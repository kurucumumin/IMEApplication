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
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Code";
            // 
            // txtQuotationItemCode
            // 
            this.txtQuotationItemCode.Location = new System.Drawing.Point(73, 14);
            this.txtQuotationItemCode.Name = "txtQuotationItemCode";
            this.txtQuotationItemCode.Size = new System.Drawing.Size(125, 20);
            this.txtQuotationItemCode.TabIndex = 1;
            // 
            // dgQuotationItemSearch
            // 
            this.dgQuotationItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotationItemSearch.Location = new System.Drawing.Point(12, 57);
            this.dgQuotationItemSearch.Name = "dgQuotationItemSearch";
            this.dgQuotationItemSearch.Size = new System.Drawing.Size(868, 559);
            this.dgQuotationItemSearch.TabIndex = 2;
            this.dgQuotationItemSearch.DoubleClick += new System.EventHandler(this.dgQuotationItemSearch_DoubleClick);
            this.dgQuotationItemSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgQuotationItemSearch_KeyDown);
            // 
            // txtQuotationArticleDesc
            // 
            this.txtQuotationArticleDesc.Location = new System.Drawing.Point(274, 14);
            this.txtQuotationArticleDesc.Name = "txtQuotationArticleDesc";
            this.txtQuotationArticleDesc.Size = new System.Drawing.Size(125, 20);
            this.txtQuotationArticleDesc.TabIndex = 3;
            // 
            // txtQuotationMPN
            // 
            this.txtQuotationMPN.Location = new System.Drawing.Point(442, 14);
            this.txtQuotationMPN.Name = "txtQuotationMPN";
            this.txtQuotationMPN.Size = new System.Drawing.Size(125, 20);
            this.txtQuotationMPN.TabIndex = 4;
            // 
            // txtQuotationNote
            // 
            this.txtQuotationNote.Location = new System.Drawing.Point(609, 14);
            this.txtQuotationNote.Name = "txtQuotationNote";
            this.txtQuotationNote.Size = new System.Drawing.Size(125, 20);
            this.txtQuotationNote.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Article Desc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "MPN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Note";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(740, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormQuotationItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 628);
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
            this.Name = "FormQuotationItemSearch";
            this.Text = "FormQuotationItemSearch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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