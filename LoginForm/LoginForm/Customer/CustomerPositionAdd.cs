﻿using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class CustomerPositionAdd : Form
    {
        
        IMEEntities IME = new IMEEntities();
        int departmanID;

        public CustomerPositionAdd(int departmentName)
        {
            InitializeComponent();
            this.TopMost = true;
            departmanID = departmentName;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var dep = IME.CustomerDepartments.Where(a => a.departmentname == comboBox1.Text).FirstOrDefault();
            if (dep != null)
            {
                var result = IME.CustomerTitles.Where(title => title.titlename == TitleName.Text).FirstOrDefault();

                if (result == null || (result != null))
                {
                    CustomerTitle ct = new CustomerTitle();
                    ct.titlename = TitleName.Text;
                    string Department = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    IME.CustomerTitles.Add(ct);
                    MessageBox.Show(this, ct.titlename + " added as a Title");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "There is a Already title with the same name in this department");
                }
            }
            else
            {
                MessageBox.Show(this, "Please choose a department name properly");
            }


        }

        private void TitleAdd_Load(object sender, EventArgs e)
        {
            //var departmenList = IME.CustomerDepartments.Select(a=>a.departmentname).ToList();
            //comboBox1.DataSource = departmenList;
            comboBox1.DataSource = IME.CustomerDepartments.ToList();
            comboBox1.DisplayMember = "departmentname";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedValue = departmanID; ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
