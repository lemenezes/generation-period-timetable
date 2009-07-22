namespace PeriodicTimetableGeneration.Forms
{
    partial class FormEditPathOfConnection
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.labelToStation = new System.Windows.Forms.Label();
            this.labelFromStation = new System.Windows.Forms.Label();
            this.textBoxFromStation = new System.Windows.Forms.TextBox();
            this.textBoxToStation = new System.Windows.Forms.TextBox();
            this.groupBoxPathStages = new System.Windows.Forms.GroupBox();
            this.buttonRemoveAllStages = new System.Windows.Forms.Button();
            this.buttonAddStage = new System.Windows.Forms.Button();
            this.listViewListOfStages = new System.Windows.Forms.ListView();
            this.columnHeaderFrom = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTo = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLineNumber = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPathValidity = new System.Windows.Forms.TextBox();
            this.groupBoxConnection.SuspendLayout();
            this.groupBoxPathStages.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(472, 422);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBack.Location = new System.Drawing.Point(12, 422);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(100, 30);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.labelToStation);
            this.groupBoxConnection.Controls.Add(this.labelFromStation);
            this.groupBoxConnection.Controls.Add(this.textBoxFromStation);
            this.groupBoxConnection.Controls.Add(this.textBoxToStation);
            this.groupBoxConnection.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(560, 50);
            this.groupBoxConnection.TabIndex = 2;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";
            // 
            // labelToStation
            // 
            this.labelToStation.AutoSize = true;
            this.labelToStation.Location = new System.Drawing.Point(292, 22);
            this.labelToStation.Name = "labelToStation";
            this.labelToStation.Size = new System.Drawing.Size(56, 13);
            this.labelToStation.TabIndex = 3;
            this.labelToStation.Text = "To Station";
            // 
            // labelFromStation
            // 
            this.labelFromStation.AutoSize = true;
            this.labelFromStation.Location = new System.Drawing.Point(6, 22);
            this.labelFromStation.Name = "labelFromStation";
            this.labelFromStation.Size = new System.Drawing.Size(66, 13);
            this.labelFromStation.TabIndex = 2;
            this.labelFromStation.Text = "From Station";
            // 
            // textBoxFromStation
            // 
            this.textBoxFromStation.Enabled = false;
            this.textBoxFromStation.Location = new System.Drawing.Point(78, 19);
            this.textBoxFromStation.Name = "textBoxFromStation";
            this.textBoxFromStation.Size = new System.Drawing.Size(200, 20);
            this.textBoxFromStation.TabIndex = 1;
            // 
            // textBoxToStation
            // 
            this.textBoxToStation.Enabled = false;
            this.textBoxToStation.Location = new System.Drawing.Point(354, 19);
            this.textBoxToStation.Name = "textBoxToStation";
            this.textBoxToStation.Size = new System.Drawing.Size(200, 20);
            this.textBoxToStation.TabIndex = 0;
            // 
            // groupBoxPathStages
            // 
            this.groupBoxPathStages.Controls.Add(this.buttonRemoveAllStages);
            this.groupBoxPathStages.Controls.Add(this.buttonAddStage);
            this.groupBoxPathStages.Controls.Add(this.listViewListOfStages);
            this.groupBoxPathStages.Controls.Add(this.label1);
            this.groupBoxPathStages.Controls.Add(this.textBoxPathValidity);
            this.groupBoxPathStages.Location = new System.Drawing.Point(12, 68);
            this.groupBoxPathStages.Name = "groupBoxPathStages";
            this.groupBoxPathStages.Size = new System.Drawing.Size(560, 348);
            this.groupBoxPathStages.TabIndex = 3;
            this.groupBoxPathStages.TabStop = false;
            this.groupBoxPathStages.Text = "Path\'s Stages";
            // 
            // buttonRemoveAllStages
            // 
            this.buttonRemoveAllStages.Location = new System.Drawing.Point(449, 82);
            this.buttonRemoveAllStages.Name = "buttonRemoveAllStages";
            this.buttonRemoveAllStages.Size = new System.Drawing.Size(105, 30);
            this.buttonRemoveAllStages.TabIndex = 5;
            this.buttonRemoveAllStages.Text = "Remove All Stages";
            this.buttonRemoveAllStages.UseVisualStyleBackColor = true;
            this.buttonRemoveAllStages.Click += new System.EventHandler(this.buttonRemoveAllStages_Click);
            // 
            // buttonAddStage
            // 
            this.buttonAddStage.Location = new System.Drawing.Point(449, 46);
            this.buttonAddStage.Name = "buttonAddStage";
            this.buttonAddStage.Size = new System.Drawing.Size(105, 30);
            this.buttonAddStage.TabIndex = 4;
            this.buttonAddStage.Text = "Add Stage";
            this.buttonAddStage.UseVisualStyleBackColor = true;
            this.buttonAddStage.Click += new System.EventHandler(this.buttonAddStage_Click);
            // 
            // listViewListOfStages
            // 
            this.listViewListOfStages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderTo,
            this.columnHeaderLineNumber});
            this.listViewListOfStages.FullRowSelect = true;
            this.listViewListOfStages.GridLines = true;
            this.listViewListOfStages.Location = new System.Drawing.Point(7, 20);
            this.listViewListOfStages.Name = "listViewListOfStages";
            this.listViewListOfStages.Size = new System.Drawing.Size(436, 296);
            this.listViewListOfStages.TabIndex = 2;
            this.listViewListOfStages.UseCompatibleStateImageBehavior = false;
            this.listViewListOfStages.View = System.Windows.Forms.View.Details;
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
            this.columnHeaderLineNumber.Text = "Line Number";
            this.columnHeaderLineNumber.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path\'s Validity";
            // 
            // textBoxPathValidity
            // 
            this.textBoxPathValidity.Enabled = false;
            this.textBoxPathValidity.Location = new System.Drawing.Point(84, 322);
            this.textBoxPathValidity.Name = "textBoxPathValidity";
            this.textBoxPathValidity.Size = new System.Drawing.Size(150, 20);
            this.textBoxPathValidity.TabIndex = 0;
            // 
            // FormEditPathOfConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 464);
            this.Controls.Add(this.groupBoxPathStages);
            this.Controls.Add(this.groupBoxConnection);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormEditPathOfConnection";
            this.Text = "Edit Path of Connection";
            this.Shown += new System.EventHandler(this.FormEditPathOfConnection_Shown);
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.groupBoxPathStages.ResumeLayout(false);
            this.groupBoxPathStages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label labelToStation;
        private System.Windows.Forms.Label labelFromStation;
        private System.Windows.Forms.TextBox textBoxFromStation;
        private System.Windows.Forms.TextBox textBoxToStation;
        private System.Windows.Forms.GroupBox groupBoxPathStages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPathValidity;
        private System.Windows.Forms.ListView listViewListOfStages;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.ColumnHeader columnHeaderLineNumber;
        private System.Windows.Forms.Button buttonRemoveAllStages;
        private System.Windows.Forms.Button buttonAddStage;
    }
}