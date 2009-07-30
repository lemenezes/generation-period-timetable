﻿using System;
using System.Collections.Generic;
using System.Text;


namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Class represents a train line with specified start time in particular timetable.
    /// </summary>
    public class TrainLineVariable
    {

        #region Prvate Fields

        /// <summary>
        /// Train line, which this trainLineVariable is related to.
        /// </summary>
        private TrainLine trainLine;
        /// <summary>
        /// Start time of train line in particular timetable, which holds this instance.
        /// </summary>
        private Time startTime;
        /// <summary>
        /// Value of minimalization factor of this line.
        /// </summary>
        private int ratingValue;
        /// <summary>
        /// The number represents number of progressive changes, which has been made.
        /// </summary>
        private int progressiveChanges;

        ///// <summary>
        ///// Flag indicates fixation (not implemented).
        ///// </summary>
        //private Boolean fixedFlag;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TrainLineVariable"/> class.
        /// </summary>
        private TrainLineVariable()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainLineVariable"/> class.
        /// </summary>
        /// <param name="line">The line.</param>
        public TrainLineVariable(TrainLine line)
        {
            setDefaultValue();
            trainLine = line;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
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

        /// <summary>
        /// Gets the line.
        /// </summary>
        /// <value>The train line.</value>
        public TrainLine Line
        {
            get
            {
                return trainLine;
            }
        }

        /// <summary>
        /// Gets the line number.
        /// </summary>
        /// <value>The line number.</value>
        public int LineNumber
        {
            get
            {
                return trainLine.LineNumber;
            }
        }

        /// <summary>
        /// Gets or sets the rating value.
        /// </summary>
        /// <value>The rating value.</value>
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

        /// <summary>
        /// Gets or sets the progressive changes.
        /// </summary>
        /// <value>The progressive changes.</value>
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

        //public Boolean FixedFlag
        //{
        //    get
        //    {
        //        return fixedFlag;
        //    }
        //    set
        //    {
        //        fixedFlag = value;
        //    }
        //}

        /// <summary>
        /// Gets the period of this line.
        /// </summary>
        /// <value>The period.</value>
        public Period Period
        {
            get
            {
                return trainLine.Period;
            }
        }

        /// <summary>
        /// Gets the type of train of this line.
        /// </summary>
        /// <value>The type of train.</value>
        public TypeOfTrain TypeOfTrain
        {
            get
            {
                return trainLine.TypeTrain;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns arrival on specified station within this line.
        /// </summary>
        /// <param name="station">The station.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns departures from specified station with in this line.
        /// </summary>
        /// <param name="station">The station.</param>
        /// <returns>The arrival time.</returns>
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

        //public Boolean isFixed()
        //{
        //    return fixedFlag;
        //}

        #endregion


        #region Private Methods


        /// <summary>
        /// Sets the default value for fields of this instance.
        /// </summary>
        private void setDefaultValue()
        {
            trainLine = null;
            startTime = Time.MinValue;
            ratingValue = int.MaxValue;
            progressiveChanges = 0;
            //fixedFlag = false;
        }

        #endregion



    }
}