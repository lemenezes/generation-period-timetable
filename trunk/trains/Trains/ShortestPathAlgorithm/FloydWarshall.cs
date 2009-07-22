using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PeriodicTimetableGeneration
{
    public class FloydWarshall
    {
        #region Private Fields

        /// <summary>
        /// 
        /// </summary>
        private List<TrainLine> trainLines;
        private List<TrainStation> trainStations;
        /// <summary>
        /// default value for distance array, maximum level
        /// </summary>
        private const int distanceDefault = int.MaxValue;
        /// <summary>
        /// default value for distance array, minimum level
        /// </summary>
        private const int distanceDefaultZero = 0;
        /// <summary>
        /// default maximum value for time array
        /// </summary>
        private Time timeDefaultMax = Time.MaxValue;
        /// <summary>
        /// default minimum value for time array
        /// </summary>
        private Time timeDefaultMin = Time.MinValue;
        /// <summary>
        /// default value for throughStation array, -1 as invalid index
        /// </summary>
        private const int throughStationDefault = -1;
        /// <summary>
        /// array NxN with time content, in minutes
        /// </summary>
        private Time[,] time;
        /// <summary>
        /// array NxN with line_ number content
        /// </summary>
//        private int[,] line_;
        /// <summary>
        /// array NxN with distance content
        /// </summary>
        private int[,] distance;
        /// <summary>
        /// array NXN with content of previous station
        /// </summary>
        private int[,] throughStation;
        /// <summary>
        /// array N of edges
        /// </summary>
        private List<Edge> edges;
        /// <summary>
        /// array N of stationIDs
        /// </summary>
        private int[] nodes;
        /// <summary>
        /// number of nodes/stations, size of matrices/multidimensional arrays
        /// </summary>
        private int n;

        #endregion

        #region Constructors

        public FloydWarshall(List<TrainLine> lines, List<TrainStation> stations)
        {
            trainLines = lines;
            trainStations = stations;
            createFloydWarshall(lines, stations);
        }

        #endregion

        #region Initialization Array Methods

        //----------------------------------------------
        // methods for initialization arrays
        //----------------------------------------------

        private void initializeArrays(List<Edge> edges)       // int[,] distance, int[,] time, int[,] line_, int[,] throughStation)
        {
            int from, to;
            // initialize array by default value
            initializeArray(distance, distanceDefault, distanceDefaultZero);
            initializeArray(time, timeDefaultMax, timeDefaultMin);
            //initializeArray(line_, 0);
            initializeArray(throughStation, throughStationDefault);
            // foreach edge fill appropirate values
            foreach (Edge edge in edges)
            {
                // initialize array by specific value
                from = edge.From;
                to = edge.To;
                distance[from, to] = edge.Distance;
                time[from, to] = edge.Time;
                //line_[fromStation, toStation] = edge.Line;
                //throughStation[fromStation, toStation] = distanceDefault;
            }
        }

        private void initializeArray(int[,] array, int value)
        {
            int maxX = array.GetLength(0);
            int maxY = array.GetLength(1);
            // access all fields and assign default value
            for (int x = 0; x != maxX; x++)
                for (int y = 0; y != maxY; y++)
                {
                    array[x, y] = value;
                }
        }

        private void initializeArray(int[,] array, int value, int diagonalValue) 
        {
            int maxX = array.GetLength(0);
            int maxY = array.GetLength(1);
            // access all fields and assign default value
            for (int x = 0; x != maxX; x++)
                for (int y = 0; y != maxY; y++)
                {
                    // if diagonal coordinates
                    if (x == y)
                    {
                        array[x, y] = diagonalValue;
                    }
                    else 
                    {
                        array[x, y] = value;
                    }
                }
        }

        private void initializeArray(Time[,] array, Time timeValue) 
        {
            //Boolean min = timeValue.Equals(Time.MinValue);

            int maxX = array.GetLength(0);
            int maxY = array.GetLength(1);
            // access all fields and assign default value
            for (int x = 0; x != maxX; x++)
                for (int y = 0; y != maxY; y++)
                {
                    array[x, y] = new Time(timeValue);
                    // diagonal version
                    //if (x == y)
                    //    array[x, y] = Time.MinValue;
                }
        }

        private void initializeArray(Time[,] array, Time timeValue, Time diagonalTimeValue)
        {
            //Boolean min = timeValue.Equals(Time.MinValue);

            int maxX = array.GetLength(0);
            int maxY = array.GetLength(1);
            // access all fields and assign default value
            for (int x = 0; x != maxX; x++)
                for (int y = 0; y != maxY; y++)
                {
                    // if diagonal coordinates
                    if (x == y)
                    {
                        array[x, y] = diagonalTimeValue;
                    }
                    else 
                    {
                        // inicialize with time value
                        array[x, y] = timeValue;
                    }
                }
        }


        #endregion

        #region Public Methods

        public void resetInstanceValues()
        {
            createFloydWarshall(trainLines, trainStations);
        }

        //----------------------------------------------
        // methods for construction path off to
        //----------------------------------------------

        public List<TrainStation> getPathStations(TrainStation start, TrainStation end)
        {
            throw new System.NotImplementedException();
        }

        public int[] getPathNodes(int start, int end)
        {
            throw new System.NotImplementedException();
        }

        public List<TrainLine> getPathLines(int start, int end)
        {
            throw new System.NotImplementedException();
        }

        public List<List<Edge>> getAllPaths() 
        {
            List<List<Edge>> allPath = new List<List<Edge>>();
            List<Edge> path = new List<Edge>();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    path = getPathEdges(i, j);
                    // i -> j, j is unreachable
                    if (path == null) continue;
                    // if i = j => path with 0 length
                    if (path.Count.Equals(0)) continue;
                    allPath.Add(path);
                }

            Console.Out.Write("all path ");
            Console.Out.WriteLine(allPath.Count);

            return allPath;
        }
        
        public List<Edge> getPathEdges(int start, int end)
        {
            List<Edge> edges = new List<Edge>();
            // if requested start = end
            if (time[start, end].Equals(Time.MinValue))
                // return empty list
                return edges;
            // if time fromStation start toStation end is infinite -> unreachable
            if (time[start, end].Equals(int.MaxValue))
                // return invalid list
                return null;
            // if intermediate node exists, through station has not invalid index
            if (!throughStation[start, end].Equals(throughStationDefault))
            {
                // getPath in range start - intermediate node
                edges.AddRange(getPathEdges(start, throughStation[start, end]));
                // getPath in range intermediate node - end
                edges.AddRange(getPathEdges(throughStation[start, end], end));
            }
            // otherwise if intermediate node doesn't exist,
            // but after previous condition is not unreachable
            else
            {
                Edge edge;
                // if edge really exists, is not null
                if( (edge = findEdge(start, end)) != null)
                    edges.Add(edge);
            }

            return edges;
        }

        public List<Edge> getEdgesCache()
        {
            return edges;
        }

        public Edge findEdge(int from, int to)
        {
            Edge newEdge = null;
            // loop over all edges
            foreach (Edge edge in edges) 
            {
                // compare fromStation, toStation and time, multiple edges may exist
                if (edge.From.Equals(from) &&
                    edge.To.Equals(to) &&
                    edge.Time.Equals(time[from, to]))
                {
                    // edge was found
                    newEdge = edge;
                    // break the loop, because we found the edge
                    break;
                }
            }
            return newEdge;
        }

        //----------------------------------------------
        // method for calcutation shortest paths
        //----------------------------------------------

        public void calculateShortestPaths()
        {
            printToFile("Before");

            // loop over all possible intermediate nodes
            for (int m = 0; m != this.n; m++)
            {
                // loop fromStation all nodes
                for (int i = 0; i != this.n; i++)
                {
                    // loop toStation all nodes
                    for (int j = 0; j != this.n; j++)
                    {
                        // calculate time through node m
                        Time timeM = time[i, m] + time[m, j];
                        // if time[i,m] and time[m,j] are not infinite and
                        // time is shorter than update all arrays
                        if (time[i, m] != Time.MaxValue && time[m, j] != Time.MaxValue
                            && timeM < time[i, j])
                        {
                            time[i, j] = timeM;
                            distance[i, j] = distance[i, m] + distance[m, j];
                            throughStation[i, j] = m;
                        }
                    }
                    // printToFile("Progress");
                }
            }
            printToFile("");
        }

        //----------------------------------------------
        // methods for output (convert toString, printToFile)
        //----------------------------------------------

        public static String toString(List<Edge> path)
        {
            String str = "";

            foreach (Edge edge in path) 
            {
                // it is a first station in path
                if (str.Equals(""))
                {
                    str += edge.FromStation.Name;
                }
                String strTmp = " -" + edge.Line + " (" + edge.Time.ToString() + ")-> " + edge.ToStation.Name;
                str += strTmp;
            }

            return str;
        }

        #endregion

        #region Private Methods

        private void printToFile(String dif)
        {
            const String BLANK_DELIMITER = "\t";
            FileStream fsTime = new FileStream("time" + dif + ".tmp", FileMode.Create);
            StreamWriter swTime = new StreamWriter(fsTime);

            FileStream fsDistance = new FileStream("distance" + dif + ".tmp", FileMode.Create);
            StreamWriter swDistance = new StreamWriter(fsDistance);

            FileStream fsStation = new FileStream("station" + dif + ".tmp", FileMode.Create);
            StreamWriter swStation = new StreamWriter(fsStation);
            
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    String strTime = String.Format("{0,22}", time[i,j]);  
                    String strDistance = String.Format("{0,13}", distance[i,j]);
                    String strStation = String.Format("{0,5}", throughStation[i,j]);

                    swTime.Write(strTime);
                    swDistance.Write(strDistance);
                    swStation.Write(strStation);

                    // we are at the end of line_
                    if (j + 1 == n)
                    {
                        swTime.WriteLine();
                        swDistance.WriteLine();
                        swStation.WriteLine();
                    }
                }
            swTime.Close();
            swDistance.Close();
            swStation.Close();
            fsTime.Close();
            fsDistance.Close();
            fsStation.Close();
        }

        private void createFloydWarshall(List<TrainLine> lines, List<TrainStation> stations)
        {
            // createConstraintSet node array, assign stationId toStation index of node
            nodes = FloydWarshallUtil.createArrayOfNode(stations);
            // initialize size n
            if (stations.Count == nodes.Length) n = nodes.Length;
            // createConstraintSet multidimensional arrays of size n
            time = FloydWarshallUtil.crateArrayOfTimeNxN(n);
            distance = FloydWarshallUtil.createArrayOfNxN(n);
            //line_ = FloydWarshallUtil.createArrayOfNxN(n);
            throughStation = FloydWarshallUtil.createArrayOfNxN(n);
            // createConstraintSet list of edges according the stops of trainlines
            edges = FloydWarshallUtil.createEdges(lines);
            // initialize all useful arrays by edges
            initializeArrays(edges);
        }

        #endregion

    }
}
