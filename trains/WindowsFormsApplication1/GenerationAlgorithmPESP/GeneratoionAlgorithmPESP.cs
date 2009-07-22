using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using PeriodicTimetableGeneration.Interfaces;

namespace PeriodicTimetableGeneration
{



    /// <summary>
    /// Class represents sophisticated Generation Algorithm of Periodic Timetables.
    /// Implements appropriate methods for it.
    /// </summary>
    public class GenerationAlgorithmPESP
    {
        #region Private Fields

        /// <summary>
        /// Default value for lower bound used in Bisection Algorithm.
        /// </summary>
        private const int LOWER_BOUND_DEFAULT = 0;

        /// <summary>
        /// Default value for upper bound used in Bisection Algorithm.
        /// </summary>
        private const int UPPER_BOUND_DEFAULT = 120;
        /// <summary>
        /// List of constructed algorithm.
        /// </summary>
        private List<Timetable> timetable;
        /// <summary>
        /// Matrix of constraints.
        /// (not implemented)
        /// </summary>
        private Constraint[,] constraintMatrix;
        /// <summary>
        /// List of distinct train line, which are used in presented constraints only.
        /// </summary>
        private List<TrainLine> trainLinesMap;
        /// <summary>
        /// Constant maximal value used for list
        /// </summary>
        const int MAX_RULETTE_COUNT = 10;

        #endregion

        #region Constructors

        public GenerationAlgorithmPESP()
        {
            setDefaultValues();
        }

        #endregion

        #region Structs

        struct SolutionItem
        {
            public SolutionItem(Set s)
            {
                if (s.Count == 1)
                {
                    Minute = 0;
                    Factor = 0;

                    // Should be the only one element in the set, so remember it.
                    foreach (KeyValuePair<int, int> p in s.MinimizationFactor)
                    {
                        Minute = p.Key;
                        Factor = p.Value;
                    }
                    NotSingleton = false;
                }
                else
                {
                    // Not constrained set - give the negative values for it.
                    Minute = -1;
                    Factor = 0;
                    NotSingleton = true;
                }
            }

            public override string ToString()
            {
                return String.Format("Minute: {0}, Factor: {1}", Minute, Factor);
            }

            public int Minute;
            public int Factor;
            public bool NotSingleton;
        }

        struct Solution
        {
            public Solution(Set[,] s)
            {
                Matrix = new SolutionItem[s.GetLength(0), s.GetLength(1)];
                Factor = 0;
                for (int i = 0, rows = s.GetLength(0); i < rows; ++i)
                {
                    for (int j = 0, cols = s.GetLength(1); j < cols; ++j)
                    {
                        Matrix[i, j] = new SolutionItem(s[i, j]);
                        Factor += Matrix[i, j].Factor;
                    }
                }
            }

            public SolutionItem[,] Matrix;
            public int Factor;
        }

        #endregion

        #region Public Methods


        private bool createFactorRecord(Set set, ref FactorRangeRecord record)
        {
            if (set.MinimizationFactor.Count <= 1)
            {
                return false;
            }

            int maxVal = int.MinValue;
            int minVal = int.MaxValue;
            foreach (int factor in set.MinimizationFactor.Values)
            {
                if (maxVal < factor)
                {
                    maxVal = factor;
                }

                if (minVal > factor)
                {
                    minVal = factor;
                }
            }

            record.Factor = maxVal - minVal;
            return true;
        }


        public void generateTimetable()
        {

            // runInitializationALg(){}

            // 1 case
            //Set[,] s = runPreparationAlgorithm(new UniformPeriodsConstraintsCreator());
            //runSearchAlgorithm(s);
            //// 2 case
            //Set[,] s = runPreparationAlgorithm(GenerationAlgorithmPESPUtil.createConstraintSetWithDifferentPeriods, rulleteDeterministic);
            //runSearchAlgorithm(s);
            //// 3 case
            //Set[,] s = runPreparationAlgorithm();
            //runSearchAlgorithm(s);
            zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
        }





        public void runSearchAlgorithm(Set[,] s)
        {
            List<Solution> solutions = new List<Solution>();
            search(s, solutions);
        }



