namespace LoginForm.StockManagement
{
    partial class frmStockReserve
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
            this.FrameTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStockReserveUpdate = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbDecrease = new System.Windows.Forms.RadioButton();
            this.rbIncrease = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgStockReserveList = new System.Windows.Forms.DataGridView();
            this.dgProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSaleOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgValidationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgReserveID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockReserveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FrameTableLayout.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabStockReserveUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.tabSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockReserveList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockReserveBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FrameTableLayout
            // 
            this.FrameTableLayout.ColumnCount = 1;
            this.FrameTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FrameTableLayout.Controls.Add(this.tabControl1, 0, 0);
            this.FrameTableLayout.Controls.Add(this.panel1, 0, 1);
            this.FrameTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrameTableLayout.Location = new System.Drawing.Point(0, 0);
            this.FrameTableLayout.Name = "FrameTableLayout";
            this.FrameTableLayout.RowCount = 2;
            this.FrameTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.FrameTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FrameTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FrameTableLayout.Size = new System.Drawing.Size(971, 719);
            this.FrameTableLayout.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStockReserveUpdate);
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(965, 194);
            this.tabControl1.TabIndex = 18;
            // 
            // tabStockReserveUpdate
            // 
            this.tabStockReserveUpdate.Controls.Add(this.btnDelete);
            this.tabStockReserveUpdate.Controls.Add(this.txtCustomer);
            this.tabStockReserveUpdate.Controls.Add(this.txtProductID);
            this.tabStockReserveUpdate.Controls.Add(this.label4);
            this.tabStockReserveUpdate.Controls.Add(this.numQuantity);
            this.tabStockReserveUpdate.Controls.Add(this.txtProductName);
            this.tabStockReserveUpdate.Controls.Add(this.label3);
            this.tabStockReserveUpdate.Controls.Add(this.rbDecrease);
            this.tabStockReserveUpdate.Controls.Add(this.rbIncrease);
            this.tabStockReserveUpdate.Controls.Add(this.btnSave);
            this.tabStockReserveUpdate.Controls.Add(this.btnClear);
            this.tabStockReserveUpdate.Controls.Add(this.label2);
            this.tabStockReserveUpdate.Controls.Add(this.label1);
            this.tabStockReserveUpdate.Location = new System.Drawing.Point(4, 27);
            this.tabStockReserveUpdate.Name = "tabStockReserveUpdate";
            this.tabStockReserveUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabStockReserveUpdate.Size = new System.Drawing.Size(957, 163);
            this.tabStockReserveUpdate.TabIndex = 0;
            this.tabStockReserveUpdate.Text = "Stock Reserve Update";
            this.tabStockReserveUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(489, 47);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 60);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(20, 116);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(183, 24);
            this.txtCustomer.TabIndex = 29;
            // 
            // txtProductID
            // 
            this.txtProductID.Enabled = false;
            this.txtProductID.Location = new System.Drawing.Point(20, 47);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(121, 24);
            this.txtProductID.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Customer";
            // 
            // numQuantity
            // 
            this.numQuantity.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numQuantity.Location = new System.Drawing.Point(239, 116);
            this.numQuantity.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 24);
            this.numQuantity.TabIndex = 26;
            // 
            // txtProductName
            // 
            this.txtProductName.Enabled = false;
            this.txtProductName.Location = new System.Drawing.Point(162, 47);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(312, 24);
            this.txtProductName.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product Description";
            // 
            // rbDecrease
            // 
            this.rbDecrease.AutoSize = true;
            this.rbDecrease.Location = new System.Drawing.Point(381, 114);
            this.rbDecrease.Name = "rbDecrease";
            this.rbDecrease.Size = new System.Drawing.Size(93, 22);
            this.rbDecrease.TabIndex = 23;
            this.rbDecrease.TabStop = true;
            this.rbDecrease.Text = "Decrease";
            this.rbDecrease.UseVisualStyleBackColor = true;
            // 
            // rbIncrease
            // 
            this.rbIncrease.AutoSize = true;
            this.rbIncrease.Location = new System.Drawing.Point(381, 85);
            this.rbIncrease.Name = "rbIncrease";
            this.rbIncrease.Size = new System.Drawing.Size(85, 22);
            this.rbIncrease.TabIndex = 22;
            this.rbIncrease.TabStop = true;
            this.rbIncrease.Text = "Increase";
            this.rbIncrease.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(754, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(182, 59);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Location = new System.Drawing.Point(754, 77);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(182, 63);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Product ID";
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.textBox1);
            this.tabSearch.Controls.Add(this.label8);
            this.tabSearch.Controls.Add(this.textBox2);
            this.tabSearch.Controls.Add(this.label5);
            this.tabSearch.Controls.Add(this.btnSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 27);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(957, 163);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(254, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 24);
            this.textBox1.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Product ID";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(19, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 24);
            this.textBox2.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Customer";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Location = new System.Drawing.Point(753, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(182, 59);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgStockReserveList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 200);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(16);
            this.panel1.Size = new System.Drawing.Size(971, 519);
            this.panel1.TabIndex = 1;
            // 
            // dgStockReserveList
            // 
            this.dgStockReserveList.AllowUserToAddRows = false;
            this.dgStockReserveList.AllowUserToDeleteRows = false;
            this.dgStockReserveList.AutoGenerateColumns = false;
            this.dgStockReserveList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStockReserveList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgStockID,
            this.dgSaleOrderID,
            this.dgCustomerName,
            this.dgValidationDate,
            this.dgProductID,
            this.dgProductName,
            this.dgQty,
            this.dgReserveID,
            this.dataGridViewTextBoxColumn4,
            this.saleOrderDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn8});
            this.dgStockReserveList.DataSource = this.stockReserveBindingSource;
            this.dgStockReserveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStockReserveList.Location = new System.Drawing.Point(16, 16);
            this.dgStockReserveList.Margin = new System.Windows.Forms.Padding(0);
            this.dgStockReserveList.MultiSelect = false;
            this.dgStockReserveList.Name = "dgStockReserveList";
            this.dgStockReserveList.ReadOnly = true;
            this.dgStockReserveList.RowTemplate.Height = 24;
            this.dgStockReserveList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStockReserveList.Size = new System.Drawing.Size(939, 487);
            this.dgStockReserveList.TabIndex = 1;
            this.dgStockReserveList.SelectionChanged += new System.EventHandler(this.dgStockList_SelectionChanged);
            // 
            // dgProductName
            // 
            this.dgProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgProductName.HeaderText = "Product Name";
            this.dgProductName.Name = "dgProductName";
            this.dgProductName.ReadOnly = true;
            // 
            // dgStockID
            // 
            this.dgStockID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgStockID.DataPropertyName = "StockID";
            this.dgStockID.HeaderText = "StockID";
            this.dgStockID.Name = "dgStockID";
            this.dgStockID.ReadOnly = true;
            this.dgStockID.Width = 90;
            // 
            // dgSaleOrderID
            // 
            this.dgSaleOrderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgSaleOrderID.DataPropertyName = "SaleOrderID";
            this.dgSaleOrderID.HeaderText = "SaleOrderID";
            this.dgSaleOrderID.Name = "dgSaleOrderID";
            this.dgSaleOrderID.ReadOnly = true;
            this.dgSaleOrderID.Width = 118;
            // 
            // dgCustomerName
            // 
            this.dgCustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgCustomerName.DataPropertyName = "Customer";
            this.dgCustomerName.HeaderText = "Customer";
            this.dgCustomerName.Name = "dgCustomerName";
            this.dgCustomerName.ReadOnly = true;
            this.dgCustomerName.Width = 103;
            // 
            // dgValidationDate
            // 
            this.dgValidationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgValidationDate.DataPropertyName = "ValidationDate";
            this.dgValidationDate.HeaderText = "ValidationDate";
            this.dgValidationDate.Name = "dgValidationDate";
            this.dgValidationDate.ReadOnly = true;
            this.dgValidationDate.Width = 131;
            // 
            // dgProductID
            // 
            this.dgProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgProductID.DataPropertyName = "ProductID";
            this.dgProductID.HeaderText = "ProductID";
            this.dgProductID.Name = "dgProductID";
            this.dgProductID.ReadOnly = true;
            this.dgProductID.Width = 103;
            // 
            // dgQty
            // 
            this.dgQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgQty.DataPropertyName = "Qty";
            this.dgQty.HeaderText = "Qty";
            this.dgQty.Name = "dgQty";
            this.dgQty.ReadOnly = true;
            this.dgQty.Width = 60;
            // 
            // dgReserveID
            // 
            this.dgReserveID.DataPropertyName = "ReserveID";
            this.dgReserveID.HeaderText = "ReserveID";
            this.dgReserveID.Name = "dgReserveID";
            this.dgReserveID.ReadOnly = true;
            this.dgReserveID.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CustomerID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CustomerID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // saleOrderDataGridViewTextBoxColumn
            // 
            this.saleOrderDataGridViewTextBoxColumn.DataPropertyName = "SaleOrder";
            this.saleOrderDataGridViewTextBoxColumn.HeaderText = "SaleOrder";
            this.saleOrderDataGridViewTextBoxColumn.Name = "saleOrderDataGridViewTextBoxColumn";
            this.saleOrderDataGridViewTextBoxColumn.ReadOnly = true;
            this.saleOrderDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Stock";
            this.dataGridViewTextBoxColumn8.HeaderText = "Stock";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // stockReserveBindingSource
            // 
            this.stockReserveBindingSource.DataSource = typeof(LoginForm.DataSet.StockReserve);
            // 
            // frmStockReserve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 719);
            this.Controls.Add(this.FrameTableLayout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(769, 532);
            this.Name = "frmStockReserve";
            this.Text = "Stock Reserve";
            this.Load += new System.EventHandler(this.StockDevelopment_Load);
            this.FrameTableLayout.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabStockReserveUpdate.ResumeLayout(false);
            this.tabStockReserveUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStockReserveList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockReserveBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel FrameTableLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgStockReserveList;
        private System.Windows.Forms.DataGridViewTextBoxColumn reserveIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn validationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isFromRSInvoiceDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSaleOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgValidationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgReserveID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.BindingSource stockReserveBindingSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStockReserveUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbDecrease;
        private System.Windows.Forms.RadioButton rbIncrease;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabSearch;
    }
}