using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using LoginForm.DataSet;
using LoginForm.Account.Services;
using LoginForm.Account;
using LoginForm.Services;
using LoginForm;

namespace LoginForm
{
    public partial class frmPaymentReport : Form
    {
        #region Functions
        /// <summary>
        /// Create an instance for frmPaymentReport class
        /// </summary>
        public frmPaymentReport()
        {
            InitializeComponent();
        }
        public void Print()
        {
            //try
            //{
            //    PaymentMasterSP SpPaymentMaster = new PaymentMasterSP();
            //    DataSet dsPaymentReport = SpPaymentMaster.PaymentReportPrinting(Convert.ToDateTime(dtpFromDate.Value.ToString()), Convert.ToDateTime(dtpToDate.Value.ToString()), Convert.ToDecimal(cmbLedger.SelectedValue), Convert.ToDecimal(cmbVoucherType.SelectedValue), Convert.ToDecimal(cmbBankOrCash.SelectedValue), 1);
            //    frmReport frmReport = new frmReport();
            //    frmReport.MdiParent = formMDI.MDIObj;
            //    frmReport.PaymentReportPrinting(dsPaymentReport);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("PRP1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        /// <summary>
        /// Function to fill CashOrBank combobox
        /// </summary>
        public void CashOrBankComboFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                TransactionsGeneralFill Obj = new TransactionsGeneralFill();
                dtbl = Obj.BankOrCashComboFill(false);
                DataRow dr = dtbl.NewRow();
                dr[0] = 0;
                dr[1] = "All";
                dtbl.Rows.InsertAt(dr, 0);
                cmbBankOrCash.DataSource = dtbl;
                cmbBankOrCash.ValueMember = "ledgerId";
                cmbBankOrCash.DisplayMember = "ledgerName";
                cmbBankOrCash.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill AccountLedger combobox
        /// </summary>
        public void AccountLedgerComboFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                TransactionsGeneralFill obj = new TransactionsGeneralFill();
                dtbl = obj.AccountLedgerComboFill();
                DataRow dr = dtbl.NewRow();
                dr[0] = 0;
                dr[2] = "All";
                dtbl.Rows.InsertAt(dr, 0);
                cmbLedger.DataSource = dtbl;
                cmbLedger.ValueMember = "ledgerId";
                cmbLedger.DisplayMember = "ledgerName";
                cmbLedger.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP3:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill Voucher combobox
        /// </summary>
        public void VoucherComboFill()
        {
            try
            {
                VoucherTypeSP SpVoucherType = new VoucherTypeSP();
                DataTable dtbl = new DataTable();
                dtbl = SpVoucherType.VoucherTypeViewAll();
                DataRow dr = dtbl.NewRow();
                dr[0] = 0;
                dr[1] = "All";
                dtbl.Rows.InsertAt(dr, 0);
                cmbVoucherType.DataSource = dtbl;
                cmbVoucherType.ValueMember = "voucherTypeId";
                cmbVoucherType.DisplayMember = "voucherTypeName";
                cmbVoucherType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP4:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill the grid based on the search catogeries
        /// </summary>
        public void GridFill()
        {
            try
            {
                PaymentMasterSP SpPaymentMaster = new PaymentMasterSP();
                DataTable dtbl = new DataTable();
                if (cmbLedger.Items.Count != 0 && cmbVoucherType.Items.Count != 0 && cmbBankOrCash.Items.Count != 0)
                {
                    if (cmbVoucherType.SelectedIndex!=0&&cmbBankOrCash.SelectedIndex!=0 &&cmbLedger.SelectedIndex!=0&&(cmbLedger.SelectedValue.ToString() != "System.Data.DataRowView") && (cmbVoucherType.SelectedValue.ToString() != "System.Data.DataRowView" ) && (cmbBankOrCash.SelectedValue.ToString() != "System.Data.DataRowView"))
                    {
                        if (txtFromDate.Text.Trim() != string.Empty && txtToDate.Text.Trim() != string.Empty)
                        {
                            dtbl = SpPaymentMaster.PaymentReportSearch(Convert.ToDateTime(dtpFromDate.Value.ToString()), Convert.ToDateTime(dtpToDate.Value.ToString()), Convert.ToDecimal(cmbLedger.SelectedValue), Convert.ToDecimal(cmbVoucherType.SelectedValue), Convert.ToDecimal(cmbBankOrCash.SelectedValue));
                            dgvPaymentReport.DataSource = dtbl;
                        }
                    }
                    else
                    {
                        if(cmbVoucherType.SelectedIndex ==0 && cmbBankOrCash.SelectedIndex == 0 && cmbLedger.SelectedIndex == 0)//all comboboxes are ALL
                        {
                            dtbl = SpPaymentMaster.PaymentReportSearch(Convert.ToDateTime(dtpFromDate.Value.ToString()), Convert.ToDateTime(dtpToDate.Value.ToString()));
                            dgvPaymentReport.DataSource = dtbl;
                        }
                        else
                        {
                            if(cmbVoucherType.SelectedIndex == 0)
                            {
                                if (cmbBankOrCash.SelectedIndex == 0)//bankorcash and vouchertype are ALL
                                {
                                    dtbl = SpPaymentMaster.PaymentReportSearchwithBankAndVoucherType(Convert.ToDateTime(dtpFromDate.Value.ToString()), Convert.ToDateTime(dtpToDate.Value.ToString()), Convert.ToDecimal(cmbVoucherType.SelectedValue), Convert.ToDecimal(cmbBankOrCash.SelectedValue));
                                    dgvPaymentReport.DataSource = dtbl;
                                }
                                else//vouchertype ALL
                                {
                                    dtbl = SpPaymentMaster.PaymentReportSearchWithVoucherType(Convert.ToDateTime(dtpFromDate.Value.ToString()), Convert.ToDateTime(dtpToDate.Value.ToString()), Convert.ToDecimal(cmbVoucherType.SelectedValue));
                                    dgvPaymentReport.DataSource = dtbl;
                                }
                            }
                            else
                            {
                                if (cmbBankOrCash.SelectedIndex == 0)
                                {
                                    if (cmbLedger.SelectedIndex==0)//ledger and bank are ALL
                                    {
                                        dtbl = SpPaymentMaster.PaymentReportSearchWithLedgerAndBank(Convert.ToDateTime(dtpFromDate.Value.ToString()), Convert.ToDateTime(dtpToDate.Value.ToString()), Convert.ToDecimal(cmbLedger.SelectedValue),  Convert.ToDecimal(cmbBankOrCash.SelectedValue));
                                        dgvPaymentReport.DataSource = dtbl;

                                    }
                                    else//bank is ALL
                                    {
                                        dtbl = SpPaymentMaster.PaymentReportSearchwithBank(Convert.ToDateTime(dtpFromDate.Value.ToString()), Convert.ToDateTime(dtpToDate.Value.ToString()), Convert.ToDecimal(cmbBankOrCash.SelectedValue));
                                        dgvPaymentReport.DataSource = dtbl;
                                    }
                                }
                                else//ledger is ALL
                                {
                                    dtbl = SpPaymentMaster.PaymentReportSearchWithLedger(Convert.ToDateTime(dtpFromDate.Value.ToString()), Convert.ToDateTime(dtpToDate.Value.ToString()), Convert.ToDecimal(cmbLedger.SelectedValue));
                                    dgvPaymentReport.DataSource = dtbl;
                                }
                            } 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Clear function to clear the form controls
        /// </summary>
        public void Clear()
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                dtpFromDate.Value = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy"));
                dtpToDate.Value = Convert.ToDateTime(Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy"));
                dtpFromDate.MinDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                dtpFromDate.MaxDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate);
                dtpToDate.MinDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                dtpToDate.MaxDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate);
                VoucherComboFill();
                AccountLedgerComboFill();
                CashOrBankComboFill();
                GridFill();
                txtFromDate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmPaymentVoucher to view details and for updation
        /// </summary>
        /// <param name="frmPaymentVoucher"></param>
        public void CallFromPaymentVoucher(frmPaymentVoucher frmPaymentVoucher)
        {
            try
            {
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Events
        /// <summary>
        /// To date validation and set the dtp value as text box text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation obj = new DateValidation();
                obj.DateValidationFunction(txtFromDate);
                if (txtFromDate.Text == string.Empty)
                {
                    txtFromDate.Text = Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy");
                }
                string strdate = txtFromDate.Text;
                dtpFromDate.Value = Convert.ToDateTime(strdate.ToString());
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }      
        /// <summary>
        /// When form load call the clear function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPaymentReport_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// set the textbox value as datetime picker value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpFromDate.Value;
                this.txtFromDate.Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// set the textbox value as datetime picker value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpToDate.Value;
                this.txtToDate.Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Cell double click for updation the selected details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPaymentReport.CurrentRow != null)
                {
                    if (dgvPaymentReport.CurrentRow.Index == e.RowIndex)
                    {
                        if (dgvPaymentReport.CurrentRow.Cells["dgvtxtpaymentMasterId"].Value != null && dgvPaymentReport.CurrentRow.Cells["dgvtxtpaymentMasterId"].Value.ToString() != string.Empty)
                        {
                            frmPaymentVoucher frmPaymentVoucherObj = new frmPaymentVoucher();
                           // frmPaymentVoucherObj.MdiParent = formMDI.MDIObj;
                            decimal decPaymentmasterId = Convert.ToDecimal(dgvPaymentReport.CurrentRow.Cells["dgvtxtpaymentMasterId"].Value.ToString());
                            frmPaymentVoucherObj.CallFromPaymentReport(this, decPaymentmasterId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Search button click, call the gridfill function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                DateValidation ObjValidation = new DateValidation();
                ObjValidation.DateValidationFunction(txtToDate);
                if (Convert.ToDateTime(txtToDate.Text) < Convert.ToDateTime(txtFromDate.Text))
                {
                    MessageBox.Show("todate should be greater than fromdate", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtToDate.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
                    txtFromDate.Text = Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy");
                    DateTime dt;
                    DateTime.TryParse(txtToDate.Text, out dt);
                    dtpToDate.Value = dt;
                    GridFill();
                }
                else
                {
                    DateTime dt;
                    DateTime.TryParse(txtToDate.Text, out dt);
                    dtpToDate.Value = dt;
                    GridFill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CF:13" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// reset button click, call the clear function in that
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP14:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Print button click, call the print function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPaymentReport.RowCount > 0)
                {
                    Print();
                }
                else
                {
                    MessageBox.Show(" No data found", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP15:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date validation and set the date as dtp' value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToDate_Leave(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                DateValidation obj = new DateValidation();
                obj.DateValidationFunction(txtToDate);
                if (txtToDate.Text == string.Empty)
                {
                    txtToDate.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
                }
                string strdate = txtToDate.Text;
                dtpToDate.Value = Convert.ToDateTime(strdate.ToString());
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP16:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On 'Export' button click to export the report to Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportNew ex = new ExportNew();
                ex.ExportExcel(dgvPaymentReport, "Payment Report", 0, 0, "Excel", null, null, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP24: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Navigation
        /// <summary>
        /// For enterkey and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtToDate.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  For enterkey and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbVoucherType.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtToDate.Text == string.Empty && txtToDate.SelectionStart == 0)
                    {
                        txtFromDate.Focus();
                        txtFromDate.SelectionStart = 0;
                        txtFromDate.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  For enterkey and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbVoucherType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBankOrCash.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtToDate.Text == string.Empty || txtToDate.SelectionStart == 0)
                    {
                        txtToDate.Focus();
                        txtToDate.SelectionStart = 0;
                        txtToDate.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  For enterkey and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBankOrCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbLedger.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    cmbVoucherType.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  For enterkey and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLedger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    cmbBankOrCash.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  For enterkey and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPaymentReport_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (Messages.CloseConfirmation())
                        this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP22:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  For enterkey and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentReport_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    btnPrint.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRP23:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion   
          
       
    }
}
