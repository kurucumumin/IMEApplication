using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.Account.Services;
using LoginForm.DataSet;
using LoginForm.Services;

namespace LoginForm
{
    public partial class frmTax : Form
    {
        #region Public Variables

        
        IMEEntities IME = new IMEEntities();
        bool isDefault = false;
        int decTaxId;
        int inNarrationCount;
        string strTaxName;
        decimal decTaxIdForEdit;
        decimal decIdForOtherForms;
        decimal decLedgerId = 0;

        #endregion

        #region Functions

        public frmTax()
        {
            InitializeComponent();
        }

        public void DecimalValidation(object sender, KeyPressEventArgs e, bool isNegativeFiled)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            if (e.KeyChar == 46)
            {
                if (txt.Text.Contains(".") && txt.SelectionStart != 0)
                {
                    e.Handled = true;
                }
                else
                {
                    if (txt.Text == "" || txt.SelectionStart == 0)
                    {
                        txt.Clear();
                        txt.Text = "0.";
                        txt.SelectionStart = txt.Text.Length;
                    }
                    else
                    {
                        txt.Text = txt.Text + ".";
                        txt.SelectionStart = txt.Text.Length;
                    }
                }
            }
            else if (e.KeyChar == 45 && (isNegativeFiled))
            {
                if (txt.Text.Contains("-") && txt.SelectionStart != 0)
                {
                    e.Handled = true;
                }
                else
                {
                    txt.Clear();
                    txt.Text = "-";
                    txt.SelectionStart = txt.Text.Length;
                }
            }
        }

