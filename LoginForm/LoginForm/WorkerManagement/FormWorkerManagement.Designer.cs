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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbRoles = new System.Windows.Forms.GroupBox();
            this.clbRoles = new System.Windows.Forms.CheckedListBox();
            this.gbAuthorities = new System.Windows.Forms.GroupBox();
            this.clbAuthorities = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
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
            this.txtNameLastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.authRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.authorizationValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 480F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbRoles, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbAuthorities, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1130, 587);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbRoles
            // 
            this.gbRoles.Controls.Add(this.clbRoles);
            this.gbRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRoles.Location = new System.Drawing.Point(488, 16);
            this.gbRoles.Margin = new System.Windows.Forms.Padding(8, 16, 8, 8);
            this.gbRoles.Name = "gbRoles";
            this.gbRoles.Padding = new System.Windows.Forms.Padding(12);
            this.gbRoles.Size = new System.Drawing.Size(309, 563);
            this.gbRoles.TabIndex = 0;
            this.gbRoles.TabStop = false;
            this.gbRoles.Text = "ROLES";
            // 
            // clbRoles
            // 
            this.clbRoles.CheckOnClick = true;
            this.clbRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbRoles.FormattingEnabled = true;
            this.clbRoles.Location = new System.Drawing.Point(12, 31);
            this.clbRoles.Name = "clbRoles";
            this.clbRoles.Size = new System.Drawing.Size(285, 520);
            this.clbRoles.TabIndex = 1;
            this.clbRoles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbRoles_ItemCheck);
            // 
            // gbAuthorities
            // 
            this.gbAuthorities.Controls.Add(this.clbAuthorities);
            this.gbAuthorities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAuthorities.Location = new System.Drawing.Point(813, 16);
            this.gbAuthorities.Margin = new System.Windows.Forms.Padding(8, 16, 8, 8);
            this.gbAuthorities.Name = "gbAuthorities";
            this.gbAuthorities.Padding = new System.Windows.Forms.Padding(12);
            this.gbAuthorities.Size = new System.Drawing.Size(309, 563);
            this.gbAuthorities.TabIndex = 1;
            this.gbAuthorities.TabStop = false;
            this.gbAuthorities.Text = "AUTHORITIES";
            // 
            // clbAuthorities
            // 
            this.clbAuthorities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAuthorities.FormattingEnabled = true;
            this.clbAuthorities.Location = new System.Drawing.Point(12, 31);
            this.clbAuthorities.Name = "clbAuthorities";
            this.clbAuthorities.Size = new System.Drawing.Size(285, 520);
            this.clbAuthorities.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.gbUserInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(480, 587);
            this.panel1.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(339, 532);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbUserInfo
            // 
            this.gbUserInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbUserInfo.BackColor = System.Drawing.SystemColors.Control;
            this.gbUserInfo.Controls.Add(this.chcActive);
            this.gbUserInfo.Controls.Add(this.panel2);
            this.gbUserInfo.Controls.Add(this.txtPhone);
            this.gbUserInfo.Controls.Add(this.txtMail);
            this.gbUserInfo.Controls.Add(this.txtUserPass);
            this.gbUserInfo.Controls.Add(this.txtUsername);
            this.gbUserInfo.Controls.Add(this.txtNameLastName);
            this.gbUserInfo.Controls.Add(this.label6);
            this.gbUserInfo.Controls.Add(this.label5);
            this.gbUserInfo.Controls.Add(this.label4);
            this.gbUserInfo.Controls.Add(this.label3);
            this.gbUserInfo.Controls.Add(this.label2);
            this.gbUserInfo.Controls.Add(this.label1);
            this.gbUserInfo.Location = new System.Drawing.Point(16, 43);
            this.gbUserInfo.Margin = new System.Windows.Forms.Padding(8, 16, 8, 8);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.Padding = new System.Windows.Forms.Padding(0);
            this.gbUserInfo.Size = new System.Drawing.Size(441, 435);
            this.gbUserInfo.TabIndex = 2;
            this.gbUserInfo.TabStop = false;
            this.gbUserInfo.Text = "USER INFO";
            // 
            // chcActive
            // 
            this.chcActive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chcActive.AutoSize = true;
            this.chcActive.Location = new System.Drawing.Point(347, 408);
            this.chcActive.Name = "chcActive";
            this.chcActive.Size = new System.Drawing.Size(77, 24);
            this.chcActive.TabIndex = 12;
            this.chcActive.Text = "Active";
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
            this.panel2.Location = new System.Drawing.Point(174, 281);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 117);
            this.panel2.TabIndex = 11;
            // 
            // numeric2
            // 
            this.numeric2.DecimalPlaces = 2;
            this.numeric2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numeric2.Location = new System.Drawing.Point(177, 15);
            this.numeric2.Name = "numeric2";
            this.numeric2.Size = new System.Drawing.Size(71, 26);
            this.numeric2.TabIndex = 13;
            // 
            // numeric1
            // 
            this.numeric1.DecimalPlaces = 2;
            this.numeric1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numeric1.Location = new System.Drawing.Point(98, 15);
            this.numeric1.Name = "numeric1";
            this.numeric1.Size = new System.Drawing.Size(71, 26);
            this.numeric1.TabIndex = 12;
            // 
            // rbGeneralManager
            // 
            this.rbGeneralManager.AutoSize = true;
            this.rbGeneralManager.Location = new System.Drawing.Point(17, 75);
            this.rbGeneralManager.Name = "rbGeneralManager";
            this.rbGeneralManager.Size = new System.Drawing.Size(199, 24);
            this.rbGeneralManager.TabIndex = 2;
            this.rbGeneralManager.TabStop = true;
            this.rbGeneralManager.Text = "GENERAL MANAGER";
            this.rbGeneralManager.UseVisualStyleBackColor = true;
            // 
            // rbSalesManager
            // 
            this.rbSalesManager.AutoSize = true;
            this.rbSalesManager.Location = new System.Drawing.Point(17, 45);
            this.rbSalesManager.Name = "rbSalesManager";
            this.rbSalesManager.Size = new System.Drawing.Size(173, 24);
            this.rbSalesManager.TabIndex = 1;
            this.rbSalesManager.TabStop = true;
            this.rbSalesManager.Text = "SALES MANAGER";
            this.rbSalesManager.UseVisualStyleBackColor = true;
            // 
            // rbSales
            // 
            this.rbSales.AutoSize = true;
            this.rbSales.Location = new System.Drawing.Point(17, 15);
            this.rbSales.Name = "rbSales";
            this.rbSales.Size = new System.Drawing.Size(84, 24);
            this.rbSales.TabIndex = 0;
            this.rbSales.TabStop = true;
            this.rbSales.Text = "SALES";
            this.rbSales.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(174, 231);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(257, 26);
            this.txtPhone.TabIndex = 10;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(174, 181);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(257, 26);
            this.txtMail.TabIndex = 9;
            // 
            // txtUserPass
            // 
            this.txtUserPass.Location = new System.Drawing.Point(174, 131);
            this.txtUserPass.Name = "txtUserPass";
            this.txtUserPass.Size = new System.Drawing.Size(257, 26);
            this.txtUserPass.TabIndex = 8;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(174, 81);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(257, 26);
            this.txtUsername.TabIndex = 7;
            // 
            // txtNameLastName
            // 
            this.txtNameLastName.Location = new System.Drawing.Point(174, 31);
            this.txtNameLastName.Name = "txtNameLastName";
            this.txtNameLastName.Size = new System.Drawing.Size(257, 26);
            this.txtNameLastName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "DISC LEVEL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "PHONE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "MAIL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "USER PASS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "USERNAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "NAME - LAST NAME";
            // 
            // authorizationValueBindingSource
            // 
            this.authorizationValueBindingSource.DataSource = typeof(LoginForm.DataSet.AuthorizationValue);
            // 
            // FormWorkerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 587);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1148, 634);
            this.Name = "FormWorkerManagement";
            this.Text = "Worker Management";
            this.Load += new System.EventHandler(this.FormWorkerManagement_Load);
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
        private System.Windows.Forms.TextBox txtNameLastName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numeric1;
        private System.Windows.Forms.NumericUpDown numeric2;
        private System.Windows.Forms.BindingSource authRoleBindingSource;
        private System.Windows.Forms.BindingSource authorizationValueBindingSource;
        private System.Windows.Forms.CheckedListBox clbAuthorities;
        private System.Windows.Forms.CheckedListBox clbRoles;
        private System.Windows.Forms.CheckBox chcActive;
    }
}