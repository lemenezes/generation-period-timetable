using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeriodicTimetableGeneration.Forms;

namespace PeriodicTimetableGeneration
{
    public partial class FormDetailsOfLine : Form
    {
        TrainLine trainLine;
        //Form parentForm;
        ListViewItem lviTrainStop;
        private const String CHANGED = "changed";

        public FormDetailsOfLine()
        {
            InitializeComponent();
        }

        public FormDetailsOfLine(TrainLine line)
        {
            InitializeComponent();
            trainLine = line;
            //comboBoxDirection.DataSource = Enum.GetNames(typeof(Direction));
            comboBoxDirection.DataSource = Enum.GetValues(typeof(Direction));
            comboBoxDirection.DisplayMember = "Display";
            //comboBoxDirection.Valueember = "Value";
            comboBoxPeriod.DataSource = Enum.GetValues(typeof(Period));
            comboBoxTypeOfTrain.DataSource = Enum.GetValues(typeof(TypeOfTrain));
            
        }

        private void FormDetailsOfLine_Load(object sender, EventArgs e)
        {
            
        }

        private void FormDetailsOfLine_Shown(object sender, EventArgs e)
        {
            readAndFillLineInformation();
        }

        //--------------------------------------------
        // initialization methods
        //--------------------------------------------

        private void readAndFillLineInformation() 
        {
            prepareListViewListOfConnectedLines();
            prepareListViewListOfStops();
            fillLinesDetails();
        }

        private void prepareListViewListOfStops() 
        {
            // starting update list, protected before draw method
            listViewListOfStops.BeginUpdate();
            // clearStableLines previous list of items
            listViewListOfStops.Items.Clear();
            List<TrainStop> trainStops = trainLine.getTrainStops();

            // prepare new list according trainStops of line_
            foreach (TrainStop stop in trainStops)
            {
                ListViewItem lvi = new ListViewItem();
                // fill the data
                lvi.Text = stop.TrainStation.Name;
                lvi.Tag = stop.TrainStation.Name;

                lvi.SubItems.Add(stop.OrderInTrainLine.ToString());
                lvi.SubItems.Add(stop.TimeFromStart.ToString());
                lvi.SubItems.Add(stop.KmFromStart.ToString());
                lvi.SubItems.Add(stop.TimeStayingAtStation.ToString());
                lvi.SubItems.Add(stop.TimeFromPreviousStop.ToString());
                lvi.SubItems.Add(stop.KmFromPreviousStop.ToString());
                

                listViewListOfStops.Items.Add(lvi);

                Console.WriteLine("------------------");
                int i = 0;
                foreach (ListViewItem.ListViewSubItem sub in lvi.SubItems)
                {
                    Console.WriteLine(i + " text " + sub.Text);
                    //Console.WriteLine(i + " name " + sub.Name);
                    //Console.WriteLine(i + " tag " + sub.Tag);
                    i++;
                }
                Console.WriteLine("subitems total: " + lvi.SubItems.Count);
            }
            listViewListOfStops.EndUpdate();
        }

        private void prepareListViewListOfConnectedLines() 
        {
            List<TrainLine> trainLines = trainLine.getConnectedLines();

            listViewListOfConnectedLines.BeginUpdate();
            listViewListOfConnectedLines.Items.Clear();

            foreach (TrainLine line in trainLines) 
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = line.LineNumber.ToString();
                lvi.Tag = line.LineNumber.ToString();

                lvi.SubItems.Add(line.TypeTrain.ToString());
                lvi.SubItems.Add(line.Period.ToString());

                listViewListOfConnectedLines.Items.Add(lvi);

            }

            listViewListOfConnectedLines.EndUpdate();
        }

        private void fillLinesDetails() 
        {
            textBoxLineNumber.Text = trainLine.LineNumber.ToString();
            textBoxProvider.Text = trainLine.Provider;
            
            comboBoxDirection.SelectedItem = trainLine.Direction;
            comboBoxTypeOfTrain.SelectedItem = trainLine.TypeTrain;
            comboBoxPeriod.SelectedItem = trainLine.Period;
        }

        //--------------------------------------------
        // stop details, list view
        //--------------------------------------------

