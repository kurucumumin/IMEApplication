using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleSupplier
{
    public partial class DepartmentAdd : Form
    {
        IMEEntities db = new IMEEntities();

        public DepartmentAdd()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var result = db.SupplierDepartment.Where(department => department.departmentname == txtdepartment.Text).ToList();
            if (result.Count == 0)
            {
                SupplierDepartment cd = new SupplierDepartment();
                cd.departmentname = txtdepartment.Text;
                db.SupplierDepartment.Add(cd);
                db.SaveChanges();
                MessageBox.Show(txtdepartment.Text + " is added as a Department");
            }
            else
            {
                MessageBox.Show("There is already a departmnet name with " + txtdepartment.Text);
            }
        }
    }
}
