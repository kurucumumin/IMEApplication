﻿using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class CustomerSubCategory : Form
    {
        IMEEntities IME = new IMEEntities();
        public CustomerSubCategory()
        {
            this.BringToFront();
            this.TopMost = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IME.CustomerSubCategories.Where(title => title.subcategoryname == TitleName.Text).FirstOrDefault() == null)
            {
                DataSet.CustomerSubCategory ct = new DataSet.CustomerSubCategory();
                ct.subcategoryname = TitleName.Text;
                string Department = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                ct.categoryID = (int)comboBox1.SelectedValue;
                IME.CustomerSubCategories.Add(ct);
                IME.SaveChanges();
                MessageBox.Show(this, ct.subcategoryname + " added as a SubCategory");
            }
            else
            {
                MessageBox.Show(this, "There is a Already CustomerSubCategories with the same name in this Category");
            }
        }

        private void TitleAdd_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.TopMost = true;
            //var departmenList = IME.CustomerCategories.Select(a=>a.categoryname).ToList();
            comboBox1.DataSource = IME.CustomerCategories.ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "categoryname";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
