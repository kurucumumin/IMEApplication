namespace LoginForm.Management
{
    partial class FormCurrencyValue
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
            this.grpCurrency = new System.Windows.Forms.GroupBox();
            this.dgCurrency = new System.Windows.Forms.DataGridView();
            this.grpCurrency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCurrency
            // 
            this.grpCurrency.Controls.Add(this.dgCurrency);
            this.grpCurrency.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCurrency.Location = new System.Drawing.Point(0, 0);
            this.grpCurrency.Name = "grpCurrency";
            this.grpCurrency.Size = new System.Drawing.Size(929, 401);
            this.grpCurrency.TabIndex = 0;
            this.grpCurrency.TabStop = false;
            this.grpCurrency.Text = "Currency";
            // 
            // dgCurrency
            // 
            this.dgCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCurrency.Location = new System.Drawing.Point(3, 16);
            this.dgCurrency.Name = "dgCurrency";
            this.dgCurrency.Size = new System.Drawing.Size(923, 382);
            this.dgCurrency.TabIndex = 0;
            // 
            // FormCurrencyValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 404);
            this.Controls.Add(this.grpCurrency);
            this.MaximumSize = new System.Drawing.Size(945, 443);
            this.MinimumSize = new System.Drawing.Size(945, 443);
            this.Name = "FormCurrencyValue";
            this.Text = "FormCurrencyValue";
            this.Load += new System.EventHandler(this.FormCurrencyValue_Load);
            this.grpCurrency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCurrency;
        private System.Windows.Forms.DataGridView dgCurrency;
    }
}