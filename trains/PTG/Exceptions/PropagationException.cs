using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeriodicTimetableGeneration.Exceptions
{
    public class PropagationException : Exception
    {

        public PropagationException(String message)
            : base(message)
        {
        }

    }
}
