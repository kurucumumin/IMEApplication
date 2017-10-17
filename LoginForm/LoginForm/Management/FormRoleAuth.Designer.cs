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
            this.lblRoletobeEdited = new System.Windows.Forms.Label();
            this.chcNewRole = new System.Windows.Forms.CheckBox();
            this.txtNewRoleName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbRoleList = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clbAuthorizationList = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.clbNewAuthorizations = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNewRoleName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRole
            // 
            this.cbRole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbRole.DisplayMember = "RoleID";
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(168, 13);
            this.cbRole.Margin = new System.Windows.Forms.Padding(4);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(210, 26);
            this.cbRole.TabIndex = 0;
            this.cbRole.ValueMember = "RoleID";
            this.cbRole.SelectedIndexChanged += new System.EventHandler(this.cbRole_SelectedIndexChanged);
            // 
            // lblRoletobeEdited
            // 
            this.lblRoletobeEdited.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRoletobeEdited.AutoSize = true;
            this.lblRoletobeEdited.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoletobeEdited.Location = new System.Drawing.Point(22, 18);
            this.lblRoletobeEdited.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoletobeEdited.Name = "lblRoletobeEdited";
            this.lblRoletobeEdited.Size = new System.Drawing.Size(138, 18);
            this.lblRoletobeEdited.TabIndex = 4;
            this.lblRoletobeEdited.Text = "Role to be Edited";
            // 
            // chcNewRole
            // 
            this.chcNewRole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chcNewRole.AutoSize = true;
            this.chcNewRole.Location = new System.Drawing.Point(168, 60);
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
            this.txtNewRoleName.Location = new System.Drawing.Point(168, 101);
            this.txtNewRoleName.Name = "txtNewRoleName";
            this.txtNewRoleName.Size = new System.Drawing.Size(210, 24);
            this.txtNewRoleName.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1172, 598);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 150);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1172, 448);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbRoleList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(16);
            this.panel2.Size = new System.Drawing.Size(357, 448);
            this.panel2.TabIndex = 12;
            // 
            // lbRoleList
            // 
            this.lbRoleList.DisplayMember = "roleName";
            this.lbRoleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoleList.FormattingEnabled = true;
            this.lbRoleList.ItemHeight = 18;
            this.lbRoleList.Location = new System.Drawing.Point(16, 16);
            this.lbRoleList.Margin = new System.Windows.Forms.Padding(4);
            this.lbRoleList.Name = "lbRoleList";
            this.lbRoleList.Size = new System.Drawing.Size(325, 416);
            this.lbRoleList.TabIndex = 8;
            this.lbRoleList.ValueMember = "RoleID";
            this.lbRoleList.SelectedIndexChanged += new System.EventHandler(this.lbRoleList_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.clbAuthorizationList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(357, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(16);
            this.panel3.Size = new System.Drawing.Size(357, 448);
            this.panel3.TabIndex = 13;
            // 
            // clbAuthorizationList
            // 
            this.clbAuthorizationList.CheckOnClick = true;
            this.clbAuthorizationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAuthorizationList.FormattingEnabled = true;
            this.clbAuthorizationList.Location = new System.Drawing.Point(16, 16);
            this.clbAuthorizationList.Margin = new System.Windows.Forms.Padding(4);
            this.clbAuthorizationList.Name = "clbAuthorizationList";
            this.clbAuthorizationList.Size = new System.Drawing.Size(325, 416);
            this.clbAuthorizationList.TabIndex = 10;
            this.clbAuthorizationList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbAuthorizationList_MouseClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.clbNewAuthorizations);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(814, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(16);
            this.panel4.Size = new System.Drawing.Size(358, 448);
            this.panel4.TabIndex = 14;
            // 
            // clbNewAuthorizations
            // 
            this.clbNewAuthorizations.CheckOnClick = true;
            this.clbNewAuthorizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbNewAuthorizations.FormattingEnabled = true;
            this.clbNewAuthorizations.Location = new System.Drawing.Point(16, 16);
            this.clbNewAuthorizations.Margin = new System.Windows.Forms.Padding(4);
            this.clbNewAuthorizations.Name = "clbNewAuthorizations";
            this.clbNewAuthorizations.Size = new System.Drawing.Size(326, 416);
            this.clbNewAuthorizations.TabIndex = 11;
            this.clbNewAuthorizations.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbNewAuthorizations_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.lblNewRoleName);
            this.panel1.Controls.Add(this.cbRole);
            this.panel1.Controls.Add(this.lblRoletobeEdited);
            this.panel1.Controls.Add(this.chcNewRole);
            this.panel1.Controls.Add(this.txtNewRoleName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1172, 150);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(1072, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 150);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNewRoleName
            // 
            this.lblNewRoleName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNewRoleName.AutoSize = true;
            this.lblNewRoleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewRoleName.Location = new System.Drawing.Point(68, 104);
            this.lblNewRoleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewRoleName.Name = "lblNewRoleName";
            this.lblNewRoleName.Size = new System.Drawing.Size(92, 18);
            this.lblNewRoleName.TabIndex = 8;
            this.lblNewRoleName.Text = "Role Name";
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lblRoletobeEdited;
        private System.Windows.Forms.CheckBox chcNewRole;
        private System.Windows.Forms.TextBox txtNewRoleName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNewRoleName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckedListBox clbNewAuthorizations;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lbRoleList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox clbAuthorizationList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSave;
    }
}