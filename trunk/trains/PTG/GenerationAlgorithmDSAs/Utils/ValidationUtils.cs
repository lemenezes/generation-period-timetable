using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeriodicTimetableGeneration.GenerationAlgorithmDSAs.Utils
{
    public static class ValidationUtils
    {

        public static bool isInteger(String s)
        {
            int result;
            return int.TryParse(s, out result);
        }

        public static bool isTime(String s)
        {
            try
            {
                Time t = Time.ToTime(s);
                return t.Hour < 24 && t.Hour >= 0 && t.Minute < 60 && t.Minute >= 0;
            }
            catch
            {
                return false;
            }
        }

    }
}
