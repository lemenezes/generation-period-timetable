using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PeriodicTimetableGeneration.Solutions
{

    /// <summary>
    /// Struct represents an a item of solution. One item of Solution[,] which is hold by Solution.
    /// </summary>
    public struct SolutionItem
    {
        #region Private Fields

        /// <summary>
        /// Minute.
        /// </summary>
        private int minute;
        /// <summary>
        /// Factor related with minute.
        /// </summary>
        private int factor;
        /// <summary>
        /// Indicates if proposed Set is single.
        /// </summary>
        private Boolean notSingleton;

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionItem"/> struct.
        /// </summary>
        /// <param name="s">The s.</param>
        public SolutionItem(Set set)
        {

            if (set.Count == 1)
            {
                minute = 0;
                factor = 0;

                // Should be the only one element in the set, so remember it.
                KeyValuePair<int, int> p = set.MinimizationFactor.First();
                minute = p.Key;
                factor = p.Value;
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

        /// <summary>
        /// Gets the factor.
        /// </summary>
        /// <value>The factor.</value>
        public int Factor
        {
            get
            {
                return factor;
            }    
        }

        /// <summary>
        /// Gets the minute.
        /// </summary>
        /// <value>The minute.</value>
        public int Minute
        {
            get
            {
                return minute;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [not singleton].
        /// </summary>
        /// <value><c>true</c> if [not singleton]; otherwise, <c>false</c>.</value>
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

    /// <summary>
    /// Struct represents solution, consists of solution items.
    /// </summary>
    public struct Solution
    {
        #region Private Fields

        /// <summary>
        /// Holds solution items.
        /// </summary>
        private SolutionItem[] solutionVector;
        /// <summary>
        /// Factor of solution.
        /// </summary>
        private int solutionFactor;

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Solution"/> struct.
        /// </summary>
        /// <param name="discreteSetMatrix">The discrete set matrix.</param>
        public Solution(Set[,] discreteSetMatrix)
        {
            solutionVector = new SolutionItem[discreteSetMatrix.GetLength(0)];
            solutionFactor = 0;

            // loop over all items in upper triangle part of matrix
            for (int i = 0, rows = discreteSetMatrix.GetLength(0); i < rows; ++i)
            {
                for (int j = i + 1, cols = discreteSetMatrix.GetLength(1); j < cols; ++j)
                {
                    if (i == 0)
                    {
                        // solution is presented by one row of matrix
                        solutionVector[j] = new SolutionItem(discreteSetMatrix[i, j]);
                    }

                    // for all items in upper triangle part - calculate global min factor
                    solutionFactor += discreteSetMatrix[i, j].MinimizationFactor.Values.First();
                }
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets the solution factor.
        /// </summary>
        /// <value>The solution factor.</value>
        public int SolutionFactor
        {
            get
            {
                return solutionFactor;
            }
        }

        /// <summary>
        /// Gets the solution vector.
        /// </summary>
        /// <value>The solution vector.</value>
        public SolutionItem[] SolutionVector
        {
            get
            {
                return solutionVector;
            }
        }

        #endregion

    }
}
