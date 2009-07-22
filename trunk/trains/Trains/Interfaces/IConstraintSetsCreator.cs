using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration.Interfaces
{
    public interface IConstraintSetsCreator
    {
        List<Constraint> createConstraintSet(List<Constraint> constraints, int size);
    }

	namespace ConstraintSetsCreators
	{

		public class SameTransferTime : IConstraintSetsCreator 
		{
			#region IConstraintSetsCreator Members

			public List<Constraint> createConstraintSet(List<Constraint> constraints, int size)
			{
				return GenerationAlgorithmPESPUtil.createConstraintSets(constraints, size);
			}

			#endregion
		}

		public class AlfaTransferTime : IConstraintSetsCreator
		{
			#region IConstraintSetsCreator Members

			public List<Constraint> createConstraintSet(List<Constraint> constraints, int size)
			{
				return GenerationAlgorithmPESPUtil.createConstraintSetsWithDifferentPeriod(constraints, size);
			}

			#endregion
		}

		public class FullDiscreteSet : IConstraintSetsCreator
		{
			#region IConstraintSetsCreator Members

			public List<Constraint> createConstraintSet(List<Constraint> constraints, int size)
			{
				return GenerationAlgorithmPESPUtil.createConstraintSets(constraints, size);
			}

			#endregion
		}

	}

}
