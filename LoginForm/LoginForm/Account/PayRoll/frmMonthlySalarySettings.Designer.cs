﻿namespace LoginForm
{
    partial class frmMonthlySalarySettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonthlySalarySettings));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblSalaryMonth = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvMonthySalarySettings = new System.Windows.Forms.DataGridView();
            this.dgvtxtSlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtMonthlySalaryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtdefaultPackageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtSalaryPackageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcmbPackage = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvtxtMonthlySalaryDetailsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtnarration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.dtpSalaryMonth = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthySalarySettings)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(929, 689);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 33);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(808, 689);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 33);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNarration.Location = new System.Drawing.Point(560, 578);
            this.lblNarration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(67, 17);
            this.lblNarration.TabIndex = 36;
            this.lblNarration.Text = "Narration";
            // 
            // lblSalaryMonth
            // 
            this.lblSalaryMonth.AutoSize = true;
            this.lblSalaryMonth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSalaryMonth.Location = new System.Drawing.Point(629, 23);
            this.lblSalaryMonth.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblSalaryMonth.Name = "lblSalaryMonth";
            this.lblSalaryMonth.Size = new System.Drawing.Size(91, 17);
            this.lblSalaryMonth.TabIndex = 35;
            this.lblSalaryMonth.Text = "Salary Month";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(565, 689);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(687, 689);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 33);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClear_KeyDown);
            // 
            // dgvMonthySalarySettings
            // 
            this.dgvMonthySalarySettings.AllowUserToAddRows = false;
            this.dgvMonthySalarySettings.AllowUserToDeleteRows = false;
            this.dgvMonthySalarySettings.AllowUserToResizeColumns = false;
            this.dgvMonthySalarySettings.AllowUserToResizeRows = false;
            this.dgvMonthySalarySettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonthySalarySettings.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonthySalarySettings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(133)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(117)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonthySalarySettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonthySalarySettings.ColumnHeadersHeight = 25;
            this.dgvMonthySalarySettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMonthySalarySettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtSlNo,
            this.dgvtxtMonthlySalaryId,
            this.dgvtxtdefaultPackageId,
            this.dgvtxtSalaryPackageName,
            this.dgvtxtEmployeeId,
            this.dgvtxtEmployeeCode,
            this.dgvtxtEmployee,
            this.dgvcmbPackage,
            this.dgvtxtMonthlySalaryDetailsId,
            this.dgvtxtnarration});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(238)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(202)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonthySalarySettings.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMonthySalarySettings.EnableHeadersVisualStyles = false;
            this.dgvMonthySalarySettings.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvMonthySalarySettings.Location = new System.Drawing.Point(24, 47);
            this.dgvMonthySalarySettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMonthySalarySettings.MultiSelect = false;
            this.dgvMonthySalarySettings.Name = "dgvMonthySalarySettings";
            this.dgvMonthySalarySettings.RowHeadersVisible = false;
            this.dgvMonthySalarySettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMonthySalarySettings.Size = new System.Drawing.Size(1019, 522);
            this.dgvMonthySalarySettings.TabIndex = 1;
            this.dgvMonthySalarySettings.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMonthySalarySettings_DataBindingComplete);
            this.dgvMonthySalarySettings.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMonthySalarySettings_DataError);
            this.dgvMonthySalarySettings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMonthySalarySettings_KeyDown);
            // 
            // dgvtxtSlNo
            // 
            this.dgvtxtSlNo.DataPropertyName = "sl.no";
            this.dgvtxtSlNo.HeaderText = "Sl No";
            this.dgvtxtSlNo.Name = "dgvtxtSlNo";
            this.dgvtxtSlNo.ReadOnly = true;
            this.dgvtxtSlNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtxtMonthlySalaryId
            // 
            this.dgvtxtMonthlySalaryId.DataPropertyName = "monthlySalaryId";
            this.dgvtxtMonthlySalaryId.HeaderText = "MonthlySalaryId";
            this.dgvtxtMonthlySalaryId.Name = "dgvtxtMonthlySalaryId";
            this.dgvtxtMonthlySalaryId.ReadOnly = true;
            this.dgvtxtMonthlySalaryId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtxtMonthlySalaryId.Visible = false;
            // 
            // dgvtxtdefaultPackageId
            // 
            this.dgvtxtdefaultPackageId.DataPropertyName = "defaultPackageId";
            this.dgvtxtdefaultPackageId.HeaderText = "DefaultPackageId";
            this.dgvtxtdefaultPackageId.Name = "dgvtxtdefaultPackageId";
            this.dgvtxtdefaultPackageId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtxtdefaultPackageId.Visible = false;
            // 
            // dgvtxtSalaryPackageName
            // 
            this.dgvtxtSalaryPackageName.DataPropertyName = "salaryPackageName";
            this.dgvtxtSalaryPackageName.HeaderText = "Salary Package Name";
            this.dgvtxtSalaryPackageName.Name = "dgvtxtSalaryPackageName";
            this.dgvtxtSalaryPackageName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtxtSalaryPackageName.Visible = false;
            // 
            // dgvtxtEmployeeId
            // 
            this.dgvtxtEmployeeId.DataPropertyName = "employeeId";
            this.dgvtxtEmployeeId.HeaderText = "Employee ID";
            this.dgvtxtEmployeeId.Name = "dgvtxtEmployeeId";
            this.dgvtxtEmployeeId.ReadOnly = true;
            this.dgvtxtEmployeeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtxtEmployeeId.Visible = false;
            // 
            // dgvtxtEmployeeCode
            // 
            this.dgvtxtEmployeeCode.DataPropertyName = "employeeCode";
            this.dgvtxtEmployeeCode.HeaderText = "Employee Code";
            this.dgvtxtEmployeeCode.Name = "dgvtxtEmployeeCode";
            this.dgvtxtEmployeeCode.ReadOnly = true;
            this.dgvtxtEmployeeCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtxtEmployee
            // 
            this.dgvtxtEmployee.DataPropertyName = "employeeName";
            this.dgvtxtEmployee.HeaderText = "Employee";
            this.dgvtxtEmployee.Name = "dgvtxtEmployee";
            this.dgvtxtEmployee.ReadOnly = true;
            this.dgvtxtEmployee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcmbPackage
            // 
            this.dgvcmbPackage.DataPropertyName = "salaryPackageId";
            this.dgvcmbPackage.HeaderText = "Package";
            this.dgvcmbPackage.Name = "dgvcmbPackage";
            this.dgvcmbPackage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgvtxtMonthlySalaryDetailsId
            // 
            this.dgvtxtMonthlySalaryDetailsId.DataPropertyName = "monthlySalaryDetailsId";
            this.dgvtxtMonthlySalaryDetailsId.HeaderText = "MonthlySalaryDetailsId";
            this.dgvtxtMonthlySalaryDetailsId.Name = "dgvtxtMonthlySalaryDetailsId";
            this.dgvtxtMonthlySalaryDetailsId.ReadOnly = true;
            this.dgvtxtMonthlySalaryDetailsId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtxtMonthlySalaryDetailsId.Visible = false;
            // 
            // dgvtxtnarration
            // 
            this.dgvtxtnarration.DataPropertyName = "narration";
            this.dgvtxtnarration.HeaderText = "Narration";
            this.dgvtxtnarration.Name = "dgvtxtnarration";
            this.dgvtxtnarration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtxtnarration.Visible = false;
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(708, 578);
            this.txtNarration.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(332, 104);
            this.txtNarration.TabIndex = 2;
            this.txtNarration.Enter += new System.EventHandler(this.txtNarration_Enter);
            this.txtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNarration_KeyPress);
            this.txtNarration.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNarration_KeyUp);
            // 
            // dtpSalaryMonth
            // 
            this.dtpSalaryMonth.CustomFormat = "MMM yyy";
            this.dtpSalaryMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSalaryMonth.Location = new System.Drawing.Point(773, 18);
            this.dtpSalaryMonth.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.dtpSalaryMonth.Name = "dtpSalaryMonth";
            this.dtpSalaryMonth.Size = new System.Drawing.Size(265, 22);
            this.dtpSalaryMonth.TabIndex = 0;
            this.dtpSalaryMonth.ValueChanged += new System.EventHandler(this.dtpSalaryMonth_ValueChanged);
            this.dtpSalaryMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpSalaryMonth_KeyDown);
            // 
            // frmMonthlySalarySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(111)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.dtpSalaryMonth);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.lblSalaryMonth);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvMonthySalarySettings);
            this.Controls.Add(this.txtNarration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmMonthlySalarySettings";
            this.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Salary Settings";
            this.Load += new System.EventHandler(this.frmMonthlySalarySettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMonthlySalarySettings_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthySalarySettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Label lblSalaryMonth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvMonthySalarySettings;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.DateTimePicker dtpSalaryMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtSlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtMonthlySalaryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtdefaultPackageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtSalaryPackageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtEmployee;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcmbPackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtMonthlySalaryDetailsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtnarration;
    }
}