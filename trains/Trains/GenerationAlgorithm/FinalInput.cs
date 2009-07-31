using System;
using System.Collections.Generic;
using System.Text;
using PeriodicTimetableGeneration.GenerationAlgorithm;

namespace PeriodicTimetableGeneration
{
    public class FinalInput
    {
        /// <summary>
        /// List of Transfers.
        /// </summary>
        List<Transfer> cacheContent;
        /// <summary>
        /// Groups of Connections.
        /// </summary>
        private List<GroupOfConnections> groupsOfConnections;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinalInput"/> class.
        /// </summary>
        public FinalInput() 
        {
            createGroupsOfConnection();
            cacheContent = new List<Transfer>();
        }

        /*
        public FinalInput(List<TrainConnection> connections) 
        {
            createGroupsOfConnection(connections);
        }*/

        /**
         * SingletonHolder is loaded on the first execution of Singleton.getInstance() 
         * or the first access toStation SingletonHolder.INSTANCE, not before.
         */
        private static class SingletonHolder
        {
            static SingletonHolder() { }

            internal static readonly FinalInput INSTANCE = new FinalInput();
        }

        /**
         * Static instance method
         */
        public static FinalInput getInstance()
        {
            return SingletonHolder.INSTANCE;
        }

        /**
	     * Get the cache which is protected by this singleton class.
	     *
         * @return the cache.
         */
        public List<GroupOfConnections> getGroupsOfConnections()
        {
            return groupsOfConnections;
        }


        public void createGroupsOfConnection()
        {
            // createConstraintSet new groups
            List<GroupOfConnections> groupsList = new List<GroupOfConnections>();
            // parse groups
            List<List<TrainConnection>> groups = groupByListOfLines(ShortestPathAlgoritm
                .getInstance().getTrainConnections());
            // loop over all groups
            foreach (List<TrainConnection> group in groups)
            {
                // createConstraintSet instance of class group
                GroupOfConnections groupOfConnections = new GroupOfConnections(group);
                // addConstraint 
                groupsList.Add(groupOfConnections);
            }

            // initialize variable of cache
            groupsOfConnections = groupsList;
        }

        private static List<List<TrainConnection>> groupByListOfLines(List<TrainConnection> connections)
        {
            List<List<TrainConnection>> groupsOfListOfConnections = new List<List<TrainConnection>>();
            List<TrainConnection> addingGroup;

            // loop over all train connections
            foreach (TrainConnection connection in connections)
            {
                String connectionKey = connection.LinesOfConnection;
                // if the group with the same key already exists
                if (doesGroupAlreadyExist(groupsOfListOfConnections, connectionKey))
                {
                    // find the group for adding
                    addingGroup = findGroup(groupsOfListOfConnections, connectionKey);
                }
                else
                {
                    // otherwise createConstraintSet a new group
                    addingGroup = new List<TrainConnection>();
                    // addConstraint group to the results
                    groupsOfListOfConnections.Add(addingGroup);
                }
                // finally addConstraint the connection into appropriate group
                addingGroup.Add(connection);
            }

            return groupsOfListOfConnections;
        }

        private static List<TrainConnection> removeSingleConnections(List<TrainConnection> connections)
        {
            // or createConstraintSet a new instance only with a valid connections
            List<TrainConnection> newConnections = new List<TrainConnection>();

            foreach (TrainConnection connection in connections)
            {
                // if connection contains more than one line => is not a single connection
                if (connection.getLinesOfConnection().Count > 1)
                    // then addConstraint to the results
                    newConnections.Add(connection);
            }

            return newConnections;
        }

        private static Boolean doesGroupAlreadyExist(List<List<TrainConnection>> groups, String key)
        {
            return findGroup(groups, key) != null ? true : false;
        }

        private static List<TrainConnection> findGroup(List<List<TrainConnection>> groups, String key)
        {
            List<TrainConnection> wantedGroup = null;
            // loop over all groups
            foreach (List<TrainConnection> group in groups)
            {
                // if group is not empty
                if (!group.Count.Equals(0))
                {
                    // access first member
                    String keyGroup = group[0].LinesOfConnection;
                    // if key of group equals wanted key
                    if (keyGroup.Equals(key))
                    {
                        // we found a group
                        wantedGroup = group;
                        // leave the loop
                        break;
                    }
                }
            }

            return wantedGroup;
        }

        private static GroupOfConnections findGroup(List<GroupOfConnections> groups, String key) 
        {
            GroupOfConnections wantedGroup = null;
            // loop
            foreach (GroupOfConnections group in groups) 
            {

                    String keyGroup = group.LinesOfConnectionString;
                    // if key of group equals wanted key
                    if (keyGroup.Equals(key))
                    {
                        // we found a group
                        wantedGroup = group;
                        // leave the loop
                        break;
                    }
            }
            return wantedGroup;
        }

        public GroupOfConnections getGroupsOfConnectionsOnSelect(String contentKey)
        {
            return findGroup(groupsOfConnections, contentKey);
        }

        public List<Transfer> getCacheContent()
        {
            return cacheContent;
        }



        public void createTransfers()
        {
            cacheContent = TransferUtil.createTransfersForAllLines();
        }
    }
}
