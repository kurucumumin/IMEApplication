namespace LoginForm.WorkerManagement
{
    partial class FormRoleAuths
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
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chcNewRole = new System.Windows.Forms.CheckBox();
            this.txtNewRoleName = new System.Windows.Forms.TextBox();
            this.lbRoleList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clbAuthorizationList = new System.Windows.Forms.CheckedListBox();
            this.clbNewAuthorizations = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRole
            // 
            this.cbRole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbRole.DisplayMember = "RoleID";
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(135, 15);
            this.cbRole.Margin = new System.Windows.Forms.Padding(4);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(210, 26);
            this.cbRole.TabIndex = 0;
            this.cbRole.ValueMember = "RoleID";
            this.cbRole.SelectedIndexChanged += new System.EventHandler(this.cbRole_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Role";
            // 
            // chcNewRole
            // 
            this.chcNewRole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chcNewRole.AutoSize = true;
            this.chcNewRole.Location = new System.Drawing.Point(135, 61);
            this.chcNewRole.Name = "chcNewRole";
            this.chcNewRole.Size = new System.Drawing.Size(95, 22);
            this.chcNewRole.TabIndex = 6;
            this.chcNewRole.Text = "New Role";
            this.chcNewRole.UseVisualStyleBackColor = true;
            this.chcNewRole.CheckedChanged += new System.EventHandler(this.chcNewRole_CheckedChanged);
            // 
            // txtNewRoleName
            // 
            this.txtNewRoleName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNewRoleName.Location = new System.Drawing.Point(135, 98);
            this.txtNewRoleName.Name = "txtNewRoleName";
            this.txtNewRoleName.Size = new System.Drawing.Size(210, 24);
            this.txtNewRoleName.TabIndex = 7;
            // 
            // lbRoleList
            // 
            this.lbRoleList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbRoleList.DisplayMember = "roleName";
            this.lbRoleList.FormattingEnabled = true;
            this.lbRoleList.ItemHeight = 18;
            this.lbRoleList.Location = new System.Drawing.Point(57, 32);
            this.lbRoleList.Margin = new System.Windows.Forms.Padding(4);
            this.lbRoleList.Name = "lbRoleList";
            this.lbRoleList.Size = new System.Drawing.Size(293, 364);
            this.lbRoleList.TabIndex = 8;
            this.lbRoleList.ValueMember = "RoleID";
            this.lbRoleList.SelectedIndexChanged += new System.EventHandler(this.lbRoleList_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1172, 598);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbRole);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chcNewRole);
            this.panel1.Controls.Add(this.txtNewRoleName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1172, 150);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Role Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.clbAuthorizationList);
            this.panel2.Controls.Add(this.lbRoleList);
            this.panel2.Controls.Add(this.clbNewAuthorizations);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1172, 448);
            this.panel2.TabIndex = 1;
            // 
            // clbAuthorizationList
            // 
            this.clbAuthorizationList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clbAuthorizationList.CheckOnClick = true;
            this.clbAuthorizationList.FormattingEnabled = true;
            this.clbAuthorizationList.Location = new System.Drawing.Point(358, 32);
            this.clbAuthorizationList.Margin = new System.Windows.Forms.Padding(4);
            this.clbAuthorizationList.Name = "clbAuthorizationList";
            this.clbAuthorizationList.Size = new System.Drawing.Size(293, 365);
            this.clbAuthorizationList.TabIndex = 10;
            this.clbAuthorizationList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbAuthorizationList_MouseClick);
            // 
            // clbNewAuthorizations
            // 
            this.clbNewAuthorizations.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clbNewAuthorizations.CheckOnClick = true;
            this.clbNewAuthorizations.FormattingEnabled = true;
            this.clbNewAuthorizations.Location = new System.Drawing.Point(802, 32);
            this.clbNewAuthorizations.Margin = new System.Windows.Forms.Padding(4);
            this.clbNewAuthorizations.Name = "clbNewAuthorizations";
            this.clbNewAuthorizations.Size = new System.Drawing.Size(293, 365);
            this.clbNewAuthorizations.TabIndex = 11;
            this.clbNewAuthorizations.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbNewAuthorizations_MouseClick);
            // 
            // FormRoleAuths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 598);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1137, 645);
            this.Name = "FormRoleAuths";
            this.Text = "Roles & Authorizations";
            this.Load += new System.EventHandler(this.FormRoleAuths_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chcNewRole;
        private System.Windows.Forms.TextBox txtNewRoleName;
        private System.Windows.Forms.ListBox lbRoleList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbAuthorizationList;
        private System.Windows.Forms.CheckedListBox clbNewAuthorizations;
    }
}