using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LoginForm.clsClasses;
using LoginForm.MyClasses;
using static LoginForm.Services.MyClasses.MyAuthority;

namespace LoginForm
{
    //deneme
    public partial class frmSupplierMain : MyForm
    {
        private static string AddressButtonsModeOpen = "Open";
        private static string AddressButtonsModeClose = "Close";

        private static string ContactButtonsModeOpen = "Open";
        private static string ContactButtonsModeClose = "Close";
        
        private static string BankAccountButtonsModeOpen = "Open";
        private static string BankAccountButtonsModeClose = "Close";

        private static string EmptyCheckTypeGeneral = "General";
        private static string EmptyCheckTypeContact = "Contact";
        private static string EmptyCheckTypeAddress = "Address";
        private static string EmptyCheckTypeBankAccount = "BankAccount";


        private static string SupplierModeAdd = "Add";
        private static string SupplierModeModify = "Modify";
        bool fromBillFromCustomer = false;

        BindingList<SupplierAddress> SavedAddresses = new BindingList<SupplierAddress>();
        BindingList<SupplierWorker> SavedContacts = new BindingList<SupplierWorker>();
        BindingList<SupplierBankAccount> SavedBankAccounts = new BindingList<SupplierBankAccount>();

        string SupplierAddMode = String.Empty;
        string AddressMode = String.Empty;
        string ContactMode = String.Empty;
        string BankMode = String.Empty;

        private List<Supplier> gridSupplierList;

        public frmSupplierMain(string SupplierID)
        {
            InitializeComponent();
            this.dgSupplier.AutoGenerateColumns = false;
            tabgenel.Enabled = false;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnExit.Enabled = false;
            fromBillFromCustomer = true;
        }

        public frmSupplierMain(Boolean buttonEnabled)
        {
            InitializeComponent();
        }

        public frmSupplierMain()
        {
            InitializeComponent();
            this.dgSupplier.AutoGenerateColumns = false;
        }
        private void ControlAutorization()
        {
            if (!Utils.AuthorityCheck(IMEAuthority.CanAddSupplier))
            {
                btnAdd.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanEditSupplier))
            {
                btnModify.Visible = false;
            }
        }
        private void CSupplierMain_Load(object sender, EventArgs e)
        {
            ControlAutorization();
            dgSupplier.DataSource = BringSupplierList(txtSearch.Text);
            dgSupplier.ClearSelection();
            initFillComboBoxes();
        }
        private List<Supplier> BringSupplierList(string SupplierName)
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

            cmbCurrency.Items.AddRange(db.Currencies.ToArray());
            cmbCurrency.DisplayMember = "currencyName";
            cmbCurrency.Items.Insert(0, "Choose");
            cmbCurrency.SelectedIndex = 0;

            //cmbInvoiceCurrency.Items.AddRange(db.Currencies.ToArray());
            //cmbInvoiceCurrency.DisplayMember = "currencyName";
            //cmbInvoiceCurrency.Items.Insert(0, "Choose");
            //cmbInvoiceCurrency.SelectedIndex = 0;

            cmbCountry.Items.AddRange(db.Countries.ToArray());
            cmbCountry.DisplayMember = "Country_name";
            cmbCountry.Items.Insert(0, "Choose");
            cmbCountry.SelectedIndex = 0;

            cmbDepartment.Items.AddRange(db.CustomerDepartments.ToArray());
            cmbDepartment.DisplayMember = "departmentname";
            cmbDepartment.Items.Insert(0, "Choose");
            cmbDepartment.SelectedIndex = 0;

            //cmbPosition.DataSource = db.SupplierTitles.ToList();
            //cmbPosition.DisplayMember = "titlename";
            //cmbPosition.ValueMember = "ID";
            //cmbPosition.SelectedIndex = -1;

            //cmbMainContact.Items.Insert(0, "Choose");
            //cmbMainContact.DisplayMember = "languagename";
            //cmbMainContact.SelectedIndex = 0;

            cmbLanguage.Items.AddRange(db.Languages.ToArray());
            cmbLanguage.DisplayMember = "languagename";
            cmbLanguage.Items.Insert(0, "Choose");
            cmbLanguage.SelectedIndex = 0;

            //txtAccountTitle.Items.AddRange(db.SupplierBanks.ToArray());
            //txtAccountTitle.DisplayMember = "bankname";
            //txtAccountTitle.Items.Insert(0, "Choose");
            //txtAccountTitle.SelectedIndex = 0;

            cmbContactAddress.Items.Insert(0, "Choose");
            cmbContactAddress.DisplayMember = "Title";
            cmbContactAddress.SelectedIndex = 0;


