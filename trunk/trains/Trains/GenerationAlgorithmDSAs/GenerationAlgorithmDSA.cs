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
using System.ComponentModel;
using PeriodicTimetableGeneration.GenerationAlgorithm;
using System.Diagnostics;

namespace PeriodicTimetableGeneration
{

    /// <summary>
    /// Class represents sophisticated Generation Algorithm of Periodic Timetables.
    /// Implements appropriate methods for it.
    /// </summary>
    public class GenerationAlgorithmDSA : IGenerationAlgorithm
    {

        #region Private Fields

        /// <summary>
        /// List of constructed algorithm.
        /// </summary>
        private List<Timetable> timetables;


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerationAlgorithmDSA"/> class.
        /// </summary>
        public GenerationAlgorithmDSA()
        {
            setDefaultValues();
        }

        #endregion


        #region IGenerationAlgorithm Members

        /// <summary>
        /// Generates the timetables.
        /// </summary>
        public void generateTimetables(int numberOftimetables)
        {
            // Initialize the algorithm.
            List<Constraint> constraints;
            runInitializeAlgorithm(out constraints);


            List<Timetable> newTimetables = new List<Timetable>();


            runSpecializedGenerationAlgorithm(constraints,
                new BisectionPropagator(new SameTransferTime()),
                new DeterministicSearcher(), newTimetables);


            runSpecializedGenerationAlgorithm(constraints,
                new BisectionPropagator(new AlfaTTransferTime()),
                new DeterministicSearcher(), newTimetables);


            runSpecializedGenerationAlgorithm(constraints,
                new SimplePropagator(new FullDiscreteSet()),
                new DeterministicSearcher(), newTimetables);


            runSpecializedGenerationAlgorithm(constraints,
                new SimplePropagator(new FullDiscreteSet()),
                new ProbableSearcher(), newTimetables);


            this.timetables = newTimetables;



            ////-----Run-Algorithm-Case-1:-Bisection-with-Same-Transfer-Time-&-Deterministic-Searcher------------------------------
            //// Run the propagation phase.
            //propagator = new BisectionPropagator(new SameTransferTime());
            //propagationResult = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmDSAUtil.MODULO_DEFAULT);
            //// Search for the result with deterministic searcher.
            //runSearchAlgorithm(new DeterministicSearcher(), propagationResult);

            ////-----Run-Algorithm-Case-2:-Bisection-with-AlfaT-Transfer-Time-&-Deterministic-Searcher------------------------------
            //// Run the propagation phase.
            //propagator = new BisectionPropagator(new AlfaTTransferTime());
            //propagationResult = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmPESPUtil.MODULO_DEFAULT);
            //// Search for the result with deterministic searcher.
            //runSearchAlgorithm(new DeterministicSearcher(), propagationResult);

            ////-----Run-Algorithm-Case-3:-Simple-with-Full-Discrete-Set-&-Deterministic-Searcher------------------------------
            //// Run the propagation phase.
            //propagator = new SimplePropagator(new FullDiscreteSet());
            //propagationResult = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmPESPUtil.MODULO_DEFAULT);
            //// Search for the result with deterministic searcher.
            //runSearchAlgorithm(new DeterministicSearcher(), propagationResult);

            ////-----Run-Algorithm-Case-4:-Simple-with-Full-Discrete-Set-&-Probable-Searcher------------------------------
            //// Run the propagation phase.
            //propagator = new SimplePropagator(new FullDiscreteSet());
            //propagationResult = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmPESPUtil.MODULO_DEFAULT);
            //// Search for the result with deterministic searcher.
            //runSearchAlgorithm(new DeterministicSearcher(), propagationResult);


        }

        /// <summary>
        /// Occurs when [on progress changed].
        /// </summary>
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;

