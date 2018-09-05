namespace LoginForm.f_RSInvoice
{
    partial class frm_RsInvoiceDetail
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgRsInvoiceItems = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRsInvoiceItems)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgRsInvoiceItems, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1299, 708);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgRsInvoiceItems
            // 
            this.dgRsInvoiceItems.AllowUserToAddRows = false;
            this.dgRsInvoiceItems.AllowUserToDeleteRows = false;
            this.dgRsInvoiceItems.AllowUserToOrderColumns = true;
            this.dgRsInvoiceItems.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgRsInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRsInvoiceItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRsInvoiceItems.Location = new System.Drawing.Point(8, 208);
            this.dgRsInvoiceItems.Margin = new System.Windows.Forms.Padding(8);
            this.dgRsInvoiceItems.Name = "dgRsInvoiceItems";
            this.dgRsInvoiceItems.ReadOnly = true;
            this.dgRsInvoiceItems.RowTemplate.Height = 24;
            this.dgRsInvoiceItems.Size = new System.Drawing.Size(1283, 292);
            this.dgRsInvoiceItems.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1293, 194);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 511);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1293, 194);
            this.panel2.TabIndex = 2;
            // 
            // frm_RsInvoiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1299, 708);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_RsInvoiceDetail";
            this.Text = "frm_RsInvoiceDetail";
            this.Load += new System.EventHandler(this.frm_RsInvoiceDetail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRsInvoiceItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgRsInvoiceItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}