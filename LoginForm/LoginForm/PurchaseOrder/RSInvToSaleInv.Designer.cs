namespace LoginForm.PurchaseOrder
{
    partial class SaleOrderToDeliveryNote
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
            this.dgSaleOrderDetails = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblSaleOrder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnDeliveryNote = new System.Windows.Forms.Button();
            this.dgSaleOrder = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgMasterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUnitContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSaleOrderDetails
            // 
            this.dgSaleOrderDetails.AllowUserToDeleteRows = false;
            this.dgSaleOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSaleOrderDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.dgMasterNo,
            this.dgItemCode,
            this.dgProductDescription,
            this.dgQuantity,
            this.dgStockQuantity,
            this.dgCName,
            this.dgDetailID,
            this.dgUnitContent,
            this.dgUnitPrice,
            this.dgUnitOfMeasure});
            this.dgSaleOrderDetails.Location = new System.Drawing.Point(528, 36);
            this.dgSaleOrderDetails.Margin = new System.Windows.Forms.Padding(4);
            this.dgSaleOrderDetails.Name = "dgSaleOrderDetails";
            this.dgSaleOrderDetails.ReadOnly = true;
            this.dgSaleOrderDetails.Size = new System.Drawing.Size(643, 309);
            this.dgSaleOrderDetails.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1007, 352);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(164, 62);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblSaleOrder
            // 
            this.lblSaleOrder.AutoSize = true;
            this.lblSaleOrder.Location = new System.Drawing.Point(20, 16);
            this.lblSaleOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaleOrder.Name = "lblSaleOrder";
            this.lblSaleOrder.Size = new System.Drawing.Size(84, 17);
            this.lblSaleOrder.TabIndex = 2;
            this.lblSaleOrder.Text = "Sale Orders";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sale Order Details";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(528, 352);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(80, 28);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "SelectAll";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(620, 352);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(80, 28);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "ClearAll";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnDeliveryNote
            // 
            this.btnDeliveryNote.Location = new System.Drawing.Point(835, 352);
            this.btnDeliveryNote.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeliveryNote.Name = "btnDeliveryNote";
            this.btnDeliveryNote.Size = new System.Drawing.Size(164, 62);
            this.btnDeliveryNote.TabIndex = 1;
            this.btnDeliveryNote.Text = "Create Delivery Note";
            this.btnDeliveryNote.UseVisualStyleBackColor = true;
            this.btnDeliveryNote.Click += new System.EventHandler(this.btnDeliveryNote_Click);
            // 
            // dgSaleOrder
            // 
            this.dgSaleOrder.AllowUserToAddRows = false;
            this.dgSaleOrder.AllowUserToDeleteRows = false;
            this.dgSaleOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSaleOrder.Location = new System.Drawing.Point(20, 36);
            this.dgSaleOrder.Margin = new System.Windows.Forms.Padding(4);
            this.dgSaleOrder.Name = "dgSaleOrder";
            this.dgSaleOrder.ReadOnly = true;
            this.dgSaleOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSaleOrder.Size = new System.Drawing.Size(500, 309);
            this.dgSaleOrder.TabIndex = 5;
            this.dgSaleOrder.SelectionChanged += new System.EventHandler(this.dgSaleOrder_SelectionChanged);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.ReadOnly = true;
            this.CheckBox.Width = 20;
            // 
            // dgMasterNo
            // 
            this.dgMasterNo.HeaderText = "Sale OrderID";
            this.dgMasterNo.Name = "dgMasterNo";
            this.dgMasterNo.ReadOnly = true;
            // 
            // dgItemCode
            // 
            this.dgItemCode.HeaderText = "Product Code";
            this.dgItemCode.Name = "dgItemCode";
            this.dgItemCode.ReadOnly = true;
            // 
            // dgProductDescription
            // 
            this.dgProductDescription.HeaderText = "Product Description";
            this.dgProductDescription.Name = "dgProductDescription";
            this.dgProductDescription.ReadOnly = true;
            // 
            // dgQuantity
            // 
            this.dgQuantity.HeaderText = "Quantity";
            this.dgQuantity.Name = "dgQuantity";
            this.dgQuantity.ReadOnly = true;
            // 
            // dgStockQuantity
            // 
            this.dgStockQuantity.HeaderText = "Stock Quantity";
            this.dgStockQuantity.Name = "dgStockQuantity";
            this.dgStockQuantity.ReadOnly = true;
            // 
            // dgCName
            // 
            this.dgCName.HeaderText = "Customer Name";
            this.dgCName.Name = "dgCName";
            this.dgCName.ReadOnly = true;
            // 
            // dgDetailID
            // 
            this.dgDetailID.HeaderText = "SaleOrderDetailID";
            this.dgDetailID.Name = "dgDetailID";
            this.dgDetailID.ReadOnly = true;
            this.dgDetailID.Visible = false;
            // 
            // dgUnitContent
            // 
            this.dgUnitContent.HeaderText = "UC";
            this.dgUnitContent.Name = "dgUnitContent";
            this.dgUnitContent.ReadOnly = true;
            // 
            // dgUnitPrice
            // 
            this.dgUnitPrice.HeaderText = "UnitPrice";
            this.dgUnitPrice.Name = "dgUnitPrice";
            this.dgUnitPrice.ReadOnly = true;
            // 
            // dgUnitOfMeasure
            // 
            this.dgUnitOfMeasure.HeaderText = "UOM";
            this.dgUnitOfMeasure.Name = "dgUnitOfMeasure";
            this.dgUnitOfMeasure.ReadOnly = true;
            // 
            // SaleOrderToDeliveryNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 418);
            this.Controls.Add(this.dgSaleOrder);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSaleOrder);
            this.Controls.Add(this.btnDeliveryNote);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgSaleOrderDetails);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SaleOrderToDeliveryNote";
            this.Text = "Sale Order To Delivery Note";
            this.Load += new System.EventHandler(this.RSInvToSaleInv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSaleOrderDetails;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblSaleOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnDeliveryNote;
        private System.Windows.Forms.DataGridView dgSaleOrder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMasterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUnitContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUnitOfMeasure;
    }
}