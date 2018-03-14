namespace LoginForm
{
    partial class frmSalesman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesman));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxSalesMan = new System.Windows.Forms.GroupBox();
            this.lblNameValidator = new System.Windows.Forms.Label();
            this.lblSalesmanCodeValidator = new System.Windows.Forms.Label();
            this.cbxActive = new System.Windows.Forms.CheckBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSalesmanCode = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNarration = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblSalesmanCode = new System.Windows.Forms.Label();
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.txtPhoneSearch = new System.Windows.Forms.TextBox();
            this.lblPhoneSearch = new System.Windows.Forms.Label();
            this.txtMobileSearch = new System.Windows.Forms.TextBox();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.lblNameSearch = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblMobileSearch = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.dgvSalesman = new System.Windows.Forms.DataGridView();
            this.dgvtxtslno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtemployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtemployeecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtemployeename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtphonenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtmobilenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxSalesMan.SuspendLayout();
            this.gbxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesman)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSalesMan
            // 
            this.gbxSalesMan.Controls.Add(this.lblNameValidator);
            this.gbxSalesMan.Controls.Add(this.lblSalesmanCodeValidator);
            this.gbxSalesMan.Controls.Add(this.cbxActive);
            this.gbxSalesMan.Controls.Add(this.lblAddress);
            this.gbxSalesMan.Controls.Add(this.txtAddress);
            this.gbxSalesMan.Controls.Add(this.txtMobile);
            this.gbxSalesMan.Controls.Add(this.lblMobile);
            this.gbxSalesMan.Controls.Add(this.txtPhone);
            this.gbxSalesMan.Controls.Add(this.lblPhone);
            this.gbxSalesMan.Controls.Add(this.txtEmail);
            this.gbxSalesMan.Controls.Add(this.txtName);
            this.gbxSalesMan.Controls.Add(this.lblName);
            this.gbxSalesMan.Controls.Add(this.btnClose);
            this.gbxSalesMan.Controls.Add(this.btnDelete);
            this.gbxSalesMan.Controls.Add(this.btnClear);
            this.gbxSalesMan.Controls.Add(this.txtSalesmanCode);
            this.gbxSalesMan.Controls.Add(this.lblEmail);
            this.gbxSalesMan.Controls.Add(this.btnSave);
            this.gbxSalesMan.Controls.Add(this.lblNarration);
            this.gbxSalesMan.Controls.Add(this.txtNarration);
            this.gbxSalesMan.Controls.Add(this.lblSalesmanCode);
            this.gbxSalesMan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbxSalesMan.Location = new System.Drawing.Point(21, 16);
            this.gbxSalesMan.Margin = new System.Windows.Forms.Padding(4);
            this.gbxSalesMan.Name = "gbxSalesMan";
            this.gbxSalesMan.Padding = new System.Windows.Forms.Padding(4);
            this.gbxSalesMan.Size = new System.Drawing.Size(1021, 236);
            this.gbxSalesMan.TabIndex = 0;
            this.gbxSalesMan.TabStop = false;
            this.gbxSalesMan.Text = "Salesman";
            // 
            // lblNameValidator
            // 
            this.lblNameValidator.AutoSize = true;
            this.lblNameValidator.ForeColor = System.Drawing.Color.Red;
            this.lblNameValidator.Location = new System.Drawing.Point(985, 37);
            this.lblNameValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblNameValidator.Name = "lblNameValidator";
            this.lblNameValidator.Size = new System.Drawing.Size(13, 17);
            this.lblNameValidator.TabIndex = 412;
            this.lblNameValidator.Text = "*";
            // 
            // lblSalesmanCodeValidator
            // 
            this.lblSalesmanCodeValidator.AutoSize = true;
            this.lblSalesmanCodeValidator.ForeColor = System.Drawing.Color.Red;
            this.lblSalesmanCodeValidator.Location = new System.Drawing.Point(436, 36);
            this.lblSalesmanCodeValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblSalesmanCodeValidator.Name = "lblSalesmanCodeValidator";
            this.lblSalesmanCodeValidator.Size = new System.Drawing.Size(13, 17);
            this.lblSalesmanCodeValidator.TabIndex = 411;
            this.lblSalesmanCodeValidator.Text = "*";
            // 
            // cbxActive
            // 
            this.cbxActive.AutoSize = true;
            this.cbxActive.Checked = true;
            this.cbxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxActive.ForeColor = System.Drawing.Color.White;
            this.cbxActive.Location = new System.Drawing.Point(712, 158);
            this.cbxActive.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(68, 21);
            this.cbxActive.TabIndex = 7;
            this.cbxActive.Text = "Active";
            this.cbxActive.UseVisualStyleBackColor = true;
            this.cbxActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxActive_KeyDown);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAddress.Location = new System.Drawing.Point(565, 98);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 17);
            this.lblAddress.TabIndex = 410;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(712, 94);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(265, 61);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.WordWrap = false;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(169, 92);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(265, 22);
            this.txtMobile.TabIndex = 4;
            this.txtMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobile_KeyDown);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMobile.Location = new System.Drawing.Point(23, 97);
            this.lblMobile.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(49, 17);
            this.lblMobile.TabIndex = 409;
            this.lblMobile.Text = "Mobile";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(712, 63);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(265, 22);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPhone.Location = new System.Drawing.Point(565, 68);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(49, 17);
            this.lblPhone.TabIndex = 408;
            this.lblPhone.Text = "Phone";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(169, 62);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(265, 22);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(712, 32);
            this.txtName.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(265, 22);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblName.Location = new System.Drawing.Point(565, 37);
            this.lblName.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 407;
            this.lblName.Text = "Name";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(885, 182);
            this.btnClose.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 33);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(764, 182);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 33);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(643, 182);
            this.btnClear.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 33);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClear_KeyDown);
            // 
            // txtSalesmanCode
            // 
            this.txtSalesmanCode.Location = new System.Drawing.Point(169, 31);
            this.txtSalesmanCode.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtSalesmanCode.Name = "txtSalesmanCode";
            this.txtSalesmanCode.Size = new System.Drawing.Size(265, 22);
            this.txtSalesmanCode.TabIndex = 0;
            this.txtSalesmanCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesmanCode_KeyDown);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmail.Location = new System.Drawing.Point(23, 66);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 17);
            this.lblEmail.TabIndex = 406;
            this.lblEmail.Text = "E-mail";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(521, 182);
            this.btnSave.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 33);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNarration.Location = new System.Drawing.Point(23, 123);
            this.lblNarration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(67, 17);
            this.lblNarration.TabIndex = 405;
            this.lblNarration.Text = "Narration";
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(169, 123);
            this.txtNarration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(265, 61);
            this.txtNarration.TabIndex = 6;
            this.txtNarration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNarration_KeyDown);
            this.txtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNarration_KeyPress);
            // 
            // lblSalesmanCode
            // 
            this.lblSalesmanCode.AutoSize = true;
            this.lblSalesmanCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSalesmanCode.Location = new System.Drawing.Point(23, 36);
            this.lblSalesmanCode.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblSalesmanCode.Name = "lblSalesmanCode";
            this.lblSalesmanCode.Size = new System.Drawing.Size(107, 17);
            this.lblSalesmanCode.TabIndex = 404;
            this.lblSalesmanCode.Text = "Salesman Code";
            // 
            // gbxSearch
            // 
            this.gbxSearch.Controls.Add(this.btnClearSearch);
            this.gbxSearch.Controls.Add(this.btnSearch);
            this.gbxSearch.Controls.Add(this.cmbIsActive);
            this.gbxSearch.Controls.Add(this.lblActive);
            this.gbxSearch.Controls.Add(this.txtPhoneSearch);
            this.gbxSearch.Controls.Add(this.lblPhoneSearch);
            this.gbxSearch.Controls.Add(this.txtMobileSearch);
            this.gbxSearch.Controls.Add(this.txtNameSearch);
            this.gbxSearch.Controls.Add(this.lblNameSearch);
            this.gbxSearch.Controls.Add(this.txtCode);
            this.gbxSearch.Controls.Add(this.lblMobileSearch);
            this.gbxSearch.Controls.Add(this.lblCode);
            this.gbxSearch.Controls.Add(this.dgvSalesman);
            this.gbxSearch.ForeColor = System.Drawing.Color.White;
            this.gbxSearch.Location = new System.Drawing.Point(21, 260);
            this.gbxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Padding = new System.Windows.Forms.Padding(4);
            this.gbxSearch.Size = new System.Drawing.Size(1017, 454);
            this.gbxSearch.TabIndex = 1;
            this.gbxSearch.TabStop = false;
            this.gbxSearch.Text = "Search";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClearSearch.BackgroundImage")));
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.ForeColor = System.Drawing.Color.White;
            this.btnClearSearch.Location = new System.Drawing.Point(851, 84);
            this.btnClearSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(113, 33);
            this.btnClearSearch.TabIndex = 6;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(729, 84);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(113, 33);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearch_KeyDown);
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbIsActive.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbIsActive.Location = new System.Drawing.Point(169, 86);
            this.cmbIsActive.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(265, 24);
            this.cmbIsActive.TabIndex = 4;
            this.cmbIsActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbIsActive_KeyDown);
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblActive.Location = new System.Drawing.Point(23, 91);
            this.lblActive.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(46, 17);
            this.lblActive.TabIndex = 402;
            this.lblActive.Text = "Active";
            // 
            // txtPhoneSearch
            // 
            this.txtPhoneSearch.Location = new System.Drawing.Point(729, 55);
            this.txtPhoneSearch.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtPhoneSearch.Name = "txtPhoneSearch";
            this.txtPhoneSearch.Size = new System.Drawing.Size(265, 22);
            this.txtPhoneSearch.TabIndex = 3;
            this.txtPhoneSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhoneSearch_KeyDown);
            // 
            // lblPhoneSearch
            // 
            this.lblPhoneSearch.AutoSize = true;
            this.lblPhoneSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPhoneSearch.Location = new System.Drawing.Point(603, 60);
            this.lblPhoneSearch.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblPhoneSearch.Name = "lblPhoneSearch";
            this.lblPhoneSearch.Size = new System.Drawing.Size(49, 17);
            this.lblPhoneSearch.TabIndex = 401;
            this.lblPhoneSearch.Text = "Phone";
            // 
            // txtMobileSearch
            // 
            this.txtMobileSearch.Location = new System.Drawing.Point(169, 55);
            this.txtMobileSearch.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtMobileSearch.Name = "txtMobileSearch";
            this.txtMobileSearch.Size = new System.Drawing.Size(265, 22);
            this.txtMobileSearch.TabIndex = 2;
            this.txtMobileSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileSearch_KeyDown);
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Location = new System.Drawing.Point(729, 25);
            this.txtNameSearch.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(265, 22);
            this.txtNameSearch.TabIndex = 1;
            this.txtNameSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNameSearch_KeyDown);
            // 
            // lblNameSearch
            // 
            this.lblNameSearch.AutoSize = true;
            this.lblNameSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNameSearch.Location = new System.Drawing.Point(603, 30);
            this.lblNameSearch.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblNameSearch.Name = "lblNameSearch";
            this.lblNameSearch.Size = new System.Drawing.Size(45, 17);
            this.lblNameSearch.TabIndex = 400;
            this.lblNameSearch.Text = "Name";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(169, 25);
            this.txtCode.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(265, 22);
            this.txtCode.TabIndex = 0;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // lblMobileSearch
            // 
            this.lblMobileSearch.AutoSize = true;
            this.lblMobileSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMobileSearch.Location = new System.Drawing.Point(23, 60);
            this.lblMobileSearch.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblMobileSearch.Name = "lblMobileSearch";
            this.lblMobileSearch.Size = new System.Drawing.Size(49, 17);
            this.lblMobileSearch.TabIndex = 399;
            this.lblMobileSearch.Text = "Mobile";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCode.Location = new System.Drawing.Point(23, 30);
            this.lblCode.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(41, 17);
            this.lblCode.TabIndex = 398;
            this.lblCode.Text = "Code";
            // 
            // dgvSalesman
            // 
            this.dgvSalesman.AllowUserToAddRows = false;
            this.dgvSalesman.AllowUserToDeleteRows = false;
            this.dgvSalesman.AllowUserToResizeColumns = false;
            this.dgvSalesman.AllowUserToResizeRows = false;
            this.dgvSalesman.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesman.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesman.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(133)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(117)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesman.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesman.ColumnHeadersHeight = 25;
            this.dgvSalesman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSalesman.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtslno,
            this.dgvtxtemployeeId,
            this.dgvtxtemployeecode,
            this.dgvtxtemployeename,
            this.dgvtxtphonenumber,
            this.dgvtxtmobilenumber,
            this.dgvtxtactive});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(238)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(202)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesman.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesman.EnableHeadersVisualStyles = false;
            this.dgvSalesman.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSalesman.Location = new System.Drawing.Point(27, 126);
            this.dgvSalesman.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.dgvSalesman.MultiSelect = false;
            this.dgvSalesman.Name = "dgvSalesman";
            this.dgvSalesman.ReadOnly = true;
            this.dgvSalesman.RowHeadersVisible = false;
            this.dgvSalesman.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesman.Size = new System.Drawing.Size(969, 313);
            this.dgvSalesman.TabIndex = 20;
            this.dgvSalesman.TabStop = false;
            this.dgvSalesman.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesman_CellDoubleClick);
            this.dgvSalesman.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSalesman_KeyDown);
            this.dgvSalesman.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSalesman_KeyUp);
            // 
            // dgvtxtslno
            // 
            this.dgvtxtslno.DataPropertyName = "sl.no";
            this.dgvtxtslno.HeaderText = "Sl.No";
            this.dgvtxtslno.Name = "dgvtxtslno";
            this.dgvtxtslno.ReadOnly = true;
            this.dgvtxtslno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtxtemployeeId
            // 
            this.dgvtxtemployeeId.DataPropertyName = "employeeId";
            this.dgvtxtemployeeId.HeaderText = "employeeId";
            this.dgvtxtemployeeId.Name = "dgvtxtemployeeId";
            this.dgvtxtemployeeId.ReadOnly = true;
            this.dgvtxtemployeeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtxtemployeeId.Visible = false;
            // 
            // dgvtxtemployeecode
            // 
            this.dgvtxtemployeecode.DataPropertyName = "employeeCode";
            this.dgvtxtemployeecode.HeaderText = "Code";
            this.dgvtxtemployeecode.Name = "dgvtxtemployeecode";
            this.dgvtxtemployeecode.ReadOnly = true;
            this.dgvtxtemployeecode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtxtemployeename
            // 
            this.dgvtxtemployeename.DataPropertyName = "employeeName";
            this.dgvtxtemployeename.HeaderText = "Name";
            this.dgvtxtemployeename.Name = "dgvtxtemployeename";
            this.dgvtxtemployeename.ReadOnly = true;
            this.dgvtxtemployeename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtxtphonenumber
            // 
            this.dgvtxtphonenumber.DataPropertyName = "phoneNumber";
            this.dgvtxtphonenumber.HeaderText = "Phone";
            this.dgvtxtphonenumber.Name = "dgvtxtphonenumber";
            this.dgvtxtphonenumber.ReadOnly = true;
            this.dgvtxtphonenumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtxtmobilenumber
            // 
            this.dgvtxtmobilenumber.DataPropertyName = "mobileNumber";
            this.dgvtxtmobilenumber.HeaderText = "Mobile";
            this.dgvtxtmobilenumber.Name = "dgvtxtmobilenumber";
            this.dgvtxtmobilenumber.ReadOnly = true;
            this.dgvtxtmobilenumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtxtactive
            // 
            this.dgvtxtactive.DataPropertyName = "isActive";
            this.dgvtxtactive.HeaderText = "Active";
            this.dgvtxtactive.Name = "dgvtxtactive";
            this.dgvtxtactive.ReadOnly = true;
            this.dgvtxtactive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmSalesman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(111)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.gbxSearch);
            this.Controls.Add(this.gbxSalesMan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSalesman";
            this.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salesman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesman_FormClosing);
            this.Load += new System.EventHandler(this.frmSalesman_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSalesman_KeyDown);
            this.gbxSalesMan.ResumeLayout(false);
            this.gbxSalesMan.PerformLayout();
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesman)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSalesMan;
        private System.Windows.Forms.Label lblNameValidator;
        private System.Windows.Forms.Label lblSalesmanCodeValidator;
        private System.Windows.Forms.CheckBox cbxActive;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSalesmanCode;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label lblSalesmanCode;
        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.TextBox txtPhoneSearch;
        private System.Windows.Forms.Label lblPhoneSearch;
        private System.Windows.Forms.TextBox txtMobileSearch;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Label lblNameSearch;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblMobileSearch;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.DataGridView dgvSalesman;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtslno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtemployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtemployeecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtemployeename;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtphonenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtmobilenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtactive;
    }
}