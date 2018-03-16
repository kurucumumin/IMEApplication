namespace LoginForm
{
    partial class frmPaySlip
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
            this.lblSalaryMonth = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpSalaryMonth = new System.Windows.Forms.DateTimePicker();
            this.lblSalaryMonthValidator = new System.Windows.Forms.Label();
            this.lblEmployeeValidator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSalaryMonth
            // 
            this.lblSalaryMonth.AutoSize = true;
            this.lblSalaryMonth.ForeColor = System.Drawing.Color.White;
            this.lblSalaryMonth.Location = new System.Drawing.Point(93, 94);
            this.lblSalaryMonth.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblSalaryMonth.Name = "lblSalaryMonth";
            this.lblSalaryMonth.Size = new System.Drawing.Size(91, 17);
            this.lblSalaryMonth.TabIndex = 11;
            this.lblSalaryMonth.Text = "Salary Month";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Location = new System.Drawing.Point(235, 121);
            this.cmbEmployee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(265, 24);
            this.cmbEmployee.TabIndex = 1;
            this.cmbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEmployee_KeyDown);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.ForeColor = System.Drawing.Color.White;
            this.lblEmployee.Location = new System.Drawing.Point(93, 126);
            this.lblEmployee.Margin = new System.Windows.Forms.Padding(7, 6, 7, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(70, 17);
            this.lblEmployee.TabIndex = 13;
            this.lblEmployee.Text = "Employee";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(235, 156);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 33);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPrint_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(356, 156);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // dtpSalaryMonth
            // 
            this.dtpSalaryMonth.CustomFormat = "MMM  yyyy";
            this.dtpSalaryMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSalaryMonth.Location = new System.Drawing.Point(235, 89);
            this.dtpSalaryMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpSalaryMonth.Name = "dtpSalaryMonth";
            this.dtpSalaryMonth.Size = new System.Drawing.Size(265, 22);
            this.dtpSalaryMonth.TabIndex = 0;
            this.dtpSalaryMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpSalaryMonth_KeyDown);
            // 
            // lblSalaryMonthValidator
            // 
            this.lblSalaryMonthValidator.AutoSize = true;
            this.lblSalaryMonthValidator.ForeColor = System.Drawing.Color.Red;
            this.lblSalaryMonthValidator.Location = new System.Drawing.Point(507, 97);
            this.lblSalaryMonthValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblSalaryMonthValidator.Name = "lblSalaryMonthValidator";
            this.lblSalaryMonthValidator.Size = new System.Drawing.Size(13, 17);
            this.lblSalaryMonthValidator.TabIndex = 114;
            this.lblSalaryMonthValidator.Text = "*";
            // 
            // lblEmployeeValidator
            // 
            this.lblEmployeeValidator.AutoSize = true;
            this.lblEmployeeValidator.ForeColor = System.Drawing.Color.Red;
            this.lblEmployeeValidator.Location = new System.Drawing.Point(507, 130);
            this.lblEmployeeValidator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblEmployeeValidator.Name = "lblEmployeeValidator";
            this.lblEmployeeValidator.Size = new System.Drawing.Size(13, 17);
            this.lblEmployeeValidator.TabIndex = 115;
            this.lblEmployeeValidator.Text = "*";
            // 
            // frmPaySlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(111)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(627, 308);
            this.Controls.Add(this.lblEmployeeValidator);
            this.Controls.Add(this.lblSalaryMonthValidator);
            this.Controls.Add(this.dtpSalaryMonth);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblSalaryMonth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmPaySlip";
            this.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay Slip";
            this.Load += new System.EventHandler(this.frmPaySlip_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPaySlip_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalaryMonth;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpSalaryMonth;
        private System.Windows.Forms.Label lblSalaryMonthValidator;
        private System.Windows.Forms.Label lblEmployeeValidator;
    }
}