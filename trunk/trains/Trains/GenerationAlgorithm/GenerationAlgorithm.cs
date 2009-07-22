using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PeriodicTimetableGeneration
{
    public class GenerationAlgorithm
    {
        private List<Timetable> timetables;
        private List<TrainLine> trainLines;
        private List<TrainStation> trainStations;

        public GenerationAlgorithm()
        {
            setDefaultValues();
        }

        private void setDefaultValues()
        {
            timetables = new List<Timetable>();
            trainLines = TrainLineCache.getInstance().getCacheContent();
            trainStations = TrainStationCache.getInstance().getCacheContent();
        }

        public List<TrainStation> TrainStations
        {
            get
            {
                return trainStations;
            }
            set
            {
                trainStations = value;
            }
        }

        public List<TrainLine> TrainLines
        {
            get
            {
                return trainLines;
            }
            set
            {
                trainLines = value;
            }
        }

        public List<Timetable> Timetables
        {
            get
            {
                return timetables;
            }
            set
            {
                timetables = value;
            }
        }

        private static class SingletonHolder 
        {
            static SingletonHolder() { }

            internal static readonly GenerationAlgorithm INSTANCE = new GenerationAlgorithm();
        }

        public static GenerationAlgorithm getInstance()
        {
            return SingletonHolder.INSTANCE;
        }

        public Timetable createTimetable()
        {
            return new Timetable(timetables.Count+1, trainLines);
        }

        public Timetable generateRandomizedTimetable()
        {
            Timetable tt = createTimetable();
            tt.randomizeTimetable();
            return tt;
        }

        public static Timetable randomizeTimetable(Timetable timetable)
        {
            timetable.randomizeTimetable();
            return timetable;
        }

        public void generateTimetables(int numberOfTimetables, 
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            // clear previous timetables
            timetables.Clear();

            for (int i = 1; i <= numberOfTimetables; i++) 
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    Timetable tt = generateTimetable();
                    timetables.Add(tt);
                    int ii = i;
                    int total = numberOfTimetables;
                    int percentageComplere = (int)((float)ii / (float)total * 100);
                    worker.ReportProgress(percentageComplere);                    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Timetable generateTimetable()
        {
            // generate randomizedTimetable
            Timetable timetable = generateRandomizedTimetable();
            // createConstraintSet temporary holder for AvailableLines during calculation
            List<TrainLineVariable> availableLines = cloneVariableLines(timetable.getVariableLines());
            // createConstraintSet temporary holder for AvailableLines during calculation
            Queue<TrainLineVariable> stableLines = new Queue<TrainLineVariable>();

            // random class for randomizing choice of trainlines
            Random random = new Random();    

            // local variables
            //int theBestTimetableRatingValue = int.MaxValue;
            //int progressiveChanges = 0;

            // loop until if availableLines are not empty AND stableLine are not complete
            while(!availableLines.Count.Equals(0) &&
                !stableLines.Count.Equals(timetable.TrainLines.Count))
            {
                // saving the theBestTimetableRatingValue

                // choose available line randomly
                TrainLineVariable selectedLine = availableLines[random.Next(0,availableLines.Count-1)];

                // startTime with appropriate best rating value of transfers calculation
                Time theBestLineStartTime = Time.MinValue;
                int theBestLineRatingValue = int.MaxValue;

                // loop over whole interval of line
                for (int i = 0; i < (int)selectedLine.Period; i++)
                {
                    // calculate transfers
                    int currentRatingValue = calculateTransfers(timetable, selectedLine, Time.ToTime(i));

                    // choose the best settings of interval
                    // if the last best line's rating value is worse than current
                    if (theBestLineRatingValue > currentRatingValue)
                    {
                        // update the best line's details
                        theBestLineRatingValue = currentRatingValue;
                        theBestLineStartTime = Time.ToTime(i);
                    }
                }

                // compare the theBestTimetableRatingValue with new line ratingValue
                // if the previousRatingValue is worse than current, then change it
                if (selectedLine.RatingValue > theBestLineRatingValue)
                {
                    // update line's details
                    selectedLine.RatingValue = theBestLineRatingValue;
                    selectedLine.StartTime = theBestLineStartTime;
                    selectedLine.ProgressiveChanges += 1;
                    // clear stableLines queue
                    stableLines.Clear();
                    // reset availableLines
                    availableLines = cloneVariableLines(timetable.getVariableLines());
                }

                // addConstraint line into queue of stableLines
                stableLines.Enqueue(selectedLine);
                // remove line off availableLines
                availableLines.Remove(selectedLine);
            }

            // update statistic's values of timetable
            timetable.calculateRatingValue();
            timetable.calculateProgressiveChanges();

            Console.WriteLine("------------------------");
            Console.WriteLine("Timetable: " + timetable.ID);
            foreach (TrainLineVariable line in timetable.getVariableLines()) 
            {
                Console.WriteLine(line.LineNumber + "> Progress: " + line.ProgressiveChanges + "> Rating: " + line.RatingValue);
            }
            

            return timetable;
        }

        private List<TrainLineVariable> cloneVariableLines(List<TrainLineVariable> lines)
        {
            List<TrainLineVariable> cloneLines = new List<TrainLineVariable>();

            foreach (TrainLineVariable line in lines) 
            {
                cloneLines.Add(line);
            }

            return cloneLines;
        }

        private int calculateTransfers(Timetable timetable, TrainLineVariable line, Time startTime)
        {
            // define all possibleTransfers
            List<Transfer> transfers = createTransfers(line.LineNumber);

            // set global globalRatingValue
            int globalRatingValue = 0;
            
            // loop over all posibleTransfers
            foreach (Transfer transfer in transfers)
            {               
                // calculate difference gap between       // increment globalRatingValue
                globalRatingValue += calculateTransfer(timetable, transfer, line, startTime);
            }    

            // return global ratingValue
            return globalRatingValue;
        }

        public int calculateTransfer(Timetable timetable, Transfer transfer, TrainLineVariable line, Time startTime)
        {
            // minimal transfers time set on 5 min
            Time minimalTransferTime = Time.ToTime(5);
            // result rating value
            int ratingValue;
            // saveTime
            Time savedTime = line.StartTime;
            // prepare new for calcualtion
            line.StartTime = startTime;

            // gain transer train line variables
            TrainLineVariable lineOff = timetable.getVariableLineOnSelect(transfer.Off);
            TrainLineVariable lineOn = timetable.getVariableLineOnSelect(transfer.On);

            // determine arrival of LineOFF and departure of LineON
            Time timeArrival = lineOff.arrivalOnStation(transfer.Station) + lineOff.StartTime;
            Time timeDeparture = lineOn.departureFromStation(transfer.Station) + lineOn.StartTime;

            // if departure is before arrival, we need to find closest time departure
            // that satisfied the condition(departure>arrival)
            if (timeDeparture < timeArrival + minimalTransferTime)
            {
                while (timeDeparture < timeArrival + minimalTransferTime)
                {
                    // addConstraint new period of train
                    timeDeparture += Time.ToTime((int)lineOn.Period);
                }
            }
            else
            {
                // if arrival is before departure, we need to find closest time arrival
                // that satisfied the cond(departure>arrival) but not the cond(departure>arrival+nextPeriod)
                while (timeDeparture > timeArrival + Time.ToTime((int) lineOff.Period) + minimalTransferTime)
                {
                    timeArrival += Time.ToTime((int) lineOff.Period);
                }
            }

            // if the time for tranfer is more than than minimal
            //if (timeDeparture - timeArrival > minimalTransferTime)
            //{
            //    // calculate rating value according passengers on transfers
            //    ratingValue = transfers.evaluateTransferFunction(timeDeparture - timeArrival);
            //}
            //// otherwise
            //else 
            //{
            //    // wait for next train of that line, in next period
            //    ratingValue = transfers.evaluateTransferFunction(timeDeparture - timeArrival + Time.ToTime( (int) transfers.OnLine.Period));
            //}

            //Console.Out.WriteLine("----------------------------------------------------------");
            //Console.Out.WriteLine("Transfer: " + transfers.OffLine.LineNumber + "->" + transfers.OnLine.LineNumber);
            //Console.Out.WriteLine("Passengers: " + transfers.Passengers + " > TransferTime: " + (timeDeparture - timeArrival).ToString());

            ratingValue = transfer.evaluateTransferFunction(timeDeparture - timeArrival);

            


            // restore saved time
            line.StartTime = savedTime;

            return ratingValue;
        }

        /*public Transfer createTransfer()
        {
        
            Transfer transfers = new Transfer(

            return transfers;
        }*/

        public static List<Transfer> createTransfers(int line)
        {
            List<Transfer> transfers = new List<Transfer>();
            List<GroupOfConnections> connections = FinalInput.getInstance().getCacheContent();

            transfers.AddRange( findOnTransfers(connections, line));
            transfers.AddRange( findOffTransfers(connections, line));

            return transfers;
        }

        private static List<Transfer> findOnTransfers(List<GroupOfConnections> connections, int lineNumber)
        {
            List<Transfer> transfers = new List<Transfer>();

            // loop over all group of connection
            foreach(GroupOfConnections connection in connections)
            {
                TrainLine previousLine = null;
                // loop over all lines in that group
                foreach(TrainLine line in connection.LinesOfConnection)
                {
                    // if we indicate the wanted line
                    if (line.LineNumber.Equals(lineNumber)) 
                    {
                        // and if previous line exists, we indicate Transfer ON LINE
                        if (previousLine != null) 
                        {
                            // determine changing station
                            TrainStation station = connection.getConnections()[0].findChangingStation(previousLine.LineNumber, lineNumber);

                            // if transfers already exists
                            if (doesTransferExist(transfers, previousLine.LineNumber, lineNumber, station.Id))
                            {
                                // find the transfers and update details
                                Transfer tranUpd = findTransfer(transfers, previousLine.LineNumber, lineNumber, station.Id);
                                tranUpd.Passengers += connection.Passengers;
                            }
                            // otherwise
                            else 
                            {
                                // createConstraintSet a new Transfer, and fill the details
                                Transfer tran = new Transfer(previousLine, line, station);
                                tran.Passengers = connection.Passengers;
                                // addConstraint into transfers
                                transfers.Add(tran);
                            }
                        }
                    }


                    // set line as prevous for next loop
                    previousLine = line;
                }


            }

            return transfers;
        }

        private static List<Transfer> findOffTransfers(List<GroupOfConnections> connections, int lineNumber) 
        {
            List<Transfer> transfers = new List<Transfer>();

            // loop over all group of connection
            foreach (GroupOfConnections connection in connections)
            {
                TrainLine previousLine = null;
                // loop over all lines in that group
                foreach (TrainLine line in connection.LinesOfConnection)
                {
                    // if the previous line is wanted line
                    if (previousLine != null && previousLine.Equals(lineNumber))
                    {
                            // determine changing station
                            TrainStation station = connection.getConnections()[0].findChangingStation(previousLine.LineNumber, line.LineNumber);

                            // if transfers already exists
                            if (doesTransferExist(transfers, previousLine.LineNumber, line.LineNumber, station.Id))
                            {
                                // find the transfers and update details
                                Transfer tranUpd = findTransfer(transfers, previousLine.LineNumber, lineNumber, station.Id);
                                tranUpd.Passengers += connection.Passengers;
                            }
                            // otherwise
                            else
                            {
                                // createConstraintSet a new Transfer, and fill the details
                                Transfer tran = new Transfer(previousLine, line, station);
                                tran.Passengers = connection.Passengers;
                                // addConstraint into transfers
                                transfers.Add(tran);
                            }                        
                    }


                    // set line as prevous for next loop
                    previousLine = line;
                }
            }

            return transfers;
        }

        public static Transfer findTransfer(List<Transfer> transfers, int off, int on, int stationID)
        {
            Transfer transfer = null;

            foreach(Transfer tran in transfers)
            {
                // if OFF and ON are equals, we found a transfers
                if(tran.Off.Equals(off) && tran.On.Equals(on) && tran.StationID.Equals(stationID))
                {
                    transfer = tran;
                    break;
                }
            }

            return transfer;
        }

        public static Timetable findTimetableOnSelect(List<Timetable> timetables , int id)
        {
            Timetable tt = null;

            foreach(Timetable timetable in timetables)
            {
                if (timetable.ID.Equals(id))
                {
                    tt = timetable;
                    break;
                }
            }
            return tt;
        }

        public Timetable findTimetableOnSelect(int id) 
        {
            return findTimetableOnSelect(this.timetables, id);
        }

        public static Boolean doesTimetableExist(List<Timetable> timetables, int id) 
        {
            Boolean exists = false;
            if (findTimetableOnSelect(timetables, id) != null)
            {
                exists = true;
            }
            return exists;
        }

        public Boolean doesTimetableExist(int id) 
        {
            return doesTimetableExist(this.timetables, id);
        }

        public static Boolean doesTransferExist(List<Transfer> transfers, int off, int on, int stationID) 
        {
            Boolean exist = false;

            // if we found transfers different than null
            if (findTransfer(transfers, off, on, stationID) != null) 
            {
                // then transfers exists
                exist = true;
            }

            return exist;
        }

    }
}
