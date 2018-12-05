namespace LoginForm
{
    partial class frmItemMovement
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
            this.label13 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.grpItemList = new System.Windows.Forms.GroupBox();
            this.dgItem = new System.Windows.Forms.DataGridView();
            this.btnItemClear = new System.Windows.Forms.Button();
            this.btnItemFind = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.grpMovementList = new System.Windows.Forms.GroupBox();
            this.dgMovement = new System.Windows.Forms.DataGridView();
            this.btnMovementClear = new System.Windows.Forms.Button();
            this.txtMovement = new System.Windows.Forms.TextBox();
            this.btnMovementItem = new System.Windows.Forms.Button();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FicheNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FicheDocNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UKPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpItemList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).BeginInit();
            this.grpMovementList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovement)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 380;
            this.label13.Text = "Export Excel";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.Location = new System.Drawing.Point(9, 9);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExcel.TabIndex = 379;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // grpItemList
            // 
            this.grpItemList.Controls.Add(this.dgItem);
            this.grpItemList.Controls.Add(this.btnItemClear);
            this.grpItemList.Controls.Add(this.btnItemFind);
            this.grpItemList.Controls.Add(this.txtItem);
            this.grpItemList.Location = new System.Drawing.Point(7, 97);
            this.grpItemList.Name = "grpItemList";
            this.grpItemList.Size = new System.Drawing.Size(336, 611);
            this.grpItemList.TabIndex = 381;
            this.grpItemList.TabStop = false;
            this.grpItemList.Text = "Item List";
            // 
            // dgItem
            // 
            this.dgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.ArticleName});
            this.dgItem.Location = new System.Drawing.Point(6, 46);
            this.dgItem.Name = "dgItem";
            this.dgItem.Size = new System.Drawing.Size(321, 559);
            this.dgItem.TabIndex = 5;
            this.dgItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItem_CellDoubleClick);
            // 
            // btnItemClear
            // 
            this.btnItemClear.Location = new System.Drawing.Point(262, 17);
            this.btnItemClear.Name = "btnItemClear";
            this.btnItemClear.Size = new System.Drawing.Size(65, 23);
            this.btnItemClear.TabIndex = 1;
            this.btnItemClear.Text = "Clear";
            this.btnItemClear.UseVisualStyleBackColor = true;
            this.btnItemClear.Click += new System.EventHandler(this.btnItemClear_Click);
            // 
            // btnItemFind
            // 
            this.btnItemFind.Location = new System.Drawing.Point(191, 17);
            this.btnItemFind.Name = "btnItemFind";
            this.btnItemFind.Size = new System.Drawing.Size(65, 23);
            this.btnItemFind.TabIndex = 0;
            this.btnItemFind.Text = "Find";
            this.btnItemFind.UseVisualStyleBackColor = true;
            this.btnItemFind.Click += new System.EventHandler(this.btnItemFind_Click);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(6, 19);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(179, 20);
            this.txtItem.TabIndex = 0;
            this.txtItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
            // 
            // grpMovementList
            // 
            this.grpMovementList.Controls.Add(this.dgMovement);
            this.grpMovementList.Controls.Add(this.btnMovementClear);
            this.grpMovementList.Controls.Add(this.txtMovement);
            this.grpMovementList.Controls.Add(this.btnMovementItem);
            this.grpMovementList.Location = new System.Drawing.Point(349, 97);
            this.grpMovementList.Name = "grpMovementList";
            this.grpMovementList.Size = new System.Drawing.Size(987, 611);
            this.grpMovementList.TabIndex = 382;
            this.grpMovementList.TabStop = false;
            this.grpMovementList.Text = "Movement List";
            // 
            // dgMovement
            // 
            this.dgMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMovement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.FicheNo,
            this.CustomerName,
            this.FicheDocNo,
            this.Qty,
            this.InOut,
            this.Type,
            this.UnitOfMeasure,
            this.UKPrice,
            this.Total,
            this.Currency});
            this.dgMovement.Location = new System.Drawing.Point(0, 45);
            this.dgMovement.Name = "dgMovement";
            this.dgMovement.Size = new System.Drawing.Size(975, 559);
            this.dgMovement.TabIndex = 6;
            // 
            // btnMovementClear
            // 
            this.btnMovementClear.Location = new System.Drawing.Point(262, 17);
            this.btnMovementClear.Name = "btnMovementClear";
            this.btnMovementClear.Size = new System.Drawing.Size(65, 23);
            this.btnMovementClear.TabIndex = 4;
            this.btnMovementClear.Text = "Clear";
            this.btnMovementClear.UseVisualStyleBackColor = true;
            this.btnMovementClear.Click += new System.EventHandler(this.btnMovementClear_Click);
            // 
            // txtMovement
            // 
            this.txtMovement.Location = new System.Drawing.Point(6, 19);
            this.txtMovement.Name = "txtMovement";
            this.txtMovement.Size = new System.Drawing.Size(179, 20);
            this.txtMovement.TabIndex = 3;
            // 
            // btnMovementItem
            // 
            this.btnMovementItem.Location = new System.Drawing.Point(191, 17);
            this.btnMovementItem.Name = "btnMovementItem";
            this.btnMovementItem.Size = new System.Drawing.Size(65, 23);
            this.btnMovementItem.TabIndex = 2;
            this.btnMovementItem.Text = "Find";
            this.btnMovementItem.UseVisualStyleBackColor = true;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            // 
            // ArticleName
            // 
            this.ArticleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ArticleName.HeaderText = "Name";
            this.ArticleName.Name = "ArticleName";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // FicheNo
            // 
            this.FicheNo.HeaderText = "Fiche No";
            this.FicheNo.Name = "FicheNo";
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            // 
            // FicheDocNo
            // 
            this.FicheDocNo.HeaderText = "Fiche Doc No";
            this.FicheDocNo.Name = "FicheDocNo";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // InOut
            // 
            this.InOut.HeaderText = "I/O";
            this.InOut.Name = "InOut";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // UnitOfMeasure
            // 
            this.UnitOfMeasure.HeaderText = "UOM";
            this.UnitOfMeasure.Name = "UnitOfMeasure";
            // 
            // UKPrice
            // 
            this.UKPrice.HeaderText = "UKPrice";
            this.UKPrice.Name = "UKPrice";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            // 
            // frmItemMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 720);
            this.Controls.Add(this.grpMovementList);
            this.Controls.Add(this.grpItemList);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnExcel);
            this.MinimizeBox = false;
            this.Name = "frmItemMovement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Movement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grpItemList.ResumeLayout(false);
            this.grpItemList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).EndInit();
            this.grpMovementList.ResumeLayout(false);
            this.grpMovementList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.GroupBox grpItemList;
        private System.Windows.Forms.GroupBox grpMovementList;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Button btnItemClear;
        private System.Windows.Forms.Button btnItemFind;
        private System.Windows.Forms.Button btnMovementClear;
        private System.Windows.Forms.TextBox txtMovement;
        private System.Windows.Forms.Button btnMovementItem;
        private System.Windows.Forms.DataGridView dgItem;
        private System.Windows.Forms.DataGridView dgMovement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn FicheNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FicheDocNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn InOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn UKPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
    }
}