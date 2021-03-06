﻿namespace LoginForm
{
    partial class frmQuotOrdersDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label13 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgQuotList = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerSubCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RSCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalQuot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AEDTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AEDTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AEDTotalLandingCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GBPRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GBPTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GBPTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GBPTotalLandingCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Margin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Markup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Online = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RSInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RSInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMEInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMEInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RSCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCCNNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateFirst = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLandingCostMarkup = new System.Windows.Forms.Label();
            this.lblLandingCostMargin = new System.Windows.Forms.Label();
            this.lblGbpLandingCost = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCostMarkup = new System.Windows.Forms.Label();
            this.lblCostMargin = new System.Windows.Forms.Label();
            this.lblGbpCost = new System.Windows.Forms.Label();
            this.lblGbpTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotList)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1209, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 351;
            this.label13.Text = "Export Excel";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.Location = new System.Drawing.Point(1214, 6);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExcel.TabIndex = 350;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.Location = new System.Drawing.Point(1284, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 52);
            this.btnSearch.TabIndex = 349;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label41.Location = new System.Drawing.Point(1289, 61);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 13);
            this.label41.TabIndex = 348;
            this.label41.Text = "Search";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgQuotList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1348, 626);
            this.groupBox1.TabIndex = 352;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quotation List";
            // 
            // dgQuotList
            // 
            this.dgQuotList.AllowUserToAddRows = false;
            this.dgQuotList.AllowUserToDeleteRows = false;
            this.dgQuotList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgQuotList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Deleted,
            this.QuotationNo,
            this.QuotationDate,
            this.CustomerCode,
            this.CustomerName,
            this.CustomerCategory,
            this.CustomerSubCategory,
            this.RSCode,
            this.Qty,
            this.UP,
            this.TotalQuot,
            this.CurrName,
            this.Rate,
            this.AEDTotal,
            this.AEDTotalCost,
            this.AEDTotalLandingCost,
            this.GBPRate,
            this.GBPTotal,
            this.GBPTotalCost,
            this.GBPTotalLandingCost,
            this.Margin,
            this.Markup,
            this.Status,
            this.RFQ,
            this.Online,
            this.SaleOrderNo,
            this.SaleOrderDate,
            this.LPO,
            this.PurchaseOrderNo,
            this.RSInvoiceNo,
            this.RSInvoiceDate,
            this.IMEInvoiceNo,
            this.IMEInvoiceDate,
            this.Manufacturer,
            this.MPN,
            this.RSCategory,
            this.CCCNNo,
            this.RepName,
            this.DeliveryType});
            this.dgQuotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgQuotList.Location = new System.Drawing.Point(3, 16);
            this.dgQuotList.MultiSelect = false;
            this.dgQuotList.Name = "dgQuotList";
            this.dgQuotList.ReadOnly = true;
            this.dgQuotList.Size = new System.Drawing.Size(1342, 607);
            this.dgQuotList.TabIndex = 0;
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 46;
            // 
            // Deleted
            // 
            this.Deleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Deleted.HeaderText = "D";
            this.Deleted.Name = "Deleted";
            this.Deleted.ReadOnly = true;
            this.Deleted.Width = 40;
            // 
            // QuotationNo
            // 
            this.QuotationNo.HeaderText = "Quot No";
            this.QuotationNo.Name = "QuotationNo";
            this.QuotationNo.ReadOnly = true;
            // 
            // QuotationDate
            // 
            this.QuotationDate.HeaderText = "Quot Date";
            this.QuotationDate.Name = "QuotationDate";
            this.QuotationDate.ReadOnly = true;
            // 
            // CustomerCode
            // 
            dataGridViewCellStyle3.Format = "N2";
            this.CustomerCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.CustomerCode.HeaderText = "Cust Code";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // CustomerCategory
            // 
            dataGridViewCellStyle4.Format = "N2";
            this.CustomerCategory.DefaultCellStyle = dataGridViewCellStyle4;
            this.CustomerCategory.HeaderText = "Cust. Category";
            this.CustomerCategory.Name = "CustomerCategory";
            this.CustomerCategory.ReadOnly = true;
            // 
            // CustomerSubCategory
            // 
            this.CustomerSubCategory.HeaderText = "Cust. Sub. Cat.";
            this.CustomerSubCategory.Name = "CustomerSubCategory";
            this.CustomerSubCategory.ReadOnly = true;
            // 
            // RSCode
            // 
            this.RSCode.HeaderText = "RS Code";
            this.RSCode.Name = "RSCode";
            this.RSCode.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // UP
            // 
            this.UP.HeaderText = "U/P";
            this.UP.Name = "UP";
            this.UP.ReadOnly = true;
            // 
            // TotalQuot
            // 
            this.TotalQuot.HeaderText = "Total Quot";
            this.TotalQuot.Name = "TotalQuot";
            this.TotalQuot.ReadOnly = true;
            // 
            // CurrName
            // 
            this.CurrName.HeaderText = "Curr Name";
            this.CurrName.Name = "CurrName";
            this.CurrName.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // AEDTotal
            // 
            this.AEDTotal.HeaderText = "AED Total";
            this.AEDTotal.Name = "AEDTotal";
            this.AEDTotal.ReadOnly = true;
            // 
            // AEDTotalCost
            // 
            this.AEDTotalCost.HeaderText = "AED Total  Cost";
            this.AEDTotalCost.Name = "AEDTotalCost";
            this.AEDTotalCost.ReadOnly = true;
            // 
            // AEDTotalLandingCost
            // 
            this.AEDTotalLandingCost.HeaderText = "AED Landing Cost";
            this.AEDTotalLandingCost.Name = "AEDTotalLandingCost";
            this.AEDTotalLandingCost.ReadOnly = true;
            // 
            // GBPRate
            // 
            this.GBPRate.HeaderText = "GBP Rate";
            this.GBPRate.Name = "GBPRate";
            this.GBPRate.ReadOnly = true;
            // 
            // GBPTotal
            // 
            this.GBPTotal.HeaderText = "GBP Total";
            this.GBPTotal.Name = "GBPTotal";
            this.GBPTotal.ReadOnly = true;
            // 
            // GBPTotalCost
            // 
            this.GBPTotalCost.HeaderText = "GBP Total Cost";
            this.GBPTotalCost.Name = "GBPTotalCost";
            this.GBPTotalCost.ReadOnly = true;
            // 
            // GBPTotalLandingCost
            // 
            this.GBPTotalLandingCost.HeaderText = "GBP Landing Cost";
            this.GBPTotalLandingCost.Name = "GBPTotalLandingCost";
            this.GBPTotalLandingCost.ReadOnly = true;
            // 
            // Margin
            // 
            this.Margin.HeaderText = "Margin";
            this.Margin.Name = "Margin";
            this.Margin.ReadOnly = true;
            // 
            // Markup
            // 
            this.Markup.HeaderText = "Markup";
            this.Markup.Name = "Markup";
            this.Markup.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // RFQ
            // 
            this.RFQ.HeaderText = "RFQ";
            this.RFQ.Name = "RFQ";
            this.RFQ.ReadOnly = true;
            // 
            // Online
            // 
            this.Online.HeaderText = "Onl";
            this.Online.Name = "Online";
            this.Online.ReadOnly = true;
            // 
            // SaleOrderNo
            // 
            this.SaleOrderNo.HeaderText = "Sales Order No";
            this.SaleOrderNo.Name = "SaleOrderNo";
            this.SaleOrderNo.ReadOnly = true;
            // 
            // SaleOrderDate
            // 
            this.SaleOrderDate.HeaderText = "Sales Order Date";
            this.SaleOrderDate.Name = "SaleOrderDate";
            this.SaleOrderDate.ReadOnly = true;
            // 
            // LPO
            // 
            this.LPO.HeaderText = "Customer LPO";
            this.LPO.Name = "LPO";
            this.LPO.ReadOnly = true;
            // 
            // PurchaseOrderNo
            // 
            this.PurchaseOrderNo.HeaderText = "RS Purchase";
            this.PurchaseOrderNo.Name = "PurchaseOrderNo";
            this.PurchaseOrderNo.ReadOnly = true;
            // 
            // RSInvoiceNo
            // 
            this.RSInvoiceNo.HeaderText = "RS Invoice No";
            this.RSInvoiceNo.Name = "RSInvoiceNo";
            this.RSInvoiceNo.ReadOnly = true;
            // 
            // RSInvoiceDate
            // 
            this.RSInvoiceDate.HeaderText = "RS Invoice Date";
            this.RSInvoiceDate.Name = "RSInvoiceDate";
            this.RSInvoiceDate.ReadOnly = true;
            // 
            // IMEInvoiceNo
            // 
            this.IMEInvoiceNo.HeaderText = "IME Invoice No";
            this.IMEInvoiceNo.Name = "IMEInvoiceNo";
            this.IMEInvoiceNo.ReadOnly = true;
            // 
            // IMEInvoiceDate
            // 
            this.IMEInvoiceDate.HeaderText = "IME Invoice Date";
            this.IMEInvoiceDate.Name = "IMEInvoiceDate";
            this.IMEInvoiceDate.ReadOnly = true;
            // 
            // Manufacturer
            // 
            this.Manufacturer.HeaderText = "Manufacturer";
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            // 
            // MPN
            // 
            this.MPN.HeaderText = "MPN";
            this.MPN.Name = "MPN";
            this.MPN.ReadOnly = true;
            // 
            // RSCategory
            // 
            this.RSCategory.HeaderText = "RS Category";
            this.RSCategory.Name = "RSCategory";
            this.RSCategory.ReadOnly = true;
            // 
            // CCCNNo
            // 
            this.CCCNNo.HeaderText = "CCCNNO";
            this.CCCNNo.Name = "CCCNNo";
            this.CCCNNo.ReadOnly = true;
            // 
            // RepName
            // 
            this.RepName.HeaderText = "Rep Name";
            this.RepName.Name = "RepName";
            this.RepName.ReadOnly = true;
            // 
            // DeliveryType
            // 
            this.DeliveryType.HeaderText = "Delivery Type";
            this.DeliveryType.Name = "DeliveryType";
            this.DeliveryType.ReadOnly = true;
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(74, 52);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 20);
            this.dateEnd.TabIndex = 359;
            // 
            // dateFirst
            // 
            this.dateFirst.Location = new System.Drawing.Point(74, 12);
            this.dateFirst.Name = "dateFirst";
            this.dateFirst.Size = new System.Drawing.Size(200, 20);
            this.dateFirst.TabIndex = 358;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 354;
            this.label7.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 353;
            this.label2.Text = "Start Date";
            // 
            // lblLandingCostMarkup
            // 
            this.lblLandingCostMarkup.AutoSize = true;
            this.lblLandingCostMarkup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLandingCostMarkup.Location = new System.Drawing.Point(717, 50);
            this.lblLandingCostMarkup.Name = "lblLandingCostMarkup";
            this.lblLandingCostMarkup.Size = new System.Drawing.Size(15, 15);
            this.lblLandingCostMarkup.TabIndex = 416;
            this.lblLandingCostMarkup.Text = "0";
            // 
            // lblLandingCostMargin
            // 
            this.lblLandingCostMargin.AutoSize = true;
            this.lblLandingCostMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLandingCostMargin.Location = new System.Drawing.Point(642, 50);
            this.lblLandingCostMargin.Name = "lblLandingCostMargin";
            this.lblLandingCostMargin.Size = new System.Drawing.Size(15, 15);
            this.lblLandingCostMargin.TabIndex = 415;
            this.lblLandingCostMargin.Text = "0";
            // 
            // lblGbpLandingCost
            // 
            this.lblGbpLandingCost.AutoSize = true;
            this.lblGbpLandingCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGbpLandingCost.Location = new System.Drawing.Point(552, 50);
            this.lblGbpLandingCost.Name = "lblGbpLandingCost";
            this.lblGbpLandingCost.Size = new System.Drawing.Size(15, 15);
            this.lblGbpLandingCost.TabIndex = 414;
            this.lblGbpLandingCost.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(700, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 15);
            this.label15.TabIndex = 413;
            this.label15.Text = "MARKUP";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(626, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 15);
            this.label14.TabIndex = 412;
            this.label14.Text = "MARGIN";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(423, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 15);
            this.label12.TabIndex = 411;
            this.label12.Text = "SALES (AED)      :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(423, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 15);
            this.label9.TabIndex = 410;
            this.label9.Text = "LANDING (AED)  :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(423, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 15);
            this.label6.TabIndex = 409;
            this.label6.Text = "COST (AED)        :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(549, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 408;
            this.label4.Text = "TOTAL";
            // 
            // lblCostMarkup
            // 
            this.lblCostMarkup.AutoSize = true;
            this.lblCostMarkup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCostMarkup.Location = new System.Drawing.Point(717, 25);
            this.lblCostMarkup.Name = "lblCostMarkup";
            this.lblCostMarkup.Size = new System.Drawing.Size(15, 15);
            this.lblCostMarkup.TabIndex = 407;
            this.lblCostMarkup.Text = "0";
            // 
            // lblCostMargin
            // 
            this.lblCostMargin.AutoSize = true;
            this.lblCostMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCostMargin.Location = new System.Drawing.Point(642, 25);
            this.lblCostMargin.Name = "lblCostMargin";
            this.lblCostMargin.Size = new System.Drawing.Size(15, 15);
            this.lblCostMargin.TabIndex = 406;
            this.lblCostMargin.Text = "0";
            // 
            // lblGbpCost
            // 
            this.lblGbpCost.AutoSize = true;
            this.lblGbpCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGbpCost.Location = new System.Drawing.Point(552, 25);
            this.lblGbpCost.Name = "lblGbpCost";
            this.lblGbpCost.Size = new System.Drawing.Size(15, 15);
            this.lblGbpCost.TabIndex = 405;
            this.lblGbpCost.Text = "0";
            // 
            // lblGbpTotal
            // 
            this.lblGbpTotal.AutoSize = true;
            this.lblGbpTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblGbpTotal.Location = new System.Drawing.Point(552, 73);
            this.lblGbpTotal.Name = "lblGbpTotal";
            this.lblGbpTotal.Size = new System.Drawing.Size(15, 15);
            this.lblGbpTotal.TabIndex = 404;
            this.lblGbpTotal.Text = "0";
            // 
            // frmQuotOrdersDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 720);
            this.Controls.Add(this.lblLandingCostMarkup);
            this.Controls.Add(this.lblLandingCostMargin);
            this.Controls.Add(this.lblGbpLandingCost);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCostMarkup);
            this.Controls.Add(this.lblCostMargin);
            this.Controls.Add(this.lblGbpCost);
            this.Controls.Add(this.lblGbpTotal);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateFirst);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label41);
            this.MinimizeBox = false;
            this.Name = "frmQuotOrdersDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quottaions vs Orders Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgQuotList;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateFirst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerSubCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn RSCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalQuot;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AEDTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AEDTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn AEDTotalLandingCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn GBPRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn GBPTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn GBPTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn GBPTotalLandingCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Margin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Markup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Online;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RSInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RSInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMEInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMEInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn MPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn RSCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCCNNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryType;
        private System.Windows.Forms.Label lblLandingCostMarkup;
        private System.Windows.Forms.Label lblLandingCostMargin;
        private System.Windows.Forms.Label lblGbpLandingCost;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCostMarkup;
        private System.Windows.Forms.Label lblCostMargin;
        private System.Windows.Forms.Label lblGbpCost;
        private System.Windows.Forms.Label lblGbpTotal;
    }
}