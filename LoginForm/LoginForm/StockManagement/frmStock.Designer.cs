namespace LoginForm.StockManagement
{
    partial class frmStock
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txt_productID = new System.Windows.Forms.TextBox();
            this.txt_ProductDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnViewStockReserves = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.MaskedTextBox();
            this.rbDecrease = new System.Windows.Forms.RadioButton();
            this.rbIncrease = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgStockList = new System.Windows.Forms.DataGridView();
            this.dgProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgReserveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FrameTableLayout.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FrameTableLayout
            // 
            this.FrameTableLayout.ColumnCount = 1;
            this.FrameTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FrameTableLayout.Controls.Add(this.groupBox2, 0, 1);
            this.FrameTableLayout.Controls.Add(this.groupBox1, 0, 0);
            this.FrameTableLayout.Controls.Add(this.panel1, 0, 2);
            this.FrameTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrameTableLayout.Location = new System.Drawing.Point(0, 0);
            this.FrameTableLayout.Name = "FrameTableLayout";
            this.FrameTableLayout.RowCount = 3;
            this.FrameTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.FrameTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.FrameTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FrameTableLayout.Size = new System.Drawing.Size(971, 719);
            this.FrameTableLayout.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txt_productID);
            this.groupBox2.Controls.Add(this.txt_ProductDesc);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(8, 208);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(955, 84);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Product ID";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Location = new System.Drawing.Point(770, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(182, 45);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txt_productID
            // 
            this.txt_productID.Location = new System.Drawing.Point(16, 45);
            this.txt_productID.Name = "txt_productID";
            this.txt_productID.Size = new System.Drawing.Size(148, 21);
            this.txt_productID.TabIndex = 0;
            this.txt_productID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_productID_KeyDown);
            // 
            // txt_ProductDesc
            // 
            this.txt_ProductDesc.Location = new System.Drawing.Point(208, 45);
            this.txt_ProductDesc.Name = "txt_ProductDesc";
            this.txt_ProductDesc.Size = new System.Drawing.Size(440, 21);
            this.txt_ProductDesc.TabIndex = 15;
            this.txt_ProductDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ProductDesc_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Product Description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnViewStockReserves);
            this.groupBox1.Controls.Add(this.numQuantity);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtProductID);
            this.groupBox1.Controls.Add(this.rbDecrease);
            this.groupBox1.Controls.Add(this.rbIncrease);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(955, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Add";
            // 
            // btnViewStockReserves
            // 
            this.btnViewStockReserves.Location = new System.Drawing.Point(485, 55);
            this.btnViewStockReserves.Name = "btnViewStockReserves";
            this.btnViewStockReserves.Size = new System.Drawing.Size(116, 60);
            this.btnViewStockReserves.TabIndex = 13;
            this.btnViewStockReserves.Text = "View Stock Reserves";
            this.btnViewStockReserves.UseVisualStyleBackColor = true;
            this.btnViewStockReserves.Click += new System.EventHandler(this.btnViewStockReserves_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numQuantity.Location = new System.Drawing.Point(208, 48);
            this.numQuantity.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 21);
            this.numQuantity.TabIndex = 12;
            this.numQuantity.Click += new System.EventHandler(this.numQuantity_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Enabled = false;
            this.txtProductName.Location = new System.Drawing.Point(16, 118);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(440, 21);
            this.txtProductName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Product Description";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(16, 47);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(148, 21);
            this.txtProductID.TabIndex = 8;
            this.txtProductID.DoubleClick += new System.EventHandler(this.txtProductID_DoubleClick);
            this.txtProductID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductID_KeyDown);
            // 
            // rbDecrease
            // 
            this.rbDecrease.AutoSize = true;
            this.rbDecrease.Enabled = false;
            this.rbDecrease.Location = new System.Drawing.Point(363, 49);
            this.rbDecrease.Name = "rbDecrease";
            this.rbDecrease.Size = new System.Drawing.Size(78, 19);
            this.rbDecrease.TabIndex = 7;
            this.rbDecrease.TabStop = true;
            this.rbDecrease.Text = "Decrease";
            this.rbDecrease.UseVisualStyleBackColor = true;
            // 
            // rbIncrease
            // 
            this.rbIncrease.AutoSize = true;
            this.rbIncrease.Enabled = false;
            this.rbIncrease.Location = new System.Drawing.Point(363, 26);
            this.rbIncrease.Name = "rbIncrease";
            this.rbIncrease.Size = new System.Drawing.Size(72, 19);
            this.rbIncrease.TabIndex = 6;
            this.rbIncrease.TabStop = true;
            this.rbIncrease.Text = "Increase";
            this.rbIncrease.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(770, 36);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(182, 59);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Location = new System.Drawing.Point(770, 95);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(182, 63);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product ID";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgStockList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(16);
            this.panel1.Size = new System.Drawing.Size(971, 419);
            this.panel1.TabIndex = 1;
            // 
            // dgStockList
            // 
            this.dgStockList.AllowUserToAddRows = false;
            this.dgStockList.AllowUserToDeleteRows = false;
            this.dgStockList.AutoGenerateColumns = false;
            this.dgStockList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgProductID,
            this.dgProductName,
            this.dgMPN,
            this.dgCost,
            this.dgQty,
            this.dgReserveQty,
            this.dgStockID,
            this.dgSupplierID});
            this.dgStockList.DataSource = this.stockBindingSource;
            this.dgStockList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStockList.Location = new System.Drawing.Point(16, 16);
            this.dgStockList.Margin = new System.Windows.Forms.Padding(0);
            this.dgStockList.MultiSelect = false;
            this.dgStockList.Name = "dgStockList";
            this.dgStockList.ReadOnly = true;
            this.dgStockList.RowTemplate.Height = 24;
            this.dgStockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStockList.Size = new System.Drawing.Size(939, 387);
            this.dgStockList.TabIndex = 1;
            this.dgStockList.SelectionChanged += new System.EventHandler(this.dgStockList_SelectionChanged);
            // 
            // dgProductID
            // 
            this.dgProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgProductID.DataPropertyName = "ProductID";
            this.dgProductID.HeaderText = "Product ID";
            this.dgProductID.Name = "dgProductID";
            this.dgProductID.ReadOnly = true;
            this.dgProductID.Width = 82;
            // 
            // dgProductName
            // 
            this.dgProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgProductName.DataPropertyName = "ProductName";
            this.dgProductName.HeaderText = "Product Name";
            this.dgProductName.Name = "dgProductName";
            this.dgProductName.ReadOnly = true;
            // 
            // dgMPN
            // 
            this.dgMPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgMPN.DataPropertyName = "MPN";
            this.dgMPN.HeaderText = "MPN";
            this.dgMPN.Name = "dgMPN";
            this.dgMPN.ReadOnly = true;
            this.dgMPN.Width = 60;
            // 
            // dgCost
            // 
            this.dgCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgCost.DataPropertyName = "Cost";
            this.dgCost.HeaderText = "Cost";
            this.dgCost.Name = "dgCost";
            this.dgCost.ReadOnly = true;
            this.dgCost.Width = 56;
            // 
            // dgQty
            // 
            this.dgQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgQty.DataPropertyName = "Qty";
            this.dgQty.HeaderText = "Quantity";
            this.dgQty.Name = "dgQty";
            this.dgQty.ReadOnly = true;
            this.dgQty.Width = 76;
            // 
            // dgReserveQty
            // 
            this.dgReserveQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgReserveQty.DataPropertyName = "ReserveQty";
            this.dgReserveQty.HeaderText = "Reserved Quantity";
            this.dgReserveQty.Name = "dgReserveQty";
            this.dgReserveQty.ReadOnly = true;
            this.dgReserveQty.Width = 120;
            // 
            // dgStockID
            // 
            this.dgStockID.DataPropertyName = "StockID";
            this.dgStockID.HeaderText = "StockID";
            this.dgStockID.Name = "dgStockID";
            this.dgStockID.ReadOnly = true;
            this.dgStockID.Visible = false;
            // 
            // dgSupplierID
            // 
            this.dgSupplierID.DataPropertyName = "SupplierID";
            this.dgSupplierID.HeaderText = "Supplier ID";
            this.dgSupplierID.Name = "dgSupplierID";
            this.dgSupplierID.ReadOnly = true;
            this.dgSupplierID.Visible = false;
            // 
            // stockBindingSource
            // 
            this.stockBindingSource.DataSource = typeof(LoginForm.DataSet.Stock);
            // 
            // frmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(971, 719);
            this.Controls.Add(this.FrameTableLayout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(769, 532);
            this.Name = "frmStock";
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.StockDevelopment_Load);
            this.FrameTableLayout.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStockList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel FrameTableLayout;
        private System.Windows.Forms.DataGridView dgStockList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtProductID;
        private System.Windows.Forms.RadioButton rbDecrease;
        private System.Windows.Forms.RadioButton rbIncrease;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource stockBindingSource;
        private System.Windows.Forms.Button btnViewStockReserves;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgReserveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSupplierID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_productID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txt_ProductDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}