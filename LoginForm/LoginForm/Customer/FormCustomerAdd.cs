﻿using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using LoginForm.Services;
using System.Drawing;

namespace LoginForm
{
    public partial class FormCustomerAdd : Form
    {
        FormCustomerMain parent;
        IMEEntities IME = new IMEEntities();
        string ComboboxString = "Choose";
        int isUpdateAdress;
        int selectedContactID;
        int contactnewID = 0;

        public FormCustomerAdd()
        {
            InitializeComponent();
        }

        public FormCustomerAdd(Customer customer, string form)
        {
            InitializeComponent();
            if (form == "View")
            {
                customerClicksearch(customer);
                EnableFalse();
                ContactList.Enabled = true;
                AdressList.Enabled = true;
            }
            else
            {
                customerClicksearch(customer);
                label67.Text = "Modify";
                itemsEnableTrue();
            }
        }

        public FormCustomerAdd(FormCustomerMain parent)
        {
            InitializeComponent();
            IMEEntities IME = new IMEEntities();
            this.parent = parent;
            itemsClear();
            itemsEnableTrue();
            NewCustomerNumber();
        }

        private void NewCustomerNumber()
        {
            DataSet.Management m = Utils.getManagement();

            dateTimePicker1.Value = DateTime.Today;
            itemsEnableTrue();
            itemsClear();
            #region Factor
            factor.Value = IME.Managements.FirstOrDefault().Factor;
            DiscountRate.Text = (100 - ((factor.Value * 100) / Utils.getManagement().Factor)).ToString();
            DiscountRate.Text = String.Format("{0:0.0000}", Decimal.Parse(DiscountRate.Text)).ToString();
            #endregion
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
            InvCurrencyName.SelectedValue = m.DefaultCurrency;
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
            Utils.LogKayit("Customer", "Customer added");
            label69.Text = "Cancel";
            AdressList.Enabled = false;
            AdressList.DataSource = null;
            ContactAdress.DataSource = null;
            AdressAdd.Enabled = true;
            btnContactAdd.Enabled = true;
            btnContactClick();
            btnAddressClick();
            btnSave.Enabled = true;
            btnClose.Enabled = true;
        }

        private void itemsClear()
        {
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
        }

        private void FormCustomerAdd_Load(object sender, EventArgs e)
        {
            ComboboxFiller();
        }

        private void ComboboxFiller()
        {
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
            //SubCategory.DataSource = IME.CustomerSubCategories.Where(a => a.categoryID == (int)MainCategory.SelectedValue);
            //SubCategory.DisplayMember = "subcategoryname";
            //SubCategory.ValueMember = "ID";
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
        }

