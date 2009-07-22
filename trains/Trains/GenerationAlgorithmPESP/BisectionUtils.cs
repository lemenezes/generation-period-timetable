using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeriodicTimetableGeneration.Interfaces;

namespace PeriodicTimetableGeneration
{

	/// <summary>
	/// Bisection utils - useful for bisection implementing propagators.
	/// </summary>
    public static class BisectionUtils
    {

		/// <summary>
		/// Runs the bisection algorithm for initial phase of constraint propagation.
		/// </summary>
		/// <param name="constraints">List of constraints.</param>
		/// <param name="constraintSetsCreator">Creator of the sets of constraints.</param>
		/// <param name="lowerBoundStart">Lower bound for the bisection search.</param>
		/// <param name="upperBoundStart">Upper bound for the bisection search.</param>
		/// <returns>Result of the initial algorithm phase.</returns>
		public static PropagationResult Bisect(List<Constraint> constraints, IConstraintSetsCreator constraintSetsCreator, int lowerBoundStart, int upperBoundStart)
        {
			// create the result.
			PropagationResult result = new PropagationResult();

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
				result = PropagationUtils.runPropagationAlgorithm(constraints, constraintSetsCreator, midpoint);

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

			// if the current found value is not valid, move to the looser restrictions
            while (!MatrixUtils.isValid(setMatrix))
            {
				result = PropagationUtils.runPropagationAlgorithm(constraints, constraintSetsCreator, ++midpoint);
            }

			// return the found result.
			return result;
        }

    }
}
