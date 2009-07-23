using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeriodicTimetableGeneration.Interfaces
{

	/// <summary>
	/// Result of the initial PESP algorithm phase.
	/// </summary>
	public struct PropagationResult
	{

		/// <summary>
		/// Creates the result structure.
		/// </summary>
		/// <param name="matrix">Constraint set matrix.</param>
		/// <param name="trainLinesMap">Map of the train lines.</param>
		public PropagationResult(Set[,] matrix, List<TrainLine> trainLinesMap)
			: this()
		{
			this.DiscreteSetMatrix = matrix;
			this.TrainLinesMap = trainLinesMap;
		}

		/// <summary>
		/// Constraint set matrix.
		/// </summary>
		public Set[,] DiscreteSetMatrix
		{
			get;
			set;
		}

		/// <summary>
		/// Map of the train lines.
		/// </summary>
		public List<TrainLine> TrainLinesMap
		{
			get;
			set;
		}

	}

}
