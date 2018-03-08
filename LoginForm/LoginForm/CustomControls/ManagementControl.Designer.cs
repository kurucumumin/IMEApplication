namespace LoginForm.CustomControls
{
    partial class ManagementControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.txtBranchCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataSeperator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCategorySubCategory = new System.Windows.Forms.Button();
            this.btnExchangeRate = new System.Windows.Forms.Button();
            this.numericFactor = new System.Windows.Forms.NumericUpDown();
            this.lblFactor = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.currencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDefaultCurrency = new System.Windows.Forms.Label();
            this.btnTermsOfPayment = new System.Windows.Forms.Button();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.lblVAT = new System.Windows.Forms.Label();
            this.btnRolesAuthorities = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLowMarginLimit = new System.Windows.Forms.TextBox();
            this.lblLowMarginLimit = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.71202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.34389F));
            this.tableLayoutPanel1.Controls.Add(this.panel31, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1023, 553);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel31
            // 
            this.panel31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel31.Controls.Add(this.txtBranchCode);
            this.panel31.Controls.Add(this.label2);
            this.panel31.Controls.Add(this.txtDataSeperator);
            this.panel31.Controls.Add(this.label1);
            this.panel31.Controls.Add(this.btnCategorySubCategory);
            this.panel31.Controls.Add(this.btnExchangeRate);
            this.panel31.Controls.Add(this.numericFactor);
            this.panel31.Controls.Add(this.lblFactor);
            this.panel31.Controls.Add(this.cbCurrency);
            this.panel31.Controls.Add(this.lblDefaultCurrency);
            this.panel31.Controls.Add(this.btnTermsOfPayment);
            this.panel31.Controls.Add(this.txtVAT);
            this.panel31.Controls.Add(this.lblVAT);
            this.panel31.Controls.Add(this.btnRolesAuthorities);
            this.panel31.Controls.Add(this.btnSave);
            this.panel31.Controls.Add(this.txtLowMarginLimit);
            this.panel31.Controls.Add(this.lblLowMarginLimit);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel31.Location = new System.Drawing.Point(204, 0);
            this.panel31.Margin = new System.Windows.Forms.Padding(0);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(334, 553);
            this.panel31.TabIndex = 0;
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranchCode.Location = new System.Drawing.Point(191, 255);
            this.txtBranchCode.Margin = new System.Windows.Forms.Padding(3, 2, 16, 2);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Size = new System.Drawing.Size(125, 24);
            this.txtBranchCode.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Branch Code";
            // 
            // txtDataSeperator
            // 
            this.txtDataSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataSeperator.Location = new System.Drawing.Point(191, 207);
            this.txtDataSeperator.Margin = new System.Windows.Forms.Padding(3, 2, 16, 2);
            this.txtDataSeperator.Name = "txtDataSeperator";
            this.txtDataSeperator.Size = new System.Drawing.Size(125, 24);
            this.txtDataSeperator.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 199);
            this.label1.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 42);
            this.label1.TabIndex = 16;
            this.label1.Text = "Data Seperator For Purchase Order";
            // 
            // btnCategorySubCategory
            // 
            this.btnCategorySubCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategorySubCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.btnCategorySubCategory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(214)))), ((int)(((byte)(167)))));
            this.btnCategorySubCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorySubCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorySubCategory.Location = new System.Drawing.Point(-1, 459);
            this.btnCategorySubCategory.Margin = new System.Windows.Forms.Padding(0);
            this.btnCategorySubCategory.Name = "btnCategorySubCategory";
            this.btnCategorySubCategory.Size = new System.Drawing.Size(338, 37);
            this.btnCategorySubCategory.TabIndex = 15;
            this.btnCategorySubCategory.Text = "Category & Sub Category";
            this.btnCategorySubCategory.UseVisualStyleBackColor = false;
            this.btnCategorySubCategory.Click += new System.EventHandler(this.btnCategorySubCategory_Click);
            // 
            // btnExchangeRate
            // 
            this.btnExchangeRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExchangeRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.btnExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(214)))), ((int)(((byte)(167)))));
            this.btnExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExchangeRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExchangeRate.Location = new System.Drawing.Point(-3, 348);
            this.btnExchangeRate.Margin = new System.Windows.Forms.Padding(0);
            this.btnExchangeRate.Name = "btnExchangeRate";
            this.btnExchangeRate.Size = new System.Drawing.Size(334, 37);
            this.btnExchangeRate.TabIndex = 14;
            this.btnExchangeRate.Text = "Exchange Rate";
            this.btnExchangeRate.UseVisualStyleBackColor = false;
            this.btnExchangeRate.Click += new System.EventHandler(this.btnExchangeRate_Click);
            // 
            // numericFactor
            // 
            this.numericFactor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericFactor.DecimalPlaces = 2;
            this.numericFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericFactor.Location = new System.Drawing.Point(191, 162);
            this.numericFactor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericFactor.Name = "numericFactor";
            this.numericFactor.Size = new System.Drawing.Size(125, 24);
            this.numericFactor.TabIndex = 13;
            // 
            // lblFactor
            // 
            this.lblFactor.AutoSize = true;
            this.lblFactor.Location = new System.Drawing.Point(16, 164);
            this.lblFactor.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
            this.lblFactor.Name = "lblFactor";
            this.lblFactor.Size = new System.Drawing.Size(51, 18);
            this.lblFactor.TabIndex = 12;
            this.lblFactor.Text = "Factor";
            // 
            // cbCurrency
            // 
            this.cbCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCurrency.DataSource = this.currencyBindingSource;
            this.cbCurrency.DisplayMember = "currencySymbol";
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(191, 114);
            this.cbCurrency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(125, 26);
            this.cbCurrency.TabIndex = 10;
            this.cbCurrency.ValueMember = "currencyID";
            // 
            // currencyBindingSource
            // 
            this.currencyBindingSource.DataSource = typeof(LoginForm.DataSet.Currency);
            // 
            // lblDefaultCurrency
            // 
            this.lblDefaultCurrency.AutoSize = true;
            this.lblDefaultCurrency.Location = new System.Drawing.Point(16, 118);
            this.lblDefaultCurrency.Name = "lblDefaultCurrency";
            this.lblDefaultCurrency.Size = new System.Drawing.Size(118, 18);
            this.lblDefaultCurrency.TabIndex = 9;
            this.lblDefaultCurrency.Text = "Default Currency";
            // 
            // btnTermsOfPayment
            // 
            this.btnTermsOfPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTermsOfPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.btnTermsOfPayment.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(214)))), ((int)(((byte)(167)))));
            this.btnTermsOfPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTermsOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTermsOfPayment.Location = new System.Drawing.Point(-3, 385);
            this.btnTermsOfPayment.Margin = new System.Windows.Forms.Padding(0);
            this.btnTermsOfPayment.Name = "btnTermsOfPayment";
            this.btnTermsOfPayment.Size = new System.Drawing.Size(334, 37);
            this.btnTermsOfPayment.TabIndex = 8;
            this.btnTermsOfPayment.Text = "Terms of Payment";
            this.btnTermsOfPayment.UseVisualStyleBackColor = false;
            this.btnTermsOfPayment.Click += new System.EventHandler(this.btnTermsOfPayment_Click);
            // 
            // txtVAT
            // 
            this.txtVAT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVAT.Location = new System.Drawing.Point(191, 71);
            this.txtVAT.Margin = new System.Windows.Forms.Padding(3, 2, 16, 2);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(125, 24);
            this.txtVAT.TabIndex = 7;
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Location = new System.Drawing.Point(16, 74);
            this.lblVAT.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(35, 18);
            this.lblVAT.TabIndex = 6;
            this.lblVAT.Text = "VAT";
            // 
            // btnRolesAuthorities
            // 
            this.btnRolesAuthorities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRolesAuthorities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.btnRolesAuthorities.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(214)))), ((int)(((byte)(167)))));
            this.btnRolesAuthorities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRolesAuthorities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRolesAuthorities.Location = new System.Drawing.Point(-3, 422);
            this.btnRolesAuthorities.Margin = new System.Windows.Forms.Padding(0);
            this.btnRolesAuthorities.Name = "btnRolesAuthorities";
            this.btnRolesAuthorities.Size = new System.Drawing.Size(334, 37);
            this.btnRolesAuthorities.TabIndex = 5;
            this.btnRolesAuthorities.Text = "Roles and Authorities";
            this.btnRolesAuthorities.UseVisualStyleBackColor = false;
            this.btnRolesAuthorities.Click += new System.EventHandler(this.btnRolesAuthorities_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(165)))), ((int)(((byte)(245)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(0, 496);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(332, 55);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLowMarginLimit
            // 
            this.txtLowMarginLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLowMarginLimit.Location = new System.Drawing.Point(191, 27);
            this.txtLowMarginLimit.Margin = new System.Windows.Forms.Padding(3, 2, 16, 2);
            this.txtLowMarginLimit.Name = "txtLowMarginLimit";
            this.txtLowMarginLimit.Size = new System.Drawing.Size(125, 24);
            this.txtLowMarginLimit.TabIndex = 1;
            // 
            // lblLowMarginLimit
            // 
            this.lblLowMarginLimit.AutoSize = true;
            this.lblLowMarginLimit.Location = new System.Drawing.Point(16, 30);
            this.lblLowMarginLimit.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
            this.lblLowMarginLimit.Name = "lblLowMarginLimit";
            this.lblLowMarginLimit.Size = new System.Drawing.Size(120, 18);
            this.lblLowMarginLimit.TabIndex = 0;
            this.lblLowMarginLimit.Text = "Low Margin Limit";
            // 
            // ManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManagementControl";
            this.Size = new System.Drawing.Size(1023, 553);
            this.Load += new System.EventHandler(this.ManagementControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.TextBox txtLowMarginLimit;
        private System.Windows.Forms.Label lblLowMarginLimit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRolesAuthorities;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.Button btnTermsOfPayment;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label lblDefaultCurrency;
        private System.Windows.Forms.Label lblFactor;
        private System.Windows.Forms.NumericUpDown numericFactor;
        private System.Windows.Forms.Button btnExchangeRate;
        private System.Windows.Forms.Button btnCategorySubCategory;
        private System.Windows.Forms.BindingSource currencyBindingSource;
        private System.Windows.Forms.TextBox txtDataSeperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBranchCode;
        private System.Windows.Forms.Label label2;
    }
}
