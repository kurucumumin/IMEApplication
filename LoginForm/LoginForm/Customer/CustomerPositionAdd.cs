using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class CustomerPositionAdd : Form
    {
        IMEEntities IME = new IMEEntities();
        public CustomerPositionAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                var dep = IME.CustomerDepartments.Where(a => a.departmentname == comboBox1.Text).FirstOrDefault();
                if (dep != null)
                {
                    var result = IME.CustomerTitles.Where(title => title.titlename == TitleName.Text).FirstOrDefault();

                    if (result == null || (((IME.CustomerTitles.Where(a => a.departmnetID == a.departmnetID)).Count() == 0) && result != null))
                    {
                        CustomerTitle ct = new CustomerTitle();
                        ct.titlename = TitleName.Text;
                        string Department = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                        ct.departmnetID = IME.CustomerDepartments.Where(cd => cd.departmentname == Department).Select(cd => cd.ID).ToList()[0];
                        IME.CustomerTitles.Add(ct);
                        MessageBox.Show(ct.titlename + " added as a Title");
                    }
                    else
                    {
                        MessageBox.Show("There is a Already title with the same name in this department");
                    }
                }
                else
                {
                    MessageBox.Show("Please choose a department name properly");
                }
            
           
        }

        private void TitleAdd_Load(object sender, EventArgs e)
        {
            var departmenList = IME.CustomerDepartments.Select(a=>a.departmentname).ToList();
            comboBox1.DataSource = departmenList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
