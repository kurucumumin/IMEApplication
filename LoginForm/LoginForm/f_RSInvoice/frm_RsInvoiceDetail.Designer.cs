namespace LoginForm.f_RSInvoice
{
    partial class frm_RsInvoiceDetail
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgRsInvoiceItems = new System.Windows.Forms.DataGridView();
            this.dgPurchaseOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPurchaseOrderItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBillingItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSalesUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGoodsValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCCCNNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCountryofOrigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgArticleDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDeliveryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDeliveryItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPurchaseOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDeleted = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtShippingCondition = new System.Windows.Forms.TextBox();
            this.txtShipmentReference = new System.Windows.Forms.TextBox();
            this.txtSupplyingECCompany = new System.Windows.Forms.TextBox();
            this.txtAirwayBillNumber = new System.Windows.Forms.TextBox();
            this.txtCustomerReference = new System.Windows.Forms.TextBox();
            this.txtBillingDocumentReference = new System.Windows.Forms.TextBox();
            this.txtBillingDocumentDate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtInvoiceNettValue = new System.Windows.Forms.TextBox();
            this.txtInvoiceGoodsValue = new System.Windows.Forms.TextBox();
            this.txtSurcharge = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtInvoiceTaxValue = new System.Windows.Forms.TextBox();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.bgw_RsInvoiceMaster = new System.ComponentModel.BackgroundWorker();
            this.bgw_RsInvoiceDetail = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRsInvoiceItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgRsInvoiceItems, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 575);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgRsInvoiceItems
            // 
            this.dgRsInvoiceItems.AllowUserToAddRows = false;
            this.dgRsInvoiceItems.AllowUserToDeleteRows = false;
            this.dgRsInvoiceItems.AllowUserToOrderColumns = true;
            this.dgRsInvoiceItems.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgRsInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRsInvoiceItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgPurchaseOrderNumber,
            this.dgPurchaseOrderItemNumber,
            this.dgProductNumber,
            this.dgBillingItemNumber,
            this.dgQuantity,
            this.dgSalesUnit,
            this.dgDiscount,
            this.dgGoodsValue,
            this.dgAmount,
            this.dgCCCNNO,
            this.dgCountryofOrigin,
            this.dgArticleDescription,
            this.dgDeliveryNumber,
            this.dgDeliveryItemNumber,
            this.dgPurchaseOrderID,
            this.dgTax});
            this.dgRsInvoiceItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRsInvoiceItems.Location = new System.Drawing.Point(6, 168);
            this.dgRsInvoiceItems.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgRsInvoiceItems.Name = "dgRsInvoiceItems";
            this.dgRsInvoiceItems.ReadOnly = true;
            this.dgRsInvoiceItems.RowTemplate.Height = 24;
            this.dgRsInvoiceItems.Size = new System.Drawing.Size(962, 239);
            this.dgRsInvoiceItems.TabIndex = 0;
            // 
            // dgPurchaseOrderNumber
            // 
            this.dgPurchaseOrderNumber.HeaderText = "Purchase Order Number";
            this.dgPurchaseOrderNumber.Name = "dgPurchaseOrderNumber";
            this.dgPurchaseOrderNumber.ReadOnly = true;
            this.dgPurchaseOrderNumber.Width = 138;
            // 
            // dgPurchaseOrderItemNumber
            // 
            this.dgPurchaseOrderItemNumber.HeaderText = "Purchase Order Item Number";
            this.dgPurchaseOrderItemNumber.Name = "dgPurchaseOrderItemNumber";
            this.dgPurchaseOrderItemNumber.ReadOnly = true;
            this.dgPurchaseOrderItemNumber.Width = 81;
            // 
            // dgProductNumber
            // 
            this.dgProductNumber.HeaderText = "Product Number";
            this.dgProductNumber.Name = "dgProductNumber";
            this.dgProductNumber.ReadOnly = true;
            this.dgProductNumber.Width = 77;
            // 
            // dgBillingItemNumber
            // 
            this.dgBillingItemNumber.HeaderText = "Billing Item Number";
            this.dgBillingItemNumber.Name = "dgBillingItemNumber";
            this.dgBillingItemNumber.ReadOnly = true;
            this.dgBillingItemNumber.Width = 76;
            // 
            // dgQuantity
            // 
            this.dgQuantity.HeaderText = "Quantity";
            this.dgQuantity.Name = "dgQuantity";
            this.dgQuantity.ReadOnly = true;
            this.dgQuantity.Width = 61;
            // 
            // dgSalesUnit
            // 
            this.dgSalesUnit.HeaderText = "Sales Unit";
            this.dgSalesUnit.Name = "dgSalesUnit";
            this.dgSalesUnit.ReadOnly = true;
            this.dgSalesUnit.Width = 68;
            // 
            // dgDiscount
            // 
            this.dgDiscount.HeaderText = "Discount";
            this.dgDiscount.Name = "dgDiscount";
            this.dgDiscount.ReadOnly = true;
            this.dgDiscount.Width = 68;
            // 
            // dgGoodsValue
            // 
            this.dgGoodsValue.HeaderText = "Goods Value";
            this.dgGoodsValue.Name = "dgGoodsValue";
            this.dgGoodsValue.ReadOnly = true;
            this.dgGoodsValue.Width = 86;
            // 
            // dgAmount
            // 
            this.dgAmount.HeaderText = "Amount";
            this.dgAmount.Name = "dgAmount";
            this.dgAmount.ReadOnly = true;
            this.dgAmount.Width = 57;
            // 
            // dgCCCNNO
            // 
            this.dgCCCNNO.HeaderText = "CCCNNO";
            this.dgCCCNNO.Name = "dgCCCNNO";
            this.dgCCCNNO.ReadOnly = true;
            this.dgCCCNNO.Width = 68;
            // 
            // dgCountryofOrigin
            // 
            this.dgCountryofOrigin.HeaderText = "Country of Origin";
            this.dgCountryofOrigin.Name = "dgCountryofOrigin";
            this.dgCountryofOrigin.ReadOnly = true;
            this.dgCountryofOrigin.Width = 68;
            // 
            // dgArticleDescription
            // 
            this.dgArticleDescription.HeaderText = "Article Description";
            this.dgArticleDescription.Name = "dgArticleDescription";
            this.dgArticleDescription.ReadOnly = true;
            this.dgArticleDescription.Width = 124;
            // 
            // dgDeliveryNumber
            // 
            this.dgDeliveryNumber.HeaderText = "Delivery Number";
            this.dgDeliveryNumber.Name = "dgDeliveryNumber";
            this.dgDeliveryNumber.ReadOnly = true;
            this.dgDeliveryNumber.Width = 85;
            // 
            // dgDeliveryItemNumber
            // 
            this.dgDeliveryItemNumber.HeaderText = "Delivery Item Number";
            this.dgDeliveryItemNumber.Name = "dgDeliveryItemNumber";
            this.dgDeliveryItemNumber.ReadOnly = true;
            this.dgDeliveryItemNumber.Width = 86;
            // 
            // dgPurchaseOrderID
            // 
            this.dgPurchaseOrderID.HeaderText = "Purchase Order ID";
            this.dgPurchaseOrderID.Name = "dgPurchaseOrderID";
            this.dgPurchaseOrderID.ReadOnly = true;
            this.dgPurchaseOrderID.Visible = false;
            // 
            // dgTax
            // 
            this.dgTax.HeaderText = "Tax";
            this.dgTax.Name = "dgTax";
            this.dgTax.ReadOnly = true;
            this.dgTax.Width = 59;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDeleted);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.txtShippingCondition);
            this.panel1.Controls.Add(this.txtShipmentReference);
            this.panel1.Controls.Add(this.txtSupplyingECCompany);
            this.panel1.Controls.Add(this.txtAirwayBillNumber);
            this.panel1.Controls.Add(this.txtCustomerReference);
            this.panel1.Controls.Add(this.txtBillingDocumentReference);
            this.panel1.Controls.Add(this.txtBillingDocumentDate);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 158);
            this.panel1.TabIndex = 1;
            // 
            // txtDeleted
            // 
            this.txtDeleted.Location = new System.Drawing.Point(867, 65);
            this.txtDeleted.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDeleted.Name = "txtDeleted";
            this.txtDeleted.ReadOnly = true;
            this.txtDeleted.Size = new System.Drawing.Size(76, 20);
            this.txtDeleted.TabIndex = 22;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(867, 25);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(76, 20);
            this.txtStatus.TabIndex = 21;
            // 
            // txtShippingCondition
            // 
            this.txtShippingCondition.Location = new System.Drawing.Point(680, 65);
            this.txtShippingCondition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtShippingCondition.Name = "txtShippingCondition";
            this.txtShippingCondition.ReadOnly = true;
            this.txtShippingCondition.Size = new System.Drawing.Size(123, 20);
            this.txtShippingCondition.TabIndex = 20;
            // 
            // txtShipmentReference
            // 
            this.txtShipmentReference.Location = new System.Drawing.Point(680, 25);
            this.txtShipmentReference.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtShipmentReference.Name = "txtShipmentReference";
            this.txtShipmentReference.ReadOnly = true;
            this.txtShipmentReference.Size = new System.Drawing.Size(123, 20);
            this.txtShipmentReference.TabIndex = 19;
            // 
            // txtSupplyingECCompany
            // 
            this.txtSupplyingECCompany.Location = new System.Drawing.Point(425, 65);
            this.txtSupplyingECCompany.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSupplyingECCompany.Name = "txtSupplyingECCompany";
            this.txtSupplyingECCompany.ReadOnly = true;
            this.txtSupplyingECCompany.Size = new System.Drawing.Size(123, 20);
            this.txtSupplyingECCompany.TabIndex = 18;
            // 
            // txtAirwayBillNumber
            // 
            this.txtAirwayBillNumber.Location = new System.Drawing.Point(425, 25);
            this.txtAirwayBillNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAirwayBillNumber.Name = "txtAirwayBillNumber";
            this.txtAirwayBillNumber.ReadOnly = true;
            this.txtAirwayBillNumber.Size = new System.Drawing.Size(123, 20);
            this.txtAirwayBillNumber.TabIndex = 17;
            // 
            // txtCustomerReference
            // 
            this.txtCustomerReference.Location = new System.Drawing.Point(160, 102);
            this.txtCustomerReference.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomerReference.Name = "txtCustomerReference";
            this.txtCustomerReference.ReadOnly = true;
            this.txtCustomerReference.Size = new System.Drawing.Size(123, 20);
            this.txtCustomerReference.TabIndex = 16;
            // 
            // txtBillingDocumentReference
            // 
            this.txtBillingDocumentReference.Location = new System.Drawing.Point(160, 65);
            this.txtBillingDocumentReference.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBillingDocumentReference.Name = "txtBillingDocumentReference";
            this.txtBillingDocumentReference.ReadOnly = true;
            this.txtBillingDocumentReference.Size = new System.Drawing.Size(123, 20);
            this.txtBillingDocumentReference.TabIndex = 15;
            // 
            // txtBillingDocumentDate
            // 
            this.txtBillingDocumentDate.Location = new System.Drawing.Point(160, 25);
            this.txtBillingDocumentDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBillingDocumentDate.Name = "txtBillingDocumentDate";
            this.txtBillingDocumentDate.ReadOnly = true;
            this.txtBillingDocumentDate.Size = new System.Drawing.Size(123, 20);
            this.txtBillingDocumentDate.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(820, 67);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Deleted :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(820, 28);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Status :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Airway Bill Number :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Customer Reference :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Supplying EC Company :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Billing Document Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(566, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Shipping Condition :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Billing Document Reference :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(566, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shipment Reference :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtInvoiceNettValue);
            this.panel2.Controls.Add(this.txtInvoiceGoodsValue);
            this.panel2.Controls.Add(this.txtSurcharge);
            this.panel2.Controls.Add(this.txtDiscount);
            this.panel2.Controls.Add(this.txtInvoiceTaxValue);
            this.panel2.Controls.Add(this.txtCurrency);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 415);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(970, 158);
            this.panel2.TabIndex = 2;
            // 
            // txtInvoiceNettValue
            // 
            this.txtInvoiceNettValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceNettValue.Location = new System.Drawing.Point(530, 115);
            this.txtInvoiceNettValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInvoiceNettValue.Name = "txtInvoiceNettValue";
            this.txtInvoiceNettValue.ReadOnly = true;
            this.txtInvoiceNettValue.Size = new System.Drawing.Size(123, 20);
            this.txtInvoiceNettValue.TabIndex = 28;
            // 
            // txtInvoiceGoodsValue
            // 
            this.txtInvoiceGoodsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceGoodsValue.Location = new System.Drawing.Point(530, 81);
            this.txtInvoiceGoodsValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInvoiceGoodsValue.Name = "txtInvoiceGoodsValue";
            this.txtInvoiceGoodsValue.ReadOnly = true;
            this.txtInvoiceGoodsValue.Size = new System.Drawing.Size(123, 20);
            this.txtInvoiceGoodsValue.TabIndex = 27;
            // 
            // txtSurcharge
            // 
            this.txtSurcharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSurcharge.Location = new System.Drawing.Point(797, 47);
            this.txtSurcharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSurcharge.Name = "txtSurcharge";
            this.txtSurcharge.ReadOnly = true;
            this.txtSurcharge.Size = new System.Drawing.Size(123, 20);
            this.txtSurcharge.TabIndex = 26;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscount.Location = new System.Drawing.Point(797, 14);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(123, 20);
            this.txtDiscount.TabIndex = 25;
            // 
            // txtInvoiceTaxValue
            // 
            this.txtInvoiceTaxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceTaxValue.Location = new System.Drawing.Point(530, 47);
            this.txtInvoiceTaxValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInvoiceTaxValue.Name = "txtInvoiceTaxValue";
            this.txtInvoiceTaxValue.ReadOnly = true;
            this.txtInvoiceTaxValue.Size = new System.Drawing.Size(123, 20);
            this.txtInvoiceTaxValue.TabIndex = 24;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrency.Location = new System.Drawing.Point(530, 14);
            this.txtCurrency.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(123, 20);
            this.txtCurrency.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(423, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Invoice Tax Value :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(423, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Invoice Goods Value :";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(423, 117);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Invoice Nett Value :";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(423, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Currency :";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(726, 16);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Discount :";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(726, 50);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Surcharge :";
            // 
            // bgw_RsInvoiceMaster
            // 
            this.bgw_RsInvoiceMaster.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_RsInvoiceMaster_DoWork);
            this.bgw_RsInvoiceMaster.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RsInvoiceMaster_RunWorkerCompleted);
            // 
            // bgw_RsInvoiceDetail
            // 
            this.bgw_RsInvoiceDetail.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_RsInvoiceDetail_DoWork);
            this.bgw_RsInvoiceDetail.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RsInvoiceDetail_RunWorkerCompleted);
            // 
            // frm_RsInvoiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(974, 575);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(990, 614);
            this.Name = "frm_RsInvoiceDetail";
            this.Text = "Rs Invoice Details";
            this.Load += new System.EventHandler(this.frm_RsInvoiceDetail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRsInvoiceItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgRsInvoiceItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeleted;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtShippingCondition;
        private System.Windows.Forms.TextBox txtShipmentReference;
        private System.Windows.Forms.TextBox txtSupplyingECCompany;
        private System.Windows.Forms.TextBox txtAirwayBillNumber;
        private System.Windows.Forms.TextBox txtCustomerReference;
        private System.Windows.Forms.TextBox txtBillingDocumentReference;
        private System.Windows.Forms.TextBox txtBillingDocumentDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoiceNettValue;
        private System.Windows.Forms.TextBox txtInvoiceGoodsValue;
        private System.Windows.Forms.TextBox txtSurcharge;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtInvoiceTaxValue;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.ComponentModel.BackgroundWorker bgw_RsInvoiceMaster;
        private System.ComponentModel.BackgroundWorker bgw_RsInvoiceDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPurchaseOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPurchaseOrderItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBillingItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSalesUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGoodsValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCCCNNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCountryofOrigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgArticleDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDeliveryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDeliveryItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPurchaseOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTax;
    }
}