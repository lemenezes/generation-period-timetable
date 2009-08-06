namespace PeriodicTimetableGeneration.Forms
{
    partial class FormDetailsOfConnection
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxConnectionInformation = new System.Windows.Forms.GroupBox();
            this.labelPassengers = new System.Windows.Forms.Label();
            this.labelDistance = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.textBoxPassengers = new System.Windows.Forms.TextBox();
            this.textBoxTotalDistance = new System.Windows.Forms.TextBox();
            this.textBoxTotalTime = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.groupBoxPathStages = new System.Windows.Forms.GroupBox();
            this.listViewConnectionStages = new System.Windows.Forms.ListView();
            this.columnHeaderFrom = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTo = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLineNumber = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTime = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDistance = new System.Windows.Forms.ColumnHeader();
            this.imageListBig = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxConnectionInformation.SuspendLayout();
            this.groupBoxPathStages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBack.Location = new System.Drawing.Point(12, 422);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(100, 30);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(872, 422);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxConnectionInformation
            // 
            this.groupBoxConnectionInformation.Controls.Add(this.labelPassengers);
            this.groupBoxConnectionInformation.Controls.Add(this.labelDistance);
            this.groupBoxConnectionInformation.Controls.Add(this.labelTime);
            this.groupBoxConnectionInformation.Controls.Add(this.labelTo);
            this.groupBoxConnectionInformation.Controls.Add(this.labelFrom);
            this.groupBoxConnectionInformation.Controls.Add(this.textBoxPassengers);
            this.groupBoxConnectionInformation.Controls.Add(this.textBoxTotalDistance);
            this.groupBoxConnectionInformation.Controls.Add(this.textBoxTotalTime);
            this.groupBoxConnectionInformation.Controls.Add(this.textBoxTo);
            this.groupBoxConnectionInformation.Controls.Add(this.textBoxFrom);
            this.groupBoxConnectionInformation.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnectionInformation.Name = "groupBoxConnectionInformation";
            this.groupBoxConnectionInformation.Size = new System.Drawing.Size(327, 154);
            this.groupBoxConnectionInformation.TabIndex = 2;
            this.groupBoxConnectionInformation.TabStop = false;
            this.groupBoxConnectionInformation.Text = "Connection\'s Information";
            // 
            // labelPassengers
            // 
            this.labelPassengers.AutoSize = true;
            this.labelPassengers.Location = new System.Drawing.Point(6, 126);
            this.labelPassengers.Name = "labelPassengers";
            this.labelPassengers.Size = new System.Drawing.Size(62, 13);
            this.labelPassengers.TabIndex = 9;
            this.labelPassengers.Text = "Passengers";
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(6, 100);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(76, 13);
            this.labelDistance.TabIndex = 8;
            this.labelDistance.Text = "Total Distance";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(6, 74);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(57, 13);
            this.labelTime.TabIndex = 7;
            this.labelTime.Text = "Total Time";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(6, 48);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(89, 13);
            this.labelTo.TabIndex = 6;
            this.labelTo.Text = "ToStation Station";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Enabled = false;
            this.labelFrom.Location = new System.Drawing.Point(6, 22);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(66, 13);
            this.labelFrom.TabIndex = 5;
            this.labelFrom.Text = "From Station";
            // 
            // textBoxPassengers
            // 
            this.textBoxPassengers.Location = new System.Drawing.Point(194, 126);
            this.textBoxPassengers.Name = "textBoxPassengers";
            this.textBoxPassengers.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassengers.TabIndex = 4;
            // 
            // textBoxTotalDistance
            // 
            this.textBoxTotalDistance.Enabled = false;
            this.textBoxTotalDistance.Location = new System.Drawing.Point(194, 100);
            this.textBoxTotalDistance.Name = "textBoxTotalDistance";
            this.textBoxTotalDistance.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalDistance.TabIndex = 3;
            // 
            // textBoxTotalTime
            // 
            this.textBoxTotalTime.Enabled = false;
            this.textBoxTotalTime.Location = new System.Drawing.Point(194, 74);
            this.textBoxTotalTime.Name = "textBoxTotalTime";
            this.textBoxTotalTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalTime.TabIndex = 2;
            // 
            // textBoxTo
            // 
            this.textBoxTo.Enabled = false;
            this.textBoxTo.Location = new System.Drawing.Point(94, 45);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(200, 20);
            this.textBoxTo.TabIndex = 1;
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Enabled = false;
            this.textBoxFrom.Location = new System.Drawing.Point(94, 19);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(200, 20);
            this.textBoxFrom.TabIndex = 0;
            // 
            // groupBoxPathStages
            // 
            this.groupBoxPathStages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPathStages.Controls.Add(this.listViewConnectionStages);
            this.groupBoxPathStages.Location = new System.Drawing.Point(342, 12);
            this.groupBoxPathStages.Name = "groupBoxPathStages";
            this.groupBoxPathStages.Size = new System.Drawing.Size(630, 404);
            this.groupBoxPathStages.TabIndex = 3;
            this.groupBoxPathStages.TabStop = false;
            this.groupBoxPathStages.Text = "Path\'s Stages";
            // 
            // listViewConnectionStages
            // 
            this.listViewConnectionStages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderTo,
            this.columnHeaderLineNumber,
            this.columnHeaderTime,
            this.columnHeaderDistance});
            this.listViewConnectionStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewConnectionStages.FullRowSelect = true;
            this.listViewConnectionStages.GridLines = true;
            this.listViewConnectionStages.LargeImageList = this.imageListBig;
            this.listViewConnectionStages.Location = new System.Drawing.Point(3, 16);
            this.listViewConnectionStages.Name = "listViewConnectionStages";
            this.listViewConnectionStages.Size = new System.Drawing.Size(624, 385);
            this.listViewConnectionStages.SmallImageList = this.imageListSmall;
            this.listViewConnectionStages.TabIndex = 0;
            this.listViewConnectionStages.UseCompatibleStateImageBehavior = false;
            this.listViewConnectionStages.View = System.Windows.Forms.View.Details;
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
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderTime.Width = 80;
            // 
            // columnHeaderDistance
            // 
            this.columnHeaderDistance.Text = "Distance";
            this.columnHeaderDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderDistance.Width = 80;
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormDetailsOfConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 464);
            this.Controls.Add(this.groupBoxPathStages);
            this.Controls.Add(this.groupBoxConnectionInformation);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonBack);
            this.Name = "FormDetailsOfConnection";
            this.Text = "Details of Connection";
            this.Shown += new System.EventHandler(this.FormDetailsOfConnection_Shown);
            this.groupBoxConnectionInformation.ResumeLayout(false);
            this.groupBoxConnectionInformation.PerformLayout();
            this.groupBoxPathStages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxConnectionInformation;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.GroupBox groupBoxPathStages;
        private System.Windows.Forms.ListView listViewConnectionStages;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.ColumnHeader columnHeaderLineNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderDistance;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.Label labelPassengers;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.TextBox textBoxPassengers;
        private System.Windows.Forms.TextBox textBoxTotalDistance;
        private System.Windows.Forms.TextBox textBoxTotalTime;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}