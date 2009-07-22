using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using PeriodicTimetableGeneration.Interfaces;
using PeriodicTimetableGeneration.Interfaces.ConstraintSetsCreators;

namespace PeriodicTimetableGeneration
{

	/// <summary>
	/// Class represents sophisticated Generation Algorithm of Periodic Timetables.
	/// Implements appropriate methods for it.
	/// </summary>
	public class GenerationAlgorithmPESP
	{

		#region Private Fields

		/// <summary>
		/// List of constructed algorithm.
		/// </summary>
		private List<Timetable> timetable;

		/// <summary>
		/// Constant maximal value used for list
		/// </summary>
		const int MAX_RULETTE_COUNT = 10;

		#endregion

		#region Constructors

		public GenerationAlgorithmPESP()
		{
			setDefaultValues();
		}

		#endregion

		#region Structs

		struct SolutionItem
		{
			public SolutionItem(Set s)
			{
				if (s.Count == 1)
				{
					Minute = 0;
					Factor = 0;

					// Should be the only one element in the set, so remember it.
					foreach (KeyValuePair<int, int> p in s.MinimizationFactor)
					{
						Minute = p.Key;
						Factor = p.Value;
					}
					NotSingleton = false;
				}
				else
				{
					// Not constrained set - give the negative values for it.
					Minute = -1;
					Factor = 0;
					NotSingleton = true;
				}
			}

			public override string ToString()
			{
				return String.Format("Minute: {0}, Factor: {1}", Minute, Factor);
			}

			public int Minute;
			public int Factor;
			public bool NotSingleton;
		}

		struct Solution
		{
			public Solution(Set[,] s)
			{
				Matrix = new SolutionItem[s.GetLength(0), s.GetLength(1)];
				Factor = 0;
				for (int i = 0, rows = s.GetLength(0); i < rows; ++i)
				{
					for (int j = 0, cols = s.GetLength(1); j < cols; ++j)
					{
						Matrix[i, j] = new SolutionItem(s[i, j]);
						Factor += Matrix[i, j].Factor;
					}
				}
			}

			public SolutionItem[,] Matrix;
			public int Factor;
		}

		#endregion

		#region Public Methods

		public void generateTimetable()
		{
			// Initialize the algorithm.
			List<Constraint> constraints;
			initializeAlgorithm(out constraints);

			// Run the propagation phase.
			IConstraintPropagator propagator = new BisectionPropagator(new SameTransferTime());
			PropagationResult result = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmPESPUtil.MODULO_DEFAULT);
			// Search for the result.
			runSearchAlgorithm(result);

			// Run the propagation phase.
			propagator = new SimplePropagator(new FullDiscreteSet());
			result = propagator.runPropagationAlgorithm(constraints, GenerationAlgorithmPESPUtil.MODULO_DEFAULT);
			// Search for the result.
			runSearchAlgorithm(result);
		}

		public void runSearchAlgorithm(PropagationResult result)
		{
			List<Solution> solutions = new List<Solution>();
			search(result, solutions);
		}

		private void search(PropagationResult result, List<Solution> solutions)
		{
			Set[,] s = result.Matrix;

			// Find the set to be shorted.
			List<FactorRangeRecord> bestRecords = searchForTheBestRecords(s);
			bool isSingleton = bestRecords.Count == 1;
			FactorRangeRecord best = rulette(bestRecords);
			Set currentSet = s[best.Row, best.Col];

			// Create the order in which we will try to find a solution, best possibility first.
			List<int> sortedMinutes = new List<int>(currentSet.MinimizationFactor.Keys);
			sortedMinutes.Sort(delegate(int i, int j)
			{
				return currentSet.MinimizationFactor[i] - currentSet.MinimizationFactor[j];
			});

			// Search for the solution.
			foreach (int minute in sortedMinutes)
			{
				// TODO: Use the branch and bound prunning.

				// Copy the matrix.
				Set[,] newMatrix = GenerationAlgorithmPESPUtil.cloneDiscreteSetMatrix(s);

				// Create a singleton set.
				Set newSet = new Set(currentSet.Modulo);
				newSet.Add(minute, currentSet.MinimizationFactor[minute]);

				// Remeber to the new matrix.
				newMatrix[best.Row, best.Col] = newSet;
				newMatrix[best.Col, best.Row] = new Set(newSet);
				newMatrix[best.Col, best.Row].Reverse();

				// Propagate newly created constraints.
				PropagationUtils.propagate(newMatrix, result.TrainLinesMap);

				// Check if the solution may be found.
				if (!MatrixUtils.isValid(s))
				{
					continue;
				}

				// If the solution is found, remember it, otherwise search for it.
				if (isSingleton)
				{
					solutions.Add(new Solution(newMatrix));
				}
				else
				{
					search(new PropagationResult(newMatrix, result.TrainLinesMap), solutions);
				}
			}
		}

		private FactorRangeRecord rulette(List<FactorRangeRecord> records)
		{
			// TODO: Make a real rulette.
			return records[0];
		}

		private List<FactorRangeRecord> searchForTheBestRecords(Set[,] s)
		{
			// Create the list of MAX_RULETTE_COUNT best records.
			List<FactorRangeRecord> bestRecords = new List<FactorRangeRecord>();
			int currentWorst = Int32.MaxValue;

			// Search for the best records.
			for (int i = 0, rows = s.GetLength(0); i != rows; ++i)
			{
				for (int j = i + 1, cols = s.GetLength(1); j != cols; ++j)
				{
					FactorRangeRecord currentRecord = new FactorRangeRecord
					{
						Row = i,
						Col = j
					};
					if (!FactorRangeRecord.createFactorRecord(s[i, j], ref currentRecord))
					{
						continue;
					}

					if (currentRecord.Factor < currentWorst)
					{
						// Insert - create a space.
						bestRecords.Add(currentRecord);
						int k = bestRecords.Count - 1;
						// Shift them - so that they are sorted.
						while (k > 0 && bestRecords[k - 1].Factor > currentRecord.Factor)
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
						currentWorst = bestRecords[bestRecords.Count - 1].Factor;
					}
				}
			}

			return bestRecords;
		}
		public void initializeAlgorithm(out List<Constraint> constraints)
		{
			//------initialization-constraints-----------------------------------

			// createConstraintSet transfers
			List<Transfer> transfers = GenerationAlgorithmPESPUtil.createTransfers();
			// createConstraintSet constraints
			constraints = GenerationAlgorithmPESPUtil.createConstraints(transfers);
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Sets the default values for fields.
		/// </summary>
		private void setDefaultValues()
		{
			this.timetable = new List<Timetable>();
		}

		#endregion

		#region Properties

		public Timetable Timetable
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
			}
		}


		#endregion
	}
}
