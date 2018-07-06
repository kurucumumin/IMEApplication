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
            this.txtQuotationArticleDesc = new System.Windows.Forms.TextBox();
            this.txtQuotationMPN = new System.Windows.Forms.TextBox();
            this.txtQuotationNote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuotationItemSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Code";
            // 
            // txtQuotationItemCode
            // 
            this.txtQuotationItemCode.Location = new System.Drawing.Point(97, 17);
            this.txtQuotationItemCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuotationItemCode.Name = "txtQuotationItemCode";
            this.txtQuotationItemCode.Size = new System.Drawing.Size(165, 22);
            this.txtQuotationItemCode.TabIndex = 1;
            this.txtQuotationItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationItemCode_KeyDown);
            // 
            // dgQuotationItemSearch
            // 
            this.dgQuotationItemSearch.AllowUserToAddRows = false;
            this.dgQuotationItemSearch.AllowUserToDeleteRows = false;
            this.dgQuotationItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotationItemSearch.Location = new System.Drawing.Point(16, 70);
            this.dgQuotationItemSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgQuotationItemSearch.Name = "dgQuotationItemSearch";
            this.dgQuotationItemSearch.ReadOnly = true;
            this.dgQuotationItemSearch.Size = new System.Drawing.Size(1157, 688);
            this.dgQuotationItemSearch.TabIndex = 2;
            this.dgQuotationItemSearch.DoubleClick += new System.EventHandler(this.dgQuotationItemSearch_DoubleClick);
            this.dgQuotationItemSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgQuotationItemSearch_KeyDown);
            // 
            // txtQuotationArticleDesc
            // 
            this.txtQuotationArticleDesc.Location = new System.Drawing.Point(365, 17);
            this.txtQuotationArticleDesc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuotationArticleDesc.Name = "txtQuotationArticleDesc";
            this.txtQuotationArticleDesc.Size = new System.Drawing.Size(165, 22);
            this.txtQuotationArticleDesc.TabIndex = 3;
            this.txtQuotationArticleDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationItemCode_KeyDown);
            // 
            // txtQuotationMPN
            // 
            this.txtQuotationMPN.Location = new System.Drawing.Point(589, 17);
            this.txtQuotationMPN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuotationMPN.Name = "txtQuotationMPN";
            this.txtQuotationMPN.Size = new System.Drawing.Size(165, 22);
            this.txtQuotationMPN.TabIndex = 4;
            this.txtQuotationMPN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationItemCode_KeyDown);
            // 
            // txtQuotationNote
            // 
            this.txtQuotationNote.Location = new System.Drawing.Point(812, 17);
            this.txtQuotationNote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuotationNote.Name = "txtQuotationNote";
            this.txtQuotationNote.Size = new System.Drawing.Size(165, 22);
            this.txtQuotationNote.TabIndex = 5;
            this.txtQuotationNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationItemCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Article Desc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "MPN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(764, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Note";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(987, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 41);
            this.button1.TabIndex = 9;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormQuotationItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1193, 779);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuotationNote);
            this.Controls.Add(this.txtQuotationMPN);
            this.Controls.Add(this.txtQuotationArticleDesc);
            this.Controls.Add(this.dgQuotationItemSearch);
            this.Controls.Add(this.txtQuotationItemCode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormQuotationItemSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.TextBox txtQuotationArticleDesc;
        private System.Windows.Forms.TextBox txtQuotationMPN;
        private System.Windows.Forms.TextBox txtQuotationNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}