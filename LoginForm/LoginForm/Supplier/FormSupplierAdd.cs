using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static LoginForm.Services.MyClasses.MyAuthority;

namespace LoginForm
{
    public partial class FormSupplierAdd : Form
    {
        FormSupplierMain parent;
        IMEEntities IME = new IMEEntities();

        string ComboboxString = "Choose";
        int isUpdateAdress;
        int selectedContactID;
        int contactnewID = 0;
        BindingList<SupplierBankAccount> SavedBanks = new BindingList<SupplierBankAccount>();
        string BankMode = String.Empty;
        public FormSupplierAdd()
        {
            InitializeComponent();
        }

        public FormSupplierAdd(Supplier supplier, string form)
        {
            InitializeComponent();
            ComboboxFiller();

            //ComboboxFiller();
            if (form == "View")
            {
                supplierClicksearch(supplier);
                EnableMod(false);
                lbContacts.Enabled = true;
                lbAddressList.Enabled = true;
                lbBankList.Enabled = true;
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
            NewSupplierNumber();
            ComboboxFiller();

            #region BankAccount

            txtBankAccountTitle.Text = String.Empty;
            txtBankAccountTitle.Enabled = true;
            txtBankBranchCode.Text = String.Empty;
            txtBankBranchCode.Enabled = true;
            txtBankAccountNumber.Text = String.Empty;
            txtBankAccountNumber.Enabled = true;
            txtBankIban.Text = String.Empty;
            txtBankIban.Enabled = true;
            lbBankList.Enabled = false;
            lbBankList.DataSource = null;
            lbBankList.Refresh();

            btnBankAdd.Text = "Save";
            btnBankAdd.Enabled = true;
            btnBankUpdate.Text = "Cancel";
            btnBankUpdate.Enabled = true;

            btnBankDelete.Visible = false;

           // BankMode = "Add";

            #endregion

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

        private void NewSupplierNumber()
        {
            DataSet.Management m = Utils.getManagement();

            //for new customerCode
            IMEEntities db = new IMEEntities();
            string suppliercode = "";
            string NewID = string.Empty;
            if (db.Suppliers.ToList().Count != 0)
            {
                suppliercode = db.Suppliers.OrderByDescending(a => a.ID).FirstOrDefault().ID;

                int newSupplierCodeNumbers = 0;
                string newsuppliercodechars = string.Empty;
               

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
                txtSupplierCode.Text = NewID;
            }
            else
            {
                NewID = "SC0001";
                txtSupplierCode.Text = NewID;
            }
            Supplier newCustomer = new Supplier();
            
            newCustomer.ID = txtSupplierCode.Text;
            IME.Suppliers.Add(newCustomer);
            IME.SaveChanges();
            Utils.LogKayit("Supplier", "Supplier added");
            lblClose.Text = "Cancel";
            lbBankList.DataSource = null;
            lbBankList.Enabled = false;
            lbAddressList.Enabled = false;
            lbAddressList.DataSource = null;
            lbContacts.DataSource = null;
            lbContacts.Enabled = false;

            btnAddressAdd.Enabled = true;
            btnContactNew.Enabled = true;
            btnBankAdd.Enabled = true;
            btnContactClick();
            btnAddressClick();
            btnSave.Enabled = true;
            btnClose.Enabled = true;
        }

        private void FormSupplierAdd_Load(object sender, EventArgs e)
        {
            //checkAuthorities();
        }

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
            txtAddressTitle.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtPoBox.Text = "";
            txtPostCode.Text = "";
            cmbCountry.SelectedIndex = -1;
            cmbCity.SelectedIndex = -1;
            cmbTown.SelectedIndex = -1;
            txtAddressDetail.Text = "";
            lbAddressList.DataSource = null;
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
            lbContacts.DataSource = null;
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

            cmbCountry.DataSource = IME.Countries.OrderBy(a => a.Country_name).ToList();
            cmbCountry.DisplayMember = "Country_name";
            cmbCountry.ValueMember = "ID";

            //ContactType.DataSource = IME.ContactTypes.ToList();
            //ContactType.ValueMember = "ID";
            //ContactType.DisplayMember = "ContactTypeName";
        }

        private void supplierClicksearch(Supplier supplier)
        {
            string supplierID = supplier.ID;

            Supplier s = IME.Suppliers.Where(a => a.ID == supplierID).FirstOrDefault();

            #region Info
            txtSupplierCode.Text = s.ID;
            if (s.Worker1 != null) cmbRepresentative.SelectedValue = s.representaryID;
            txtName.Text = s.s_name;
            txtWeb.Text = s.webadress?.ToString();
            
            cmbMainContact.DataSource = IME.SupplierWorkers.Where(sw => sw.supplierID == txtSupplierCode.Text).ToList();
            cmbMainContact.DisplayMember = "sw_name";
            cmbMainContact.ValueMember = "ID";

            if (s.SupplierCategory != null)
            {
                cmbMainCategory.SelectedValue = s.CategoryID;
                if (s.SupplierSubCategory != null)
                {
                    cmbSubCategory.SelectedIndex = cmbSubCategory.FindStringExact(s.SupplierSubCategory.subcategoryname);
                }
                else
                {
                    cmbSubCategory.SelectedIndex = -1;
                }
            }
            txtTaxOffice.Text = s.taxoffice;
            txtTaxNumber.Text = s.taxnumber;
            txtSupplierNotes.Text = s.Note1?.Note_name;
            #endregion

            #region Address
            lbAddressList.DataSource = IME.SupplierAddresses.Where(sa => sa.SupplierID == supplierID).ToList();
            lbAddressList.DisplayMember = "Title";
            lbAddressList.ValueMember = "ID";
            #endregion

            #region Contact
            lbContacts.DataSource = IME.SupplierWorkers.Where(sa => sa.supplierID == supplierID).ToList();
            lbContacts.DisplayMember = "sw_name";
            lbContacts.ValueMember = "ID";
            #endregion

            #region Account
            if (s.accountrepresentaryID != null) cmbAccountRep.SelectedValue = s.Worker.WorkerID;
            if (s.PaymentTerm != null) cmbAccountTerms.SelectedValue = s.payment_termID;
            if (s.paymentmethodID != null) cmbAccountMethod.SelectedValue = s.paymentmethodID;
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
            if (s.SupplierBankAccounts != null)
            {
                lbBankList.DataSource = IME.SupplierBankAccounts.Where(a => a.SupplierID == s.ID).ToList();
                lbBankList.DisplayMember = "Title";
                lbBankList.ValueMember = "ID";
            }
            #endregion



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
            lbBankList.Enabled = mod;
            txtAddressTitle.Enabled = mod;
            txtPhone.Enabled = mod;
            txtFax.Enabled = mod;
            txtPoBox.Enabled = mod;
            txtPostCode.Enabled = mod;
            cmbCountry.Enabled = mod;
            cmbCity.Enabled = mod;
            cmbTown.Enabled = mod;
            txtAddressDetail.Enabled = mod;
            //lbAddressList.DataSource = null;
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
            //lbContacts.DataSource = null;
            btnSave.Enabled = mod;
        }

        private void contactTabEnableFalse()
        {
            #region contactTabEnableFalse
            cmbDepartment.Enabled = false;
            btnDep.Enabled = false;

            cmbPosition.Enabled = false;
            btnDep.Enabled = false;
            txtContactName.Enabled = false;
            txtContactMail.Enabled = false;
            txtContactPhone.Enabled = false;
            txtExternalNumber.Enabled = false;
            cmbContactAddress.Enabled = false;
            txtContactMobile.Enabled = false;
            txtContactFax.Enabled = false;
            cmbLanguage.Enabled = false;
            txtContactNotes.Enabled = false;

            btnPos.Enabled = false;
            lbContacts.Enabled = true;

            btnContactNew.Enabled = true;
            if (lbContacts.DataSource != null)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }
            else
            {
                btnContactDelete.Enabled = false;
                btnContactUpdate.Enabled = false;
            }

            btnContactNew.Enabled = false;

            btnSave.Enabled = true;

            btnContactNew.Enabled = true;
            if (lbContacts.DataSource != null)
            {
                btnContactUpdate.Enabled = true;
                btnContactDelete.Enabled = true;
            }

            #endregion
        }

