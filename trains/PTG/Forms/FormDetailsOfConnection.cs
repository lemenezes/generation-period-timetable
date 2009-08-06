using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeriodicTimetableGeneration.GenerationAlgorithmDSAs.Utils;

namespace PeriodicTimetableGeneration.Forms
{
    public partial class FormDetailsOfConnection : Form
    {
        /// <summary>
        /// instance of connection, which this form is related with
        /// </summary>
        private TrainConnection trainConnection;

        public FormDetailsOfConnection()
        {
            InitializeComponent();
        }

        public FormDetailsOfConnection(TrainConnection connection) 
        {
            InitializeComponent();
            trainConnection = connection;
        }

        private void FormDetailsOfConnection_Shown(object sender, EventArgs e)
        {
            readAndFillConnectionInformation();
        }

        private void readAndFillConnectionInformation()
        {
            fillConnectionInformation();
            prepareListViewListOfConnectionStages();
        }

        private void fillConnectionInformation()
        {
            textBoxFrom.Text = trainConnection.FromStation.Name;
            textBoxTo.Text = trainConnection.FromStation.Name;
            textBoxTotalTime.Text = trainConnection.Time.ToString();
            textBoxTotalDistance.Text = trainConnection.Distance.ToString();
            textBoxPassengers.Text = trainConnection.Passengers.ToString();
        }

        private void prepareListViewListOfConnectionStages()
        {
            listViewConnectionStages.BeginUpdate();
            listViewConnectionStages.Items.Clear();

            foreach (Stage stage in trainConnection.getStages()) 
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = stage.FromStationName;
                lvi.Tag = stage.FromStationName + stage.ToStationName + stage.LineNumber.ToString();

                lvi.SubItems.Add(stage.ToStationName);
                lvi.SubItems.Add(stage.LineNumber.ToString());
                lvi.SubItems.Add(stage.Time.ToString());
                lvi.SubItems.Add(stage.Distance.ToString());

                listViewConnectionStages.Items.Add(lvi);
            }

            listViewConnectionStages.EndUpdate();
        }






        //-----------------------------------------------------
        // button BACK
        //-----------------------------------------------------

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //-----------------------------------------------------
        // button SAVE
        //-----------------------------------------------------

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }

            saveConnectionInformation();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool validate()
        {
            if (ValidationUtils.isInteger(textBoxPassengers.Text))
            {
                errorProvider.SetError(textBoxPassengers, null);
                return true;
            }
            else
            {
                errorProvider.SetError(textBoxPassengers, "The number of passengers is not a valid integer.");
                return false;
            }
        }

        private void saveConnectionInformation() 
        {
             trainConnection.Passengers = Convert.ToInt32(textBoxPassengers.Text);
        }

    }
}
