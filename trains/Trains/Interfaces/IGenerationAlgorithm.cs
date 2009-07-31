using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PeriodicTimetableGeneration.Interfaces
{

    /// <summary>
    /// Interface for generation algorithms.
    /// </summary>
    public interface IGenerationAlgorithm
    {
        #region Methods

        /// <summary>
        /// Generates the timetables.
        /// The number determine an amount of timetables.
        /// </summary>
        /// <param name="number">The number.</param>
        void generateTimetables(int number);

        /// <summary>
        /// Finds the timetable on select.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        Timetable findTimetableOnSelect(int id);

        /// <summary>
        /// Doeses the timetable exist.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        Boolean doesTimetableExist(int id);

        #endregion


        #region Events

        /// <summary>
        /// Occurs when [on progress changed].
        /// </summary>
        event EventHandler<ProgressChangedEventArgs> OnProgressChanged;

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this generation is cancelled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this generation is cancelled; otherwise, <c>false</c>.
        /// </value>
        bool IsCancelled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the timetables.
        /// </summary>
        /// <value>The timetables.</value>
        List<Timetable> Timetables
        {
            get;
        }

        /// <summary>
        /// Gets or sets the train lines.
        /// </summary>
        /// <value>The train lines.</value>
        List<TrainLine> TrainLines
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the train stations.
        /// </summary>
        /// <value>The train stations.</value>
        List<TrainStation> TrainStations
        {
            get;
            set;
        }

        #endregion


    }

}