        private void search(Set[,] s, List<Solution> solutions)
        {
            // Find the set to be shorted.
            List<FactorRangeRecord> bestRecords = searchForTheBestRecords(s);
            bool isSingleton = bestRecords.Count == 1;
            FactorRangeRecord best = rulette(bestRecords);
            Set currentSet = s[best.Row, best.Col];

            // Create the order in which we will try to find a solution, best possibility first.
            List<int> sortedMinutes = new List<int>(currentSet.MinimizationFactor.Keys);
            sortedMinutes.Sort(delegate(int i, int j)
            {
                return currentSet.MinimizationFactor[i] - currentSet.MinimizationFactor[j];
            });

            // Search for the solution.
            foreach (int minute in sortedMinutes)
            {
                // TODO: Use the branch and bound prunning.

                // Copy the matrix.
                Set[,] newMatrix = GenerationAlgorithmPESPUtil.cloneDiscreteSetMatrix(s);

                // Create a singleton set.
                Set newSet = new Set(currentSet.Modulo);
                newSet.Add(minute, currentSet.MinimizationFactor[minute]);

                // Remeber to the new matrix.
                newMatrix[best.Row, best.Col] = newSet;
                newMatrix[best.Col, best.Row] = new Set(newSet);
                newMatrix[best.Col, best.Row].Reverse();

                // Propagate newly created constraints.
                propagate(newMatrix);

                // Check if the solution may be found.
                if (!isValid(s))
                {
                    continue;
                }

                // If the solution is found, remember it, otherwise search for it.
                if (isSingleton)
                {
                    solutions.Add(new Solution(newMatrix));
                }
                else
                {
                    search(newMatrix, solutions);
                }
            }
        }

        private FactorRangeRecord rulette(List<FactorRangeRecord> records)
        {
            // TODO: Make a real rulette.
            return records[0];
        }

        private List<FactorRangeRecord> searchForTheBestRecords(Set[,] s)
        {
            // Create the list of MAX_RULETTE_COUNT best records.
            List<FactorRangeRecord> bestRecords = new List<FactorRangeRecord>();
            int currentWorst = Int32.MaxValue;

            // Search for the best records.
            for (int i = 0, rows = s.GetLength(0); i != rows; ++i)
            {
                for (int j = i + 1, cols = s.GetLength(1); j != cols; ++j)
                {
                    FactorRangeRecord currentRecord = new FactorRangeRecord { Row = i, Col = j };
                    if (!createFactorRecord(s[i, j], ref currentRecord))
                    {
                        continue;
                    }

                    if (currentRecord.Factor < currentWorst)
                    {
                        // Insert - create a space.
                        bestRecords.Add(currentRecord);
                        int k = bestRecords.Count - 1;
                        // Shift them - so that they are sorted.
                        while (k > 0 && bestRecords[k - 1].Factor > currentRecord.Factor)
                        {
                            bestRecords[k] = bestRecords[k - 1];
                            --k;
                        }
                        // Last assignment places the current record at the right position.
                        bestRecords[k] = currentRecord;

                        // If we have too many elements remove them.
                        if (bestRecords.Count > MAX_RULETTE_COUNT)
                        {
                            bestRecords.RemoveAt(MAX_RULETTE_COUNT);
                        }

                        // Remember the current worst possibility.
                        currentWorst = bestRecords[bestRecords.Count - 1].Factor;
                    }
                }
            }

            return bestRecords;
        }

