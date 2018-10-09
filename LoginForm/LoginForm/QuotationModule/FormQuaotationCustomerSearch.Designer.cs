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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSearchGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.CustomerCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CustomerCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CustomerCode.Location = new System.Drawing.Point(114, 25);
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Size = new System.Drawing.Size(94, 20);
            this.CustomerCode.TabIndex = 2;
            this.CustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerCode_KeyDown);
            // 
            // CustomerName
            // 
            this.CustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CustomerName.Location = new System.Drawing.Point(114, 56);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(219, 20);
            this.CustomerName.TabIndex = 0;
            this.CustomerName.TextChanged += new System.EventHandler(this.CustomerName_TextChanged);
            this.CustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerName_KeyDown);
            // 
            // CustomerSearchGrid
            // 
            this.CustomerSearchGrid.AllowUserToAddRows = false;
            this.CustomerSearchGrid.AllowUserToDeleteRows = false;
            this.CustomerSearchGrid.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.CustomerSearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerSearchGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerSearchGrid.Location = new System.Drawing.Point(3, 16);
            this.CustomerSearchGrid.MultiSelect = false;
            this.CustomerSearchGrid.Name = "CustomerSearchGrid";
            this.CustomerSearchGrid.ReadOnly = true;
            this.CustomerSearchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerSearchGrid.Size = new System.Drawing.Size(1286, 394);
            this.CustomerSearchGrid.TabIndex = 1;
            this.CustomerSearchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerSearchGrid_CellClick);
            this.CustomerSearchGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerSearchGrid_CellDoubleClick);
            this.CustomerSearchGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerSearchGrid_KeyDown);
            // 
            // button1
            // 
            this.button1.Image = global::LoginForm.Properties.Resources.icons8_Plus_32;
            this.button1.Location = new System.Drawing.Point(1229, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 52);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1205, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Add New Customer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CustomerSearchGrid);
            this.groupBox1.Location = new System.Drawing.Point(15, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1292, 413);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1149, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Skip";
            // 
            // button2
            // 
            this.button2.Image = global::LoginForm.Properties.Resources.icons8_Refresh_32;
            this.button2.Location = new System.Drawing.Point(1140, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 52);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormQuaotationCustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1348, 523);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CustomerName);
            this.Controls.Add(this.CustomerCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1441, 562);
            this.MinimumSize = new System.Drawing.Size(1286, 562);
            this.Name = "FormQuaotationCustomerSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Search";
            this.Load += new System.EventHandler(this.FormQuaotationCustomerSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSearchGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}