        private void contactTabEnableTrue()
        {
            #region contactTabEnableTrue
            cmbDepartment.Enabled = true;
            btnDep.Enabled = true;
            cmbPosition.Enabled = true;
            btnDep.Enabled = true;
            txtContactName.Enabled = true;
            txtContactMail.Enabled = true;
            txtContactPhone.Enabled = true;
            txtExternalNumber.Enabled = true;
            cmbContactAddress.Enabled = true;
            txtContactMobile.Enabled = true;
            txtContactFax.Enabled = true;
            cmbLanguage.Enabled = true;
            txtContactNotes.Enabled = true;

            btnPos.Enabled = true;
            lbContacts.Enabled = false;

            btnContactNew.Enabled = true;
            if (lbContacts.Items.Count > 0)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }

            if (lbAddressList.Items.Count > 0)
            {
                btnAddressDelete.Enabled = true;
                btnAddressUpdate.Enabled = true;
            }
            btnAddressAdd.Enabled = true;
            btnContactNew.Enabled = false;
            btnContactDelete.Enabled = false;
            btnContactUpdate.Enabled = false;
            btnSave.Enabled = false;
            groupContact.Enabled = true;
            #endregion
        }

        private void AdressTabEnableFalse()
        {
            #region AdressTabEnableFalse
            cmbCountry.Enabled = false;
            cmbCity.Enabled = false;
            cmbTown.Enabled = false;
            txtPostCode.Enabled = false;
            txtAddressTitle.Enabled = false;
            CityAdd.Enabled = false;
            TownAdd.Enabled = false;
            txtAddressDetail.Enabled = false;
            lbAddressList.Enabled = true;
            if (lbContacts.DataSource != null)
            {
                btnAddressDelete.Enabled = true;
                btnAddressUpdate.Enabled = true;
            }
            btnAddressAdd.Enabled = true;
            btnSave.Enabled = true;
            #endregion
        }

