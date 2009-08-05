namespace PeriodicTimetableGeneration.Forms
{
    partial class FormAddStageDialog
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewListOfAvailableStages = new System.Windows.Forms.ListView();
            this.columnHeaderFrom = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTo = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderLineNumber = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTime = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderDistance = new PeriodicTimetableGeneration.ColHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAdd.Location = new System.Drawing.Point(366, 422);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 30);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(472, 422);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 30);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listViewListOfAvailableStages);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 404);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Stages";
            // 
            // listViewListOfAvailableStages
            // 
            this.listViewListOfAvailableStages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderTo,
            this.columnHeaderLineNumber,
            this.columnHeaderTime,
            this.columnHeaderDistance});
            this.listViewListOfAvailableStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewListOfAvailableStages.FullRowSelect = true;
            this.listViewListOfAvailableStages.GridLines = true;
            this.listViewListOfAvailableStages.Location = new System.Drawing.Point(3, 16);
            this.listViewListOfAvailableStages.MultiSelect = false;
            this.listViewListOfAvailableStages.Name = "listViewListOfAvailableStages";
            this.listViewListOfAvailableStages.Size = new System.Drawing.Size(554, 385);
            this.listViewListOfAvailableStages.TabIndex = 0;
            this.listViewListOfAvailableStages.UseCompatibleStateImageBehavior = false;
            this.listViewListOfAvailableStages.View = System.Windows.Forms.View.Details;
            this.listViewListOfAvailableStages.ItemActivate += new System.EventHandler(this.listViewListOfAvailableStages_ItemActivate);
            this.listViewListOfAvailableStages.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewListOfAvailableStages_ColumnClick);
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
            // columnHeaderLineNumber
            // 
            this.columnHeaderLineNumber.SortType = PeriodicTimetableGeneration.SortType.Integer;
            this.columnHeaderLineNumber.Text = "Line Number";
            this.columnHeaderLineNumber.Width = 80;
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
            // FormAddStageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Name = "FormAddStageDialog";
            this.Text = "Add Stage";
            this.Load += new System.EventHandler(this.FormAddStageDialog_Load);
            this.Shown += new System.EventHandler(this.FormAddStageDialog_Shown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewListOfAvailableStages;
        private ColHeader columnHeaderFrom;
        private ColHeader columnHeaderTo;
        private ColHeader columnHeaderLineNumber;
        private ColHeader columnHeaderTime;
        private ColHeader columnHeaderDistance;
    }
}