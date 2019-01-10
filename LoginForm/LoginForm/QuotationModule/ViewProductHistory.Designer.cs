namespace LoginForm.QuotationModule
{
    partial class ViewProductHistory
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
            this.dgProductHistory = new System.Windows.Forms.DataGridView();
            this.dgcRsCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcQuotationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLandingCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMargin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProductHistory
            // 
            this.dgProductHistory.AllowUserToAddRows = false;
            this.dgProductHistory.AllowUserToDeleteRows = false;
            this.dgProductHistory.AllowUserToOrderColumns = true;
            this.dgProductHistory.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgProductHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcRsCode,
            this.dgcCustomerCode,
            this.dgcCustomerName,
            this.dgcDate,
            this.dgcQuotationNo,
            this.dgcQuantity,
            this.dgcUP,
            this.dgcCurrency,
            this.dgLandingCost,
            this.dgMargin,
            this.dgcStatus});
            this.dgProductHistory.Location = new System.Drawing.Point(12, 12);
            this.dgProductHistory.MaximumSize = new System.Drawing.Size(1123, 394);
            this.dgProductHistory.MinimumSize = new System.Drawing.Size(1123, 394);
            this.dgProductHistory.Name = "dgProductHistory";
            this.dgProductHistory.ReadOnly = true;
            this.dgProductHistory.Size = new System.Drawing.Size(1123, 394);
            this.dgProductHistory.TabIndex = 0;
            this.dgProductHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProductHistory_KeyDown);
            // 
            // dgcRsCode
            // 
            this.dgcRsCode.HeaderText = "RS CODE";
            this.dgcRsCode.Name = "dgcRsCode";
            this.dgcRsCode.ReadOnly = true;
            // 
            // dgcCustomerCode
            // 
            this.dgcCustomerCode.HeaderText = "CUSTOMER CODE";
            this.dgcCustomerCode.Name = "dgcCustomerCode";
            this.dgcCustomerCode.ReadOnly = true;
            // 
            // dgcCustomerName
            // 
            this.dgcCustomerName.HeaderText = "CUSTOMER NAME";
            this.dgcCustomerName.Name = "dgcCustomerName";
            this.dgcCustomerName.ReadOnly = true;
            // 
            // dgcDate
            // 
            this.dgcDate.HeaderText = "DATE";
            this.dgcDate.Name = "dgcDate";
            this.dgcDate.ReadOnly = true;
            // 
            // dgcQuotationNo
            // 
            this.dgcQuotationNo.HeaderText = "QUOT NO";
            this.dgcQuotationNo.Name = "dgcQuotationNo";
            this.dgcQuotationNo.ReadOnly = true;
            // 
            // dgcQuantity
            // 
            this.dgcQuantity.HeaderText = "QTY";
            this.dgcQuantity.Name = "dgcQuantity";
            this.dgcQuantity.ReadOnly = true;
            // 
            // dgcUP
            // 
            this.dgcUP.HeaderText = "U/P";
            this.dgcUP.Name = "dgcUP";
            this.dgcUP.ReadOnly = true;
            // 
            // dgcCurrency
            // 
            this.dgcCurrency.HeaderText = "CURR";
            this.dgcCurrency.Name = "dgcCurrency";
            this.dgcCurrency.ReadOnly = true;
            // 
            // dgLandingCost
            // 
            this.dgLandingCost.HeaderText = "LandingCost";
            this.dgLandingCost.Name = "dgLandingCost";
            this.dgLandingCost.ReadOnly = true;
            // 
            // dgMargin
            // 
            this.dgMargin.HeaderText = "Margin";
            this.dgMargin.Name = "dgMargin";
            this.dgMargin.ReadOnly = true;
            // 
            // dgcStatus
            // 
            this.dgcStatus.HeaderText = "ORDER STATUS";
            this.dgcStatus.Name = "dgcStatus";
            this.dgcStatus.ReadOnly = true;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnClose.Location = new System.Drawing.Point(1074, 412);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 52);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1085, 467);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Close";
            // 
            // ViewProductHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1138, 485);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgProductHistory);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1154, 524);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1154, 524);
            this.Name = "ViewProductHistory";
            this.Text = "ViewProductHistory";
            this.Load += new System.EventHandler(this.ViewProductHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProductHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRsCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQuotationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLandingCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMargin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcStatus;
    }
}