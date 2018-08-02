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
            this.btnSave = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.CustomsRateUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.FreightChargeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBranchCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataSeperator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericFactor = new System.Windows.Forms.NumericUpDown();
            this.lblFactor = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.currencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDefaultCurrency = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.lblVAT = new System.Windows.Forms.Label();
            this.txtLowMarginLimit = new System.Windows.Forms.TextBox();
            this.lblLowMarginLimit = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainCategorySubCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exchangeRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.termsOfPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesAndAuthoritiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainCategorySubCategoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomsRateUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreightChargeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel31, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(388, 522);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.panel31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel31.Controls.Add(this.btnSave);
            this.panel31.Controls.Add(this.label67);
            this.panel31.Controls.Add(this.CustomsRateUpDown);
            this.panel31.Controls.Add(this.label4);
            this.panel31.Controls.Add(this.FreightChargeUpDown);
            this.panel31.Controls.Add(this.label3);
            this.panel31.Controls.Add(this.txtBranchCode);
            this.panel31.Controls.Add(this.label2);
            this.panel31.Controls.Add(this.txtDataSeperator);
            this.panel31.Controls.Add(this.label1);
            this.panel31.Controls.Add(this.numericFactor);
            this.panel31.Controls.Add(this.lblFactor);
            this.panel31.Controls.Add(this.cbCurrency);
            this.panel31.Controls.Add(this.lblDefaultCurrency);
            this.panel31.Controls.Add(this.txtVAT);
            this.panel31.Controls.Add(this.lblVAT);
            this.panel31.Controls.Add(this.txtLowMarginLimit);
            this.panel31.Controls.Add(this.lblLowMarginLimit);
            this.panel31.Controls.Add(this.menuStrip1);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel31.Location = new System.Drawing.Point(0, 0);
            this.panel31.Margin = new System.Windows.Forms.Padding(0);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(388, 522);
            this.panel31.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Image = global::LoginForm.Properties.Resources.if_floppy_285657;
            this.btnSave.Location = new System.Drawing.Point(143, 349);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 41);
            this.btnSave.TabIndex = 60;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(151, 393);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(34, 15);
            this.label67.TabIndex = 59;
            this.label67.Text = "Save";
            // 
            // CustomsRateUpDown
            // 
            this.CustomsRateUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomsRateUpDown.DecimalPlaces = 2;
            this.CustomsRateUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.CustomsRateUpDown.Location = new System.Drawing.Point(143, 304);
            this.CustomsRateUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CustomsRateUpDown.Name = "CustomsRateUpDown";
            this.CustomsRateUpDown.Size = new System.Drawing.Size(231, 21);
            this.CustomsRateUpDown.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 305);
            this.label4.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Customs Rate";
            // 
            // FreightChargeUpDown
            // 
            this.FreightChargeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FreightChargeUpDown.DecimalPlaces = 2;
            this.FreightChargeUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.FreightChargeUpDown.Location = new System.Drawing.Point(143, 268);
            this.FreightChargeUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.FreightChargeUpDown.Name = "FreightChargeUpDown";
            this.FreightChargeUpDown.Size = new System.Drawing.Size(231, 21);
            this.FreightChargeUpDown.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 268);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Freight Charge";
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranchCode.Enabled = false;
            this.txtBranchCode.Location = new System.Drawing.Point(143, 230);
            this.txtBranchCode.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Size = new System.Drawing.Size(232, 21);
            this.txtBranchCode.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(12, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Branch Code";
            // 
            // txtDataSeperator
            // 
            this.txtDataSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataSeperator.Location = new System.Drawing.Point(143, 191);
            this.txtDataSeperator.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtDataSeperator.Name = "txtDataSeperator";
            this.txtDataSeperator.Size = new System.Drawing.Size(232, 21);
            this.txtDataSeperator.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 34);
            this.label1.TabIndex = 16;
            this.label1.Text = "Data Seperator For Purchase Order";
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
            this.numericFactor.Location = new System.Drawing.Point(143, 155);
            this.numericFactor.Margin = new System.Windows.Forms.Padding(2);
            this.numericFactor.Name = "numericFactor";
            this.numericFactor.Size = new System.Drawing.Size(231, 21);
            this.numericFactor.TabIndex = 13;
            // 
            // lblFactor
            // 
            this.lblFactor.AutoSize = true;
            this.lblFactor.Location = new System.Drawing.Point(12, 156);
            this.lblFactor.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.lblFactor.Name = "lblFactor";
            this.lblFactor.Size = new System.Drawing.Size(41, 15);
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
            this.cbCurrency.Location = new System.Drawing.Point(143, 116);
            this.cbCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(232, 23);
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
            this.lblDefaultCurrency.Location = new System.Drawing.Point(12, 119);
            this.lblDefaultCurrency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDefaultCurrency.Name = "lblDefaultCurrency";
            this.lblDefaultCurrency.Size = new System.Drawing.Size(97, 15);
            this.lblDefaultCurrency.TabIndex = 9;
            this.lblDefaultCurrency.Text = "Default Currency";
            // 
            // txtVAT
            // 
            this.txtVAT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVAT.Location = new System.Drawing.Point(143, 81);
            this.txtVAT.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(232, 21);
            this.txtVAT.TabIndex = 7;
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Location = new System.Drawing.Point(12, 83);
            this.lblVAT.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(28, 15);
            this.lblVAT.TabIndex = 6;
            this.lblVAT.Text = "VAT";
            // 
            // txtLowMarginLimit
            // 
            this.txtLowMarginLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLowMarginLimit.Location = new System.Drawing.Point(143, 45);
            this.txtLowMarginLimit.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtLowMarginLimit.Name = "txtLowMarginLimit";
            this.txtLowMarginLimit.Size = new System.Drawing.Size(232, 21);
            this.txtLowMarginLimit.TabIndex = 1;
            // 
            // lblLowMarginLimit
            // 
            this.lblLowMarginLimit.AutoSize = true;
            this.lblLowMarginLimit.Location = new System.Drawing.Point(12, 47);
            this.lblLowMarginLimit.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.lblLowMarginLimit.Name = "lblLowMarginLimit";
            this.lblLowMarginLimit.Size = new System.Drawing.Size(102, 15);
            this.lblLowMarginLimit.TabIndex = 0;
            this.lblLowMarginLimit.Text = "Low Margin Limit";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainCategorySubCategoryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(386, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainCategorySubCategoryToolStripMenuItem
            // 
            this.mainCategorySubCategoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exchangeRateToolStripMenuItem,
            this.termsOfPaymentToolStripMenuItem,
            this.rolesAndAuthoritiesToolStripMenuItem,
            this.mainCategorySubCategoryToolStripMenuItem1});
            this.mainCategorySubCategoryToolStripMenuItem.Name = "mainCategorySubCategoryToolStripMenuItem";
            this.mainCategorySubCategoryToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.mainCategorySubCategoryToolStripMenuItem.Text = "Menu";
            // 
            // exchangeRateToolStripMenuItem
            // 
            this.exchangeRateToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.exchangeRateToolStripMenuItem.Name = "exchangeRateToolStripMenuItem";
            this.exchangeRateToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.exchangeRateToolStripMenuItem.Text = "Exchange Rate";
            this.exchangeRateToolStripMenuItem.Click += new System.EventHandler(this.exchangeRateToolStripMenuItem_Click);
            // 
            // termsOfPaymentToolStripMenuItem
            // 
            this.termsOfPaymentToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.termsOfPaymentToolStripMenuItem.Name = "termsOfPaymentToolStripMenuItem";
            this.termsOfPaymentToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.termsOfPaymentToolStripMenuItem.Text = "Terms of Payment";
            this.termsOfPaymentToolStripMenuItem.Click += new System.EventHandler(this.termsOfPaymentToolStripMenuItem_Click);
            // 
            // rolesAndAuthoritiesToolStripMenuItem
            // 
            this.rolesAndAuthoritiesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.rolesAndAuthoritiesToolStripMenuItem.Name = "rolesAndAuthoritiesToolStripMenuItem";
            this.rolesAndAuthoritiesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.rolesAndAuthoritiesToolStripMenuItem.Text = "Roles and Authorities";
            this.rolesAndAuthoritiesToolStripMenuItem.Click += new System.EventHandler(this.rolesAndAuthoritiesToolStripMenuItem_Click);
            // 
            // mainCategorySubCategoryToolStripMenuItem1
            // 
            this.mainCategorySubCategoryToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.mainCategorySubCategoryToolStripMenuItem1.Name = "mainCategorySubCategoryToolStripMenuItem1";
            this.mainCategorySubCategoryToolStripMenuItem1.Size = new System.Drawing.Size(230, 22);
            this.mainCategorySubCategoryToolStripMenuItem1.Text = "Main category - Sub category";
            this.mainCategorySubCategoryToolStripMenuItem1.Click += new System.EventHandler(this.mainCategorySubCategoryToolStripMenuItem1_Click);
            // 
            // ManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManagementControl";
            this.Size = new System.Drawing.Size(388, 522);
            this.Load += new System.EventHandler(this.ManagementControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomsRateUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreightChargeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource currencyBindingSource;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.TextBox txtBranchCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataSeperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericFactor;
        private System.Windows.Forms.Label lblFactor;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label lblDefaultCurrency;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.TextBox txtLowMarginLimit;
        private System.Windows.Forms.Label lblLowMarginLimit;
        private System.Windows.Forms.NumericUpDown CustomsRateUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown FreightChargeUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainCategorySubCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exchangeRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem termsOfPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesAndAuthoritiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainCategorySubCategoryToolStripMenuItem1;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Button btnSave;
    }
}
