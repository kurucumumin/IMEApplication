namespace LoginForm
{
    partial class frmCostAnalyst
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
            this.dgCost = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.label69 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCost)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCost
            // 
            this.dgCost.AllowUserToAddRows = false;
            this.dgCost.AllowUserToDeleteRows = false;
            this.dgCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCost.Location = new System.Drawing.Point(0, 82);
            this.dgCost.Name = "dgCost";
            this.dgCost.ReadOnly = true;
            this.dgCost.Size = new System.Drawing.Size(1068, 429);
            this.dgCost.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 31;
            this.label7.Text = "Excel";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportToExcel.Location = new System.Drawing.Point(9, 4);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Padding = new System.Windows.Forms.Padding(6, 13, 6, 0);
            this.btnExportToExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExportToExcel.TabIndex = 30;
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(86, 60);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(40, 15);
            this.label69.TabIndex = 61;
            this.label69.Text = "Close";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnClose.Location = new System.Drawing.Point(80, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 52);
            this.btnClose.TabIndex = 60;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCostAnalyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1068, 511);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.dgCost);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1084, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1084, 550);
            this.Name = "frmCostAnalyst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cost Analyst";
            this.Load += new System.EventHandler(this.frmCostAnalyst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button btnClose;
    }
}