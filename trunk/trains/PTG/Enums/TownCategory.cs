using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Enum to specify town categories related to inhabitation.
    /// </summary>
    public enum TownCategory
    {
        /// <summary>
        /// Village.
        /// </summary>
        small = 1000,
        /// <summary>
        /// Town.
        /// </summary>
        medium = 5000,
        /// <summary>
        /// City.
        /// </summary>
        big = 20000,
        /// <summary>
        /// Big City.
        /// </summary>
        large = 50000, 

    }

    /// <summary>
    /// Implements utility methods for enum Town Category.
    /// </summary>
    public static class TownCategoryUtil
    {
        /// <summary>
        /// Calculates the town category according the inhabitation.
        /// </summary>
        /// <param name="inhabitation">The inhabitation.</param>
        /// <returns></returns>
        public static TownCategory calculateCategory(int inhabitation)
        {
            TownCategory category = TownCategory.small;

            TownCategory[] enums;            
            enums = (TownCategory[]) Enum.GetValues(typeof(TownCategory));
            foreach (TownCategory cat in enums)
            {
                if (inhabitation > (int)cat)
                    category = cat;
                else
                    break;
            }

            return category;
        }

        /// <summary>
        /// Calculates the inhabitation according the town category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public static int calculateInhabitation(TownCategory category) 
        {
            return (int)category;
        }

    }
}
