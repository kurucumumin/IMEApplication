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
    public partial class SupplierPositionAdd : Form
    {
        IMEEntities db = new IMEEntities();

        public SupplierPositionAdd()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            //SupplierMain form = new SupplierMain();
            //form.Show();
            this.Hide();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var dep = db.SupplierDepartments.Where(a => a.departmentname == cmbDepartment.Text).FirstOrDefault();
            if (dep != null)
            {
                var result = db.SupplierTitles.Where(title => title.titlename == txttitle.Text).FirstOrDefault();

                if (result == null || (((db.SupplierTitles.Where(a => a.departmnetID == a.departmnetID)).Count() == 0) && result != null))
                {
                    SupplierTitle ct = new SupplierTitle();
                    ct.titlename = txttitle.Text;
                    string Department = cmbDepartment.Items[cmbDepartment.SelectedIndex].ToString();
                    ct.departmnetID = db.SupplierDepartments.Where(cd => cd.departmentname == Department).Select(cd => cd.ID).ToList()[0];
                    db.SupplierTitles.Add(ct);
                    MessageBox.Show(this, ct.titlename + " added as a Title");
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

            private void SupplierPositionAdd_Load(object sender, EventArgs e)
        {
            var departmenList = db.SupplierDepartments.Select(a => a.departmentname).ToList();
            cmbDepartment.DataSource = departmenList;
        }
    }
}
