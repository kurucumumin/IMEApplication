
namespace LoginForm
{
    partial class frmExchangeRate
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblExchangeRateValidator = new System.Windows.Forms.Label();
            this.lblCurrencyValidator = new System.Windows.Forms.Label();
            this.pnlExchange = new System.Windows.Forms.Panel();
            this.lblEqual = new System.Windows.Forms.Label();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnCurrencyAdd = new System.Windows.Forms.Button();
            this.lblExchangeaRate = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDatefrom = new System.Windows.Forms.TextBox();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSearchClear = new System.Windows.Forms.Button();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.cmbCurrencyRate = new System.Windows.Forms.ComboBox();
            this.lblCurrencySearch = new System.Windows.Forms.Label();
            this.dgvExchangeRate = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.pnlExchange.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchangeRate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.lblExchangeRateValidator);
            this.groupBox1.Controls.Add(this.lblCurrencyValidator);
            this.groupBox1.Controls.Add(this.pnlExchange);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.btnCurrencyAdd);
            this.groupBox1.Controls.Add(this.lblExchangeaRate);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txtNarration);
            this.groupBox1.Controls.Add(this.txtExchangeRate);
            this.groupBox1.Controls.Add(this.lblNarration);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.lblCurrency);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(24, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1019, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exchange rate";
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(727, 27);
            this.txtDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(237, 22);
            this.txtDate.TabIndex = 2;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // lblExchangeRateValidator
            // 
            this.lblExchangeRateValidator.AutoSize = true;
            this.lblExchangeRateValidator.ForeColor = System.Drawing.Color.Red;
            this.lblExchangeRateValidator.Location = new System.Drawing.Point(425, 59);
            this.lblExchangeRateValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblExchangeRateValidator.Name = "lblExchangeRateValidator";
            this.lblExchangeRateValidator.Size = new System.Drawing.Size(13, 17);
            this.lblExchangeRateValidator.TabIndex = 139;
            this.lblExchangeRateValidator.Text = "*";
            // 
            // lblCurrencyValidator
            // 
            this.lblCurrencyValidator.AutoSize = true;
            this.lblCurrencyValidator.ForeColor = System.Drawing.Color.Red;
            this.lblCurrencyValidator.Location = new System.Drawing.Point(425, 32);
            this.lblCurrencyValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblCurrencyValidator.Name = "lblCurrencyValidator";
            this.lblCurrencyValidator.Size = new System.Drawing.Size(13, 17);
            this.lblCurrencyValidator.TabIndex = 1;
            this.lblCurrencyValidator.Text = "*";
            // 
            // pnlExchange
            // 
            this.pnlExchange.Controls.Add(this.lblEqual);
            this.pnlExchange.Controls.Add(this.lblSymbol);
            this.pnlExchange.Controls.Add(this.lblRate);
            this.pnlExchange.Location = new System.Drawing.Point(151, 92);
            this.pnlExchange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlExchange.Name = "pnlExchange";
            this.pnlExchange.Size = new System.Drawing.Size(380, 75);
            this.pnlExchange.TabIndex = 137;
            this.pnlExchange.Visible = false;
            // 
            // lblEqual
            // 
            this.lblEqual.AutoSize = true;
            this.lblEqual.ForeColor = System.Drawing.Color.White;
            this.lblEqual.Location = new System.Drawing.Point(168, 25);
            this.lblEqual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEqual.Name = "lblEqual";
            this.lblEqual.Size = new System.Drawing.Size(16, 17);
            this.lblEqual.TabIndex = 120;
            this.lblEqual.Text = "=";
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.ForeColor = System.Drawing.Color.White;
            this.lblSymbol.Location = new System.Drawing.Point(55, 25);
            this.lblSymbol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(0, 17);
            this.lblSymbol.TabIndex = 118;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.ForeColor = System.Drawing.Color.White;
            this.lblRate.Location = new System.Drawing.Point(207, 25);
            this.lblRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(0, 17);
            this.lblRate.TabIndex = 119;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(963, 27);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(29, 22);
            this.dtpDate.TabIndex = 136;
            this.dtpDate.TabStop = false;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // btnCurrencyAdd
            // 
            this.btnCurrencyAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnCurrencyAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCurrencyAdd.FlatAppearance.BorderSize = 0;
            this.btnCurrencyAdd.ForeColor = System.Drawing.Color.Black;
            this.btnCurrencyAdd.Location = new System.Drawing.Point(451, 27);
            this.btnCurrencyAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCurrencyAdd.Name = "btnCurrencyAdd";
            this.btnCurrencyAdd.Size = new System.Drawing.Size(27, 25);
            this.btnCurrencyAdd.TabIndex = 1;
            this.btnCurrencyAdd.Text = "+";
            this.btnCurrencyAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCurrencyAdd.UseVisualStyleBackColor = false;
            this.btnCurrencyAdd.Click += new System.EventHandler(this.btnCurrencyAdd_Click);
            // 
            // lblExchangeaRate
            // 
            this.lblExchangeaRate.AutoSize = true;
            this.lblExchangeaRate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblExchangeaRate.Location = new System.Drawing.Point(21, 59);
            this.lblExchangeaRate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblExchangeaRate.Name = "lblExchangeaRate";
            this.lblExchangeaRate.Size = new System.Drawing.Size(104, 17);
            this.lblExchangeaRate.TabIndex = 135;
            this.lblExchangeaRate.Text = "Exchange Rate";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(583, 27);
            this.lblDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 17);
            this.lblDate.TabIndex = 134;
            this.lblDate.Text = "Date";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(151, 27);
            this.cmbCurrency.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(265, 24);
            this.cmbCurrency.TabIndex = 0;
            this.cmbCurrency.SelectedValueChanged += new System.EventHandler(this.cmbCurrency_SelectedValueChanged);
            this.cmbCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCurrency_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(880, 175);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 33);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(727, 59);
            this.txtNarration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(265, 61);
            this.txtNarration.TabIndex = 4;
            this.txtNarration.Enter += new System.EventHandler(this.txtNarration_Enter);
            this.txtNarration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNarration_KeyDown);
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(151, 59);
            this.txtExchangeRate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtExchangeRate.MaxLength = 10;
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(265, 22);
            this.txtExchangeRate.TabIndex = 3;
            this.txtExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExchangeRate.TextChanged += new System.EventHandler(this.txtExchangeRate_TextChanged);
            this.txtExchangeRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExchangeRate_KeyDown);
            this.txtExchangeRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExchangeRate_KeyPress);
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNarration.Location = new System.Drawing.Point(584, 63);
            this.lblNarration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(67, 17);
            this.lblNarration.TabIndex = 133;
            this.lblNarration.Text = "Narration";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(759, 175);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 33);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrency.Location = new System.Drawing.Point(21, 27);
            this.lblCurrency.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(65, 17);
            this.lblCurrency.TabIndex = 132;
            this.lblCurrency.Text = "Currency";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(516, 175);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(637, 175);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 33);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDatefrom);
            this.groupBox2.Controls.Add(this.txtDateTo);
            this.groupBox2.Controls.Add(this.dtpDateTo);
            this.groupBox2.Controls.Add(this.dtpDateFrom);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.btnSearchClear);
            this.groupBox2.Controls.Add(this.lblDateFrom);
            this.groupBox2.Controls.Add(this.lblDateTo);
            this.groupBox2.Controls.Add(this.cmbCurrencyRate);
            this.groupBox2.Controls.Add(this.lblCurrencySearch);
            this.groupBox2.Controls.Add(this.dgvExchangeRate);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(24, 270);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1019, 453);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // txtDatefrom
            // 
            this.txtDatefrom.Location = new System.Drawing.Point(721, 26);
            this.txtDatefrom.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtDatefrom.Name = "txtDatefrom";
            this.txtDatefrom.Size = new System.Drawing.Size(235, 22);
            this.txtDatefrom.TabIndex = 1;
            this.txtDatefrom.TextChanged += new System.EventHandler(this.txtDatefrom_TextChanged);
            this.txtDatefrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDatefrom_KeyDown);
            this.txtDatefrom.Leave += new System.EventHandler(this.txtDatefrom_Leave);
            // 
            // txtDateTo
            // 
            this.txtDateTo.Location = new System.Drawing.Point(176, 58);
            this.txtDateTo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(239, 22);
            this.txtDateTo.TabIndex = 2;
            this.txtDateTo.TextChanged += new System.EventHandler(this.txtDateTo_TextChanged);
            this.txtDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDateTo_KeyDown);
            this.txtDateTo.Leave += new System.EventHandler(this.txtDateTo_Leave);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(415, 58);
            this.dtpDateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(27, 22);
            this.dtpDateTo.TabIndex = 128;
            this.dtpDateTo.TabStop = false;
            this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(956, 26);
            this.dtpDateFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(31, 22);
            this.dtpDateFrom.TabIndex = 127;
            this.dtpDateFrom.TabStop = false;
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(721, 55);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(113, 33);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearch_KeyDown);
            // 
            // btnSearchClear
            // 
            this.btnSearchClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearchClear.FlatAppearance.BorderSize = 0;
            this.btnSearchClear.ForeColor = System.Drawing.Color.Black;
            this.btnSearchClear.Location = new System.Drawing.Point(843, 55);
            this.btnSearchClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchClear.Name = "btnSearchClear";
            this.btnSearchClear.Size = new System.Drawing.Size(113, 33);
            this.btnSearchClear.TabIndex = 4;
            this.btnSearchClear.Text = "Clear";
            this.btnSearchClear.UseVisualStyleBackColor = false;
            this.btnSearchClear.Click += new System.EventHandler(this.btnSearchClear_Click);
            this.btnSearchClear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearchClear_KeyDown);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDateFrom.Location = new System.Drawing.Point(575, 31);
            this.lblDateFrom.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(74, 17);
            this.lblDateFrom.TabIndex = 126;
            this.lblDateFrom.Text = "Date From";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDateTo.Location = new System.Drawing.Point(24, 63);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(59, 17);
            this.lblDateTo.TabIndex = 125;
            this.lblDateTo.Text = "Date To";
            // 
            // cmbCurrencyRate
            // 
            this.cmbCurrencyRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrencyRate.FormattingEnabled = true;
            this.cmbCurrencyRate.Location = new System.Drawing.Point(176, 26);
            this.cmbCurrencyRate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 0);
            this.cmbCurrencyRate.Name = "cmbCurrencyRate";
            this.cmbCurrencyRate.Size = new System.Drawing.Size(265, 24);
            this.cmbCurrencyRate.TabIndex = 0;
            this.cmbCurrencyRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCurrencyRate_KeyDown);
            // 
            // lblCurrencySearch
            // 
            this.lblCurrencySearch.AutoSize = true;
            this.lblCurrencySearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrencySearch.Location = new System.Drawing.Point(24, 31);
            this.lblCurrencySearch.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblCurrencySearch.Name = "lblCurrencySearch";
            this.lblCurrencySearch.Size = new System.Drawing.Size(65, 17);
            this.lblCurrencySearch.TabIndex = 124;
            this.lblCurrencySearch.Text = "Currency";
            // 
            // dgvExchangeRate
            // 
            this.dgvExchangeRate.AllowUserToAddRows = false;
            this.dgvExchangeRate.AllowUserToDeleteRows = false;
            this.dgvExchangeRate.AllowUserToResizeColumns = false;
            this.dgvExchangeRate.AllowUserToResizeRows = false;
            this.dgvExchangeRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExchangeRate.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvExchangeRate.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(133)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(117)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExchangeRate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExchangeRate.ColumnHeadersHeight = 25;
            this.dgvExchangeRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(238)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(202)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExchangeRate.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExchangeRate.EnableHeadersVisualStyles = false;
            this.dgvExchangeRate.GridColor = System.Drawing.SystemColors.Control;
            this.dgvExchangeRate.Location = new System.Drawing.Point(25, 100);
            this.dgvExchangeRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvExchangeRate.MultiSelect = false;
            this.dgvExchangeRate.Name = "dgvExchangeRate";
            this.dgvExchangeRate.ReadOnly = true;
            this.dgvExchangeRate.RowHeadersVisible = false;
            this.dgvExchangeRate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExchangeRate.Size = new System.Drawing.Size(968, 329);
            this.dgvExchangeRate.TabIndex = 123;
            this.dgvExchangeRate.TabStop = false;
            this.dgvExchangeRate.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExchangeRate_CellDoubleClick);
            this.dgvExchangeRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvExchangeRate_KeyUp);
            // 
            // frmExchangeRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmExchangeRate";
            this.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange Rate";
            this.Load += new System.EventHandler(this.frmExchangeRate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmExchangeRate_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlExchange.ResumeLayout(false);
            this.pnlExchange.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchangeRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblExchangeRateValidator;
        private System.Windows.Forms.Label lblCurrencyValidator;
        private System.Windows.Forms.Panel pnlExchange;
        private System.Windows.Forms.Label lblEqual;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnCurrencyAdd;
        private System.Windows.Forms.Label lblExchangeaRate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDatefrom;
        private System.Windows.Forms.TextBox txtDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSearchClear;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.ComboBox cmbCurrencyRate;
        private System.Windows.Forms.Label lblCurrencySearch;
        private System.Windows.Forms.DataGridView dgvExchangeRate;
    }
}