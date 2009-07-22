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
    public partial class FormAddStageDialog : Form
    {
        /// <summary>
        /// variable for new added stage
        /// </summary>
        private Stage newAddedStage;
        /// <summary>
        /// variable for a list of all available stages
        /// </summary>
        private List<Stage> availableStages;
        /// <summary>
        /// variable for previous stage
        /// </summary>
        private Stage previousStage;
        /// <summary>
        /// variable of final station of connection
        /// </summary>
        private TrainStation finalStation;
        /// <summary>
        /// variable of start station of connection
        /// </summary>
        private TrainStation startStation;

        public FormAddStageDialog()
        {
            InitializeComponent();
            setDefaultValues();
        }

        public FormAddStageDialog(Stage previousStage_, TrainStation toStation)
        {
            InitializeComponent();
            setDefaultValues();
            previousStage = previousStage_;
            finalStation = toStation;
        }

        public FormAddStageDialog(TrainStation fromStation, TrainStation toStation)
        {
            InitializeComponent();
            setDefaultValues();
            startStation = fromStation;
            finalStation = toStation;
        }

        private void setDefaultValues() 
        {
            newAddedStage = null;
            availableStages = new List<Stage>();
            previousStage = null;
            startStation = null;
            finalStation = null;
        }

        private void FormAddStageDialog_Shown(object sender, EventArgs e)
        {
            prepareListOfAvailableStages();
            prepareListViewListOfAvailableStages();
        }

        public Stage NewAddedStage 
        {
            get 
            {
                return newAddedStage;
            }
            set 
            {
            }
        }

        //-----------------------------------------------------------
        // methods preparing AVAILABLE STAGES and LIST VIEW
        //-----------------------------------------------------------

        private void prepareListOfAvailableStages()
        {
            // if previous doesn't exist, find first stages
            if (previousStage == null)
            {
                availableStages = StageUtil.findAvailableStages(startStation, finalStation);
            }
            // otherwise
            else 
            {
                availableStages = StageUtil.findAvailableStages(previousStage, finalStation);
            }
        }

        private void prepareListViewListOfAvailableStages()
        {
            listViewListOfAvailableStages.BeginUpdate();
            // clearStableLines off previous program run
            listViewListOfAvailableStages.Items.Clear();

            foreach (Stage stage in availableStages) 
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = stage.FromStationName;
                lvi.Tag = stage.FromStationName + stage.ToStationName + stage.LineNumber.ToString();

                lvi.SubItems.Add(stage.ToStationName);
                lvi.SubItems.Add(stage.LineNumber.ToString());
                lvi.SubItems.Add(stage.Time.ToString());
                lvi.SubItems.Add(stage.Distance.ToString());

                listViewListOfAvailableStages.Items.Add(lvi);
            }

            listViewListOfAvailableStages.EndUpdate();
        }

        //---------------------------------------
        // button CANCEL
        //---------------------------------------

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //---------------------------------------
        // button ADD_STAGE
        //---------------------------------------

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addStage();            
        }

        private void addStage() 
        {
            // if nothing selected
            if (listViewListOfAvailableStages.SelectedItems.Count.Equals(0))
            {
                MessageBox.Show("Please, select the stage.", "No stage selected");
            }
            // if something selected
            else 
            {

                newAddedStage = findStage(listViewListOfAvailableStages.SelectedItems[0].Tag);
                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }
        }

        private Stage findStage(Object key)
        {
            Stage selectedStage = null;

            foreach (Stage stage in availableStages) 
            {
                // createConstraintSet the key for stage
                String stageKey = stage.FromStationName + stage.ToStationName + stage.LineNumber.ToString();
                // compare with key
                if (stageKey.Equals(key))
                {
                    selectedStage = stage;
                    break;
                }
            }

            return selectedStage;
        }

        //---------------------------------------
        // list of AVALABLE STAGES
        //---------------------------------------

        private void listViewListOfAvailableStages_ItemActivate(object sender, EventArgs e)
        {
            addStage();
        }

        //-----------------------------------------------------------
        // ListViewListOf AVAILABLE STAGES - ColumnClick - Sorting
        //-----------------------------------------------------------

        private void listViewListOfAvailableStages_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FormUtil.listView_ColumnClick_Sorting(sender, e, this.listViewListOfAvailableStages);
        }

    }
}
