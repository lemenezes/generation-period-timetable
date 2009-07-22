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
    public partial class FormTimetables : Form
    {

        private const int NUMBER_OF_PERIOD = 5;
        private const int NUMBER_OF_TIMETABLES = 15;
        private static Time START_TIME_OF_LT = new Time(8, 0);
        private static Time START_TIME_OF_ST = new Time(8, 0);
        private static Time END_TIME_OF_ST = new Time(11, 0);

        public FormTimetables()
        {
            InitializeComponent();
        }

        private void FormTimetables_Load(object sender, EventArgs e)
        {
            prepareNumericUpDownTimetables();    
        }

        //--------------------------------------------------
        // Button EXIT stations timetables
        //--------------------------------------------------

        private void buttonExitStationsTimetables_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //--------------------------------------------------
        // Button NEXT generating timetables
        //--------------------------------------------------

        private void buttonNextGeneratingTimtables_Click(object sender, EventArgs e)
        {
            // prepare comboBoxes
            prepareComboBoxSelectedTimetableLT(GenerationAlgorithm.getInstance().Timetables);
            prepareComboBoxSelectedLine(GenerationAlgorithm.getInstance().TrainLines);
            // check if the options are selected
            lineTimetable_SelectIndexChanged();
            // open tab
            tabControlGeneratingTimetables.SelectTab(tabPageLinesTimetables);
        }

        //--------------------------------------------------
        // Button EXIT lines timetables
        //--------------------------------------------------

        private void buttonNextLinesTimetables_Click(object sender, EventArgs e)
        {
            // prepare comboBoxes
            prepareComboBoxSelectedTimetableST(GenerationAlgorithm.getInstance().Timetables);
            prepareComboBoxSelectedStation(GenerationAlgorithm.getInstance().TrainStations);
            // check if the options are selected
            stationTimetable_SelectIndexChanged();
            // open tab
            tabControlGeneratingTimetables.SelectTab(tabPageStationsTimetables);
        }

        //--------------------------------------------------
        // ComboBox Selected Timetables LT
        //--------------------------------------------------

        private void prepareComboBoxSelectedTimetableLT(List<Timetable> timetables)
        {
            comboBoxSelectedTimetableLT.BeginUpdate();
            comboBoxSelectedTimetableLT.Items.Clear();

            foreach (Timetable timetable in timetables)
            {
                comboBoxSelectedTimetableLT.Items.Add(timetable.ID);
            }

            comboBoxSelectedTimetableLT.EndUpdate();
        }

        private void comboBoxSelectedTimetableLT_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineTimetable_SelectIndexChanged();
        }

        //--------------------------------------------------
        // ComboBox Selected Line
        //--------------------------------------------------

        private void prepareComboBoxSelectedLine(List<TrainLine> lines)
        {
            comboBoxSelectedLine.BeginUpdate();
            comboBoxSelectedLine.Items.Clear();

            foreach (TrainLine line in lines)
            {
                comboBoxSelectedLine.Items.Add(line.LineNumber);
            }
            comboBoxSelectedLine.EndUpdate();
        }

        private void comboBoxSelectedLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineTimetable_SelectIndexChanged();
        }

        private void lineTimetable_SelectIndexChanged()
        {
            Timetable tt;
            if (comboBoxSelectedLine.SelectedIndex != -1 && comboBoxSelectedTimetableLT.SelectedIndex != -1)
            {
                // check whether both comboBox has a selection and 
                int ttIndex = Convert.ToInt32(comboBoxSelectedTimetableLT.SelectedItem);
                int lineNumber = Convert.ToInt32(comboBoxSelectedLine.SelectedItem);
                if (GenerationAlgorithm.getInstance().doesTimetableExist(ttIndex))
                {
                    tt = GenerationAlgorithm.getInstance().findTimetableOnSelect(ttIndex);
                    // fill line's details
                    fillLineDetails(tt, lineNumber);
                    // createConstraintSet list view of line timetable
                    prepareListViewLineTimetable(tt, lineNumber);
                }

            }
        }

        //--------------------------------------------------
        // ComboBox Selected Timetables ST
        //--------------------------------------------------

        private void prepareComboBoxSelectedTimetableST(List<Timetable> timetables) 
        {
            comboBoxSelectedTimetableST.BeginUpdate();
            comboBoxSelectedTimetableST.Items.Clear();

            foreach (Timetable timetable in timetables) 
            {
                comboBoxSelectedTimetableST.Items.Add(timetable.ID);
            }

            comboBoxSelectedTimetableST.EndUpdate();
        }

        private void comboBoxSelectedTimtableST_SelectedIndexChanged(object sender, EventArgs e)
        {
            stationTimetable_SelectIndexChanged();
        }

        //--------------------------------------------------
        // ComboBox Selected Station
        //--------------------------------------------------

        private void prepareComboBoxSelectedStation(List<TrainStation> stations)
        {
            comboBoxSelectedStation.BeginUpdate();
            comboBoxSelectedStation.Items.Clear();

            foreach (TrainStation station in stations) 
            {
                comboBoxSelectedStation.Items.Add(station.Name);
            }
            //Array.Sort(comboBoxSelectedStation.Items);

            comboBoxSelectedStation.EndUpdate();
        }

        private void comboBoxSelectedStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            stationTimetable_SelectIndexChanged();
        }

        private void stationTimetable_SelectIndexChanged()
        {
            Timetable tt;
            if (comboBoxSelectedStation.SelectedIndex != -1 && comboBoxSelectedTimetableST.SelectedIndex != -1)
            {
                // check whether both comboBox has a selection and 
                int ttIndex = Convert.ToInt32(comboBoxSelectedTimetableST.SelectedItem);
                String stationName = (String) comboBoxSelectedStation.SelectedItem;
                if (GenerationAlgorithm.getInstance().doesTimetableExist(ttIndex))
                {
                    tt = GenerationAlgorithm.getInstance().findTimetableOnSelect(ttIndex);
                    // fill station's details
                    fillStationDetails(stationName);
                    // createConstraintSet list view of station timetable
                    prepareListViewStationTimetable(tt, stationName);
                }

            }
        }

        //--------------------------------------------------
        // Line Timetable presentation
        //--------------------------------------------------

        private void fillLineDetails(Timetable timetable, int lineNumber)
        {
            if (timetable == null) return;

            TrainLineVariable line = timetable.getVariableLineOnSelect(lineNumber);

            textBoxLineNumber.Text = line.LineNumber.ToString();
            textBoxTypeOfTrain.Text = line.TypeOfTrain.ToString();
            textBoxPeriod.Text = line.Period.ToString();

        }

        private void prepareListViewLineTimetable(Timetable timetable, int lineNumber) 
        {
            if (timetable == null) return;

            listViewLineTimetable.BeginUpdate();
            listViewLineTimetable.Items.Clear();

            TrainLineVariable line = timetable.getVariableLineOnSelect(lineNumber);


            // loop over ALL trainStops
            foreach (TrainStop stop in line.Line.getTrainStops()) 
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = stop.TrainStation.Name;
                lvi.Tag = stop.TrainStation.Name;

                lvi.SubItems.Add(stop.OrderInTrainLine.ToString());
                lvi.SubItems.Add(stop.KmFromStart.ToString());

                // loop over number of displaying period
                for (int i = 0; i < NUMBER_OF_PERIOD; i++ )
                {
                    // inicialize time with start time of line and plus multiplication of period
                    Time time = line.StartTime + Time.ToTime(i * (int) line.Period) + START_TIME_OF_LT;
                    // if departure exists (is not a empty value)
                    if (!stop.TimeDepartureChecked.Equals(Time.EmptyValue))
                    {
                        // use time departure
                        time += stop.TimeDepartureChecked;
                    }
                    // otherwise
                    else 
                    {
                        // if departure is empty - use arrival (last stop)
                        time += stop.TimeArrivalChecked;
                    }
                    lvi.SubItems.Add(time.ToString());
                }
                listViewLineTimetable.Items.Add(lvi);
            }
            listViewLineTimetable.EndUpdate();
        }

        //--------------------------------------------------
        // Station Timetable presentation
        //--------------------------------------------------

        private void fillStationDetails(String stationName)
        {
            if (stationName == "") return;

            TrainStation station = TrainStationCache.getInstance().getCacheContentOnName(stationName);

            textBoxStationID.Text = station.Id.ToString();
            textBoxStationName.Text = station.Name;
            textBoxStationCategory.Text = station.TownCategory.ToString();
            textBoxStationInhabitation.Text = station.Inhabitation.ToString();
        }

        private void prepareListViewStationTimetable(Timetable timetable, String stationName)
        {
            listViewStationTimetable.BeginUpdate();
            listViewStationTimetable.Items.Clear();

            // determine trainStation
            TrainStation station = TrainStationCache.getInstance().getCacheContentOnName(stationName);
            // find all lines passing this station
            List<TrainLineVariable> lines = findTrainLinesVariable(station.getTrainLines(), timetable);

            foreach(TrainLineVariable line in lines)
            {
                TrainStop stop = line.Line.getTrainStopOnStation(station.Name);

                Time arrival = stop.TimeArrival;
                Time departure = stop.TimeDeparture;
                int m = (END_TIME_OF_ST - START_TIME_OF_ST).ToMinutes();
                // loop until we are still in interval -> max M
                for( int i = 0; i * (int)line.Period  < m; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = line.LineNumber.ToString();
                    lvi.Tag = line.LineNumber.ToString();

                    // if areival is not equal 00:00
                    if (!arrival.Equals(Time.MinValue))
                    {
                        // start time of timetable + arrival on station + period time factor
                        lvi.SubItems.Add((START_TIME_OF_ST + arrival + line.StartTime + Time.ToTime(i* (int) line.Period)).ToString());
                    }
                    // otherwise
                    else
                    {
                        // if stop is the first, there no arrival exists
                        if (stop.OrderInTrainLine.Equals(0))
                            lvi.SubItems.Add("");
                        // otherwise (time is 00:00 but the stop is not first) use departure
                        else
                            lvi.SubItems.Add((START_TIME_OF_ST + departure + line.StartTime + Time.ToTime(i * (int)line.Period)).ToString());
                    }

                    // if departure is not equal 00:00
                    if (!departure.Equals(Time.MinValue))
                    {
                        lvi.SubItems.Add((START_TIME_OF_ST + departure + line.StartTime + Time.ToTime(i * (int)line.Period)).ToString());
                    }
                    // otherwise
                    else 
                    {
                        // if stop is a first one, there it is a legal time, use it
                        if (stop.OrderInTrainLine.Equals(0))
                            lvi.SubItems.Add((START_TIME_OF_ST + Time.MinValue + line.StartTime + Time.ToTime(i * (int)line.Period)).ToString());
                        // otherwise (time is 00:00 but the stop is not first)
                        else
                            // it has to be last stop, which has no departure (not continue)
                            lvi.SubItems.Add("");                        
                    }

                    listViewStationTimetable.Items.Add(lvi);
                }
            }



            listViewStationTimetable.EndUpdate();
        }

        private List<TrainLineVariable> findTrainLinesVariable(List<TrainLine> lines, Timetable tt) 
        {
            List<TrainLineVariable> resultLines = new List<TrainLineVariable>();
            // loop over all lines included in lines
            foreach(TrainLine line in lines)
            {
                // if timetable contains a trainLineVariable
                TrainLineVariable ll = tt.getVariableLineOnSelect(line.LineNumber);
                if (ll != null) 
                {
                    resultLines.Add(ll);
                }
            }
            return resultLines;
        }

        //--------------------------------------------------
        // Generating Timetables presentation
        //--------------------------------------------------

        private void prepareListViewGeneratingTimetable() 
        {
            
            listViewGeneratingTimetables.BeginUpdate();
            listViewGeneratingTimetables.Items.Clear();

            foreach (Timetable timetable in GenerationAlgorithm.getInstance().Timetables) 
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = timetable.ID.ToString();
                lvi.Tag = timetable.ID.ToString();

                lvi.SubItems.Add(timetable.ProgressiveChanges.ToString());
                lvi.SubItems.Add(timetable.RatingValue.ToString());

                listViewGeneratingTimetables.Items.Add(lvi);
            }

            listViewGeneratingTimetables.EndUpdate();
        }

        //--------------------------------------------------
        // Button START generation
        //--------------------------------------------------

        private void buttonStartGeneration_Click(object sender, EventArgs e)
        {
            // disable button
            this.buttonStartGeneration.Enabled = false;
            this.buttonNextGeneratingTimtables.Enabled = false;
            // enable butttons
            this.buttonAbortGeneration.Enabled = true;
            this.buttonCompleteAndStop.Enabled = true;

            // TODO: select howMany timetables you want

            // start asynchronous operation
           this.backgroundWorkerTG.RunWorkerAsync();
        }

        //--------------------------------------------------
        // Button ABORT generation
        //--------------------------------------------------

        private void buttonAbortGeneration_Click(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------
        // Button COMPLETE and STOP generation
        //--------------------------------------------------

        private void buttonCompleteAndStop_Click(object sender, EventArgs e)
        {
            // cancel computation
            this.backgroundWorkerTG.CancelAsync();

            // disable buttons
            this.buttonCompleteAndStop.Enabled = false;
            this.buttonAbortGeneration.Enabled = false;

        }

        //--------------------------------------------------
        // BACKGROUND WORKER methods
        //--------------------------------------------------

        private void backgroundWorkerTG_DoWork(object sender, DoWorkEventArgs e)
        {
            // get the worker, who call this method
            BackgroundWorker worker = sender as BackgroundWorker;
            //
            int number = (int) numericUpDownTimetables.Value;
            // do generation of timetables
            GenerationAlgorithm.getInstance().generateTimetables(number, worker, e);
        }

        private void backgroundWorkerTG_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // when progress changed, update listView and draw automatically again
            this.progressBarGT.Value = e.ProgressPercentage;
            prepareListViewGeneratingTimetable();
        }

        private void updateListViewProgressChanged() 
        {
            listViewGeneratingTimetables.BeginUpdate();
            // access last timetable
            Timetable tt = GenerationAlgorithm.getInstance().Timetables
                [GenerationAlgorithm.getInstance().Timetables.Count - 1];
            // access last listView
            ListViewItem lvi = listViewGeneratingTimetables.Items
                [listViewGeneratingTimetables.Items.Count - 1];
            lvi.SubItems[1].Text = tt.ProgressiveChanges.ToString();
            lvi.SubItems[2].Text = tt.RatingValue.ToString();

            listViewGeneratingTimetables.EndUpdate();
        }

        private void backgroundWorkerTG_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                prepareListViewGeneratingTimetable();
            }
            // enable buttons
            this.buttonNextGeneratingTimtables.Enabled = true;
            this.buttonStartGeneration.Enabled = true;


            // disable buttons
            this.buttonCompleteAndStop.Enabled = false;
            this.buttonAbortGeneration.Enabled = false;
        }

        //-----------------------------------------------------------
        // ListView STATION TIMETABLE - ColumnClick - Sorting
        //-----------------------------------------------------------

        private void listViewStationTimetable_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            FormUtil.listView_ColumnClick_Sorting(sender, e, listViewStationTimetable);
        }

        //-----------------------------------------------------------
        // NumberUpDown
        //-----------------------------------------------------------

        private void prepareNumericUpDownTimetables() 
        {
            numericUpDownTimetables.Value = NUMBER_OF_TIMETABLES;
        }

        //-----------------------------------------------------------
        // ListView GENERATING TIMETABLES - ColumnClick - Sorting
        //-----------------------------------------------------------

        private void listViewGeneratingTimetables_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FormUtil.listView_ColumnClick_Sorting(sender, e, listViewGeneratingTimetables);
        }

    }
}
