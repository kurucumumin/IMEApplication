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
    //deneme
    public partial class CemSupplierMainCem : Form
    {
        private static string AddressButtonsModeOpen = "Open";
        private static string AddressButtonsModeClose = "Close";

        string SupplierCustomerMode = String.Empty;
        string AddressMode = String.Empty;
        string ContactMode = String.Empty;

        private List<Supplier> gridSupplierList;

        public CemSupplierMainCem()
        {
            InitializeComponent();
        }
        private void CSupplierMain_Load(object sender, EventArgs e)
        {
            dgSupplier.DataSource = BringSuppierList(txtSearch.Text);
            dgSupplier.ClearSelection();
            initFillComboBoxes();
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

        private void initFillComboBoxes()
        {
            IMEEntities db = new IMEEntities();

            int workerId = Utils.getCurrentUser().WorkerID;
            cmbRepresentative.DisplayMember = "NameLastName";
            cmbRepresentative.Items.AddRange(db.Workers.ToArray());
            cmbRepresentative.Items.Insert(0,"Choose");
            cmbRepresentative.SelectedIndex = 0;

            cmbMainCategory.Items.AddRange(db.SupplierCategories.ToArray());
            cmbMainCategory.DisplayMember = "categoryname";
            cmbMainCategory.Items.Insert(0, "Choose");
            cmbMainCategory.SelectedIndex = 0;

            //cmbSubCategory.Items.AddRange(db.SupplierSubCategories.ToArray());
            //cmbSubCategory.DisplayMember = "subcategoryname";
            ////cmbSubCategory.ValueMember = "ID";
            //cmbSubCategory.Items.Insert(0, "Choose");
            //cmbSubCategory.SelectedIndex = 0;

            cmbAccountRep.Items.AddRange(db.Workers.ToArray());
            cmbAccountRep.DisplayMember = "NameLastName";
            cmbAccountRep.Items.Insert(0, "Choose");
            cmbAccountRep.SelectedIndex = 0;

            cmbAccountTerms.Items.AddRange(db.PaymentTerms.OrderBy(p => p.timespan).ToArray());
            cmbAccountTerms.DisplayMember = "term_name";
            cmbAccountTerms.Items.Insert(0, "Choose");
            cmbAccountTerms.SelectedIndex = 0;

            cmbAccountMethod.Items.AddRange(db.PaymentMethods.ToArray());
            cmbAccountMethod.DisplayMember = "Payment";
            cmbAccountMethod.Items.Insert(0, "Choose");
            cmbAccountMethod.SelectedIndex = 0;

            cmbQuoCurrency.Items.AddRange(db.Currencies.ToArray());
            cmbQuoCurrency.DisplayMember = "currencyName";
            cmbQuoCurrency.Items.Insert(0, "Choose");
            cmbQuoCurrency.SelectedIndex = 0;

            cmbInvoiceCurrency.Items.AddRange(db.Currencies.ToArray());
            cmbInvoiceCurrency.DisplayMember = "currencyName";
            cmbInvoiceCurrency.Items.Insert(0, "Choose");
            cmbInvoiceCurrency.SelectedIndex = 0;

            cmbCounrty.Items.AddRange(db.Countries.ToArray());
            cmbCounrty.DisplayMember = "Country_name";
            cmbCounrty.Items.Insert(0, "Choose");
            cmbCounrty.SelectedIndex = 0;

            cmbDepartment.Items.AddRange(db.CustomerDepartments.ToArray());
            cmbDepartment.DisplayMember = "departmentname";
            cmbDepartment.Items.Insert(0, "Choose");
            cmbDepartment.SelectedIndex = 0;

            //cmbPosition.DataSource = db.SupplierTitles.ToList();
            //cmbPosition.DisplayMember = "titlename";
            //cmbPosition.ValueMember = "ID";
            //cmbPosition.SelectedIndex = -1;

            cmbMainContact.Items.AddRange(db.SupplierWorkers.ToArray());
            cmbMainContact.DisplayMember = "languagename";
            cmbMainContact.Items.Insert(0, "Choose");
            cmbMainContact.SelectedIndex = 0;

            cmbLanguage.Items.AddRange(db.Languages.ToArray());
            cmbLanguage.DisplayMember = "languagename";
            cmbLanguage.Items.Insert(0, "Choose");
            cmbLanguage.SelectedIndex = 0;

            cmbBankName.Items.AddRange(db.SupplierBanks.ToArray());
            cmbBankName.DisplayMember = "bankname";
            cmbBankName.Items.Insert(0, "Choose");
            cmbBankName.SelectedIndex = 0;

            // TODO 100001 ComboBoxların kalanlarını sadece 'Choose' ile doldur
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (btnAdd.Text)
            {
                case "Add":
                    SupplierCustomerMode = "Add";
                    EnableGeneralInput(true);

                    txtSupplierCode.Text = NewSupplierID();




                    btnAdd.Text = "Save";
                    btnModify.Text = "Cancel";
                    break;
                case "Save":


                    SupplierCustomerMode = String.Empty;
                    break;
                default:
                    break;
            }
        }

        private void EnableGeneralInput(bool state)
        {
            dgSupplier.Enabled = !state;
            cmbRepresentative.Enabled = state;
            txtName.Enabled = state;
            cmbMainCategory.Enabled = state;
            btnMainCategoryAdd.Enabled = state;
            txtTaxOffice.Enabled = state;
            txtSupplierNotes.Enabled = state;
            if (state && cmbMainCategory.SelectedIndex > 0)
            {
                cmbSubCategory.Enabled = true;
                btnSubCategoryAdd.Enabled = true;
            }
            else
            {
                cmbSubCategory.Enabled = false;
                btnSubCategoryAdd.Enabled = false;
            }
            txtTaxNumber.Enabled = state;

            cmbAccountRep.Enabled = state;
            cmbAccountTerms.Enabled = state;
            cmbAccountMethod.Enabled = state;
            txtDiscountRate.Enabled = state;
            cmbQuoCurrency.Enabled = state;
            cmbInvoiceCurrency.Enabled = state;
            txtAccountNotes.Enabled = state;

            btnAddressAdd.Enabled = state;

            cmbDepartment.Enabled = state;
            btnDep.Enabled = state;
            btnPos.Enabled = state;
            txtContactName.Enabled = state;
            txtContactPhone.Enabled = state;
            txtExtraNumber.Enabled = state;
            txtContactMail.Enabled = state;
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
            if (state && cmbDepartment.SelectedIndex > 0)
            {
                cmbPosition.Enabled = true;
                btnPos.Enabled = true;
            }
            else
            {
                cmbPosition.Enabled = false;
                btnPos.Enabled = false;
            }

            cmbBankName.Enabled = state;
            txtBankBranchCode.Enabled = state;
            txtBankAccountNumber.Enabled = state;
            txtBankIban.Enabled = state;
            if (!state)
            {
                cmbCounrty.SelectedIndex = 0;
            }
        }

        private void EnableAddressInput(bool state)
        {
            txtPhone.Enabled = state;
            txtFax.Enabled = state;
            txtPoBox.Enabled = state;
            cmbCounrty.Enabled = state;
            txtPostCode.Enabled = state;
            txtWeb.Enabled = state;
            txtAddressDetail.Enabled = state;
            lbAddressList.Enabled = state;
            if (state && cmbCounrty.SelectedIndex > 0)
            {
                cmbCity.Enabled = true;
            }
            else
            {
                cmbCity.Enabled = false;
            }
            if (state && cmbCity.SelectedIndex > 0)
            {
                cmbTown.Enabled = true;
            }
            else
            {
                cmbTown.Enabled = false;
            }

            if (state)
            {
                if (lbAddressList.Items.Count > 0)
                {
                    btnAddressUpdate.Enabled = state;
                    btnAddressDelete.Enabled = state;
                }
                else
                {
                    btnAddressUpdate.Enabled = !state;
                    btnAddressDelete.Enabled = !state;
                }
            }
            else
            {
                if (SupplierCustomerMode == String.Empty)
                {
                    btnAddressAdd.Enabled = state;
                }
                btnAddressUpdate.Enabled = state;
                btnAddressDelete.Enabled = state;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            switch (btnModify.Text)
            {
                case "Modify":
                    SupplierCustomerMode = "Modify";
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
                    if (SupplierCustomerMode == "Add")
                    {
                        // Clear all input areas and close them
                        ClearInputs();
                    }
                    else
                    {
                        // Just close Inputs
                    }
                    AddressButtonsMode(AddressButtonsModeClose);
                    SupplierCustomerMode = String.Empty;
                    EnableAddressInput(false);
                    btnAdd.Text = "Add";
                    btnModify.Text = "Modify";
                    EnableGeneralInput(false);


                    break;
                default:

                    break;
            }
        }

        private void dgSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillSupplierInfo(dgSupplier.Rows[e.RowIndex].Cells[colID.Index].Value.ToString());
        }

        private void FillSupplierInfo(string SupplierID)
        {
            Supplier s = gridSupplierList.Where(x=>x.ID == SupplierID).FirstOrDefault();

            txtSupplierCode.Text = s.ID;
            txtName.Text = s.s_name;
            txtTaxOffice.Text = s.taxoffice;
            txtTaxNumber.Text = s.taxnumber;
            txtSupplierNotes.Text = s.Note.Note_name;

            string name = s.Worker1.NameLastName;
            cmbRepresentative.SelectedIndex = cmbRepresentative.FindStringExact(name);

            name = s.SupplierCategory.categoryname;
            cmbMainCategory.SelectedIndex = cmbMainCategory.FindStringExact(name);

            name = s.SupplierSubCategory.subcategoryname;
            cmbSubCategory.SelectedIndex = cmbSubCategory.FindStringExact(name);


            

        }

        private void ClearInputs()
        {
            txtSupplierCode.Text = String.Empty;


        }

        //private void btnDep_Click(object sender, EventArgs e)
        //{
        //    SupplierCategoryAdd form = new SupplierCategoryAdd();
        //    form.ShowDialog();

        //    cmbDepartment.Items.Clear();
        //    cmbDepartment.DisplayMember = "departmentname";
        //    cmbDepartment.Items.AddRange(new IMEEntities().SupplierDepartments.ToArray());
        //    cmbDepartment.Items.Insert(0, "Choose");
        //    cmbDepartment.SelectedIndex = 0;

        //}

        private void btnMainCategoryAdd_Click(object sender, EventArgs e)
        {
            frmSupplierCategoryAdd form = new frmSupplierCategoryAdd();
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                cmbMainCategory.Items.Clear();
                cmbMainCategory.DisplayMember = "categoryname";
                cmbMainCategory.Items.AddRange(new IMEEntities().SupplierCategories.ToArray());
                cmbMainCategory.Items.Insert(0, "Choose");
                cmbMainCategory.SelectedIndex = cmbMainCategory.Items.Count - 1;
            }
        }

        private void btnSubCategoryAdd_Click(object sender, EventArgs e)
        {
            SupplierCategory sc = ((SupplierCategory)cmbMainCategory.SelectedItem);
            frmSupplierSubCategoryAdd form = new frmSupplierSubCategoryAdd(sc.categoryname);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                cmbSubCategory.Items.Clear();
                cmbSubCategory.DisplayMember = "subcategoryname";
                cmbSubCategory.Items.AddRange(new IMEEntities().SupplierSubCategories.Where(x=>x.categoryID == sc.ID).ToArray());
                cmbSubCategory.Items.Insert(0, "Choose");
                cmbSubCategory.SelectedIndex = cmbSubCategory.Items.Count - 1;
            }
        }

        private void cmbMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMainCategory.Items.Count != 0)
            {
                if (cmbMainCategory.SelectedIndex > 0)
                {
                    int id = ((SupplierCategory)cmbMainCategory.SelectedItem).ID;

                    cmbSubCategory.Items.Clear();
                    cmbSubCategory.DisplayMember = "subcategoryname";
                    cmbSubCategory.Items.AddRange(new IMEEntities().SupplierSubCategories.Where(x => x.categoryID == id).ToArray());
                    cmbSubCategory.Items.Insert(0, "Choose");
                    cmbSubCategory.SelectedIndex = 0;

                    cmbSubCategory.Enabled = true;
                    btnSubCategoryAdd.Enabled = true;
                }
                else
                {

                    if (cmbSubCategory.Items.Count != 0)
                    {
                        cmbSubCategory.SelectedIndex = 0;
                    }
                    cmbSubCategory.Enabled = false;
                    btnSubCategoryAdd.Enabled = false;
                }
            }else
            {
                cmbSubCategory.Enabled = true;
                btnSubCategoryAdd.Enabled = false;
            }
        }

        private string NewSupplierID()
        {
            IMEEntities db = new IMEEntities(); 
            string suppliercode = "";
            if (db.Suppliers.ToList().Count != 0)
            {
                suppliercode = db.Suppliers.OrderByDescending(a => a.ID).FirstOrDefault().ID;

                int newSupplierCodeNumbers = 0;
                string newsuppliercodechars = string.Empty;
                string NewID = string.Empty;

                int i;
                for (i = 0; i < suppliercode.Length; i++)
                {
                    if (!Char.IsDigit(suppliercode[i]))
                    {
                        newsuppliercodechars += suppliercode[i];
                    }
                    else
                    {
                        newSupplierCodeNumbers = Int32.Parse(suppliercode.Substring(i));
                        break;
                    }
                }

                NewID += newsuppliercodechars;
                for (i = 0; i < (4 - newSupplierCodeNumbers.ToString().Length); i++)
                {
                    NewID += "0";
                }
                NewID += (newSupplierCodeNumbers + 1);
                return NewID;
            }
            else
            {
                return "SC0001";
            }
        }

        private void cmbCounrty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCounrty.Items.Count != 0)
            {
                if (cmbCounrty.SelectedIndex > 0)
                {
                    int id = ((Country)cmbCounrty.SelectedItem).ID;

                    cmbCity.Items.Clear();
                    cmbCity.DisplayMember = "City_name";
                    cmbCity.Items.AddRange(new IMEEntities().Cities.Where(x => x.CountryID == id).ToArray());
                    cmbCity.Items.Insert(0, "Choose");
                    cmbCity.SelectedIndex = 0;

                    cmbCity.Enabled = true;
                }
                else
                {
                    if (cmbCity.Items.Count != 0)
                    {
                        cmbCity.SelectedIndex = 0;
                    }
                    cmbCity.Enabled = false;
                }
            }
            else
            {
                cmbCity.Enabled = true;
            }
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCity.Items.Count != 0)
            {
                if (cmbCity.SelectedIndex > 0)
                {
                    int id = ((City)cmbCity.SelectedItem).ID;

                    cmbTown.Items.Clear();
                    cmbTown.DisplayMember = "Town_name";
                    cmbTown.Items.AddRange(new IMEEntities().Towns.Where(x => x.CityID == id).ToArray());
                    cmbTown.Items.Insert(0, "Choose");
                    cmbTown.SelectedIndex = 0;

                    cmbTown.Enabled = true;
                }
                else
                {

                    if (cmbTown.Items.Count != 0)
                    {
                        cmbTown.SelectedIndex = 0;
                    }
                    cmbTown.Enabled = false;
                }
            }
            else
            {
                cmbTown.Enabled = true;
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.Items.Count != 0)
            {
                if (cmbDepartment.SelectedIndex > 0)
                {
                    int id = ((CustomerDepartment)cmbDepartment.SelectedItem).ID;

                    cmbPosition.Items.Clear();
                    cmbPosition.DisplayMember = "titlename";
                    cmbPosition.Items.AddRange(new IMEEntities().CustomerTitles.ToArray());
                    cmbPosition.Items.Insert(0, "Choose");
                    cmbPosition.SelectedIndex = 0;

                    btnPos.Enabled = true;
                    cmbPosition.Enabled = true;
                }
                else
                {

                    if (cmbPosition.Items.Count != 0)
                    {
                        cmbPosition.SelectedIndex = 0;
                    }
                    btnPos.Enabled = false;
                    cmbPosition.Enabled = false;
                }
            }
            else
            {
                btnPos.Enabled = true;
                cmbPosition.Enabled = true;
            }
        }

        private void btnAddressAdd_Click(object sender, EventArgs e)
        {
            EnableAddressInput(true);
            AddressButtonsMode(AddressButtonsModeOpen);
        }

        private void AddressButtonsMode(string Mode)
        {
            if (Mode == AddressButtonsModeOpen)
            {
                btnAddressAdd.Visible = false;
                btnAddressUpdate.Visible = false;
                btnAddressDelete.Visible = false;
                btnAddressDone.Visible = true;
                btnAddressCancel.Visible = true;
            }else if (Mode == AddressButtonsModeClose)
            {
                btnAddressAdd.Visible = true;
                btnAddressUpdate.Visible = true;
                btnAddressDelete.Visible = true;
                btnAddressDone.Visible = false;
                btnAddressCancel.Visible = false;
            }
        }

        private void btnAddressCancel_Click(object sender, EventArgs e)
        {
            EnableAddressInput(false);
            AddressButtonsMode("Close");
        }

        private void btnAddressDone_Click(object sender, EventArgs e)
        {

        }

        private void btnAddressUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnAddressDelete_Click(object sender, EventArgs e)
        {

        }
    }

    
}