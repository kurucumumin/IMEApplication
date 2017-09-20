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

namespace CustomerPage2
{
    public partial class CustomerMain : Form
    {
        IMEEntities IME = new IMEEntities();
        int gridselectedindex=0;
        string searchtxt="";
        int selectedContactID;

        public CustomerMain()
        {
            InitializeComponent();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void CustomerMain_Load(object sender, EventArgs e)
        {
            #region ComboboxFiller
            
            ContactDepartment.DataSource = IME.CustomerDepartments.ToList();
            ContactDepartment.DisplayMember = "departmentname";
            ContactTitle.DataSource = IME.CustomerTitles.ToList();
            ContactTitle.DisplayMember = "titlename";
            CommunicationLanguage.DataSource = IME.Languages.ToList();
            CommunicationLanguage.DisplayMember = "languagename";
            factor.DataSource = IME.Rates.Where(d => d.rate_date == DateTime.Now).ToList();// bugünün rateleri gelecek
            factor.DisplayMember = "rate_name";
            Represantative2.DataSource = IME.Workers.ToList();
            Represantative2.DisplayMember = "FirstName";
            Represantative1.DataSource = IME.Workers.ToList();
            Represantative1.DisplayMember = "FirstName";
            SubCategory.DataSource = IME.CustomerSubCategories.ToList();
            SubCategory.DisplayMember = "subcategoryname";
            MainCategory.DataSource = IME.CustomerCategories.ToList();
            MainCategory.DisplayMember = "categoryname";
            QuoCurrency.DataSource = IME.Rates.ToList();
            QuoCurrency.DisplayMember = "currency";
            InvCurrency.DataSource = IME.Rates.ToList();
            InvCurrency.DisplayMember = "currency";
            TermsofPayments.DataSource = IME.PaymentTerms.ToList();
            TermsofPayments.DisplayMember = "term_name";
            PaymentMethod.DataSource = IME.PaymentMethods.ToList();
            PaymentMethod.DisplayMember = "Payment";
            AccountRepresentary.DataSource = IME.Workers.ToList();
            AccountRepresentary.DisplayMember= "FirstName";
            
            
            cbCountry.DataSource = IME.Countries.ToList();
            cbCountry.DisplayMember = "Country_name";
            
            #endregion
            customersearch();
        }
        private void CustomerDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void CustomerDataGrid_Click(object sender, EventArgs e)
        {        
            gridselectedindex = CustomerDataGrid.CurrentCell.RowIndex;
            customersearch();
        }

       

        private void ContactNotes_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tab_contact_Click(object sender, EventArgs e)
        {

        }

        private void ContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ContactList
            //contact daki list box a tıklandığında contact ın bilgileri tıklanan göre doldurulmasıse
            int cw_ID=0;
            try { cw_ID = ((CustomerWorker)((ListBox)sender).SelectedItem).ID; } catch { cw_ID = 0; }
            try
            {
                if (ContactListItem.ID != cw_ID)
                            {
                                ContactListItem.ID = cw_ID;
                                string contactname = ((CustomerWorker)((ListBox)sender).SelectedItem).cw_name;
                                ContactListItem.contactName = contactname;
                                var contact1 = IME.CustomerWorkers.Where(cw => cw.ID == cw_ID).ToList();
                                foreach (var a in contact1)
                                {
                                    selectedContactID = a.ID;
                                    ContactName.Text = a.cw_name;
                                    ContactEmail.Text = a.cw_email;
                                    ContactDepartment.Text = a.CustomerDepartment.departmentname;
                                    ContactFAX.Text = a.fax;
                                    ContactMobilePhone.Text = a.mobilephone;
                                    ContactTitle.Text = a.CustomerTitle.titlename;
                                    ContactPhone.Text = a.phone;
                                    ContactNotes.Text = a.Note.Note_name;
                                }
                            }
            }catch { }
#endregion
        }

        private void departmentAdd_Click(object sender, EventArgs e)
        {
            DepartmentAdd form = new DepartmentAdd();
            form.Show();
            this.Hide();
            
        }

