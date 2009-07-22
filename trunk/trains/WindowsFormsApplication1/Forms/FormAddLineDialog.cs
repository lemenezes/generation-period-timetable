using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using PeriodicTimetableGeneration.Util;

namespace PeriodicTimetableGeneration.Forms
{
    public partial class FormAddLinesDialog : Form
    {
        private ListView.ListViewItemCollection connectedLviLines;
        private TrainLine trainLine;
        private List<ListViewItem> addedLines;

        public FormAddLinesDialog()
        {
            InitializeComponent();
        }

        //public FormAddLineDialog(List<TrainLine> variableLines)
        //{
        //    InitializeComponent();
        //    connectedTrainLines = variableLines;
        //    ListView.ListViewItemCollection addedLines = new ListView.ListViewItemCollection();
        //}

        public FormAddLinesDialog(TrainLine line, ListView.ListViewItemCollection lviLines)
        {
            InitializeComponent();
            trainLine = line;
            addedLines = new List<ListViewItem>();
            connectedLviLines = lviLines;
        }

        public List<ListViewItem> AddedLines
        {
            get
            {
                return addedLines;
            }
            set
            {
            
            }
        }

        public List<ListViewItem> getAddedLines() 
        {
            return addedLines;
        }

        private void FormAddLineDialog_Shown(object sender, EventArgs e)
        {
            prepareListViewListOfTrainLines();
        }

        private void prepareListViewListOfTrainLines() 
        {
            // retreive trainLines off cache
            List<TrainLine> trainLines = TrainLineCache.getInstance().getCacheContent();

            listViewListOfTrainLines.BeginUpdate();

            listViewListOfTrainLines.Items.Clear();
            foreach (TrainLine line in trainLines)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = line.LineNumber.ToString();
                lvi.Tag = line.LineNumber.ToString();

                // if line_ is already contained as a connected line_ at trainLine1
                //if (TrainLineCache.doesLineExist(line_.LineNumber, trainLine1.getConnectedLines())) 
                // if line_ is already contained in ListView of connectedLines
                if (isAlreadyInListView(lvi.Tag, connectedLviLines))
                    // dont addConstraint, continue with next trainLine1
                    continue;
                // if line_ itself, continue with next trainLine1
                if (line.LineNumber.Equals(trainLine.LineNumber))
                    continue;
                    
                // otherwise copy information about line_ into list
                lvi.SubItems.Add(line.TypeTrain.ToString());
                lvi.SubItems.Add(line.Period.ToString());
                lvi.SubItems.Add(line.getFirstTrainStop().TrainStation.Name);
                lvi.SubItems.Add(line.getLastTrainStop().TrainStation.Name);

                listViewListOfTrainLines.Items.Add(lvi);
            }
            listViewListOfTrainLines.EndUpdate();
        }

        private Boolean isAlreadyInListView(Object key, ListView.ListViewItemCollection items)
        {
            Boolean exists = false;

            foreach (ListViewItem lvi in items)
                if (lvi.Tag.Equals(key))
                {
                    exists = true;
                    break;
                }
            return exists;
        }

        //--------------------------------
        // button CANCEL
        //--------------------------------

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //--------------------------------
        // button ADD
        //--------------------------------

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addLines();
        }

        private void addLines() 
        {
            // if no variableLines selected
            if (listViewListOfTrainLines.SelectedItems.Count.Equals(0))
            {
                MessageBox.Show("Please, select the line_(s).", "No variableLines selected");
            }
            // if something selected
            else
            {
                // clearStableLines off previous program run
                addedLines.Clear();
                // loop over all selected variableLines
                foreach (ListViewItem lvi in listViewListOfTrainLines.SelectedItems) 
                {
                    // addConstraint it to the output list
                    addedLines.Add(lvi);
                }

                // addConstraint variableLines and close
                this.Close();
            }
        }

        //-----------------------------------------------------------
        // ListViewListOf TRAIN LINES - ColumnClick - Sorting
        //-----------------------------------------------------------

        private void listViewListOfTrainLines_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FormUtil.listView_ColumnClick_Sorting(sender, e, this.listViewListOfTrainLines);
        }

    }
}
