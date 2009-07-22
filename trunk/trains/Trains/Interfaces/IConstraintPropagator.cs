using System;
using System.Collections.Generic;
using System.Text;
using PeriodicTimetableGeneration.Interfaces.ConstraintSetsCreators;

namespace PeriodicTimetableGeneration.Interfaces
{
	public interface IConstraintPropagator
	{
		PropagationResult runPropagationAlgorithm(List<Constraint> constraints, int size);
	}

	public class BisectionPropagator : IConstraintPropagator
	{

		#region Contraint sets creator

		private readonly IConstraintSetsCreator constraintSetsCreator;

		protected IConstraintSetsCreator ConstraintSetsCreator
		{
			get
			{
				return this.constraintSetsCreator;
			}
		}

		#endregion

		public BisectionPropagator(IConstraintSetsCreator constraintSetsCreator)
		{
			this.constraintSetsCreator = constraintSetsCreator;
		}


		#region Default settings for the algorithm

		/// <summary>
		/// Default value for lower bound used in Bisection Algorithm.
		/// </summary>
		private const int LOWER_BOUND_DEFAULT = 0;

		/// <summary>
		/// Default value for upper bound used in Bisection Algorithm.
		/// </summary>
		private const int UPPER_BOUND_DEFAULT = 120;

		#endregion

		#region IConstraintPropagator Members

		public PropagationResult runPropagationAlgorithm(List<Constraint> constraints, int size)
		{
			return BisectionUtils.Bisect(constraints, this.ConstraintSetsCreator, LOWER_BOUND_DEFAULT, UPPER_BOUND_DEFAULT);
		}

		#endregion
	}

	public class SimplePropagator : IConstraintPropagator
	{
		#region Contraint sets creator

		private readonly IConstraintSetsCreator constraintSetsCreator;

		protected IConstraintSetsCreator ConstraintSetsCreator
		{
			get
			{
				return this.constraintSetsCreator;
			}
		}

		#endregion

		public SimplePropagator(IConstraintSetsCreator constraintSetsCreator)
		{
			this.constraintSetsCreator = constraintSetsCreator;
		}

		#region IConstraintPropagator Members

		public PropagationResult runPropagationAlgorithm(List<Constraint> constraints, int size)
		{
			return PropagationUtils.runPropagationAlgorithm(constraints, this.ConstraintSetsCreator, size);
		}

		#endregion
	}

}