        public Set[,] runPropagationAlgorithm(List<Constraint> originalConstraints, int size)
        {
            // create working copy of constraints

            List<Constraint> constraints = GenerationAlgorithmPESPUtil.cloneConstraints(originalConstraints);

            //------createConstraintSet-potential-set-for-constraints-----------------------

            constraints = GenerationAlgorithmPESPUtil.createConstraintSets(constraints, size);

            //------modification-constraints----------------------------------

            printToFileConstraints(constraints, "originalConstraints");

            // normalize constraints
            constraints = GenerationAlgorithmPESPUtil.normalizeConstraints(constraints);

            printToFileConstraints(constraints, "normalizedConstraints");

            // find equivalent constraints
            List<List<Constraint>> groupOfconstraints = GenerationAlgorithmPESPUtil.findEquivalentConstraints(constraints);
            // try to merge them
            constraints = GenerationAlgorithmPESPUtil.mergeEquivalentConstrains(groupOfconstraints);

            printToFileConstraints(constraints, "mergedConstraints");

            // createConstraintSet a hashtable only of all trainLines used in constraints
            this.trainLinesMap = GenerationAlgorithmPESPUtil.createTrainLineMap(constraints);
            // store constraints - into constraintCache
            ConstraintCache.getInstance().setCacheContent(constraints);
            // create matrix of discrete sets
            Set[,] setMatrix = GenerationAlgorithmPESPUtil.createDiscretSetMatrix(constraints, trainLinesMap);


            // createConstraintSet constraint's matrix
            //this.constraintMatrix = GenerationAlgorithmPESPUtil.createConstraintMatrix(constraints, trainLinesMap);



            //-------propagation-part-of-algorithm--------------------------------------------------------
            propagate(setMatrix);

            return setMatrix;
        }

        public Set[,] runPreparationAlgorithm(IConstraintPropagator propagator)
        {
            //------initialization-constraints-----------------------------------

            // createConstraintSet transfers
            List<Transfer> transfers = GenerationAlgorithmPESPUtil.createTransfers();
            // createConstraintSet constraints
            List<Constraint> constraints = GenerationAlgorithmPESPUtil.createConstraints(transfers);

            return BisectionUtils.Bisect(constraints, propagator, LOWER_BOUND_DEFAULT, UPPER_BOUND_DEFAULT);

            /*

            //-------bisection-algorithm-for-finding-the-proper-bound-for-discret-set------
            // set default lower and upper bounds
            int lowerBound = LOWER_BOUND_DEFAULT;
            int upperBound = UPPER_BOUND_DEFAULT;
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
                setMatrix = runPropagationAlgorithm(constraints, midpoint);

                // if the constraint matrix is stable (previously), and valid
                if (isValid(setMatrix))
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
            while (!isValid(setMatrix))
            {
                setMatrix = runPropagationAlgorithm(constraints, ++midpoint);
            }
            return setMatrix;
             */ 
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Sets the default values for fields.
        /// </summary>
        private void setDefaultValues()
        {
            this.trainLinesMap = new List<TrainLine>();
            this.timetable = new List<Timetable>();
        }




        /// <summary>
        /// Determines whether the specified matrix is stable.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        /// 	<c>true</c> if the specified matrix is stable; otherwise, <c>false</c>.
        /// </returns>
        private Boolean isStable(Set[,] matrix)
        {
            Set zeroSet = new Set(new int[] { 0 }, GenerationAlgorithmPESPUtil.MODULO_DEFAULT);

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
        private Boolean isValid(Set[,] matrix)
        {
            Boolean valid = true;

            foreach (Set item in matrix)
            {
                // if at least one of item is empty, all matrix is empty
                if (item.isDiscreteSetEmpty())
                {
                    valid = false;
                    break;
                }
            }

            return valid;
        }

        private void propagate(Set[,] matrix)
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
                            if (i == j || j == k || i == k) continue;
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

        private void printToFile(Set[,] matrix, String fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            // loop over all rows
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // loop over all columns
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    String str = String.Format("[{0}, {1}]: ", i.ToString().PadLeft(2, ' '), j.ToString().PadLeft(2, ' '));
                    str += matrix[i, j].ToString();
                    sw.WriteLine(str);
                }
            }

            sw.Close();
            fs.Close();
        }

        private void printToFileConstraints(List<Constraint> constraints, String fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("{0} ", constraints.Count);

            foreach (Constraint constraint in constraints)
            {
                sw.Write("{0}->{1}: ", constraint.TrainLineNumber1, constraint.TrainLineNumber2);
                sw.WriteLine(constraint.DiscreteSet.ToString());
            }
            sw.Close();
            fs.Close();
        }

        #endregion

        #region Properties

        public Timetable Timetable
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


        #endregion
    }
}
