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
				return GenerationAlgorithmPESPUtil.createConstraintSets_SameTransferTime(constraints, size);
			}

			#endregion
		}

		public class AlfaTTransferTime : IConstraintSetsCreator
		{
			#region IConstraintSetsCreator Members

			public List<Constraint> createConstraintSet(List<Constraint> constraints, int size)
			{
				return GenerationAlgorithmPESPUtil.createConstraintSets_AlfaTTransferTime(constraints, size);
			}

			#endregion
		}

		public class FullDiscreteSet : IConstraintSetsCreator
		{
			#region IConstraintSetsCreator Members

			public List<Constraint> createConstraintSet(List<Constraint> constraints, int size)
			{
				return GenerationAlgorithmPESPUtil.createConstraintSets_FullDiscreteSets(constraints, size);
			}

			#endregion
		}

	}

}
