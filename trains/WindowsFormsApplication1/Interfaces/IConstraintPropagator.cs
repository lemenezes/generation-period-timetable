using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration.Interfaces
{
    public interface IConstraintPropagator
    {
        Set[,] runPropagationAlgorithm(List<Constraint> constraints, int size);
    }
}
