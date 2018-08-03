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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
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
            this.txtQuotationItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationItemCode_KeyDown);
            // 
            // dgQuotationItemSearch
            // 
            this.dgQuotationItemSearch.AllowUserToAddRows = false;
            this.dgQuotationItemSearch.AllowUserToDeleteRows = false;
            this.dgQuotationItemSearch.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgQuotationItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuotationItemSearch.Location = new System.Drawing.Point(12, 73);
            this.dgQuotationItemSearch.Name = "dgQuotationItemSearch";
            this.dgQuotationItemSearch.ReadOnly = true;
            this.dgQuotationItemSearch.Size = new System.Drawing.Size(868, 543);
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
            this.txtQuotationArticleDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationItemCode_KeyDown);
            // 
            // txtQuotationMPN
            // 
            this.txtQuotationMPN.Location = new System.Drawing.Point(442, 14);
            this.txtQuotationMPN.Name = "txtQuotationMPN";
            this.txtQuotationMPN.Size = new System.Drawing.Size(125, 20);
            this.txtQuotationMPN.TabIndex = 4;
            this.txtQuotationMPN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationItemCode_KeyDown);
            // 
            // txtQuotationNote
            // 
            this.txtQuotationNote.Location = new System.Drawing.Point(609, 14);
            this.txtQuotationNote.Name = "txtQuotationNote";
            this.txtQuotationNote.Size = new System.Drawing.Size(125, 20);
            this.txtQuotationNote.TabIndex = 5;
            this.txtQuotationNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationItemCode_KeyDown);
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
            // btnSearch
            // 
            this.btnSearch.Image = global::LoginForm.Properties.Resources.if_search_magnifying_glass_find_103857;
            this.btnSearch.Location = new System.Drawing.Point(770, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 52);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(776, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Search";
            // 
            // FormQuotationItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(895, 609);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuotationNote);
            this.Controls.Add(this.txtQuotationMPN);
            this.Controls.Add(this.txtQuotationArticleDesc);
            this.Controls.Add(this.dgQuotationItemSearch);
            this.Controls.Add(this.txtQuotationItemCode);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
    }
}