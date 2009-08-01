using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PeriodicTimetableGeneration
{

    public delegate FactorRangeRecord SelectBestRecord(List<FactorRangeRecord> bestRecords);

    /// <summary>
    /// Class implements the methods to find best suitable record in matrix Set[,].
    /// </summary>
    public static class BestSearchUtil
    {
        /// <summary>
        /// Constant maximal value used for list
        /// </summary>
        const int MAX_RULETTE_COUNT = 10;

        /// <summary>
        /// Random class.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Finds the best record used deterministic method.
        /// Firstly choose the biggest range of minFactor in Set, then pick the Min value from that range.
        /// </summary>
        /// <param name="discreteSetMatrix">The discrete set matrix.</param>
        /// <returns></returns>
        public static Boolean deterministicSearchForBestRecord(Set[,] discreteSetMatrix, out FactorRangeRecord resultFactorRangeRecord)
        {
            return searchForBestRecord(discreteSetMatrix, out resultFactorRangeRecord, deterministicChoice);
        }




        /// <summary>
        /// Finds the best record used probabilistic method.
        /// Firstly choose randomly with certain probability the Set with respect to range of minFactr, the pick the min value.
        /// </summary>
        /// <returns></returns>
        public static Boolean probableSearchForBestRecord(Set[,] discreteSetMatrix, out FactorRangeRecord resultFactorRangeRecord)
        {
            return searchForBestRecord(discreteSetMatrix, out resultFactorRangeRecord, probabilisticChoice);
        }

        public static Boolean searchForBestRecord(Set[,] discreteSetMatrix, out FactorRangeRecord resultFactorRangeRecord, SelectBestRecord selectBestRecord)
        {
            Boolean bestRecordsFound = true;

            // Find the top list of possible choices of Set with maximum minFactor range.
            List<FactorRangeRecord> bestRecords = searchForTheBestRecords(discreteSetMatrix);

            // If no best record found
            if (bestRecords.Count.Equals(0))
            {
                // set boolean
                bestRecordsFound = false;
                // return empty record
                resultFactorRangeRecord = new FactorRangeRecord();
            }
            else
            {
                // select one of the best record
                FactorRangeRecord bestRecord = selectBestRecord(bestRecords);
                Set currentSet = bestRecord.Set;

                // from selected set choose pair with min value
                KeyValuePair<int, int> minKeyValuePair = currentSet.Min();

                // selected solutionFactor record set as result
                resultFactorRangeRecord = bestRecord;
                // set item of set with min solutionFactor
                resultFactorRangeRecord.MinItemOfSet = minKeyValuePair.Key;
            }

            return bestRecordsFound;
        }

        public static FactorRangeRecord probabilisticChoice(List<FactorRangeRecord> bestRecords) 
        {
            FactorRangeRecord selectedRecord = new FactorRangeRecord();

            // calculate sum of range factors
            int sumOfRangeFactors = bestRecords.Sum( bestRecord => bestRecord.RangeFactor);
            // generate random number from {0..sumOfRangeFactors}
            int randomNumber = random.Next(sumOfRangeFactors + 1);

            // current sum
            int currentSum = 0;
            int index = 0;

            // current sum is less then random number and index in range
            while (currentSum <= randomNumber && index < bestRecords.Count)
            {
                currentSum += bestRecords[index].RangeFactor;
                selectedRecord = bestRecords[index];
                index++;
            }

            return selectedRecord;
        }

        public static FactorRangeRecord deterministicChoice(List<FactorRangeRecord> bestRecords) 
        {
            return bestRecords[0];
        }

        public static List<FactorRangeRecord> searchForTheBestRecords(Set[,] s)
        {
            // Create the list of MAX_RULETTE_COUNT best records.
            List<FactorRangeRecord> bestRecords = new List<FactorRangeRecord>();
            int currentWorst = 0;

            // Search for the best records.
            for (int i = 0, rows = s.GetLength(0); i != rows; ++i)
            {
                for (int j = i + 1, cols = s.GetLength(1); j != cols; ++j)
                {
                    FactorRangeRecord currentRecord = new FactorRangeRecord
                    {
                        Row = i,
                        Col = j,
                        Set = s[i, j]
                    };
                    if (!FactorRangeRecord.createFactorRecord(s[i, j], ref currentRecord))
                    {
                        continue;
                    }

                    if (currentRecord.RangeFactor >= currentWorst)
                    {
                        // Insert - create a space.
                        bestRecords.Add(currentRecord);
                        int k = bestRecords.Count - 1;
                        // Shift them - so that they are sorted.
                        while (k > 0 && bestRecords[k - 1].RangeFactor < currentRecord.RangeFactor)
                        {
                            bestRecords[k] = bestRecords[k - 1];
                            --k;
                        }
                        // Last assignment places the current record at the right position.
                        bestRecords[k] = currentRecord;

                        // If we have too many elements remove them.
                        if (bestRecords.Count > MAX_RULETTE_COUNT)
                        {
                            bestRecords.RemoveAt(MAX_RULETTE_COUNT);
                        }

                        // Remember the current worst possibility.
                        currentWorst = bestRecords[bestRecords.Count - 1].RangeFactor;
                    }
                }
            }

            return bestRecords;
        }
    }
}