        private void titleAdd_Click(object sender, EventArgs e)
        {
            TitleAdd form = new TitleAdd();
            form.Show();
            this.Hide();
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void MainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            

                int c_categoryID;
                try { c_categoryID = ((CustomerCategory)((ComboBox)sender).SelectedItem).ID; } catch { c_categoryID = 0; }
                SubCategory.DataSource = IME.CustomerSubCategories.Where(b => b.categoryID == c_categoryID).ToList();
                SubCategory.DisplayMember = "subcategoryname";

        }

        private void Search_Click(object sender, EventArgs e)
        {
            gridselectedindex = 0;
            searchtxt = txtSearch.Text;
            customersearch();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void tabsenablefalse()
        {
            
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
            ContactMobilePhone.Enabled = false;
            ContactFAX.Enabled = false;
            CommunicationLanguage.Enabled = false;
            ContactNotes.Enabled = false;
            departmentAdd.Enabled = false;
            DeliveryAddressOk.Enabled = false;
            InvoiceAdressOk.Enabled = false;

            titleAdd.Enabled = false;
            ContactList.Enabled = true;
            
            btnContactAdd.Enabled = true;
            if (ContactList.DataSource!=null)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }
            

            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            
            btnContactAdd.Enabled = true;
            if (ContactList.DataSource!=null)
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
            ContactMobilePhone.Enabled = true;
            ContactFAX.Enabled = true;
            CommunicationLanguage.Enabled = true;
            ContactNotes.Enabled = true;
            departmentAdd.Enabled = true;
            DeliveryAddressOk.Enabled = true;
            InvoiceAdressOk.Enabled = true;
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
            AddressDetails.Enabled = false;
            DeliveryAddressOk.Enabled = false;
            InvoiceAdressOk.Enabled = false;
            cbCompanyAdress.Enabled = false;
            AdressList.Enabled = true;

            
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
            AddressType.Enabled = true;
            cbCountry.Enabled = true;
            cbCity.Enabled = true;
            cbTown.Enabled = true;
            PostCode.Enabled = true;
            AddressDetails.Enabled = true;
            DeliveryAddressOk.Enabled = true;
            InvoiceAdressOk.Enabled = true;
            cbCompanyAdress.Enabled = true;
            AdressList.Enabled = false;

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
            #region customersearch
            var customerAdapter = (from c in IME.Customers.Where(a => a.c_name.Contains(searchtxt))
                                   join w in IME.Workers on c.representaryID equals w.WorkerID
                                   join customerworker in IME.CustomerWorkers on c.ID equals customerworker.customerID into customerworkeres
                                   let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                                   join r in IME.Workers on c.representary2ID equals r.WorkerID
                                   join customeraccountant  in IME.Workers on c.accountrepresentaryID equals customeraccountant.WorkerID 
                                   join s in IME.CustomerCategorySubCategories on c.ID equals s.customerID
                                   join p in IME.PaymentTerms on c.payment_termID equals p.ID
                                   join m in IME.PaymentMethods on c.paymentmethodID equals m.ID
                                   join l in IME.Languages on customerworker.languageID equals l.ID
                                   join a in IME.CustomerAdresses on c.ID equals a.CustomerID into adress
                                   let a = adress.Select(customerworker1 => customerworker1).FirstOrDefault()

                                   select new
                                   {
                                       c.ID,
                                       c.c_name,
                                       c.Rate.currency,
                                       c.telephone,
                                       c.fax,
                                       c.webadress,
                                       w.FirstName,
                                       Representative2 = r.FirstName,
                                       customerworker.cw_name,
                                       customerworker.cw_email,
                                       customerworker.CustomerTitle.titlename,
                                       customerworker.CustomerDepartment.departmentname,
                                       s.CustomerCategory.categoryname,
                                       s.CustomerSubCategory.subcategoryname,
                                       p.term_name,
                                       customerworker,
                                       cwNote = customerworker.Note.Note_name,
                                       c.isactive,
                                       c.rateIDinvoice,
                                       CustomerNote = c.Note.Note_name,
                                       WorkerNote = w.Note.Note_name,
                                       CustomerWorkerNote = customerworker.Note.Note_name,
                                       AccountRepresentative = customeraccountant.FirstName,
                                       l.languagename,
                                       AddressCity=a.City.City_name,
                                       AddressContact=a.CustomerWorker.cw_name,
                                       AdressCountry=a.Country.Country_name,
                                       a.isDeliveryAdress,
                                       a.isInvoiceAdress,
                                       a.PostCode,
                                       a.Town.Town_name,
                                       a.AdressDetails,
                                   }).ToList();
            #endregion

            #region FillInfos
            CustomerDataGrid.DataSource = customerAdapter;
            
            CustomerDataGrid.ClearSelection();
            CustomerDataGrid.Rows[gridselectedindex].Selected = true;// tüm row u seçtirmek için bu formülü kullnınca selectedrow index =0 oluyor
            CustomerCode.Text = customerAdapter[gridselectedindex].ID;
            AddressType.DataSource = IME.CustomerWorkers.Where(a => a.customerID == CustomerCode.Text).ToList();
            AddressType.DisplayMember = "cw_name";
            CustomerName.Text = customerAdapter[gridselectedindex].c_name;
            factor.SelectedIndex = factor.FindStringExact(customerAdapter[gridselectedindex].currency.ToString());
            Telephone.Text = customerAdapter[gridselectedindex].telephone.ToString();
            ContactFAX.Text = customerAdapter[gridselectedindex].fax.ToString();
            WebAdress.Text = customerAdapter[gridselectedindex].webadress;
            Represantative2.Text = customerAdapter[gridselectedindex].Representative2;
            ContactNotes.Text = customerAdapter[gridselectedindex].cwNote;
            Represantative1.SelectedIndex = Represantative1.FindStringExact(customerAdapter[gridselectedindex].FirstName);
            ContactTitle.SelectedIndex = ContactTitle.FindStringExact(customerAdapter[gridselectedindex].titlename);
            ContactDepartment.SelectedIndex = ContactDepartment.FindStringExact(customerAdapter[gridselectedindex].titlename);
            MainCategory.SelectedIndex = MainCategory.FindStringExact(customerAdapter[gridselectedindex].categoryname);
            SubCategory.SelectedIndex = SubCategory.FindStringExact(customerAdapter[gridselectedindex].subcategoryname);
            TermsofPayments.SelectedIndex = TermsofPayments.FindStringExact(customerAdapter[gridselectedindex].term_name);
            ContactName.Text = customerAdapter[gridselectedindex].cw_name;
            ContactEmail.Text = customerAdapter[gridselectedindex].cw_email;
            CompanyNotes.Text = customerAdapter[gridselectedindex].CustomerNote;
            ContactNotes.Text = customerAdapter[gridselectedindex].WorkerNote;
            AccountRepresentary.Text = customerAdapter[gridselectedindex].AccountRepresentative;
            CommunicationLanguage.Text = customerAdapter[gridselectedindex].languagename;
            if (customerAdapter[gridselectedindex].isactive == 1) { rb_active.Checked = true; } else { rb_passive.Checked = true; }
            ContactList.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
            ContactList.DisplayMember = "cw_name";
            AdressList.DataSource = IME.CustomerAdresses.Where(a => a.CustomerID == CustomerCode.Text).ToList();
            AdressList.DisplayMember = "AdressDetails";
            if (customerAdapter[gridselectedindex].AddressContact == null)
            { AddressType.SelectedItem=null;cbCompanyAdress.Checked = true; }
            else
            {
                AddressType.SelectedIndex = AddressType.FindStringExact(customerAdapter[gridselectedindex].AddressContact);
            }
            PostCode.Text = customerAdapter[gridselectedindex].PostCode;
            cbCountry.SelectedIndex = cbCountry.FindStringExact(customerAdapter[gridselectedindex].AdressCountry);
            cbCity.SelectedIndex = cbCity.FindStringExact(customerAdapter[gridselectedindex].AddressCity);
            if (customerAdapter[gridselectedindex].isDeliveryAdress == 1) { DeliveryAddressOk.Checked = true; } else { DeliveryAddressOk.Checked = false; }
            if (customerAdapter[gridselectedindex].isInvoiceAdress == 1) { InvoiceAdressOk.Checked = true; } else { InvoiceAdressOk.Checked = false; }
            cbTown.SelectedIndex = cbTown.FindStringExact(customerAdapter[gridselectedindex].Town_name);
            AddressDetails.Text = customerAdapter[gridselectedindex].AdressDetails;
            #endregion
        }

