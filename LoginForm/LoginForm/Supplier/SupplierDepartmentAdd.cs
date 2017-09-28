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
    public partial class SupplierDepartmentAdd : Form
    {
        IMEEntities db = new IMEEntities();

        public SupplierDepartmentAdd()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            SupplierMain form = new SupplierMain();
            form.Show();
            this.Hide();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var result = db.SupplierDepartments.Where(department => department.departmentname == txtdepartment.Text).ToList();
            if (result.Count == 0)
            {
                //CommitDenemefromDemir
                SupplierDepartment cd = new SupplierDepartment();
                cd.departmentname = txtdepartment.Text;
                db.SupplierDepartments.Add(cd);
                db.SaveChanges();
                MessageBox.Show(txtdepartment.Text + " is added as a Department");
            }
            else
            {
                MessageBox.Show("There is already a departmnet name with " + txtdepartment.Text);
            }
        }

        private void SupplierDepartmentAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
