using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public enum TypeOfTrain
    {
        /// <summary>
        /// SuperCity
        /// </summary>
        SC = 1,
        /// <summary>
        /// EuroCity
        /// </summary>
        EC = 2,
        /// <summary>
        /// InterCity
        /// </summary>
        IC = 3,
        /// <summary>
        /// EuroNight
        /// </summary>
        EN = 4,
        /// <summary>
        /// Expres
        /// </summary>
        Ex = 5,
        /// <summary>
        /// Rychlik
        /// </summary>
        R = 6,
        /// <summary>
        /// Spesny vlak
        /// </summary>
        Sp = 7,
        /// <summary>
        /// Osobni vlak
        /// </summary>
        Os = 8,
    }

    public static class TypeOfTrainUtil
    {
        public const String SC = "SC", EC = "EC", IC = "IC", EN = "EN";
        public const String Ex = "Sp", R = "R", Sp = "Sp", Os = "Os";

        public static TypeOfTrain getTypeOfTrain(String type)
        {
            
            TypeOfTrain newType;
            if (type.Equals(EC))
                newType = TypeOfTrain.EC;
            else if (IC.Equals(type))
                newType = TypeOfTrain.IC;
            else if (EN.Equals(type))
                newType = TypeOfTrain.EN;
            else if (Ex.Equals(type))
                newType = TypeOfTrain.Ex;
            else if (Os.Equals(type))
                newType = TypeOfTrain.Os;
            else if (R.Equals(type))
                newType = TypeOfTrain.R;
            else if (SC.Equals(type))
                newType = TypeOfTrain.SC;
            else if (Sp.Equals(type))
                newType = TypeOfTrain.Sp;
            else
                newType = TypeOfTrain.Os;

            return newType;
        }

    }



}
