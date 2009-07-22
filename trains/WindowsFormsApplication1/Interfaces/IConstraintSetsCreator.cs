using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration.Interfaces
{
    public interface IConstraintSetsCreator
    {
        List<Constraint> createConstraintSet(List<Constraint> constraints, int size);
    }

    public class BisectionSameTransferTimeCreator : IConstraintSetsCreator
    {

        #region IConstraintSetsCreator Members

        public List<Constraint> createConstraintSet(List<Constraint> constraints, int size)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

  

   

}