        //CONTACT ADD NEW
        private void button1_Click(object sender, EventArgs e)
        {
            #region addContactButton
            contactTabEnableTrue();
            ContactType.Text="";
            ContactDepartment.Text = "";
            ContactTitle.Text = "";
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
            #endregion
        }
        //CONTACT UPDATE
        private void btnContactUpdate_Click(object sender, EventArgs e)
        {
            #region  btnContactUpdate
            contactTabEnableTrue();
            btnContactAdd.Visible = false;
            btnContactCancel.Visible = true;
            btnContactDelete.Visible = false;
            btnContactDone.Visible = true;
            btnContactUpdate.Visible = false;
            #endregion
        }


        private void btnContactDone_Click(object sender, EventArgs e)
        {
            
                CustomerWorker cw = new CustomerWorker();
            //CustomerCode.Text;
            cw.customerID = CustomerCode.Text;
            cw.departmentID = ((CustomerDepartment)(ContactDepartment).SelectedItem).ID;
            cw.titleID = ((CustomerTitle)(ContactTitle).SelectedItem).ID;
            cw.cw_name = ContactName.Text;
            cw.cw_email = ContactEmail.Text;
            cw.phone = ContactPhone.Text;
            cw.mobilephone = ContactMobilePhone.Text;
            cw.fax = ContactFAX.Text;
            cw.languageID = ((Language)(CommunicationLanguage).SelectedItem).ID;
            Note n = new Note();
            n.Note_name = ContactNotes.Text;
            IME.Notes.Add(n);
            IME.SaveChanges();
            cw.customerNoteID = n.ID;
            IME.CustomerWorkers.Add(cw);
            IME.SaveChanges();
            contactTabEnableFalse();
            if(btnCreate.Text=="CREATE")
            {
                txtSearch.Enabled = true;
                Search.Enabled = true;
                CustomerDataGrid.Enabled = true;
            }
            ContactList.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
            ContactList.DisplayMember = "cw_name";
            //catch { MessageBox.Show("Contact is NOT successfull"); }
            btnContactAdd.Visible = true;
            btnContactDelete.Visible = true;
            btnContactUpdate.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDone.Visible = false;

        }

