﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PeriodicTimetableGeneration.Forms;
using System.Collections;
using PeriodicTimetableGeneration;
using PeriodicTimetableGeneration.Util;

namespace PeriodicTimetableGeneration
{
    public partial class FormRPproject : Form
    {
        const String COMBOBOX_ALLLINES = "All lines";
        
        public FormRPproject()
        {
            InitializeComponent();
        }

        //--------------------------------------------
        // button ADD files
        //--------------------------------------------

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            openFileDialogTrainLines.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            addItemsToLVLoadFiles();
        }

        private void addItemsToLVLoadFiles() 
        {
            listViewLoadFiles.BeginUpdate();

            foreach (string s in openFileDialogTrainLines.FileNames)
            {
                FileInfo fileInfo = new FileInfo(s);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = fileInfo.Name;
                lvi.Tag = fileInfo.FullName;
                lvi.ImageIndex = 1;

                Console.WriteLine(fileInfo.FullName);
                Console.WriteLine(lvi.Tag.ToString());

                ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = fileInfo.Length.ToString();
                lvi.SubItems.Add(lvsi);
                lvi.SubItems.Add(fileInfo.FullName);

                if (isAlreadyInViewList(lvi.Tag))
                {
                    // file already exists in listView
                    continue;
                }

                listViewLoadFiles.Items.Add(lvi);

                Console.WriteLine("------------------");
                int i = 0;
                foreach (ListViewItem.ListViewSubItem sub in lvi.SubItems)
                {
                    Console.WriteLine(i + " " + sub.Text);
                    i++;
                }
                Console.WriteLine("subitems total: " + lvi.SubItems.Count);
            }
            listViewLoadFiles.EndUpdate();
            Console.WriteLine(listViewLoadFiles.Items.Count);
            Console.WriteLine(listViewLoadFiles.Items[0].Text);

        }

        private Boolean isAlreadyInViewList(Object key)
        {
            Boolean exists = false;

            foreach (ListViewItem lvi in listViewLoadFiles.Items)
                if (lvi.Tag.Equals(key))
                {
                    exists = true;
                    break;
                }
            return exists;
        }

