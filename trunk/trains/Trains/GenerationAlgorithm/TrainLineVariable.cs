using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public class TrainLineVariable
    {
        private TrainLine trainLine;
        private Time startTime;
        /// <summary>
        /// value of minimalization factor
        /// </summary>
        private int ratingValue;
        private int progressiveChanges;
        private Boolean fixedFlag;

        /// <summary>
        /// constructor
        /// </summary>
        public TrainLineVariable()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// constructor
        /// </summary>
        public TrainLineVariable(TrainLine line)
        {
            setDefaultValue();
            trainLine = line;
        }

        public Time StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        public TrainLine Line
        {
            get
            {
                return trainLine;
            }
            set
            {
                //trainLine1 = value;
            }
        }

        public int LineNumber
        {
            get
            {
                return trainLine.LineNumber;
            }
            set
            {
            }
        }

        public int RatingValue
        {
            get
            {
                return ratingValue;
            }
            set
            {
                ratingValue = value;
            }
        }

        public int ProgressiveChanges
        {
            get
            {
                return progressiveChanges;
            }
            set
            {
                progressiveChanges = value;
            }
        }

        public Boolean FixedFlag
        {
            get
            {
                return fixedFlag;
            }
            set
            {
                fixedFlag = value;
            }
        }

        public Period Period
        {
            get
            {
                return trainLine.Period;
            }
            set
            {
            }
        }

        public TypeOfTrain TypeOfTrain
        {
            get
            {
                return trainLine.TypeTrain;
            }
            set
            {
            }
        }


        public Time arrivalOnStation(TrainStation station)
        {
            TrainStop stop =  trainLine.getTrainStopOnStation(station.Name);
            Time time;

            // if arrival is not equal 00:00
            if (!stop.TimeArrival.Equals(Time.MinValue))
            {
                time = stop.TimeArrival;                
            }
            else
            {
                // if stop is the first, there no arrival exists
                if (stop.OrderInTrainLine.Equals(0))
                    time = Time.EmptyValue;
                // otherwise (time is 00:00 but the stop is not first) use departure
                else
                    time = stop.TimeDeparture;
            }

            return time;
        }

        public Time departureFromStation(TrainStation station) 
        {
            TrainStop stop = trainLine.getTrainStopOnStation(station.Name);
            Time time;

            // if departure is not equal 00:00
            if (!stop.TimeDeparture.Equals(Time.MinValue))
            {
                time = stop.TimeDeparture;
            }
            else
            {
                // if stop is a first one, there it is a legal time, use it
                if (stop.OrderInTrainLine.Equals(0))
                    time = stop.TimeDeparture;
                // otherwise (time is 00:00 but the stop is not first)
                else
                    // it has to be last stop, which has no departure (not continue)
                    time = Time.EmptyValue;
            }

            return time;
        }

        /// <summary>
        /// set default value
        /// </summary>
        private void setDefaultValue()
        {
            trainLine = null;
            startTime = Time.MinValue;
            ratingValue = int.MaxValue;
            progressiveChanges = 0;
            fixedFlag = false;
        }

        public Boolean isFixed()
        {
            return fixedFlag;
        }
    }
}
