namespace LoginForm.QuotationModule
{
    partial class FormQuaotationCustomerSearch
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
            this.label2 = new System.Windows.Forms.Label();
            this.CustomerCode = new System.Windows.Forms.TextBox();
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.CustomerSearchGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSearchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer Name";
            // 
            // CustomerCode
            // 
            this.CustomerCode.Location = new System.Drawing.Point(114, 25);
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Size = new System.Drawing.Size(94, 20);
            this.CustomerCode.TabIndex = 1;
            this.CustomerCode.TextChanged += new System.EventHandler(this.CustomerCode_TextChanged);
            this.CustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerCode_KeyDown);
            // 
            // CustomerName
            // 
            this.CustomerName.Location = new System.Drawing.Point(114, 56);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(219, 20);
            this.CustomerName.TabIndex = 1;
            this.CustomerName.TextChanged += new System.EventHandler(this.CustomerName_TextChanged);
            this.CustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerName_KeyDown);
            // 
            // CustomerSearchGrid
            // 
            this.CustomerSearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerSearchGrid.Location = new System.Drawing.Point(15, 97);
            this.CustomerSearchGrid.Name = "CustomerSearchGrid";
            this.CustomerSearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerSearchGrid.Size = new System.Drawing.Size(526, 103);
            this.CustomerSearchGrid.TabIndex = 2;
            this.CustomerSearchGrid.Click += new System.EventHandler(this.CustomerSearchGrid_Click);
            this.CustomerSearchGrid.DoubleClick += new System.EventHandler(this.CustomerSearchGrid_DoubleClick);
            this.CustomerSearchGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerSearchGrid_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(446, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add New Customer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormQuaotationCustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 212);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CustomerSearchGrid);
            this.Controls.Add(this.CustomerName);
            this.Controls.Add(this.CustomerCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormQuaotationCustomerSearch";
            this.Text = "Customer Search";
            this.Load += new System.EventHandler(this.FormQuaotationCustomerSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSearchGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CustomerCode;
        private System.Windows.Forms.TextBox CustomerName;
        private System.Windows.Forms.DataGridView CustomerSearchGrid;
        private System.Windows.Forms.Button button1;
    }
}