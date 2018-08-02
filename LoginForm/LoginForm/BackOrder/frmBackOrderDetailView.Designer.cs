namespace LoginForm.BackOrder
{
    partial class frmBackOrderDetailView
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
            this.dg = new System.Windows.Forms.DataGridView();
            this.RSUKReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldToNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradingTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Article = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutstandingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstPromisedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LatestPromisedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RSUKReference,
            this.SoldToNumber,
            this.TradingTitle,
            this.PurchaseOrderNumber,
            this.OrderDate,
            this.Article,
            this.OutstandingQuantity,
            this.LineValue,
            this.FirstPromisedDate,
            this.LatestPromisedDate,
            this.ID});
            this.dg.Location = new System.Drawing.Point(3, 71);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(1008, 458);
            this.dg.TabIndex = 4;
            // 
            // RSUKReference
            // 
            this.RSUKReference.HeaderText = "RS UK Reference";
            this.RSUKReference.Name = "RSUKReference";
            this.RSUKReference.ReadOnly = true;
            // 
            // SoldToNumber
            // 
            this.SoldToNumber.HeaderText = "Sold To Number";
            this.SoldToNumber.Name = "SoldToNumber";
            this.SoldToNumber.ReadOnly = true;
            // 
            // TradingTitle
            // 
            this.TradingTitle.HeaderText = "Trading Title";
            this.TradingTitle.Name = "TradingTitle";
            this.TradingTitle.ReadOnly = true;
            // 
            // PurchaseOrderNumber
            // 
            this.PurchaseOrderNumber.HeaderText = "Purchase Order Number";
            this.PurchaseOrderNumber.Name = "PurchaseOrderNumber";
            this.PurchaseOrderNumber.ReadOnly = true;
            // 
            // OrderDate
            // 
            this.OrderDate.HeaderText = "Order Date";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // Article
            // 
            this.Article.HeaderText = "Article";
            this.Article.Name = "Article";
            this.Article.ReadOnly = true;
            // 
            // OutstandingQuantity
            // 
            this.OutstandingQuantity.HeaderText = "Outstanding Quantity";
            this.OutstandingQuantity.Name = "OutstandingQuantity";
            this.OutstandingQuantity.ReadOnly = true;
            // 
            // LineValue
            // 
            this.LineValue.HeaderText = "Line Value";
            this.LineValue.Name = "LineValue";
            this.LineValue.ReadOnly = true;
            // 
            // FirstPromisedDate
            // 
            this.FirstPromisedDate.HeaderText = "First Promised Date";
            this.FirstPromisedDate.Name = "FirstPromisedDate";
            this.FirstPromisedDate.ReadOnly = true;
            // 
            // LatestPromisedDate
            // 
            this.LatestPromisedDate.HeaderText = "Latest Promised Date";
            this.LatestPromisedDate.Name = "LatestPromisedDate";
            this.LatestPromisedDate.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnClose.Location = new System.Drawing.Point(15, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 41);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Close";
            // 
            // frmBackOrderDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1014, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dg);
            this.Name = "frmBackOrderDetailView";
            this.Text = "frmBackOrderDetailView";
            this.Load += new System.EventHandler(this.frmBackOrderDetailView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.DataGridViewTextBoxColumn RSUKReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldToNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradingTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Article;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutstandingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstPromisedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LatestPromisedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}