using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeriodicTimetableGeneration.GenerationAlgorithm
{
    /// <summary>
    /// Class represents and implements utility methods for timetable.
    /// </summary>
    public static class TimetableUtil
    {

        /// <summary>
        /// Determine whether the timetable exixts in specfied timetables.
        /// </summary>
        /// <param name="timetables">The timetables.</param>
        /// <param name="id">The id.</param>
        /// <returns>True if timetable exists, otherwise false.</returns>
        public static Boolean doesTimetableExist(List<Timetable> timetables, int id)
        {
            Boolean exists = false;
            if (findTimetableOnSelect(timetables, id) != null)
            {
                exists = true;
            }
            return exists;
        }

        /// <summary>
        /// Finds the timetable on selected id.
        /// </summary>
        /// <param name="timetables">The timetables.</param>
        /// <param name="id">The id.</param>
        /// <returns>The timetable.</returns>
        public static Timetable findTimetableOnSelect(List<Timetable> timetables, int id)
        {
            Timetable tt = null;

            foreach (Timetable timetable in timetables)
            {
                if (timetable.ID.Equals(id))
                {
                    tt = timetable;
                    break;
                }
            }
            return tt;
        }

        /// <summary>
        /// Constructs the original timetable.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <returns></returns>
        public static Timetable constructOriginalTimetable(List<TrainLine> lines) 
        {
            Timetable timetable = new Timetable(1, lines);

            foreach(TrainLineVariable varLine in timetable.TrainLines)
            {
                varLine.StartTime = varLine.Line.ConnectedLineShift;
            }

            return timetable;
        }

    }
}
