namespace PeriodicTimetableGeneration
{
    partial class FormRPproject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param stationName="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.tabControlTG = new System.Windows.Forms.TabControl();
            this.tabPageLoadFiles = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewLoadFiles = new System.Windows.Forms.ListView();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderSize = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFullPath = new System.Windows.Forms.ColumnHeader();
            this.imageListBig = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.buttonLoadFileNext = new System.Windows.Forms.Button();
            this.buttonRemoveFiles = new System.Windows.Forms.Button();
            this.buttonAddFiles = new System.Windows.Forms.Button();
            this.tabPageListOfLines = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewListOfLines = new System.Windows.Forms.ListView();
            this.buttonListOfLinesNext = new System.Windows.Forms.Button();
            this.buttonDetailsLine = new System.Windows.Forms.Button();
            this.tabPageListOfStation = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listViewListOfStations = new System.Windows.Forms.ListView();
            this.ColumnHeaderTown = new System.Windows.Forms.ColumnHeader();
            this.buttonUpdateCategories = new System.Windows.Forms.Button();
            this.groupBoxSelectLine = new System.Windows.Forms.GroupBox();
            this.comboBoxSelectLine = new System.Windows.Forms.ComboBox();
            this.buttonListOfStationNext = new System.Windows.Forms.Button();
            this.buttonDetailsStation = new System.Windows.Forms.Button();
            this.tabPageListOfConncetions = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.listViewListOfConnections = new System.Windows.Forms.ListView();
            this.buttonListOfConncetionsNext = new System.Windows.Forms.Button();
            this.buttonEditPath = new System.Windows.Forms.Button();
            this.buttonDetailsConnection = new System.Windows.Forms.Button();
            this.tabPageFinalInput = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.listViewFinalInput = new System.Windows.Forms.ListView();
            this.buttonGenerationPESP = new System.Windows.Forms.Button();
            this.buttonGenerateTimetables = new System.Windows.Forms.Button();
            this.openFileDialogTrainLines = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogUpdateTownCategories = new System.Windows.Forms.OpenFileDialog();
            this.columnHeaderNumber = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderType = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderPeriod = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderStart = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderDestination = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderIdStation = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderNameStation = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTownCategory = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderInhabitation = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderFrom = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTo = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTime = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderDistance = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderPassangers = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderPath = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderChangingStations = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderFIlistOfLines = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderFIchangingStations = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderFIpassengers = new PeriodicTimetableGeneration.ColHeader();
            this.tabControlTG.SuspendLayout();
            this.tabPageLoadFiles.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPageListOfLines.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPageListOfStation.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBoxSelectLine.SuspendLayout();
            this.tabPageListOfConncetions.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tabPageFinalInput.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTG
            // 
            this.tabControlTG.Controls.Add(this.tabPageLoadFiles);
            this.tabControlTG.Controls.Add(this.tabPageListOfLines);
            this.tabControlTG.Controls.Add(this.tabPageListOfStation);
            this.tabControlTG.Controls.Add(this.tabPageListOfConncetions);
            this.tabControlTG.Controls.Add(this.tabPageFinalInput);
            this.tabControlTG.Location = new System.Drawing.Point(0, 0);
            this.tabControlTG.Name = "tabControlTG";
            this.tabControlTG.SelectedIndex = 0;
            this.tabControlTG.Size = new System.Drawing.Size(984, 564);
            this.tabControlTG.TabIndex = 0;
            // 
            // tabPageLoadFiles
            // 
            this.tabPageLoadFiles.Controls.Add(this.splitContainer1);
            this.tabPageLoadFiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageLoadFiles.Name = "tabPageLoadFiles";
            this.tabPageLoadFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLoadFiles.Size = new System.Drawing.Size(976, 538);
            this.tabPageLoadFiles.TabIndex = 0;
            this.tabPageLoadFiles.Text = "Load Files";
            this.tabPageLoadFiles.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewLoadFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.buttonLoadFileNext);
            this.splitContainer1.Panel2.Controls.Add(this.buttonRemoveFiles);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAddFiles);
            this.splitContainer1.Size = new System.Drawing.Size(970, 532);
            this.splitContainer1.SplitterDistance = 850;
            this.splitContainer1.TabIndex = 0;
            // 
            // listViewLoadFiles
            // 
            this.listViewLoadFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderSize,
            this.columnHeaderFullPath});
            this.listViewLoadFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLoadFiles.FullRowSelect = true;
            this.listViewLoadFiles.GridLines = true;
            this.listViewLoadFiles.LargeImageList = this.imageListBig;
            this.listViewLoadFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewLoadFiles.Name = "listViewLoadFiles";
            this.listViewLoadFiles.Size = new System.Drawing.Size(850, 532);
            this.listViewLoadFiles.SmallImageList = this.imageListSmall;
            this.listViewLoadFiles.TabIndex = 0;
            this.listViewLoadFiles.UseCompatibleStateImageBehavior = false;
            this.listViewLoadFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 300;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Size";
            this.columnHeaderSize.Width = 150;
            // 
            // columnHeaderFullPath
            // 
            this.columnHeaderFullPath.Text = "Full Path";
            this.columnHeaderFullPath.Width = 300;
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
            // buttonLoadFileNext
            // 
            this.buttonLoadFileNext.Location = new System.Drawing.Point(11, 497);
            this.buttonLoadFileNext.Name = "buttonLoadFileNext";
            this.buttonLoadFileNext.Size = new System.Drawing.Size(100, 30);
            this.buttonLoadFileNext.TabIndex = 2;
            this.buttonLoadFileNext.Text = "Next";
            this.buttonLoadFileNext.UseVisualStyleBackColor = true;
            this.buttonLoadFileNext.Click += new System.EventHandler(this.buttonLoadFileNext_Click);
            // 
            // buttonRemoveFiles
            // 
            this.buttonRemoveFiles.Location = new System.Drawing.Point(11, 65);
            this.buttonRemoveFiles.Name = "buttonRemoveFiles";
            this.buttonRemoveFiles.Size = new System.Drawing.Size(100, 30);
            this.buttonRemoveFiles.TabIndex = 1;
            this.buttonRemoveFiles.Text = "Remove Files";
            this.buttonRemoveFiles.UseVisualStyleBackColor = true;
            this.buttonRemoveFiles.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAddFiles
            // 
            this.buttonAddFiles.Location = new System.Drawing.Point(11, 29);
            this.buttonAddFiles.Name = "buttonAddFiles";
            this.buttonAddFiles.Size = new System.Drawing.Size(100, 30);
            this.buttonAddFiles.TabIndex = 0;
            this.buttonAddFiles.Text = "Add Files";
            this.buttonAddFiles.UseVisualStyleBackColor = true;
            this.buttonAddFiles.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // tabPageListOfLines
            // 
            this.tabPageListOfLines.Controls.Add(this.splitContainer2);
            this.tabPageListOfLines.Location = new System.Drawing.Point(4, 22);
            this.tabPageListOfLines.Name = "tabPageListOfLines";
            this.tabPageListOfLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListOfLines.Size = new System.Drawing.Size(976, 538);
            this.tabPageListOfLines.TabIndex = 1;
            this.tabPageListOfLines.Text = "List of Lines";
            this.tabPageListOfLines.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewListOfLines);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.buttonListOfLinesNext);
            this.splitContainer2.Panel2.Controls.Add(this.buttonDetailsLine);
            this.splitContainer2.Size = new System.Drawing.Size(970, 532);
            this.splitContainer2.SplitterDistance = 850;
            this.splitContainer2.TabIndex = 0;
            // 
            // listViewListOfLines
            // 
            this.listViewListOfLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumber,
            this.columnHeaderType,
            this.columnHeaderPeriod,
            this.columnHeaderStart,
            this.columnHeaderDestination});
            this.listViewListOfLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewListOfLines.FullRowSelect = true;
            this.listViewListOfLines.GridLines = true;
            this.listViewListOfLines.LargeImageList = this.imageListBig;
            this.listViewListOfLines.Location = new System.Drawing.Point(0, 0);
            this.listViewListOfLines.MultiSelect = false;
            this.listViewListOfLines.Name = "listViewListOfLines";
            this.listViewListOfLines.Size = new System.Drawing.Size(850, 532);
            this.listViewListOfLines.SmallImageList = this.imageListSmall;
            this.listViewListOfLines.TabIndex = 0;
            this.listViewListOfLines.UseCompatibleStateImageBehavior = false;
            this.listViewListOfLines.View = System.Windows.Forms.View.Details;
            this.listViewListOfLines.ItemActivate += new System.EventHandler(this.listViewListOfLines_ItemActivate);
            this.listViewListOfLines.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewListOfLines_ColumnClick);
            // 
            // buttonListOfLinesNext
            // 
            this.buttonListOfLinesNext.Location = new System.Drawing.Point(11, 497);
            this.buttonListOfLinesNext.Name = "buttonListOfLinesNext";
            this.buttonListOfLinesNext.Size = new System.Drawing.Size(100, 30);
            this.buttonListOfLinesNext.TabIndex = 2;
            this.buttonListOfLinesNext.Text = "Next";
            this.buttonListOfLinesNext.UseVisualStyleBackColor = true;
            this.buttonListOfLinesNext.Click += new System.EventHandler(this.buttonListOfLinesNext_Click);
            // 
            // buttonDetailsLine
            // 
            this.buttonDetailsLine.Location = new System.Drawing.Point(11, 29);
            this.buttonDetailsLine.Name = "buttonDetailsLine";
            this.buttonDetailsLine.Size = new System.Drawing.Size(100, 30);
            this.buttonDetailsLine.TabIndex = 1;
            this.buttonDetailsLine.Text = "Details";
            this.buttonDetailsLine.UseVisualStyleBackColor = true;
            this.buttonDetailsLine.Click += new System.EventHandler(this.buttonDetailsLine_Click);
            // 
            // tabPageListOfStation
            // 
            this.tabPageListOfStation.Controls.Add(this.splitContainer3);
            this.tabPageListOfStation.Location = new System.Drawing.Point(4, 22);
            this.tabPageListOfStation.Name = "tabPageListOfStation";
            this.tabPageListOfStation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListOfStation.Size = new System.Drawing.Size(976, 538);
            this.tabPageListOfStation.TabIndex = 2;
            this.tabPageListOfStation.Text = "List of Stations";
            this.tabPageListOfStation.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listViewListOfStations);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.buttonUpdateCategories);
            this.splitContainer3.Panel2.Controls.Add(this.groupBoxSelectLine);
            this.splitContainer3.Panel2.Controls.Add(this.buttonListOfStationNext);
            this.splitContainer3.Panel2.Controls.Add(this.buttonDetailsStation);
            this.splitContainer3.Size = new System.Drawing.Size(970, 532);
            this.splitContainer3.SplitterDistance = 850;
            this.splitContainer3.TabIndex = 0;
            // 
            // listViewListOfStations
            // 
            this.listViewListOfStations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIdStation,
            this.columnHeaderNameStation,
            this.columnHeaderTownCategory,
            this.columnHeaderInhabitation,
            this.ColumnHeaderTown});
            this.listViewListOfStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewListOfStations.FullRowSelect = true;
            this.listViewListOfStations.GridLines = true;
            this.listViewListOfStations.LargeImageList = this.imageListBig;
            this.listViewListOfStations.Location = new System.Drawing.Point(0, 0);
            this.listViewListOfStations.MultiSelect = false;
            this.listViewListOfStations.Name = "listViewListOfStations";
            this.listViewListOfStations.Size = new System.Drawing.Size(850, 532);
            this.listViewListOfStations.SmallImageList = this.imageListSmall;
            this.listViewListOfStations.TabIndex = 0;
            this.listViewListOfStations.UseCompatibleStateImageBehavior = false;
            this.listViewListOfStations.View = System.Windows.Forms.View.Details;
            this.listViewListOfStations.ItemActivate += new System.EventHandler(this.listViewListOfStations_ItemActivate);
            this.listViewListOfStations.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewListOfStations_ColumnClick);
            // 
            // ColumnHeaderTown
            // 
            this.ColumnHeaderTown.Text = "Town";
            this.ColumnHeaderTown.Width = 100;
            // 
            // buttonUpdateCategories
            // 
            this.buttonUpdateCategories.Location = new System.Drawing.Point(8, 107);
            this.buttonUpdateCategories.Name = "buttonUpdateCategories";
            this.buttonUpdateCategories.Size = new System.Drawing.Size(103, 30);
            this.buttonUpdateCategories.TabIndex = 6;
            this.buttonUpdateCategories.Text = "Update Categories";
            this.buttonUpdateCategories.UseVisualStyleBackColor = true;
            this.buttonUpdateCategories.Click += new System.EventHandler(this.buttonUpdateCategories_Click);
            // 
            // groupBoxSelectLine
            // 
            this.groupBoxSelectLine.Controls.Add(this.comboBoxSelectLine);
            this.groupBoxSelectLine.Location = new System.Drawing.Point(11, 24);
            this.groupBoxSelectLine.Name = "groupBoxSelectLine";
            this.groupBoxSelectLine.Size = new System.Drawing.Size(100, 41);
            this.groupBoxSelectLine.TabIndex = 5;
            this.groupBoxSelectLine.TabStop = false;
            this.groupBoxSelectLine.Text = "Select Line";
            // 
            // comboBoxSelectLine
            // 
            this.comboBoxSelectLine.FormattingEnabled = true;
            this.comboBoxSelectLine.Location = new System.Drawing.Point(0, 14);
            this.comboBoxSelectLine.Name = "comboBoxSelectLine";
            this.comboBoxSelectLine.Size = new System.Drawing.Size(100, 21);
            this.comboBoxSelectLine.Sorted = true;
            this.comboBoxSelectLine.TabIndex = 4;
            this.comboBoxSelectLine.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectLine_SelectedIndexChanged);
            // 
            // buttonListOfStationNext
            // 
            this.buttonListOfStationNext.Location = new System.Drawing.Point(11, 497);
            this.buttonListOfStationNext.Name = "buttonListOfStationNext";
            this.buttonListOfStationNext.Size = new System.Drawing.Size(100, 30);
            this.buttonListOfStationNext.TabIndex = 3;
            this.buttonListOfStationNext.Text = "Next";
            this.buttonListOfStationNext.UseVisualStyleBackColor = true;
            this.buttonListOfStationNext.Click += new System.EventHandler(this.buttonListOfStationNext_Click);
            // 
            // buttonDetailsStation
            // 
            this.buttonDetailsStation.Location = new System.Drawing.Point(8, 71);
            this.buttonDetailsStation.Name = "buttonDetailsStation";
            this.buttonDetailsStation.Size = new System.Drawing.Size(103, 30);
            this.buttonDetailsStation.TabIndex = 2;
            this.buttonDetailsStation.Text = "Details";
            this.buttonDetailsStation.UseVisualStyleBackColor = true;
            this.buttonDetailsStation.Click += new System.EventHandler(this.buttonDetailsStation_Click);
            // 
            // tabPageListOfConncetions
            // 
            this.tabPageListOfConncetions.Controls.Add(this.splitContainer4);
            this.tabPageListOfConncetions.Location = new System.Drawing.Point(4, 22);
            this.tabPageListOfConncetions.Name = "tabPageListOfConncetions";
            this.tabPageListOfConncetions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListOfConncetions.Size = new System.Drawing.Size(976, 538);
            this.tabPageListOfConncetions.TabIndex = 3;
            this.tabPageListOfConncetions.Text = "List of Connections";
            this.tabPageListOfConncetions.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.listViewListOfConnections);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel2.Controls.Add(this.buttonListOfConncetionsNext);
            this.splitContainer4.Panel2.Controls.Add(this.buttonEditPath);
            this.splitContainer4.Panel2.Controls.Add(this.buttonDetailsConnection);
            this.splitContainer4.Size = new System.Drawing.Size(970, 532);
            this.splitContainer4.SplitterDistance = 850;
            this.splitContainer4.TabIndex = 0;
            // 
            // listViewListOfConnections
            // 
            this.listViewListOfConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderTo,
            this.columnHeaderTime,
            this.columnHeaderDistance,
            this.columnHeaderPassangers,
            this.columnHeaderPath,
            this.columnHeaderChangingStations});
            this.listViewListOfConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewListOfConnections.FullRowSelect = true;
            this.listViewListOfConnections.GridLines = true;
            this.listViewListOfConnections.Location = new System.Drawing.Point(0, 0);
            this.listViewListOfConnections.MultiSelect = false;
            this.listViewListOfConnections.Name = "listViewListOfConnections";
            this.listViewListOfConnections.Size = new System.Drawing.Size(850, 532);
            this.listViewListOfConnections.TabIndex = 0;
            this.listViewListOfConnections.UseCompatibleStateImageBehavior = false;
            this.listViewListOfConnections.View = System.Windows.Forms.View.Details;
            this.listViewListOfConnections.ItemActivate += new System.EventHandler(this.listViewListOfConnections_ItemActivate);
            this.listViewListOfConnections.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewListOfConnections_ColumnClick);
            // 
            // buttonListOfConncetionsNext
            // 
            this.buttonListOfConncetionsNext.Location = new System.Drawing.Point(11, 497);
            this.buttonListOfConncetionsNext.Name = "buttonListOfConncetionsNext";
            this.buttonListOfConncetionsNext.Size = new System.Drawing.Size(100, 30);
            this.buttonListOfConncetionsNext.TabIndex = 5;
            this.buttonListOfConncetionsNext.Text = "Next";
            this.buttonListOfConncetionsNext.UseVisualStyleBackColor = true;
            this.buttonListOfConncetionsNext.Click += new System.EventHandler(this.buttonListOfConncetionsNext_Click);
            // 
            // buttonEditPath
            // 
            this.buttonEditPath.Location = new System.Drawing.Point(11, 65);
            this.buttonEditPath.Name = "buttonEditPath";
            this.buttonEditPath.Size = new System.Drawing.Size(100, 30);
            this.buttonEditPath.TabIndex = 4;
            this.buttonEditPath.Text = "Edit Path";
            this.buttonEditPath.UseVisualStyleBackColor = true;
            this.buttonEditPath.Click += new System.EventHandler(this.buttonEditPath_Click);
            // 
            // buttonDetailsConnection
            // 
            this.buttonDetailsConnection.Location = new System.Drawing.Point(11, 29);
            this.buttonDetailsConnection.Name = "buttonDetailsConnection";
            this.buttonDetailsConnection.Size = new System.Drawing.Size(100, 30);
            this.buttonDetailsConnection.TabIndex = 3;
            this.buttonDetailsConnection.Text = "Details";
            this.buttonDetailsConnection.UseVisualStyleBackColor = true;
            this.buttonDetailsConnection.Click += new System.EventHandler(this.buttonDetailsConnection_Click);
            // 
            // tabPageFinalInput
            // 
            this.tabPageFinalInput.Controls.Add(this.splitContainer5);
            this.tabPageFinalInput.Location = new System.Drawing.Point(4, 22);
            this.tabPageFinalInput.Name = "tabPageFinalInput";
            this.tabPageFinalInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFinalInput.Size = new System.Drawing.Size(976, 538);
            this.tabPageFinalInput.TabIndex = 4;
            this.tabPageFinalInput.Text = "Final Input";
            this.tabPageFinalInput.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(3, 3);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.listViewFinalInput);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer5.Panel2.Controls.Add(this.buttonGenerationPESP);
            this.splitContainer5.Panel2.Controls.Add(this.buttonGenerateTimetables);
            this.splitContainer5.Size = new System.Drawing.Size(970, 532);
            this.splitContainer5.SplitterDistance = 850;
            this.splitContainer5.TabIndex = 0;
            // 
            // listViewFinalInput
            // 
            this.listViewFinalInput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFIlistOfLines,
            this.columnHeaderFIchangingStations,
            this.columnHeaderFIpassengers});
            this.listViewFinalInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFinalInput.FullRowSelect = true;
            this.listViewFinalInput.GridLines = true;
            this.listViewFinalInput.LargeImageList = this.imageListBig;
            this.listViewFinalInput.Location = new System.Drawing.Point(0, 0);
            this.listViewFinalInput.MultiSelect = false;
            this.listViewFinalInput.Name = "listViewFinalInput";
            this.listViewFinalInput.Size = new System.Drawing.Size(850, 532);
            this.listViewFinalInput.SmallImageList = this.imageListSmall;
            this.listViewFinalInput.TabIndex = 0;
            this.listViewFinalInput.UseCompatibleStateImageBehavior = false;
            this.listViewFinalInput.View = System.Windows.Forms.View.Details;
            this.listViewFinalInput.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewFinalInput_ColumnClick);
            // 
            // buttonGenerationPESP
            // 
            this.buttonGenerationPESP.Location = new System.Drawing.Point(11, 416);
            this.buttonGenerationPESP.Name = "buttonGenerationPESP";
            this.buttonGenerationPESP.Size = new System.Drawing.Size(100, 49);
            this.buttonGenerationPESP.TabIndex = 6;
            this.buttonGenerationPESP.Text = "Generate PESP";
            this.buttonGenerationPESP.UseVisualStyleBackColor = true;
            this.buttonGenerationPESP.Click += new System.EventHandler(this.buttonGenerationPESP_Click);
            // 
            // buttonGenerateTimetables
            // 
            this.buttonGenerateTimetables.Location = new System.Drawing.Point(11, 487);
            this.buttonGenerateTimetables.Name = "buttonGenerateTimetables";
            this.buttonGenerateTimetables.Size = new System.Drawing.Size(100, 40);
            this.buttonGenerateTimetables.TabIndex = 5;
            this.buttonGenerateTimetables.Text = "Generate Timetables";
            this.buttonGenerateTimetables.UseVisualStyleBackColor = true;
            this.buttonGenerateTimetables.Click += new System.EventHandler(this.buttonGenerateTimetables_Click);
            // 
            // openFileDialogTrainLines
            // 
            this.openFileDialogTrainLines.Filter = "Text files|*.txt|All filles|*.*";
            this.openFileDialogTrainLines.InitialDirectory = "Application.StartupPath";
            this.openFileDialogTrainLines.Multiselect = true;
            this.openFileDialogTrainLines.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileDialogUpdateTownCategories
            // 
            this.openFileDialogUpdateTownCategories.FileName = "openFileDialogUpdateTownCategories";
            this.openFileDialogUpdateTownCategories.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogUpdateTownCategories_FileOk);
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderNumber.Text = "Line Number";
            this.columnHeaderNumber.Width = 80;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type of Train";
            this.columnHeaderType.Width = 80;
            // 
            // columnHeaderPeriod
            // 
            this.columnHeaderPeriod.Text = "Period";
            this.columnHeaderPeriod.Width = 80;
            // 
            // columnHeaderStart
            // 
            this.columnHeaderStart.Text = "From";
            this.columnHeaderStart.Width = 200;
            // 
            // columnHeaderDestination
            // 
            this.columnHeaderDestination.Text = "To";
            this.columnHeaderDestination.Width = 200;
            // 
            // columnHeaderIdStation
            // 
            this.columnHeaderIdStation.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderIdStation.Text = "Id";
            this.columnHeaderIdStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderIdStation.Width = 80;
            // 
            // columnHeaderNameStation
            // 
            this.columnHeaderNameStation.Text = "Name of Station";
            this.columnHeaderNameStation.Width = 220;
            // 
            // columnHeaderTownCategory
            // 
            this.columnHeaderTownCategory.Text = "Category";
            this.columnHeaderTownCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTownCategory.Width = 80;
            // 
            // columnHeaderInhabitation
            // 
            this.columnHeaderInhabitation.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderInhabitation.Text = "Inhabitation";
            this.columnHeaderInhabitation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderInhabitation.Width = 150;
            // 
            // columnHeaderFrom
            // 
            this.columnHeaderFrom.Text = "From";
            this.columnHeaderFrom.Width = 150;
            // 
            // columnHeaderTo
            // 
            this.columnHeaderTo.Text = "To";
            this.columnHeaderTo.Width = 150;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTime.Width = 80;
            // 
            // columnHeaderDistance
            // 
            this.columnHeaderDistance.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderDistance.Text = "Distance";
            this.columnHeaderDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderDistance.Width = 80;
            // 
            // columnHeaderPassangers
            // 
            this.columnHeaderPassangers.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderPassangers.Text = "Passangers";
            this.columnHeaderPassangers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderPassangers.Width = 80;
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "Path";
            this.columnHeaderPath.Width = 150;
            // 
            // columnHeaderChangingStations
            // 
            this.columnHeaderChangingStations.Text = "Changing Stations";
            this.columnHeaderChangingStations.Width = 150;
            // 
            // columnHeaderFIlistOfLines
            // 
            this.columnHeaderFIlistOfLines.Text = "Path (List of Lines)";
            this.columnHeaderFIlistOfLines.Width = 300;
            // 
            // columnHeaderFIchangingStations
            // 
            this.columnHeaderFIchangingStations.Text = "Changing Stations";
            this.columnHeaderFIchangingStations.Width = 400;
            // 
            // columnHeaderFIpassengers
            // 
            this.columnHeaderFIpassengers.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderFIpassengers.Text = "Passengers";
            this.columnHeaderFIpassengers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderFIpassengers.Width = 100;
            // 
            // FormRPproject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 564);
            this.Controls.Add(this.tabControlTG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormRPproject";
            this.Text = "Generating Timetables :: Preparation of Input";
            this.tabControlTG.ResumeLayout(false);
            this.tabPageLoadFiles.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabPageListOfLines.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabPageListOfStation.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBoxSelectLine.ResumeLayout(false);
            this.tabPageListOfConncetions.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.tabPageFinalInput.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTG;
        private System.Windows.Forms.TabPage tabPageLoadFiles;
        private System.Windows.Forms.TabPage tabPageListOfLines;
        private System.Windows.Forms.TabPage tabPageListOfStation;
        private System.Windows.Forms.OpenFileDialog openFileDialogTrainLines;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonDetailsLine;
        private System.Windows.Forms.Button buttonListOfLinesNext;
        private System.Windows.Forms.ListView listViewListOfLines;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button buttonDetailsStation;
        private System.Windows.Forms.Button buttonListOfStationNext;
        private System.Windows.Forms.ListView listViewListOfStations;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewLoadFiles;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.Button buttonLoadFileNext;
        private System.Windows.Forms.Button buttonRemoveFiles;
        private System.Windows.Forms.Button buttonAddFiles;
        private System.Windows.Forms.GroupBox groupBoxSelectLine;
        private System.Windows.Forms.ComboBox comboBoxSelectLine;
        private System.Windows.Forms.TabPage tabPageListOfConncetions;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListView listViewListOfConnections;
        private System.Windows.Forms.Button buttonEditPath;
        private System.Windows.Forms.Button buttonDetailsConnection;
        private System.Windows.Forms.Button buttonListOfConncetionsNext;
        private System.Windows.Forms.ColumnHeader columnHeaderFullPath;
        private System.Windows.Forms.Button buttonUpdateCategories;
        private System.Windows.Forms.OpenFileDialog openFileDialogUpdateTownCategories;
        private System.Windows.Forms.TabPage tabPageFinalInput;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ListView listViewFinalInput;
        private System.Windows.Forms.Button buttonGenerateTimetables;
        private System.Windows.Forms.ColumnHeader ColumnHeaderTown;
        private ColHeader columnHeaderNumber;
        private ColHeader columnHeaderType;
        private ColHeader columnHeaderPeriod;
        private ColHeader columnHeaderStart;
        private ColHeader columnHeaderDestination;
        private ColHeader columnHeaderFIlistOfLines;
        private ColHeader columnHeaderFIchangingStations;
        private ColHeader columnHeaderFIpassengers;
        private ColHeader columnHeaderIdStation;
        private ColHeader columnHeaderNameStation;
        private ColHeader columnHeaderTownCategory;
        private ColHeader columnHeaderInhabitation;
        private ColHeader columnHeaderFrom;
        private ColHeader columnHeaderTo;
        private ColHeader columnHeaderPassangers;
        private ColHeader columnHeaderPath;
        private ColHeader columnHeaderChangingStations;
        private ColHeader columnHeaderTime;
        private ColHeader columnHeaderDistance;
        private System.Windows.Forms.Button buttonGenerationPESP;
        
/*      
        private ColHeader columnHeaderIdStation;
        private ColHeader columnHeaderNameStation;
        private ColHeader columnHeaderTownCategory;
        private ColHeader columnHeaderInhabitation;
        private ColHeader columnHeaderFrom;
        private ColHeader columnHeaderTo;
        private ColHeader columnHeaderPassangers;
        private ColHeader columnHeaderPath;
        private ColHeader columnHeaderChangingStations;
        private ColHeader columnHeaderTime;
        private ColHeader columnHeaderDistance;
        */
    }
}