        private void AdressTabEnableTrue()
        {
            #region contactTabEnableTrue
            cmbCountry.Enabled = true;
            cmbCity.Enabled = true;
            cmbTown.Enabled = true;
            txtPostCode.Enabled = true;
            txtAddressTitle.Enabled = true;
            CityAdd.Enabled = true;
            TownAdd.Enabled = true;
            txtAddressDetail.Enabled = true;
            lbAddressList.Enabled = false;
            btnAddressAdd.Enabled = false;
            btnAddressDelete.Enabled = false;
            btnAddressUpdate.Enabled = false;
            btnSave.Enabled = false;
            groupAddresses.Enabled = true;
            #endregion
        }

        private void btnContactClick()
        {
            #region addContactButton
            contactnewID = 0;
            contactTabEnableTrue();

            cmbDepartment.Text = "";
            cmbPosition.Text = "";
            cmbMainContact.Text = "";
            txtContactName.Text = "";
            txtContactPhone.Text = "";
            txtExternalNumber.Text = "";
            txtContactMail.Text = "";
            txtContactFax.Text = "";
            txtContactMobile.Text = "";
            cmbLanguage.Text = "";
            cmbContactAddress.Text = "";
            txtContactNotes.Text = "";

            btnContactNew.Visible = false;
            btnContactCancel.Visible = true;
            btnContactDelete.Visible = false;
            btnContactDone.Visible = true;
            btnContactUpdate.Visible = false;
            lbContacts.Enabled = false;

            cmbContactAddress.Text = (ComboboxString);
            cmbDepartment.Text = (ComboboxString);
            cmbPosition.Text = (ComboboxString);
            cmbLanguage.Text = (ComboboxString);
            #endregion
        }

        private void btnAddressClick()
        {
            isUpdateAdress = 0;
            AdressTabEnableTrue();
            cmbCountry.Text = "";
            cmbCity.Text = "";
            cmbTown.Text = "";
            txtPostCode.Text = "";
            txtAddressTitle.Text = "";
            txtAddressDetail.Text = "";
            txtPoBox.Text = "";
            txtFax.Text = "";
            txtPhone.Text = "";
            btnAddressAdd.Visible = false;
            btnAddressCancel.Visible = true;
            btnAddressDelete.Visible = false;
            btnAddressDone.Visible = true;
            btnAddressUpdate.Visible = false;
            lbAddressList.Enabled = false;

            cmbCountry.Text = (ComboboxString);
            cmbCity.Text = (ComboboxString);
            cmbTown.Text = (ComboboxString);
        }

