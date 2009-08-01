using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public enum Period
    {
        interval15 = 15,
        interval30 = 30,
        interval60 = 60,
        interval120 = 120,
    }

    public static class PeriodUtil
    {
        //public static

        public static Period getPeriod(String interval)
        {
            Period newPeriod;
            int intInterval = Convert.ToInt32(interval);

            if (intInterval.Equals((int)Period.interval15))
                newPeriod = Period.interval15;
            else if (intInterval.Equals((int)Period.interval30))
                newPeriod = Period.interval30;
            else if (intInterval.Equals((int)Period.interval60))
                newPeriod = Period.interval60;
            else if (intInterval.Equals((int)Period.interval120))
                newPeriod = Period.interval120;
            else
                newPeriod = Period.interval120;
            return newPeriod;
        }

        public static Period getPeriod(int intInterval)
        {
            Period newPeriod;
            //int intInterval = Convert.ToInt32(interval);

            if (intInterval.Equals((int)Period.interval15))
                newPeriod = Period.interval15;
            else if (intInterval.Equals((int)Period.interval30))
                newPeriod = Period.interval30;
            else if (intInterval.Equals((int)Period.interval60))
                newPeriod = Period.interval60;
            else if (intInterval.Equals((int)Period.interval120))
                newPeriod = Period.interval120;
            else
                newPeriod = Period.interval120;
            return newPeriod;
        }

        public static Time normalizeTime(Time time, Period period)
        {
            int minutes = time.ToMinutes();
            minutes %= (int)period;
            if (minutes < 0)
            {
                minutes += (int)period;
            }

            return Time.ToTime(minutes);
        }

        public static int normalizeTime(int minutes, int period)
        {            
            minutes %= period;
            if (minutes < 0)
            {
                minutes += period;
            }

            return minutes;
        }

    }
}
