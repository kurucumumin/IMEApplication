using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using LoginForm.Services;
using System.Drawing;
using LoginForm.clsClasses;
using System.ComponentModel;
using static LoginForm.Services.MyClasses.MyAuthority;

namespace LoginForm
{
    public partial class FormSupplierAdd : Form
    {
        BindingList<SupplierAddress> SavedAddresses = new BindingList<SupplierAddress>();
        BindingList<SupplierWorker> SavedContacts = new BindingList<SupplierWorker>();
        BindingList<SupplierBankAccount> SavedBanks = new BindingList<SupplierBankAccount>();

        string ComboboxString = "Choose";
        int isUpdateAdress;
        int selectedContactID;
        int contactnewID = 0;
        FormSupplierMain parent;
        IMEEntities IME = new IMEEntities();

        public FormSupplierAdd()
        {
            InitializeComponent();
        }

        public FormSupplierAdd(Supplier supplier, string form)
        {
            InitializeComponent();
            if (form == "View")
            {
                supplierClicksearch(supplier);
                EnableMod(false);
                ContactList.Enabled = true;
                AdressList.Enabled = true;
            }
            else
            {
                supplierClicksearch(supplier);
                //parent.Text = "Modify Supplier";
                //label67.Text = "Modify";
                EnableMod(true);
            }
        }

        public FormSupplierAdd(FormSupplierMain parent)
        {
            InitializeComponent();
            this.IME = new IMEEntities();
            this.parent = parent;
            itemsClear();
            EnableMod(true);
            txtSupplierCode.Text = NewSupplierNumber();
        }

