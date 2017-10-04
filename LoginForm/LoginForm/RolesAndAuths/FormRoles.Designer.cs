namespace LoginForm.RolesAndAuths
{
    partial class FormRoles
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
            this.btnAddRole = new System.Windows.Forms.Button();
            this.btnAddAuth = new System.Windows.Forms.Button();
            this.cbRoleList = new System.Windows.Forms.ComboBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.txtAuthName = new System.Windows.Forms.TextBox();
            this.btnAddWorker = new System.Windows.Forms.Button();
            this.lbWorkerList = new System.Windows.Forms.ListBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(522, 12);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(114, 23);
            this.btnAddRole.TabIndex = 0;
            this.btnAddRole.Text = "AddRole";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnAddAuth
            // 
            this.btnAddAuth.Location = new System.Drawing.Point(522, 41);
            this.btnAddAuth.Name = "btnAddAuth";
            this.btnAddAuth.Size = new System.Drawing.Size(114, 23);
            this.btnAddAuth.TabIndex = 1;
            this.btnAddAuth.Text = "AddAuth";
            this.btnAddAuth.UseVisualStyleBackColor = true;
            this.btnAddAuth.Click += new System.EventHandler(this.btnAddAuth_Click);
            // 
            // cbRoleList
            // 
            this.cbRoleList.FormattingEnabled = true;
            this.cbRoleList.Location = new System.Drawing.Point(11, 41);
            this.cbRoleList.Name = "cbRoleList";
            this.cbRoleList.Size = new System.Drawing.Size(265, 24);
            this.cbRoleList.TabIndex = 2;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(282, 12);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(222, 22);
            this.txtRoleName.TabIndex = 3;
            // 
            // txtAuthName
            // 
            this.txtAuthName.Location = new System.Drawing.Point(282, 41);
            this.txtAuthName.Name = "txtAuthName";
            this.txtAuthName.Size = new System.Drawing.Size(222, 22);
            this.txtAuthName.TabIndex = 4;
            // 
            // btnAddWorker
            // 
            this.btnAddWorker.Location = new System.Drawing.Point(522, 260);
            this.btnAddWorker.Name = "btnAddWorker";
            this.btnAddWorker.Size = new System.Drawing.Size(114, 23);
            this.btnAddWorker.TabIndex = 5;
            this.btnAddWorker.Text = "AddWorker";
            this.btnAddWorker.UseVisualStyleBackColor = true;
            this.btnAddWorker.Click += new System.EventHandler(this.btnAddWorker_Click);
            // 
            // lbWorkerList
            // 
            this.lbWorkerList.FormattingEnabled = true;
            this.lbWorkerList.ItemHeight = 16;
            this.lbWorkerList.Location = new System.Drawing.Point(11, 71);
            this.lbWorkerList.Name = "lbWorkerList";
            this.lbWorkerList.Size = new System.Drawing.Size(265, 212);
            this.lbWorkerList.TabIndex = 6;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(282, 166);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(114, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "button1";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // FormRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 316);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lbWorkerList);
            this.Controls.Add(this.btnAddWorker);
            this.Controls.Add(this.txtAuthName);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.cbRoleList);
            this.Controls.Add(this.btnAddAuth);
            this.Controls.Add(this.btnAddRole);
            this.MinimumSize = new System.Drawing.Size(645, 235);
            this.Name = "FormRoles";
            this.Text = "FormRoles";
            this.Load += new System.EventHandler(this.FormRoles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnAddAuth;
        private System.Windows.Forms.ComboBox cbRoleList;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.TextBox txtAuthName;
        private System.Windows.Forms.Button btnAddWorker;
        private System.Windows.Forms.ListBox lbWorkerList;
        private System.Windows.Forms.Button btnEdit;
    }
}