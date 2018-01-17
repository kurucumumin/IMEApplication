namespace LoginForm
{
    partial class frmPdcPayable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPdcPayable));
            this.cbxPrint = new System.Windows.Forms.CheckBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.btnNewAccountLedger = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbAccountLedger = new System.Windows.Forms.ComboBox();
            this.lblAccountledger = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblvoucherNo = new System.Windows.Forms.Label();
            this.txtvoucherNo = new System.Windows.Forms.TextBox();
            this.btnAgainstRef = new System.Windows.Forms.Button();
            this.gpxDetails = new System.Windows.Forms.GroupBox();
            this.lblBankValidator = new System.Windows.Forms.Label();
            this.lblChecknoValidator = new System.Windows.Forms.Label();
            this.lbAmountValidator = new System.Windows.Forms.Label();
            this.dtpchekdate = new System.Windows.Forms.DateTimePicker();
            this.txtChequeDate = new System.Windows.Forms.TextBox();
            this.lblCheckdate = new System.Windows.Forms.Label();
            this.btnNewAccountLedger2 = new System.Windows.Forms.Button();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblCheckNo = new System.Windows.Forms.Label();
            this.txtcheckNo = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtpVoucherDate = new System.Windows.Forms.DateTimePicker();
            this.txtVoucherDate = new System.Windows.Forms.TextBox();
            this.lblAccountLedgerValidator = new System.Windows.Forms.Label();
            this.lblVoucherNoManualValidator = new System.Windows.Forms.Label();
            this.gpxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxPrint
            // 
            this.cbxPrint.AutoSize = true;
            this.cbxPrint.ForeColor = System.Drawing.Color.White;
            this.cbxPrint.Location = new System.Drawing.Point(20, 341);
            this.cbxPrint.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cbxPrint.Name = "cbxPrint";
            this.cbxPrint.Size = new System.Drawing.Size(126, 21);
            this.cbxPrint.TabIndex = 10;
            this.cbxPrint.Text = "Print after save";
            this.cbxPrint.UseVisualStyleBackColor = true;
            this.cbxPrint.CheckedChanged += new System.EventHandler(this.cbxPrint_CheckedChanged);
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNarration.Location = new System.Drawing.Point(380, 202);
            this.lblNarration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(67, 17);
            this.lblNarration.TabIndex = 473;
            this.lblNarration.Text = "Narration";
            this.lblNarration.Click += new System.EventHandler(this.lblNarration_Click);
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(507, 202);
            this.txtNarration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(532, 122);
            this.txtNarration.TabIndex = 5;
            this.txtNarration.TextChanged += new System.EventHandler(this.txtNarration_TextChanged);
            this.txtNarration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNarration_KeyDown);
            this.txtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNarration_KeyPress);
            // 
            // btnNewAccountLedger
            // 
            this.btnNewAccountLedger.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewAccountLedger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNewAccountLedger.FlatAppearance.BorderSize = 0;
            this.btnNewAccountLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewAccountLedger.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewAccountLedger.Location = new System.Drawing.Point(427, 49);
            this.btnNewAccountLedger.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewAccountLedger.Name = "btnNewAccountLedger";
            this.btnNewAccountLedger.Size = new System.Drawing.Size(28, 25);
            this.btnNewAccountLedger.TabIndex = 2;
            this.btnNewAccountLedger.Text = "+";
            this.btnNewAccountLedger.UseVisualStyleBackColor = false;
            this.btnNewAccountLedger.Click += new System.EventHandler(this.btnNewAccountLedger_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(649, 23);
            this.lblDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 17);
            this.lblDate.TabIndex = 463;
            this.lblDate.Text = "Date";
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // cmbAccountLedger
            // 
            this.cmbAccountLedger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountLedger.FormattingEnabled = true;
            this.cmbAccountLedger.Location = new System.Drawing.Point(153, 49);
            this.cmbAccountLedger.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.cmbAccountLedger.Name = "cmbAccountLedger";
            this.cmbAccountLedger.Size = new System.Drawing.Size(265, 24);
            this.cmbAccountLedger.TabIndex = 1;
            this.cmbAccountLedger.SelectedIndexChanged += new System.EventHandler(this.cmbAccountLedger_SelectedIndexChanged);
            this.cmbAccountLedger.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAccountLedger_KeyDown);
            this.cmbAccountLedger.Leave += new System.EventHandler(this.cmbAccountLedger_Leave);
            // 
            // lblAccountledger
            // 
            this.lblAccountledger.AutoSize = true;
            this.lblAccountledger.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAccountledger.Location = new System.Drawing.Point(27, 54);
            this.lblAccountledger.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblAccountledger.Name = "lblAccountledger";
            this.lblAccountledger.Size = new System.Drawing.Size(108, 17);
            this.lblAccountledger.TabIndex = 457;
            this.lblAccountledger.Text = "Account Ledger";
            this.lblAccountledger.Click += new System.EventHandler(this.lblAccountledger_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(929, 335);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 33);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(808, 335);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 33);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(687, 335);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 33);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(565, 335);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // lblvoucherNo
            // 
            this.lblvoucherNo.AutoSize = true;
            this.lblvoucherNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblvoucherNo.Location = new System.Drawing.Point(27, 23);
            this.lblvoucherNo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblvoucherNo.Name = "lblvoucherNo";
            this.lblvoucherNo.Size = new System.Drawing.Size(87, 17);
            this.lblvoucherNo.TabIndex = 451;
            this.lblvoucherNo.Text = "Voucher No.";
            this.lblvoucherNo.Click += new System.EventHandler(this.lblvoucherNo_Click);
            // 
            // txtvoucherNo
            // 
            this.txtvoucherNo.Location = new System.Drawing.Point(153, 18);
            this.txtvoucherNo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtvoucherNo.Name = "txtvoucherNo";
            this.txtvoucherNo.Size = new System.Drawing.Size(265, 22);
            this.txtvoucherNo.TabIndex = 7568;
            this.txtvoucherNo.TextChanged += new System.EventHandler(this.txtvoucherNo_TextChanged);
            this.txtvoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherNo_KeyDown);
            // 
            // btnAgainstRef
            // 
            this.btnAgainstRef.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgainstRef.Enabled = false;
            this.btnAgainstRef.FlatAppearance.BorderSize = 0;
            this.btnAgainstRef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgainstRef.ForeColor = System.Drawing.Color.Black;
            this.btnAgainstRef.Location = new System.Drawing.Point(491, 41);
            this.btnAgainstRef.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgainstRef.Name = "btnAgainstRef";
            this.btnAgainstRef.Size = new System.Drawing.Size(113, 33);
            this.btnAgainstRef.TabIndex = 3;
            this.btnAgainstRef.Text = "Against Ref.";
            this.btnAgainstRef.UseVisualStyleBackColor = false;
            this.btnAgainstRef.Click += new System.EventHandler(this.btnAgainstRef_Click);
            // 
            // gpxDetails
            // 
            this.gpxDetails.Controls.Add(this.lblBankValidator);
            this.gpxDetails.Controls.Add(this.lblChecknoValidator);
            this.gpxDetails.Controls.Add(this.lbAmountValidator);
            this.gpxDetails.Controls.Add(this.dtpchekdate);
            this.gpxDetails.Controls.Add(this.txtChequeDate);
            this.gpxDetails.Controls.Add(this.lblCheckdate);
            this.gpxDetails.Controls.Add(this.btnNewAccountLedger2);
            this.gpxDetails.Controls.Add(this.cmbBank);
            this.gpxDetails.Controls.Add(this.lblBank);
            this.gpxDetails.Controls.Add(this.lblCheckNo);
            this.gpxDetails.Controls.Add(this.txtcheckNo);
            this.gpxDetails.Controls.Add(this.lblAmount);
            this.gpxDetails.Controls.Add(this.txtAmount);
            this.gpxDetails.ForeColor = System.Drawing.Color.White;
            this.gpxDetails.Location = new System.Drawing.Point(20, 84);
            this.gpxDetails.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gpxDetails.Name = "gpxDetails";
            this.gpxDetails.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.gpxDetails.Size = new System.Drawing.Size(1020, 106);
            this.gpxDetails.TabIndex = 4;
            this.gpxDetails.TabStop = false;
            this.gpxDetails.Text = "Details";
            this.gpxDetails.Enter += new System.EventHandler(this.gpxDetails_Enter);
            // 
            // lblBankValidator
            // 
            this.lblBankValidator.AutoSize = true;
            this.lblBankValidator.ForeColor = System.Drawing.Color.Red;
            this.lblBankValidator.Location = new System.Drawing.Point(931, 31);
            this.lblBankValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblBankValidator.Name = "lblBankValidator";
            this.lblBankValidator.Size = new System.Drawing.Size(13, 17);
            this.lblBankValidator.TabIndex = 1150;
            this.lblBankValidator.Text = "*";
            this.lblBankValidator.Click += new System.EventHandler(this.lblBankValidator_Click);
            // 
            // lblChecknoValidator
            // 
            this.lblChecknoValidator.AutoSize = true;
            this.lblChecknoValidator.ForeColor = System.Drawing.Color.Red;
            this.lblChecknoValidator.Location = new System.Drawing.Point(441, 62);
            this.lblChecknoValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblChecknoValidator.Name = "lblChecknoValidator";
            this.lblChecknoValidator.Size = new System.Drawing.Size(13, 17);
            this.lblChecknoValidator.TabIndex = 1149;
            this.lblChecknoValidator.Text = "*";
            this.lblChecknoValidator.Click += new System.EventHandler(this.lblChecknoValidator_Click);
            // 
            // lbAmountValidator
            // 
            this.lbAmountValidator.AutoSize = true;
            this.lbAmountValidator.ForeColor = System.Drawing.Color.Red;
            this.lbAmountValidator.Location = new System.Drawing.Point(441, 31);
            this.lbAmountValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lbAmountValidator.Name = "lbAmountValidator";
            this.lbAmountValidator.Size = new System.Drawing.Size(13, 17);
            this.lbAmountValidator.TabIndex = 1148;
            this.lbAmountValidator.Text = "*";
            this.lbAmountValidator.Click += new System.EventHandler(this.lbAmountValidator_Click);
            // 
            // dtpchekdate
            // 
            this.dtpchekdate.CustomFormat = "dd-MMM-yyyy";
            this.dtpchekdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpchekdate.Location = new System.Drawing.Point(904, 57);
            this.dtpchekdate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpchekdate.Name = "dtpchekdate";
            this.dtpchekdate.Size = new System.Drawing.Size(25, 22);
            this.dtpchekdate.TabIndex = 480;
            this.dtpchekdate.CloseUp += new System.EventHandler(this.dtpchekdate_CloseUp);
            this.dtpchekdate.ValueChanged += new System.EventHandler(this.dtpchekdate_ValueChanged);
            // 
            // txtChequeDate
            // 
            this.txtChequeDate.Location = new System.Drawing.Point(664, 57);
            this.txtChequeDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtChequeDate.Name = "txtChequeDate";
            this.txtChequeDate.Size = new System.Drawing.Size(265, 22);
            this.txtChequeDate.TabIndex = 4;
            this.txtChequeDate.TextChanged += new System.EventHandler(this.txtChequeDate_TextChanged);
            this.txtChequeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeDate_KeyDown);
            this.txtChequeDate.Leave += new System.EventHandler(this.txtChequeDate_Leave);
            // 
            // lblCheckdate
            // 
            this.lblCheckdate.AutoSize = true;
            this.lblCheckdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCheckdate.Location = new System.Drawing.Point(517, 62);
            this.lblCheckdate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblCheckdate.Name = "lblCheckdate";
            this.lblCheckdate.Size = new System.Drawing.Size(91, 17);
            this.lblCheckdate.TabIndex = 475;
            this.lblCheckdate.Text = "Cheque Date";
            this.lblCheckdate.Click += new System.EventHandler(this.lblCheckdate_Click);
            // 
            // btnNewAccountLedger2
            // 
            this.btnNewAccountLedger2.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewAccountLedger2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNewAccountLedger2.FlatAppearance.BorderSize = 0;
            this.btnNewAccountLedger2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewAccountLedger2.ForeColor = System.Drawing.Color.Black;
            this.btnNewAccountLedger2.Location = new System.Drawing.Point(956, 26);
            this.btnNewAccountLedger2.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewAccountLedger2.Name = "btnNewAccountLedger2";
            this.btnNewAccountLedger2.Size = new System.Drawing.Size(28, 25);
            this.btnNewAccountLedger2.TabIndex = 2;
            this.btnNewAccountLedger2.Text = "+";
            this.btnNewAccountLedger2.UseVisualStyleBackColor = false;
            this.btnNewAccountLedger2.Click += new System.EventHandler(this.btnNewAccountLedger2_Click);
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(664, 26);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(265, 24);
            this.cmbBank.TabIndex = 1;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBank_KeyDown);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBank.Location = new System.Drawing.Point(519, 31);
            this.lblBank.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(40, 17);
            this.lblBank.TabIndex = 472;
            this.lblBank.Text = "Bank";
            this.lblBank.Click += new System.EventHandler(this.lblBank_Click);
            // 
            // lblCheckNo
            // 
            this.lblCheckNo.AutoSize = true;
            this.lblCheckNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCheckNo.Location = new System.Drawing.Point(20, 62);
            this.lblCheckNo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblCheckNo.Name = "lblCheckNo";
            this.lblCheckNo.Size = new System.Drawing.Size(83, 17);
            this.lblCheckNo.TabIndex = 455;
            this.lblCheckNo.Text = "Cheque No.";
            this.lblCheckNo.Click += new System.EventHandler(this.lblCheckNo_Click);
            // 
            // txtcheckNo
            // 
            this.txtcheckNo.Location = new System.Drawing.Point(168, 57);
            this.txtcheckNo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtcheckNo.Name = "txtcheckNo";
            this.txtcheckNo.Size = new System.Drawing.Size(265, 22);
            this.txtcheckNo.TabIndex = 3;
            this.txtcheckNo.TextChanged += new System.EventHandler(this.txtcheckNo_TextChanged);
            this.txtcheckNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcheckNo_KeyDown);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAmount.Location = new System.Drawing.Point(21, 31);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(56, 17);
            this.lblAmount.TabIndex = 453;
            this.lblAmount.Text = "Amount";
            this.lblAmount.Click += new System.EventHandler(this.lblAmount_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(168, 26);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(265, 22);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // dtpVoucherDate
            // 
            this.dtpVoucherDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVoucherDate.Location = new System.Drawing.Point(1016, 18);
            this.dtpVoucherDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVoucherDate.Name = "dtpVoucherDate";
            this.dtpVoucherDate.Size = new System.Drawing.Size(25, 22);
            this.dtpVoucherDate.TabIndex = 478;
            this.dtpVoucherDate.CloseUp += new System.EventHandler(this.dtpVoucherDate_CloseUp);
            this.dtpVoucherDate.ValueChanged += new System.EventHandler(this.dtpVoucherDate_ValueChanged);
            // 
            // txtVoucherDate
            // 
            this.txtVoucherDate.Location = new System.Drawing.Point(776, 18);
            this.txtVoucherDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtVoucherDate.Name = "txtVoucherDate";
            this.txtVoucherDate.Size = new System.Drawing.Size(240, 22);
            this.txtVoucherDate.TabIndex = 0;
            this.txtVoucherDate.TextChanged += new System.EventHandler(this.txtVoucherDate_TextChanged);
            this.txtVoucherDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherDate_KeyDown);
            this.txtVoucherDate.Leave += new System.EventHandler(this.txtVoucherDate_Leave);
            // 
            // lblAccountLedgerValidator
            // 
            this.lblAccountLedgerValidator.AutoSize = true;
            this.lblAccountLedgerValidator.ForeColor = System.Drawing.Color.Red;
            this.lblAccountLedgerValidator.Location = new System.Drawing.Point(463, 54);
            this.lblAccountLedgerValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblAccountLedgerValidator.Name = "lblAccountLedgerValidator";
            this.lblAccountLedgerValidator.Size = new System.Drawing.Size(13, 17);
            this.lblAccountLedgerValidator.TabIndex = 1147;
            this.lblAccountLedgerValidator.Text = "*";
            this.lblAccountLedgerValidator.Click += new System.EventHandler(this.lblAccountLedgerValidator_Click);
            // 
            // lblVoucherNoManualValidator
            // 
            this.lblVoucherNoManualValidator.AutoSize = true;
            this.lblVoucherNoManualValidator.ForeColor = System.Drawing.Color.Red;
            this.lblVoucherNoManualValidator.Location = new System.Drawing.Point(439, 23);
            this.lblVoucherNoManualValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblVoucherNoManualValidator.Name = "lblVoucherNoManualValidator";
            this.lblVoucherNoManualValidator.Size = new System.Drawing.Size(13, 17);
            this.lblVoucherNoManualValidator.TabIndex = 1150;
            this.lblVoucherNoManualValidator.Text = "*";
            this.lblVoucherNoManualValidator.Visible = false;
            this.lblVoucherNoManualValidator.Click += new System.EventHandler(this.lblVoucherNoManualValidator_Click);
            // 
            // frmPdcPayable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(111)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(1067, 388);
            this.Controls.Add(this.lblVoucherNoManualValidator);
            this.Controls.Add(this.lblAccountLedgerValidator);
            this.Controls.Add(this.dtpVoucherDate);
            this.Controls.Add(this.gpxDetails);
            this.Controls.Add(this.txtVoucherDate);
            this.Controls.Add(this.btnAgainstRef);
            this.Controls.Add(this.cbxPrint);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.txtNarration);
            this.Controls.Add(this.btnNewAccountLedger);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbAccountLedger);
            this.Controls.Add(this.lblAccountledger);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblvoucherNo);
            this.Controls.Add(this.txtvoucherNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmPdcPayable";
            this.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDC Payable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPdcPayable_FormClosing);
            this.Load += new System.EventHandler(this.frmPdcPayable_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPdcPayable_KeyDown);
            this.gpxDetails.ResumeLayout(false);
            this.gpxDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxPrint;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Button btnNewAccountLedger;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbAccountLedger;
        private System.Windows.Forms.Label lblAccountledger;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblvoucherNo;
        private System.Windows.Forms.TextBox txtvoucherNo;
        private System.Windows.Forms.Button btnAgainstRef;
        private System.Windows.Forms.GroupBox gpxDetails;
        private System.Windows.Forms.Label lblCheckdate;
        private System.Windows.Forms.Button btnNewAccountLedger2;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblCheckNo;
        private System.Windows.Forms.TextBox txtcheckNo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtpVoucherDate;
        private System.Windows.Forms.TextBox txtVoucherDate;
        private System.Windows.Forms.DateTimePicker dtpchekdate;
        private System.Windows.Forms.TextBox txtChequeDate;
        private System.Windows.Forms.Label lblAccountLedgerValidator;
        private System.Windows.Forms.Label lblBankValidator;
        private System.Windows.Forms.Label lblChecknoValidator;
        private System.Windows.Forms.Label lbAmountValidator;
        private System.Windows.Forms.Label lblVoucherNoManualValidator;
    }
}