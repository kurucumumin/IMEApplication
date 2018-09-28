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
            string custmrcode = "";
            if (IME.Suppliers.ToList().Count != 0)
                custmrcode = IME.Suppliers.OrderByDescending(a => a.ID).FirstOrDefault().ID;
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
            while (IME.Suppliers.Where(a => a.ID == custmrcode).Count() > 0)
            {
                newcustomercodenumbers = (Int32.Parse(newcustomercodenumbers) + 1).ToString();
                custmrcode = newcustomercodechars + newcustomercodezeros + newcustomercodenumbers;
            }
            //
            txtSupplierCode.Text = custmrcode;
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
            ComboboxFiller();
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

            #region Address
            lbAddressList.DataSource = IME.SupplierAddresses.Where(sa => sa.SupplierID == txtSupplierCode.Text).ToList();
            lbAddressList.DisplayMember = "AdressTitle";
            lbAddressList.ValueMember = "ID";
            #endregion

            #region Contact
            lbContacts.DataSource = IME.SupplierWorkers.Where(sa => sa.supplierID == txtSupplierCode.Text).ToList();
            lbContacts.DisplayMember = "sw_name";
            lbContacts.ValueMember = "ID";
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
            txtAddressTitle.Enabled = mod;
            txtPhone.Enabled = mod;
            txtFax.Enabled = mod;
            txtPoBox.Enabled = mod;
            txtPostCode.Enabled = mod;
            cmbCountry.Enabled = mod;
            cmbCity.Enabled = mod;
            cmbTown.Enabled = mod;
            txtAddressDetail.Enabled = mod;
            lbAddressList.DataSource = null;
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
            lbContacts.DataSource = null;
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



    }
}
