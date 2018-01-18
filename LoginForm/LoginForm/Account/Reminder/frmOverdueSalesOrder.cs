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

namespace LoginForm.Account
{
    public partial class frmOverdueSalesOrder : Form
    {
        #region  Variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        TransactionsGeneralFill TransactionsGeneralFillObj = new TransactionsGeneralFill();
        frmReminderPopUp frmReminderPopupObj;
        #endregion
        #region Functions
        /// <summary>
        /// Creates an instance of  frmOverdueSalesOrder class
        /// </summary>
        public frmOverdueSalesOrder()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to fill Cash/Party combobox
        /// </summary>
        public void AccountLedgerComboFill()
        {
            try
            {
                TransactionsGeneralFillObj.CashOrPartyUnderSundryDrComboFill(cmbAccountLeadger, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ODSO1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill Datagridview
        /// </summary>
        public void OverDueSalesOrderGridFill()
        {
            ReminderSP spReminder = new ReminderSP();
                if (cmbAccountLeadger.SelectedValue!=null && cmbAccountLeadger.SelectedValue.ToString() != "System.Data.DataRowView" && cmbAccountLeadger.Text != "System.Data.DataRowView")
                {
                    decimal decLedgerId = decimal.Parse(cmbAccountLeadger.SelectedValue.ToString());
                    dgvOverdueSalesOrder.DataSource = spReminder.OverdueSalesOrderCorrespondingAccountLedger(decLedgerId);
                }
            
        }
        /// <summary>
        /// Function to call this form from frmReminderPopUp to view details
        /// </summary>
        /// <param name="frmreminder"></param>
        public void CallFromReminder(frmReminderPopUp frmreminder)
        {
            try
            {
                base.Show();
                this.frmReminderPopupObj = frmreminder;
                frmReminderPopupObj.Enabled = false;
                OverDueSalesOrderGridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ODSO3:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Events
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOverdueSalesOrder_Load(object sender, EventArgs e)
        {

                AccountLedgerComboFill();
                OverDueSalesOrderGridFill();
        }
 
        /// <param name="e"></param>
        private void cmbAccountLeadger_SelectedIndexChanged(object sender, EventArgs e)
        {
                OverDueSalesOrderGridFill();
        }
        /// <summary>
        /// Enables the object of other forms on Formclosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOverdueSalesOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (frmReminderPopupObj != null)
                {
                    frmReminderPopupObj.Enabled = true;
                    frmReminderPopupObj.Activate();
                    frmReminderPopupObj.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ODSO6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Close' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnclose_Click(object sender, EventArgs e)
        {
            try
            {
                //if (PublicVariables.isMessageClose)
                //{
                //    Messages.CloseMessage(this);
                //}
                //else
                //{
                    this.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("ODSO7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        # region Navigation
        /// <summary>
        /// Escape key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOverdueSalesOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    //if (PublicVariables.isMessageClose)
                    //{
                    //    Messages.CloseMessage(this);
                    //}
                    //else
                    //{
                        this.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ODSO8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAccountLeadger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnclose.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ODSO9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
