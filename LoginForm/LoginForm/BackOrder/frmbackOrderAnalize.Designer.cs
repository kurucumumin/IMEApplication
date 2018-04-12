using System;

namespace LoginForm.BackOrder
{
    partial class frmbackOrderAnalize
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg = new System.Windows.Forms.DataGridView();
            this.QuotationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuoDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Productno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstPromisedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emphty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingAmount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromisedDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPromisedDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QuotationNo,
            this.SaleOrder,
            this.QuoDetail,
            this.OrderDate,
            this.SaleDetail,
            this.CustomerName,
            this.Adder,
            this.Representative,
            this.PurchaseOrderNumber,
            this.Productno,
            this.Quantity,
            this.PendingAmount,
            this.FirstPromisedDate,
            this.Emphty,
            this.PendingAmount1,
            this.PromisedDate2,
            this.CurrentPromisedDate2,
            this.Information});
            this.dg.Location = new System.Drawing.Point(2, 51);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(1165, 690);
            this.dg.TabIndex = 5;
            // 
            // QuotationNo
            // 
            this.QuotationNo.HeaderText = "QuotationNo";
            this.QuotationNo.Name = "QuotationNo";
            this.QuotationNo.ReadOnly = true;
            // 
            // SaleOrder
            // 
            this.SaleOrder.HeaderText = "Sale Order";
            this.SaleOrder.Name = "SaleOrder";
            this.SaleOrder.ReadOnly = true;
            // 
            // QuoDetail
            // 
            this.QuoDetail.HeaderText = "QuoDetail";
            this.QuoDetail.Name = "QuoDetail";
            this.QuoDetail.ReadOnly = true;
            this.QuoDetail.Visible = false;
            // 
            // OrderDate
            // 
            this.OrderDate.HeaderText = "Order Date";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // SaleDetail
            // 
            this.SaleDetail.HeaderText = "SaleDetail";
            this.SaleDetail.Name = "SaleDetail";
            this.SaleDetail.ReadOnly = true;
            this.SaleDetail.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // Adder
            // 
            this.Adder.HeaderText = "Adder ";
            this.Adder.Name = "Adder";
            this.Adder.ReadOnly = true;
            // 
            // Representative
            // 
            this.Representative.HeaderText = "Representative";
            this.Representative.Name = "Representative";
            this.Representative.ReadOnly = true;
            // 
            // PurchaseOrderNumber
            // 
            this.PurchaseOrderNumber.HeaderText = "Purchase Order Number";
            this.PurchaseOrderNumber.Name = "PurchaseOrderNumber";
            this.PurchaseOrderNumber.ReadOnly = true;
            // 
            // Productno
            // 
            this.Productno.HeaderText = "Product No";
            this.Productno.Name = "Productno";
            this.Productno.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // PendingAmount
            // 
            this.PendingAmount.HeaderText = "Pending Amount";
            this.PendingAmount.Name = "PendingAmount";
            this.PendingAmount.ReadOnly = true;
            // 
            // FirstPromisedDate
            // 
            this.FirstPromisedDate.HeaderText = "First Promised Date";
            this.FirstPromisedDate.Name = "FirstPromisedDate";
            this.FirstPromisedDate.ReadOnly = true;
            // 
            // Emphty
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            this.Emphty.DefaultCellStyle = dataGridViewCellStyle1;
            this.Emphty.HeaderText = "";
            this.Emphty.Name = "Emphty";
            this.Emphty.ReadOnly = true;
            this.Emphty.Width = 20;
            // 
            // PendingAmount1
            // 
            this.PendingAmount1.HeaderText = "Pending Amount";
            this.PendingAmount1.Name = "PendingAmount1";
            this.PendingAmount1.ReadOnly = true;
            // 
            // PromisedDate2
            // 
            this.PromisedDate2.HeaderText = "Promised Date 2";
            this.PromisedDate2.Name = "PromisedDate2";
            this.PromisedDate2.ReadOnly = true;
            // 
            // CurrentPromisedDate2
            // 
            this.CurrentPromisedDate2.HeaderText = "Current Promised Date 2";
            this.CurrentPromisedDate2.Name = "CurrentPromisedDate2";
            this.CurrentPromisedDate2.ReadOnly = true;
            // 
            // Information
            // 
            this.Information.HeaderText = "Information";
            this.Information.Name = "Information";
            this.Information.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(93, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 43);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmbackOrderAnalize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 753);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dg);
            this.Name = "frmbackOrderAnalize";
            this.Text = "frmbackOrderAnalize";
            this.Load += new System.EventHandler(this.frmbackOrderAnalize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg;
        private DateTime value1;
        private DateTime value2;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuoDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representative;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Productno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PendingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstPromisedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emphty;
        private System.Windows.Forms.DataGridViewTextBoxColumn PendingAmount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromisedDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPromisedDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExit;
    }
}