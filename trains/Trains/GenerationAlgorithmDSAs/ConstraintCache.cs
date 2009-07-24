using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Class represents a cache for Constraints and implements appropriate methods.
    /// </summary>
    public class ConstraintCache
    {
        #region Private Variables

        /// <summary>
        /// Cache content.
        /// </summary>
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

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ConstraintCache getInstance()
        {
            return SingletonHolder.INSTANCE;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// Adds the constraint to cache.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        public void addConstraint(Constraint constraint)
        {
            cacheContent.Add(constraint);
        }

        /// <summary>
        /// Gets the content on select.
        /// </summary>
        /// <param name="index1">The index X.</param>
        /// <param name="index2">The index Y.</param>
        /// <returns></returns>
        public Constraint getContentOnSelect(int index1, int index2)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the content on select.
        /// </summary>
        /// <param name="trainLine1">The train line1.</param>
        /// <param name="trainLine2">The train line2.</param>
        /// <returns></returns>
        public Constraint getContentOnSelect(TrainLine trainLine1, TrainLine trainLine2)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Clears the content.
        /// </summary>
        public void clearContent()
        {
            cacheContent.Clear();
        }

        /// <summary>
        /// Sets the content of the cache.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        public void setCacheContent(List<Constraint> constraints) 
        {
            cacheContent = constraints;
        }

        /// <summary>
        /// Gets the content of the cache.
        /// </summary>
        /// <returns></returns>
        public List<Constraint> getCacheContent() 
        {
            return cacheContent;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Finds the constraint in specified constraints.
        /// </summary>
        /// <param name="contraints">The contraints.</param>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        /// <returns></returns>
        public Constraint findConstraint(List<Constraint> contraints, int index1, int index2)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determine, whether the constraint exists within the specified constraints.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        /// <returns></returns>
        public Boolean doesConstraintExist(List<Constraint> constraints, int index1, int index2)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
