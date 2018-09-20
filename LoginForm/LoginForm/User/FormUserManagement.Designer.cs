namespace LoginForm.User
{
    partial class FormWorkerManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWorkerManagement));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbUserAuthorityList = new System.Windows.Forms.CheckedListBox();
            this.gbRoles = new System.Windows.Forms.GroupBox();
            this.lbRoles = new System.Windows.Forms.ListBox();
            this.roleValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbAuthorities = new System.Windows.Forms.GroupBox();
            this.chcAllAuth = new System.Windows.Forms.CheckBox();
            this.clbAuthorities = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAuthorities = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.rbPassive = new System.Windows.Forms.RadioButton();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.numericDiscountRate = new System.Windows.Forms.NumericUpDown();
            this.numericFactor = new System.Windows.Forms.NumericUpDown();
            this.numericMinMargin = new System.Windows.Forms.NumericUpDown();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtNameLastName = new System.Windows.Forms.TextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtUserPass = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.chcChangePassword = new System.Windows.Forms.CheckBox();
            this.authRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.authorizationValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleValueBindingSource)).BeginInit();
            this.gbAuthorities.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscountRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorizationValueBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbRoles, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbAuthorities, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbUserAuthorityList);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // clbUserAuthorityList
            // 
            this.clbUserAuthorityList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.clbUserAuthorityList.CheckOnClick = true;
            resources.ApplyResources(this.clbUserAuthorityList, "clbUserAuthorityList");
            this.clbUserAuthorityList.FormattingEnabled = true;
            this.clbUserAuthorityList.Name = "clbUserAuthorityList";
            this.clbUserAuthorityList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbUserAuthorityList_MouseClick);
            // 
            // gbRoles
            // 
            this.gbRoles.Controls.Add(this.lbRoles);
            resources.ApplyResources(this.gbRoles, "gbRoles");
            this.gbRoles.Name = "gbRoles";
            this.gbRoles.TabStop = false;
            // 
            // lbRoles
            // 
            this.lbRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.lbRoles.DataSource = this.roleValueBindingSource;
            this.lbRoles.DisplayMember = "roleName";
            resources.ApplyResources(this.lbRoles, "lbRoles");
            this.lbRoles.FormattingEnabled = true;
            this.lbRoles.Name = "lbRoles";
            this.lbRoles.ValueMember = "RoleID";
            this.lbRoles.SelectedIndexChanged += new System.EventHandler(this.lbRoles_SelectedIndexChanged);
            // 
            // gbAuthorities
            // 
            this.gbAuthorities.Controls.Add(this.chcAllAuth);
            this.gbAuthorities.Controls.Add(this.clbAuthorities);
            resources.ApplyResources(this.gbAuthorities, "gbAuthorities");
            this.gbAuthorities.Name = "gbAuthorities";
            this.gbAuthorities.TabStop = false;
            // 
            // chcAllAuth
            // 
            resources.ApplyResources(this.chcAllAuth, "chcAllAuth");
            this.chcAllAuth.Name = "chcAllAuth";
            this.chcAllAuth.UseVisualStyleBackColor = true;
            this.chcAllAuth.Click += new System.EventHandler(this.chcAllAuth_Click);
            // 
            // clbAuthorities
            // 
            this.clbAuthorities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.clbAuthorities.CheckOnClick = true;
            resources.ApplyResources(this.clbAuthorities, "clbAuthorities");
            this.clbAuthorities.FormattingEnabled = true;
            this.clbAuthorities.Name = "clbAuthorities";
            this.clbAuthorities.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbAuthorities_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnAuthorities);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.gbUserInfo);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btnAuthorities
            // 
            resources.ApplyResources(this.btnAuthorities, "btnAuthorities");
            this.btnAuthorities.Image = global::LoginForm.Properties.Resources.icons8_Edit_Property_32;
            this.btnAuthorities.Name = "btnAuthorities";
            this.btnAuthorities.UseVisualStyleBackColor = true;
            this.btnAuthorities.Click += new System.EventHandler(this.btnAuthorities_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = global::LoginForm.Properties.Resources.if_floppy_285657;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbUserInfo
            // 
            resources.ApplyResources(this.gbUserInfo, "gbUserInfo");
            this.gbUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.gbUserInfo.Controls.Add(this.rbPassive);
            this.gbUserInfo.Controls.Add(this.txtTitle);
            this.gbUserInfo.Controls.Add(this.materialLabel6);
            this.gbUserInfo.Controls.Add(this.materialLabel10);
            this.gbUserInfo.Controls.Add(this.materialLabel9);
            this.gbUserInfo.Controls.Add(this.materialLabel8);
            this.gbUserInfo.Controls.Add(this.numericDiscountRate);
            this.gbUserInfo.Controls.Add(this.numericFactor);
            this.gbUserInfo.Controls.Add(this.numericMinMargin);
            this.gbUserInfo.Controls.Add(this.materialLabel7);
            this.gbUserInfo.Controls.Add(this.txtNote);
            this.gbUserInfo.Controls.Add(this.txtNameLastName);
            this.gbUserInfo.Controls.Add(this.materialLabel5);
            this.gbUserInfo.Controls.Add(this.materialLabel4);
            this.gbUserInfo.Controls.Add(this.materialLabel3);
            this.gbUserInfo.Controls.Add(this.materialLabel2);
            this.gbUserInfo.Controls.Add(this.materialLabel1);
            this.gbUserInfo.Controls.Add(this.rbActive);
            this.gbUserInfo.Controls.Add(this.txtPhone);
            this.gbUserInfo.Controls.Add(this.txtMail);
            this.gbUserInfo.Controls.Add(this.txtUserPass);
            this.gbUserInfo.Controls.Add(this.txtUsername);
            this.gbUserInfo.Controls.Add(this.chcChangePassword);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.TabStop = false;
            // 
            // rbPassive
            // 
            resources.ApplyResources(this.rbPassive, "rbPassive");
            this.rbPassive.Name = "rbPassive";
            this.rbPassive.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            resources.ApplyResources(this.txtTitle, "txtTitle");
            this.txtTitle.Name = "txtTitle";
            // 
            // materialLabel6
            // 
            resources.ApplyResources(this.materialLabel6, "materialLabel6");
            this.materialLabel6.Depth = 0;
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            // 
            // materialLabel10
            // 
            resources.ApplyResources(this.materialLabel10, "materialLabel10");
            this.materialLabel10.Depth = 0;
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            // 
            // materialLabel9
            // 
            resources.ApplyResources(this.materialLabel9, "materialLabel9");
            this.materialLabel9.Depth = 0;
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            // 
            // materialLabel8
            // 
            resources.ApplyResources(this.materialLabel8, "materialLabel8");
            this.materialLabel8.Depth = 0;
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            // 
            // numericDiscountRate
            // 
            this.numericDiscountRate.DecimalPlaces = 2;
            this.numericDiscountRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.numericDiscountRate, "numericDiscountRate");
            this.numericDiscountRate.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericDiscountRate.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.numericDiscountRate.Name = "numericDiscountRate";
            // 
            // numericFactor
            // 
            this.numericFactor.DecimalPlaces = 2;
            this.numericFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.numericFactor, "numericFactor");
            this.numericFactor.Name = "numericFactor";
            // 
            // numericMinMargin
            // 
            this.numericMinMargin.DecimalPlaces = 2;
            this.numericMinMargin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.numericMinMargin, "numericMinMargin");
            this.numericMinMargin.Name = "numericMinMargin";
            // 
            // materialLabel7
            // 
            resources.ApplyResources(this.materialLabel7, "materialLabel7");
            this.materialLabel7.Depth = 0;
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            // 
            // txtNote
            // 
            resources.ApplyResources(this.txtNote, "txtNote");
            this.txtNote.Name = "txtNote";
            // 
            // txtNameLastName
            // 
            resources.ApplyResources(this.txtNameLastName, "txtNameLastName");
            this.txtNameLastName.Name = "txtNameLastName";
            // 
            // materialLabel5
            // 
            resources.ApplyResources(this.materialLabel5, "materialLabel5");
            this.materialLabel5.Depth = 0;
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            // 
            // materialLabel4
            // 
            resources.ApplyResources(this.materialLabel4, "materialLabel4");
            this.materialLabel4.Depth = 0;
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            // 
            // materialLabel3
            // 
            resources.ApplyResources(this.materialLabel3, "materialLabel3");
            this.materialLabel3.Depth = 0;
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            // 
            // materialLabel2
            // 
            resources.ApplyResources(this.materialLabel2, "materialLabel2");
            this.materialLabel2.Depth = 0;
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            // 
            // materialLabel1
            // 
            resources.ApplyResources(this.materialLabel1, "materialLabel1");
            this.materialLabel1.Depth = 0;
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            // 
            // rbActive
            // 
            resources.ApplyResources(this.rbActive, "rbActive");
            this.rbActive.Name = "rbActive";
            this.rbActive.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            resources.ApplyResources(this.txtPhone, "txtPhone");
            this.txtPhone.Name = "txtPhone";
            // 
            // txtMail
            // 
            resources.ApplyResources(this.txtMail, "txtMail");
            this.txtMail.Name = "txtMail";
            // 
            // txtUserPass
            // 
            resources.ApplyResources(this.txtUserPass, "txtUserPass");
            this.txtUserPass.Name = "txtUserPass";
            // 
            // txtUsername
            // 
            resources.ApplyResources(this.txtUsername, "txtUsername");
            this.txtUsername.Name = "txtUsername";
            // 
            // chcChangePassword
            // 
            resources.ApplyResources(this.chcChangePassword, "chcChangePassword");
            this.chcChangePassword.Name = "chcChangePassword";
            this.chcChangePassword.UseVisualStyleBackColor = true;
            this.chcChangePassword.CheckedChanged += new System.EventHandler(this.chcChangePassword_CheckedChanged);
            // 
            // FormWorkerManagement
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormWorkerManagement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roleValueBindingSource)).EndInit();
            this.gbAuthorities.ResumeLayout(false);
            this.gbAuthorities.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbUserInfo.ResumeLayout(false);
            this.gbUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscountRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorizationValueBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbRoles;
        private System.Windows.Forms.GroupBox gbAuthorities;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbUserInfo;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtUserPass;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.BindingSource authRoleBindingSource;
        private System.Windows.Forms.BindingSource authorizationValueBindingSource;
        private System.Windows.Forms.CheckedListBox clbAuthorities;
        private System.Windows.Forms.RadioButton rbActive;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox txtNameLastName;
        private System.Windows.Forms.CheckBox chcChangePassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbUserAuthorityList;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.ListBox lbRoles;
        private System.Windows.Forms.BindingSource roleValueBindingSource;
        private System.Windows.Forms.CheckBox chcAllAuth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAuthorities;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private System.Windows.Forms.NumericUpDown numericDiscountRate;
        private System.Windows.Forms.NumericUpDown numericFactor;
        private System.Windows.Forms.NumericUpDown numericMinMargin;
        private System.Windows.Forms.TextBox txtTitle;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.RadioButton rbPassive;
    }
}