        private void listViewListOfStops_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   fillStopDetails(listViewListOfStops.Items[
         //       listViewListOfStops.SelectedIndices[0]]);
            //lviTrainStop = listViewListOfStops.SelectedItems[0];
        }

        private void listViewListOfStops_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!listViewListOfStops.SelectedItems.Count.Equals(0))
                fillStopDetails(listViewListOfStops.SelectedItems[0]);
        }

        private void fillStopDetails(ListViewItem lvi)
        {
            textBoxTrainStation.Text = lvi.Text;
            textBoxOrderAtLine.Text = lvi.SubItems[1].Text;
            textBoxTimeOfStaying.Text = lvi.SubItems[4].Text;
            textBoxTimeDifference.Text = lvi.SubItems[5].Text;
            textBoxDistanceDifference.Text = lvi.SubItems[6].Text;
            
            lviTrainStop = lvi;
        }

        //--------------------------------------------
        // button UpdateStopDetails
        //--------------------------------------------

        private void updateStopDetails()
        {
            if (lviTrainStop != null)
            {
                lviTrainStop.SubItems[4].Text = textBoxTimeOfStaying.Text;
                lviTrainStop.SubItems[5].Text = textBoxTimeDifference.Text;
                lviTrainStop.SubItems[6].Text = textBoxDistanceDifference.Text;                
                lviTrainStop.Tag = CHANGED;
            }
        }

        private void buttonUpdateStopDetails_Click(object sender, EventArgs e)
        {
            updateStopDetails();
        }

        //--------------------------------------------
        // button BACK
        //--------------------------------------------

        private void buttonBackDetailsOfLine_Click(object sender, EventArgs e)
        {
            backDetailsOfLine();
        }

        private void backDetailsOfLine() 
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //--------------------------------------------
        // button SAVE
        //--------------------------------------------

        private void buttonSaveDetailsOfLine_Click(object sender, EventArgs e)
        {
            saveLineInformation();
            saveStopsInformation();
            saveConnectedLinesInformation();
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void saveLineInformation()
        {
            trainLine.Period = (Period)comboBoxPeriod.SelectedItem;
            trainLine.Provider = textBoxProvider.Text;
            trainLine.TypeTrain = (TypeOfTrain)comboBoxTypeOfTrain.SelectedItem;
            trainLine.Direction = (Direction)comboBoxDirection.SelectedItem;
        }

        private void saveStopsInformation()
        {
            foreach (ListViewItem lvi in listViewListOfStops.Items)
            {
                // if there where changes of the train stop, save it
                if (lvi.Tag.Equals(CHANGED)) 
                {
                    // train stop at order
                    int order = Convert.ToInt32(lvi.SubItems[1].Text);
                    TrainStop stop = trainLine.getTrainStopOrderedAt(order);

                    stop.TimeStayingAtStation = Time.ToTime(lvi.SubItems[4].Text);
                    stop.TimeFromPreviousStop = Time.ToTime(lvi.SubItems[5].Text);
                    stop.KmFromPreviousStop = Convert.ToInt32( lvi.SubItems[6].Text);
                }
            }
        }

        private void saveConnectedLinesInformation()
        {
            List<TrainLine> connectedLines = trainLine.getConnectedLines();

            // ADD NEW CONNECTED LINES
            // loop over all items of list of connectedLines
            foreach (ListViewItem lvi in listViewListOfConnectedLines.Items) 
            {
                // retreive line_ number
                int lineNmuber = Convert.ToInt32(lvi.Text);

                // if line_ exist do nothing 
                if (TrainLineCache.doesLineExist(lineNmuber, connectedLines))
                {
                }
                    // if line_ doesn't exist in list of connected variableLines
                else 
                {
                    // retreive train line_ off train line_ cache
                    TrainLine line = TrainLineCache.getInstance()
                        .getCacheContentOnNumber(lineNmuber);
                    // and addConstraint
                    connectedLines.Add(line);
                }
            }
            // REMOVE OLD CONNECTED LINES
            // loop over all items in list of connectedLines
            for (int i = connectedLines.Count - 1; i >= 0; i-- )
            {
                TrainLine line = connectedLines[i];

                // if line_ of connectedLine also exist in listView
                if (isAlreadyInListView(line.LineNumber.ToString(), listViewListOfConnectedLines.Items))
                {
                    // do nothing, it is actual
                }
                // if line_ of connectedLines is not in listView
                else
                {
                    // it is out-of-date, remove it
                    connectedLines.RemoveAt(i);
                }
            }
        }

        private Boolean isAlreadyInListView(String key, ListView.ListViewItemCollection items)
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

        //--------------------------------------------
        // button Remove ConnectedLine
        //--------------------------------------------

        private void buttonRemoveConnectedLine_Click(object sender, EventArgs e)
        {
            removeConnectedLine();
        }

        private void removeConnectedLine()
        {
            // if nothing selected
            if (listViewListOfConnectedLines.SelectedItems.Count.Equals(0))
            {
                MessageBox.Show("Please, select the line_.", "No line_ selected");
            }
            else
            {

                // Multiselect false version
                // remove items fromStation list according selected items
                //listViewListOfConnectedLines.Items.Remove(
                //    listViewListOfConnectedLines.SelectedItems[0]);

                ListView.SelectedIndexCollection indices = listViewListOfConnectedLines.SelectedIndices;

                listViewListOfConnectedLines.BeginUpdate();
                // while is still there any indeces
                while (indices.Count != 0)
                {
                    // remove item at index which is last in selected indeces array
                    listViewListOfConnectedLines.Items.RemoveAt(indices[indices.Count - 1]);
                }

                listViewListOfConnectedLines.EndUpdate();
            }
        }

        //--------------------------------------------
        // button Add ConnectedLine
        //--------------------------------------------

        private void buttonAddConnectedLine_Click(object sender, EventArgs e)
        {
            addConnectedLine();
        }

        private void addConnectedLine() 
        {
            FormAddLinesDialog formAddLinesDialog = new FormAddLinesDialog(trainLine, listViewListOfConnectedLines.Items);
            DialogResult dr = formAddLinesDialog.ShowDialog();

            // if the dialog was closed by Button OK
            if (dr.Equals(DialogResult.OK))
            {
                // prevent off method draw
                listViewListOfConnectedLines.BeginUpdate();

                // if something was selected
                if (!formAddLinesDialog.AddedLines.Count.Equals(0))
                {
                    // addConstraint new connected lines
                    foreach (ListViewItem lvi in formAddLinesDialog.AddedLines)
                    {
                        ListViewItem lviClone = (ListViewItem)lvi.Clone();
                        listViewListOfConnectedLines.Items.Add(lviClone);
                    }
                }
                listViewListOfConnectedLines.EndUpdate();
            }
        }
    }
}
