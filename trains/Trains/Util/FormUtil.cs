using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeriodicTimetableGeneration;
using System.Collections;

namespace PeriodicTimetableGeneration.Util
{
    class FormUtil
    {

        /// <summary>
        /// Sorts ListView items using MergeSort.
        /// Invokes after click on column of ListView.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ColumnClickEventArgs"/> instance containing the event data.</param>
        /// <param name="listView">The list view.</param>
        public static void listView_ColumnClick_Sorting(object sender, ColumnClickEventArgs e, ListView listView)
        {
            // Create an instance of the ColHeader class.
            ColHeader clickedCol = (ColHeader)listView.Columns[e.Column];

            // Set the ascending property to sort in the opposite order.
            clickedCol.ascending = !clickedCol.ascending;

            // Get the number of items in the list.
            int numItems = listView.Items.Count;

            // Turn off display while data is repoplulated.
            listView.BeginUpdate();

            // Populate an ArrayList with a SortWrapper of each list item.
            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(listView.Items[i], e.Column));
            }

            // Sort the elements in the ArrayList using a new instance of the SortComparer
            // class. The parameters are the starting index, the length of the range to sort,
            // and the IComparer implementation to use for comparing elements. Note that
            // the IComparer implementation (SortComparer) requires the sort
            // direction for its constructor; true if ascending, othwise false.
            //SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.ascending));
            MergeSort.Sort(SortArray, 0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.ascending, clickedCol.SortType));

            // Clear the list, and repopulate with the sorted items.
            listView.Items.Clear();
            for (int i = 0; i < numItems; i++)
                listView.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            // Turn display back on.
            listView.EndUpdate();
        }

        /// <summary>
        /// Refreshes the selection and focus on item in ListView.
        /// </summary>
        /// <param name="listView">The ListView.</param>
        /// <param name="selectedIndex">Index of the selected item.</param>
        public static void listView_SelecdAndFocus(ListView listView, int selectedIndex) 
        {
            listView.BeginUpdate();

            listView.Items[selectedIndex].Selected = true;
            listView.Select();
            listView.EnsureVisible(selectedIndex);
            listView.Focus();

            //listViewListOfStations.Items[selectedIndex].EnsureVisible();
            //listViewListOfStations.Items[selectedIndex].Checked = true;                    
            //listViewListOfStations.Items[selectedIndex].Focused = true;

            listView.EndUpdate();  

        }

    }
}
