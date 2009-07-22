using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{

    /// <summary>
    /// Class represents a Train Stop within a Train Line.
    /// </summary>
    public class TrainStop
    {
        #region Private Fields

        /// <summary>
        /// Train station, which the train stop is connected with.
        /// </summary>
        private TrainStation trainStation;
        /// <summary>
        /// Time of arrival on this train stop.
        /// </summary>
        private Time timeArrival;
        /// <summary>
        /// Time of departure of this train stop.
        /// </summary>
        private Time timeDeparture;
        /// <summary>
        /// Days, when the stop is used (not used)
        /// </summary>
        private int daysInWeek;
        /// <summary>
        /// Distance from first train stop within the train line
        /// </summary>
        private int kmFromStart;
        /// <summary>
        /// Time from first train stop within the train line.
        /// </summary>
        private Time timeFromStart;
        /// <summary>
        /// Number of platform (not used).
        /// </summary>
        private int platform;
        /// <summary>
        /// Number of train line, which this train stop belongs to.
        /// </summary>
        private int trainLine;
        /// <summary>
        /// Order number within the train line.
        /// </summary>
        private int orderInTrainLine;
        /// <summary>
        /// Differential time from previous train stop.
        /// </summary>
        private Time timeFromPreviousStop;
        /// <summary>
        /// Differential distance from previous train stop.
        /// </summary>
        private int kmFromPreviousStop;
        /// <summary>
        /// Time of staying at station.
        /// </summary>
        private Time timeStayingAtStation;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainStop"/> class.
        /// </summary>
        public TrainStop()
        {
            setDefaultValues();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the default values.
        /// </summary>
        private void setDefaultValues() 
        {
            this.trainStation = null;
            this.trainLine = -1;
            this.timeFromStart = Time.EmptyValue;
            this.timeFromPreviousStop = Time.EmptyValue;
            this.timeDeparture = Time.EmptyValue;
            this.timeArrival = Time.EmptyValue;
            this.platform = -1;
            this.orderInTrainLine = -1;
            this.kmFromStart = -1;
            this.kmFromPreviousStop = -1;
            this.daysInWeek = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>The day.</value>
        public int Day
        {
            get
            {
                return daysInWeek;
            }
            set
            {
                daysInWeek = value;
            }
        }

        /// <summary>
        /// Gets or sets the distance from start.
        /// </summary>
        /// <value>The distance from start.</value>
        public int KmFromStart
        {
            get
            {
                return kmFromStart;
            }
            set
            {
                kmFromStart = value;
            }
        }

        /// <summary>
        /// Gets or sets the order number within train line.
        /// </summary>
        /// <value>The order number within train line.</value>
        public int OrderInTrainLine
        {
            get
            {
                return orderInTrainLine;
            }
            set
            {
                orderInTrainLine = value;
            }
        }


        /// <summary>
        /// Gets or sets the platform's number.
        /// </summary>
        /// <value>The platform's number.</value>
        public int Platform
        {
            get
            {
                return platform;
            }
            set
            {
                platform = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of train line.
        /// </summary>
        /// <value>The number of train line.</value>
        public int TrainLine
        {
            get
            {
                return trainLine;
            }
            set
            {
                trainLine = value;
            }
        }

        /// <summary>
        /// Gets or sets the train station.
        /// </summary>
        /// <value>The train station.</value>
        public TrainStation TrainStation
        {
            get
            {
                return trainStation;
            }
            set
            {
                trainStation = value;
            }
        }

        /// <summary>
        /// Gets or sets the distance from previous stop in km.
        /// </summary>
        /// <value>The distance from previous stop.</value>
        public int KmFromPreviousStop
        {
            get
            {
                return kmFromPreviousStop;
            }
            set
            {
                kmFromPreviousStop = value;
            }
        }

        /// <summary>
        /// Gets or sets the time departure.
        /// </summary>
        /// <value>The time departure.</value>
        public Time TimeDeparture
        {
            get
            {
                return timeDeparture;
            }
            set
            {
                timeDeparture = value;
            }
        }

        /// <summary>
        /// Gets the time departure on checked condition.
        /// </summary>
        /// <value>The time departure checked.</value>
        public Time TimeDepartureChecked
        {
            get
            {
                Time time;

                // if departure is not equal 00:00
                if (!timeDeparture.Equals(Time.MinValue))
                {
                    time = timeDeparture;
                }
                else
                {
                    // if stop is a first one, there it is a legal time, use it
                    if (orderInTrainLine.Equals(0))
                        time = timeDeparture;
                    // otherwise (time is 00:00 but the stop is not first)
                    else
                        // it has to be last stop, which has no departure (not continue)
                        time = Time.EmptyValue;
                }

                return time;
            }        
        }


        /// <summary>
        /// Gets or sets the time arrival.
        /// </summary>
        /// <value>The time arrival.</value>
        public Time TimeArrival
        {
            get
            {
                return timeArrival;
            }
            set
            {
                timeArrival = value;
            }
        }

        /// <summary>
        /// Gets the time arrival on checked condition.
        /// </summary>
        /// <value>The time arrival checked.</value>
        public Time TimeArrivalChecked 
        {
            get 
            {
                Time time;

                // if arrival is not equal 00:00
                if (!timeArrival.Equals(Time.MinValue))
                {
                    time = timeArrival;
                }
                else
                {
                    // if stop is the first, there no arrival exists
                    if (orderInTrainLine.Equals(0))
                        time = Time.EmptyValue;
                    // otherwise (time is 00:00 but the stop is not first) use departure
                    else
                        time = timeDeparture;
                }

                return time;
            }
        }

        /// <summary>
        /// Gets or sets the time from previous stop.
        /// </summary>
        /// <value>The time from previous stop.</value>
        public Time TimeFromPreviousStop
        {
            get
            {
                return timeFromPreviousStop;
            }
            set
            {
                timeFromPreviousStop = value;
            }
        }

        /// <summary>
        /// Gets or sets the time from start.
        /// </summary>
        /// <value>The time from start.</value>
        public Time TimeFromStart
        {
            get
            {
                // if timeArrival is not specified, used departure tim
                if (timeArrival.Equals(Time.MinValue))
                    timeFromStart = timeDeparture;
                else
                    // otherwise use time arrival
                    timeFromStart = timeArrival;

                return timeFromStart;
            }
            set
            {
                timeFromStart = value;
            }
        }

        /// <summary>
        /// Gets the time staying at station.
        /// </summary>
        /// <value>The time staying at station.</value>
        public Time TimeStayingAtStation
        {
            get
            {
                // if time arrival is not specified, use minimal time value (00:00),
                // otherwise use difference betweeen time departure and time arrival
                return (timeArrival.Equals(Time.MinValue)) ? Time.MinValue : timeDeparture - timeArrival;
            }
            set
            {
                timeStayingAtStation = value;
            }
        }

        #endregion

    }
}
