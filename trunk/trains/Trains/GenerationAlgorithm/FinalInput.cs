using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public class FinalInput
    {
        List<GroupOfConnections> cacheContent;

        public FinalInput() 
        {

            //groupsOfConnections = new List<GroupOfConnections>();
            createGroupsOfConnection();
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
        public List<GroupOfConnections> getCacheContent()
        {
            return cacheContent;
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
            cacheContent = groupsList;
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

        public GroupOfConnections getContentOnSelect(String contentKey)
        {
            return findGroup(cacheContent, contentKey);
        }


    }
}
