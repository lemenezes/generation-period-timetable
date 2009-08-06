using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PeriodicTimetableGeneration.Util
{
    public class MergeSort
    {
        /// <summary>
        /// Private method sorts the array (items in array). 
        /// Implements merge sort.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="endIndex">The end index.</param>
        /// <param name="comparer">The comparer.</param>
        private static void InternalSort(ArrayList array, int startIndex, int endIndex, IComparer comparer)
        {
            if (startIndex == endIndex) 
            {
                return; // nothing to do
            }

            // recurse sorting
            int length = endIndex - startIndex + 1;
            int pivot = (startIndex + endIndex) / 2;
            InternalSort(array, startIndex, pivot, comparer);
            InternalSort(array, pivot + 1, endIndex, comparer);

            // execute merge sort
            //object[] working = new ArrayList(length;      
            //ArrayList.Copy(array, startIndex, working, 0, length);  //createConstraintSet a copy of array during merging
            ArrayList working = (ArrayList) array.GetRange(startIndex, length).Clone();

            // pointers inside the parts of array
            int m1 = 0;     // left part
            int m2 = pivot - startIndex + 1;    // right part

            for (int i = 0; i < length; ++i)
            {   // m2 is at the end (right part is empty)
                if (m2 <= (endIndex - startIndex)) 
                {   // m1 is at the end (left part is empty)
                    if (m1 <= (pivot - startIndex))
                    {
                        // compare first items in the parts
                        if (0 < comparer.Compare(working[m1], working[m2])) 
                        {
                            // if items on m1 > items on m2, than copy m2
                            //array.SetValue(working[m2++], startIndex + i);
                            array[startIndex + i] = working[m2++];
                        } 
                        else
                        {
                            // otherwise copy m1
                            //array.SetValue(working[m1++], startIndex + i);
                            array[startIndex + i] = working[m1++];
                        }
                    }
                    else
                    {
                        // just copy the items of the right part
                        //array.SetValue(working[m2++], startIndex + i);
                        array[startIndex + i] = working[m2++];
                    }
                } 
                else
                {
                    // just copy the items of left part
                    //array.SetValue(working[m1++], startIndex + i);
                    array[startIndex + i] = working[m1++];
                }
            }
        }

        #region Methods

        /// <summary>
        /// Sorts the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        public static void Sort(ArrayList array)
        {
            Sort(array, Comparer.Default);
        }

        /// <summary>
        /// Sorts the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        public static void Sort(ArrayList array, IComparer comparer)
        {
            Sort(array, 0, array.Count, comparer);
        }

        /// <summary>
        /// Sorts the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        public static void Sort(ArrayList array, int index, int length)
        {
            Sort(array, index, length, Comparer.Default);
        }

        /// <summary>
        /// Sorts the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        /// <param name="comparer">The comparer.</param>
        public static void Sort(ArrayList array, int index, int length, IComparer comparer)
        {
            if (null == array)
            {
                throw new ArgumentNullException("array");
            }

            if (0 > length) 
            {
                throw new ArgumentOutOfRangeException("length");
            }

            if ((array.Count - length) < index) 
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (length <= 1) 
            {
                return; // nothing to do
            }

            InternalSort(array, index, (index + length) - 1, comparer);
        }

        #endregion // Methods


    }
    
}
