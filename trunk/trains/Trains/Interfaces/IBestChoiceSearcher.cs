using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration.Interfaces
{
    public interface IBestChoiceSearcher
    {
        Boolean chooseBestRecord(Set[,] matrix, out FactorRangeRecord resultFactorRangeRecord);
    }

    public class DeterministicSearcher : IBestChoiceSearcher 
    {


        #region IBestChoiceSearcher Members

        public bool chooseBestRecord(Set[,] matrix, out FactorRangeRecord resultFactorRangeRecord)
        {
            return BestSearchUtil.deterministicSearchForBestRecord(matrix, out resultFactorRangeRecord);
        }

        #endregion
    }

    public class ProbableSearcher : IBestChoiceSearcher 
    {

        #region IBestChoiceSearcher Members

        public bool chooseBestRecord(Set[,] matrix, out FactorRangeRecord resultFactorRangeRecord)
        {
            return BestSearchUtil.probableSearchForBestRecord(matrix, out resultFactorRangeRecord);
        }

        #endregion
    }

}
