using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Class represents a elementary part of connection.
    /// From and to particular station, by the train line.
    /// </summary>
    public class Stage
    {
        #region Private Fields

        /// <summary>
        /// Station where the stage starts.
        /// </summary>
        private TrainStation fromStation;
        /// <summary>
        /// Station where the stage finishes.
        /// </summary>
        private TrainStation toStation;
        /// <summary>
        /// The line, which the stage belongs to.
        /// </summary>
        private TrainLine line;
        /// <summary>
        /// Time duration of this stage.
        /// </summary>
        private Time time;
        /// <summary>
        /// Distance in km of this stage.
        /// </summary>
        private int distance;
        /// <summary>
        /// The edges (station -> to next station), which the stage consist of.
        /// </summary>
        private List<Edge> edges;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Stage"/> class.
        /// </summary>
        /// <param name="edges_">The list of edges.</param>
        public Stage(List<Edge> edges_) 
        {
            edges = edges_;
            line = TrainLineCache.getInstance().getCacheContentOnNumber(edges[0].Line);
            fromStation = edges[0].FromStation;
            toStation = edges[edges.Count - 1].ToStation;
            time = TrainConnection.calculateTime(edges);
            distance = TrainConnection.calculateDistance(edges);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stage"/> class.
        /// </summary>
        /// <param name="from">From station.</param>
        /// <param name="to">To station.</param>
        /// <param name="line_">By the line.</param>
        public Stage(TrainStation from, TrainStation to, TrainLine line_)
        {
            edges = FloydWarshallUtil.createEdges(line_, from, to);
            line = line_;
            fromStation = from;
            toStation = to;
            time = TrainConnection.calculateTime(edges);
            distance = TrainConnection.calculateDistance(edges);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>The distance in km.</value>
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

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time in Time.</value>
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

        /// <summary>
        /// Gets or sets from station.
        /// </summary>
        /// <value>From station.</value>
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

        /// <summary>
        /// Gets or sets the name of from station.
        /// </summary>
        /// <value>The name of from station.</value>
        public String FromStationName
        {
            get
            {
                return fromStation.Name;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets to station.
        /// </summary>
        /// <value>To station.</value>
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

        /// <summary>
        /// Gets or sets the name of to station.
        /// </summary>
        /// <value>The name of to station.</value>
        public String ToStationName
        {
            get
            {
                return toStation.Name;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        /// <value>The line.</value>
        public TrainLine Line
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

        /// <summary>
        /// Gets the line number.
        /// </summary>
        /// <value>The line number.</value>
        public int LineNumber
        {
            get
            {
                return line.LineNumber;
            }
        }

        /// <summary>
        /// Gets or sets the edges.
        /// </summary>
        /// <value>The list of edges.</value>
        public List<Edge> Edges
        {
            get
            {
                return edges;
            }
            set
            {
                edges = value;
            }
        }

        #endregion

        #region Get Set Methods

        /// <summary>
        /// Gets the edges.
        /// </summary>
        /// <returns>List of edges.</returns>
        public List<Edge> getEdges()
        {
            return edges;
        }

        /// <summary>
        /// Sets the edges.
        /// </summary>
        /// <param name="edges_">The list of edges.</param>
        public void setEdges(List<Edge> edges_)
        {
            edges = edges_;
        }

        #endregion

    }
}