        /// <summary>
        /// Reports the progress.
        /// </summary>
        /// <param name="percentageComplete">The percentage complete.</param>
        protected void reportProgress(int percentageComplete)
        {
            if (this.OnProgressChanged != null)
            {
                this.OnProgressChanged(this, new ProgressChangedEventArgs(percentageComplete, this));
            }
        }

        /// <summary>
        /// Finds the timetable on select.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Timetable findTimetableOnSelect(int id)
        {
            return TimetableUtil.findTimetableOnSelect(this.timetables, id);
        }

        /// <summary>
        /// Doeses the timetable exist.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Boolean doesTimetableExist(int id)
        {
            return TimetableUtil.doesTimetableExist(this.timetables, id);
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Runs the specialized generation algorithm.
        /// Propagetes constraints, searches for solutions and constructs timetables.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <param name="constraintPropagator">The constraint propagator.</param>
        /// <param name="bestChoiceSearcher">The best choice searcher.</param>
        /// <returns>The timetables.</returns>
        public void runSpecializedGenerationAlgorithm(List<Constraint> constraints, IConstraintPropagator constraintPropagator,
            IBestChoiceSearcher bestChoiceSearcher, List<Timetable> timetables) 
        {          

            // start time
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Propagate constraints with specific constraintPropagator
            PropagationResult propagationResult = constraintPropagator.runPropagationAlgorithm(constraints, GenerationAlgorithmDSAUtil.MODULO_DEFAULT);
            // Search for the solution with specific bestChoiceSearcher
            List<Solution> solutions = runSearchAlgorithm(bestChoiceSearcher, propagationResult);

            // finish time
            watch.Stop();

   
            TimeSpan runningTime = watch.Elapsed;

            // crete note for generated solutions
            String note = constraintPropagator.getDescription() + ", " + bestChoiceSearcher.getDescription();

            // Construct timetables from solutions generated above.
            runConstructionTimetableAlgorithm(solutions, propagationResult.TrainLinesMap, timetables, note, runningTime);
        }

        /// <summary>
        /// Runs the construction timetable algorithm.
        /// Constructs timetables from solution.
        /// </summary>
        /// <param name="solutions">The solutions.</param>
        /// <param name="trainLineMap">The train line map.</param>
        /// <param name="timetables">The timetables.</param>
        /// <param name="note">The note.</param>
        public void runConstructionTimetableAlgorithm(List<Solution> solutions, List<TrainLine> trainLineMap, List<Timetable> timetables, String note, TimeSpan runningTime)
        {
            GenerationAlgorithmDSAUtil.constructTimetables(solutions, trainLineMap, timetables, note, runningTime);
        }

        #endregion



        #region Search Algorithm Methods

        /// <summary>
        /// Runs the search algorithm.
        /// Call method Search, which search for solutions.
        /// </summary>
        /// <param name="bestChoiceSearcher">The best choice searcher.</param>
        /// <param name="propagationResult">The propagation result.</param>
        /// <returns>The solutions.</returns>
        public List<Solution> runSearchAlgorithm(IBestChoiceSearcher bestChoiceSearcher, PropagationResult propagationResult)
        {
            List<Solution> solutions = new List<Solution>();
            search(bestChoiceSearcher, propagationResult, solutions);

            return solutions;
        }

        // old search method
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

        /// <summary>
        /// Searches for solution.
        /// It is called recursively, backtracking all possiblities with respect to specific choice searcher.
        /// </summary>
        /// <param name="bestChoiceSearcher">The best choice searcher.</param>
        /// <param name="propagationResult">The propagation result.</param>
        /// <param name="solutions">The solutions.</param>
        /// <returns>True if solution found, terminate recursive calls. Otherwise continue in backtracking.</returns>
        private Boolean search(IBestChoiceSearcher bestChoiceSearcher, PropagationResult propagationResult, List<Solution> solutions)
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
                    return false;
                }

                // Find the set to be shortened.
                FactorRangeRecord bestRecord;

