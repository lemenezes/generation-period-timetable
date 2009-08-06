using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public class Time
    {
        const String TIME_DELIMITER = ":";
        const int MINUTES_PER_HOUR = 60;

        private int hour;
        private int minute;

        public Time()
        {
            hour = 0;
            minute = 0;
        }

        public Time(int hour_, int minute_) 
        {
            hour = hour_;
            minute = minute_;
        }

        public Time(Time time) 
        {
            hour = time.Hour;
            minute = time.Minute;
        }

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = value;
            }
        }

        public static Time MinValue 
        {
            get
            {
                return new Time(0,0);
            }
        }

        public static Time MaxValue 
        {
            get 
            {
                return new Time(int.MaxValue, int.MaxValue);
            }
        }

        public static Time EmptyValue
        {
            get
            {
                return new Time(-1, -1);
            }
        }

        public override String ToString()
        {
            //return String.Format("{0:dd}"+ TIME_DELIMITER+ "{1:dd}", hour, minute);   
            return hour.ToString().PadLeft(2, '0') + TIME_DELIMITER + minute.ToString().PadLeft(2, '0');
        }

        //public override Boolean Equals(object o) { }

        public override Boolean Equals(object obj) 
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Time p = obj as Time;
            if ((System.Object)p == null)
            {
                return false;
            }

            return this.CompareTo(p).Equals(0);
        }

        public override int GetHashCode()
        {
            return hour ^ minute;
        }

        public Boolean Equals(Time time)
        {
            // if comparing is equal 0, then they are Equal
            return this.CompareTo(time).Equals(0);
        }

        public int CompareTo(Time time)
        {
            // evaluate the time of instance and time of object
            int valueOfInstance = hour * MINUTES_PER_HOUR + minute;
            int valueOfObject = time.Hour * MINUTES_PER_HOUR + time.Minute;
            // compare using int.CompareTo
            return (valueOfInstance.CompareTo(valueOfObject));
        }

        public Boolean isValid() 
        {
            Boolean valid = true;
            if (minute < 0 || minute > 59)
                valid = false;
            if (hour < 0 || hour > 23)
                valid = false;

            return valid;
        }

        public static Boolean operator <(Time time1, Time time2)
        {
            return ( time1.CompareTo(time2) < 0) ? true : false;
        }

        public static Boolean operator >(Time time1, Time time2) 
        {
            return ( time1.CompareTo(time2) > 0) ? true : false;
        }

        public static Boolean operator ==(Time time1, Time time2) 
        {
            return time1.Equals(time2);
        }

        public static Boolean operator !=(Time time1, Time time2) 
        {
            return !(time1.Equals(time2));
        }

        public static Boolean operator <=(Time time1, Time time2)
        {
            return !(time1 > time2);
        }

        public static Boolean operator >=(Time time1, Time time2) 
        {
            return !(time1 < time2);
        }

        public static Time operator -(Time time1, Time time2) 
        {            
            Time newTime = new Time();
            if (time1 >= time2)
            {
                int min1 = time1.ToMinutes();
                int min2 = time2.ToMinutes();
                newTime = Time.ToTime(min1 - min2);
            }
            return newTime;
        }

        public static Time operator +(Time time1, Time time2)
        {
            int min1 = time1.ToMinutes();
            int min2 = time2.ToMinutes();
            return Time.ToTime(min1 + min2);
        }

        public static Time ToTime(int minutes) 
        {
            Time time = new Time();
            time.Minute = minutes % MINUTES_PER_HOUR;
            time.Hour = (minutes - time.Minute) / MINUTES_PER_HOUR;
            return time;
        }

        public static Time ToTime(String str)
        {
            if (str.Equals("")) return Time.MinValue;

            String[] strings = str.Split( new string[]  { TIME_DELIMITER }, StringSplitOptions.None);
            int hour = Convert.ToInt32(strings[0]);
            int min = Convert.ToInt32(strings[1]);
            return new Time(hour, min);
        }

        /// <summary>
        /// Convert time into minutes
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int ToMinutes() 
        {
            // count minutes off hours
            return hour * MINUTES_PER_HOUR + minute;
        }

    }   
}
