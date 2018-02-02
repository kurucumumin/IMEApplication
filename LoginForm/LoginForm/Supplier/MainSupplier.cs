using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LoginForm.Supplier
{
    public partial class MainSupplier : Form
    {
        DataSet.Supplier model = new DataSet.Supplier();
        public MainSupplier()
        {
            InitializeComponent();
        }

        private void MainSupplier_Load(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();

            #region ComboboxFiller
            cmbAcountMethod.DataSource = IME.PaymentMethods.ToList();
            cmbAcountMethod.DisplayMember = "Payment";
            cmbAcountMethod.ValueMember = "ID";

            cmbAcountRep.DataSource = IME.Workers.ToList();
            cmbAcountRep.DisplayMember = "NameLastName";
            cmbAcountRep.ValueMember = "WorkerID";

            cmbAcountTerms.DataSource = IME.PaymentTerms.OrderBy(p => p.timespan).ToList();
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

            cmbdepartman.DataSource = IME.SupplierDepartments.ToList();
            cmbdepartman.DisplayMember = "departmentname";
            cmbdepartman.ValueMember = "ID";

            cmblanguage.DataSource = IME.Languages.ToList();
            cmblanguage.DisplayMember = "languagename";
            cmblanguage.ValueMember = "ID";

            cmbposition.DataSource = IME.SupplierTitles.ToList();
            cmbposition.DisplayMember = "titlename";
            cmbposition.ValueMember = "ID";

            cmbBankName.DataSource = IME.SupplierBanks.ToList();
            cmbBankName.DisplayMember = "bankname";
            cmbBankName.ValueMember = "ID";

            cmbcounrty.DataSource = IME.Countries.ToList();
            cmbcounrty.DisplayMember = "Country_name";
            cmbcounrty.ValueMember = "ID";


            #endregion

            Clear();
            PopulateDataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record ?","Deleted",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                using (IMEEntities db = new IMEEntities())
                {
                    var entry = db.Entry(model);
                    if (entry.State==EntityState.Detached)
                    {
                        db.Suppliers.Attach(model);
                    }
                    db.Suppliers.Remove(model);
                    db.SaveChanges();
                    PopulateDataGridView();
                    Clear();
                    MessageBox.Show("Deleted Succesfully");
                }
            }
        }

        void Clear()
        {
            txtAccountNotes.Text = txtBankCode.Text = txtBankIban.Text = txtBankNumber.Text = txtcode.Text = txtCompanyAddress.Text = txtContactAddress.Text = txtContactfax.Text = txtContactMail.Text = txtContactMobile.Text = txtContactName.Text = txtContactNotes.Text = txtContactPhone.Text = txtdiscount.Text = txtExtNumber.Text = txtfax.Text = txtname.Text = txtnotes.Text = txtphone.Text = txtpobox.Text = txtpost.Text = txtsearch.Text = txtTaxNumber.Text = txtTaxOffice.Text = txtweb.Text = "";

            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            model.ID = "0";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();

            model.s_name = txtname.Text.Trim();
            model.ID = txtcode.Text;
            // model.representaryID = ((Worker)(cmbrepresentative).SelectedItem).WorkerID;
            int s_rep1ID = ((Worker)(cmbrepresentative).SelectedItem).WorkerID; model.representaryID = s_rep1ID;
            model.taxoffice = txtTaxOffice.Text;
            model.taxnumber = Convert.ToInt32(txtTaxNumber.Text);
            //model.accountrepresentaryID= ((Worker)(cmbAcountRep).SelectedItem).WorkerID;
            int s_repAcoID = ((Worker)(cmbAcountRep).SelectedItem).WorkerID; model.accountrepresentaryID = s_repAcoID;
            //model.payment_termID= ((PaymentTerm)(cmbAcountTerms).SelectedItem).ID;
            int s_PayTermID = ((PaymentTerm)(cmbAcountTerms).SelectedItem).ID; model.payment_termID = s_PayTermID;
            //model.paymentmethodID= ((PaymentMethod)(cmbAcountMethod).SelectedItem).ID;
            int s_PayMethodID = ((PaymentMethod)(cmbAcountMethod).SelectedItem).ID; model.paymentmethodID = s_PayMethodID;
            model.discountrate = Convert.ToDecimal(txtdiscount.Text);
           // model.CurrNameInv = ((Currency)(cmbInvoiceCur).SelectedItem).currencyName;
            string s_CurrNameInv = ((Currency)(cmbInvoiceCur).SelectedItem).currencyName; model.CurrNameInv = s_CurrNameInv;
            //model.CurrNameQuo =((Currency)(cmbCurrenyt).SelectedItem).currencyName;
            string s_CurrNameQuo = ((Currency)(cmbCurrenyt).SelectedItem).currencyName;  model.CurrNameQuo = s_CurrNameQuo;

            //Note n = new Note();
            //try { n = IME.Notes.Where(a => a.ID == model.SupplierNoteID).FirstOrDefault(); } catch { }
            //if (model.SupplierNoteID == null)
            //{
            //    n.Note_name = txtAccountNotes.Text;
            //    model.SupplierNoteID = n.ID;
            //}
            //else
            //{
            //    n.Note_name = txtAccountNotes.Text;
            //}
            model.Note.Note_name= txtnotes.Text;
            model.SupplierNoteID= txtAccountNotes.Text;
            string s_bankName= ((SupplierBank)(cmbBankName).SelectedItem).bankname; model.SupplierBank.bankname = s_bankName;
            model.branchcode = txtBankCode.Text;
            model.accountnumber = txtBankNumber.Text;
            model.iban = txtBankIban.Text;
            

            using (IMEEntities db = new IMEEntities())
            {
                if (model.ID == "0")//Insert
                {
                    IME.Suppliers.Add(model);
                }
                else//Update    
                {
                    IME.Entry(model).State = EntityState.Modified;
                }
                IME.SaveChanges();
            }
            Clear();
            PopulateDataGridView();
            MessageBox.Show("save succesfully.");
        }

        void PopulateDataGridView()
        {
            dgSupplier.AutoGenerateColumns = false;

            using (IMEEntities db = new IMEEntities())
            {
                dgSupplier.DataSource = db.Suppliers.ToList<DataSet.Supplier>();
            }

        }

        private void dgSupplier_DoubleClick(object sender, EventArgs e)
        {
            if (dgSupplier.CurrentRow.Index !=-1)
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
                    txtdiscount.Text=Convert.ToString(model.discountrate);
                   // cmbInvoiceCur.SelectedItem= model.CurrNameInv;
                    if (model.CurrNameInv != null) cmbInvoiceCur.SelectedValue = model.CurrNameInv;
                   // cmbCurrenyt.SelectedItem=model.CurrNameQuo;
                    if (model.CurrNameQuo != null) cmbCurrenyt.SelectedValue = model.CurrNameQuo;

                    Note n1 = new Note();
                    try { n1 = db.Notes.Where(a => a.ID == model.Note.ID).FirstOrDefault(); } catch { }
                    if (model.Note == null)
                    {
                        txtnotes.Text=n1.Note_name;
                        n1= model.Note;
                    }
                    else
                    {
                        txtnotes.Text=n1.Note_name;
                    }
                    if (model.SupplierNoteID == null)
                    {
                        Note n = new Note();
                        txtAccountNotes.Text=n.Note_name;
                        //n.ID=model.SupplierNoteID;
                    }
                    else
                    {
                        Note n = db.Notes.Where(a => a.ID == model.SupplierNoteID).FirstOrDefault();
                        txtAccountNotes.Text=n.Note_name;
                    }

                    SupplierBank n2 = new SupplierBank();
                    try { n2 = db.SupplierBanks.Where(a => a.ID == model.SupplierBank.ID).FirstOrDefault(); } catch { }
                    if (model.SupplierBank == null)
                    {
                        cmbBankName.SelectedItem=n2.bankname ;
                        n2=model.SupplierBank;
                    }
                    else
                    {
                        cmbBankName.SelectedItem=n2.bankname ;
                    }
                    txtBankCode.Text = model.branchcode;
                    txtBankCode.Text = model.accountnumber;
                    txtBankIban.Text = model.iban;
                }
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }
    }
}
