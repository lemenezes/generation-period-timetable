using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public class TrainConnection
    {
        #region Private Fields

        const String STATIONS_DELIMITER = ", ";
        const String LINES_DELIMITER = "->";
        /// <summary>
        /// List of edges that create a path from to.
        /// Edge -> from station to the next closest station.
        /// </summary>
        private List<Edge> edges;
        /// <summary>
        /// List of stages that create a path from to.
        /// Stage -> from station to station on the path by one line.
        /// </summary>
        private List<Stage> stages;
        /// <summary>
        /// Start train station.
        /// </summary>
        private TrainStation fromStation;
        /// <summary>
        /// destinate train station
        /// </summary>
        private TrainStation toStation;
        /// <summary>
        /// number of expected passengers
        /// </summary>
        private int passengers;
        /// <summary>
        /// time without staying at stations, or waiting on changingStations
        /// </summary>
        private Time time;
        /// <summary>
        /// distance between off station and destination station
        /// </summary>
        private int distance;
        /// <summary>
        /// list of variableLines on the path
        /// </summary>
        private List<TrainLine> linesOfConnection;
        /// <summary>
        /// list of station where to transfers
        /// </summary>
        private List<TrainStation> changingStations;

        #endregion

        #region Constructors

        public TrainConnection() 
        {
            setDefaultValues();
        }

        public TrainConnection(TrainStation from, TrainStation to, List<Edge> edges_)
        {
            setDefaultValues();
            fromStation = from;
            toStation = to;
            edges = edges_;
            createTrainConnection(edges_);
        }

        public TrainConnection(List<Edge> edges_)
        {
            setDefaultValues();
            createTrainConnection(edges_);
        }

        #endregion

        #region Public Calculation Methods

        /// <summary>
        /// Function calculate time off start to destination station.
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static Time calculateTime(List<Edge> edges)
        {
            Time totalTime = new Time();
            foreach (Edge edge in edges) 
            {
                totalTime += edge.Time;
            }

            return totalTime;
        }

        public static Time calculateTime(List<Stage> stages) 
        {
            Time totalTime = new Time();
            foreach (Stage stage in stages)
            {
                totalTime += stage.Time;
            }

            return totalTime;
        }

        /// <summary>
        /// Method calculates total time of this train connection
        /// off strat to destination station.
        /// </summary>
        public void calculateTime()
        {
            // randomizeTimetable time using edges
            //time = calculateTime(edges);
            // randomizeTimetable time using stages
            time = calculateTime(stages);
        }

        /// <summary>
        /// Function calculates a total distance for the path of edges.
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static int calculateDistance(List<Edge> edges)
        {
            int totalDistance = 0;
            foreach(Edge edge in edges)
            {
                totalDistance += edge.Distance;
            }
            return totalDistance;
        }

        public static int calculateDistance(List<Stage> stages) 
        {
            int totalDistance = 0;
            foreach (Stage stage in stages)
            {
                totalDistance += stage.Distance;
            }
            return totalDistance;    
        }

        /// <summary>
        /// Methods calculates total distance of this train connection
        /// off start to destination station.
        /// </summary>
        public void calculateDistance() 
        {
            // calculate distance using edges
            // distance = calculateDistance(edges);
            // calculate distance using stages
            distance = calculateDistance(stages);
        }

        /// <summary>
        /// Method calculate expected number of passengers on this train connection
        /// according Newton's formula.
        /// </summary>
        public void calculatePassengers()
        {
            // first let run calcualtion for time
            if (time.Equals(Time.MinValue))
                calculateTime();
            // generatePassangers need a time for calculation
            passengers = NewtonFormula.generatePassengers(fromStation, toStation, time);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Function creates trainConnecion off path of (optimalized) edges.
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public void createTrainConnection(List<Edge> edges_)
        {
            // if there is path with length 0 or list of edges doesn't exist
            if (edges_.Count.Equals(0) || edges_.Equals(null)) return;
            // determine start and destination station
            fromStation = edges_[0].FromStation;
            toStation = edges_[edges_.Count - 1].ToStation;
            // set the edges
            edges = edges_;
            // randomizeTimetable local variables
            generateStages();

            generateLinesOfConnection();
            generateChangingStation();
            calculateTime();
            calculateDistance();
            calculatePassengers();
        }

        public void updateGeneratedValues()
        {
            generateLinesOfConnection();
            generateChangingStation();
            calculateTime();
            calculateDistance();
            calculatePassengers();
        }

        public static List<Stage> generateStages(TrainConnection connection)
        {
            return StageUtil.generateStages(connection);
        }

        public void generateStages()
        {
            stages = generateStages(this);
        }

        /// <summary>
        /// Funtion randomizeTimetable changing station, when path continues with different line_.
        /// That means that, next edge has different line_ number.
        /// 
        /// Static funtion may be called don't change instance of TrainConnection.
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static List<TrainStation> generateChangingStation(List<Edge> edges) 
        {
            List<TrainStation> stations = new List<TrainStation>();
            // variable for remebering previous edge
            Edge previousEdge = null;

            // loop over all edges in path
            foreach (Edge edge in edges)
            {
                // if previous edge doesn' exist, than continue with next edge
                if (previousEdge == null)
                {
                    previousEdge = edge;
                    continue;
                }
                // if previous edge has different line_ number, that means...
                if (!previousEdge.Line.Equals(edge.Line))
                    //...edge.FromStation is a changing station
                    stations.Add(edge.FromStation);

                previousEdge = edge;
            }
            // if there are no changing stations return null
            //if (stations.Count.Equals(0)) stations = null;

            return stations;
        }

        public static List<TrainStation> generateChangingStation(List<Stage> stages)
        {
            List<TrainStation> stations = new List<TrainStation>();
            // variable for remebering previous stage
            Stage previousStage = null;

            // loop over all stages in path
            foreach (Stage stage in stages) 
            {
                // if previous stage doesn' exist, than continue with next stage
                if (previousStage == null)
                {
                    previousStage = stage;
                    continue;
                }
                stations.Add(stage.FromStation);

                previousStage = stage;
            }

            return stations;
        }

        public static TrainStation findChangingStation(List<Stage> stages, int line1, int line2)
        {
            TrainStation station = null;
            Stage previousStage = null;

            // loop over all stages in path
            foreach (Stage stage in stages)
            {
                // if previous stage doesn' exist, than continue with next stage
                if (previousStage == null)
                {
                    previousStage = stage;
                    continue;
                }
                if(previousStage.LineNumber.Equals(line1) && stage.LineNumber.Equals(line2))
                {
                    station = stage.FromStation;
                    break;
                }

                previousStage = stage;
            }

            return station;
        }

        public TrainStation findChangingStation(int line1, int line2) 
        {
            return findChangingStation(this.stages, line1, line2);
        }

        /// <summary>
        /// Method randomizeTimetable changing station of particular TrainConnection,
        /// according its edges.
        /// 
        /// Method changes instance for what is called.
        /// </summary>
        public void generateChangingStation()
        {
            // using edges
            //changingStations = generateChangingStation(edges);
            // using stages
            changingStations = generateChangingStation(stages);
        }


        /// <summary>
        /// Function generates variableLines of connetcion according of edges of path.
        /// New line_ is added, when previous edge has different line_ number.
        /// 
        /// Static funtion may be called don't change instance of TrainConnection.
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static List<TrainLine> generateLinesOfConnection(List<Edge> edges)
        {
            List<TrainLine> lines = new List<TrainLine>();
            TrainLine line = null;
            // variable for remembering previous edge
            Edge previousEdge = null;
            // loop over all edges in path
            foreach(Edge edge in edges)
            {
                // if no previous edge exists then addConstraint first line_ and continue
                if (previousEdge == null)
                {
                    line = TrainLineCache.getInstance().getCacheContentOnNumber(edge.Line);
                    lines.Add(line);
                    previousEdge = edge;
                    continue;
                }
                // if previous edge of path has a different line_ number, 
                if (!previousEdge.Line.Equals(edge.Line))
                {
                    line = TrainLineCache.getInstance().getCacheContentOnNumber(edge.Line);
                    lines.Add(line);
                    previousEdge = edge;
                }               
            }
            // if path has no variableLines return null
            // if (variableLines.Count.Equals(0)) variableLines = null;

            return lines;
        }

        public static List<TrainLine> generateLinesOfConnection(List<Stage> stages) 
        {
            List<TrainLine> lines = new List<TrainLine>();
            //TrainLine line = null;
            // variable for remembering previous edge
            //Edge previousEdge = null;
            // loop over all edges in path
            foreach (Stage stage in stages)
            {
                lines.Add(stage.Line);
            }

            return lines;
        }

        /// <summary>
        /// Method generates variableLines of connection of particular TrainConnection,
        /// according its edges.
        /// 
        /// Method changes instance for what is called.
        /// </summary>
        public void generateLinesOfConnection() 
        {
            // generates variableLines of connection using edges
            //linesOfConnection = generateLinesOfConnection(edges);
            linesOfConnection = generateLinesOfConnection(stages);
        }

        #endregion

        #region Properties

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

        public String ChangingStation
        {
            get
            {
                return toString(changingStations);
            }
            set
            {
            }
        }

        public String LinesOfConnection
        {
            get
            {
                return toString(linesOfConnection);
            }
            set
            {
            }
        }

        #endregion

        #region Get Set Add Methods

        public List<TrainStation> getChangingStation()
        {
            return changingStations;
        }

        public void setChangingStation(List<TrainStation> stations)
        {
            changingStations = stations;
        }

        public void addChangingStation(TrainStation station)
        {
            changingStations.Add(station);
        }

        public void setFromStation(TrainStation station)
        {
            fromStation = station;
        }

        public TrainStation getFromStation()
        {
            return fromStation;
        }

        public void setToStation(TrainStation station)
        {
            toStation = station;
        }

        public TrainStation getToStation()
        {
            return toStation;
        }

        public List<TrainLine> getLinesOfConnection()
        {
            return linesOfConnection;
        }

        public void setLinesOfConnection(List<TrainLine> lines)
        {
            linesOfConnection = lines;
        }

        public void addLineAtConnection(TrainLine line)
        {
            linesOfConnection.Add(line);
        }

        public List<Edge> getEdges()
        {
            return edges;
        }

        public void setEdges(List<Edge> edges_)
        {
            edges = edges_;
        }

        public void addEdge(Edge edge)
        {
            edges.Add(edge);
        }

        public List<Stage> getStages()
        {
            return stages;
        }

        public void setStages(List<Stage> stages_)
        {
            stages = stages_;
        }

        #endregion

        #region ToString Methods

        public static String toString(List<TrainStation> stations) 
        {
            String str = "";
            if (stations == null) return str;
            foreach (TrainStation station in stations) 
            {
                // if final string is not empty, this is not a first station
                if (!str.Equals("")) 
                {
                    // addConstraint first delimiter at the end of string
                    str += STATIONS_DELIMITER;
                }
                // addConstraint station Name
                str += station.Name;
            }

            return str;
        }

        public static String toString(List<TrainLine> lines) 
        {
            String str = "";
            // loop over all variableLines
            foreach (TrainLine line in lines) 
            {
                // if this is not a first line_
                if (!str.Equals("")) 
                {
                    // addConstraint first delimiter
                    str += LINES_DELIMITER;
                }
                str += line.LineNumber.ToString();
            }

            return str;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method sets default values for variables of this instance.
        /// </summary>
        private void setDefaultValues()
        {
            fromStation = null;
            toStation = null;
            edges = new List<Edge>();
            passengers = 0;
            time = Time.MinValue;
            linesOfConnection = new List<TrainLine>();
            changingStations = new List<TrainStation>();
        }

        #endregion
    }
}
