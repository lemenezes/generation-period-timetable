using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration.Solutions
{

    /// <summary>
    /// Struct represent an a item of solution. One item of Solution[,] which is hold by Solution.
    /// </summary>
    public struct SolutionItem
    {
        #region Private Fields

        private int minute;
        private int factor;
        private Boolean notSingleton;

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionItem"/> struct.
        /// </summary>
        /// <param name="s">The s.</param>
        public SolutionItem(Set s)
        {

            if (s.Count == 1)
            {
                minute = 0;
                factor = 0;

                // Should be the only one element in the set, so remember it.
                foreach (KeyValuePair<int, int> p in s.MinimizationFactor)
                {
                    minute = p.Key;
                    factor = p.Value;
                }
                notSingleton = false;
            }
            else
            {
                // Not constrained set - give the negative values for it.
                minute = -1;
                factor = 0;
                notSingleton = true;
            }
        }

        #endregion


        #region Properties

        public int Factor
        {
            get
            {
                return factor;
            }    
        }

        public int Minute
        {
            get
            {
                return minute;
            }
        }

        public Boolean NotSingleton
        {
            get
            {
                return notSingleton;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format("Minute: {0}, solutionFactor: {1}", minute, factor);
        }

        #endregion

    }
    
    public struct Solution
    {
        #region Private Fields

        public SolutionItem[,] solutionMatrix;
        public int solutionFactor;

        #endregion


        #region Constructor

        public Solution(Set[,] discreteSetMatrix)
        {
            solutionMatrix = new SolutionItem[discreteSetMatrix.GetLength(0), discreteSetMatrix.GetLength(1)];
            solutionFactor = 0;
            for (int i = 0, rows = discreteSetMatrix.GetLength(0); i < rows; ++i)
            {
                for (int j = 0, cols = discreteSetMatrix.GetLength(1); j < cols; ++j)
                {
                    solutionMatrix[i, j] = new SolutionItem(discreteSetMatrix[i, j]);
                    solutionFactor += solutionMatrix[i, j].Factor;
                }
            }
        }

        #endregion


        #region Properties

        public int SolutionFactor
        {
            get
            {
                return solutionFactor;
            }
        }

        public SolutionItem[,] SolutionSingleMatrix
        {
            get
            {
                return solutionMatrix;
            }
        }

        #endregion

    }
}
