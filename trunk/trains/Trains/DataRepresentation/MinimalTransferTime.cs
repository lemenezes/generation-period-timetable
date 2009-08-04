using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeriodicTimetableGeneration.DataRepresentation
{
    public enum MinimalTransferTime
    {
        /// <summary>
        /// Minimal trasfer time on village' station.
        /// </summary>
        small = 3,
        /// <summary>
        /// Minimal transfer time on town' station.
        /// </summary>
        medium = 4,
        /// <summary>
        /// Minimal transfer time on city' station.
        /// </summary>
        big = 5,
        /// <summary>
        /// Minimal transfer time on big city' station.
        /// </summary>
        large = 7,
    }

    public enum CopyOfMinimalTransferTime
    {
        /// <summary>
        /// Minimal trasfer time on village' station.
        /// </summary>
        small = 3,
        /// <summary>
        /// Minimal transfer time on town' station.
        /// </summary>
        medium = 4,
        /// <summary>
        /// Minimal transfer time on city' station.
        /// </summary>
        big = 5,
        /// <summary>
        /// Minimal transfer time on big city' station.
        /// </summary>
        large = 7,
    }

    /// <summary>
    /// Implements utility methods for enum Minimal Transfer Time.
    /// </summary>
    public static class MinimalTransferTimeUtil 
    {
        /// <summary>
        /// Calculates the time according town category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public static Time calculateTime(TownCategory category) 
        {
            int minutes = 5;
            String nameCategory = Enum.GetName(typeof(TownCategory), category);

            // map Minimal Transfer Time into two arrays (string and value array)
            String[] namesMTT = Enum.GetNames(typeof(MinimalTransferTime));
            MinimalTransferTime[] arrayMTT = (MinimalTransferTime[]) Enum.GetValues(typeof(MinimalTransferTime));

            // find index according the name of item
            int index = find(namesMTT, nameCategory);
            
            if(index != -1)
            {
                // retreive value according the index
                MinimalTransferTime mtt = (MinimalTransferTime) arrayMTT.GetValue(index);
                minutes = (int) mtt;                
            }
            //int minutes = (int) mtt;
            return Time.ToTime(minutes);            
        }

        /// <summary>
        /// Finds the specified name in String[].
        /// </summary>
        /// <param name="names">The names.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private static int find(String[] names, String name) 
        {
            int index = -1;
            int i = 0;
            foreach (String n in names) 
            {
                if (n.Equals(name))
                {
                    index = i;
                    break;
                }
                i++;
            }

            return index;
        }
    }

}
