using System;
using System.Collections.Generic;
using System.Text;
using PeriodicTimetableGeneration.GenerationAlgorithmDSAs;

namespace PeriodicTimetableGeneration.Interfaces
{
    /// <summary>
    /// Infercafe for constraint sets creator.
    /// </summary>
    public interface IConstraintSetsCreator
    {
        /// <summary>
        /// Creates the sets for constraints.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        List<Constraint> createConstraintSets(List<Constraint> constraints, int size);

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <returns></returns>
        String getDescription();
    }

	namespace ConstraintSetsCreators
	{

        /// <summary>
        /// Create constraint sets, the same transfer time is guqranteed for all transfers.
        /// Implements constraint sets creator.
        /// </summary>
		public class SameTransferTime : IConstraintSetsCreator 
		{
			#region IConstraintSetsCreator Members

            /// <summary>
            /// Creates the sets for constraints.
            /// </summary>
            /// <param name="constraints">The constraints.</param>
            /// <param name="size">The size.</param>
            /// <returns></returns>
			public List<Constraint> createConstraintSets(List<Constraint> constraints, int size)
			{
                // same transfer time
				return CreateConstraintSetsUtil.createConstraintSets_SameTransferTime(constraints, size);
			}

            /// <summary>
            /// Gets the description.
            /// </summary>
            /// <returns></returns>
            public string getDescription()
            {
                return "Same discrete sets";
            }

            #endregion
        }

        /// <summary>
        /// Create constraint sets, the alfa*period transfer time is quaranteed for all transfers.
        /// Implements constraint sets creator.
        /// </summary>
		public class AlfaTTransferTime : IConstraintSetsCreator
		{
			#region IConstraintSetsCreator Members

            /// <summary>
            /// Creates the sets for constraints.
            /// </summary>
            /// <param name="constraints">The constraints.</param>
            /// <param name="size">The size.</param>
            /// <returns></returns>
			public List<Constraint> createConstraintSets(List<Constraint> constraints, int size)
			{
                // alfta*period transfer time
                return CreateConstraintSetsUtil.createConstraintSets_AlfaTTransferTime(constraints, size);
			}


            /// <summary>
            /// Gets the description.
            /// </summary>
            /// <returns></returns>
            public string getDescription()
            {
                return "Alpha*T size of discrete sets";
            }

            #endregion
        }

        /// <summary>
        /// Create constraint full discrete sets.
        /// Implements constraint sets creator.
        /// </summary>
		public class FullDiscreteSet : IConstraintSetsCreator
		{
			#region IConstraintSetsCreator Members

            /// <summary>
            /// Creates the sets for constraints.
            /// </summary>
            /// <param name="constraints">The constraints.</param>
            /// <param name="size">The size.</param>
            /// <returns></returns>
			public List<Constraint> createConstraintSets(List<Constraint> constraints, int size)
			{
                // no transfer time is quaranteed
                return CreateConstraintSetsUtil.createConstraintSets_FullDiscreteSets(constraints, size);
			}

            /// <summary>
            /// Gets the description.
            /// </summary>
            /// <returns></returns>
            public string getDescription()
            {
                return "Full discrete sets";
            }

            #endregion
        }

	}

}
