namespace LoginForm.IMEAccount
{
    partial class frmAccountMain
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
            this.dg = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSaleoperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.AddAccount = new System.Windows.Forms.Button();
            this.btnUpdateAccount = new System.Windows.Forms.Button();
            this.btnAddFromCustomer = new System.Windows.Forms.Button();
            this.btnUpdateFromCustomer = new System.Windows.Forms.Button();
            this.btnAllAccounts = new System.Windows.Forms.Button();
            this.btnCustomersDebits = new System.Windows.Forms.Button();
            this.btnAddVoucher = new System.Windows.Forms.Button();
            this.dgCurrenetAccountMovements = new System.Windows.Forms.DataGridView();
            this.currentTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representativeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cariHareketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrenetAccountMovements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cariHareketBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CustomerName,
            this.CustomerID,
            this.Amount,
            this.Currency,
            this.Representative,
            this.Desc,
            this.Supplier,
            this.IsSaleoperation});
            this.dg.Location = new System.Drawing.Point(772, 141);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(189, 358);
            this.dg.TabIndex = 0;
            this.dg.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // CustomerID
            // 
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Visible = false;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Balance";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            this.Currency.ReadOnly = true;
            // 
            // Representative
            // 
            this.Representative.HeaderText = "Representative";
            this.Representative.Name = "Representative";
            this.Representative.ReadOnly = true;
            // 
            // Desc
            // 
            this.Desc.HeaderText = "Desc";
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            // 
            // Supplier
            // 
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            // 
            // IsSaleoperation
            // 
            this.IsSaleoperation.HeaderText = "IsSaleoperation";
            this.IsSaleoperation.Name = "IsSaleoperation";
            this.IsSaleoperation.ReadOnly = true;
            this.IsSaleoperation.Visible = false;
            // 
            // btnAddBill
            // 
            this.btnAddBill.Location = new System.Drawing.Point(100, 6);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(75, 43);
            this.btnAddBill.TabIndex = 1;
            this.btnAddBill.Text = "Add Bill To Customer";
            this.btnAddBill.UseVisualStyleBackColor = true;
            this.btnAddBill.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(181, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 43);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update Bill To Customer";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(887, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 43);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AddAccount
            // 
            this.AddAccount.Location = new System.Drawing.Point(530, 6);
            this.AddAccount.Name = "AddAccount";
            this.AddAccount.Size = new System.Drawing.Size(75, 43);
            this.AddAccount.TabIndex = 1;
            this.AddAccount.Text = "Add Account";
            this.AddAccount.UseVisualStyleBackColor = true;
            this.AddAccount.Click += new System.EventHandler(this.AddAccount_Click);
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Location = new System.Drawing.Point(611, 6);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(75, 43);
            this.btnUpdateAccount.TabIndex = 1;
            this.btnUpdateAccount.Text = "Update Account";
            this.btnUpdateAccount.UseVisualStyleBackColor = true;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // btnAddFromCustomer
            // 
            this.btnAddFromCustomer.Location = new System.Drawing.Point(262, 6);
            this.btnAddFromCustomer.Name = "btnAddFromCustomer";
            this.btnAddFromCustomer.Size = new System.Drawing.Size(82, 43);
            this.btnAddFromCustomer.TabIndex = 1;
            this.btnAddFromCustomer.Text = "Add Bill From Supplier";
            this.btnAddFromCustomer.UseVisualStyleBackColor = true;
            this.btnAddFromCustomer.Visible = false;
            this.btnAddFromCustomer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdateFromCustomer
            // 
            this.btnUpdateFromCustomer.Location = new System.Drawing.Point(350, 6);
            this.btnUpdateFromCustomer.Name = "btnUpdateFromCustomer";
            this.btnUpdateFromCustomer.Size = new System.Drawing.Size(94, 43);
            this.btnUpdateFromCustomer.TabIndex = 1;
            this.btnUpdateFromCustomer.Text = "Update Bill From Supplier";
            this.btnUpdateFromCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateFromCustomer.Visible = false;
            this.btnUpdateFromCustomer.Click += new System.EventHandler(this.btnUpdateFromCustomer_Click);
            // 
            // btnAllAccounts
            // 
            this.btnAllAccounts.Location = new System.Drawing.Point(450, 6);
            this.btnAllAccounts.Name = "btnAllAccounts";
            this.btnAllAccounts.Size = new System.Drawing.Size(75, 43);
            this.btnAllAccounts.TabIndex = 1;
            this.btnAllAccounts.Text = "All Accounts";
            this.btnAllAccounts.UseVisualStyleBackColor = true;
            this.btnAllAccounts.Click += new System.EventHandler(this.btnAllAccounts_Click);
            // 
            // btnCustomersDebits
            // 
            this.btnCustomersDebits.Location = new System.Drawing.Point(692, 6);
            this.btnCustomersDebits.Name = "btnCustomersDebits";
            this.btnCustomersDebits.Size = new System.Drawing.Size(75, 43);
            this.btnCustomersDebits.TabIndex = 1;
            this.btnCustomersDebits.Text = "Customer Debits";
            this.btnCustomersDebits.UseVisualStyleBackColor = true;
            this.btnCustomersDebits.Visible = false;
            this.btnCustomersDebits.Click += new System.EventHandler(this.btnCustomersDebits_Click);
            // 
            // btnAddVoucher
            // 
            this.btnAddVoucher.Location = new System.Drawing.Point(13, 6);
            this.btnAddVoucher.Name = "btnAddVoucher";
            this.btnAddVoucher.Size = new System.Drawing.Size(75, 43);
            this.btnAddVoucher.TabIndex = 2;
            this.btnAddVoucher.Text = "Add Voucher";
            this.btnAddVoucher.UseVisualStyleBackColor = true;
            this.btnAddVoucher.Click += new System.EventHandler(this.btnAddVoucher_Click);
            // 
            // dgCurrenetAccountMovements
            // 
            this.dgCurrenetAccountMovements.AutoGenerateColumns = false;
            this.dgCurrenetAccountMovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCurrenetAccountMovements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.currentTypeDataGridViewTextBoxColumn,
            this.currentIDDataGridViewTextBoxColumn,
            this.currentNameDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.currencyDataGridViewTextBoxColumn,
            this.representativeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.operationTypeDataGridViewTextBoxColumn,
            this.accountNameDataGridViewTextBoxColumn});
            this.dgCurrenetAccountMovements.DataSource = this.cariHareketBindingSource;
            this.dgCurrenetAccountMovements.Location = new System.Drawing.Point(13, 69);
            this.dgCurrenetAccountMovements.Margin = new System.Windows.Forms.Padding(2);
            this.dgCurrenetAccountMovements.Name = "dgCurrenetAccountMovements";
            this.dgCurrenetAccountMovements.RowTemplate.Height = 24;
            this.dgCurrenetAccountMovements.Size = new System.Drawing.Size(942, 414);
            this.dgCurrenetAccountMovements.TabIndex = 3;
            // 
            // currentTypeDataGridViewTextBoxColumn
            // 
            this.currentTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.currentTypeDataGridViewTextBoxColumn.DataPropertyName = "Current_Type";
            this.currentTypeDataGridViewTextBoxColumn.HeaderText = "Current_Type";
            this.currentTypeDataGridViewTextBoxColumn.Name = "currentTypeDataGridViewTextBoxColumn";
            this.currentTypeDataGridViewTextBoxColumn.Width = 96;
            // 
            // currentIDDataGridViewTextBoxColumn
            // 
            this.currentIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.currentIDDataGridViewTextBoxColumn.DataPropertyName = "Current_ID";
            this.currentIDDataGridViewTextBoxColumn.HeaderText = "Current_ID";
            this.currentIDDataGridViewTextBoxColumn.Name = "currentIDDataGridViewTextBoxColumn";
            this.currentIDDataGridViewTextBoxColumn.Width = 83;
            // 
            // currentNameDataGridViewTextBoxColumn
            // 
            this.currentNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.currentNameDataGridViewTextBoxColumn.DataPropertyName = "Current_Name";
            this.currentNameDataGridViewTextBoxColumn.HeaderText = "Current_Name";
            this.currentNameDataGridViewTextBoxColumn.Name = "currentNameDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 68;
            // 
            // currencyDataGridViewTextBoxColumn
            // 
            this.currencyDataGridViewTextBoxColumn.DataPropertyName = "Currency";
            this.currencyDataGridViewTextBoxColumn.HeaderText = "Currency";
            this.currencyDataGridViewTextBoxColumn.Name = "currencyDataGridViewTextBoxColumn";
            // 
            // representativeDataGridViewTextBoxColumn
            // 
            this.representativeDataGridViewTextBoxColumn.DataPropertyName = "Representative";
            this.representativeDataGridViewTextBoxColumn.HeaderText = "Representative";
            this.representativeDataGridViewTextBoxColumn.Name = "representativeDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // operationTypeDataGridViewTextBoxColumn
            // 
            this.operationTypeDataGridViewTextBoxColumn.DataPropertyName = "Operation_Type";
            this.operationTypeDataGridViewTextBoxColumn.HeaderText = "Operation_Type";
            this.operationTypeDataGridViewTextBoxColumn.Name = "operationTypeDataGridViewTextBoxColumn";
            // 
            // accountNameDataGridViewTextBoxColumn
            // 
            this.accountNameDataGridViewTextBoxColumn.DataPropertyName = "Account_Name";
            this.accountNameDataGridViewTextBoxColumn.HeaderText = "Account_Name";
            this.accountNameDataGridViewTextBoxColumn.Name = "accountNameDataGridViewTextBoxColumn";
            // 
            // cariHareketBindingSource
            // 
            this.cariHareketBindingSource.DataSource = typeof(LoginForm.DataSet.CariHareket);
            // 
            // frmAccountMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 503);
            this.Controls.Add(this.dgCurrenetAccountMovements);
            this.Controls.Add(this.btnAddVoucher);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdateFromCustomer);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCustomersDebits);
            this.Controls.Add(this.btnUpdateAccount);
            this.Controls.Add(this.btnAddFromCustomer);
            this.Controls.Add(this.btnAllAccounts);
            this.Controls.Add(this.AddAccount);
            this.Controls.Add(this.btnAddBill);
            this.Controls.Add(this.dg);
            this.Name = "frmAccountMain";
            this.Text = "frmAccountMain";
            this.Load += new System.EventHandler(this.frmAccountMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrenetAccountMovements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cariHareketBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button AddAccount;
        private System.Windows.Forms.Button btnUpdateAccount;
        private System.Windows.Forms.Button btnAddFromCustomer;
        private System.Windows.Forms.Button btnUpdateFromCustomer;
        private System.Windows.Forms.Button btnAllAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representative;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSaleoperation;
        private System.Windows.Forms.Button btnCustomersDebits;
        private System.Windows.Forms.Button btnAddVoucher;
        private System.Windows.Forms.DataGridView dgCurrenetAccountMovements;
        private System.Windows.Forms.BindingSource cariHareketBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn representativeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNameDataGridViewTextBoxColumn;
    }
}