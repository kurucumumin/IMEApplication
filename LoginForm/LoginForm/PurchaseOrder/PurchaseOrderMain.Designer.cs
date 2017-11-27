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
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPurchaseOrders);
            this.groupBox1.Controls.Add(this.dateEnding);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateStarting);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1667, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchase Orders";
            // 
            // btnPurchaseOrders
            // 
            this.btnPurchaseOrders.Location = new System.Drawing.Point(1197, 13);
            this.btnPurchaseOrders.Name = "btnPurchaseOrders";
            this.btnPurchaseOrders.Size = new System.Drawing.Size(163, 31);
            this.btnPurchaseOrders.TabIndex = 14;
            this.btnPurchaseOrders.Text = "Bring The Purchase Orders";
            this.btnPurchaseOrders.UseVisualStyleBackColor = true;
            this.btnPurchaseOrders.Click += new System.EventHandler(this.btnPurchaseOrders_Click);
            // 
            // dateEnding
            // 
            this.dateEnding.Location = new System.Drawing.Point(897, 22);
            this.dateEnding.Name = "dateEnding";
            this.dateEnding.Size = new System.Drawing.Size(200, 20);
            this.dateEnding.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(825, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ending Date";
            // 
            // dateStarting
            // 
            this.dateStarting.Location = new System.Drawing.Point(615, 22);
            this.dateStarting.Name = "dateStarting";
            this.dateStarting.Size = new System.Drawing.Size(200, 20);
            this.dateStarting.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Starting Date";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 19);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(345, 31);
            this.txtSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(357, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 31);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgPurchase
            // 
            this.dgPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchase.Location = new System.Drawing.Point(12, 83);
            this.dgPurchase.Name = "dgPurchase";
            this.dgPurchase.Size = new System.Drawing.Size(1365, 505);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}