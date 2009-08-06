using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using PeriodicTimetableGeneration.Interfaces;
using PeriodicTimetableGeneration.Properties;
using PeriodicTimetableGeneration.GenerationAlgorithm;
using System.Diagnostics;
using System.Linq;

namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Generation Algorithm, which construct randomize timetable first and then trying to imprve it.
    /// </summary>
    public class GenerationAlgorithmRandomized : IGenerationAlgorithm
    {
        #region Private Fields

        /// <summary>
        /// Timetables.
        /// </summary>
        private List<Timetable> timetables;
        /// <summary>
        /// All train lines.
        /// </summary>
        private List<TrainLine> trainLines;
        /// <summary>
        /// All train station.
        /// </summary>
        private List<TrainStation> trainStations;

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerationAlgorithmRandomized"/> class.
        /// </summary>
        public GenerationAlgorithmRandomized()
        {
            setDefaultValues();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the train stations.
        /// </summary>
        /// <value>The train stations.</value>
        public List<TrainStation> TrainStations
        {
            get
            {
                return trainStations;
            }
            set
            {
                trainStations = value;
            }
        }

        /// <summary>
        /// Gets or sets the train lines.
        /// </summary>
        /// <value>The train lines.</value>
        public List<TrainLine> TrainLines
        {
            get
            {
                return trainLines;
            }
            set
            {
                trainLines = value;
            }
        }

        /// <summary>
        /// Gets the timetables.
        /// </summary>
        /// <value>The timetables.</value>
        public List<Timetable> Timetables
        {
            get
            {
                return timetables;
            }
            set
            {
                timetables = value;
            }
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


        #region IGenerationAlgorithm Members

        /// <summary>
        /// Generates the timetables.
        /// </summary>
        /// <param name="numberOfTimetables">The number of timetables.</param>
        public void generateTimetables(int numberOfTimetables)
        {
            // clear previous timetables
            timetables.Clear();

            for (int i = 1; i <= numberOfTimetables; i++)
            {
                if (IsCancelled)
                {
                    return;
                }

                // start time
                Stopwatch watch = new Stopwatch();
                watch.Start();

                Timetable tt = generateTimetable();

                // stop measuring time
                watch.Stop();
                tt.GenerationTime = watch.Elapsed;

                Console.Out.WriteLine("{0} -> {1}", tt.RatingValue, Timetable.calculateTimetableRatingValue(tt));

                // add timetable
                timetables.Add(tt);
  
                int percentageComplete = (int)((float)i / (float)numberOfTimetables * 100);
                reportProgress(percentageComplete);
            }
        }

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
        /// Occurs when [on progress changed].
        /// </summary>
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;

        /// <summary>
        /// Finds the timetable on select id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Timetable findTimetableOnSelect(int id)
        {
            return TimetableUtil.findTimetableOnSelect(this.timetables, id);
        }

        /// <summary>
        /// Determine whether the timetable exists.
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
        /// Creates the timetable.
        /// </summary>
        /// <returns></returns>
        public Timetable createTimetable()
        {
            return new Timetable(timetables.Count + 1, trainLines);
        }

        /// <summary>
        /// Generates the randomized timetable.
        /// </summary>
        /// <returns></returns>
        public Timetable generateRandomizedTimetable()
        {
            Timetable tt = createTimetable();
            tt.randomizeTimetable();
            return tt;
        }

        /// <summary>
        /// Randomizes the timetable.
        /// </summary>
        /// <param name="timetable">The timetable.</param>
        /// <returns></returns>
        public static Timetable randomizeTimetable(Timetable timetable)
        {
            timetable.randomizeTimetable();
            return timetable;
        }

        /// <summary>
        /// Generates the timetable.
        /// </summary>
        /// <returns></returns>
        public Timetable generateTimetable()
        {
            // generate randomizedTimetable
            Timetable timetable = generateRandomizedTimetable();
            // createConstraintSet temporary holder for AvailableLines during calculation
            List<TrainLineVariable> availableLines = cloneVariableLines(timetable.getVariableLines());
            // createConstraintSet temporary holder for AvailableLines during calculation
            List<TrainLineVariable> stableLines = new List<TrainLineVariable>();

            // random class for randomizing choice of trainlines
            Random random = new Random();

            // local variables
            //int theBestTimetableRatingValue = int.MaxValue;
            //int progressiveChanges = 0;

            // Find the best new state.
            CurrentState state = new CurrentState(new List<Change>(), int.MaxValue);

            // loop until if availableLines are not empty AND stableLine are not complete
            while (!availableLines.Count.Equals(0) &&
                !stableLines.Count.Equals(timetable.TrainLines.Count))
            {
                Boolean improved = false;

                // choose available line randomly
                TrainLineVariable selectedLine = availableLines[random.Next(0, availableLines.Count - 1)];

                // loop over whole interval of line
                for (int i = 0; i < (int)selectedLine.Period; i++)
                {
                    // calculate transfers
                    CurrentState newState = calculateTransfers(timetable, selectedLine, Time.ToTime(i));
                    if (newState.Factor > state.Factor) {
                        // If the current one is better forget the computed one.
                        newState.Revert();
                    } else if (newState.Factor != state.Factor) {
                        // The computed one should be preserved.
                        state = newState;
                        improved = true;
                    }
                }

                // If the state was improved.
                if (improved)
                {
                    selectedLine.ProgressiveChanges += 1;
                    // clear stableLines queue
                    stableLines.Clear();
                    // reset availableLines
                    availableLines = cloneVariableLines(timetable.getVariableLines());
                }

                // add selected line into list of stableLines
                stableLines.Add(selectedLine);
                // add also all connected lines with selected line
                stableLines.AddRange(selectedLine.ConnectedLinesVariable);
                // remove line off availableLines
                availableLines.Remove(selectedLine);
                // remove all connected lines with selected line
                foreach (TrainLineVariable connectedVar in selectedLine.ConnectedLinesVariable)
                {
                    availableLines.Remove(connectedVar);
                }
            }

            timetable.RatingValue = state.Factor;
            //int ratingValue = Timetable.calculateTimetableRatingValue(timetable);
            timetable.calculateProgressiveChanges();
            
            //LogUtil.printTimetableTransfersEvaluation(timetable, FinalInput.getInstance().getCacheContent());

            return timetable;
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Sets the default values.
        /// </summary>
        private void setDefaultValues()
        {
            timetables = new List<Timetable>();
            trainLines = TrainLineCache.getInstance().getCacheContent();
            trainStations = TrainStationCache.getInstance().getCacheContent();
        }

        /// <summary>
        /// Clones the variable lines.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <returns></returns>
        private List<TrainLineVariable> cloneVariableLines(List<TrainLineVariable> lines)
        {
            List<TrainLineVariable> cloneLines = new List<TrainLineVariable>();

            foreach (TrainLineVariable line in lines)
            {
                cloneLines.Add(line);
            }

            return cloneLines;
        }

        /// <summary>
        /// Calculates the transfers.
        /// </summary>
        /// <param name="timetable">The timetable.</param>
        /// <param name="line">The line.</param>
        /// <param name="startTime">The start time.</param>
        /// <returns></returns>
        private CurrentState calculateTransfers(Timetable timetable, TrainLineVariable line, Time startTime)
        {
            // Changes, in case we need to revert the state (it is worse than the current one).
            List<Change> changes = new List<Change>();

            //////SET SELECED LINES
            // Set the start time for the given line.
            changes.Add(new Change(line, line.StartTime));
            line.StartTime = startTime;

            ///SET ALL CONNECTED LINES
            // Set the appropriate start time for each connected variable.
            foreach (TrainLineVariable connectedVariable in line.ConnectedLinesVariable)
            {
                // Set the start for variable.
                changes.Add(new Change(line, line.StartTime));                
                connectedVariable.StartTime = startTime - connectedVariable.Line.ConnectedLineShift;
                connectedVariable.StartTime = PeriodUtil.normalizeTime(connectedVariable.StartTime, connectedVariable.Period);
            }

            // Compute the factor.
            int factor = Timetable.calculateTimetableRatingValue(timetable);           

            // Current state returned.
            return new CurrentState(changes, factor);
        }

        

        private struct CurrentState
        {

            private int factor;

            private List<Change> changes;

            public CurrentState(List<Change> changes, int factor)
                : this()
            {

                this.changes = changes;
                this.factor = factor;
            }

            public int Factor
            {
                get
                {
                    return this.factor;
                }
            }

            public List<Change> Changes
            {
                get
                {
                    return changes;
                }
            }

            public void Revert()
            {
                foreach (Change change in changes)
                {
                    change.Revert();
                }
            }

        }

        private struct Change
        {
            private TrainLineVariable changedVariable;

            private Time oldStartTime;

            public Change(TrainLineVariable variable, Time oldTime)
                : this()
            {
                this.changedVariable = variable;
                this.oldStartTime = oldTime;
            }

            public TrainLineVariable ChangedVariable
            {
                get
                {
                    return changedVariable;
                }
            }

            public Time OldStartTime
            {
                get
                {
                    return oldStartTime;
                }
            }

            public void Revert()
            {
                changedVariable.StartTime = OldStartTime;
            }

        

       

            // if the time for tranfer is more than than minimal
            //if (timeDeparture - timeArrival > minimalTransferTime)
            //{
            //    // calculate rating value according passengers on transfers
            //    ratingValue = transfers.evaluateTransferFunction(timeDeparture - timeArrival);
            //}
            //// otherwise
            //else 
            //{
            //    // wait for next train of that line, in next period
            //    ratingValue = transfers.evaluateTransferFunction(timeDeparture - timeArrival + Time.ToTime( (int) transfers.OnLine.Period));
            //}

            //Console.Out.WriteLine("----------------------------------------------------------");
            //Console.Out.WriteLine("Transfer: " + transfers.OffLine.LineNumber + "->" + transfers.OnLine.LineNumber);
            //Console.Out.WriteLine("Passengers: " + transfers.Passengers + " > TransferTime: " + (timeDeparture - timeArrival).ToString());
        }

        #endregion




    }
}
