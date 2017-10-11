namespace LoginForm.WorkerManagement
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
            this.gbRoles = new System.Windows.Forms.GroupBox();
            this.clbRoles = new System.Windows.Forms.CheckedListBox();
            this.gbAuthorities = new System.Windows.Forms.GroupBox();
            this.clbAuthorities = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.txtNameLastName = new System.Windows.Forms.TextBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.chcActive = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numeric2 = new System.Windows.Forms.NumericUpDown();
            this.numeric1 = new System.Windows.Forms.NumericUpDown();
            this.rbGeneralManager = new System.Windows.Forms.RadioButton();
            this.rbSalesManager = new System.Windows.Forms.RadioButton();
            this.rbSales = new System.Windows.Forms.RadioButton();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtUserPass = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.chcChangePassword = new System.Windows.Forms.CheckBox();
            this.authRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.authorizationValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbUserAuthorityList = new System.Windows.Forms.CheckedListBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbRoles.SuspendLayout();
            this.gbAuthorities.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbUserInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorizationValueBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // gbRoles
            // 
            this.gbRoles.Controls.Add(this.clbRoles);
            resources.ApplyResources(this.gbRoles, "gbRoles");
            this.gbRoles.Name = "gbRoles";
            this.gbRoles.TabStop = false;
            // 
            // clbRoles
            // 
            this.clbRoles.CheckOnClick = true;
            resources.ApplyResources(this.clbRoles, "clbRoles");
            this.clbRoles.FormattingEnabled = true;
            this.clbRoles.Name = "clbRoles";
            this.clbRoles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbRoles_ItemCheck);
            // 
            // gbAuthorities
            // 
            this.gbAuthorities.Controls.Add(this.clbAuthorities);
            resources.ApplyResources(this.gbAuthorities, "gbAuthorities");
            this.gbAuthorities.Name = "gbAuthorities";
            this.gbAuthorities.TabStop = false;
            // 
            // clbAuthorities
            // 
            resources.ApplyResources(this.clbAuthorities, "clbAuthorities");
            this.clbAuthorities.FormattingEnabled = true;
            this.clbAuthorities.Name = "clbAuthorities";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.materialRaisedButton1);
            this.panel1.Controls.Add(this.gbUserInfo);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            resources.ApplyResources(this.materialRaisedButton1, "materialRaisedButton1");
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbUserInfo
            // 
            resources.ApplyResources(this.gbUserInfo, "gbUserInfo");
            this.gbUserInfo.BackColor = System.Drawing.SystemColors.Control;
            this.gbUserInfo.Controls.Add(this.materialLabel7);
            this.gbUserInfo.Controls.Add(this.txtNote);
            this.gbUserInfo.Controls.Add(this.txtNameLastName);
            this.gbUserInfo.Controls.Add(this.materialLabel6);
            this.gbUserInfo.Controls.Add(this.materialLabel5);
            this.gbUserInfo.Controls.Add(this.materialLabel4);
            this.gbUserInfo.Controls.Add(this.materialLabel3);
            this.gbUserInfo.Controls.Add(this.materialLabel2);
            this.gbUserInfo.Controls.Add(this.materialLabel1);
            this.gbUserInfo.Controls.Add(this.chcActive);
            this.gbUserInfo.Controls.Add(this.panel2);
            this.gbUserInfo.Controls.Add(this.txtPhone);
            this.gbUserInfo.Controls.Add(this.txtMail);
            this.gbUserInfo.Controls.Add(this.txtUserPass);
            this.gbUserInfo.Controls.Add(this.txtUsername);
            this.gbUserInfo.Controls.Add(this.chcChangePassword);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.TabStop = false;
            // 
            // txtNameLastName
            // 
            resources.ApplyResources(this.txtNameLastName, "txtNameLastName");
            this.txtNameLastName.Name = "txtNameLastName";
            // 
            // materialLabel6
            // 
            resources.ApplyResources(this.materialLabel6, "materialLabel6");
            this.materialLabel6.Depth = 0;
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
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
            // chcActive
            // 
            resources.ApplyResources(this.chcActive, "chcActive");
            this.chcActive.Name = "chcActive";
            this.chcActive.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.numeric2);
            this.panel2.Controls.Add(this.numeric1);
            this.panel2.Controls.Add(this.rbGeneralManager);
            this.panel2.Controls.Add(this.rbSalesManager);
            this.panel2.Controls.Add(this.rbSales);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // numeric2
            // 
            this.numeric2.DecimalPlaces = 2;
            this.numeric2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.numeric2, "numeric2");
            this.numeric2.Name = "numeric2";
            // 
            // numeric1
            // 
            this.numeric1.DecimalPlaces = 2;
            this.numeric1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.numeric1, "numeric1");
            this.numeric1.Name = "numeric1";
            // 
            // rbGeneralManager
            // 
            resources.ApplyResources(this.rbGeneralManager, "rbGeneralManager");
            this.rbGeneralManager.Name = "rbGeneralManager";
            this.rbGeneralManager.TabStop = true;
            this.rbGeneralManager.UseVisualStyleBackColor = true;
            // 
            // rbSalesManager
            // 
            resources.ApplyResources(this.rbSalesManager, "rbSalesManager");
            this.rbSalesManager.Name = "rbSalesManager";
            this.rbSalesManager.TabStop = true;
            this.rbSalesManager.UseVisualStyleBackColor = true;
            // 
            // rbSales
            // 
            resources.ApplyResources(this.rbSales, "rbSales");
            this.rbSales.Name = "rbSales";
            this.rbSales.TabStop = true;
            this.rbSales.UseVisualStyleBackColor = true;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbUserAuthorityList);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // clbUserAuthorityList
            // 
            resources.ApplyResources(this.clbUserAuthorityList, "clbUserAuthorityList");
            this.clbUserAuthorityList.FormattingEnabled = true;
            this.clbUserAuthorityList.Name = "clbUserAuthorityList";
            // 
            // txtNote
            // 
            resources.ApplyResources(this.txtNote, "txtNote");
            this.txtNote.Name = "txtNote";
            // 
            // materialLabel7
            // 
            resources.ApplyResources(this.materialLabel7, "materialLabel7");
            this.materialLabel7.Depth = 0;
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            // 
            // FormWorkerManagement
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormWorkerManagement";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbRoles.ResumeLayout(false);
            this.gbAuthorities.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbUserInfo.ResumeLayout(false);
            this.gbUserInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorizationValueBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbRoles;
        private System.Windows.Forms.GroupBox gbAuthorities;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbUserInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbGeneralManager;
        private System.Windows.Forms.RadioButton rbSalesManager;
        private System.Windows.Forms.RadioButton rbSales;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtUserPass;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.NumericUpDown numeric1;
        private System.Windows.Forms.NumericUpDown numeric2;
        private System.Windows.Forms.BindingSource authRoleBindingSource;
        private System.Windows.Forms.BindingSource authorizationValueBindingSource;
        private System.Windows.Forms.CheckedListBox clbAuthorities;
        private System.Windows.Forms.CheckedListBox clbRoles;
        private System.Windows.Forms.CheckBox chcActive;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
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
    }
}