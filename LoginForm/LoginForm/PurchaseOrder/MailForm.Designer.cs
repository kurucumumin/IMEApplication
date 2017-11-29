namespace LoginForm.PurchaseOrder
{
    partial class MailForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgMail = new System.Windows.Forms.DataGridView();
            this.radioDefault = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.radioSpecial = new System.Windows.Forms.RadioButton();
            this.mailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mailAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tooDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgMail);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(760, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mail To List";
            // 
            // dgMail
            // 
            this.dgMail.AllowUserToOrderColumns = true;
            this.dgMail.AutoGenerateColumns = false;
            this.dgMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.mailAddressDataGridViewTextBoxColumn,
            this.ccDataGridViewTextBoxColumn,
            this.tooDataGridViewTextBoxColumn});
            this.dgMail.DataSource = this.mailBindingSource;
            this.dgMail.Location = new System.Drawing.Point(4, 20);
            this.dgMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgMail.Name = "dgMail";
            this.dgMail.Size = new System.Drawing.Size(756, 154);
            this.dgMail.TabIndex = 0;
            this.dgMail.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgMail_UserAddedRow);
            this.dgMail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgMail_KeyDown);
            // 
            // radioDefault
            // 
            this.radioDefault.AutoSize = true;
            this.radioDefault.Checked = true;
            this.radioDefault.Location = new System.Drawing.Point(153, 192);
            this.radioDefault.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioDefault.Name = "radioDefault";
            this.radioDefault.Size = new System.Drawing.Size(74, 21);
            this.radioDefault.TabIndex = 2;
            this.radioDefault.TabStop = true;
            this.radioDefault.Text = "Default";
            this.radioDefault.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(659, 192);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(551, 192);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radioSpecial
            // 
            this.radioSpecial.AutoSize = true;
            this.radioSpecial.Location = new System.Drawing.Point(7, 192);
            this.radioSpecial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioSpecial.Name = "radioSpecial";
            this.radioSpecial.Size = new System.Drawing.Size(130, 21);
            this.radioSpecial.TabIndex = 1;
            this.radioSpecial.Text = "Special Settings";
            this.radioSpecial.UseVisualStyleBackColor = true;
            this.radioSpecial.CheckedChanged += new System.EventHandler(this.radioSpecial_CheckedChanged);
            // 
            // mailBindingSource
            // 
            this.mailBindingSource.DataSource = typeof(LoginForm.DataSet.Mail);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // mailAddressDataGridViewTextBoxColumn
            // 
            this.mailAddressDataGridViewTextBoxColumn.DataPropertyName = "MailAddress";
            this.mailAddressDataGridViewTextBoxColumn.HeaderText = "MailAddress";
            this.mailAddressDataGridViewTextBoxColumn.Name = "mailAddressDataGridViewTextBoxColumn";
            // 
            // ccDataGridViewTextBoxColumn
            // 
            this.ccDataGridViewTextBoxColumn.DataPropertyName = "cc";
            this.ccDataGridViewTextBoxColumn.HeaderText = "cc";
            this.ccDataGridViewTextBoxColumn.Name = "ccDataGridViewTextBoxColumn";
            this.ccDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ccDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tooDataGridViewTextBoxColumn
            // 
            this.tooDataGridViewTextBoxColumn.DataPropertyName = "too";
            this.tooDataGridViewTextBoxColumn.HeaderText = "too";
            this.tooDataGridViewTextBoxColumn.Name = "tooDataGridViewTextBoxColumn";
            this.tooDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tooDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 225);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.radioDefault);
            this.Controls.Add(this.radioSpecial);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MailForm";
            this.Load += new System.EventHandler(this.MailForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgMail;
        private System.Windows.Forms.RadioButton radioDefault;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton radioSpecial;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mailAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ccDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tooDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource mailBindingSource;
    }
}