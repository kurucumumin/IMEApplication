namespace LoginForm.PurchaseOrder
{
    partial class PurchaseOrderMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioNotSent = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioSent = new System.Windows.Forms.RadioButton();
            this.btnPurchaseOrders = new System.Windows.Forms.Button();
            this.dateEnding = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateStarting = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgPurchase = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnPurchaseOrders);
            this.groupBox1.Controls.Add(this.dateEnding);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateStarting);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1667, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioNotSent);
            this.groupBox2.Controls.Add(this.radioAll);
            this.groupBox2.Controls.Add(this.radioSent);
            this.groupBox2.Location = new System.Drawing.Point(6, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 117);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametrs";
            // 
            // radioNotSent
            // 
            this.radioNotSent.AutoSize = true;
            this.radioNotSent.Location = new System.Drawing.Point(6, 54);
            this.radioNotSent.Name = "radioNotSent";
            this.radioNotSent.Size = new System.Drawing.Size(95, 17);
            this.radioNotSent.TabIndex = 2;
            this.radioNotSent.Text = "Not sent to RS";
            this.radioNotSent.UseVisualStyleBackColor = true;
            this.radioNotSent.CheckedChanged += new System.EventHandler(this.radioNotSent_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Location = new System.Drawing.Point(6, 94);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(36, 17);
            this.radioAll.TabIndex = 1;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // radioSent
            // 
            this.radioSent.AutoSize = true;
            this.radioSent.Location = new System.Drawing.Point(6, 19);
            this.radioSent.Name = "radioSent";
            this.radioSent.Size = new System.Drawing.Size(77, 17);
            this.radioSent.TabIndex = 0;
            this.radioSent.Text = "Sent to RS";
            this.radioSent.UseVisualStyleBackColor = true;
            this.radioSent.CheckedChanged += new System.EventHandler(this.radioSent_CheckedChanged);
            // 
            // btnPurchaseOrders
            // 
            this.btnPurchaseOrders.Location = new System.Drawing.Point(1197, 13);
            this.btnPurchaseOrders.Name = "btnPurchaseOrders";
            this.btnPurchaseOrders.Size = new System.Drawing.Size(163, 91);
            this.btnPurchaseOrders.TabIndex = 14;
            this.btnPurchaseOrders.Text = "Bring The Purchase Orders";
            this.btnPurchaseOrders.UseVisualStyleBackColor = true;
            this.btnPurchaseOrders.Click += new System.EventHandler(this.btnPurchaseOrders_Click);
            // 
            // dateEnding
            // 
            this.dateEnding.Location = new System.Drawing.Point(890, 84);
            this.dateEnding.Name = "dateEnding";
            this.dateEnding.Size = new System.Drawing.Size(200, 20);
            this.dateEnding.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(818, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ending Date";
            // 
            // dateStarting
            // 
            this.dateStarting.Location = new System.Drawing.Point(890, 28);
            this.dateStarting.Name = "dateStarting";
            this.dateStarting.Size = new System.Drawing.Size(200, 20);
            this.dateStarting.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(815, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Starting Date";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(252, 19);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(345, 31);
            this.txtSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(603, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(175, 51);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgPurchase
            // 
            this.dgPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchase.Location = new System.Drawing.Point(12, 154);
            this.dgPurchase.Name = "dgPurchase";
            this.dgPurchase.Size = new System.Drawing.Size(1365, 434);
            this.dgPurchase.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1280, 598);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 42);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(902, 598);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(166, 42);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "Export to Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(1074, 598);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(97, 42);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create Purchase Orders";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1177, 598);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(97, 42);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Send To Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // PurchaseOrderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 652);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgPurchase);
            this.Controls.Add(this.groupBox1);
            this.Name = "PurchaseOrderMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseOrderMain";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PurchaseOrderMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateEnding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateStarting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPurchaseOrders;
        private System.Windows.Forms.DataGridView dgPurchase;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioNotSent;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioSent;
    }
}