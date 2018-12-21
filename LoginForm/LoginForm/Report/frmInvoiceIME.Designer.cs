namespace LoginForm
{
    partial class frmInvoiceIME
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
            this.dgInvoice = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgInvoice
            // 
            this.dgInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInvoice.Location = new System.Drawing.Point(0, 0);
            this.dgInvoice.Name = "dgInvoice";
            this.dgInvoice.Size = new System.Drawing.Size(1348, 486);
            this.dgInvoice.TabIndex = 0;
            // 
            // frmInvoiceIME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1348, 486);
            this.Controls.Add(this.dgInvoice);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1364, 525);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1364, 525);
            this.Name = "frmInvoiceIME";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IME Invoice";
            this.Load += new System.EventHandler(this.frmInvoiceIME_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgInvoice;
    }
}