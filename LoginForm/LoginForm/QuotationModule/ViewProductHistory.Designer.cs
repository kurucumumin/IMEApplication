namespace LoginForm.QuotationModule
{
    partial class ViewProductHistory
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
            this.dgProductHistory = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProductHistory
            // 
            this.dgProductHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductHistory.Location = new System.Drawing.Point(12, 12);
            this.dgProductHistory.Name = "dgProductHistory";
            this.dgProductHistory.Size = new System.Drawing.Size(986, 387);
            this.dgProductHistory.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(908, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewProductHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 459);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgProductHistory);
            this.Name = "ViewProductHistory";
            this.Text = "ViewProductHistory";
            this.Load += new System.EventHandler(this.ViewProductHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProductHistory;
        private System.Windows.Forms.Button btnClose;
    }
}