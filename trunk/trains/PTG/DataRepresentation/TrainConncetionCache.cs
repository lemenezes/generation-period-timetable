using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public class TrainConnectionCache
    {

        private List<TrainConnection> trainConnections;

        /// <summary>
        /// Singleton class implemented as a holder for class TrainConncetionCache
        /// </summary>
        private static class SingletonHolder 
        {
            static SingletonHolder() { }

            internal static readonly TrainConnectionCache INSTANCE = new TrainConnectionCache();
        }

        public static TrainConnectionCache getInstance()
        {
            return SingletonHolder.INSTANCE;
        }


        public void addTrainConnection(TrainConnection connection)
        {
            throw new System.NotImplementedException();
        }

        public Boolean doesConnectionExist(TrainStation from, TrainStation to)
        {
            throw new System.NotImplementedException();
        }

        public TrainConnection getCacheContent()
        {
            throw new System.NotImplementedException();
        }

        public TrainConnection getCacheContentOnFromTo(TrainStation from, string to)
        {
            throw new System.NotImplementedException();
        }


        public void setCacheContent(List<TrainConnection> connections)
        {
            throw new System.NotImplementedException();
        }

        public TrainConnectionCache()
        {
            throw new System.NotImplementedException();
        }

        private TrainConnection findConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
