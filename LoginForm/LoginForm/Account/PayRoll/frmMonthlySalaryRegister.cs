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

    public partial class frmMonthlySalaryRegister : Form
    {
        #region Public Variables
        IMEEntities IME = new IMEEntities();
        int inCurrenRowIndex = 0;
        frmLedgerPopup frmLedgerPopupObj = new frmLedgerPopup();

        #endregion

        #region Functions
        /// <summary>
        /// Creates an instance of frmMonthlySalaryRegister class
        /// </summary>
        public frmMonthlySalaryRegister()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to fill VoucherType combobox
        /// </summary>
        public void VoucherTypeNameComboFill()
        {
            try
            {
                DataTable dtblVoucherTyeName = new DataTable();
                VoucherTypeSP spVoucherType = new VoucherTypeSP();
                dtblVoucherTyeName = spVoucherType.VoucherTypeNameComboFill();
                DataRow dr = dtblVoucherTyeName.NewRow();
                dr[1] = "All";
                dtblVoucherTyeName.Rows.InsertAt(dr, 0);
                cmbVoucherTypeName.DataSource = dtblVoucherTyeName;
                cmbVoucherTypeName.ValueMember = "voucherTypeId";
                cmbVoucherTypeName.DisplayMember = "voucherTypeName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        /// <summary>
        /// Function to fill Datagridview
        /// </summary>
        public void GridFill()
        {
            try
            {
                if (cmbCashBankAC.Text.Trim() == string.Empty)
                {
                    if (cmbCashBankAC.DropDownStyle != ComboBoxStyle.DropDown)
                    {
                        cmbCashBankAC.DropDownStyle = ComboBoxStyle.DropDown;
                    }
                    cmbCashBankAC.Text = "All";
                }
                DataTable dtbl = new DataTable();
                SalaryVoucherMasterSP spSalaryVoucherMaster = new SalaryVoucherMasterSP();
                dtbl = spSalaryVoucherMaster.MonthlySalaryRegisterSearch(Convert.ToDateTime(txtVoucherDateFrom.Text.Trim().ToString()), Convert.ToDateTime(txtVoucherDateTo.Text.Trim().ToString()), Convert.ToDateTime(dtpSalaryMonth.Value.ToString("MMMM yyyy")), txtVoucherNo.Text.Trim(), cmbCashBankAC.Text.ToString(), cmbVoucherTypeName.Text.ToString());
                dgvMonthlySalaryRegister.DataSource = dtbl;
                if (cmbCashBankAC.Text == "All")
                {
                    cmbCashBankAC.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to reset form
        /// </summary>
        public void Clear()
        {
            try
            {
                txtVoucherDateFrom.Text = IME.FinancialYears.Where(a => a.fromDate <= Convert.ToDateTime(IME.CurrentDate().First())).Where(b => b.toDate >= Convert.ToDateTime(IME.CurrentDate().First())).FirstOrDefault().fromDate?.ToString("dd-MMM-yyyy");
                txtVoucherDateTo.Text = IME.FinancialYears.Where(a => a.fromDate <= Convert.ToDateTime(IME.CurrentDate().First())).Where(b => b.toDate >= Convert.ToDateTime(IME.CurrentDate().First())).FirstOrDefault().toDate?.ToString("dd-MMM-yyyy");
                dtpVoucherDateFrom.Value = DateTime.Parse(IME.CurrentDate().ToString());
                dtpVoucherDateFrom.MinDate = (DateTime)IME.FinancialYears.Where(a => a.fromDate <= Convert.ToDateTime(IME.CurrentDate().First())).Where(b => b.toDate >= Convert.ToDateTime(IME.CurrentDate().First())).FirstOrDefault().fromDate;
                dtpVoucherDateFrom.MaxDate = (DateTime)IME.FinancialYears.Where(a => a.fromDate <= Convert.ToDateTime(IME.CurrentDate().First())).Where(b => b.toDate >= Convert.ToDateTime(IME.CurrentDate().First())).FirstOrDefault().toDate;
                dtpVoucherDateTo.Value = DateTime.Parse(IME.CurrentDate().ToString());
                dtpVoucherDateTo.MinDate = (DateTime)IME.FinancialYears.Where(a => a.fromDate <= Convert.ToDateTime(IME.CurrentDate().First())).Where(b => b.toDate >= Convert.ToDateTime(IME.CurrentDate().First())).FirstOrDefault().fromDate;
                dtpVoucherDateTo.MaxDate = (DateTime)IME.FinancialYears.Where(a => a.fromDate <= Convert.ToDateTime(IME.CurrentDate().First())).Where(b => b.toDate >= Convert.ToDateTime(IME.CurrentDate().First())).FirstOrDefault().toDate; 
                dtpSalaryMonth.Value = DateTime.Parse(IME.CurrentDate().ToString());
                dtpSalaryMonth.MinDate = (DateTime)IME.FinancialYears.Where(a => a.fromDate <= Convert.ToDateTime(IME.CurrentDate().First())).Where(b => b.toDate >= Convert.ToDateTime(IME.CurrentDate().First())).FirstOrDefault().fromDate;
                dtpSalaryMonth.MaxDate = (DateTime)IME.FinancialYears.Where(a => a.fromDate <= Convert.ToDateTime(IME.CurrentDate().First())).Where(b => b.toDate >= Convert.ToDateTime(IME.CurrentDate().First())).FirstOrDefault().toDate;
                txtVoucherNo.Clear();
                cmbVoucherTypeName.SelectedIndex = -1;
                VoucherTypeNameComboFill();
                TransactionsGeneralFill obj = new TransactionsGeneralFill();
                obj.CashOrBankComboFill(cmbCashBankAC, false);
                cmbCashBankAC.SelectedIndex = -1;
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR3:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call frmLedgerPopup form to select and view ledgers
        /// </summary>
        /// <param name="frmLedgerPopup"></param>
        /// <param name="decId"></param>
        public void CallFromLedgerPopup(frmLedgerPopup frmLedgerPopup, decimal decId) //PopUp
        {
            try
            {
                base.Show();
                this.frmLedgerPopupObj = frmLedgerPopup;
                TransactionsGeneralFill obj = new TransactionsGeneralFill();
                obj.CashOrBankComboFill(cmbCashBankAC, false);
                cmbCashBankAC.SelectedValue = decId;
                cmbCashBankAC.Focus();
                frmLedgerPopupObj.Close();
                frmLedgerPopupObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR4:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Events
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMonthlySalaryRegister_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fills txtVoucherDateFrom textbox on dtpVoucherDateFrom datetimepicker ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpVoucherDateFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtVoucherDateFrom.Text = this.dtpVoucherDateFrom.Value.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fills txtVoucherDateTo textbox on dtpVoucherDateTo datetimepicker ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpVoucherDateTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtVoucherDateTo.Text = this.dtpVoucherDateTo.Value.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherDateFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation objDateValidation = new DateValidation();
                objDateValidation.DateValidationFunction(txtVoucherDateFrom);
                if (txtVoucherDateFrom.Text == string.Empty)
                {
                    txtVoucherDateFrom.Text = DateTime.Parse(IME.CurrentDate().ToString()).ToString("dd-MMM-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherDateTo_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation objDateValidation = new DateValidation();
                objDateValidation.DateValidationFunction(txtVoucherDateTo);
                if (txtVoucherDateTo.Text == string.Empty)
                {
                    txtVoucherDateTo.Text = DateTime.Parse(IME.CurrentDate().ToString()).ToString("dd-MMM-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Escape key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMonthlySalaryRegister_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.KeyCode == Keys.Escape)
                {
                    DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
           
        }
        /// <summary>
        /// On 'Search' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Calls frmMonthlySalaryVoucher form when cell double click for updation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMonthlySalaryRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvMonthlySalaryRegister.CurrentRow.Index == e.RowIndex)
                    {
                        //Mountly Salary Voucher yapıldıktan sonra açılacak
                        //frmMonthlySalaryVoucher objfrmMonthlySalaryVoucher = new frmMonthlySalaryVoucher(); ;
                        //objfrmMonthlySalaryVoucher.MdiParent = FormMain.MDIObj;
                        //frmMonthlySalaryVoucher open = Application.OpenForms["frmMonthlySalaryVoucher"] as frmMonthlySalaryVoucher;

                        //if (open == null)
                        //{
                        //    objfrmMonthlySalaryVoucher.WindowState = FormWindowState.Normal;
                        //    objfrmMonthlySalaryVoucher.MdiParent = FormMain.MDIObj;
                        //    objfrmMonthlySalaryVoucher.CallFromMonthlySalaryRegister(Convert.ToDecimal(dgvMonthlySalaryRegister.Rows[e.RowIndex].Cells["dgvtxtSalaryVoucherMasterID"].Value.ToString()), this);
                        //}
                        //else
                        //{
                        //    open.CallFromMonthlySalaryRegister(Convert.ToDecimal(dgvMonthlySalaryRegister.Rows[e.RowIndex].Cells["dgvtxtSalaryVoucherMasterID"].Value.ToString()), this);
                        //    if (open.WindowState == FormWindowState.Minimized)
                        //    {
                        //        open.WindowState = FormWindowState.Normal;
                        //    }
                        //}
                        //inCurrenRowIndex = dgvMonthlySalaryRegister.CurrentRow.Index;
                    }
                    this.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'clear' button click
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
                MessageBox.Show("MSR13:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Navigation
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherDateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtVoucherDateTo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR14:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpSalaryMonth.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtVoucherDateTo.Text == string.Empty || txtVoucherDateTo.SelectionStart == 0)
                    {
                        txtVoucherDateFrom.SelectionStart = 0;
                        txtVoucherDateFrom.SelectionLength = 0;
                        txtVoucherDateFrom.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR15:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dtpSalaryMonth_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtVoucherNo.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtVoucherDateTo.SelectionStart = 0;
                    txtVoucherDateTo.SelectionLength = 0;
                    txtVoucherDateTo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR16:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCashBankAC.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtVoucherNo.Text == string.Empty || txtVoucherNo.SelectionStart == 0)
                    {
                        dtpSalaryMonth.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCashBankAC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbVoucherTypeName.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbCashBankAC.Text == string.Empty || cmbCashBankAC.SelectionStart == 0)
                    {
                        txtVoucherNo.SelectionStart = 0;
                        txtVoucherNo.SelectionLength = 0;
                        txtVoucherNo.Focus();
                    }
                }
                if (e.KeyCode == Keys.F && Control.ModifierKeys == Keys.Control) //Pop Up
                {

                    if (cmbCashBankAC.SelectedIndex != -1)
                    {
                        if (cmbCashBankAC.Focused)
                        {
                            cmbCashBankAC.DropDownStyle = ComboBoxStyle.DropDown;
                        }
                        else
                        {
                            cmbCashBankAC.DropDownStyle = ComboBoxStyle.DropDownList;
                        }
                        frmLedgerPopupObj = new frmLedgerPopup();
                        frmLedgerPopupObj.MdiParent = FormMain.MDIObj;
                        frmLedgerPopupObj.CallFromMonthlySalaryRegister(this, Convert.ToDecimal(cmbCashBankAC.SelectedValue.ToString()), "CashOrBank");
                    }
                    else
                    {
                        Messages.InformationMessage("Select any cash or bank account");
                        cmbCashBankAC.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    cmbVoucherTypeName.SelectionStart = 0;
                    cmbVoucherTypeName.SelectionLength = 0;
                    cmbVoucherTypeName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Calls frmMonthlySalaryVoucher for updation on enter key in Datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMonthlySalaryRegister_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvMonthlySalaryRegister.CurrentRow != null)
                    {
                        DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(dgvMonthlySalaryRegister.CurrentCell.ColumnIndex, dgvMonthlySalaryRegister.CurrentCell.RowIndex);
                        dgvMonthlySalaryRegister_CellDoubleClick(sender, ex);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbVoucherTypeName_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbVoucherTypeName.Text == string.Empty || cmbVoucherTypeName.SelectionLength == 0)
                    {
                        cmbCashBankAC.SelectionStart = 0;
                        cmbCashBankAC.SelectionLength = 0;
                        cmbCashBankAC.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSR21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

    }
}


