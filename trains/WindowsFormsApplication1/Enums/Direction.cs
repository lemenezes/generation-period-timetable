using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public enum Direction
    {
        /// <summary>
        /// v smere zadanej linky
        /// </summary>
        Forward = 1,
        /// <summary>
        /// v opacnom smere
        /// </summary>
        Back = 2,
    }

    public static class DirectionUtil
    {
        public const String FORWARD = "Forward";
        public const String BACK = "Back";

        public static Direction getDirection(String direction) 
        {
            Direction newDirection;
            if (FORWARD.Equals(direction))
                newDirection = Direction.Forward;
            else if (BACK.Equals(direction))
                newDirection = Direction.Back;
            else
                newDirection = Direction.Forward;

            return newDirection;
        }
    }

}
