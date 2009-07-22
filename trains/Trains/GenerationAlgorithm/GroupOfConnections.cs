using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public class GroupOfConnections
    {
        private List<TrainConnection> connections;

        public GroupOfConnections(List<TrainConnection> connections_)
        {
            connections = connections_;
        }

        public List<TrainLine> LinesOfConnection
        {
            get
            {
                if (connections.Count.Equals(0))
                {
                    return new List<TrainLine>();
                }
                else 
                {
                    return connections[0].getLinesOfConnection();
                }
            }
            set
            {
            }
        }

        public String LinesOfConnectionString
        {
            get
            {
                if (connections.Count.Equals(0))
                {
                    return "";
                }
                else 
                {
                    return connections[0].LinesOfConnection;
                }
            }
            set
            {
            }
        }

        public List<TrainStation> ChangingStations
        {
            get
            {
                if (connections.Count.Equals(0))
                {
                    return new List<TrainStation>();
                }
                else 
                {
                    return connections[0].getChangingStation();
                }
            }
            set
            {
            }
        }

        public String ChangingStationsString
        {
            get
            {
                if (connections.Count.Equals(0))
                {
                    return "";
                }
                else 
                {
                    return connections[0].ChangingStation;
                }
            }
            set
            {
            }
        }

        public int Passengers
        {
            get
            {
                return calculatePassengers();
            }
            set
            {
            }
        }

        public List<TrainConnection> getConnections()
        {
            return connections;
        }

        public int calculatePassengers()
        {
            int totalPassengers = 0;
            foreach (TrainConnection connection in connections)
            {
                totalPassengers += connection.Passengers;
            }

            return totalPassengers;
        }
    }
}
