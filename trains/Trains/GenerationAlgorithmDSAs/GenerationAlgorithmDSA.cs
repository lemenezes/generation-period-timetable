using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using PeriodicTimetableGeneration.Interfaces;
using PeriodicTimetableGeneration.Interfaces.ConstraintSetsCreators;
using PeriodicTimetableGeneration.Solutions;
using PeriodicTimetableGeneration.Interfaces.ConstraintPropagators;
using PeriodicTimetableGeneration.Interfaces.BestChoiceSearchers;
using PeriodicTimetableGeneration.GenerationAlgorithmDSAs;

namespace PeriodicTimetableGeneration
{

    /// <summary>
    /// Class represents sophisticated Generation Algorithm of Periodic Timetables.
    /// Implements appropriate methods for it.
    /// </summary>
    public class GenerationAlgorithmDSA
    {

        #region Private Fields

        /// <summary>
        /// List of constructed algorithm.
        /// </summary>
        private List<Timetable> timetable;


        #endregion

        #region Constructors

        public GenerationAlgorithmDSA()
        {
            setDefaultValues();
        }

        #endregion



        #region Public Methods

        public void generateTimetable()
        {
            // Initialize the algorithm.
            List<Constraint> constraints;
            runInitializeAlgorithm(out constraints);

            // Propagator variable.
            IConstraintPropagator propagator;
            // propagator result is a structure with SetMatrix and TrainLineMap
            PropagationResult propagationResult;

            //-----Run-Algorithm-Case-1:-Bisection-with-Same-Transfer-Time-&-Deterministic-Searcher------------------------------
            // Run the propagation phase.
            propagator = new BisectionPropagator(new SameTransferTime());
            propagationResult = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmDSAUtil.MODULO_DEFAULT);
            // Search for the result with deterministic searcher.
            runSearchAlgorithm(new DeterministicSearcher(), propagationResult);
/*
            //-----Run-Algorithm-Case-2:-Bisection-with-AlfaT-Transfer-Time-&-Deterministic-Searcher------------------------------
            // Run the propagation phase.
            propagator = new BisectionPropagator(new AlfaTTransferTime());
            propagationResult = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmPESPUtil.MODULO_DEFAULT);
            // Search for the result with deterministic searcher.
            runSearchAlgorithm(new DeterministicSearcher(), propagationResult);

            //-----Run-Algorithm-Case-3:-Simple-with-Full-Discrete-Set-&-Deterministic-Searcher------------------------------
            // Run the propagation phase.
            propagator = new SimplePropagator(new FullDiscreteSet());
            propagationResult = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmPESPUtil.MODULO_DEFAULT);
            // Search for the result with deterministic searcher.
            runSearchAlgorithm(new DeterministicSearcher(), propagationResult);

            //-----Run-Algorithm-Case-4:-Simple-with-Full-Discrete-Set-&-Probable-Searcher------------------------------
            // Run the propagation phase.
            propagator = new SimplePropagator(new FullDiscreteSet());
            propagationResult = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmPESPUtil.MODULO_DEFAULT);
            // Search for the result with deterministic searcher.
            runSearchAlgorithm(new DeterministicSearcher(), propagationResult);

            */

        }

        #endregion



        #region Search Algorithm Methods

        public void runSearchAlgorithm(IBestChoiceSearcher bestChoiceSearcher, PropagationResult result)
        {
            List<Solution> solutions = new List<Solution>();
            search(bestChoiceSearcher, result, solutions);
        }

        /*
		private void search2(IBestChoiceSearcher bestChoiceSearcher, PropagationResult result, List<Solution> solutions)
		{
			Set[,] s = result.matrix;

            // Find the top list of possible choices of Set with maximum minFactor range.
			List<FactorRangeRecord> bestRecords = searchForTheBestRecords(s);
            // If the it is only one possible Set, after shorten will be matrix singleton
			bool isSingleton = bestRecords.Count == 1;

            // Find the set to be shortened.
			FactorRangeRecord best = bestChoiceSearcher.chooseBestRecord(bestRecords);
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
				PropagationUtils.propagate(newMatrix, result.TrainLinesMap);

				// Check if the solution may be found.
				if (!MatrixUtils.isValid(s))
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
					search(new PropagationResult(newMatrix, result.TrainLinesMap), solutions);
				}
			}
		}
        */

        private void search(IBestChoiceSearcher bestChoiceSearcher, PropagationResult propagationResult, List<Solution> solutions)
        {
            // retreive discrete set matrix after propagation from propagation result
            Set[,] discreteSetMatrix = propagationResult.DiscreteSetMatrix;

            // while until you can still find some solution (still can found best record)
            while (true)
            {
                // Propagate newly created constraints.
                PropagationUtil.propagate(discreteSetMatrix, propagationResult.TrainLinesMap);

                // Check if the solution may be found.
                if (!MatrixUtils.isValid(discreteSetMatrix))
                {
                    // No valid matrix - solution can not be found.
                    return;
                }

                // Find the set to be shortened.
                FactorRangeRecord best;

                // if no best record found ()
                if (!bestChoiceSearcher.chooseBestRecord(discreteSetMatrix, out best))
                {
                    // then solution founded, matrix is single (contains singletons only).
                    solutions.Add(new Solution(discreteSetMatrix));

                    // end of recursive calls
                    return;
                }

                // Current set to be shortened
                Set currentSet = best.Set;

                // Item of Set which will be fixed.
                int minute = best.MinItemOfSet;

                // TODO: Use the branch and bound prunning.

                // Copy the matrix.
                Set[,] newMatrix = GenerationAlgorithmDSAUtil.cloneDiscreteSetMatrix(discreteSetMatrix);

                // Create a singleton set.
                Set newSet = new Set(currentSet.Modulo);
                // Add only one item, fixed item.
                newSet.Add(minute, currentSet.MinimizationFactor[minute]);

                // Remeber to the new matrix.
                newMatrix[best.Row, best.Col] = newSet;
                newMatrix[best.Col, best.Row] = new Set(newSet);
                newMatrix[best.Col, best.Row].Reverse();

                // matrix was changed, continue in recursive calls
                search(bestChoiceSearcher, new PropagationResult(newMatrix, propagationResult.TrainLinesMap), solutions);

                // after return from recursive call, remove fixed object and try to
                discreteSetMatrix[best.Row, best.Col].Remove(minute);
                discreteSetMatrix[best.Col, best.Row].RemoveReverse(minute);
            }
        }

        private FactorRangeRecord rulette(List<FactorRangeRecord> records)
        {
            // TODO: Make a real rulette.
            return records[0];
        }



        #endregion


        #region Initialize Algorithm Methods

        /// <summary>
        /// Runs the initialize algorithm which according the transfer constructs appropriate constraints.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        public void runInitializeAlgorithm(out List<Constraint> constraints)
        {
            //------initialization-constraints-----------------------------------

            // createConstraintSet transfers
            List<Transfer> transfers = ConstraintUtil.createTransfers();
            // createConstraintSet constraints
            constraints = ConstraintUtil.createConstraints(transfers);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the default values for fields.
        /// </summary>
        private void setDefaultValues()
        {
            this.timetable = new List<Timetable>();
        }

        #endregion

        public List<Timetable> runConstructionAlgorithm()
        {
            throw new System.NotImplementedException();
        }

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
