namespace LoginForm.QuotationModule
{
    partial class FormQuotationItemSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuotationItemCode = new System.Windows.Forms.TextBox();
            this.dgQuotationItemSearch = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotationItemSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Code";
            // 
            // txtQuotationItemCode
            // 
            this.txtQuotationItemCode.Location = new System.Drawing.Point(70, 16);
            this.txtQuotationItemCode.Name = "txtQuotationItemCode";
            this.txtQuotationItemCode.Size = new System.Drawing.Size(100, 20);
            this.txtQuotationItemCode.TabIndex = 1;
            this.txtQuotationItemCode.TextChanged += new System.EventHandler(this.txtQuotationItemCode_TextChanged);
            // 
            // dgQuotationItemSearch
            // 
            this.dgQuotationItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotationItemSearch.Location = new System.Drawing.Point(12, 57);
            this.dgQuotationItemSearch.Name = "dgQuotationItemSearch";
            this.dgQuotationItemSearch.Size = new System.Drawing.Size(450, 113);
            this.dgQuotationItemSearch.TabIndex = 2;
            this.dgQuotationItemSearch.DoubleClick += new System.EventHandler(this.dgQuotationItemSearch_DoubleClick);
            this.dgQuotationItemSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgQuotationItemSearch_KeyDown);
            // 
            // FormQuotationItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 181);
            this.Controls.Add(this.dgQuotationItemSearch);
            this.Controls.Add(this.txtQuotationItemCode);
            this.Controls.Add(this.label1);
            this.Name = "FormQuotationItemSearch";
            this.Text = "FormQuotationItemSearch";
            this.Load += new System.EventHandler(this.FormQuotationItemSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotationItemSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuotationItemCode;
        private System.Windows.Forms.DataGridView dgQuotationItemSearch;
    }
}