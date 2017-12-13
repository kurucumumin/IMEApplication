namespace LoginForm.nsSaleOrder
{
    partial class FormSalesOrderMain
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
            this.btnSearchStockNumber = new System.Windows.Forms.Button();
            this.chcCustStockNumber = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chcAllSales = new System.Windows.Forms.CheckBox();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datetimeEnd = new System.Windows.Forms.DateTimePicker();
            this.datetimeStart = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgSales = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchStockNumber
            // 
            this.btnSearchStockNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnSearchStockNumber.Enabled = false;
            this.btnSearchStockNumber.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnSearchStockNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStockNumber.Location = new System.Drawing.Point(1007, 82);
            this.btnSearchStockNumber.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchStockNumber.Name = "btnSearchStockNumber";
            this.btnSearchStockNumber.Size = new System.Drawing.Size(216, 32);
            this.btnSearchStockNumber.TabIndex = 27;
            this.btnSearchStockNumber.Text = "Search Stock Number";
            this.btnSearchStockNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchStockNumber.UseVisualStyleBackColor = false;
            // 
            // chcCustStockNumber
            // 
            this.chcCustStockNumber.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcCustStockNumber.Enabled = false;
            this.chcCustStockNumber.Location = new System.Drawing.Point(1007, 54);
            this.chcCustStockNumber.Name = "chcCustStockNumber";
            this.chcCustStockNumber.Size = new System.Drawing.Size(216, 24);
            this.chcCustStockNumber.TabIndex = 26;
            this.chcCustStockNumber.Text = "Customer Stock Code";
            this.chcCustStockNumber.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(1007, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(216, 24);
            this.textBox2.TabIndex = 25;
            // 
            // chcAllSales
            // 
            this.chcAllSales.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcAllSales.Enabled = false;
            this.chcAllSales.Location = new System.Drawing.Point(786, 90);
            this.chcAllSales.Name = "chcAllSales";
            this.chcAllSales.Size = new System.Drawing.Size(184, 24);
            this.chcAllSales.TabIndex = 24;
            this.chcAllSales.Text = "All Quotations";
            this.chcAllSales.UseVisualStyleBackColor = true;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Enabled = false;
            this.txtSearchText.Location = new System.Drawing.Point(786, 55);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(184, 24);
            this.txtSearchText.TabIndex = 23;
            // 
            // cbSearch
            // 
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.Enabled = false;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "QUOT NUMBER"});
            this.cbSearch.Location = new System.Drawing.Point(786, 21);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(184, 26);
            this.cbSearch.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Start Date";
            // 
            // datetimeEnd
            // 
            this.datetimeEnd.CustomFormat = "dd-MM-yyyy";
            this.datetimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeEnd.Location = new System.Drawing.Point(100, 87);
            this.datetimeEnd.Name = "datetimeEnd";
            this.datetimeEnd.Size = new System.Drawing.Size(133, 24);
            this.datetimeEnd.TabIndex = 19;
            // 
            // datetimeStart
            // 
            this.datetimeStart.CustomFormat = "dd-MM-yyyy";
            this.datetimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeStart.Location = new System.Drawing.Point(100, 18);
            this.datetimeStart.Name = "datetimeStart";
            this.datetimeStart.Size = new System.Drawing.Size(133, 24);
            this.datetimeStart.TabIndex = 18;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(602, 18);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDelete.Size = new System.Drawing.Size(99, 96);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnModify.Enabled = false;
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Image = global::LoginForm.Properties.Resources.icons8_Edit_Property_32;
            this.btnModify.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModify.Location = new System.Drawing.Point(506, 18);
            this.btnModify.Margin = new System.Windows.Forms.Padding(0);
            this.btnModify.Name = "btnModify";
            this.btnModify.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnModify.Size = new System.Drawing.Size(96, 96);
            this.btnModify.TabIndex = 16;
            this.btnModify.Text = "Modify";
            this.btnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModify.UseVisualStyleBackColor = false;
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnRefreshList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshList.Image = global::LoginForm.Properties.Resources.icons8_Refresh_32;
            this.btnRefreshList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshList.Location = new System.Drawing.Point(237, 18);
            this.btnRefreshList.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnRefreshList.Size = new System.Drawing.Size(87, 96);
            this.btnRefreshList.TabIndex = 14;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefreshList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshList.UseVisualStyleBackColor = false;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(17, 17);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(9, 18, 9, 0);
            this.button4.Size = new System.Drawing.Size(98, 96);
            this.button4.TabIndex = 7;
            this.button4.Text = "Export to Excel";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::LoginForm.Properties.Resources.icons8_Plus_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.Location = new System.Drawing.Point(411, 18);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnNew.Size = new System.Drawing.Size(96, 96);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchStockNumber);
            this.panel1.Controls.Add(this.chcCustStockNumber);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.chcAllSales);
            this.panel1.Controls.Add(this.txtSearchText);
            this.panel1.Controls.Add(this.cbSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.datetimeEnd);
            this.panel1.Controls.Add(this.datetimeStart);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnModify);
            this.panel1.Controls.Add(this.btnRefreshList);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 130);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 578);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1250, 126);
            this.panel2.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(122, 17);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(9, 18, 9, 0);
            this.button5.Size = new System.Drawing.Size(98, 96);
            this.button5.TabIndex = 8;
            this.button5.Text = "Print";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgSales, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1250, 704);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgSales
            // 
            this.dgSales.AllowUserToAddRows = false;
            this.dgSales.AllowUserToDeleteRows = false;
            this.dgSales.AllowUserToOrderColumns = true;
            this.dgSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSales.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgSales.Location = new System.Drawing.Point(8, 144);
            this.dgSales.Margin = new System.Windows.Forms.Padding(8);
            this.dgSales.Name = "dgSales";
            this.dgSales.ReadOnly = true;
            this.dgSales.RowTemplate.Height = 24;
            this.dgSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSales.Size = new System.Drawing.Size(1234, 426);
            this.dgSales.TabIndex = 0;
            this.dgSales.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgSales_MouseClick);
            this.dgSales.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgSales_MouseDoubleClick);
            // 
            // FormSalesOrderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 704);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1266, 726);
            this.Name = "FormSalesOrderMain";
            this.Text = "Sales Order";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSalesOrderMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearchStockNumber;
        private System.Windows.Forms.CheckBox chcCustStockNumber;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox chcAllSales;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datetimeEnd;
        private System.Windows.Forms.DateTimePicker datetimeStart;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgSales;
    }
}