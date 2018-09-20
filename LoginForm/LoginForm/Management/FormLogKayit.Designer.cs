namespace LoginForm.Management
{
    partial class FormLogKayit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupPerson = new System.Windows.Forms.GroupBox();
            this.groupLogRecords = new System.Windows.Forms.GroupBox();
            this.dgPerson = new System.Windows.Forms.DataGridView();
            this.WorkerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLog = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TABLE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DONE_OPERATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupPerson.SuspendLayout();
            this.groupLogRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 81);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Start Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(83, 48);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(119, 20);
            this.dtpToDate.TabIndex = 18;
            this.dtpToDate.Value = new System.DateTime(2030, 8, 9, 14, 42, 0, 0);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(83, 15);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(119, 20);
            this.dtpFromDate.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Export Excel";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.Location = new System.Drawing.Point(326, 15);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExcel.TabIndex = 30;
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Close";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.Location = new System.Drawing.Point(407, 18);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnClose.Size = new System.Drawing.Size(52, 52);
            this.btnClose.TabIndex = 32;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupPerson
            // 
            this.groupPerson.Controls.Add(this.dgPerson);
            this.groupPerson.Location = new System.Drawing.Point(12, 90);
            this.groupPerson.Name = "groupPerson";
            this.groupPerson.Size = new System.Drawing.Size(450, 571);
            this.groupPerson.TabIndex = 34;
            this.groupPerson.TabStop = false;
            this.groupPerson.Text = "Person";
            // 
            // groupLogRecords
            // 
            this.groupLogRecords.Controls.Add(this.dgLog);
            this.groupLogRecords.Location = new System.Drawing.Point(468, 90);
            this.groupLogRecords.Name = "groupLogRecords";
            this.groupLogRecords.Size = new System.Drawing.Size(1528, 571);
            this.groupLogRecords.TabIndex = 35;
            this.groupLogRecords.TabStop = false;
            this.groupLogRecords.Text = "Log Records";
            // 
            // dgPerson
            // 
            this.dgPerson.AllowUserToAddRows = false;
            this.dgPerson.AllowUserToDeleteRows = false;
            this.dgPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkerID,
            this.NameLastName});
            this.dgPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPerson.Location = new System.Drawing.Point(3, 16);
            this.dgPerson.Name = "dgPerson";
            this.dgPerson.ReadOnly = true;
            this.dgPerson.Size = new System.Drawing.Size(444, 552);
            this.dgPerson.TabIndex = 0;
            this.dgPerson.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgPerson_MouseClick);
            // 
            // WorkerID
            // 
            this.WorkerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WorkerID.HeaderText = "WorkerID";
            this.WorkerID.Name = "WorkerID";
            this.WorkerID.ReadOnly = true;
            this.WorkerID.Width = 78;
            // 
            // NameLastName
            // 
            this.NameLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameLastName.HeaderText = "Name LastName";
            this.NameLastName.Name = "NameLastName";
            this.NameLastName.ReadOnly = true;
            // 
            // dgLog
            // 
            this.dgLog.AllowUserToAddRows = false;
            this.dgLog.AllowUserToDeleteRows = false;
            this.dgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TABLE_NAME,
            this.TIME,
            this.USER_ID,
            this.DONE_OPERATION});
            this.dgLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLog.Location = new System.Drawing.Point(3, 16);
            this.dgLog.Name = "dgLog";
            this.dgLog.ReadOnly = true;
            this.dgLog.Size = new System.Drawing.Size(1522, 552);
            this.dgLog.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // TABLE_NAME
            // 
            this.TABLE_NAME.HeaderText = "TABLE_NAME";
            this.TABLE_NAME.Name = "TABLE_NAME";
            this.TABLE_NAME.ReadOnly = true;
            // 
            // TIME
            // 
            this.TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.TIME.HeaderText = "TIME";
            this.TIME.Name = "TIME";
            this.TIME.ReadOnly = true;
            this.TIME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TIME.Width = 5;
            // 
            // USER_ID
            // 
            this.USER_ID.HeaderText = "USER_ID";
            this.USER_ID.Name = "USER_ID";
            this.USER_ID.ReadOnly = true;
            this.USER_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DONE_OPERATION
            // 
            this.DONE_OPERATION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DONE_OPERATION.HeaderText = "DONE_OPERATION";
            this.DONE_OPERATION.Name = "DONE_OPERATION";
            this.DONE_OPERATION.ReadOnly = true;
            this.DONE_OPERATION.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Refresh";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnRefreshList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshList.Image = global::LoginForm.Properties.Resources.icons8_Refresh_32;
            this.btnRefreshList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshList.Location = new System.Drawing.Point(251, 18);
            this.btnRefreshList.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnRefreshList.Size = new System.Drawing.Size(52, 52);
            this.btnRefreshList.TabIndex = 36;
            this.btnRefreshList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefreshList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // FormLogKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(2008, 673);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.groupLogRecords);
            this.Controls.Add(this.groupPerson);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1055, 712);
            this.Name = "FormLogKayit";
            this.Text = "Log Records";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormLogKayit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupPerson.ResumeLayout(false);
            this.groupLogRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupPerson;
        private System.Windows.Forms.GroupBox groupLogRecords;
        private System.Windows.Forms.DataGridView dgPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameLastName;
        private System.Windows.Forms.DataGridView dgLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DONE_OPERATION;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefreshList;
    }
}