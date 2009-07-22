namespace PeriodicTimetableGeneration.Forms
{
    partial class FormGenerationPESP
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
            this.tabControlGenerationPESP = new System.Windows.Forms.TabControl();
            this.tabPageListOfConstraints = new System.Windows.Forms.TabPage();
            this.tabPageGeneration = new System.Windows.Forms.TabPage();
            this.tabPageLinesTimetable = new System.Windows.Forms.TabPage();
            this.tabPageStationsTimetable = new System.Windows.Forms.TabPage();
            this.splitContainerListOfConstraints = new System.Windows.Forms.SplitContainer();
            this.listViewListOfConstraints = new System.Windows.Forms.ListView();
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.imageListBig = new System.Windows.Forms.ImageList(this.components);
            this.columnHeaderLine1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLine2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDiscreteSet = new System.Windows.Forms.ColumnHeader();
            this.backgroundWorkerPESP = new System.ComponentModel.BackgroundWorker();
            this.tabControlGenerationPESP.SuspendLayout();
            this.tabPageListOfConstraints.SuspendLayout();
            this.splitContainerListOfConstraints.Panel1.SuspendLayout();
            this.splitContainerListOfConstraints.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlGenerationPESP
            // 
            this.tabControlGenerationPESP.Controls.Add(this.tabPageListOfConstraints);
            this.tabControlGenerationPESP.Controls.Add(this.tabPageGeneration);
            this.tabControlGenerationPESP.Controls.Add(this.tabPageLinesTimetable);
            this.tabControlGenerationPESP.Controls.Add(this.tabPageStationsTimetable);
            this.tabControlGenerationPESP.Location = new System.Drawing.Point(12, 12);
            this.tabControlGenerationPESP.Name = "tabControlGenerationPESP";
            this.tabControlGenerationPESP.SelectedIndex = 0;
            this.tabControlGenerationPESP.Size = new System.Drawing.Size(960, 540);
            this.tabControlGenerationPESP.TabIndex = 0;
            // 
            // tabPageListOfConstraints
            // 
            this.tabPageListOfConstraints.Controls.Add(this.splitContainerListOfConstraints);
            this.tabPageListOfConstraints.Location = new System.Drawing.Point(4, 22);
            this.tabPageListOfConstraints.Name = "tabPageListOfConstraints";
            this.tabPageListOfConstraints.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListOfConstraints.Size = new System.Drawing.Size(952, 514);
            this.tabPageListOfConstraints.TabIndex = 0;
            this.tabPageListOfConstraints.Text = "List of Constraints";
            this.tabPageListOfConstraints.UseVisualStyleBackColor = true;
            // 
            // tabPageGeneration
            // 
            this.tabPageGeneration.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneration.Name = "tabPageGeneration";
            this.tabPageGeneration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneration.Size = new System.Drawing.Size(942, 504);
            this.tabPageGeneration.TabIndex = 1;
            this.tabPageGeneration.Text = "Generation";
            this.tabPageGeneration.UseVisualStyleBackColor = true;
            // 
            // tabPageLinesTimetable
            // 
            this.tabPageLinesTimetable.Location = new System.Drawing.Point(4, 22);
            this.tabPageLinesTimetable.Name = "tabPageLinesTimetable";
            this.tabPageLinesTimetable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLinesTimetable.Size = new System.Drawing.Size(942, 504);
            this.tabPageLinesTimetable.TabIndex = 2;
            this.tabPageLinesTimetable.Text = "Line\'s Timetable";
            this.tabPageLinesTimetable.UseVisualStyleBackColor = true;
            // 
            // tabPageStationsTimetable
            // 
            this.tabPageStationsTimetable.Location = new System.Drawing.Point(4, 22);
            this.tabPageStationsTimetable.Name = "tabPageStationsTimetable";
            this.tabPageStationsTimetable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStationsTimetable.Size = new System.Drawing.Size(942, 504);
            this.tabPageStationsTimetable.TabIndex = 3;
            this.tabPageStationsTimetable.Text = "StationsTimetable";
            this.tabPageStationsTimetable.UseVisualStyleBackColor = true;
            // 
            // splitContainerListOfConstraints
            // 
            this.splitContainerListOfConstraints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerListOfConstraints.Location = new System.Drawing.Point(3, 3);
            this.splitContainerListOfConstraints.Name = "splitContainerListOfConstraints";
            // 
            // splitContainerListOfConstraints.Panel1
            // 
            this.splitContainerListOfConstraints.Panel1.Controls.Add(this.listViewListOfConstraints);
            // 
            // splitContainerListOfConstraints.Panel2
            // 
            this.splitContainerListOfConstraints.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerListOfConstraints.Size = new System.Drawing.Size(946, 508);
            this.splitContainerListOfConstraints.SplitterDistance = 820;
            this.splitContainerListOfConstraints.TabIndex = 0;
            // 
            // listViewListOfConstraints
            // 
            this.listViewListOfConstraints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine1,
            this.columnHeaderLine2,
            this.columnHeaderDiscreteSet});
            this.listViewListOfConstraints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewListOfConstraints.FullRowSelect = true;
            this.listViewListOfConstraints.GridLines = true;
            this.listViewListOfConstraints.LargeImageList = this.imageListBig;
            this.listViewListOfConstraints.Location = new System.Drawing.Point(0, 0);
            this.listViewListOfConstraints.Name = "listViewListOfConstraints";
            this.listViewListOfConstraints.Size = new System.Drawing.Size(820, 508);
            this.listViewListOfConstraints.SmallImageList = this.imageListSmall;
            this.listViewListOfConstraints.TabIndex = 0;
            this.listViewListOfConstraints.UseCompatibleStateImageBehavior = false;
            this.listViewListOfConstraints.View = System.Windows.Forms.View.Details;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListBig
            // 
            this.imageListBig.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListBig.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListBig.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // columnHeaderLine1
            // 
            this.columnHeaderLine1.Text = "Line1";
            this.columnHeaderLine1.Width = 80;
            // 
            // columnHeaderLine2
            // 
            this.columnHeaderLine2.Text = "Line2";
            this.columnHeaderLine2.Width = 80;
            // 
            // columnHeaderDiscreteSet
            // 
            this.columnHeaderDiscreteSet.Text = "Discrete Set";
            this.columnHeaderDiscreteSet.Width = 350;
            // 
            // backgroundWorkerPESP
            // 
            this.backgroundWorkerPESP.WorkerReportsProgress = true;
            this.backgroundWorkerPESP.WorkerSupportsCancellation = true;
            this.backgroundWorkerPESP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPESP_DoWork);
            this.backgroundWorkerPESP.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPESP_RunWorkerCompleted);
            this.backgroundWorkerPESP.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerPESP_ProgressChanged);
            // 
            // FormGenerationPESP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 564);
            this.Controls.Add(this.tabControlGenerationPESP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormGenerationPESP";
            this.Text = "FormGenerationPESP";
            this.Load += new System.EventHandler(this.FormGenerationPESP_Load);
            this.tabControlGenerationPESP.ResumeLayout(false);
            this.tabPageListOfConstraints.ResumeLayout(false);
            this.splitContainerListOfConstraints.Panel1.ResumeLayout(false);
            this.splitContainerListOfConstraints.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlGenerationPESP;
        private System.Windows.Forms.TabPage tabPageListOfConstraints;
        private System.Windows.Forms.TabPage tabPageGeneration;
        private System.Windows.Forms.TabPage tabPageLinesTimetable;
        private System.Windows.Forms.TabPage tabPageStationsTimetable;
        private System.Windows.Forms.SplitContainer splitContainerListOfConstraints;
        private System.Windows.Forms.ListView listViewListOfConstraints;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.ColumnHeader columnHeaderLine1;
        private System.Windows.Forms.ColumnHeader columnHeaderLine2;
        private System.Windows.Forms.ColumnHeader columnHeaderDiscreteSet;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPESP;
    }
}