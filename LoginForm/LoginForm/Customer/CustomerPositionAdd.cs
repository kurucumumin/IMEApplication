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
            var result = IME.CustomerTitles.Where(title => title.titlename == TitleName.Text).ToList();
            if (result.Count == 0)
            {
                
                CustomerTitle ct = new CustomerTitle();
                ct.titlename = TitleName.Text;
                string Department = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                ct.departmnetID = IME.CustomerDepartments.Where(cd => cd.departmentname == Department).Select(cd => cd.ID).ToList()[0];
                IME.CustomerTitles.Add(ct);
            }
            else
            {

            }
        }

        private void TitleAdd_Load(object sender, EventArgs e)
        {
            var departmenList = IME.CustomerDepartments.Select(a=>a.departmentname).ToList();
            comboBox1.DataSource = departmenList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerMain form = new CustomerMain();
            form.Show();
            this.Hide();
        }
    }
}
