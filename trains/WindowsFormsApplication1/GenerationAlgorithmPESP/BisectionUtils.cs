using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeriodicTimetableGeneration.Interfaces;

namespace PeriodicTimetableGeneration
{
    public static class BisectionUtils
    {

        public static Set[,] Bisect(List<Constraint> constraints, IConstraintPropagator propagator, int lowerBoundStart, int upperBoundStart)
        {
            //-------bisection-algorithm-for-finding-the-proper-bound-for-discret-set------
            // set default lower and upper bounds
            int lowerBound = lowerBoundStart;
            int upperBound = upperBoundStart;
            // set the boolean loop variable
            Boolean loop = true;

            Set[,] setMatrix = null;
            int midpoint = 0;

            // loop while bounds are not crossed and loop
            while ((upperBound - lowerBound) > 1 && loop)
            {
                midpoint = (upperBound + lowerBound) / 2;

                // run rpopagation algorithm, which create constraintSet, constraintMatrix
                // and propagate it (make it stable)
                setMatrix = propagator.runPropagationAlgorithm(constraints, midpoint);

                // if the constraint matrix is stable (previously), and valid
                if (MatrixUtils.isValid(setMatrix))
                {
                    // change upperbound of interval, right part is thrown away
                    upperBound = midpoint;
                }
                else
                {
                    // change lowerbound of interval, left part is thrown away
                    lowerBound = midpoint;
                }
            }
            while (!MatrixUtils.isValid(setMatrix))
            {
                setMatrix = propagator.runPropagationAlgorithm(constraints, ++midpoint);
            }

            return setMatrix;
        }

    }
}
