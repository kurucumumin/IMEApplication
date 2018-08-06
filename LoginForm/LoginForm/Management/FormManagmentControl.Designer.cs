namespace LoginForm.ManagementModule
{
    partial class FormManagmentControl
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
            this.lblDefaultCurrency = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.lblVAT = new System.Windows.Forms.Label();
            this.txtLowMarginLimit = new System.Windows.Forms.TextBox();
            this.lblLowMarginLimit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CustomsRateUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreightChargeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Image = global::LoginForm.Properties.Resources.if_floppy_285657;
            this.btnSave.Location = new System.Drawing.Point(134, 322);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 41);
            this.btnSave.TabIndex = 78;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(142, 366);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(32, 13);
            this.label67.TabIndex = 77;
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
            this.CustomsRateUpDown.Location = new System.Drawing.Point(134, 277);
            this.CustomsRateUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CustomsRateUpDown.Name = "CustomsRateUpDown";
            this.CustomsRateUpDown.Size = new System.Drawing.Size(231, 20);
            this.CustomsRateUpDown.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 278);
            this.label4.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 75;
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
            this.FreightChargeUpDown.Location = new System.Drawing.Point(134, 241);
            this.FreightChargeUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.FreightChargeUpDown.Name = "FreightChargeUpDown";
            this.FreightChargeUpDown.Size = new System.Drawing.Size(231, 20);
            this.FreightChargeUpDown.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 241);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Freight Charge";
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBranchCode.Enabled = false;
            this.txtBranchCode.Location = new System.Drawing.Point(134, 203);
            this.txtBranchCode.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Size = new System.Drawing.Size(232, 20);
            this.txtBranchCode.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(3, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Branch Code";
            // 
            // txtDataSeperator
            // 
            this.txtDataSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataSeperator.Location = new System.Drawing.Point(134, 164);
            this.txtDataSeperator.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtDataSeperator.Name = "txtDataSeperator";
            this.txtDataSeperator.Size = new System.Drawing.Size(232, 20);
            this.txtDataSeperator.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 158);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 34);
            this.label1.TabIndex = 69;
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
            this.numericFactor.Location = new System.Drawing.Point(134, 128);
            this.numericFactor.Margin = new System.Windows.Forms.Padding(2);
            this.numericFactor.Name = "numericFactor";
            this.numericFactor.Size = new System.Drawing.Size(231, 20);
            this.numericFactor.TabIndex = 68;
            // 
            // lblFactor
            // 
            this.lblFactor.AutoSize = true;
            this.lblFactor.Location = new System.Drawing.Point(3, 129);
            this.lblFactor.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.lblFactor.Name = "lblFactor";
            this.lblFactor.Size = new System.Drawing.Size(37, 13);
            this.lblFactor.TabIndex = 67;
            this.lblFactor.Text = "Factor";
            // 
            // cbCurrency
            // 
            this.cbCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCurrency.DisplayMember = "currencySymbol";
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(134, 89);
            this.cbCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(232, 21);
            this.cbCurrency.TabIndex = 66;
            this.cbCurrency.ValueMember = "currencyID";
            // 
            // lblDefaultCurrency
            // 
            this.lblDefaultCurrency.AutoSize = true;
            this.lblDefaultCurrency.Location = new System.Drawing.Point(3, 92);
            this.lblDefaultCurrency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDefaultCurrency.Name = "lblDefaultCurrency";
            this.lblDefaultCurrency.Size = new System.Drawing.Size(86, 13);
            this.lblDefaultCurrency.TabIndex = 65;
            this.lblDefaultCurrency.Text = "Default Currency";
            // 
            // txtVAT
            // 
            this.txtVAT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVAT.Location = new System.Drawing.Point(134, 54);
            this.txtVAT.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(232, 20);
            this.txtVAT.TabIndex = 64;
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Location = new System.Drawing.Point(3, 56);
            this.lblVAT.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(28, 13);
            this.lblVAT.TabIndex = 63;
            this.lblVAT.Text = "VAT";
            // 
            // txtLowMarginLimit
            // 
            this.txtLowMarginLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLowMarginLimit.Location = new System.Drawing.Point(134, 18);
            this.txtLowMarginLimit.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtLowMarginLimit.Name = "txtLowMarginLimit";
            this.txtLowMarginLimit.Size = new System.Drawing.Size(232, 20);
            this.txtLowMarginLimit.TabIndex = 62;
            // 
            // lblLowMarginLimit
            // 
            this.lblLowMarginLimit.AutoSize = true;
            this.lblLowMarginLimit.Location = new System.Drawing.Point(3, 20);
            this.lblLowMarginLimit.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.lblLowMarginLimit.Name = "lblLowMarginLimit";
            this.lblLowMarginLimit.Size = new System.Drawing.Size(86, 13);
            this.lblLowMarginLimit.TabIndex = 61;
            this.lblLowMarginLimit.Text = "Low Margin Limit";
            // 
            // FormManagmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(372, 483);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.CustomsRateUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FreightChargeUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBranchCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDataSeperator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericFactor);
            this.Controls.Add(this.lblFactor);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.lblDefaultCurrency);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.lblVAT);
            this.Controls.Add(this.txtLowMarginLimit);
            this.Controls.Add(this.lblLowMarginLimit);
            this.Name = "FormManagmentControl";
            this.Text = "FormManagmentControl";
            this.Load += new System.EventHandler(this.FormManagmentControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomsRateUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreightChargeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFactor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.NumericUpDown CustomsRateUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown FreightChargeUpDown;
        private System.Windows.Forms.Label label3;
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
    }
}