using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LoginForm.clsClasses;
using System.Collections.Generic;
using LoginForm.MyClasses;
using static LoginForm.Services.MyClasses.MyAuthority;

namespace LoginForm
{
    public partial class CustomerMain : Form
    {
        IMEEntities IME = new IMEEntities();
        int gridselectedindex = 0;
        string searchtxt = "";
        int selectedContactID;
        int contactnewID = 0;
        int QuotationCustomerId = 0;
        int isUpdateAdress;
        bool isModify = false;
        string ComboboxString = "Choose";

        public CustomerMain()
        {
            InitializeComponent();

            CustomerDataGrid.DataSource = null;
            //CustomerDataGrid.DataSource = IME.Customers.ToList(); ;
            CustomerDataGrid.DataSource = IME.CustomerAll().ToList();
            CustomerDataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public CustomerMain(Boolean buttonEnabled, string CustomerID)
        {
            //Qoutation Customer Details

            InitializeComponent();
            if (buttonEnabled)
            {
                CustomerDataGrid.Enabled = false;
                txtSearch.Enabled = false;
                Search.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnContactAdd.Enabled = true;
                btnContactCancel.Enabled = false;
                btnContactDelete.Enabled = true;
                btnContactDone.Enabled = false;
                btnContactUpdate.Enabled = true;
                AdressAdd.Enabled = true;
                AddressUpd.Enabled = true;
                AddressDel.Enabled = true;
                isModify = true;

                MainCategory.DataSource = IME.CustomerCategories.ToList();
                MainCategory.DisplayMember = "categoryname";
                MainCategory.ValueMember = "ID";
                SubCategory.DataSource = IME.CustomerSubCategories.Where(a => a.categoryID == (int)MainCategory.SelectedValue);
                SubCategory.DisplayMember = "subcategoryname";
                SubCategory.ValueMember = "ID";

                QuotationCustomerSearch(CustomerID);


            }
        }

        public CustomerMain(int x, string CustomerID)
        {
            //Qoutation Customer Details
            InitializeComponent();
            if (x == 1)
            {
                QuotationCustomerId = x;
                btnContactClick();
                isModify = true;
                CustomerDataGrid.Enabled = false;
                txtSearch.Enabled = false;
                Search.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnContactAdd.Enabled = true;
                btnContactCancel.Enabled = true;
                btnContactDelete.Enabled = true;
                btnContactDone.Enabled = true;
                btnContactUpdate.Enabled = true;
                tabControl1.SelectedTab = tab_contact;
                tabControl1.TabPages.Remove(tab_account);
                tabControl1.TabPages.Remove(tab_adresses);
                tabControl1.TabPages.Remove(tab_company);
                QuotationCustomerSearch(CustomerID);

            }
            if (x == 2)
            {
                btnContactUpdateClick();
                isModify = true;
                CustomerDataGrid.Enabled = false;
                txtSearch.Enabled = false;
                Search.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnContactAdd.Enabled = false;
                btnContactCancel.Enabled = false;
                btnContactDelete.Enabled = false;
                btnContactDone.Enabled = false;
                btnContactUpdate.Enabled = false;
                AdressAdd.Enabled = true;
                AddressUpd.Enabled = true;
                AddressDel.Enabled = true;
                AdressDone.Enabled = true;
                AdressCancel.Enabled = true;
                tabControl1.SelectedTab = tab_adresses;
                //   tabControl1.Enabled = false;
                QuotationCustomerSearch(CustomerID);
            }
        }

        public CustomerMain(Boolean buttonEnabled)
        {
            InitializeComponent();
        }

        private void ControlAutorization()
        {
            if (!Utils.AuthorityCheck(IMEAuthority.CanAddCustomer))
            {
                btnCreate.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanEditCustomer))
            {
                btnUpdate.Enabled = false;
            }
        }

        private void CustomerMain_Load(object sender, EventArgs e)
        {
            ControlAutorization();
            this.CompanyNotes.KeyDown += new KeyEventHandler(CompanyNotes_KeyDown);
            #region ComboboxFiller
            ContactDepartment.DataSource = IME.CustomerDepartments.ToList();
            ContactDepartment.DisplayMember = "departmentname";
            ContactDepartment.ValueMember = "ID";
            ContactTitle.DataSource = IME.CustomerTitles.ToList();
            ContactTitle.DisplayMember = "titlename";
            ContactTitle.ValueMember = "ID";
            CommunicationLanguage.DataSource = IME.Languages.ToList();
            CommunicationLanguage.DisplayMember = "languagename";
            CommunicationLanguage.ValueMember = "ID";
            Represantative2.DataSource = IME.Workers.ToList();
            Represantative2.DisplayMember = "NameLastName";
            Represantative2.ValueMember = "WorkerID";
            Represantative1.DataSource = IME.Workers.ToList();
            Represantative1.DisplayMember = "NameLastName";
            Represantative1.ValueMember = "WorkerID";
            MainCategory.DataSource = IME.CustomerCategories.ToList();
            MainCategory.DisplayMember = "categoryname";
            MainCategory.ValueMember = "ID";
            SubCategory.DataSource = IME.CustomerSubCategories.Where(a => a.categoryID == (int)MainCategory.SelectedValue);
            SubCategory.DisplayMember = "subcategoryname";
            SubCategory.ValueMember = "ID";
            QuoCurrencyName.DataSource = IME.Currencies.ToList();
            QuoCurrencyName.DisplayMember = "currencyName";
            QuoCurrencyName.ValueMember = "currencyId";
            QuoCurrencyName.SelectedIndex = -1;
            InvCurrencyName.DataSource = IME.Currencies.ToList();
            InvCurrencyName.DisplayMember = "currencyName";
            InvCurrencyName.ValueMember = "currencyId";
            InvCurrencyName.SelectedIndex = -1;
            TermsofPayments.DataSource = IME.PaymentTerms.OrderBy(p => p.timespan).ToList();
            TermsofPayments.DisplayMember = "term_name";
            TermsofPayments.ValueMember = "ID";
            PaymentMethod.DataSource = IME.PaymentMethods.ToList();
            PaymentMethod.DisplayMember = "Payment";
            PaymentMethod.ValueMember = "ID";
            AccountRepresentary.DataSource = IME.Workers.ToList();
            AccountRepresentary.DisplayMember = "NameLastName";
            AccountRepresentary.ValueMember = "WorkerID";
            cbCountry.DataSource = IME.Countries.OrderBy(a => a.Country_name).ToList();
            cbCountry.DisplayMember = "Country_name";
            cbCountry.ValueMember = "ID";

            ContactType.DataSource = IME.ContactTypes.ToList();
            ContactType.ValueMember = "ID";
            ContactType.DisplayMember = "ContactTypeName";
            #endregion
            if (!isModify)
            {
                customersearch();
            }
        }

        private void CustomerDataGrid_Click(object sender, EventArgs e)
        {
            itemsClear();
            gridselectedindex = CustomerDataGrid.CurrentCell.RowIndex;
            customerClicksearch();
        }

        private void customerClicksearch()
        {
            string customerID = CustomerDataGrid.CurrentRow.Cells[ıDDataGridViewTextBoxColumn.Index].Value.ToString();
            //Customer c = (Customer)(IME.Customer_CustomerID(customerID).FirstOrDefault());
            Customer c = IME.Customers.Where(a => a.ID == customerID).FirstOrDefault();
            dateTimePicker1.Value = c.CreateDate.Value;
            CustomerCode.Text = c.ID;
            AdressList.DataSource = IME.CustomerAddresses.Where(customera => customera.CustomerID == CustomerCode.Text).ToList();
            AdressList.DisplayMember = "AdressTitle";
            ContactAdress.DataSource = IME.CustomerAddresses.Where(customera => customera.CustomerID == CustomerCode.Text).ToList();
            ContactAdress.DisplayMember = "AdressTitle";
            CustomerName.Text = c.c_name;
            Telephone.Text = c.telephone;
            if (c.payment_termID != null) TermsofPayments.SelectedValue = c.payment_termID;
            ContactFAX.Text = c.fax;
            WebAdress.Text = c.webadress;
            if (c.Worker2 != null) Represantative2.SelectedValue = c.Worker2.WorkerID;
            if (c.Worker1 != null) Represantative1.SelectedValue = c.Worker1.WorkerID;
            if (c.accountrepresentaryID != null) AccountRepresentary.Text = IME.Workers.Where(a => a.WorkerID == c.accountrepresentaryID).FirstOrDefault().NameLastName;

            if (c.PaymentTerm != null) TermsofPayments.SelectedValue = c.PaymentTerm.ID;
            if (c.isactive == 1) { rb_active.Checked = true; } else { rb_passive.Checked = true; }
            ContactList.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
            ContactList.DisplayMember = "cw_name";
            ContactList.ValueMember = "ID";
            cbMainContact.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
            cbMainContact.DisplayMember = "cw_name";
            cbMainContact.ValueMember = "ID";
            if (c.CurrNameQuo != null)
            {
                QuoCurrencyName.SelectedIndex = QuoCurrencyName.FindStringExact(c.CurrNameQuo);
            }
            else
            {
                QuoCurrencyName.SelectedIndex = -1;
            }
            if (c.CurrNameInv != null)
            {
                InvCurrencyName.SelectedIndex = InvCurrencyName.FindStringExact(c.CurrNameInv);
            }
            else
            {
                InvCurrencyName.SelectedIndex = -1;
            }

            if (c.CustomerCategory != null)
            {
                MainCategory.SelectedValue = c.CustomerCategory.ID;
                if (c.CustomerSubCategory != null)
                {
                    SubCategory.SelectedValue = c.subcategoryID;
                }
                else
                {
                    SubCategory.SelectedValue = -1;
                }
            }
            //QuoCurrencyName.SelectedValue = c.CurrNameQuo ?? -1;
            //InvCurrencyName.SelectedValue = c.CurrNameInv ?? -1;
            if (c.Note != null) CompanyNotes.Text = IME.Notes.Where(a => a.ID == c.Note.ID).FirstOrDefault().Note_name;
            if (c.customerAccountantNoteID != null) AccountingNotes.Text = IME.Notes.Where(a => a.ID == c.customerAccountantNoteID).FirstOrDefault().Note_name;
            if (c.creditlimit != null) CreditLimit.Text = c.creditlimit.ToString();
            if (c.creditlimit != null) CreditLimit.Text = c.creditlimit.ToString();

            txt3partyCode.Text = c.ThirdPartyCode ?? txt3partyCode.Text;
            Capital.SelectedIndex = Capital.FindStringExact(c.Capital);
            CustomerFax.Text = c.fax ?? CustomerFax.Text;
            TaxOffice.Text = c.taxoffice ?? TaxOffice.Text;
            taxNumber.Text = c.taxnumber ?? taxNumber.Text;
            PaymentMethod.SelectedValue = (c.paymentmethodID != null) ? c.paymentmethodID : -1;
            factor.Text = c.factor.ToString() ?? factor.Text;
            DiscountRate.Text = c.discountrate.ToString() ?? DiscountRate.Text;
        }

        //private void populateGrid<T>(List<T> queryable)
        //{
        //    CustomerDataGrid.DataSource = null;
        //    CustomerDataGrid.DataSource = queryable;
        //    CustomerDataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //}

