namespace PeriodicTimetableGeneration.Forms
{
    partial class FormAddLinesDialog
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBoxTrainLines = new System.Windows.Forms.GroupBox();
            this.listViewListOfTrainLines = new System.Windows.Forms.ListView();
            this.columnHeaderLineNumber = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTypeOfTrain = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderPeriod = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderFrom = new PeriodicTimetableGeneration.ColHeader();
            this.columnHeaderTo = new PeriodicTimetableGeneration.ColHeader();
            this.imageListBig = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxTrainLines.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(472, 422);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 30);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAdd.Location = new System.Drawing.Point(366, 422);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 30);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // groupBoxTrainLines
            // 
            this.groupBoxTrainLines.Controls.Add(this.listViewListOfTrainLines);
            this.groupBoxTrainLines.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTrainLines.Name = "groupBoxTrainLines";
            this.groupBoxTrainLines.Size = new System.Drawing.Size(560, 404);
            this.groupBoxTrainLines.TabIndex = 2;
            this.groupBoxTrainLines.TabStop = false;
            this.groupBoxTrainLines.Text = "Available Train Lines";
            // 
            // listViewListOfTrainLines
            // 
            this.listViewListOfTrainLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLineNumber,
            this.columnHeaderTypeOfTrain,
            this.columnHeaderPeriod,
            this.columnHeaderFrom,
            this.columnHeaderTo});
            this.listViewListOfTrainLines.FullRowSelect = true;
            this.listViewListOfTrainLines.GridLines = true;
            this.listViewListOfTrainLines.LargeImageList = this.imageListBig;
            this.listViewListOfTrainLines.Location = new System.Drawing.Point(6, 19);
            this.listViewListOfTrainLines.Name = "listViewListOfTrainLines";
            this.listViewListOfTrainLines.Size = new System.Drawing.Size(548, 379);
            this.listViewListOfTrainLines.SmallImageList = this.imageListSmall;
            this.listViewListOfTrainLines.TabIndex = 0;
            this.listViewListOfTrainLines.UseCompatibleStateImageBehavior = false;
            this.listViewListOfTrainLines.View = System.Windows.Forms.View.Details;
            this.listViewListOfTrainLines.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewListOfTrainLines_ColumnClick);
            // 
            // columnHeaderLineNumber
            // 
            this.columnHeaderLineNumber.Text = "Line Number";
            this.columnHeaderLineNumber.Width = 80;
            // 
            // columnHeaderTypeOfTrain
            // 
            this.columnHeaderTypeOfTrain.Text = "Type of Train";
            this.columnHeaderTypeOfTrain.Width = 80;
            // 
            // columnHeaderPeriod
            // 
            this.columnHeaderPeriod.Text = "Period";
            this.columnHeaderPeriod.Width = 80;
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
            // FormAddLinesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 464);
            this.Controls.Add(this.groupBoxTrainLines);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAddLinesDialog";
            this.Text = "Add Lines";
            this.Shown += new System.EventHandler(this.FormAddLineDialog_Shown);
            this.groupBoxTrainLines.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox groupBoxTrainLines;
        private System.Windows.Forms.ListView listViewListOfTrainLines;
        private System.Windows.Forms.ColumnHeader columnHeaderLineNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderTypeOfTrain;
        private System.Windows.Forms.ColumnHeader columnHeaderPeriod;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.ImageList imageListSmall;
    }
}