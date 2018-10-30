namespace LoginForm.QuotationModule
{
    partial class FormQuotationMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgQuotation = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rep_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreparedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rep2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dELETEQUOTATIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uNDODELETEQUOTATIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUOTATIONINFOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUOTATIONPRINTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dISCONTINUEDUSERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOPYQUOTATIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mODIFYQUOTATIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uPDATEQUOTATIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cREATESALEORDERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchStockNumber = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.chcCustStockNumber = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.chcAllQuots = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnNewQuotation = new System.Windows.Forms.Button();
            this.btnModifyQuotation = new System.Windows.Forms.Button();
            this.btnDeleteQuotation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotation)).BeginInit();
            this.gridRightClick.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgQuotation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 696);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgQuotation
            // 
            this.dgQuotation.AllowUserToAddRows = false;
            this.dgQuotation.AllowUserToDeleteRows = false;
            this.dgQuotation.AllowUserToOrderColumns = true;
            this.dgQuotation.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgQuotation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgQuotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.QuotationNo,
            this.Rep_Name,
            this.PreparedBy,
            this.RFQ,
            this.CustomerCode,
            this.CustomerName,
            this.Total,
            this.Currency,
            this.OrderDate,
            this.City,
            this.SaleOrderNo,
            this.OrderStatus,
            this.FirstNote,
            this.Date1,
            this.Rep1,
            this.SecondNote,
            this.Date2,
            this.Rep2,
            this.SaleOrderID});
            this.dgQuotation.ContextMenuStrip = this.gridRightClick;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgQuotation.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgQuotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgQuotation.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgQuotation.Location = new System.Drawing.Point(8, 129);
            this.dgQuotation.Margin = new System.Windows.Forms.Padding(8);
            this.dgQuotation.Name = "dgQuotation";
            this.dgQuotation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgQuotation.RowTemplate.Height = 24;
            this.dgQuotation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgQuotation.Size = new System.Drawing.Size(1354, 550);
            this.dgQuotation.TabIndex = 0;
            this.dgQuotation.TabStop = false;
            this.dgQuotation.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgQuotation_CellEndEdit);
            this.dgQuotation.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgQuotation_CellMouseDoubleClick);
            this.dgQuotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgQuotation_KeyDown);
            this.dgQuotation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgQuotation_MouseDown);
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // QuotationNo
            // 
            this.QuotationNo.HeaderText = "QuotationNo";
            this.QuotationNo.Name = "QuotationNo";
            this.QuotationNo.ReadOnly = true;
            // 
            // Rep_Name
            // 
            this.Rep_Name.HeaderText = "Rep_Name";
            this.Rep_Name.Name = "Rep_Name";
            this.Rep_Name.ReadOnly = true;
            // 
            // PreparedBy
            // 
            this.PreparedBy.HeaderText = "PreparedBy";
            this.PreparedBy.Name = "PreparedBy";
            this.PreparedBy.ReadOnly = true;
            // 
            // RFQ
            // 
            this.RFQ.HeaderText = "RFQ";
            this.RFQ.Name = "RFQ";
            this.RFQ.ReadOnly = true;
            // 
            // CustomerCode
            // 
            this.CustomerCode.HeaderText = "CustomerCode";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 119;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            this.Currency.ReadOnly = true;
            // 
            // OrderDate
            // 
            this.OrderDate.HeaderText = "OrderDate";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            // 
            // SaleOrderNo
            // 
            this.SaleOrderNo.HeaderText = "Sale Order No";
            this.SaleOrderNo.Name = "SaleOrderNo";
            // 
            // OrderStatus
            // 
            this.OrderStatus.HeaderText = "Status";
            this.OrderStatus.Name = "OrderStatus";
            this.OrderStatus.ReadOnly = true;
            // 
            // FirstNote
            // 
            this.FirstNote.HeaderText = "FirstNote";
            this.FirstNote.Name = "FirstNote";
            // 
            // Date1
            // 
            this.Date1.HeaderText = "Date1";
            this.Date1.Name = "Date1";
            this.Date1.ReadOnly = true;
            // 
            // Rep1
            // 
            this.Rep1.HeaderText = "Rep1";
            this.Rep1.Name = "Rep1";
            this.Rep1.ReadOnly = true;
            // 
            // SecondNote
            // 
            this.SecondNote.HeaderText = "SecondNote";
            this.SecondNote.Name = "SecondNote";
            // 
            // Date2
            // 
            this.Date2.HeaderText = "Date2";
            this.Date2.Name = "Date2";
            this.Date2.ReadOnly = true;
            // 
            // Rep2
            // 
            this.Rep2.HeaderText = "Rep2";
            this.Rep2.Name = "Rep2";
            this.Rep2.ReadOnly = true;
            // 
            // SaleOrderID
            // 
            this.SaleOrderID.HeaderText = "SaleOrderID";
            this.SaleOrderID.Name = "SaleOrderID";
            this.SaleOrderID.ReadOnly = true;
            this.SaleOrderID.Visible = false;
            // 
            // gridRightClick
            // 
            this.gridRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dELETEQUOTATIONToolStripMenuItem,
            this.uNDODELETEQUOTATIONToolStripMenuItem,
            this.qUOTATIONINFOToolStripMenuItem,
            this.qUOTATIONPRINTToolStripMenuItem,
            this.dISCONTINUEDUSERToolStripMenuItem,
            this.cOPYQUOTATIONToolStripMenuItem,
            this.mODIFYQUOTATIONToolStripMenuItem,
            this.uPDATEQUOTATIONToolStripMenuItem,
            this.cREATESALEORDERToolStripMenuItem});
            this.gridRightClick.Name = "gridRightClick";
            this.gridRightClick.Size = new System.Drawing.Size(195, 202);
            // 
            // dELETEQUOTATIONToolStripMenuItem
            // 
            this.dELETEQUOTATIONToolStripMenuItem.Name = "dELETEQUOTATIONToolStripMenuItem";
            this.dELETEQUOTATIONToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.dELETEQUOTATIONToolStripMenuItem.Text = "DELETE";
            this.dELETEQUOTATIONToolStripMenuItem.Click += new System.EventHandler(this.dELETEQUOTATIONToolStripMenuItem_Click);
            // 
            // uNDODELETEQUOTATIONToolStripMenuItem
            // 
            this.uNDODELETEQUOTATIONToolStripMenuItem.Name = "uNDODELETEQUOTATIONToolStripMenuItem";
            this.uNDODELETEQUOTATIONToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.uNDODELETEQUOTATIONToolStripMenuItem.Text = "UNDO DELETE";
            this.uNDODELETEQUOTATIONToolStripMenuItem.Click += new System.EventHandler(this.uNDODELETEQUOTATIONToolStripMenuItem_Click);
            // 
            // qUOTATIONINFOToolStripMenuItem
            // 
            this.qUOTATIONINFOToolStripMenuItem.Name = "qUOTATIONINFOToolStripMenuItem";
            this.qUOTATIONINFOToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.qUOTATIONINFOToolStripMenuItem.Text = " INFO";
            this.qUOTATIONINFOToolStripMenuItem.Click += new System.EventHandler(this.qUOTATIONINFOToolStripMenuItem_Click);
            // 
            // qUOTATIONPRINTToolStripMenuItem
            // 
            this.qUOTATIONPRINTToolStripMenuItem.Name = "qUOTATIONPRINTToolStripMenuItem";
            this.qUOTATIONPRINTToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.qUOTATIONPRINTToolStripMenuItem.Text = "PRINT";
            this.qUOTATIONPRINTToolStripMenuItem.Click += new System.EventHandler(this.qUOTATIONPRINTToolStripMenuItem_Click);
            // 
            // dISCONTINUEDUSERToolStripMenuItem
            // 
            this.dISCONTINUEDUSERToolStripMenuItem.Name = "dISCONTINUEDUSERToolStripMenuItem";
            this.dISCONTINUEDUSERToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.dISCONTINUEDUSERToolStripMenuItem.Text = "DISCONNECT USER";
            this.dISCONTINUEDUSERToolStripMenuItem.Click += new System.EventHandler(this.dISCONTINUEDUSERToolStripMenuItem_Click);
            // 
            // cOPYQUOTATIONToolStripMenuItem
            // 
            this.cOPYQUOTATIONToolStripMenuItem.Name = "cOPYQUOTATIONToolStripMenuItem";
            this.cOPYQUOTATIONToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.cOPYQUOTATIONToolStripMenuItem.Text = "COPY QUOTATION";
            this.cOPYQUOTATIONToolStripMenuItem.Click += new System.EventHandler(this.cOPYQUOTATIONToolStripMenuItem_Click);
            // 
            // mODIFYQUOTATIONToolStripMenuItem
            // 
            this.mODIFYQUOTATIONToolStripMenuItem.Name = "mODIFYQUOTATIONToolStripMenuItem";
            this.mODIFYQUOTATIONToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.mODIFYQUOTATIONToolStripMenuItem.Text = "CREATE NEW VERSION";
            this.mODIFYQUOTATIONToolStripMenuItem.Click += new System.EventHandler(this.mODIFYQUOTATIONToolStripMenuItem_Click);
            // 
            // uPDATEQUOTATIONToolStripMenuItem
            // 
            this.uPDATEQUOTATIONToolStripMenuItem.Name = "uPDATEQUOTATIONToolStripMenuItem";
            this.uPDATEQUOTATIONToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.uPDATEQUOTATIONToolStripMenuItem.Text = "MODIFY";
            this.uPDATEQUOTATIONToolStripMenuItem.Click += new System.EventHandler(this.uPDATEQUOTATIONToolStripMenuItem_Click);
            // 
            // cREATESALEORDERToolStripMenuItem
            // 
            this.cREATESALEORDERToolStripMenuItem.Name = "cREATESALEORDERToolStripMenuItem";
            this.cREATESALEORDERToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.cREATESALEORDERToolStripMenuItem.Text = "CREATE SALE ORDER";
            this.cREATESALEORDERToolStripMenuItem.Click += new System.EventHandler(this.cREATESALEORDERToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchStockNumber);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 115);
            this.panel1.TabIndex = 1;
            // 
            // btnSearchStockNumber
            // 
            this.btnSearchStockNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnSearchStockNumber.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnSearchStockNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStockNumber.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearchStockNumber.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearchStockNumber.Location = new System.Drawing.Point(1286, 22);
            this.btnSearchStockNumber.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchStockNumber.Name = "btnSearchStockNumber";
            this.btnSearchStockNumber.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnSearchStockNumber.Size = new System.Drawing.Size(52, 52);
            this.btnSearchStockNumber.TabIndex = 27;
            this.btnSearchStockNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearchStockNumber.UseVisualStyleBackColor = true;
            this.btnSearchStockNumber.Click += new System.EventHandler(this.btnSearchStockNumber_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1286, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Search";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtStockCode);
            this.groupBox4.Controls.Add(this.chcCustStockNumber);
            this.groupBox4.Location = new System.Drawing.Point(1063, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 106);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(3, 13);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(192, 21);
            this.txtStockCode.TabIndex = 25;
            this.txtStockCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStockCode_KeyDown);
            // 
            // chcCustStockNumber
            // 
            this.chcCustStockNumber.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcCustStockNumber.Location = new System.Drawing.Point(3, 45);
            this.chcCustStockNumber.Name = "chcCustStockNumber";
            this.chcCustStockNumber.Size = new System.Drawing.Size(192, 21);
            this.chcCustStockNumber.TabIndex = 26;
            this.chcCustStockNumber.Text = "Customer Stock Code";
            this.chcCustStockNumber.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbSearch);
            this.groupBox3.Controls.Add(this.txtSearchText);
            this.groupBox3.Controls.Add(this.chcAllQuots);
            this.groupBox3.Location = new System.Drawing.Point(822, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 109);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // cbSearch
            // 
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "QUOT NUMBER",
            "CUSTOMER CODE",
            "CUSTOMER NAME",
            "TOTAL AMOUNT",
            "RFQ",
            "MPN",
            "SALE ORDER NO",
            "PURCHASE ORDER NO"});
            this.cbSearch.Location = new System.Drawing.Point(6, 14);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(216, 23);
            this.cbSearch.TabIndex = 22;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(6, 44);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(216, 21);
            this.txtSearchText.TabIndex = 23;
            this.txtSearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchText_KeyPress);
            // 
            // chcAllQuots
            // 
            this.chcAllQuots.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcAllQuots.Checked = true;
            this.chcAllQuots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcAllQuots.Location = new System.Drawing.Point(6, 85);
            this.chcAllQuots.Name = "chcAllQuots";
            this.chcAllQuots.Size = new System.Drawing.Size(216, 21);
            this.chcAllQuots.TabIndex = 24;
            this.chcAllQuots.Text = "All Quotations";
            this.chcAllQuots.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcAllQuots.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnRefreshList);
            this.groupBox2.Controls.Add(this.btnNewQuotation);
            this.groupBox2.Controls.Add(this.btnModifyQuotation);
            this.groupBox2.Controls.Add(this.btnDeleteQuotation);
            this.groupBox2.Location = new System.Drawing.Point(234, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 112);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 32;
            this.label10.Text = "Modify";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::LoginForm.Properties.Resources.if_Gnome_System_Software_Update_48_55454;
            this.btnUpdate.Location = new System.Drawing.Point(143, 23);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnUpdate.Size = new System.Drawing.Size(52, 52);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(512, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 30;
            this.label8.Text = "Print";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(407, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 29;
            this.label7.Text = "Export Excel";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::LoginForm.Properties.Resources.if_print_173079;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.Location = new System.Drawing.Point(503, 23);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.button5.Size = new System.Drawing.Size(52, 52);
            this.button5.TabIndex = 28;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.Location = new System.Drawing.Point(418, 22);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExcel.TabIndex = 27;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Refresh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "New ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Create New Vers.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Delete";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnRefreshList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshList.Image = global::LoginForm.Properties.Resources.icons8_Refresh_32;
            this.btnRefreshList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshList.Location = new System.Drawing.Point(14, 23);
            this.btnRefreshList.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnRefreshList.Size = new System.Drawing.Size(52, 52);
            this.btnRefreshList.TabIndex = 14;
            this.btnRefreshList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefreshList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // btnNewQuotation
            // 
            this.btnNewQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnNewQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnNewQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewQuotation.Image = global::LoginForm.Properties.Resources.icons8_Plus_32;
            this.btnNewQuotation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewQuotation.Location = new System.Drawing.Point(75, 23);
            this.btnNewQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewQuotation.Name = "btnNewQuotation";
            this.btnNewQuotation.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnNewQuotation.Size = new System.Drawing.Size(52, 52);
            this.btnNewQuotation.TabIndex = 1;
            this.btnNewQuotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewQuotation.UseVisualStyleBackColor = true;
            this.btnNewQuotation.Click += new System.EventHandler(this.btnNewQuotation_Click);
            // 
            // btnModifyQuotation
            // 
            this.btnModifyQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnModifyQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnModifyQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyQuotation.Image = global::LoginForm.Properties.Resources.icons8_Edit_Property_32;
            this.btnModifyQuotation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModifyQuotation.Location = new System.Drawing.Point(232, 23);
            this.btnModifyQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnModifyQuotation.Name = "btnModifyQuotation";
            this.btnModifyQuotation.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnModifyQuotation.Size = new System.Drawing.Size(52, 52);
            this.btnModifyQuotation.TabIndex = 16;
            this.btnModifyQuotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModifyQuotation.UseVisualStyleBackColor = true;
            this.btnModifyQuotation.Click += new System.EventHandler(this.btnModifyQuotation_Click);
            // 
            // btnDeleteQuotation
            // 
            this.btnDeleteQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnDeleteQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnDeleteQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteQuotation.Image = global::LoginForm.Properties.Resources.if_minus_1645995;
            this.btnDeleteQuotation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteQuotation.Location = new System.Drawing.Point(327, 22);
            this.btnDeleteQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteQuotation.Name = "btnDeleteQuotation";
            this.btnDeleteQuotation.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDeleteQuotation.Size = new System.Drawing.Size(52, 52);
            this.btnDeleteQuotation.TabIndex = 17;
            this.btnDeleteQuotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteQuotation.UseVisualStyleBackColor = true;
            this.btnDeleteQuotation.Click += new System.EventHandler(this.btnDeleteQuotation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Location = new System.Drawing.Point(12, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 112);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Start Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(83, 48);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(119, 21);
            this.dtpToDate.TabIndex = 18;
            this.dtpToDate.Value = new System.DateTime(2030, 8, 9, 14, 42, 0, 0);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(83, 15);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(119, 21);
            this.dtpFromDate.TabIndex = 19;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // FormQuotationMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1370, 696);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "FormQuotationMain";
            this.Text = "Quotation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormQuotationMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotation)).EndInit();
            this.gridRightClick.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgQuotation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteQuotation;
        private System.Windows.Forms.Button btnModifyQuotation;
        private System.Windows.Forms.Button btnNewQuotation;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.CheckBox chcAllQuots;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.CheckBox chcCustStockNumber;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearchStockNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ContextMenuStrip gridRightClick;
        private System.Windows.Forms.ToolStripMenuItem dELETEQUOTATIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUOTATIONINFOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUOTATIONPRINTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dISCONTINUEDUSERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOPYQUOTATIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mODIFYQUOTATIONToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem uPDATEQUOTATIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uNDODELETEQUOTATIONToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rep_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rep2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderID;
        private System.Windows.Forms.ToolStripMenuItem cREATESALEORDERToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}