        private void ContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                #region ContactList
                //contact daki list box a tıklandığında contact ın bilgileri tıklanan göre doldurulmasıse
                int cw_ID = (int)ContactList.SelectedValue;
                if (CustomerName.Text != string.Empty)
                {
                    ContactListItem.ID = cw_ID;
                    string contactname = ((CustomerWorker)((ListBox)sender).SelectedItem).cw_name;
                    ContactListItem.contactName = contactname;
                    var a = IME.CustomerWorkers.Where(cw => cw.ID == cw_ID).FirstOrDefault();

                    selectedContactID = a.ID;
                    if (a.ContactTypeID != null) ContactType.SelectedValue = a.ContactTypeID;
                    ContactName.Text = a.cw_name;
                    ContactEmail.Text = a.cw_email;
                    if (a.CustomerDepartment != null) ContactDepartment.SelectedValue = a.CustomerDepartment.ID;
                    if (a.CustomerTitle != null) ContactTitle.SelectedValue = a.CustomerTitle.ID;
                    ContactFAX.Text = a.fax;
                    ContactMobilePhone.Text = a.mobilephone;
                    ContactPhone.Text = a.phone;
                    if (a.CustomerWorkerAdress != null) ContactAdress.SelectedItem = Int32.Parse(a.CustomerWorkerAdress.ToString());
                    CommunicationLanguage.SelectedValue = a.Language.ID;
                    if (a.Note != null) { ContactNotes.Text = a.Note.Note_name; } else { ContactNotes.Text = ""; }

                    //foreach (var a in contact1)
                    //{
                    //    selectedContactID = a.ID;
                    //    if (a.ContactTypeID != null) ContactType.SelectedValue = a.ContactTypeID;
                    //    ContactName.Text = a.cw_name;
                    //    ContactEmail.Text = a.cw_email;
                    //    if (a.CustomerDepartment != null) ContactDepartment.SelectedValue = ContactDepartment.FindStringExact(a.CustomerDepartment.departmentname);
                    //    if (a.CustomerTitle != null) ContactTitle.SelectedValue = ContactTitle.FindStringExact(a.CustomerTitle.titlename);
                    //    ContactFAX.Text = a.fax;
                    //    ContactMobilePhone.Text = a.mobilephone;
                    //    ContactPhone.Text = a.phone;
                    //    if (a.CustomerWorkerAdress != null) ContactAdress.SelectedItem = Int32.Parse(a.CustomerWorkerAdress.ToString());
                    //    CommunicationLanguage.SelectedValue = CommunicationLanguage.FindStringExact(a.Language.languagename);
                    //    if (a.Note != null) { ContactNotes.Text = a.Note.Note_name; } else { ContactNotes.Text = ""; }
                    //}

                }
                #endregion
            }
            catch { }
        }

        private void departmentAdd_Click(object sender, EventArgs e)
        {
            CustomerDepartmentAdd form = new CustomerDepartmentAdd();
            this.Enabled = false;
            this.SendToBack();
            form.ShowDialog();
            ContactDepartment.DataSource = new IMEEntities().CustomerDepartments.ToList();
            this.Enabled = true;
        }

        private void titleAdd_Click(object sender, EventArgs e)
        {
            if (ContactDepartment.SelectedValue != null && ContactDepartment.Text != ComboboxString)
            {
                int department = Convert.ToInt32(ContactDepartment.SelectedValue);
                CustomerPositionAdd form = new CustomerPositionAdd(department);
                this.Enabled = false;
                this.SendToBack();
                form.ShowDialog();
                ContactTitle.DataSource = new IMEEntities().CustomerTitles.ToList();
                this.Enabled = true;
            }
            else { MessageBox.Show("Please select a Department"); }
        }

        private void MainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategory.Text = "";
            int c_categoryID;
            try
            {
                c_categoryID = (int)((ComboBox)sender).SelectedValue;
            }
            catch { c_categoryID = 0; }
            SubCategory.DataSource = IME.CustomerSubCategories.Where(b => b.categoryID == c_categoryID).ToList();
            SubCategory.DisplayMember = "subcategoryname";
            SubCategory.ValueMember = "ID";
        }

        private void Search_Click(object sender, EventArgs e)
        {
            gridselectedindex = 0;
            searchtxt = txtSearch.Text;
            customersearch();

        }

        private void contactTabEnableFalse()
        {
            #region contactTabEnableFalse
            ContactEmail.Enabled = false;
            CommunicationLanguage.Enabled = false;
            ContactType.Enabled = false;
            ContactDepartment.Enabled = false;
            departmentAdd.Enabled = false;

            ContactTitle.Enabled = false;
            titleAdd.Enabled = false;
            ContactName.Enabled = false;
            ContactEmail.Enabled = false;
            ContactPhone.Enabled = false;
            txtExtNumber.Enabled = false;
            ContactAdress.Enabled = false;
            ContactMobilePhone.Enabled = false;
            ContactFAX.Enabled = false;
            CommunicationLanguage.Enabled = false;
            ContactNotes.Enabled = false;
            departmentAdd.Enabled = false;
            cbDefaultInvoiceAdress.Enabled = false;
            cbDefaultDeliveryAdress.Enabled = false;

            titleAdd.Enabled = false;
            ContactList.Enabled = true;

            btnContactAdd.Enabled = true;
            if (ContactList.DataSource != null)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }
            else
            {
                btnContactDelete.Enabled = false;
                btnContactUpdate.Enabled = false;
            }

            btnContactAdd.Enabled = false;

            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;

            btnContactAdd.Enabled = true;
            if (ContactList.DataSource != null)
            {
                btnContactUpdate.Enabled = true;
                btnContactDelete.Enabled = true;
            }

            #endregion
        }

        private void contactTabEnableTrue()
        {
            #region contactTabEnableTrue
            ContactEmail.Enabled = true;
            CommunicationLanguage.Enabled = true;
            ContactType.Enabled = true;
            ContactDepartment.Enabled = true;
            departmentAdd.Enabled = true;
            ContactTitle.Enabled = true;
            titleAdd.Enabled = true;

            ContactName.Enabled = true;
            ContactEmail.Enabled = true;
            ContactPhone.Enabled = true;
            txtExtNumber.Enabled = true;
            ContactAdress.Enabled = true;
            btnContactAdd.Enabled = true;
            if (ContactList.Items.Count > 0)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }

            ContactMobilePhone.Enabled = true;
            ContactFAX.Enabled = true;
            CommunicationLanguage.Enabled = true;
            ContactNotes.Enabled = true;
            departmentAdd.Enabled = true;
            if (AdressList.Items.Count > 0)
            {
                AddressDel.Enabled = true;
                AddressUpd.Enabled = true;
            }
            AdressAdd.Enabled = true;
            titleAdd.Enabled = true;
            ContactList.Enabled = false;
            CustomerDataGrid.Enabled = false;
            btnContactAdd.Enabled = false;
            btnContactDelete.Enabled = false;
            btnContactUpdate.Enabled = false;
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            txtSearch.Enabled = false;
            Search.Enabled = false;
            #endregion
        }

        private void AdressTabEnableFalse()
        {
            #region AdressTabEnableFalse
            AddressType.Enabled = false;
            cbCountry.Enabled = false;
            cbCity.Enabled = false;
            cbTown.Enabled = false;
            PostCode.Enabled = false;
            txtAdressTitle.Enabled = false;
            cbTown.Enabled = false;
            TownAdd.Enabled = false;
            AddressDetails.Enabled = false;
            cbDefaultInvoiceAdress.Enabled = false;
            cbDefaultDeliveryAdress.Enabled = false;
            cbDefaultInvoiceAdress.Enabled = false;
            AdressList.Enabled = true;
            txtAdressTitle.Enabled = false;
            if (ContactList.DataSource != null)
            {
                AddressDel.Enabled = true;
                AddressUpd.Enabled = true;
            }
            AdressAdd.Enabled = true;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            #endregion
        }

        private void AdressTabEnableTrue()
        {
            #region contactTabEnableTrue
            //if (cbIMEOffice.Checked == false)
            //{
            AddressType.Enabled = true;
            //}
            cbCountry.Enabled = true;
            cbCity.Enabled = true;
            cbTown.Enabled = true;
            PostCode.Enabled = true;
            txtAdressTitle.Enabled = true;
            cbTown.Enabled = true;
            AddressDetails.Enabled = true;
            cbDefaultInvoiceAdress.Enabled = true;
            cbDefaultDeliveryAdress.Enabled = true;
            cbDefaultInvoiceAdress.Enabled = true;
            AdressList.Enabled = false;
            txtAdressTitle.Enabled = true;
            TownAdd.Enabled = true;
            CustomerDataGrid.Enabled = false;
            AdressAdd.Enabled = false;
            AddressDel.Enabled = false;
            AddressUpd.Enabled = false;
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            txtSearch.Enabled = false;
            Search.Enabled = false;
            #endregion
        }

        private void customersearch()
        {
            if (searchtxt == null || searchtxt == "")
            {
                // TODO 7 : Veritabanından customer araması sql'den çekilecek
                //var CustomerList = (from c in IME.Customers.Take(100).Where(a => a.c_name.Contains(searchtxt))
                //                    select new
                //                    {
                //                        c.ID,
                //                        CustomerName = c.c_name,
                //                        Disc = c.discountrate,
                //                        PaymentMethod = c.PaymentMethod.Payment,
                //                        CrediLimit = c.creditlimit,
                //                        Web = c.webadress,
                //                        PaymentTerm = c.PaymentTerm.term_name,
                //                        Representative = c.representaryID,
                //                        NoteName = c.Note.Note_name,
                //                        Representative2 = c.representary2ID,
                //                        AccountRepresentative = c.accountrepresentaryID,
                //                        IsActive = c.isactive,
                //                        RateInvoice = c.rateIDinvoice,
                //                        TaxOffice = c.taxoffice,
                //                        TaxNumber = c.taxnumber,
                //                        MainContact = c.MainContactID,
                //                        CurTypeInvoice = c.CurrTypeInv,
                //                        CurNameInvoice = c.CurrNameInv,
                //                        CurTypeQuo = c.CurrTypeQuo,
                //                        CurNameQuo = c.CurrNameQuo,
                //                        AccountNote = c.customerAccountantNoteID,
                //                        ExtensionNumber = c.extensionnumber,
                //                        Factor = c.factor,
                //                        CreditDay = c.creditDay,
                //                        c.CreateDate,
                //                        Telephone = c.telephone,
                //                        Fax = c.fax,
                //                        Category = c.categoryID,
                //                        SubCategory = c.subcategoryID,
                //                        c.ThirdPartyCode,
                //                        c.Capital
                //                    }).ToList();
                //List<Customer> CustomerList = IME.Customers.Where(a=>a.c_name.Contains(searchtxt)).OrderByDescending(de => de.CreateDate).ToList();
                var CustomerList = IME.Customer_CustomerName(searchtxt).ToList();
                CustomerDataGrid.DataSource = CustomerList;
            }
            else
            {
                // TODO 7 : Veritabanından customer araması sql'den çekilecek
                //var CustomerList = (from c in IME.Customers.Where(a => a.c_name.Contains(searchtxt)).OrderByDescending(de => de.CreateDate)
                //                    select new
                //                    {
                //                        c.ID,
                //                        CustomerName = c.c_name,
                //                        Disc = c.discountrate,
                //                        PaymentMethod = c.PaymentMethod.Payment,
                //                        CrediLimit = c.creditlimit,
                //                        Web = c.webadress,
                //                        PaymentTerm = c.PaymentTerm.term_name,
                //                        Representative = c.representaryID,
                //                        NoteName = c.Note.Note_name,
                //                        Representative2 = c.representary2ID,
                //                        AccountRepresentative = c.accountrepresentaryID,
                //                        IsActive = c.isactive,
                //                        RateInvoice = c.rateIDinvoice,
                //                        TaxOffice = c.taxoffice,
                //                        TaxNumber = c.taxnumber,
                //                        MainContact = c.MainContactID,
                //                        CurTypeInvoice = c.CurrTypeInv,
                //                        CurNameInvoice = c.CurrNameInv,
                //                        CurTypeQuo = c.CurrTypeQuo,
                //                        CurNameQuo = c.CurrNameQuo,
                //                        AccountNote = c.customerAccountantNoteID,
                //                        ExtensionNumber = c.extensionnumber,
                //                        Factor = c.factor,
                //                        CreditDay = c.creditDay,
                //                        CreateDate = c.CreateDate,
                //                        Telephone = c.telephone,
                //                        Fax = c.fax,
                //                        Category = c.categoryID,
                //                        SubCategory = c.subcategoryID,
                //                        ThirdPartyCode = c.ThirdPartyCode,
                //                        c.Capital
                //                    }).ToList();
                //List<Customer> CustomerList = IME.Customers.Where(a => a.c_name.Contains(searchtxt)).OrderByDescending(de => de.CreateDate).ToList();
                var CustomerList = IME.Customer_CustomerName(searchtxt).ToList();
                CustomerDataGrid.DataSource = CustomerList;
            }
            if (CustomerDataGrid.RowCount != 0)
            {
                string customerID = CustomerDataGrid.CurrentRow.Cells[ıDDataGridViewTextBoxColumn.Index].Value.ToString();
               // Customer c = (Customer)IME.Customer_CustomerID(customerID).FirstOrDefault();
               Customer c = IME.Customers.Where(a => a.ID == customerID).FirstOrDefault();
                dateTimePicker1.Value = c.CreateDate.Value;
                CustomerCode.Text = c.ID;
                txt3partyCode.Text = c.ThirdPartyCode;
                AdressList.DataSource = IME.CustomerAddresses.Where(customera => customera.CustomerID == CustomerCode.Text).ToList();
                AdressList.DisplayMember = "AdressTitle";
                ContactAdress.DataSource = IME.CustomerAddresses.Where(customera => customera.CustomerID == CustomerCode.Text).ToList();
                ContactAdress.DisplayMember = "AdressTitle";
                CustomerName.Text = c.c_name;
                Telephone.Text = c.telephone;
                ContactFAX.Text = c.fax;
                WebAdress.Text = c.webadress;
                if (c.Worker2 != null) Represantative2.SelectedValue = c.Worker2.WorkerID;
                if (c.Worker1 != null) Represantative1.SelectedValue = c.Worker1.WorkerID;
                if (c.accountrepresentaryID != null) AccountRepresentary.Text = IME.Workers.Where(a => a.WorkerID == c.accountrepresentaryID).FirstOrDefault().NameLastName;
                if (c.CustomerCategory != null) MainCategory.SelectedValue = c.CustomerCategory.ID;
                if (c.CustomerSubCategory != null) SubCategory.SelectedValue = c.CustomerSubCategory.ID;
                TermsofPayments.SelectedValue = c.PaymentTerm != null ? c.PaymentTerm.ID : 0;
                if (c.isactive == 1) { rb_active.Checked = true; } else { rb_passive.Checked = true; }
                ContactList.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
                ContactList.DisplayMember = "cw_name";
                ContactList.ValueMember = "ID";
                cbMainContact.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
                cbMainContact.DisplayMember = "cw_name";
                cbMainContact.ValueMember = "ID";
                if (c.Note != null) CompanyNotes.Text = IME.Notes.Where(a => a.ID == c.Note.ID).FirstOrDefault().Note_name;
                if (c.customerAccountantNoteID != null) AccountingNotes.Text = IME.Notes.Where(a => a.ID == c.customerAccountantNoteID).FirstOrDefault().Note_name;
                CreditLimit.Text = c.creditlimit.ToString();
            }
        }

        private void QuotationCustomerSearch(string search)
        {
            //var CustomerList = IME.Customers.Where(a => a.ID.ToUpper().Contains(search.ToUpper())).ToList();
            var CustomerList = IME.Customer_CustomerID(search).ToList();
            CustomerDataGrid.DataSource = CustomerList;
            string customerID = CustomerDataGrid.Rows[0].Cells["ID"].Value.ToString();
            //Customer c = (Customer)IME.Customer_CustomerID(customerID).FirstOrDefault();
            Customer c = IME.Customers.Where(a => a.ID == customerID).FirstOrDefault();
            dateTimePicker1.Value = c.CreateDate.Value;
            CustomerCode.Text = c.ID;
            AdressList.DataSource = IME.CustomerAddresses.Where(customera => customera.CustomerID == CustomerCode.Text).ToList();
            AdressList.DisplayMember = "AdressTitle";
            ContactAdress.DataSource = IME.CustomerAddresses.Where(customera => customera.CustomerID == CustomerCode.Text).ToList();
            ContactAdress.DisplayMember = "AdressTitle";
            CustomerName.Text = c.c_name;
            txt3partyCode.Text = c.ThirdPartyCode;
            Telephone.Text = c.telephone;
            ContactFAX.Text = c.fax;
            WebAdress.Text = c.webadress;
            if (c.Worker2 != null) Represantative2.SelectedValue = c.Worker2.WorkerID;
            if (c.Worker1 != null) Represantative1.SelectedValue = c.Worker1.WorkerID;
            if (c.accountrepresentaryID != null) AccountRepresentary.Text = IME.Workers.Where(a => a.WorkerID == c.accountrepresentaryID).FirstOrDefault().NameLastName;
            if (c.CustomerCategory != null) MainCategory.SelectedValue = c.CustomerCategory.ID;
            if (c.CustomerSubCategory != null) SubCategory.SelectedValue = c.CustomerSubCategory.ID;
            if (c.payment_termID != null) TermsofPayments.SelectedValue = c.PaymentTerm.ID;
            if (c.isactive == 1) { rb_active.Checked = true; } else { rb_passive.Checked = true; }
            ContactList.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
            ContactList.DisplayMember = "cw_name";
            ContactList.ValueMember = "ID";
            cbMainContact.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
            cbMainContact.DisplayMember = "cw_name";
            cbMainContact.ValueMember = "ID";
            if (c.Note != null) CompanyNotes.Text = IME.Notes.Where(a => a.ID == c.Note.ID).FirstOrDefault().Note_name;
            if (c.customerAccountantNoteID != null) AccountingNotes.Text = IME.Notes.Where(a => a.ID == c.customerAccountantNoteID).FirstOrDefault().Note_name;
            CreditLimit.Text = c.creditlimit.ToString();
            // CustomerDataGrid.CurrentCell = CustomerDataGrid.Rows[gridselectedindex].Cells[0];
        }

        //CONTACT ADD NEW
        private void btnContactAdd_Click(object sender, EventArgs e)
        {
            btnContactClick();
        }

        private void btnContactClick()
        {
            #region addContactButton
            contactnewID = 0;
            contactTabEnableTrue();
            ContactType.Text = "";
            ContactDepartment.Text = "";
            ContactTitle.Text = "";
            cbMainContact.Text = "";
            ContactName.Text = "";
            ContactEmail.Text = "";
            ContactPhone.Text = "";
            ContactMobilePhone.Text = "";
            ContactFAX.Text = "";
            CommunicationLanguage.Text = "";
            ContactNotes.Text = "";
            btnContactAdd.Visible = false;
            btnContactCancel.Visible = true;
            btnContactDelete.Visible = false;
            btnContactDone.Visible = true;
            btnContactUpdate.Visible = false;
            ContactList.Enabled = false;

            ContactType.Text = (ComboboxString);
            ContactDepartment.Text = (ComboboxString);
            ContactTitle.Text = (ComboboxString);
            CommunicationLanguage.Text = (ComboboxString);
            #endregion
        }

        private void btnContactCancel_Click(object sender, EventArgs e)
        {
            #region btnContactCancel
            contactTabEnableFalse();
            if (btnCreate.Text == "CREATE")
            {
                txtSearch.Enabled = true;
                Search.Enabled = true;
                CustomerDataGrid.Enabled = true;
            }
            btnContactAdd.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDelete.Visible = true;
            btnContactDone.Visible = false;
            btnContactUpdate.Visible = true;

            if (QuotationCustomerId == 1)
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
            }
            #endregion

        }
        //CONTACT UPDATE
        private void btnContactUpdate_Click(object sender, EventArgs e)
        {
            btnContactUpdateClick();
        }

        private void btnContactUpdateClick()
        {
            contactnewID = 1;
            contactTabEnableTrue();
            btnContactAdd.Visible = false;
            btnContactCancel.Visible = true;
            btnContactDelete.Visible = false;
            btnContactDone.Visible = true;
            btnContactUpdate.Visible = false;
        }

        private void btnContactDone_Click(object sender, EventArgs e)
        {
            if (contactnewID == 0)
            {
                CustomerWorker cw = new CustomerWorker();
                //CustomerCode.Text;
                cw.customerID = CustomerCode.Text;
                cw.departmentID = ((CustomerDepartment)(ContactDepartment).SelectedItem).ID;
                cw.titleID = ((CustomerTitle)(ContactTitle).SelectedItem).ID;
                cw.cw_name = ContactName.Text;
                cw.cw_email = ContactEmail.Text;
                cw.phone = ContactPhone.Text;
                if (ContactAdress.SelectedItem != null) cw.CustomerWorkerAdress = (ContactAdress.SelectedItem as CustomerAddress).ID;
                if (ContactType.SelectedItem != null) cw.ContactTypeID = (ContactType.SelectedItem as ContactType).ID;
                cw.mobilephone = ContactMobilePhone.Text;
                cw.fax = ContactFAX.Text;
                if (CommunicationLanguage.SelectedItem != null) cw.languageID = ((Language)(CommunicationLanguage).SelectedItem).ID;
                Note n = new Note();
                n.Note_name = ContactNotes.Text;
                IME.Notes.Add(n);
                IME.SaveChanges();
                cw.customerNoteID = n.ID;
                IME.CustomerWorkers.Add(cw);
                IME.SaveChanges();
                if (btnCreate.Text == "CREATE")
                {
                    txtSearch.Enabled = true;
                    Search.Enabled = true;
                    CustomerDataGrid.Enabled = true;
                }
                ContactList.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
                ContactList.DisplayMember = "cw_name";
                ContactList.ValueMember = "ID";
                //catch { MessageBox.Show("Contact is NOT successfull"); }
                cbMainContact.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
                cbMainContact.DisplayMember = "cw_name";
                cbMainContact.ValueMember = "ID";
                contactTabEnableFalse();
            }
            else
            {
                CustomerWorker cw = IME.CustomerWorkers.Where(a => a.ID == ((CustomerWorker)(ContactList).SelectedItem).ID).FirstOrDefault();
                if (cw.cw_name != "")
                {
                    //UPDATE CONTACT
                    cw.customerID = CustomerCode.Text;
                    cw.departmentID = ((ContactDepartment).SelectedItem as CustomerDepartment).ID;
                    cw.titleID = ((ContactTitle).SelectedItem as CustomerTitle).ID;
                    cw.ContactTypeID = (ContactType.SelectedItem as ContactType).ID;
                    cw.cw_name = ContactName.Text;
                    cw.cw_email = ContactEmail.Text;
                    cw.phone = ContactPhone.Text;
                    if (ContactAdress.SelectedItem != null) cw.CustomerWorkerAdress = (ContactAdress.SelectedItem as CustomerAddress).ID;
                    cw.mobilephone = ContactMobilePhone.Text;
                    cw.fax = ContactFAX.Text;
                    cw.languageID = ((CommunicationLanguage).SelectedItem as Language).ID;
                    var contactNote = IME.Notes.Where(a => a.ID == cw.customerNoteID).FirstOrDefault();
                    if (contactNote == null)
                    {
                        if (ContactNotes.Text != "")
                        {
                            Note n = new Note();
                            n.Note_name = ContactNotes.Text;
                            IME.Notes.Add(n);
                            IME.SaveChanges();
                            cw.customerNoteID = n.ID;
                        }
                    }
                    else
                    {
                        contactNote.Note_name = ContactNotes.Text;
                        IME.SaveChanges();
                        cw.customerNoteID = contactNote.ID;
                    }
                    IME.SaveChanges();
                    contactTabEnableFalse();
                    if (btnCreate.Text == "CREATE")
                    {
                        txtSearch.Enabled = true;
                        Search.Enabled = true;
                        CustomerDataGrid.Enabled = true;
                    }
                    ContactList.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
                    ContactList.DisplayMember = "cw_name";
                    cbMainContact.ValueMember = "ID";
                    cbMainContact.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
                    cbMainContact.DisplayMember = "cw_name";
                    cbMainContact.ValueMember = "ID";
                }
                else { MessageBox.Show("Please choose a contact to update"); }
            }




            btnContactAdd.Visible = true;
            btnContactDelete.Visible = true;
            btnContactUpdate.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDone.Visible = false;

            if (QuotationCustomerId == 1)
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void ContactDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_departmentID;
            try { c_departmentID = ((CustomerDepartment)((ComboBox)sender).SelectedItem).ID; } catch { c_departmentID = 0; }
            ContactTitle.DataSource = IME.CustomerTitles.ToList();
            ContactTitle.DisplayMember = "titlename";
        }

        private void btnContactDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Delete Contact " + ContactListItem.contactName + " ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                CustomerWorker cw = IME.CustomerWorkers.First(a => a.ID == (int)ContactList.SelectedValue);
                IME.CustomerWorkers.Remove(cw);
                IME.SaveChanges();
                ContactType.SelectedIndex = -1;
                ContactDepartment.SelectedIndex = -1;
                ContactTitle.SelectedIndex = -1;
                ContactName.Text = "";
                ContactEmail.Text = "";
                ContactPhone.Text = "";
                ContactMobilePhone.Text = "";
                ContactFAX.Text = "";
                CommunicationLanguage.SelectedIndex = -1;
                ContactNotes.Text = "";
                ContactList.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
                ContactList.DisplayMember = "cw_name";
                ContactList.ValueMember = "ID";
                cbMainContact.DataSource = null;
                cbMainContact.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
                cbMainContact.DisplayMember = "cw_name";
                cbMainContact.ValueMember = "ID";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Management m = Utils.getManagement();
            if (btnCreate.Text == "CREATE")
            {
                dateTimePicker1.Value = DateTime.Today;
                itemsEnableTrue();
                itemsClear();
                rb_active.Checked = true;
                int represantative_id = Utils.getCurrentUser().WorkerID;
                Represantative1.DataSource = IME.Workers.Where(a => a.WorkerID == represantative_id).ToList();
                Represantative1.DisplayMember = "NameLastName";
                cbMainContact.DataSource = null;
                #region ComboboxChoose
                MainCategory.Text = (ComboboxString);
                SubCategory.Text = (ComboboxString);
                // Represantative1.Text = (ComboboxString);
                Represantative2.Text = (ComboboxString);
                Capital.Text = (ComboboxString);
                cbMainContact.Text = (ComboboxString);
                AccountRepresentary.Text = (ComboboxString);
                TermsofPayments.Text = (ComboboxString);
                PaymentMethod.Text = (ComboboxString);
                QuoCurrencyName.SelectedValue = m.DefaultCurrency;
                QuoCurrencyType.Text = (ComboboxString);
                InvCurrencyName.SelectedValue = m.DefaultCurrency;
                InvCurrencyType.Text = (ComboboxString);
                AddressType.Text = (ComboboxString);
                cbCountry.Text = (ComboboxString);
                cbCity.Text = (ComboboxString);
                cbTown.Text = (ComboboxString);
                ContactType.Text = (ComboboxString);
                ContactDepartment.Text = (ComboboxString);
                ContactTitle.Text = (ComboboxString);
                CommunicationLanguage.Text = (ComboboxString);
                #endregion

                //for new customerCode
                string custmrcode = "";
                if (IME.Customers.ToList().Count != 0)
                    custmrcode = IME.Customers.OrderByDescending(a => a.ID).FirstOrDefault().ID;
                string custmrnumbers = string.Empty;
                string newcustomercodenumbers = "";
                string newcustomercodezeros = "";
                string newcustomercodechars = "";
                for (int i = 0; i < custmrcode.Length; i++)
                {
                    if (Char.IsDigit(custmrcode[i]))
                    {
                        if (custmrcode[i] == '0') { newcustomercodezeros += custmrcode[i]; } else { newcustomercodenumbers += custmrcode[i]; }
                    }
                    else
                    {
                        newcustomercodechars += custmrcode[i];
                    }
                }
                //Aynı ID ile customer oluşturmasını önleyen kısım
                while (IME.Customers.Where(a => a.ID == custmrcode).Count() > 0)
                {
                    newcustomercodenumbers = (Int32.Parse(newcustomercodenumbers) + 1).ToString();
                    custmrcode = newcustomercodechars + newcustomercodezeros + newcustomercodenumbers;
                }
                //
                ContactList.DataSource = null;
                CustomerCode.Text = custmrcode;
                Customer newCustomer = new Customer();
                newCustomer.CreateDate = Convert.ToDateTime(IME.CurrentDate().First()).Date;
                newCustomer.ID = CustomerCode.Text;
                IME.Customers.Add(newCustomer);
                IME.SaveChanges();
                btnCreate.Text = "SAVE";
                btnUpdate.Text = "CANCEL";
                AdressList.Enabled = false;
                AdressList.DataSource = null;
                ContactAdress.DataSource = null;
                AdressAdd.Enabled = true;
                btnContactAdd.Enabled = true;
                btnContactClick();
                btnAddressClick();
                btnUpdate.Enabled = true;
                btnCreate.Enabled = true;
            }
            else
            {
                if (ControlSave())
                {
                    //if (MainCategory.Text == ComboboxString || SubCategory.Text == ComboboxString || Represantative2.Text == ComboboxString || Capital.Text == ComboboxString || cbMainContact.Text == ComboboxString || AccountRepresentary.Text == ComboboxString || TermsofPayments.Text == ComboboxString || PaymentMethod.Text == ComboboxString || QuoCurrencyName.Text == ComboboxString || /*QuoCurrencyType.Text == ComboboxString ||*/ InvCurrencyName.Text == ComboboxString || /*InvCurrencyType.Text == ComboboxString ||*/ AddressType.Text == ComboboxString || cbCountry.Text == ComboboxString || cbCity.Text == ComboboxString || cbTown.Text == ComboboxString || ContactType.Text == ComboboxString || ContactDepartment.Text == ComboboxString || ContactTitle.Text == ComboboxString || CommunicationLanguage.Text == ComboboxString)
                    //{
                    //    MessageBox.Show("Combobox is empty", "WARNING", MessageBoxButtons.OK);

                    //}
                    //else
                    //{
                    btnCreate.Text = "CREATE";
                    btnUpdate.Text = "UPDATE";

                    Customer c = new Customer();
                    //c = (Customer)IME.Customer_CustomerID(CustomerCode.Text).FirstOrDefault();
                    c = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();
                    if (rb_active.Checked) { c.isactive = 1; } else { c.isactive = 0; }
                    c.c_name = CustomerName.Text;
                    if (!String.IsNullOrEmpty(txt3partyCode.Text))
                    { c.ThirdPartyCode = txt3partyCode.Text; }
                    if (Telephone.Text != "") { c.telephone = Telephone.Text; }
                    if (txtExtNumber.Text != "") { c.extensionnumber = txtExtNumber.Text; }
                    if (CustomerFax.Text != "") { c.fax = CustomerFax.Text; }
                    c.webadress = WebAdress.Text;
                    if (CreditLimit.Text != "") { c.creditlimit = Int32.Parse(CreditLimit.Text); }
                    if (DiscountRate.Text != "") { c.discountrate = Decimal.Parse(DiscountRate.Text); }
                    c.taxoffice = TaxOffice.Text;
                    if (taxNumber.Text != "") { c.taxnumber = taxNumber.Text; }
                    if (MainCategory.SelectedValue != null)
                    { c.categoryID = Int32.Parse(MainCategory.SelectedValue.ToString()); }

                    if (SubCategory.SelectedValue != null) { c.subcategoryID = Int32.Parse(SubCategory.SelectedValue.ToString()); }
                    if (AccountRepresentary.SelectedItem != null)
                    { c.accountrepresentaryID = (AccountRepresentary.SelectedItem as Worker).WorkerID; }
                    //c.representaryID = Utils.getCurrentUser().WorkerID;
                    if (Represantative1.SelectedValue != null)
                    {
                        int c_rep1ID = ((Worker)(Represantative1).SelectedItem).WorkerID;
                        c.representaryID = c_rep1ID;
                    }
                    if (Represantative2.SelectedValue != null)
                    {
                        int c_rep2ID = ((Worker)(Represantative2).SelectedItem).WorkerID;
                        c.representary2ID = c_rep2ID;
                    }
                    if (TermsofPayments.SelectedValue != null)
                    {
                        int c_termpayment = ((PaymentTerm)(TermsofPayments).SelectedItem).ID;
                        c.payment_termID = c_termpayment;
                    }
                    if (PaymentMethod.SelectedValue != null)
                    {
                        int c_paymentmeth = ((PaymentMethod)(PaymentMethod).SelectedItem).ID;
                        c.paymentmethodID = c_paymentmeth;
                    }
                    if (cbMainContact.SelectedValue != null)
                    {
                        c.MainContactID = (int)cbMainContact.SelectedValue;
                    }
                    if (QuoCurrencyName.SelectedValue != null)
                    {
                        c.CurrNameQuo = ((DataSet.Currency)QuoCurrencyName.SelectedItem).currencyName;
                    }
                    if (InvCurrencyName.SelectedValue != null)
                    {
                        c.CurrNameInv = ((DataSet.Currency)InvCurrencyName.SelectedItem).currencyName;
                    }
                    if (factor.Text != "") c.factor = Decimal.Parse(factor.Text);
                    if (Capital.SelectedItem != null) c.Capital = Capital.SelectedItem.ToString();

                    //Notes kısmına kayıt ediliyor
                    Note n1 = new Note();
                    try { n1 = IME.Notes.Where(a => a.ID == c.Note.ID).FirstOrDefault(); } catch { }
                    if (c.Note == null)
                    {
                        n1.Note_name = CompanyNotes.Text;
                        c.Note = n1;
                        IME.Notes.Add(c.Note);
                        IME.SaveChanges();
                        //c.customerNoteID = c.Note.ID;
                    }
                    else
                    {
                        n1.Note_name = CompanyNotes.Text;
                        IME.SaveChanges();
                    }
                    if (c.customerAccountantNoteID == null)
                    {
                        Note n = new Note();
                        n.Note_name = AccountingNotes.Text;
                        IME.Notes.Add(n);
                        IME.SaveChanges();
                        c.customerAccountantNoteID = n.ID;
                    }
                    else
                    {
                        Note n = IME.Notes.Where(a => a.ID == c.customerAccountantNoteID).FirstOrDefault();
                        n.Note_name = AccountingNotes.Text;
                        IME.SaveChanges();
                    }
                    IME.SaveChanges();

                    itemsEnableFalse();
                    contactTabEnableFalse();
                    customersearch();
                    //}

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "UPDATE")
            {
                itemsEnableTrue();
                btnContactAdd.Enabled = true;
                if (ContactList.DataSource != null)
                {
                    btnContactDelete.Enabled = true;
                    btnContactUpdate.Enabled = true;
                }
                AdressAdd.Enabled = true;
                if (AdressList.DataSource != null)
                {
                    AddressDel.Enabled = true;
                    AddressUpd.Enabled = true;
                }
                btnUpdate.Text = "CANCEL";
                btnCreate.Text = "SAVE";
            }
            else
            {
                btnUpdate.Text = "UPDATE";
                btnCreate.Text = "CREATE";
                itemsEnableFalse();
                btnContactAdd.Enabled = false;
                btnContactDelete.Enabled = false;
                btnContactUpdate.Enabled = false;
                var customer = IME.Customer_CustomerID(CustomerCode.Text).FirstOrDefault();
                if (customer.c_name == null)
                {
                    //CREATE in cancel ı
                    var cw = IME.CustomerWorkers.Where(a => a.customerID == CustomerCode.Text);
                    //ilk önce Contact ların ve adress lerin verilerini sil sonra customer ın verisini sil
                    while (cw.Count() > 0)
                    {
                        IME.CustomerWorkers.Remove(cw.FirstOrDefault());
                        IME.SaveChanges();
                    }
                    //üstteki işlem adresses için de yapılmalı

                    //

                    //contact için de yapılmalı

                    //
                    Customer c = new Customer();
                    //c = (Customer)IME.Customer_CustomerID(CustomerCode.Text).FirstOrDefault();
                    c= c = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();
                    IME.Customers.Remove(c);
                    IME.SaveChanges();
                }
                CustomerDataGrid.Enabled = true;
                gridselectedindex = CustomerDataGrid.CurrentCell.RowIndex;
                customersearch();
            }
        }

        private void itemsClear()
        {
            #region itemClaer
            ContactType.SelectedIndex = -1;
            ContactDepartment.SelectedIndex = -1;
            ContactTitle.SelectedIndex = -1;
            ContactName.Text = "";
            ContactEmail.Text = "";
            ContactPhone.Text = "";
            ContactMobilePhone.Text = "";
            ContactFAX.Text = "";
            CommunicationLanguage.SelectedIndex = -1;
            ContactNotes.Text = "";
            MainCategory.SelectedIndex = -1;
            if (SubCategory.Items.Count != 0) SubCategory.SelectedIndex = -1;
            CompanyNotes.Text = "";
            WebAdress.Text = "";
            CustomerFax.Text = "";
            CustomerName.Text = "";
            txt3partyCode.Text = "";
            AccountingNotes.Text = "";
            Telephone.Text = "";
            CustomerCode.Text = "";
            AccountingNotes.Text = "";
            DiscountRate.Text = "";
            PaymentMethod.SelectedIndex = -1;
            TermsofPayments.SelectedIndex = -1;
            TaxOffice.Text = "";
            Represantative2.SelectedIndex = -1;
            Represantative1.SelectedIndex = -1;
            InvCurrencyName.SelectedIndex = -1;
            InvCurrencyType.Text = "";
            QuoCurrencyType.Text = "";
            QuoCurrencyName.SelectedIndex = -1;
            AccountRepresentary.SelectedIndex = -1;
            CreditLimit.Text = "";
            taxNumber.Text = "";
            factor.Text = "";
            Capital.SelectedIndex = -1;
            ContactEmail.Text = "";
            AdressList.DataSource = null;
            ContactList.DataSource = null;
            AddressType.SelectedIndex = -1;
            txtAdressTitle.Text = "";
            AddressDetails.Text = "";
            cbMainContact.SelectedIndex = -1;
            cbCountry.SelectedIndex = -1;
            cbCity.SelectedIndex = -1;
            PostCode.Text = "";
            cbTown.SelectedIndex = -1;
            ContactAdress.SelectedIndex = -1;
            #endregion

        }

        private void itemsEnableFalse()
        {
            #region itemsEnableFalse
            SubCategory.Enabled = false;
            MainCategory.Enabled = false;
            cbMainContact.Enabled = false;
            Represantative1.Enabled = false;
            CompanyNotes.Enabled = false;
            WebAdress.Enabled = false;

            CustomerFax.Enabled = false;
            CustomerName.Enabled = false;
            txt3partyCode.Enabled = false;
            Telephone.Enabled = false;
            CustomerCode.Enabled = false;
            tab_adresses.Enabled = false;
            tab_contact.Enabled = false;
            AccountingNotes.Enabled = false;
            DiscountRate.Enabled = false;
            PaymentMethod.Enabled = false;
            TermsofPayments.Enabled = false;
            TaxOffice.Enabled = false;
            btnContactAdd.Enabled = true;
            txtSearch.Enabled = true;
            Search.Enabled = true;
            if (ContactList.DataSource != null)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }
            departmentAdd.Enabled = false;
            Represantative2.Enabled = false;
            Represantative1.Enabled = false;
            InvCurrencyName.Enabled = false;
            InvCurrencyType.Enabled = false;
            QuoCurrencyName.Enabled = false;
            QuoCurrencyType.Enabled = false;

            AccountRepresentary.Enabled = false;
            CreditLimit.Enabled = false;
            taxNumber.Enabled = false;
            rb_passive.Enabled = false;
            rb_active.Enabled = false;
            factor.Enabled = false;
            Capital.Enabled = false;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            btnContactDone.Enabled = false;
            btnContactCancel.Enabled = false;
            CustomerDataGrid.Enabled = true;
            #endregion
        }

        private void itemsEnableTrue()
        {
            #region itemsEnableTrue
            SubCategory.Enabled = true;
            MainCategory.Enabled = true;
            CompanyNotes.Enabled = true;
            cbMainContact.Enabled = true;
            Represantative1.Enabled = true;
            WebAdress.Enabled = true;
            cbMainContact.Enabled = true;
            CustomerFax.Enabled = true;
            CustomerName.Enabled = true;
            txt3partyCode.Enabled = true;
            Telephone.Enabled = true;
            tab_adresses.Enabled = true;
            tab_contact.Enabled = true;
            AccountingNotes.Enabled = true;
            DiscountRate.Enabled = true;
            PaymentMethod.Enabled = true;
            TermsofPayments.Enabled = true;
            TaxOffice.Enabled = true;
            Represantative2.Enabled = true;
            InvCurrencyName.Enabled = true;
            InvCurrencyType.Enabled = true;
            QuoCurrencyName.Enabled = true;
            QuoCurrencyType.Enabled = true;
            AccountRepresentary.Enabled = true;
            CreditLimit.Enabled = true;
            taxNumber.Enabled = true;

            rb_passive.Enabled = true;
            rb_active.Enabled = true;
            factor.Enabled = true;
            Capital.Enabled = true;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            btnContactDone.Enabled = true;
            btnContactCancel.Enabled = true;
            CustomerDataGrid.Enabled = false;
            Search.Enabled = false;
            txtSearch.Enabled = false;
            #endregion
        }

        private void ContactList_DataSourceChanged(object sender, EventArgs e)
        {
            if (ContactList.DataSource == null) { btnContactDelete.Enabled = false; btnContactUpdate.Enabled = false; }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridselectedindex = 0;
                searchtxt = txtSearch.Text;
                customersearch();
            }
        }

        private void AdressAdd_Click(object sender, EventArgs e)
        {
            btnAddressClick();
        }

        private void btnAddressClick()
        {
            isUpdateAdress = 0;
            AdressTabEnableTrue();
            AddressType.Text = "";
            cbCountry.Text = "";
            cbDefaultInvoiceAdress.Checked = false;
            cbDefaultDeliveryAdress.Checked = false;
            cbDefaultInvoiceAdress.Checked = false;
            cbCity.Text = "";
            cbTown.Text = "";
            PostCode.Text = "";
            AddressDetails.Text = "";
            AdressAdd.Visible = false;
            AdressCancel.Visible = true;
            AddressDel.Visible = false;
            AdressDone.Visible = true;
            AddressUpd.Visible = false;
            AdressList.Enabled = false;

            AddressType.Text = (ComboboxString);
            cbCountry.Text = (ComboboxString);
            cbCity.Text = (ComboboxString);
            cbTown.Text = (ComboboxString);
        }


        private void AddressUpd_Click(object sender, EventArgs e)
        {
            isUpdateAdress = 1;
            #region  AdressUpd
            AdressTabEnableTrue();
            AdressAdd.Visible = false;
            AdressCancel.Visible = true;
            AddressDel.Visible = false;
            AdressDone.Visible = true;
            AddressUpd.Visible = false;
            #endregion
        }

        private void AddressDel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Delete This Adress ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CustomerAddress ca = IME.CustomerAddresses.First(a => a.ID == ContactListItem.AdressID);
                IME.CustomerAddresses.Remove(ca);
                IME.SaveChanges();
                AdressList.DataSource = IME.CustomerAddresses.Where(customera => customera.CustomerID == CustomerCode.Text).ToList();
                AdressList.DisplayMember = "AdressTitle";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void AdressDone_Click(object sender, EventArgs e)
        {
            CustomerAddress ca = new CustomerAddress();
            if (isUpdateAdress == 1)
            {
                int caID = ((AdressList).SelectedItem as CustomerAddress).ID;
                ca = IME.CustomerAddresses.Where(a => a.ID == caID).FirstOrDefault();
            }
            else { ca = null; }

            if (ca != null)
            {
                ca.AddressType = AddressType.Text;
                //CustomerCode.Text;
                ca.CustomerID = CustomerCode.Text;
                ca.CountryID = ((cbCountry).SelectedItem as Country).ID;
                ca.CityID = ((cbCity).SelectedItem as City).ID;
                //AddresType
                ca.isInvoiceAddress = false;
                if (cbDefaultInvoiceAdress.Checked == false)
                {
                    ca.isInvoiceAddress = true;
                }
                ca.AdressTitle = txtAdressTitle.Text;

                ca.PostCode = PostCode.Text;
                ca.AdressDetails = AddressDetails.Text;
                if (cbDefaultInvoiceAdress.Checked) { ca.isInvoiceAddress = true; } else { ca.isInvoiceAddress = false; }
                if (cbDefaultDeliveryAdress.Checked) { ca.isDeliveryAddress = true; } else { ca.isDeliveryAddress = false; }
                IME.SaveChanges();
            }
            else
            {
                if (AddressControl())
                {
                    ca = new CustomerAddress
                    {
                        AddressType = AddressType.Text,
                        //CustomerCode.Text;
                        CustomerID = CustomerCode.Text,
                        CountryID = ((cbCountry).SelectedItem as Country).ID,
                        CityID = ((cbCity).SelectedItem as City).ID,
                        TownID = ((cbTown).SelectedItem as Town).ID,
                        //TownID = (int)cbTown.SelectedValue,
                        AdressTitle = txtAdressTitle.Text,
                        //AddresType
                        isInvoiceAddress = false,
                        PostCode = PostCode.Text,
                        AdressDetails = AddressDetails.Text
                    };
                }
                //if (!cbDefaultInvoiceAdress.Checked) { ca.isInvoiceAddress = true;}
                if (cbDefaultInvoiceAdress.Checked) { ca.isInvoiceAddress = true; } else { ca.isInvoiceAddress = false; }
                if (cbDefaultDeliveryAdress.Checked) { ca.isDeliveryAddress = true; } else { ca.isDeliveryAddress = false; }
                IME.CustomerAddresses.Add(ca);
                IME.SaveChanges();
            }
            AdressTabEnableFalse();
            if (btnCreate.Text == "CREATE")
            {
                txtSearch.Enabled = true;
                Search.Enabled = true;
                CustomerDataGrid.Enabled = true;
            }
            AdressList.DataSource = null;
            AdressList.DataSource = IME.CustomerAddresses.Where(customerw => customerw.CustomerID == CustomerCode.Text).ToList();
            AdressList.DisplayMember = "AdressTitle";
            ContactAdress.DataSource = null;
            ContactAdress.DataSource = IME.CustomerAddresses.Where(customerw => customerw.CustomerID == CustomerCode.Text).ToList();
            ContactAdress.DisplayMember = "AdressTitle";
            AdressAdd.Visible = true;
            AddressDel.Visible = true;
            AddressUpd.Visible = true;
            AdressCancel.Visible = false;
            AdressDone.Visible = false;
        }

        private void AdressCancel_Click(object sender, EventArgs e)
        {
            AdressTabEnableFalse();
            if (btnCreate.Text == "CREATE")
            {
                txtSearch.Enabled = true;
                Search.Enabled = true;
                CustomerDataGrid.Enabled = true;
            }
            AdressList.DataSource = IME.CustomerAddresses.Where(customerw => customerw.CustomerID == CustomerCode.Text).ToList();
            AdressList.DisplayMember = "AdressTitle";

            AdressAdd.Visible = true;
            AddressDel.Visible = true;
            AddressUpd.Visible = true;
            AdressCancel.Visible = false;
            AdressDone.Visible = false;
            customersearch();
        }

        private void Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbCity.DataSource = IME.Cities.Where(a => a.CountryID == ((Country)(cbCountry).SelectedItem).ID).ToList();
                cbCity.DisplayMember = "City_name";
                cbCity.ValueMember = "ID";

                if (cbCity.DataSource == null || cbCity.Items.Count == 0)
                {
                    cbCity.Text = "N/A";
                }
            }
            catch { }
        }

        private void City_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbTown.DataSource = IME.Towns.Where(a => a.CityID == ((City)(cbCity).SelectedItem).ID).ToList();
                cbTown.DisplayMember = "Town_name";
                cbTown.ValueMember = "ID";

                if (cbTown.DataSource == null || cbTown.Items.Count == 1)
                {
                    cbTown.Text = "N/A";
                }
            }
            catch { }
        }

        private void AdressList_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region AdressList
            //contact daki list box a tıklandığında contact ın bilgileri tıklanan göre doldurulmasıse
            int cw_ID = 0;
            try { cw_ID = ((CustomerAddress)((ListBox)sender).SelectedItem).ID; } catch { cw_ID = 0; }

            if (ContactListItem.AdressID != cw_ID)
            {
                ContactListItem.AdressID = cw_ID;
                var contact1 = IME.CustomerAddresses.Where(cw => cw.ID == cw_ID).ToList();
                foreach (var a in contact1)
                {
                    if (a.isDeliveryAddress != null && (bool)a.isDeliveryAddress)
                    {
                        cbDefaultDeliveryAdress.Checked = true;
                    }
                    else
                    {
                        cbDefaultDeliveryAdress.Checked = false;
                    }

                    if (a.isInvoiceAddress != null && (bool)a.isInvoiceAddress)
                    {
                        cbDefaultInvoiceAdress.Checked = true;
                    }
                    else
                    {
                        cbDefaultInvoiceAdress.Checked = false;
                    }
                    txtAdressTitle.Text = a.AdressTitle;
                    cbCountry.SelectedItem = a.Country;
                    AddressType.SelectedIndex = AddressType.FindStringExact(a.AddressType);
                    if (a.City != null)
                    {
                        cbCity.SelectedValue = a.CityID;
                    }
                    if (a.Town != null)
                    {
                        cbTown.SelectedValue = a.TownID;
                    }
                    PostCode.Text = a.PostCode;
                    AddressDetails.Text = a.AdressDetails;
                }
            }
            #endregion
        }

        //private void WebAdress_Leave(object sender, EventArgs e)
        //{
        //    string pattern = @"^(www\.)([\w]+)\.([\w]+)$";
        //    if (Regex.IsMatch(WebAdress.Text, pattern))
        //    {

        //    }
        //    else
        //    {
        //        MessageBox.Show("Example: www.rsdelivers.com ", "Please provide valid Web Address !");
        //        WebAdress.Focus();
        //        return;
        //    }
        //}

        private void Telephone_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(Telephone.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please provide valid Phone Number !");
                Telephone.Focus();
                return;
            }
        }

        private void CustomerFax_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(CustomerFax.Text, pattern) || CustomerFax.Text == string.Empty)
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please provide valid Fax Number !");
                CustomerFax.Focus();
                return;
            }
        }

        private void ContactEmail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(ContactEmail.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("info@imeturkey.com", "Please provide valid Mail address !");
                ContactEmail.Focus();
                return;
            }
        }

        private void ContactPhone_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(ContactPhone.Text, pattern) || ContactPhone.Text == string.Empty)
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please provide valid Phone Number !");
                ContactPhone.Focus();
                return;
            }
        }

        private void ContactMobilePhone_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(ContactMobilePhone.Text, pattern) || ContactMobilePhone.Text == string.Empty)
            {

            }
            else
            {
                MessageBox.Show("Example: 0530 283 38 02 ", "Please provide valid Mobile Phone Number !");
                ContactMobilePhone.Focus();
                return;
            }
        }

        private void ContactFAX_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(ContactFAX.Text, pattern) || ContactFAX.Text == string.Empty)
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please provide valid Fax Number !");
                ContactFAX.Focus();
                return;
            }
        }

        private void Represantative1_MouseClick(object sender, MouseEventArgs e)
        {
            Represantative1.DataSource = IME.Workers.ToList();
            Represantative1.DisplayMember = "NameLastName";
        }

        private void ComboboxElleGirisEngelleme(KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void Represantative2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void MainCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void SubCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void Represantative1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void Capital_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void cbMainContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void AccountRepresentary_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void TermsofPayments_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void PaymentMethod_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void QuoCurrencyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void QuoCurrencyType_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void InvCurrencyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void InvCurrencyType_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void AddressType_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void cbCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void cbCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void cbTown_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void ContactType_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void ContactDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void ContactTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void CommunicationLanguage_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboboxElleGirisEngelleme(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MakeTextUpperCase((TextBox)sender);
        }

        private void AddressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtAdressTitle.Text = string.Empty;
        }

        private bool ControlSave()
        {
            bool isSave = true;
            string ErrorMessage = string.Empty;
            if (CustomerName.Text == null || CustomerName.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Company's Name\n"; isSave = false; }
            //if (MainCategory.Text == ComboboxString) { ErrorMessage = ErrorMessage + "Please Choose Main Category Company\n"; isSave = false; }
            //if (SubCategory.Text == ComboboxString) { ErrorMessage = ErrorMessage + "Please Choose SubCategory of Company\n"; isSave = false; }
            //if (Capital.Text == ComboboxString) { ErrorMessage = ErrorMessage + "Please Choose Capital of the Company\n"; isSave = false; }
            //if (Telephone.Text == null || Telephone.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Company's Phone correctly or Delete\n"; isSave = false; }
            //if (ContactList.Items.Count == 0) { ErrorMessage = ErrorMessage + "Please Enter a Contact\n"; isSave = false; }
            //if (cbCity.Text == ComboboxString) { ErrorMessage = ErrorMessage + "Please Choose City of Company\n"; isSave = false; }
            //if (cbTown.Text == ComboboxString) { ErrorMessage = ErrorMessage + "Please Choose Town of Company\n"; isSave = false; }
            if (isSave == true) { return true; } else { MessageBox.Show(ErrorMessage); return false; }
        }

        private void CompanyNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab = tabControl1.TabPages["tab_account"];
            }
        }

        private void TownAdd_Click(object sender, EventArgs e)
        {
            if (cbCity.SelectedValue != null && cbCity.Text != ComboboxString)
            {
                int city = Convert.ToInt32(cbCity.SelectedValue);
                int country = Convert.ToInt32(cbCountry.SelectedValue);
                FormTownAdd form = new FormTownAdd(country, city);
                this.SendToBack();
                form.ShowDialog();
                this.BringToFront();
                cbTown.Refresh();

                cbTown.DataSource = IME.Towns.Where(a => a.CityID == (int)cbCity.SelectedValue).ToList();
                cbTown.DisplayMember = "Town_name";
                cbTown.ValueMember = "ID";
            }
            else { MessageBox.Show("Please select a City"); }
        }

        private void btnAddMainCategory_Click(object sender, EventArgs e)
        {
            CustomerMainCategory form = new CustomerMainCategory();
            form.ShowDialog();
            MainCategory.DataSource = IME.CustomerCategories.ToList();
            MainCategory.DisplayMember = "categoryname";
            MainCategory.ValueMember = "ID";
        }

        private void btnAddSubcategory_Click(object sender, EventArgs e)
        {
            if (MainCategory.SelectedValue != null && MainCategory.Text != ComboboxString)
            {
                int categoryID = Convert.ToInt32(MainCategory.SelectedValue);
                CustomerSubCategory form = new CustomerSubCategory(categoryID);
                form.ShowDialog();
                SubCategory.DataSource = IME.CustomerSubCategories.Where(a => a.categoryID == (int)MainCategory.SelectedValue).ToList();
                SubCategory.DisplayMember = "subcategoryname";
                SubCategory.ValueMember = "ID";
            }
            else { MessageBox.Show("Please select a Maincategory"); }
        }

        private void factor_Leave(object sender, EventArgs e)
        {
            if (factor.Text == "") factor.Text = 0.ToString();
            decimal factorValue = Decimal.Parse(factor.Text);
            DiscountRate.Text = (100 - ((factorValue * 100) / Utils.getManagement().Factor)).ToString();
            DiscountRate.Text = String.Format("{0:0.0000}", Decimal.Parse(DiscountRate.Text)).ToString();

        }

        private void DiscountRate_Leave(object sender, EventArgs e)
        {
            decimal DiscountRateValue = Decimal.Parse(DiscountRate.Text);
            factor.Text = (Utils.getManagement().Factor - ((DiscountRateValue * Utils.getManagement().Factor) / 100)).ToString();
            factor.Text = String.Format("{0:0.0000}", Decimal.Parse(factor.Text)).ToString();
        }

        private void CustomerDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            itemsClear();
            gridselectedindex = CustomerDataGrid.CurrentCell.RowIndex;
            customerClicksearch();
        }

        private void MakeTextUpperCase(TextBox txtBox)
        {
            txtBox.Text = txtBox.Text.ToUpperInvariant();
        }

        private void CustomerName_Leave(object sender, EventArgs e)
        {
            MakeTextUpperCase((TextBox)sender);
        }

        private void txtAdressTitle_Leave(object sender, EventArgs e)
        {
            MakeTextUpperCase((TextBox)sender);
        }

        private void ContactName_Leave(object sender, EventArgs e)
        {
            MakeTextUpperCase((TextBox)sender);
        }

        private void TaxOffice_Leave(object sender, EventArgs e)
        {
            MakeTextUpperCase((TextBox)sender);
        }

        //public static void EnableTab(TabPage page, bool enable)
        //{
        //    EnableControls(page.Controls, enable);
        //}
        //private static void EnableControls(Control.ControlCollection ctls, bool enable)
        //{
        //    foreach (Control ctl in ctls)
        //    {
        //        ctl.Enabled = enable;
        //        EnableControls(ctl.Controls, enable);
        //    }
        //}

        //public static void DisablePage(TabPage pTabPage)
        //{
        //    pTabPage.Enabled = false;
        //}

        //private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    // Check Credentials Here
        //    if (tabControl1.SelectedTab == tab_contact)
        //    {
        //        tabControl1.SelectedTab = tab_contact;
        //    }
        //}

        private bool AddressControl()
        {
            bool isSave = true;
            string ErrorMessage = string.Empty;
            if (cbCity.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter City"; isSave = false; }
            if (cbTown.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Town"; isSave = false; }
            if (isSave == true) { return true; } else { MessageBox.Show(ErrorMessage); return false; }
        }

        private void CityAdd_Click(object sender, EventArgs e)
        {
            if (cbCountry.SelectedValue != null && cbCountry.Text != ComboboxString)
            {
                int country = Convert.ToInt32(cbCountry.SelectedValue);
                frmCityAdd form = new frmCityAdd(country);
                form.ShowDialog();
                cbCity.DataSource = IME.Cities.Where(a => a.CountryID == (int)cbCountry.SelectedValue).ToList();
                cbCity.DisplayMember = "City_name";
                cbCity.ValueMember = "ID";
            }
            else { MessageBox.Show("Please select a Country"); }
        }

        private void txtSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridselectedindex = 0;
                searchtxt = txtSearch.Text;
                customersearch();
            }
        }

        private void btnLogoSave_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "UPDATE")
            {
                logoCustAdd();
            }
            else
            {
                logoCustAdd();
            }
        }

        private void logoCustAdd()
        {
            #region CustomerForLogo

            //string str = MyConnect.Ornekle.ExecuteScalar(Utils.ConnectionStringLogo, "SELECT CODE FROM L_COUNTRY WHERE LOGICALREF = " + this.cbCountry.SelectedValue._ToIntegerR(), CommandType.Text, 60, new KomutArgumanlari_[0]).ToString();
            if (/*this.GelenID*/0 == 0)
            {
                KomutArgumanlari_[] arguman = new KomutArgumanlari_[1];
                KomutArgumanlari_ i_1 = new KomutArgumanlari_
                {
                    Parametre = this.CustomerCode.Text,
                    ParametreAdi = "@param"
                };
                arguman[0] = i_1;
                if (MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("SELECT COUNT(*) FROM LG_{0}_CLCARD WHERE CODE = @param", Utils.FrmNo), CommandType.Text, 60, arguman) > 0)
                {
                    string str3 = MyConnect.Ornekle.ExecuteScalar(Utils.ConnectionStringLogo, string.Format("SELECT MAX(CODE) FROM LG_{0}_CLCARD WHERE CODE LIKE 'SD%'", Utils.FrmNo), CommandType.Text, 60, new KomutArgumanlari_[0])._ToString();
                    str3 = str3.Substring(0, 2) + (str3.Replace("SD", "")._ToIntegerR() + 1);
                    this.CustomerCode.Text = str3;
                }
                clsLogClass cls = new clsLogClass
                {
                    TABLE_ID = 0x3f6,
                    DONE_OPERATION = string.Format("{0} kodlu cari eklendi.", this.CustomerCode.Text),
                    RECORD_ID = 0,
                    TIME = DateTime.Now
                };
                clsLog.LogKayit(cls);
                int num = MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("select ISNULL(MAX(CL.LOWLEVELCODES1)+1,1) from LG_{0}_CLCARD AS CL", Utils.FrmNo), CommandType.Text, 60, new KomutArgumanlari_[0]);
                string str2 = (/*this.Nerden*/1 == 0) ? "'RS'" : "''";
                object[] objArray1 = new object[] { "INSERT INTO LG_{0}_CLCARD (ACTIVE, CARDTYPE, CODE, DEFINITION_, SPECODE, CYPHCODE, ADDR1, ADDR2, CITY, COUNTRY, POSTCODE, TELNRS1, TELNRS2, FAXNR, TAXNR, TAXOFFICE, INCHARGE, DISCRATE, EXTENREF, PAYMENTREF, EMAILADDR, WEBADDR, WARNMETHOD, WARNEMAILADDR, WARNFAXNR, CLANGUAGE, VATNR, BLOCKED, BANKBRANCHS1, BANKBRANCHS2, BANKBRANCHS3, BANKBRANCHS4, BANKBRANCHS5, BANKBRANCHS6, BANKBRANCHS7, BANKACCOUNTS1, BANKACCOUNTS2, BANKACCOUNTS3, BANKACCOUNTS4, BANKACCOUNTS5, BANKACCOUNTS6, BANKACCOUNTS7, DELIVERYMETHOD, DELIVERYFIRM, CCURRENCY, TEXTINC, SITEID, RECSTATUS, ORGLOGICREF, EDINO, TRADINGGRP, CAPIBLOCK_CREATEDBY, CAPIBLOCK_CREADEDDATE, CAPIBLOCK_CREATEDHOUR, CAPIBLOCK_CREATEDMIN, CAPIBLOCK_CREATEDSEC, CAPIBLOCK_MODIFIEDBY, CAPIBLOCK_MODIFIEDDATE, CAPIBLOCK_MODIFIEDHOUR, CAPIBLOCK_MODIFIEDMIN, CAPIBLOCK_MODIFIEDSEC, PAYMENTPROC, CRATEDIFFPROC, WFSTATUS, PPGROUPCODE, PPGROUPREF, TAXOFFCODE, TOWNCODE, TOWN, DISTRICTCODE, DISTRICT, CITYCODE, COUNTRYCODE, ORDSENDMETHOD, ORDSENDEMAILADDR, ORDSENDFAXNR, DSPSENDMETHOD, DSPSENDEMAILADDR, DSPSENDFAXNR, INVSENDMETHOD, INVSENDEMAILADDR, INVSENDFAXNR, SUBSCRIBERSTAT, SUBSCRIBEREXT, AUTOPAIDBANK, PAYMENTTYPE, LASTSENDREMLEV, EXTACCESSFLAGS, ORDSENDFORMAT, DSPSENDFORMAT, INVSENDFORMAT, REMSENDFORMAT, STORECREDITCARDNO, CLORDFREQ, ORDDAY, LOGOID, LIDCONFIRMED, EXPREGNO, EXPDOCNO, EXPBUSTYPREF, INVPRINTCNT, PIECEORDINFLICT, COLLECTINVOICING, EBUSDATASENDTYPE, INISTATUSFLAGS, SLSORDERSTATUS, SLSORDERPRICE, LTRSENDMETHOD, LTRSENDEMAILADDR, LTRSENDFAXNR, LTRSENDFORMAT, IMAGEINC, CELLPHONE, SAMEITEMCODEUSE, STATECODE, STATENAME, WFLOWCRDREF, PARENTCLREF, LOWLEVELCODES1, LOWLEVELCODES2, LOWLEVELCODES3, LOWLEVELCODES4, LOWLEVELCODES5, LOWLEVELCODES6, LOWLEVELCODES7, LOWLEVELCODES8, LOWLEVELCODES9, LOWLEVELCODES10, TELCODES1, TELCODES2, FAXCODE, PURCHBRWS, SALESBRWS, IMPBRWS, EXPBRWS, FINBRWS, ORGLOGOID, ADDTOREFLIST, TEXTREFTR, TEXTREFEN, ARPQUOTEINC, CLCRM, GRPFIRMNR, CONSCODEREF, SPECODE2, SPECODE3, SPECODE4, SPECODE5, OFFSENDMETHOD, OFFSENDEMAILADDR, OFFSENDFAXNR, OFFSENDFORMAT, EBANKNO, LOANGRPCTRL, BANKNAMES1, BANKNAMES2, BANKNAMES3, BANKNAMES4, BANKNAMES5, BANKNAMES6, BANKNAMES7, LDXFIRMNR, MAPID, LONGITUDE, LATITUTE, CITYID, TOWNID, BANKIBANS1, BANKIBANS2, BANKIBANS3, BANKIBANS4, BANKIBANS5, BANKIBANS6, BANKIBANS7, TCKNO, ISPERSCOMP, EXTSENDMETHOD, EXTSENDEMAILADDR, EXTSENDFAXNR, EXTSENDFORMAT, BANKBICS1, BANKBICS2, BANKBICS3, BANKBICS4, BANKBICS5, BANKBICS6, BANKBICS7, CASHREF, USEDINPERIODS, INCHARGE2, INCHARGE3, EMAILADDR2, EMAILADDR3, RSKLIMCR, RSKDUEDATECR, RSKAGINGCR, RSKAGINGDAY, ACCEPTEINV, EINVOICEID, PROFILEID, BANKBCURRENCY1, BANKBCURRENCY2, BANKBCURRENCY3, BANKBCURRENCY4, BANKBCURRENCY5, BANKBCURRENCY6, BANKBCURRENCY7, PURCORDERSTATUS, PURCORDERPRICE, ISFOREIGN, SHIPBEGTIME1, SHIPBEGTIME2, SHIPBEGTIME3, SHIPENDTIME1, SHIPENDTIME2, SHIPENDTIME3, DBSLIMIT1, DBSLIMIT2, DBSLIMIT3, DBSLIMIT4, DBSLIMIT5, DBSLIMIT6, DBSLIMIT7, DBSTOTAL1, DBSTOTAL2, DBSTOTAL3, DBSTOTAL4, DBSTOTAL5, DBSTOTAL6, DBSTOTAL7, DBSBANKNO1, DBSBANKNO2, DBSBANKNO3, DBSBANKNO4, DBSBANKNO5, DBSBANKNO6, DBSBANKNO7, DBSRISKCNTRL1, DBSRISKCNTRL2, DBSRISKCNTRL3, DBSRISKCNTRL4, DBSRISKCNTRL5, DBSRISKCNTRL6, DBSRISKCNTRL7, DBSBANKCURRENCY1, DBSBANKCURRENCY2, DBSBANKCURRENCY3, DBSBANKCURRENCY4, DBSBANKCURRENCY5, DBSBANKCURRENCY6, DBSBANKCURRENCY7, BANKCORRPACC1, BANKCORRPACC2, BANKCORRPACC3, BANKCORRPACC4, BANKCORRPACC5, BANKCORRPACC6, BANKCORRPACC7, BANKVOEN1, BANKVOEN2, BANKVOEN3, BANKVOEN4, BANKVOEN5, BANKVOEN6, BANKVOEN7, EINVOICETYPE, DEFINITION2, TELEXTNUMS1, TELEXTNUMS2, FAXEXTNUM, FACEBOOKURL, TWITTERURL, APPLEID, SKYPEID, GLOBALID, GUID, DUEDATECOUNT, DUEDATELIMIT, DUEDATETRACK, DUEDATECONTROL1, DUEDATECONTROL2, DUEDATECONTROL3, DUEDATECONTROL4, DUEDATECONTROL5, DUEDATECONTROL6, DUEDATECONTROL7, DUEDATECONTROL8, DUEDATECONTROL9, DUEDATECONTROL10, DUEDATECONTROL11, DUEDATECONTROL12, DUEDATECONTROL13, DUEDATECONTROL14, DUEDATECONTROL15, ADRESSNO, POSTLABELCODE, SENDERLABELCODE, CLOSEDATECOUNT, CLOSEDATETRACK, DEGACTIVE, DEGCURR, NAME, SURNAME, LABELINFO, DEFBNACCREF, PROJECTREF, DISCTYPE) VALUES (0, ", 3, ", @Kodu, @Unvan, ", str2, ", @CYPHCODE, @Adres1, @Adres2, @CtName, @COUNTRY, @Pc, @Tel, '', @Fx, @Vn, @Vd, @Yetkili, 0, 0, @PAYMENTREF, @MailAdres, @WEBADDR, 0, '', '', 1, '', 0, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 0, 0, 0, 1, 0, '', '', 1, GETDATE(), DATEPART(hour, GETDATE()), DATEPART(minute, GETDATE()), DATEPART(second, GETDATE()), 0, NULL, 0, 0, 0, 0, 0, 0, '', 0, '', @TwC, @TwN, '', '', @CityCode, @COUNTRYCODE, 0, '', '', 0, '', '', 0, '', '', 0, '', '', 0, 0, 0, 0, 0, 0, 0, '', 1, 0, '', 0, '', '', 0, 1, 0, 0, 0, 0, 0, 0, 0, '', '', 0, 0, '', 0, '', '', 0, 0, {1}, 0, 0, 0, 0, 0, 0, 0, 0, 0, @AlanKodu, '', '', 1, 1, 1, 1, 1, '', 0, 0, 0, 0, 0, 0, 0, '', @Credit, @Indirim, @Temsilci, 0, '', '', 0, 0, 0, '', '', '', '', '', '', '', 0, '', '', '', '', '', '', '', '', '', '', '', '', '', 0, 0, '', '', 0, '', '', '', '', '', '', '', 0, 0, '', '', '', '', 0, 0, 0, 0, 0, '', 2, '', '', '', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', '', '', '', '', '', '', '', '', '', '', '', '', 0, '', @Dahili, '', '', '', '', '', '', '', NEWID(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', '', 0, 0, 0, 0, '', '', 0, 0, 0, 0); SELECT SCOPE_IDENTITY()" };
                KomutArgumanlari_[] i_Array2 = new KomutArgumanlari_[0x19];
                KomutArgumanlari_ i_2 = new KomutArgumanlari_
                {
                    Parametre = this.CustomerCode.Text.ToUpper(),
                    ParametreAdi = "@Kodu"
                };
                i_Array2[0] = i_2;
                KomutArgumanlari_ i_3 = new KomutArgumanlari_
                {
                    Parametre = this.CustomerName.Text.ToUpper(),
                    ParametreAdi = "@Unvan"
                };
                i_Array2[1] = i_3;
                KomutArgumanlari_ i_ = new KomutArgumanlari_
                {
                    Parametre = (/*this.Nerden*/1 == 0) ? this.CustomerCode.Text.Split(new char[] { '-' })[0].ToString() : "0",
                    ParametreAdi = "@CYPHCODE"
                };
                i_Array2[2] = i_;
                KomutArgumanlari_ i_4 = new KomutArgumanlari_
                {
                    Parametre = this.cbCountry.Text,
                    ParametreAdi = "@COUNTRY"
                };
                i_Array2[3] = i_4;
                KomutArgumanlari_ i_5 = new KomutArgumanlari_
                {
                    Parametre = this.cbCountry.SelectedValue._ToIntegerR(),
                    ParametreAdi = "@COUNTRYCODE"
                };
                i_Array2[4] = i_5;
                KomutArgumanlari_ i_6 = new KomutArgumanlari_
                {
                    Parametre = this.txtAddress1.Text.ToUpper(),
                    ParametreAdi = "@Adres1"
                };
                i_Array2[5] = i_6;
                KomutArgumanlari_ i_7 = new KomutArgumanlari_
                {
                    Parametre = this.txtAddress2.Text.ToUpper(),
                    ParametreAdi = "@Adres2"
                };
                i_Array2[6] = i_7;
                KomutArgumanlari_ i_8 = new KomutArgumanlari_
                {
                    Parametre = this.Telephone.Text,
                    ParametreAdi = "@Tel"
                };
                i_Array2[7] = i_8;
                KomutArgumanlari_ i_9 = new KomutArgumanlari_
                {
                    Parametre = this.CustomerFax.Text,
                    ParametreAdi = "@Fx"
                };
                i_Array2[8] = i_9;
                KomutArgumanlari_ i_10 = new KomutArgumanlari_
                {
                    Parametre = this.PaymentMethod.SelectedValue,
                    ParametreAdi = "@PAYMENTREF"
                };
                i_Array2[9] = i_10;
                KomutArgumanlari_ i_11 = new KomutArgumanlari_
                {
                    Parametre = "",
                    ParametreAdi = "@Yetkili"
                };
                i_Array2[10] = i_11;
                KomutArgumanlari_ i_12 = new KomutArgumanlari_
                {
                    Parametre = (cbMainContact.SelectedItem as CustomerWorker).cw_email,
                    ParametreAdi = "@MailAdres"
                };
                i_Array2[11] = i_12;
                KomutArgumanlari_ i_13 = new KomutArgumanlari_
                {
                    Parametre = this.cbCity.Text,
                    ParametreAdi = "@CtName"
                };
                i_Array2[12] = i_13;
                KomutArgumanlari_ i_14 = new KomutArgumanlari_
                {
                    Parametre = this.Represantative1.SelectedValue,
                    ParametreAdi = "@Temsilci"
                };
                i_Array2[13] = i_14;
                KomutArgumanlari_ i_15 = new KomutArgumanlari_
                {
                    Parametre = this.CreditLimit.Text,
                    ParametreAdi = "@Credit"
                };
                i_Array2[14] = i_15;
                KomutArgumanlari_ i_16 = new KomutArgumanlari_
                {
                    Parametre = this.DiscountRate.Text,
                    ParametreAdi = "@Indirim"
                };
                i_Array2[15] = i_16;
                KomutArgumanlari_ i_17 = new KomutArgumanlari_
                {
                    Parametre = "",
                    ParametreAdi = "@AlanKodu"
                };
                i_Array2[0x10] = i_17;
                KomutArgumanlari_ i_18 = new KomutArgumanlari_
                {
                    Parametre = this.txtExtNumber.Text,
                    ParametreAdi = "@Dahili"
                };
                i_Array2[0x11] = i_18;
                KomutArgumanlari_ i_19 = new KomutArgumanlari_
                {
                    Parametre = this.PostCode.Text,
                    ParametreAdi = "@Pc"
                };
                i_Array2[0x12] = i_19;
                KomutArgumanlari_ i_20 = new KomutArgumanlari_
                {
                    Parametre = this.taxNumber.Text,
                    ParametreAdi = "@Vn"
                };
                i_Array2[0x13] = i_20;
                KomutArgumanlari_ i_21 = new KomutArgumanlari_
                {
                    Parametre = this.cbTown.SelectedValue._ToIntegerR(),
                    ParametreAdi = "@TwC"
                };
                i_Array2[20] = i_21;
                KomutArgumanlari_ i_22 = new KomutArgumanlari_
                {
                    Parametre = this.cbCity.SelectedValue._ToIntegerR(),
                    ParametreAdi = "@CityCode"
                };
                i_Array2[0x15] = i_22;
                KomutArgumanlari_ i_23 = new KomutArgumanlari_
                {
                    Parametre = this.cbTown.Text,
                    ParametreAdi = "@TwN"
                };
                i_Array2[0x16] = i_23;
                KomutArgumanlari_ i_24 = new KomutArgumanlari_
                {
                    Parametre = this.TaxOffice.Text.ToUpper(),
                    ParametreAdi = "@Vd"
                };
                i_Array2[0x17] = i_24;
                KomutArgumanlari_ i_25 = new KomutArgumanlari_
                {
                    Parametre = this.WebAdress.Text,
                    ParametreAdi = "@WEBADDR"
                };
                i_Array2[0x18] = i_25;
                int num2 = MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format(string.Concat(objArray1), Utils.FrmNo, num), CommandType.Text, 60, i_Array2);
                if (num2 > 0)
                {
                    Bolgeler.GroupGuncelle(this.CustomerCode.Text.ToUpper(), this.MainCategory.SelectedValue._ToIntegerR(), this.SubCategory.SelectedValue._ToIntegerR(), this.Capital.SelectedValue._ToIntegerR());
                    clsLogClass class2 = new clsLogClass
                    {
                        TABLE_ID = 0x3f6,
                        DONE_OPERATION = string.Format("{0} kodlu cari g\x00fcncellendi.", this.CustomerCode.Text),
                        RECORD_ID = 0,
                        TIME = DateTime.Now
                    };
                    clsLog.LogKayit(class2);
                    MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_{1}_CLRNUMS (CLCARDREF, RISKTYPE, RISKOVER, PS, KC, RISKTOTAL, DESPRISKTOTAL, RISKLIMIT, RISKBALANCED, CEKRISKFACTOR, SENETRISKFACTOR, CEK0_DEBIT, CEK0_CREDIT, CEK1_DEBIT, CEK1_CREDIT, SENET0_DEBIT, SENET0_CREDIT, SENET1_DEBIT, SENET1_CREDIT, CEKCURR0_DEBIT, CEKCURR0_CREDIT, CEKCURR1_DEBIT, CEKCURR1_CREDIT, SENETCURR0_DEBIT, SENETCURR0_CREDIT, SENETCURR1_DEBIT, SENETCURR1_CREDIT, ORDRISKOVER, DESPRISKOVER, USEREPRISK, REPRISKTOTAL, REPDESPRISKTOTAL, REPRISKLIMIT, REPRISKBALANCED, REPPS, REPKC, ORDRISKTOTAL, ORDRISKTOTALSUGG, REPORDRISKTOTAL, REPORDRISKTOTALSUGG, RISKTYPES1, RISKTYPES2, RISKTYPES3, RISKTYPES4, RISKTYPES5, RISKTYPES6, RISKTYPES7, RISKTYPES8, RISKTYPES9, RISKTYPES10, RISKTYPES11, RISKTYPES12, RISKTYPES13, RISKTYPES14, RISKTYPES15, CSTCEKRISKFACTOR, CSTSENETRISKFACTOR, RISKGRPCONTROL, ACCRISKOVER, CSTCSRISKOVER, MYCSRISKOVER, RISKCTRLTYPE, ACCRISKTOTAL, REPACCRISKTOTAL, CSTCSRISKTOTAL, REPCSTCSRISKTOTAL, MYCSRISKTOTAL, REPMYCSRISKTOTAL, ACCRISKLIMIT, REPACCRISKLIMIT, CSTCSRISKLIMIT, REPCSTCSRISKLIMIT, MYCSRISKLIMIT, REPMYCSRISKLIMIT, DESPRISKLIMIT, REPDESPRISKLIMIT, ORDRISKLIMIT, REPORDRISKLIMIT, ORDRISKLIMITSUGG, REPORDRISKLIMITSUGG, ACCRSKBLNCED, REPACCRSKBLNCED, CSTCSRSKBLNCED, REPCSTCSRSKBLNCED, MYCSRSKBLNCED, REPMYCSRSKBLNCED, DESPRSKBLNCED, REPDESPRSKBLNCED, ORDRSKBLNCED, REPORDRSKBLNCED, ORDRSKBLNCEDSUG, REPORDRSKBLNCEDSUG, ORDRISKOVERSUGG, CSDOWNSRISK, CSTCSCIRORISKOVER, CSTCIROCEKRISKFAC, CSTCIROSENETRISKFAC, CSCIRODOWNSRISK, CSTCSCIRORISKLIMIT, REPCSTCSCIRORISKLIM, CSTCSCIRORSKBLNCED, REPCSTCSCIRORSKBLN, CSTCSOWNRISKTOTAL, REPCSTCSOWNRISKTOT, CSTCSCIRORISKTOTAL, REPCSTCSCIRORISKTOT, DESPRISKOVERSUG, DESPRISKLIMITSUG, REPDESPRISKLIMITSUG, DESPRISKTOTALSUG, REPDESPRISKTOTALSUG, DESPRSKBLNCEDSUG, REPDESPRSKBLNCEDSUG) VALUES ({2}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)", Utils.FrmNo, Utils.DnmNo, num2), CommandType.Text, 60, new KomutArgumanlari_[0]);
                    MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_{1}_CLCOLLATRLRISK(CLCARDREF, RISKTYPE, RISKOVER, ORDRISKOVER, DESPRISKOVER, USEREPRISK, PCOLLATRLTOTAL, REPPCOLLATRLTOTAL, SCOLLATRLTOTAL, REPSCOLLATRLTOTAL, RISKTOTAL, REPRISKTOTAL, DESPRISKTOTAL, REPDESPRISKTOTAL, RISKLIMIT, REPRISKLIMIT, RISKBALANCED, REPRISKBALANCED, ORDRISKTOTAL, REPORDRISKTOTAL, ORDRISKTOTALSUGG, REPORDRISKTOTALSUGG) VALUES ({2}, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)", Utils.FrmNo, Utils.DnmNo, num2), CommandType.Text, 60, new KomutArgumanlari_[0]);
                    //this.CariyeNotEkle(this.CustomerCode.Text, this.txtNot.Text);
                    if (DateTime.Now.Year > 0x7e0)
                    {
                        KomutArgumanlari_[] i_Array3 = new KomutArgumanlari_[14];
                        KomutArgumanlari_ i_26 = new KomutArgumanlari_
                        {
                            Parametre = num2,
                            ParametreAdi = "@CLIENTREF"
                        };
                        i_Array3[0] = i_26;
                        KomutArgumanlari_ i_27 = new KomutArgumanlari_
                        {
                            Parametre = this.txtAddress1.Text.ToUpper(),
                            ParametreAdi = "@ADDR1"
                        };
                        i_Array3[1] = i_27;
                        KomutArgumanlari_ i_28 = new KomutArgumanlari_
                        {
                            Parametre = this.txtAddress2.Text.ToUpper(),
                            ParametreAdi = "@ADDR2"
                        };
                        i_Array3[2] = i_28;
                        KomutArgumanlari_ i_29 = new KomutArgumanlari_
                        {
                            Parametre = this.cbCity.Text,
                            ParametreAdi = "@CITY"
                        };
                        i_Array3[3] = i_29;
                        KomutArgumanlari_ i_30 = new KomutArgumanlari_
                        {
                            Parametre = this.cbCountry.Text,
                            ParametreAdi = "@COUNTRY"
                        };
                        i_Array3[4] = i_30;
                        KomutArgumanlari_ i_31 = new KomutArgumanlari_
                        {
                            Parametre = this.PostCode.Text,
                            ParametreAdi = "@POSTCODE"
                        };
                        i_Array3[5] = i_31;
                        KomutArgumanlari_ i_32 = new KomutArgumanlari_
                        {
                            Parametre = this.Telephone.Text,
                            ParametreAdi = "@TELNRS1"
                        };
                        i_Array3[6] = i_32;
                        KomutArgumanlari_ i_33 = new KomutArgumanlari_
                        {
                            Parametre = this.CustomerFax.Text,
                            ParametreAdi = "@FAXNR"
                        };
                        i_Array3[7] = i_33;
                        KomutArgumanlari_ i_34 = new KomutArgumanlari_
                        {
                            Parametre = this.cbTown.SelectedValue._ToIntegerR(),
                            ParametreAdi = "@TOWNCODE"
                        };
                        i_Array3[8] = i_34;
                        KomutArgumanlari_ i_35 = new KomutArgumanlari_
                        {
                            Parametre = this.cbTown.Text,
                            ParametreAdi = "@TOWN"
                        };
                        i_Array3[9] = i_35;
                        KomutArgumanlari_ i_36 = new KomutArgumanlari_
                        {
                            Parametre = this.cbCity.SelectedValue._ToIntegerR(),
                            ParametreAdi = "@CITYCODE"
                        };
                        i_Array3[10] = i_36;
                        KomutArgumanlari_ i_37 = new KomutArgumanlari_
                        {
                            Parametre = this.cbCountry.SelectedValue._ToIntegerR(),
                            ParametreAdi = "@COUNTRYCODE"
                        };
                        i_Array3[11] = i_37;
                        KomutArgumanlari_ i_38 = new KomutArgumanlari_
                        {
                            Parametre = (this.cbMainContact.SelectedItem as CustomerWorker).cw_email,
                            ParametreAdi = "@EMAILADDR"
                        };
                        i_Array3[12] = i_38;
                        KomutArgumanlari_ i_39 = new KomutArgumanlari_
                        {
                            Parametre = "",
                            ParametreAdi = "@INCHANGE"
                        };
                        i_Array3[13] = i_39;
                        MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_SHIPINFO (CLIENTREF, CODE, NAME, SPECODE, CYPHCODE, ADDR1, ADDR2, CITY, COUNTRY, POSTCODE, TELNRS1, TELNRS2, FAXNR, CAPIBLOCK_CREATEDBY, CAPIBLOCK_CREADEDDATE, CAPIBLOCK_CREATEDHOUR, CAPIBLOCK_CREATEDMIN, CAPIBLOCK_CREATEDSEC, CAPIBLOCK_MODIFIEDBY, CAPIBLOCK_MODIFIEDDATE, CAPIBLOCK_MODIFIEDHOUR, CAPIBLOCK_MODIFIEDMIN, CAPIBLOCK_MODIFIEDSEC, SITEID, RECSTATUS, ORGLOGICREF, TRADINGGRP, VATNR, TAXNR, TAXOFFICE, TOWNCODE, TOWN, DISTRICTCODE, DISTRICT, CITYCODE, COUNTRYCODE, ACTIVE, TEXTINC, EMAILADDR, INCHANGE, TELCODES1, TELCODES2, FAXCODE, LONGITUDE, LATITUTE, CITYID, TOWNID, SHIPBEGTIME1, SHIPBEGTIME2, SHIPBEGTIME3, SHIPENDTIME1, SHIPENDTIME2, SHIPENDTIME3, POSTLABELCODE, SENDERLABELCODE) VALUES (@CLIENTREF, '888888', 'FATURA ADRESİ', '', '', @ADDR1, @ADDR2, @CITY, @COUNTRY, @POSTCODE, @TELNRS1, '', @FAXNR, 1, '01-01-2017', 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, '', '', '', '', @TOWNCODE, @TOWN, '', '', @CITYCODE, @COUNTRYCODE, 1, 0, @EMAILADDR, @INCHANGE, '', '', '', '', '', '', '', 134217752, 0, 0, 288817176, 0, 0, '', ''); SELECT SCOPE_IDENTITY()", Utils.FrmNo), CommandType.Text, 60, i_Array3);
                    }
                    base.Close();
                }
                else
                {
                    MessageBox.Show("Exception Error");
                }
            }
            #endregion
        }

        //private void logoCustUpd()
        //{
        //    //string str = MyConnect.Ornekle.ExecuteScalar(Utils.ConnectionStringLogo, "SELECT CODE FROM L_COUNTRY WHERE LOGICALREF = " + this.cbCountry.SelectedValue._ToIntegerR(), CommandType.Text, 60, new KomutArgumanlari_[0]).ToString();
        //    //int num = MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("select ISNULL(MAX(CL.LOWLEVELCODES1)+1,1) from LG_{0}_CLCARD AS CL", Utils.FrmNo), CommandType.Text, 60, new KomutArgumanlari_[0]);
        //    //Bolgeler.GroupGuncelle(this.CustomerCode.Text.ToUpper(), this.MainCategory.SelectedValue._ToIntegerR(), this.SubCategory.SelectedValue._ToIntegerR(), this.Capital.SelectedValue._ToIntegerR());
        //    KomutArgumanlari_[] i_Array4 = new KomutArgumanlari_[0x17];
        //    KomutArgumanlari_ i_40 = new KomutArgumanlari_
        //    {
        //        Parametre = this.CustomerCode.Text.ToUpper(),
        //        ParametreAdi = "@Kodu"
        //    };
        //    i_Array4[0] = i_40;
        //    KomutArgumanlari_ i_41 = new KomutArgumanlari_
        //    {
        //        Parametre = this.CustomerName.Text.ToUpper(),
        //        ParametreAdi = "@Unvan"
        //    };
        //    i_Array4[1] = i_41;
        //    KomutArgumanlari_ i_42 = new KomutArgumanlari_
        //    {
        //        Parametre = this.txtAddress1.Text.ToUpper(),
        //        ParametreAdi = "@Adres1"
        //    };
        //    i_Array4[2] = i_42;
        //    KomutArgumanlari_ i_43 = new KomutArgumanlari_
        //    {
        //        Parametre = this.txtAddress2.Text.ToUpper(),
        //        ParametreAdi = "@Adres2"
        //    };
        //    i_Array4[3] = i_43;
        //    KomutArgumanlari_ i_44 = new KomutArgumanlari_
        //    {
        //        Parametre = this.cbCountry.SelectedValue._ToIntegerR(),
        //        ParametreAdi = "@COUNTRYCODE"
        //    };
        //    i_Array4[4] = i_44;
        //    KomutArgumanlari_ i_45 = new KomutArgumanlari_
        //    {
        //        Parametre = this.cbCountry.Text,
        //        ParametreAdi = "@COUNTRY"
        //    };
        //    i_Array4[5] = i_45;
        //    KomutArgumanlari_ i_46 = new KomutArgumanlari_
        //    {
        //        Parametre = this.cbCity.Text,
        //        ParametreAdi = "@CtName"
        //    };
        //    i_Array4[6] = i_46;
        //    KomutArgumanlari_ i_47 = new KomutArgumanlari_
        //    {
        //        Parametre = this.PostCode.Text,
        //        ParametreAdi = "@Pc"
        //    };
        //    i_Array4[7] = i_47;
        //    KomutArgumanlari_ i_48 = new KomutArgumanlari_
        //    {
        //        Parametre = this.Telephone.Text,
        //        ParametreAdi = "@Tel"
        //    };
        //    i_Array4[8] = i_48;
        //    KomutArgumanlari_ i_49 = new KomutArgumanlari_
        //    {
        //        Parametre = "",
        //        ParametreAdi = "@SPECODE"
        //    };
        //    i_Array4[9] = i_49;
        //    KomutArgumanlari_ i_50 = new KomutArgumanlari_
        //    {
        //        Parametre = this.Represantative1.SelectedValue,
        //        ParametreAdi = "@Temsilci"
        //    };
        //    i_Array4[10] = i_50;
        //    KomutArgumanlari_ i_51 = new KomutArgumanlari_
        //    {
        //        Parametre = this.CreditLimit.Text,
        //        ParametreAdi = "@Credit"
        //    };
        //    i_Array4[11] = i_51;
        //    KomutArgumanlari_ i_52 = new KomutArgumanlari_
        //    {
        //        Parametre = this.DiscountRate.Text,
        //        ParametreAdi = "@Indirim"
        //    };
        //    i_Array4[12] = i_52;
        //    KomutArgumanlari_ i_53 = new KomutArgumanlari_
        //    {
        //        Parametre = this.CustomerFax.Text,
        //        ParametreAdi = "@Fx"
        //    };
        //    i_Array4[13] = i_53;
        //    KomutArgumanlari_ i_54 = new KomutArgumanlari_
        //    {
        //        Parametre = this.taxNumber.Text,
        //        ParametreAdi = "@Vn"
        //    };
        //    i_Array4[14] = i_54;
        //    KomutArgumanlari_ i_55 = new KomutArgumanlari_
        //    {
        //        Parametre = this.taxNumber.Text,
        //        ParametreAdi = "@Vd"
        //    };
        //    i_Array4[15] = i_55;
        //    KomutArgumanlari_ i_56 = new KomutArgumanlari_
        //    {
        //        Parametre = (this.cbMainContact.SelectedItem as CustomerWorker).cw_email,
        //        ParametreAdi = "@MailAdres"
        //    };
        //    i_Array4[0x10] = i_56;
        //    KomutArgumanlari_ i_57 = new KomutArgumanlari_
        //    {
        //        Parametre = this.PaymentMethod.SelectedValue,
        //        ParametreAdi = "@PAYMENTREF"
        //    };
        //    i_Array4[0x11] = i_57;
        //    KomutArgumanlari_ i_58 = new KomutArgumanlari_
        //    {
        //        Parametre = this.cbTown.SelectedValue._ToIntegerR(),
        //        ParametreAdi = "@TwC"
        //    };
        //    i_Array4[0x12] = i_58;
        //    KomutArgumanlari_ i_59 = new KomutArgumanlari_
        //    {
        //        Parametre = this.cbTown.Text,
        //        ParametreAdi = "@TwN"
        //    };
        //    i_Array4[0x13] = i_59;
        //    KomutArgumanlari_ i_60 = new KomutArgumanlari_
        //    {
        //        Parametre = this.cbCity.SelectedValue._ToIntegerR(),
        //        ParametreAdi = "@CityCode"
        //    };
        //    i_Array4[20] = i_60;
        //    KomutArgumanlari_ i_61 = new KomutArgumanlari_
        //    {
        //        Parametre = this.txtExtNumber.Text,
        //        ParametreAdi = "@Dahili"
        //    };
        //    i_Array4[0x15] = i_61;
        //    KomutArgumanlari_ i_62 = new KomutArgumanlari_
        //    {
        //        Parametre = this.WebAdress.Text,
        //        ParametreAdi = "@WEBADDR"
        //    };
        //    i_Array4[0x16] = i_62;
        //    MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("UPDATE LG_{0}_CLCARD SET CODE = @Kodu, DEFINITION_ = @Unvan, ADDR1 = @Adres1, ADDR2 = @Adres2, CITY = @CtName, POSTCODE = @Pc, TELNRS1 = @Tel, FAXNR = @Fx, TAXNR = @Vn, TAXOFFICE = @Vd, EMAILADDR = @MailAdres, TOWNCODE = @TwC, TOWN = @TwN, CITYCODE = @CityCode, TELEXTNUMS1 = @Dahili, SPECODE = @SPECODE, PAYMENTREF=@PAYMENTREF, SPECODE3 = @Credit, SPECODE4 = @Indirim, SPECODE5 = @Temsilci, WEBADDR = @WEBADDR, COUNTRYCODE = @COUNTRYCODE, COUNTRY = @COUNTRY WHERE LOGICALREF = {1}", Utils.FrmNo, ""), CommandType.Text, 60, i_Array4);
        //   // this.CariyeNotEkle(this.CustomerCode.Text, this.txtNot.Text);
        //    if (DateTime.Now.Year > 0x7e0)
        //    {
        //        KomutArgumanlari_[] i_Array5 = new KomutArgumanlari_[13];
        //        KomutArgumanlari_ i_63 = new KomutArgumanlari_
        //        {
        //            Parametre = "",
        //            ParametreAdi = "@CLIENTREF"
        //        };
        //        i_Array5[0] = i_63;
        //        KomutArgumanlari_ i_64 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtAddress1.Text.ToUpper(),
        //            ParametreAdi = "@ADDR1"
        //        };
        //        i_Array5[1] = i_64;
        //        KomutArgumanlari_ i_65 = new KomutArgumanlari_
        //        {
        //            Parametre = this.txtAddress2.Text.ToUpper(),
        //            ParametreAdi = "@ADDR2"
        //        };
        //        i_Array5[2] = i_65;
        //        KomutArgumanlari_ i_66 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cbCity.Text,
        //            ParametreAdi = "@CITY"
        //        };
        //        i_Array5[3] = i_66;
        //        KomutArgumanlari_ i_67 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cbCountry.Text,
        //            ParametreAdi = "@COUNTRY"
        //        };
        //        i_Array5[4] = i_67;
        //        KomutArgumanlari_ i_68 = new KomutArgumanlari_
        //        {
        //            Parametre = this.PostCode.Text,
        //            ParametreAdi = "@POSTCODE"
        //        };
        //        i_Array5[5] = i_68;
        //        KomutArgumanlari_ i_69 = new KomutArgumanlari_
        //        {
        //            Parametre = this.Telephone.Text,
        //            ParametreAdi = "@TELNRS1"
        //        };
        //        i_Array5[6] = i_69;
        //        KomutArgumanlari_ i_70 = new KomutArgumanlari_
        //        {
        //            Parametre = this.CustomerFax.Text,
        //            ParametreAdi = "@FAXNR"
        //        };
        //        i_Array5[7] = i_70;
        //        KomutArgumanlari_ i_71 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cbTown.SelectedValue._ToIntegerR(),
        //            ParametreAdi = "@TOWNCODE"
        //        };
        //        i_Array5[8] = i_71;
        //        KomutArgumanlari_ i_72 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cbTown.Text,
        //            ParametreAdi = "@TOWN"
        //        };
        //        i_Array5[9] = i_72;
        //        KomutArgumanlari_ i_73 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cbCity.SelectedValue._ToIntegerR(),
        //            ParametreAdi = "@CITYCODE"
        //        };
        //        i_Array5[10] = i_73;
        //        KomutArgumanlari_ i_74 = new KomutArgumanlari_
        //        {
        //            Parametre = this.cbCountry.SelectedValue._ToIntegerR(),
        //            ParametreAdi = "@COUNTRYCODE"
        //        };
        //        i_Array5[11] = i_74;
        //        KomutArgumanlari_ i_75 = new KomutArgumanlari_
        //        {
        //            Parametre = (this.cbMainContact.SelectedItem as CustomerWorker).cw_email,
        //            ParametreAdi = "@EMAILADDR"
        //        };
        //        i_Array5[12] = i_75;
        //        MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringLogo, string.Format("UPDATE LG_{0}_SHIPINFO SET ADDR1 = @ADDR1, ADDR2 = @ADDR2, CITY = @CITY, COUNTRY = @COUNTRY, POSTCODE = @POSTCODE, TELNRS1 = @TELNRS1, FAXNR = @FAXNR, TOWNCODE = @TOWNCODE, TOWN = @TOWN, CITYCODE = @CITYCODE, COUNTRYCODE = @COUNTRYCODE, EMAILADDR = @EMAILADDR WHERE CLIENTREF = @CLIENTREF AND CODE = '888888'", Utils.FrmNo), CommandType.Text, 60, i_Array5);
        //    }
        //    base.Close();
        //}
    }
}
