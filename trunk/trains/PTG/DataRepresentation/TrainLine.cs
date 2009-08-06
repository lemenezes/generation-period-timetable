using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Class represents Train Line.
    /// </summary>
    public class TrainLine
    {
        #region Private Fields               
        
        /// <summary>
        /// The number of train line.
        /// </summary>
        private int trainLineNumber;
        /// <summary>
        /// The list of train stops of the line.
        /// </summary>
        private List<TrainStop> trainStops;
        /// <summary>
        /// The type of train.
        /// </summary>
        private TypeOfTrain typeOfTrain;
        /// <summary>
        /// The direction of the train line.
        /// (not implemented)
        /// </summary>
        private Direction direction;
        /// <summary>
        /// The time period, in which line repeats regularly.
        /// </summary>
        private Period period;
        /// <summary>
        /// The provider's name of this line.
        /// </summary>
        private String provider;
        /// <summary>
        /// List of lines, which are connected with this line.
        /// </summary>
        private List<TrainLine> connectedTrainLInes;
        /// <summary>
        /// Time of original departure loaded from input.
        /// </summary>
        private Time originalDepartureFromFirstStation;
        /// <summary>
        /// Determine whether line is already fixed.
        /// </summary>
        private Boolean isFixed;
        /// <summary>
        /// Transfers from this line.
        /// </summary>
        private List<Transfer> transfersOffThisLine;
        /// <summary>
        /// Transfers to this line.
        /// </summary>
        private List<Transfer> transfersOnThisLine;
        /// <summary>
        /// Time shitf valid within equivalent group of connected lines.
        /// </summary>
        private Time connectedLineShift;
 
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainLine"/> class.
        /// </summary>
        public TrainLine()
        {
            setDefaultValue();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainLine"/> class.
        /// </summary>
        /// <param name="trainLN">The line's number.</param>
        /// <param name="typeOT">The type of train.</param>
        /// <param name="direct">The direction.</param>
        /// <param name="period_">The time period.</param>       
        public TrainLine(int trainLN, TypeOfTrain typeOT, Direction direct, Period period_)
        {
            setDefaultValue();
            trainLineNumber = trainLN;
            typeOfTrain = typeOT;
            direction = direct;
            period = period_;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the transfers off this line.
        /// </summary>
        /// <value>The transfers off.</value>
        public List<Transfer> TransfersOff 
        {
            get 
            {
                return transfersOffThisLine;
            }
            set 
            {
                transfersOffThisLine = value;
            }
        }

        /// <summary>
        /// Gets or sets the transfers on.
        /// </summary>
        /// <value>The transfers on.</value>
        public List<Transfer> TransfersOn 
        {
            get 
            {
                return transfersOnThisLine;
            }
            set 
            {
                transfersOnThisLine = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fixed in context of setting departure time.
        /// </summary>
        /// <value><c>true</c> if this instance is fixed; otherwise, <c>false</c>.</value>
        public Boolean IsFixed 
        {
            get 
            {
                return isFixed;
            }
            set 
            {
                isFixed = value;
            }
        }

        /// <summary>
        /// Gets or sets the shift in context of connected line.
        /// </summary>
        /// <value>The connected line shift.</value>
        public Time ConnectedLineShift
        {
            get
            {
                return connectedLineShift;
            }
            set
            {
                connectedLineShift = value;
            }
        }

        /// <summary>
        /// Gets or sets the time of original departure.
        /// </summary>
        /// <value>The time of original departure.</value>
        public Time OriginalDeparture 
        {
            get
            {
                return originalDepartureFromFirstStation;
            }
            set
            {
                originalDepartureFromFirstStation = value;
            }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public Direction Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
            }
        }

        /// <summary>
        /// Gets or sets the line's number.
        /// </summary>
        /// <value>The line's number.</value>
        public int LineNumber
        {
            get
            {
                return trainLineNumber;
            }
            set
            {
                trainLineNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of train.
        /// </summary>
        /// <value>The type of train.</value>
        public TypeOfTrain TypeTrain
        {
            get
            {
                return typeOfTrain;
            }
            set
            {
                typeOfTrain = value;
            }
        }

        /// <summary>
        /// Gets or sets the time period.
        /// </summary>
        /// <value>The period.</value>
        public Period Period
        {
            get
            {
                return period;
            }
            set
            {
                period = value;
            }
        }

        /// <summary>
        /// Gets or sets the provider's name.
        /// </summary>
        /// <value>The provider's name.</value>
        public String Provider
        {
            get
            {
                return provider;
            }
            set
            {
                provider = value;
            }
        }

        #endregion

        #region Get Set Add Methods

        /// <summary>
        /// Gets the train line's number.
        /// </summary>
        /// <returns>Line's number.</returns>
        public int getTrainLineNumber()
        {
            return trainLineNumber;
        }

        /// <summary>
        /// Sets the train line's number.
        /// </summary>
        /// <param name="value">The line's number.</param>
        public void setTrainLineNumber(int value)
        {
            trainLineNumber = value;
        }

        /// <summary>
        /// Gets the list of train stops.
        /// </summary>
        /// <returns>The list of train stops.</returns>
        public List<TrainStop> getTrainStops()
        {
            return trainStops;
        }

        /// <summary>
        /// Adds the train stop.
        /// </summary>
        /// <param name="trainStop">The train stop.</param>
        public void addTrainStop(TrainStop trainStop)
        {
            trainStops.Add(trainStop);
        }


        /// <summary>
        /// Sets the time period.
        /// </summary>
        /// <param name="per">The period.</param>
        public void setPeriod(Period per)
        {
            period = per;
        }

        /// <summary>
        /// Gets the period.
        /// </summary>
        /// <returns>The period.</returns>
        public Period getPeriod()
        {
            return period;
        }

        /// <summary>
        /// Sets the train stops.
        /// </summary>
        /// <param name="stops">The list of train stops.</param>
        public void setTrainStops(List<TrainStop> stops)
        {
            trainStops = stops;
        }

        /// <summary>
        /// Sets the connected lines.
        /// </summary>
        /// <param name="lines">The list of connected lines.</param>
        public void setConnectedLines(List<TrainLine> lines)
        {
            connectedTrainLInes = lines;
        }

        /// <summary>
        /// Gets the connected lines.
        /// </summary>
        /// <returns>The list of connected lines.</returns>
        public List<TrainLine> getConnectedLines()
        {
            return connectedTrainLInes;
        }

        /// <summary>
        /// Adds the connected line.
        /// </summary>
        /// <param name="line">The new connected line.</param>
        public void addConnectedLine(TrainLine line)
        {
            connectedTrainLInes.Add(line);
        }

        /// <summary>
        /// Gets the first train stop of this line.
        /// </summary>
        /// <returns>The train stop.</returns>
        public TrainStop getFirstTrainStop()
        {
            // give me first stop.. numbering fromStation 0
            return getTrainStopOrderedAt(0);
        }

        /// <summary>
        /// Gets the last train stop.
        /// </summary>
        /// <returns>The train stop.</returns>
        public TrainStop getLastTrainStop()
        {
            // give me last stop.. numbering fromStation 0
            return getTrainStopOrderedAt(trainStops.Count - 1);
        }

        /// <summary>
        /// Gets the train stop ordered at.
        /// </summary>
        /// <param name="order">The ordinal number.</param>
        /// <returns>The train stop.</returns>
        public TrainStop getTrainStopOrderedAt(int order)
        {
            TrainStop newStop = null;

            // not initialized
            if (trainStops == null) return null;
            // if empty
            if (trainStops.Count.Equals(0)) return null;

            foreach (TrainStop stop in trainStops)
            {
                if (stop.OrderInTrainLine.Equals(order))
                {
                    newStop = stop;
                    break;
                }
            }

            return newStop;
        }

        /// <summary>
        /// Gets the train stop on station.
        /// </summary>
        /// <param name="stationName">Name of the station.</param>
        /// <returns>The train stop.</returns>
        public TrainStop getTrainStopOnStation(String stationName)
        {
            TrainStop newStop = null;

            // not initialized
            if (trainStops == null) return null;

            foreach (TrainStop stop in trainStops)
            {
                if (stop.TrainStation.Name.Equals(stationName))
                {
                    newStop = stop;
                    break;
                }
            }

            return newStop;
        }

        /// <summary>
        /// Gets the train stop on station.
        /// </summary>
        /// <param name="stationName">Name of the station.</param>
        /// <returns>The train stop.</returns>
        public TrainStop getTrainStopOnStation(TrainStation station)
        {
            TrainStop newStop = null;

            // not initialized
            if (trainStops == null) return null;

            foreach (TrainStop stop in trainStops)
            {
                if (stop.TrainStation == station)
                {
                    newStop = stop;
                    break;
                }
            }

            return newStop;
        }


        #endregion


        #region Public Methods

        /// <summary>
        /// Updates the relative train stops' information.
        /// </summary>
        public void updateRelativeTrainStopInformation()
        {
            //set initial value
            Time timeFromStart = Time.MinValue;
            int kmFromStart = 0;

            Boolean firstStop = true;

            // loop over all stops
            foreach(TrainStop stop in this.trainStops)
            {
                if (firstStop) 
                {
                    // km
                    stop.KmFromPreviousStop = 0;
                    stop.KmFromStart = 0;
                    // time
                    stop.TimeArrival = Time.MinValue;
                    stop.TimeDeparture = Time.MinValue;
                    stop.TimeStayingAtStation = Time.MinValue;                    
                    stop.TimeFromStart = Time.MinValue;
                    stop.TimeFromPreviousStop = Time.MinValue;

                    firstStop = false;
                    continue;
                }

                stop.TimeArrival = timeFromStart += stop.TimeFromPreviousStop;
                stop.KmFromStart = kmFromStart += stop.KmFromPreviousStop;
                stop.TimeDeparture = timeFromStart += stop.TimeStayingAtStation;
            }
        }

        /// <summary>
        /// Updates the relative train stops' information.
        /// </summary>
        //public void updateDifferentialTrainStopInformation()
        //{

        //}


        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the default value of private fields.
        /// </summary>
        private void setDefaultValue()
        {
            trainLineNumber = 0;
            trainStops = new List<TrainStop>();
            typeOfTrain = TypeOfTrain.Os;
            direction = Direction.Forward;
            period = Period.interval60;
            connectedTrainLInes = new List<TrainLine>();
            originalDepartureFromFirstStation = Time.MinValue;
            connectedLineShift = Time.MinValue;

            transfersOnThisLine = new List<Transfer>();
            transfersOffThisLine = new List<Transfer>();
        }


        #endregion
    }
}
