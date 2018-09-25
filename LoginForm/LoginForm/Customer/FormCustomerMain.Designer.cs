namespace LoginForm
{
    partial class FormCustomerMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uPDATEQUOTATIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.qUOTATIONINFOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUOTATIONPRINTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgCustomer = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WebAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.gridRightClick.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uPDATEQUOTATIONToolStripMenuItem
            // 
            this.uPDATEQUOTATIONToolStripMenuItem.Name = "uPDATEQUOTATIONToolStripMenuItem";
            this.uPDATEQUOTATIONToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.uPDATEQUOTATIONToolStripMenuItem.Text = "MODIFY";
            // 
            // gridRightClick
            // 
            this.gridRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qUOTATIONINFOToolStripMenuItem,
            this.qUOTATIONPRINTToolStripMenuItem,
            this.uPDATEQUOTATIONToolStripMenuItem});
            this.gridRightClick.Name = "gridRightClick";
            this.gridRightClick.Size = new System.Drawing.Size(119, 70);
            // 
            // qUOTATIONINFOToolStripMenuItem
            // 
            this.qUOTATIONINFOToolStripMenuItem.Name = "qUOTATIONINFOToolStripMenuItem";
            this.qUOTATIONINFOToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.qUOTATIONINFOToolStripMenuItem.Text = " INFO";
            this.qUOTATIONINFOToolStripMenuItem.Click += new System.EventHandler(this.qUOTATIONINFOToolStripMenuItem_Click);
            // 
            // qUOTATIONPRINTToolStripMenuItem
            // 
            this.qUOTATIONPRINTToolStripMenuItem.Name = "qUOTATIONPRINTToolStripMenuItem";
            this.qUOTATIONPRINTToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.qUOTATIONPRINTToolStripMenuItem.Text = "PRINT";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgCustomer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1378, 699);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgCustomer
            // 
            this.dgCustomer.AllowUserToAddRows = false;
            this.dgCustomer.AllowUserToDeleteRows = false;
            this.dgCustomer.AllowUserToOrderColumns = true;
            this.dgCustomer.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.CustomerNo,
            this.CustomerName,
            this.WebAddress,
            this.Telephone,
            this.Category,
            this.Representative,
            this.Factor,
            this.CreditLimit,
            this.CustomerNote,
            this.IsActive});
            this.dgCustomer.ContextMenuStrip = this.gridRightClick;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCustomer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgCustomer.Location = new System.Drawing.Point(8, 129);
            this.dgCustomer.Margin = new System.Windows.Forms.Padding(8);
            this.dgCustomer.Name = "dgCustomer";
            this.dgCustomer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgCustomer.RowTemplate.Height = 24;
            this.dgCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCustomer.Size = new System.Drawing.Size(1362, 553);
            this.dgCustomer.TabIndex = 0;
            this.dgCustomer.TabStop = false;
            this.dgCustomer.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgCustomer_CellMouseDoubleClick);
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Visible = false;
            // 
            // CustomerNo
            // 
            this.CustomerNo.HeaderText = "CustomerNo";
            this.CustomerNo.Name = "CustomerNo";
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            // 
            // WebAddress
            // 
            this.WebAddress.HeaderText = "Web Address";
            this.WebAddress.Name = "WebAddress";
            // 
            // Telephone
            // 
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.Name = "Telephone";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // Representative
            // 
            this.Representative.HeaderText = "Representative";
            this.Representative.Name = "Representative";
            // 
            // Factor
            // 
            this.Factor.HeaderText = "Factor";
            this.Factor.Name = "Factor";
            // 
            // CreditLimit
            // 
            this.CreditLimit.HeaderText = "Credit Limit";
            this.CreditLimit.Name = "CreditLimit";
            // 
            // CustomerNote
            // 
            this.CustomerNote.HeaderText = "Customer Note";
            this.CustomerNote.Name = "CustomerNote";
            // 
            // IsActive
            // 
            this.IsActive.HeaderText = "Is Active";
            this.IsActive.Name = "IsActive";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 115);
            this.panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.txtSearchText);
            this.groupBox3.Location = new System.Drawing.Point(1141, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 112);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(181, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(173, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnSearch.Size = new System.Drawing.Size(52, 52);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(6, 29);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(148, 20);
            this.txtSearchText.TabIndex = 23;
            this.txtSearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchText_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnRefreshList);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Location = new System.Drawing.Point(5, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 112);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Refresh";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnRefreshList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshList.Image = global::LoginForm.Properties.Resources.icons8_Refresh_32;
            this.btnRefreshList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshList.Location = new System.Drawing.Point(12, 16);
            this.btnRefreshList.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnRefreshList.Size = new System.Drawing.Size(52, 52);
            this.btnRefreshList.TabIndex = 33;
            this.btnRefreshList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefreshList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Modify";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::LoginForm.Properties.Resources.if_Gnome_System_Software_Update_48_55454;
            this.btnUpdate.Location = new System.Drawing.Point(143, 16);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnUpdate.Size = new System.Drawing.Size(52, 52);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Print";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Export Excel";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::LoginForm.Properties.Resources.if_print_173079;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.Location = new System.Drawing.Point(300, 16);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnPrint.Size = new System.Drawing.Size(52, 52);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.Location = new System.Drawing.Point(215, 15);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExcel.TabIndex = 27;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "New ";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::LoginForm.Properties.Resources.icons8_Plus_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.Location = new System.Drawing.Point(75, 16);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnNew.Size = new System.Drawing.Size(52, 52);
            this.btnNew.TabIndex = 1;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // FormCustomerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1378, 699);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCustomerMain";
            this.Text = "FormCustomerMain";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCustomerMain_Load);
            this.gridRightClick.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem uPDATEQUOTATIONToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip gridRightClick;
        private System.Windows.Forms.ToolStripMenuItem qUOTATIONINFOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUOTATIONPRINTToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgCustomer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WebAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representative;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefreshList;
    }
}