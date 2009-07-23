using System;
using System.Collections.Generic;
using System.Text;
using PeriodicTimetableGeneration;
using System.Collections;
using PeriodicTimetableGeneration.Properties;

namespace PeriodicTimetableGeneration
{
	public static class GenerationAlgorithmPESPUtil
	{
		#region Constant Fields

		/// <summary>
		/// Default modulo value, Z_120.
		/// </summary>
		public static int MODULO_DEFAULT
		{
			get
			{
				return Settings.Default.Modulo;
			}
		}

		#endregion

		#region Public Static Methods

		#region Create Methods

		/// <summary>
		/// Creates the constraint from transfer.
		/// </summary>
		/// <param name="transfer">The transfer.</param>
		/// <returns>The constraint.</returns>
		public static Constraint createConstraint(Transfer transfer)
		{
			return new Constraint(transfer);
		}

		/// <summary>
		/// Creates the constraints from transfers.
		/// </summary>
		/// <param name="transfers">The transfers.</param>
		/// <returns>List of constraints.</returns>
		public static List<Constraint> createConstraints(List<Transfer> transfers)
		{
			List<Constraint> constraints = new List<Constraint>();

			foreach (Transfer transfer in transfers)
			{
				constraints.Add(createConstraint(transfer));
			}

			return constraints;
		}

		/// <summary>
		/// Creates the transfers on each line train line respectively.
		/// </summary>
		/// <returns>List of transfers.</returns>
		public static List<Transfer> createTransfers()
		{
			List<Transfer> transfers = new List<Transfer>();
			foreach (TrainLine line in TrainLineCache.getInstance().getCacheContent())
				transfers.AddRange(GenerationAlgorithm.createTransfers(line.LineNumber));
			return transfers;
		}