        public void Clear()
        {
            try
            {
                txtTaxName.Clear();
                txtRate.Clear();
                txtNarration.Clear();
                dgvTaxSelection.Enabled = false;
                cmbApplicableFor.SelectedIndex = -1;
                cmbCalculationMode.SelectedIndex = -1;
                cmbCalculationMode.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
                cbxActive.Checked = true;
                dgvTaxSearch.ClearSelection();
                TaxSelectionGridFill();
                decLedgerId = 0;
                txtTaxName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void SearchClear()
        {
            try
            {
                txtTaxNameSearch.Clear();
                cmbActiveSearch.SelectedIndex = 0;
                cmbApplicableForSearch.SelectedIndex = 0;
                cmbCalculationModeSearch.SelectedIndex = 0;
                txtTaxNameSearch.Focus();
                TaxSearchGridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC3:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void SaveFunction()
        {
            if (IME.Taxes.Where(a => a.taxName == txtTaxName.Text.Trim()).FirstOrDefault() == null)
            {
                Tax infoTax = new Tax();
                //TaxDetail spTax = new TaxDetail();

                infoTax.taxName = txtTaxName.Text.Trim();
                infoTax.Rate = Convert.ToDecimal(txtRate.Text.ToString());
                infoTax.ApplicationOn = cmbApplicableFor.SelectedItem.ToString();
                if (cmbCalculationMode.Enabled != true)
                {
                    infoTax.CalculatingMode = null;
                }
                else
                {
                    infoTax.CalculatingMode = cmbCalculationMode.SelectedItem.ToString();
                }
                infoTax.narration = txtNarration.Text.Trim();
                if (cbxActive.Checked)
                {
                    infoTax.isActive = true;
                }
                else
                {
                    infoTax.isActive = false;
                }

                IME.Taxes.Add(infoTax);
                IME.SaveChanges();
            }
            else
            {
                MessageBox.Show("Tax or ledger already exist");
            }
        }
        /// <summary>
        /// update function
        /// </summary>
        public void EditFunction()
        {

            //TaxInfo infoTax = new TaxInfo();
            //TaxSP spTax = new TaxSP();
            //TaxDetailsInfo infoTaxDetails = new TaxDetailsInfo();
            //TaxDetailsSP spTaxDetails = new TaxDetailsSP();

            if (txtTaxName.Text.ToString() != strTaxName)
            {
                if (IME.Taxes.Where(a => a.TaxID == decTaxId).FirstOrDefault() == null)
                {
                    //TaxEDIT
                    Tax tax = IME.Taxes.Where(a => a.taxName == txtTaxName.Text).FirstOrDefault();
                    tax.TaxID = decTaxId;
                    tax.taxName = txtTaxName.Text.Trim();
                    tax.Rate = Convert.ToDecimal(txtRate.Text.ToString());
                    tax.ApplicationOn = cmbApplicableFor.SelectedItem.ToString();
                    if (cmbCalculationMode.Enabled != true)
                    {
                        tax.CalculatingMode = string.Empty;
                    }
                    else
                    {
                        tax.CalculatingMode = cmbCalculationMode.SelectedItem.ToString();
                    }
                    tax.narration = txtNarration.Text.Trim();
                    if (cbxActive.Checked)
                    {
                        tax.isActive = true;
                    }
                    else
                    {
                        tax.isActive = false;
                    }
                    IME.SaveChanges();
                    //
                    //-- Delete And Add Tax details --//
                    var taxDetail = IME.TaxDetails.Where(a => a.taxID == decTaxId).FirstOrDefault();
                    if (taxDetail != null) { IME.TaxDetails.Remove(taxDetail); }
                    if (dgvTaxSelection.RowCount > 0)
                    {
                        bool isOk = false;
                        foreach (DataGridViewRow dgvRow in dgvTaxSelection.Rows)
                        {
                            isOk = Convert.ToBoolean(dgvRow.Cells["dgvcbxSelect"].Value);
                            if (isOk)
                            {

                                taxDetail = new TaxDetail();
                                taxDetail.taxID = decTaxId;
                                taxDetail.SelectedtaxID = Convert.ToInt32(dgvRow.Cells["dgvtxtTaxId"].Value.ToString());//dgvRow.Cells[0].Value.ToString();
                                taxDetail.taxDate = Convert.ToDateTime(IME.CurrentDate().First());
                                IME.TaxDetails.Add(taxDetail);
                            }
                        }
                    }
                    //GOTO Ledger
                    //LedgerEdit();
                    MessageBox.Show("Update is Successful");
                    Clear();
                }
                else
                {
                    MessageBox.Show(" Tax or ledger already exist");
                    txtTaxName.Focus();
                }
            }
            else
            {
                if (IME.Taxes.Where(a => a.TaxID == decTaxId).FirstOrDefault() == null)
                {
                    //TaxEDIT
                    Tax tax = IME.Taxes.Where(a => a.taxName == txtTaxName.Text).FirstOrDefault();
                    tax.TaxID = decTaxId;
                    tax.taxName = txtTaxName.Text.Trim();
                    tax.Rate = Convert.ToDecimal(txtRate.Text.ToString());
                    tax.ApplicationOn = cmbApplicableFor.SelectedItem.ToString();
                    if (cmbCalculationMode.Enabled != true)
                    {
                        tax.CalculatingMode = string.Empty;
                    }
                    else
                    {
                        tax.CalculatingMode = cmbCalculationMode.SelectedItem.ToString();
                    }
                    tax.narration = txtNarration.Text.Trim();
                    if (cbxActive.Checked)
                    {
                        tax.isActive = true;
                    }
                    else
                    {
                        tax.isActive = false;
                    }
                    IME.SaveChanges();
                    //
                }
                //-- Delete And Add Tax details --//
                var taxDetail = IME.TaxDetails.Where(a => a.taxID == decTaxId).FirstOrDefault();
                if (taxDetail != null) { IME.TaxDetails.Remove(taxDetail); }
                if (dgvTaxSelection.RowCount > 0)
                {
                    bool isOk = false;
                    foreach (DataGridViewRow dgvRow in dgvTaxSelection.Rows)
                    {
                        isOk = Convert.ToBoolean(dgvRow.Cells["dgvcbxSelect"].Value);
                        if (isOk)
                        {

                            taxDetail = new TaxDetail();
                            taxDetail.taxID = decTaxId;
                            taxDetail.SelectedtaxID = Convert.ToInt32(dgvRow.Cells["dgvtxtTaxId"].Value.ToString());//dgvRow.Cells[0].Value.ToString();
                            taxDetail.taxDate = Convert.ToDateTime(IME.CurrentDate().First());
                            IME.TaxDetails.Add(taxDetail);
                        }
                    }
                }

                //GOTO Ledger
                //LedgerEdit();
                MessageBox.Show("Update is Successful");
                Clear();
            }
        }
        /// <summary>
        /// checking checking existance entries for save or edit function
        /// </summary>
        public void SaveOrEditMessage()
        {
            //create ledger for the tax
            string strTaxNameForLedger = string.Empty;
            strTaxNameForLedger = txtTaxName.Text;


            if (btnSave.Text == "Save")
            {
                if (IME.AccountLedgers.Where(a => a.ledgerName == strTaxNameForLedger).FirstOrDefault() == null)
                {
                    SaveFunction();
                    TaxSelectionGridFill();
                    TaxSearchGridFill();
                    MessageBox.Show("Ledger Added Successfully");

                }
                else
                {
                    MessageBox.Show("Cannot save. Ledger already exists");
                }
            }
            else
            {
                if (IME.AccountLedgers.Where(a => a.ledgerName == strTaxNameForLedger).Where(b => b.ledgerId == decLedgerId).FirstOrDefault() == null)
                {
                    EditFunction();
                    TaxSelectionGridFill();
                    TaxSearchGridFill();
                    MessageBox.Show("Ledger Edited Successfully");
                }
                else
                {
                    MessageBox.Show("Cannot save. Ledger already exists");
                }
            }


        }
        /// <summary>
        /// check invalid entries for save or update function
        /// </summary>
        public void SaveOrEdit()
        {
            isDefault = false;
            if (txtTaxName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter tax name");
                txtTaxName.Focus();
            }
            else if (txtRate.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter rate");
                txtRate.Focus();
            }
            else if (cmbApplicableFor.SelectedIndex == -1)
            {
                MessageBox.Show("Select applicable for");
                cmbApplicableFor.Focus();
            }
            else if (cmbCalculationMode.Enabled)
            {
                if (cmbCalculationMode.SelectedIndex == -1)
                {
                    MessageBox.Show("Select calculation mode");
                    cmbCalculationMode.Focus();
                }
                else if (dgvTaxSelection.Enabled)
                {
                    int inRowCount = dgvTaxSelection.RowCount;
                    for (int i = 0; i <= inRowCount - 1; i++)
                    {
                        if (dgvTaxSelection.Rows[i].Cells["dgvcbxSelect"].Value != null && dgvTaxSelection.Rows[i].Cells["dgvcbxSelect"].Value.ToString() != "False")
                        {
                            isDefault = Convert.ToBoolean(dgvTaxSelection.Rows[i].Cells["dgvcbxSelect"].Value.ToString());
                        }
                    }
                    if (isDefault == false)
                    {
                        MessageBox.Show("Select tax items");
                        dgvTaxSelection.Focus();
                    }
                    else
                    {

                        SaveOrEditMessage();
                    }
                }
                else
                {
                    SaveOrEditMessage();
                }
            }
            else
            {
                SaveOrEditMessage();
            }
        }
        /// <summary>
        /// tax Selection grid fill function
        /// </summary>
        public void TaxSelectionGridFill()
        {
            try
            {
                TaxSP spTax = new TaxSP();
                DataTable dtblTax = new DataTable();
                dtblTax = spTax.TaxViewAllForTaxSelection();
                dgvTaxSelection.DataSource = dtblTax;
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// tax search grid fill
        /// </summary>
        public void TaxSearchGridFill()
        {
            string strCmbActiveSearchText = string.Empty;
            try
            {
                DataTable dtblTaxSearch = new DataTable();
                TaxSP spTax = new TaxSP();
                if (cmbActiveSearch.Text == "Yes")
                {
                    strCmbActiveSearchText = "True";
                }
                else if (cmbActiveSearch.Text == "No")
                {
                    strCmbActiveSearchText = "False";
                }
                else
                {
                    strCmbActiveSearchText = "All";
                }
                dtblTaxSearch = spTax.TaxSearch(txtTaxNameSearch.Text.Trim(), cmbApplicableForSearch.Text, cmbCalculationModeSearch.Text, strCmbActiveSearchText);
                dgvTaxSearch.DataSource = dtblTaxSearch;
                int inRowCount = dgvTaxSearch.RowCount;
                for (int i = 0; i <= inRowCount - 1; i++)
                {
                    if (dgvTaxSearch.Rows[i].Cells["dgvtxtActive"].Value.ToString() == "1")
                    {
                        dgvTaxSearch.Rows[i].Cells["dgvtxtActive"].Value = "Yes";
                    }
                    if (dgvTaxSearch.Rows[i].Cells["dgvtxtActive"].Value.ToString() == "0")
                    {
                        dgvTaxSearch.Rows[i].Cells["dgvtxtActive"].Value = "No";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// fill the curresponding details for update
        /// </summary>
        public void TaxSelectionFillForUpdate()
        {
            try
            {
                int inRowCount = dgvTaxSelection.RowCount;
                for (int i = 0; i < inRowCount; i++)
                {
                    dgvTaxSelection.Rows[i].Cells["dgvcbxSelect"].Value = false;
                }
                decTaxId = Convert.ToInt32(dgvTaxSearch.CurrentRow.Cells["dgvtxtTaxIdSearch"].Value.ToString());
                Tax infoTax = new Tax();
                TaxSP spTax = new TaxSP();
                TaxDetail infoTaxDetails = new TaxDetail();
                TaxDetailsSP spTaxDetails = new TaxDetailsSP();
                infoTax = spTax.TaxView(decTaxId);
                txtTaxName.Text = infoTax.taxName;
                txtRate.Text = infoTax.Rate.ToString();
                cmbApplicableFor.Text = infoTax.ApplicationOn;
                cmbCalculationMode.Text = infoTax.CalculatingMode;
                txtNarration.Text = infoTax.narration;
                if (infoTax.isActive.ToString() == "True")
                {
                    cbxActive.Checked = true;
                }
                else
                {
                    cbxActive.Checked = false;
                }
                strTaxName = infoTax.taxName;
                decTaxIdForEdit = infoTax.TaxID;
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
                DataTable dtbl = new DataTable();
                dtbl = spTax.TaxIdForTaxSelectionUpdate(decTaxId);
                foreach (DataRow dr in dtbl.Rows)
                {
                    string strTaxId = dr["selectedtaxId"].ToString();
                    for (int i = 0; i < inRowCount; i++)
                    {
                        if (dgvTaxSelection.Rows[i].Cells["dgvtxtTaxId"].Value.ToString() == strTaxId)
                        {
                            dgvTaxSelection.Rows[i].Cells["dgvcbxSelect"].Value = true;
                        }
                    }
                }

                AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                decLedgerId = spAccountLedger.AccountLedgerIdGetByName(txtTaxName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ///// <summary>
        ///// fill the curresponding details for update
        ///// </summary>
        //public void TaxSelectionFillForUpdate()
        //{
        //    int inRowCount = dgvTaxSelection.RowCount;
        //    for (int i = 0; i < inRowCount; i++)
        //    {
        //        dgvTaxSelection.Rows[i].Cells["dgvcbxSelect"].Value = false;
        //    }
        //    decTaxId = Convert.ToInt32(dgvTaxSearch.CurrentRow.Cells["dgvtxtTaxIdSearch"].Value.ToString());
        //    Tax infoTax = IME.Taxes.Where(a => a.TaxID == decTaxId).FirstOrDefault();
        //    if (infoTax != null)
        //    {

        //    }

        //    //TaxInfo infoTax = new TaxInfo();
        //    //TaxSP spTax = new TaxSP();
        //    //TaxDetailsInfo infoTaxDetails = new TaxDetailsInfo();
        //    //TaxDetailsSP spTaxDetails = new TaxDetailsSP();
        //    //infoTax = spTax.TaxView(decTaxId);
        //    txtTaxName.Text = infoTax.taxName;
        //    txtRate.Text = infoTax.Rate.ToString();
        //    cmbApplicableFor.Text = infoTax.ApplicationOn;
        //    cmbCalculationMode.Text = infoTax.CalculatingMode;
        //    txtNarration.Text = infoTax.narration;
        //    if (infoTax.isActive.ToString() == "True")
        //    {
        //        cbxActive.Checked = true;
        //    }
        //    else
        //    {
        //        cbxActive.Checked = false;
        //    }
        //    strTaxName = infoTax.taxName;
        //    decTaxIdForEdit = infoTax.TaxID;
        //    btnSave.Text = "Update";
        //    btnDelete.Enabled = true;
        //    IME.SaveChanges();
        //    var selectedtaxID = IME.TaxDetails.Where(a => a.taxID == decTaxId).Select(b => b.SelectedtaxID).ToList();
        //    foreach (var dr in selectedtaxID)
        //    {
        //        string strTaxId = dr.ToString();
        //        for (int i = 0; i < inRowCount; i++)
        //        {
        //            if (dgvTaxSelection.Rows[i].Cells["dgvtxtTaxId"].Value.ToString() == strTaxId)
        //            {
        //                dgvTaxSelection.Rows[i].Cells["dgvcbxSelect"].Value = true;
        //            }
        //        }
        //    }
        //    AccountLedger al = new AccountLedger();
        //    decLedgerId = IME.AccountLedgers.Where(a => a.ledgerName == txtTaxName.Text).FirstOrDefault().ledgerId;


        //}
        /// <summary>
        /// delete function
        /// </summary>
        public void Delete()
        {
            Tax infoTax = new Tax();
            TaxDetail taxDetail = new TaxDetail();
            bool isExist = false;
            if (IME.Taxes.Where(a => a.TaxID == decTaxId).FirstOrDefault() != null) isExist = true;
            if (!isExist)
            {

                bool isDeletedTax = true;
                try
                {
                    Tax tax = IME.Taxes.Where(a => a.TaxID == decTaxId).FirstOrDefault();
                    IME.Taxes.Remove(tax);
                }
                catch
                {
                    isDeletedTax = false;
                }
                if (isDeletedTax == false)
                {
                    MessageBox.Show("You can't delete,reference exist");
                }
                else
                {
                    var taxdetail = IME.TaxDetails.Where(a => a.taxID == decTaxId).ToList();
                    foreach (var item in taxdetail)
                    {
                        IME.TaxDetails.Remove(item);
                        IME.SaveChanges();
                    }
                    var accountLedger = IME.AccountLedgers.Where(a => a.ledgerId == decLedgerId).ToList();
                    foreach (var item in accountLedger)
                    {
                        IME.AccountLedgers.Remove(item);
                        IME.SaveChanges();
                    }

                    MessageBox.Show("Tax is Deleted successfully ");
                    TaxSearchGridFill();
                    TaxSelectionGridFill();
                    Clear();
                    SearchClear();
                }
            }
            else
            {
                MessageBox.Show("You can't delete,reference exist");
            }
        }

        public void CreateLedger()
        {
            AccountLedger accountLedger = new AccountLedger();
            accountLedger.accountGroupID = 20;
            accountLedger.ledgerName = txtTaxName.Text;
            accountLedger.openingBalance = 0;
            accountLedger.isDefault = false;
            accountLedger.crOrDr = "Cr";
            accountLedger.narration = string.Empty;
            accountLedger.mailingName = txtTaxName.Text;
            accountLedger.address = string.Empty;
            accountLedger.phone = string.Empty;
            accountLedger.mobile = string.Empty;
            accountLedger.email = string.Empty;
            accountLedger.creditPeriod = 0;
            accountLedger.creditLimit = 0;
            accountLedger.pricinglevelId = 0;
            accountLedger.billByBill = false;
            accountLedger.tin = string.Empty;
            accountLedger.cst = string.Empty;
            accountLedger.pan = string.Empty;
            accountLedger.routeId = 1;
            accountLedger.bankAccountNumber = string.Empty;
            accountLedger.branchName = string.Empty;
            accountLedger.branchCode = string.Empty;
            accountLedger.extraDate = Convert.ToDateTime(IME.CurrentDate().First());
            accountLedger.areaId = 1;
            IME.AccountLedgers.Add(accountLedger);
            IME.SaveChanges();
        }
        /// <summary>
        /// editing the ledger on update
        /// </summary>
        public void LedgerEdit()
        {
            AccountLedger accountLedger = IME.AccountLedgers.Where(a => a.ledgerId == decLedgerId).FirstOrDefault();
            if (accountLedger != null)
            {
                accountLedger.accountGroupID = 20;
                accountLedger.ledgerName = txtTaxName.Text;
                accountLedger.openingBalance = 0;
                accountLedger.isDefault = false;
                accountLedger.crOrDr = "Cr";
                accountLedger.narration = string.Empty;
                accountLedger.mailingName = txtTaxName.Text;
                accountLedger.address = string.Empty;
                accountLedger.phone = string.Empty;
                accountLedger.mobile = string.Empty;
                accountLedger.email = string.Empty;
                accountLedger.creditPeriod = 0;
                accountLedger.creditLimit = 0;
                accountLedger.pricinglevelId = 0;
                accountLedger.billByBill = false;
                accountLedger.tin = string.Empty;
                accountLedger.cst = string.Empty;
                accountLedger.pan = string.Empty;
                accountLedger.routeId = 1;
                accountLedger.bankAccountNumber = string.Empty;
                accountLedger.branchName = string.Empty;
                accountLedger.branchCode = string.Empty;
                accountLedger.extraDate = Convert.ToDateTime(IME.CurrentDate().First());
                accountLedger.areaId = 1;
                IME.SaveChanges();
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTax_Load(object sender, EventArgs e)
        {
            try
            {
                TaxSelectionGridFill();
                Clear();
                cmbActiveSearch.SelectedIndex = 0;
                cmbApplicableForSearch.SelectedIndex = 0;
                cmbCalculationModeSearch.SelectedIndex = 0;
                TaxSearchGridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC14:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// form keydown for save,update and delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTax_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
                {
                    if (dgvTaxSelection.Focused)
                    {
                        txtNarration.Focus();
                    }
                    btnSave_Click(sender, e);
                }
                if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control) //Delete
                {
                    if (btnDelete.Enabled)
                    {
                        btnDelete_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC15:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// save button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // TO DO TAX CheckUserPrivilege
            //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, this.Name, btnSave.Text))
            //    {
            SaveOrEdit();
            txtRate.Focus();
            //}
            //else
            //{
            //    MessageBox.Show()
            //}

        }
        /// <summary>
        /// clear button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                TaxSearchGridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// close button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        /// <summary>
        /// search clear button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// combobox tax applicable index changed for calculating mode selection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbApplicableFor_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cmbApplicableFor.Text == "Bill")
                {
                    cmbCalculationMode.Enabled = true;
                }
                else
                {
                    cmbCalculationMode.Enabled = false;
                    cmbCalculationMode.SelectedIndex = -1;
                    int inRowCount = dgvTaxSelection.RowCount;
                    for (int i = 0; i <= inRowCount - 1; i++)
                    {
                        dgvTaxSelection.Rows[i].Cells["dgvcbxSelect"].Value = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// to make enable the selection tax grid if the condition is satisfied
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCalculationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCalculationMode.Text == "Tax Amount")
                {
                    dgvTaxSelection.Enabled = true;
                }
                else
                {
                    dgvTaxSelection.Enabled = false;
                    int inRowCount = dgvTaxSelection.RowCount;
                    for (int i = 0; i <= inRowCount - 1; i++)
                    {
                        dgvTaxSelection.Rows[i].Cells["dgvcbxSelect"].Value = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC22:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// rate keypress for decimal validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalValidation(sender, e, false);
        }
        /// <summary>
        /// delete button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Selected tax will be deleted! Do you confirm?", "Delete Tax", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {

                Delete();
                txtTaxName.Focus();
            }

        }
        /// <summary>
        /// grid binding complete event for clear the selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTaxSelection_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvTaxSelection.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC25:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// cell doublr click for update the items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTaxSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    TaxSelectionFillForUpdate();
                    txtTaxName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Form closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTax_FormClosing(object sender, FormClosingEventArgs e)
        {

            //if (frmProductCreationObj != null)
            //{
            //    frmProductCreationObj.ReturnFromTaxForm(decIdForOtherForms);
            //    groupBox2.Enabled = true;
            //    frmProductCreationObj.Enabled = true;
            //}

        }
        #endregion

        #region Navigation
        /// <summary>
        /// for enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTaxName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRate.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC28:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbApplicableFor.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtRate.Text == string.Empty || txtRate.SelectionStart == 0)
                    {
                        txtTaxName.SelectionStart = 0;
                        txtTaxName.SelectionLength = 0;
                        txtTaxName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC29:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter key and backspace for navigation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbApplicableFor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbCalculationMode.Enabled)
                    {
                        cmbCalculationMode.Focus();
                    }
                    else if (dgvTaxSelection.Enabled)
                    {
                        dgvTaxSelection.Focus();
                    }
                    else
                    {
                        txtNarration.Focus();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbApplicableFor.Text == string.Empty || cmbApplicableFor.SelectionStart == 0)
                    {
                        txtRate.SelectionStart = 0;
                        txtRate.SelectionLength = 0;
                        txtRate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC30:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCalculationMode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvTaxSelection.Enabled)
                    {
                        dgvTaxSelection.Focus();
                    }
                    else
                    {
                        txtNarration.Focus();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbCalculationMode.Text == string.Empty || cmbCalculationMode.SelectionStart == 0)
                    {
                        cmbApplicableFor.SelectionStart = 0;
                        cmbApplicableFor.SelectionLength = 0;
                        cmbApplicableFor.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC31:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTaxSelection_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNarration.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbCalculationMode.Enabled)
                    {
                        cmbCalculationMode.SelectionStart = 0;
                        cmbCalculationMode.SelectionLength = 0;
                        cmbCalculationMode.Focus();
                    }
                    else
                    {
                        cmbApplicableFor.SelectionStart = 0;
                        cmbApplicableFor.SelectionLength = 0;
                        cmbApplicableFor.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC32:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        if (dgvTaxSelection.Enabled)
                        {
                            dgvTaxSelection.Focus();
                        }
                        else if (cmbCalculationMode.Enabled)
                        {
                            cmbCalculationMode.SelectionStart = 0;
                            cmbCalculationMode.SelectionLength = 0;
                            cmbCalculationMode.Focus();
                        }
                        else
                        {
                            cmbApplicableFor.SelectionStart = 0;
                            cmbApplicableFor.SelectionLength = 0;
                            cmbApplicableFor.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC33:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                inNarrationCount = 0;
                txtNarration.Text = txtNarration.Text.Trim();
                if (txtNarration.Text == string.Empty)
                {
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
                    txtNarration.Focus();
                }
                else
                {
                    txtNarration.SelectionStart = txtNarration.Text.Length;
                    txtNarration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC34:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// get count of textbox narration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    inNarrationCount++;
                    if (inNarrationCount == 2)
                    {
                        inNarrationCount = 0;
                        cbxActive.Focus();
                    }
                }
                else
                {
                    inNarrationCount = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC35:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtNarration.Focus();
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC36:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    cbxActive.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC37:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter  navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTaxNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbApplicableForSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC38:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbApplicableForSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCalculationModeSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbApplicableForSearch.Text == string.Empty || cmbApplicableForSearch.SelectionStart == 0)
                    {
                        txtTaxNameSearch.SelectionStart = 0;
                        txtTaxNameSearch.SelectionLength = 0;
                        txtTaxNameSearch.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC39:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCalculationModeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbActiveSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbCalculationModeSearch.Text == string.Empty || cmbCalculationModeSearch.SelectionStart == 0)
                    {
                        cmbApplicableForSearch.SelectionStart = 0;
                        cmbApplicableForSearch.SelectionLength = 0;
                        cmbApplicableForSearch.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC40:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbActiveSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbActiveSearch.Text == string.Empty || cmbActiveSearch.SelectionStart == 0)
                    {
                        cmbCalculationModeSearch.SelectionStart = 0;
                        cmbCalculationModeSearch.SelectionLength = 0;
                        cmbCalculationModeSearch.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC41:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClearSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    cmbActiveSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC42:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvTaxSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    btnSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC43:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// for enter and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTaxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    cmbActiveSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TC44:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion




    }
}