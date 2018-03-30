using LoginForm.Item;
using LoginForm.nsSaleOrder;
using LoginForm.PurchaseOrder;
using LoginForm.QuotationModule;
using LoginForm.User;
using System;
using System.Windows.Forms;
using LoginForm.Services;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using LoginForm.DataSet;

namespace LoginForm.CustomControls
{
    public partial class ReportsControl : UserControl
    {
        public ReportsControl()
        {
            InitializeComponent();
        }

        private void btnAccountGroupReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmAccountGroupReport", "View"))
                //{
                    frmAccountGroupReport frm = new frmAccountGroupReport();
                    frmAccountGroupReport open = Application.OpenForms["frmAccountGroupReport"] as frmAccountGroupReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 180: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAccountLedgerReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmAccountLedgerReport", "View"))
                //{
                    frmAccountLedgerReport frm = new frmAccountLedgerReport();
                    frmAccountLedgerReport open = Application.OpenForms["frmAccountLedgerReport"] as frmAccountLedgerReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 177: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgeingReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmAgeingReport", "View"))
                //{
                    frmAgeingReport frm = new frmAgeingReport();
                    frmAgeingReport open = Application.OpenForms["frmAgeingReport"] as frmAgeingReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 179: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCashBankBook_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmCashBankBookReport", "View"))
                //{
                    frmCashBankBookReport frm = new frmCashBankBookReport();
                    frmCashBankBookReport open = Application.OpenForms["frmCashBankBookReport"] as frmCashBankBookReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 176: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChequeReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmChequeReport", "View"))
                //{
                    frmChequeReport frm = new frmChequeReport();
                    frmChequeReport open = Application.OpenForms["frmChequeReport"] as frmChequeReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 201: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreditNoteReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmCreditNoteReport", "View"))
                //{
                    frmCreditNoteReport frm = new frmCreditNoteReport();
                    frmCreditNoteReport open = Application.OpenForms["frmCreditNoteReport"] as frmCreditNoteReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 188: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDayBook_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmDayBook", "View"))
                //{
                    frmDayBook frm = new frmDayBook();
                    frmDayBook open = Application.OpenForms["frmDayBook"] as frmDayBook;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 175 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnJournalReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmJournalReport", "View"))
                //{
                    frmJournalReport frm = new frmJournalReport();
                    frmJournalReport open = Application.OpenForms["frmJournalReport"] as frmJournalReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 190: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOutstandingReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmOutstandingReport", "View"))
                //{
                    frmOutstandingReport frm = new frmOutstandingReport();
                    frmOutstandingReport open = Application.OpenForms["frmOutstandingReport"] as frmOutstandingReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 178 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPartyAddressBook_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmOutstandingReport", "View"))
                //{
                    frmOutstandingReport frm = new frmOutstandingReport();
                    frmOutstandingReport open = Application.OpenForms["frmOutstandingReport"] as frmOutstandingReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 178 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPaymentReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmPaymentReport", "View"))
                //{
                    frmPaymentReport frm = new frmPaymentReport();
                    frmPaymentReport open = Application.OpenForms["frmPaymentReport"] as frmPaymentReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 187: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPDCClearanceReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmPDCClearanceReport", "View"))
                //{
                    frmPDCClearanceReport frm = new frmPDCClearanceReport();
                    frmPDCClearanceReport open = Application.OpenForms["frmPDCClearanceReport"] as frmPDCClearanceReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 191: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPDCPayableReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmPDCPayableReport", "View"))
                //{
                    frmPDCPayableReport frm = new frmPDCPayableReport();
                    frmPDCPayableReport open = Application.OpenForms["frmPDCPayableReport"] as frmPDCPayableReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 193: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPDCRecievableReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmPDCRecievableReport", "View"))
                //{
                    frmPDCRecievableReport frm = new frmPDCRecievableReport();
                    frmPDCRecievableReport open = Application.OpenForms["frmPDCRecievableReport"] as frmPDCRecievableReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 194: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReceiptReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmReceiptReport", "View"))
                //{
                    frmReceiptReport frmReceptReport = new frmReceiptReport();
                    frmReceiptReport open = Application.OpenForms["frmReceiptReport"] as frmReceiptReport;
                    if (open == null)
                    {
                        //frmReceptReport.MdiParent = this;
                        frmReceptReport.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 196: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmSalesReport", "View"))
                //{
                    frmSalesReport objSalesReport = new frmSalesReport();
                    frmSalesReport open = Application.OpenForms["frmSalesReport"] as frmSalesReport;
                    if (open == null)
                    {
                        //objSalesReport.MdiParent = this;
                        objSalesReport.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 224: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalesReturnReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmSalesReturnReport", "View"))
                //{
                frmSalesReturnReport objSalesReturnReport = new frmSalesReturnReport();
                    frmSalesReturnReport open = Application.OpenForms["frmSalesReturnReport"] as frmSalesReturnReport;
                    if (open == null)
                    {
                        //objSalesReturnReport.MdiParent = this;
                        objSalesReturnReport.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 223: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaxReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmTaxReport", "View"))
                //{
                    frmTaxReport frm = new frmTaxReport();
                    frmTaxReport open = Application.OpenForms["frmTaxReport"] as frmTaxReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 200: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVatReturnReport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmVatReturnReport", "View"))
                //{
                    frmVatReturnReport frm = new frmVatReturnReport();
                    frmVatReturnReport open = Application.OpenForms["frmVatReturnReport"] as frmVatReturnReport;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 204: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
