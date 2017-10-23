using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LoginForm.DataSet;
using LoginForm.Services;

    namespace LoginForm
    {
        public partial class SupplierMain : Form
        {
        IMEEntities db = new IMEEntities();
        int gridselectedindex = 0;
        string searchtxt = "";
        int selectedContactID;
        int isNewContact = 0;
        int isUpdateAdress;


        public SupplierMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region ComboboxFiller
            cmbAcountMethod.DataSource = db.PaymentMethods.ToList();
            cmbAcountMethod.DisplayMember = "Payment";
            cmbAcountMethod.ValueMember = "ID";

            cmbAcountRep.DataSource = db.Workers.ToList();
            cmbAcountRep.DisplayMember = "UserName";
            cmbAcountRep.ValueMember = "WorkerID";

            cmbAcountTerms.DataSource = db.PaymentTerms.ToList();
            cmbAcountTerms.DisplayMember = "term_name";
            cmbAcountTerms.ValueMember = "ID";

            cmbcategory.DataSource = db.SupplierCategories.ToList();
            cmbcategory.DisplayMember = "categoryname";
            cmbcategory.ValueMember = "ID";

            cmbsub.DataSource = db.SupplierSubCategories.ToList();
            cmbsub.DisplayMember = "subcategoryname";
            cmbsub.ValueMember = "ID";

            cmbCurrenyt.DataSource = db.Rates.ToList();
            cmbCurrenyt.DisplayMember = "CurType";
            cmbCurrenyt.ValueMember = "ID";

            cmbInvoiceCur.DataSource = db.Rates.ToList();
            cmbInvoiceCur.DisplayMember = "CurType";
            cmbInvoiceCur.ValueMember = "ID";

            cmbrepresentative.DataSource = db.Workers.ToList();
            cmbrepresentative.DisplayMember = "UserName";
            cmbrepresentative.ValueMember = "WorkerID";

            cmbdepartman.DataSource = db.SupplierDepartments.ToList();
            cmbdepartman.DisplayMember = "departmentname";
            cmbdepartman.ValueMember = "ID";

            cmblanguage.DataSource = db.Languages.ToList();
            cmblanguage.DisplayMember = "languagename";
            cmblanguage.ValueMember = "ID";

            cmbposition.DataSource = db.SupplierTitles.ToList();
            cmbposition.DisplayMember = "titlename";
            cmbposition.ValueMember = "ID";

            cmbBankName.DataSource = db.SupplierBanks.ToList();
            cmbBankName.DisplayMember = "bankname";
            cmbBankName.ValueMember = "ID";

            cmbcounrty.DataSource = db.Countries.ToList();
            cmbcounrty.DisplayMember = "Country_name";
            cmbcounrty.ValueMember = "ID";
            #endregion
            itemsEnableFalse();
            contactTabEnableFalse();
            suppliersearch();
        }

        private void dgSupplier_Click(object sender, EventArgs e)
        {
            gridselectedindex = dgSupplier.CurrentCell.RowIndex;
            suppliersearch();
        }

        private void listContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ContactList

            //contact daki list box a tıklandığında contact ın bilgileri tıklanan göre doldurulmasıse

            int cw_ID = 0;
            try  { cw_ID = ((SupplierWorker)((ListBox)sender).SelectedItem).ID;}
            catch {cw_ID = 0;}
            try
            {
                if (ContactListItem.ID != cw_ID)
                {
                    ContactListItem.ID = cw_ID;
                    string contactname = ((SupplierWorker)((ListBox)sender).SelectedItem).sw_name;
                    ContactListItem.contactName = contactname;
                    var contact1 = db.SupplierWorkers.Where(cw => cw.ID == cw_ID).ToList();
                    foreach (var a in contact1)
                    {
                        selectedContactID = a.ID;
                        cmbdepartman.SelectedIndex = cmbdepartman.FindStringExact(a.SupplierDepartment.departmentname);
                        cmbposition.SelectedIndex = cmbposition.FindStringExact(a.SupplierTitle.titlename);
                        cmblanguage.SelectedIndex = cmblanguage.FindStringExact(a.Language.languagename);
                        txtContactName.Text = a.sw_name;
                        txtContactMail.Text = a.sw_email;
                        txtContactfax.Text = a.fax;
                        txtContactMobile.Text = a.mobilephone;
                        txtContactPhone.Text = a.phone;
                        if (a.Note != null) { txtContactNotes.Text = a.Note.Note_name; } else { txtContactNotes.Text = ""; }
                    }
                }
            }
            catch { }
            #endregion
        }

        private void btnDep_Click(object sender, EventArgs e)
        {
            SupplierDepartmentAdd form = new SupplierDepartmentAdd();
            this.Enabled = false;
            this.SendToBack();
            form.ShowDialog();
            cmbdepartman.DataSource = db.SupplierDepartments;
            this.Enabled = true;
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            SupplierPositionAdd form = new SupplierPositionAdd();
            this.Enabled = false;
            this.SendToBack();
            form.ShowDialog();
            cmbposition.DataSource = db.SupplierTitles;
            this.Enabled = true;
        }

        private void cmbcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_categoryID;
            try { c_categoryID = ((SupplierCategory)((ComboBox)sender).SelectedItem).ID; } catch { c_categoryID = 0; }
            cmbsub.DataSource = db.SupplierSubCategories.Where(b => b.categoryID == c_categoryID).ToList();
            cmbsub.DisplayMember = "subcategoryname";
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            gridselectedindex = 0;
            searchtxt = txtsearch.Text;
            suppliersearch();
        }

        private void itemsClear()
        {
            #region itemClaer
            txtcode.Text = "";
            cmbrepresentative.Text = "";
            txtname.Text = "";
            cmbcategory.SelectedIndex = 0;
            txtTaxOffice.Text = "";
            txtTaxNumber.Text = "";
            txtnotes.Text = "";

            cmbAcountRep.Text = "";
            cmbAcountTerms.Text = "";
            cmbAcountMethod.Text = "";
            txtdiscount.Text = "";
            cmbCurrenyt.Text = "";
            cmbInvoiceCur.Text = "";

            cmbdepartman.Text = "";
            cmbposition.Text = "";
            txtContactName.Text = "";
            txtContactMail.Text = "";
            txtAccountNotes.Text = "";
            cmbMainContact.Text = "";
            txtpobox.Text = "";

            txtphone.Text = "";
            txtfax.Text = "";
            txtpost.Text = "";
            txtweb.Text = "";
            cmbcounrty.Text = "";
            cmbcity.Text = "";
            cmbtown.Text = "";
            txtCompanyAddress.Text = "";

            txtContactPhone.Text = "";
            txtContactMobile.Text = "";
            txtContactfax.Text = "";
            cmblanguage.Text = "";
            txtContactAddress.Text = "";
            txtContactNotes.Text = "";

            cmbBankName.Text = "";
            txtBankCode.Text = "";
            txtBankNumber.Text = "";
            txtBankIban.Text = "";
            #endregion

        }

        private void contactTabEnableFalse()
        {
            #region contactTabEnableFalse
            txtContactMail.Enabled = false;
            cmblanguage.Enabled = false;
            cmbdepartman.Enabled = false;
            btnDep.Enabled = false;
            btnPos.Enabled = false;
            cmbposition.Enabled = false;
            cmbposition.Enabled = false;
            cmbsub.Enabled = false;
            txtContactName.Enabled = false;
            txtContactMail.Enabled = false;
            txtContactPhone.Enabled = false;
            txtContactAddress.Enabled = false;
            txtContactMobile.Enabled = false;
            txtContactfax.Enabled = false;
            txtContactNotes.Enabled = false;
            listContact.Enabled = true;
            cmbMainContact.Enabled = false;

            btnContactNew.Enabled = true;
            if (listContact.DataSource != null)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }


            btnnew.Enabled = true;
            btnupdate.Enabled = true;

            btnContactNew.Enabled = true;
            if (listContact.DataSource != null)
            {
                btnContactUpdate.Enabled = true;
                btnContactDelete.Enabled = true;
            }

            #endregion
        }

        private void contactTabEnableTrue()
        {
            #region contactTabEnableTrue
            txtContactMail.Enabled = true;
            cmblanguage.Enabled = true;
            cmbdepartman.Enabled = true;
            btnDep.Enabled = true;
            btnPos.Enabled = true;
            cmbposition.Enabled = true;
            cmbposition.Enabled = true;
            cmbsub.Enabled = true;
            txtContactName.Enabled = true;
            cmbMainContact.Enabled = true;
            txtContactMail.Enabled = true;
            txtContactAddress.Enabled = true;
            txtContactPhone.Enabled = true;
            txtContactMobile.Enabled = true;
            txtContactfax.Enabled = true;
            txtContactNotes.Enabled = true;
            btnContactCancel.Enabled = true;
            listContact.Enabled = false;
            dgSupplier.Enabled = false;
            btnContactNew.Enabled = false;
            btnContactDelete.Enabled = false;
            btnContactUpdate.Enabled = false;
            btnContactDone.Enabled = true;
            btnnew.Enabled = false;
            btnupdate.Enabled = false;
            txtsearch.Enabled = false;
            #endregion
        }

        private void itemsEnableFalse()
        {
            #region itemsEnableFalse
            txtcode.Enabled = false;
            cmbrepresentative.Enabled = false;
            txtname.Enabled = false;
            cmbcategory.Enabled = false;
            txtTaxOffice.Enabled = false;
            txtTaxNumber.Enabled = false;
            cmbsub.Enabled = false;
            txtnotes.Enabled = false;

            cmbAcountRep.Enabled = false;
            cmbAcountTerms.Enabled = false;
            cmbAcountMethod.Enabled = false;
            txtdiscount.Enabled = false;
            cmbCurrenyt.Enabled = false;
            cmbInvoiceCur.Enabled = false;

            cmbdepartman.Enabled = false;
            cmbposition.Enabled = false;
            txtContactName.Enabled = false;
            txtContactMail.Enabled = false;
            txtAccountNotes.Enabled = false;
            txtpobox.Enabled = false;
            cmbMainContact.Enabled = false;

            txtphone.Enabled = false;
            txtfax.Enabled = false;
            txtpost.Enabled = false;
            txtweb.Enabled = false;
            cmbcounrty.Enabled = false;
            cmbcity.Enabled = false;
            cmbtown.Enabled = false;
            txtCompanyAddress.Enabled = false;

            txtContactPhone.Enabled = false;
            txtContactMobile.Enabled = false;
            txtContactfax.Enabled = false;
            cmblanguage.Enabled = false;
            txtContactAddress.Enabled = false;
            txtContactNotes.Enabled = false;

            cmbBankName.Enabled = false;
            txtBankCode.Enabled = false;
            txtBankNumber.Enabled = false;
            txtBankIban.Enabled = false;

            btnContactNew.Enabled = true;
            if (listContact.DataSource != null)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }
            btnContactDone.Enabled = false;
            btnDep.Enabled = false;
            btnPos.Enabled = false;
            btnContactCancel.Enabled = false;
            btnupdate.Enabled = true;
            btnnew.Enabled = true;
            txtsearch.Enabled = true;
            dgSupplier.Enabled = true;
            #endregion
        }

        private void itemsEnableTrue()
        {
            #region itemsEnableTrue
            txtcode.Enabled = false;
            cmbrepresentative.Enabled = true;
            txtname.Enabled = true;
            cmbcategory.Enabled = true;
            txtTaxOffice.Enabled = true;
            txtTaxNumber.Enabled = true;
            cmbsub.Enabled = true;
            txtnotes.Enabled = true;

            cmbAcountRep.Enabled = true;
            cmbAcountTerms.Enabled = true;
            cmbAcountMethod.Enabled = true;
            txtdiscount.Enabled = true;
            cmbCurrenyt.Enabled = true;
            cmbInvoiceCur.Enabled = true;

            cmbdepartman.Enabled = true;
            cmbposition.Enabled = true;
            txtContactName.Enabled = true;
            txtContactMail.Enabled = true;
            txtpobox.Enabled = true;
            txtAccountNotes.Enabled = true;
            cmbMainContact.Enabled = true;

            txtphone.Enabled = true;
            txtfax.Enabled = true;
            txtpost.Enabled = true;
            txtweb.Enabled = true;
            cmbcounrty.Enabled = true;
            cmbcity.Enabled = true;
            cmbtown.Enabled = true;
            txtCompanyAddress.Enabled = true;

            txtContactPhone.Enabled = true;
            txtContactMobile.Enabled = true;
            txtContactfax.Enabled = true;
            cmblanguage.Enabled = true;
            txtContactAddress.Enabled = true;
            txtContactNotes.Enabled = true;

            cmbBankName.Enabled = true;
            txtBankCode.Enabled = true;
            txtBankNumber.Enabled = true;
            txtBankIban.Enabled = true;

            btnnew.Enabled = true;
            btnDep.Enabled = true;
            btnPos.Enabled = true;
            btnupdate.Enabled = true;
            btnContactDone.Enabled = true;
            btnContactCancel.Enabled = true;
            dgSupplier.Enabled = false;
            #endregion
        }

        private void AdressTabEnableFalse()
        {
            #region AdressTabEnableFalse
            cmbcounrty.Enabled = false;
            cmbcity.Enabled = false;
            cmbtown.Enabled = false;
            txtpobox.Enabled = false;
            txtpost.Enabled = false;
            txtCompanyAddress.Enabled = false;
            txtphone.Enabled = false;
            txtfax.Enabled = false;
            txtweb.Enabled = false;
            AdressList.Enabled = true;

            if (listContact.DataSource != null)
            {
                AddressDel.Enabled = true;
                AddressUpd.Enabled = true;
            }
            AdressAdd.Enabled = true;
            btnnew.Enabled = true;
            btnupdate.Enabled = true;
            #endregion
        }

        private void AdressTabEnableTrue()
        {
            #region contactTabEnableTrue
            cmbcounrty.Enabled = true;
            cmbcity.Enabled = true;
            cmbtown.Enabled = true;
            txtpobox.Enabled = true;
            txtpost.Enabled = true;
            txtCompanyAddress.Enabled = true;
            txtphone.Enabled = true;
            txtfax.Enabled = true;
            txtweb.Enabled = true;
            AdressList.Enabled = false;

            dgSupplier.Enabled = false;
            AdressAdd.Enabled = false;
            AddressDel.Enabled = false;
            AddressUpd.Enabled = false;
            btnnew.Enabled = false;
            btnupdate.Enabled = false;
            txtsearch.Enabled = false;
            #endregion
        }

        private void suppliersearch()
        {
            #region suppliersearch
            var supplierAdapter = (from c in db.Suppliers.Where(a => a.s_name.Contains(searchtxt))
                                   join w in db.Workers on c.representaryID equals w.WorkerID
                                   join SupplierWorker in db.SupplierWorkers on c.ID equals SupplierWorker.supplierID into supplierworker
                                   let SupplierWorker = supplierworker.Select(supplierworker1 => supplierworker1).FirstOrDefault()
                                   join supplieraccountant in db.Workers on c.accountrepresentaryID equals supplieraccountant.WorkerID
                                   join s in db.SupplierCategorySubCategories on c.ID equals s.supplierID
                                   join p in db.PaymentTerms on c.payment_termID equals p.ID
                                   join m in db.PaymentMethods on c.paymentmethodID equals m.ID
                                   join n in db.SupplierBanks on c.BankID equals n.ID
                                   join a in db.SupplierAdresses on c.ID equals a.SupplierID into adress
                                   let a = adress.Select(supplierworker1 => supplierworker1).FirstOrDefault()
                                   join sc in db.SupplierWorkers on c.MainContactID equals sc.ID into maincontact
                                   let sc = maincontact.Select(supplierworker1 => supplierworker1).FirstOrDefault()
                                   join l in db.Languages on SupplierWorker.languageID equals l.ID into supplierlanguage
                                   let l = supplierlanguage.Select(supplierlanguage1 => supplierlanguage1).FirstOrDefault()
                                   select new
                                   {
                                       c.ID,
                                       c.s_name,
                                       c.Rate.currency,
                                       c.telephone,
                                       c.fax,
                                       c.webadress,
                                       c.discountrate,
                                       w.NameLastName,
                                       SupplierWorker.sw_name,
                                       SupplierWorker.sw_email,
                                       SupplierWorker.SupplierTitle.titlename,
                                       SupplierWorker.SupplierDepartment.departmentname,
                                       s.SupplierCategory.categoryname,
                                       s.SupplierSubCategory.subcategoryname,
                                       p.term_name,
                                       supplierworker,
                                       swNote = SupplierWorker.Note.Note_name,
                                       SupplierNote = c.Note.Note_name,
                                       AccountRepresentative = supplieraccountant.NameLastName,
                                       l.languagename,
                                       n.bankname,
                                       c.iban,
                                       c.PoBox,
                                       c.branchcode,
                                       c.accountnumber,
                                       AddressCity = a.City.City_name,
                                       AdressCountry = a.Country.Country_name,
                                       a.Town.Town_name,
                                       a.AdressDetails,
                                       c.MainContactID,
                                       Maincontact = sc.sw_name
                                   }).ToList();
            #endregion
            dgSupplier.DataSource = supplierAdapter;
            if (supplierAdapter.Count > 0)
            {
                #region FillInfos

                dgSupplier.DataSource = supplierAdapter;
                dgSupplier.CurrentCell = dgSupplier.Rows[gridselectedindex].Cells[0];

                AdressList.DataSource = db.SupplierAdresses.Where(supplierw => supplierw.SupplierID == txtcode.Text).ToList();
                AdressList.DisplayMember = "AdressDetails";
                db.SaveChanges();

                txtcode.Text = supplierAdapter[gridselectedindex].ID;
                cmbMainContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                cmbMainContact.DisplayMember = "sw_name";
                cmbMainContact.SelectedItem = cmbMainContact.FindStringExact(supplierAdapter[gridselectedindex].sw_name);
                txtname.Text = supplierAdapter[gridselectedindex].s_name;
                txtdiscount.Text = supplierAdapter[gridselectedindex].discountrate.ToString();
                try { txtphone.Text = supplierAdapter[gridselectedindex].telephone.ToString(); } catch { }
                try { txtfax.Text = supplierAdapter[gridselectedindex].fax.ToString(); } catch { }
                txtweb.Text = supplierAdapter[gridselectedindex].webadress;
                txtContactNotes.Text = supplierAdapter[gridselectedindex].swNote;
                cmbrepresentative.SelectedIndex = cmbrepresentative.FindStringExact(supplierAdapter[gridselectedindex].NameLastName);
                cmbposition.SelectedIndex = cmbposition.FindStringExact(supplierAdapter[gridselectedindex].titlename);
                cmbdepartman.SelectedIndex = cmbdepartman.FindStringExact(supplierAdapter[gridselectedindex].departmentname);
                cmbcategory.SelectedIndex = cmbcategory.FindStringExact(supplierAdapter[gridselectedindex].categoryname);
                cmbsub.SelectedIndex = cmbsub.FindStringExact(supplierAdapter[gridselectedindex].subcategoryname);

                cmbBankName.SelectedIndex = cmbBankName.FindStringExact(supplierAdapter[gridselectedindex].bankname);
                txtBankCode.Text = supplierAdapter[gridselectedindex].branchcode;
                txtBankNumber.Text = supplierAdapter[gridselectedindex].accountnumber;
                txtBankIban.Text = supplierAdapter[gridselectedindex].iban;

                cmbAcountTerms.SelectedIndex = cmbAcountTerms.FindStringExact(supplierAdapter[gridselectedindex].term_name);
                txtContactName.Text = supplierAdapter[gridselectedindex].sw_name;
                txtContactMail.Text = supplierAdapter[gridselectedindex].sw_email;
                txtnotes.Text = supplierAdapter[gridselectedindex].SupplierNote;
                cmbAcountRep.Text = supplierAdapter[gridselectedindex].AccountRepresentative;
                cmblanguage.Text = supplierAdapter[gridselectedindex].languagename;
                txtpobox.Text = supplierAdapter[gridselectedindex].PoBox;

                listContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                listContact.DisplayMember = "sw_name";

                cmbcounrty.SelectedIndex = cmbcounrty.FindStringExact(supplierAdapter[gridselectedindex].AdressCountry);
                cmbcity.SelectedIndex = cmbcity.FindStringExact(supplierAdapter[gridselectedindex].AddressCity);
                cmbtown.SelectedIndex = cmbtown.FindStringExact(supplierAdapter[gridselectedindex].Town_name);
                txtCompanyAddress.Text = supplierAdapter[gridselectedindex].AdressDetails;

                #endregion
            }
            else
            {
                itemsClear();
            }
        }

        //CONTACT ADD NEW
        private void btnContactNew_Click(object sender, EventArgs e)
        {
            isNewContact = 0;
            #region ContactNewButton
            contactTabEnableTrue();
            cmbdepartman.Text = "";
            cmbposition.Text = "";
            txtContactName.Text = "";
            txtContactMail.Text = "";
            txtContactPhone.Text = "";
            txtContactMobile.Text = "";
            cmbMainContact.Text = "";
            txtContactfax.Text = "";
            cmblanguage.Text = "";
            txtContactAddress.Text = "";
            txtpobox.Text = "";
            txtContactNotes.Text = "";

            btnContactNew.Visible = false;
            btnContactUpdate.Visible = false;
            btnContactDelete.Visible = false;
            listContact.Enabled = false;
            cmbMainContact.Enabled = true;
            btnDep.Enabled = true;
            btnPos.Enabled = true;
            btnContactCancel.Visible = true;
            btnContactDone.Visible = true;
            btnnew.Enabled = true;
            btnupdate.Enabled = true;
            #endregion
        }

        private void btnContactCancel_Click(object sender, EventArgs e)
        {
            #region btnContactCancel
            contactTabEnableFalse();
            if (btnnew.Text == "Add")
            {
                txtsearch.Enabled = true;
                dgSupplier.Enabled = true;
            }
            btnContactNew.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDelete.Visible = true;
            btnContactDone.Visible = false;
            btnContactUpdate.Visible = true;
            #endregion
        }

        //CONTACT UPDATE
        private void btnContactUpdate_Click(object sender, EventArgs e)
        {
            isNewContact = 1;
            #region  btnContactUpdate
            contactTabEnableTrue();
            btnContactNew.Visible = false;
            btnContactCancel.Visible = true;
            btnContactDelete.Visible = false;
            btnContactDone.Visible = true;
            btnContactUpdate.Visible = false;
            btnDep.Enabled = true;
            btnPos.Enabled = true;
            #endregion
        }

        private void btnContactDone_Click(object sender, EventArgs e)
        {
            if (isNewContact == 0)
            {
                foreach (Control ctl in this.Controls)
                    if (ctl is TextBox)
                    {
                        if (txtContactMobile.Text == String.Empty || txtContactName.Text == string.Empty || cmblanguage.Text == string.Empty || txtContactNotes.Text == string.Empty)
                        {
                            MessageBox.Show(" Empty can not pass ! ", "Could not Save");
                        }
                        else
                        {
                            SupplierWorker cw = new SupplierWorker();
                            cw.supplierID = txtcode.Text;
                            cw.departmentID = ((SupplierDepartment)(cmbdepartman).SelectedItem).ID;
                            cw.titleID = ((SupplierTitle)(cmbposition).SelectedItem).ID;
                            cw.sw_name = txtContactName.Text;
                            cw.sw_email = txtContactMail.Text;
                            cw.phone = txtContactPhone.Text;
                            cw.mobilephone = txtContactMobile.Text;
                            cw.fax = txtContactfax.Text;
                            cw.languageID = ((Language)(cmblanguage).SelectedItem).ID;
                            db.SupplierWorkers.Add(cw);
                            db.SaveChanges();
                            Note n = new Note();
                            n.Note_name = txtContactNotes.Text;
                            db.Notes.Add(n);
                            db.SaveChanges();
                            cw.supplierNoteID = n.ID;
                            contactTabEnableFalse();
                            if (btnnew.Text == "Add")
                            {
                                txtsearch.Enabled = true;
                                dgSupplier.Enabled = true;
                            }
                            listContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                            listContact.DisplayMember = "sw_name";
                            //catch { MessageBox.Show("Contact is NOT successfull"); }
                        }
                    }
            }
            else
            {

                SupplierWorker cw = db.SupplierWorkers.Where(a => a.ID == ((SupplierWorker)(listContact).SelectedItem).ID).FirstOrDefault();
                foreach (Control ctl in this.Controls)
                    if (ctl is TextBox)
                    {
                        if (txtContactMobile.Text == String.Empty || txtContactName.Text == string.Empty || cmblanguage.Text == string.Empty || txtContactNotes.Text == string.Empty)
                        {
                            MessageBox.Show(" Empty can not pass ! ", "Could not Save");
                        }
                        else
                        {
                            if (cw.sw_name != "")
                            {
                                //UPDATE CONTACT
                                cw.supplierID = txtcode.Text;
                                cw.departmentID = ((SupplierDepartment)(cmbdepartman).SelectedItem).ID;
                                cw.titleID = ((SupplierTitle)(cmbposition).SelectedItem).ID;
                                cw.sw_name = txtContactName.Text;
                                cw.sw_email = txtContactMail.Text;
                                cw.phone = txtContactPhone.Text;
                                cw.mobilephone = txtContactMobile.Text;
                                cw.fax = txtContactfax.Text;
                                cw.languageID = ((Language)(cmblanguage).SelectedItem).ID;
                                var contactNote = db.Notes.Where(a => a.ID == cw.supplierNoteID).FirstOrDefault();
                                if (contactNote == null)
                                {
                                    if (txtContactNotes.Text != "")
                                    {
                                        Note n = new Note();
                                        n.Note_name = txtContactNotes.Text;
                                        db.Notes.Add(n);
                                        db.SaveChanges();
                                        cw.supplierNoteID = n.ID;
                                    }
                                }
                                else
                                {
                                    contactNote.Note_name = txtContactNotes.Text;
                                    db.SaveChanges();
                                    cw.supplierNoteID = contactNote.ID;
                                }
                                db.SaveChanges();
                                contactTabEnableFalse();
                                if (btnnew.Text == "ADD")
                                {
                                    txtsearch.Enabled = true;
                                    dgSupplier.Enabled = true;
                                }
                                listContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                                listContact.DisplayMember = "sw_name";
                                cmbMainContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                                cmbMainContact.DisplayMember = "cw_name";
                            }
                            else { MessageBox.Show("Please choose a contact to update"); }

                        }
                    }
            }
            btnContactNew.Visible = true;
            btnContactDelete.Visible = true;
            btnContactUpdate.Visible = true;
            btnDep.Visible = true;
            btnPos.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDone.Visible = false;
        }

        private void btnContactDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Delete Contact " + ContactListItem.contactName + " ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SupplierWorker sw = db.SupplierWorkers.First(a => a.ID == ContactListItem.ID);
                db.SupplierWorkers.Remove(sw);
                db.SaveChanges();
                listContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                listContact.DisplayMember = "sw_name";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void cmbdepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s_departmentID;
            try { s_departmentID = ((SupplierDepartment)((ComboBox)sender).SelectedItem).ID; } catch { s_departmentID = 0; }
            cmbposition.DataSource = db.SupplierTitles.Where(b => b.SupplierDepartment.ID == s_departmentID).ToList();
            cmbposition.DisplayMember = "titlename";
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            if (btnnew.Text == "Add")
            {
                itemsEnableTrue();
                itemsClear();
                //for new customerCode
                var suppliercode = db.Suppliers.OrderByDescending(a => a.ID).FirstOrDefault().ID;
                string suppliernumbers = string.Empty;
                string newsuppliercodenumbers = "";
                string newsuppliercodezeros = "";
                string newsuppliercodechars = "";

                for (int i = 0; i < suppliercode.Length; i++)
                {
                    if (Char.IsDigit(suppliercode[i]))
                    {
                        if (suppliercode[i] == '0') { newsuppliercodezeros += suppliercode[i]; } else { newsuppliercodenumbers += suppliercode[i]; }
                    }
                    else
                    {
                        newsuppliercodechars += suppliercode[i];
                    }

                }
                //Aynı ID ile supplier oluşturmasını önleyen kısım
                while (db.Suppliers.Where(a => a.ID == suppliercode).Count() > 0)
                {
                    newsuppliercodenumbers = (Int32.Parse(newsuppliercodenumbers) + 1).ToString();
                    suppliercode = newsuppliercodechars + newsuppliercodezeros + newsuppliercodenumbers;
                }
                //
                listContact.DataSource = null;
                txtcode.Text = suppliercode;
                Supplier s = new Supplier();
                s.ID = txtcode.Text;
                db.Suppliers.Add(s);
                db.SaveChanges();
                btnnew.Text = "Save";
                btnupdate.Text = "Cancel";
                AdressList.Enabled = false;
                AdressList.DataSource = null;
                AdressAdd.Enabled = true;
                btnContactNew.Enabled = true;
            }
            else
            {
                btnnew.Text = "Add";
                btnupdate.Text = "Modify";

                Supplier s = new Supplier();
                s = db.Suppliers.Where(a => a.ID == txtcode.Text).FirstOrDefault();
                s.s_name = txtname.Text;
                try { if (txtdiscount.Text != "") { s.discountrate = Int32.Parse(txtdiscount.Text); } } catch { };
                if (txtphone.Text != "") { s.telephone = txtphone.Text; }
                int s_paymentmeth = ((PaymentMethod)(cmbAcountMethod).SelectedItem).ID; s.paymentmethodID = s_paymentmeth;
                if (txtfax.Text != "") { s.fax = txtfax.Text; }
                s.webadress = txtweb.Text;
                int s_termpayment = ((PaymentTerm)(cmbAcountTerms).SelectedItem).ID; s.payment_termID = s_termpayment;
                int s_rep1ID = ((Worker)(cmbrepresentative).SelectedItem).WorkerID; s.representaryID = s_rep1ID;
                int s_repAcoID = ((Worker)(cmbAcountRep).SelectedItem).WorkerID; s.accountrepresentaryID = s_repAcoID;
                s.taxoffice = txtTaxOffice.Text;
                s.PoBox = txtpobox.Text;
                if (txtTaxNumber.Text != "") { s.taxnumber = Int32.Parse(txtTaxNumber.Text); }
                try
                {
                    if (s.BankID != null)
                    {
                        SupplierBank bank1 = new SupplierBank();
                        bank1 = db.SupplierBanks.Where(a => a.ID == s.BankID).FirstOrDefault();
                        s.iban = txtBankIban.Text;
                        s.branchcode = txtBankCode.Text;
                        s.accountnumber = txtBankNumber.Text;
                    }
                    else
                    {
                        s.iban = txtBankIban.Text;
                        db.SupplierBanks.Add(s.SupplierBank);
                        s.BankID = s.SupplierBank.ID;
                        s.branchcode = txtBankCode.Text;
                        s.accountnumber = txtBankNumber.Text;
                    }
                    db.SaveChanges();

                }
                catch { }
                int s_bank = ((SupplierBank)(cmbBankName).SelectedItem).ID; s.BankID = s_bank;
                //CategorySubCategory Tablosuna veri ekleniyor(ara tabloya)
                SupplierCategorySubCategory SupplierCatSubCat = new SupplierCategorySubCategory();
                //UPDATE YAPILIRKEN BU ŞEKİLDE OLUYOR
                if (db.SupplierCategorySubCategories.Where(a => a.supplierID == txtcode.Text).FirstOrDefault() != null) { SupplierCatSubCat = db.SupplierCategorySubCategories.Where(a => a.supplierID == txtcode.Text).FirstOrDefault(); }
                SupplierCatSubCat.supplierID = txtcode.Text;
                int c_CategoryID = ((SupplierCategory)(cmbcategory).SelectedItem).ID;
                SupplierCatSubCat.categoryID = c_CategoryID;
                int c_SubcategoryID = ((SupplierSubCategory)(cmbsub).SelectedItem).ID;
                SupplierCatSubCat.subcategoryID = c_SubcategoryID;
                if (db.SupplierCategorySubCategories.Where(a => a.supplierID == txtcode.Text).FirstOrDefault() == null) { db.SupplierCategorySubCategories.Add(SupplierCatSubCat); }
                db.SaveChanges();
                //        
                //Notes kısmına kayıt ediliyor
                try
                {
                    if (s.SupplierNoteID != null)
                    {
                        Note note1 = new Note();
                        note1 = db.Notes.Where(a => a.ID == s.SupplierNoteID).FirstOrDefault();
                        note1.Note_name = txtnotes.Text;
                    }
                    else
                    {
                        s.Note.Note_name = txtnotes.Text;
                        db.Notes.Add(s.Note);
                        s.SupplierNoteID = s.Note.ID;
                    }
                    db.SaveChanges();

                }
                catch { }

                db.SaveChanges();
                itemsEnableFalse();
                contactTabEnableFalse();
                suppliersearch();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            if (btnupdate.Text == "Modify")
            {
                contactTabEnableTrue();
                itemsEnableTrue();
                btnContactNew.Enabled = true;
                if (listContact.DataSource != null)
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
                btnupdate.Text = "CANCEL";
                btnnew.Text = "Save";
            }
            else
            {
                btnupdate.Text = "Modify";
                btnnew.Text = "Add";
                itemsEnableFalse();
                contactTabEnableFalse();
                btnContactNew.Enabled = false;
                btnContactDelete.Enabled = false;
                btnContactUpdate.Enabled = false;
                var supplier = db.Suppliers.Where(a => a.ID == txtcode.Text).FirstOrDefault();
                if (supplier.s_name == null)
                {
                    //CREATE in cancel ı
                    var sw = db.SupplierWorkers.Where(a => a.supplierID == txtcode.Text);
                    //ilk önce Contact ların ve adress lerin verilerini sil sonra supplier ın verisini sil
                    while (sw.Count() > 0)
                    {
                        db.SupplierWorkers.Remove(sw.FirstOrDefault());
                        db.SaveChanges();
                    }
                    //üstteki işlem adresses için de yapılmalı
                    //

                    Supplier s = new Supplier();
                    s = db.Suppliers.Where(a => a.ID == txtcode.Text).FirstOrDefault();
                    db.Suppliers.Remove(s);
                    db.SaveChanges();
                }
                dgSupplier.Enabled = true;
                gridselectedindex = dgSupplier.CurrentCell.RowIndex;
                suppliersearch();

            }
        }

        private void listContact_DataSourceChanged(object sender, EventArgs e)
        {
            if (listContact.DataSource == null) { btnContactDelete.Enabled = false; btnContactUpdate.Enabled = false; }

        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridselectedindex = 0;
                searchtxt = txtsearch.Text;
                suppliersearch();
            }
        }

        private void AdressAdd_Click(object sender, EventArgs e)
        {
            isUpdateAdress = 0;
            #region addAdressButton
            AdressTabEnableTrue();
            cmbcounrty.Text = "";
            cmbcity.Text = "";
            cmbtown.Text = "";
            txtpost.Text = "";
            txtweb.Text = "";
            txtphone.Text = "";
            txtfax.Text = "";
            txtCompanyAddress.Text = "";
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
                SupplierAdress ca = db.SupplierAdresses.First(a => a.ID == ContactListItem.AdressID);
                db.SupplierAdresses.Remove(ca);
                db.SaveChanges();
                AdressList.DataSource = db.SupplierAdresses.Where(suppliera => suppliera.SupplierID == txtcode.Text).ToList();
                AdressList.DisplayMember = "AdressDetails";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void AdressDone_Click(object sender, EventArgs e)
        {
            SupplierAdress ca = new SupplierAdress();
            if (isUpdateAdress == 1)
            {
                ca = db.SupplierAdresses.Where(a => a.ID == ((SupplierAdress)(AdressList).SelectedItem).ID).FirstOrDefault();
            }

            if (ca != null)
            {
                ca.CountryID = ((Country)(cmbcounrty).SelectedItem).ID;
                ca.CityID = ((City)(cmbcity).SelectedItem).ID;
                ca.TownID = ((Town)(cmbtown).SelectedItem).ID;
                ca.AdressDetails = txtCompanyAddress.Text;
                db.SaveChanges();
            }
            else
            {
                ca = new SupplierAdress();
                ca.CountryID = ((Country)(cmbcounrty).SelectedItem).ID;
                ca.CityID = ((City)(cmbcity).SelectedItem).ID;
                ca.TownID = ((Town)(cmbtown).SelectedItem).ID;
                ca.AdressDetails = txtCompanyAddress.Text;
                db.SupplierAdresses.Add(ca);
                db.SaveChanges();
            }
            AdressTabEnableFalse();
            if (btnnew.Text == "CREATE")
            {
                txtsearch.Enabled = true;
                dgSupplier.Enabled = true;
            }
            AdressList.DataSource = db.SupplierAdresses.Where(suppliera => suppliera.SupplierID == txtcode.Text).ToList();
            AdressList.DisplayMember = "sw_name";

            AdressAdd.Visible = true;
            AddressDel.Visible = true;
            AddressUpd.Visible = true;
            AdressCancel.Visible = false;
            AdressDone.Visible = false;
        }

        private void AdressCancel_Click(object sender, EventArgs e)
        {
            AdressTabEnableFalse();
            if (btnnew.Text == "CREATE")
            {
                txtsearch.Enabled = true;
                dgSupplier.Enabled = true;
            }
            AdressList.DataSource = db.SupplierAdresses.Where(suppliera => suppliera.SupplierID == txtcode.Text).ToList();
            AdressList.DisplayMember = "AdressDetails";

            AdressAdd.Visible = true;
            AddressDel.Visible = true;
            AddressUpd.Visible = true;
            AdressCancel.Visible = false;
            AdressDone.Visible = false;
            suppliersearch();
        }

        private void AdressList_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region AdressList
            //contact daki list box a tıklandığında contact ın bilgileri tıklanan göre doldurulmasıse
            int cw_ID = 0;
            try { cw_ID = ((SupplierAdress)((ListBox)sender).SelectedItem).ID; } catch { cw_ID = 0; }
            try
            {
                if (ContactListItem.AdressID != cw_ID)
                {
                    ContactListItem.AdressID = cw_ID;

                    var contact1 = db.SupplierAdresses.Where(cw => cw.ID == cw_ID).ToList();
                    foreach (var a in contact1)
                    {
                       
                        cmbcounrty.SelectedItem = a.Country;
                        cmbcity.SelectedIndex = cmbcity.FindStringExact(a.City.City_name);
                        cmbtown.SelectedIndex = cmbtown.FindStringExact(a.Town.Town_name);
                        txtCompanyAddress.Text = a.AdressDetails;
                    }
                }
            }
            catch { }
            #endregion
        }

        private void cmbcounrty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbcity.DataSource = db.Cities.Where(a => a.CountryID == ((Country)(cmbcounrty).SelectedItem).ID).ToList();
                cmbcity.DisplayMember = "City_name";
            }
            catch { }
        }

        private void cmbcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbtown.DataSource = db.Towns.Where(a => a.CityID == ((City)(cmbcity).SelectedItem).ID).ToList();
                cmbtown.DisplayMember = "Town_name";
            }
            catch { }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.Show();
                this.Close();
            }
        }

        private void txtContactMail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtContactMail.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("info@imeturkey.com", "Please prowide valid Mail address !");
                txtContactMail.Focus();
                return;
            }
        }

        private void txtContactPhone_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtContactPhone.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please prowide valid Phone Number !");
                txtContactPhone.Focus();
                return;
            }
        }

        private void txtphone_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtphone.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please prowide valid Phone Number !");
                txtphone.Focus();
                return;
            }
        }

        private void txtfax_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtfax.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please prowide valid Fax Number !");
                txtfax.Focus();
                return;
            }
        }

        private void txtContactfax_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtContactfax.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please prowide valid Fax Number !");
                txtContactfax.Focus();
                return;
            }
        }

        private void txtContactMobile_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtContactMobile.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("Example: 0530 283 38 02 ", "Please prowide valid Mobile Phone Number !");
                txtContactMobile.Focus();
                return;
            }
        }

        private void txtweb_Leave(object sender, EventArgs e)
        {
            string pattern = @"^(www\.)([\w]+)\.([\w]+)$";
            if (Regex.IsMatch(txtweb.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("Example: www.rsdelivers.com ", "Please prowide valid Web Address !");
                txtweb.Focus();
                return;
            }
        }

        private void txtBankIban_Leave(object sender, EventArgs e)
        {

            string pattern = "^(TR)([0-9]{2})[ ]([0-9]{4})[ ]([0-9]{4})[ ]([0-9]{4})[ ]([0-9]{4})[ ]([0-9]{4})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtBankIban.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("Example: TR11 0011 1000 0000 0038 1312 04 ", "Please prowide valid IBAN Number !");
                txtBankIban.Focus();
                return;
            }
        }

    }

}