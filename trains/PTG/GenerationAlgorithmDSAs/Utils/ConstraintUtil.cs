using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeriodicTimetableGeneration.GenerationAlgorithm;

namespace PeriodicTimetableGeneration.GenerationAlgorithmDSAs
{
    /// <summary>
    /// Class implements utility methods for Constraint.
    /// </summary>
    public static class ConstraintUtil
    {
        #region Create Methods

        /// <summary>
        /// Creates the constraint from transfer.
        /// </summary>
        /// <param name="transfer">The transfer.</param>
        /// <returns>The constraint.</returns>
        public static Constraint createConstraint(Transfer transfer)
        {
            return new TransferConstraint(transfer);
        }

        /// <summary>
        /// Creates the constraints from transfers.
        /// </summary>
        /// <param name="transfers">The transfers.</param>
        /// <returns>List of constraints.</returns>
        public static List<Constraint> createConstraints(List<Transfer> transfers)
        {
            List<Constraint> constraints = new List<Constraint>();

            foreach (Transfer transfer in transfers)
            {
                constraints.Add(createConstraint(transfer));
            }

            return constraints;
        }

        /// <summary>
        /// Creates the transfers on each line train line respectively.
        /// </summary>
        /// <returns>List of transfers.</returns>
        public static List<Transfer> retrieveTransfers()
        {
            // TODO: Retrieve from FinalInput.

            List<Transfer> transfers = FinalInput.getInstance().getCacheContent();

            //List<Transfer> transfers = new List<Transfer>();
            //foreach (TrainLine line in TrainLineCache.getInstance().getCacheContent())
            //{
            //    TransferUtil.createTransfers(line, transfers);
            //}

            return transfers;
        }

        #endregion

        #region Constraint Manipulating Methods

        /// <summary>
        /// Finds the equivalent constraints.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <returns>Groups of equivalent constraints.</returns>
        public static List<List<Constraint>> findEquivalentConstraints(List<Constraint> constraints)
        {
            List<List<Constraint>> equivalentConstraints = new List<List<Constraint>>();
            // loop over all appropriate constraints
            foreach (Constraint constraint in constraints)
            {
                // try to find equivalent group of constraint
                List<Constraint> group = findEquivalentConstraintGroup(equivalentConstraints, constraint);
                // if already exists group
                if (group != null)
                    // add constraint there
                    group.Add(constraint);
                // otherwise create new group and add it as a new member
                else
                {
                    group = new List<Constraint>();
                    group.Add(constraint);
                    equivalentConstraints.Add(group);
                }
            }
            // return List of List of equivalent constraints
            return equivalentConstraints;
        }

        /// <summary>
        /// Merges the equivalent constrains.
        /// </summary>
        /// <param name="constraints">The group of equivalent constraints.</param>
        /// <returns>List of constraints.</returns>
        public static List<Constraint> mergeEquivalentConstrains(List<List<Constraint>> constraints)
        {
            List<Constraint> mergedConstraints = new List<Constraint>();

            // loop over all equivalent groups
            foreach (List<Constraint> group in constraints)
            {
                // merge group into the one constraint and add
                mergedConstraints.Add(mergeEquivalentConstraintGroup(group));
            }

            return mergedConstraints;
        }

        /// <summary>
        /// Normalizes the constraints.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <returns>List of constraints.</returns>
        public static List<Constraint> normalizeConstraints(List<Constraint> constraints)
        {
            foreach (Constraint constraint in constraints)
            {
                constraint.normalizeConstraint();
            }
            return constraints;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Finds the group of equivalent constraints for specified constraint.
        /// </summary>
        /// <param name="equivalentConstraints">The groups of equivalent constraints.</param>
        /// <param name="constraint">The constraint.</param>
        /// <returns>The group of equivalent constraints.</returns>
        private static List<Constraint> findEquivalentConstraintGroup(List<List<Constraint>> equivalentConstraints, Constraint constraint)
        {
            List<Constraint> equivalentGroup = null;
            // loop over all lists of equivalent constraints
            foreach (List<Constraint> group in equivalentConstraints)
            {
                // if not empty compare with a first item of that list
                if (!group.Count.Equals(0) && group[0].equivalentWith(constraint))
                {
                    equivalentGroup = group;
                    break;
                }
            }

            // if it' s if not return null;
            return equivalentGroup;
        }

        /// <summary>
        /// Merges the equivalent constraint group into one constraintt.
        /// </summary>
        /// <param name="constraints">The list of constraints.</param>
        /// <returns>The constraint.</returns>
        private static Constraint mergeEquivalentConstraintGroup(List<Constraint> constraints)
        {
            Constraint mergedConstraint;
            // if empty, return null
            if (constraints.Equals(0))
                return null;
            // if not empty, dont merge
            else
            {
                // set the first initial constraint
                mergedConstraint = constraints[0];
                // and remove it from group
                constraints.RemoveAt(0);
            }

            // loop over all constraints in group
            foreach (Constraint constraint in constraints)
            {
                // if they are not pair equivalent, reverse
                if (!constraint.equivalentPairWith(mergedConstraint))
                {
                    constraint.reverseConstraint();
                }
                mergedConstraint.mergeConstraintWith(constraint);
            }

            return mergedConstraint;
        }

        #endregion


        public static IEnumerable<Constraint> createConstraints(List<TrainLine> trainLines)
        {
            List<Constraint> constraints = new List<Constraint>();

            foreach (TrainLine line in trainLines)
            {
                createConstraintsForLine(line, constraints);
            }

            return constraints;
        }

        private static void createConstraintsForLine(TrainLine line, List<Constraint> constraints)
        {
            foreach (TrainLine connectedLine in line.getConnectedLines())
            {
                // for every pair just one constraint is constructed
                if (connectedLine.LineNumber < line.LineNumber)
                {
                    constraints.Add(new ConnectedLineConstraint(connectedLine, line, (int)line.Period));
                }
            }
        }
    }
}
