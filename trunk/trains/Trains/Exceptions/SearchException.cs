﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeriodicTimetableGeneration.Exceptions
{
    public class SearchException : Exception
    {

        public SearchException(String message)
            : base(message)
        {
        }

    }
}
