namespace PeriodicTimetableGeneration
{
    partial class FormDetailsOfStation
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
            this.groupBoxStationInformation = new System.Windows.Forms.GroupBox();
            this.labelMinimalTransferTime = new System.Windows.Forms.Label();
            this.textBoxMinimalTransferTime = new System.Windows.Forms.TextBox();
            this.textBoxTown = new System.Windows.Forms.TextBox();
            this.labelTown = new System.Windows.Forms.Label();
            this.labelInhabitation = new System.Windows.Forms.Label();
            this.textBoxInhabitation = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.listViewTrainLines = new System.Windows.Forms.ListView();
            this.columnHeaderNumber = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPeriod = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFrom = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTo = new System.Windows.Forms.ColumnHeader();
            this.imageListBig = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxTrainLines = new System.Windows.Forms.GroupBox();
            this.buttonBackDetailsOfStation = new System.Windows.Forms.Button();
            this.buttonSaveDetailsOfStation = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxStationInformation.SuspendLayout();
            this.groupBoxTrainLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxStationInformation
            // 
            this.groupBoxStationInformation.Controls.Add(this.labelMinimalTransferTime);
            this.groupBoxStationInformation.Controls.Add(this.textBoxMinimalTransferTime);
            this.groupBoxStationInformation.Controls.Add(this.textBoxTown);
            this.groupBoxStationInformation.Controls.Add(this.labelTown);
            this.groupBoxStationInformation.Controls.Add(this.labelInhabitation);
            this.groupBoxStationInformation.Controls.Add(this.textBoxInhabitation);
            this.groupBoxStationInformation.Controls.Add(this.comboBoxCategory);
            this.groupBoxStationInformation.Controls.Add(this.labelCategory);
            this.groupBoxStationInformation.Controls.Add(this.labelName);
            this.groupBoxStationInformation.Controls.Add(this.textBoxName);
            this.groupBoxStationInformation.Controls.Add(this.labelId);
            this.groupBoxStationInformation.Controls.Add(this.textBoxId);
            this.groupBoxStationInformation.Location = new System.Drawing.Point(12, 12);
            this.groupBoxStationInformation.Name = "groupBoxStationInformation";
            this.groupBoxStationInformation.Size = new System.Drawing.Size(303, 179);
            this.groupBoxStationInformation.TabIndex = 0;
            this.groupBoxStationInformation.TabStop = false;
            this.groupBoxStationInformation.Text = "Station\'s Information";
            // 
            // labelMinimalTransferTime
            // 
            this.labelMinimalTransferTime.AutoSize = true;
            this.labelMinimalTransferTime.Location = new System.Drawing.Point(6, 152);
            this.labelMinimalTransferTime.Name = "labelMinimalTransferTime";
            this.labelMinimalTransferTime.Size = new System.Drawing.Size(110, 13);
            this.labelMinimalTransferTime.TabIndex = 11;
            this.labelMinimalTransferTime.Text = "Minimal Transfer Time";
            // 
            // textBoxMinimalTransferTime
            // 
            this.textBoxMinimalTransferTime.Location = new System.Drawing.Point(161, 149);
            this.textBoxMinimalTransferTime.Name = "textBoxMinimalTransferTime";
            this.textBoxMinimalTransferTime.Size = new System.Drawing.Size(115, 20);
            this.textBoxMinimalTransferTime.TabIndex = 10;
            // 
            // textBoxTown
            // 
            this.textBoxTown.Location = new System.Drawing.Point(74, 123);
            this.textBoxTown.Name = "textBoxTown";
            this.textBoxTown.Size = new System.Drawing.Size(202, 20);
            this.textBoxTown.TabIndex = 9;
            // 
            // labelTown
            // 
            this.labelTown.AutoSize = true;
            this.labelTown.Location = new System.Drawing.Point(6, 126);
            this.labelTown.Name = "labelTown";
            this.labelTown.Size = new System.Drawing.Size(34, 13);
            this.labelTown.TabIndex = 8;
            this.labelTown.Text = "Town";
            // 
            // labelInhabitation
            // 
            this.labelInhabitation.AutoSize = true;
            this.labelInhabitation.Location = new System.Drawing.Point(6, 100);
            this.labelInhabitation.Name = "labelInhabitation";
            this.labelInhabitation.Size = new System.Drawing.Size(62, 13);
            this.labelInhabitation.TabIndex = 7;
            this.labelInhabitation.Text = "Inhabitation";
            // 
            // textBoxInhabitation
            // 
            this.textBoxInhabitation.Location = new System.Drawing.Point(74, 97);
            this.textBoxInhabitation.Name = "textBoxInhabitation";
            this.textBoxInhabitation.Size = new System.Drawing.Size(202, 20);
            this.textBoxInhabitation.TabIndex = 6;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(74, 70);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(202, 21);
            this.comboBoxCategory.TabIndex = 5;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(6, 73);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(49, 13);
            this.labelCategory.TabIndex = 4;
            this.labelCategory.Text = "Category";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 47);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(74, 44);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(202, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(6, 22);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "Id";
            // 
            // textBoxId
            // 
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(161, 19);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(115, 20);
            this.textBoxId.TabIndex = 0;
            // 
            // listViewTrainLines
            // 
            this.listViewTrainLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumber,
            this.columnHeaderType,
            this.columnHeaderPeriod,
            this.columnHeaderFrom,
            this.columnHeaderTo});
            this.listViewTrainLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTrainLines.Enabled = false;
            this.listViewTrainLines.FullRowSelect = true;
            this.listViewTrainLines.GridLines = true;
            this.listViewTrainLines.LargeImageList = this.imageListBig;
            this.listViewTrainLines.Location = new System.Drawing.Point(3, 16);
            this.listViewTrainLines.MultiSelect = false;
            this.listViewTrainLines.Name = "listViewTrainLines";
            this.listViewTrainLines.Size = new System.Drawing.Size(645, 384);
            this.listViewTrainLines.SmallImageList = this.imageListSmall;
            this.listViewTrainLines.TabIndex = 1;
            this.listViewTrainLines.UseCompatibleStateImageBehavior = false;
            this.listViewTrainLines.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNumber
            // 
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
            // columnHeaderFrom
            // 
            this.columnHeaderFrom.Text = "From";
            this.columnHeaderFrom.Width = 200;
            // 
            // columnHeaderTo
            // 
            this.columnHeaderTo.Text = "ToStation";
            this.columnHeaderTo.Width = 200;
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
            // groupBoxTrainLines
            // 
            this.groupBoxTrainLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTrainLines.Controls.Add(this.listViewTrainLines);
            this.groupBoxTrainLines.Location = new System.Drawing.Point(321, 12);
            this.groupBoxTrainLines.Name = "groupBoxTrainLines";
            this.groupBoxTrainLines.Size = new System.Drawing.Size(651, 403);
            this.groupBoxTrainLines.TabIndex = 2;
            this.groupBoxTrainLines.TabStop = false;
            this.groupBoxTrainLines.Text = "Train Lines";
            // 
            // buttonBackDetailsOfStation
            // 
            this.buttonBackDetailsOfStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBackDetailsOfStation.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBackDetailsOfStation.Location = new System.Drawing.Point(12, 422);
            this.buttonBackDetailsOfStation.Name = "buttonBackDetailsOfStation";
            this.buttonBackDetailsOfStation.Size = new System.Drawing.Size(100, 30);
            this.buttonBackDetailsOfStation.TabIndex = 3;
            this.buttonBackDetailsOfStation.Text = "Back";
            this.buttonBackDetailsOfStation.UseVisualStyleBackColor = true;
            this.buttonBackDetailsOfStation.Click += new System.EventHandler(this.buttonBackDetailsOfStation_Click);
            // 
            // buttonSaveDetailsOfStation
            // 
            this.buttonSaveDetailsOfStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveDetailsOfStation.Location = new System.Drawing.Point(872, 422);
            this.buttonSaveDetailsOfStation.Name = "buttonSaveDetailsOfStation";
            this.buttonSaveDetailsOfStation.Size = new System.Drawing.Size(100, 30);
            this.buttonSaveDetailsOfStation.TabIndex = 4;
            this.buttonSaveDetailsOfStation.Text = "Save";
            this.buttonSaveDetailsOfStation.UseVisualStyleBackColor = true;
            this.buttonSaveDetailsOfStation.Click += new System.EventHandler(this.buttonSaveDetailsOfStation_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormDetailsOfStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 464);
            this.Controls.Add(this.buttonSaveDetailsOfStation);
            this.Controls.Add(this.buttonBackDetailsOfStation);
            this.Controls.Add(this.groupBoxTrainLines);
            this.Controls.Add(this.groupBoxStationInformation);
            this.Name = "FormDetailsOfStation";
            this.Text = "Details of Station";
            this.Load += new System.EventHandler(this.FormDetailsOfStation_Load);
            this.groupBoxStationInformation.ResumeLayout(false);
            this.groupBoxStationInformation.PerformLayout();
            this.groupBoxTrainLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStationInformation;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ListView listViewTrainLines;
        private System.Windows.Forms.GroupBox groupBoxTrainLines;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.Button buttonBackDetailsOfStation;
        private System.Windows.Forms.Button buttonSaveDetailsOfStation;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.Label labelInhabitation;
        private System.Windows.Forms.TextBox textBoxInhabitation;
        private System.Windows.Forms.ColumnHeader columnHeaderPeriod;
        private System.Windows.Forms.TextBox textBoxTown;
        private System.Windows.Forms.Label labelTown;
        private System.Windows.Forms.Label labelMinimalTransferTime;
        private System.Windows.Forms.TextBox textBoxMinimalTransferTime;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}