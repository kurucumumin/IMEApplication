namespace LoginForm
{
    partial class frmQuotOrders
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
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgQuotList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCurrency2 = new System.Windows.Forms.Label();
            this.txtOrdersTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOrdersQty = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.cmbEndMonth = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStartMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkMonthGroup = new System.Windows.Forms.CheckBox();
            this.txtNumbers = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkYearsGroup = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.Years = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Months = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(650, 469);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(67, 20);
            this.txtTotalQty.TabIndex = 302;
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(598, 472);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 301;
            this.label8.Text = "Quot Qty";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(817, 471);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(35, 13);
            this.lblCurrency.TabIndex = 300;
            this.lblCurrency.Text = "label7";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(749, 469);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(67, 20);
            this.txtTotal.TabIndex = 299;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(717, 472);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 298;
            this.label6.Text = "Quot";
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
            this.dgQuotList.Size = new System.Drawing.Size(1265, 340);
            this.dgQuotList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgQuotList);
            this.groupBox1.Location = new System.Drawing.Point(8, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1271, 359);
            this.groupBox1.TabIndex = 293;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quotation List";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1003, 472);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 314;
            this.label12.Text = "Orders Qty";
            // 
            // lblCurrency2
            // 
            this.lblCurrency2.AutoSize = true;
            this.lblCurrency2.Location = new System.Drawing.Point(1241, 472);
            this.lblCurrency2.Name = "lblCurrency2";
            this.lblCurrency2.Size = new System.Drawing.Size(35, 13);
            this.lblCurrency2.TabIndex = 313;
            this.lblCurrency2.Text = "label9";
            // 
            // txtOrdersTotal
            // 
            this.txtOrdersTotal.Location = new System.Drawing.Point(1174, 468);
            this.txtOrdersTotal.Name = "txtOrdersTotal";
            this.txtOrdersTotal.Size = new System.Drawing.Size(67, 20);
            this.txtOrdersTotal.TabIndex = 312;
            this.txtOrdersTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1133, 472);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 311;
            this.label10.Text = "Orders";
            // 
            // txtOrdersQty
            // 
            this.txtOrdersQty.Location = new System.Drawing.Point(1063, 468);
            this.txtOrdersQty.Name = "txtOrdersQty";
            this.txtOrdersQty.Size = new System.Drawing.Size(67, 20);
            this.txtOrdersQty.TabIndex = 315;
            this.txtOrdersQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.Location = new System.Drawing.Point(1212, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 52);
            this.btnSearch.TabIndex = 319;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label41.Location = new System.Drawing.Point(1217, 65);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 13);
            this.label41.TabIndex = 318;
            this.label41.Text = "Search";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEndMonth
            // 
            this.cmbEndMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndMonth.FormattingEnabled = true;
            this.cmbEndMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbEndMonth.Location = new System.Drawing.Point(87, 68);
            this.cmbEndMonth.Name = "cmbEndMonth";
            this.cmbEndMonth.Size = new System.Drawing.Size(185, 21);
            this.cmbEndMonth.TabIndex = 333;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 332;
            this.label7.Text = "End Month";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(662, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 21);
            this.button2.TabIndex = 331;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 21);
            this.button1.TabIndex = 330;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(476, 36);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(185, 21);
            this.cmbCity.TabIndex = 327;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(476, 6);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(185, 21);
            this.cmbCustomer.TabIndex = 326;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 325;
            this.label3.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 324;
            this.label4.Text = "Customer";
            // 
            // cmbStartMonth
            // 
            this.cmbStartMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartMonth.FormattingEnabled = true;
            this.cmbStartMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbStartMonth.Location = new System.Drawing.Point(87, 38);
            this.cmbStartMonth.Name = "cmbStartMonth";
            this.cmbStartMonth.Size = new System.Drawing.Size(185, 21);
            this.cmbStartMonth.TabIndex = 323;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2018",
            "2017",
            "2016"});
            this.cmbYear.Location = new System.Drawing.Point(87, 6);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(185, 21);
            this.cmbYear.TabIndex = 322;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 321;
            this.label2.Text = "Start Month";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 320;
            this.label1.Text = "Year";
            // 
            // chkMonthGroup
            // 
            this.chkMonthGroup.AutoSize = true;
            this.chkMonthGroup.Checked = true;
            this.chkMonthGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonthGroup.Location = new System.Drawing.Point(278, 44);
            this.chkMonthGroup.Name = "chkMonthGroup";
            this.chkMonthGroup.Size = new System.Drawing.Size(61, 17);
            this.chkMonthGroup.TabIndex = 334;
            this.chkMonthGroup.Text = "Months";
            this.chkMonthGroup.UseVisualStyleBackColor = true;
            this.chkMonthGroup.CheckedChanged += new System.EventHandler(this.chkMonthGroup_CheckedChanged);
            // 
            // txtNumbers
            // 
            this.txtNumbers.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumbers.Location = new System.Drawing.Point(1063, 495);
            this.txtNumbers.Name = "txtNumbers";
            this.txtNumbers.Size = new System.Drawing.Size(67, 21);
            this.txtNumbers.TabIndex = 344;
            this.txtNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(749, 495);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(67, 21);
            this.txtValue.TabIndex = 343;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(867, 498);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(197, 14);
            this.label11.TabIndex = 342;
            this.label11.Text = "Quotation vs Orders (Numbers) :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(575, 498);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 14);
            this.label9.TabIndex = 341;
            this.label9.Text = "Quotation vs Orders (Value) :";
            // 
            // chkYearsGroup
            // 
            this.chkYearsGroup.AutoSize = true;
            this.chkYearsGroup.Location = new System.Drawing.Point(278, 8);
            this.chkYearsGroup.Name = "chkYearsGroup";
            this.chkYearsGroup.Size = new System.Drawing.Size(53, 17);
            this.chkYearsGroup.TabIndex = 345;
            this.chkYearsGroup.Text = "Years";
            this.chkYearsGroup.UseVisualStyleBackColor = true;
            this.chkYearsGroup.CheckedChanged += new System.EventHandler(this.chkYearsGroup_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1128, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 347;
            this.label13.Text = "Export Excel";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.Location = new System.Drawing.Point(1136, 10);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExcel.TabIndex = 346;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
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
            // frmQuotOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 533);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.chkYearsGroup);
            this.Controls.Add(this.txtNumbers);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkMonthGroup);
            this.Controls.Add(this.cmbEndMonth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStartMonth);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCurrency2);
            this.Controls.Add(this.txtOrdersTotal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOrdersQty);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1295, 572);
            this.MinimumSize = new System.Drawing.Size(1295, 572);
            this.Name = "frmQuotOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quot vs Orders";
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgQuotList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCurrency2;
        private System.Windows.Forms.TextBox txtOrdersTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOrdersQty;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox cmbEndMonth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStartMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkMonthGroup;
        private System.Windows.Forms.TextBox txtNumbers;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkYearsGroup;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Years;
        private System.Windows.Forms.DataGridViewTextBoxColumn Months;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderQty;
    }
}