using LoginForm.Account.Services;
using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace LoginForm
{
    public partial class frmBankReconciliation : Form
    {
        #region Public Variables
        IMEEntities IME = new IMEEntities();
        #endregion
        #region Functions
        /// <summary>
        /// Create an instance of a frmBankReconciliation Class
        /// </summary>
        public frmBankReconciliation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Here reset the form
        /// </summary>
        public void clear()
        {
            try
            {
                bankAccountComboFill();
                cmbStatus.SelectedIndex = -1;
                /*-------date setting at the time of loading--------*/
                dtpStatementFrom.MinDate = (DateTime)Utils.getManagement().FinancialYear.fromDate;
                dtpStatementFrom.MaxDate = (DateTime)Utils.getManagement().FinancialYear.toDate;
                dtpStatementFrom.Value = Convert.ToDateTime(IME.CurrentDate().First());
                dtpStatrmentTo.MinDate = (DateTime)Utils.getManagement().FinancialYear.fromDate;
                dtpStatrmentTo.MaxDate = (DateTime)Utils.getManagement().FinancialYear.toDate;
                dtpStatrmentTo.Value = Convert.ToDateTime(IME.CurrentDate().First());
                /*--------------------------------------------------*/
                txtBalanceBankCr.Text = string.Empty;
                txtBalanceBankDr.Text = string.Empty;
                txtBalanceCompanyCr.Text = string.Empty;
                txtBalanceCompnyDr.Text = string.Empty;
                txtDifferenceCr.Text = string.Empty;
                txtDifferenceDr.Text = string.Empty;
                txtBalanceBankCr.Text = string.Empty;
                txtBalanceBankDr.Text = string.Empty;
                txtBalanceCompanyCr.Text = string.Empty;
                txtBalanceCompnyDr.Text = string.Empty;
                txtDifferenceCr.Text = string.Empty;
                txtDifferenceDr.Text = string.Empty;
                dgvBankReconciliation.Rows.Clear();
                BankReconciliationFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:1" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// BankAccount Combobox fill function
        /// </summary>
        public void bankAccountComboFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                TransactionsGeneralFill obj = new TransactionsGeneralFill();
                obj.CashOrBankComboFill(cmbBankAccount,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:2" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// BankReconciliation Grid Fill function
        /// </summary>
        public void BankReconciliationFill()
        {
            try
            {
                //BankReconciliationInfo infoBankReconciliation = new BankReconciliationInfo();
                BankReconciliationSP spBankReconciliation = new BankReconciliationSP();
                dgvBankReconciliation.Rows.Clear();
                DataTable dtblBank = new DataTable();
                if (cmbBankAccount.SelectedIndex > -1)
                {
                    if (cmbStatus.Text == "Reconciled")
                    {
                        
                        dtblBank = spBankReconciliation.BankReconciliationFillReconcile(Convert.ToDecimal(cmbBankAccount.SelectedValue.ToString()), Convert.ToDateTime(txtStatementFrom.Text), Convert.ToDateTime(txtStatementTo.Text));
                        if (dtblBank.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtblBank.Rows.Count; i++)
                            {
                                dgvBankReconciliation.Rows.Add();
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtSlNo"].Value = dtblBank.Rows[i]["Sl No"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtDate"].Value = dtblBank.Rows[i]["date"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtParticular"].Value = dtblBank.Rows[i]["ledgerName"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtVoucherType"].Value = dtblBank.Rows[i]["voucherTypeName"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtVoucherNo"].Value = dtblBank.Rows[i]["voucherNo"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtChequeNo"].Value = dtblBank.Rows[i]["chequeNo"].ToString();
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtChequeDate"].Value = dtblBank.Rows[i]["chequeDate"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtDeposit"].Value = dtblBank.Rows[i]["debit"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtWithdraw"].Value = dtblBank.Rows[i]["credit"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtStatementDate"].Value = dtblBank.Rows[i]["statementDate"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtLedgerPostingId"].Value = dtblBank.Rows[i]["ledgerPostingId"];
                            }
                        }
                    }
                    else
                    {
                        dtblBank = spBankReconciliation.BankReconciliationUnrecocile(Convert.ToDecimal(cmbBankAccount.SelectedValue.ToString()), Convert.ToDateTime(txtStatementFrom.Text), Convert.ToDateTime(txtStatementTo.Text));
                        if (dtblBank.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtblBank.Rows.Count; i++)
                            {
                                dgvBankReconciliation.Rows.Add();
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtSlNo"].Value = dtblBank.Rows[i]["Sl No"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtDate"].Value = dtblBank.Rows[i]["date"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtParticular"].Value = dtblBank.Rows[i]["ledgerName"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtVoucherType"].Value = dtblBank.Rows[i]["voucherTypeName"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtVoucherNo"].Value = dtblBank.Rows[i]["voucherNo"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtChequeNo"].Value = dtblBank.Rows[i]["chequeNo"].ToString();
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtChequeDate"].Value = dtblBank.Rows[i]["chequeDate"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtDeposit"].Value = dtblBank.Rows[i]["debit"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtWithdraw"].Value = dtblBank.Rows[i]["credit"];
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtStatementDate"].Value = string.Empty;
                                dgvBankReconciliation.Rows[i].Cells["dgvtxtLedgerPostingId"].Value = dtblBank.Rows[i]["ledgerPostingId"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:3" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Checking invalid entries for Save or Update and Save and Update function
        /// </summary>
        public void saveOrEdit()
        {
                BankReconciliation infoBankReconciliation = new BankReconciliation();
                BankReconciliationSP spBankReconciliation = new BankReconciliationSP();
                foreach (DataGridViewRow dgv in dgvBankReconciliation.Rows)
                {
                    if (dgv.Cells["dgvtxtStatementDate"].Value != null && Convert.ToDecimal(dgv.Cells["dgvtxtLedgerPostingId"].Value.ToString()) != 0 && dgv.Cells["dgvtxtStatementDate"].Value.ToString() != string.Empty)
                    {
                        infoBankReconciliation.ledgerPostingId = decimal.Parse(dgv.Cells["dgvtxtLedgerPostingId"].Value.ToString());
                        infoBankReconciliation.statementDate = Convert.ToDateTime((dgv.Cells["dgvtxtStatementDate"].Value.ToString()));
                    decimal LedgerPostingId = Convert.ToDecimal(dgv.Cells["dgvtxtLedgerPostingId"].Value.ToString());
                    decimal decReconcileId = IME.BankReconciliations.Where(a => a.ledgerPostingId == LedgerPostingId).FirstOrDefault().reconcileId;
                        if (decReconcileId != 0)
                        {
                            infoBankReconciliation.reconcileId = decReconcileId;
                            bankReconciliationEdit(infoBankReconciliation);
                        }
                        else
                            bankReconciliationAdd(infoBankReconciliation);
                    }
                    else
                    {
                        if (Convert.ToDecimal(dgv.Cells["dgvtxtLedgerPostingId"].Value.ToString()) != 0)
                        {
                        decimal LedgerPostingId = Convert.ToDecimal(dgv.Cells["dgvtxtLedgerPostingId"].Value.ToString());
                        decimal decReconcileId = IME.BankReconciliations.Where(a => a.ledgerPostingId == LedgerPostingId).FirstOrDefault().reconcileId;
                        if (decReconcileId != 0)
                            {
                                IME.BankReconciliations.Remove(IME.BankReconciliations.Where(a=>a.reconcileId== decReconcileId).FirstOrDefault());
                            }
                        }
                    }
                }
           
        }
        private void bankReconciliationAdd(BankReconciliation BankReconciliation)
        {
            BankReconciliation BankReconciliationnew = new BankReconciliation();
            BankReconciliationnew.ledgerPostingId = BankReconciliation.ledgerPostingId;
            BankReconciliationnew.statementDate = BankReconciliation.statementDate;
            IME.BankReconciliations.Add(BankReconciliationnew);
            IME.SaveChanges();
        }
        private void bankReconciliationEdit(BankReconciliation BankReconciliation)
        {
            BankReconciliation BankReconciliationnew = IME.BankReconciliations.Where(a=>a.reconcileId==BankReconciliation.reconcileId).FirstOrDefault();
            BankReconciliationnew.ledgerPostingId = BankReconciliation.ledgerPostingId;
            BankReconciliationnew.statementDate = BankReconciliation.statementDate;
            IME.SaveChanges();
        }

        public void FindTotal()
        {
            try
            {
                decimal DrCompany = 0;
                decimal CrCompany = 0;
                decimal DrDifference = 0;
                decimal DrBank = 0;
                decimal CrBank = 0;
                decimal CrDifference = 0;
                if (dgvBankReconciliation.RowCount > 0)
                {
                    foreach (DataGridViewRow dgvRow in dgvBankReconciliation.Rows)
                    {
                        DrCompany += Convert.ToDecimal(dgvRow.Cells["dgvtxtDeposit"].Value.ToString());
                        CrCompany += Convert.ToDecimal(dgvRow.Cells["dgvtxtWithdraw"].Value.ToString());
                        if (dgvRow.Cells["dgvtxtStatementDate"].Value != null && dgvRow.Cells["dgvtxtStatementDate"].Value.ToString() != string.Empty)
                        {
                            DrBank += Convert.ToDecimal(dgvRow.Cells["dgvtxtDeposit"].Value.ToString());
                            CrBank += Convert.ToDecimal(dgvRow.Cells["dgvtxtWithdraw"].Value.ToString());
                        }
                    }
                }
                txtBalanceCompnyDr.Text = DrCompany.ToString();
                txtBalanceCompanyCr.Text = CrCompany.ToString();
                txtBalanceBankDr.Text = DrBank.ToString();
                txtBalanceBankCr.Text = CrBank.ToString();
                DrDifference = DrCompany - DrBank;
                CrDifference = CrCompany - CrBank;
                txtDifferenceDr.Text = DrDifference.ToString();
                txtDifferenceCr.Text = CrDifference.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:5" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Events
        
        /// <summary>
        /// Form keydown for Quick Access for save and close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBankReconciliation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
                {
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:6" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Close button click
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
        /// When Form Bank Reconciliation Load call the clear function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBankReconciliation_Load(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:8" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Clear button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:9" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date time picker value change for setting the new date in textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStatementFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpStatementFrom.Value;
                this.txtStatementFrom.Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:10" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// text box StatementFrom leave for change date in date time picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStatementFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation obj = new DateValidation();
                obj.DateValidationFunction(txtStatementFrom);
                if (txtStatementFrom.Text == string.Empty)
                {
                    txtStatementFrom.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
                }
                dtpStatementFrom.Value = Convert.ToDateTime(txtStatementFrom.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:11" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date time picker StatrmentTo value change for setting the new date in textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStatrmentTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpStatrmentTo.Value;
                this.txtStatementTo.Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:12" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// text box StatementTo leave for change date in date time picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStatementTo_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation obj = new DateValidation();
                obj.DateValidationFunction(txtStatementTo);
                if (txtStatementTo.Text == string.Empty)
                {
                    txtStatementTo.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
                }
                dtpStatrmentTo.Value = Convert.ToDateTime(txtStatementTo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:13" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Save button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
              
                    if (dgvBankReconciliation.RowCount > 0)
                    {
                       if (Messages.SaveMessage())
                            {
                                saveOrEdit();
                                FindTotal();
                                Messages.SavedMessage();
                            }
                    }
                    else
                    {
                        Messages.InformationMessage("No row to save");
                    }
                    clear();
                
            
        }
        /// <summary>
        /// Search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBankAccount.SelectedIndex > -1)
                {
                    if (cmbStatus.SelectedIndex > -1)
                    {
                        if (dtpStatrmentTo.Value >= dtpStatementFrom.Value)
                        {
                            BankReconciliationFill();
                        }
                        else
                        {
                            Messages.InformationMessage("Statement date to less than statement date from");
                            txtStatementTo.Focus();
                        }
                    }
                    else
                    {
                        Messages.InformationMessage("Please select status");
                        cmbStatus.Focus();
                    }
                }
                else
                {
                    Messages.InformationMessage("Please select bank account");
                    cmbBankAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:15" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Bank reconciliation Cell value changed event for Set the statement date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBankReconciliation_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    DateValidation objVal = new DateValidation();
                    TextBox txtDate = new TextBox();
                    if (!dgvBankReconciliation.Rows[e.RowIndex].Cells["dgvtxtStatementDate"].ReadOnly)
                    {
                        if (dgvBankReconciliation.Rows[e.RowIndex].Cells["dgvtxtStatementDate"].Value != null && dgvBankReconciliation.Rows[e.RowIndex].Cells["dgvtxtStatementDate"].Value.ToString() != string.Empty)
                        {
                            txtDate.Text = dgvBankReconciliation.Rows[e.RowIndex].Cells["dgvtxtStatementDate"].Value.ToString();
                            bool isDate = objVal.DateValidationFunction(txtDate);
                            if (isDate)
                            {
                                dgvBankReconciliation.Rows[e.RowIndex].Cells["dgvtxtStatementDate"].Value = txtDate.Text;
                            }
                            else
                            {
                                dgvBankReconciliation.Rows[e.RowIndex].Cells["dgvtxtStatementDate"].Value = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:16" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// When the state of a Gridview cell changes in relation to a change in its contents.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBankReconciliation_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBankReconciliation.IsCurrentCellDirty)
                {
                    dgvBankReconciliation.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:17" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call the Total Amount calculation In dataGridView CellEndEdit Event,its call once complete the Editing of a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBankReconciliation_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FindTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:18" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Navigations
        /// <summary>
        /// For EnterKey Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBankAccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:19" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For EnterKey and BackSpace Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtStatementFrom.Focus();
                    txtStatementFrom.SelectionStart = 0;
                    txtStatementFrom.SelectionLength = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    cmbBankAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:20" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For EnterKey and BackSpace Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStatementFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtStatementTo.Focus();
                    txtStatementTo.SelectionStart = 0;
                    txtStatementTo.SelectionLength = 0;
                }
                if (txtStatementFrom.Text == string.Empty || txtStatementFrom.SelectionStart == 0)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        cmbStatus.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:21" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For EnterKey and BackSpace Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStatementTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtStatementTo.Text == string.Empty || txtStatementTo.SelectionStart == 0)
                    {
                        txtStatementFrom.Focus();
                        txtStatementFrom.SelectionLength = 0;
                        txtStatementTo.SelectionStart = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:22" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For EnterKey and BackSpace Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvBankReconciliation.RowCount > 0)
                    {
                        dgvBankReconciliation.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtStatementTo.Focus();
                    txtStatementTo.SelectionStart = 0;
                    txtStatementTo.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:23" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For EnterKey and BackSpace Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBankReconciliation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{tab}");
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (dgvBankReconciliation.CurrentCell == dgvBankReconciliation.Rows[0].Cells["dgvtxtSlNo"])
                    {
                        btnSearch.Focus();
                        dgvBankReconciliation.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:24" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For EnterKey and BackSpace Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClear.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (dgvBankReconciliation.RowCount > 0)
                    {
                        dgvBankReconciliation.Focus();
                    }
                    else
                    {
                        btnSearch.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:25" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For EnterKey and BackSpace Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:26" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For BackSpace Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    btnClear.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BR:27" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