		/// <summary>
		/// Creates the constraint matrix.
		/// </summary>
		/// <param name="constraints">The constraints.</param>
		/// <param name="trainLineMap">The train line map.</param>
		/// <returns>Matrix of constraints.</returns>
		public static Constraint[,] createConstraintMatrix(List<Constraint> constraints, List<TrainLine> trainLineMap)
		{
			//Constraint[,] matrix = new Constraint[trainLineMap.Count,trainLineMap.Count];
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Creates the discret set matrix from constraint's sets.
		/// </summary>
		/// <param name="constraints">The constraints.</param>
		/// <param name="trainLineMap">The train line map.</param>
		/// <returns>The matrix of Set.</returns>
		public static Set[,] createDiscretSetMatrix(List<Constraint> constraints, List<TrainLine> trainLineMap)
		{
			// create matrix
			Set[,] setMatrix = new Set[trainLineMap.Count, trainLineMap.Count];

			// initialize matrix with default discrete sets, {0} on diagonal, {0..size} elsewhere
			setDefaultValues(setMatrix, MODULO_DEFAULT);

			// initialize matrix according constraints
			foreach (Constraint constraint in constraints)
			{
				// update indices (indexes) in instance of constraint related to matrix
				constraint.Index1 = findIndexTrainLine(trainLineMap, constraint.TrainLine1);
				constraint.Index2 = findIndexTrainLine(trainLineMap, constraint.TrainLine2);
				// initialize item on [index1,index2] with discrete set of appropriate constraint
				setMatrix[constraint.Index1, constraint.Index2] = new Set(constraint.DiscreteSet);
				// initialize item on transposition, on [index2,index1] with reverse discrete set
				Set tempSet = new Set(constraint.DiscreteSet);
				tempSet.Reverse();
				setMatrix[constraint.Index2, constraint.Index1] = tempSet;
			}

			return setMatrix;
		}

		/// <summary>
		/// Creates the map of disticnt train lines used in constraints only.
		/// </summary>
		/// <param name="constraints">The constraints.</param>
		/// <returns>List of train line.</returns>
		public static List<TrainLine> createTrainLineMap(List<Constraint> constraints)
		{
			List<TrainLine> trainLineMap = new List<TrainLine>();
			// loop over all constraints
			foreach (Constraint constraint in constraints)
			{
				// inspect all proper train line
				// if constrain's trainLine1 not include
				if (!containsTrainLine(trainLineMap, constraint.TrainLine1))
				{
					// then add it into Map
					trainLineMap.Add(constraint.TrainLine1);
				}
				// if constrain's trainLine2 not include
				if (!containsTrainLine(trainLineMap, constraint.TrainLine2))
				{
					// then add it into Map
					trainLineMap.Add(constraint.TrainLine2);
				}
			}
			return trainLineMap;
		}



		/// <summary>
		/// Creates the sequence of number.
		/// Starts from lower bound to upper bound inclusive.
		/// </summary>
		/// <param name="lowerBound">The lower bound.</param>
		/// <param name="upperBound">The upper bound.</param>
		/// <returns>Sequence of int.</returns>
		public static List<int> createSequenceOfNumber(int lowerBound, int upperBound)
		{
			List<int> sequence = new List<int>();
			for (int i = lowerBound; i <= upperBound; i++)
			{
				sequence.Add(i);
			}
			return sequence;
		}

		/// <summary>
		/// Creates the sequence of number.
		/// Strats form 0 to length-1.
		/// </summary>
		/// <param name="length">The length.</param>
		/// <returns>Sequence of int.</returns>
		public static List<int> createSequenceOfNumber(int length)
		{
			return createSequenceOfNumber(0, length - 1);
        }

        #endregion


        #region Create Constraint Sets' Methods

        /// <summary>
		/// Creates the Sets for constraints with the same size of discrete set.
        /// Therefore same maximal transfer time is quaranteed for all transfers.
		/// </summary>
		/// <param name="constraints">The constraints.</param>
		/// <param name="size">The size of set.</param>
		/// <returns>List of constraints.</returns>
		public static List<Constraint> createConstraintSets_SameTransferTime(List<Constraint> constraints, int size)
		{
			foreach (Constraint constraint in constraints)
			{
				createConstraintSet_SameTransferTime(constraint, size);
			}
			return constraints;
		}

		/// <summary>
		/// Creates the Set for constraint.
        /// Calculate with frequency of within Modulo Model.
        /// Maximal transfer time is then same for all transfers.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="size">The size of set.</param>
		public static void createConstraintSet_SameTransferTime(Constraint constraint, int size)
		{
            List<Set> newSets = new List<Set>();
            // get minimal period
            int period = Math.Min((int)constraint.TrainLine1.Period, (int)constraint.TrainLine2.Period);
            // calculate frequency
            int frequency = MODULO_DEFAULT / period;
            // create as many seqence as they are within modulo
            for (int i = 0; i < MODULO_DEFAULT / period; i++)
            {
                // create discrete set {60*i .. 60*i + size -1}
                Set newSet = new Set(createSequenceOfNumber(i*period, i*period + size - 1), MODULO_DEFAULT);
                // create minimization factor for appropriate discrete set
                // according the amount of passenger on transfer
                newSet.createMinimizationFactor(constraint.Transfer.Passengers);
                // add newSet
                newSets.Add(newSet);
            }

            Set finalSet = null;
			Boolean first = true;
			// union sets
			foreach (Set set in newSets)
			{
				// if first, just set as a final
				if (first)
				{
					finalSet = set;
					first = false;
				}
				// otherwise unions with next one
				else
				{
					finalSet.UnionWith(set);
				}
			}
			// finally initialize Set for Constraint
			constraint.DiscreteSet = finalSet;
		}


        /// <summary>
        /// Creates the Sets for constraints with full discrete sets.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static List<Constraint> createConstraintSets_FullDiscreteSets(List<Constraint> constraints, int size)
        {
            foreach (Constraint constraint in constraints) 
            {
                createConstraintSet_FullDiscreteSets(constraint, size);
            }
            return constraints;
        }

        /// <summary>
        /// Creates the Set for constraint with full discrete set.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        /// <param name="size">The size.</param>
        private static void createConstraintSet_FullDiscreteSets(Constraint constraint, int sizeOfFullDiscreteSet)
        {
            // create Set for constraint with full discrete set
            constraint.DiscreteSet = new Set(createSequenceOfNumber(sizeOfFullDiscreteSet), MODULO_DEFAULT);
            // create minimization factor for appropriate discrete set
            // according the amount of passenger on transfer
            constraint.DiscreteSet.createMinimizationFactor(constraint.Transfer.Passengers);
        }

		/// <summary>
		/// Creates the Sets for constraints with respect to period T of both lines on Constraint.
		/// </summary>
		/// <param name="constraints">The constraints.</param>
		/// <param name="size">The size of set.</param>
		/// <returns>List of Constraints.</returns>
        public static List<Constraint> createConstraintSets_AlfaTTransferTime(List<Constraint> constraints, int size)
		{
			foreach (Constraint constraint in constraints)
			{
				createConstraintSet_AlfaTTransferTime(constraint, size);
			}
			return constraints;
		}


		/// <summary>
        /// Creates the Set for constraint with respect to period T of both lines on Constraint.
		/// Calculate with frequency of within Modulo Model.
        /// Maximal transfer time is then alfa*periodLine for all transfers.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="size">The size of set.</param>
		public static void createConstraintSet_AlfaTTransferTime(Constraint constraint, int size)
		{
			List<Set> newSets = new List<Set>();
			// get minimal period
			int period = Math.Min((int)constraint.TrainLine1.Period, (int)constraint.TrainLine2.Period);
            // calculate frequency
            int frequency = MODULO_DEFAULT / period;
			// create as many seqence as they are within modulo
			for (int i = 0; i < frequency; i++)
			{
				// new set {60*i .. 60*i + size/frequency - 1}, transfer time is shorten by frequency
				Set newSet = new Set(createSequenceOfNumber(i * period, i * period + size / (frequency) - 1), MODULO_DEFAULT);
				// new minfactor for set
				newSet.createMinimizationFactor(constraint.Transfer.Passengers);
				// add it
				newSets.Add(newSet);
			}

			Set finalSet = null;
			Boolean first = true;
			// union sets
			foreach (Set set in newSets)
			{
				// if first, just set as a final
				if (first)
				{
					finalSet = set;
					first = false;
				}
				// otherwise unions with next one
				else
				{
					finalSet.UnionWith(set);
				}
			}
			// finally initialize Set for Constraint
			constraint.DiscreteSet = finalSet;
		}

		#endregion

		#region Constraint Manipulating Methods

		/// <summary>
		/// Finds the equivalent constraints.
		/// </summary>
		/// <param name="constraints">The constraints.</param>
		/// <returns>Groups of equivalent constraints.</returns>
		public static List<List<Constraint>> findEquivalentConstraints(List<Constraint> constraints)
		{
			List<List<Constraint>> equivalentConstraints = new List<List<Constraint>>();
			// loop over all appropriate constraints
			foreach (Constraint constraint in constraints)
			{
				// try to find equivalent group of constraint
				List<Constraint> group = findEquivalentConstraintGroup(equivalentConstraints, constraint);
				// if already exists group
				if (group != null)
					// add constraint there
					group.Add(constraint);
				// otherwise create new group and add it as a new member
				else
				{
					group = new List<Constraint>();
					group.Add(constraint);
					equivalentConstraints.Add(group);
				}
			}
			// return List of List of equivalent constraints
			return equivalentConstraints;
		}

		/// <summary>
		/// Merges the equivalent constrains.
		/// </summary>
		/// <param name="constraints">The group of equivalent constraints.</param>
		/// <returns>List of constraints.</returns>
		public static List<Constraint> mergeEquivalentConstrains(List<List<Constraint>> constraints)
		{
			List<Constraint> mergedConstraints = new List<Constraint>();

			// loop over all equivalent groups
			foreach (List<Constraint> group in constraints)
			{
				// merge group into the one constraint and add
				mergedConstraints.Add(mergeEquivalentConstraintGroup(group));
			}

			return mergedConstraints;
		}

		/// <summary>
		/// Normalizes the constraints.
		/// </summary>
		/// <param name="constraints">The constraints.</param>
		/// <returns>List of constraints.</returns>
		public static List<Constraint> normalizeConstraints(List<Constraint> constraints)
		{
			foreach (Constraint constraint in constraints)
			{
				constraint.normalizeConstraint();
			}
			return constraints;
		}

		#endregion


		#region Copy Methods

		/// <summary>
		/// Create a deep copy of the list of constraints.
		/// </summary>
		/// <param name="constraints">The constraints.</param>
		/// <returns></returns>
		public static List<Constraint> cloneConstraints(List<Constraint> constraints)
		{
			List<Constraint> newConstraints = new List<Constraint>();

			foreach (Constraint constraint in constraints)
			{
				// add copy
				newConstraints.Add(new Constraint(constraint));

			}

			return newConstraints;
		}


		/// <summary>
		/// Creates a deep copy of discrete set matrix.
		/// </summary>
		/// <param name="matrix">The matrix.</param>
		/// <returns></returns>
		public static Set[,] cloneDiscreteSetMatrix(Set[,] matrix)
		{
			Set[,] m = new Set[matrix.GetLength(0), matrix.GetLength(1)];
			for (int i = 0, rows = matrix.GetLength(0); i < rows; ++i)
			{
				for (int j = 0, cols = matrix.GetLength(1); j < cols; ++j)
				{
					m[i, j] = new Set(matrix[i, j]);
				}
			}

			return m;
		}

		#endregion

		#endregion

		#region Private Methods

		/// <summary>
		/// Sets the default values for fields.
		/// </summary>
		/// <param name="setMatrix">The set matrix.</param>
		/// <param name="sizeOfDiscretSet">The size of discret set.</param>
		private static void setDefaultValues(Set[,] setMatrix, int sizeOfDiscretSet)
		{
			// loop over all rows
			for (int i = 0; i < setMatrix.GetLength(0); i++)
				// loop over all rows
				for (int j = 0; j < setMatrix.GetLength(1); j++)
				{
					// diagonal
					if (i.Equals(j))
						// initialize with a discreteSet with sequence length 1, {0}
						setMatrix[i, j] = new Set(createSequenceOfNumber(1), MODULO_DEFAULT);
					else
						// otherwise initialize with a discreteSet
						setMatrix[i, j] = new Set(createSequenceOfNumber(sizeOfDiscretSet), MODULO_DEFAULT);
				}
		}

		/// <summary>
		/// Determines whether [the specified lines] [contains train line].
		/// </summary>
		/// <param name="lines">The lines.</param>
		/// <param name="line">The line.</param>
		/// <returns>
		/// 	<c>true</c> if [the specified lines] [contains train line]; otherwise, <c>false</c>.
		/// </returns>
		private static Boolean containsTrainLine(List<TrainLine> lines, TrainLine line)
		{
			Boolean contains = false;
			if (findTrainLine(lines, line) != null)
			{
				contains = true;
			}
			return contains;
		}

		/// <summary>
		/// Finds the train line in list of lines.
		/// </summary>
		/// <param name="lines">The lines.</param>
		/// <param name="line">The line.</param>
		/// <returns>Train Line.</returns>
		private static TrainLine findTrainLine(List<TrainLine> lines, TrainLine line)
		{
			TrainLine wantedLine = null;
			foreach (TrainLine l in lines)
			{
				if (l.LineNumber.Equals(line.LineNumber))
				//if (l.Equals(line)) 
				{
					wantedLine = l;
					break;
				}
			}
			return wantedLine;
		}

		/// <summary>
		/// Finds the index of train line in list of lines.
		/// </summary>
		/// <param name="lines">The lines.</param>
		/// <param name="line">The line.</param>
		/// <returns>Index.</returns>
		private static int findIndexTrainLine(List<TrainLine> lines, TrainLine line)
		{
			int wantedLine = -1;
			int index = 0;
			foreach (TrainLine l in lines)
			{
				//if(l.LineNumber.Equals(line.LineNumber))
				if (l.Equals(line))
				{
					wantedLine = index;
					break;
				}
				// increment index
				index++;
			}
			return wantedLine;
		}

		/// <summary>
		/// Finds the group of equivalent constraints for specified constraint.
		/// </summary>
		/// <param name="equivalentConstraints">The groups of equivalent constraints.</param>
		/// <param name="constraint">The constraint.</param>
		/// <returns>The group of equivalent constraints.</returns>
		private static List<Constraint> findEquivalentConstraintGroup(List<List<Constraint>> equivalentConstraints, Constraint constraint)
		{
			List<Constraint> equivalentGroup = null;
			// loop over all lists of equivalent constraints
			foreach (List<Constraint> group in equivalentConstraints)
			{
				// if not empty compare with a first item of that list
				if (!group.Count.Equals(0) && group[0].equivalentWith(constraint))
				{
					equivalentGroup = group;
					break;
				}
			}

			// if it' s if not return null;
			return equivalentGroup;
		}

		/// <summary>
		/// Merges the equivalent constraint group into one constraintt.
		/// </summary>
		/// <param name="constraints">The list of constraints.</param>
		/// <returns>The constraint.</returns>
		private static Constraint mergeEquivalentConstraintGroup(List<Constraint> constraints)
		{
			Constraint mergedConstraint;
			// if empty, return null
			if (constraints.Equals(0))
				return null;
			// if not empty, dont merge
			else
			{
				// set the first initial constraint
				mergedConstraint = constraints[0];
				// and remove it from group
				constraints.RemoveAt(0);
			}

			// loop over all constraints in group
			foreach (Constraint constraint in constraints)
			{
				// if they are not pair equivalent, reverse
				if (!constraint.equivalentPairWith(mergedConstraint))
				{
					constraint.reverseConstraint();
				}
				mergedConstraint.mergeConstraintWith(constraint);
			}

			return mergedConstraint;
		}

		#endregion


	}
}
