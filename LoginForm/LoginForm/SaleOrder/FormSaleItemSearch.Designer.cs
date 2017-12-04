﻿namespace LoginForm.nmSaleOrder
{
    partial class FormSaleItemSearch
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtMPN = new System.Windows.Forms.TextBox();
            this.txtArticleDesc = new System.Windows.Forms.TextBox();
            this.dgItemSearch = new System.Windows.Forms.DataGridView();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1076, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Note";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(742, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "MPN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Article Desc";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(1130, 15);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(185, 24);
            this.txtNote.TabIndex = 14;
            // 
            // txtMPN
            // 
            this.txtMPN.Location = new System.Drawing.Point(798, 15);
            this.txtMPN.Margin = new System.Windows.Forms.Padding(4);
            this.txtMPN.Name = "txtMPN";
            this.txtMPN.Size = new System.Drawing.Size(185, 24);
            this.txtMPN.TabIndex = 13;
            // 
            // txtArticleDesc
            // 
            this.txtArticleDesc.Location = new System.Drawing.Point(459, 15);
            this.txtArticleDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtArticleDesc.Name = "txtArticleDesc";
            this.txtArticleDesc.Size = new System.Drawing.Size(185, 24);
            this.txtArticleDesc.TabIndex = 12;
            // 
            // dgItemSearch
            // 
            this.dgItemSearch.AllowUserToAddRows = false;
            this.dgItemSearch.AllowUserToDeleteRows = false;
            this.dgItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemSearch.Location = new System.Drawing.Point(15, 104);
            this.dgItemSearch.Margin = new System.Windows.Forms.Padding(4);
            this.dgItemSearch.Name = "dgItemSearch";
            this.dgItemSearch.ReadOnly = true;
            this.dgItemSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItemSearch.Size = new System.Drawing.Size(1302, 601);
            this.dgItemSearch.TabIndex = 11;
            this.dgItemSearch.DoubleClick += new System.EventHandler(this.dgItemSearch_DoubleClick);
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(106, 15);
            this.txtItemCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(185, 24);
            this.txtItemCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Item Code";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(620, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 26);
            this.button1.TabIndex = 18;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormSaleItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 718);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtMPN);
            this.Controls.Add(this.txtArticleDesc);
            this.Controls.Add(this.dgItemSearch);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormSaleItemSearch";
            this.Text = "Item Search";
            this.Load += new System.EventHandler(this.SaleItemSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItemSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtMPN;
        private System.Windows.Forms.TextBox txtArticleDesc;
        private System.Windows.Forms.DataGridView dgItemSearch;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}