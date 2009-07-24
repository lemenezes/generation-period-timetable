using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{

    /// <summary>
    /// Record for every constraint set describing how suitable it is for labeling.
    /// </summary>
    public struct FactorRangeRecord
    {

        /// <summary>
        /// Creates the solutionFactor record when optimizing the order of the backtracking variable labeling.
        /// </summary>
        /// <param name="set">Set of constraints.</param>
        /// <param name="record">Record describing how the @c set of constraints is suitable for the labeling.</param>
        /// <returns>True iff the record has been created.</returns>
        public static bool createFactorRecord(Set set, ref FactorRangeRecord record)
        {
            if (set.MinimizationFactor.Count <= 1)
            {
                return false;
            }

            int maxVal = int.MinValue;
            int minVal = int.MaxValue;
            foreach (int factor in set.MinimizationFactor.Values)
            {
                if (maxVal < factor)
                {
                    maxVal = factor;
                }

                if (minVal > factor)
                {
                    minVal = factor;
                }
            }

            record.RangeFactor = maxVal - minVal;
            return true;
        }

        /// <summary>
        /// Row coordintate of the matrix where the set is stored.
        /// </summary>
        public int Row
        {
            get;
            set;
        }

        /// <summary>
        /// Col coordinate of the matrix where the set is stored.
        /// </summary>
        public int Col
        {
            get;
            set;
        }

        /// <summary>
        /// Range Minimal Factor difference for the - suitability - the bigger the better.
        /// </summary>
        public int RangeFactor
        {
            get;
            set;
        }

        /// <summary>
        /// Best set in matrix.
        /// </summary>
        public Set Set
        {
            get;
            set;
        }

        /// <summary>
        /// Item with minFactor of choosen Set.
        /// </summary>
        public int MinItemOfSet
        {
            get;
            set;
        }

    }
}