        private bool AddressControl()
        {
            bool isSave = true;
            string ErrorMessage = string.Empty;
            if (cmbCity.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter City"; isSave = false; }
            if (cmbTown.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Town"; isSave = false; }
            if (isSave == true) { return true; } else { MessageBox.Show(ErrorMessage); return false; }
        }

        private bool ControlSave()
        {
            bool isSave = true;
            string ErrorMessage = string.Empty;
            if (txtName.Text == null || txtName.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Supplier's Name\n"; isSave = false; }
            if (isSave == true) { return true; } else { MessageBox.Show(ErrorMessage); return false; }
        }

        private void CancelCustomer()
        {
            var Supplier = IME.Suppliers.Where(x=> x.ID == txtSupplierCode.Text).FirstOrDefault();
            if (Supplier != null)
            {
                //CREATE in cancel ı
                var cw = IME.SupplierWorkers.Where(a => a.supplierID == txtSupplierCode.Text);
                //Contact
                while (cw.Count() > 0)
                {
                    IME.SupplierWorkers.Remove(cw.FirstOrDefault());
                    IME.SaveChanges();
                }
                //adresses
                var cd = IME.SupplierAddresses.Where(a => a.SupplierID == txtSupplierCode.Text);
                while (cd.Count() > 0)
                {
                    IME.SupplierAddresses.Remove(cd.FirstOrDefault());
                    IME.SaveChanges();
                }
                //bank
                var cb = IME.SupplierBankAccounts.Where(a => a.SupplierID == txtSupplierCode.Text);
                while (cb.Count() > 0)
                {
                    IME.SupplierBankAccounts.Remove(cb.FirstOrDefault());
                    IME.SaveChanges();
                }

                Supplier c = new Supplier();
                c = IME.Suppliers.Where(a => a.ID == txtSupplierCode.Text).FirstOrDefault();
                IME.Suppliers.Remove(c);
                IME.SaveChanges();
            }
            itemsClear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (lblClose.Text != "Close")
            {
                base.OnFormClosing(e);

                if (e.CloseReason == CloseReason.WindowsShutDown) return;

                // Confirm user wants to close
                switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        CancelCustomer();
                        break;
                    default:
                        break;
                }
            }
        }

        private void MakeTextUpperCase(TextBox txtBox)
        {
            txtBox.Text = txtBox.Text.ToUpperInvariant();
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

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
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

        private void lbBankList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBankList.SelectedIndex >= 0)
            {
                BankAccountFill((SupplierBankAccount)lbBankList.SelectedItem);
            }
            else
            {
                ClearBankAccountInputs();
            }
        }

        private void BankAccountFill(SupplierBankAccount bank)
        {
            txtBankAccountTitle.Text = bank.Title;
            txtBankIban.Text = bank.IBAN;
            txtBankBranchCode.Text = bank.BranchCode?.ToString();
            txtBankAccountNumber.Text = bank.AccountNumber?.ToString();
        }

        private void ClearBankAccountInputs()
        {
            txtBankAccountTitle.Text = String.Empty;
            txtBankBranchCode.Text = String.Empty;
            txtBankAccountNumber.Text = String.Empty;
            txtBankIban.Text = String.Empty;
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
            if (list.Count > 1)
            {
                list.RemoveAt(0);
                string PositionName = (worker.titleID != null) ? (list.Cast<CustomerTitle>().Where(x => x.ID == worker.titleID).FirstOrDefault().titlename) : "Choose";
                cmbPosition.SelectedIndex = cmbPosition.FindStringExact(PositionName);
                cmbPosition.Enabled = txtContactName.Enabled;
                btnPos.Enabled = txtContactName.Enabled;
            }

            list = lbAddressList.Items.Cast<object>().ToList();
            string AddressTitle = (worker.SupplierAddress != null) ? (list.Cast<SupplierAddress>().Where(x => x.Title == worker.SupplierAddress.Title).FirstOrDefault().Title) : String.Empty;


            cmbContactAddress.DataSource = IME.SupplierAddresses.Where(x => x.SupplierID == worker.supplierID).ToList();
            cmbContactAddress.DisplayMember = "Title";
            cmbContactAddress.ValueMember = "ID";
            if (AddressTitle != String.Empty)
            {
                cmbContactAddress.SelectedValue = worker.supplieradressID;
            }
            else
            {
                cmbContactAddress.SelectedIndex = -1;
            }

            list = cmbLanguage.Items.Cast<object>().ToList();
            //list.RemoveAt(0);
            if (worker.languageID != null)
            {
                string Language = list.Cast<Language>().Where(x => x.ID == worker.languageID).FirstOrDefault().languagename;
                cmbLanguage.SelectedIndex = cmbLanguage.FindStringExact(Language);
            }
            list = null;

            txtContactName.Text = worker.sw_name;
            txtContactPhone.Text = worker.phone;
            txtExternalNumber.Text = worker.PhoneExternalNum;
            txtContactMail.Text = worker.sw_email;
            txtContactFax.Text = worker.fax;
            txtContactMobile.Text = worker.mobilephone;
            txtContactNotes.Text = (worker.Note != null) ? worker.Note.Note_name : String.Empty;
        }

        private void cmbMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMainCategory.Items.Count != 0)
            {
                if (cmbMainCategory.SelectedIndex > 0)
                {
                    int id = ((SupplierCategory)cmbMainCategory.SelectedItem).ID;

                    cmbSubCategory.Items.Clear();
                    cmbSubCategory.Items.AddRange(new IMEEntities().SupplierSubCategories.Where(x => x.categoryID == id).ToArray());
                    cmbSubCategory.Items.Insert(0, "Choose");
                    cmbSubCategory.DisplayMember = "subcategoryname";
                    cmbSubCategory.ValueMember = "ID";
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
            }
            else
            {
                cmbSubCategory.Enabled = true;
                btnSubCategoryAdd.Enabled = false;
            }
        }

