using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PeriodicTimetableGeneration
{
    public class Timetable
    {
        private List<TrainLineVariable> variableLines;
        private int ratingValue;
        private Queue<TrainLineVariable> stableLines;
        private int id;
        private int progressiveChanges;

        public Timetable()
        {
            setDefaultValues();
        }

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

            variableLines = varLines;
        }

        private void setDefaultValues() 
        {
            id = -1;
            ratingValue = int.MaxValue;
            progressiveChanges = 0;
            stableLines = new Queue<TrainLineVariable>();
            variableLines = new List<TrainLineVariable>();
        }

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

        public List<TrainLineVariable> TrainLines
        {
            get
            {
                return variableLines;
            }
            set
            {
            }
        }

        public List<TrainLineVariable> findFixedLines()
        {

            List<TrainLineVariable> fixedLines = new List<TrainLineVariable>();
            // loop over all lines
            foreach(TrainLineVariable line in variableLines)
            {
                if (line.isFixed()) 
                {
                    fixedLines.Add(line);
                }
            }

            return fixedLines;
        }

        public void addVariableLine(TrainLineVariable line)
        {
            if (!doesVariableLineExist(variableLines, line.LineNumber))
            {
                variableLines.Add(line);
            }
        }

        public void setVariableLines(List<TrainLineVariable> lines)
        {
            variableLines = lines;
        }

        public List<TrainLineVariable> getVariableLines()
        {
            return variableLines;
        }

        public void addStableLine(TrainLineVariable line)
        {
            if (!stableLines.Contains(line))
            {
                stableLines.Enqueue(line);
            }

            //if (!doesVariableLineExist(stableLines, line.LineNumber)) 
            //{
            //    stableLines.Enqueue(line);               
            //}
        }

        public void setStableLines(Queue<TrainLineVariable> lines)
        {
            this.stableLines = lines;
        }

        public void clearStableLines()
        {
            stableLines.Clear();
        }

        public Queue<TrainLineVariable> getStableLines()
        {
            return stableLines;
        }

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

        public TrainLineVariable getVariableLineOnSelect(int lineNumber) 
        {
            return findVariableLine(variableLines, lineNumber);
        }

        public static Boolean doesVariableLineExist(List<TrainLineVariable> lines, int lineNumber) 
        {
            Boolean exists = true;
            if (findVariableLine(lines, lineNumber) == null)
            {
                exists = false;
            }
            return exists;
        }

        public void randomizeTimetable()
        {
            DateTime now = DateTime.Now;
            // output for controlling random numbers
            //FileStream fs = new FileStream("randomNumbers" + now.Month + now.Day + now.Hour + now.Minute + ".tmp", FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);

            // createConstraintSet instance of class Random
            Random random = new Random();

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

        public static int calculateTimetableRatingValue(Timetable tt)
        {
            int ratingValue = 0;

            foreach (TrainLineVariable line in tt.TrainLines)
            {
                ratingValue += line.RatingValue;
            }

            return ratingValue;
        }

        public void calculateRatingValue()
        {
            ratingValue = calculateTimetableRatingValue(this);
        }

        public static int calculateTimetableProgressiveChanges(Timetable tt)
        {
            int progressiveChanges = 0;

            foreach (TrainLineVariable line in tt.TrainLines) 
            {
                progressiveChanges += line.ProgressiveChanges;
            }
            return progressiveChanges;
        }

        public void calculateProgressiveChanges()
        {
            progressiveChanges = calculateTimetableProgressiveChanges(this);
        }
    }
}