        private void ContactDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
                int c_departmentID;
                try { c_departmentID = ((CustomerDepartment)((ComboBox)sender).SelectedItem).ID; } catch { c_departmentID = 0; }
                ContactTitle.DataSource = IME.CustomerTitles.Where(b => b.CustomerDepartment.ID == c_departmentID).ToList();
                ContactTitle.DisplayMember = "titlename";
        }

        private void btnContactDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Delete Contact " + ContactListItem.contactName + " ?" , "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CustomerWorker cw = IME.CustomerWorkers.First(a => a.ID == ContactListItem.ID);
                IME.CustomerWorkers.Remove(cw);
                IME.SaveChanges();
                ContactList.DataSource = IME.CustomerWorkers.Where(customerw => customerw.customerID == CustomerCode.Text).ToList();
                ContactList.DisplayMember = "cw_name";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            if (btnCreate.Text == "CREATE")
            {
                
                itemsEnableTrue();
                itemsClear();

                //for new customerCode
                var custmrcode = IME.Customers.OrderByDescending(a => a.ID).FirstOrDefault().ID;
                string custmrnumbers = string.Empty;
                string newcustomercodenumbers="";
                string newcustomercodezeros = "";
                string newcustomercodechars="";

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
                while(IME.Customers.Where(a=>a.ID== custmrcode).Count()>0)
                {
                    newcustomercodenumbers = (Int32.Parse(newcustomercodenumbers) + 1).ToString();
                    custmrcode = newcustomercodechars + newcustomercodezeros + newcustomercodenumbers;
                }
                //
                ContactList.DataSource = null;
                CustomerCode.Text = custmrcode;
                Customer c = new Customer();
                c.ID = CustomerCode.Text;
                IME.Customers.Add(c);
                IME.SaveChanges();
                
                btnCreate.Text = "DONE";
                btnUpdate.Text = "CANCEL";
            }
            else
            {
                btnCreate.Text = "CREATE";
                btnUpdate.Text = "UPDATE";
                Customer c = new Customer();
                c = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();

                if (rb_active.Checked) { c.isactive = 1; } else { c.isactive = 0; }
                c.c_name = CustomerName.Text;
                if (Telephone.Text != "") { c.telephone = Int32.Parse(Telephone.Text); }
                if (CustomerFax.Text != "") { c.fax = Int32.Parse(CustomerFax.Text); }
                c.webadress = WebAdress.Text;
                c.taxoffice = CustomerFax.Text;

                if (CreditLimit.Text != "") { c.creditlimit = Int32.Parse(CreditLimit.Text); }
                if (DiscountRate.Text != "") { c.discountrate = Int32.Parse(DiscountRate.Text); }
                c.taxoffice = TaxOffice.Text;
                if (taxNumber.Text != "") { c.taxnumber = Int32.Parse(taxNumber.Text); }

                //CategorySubCategory Tablosuna veri ekleniyor(ara tabloya)
                CustomerCategorySubCategory CustomerCatSubcat = new CustomerCategorySubCategory();
                //UPDATE YAPILIRKEN BU ŞEKİLDE OLUYOR
                if (IME.CustomerCategorySubCategories.Where(a => a.customerID == CustomerCode.Text).FirstOrDefault() != null) { CustomerCatSubcat = IME.CustomerCategorySubCategories.Where(a => a.customerID == CustomerCode.Text).FirstOrDefault(); }
                CustomerCatSubcat.customerID = CustomerCode.Text;
                int c_CategoryID = ((CustomerCategory)(MainCategory).SelectedItem).ID;
                CustomerCatSubcat.categoryID = c_CategoryID;
                int c_SubcategoryID = ((CustomerSubCategory)(SubCategory).SelectedItem).ID;
                CustomerCatSubcat.subcategoryID = c_SubcategoryID;
                if (IME.CustomerCategorySubCategories.Where(a => a.customerID == CustomerCode.Text).FirstOrDefault() == null){ IME.CustomerCategorySubCategories.Add(CustomerCatSubcat); }
                IME.SaveChanges();
                //
                int c_rep1ID = ((Worker)(Represantative1).SelectedItem).WorkerID;
                c.representaryID = c_rep1ID;
                int c_rep2ID = ((Worker)(Represantative2).SelectedItem).WorkerID;
                c.representary2ID = c_rep2ID;
                int c_termpayment = ((PaymentTerm)(TermsofPayments).SelectedItem).ID;
                c.payment_termID = c_termpayment;
                int c_paymentmeth = ((PaymentMethod)(PaymentMethod).SelectedItem).ID;
                c.paymentmethodID = c_paymentmeth;
                //Notes kısmına kayıt ediliyor
                try
                {
                    if (c.customerNoteID != null)
                    {
                        Note note1 = new Note();
                        note1 = IME.Notes.Where(a => a.ID == c.customerNoteID).FirstOrDefault();
                        note1.Note_name = CompanyNotes.Text;
                    }
                    else
                    {
                        c.Note.Note_name = CompanyNotes.Text;
                        IME.Notes.Add(c.Note);
                        c.customerNoteID = c.Note.ID;
                    }
                    IME.SaveChanges();
                    
                }
                catch { }

                IME.SaveChanges();
                itemsEnableFalse();
                contactTabEnableFalse();
                customersearch();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "UPDATE")
            {
                contactTabEnableTrue();
                itemsEnableTrue();
                btnUpdate.Text = "CANCEL";
                btnCreate.Text = "DONE";
            }
            else
            {
                btnUpdate.Text = "UPDATE";
                btnCreate.Text = "CREATE";
                itemsEnableFalse();
                contactTabEnableFalse();
                var customer = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();
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

                    Customer c = new Customer();
                    c = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();
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
            ContactType.Text = "";
            ContactDepartment.Text = "";
            ContactTitle.Text = "";
            ContactName.Text = "";
            ContactEmail.Text = "";
            ContactPhone.Text = "";
            ContactMobilePhone.Text = "";
            ContactFAX.Text = "";
            CommunicationLanguage.Text = "";
            ContactNotes.Text = "";
            MainCategory.SelectedIndex=0;
            SubCategory.SelectedIndex = 0;
            CompanyNotes.Text = "";
            WebAdress.Text = "";
            CustomerFax.Text = "";
            CustomerName.Text = "";
            Telephone.Text = "";
            CustomerCode.Text = "";         
            AccountingNotes.Text = "";
            DiscountRate.Text = "";
            PaymentMethod.Text = "";
            TermsofPayments.Text = "";
            TaxOffice.Text = "";           
            Represantative2.Text = "";
            Represantative1.Text = "";
            InvCurrency.Text = "";
            QuoCurrency.Text = "";
            AccountRepresentary.Text = "";
            CommunicationLanguage.Text = "";
            CreditLimit.Text = "";
            taxNumber.Text = "";
            factor.Text = "";
            Capital.Text = "";
            ContactEmail.Text = "";
            #endregion

        }
        private void itemsEnableFalse()
        {
            #region itemsEnableFalse
            SubCategory.Enabled = false;
            MainCategory.Enabled = false;
            CompanyNotes.Enabled = false;
            WebAdress.Enabled = false;
            CustomerFax.Enabled = false;
            CustomerName.Enabled = false;
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

            if (ContactList.DataSource!=null)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }
            departmentAdd.Enabled = false;
            Represantative2.Enabled = false;
            Represantative1.Enabled = false;
            InvCurrency.Enabled = false;
            QuoCurrency.Enabled = false;
            AccountRepresentary.Enabled = false;
            CreditLimit.Enabled = false;
            taxNumber.Enabled = false;
            Search.Enabled = false;
            txtSearch.Enabled = false;
            rb_passive.Enabled = false;
            rb_active.Enabled = false;
            factor.Enabled = false;
            Capital.Enabled = false;
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
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
            WebAdress.Enabled = true;
            CustomerFax.Enabled = true;
            CustomerName.Enabled = true;
            Telephone.Enabled = true;
            tab_adresses.Enabled = true;
            tab_contact.Enabled = true;
            AccountingNotes.Enabled = true;
            DiscountRate.Enabled = true;
            PaymentMethod.Enabled = true;
            TermsofPayments.Enabled = true;
            TaxOffice.Enabled = true;
            Represantative2.Enabled = true;
            Represantative1.Enabled = true;
            InvCurrency.Enabled = true;
            QuoCurrency.Enabled = true;
            AccountRepresentary.Enabled = true;
            CreditLimit.Enabled = true;
            taxNumber.Enabled = true;
            txtSearch.Enabled = true;
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
            #endregion
        }

        private void AccountRepresentary_Click(object sender, EventArgs e)
        {

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
            #region addAdressButton
            AdressTabEnableTrue();
            AddressType.Text = "";
            cbCompanyAdress.Checked = false;
            InvoiceAdressOk.Checked = false;
            DeliveryAddressOk.Checked = false;
            cbCountry.Text = "";
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
            #endregion
        }

        private void AddressUpd_Click(object sender, EventArgs e)
        {
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
                CustomerAdress ca = IME.CustomerAdresses.First(a => a.ID == ContactListItem.AdressID);
                IME.CustomerAdresses.Remove(ca);
                IME.SaveChanges();
                AdressList.DataSource = IME.CustomerAdresses.Where(customera => customera.CustomerID == CustomerCode.Text).ToList();
                AdressList.DisplayMember = "AdressDetails";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void AdressDone_Click(object sender, EventArgs e)
        {
            CustomerAdress ca = new CustomerAdress();
            //CustomerCode.Text;
            ca.CustomerID = CustomerCode.Text;
            ca.CountryID = ((Country)(cbCountry).SelectedItem).ID;
            ca.CityID = ((City)(cbCity).SelectedItem).ID;
            //AddresType
            if (cbCompanyAdress.Checked==false)
            {
                ca.ContactID = ((CustomerWorker)(AddressType).SelectedItem).ID;
            }

            ca.PostCode = PostCode.Text;
            ca.AdressDetails = AddressDetails.Text;
            if (DeliveryAddressOk.Checked) { ca.isDeliveryAdress = 1; } else { ca.isDeliveryAdress = 0; }
            if (InvoiceAdressOk.Checked) { ca.isInvoiceAdress = 1; } else { ca.isInvoiceAdress = 0; }

            IME.CustomerAdresses.Add(ca);
            IME.SaveChanges();
            AdressTabEnableFalse();
            if (btnCreate.Text == "CREATE")
            {
                txtSearch.Enabled = true;
                Search.Enabled = true;
                CustomerDataGrid.Enabled = true;
            }
            AdressList.DataSource = IME.CustomerAdresses.Where(customerw => customerw.CustomerID == CustomerCode.Text).ToList();
            AdressList.DisplayMember = "AdressDetails";

            AdressAdd.Visible = true;
            AddressDel.Visible = true;
            AddressUpd.Visible = true;
            AdressCancel.Visible = false;
            AdressDone.Visible = false;
        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCompanyAdress.Checked)
            {
                AddressType.Enabled = false;
                AddressType.SelectedItem = null;
            }
            else { AddressType.Enabled = true; }
            
        }

        private void AdressCancel_Click(object sender, EventArgs e)
        {

        }

        private void Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbCity.DataSource = IME.Cities.Where(a => a.CountryID == ((Country)(cbCountry).SelectedItem).ID).ToList();
                cbCity.DisplayMember = "City_name";
            }
            catch { }
        }

        private void City_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbTown.DataSource = IME.Towns.Where(a => a.CityID == ((City)(cbCity).SelectedItem).ID).ToList();
                cbTown.DisplayMember = "Town_name";
            }
            catch { }
        }

        private void AdressList_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region AdressList
            //contact daki list box a tıklandığında contact ın bilgileri tıklanan göre doldurulmasıse
            int cw_ID = 0;
            try { cw_ID = ((CustomerAdress)((ListBox)sender).SelectedItem).ID; } catch { cw_ID = 0; }
            try
            {
                if (ContactListItem.AdressID != cw_ID)
                {
                    ContactListItem.AdressID = cw_ID;
                    //string contactname = ((CustomerWorker)((ListBox)sender).SelectedItem).cw_name;
                    //ContactListItem.contactName = contactname;
                    var contact1 = IME.CustomerAdresses.Where(cw => cw.ID == cw_ID).ToList();
                    foreach (var a in contact1)
                    {
                        if (a.isDeliveryAdress == 1) { DeliveryAddressOk.Checked = true; } else { DeliveryAddressOk.Checked = false; }
                        if (a.isInvoiceAdress == 1) { InvoiceAdressOk.Checked = true; } else { InvoiceAdressOk.Checked = false; }
                        
                        cbCountry.SelectedItem = a.Country;
                        ((City)(cbCity).SelectedItem).ID=(int)a.CityID;
                        cbTown.SelectedItem = a.Town;
                        PostCode.Text = a.PostCode;
                        AddressDetails.Text = a.AdressDetails;
                    }
                }
            }
            catch { }
            #endregion
        }

        private void CustomerDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
