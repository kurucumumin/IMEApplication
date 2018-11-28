namespace LoginForm.Report
{
    partial class frmQuotOrdersDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label13 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgQuotList = new System.Windows.Forms.DataGridView();
            this.Years = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Months = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotList)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1134, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 351;
            this.label13.Text = "Export Excel";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.Location = new System.Drawing.Point(1142, 9);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExcel.TabIndex = 350;
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.Location = new System.Drawing.Point(1218, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 52);
            this.btnSearch.TabIndex = 349;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label41.Location = new System.Drawing.Point(1223, 64);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 13);
            this.label41.TabIndex = 348;
            this.label41.Text = "Search";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgQuotList);
            this.groupBox1.Location = new System.Drawing.Point(4, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1271, 434);
            this.groupBox1.TabIndex = 352;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quotation List";
            // 
            // dgQuotList
            // 
            this.dgQuotList.AllowUserToAddRows = false;
            this.dgQuotList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgQuotList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Years,
            this.Months,
            this.QuotationTotal,
            this.QuotationQty,
            this.SaleOrderTotal,
            this.SaleOrderQty});
            this.dgQuotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgQuotList.Location = new System.Drawing.Point(3, 16);
            this.dgQuotList.MultiSelect = false;
            this.dgQuotList.Name = "dgQuotList";
            this.dgQuotList.ReadOnly = true;
            this.dgQuotList.Size = new System.Drawing.Size(1265, 415);
            this.dgQuotList.TabIndex = 0;
            // 
            // Years
            // 
            this.Years.HeaderText = "Year";
            this.Years.Name = "Years";
            this.Years.ReadOnly = true;
            // 
            // Months
            // 
            this.Months.HeaderText = "Month";
            this.Months.Name = "Months";
            this.Months.ReadOnly = true;
            // 
            // QuotationTotal
            // 
            dataGridViewCellStyle1.Format = "N2";
            this.QuotationTotal.DefaultCellStyle = dataGridViewCellStyle1;
            this.QuotationTotal.HeaderText = "Quotation Value";
            this.QuotationTotal.Name = "QuotationTotal";
            this.QuotationTotal.ReadOnly = true;
            // 
            // QuotationQty
            // 
            this.QuotationQty.HeaderText = "#ofQuotes";
            this.QuotationQty.Name = "QuotationQty";
            this.QuotationQty.ReadOnly = true;
            // 
            // SaleOrderTotal
            // 
            dataGridViewCellStyle2.Format = "N2";
            this.SaleOrderTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.SaleOrderTotal.HeaderText = "Sales Order Value";
            this.SaleOrderTotal.Name = "SaleOrderTotal";
            this.SaleOrderTotal.ReadOnly = true;
            // 
            // SaleOrderQty
            // 
            this.SaleOrderQty.HeaderText = "#ofSO";
            this.SaleOrderQty.Name = "SaleOrderQty";
            this.SaleOrderQty.ReadOnly = true;
            // 
            // frmQuotOrdersDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 533);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label41);
            this.MaximumSize = new System.Drawing.Size(1295, 572);
            this.MinimumSize = new System.Drawing.Size(1295, 572);
            this.Name = "frmQuotOrdersDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quottaions vs Orders Details";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgQuotList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Years;
        private System.Windows.Forms.DataGridViewTextBoxColumn Months;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderQty;
    }
}