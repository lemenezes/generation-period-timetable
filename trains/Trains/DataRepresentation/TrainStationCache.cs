using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public class TrainStationCache
    {
        /// <summary>
        /// Class represents a cache for Train Stations.
        /// </summary>
        private List<TrainStation> cacheContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainStationCache"/> class.
        /// A private Constructor prevents any other class from instantiating.
        /// </summary>
	    private TrainStationCache()
        {
            cacheContent = new List<TrainStation>();
        }

        /// <summary>
        /// Clears the cache content.
        /// </summary>
        public void clearContent() 
        {
            cacheContent.Clear();
        }




        /// <summary>
        /// SingletonHolder is loaded on the first execution of Singleton.getInstance() 
	    /// or the first access to SingletonHolder.INSTANCE, not before.
        /// </summary>
        private static class SingletonHolder
        {
            static SingletonHolder() { }

            internal static readonly TrainStationCache INSTANCE = new TrainStationCache();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>Instance of TrainStationCache</returns>
        public static TrainStationCache getInstance()
        {
            return SingletonHolder.INSTANCE;
        }

        /// <summary>
        /// Gets the content of the cache, which is protected by this singleton class.
        /// </summary>
        /// <returns></returns>
        public List<TrainStation> getCacheContent()
        {
            return cacheContent;
        }


        /// <summary>
        /// Gets the cache content on select.
        /// </summary>
        /// <param name="idStation">The id of station.</param>
        /// <returns>Train Station</returns>
        public TrainStation getCacheContentOnSelect(int idStation)
        {
            TrainStation station = null;
            foreach(TrainStation s in cacheContent){    //loop all stations
                if (s.Id.Equals(idStation))       //searching for the same idStation
                {
                    station = s;                        //if found, then break
                    break;
                }
            }
            return station;
        }

        /// <summary>
        /// Sets the content of the cache.
        /// </summary>
        /// <param name="trainStations">The train stations.</param>
        public void setCacheContent(List<TrainStation> trainStations) 
        {
            cacheContent = trainStations;
        }

        /// <summary>
        /// Method determines, whether the station exists in cache.
        /// </summary>
        /// <param name="name">The name of train station.</param>
        /// <returns>True or false</returns>
        public Boolean doesStationExist(String name)
        {
            if (findStation(name) != null)
                return true;
            else
                return false;            
        }

        
        /// <summary>
        /// Gets the content on name of station.
        /// </summary>
        /// <param name="stationName">The name of train station.</param>
        /// <returns></returns>
        public TrainStation getCacheContentOnName(String stationName)
        {
            return findStation(stationName);
        }

        /// <summary>
        /// Finds the station in cache.
        /// </summary>
        /// <param name="stationName">The name of train station.</param>
        /// <returns>Train station</returns>
        private TrainStation findStation(String stationName)
        {
            //set default
            TrainStation station = null;
            //loop all throughStation
            foreach (TrainStation s in cacheContent)    
            {
                //if stationName found
                if (s.Name.Equals(stationName))
                {
                    //return throughStation
                    station = s;
                    break;
                }
            }
            return station;
        }

        /// <summary>
        /// Adds the train station into cache content.
        /// </summary>
        /// <param name="trainStation">The train station.</param>
        public void addTrainStation(TrainStation trainStation)
        {
            cacheContent.Add(trainStation);
        }
    }
}
