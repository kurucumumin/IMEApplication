namespace LoginForm.PurchaseOrder
{
    partial class PurchaseOrderMain
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioNotSent = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioSent = new System.Windows.Forms.RadioButton();
            this.btnPurchaseOrders = new System.Windows.Forms.Button();
            this.dateEnding = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateStarting = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgPurchase = new System.Windows.Forms.DataGridView();
            this.purchaseOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FicheNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseOrderDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CameDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnPurchaseOrders);
            this.groupBox1.Controls.Add(this.dateEnding);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateStarting);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1667, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(605, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Search";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioNotSent);
            this.groupBox2.Controls.Add(this.radioAll);
            this.groupBox2.Controls.Add(this.radioSent);
            this.groupBox2.Location = new System.Drawing.Point(6, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 117);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametrs";
            // 
            // radioNotSent
            // 
            this.radioNotSent.AutoSize = true;
            this.radioNotSent.Location = new System.Drawing.Point(6, 54);
            this.radioNotSent.Name = "radioNotSent";
            this.radioNotSent.Size = new System.Drawing.Size(95, 17);
            this.radioNotSent.TabIndex = 2;
            this.radioNotSent.Text = "Not sent to RS";
            this.radioNotSent.UseVisualStyleBackColor = true;
            this.radioNotSent.CheckedChanged += new System.EventHandler(this.radioNotSent_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Location = new System.Drawing.Point(6, 94);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(36, 17);
            this.radioAll.TabIndex = 1;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // radioSent
            // 
            this.radioSent.AutoSize = true;
            this.radioSent.Location = new System.Drawing.Point(6, 19);
            this.radioSent.Name = "radioSent";
            this.radioSent.Size = new System.Drawing.Size(77, 17);
            this.radioSent.TabIndex = 0;
            this.radioSent.Text = "Sent to RS";
            this.radioSent.UseVisualStyleBackColor = true;
            this.radioSent.CheckedChanged += new System.EventHandler(this.radioSent_CheckedChanged);
            // 
            // btnPurchaseOrders
            // 
            this.btnPurchaseOrders.Image = global::LoginForm.Properties.Resources.icons8_Refresh_32;
            this.btnPurchaseOrders.Location = new System.Drawing.Point(1284, 2);
            this.btnPurchaseOrders.Name = "btnPurchaseOrders";
            this.btnPurchaseOrders.Size = new System.Drawing.Size(54, 48);
            this.btnPurchaseOrders.TabIndex = 14;
            this.btnPurchaseOrders.UseVisualStyleBackColor = true;
            this.btnPurchaseOrders.Click += new System.EventHandler(this.btnPurchaseOrders_Click);
            // 
            // dateEnding
            // 
            this.dateEnding.Location = new System.Drawing.Point(1062, 45);
            this.dateEnding.Name = "dateEnding";
            this.dateEnding.Size = new System.Drawing.Size(200, 20);
            this.dateEnding.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(987, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ending Date";
            // 
            // dateStarting
            // 
            this.dateStarting.Location = new System.Drawing.Point(1062, 10);
            this.dateStarting.Name = "dateStarting";
            this.dateStarting.Size = new System.Drawing.Size(200, 20);
            this.dateStarting.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(984, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Starting Date";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(252, 19);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(345, 31);
            this.txtSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.Location = new System.Drawing.Point(603, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 47);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgPurchase
            // 
            this.dgPurchase.AllowUserToAddRows = false;
            this.dgPurchase.AllowUserToDeleteRows = false;
            this.dgPurchase.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchaseOrderId,
            this.PoNo,
            this.FicheNo,
            this.PurchaseOrderDate,
            this.CustomerID,
            this.c_name,
            this.CameDate,
            this.Reason});
            this.dgPurchase.Location = new System.Drawing.Point(7, 148);
            this.dgPurchase.Name = "dgPurchase";
            this.dgPurchase.Size = new System.Drawing.Size(1365, 434);
            this.dgPurchase.TabIndex = 9;
            this.dgPurchase.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgPurchase_DataError);
            this.dgPurchase.DoubleClick += new System.EventHandler(this.dgPurchase_DoubleClick);
            // 
            // purchaseOrderId
            // 
            this.purchaseOrderId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.purchaseOrderId.HeaderText = "ID";
            this.purchaseOrderId.Name = "purchaseOrderId";
            this.purchaseOrderId.Visible = false;
            // 
            // PoNo
            // 
            this.PoNo.HeaderText = "Purchase Order Number";
            this.PoNo.Name = "PoNo";
            // 
            // FicheNo
            // 
            this.FicheNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FicheNo.HeaderText = "Fiche No";
            this.FicheNo.Name = "FicheNo";
            this.FicheNo.Visible = false;
            // 
            // PurchaseOrderDate
            // 
            this.PurchaseOrderDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PurchaseOrderDate.HeaderText = "Date";
            this.PurchaseOrderDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.PurchaseOrderDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.PurchaseOrderDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.PurchaseOrderDate.MonthCalendar.BackgroundStyle.Class = "";
            this.PurchaseOrderDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.PurchaseOrderDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.PurchaseOrderDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PurchaseOrderDate.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.PurchaseOrderDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.PurchaseOrderDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.PurchaseOrderDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.PurchaseOrderDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.PurchaseOrderDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PurchaseOrderDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.PurchaseOrderDate.Name = "PurchaseOrderDate";
            this.PurchaseOrderDate.Width = 55;
            // 
            // CustomerID
            // 
            this.CustomerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CustomerID.HeaderText = "Customer ID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Width = 83;
            // 
            // c_name
            // 
            this.c_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_name.HeaderText = "Customer Name";
            this.c_name.Name = "c_name";
            // 
            // CameDate
            // 
            this.CameDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CameDate.HeaderText = "Creation Date";
            this.CameDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.CameDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.CameDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.CameDate.MonthCalendar.BackgroundStyle.Class = "";
            this.CameDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.CameDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.CameDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CameDate.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.CameDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.CameDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.CameDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.CameDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.CameDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CameDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.CameDate.Name = "CameDate";
            this.CameDate.Width = 89;
            // 
            // Reason
            // 
            this.Reason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reason.HeaderText = "Reason";
            this.Reason.Name = "Reason";
            this.Reason.Width = 69;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnClose.Location = new System.Drawing.Point(1310, 587);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 42);
            this.btnClose.TabIndex = 12;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.Location = new System.Drawing.Point(1126, 587);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(59, 42);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::LoginForm.Properties.Resources.icons8_Plus_32;
            this.btnCreate.Location = new System.Drawing.Point(1040, 587);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(48, 42);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::LoginForm.Properties.Resources.if_print_173079;
            this.btnPrint.Location = new System.Drawing.Point(1225, 587);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(45, 42);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1052, 632);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Add";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1137, 632);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Excel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1236, 632);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Print";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1317, 632);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Close";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1291, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Search";
            // 
            // PurchaseOrderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1370, 651);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgPurchase);
            this.Controls.Add(this.groupBox1);
            this.Name = "PurchaseOrderMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseOrderMain";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PurchaseOrderMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateEnding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateStarting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPurchaseOrders;
        private System.Windows.Forms.DataGridView dgPurchase;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioNotSent;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioSent;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FicheNo;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn PurchaseOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn CameDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}