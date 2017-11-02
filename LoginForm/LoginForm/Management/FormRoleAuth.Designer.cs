namespace LoginForm.ManagementModule
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
            this.txtSearchRole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRoleList = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSearchAuthority = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clbAuthorizationList = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearchUserAuthority = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clbNewAuthorizations = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
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
            this.lblRoletobeEdited.AutoSize = true;
            this.lblRoletobeEdited.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoletobeEdited.Location = new System.Drawing.Point(22, 18);
            this.lblRoletobeEdited.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoletobeEdited.Name = "lblRoletobeEdited";
            this.lblRoletobeEdited.Size = new System.Drawing.Size(113, 18);
            this.lblRoletobeEdited.TabIndex = 4;
            this.lblRoletobeEdited.Text = "Selected Role";
            // 
            // chcNewRole
            // 
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1172, 606);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1172, 456);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSearchRole);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbRoleList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(16);
            this.panel2.Size = new System.Drawing.Size(357, 456);
            this.panel2.TabIndex = 12;
            // 
            // txtSearchRole
            // 
            this.txtSearchRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchRole.Location = new System.Drawing.Point(16, 48);
            this.txtSearchRole.Name = "txtSearchRole";
            this.txtSearchRole.Size = new System.Drawing.Size(325, 24);
            this.txtSearchRole.TabIndex = 10;
            this.txtSearchRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchRole_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Role List";
            // 
            // lbRoleList
            // 
            this.lbRoleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRoleList.DisplayMember = "roleName";
            this.lbRoleList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoleList.FormattingEnabled = true;
            this.lbRoleList.ItemHeight = 20;
            this.lbRoleList.Location = new System.Drawing.Point(16, 91);
            this.lbRoleList.Margin = new System.Windows.Forms.Padding(4);
            this.lbRoleList.Name = "lbRoleList";
            this.lbRoleList.Size = new System.Drawing.Size(325, 324);
            this.lbRoleList.TabIndex = 8;
            this.lbRoleList.ValueMember = "RoleID";
            this.lbRoleList.SelectedIndexChanged += new System.EventHandler(this.lbRoleList_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSearchAuthority);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.clbAuthorizationList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(357, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(16);
            this.panel3.Size = new System.Drawing.Size(357, 456);
            this.panel3.TabIndex = 13;
            // 
            // txtSearchAuthority
            // 
            this.txtSearchAuthority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchAuthority.Location = new System.Drawing.Point(19, 48);
            this.txtSearchAuthority.Name = "txtSearchAuthority";
            this.txtSearchAuthority.Size = new System.Drawing.Size(325, 24);
            this.txtSearchAuthority.TabIndex = 11;
            this.txtSearchAuthority.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchAuthority_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Authority List";
            // 
            // clbAuthorizationList
            // 
            this.clbAuthorizationList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbAuthorizationList.CheckOnClick = true;
            this.clbAuthorizationList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbAuthorizationList.FormattingEnabled = true;
            this.clbAuthorizationList.Location = new System.Drawing.Point(19, 95);
            this.clbAuthorizationList.Margin = new System.Windows.Forms.Padding(4);
            this.clbAuthorizationList.Name = "clbAuthorizationList";
            this.clbAuthorizationList.Size = new System.Drawing.Size(325, 319);
            this.clbAuthorizationList.TabIndex = 10;
            this.clbAuthorizationList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbAuthorizationList_MouseClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtSearchUserAuthority);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.clbNewAuthorizations);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(814, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(16);
            this.panel4.Size = new System.Drawing.Size(358, 456);
            this.panel4.TabIndex = 14;
            // 
            // txtSearchUserAuthority
            // 
            this.txtSearchUserAuthority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchUserAuthority.Location = new System.Drawing.Point(19, 48);
            this.txtSearchUserAuthority.Name = "txtSearchUserAuthority";
            this.txtSearchUserAuthority.Size = new System.Drawing.Size(326, 24);
            this.txtSearchUserAuthority.TabIndex = 13;
            this.txtSearchUserAuthority.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchUserAuthority_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "New Authority List";
            // 
            // clbNewAuthorizations
            // 
            this.clbNewAuthorizations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbNewAuthorizations.CheckOnClick = true;
            this.clbNewAuthorizations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbNewAuthorizations.FormattingEnabled = true;
            this.clbNewAuthorizations.Location = new System.Drawing.Point(19, 95);
            this.clbNewAuthorizations.Margin = new System.Windows.Forms.Padding(4);
            this.clbNewAuthorizations.Name = "clbNewAuthorizations";
            this.clbNewAuthorizations.Size = new System.Drawing.Size(326, 319);
            this.clbNewAuthorizations.TabIndex = 11;
            this.clbNewAuthorizations.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbNewAuthorizations_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
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
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(112)))), ((int)(((byte)(67)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(972, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 150);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ClientSize = new System.Drawing.Size(1172, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1137, 645);
            this.Name = "FormRoleAuths";
            this.Text = "Roles & Authorizations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormRoleAuths_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchRole;
        private System.Windows.Forms.TextBox txtSearchAuthority;
        private System.Windows.Forms.TextBox txtSearchUserAuthority;
    }
}