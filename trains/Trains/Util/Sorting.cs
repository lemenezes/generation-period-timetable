using System.Collections;
using System.Windows.Forms;
using System;
using System.ComponentModel;

namespace PeriodicTimetableGeneration
{
    /// <summary>
    /// The ColHeader class is a ColumnHeader object with an
    /// added property for determining an ascending or descending sort.
    /// True specifies an ascending order, false specifies a descending order.
    /// </summary>
    public class ColHeader : ColumnHeader
    {

        public bool ascending;

        [Category("Sorting")]
        [DefaultValue(SortType.String)]
        public SortType SortType
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColHeader"/> class.
        /// </summary>
        public ColHeader()
            : this(SortType.String)
        {
        }

        public ColHeader(SortType sortType)
            : base()
        {
            this.SortType = sortType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColHeader"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="width">The width.</param>
        /// <param name="align">The align.</param>
        /// <param name="asc">true if ascending, otherwise descending</param>
        public ColHeader(string text, int width, HorizontalAlignment align, bool asc)
        {
            this.Text = text;
            this.Width = width;
            this.TextAlign = align;
            this.ascending = asc;
        }
    }

    public enum SortType
    {
        Integer,
        Date,
        String
    }

    /// <summary>
    /// An instance of the SortWrapper class is created for
    /// each item and added to the ArrayList for sorting.
    /// </summary>
    public class SortWrapper
    {
        internal ListViewItem sortItem;
        internal int sortColumn;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortWrapper"/> class.
        /// A SortWrapper requires the item and the index of the clicked column.
        /// </summary>
        /// <param name="Item">The item.</param>
        /// <param name="iColumn">The i column.</param>
        public SortWrapper(ListViewItem Item, int iColumn)
        {
            sortItem = Item;
            sortColumn = iColumn;
        }

        /// <summary>
        /// Gets the text of an item.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return sortItem.SubItems[sortColumn].Text;
            }
        }

        /// <summary>
        /// Implementation of the IComparer
        /// interface for sorting ArrayList items.
        /// </summary>
        public class SortComparer : IComparer
        {
            protected SortType sortType;

            bool ascending;

            /// <summary>
            /// Initializes a new instance of the <see cref="SortComparer"/> class.
            /// Constructor requires the sort order
            /// </summary>
            /// <param name="asc">True if ascending, otherwise descending.</param>
            public SortComparer(bool asc, SortType sortType)
            {
                this.ascending = asc;
                this.sortType = sortType;
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            /// <returns>
            /// Value Condition Less than zero <paramref name="x"/> is less than <paramref name="y"/>. Zero <paramref name="x"/> equals <paramref name="y"/>. Greater than zero <paramref name="x"/> is greater than <paramref name="y"/>.
            /// </returns>
            /// <exception cref="T:System.ArgumentException">Neither <paramref name="x"/> nor <paramref name="y"/> implements the <see cref="T:System.IComparable"/> interface.-or- <paramref name="x"/> and <paramref name="y"/> are of different types and neither one can handle comparisons with the other. </exception>
            public int Compare(object x, object y)
            {
                SortWrapper xItem = (SortWrapper)x;
                SortWrapper yItem = (SortWrapper)y;
                int res = 0;

                switch (sortType)
                {
                    case SortType.Integer:
                        res = Convert.ToInt32(xItem.sortItem.SubItems[xItem.sortColumn].Text) - Convert.ToInt32(yItem.sortItem.SubItems[yItem.sortColumn].Text);
                        break;

                    case SortType.Date:
                    case SortType.String:
                        string xText = xItem.sortItem.SubItems[xItem.sortColumn].Text;
                        string yText = yItem.sortItem.SubItems[yItem.sortColumn].Text;
                        res = xText.CompareTo(yText);
                        break;
                }

                return res * (this.ascending ? 1 : -1);
            }
        }
    }



}