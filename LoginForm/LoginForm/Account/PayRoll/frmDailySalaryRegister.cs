using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using LoginForm.DataSet;
using LoginForm.Services;
using LoginForm.Account.Services;

namespace LoginForm
{
    public partial class frmDailySalaryRegister : Form
    {
        #region Public Variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        int q = 0;
        int inCurrenRowIndex = 0;

        #endregion

        #region Function
        /// <summary>
        /// Creates an instance of frmDailySalaryRegister class
        /// </summary>
        public frmDailySalaryRegister()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to reset the form
        /// </summary>
        public void Clear()
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                txtSalaryDateFrom.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                txtSalaryDateTo.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                txtVoucherDateFrom.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                txtVoucherDateTo.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                dtpSalaryDateFrom.Value = IME.CurrentDate().FirstOrDefault().Value;
                dtpSalaryDateFrom.MinDate = Utils.getManagement().FinancialYear.fromDate.Value;
                dtpSalaryDateFrom.MaxDate = Utils.getManagement().FinancialYear.toDate.Value;
                dtpSalaryDateTo.Value = IME.CurrentDate().FirstOrDefault().Value;
                dtpSalaryDateTo.MinDate = Utils.getManagement().FinancialYear.fromDate.Value;
                dtpSalaryDateTo.MaxDate = Utils.getManagement().FinancialYear.toDate.Value;
                dtpVoucherDateFrom.Value = IME.CurrentDate().FirstOrDefault().Value;
                dtpVoucherDateFrom.MinDate = Utils.getManagement().FinancialYear.fromDate.Value;
                dtpVoucherDateFrom.MaxDate = Utils.getManagement().FinancialYear.toDate.Value;
                dtpVoucherDateTo.Value = IME.CurrentDate().FirstOrDefault().Value;
                dtpVoucherDateTo.MinDate = Utils.getManagement().FinancialYear.fromDate.Value;
                dtpVoucherDateTo.MaxDate = Utils.getManagement().FinancialYear.toDate.Value;
                txtVoucherNo.Text = string.Empty;
                txtSalaryDateFrom.Focus();
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR1" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill Datagridview
        /// </summary>
        public void GridFill()
        {
            try
            {
                DataTable dtblDailySalaryRegister = new DataTable();
                DailySalaryVoucherMasterSP spDailySalaryVoucherMasterSP = new DailySalaryVoucherMasterSP();
                dtblDailySalaryRegister = spDailySalaryVoucherMasterSP.DailySalaryRegisterSearch(Convert.ToDateTime(txtVoucherDateFrom.Text.ToString()), Convert.ToDateTime(txtVoucherDateTo.Text.ToString()), Convert.ToDateTime(txtSalaryDateFrom.Text.ToString()), Convert.ToDateTime(txtSalaryDateTo.Text.ToString()), txtVoucherNo.Text);
                dgvDailySalaryRegister.DataSource = dtblDailySalaryRegister;

            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR2" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to select the row in Datagridview
        /// </summary>
        public void GridSelection()
        {
            try
            {
                if (inCurrenRowIndex >= 0 && dgvDailySalaryRegister.Rows.Count > 0 && inCurrenRowIndex < dgvDailySalaryRegister.Rows.Count)
                {
                    dgvDailySalaryRegister.CurrentCell = dgvDailySalaryRegister.Rows[inCurrenRowIndex].Cells[0];
                    dgvDailySalaryRegister.CurrentCell.Selected = true;
                }
                else
                {
                    inCurrenRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR3" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Events
       /// <summary>
       /// On 'Clear' button click
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
                MessageBox.Show("DSR4" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("DSR5" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDailySalaryRegister_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR6" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Clears selection on Databind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDailySalaryRegister_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvDailySalaryRegister.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR7" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fills Datagridview when form activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDailySalaryRegister_Activated(object sender, EventArgs e)
        {
            try
            {
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR8" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Calls frmDailySalaryVoucher form when cell double click for updation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDailySalaryRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvDailySalaryRegister.CurrentRow.Index == e.RowIndex)
                    {
                        frmDailySalaryVoucher dailySalaryVoucherObj = new frmDailySalaryVoucher();
                        //dailySalaryVoucherObj.MdiParent = formMDI.MDIObj;

                        frmDailySalaryVoucher open = Application.OpenForms["frmDailySalaryVoucher"] as frmDailySalaryVoucher;
                        if (open == null)
                        {
                            dailySalaryVoucherObj = new frmDailySalaryVoucher();
                            //dailySalaryVoucherObj.MdiParent = formMDI.MDIObj;
                            dailySalaryVoucherObj.CallFromDailySalaryVoucherRegister(Convert.ToDecimal(dgvDailySalaryRegister.Rows[e.RowIndex].Cells["dgvtxtDailySalaryVoucherMasterId"].Value.ToString()), this);
                        }
                        else
                        {
                            //open.MdiParent = formMDI.MDIObj;
                            open.BringToFront();
                            open.CallFromDailySalaryVoucherRegister(Convert.ToDecimal(dgvDailySalaryRegister.Rows[e.RowIndex].Cells["dgvtxtDailySalaryVoucherMasterId"].Value.ToString()), this);
                            if (open.WindowState == FormWindowState.Minimized)
                            {
                                open.WindowState = FormWindowState.Normal;
                            }
                        }
                        inCurrenRowIndex = dgvDailySalaryRegister.CurrentRow.Index;
                    }
                    this.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR9" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fills txtSalaryDateFrom textbox on dtpSalaryDateFrom datetimepicker ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpSalaryDateFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dtdate = this.dtpSalaryDateFrom.Value;
                dtpSalaryDateFrom.Format = DateTimePickerFormat.Custom;
                this.txtSalaryDateFrom.Text = dtdate.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR10" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSalaryDateFrom_Leave(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                DateValidation objDateValidation = new DateValidation();
                objDateValidation.DateValidationFunction(txtSalaryDateFrom);
                if (txtSalaryDateFrom.Text == string.Empty)
                {
                    txtSalaryDateFrom.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR11" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Datevalidation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSalaryDateTo_Leave(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                DateValidation objDateValidation = new DateValidation();
                objDateValidation.DateValidationFunction(txtSalaryDateTo);
                if (txtSalaryDateTo.Text == string.Empty)
                {
                    txtSalaryDateTo.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR12" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fills txtSalaryDateTo textbox on dtpSalaryDateTo datetimepicker ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpSalaryDateTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dtdate = this.dtpSalaryDateFrom.Value;
                dtpSalaryDateFrom.Format = DateTimePickerFormat.Custom;
                this.txtSalaryDateTo.Text = dtdate.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR13" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherDateFrom_Leave(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                DateValidation objDateValidation = new DateValidation();
                objDateValidation.DateValidationFunction(txtVoucherDateFrom);
                if (txtVoucherDateFrom.Text == string.Empty)
                {
                    txtVoucherDateFrom.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR14" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DateTime dtdate = this.dtpSalaryDateFrom.Value;
                dtpSalaryDateFrom.Format = DateTimePickerFormat.Custom;
                this.txtVoucherDateFrom.Text = dtdate.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR15" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherDateTo_Leave(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                DateValidation objDateValidation = new DateValidation();
                objDateValidation.DateValidationFunction(txtVoucherDateTo);
                if (txtVoucherDateTo.Text == string.Empty)
                {
                    txtVoucherDateTo.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR16" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DateTime dtdate = this.dtpSalaryDateFrom.Value;
                dtpSalaryDateFrom.Format = DateTimePickerFormat.Custom;
                this.txtVoucherDateTo.Text = dtdate.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR17" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Navigation
        /// <summary>
        /// Escape key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDailySalaryRegister_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Messages.CloseMessage(this);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtVoucherNo.Text == string.Empty || txtVoucherNo.SelectionStart == 0)
                    {
                        txtVoucherDateTo.SelectionStart = 0;
                        txtVoucherDateTo.SelectionLength = 0;
                        txtVoucherDateTo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR19" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    txtVoucherNo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR20" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       /// <summary>
       /// Enter key navigation
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void dgvDailySalaryRegister_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvDailySalaryRegister.CurrentRow != null)
                    {
                        DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(dgvDailySalaryRegister.CurrentCell.ColumnIndex, dgvDailySalaryRegister.CurrentCell.RowIndex);
                        dgvDailySalaryRegister_CellDoubleClick(sender, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR21" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSalaryDateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSalaryDateTo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR22" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSalaryDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtVoucherDateFrom.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtSalaryDateTo.Text == string.Empty || txtSalaryDateTo.SelectionStart == 0)
                    {
                        txtSalaryDateFrom.SelectionStart = 0;
                        txtSalaryDateFrom.SelectionLength = 0;
                        txtSalaryDateFrom.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR23" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation
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
                if (e.KeyCode == Keys.Back)
                {
                    if (txtVoucherDateFrom.Text == string.Empty || txtVoucherDateFrom.SelectionStart == 0)
                    {
                        txtSalaryDateTo.SelectionStart = 0;
                        txtSalaryDateTo.SelectionLength = 0;
                        txtSalaryDateTo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSR24" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    txtVoucherNo.Focus();
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
                MessageBox.Show("DSR25" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
 
        #endregion
    }
}