        #region Address
        private void btnAddressDoneClick()
        {
            SupplierAddress ca = new SupplierAddress();
            if (isUpdateAdress == 1)
            {
                int caID = ((lbAddressList).SelectedItem as SupplierAddress).ID;
                ca = IME.SupplierAddresses.Where(a => a.ID == caID).FirstOrDefault();
            }
            else { ca = null; }

            if (ca != null)
            {
                ca.SupplierID = txtSupplierCode.Text;
                ca.Title = txtAddressTitle.Text;
                ca.Phone = txtPhone.Text;
                ca.Fax = txtFax.Text;
                ca.PoBox = txtPoBox.Text;
                ca.PostCode = txtPostCode.Text;
                ca.CountryID = ((cmbCountry).SelectedItem as Country).ID;
                ca.CityID = ((cmbCity).SelectedItem as City).ID;
                ca.TownID = ((cmbTown).SelectedItem as Town).ID;
                ca.AdressDetails = txtAddressDetail.Text;

                IME.SaveChanges();
                Utils.LogKayit("Supplier", "Supplier address update");
            }
            else
            {
                if (AddressControl())
                {
                    ca = new SupplierAddress
                    {
                        SupplierID = txtSupplierCode.Text,
                        Title = txtAddressTitle.Text,
                        Phone = txtPhone.Text,
                        Fax = txtFax.Text,
                        PoBox = txtPoBox.Text,
                        PostCode = txtPostCode.Text,
                        CountryID = ((cmbCountry).SelectedItem as Country).ID,
                        CityID = ((cmbCity).SelectedItem as City).ID,
                        TownID = ((cmbTown).SelectedItem as Town).ID,
                        AdressDetails = txtAddressDetail.Text
                    };
                }
                IME.SupplierAddresses.Add(ca);
                IME.SaveChanges();
                Utils.LogKayit("Supplier", "Supplier address added");
            }
            AdressTabEnableFalse();
            lbAddressList.DataSource = null;
            lbAddressList.DataSource = IME.SupplierAddresses.Where(customerw => customerw.SupplierID == txtSupplierCode.Text).ToList();
            lbAddressList.DisplayMember = "Title";
            cmbContactAddress.DataSource = null;
            cmbContactAddress.DataSource = IME.SupplierAddresses.Where(customerw => customerw.SupplierID == txtSupplierCode.Text).ToList();
            cmbContactAddress.DisplayMember = "Title";
            btnAddressAdd.Visible = true;
            btnAddressDelete.Visible = true;
            btnAddressUpdate.Visible = true;
            btnAddressCancel.Visible = false;
            btnAddressDone.Visible = false;
        }

        private void btnAddressAdd_Click(object sender, EventArgs e)
        {
            btnAddressClick();
        }

        private void btnAddressDone_Click(object sender, EventArgs e)
        {
            btnAddressDoneClick();
        }

        private void btnAddressUpdate_Click(object sender, EventArgs e)
        {
            isUpdateAdress = 1;
            #region  AdressUpd
            AdressTabEnableTrue();
            btnAddressAdd.Visible = false;
            btnAddressCancel.Visible = true;
            btnAddressDelete.Visible = false;
            btnAddressDone.Visible = true;
            btnAddressUpdate.Visible = false;
            #endregion
        }

        private void btnAddressDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Delete This Adress ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SupplierAddress ca = IME.SupplierAddresses.First(a => a.ID == ContactListItem.AdressID);
                IME.SupplierAddresses.Remove(ca);
                IME.SaveChanges();
                lbAddressList.DataSource = IME.SupplierAddresses.Where(customerw => customerw.SupplierID == txtSupplierCode.Text).ToList();
                lbAddressList.DisplayMember = "Title";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void btnAddressCancel_Click(object sender, EventArgs e)
        {
            AdressTabEnableFalse();

            lbAddressList.DataSource = IME.SupplierAddresses.Where(customerw => customerw.SupplierID == txtSupplierCode.Text).ToList();
            lbAddressList.DisplayMember = "Title";

            btnAddressAdd.Visible = true;
            btnAddressCancel.Visible = true;
            btnAddressDelete.Visible = true;
            btnAddressDone.Visible = false;
            btnAddressUpdate.Visible = false;
        }

        #endregion

        #region Contact

