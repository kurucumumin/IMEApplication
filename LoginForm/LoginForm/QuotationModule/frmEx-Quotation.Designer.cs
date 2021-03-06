﻿namespace LoginForm.QuotationModule
{
    partial class frmEx_Quotation
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
            this.btnStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dg = new System.Windows.Forms.DataGridView();
            this.QuoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuotationno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.rbQuoNo = new System.Windows.Forms.RadioButton();
            this.rbCustomerName = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartDate
            // 
            this.btnStartDate.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnStartDate.CustomFormat = "dd-MM-yyyy";
            this.btnStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.btnStartDate.Location = new System.Drawing.Point(458, 8);
            this.btnStartDate.Name = "btnStartDate";
            this.btnStartDate.Size = new System.Drawing.Size(107, 20);
            this.btnStartDate.TabIndex = 0;
            this.btnStartDate.UseWaitCursor = true;
            // 
            // btnEndDate
            // 
            this.btnEndDate.CustomFormat = "dd-MM-yyyy";
            this.btnEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.btnEndDate.Location = new System.Drawing.Point(458, 44);
            this.btnEndDate.Name = "btnEndDate";
            this.btnEndDate.Size = new System.Drawing.Size(107, 20);
            this.btnEndDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "End Date";
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QuoNo,
            this.SDCode,
            this.CustomerName,
            this.Date,
            this.dgTotal});
            this.dg.Location = new System.Drawing.Point(12, 96);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(561, 241);
            this.dg.TabIndex = 2;
            this.dg.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_CellMouseDoubleClick);
            this.dg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_KeyDown);
            // 
            // QuoNo
            // 
            this.QuoNo.HeaderText = "Quotation No";
            this.QuoNo.Name = "QuoNo";
            this.QuoNo.ReadOnly = true;
            // 
            // SDCode
            // 
            this.SDCode.HeaderText = "SD Code";
            this.SDCode.Name = "SDCode";
            this.SDCode.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Quotation Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // dgTotal
            // 
            this.dgTotal.HeaderText = "Total Price";
            this.dgTotal.Name = "dgTotal";
            this.dgTotal.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Quotation No";
            // 
            // txtQuotationno
            // 
            this.txtQuotationno.Location = new System.Drawing.Point(97, 12);
            this.txtQuotationno.Name = "txtQuotationno";
            this.txtQuotationno.Size = new System.Drawing.Size(100, 20);
            this.txtQuotationno.TabIndex = 3;
            this.txtQuotationno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationno_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(97, 41);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyDown);
            // 
            // rbQuoNo
            // 
            this.rbQuoNo.AutoSize = true;
            this.rbQuoNo.Checked = true;
            this.rbQuoNo.Location = new System.Drawing.Point(15, 67);
            this.rbQuoNo.Name = "rbQuoNo";
            this.rbQuoNo.Size = new System.Drawing.Size(88, 17);
            this.rbQuoNo.TabIndex = 4;
            this.rbQuoNo.TabStop = true;
            this.rbQuoNo.Text = "Quotation No";
            this.rbQuoNo.UseVisualStyleBackColor = true;
            // 
            // rbCustomerName
            // 
            this.rbCustomerName.AutoSize = true;
            this.rbCustomerName.Location = new System.Drawing.Point(103, 67);
            this.rbCustomerName.Name = "rbCustomerName";
            this.rbCustomerName.Size = new System.Drawing.Size(100, 17);
            this.rbCustomerName.TabIndex = 4;
            this.rbCustomerName.TabStop = true;
            this.rbCustomerName.Text = "Customer Name";
            this.rbCustomerName.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.Location = new System.Drawing.Point(229, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 52);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Search";
            // 
            // frmEx_Quotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(577, 343);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.rbCustomerName);
            this.Controls.Add(this.rbQuoNo);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtQuotationno);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEndDate);
            this.Controls.Add(this.btnStartDate);
            this.Name = "frmEx_Quotation";
            this.Text = "frmEx_Quotation";
            this.Load += new System.EventHandler(this.frmEx_Quotation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker btnStartDate;
        private System.Windows.Forms.DateTimePicker btnEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuotationno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.RadioButton rbQuoNo;
        private System.Windows.Forms.RadioButton rbCustomerName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
    }
}