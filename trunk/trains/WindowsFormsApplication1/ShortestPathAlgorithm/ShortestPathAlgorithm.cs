using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PeriodicTimetableGeneration
{
    public class ShortestPathAlgoritm
    {
        #region Private Fields

        private List<TrainConnection> trainConnections;
        private FloydWarshall floydWarshalAlgorithm;

        #endregion

        #region Nested Static Class

        private static class SingletonHolder 
        {
            static SingletonHolder() {}

            internal static readonly ShortestPathAlgoritm INSTANCE =
                new ShortestPathAlgoritm(TrainLineCache.getInstance().getCacheContent(),
                                        TrainStationCache.getInstance().getCacheContent());
        }

        /// <summary>
        /// Method which return instance of ShortestPathAlgoritm class holded by Singleton class.
        /// </summary>
        /// <returns></returns>
        public static ShortestPathAlgoritm getInstance() 
        {
            return SingletonHolder.INSTANCE;
        }

        #endregion

        #region Constructors

        public ShortestPathAlgoritm()
        {
            setDefaultValue();
        }

        public ShortestPathAlgoritm(List<TrainLine> lines, List<TrainStation> stations) 
        {
            setDefaultValue();
            floydWarshalAlgorithm = new FloydWarshall(lines, stations);
        }

        #endregion

        #region Public Methods

        public void calculateShortestPath()
        {
            floydWarshalAlgorithm.resetInstanceValues();
            floydWarshalAlgorithm.calculateShortestPaths();
        }

        public void generateAllTrainConnections()
        {
            // clearStableLines train connection off previous run
            trainConnections.Clear();
            // retreive all paths off field stationXstation
            List<List<Edge>> allPaths = floydWarshalAlgorithm.getAllPaths();

            printToFile(allPaths,"path.tmp");

            List<Edge> otpimizedPath;

            foreach (List<Edge> path in allPaths)
            {
                //TrainConnection fictive = new TrainConnection(path);
                //Console.Out.WriteLine("---------------------------------");
                //Console.Out.WriteLine("before: "+ fictive.LinesOfConnection);

                // optimse path
                otpimizedPath = optimisePath(path, floydWarshalAlgorithm.getEdgesCache());
                // createConstraintSet train connection
                TrainConnection connection = new TrainConnection(otpimizedPath);

                //Console.Out.WriteLine("after: " +connection.LinesOfConnection);

                trainConnections.Add(connection);
            }
            
        }

        public void printToFile(List<List<Edge>> paths, String fileName) 
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            foreach(List<Edge> path in paths)
            {
                String str = FloydWarshall.toString(path);
                sw.WriteLine(str);
            }
            sw.Close();
            fs.Close();
        }

        /****************************************/
        // Optimization path' related methods
        /****************************************/


        public static List<Edge> optimisePath(List<Edge> edges, List<Edge> edgesCache) 
        {
            List<Edge> optimizedPath;
            // if the start and end station are the same
            optimizedPath = optimizationFunctionSameLine(edges, edgesCache);

            // make optimization on zig-zag path, step by stages
            optimizedPath = optimizationFunctionZigZagByStages(optimizedPath, edgesCache);

            // make optimization on zig-zag path, step by edges  (L1->L2->L1->L2)
            optimizedPath = optimizationFunctionZigZagByEdges(optimizedPath, edgesCache);
            

            return optimizedPath;
        }

        private static List<Edge> optimizationFunctionSameLine(List<Edge> edges, List<Edge> edgeCache) 
        {
            // retreive all lines
            List<TrainLine> allLines = TrainLineCache.getInstance().getCacheContent();
            List<Edge> newPath = edges;

            // loop over all lines
            foreach (TrainLine line in allLines) 
            {
                // find if one line contains first and last stop on path
                if (containsTrainStations(line, edges[0].From, edges[edges.Count - 1].To))
                {
                    // prepare new path
                    newPath = FloydWarshallUtil.createEdges(line, edges[0].From, edges[edges.Count - 1].To);
                }
            }
            // return the same or new
            return newPath;
        }

        private static List<Edge> optimizationFunctionZigZagByStages(List<Edge> edges, List<Edge> edgesCache) 
        {
            List<Edge> newEdges = new List<Edge>();

            // loop over all edges with index
            for (int i = 0; i < edges.Count; i++) 
            {
                // define last index
                int last = edges.Count-1;
                // find last edges where the line is the same
                while(i<last)
                {
                    // if edges on the last current index has the same line
                    if(edges[last].Line.Equals(edges[i].Line))
                    {
                        break;
                    }
                    last--;
                }
                // if there is path > 1
                if ((last - i) > 1)
                {
                    // between thouse indices replace edges for 
                    List<Edge> alternative = FloydWarshallUtil.createEdges(TrainLineCache.getInstance().getCacheContentOnNumber(edges[i].Line),
                        edges[i].From, edges[last].To);
                    // add alternative path instead
                    newEdges.AddRange(alternative);
                    // index += path
                    i = last;
                }
                else 
                {
                    // add original edge
                    newEdges.Add(edges[i]);
                    // index ++, in for loop
                }
            }
            return newEdges;
        }

        private static List<Edge> optimizationFunctionZigZagByEdges(List<Edge> edges, List<Edge> edgesCache)
        {            
            //List<TrainLine> optimizedPathOfLines;
            //optimizedPathOfLines = TrainConnection.generateLinesOfConnection(edges);

            // create a new optimizes path
            List<Edge> optimizedPath = new List<Edge>();

            // variable for previous edge
            Edge previousEdge = null;
            // variable for alternative edge
            Edge alternativeEdge = null;
            // boolean indication for first run of loop
            Boolean first = true;
            // loop over all edges
            foreach (Edge edge in edges)
            {
                // if first run of loop
                if (first) 
                {
                    // set previous
                    previousEdge = edge;
                    // add edge
                    optimizedPath.Add(edge);
                    // set first on false
                    first = false;
                    // continue with second run of loop
                    continue;
                }
                // try to find alternative edge from , to, with previous line
                //alternativeEdge =  findEdge(edgesCache, edge.From, edge.To, previousEdge.Line);
                // if previous edge has the same line
                if (previousEdge.Line.Equals(edge.Line))
                {
                    // just add edge
                    optimizedPath.Add(edge);
                    // set previous edge
                    previousEdge = edge;
                }
                // else if exist the edge from, to, with previous line
                else if ((alternativeEdge =  findEdge(edgesCache, edge.From, edge.To, previousEdge.Line))
                    != null) 
                {
                    // add this edge instead
                    optimizedPath.Add(alternativeEdge);
                    // set previous edge
                    previousEdge = alternativeEdge;
                }
                else
                {
                    // otherwise add edge without changes
                    optimizedPath.Add(edge);
                    // set previous edge
                    previousEdge = edge;
                }
                
            }
            return optimizedPath;   
        }

        private static Boolean containsTrainStations(TrainLine line, int from, int to) 
        {
            Boolean first = false;
            Boolean last = false;
            // loop over all train stops on line
            foreach (TrainStop stop in line.getTrainStops()) 
            {
                // if contains first stop FROM
                if (stop.TrainStation.Id.Equals(from))
                    first = true;
                // if has already constained first and contains stop TO
                if (first && stop.TrainStation.Id.Equals(to))
                    last = true;

                // if already determine whether it contains both
                if (first && last)
                    break;
            }

            return first && last;
        }


        /****************************************/
        // TrainConnections' related methods
        /****************************************/

        /// <summary>
        /// Funtion creates trainConnecion off path of (optimalized) edges.
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static TrainConnection createTrainConnection(List<Edge> edges)
        {
            // if there is path with length 0 or list of edges doesn't exist
            if (edges.Count.Equals(0) || edges.Equals(null)) return null;
            // determine start and destination station
            TrainStation from = edges[0].FromStation;
            TrainStation to = edges[edges.Count - 1].ToStation;

            // createConstraintSet new connection with start and destination stattion, and path of edges
            TrainConnection connection = new TrainConnection(from, to, edges);
            // randomizeTimetable changing station and set them in connection
            connection.setChangingStation(TrainConnection.generateChangingStation(edges));
            // randomizeTimetable variableLines of connection and set them in connection
            connection.setLinesOfConnection(TrainConnection.generateLinesOfConnection(edges));

            // calculate other variabiles
            connection.calculateDistance();
            connection.calculatePassengers();
            connection.calculateTime();
            
            return connection;
        }

    
        /// <summary>
        /// Method addConstraint new connection to cache.
        /// </summary>
        /// <param name="connection"></param>
        public void addTrainConnection(TrainConnection connection)
        {
            // test if connection off to already exits
            if (!doesConnectionExist(connection.FromStation, connection.ToStation))         
                // if no, then addConstraint
                trainConnections.Add(connection);
        }

        /// <summary>
        /// Function determine if specific connection off to already exists/
        /// </summary>
        /// <param name="off"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public Boolean doesConnectionExist(TrainStation from, TrainStation to)
        {
            Boolean exists = true;
            // try to find connection, if null value returns, connection doesn't exist
            if (findConnection(from, to) == null)
                exists = false;

            return exists;
        }

        /// <summary>
        /// Function returns all trainConnections as a List<>.
        /// </summary>
        /// <returns></returns>
        public List<TrainConnection> getTrainConnections()
        {
            return trainConnections;
        }

        /// <summary>
        /// Function returns a connection according specific station off to if exists.
        /// </summary>
        /// <param name="off"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public TrainConnection getTrainConnectionOnFromTo(TrainStation from, TrainStation to)
        {
            return findConnection(from, to);
        }

        /// <summary>
        /// Function returns a connection according specific station names off to if exists.
        /// </summary>
        /// <param name="off"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public TrainConnection getTrainConnectionOnFromTo(String from, String to)
        {
            return findConnection(from, to);
        }

        /// <summary>
        /// Method set trainConnections variable.
        /// </summary>
        /// <param name="connections"></param>
        public void setTrainConnections(List<TrainConnection> connections)
        {
            trainConnections = connections;
        }

        public List<TrainConnection> groupByListOfLines(List<TrainConnection> connections)
        {
            throw new System.NotImplementedException();
        }

        #endregion


        #region Private Methods

        private static Edge findEdge(List<Edge> edges, int from, int to, int line) 
        {
            Edge wantedEdge = null;

            foreach (Edge edge in edges) 
            {
                // if the proper edge indicate
                if (edge.From.Equals(from) && edge.To.Equals(to)
                    && edge.Line.Equals(line)) 
                {
                    wantedEdge = edge;
                    break;
                }
            }

            return wantedEdge;
        }

        /// <summary>
        /// Method sets default values of fields.
        /// </summary>
        private void setDefaultValue()
        {
            floydWarshalAlgorithm = null;
            trainConnections = new List<TrainConnection>();
        }

        /// <summary>
        /// Function finds connection between station off and to.
        /// </summary>
        /// <param name="off"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private TrainConnection findConnection(TrainStation from, TrainStation to)
        {
            TrainConnection connection = null;
            foreach(TrainConnection c in trainConnections)
            {
                if (c.FromStation.Equals(from) && c.ToStation.Equals(to))
                {
                    connection = c;
                    break;
                }
            }

            return connection;
        }

        /// <summary>
        /// Function finds connection between station names off and to.
        /// </summary>
        /// <param name="off"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private TrainConnection findConnection(String from, String to) 
        {
            TrainConnection connection = null;
            foreach (TrainConnection c in trainConnections)
            {
                if (c.FromStation.Name.Equals(from) && c.ToStation.Name.Equals(to))
                {
                    connection = c;
                    break;
                }
            }

            return connection;
        }

        #endregion


    }
}
