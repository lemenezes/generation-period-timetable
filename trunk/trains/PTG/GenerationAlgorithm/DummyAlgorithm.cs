using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeriodicTimetableGeneration.Interfaces;
using System.ComponentModel;

namespace PeriodicTimetableGeneration.GenerationAlgorithm
{
    /// <summary>
    /// Dummy instance of IGenerationAlgorithm for purpose of evaluation.
    /// </summary>
    class DummyAlgorithm : IGenerationAlgorithm
    {

        #region Private Fields

        /// <summary>
        /// Orignal Timetable instance.
        /// </summary>
        private Timetable originalTimetable;

        /// <summary>
        /// List of timetable, implemented in the same ways othen generation algorithm.
        /// </summary>
        private List<Timetable> timetables;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyAlgorithm"/> class.
        /// </summary>
        /// <param name="originalTimetable">The original timetable.</param>
        public DummyAlgorithm(Timetable originalTimetable)
        {
            setDefaultValues();
            this.originalTimetable = originalTimetable;
        }

        #endregion



        #region IGenerationAlgorithm Members

        /// <summary>
        /// Generates the timetables. But in fact just only evaluate the original timetable.
        /// </summary>
        /// <param name="number">The number.</param>
        public void generateTimetables(int number)
        {
            this.Timetables.Clear();
            this.originalTimetable.calculateRatingValue();
            LogUtil.printTimetableTransfersEvaluation(originalTimetable, FinalInput.getInstance().getCacheContent());
            this.Timetables.Add(this.originalTimetable);
        }

        /// <summary>
        /// Finds the timetable on select id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Timetable findTimetableOnSelect(int id)
        {
            return TimetableUtil.findTimetableOnSelect(this.timetables, id);
        }

        /// <summary>
        /// Determines whether the timetable exist.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool doesTimetableExist(int id)
        {
            return TimetableUtil.doesTimetableExist(this.timetables, id);
        }

        /// <summary>
        /// Occurs when [on progress changed].
        /// </summary>
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;

        /// <summary>
        /// Gets or sets a value indicating whether this generation is cancelled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this generation is cancelled; otherwise, <c>false</c>.
        /// </value>
        public bool IsCancelled
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets the timetables.
        /// </summary>
        /// <value>The timetables.</value>
        public List<Timetable> Timetables
        {
            get
            {
                return this.timetables;
            }
        }

        /// <summary>
        /// Gets or sets the train lines.
        /// </summary>
        /// <value>The train lines.</value>
        public List<TrainLine> TrainLines
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the train stations.
        /// </summary>
        /// <value>The train stations.</value>
        public List<TrainStation> TrainStations
        {
            get;
            set;
        }

        #endregion


        #region Private Methods        

        /// <summary>
        /// Sets the default values.
        /// </summary>
        private void setDefaultValues()
        {
            this.timetables = new List<Timetable>();
            this.TrainLines = TrainLineCache.getInstance().getCacheContent();
            this.TrainStations = TrainStationCache.getInstance().getCacheContent();
        }

        #endregion
    }
}
