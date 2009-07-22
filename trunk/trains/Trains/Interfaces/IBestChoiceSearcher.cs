using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration.Interfaces
{
    public interface IBestChoiceSearcher
    {
        FactorRangeRecord chooseBestChoice(Set[,] matrix);
    }
}
