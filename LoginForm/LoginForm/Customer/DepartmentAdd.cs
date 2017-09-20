using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerPage2
{
    public partial class DepartmentAdd : Form
    {
        IMEEntities IME = new IMEEntities();
        public DepartmentAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = IME.CustomerDepartments.Where(department => department.departmentname == DepartmentName.Text).ToList();
            if (result.Count==0)
            {
                CustomerDepartment cd = new CustomerDepartment();
                cd.departmentname = DepartmentName.Text;
                IME.CustomerDepartments.Add(cd);
                IME.SaveChanges();
                MessageBox.Show(DepartmentName.Text + " is added as a Department");
            }
            else
            {
                MessageBox.Show("There is already a departmnet name with " + DepartmentName.Text);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CustomerMain form = new CustomerMain();
            form.Show();
            this.Hide();
        }
    }
}
