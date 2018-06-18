namespace LoginForm.QuotationModule
{
    partial class FormQuotationMain
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgQuotation = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchStockNumber = new System.Windows.Forms.Button();
            this.chcCustStockNumber = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chcAllQuots = new System.Windows.Forms.CheckBox();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteQuotation = new System.Windows.Forms.Button();
            this.btnModifyQuotation = new System.Windows.Forms.Button();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnNewQuotation = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotation)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgQuotation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1236, 696);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgQuotation
            // 
            this.dgQuotation.AllowUserToAddRows = false;
            this.dgQuotation.AllowUserToDeleteRows = false;
            this.dgQuotation.AllowUserToOrderColumns = true;
            this.dgQuotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgQuotation.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgQuotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgQuotation.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgQuotation.Location = new System.Drawing.Point(8, 129);
            this.dgQuotation.Margin = new System.Windows.Forms.Padding(8);
            this.dgQuotation.Name = "dgQuotation";
            this.dgQuotation.ReadOnly = true;
            this.dgQuotation.RowTemplate.Height = 24;
            this.dgQuotation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgQuotation.Size = new System.Drawing.Size(1220, 447);
            this.dgQuotation.TabIndex = 0;
            this.dgQuotation.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgQuotation_CellMouseDoubleClick);
            this.dgQuotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgQuotation_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchStockNumber);
            this.panel1.Controls.Add(this.chcCustStockNumber);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.chcAllQuots);
            this.panel1.Controls.Add(this.txtSearchText);
            this.panel1.Controls.Add(this.cbSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.btnDeleteQuotation);
            this.panel1.Controls.Add(this.btnModifyQuotation);
            this.panel1.Controls.Add(this.btnRefreshList);
            this.panel1.Controls.Add(this.btnNewQuotation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1230, 115);
            this.panel1.TabIndex = 1;
            // 
            // btnSearchStockNumber
            // 
            this.btnSearchStockNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnSearchStockNumber.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnSearchStockNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStockNumber.Location = new System.Drawing.Point(895, 73);
            this.btnSearchStockNumber.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchStockNumber.Name = "btnSearchStockNumber";
            this.btnSearchStockNumber.Size = new System.Drawing.Size(192, 28);
            this.btnSearchStockNumber.TabIndex = 27;
            this.btnSearchStockNumber.Text = "Search Stock Number";
            this.btnSearchStockNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchStockNumber.UseVisualStyleBackColor = false;
            this.btnSearchStockNumber.Click += new System.EventHandler(this.btnSearchStockNumber_Click);
            // 
            // chcCustStockNumber
            // 
            this.chcCustStockNumber.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcCustStockNumber.Location = new System.Drawing.Point(895, 48);
            this.chcCustStockNumber.Name = "chcCustStockNumber";
            this.chcCustStockNumber.Size = new System.Drawing.Size(192, 21);
            this.chcCustStockNumber.TabIndex = 26;
            this.chcCustStockNumber.Text = "Customer Stock Code";
            this.chcCustStockNumber.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(895, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(192, 24);
            this.textBox2.TabIndex = 25;
            // 
            // chcAllQuots
            // 
            this.chcAllQuots.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcAllQuots.Location = new System.Drawing.Point(699, 80);
            this.chcAllQuots.Name = "chcAllQuots";
            this.chcAllQuots.Size = new System.Drawing.Size(164, 21);
            this.chcAllQuots.TabIndex = 24;
            this.chcAllQuots.Text = "All Quotations";
            this.chcAllQuots.UseVisualStyleBackColor = true;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(699, 49);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(164, 24);
            this.txtSearchText.TabIndex = 23;
            this.txtSearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchText_KeyPress);
            // 
            // cbSearch
            // 
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "QUOT NUMBER"});
            this.cbSearch.Location = new System.Drawing.Point(699, 19);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(164, 26);
            this.cbSearch.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "From";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(73, 14);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(119, 24);
            this.dtpFromDate.TabIndex = 19;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(73, 80);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(119, 24);
            this.dtpToDate.TabIndex = 18;
            // 
            // btnDeleteQuotation
            // 
            this.btnDeleteQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnDeleteQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnDeleteQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteQuotation.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnDeleteQuotation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteQuotation.Location = new System.Drawing.Point(535, 16);
            this.btnDeleteQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteQuotation.Name = "btnDeleteQuotation";
            this.btnDeleteQuotation.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDeleteQuotation.Size = new System.Drawing.Size(88, 85);
            this.btnDeleteQuotation.TabIndex = 17;
            this.btnDeleteQuotation.Text = "Delete";
            this.btnDeleteQuotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteQuotation.UseVisualStyleBackColor = false;
            this.btnDeleteQuotation.Click += new System.EventHandler(this.btnDeleteQuotation_Click);
            // 
            // btnModifyQuotation
            // 
            this.btnModifyQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnModifyQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnModifyQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyQuotation.Image = global::LoginForm.Properties.Resources.icons8_Edit_Property_32;
            this.btnModifyQuotation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModifyQuotation.Location = new System.Drawing.Point(450, 16);
            this.btnModifyQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnModifyQuotation.Name = "btnModifyQuotation";
            this.btnModifyQuotation.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnModifyQuotation.Size = new System.Drawing.Size(85, 85);
            this.btnModifyQuotation.TabIndex = 16;
            this.btnModifyQuotation.Text = "Modify";
            this.btnModifyQuotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModifyQuotation.UseVisualStyleBackColor = false;
            this.btnModifyQuotation.Click += new System.EventHandler(this.btnModifyQuotation_Click);
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnRefreshList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshList.Image = global::LoginForm.Properties.Resources.icons8_Refresh_32;
            this.btnRefreshList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshList.Location = new System.Drawing.Point(211, 16);
            this.btnRefreshList.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnRefreshList.Size = new System.Drawing.Size(77, 85);
            this.btnRefreshList.TabIndex = 14;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefreshList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshList.UseVisualStyleBackColor = false;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // btnNewQuotation
            // 
            this.btnNewQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnNewQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnNewQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewQuotation.Image = global::LoginForm.Properties.Resources.icons8_Plus_32;
            this.btnNewQuotation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewQuotation.Location = new System.Drawing.Point(365, 16);
            this.btnNewQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewQuotation.Name = "btnNewQuotation";
            this.btnNewQuotation.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnNewQuotation.Size = new System.Drawing.Size(85, 85);
            this.btnNewQuotation.TabIndex = 1;
            this.btnNewQuotation.Text = "New";
            this.btnNewQuotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewQuotation.UseVisualStyleBackColor = false;
            this.btnNewQuotation.Click += new System.EventHandler(this.btnNewQuotation_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 584);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1236, 112);
            this.panel2.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(108, 15);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.button5.Size = new System.Drawing.Size(87, 85);
            this.button5.TabIndex = 8;
            this.button5.Text = "Print";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(15, 15);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.button4.Size = new System.Drawing.Size(87, 85);
            this.button4.TabIndex = 7;
            this.button4.Text = "Export to Excel";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormQuotationMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 696);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "FormQuotationMain";
            this.Text = "Quotation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormQuotationMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgQuotation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteQuotation;
        private System.Windows.Forms.Button btnModifyQuotation;
        private System.Windows.Forms.Button btnNewQuotation;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.CheckBox chcAllQuots;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSearchStockNumber;
        private System.Windows.Forms.CheckBox chcCustStockNumber;
        private System.Windows.Forms.TextBox textBox2;
    }
}