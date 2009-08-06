using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public static class StageUtil
    {
        //-----------------------------------------------------
        // Methods generating STAGES based on CONNECTION
        //-----------------------------------------------------

        /// <summary>
        /// Function generates and returns all stages existed at trainConnection.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static List<Stage> generateStages(TrainConnection connection)
        {

            List<Stage> stages = new List<Stage>();
            
            TrainStation from = connection.FromStation;

            // randomizeTimetable changing station according edges
            List<TrainStation> changingStation = TrainConnection.generateChangingStation(connection.getEdges());

            // loop over all changing station at connection
            foreach(TrainStation station in changingStation)
            {
                // randomizeTimetable connection
                Stage stage = generateStage(connection.getEdges(), from, station);
                // if exists, then addConstraint
                if (stage != null)
                    stages.Add(stage);

                // set up actual toStation as a fromStation for next loop
                from = station;
            }

            // randomizeTimetable last stage
            Stage lastStage = generateStage(connection.getEdges(), from, connection.ToStation);
            // if exists, then addConstraint last stage
            if (lastStage != null)
                stages.Add(lastStage);

            return stages;
        }

        //-----------------------------------------------------
        // Methods generating simple STAGE
        //-----------------------------------------------------

        /// <summary>
        /// Function randomizeTimetable stage off list of edges between stations off and to.
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="off"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static Stage generateStage(List<Edge> edges, TrainStation from, TrainStation to)
        {
            int indexOfFrom = findFromStation(edges, from);
            int indexOfTo = findToStation(edges, to);

            // if at least one of indices is not valid
            if (indexOfFrom.Equals(-1) || indexOfTo.Equals(-1))
                return null;

            // invalid sequence of indices, 
            if (indexOfTo < indexOfFrom)
                return null;

            // make a copy
            List<Edge> edgesCopy = new List<Edge>();
            foreach (Edge edge in edges) 
            {
                edgesCopy.Add(edge);
            }


            // if next index is not out of range
            if (indexOfTo+1 < edgesCopy.Count)
                // REMOVE tail to remain first indices still valid, start at next index, 
                edgesCopy.RemoveRange(indexOfTo+1,edgesCopy.Count-indexOfTo-1);
           
            // REMOVE front part
            edgesCopy.RemoveRange(0,indexOfFrom);

            return new Stage(edgesCopy);
        }

        /// <summary>
        /// Function randomizeTimetable stage off a train line, only between stations off and to.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="off"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Stage generateStage(TrainLine line, TrainStation from, TrainStation to)
        {
            List<Edge> edges = FloydWarshallUtil.createEdges(line);

            return generateStage(edges, from, to);
            // with null checking
            //return generateStage(edges);
        }

        

        /// <summary>
        /// Function finds and return index of edge fromStation in list of edges.
        /// </summary>
        /// <param name="stops"></param>
        /// <param name="station"></param>
        /// <returns></returns>
        private static int findFromStation(List<Edge> edges, TrainStation fromStation)
        {
            int index = -1;

            for (int i = 0; i < edges.Count; i++)
            {
                // if station of stops equals the id of finding station
                if (edges[i].FromStation.Id.Equals(fromStation.Id)) 
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Function finds and return index of edge with toStation in list of edges.
        /// </summary>
        /// <param name="stops"></param>
        /// <param name="station"></param>
        /// <returns></returns>
        private static int findToStation(List<Edge> edges, TrainStation toStation)
        {
            int index = -1;

            for (int i = 0; i < edges.Count; i++)
            {
                // if station of stops equals the id of finding station
                if (edges[i].ToStation.Id.Equals(toStation.Id))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Function randomizeTimetable and return instance of Stage according list of edges.
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static Stage generateStage(List<Edge> edges)
        {
            // if invalid list
            if (edges == null ) return null;
            // if empty list
            if (edges.Count.Equals(0)) return null;

            // createConstraintSet new stage with first station and last station
            return new Stage(edges);
        }

        //-----------------------------------------------------
        // Methods generating NEXT TRANSFER STAGES
        //-----------------------------------------------------

        /// <summary>
        /// Function finds and returns a list of stages generated off previous stage.
        /// Finds all next transfers stages.
        /// </summary>
        /// <param name="previousStage"></param>
        /// <returns></returns>
        public static List<Stage> findNextTransferStages(Stage previousStage)
        {
            List<Stage> stages = new List<Stage>();
            // retreive all available trainLine1 passing trough toStation of previousStage
            List<TrainLine> availableTrainLines = previousStage.ToStation.getTrainLines();

            // loop over all available trainLines
            foreach(TrainLine line in availableTrainLines)
            {
                // find all available possible changing station on trainLine1
                List<TrainStation> changingStations = findChangingStationOnTrainLine(line);
                // loop over all changing station
                foreach(TrainStation to in changingStations)
                {
                    // if next possible toStation is the same as the fromStation of previousStage
                    // we would go the same path as we arrived
                    if (to.Id.Equals(previousStage.FromStation.Id)) continue;
                    // randomizeTimetable stage on line between stations off and to                    
                    Stage stage = generateStage(line, previousStage.ToStation, to);
                    // if exists
                    if(stage != null)
                        // addConstraint to stages
                        stages.Add(stage);
                }
            }

            return stages;
        }

        /// <summary>
        /// Function finds and returns a list of stages generated off first station.
        /// Finds all next transfers stages.
        /// </summary>
        /// <param name="off"></param>
        /// <returns></returns>
        public static List<Stage> findNextTransferStages(TrainStation from) 
        {
            List<Stage> stages = new List<Stage>();
            // retreive all available trainLine1 passing trough toStation of previousStage
            List<TrainLine> availableTrainLines = from.getTrainLines();

            // loop over all available trainLines
            foreach (TrainLine line in availableTrainLines)
            {
                // find all available possible changing station on trainLine1
                List<TrainStation> changingStations = findChangingStationOnTrainLine(line);
                // loop over all changing station
                foreach (TrainStation to in changingStations)
                {
                    // randomizeTimetable stage on line between stations off and to                    
                    Stage stage = generateStage(line, from, to);
                    // if exists
                    if (stage != null)
                        // addConstraint to stages
                        stages.Add(stage);
                }
            }
            return stages;
        }

        /// <summary>
        /// Function finds and returns all changing stations on trainLine1.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static List<TrainStation> findChangingStationOnTrainLine(TrainLine line)
        {

            List<TrainStation> changingStation = new List<TrainStation>();

            foreach (TrainStop stop in line.getTrainStops()) 
            {
                // if train station of stop is has at least one transfer is a changing station
                if (stop.TrainStation.Transfers.Count > 0)
                    // is determine as a changing station
                    changingStation.Add(stop.TrainStation);
            }

            return changingStation;    
        }

        //-----------------------------------------------------
        // Method generating NEXT FINAL STAGES
        //-----------------------------------------------------

        /// <summary>
        /// Function finds and returns a list of final stage
        /// generated off previous stage and toStation.
        /// </summary>
        /// <param name="previousStage"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static List<Stage> findNextFinalStages(TrainStation from, TrainStation to)
        {
            List<Stage> stages = new List<Stage>();
            // retreive all available trainLine1 passing trough toStation of previousStage
            List<TrainLine> availableTrainLines = from.getTrainLines();

            // loop over all available trainLines
            foreach (TrainLine line in availableTrainLines)
            {
                Stage stage = generateStage(line, from, to);

                // if exists
                if (stage != null)
                    // addConstraint to stages
                    stages.Add(stage);
            }
            return stages;
        }

        //-----------------------------------------------------
        // Method generating ALL AVAILABLE STAGES
        //-----------------------------------------------------

        /// <summary>
        /// Function finds and returns a list of stages generated off first station.
        /// Finds all available transfers stages and available final stage.
        /// </summary>
        /// <param name="off"></param>
        /// <param name="toStation"></param>
        /// <returns></returns>
        public static List<Stage> findAvailableStages(TrainStation fromStation, TrainStation toStation)
        {
            List<Stage> availableStages = new List<Stage>();

            // find all stages from start station to all possible changing stations
            availableStages.AddRange(findNextTransferStages(fromStation));

            // if toStation is also transfer station, is already included, if not find for the posibiliy of direct stage 
            if (toStation.Transfers.Count == 0)
            {
                availableStages.AddRange(findNextFinalStages(fromStation, toStation));
            }
            return availableStages;
        }

        /// <summary>
        /// Function finds and returns a list of stages generated off previousStage.
        /// Finds all available transfers stages and available final stage.
        /// </summary>
        /// <param name="previousStage"></param>
        /// <param name="toStation"></param>
        /// <returns></returns>
        public static List<Stage> findAvailableStages(Stage previousStage, TrainStation toStation)
        {
            List<Stage> availableStages = new List<Stage>();

            // find all next available transfers stages
            availableStages.AddRange(findNextTransferStages(previousStage));

            // if toStation is also transfer station, is already included, if not find for the posibiliy of direct stage 
            if (toStation.Transfers.Count == 0)
            {
                availableStages.AddRange(findNextFinalStages(previousStage.ToStation, toStation));
            }
/*            // try to find the final stage
            Stage finalStage = findNextFinalStage(previousStage.ToStation, toStation);
            // if finalStage exits
            if (finalStage != null)
                // addConstraint it 
                availableStages.Add(finalStage);
 */
            return availableStages;
        }
    }
}
