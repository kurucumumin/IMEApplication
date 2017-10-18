namespace LoginForm.QuotationModule
{
    partial class FormQuotationMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgQuotation = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchStockNumber = new System.Windows.Forms.Button();
            this.chcCustStockNumber = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chcAllQuots = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datetimeEnd = new System.Windows.Forms.DateTimePicker();
            this.datetimeStart = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteQuotation = new System.Windows.Forms.Button();
            this.btnModifyQuotation = new System.Windows.Forms.Button();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnNewQuotation = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.quotationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rFQNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteForUsIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteForCustomerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forFinancelIsTrueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shippingMethodIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isItemCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isWeightCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCustomsDutiesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discOnSubTotal2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validationDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isVatValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotationDetailsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotation)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quotationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgQuotation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 681);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgQuotation
            // 
            this.dgQuotation.AllowUserToAddRows = false;
            this.dgQuotation.AllowUserToDeleteRows = false;
            this.dgQuotation.AllowUserToOrderColumns = true;
            this.dgQuotation.AutoGenerateColumns = false;
            this.dgQuotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rFQNoDataGridViewTextBoxColumn,
            this.customerIDDataGridViewTextBoxColumn,
            this.noteForUsIDDataGridViewTextBoxColumn,
            this.noteForCustomerIDDataGridViewTextBoxColumn,
            this.forFinancelIsTrueDataGridViewTextBoxColumn,
            this.shippingMethodIDDataGridViewTextBoxColumn,
            this.isItemCostDataGridViewTextBoxColumn,
            this.isWeightCostDataGridViewTextBoxColumn,
            this.isCustomsDutiesDataGridViewTextBoxColumn,
            this.discOnSubTotal2DataGridViewTextBoxColumn,
            this.extraChargesDataGridViewTextBoxColumn,
            this.subTotalDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.validationDayDataGridViewTextBoxColumn,
            this.paymentIDDataGridViewTextBoxColumn,
            this.currDataGridViewTextBoxColumn,
            this.currTypeDataGridViewTextBoxColumn,
            this.factorDataGridViewTextBoxColumn,
            this.isVatValueDataGridViewTextBoxColumn,
            this.vatValueDataGridViewTextBoxColumn,
            this.currNameDataGridViewTextBoxColumn,
            this.customerDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.note1DataGridViewTextBoxColumn,
            this.paymentMethodDataGridViewTextBoxColumn,
            this.quotationDetailsDataGridViewTextBoxColumn});
            this.dgQuotation.DataSource = this.quotationBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgQuotation.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgQuotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgQuotation.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgQuotation.Location = new System.Drawing.Point(3, 124);
            this.dgQuotation.Name = "dgQuotation";
            this.dgQuotation.ReadOnly = true;
            this.dgQuotation.RowTemplate.Height = 24;
            this.dgQuotation.Size = new System.Drawing.Size(1178, 442);
            this.dgQuotation.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchStockNumber);
            this.panel1.Controls.Add(this.chcCustStockNumber);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.chcAllQuots);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.datetimeEnd);
            this.panel1.Controls.Add(this.datetimeStart);
            this.panel1.Controls.Add(this.btnDeleteQuotation);
            this.panel1.Controls.Add(this.btnModifyQuotation);
            this.panel1.Controls.Add(this.btnRefreshList);
            this.panel1.Controls.Add(this.btnNewQuotation);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 115);
            this.panel1.TabIndex = 1;
            // 
            // btnSearchStockNumber
            // 
            this.btnSearchStockNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnSearchStockNumber.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnSearchStockNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStockNumber.Image = global::LoginForm.Properties.Resources.btnBackground;
            this.btnSearchStockNumber.Location = new System.Drawing.Point(895, 73);
            this.btnSearchStockNumber.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchStockNumber.Name = "btnSearchStockNumber";
            this.btnSearchStockNumber.Size = new System.Drawing.Size(192, 28);
            this.btnSearchStockNumber.TabIndex = 27;
            this.btnSearchStockNumber.Text = "Search Stock Number";
            this.btnSearchStockNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchStockNumber.UseVisualStyleBackColor = false;
            // 
            // chcCustStockNumber
            // 
            this.chcCustStockNumber.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcCustStockNumber.Location = new System.Drawing.Point(895, 48);
            this.chcCustStockNumber.Name = "chcCustStockNumber";
            this.chcCustStockNumber.Size = new System.Drawing.Size(192, 21);
            this.chcCustStockNumber.TabIndex = 26;
            this.chcCustStockNumber.Text = "Customer Stock Code";
            this.chcCustStockNumber.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(895, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(192, 24);
            this.textBox2.TabIndex = 25;
            // 
            // chcAllQuots
            // 
            this.chcAllQuots.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcAllQuots.Location = new System.Drawing.Point(699, 80);
            this.chcAllQuots.Name = "chcAllQuots";
            this.chcAllQuots.Size = new System.Drawing.Size(164, 21);
            this.chcAllQuots.TabIndex = 24;
            this.chcAllQuots.Text = "All Quotations";
            this.chcAllQuots.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(699, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 24);
            this.textBox1.TabIndex = 23;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(699, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 26);
            this.comboBox1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Start Date";
            // 
            // datetimeEnd
            // 
            this.datetimeEnd.CustomFormat = "dd-MM-yyyy";
            this.datetimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeEnd.Location = new System.Drawing.Point(89, 77);
            this.datetimeEnd.Name = "datetimeEnd";
            this.datetimeEnd.Size = new System.Drawing.Size(119, 24);
            this.datetimeEnd.TabIndex = 19;
            // 
            // datetimeStart
            // 
            this.datetimeStart.CustomFormat = "dd-MM-yyyy";
            this.datetimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeStart.Location = new System.Drawing.Point(89, 16);
            this.datetimeStart.Name = "datetimeStart";
            this.datetimeStart.Size = new System.Drawing.Size(119, 24);
            this.datetimeStart.TabIndex = 18;
            // 
            // btnDeleteQuotation
            // 
            this.btnDeleteQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnDeleteQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnDeleteQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteQuotation.Image = global::LoginForm.Properties.Resources.btnBackground;
            this.btnDeleteQuotation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteQuotation.Location = new System.Drawing.Point(535, 16);
            this.btnDeleteQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteQuotation.Name = "btnDeleteQuotation";
            this.btnDeleteQuotation.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnDeleteQuotation.Size = new System.Drawing.Size(88, 85);
            this.btnDeleteQuotation.TabIndex = 17;
            this.btnDeleteQuotation.Text = "Delete";
            this.btnDeleteQuotation.UseVisualStyleBackColor = false;
            // 
            // btnModifyQuotation
            // 
            this.btnModifyQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnModifyQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnModifyQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyQuotation.Image = global::LoginForm.Properties.Resources.btnBackground;
            this.btnModifyQuotation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModifyQuotation.Location = new System.Drawing.Point(450, 16);
            this.btnModifyQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnModifyQuotation.Name = "btnModifyQuotation";
            this.btnModifyQuotation.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnModifyQuotation.Size = new System.Drawing.Size(85, 85);
            this.btnModifyQuotation.TabIndex = 16;
            this.btnModifyQuotation.Text = "Modify";
            this.btnModifyQuotation.UseVisualStyleBackColor = false;
            this.btnModifyQuotation.Click += new System.EventHandler(this.btnModifyQuotation_Click);
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnRefreshList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshList.Location = new System.Drawing.Point(211, 16);
            this.btnRefreshList.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(77, 85);
            this.btnRefreshList.TabIndex = 14;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.UseVisualStyleBackColor = false;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // btnNewQuotation
            // 
            this.btnNewQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnNewQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnNewQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewQuotation.Image = global::LoginForm.Properties.Resources.btnBackground;
            this.btnNewQuotation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewQuotation.Location = new System.Drawing.Point(365, 16);
            this.btnNewQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewQuotation.Name = "btnNewQuotation";
            this.btnNewQuotation.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnNewQuotation.Size = new System.Drawing.Size(85, 85);
            this.btnNewQuotation.TabIndex = 1;
            this.btnNewQuotation.Text = "New";
            this.btnNewQuotation.UseVisualStyleBackColor = false;
            this.btnNewQuotation.Click += new System.EventHandler(this.btnNewQuotation_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 569);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 112);
            this.panel2.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::LoginForm.Properties.Resources.btnBackground;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(108, 15);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.button5.Size = new System.Drawing.Size(87, 85);
            this.button5.TabIndex = 8;
            this.button5.Text = "Print";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::LoginForm.Properties.Resources.btnBackground;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(15, 15);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.button4.Size = new System.Drawing.Size(87, 85);
            this.button4.TabIndex = 7;
            this.button4.Text = "Export to Excel";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // quotationBindingSource
            // 
            this.quotationBindingSource.DataSource = typeof(LoginForm.DataSet.Quotation);
            // 
            // rFQNoDataGridViewTextBoxColumn
            // 
            this.rFQNoDataGridViewTextBoxColumn.DataPropertyName = "RFQNo";
            this.rFQNoDataGridViewTextBoxColumn.HeaderText = "RFQNo";
            this.rFQNoDataGridViewTextBoxColumn.Name = "rFQNoDataGridViewTextBoxColumn";
            this.rFQNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerIDDataGridViewTextBoxColumn
            // 
            this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
            this.customerIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noteForUsIDDataGridViewTextBoxColumn
            // 
            this.noteForUsIDDataGridViewTextBoxColumn.DataPropertyName = "NoteForUsID";
            this.noteForUsIDDataGridViewTextBoxColumn.HeaderText = "NoteForUsID";
            this.noteForUsIDDataGridViewTextBoxColumn.Name = "noteForUsIDDataGridViewTextBoxColumn";
            this.noteForUsIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noteForCustomerIDDataGridViewTextBoxColumn
            // 
            this.noteForCustomerIDDataGridViewTextBoxColumn.DataPropertyName = "NoteForCustomerID";
            this.noteForCustomerIDDataGridViewTextBoxColumn.HeaderText = "NoteForCustomerID";
            this.noteForCustomerIDDataGridViewTextBoxColumn.Name = "noteForCustomerIDDataGridViewTextBoxColumn";
            this.noteForCustomerIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // forFinancelIsTrueDataGridViewTextBoxColumn
            // 
            this.forFinancelIsTrueDataGridViewTextBoxColumn.DataPropertyName = "ForFinancelIsTrue";
            this.forFinancelIsTrueDataGridViewTextBoxColumn.HeaderText = "ForFinancelIsTrue";
            this.forFinancelIsTrueDataGridViewTextBoxColumn.Name = "forFinancelIsTrueDataGridViewTextBoxColumn";
            this.forFinancelIsTrueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shippingMethodIDDataGridViewTextBoxColumn
            // 
            this.shippingMethodIDDataGridViewTextBoxColumn.DataPropertyName = "ShippingMethodID";
            this.shippingMethodIDDataGridViewTextBoxColumn.HeaderText = "ShippingMethodID";
            this.shippingMethodIDDataGridViewTextBoxColumn.Name = "shippingMethodIDDataGridViewTextBoxColumn";
            this.shippingMethodIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isItemCostDataGridViewTextBoxColumn
            // 
            this.isItemCostDataGridViewTextBoxColumn.DataPropertyName = "IsItemCost";
            this.isItemCostDataGridViewTextBoxColumn.HeaderText = "IsItemCost";
            this.isItemCostDataGridViewTextBoxColumn.Name = "isItemCostDataGridViewTextBoxColumn";
            this.isItemCostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isWeightCostDataGridViewTextBoxColumn
            // 
            this.isWeightCostDataGridViewTextBoxColumn.DataPropertyName = "IsWeightCost";
            this.isWeightCostDataGridViewTextBoxColumn.HeaderText = "IsWeightCost";
            this.isWeightCostDataGridViewTextBoxColumn.Name = "isWeightCostDataGridViewTextBoxColumn";
            this.isWeightCostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isCustomsDutiesDataGridViewTextBoxColumn
            // 
            this.isCustomsDutiesDataGridViewTextBoxColumn.DataPropertyName = "IsCustomsDuties";
            this.isCustomsDutiesDataGridViewTextBoxColumn.HeaderText = "IsCustomsDuties";
            this.isCustomsDutiesDataGridViewTextBoxColumn.Name = "isCustomsDutiesDataGridViewTextBoxColumn";
            this.isCustomsDutiesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // discOnSubTotal2DataGridViewTextBoxColumn
            // 
            this.discOnSubTotal2DataGridViewTextBoxColumn.DataPropertyName = "DiscOnSubTotal2";
            this.discOnSubTotal2DataGridViewTextBoxColumn.HeaderText = "DiscOnSubTotal2";
            this.discOnSubTotal2DataGridViewTextBoxColumn.Name = "discOnSubTotal2DataGridViewTextBoxColumn";
            this.discOnSubTotal2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // extraChargesDataGridViewTextBoxColumn
            // 
            this.extraChargesDataGridViewTextBoxColumn.DataPropertyName = "ExtraCharges";
            this.extraChargesDataGridViewTextBoxColumn.HeaderText = "ExtraCharges";
            this.extraChargesDataGridViewTextBoxColumn.Name = "extraChargesDataGridViewTextBoxColumn";
            this.extraChargesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
            this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "StartDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // validationDayDataGridViewTextBoxColumn
            // 
            this.validationDayDataGridViewTextBoxColumn.DataPropertyName = "ValidationDay";
            this.validationDayDataGridViewTextBoxColumn.HeaderText = "ValidationDay";
            this.validationDayDataGridViewTextBoxColumn.Name = "validationDayDataGridViewTextBoxColumn";
            this.validationDayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paymentIDDataGridViewTextBoxColumn
            // 
            this.paymentIDDataGridViewTextBoxColumn.DataPropertyName = "PaymentID";
            this.paymentIDDataGridViewTextBoxColumn.HeaderText = "PaymentID";
            this.paymentIDDataGridViewTextBoxColumn.Name = "paymentIDDataGridViewTextBoxColumn";
            this.paymentIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currDataGridViewTextBoxColumn
            // 
            this.currDataGridViewTextBoxColumn.DataPropertyName = "Curr";
            this.currDataGridViewTextBoxColumn.HeaderText = "Curr";
            this.currDataGridViewTextBoxColumn.Name = "currDataGridViewTextBoxColumn";
            this.currDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currTypeDataGridViewTextBoxColumn
            // 
            this.currTypeDataGridViewTextBoxColumn.DataPropertyName = "CurrType";
            this.currTypeDataGridViewTextBoxColumn.HeaderText = "CurrType";
            this.currTypeDataGridViewTextBoxColumn.Name = "currTypeDataGridViewTextBoxColumn";
            this.currTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factorDataGridViewTextBoxColumn
            // 
            this.factorDataGridViewTextBoxColumn.DataPropertyName = "Factor";
            this.factorDataGridViewTextBoxColumn.HeaderText = "Factor";
            this.factorDataGridViewTextBoxColumn.Name = "factorDataGridViewTextBoxColumn";
            this.factorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isVatValueDataGridViewTextBoxColumn
            // 
            this.isVatValueDataGridViewTextBoxColumn.DataPropertyName = "IsVatValue";
            this.isVatValueDataGridViewTextBoxColumn.HeaderText = "IsVatValue";
            this.isVatValueDataGridViewTextBoxColumn.Name = "isVatValueDataGridViewTextBoxColumn";
            this.isVatValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vatValueDataGridViewTextBoxColumn
            // 
            this.vatValueDataGridViewTextBoxColumn.DataPropertyName = "VatValue";
            this.vatValueDataGridViewTextBoxColumn.HeaderText = "VatValue";
            this.vatValueDataGridViewTextBoxColumn.Name = "vatValueDataGridViewTextBoxColumn";
            this.vatValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currNameDataGridViewTextBoxColumn
            // 
            this.currNameDataGridViewTextBoxColumn.DataPropertyName = "CurrName";
            this.currNameDataGridViewTextBoxColumn.HeaderText = "CurrName";
            this.currNameDataGridViewTextBoxColumn.Name = "currNameDataGridViewTextBoxColumn";
            this.currNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            this.customerDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "Note";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // note1DataGridViewTextBoxColumn
            // 
            this.note1DataGridViewTextBoxColumn.DataPropertyName = "Note1";
            this.note1DataGridViewTextBoxColumn.HeaderText = "Note1";
            this.note1DataGridViewTextBoxColumn.Name = "note1DataGridViewTextBoxColumn";
            this.note1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
            this.paymentMethodDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quotationDetailsDataGridViewTextBoxColumn
            // 
            this.quotationDetailsDataGridViewTextBoxColumn.DataPropertyName = "QuotationDetails";
            this.quotationDetailsDataGridViewTextBoxColumn.HeaderText = "QuotationDetails";
            this.quotationDetailsDataGridViewTextBoxColumn.Name = "quotationDetailsDataGridViewTextBoxColumn";
            this.quotationDetailsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormQuotationMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "FormQuotationMain";
            this.Text = "Quotation";
            this.Load += new System.EventHandler(this.FormQuotationMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quotationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgQuotation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteQuotation;
        private System.Windows.Forms.Button btnModifyQuotation;
        private System.Windows.Forms.Button btnNewQuotation;
        private System.Windows.Forms.DateTimePicker datetimeStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datetimeEnd;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.CheckBox chcAllQuots;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSearchStockNumber;
        private System.Windows.Forms.CheckBox chcCustStockNumber;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rFQNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteForUsIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteForCustomerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn forFinancelIsTrueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shippingMethodIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isItemCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isWeightCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isCustomsDutiesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discOnSubTotal2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn validationDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isVatValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn note1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotationDetailsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource quotationBindingSource;
    }
}