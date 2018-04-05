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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnPurchaseOrders);
            this.groupBox1.Controls.Add(this.dateEnding);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateStarting);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(2223, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioNotSent);
            this.groupBox2.Controls.Add(this.radioAll);
            this.groupBox2.Controls.Add(this.radioSent);
            this.groupBox2.Location = new System.Drawing.Point(8, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(280, 144);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametrs";
            // 
            // radioNotSent
            // 
            this.radioNotSent.AutoSize = true;
            this.radioNotSent.Location = new System.Drawing.Point(8, 66);
            this.radioNotSent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioNotSent.Name = "radioNotSent";
            this.radioNotSent.Size = new System.Drawing.Size(121, 21);
            this.radioNotSent.TabIndex = 2;
            this.radioNotSent.Text = "Not sent to RS";
            this.radioNotSent.UseVisualStyleBackColor = true;
            this.radioNotSent.CheckedChanged += new System.EventHandler(this.radioNotSent_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Location = new System.Drawing.Point(8, 116);
            this.radioAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(44, 21);
            this.radioAll.TabIndex = 1;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // radioSent
            // 
            this.radioSent.AutoSize = true;
            this.radioSent.Location = new System.Drawing.Point(8, 23);
            this.radioSent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioSent.Name = "radioSent";
            this.radioSent.Size = new System.Drawing.Size(97, 21);
            this.radioSent.TabIndex = 0;
            this.radioSent.Text = "Sent to RS";
            this.radioSent.UseVisualStyleBackColor = true;
            this.radioSent.CheckedChanged += new System.EventHandler(this.radioSent_CheckedChanged);
            // 
            // btnPurchaseOrders
            // 
            this.btnPurchaseOrders.Location = new System.Drawing.Point(1596, 16);
            this.btnPurchaseOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPurchaseOrders.Name = "btnPurchaseOrders";
            this.btnPurchaseOrders.Size = new System.Drawing.Size(217, 112);
            this.btnPurchaseOrders.TabIndex = 14;
            this.btnPurchaseOrders.Text = "Bring The Purchase Orders";
            this.btnPurchaseOrders.UseVisualStyleBackColor = true;
            this.btnPurchaseOrders.Click += new System.EventHandler(this.btnPurchaseOrders_Click);
            // 
            // dateEnding
            // 
            this.dateEnding.Location = new System.Drawing.Point(1187, 103);
            this.dateEnding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateEnding.Name = "dateEnding";
            this.dateEnding.Size = new System.Drawing.Size(265, 22);
            this.dateEnding.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1091, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ending Date";
            // 
            // dateStarting
            // 
            this.dateStarting.Location = new System.Drawing.Point(1187, 34);
            this.dateStarting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateStarting.Name = "dateStarting";
            this.dateStarting.Size = new System.Drawing.Size(265, 22);
            this.dateStarting.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1087, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Starting Date";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(336, 23);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(459, 37);
            this.txtSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(804, 16);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(233, 63);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgPurchase
            // 
            this.dgPurchase.AllowUserToAddRows = false;
            this.dgPurchase.AllowUserToDeleteRows = false;
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
            this.dgPurchase.Location = new System.Drawing.Point(9, 182);
            this.dgPurchase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgPurchase.Name = "dgPurchase";
            this.dgPurchase.Size = new System.Drawing.Size(1820, 534);
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
            this.PurchaseOrderDate.Width = 67;
            // 
            // CustomerID
            // 
            this.CustomerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CustomerID.HeaderText = "Customer ID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Width = 105;
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
            this.CameDate.Width = 114;
            // 
            // Reason
            // 
            this.Reason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reason.HeaderText = "Reason";
            this.Reason.Name = "Reason";
            this.Reason.Width = 86;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1707, 736);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 52);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(1203, 736);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(221, 52);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "Export to Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(1432, 736);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(129, 52);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create Purchase Orders";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1569, 736);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(129, 52);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Send To Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // PurchaseOrderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1845, 802);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgPurchase);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}