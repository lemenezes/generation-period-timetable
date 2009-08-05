using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeriodicTimetableGeneration.Forms
{
    public partial class FormEditPathOfConnection : Form
    {
        const String IS_VALID = "is valid";
        const String IS_NOT_VALID = "is not valid";
        /// <summary>
        /// variable for trainConnection related with this off
        /// </summary>
        private TrainConnection trainConnection;
        /// <summary>
        /// variable whether the new path is valid
        /// </summary>
        private Boolean pathValidity;
        /// <summary>
        /// variable for stages creating
        /// </summary>
        private List<Stage> stages;

        //private List<Edge>

        public FormEditPathOfConnection()
        {
            InitializeComponent();
            setDefaultValues();
        }

        public FormEditPathOfConnection(TrainConnection connection)
        {
            InitializeComponent();
            setDefaultValues();
            trainConnection = connection;
            textBoxFromStation.Text = trainConnection.FromStation.Name;
            textBoxToStation.Text = trainConnection.ToStation.Name;
            textBoxPathValidity.Text = displayValidity(pathValidity);

        }

        private void FormEditPathOfConnection_Shown(object sender, EventArgs e)
        {
            prepareListViewListOfStages();
        }

        private void prepareListViewListOfStages()
        {
            listViewListOfStages.BeginUpdate();
            listViewListOfStages.Items.Clear();


            foreach (Stage stage in stages) 
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = stage.FromStationName;
                lvi.Tag = stage.FromStationName + stage.ToStationName + stage.LineNumber.ToString();

                lvi.SubItems.Add(stage.ToStationName);
                lvi.SubItems.Add(stage.LineNumber.ToString());
                lvi.SubItems.Add(stage.Time.ToString());
                lvi.SubItems.Add(stage.Distance.ToString());

                listViewListOfStages.Items.Add(lvi);
            }

            listViewListOfStages.EndUpdate();
        }

        private void setDefaultValues() 
        {
            trainConnection = null;
            pathValidity = false;
            stages = new List<Stage>();
        }

        private static String displayValidity(Boolean valid)
        {
            if (valid) return IS_VALID;
            else return IS_NOT_VALID;
        }

        public List<Stage> NewStages 
        {
            get 
            {
                if (isPathValid()) return stages;
                else return null;
            }
            set 
            {
            }
        }

        //-------------------------------------------------
        // button ADD_STAGE
        //-------------------------------------------------

        private void buttonAddStage_Click(object sender, EventArgs e)
        {
            addStageDialogOpen();
        }

        private void addStageDialogOpen()
        {
            FormAddStageDialog addStageDialog;
            // if list view is empty
            if (listViewListOfStages.Items.Count.Equals(0))
                addStageDialog = new FormAddStageDialog(trainConnection.FromStation, trainConnection.ToStation);
            else
                addStageDialog = new FormAddStageDialog(stages[stages.Count - 1], trainConnection.ToStation);

            
            DialogResult dr = addStageDialog.ShowDialog();

            // if the dialog was closed by button OK
            if (dr.Equals(DialogResult.OK))
            {
                // if there is a new stage
                if (addStageDialog.NewAddedStage != null)
                    // addConstraint stage
                    stages.Add(addStageDialog.NewAddedStage);

                // update ListView
                prepareListViewListOfStages();

                // check whether new composition of path is valid
                checkValidity();
            }
        }

        //-------------------------------------------------
        // button REMOVE_ALL_STAGES
        //-------------------------------------------------

        private void buttonRemoveAllStages_Click(object sender, EventArgs e)
        {
            removeAllStages();
        }

        private void removeAllStages() 
        {
            // clearStableLines list view
            listViewListOfStages.BeginUpdate();
            listViewListOfStages.Items.Clear();
            listViewListOfStages.EndUpdate();
            // clearStableLines list of stages
            stages.Clear();

            checkValidity();
        }

        //-------------------------------------------------
        // button BACK path
        //-------------------------------------------------

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //-------------------------------------------------
        // button SAVE path
        //-------------------------------------------------

        private void buttonSave_Click(object sender, EventArgs e)
        {
            savePathOfConnection();
        }

        private void savePathOfConnection()
        {
            // if the new path is valid
            if (isPathValid())
            {
                // save
                this.Close();
            }
            //if not
            else
            {
                MessageBox.Show("Please, createConstraintSet a valid path.", "Invalid path");
            }
        }

        //-------------------------------------------------
        // assistent methods 
        //-------------------------------------------------

        private void checkValidity()
        {
            pathValidity = isPathValid();
            // after checking display path validity
            textBoxPathValidity.Text = displayValidity(pathValidity);
        }

        private Boolean isPathValid()
        {
            Boolean isValid = false;

            if (stages == null) return false;
            if (stages.Count.Equals(0)) return false;

            // if start and final stations are equal in stages and at trainConnection
            if (stages[0].FromStation.Id.Equals(trainConnection.FromStation.Id) &&
                stages[stages.Count - 1].ToStation.Id.Equals(trainConnection.ToStation.Id))
                isValid = true;

            return isValid;
        }

        private void listViewListOfStages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormEditPathOfConnection_Load(object sender, EventArgs e)
        {

        }


    }
}
