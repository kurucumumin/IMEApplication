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
            string supplierCode = "";
            if (IME.Suppliers.ToList().Count != 0)
                supplierCode = IME.Suppliers.OrderByDescending(a => a.ID).FirstOrDefault().ID;
            string suppliernumber = string.Empty;
            string newcustomercodenumbers = "";
            string newcustomercodezeros = "";
            string newcustomercodechars = "";
            for (int i = 0; i < supplierCode.Length; i++)
            {
                if (Char.IsDigit(supplierCode[i]))
                {
                    if (supplierCode[i] == '0') { newcustomercodezeros += supplierCode[i]; } else { newcustomercodenumbers += supplierCode[i]; }
                }
                else
                {
                    newcustomercodechars += supplierCode[i];
                }
            }
            //Aynı ID ile customer oluşturmasını önleyen kısım
            while (IME.Suppliers.Where(a => a.ID == supplierCode).Count() > 0)
            {
                newcustomercodenumbers = (Int32.Parse(newcustomercodenumbers) + 1).ToString();
                supplierCode = newcustomercodechars + newcustomercodezeros + newcustomercodenumbers;
            }
            //
            txtSupplierCode.Text = supplierCode;
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


            cmbContactAddress.DataSource = worker.Supplier.SupplierAddresses.ToList();
            cmbContactAddress.DisplayMember = "sw_name";
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
            list.RemoveAt(0);
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
                    //if (SupplierAddMode == String.Empty)
                    //{
                    //    cmbSubCategory.Enabled = false;
                    //    btnSubCategoryAdd.Enabled = false;
                    //}
                    //else
                    //{
                        cmbSubCategory.Enabled = true;
                        btnSubCategoryAdd.Enabled = true;
                    //}
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
    }
}
