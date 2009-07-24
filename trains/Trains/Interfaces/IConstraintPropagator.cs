using System;
using System.Collections.Generic;
using System.Text;
using PeriodicTimetableGeneration.Interfaces.ConstraintSetsCreators;

namespace PeriodicTimetableGeneration.Interfaces
{
    /// <summary>
    /// Interface for constraint propagator.
    /// </summary>
	public interface IConstraintPropagator
	{
        /// <summary>
        /// Runs the propagation algorithm.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
		PropagationResult runPropagationAlgorithm(List<Constraint> constraints, int size);
	}

    namespace ConstraintPropagators
    {
        /// <summary>
        /// Bisection propagator implements the IConstraintPropagator interface.
        /// </summary>
        public class BisectionPropagator : IConstraintPropagator
        {

            #region Contraint sets creator

            /// <summary>
            /// Constraint set creator used in call of runPropagationAlgorithm method.
            /// </summary>
            private readonly IConstraintSetsCreator constraintSetsCreator;

            #endregion

            #region Default settings for the algorithm

            /// <summary>
            /// Default value for lower bound used in Bisection Algorithm.
            /// </summary>
            private const int LOWER_BOUND_DEFAULT = 0;

            /// <summary>
            /// Default value for upper bound used in Bisection Algorithm.
            /// </summary>
            private const int UPPER_BOUND_DEFAULT = 120;

            #endregion

            #region Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="BisectionPropagator"/> class.
            /// </summary>
            /// <param name="constraintSetsCreator">The constraint sets creator.</param>
            public BisectionPropagator(IConstraintSetsCreator constraintSetsCreator)
            {
                // initialize
                this.constraintSetsCreator = constraintSetsCreator;
            }

            #endregion


            #region IConstraintPropagator Members

            /// <summary>
            /// Runs the propagation algorithm.
            /// </summary>
            /// <param name="constraints">The constraints.</param>
            /// <param name="size">The size.</param>
            /// <returns></returns>
            public PropagationResult runPropagationAlgorithm(List<Constraint> constraints, int size)
            {
                // bisection algorithm is used for determine size of Sets and calls PropagationUtil.runPropagationAlgorithm
                return BisectionUtil.Bisect(constraints, this.ConstraintSetsCreator, LOWER_BOUND_DEFAULT, UPPER_BOUND_DEFAULT);
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the constraint sets creator.
            /// </summary>
            /// <value>The constraint sets creator.</value>
            protected IConstraintSetsCreator ConstraintSetsCreator
            {
                get
                {
                    return this.constraintSetsCreator;
                }
            }

            #endregion
        }

        /// <summary>
        /// Simple propagator implements IConstraintPropagator interface.
        /// </summary>
        public class SimplePropagator : IConstraintPropagator
        {
            #region Contraint sets creator

            /// <summary>
            /// Constraint set creator used in call of runPropagationAlgorithm method.
            /// </summary>
            private readonly IConstraintSetsCreator constraintSetsCreator;
           
            #endregion

            #region Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="SimplePropagator"/> class.
            /// </summary>
            /// <param name="constraintSetsCreator">The constraint sets creator.</param>
            public SimplePropagator(IConstraintSetsCreator constraintSetsCreator)
            {
                // initialize
                this.constraintSetsCreator = constraintSetsCreator;
            }

            #endregion


            #region IConstraintPropagator Members

            /// <summary>
            /// Runs the propagation algorithm.
            /// </summary>
            /// <param name="constraints">The constraints.</param>
            /// <param name="size">The size.</param>
            /// <returns></returns>
            public PropagationResult runPropagationAlgorithm(List<Constraint> constraints, int size)
            {
                // calls directly PropagationUtil.runPropagationAlgorithm
                return PropagationUtil.runPropagationAlgorithm(constraints, this.ConstraintSetsCreator, size);
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the constraint sets creator.
            /// </summary>
            /// <value>The constraint sets creator.</value>
            protected IConstraintSetsCreator ConstraintSetsCreator
            {
                get
                {
                    return this.constraintSetsCreator;
                }
            }

            #endregion
        }
    }
}
