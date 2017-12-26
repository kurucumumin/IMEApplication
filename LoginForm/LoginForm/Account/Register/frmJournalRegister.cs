using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.DataSet;
namespace LoginForm
{
    public partial class frmJournalRegister : Form
    {
        IMEEntities IME = new IMEEntities();
        #region Functions
        /// <summary>
        /// Creates an instance of frmJournalRegister class
        /// </summary>
        public frmJournalRegister()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to fill Dates
        /// </summary>
        public void SetDate()
        {
            try
            {
                txtToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                txtFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                DateTime dt;
                DateTime.TryParse(txtToDate.Text, out dt);
                dtpToDate.Value = dt;
                dtpFromDate.Value = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to reset the controls
        /// </summary>
        public void Reset()
        {
            try
            {
                dtpFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                dtpToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                txtVoucherNo.Text = string.Empty;
                txtFromDate.Focus();
                SearchRegister();
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill Datagridview 
        /// </summary>
        public void SearchRegister()
        {

                if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
                {
                    if (Convert.ToDateTime(txtToDate.Text) < Convert.ToDateTime(txtFromDate.Text))
                    {
                        MessageBox.Show("Todate should be greater than fromdate", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetDate();
                    }
                }
                string strVoucherNo = txtVoucherNo.Text;
                string strToDate = string.Empty;
                string strFromDate = string.Empty;
                if (txtToDate.Text == string.Empty)
                {
                    strToDate = DateTime.Now.ToString();
                }
                else
                {
                    strToDate = txtToDate.Text;
                }
                if (txtFromDate.Text == string.Empty)
                {
                    strFromDate = DateTime.Now.ToString();
                }
                else
                {
                    strFromDate = txtFromDate.Text;
                }
                dgvJournalRegister.DataSource = IME.JournalMasters.Where(b => b.voucherNo.Contains(strVoucherNo)).Where(c => c.date > DateTime.Parse(strFromDate)).Where(d => d.date > DateTime.Parse(strToDate)).ToList().OrderByDescending(e => e.journalMasterId);
        }
        /// <summary>
        /// Function to fill the Dates
        /// </summary>
        public void FinancialYearDate()
        {
            try
            {
                dtpFromDate.MinDate = DateTime.Today.AddMonths(-9);
                dtpFromDate.MaxDate = DateTime.Today.AddMonths(3);
                //CompanyInfo infoComapany = new CompanyInfo();
                //CompanySP spCompany = new CompanySP();
                //infoComapany = spCompany.CompanyView(1);
                //DateTime dtFromDate = infoComapany.CurrentDate;
                //dtpFromDate.Value = dtFromDate;
                //txtFromDate.Text = dtFromDate.ToString("dd-MMM-yyyy");
                dtpFromDate.Value = DateTime.Now;
                txtFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                dtpFromDate.Value = Convert.ToDateTime(txtFromDate.Text);
                dtpToDate.MinDate = DateTime.Today.AddMonths(-9);
                dtpToDate.MaxDate = DateTime.Today.AddMonths(3);
                //infoComapany = spCompany.CompanyView(1);
                //DateTime dtToDate = infoComapany.CurrentDate;
                //dtpToDate.Value = dtToDate;
                //dtpToDate.Text = dtToDate.ToString("dd-MMM-yyyy");
                dtpToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                dtpToDate.Value = Convert.ToDateTime(txtFromDate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG4:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Events
        /// <summary>
        /// On Form Load fills the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJournalRegister_Load(object sender, EventArgs e)
        {
            try
            {
                FinancialYearDate();
                dtpFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                dtpToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                SearchRegister();
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Calls Corresponding voucher for updation on cell double click in Datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJournalRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    btnViewDetails_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Commits edit on CurrentCellDirtyStateChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJournalRegister_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvJournalRegister.IsCurrentCellDirty)
                {
                    dgvJournalRegister.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Calls Corresponding voucher for updation on 'ViewDetails' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            //TO DO open JournalRegister for detail
            //try
            //{
            //    if (dgvJournalRegister.CurrentRow != null)
            //    {
            //        frmJournalVoucher frmJournalVoucherObj = new frmJournalVoucher();
            //        frmJournalVoucher open = Application.OpenForms["frmJournalVoucher"] as frmJournalVoucher;
            //        decimal decMasterId = Convert.ToDecimal(dgvJournalRegister.CurrentRow.Cells["dgvtxtJournalMasterId"].Value.ToString());
            //        if (open == null)
            //        {
            //            frmJournalVoucherObj.WindowState = FormWindowState.Normal;
            //            frmJournalVoucherObj.MdiParent = formMDI.MDIObj;
            //            frmJournalVoucherObj.CallFromJournalRegister(this, decMasterId);
            //        }
            //        else
            //        {
            //            open.MdiParent = formMDI.MDIObj;
            //            open.BringToFront();
            //            open.CallFromJournalRegister(this, decMasterId);
            //            if (open.WindowState == FormWindowState.Minimized)
            //            {
            //                open.WindowState = FormWindowState.Normal;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("JREG8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
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

      
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpFromDate.Value;
                this.txtFromDate.Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("JREG13:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Reset' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG14:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                SearchRegister();
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG15:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Navigation

        private void txtToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtVoucherNo.Focus();
                }
                if (txtToDate.Text == string.Empty || txtToDate.SelectionStart == 0)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        txtFromDate.Focus();
                        txtFromDate.SelectionStart = 0;
                        txtFromDate.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
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
                    txtToDate.SelectionStart = txtToDate.TextLength;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    dgvJournalRegister.Focus();
                }
                if (txtVoucherNo.Text == string.Empty || txtVoucherNo.SelectionStart == 0)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        txtToDate.Focus();
                        txtToDate.SelectionStart = 0;
                        txtToDate.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJournalRegister_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnViewDetails_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Back)
                {
                    txtVoucherNo.Focus();
                    txtVoucherNo.SelectionStart = txtVoucherNo.TextLength;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("JREG20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
