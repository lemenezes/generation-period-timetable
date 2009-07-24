using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using PeriodicTimetableGeneration.Interfaces;
using PeriodicTimetableGeneration.Properties;
using PeriodicTimetableGeneration.GenerationAlgorithm;

namespace PeriodicTimetableGeneration
{
    public class GenerationAlgorithmRandomized : IGenerationAlgorithm
    {
        #region Private Fields

        private List<Timetable> timetables;
        private List<TrainLine> trainLines;
        private List<TrainStation> trainStations;

        #endregion


        #region Constructor

        public GenerationAlgorithmRandomized()
        {
            setDefaultValues();
        }

        #endregion

        #region Properties

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

        public bool IsCancelled
        {
            get;
            set;
        }

        public Time MinimalTransferTime 
        {
            get 
            {
                return Time.ToTime(Settings.Default.MinimalTransferTime);
            }
        }

        #endregion


        #region IGenerationAlgorithm Members

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

                Timetable tt = generateTimetable();
                timetables.Add(tt);

                int percentageComplete = (int)((float)i / (float)numberOfTimetables * 100);
                reportProgress(percentageComplete);
            }
        }

        protected void reportProgress(int percentageComplete)
        {
            if (this.OnProgressChanged != null)
            {
                this.OnProgressChanged(this, new ProgressChangedEventArgs(percentageComplete, this));
            }
        }

        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;

        public Timetable findTimetableOnSelect(int id)
        {
            return TimetableUtil.findTimetableOnSelect(this.timetables, id);
        }

        public Boolean doesTimetableExist(int id)
        {
            return TimetableUtil.doesTimetableExist(this.timetables, id);
        }

        #endregion


        #region Public Methods

        public Timetable createTimetable()
        {
            return new Timetable(timetables.Count + 1, trainLines);
        }

        public Timetable generateRandomizedTimetable()
        {
            Timetable tt = createTimetable();
            tt.randomizeTimetable();
            return tt;
        }

        public static Timetable randomizeTimetable(Timetable timetable)
        {
            timetable.randomizeTimetable();
            return timetable;
        }          

        public Timetable generateTimetable()
        {
            // generate randomizedTimetable
            Timetable timetable = generateRandomizedTimetable();
            // createConstraintSet temporary holder for AvailableLines during calculation
            List<TrainLineVariable> availableLines = cloneVariableLines(timetable.getVariableLines());
            // createConstraintSet temporary holder for AvailableLines during calculation
            Queue<TrainLineVariable> stableLines = new Queue<TrainLineVariable>();

            // random class for randomizing choice of trainlines
            Random random = new Random();

            // local variables
            //int theBestTimetableRatingValue = int.MaxValue;
            //int progressiveChanges = 0;

            // loop until if availableLines are not empty AND stableLine are not complete
            while (!availableLines.Count.Equals(0) &&
                !stableLines.Count.Equals(timetable.TrainLines.Count))
            {
                // saving the theBestTimetableRatingValue

                // choose available line randomly
                TrainLineVariable selectedLine = availableLines[random.Next(0, availableLines.Count - 1)];

                // startTime with appropriate best rating value of transfers calculation
                Time theBestLineStartTime = Time.MinValue;
                int theBestLineRatingValue = int.MaxValue;

                // loop over whole interval of line
                for (int i = 0; i < (int)selectedLine.Period; i++)
                {
                    // calculate transfers
                    int currentRatingValue = calculateTransfers(timetable, selectedLine, Time.ToTime(i));

                    // choose the best settings of interval
                    // if the last best line's rating value is worse than current
                    if (theBestLineRatingValue > currentRatingValue)
                    {
                        // update the best line's details
                        theBestLineRatingValue = currentRatingValue;
                        theBestLineStartTime = Time.ToTime(i);
                    }
                }

                // compare the theBestTimetableRatingValue with new line ratingValue
                // if the previousRatingValue is worse than current, then change it
                if (selectedLine.RatingValue > theBestLineRatingValue)
                {
                    // update line's details
                    selectedLine.RatingValue = theBestLineRatingValue;
                    selectedLine.StartTime = theBestLineStartTime;
                    selectedLine.ProgressiveChanges += 1;
                    // clear stableLines queue
                    stableLines.Clear();
                    // reset availableLines
                    availableLines = cloneVariableLines(timetable.getVariableLines());
                }

                // addConstraint line into queue of stableLines
                stableLines.Enqueue(selectedLine);
                // remove line off availableLines
                availableLines.Remove(selectedLine);
            }

            // update statistic's values of timetable
            timetable.calculateRatingValue();
            timetable.calculateProgressiveChanges();

            Console.WriteLine("------------------------");
            Console.WriteLine("Timetable: " + timetable.ID);
            foreach (TrainLineVariable line in timetable.getVariableLines())
            {
                Console.WriteLine(line.LineNumber + "> Progress: " + line.ProgressiveChanges + "> Rating: " + line.RatingValue);
            }


            return timetable;
        }

        #endregion



        #region Private Methods

        private void setDefaultValues()
        {
            timetables = new List<Timetable>();
            trainLines = TrainLineCache.getInstance().getCacheContent();
            trainStations = TrainStationCache.getInstance().getCacheContent();
        }

        private List<TrainLineVariable> cloneVariableLines(List<TrainLineVariable> lines)
        {
            List<TrainLineVariable> cloneLines = new List<TrainLineVariable>();

            foreach (TrainLineVariable line in lines)
            {
                cloneLines.Add(line);
            }

            return cloneLines;
        }

        private int calculateTransfers(Timetable timetable, TrainLineVariable line, Time startTime)
        {
            // define all possibleTransfers
            List<Transfer> transfers = TransferUtil.createTransfers(line.LineNumber);

            // set global globalRatingValue
            int globalRatingValue = 0;

            // loop over all posibleTransfers
            foreach (Transfer transfer in transfers)
            {
                // calculate difference gap between       // increment globalRatingValue
                globalRatingValue += calculateTransfer(timetable, transfer, line, startTime);
            }

            // return global ratingValue
            return globalRatingValue;
        }

        private int calculateTransfer(Timetable timetable, Transfer transfer, TrainLineVariable line, Time startTime)
        {
            // minimal transfers time set
            Time minimalTransferTime = MinimalTransferTime;
            // result rating value
            int ratingValue;
            // saveTime
            Time savedTime = line.StartTime;
            // prepare new for calcualtion
            line.StartTime = startTime;

            // gain transer train line variables
            TrainLineVariable lineOff = timetable.getVariableLineOnSelect(transfer.Off);
            TrainLineVariable lineOn = timetable.getVariableLineOnSelect(transfer.On);

            // determine arrival of LineOFF and departure of LineON
            Time timeArrival = lineOff.arrivalOnStation(transfer.Station) + lineOff.StartTime;
            Time timeDeparture = lineOn.departureFromStation(transfer.Station) + lineOn.StartTime;

            // if departure is before arrival, we need to find closest time departure
            // that satisfied the condition(departure>arrival)
            if (timeDeparture < timeArrival + minimalTransferTime)
            {
                while (timeDeparture < timeArrival + minimalTransferTime)
                {
                    // addConstraint new period of train
                    timeDeparture += Time.ToTime((int)lineOn.Period);
                }
            }
            else
            {
                // if arrival is before departure, we need to find closest time arrival
                // that satisfied the cond(departure>arrival) but not the cond(departure>arrival+nextPeriod)
                while (timeDeparture > timeArrival + Time.ToTime((int)lineOff.Period) + minimalTransferTime)
                {
                    timeArrival += Time.ToTime((int)lineOff.Period);
                }
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

            ratingValue = transfer.evaluateTransferFunction(timeDeparture - timeArrival);




            // restore saved time
            line.StartTime = savedTime;

            return ratingValue;
        }


        #endregion




    }
}
