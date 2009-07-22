using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeriodicTimetableGeneration.Interfaces;

namespace PeriodicTimetableGeneration
{
	public static class PropagationUtils
	{

		// TODO: move to IPropagator Iface.
		public static PropagationResult runPropagationAlgorithm(List<Constraint> originalConstraints, IConstraintSetsCreator constraintSetsCreator, int size)
		{
			// create working copy of constraints

			List<Constraint> constraints = GenerationAlgorithmPESPUtil.cloneConstraints(originalConstraints);

			//------createConstraintSet-potential-set-for-constraints-----------------------

			constraints = constraintSetsCreator.createConstraintSet(constraints, size);

			//------modification-constraints----------------------------------

			LogUtils.printToFileConstraints(constraints, "originalConstraints");

			// normalize constraints
			constraints = GenerationAlgorithmPESPUtil.normalizeConstraints(constraints);

			LogUtils.printToFileConstraints(constraints, "normalizedConstraints");

			// find equivalent constraints
			List<List<Constraint>> groupOfconstraints = GenerationAlgorithmPESPUtil.findEquivalentConstraints(constraints);
			// try to merge them
			constraints = GenerationAlgorithmPESPUtil.mergeEquivalentConstrains(groupOfconstraints);

			LogUtils.printToFileConstraints(constraints, "mergedConstraints");

			// createConstraintSet a hashtable only of all trainLines used in constraints
			List<TrainLine> trainLinesMap = GenerationAlgorithmPESPUtil.createTrainLineMap(constraints);
			// store constraints - into constraintCache
			ConstraintCache.getInstance().setCacheContent(constraints);
			// create matrix of discrete sets
			Set[,] setMatrix = GenerationAlgorithmPESPUtil.createDiscretSetMatrix(constraints, trainLinesMap);


			// createConstraintSet constraint's matrix
			//this.constraintMatrix = GenerationAlgorithmPESPUtil.createConstraintMatrix(constraints, trainLinesMap);



			//-------propagation-part-of-algorithm--------------------------------------------------------
			PropagationUtils.propagate(setMatrix, trainLinesMap);

			return new PropagationResult(setMatrix, trainLinesMap);
		}

		public static void propagate(Set[,] matrix, List<TrainLine> trainLinesMap)
		{
			Boolean changed = true;
			// determine size of 

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
						for (int j = 0; j < trainLinesMap.Count; j++)
						{
							// if at least 2 of indices are equal ,then continue
							if (i == j || j == k || i == k)
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
