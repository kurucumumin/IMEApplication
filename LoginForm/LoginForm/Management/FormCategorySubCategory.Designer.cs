﻿namespace LoginForm.ManagementModule
{
    partial class FormCategorySubCategory
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMainCategoryAdd = new System.Windows.Forms.Button();
            this.btnSubCategoryAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.customerCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerSubCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtMainCategory = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbCategory = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbSubCategory = new System.Windows.Forms.ListBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnEditSubcategory = new System.Windows.Forms.Button();
            this.btnDeleteSubcategory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerSubCategoryBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Main Category Name";
            // 
            // btnMainCategoryAdd
            // 
            this.btnMainCategoryAdd.Location = new System.Drawing.Point(319, 51);
            this.btnMainCategoryAdd.Name = "btnMainCategoryAdd";
            this.btnMainCategoryAdd.Size = new System.Drawing.Size(99, 50);
            this.btnMainCategoryAdd.TabIndex = 3;
            this.btnMainCategoryAdd.Text = "Add Category";
            this.btnMainCategoryAdd.UseVisualStyleBackColor = true;
            this.btnMainCategoryAdd.Click += new System.EventHandler(this.btnMainCategoryAdd_Click);
            // 
            // btnSubCategoryAdd
            // 
            this.btnSubCategoryAdd.Location = new System.Drawing.Point(317, 51);
            this.btnSubCategoryAdd.Name = "btnSubCategoryAdd";
            this.btnSubCategoryAdd.Size = new System.Drawing.Size(99, 50);
            this.btnSubCategoryAdd.TabIndex = 4;
            this.btnSubCategoryAdd.Text = "Add Subcategory";
            this.btnSubCategoryAdd.UseVisualStyleBackColor = true;
            this.btnSubCategoryAdd.Click += new System.EventHandler(this.btnSubCategoryAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sub Category Name";
            // 
            // customerCategoryBindingSource
            // 
            this.customerCategoryBindingSource.DataSource = typeof(LoginForm.DataSet.CustomerCategory);
            // 
            // customerSubCategoryBindingSource
            // 
            this.customerSubCategoryBindingSource.DataSource = typeof(LoginForm.DataSet.CustomerSubCategory);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(913, 674);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel14);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.txtMainCategory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMainCategoryAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 119);
            this.panel1.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(10, 119);
            this.panel14.TabIndex = 12;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(440, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(10, 119);
            this.panel9.TabIndex = 9;
            // 
            // txtMainCategory
            // 
            this.txtMainCategory.Location = new System.Drawing.Point(32, 64);
            this.txtMainCategory.Name = "txtMainCategory";
            this.txtMainCategory.Size = new System.Drawing.Size(281, 21);
            this.txtMainCategory.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel15);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.txtSubCategory);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSubCategoryAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(459, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 119);
            this.panel2.TabIndex = 1;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(10, 119);
            this.panel15.TabIndex = 12;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(441, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(10, 119);
            this.panel10.TabIndex = 10;
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(35, 64);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Size = new System.Drawing.Size(276, 21);
            this.txtSubCategory.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 128);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 543);
            this.panel3.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(450, 543);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbCategory);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(32, 16);
            this.panel6.Margin = new System.Windows.Forms.Padding(32, 16, 32, 16);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(386, 436);
            this.panel6.TabIndex = 0;
            // 
            // lbCategory
            // 
            this.lbCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.customerCategoryBindingSource, "ID", true));
            this.lbCategory.DataSource = this.customerCategoryBindingSource;
            this.lbCategory.DisplayMember = "categoryname";
            this.lbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCategory.FormattingEnabled = true;
            this.lbCategory.ItemHeight = 15;
            this.lbCategory.Location = new System.Drawing.Point(0, 0);
            this.lbCategory.Margin = new System.Windows.Forms.Padding(0);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(386, 436);
            this.lbCategory.TabIndex = 0;
            this.lbCategory.ValueMember = "ID";
            this.lbCategory.SelectedValueChanged += new System.EventHandler(this.lbCategory_SelectedValueChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel13);
            this.panel5.Controls.Add(this.panel11);
            this.panel5.Controls.Add(this.btnEditCategory);
            this.panel5.Controls.Add(this.btnDeleteCategory);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 471);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(444, 69);
            this.panel5.TabIndex = 1;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(10, 69);
            this.panel13.TabIndex = 11;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(434, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(10, 69);
            this.panel11.TabIndex = 10;
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Enabled = false;
            this.btnEditCategory.Location = new System.Drawing.Point(29, 3);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(99, 50);
            this.btnEditCategory.TabIndex = 1;
            this.btnEditCategory.Text = "Edit Category";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(316, 3);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(99, 50);
            this.btnDeleteCategory.TabIndex = 0;
            this.btnDeleteCategory.Text = "Delete Category";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(459, 128);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(451, 543);
            this.panel4.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel8, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(451, 543);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lbSubCategory);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(32, 16, 32, 16);
            this.panel7.Size = new System.Drawing.Size(451, 468);
            this.panel7.TabIndex = 0;
            // 
            // lbSubCategory
            // 
            this.lbSubCategory.DataSource = this.customerSubCategoryBindingSource;
            this.lbSubCategory.DisplayMember = "subcategoryname";
            this.lbSubCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSubCategory.FormattingEnabled = true;
            this.lbSubCategory.ItemHeight = 15;
            this.lbSubCategory.Location = new System.Drawing.Point(32, 16);
            this.lbSubCategory.Margin = new System.Windows.Forms.Padding(0);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(387, 436);
            this.lbSubCategory.TabIndex = 1;
            this.lbSubCategory.ValueMember = "subcategoryname";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel16);
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Controls.Add(this.btnEditSubcategory);
            this.panel8.Controls.Add(this.btnDeleteSubcategory);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 471);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(445, 69);
            this.panel8.TabIndex = 1;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(10, 69);
            this.panel16.TabIndex = 12;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(435, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(10, 69);
            this.panel12.TabIndex = 10;
            // 
            // btnEditSubcategory
            // 
            this.btnEditSubcategory.Enabled = false;
            this.btnEditSubcategory.Location = new System.Drawing.Point(32, 3);
            this.btnEditSubcategory.Name = "btnEditSubcategory";
            this.btnEditSubcategory.Size = new System.Drawing.Size(99, 50);
            this.btnEditSubcategory.TabIndex = 3;
            this.btnEditSubcategory.Text = "Edit Subcategory";
            this.btnEditSubcategory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSubcategory
            // 
            this.btnDeleteSubcategory.Location = new System.Drawing.Point(314, 3);
            this.btnDeleteSubcategory.Name = "btnDeleteSubcategory";
            this.btnDeleteSubcategory.Size = new System.Drawing.Size(99, 50);
            this.btnDeleteSubcategory.TabIndex = 2;
            this.btnDeleteSubcategory.Text = "Delete Subcategory";
            this.btnDeleteSubcategory.UseVisualStyleBackColor = true;
            this.btnDeleteSubcategory.Click += new System.EventHandler(this.btnDeleteSubcategory_Click);
            // 
            // FormCategorySubCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(913, 674);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(502, 353);
            this.Name = "FormCategorySubCategory";
            this.Text = "Category & Sub Category";
            this.Load += new System.EventHandler(this.FormCategorySubCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerSubCategoryBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMainCategoryAdd;
        private System.Windows.Forms.Button btnSubCategoryAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lbCategory;
        private System.Windows.Forms.ListBox lbSubCategory;
        private System.Windows.Forms.BindingSource customerCategoryBindingSource;
        private System.Windows.Forms.BindingSource customerSubCategoryBindingSource;
        private System.Windows.Forms.TextBox txtMainCategory;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnEditSubcategory;
        private System.Windows.Forms.Button btnDeleteSubcategory;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel16;
    }
}