using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PeriodicTimetableGeneration
{

    /// <summary>
    /// Implements utility method for logs.
    /// </summary>
	public static class LogUtil
	{


        /// <summary>
        /// Prints the discrete set matrix to file.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="fileName">Name of the file.</param>
		public static void printDiscreteSetMatrixToFile(Set[,] matrix, String fileName)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);

			// loop over all rows
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				// loop over all columns
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					String str = String.Format("[{0}, {1}]: ", i.ToString().PadLeft(2, ' '), j.ToString().PadLeft(2, ' '));
					str += matrix[i, j].ToString();
					sw.WriteLine(str);
				}
			}

			sw.Close();
			fs.Close();
		}

        /// <summary>
        /// Prints the constraints to file.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <param name="fileName">Name of the file.</param>
		public static void printConstraintsToFile(List<Constraint> constraints, String fileName)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);

			sw.WriteLine("{0} ", constraints.Count);

			foreach (Constraint constraint in constraints)
			{
				sw.Write("{0}->{1}: ", constraint.TrainLineNumber1, constraint.TrainLineNumber2);
				sw.WriteLine(constraint.DiscreteSet.ToString());
			}

			sw.Close();
			fs.Close();
		}

        public static void printTimetableTransfersEvaluation(Timetable timetable, List<Transfer> transfers) 
        {
            String fileName = timetable.ID.ToString();

            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            int ratingValue = 0;

            foreach (Transfer transfer in transfers)
            {
                int value = calculateTransfer(timetable, transfer, sw);
                ratingValue += value;
            }

            sw.WriteLine("TotalRatingValue: {0}", ratingValue);

            sw.Close();
            fs.Close();
        }

        public static int calculateTransfer(Timetable timetable, Transfer transfer, StreamWriter sw)
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

            sw.WriteLine("{0} - {1} => {2}*{3} = {4}", departureTime, arrivalTime, departureTime -arrivalTime, transfer.Passengers, ratingValue);

            return ratingValue;
        }

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

	}

}
