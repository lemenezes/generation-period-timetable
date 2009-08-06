using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Class represents a tranfer from one and to another train line.
    /// </summary>
    public class Transfer
    {
        #region Private Fields

        /// <summary>
        /// The line's number, where transfers off.
        /// </summary>
        private int off;
        /// <summary>
        /// The line's number, where transfers on.
        /// </summary>
        private int on;


        /// <summary>
        /// The train line, where transfers off.
        /// </summary>
        private TrainLine offLine;
        /// <summary>
        /// The train line, where transfers on.
        /// </summary>
        private TrainLine onLine;
        /// <summary>
        /// The number of passengers.
        /// </summary>
        private int passengers;
        /// <summary>
        /// The station's id.
        /// </summary>
        private int stationID;
        /// <summary>
        /// The train staiton, where transfers at.
        /// </summary>
        private TrainStation station;

        private int trainStopIndexOffLine;

        private int trainStopIndexOnLine;


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Transfer"/> class.
        /// </summary>
        /// <param name="off_">The line's number, transfer off.</param>
        /// <param name="on_">The line's number, transfer on.</param>
        /// <param name="stationI">The station's Id.</param>
        public Transfer(int off_, int on_, int stationI)
        {
            setDefaultValues();
            off = off_;
            on = on_;
            stationID = stationI;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transfer"/> class.
        /// </summary>
        /// <param name="off_">The line, transfer off.</param>
        /// <param name="on_">The line, transfer on.</param>
        /// <param name="station_">The station, where transfers at.</param>
        public Transfer(TrainLine off_, TrainLine on_, TrainStation station_)
        {
            setDefaultValues();
            offLine = off_;
            onLine = on_;
            off = off_.LineNumber;
            on = on_.LineNumber;
            stationID = station_.Id;
            station = station_;
            // indices
            trainStopIndexOffLine = off_.getTrainStopOnStation(station).OrderInTrainLine;
            trainStopIndexOnLine = on_.getTrainStopOnStation(station).OrderInTrainLine;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the default values of private fields.
        /// </summary>
        private void setDefaultValues()
        {
            off = 0;
            on = 0;
            stationID = -1;
            passengers = 0;
            offLine = null;
            onLine = null;
            station = null;
        }

        #endregion


        #region Properties

        public int TrainStopIndexOffLine
        {
            get
            {
                return trainStopIndexOffLine;
            }
            set
            {
                trainStopIndexOffLine = value;
            }
        }

        public int TrainStopIndexOnLine
        {
            get
            {
                return trainStopIndexOnLine;
            }
            set
            {
                trainStopIndexOnLine = value;
            }
        }

        /// <summary>
        /// Gets or sets the passengers.
        /// </summary>
        /// <value>The number of passengers.</value>
        public int Passengers
        {
            get
            {
                return passengers;
            }
            set
            {
                passengers = value;
            }
        }

        /// <summary>
        /// Gets or sets the line's number, where transfer off.
        /// </summary>
        /// <value>The line's number.</value>
        public int Off
        {
            get
            {
                return off;
            }
            set
            {
                off = value;
            }
        }

        /// <summary>
        /// Gets or sets the line's number, where transfer on.
        /// </summary>
        /// <value>The line's number.</value>
        public int On
        {
            get
            {
                return on;
            }
            set
            {
                on = value;
            }
        }

        /// <summary>
        /// Gets or sets the station's ID.
        /// </summary>
        /// <value>The station's ID.</value>
        public int StationID
        {
            get
            {
                return stationID;
            }
            set
            {
                stationID = value;
            }
        }

        /// <summary>
        /// Gets or sets the station, where transfers at.
        /// </summary>
        /// <value>The train station.</value>
        public TrainStation Station
        {
            get 
            {
                return station;
            }
            set 
            {
                station = value;
            }
        }

        /// <summary>
        /// Gets or sets the line, where transfers off.
        /// </summary>
        /// <value>The train line.</value>
        public TrainLine OffLine
        {
            get
            {
                return offLine;
            }
            set
            {
                offLine = value;
            }
        }

        /// <summary>
        /// Gets or sets the line, where transfers on.
        /// </summary>
        /// <value>The train line.</value>
        public TrainLine OnLine
        {
            get
            {
                return onLine;
            }
            set
            {
                onLine = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Evaluates the transfer penalty function.
        /// </summary>
        /// <param name="transfer">The transfer.</param>
        /// <param name="time">The time for transfer.</param>
        /// <returns></returns>
        public static int evaluateTransferFunction(Transfer transfer, Time time)
        {
            // multiple constant
            const int FACTOR = 10;

            int result = time.ToMinutes() * transfer.passengers / FACTOR;
            //Console.Out.WriteLine("Rating: " + time.ToMinutes() + " * " + transfers.passengers + " / " + solutionFactor + " = " + result);
            return result;
        }

        /// <summary>
        /// Evaluates the transfer penalty function.
        /// </summary>
        /// <param name="time">The time for transfer.</param>
        /// <returns></returns>
        public int evaluateTransferFunction(Time time)
        {
            return evaluateTransferFunction(this, time);
        }

        #endregion

    }
}
