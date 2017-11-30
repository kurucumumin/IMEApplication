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
            this.purchaseOrderDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SLC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ıtemDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepotQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hazardousDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.calibrationDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BillTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderDetailBindingSource)).BeginInit();
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
            this.SLC,
            this.Customer,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.ıtemDescDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.SaleQty,
            this.DepotQty,
            this.dataGridViewTextBoxColumn4,
            this.hazardousDataGridViewCheckBoxColumn,
            this.calibrationDataGridViewCheckBoxColumn,
            this.dataGridViewTextBoxColumn6,
            this.BillTo,
            this.ShipTo,
            this.dataGridViewTextBoxColumn5,
            this.unitPriceDataGridViewTextBoxColumn,
            this.Total});
            this.dgPurchase.DataSource = this.purchaseOrderDetailBindingSource;
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
            // purchaseOrderDetailBindingSource
            // 
            this.purchaseOrderDetailBindingSource.DataSource = typeof(LoginForm.DataSet.PurchaseOrderDetail);
            // 
            // SLC
            // 
            this.SLC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SLC.HeaderText = "SLC";
            this.SLC.Name = "SLC";
            this.SLC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SLC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SLC.Width = 52;
            // 
            // Customer
            // 
            this.Customer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            this.Customer.Width = 76;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SaleOrderNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "SaleOrderNo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 21;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "QuotationNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "QuotationNo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 21;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ItemCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "ItemCode";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 21;
            // 
            // ıtemDescDataGridViewTextBoxColumn
            // 
            this.ıtemDescDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ıtemDescDataGridViewTextBoxColumn.DataPropertyName = "ItemDesc";
            this.ıtemDescDataGridViewTextBoxColumn.HeaderText = "ItemDesc";
            this.ıtemDescDataGridViewTextBoxColumn.Name = "ıtemDescDataGridViewTextBoxColumn";
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            this.unitDataGridViewTextBoxColumn.Width = 51;
            // 
            // SaleQty
            // 
            this.SaleQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SaleQty.HeaderText = "S.O. QTY";
            this.SaleQty.Name = "SaleQty";
            this.SaleQty.Width = 78;
            // 
            // DepotQty
            // 
            this.DepotQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DepotQty.HeaderText = "Depot QTY";
            this.DepotQty.Name = "DepotQty";
            this.DepotQty.Width = 86;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SendQty";
            this.dataGridViewTextBoxColumn4.HeaderText = "SendQty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 73;
            // 
            // hazardousDataGridViewCheckBoxColumn
            // 
            this.hazardousDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.hazardousDataGridViewCheckBoxColumn.DataPropertyName = "Hazardous";
            this.hazardousDataGridViewCheckBoxColumn.HeaderText = "HZ";
            this.hazardousDataGridViewCheckBoxColumn.Name = "hazardousDataGridViewCheckBoxColumn";
            this.hazardousDataGridViewCheckBoxColumn.Width = 28;
            // 
            // calibrationDataGridViewCheckBoxColumn
            // 
            this.calibrationDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.calibrationDataGridViewCheckBoxColumn.DataPropertyName = "Calibration";
            this.calibrationDataGridViewCheckBoxColumn.HeaderText = "CAL";
            this.calibrationDataGridViewCheckBoxColumn.Name = "calibrationDataGridViewCheckBoxColumn";
            this.calibrationDataGridViewCheckBoxColumn.Width = 33;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SaleOrderNature";
            this.dataGridViewTextBoxColumn6.HeaderText = "S.O. NATURE";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BillTo
            // 
            this.BillTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BillTo.HeaderText = "BILL TO";
            this.BillTo.Name = "BillTo";
            this.BillTo.Width = 72;
            // 
            // ShipTo
            // 
            this.ShipTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ShipTo.HeaderText = "SHIP TO";
            this.ShipTo.Name = "ShipTo";
            this.ShipTo.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FrtType";
            this.dataGridViewTextBoxColumn5.HeaderText = "FrtType";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 68;
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            this.unitPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            this.unitPriceDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            this.unitPriceDataGridViewTextBoxColumn.Width = 53;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Total.DataPropertyName = "ID";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.Width = 56;
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
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderDetailBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn quotationNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleOrderNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ıtemCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleOrderNatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frtTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource purchaseOrderDetailBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ıtemDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepotQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hazardousDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn calibrationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}