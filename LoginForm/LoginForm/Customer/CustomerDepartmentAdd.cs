using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class CustomerDepartmentAdd : Form
    {
        IMEEntities IME = new IMEEntities();
        public CustomerDepartmentAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = IME.CustomerDepartments.Where(department => department.departmentname == DepartmentName.Text).ToList();
            if (result.Count == 0)
            {
                CustomerDepartment cd = new CustomerDepartment();
                cd.departmentname = DepartmentName.Text;
                IME.CustomerDepartments.Add(cd);
                IME.SaveChanges();
                MessageBox.Show(DepartmentName.Text + " is added as a Department");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("There is already a departmnet name with " + DepartmentName.Text);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
