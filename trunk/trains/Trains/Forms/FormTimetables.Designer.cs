namespace PeriodicTimetableGeneration.Forms
{
    partial class FormTimetables
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlGeneratingTimetables = new System.Windows.Forms.TabControl();
            this.tabPageGenerating = new System.Windows.Forms.TabPage();
            this.splitContainerTimetables = new System.Windows.Forms.SplitContainer();
            this.listViewGeneratingTimetables = new System.Windows.Forms.ListView();
            this.imageListBig = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxNumberOfTimetables = new System.Windows.Forms.GroupBox();
            this.numericUpDownTimetables = new System.Windows.Forms.NumericUpDown();
            this.groupBoxProgress = new System.Windows.Forms.GroupBox();
            this.progressBarGT = new System.Windows.Forms.ProgressBar();
            this.groupBoxGeneration = new System.Windows.Forms.GroupBox();
            this.buttonCompleteAndStop = new System.Windows.Forms.Button();
            this.buttonAbortGeneration = new System.Windows.Forms.Button();
            this.buttonStartGeneration = new System.Windows.Forms.Button();
            this.buttonNextGeneratingTimtables = new System.Windows.Forms.Button();
            this.tabPageLinesTimetables = new System.Windows.Forms.TabPage();
            this.splitContainerLinesTimetables = new System.Windows.Forms.SplitContainer();
            this.groupBoxLinesDetails = new System.Windows.Forms.GroupBox();
            this.textBoxPeriod = new System.Windows.Forms.TextBox();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.textBoxTypeOfTrain = new System.Windows.Forms.TextBox();
            this.labelTypeOfTrain = new System.Windows.Forms.Label();
            this.textBoxLineNumber = new System.Windows.Forms.TextBox();
            this.labelLineNumber = new System.Windows.Forms.Label();
            this.listViewLineTimetable = new System.Windows.Forms.ListView();
            this.columnHeaderTrainStation = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderOrder = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderKmFromStart = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTime1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTime2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTime3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTime4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTime5 = new System.Windows.Forms.ColumnHeader();
            this.buttonNextLinesTimetables = new System.Windows.Forms.Button();
            this.groupBoxSelectLine = new System.Windows.Forms.GroupBox();
            this.comboBoxSelectedLine = new System.Windows.Forms.ComboBox();
            this.groupBoxSelectTimetableLT = new System.Windows.Forms.GroupBox();
            this.comboBoxSelectedTimetableLT = new System.Windows.Forms.ComboBox();
            this.tabPageStationsTimetables = new System.Windows.Forms.TabPage();
            this.splitContainerStationTimetables = new System.Windows.Forms.SplitContainer();
            this.groupBoxStationsDetails = new System.Windows.Forms.GroupBox();
            this.textBoxStationInhabitation = new System.Windows.Forms.TextBox();
            this.labelStationInhabitation = new System.Windows.Forms.Label();
            this.textBoxStationCategory = new System.Windows.Forms.TextBox();
            this.labelStationCategory = new System.Windows.Forms.Label();
            this.textBoxStationName = new System.Windows.Forms.TextBox();
            this.labelStationName = new System.Windows.Forms.Label();
            this.textBoxStationID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.listViewStationTimetable = new System.Windows.Forms.ListView();
            this.groupBoxSelectedStation = new System.Windows.Forms.GroupBox();
            this.comboBoxSelectedStation = new System.Windows.Forms.ComboBox();
            this.groupBoxSelectTimetableST = new System.Windows.Forms.GroupBox();
            this.comboBoxSelectedTimetableST = new System.Windows.Forms.ComboBox();
            this.buttonExitStationsTimetables = new System.Windows.Forms.Button();
            this.backgroundWorkerTG = new System.ComponentModel.BackgroundWorker();
            this.columnHeaderAttempt = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderProgressiveChanges = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderRatingValue = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderGenerationTime = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderNote = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderLineNumber = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderArrival = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderDeparture = new PeriodicTimetableGeneration.ColHeader();
            this.tabControlGeneratingTimetables.SuspendLayout();
            this.tabPageGenerating.SuspendLayout();
            this.splitContainerTimetables.Panel1.SuspendLayout();
            this.splitContainerTimetables.Panel2.SuspendLayout();
            this.splitContainerTimetables.SuspendLayout();
            this.groupBoxNumberOfTimetables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimetables)).BeginInit();
            this.groupBoxProgress.SuspendLayout();
            this.groupBoxGeneration.SuspendLayout();
            this.tabPageLinesTimetables.SuspendLayout();
            this.splitContainerLinesTimetables.Panel1.SuspendLayout();
            this.splitContainerLinesTimetables.Panel2.SuspendLayout();
            this.splitContainerLinesTimetables.SuspendLayout();
            this.groupBoxLinesDetails.SuspendLayout();
            this.groupBoxSelectLine.SuspendLayout();
            this.groupBoxSelectTimetableLT.SuspendLayout();
            this.tabPageStationsTimetables.SuspendLayout();
            this.splitContainerStationTimetables.Panel1.SuspendLayout();
            this.splitContainerStationTimetables.Panel2.SuspendLayout();
            this.splitContainerStationTimetables.SuspendLayout();
            this.groupBoxStationsDetails.SuspendLayout();
            this.groupBoxSelectedStation.SuspendLayout();
            this.groupBoxSelectTimetableST.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlGeneratingTimetables
            // 
            this.tabControlGeneratingTimetables.Controls.Add(this.tabPageGenerating);
            this.tabControlGeneratingTimetables.Controls.Add(this.tabPageLinesTimetables);
            this.tabControlGeneratingTimetables.Controls.Add(this.tabPageStationsTimetables);
            this.tabControlGeneratingTimetables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlGeneratingTimetables.Location = new System.Drawing.Point(0, 0);
            this.tabControlGeneratingTimetables.Name = "tabControlGeneratingTimetables";
            this.tabControlGeneratingTimetables.SelectedIndex = 0;
            this.tabControlGeneratingTimetables.Size = new System.Drawing.Size(984, 564);
            this.tabControlGeneratingTimetables.TabIndex = 0;
            // 
            // tabPageGenerating
            // 
            this.tabPageGenerating.Controls.Add(this.splitContainerTimetables);
            this.tabPageGenerating.Location = new System.Drawing.Point(4, 22);
            this.tabPageGenerating.Name = "tabPageGenerating";
            this.tabPageGenerating.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGenerating.Size = new System.Drawing.Size(976, 538);
            this.tabPageGenerating.TabIndex = 0;
            this.tabPageGenerating.Text = "Generating Timetables";
            this.tabPageGenerating.UseVisualStyleBackColor = true;
            // 
            // splitContainerTimetables
            // 
            this.splitContainerTimetables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTimetables.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerTimetables.IsSplitterFixed = true;
            this.splitContainerTimetables.Location = new System.Drawing.Point(3, 3);
            this.splitContainerTimetables.Name = "splitContainerTimetables";
            // 
            // splitContainerTimetables.Panel1
            // 
            this.splitContainerTimetables.Panel1.Controls.Add(this.listViewGeneratingTimetables);
            // 
            // splitContainerTimetables.Panel2
            // 
            this.splitContainerTimetables.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerTimetables.Panel2.Controls.Add(this.groupBoxNumberOfTimetables);
            this.splitContainerTimetables.Panel2.Controls.Add(this.groupBoxProgress);
            this.splitContainerTimetables.Panel2.Controls.Add(this.groupBoxGeneration);
            this.splitContainerTimetables.Panel2.Controls.Add(this.buttonNextGeneratingTimtables);
            this.splitContainerTimetables.Size = new System.Drawing.Size(970, 532);
            this.splitContainerTimetables.SplitterDistance = 844;
            this.splitContainerTimetables.TabIndex = 0;
            // 
            // listViewGeneratingTimetables
            // 
            this.listViewGeneratingTimetables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAttempt,
            this.columnHeaderProgressiveChanges,
            this.columnHeaderRatingValue,
            this.columnHeaderGenerationTime,
            this.columnHeaderNote});
            this.listViewGeneratingTimetables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGeneratingTimetables.FullRowSelect = true;
            this.listViewGeneratingTimetables.GridLines = true;
            this.listViewGeneratingTimetables.LargeImageList = this.imageListBig;
            this.listViewGeneratingTimetables.Location = new System.Drawing.Point(0, 0);
            this.listViewGeneratingTimetables.Name = "listViewGeneratingTimetables";
            this.listViewGeneratingTimetables.Size = new System.Drawing.Size(844, 532);
            this.listViewGeneratingTimetables.SmallImageList = this.imageListSmall;
            this.listViewGeneratingTimetables.TabIndex = 0;
            this.listViewGeneratingTimetables.UseCompatibleStateImageBehavior = false;
            this.listViewGeneratingTimetables.View = System.Windows.Forms.View.Details;
            this.listViewGeneratingTimetables.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewGeneratingTimetables_ColumnClick);
            // 
            // imageListBig
            // 
            this.imageListBig.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListBig.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListBig.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBoxNumberOfTimetables
            // 
            this.groupBoxNumberOfTimetables.Controls.Add(this.numericUpDownTimetables);
            this.groupBoxNumberOfTimetables.Location = new System.Drawing.Point(3, 27);
            this.groupBoxNumberOfTimetables.Name = "groupBoxNumberOfTimetables";
            this.groupBoxNumberOfTimetables.Size = new System.Drawing.Size(116, 47);
            this.groupBoxNumberOfTimetables.TabIndex = 5;
            this.groupBoxNumberOfTimetables.TabStop = false;
            this.groupBoxNumberOfTimetables.Text = "# Timetables";
            // 
            // numericUpDownTimetables
            // 
            this.numericUpDownTimetables.Location = new System.Drawing.Point(7, 20);
            this.numericUpDownTimetables.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimetables.Name = "numericUpDownTimetables";
            this.numericUpDownTimetables.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownTimetables.TabIndex = 0;
            this.numericUpDownTimetables.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBoxProgress
            // 
            this.groupBoxProgress.Controls.Add(this.progressBarGT);
            this.groupBoxProgress.Location = new System.Drawing.Point(3, 215);
            this.groupBoxProgress.Name = "groupBoxProgress";
            this.groupBoxProgress.Size = new System.Drawing.Size(116, 45);
            this.groupBoxProgress.TabIndex = 4;
            this.groupBoxProgress.TabStop = false;
            this.groupBoxProgress.Text = "Progress";
            // 
            // progressBarGT
            // 
            this.progressBarGT.Location = new System.Drawing.Point(7, 20);
            this.progressBarGT.Name = "progressBarGT";
            this.progressBarGT.Size = new System.Drawing.Size(100, 18);
            this.progressBarGT.TabIndex = 0;
            // 
            // groupBoxGeneration
            // 
            this.groupBoxGeneration.Controls.Add(this.buttonCompleteAndStop);
            this.groupBoxGeneration.Controls.Add(this.buttonAbortGeneration);
            this.groupBoxGeneration.Controls.Add(this.buttonStartGeneration);
            this.groupBoxGeneration.Location = new System.Drawing.Point(3, 80);
            this.groupBoxGeneration.Name = "groupBoxGeneration";
            this.groupBoxGeneration.Size = new System.Drawing.Size(116, 129);
            this.groupBoxGeneration.TabIndex = 3;
            this.groupBoxGeneration.TabStop = false;
            this.groupBoxGeneration.Text = "Generation";
            // 
            // buttonCompleteAndStop
            // 
            this.buttonCompleteAndStop.Enabled = false;
            this.buttonCompleteAndStop.Location = new System.Drawing.Point(6, 91);
            this.buttonCompleteAndStop.Name = "buttonCompleteAndStop";
            this.buttonCompleteAndStop.Size = new System.Drawing.Size(105, 30);
            this.buttonCompleteAndStop.TabIndex = 6;
            this.buttonCompleteAndStop.Text = "Complete and Stop";
            this.buttonCompleteAndStop.UseVisualStyleBackColor = true;
            this.buttonCompleteAndStop.Click += new System.EventHandler(this.buttonCompleteAndStop_Click);
            // 
            // buttonAbortGeneration
            // 
            this.buttonAbortGeneration.Enabled = false;
            this.buttonAbortGeneration.Location = new System.Drawing.Point(6, 55);
            this.buttonAbortGeneration.Name = "buttonAbortGeneration";
            this.buttonAbortGeneration.Size = new System.Drawing.Size(105, 30);
            this.buttonAbortGeneration.TabIndex = 5;
            this.buttonAbortGeneration.Text = "Abort";
            this.buttonAbortGeneration.UseVisualStyleBackColor = true;
            this.buttonAbortGeneration.Click += new System.EventHandler(this.buttonAbortGeneration_Click);
            // 
            // buttonStartGeneration
            // 
            this.buttonStartGeneration.Location = new System.Drawing.Point(6, 19);
            this.buttonStartGeneration.Name = "buttonStartGeneration";
            this.buttonStartGeneration.Size = new System.Drawing.Size(105, 30);
            this.buttonStartGeneration.TabIndex = 4;
            this.buttonStartGeneration.Text = "Start";
            this.buttonStartGeneration.UseVisualStyleBackColor = true;
            this.buttonStartGeneration.Click += new System.EventHandler(this.buttonStartGeneration_Click);
            // 
            // buttonNextGeneratingTimtables
            // 
            this.buttonNextGeneratingTimtables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNextGeneratingTimtables.Enabled = false;
            this.buttonNextGeneratingTimtables.Location = new System.Drawing.Point(14, 499);
            this.buttonNextGeneratingTimtables.Name = "buttonNextGeneratingTimtables";
            this.buttonNextGeneratingTimtables.Size = new System.Drawing.Size(100, 30);
            this.buttonNextGeneratingTimtables.TabIndex = 2;
            this.buttonNextGeneratingTimtables.Text = "Next";
            this.buttonNextGeneratingTimtables.UseVisualStyleBackColor = true;
            this.buttonNextGeneratingTimtables.Click += new System.EventHandler(this.buttonNextGeneratingTimtables_Click);
            // 
            // tabPageLinesTimetables
            // 
            this.tabPageLinesTimetables.Controls.Add(this.splitContainerLinesTimetables);
            this.tabPageLinesTimetables.Location = new System.Drawing.Point(4, 22);
            this.tabPageLinesTimetables.Name = "tabPageLinesTimetables";
            this.tabPageLinesTimetables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLinesTimetables.Size = new System.Drawing.Size(976, 538);
            this.tabPageLinesTimetables.TabIndex = 1;
            this.tabPageLinesTimetables.Text = "Lines\' Timetables";
            this.tabPageLinesTimetables.UseVisualStyleBackColor = true;
            // 
            // splitContainerLinesTimetables
            // 
            this.splitContainerLinesTimetables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLinesTimetables.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerLinesTimetables.IsSplitterFixed = true;
            this.splitContainerLinesTimetables.Location = new System.Drawing.Point(3, 3);
            this.splitContainerLinesTimetables.Name = "splitContainerLinesTimetables";
            // 
            // splitContainerLinesTimetables.Panel1
            // 
            this.splitContainerLinesTimetables.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerLinesTimetables.Panel1.Controls.Add(this.groupBoxLinesDetails);
            this.splitContainerLinesTimetables.Panel1.Controls.Add(this.listViewLineTimetable);
            // 
            // splitContainerLinesTimetables.Panel2
            // 
            this.splitContainerLinesTimetables.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerLinesTimetables.Panel2.Controls.Add(this.buttonNextLinesTimetables);
            this.splitContainerLinesTimetables.Panel2.Controls.Add(this.groupBoxSelectLine);
            this.splitContainerLinesTimetables.Panel2.Controls.Add(this.groupBoxSelectTimetableLT);
            this.splitContainerLinesTimetables.Size = new System.Drawing.Size(970, 532);
            this.splitContainerLinesTimetables.SplitterDistance = 844;
            this.splitContainerLinesTimetables.TabIndex = 0;
            // 
            // groupBoxLinesDetails
            // 
            this.groupBoxLinesDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLinesDetails.Controls.Add(this.textBoxPeriod);
            this.groupBoxLinesDetails.Controls.Add(this.labelPeriod);
            this.groupBoxLinesDetails.Controls.Add(this.textBoxTypeOfTrain);
            this.groupBoxLinesDetails.Controls.Add(this.labelTypeOfTrain);
            this.groupBoxLinesDetails.Controls.Add(this.textBoxLineNumber);
            this.groupBoxLinesDetails.Controls.Add(this.labelLineNumber);
            this.groupBoxLinesDetails.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLinesDetails.Name = "groupBoxLinesDetails";
            this.groupBoxLinesDetails.Size = new System.Drawing.Size(838, 47);
            this.groupBoxLinesDetails.TabIndex = 1;
            this.groupBoxLinesDetails.TabStop = false;
            this.groupBoxLinesDetails.Text = "Line\'s Details";
            // 
            // textBoxPeriod
            // 
            this.textBoxPeriod.Enabled = false;
            this.textBoxPeriod.Location = new System.Drawing.Point(406, 19);
            this.textBoxPeriod.Name = "textBoxPeriod";
            this.textBoxPeriod.Size = new System.Drawing.Size(100, 20);
            this.textBoxPeriod.TabIndex = 5;
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Location = new System.Drawing.Point(363, 22);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(37, 13);
            this.labelPeriod.TabIndex = 4;
            this.labelPeriod.Text = "Period";
            // 
            // textBoxTypeOfTrain
            // 
            this.textBoxTypeOfTrain.Enabled = false;
            this.textBoxTypeOfTrain.Location = new System.Drawing.Point(248, 19);
            this.textBoxTypeOfTrain.Name = "textBoxTypeOfTrain";
            this.textBoxTypeOfTrain.Size = new System.Drawing.Size(100, 20);
            this.textBoxTypeOfTrain.TabIndex = 3;
            // 
            // labelTypeOfTrain
            // 
            this.labelTypeOfTrain.AutoSize = true;
            this.labelTypeOfTrain.Location = new System.Drawing.Point(172, 22);
            this.labelTypeOfTrain.Name = "labelTypeOfTrain";
            this.labelTypeOfTrain.Size = new System.Drawing.Size(70, 13);
            this.labelTypeOfTrain.TabIndex = 2;
            this.labelTypeOfTrain.Text = "Type of Train";
            // 
            // textBoxLineNumber
            // 
            this.textBoxLineNumber.Enabled = false;
            this.textBoxLineNumber.Location = new System.Drawing.Point(56, 19);
            this.textBoxLineNumber.Name = "textBoxLineNumber";
            this.textBoxLineNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxLineNumber.TabIndex = 1;
            // 
            // labelLineNumber
            // 
            this.labelLineNumber.AutoSize = true;
            this.labelLineNumber.Location = new System.Drawing.Point(6, 22);
            this.labelLineNumber.Name = "labelLineNumber";
            this.labelLineNumber.Size = new System.Drawing.Size(44, 13);
            this.labelLineNumber.TabIndex = 0;
            this.labelLineNumber.Text = "Number";
            // 
            // listViewLineTimetable
            // 
            this.listViewLineTimetable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLineTimetable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTrainStation,
            this.columnHeaderOrder,
            this.columnHeaderKmFromStart,
            this.columnHeaderTime1,
            this.columnHeaderTime2,
            this.columnHeaderTime3,
            this.columnHeaderTime4,
            this.columnHeaderTime5});
            this.listViewLineTimetable.FullRowSelect = true;
            this.listViewLineTimetable.GridLines = true;
            this.listViewLineTimetable.LargeImageList = this.imageListBig;
            this.listViewLineTimetable.Location = new System.Drawing.Point(3, 56);
            this.listViewLineTimetable.Name = "listViewLineTimetable";
            this.listViewLineTimetable.Size = new System.Drawing.Size(838, 471);
            this.listViewLineTimetable.SmallImageList = this.imageListSmall;
            this.listViewLineTimetable.TabIndex = 0;
            this.listViewLineTimetable.UseCompatibleStateImageBehavior = false;
            this.listViewLineTimetable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTrainStation
            // 
            this.columnHeaderTrainStation.Text = "Train Station";
            this.columnHeaderTrainStation.Width = 150;
            // 
            // columnHeaderOrder
            // 
            this.columnHeaderOrder.Text = "Order";
            this.columnHeaderOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeaderKmFromStart
            // 
            this.columnHeaderKmFromStart.Text = "Distance";
            this.columnHeaderKmFromStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeaderTime1
            // 
            this.columnHeaderTime1.Text = "Time";
            this.columnHeaderTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTime1.Width = 100;
            // 
            // columnHeaderTime2
            // 
            this.columnHeaderTime2.Text = "Time";
            this.columnHeaderTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTime2.Width = 100;
            // 
            // columnHeaderTime3
            // 
            this.columnHeaderTime3.Text = "Time";
            this.columnHeaderTime3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTime3.Width = 100;
            // 
            // columnHeaderTime4
            // 
            this.columnHeaderTime4.Text = "Time";
            this.columnHeaderTime4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTime4.Width = 100;
            // 
            // columnHeaderTime5
            // 
            this.columnHeaderTime5.Text = "Time";
            this.columnHeaderTime5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTime5.Width = 100;
            // 
            // buttonNextLinesTimetables
            // 
            this.buttonNextLinesTimetables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNextLinesTimetables.Location = new System.Drawing.Point(14, 499);
            this.buttonNextLinesTimetables.Name = "buttonNextLinesTimetables";
            this.buttonNextLinesTimetables.Size = new System.Drawing.Size(100, 30);
            this.buttonNextLinesTimetables.TabIndex = 3;
            this.buttonNextLinesTimetables.Text = "Next";
            this.buttonNextLinesTimetables.UseVisualStyleBackColor = true;
            this.buttonNextLinesTimetables.Click += new System.EventHandler(this.buttonNextLinesTimetables_Click);
            // 
            // groupBoxSelectLine
            // 
            this.groupBoxSelectLine.Controls.Add(this.comboBoxSelectedLine);
            this.groupBoxSelectLine.Location = new System.Drawing.Point(2, 137);
            this.groupBoxSelectLine.Name = "groupBoxSelectLine";
            this.groupBoxSelectLine.Size = new System.Drawing.Size(116, 46);
            this.groupBoxSelectLine.TabIndex = 2;
            this.groupBoxSelectLine.TabStop = false;
            this.groupBoxSelectLine.Text = "Select Line";
            // 
            // comboBoxSelectedLine
            // 
            this.comboBoxSelectedLine.FormattingEnabled = true;
            this.comboBoxSelectedLine.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSelectedLine.Name = "comboBoxSelectedLine";
            this.comboBoxSelectedLine.Size = new System.Drawing.Size(105, 21);
            this.comboBoxSelectedLine.Sorted = true;
            this.comboBoxSelectedLine.TabIndex = 0;
            this.comboBoxSelectedLine.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectedLine_SelectedIndexChanged);
            // 
            // groupBoxSelectTimetableLT
            // 
            this.groupBoxSelectTimetableLT.Controls.Add(this.comboBoxSelectedTimetableLT);
            this.groupBoxSelectTimetableLT.Location = new System.Drawing.Point(3, 85);
            this.groupBoxSelectTimetableLT.Name = "groupBoxSelectTimetableLT";
            this.groupBoxSelectTimetableLT.Size = new System.Drawing.Size(116, 46);
            this.groupBoxSelectTimetableLT.TabIndex = 1;
            this.groupBoxSelectTimetableLT.TabStop = false;
            this.groupBoxSelectTimetableLT.Text = "Select Timetable";
            // 
            // comboBoxSelectedTimetableLT
            // 
            this.comboBoxSelectedTimetableLT.FormattingEnabled = true;
            this.comboBoxSelectedTimetableLT.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSelectedTimetableLT.Name = "comboBoxSelectedTimetableLT";
            this.comboBoxSelectedTimetableLT.Size = new System.Drawing.Size(105, 21);
            this.comboBoxSelectedTimetableLT.TabIndex = 0;
            this.comboBoxSelectedTimetableLT.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectedTimetableLT_SelectedIndexChanged);
            // 
            // tabPageStationsTimetables
            // 
            this.tabPageStationsTimetables.Controls.Add(this.splitContainerStationTimetables);
            this.tabPageStationsTimetables.Location = new System.Drawing.Point(4, 22);
            this.tabPageStationsTimetables.Name = "tabPageStationsTimetables";
            this.tabPageStationsTimetables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStationsTimetables.Size = new System.Drawing.Size(976, 538);
            this.tabPageStationsTimetables.TabIndex = 2;
            this.tabPageStationsTimetables.Text = "Stations\' Timetables";
            this.tabPageStationsTimetables.UseVisualStyleBackColor = true;
            // 
            // splitContainerStationTimetables
            // 
            this.splitContainerStationTimetables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStationTimetables.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerStationTimetables.IsSplitterFixed = true;
            this.splitContainerStationTimetables.Location = new System.Drawing.Point(3, 3);
            this.splitContainerStationTimetables.Name = "splitContainerStationTimetables";
            // 
            // splitContainerStationTimetables.Panel1
            // 
            this.splitContainerStationTimetables.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerStationTimetables.Panel1.Controls.Add(this.groupBoxStationsDetails);
            this.splitContainerStationTimetables.Panel1.Controls.Add(this.listViewStationTimetable);
            // 
            // splitContainerStationTimetables.Panel2
            // 
            this.splitContainerStationTimetables.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerStationTimetables.Panel2.Controls.Add(this.groupBoxSelectedStation);
            this.splitContainerStationTimetables.Panel2.Controls.Add(this.groupBoxSelectTimetableST);
            this.splitContainerStationTimetables.Panel2.Controls.Add(this.buttonExitStationsTimetables);
            this.splitContainerStationTimetables.Size = new System.Drawing.Size(970, 532);
            this.splitContainerStationTimetables.SplitterDistance = 844;
            this.splitContainerStationTimetables.TabIndex = 0;
            // 
            // groupBoxStationsDetails
            // 
            this.groupBoxStationsDetails.Controls.Add(this.textBoxStationInhabitation);
            this.groupBoxStationsDetails.Controls.Add(this.labelStationInhabitation);
            this.groupBoxStationsDetails.Controls.Add(this.textBoxStationCategory);
            this.groupBoxStationsDetails.Controls.Add(this.labelStationCategory);
            this.groupBoxStationsDetails.Controls.Add(this.textBoxStationName);
            this.groupBoxStationsDetails.Controls.Add(this.labelStationName);
            this.groupBoxStationsDetails.Controls.Add(this.textBoxStationID);
            this.groupBoxStationsDetails.Controls.Add(this.labelID);
            this.groupBoxStationsDetails.Location = new System.Drawing.Point(3, 3);
            this.groupBoxStationsDetails.Name = "groupBoxStationsDetails";
            this.groupBoxStationsDetails.Size = new System.Drawing.Size(750, 50);
            this.groupBoxStationsDetails.TabIndex = 3;
            this.groupBoxStationsDetails.TabStop = false;
            this.groupBoxStationsDetails.Text = "Station\'s Details";
            // 
            // textBoxStationInhabitation
            // 
            this.textBoxStationInhabitation.Enabled = false;
            this.textBoxStationInhabitation.Location = new System.Drawing.Point(592, 19);
            this.textBoxStationInhabitation.Name = "textBoxStationInhabitation";
            this.textBoxStationInhabitation.Size = new System.Drawing.Size(150, 20);
            this.textBoxStationInhabitation.TabIndex = 8;
            // 
            // labelStationInhabitation
            // 
            this.labelStationInhabitation.AutoSize = true;
            this.labelStationInhabitation.Location = new System.Drawing.Point(524, 22);
            this.labelStationInhabitation.Name = "labelStationInhabitation";
            this.labelStationInhabitation.Size = new System.Drawing.Size(62, 13);
            this.labelStationInhabitation.TabIndex = 7;
            this.labelStationInhabitation.Text = "Inhabitation";
            // 
            // textBoxStationCategory
            // 
            this.textBoxStationCategory.Enabled = false;
            this.textBoxStationCategory.Location = new System.Drawing.Point(407, 19);
            this.textBoxStationCategory.Name = "textBoxStationCategory";
            this.textBoxStationCategory.Size = new System.Drawing.Size(100, 20);
            this.textBoxStationCategory.TabIndex = 6;
            // 
            // labelStationCategory
            // 
            this.labelStationCategory.AutoSize = true;
            this.labelStationCategory.Location = new System.Drawing.Point(352, 22);
            this.labelStationCategory.Name = "labelStationCategory";
            this.labelStationCategory.Size = new System.Drawing.Size(49, 13);
            this.labelStationCategory.TabIndex = 5;
            this.labelStationCategory.Text = "Category";
            // 
            // textBoxStationName
            // 
            this.textBoxStationName.Enabled = false;
            this.textBoxStationName.Location = new System.Drawing.Point(137, 19);
            this.textBoxStationName.Name = "textBoxStationName";
            this.textBoxStationName.Size = new System.Drawing.Size(200, 20);
            this.textBoxStationName.TabIndex = 4;
            // 
            // labelStationName
            // 
            this.labelStationName.AutoSize = true;
            this.labelStationName.Location = new System.Drawing.Point(96, 22);
            this.labelStationName.Name = "labelStationName";
            this.labelStationName.Size = new System.Drawing.Size(35, 13);
            this.labelStationName.TabIndex = 3;
            this.labelStationName.Text = "Name";
            // 
            // textBoxStationID
            // 
            this.textBoxStationID.Enabled = false;
            this.textBoxStationID.Location = new System.Drawing.Point(30, 19);
            this.textBoxStationID.Name = "textBoxStationID";
            this.textBoxStationID.Size = new System.Drawing.Size(50, 20);
            this.textBoxStationID.TabIndex = 2;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(6, 22);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 1;
            this.labelID.Text = "ID";
            // 
            // listViewStationTimetable
            // 
            this.listViewStationTimetable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLineNumber,
            this.columnHeaderArrival,
            this.columnHeaderDeparture});
            this.listViewStationTimetable.FullRowSelect = true;
            this.listViewStationTimetable.GridLines = true;
            this.listViewStationTimetable.LargeImageList = this.imageListBig;
            this.listViewStationTimetable.Location = new System.Drawing.Point(0, 59);
            this.listViewStationTimetable.Name = "listViewStationTimetable";
            this.listViewStationTimetable.Size = new System.Drawing.Size(817, 446);
            this.listViewStationTimetable.SmallImageList = this.imageListSmall;
            this.listViewStationTimetable.TabIndex = 0;
            this.listViewStationTimetable.UseCompatibleStateImageBehavior = false;
            this.listViewStationTimetable.View = System.Windows.Forms.View.Details;
            this.listViewStationTimetable.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewStationTimetable_ColumnClick);
            // 
            // groupBoxSelectedStation
            // 
            this.groupBoxSelectedStation.Controls.Add(this.comboBoxSelectedStation);
            this.groupBoxSelectedStation.Location = new System.Drawing.Point(3, 138);
            this.groupBoxSelectedStation.Name = "groupBoxSelectedStation";
            this.groupBoxSelectedStation.Size = new System.Drawing.Size(116, 50);
            this.groupBoxSelectedStation.TabIndex = 6;
            this.groupBoxSelectedStation.TabStop = false;
            this.groupBoxSelectedStation.Text = "Select Station";
            // 
            // comboBoxSelectedStation
            // 
            this.comboBoxSelectedStation.FormattingEnabled = true;
            this.comboBoxSelectedStation.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSelectedStation.Name = "comboBoxSelectedStation";
            this.comboBoxSelectedStation.Size = new System.Drawing.Size(105, 21);
            this.comboBoxSelectedStation.Sorted = true;
            this.comboBoxSelectedStation.TabIndex = 0;
            this.comboBoxSelectedStation.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectedStation_SelectedIndexChanged);
            // 
            // groupBoxSelectTimetableST
            // 
            this.groupBoxSelectTimetableST.Controls.Add(this.comboBoxSelectedTimetableST);
            this.groupBoxSelectTimetableST.Location = new System.Drawing.Point(3, 85);
            this.groupBoxSelectTimetableST.Name = "groupBoxSelectTimetableST";
            this.groupBoxSelectTimetableST.Size = new System.Drawing.Size(116, 47);
            this.groupBoxSelectTimetableST.TabIndex = 5;
            this.groupBoxSelectTimetableST.TabStop = false;
            this.groupBoxSelectTimetableST.Text = "Select Timetable";
            // 
            // comboBoxSelectedTimetableST
            // 
            this.comboBoxSelectedTimetableST.FormattingEnabled = true;
            this.comboBoxSelectedTimetableST.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSelectedTimetableST.Name = "comboBoxSelectedTimetableST";
            this.comboBoxSelectedTimetableST.Size = new System.Drawing.Size(105, 21);
            this.comboBoxSelectedTimetableST.TabIndex = 0;
            this.comboBoxSelectedTimetableST.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectedTimtableST_SelectedIndexChanged);
            // 
            // buttonExitStationsTimetables
            // 
            this.buttonExitStationsTimetables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExitStationsTimetables.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.buttonExitStationsTimetables.Location = new System.Drawing.Point(11, 499);
            this.buttonExitStationsTimetables.Name = "buttonExitStationsTimetables";
            this.buttonExitStationsTimetables.Size = new System.Drawing.Size(100, 30);
            this.buttonExitStationsTimetables.TabIndex = 4;
            this.buttonExitStationsTimetables.Text = "Exit";
            this.buttonExitStationsTimetables.UseVisualStyleBackColor = true;
            this.buttonExitStationsTimetables.Click += new System.EventHandler(this.buttonExitStationsTimetables_Click);
            // 
            // backgroundWorkerTG
            // 
            this.backgroundWorkerTG.WorkerReportsProgress = true;
            this.backgroundWorkerTG.WorkerSupportsCancellation = true;
            this.backgroundWorkerTG.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTG_DoWork);
            this.backgroundWorkerTG.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTG_RunWorkerCompleted);
            this.backgroundWorkerTG.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTG_ProgressChanged);
            // 
            // columnHeaderAttempt
            // 
            this.columnHeaderAttempt.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderAttempt.Text = "Attempt";
            // 
            // columnHeaderProgressiveChanges
            // 
            this.columnHeaderProgressiveChanges.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderProgressiveChanges.Text = "Progressive Changes";
            this.columnHeaderProgressiveChanges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderProgressiveChanges.Width = 120;
            // 
            // columnHeaderRatingValue
            // 
            this.columnHeaderRatingValue.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderRatingValue.Text = "Rating Value";
            this.columnHeaderRatingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderRatingValue.Width = 120;
            // 
            // columnHeaderGenerationTime
            // 
            this.columnHeaderGenerationTime.Text = "Generation Time";
            this.columnHeaderGenerationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderGenerationTime.Width = 100;
            // 
            // columnHeaderNote
            // 
            this.columnHeaderNote.Text = "Note";
            this.columnHeaderNote.Width = 400;
            // 
            // columnHeaderLineNumber
            // 
            this.columnHeaderLineNumber.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderLineNumber.Text = "Line Number";
            this.columnHeaderLineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderLineNumber.Width = 100;
            // 
            // columnHeaderArrival
            // 
            this.columnHeaderArrival.Text = "Arrival";
            this.columnHeaderArrival.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderArrival.Width = 100;
            // 
            // columnHeaderDeparture
            // 
            this.columnHeaderDeparture.Text = "Departure";
            this.columnHeaderDeparture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderDeparture.Width = 100;
            // 
            // FormTimetables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 564);
            this.Controls.Add(this.tabControlGeneratingTimetables);
            this.Name = "FormTimetables";
            this.Text = "Timetables";
            this.Load += new System.EventHandler(this.FormTimetables_Load);
            this.tabControlGeneratingTimetables.ResumeLayout(false);
            this.tabPageGenerating.ResumeLayout(false);
            this.splitContainerTimetables.Panel1.ResumeLayout(false);
            this.splitContainerTimetables.Panel2.ResumeLayout(false);
            this.splitContainerTimetables.ResumeLayout(false);
            this.groupBoxNumberOfTimetables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimetables)).EndInit();
            this.groupBoxProgress.ResumeLayout(false);
            this.groupBoxGeneration.ResumeLayout(false);
            this.tabPageLinesTimetables.ResumeLayout(false);
            this.splitContainerLinesTimetables.Panel1.ResumeLayout(false);
            this.splitContainerLinesTimetables.Panel2.ResumeLayout(false);
            this.splitContainerLinesTimetables.ResumeLayout(false);
            this.groupBoxLinesDetails.ResumeLayout(false);
            this.groupBoxLinesDetails.PerformLayout();
            this.groupBoxSelectLine.ResumeLayout(false);
            this.groupBoxSelectTimetableLT.ResumeLayout(false);
            this.tabPageStationsTimetables.ResumeLayout(false);
            this.splitContainerStationTimetables.Panel1.ResumeLayout(false);
            this.splitContainerStationTimetables.Panel2.ResumeLayout(false);
            this.splitContainerStationTimetables.ResumeLayout(false);
            this.groupBoxStationsDetails.ResumeLayout(false);
            this.groupBoxStationsDetails.PerformLayout();
            this.groupBoxSelectedStation.ResumeLayout(false);
            this.groupBoxSelectTimetableST.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlGeneratingTimetables;
        private System.Windows.Forms.TabPage tabPageGenerating;
        private System.Windows.Forms.TabPage tabPageLinesTimetables;
        private System.Windows.Forms.TabPage tabPageStationsTimetables;
        private System.Windows.Forms.SplitContainer splitContainerTimetables;
        private System.Windows.Forms.SplitContainer splitContainerLinesTimetables;
        private System.Windows.Forms.ListView listViewGeneratingTimetables;
        private System.Windows.Forms.SplitContainer splitContainerStationTimetables;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.ListView listViewLineTimetable;
        private System.Windows.Forms.ListView listViewStationTimetable;
        private System.Windows.Forms.GroupBox groupBoxSelectLine;
        private System.Windows.Forms.ComboBox comboBoxSelectedLine;
        private System.Windows.Forms.GroupBox groupBoxSelectTimetableLT;
        private System.Windows.Forms.ComboBox comboBoxSelectedTimetableLT;
        private System.Windows.Forms.Button buttonNextGeneratingTimtables;
        private System.Windows.Forms.Button buttonNextLinesTimetables;
        private System.Windows.Forms.Button buttonExitStationsTimetables;
        private System.Windows.Forms.GroupBox groupBoxSelectedStation;
        private System.Windows.Forms.ComboBox comboBoxSelectedStation;
        private System.Windows.Forms.GroupBox groupBoxSelectTimetableST;
        private System.Windows.Forms.ComboBox comboBoxSelectedTimetableST;
        private System.Windows.Forms.GroupBox groupBoxStationsDetails;
        private System.Windows.Forms.TextBox textBoxStationID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxStationName;
        private System.Windows.Forms.Label labelStationName;
        private System.Windows.Forms.TextBox textBoxStationInhabitation;
        private System.Windows.Forms.Label labelStationInhabitation;
        private System.Windows.Forms.TextBox textBoxStationCategory;
        private System.Windows.Forms.Label labelStationCategory;
        private System.Windows.Forms.GroupBox groupBoxLinesDetails;
        private System.Windows.Forms.TextBox textBoxLineNumber;
        private System.Windows.Forms.Label labelLineNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderTrainStation;
        private System.Windows.Forms.ColumnHeader columnHeaderOrder;
        private System.Windows.Forms.ColumnHeader columnHeaderKmFromStart;
        private System.Windows.Forms.ColumnHeader columnHeaderTime1;
        private System.Windows.Forms.ColumnHeader columnHeaderTime2;
        private System.Windows.Forms.ColumnHeader columnHeaderTime3;
        private System.Windows.Forms.ColumnHeader columnHeaderTime4;
        private System.Windows.Forms.ColumnHeader columnHeaderTime5;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.TextBox textBoxTypeOfTrain;
        private System.Windows.Forms.Label labelTypeOfTrain;
        private System.Windows.Forms.TextBox textBoxPeriod;
        private System.Windows.Forms.GroupBox groupBoxGeneration;
        private System.Windows.Forms.Button buttonAbortGeneration;
        private System.Windows.Forms.Button buttonStartGeneration;
        private System.Windows.Forms.Button buttonCompleteAndStop;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTG;
        private System.Windows.Forms.GroupBox groupBoxProgress;
        private System.Windows.Forms.ProgressBar progressBarGT;
        private ColHeader columnHeaderArrival;
        private ColHeader columnHeaderDeparture;
        private ColHeader columnHeaderLineNumber;
        private System.Windows.Forms.GroupBox groupBoxNumberOfTimetables;
        private System.Windows.Forms.NumericUpDown numericUpDownTimetables;
        private ColHeader columnHeaderAttempt;
        private ColHeader columnHeaderProgressiveChanges;
        private ColHeader columnHeaderRatingValue;
        private ColHeader columnHeaderNote;
        private ColHeader columnHeaderGenerationTime;
    }
}