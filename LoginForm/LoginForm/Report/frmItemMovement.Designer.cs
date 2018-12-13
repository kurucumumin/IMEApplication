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
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnItemClear = new System.Windows.Forms.Button();
            this.btnItemFind = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.grpMovementList = new System.Windows.Forms.GroupBox();
            this.dgMovement = new System.Windows.Forms.DataGridView();
            this.btnMovementClear = new System.Windows.Forms.Button();
            this.txtMovement = new System.Windows.Forms.TextBox();
            this.btnMovementItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIN = new System.Windows.Forms.TextBox();
            this.txtOUT = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.grpItemList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).BeginInit();
            this.grpMovementList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovement)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 53);
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
            this.btnExcel.Location = new System.Drawing.Point(9, 1);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(8, 16, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExcel.TabIndex = 379;
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // grpItemList
            // 
            this.grpItemList.Controls.Add(this.dgItem);
            this.grpItemList.Controls.Add(this.btnItemClear);
            this.grpItemList.Controls.Add(this.btnItemFind);
            this.grpItemList.Controls.Add(this.txtItem);
            this.grpItemList.Location = new System.Drawing.Point(7, 75);
            this.grpItemList.Name = "grpItemList";
            this.grpItemList.Size = new System.Drawing.Size(336, 644);
            this.grpItemList.TabIndex = 381;
            this.grpItemList.TabStop = false;
            this.grpItemList.Text = "Item List";
            // 
            // dgItem
            // 
            this.dgItem.AllowUserToAddRows = false;
            this.dgItem.AllowUserToDeleteRows = false;
            this.dgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.ArticleName});
            this.dgItem.Location = new System.Drawing.Point(6, 46);
            this.dgItem.Name = "dgItem";
            this.dgItem.ReadOnly = true;
            this.dgItem.Size = new System.Drawing.Size(321, 559);
            this.dgItem.TabIndex = 5;
            this.dgItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItem_CellDoubleClick);
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // ArticleName
            // 
            this.ArticleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ArticleName.HeaderText = "Name";
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.ReadOnly = true;
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
            this.grpMovementList.Location = new System.Drawing.Point(349, 75);
            this.grpMovementList.Name = "grpMovementList";
            this.grpMovementList.Size = new System.Drawing.Size(996, 644);
            this.grpMovementList.TabIndex = 382;
            this.grpMovementList.TabStop = false;
            this.grpMovementList.Text = "Search Name";
            // 
            // dgMovement
            // 
            this.dgMovement.AllowUserToAddRows = false;
            this.dgMovement.AllowUserToDeleteRows = false;
            this.dgMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMovement.Location = new System.Drawing.Point(0, 45);
            this.dgMovement.Name = "dgMovement";
            this.dgMovement.ReadOnly = true;
            this.dgMovement.Size = new System.Drawing.Size(990, 559);
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
            this.txtMovement.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMovement_KeyDown);
            // 
            // btnMovementItem
            // 
            this.btnMovementItem.Location = new System.Drawing.Point(191, 17);
            this.btnMovementItem.Name = "btnMovementItem";
            this.btnMovementItem.Size = new System.Drawing.Size(65, 23);
            this.btnMovementItem.TabIndex = 2;
            this.btnMovementItem.Text = "Find";
            this.btnMovementItem.UseVisualStyleBackColor = true;
            this.btnMovementItem.Click += new System.EventHandler(this.btnMovementItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 383;
            this.label1.Text = "Total IN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 384;
            this.label2.Text = "Total OUT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 385;
            this.label3.Text = "Stock Qty";
            // 
            // txtIN
            // 
            this.txtIN.Location = new System.Drawing.Point(569, 15);
            this.txtIN.Name = "txtIN";
            this.txtIN.Size = new System.Drawing.Size(59, 20);
            this.txtIN.TabIndex = 7;
            // 
            // txtOUT
            // 
            this.txtOUT.Location = new System.Drawing.Point(698, 15);
            this.txtOUT.Name = "txtOUT";
            this.txtOUT.Size = new System.Drawing.Size(59, 20);
            this.txtOUT.TabIndex = 386;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(633, 46);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(59, 20);
            this.txtQty.TabIndex = 387;
            // 
            // frmItemMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 720);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtOUT);
            this.Controls.Add(this.txtIN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIN;
        private System.Windows.Forms.TextBox txtOUT;
        private System.Windows.Forms.TextBox txtQty;
    }
}