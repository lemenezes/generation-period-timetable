using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using PeriodicTimetableGeneration.DataRepresentation;

namespace PeriodicTimetableGeneration
{



    /// <summary>
    /// Class represents a Train Station.
    /// </summary>
    public class TrainStation
    {
        #region Private Fields

        /// <summary>
        /// Default minimal time for Transfer on the Station.
        /// </summary>
        private static Time MINIMAL_TRANSFER_TIME_DEFAULT = new Time(0,5);
        /// <summary>
        /// Id of station.
        /// </summary>
        private int id;
        /// <summary>
        /// The name of station.
        /// </summary>
        private String stationName;
        /// <summary>
        /// Train Lines passing this train station.
        /// </summary>
        private List<TrainLine> trainLines;
        /// <summary>
        /// Track, which the station belongs to (not used).
        /// </summary>
        private int track;
        /// <summary>
        /// Town category related to amount of passengers.
        /// </summary>
        private TownCategory townCategory;
        /// <summary>
        /// Amount of passengers falling on station.
        /// </summary>
        private int inhabitation;
        /// <summary>
        /// The name of Town.
        /// </summary>
        private String town;
        /// <summary>
        /// The minimum time for transfers from train to train.
        /// </summary>
        private Time minimalTransferTime;
        private List<Transfer> transfers;

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainStation"/> class.
        /// </summary>
        public TrainStation() 
        {
            setDefaultValues();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainStation"/> class.
        /// </summary>
        /// <param name="id_">The id.</param>
        /// <param name="name_">The name.</param>
        public TrainStation(int id_, string name_)
        {
            setDefaultValues();
            id = id_;
            stationName = name_;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="station">The station.</param>
        public TrainStation(TrainStation station)
        {
            this.id = station.id;
            this.stationName = station.stationName;
            this.inhabitation = station.inhabitation;
            this.townCategory = station.townCategory;
            this.track = station.track;
            this.trainLines = station.trainLines;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the default values for variables.
        /// </summary>
        private void setDefaultValues()
        {
            id = -1;
            stationName = "";
            trainLines = new List<TrainLine>();
            track = -1;
            minimalTransferTime = MINIMAL_TRANSFER_TIME_DEFAULT;
            townCategory = TownCategory.medium;
            updateInhabitation();
            updateMinimalTransferTime();

            transfers = new List<Transfer>();
        }

        #endregion


        #region Properties

        public List<Transfer> Transfers 
        {
            get 
            {
                return transfers;
            }
            set 
            {
                transfers = value;
            }
        }

        /// <summary>
        /// Gets or sets the station's id.
        /// </summary>
        /// <value>The station's id.</value>
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Gets or sets the station's name.
        /// </summary>
        /// <value>The station's name.</value>
        public String Name
        {
            get
            {
                return stationName;
            }
            set
            {
                stationName = value;
            }
        }

        /// <summary>
        /// Gets or sets the town category.
        /// </summary>
        /// <value>The town category.</value>
        public TownCategory TownCategory
        {
            get
            {
                return townCategory;
            }
            set
            {
                townCategory = value;
            }
        }

        /// <summary>
        /// Gets or sets inhabitation.
        /// </summary>
        /// <value>The inhabitation.</value>
        public int Inhabitation
        {
            get
            {
                return inhabitation;
            }
            set
            {
                inhabitation = value;
            }
        }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
        /// <value>The town.</value>
        public String Town
        {
            get
            {
                return this.town;
            }
            set
            {
                this.town = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimal transfers time.
        /// </summary>
        /// <value>The minimal transfers time.</value>
        public Time MinimalTransferTime
        {
            get
            {
                return minimalTransferTime;
            }
            set
            {
                minimalTransferTime = value;
            }
        }



        #endregion

        #region Get Set Add Methods

        /// <summary>
        /// Gets the train lines.
        /// </summary>
        /// <returns>Train Lines.</returns>
        public List<TrainLine> getTrainLines()
        {
            return trainLines;
        }

        /// <summary>
        /// Gets the track.
        /// </summary>
        /// <returns>The number of track.</returns>
        public int getTrack()
        {
            return track;
        }

        /// <summary>
        /// Adds the train line, which passing the station.
        /// </summary>
        /// <param name="line">The line.</param>
        public void addTrainLine(TrainLine line)
        {
            trainLines.Add(line);
        }

        /// <summary>
        /// Sets the number of track.
        /// </summary>
        /// <param name="track_">The track's number.</param>
        public void setTrack(int track_)
        {
            track = track_;
        }

        /// <summary>
        /// Sets the station's id.
        /// </summary>
        /// <param name="idStation">The id station.</param>
        public void setId(int idStation)
        {
            id = idStation;
        }

        /// <summary>
        /// Gets the station's id.
        /// </summary>
        /// <returns>The id station.</returns>
        public int getId()
        {
            return id;
        }

        /// <summary>
        /// Gets the station's name.
        /// </summary>
        /// <returns>The station's name.</returns>
        public String getName()
        {
            return stationName;
        }

        /// <summary>
        /// Sets the station's name.
        /// </summary>
        /// <param name="name">The station's name.</param>
        public void setName(String name)
        {
            stationName = name;
        }


        /// <summary>
        /// Sets the train lines, which are passing the station.
        /// </summary>
        /// <param name="lines">The train lines.</param>
        public void setTrainLines(List<TrainLine> lines)
        {
            trainLines = lines;
        }

        /// <summary>
        /// Gets the inhabitation.
        /// </summary>
        /// <returns>The amount of inhabitation</returns>
        public int getInhabitation()
        {
            return inhabitation;
        }

        /// <summary>
        /// Sets the inhabitation.
        /// </summary>
        /// <param name="inhabitation_">The amount of inhabitation.</param>
        public void setInhabitation(int inhabitation_)
        {
            inhabitation = inhabitation_;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines whether the station contains specified line (line's number).
        /// </summary>
        /// <param name="lineNumber">The line's number.</param>
        /// <returns>
        /// 	<c>true</c> if the station contains line; otherwise, <c>false</c>.
        /// </returns>
        public Boolean containsLine(int lineNumber)
        {
            Boolean contain = false;

            foreach (TrainLine line in trainLines) 
            {
                // if train station contain train line_, if line_ passes through station
                if (lineNumber.Equals(line.LineNumber))
                {
                    // set the value, station contains line_
                    contain = true;
                    // quit the loop foreach
                    break;
                }
            }

            return contain;
        }

        /// <summary>
        /// Updates the town category according the inhabitation value.
        /// </summary>
        public void updateTownCategory()
        {
            townCategory = TownCategoryUtil.calculateCategory(inhabitation);
        }

        /// <summary>
        /// Updates the inhabitation according the town category.
        /// </summary>
        public void updateInhabitation()
        {
            inhabitation = TownCategoryUtil.calculateInhabitation(townCategory);
        }


        /// <summary>
        /// Updates the minimal transfer time according the town category
        /// </summary>
        public void updateMinimalTransferTime() 
        {
            minimalTransferTime = MinimalTransferTimeUtil.calculateTime(townCategory);
        }

        #endregion


    }
}
