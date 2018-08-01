namespace LoginForm.IMEAccount
{
    partial class frmBillFromSupplier
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
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBank = new System.Windows.Forms.ComboBox();
            this.btnAccountAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbCurrency
            // 
            this.cbCurrency.Enabled = false;
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(318, 40);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(121, 21);
            this.cbCurrency.TabIndex = 8916;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8914;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8915;
            this.label1.Text = "Currency";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(259, 14);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(178, 20);
            this.txtCustomerName.TabIndex = 8913;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(132, 40);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(120, 20);
            this.txtAmount.TabIndex = 8910;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(132, 13);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(121, 20);
            this.txtCustomer.TabIndex = 8911;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCustomer.Location = new System.Drawing.Point(13, 17);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(106, 13);
            this.lblCustomer.TabIndex = 8912;
            this.lblCustomer.Text = "Supplier Code/Name";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(208, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 42);
            this.btnSave.TabIndex = 8909;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(133, 65);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(304, 20);
            this.txtDesc.TabIndex = 8910;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8914;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 8914;
            this.label4.Text = "Bank Account";
            // 
            // cbBank
            // 
            this.cbBank.FormattingEnabled = true;
            this.cbBank.Location = new System.Drawing.Point(133, 92);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(242, 21);
            this.cbBank.TabIndex = 8916;
            this.cbBank.SelectedIndexChanged += new System.EventHandler(this.cbBank_SelectedIndexChanged);
            // 
            // btnAccountAdd
            // 
            this.btnAccountAdd.Location = new System.Drawing.Point(388, 90);
            this.btnAccountAdd.Name = "btnAccountAdd";
            this.btnAccountAdd.Size = new System.Drawing.Size(49, 23);
            this.btnAccountAdd.TabIndex = 8917;
            this.btnAccountAdd.Text = "+";
            this.btnAccountAdd.UseVisualStyleBackColor = true;
            this.btnAccountAdd.Click += new System.EventHandler(this.btnAccountAdd_Click);
            // 
            // frmBillFromSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(451, 167);
            this.Controls.Add(this.btnAccountAdd);
            this.Controls.Add(this.cbBank);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnSave);
            this.Name = "frmBillFromSupplier";
            this.Text = "frmBillFromSupplier";
            this.Load += new System.EventHandler(this.frmBillFromCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBank;
        private System.Windows.Forms.Button btnAccountAdd;
    }
}