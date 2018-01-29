using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.DataSet;
using LoginForm.Services;
using LoginForm.Account.Services;

namespace LoginForm
{
    public partial class frmPaymentRegister : Form
    {
        IMEEntities IME = new IMEEntities();
        #region Functions

        public frmPaymentRegister()
        {
            InitializeComponent();
        }
        public void LedgerComboFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                TransactionsGeneralFill obj = new TransactionsGeneralFill();
                dtbl = obj.BankOrCashComboFill(false);
                DataRow dr = dtbl.NewRow();
                dr[1] = "All";
                dr[0] = 0;
                dtbl.Rows.InsertAt(dr, 0);
                cmbAccountLedger.DataSource = dtbl;
                cmbAccountLedger.ValueMember = "ledgerId";
                cmbAccountLedger.DisplayMember = "ledgerName";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Clear()
        {

            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;
            LedgerComboFill();
            txtVoucherNo.Text = string.Empty;
            gridfill();
            txtFromDate.Focus();

        }
        /// <summary>
        /// Function to fill Datagridview
        /// </summary>
        public void gridfill()
        {
            try
            {
                PaymentMasterSP SpPaymentMaster = new PaymentMasterSP();
                PaymentMaster infoPaymentMaster = new PaymentMaster();
                DataTable dtbl = new DataTable();
                if (cmbAccountLedger.Items.Count > 0)
                {
                    if (cmbAccountLedger.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        if (txtFromDate.Text.Trim() != string.Empty && txtToDate.Text.Trim() != string.Empty)
                        {
                                dtbl = SpPaymentMaster.PaymentMasterSearch(dtpFromDate.Value, dtpToDate.Value, (cmbAccountLedger.SelectedValue).ToString(), txtVoucherNo.Text);
                                dgvPaymentRegister.DataSource = dtbl;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG4:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from PaymentVoucher when Updation is Completed
        /// </summary>
        /// <param name="frmPaymentVoucher"></param>
        public void CallFromPaymentVoucher()
        {

            gridfill();

        }
        #endregion
        #region Events
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPaymentRegister_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Calls corresponding PaymentVoucher on cell doubleclick in Datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (dgvPaymentRegister.CurrentRow.Index != -1 && dgvPaymentRegister.CurrentCell.ColumnIndex != 0)
                    {
                        btnviewDetails_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// DataError event to throw unhandled exceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentRegister_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                {
                    object value = dgvPaymentRegister.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dgvPaymentRegister.Columns[e.ColumnIndex]).Items.Contains(value))
                    {
                        e.ThrowException = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// DateValidation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToDate_Leave(object sender, EventArgs e)
        {


            if (txtToDate.Text == string.Empty)
            {
                txtToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            }
            //---for change date in Date time picker----//
            string strdate = txtToDate.Text;
            dtpToDate.Value = Convert.ToDateTime(strdate.ToString());

        }
        /// <summary>
        /// Date validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFromDate_Leave(object sender, EventArgs e)
        {

            if (txtFromDate.Text == string.Empty)
            {
                txtFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            }
            //---for change date in Date time picker----//
            string strdate = txtFromDate.Text;
            dtpFromDate.Value = Convert.ToDateTime(strdate.ToString());

        }
        /// <summary>
        /// Fills txtFromDate textbox on dtpFromDate datetimepicker ValueChanged
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
                MessageBox.Show("PREG11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fills txtToDate textbox on dtpToDate datetimepicker ValueChanged
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
                MessageBox.Show("PREG12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Close' button click
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
        /// On 'Reset' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        /// <summary>
        /// On 'Search' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
                {
                    if (Convert.ToDateTime(txtToDate.Text) < Convert.ToDateTime(txtFromDate.Text))
                    {
                        MessageBox.Show("To date should be greater than fromdate", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                        txtFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                        DateTime dt;
                        DateTime.TryParse(txtToDate.Text, out dt);
                        dtpToDate.Value = dt;
                        dtpFromDate.Value = dt;
                    }
                }
                else if (txtFromDate.Text == string.Empty)
                {
                    txtFromDate.Text = DateTime.Now.ToString();
                    txtToDate.Text = DateTime.Now.ToString();
                    DateTime dt;
                    DateTime.TryParse(txtToDate.Text, out dt);
                    dtpToDate.Value = dt;
                    dtpFromDate.Value = dt;
                }
                gridfill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG15:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnviewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPaymentRegister.CurrentRow != null)
                {
                    if (dgvPaymentRegister.CurrentRow.Cells["dgvtxtpaymentMasterId"].Value != null && dgvPaymentRegister.CurrentRow.Cells["dgvtxtpaymentMasterId"].Value.ToString() != string.Empty)
                    {
                        //frmPaymentVoucher frmPaymentVoucherObj = new frmPaymentVoucher();
                        //frmPaymentVoucher open = Application.OpenForms["frmPaymentVoucher"] as frmPaymentVoucher;
                        decimal decPaymentmasterId = Convert.ToDecimal(dgvPaymentRegister.CurrentRow.Cells["dgvtxtpaymentMasterId"].Value.ToString());

                        // TO DO CALL frmPaymentVoucher 
                        //frmPaymentVoucherObj.CallFromPaymentRegister(this, decPaymentmasterId);

                        //open.MdiParent = formMDI.MDIObj;
                        //open.BringToFront();
                        //open.CallFromPaymentRegister(this, decPaymentmasterId);
                        //if (open.WindowState == FormWindowState.Minimized)
                        //{
                        //    open.WindowState = FormWindowState.Normal;
                        //}

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG16:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
        #region Navigation
        /// <summary>
        /// Enter key navigation
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbAccountLedger.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtFromDate.Focus();
                    txtFromDate.SelectionStart = 0;
                    txtFromDate.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAccountLedger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtVoucherNo.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtToDate.Focus();
                    txtToDate.SelectionStart = 0;
                    txtToDate.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    btnRefresh.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtVoucherNo.Text.Trim() == string.Empty || txtVoucherNo.SelectionStart == 0)
                    {
                        cmbAccountLedger.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Escape key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentRegister_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnviewDetails_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Back)
                {
                    txtVoucherNo.Focus();
                    txtVoucherNo.SelectionStart = txtVoucherNo.TextLength;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PREG22:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
