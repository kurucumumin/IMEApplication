namespace LoginForm
{
    partial class FormNewPurchaseOrder
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
            this.btnCreatePurchase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl1 = new System.Windows.Forms.DataGridView();
            this.Choose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SaleOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationNos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMargin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderNature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreatePurchase
            // 
            this.btnCreatePurchase.Image = global::LoginForm.Properties.Resources.if_floppy_285657;
            this.btnCreatePurchase.Location = new System.Drawing.Point(959, 613);
            this.btnCreatePurchase.Name = "btnCreatePurchase";
            this.btnCreatePurchase.Size = new System.Drawing.Size(52, 52);
            this.btnCreatePurchase.TabIndex = 9;
            this.btnCreatePurchase.UseVisualStyleBackColor = true;
            this.btnCreatePurchase.Click += new System.EventHandler(this.btnCreatePurchase_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(926, 668);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Create Purchase Order";
            // 
            // gridControl1
            // 
            this.gridControl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridControl1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Choose,
            this.SaleOrderID,
            this.SaleDate,
            this.QuotationNos,
            this.SubTotal,
            this.TotalPrice,
            this.TotalMargin,
            this.SaleOrderNature});
            this.gridControl1.Location = new System.Drawing.Point(3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1041, 605);
            this.gridControl1.TabIndex = 15;
            // 
            // Choose
            // 
            this.Choose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Choose.HeaderText = "Choose";
            this.Choose.Name = "Choose";
            this.Choose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Choose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Choose.Width = 68;
            // 
            // SaleOrderID
            // 
            this.SaleOrderID.HeaderText = "SaleOrderID";
            this.SaleOrderID.Name = "SaleOrderID";
            // 
            // SaleDate
            // 
            this.SaleDate.HeaderText = "SaleDate";
            this.SaleDate.Name = "SaleDate";
            // 
            // QuotationNos
            // 
            this.QuotationNos.HeaderText = "QuotationNos";
            this.QuotationNos.Name = "QuotationNos";
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            // 
            // TotalPrice
            // 
            this.TotalPrice.HeaderText = "TotalPrice";
            this.TotalPrice.Name = "TotalPrice";
            // 
            // TotalMargin
            // 
            this.TotalMargin.HeaderText = "TotalMargin";
            this.TotalMargin.Name = "TotalMargin";
            // 
            // SaleOrderNature
            // 
            this.SaleOrderNature.HeaderText = "SaleOrderNature";
            this.SaleOrderNature.Name = "SaleOrderNature";
            // 
            // FormNewPurchaseOrder
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 687);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreatePurchase);
            this.MaximumSize = new System.Drawing.Size(1069, 726);
            this.MinimumSize = new System.Drawing.Size(1069, 726);
            this.Name = "FormNewPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNewPurchaseOrder";
            this.Load += new System.EventHandler(this.FormNewPurchaseOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreatePurchase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridControl1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Choose;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationNos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMargin;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNature;
    }
}