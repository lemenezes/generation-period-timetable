﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PeriodicTimetableGeneration
{
    public class Timetable
    {
        #region Private Fields

        
        //private Queue<TrainLineVariable> stableLines;

        /// <summary>
        /// List of train lines with specific start time.
        /// </summary>
        private List<TrainLineVariable> variableLines;
        /// <summary>
        /// Rating value of minimization factor of this timetable.
        /// </summary>
        private int ratingValue;
        /// <summary>
        /// Id of timetable.
        /// </summary>
        private int id;
        /// <summary>
        /// The number of progressive changes, which has been made to improve this timetable.
        /// </summary>
        private int progressiveChanges;
        /// <summary>
        /// The note about this timetable.
        /// </summary>
        private String note;
        /// <summary>
        /// Total time of generation this timetable.
        /// </summary>
        private TimeSpan generationTime;
        /// <summary>
        /// Instance of class Random, used for randomizing start time of lines.
        /// </summary>
        public static Random random = new Random();


        #endregion

        

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Timetable"/> class.
        /// </summary>
        public Timetable()
        {
            setDefaultValues();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Timetable"/> class.
        /// </summary>
        /// <param name="id_">The id.</param>
        /// <param name="lines">The lines.</param>
        public Timetable(int id_, List<TrainLine> lines)
        {
            // set default values for variables
            setDefaultValues();
            // set id
            id = id_;
            // createConstraintSet new list of variable lines
            List<TrainLineVariable> varLines = new List<TrainLineVariable>();

            // loop over all lines
            foreach (TrainLine line in lines)
            {
                // createConstraintSet varibleLine for part
                varLines.Add(new TrainLineVariable(line));
            }

            // update ConnectedTrainLineVariables for each line of equivalent group
            updateConnectedTrainLineVariables(varLines);


            variableLines = varLines;
        }

        /// <summary>
        /// Updates the connected train line variables.
        /// </summary>
        /// <param name="varLines">The variable lines.</param>
        private void updateConnectedTrainLineVariables(List<TrainLineVariable> varLines)
        {
            // loop over all varLines
            foreach (TrainLineVariable varLine in varLines)
            {
                // update (set) relative shift within equivalent group
                updateConnectedLineShift(varLine);
                
                // loop over all connected line for line related with varLine
                foreach (TrainLine line in varLine.Line.getConnectedLines()) 
                {
                    // update the connections
                    if (line.LineNumber < varLine.LineNumber)
                    {
                        // find appropriate varLine
                        TrainLineVariable connectedVariableLine = findVariableLine(varLines, line.LineNumber);

                        // add this var line into list of related var line
                        connectedVariableLine.ConnectedLinesVariable.Add(varLine);
                        varLine.ConnectedLinesVariable.Add(connectedVariableLine);
                    }
                }
            }
        }

        private void updateConnectedLineShift(TrainLineVariable varLine)
        {
            // create choosen time window
            Time timeWindowLowerBound = new Time(TimeWindowLowerBoundHour, 0);

            // calculate in minutes

            // normalize with respect to the choosen window
            int shift = varLine.Line.OriginalDeparture.ToMinutes() - timeWindowLowerBound.ToMinutes();

            // move it into that window 
            while (shift < 0)
                shift += (int) varLine.Period;
            while (shift >= (int)varLine.Period) 
                shift -= (int) varLine.Period;

            // store the relative
            varLine.Line.ConnectedLineShift = Time.ToTime(shift);
        }

        /// <summary>
        /// Gets the time window lower bound representing hour.
        /// </summary>
        /// <value>The time window lower bound hour.</value>
        public int TimeWindowLowerBoundHour 
        {

            // BUNO
            get 
            {
                return 12;
            }
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the generation time.
        /// </summary>
        /// <value>The generation time.</value>
        public TimeSpan GenerationTime 
        {
            get
            {
                return generationTime;
            }
            set
            {
                generationTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public int ID
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
        /// Gets or sets the progressive changes.
        /// </summary>
        /// <value>The progressive changes.</value>
        public int ProgressiveChanges
        {
            get
            {
                return progressiveChanges;
            }
            set
            {
                progressiveChanges = value;
            }
        }

        /// <summary>
        /// Gets or sets the rating value.
        /// </summary>
        /// <value>The rating value.</value>
        public int RatingValue
        {
            get
            {
                return ratingValue;
            }
            set
            {
                ratingValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the train lines.
        /// </summary>
        /// <value>The train lines.</value>
        public List<TrainLineVariable> TrainLines
        {
            get
            {
                return variableLines;
            }
        }

        /// <summary>
        /// Gets or sets the note for this timetable.
        /// </summary>
        /// <value>The note.</value>
        public String Note 
        {
            get 
            {
                return note;
            }
            set 
            {
                note = value;
            }
        }

        #endregion

        #region Get Set Add Methods

        /// <summary>
        /// Adds the variable line.
        /// </summary>
        /// <param name="line">The variable train line.</param>
        public void addVariableLine(TrainLineVariable line)
        {
            if (!doesVariableLineExist(variableLines, line.LineNumber))
            {
                variableLines.Add(line);
            }
        }

        /// <summary>
        /// Sets the variable lines.
        /// </summary>
        /// <param name="lines">The variable train lines.</param>
        public void setVariableLines(List<TrainLineVariable> lines)
        {
            variableLines = lines;
        }

        /// <summary>
        /// Gets the variable lines.
        /// </summary>
        /// <returns>The list of variable train lines.</returns>
        public List<TrainLineVariable> getVariableLines()
        {
            return variableLines;
        }

        //public void addStableLine(TrainLineVariable line)
        //{
        //    if (!stableLines.Contains(line))
        //    {
        //        stableLines.Enqueue(line);
        //    }

        //    //if (!doesVariableLineExist(stableLines, line.LineNumber)) 
        //    //{
        //    //    stableLines.Enqueue(line);               
        //    //}
        //}

        //public void setStableLines(Queue<TrainLineVariable> lines)
        //{
        //    this.stableLines = lines;
        //}

        //public void clearStableLines()
        //{
        //    stableLines.Clear();
        //}


        //public Queue<TrainLineVariable> getStableLines()
        //{
        //    return stableLines;
        //}

        #endregion



        #region Public Methods

        //public List<TrainLineVariable> findFixedLines()
        //{

        //    List<TrainLineVariable> fixedLines = new List<TrainLineVariable>();
        //    // loop over all lines
        //    foreach(TrainLineVariable line in variableLines)
        //    {
        //        if (line.isFixed()) 
        //        {
        //            fixedLines.Add(line);
        //        }
        //    }

        //    return fixedLines;
        //}



        /// <summary>
        /// Gets the variable line on select.
        /// </summary>
        /// <param name="lineNumber">The line number.</param>
        /// <returns>The variable train line.</returns>
        public TrainLineVariable getVariableLineOnSelect(int lineNumber) 
        {
            return findVariableLine(variableLines, lineNumber);
        }

        /// <summary>
        /// Finds the variable line from specified lines.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <returns>The variable train line.</returns>
        public static TrainLineVariable findVariableLine(List<TrainLineVariable> lines, int lineNumber)
        {
            TrainLineVariable wantedLine = null;
            // loop over all lines
            foreach (TrainLineVariable line in lines)
            {
                // if lines' number are equal
                if (line.LineNumber.Equals(lineNumber))
                {
                    // we found the line
                    wantedLine = line;
                    // and escape the loop
                    break;
                }
            }
            return wantedLine;
        }

        /// <summary>
        /// Determines whether the variable line exists within specified lines.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <returns>True if lines contains line, otherwise false.</returns>
        public static Boolean doesVariableLineExist(List<TrainLineVariable> lines, int lineNumber) 
        {
            Boolean exists = true;
            if (findVariableLine(lines, lineNumber) == null)
            {
                exists = false;
            }
            return exists;
        }

        /// <summary>
        /// Randomizes the timetable.
        /// Set random strat time for all train lines of timetable.
        /// </summary>
        public void randomizeTimetable()
        {
            DateTime now = DateTime.Now;
            // output for controlling random numbers
            //FileStream fs = new FileStream("randomNumbers" + now.Month + now.Day + now.Hour + now.Minute + ".tmp", FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);


            foreach (TrainLineVariable line in variableLines) 
            {
                int randomInt = random.Next(0, (int)line.Period);
                Time time = Time.ToTime(randomInt);

                line.StartTime = time;

                // controll information
              //  sw.WriteLine(String.Format("{0,8}", time));
            }

            //sw.Close();
            //fs.Close();
        }


        #endregion


        #region Calculation Methods

        /// <summary>
        /// Calculates the timetable rating value.
        /// </summary>
        /// <param name="tt">The timetable.</param>
        /// <returns>The rating value.</returns>
        public static int calculateTimetableRatingValue(Timetable tt)
        {
            int ratingValue = 0;

            List<Transfer> transfers = FinalInput.getInstance().getCacheContent();

            foreach (Transfer transfer in transfers)
            {
                int value = calculateTransfer(tt, transfer);
                ratingValue += value;

            }

            return ratingValue;
        }


        /// <summary>
        /// Calculates the transfer.
        /// </summary>
        /// <param name="timetable">The timetable.</param>
        /// <param name="transfer">The transfer.</param>
        /// <returns></returns>
        public static int calculateTransfer(Timetable timetable, Transfer transfer)
        {
            // result rating value
            int ratingValue;

            TrainLineVariable onLine = timetable.getVariableLineOnSelect(transfer.OnLine.LineNumber);
            TrainLineVariable offLine = timetable.getVariableLineOnSelect(transfer.OffLine.LineNumber);

            // varline startime, departure from start of line, connected line shif of line
            Time arrivalTime = offLine.StartTime + offLine.arrivalToStopAtIndex(transfer.TrainStopIndexOffLine);
            Time departureTime = onLine.StartTime + onLine.departureFromStopAtIndex(transfer.TrainStopIndexOnLine);

            normalizeTransferTime(ref departureTime, ref arrivalTime, transfer.Station.MinimalTransferTime, (int)onLine.Period, (int)offLine.Period);
            ratingValue = transfer.evaluateTransferFunction(departureTime - arrivalTime);
            return ratingValue;
        }

        /// <summary>
        /// Calculates the rating value of this instance.
        /// </summary>
        public void calculateRatingValue()
        {
            ratingValue = calculateTimetableRatingValue(this);
        }

        /// <summary>
        /// Calculates the timetable progressive changes.
        /// </summary>
        /// <param name="tt">The timetable.</param>
        /// <returns>The progressive changes.</returns>
        public static int calculateTimetableProgressiveChanges(Timetable tt)
        {
            int progressiveChanges = 0;

            foreach (TrainLineVariable line in tt.TrainLines) 
            {
                progressiveChanges += line.ProgressiveChanges;
            }
            return progressiveChanges;
        }

        /// <summary>
        /// Calculates the progressive changes of this instance.
        /// </summary>
        public void calculateProgressiveChanges()
        {
            progressiveChanges = calculateTimetableProgressiveChanges(this);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the default values for fields this of instance.
        /// </summary>
        private void setDefaultValues()
        {
            id = -1;
            ratingValue = int.MaxValue;
            progressiveChanges = 0;
            variableLines = new List<TrainLineVariable>();
            note = "";
            generationTime = TimeSpan.Zero;
            //stableLines = new Queue<TrainLineVariable>();
        }

         /// <summary>
        /// Normalizes the transfer time.
        /// </summary>
        /// <param name="timeDeparture">The time departure.</param>
        /// <param name="timeArrival">The time arrival.</param>
        /// <param name="minimalTransferTime">The minimal transfer time.</param>
        /// <param name="onPeriod">The on period.</param>
        /// <param name="offPeriod">The off period.</param>
        private static void normalizeTransferTime(ref Time timeDeparture, ref Time timeArrival, Time minimalTransferTime, int onPeriod, int offPeriod)
        {
            // if departure is before arrival, we need to find closest time departure
            // that satisfied the condition(departure>arrival)
            if (timeDeparture < timeArrival + minimalTransferTime)
            {
                while (timeDeparture < timeArrival + minimalTransferTime)
                {
                    // addConstraint new period of train
                    timeDeparture += Time.ToTime(onPeriod);
                }
            }
            else
            {
                // if arrival is before departure, we need to find closest time arrival
                // that satisfied the cond(departure>arrival) but not the cond(departure>arrival+nextPeriod)
                while (timeDeparture > timeArrival + Time.ToTime(offPeriod) + minimalTransferTime)
                {
                    timeArrival += Time.ToTime(offPeriod);
                }
            }
        }

        #endregion

    }
}
