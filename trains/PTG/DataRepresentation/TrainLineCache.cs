using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{

    /// <summary>
    /// Class represents a cache for Train Lines.
    /// </summary>
    public class TrainLineCache
    {
        private List<TrainLine> cacheContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainLineCache"/> class.
        /// Private constructor, protected from creating instance form outside.
        /// </summary>
        private TrainLineCache() {
            cacheContent = new List<TrainLine>();
        }


        /// <summary>
        /// SingletonHolder is loaded on the first execution of Singleton.getInstance()
        /// or the first access toStation SingletonHolder.INSTANCE, not before.
        /// </summary>
        /// 
        /// </summary>
        private static class SingletonHolder
        {
            static SingletonHolder() { }

            internal static readonly TrainLineCache INSTANCE = new TrainLineCache();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>Instance of TrainLineCache</returns>
        public static TrainLineCache getInstance()
        {
            return SingletonHolder.INSTANCE;
        }

        /// <summary>
        /// Clears the cache content.
        /// </summary>
        public void clearContent()
        {
            cacheContent.Clear();
        }

        /// <summary>
        /// Finds the train line according the line's number.
        /// </summary>
        /// <param name="number">The line's number.</param>
        /// <returns>The train line</returns>
        private TrainLine findLine(int number)
        {
            
            TrainLine line = null;                  //set default
            foreach (TrainLine s in cacheContent)   //loop all variableLines
            {
                if (s.LineNumber.Equals(number))     //if line_ number found
                {
                    line = s;                       //return line_
                    break;
                }
            }
            return line;
        }

        /// <summary>
        /// Finds the train line according the line's number in train lines.
        /// </summary>
        /// <param name="number">The line's number.</param>
        /// <param name="lines">The train lines.</param>
        /// <returns></returns>
        public static TrainLine findLine(int number, List<TrainLine> lines) 
        {
            TrainLine line = null;                  //set default
            foreach (TrainLine s in lines)          //loop all variableLines
            {
                if (s.LineNumber.Equals(number))    //if line_ number found
                {
                    line = s;                       //return line_
                    break;
                }
            }
            return line;        
        }

        /// <summary>
        /// Gets the content of the cache.
        /// </summary>
        /// <returns>The train lines</returns>
        public List<TrainLine> getCacheContent()
        {
            return cacheContent;
        }

        /// <summary>
        /// Gets the cache content on line's number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The train line</returns>
        public TrainLine getCacheContentOnNumber(int number)
        {
            return findLine(number);
        }

//        public TrainLine getCahceContentOnSelect()
//        {
//            throw new System.NotImplementedException();
//        }

        /// <summary>
        /// Determines whether the trian line exists in cache.
        /// </summary>
        /// <param name="number">The line's number.</param>
        /// <returns></returns>
        public Boolean doesLineExist(int number)
        {
            if (findLine(number) != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Determines whether the trian line exists in train lines.
        /// </summary>
        /// <param name="number">The line's number.</param>
        /// <param name="lines">The train lines.</param>
        /// <returns></returns>
        public static Boolean doesLineExist(int number, List<TrainLine> lines) 
        {
            if (findLine(number, lines) != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Sets the content of the cache.
        /// </summary>
        /// <param name="lines">The train lines.</param>
        public void setCacheContent(List<TrainLine> lines)
        {
            cacheContent = lines;
        }

        /// <summary>
        /// Adds the train line into cache.
        /// </summary>
        /// <param name="line">The train line.</param>
        public void addTrainLine(TrainLine line)
        {
             cacheContent.Add(line);
        }





    }
}