        #region Groupbox Rengi
        
        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);
                // Clear text and border
                g.Clear(this.BackColor);
                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);
                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void groupInfo_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.WhiteSmoke);
        }

        private void groupAcconutBank_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.WhiteSmoke);
        }

        private void groupContact_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.WhiteSmoke);
        }

        private void groupAddresses_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.WhiteSmoke);
        }

        #endregion

        private void itemsClear()
        {
            txtSupplierCode.Text = "";
            cmbRepresentative.SelectedIndex = -1;
            txtName.Text = "";
            txtWeb.Text = "";
            cmbMainCategory.SelectedIndex = -1;
            if (cmbSubCategory.Items.Count != 0) cmbSubCategory.SelectedIndex = -1;
            txtTaxOffice.Text = "";
            txtTaxNumber.Text = "";
            cmbMainContact.SelectedIndex = -1;
            txtSupplierNotes.Text = "";
            cmbAccountRep.SelectedIndex = -1;
            cmbAccountTerms.SelectedIndex = -1;
            cmbAccountMethod.SelectedIndex = -1;
            cmbCurrency.SelectedIndex = -1;
            txtAccountNotes.Text = "";
            txtBankAccountNumber.Text = "";
            txtBankAccountTitle.Text = "";
            txtBankBranchCode.Text = "";
            txtBankIban.Text = "";
            lbBankList.DataSource = null;
            txtAdressTitle.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtPoBox.Text = "";
            PostCode.Text = "";
            cbCountry.SelectedIndex = -1;
            cbCity.SelectedIndex = -1;
            cbTown.SelectedIndex = -1;
            AddressDetails.Text = "";
            AdressList.DataSource = null;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            txtContactName.Text = "";
            txtContactPhone.Text = "";
            txtExternalNumber.Text = "";
            txtContactMail.Text = "";
            txtContactMobile.Text = "";
            cmbLanguage.SelectedIndex = -1;
            cmbContactAddress.SelectedIndex = -1;
            txtContactNotes.Text = "";
            ContactList.DataSource = null;
        }

        private void ComboboxFiller()
        {
            cmbDepartment.DataSource = IME.CustomerDepartments.ToList();
            cmbDepartment.DisplayMember = "departmentname";
            cmbDepartment.ValueMember = "ID";

            cmbPosition.DataSource = IME.CustomerTitles.ToList();
            cmbPosition.DisplayMember = "titlename";
            cmbPosition.ValueMember = "ID";

            cmbLanguage.DataSource = IME.Languages.ToList();
            cmbLanguage.DisplayMember = "languagename";
            cmbLanguage.ValueMember = "ID";

            cmbAccountRep.DataSource = IME.Workers.ToList();
            cmbAccountRep.DisplayMember = "NameLastName";
            cmbAccountRep.ValueMember = "WorkerID";
            
            cmbMainCategory.DataSource = IME.SupplierCategories.ToList();
            cmbMainCategory.DisplayMember = "categoryname";
            cmbMainCategory.ValueMember = "ID";
            //SubCategory.DataSource = IME.CustomerSubCategories.Where(a => a.categoryID == (int)MainCategory.SelectedValue);
            //SubCategory.DisplayMember = "subcategoryname";
            //SubCategory.ValueMember = "ID";
            cmbCurrency.DataSource = IME.Currencies.ToList();
            cmbCurrency.DisplayMember = "currencyName";
            cmbCurrency.ValueMember = "currencyId";
            cmbCurrency.SelectedIndex = -1;

            cmbAccountTerms.DataSource = IME.PaymentTerms.OrderBy(p => p.timespan).ToList();
            cmbAccountTerms.DisplayMember = "term_name";
            cmbAccountTerms.ValueMember = "ID";

            cmbAccountMethod.DataSource = IME.PaymentMethods.ToList();
            cmbAccountMethod.DisplayMember = "Payment";
            cmbAccountMethod.ValueMember = "ID";

            cmbRepresentative.DataSource = IME.Workers.ToList();
            cmbRepresentative.DisplayMember = "NameLastName";
            cmbRepresentative.ValueMember = "WorkerID";

            cbCountry.DataSource = IME.Countries.OrderBy(a => a.Country_name).ToList();
            cbCountry.DisplayMember = "Country_name";
            cbCountry.ValueMember = "ID";

            //ContactType.DataSource = IME.ContactTypes.ToList();
            //ContactType.ValueMember = "ID";
            //ContactType.DisplayMember = "ContactTypeName";
        }

        private string NewSupplierNumber()
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

        private void supplierClicksearch(Supplier supplier)
        {
            string supplierID = supplier.ID;

            Supplier s = IME.Suppliers.Where(a => a.ID == supplierID).FirstOrDefault();

            #region Info
            txtSupplierCode.Text = s.ID;
            if (s.Worker1 != null) cmbRepresentative.SelectedValue = s.Worker1.WorkerID;
            txtName.Text = s.s_name;
            txtWeb.Text = s.webadress ?? String.Empty;
            if (s.SupplierCategory != null)
            {
                cmbMainContact.SelectedValue = s.SupplierCategory.ID;
                if (s.SupplierSubCategory != null)
                {
                    cmbMainContact.SelectedValue = s.SubCategoryID;
                }
                else
                {
                    cmbMainContact.SelectedValue = -1;
                }
            }
            txtTaxOffice.Text = s.taxoffice;
            txtTaxNumber.Text = s.taxnumber;
            cmbMainContact.DataSource = IME.SupplierWorkers.Where(sw => sw.supplierID == txtSupplierCode.Text).ToList();
            cmbMainContact.DisplayMember = "sw_name";
            cmbMainContact.ValueMember = "ID";
            txtSupplierNotes.Text = (s.Note1 != null) ? s.Note1.Note_name : String.Empty;
            #endregion

            #region Account
            if (s.accountrepresentaryID != null) cmbAccountRep.Text = IME.Workers.Where(a => a.WorkerID == s.accountrepresentaryID).FirstOrDefault().NameLastName;
            if (s.PaymentTerm != null) cmbAccountTerms.SelectedValue = s.PaymentTerm.ID;
            cmbAccountMethod.SelectedValue = (s.paymentmethodID != null) ? s.paymentmethodID : -1;
            if (s.Currency != null)
            {
                cmbCurrency.SelectedIndex = cmbCurrency.FindStringExact(s.Currency.currencyName);
            }
            else
            {
                cmbCurrency.SelectedIndex = -1;
            }
            if (s.AccountNoteID != null) txtAccountNotes.Text = IME.Notes.Where(a => a.ID == s.AccountNoteID).FirstOrDefault().Note_name;
            #endregion

            #region Bank
            if (s.SupplierBankAccount != null)
            {
                txtBankAccountTitle.Text = IME.SupplierBankAccounts.Where(a => a.ID == s.MainBankAccountID).FirstOrDefault().Title;
                txtBankBranchCode.Text = IME.SupplierBankAccounts.Where(a => a.ID == s.MainBankAccountID).FirstOrDefault().BranchCode;
                txtBankAccountNumber.Text = IME.SupplierBankAccounts.Where(a => a.ID == s.MainBankAccountID).FirstOrDefault().AccountNumber;
                txtBankIban.Text = IME.SupplierBankAccounts.Where(a => a.ID == s.MainBankAccountID).FirstOrDefault().IBAN;
            }
            #endregion

            #region Address
            AdressList.DataSource = IME.SupplierAddresses.Where(sa => sa.SupplierID == txtSupplierCode.Text).ToList();
            AdressList.DisplayMember = "AdressTitle";
            AdressList.ValueMember = "ID";
            #endregion

            #region Contact
            ContactList.DataSource = IME.SupplierWorkers.Where(sa => sa.supplierID == txtSupplierCode.Text).ToList();
            ContactList.DisplayMember = "sw_name";
            ContactList.ValueMember = "ID";
            #endregion
            //cmbContactAddress.DataSource = IME.SupplierAddresses.Where(c => c.SupplierID == txtSupplierCode.Text).ToList();
            //cmbContactAddress.DisplayMember = "Title";
            //AdressList.ValueMember = "ID";

            //string name = s.Worker1.NameLastName;


            //if (s.SupplierCategory != null)
            //{
            //    name = s.SupplierCategory.categoryname;
            //    cmbMainCategory.SelectedIndex = cmbMainCategory.FindStringExact(name);
            //}
            //else
            //{
            //    cmbMainCategory.SelectedIndex = 0;
            //}

            //if (s.Worker != null)
            //{
            //    name = s.Worker.NameLastName;
            //    cmbAccountRep.SelectedIndex = cmbAccountRep.FindString(name);
            //}
            //else
            //{
            //    cmbAccountRep.SelectedIndex = 0;
            //}

            //if (s.PaymentTerm != null)
            //{
            //    name = s.PaymentTerm.term_name;
            //    cmbAccountTerms.SelectedIndex = cmbAccountTerms.FindString(name);
            //}
            //else
            //{
            //    cmbAccountTerms.SelectedIndex = 0;
            //}


            //if (s.PaymentMethod != null)
            //{
            //    name = s.PaymentMethod.Payment;
            //    cmbAccountMethod.SelectedIndex = cmbAccountMethod.FindString(name);
            //}
            //else
            //{
            //    cmbAccountMethod.SelectedIndex = 0;
            //}


            //if (s.Currency != null)
            //{
            //    name = s.Currency.currencyName;
            //    cmbCurrency.SelectedIndex = cmbCurrency.FindStringExact(name);
            //}
            //else
            //{
            //    cmbCurrency.SelectedIndex = 0;
            //}


            ////name = s.SupplierBank.bankname;
            //if (s.SupplierWorker != null)
            //{
            //    name = s.SupplierWorker.sw_name;
            //    cmbMainContact.SelectedIndex = cmbMainContact.FindStringExact(name);
            //}
            //else
            //{
            //    if (cmbMainContact.Items.Count != 0)
            //    {
            //        cmbMainContact.SelectedIndex = 0;
            //    }
            //}


            //SavedAddresses.Clear();
            //foreach (SupplierAddress sa in s.SupplierAddresses)
            //{
            //    SavedAddresses.Add(sa);
            //}
            //AdressList.DataSource = null;
            //AdressList.DataSource = SavedAddresses;
            //AdressList.DisplayMember = "Title";
            //AdressList.ClearSelected();
            //AdressList.Enabled = true;

            //SavedContacts.Clear();
            //foreach (SupplierWorker sw in s.SupplierWorkers)
            //{
            //    SavedContacts.Add(sw);
            //}
            //ContactList.DataSource = null;
            //ContactList.DataSource = SavedContacts;
            //ContactList.DisplayMember = "sw_name";
            //ContactList.ClearSelected();
            //ContactList.Enabled = true;

            //SavedBanks.Clear();
            //foreach (SupplierBankAccount ba in s.SupplierBankAccounts)
            //{
            //    SavedBanks.Add(ba);
            //}
            //lbBankList.DataSource = null;
            //lbBankList.DataSource = SavedBanks;
            //lbBankList.DisplayMember = "Title";
            //lbBankList.ClearSelected();
            //lbBankList.Enabled = true;
        }

        private void EnableMod(bool mod)
        {
            txtSupplierCode.Enabled = mod;
            cmbRepresentative.Enabled = mod;
            txtName.Enabled = mod;
            txtWeb.Enabled = mod;
            cmbMainCategory.Enabled = mod;
            if (cmbSubCategory.Items.Count != 0) cmbSubCategory.Enabled = mod;
            txtTaxOffice.Enabled = mod;
            txtTaxNumber.Enabled = mod;
            cmbMainContact.Enabled = mod;
            txtSupplierNotes.Enabled = mod;
            cmbAccountRep.Enabled = mod;
            cmbAccountTerms.Enabled = mod;
            cmbAccountMethod.Enabled = mod;
            cmbCurrency.Enabled = mod;
            txtAccountNotes.Enabled = mod;
            txtBankAccountNumber.Enabled = mod;
            txtBankAccountTitle.Enabled = mod;
            txtBankBranchCode.Enabled = mod;
            txtBankIban.Enabled = mod;
            lbBankList.DataSource = null;
            txtAdressTitle.Enabled = mod;
            txtPhone.Enabled = mod;
            txtFax.Enabled = mod;
            txtPoBox.Enabled = mod;
            PostCode.Enabled = mod;
            cbCountry.Enabled = mod;
            cbCity.Enabled = mod;
            cbTown.Enabled = mod;
            AddressDetails.Enabled = mod;
            AdressList.DataSource = null;
            cmbDepartment.Enabled = mod;
            cmbPosition.Enabled = mod;
            txtContactName.Enabled = mod;
            txtContactPhone.Enabled = mod;
            txtExternalNumber.Enabled = mod;
            txtContactMail.Enabled = mod;
            txtContactMobile.Enabled = mod;
            cmbLanguage.Enabled = mod;
            cmbContactAddress.Enabled = mod;
            txtContactNotes.Enabled = mod;
            ContactList.DataSource = null;
            btnSave.Enabled = mod;
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

        private void TownAdd_Click(object sender, EventArgs e)
        {
            if (cbCity.SelectedValue != null && cbCity.Text != ComboboxString)
            {
                int city = Convert.ToInt32(cbCity.SelectedValue);
                int country = Convert.ToInt32(cbCountry.SelectedValue);
                FormTownAdd form = new FormTownAdd(country, city);
                form.ShowDialog();
                //this.BringToFront();
                //cbTown.Refresh();

                cbTown.DataSource = IME.Towns.Where(a => a.CityID == (int)cbCity.SelectedValue).ToList();
                cbTown.DisplayMember = "Town_name";
                cbTown.ValueMember = "ID";
            }
            else { MessageBox.Show("Please select a City"); }
        }

        private void btnMainCategoryAdd_Click(object sender, EventArgs e)
        {
            frmSupplierCategoryAdd form = new frmSupplierCategoryAdd();
            form.ShowDialog();
            cmbMainCategory.DataSource = IME.SupplierCategories.ToList();
            cmbMainCategory.DisplayMember = "categoryname";
            cmbMainCategory.ValueMember = "ID";
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
                cmbSubCategory.Items.AddRange(new IMEEntities().SupplierSubCategories.Where(x => x.categoryID == sc.ID).ToArray());
                cmbSubCategory.Items.Insert(0, "Choose");
                cmbSubCategory.SelectedIndex = cmbSubCategory.Items.Count - 1;
            }
        }

        private void FormSupplierAdd_Load(object sender, EventArgs e)
        {
            ComboboxFiller();
        }

        private void AdressList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                #region AddressList (list box a tıklandığında adres bilgileri tıklanana göre doldurulması)

                int cw_ID = (int)AdressList.SelectedValue;
                if (txtName.Text != string.Empty)
                {
                    SupplierAddress c;

                    IMEEntities IME = new IMEEntities();
                    try
                    {
                        c = IME.SupplierAddresses.Where(q => q.ID == cw_ID).FirstOrDefault();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    ContactListItem.ID = cw_ID;
                    txtAdressTitle.Text = c.Title;
                    txtPhone.Text = c.Phone;
                    txtFax.Text = c.Fax;
                    txtPoBox.Text = c.PoBox;
                    PostCode.Text = c.PostCode;
                    cbCountry.SelectedValue = c.CountryID;
                    cbCity.SelectedValue = c.CityID;
                    cbTown.SelectedValue = c.TownID;
                    AddressDetails.Text = c.AdressDetails;
                }
                #endregion
            }
            catch { }
        }

        private void ContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                #region ContactList (list box a tıklandığında contact ın bilgileri tıklanana göre doldurulması)
                int cw_ID = (int)ContactList.SelectedValue;
                if (txtName.Text != string.Empty)
                {
                    ContactListItem.ID = cw_ID;
                    string contactname = ((SupplierWorker)((ListBox)sender).SelectedItem).sw_name;
                    ContactListItem.contactName = contactname;
                    var a = IME.SupplierWorkers.Where(cw => cw.ID == cw_ID).FirstOrDefault();

                    selectedContactID = a.ID;

                    if (a.departmentID != null) cmbDepartment.SelectedValue = a.departmentID;
                    if (a.titleID != null) cmbPosition.SelectedValue = a.titleID;

                    txtContactName.Text = a.sw_name;
                    txtContactPhone.Text = a.phone;
                    txtContactMail.Text = a.sw_email;
                    txtContactFax.Text = a.fax;
                    txtContactMobile.Text = a.mobilephone;
                    cmbLanguage.SelectedValue = a.Language.ID;
                    if (a.SupplierAddress != null) cmbContactAddress.SelectedItem = Int32.Parse(a.SupplierAddress.ToString());
                    if (a.Note != null) { txtContactNotes.Text = a.Note.Note_name; } else { txtContactNotes.Text = ""; }

                }
                #endregion
            }
            catch { }
        }

        private bool ControlSave()
        {
            bool isSave = true;
            string ErrorMessage = string.Empty;
            if (txtName.Text == null || txtName.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Supplier Name\n"; isSave = false; }
            if (isSave == true) { return true; } else { MessageBox.Show(ErrorMessage); return false; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ControlSave())
            {
                Supplier s = new Supplier();

                s = IME.Suppliers.Where(a => a.ID == txtSupplierCode.Text).FirstOrDefault();
               
                if (cmbRepresentative.SelectedValue != null)
                {
                    int s_repID = ((Worker)(cmbRepresentative).SelectedItem).WorkerID;
                    s.representaryID = s_repID;
                }
                s.s_name= txtName.Text;
                s.webadress = txtWeb.Text;
                if (cmbMainCategory.SelectedValue != null)
                { s.CategoryID = Int32.Parse(cmbMainCategory.SelectedValue.ToString()); }
                if (cmbSubCategory.SelectedValue != null) { s.SubCategoryID = Int32.Parse(cmbSubCategory.SelectedValue.ToString()); }
                s.taxoffice = txtTaxOffice.Text;
                s.taxnumber = txtTaxNumber.Text;
                if (cmbMainCategory.SelectedValue != null)
                {
                    s.MainContactID = (int)cmbMainCategory.SelectedValue;
                }
                if (cmbAccountRep.SelectedItem != null)
                {
                    s.accountrepresentaryID = (cmbAccountRep.SelectedItem as Worker).WorkerID;
                }
                if (cmbAccountTerms.SelectedValue != null)
                {
                    int c_termpayment = ((PaymentTerm)(cmbAccountTerms).SelectedItem).ID;
                    s.payment_termID = c_termpayment;
                }
                if (cmbAccountMethod.SelectedValue != null)
                {
                    int c_paymentmeth = ((PaymentMethod)(cmbAccountMethod).SelectedItem).ID;
                    s.paymentmethodID = c_paymentmeth;
                }
                if (cmbCurrency.SelectedValue != null)
                {
                    decimal c_currency = ((Currency)(cmbCurrency).SelectedItem).currencyID;
                    s.Currency.currencyID = c_currency;
                }

                //Notes kısmına kayıt ediliyor
                Note n1 = new Note();
                try { n1 = IME.Notes.Where(a => a.ID == s.Note.ID).FirstOrDefault(); } catch { }
                if (s.Note == null)
                {
                    n1.Note_name = txtSupplierNotes.Text;
                    s.Note = n1;
                    IME.Notes.Add(s.Note);
                    IME.SaveChanges();
                }
                else
                {
                    n1.Note_name = txtSupplierNotes.Text;
                    IME.SaveChanges();
                }
                if (s.AccountNoteID == null)
                {
                    Note n = new Note();
                    n.Note_name = txtAccountNotes.Text;
                    IME.Notes.Add(n);
                    IME.SaveChanges();
                    s.AccountNoteID = n.ID;
                }
                else
                {
                    Note n = IME.Notes.Where(a => a.ID == s.AccountNoteID).FirstOrDefault();
                    n.Note_name = txtAccountNotes.Text;
                    IME.SaveChanges();
                }
                if (s.Worker.WorkerNoteID == null)
                {
                    Note n = new Note();
                    n.Note_name = txtContactNotes.Text;
                    IME.Notes.Add(n);
                    IME.SaveChanges();
                    s.Worker.WorkerNoteID = n.ID;
                }
                else
                {
                    Note n = IME.Notes.Where(a => a.ID == s.Worker.WorkerNoteID).FirstOrDefault();
                    n.Note_name = txtContactNotes.Text;
                    IME.SaveChanges();
                }
                IME.SaveChanges();
                MessageBox.Show("Supplier save succesfully");
                Utils.LogKayit("Supplier", "Supplier update");
                this.Close();

            }
        }
    }
}
