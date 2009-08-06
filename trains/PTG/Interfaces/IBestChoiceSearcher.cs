using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration.Interfaces
{
    /// <summary>
    /// Interface for best choice searcher.
    /// </summary>
    public interface IBestChoiceSearcher
    {
        /// <summary>
        /// Chooses the best record, the proper Set, from matrix and store into result factor range record. 
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="resultFactorRangeRecord">The result factor range record.</param>
        /// <returns></returns>
        Boolean chooseBestRecord(Set[,] matrix, out FactorRangeRecord resultFactorRangeRecord);

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <returns></returns>
        String getDescription();
    }

    namespace BestChoiceSearchers
    {

        /// <summary>
        /// Deterministic searcher implements IBestChoiceSearcher interface.
        /// </summary>
        public class DeterministicSearcher : IBestChoiceSearcher
        {

            #region IBestChoiceSearcher Members

            /// <summary>
            /// Chooses the best record, the proper Set, from matrix and store into result factor range record.
            /// </summary>
            /// <param name="matrix">The matrix.</param>
            /// <param name="resultFactorRangeRecord">The result factor range record.</param>
            /// <returns></returns>
            public bool chooseBestRecord(Set[,] matrix, out FactorRangeRecord resultFactorRangeRecord)
            {
                // use deterministic choice
                return BestSearchUtil.deterministicSearchForBestRecord(matrix, out resultFactorRangeRecord);
            }

            /// <summary>
            /// Gets the description.
            /// </summary>
            /// <returns></returns>
            public string getDescription()
            {
                return "Deterministic searcher";
            }

            #endregion

        }

        public class ProbableSearcher : IBestChoiceSearcher
        {

            #region IBestChoiceSearcher Members

            /// <summary>
            /// Chooses the best record, the proper Set, from matrix and store into result factor range record.
            /// </summary>
            /// <param name="matrix">The matrix.</param>
            /// <param name="resultFactorRangeRecord">The result factor range record.</param>
            /// <returns></returns>
            public bool chooseBestRecord(Set[,] matrix, out FactorRangeRecord resultFactorRangeRecord)
            {
                // use probablistic choice
                return BestSearchUtil.probableSearchForBestRecord(matrix, out resultFactorRangeRecord);
            }

            /// <summary>
            /// Gets the description.
            /// </summary>
            /// <returns></returns>
            public string getDescription()
            {
                return "Probabilistic searcher";
            }

            #endregion
        }
    }
}
