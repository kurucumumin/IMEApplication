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

        private void PositionAdd_Load(object sender, EventArgs e)
        {
            var departmenList = db.SupplierDepartments.Select(a => a.departmentname).ToList();
            cmbDepartment.DataSource = departmenList;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            SupplierMain form = new SupplierMain();
            form.Show();
            this.Hide();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var result = db.SupplierTitles.Where(title => title.titlename == txttitle.Text).ToList();
            if (result.Count == 0)
            {

                SupplierTitle ct = new SupplierTitle();
                ct.titlename = txttitle.Text;
                string Department = cmbDepartment.Items[cmbDepartment.SelectedIndex].ToString();
                ct.departmnetID = db.SupplierDepartments.Where(cd => cd.departmentname == Department).Select(cd => cd.ID).ToList()[0];
                db.SupplierTitles.Add(ct);
            }
            else
            {
                MessageBox.Show("There is already a position name with " + txttitle.Text);
            }
        }
    }
}
