using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public class Edge
    {

        #region Private Fields

        /// <summary>
        /// distance in km
        /// </summary>
        private int distance;
        /// <summary>
        /// number of line_
        /// </summary>
        private int line;
        /// <summary>
        /// time
        /// </summary>
        private Time time;
        /// <summary>
        /// train station reference
        /// </summary>
        private TrainStation fromStation;
        /// <summary>
        /// id of station
        /// </summary>
        private int from;
        /// <summary>
        /// train station reference
        /// </summary>
        private TrainStation toStation;
        /// <summary>
        /// id of station
        /// </summary>
        private int to;

        #endregion


        #region Constructor

        public Edge() 
        {
            from = -1;
            to = -1;
            time = Time.MaxValue;
            distance = int.MaxValue;
            line = 0;
            fromStation = null;
            toStation = null;
        }

        public Edge(int from_, int to_, Time time_, int distance_, int line_)
        {
            from = from_;
            fromStation = TrainStationCache.getInstance().getCacheContentOnSelect(from_);
            to = to_;
            toStation = TrainStationCache.getInstance().getCacheContentOnSelect(to_);
            time = time_;
            distance = distance_;
            line = line_;
        }

        public Edge(TrainStation from_, TrainStation to_, Time time_, int distance_, int line_)
        {
            fromStation = from_;
            from = fromStation.Id;
            toStation = to_;
            to = toStation.Id;
            time = time_;
            distance = distance_;
            line = line_;
        }

        #endregion

        #region Properties
        
        public int Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }

        public int Line
        {
            get
            {
                return line;
            }
            set
            {
                line = value;
            }
        }

        public Time Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        public int From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        public int To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        public TrainStation FromStation
        {
            get
            {
                return fromStation;
            }
            set
            {
                fromStation = value;
            }
        }

        public TrainStation ToStation
        {
            get
            {
                return toStation;
            }
            set
            {
                toStation = value;
            }
        }

        #endregion

    }
}
