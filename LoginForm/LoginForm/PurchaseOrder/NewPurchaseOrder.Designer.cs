namespace LoginForm.PurchaseOrder
{
    partial class NewPurchaseOrder
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioNotSent = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioSent = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.dgPurchase = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.purchaseOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotationNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleOrderNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ıtemCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleOrderNatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillTo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ShipTo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.frtTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioNotSent);
            this.groupBox1.Controls.Add(this.radioAll);
            this.groupBox1.Controls.Add(this.radioSent);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametrs";
            // 
            // radioNotSent
            // 
            this.radioNotSent.AutoSize = true;
            this.radioNotSent.Location = new System.Drawing.Point(6, 54);
            this.radioNotSent.Name = "radioNotSent";
            this.radioNotSent.Size = new System.Drawing.Size(95, 17);
            this.radioNotSent.TabIndex = 2;
            this.radioNotSent.TabStop = true;
            this.radioNotSent.Text = "Not sent to RS";
            this.radioNotSent.UseVisualStyleBackColor = true;
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(6, 94);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(36, 17);
            this.radioAll.TabIndex = 1;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // radioSent
            // 
            this.radioSent.AutoSize = true;
            this.radioSent.Location = new System.Drawing.Point(6, 19);
            this.radioSent.Name = "radioSent";
            this.radioSent.Size = new System.Drawing.Size(77, 17);
            this.radioSent.TabIndex = 0;
            this.radioSent.TabStop = true;
            this.radioSent.Text = "Sent to RS";
            this.radioSent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order Number Beginning";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(252, 62);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(120, 20);
            this.txtOrderNumber.TabIndex = 2;
            // 
            // dgPurchase
            // 
            this.dgPurchase.AutoGenerateColumns = false;
            this.dgPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIDDataGridViewTextBoxColumn,
            this.quotationNoDataGridViewTextBoxColumn,
            this.saleOrderNoDataGridViewTextBoxColumn,
            this.ıtemCodeDataGridViewTextBoxColumn,
            this.SaleOrderQty,
            this.StoreQty,
            this.sendQtyDataGridViewTextBoxColumn,
            this.saleOrderNatureDataGridViewTextBoxColumn,
            this.BillTo,
            this.ShipTo,
            this.frtTypeDataGridViewTextBoxColumn,
            this.Cost,
            this.TotalPrice});
            this.dgPurchase.DataSource = this.purchaseOrderBindingSource;
            this.dgPurchase.Location = new System.Drawing.Point(12, 133);
            this.dgPurchase.Name = "dgPurchase";
            this.dgPurchase.Size = new System.Drawing.Size(1272, 432);
            this.dgPurchase.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1209, 571);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 42);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(865, 571);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(166, 42);
            this.btnExcel.TabIndex = 12;
            this.btnExcel.Text = "Export to Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(1037, 571);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(166, 42);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Create an Order That is Chosen";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // purchaseOrderBindingSource
            // 
            this.purchaseOrderBindingSource.DataSource = typeof(LoginForm.DataSet.PurchaseOrder);
            // 
            // customerIDDataGridViewTextBoxColumn
            // 
            this.customerIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.HeaderText = "Customer Title";
            this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
            // 
            // quotationNoDataGridViewTextBoxColumn
            // 
            this.quotationNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.quotationNoDataGridViewTextBoxColumn.DataPropertyName = "QuotationNo";
            this.quotationNoDataGridViewTextBoxColumn.HeaderText = "QuotationNo";
            this.quotationNoDataGridViewTextBoxColumn.Name = "quotationNoDataGridViewTextBoxColumn";
            this.quotationNoDataGridViewTextBoxColumn.Width = 92;
            // 
            // saleOrderNoDataGridViewTextBoxColumn
            // 
            this.saleOrderNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.saleOrderNoDataGridViewTextBoxColumn.DataPropertyName = "SaleOrderNo";
            this.saleOrderNoDataGridViewTextBoxColumn.HeaderText = "SaleOrderNo";
            this.saleOrderNoDataGridViewTextBoxColumn.Name = "saleOrderNoDataGridViewTextBoxColumn";
            this.saleOrderNoDataGridViewTextBoxColumn.Width = 93;
            // 
            // ıtemCodeDataGridViewTextBoxColumn
            // 
            this.ıtemCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ıtemCodeDataGridViewTextBoxColumn.DataPropertyName = "ItemCode";
            this.ıtemCodeDataGridViewTextBoxColumn.HeaderText = "ItemCode";
            this.ıtemCodeDataGridViewTextBoxColumn.Name = "ıtemCodeDataGridViewTextBoxColumn";
            this.ıtemCodeDataGridViewTextBoxColumn.Width = 77;
            // 
            // SaleOrderQty
            // 
            this.SaleOrderQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SaleOrderQty.DataPropertyName = "ID";
            this.SaleOrderQty.HeaderText = "Sales Qty";
            this.SaleOrderQty.Name = "SaleOrderQty";
            this.SaleOrderQty.Width = 77;
            // 
            // StoreQty
            // 
            this.StoreQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StoreQty.DataPropertyName = "ID";
            this.StoreQty.HeaderText = "Store Qty";
            this.StoreQty.Name = "StoreQty";
            this.StoreQty.Width = 76;
            // 
            // sendQtyDataGridViewTextBoxColumn
            // 
            this.sendQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sendQtyDataGridViewTextBoxColumn.DataPropertyName = "SendQty";
            this.sendQtyDataGridViewTextBoxColumn.HeaderText = "Send Qty";
            this.sendQtyDataGridViewTextBoxColumn.Name = "sendQtyDataGridViewTextBoxColumn";
            this.sendQtyDataGridViewTextBoxColumn.Width = 76;
            // 
            // saleOrderNatureDataGridViewTextBoxColumn
            // 
            this.saleOrderNatureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.saleOrderNatureDataGridViewTextBoxColumn.DataPropertyName = "SaleOrderNature";
            this.saleOrderNatureDataGridViewTextBoxColumn.HeaderText = "SaleOrderNature";
            this.saleOrderNatureDataGridViewTextBoxColumn.Name = "saleOrderNatureDataGridViewTextBoxColumn";
            this.saleOrderNatureDataGridViewTextBoxColumn.Width = 111;
            // 
            // BillTo
            // 
            this.BillTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BillTo.DataPropertyName = "ID";
            this.BillTo.HeaderText = "Bill To";
            this.BillTo.Name = "BillTo";
            this.BillTo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BillTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BillTo.Width = 61;
            // 
            // ShipTo
            // 
            this.ShipTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ShipTo.DataPropertyName = "ID";
            this.ShipTo.HeaderText = "Ship To";
            this.ShipTo.Name = "ShipTo";
            this.ShipTo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShipTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ShipTo.Width = 69;
            // 
            // frtTypeDataGridViewTextBoxColumn
            // 
            this.frtTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.frtTypeDataGridViewTextBoxColumn.DataPropertyName = "FrtType";
            this.frtTypeDataGridViewTextBoxColumn.HeaderText = "FrtType";
            this.frtTypeDataGridViewTextBoxColumn.Name = "frtTypeDataGridViewTextBoxColumn";
            this.frtTypeDataGridViewTextBoxColumn.Width = 68;
            // 
            // Cost
            // 
            this.Cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cost.DataPropertyName = "ID";
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.Width = 53;
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TotalPrice.DataPropertyName = "ID";
            this.TotalPrice.HeaderText = "Total Price";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Width = 83;
            // 
            // NewPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 614);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgPurchase);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewPurchaseOrder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewPurchaseOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioNotSent;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioSent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.DataGridView dgPurchase;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.BindingSource purchaseOrderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotationNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleOrderNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ıtemCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleOrderNatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn BillTo;
        private System.Windows.Forms.DataGridViewComboBoxColumn ShipTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn frtTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
    }
}