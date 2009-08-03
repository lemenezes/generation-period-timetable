namespace PeriodicTimetableGeneration
{
    partial class FormDetailsOfLine
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
            this.buttonBackDetailsOfLine = new System.Windows.Forms.Button();
            this.buttonSaveDetailsOfLine = new System.Windows.Forms.Button();
            this.groupBoxLineInformation = new System.Windows.Forms.GroupBox();
            this.labelProvider = new System.Windows.Forms.Label();
            this.textBoxProvider = new System.Windows.Forms.TextBox();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.comboBoxTypeOfTrain = new System.Windows.Forms.ComboBox();
            this.labelTypeOfTrain = new System.Windows.Forms.Label();
            this.labelLineNumber = new System.Windows.Forms.Label();
            this.textBoxLineNumber = new System.Windows.Forms.TextBox();
            this.groupBoxListOfStops = new System.Windows.Forms.GroupBox();
            this.listViewListOfStops = new System.Windows.Forms.ListView();
            this.columnHeaderNameStation = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderOrder = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTimeFromStart = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderKmFromStart = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTimeOfStaying = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTimeDifference = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderKmDifference = new System.Windows.Forms.ColumnHeader();
            this.imageListBig = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxConnectedLines = new System.Windows.Forms.GroupBox();
            this.buttonRemoveConnectedLines = new System.Windows.Forms.Button();
            this.listViewListOfConnectedLines = new System.Windows.Forms.ListView();
            this.columnHeaderLine = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTypeOfTrain = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPeriod = new System.Windows.Forms.ColumnHeader();
            this.buttonAddConnectedLines = new System.Windows.Forms.Button();
            this.groupBoxLineInformation.SuspendLayout();
            this.groupBoxListOfStops.SuspendLayout();
            this.groupBoxConnectedLines.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBackDetailsOfLine
            // 
            this.buttonBackDetailsOfLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBackDetailsOfLine.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBackDetailsOfLine.Location = new System.Drawing.Point(15, 522);
            this.buttonBackDetailsOfLine.Name = "buttonBackDetailsOfLine";
            this.buttonBackDetailsOfLine.Size = new System.Drawing.Size(100, 30);
            this.buttonBackDetailsOfLine.TabIndex = 0;
            this.buttonBackDetailsOfLine.Text = "Back";
            this.buttonBackDetailsOfLine.UseVisualStyleBackColor = true;
            this.buttonBackDetailsOfLine.Click += new System.EventHandler(this.buttonBackDetailsOfLine_Click);
            // 
            // buttonSaveDetailsOfLine
            // 
            this.buttonSaveDetailsOfLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveDetailsOfLine.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSaveDetailsOfLine.Location = new System.Drawing.Point(872, 522);
            this.buttonSaveDetailsOfLine.Name = "buttonSaveDetailsOfLine";
            this.buttonSaveDetailsOfLine.Size = new System.Drawing.Size(100, 30);
            this.buttonSaveDetailsOfLine.TabIndex = 1;
            this.buttonSaveDetailsOfLine.Text = " Save";
            this.buttonSaveDetailsOfLine.UseVisualStyleBackColor = true;
            this.buttonSaveDetailsOfLine.Click += new System.EventHandler(this.buttonSaveDetailsOfLine_Click);
            // 
            // groupBoxLineInformation
            // 
            this.groupBoxLineInformation.Controls.Add(this.labelProvider);
            this.groupBoxLineInformation.Controls.Add(this.textBoxProvider);
            this.groupBoxLineInformation.Controls.Add(this.comboBoxDirection);
            this.groupBoxLineInformation.Controls.Add(this.label2);
            this.groupBoxLineInformation.Controls.Add(this.comboBoxPeriod);
            this.groupBoxLineInformation.Controls.Add(this.labelPeriod);
            this.groupBoxLineInformation.Controls.Add(this.comboBoxTypeOfTrain);
            this.groupBoxLineInformation.Controls.Add(this.labelTypeOfTrain);
            this.groupBoxLineInformation.Controls.Add(this.labelLineNumber);
            this.groupBoxLineInformation.Controls.Add(this.textBoxLineNumber);
            this.groupBoxLineInformation.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLineInformation.Name = "groupBoxLineInformation";
            this.groupBoxLineInformation.Size = new System.Drawing.Size(256, 155);
            this.groupBoxLineInformation.TabIndex = 2;
            this.groupBoxLineInformation.TabStop = false;
            this.groupBoxLineInformation.Text = "Line\'s Information";
            // 
            // labelProvider
            // 
            this.labelProvider.AutoSize = true;
            this.labelProvider.Location = new System.Drawing.Point(6, 132);
            this.labelProvider.Name = "labelProvider";
            this.labelProvider.Size = new System.Drawing.Size(46, 13);
            this.labelProvider.TabIndex = 10;
            this.labelProvider.Text = "Provider";
            // 
            // textBoxProvider
            // 
            this.textBoxProvider.Location = new System.Drawing.Point(95, 129);
            this.textBoxProvider.Name = "textBoxProvider";
            this.textBoxProvider.Size = new System.Drawing.Size(155, 20);
            this.textBoxProvider.TabIndex = 9;
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Location = new System.Drawing.Point(95, 102);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(155, 21);
            this.comboBoxDirection.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Direction";
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboBoxPeriod.Location = new System.Drawing.Point(95, 72);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(155, 21);
            this.comboBoxPeriod.TabIndex = 6;
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Location = new System.Drawing.Point(6, 75);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(37, 13);
            this.labelPeriod.TabIndex = 5;
            this.labelPeriod.Text = "Period";
            // 
            // comboBoxTypeOfTrain
            // 
            this.comboBoxTypeOfTrain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeOfTrain.FormattingEnabled = true;
            this.comboBoxTypeOfTrain.Location = new System.Drawing.Point(95, 45);
            this.comboBoxTypeOfTrain.Name = "comboBoxTypeOfTrain";
            this.comboBoxTypeOfTrain.Size = new System.Drawing.Size(155, 21);
            this.comboBoxTypeOfTrain.TabIndex = 4;
            // 
            // labelTypeOfTrain
            // 
            this.labelTypeOfTrain.AutoSize = true;
            this.labelTypeOfTrain.Location = new System.Drawing.Point(6, 48);
            this.labelTypeOfTrain.Name = "labelTypeOfTrain";
            this.labelTypeOfTrain.Size = new System.Drawing.Size(70, 13);
            this.labelTypeOfTrain.TabIndex = 3;
            this.labelTypeOfTrain.Text = "Type of Train";
            // 
            // labelLineNumber
            // 
            this.labelLineNumber.AutoSize = true;
            this.labelLineNumber.Location = new System.Drawing.Point(6, 22);
            this.labelLineNumber.Name = "labelLineNumber";
            this.labelLineNumber.Size = new System.Drawing.Size(74, 13);
            this.labelLineNumber.TabIndex = 1;
            this.labelLineNumber.Text = "Line\'s Number";
            // 
            // textBoxLineNumber
            // 
            this.textBoxLineNumber.Enabled = false;
            this.textBoxLineNumber.Location = new System.Drawing.Point(95, 19);
            this.textBoxLineNumber.Name = "textBoxLineNumber";
            this.textBoxLineNumber.Size = new System.Drawing.Size(155, 20);
            this.textBoxLineNumber.TabIndex = 0;
            // 
            // groupBoxListOfStops
            // 
            this.groupBoxListOfStops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxListOfStops.Controls.Add(this.listViewListOfStops);
            this.groupBoxListOfStops.Location = new System.Drawing.Point(274, 13);
            this.groupBoxListOfStops.Name = "groupBoxListOfStops";
            this.groupBoxListOfStops.Size = new System.Drawing.Size(698, 503);
            this.groupBoxListOfStops.TabIndex = 4;
            this.groupBoxListOfStops.TabStop = false;
            this.groupBoxListOfStops.Text = "List of Stops";
            // 
            // listViewListOfStops
            // 
            this.listViewListOfStops.AllowColumnReorder = true;
            this.listViewListOfStops.AllowDrop = true;
            this.listViewListOfStops.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNameStation,
            this.columnHeaderOrder,
            this.columnHeaderTimeFromStart,
            this.columnHeaderKmFromStart,
            this.columnHeaderTimeOfStaying,
            this.columnHeaderTimeDifference,
            this.columnHeaderKmDifference});
            this.listViewListOfStops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewListOfStops.FullRowSelect = true;
            this.listViewListOfStops.GridLines = true;
            this.listViewListOfStops.LabelEdit = true;
            this.listViewListOfStops.LargeImageList = this.imageListBig;
            this.listViewListOfStops.Location = new System.Drawing.Point(3, 16);
            this.listViewListOfStops.MultiSelect = false;
            this.listViewListOfStops.Name = "listViewListOfStops";
            this.listViewListOfStops.Size = new System.Drawing.Size(692, 484);
            this.listViewListOfStops.SmallImageList = this.imageListSmall;
            this.listViewListOfStops.TabIndex = 0;
            this.listViewListOfStops.UseCompatibleStateImageBehavior = false;
            this.listViewListOfStops.View = System.Windows.Forms.View.Details;
            this.listViewListOfStops.SelectedIndexChanged += new System.EventHandler(this.listViewListOfStops_SelectedIndexChanged);
            this.listViewListOfStops.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewListOfStops_ItemSelectionChanged);
            // 
            // columnHeaderNameStation
            // 
            this.columnHeaderNameStation.Text = "Train Station";
            this.columnHeaderNameStation.Width = 150;
            // 
            // columnHeaderOrder
            // 
            this.columnHeaderOrder.Text = "Order";
            this.columnHeaderOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderOrder.Width = 40;
            // 
            // columnHeaderTimeFromStart
            // 
            this.columnHeaderTimeFromStart.Text = "Time From Start";
            this.columnHeaderTimeFromStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTimeFromStart.Width = 90;
            // 
            // columnHeaderKmFromStart
            // 
            this.columnHeaderKmFromStart.Text = "Km From Start";
            this.columnHeaderKmFromStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderKmFromStart.Width = 80;
            // 
            // columnHeaderTimeOfStaying
            // 
            this.columnHeaderTimeOfStaying.Text = "Time of Staying";
            this.columnHeaderTimeOfStaying.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTimeOfStaying.Width = 90;
            // 
            // columnHeaderTimeDifference
            // 
            this.columnHeaderTimeDifference.Text = "Time Difference";
            this.columnHeaderTimeDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTimeDifference.Width = 90;
            // 
            // columnHeaderKmDifference
            // 
            this.columnHeaderKmDifference.Text = "Km Difference";
            this.columnHeaderKmDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderKmDifference.Width = 80;
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
            // groupBoxConnectedLines
            // 
            this.groupBoxConnectedLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxConnectedLines.Controls.Add(this.buttonRemoveConnectedLines);
            this.groupBoxConnectedLines.Controls.Add(this.listViewListOfConnectedLines);
            this.groupBoxConnectedLines.Controls.Add(this.buttonAddConnectedLines);
            this.groupBoxConnectedLines.Location = new System.Drawing.Point(12, 173);
            this.groupBoxConnectedLines.Name = "groupBoxConnectedLines";
            this.groupBoxConnectedLines.Size = new System.Drawing.Size(256, 343);
            this.groupBoxConnectedLines.TabIndex = 6;
            this.groupBoxConnectedLines.TabStop = false;
            this.groupBoxConnectedLines.Text = "Connected Lines";
            // 
            // buttonRemoveConnectedLines
            // 
            this.buttonRemoveConnectedLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveConnectedLines.Location = new System.Drawing.Point(150, 304);
            this.buttonRemoveConnectedLines.Name = "buttonRemoveConnectedLines";
            this.buttonRemoveConnectedLines.Size = new System.Drawing.Size(100, 30);
            this.buttonRemoveConnectedLines.TabIndex = 9;
            this.buttonRemoveConnectedLines.Text = "Remove Lines";
            this.buttonRemoveConnectedLines.UseVisualStyleBackColor = true;
            this.buttonRemoveConnectedLines.Click += new System.EventHandler(this.buttonRemoveConnectedLine_Click);
            // 
            // listViewListOfConnectedLines
            // 
            this.listViewListOfConnectedLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewListOfConnectedLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine,
            this.columnHeaderTypeOfTrain,
            this.columnHeaderPeriod});
            this.listViewListOfConnectedLines.FullRowSelect = true;
            this.listViewListOfConnectedLines.GridLines = true;
            this.listViewListOfConnectedLines.LargeImageList = this.imageListSmall;
            this.listViewListOfConnectedLines.Location = new System.Drawing.Point(3, 17);
            this.listViewListOfConnectedLines.MultiSelect = false;
            this.listViewListOfConnectedLines.Name = "listViewListOfConnectedLines";
            this.listViewListOfConnectedLines.Size = new System.Drawing.Size(249, 281);
            this.listViewListOfConnectedLines.SmallImageList = this.imageListSmall;
            this.listViewListOfConnectedLines.TabIndex = 8;
            this.listViewListOfConnectedLines.UseCompatibleStateImageBehavior = false;
            this.listViewListOfConnectedLines.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLine
            // 
            this.columnHeaderLine.Text = "Number";
            this.columnHeaderLine.Width = 80;
            // 
            // columnHeaderTypeOfTrain
            // 
            this.columnHeaderTypeOfTrain.Text = "Type";
            this.columnHeaderTypeOfTrain.Width = 80;
            // 
            // columnHeaderPeriod
            // 
            this.columnHeaderPeriod.Text = "Period";
            this.columnHeaderPeriod.Width = 80;
            // 
            // buttonAddConnectedLines
            // 
            this.buttonAddConnectedLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddConnectedLines.Location = new System.Drawing.Point(44, 304);
            this.buttonAddConnectedLines.Name = "buttonAddConnectedLines";
            this.buttonAddConnectedLines.Size = new System.Drawing.Size(100, 30);
            this.buttonAddConnectedLines.TabIndex = 7;
            this.buttonAddConnectedLines.Text = "Add Lines";
            this.buttonAddConnectedLines.UseVisualStyleBackColor = true;
            this.buttonAddConnectedLines.Click += new System.EventHandler(this.buttonAddConnectedLine_Click);
            // 
            // FormDetailsOfLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 564);
            this.Controls.Add(this.groupBoxConnectedLines);
            this.Controls.Add(this.groupBoxListOfStops);
            this.Controls.Add(this.groupBoxLineInformation);
            this.Controls.Add(this.buttonSaveDetailsOfLine);
            this.Controls.Add(this.buttonBackDetailsOfLine);
            this.Name = "FormDetailsOfLine";
            this.Text = "Details of Line";
            this.Load += new System.EventHandler(this.FormDetailsOfLine_Load);
            this.Shown += new System.EventHandler(this.FormDetailsOfLine_Shown);
            this.groupBoxLineInformation.ResumeLayout(false);
            this.groupBoxLineInformation.PerformLayout();
            this.groupBoxListOfStops.ResumeLayout(false);
            this.groupBoxConnectedLines.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBackDetailsOfLine;
        private System.Windows.Forms.Button buttonSaveDetailsOfLine;
        private System.Windows.Forms.GroupBox groupBoxLineInformation;
        private System.Windows.Forms.Label labelLineNumber;
        private System.Windows.Forms.TextBox textBoxLineNumber;
        private System.Windows.Forms.Label labelTypeOfTrain;
        private System.Windows.Forms.ComboBox comboBoxTypeOfTrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPeriod;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.Label labelProvider;
        private System.Windows.Forms.TextBox textBoxProvider;
        private System.Windows.Forms.ComboBox comboBoxDirection;
        private System.Windows.Forms.GroupBox groupBoxListOfStops;
        private System.Windows.Forms.ListView listViewListOfStops;
        private System.Windows.Forms.ColumnHeader columnHeaderNameStation;
        private System.Windows.Forms.ColumnHeader columnHeaderOrder;
        private System.Windows.Forms.ColumnHeader columnHeaderTimeDifference;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ColumnHeader columnHeaderKmDifference;
        private System.Windows.Forms.GroupBox groupBoxConnectedLines;
        private System.Windows.Forms.Button buttonAddConnectedLines;
        private System.Windows.Forms.ListView listViewListOfConnectedLines;
        private System.Windows.Forms.Button buttonRemoveConnectedLines;
        private System.Windows.Forms.ColumnHeader columnHeaderLine;
        private System.Windows.Forms.ColumnHeader columnHeaderTypeOfTrain;
        private System.Windows.Forms.ColumnHeader columnHeaderPeriod;
        private System.Windows.Forms.ColumnHeader columnHeaderTimeOfStaying;
        private System.Windows.Forms.ColumnHeader columnHeaderTimeFromStart;
        private System.Windows.Forms.ColumnHeader columnHeaderKmFromStart;

    }
}