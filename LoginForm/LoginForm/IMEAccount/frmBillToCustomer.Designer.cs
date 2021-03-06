﻿namespace LoginForm.IMEAccount
{
    partial class frmBillToCustomer
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
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBank = new System.Windows.Forms.ComboBox();
            this.btnAccountAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(199, 117);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 42);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(253, 15);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(178, 20);
            this.txtCustomerID.TabIndex = 8906;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(126, 14);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(121, 20);
            this.txtCustomerName.TabIndex = 8904;
            this.txtCustomerName.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCustomer.Location = new System.Drawing.Point(7, 18);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(112, 13);
            this.lblCustomer.TabIndex = 8905;
            this.lblCustomer.Text = "Customer Code/Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8907;
            this.label1.Text = "Currency";
            // 
            // cbCurrency
            // 
            this.cbCurrency.Enabled = false;
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(310, 70);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(121, 21);
            this.cbCurrency.TabIndex = 8908;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8907;
            this.label2.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(126, 71);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(120, 20);
            this.txtAmount.TabIndex = 8904;
            this.txtAmount.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8907;
            this.label3.Text = "Account";
            // 
            // cbBank
            // 
            this.cbBank.FormattingEnabled = true;
            this.cbBank.Location = new System.Drawing.Point(128, 42);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(248, 21);
            this.cbBank.TabIndex = 8909;
            this.cbBank.SelectedIndexChanged += new System.EventHandler(this.cbBank_SelectedIndexChanged);
            // 
            // btnAccountAdd
            // 
            this.btnAccountAdd.Location = new System.Drawing.Point(382, 40);
            this.btnAccountAdd.Name = "btnAccountAdd";
            this.btnAccountAdd.Size = new System.Drawing.Size(49, 23);
            this.btnAccountAdd.TabIndex = 8918;
            this.btnAccountAdd.Text = "+";
            this.btnAccountAdd.UseVisualStyleBackColor = true;
            this.btnAccountAdd.Click += new System.EventHandler(this.btnAccountAdd_Click);
            // 
            // frmBillToCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(536, 171);
            this.Controls.Add(this.btnAccountAdd);
            this.Controls.Add(this.cbBank);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnSave);
            this.Name = "frmBillToCustomer";
            this.Text = "Bill To Customer";
            this.Load += new System.EventHandler(this.BillToCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBank;
        private System.Windows.Forms.Button btnAccountAdd;
    }
}