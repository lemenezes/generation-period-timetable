using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{

	/// <summary>
	/// Utilities for the matrix of sets of constraints.
	/// </summary>
    public static class MatrixUtils
    {

		/// <summary>
		/// Determines whether the specified matrix is stable.
		/// </summary>
		/// <param name="matrix">The matrix.</param>
		/// <returns>
		/// 	<c>true</c> if the specified matrix is stable; otherwise, <c>false</c>.
		/// </returns>
		public static Boolean isStable(Set[,] matrix)
		{
			Set zeroSet = new Set(new int[] { 0 }, GenerationAlgorithmDSAUtil.MODULO_DEFAULT);

			Boolean stable = true;
			// loop over all rows
			for (int i = 0, rows = matrix.GetLength(0); i < rows; i++)
			{
				// loop over all columns
				for (int j = 0, cols = matrix.GetLength(1); j < rows; j++)
				{
					// on diagonal must be {0}
					if (i == j && !matrix[i, j].IsSubsetOf(zeroSet))
					{
						// if not, matrix is not stable, return
						stable = false;
						break;
					}
					// for sets S and T on [i,j] and [j,i] must hold true S = T
					//(S subset of T and T subset of S)
					else if (!matrix[i, j].IsSubsetOf(matrix[i, j])
						|| !matrix[j, i].IsSubsetOf(matrix[i, j]))
					{
						// if not, matrix is not stable, return
						stable = false;
						break;
					}

					// other loop over all size of matrix
					for (int k = 0, rows2 = matrix.GetLength(0); k < rows2; k++)
					{
						//for indices i,j,k must hold true Set[i,j] is subset of (Set[i,k] + Set[k,j])
						if (!matrix[i, j].IsSubsetOf(Set.Addition(matrix[i, k], matrix[k, j])))
						{
							// if not, matrix is not stable, return
							stable = false;
							break;
						}
					}
				}
			}

			return stable;
		}

		/// <summary>
		/// Determines whether the specified matrix is valid. None of set is empty.
		/// </summary>
		/// <param name="matrix">The matrix.</param>
		/// <returns>
		/// 	<c>true</c> if the specified matrix is valid; otherwise, <c>false</c>.
		/// </returns>
		public static Boolean isValid(Set[,] matrix)
		{
			Boolean valid = true;


            // complexity NxN, where N is size of matrix
            //foreach (Set item in matrix)
            //{
            //    // if at least one of item is empty, all matrix is empty
            //    if (item.isDiscreteSetEmpty())
            //    {
            //        valid = false;
            //        break;
            //    }
            //}

            // complexity N, where N is size of matrix
            for (int i = 0, rows = matrix.GetLength(0); i < rows; i++) 
            {
                // if at least one of the items on diagonal is empty, all matrix is empty
                if (matrix[i, i].isDiscreteSetEmpty()) 
                {
                    valid = false;
                }
            }


                return valid;
		}

    }

}
