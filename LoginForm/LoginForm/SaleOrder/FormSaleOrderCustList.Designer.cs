namespace LoginForm.SaleOrder
{
    partial class FormSaleOrderCustList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCustomerList = new System.Windows.Forms.ListBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgQuotations = new System.Windows.Forms.DataGridView();
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
            this.factorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isVatValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rFQNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotationMainContactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotationBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtSearchCustomer);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbCustomerList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(16);
            this.panel2.Size = new System.Drawing.Size(293, 506);
            this.panel2.TabIndex = 12;
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchCustomer.Location = new System.Drawing.Point(16, 48);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(259, 24);
            this.txtSearchCustomer.TabIndex = 10;
            this.txtSearchCustomer.TextChanged += new System.EventHandler(this.txtSearchCustomer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Customer List";
            // 
            // lbCustomerList
            // 
            this.lbCustomerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCustomerList.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.customerBindingSource, "ID", true));
            this.lbCustomerList.DataSource = this.customerBindingSource;
            this.lbCustomerList.DisplayMember = "c_name";
            this.lbCustomerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomerList.FormattingEnabled = true;
            this.lbCustomerList.ItemHeight = 20;
            this.lbCustomerList.Location = new System.Drawing.Point(16, 91);
            this.lbCustomerList.Margin = new System.Windows.Forms.Padding(4);
            this.lbCustomerList.Name = "lbCustomerList";
            this.lbCustomerList.Size = new System.Drawing.Size(259, 364);
            this.lbCustomerList.TabIndex = 8;
            this.lbCustomerList.ValueMember = "ID";
            this.lbCustomerList.SelectedValueChanged += new System.EventHandler(this.lbCustomerList_SelectedValueChanged);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(LoginForm.DataSet.Customer);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 506);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1172, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(112)))), ((int)(((byte)(67)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(970, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 98);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(1070, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 98);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1172, 606);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1172, 506);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(296, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(873, 500);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgQuotations);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quotations";
            // 
            // dgQuotations
            // 
            this.dgQuotations.AllowUserToAddRows = false;
            this.dgQuotations.AllowUserToDeleteRows = false;
            this.dgQuotations.AutoGenerateColumns = false;
            this.dgQuotations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.factorDataGridViewTextBoxColumn,
            this.isVatValueDataGridViewTextBoxColumn,
            this.vatValueDataGridViewTextBoxColumn,
            this.currNameDataGridViewTextBoxColumn,
            this.QuotationNo,
            this.rFQNoDataGridViewTextBoxColumn,
            this.currTypeDataGridViewTextBoxColumn,
            this.quotationMainContactDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.note1DataGridViewTextBoxColumn,
            this.paymentMethodDataGridViewTextBoxColumn});
            this.dgQuotations.DataSource = this.quotationBindingSource;
            this.dgQuotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgQuotations.Location = new System.Drawing.Point(3, 22);
            this.dgQuotations.Name = "dgQuotations";
            this.dgQuotations.ReadOnly = true;
            this.dgQuotations.RowTemplate.Height = 24;
            this.dgQuotations.Size = new System.Drawing.Size(847, 200);
            this.dgQuotations.TabIndex = 0;
            this.dgQuotations.SelectionChanged += new System.EventHandler(this.dgQuotations_SelectionChanged);
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
            // QuotationNo
            // 
            this.QuotationNo.DataPropertyName = "QuotationNo";
            this.QuotationNo.HeaderText = "QuotationNo";
            this.QuotationNo.Name = "QuotationNo";
            this.QuotationNo.ReadOnly = true;
            // 
            // rFQNoDataGridViewTextBoxColumn
            // 
            this.rFQNoDataGridViewTextBoxColumn.DataPropertyName = "RFQNo";
            this.rFQNoDataGridViewTextBoxColumn.HeaderText = "RFQNo";
            this.rFQNoDataGridViewTextBoxColumn.Name = "rFQNoDataGridViewTextBoxColumn";
            this.rFQNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currTypeDataGridViewTextBoxColumn
            // 
            this.currTypeDataGridViewTextBoxColumn.DataPropertyName = "CurrType";
            this.currTypeDataGridViewTextBoxColumn.HeaderText = "CurrType";
            this.currTypeDataGridViewTextBoxColumn.Name = "currTypeDataGridViewTextBoxColumn";
            this.currTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quotationMainContactDataGridViewTextBoxColumn
            // 
            this.quotationMainContactDataGridViewTextBoxColumn.DataPropertyName = "QuotationMainContact";
            this.quotationMainContactDataGridViewTextBoxColumn.HeaderText = "QuotationMainContact";
            this.quotationMainContactDataGridViewTextBoxColumn.Name = "quotationMainContactDataGridViewTextBoxColumn";
            this.quotationMainContactDataGridViewTextBoxColumn.ReadOnly = true;
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
            // quotationBindingSource
            // 
            this.quotationBindingSource.DataSource = typeof(LoginForm.DataSet.Quotation);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(853, 231);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Items";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.dgItems, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 17);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(853, 214);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // dgItems
            // 
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.Location = new System.Drawing.Point(3, 3);
            this.dgItems.Name = "dgItems";
            this.dgItems.RowTemplate.Height = 24;
            this.dgItems.Size = new System.Drawing.Size(847, 168);
            this.dgItems.TabIndex = 0;
            // 
            // FormSaleOrderCustList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 606);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1137, 645);
            this.Name = "FormSaleOrderCustList";
            this.Text = "New Sale Order";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSaleOrderCustList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotationBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lbCustomerList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgQuotations;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource quotationBindingSource;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn factorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isVatValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rFQNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotationMainContactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn note1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
    }
}