                // if no best record found ()
                if (!bestChoiceSearcher.chooseBestRecord(discreteSetMatrix, out bestRecord))
                {
                    // then solution found, matrix is single (contains singletons only).
                    solutions.Add(new Solution(discreteSetMatrix));

                    // End of recursive calls
                    return true;
                }

                // fix one potential set with item founded as best
                Set[,] newMatrix = fixOnePotentialOfSetInMatrix(discreteSetMatrix, bestRecord);

                // matrix was changed, continue in recursive calls
                Boolean solutionFound = search(bestChoiceSearcher, new PropagationResult(newMatrix, propagationResult.TrainLinesMap), solutions);

                // Test if solution was found
                if (solutionFound)
                {
                    return true;    
                }

                // after return from recursive call, remove fixed object and try to
                discreteSetMatrix[bestRecord.Row, bestRecord.Col].Remove(bestRecord.MinItemOfSet);
                discreteSetMatrix[bestRecord.Col, bestRecord.Row].RemoveReverse(bestRecord.MinItemOfSet);
            }
        }

        #endregion


        /// <summary>
        /// Fixes the one potential of set in matrix according the founded best record.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="bestRecord">The best record.</param>
        /// <returns>The changed matrix.</returns>
        private Set[,] fixOnePotentialOfSetInMatrix(Set[,] matrix, FactorRangeRecord bestRecord) 
        {
            // copy the matrix
            Set[,] newMatrix = GenerationAlgorithmDSAUtil.cloneDiscreteSetMatrix(matrix);

            // create a singleton set. Fix minute which corresponds with minimal factor value
            Set newSet = new Set(bestRecord.Set.Modulo);
            // add only one item with facotr, fixed item
            newSet.Add(bestRecord.MinItemOfSet, bestRecord.Set.MinimizationFactor[bestRecord.MinItemOfSet]);

            // replace changed Set also in matrix
            newMatrix[bestRecord.Row, bestRecord.Col] = newSet;
            newMatrix[bestRecord.Col, bestRecord.Row] = new Set(newSet);
            newMatrix[bestRecord.Col, bestRecord.Row].Reverse();

            return newMatrix;

            //// Current set to be shortened
            //Set currentSet = best.Set;

            //// Item of Set which will be fixed.
            //int minute = best.MinItemOfSet;

            //// TODO: Use the branch and bound prunning.

            //// Copy the matrix.
            //Set[,] newMatrix = GenerationAlgorithmDSAUtil.cloneDiscreteSetMatrix(discreteSetMatrix);

            //// Create a singleton set. Fix minute which corresponds with minimal factor value.
            //Set newSet = new Set(currentSet.Modulo);
            //// Add only one item, fixed item.
            //newSet.Add(minute, currentSet.MinimizationFactor[minute]);

            //// Remeber to the new matrix.
            //newMatrix[best.Row, best.Col] = newSet;
            //newMatrix[best.Col, best.Row] = new Set(newSet);
            //newMatrix[best.Col, best.Row].Reverse();
        }


        #region Initialize Algorithm Methods

        /// <summary>
        /// Runs the initialize algorithm, which according the transfer constructs appropriate constraints.
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
            this.Timetables = new List<Timetable>();
            this.TrainLines = TrainLineCache.getInstance().getCacheContent();
            this.TrainStations = TrainStationCache.getInstance().getCacheContent();
        }

        #endregion

 

        #region Properties

        /// <summary>
        /// Gets or sets the timetable.
        /// </summary>
        /// <value>The timetable.</value>
        public List<Timetable> Timetables
        {
            get
            {
                return timetables;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the train lines.
        /// </summary>
        /// <value>The train lines.</value>
        public List<TrainLine> TrainLines
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the train stations.
        /// </summary>
        /// <value>The train stations.</value>
        public List<TrainStation> TrainStations
        {
            get;            
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this generation is cancelled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this generation is cancelled; otherwise, <c>false</c>.
        /// </value>
        public bool IsCancelled
        {
            get;
            set;
        }

        #endregion

 
    }
}
