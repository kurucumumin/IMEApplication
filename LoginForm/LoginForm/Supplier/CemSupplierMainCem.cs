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
    public partial class CemSupplierMainCem : Form
    {
        private List<Supplier> gridSupplierList;

        public CemSupplierMainCem()
        {
            InitializeComponent();
        }
        private void CSupplierMain_Load(object sender, EventArgs e)
        {
            dgSupplier.DataSource = BringSuppierList(txtSearch.Text);
            dgSupplier.ClearSelection();
            FillComboBoxes();
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

        private void FillComboBoxes()
        {
            IMEEntities db = new IMEEntities();

            int workerId = Utils.getCurrentUser().WorkerID;

            cmbRepresentative.Items.AddRange(db.Workers.Where(a => a.WorkerID == workerId).ToArray());
            cmbRepresentative.DisplayMember = "NameLastName";
            //cmbRepresentative.ValueMember = "WorkerID";
            cmbRepresentative.Items.Insert(0,"Choose");
            cmbRepresentative.SelectedIndex = 0;

            cmbMainCategory.Items.AddRange(db.SupplierCategories.ToArray());
            cmbMainCategory.DisplayMember = "categoryname";
            //cmbMainCategory.ValueMember = "ID";
            cmbMainCategory.Items.Insert(0, "Choose");
            cmbMainCategory.SelectedIndex = 0;

            cmbSubCategory.Items.AddRange(db.SupplierSubCategories.ToArray());
            cmbSubCategory.DisplayMember = "subcategoryname";
            //cmbSubCategory.ValueMember = "ID";
            cmbSubCategory.Items.Insert(0, "Choose");
            cmbSubCategory.SelectedIndex = 0;

            cmbAccountRep.Items.AddRange(db.Workers.ToArray());
            cmbAccountRep.DisplayMember = "NameLastName";
            //cmbAccountRep.ValueMember = "WorkerID";
            cmbAccountRep.Items.Insert(0, "Choose");
            cmbAccountRep.SelectedIndex = 0;

            cmbAccountTerms.Items.AddRange(db.PaymentTerms.OrderBy(p => p.timespan).ToArray());
            cmbAccountTerms.DisplayMember = "term_name";
            //cmbAccountTerms.ValueMember = "ID";
            cmbAccountTerms.Items.Insert(0, "Choose");
            cmbAccountTerms.SelectedIndex = 0;

            cmbAccountMethod.Items.AddRange(db.PaymentMethods.ToArray());
            cmbAccountMethod.DisplayMember = "Payment";
            //cmbAccountMethod.ValueMember = "ID";
            cmbAccountMethod.Items.Insert(0, "Choose");
            cmbAccountMethod.SelectedIndex = 0;

            cmbQuoCurrency.Items.AddRange(db.Currencies.ToArray());
            cmbQuoCurrency.DisplayMember = "currencyName";
            //cmbQuoCurrency.ValueMember = "currencyId";
            cmbQuoCurrency.Items.Insert(0, "Choose");
            cmbQuoCurrency.SelectedIndex = 0;

            cmbInvoiceCurrency.Items.AddRange(db.Currencies.ToArray());
            cmbInvoiceCurrency.DisplayMember = "currencyName";
            //cmbInvoiceCurrency.ValueMember = "currencyId";
            cmbInvoiceCurrency.Items.Insert(0, "Choose");
            cmbInvoiceCurrency.SelectedIndex = 0;

            cmbCounrty.Items.AddRange(db.Countries.ToArray());
            cmbCounrty.DisplayMember = "Country_name";
            //cmbCounrty.ValueMember = "ID";
            cmbCounrty.Items.Insert(0, "Choose");
            cmbCounrty.SelectedIndex = 0;

            cmbDepartment.Items.AddRange(db.SupplierDepartments.ToArray());
            cmbDepartment.DisplayMember = "departmentname";
            //cmbDepartment.ValueMember = "ID";
            cmbDepartment.Items.Insert(0, "Choose");
            cmbDepartment.SelectedIndex = 0;

            //cmbPosition.DataSource = db.SupplierTitles.ToList();
            //cmbPosition.DisplayMember = "titlename";
            //cmbPosition.ValueMember = "ID";
            //cmbPosition.SelectedIndex = -1;

            cmbLanguage.Items.AddRange(db.Languages.ToArray());
            cmbLanguage.DisplayMember = "languagename";
            //cmbLanguage.ValueMember = "ID";
            cmbLanguage.Items.Insert(0, "Choose");
            cmbLanguage.SelectedIndex = 0;

            cmbBankName.Items.AddRange(db.SupplierBanks.ToArray());
            cmbBankName.DisplayMember = "bankname";
            //cmbBankName.ValueMember = "ID";
            cmbBankName.Items.Insert(0, "Choose");
            cmbBankName.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (btnAdd.Text)
            {
                case "Add":
                    EnableGeneralInput(true);



                    btnAdd.Text = "Save";
                    btnModify.Text = "Cancel";
                    break;
                case "Save":



                    break;
                default:
                    break;
            }
        }

        private void EnableGeneralInput(bool state)
        {
            cmbRepresentative.Enabled = state;
            txtName.Enabled = state;
            cmbMainCategory.Enabled = state;
            txtTaxOffice.Enabled = state;
            txtSupplierNotes.Enabled = state;
            cmbSubCategory.Enabled = state;
            txtTaxNumber.Enabled = state;
            cmbAccountRep.Enabled = state;
            cmbAccountTerms.Enabled = state;
            cmbAccountMethod.Enabled = state;
            txtDiscountRate.Enabled = state;
            cmbQuoCurrency.Enabled = state;
            cmbInvoiceCurrency.Enabled = state;
            txtAccountNotes.Enabled = state;
            txtPhone.Enabled = state;
            txtFax.Enabled = state;
            txtPoBox.Enabled = state;
            cmbCounrty.Enabled = state;
            txtPostCode.Enabled = state;
            txtWeb.Enabled = state;
            txtAddressDetail.Enabled = state;
            lbAddressList.Enabled = state;
            btnAddressAdd.Enabled = state;
            btnAddressUpdate.Enabled = state;
            btnAddressDelete.Enabled = state;
            cmbDepartment.Enabled = state;
            cmbPosition.Enabled = state;
            txtContactName.Enabled = state;
            txtContactPhone.Enabled = state;
            txtExtraNumber.Enabled = state;
            txtExtraNumber.Enabled = state;
            cmbMainContact.Enabled = state;
            txtContactMobile.Enabled = state;
            txtContactFax.Enabled = state;
            cmbLanguage.Enabled = state;
            txtContactAddress.Enabled = state;
            txtContactNotes.Enabled = state;
            lbContacts.Enabled = state;
            btnContactNew.Enabled = state;
            btnContactUpdate.Enabled = state;
            btnContactDelete.Enabled = state;
            cmbBankName.Enabled = state;
            txtBankBranchCode.Enabled = state;
            txtBankAccountNumber.Enabled = state;
            txtBankIban.Enabled = state;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            switch (btnModify.Text)
            {
                case "Modify":
                    if (dgSupplier.SelectedRows.Count != 0)
                    {
                        EnableGeneralInput(true);

                        btnAdd.Text = "Save";
                        btnModify.Text = "Cancel";
                    }
                    else
                    {
                        MessageBox.Show("You should choose a customer first!","Info");
                    }
                    break;
                case "Cancel":
                    EnableGeneralInput(false);

                    btnAdd.Text = "Add";
                    btnModify.Text = "Modify";
                    break;
                default:

                    break;
            }
        }
    }

    
}