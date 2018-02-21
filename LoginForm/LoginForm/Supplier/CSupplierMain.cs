using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class CSupplierMain : Form
    {
        private List<Supplier> gridSupplierList;

        public CSupplierMain()
        {
            InitializeComponent();
        }
        private void CSupplierMain_Load(object sender, EventArgs e)
        {
            dgSupplier.DataSource = BringSuppierList(txtSearch.Text);
        }
        private List<Supplier> BringSuppierList(string SupplierName)
        {
            if (SupplierName == null)
            {
                throw new ArgumentNullException(nameof(SupplierName));
            }

            gridSupplierList = new IMEEntities().Suppliers.Where(x => x.s_name.Contains(SupplierName)).ToList();
            return gridSupplierList.ToList();
        }

        private void fillComboBoxes()
        {
            IMEEntities db = new IMEEntities();

            cmbRepresentative.DataSource = db.Workers.Where(a => a.WorkerID == Utils.getCurrentUser().WorkerID).ToList();
            cmbRepresentative.DisplayMember = "NameLastName";
            cmbRepresentative.ValueMember = "WorkerID";

            cmbMainCategory.DataSource = db.SupplierCategories.ToList();
            cmbMainCategory.DisplayMember = "categoryname";
            cmbMainCategory.ValueMember = "ID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmbRepresentative.Enabled = true;
        }


    }

    
}