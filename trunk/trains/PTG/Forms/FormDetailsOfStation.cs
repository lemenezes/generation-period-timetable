using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeriodicTimetableGeneration.GenerationAlgorithmDSAs.Utils;

namespace PeriodicTimetableGeneration
{
    public partial class FormDetailsOfStation : Form
    {
        private TrainStation trainStation;

        public FormDetailsOfStation()
        {
            InitializeComponent();
        }

        public FormDetailsOfStation(TrainStation station) 
        {
            InitializeComponent();
            trainStation = station;

            comboBoxCategory.DataSource = Enum.GetValues(typeof(TownCategory));
            fillStationInformation();
        }

        private void FormDetailsOfStation_Load(object sender, EventArgs e)
        {

        }

        //--------------------------------
        // initalization methods
        //--------------------------------

        private void fillStationInformation()
        {
            textBoxId.Text = trainStation.Id.ToString();
            textBoxName.Text = trainStation.Name;
            comboBoxCategory.SelectedItem = trainStation.TownCategory;
            textBoxInhabitation.Text = trainStation.Inhabitation.ToString();
            textBoxTown.Text = trainStation.Town;
            textBoxMinimalTransferTime.Text = trainStation.MinimalTransferTime.ToString();
            prepareListViewListOfTrainLines();
        }

        private void prepareListViewListOfTrainLines() 
        {
            List<TrainLine> trainLines = trainStation.getTrainLines();
            listViewTrainLines.BeginUpdate();

            listViewTrainLines.Items.Clear();
            foreach (TrainLine line in trainLines)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = line.LineNumber.ToString();
                lvi.Tag = line.LineNumber.ToString();

                lvi.SubItems.Add(line.TypeTrain.ToString());
                lvi.SubItems.Add(line.Period.ToString());
                lvi.SubItems.Add(line.getFirstTrainStop().TrainStation.Name);
                lvi.SubItems.Add(line.getLastTrainStop().TrainStation.Name);

                listViewTrainLines.Items.Add(lvi);
            }
            listViewTrainLines.EndUpdate();
        }

        //--------------------------------
        // button BACK
        //--------------------------------

        private void buttonBackDetailsOfStation_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //--------------------------------
        // button SAVE
        //--------------------------------

        private void buttonSaveDetailsOfStation_Click(object sender, EventArgs e)
        {

            if (!validate())
            {
                return;
            }


            saveDetailsOfStation();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private Boolean validate()
        {
            Boolean isValid = true;

            if (!ValidationUtils.isInteger(this.textBoxInhabitation.Text) || Convert.ToInt32(textBoxInhabitation.Text) < 0)
            {
                isValid = false;
                errorProvider.SetError(textBoxInhabitation, "Invalid inhabitation value.");
            }
            else
            {
                errorProvider.SetError(textBoxInhabitation, null);
            }

            if (!ValidationUtils.isTime(this.textBoxMinimalTransferTime.Text))
            {
                isValid = false;
                errorProvider.SetError(textBoxMinimalTransferTime, "Invalid time format for Minimal Tranfer Time.");
            }
            else
            {
                errorProvider.SetError(textBoxMinimalTransferTime, null);
            }

            return isValid;
        }

        private void saveDetailsOfStation()
        {
            // if the value of inhabitation was changed
            if (inhabitationValueChanged()) 
            {
                // set up the new value of inhabitation
                trainStation.Inhabitation = Convert.ToInt32(textBoxInhabitation.Text);
                // and according that update townCategory
                trainStation.updateTownCategory();
            }
                // otherwise if category was changed
            else if (townCategoryValueChanged()) 
            {
                // set up the new value of townCategory 
                trainStation.TownCategory = (TownCategory) comboBoxCategory.SelectedValue;
                // and according that update value of inhabitation
                trainStation.updateInhabitation();
            }

            // save information about the town
            trainStation.Town = textBoxTown.Text;
            trainStation.MinimalTransferTime = Time.ToTime(textBoxMinimalTransferTime.Text);
        }

        private Boolean townCategoryValueChanged() 
        {
            Boolean changed = true;

            TownCategory newTownCategory = (TownCategory) comboBoxCategory.SelectedValue;
            // if the value of townCategory has not changed
            if (newTownCategory.Equals(trainStation.TownCategory))
                changed = false;

            return changed;
        }

        private Boolean inhabitationValueChanged() 
        {
            Boolean changed = true;

            int newInhabitation = Convert.ToInt32(textBoxInhabitation.Text);
            // if the value of inhabitation has not changed
            if (newInhabitation.Equals(trainStation.Inhabitation))
                changed = false;

            return changed;
        }
    }
}
