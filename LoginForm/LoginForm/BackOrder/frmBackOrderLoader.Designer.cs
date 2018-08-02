namespace LoginForm.BackOrder
{
    partial class frmBackOrderLoader
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
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGridView();
            this.RSUKReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldToNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradingTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Article = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutstandingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstPromisedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LatestPromisedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(12, 12);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(75, 69);
            this.btnChooseFile.TabIndex = 0;
            this.btnChooseFile.Text = "Choose File";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(233, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(192, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Back Order Description";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(233, 16);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(192, 20);
            this.txtDesc.TabIndex = 4;
            // 
            // btnsave
            // 
            this.btnsave.Image = global::LoginForm.Properties.Resources.icons8_Plus_32;
            this.btnsave.Location = new System.Drawing.Point(627, 27);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(43, 39);
            this.btnsave.TabIndex = 0;
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnClose.Location = new System.Drawing.Point(696, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 39);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RSUKReference,
            this.ID,
            this.SoldToNumber,
            this.TradingTitle,
            this.PurchaseOrderNumber,
            this.OrderDate,
            this.Article,
            this.OutstandingQuantity,
            this.LineValue,
            this.FirstPromisedDate,
            this.LatestPromisedDate});
            this.dg.Location = new System.Drawing.Point(12, 87);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(727, 292);
            this.dg.TabIndex = 5;
            // 
            // RSUKReference
            // 
            this.RSUKReference.HeaderText = "RS UK Reference";
            this.RSUKReference.Name = "RSUKReference";
            this.RSUKReference.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(634, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ADD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(702, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "EXIT";
            // 
            // frmBackOrderLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(742, 383);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnChooseFile);
            this.Name = "frmBackOrderLoader";
            this.Text = "frmBackOrderLoader";
            this.Load += new System.EventHandler(this.frmBackOrderLoader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.DataGridViewTextBoxColumn RSUKReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldToNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradingTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Article;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutstandingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstPromisedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LatestPromisedDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}