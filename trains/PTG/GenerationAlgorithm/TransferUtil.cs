﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeriodicTimetableGeneration.GenerationAlgorithm
{
    /// <summary>
    /// Utility methods for transfer.
    /// </summary>
    public static class TransferUtil
    {

        #region Public Static Methods

        /// <summary>
        /// Doeses the transfer exist.
        /// </summary>
        /// <param name="transfers">The transfers.</param>
        /// <param name="off">The off.</param>
        /// <param name="on">The on.</param>
        /// <param name="stationID">The station ID.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates the transfers for all lines.
        /// </summary>
        /// <returns></returns>
        public static List<Transfer> createTransfersForAllLines()
        {
            // new transfers
            List<Transfer> transfers = new List<Transfer>();
            // retreive all lines
            List<TrainLine> allLines = TrainLineCache.getInstance().getCacheContent();

            // loop over all lines
            foreach (TrainLine line in allLines)
            {
                // find all transfers except of existed ones
                createTransfers(line, transfers);
            }

            return transfers;
        }

        /// <summary>
        /// Creates the transfers.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="transfers">The transfers.</param>
        public static void createTransfers(TrainLine line, List<Transfer> transfers)
        {
            // List<Transfer> transfers = new List<Transfer>();
            List<GroupOfConnections> connections = FinalInput.getInstance().getGroupsOfConnections();
            findOnOffTransfers(connections, line, transfers);
        }

        /// <summary>
        /// Finds the transfer.
        /// </summary>
        /// <param name="transfers">The transfers.</param>
        /// <param name="off">The off line.</param>
        /// <param name="on">The on line.</param>
        /// <param name="stationID">The station ID.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Finds the on transfers.
        /// </summary>
        /// <param name="connections">The connections.</param>
        /// <param name="selectedLine">The selected line.</param>
        /// <param name="transfers">The transfers.</param>
        /// <returns></returns>
        private static List<Transfer> findOnTransfers(List<GroupOfConnections> connections, TrainLine selectedLine, List<Transfer> transfers)
        {
            int lineNumber = selectedLine.LineNumber;

            // loop over all group of connection
            foreach (GroupOfConnections connection in connections)
            {
                TrainLine previousLine = null;
                // loop over all lines in that group
                foreach (TrainLine line in connection.LinesOfConnection)
                {
                    // if we indicate the wanted line
                    // and if previous line exists, we indicate Transfer ON LINE
                    if (previousLine != null && line.LineNumber == lineNumber)
                    {
                        updateTransfer(previousLine, selectedLine, connection, transfers);
                    }

                    // set line as prevous for next loop
                    previousLine = line;
                }
            }

            return transfers;
        }

        /// <summary>
        /// Finds the on/off transfers.
        /// </summary>
        /// <param name="connections">The connections.</param>
        /// <param name="selectedLine">The selected line.</param>
        /// <param name="transfers">The transfers.</param>
        /// <returns></returns>
        private static List<Transfer> findOnOffTransfers(List<GroupOfConnections> connections, TrainLine selectedLine, List<Transfer> transfers)
        {
            int lineNumber = selectedLine.LineNumber;

            // loop over all group of connection
            foreach (GroupOfConnections connection in connections)
            {
                // previous line - determines if we are handling the off or on transfer
                TrainLine previousLine = null;

                // loop over all lines in that group
                foreach (TrainLine line in connection.LinesOfConnection)
                {
                    if (previousLine != null)
                    {
                        // off: if the previous line is wanted line
                        if (previousLine.LineNumber == lineNumber)
                        {
                            updateTransfer(selectedLine, line, connection, transfers);
                        }

                        // on: if the current line is wanted line
                        if (line.LineNumber == lineNumber)
                        {
                            updateTransfer(previousLine, selectedLine, connection, transfers);
                        }
                    }

                    // set line as prevous for next loop
                    previousLine = line;
                }
            }

            return transfers;
        }

        /// <summary>
        /// Finds the off transfers.
        /// </summary>
        /// <param name="connections">The connections.</param>
        /// <param name="selectedLine">The selected line.</param>
        /// <param name="transfers">The transfers.</param>
        /// <returns></returns>
        private static List<Transfer> findOffTransfers(List<GroupOfConnections> connections, TrainLine selectedLine, List<Transfer> transfers)
        {
            int lineNumber = selectedLine.LineNumber;

            // loop over all group of connection
            foreach (GroupOfConnections connection in connections)
            {
                TrainLine previousLine = null;
                // loop over all lines in that group
                foreach (TrainLine line in connection.LinesOfConnection)
                {
                    // if the previous line is wanted line
                    if (previousLine != null && previousLine.LineNumber == lineNumber)
                    {
                        updateTransfer(selectedLine, line, connection, transfers);
                    }

                    // set line as prevous for next loop
                    previousLine = line;
                }
            }

            return transfers;
        }

        /// <summary>
        /// Updates the transfer's passengers field.
        /// </summary>
        /// <param name="offLine">The off line.</param>
        /// <param name="onLine">The on line.</param>
        /// <param name="connection">The connection.</param>
        /// <param name="transfers">The transfers.</param>
        private static void updateTransfer(TrainLine offLine, TrainLine onLine, GroupOfConnections connection, List<Transfer> transfers)
        {
            // determine changing station
            TrainStation station = connection.getConnections()[0].findChangingStation(offLine.LineNumber, onLine.LineNumber);

            // try to find transfer
            Transfer existedTransfer = findTransfer(transfers, offLine.LineNumber, onLine.LineNumber, station.Id);

            // if transfers already exists
            if (existedTransfer == null)
            {
                // create a new Transfer, and fill the details
                existedTransfer = new Transfer(offLine, onLine, station);

                // add transfer into transfers
                transfers.Add(existedTransfer);

                // add into line1 and line2
                updateTransferLinks(existedTransfer);
            }

            existedTransfer.Passengers += connection.Passengers;
        }

        /// <summary>
        /// Updates the transfer links.
        /// </summary>
        /// <param name="transfer">The transfer.</param>
        private static void updateTransferLinks(Transfer transfer)
        {
            // update station's link
            transfer.Station.Transfers.Add(transfer);
            // upadte line's on lnik
            transfer.OnLine.TransfersOn.Add(transfer);
            // update line's off link
            transfer.OffLine.TransfersOff.Add(transfer);
        }


        #endregion

    }
}
