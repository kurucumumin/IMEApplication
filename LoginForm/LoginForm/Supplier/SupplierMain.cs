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

        public SupplierMain()
        {
            InitializeComponent();
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
                cmbMainContact.DataSource = null;
                txtcode.Text = suppliercode;
                Supplier s = new Supplier();
                s.ID = txtcode.Text;
                db.Suppliers.Add(s);
                db.SaveChanges();

                btnnew.Text = "Save";
                btnupdate.Text = "Cancel";
                btnContactNew.Enabled = true;
            }
            else
            {
                btnnew.Text = "Add";
                btnupdate.Text = "Modify";
                Supplier s = new Supplier();
                s = db.Suppliers.Where(a => a.ID == txtcode.Text).FirstOrDefault();
                s.s_name = txtname.Text;
                if (txtdiscount.Text != "") { s.discountrate = Int32.Parse(txtdiscount.Text); }
                if (txtphone.Text != "") { s.telephone = txtphone.Text; }
                if (txtfax.Text != "") { s.fax = txtfax.Text; }
                if (txtTaxNumber.Text != "") { s.taxnumber = Int32.Parse(txtTaxNumber.Text); }
                s.webadress = txtweb.Text;
                s.taxoffice = txtTaxOffice.Text;
                s.branchcode = txtBankCode.Text;
                s.accountnumber = txtBankNumber.Text;
                int s_paymentmeth = ((PaymentMethod)(cmbAcountMethod).SelectedItem).ID; s.paymentmethodID = s_paymentmeth;
                int s_termpayment = ((PaymentTerm)(cmbAcountTerms).SelectedItem).ID; s.payment_termID = s_termpayment;
                int s_rep1ID = ((Worker)(cmbrepresentative).SelectedItem).WorkerID; s.representaryID = s_rep1ID;
                int s_repAcoID = ((Worker)(cmbAcountRep).SelectedItem).WorkerID; s.accountrepresentaryID = s_repAcoID;
               
                try
                {
                    if (s.BankID != null)
                    {
                        SupplierBank bank1 = new SupplierBank();
                        bank1 = db.SupplierBanks.Where(a => a.ID == s.BankID).FirstOrDefault();
                        s.iban = txtBankIban.Text;
                    }
                    else
                    {
                        s.iban = txtBankIban.Text;
                        db.SupplierBanks.Add(s.SupplierBank);
                        s.BankID = s.SupplierBank.ID;
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
                btnContactDone.Enabled = true;
                itemsEnableTrue();
                if (listContact.DataSource != null)
                {
                    btnContactDelete.Enabled = true;
                    btnContactUpdate.Enabled = true;
                }
                btnupdate.Text = "CANCEL";
                btnnew.Text = "Save";
            }
            else
            {
                btnupdate.Text = "Modify";
                btnnew.Text = "Add";
                itemsEnableFalse();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            #region ComboboxFiller
            cmbAcountMethod.DataSource = db.PaymentMethods.ToList();
            cmbAcountMethod.DisplayMember = "Payment";
            cmbAcountMethod.ValueMember = "ID";

            cmbAcountRep.DataSource = db.Workers.ToList();
            cmbAcountRep.DisplayMember = "FirstName";
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
            cmbCurrenyt.DisplayMember = "rate_name";
            cmbCurrenyt.ValueMember = "ID";

            cmbInvoiceCur.DataSource = db.Rates.ToList();
            cmbInvoiceCur.DisplayMember = "currency";
            cmbInvoiceCur.ValueMember = "ID";

            cmbrepresentative.DataSource = db.Workers.ToList();
            cmbrepresentative.DisplayMember = "FirstName";
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
            if (dgSupplier.Visible == true)
            {
                suppliersearch();
            }
        }

        private void dgSupplier_Click(object sender, EventArgs e)
        {
            if (dgSupplier.DataSource != null)
            {
            gridselectedindex = dgSupplier.CurrentCell.RowIndex;
            suppliersearch();
            }
        }

        private void listContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ContactList
            int cw_ID = 0;
            try
            {
                cw_ID = ((SupplierWorker)((ListBox)sender).SelectedItem).ID;
            }
            catch
            {
                cw_ID = 0;
            }
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
                        txtContactName.Text = a.sw_name;
                        txtContactMail.Text = a.sw_email;
                        cmbdepartman.SelectedIndex = cmbdepartman.FindStringExact(a.SupplierDepartment.departmentname);
                        txtContactfax.Text = a.fax;
                        txtContactMobile.Text = a.mobilephone;
                        cmbposition.SelectedIndex = cmbposition.FindStringExact(a.SupplierTitle.titlename);
                        txtContactPhone.Text = a.phone;
                        cmblanguage.SelectedIndex = cmblanguage.FindStringExact(a.Language.languagename);
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
            btnContactNew.Enabled = false;
            btnContactDelete.Enabled = false;
            btnContactUpdate.Enabled = false;
            btnnew.Enabled = true;
            btnupdate.Enabled = true;

            btnContactNew.Enabled = true;
            if (listContact.DataSource != null)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
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
            btnContactDone.Enabled = true;
            btnContactNew.Enabled = true;
            if (listContact.Items.Count > 0)
            {
                btnContactDelete.Enabled = true;
                btnContactUpdate.Enabled = true;
            }
            listContact.Enabled = false;
            dgSupplier.Enabled = false;
            btnContactNew.Enabled = false;
            btnContactDelete.Enabled = false;
            btnContactUpdate.Enabled = false;
            btnnew.Enabled = false;
            btnupdate.Enabled = false;
            txtsearch.Enabled = false;
            #endregion
        }

        private void AdressTabEnableFalse()
        {
            #region AdressTabEnableFalse
            cmbcounrty.Enabled = false;
            cmbcity.Enabled = false;
            cmbtown.Enabled = false;
            txtpost.Enabled = false;
            txtCompanyAddress.Enabled = false;
            txtpost.Enabled = false;
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
            txtpost.Enabled = true;
            txtCompanyAddress.Enabled = true;
            txtpost.Enabled = true;
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
                                   join l in db.Languages on SupplierWorker.languageID equals l.ID into supplierlanguage
                                   let l = supplierlanguage.Select(supplierlanguage1 => supplierlanguage1).FirstOrDefault()
                                   join n in db.SupplierBanks on c.BankID equals n.ID
                                   join sc in db.SupplierWorkers on c.MainContactID equals sc.ID into suppliercontact
                                   let sc = suppliercontact.Select(supplierworker1 => supplierworker1).FirstOrDefault()
                                   join a in db.SupplierAdresses on c.ID equals a.SupplierID into adress
                                   let a = adress.Select(supplierworker1  => supplierworker1).FirstOrDefault()
                                   select new
                                   {
                                       c.ID,
                                       c.s_name,
                                       c.Rate.currency,
                                       c.telephone,
                                       c.fax,
                                       c.webadress,
                                       c.discountrate,
                                       w.FirstName,
                                       SupplierWorker.sw_name,
                                       SupplierWorker.sw_email,
                                       SupplierWorker.SupplierTitle.titlename,
                                       SupplierWorker.SupplierDepartment.departmentname,
                                       s.SupplierCategory.categoryname,
                                       s.SupplierSubCategory.subcategoryname,
                                       p.term_name,
                                       supplierworker,
                                       swNote = SupplierWorker.Note.Note_name,
                                       SupplierWorker.adress,
                                       SupplierNote = c.Note.Note_name,
                                       AccountRepresentative = supplieraccountant.FirstName,
                                       l.languagename,
                                       n.bankname,
                                       c.iban,
                                       c.branchcode,
                                       c.accountnumber,
                                       c.MainContactID,
                                       Maincontact = sc.sw_name,
                                       c.taxoffice,
                                       c.taxnumber,
                                       AddressCity = a.City.City_name,
                                       AdressCountry = a.Country.Country_name,
                                       a.PostCode,
                                       a.Town.Town_name,
                                       a.AdressDetails,
                                       
                                   }).ToList();
            #endregion
            dgSupplier.DataSource = supplierAdapter;
            if (supplierAdapter.Count > 0)
            {
                #region FillInfos
                dgSupplier.CurrentCell = dgSupplier.Rows[gridselectedindex].Cells[0]; ;
                txtcode.Text = supplierAdapter[gridselectedindex].ID;

                txtname.Text = supplierAdapter[gridselectedindex].s_name;
                txtphone.Text = supplierAdapter[gridselectedindex].telephone.ToString();
                txtfax.Text = supplierAdapter[gridselectedindex].fax.ToString();
                txtweb.Text = supplierAdapter[gridselectedindex].webadress;
                txtnotes.Text = supplierAdapter[gridselectedindex].SupplierNote;
                txtTaxOffice.Text = supplierAdapter[gridselectedindex].taxoffice;
                txtTaxNumber.Text = supplierAdapter[gridselectedindex].taxnumber.ToString();

                txtContactName.Text = supplierAdapter[gridselectedindex].sw_name;
                txtContactMail.Text = supplierAdapter[gridselectedindex].sw_email;
                txtContactNotes.Text = supplierAdapter[gridselectedindex].swNote;
                txtContactAddress.Text = supplierAdapter[gridselectedindex].adress;

                cmbrepresentative.SelectedIndex = cmbrepresentative.FindStringExact(supplierAdapter[gridselectedindex].FirstName);
                txtdiscount.Text = supplierAdapter[gridselectedindex].discountrate.ToString();

                cmbMainContact.SelectedIndex = cmbMainContact.FindStringExact(supplierAdapter[gridselectedindex].Maincontact);
                cmbMainContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                cmbMainContact.DisplayMember = "sw_name";
               
                cmbBankName.SelectedIndex = cmbBankName.FindStringExact(supplierAdapter[gridselectedindex].bankname);
                txtBankCode.Text = supplierAdapter[gridselectedindex].branchcode;
                txtBankNumber.Text = supplierAdapter[gridselectedindex].accountnumber;
                txtBankIban.Text = supplierAdapter[gridselectedindex].iban;

                cmbposition.SelectedIndex = cmbposition.FindStringExact(supplierAdapter[gridselectedindex].titlename);
                cmbdepartman.SelectedIndex = cmbdepartman.FindStringExact(supplierAdapter[gridselectedindex].titlename);
                cmbcategory.SelectedIndex = cmbcategory.FindStringExact(supplierAdapter[gridselectedindex].categoryname);
                cmbsub.SelectedIndex=cmbsub.FindStringExact(supplierAdapter[gridselectedindex].subcategoryname);

                cmbAcountTerms.SelectedIndex = cmbAcountTerms.FindStringExact(supplierAdapter[gridselectedindex].term_name);
                cmbAcountRep.Text = supplierAdapter[gridselectedindex].AccountRepresentative;
                cmblanguage.Text = supplierAdapter[gridselectedindex].languagename;

                listContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                listContact.DisplayMember = "sw_name";

                AdressList.DataSource = db.SupplierAdresses.Where(suppliera => suppliera.SupplierID == txtcode.Text).ToList();
                AdressList.DisplayMember = "AdressDetails";

                txtpost.Text = supplierAdapter[gridselectedindex].PostCode;
                cmbcounrty.SelectedIndex = cmbcounrty.FindStringExact(supplierAdapter[gridselectedindex].AdressCountry);
                cmbcity.SelectedIndex = cmbcity.FindStringExact(supplierAdapter[gridselectedindex].AddressCity);
                cmbtown.SelectedIndex = cmbtown.FindStringExact(supplierAdapter[gridselectedindex].Town_name);
                txtCompanyAddress.Text = supplierAdapter[gridselectedindex].AdressDetails;

                dgSupplier.Update();
                dgSupplier.Refresh();

                #endregion
            }
            else { itemsClear(); }
        }

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
            btnDep.Enabled = true;
            btnPos.Enabled = true;
            btnContactCancel.Visible = true;
            btnContactDone.Visible = true;
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
                dgSupplier.Enabled = true;
            }
            btnContactNew.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDelete.Visible = true;
            btnContactDone.Visible = false;
            btnContactUpdate.Visible = true;
            #endregion
        }

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
                cw.adress = txtContactAddress.Text;
                db.SupplierWorkers.Add(cw);
                db.SaveChanges();
                Note n = new Note();
                n.Note_name = txtContactNotes.Text;
                db.Notes.Add(n);
                db.SaveChanges();
                contactTabEnableFalse();
                if (btnnew.Text == "Add")
                {
                    txtsearch.Enabled = true;
                    dgSupplier.Enabled = true;
                }
                listContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                listContact.DisplayMember = "sw_name";
                //Main contact değişimi için
                //  cmbMainContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                //  cmbMainContact.DisplayMember = "sw_name";
            }
            else
            {

                SupplierWorker cw = db.SupplierWorkers.Where(a => a.ID == ((SupplierWorker)(listContact).SelectedItem).ID).FirstOrDefault();
                if (cw.sw_name != "")
                {
                    //Update Contact
                    cw.supplierID = txtcode.Text;
                    cw.departmentID = ((SupplierDepartment)(cmbdepartman).SelectedItem).ID;
                    cw.titleID = ((SupplierTitle)(cmbposition).SelectedItem).ID;
                    cw.sw_name = txtContactName.Text;
                    cw.sw_email = txtContactMail.Text;
                    cw.phone = txtContactPhone.Text;
                    cw.mobilephone = txtContactMobile.Text;
                    cw.fax = txtContactfax.Text;
                    cw.languageID = ((Language)(cmblanguage).SelectedItem).ID;
                    cw.adress = txtContactAddress.Text;
                    var contactNote = db.Notes.Where(a => a.ID == cw.WorkerNoteID).FirstOrDefault();
                    if (contactNote == null)
                    {
                        if (txtContactNotes.Text != "")
                        {
                            Note n = new Note();
                            n.Note_name = txtContactNotes.Text;
                            db.Notes.Add(n);
                            db.SaveChanges();
                            cw.WorkerNoteID = n.ID;
                        }
                    }
                    else
                    {
                        contactNote.Note_name = txtContactNotes.Text;
                        db.SaveChanges();
                        cw.WorkerNoteID = contactNote.ID;
                    }
                    db.SaveChanges();
                    contactTabEnableFalse();
                    if (btnnew.Text == "Add")
                    {
                        txtsearch.Enabled = true;
                        dgSupplier.Enabled = true;
                    }
                    listContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                    listContact.DisplayMember = "sw_name";
                    cmbMainContact.DataSource = db.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                    cmbMainContact.DisplayMember = "sw_name";
                }
                else { MessageBox.Show("Contact is NOT successfull"); }
            } 
            btnContactNew.Visible = true;
            btnContactDelete.Visible = true;
            btnContactUpdate.Visible = true;
            btnContactCancel.Visible = false;
            btnContactDone.Visible = false;
        }

        private void cmbdepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s_departmentID;
            try { s_departmentID = ((SupplierDepartment)((ComboBox)sender).SelectedItem).ID; } catch { s_departmentID = 0; }
            cmbposition.DataSource = db.SupplierTitles.Where(b => b.SupplierDepartment.ID == s_departmentID).ToList();
            cmbposition.DisplayMember = "titlename";
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

            if (cmbMainContact.DataSource != null) { cmbMainContact.SelectedIndex = 0; }
            if (cmbsub.DataSource != null) { cmbsub.SelectedIndex = 0; }
            listContact.DataSource = null;
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
            btnupdate.Enabled = false;
            btnContactDone.Enabled = false;
            btnDep.Enabled = false;
            btnPos.Enabled = false;
            btnContactCancel.Enabled = false;
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

        private void listContact_DataSourceChanged(object sender, EventArgs e)
        {
            if (listContact.DataSource == null) { btnContactDelete.Enabled = false; btnContactUpdate.Enabled = false; }

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
                gridselectedindex = 0;
                searchtxt = txtsearch.Text;
                suppliersearch();
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
                return;
            }
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

        private void AdressCancel_Click(object sender, EventArgs e)
        {
            AdressTabEnableFalse();
            if (btnnew.Text == "CREATE")
            {
                txtsearch.Enabled = true;
                dgSupplier.Enabled = true;
            }
            AdressList.DataSource = db.SupplierAdresses.Where(supplierw => supplierw.SupplierID == txtcode.Text).ToList();
            AdressList.DisplayMember = "sw_name";

            AdressAdd.Visible = true;
            AddressDel.Visible = true;
            AddressUpd.Visible = true;
            AdressCancel.Visible = false;
            AdressDone.Visible = false;
            suppliersearch();
        }

        private void Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbcity.DataSource = db.Cities.Where(a => a.CountryID == ((Country)(cmbcounrty).SelectedItem).ID).ToList();
                cmbcity.DisplayMember = "City_name";
            }
            catch { }
        }

        private void City_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbtown.DataSource = db.Towns.Where(a => a.CityID == ((City)(cmbcity).SelectedItem).ID).ToList();
                cmbtown.DisplayMember = "Town_name";
            }
            catch { }
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
                        txtpost.Text = a.PostCode;
                        txtpobox.Text = a.PoBox;
                        txtCompanyAddress.Text = a.AdressDetails;
                    }
                }
            }
            catch { }
            #endregion


        }

        private void AdressAdd_Click(object sender, EventArgs e)
        {
            #region addAdressButton
            AdressTabEnableTrue();
            cmbcounrty.Text = "";
            cmbcity.Text = "";
            cmbtown.Text = "";
            txtpost.Text = "";
            txtpobox.Text = "";
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
                AdressList.DataSource = db.SupplierAdresses.Where(suppliera => suppliera .SupplierID == txtcode.Text).ToList();
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
            ca = db.SupplierAdresses.Where(a => a.ID == ((SupplierAdress)(AdressList).SelectedItem).ID).FirstOrDefault();
            if (ca != null)
            {

                //CustomerCode.Text;
                ca.SupplierID = txtcode.Text;
                ca.CountryID = ((Country)(cmbcounrty).SelectedItem).ID;
                ca.CityID = ((City)(cmbcity).SelectedItem).ID;
                ca.TownID=((Town)(cmbtown).SelectedItem).ID;
                //AddresType
                ca.PostCode = txtpost.Text;
                ca.PoBox = txtpobox.Text;
                ca.AdressDetails = txtCompanyAddress.Text;
                db.SaveChanges();
            }
            else
            {
                ca = new SupplierAdress();
                //CustomerCode.Text;
                ca.SupplierID = txtcode.Text;
                ca.CountryID = ((Country)(cmbcounrty).SelectedItem).ID;
                ca.CityID = ((City)(cmbcity).SelectedItem).ID;
                ca.TownID = ((Town)(cmbtown).SelectedItem).ID;
                //AddresType
                ca.PostCode = txtpost.Text;
                ca.PoBox = txtpobox.Text;
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
            AdressList.DataSource = db.SupplierAdresses.Where(supplierw => supplierw.SupplierID == txtcode.Text).ToList();
            AdressList.DisplayMember = "sw_name";

            AdressAdd.Visible = true;
            AddressDel.Visible = true;
            AddressUpd.Visible = true;
            AdressCancel.Visible = false;
            AdressDone.Visible = false;
        }

    }

}