            // TODO 100001 ComboBoxların kalanlarını sadece 'Choose' ile doldur
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (btnAdd.Text)
            {
                case "Add":
                    ClearGeneralInputs();
                    ClearAddressInputs();
                    ClearContactInputs();
                    ClearBankInputs();
                    cmbMainContact.DataSource = null;
                    SupplierAddMode = SupplierModeAdd;
                    EnableGeneralInput(true);

                    txtSupplierCode.Text = NewSupplierID();

                    btnAdd.Text = "Save";
                    btnModify.Text = "Cancel";
                    AddressButtonsMode(AddressButtonsModeOpen);
                    ContactButtonsMode(ContactButtonsModeOpen);

                    btnBankAdd.Enabled = true;
                    btnBankDelete.Enabled = true;
                    btnBankUpdate.Enabled = true;



                    btnNewAddress();
                    btnNewContact();
                    btnNewBankAccount();
                    break;
                case "Save":
                    if (SupplierAddMode == SupplierModeAdd)
                    {
                        SaveNewSupplier();

                    }
                    else if (SupplierAddMode == SupplierModeModify)
                    {
                        SaveModifiedSupplier();
                    }
                    break;
            }
        }

        private void btnNewBankAccount()
        {
            BankMode = "Add";
            lbBankList.ClearSelected();
            lbContacts.Enabled = false;

            ClearBankInputs();
            EnableBankAccountInput(true);
            //BankButtonsMode(ContactButtonsModeOpen);
            //ManageDeleteAndModifyButtons(lbContacts, btnContactUpdate, btnContactDelete);
        }

        private void ClearBankInputs()
        {
            txtAccountTitle.Clear();
            txtBankBranchCode.Clear();
            txtBankAccountNumber.Clear();
            txtBankIban.Clear();
            if (SupplierAddMode == String.Empty)
            {
                SavedBankAccounts.Clear();
            }
        }

        private void SaveModifiedSupplier()
        {
            if (!InputErrorExist(EmptyCheckTypeGeneral))
            {
                IMEEntities db = new IMEEntities();
                try
                {
                    Supplier s = db.Suppliers.Where(x => x.ID == txtSupplierCode.Text).FirstOrDefault();
                    s.representaryID = ((Worker)cmbRepresentative.SelectedItem).WorkerID;
                    s.s_name = txtName.Text;
                    s.CategoryID = ((SupplierCategory)cmbMainCategory.SelectedItem).ID;
                    s.SubCategoryID = ((SupplierSubCategory)cmbSubCategory.SelectedItem).ID;
                    s.taxoffice = txtTaxOffice.Text;
                    s.taxnumber = txtTaxNumber.Text;
                    s.accountrepresentaryID = ((Worker)cmbAccountRep.SelectedItem).WorkerID;
                    s.payment_termID = ((PaymentTerm)cmbAccountTerms.SelectedItem).ID;
                    s.paymentmethodID = ((PaymentMethod)cmbAccountMethod.SelectedItem).ID;
                    //s.discountrate = Convert.ToDecimal(txtDiscountRate.Text);
                    s.DefaultCurrency = ((Currency)cmbCurrency.SelectedItem).currencyID;
                    //s.BankID = ((SupplierBank)cmbBankName.SelectedItem).ID;

                    s.webadress = (txtWeb.Text != String.Empty) ? txtWeb.Text : null;

                    if (s.Note1 == null)
                    {
                        if (txtSupplierNotes.Text != String.Empty)
                        {
                            try
                            {
                                Note n = new Note();
                                n.Note_name = txtSupplierNotes.Text;
                                db.Notes.Add(n);
                                db.SaveChanges();

                                s.SupplierNoteID = n.ID;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("SN1: SupplierNote could not been updated!." + "/n" + ex.ToString(), "Note Update Error");
                            }
                        }
                    }
                    else
                    {
                        Note n = db.Notes.Where(x => x.ID == s.Note1.ID).FirstOrDefault();
                        if (txtSupplierNotes.Text != String.Empty)
                        {
                            n.Note_name = txtSupplierNotes.Text;
                        }
                        else
                        {
                            db.Notes.Remove(n);
                            s.Note1 = null;
                        }
                        db.SaveChanges();
                    }
                    db.SaveChanges();

                    List<SupplierAddress> deleteAddress = new List<SupplierAddress>();

                    foreach (SupplierAddress add in s.SupplierAddresses)
                    {
                        SupplierAddress _add = db.SupplierAddresses.Where(x => x.ID == add.ID).FirstOrDefault();
                        SupplierAddress _sa = SavedAddresses.Where(x => x.Title == add.Title).FirstOrDefault();

                        if(_sa != null)
                        {
                            _add.AdressDetails = _sa.AdressDetails;
                            _add.TownID = _sa.TownID;
                            _add.CityID = _sa.CityID;
                            _add.CountryID = _sa.CountryID;
                            _add.Fax = _sa.Fax;
                            _add.Phone = _sa.Phone;
                            _add.PoBox = _sa.PoBox;
                            _add.PostCode = _sa.PostCode;
                            _add.Title = _sa.Title;

                            db.SaveChanges();
                        }
                        else
                        {
                            deleteAddress.Add(_add);
                        }
                    }
                    
                    db.SupplierAddresses.RemoveRange(deleteAddress);
                    db.SaveChanges();


                    foreach (SupplierAddress a in SavedAddresses)
                    {
                        if (a.ID == 0)
                        {
                            db.SupplierAddresses.Add(a);
                        }
                    }


                    foreach (SupplierWorker worker in SavedContacts)
                    {
                        SupplierWorker w = db.SupplierWorkers.Where(x => x.ID == worker.ID).FirstOrDefault();
                        if (worker.Note != null)
                        {
                            Note n = db.Notes.Where(x => x.ID == worker.Note.ID).FirstOrDefault();
                            if (worker.Note.Note_name == String.Empty)
                            {
                                db.Notes.Remove(n);
                            }
                            else
                            {
                                n.Note_name = worker.Note.Note_name;
                                worker.supplierNoteID = n.ID;
                                worker.Note = null;
                            }
                            db.SaveChanges();
                        }

                        if (worker.SupplierAddress != null)
                        {
                            int addressID = db.SupplierAddresses.Where(x => x.SupplierID == s.ID && x.Title == worker.SupplierAddress.Title).FirstOrDefault().ID;
                            worker.SupplierAddress = null;
                            worker.supplieradressID = addressID;
                        }
                        w.departmentID = worker.departmentID;
                        w.languageID = worker.languageID;
                        w.mobilephone = worker.mobilephone;
                        w.phone = worker.phone;
                        w.fax = worker.fax;
                        w.PhoneExternalNum = worker.PhoneExternalNum;
                        w.sw_email = worker.sw_email;
                        w.sw_name = worker.sw_name;
                        w.titleID = worker.titleID;
                        db.SaveChanges();
                    }
                    s.MainContactID = db.SupplierWorkers.Where(x => x.supplierID == s.ID).FirstOrDefault().ID;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("S1:An error occured while updating the Supplier! Try Again Later /n" + ex.ToString(), "Error");
                    throw;
                }
                finally
                {
                    SupplierAddMode = String.Empty;
                    dgSupplier.DataSource = new IMEEntities().Suppliers.ToList();
                    EnableGeneralInput(false);
                    EnableAddressInput(false);
                    EnableContactInput(false);
                    EnableBankAccountInput(false);

                    BringSupplierList(txtSearch.Text);

                    btnAdd.Text = SupplierModeAdd;
                    btnModify.Text = SupplierModeModify;
                }

            }
        }

        private void EnableBankAccountInput(bool state)
        {
            txtAccountTitle.Enabled = state;
            txtBankBranchCode.Enabled = state;
            txtBankAccountNumber.Enabled = state;
            txtBankIban.Enabled = state;
            if (SupplierAddMode == String.Empty)
            {
                lbBankList.Enabled = state;
            }
            else
            {
                lbBankList.Enabled = !state;
            }
            
            if (state)
            {
                if (lbBankList.Items.Count > 0)
                {
                    btnBankUpdate.Enabled = state;
                    btnBankDelete.Enabled = state;
                }
                else
                {
                    btnBankUpdate.Enabled = !state;
                    btnBankDelete.Enabled = !state;
                }
            }
            else
            {
                if (SupplierAddMode == String.Empty)
                {
                    btnBankAdd.Enabled = state;
                }
                btnBankUpdate.Enabled = state;
                btnBankDelete.Enabled = state;
            }
        }

        private void SaveNewSupplier()
        {
            if (!InputErrorExist(EmptyCheckTypeGeneral))
            {
                IMEEntities db = new IMEEntities();
                try
                {
                    Supplier s = new Supplier();
                    s.ID = txtSupplierCode.Text;
                    s.representaryID = ((Worker)cmbRepresentative.SelectedItem).WorkerID;
                    s.s_name = txtName.Text;
                    s.CategoryID = ((SupplierCategory)cmbMainCategory.SelectedItem).ID;
                    s.SubCategoryID = ((SupplierSubCategory)cmbSubCategory.SelectedItem).ID;
                    s.taxoffice = txtTaxOffice.Text;
                    s.taxnumber = txtTaxNumber.Text;
                    s.accountrepresentaryID = ((Worker)cmbAccountRep.SelectedItem).WorkerID;
                    if(cmbAccountTerms.SelectedIndex != 0)
                    {
                        s.payment_termID = ((PaymentTerm)cmbAccountTerms.SelectedItem).ID;
                    }
                    if(cmbAccountMethod.SelectedIndex != 0)
                    {
                        s.paymentmethodID = ((PaymentMethod)cmbAccountMethod.SelectedItem).ID;
                    }
                        
                     
                    //s.discountrate = Convert.ToDecimal(txtDiscountRate.Text);
                    s.DefaultCurrency = ((Currency)cmbCurrency.SelectedItem).currencyID;
                    //s.BankID = ((SupplierBank)txtAccountTitle.SelectedItem).ID;
                    //s.branchcode = txtBankBranchCode.Text;
                    //s.accountnumber = txtBankAccountNumber.Text;
                    //s.iban = txtBankIban.Text;

                    s.webadress = (txtWeb.Text != String.Empty) ? txtWeb.Text : null;

                    if (txtSupplierNotes.Text != String.Empty)
                    {
                        try
                        {
                            Note n = new Note();
                            n.Note_name = txtSupplierNotes.Text;
                            db.Notes.Add(n);
                            db.SaveChanges();

                            s.SupplierNoteID = n.ID;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("SN1: SupplierNote could not be added!." + "/n" + ex.ToString(), "Note Saving Error");
                        }
                    }

                    db.Suppliers.Add(s);
                    db.SaveChanges();


                    foreach (SupplierAddress address in SavedAddresses)
                    {
                        db.SupplierAddresses.Add(address);
                        db.SaveChanges();
                    }


                    foreach (SupplierWorker worker in SavedContacts)
                    {
                        if (worker.Note != null)
                        {
                            Note n = worker.Note;
                            worker.Note = null;
                            db.Notes.Add(n);
                            db.SaveChanges();
                            worker.supplierNoteID = n.ID;
                        }

                        if (worker.SupplierAddress != null)
                        {
                            int addressID = db.SupplierAddresses.Where(x => x.SupplierID == s.ID && x.Title == worker.SupplierAddress.Title).FirstOrDefault().ID;
                            worker.SupplierAddress = null;
                            worker.supplieradressID = addressID;
                        }

                        db.SupplierWorkers.Add(worker);
                        db.SaveChanges();
                    }
                    s.MainContactID = db.SupplierWorkers.Where(x => x.supplierID == s.ID).FirstOrDefault().ID;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("S1:An error occured while saving the Supplier! Try Again Later /n" + ex.ToString(), "Error");
                    throw;
                }
                finally
                {
                    SupplierAddMode = String.Empty;
                    dgSupplier.DataSource = new IMEEntities().Suppliers.ToList();
                    EnableGeneralInput(false);
                    EnableAddressInput(false);
                    EnableContactInput(false);
                    EnableBankAccountInput(false);

                    BringSupplierList(txtSearch.Text);

                    btnAdd.Text = SupplierModeAdd;
                    btnModify.Text = SupplierModeModify;
                }
            }
        }

        private void EnableGeneralInput(bool state)
        {
            txtWeb.Enabled = state;
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
            cmbMainContact.Enabled = state;

            cmbAccountRep.Enabled = state;
            cmbAccountTerms.Enabled = state;
            cmbAccountMethod.Enabled = state;
            //txtDiscountRate.Enabled = state;
            cmbCurrency.Enabled = state;
            //cmbInvoiceCurrency.Enabled = state;
            //txtAccountNotes.Enabled = state;

            btnAddressAdd.Enabled = state;
            if(lbAddressList.Items.Count > 0)
            {
                btnAddressUpdate.Enabled = state;
                btnAddressDelete.Enabled = state;
            }

            btnContactNew.Enabled = state;
            if (lbContacts.Items.Count > 0)
            {
                btnContactUpdate.Enabled = state;
                btnContactDelete.Enabled = state;
            }

            txtAccountTitle.Enabled = state;
            txtBankBranchCode.Enabled = state;
            txtBankAccountNumber.Enabled = state;
            txtBankIban.Enabled = state;
            if (!state)
            {
                cmbCountry.SelectedIndex = 0;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            switch (btnModify.Text)
            {
                case "Modify":
                    SupplierAddMode = SupplierModeModify;
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
                    ClearGeneralInputs();
                    ClearAddressInputs();
                    ClearContactInputs();

                    if (SupplierAddMode == "Add")
                    {
                        dgSupplier.ClearSelection();
                    }
                    else
                    {
                        FillSupplierInfo(dgSupplier.CurrentRow.Cells[dgID.Index].Value.ToString());
                        lbAddressList.Enabled = true;
                        lbContacts.Enabled = true;

                    }
                    AddressButtonsMode(AddressButtonsModeClose);
                    ContactButtonsMode(ContactButtonsModeClose);

                    EnableAddressInput(false);
                    EnableContactInput(false);
                    EnableBankAccountInput(false);
                    EnableGeneralInput(false);
                    EnableGeneralInput(false);
                    btnAdd.Text = "Add";
                    btnModify.Text = "Modify";
                    SupplierAddMode = String.Empty;


                    break;
                default:

                    break;
            }
        }

        private void dgSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SavedAddresses.Clear();
            SavedContacts.Clear();
            FillSupplierInfo(dgSupplier.Rows[e.RowIndex].Cells[dgID.Index].Value.ToString());
        }

        private void FillSupplierInfo(string SupplierID)
        {
            Supplier s = gridSupplierList.Where(x=>x.ID == SupplierID).FirstOrDefault();

            txtSupplierCode.Text = s.ID;
            txtName.Text = s.s_name;
            txtTaxOffice.Text = s.taxoffice;
            txtTaxNumber.Text = s.taxnumber;
            //txtDiscountRate.Text = s.discountrate.ToString();
            

            txtWeb.Text = s.webadress ?? String.Empty;
            txtSupplierNotes.Text = (s.Note1 != null) ? s.Note1.Note_name : String.Empty;
            //txtAccountNotes.Text = (s.Note != null) ? s.Note.Note_name : String.Empty;

            cmbContactAddress.DataSource = s.SupplierAddresses.ToList();
            cmbContactAddress.DisplayMember = "Title";

            cmbMainContact.DisplayMember = "sw_name";
            cmbMainContact.DataSource = s.SupplierWorkers.ToList();

            string name = s.Worker1.NameLastName;
            cmbRepresentative.SelectedIndex = cmbRepresentative.FindStringExact(name);

            name = s.SupplierCategory.categoryname;
            cmbMainCategory.SelectedIndex = cmbMainCategory.FindStringExact(name);

            name = s.SupplierSubCategory.subcategoryname;
            cmbSubCategory.SelectedIndex = cmbSubCategory.FindStringExact(name);

            name = s.Worker.NameLastName;
            cmbAccountRep.SelectedIndex = cmbAccountRep.FindString(name);

            name = s.PaymentTerm.term_name;
            cmbAccountTerms.SelectedIndex = cmbAccountTerms.FindString(name);

            name = s.PaymentMethod.Payment;
            cmbAccountMethod.SelectedIndex = cmbAccountMethod.FindString(name);

            name = s.Currency.currencyName;
            cmbCurrency.SelectedIndex = cmbCurrency.FindStringExact(name);

            //name = s.SupplierBank.bankname;
            //txtAccountTitle.SelectedIndex = txtAccountTitle.FindStringExact(name);

            name = s.SupplierWorker.sw_name;
            cmbMainContact.SelectedIndex = cmbMainContact.FindStringExact(name);

            SavedAddresses.Clear();
            foreach (SupplierAddress sa in s.SupplierAddresses)
            {
                SavedAddresses.Add(sa);
            }
            lbAddressList.DataSource = null;
            lbAddressList.DataSource = SavedAddresses;
            lbAddressList.DisplayMember = "Title";
            lbAddressList.ClearSelected();
            lbAddressList.Enabled = true;

            SavedContacts.Clear();
            foreach (SupplierWorker sw in s.SupplierWorkers)
            {
                SavedContacts.Add(sw);
            }
            lbContacts.DataSource = null;
            lbContacts.DataSource = SavedContacts;
            lbContacts.DisplayMember = "sw_name";
            lbContacts.ClearSelected();
            lbContacts.Enabled = true;
        }

        private void ClearGeneralInputs()
        {
            txtSupplierCode.Clear();
            cmbRepresentative.SelectedIndex = 0;
            txtName.Clear();
            cmbMainCategory.SelectedIndex = 0;
            txtTaxOffice.Clear();
            txtWeb.Clear();
            txtSupplierNotes.Clear();
            txtTaxNumber.Clear();

            cmbAccountRep.SelectedIndex = 0;
            cmbAccountTerms.SelectedIndex = 0;
            cmbAccountMethod.SelectedIndex = 0;
            //txtDiscountRate.Clear();
            cmbCurrency.SelectedIndex = 0;
        }

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
                    if (SupplierAddMode == String.Empty)
                    {
                        cmbSubCategory.Enabled = false;
                        btnSubCategoryAdd.Enabled = false;
                    }
                    else
                    {
                        cmbSubCategory.Enabled = true;
                        btnSubCategoryAdd.Enabled = true;
                    }
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







        private void EnableAddressInput(bool state)
        {
            txtAddressTitle.Enabled = state;
            txtPhone.Enabled = state;
            txtFax.Enabled = state;
            txtPoBox.Enabled = state;
            cmbCountry.Enabled = state;
            txtPostCode.Enabled = state;
            txtAddressDetail.Enabled = state;
            if (SupplierAddMode == String.Empty)
            {
                lbAddressList.Enabled = state;
            }
            else
            {
                lbAddressList.Enabled = !state;
            }
            if (state && cmbCountry.SelectedIndex > 0)
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
                if (SupplierAddMode == String.Empty)
                {
                    btnAddressAdd.Enabled = state;
                }
                btnAddressUpdate.Enabled = state;
                btnAddressDelete.Enabled = state;
            }
        }

        private void cmbCounrty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCountry.Items.Count != 0)
            {
                if (cmbCountry.SelectedIndex > 0)
                {
                    int id = ((Country)cmbCountry.SelectedItem).ID;

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

        private void btnAddressAdd_Click(object sender, EventArgs e)
        {
            btnNewAddress();
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
            ClearAddressInputs();

            EnableAddressInput(false);
            AddressButtonsMode(AddressButtonsModeClose);

            ManageDeleteAndModifyButtons(lbAddressList, btnAddressUpdate, btnAddressDelete);
            AddressMode = String.Empty;

        }

        private void ClearAddressInputs()
        {
            txtAddressTitle.Clear();
            txtPhone.Clear();
            txtFax.Clear();
            txtPoBox.Clear();
            cmbCountry.SelectedIndex = 0;
            txtPostCode.Clear();
            txtAddressDetail.Clear();
            if (SupplierAddMode == String.Empty)
            {
                SavedAddresses.Clear();
            }
        }

        private void btnAddressDone_Click(object sender, EventArgs e)
        {
            if (!InputErrorExist(EmptyCheckTypeAddress))
            {
                if (AddressMode == "Add")
                {
                    SupplierAddress address = new SupplierAddress
                    {
                        Title = txtAddressTitle.Text,
                        Phone = txtPhone.Text,
                        Fax = (txtFax.Text != String.Empty) ? txtFax.Text : null,
                        CountryID = ((Country)cmbCountry.SelectedItem).ID,
                        CityID = ((City)cmbCity.SelectedItem).ID,
                        TownID = ((Town)cmbTown.SelectedItem).ID,
                        PoBox = txtPoBox.Text,
                        PostCode = txtPostCode.Text,
                        AdressDetails = txtAddressDetail.Text,
                        SupplierID = txtSupplierCode.Text
                    };


                    SavedAddresses.Add(address);

                    cmbContactAddress.DataSource = null;
                    cmbContactAddress.DataSource = SavedAddresses;
                    cmbContactAddress.DisplayMember = "Title";
                    cmbContactAddress.SelectedIndex = -1;
                }
                else if (AddressMode == "Update")
                {
                    SupplierAddress s = (SupplierAddress)lbAddressList.SelectedItem;
                    SupplierAddress address = SavedAddresses.Where(x => x.Title == s.Title).FirstOrDefault();

                    address.Title = txtAddressTitle.Text;
                    address.Phone = txtPhone.Text;
                    address.Fax = (txtFax.Text != String.Empty) ? txtFax.Text : null;
                    address.CountryID = ((Country)cmbCountry.SelectedItem).ID;
                    address.CityID = ((City)cmbCity.SelectedItem).ID;
                    address.TownID = ((Town)cmbTown.SelectedItem).ID;
                    address.PoBox = txtPoBox.Text;
                    address.PostCode = txtPostCode.Text;
                    address.AdressDetails = txtAddressDetail.Text;
                }

                lbAddressList.DataSource = null;
                lbAddressList.DataSource = SavedAddresses;
                lbAddressList.DisplayMember = "Title";
                lbAddressList.SelectedIndex = -1;

                cmbContactAddress.DataSource = null;
                cmbContactAddress.DataSource = SavedAddresses;
                cmbContactAddress.DisplayMember = "Title";
                cmbContactAddress.SelectedIndex = -1;

                btnAddressCancel.PerformClick();
                lbAddressList.Enabled = true;

                cmbCity.Enabled = false;
                cmbTown.Enabled = false;

                ManageDeleteAndModifyButtons(lbAddressList, btnAddressUpdate, btnAddressDelete);
                AddressMode = String.Empty;
            }
        }

        private void ManageDeleteAndModifyButtons(ListBox lb, Button btnUpdate, Button btnDelete)
        {
            bool state = false;
            if(lb.Items.Count != 0)
            {
                state = true;
            }
            btnUpdate.Enabled = state;
            btnDelete.Enabled = state;
        }

        private void btnAddressUpdate_Click(object sender, EventArgs e)
        {
            if (lbAddressList.SelectedIndex != -1)
            {
                AddressMode = "Update";

                EnableAddressInput(true);
                AddressButtonsMode(AddressButtonsModeOpen);
            }
            else
            {
                MessageBox.Show("Please choose an address from the list!", "Warning");
            }
        }

        private void btnAddressDelete_Click(object sender, EventArgs e)
        {
            if (lbAddressList.SelectedIndex != -1)
            {
                SupplierAddress sa = (SupplierAddress)lbAddressList.SelectedItem;
                if(sa.SupplierWorkers.Count != 0)
                {
                    MessageBox.Show("This address is matched with a contact, please modify it first!", "Warning");
                }
                else
                {
                    SavedAddresses.Remove(sa);

                    ClearAddressInputs();

                    EnableAddressInput(false);
                    AddressButtonsMode(AddressButtonsModeClose);
                    ManageDeleteAndModifyButtons(lbAddressList, btnAddressUpdate, btnAddressDelete);

                    lbAddressList.ClearSelected();
                }
            }
            else
            {
                MessageBox.Show("Please choose an address from the list!", "Warning");
            }


        }

        private void lbAddressList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAddressList.SelectedIndex >= 0)
            {
                AddressFill((SupplierAddress)lbAddressList.SelectedItem);
            }
        }

        private void AddressFill(SupplierAddress address)
        {
            txtAddressTitle.Text = address.Title;
            txtPhone.Text = address.Phone;
            txtFax.Text = (address.Fax != null) ? address.Fax : String.Empty;
            txtPoBox.Text = address.PoBox.ToString();
            txtPostCode.Text = address.PostCode;
            txtAddressDetail.Text = address.AdressDetails;

            var list = cmbCountry.Items.Cast<object>().ToList();
            list.RemoveAt(0);
            string CountryName = list.Cast<Country>().Where(x => x.ID == address.CountryID).FirstOrDefault().Country_name;
            cmbCountry.SelectedIndex = cmbCountry.FindStringExact(CountryName);


            list = cmbCity.Items.Cast<object>().ToList();
            list.RemoveAt(0);
            string CityName = list.Cast<City>().Where(x => x.ID == address.CityID).FirstOrDefault().City_name;
            cmbCity.SelectedIndex = cmbCity.FindStringExact(CityName);
            cmbCity.Enabled = txtAddressTitle.Enabled;


            list = cmbTown.Items.Cast<object>().ToList();
            list.RemoveAt(0);
            string TownName = list.Cast<Town>().Where(x => x.ID == address.TownID).FirstOrDefault().Town_name;
            cmbTown.SelectedIndex = cmbTown.FindStringExact(TownName);
            cmbTown.Enabled = txtAddressTitle.Enabled;

            list = null;
        }

        private void EnableContactInput(bool state)
        {
            txtContactName.Enabled = state;
            txtContactPhone.Enabled = state;
            txtExternalNumber.Enabled = state;
            txtContactMail.Enabled = state;
            cmbDepartment.Enabled = state;
            txtContactMobile.Enabled = state;
            txtContactFax.Enabled = state;
            cmbLanguage.Enabled = state;
            cmbContactAddress.Enabled = state;
            txtContactNotes.Enabled = state;
            if (SupplierAddMode == String.Empty)
            {
                lbContacts.Enabled = state;
            }
            else
            {
                lbContacts.Enabled = !state;
            }
            if (state && cmbDepartment.SelectedIndex > 0)
            {
                cmbPosition.Enabled = true;
            }
            else
            {
                cmbPosition.Enabled = false;
            }
            if (state)
            {
                if (lbContacts.Items.Count > 0)
                {
                    btnContactUpdate.Enabled = state;
                    btnContactDelete.Enabled = state;
                }
                else
                {
                    btnContactUpdate.Enabled = !state;
                    btnContactDelete.Enabled = !state;
                }
            }
            else
            {
                if (SupplierAddMode == String.Empty)
                {
                    btnContactNew.Enabled = state;
                }
                btnContactUpdate.Enabled = state;
                btnContactDelete.Enabled = state;
            }


        }

        //private void cmbDep_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbCountry.Items.Count != 0)
        //    {
        //        if (cmbCountry.SelectedIndex > 0)
        //        {
        //            int id = ((Country)cmbCountry.SelectedItem).ID;

        //            cmbCity.Items.Clear();
        //            cmbCity.DisplayMember = "City_name";
        //            cmbCity.Items.AddRange(new IMEEntities().Cities.Where(x => x.CountryID == id).ToArray());
        //            cmbCity.Items.Insert(0, "Choose");
        //            cmbCity.SelectedIndex = 0;

        //            cmbCity.Enabled = true;
        //        }
        //        else
        //        {
        //            if (cmbCity.Items.Count != 0)
        //            {
        //                cmbCity.SelectedIndex = 0;
        //            }
        //            cmbCity.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        cmbCity.Enabled = true;
        //    }
        //}

        //private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbCity.Items.Count != 0)
        //    {
        //        if (cmbCity.SelectedIndex > 0)
        //        {
        //            int id = ((City)cmbCity.SelectedItem).ID;

        //            cmbTown.Items.Clear();
        //            cmbTown.DisplayMember = "Town_name";
        //            cmbTown.Items.AddRange(new IMEEntities().Towns.Where(x => x.CityID == id).ToArray());
        //            cmbTown.Items.Insert(0, "Choose");
        //            cmbTown.SelectedIndex = 0;

        //            cmbTown.Enabled = true;
        //        }
        //        else
        //        {

        //            if (cmbTown.Items.Count != 0)
        //            {
        //                cmbTown.SelectedIndex = 0;
        //            }
        //            cmbTown.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        cmbTown.Enabled = true;
        //    }
        //}

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

        private void btnContactNew_Click(object sender, EventArgs e)
        {
            btnNewContact();
        }

        private void ContactButtonsMode(string Mode)
        {
            if (Mode == ContactButtonsModeOpen)
            {
                btnContactNew.Visible = false;
                btnContactUpdate.Visible = false;
                btnContactDelete.Visible = false;
                btnContactDone.Visible = true;
                btnContactCancel.Visible = true;
            }
            else if (Mode == ContactButtonsModeClose)
            {
                btnContactNew.Visible = true;
                btnContactUpdate.Visible = true;
                btnContactDelete.Visible = true;
                btnContactDone.Visible = false;
                btnContactCancel.Visible = false;
            }
        }

        //private void BankAccountButtonsMode(string Mode)
        //{
        //    if (Mode == BankAccountButtonsModeOpen)
        //    {
        //        btnBankAdd.Enabled = true;
        //        btnBankUpdate.Enabled = true;
        //        btnBankDelete.Enabled = true;

        //        btnBankAdd.Text = "Add";

        //        btnContactNew.Visible = false;
        //        btnContactUpdate.Visible = false;
        //        btnContactDelete.Visible = false;
        //        btnContactDone.Visible = true;
        //        btnContactCancel.Visible = true;
        //    }
        //    else if (Mode == BankAccountButtonsModeClose)
        //    {
        //        btnBankAdd.Enabled = true;
        //        btnBankUpdate.Enabled = true;
        //        btnBankDelete.Enabled = true;

        //        btnBankAdd.Text = "Add";
        //        btnBankUpdate.Text = "Update;"
        //    }
        //}

        private void btnContactCancel_Click(object sender, EventArgs e)
        {
            ClearContactInputs();

            EnableContactInput(false);
            ContactButtonsMode(ContactButtonsModeClose);

            ManageDeleteAndModifyButtons(lbContacts, btnContactUpdate, btnContactDelete);
            ContactMode = String.Empty;

        }

        private void ClearContactInputs()
        {
            txtContactName.Clear();
            txtContactPhone.Clear();
            txtExternalNumber.Clear();
            txtContactMail.Clear();
            txtContactFax.Clear();
            txtContactMobile.Clear();
            cmbDepartment.SelectedIndex = 0;
            cmbLanguage.SelectedIndex = 0;
            cmbContactAddress.SelectedIndex = -1;
            txtContactNotes.Clear();
            if (SupplierAddMode == String.Empty)
            {
                SavedContacts.Clear();
            }
        }

        private void btnContactDone_Click(object sender, EventArgs e)
        {
            if (!InputErrorExist(EmptyCheckTypeContact))
            {
                if (ContactMode == "Add")
                {
                    SupplierWorker worker = new SupplierWorker
                    {
                        supplierID = txtSupplierCode.Text,
                        sw_name = txtContactName.Text,
                        phone = txtContactPhone.Text,
                        languageID = ((Language)cmbLanguage.SelectedItem).ID,
                        PhoneExternalNum = (txtExternalNumber.Text != String.Empty) ? txtExternalNumber.Text : null,
                        sw_email = (txtContactMail.Text != String.Empty) ? txtContactMail.Text : null,
                        fax = (txtContactFax.Text != String.Empty) ? txtContactFax.Text : null,
                        mobilephone = (txtContactMobile.Text != String.Empty) ? txtContactMobile.Text : null
                    };

                    if (cmbDepartment.SelectedIndex > 0) { worker.departmentID = ((CustomerDepartment)cmbDepartment.SelectedItem).ID; }
                    if (cmbPosition.SelectedIndex > 0) { worker.titleID = ((CustomerTitle)cmbPosition.SelectedItem).ID; }
                    if (cmbContactAddress.SelectedIndex >= 0) { worker.SupplierAddress = (SupplierAddress)cmbContactAddress.SelectedItem; }

                    if (txtContactNotes.Text != String.Empty)
                    {
                        Note n = new Note();
                        n.Note_name = txtContactNotes.Text;
                        worker.Note = n;
                    }
                    SavedContacts.Add(worker);
                }
                else if (ContactMode == "Update")
                {
                    SupplierWorker worker = (SupplierWorker)lbContacts.SelectedItem;
                    SupplierWorker address = SavedContacts.Where(x => x.sw_name == worker.sw_name).FirstOrDefault();

                    worker.sw_name = txtContactName.Text;
                    if (cmbDepartment.SelectedIndex > 0) { worker.departmentID = ((CustomerDepartment)cmbDepartment.SelectedItem).ID; }
                    worker.phone = txtContactPhone.Text;
                    if (cmbPosition.SelectedIndex > 0) { worker.titleID = ((CustomerTitle)cmbPosition.SelectedItem).ID; }
                    worker.PhoneExternalNum = (txtExternalNumber.Text != String.Empty) ? txtExternalNumber.Text : null;
                    worker.sw_email = (txtContactMail.Text != String.Empty) ? txtContactMail.Text : null;
                    worker.fax = (txtContactFax.Text != String.Empty) ? txtContactFax.Text : null;
                    worker.mobilephone = (txtContactMobile.Text != String.Empty) ? txtContactMobile.Text : null;
                    worker.languageID = ((Language)cmbLanguage.SelectedItem).ID;
                    if (cmbContactAddress.SelectedIndex >= 0) { worker.SupplierAddress = (SupplierAddress)cmbContactAddress.SelectedItem; }

                    if (worker.Note != null)
                    {
                        worker.Note.Note_name = txtContactNotes.Text;
                    }
                    else
                    {
                        Note n = new Note();
                        n.Note_name = txtContactNotes.Text;
                        worker.Note = n;
                    }
                }

                lbContacts.DataSource = null;
                lbContacts.DataSource = SavedContacts;
                lbContacts.DisplayMember = "sw_name";
                lbContacts.SelectedIndex = -1;

                cmbMainContact.DataSource = null;
                cmbMainContact.DataSource = SavedContacts;
                cmbMainContact.DisplayMember = "sw_name";
                cmbMainContact.SelectedIndex = -1;

                btnContactCancel.PerformClick();
                lbContacts.Enabled = true;

                cmbPosition.Enabled = false;

                ManageDeleteAndModifyButtons(lbContacts, btnContactUpdate, btnContactDelete);
                ContactMode = String.Empty;
            }
        }

        private void btnContactUpdate_Click(object sender, EventArgs e)
        {
            if (lbContacts.SelectedIndex != -1)
            {
                ContactMode = "Update";

                EnableContactInput(true);
                ContactButtonsMode(ContactButtonsModeOpen);
            }
            else
            {
                MessageBox.Show("Please choose an contact from the list!", "Warning");
            }
        }

        private void btnContactDelete_Click(object sender, EventArgs e)
        {
            if (lbContacts.SelectedIndex != -1)
            {
                SupplierWorker sw = (SupplierWorker)lbContacts.SelectedItem;
                SavedContacts.Remove(sw);

                ClearContactInputs();

                EnableContactInput(false);
                ContactButtonsMode(ContactButtonsModeClose);
                ManageDeleteAndModifyButtons(lbContacts, btnContactUpdate, btnContactDelete);

                lbContacts.ClearSelected();
            }
            else
            {
                MessageBox.Show("Please choose an contact from the list!", "Warning");
            }
        }

        private void lbContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbContacts.SelectedIndex >= 0)
            {
                ContactFill((SupplierWorker)lbContacts.SelectedItem);
            }
        }

        private void ContactFill(SupplierWorker worker)
        {
            var list = cmbDepartment.Items.Cast<object>().ToList();
            list.RemoveAt(0);
            string DepartmentName = (worker.departmentID != null) ? (list.Cast<CustomerDepartment>().Where(x => x.ID == worker.departmentID).FirstOrDefault().departmentname) : "Choose";
            cmbDepartment.SelectedIndex = cmbDepartment.FindStringExact(DepartmentName);

            list = cmbPosition.Items.Cast<object>().ToList();
            if(list.Count > 1)
            {
                list.RemoveAt(0);
                string PositionName = (worker.titleID != null) ? (list.Cast<CustomerTitle>().Where(x => x.ID == worker.titleID).FirstOrDefault().titlename) : "Choose";
                cmbPosition.SelectedIndex = cmbPosition.FindStringExact(PositionName);
                cmbPosition.Enabled = txtContactName.Enabled;
                btnPos.Enabled = txtContactName.Enabled;
            }

            list = lbAddressList.Items.Cast<object>().ToList();
            string AddressTitle = (worker.SupplierAddress != null) ? (list.Cast<SupplierAddress>().Where(x => x.Title == worker.SupplierAddress.Title).FirstOrDefault().Title) : String.Empty;
            cmbContactAddress.SelectedIndex = (AddressTitle != String.Empty) ? cmbContactAddress.FindStringExact(AddressTitle) : -1;

            list = cmbLanguage.Items.Cast<object>().ToList();
            list.RemoveAt(0);
            string Language = list.Cast<Language>().Where(x => x.ID == worker.languageID).FirstOrDefault().languagename;
            cmbLanguage.SelectedIndex = cmbLanguage.FindStringExact(Language);

            list = null;

            txtContactName.Text = worker.sw_name;
            txtContactPhone.Text = worker.phone;
            txtExternalNumber.Text = worker.PhoneExternalNum;
            txtContactMail.Text = worker.sw_email;
            txtContactFax.Text = worker.fax;
            txtContactMobile.Text = worker.mobilephone;
            txtContactNotes.Text = (worker.Note != null) ? worker.Note.Note_name : String.Empty;
        }
        private bool InputErrorExist(string type)
        {
            List<string> ErrorLog = new List<string>();

            switch (type)
            {
                #region Contact
                case "Contact":
                    if (txtContactName.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Name must not be empty!");
                    }
                    else if (Utils.HasNumbersIn(txtContactName.Text))
                    {
                        ErrorLog.Add("Name should not contain numbers!");
                    }

                    if (txtContactPhone.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Phone must not be empty!");
                    }
                    else if (!Utils.HasOnlyNumbers(txtContactPhone.Text))
                    {
                        ErrorLog.Add("The Phone number must be a numerical string!");
                    }

                    //if (txtContactMobile.Text.Trim() != String.Empty && !Utils.HasOnlyNumbers(txtContactMobile.Text))
                    //{
                    //    ErrorLog.Add("The Mobile number must be a numerical string!");
                    //}

                    //if (txtContactFax.Text.Trim() != String.Empty && !Utils.HasOnlyNumbers(txtContactFax.Text))
                    //{
                    //    ErrorLog.Add("The Fax number must be a numerical string!");
                    //}

                    //if (txtExternalNumber.Text.Trim() != String.Empty && !Utils.HasOnlyNumbers(txtExternalNumber.Text))
                    //{
                    //    ErrorLog.Add("The Extension number must be a numerical string!");
                    //}

                    if (cmbLanguage.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose a Communication Language!");
                    }


                    string ErrorStringContact = String.Empty;
                    for (int i = 0; i < ErrorLog.Count; i++)
                    {
                        ErrorStringContact += ErrorLog[i];
                        if (i != ErrorLog.Count - 1)
                        {
                            ErrorStringContact += "\n";
                        }
                    }

                    if (ErrorLog.Count != 0)
                    {
                        MessageBox.Show(ErrorStringContact, "Empty Areas");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                #endregion
                #region Address
                case "Address":

                    //if (txtExternalNumber.Text.Trim() != String.Empty && !Utils.HasOnlyNumbers(txtExternalNumber.Text))
                    //{
                    //    ErrorLog.Add("The Extension number must be a numerical string!");
                    //}

                    if (txtAddressTitle.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Title must not be empty!");
                    }

                    if (txtPhone.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Phone must not be empty!");
                    }
                    else if (!Utils.HasOnlyNumbers(txtPhone.Text))
                    {
                        ErrorLog.Add("The Phone number must be a numerical string!");
                    }

                    //if (txtFax.Text.Trim() != String.Empty && !Utils.HasOnlyNumbers(txtFax.Text))
                    //{
                    //    ErrorLog.Add("The Fax number must be a numerical string!");
                    //}

                    //if (txtPoBox.Text.Trim() == String.Empty)
                    //{
                    //    ErrorLog.Add("P.O.Box must not be empty!");
                    //}

                    if (txtPostCode.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Post Code must not be empty!");
                    }

                    if (txtAddressDetail.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Address details must not be empty!");
                    }

                    if (cmbCountry.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose a Country!");
                    }
                    if (cmbCity.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose a City!");
                    }
                    if (cmbTown.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose a Town!");
                    }

                    string ErrorStringAddress = String.Empty;
                    for (int i = 0; i < ErrorLog.Count; i++)
                    {
                        ErrorStringAddress += ErrorLog[i];
                        if (i != ErrorLog.Count - 1)
                        {
                            ErrorStringAddress += "\n";
                        }
                    }

                    if (ErrorLog.Count != 0)
                    {
                        MessageBox.Show(ErrorStringAddress, "Empty Areas");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                #endregion
                #region BankAccount
                case "BankAccount":
                    if (txtAccountTitle.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Account title must not be empty!");
                    }

                    if (txtBankIban.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("IBAN must not be empty!");
                    }


                    string ErrorStringBankAccount = String.Empty;
                    for (int i = 0; i < ErrorLog.Count; i++)
                    {
                        ErrorStringBankAccount += ErrorLog[i];
                        if (i != ErrorLog.Count - 1)
                        {
                            ErrorStringBankAccount += "\n";
                        }
                    }

                    if (ErrorLog.Count != 0)
                    {
                        MessageBox.Show(ErrorStringBankAccount, "Empty Areas");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                #endregion
                #region General
                case "General":
                    if (cmbRepresentative.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose a Representative!");
                    }
                    if (txtName.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Name must not be empty!");
                    }
                    if (cmbMainCategory.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose a Main Category!");
                    }
                    if (cmbSubCategory.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose a Sub Category!");
                    }
                    if (txtTaxOffice.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Tax Office must not be empty!");
                    }
                    if (txtTaxNumber.Text.Trim() == String.Empty)
                    {
                        ErrorLog.Add("Tax Number must not be empty!");
                    }
                    else if (!Utils.HasOnlyNumbers(txtTaxNumber.Text))
                    {
                        ErrorLog.Add("Tax Number must be a numerical string!");
                    }

                    if (cmbMainContact.SelectedIndex < 0)
                    {
                        ErrorLog.Add("You should choose a Main Contact!");
                    }

                    if (cmbAccountRep.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose an Account Representative!");
                    }

                    if (cmbAccountTerms.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose a Terms of Payment!");
                    }

                    //if (cmbAccountMethod.SelectedIndex <= 0)
                    //{
                    //    ErrorLog.Add("You should choose a Payment Method!");
                    //}

                    //decimal rate;
                    //if (txtDiscountRate.Text.Trim() == String.Empty)
                    //{
                    //    ErrorLog.Add("Discount Rate must not be empty!");
                    //}
                    //else if (!Decimal.TryParse(txtDiscountRate.Text,out rate))
                    //{
                    //    ErrorLog.Add("Discount rate must be a numerical string!");
                    //}

                    if (cmbCurrency.SelectedIndex <= 0)
                    {
                        ErrorLog.Add("You should choose a Currency!");
                    }
                    if (lbAddressList.Items.Count <= 0)
                    {
                        ErrorLog.Add("You should add at least one Address!");
                    }
                    if (lbContacts.Items.Count <= 0)
                    {
                        ErrorLog.Add("You should add at least Contact!");
                    }


                    string ErrorStringGeneral = String.Empty;
                    for (int i = 0; i < ErrorLog.Count; i++)
                    {
                        ErrorStringGeneral += ErrorLog[i];
                        if (i != ErrorLog.Count - 1)
                        {
                            ErrorStringGeneral += "\n";
                        }
                    }

                    if (ErrorLog.Count != 0)
                    {
                        MessageBox.Show(ErrorStringGeneral, "Empty Areas");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                #endregion
                default:
                    return false;
            }
        }
        private void MakeTextUpperCase(TextBox txtBox)
        {
            txtBox.Text = txtBox.Text.ToUpperInvariant();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            MakeTextUpperCase((TextBox)sender);
        }

        private void txtTaxOffice_Leave(object sender, EventArgs e)
        {
            MakeTextUpperCase((TextBox)sender);
        }

        private void txtAddressTitle_Leave(object sender, EventArgs e)
        {
            MakeTextUpperCase((TextBox)sender);
        }

        private void txtContactName_Leave(object sender, EventArgs e)
        {
            MakeTextUpperCase((TextBox)sender);
        }

        private void dgSupplier_DoubleClick(object sender, EventArgs e)
        {
            if (fromBillFromCustomer)
            {
                IMEEntities IME = new IMEEntities();
                if (dgSupplier.CurrentRow != null)
                {
                    string SupplierID = "";
                    try { SupplierID = dgSupplier.CurrentRow.Cells[iDDataGridViewTextBoxColumn.Index].Value.ToString(); } catch { }
                    classSupplier.Supplier = IME.Suppliers.Where(a=>a.ID==SupplierID).FirstOrDefault();
                }
                else
                {
                    classSupplier.Supplier = null;
                }
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Close This Window?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnNewAddress()
        {
            AddressMode = "Add";
            lbAddressList.ClearSelected();
            lbAddressList.Enabled = false;

            ClearAddressInputs();
            EnableAddressInput(true);
            AddressButtonsMode(AddressButtonsModeOpen);
            ManageDeleteAndModifyButtons(lbAddressList, btnAddressUpdate, btnAddressDelete);
        }

        private void btnNewContact()
        {
            ContactMode = "Add";
            lbContacts.ClearSelected();
            lbContacts.Enabled = false;

            ClearContactInputs();
            EnableContactInput(true);
            ContactButtonsMode(ContactButtonsModeOpen);
            ManageDeleteAndModifyButtons(lbContacts, btnContactUpdate, btnContactDelete);
        }

        //private void btnLogoSave_Click(object sender, EventArgs e)
        //{
        //    logoSuppAdd();
        //}

        //private void logoSuppAdd()
        //{
        //    #region SupplierForLogo

        //    //string str = MyConnect.Ornekle.ExecuteScalar(Utils.ConnectionStringLogo, "SELECT CODE FROM L_COUNTRY WHERE LOGICALREF = " + this.cbCountry.SelectedValue._ToIntegerR(), CommandType.Text, 60, new KomutArgumanlari_[0]).ToString();
        //    if (/*this.GelenID*/0 == 0)
        //    {
        //        KomutArgumanlari_[] arguman = new KomutArgumanlari_[1];
        //        KomutArgumanlari_ i_1 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtSupplierCode.Text,
        //            ParametreAdi = "@param"
        //        };
        //        arguman[0] = i_1;
        //        if (MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("SELECT COUNT(*) FROM LG_{0}_CLCARD WHERE CODE = @param", Utils.FrmNo), CommandType.Text, 60, arguman) > 0)
        //        {
        //            string str3 = MyConnect.Ornekle.ExecuteScalar(Utils.ConnectionStringLogo, string.Format("SELECT MAX(CODE) FROM LG_{0}_CLCARD WHERE CODE LIKE 'SC%'", Utils.FrmNo), CommandType.Text, 60, new KomutArgumanlari_[0])._ToString();
        //            str3 = str3.Substring(0, 2) + (str3.Replace("SC", "")._ToIntegerR() + 1);
        //            this.txtSupplierCode.Text = str3;
        //        }

        //        int num = MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("select ISNULL(MAX(CL.LOWLEVELCODES1)+1,1) from LG_{0}_CLCARD AS CL", Utils.FrmNo), CommandType.Text, 60, new KomutArgumanlari_[0]);
        //        string str2 = (/*this.Nerden*/1 == 0) ? "'RS'" : "''";
        //        object[] objArray1 = new object[] { "INSERT INTO LG_{0}_CLCARD (ACTIVE, CARDTYPE, CODE, DEFINITION_, SPECODE, CYPHCODE, ADDR1, ADDR2, CITY, COUNTRY, POSTCODE, TELNRS1, TELNRS2, FAXNR, TAXNR, TAXOFFICE, INCHARGE, DISCRATE, EXTENREF, PAYMENTREF, EMAILADDR, WEBADDR, WARNMETHOD, WARNEMAILADDR, WARNFAXNR, CLANGUAGE, VATNR, BLOCKED, BANKBRANCHS1, BANKBRANCHS2, BANKBRANCHS3, BANKBRANCHS4, BANKBRANCHS5, BANKBRANCHS6, BANKBRANCHS7, BANKACCOUNTS1, BANKACCOUNTS2, BANKACCOUNTS3, BANKACCOUNTS4, BANKACCOUNTS5, BANKACCOUNTS6, BANKACCOUNTS7, DELIVERYMETHOD, DELIVERYFIRM, CCURRENCY, TEXTINC, SITEID, RECSTATUS, ORGLOGICREF, EDINO, TRADINGGRP, CAPIBLOCK_CREATEDBY, CAPIBLOCK_CREADEDDATE, CAPIBLOCK_CREATEDHOUR, CAPIBLOCK_CREATEDMIN, CAPIBLOCK_CREATEDSEC, CAPIBLOCK_MODIFIEDBY, CAPIBLOCK_MODIFIEDDATE, CAPIBLOCK_MODIFIEDHOUR, CAPIBLOCK_MODIFIEDMIN, CAPIBLOCK_MODIFIEDSEC, PAYMENTPROC, CRATEDIFFPROC, WFSTATUS, PPGROUPCODE, PPGROUPREF, TAXOFFCODE, TOWNCODE, TOWN, DISTRICTCODE, DISTRICT, CITYCODE, COUNTRYCODE, ORDSENDMETHOD, ORDSENDEMAILADDR, ORDSENDFAXNR, DSPSENDMETHOD, DSPSENDEMAILADDR, DSPSENDFAXNR, INVSENDMETHOD, INVSENDEMAILADDR, INVSENDFAXNR, SUBSCRIBERSTAT, SUBSCRIBEREXT, AUTOPAIDBANK, PAYMENTTYPE, LASTSENDREMLEV, EXTACCESSFLAGS, ORDSENDFORMAT, DSPSENDFORMAT, INVSENDFORMAT, REMSENDFORMAT, STORECREDITCARDNO, CLORDFREQ, ORDDAY, LOGOID, LIDCONFIRMED, EXPREGNO, EXPDOCNO, EXPBUSTYPREF, INVPRINTCNT, PIECEORDINFLICT, COLLECTINVOICING, EBUSDATASENDTYPE, INISTATUSFLAGS, SLSORDERSTATUS, SLSORDERPRICE, LTRSENDMETHOD, LTRSENDEMAILADDR, LTRSENDFAXNR, LTRSENDFORMAT, IMAGEINC, CELLPHONE, SAMEITEMCODEUSE, STATECODE, STATENAME, WFLOWCRDREF, PARENTCLREF, LOWLEVELCODES1, LOWLEVELCODES2, LOWLEVELCODES3, LOWLEVELCODES4, LOWLEVELCODES5, LOWLEVELCODES6, LOWLEVELCODES7, LOWLEVELCODES8, LOWLEVELCODES9, LOWLEVELCODES10, TELCODES1, TELCODES2, FAXCODE, PURCHBRWS, SALESBRWS, IMPBRWS, EXPBRWS, FINBRWS, ORGLOGOID, ADDTOREFLIST, TEXTREFTR, TEXTREFEN, ARPQUOTEINC, CLCRM, GRPFIRMNR, CONSCODEREF, SPECODE2, SPECODE3, SPECODE4, SPECODE5, OFFSENDMETHOD, OFFSENDEMAILADDR, OFFSENDFAXNR, OFFSENDFORMAT, EBANKNO, LOANGRPCTRL, BANKNAMES1, BANKNAMES2, BANKNAMES3, BANKNAMES4, BANKNAMES5, BANKNAMES6, BANKNAMES7, LDXFIRMNR, MAPID, LONGITUDE, LATITUTE, CITYID, TOWNID, BANKIBANS1, BANKIBANS2, BANKIBANS3, BANKIBANS4, BANKIBANS5, BANKIBANS6, BANKIBANS7, TCKNO, ISPERSCOMP, EXTSENDMETHOD, EXTSENDEMAILADDR, EXTSENDFAXNR, EXTSENDFORMAT, BANKBICS1, BANKBICS2, BANKBICS3, BANKBICS4, BANKBICS5, BANKBICS6, BANKBICS7, CASHREF, USEDINPERIODS, INCHARGE2, INCHARGE3, EMAILADDR2, EMAILADDR3, RSKLIMCR, RSKDUEDATECR, RSKAGINGCR, RSKAGINGDAY, ACCEPTEINV, EINVOICEID, PROFILEID, BANKBCURRENCY1, BANKBCURRENCY2, BANKBCURRENCY3, BANKBCURRENCY4, BANKBCURRENCY5, BANKBCURRENCY6, BANKBCURRENCY7, PURCORDERSTATUS, PURCORDERPRICE, ISFOREIGN, SHIPBEGTIME1, SHIPBEGTIME2, SHIPBEGTIME3, SHIPENDTIME1, SHIPENDTIME2, SHIPENDTIME3, DBSLIMIT1, DBSLIMIT2, DBSLIMIT3, DBSLIMIT4, DBSLIMIT5, DBSLIMIT6, DBSLIMIT7, DBSTOTAL1, DBSTOTAL2, DBSTOTAL3, DBSTOTAL4, DBSTOTAL5, DBSTOTAL6, DBSTOTAL7, DBSBANKNO1, DBSBANKNO2, DBSBANKNO3, DBSBANKNO4, DBSBANKNO5, DBSBANKNO6, DBSBANKNO7, DBSRISKCNTRL1, DBSRISKCNTRL2, DBSRISKCNTRL3, DBSRISKCNTRL4, DBSRISKCNTRL5, DBSRISKCNTRL6, DBSRISKCNTRL7, DBSBANKCURRENCY1, DBSBANKCURRENCY2, DBSBANKCURRENCY3, DBSBANKCURRENCY4, DBSBANKCURRENCY5, DBSBANKCURRENCY6, DBSBANKCURRENCY7, BANKCORRPACC1, BANKCORRPACC2, BANKCORRPACC3, BANKCORRPACC4, BANKCORRPACC5, BANKCORRPACC6, BANKCORRPACC7, BANKVOEN1, BANKVOEN2, BANKVOEN3, BANKVOEN4, BANKVOEN5, BANKVOEN6, BANKVOEN7, EINVOICETYPE, DEFINITION2, TELEXTNUMS1, TELEXTNUMS2, FAXEXTNUM, FACEBOOKURL, TWITTERURL, APPLEID, SKYPEID, GLOBALID, GUID, DUEDATECOUNT, DUEDATELIMIT, DUEDATETRACK, DUEDATECONTROL1, DUEDATECONTROL2, DUEDATECONTROL3, DUEDATECONTROL4, DUEDATECONTROL5, DUEDATECONTROL6, DUEDATECONTROL7, DUEDATECONTROL8, DUEDATECONTROL9, DUEDATECONTROL10, DUEDATECONTROL11, DUEDATECONTROL12, DUEDATECONTROL13, DUEDATECONTROL14, DUEDATECONTROL15, ADRESSNO, POSTLABELCODE, SENDERLABELCODE, CLOSEDATECOUNT, CLOSEDATETRACK, DEGACTIVE, DEGCURR, NAME, SURNAME, LABELINFO, DEFBNACCREF, PROJECTREF, DISCTYPE) VALUES (0, ", 2, ", @Kodu, @Unvan, ", str2, ", @CYPHCODE, @Adres1, @Adres2, @CtName, @COUNTRY, @Pc, @Tel, '', @Fx, @Vn, @Vd, @Yetkili, 0, 0, @PAYMENTREF, @MailAdres, @WEBADDR, 0, '', '', 1, '', 0, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 0, 0, 0, 1, 0, '', '', 1, GETDATE(), DATEPART(hour, GETDATE()), DATEPART(minute, GETDATE()), DATEPART(second, GETDATE()), 0, NULL, 0, 0, 0, 0, 0, 0, '', 0, '', @TwC, @TwN, '', '', @CityCode, @COUNTRYCODE, 0, '', '', 0, '', '', 0, '', '', 0, '', '', 0, 0, 0, 0, 0, 0, 0, '', 1, 0, '', 0, '', '', 0, 1, 0, 0, 0, 0, 0, 0, 0, '', '', 0, 0, '', 0, '', '', 0, 0, {1}, 0, 0, 0, 0, 0, 0, 0, 0, 0, @AlanKodu, '', '', 1, 1, 1, 1, 1, '', 0, 0, 0, 0, 0, 0, 0, '', @Credit, @Indirim, @Temsilci, 0, '', '', 0, 0, 0, '', '', '', '', '', '', '', 0, '', '', '', '', '', '', '', '', '', '', '', '', '', 0, 0, '', '', 0, '', '', '', '', '', '', '', 0, 0, '', '', '', '', 0, 0, 0, 0, 0, '', 2, '', '', '', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', '', '', '', '', '', '', '', '', '', '', '', '', 0, '', @Dahili, '', '', '', '', '', '', '', NEWID(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', '', 0, 0, 0, 0, '', '', 0, 0, 0, 0); SELECT SCOPE_IDENTITY()" };
        //        KomutArgumanlari_[] i_Array2 = new KomutArgumanlari_[0x19];
        //        KomutArgumanlari_ i_2 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtSupplierCode.Text.ToUpper(),
        //            ParametreAdi = "@Kodu"
        //        };
        //        i_Array2[0] = i_2;
        //        KomutArgumanlari_ i_3 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtName.Text.ToUpper(),
        //            ParametreAdi = "@Unvan"
        //        };
        //        i_Array2[1] = i_3;
        //        KomutArgumanlari_ i_ = new KomutArgumanlari_
        //        {
        //            Parametre = (/*this.Nerden*/1 == 0) ? this.txtSupplierCode.Text.Split(new char[] { '-' })[0].ToString() : "0",
        //            ParametreAdi = "@CYPHCODE"
        //        };
        //        i_Array2[2] = i_;
        //        KomutArgumanlari_ i_4 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cmbCountry.Text,
        //            ParametreAdi = "@COUNTRY"
        //        };
        //        i_Array2[3] = i_4;
        //        KomutArgumanlari_ i_5 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cmbCountry.SelectedValue._ToIntegerR(),
        //            ParametreAdi = "@COUNTRYCODE"
        //        };
        //        i_Array2[4] = i_5;
        //        KomutArgumanlari_ i_6 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtAddress1.Text.ToUpper(),
        //            ParametreAdi = "@Adres1"
        //        };
        //        i_Array2[5] = i_6;
        //        KomutArgumanlari_ i_7 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtAddress2.Text.ToUpper(),
        //            ParametreAdi = "@Adres2"
        //        };
        //        i_Array2[6] = i_7;
        //        KomutArgumanlari_ i_8 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtPhone.Text,
        //            ParametreAdi = "@Tel"
        //        };
        //        i_Array2[7] = i_8;
        //        KomutArgumanlari_ i_9 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtFax.Text,
        //            ParametreAdi = "@Fx"
        //        };
        //        i_Array2[8] = i_9;
        //        KomutArgumanlari_ i_10 = new KomutArgumanlari_
        //        {
        //            Parametre = ((PaymentMethod)this.cmbAccountMethod.SelectedItem).ID,
        //            ParametreAdi = "@PAYMENTREF"
        //        };
        //        i_Array2[9] = i_10;
        //        KomutArgumanlari_ i_11 = new KomutArgumanlari_
        //        {
        //            Parametre = "",
        //            ParametreAdi = "@Yetkili"
        //        };
        //        i_Array2[10] = i_11;
        //        KomutArgumanlari_ i_12 = new KomutArgumanlari_
        //        {
        //            Parametre = (cmbMainContact.SelectedItem as SupplierWorker).sw_email,
        //            ParametreAdi = "@MailAdres"
        //        };
        //        i_Array2[11] = i_12;
        //        KomutArgumanlari_ i_13 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cmbCity.Text,
        //            ParametreAdi = "@CtName"
        //        };
        //        i_Array2[12] = i_13;
        //        KomutArgumanlari_ i_14 = new KomutArgumanlari_
        //        {
        //            Parametre = ((Worker)(this.cmbRepresentative.SelectedItem)).WorkerID,
        //            ParametreAdi = "@Temsilci"
        //        };
        //        i_Array2[13] = i_14;
        //        KomutArgumanlari_ i_15 = new KomutArgumanlari_
        //        {
        //            Parametre = "",
        //            ParametreAdi = "@Credit"
        //        };
        //        i_Array2[14] = i_15;
        //        KomutArgumanlari_ i_16 = new KomutArgumanlari_
        //        {
        //            Parametre = "",
        //            ParametreAdi = "@Indirim"
        //        };
        //        i_Array2[15] = i_16;
        //        KomutArgumanlari_ i_17 = new KomutArgumanlari_
        //        {
        //            Parametre = "",
        //            ParametreAdi = "@AlanKodu"
        //        };
        //        i_Array2[0x10] = i_17;
        //        KomutArgumanlari_ i_18 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtExternalNumber.Text,
        //            ParametreAdi = "@Dahili"
        //        };
        //        i_Array2[0x11] = i_18;
        //        KomutArgumanlari_ i_19 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtPostCode.Text,
        //            ParametreAdi = "@Pc"
        //        };
        //        i_Array2[0x12] = i_19;
        //        KomutArgumanlari_ i_20 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtTaxNumber.Text,
        //            ParametreAdi = "@Vn"
        //        };
        //        i_Array2[0x13] = i_20;
        //        KomutArgumanlari_ i_21 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cmbTown.SelectedValue._ToIntegerR(),
        //            ParametreAdi = "@TwC"
        //        };
        //        i_Array2[20] = i_21;
        //        KomutArgumanlari_ i_22 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cmbCity.SelectedValue._ToIntegerR(),
        //            ParametreAdi = "@CityCode"
        //        };
        //        i_Array2[0x15] = i_22;
        //        KomutArgumanlari_ i_23 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cmbTown.Text,
        //            ParametreAdi = "@TwN"
        //        };
        //        i_Array2[0x16] = i_23;
        //        KomutArgumanlari_ i_24 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtTaxOffice.Text.ToUpper(),
        //            ParametreAdi = "@Vd"
        //        };
        //        i_Array2[0x17] = i_24;
        //        KomutArgumanlari_ i_25 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtWeb.Text,
        //            ParametreAdi = "@WEBADDR"
        //        };
        //        i_Array2[0x18] = i_25;
        //        int num2 = MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format(string.Concat(objArray1), Utils.FrmNo, num), CommandType.Text, 60, i_Array2);
        //        if (num2 > 0)
        //        {

        //            MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_{1}_CLRNUMS (CLCARDREF, RISKTYPE, RISKOVER, PS, KC, RISKTOTAL, DESPRISKTOTAL, RISKLIMIT, RISKBALANCED, CEKRISKFACTOR, SENETRISKFACTOR, CEK0_DEBIT, CEK0_CREDIT, CEK1_DEBIT, CEK1_CREDIT, SENET0_DEBIT, SENET0_CREDIT, SENET1_DEBIT, SENET1_CREDIT, CEKCURR0_DEBIT, CEKCURR0_CREDIT, CEKCURR1_DEBIT, CEKCURR1_CREDIT, SENETCURR0_DEBIT, SENETCURR0_CREDIT, SENETCURR1_DEBIT, SENETCURR1_CREDIT, ORDRISKOVER, DESPRISKOVER, USEREPRISK, REPRISKTOTAL, REPDESPRISKTOTAL, REPRISKLIMIT, REPRISKBALANCED, REPPS, REPKC, ORDRISKTOTAL, ORDRISKTOTALSUGG, REPORDRISKTOTAL, REPORDRISKTOTALSUGG, RISKTYPES1, RISKTYPES2, RISKTYPES3, RISKTYPES4, RISKTYPES5, RISKTYPES6, RISKTYPES7, RISKTYPES8, RISKTYPES9, RISKTYPES10, RISKTYPES11, RISKTYPES12, RISKTYPES13, RISKTYPES14, RISKTYPES15, CSTCEKRISKFACTOR, CSTSENETRISKFACTOR, RISKGRPCONTROL, ACCRISKOVER, CSTCSRISKOVER, MYCSRISKOVER, RISKCTRLTYPE, ACCRISKTOTAL, REPACCRISKTOTAL, CSTCSRISKTOTAL, REPCSTCSRISKTOTAL, MYCSRISKTOTAL, REPMYCSRISKTOTAL, ACCRISKLIMIT, REPACCRISKLIMIT, CSTCSRISKLIMIT, REPCSTCSRISKLIMIT, MYCSRISKLIMIT, REPMYCSRISKLIMIT, DESPRISKLIMIT, REPDESPRISKLIMIT, ORDRISKLIMIT, REPORDRISKLIMIT, ORDRISKLIMITSUGG, REPORDRISKLIMITSUGG, ACCRSKBLNCED, REPACCRSKBLNCED, CSTCSRSKBLNCED, REPCSTCSRSKBLNCED, MYCSRSKBLNCED, REPMYCSRSKBLNCED, DESPRSKBLNCED, REPDESPRSKBLNCED, ORDRSKBLNCED, REPORDRSKBLNCED, ORDRSKBLNCEDSUG, REPORDRSKBLNCEDSUG, ORDRISKOVERSUGG, CSDOWNSRISK, CSTCSCIRORISKOVER, CSTCIROCEKRISKFAC, CSTCIROSENETRISKFAC, CSCIRODOWNSRISK, CSTCSCIRORISKLIMIT, REPCSTCSCIRORISKLIM, CSTCSCIRORSKBLNCED, REPCSTCSCIRORSKBLN, CSTCSOWNRISKTOTAL, REPCSTCSOWNRISKTOT, CSTCSCIRORISKTOTAL, REPCSTCSCIRORISKTOT, DESPRISKOVERSUG, DESPRISKLIMITSUG, REPDESPRISKLIMITSUG, DESPRISKTOTALSUG, REPDESPRISKTOTALSUG, DESPRSKBLNCEDSUG, REPDESPRSKBLNCEDSUG) VALUES ({2}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)", Utils.FrmNo, Utils.DnmNo, num2), CommandType.Text, 60, new KomutArgumanlari_[0]);
        //            MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_{1}_CLCOLLATRLRISK(CLCARDREF, RISKTYPE, RISKOVER, ORDRISKOVER, DESPRISKOVER, USEREPRISK, PCOLLATRLTOTAL, REPPCOLLATRLTOTAL, SCOLLATRLTOTAL, REPSCOLLATRLTOTAL, RISKTOTAL, REPRISKTOTAL, DESPRISKTOTAL, REPDESPRISKTOTAL, RISKLIMIT, REPRISKLIMIT, RISKBALANCED, REPRISKBALANCED, ORDRISKTOTAL, REPORDRISKTOTAL, ORDRISKTOTALSUGG, REPORDRISKTOTALSUGG) VALUES ({2}, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)", Utils.FrmNo, Utils.DnmNo, num2), CommandType.Text, 60, new KomutArgumanlari_[0]);

        //            if (DateTime.Now.Year > 0x7e0)
        //            {
        //                KomutArgumanlari_[] i_Array3 = new KomutArgumanlari_[14];
        //                KomutArgumanlari_ i_26 = new KomutArgumanlari_
        //                {
        //                    Parametre = num2,
        //                    ParametreAdi = "@CLIENTREF"
        //                };
        //                i_Array3[0] = i_26;
        //                KomutArgumanlari_ i_27 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.txtAddress1.Text.ToUpper(),
        //                    ParametreAdi = "@ADDR1"
        //                };
        //                i_Array3[1] = i_27;
        //                KomutArgumanlari_ i_28 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.txtAddress2.Text.ToUpper(),
        //                    ParametreAdi = "@ADDR2"
        //                };
        //                i_Array3[2] = i_28;
        //                KomutArgumanlari_ i_29 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.cmbCity.Text,
        //                    ParametreAdi = "@CITY"
        //                };
        //                i_Array3[3] = i_29;
        //                KomutArgumanlari_ i_30 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.cmbCountry.Text,
        //                    ParametreAdi = "@COUNTRY"
        //                };
        //                i_Array3[4] = i_30;
        //                KomutArgumanlari_ i_31 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.txtPostCode.Text,
        //                    ParametreAdi = "@POSTCODE"
        //                };
        //                i_Array3[5] = i_31;
        //                KomutArgumanlari_ i_32 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.txtPhone.Text,
        //                    ParametreAdi = "@TELNRS1"
        //                };
        //                i_Array3[6] = i_32;
        //                KomutArgumanlari_ i_33 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.txtFax.Text,
        //                    ParametreAdi = "@FAXNR"
        //                };
        //                i_Array3[7] = i_33;
        //                KomutArgumanlari_ i_34 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.cmbTown.SelectedValue._ToIntegerR(),
        //                    ParametreAdi = "@TOWNCODE"
        //                };
        //                i_Array3[8] = i_34;
        //                KomutArgumanlari_ i_35 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.cmbTown.Text,
        //                    ParametreAdi = "@TOWN"
        //                };
        //                i_Array3[9] = i_35;
        //                KomutArgumanlari_ i_36 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.cmbCity.SelectedValue._ToIntegerR(),
        //                    ParametreAdi = "@CITYCODE"
        //                };
        //                i_Array3[10] = i_36;
        //                KomutArgumanlari_ i_37 = new KomutArgumanlari_
        //                {
        //                    Parametre = this.cmbCountry.SelectedValue._ToIntegerR(),
        //                    ParametreAdi = "@COUNTRYCODE"
        //                };
        //                i_Array3[11] = i_37;
        //                KomutArgumanlari_ i_38 = new KomutArgumanlari_
        //                {
        //                    Parametre = (this.cmbMainContact.SelectedItem as SupplierWorker).sw_email,
        //                    ParametreAdi = "@EMAILADDR"
        //                };
        //                i_Array3[12] = i_38;
        //                KomutArgumanlari_ i_39 = new KomutArgumanlari_
        //                {
        //                    Parametre = "",
        //                    ParametreAdi = "@INCHANGE"
        //                };
        //                i_Array3[13] = i_39;
        //                MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_SHIPINFO (CLIENTREF, CODE, NAME, SPECODE, CYPHCODE, ADDR1, ADDR2, CITY, COUNTRY, POSTCODE, TELNRS1, TELNRS2, FAXNR, CAPIBLOCK_CREATEDBY, CAPIBLOCK_CREADEDDATE, CAPIBLOCK_CREATEDHOUR, CAPIBLOCK_CREATEDMIN, CAPIBLOCK_CREATEDSEC, CAPIBLOCK_MODIFIEDBY, CAPIBLOCK_MODIFIEDDATE, CAPIBLOCK_MODIFIEDHOUR, CAPIBLOCK_MODIFIEDMIN, CAPIBLOCK_MODIFIEDSEC, SITEID, RECSTATUS, ORGLOGICREF, TRADINGGRP, VATNR, TAXNR, TAXOFFICE, TOWNCODE, TOWN, DISTRICTCODE, DISTRICT, CITYCODE, COUNTRYCODE, ACTIVE, TEXTINC, EMAILADDR, INCHANGE, TELCODES1, TELCODES2, FAXCODE, LONGITUDE, LATITUTE, CITYID, TOWNID, SHIPBEGTIME1, SHIPBEGTIME2, SHIPBEGTIME3, SHIPENDTIME1, SHIPENDTIME2, SHIPENDTIME3, POSTLABELCODE, SENDERLABELCODE) VALUES (@CLIENTREF, '888888', 'FATURA ADRESİ', '', '', @ADDR1, @ADDR2, @CITY, @COUNTRY, @POSTCODE, @TELNRS1, '', @FAXNR, 1, '01-01-2017', 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, '', '', '', '', @TOWNCODE, @TOWN, '', '', @CITYCODE, @COUNTRYCODE, 1, 0, @EMAILADDR, @INCHANGE, '', '', '', '', '', '', '', 134217752, 0, 0, 288817176, 0, 0, '', ''); SELECT SCOPE_IDENTITY()", Utils.FrmNo), CommandType.Text, 60, i_Array3);
        //            }
        //            base.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Exception Error");
        //        }
        //    }
        //    #endregion
        //}

        private void btnNextCompany_Click(object sender, EventArgs e)
        {
            tabgenel.SelectedTab = tabAccount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabgenel.SelectedTab = tabAddress;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabgenel.SelectedTab = tabContact;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabgenel.SelectedTab = tabBank;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabgenel.SelectedTab = tabInfo;
        }

        private void btnBankAdd_Click(object sender, EventArgs e)
        {
            if (btnBankAdd.Text == "Add")
            {
                BankMode = "Add";

                txtAccountTitle.Text = String.Empty;
                txtBankBranchCode.Text = String.Empty;
                txtBankAccountNumber.Text = String.Empty;
                txtBankIban.Text = String.Empty;

                btnBankAdd.Text = "Save";
                btnBankUpdate.Text = "Cancel";
                btnBankDelete.Enabled = false;
            }
            else if (btnBankAdd.Text == "Save")
            {
                if (!InputErrorExist(EmptyCheckTypeBankAccount))
                {
                    if (BankMode == "Add")
                    {
                        SupplierBankAccount ba = new SupplierBankAccount
                        {
                            Title = txtAccountTitle.Text,
                            BranchCode = txtBankBranchCode.Text,
                            AccountNumber = txtBankAccountNumber.Text,
                            IBAN = txtBankIban.Text
                        };
                        SavedBankAccounts.Add(ba);
                    }
                    else if (BankMode == "Update")
                    {
                        SupplierBankAccount ba = (SupplierBankAccount)lbBankList.SelectedItem;

                        ba.Title = txtAccountTitle.Text;
                        ba.BranchCode = txtBankBranchCode.Text;
                        ba.AccountNumber = txtBankAccountNumber.Text;
                        ba.IBAN = txtBankIban.Text;
                    }

                    lbBankList.DataSource = null;
                    lbBankList.DataSource = SavedBankAccounts;
                    lbBankList.DisplayMember = "Title";
                    lbBankList.SelectedIndex = -1;
                    
                    lbBankList.Enabled = true;

                    btnBankAdd.Text = "Add";
                    btnBankUpdate.Text = "Update";
                    btnBankDelete.Enabled = true;
                    
                    BankMode = String.Empty;
                }
            }
        }

        private void btnBankDelete_Click(object sender, EventArgs e)
        {
            if (btnBankDelete.Text == "Cancel")
            {
                ClearBankInputs();
                EnableBankAccountInput(false);

                btnBankAdd.Text = "Add";
                btnBankUpdate.Text = "Update";
                btnBankDelete.Text = "Delete";
                
                ManageDeleteAndModifyButtons(lbContacts, btnContactUpdate, btnContactDelete);
                BankMode = String.Empty;
            }
            else if (btnBankDelete.Text == "Delete")
            {
                ClearBankInputs();
            }
        }

        private void btnBankModify_Click(object sender, EventArgs e)
        {

        }
    }
}