        private void customerClicksearch(Customer customer)
        {
            string customerID = customer.ID;

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

        private void EnableTrue()
        {
            groupAccount.Enabled = true;
            groupAddresses.Enabled = true;
            groupCompany.Enabled = true;
            groupContact.Enabled = true;
            btnSave.Enabled = true;
        }

        private void EnableFalse()
        {
            groupAccount.Enabled = false;
            groupAddresses.Enabled = false;
            groupCompany.Enabled = false;
            groupContact.Enabled = false;
            btnSave.Enabled = false;
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

            btnSave.Enabled = true;

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
            btnContactAdd.Enabled = false;
            btnContactDelete.Enabled = false;
            btnContactUpdate.Enabled = false;
            btnSave.Enabled = false;
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
            btnSave.Enabled = true;
            #endregion
        }

        private void AdressTabEnableTrue()
        {
            #region contactTabEnableTrue
            AddressType.Enabled = true;
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
            AdressAdd.Enabled = false;
            AddressDel.Enabled = false;
            AddressUpd.Enabled = false;
            btnSave.Enabled = false;
            #endregion
        }

        private void ContactList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Yellow);//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(ContactList.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
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

                }
                #endregion
            }
            catch { }
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

        private void btnContactAdd_Click(object sender, EventArgs e)
        {
            btnContactClick();
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

        private void btnContactCancel_Click(object sender, EventArgs e)
        {
            #region btnContactCancel
            contactTabEnableFalse();
            //if (btnCreate.Text == "ADD")
            //{
            //    txtSearch.Enabled = true;
            //    Search.Enabled = true;
            //    dgvCustomer.Enabled = true;
            //}
            btnContactAdd.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDelete.Visible = true;
            btnContactDone.Visible = false;
            btnContactUpdate.Visible = true;

            //if (QuotationCustomerId == 1)
            //{
            //    btnCreate.Enabled = false;
            //    btnUpdate.Enabled = false;
            //}
            #endregion
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

        private void btnContactUpdate_Click(object sender, EventArgs e)
        {
            btnContactUpdateClick();
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
                Utils.LogKayit("Customer", "Customer contact added");
                IME.SaveChanges();
                //if (btnCreate.Text == "ADD")
                //{
                //    txtSearch.Enabled = true;
                //    Search.Enabled = true;
                //    dgvCustomer.Enabled = true;
                //}
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
                    Utils.LogKayit("Customer", "Customer contact update");
                    contactTabEnableFalse();
                    //if (btnCreate.Text == "ADD")
                    //{
                    //    txtSearch.Enabled = true;
                    //    Search.Enabled = true;
                    //    dgvCustomer.Enabled = true;
                    //}
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

            //if (QuotationCustomerId == 1)
            //{
            //    btnCreate.Enabled = false;
            //    btnUpdate.Enabled = false;
            //}
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

        private void AdressAdd_Click(object sender, EventArgs e)
        {
            btnAddressClick();
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

        private bool AddressControl()
        {
            bool isSave = true;
            string ErrorMessage = string.Empty;
            if (cbCity.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter City"; isSave = false; }
            if (cbTown.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Town"; isSave = false; }
            if (isSave == true) { return true; } else { MessageBox.Show(ErrorMessage); return false; }
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
                Utils.LogKayit("Customer", "Customer address update");
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
                        CountryID = ((cbCountry).SelectedItem as Country)?.ID,
                        CityID = ((cbCity).SelectedItem as City)?.ID,
                        TownID = ((cbTown).SelectedItem as Town)?.ID,
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
                Utils.LogKayit("Customer", "Customer address added");
            }
            AdressTabEnableFalse();
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
            //if (btnCreate.Text == "ADD")
            //{
            //    txtSearch.Enabled = true;
            //    Search.Enabled = true;
            //    dgvCustomer.Enabled = true;
            //}
            AdressList.DataSource = IME.CustomerAddresses.Where(customerw => customerw.CustomerID == CustomerCode.Text).ToList();
            AdressList.DisplayMember = "AdressTitle";

            AdressAdd.Visible = true;
            AddressDel.Visible = true;
            AddressUpd.Visible = true;
            AdressCancel.Visible = false;
            AdressDone.Visible = false;
            //customersearch();
        }

        private bool ControlSave()
        {
            bool isSave = true;
            string ErrorMessage = string.Empty;
            if (CustomerName.Text == null || CustomerName.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Company's Name\n"; isSave = false; }
            if (isSave == true) { return true; } else { MessageBox.Show(ErrorMessage); return false; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ControlSave())
            {
                Customer c = new Customer();

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
                MessageBox.Show("Customer save succesfully");
                Utils.LogKayit("Customer", "Customer update");
                this.Close();

            }       
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
            AccountingNotes.Enabled = false;
            DiscountRate.Enabled = false;
            PaymentMethod.Enabled = false;
            TermsofPayments.Enabled = false;
            TaxOffice.Enabled = false;
            btnContactAdd.Enabled = true;
            if (ContactList.DataSource != null)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }
            departmentAdd.Enabled = false;
            Represantative2.Enabled = false;
            Represantative1.Enabled = false;
            InvCurrencyName.Enabled = false;
            QuoCurrencyName.Enabled = false;

            AccountRepresentary.Enabled = false;
            CreditLimit.Enabled = false;
            taxNumber.Enabled = false;
            rb_passive.Enabled = false;
            rb_active.Enabled = false;
            factor.Enabled = false;
            Capital.Enabled = false;
            btnSave.Enabled = true;
            btnContactDone.Enabled = false;
            btnContactCancel.Enabled = false;
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
            AccountingNotes.Enabled = true;
            DiscountRate.Enabled = true;
            PaymentMethod.Enabled = true;
            TermsofPayments.Enabled = true;
            TaxOffice.Enabled = true;
            Represantative2.Enabled = true;
            InvCurrencyName.Enabled = true;
            QuoCurrencyName.Enabled = true;
            AccountRepresentary.Enabled = true;
            CreditLimit.Enabled = true;
            taxNumber.Enabled = true;

            rb_passive.Enabled = true;
            rb_active.Enabled = true;
            factor.Enabled = true;
            Capital.Enabled = true;
            btnSave.Enabled = true;
            btnContactDone.Enabled = true;
            btnContactCancel.Enabled = true;

            AdressAdd.Enabled = true;
            btnContactAdd.Enabled = true;
            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (label69.Text == "Cancel")
            {
                var customer = IME.Customer_CustomerID(CustomerCode.Text).FirstOrDefault();
                if (customer != null)
                {
                    //CREATE in cancel ı
                    var cw = IME.CustomerWorkers.Where(a => a.customerID == CustomerCode.Text);
                    //Contact
                    while (cw.Count() > 0)
                    {
                        IME.CustomerWorkers.Remove(cw.FirstOrDefault());
                        IME.SaveChanges();
                    }
                    //adresses
                    var cd = IME.CustomerAddresses.Where(a => a.CustomerID == CustomerCode.Text);
                    while (cd.Count() > 0)
                    {
                        IME.CustomerAddresses.Remove(cd.FirstOrDefault());
                        IME.SaveChanges();
                    }

                    Customer c = new Customer();
                    c = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();
                    IME.Customers.Remove(c);
                    IME.SaveChanges();
                }
                itemsClear();
            }
            else
            {
                this.Close();
            }
        }
    }
}
