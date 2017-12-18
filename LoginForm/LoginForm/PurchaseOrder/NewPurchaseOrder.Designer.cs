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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.dgPurchase = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.customerAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SLC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationNos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hazardous = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Calibration = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SaleOrderNature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AdressTitle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UPIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerAddressBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order Number Beginning";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(12, 40);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(120, 20);
            this.txtOrderNumber.TabIndex = 2;
            // 
            // dgPurchase
            // 
            this.dgPurchase.AllowUserToAddRows = false;
            this.dgPurchase.AllowUserToDeleteRows = false;
            this.dgPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLC,
            this.c_name,
            this.QuotationNos,
            this.SaleOrderNo,
            this.ItemCode,
            this.ItemDescription,
            this.UnitOfMeasure,
            this.Quantity,
            this.Hazardous,
            this.Calibration,
            this.SaleOrderNature,
            this.AddressType,
            this.AdressTitle,
            this.UPIME,
            this.Total});
            this.dgPurchase.Location = new System.Drawing.Point(12, 66);
            this.dgPurchase.Name = "dgPurchase";
            this.dgPurchase.Size = new System.Drawing.Size(1320, 556);
            this.dgPurchase.TabIndex = 10;
            this.dgPurchase.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgPurchase_DataError);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1257, 628);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 42);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(913, 628);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(166, 42);
            this.btnExcel.TabIndex = 12;
            this.btnExcel.Text = "Export to Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(1085, 628);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(166, 42);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Create an Order That is Chosen";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // customerAddressBindingSource
            // 
            this.customerAddressBindingSource.DataSource = typeof(LoginForm.DataSet.CustomerAddress);
            // 
            // SLC
            // 
            this.SLC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SLC.HeaderText = "SLC";
            this.SLC.Name = "SLC";
            this.SLC.Width = 33;
            // 
            // c_name
            // 
            this.c_name.HeaderText = "Customer Name";
            this.c_name.Name = "c_name";
            // 
            // QuotationNos
            // 
            this.QuotationNos.HeaderText = "Quotation No";
            this.QuotationNos.Name = "QuotationNos";
            // 
            // SaleOrderNo
            // 
            this.SaleOrderNo.HeaderText = "Sale No";
            this.SaleOrderNo.Name = "SaleOrderNo";
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            // 
            // ItemDescription
            // 
            this.ItemDescription.HeaderText = "Description";
            this.ItemDescription.Name = "ItemDescription";
            // 
            // UnitOfMeasure
            // 
            this.UnitOfMeasure.HeaderText = "UnitOfMeasure";
            this.UnitOfMeasure.Name = "UnitOfMeasure";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "QTY";
            this.Quantity.Name = "Quantity";
            // 
            // Hazardous
            // 
            this.Hazardous.HeaderText = "HZ";
            this.Hazardous.Name = "Hazardous";
            // 
            // Calibration
            // 
            this.Calibration.HeaderText = "CAL";
            this.Calibration.Name = "Calibration";
            // 
            // SaleOrderNature
            // 
            this.SaleOrderNature.HeaderText = "Nature";
            this.SaleOrderNature.Name = "SaleOrderNature";
            this.SaleOrderNature.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SaleOrderNature.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AddressType
            // 
            this.AddressType.HeaderText = "Bill To";
            this.AddressType.Items.AddRange(new object[] {
            "IME GENERAL COMPONENTS",
            "3RD PARTY"});
            this.AddressType.Name = "AddressType";
            this.AddressType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AdressTitle
            // 
            this.AdressTitle.HeaderText = "Ship To";
            this.AdressTitle.Items.AddRange(new object[] {
            "IME GENERAL COMPONENTS",
            "3RD PARTY"});
            this.AdressTitle.Name = "AdressTitle";
            // 
            // UPIME
            // 
            this.UPIME.HeaderText = "UPIME";
            this.UPIME.Name = "UPIME";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // NewPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 682);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgPurchase);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.label1);
            this.Name = "NewPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewPurchaseOrder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewPurchaseOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerAddressBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ıtemDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationNos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hazardous;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Calibration;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNature;
        private System.Windows.Forms.DataGridViewComboBoxColumn AddressType;
        private System.Windows.Forms.DataGridViewComboBoxColumn AdressTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.BindingSource customerAddressBindingSource;
    }
}