        //--------------------------------------------
        // button REMOVE files
        //--------------------------------------------

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            removeItemsFromLVLoadFiles();
        }

        private void removeItemsFromLVLoadFiles()
        {
            ListView.SelectedIndexCollection indices = listViewLoadFiles.SelectedIndices;
//            ListView.SelectedListViewItemCollection items = listViewLoadFiles.Items;

            // while is still there any indeces
            while (indices.Count != 0) 
            {
                // remove item at index which is last in selected indeces array
                listViewLoadFiles.Items.RemoveAt(indices[indices.Count - 1]);
            }

/*            foreach (int i in indices)
            {
                listViewLoadFiles.Items.RemoveAt(i);
            }
*/

            listViewLoadFiles.EndUpdate();
        }   

        //--------------------------------------------
        // button NEXT list of variableLines
        //--------------------------------------------


        private void buttonListOfLinesNext_Click(object sender, EventArgs e)
        {
            prepareListViewListOfStations();
            tabControlTG.SelectTab(tabPageListOfStation);
            prepareComboBoxListOfLines(listViewListOfLines);
        }

        private void prepareComboBoxListOfLines(ListView listOfLines)
        {
            // prevent comboBox fromStation method draw during update
            comboBoxSelectLine.BeginUpdate();
            // clearStableLines previous list, if exists
            comboBoxSelectLine.Items.Clear();
            // addConstraint first option, which is all variableLines, resp. no line_ selected -> all station
            comboBoxSelectLine.Items.Add(COMBOBOX_ALLLINES);
            // for each Line in ListView ListOfLines
            foreach (ListViewItem lvi in listViewListOfLines.Items) 
            {
                // addConstraint new number of line_ into comboBox.Items
                comboBoxSelectLine.Items.Add(lvi.Text);
            }
            // finish updating
            comboBoxSelectLine.EndUpdate();
            comboBoxSelectLine.SelectedItem = COMBOBOX_ALLLINES;
        }

        //--------------------------------------------
        // button DETAILS line_
        //--------------------------------------------

        private void buttonDetailsLine_Click(object sender, EventArgs e)
        {
            detailsLineOpen();
        }

        private void detailsLineOpen() 
        {
            // if nothing selected 
            if (listViewListOfLines.SelectedItems.Count.Equals(0))
            {
                MessageBox.Show("Please, select the line_.", "No line_ selected");
            }
            // if selected
            else
            {
                Form formLineDetails = new FormDetailsOfLine(
                    TrainLineCache.getInstance().getCacheContentOnNumber(
                        Convert.ToInt32(
                            listViewListOfLines
                                .SelectedItems[0]
                                .Text
                         )
                    )
                );

                // before calling subform - remember listView focus
                int selectedIndex = listViewListOfLines.SelectedIndices[0];

                DialogResult dr = formLineDetails.ShowDialog();
                if (dr.Equals(DialogResult.OK)) 
                {
                    // update list view
                    prepareListViewListOfLines();
                    // refresh selection and focus on selected item
                    FormUtil.listView_SelecdAndFocus(listViewListOfLines, selectedIndex);
                }
            }
        }

        //--------------------------------------------
        // button NEXT load file
        //--------------------------------------------

        private void buttonLoadFileNext_Click(object sender, EventArgs e)
        {
            createTrainLinesFromFiles();
            prepareListViewListOfLines();
            tabControlTG.SelectTab(tabPageListOfLines);
        }

        private void prepareListViewListOfStations() 
        {
            // load throughStation's cache
            List<TrainStation> listStations = TrainStationCache.getInstance().getCacheContent();
            // starting update list, protected before method Draw
            listViewListOfStations.BeginUpdate();
            // clearStableLines previous list's items
            listViewListOfStations.Items.Clear();
            // and prepare new list view accordind throughStation's cache
            foreach (TrainStation station in listStations) 
            {
                ListViewItem lvi = new ListViewItem();
                // fill item with throughStation's information 
                lvi.Text = station.Id.ToString();
                lvi.Tag = station.Id.ToString();

                lvi.SubItems.Add(station.Name);
                lvi.SubItems.Add(station.TownCategory.ToString());
                lvi.SubItems.Add(station.Inhabitation.ToString());
                lvi.SubItems.Add(station.Town);
                // addConstraint item into the list
                listViewListOfStations.Items.Add(lvi);
            }
            // release list view
            listViewListOfStations.EndUpdate();
        }

        private void prepareListViewListOfStations(int lineNumber)
        {         

            // get trainLine1 on lineNumber
            TrainLine trainLine = TrainLineCache.getInstance().getCacheContentOnNumber(lineNumber);
            // get trainStop of line_
            List<TrainStop> stops = trainLine.getTrainStops();

            // starting update list, protected before method Draw
            listViewListOfStations.BeginUpdate();
            // clearStableLines previous list's items
            listViewListOfStations.Items.Clear();
            // and prepare new list view accordind trainStops of line_
            foreach (TrainStop stop in stops)
            {
                // get station of stop
                TrainStation station = stop.TrainStation;

                    ListViewItem lvi = new ListViewItem();
                    // fill item with throughStation's information 
                    lvi.Text = station.Id.ToString();
                    lvi.Tag = station.Id.ToString();

                    lvi.SubItems.Add(station.Name);
                    lvi.SubItems.Add(station.TownCategory.ToString());
                    lvi.SubItems.Add(station.Inhabitation.ToString());
                    lvi.SubItems.Add(station.Town);
                
                    // addConstraint item into the list
                    listViewListOfStations.Items.Add(lvi);
            }
            // release list view
            listViewListOfStations.EndUpdate();
        }
        

        private void createTrainLinesFromFiles()
        {
            // clearStableLines variableLines off previous run
            TrainLineCache.getInstance().clearContent();
            // clearStableLines station off previous run
            TrainStationCache.getInstance().clearContent();

            TrainLineCache lineCache = TrainLineCache.getInstance();

            foreach (ListViewItem lvi in listViewLoadFiles.Items)
            {
                TrainLine line = IOUtil.readTrainLineFromFile(lvi.Tag.ToString());
                // test if already exists
                if (TrainLineCache.getInstance().doesLineExist(line.LineNumber)) { }
                else
                { 
                    lineCache.addTrainLine(line);
                }
            }
        }

        private void prepareListViewListOfLines()
        {
            // load line_'s cache
            List<TrainLine> listLines = TrainLineCache.getInstance().getCacheContent();


            // starting update list, protected before draw method
            listViewListOfLines.BeginUpdate();
            // clearStableLines previous list of items
            listViewListOfLines.Items.Clear();
            
            // and prepare new list view according line_'s cahe
            foreach (TrainLine line in listLines)
            {
                ListViewItem lvi = new ListViewItem();
                // fill item with line_'s information
                lvi.Text = line.LineNumber.ToString();
                lvi.Tag = line.LineNumber.ToString();

                //ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                //lvsi.Text = line_.TypeTrain.ToString();
                lvi.SubItems.Add(line.TypeTrain.ToString());
                lvi.SubItems.Add(line.Period.ToString());
                lvi.SubItems.Add(line.getFirstTrainStop().TrainStation.Name);
                lvi.SubItems.Add(line.getLastTrainStop().TrainStation.Name);

                listViewListOfLines.Items.Add(lvi);
            }
            // release list of items
            listViewListOfLines.EndUpdate();

        }

        //--------------------------------------------
        // button DETAILS station
        //--------------------------------------------

        private void buttonDetailsStation_Click(object sender, EventArgs e)
        {
            detailsStationOpen();            
        }

        private void detailsStationOpen()
        {
            // if nothing selected
            if (listViewListOfStations.SelectedItems.Count.Equals(0))
            {
                MessageBox.Show("Please, select the station.", "No station selected");
                // if selected
            }
            else
            {
                Form formDetailsOfStation = new FormDetailsOfStation(
                    TrainStationCache.getInstance().getCacheContentOnSelect(
                        Convert.ToInt32(
                            listViewListOfStations
                            .SelectedItems[0]
                            .Text
                        )
                    )
                );

                // before calling subform - remember listView focus                
                int selectedIndex = listViewListOfStations.SelectedIndices[0];                

                DialogResult dr = formDetailsOfStation.ShowDialog();
                // if the subform closed by OK something may changed
                if (dr.Equals(DialogResult.OK))
                {
                    // then update list view
                    comboBoxSelectLineChanged();
                    // refresh selection and focus on selected item
                    FormUtil.listView_SelecdAndFocus(listViewListOfStations, selectedIndex);
                }
            }
        }

        //--------------------------------------------
        // list of STATION
        //--------------------------------------------

        private void listViewListOfStations_ItemActivate(object sender, EventArgs e)
        {
            detailsStationOpen();
            //prepareListViewListOfStations();
        }

        //--------------------------------------------
        // list of LINES
        //--------------------------------------------

        private void listViewListOfLines_ItemActivate(object sender, EventArgs e)
        {
            detailsLineOpen();
            //prepareListViewListOfLines();
        }

        private void comboBoxSelectLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSelectLineChanged();
        }

        private void comboBoxSelectLineChanged() 
        {
            // if something selected
            if (comboBoxSelectLine.SelectedIndex != -1)
            {
                // if default option selected
                if (comboBoxSelectLine.SelectedItem.Equals(COMBOBOX_ALLLINES))
                {
                    // createConstraintSet list of all stations
                    prepareListViewListOfStations();
                }
                // otherwise choose only station according
                else
                {
                    prepareListViewListOfStations(Convert.ToInt32( comboBoxSelectLine.SelectedItem));
                }

            }
        }

        //--------------------------------------------
        // button NEXT list of station
        //--------------------------------------------

        private void buttonListOfStationNext_Click(object sender, EventArgs e)
        {
            // activate algorithm
            ShortestPathAlgoritm shortestPathAlgorithm = ShortestPathAlgoritm.getInstance();
            shortestPathAlgorithm.calculateShortestPath();
            shortestPathAlgorithm.generateAllTrainConnections();
            // prepare list view
            prepareListViewListOfConnections();
            // open particular tab
            tabControlTG.SelectTab(tabPageListOfConncetions);
        }

        private void prepareListViewListOfConnections()
        {
            // retreive train connections off cache
            List<TrainConnection> connections = ShortestPathAlgoritm.getInstance().getTrainConnections();

            // prevent off method draw called on this listView
            listViewListOfConnections.BeginUpdate();
            // clearStableLines previous content
            listViewListOfConnections.Items.Clear();
            // loop over trainConnections
            foreach (TrainConnection connection in connections) 
            {
                ListViewItem lvi = new ListViewItem();
                // fill the information about train connection;
                lvi.Text = connection.FromStation.Name;
                lvi.Tag = connection.FromStation.Name + " -> " + connection.ToStation.Name; 

                // fill other information about connection
                lvi.SubItems.Add(connection.ToStation.Name);
                lvi.SubItems.Add(connection.Time.ToString());
                lvi.SubItems.Add(connection.Distance.ToString());
                lvi.SubItems.Add(connection.Passengers.ToString());
                lvi.SubItems.Add(connection.LinesOfConnection);
                lvi.SubItems.Add(connection.ChangingStation);

                listViewListOfConnections.Items.Add(lvi);
            }
            // release list of items
            listViewListOfConnections.EndUpdate();
        }

        //--------------------------------------------
        // button UPDATE_CATEGORIES
        //--------------------------------------------

        private void openFileDialogUpdateTownCategories_FileOk(object sender, CancelEventArgs e)
        {
            updateTownCategoriesFromFile(openFileDialogUpdateTownCategories.FileName);
            prepareListViewListOfStations();
        }

        private void updateTownCategoriesFromFile(String fileName)
        {
            List<TrainStation> stations = IOUtil.readTrainStationFromFile(fileName);

            foreach (TrainStation station in stations) 
            {
                // if station exits in train station cache
                if(TrainStationCache.getInstance().doesStationExist(station.Name))
                {
                    // find station in cache
                    TrainStation s = TrainStationCache.getInstance()
                        .getCacheContentOnName(station.Name);
                    // copy inhabitation
                    s.Inhabitation = station.Inhabitation;
                    // update town category according inhabitation
                    s.updateTownCategory();
                }
            }

        }

        private void buttonUpdateCategories_Click(object sender, EventArgs e)
        {
            openFileDialogUpdateTownCategories.ShowDialog();
        }

        //--------------------------------------------
        // button DETAILS of connection
        //--------------------------------------------

        private void buttonDetailsConnection_Click(object sender, EventArgs e)
        {
            detailsOfConnectionOpen();
        }

        private void detailsOfConnectionOpen()
        {
            // if nothing selected
            if (listViewListOfConnections.SelectedItems.Count.Equals(0))
            {
                MessageBox.Show("Please, select the connection.", "No connection selected");
            }
            // if selected
            else
            {
                TrainConnection connection = ShortestPathAlgoritm.getInstance().getTrainConnectionOnFromTo(
                        listViewListOfConnections.SelectedItems[0].Text,
                        listViewListOfConnections.SelectedItems[0].SubItems[1].Text);

                FormDetailsOfConnection formDetailsOfConnection = new FormDetailsOfConnection(connection);

                // before calling subform - remember listView focus
                int selectedIndex = listViewListOfConnections.SelectedIndices[0];
                
                
                DialogResult dr = formDetailsOfConnection.ShowDialog();
                if (dr.Equals(DialogResult.OK)) 
                {
                    // update list view
                    prepareListViewListOfConnections();
                    // refresh selection and focus on selected item
                    FormUtil.listView_SelecdAndFocus(listViewListOfConnections, selectedIndex);
                }


            }

        }

        //--------------------------------------------
        // list of connection
        //--------------------------------------------

        private void listViewListOfConnections_ItemActivate(object sender, EventArgs e)
        {
            detailsOfConnectionOpen();
            //prepareListViewListOfConnections();
        }

        //--------------------------------------------
        // button NEXT list of connection
        //--------------------------------------------

        private void buttonListOfConncetionsNext_Click(object sender, EventArgs e)
        {
            prepareListViewFinalInput();
            tabControlTG.SelectTab(tabPageFinalInput);
        }

        //--------------------------------------------
        // button EDIT_PATH of connection
        //--------------------------------------------

        private void buttonEditPath_Click(object sender, EventArgs e)
        {
            editPathConnectionOpen();
        }

        private void editPathConnectionOpen() 
        {
            // if nothing selected
            if (listViewListOfConnections.SelectedItems.Count.Equals(0))
            {
                MessageBox.Show("Please, select the connection", "No connection selected");
            }
            // if selected
            else 
            {
                TrainConnection connection = ShortestPathAlgoritm.getInstance().getTrainConnectionOnFromTo(
                listViewListOfConnections.SelectedItems[0].Text,
                listViewListOfConnections.SelectedItems[0].SubItems[1].Text);

                FormEditPathOfConnection editPathConnection = new FormEditPathOfConnection(connection);

                // before calling subform - remember listView focus   
                int selectedIndex = listViewListOfConnections.SelectedIndices[0];

                // open subform as a dialog
                DialogResult dr = editPathConnection.ShowDialog();

                // if the dialog was closed by button OK
                if (dr.Equals(DialogResult.OK))
                {
                    // and if there are new valid stages
                    List<Stage> newStages = editPathConnection.NewStages;
                    if (newStages != null)
                    {
                        // set new stages
                        connection.setStages(newStages);
                        connection.updateGeneratedValues();
                        // refresh ListView
                        prepareListViewListOfConnections();
                        // refresh selection and focus on selected item
                        FormUtil.listView_SelecdAndFocus(listViewListOfConnections, selectedIndex);
                    }
                }
            }
        }

        //----------------------------------------------
        // Methods for preparing FINAL INPUT
        //----------------------------------------------

        /*
        private void prepareListViewFinalInput() 
        {
            listViewFinalInput.BeginUpdate();
            listViewFinalInput.Items.Clear();
            
            List<TrainConnection> connections = ShortestPathAlgoritm.getInstance().getTrainConnections();
            List<List<TrainConnection>> groupsOfConnections = groupByListOfLines(connections);

            // loop over all groups
            foreach (List<TrainConnection> group in groupsOfConnections) 
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = group[0].LinesOfConnection;
                lvi.Tag = group[0].LinesOfConnection;

                lvi.SubItems.Add(group[0].ChangingStation);
                lvi.SubItems.Add(calculatePassengersForGroupOfConnections(group).ToString());
                
                listViewFinalInput.Items.Add(lvi);
            }

            listViewFinalInput.EndUpdate();
        }*/

        private void prepareListViewFinalInput()
        {
            listViewFinalInput.BeginUpdate();
            listViewFinalInput.Items.Clear();

            // createConstraintSet new final input
            FinalInput.getInstance().createGroupsOfConnection();

            // loop over all groups
            foreach (GroupOfConnections group in FinalInput.getInstance().getCacheContent()) 
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = group.LinesOfConnectionString;
                lvi.Tag = group.LinesOfConnectionString;

                lvi.SubItems.Add(group.ChangingStationsString);
                lvi.SubItems.Add(group.calculatePassengers().ToString());

                listViewFinalInput.Items.Add(lvi);
            }

            listViewFinalInput.EndUpdate();
        }

        private void buttonGenerateTimetables_Click(object sender, EventArgs e)
        {
            FormTimetables formTimetables = new FormTimetables();
            formTimetables.Show();
        }

        //-----------------------------------------------------------
        // ListViewListOf STATION - ColumnClick - Sorting
        //-----------------------------------------------------------

        private void listViewListOfStations_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FormUtil.listView_ColumnClick_Sorting(sender, e, this.listViewListOfStations);
        }

        //-----------------------------------------------------------
        // ListViewListOf CONNECTION - ColumnClick - Sorting
        //-----------------------------------------------------------

        private void listViewListOfConnections_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FormUtil.listView_ColumnClick_Sorting(sender, e, this.listViewListOfConnections);
        }


        //-----------------------------------------------------------
        // ListViewListOf LINES - ColumnClick - Sorting
        //-----------------------------------------------------------

        private void listViewListOfLines_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FormUtil.listView_ColumnClick_Sorting(sender, e, this.listViewListOfLines);
        }

        //-----------------------------------------------------------
        // ListViewListOf FINAL INPUT - ColumnClick - Sorting
        //-----------------------------------------------------------

        private void listViewFinalInput_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FormUtil.listView_ColumnClick_Sorting(sender, e, this.listViewFinalInput);
        }

        private void buttonGenerationPESP_Click(object sender, EventArgs e)
        {
            GenerationAlgorithmPESP genAlgo = new GenerationAlgorithmPESP();
            //genAlgo.runPreparationAlgorithm();
            genAlgo.generateTimetable();
        }


        /*
        private static int calculatePassengersForGroupOfConnections(List<TrainConnection> group) 
        {
            int totalPassengers = 0;
            foreach (TrainConnection connection in group) 
            {
                totalPassengers += connection.Passengers;
            }

            return totalPassengers;
        }

        private List<List<TrainConnection>> groupByListOfLines(List<TrainConnection> connections)
        {
            List<List<TrainConnection>> groupsOfListOfConnections = new List<List<TrainConnection>>();
            List<TrainConnection> addingGroup;

            // loop over all train connections
            foreach (TrainConnection connection in connections) 
            {
                String connectionKey = connection.LinesOfConnection;
                // if the group with the same key already exists
                if (doesGroupAlreadyExist(groupsOfListOfConnections, connectionKey))
                {
                    // find the group for adding
                    addingGroup = findGroup(groupsOfListOfConnections, connectionKey);
                }
                else 
                {
                    // otherwise createConstraintSet a new group
                    addingGroup = new List<TrainConnection>();
                    // addConstraint group to the results
                    groupsOfListOfConnections.Add(addingGroup);
                }
                // finally addConstraint the connection into appropriate group
                addingGroup.Add(connection);
            }

            return groupsOfListOfConnections;
        }

        private List<TrainConnection> removeSingleConnections(List<TrainConnection> connections) 
        {
            // or createConstraintSet a new instance only with a valid connections
            List<TrainConnection> newConnections = new List<TrainConnection>();

            foreach (TrainConnection connection in connections) 
            {
                // if connection contains more than one line => is not a single connection
                if (connection.getLinesOfConnection().Count > 1)
                    // then addConstraint to the results
                    newConnections.Add(connection);
            }

            return newConnections;
        }

        private Boolean doesGroupAlreadyExist( List<List<TrainConnection>> groups, String key) 
        {
            return findGroup(groups, key) != null ? true : false; 
        }

        private List<TrainConnection> findGroup(List<List<TrainConnection>> groups , String key)
        {
            List<TrainConnection> wantedGroup = null;
            // loop over all groups
            foreach (List<TrainConnection> group in groups) 
            {
                // if group is not empty
                if (!group.Count.Equals(0)) 
                {
                    // access first member
                    String keyGroup = group[0].LinesOfConnection;
                    // if key of group equals wanted key
                    if (keyGroup.Equals(key))
                    {
                        // we found a group
                        wantedGroup = group;
                        // leave the loop
                        break;
                    }
                }
            }

            return wantedGroup;
        }
         */
    }
}
