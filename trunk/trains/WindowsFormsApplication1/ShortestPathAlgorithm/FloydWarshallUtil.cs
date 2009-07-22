using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public static class FloydWarshallUtil
    {
        public static int[] createArrayOfNode(List<TrainStation> trainStations)
        {
            // allocate new array
            int[] array = new int[trainStations.Count];

            int index = 0;
            // foreach station copy id of station into array
            foreach (TrainStation station in trainStations) 
            {
                array[index] = station.Id;
                index++;
            }

            return array;
        }

        public static int[,] createArrayOfNxN(int n)
        {
            return new int[n, n];
        }

        public static Time[,] crateArrayOfTimeNxN(int n)
        {
            return new Time[n, n];
        }

        public static List<Edge> createEdges(List<TrainLine> lines)
        {
            List<Edge> edges = new List<Edge>();

            // loop over variableLines
            foreach (TrainLine line in lines)
            {
                edges.AddRange(createEdges(line));
            }

            return edges;
        }

        public static List<Edge> createEdges(TrainLine line) 
        {
            List<Edge> edges = new List<Edge>();
            Boolean first = true;
            List<TrainStop> stops;
            TrainStop previousStop = null;

            stops = line.getTrainStops();
            // loop over stops
            foreach (TrainStop stop in stops)
            {
                // first run = first stop
                if (first)
                {
                    previousStop = stop;
                    first = false;
                }
                // other stops
                else
                {
                    // createConstraintSet new edge according line_ and stop information
                    Edge edge = new Edge(previousStop.TrainStation,
                                        stop.TrainStation,
                                        stop.TimeFromPreviousStop,
                                        stop.KmFromPreviousStop,
                                        line.LineNumber);
                    // addConstraint edge into edges
                    edges.Add(edge);
                    // save stop as a previous stop for next loop
                    previousStop = stop;
                }
            }

            return edges;
        }

        public static List<Edge> createEdges(TrainLine line, TrainStation from, TrainStation to) 
        {
            return createEdges(line, from.Id, to.Id);
        }

        public static List<Edge> createEdges(TrainLine line, int from, int to) 
        {
            List<Edge> edges = new List<Edge>();
            Boolean first = true;
            Boolean perform = false;
            List<TrainStop> stops;
            TrainStop previousStop = null;

            stops = line.getTrainStops();
            // loop over stops
            foreach (TrainStop stop in stops)
            {
                // first find a stop with FROM station
                if (stop.TrainStation.Id.Equals(from))
                {
                    perform = true;
                }
                // perform creating a path
                if (perform)
                {
                    // first run = first stop
                    if (first)
                    {
                        previousStop = stop;
                        first = false;
                    }
                    // other stops
                    else
                    {
                        // createConstraintSet new edge according line_ and stop information
                        Edge edge = new Edge(previousStop.TrainStation,
                                            stop.TrainStation,
                                            stop.TimeFromPreviousStop,
                                            stop.KmFromPreviousStop,
                                            line.LineNumber);
                        // addConstraint edge into edges
                        edges.Add(edge);
                        // save stop as a previous stop for next loop
                        previousStop = stop;
                    }
                }
                // last stop find, stop perform creating
                if (perform && stop.TrainStation.Id.Equals(to)) 
                {
                    perform = false;
                    break;
                }
            }

            return edges;
        }
    }
}
