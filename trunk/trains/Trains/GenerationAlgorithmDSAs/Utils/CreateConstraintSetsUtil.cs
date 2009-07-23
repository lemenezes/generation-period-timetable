using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeriodicTimetableGeneration.Properties;

namespace PeriodicTimetableGeneration.GenerationAlgorithmDSAs
{
    public static class CreateConstraintSetsUtil
    {
        #region Setting Properties

        public static int MODULO_DEFAULT
        {
            get 
            {
                return Settings.Default.Modulo;
            }
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
                Set newSet = new Set(GenerationAlgorithmDSAUtil.createSequenceOfNumber(i*period, i*period + size - 1), MODULO_DEFAULT);
                // create minimization solutionFactor for appropriate discrete set
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
            constraint.DiscreteSet = new Set(GenerationAlgorithmDSAUtil.createSequenceOfNumber(sizeOfFullDiscreteSet), MODULO_DEFAULT);
            // create minimization solutionFactor for appropriate discrete set
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
				Set newSet = new Set(GenerationAlgorithmDSAUtil.createSequenceOfNumber(i * period, i * period + size / (frequency) - 1), MODULO_DEFAULT);
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

    }
}
