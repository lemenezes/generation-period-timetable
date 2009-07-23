using System;
using System.Collections.Generic;
using System.Text;
using PeriodicTimetableGeneration;
using System.Collections;
using PeriodicTimetableGeneration.Properties;
using PeriodicTimetableGeneration.Solutions;

namespace PeriodicTimetableGeneration
{
	public static class GenerationAlgorithmDSAUtil
	{
		#region Settings Properties

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
		/// Creates the constraint matrix.
		/// </summary>
		/// <param name="constraints">The constraints.</param>
		/// <param name="trainLineMap">The train line map.</param>
		/// <returns>matrix of constraints.</returns>
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

        #region Timetable Construction Methods

        public static List<Timetable> constructTimetables(List<Solution> solutions)
        {
            throw new System.NotImplementedException();
        }

        public static List<Timetable> constructTimetables(List<Solution> solutions, int numberOfTimetables)
        {
            throw new System.NotImplementedException();
        }

        public static Timetable constructTimetable(Solution solution)
        {
            throw new System.NotImplementedException();
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
                    {
                        // initialize with a discreteSet with sequence length 1, {0}
                        setMatrix[i, j] = new Set(createSequenceOfNumber(1), MODULO_DEFAULT);
                        // create default minimization solutionFactor, which is for passengers = 0;
                        setMatrix[i, j].createMinimizationFactor(0);
                    }
                    else
                    {   // otherwise initialize with a discreteSet
                        setMatrix[i, j] = new Set(createSequenceOfNumber(sizeOfDiscretSet), MODULO_DEFAULT);
                    }
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



		#endregion




	}
}
