using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// Class represent Constraint, which model relation between two lines.
    /// Implements appropriate methods for it.
    /// </summary>
    public class Constraint
    {

        #region Private Fields

        /// <summary>
        /// The discret set representing available times for train departure time.
        /// </summary>
        private Set set;
        /// <summary>
        /// TrainLine1
        /// </summary>
        private TrainLine trainLine1;
        /// <summary>
        /// TrainLine2
        /// </summary>
        private TrainLine trainLine2;
        /// <summary>
        /// The number related with Train1 as an index.
        /// </summary>
        private int index1;
        /// <summary>
        /// The number related with Train2 as an index.
        /// </summary>
        private int index2;
        /// <summary>
        /// Transfer related to this constraint
        /// </summary>
        private List<Transfer> transfer;
        /// <summary>
        /// Constant member related to trainLine1.
        /// </summary>
        private int constantMember1;
        /// <summary>
        /// Constant member related to trainLine2.
        /// </summary>
        private int constantMember2;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint"/> class.
        /// </summary>
        public Constraint()
        {
            setDefaultValues();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint"/> class.
        /// </summary>
        /// <param name="transfer_">The transfer.</param>
        public Constraint(Transfer transfer_) 
        {
            setDefaultValues();
            // initialize the transfer
            this.transfer.Add(transfer_);
            // first is a line, which transfers ON
            this.trainLine1 = transfer_.OnLine;
            // second is a line, which transfer OFF
            this.trainLine2 = transfer_.OffLine;
            // from train line get trainstop of tranfer, get arrival in minutes
            this.constantMember1 = this.trainLine1.getTrainStopOnStation(Transfer.Station.Name).TimeDepartureChecked.ToMinutes();
            this.constantMember2 = this.trainLine2.getTrainStopOnStation(Transfer.Station.Name).TimeArrivalChecked.ToMinutes();

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="modulo">The modulo.</param>
        public Constraint(ICollection<int> collection, int modulo)
        {
            setDefaultValues();
            this.set = new Set(collection, modulo);
            this.set.Modulo = modulo;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint"/> class.
        /// </summary>
        /// <param name="otherConstraint">The other constraint.</param>
        public Constraint(Constraint otherConstraint) 
        {
            setDefaultValues(); // not needed, because all fields will be assigned
            this.constantMember1 = otherConstraint.constantMember1;
            this.constantMember2 = otherConstraint.constantMember2;
            this.index1 = otherConstraint.index1;
            this.index2 = otherConstraint.index2;
            this.trainLine1 = otherConstraint.trainLine1;
            this.trainLine2 = otherConstraint.trainLine2;
            this.transfer.AddRange(otherConstraint.transfer);
            this.set = new Set(otherConstraint.DiscreteSet);
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Normalizes the constraint to the predefined format.
        /// </summary>
        public void normalizeConstraint()
        {
            // include minimal transter time, Set = {0,1,2,3}; MTT = 5 => {5,6,7,8}
            this.set.Addition(Transfer.Station.MinimalTransferTime.ToMinutes());
            // reduce constantMembers (x + cm1) - (y + cm2) .. {0..15} => set.additon(-cm1+cm2);
            this.set.Addition(this.constantMember2-this.constantMember1);
            // constantMembers are now zero
            this.constantMember1 = 0;
            this.constantMember2 = 0;
        }

        /// <summary>
        /// Merges the constraint with.
        /// </summary>
        /// <param name="otherConstraint">The other constraint.</param>
        public void mergeConstraintWith(Constraint otherConstraint) 
        {
            // addition constant members
            this.constantMember1 += otherConstraint.constantMember1;
            this.constantMember2 += otherConstraint.constantMember2;
            // intersects discrete set of appropriate constraints
            this.DiscreteSet.MergeWith(otherConstraint.DiscreteSet);
            
        }

        /// <summary>
        /// Reverses the constraint (as multiply by -1).
        /// </summary>
        public void reverseConstraint()
        {
            int tempInt;
            // swap indices in matrices
            tempInt = index1;
            index1 = index2;
            index2 = tempInt;

            // swap constant matrix - related to train lines
            tempInt = constantMember1;
            constantMember1 = constantMember2;
            constantMember2 = tempInt;

            TrainLine tempTL;
            // swap train lines
            tempTL = trainLine1;
            trainLine1 = trainLine2;
            trainLine2 = tempTL;

            // reverse DiscreteSet (minimization solutionFactor reverse included)
            DiscreteSet.Reverse();
        }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public Boolean isValid()
        {
            Boolean valid = true;
            if (set.isDiscreteSetEmpty())
                valid = false;
            return valid;
        }

        /*public Boolean equals(Constraint otherConstraint)
        {
            throw new System.NotImplementedException();
        }*/

        /// <summary>
        /// Determined whether this instance is equivalent the with other.
        /// </summary>
        /// <param name="otherConstraint">The other constraint.</param>
        /// <returns></returns>
        public Boolean equivalentWith(Constraint otherConstraint) 
        {
            Boolean equivalent = false;
            // other1 == this1 && other2 == this2
            if(otherConstraint.TrainLineNumber1.Equals(this.TrainLineNumber1)
                && otherConstraint.TrainLineNumber2.Equals(this.TrainLineNumber2))
                equivalent = true;
            // or other1 == this2 && other2 == this1
            else if(otherConstraint.TrainLineNumber1.Equals(this.TrainLineNumber2)
                && otherConstraint.TrainLineNumber2.Equals(this.TrainLineNumber1))
                equivalent = true;

            return equivalent;
        }

        /// <summary>
        /// Determined whether this instance is equivalent on pair of lines the with other.
        /// </summary>
        /// <param name="otherConstraint">The other constraint.</param>
        /// <returns></returns>
        public Boolean equivalentPairWith(Constraint otherConstraint) 
        {
            Boolean equivalentPair = false;
            if (otherConstraint.TrainLineNumber1.Equals(this.TrainLineNumber1)
                && otherConstraint.TrainLineNumber2.Equals(this.TrainLineNumber2)) 
            {
                equivalentPair = true;
            }
            return equivalentPair;
        }

        /// <summary>
        /// Clones this instance. Deep clone.
        /// </summary>
        /// <returns></returns>
        public Constraint clone()
        {
            return new Constraint(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the discrete set.
        /// </summary>
        /// <value>The discrete set.</value>
        public Set DiscreteSet 
        {
            get 
            {
                return this.set;
            }
            set 
            {
                this.set = value;
            }
        }

        /// <summary>
        /// Gets or sets the index1 (related to trainLine1).
        /// </summary>
        /// <value>The index.</value>
        public int Index1
        {
            get
            {
                return index1;
            }
            set
            {
                index1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the index2 (related to trainLine2).
        /// </summary>
        /// <value>The index.</value>
        public int Index2
        {
            get
            {
                return index2;
            }
            set
            {
                index2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the trainLine1.
        /// </summary>
        /// <value>The train line.</value>
        public TrainLine TrainLine1
        {
            get
            {
                return trainLine1;
            }
            set
            {
                trainLine1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the trainLine2.
        /// </summary>
        /// <value>The train line.</value>
        public TrainLine TrainLine2
        {
            get
            {
                return trainLine2;
            }
            set
            {
                trainLine2 = value;
            }
        }

        /// <summary>
        /// Gets the train line' number1.
        /// </summary>
        /// <value>The train line' number.</value>
        public int TrainLineNumber1
        {
            get
            {
                return trainLine1.LineNumber;
            }
        }

        /// <summary>
        /// Gets the train line' number2.
        /// </summary>
        /// <value>The train line' number.</value>
        public int TrainLineNumber2
        {
            get
            {
                return trainLine2.LineNumber;
            }
        }

        /// <summary>
        /// Gets the transfer.
        /// </summary>
        /// <value>The transfer.</value>
        public Transfer Transfer
        {
            get
            {
                Transfer trans = null;
                if(!transfer.Count.Equals(0))
                    trans = this.transfer[0];
                return trans;
            }
        }

        /// <summary>
        /// Gets the modulo.
        /// </summary>
        /// <value>The modulo.</value>
        public int Modulo 
        {
            get 
            {
                return set.Modulo;
            }
        }

        /// <summary>
        /// Gets or sets the constant member1 (related to trainLine1).
        /// </summary>
        /// <value>The constant member.</value>
        public int ConstantMember1
        {
            get
            {
                return this.constantMember1;
            }
            set
            {
                this.constantMember1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the constant member2 (related to trainLine).
        /// </summary>
        /// <value>The constant member.</value>
        public int ConstantMember2 
        {
            get 
            {
                return this.constantMember2;
            }
            set 
            {
                this.constantMember2 = value;
            }
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Sets the default values of fields.
        /// </summary>
        private void setDefaultValues()
        {
            this.index1 = -1;
            this.index2 = -1;
            this.set = null;
            this.trainLine1 = null;
            this.trainLine2 = null;
            this.constantMember1 = 0;
            this.constantMember2 = 0;
            this.transfer = new List<Transfer>();
        }

        #endregion
    }
}
