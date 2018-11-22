namespace LoginForm
{
    partial class frmQuotOrdersCurrency
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbStartMonth = new System.Windows.Forms.ComboBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgItemList = new System.Windows.Forms.DataGridView();
            this.label41 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbEndMonth = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkMonthGroup = new System.Windows.Forms.CheckBox();
            this.chkYearsGroup = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.txtNumbers = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCurrency2 = new System.Windows.Forms.Label();
            this.txtOrdersTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOrdersQty = new System.Windows.Forms.TextBox();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CurrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Years = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Months = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Month";
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
            this.cmbYear.TabIndex = 2;
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
            this.cmbStartMonth.TabIndex = 3;
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(480, 67);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(185, 21);
            this.cmbCity.TabIndex = 7;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(480, 37);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(185, 21);
            this.cmbCustomer.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Customer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgItemList);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1267, 359);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report List";
            // 
            // dgItemList
            // 
            this.dgItemList.AllowUserToAddRows = false;
            this.dgItemList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CurrName,
            this.Years,
            this.Months,
            this.QuotationTotal,
            this.QuotationQty,
            this.QuotationCurrency,
            this.SaleOrderTotal,
            this.SaleOrderQty,
            this.SaleOrderCurrency});
            this.dgItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItemList.Location = new System.Drawing.Point(3, 17);
            this.dgItemList.MultiSelect = false;
            this.dgItemList.Name = "dgItemList";
            this.dgItemList.ReadOnly = true;
            this.dgItemList.Size = new System.Drawing.Size(1261, 339);
            this.dgItemList.TabIndex = 0;
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label41.Location = new System.Drawing.Point(1220, 59);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 13);
            this.label41.TabIndex = 271;
            this.label41.Text = "Search";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.Location = new System.Drawing.Point(1215, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 52);
            this.btnSearch.TabIndex = 270;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
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
            this.cmbCurrency.Location = new System.Drawing.Point(480, 5);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(185, 21);
            this.cmbCurrency.TabIndex = 273;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 272;
            this.label5.Text = "Currency";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(666, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 21);
            this.button1.TabIndex = 285;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(666, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 21);
            this.button2.TabIndex = 286;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.cmbEndMonth.TabIndex = 288;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 287;
            this.label7.Text = "End Month";
            // 
            // chkMonthGroup
            // 
            this.chkMonthGroup.AutoSize = true;
            this.chkMonthGroup.Checked = true;
            this.chkMonthGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonthGroup.Location = new System.Drawing.Point(278, 42);
            this.chkMonthGroup.Name = "chkMonthGroup";
            this.chkMonthGroup.Size = new System.Drawing.Size(61, 17);
            this.chkMonthGroup.TabIndex = 335;
            this.chkMonthGroup.Text = "Months";
            this.chkMonthGroup.UseVisualStyleBackColor = true;
            this.chkMonthGroup.CheckedChanged += new System.EventHandler(this.chkMonthGroup_CheckedChanged);
            // 
            // chkYearsGroup
            // 
            this.chkYearsGroup.AutoSize = true;
            this.chkYearsGroup.Location = new System.Drawing.Point(278, 9);
            this.chkYearsGroup.Name = "chkYearsGroup";
            this.chkYearsGroup.Size = new System.Drawing.Size(53, 17);
            this.chkYearsGroup.TabIndex = 341;
            this.chkYearsGroup.Text = "Years";
            this.chkYearsGroup.UseVisualStyleBackColor = true;
            this.chkYearsGroup.CheckedChanged += new System.EventHandler(this.chkYearsGroup_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1133, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 343;
            this.label13.Text = "Export Excel";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.Location = new System.Drawing.Point(1138, 5);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExcel.TabIndex = 342;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtNumbers
            // 
            this.txtNumbers.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumbers.Location = new System.Drawing.Point(1063, 495);
            this.txtNumbers.Name = "txtNumbers";
            this.txtNumbers.Size = new System.Drawing.Size(67, 21);
            this.txtNumbers.TabIndex = 358;
            this.txtNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(749, 495);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(67, 21);
            this.txtValue.TabIndex = 357;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(867, 498);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(197, 14);
            this.label11.TabIndex = 356;
            this.label11.Text = "Quotation vs Orders (Numbers) :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(575, 498);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 14);
            this.label9.TabIndex = 355;
            this.label9.Text = "Quotation vs Orders (Value) :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1000, 472);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 353;
            this.label12.Text = "Orders Qty";
            // 
            // lblCurrency2
            // 
            this.lblCurrency2.AutoSize = true;
            this.lblCurrency2.Location = new System.Drawing.Point(1241, 472);
            this.lblCurrency2.Name = "lblCurrency2";
            this.lblCurrency2.Size = new System.Drawing.Size(35, 13);
            this.lblCurrency2.TabIndex = 352;
            this.lblCurrency2.Text = "label9";
            // 
            // txtOrdersTotal
            // 
            this.txtOrdersTotal.Location = new System.Drawing.Point(1174, 468);
            this.txtOrdersTotal.Name = "txtOrdersTotal";
            this.txtOrdersTotal.Size = new System.Drawing.Size(67, 21);
            this.txtOrdersTotal.TabIndex = 351;
            this.txtOrdersTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1133, 472);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 350;
            this.label10.Text = "Orders";
            // 
            // txtOrdersQty
            // 
            this.txtOrdersQty.Location = new System.Drawing.Point(1063, 468);
            this.txtOrdersQty.Name = "txtOrdersQty";
            this.txtOrdersQty.Size = new System.Drawing.Size(67, 21);
            this.txtOrdersQty.TabIndex = 354;
            this.txtOrdersQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(650, 469);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(67, 21);
            this.txtTotalQty.TabIndex = 349;
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(598, 472);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 348;
            this.label8.Text = "Quot Qty";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(817, 471);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(35, 13);
            this.lblCurrency.TabIndex = 347;
            this.lblCurrency.Text = "label7";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(749, 469);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(67, 21);
            this.txtTotal.TabIndex = 346;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(717, 472);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 345;
            this.label6.Text = "Quot";
            // 
            // CurrName
            // 
            this.CurrName.HeaderText = "Currency Name";
            this.CurrName.Name = "CurrName";
            this.CurrName.ReadOnly = true;
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
            dataGridViewCellStyle1.NullValue = null;
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
            // QuotationCurrency
            // 
            this.QuotationCurrency.HeaderText = "Quotation Value/Currency";
            this.QuotationCurrency.Name = "QuotationCurrency";
            this.QuotationCurrency.ReadOnly = true;
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
            // SaleOrderCurrency
            // 
            this.SaleOrderCurrency.HeaderText = "Sales Order Value/Currency";
            this.SaleOrderCurrency.Name = "SaleOrderCurrency";
            this.SaleOrderCurrency.ReadOnly = true;
            // 
            // frmQuotOrdersCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 523);
            this.Controls.Add(this.txtNumbers);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
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
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.chkYearsGroup);
            this.Controls.Add(this.chkMonthGroup);
            this.Controls.Add(this.cmbEndMonth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStartMonth);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1295, 534);
            this.Name = "frmQuotOrdersCurrency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quotation and SaleOrders Currency";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbStartMonth;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgItemList;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbEndMonth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkMonthGroup;
        private System.Windows.Forms.CheckBox chkYearsGroup;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtNumbers;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCurrency2;
        private System.Windows.Forms.TextBox txtOrdersTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOrdersQty;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Years;
        private System.Windows.Forms.DataGridViewTextBoxColumn Months;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderCurrency;
    }
}