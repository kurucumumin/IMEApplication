namespace LoginForm
{
    partial class frmAreaSalesReport
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
            this.label13 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.dgArea = new System.Windows.Forms.DataGridView();
            this.chkSalesInvoice = new System.Windows.Forms.CheckBox();
            this.chkSalesOrders = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgArea)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1207, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 354;
            this.label13.Text = "Export Excel";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.Location = new System.Drawing.Point(1213, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(61, 48);
            this.btnExcel.TabIndex = 353;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.Location = new System.Drawing.Point(1289, 55);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 13);
            this.label41.TabIndex = 352;
            this.label41.Text = "Search";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.Location = new System.Drawing.Point(1277, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 48);
            this.btnSearch.TabIndex = 351;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 350;
            this.label1.Text = "Year";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021"});
            this.cmbYear.Location = new System.Drawing.Point(55, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(182, 21);
            this.cmbYear.TabIndex = 349;
            // 
            // dgArea
            // 
            this.dgArea.AllowUserToAddRows = false;
            this.dgArea.AllowUserToDeleteRows = false;
            this.dgArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArea.Location = new System.Drawing.Point(12, 71);
            this.dgArea.Name = "dgArea";
            this.dgArea.ReadOnly = true;
            this.dgArea.Size = new System.Drawing.Size(1326, 410);
            this.dgArea.TabIndex = 348;
            // 
            // chkSalesInvoice
            // 
            this.chkSalesInvoice.AutoSize = true;
            this.chkSalesInvoice.Location = new System.Drawing.Point(635, 23);
            this.chkSalesInvoice.Name = "chkSalesInvoice";
            this.chkSalesInvoice.Size = new System.Drawing.Size(89, 17);
            this.chkSalesInvoice.TabIndex = 356;
            this.chkSalesInvoice.Text = "Sales Invoice";
            this.chkSalesInvoice.UseVisualStyleBackColor = true;
            this.chkSalesInvoice.CheckedChanged += new System.EventHandler(this.chkSalesInvoice_CheckedChanged);
            // 
            // chkSalesOrders
            // 
            this.chkSalesOrders.AutoSize = true;
            this.chkSalesOrders.Checked = true;
            this.chkSalesOrders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSalesOrders.Location = new System.Drawing.Point(513, 23);
            this.chkSalesOrders.Name = "chkSalesOrders";
            this.chkSalesOrders.Size = new System.Drawing.Size(87, 17);
            this.chkSalesOrders.TabIndex = 355;
            this.chkSalesOrders.Text = "Sales Orders";
            this.chkSalesOrders.UseVisualStyleBackColor = true;
            this.chkSalesOrders.CheckedChanged += new System.EventHandler(this.chkSalesOrders_CheckedChanged);
            // 
            // frmAreaSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 486);
            this.Controls.Add(this.chkSalesInvoice);
            this.Controls.Add(this.chkSalesOrders);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.dgArea);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1364, 525);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1364, 525);
            this.Name = "frmAreaSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Area Sales Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAreaSalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.DataGridView dgArea;
        private System.Windows.Forms.CheckBox chkSalesInvoice;
        private System.Windows.Forms.CheckBox chkSalesOrders;
    }
}