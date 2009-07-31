using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeriodicTimetableGeneration.GenerationAlgorithm
{
    public static class TransferUtil
    {
        #region Public Static Methods        

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

        public static List<Transfer> createTransfers(int line)
        {
            List<Transfer> transfers = new List<Transfer>();
            List<GroupOfConnections> connections = FinalInput.getInstance().getCacheContent();

            transfers.AddRange(findOnTransfers(connections, line));
            transfers.AddRange(findOffTransfers(connections, line));

            return transfers;
        }

        public static Transfer findTransfer(List<Transfer> transfers, int off, int on, int stationID)
        {
            Transfer transfer = null;

            foreach (Transfer tran in transfers)
            {
                // if OFF and ON are equals, we found a transfers
                if (tran.Off.Equals(off) && tran.On.Equals(on) && tran.StationID.Equals(stationID))
                {
                    transfer = tran;
                    break;
                }
            }

            return transfer;
        }

        #endregion


        #region Private Static Methods

        private static List<Transfer> findOnTransfers(List<GroupOfConnections> connections, int lineNumber)
        {
            List<Transfer> transfers = new List<Transfer>();

            // loop over all group of connection
            foreach (GroupOfConnections connection in connections)
            {
                TrainLine previousLine = null;
                // loop over all lines in that group
                foreach (TrainLine line in connection.LinesOfConnection)
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


        #endregion

    }
}
