using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LoginForm
{
    //
    public partial class SupplierMain : Form
        {
        IMEEntities IME = new IMEEntities();
        int gridselectedindex = 0;
        string searchtxt = "";
        int selectedContactID;
        int isNewContact = 0;
        int isUpdateAdress;
        string ComboboxString = "Choose";

        public SupplierMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region ComboboxFiller
            cmbAcountMethod.DataSource = IME.PaymentMethods.ToList();
            cmbAcountMethod.DisplayMember = "Payment";
            cmbAcountMethod.ValueMember = "ID";

            cmbAcountRep.DataSource = IME.Workers.ToList();
            cmbAcountRep.DisplayMember = "NameLastName";
            cmbAcountRep.ValueMember = "WorkerID";

            cmbAcountTerms.DataSource = IME.PaymentTerms.OrderBy(p=>p.timespan).ToList();
            cmbAcountTerms.DisplayMember = "term_name";
            cmbAcountTerms.ValueMember = "ID";

            cmbcategory.DataSource = IME.SupplierCategories.ToList();
            cmbcategory.DisplayMember = "categoryname";
            cmbcategory.ValueMember = "ID";

            cmbsub.DataSource = IME.SupplierSubCategories.ToList();
            cmbsub.DisplayMember = "subcategoryname";
            cmbsub.ValueMember = "ID";
 
            cmbCurrenyt.DataSource = IME.Currencies.ToList();
            cmbCurrenyt.DisplayMember = "currencyName";
            cmbCurrenyt.ValueMember = "currencyId";

            cmbInvoiceCur.DataSource = IME.Currencies.ToList();
            cmbInvoiceCur.DisplayMember = "currencyName";
            cmbInvoiceCur.ValueMember = "currencyId";

            cmbrepresentative.DataSource = IME.Workers.ToList();
            cmbrepresentative.DisplayMember = "NameLastName";
            cmbrepresentative.ValueMember = "WorkerID";

            //cmbdepartman.DataSource = IME.SupplierDepartments.ToList();
            //cmbdepartman.DisplayMember = "departmentname";
            //cmbdepartman.ValueMember = "ID";

            cmblanguage.DataSource = IME.Languages.ToList();
            cmblanguage.DisplayMember = "languagename";
            cmblanguage.ValueMember = "ID";

            //cmbposition.DataSource = IME.SupplierTitles.ToList();
            //cmbposition.DisplayMember = "titlename";
            //cmbposition.ValueMember = "ID";

            cmbBankName.DataSource = IME.SupplierBanks.ToList();
            cmbBankName.DisplayMember = "bankname";
            cmbBankName.ValueMember = "ID";

            cmbcounrty.DataSource = IME.Countries.ToList();
            cmbcounrty.DisplayMember = "Country_name";
            cmbcounrty.ValueMember = "ID";

            
            #endregion
            itemsEnableFalse();
            contactTabEnableFalse();
            suppliersearch();
        }

        private void dgSupplier_Click(object sender, EventArgs e)
        {
            //gridselectedindex = dgSupplier.CurrentCell.RowIndex;
            //supplierClicksearch();
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
                    var contact1 = IME.SupplierWorkers.Where(cw => cw.ID == cw_ID).ToList();
                    foreach (var a in contact1)
                    {
                        selectedContactID = a.ID;
                        //if (a.SupplierDepartment != null) cmbdepartman.SelectedValue = cmbdepartman.FindStringExact(a.SupplierDepartment.departmentname);
                        //if (a.SupplierTitle != null) cmbposition.SelectedValue = cmbposition.FindStringExact(a.SupplierTitle.titlename);
                        //cmblanguage.SelectedIndex = cmblanguage.FindStringExact(a.Language.languagename);
                        //txtContactName.Text = a.sw_name;
                        //txtContactMail.Text = a.sw_email;
                        //txtContactfax.Text = a.fax;
                        //txtContactMobile.Text = a.mobilephone;
                        //txtContactPhone.Text = a.phone;
                        //if (a.Note != null) { txtContactNotes.Text = a.Note.Note_name; } else { txtContactNotes.Text = ""; }
                    }
                }
            }
            catch { }
            #endregion
        }

        private void btnDep_Click(object sender, EventArgs e)
        {
            frmSupplierCategoryAdd form = new frmSupplierCategoryAdd();
            this.Enabled = false;
            this.SendToBack();
            form.ShowDialog();
            //cmbdepartman.DataSource = IME.SupplierDepartments;
            this.Enabled = true;
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            //frmSupplierSubCategoryAdd form = new frmSupplierSubCategoryAdd();
            this.Enabled = false;
            this.SendToBack();
            //form.ShowDialog();
            //cmbposition.DataSource = IME.SupplierTitles;
            this.Enabled = true;
        }

        private void cmbcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_categoryID;
            try { c_categoryID = ((SupplierCategory)((ComboBox)sender).SelectedItem).ID; } catch { c_categoryID = 0; }
            cmbsub.DataSource = IME.SupplierSubCategories.Where(b => b.categoryID == c_categoryID).ToList();
            cmbsub.DisplayMember = "subcategoryname";
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            gridselectedindex = 0;
            searchtxt = txtsearch.Text;
            suppliersearch();
        }

        private void supplierClicksearch()
        {
            string supplierID = dgSupplier.CurrentRow.Cells["ID"].Value.ToString();
           DataSet.Supplier c = IME.Suppliers.Where(a => a.ID == supplierID).FirstOrDefault();
           // dateTimePicker1.Value = c.CreateDate.Value;
            txtcode.Text = c.ID;
            AdressList.DataSource = IME.SupplierAddresses.Where(customera => customera.SupplierID == txtcode.Text).ToList();
            AdressList.DisplayMember = "AdressDetails";
            AdressList.ValueMember = "ID";
            //ContactAdress.DataSource = IME.CustomerAddresses.Where(customera => customera.CustomerID == CustomerCode.Text).ToList();
            //ContactAdress.DisplayMember = "AdressDetails";
            txtname.Text = c.s_name;
            txtphone.Text = c.telephone;
            txtfax.Text = c.fax;
            txtweb.Text = c.webadress;
           // if (c.Worker2 != null) Represantative2.SelectedValue = c.Worker2.WorkerID;
            if (c.Worker1 != null) cmbrepresentative.SelectedValue = c.Worker1.WorkerID;
            if (c.accountrepresentaryID != null) cmbAcountRep.Text = IME.Workers.Where(a => a.WorkerID == c.accountrepresentaryID).FirstOrDefault().NameLastName;
            if (c.PaymentTerm != null) cmbAcountTerms.SelectedValue = c.PaymentTerm.ID;
            listContact.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtcode.Text).ToList();
            listContact.DisplayMember = "sw_name";
            cmbMainContact.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtcode.Text).ToList();
            cmbMainContact.DisplayMember = "sw_name";
            if (c.Note != null) txtnotes.Text = IME.Notes.Where(a => a.ID == c.Note.ID).FirstOrDefault().Note_name;
            if (c.SupplierNoteID != null) txtAccountNotes.Text = IME.Notes.Where(a => a.ID == c.SupplierNoteID).FirstOrDefault().Note_name;
           
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
            txtExtNumber.Enabled = false;

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
            txtExtNumber.Enabled = true;
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
            txtExtNumber.Enabled = false;
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
            txtExtNumber.Enabled = true;
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

        

        //CONTACT ADD NEW
        private void suppliersearch()
        {
            if (searchtxt == null || searchtxt == "")
            {
                var SupplierList =(from c in IME.Suppliers.Where(a => a.s_name.Contains(searchtxt))
                                   select new {
                                       c.ID,
                                       CustomerName = c.s_name,
                                       Telephone = c.telephone,
                                       PaymentMethod = c.PaymentMethod.Payment,
                                       Fax = c.fax,
                                       CrediLimit = c.creditlimit,
                                       Web = c.webadress,
                                       PaymentTerm = c.PaymentTerm.term_name,
                                       WorkerName = c.Worker.NameLastName,
                                       CurType = c.Rate.CurType,
                                       TaxOffice = c.taxoffice,
                                       TaxNumber = c.taxnumber,
                                       Representative = c.accountrepresentaryID,
                                       NoteName = c.Note.Note_name,
                                       MainContact = c.MainContactID,
                                       BankName = c.SupplierBank.bankname,
                                       PoBox = c.PoBox,
                                       Disc = c.discountrate,
                                       Iban = c.iban,
                                       BrancCoe = c.branchcode,
                                       AccountNumber = c.accountnumber
                                   }).ToList();
                dgSupplier.DataSource = SupplierList;
            }
            else
            {
                var SupplierList = (from c in IME.Suppliers.Where(a => a.s_name.Contains(searchtxt))
                                    select new
                                    {
                                        c.ID,
                                        CustomerName = c.s_name,
                                        Telephone = c.telephone,
                                        PaymentMethod = c.PaymentMethod.Payment,
                                        Fax = c.fax,
                                        CrediLimit = c.creditlimit,
                                        Web = c.webadress,
                                        PaymentTerm = c.PaymentTerm.term_name,
                                        WorkerName = c.Worker.NameLastName,
                                        CurType = c.Rate.CurType,
                                        TaxOffice = c.taxoffice,
                                        TaxNumber = c.taxnumber,
                                        Representative = c.accountrepresentaryID,
                                        NoteName = c.Note.Note_name,
                                        MainContact = c.MainContactID,
                                        BankName = c.SupplierBank.bankname,
                                        PoBox = c.PoBox,
                                        Disc = c.discountrate,
                                        Iban = c.iban,
                                        BrancCoe = c.branchcode,
                                        AccountNumber = c.accountnumber
                                    }).ToList();
                dgSupplier.DataSource = SupplierList;
            }
            if (dgSupplier.RowCount != 0)
            {
                string supplierID = dgSupplier.CurrentRow.Cells["ID"].Value.ToString();
                DataSet.Supplier c = IME.Suppliers.Where(a => a.ID == supplierID).FirstOrDefault();
                txtcode.Text = c.ID;
                AdressList.DataSource = IME.SupplierAddresses.Where(customera => customera.SupplierID == txtcode.Text).ToList();
                AdressList.DisplayMember = "AdressDetails";
                txtname.Text = c.s_name;
                txtphone.Text = c.telephone;
                txtfax.Text = c.fax;
                txtweb.Text = c.webadress;
                if (c.Worker1 != null) cmbrepresentative.SelectedValue = c.Worker1.WorkerID;
                if (c.accountrepresentaryID != null) cmbAcountRep.Text = IME.Workers.Where(a => a.WorkerID == c.accountrepresentaryID).FirstOrDefault().NameLastName;
                if (c.PaymentTerm != null) cmbAcountTerms.SelectedValue = c.PaymentTerm.ID;
                listContact.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtcode.Text).ToList();
                listContact.DisplayMember = "sw_name";
                cmbMainContact.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtcode.Text).ToList();
                cmbMainContact.DisplayMember = "sw_name";
                if (c.Note != null) txtnotes.Text = IME.Notes.Where(a => a.ID == c.Note.ID).FirstOrDefault().Note_name;
                if (c.SupplierNoteID != null) txtAccountNotes.Text = IME.Notes.Where(a => a.ID == c.SupplierNoteID).FirstOrDefault().Note_name;
            }
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
                            //cw.departmentID = ((SupplierDepartment)(cmbdepartman).SelectedItem).ID;
                            //cw.titleID = ((SupplierTitle)(cmbposition).SelectedItem).ID;
                            cw.sw_name = txtContactName.Text;
                            cw.sw_email = txtContactMail.Text;
                            cw.phone = txtContactPhone.Text;
                            cw.mobilephone = txtContactMobile.Text;
                            cw.fax = txtContactfax.Text;
                            cw.languageID = ((Language)(cmblanguage).SelectedItem).ID;
                            Note n = new Note();
                            n.Note_name = txtContactNotes.Text;
                            IME.Notes.Add(n);
                            IME.SaveChanges();
                            cw.supplierNoteID = n.ID;
                            IME.SupplierWorkers.Add(cw);
                            IME.SaveChanges();
                            contactTabEnableFalse();
                            if (btnnew.Text == "CREATE")
                            {
                                txtsearch.Enabled = true;
                                dgSupplier.Enabled = true;
                            }
                            listContact.DataSource = IME.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                            listContact.DisplayMember = "sw_name";
                            cmbMainContact.DataSource = IME.SupplierWorkers.Where(customerw => customerw.supplierID == txtcode.Text).ToList();
                            cmbMainContact.DisplayMember = "sw_name";
                        }
                    }
            }
            else
            {

                SupplierWorker cw = IME.SupplierWorkers.Where(a => a.ID == ((SupplierWorker)(listContact).SelectedItem).ID).FirstOrDefault();
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
                                //cw.departmentID = ((SupplierDepartment)(cmbdepartman).SelectedItem).ID;
                                //cw.titleID = ((SupplierTitle)(cmbposition).SelectedItem).ID;
                                cw.sw_name = txtContactName.Text;
                                cw.sw_email = txtContactMail.Text;
                                cw.phone = txtContactPhone.Text;
                                cw.mobilephone = txtContactMobile.Text;
                                cw.fax = txtContactfax.Text;
                                cw.languageID = ((Language)(cmblanguage).SelectedItem).ID;
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
                                contactTabEnableFalse();
                                if (btnnew.Text == "ADD")
                                {
                                    txtsearch.Enabled = true;
                                    dgSupplier.Enabled = true;
                                }
                                listContact.DataSource = IME.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                                listContact.DisplayMember = "sw_name";
                                cmbMainContact.DataSource = IME.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                                cmbMainContact.DisplayMember = "sw_name";
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
                SupplierWorker sw = IME.SupplierWorkers.First(a => a.ID == ContactListItem.ID);
                IME.SupplierWorkers.Remove(sw);
                IME.SaveChanges();
                listContact.DataSource = IME.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                listContact.DisplayMember = "sw_name";
                cmbMainContact.DataSource = null;
                cmbMainContact.DataSource = IME.SupplierWorkers.Where(supplierw => supplierw.supplierID == txtcode.Text).ToList();
                cmbMainContact.DisplayMember = "sw_name";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void cmbdepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s_departmentID;
            //try { s_departmentID = ((SupplierDepartment)((ComboBox)sender).SelectedItem).ID; } catch { s_departmentID = 0; }
            //cmbposition.DataSource = IME.SupplierTitles.Where(b => b.SupplierDepartment.ID == s_departmentID).ToList();
            cmbposition.DisplayMember = "titlename";
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            if (btnnew.Text == "Add")
            {
                itemsEnableTrue();
                itemsClear();
                int represantative_id = Utils.getCurrentUser().WorkerID;
                cmbrepresentative.DataSource = IME.Workers.Where(a => a.WorkerID == represantative_id).ToList();
                cmbrepresentative.DisplayMember = "NameLastName";
                cmbMainContact.DataSource = null;
                #region ComboboxChoose
                cmbMainContact.Text = (ComboboxString);
                cmbsub.Text = (ComboboxString);
                cmbAcountRep.Text = (ComboboxString);
                cmbAcountMethod.Text = (ComboboxString);
                cmbCurrenyt.Text = (ComboboxString);
                cmbInvoiceCur.Text = (ComboboxString);
                cmbcounrty.Text = (ComboboxString);
                cmbcity.Text = (ComboboxString);
                cmbtown.Text = (ComboboxString);
                cmbdepartman.Text = (ComboboxString);
                cmbposition.Text = (ComboboxString);
                cmblanguage.Text = (ComboboxString);
                #endregion

                //for new customerCode
                string suppliercode = "";
                if (IME.Suppliers.ToList().Count != 0) suppliercode = IME.Suppliers.OrderByDescending(a => a.ID).FirstOrDefault().ID;
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
                while (IME.Suppliers.Where(a => a.ID == suppliercode).Count() > 0)
                {
                    newsuppliercodenumbers = (Int32.Parse(newsuppliercodenumbers) + 1).ToString();
                    suppliercode = newsuppliercodechars + newsuppliercodezeros + newsuppliercodenumbers;
                }
                //
                listContact.DataSource = null;
                txtcode.Text = suppliercode;
                DataSet.Supplier s = new DataSet.Supplier();
                s.ID = txtcode.Text;
                IME.Suppliers.Add(s);
                IME.SaveChanges();
                btnnew.Text = "Save";
                btnupdate.Text = "Cancel";
                AdressList.Enabled = false;
                AdressList.DataSource = null;
                AdressAdd.Enabled = true;
                btnContactNew.Enabled = true;
            }
            else
            {
                if (ControlSave())
                {

                    if (cmbsub.Text == ComboboxString || cmbAcountRep.Text == ComboboxString || cmbAcountMethod.Text == ComboboxString || cmbCurrenyt.Text == ComboboxString || cmbInvoiceCur.Text == ComboboxString || cmbcounrty.Text == ComboboxString || cmbcity.Text == ComboboxString || cmbtown.Text == ComboboxString || cmbdepartman.Text == ComboboxString || cmbposition.Text == ComboboxString || cmblanguage.Text == ComboboxString)
                    {
                        MessageBox.Show("Combobox is empty", "WARNİNG", MessageBoxButtons.OK);

                    }
                    else
                    {
                        btnnew.Text = "Add";
                        btnupdate.Text = "Modify";

                        DataSet.Supplier s = new DataSet.Supplier();
                        s = IME.Suppliers.Where(a => a.ID == txtcode.Text).FirstOrDefault();
                        s.s_name = txtname.Text;
                        try { if (txtdiscount.Text != "") { s.discountrate = Int32.Parse(txtdiscount.Text); } } catch { };
                        try { if (txtphone.Text != "") { s.telephone = txtphone.Text; } } catch { };
                        try { int s_paymentmeth = ((PaymentMethod)(cmbAcountMethod).SelectedItem).ID; s.paymentmethodID = s_paymentmeth; } catch { };
                        try { if (txtfax.Text != "") { s.fax = txtfax.Text; } } catch { };
                        s.webadress = txtweb.Text;
                        try { int s_termpayment = ((PaymentTerm)(cmbAcountTerms).SelectedItem).ID; s.payment_termID = s_termpayment; } catch { };
                        try { int s_rep1ID = ((Worker)(cmbrepresentative).SelectedItem).WorkerID; s.representaryID = s_rep1ID; } catch { };
                        try { int s_repAcoID = ((Worker)(cmbAcountRep).SelectedItem).WorkerID; s.accountrepresentaryID = s_repAcoID; } catch { };
                        s.taxoffice = txtTaxOffice.Text;
                        s.PoBox = txtpobox.Text;
                        try { if (txtTaxNumber.Text != "") { s.taxnumber = txtTaxNumber.Text; } } catch { };
                        try
                        {
                            if (s.BankID != null)
                            {
                                SupplierBank bank1 = new SupplierBank();
                                bank1 = IME.SupplierBanks.Where(a => a.ID == s.BankID).FirstOrDefault();
                                s.iban = txtBankIban.Text;
                                s.branchcode = txtBankCode.Text;
                                s.accountnumber = txtBankNumber.Text;
                            }
                            else
                            {
                                s.iban = txtBankIban.Text;
                                IME.SupplierBanks.Add(s.SupplierBank);
                                s.BankID = s.SupplierBank.ID;
                                s.branchcode = txtBankCode.Text;
                                s.accountnumber = txtBankNumber.Text;
                            }
                            IME.SaveChanges();
                        }
                        catch { }
                        int s_bank = ((SupplierBank)(cmbBankName).SelectedItem).ID; s.BankID = s_bank;
                        //CategorySubCategory Tablosuna veri ekleniyor(ara tabloya)
                        //SupplierCategorySubCategory SupplierCatSubCat = new SupplierCategorySubCategory();
                        ////UPDATE YAPILIRKEN BU ŞEKİLDE OLUYOR
                        //if (IME.SupplierCategorySubCategories.Where(a => a.supplierID == txtcode.Text).FirstOrDefault() != null) { SupplierCatSubCat = IME.SupplierCategorySubCategories.Where(a => a.supplierID == txtcode.Text).FirstOrDefault(); }
                        //SupplierCatSubCat.supplierID = txtcode.Text;
                        //int c_CategoryID = ((SupplierCategory)(cmbcategory).SelectedItem).ID;
                        //SupplierCatSubCat.categoryID = c_CategoryID;
                        //int c_SubcategoryID = ((SupplierSubCategory)(cmbsub).SelectedItem).ID;
                        //SupplierCatSubCat.subcategoryID = c_SubcategoryID;
                        //if (IME.SupplierCategorySubCategories.Where(a => a.supplierID == txtcode.Text).FirstOrDefault() == null) { IME.SupplierCategorySubCategories.Add(SupplierCatSubCat); }
                        IME.SaveChanges();
                        //        
                        //Notes kısmına kayıt ediliyor
                        try
                        {
                            if (s.SupplierNoteID != null)
                            {
                                Note note1 = new Note();
                                note1 = IME.Notes.Where(a => a.ID == s.SupplierNoteID).FirstOrDefault();
                                note1.Note_name = txtnotes.Text;
                            }
                            else
                            {
                                s.Note.Note_name = txtnotes.Text;
                                IME.Notes.Add(s.Note);
                                s.SupplierNoteID = s.Note.ID;
                            }
                            IME.SaveChanges();

                        }
                        catch { }

                        IME.SaveChanges();
                        itemsEnableFalse();
                        contactTabEnableFalse();
                        suppliersearch();
                    }
                }
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
                btnupdate.Text = "Cancel";
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
                var supplier = IME.Suppliers.Where(a => a.ID == txtcode.Text).FirstOrDefault();
                if (supplier.s_name == null)
                {
                    //CREATE in cancel ı
                    var sw = IME.SupplierWorkers.Where(a => a.supplierID == txtcode.Text);
                    //ilk önce Contact ların ve adress lerin verilerini sil sonra supplier ın verisini sil
                    while (sw.Count() > 0)
                    {
                        IME.SupplierWorkers.Remove(sw.FirstOrDefault());
                        IME.SaveChanges();
                    }
                    //üstteki işlem adresses için de yapılmalı
                    //

                    DataSet.Supplier s = new DataSet.Supplier();
                    s = IME.Suppliers.Where(a => a.ID == txtcode.Text).FirstOrDefault();
                    IME.Suppliers.Remove(s);
                    IME.SaveChanges();
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
                SupplierAddress ca = IME.SupplierAddresses.First(a => a.ID == ContactListItem.AdressID);
                IME.SupplierAddresses.Remove(ca);
                IME.SaveChanges();
                AdressList.DataSource = IME.SupplierAddresses.Where(suppliera => suppliera.SupplierID == txtcode.Text).ToList();
                AdressList.DisplayMember = "AdressDetails";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void AdressDone_Click(object sender, EventArgs e)
        {
            SupplierAddress ca = new SupplierAddress();
            if (isUpdateAdress == 1)
            {
                int saID = ((AdressList).SelectedItem as SupplierAddress).ID;
                ca = IME.SupplierAddresses.Where(a => a.ID == saID).FirstOrDefault();
            }
            else { ca = null; }

            if (ca != null)
            {
                ca.SupplierID = txtcode.Text;
                ca.CountryID = ((cmbcounrty).SelectedItem as Country).ID;
                ca.CityID = ((cmbcity).SelectedItem as City).ID;
                ca.TownID = ((cmbtown).SelectedItem as Town).ID;
                ca.AdressDetails = txtCompanyAddress.Text;

                IME.SaveChanges();
            }
            else
            {
                ca = new SupplierAddress();
                ca.SupplierID = txtcode.Text;
                ca.CountryID = ((cmbcounrty).SelectedItem as Country).ID;
                ca.CityID = ((cmbcity).SelectedItem as City).ID;
                ca.TownID = ((cmbtown).SelectedItem as Town).ID;
                ca.AdressDetails = txtCompanyAddress.Text;
                
                IME.SupplierAddresses.Add(ca);
                IME.SaveChanges();
            }

            AdressTabEnableFalse();
            if (btnnew.Text == "CREATE")
            {
                txtsearch.Enabled = true;
                dgSupplier.Enabled = true;
            }
            AdressList.DataSource = null;
            AdressList.DataSource = IME.SupplierAddresses.Where(suppliera => suppliera.SupplierID == txtcode.Text).ToList();
            AdressList.DisplayMember = "AdressDetails";

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
            AdressList.DataSource = IME.SupplierAddresses.Where(suppliera => suppliera.SupplierID == txtcode.Text).ToList();
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
            try { cw_ID = ((SupplierAddress)((ListBox)sender).SelectedValue).ID; } catch { cw_ID = 0; }
            try
            {
                if (ContactListItem.AdressID != cw_ID)
                {
                    ContactListItem.AdressID = cw_ID;

                    var contact1 = IME.SupplierAddresses.Where(cw => cw.ID == cw_ID).ToList();
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
                cmbcity.DataSource = IME.Cities.Where(a => a.CountryID == (int)(cmbcounrty.SelectedValue)).ToList();
                cmbcity.DisplayMember = "City_name";
                cmbcity.ValueMember = "ID";
            }
            catch { }
        }

        private void cmbcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbtown.DataSource = IME.Towns.Where(a => a.CityID == ((int)(cmbcity).SelectedValue)).ToList();
                cmbtown.DisplayMember = "Town_name";
                cmbtown.ValueMember = "ID";
            }
            catch { }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
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
                MessageBox.Show("info@imeturkey.com", "Please provide valid Mail address !");
                txtContactMail.Focus();
                return;
            }
        }

        private void txtContactPhone_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtContactPhone.Text, pattern) || txtContactPhone.Text == string.Empty)
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please provide valid Phone Number !");
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
                MessageBox.Show("Example: 0212 210 05 07", "Please provide valid Phone Number !");
                txtphone.Focus();
                return;
            }
        }

        private void txtfax_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtfax.Text, pattern) || txtfax.Text == string.Empty)
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please provide valid Fax Number !");
                txtfax.Focus();
                return;
            }
        }

        private void txtContactfax_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtContactfax.Text, pattern) || txtContactfax.Text == string.Empty)
            {

            }
            else
            {
                MessageBox.Show("Example: 0212 210 05 07", "Please provide valid Fax Number !");
                txtContactfax.Focus();
                return;
            }
        }

        private void txtContactMobile_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{2})[ ]([0-9]{2})$";
            if (Regex.IsMatch(txtContactMobile.Text, pattern) || txtContactMobile.Text == string.Empty)
            {

            }
            else
            {
                MessageBox.Show("Example: 0530 283 38 02 ", "Please provide valid Mobile Phone Number !");
                txtContactMobile.Focus();
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
                MessageBox.Show("Example: TR11 0011 1000 0000 0038 1312 04 ", "Please provide valid IBAN Number !");
                txtBankIban.Focus();
                return;
            }
        }

        private bool ControlSave()
        {
            bool isSave = true;
            string ErrorMessage = string.Empty;
            if (txtcode.Text == null || txtcode.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Company's Name\n"; isSave = false; }
            if (cmbcategory.Text == ComboboxString) { ErrorMessage = ErrorMessage + "Please Choose Main Category Company\n"; isSave = false; }
            if (cmbsub.Text == ComboboxString) { ErrorMessage = ErrorMessage + "Please Choose SubCategory of Company\n"; isSave = false; }
            if (txtphone.Text == null || txtphone.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Company's Phone correctly or Delete\n"; isSave = false; }
            //if (listContact.Items.Count == 0) { ErrorMessage = ErrorMessage + "Please Enter a Contact\n"; isSave = false; }
            if (isSave == true) { return true; } else { MessageBox.Show(ErrorMessage); return false; }
        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            try { decimal DiscountRateValue = Decimal.Parse(txtdiscount.Text); } catch { }
        }

        private void cmbrepresentative_MouseClick(object sender, MouseEventArgs e)
        {
            cmbrepresentative.DataSource = IME.Workers.ToList();
            cmbrepresentative.DisplayMember = "NameLastName";
            cmbrepresentative.ValueMember = "WorkerID";
        }

        private void dgSupplier_DoubleClick(object sender, EventArgs e)
        {
            DataSet.Supplier model = new DataSet.Supplier();

            if (dgSupplier.CurrentRow.Index != -1)
            {
                model.ID = dgSupplier.CurrentRow.Cells["ID"].Value.ToString();
                using (IMEEntities db = new IMEEntities())
                {
                    model = db.Suppliers.Where(x => x.ID == model.ID).FirstOrDefault();

                    txtname.Text = model.s_name;
                    txtcode.Text = model.ID;
                    //cmbrepresentative.SelectedItem= model.representaryID;
                    if (model.Worker1 != null) cmbrepresentative.SelectedValue = model.Worker1.WorkerID;
                    txtTaxOffice.Text = model.taxoffice;
                    txtTaxNumber.Text = Convert.ToString(model.taxnumber);
                    //cmbAcountRep.SelectedItem =model.accountrepresentaryID;
                    if (model.accountrepresentaryID != null) cmbAcountRep.Text = db.Workers.Where(a => a.WorkerID == model.accountrepresentaryID).FirstOrDefault().NameLastName;
                    //cmbAcountTerms.SelectedItem=model.payment_termID ;
                    if (model.PaymentTerm != null) cmbAcountTerms.SelectedValue = model.PaymentTerm.ID;
                    //cmbAcountMethod.SelectedItem=model.paymentmethodID;
                    if (model.PaymentMethod != null) cmbAcountMethod.SelectedValue = model.PaymentMethod.ID;
                    txtdiscount.Text = Convert.ToString(model.discountrate);
                    // cmbInvoiceCur.SelectedItem= model.CurrNameInv;
                    if (model.CurrNameInv != null) cmbInvoiceCur.SelectedValue = model.CurrNameInv;
                    // cmbCurrenyt.SelectedItem=model.CurrNameQuo;
                    if (model.CurrNameQuo != null) cmbCurrenyt.SelectedValue = model.CurrNameQuo;

                    Note n1 = new Note();
                    try { n1 = db.Notes.Where(a => a.ID == model.Note.ID).FirstOrDefault(); } catch { }
                    if (model.Note == null)
                    {
                        txtnotes.Text = n1.Note_name;
                        n1 = model.Note;
                    }
                    else
                    {
                        txtnotes.Text = n1.Note_name;
                    }
                    if (model.SupplierNoteID == null)
                    {
                        Note n = new Note();
                        txtAccountNotes.Text = n.Note_name;
                        //n.ID=model.SupplierNoteID;
                    }
                    else
                    {
                        Note n = db.Notes.Where(a => a.ID == model.SupplierNoteID).FirstOrDefault();
                        txtAccountNotes.Text = n.Note_name;
                    }

                    SupplierBank n2 = new SupplierBank();
                    try { n2 = db.SupplierBanks.Where(a => a.ID == model.SupplierBank.ID).FirstOrDefault(); } catch { }
                    if (model.SupplierBank == null)
                    {
                        cmbBankName.SelectedItem = n2.bankname;
                        n2 = model.SupplierBank;
                    }
                    else
                    {
                        cmbBankName.SelectedItem = n2.bankname;
                    }
                    txtBankCode.Text = model.branchcode;
                    txtBankCode.Text = model.accountnumber;
                    txtBankIban.Text = model.iban;

                }
            }
        }
    }

}