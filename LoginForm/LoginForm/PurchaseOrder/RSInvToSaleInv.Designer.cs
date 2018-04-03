namespace LoginForm.PurchaseOrder
{
    partial class RSInvToSaleInv
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
            this.dgSaleInvoice = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblPurchaseOrder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnSaleInvoice = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgPurchaseOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPurchaseOrderItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBillingItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSalesUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PODetailNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGoodsValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCCCNNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCountryofOrigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgArticleDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDeliveryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDeliveryItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSaleInvoice
            // 
            this.dgSaleInvoice.AllowUserToOrderColumns = true;
            this.dgSaleInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSaleInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.dgPurchaseOrderNumber,
            this.dgPurchaseOrderItemNumber,
            this.dgProductNumber,
            this.dgBillingItemNumber,
            this.dgQuantity,
            this.dgSalesUnit,
            this.dgUnitPrice,
            this.PODetailNo,
            this.dgDiscount,
            this.dgGoodsValue,
            this.dgAmount,
            this.dgCCCNNO,
            this.dgCountryofOrigin,
            this.dgArticleDescription,
            this.dgDeliveryNumber,
            this.dgDeliveryItemNumber});
            this.dgSaleInvoice.Location = new System.Drawing.Point(396, 29);
            this.dgSaleInvoice.Name = "dgSaleInvoice";
            this.dgSaleInvoice.Size = new System.Drawing.Size(482, 251);
            this.dgSaleInvoice.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(755, 286);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 50);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPurchaseOrder
            // 
            this.lblPurchaseOrder.AutoSize = true;
            this.lblPurchaseOrder.Location = new System.Drawing.Point(12, 13);
            this.lblPurchaseOrder.Name = "lblPurchaseOrder";
            this.lblPurchaseOrder.Size = new System.Drawing.Size(81, 13);
            this.lblPurchaseOrder.TabIndex = 2;
            this.lblPurchaseOrder.Text = "Purchase Order";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Purchase Order Details";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(396, 286);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(60, 23);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "SelectAll";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(465, 286);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(60, 23);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "ClearAll";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnSaleInvoice
            // 
            this.btnSaleInvoice.Location = new System.Drawing.Point(626, 286);
            this.btnSaleInvoice.Name = "btnSaleInvoice";
            this.btnSaleInvoice.Size = new System.Drawing.Size(123, 50);
            this.btnSaleInvoice.TabIndex = 1;
            this.btnSaleInvoice.Text = "Create Sale Invoice";
            this.btnSaleInvoice.UseVisualStyleBackColor = true;
            this.btnSaleInvoice.Click += new System.EventHandler(this.btnSaleInvoice_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(375, 251);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 20;
            // 
            // dgPurchaseOrderNumber
            // 
            this.dgPurchaseOrderNumber.HeaderText = "PurchaseOrderNumber";
            this.dgPurchaseOrderNumber.Name = "dgPurchaseOrderNumber";
            this.dgPurchaseOrderNumber.ReadOnly = true;
            // 
            // dgPurchaseOrderItemNumber
            // 
            this.dgPurchaseOrderItemNumber.HeaderText = "PurchaseOrderItemNumber";
            this.dgPurchaseOrderItemNumber.Name = "dgPurchaseOrderItemNumber";
            this.dgPurchaseOrderItemNumber.ReadOnly = true;
            // 
            // dgProductNumber
            // 
            this.dgProductNumber.HeaderText = "ProductNumber";
            this.dgProductNumber.Name = "dgProductNumber";
            this.dgProductNumber.ReadOnly = true;
            // 
            // dgBillingItemNumber
            // 
            this.dgBillingItemNumber.HeaderText = "BillingItemNumber";
            this.dgBillingItemNumber.Name = "dgBillingItemNumber";
            this.dgBillingItemNumber.ReadOnly = true;
            // 
            // dgQuantity
            // 
            this.dgQuantity.HeaderText = "Quantity";
            this.dgQuantity.Name = "dgQuantity";
            this.dgQuantity.ReadOnly = true;
            // 
            // dgSalesUnit
            // 
            this.dgSalesUnit.HeaderText = "SalesUnit";
            this.dgSalesUnit.Name = "dgSalesUnit";
            this.dgSalesUnit.ReadOnly = true;
            // 
            // dgUnitPrice
            // 
            this.dgUnitPrice.HeaderText = "UnitPrice";
            this.dgUnitPrice.Name = "dgUnitPrice";
            this.dgUnitPrice.ReadOnly = true;
            // 
            // PODetailNo
            // 
            this.PODetailNo.HeaderText = "PODetail";
            this.PODetailNo.Name = "PODetailNo";
            this.PODetailNo.Visible = false;
            // 
            // dgDiscount
            // 
            this.dgDiscount.HeaderText = "Discount";
            this.dgDiscount.Name = "dgDiscount";
            this.dgDiscount.ReadOnly = true;
            // 
            // dgGoodsValue
            // 
            this.dgGoodsValue.HeaderText = "GoodsValue";
            this.dgGoodsValue.Name = "dgGoodsValue";
            this.dgGoodsValue.ReadOnly = true;
            // 
            // dgAmount
            // 
            this.dgAmount.HeaderText = "Amount";
            this.dgAmount.Name = "dgAmount";
            this.dgAmount.ReadOnly = true;
            // 
            // dgCCCNNO
            // 
            this.dgCCCNNO.HeaderText = "CCCNNO";
            this.dgCCCNNO.Name = "dgCCCNNO";
            this.dgCCCNNO.ReadOnly = true;
            // 
            // dgCountryofOrigin
            // 
            this.dgCountryofOrigin.HeaderText = "CountryofOrigin";
            this.dgCountryofOrigin.Name = "dgCountryofOrigin";
            this.dgCountryofOrigin.ReadOnly = true;
            // 
            // dgArticleDescription
            // 
            this.dgArticleDescription.HeaderText = "ArticleDescription";
            this.dgArticleDescription.Name = "dgArticleDescription";
            this.dgArticleDescription.ReadOnly = true;
            // 
            // dgDeliveryNumber
            // 
            this.dgDeliveryNumber.HeaderText = "DeliveryNumber";
            this.dgDeliveryNumber.Name = "dgDeliveryNumber";
            this.dgDeliveryNumber.ReadOnly = true;
            // 
            // dgDeliveryItemNumber
            // 
            this.dgDeliveryItemNumber.HeaderText = "DeliveryItemNumber";
            this.dgDeliveryItemNumber.Name = "dgDeliveryItemNumber";
            this.dgDeliveryItemNumber.ReadOnly = true;
            // 
            // RSInvToSaleInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 340);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPurchaseOrder);
            this.Controls.Add(this.btnSaleInvoice);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgSaleInvoice);
            this.Name = "RSInvToSaleInv";
            this.Text = "RSInvToSaleInv";
            this.Load += new System.EventHandler(this.RSInvToSaleInv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSaleInvoice;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblPurchaseOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnSaleInvoice;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPurchaseOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPurchaseOrderItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBillingItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSalesUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PODetailNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGoodsValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCCCNNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCountryofOrigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgArticleDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDeliveryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDeliveryItemNumber;
    }
}