        private void btnContactDoneClick()
        {
            if (contactnewID == 0)
            {
                SupplierWorker cw = new SupplierWorker();
               
                cw.supplierID = txtSupplierCode.Text;
                cw.departmentID = ((CustomerDepartment)(cmbDepartment).SelectedItem).ID;
                cw.titleID = ((CustomerTitle)(cmbPosition).SelectedItem).ID;
                cw.sw_name = txtContactName.Text;
                cw.sw_email = txtContactMail.Text;
                cw.phone = txtContactPhone.Text;
                cw.mobilephone = txtContactMobile.Text;
                cw.fax = txtContactFax.Text;
                if (cmbLanguage.SelectedItem != null) cw.languageID = ((Language)(cmbLanguage).SelectedItem).ID;
                if (cmbContactAddress.SelectedItem != null) cw.supplieradressID = (cmbContactAddress.SelectedItem as SupplierAddress).ID;
                
                Note n = new Note();
                n.Note_name = txtContactNotes.Text;
                IME.Notes.Add(n);
                IME.SaveChanges();
                cw.supplierNoteID = n.ID;
                IME.SupplierWorkers.Add(cw);
                Utils.LogKayit("Supplier", "Supplier contact added");
                IME.SaveChanges();
                lbContacts.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtSupplierCode.Text).ToList();
                lbContacts.DisplayMember = "sw_name";
                lbContacts.ValueMember = "ID";
                cmbMainContact.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtSupplierCode.Text).ToList();
                cmbMainContact.DisplayMember = "sw_name";
                cmbMainContact.ValueMember = "ID";
                contactTabEnableFalse();
            }
            else
            {
                SupplierWorker cw = IME.SupplierWorkers.Where(a => a.ID == ((SupplierWorker)(lbContacts).SelectedItem).ID).FirstOrDefault();
                if (cw.sw_name != "")
                {
                    //UPDATE CONTACT
                    cw.supplierID = txtSupplierCode.Text;
                    cw.departmentID = ((CustomerDepartment)(cmbDepartment).SelectedItem).ID;
                    cw.titleID = ((CustomerTitle)(cmbPosition).SelectedItem).ID;
                    cw.sw_name = txtContactName.Text;
                    cw.sw_email = txtContactMail.Text;
                    cw.phone = txtContactPhone.Text;
                    cw.mobilephone = txtContactMobile.Text;
                    cw.fax = txtContactFax.Text;
                    cw.languageID = ((Language)(cmbLanguage).SelectedItem).ID;
                    if (cmbContactAddress.SelectedItem != null) cw.supplieradressID = (cmbContactAddress.SelectedItem as SupplierAddress).ID;
                    var contactNote = IME.Notes.Where(a => a.ID == cw.supplierNoteID).FirstOrDefault();
                    if (contactNote == null)
                    {
                        if (txtContactNotes.Text != "")
                        {
                            Note n = new Note();
                            n.Note_name = txtContactNotes.Text;
                            IME.Notes.Add(n);
                            IME.SaveChanges();
                            cw.supplierNoteID = n.ID;
                        }
                    }
                    else
                    {
                        contactNote.Note_name = txtContactNotes.Text;
                        IME.SaveChanges();
                        cw.supplierNoteID = contactNote.ID;
                    }
                    IME.SaveChanges();
                    Utils.LogKayit("Supplier", "Supplier contact update");
                    contactTabEnableFalse();
                    
                    lbContacts.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtSupplierCode.Text).ToList();
                    lbContacts.DisplayMember = "sw_name";
                    lbContacts.ValueMember = "ID";
                    cmbMainContact.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtSupplierCode.Text).ToList();
                    cmbMainContact.DisplayMember = "sw_name";
                    cmbMainContact.ValueMember = "ID";
                }
                else { MessageBox.Show("Please choose a contact to update"); }
            }

            btnContactNew.Visible = true;
            btnContactDelete.Visible = true;
            btnContactUpdate.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDone.Visible = false;
        }

        private void btnContactUpdateClick()
        {
            contactnewID = 1;
            contactTabEnableTrue();
            btnContactNew.Visible = false;
            btnContactCancel.Visible = true;
            btnContactDelete.Visible = false;
            btnContactDone.Visible = true;
            btnContactUpdate.Visible = false;
        }

        private void btnContactDone_Click(object sender, EventArgs e)
        {
            btnContactDoneClick();
        }

        private void btnContactCancel_Click(object sender, EventArgs e)
        {
            #region btnContactCancel
            contactTabEnableFalse();
            btnContactNew.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDelete.Visible = true;
            btnContactDone.Visible = false;
            btnContactUpdate.Visible = true;
            #endregion
        }

        private void btnContactDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Delete Contact " + ContactListItem.contactName + " ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SupplierWorker cw = IME.SupplierWorkers.First(a => a.ID == (int)lbContacts.SelectedValue);
                IME.SupplierWorkers.Remove(cw);
                IME.SaveChanges();
                cmbDepartment.SelectedIndex = -1;
                cmbPosition.SelectedIndex = -1;
                txtContactName.Text = "";
                txtContactMail.Text = "";
                txtContactPhone.Text = "";
                txtContactMobile.Text = "";
                txtContactFax.Text = "";
                cmbLanguage.SelectedIndex = -1;
                txtContactNotes.Text = "";
                lbContacts.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtSupplierCode.Text).ToList();
                lbContacts.DisplayMember = "sw_name";
                lbContacts.ValueMember = "ID";
                cmbMainContact.DataSource = null;
                cmbMainContact.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtSupplierCode.Text).ToList();
                cmbMainContact.DisplayMember = "sw_name";
                cmbMainContact.ValueMember = "ID";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void btnContactUpdate_Click(object sender, EventArgs e)
        {
            btnContactUpdateClick();
        }

        private void btnContactNew_Click(object sender, EventArgs e)
        {
            btnContactClick();
        }

        #endregion

        #region Bank

        private void btnBankAddClick()
        {
            if (btnBankAdd.Text == "Save")
            {
                if (txtBankAccountTitle.Text.Trim() != String.Empty)
                {
                    if (BankMode == "Add")
                    {
                        SupplierBankAccount bank = new SupplierBankAccount
                        {
                            SupplierID = txtSupplierCode.Text,
                            Title = txtBankAccountTitle.Text,
                            BranchCode = txtBankBranchCode.Text,
                            AccountNumber = txtBankAccountNumber.Text,
                            IBAN = txtBankIban.Text
                        };
                        IME.SupplierBankAccounts.Add(bank);
                        IME.SaveChanges();
                    }
                    else if (BankMode == "Update")
                    {
                        SupplierBankAccount bank1 = IME.SupplierBankAccounts.Where(x => x.ID == ((SupplierBankAccount)(lbBankList).SelectedItem).ID).FirstOrDefault();

                        bank1.Title = txtBankAccountTitle.Text;
                        bank1.BranchCode = txtBankBranchCode.Text;
                        bank1.AccountNumber = txtBankAccountNumber.Text;
                        bank1.IBAN = txtBankIban.Text;

                        IME.SaveChanges();
                    }


                    lbBankList.DataSource = null;
                    lbBankList.DataSource = IME.SupplierBankAccounts.Where(x => x.SupplierID == txtSupplierCode.Text).ToList(); ;
                    lbBankList.DisplayMember = "Title";
                    lbBankList.SelectedIndex = -1;

                    txtBankAccountTitle.Text = String.Empty;
                    txtBankAccountTitle.Enabled = false;
                    txtBankBranchCode.Text = String.Empty;
                    txtBankBranchCode.Enabled = false;
                    txtBankAccountNumber.Text = String.Empty;
                    txtBankAccountNumber.Enabled = false;
                    txtBankIban.Text = String.Empty;
                    txtBankIban.Enabled = false;
                    lbBankList.Enabled = true;

                    btnBankAdd.Text = "Add";
                    btnBankAdd.Enabled = true;
                    btnBankUpdate.Text = "Update";
                    btnBankUpdate.Enabled = true;

                    btnBankDelete.Visible = true;
                    btnBankDelete.Enabled = true;



                    BankMode = "";


                }
            }
            else if (btnBankAdd.Text == "Add")
            {
                BankMode = "Add";

                txtBankAccountTitle.Text = String.Empty;
                txtBankAccountTitle.Enabled = true;
                txtBankBranchCode.Text = String.Empty;
                txtBankBranchCode.Enabled = true;
                txtBankAccountNumber.Text = String.Empty;
                txtBankAccountNumber.Enabled = true;
                txtBankIban.Text = String.Empty;
                txtBankIban.Enabled = true;
                lbBankList.Enabled = false;

                btnBankAdd.Text = "Save";
                btnBankAdd.Enabled = true;
                btnBankUpdate.Text = "Cancel";
                btnBankUpdate.Enabled = true;

                btnBankDelete.Visible = false;
            }
        }

        private void btnBankAdd_Click(object sender, EventArgs e)
        {
            btnBankAddClick();
        }

        private void btnBankUpdate_Click(object sender, EventArgs e)
        {
            if (lbBankList.SelectedIndex != -1)
            {
                if (btnBankUpdate.Text == "Update")
                {
                    BankMode = "Update";
                    lbBankList.Enabled = false;

                    txtBankAccountTitle.Enabled = true;
                    txtBankBranchCode.Enabled = true;
                    txtBankAccountNumber.Enabled = true;
                    txtBankIban.Enabled = true;

                    btnBankDelete.Visible = false;
                    btnBankAdd.Text = "Save";
                    btnBankUpdate.Text = "Cancel";

                }
                else if (btnBankUpdate.Text == "Cancel")
                {
                    BankMode = String.Empty;
                    ClearBankAccountInputs();
                    lbBankList.Enabled = true;

                    btnBankDelete.Visible = true;
                    btnBankAdd.Text = "Add";
                    btnBankUpdate.Text = "Update";
                    if (lbBankList.Items.Count > 0)
                    {
                        btnBankUpdate.Enabled = true;
                        btnBankDelete.Enabled = true;
                        BankAccountFill((SupplierBankAccount)lbBankList.SelectedItem);
                    }
                    else
                    {
                        btnBankDelete.Enabled = false;
                        btnBankUpdate.Enabled = false;
                    }

                    txtBankAccountTitle.Enabled = false;
                    txtBankBranchCode.Enabled = false;
                    txtBankAccountNumber.Enabled = false;
                    txtBankIban.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please select an bank account from the list", "Warning");
            }
        }

        private void btnBankDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Selected Bank Account Will Be Deleted! Do You Confirm?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (lbBankList.SelectedIndex != -1)
                {
                    SupplierBankAccount ba = (SupplierBankAccount)lbBankList.SelectedItem;
                    SavedBanks.Remove(ba);

                    ClearBankAccountInputs();

                    lbBankList.Enabled = true;
                    txtBankAccountTitle.Enabled = false;
                    txtBankBranchCode.Enabled = false;
                    txtBankAccountNumber.Enabled = false;
                    txtBankIban.Enabled = false;

                    if (lbBankList.Items.Count <= 0)
                    {
                        btnBankUpdate.Enabled = false;
                        btnBankDelete.Enabled = false;
                    }

                    lbBankList.ClearSelected();
                }
                else
                {
                    MessageBox.Show("Please choose an address from the list!", "Warning");
                }
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ControlSave())
            {
                Supplier c = new Supplier();

                c = IME.Suppliers.Where(a => a.ID == txtSupplierCode.Text).FirstOrDefault();
                if (cmbRepresentative.SelectedValue != null) { c.representaryID = Int32.Parse(cmbRepresentative.SelectedValue.ToString()); }
                c.s_name = txtName.Text;
                c.webadress = txtWeb.Text;
                if (cmbMainCategory.SelectedValue != null) { c.CategoryID = Int32.Parse(cmbMainCategory.SelectedValue.ToString()); }
                if (cmbSubCategory.SelectedValue != null) { c.SubCategoryID = Int32.Parse(cmbSubCategory.SelectedValue.ToString()); }
                if (txtTaxOffice.Text != "") { c.taxoffice = txtTaxOffice.Text; }
                if (txtTaxNumber.Text != "") { c.taxnumber = txtTaxNumber.Text; }
                if (cmbMainContact.SelectedValue != null) { c.MainContactID = Int32.Parse(cmbMainContact.SelectedValue.ToString()); }
                if (cmbAccountRep.SelectedValue != null) { c.accountrepresentaryID = Int32.Parse(cmbAccountRep.SelectedValue.ToString()); }
                if (cmbAccountTerms.SelectedValue != null) { c.payment_termID = Int32.Parse(cmbAccountTerms.SelectedValue.ToString()); }
                if (cmbAccountMethod.SelectedValue != null) { c.paymentmethodID = Int32.Parse(cmbAccountMethod.SelectedValue.ToString()); }
                if (cmbCurrency.SelectedValue != null) { c.DefaultCurrency = Int32.Parse(cmbCurrency.SelectedValue.ToString()); }
                //Notes kısmına kayıt ediliyor
                Note n1 = new Note();
                try { n1 = IME.Notes.Where(a => a.ID == c.Note.ID).FirstOrDefault(); } catch { }
                if (c.Note == null)
                {
                    n1.Note_name = txtSupplierNotes.Text;
                    c.Note = n1;
                    IME.Notes.Add(c.Note);
                    IME.SaveChanges();
                }
                else
                {
                    n1.Note_name = txtSupplierNotes.Text;
                    IME.SaveChanges();
                }
                if (c.AccountNoteID == null)
                {
                    Note n = new Note();
                    n.Note_name = txtAccountNotes.Text;
                    IME.Notes.Add(n);
                    IME.SaveChanges();
                    c.AccountNoteID = n.ID;
                }
                else
                {
                    Note n = IME.Notes.Where(a => a.ID == c.AccountNoteID).FirstOrDefault();
                    n.Note_name = txtAccountNotes.Text;
                    IME.SaveChanges();
                }
                IME.SaveChanges();
                MessageBox.Show("Supplier save succesfully");
                Utils.LogKayit("Supplier", "Supplier update");
                this.Close();

            }
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

        private void CityAdd_Click(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedValue != null && cmbCountry.Text != ComboboxString)
            {
                int country = Convert.ToInt32(cmbCountry.SelectedValue);
                frmCityAdd form = new frmCityAdd(country);
                form.ShowDialog();
                cmbCity.DataSource = IME.Cities.Where(a => a.CountryID == (int)cmbCountry.SelectedValue).ToList();
                cmbCity.DisplayMember = "City_name";
                cmbCity.ValueMember = "ID";
            }
            else { MessageBox.Show("Please select a Country"); }
        }

        private void TownAdd_Click(object sender, EventArgs e)
        {
            if (cmbCity.SelectedValue != null && cmbCity.Text != ComboboxString)
            {
                int city = Convert.ToInt32(cmbCity.SelectedValue);
                int country = Convert.ToInt32(cmbCountry.SelectedValue);
                FormTownAdd form = new FormTownAdd(country, city);
                this.SendToBack();
                form.ShowDialog();
                this.BringToFront();
                cmbTown.Refresh();
                cmbTown.DataSource = IME.Towns.Where(a => a.CityID == (int)cmbCity.SelectedValue).ToList();
                cmbTown.DisplayMember = "Town_name";
                cmbTown.ValueMember = "ID";
            }
            else { MessageBox.Show("Please select a City"); }
        }

        private void btnDep_Click(object sender, EventArgs e)
        {
            CustomerDepartmentAdd form = new CustomerDepartmentAdd();
            this.Enabled = false;
            this.SendToBack();
            form.ShowDialog();
            cmbDepartment.DataSource = new IMEEntities().CustomerDepartments.ToList();
            this.Enabled = true;
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedValue != null && cmbDepartment.Text != ComboboxString)
            {
                int department = Convert.ToInt32(cmbDepartment.SelectedValue);
                CustomerPositionAdd form = new CustomerPositionAdd(department);
                this.Enabled = false;
                this.SendToBack();
                form.ShowDialog();
                cmbPosition.DataSource = new IMEEntities().CustomerTitles.ToList();
                this.Enabled = true;
            }
            else { MessageBox.Show("Please select a Department"); }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_departmentID;
            try { c_departmentID = ((CustomerDepartment)((ComboBox)sender).SelectedItem).ID; } catch { c_departmentID = 0; }
            cmbPosition.DataSource = IME.CustomerTitles.ToList();
            cmbPosition.DisplayMember = "titlename";
        }
    }
}
