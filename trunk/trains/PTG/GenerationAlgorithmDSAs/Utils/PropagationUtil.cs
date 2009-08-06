using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeriodicTimetableGeneration.Interfaces;
using PeriodicTimetableGeneration.GenerationAlgorithmDSAs;

namespace PeriodicTimetableGeneration
{

    /// <summary>
    /// Class represents and implements utility methods for propagation.
    /// </summary>
	public static class PropagationUtil
	{

		// TODO: move to the IPropagator Iface.

        /// <summary>
        /// Runs the propagation algorithm.
        /// Create discrete set for constraints, normalize and merge them, and propagate constraints' sets in matrix.
        /// </summary>
        /// <param name="originalConstraints">The original constraints.</param>
        /// <param name="constraintSetsCreator">The constraint sets creator.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
		public static PropagationResult runPropagationAlgorithm(List<Constraint> originalConstraints, IConstraintSetsCreator constraintSetsCreator, int size)
		{
			// create working copy of constraints

			List<Constraint> constraints = GenerationAlgorithmDSAUtil.cloneConstraints(originalConstraints);

			//------createConstraintSet-potential-set-for-constraints-----------------------

			constraints = constraintSetsCreator.createConstraintSets(constraints, size);

			//------modification-constraints----------------------------------

            //LogUtil.printConstraintsToFile(constraints, "originalConstraints");

			// normalize constraints
			constraints = ConstraintUtil.normalizeConstraints(constraints);

            //LogUtil.printConstraintsToFile(constraints, "normalizedConstraints");

			// find equivalent constraints
			List<List<Constraint>> groupOfconstraints = ConstraintUtil.findEquivalentConstraints(constraints);
			// try to merge them
			constraints = ConstraintUtil.mergeEquivalentConstrains(groupOfconstraints);

            //LogUtil.printConstraintsToFile(constraints, "mergedConstraints");

			// createConstraintSet a hashtable only of all trainLines used in constraints
			List<TrainLine> trainLinesMap = GenerationAlgorithmDSAUtil.createTrainLineMap(constraints);
			// store constraints - into constraintCache
			ConstraintCache.getInstance().setCacheContent(constraints);
			// create matrix of discrete sets
			Set[,] setMatrix = GenerationAlgorithmDSAUtil.createDiscretSetMatrix(constraints, trainLinesMap);


			// createConstraintSet constraint's matrix
			//this.constraintMatrix = GenerationAlgorithmPESPUtil.createConstraintMatrix(constraints, trainLinesMap);



			//-------propagation-part-of-algorithm--------------------------------------------------------
			PropagationUtil.propagate(setMatrix, trainLinesMap);

			return new PropagationResult(setMatrix, trainLinesMap);
		}

        /// <summary>
        /// Propagates the specified matrix of discrete sets.
        /// Matrix S must hold true for: S[i,j] is subset of S[i,k] + S[k,j].
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="trainLinesMap">The train lines map.</param>
		public static void propagate(Set[,] matrix, List<TrainLine> trainLinesMap)
		{
			Boolean changed = true;			

			//printToFile(matrix, "matrixBefore");

			int loop = 0;
			// loop while the iteration was with change
			while (changed)
			{
				// nothing changed yet
				changed = false;
				// loop over all combination i,j,k
				for (int k = 0; k < trainLinesMap.Count; k++)
					for (int i = 0; i < trainLinesMap.Count; i++)
						for (int j = i; j < trainLinesMap.Count; j++)
						{
							// if at least 2 of indices are equal ,then continue, or if i > j (search only when i<)
							//if (i == j || j == k || i == k || i > j)
                            if (j == k || i == k)
								continue;
							// make a addition of two sets on [i,k] and [k,j]
							Set additionSet = Set.Addition(matrix[i, k], matrix[k, j]);
							// if the set on [i,j] is not a proper subset of additionSet
							if (!matrix[i, j].IsSubsetOf(additionSet))
							{
								// on [i,j] assign intersection of set on [i,j] and additionSet
								matrix[i, j].IntersectWith(additionSet);
								// createCopy
								Set reverseSet = new Set(matrix[i, j]);
								// and reverse it
								reverseSet.Reverse();
								// on [j,i] assign reverseSet of [i,j]
								matrix[j, i] = reverseSet;
								// something changed so:
								changed = true;
							}
						}
				loop++;
			}

			//printToFile(matrix, "matrixAfter");
			//Console.Out.WriteLine("Propagate matrix to stable: {0} loops", loop);

		}

	}

}
