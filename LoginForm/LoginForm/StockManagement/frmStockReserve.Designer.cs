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
            this.FrameTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStockReserveUpdate = new System.Windows.Forms.TabPage();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
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
            this.dgStockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSaleOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgValidationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FrameTableLayout.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabStockReserveUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.tabSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockReserveList)).BeginInit();
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
            this.tabStockReserveUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.tabStockReserveUpdate.Controls.Add(this.label10);
            this.tabStockReserveUpdate.Controls.Add(this.label9);
            this.tabStockReserveUpdate.Controls.Add(this.label7);
            this.tabStockReserveUpdate.Controls.Add(this.txtCustomerName);
            this.tabStockReserveUpdate.Controls.Add(this.label6);
            this.tabStockReserveUpdate.Controls.Add(this.btnDelete);
            this.tabStockReserveUpdate.Controls.Add(this.txtCustomerID);
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
            this.tabStockReserveUpdate.Location = new System.Drawing.Point(4, 24);
            this.tabStockReserveUpdate.Name = "tabStockReserveUpdate";
            this.tabStockReserveUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabStockReserveUpdate.Size = new System.Drawing.Size(957, 166);
            this.tabStockReserveUpdate.TabIndex = 0;
            this.tabStockReserveUpdate.Text = "Stock Reserve Update";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(163, 47);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(240, 21);
            this.txtCustomerName.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Customer Name";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnDelete.Location = new System.Drawing.Point(820, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 56);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Enabled = false;
            this.txtCustomerID.Location = new System.Drawing.Point(21, 47);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(121, 21);
            this.txtCustomerID.TabIndex = 29;
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomerID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCustomerID_MouseDoubleClick);
            // 
            // txtProductID
            // 
            this.txtProductID.Enabled = false;
            this.txtProductID.Location = new System.Drawing.Point(21, 116);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(121, 21);
            this.txtProductID.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
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
            this.numQuantity.Location = new System.Drawing.Point(524, 116);
            this.numQuantity.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 21);
            this.numQuantity.TabIndex = 26;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(163, 116);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(240, 21);
            this.txtProductName.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product Description";
            // 
            // rbDecrease
            // 
            this.rbDecrease.AutoSize = true;
            this.rbDecrease.Location = new System.Drawing.Point(421, 116);
            this.rbDecrease.Name = "rbDecrease";
            this.rbDecrease.Size = new System.Drawing.Size(78, 19);
            this.rbDecrease.TabIndex = 23;
            this.rbDecrease.TabStop = true;
            this.rbDecrease.Text = "Decrease";
            this.rbDecrease.UseVisualStyleBackColor = true;
            // 
            // rbIncrease
            // 
            this.rbIncrease.AutoSize = true;
            this.rbIncrease.Location = new System.Drawing.Point(421, 87);
            this.rbIncrease.Name = "rbIncrease";
            this.rbIncrease.Size = new System.Drawing.Size(72, 19);
            this.rbIncrease.TabIndex = 22;
            this.rbIncrease.TabStop = true;
            this.rbIncrease.Text = "Increase";
            this.rbIncrease.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Image = global::LoginForm.Properties.Resources.if_floppy_285657;
            this.btnSave.Location = new System.Drawing.Point(744, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 56);
            this.btnSave.TabIndex = 21;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Image = global::LoginForm.Properties.Resources.if_edit_clear_23227;
            this.btnClear.Location = new System.Drawing.Point(892, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 56);
            this.btnClear.TabIndex = 20;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Product ID";
            // 
            // tabSearch
            // 
            this.tabSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.tabSearch.Controls.Add(this.label11);
            this.tabSearch.Controls.Add(this.textBox1);
            this.tabSearch.Controls.Add(this.label8);
            this.tabSearch.Controls.Add(this.textBox2);
            this.tabSearch.Controls.Add(this.label5);
            this.tabSearch.Controls.Add(this.btnSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 24);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(957, 166);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.Text = "Search";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(254, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 21);
            this.textBox1.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Product ID";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(19, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 21);
            this.textBox2.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Customer";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.Location = new System.Drawing.Point(465, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 50);
            this.btnSearch.TabIndex = 5;
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
            this.dgStockReserveList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgStockReserveList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStockReserveList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgStockID,
            this.dgSaleOrderID,
            this.dgCustomerName,
            this.dgValidationDate,
            this.dgProductID,
            this.dgProductName,
            this.dgQty});
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
            // dgStockID
            // 
            this.dgStockID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgStockID.HeaderText = "StockID";
            this.dgStockID.Name = "dgStockID";
            this.dgStockID.ReadOnly = true;
            this.dgStockID.Width = 74;
            // 
            // dgSaleOrderID
            // 
            this.dgSaleOrderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgSaleOrderID.HeaderText = "Sale Order ID";
            this.dgSaleOrderID.Name = "dgSaleOrderID";
            this.dgSaleOrderID.ReadOnly = true;
            this.dgSaleOrderID.Width = 87;
            // 
            // dgCustomerName
            // 
            this.dgCustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgCustomerName.HeaderText = "Customer Name";
            this.dgCustomerName.Name = "dgCustomerName";
            this.dgCustomerName.ReadOnly = true;
            this.dgCustomerName.Width = 112;
            // 
            // dgValidationDate
            // 
            this.dgValidationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgValidationDate.HeaderText = "Validation Date";
            this.dgValidationDate.Name = "dgValidationDate";
            this.dgValidationDate.ReadOnly = true;
            this.dgValidationDate.Width = 105;
            // 
            // dgProductID
            // 
            this.dgProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgProductID.HeaderText = "Product ID";
            this.dgProductID.Name = "dgProductID";
            this.dgProductID.ReadOnly = true;
            this.dgProductID.Width = 82;
            // 
            // dgProductName
            // 
            this.dgProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgProductName.HeaderText = "Product Name";
            this.dgProductName.Name = "dgProductName";
            this.dgProductName.ReadOnly = true;
            // 
            // dgQty
            // 
            this.dgQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgQty.HeaderText = "Quantity";
            this.dgQty.Name = "dgQty";
            this.dgQty.ReadOnly = true;
            this.dgQty.Width = 76;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(756, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Save";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(827, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "Delete";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(900, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 15);
            this.label10.TabIndex = 35;
            this.label10.Text = "Clear";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(469, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "Search";
            // 
            // frmStockReserve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStockReserveUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtCustomerID;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSaleOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgValidationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQty;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
    }
}