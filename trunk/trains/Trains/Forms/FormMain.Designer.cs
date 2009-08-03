namespace PeriodicTimetableGeneration
{
    partial class FormMain
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
            this.splitContainerLoadFiles = new System.Windows.Forms.SplitContainer();
            this.listViewLoadFiles = new System.Windows.Forms.ListView();
            this.columnHeaderName = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderSize = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderFullPath = new System.Windows.Forms.ColumnHeader();
            this.imageListBig = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.buttonLoadFileNext = new System.Windows.Forms.Button();
            this.buttonRemoveFiles = new System.Windows.Forms.Button();
            this.buttonAddFiles = new System.Windows.Forms.Button();
            this.tabPageListOfLines = new System.Windows.Forms.TabPage();
            this.splitContainerListOfLines = new System.Windows.Forms.SplitContainer();
            this.listViewListOfLines = new System.Windows.Forms.ListView();
            this.columnHeaderNumber = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderType = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderPeriod = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderStart = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderDestination = new PeriodicTimetableGeneration.ColHeader();
            this.buttonConnectedLines = new System.Windows.Forms.Button();
            this.buttonListOfLinesNext = new System.Windows.Forms.Button();
            this.buttonDetailsLine = new System.Windows.Forms.Button();
            this.tabPageListOfStations = new System.Windows.Forms.TabPage();
            this.splitContainerListOfStations = new System.Windows.Forms.SplitContainer();
            this.listViewListOfStations = new System.Windows.Forms.ListView();
            this.columnHeaderIdStation = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderNameStation = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTownCategory = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderInhabitation = new PeriodicTimetableGeneration.ColHeader();
            this.ColumnHeaderTown = new System.Windows.Forms.ColumnHeader();
            this.buttonUpdateCategories = new System.Windows.Forms.Button();
            this.groupBoxSelectLine = new System.Windows.Forms.GroupBox();
            this.comboBoxSelectLine = new System.Windows.Forms.ComboBox();
            this.buttonListOfStationNext = new System.Windows.Forms.Button();
            this.buttonDetailsStation = new System.Windows.Forms.Button();
            this.tabPageListOfConncetions = new System.Windows.Forms.TabPage();
            this.splitContainerListOfConnections = new System.Windows.Forms.SplitContainer();
            this.listViewListOfConnections = new System.Windows.Forms.ListView();
            this.columnHeaderFrom = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTo = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTime = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderDistance = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderPassangers = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderPath = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderChangingStations = new PeriodicTimetableGeneration.ColHeader();
            this.buttonListOfConncetionsNext = new System.Windows.Forms.Button();
            this.buttonEditPath = new System.Windows.Forms.Button();
            this.buttonDetailsConnection = new System.Windows.Forms.Button();
            this.tabPageListOfRoutes = new System.Windows.Forms.TabPage();
            this.splitContainerListOfPaths = new System.Windows.Forms.SplitContainer();
            this.listViewFinalInput = new System.Windows.Forms.ListView();
            this.columnHeaderFIlistOfLines = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderFIchangingStations = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderFIpassengers = new PeriodicTimetableGeneration.ColHeader();
            this.buttonListOfGroupsOfConnectionsNext = new System.Windows.Forms.Button();
            this.tabPageListOfTransfers = new System.Windows.Forms.TabPage();
            this.splitContainerListOfTransfers = new System.Windows.Forms.SplitContainer();
            this.listViewListOfTransfers = new System.Windows.Forms.ListView();
            this.columnHeaderFromLine = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderToLine = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderAtStations = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderPassengersOnTransfer = new PeriodicTimetableGeneration.ColHeader();
            this.groupBoxGenerationAlgorithm = new System.Windows.Forms.GroupBox();
            this.buttonGenerationAlgorithmRandomized = new System.Windows.Forms.Button();
            this.buttonGenerationAlgorithmDSA = new System.Windows.Forms.Button();
            this.openFileDialogTrainLines = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogUpdateTownCategories = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogUpdateConnectedLines = new System.Windows.Forms.OpenFileDialog();
            this.labelWait = new System.Windows.Forms.Label();
            this.tabControlTG.SuspendLayout();
            this.tabPageLoadFiles.SuspendLayout();
            this.splitContainerLoadFiles.Panel1.SuspendLayout();
            this.splitContainerLoadFiles.Panel2.SuspendLayout();
            this.splitContainerLoadFiles.SuspendLayout();
            this.tabPageListOfLines.SuspendLayout();
            this.splitContainerListOfLines.Panel1.SuspendLayout();
            this.splitContainerListOfLines.Panel2.SuspendLayout();
            this.splitContainerListOfLines.SuspendLayout();
            this.tabPageListOfStations.SuspendLayout();
            this.splitContainerListOfStations.Panel1.SuspendLayout();
            this.splitContainerListOfStations.Panel2.SuspendLayout();
            this.splitContainerListOfStations.SuspendLayout();
            this.groupBoxSelectLine.SuspendLayout();
            this.tabPageListOfConncetions.SuspendLayout();
            this.splitContainerListOfConnections.Panel1.SuspendLayout();
            this.splitContainerListOfConnections.Panel2.SuspendLayout();
            this.splitContainerListOfConnections.SuspendLayout();
            this.tabPageListOfRoutes.SuspendLayout();
            this.splitContainerListOfPaths.Panel1.SuspendLayout();
            this.splitContainerListOfPaths.Panel2.SuspendLayout();
            this.splitContainerListOfPaths.SuspendLayout();
            this.tabPageListOfTransfers.SuspendLayout();
            this.splitContainerListOfTransfers.Panel1.SuspendLayout();
            this.splitContainerListOfTransfers.Panel2.SuspendLayout();
            this.splitContainerListOfTransfers.SuspendLayout();
            this.groupBoxGenerationAlgorithm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTG
            // 
            this.tabControlTG.Controls.Add(this.tabPageLoadFiles);
            this.tabControlTG.Controls.Add(this.tabPageListOfLines);
            this.tabControlTG.Controls.Add(this.tabPageListOfStations);
            this.tabControlTG.Controls.Add(this.tabPageListOfConncetions);
            this.tabControlTG.Controls.Add(this.tabPageListOfRoutes);
            this.tabControlTG.Controls.Add(this.tabPageListOfTransfers);
            this.tabControlTG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTG.Location = new System.Drawing.Point(0, 0);
            this.tabControlTG.Name = "tabControlTG";
            this.tabControlTG.SelectedIndex = 0;
            this.tabControlTG.Size = new System.Drawing.Size(984, 564);
            this.tabControlTG.TabIndex = 0;
            this.tabControlTG.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlTG_Selecting);
            // 
            // tabPageLoadFiles
            // 
            this.tabPageLoadFiles.Controls.Add(this.splitContainerLoadFiles);
            this.tabPageLoadFiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageLoadFiles.Name = "tabPageLoadFiles";
            this.tabPageLoadFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLoadFiles.Size = new System.Drawing.Size(976, 538);
            this.tabPageLoadFiles.TabIndex = 0;
            this.tabPageLoadFiles.Text = "Load Files";
            this.tabPageLoadFiles.UseVisualStyleBackColor = true;
            // 
            // splitContainerLoadFiles
            // 
            this.splitContainerLoadFiles.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerLoadFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLoadFiles.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerLoadFiles.IsSplitterFixed = true;
            this.splitContainerLoadFiles.Location = new System.Drawing.Point(3, 3);
            this.splitContainerLoadFiles.Name = "splitContainerLoadFiles";
            // 
            // splitContainerLoadFiles.Panel1
            // 
            this.splitContainerLoadFiles.Panel1.Controls.Add(this.listViewLoadFiles);
            // 
            // splitContainerLoadFiles.Panel2
            // 
            this.splitContainerLoadFiles.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerLoadFiles.Panel2.Controls.Add(this.buttonLoadFileNext);
            this.splitContainerLoadFiles.Panel2.Controls.Add(this.buttonRemoveFiles);
            this.splitContainerLoadFiles.Panel2.Controls.Add(this.buttonAddFiles);
            this.splitContainerLoadFiles.Size = new System.Drawing.Size(970, 532);
            this.splitContainerLoadFiles.SplitterDistance = 850;
            this.splitContainerLoadFiles.TabIndex = 0;
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
            this.listViewLoadFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewLoadFiles_ColumnClick);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 300;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.SortType = PeriodicTimetableGeneration.SortType.Integer;
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
            this.buttonLoadFileNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tabPageListOfLines.Controls.Add(this.splitContainerListOfLines);
            this.tabPageListOfLines.Location = new System.Drawing.Point(4, 22);
            this.tabPageListOfLines.Name = "tabPageListOfLines";
            this.tabPageListOfLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListOfLines.Size = new System.Drawing.Size(976, 538);
            this.tabPageListOfLines.TabIndex = 1;
            this.tabPageListOfLines.Text = "List of Lines";
            this.tabPageListOfLines.UseVisualStyleBackColor = true;
            // 
            // splitContainerListOfLines
            // 
            this.splitContainerListOfLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerListOfLines.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerListOfLines.IsSplitterFixed = true;
            this.splitContainerListOfLines.Location = new System.Drawing.Point(3, 3);
            this.splitContainerListOfLines.Name = "splitContainerListOfLines";
            // 
            // splitContainerListOfLines.Panel1
            // 
            this.splitContainerListOfLines.Panel1.Controls.Add(this.listViewListOfLines);
            // 
            // splitContainerListOfLines.Panel2
            // 
            this.splitContainerListOfLines.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerListOfLines.Panel2.Controls.Add(this.buttonConnectedLines);
            this.splitContainerListOfLines.Panel2.Controls.Add(this.buttonListOfLinesNext);
            this.splitContainerListOfLines.Panel2.Controls.Add(this.buttonDetailsLine);
            this.splitContainerListOfLines.Size = new System.Drawing.Size(970, 532);
            this.splitContainerListOfLines.SplitterDistance = 850;
            this.splitContainerListOfLines.TabIndex = 0;
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
            // buttonConnectedLines
            // 
            this.buttonConnectedLines.Location = new System.Drawing.Point(11, 65);
            this.buttonConnectedLines.Name = "buttonConnectedLines";
            this.buttonConnectedLines.Size = new System.Drawing.Size(100, 45);
            this.buttonConnectedLines.TabIndex = 3;
            this.buttonConnectedLines.Text = "Update Connected Lines";
            this.buttonConnectedLines.UseVisualStyleBackColor = true;
            this.buttonConnectedLines.Click += new System.EventHandler(this.buttonConnectedLines_Click);
            // 
            // buttonListOfLinesNext
            // 
            this.buttonListOfLinesNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            // tabPageListOfStations
            // 
            this.tabPageListOfStations.Controls.Add(this.splitContainerListOfStations);
            this.tabPageListOfStations.Location = new System.Drawing.Point(4, 22);
            this.tabPageListOfStations.Name = "tabPageListOfStations";
            this.tabPageListOfStations.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListOfStations.Size = new System.Drawing.Size(976, 538);
            this.tabPageListOfStations.TabIndex = 2;
            this.tabPageListOfStations.Text = "List of Stations";
            this.tabPageListOfStations.UseVisualStyleBackColor = true;
            // 
            // splitContainerListOfStations
            // 
            this.splitContainerListOfStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerListOfStations.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerListOfStations.IsSplitterFixed = true;
            this.splitContainerListOfStations.Location = new System.Drawing.Point(3, 3);
            this.splitContainerListOfStations.Name = "splitContainerListOfStations";
            // 
            // splitContainerListOfStations.Panel1
            // 
            this.splitContainerListOfStations.Panel1.Controls.Add(this.listViewListOfStations);
            // 
            // splitContainerListOfStations.Panel2
            // 
            this.splitContainerListOfStations.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerListOfStations.Panel2.Controls.Add(this.buttonUpdateCategories);
            this.splitContainerListOfStations.Panel2.Controls.Add(this.groupBoxSelectLine);
            this.splitContainerListOfStations.Panel2.Controls.Add(this.buttonListOfStationNext);
            this.splitContainerListOfStations.Panel2.Controls.Add(this.buttonDetailsStation);
            this.splitContainerListOfStations.Size = new System.Drawing.Size(970, 532);
            this.splitContainerListOfStations.SplitterDistance = 850;
            this.splitContainerListOfStations.TabIndex = 0;
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
            // ColumnHeaderTown
            // 
            this.ColumnHeaderTown.Text = "Town";
            this.ColumnHeaderTown.Width = 100;
            // 
            // buttonUpdateCategories
            // 
            this.buttonUpdateCategories.Location = new System.Drawing.Point(7, 120);
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
            this.groupBoxSelectLine.Location = new System.Drawing.Point(2, 27);
            this.groupBoxSelectLine.Name = "groupBoxSelectLine";
            this.groupBoxSelectLine.Size = new System.Drawing.Size(113, 51);
            this.groupBoxSelectLine.TabIndex = 5;
            this.groupBoxSelectLine.TabStop = false;
            this.groupBoxSelectLine.Text = "Select Line";
            // 
            // comboBoxSelectLine
            // 
            this.comboBoxSelectLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectLine.FormattingEnabled = true;
            this.comboBoxSelectLine.Location = new System.Drawing.Point(5, 19);
            this.comboBoxSelectLine.Name = "comboBoxSelectLine";
            this.comboBoxSelectLine.Size = new System.Drawing.Size(103, 21);
            this.comboBoxSelectLine.Sorted = true;
            this.comboBoxSelectLine.TabIndex = 4;
            this.comboBoxSelectLine.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectLine_SelectedIndexChanged);
            // 
            // buttonListOfStationNext
            // 
            this.buttonListOfStationNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonDetailsStation.Location = new System.Drawing.Point(7, 84);
            this.buttonDetailsStation.Name = "buttonDetailsStation";
            this.buttonDetailsStation.Size = new System.Drawing.Size(103, 30);
            this.buttonDetailsStation.TabIndex = 2;
            this.buttonDetailsStation.Text = "Details";
            this.buttonDetailsStation.UseVisualStyleBackColor = true;
            this.buttonDetailsStation.Click += new System.EventHandler(this.buttonDetailsStation_Click);
            // 
            // tabPageListOfConncetions
            // 
            this.tabPageListOfConncetions.Controls.Add(this.splitContainerListOfConnections);
            this.tabPageListOfConncetions.Location = new System.Drawing.Point(4, 22);
            this.tabPageListOfConncetions.Name = "tabPageListOfConncetions";
            this.tabPageListOfConncetions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListOfConncetions.Size = new System.Drawing.Size(976, 538);
            this.tabPageListOfConncetions.TabIndex = 3;
            this.tabPageListOfConncetions.Text = "List of Connections";
            this.tabPageListOfConncetions.UseVisualStyleBackColor = true;
            // 
            // splitContainerListOfConnections
            // 
            this.splitContainerListOfConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerListOfConnections.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerListOfConnections.IsSplitterFixed = true;
            this.splitContainerListOfConnections.Location = new System.Drawing.Point(3, 3);
            this.splitContainerListOfConnections.Name = "splitContainerListOfConnections";
            // 
            // splitContainerListOfConnections.Panel1
            // 
            this.splitContainerListOfConnections.Panel1.Controls.Add(this.listViewListOfConnections);
            // 
            // splitContainerListOfConnections.Panel2
            // 
            this.splitContainerListOfConnections.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerListOfConnections.Panel2.Controls.Add(this.buttonListOfConncetionsNext);
            this.splitContainerListOfConnections.Panel2.Controls.Add(this.buttonEditPath);
            this.splitContainerListOfConnections.Panel2.Controls.Add(this.buttonDetailsConnection);
            this.splitContainerListOfConnections.Size = new System.Drawing.Size(970, 532);
            this.splitContainerListOfConnections.SplitterDistance = 850;
            this.splitContainerListOfConnections.TabIndex = 0;
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
            // buttonListOfConncetionsNext
            // 
            this.buttonListOfConncetionsNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            // tabPageListOfRoutes
            // 
            this.tabPageListOfRoutes.Controls.Add(this.splitContainerListOfPaths);
            this.tabPageListOfRoutes.Location = new System.Drawing.Point(4, 22);
            this.tabPageListOfRoutes.Name = "tabPageListOfRoutes";
            this.tabPageListOfRoutes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListOfRoutes.Size = new System.Drawing.Size(976, 538);
            this.tabPageListOfRoutes.TabIndex = 4;
            this.tabPageListOfRoutes.Text = "List of Routes";
            this.tabPageListOfRoutes.UseVisualStyleBackColor = true;
            // 
            // splitContainerListOfPaths
            // 
            this.splitContainerListOfPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerListOfPaths.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerListOfPaths.IsSplitterFixed = true;
            this.splitContainerListOfPaths.Location = new System.Drawing.Point(3, 3);
            this.splitContainerListOfPaths.Name = "splitContainerListOfPaths";
            // 
            // splitContainerListOfPaths.Panel1
            // 
            this.splitContainerListOfPaths.Panel1.Controls.Add(this.listViewFinalInput);
            // 
            // splitContainerListOfPaths.Panel2
            // 
            this.splitContainerListOfPaths.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerListOfPaths.Panel2.Controls.Add(this.buttonListOfGroupsOfConnectionsNext);
            this.splitContainerListOfPaths.Size = new System.Drawing.Size(970, 532);
            this.splitContainerListOfPaths.SplitterDistance = 850;
            this.splitContainerListOfPaths.TabIndex = 0;
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
            // columnHeaderFIlistOfLines
            // 
            this.columnHeaderFIlistOfLines.Text = "Route (List of Lines)";
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
            // buttonListOfGroupsOfConnectionsNext
            // 
            this.buttonListOfGroupsOfConnectionsNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonListOfGroupsOfConnectionsNext.Location = new System.Drawing.Point(11, 497);
            this.buttonListOfGroupsOfConnectionsNext.Name = "buttonListOfGroupsOfConnectionsNext";
            this.buttonListOfGroupsOfConnectionsNext.Size = new System.Drawing.Size(100, 30);
            this.buttonListOfGroupsOfConnectionsNext.TabIndex = 6;
            this.buttonListOfGroupsOfConnectionsNext.Text = "Next";
            this.buttonListOfGroupsOfConnectionsNext.UseVisualStyleBackColor = true;
            this.buttonListOfGroupsOfConnectionsNext.Click += new System.EventHandler(this.buttonListOfGroupsOfConnectionsNext_Click);
            // 
            // tabPageListOfTransfers
            // 
            this.tabPageListOfTransfers.Controls.Add(this.splitContainerListOfTransfers);
            this.tabPageListOfTransfers.Location = new System.Drawing.Point(4, 22);
            this.tabPageListOfTransfers.Name = "tabPageListOfTransfers";
            this.tabPageListOfTransfers.Size = new System.Drawing.Size(976, 538);
            this.tabPageListOfTransfers.TabIndex = 5;
            this.tabPageListOfTransfers.Text = "List of Transfers";
            this.tabPageListOfTransfers.UseVisualStyleBackColor = true;
            // 
            // splitContainerListOfTransfers
            // 
            this.splitContainerListOfTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerListOfTransfers.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerListOfTransfers.IsSplitterFixed = true;
            this.splitContainerListOfTransfers.Location = new System.Drawing.Point(0, 0);
            this.splitContainerListOfTransfers.Name = "splitContainerListOfTransfers";
            // 
            // splitContainerListOfTransfers.Panel1
            // 
            this.splitContainerListOfTransfers.Panel1.Controls.Add(this.listViewListOfTransfers);
            // 
            // splitContainerListOfTransfers.Panel2
            // 
            this.splitContainerListOfTransfers.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerListOfTransfers.Panel2.Controls.Add(this.groupBoxGenerationAlgorithm);
            this.splitContainerListOfTransfers.Size = new System.Drawing.Size(976, 538);
            this.splitContainerListOfTransfers.SplitterDistance = 850;
            this.splitContainerListOfTransfers.TabIndex = 0;
            // 
            // listViewListOfTransfers
            // 
            this.listViewListOfTransfers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFromLine,
            this.columnHeaderToLine,
            this.columnHeaderAtStations,
            this.columnHeaderPassengersOnTransfer});
            this.listViewListOfTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewListOfTransfers.FullRowSelect = true;
            this.listViewListOfTransfers.GridLines = true;
            this.listViewListOfTransfers.Location = new System.Drawing.Point(0, 0);
            this.listViewListOfTransfers.Name = "listViewListOfTransfers";
            this.listViewListOfTransfers.Size = new System.Drawing.Size(850, 538);
            this.listViewListOfTransfers.TabIndex = 0;
            this.listViewListOfTransfers.UseCompatibleStateImageBehavior = false;
            this.listViewListOfTransfers.View = System.Windows.Forms.View.Details;
            this.listViewListOfTransfers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewListOfTransfers_ColumnClick);
            // 
            // columnHeaderFromLine
            // 
            this.columnHeaderFromLine.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderFromLine.Text = "From Line";
            this.columnHeaderFromLine.Width = 120;
            // 
            // columnHeaderToLine
            // 
            this.columnHeaderToLine.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderToLine.Text = "To Line";
            this.columnHeaderToLine.Width = 120;
            // 
            // columnHeaderAtStations
            // 
            this.columnHeaderAtStations.Text = "At Station";
            this.columnHeaderAtStations.Width = 250;
            // 
            // columnHeaderPassengersOnTransfer
            // 
            this.columnHeaderPassengersOnTransfer.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderPassengersOnTransfer.Text = "Passengers on Transfer";
            this.columnHeaderPassengersOnTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderPassengersOnTransfer.Width = 200;
            // 
            // groupBoxGenerationAlgorithm
            // 
            this.groupBoxGenerationAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGenerationAlgorithm.Controls.Add(this.buttonGenerationAlgorithmRandomized);
            this.groupBoxGenerationAlgorithm.Controls.Add(this.buttonGenerationAlgorithmDSA);
            this.groupBoxGenerationAlgorithm.Location = new System.Drawing.Point(6, 405);
            this.groupBoxGenerationAlgorithm.Name = "groupBoxGenerationAlgorithm";
            this.groupBoxGenerationAlgorithm.Size = new System.Drawing.Size(113, 125);
            this.groupBoxGenerationAlgorithm.TabIndex = 8;
            this.groupBoxGenerationAlgorithm.TabStop = false;
            this.groupBoxGenerationAlgorithm.Text = "Generation Algorithms";
            // 
            // buttonGenerationAlgorithmRandomized
            // 
            this.buttonGenerationAlgorithmRandomized.Location = new System.Drawing.Point(6, 33);
            this.buttonGenerationAlgorithmRandomized.Name = "buttonGenerationAlgorithmRandomized";
            this.buttonGenerationAlgorithmRandomized.Size = new System.Drawing.Size(100, 40);
            this.buttonGenerationAlgorithmRandomized.TabIndex = 5;
            this.buttonGenerationAlgorithmRandomized.Text = "Randomized";
            this.buttonGenerationAlgorithmRandomized.UseVisualStyleBackColor = true;
            this.buttonGenerationAlgorithmRandomized.Click += new System.EventHandler(this.buttonGenerateTimetablesRandomized_Click);
            // 
            // buttonGenerationAlgorithmDSA
            // 
            this.buttonGenerationAlgorithmDSA.Location = new System.Drawing.Point(6, 79);
            this.buttonGenerationAlgorithmDSA.Name = "buttonGenerationAlgorithmDSA";
            this.buttonGenerationAlgorithmDSA.Size = new System.Drawing.Size(100, 40);
            this.buttonGenerationAlgorithmDSA.TabIndex = 6;
            this.buttonGenerationAlgorithmDSA.Text = "Discrete Sets";
            this.buttonGenerationAlgorithmDSA.UseVisualStyleBackColor = true;
            this.buttonGenerationAlgorithmDSA.Click += new System.EventHandler(this.buttonGenerationAlgorithmDSA_Click);
            // 
            // openFileDialogTrainLines
            // 
            this.openFileDialogTrainLines.Filter = "Text files|*.txt|All filles|*.*";
            this.openFileDialogTrainLines.InitialDirectory = "Application.StartupPath";
            this.openFileDialogTrainLines.Multiselect = true;
            this.openFileDialogTrainLines.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogTrainLines_FileOk);
            // 
            // openFileDialogUpdateTownCategories
            // 
            this.openFileDialogUpdateTownCategories.FileName = "openFileDialogUpdateTownCategories";
            this.openFileDialogUpdateTownCategories.Filter = "Text files|*.txt|All filles|*.*";
            this.openFileDialogUpdateTownCategories.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogUpdateTownCategories_FileOk);
            // 
            // openFileDialogUpdateConnectedLines
            // 
            this.openFileDialogUpdateConnectedLines.FileName = "openFileDialogUpdateConnecterdLines";
            this.openFileDialogUpdateConnectedLines.Filter = "Text files|*.txt|All filles|*.*";
            this.openFileDialogUpdateConnectedLines.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogUpdateConnectedLines_FileOk);
            // 
            // labelWait
            // 
            this.labelWait.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWait.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWait.Location = new System.Drawing.Point(400, 225);
            this.labelWait.Name = "labelWait";
            this.labelWait.Size = new System.Drawing.Size(184, 114);
            this.labelWait.TabIndex = 2;
            this.labelWait.Text = "Please wait,\r\nprocessing data...";
            this.labelWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWait.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 564);
            this.Controls.Add(this.labelWait);
            this.Controls.Add(this.tabControlTG);
            this.Name = "FormMain";
            this.Text = "PTG :: Preparing Input";
            this.tabControlTG.ResumeLayout(false);
            this.tabPageLoadFiles.ResumeLayout(false);
            this.splitContainerLoadFiles.Panel1.ResumeLayout(false);
            this.splitContainerLoadFiles.Panel2.ResumeLayout(false);
            this.splitContainerLoadFiles.ResumeLayout(false);
            this.tabPageListOfLines.ResumeLayout(false);
            this.splitContainerListOfLines.Panel1.ResumeLayout(false);
            this.splitContainerListOfLines.Panel2.ResumeLayout(false);
            this.splitContainerListOfLines.ResumeLayout(false);
            this.tabPageListOfStations.ResumeLayout(false);
            this.splitContainerListOfStations.Panel1.ResumeLayout(false);
            this.splitContainerListOfStations.Panel2.ResumeLayout(false);
            this.splitContainerListOfStations.ResumeLayout(false);
            this.groupBoxSelectLine.ResumeLayout(false);
            this.tabPageListOfConncetions.ResumeLayout(false);
            this.splitContainerListOfConnections.Panel1.ResumeLayout(false);
            this.splitContainerListOfConnections.Panel2.ResumeLayout(false);
            this.splitContainerListOfConnections.ResumeLayout(false);
            this.tabPageListOfRoutes.ResumeLayout(false);
            this.splitContainerListOfPaths.Panel1.ResumeLayout(false);
            this.splitContainerListOfPaths.Panel2.ResumeLayout(false);
            this.splitContainerListOfPaths.ResumeLayout(false);
            this.tabPageListOfTransfers.ResumeLayout(false);
            this.splitContainerListOfTransfers.Panel1.ResumeLayout(false);
            this.splitContainerListOfTransfers.Panel2.ResumeLayout(false);
            this.splitContainerListOfTransfers.ResumeLayout(false);
            this.groupBoxGenerationAlgorithm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTG;
        private System.Windows.Forms.TabPage tabPageLoadFiles;
        private System.Windows.Forms.TabPage tabPageListOfLines;
        private System.Windows.Forms.TabPage tabPageListOfStations;
        private System.Windows.Forms.OpenFileDialog openFileDialogTrainLines;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.SplitContainer splitContainerListOfLines;
        private System.Windows.Forms.Button buttonDetailsLine;
        private System.Windows.Forms.Button buttonListOfLinesNext;
        private System.Windows.Forms.ListView listViewListOfLines;
        private System.Windows.Forms.SplitContainer splitContainerListOfStations;
        private System.Windows.Forms.Button buttonDetailsStation;
        private System.Windows.Forms.Button buttonListOfStationNext;
        private System.Windows.Forms.ListView listViewListOfStations;
        private System.Windows.Forms.SplitContainer splitContainerLoadFiles;
        private System.Windows.Forms.ListView listViewLoadFiles;
        private System.Windows.Forms.Button buttonLoadFileNext;
        private System.Windows.Forms.Button buttonRemoveFiles;
        private System.Windows.Forms.Button buttonAddFiles;
        private System.Windows.Forms.GroupBox groupBoxSelectLine;
        private System.Windows.Forms.ComboBox comboBoxSelectLine;
        private System.Windows.Forms.TabPage tabPageListOfConncetions;
        private System.Windows.Forms.SplitContainer splitContainerListOfConnections;
        private System.Windows.Forms.ListView listViewListOfConnections;
        private System.Windows.Forms.Button buttonEditPath;
        private System.Windows.Forms.Button buttonDetailsConnection;
        private System.Windows.Forms.Button buttonListOfConncetionsNext;
        private System.Windows.Forms.ColumnHeader columnHeaderFullPath;
        private System.Windows.Forms.Button buttonUpdateCategories;
        private System.Windows.Forms.OpenFileDialog openFileDialogUpdateTownCategories;
        private System.Windows.Forms.TabPage tabPageListOfRoutes;
        private System.Windows.Forms.SplitContainer splitContainerListOfPaths;
        private System.Windows.Forms.ListView listViewFinalInput;
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
        private System.Windows.Forms.Button buttonConnectedLines;
        private System.Windows.Forms.OpenFileDialog openFileDialogUpdateConnectedLines;
        private System.Windows.Forms.TabPage tabPageListOfTransfers;
        private System.Windows.Forms.SplitContainer splitContainerListOfTransfers;
        private System.Windows.Forms.ListView listViewListOfTransfers;
        private ColHeader columnHeaderFromLine;
        private ColHeader columnHeaderToLine;
        private ColHeader columnHeaderAtStations;
        private ColHeader columnHeaderPassengersOnTransfer;
        private System.Windows.Forms.GroupBox groupBoxGenerationAlgorithm;
        private System.Windows.Forms.Button buttonGenerationAlgorithmRandomized;
        private System.Windows.Forms.Button buttonGenerationAlgorithmDSA;
        private System.Windows.Forms.Button buttonListOfGroupsOfConnectionsNext;
        private ColHeader columnHeaderName;
        private ColHeader columnHeaderSize;
        private System.Windows.Forms.Label labelWait;
        
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

