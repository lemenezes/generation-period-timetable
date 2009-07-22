using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Class represents a cache for Constraints with appropriate methods.
    /// </summary>
    public class ConstraintCache
    {
        #region Private Variables

        private List<Constraint> cacheContent;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintCache"/> class.
        /// Private constructor, protected from creating instance form outside.
        /// </summary>
        private ConstraintCache()
        {
            cacheContent = new List<Constraint>();
        }

        #endregion

        #region Singleton Holder

        /// <summary>
        /// SingletonHolder is loaded on the first execution of Singleton.getInstance()
        /// or the first access toStation SingletonHolder.INSTANCE, not before.
        /// </summary>
        private static class SingletonHolder 
        {
            static SingletonHolder() { }

            internal static readonly ConstraintCache INSTANCE = new ConstraintCache();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ConstraintCache getInstance()
        {
            return SingletonHolder.INSTANCE;
        }

        public void addConstraint(Constraint constraint)
        {
            cacheContent.Add(constraint);
        }

        public Constraint getContentOnSelect(int index1, int index2)
        {
            throw new System.NotImplementedException();
        }

        public Constraint getContentOnSelect(TrainLine trainLine1, TrainLine trainLine2)
        {
            throw new System.NotImplementedException();
        }

        public void clearContent()
        {
            cacheContent.Clear();
        }

        public void setCacheContent(List<Constraint> constraints) 
        {
            cacheContent = constraints;
        }

        public List<Constraint> getCacheContent() 
        {
            return cacheContent;
        }

        #endregion

        #region Private Methods

        public Constraint findConstraint(List<Constraint> contraints, int index1, int index2)
        {
            throw new System.NotImplementedException();
        }

        public Boolean doesConstraintExist(List<Constraint> constraints, int index1, int index2)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
