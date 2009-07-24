using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PeriodicTimetableGeneration
{

    /// <summary>
    /// Interface that specifies a Set. Only one instance of an object
    /// will exist in an ISet even if it is added multiple times. An ISet
    /// is not ordered.
    /// </summary>
    public interface ISet
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Set"/> class.
        /// Suggested Constructor takes an ICollection<int>.
        /// </summary>
        /// <param name="objects">The objects of ICollection.</param>
        /// <param name="modulo">The modulo.</param>
        // Set(ICollection<int> objects, int modulo);

        /// <summary>
        /// Add an item to the ISet.
        /// </summary>
        /// <param name="anObject"></param>
        /// /// <returns>true if the element is added to the Set object; false if the element is already present.</returns>
        Boolean Add(object anObject);

        /// <summary>
        /// Adds the specified item to ISet with specific value.
        /// </summary>
        /// <param name="anObject">An object.</param>
        /// <param name="value">The value.</param>
        /// <returns>true if the element is added to the Set object; false if the element is already present.</returns>
        Boolean Add(object anObject, int value);

        /// <summary>
        /// Add the specified items to the ISet.
        /// </summary>
        /// <param name="objects">The objects.</param>
        void AddRange(ICollection objects);

        /*    
		/// <summary>
        /// Adds an item, with key and value, to ISet, especially to the minimization solutionFactor hashtable.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void AddFactor(int key, int value); 

        /// <summary>
        /// Adds the specified items to the ISet, especially to the minimization solutionFactor hashtable.
        /// </summary>
        /// <param name="objects">The objects.</param>
        void AddFactorRange(IDictionary objects);   
		 */

        /// <summary>
        /// Remove all items from the ISet.
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines whether the ISet contains the specified item.
        /// </summary>
        /// <param name="anObject"></param>
        /// <returns></returns>
        bool Contains(int anObject);

        /// <summary>
        /// Removes the specified item from the ISet.
        /// </summary>
        /// <param name="anObject"></param>
        void Remove(int anObject);

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        String ToString();

        /// <summary>
        /// Compute the set Excepts the with the other set.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        void ExceptWith(Set otherSet);

        /// <summary>
        /// Compute the set Intersects the with other set.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        void IntersectWith(Set otherSet);

        /// <summary>
        /// Determines whether [is proper subset of] [the specified other set].
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns>
        /// 	<c>true</c> if [is proper subset of] [the specified other set]; otherwise, <c>false</c>.
        /// </returns>
        Boolean IsProperSubsetOf(Set otherSet);

        /// <summary>
        /// Determines whether [is proper superset of] [the specified other set].
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns>
        /// 	<c>true</c> if [is proper superset of] [the specified other set]; otherwise, <c>false</c>.
        /// </returns>
        Boolean IsProperSupersetOf(Set otherSet);

        /// <summary>
        /// Determines whether [is subset of] [the specified other set].
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns>
        /// 	<c>true</c> if [is subset of] [the specified other set]; otherwise, <c>false</c>.
        /// </returns>
        Boolean IsSubsetOf(Set otherSet);

        /// <summary>
        /// Determines whether [is superset of] [the specified other set].
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns>
        /// 	<c>true</c> if [is superset of] [the specified other set]; otherwise, <c>false</c>.
        /// </returns>
        Boolean IsSupersetOf(Set otherSet);

        /// <summary>
        /// Determines whether the set Overlaps the specified other set.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns></returns>
        Boolean Overlaps(Set otherSet);

        /// <summary>
        /// Compute the set Unions the with other set.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        void UnionWith(Set otherSet);

    }

    /// <summary>
    /// Class represents a set for calculation process of algorithm.
    /// Used as a private fields in instance of class Constraint.
    /// </summary>
    public class Set : ISet
    {
        #region Private Fields

        /// <summary>
        /// Left bracket used for ToString implementation.
        /// </summary>
        private String BRACKET_LEFT = "{";
        /// <summary>
        /// Right bracket used for ToString implementation.
        /// </summary>
        private String BRACKET_RIGHT = "}";
        /// <summary>
        /// Delimiter used for ToString implementation.
        /// </summary>
        private String SET_DELIMITER = ", ";
        /// <summary>
        /// Default modulo (Z_120).
        /// </summary>
        private const int MODULO_DEFAULT = 120;
        /// <summary>
        /// Hastable for set and its appropriate minimization solutionFactor value.
        /// </summary>
        private IDictionary<int, int> minimizationFactor;
        /// <summary>
        /// Hashset represents items of the Set.
        /// </summary>
        private HashSet<int> mySet;
        /// <summary>
        /// Modulo (Z_120).
        /// </summary>
        private int modulo;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Set"/> class.
        /// </summary>
        /// <param name="modulo_">The modulo.</param>
        public Set(int modulo_)
        {
            setDefaultValues();
            this.modulo = modulo_;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Set"/> class.
        /// </summary>
        /// <param name="objects">The objects of ICollection.</param>
        /// <param name="modulo">The modulo.</param>
        public Set(IEnumerable<int> objects, int modulo)
        {
            setDefaultValues();
            this.modulo = modulo;
            this.mySet = new HashSet<int>(objects);
            //AddRange(objects);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Set"/> class.
        /// Copy constructor.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        public Set(Set otherSet)
        {
            setDefaultValues();
            if (otherSet != null)
            {
                this.modulo = otherSet.modulo;
                // for adding range of new items, i can create new instances by copy construtor
                this.mySet = new HashSet<int>(otherSet.DiscreteSet);
                this.minimizationFactor = new Dictionary<int, int>(otherSet.MinimizationFactor);
                //AddRange(otherSet.getContentSet());
                //AddFactorRange(otherSet.getContentMinimizationFactor());
            }
        }

        #endregion

        #region ISet Members

        /// <summary>
        /// Add an item to the ISet.
        /// </summary>
        /// <param name="anObject"></param>
        /// <returns>
        /// true if the element is added to the Set object; false if the element is already present.
        /// </returns>
        public Boolean Add(object anObject)
        {
            Boolean added = false;
            if (anObject is int && !mySet.Contains((int)anObject))
            {
                this.mySet.Add((int)anObject);
                added = true;
            }
            return added;
        }

        /// <summary>
        /// Adds the specified item to ISet with specific value.
        /// </summary>
        /// <param name="anObject">An object.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// true if the element is added to the Set object; false if the element is already present.
        /// </returns>
        public Boolean Add(object anObject, int value)
        {
            Boolean added;
            if (added = Add(anObject) && anObject is int)
            {
                AddFactor((int)anObject, value);
            }
            return added;
        }

        /// <summary>
        /// Add the specified items to the ISet.
        /// </summary>
        /// <param name="objects">ICollection of objects.</param>
        public void AddRange(ICollection objects)
        {
            foreach (object obj in objects) Add(obj);
        }

        /// <summary>
        /// Adds the range of specified items.
        /// </summary>
        /// <param name="set">The set.</param>
        private void AddRange(HashSet<int> set)
        {
            foreach (int i in set)
                this.mySet.Add(i);
        }

        /// <summary>
        /// Adds the solutionFactor value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddFactor(int key, int value)
        {
            this.minimizationFactor.Add(key, value);
        }

        /// <summary>
        /// Adds the solutionFactor range.
        /// </summary>
        /// <param name="objects">The objects.</param>
        public void AddFactorRange(IDictionary<int, int> objects)
        {
            foreach (int i in objects.Keys)
                AddFactor(i, (int)objects[i]);
        }

        /// <summary>
        /// Remove all items from the ISet.
        /// </summary>
        public void Clear()
        {
            this.mySet.Clear();
        }

        /// <summary>
        /// Determines whether the ISet contains the specified item.
        /// </summary>
        /// <param name="anObject">The item.</param>
        /// <returns>True if contains, otherwise false.</returns>
        public bool Contains(int anObject)
        {
            return this.mySet.Contains(anObject);
        }

        /// <summary>
        /// Removes the specified item from the ISet.
        /// </summary>
        /// <param name="anObject"></param>
        public void Remove(int anObject)
        {
            this.mySet.Remove(anObject);
            this.minimizationFactor.Remove(anObject);
        }

        /// <summary>
        /// Removes the reverse item of specified item from the ISet.
        /// </summary>
        /// <param name="minute">The minute.</param>
        public void RemoveReverse(int minute)
        {
            this.Remove(reverseNumberModulo(minute, modulo));
        }

        /// <summary>
        /// Finds a key value pair from minimization factor dictionary, with minimum factor.
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<int, int> Min()
        {
            KeyValuePair<int, int> currentMin = new KeyValuePair<int,int>(-1, int.MaxValue);

            foreach (KeyValuePair<int, int> factorPair in this.minimizationFactor)
            {
                if (currentMin.Value > factorPair.Value)
                {
                    currentMin = factorPair;
                }
            }

            return currentMin;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the content of set.
        /// </summary>
        /// <returns>Discrete set.</returns>
        public HashSet<int> getContentSet()
        {
            return this.mySet;
        }

        /// <summary>
        /// Gets the content of minimization solutionFactor.
        /// </summary>
        /// <returns>Minimization solutionFactor.</returns>
        public IDictionary<int, int> getContentMinimizationFactor()
        {
            return this.minimizationFactor;
        }

        /// <summary>
        /// Determines whether [is discrete set empty].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is discrete set empty]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean isDiscreteSetEmpty()
        {
            return mySet.Count.Equals(0);
        }

        /// <summary>
        /// Creates the minimization solutionFactor for all items of set.
        /// </summary>
        /// <param name="passengers">The passengers.</param>
        public void createMinimizationFactor(int passengers)
        {
            List<int> array = new List<int>();
            IDictionary<int, int> minFactor = new Dictionary<int, int>();

            // extract all items from my discreteSet
            foreach (int i in mySet)
            {
                array.Add(i);
            }
            // sort all items
            array.Sort();
            // create minimizationFactor
            for (int j = 0; j < array.Count; j++)
            {
                // a new minFactor item: item as key, j*passengers as a value
                minFactor.Add(array[j], j * passengers);
            }
            // assign a fields
            this.minimizationFactor = minFactor;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override String ToString()
        {
            String str;
            List<int> array = new List<int>();

            // extract all items from my discreteSet
            foreach (int i in mySet)
            {
                array.Add(i);
            }
            // sort all items
            array.Sort();
            // loop over all item
            Boolean first = true;
            // add left bracket
            str = BRACKET_LEFT;
            foreach (int item in array)
            {
                if (first)
                    // if first item, no delimiter
                    first = false;
                else
                    // otherwise add delimiter first
                    str += SET_DELIMITER;

                // add item
                str += item;
            }
            // add right bracket
            str += BRACKET_RIGHT;

            return str;
        }

        /// <summary>
        /// Clones this instance. Deep clone.
        /// </summary>
        /// <returns></returns>
        public Set clone() 
        {
            return new Set(this);
        }

        #endregion

        #region ISet Operators

        /// <summary>
        /// Compute the set Excepts the with the other set.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        public void ExceptWith(Set otherSet)
        {
            mySet.ExceptWith(otherSet.getContentSet());
        }

        /// <summary>
        /// Compute the set Intersects the with other set.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        public void IntersectWith(Set otherSet)
        {
            // intersects discrete set in hashset implementation
            this.mySet.IntersectWith(otherSet.getContentSet());
            // create a new Dictionary for minFactor
            Dictionary<int, int> minFactor = new Dictionary<int, int>();
            // loop over all new items in discrete set O(all new items)
            foreach (int item in this.mySet) 
            {    
                // create new minFactor only with the values contained in discrete set.
                int newFactor = this.minimizationFactor[item] + otherSet.minimizationFactor[item];
                minFactor.Add(item, newFactor);
            }


            /*  // replaced, coz: all_old_keys > all_new_items
             // loop over all keys in old minFactor  O(all old keys)
            foreach (int item in this.minimizationFactor.Keys) 
            {
                if (this.mySet.Contains(item))
                {
                    minFactor.Add(item, this.minimizationFactor[item]);
                }
            }*/

            this.minimizationFactor = minFactor;
        }

        /// <summary>
        /// Determines whether [is proper subset of] [the specified other set].
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns>
        /// 	<c>true</c> if [is proper subset of] [the specified other set]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsProperSubsetOf(Set otherSet)
        {
            return this.mySet.IsProperSubsetOf(otherSet.getContentSet());
        }

        /// <summary>
        /// Determines whether [is proper superset of] [the specified other set].
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns>
        /// 	<c>true</c> if [is proper superset of] [the specified other set]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsProperSupersetOf(Set otherSet)
        {
            return this.mySet.IsProperSupersetOf(otherSet.getContentSet());
        }


        /// <summary>
        /// Determines whether [is subset of] [the specified other set].
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns>
        /// 	<c>true</c> if [is subset of] [the specified other set]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsSubsetOf(Set otherSet)
        {
            return this.mySet.IsSubsetOf(otherSet.getContentSet());
        }

        /// <summary>
        /// Determines whether [is superset of] [the specified other set].
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns>
        /// 	<c>true</c> if [is superset of] [the specified other set]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsSupersetOf(Set otherSet)
        {
            return this.mySet.IsSupersetOf(otherSet.getContentSet());
        }

        /// <summary>
        /// Determines whether the set Overlaps the specified other set.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        /// <returns></returns>
        public Boolean Overlaps(Set otherSet)
        {
            return this.mySet.Overlaps(otherSet.getContentSet());
        }

        /// <summary>
        /// Compute the set Unions the with other set.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        public void UnionWith(Set otherSet)
        {
            // union of discrete sets
            this.mySet.UnionWith(otherSet.getContentSet());
            // union of minimization solutionFactor            
            foreach (int item in otherSet.MinimizationFactor.Keys)
            {
                // if doesn't contain a key, then add
                if (!this.minimizationFactor.ContainsKey(item))
                {
                    this.minimizationFactor.Add(item, otherSet.MinimizationFactor[item]);
                }
            }
            
        }

        /// <summary>
        /// Compute the Addition operation with the specified other set.
        /// </summary>
        /// <param name="otherSet">The other set.</param>
        public void Addition(Set otherSet)
        {
            Set newSet = Addition(this, otherSet);
            this.DiscreteSet = newSet.DiscreteSet;
            this.MinimizationFactor = newSet.MinimizationFactor;
        }

        /// <summary>
        /// Compute the Addition operation with the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        public void Addition(int number)
        {
            Set newSet = Addition(this, number);
            this.DiscreteSet = newSet.DiscreteSet;
            this.MinimizationFactor = newSet.MinimizationFactor;
        }

        /// <summary>
        /// Reverses the content of this instance.
        /// A:Set; {0}-A : ReverseSet.
        /// </summary>
        public void Reverse()
        {
            HashSet<int> discretSet = new HashSet<int>();
            Dictionary<int, int> minFactor = new Dictionary<int, int>();
            foreach (int item in this.mySet)
            {
                int reverseItem = reverseNumberModulo(item, modulo);
                // reverse the item in set
                discretSet.Add(reverseItem);
                // retreive old value and add to the new hastable
                if (minimizationFactor.ContainsKey(item))
                {
                    minFactor.Add(reverseItem, minimizationFactor[item]);
                }
                // change a key in minimalizaion solutionFactor hashtable, where the item is a key
                // changeKeyInMinimizationFactor(item, this.modulo-item);
            }
            mySet = discretSet;
            minimizationFactor = minFactor;
        }

        #endregion

        #region ISet Global Opertator

        /// <summary>
        /// Compute the set Excepts one set the with othe.r
        /// </summary>
        /// <param name="oneSet">The one set.</param>
        /// <param name="otherSet">The other set.</param>
        /// <returns></returns>
        public static Set ExceptWith(Set oneSet, Set otherSet)
        {
            Set newSet = new Set(oneSet);
            newSet.ExceptWith(otherSet);
            return newSet;
        }

        /// <summary>
        /// Intersects the with.
        /// </summary>
        /// <param name="oneSet">The one set.</param>
        /// <param name="otherSet">The other set.</param>
        /// <returns></returns>
        public static Set IntersectWith(Set oneSet, Set otherSet)
        {
            Set newSet = new Set(oneSet);
            newSet.IntersectWith(otherSet);
            return newSet;
        }

        public static Boolean IsProperSubsetOf(Set oneSet, Set otherSet)
        {
            //Set newSet = new Set(oneSet);
            return oneSet.IsProperSubsetOf(otherSet);
        }

        public static Boolean IsProperSupersetOf(Set oneSet, Set otherSet)
        {
            //Set newSet = new Set(oneSet);
            return oneSet.IsProperSupersetOf(otherSet);
        }

        public static Boolean IsSubsetOf(Set oneSet, Set otherSet)
        {
            //Set newSet = new Set(oneSet);
            return oneSet.IsSubsetOf(otherSet);
        }

        public static Boolean IsSupersetOf(Set oneSet, Set otherSet)
        {
            //Set newSet = new Set(oneSet);
            return oneSet.IsSupersetOf(otherSet);
        }

        public static Boolean Overlaps(Set oneSet, Set otherSet)
        {
            return oneSet.Overlaps(otherSet);
        }

        public static Set UnionWith(Set oneSet, Set otherSet)
        {
            Set newSet = new Set(oneSet);
            newSet.UnionWith(otherSet);
            return newSet;
        }

        /// <summary>
        /// Compute the Addition operation between the specified two set.
        /// </summary>
        /// <param name="oneSet">The one set.</param>
        /// <param name="otherSet">The other set.</param>
        /// <returns>The set.</returns>
        public static Set Addition(Set oneSet, Set otherSet)
        {
            // newSet which will be as a result of this operator
            Set newSet = new Set(oneSet.Modulo);
            int newItem;
            int newFactor = 1;

            // Optimization: if |M1| + |M2| > modulo -> |M1| + |M2| = {0..modulo}
            if (oneSet.Count + otherSet.Count > oneSet.Modulo)
            {
                newSet.AddRange(GenerationAlgorithmDSAUtil.createSequenceOfNumber(oneSet.Modulo));
                return newSet;
            }

            // for each pair item1 and item2 calculate new item
            foreach (int item1 in oneSet.DiscreteSet)
                foreach (int item2 in otherSet.DiscreteSet)
                {
                    // calculate the new item
                    newItem = modifyNumberModulo((item1 + item2), oneSet.Modulo);
                    // calculate the new solutionFactor, NOT NEEDED a MinFactor
                    /*
                    if (oneSet.MinimizationFactor.ContainsKey(item1) && otherSet.MinimizationFactor.ContainsKey(item2))
                    {
                        newFactor = (int)oneSet.MinimizationFactor[item1] + (int)otherSet.MinimizationFactor[item2];
                    }
                    else if (oneSet.MinimizationFactor.ContainsKey(item1))
                    {
                        newFactor = (int)oneSet.MinimizationFactor[item1];
                    }
                    else if (otherSet.MinimizationFactor.ContainsKey(item2))
                    {
                        newFactor = (int)otherSet.MinimizationFactor[item2];
                    }
                    else
                    { 
                        newSet.Add(newItem); 
                        continue; 
                    }
                    */
                    //newSet.Add(newItem, newFactor);
                    newSet.Add(newItem);
                }

            return newSet;
        }

        /// <summary>
        /// Compute the Addition operation on set with the specified number.
        /// </summary>
        /// <param name="set">The set.</param>
        /// <param name="number">The number.</param>
        /// <returns>The set.</returns>
        public static Set Addition(Set set, int number)
        {
            // create a new set
            Set newSet = new Set(set.Modulo);
            int newItem;
            // loop over all items in discrete set
            foreach (int item in set.DiscreteSet)
            {
                // modify item
                newItem = modifyNumberModulo((item + number), set.Modulo);
                // add to new set, also with previous minFactor
                newSet.Add(newItem, set.MinimizationFactor[item]);
            }
            return newSet;
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Gets the count of items in Set.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return this.mySet.Count;
            }
        }

        /// <summary>
        /// Copies the elements to an array, starting at the specified array index. 
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        public void CopyTo(int[] array, int index)
        {
            this.mySet.CopyTo(array, index);
        }

        #endregion

        #region Property Members

        /// <summary>
        /// Gets or sets the modulo.
        /// </summary>
        /// <value>The modulo.</value>
        public int Modulo
        {
            get
            {
                return modulo;
            }
            set
            {
                modulo = value;
            }
        }

        /// <summary>
        /// Gets or sets the discrete set.
        /// </summary>
        /// <value>The discrete set.</value>
        public HashSet<int> DiscreteSet
        {
            get
            {
                return mySet;
            }
            set
            {
                mySet = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimization solutionFactor.
        /// </summary>
        /// <value>The minimization solutionFactor.</value>
        public IDictionary<int, int> MinimizationFactor
        {
            get
            {
                return minimizationFactor;
            }
            set
            {
                minimizationFactor = value;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Gets the enumerator that iterate throughs discrete set (HashSet).
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return this.mySet.GetEnumerator();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Checks all items of the set, whether they are non negative intigers and all in Zmodulo.
        /// </summary>
        /// <returns></returns>
        private Boolean checkSetModulo()
        {
            Boolean isOK = true;
            foreach (int i in this.mySet)
                if (i < 0 || i >= this.modulo)
                {
                    isOK = false;
                    break;
                }
            return isOK;
        }

        /// <summary>
        /// Updates the set modulo.
        /// </summary>
        private void updateSetModulo()
        {
            Boolean changed = false;
            HashSet<int> discreteSet = new HashSet<int>();

            foreach (int i in mySet)
                // if the item is not positive number within modulo, modify it
                if (i < 0 || i >= this.modulo)
                {
                    // index for
                    int index = i;
                    int newI = modifyNumberModulo(i, this.modulo);
                    // addConstraint to the new discrete set
                    discreteSet.Add(newI);
                    changeKeyInMinimizationFactor(index, newI);
                    changed = true;
                }
                else
                {
                    //otherwise, just addConstraint to the new discrete set
                    discreteSet.Add(i);
                }
            // if it was something change
            if (changed)
                // replace set with a new discrete set
                mySet = discreteSet;

        }

        /// <summary>
        /// Modifies the number with modulo operation.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="mod">The mod.</param>
        /// <returns></returns>
        private static int modifyNumberModulo(int number, int mod)
        {
            number %= mod;
            if (number < 0)
                number += mod;
            return number;
        }

        /// <summary>
        /// Reverses the number modulo.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="mod">The mod.</param>
        /// <returns></returns>
        private int reverseNumberModulo(int number, int mod)
        {
            return (mod - number) % mod;
        }

        /// <summary>
        /// Changes the item in set into new value.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        private void changeItemInSet(int oldValue, int newValue)
        {
            if (this.mySet.Contains(oldValue))
            {
                this.mySet.Remove(oldValue);
                this.mySet.Add(newValue);
            }
        }

        /// <summary>
        /// Changes the key in minimization solutionFactor into newKey and remain the same value.
        /// </summary>
        /// <param name="oldKey">The old key.</param>
        /// <param name="newKey">The new key.</param>
        private void changeKeyInMinimizationFactor(int oldKey, int newKey)
        {
            if (this.minimizationFactor.ContainsKey(oldKey))
            {
                int value = (int)this.minimizationFactor[oldKey];
                this.minimizationFactor.Remove(oldKey);
                this.minimizationFactor.Add(newKey, value);
            }
        }

        /// <summary>
        /// Sets the default values of fields.
        /// </summary>
        private void setDefaultValues()
        {
            this.modulo = MODULO_DEFAULT;
            this.mySet = new HashSet<int>();
            this.minimizationFactor = new Dictionary<int, int>();
        }

        #endregion


       
    }

}
