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
            this.components = new System.ComponentModel.Container();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.btnAddAuth = new System.Windows.Forms.Button();
            this.cbRoleList = new System.Windows.Forms.ComboBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.txtAuthName = new System.Windows.Forms.TextBox();
            this.btnEditWorker = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddWorker = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgWorkerList = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minMargeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkerList)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(553, 18);
            this.btnAddRole.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(142, 29);
            this.btnAddRole.TabIndex = 0;
            this.btnAddRole.Text = "AddRole";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnAddAuth
            // 
            this.btnAddAuth.Location = new System.Drawing.Point(553, 50);
            this.btnAddAuth.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAuth.Name = "btnAddAuth";
            this.btnAddAuth.Size = new System.Drawing.Size(142, 29);
            this.btnAddAuth.TabIndex = 1;
            this.btnAddAuth.Text = "AddAuth";
            this.btnAddAuth.UseVisualStyleBackColor = true;
            this.btnAddAuth.Click += new System.EventHandler(this.btnAddAuth_Click);
            // 
            // cbRoleList
            // 
            this.cbRoleList.FormattingEnabled = true;
            this.cbRoleList.Location = new System.Drawing.Point(15, 55);
            this.cbRoleList.Margin = new System.Windows.Forms.Padding(4);
            this.cbRoleList.Name = "cbRoleList";
            this.cbRoleList.Size = new System.Drawing.Size(205, 28);
            this.cbRoleList.TabIndex = 2;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(253, 24);
            this.txtRoleName.Margin = new System.Windows.Forms.Padding(4);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(276, 26);
            this.txtRoleName.TabIndex = 3;
            // 
            // txtAuthName
            // 
            this.txtAuthName.Location = new System.Drawing.Point(253, 55);
            this.txtAuthName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuthName.Name = "txtAuthName";
            this.txtAuthName.Size = new System.Drawing.Size(276, 26);
            this.txtAuthName.TabIndex = 4;
            // 
            // btnEditWorker
            // 
            this.btnEditWorker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditWorker.Depth = 0;
            this.btnEditWorker.Location = new System.Drawing.Point(112, 6);
            this.btnEditWorker.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.btnEditWorker.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditWorker.Name = "btnEditWorker";
            this.btnEditWorker.Primary = true;
            this.btnEditWorker.Size = new System.Drawing.Size(100, 48);
            this.btnEditWorker.TabIndex = 11;
            this.btnEditWorker.Text = "Edit user";
            this.btnEditWorker.UseVisualStyleBackColor = true;
            this.btnEditWorker.Click += new System.EventHandler(this.btnEditWorker_Click);
            // 
            // btnAddWorker
            // 
            this.btnAddWorker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddWorker.Depth = 0;
            this.btnAddWorker.Location = new System.Drawing.Point(6, 6);
            this.btnAddWorker.Margin = new System.Windows.Forms.Padding(6, 6, 3, 3);
            this.btnAddWorker.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddWorker.Name = "btnAddWorker";
            this.btnAddWorker.Primary = true;
            this.btnAddWorker.Size = new System.Drawing.Size(100, 48);
            this.btnAddWorker.TabIndex = 12;
            this.btnAddWorker.Text = "Add User";
            this.btnAddWorker.UseVisualStyleBackColor = true;
            this.btnAddWorker.Click += new System.EventHandler(this.btnAddWorker_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgWorkerList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 665);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // dgWorkerList
            // 
            this.dgWorkerList.AllowUserToAddRows = false;
            this.dgWorkerList.AllowUserToDeleteRows = false;
            this.dgWorkerList.AllowUserToOrderColumns = true;
            this.dgWorkerList.AutoGenerateColumns = false;
            this.dgWorkerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWorkerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.isActiveDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.minMargeDataGridViewTextBoxColumn});
            this.dgWorkerList.DataSource = this.workerBindingSource;
            this.dgWorkerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWorkerList.Location = new System.Drawing.Point(3, 78);
            this.dgWorkerList.Name = "dgWorkerList";
            this.dgWorkerList.ReadOnly = true;
            this.dgWorkerList.RowTemplate.Height = 24;
            this.dgWorkerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWorkerList.Size = new System.Drawing.Size(787, 484);
            this.dgWorkerList.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddWorker);
            this.flowLayoutPanel1.Controls.Add(this.btnEditWorker);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(787, 69);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRoleName);
            this.panel1.Controls.Add(this.txtAuthName);
            this.panel1.Controls.Add(this.btnAddRole);
            this.panel1.Controls.Add(this.btnAddAuth);
            this.panel1.Controls.Add(this.cbRoleList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 568);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 94);
            this.panel1.TabIndex = 2;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "USER NAME";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isActiveDataGridViewTextBoxColumn
            // 
            this.isActiveDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isActiveDataGridViewTextBoxColumn.DataPropertyName = "isActive";
            this.isActiveDataGridViewTextBoxColumn.HeaderText = "STATUS";
            this.isActiveDataGridViewTextBoxColumn.Name = "isActiveDataGridViewTextBoxColumn";
            this.isActiveDataGridViewTextBoxColumn.ReadOnly = true;
            this.isActiveDataGridViewTextBoxColumn.Width = 103;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "EMAIL";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "PHONE";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "LEVEL";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 91;
            // 
            // minMargeDataGridViewTextBoxColumn
            // 
            this.minMargeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.minMargeDataGridViewTextBoxColumn.DataPropertyName = "MinMarge";
            this.minMargeDataGridViewTextBoxColumn.HeaderText = "LEVEL STATUS";
            this.minMargeDataGridViewTextBoxColumn.Name = "minMargeDataGridViewTextBoxColumn";
            this.minMargeDataGridViewTextBoxColumn.ReadOnly = true;
            this.minMargeDataGridViewTextBoxColumn.Width = 147;
            // 
            // workerBindingSource
            // 
            this.workerBindingSource.DataSource = typeof(LoginForm.DataSet.Worker);
            // 
            // FormRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 665);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(811, 712);
            this.Name = "FormRoles";
            this.Text = "FormRoles";
            this.Load += new System.EventHandler(this.FormRoles_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkerList)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnAddAuth;
        private System.Windows.Forms.ComboBox cbRoleList;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.TextBox txtAuthName;
        private MaterialSkin.Controls.MaterialRaisedButton btnEditWorker;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddWorker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgWorkerList;
        private System.Windows.Forms.BindingSource workerBindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isActiveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minMargeDataGridViewTextBoxColumn;
    }
}