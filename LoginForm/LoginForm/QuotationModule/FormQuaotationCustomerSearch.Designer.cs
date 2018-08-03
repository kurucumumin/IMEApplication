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
            this.label3 = new System.Windows.Forms.Label();
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
            this.CustomerCode.TabIndex = 2;
            this.CustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerCode_KeyDown);
            // 
            // CustomerName
            // 
            this.CustomerName.Location = new System.Drawing.Point(114, 56);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(219, 20);
            this.CustomerName.TabIndex = 3;
            this.CustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerName_KeyDown);
            // 
            // CustomerSearchGrid
            // 
            this.CustomerSearchGrid.AllowUserToAddRows = false;
            this.CustomerSearchGrid.AllowUserToDeleteRows = false;
            this.CustomerSearchGrid.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.CustomerSearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerSearchGrid.Location = new System.Drawing.Point(15, 107);
            this.CustomerSearchGrid.MultiSelect = false;
            this.CustomerSearchGrid.Name = "CustomerSearchGrid";
            this.CustomerSearchGrid.ReadOnly = true;
            this.CustomerSearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerSearchGrid.Size = new System.Drawing.Size(526, 206);
            this.CustomerSearchGrid.TabIndex = 1;
            this.CustomerSearchGrid.DoubleClick += new System.EventHandler(this.CustomerSearchGrid_DoubleClick);
            this.CustomerSearchGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerSearchGrid_KeyDown);
            // 
            // button1
            // 
            this.button1.Image = global::LoginForm.Properties.Resources.icons8_Plus_32;
            this.button1.Location = new System.Drawing.Point(467, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 52);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Add New Customer";
            // 
            // FormQuaotationCustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(553, 325);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CustomerSearchGrid);
            this.Controls.Add(this.CustomerName);
            this.Controls.Add(this.CustomerCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormQuaotationCustomerSearch";
            this.Text = "Customer Search";
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
        private System.Windows.Forms.Label label3;
    }
}