using LoginForm.ItemModule;
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
using LoginForm.Account;

namespace LoginForm.CustomControls
{
    public partial class RegistersControl : UserControl
    {
        public RegistersControl()
        {
            InitializeComponent();
        }

        private void btnCreditNoteRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmCreditNoteRegister", "View"))
                //{
                    frmCreditNoteRegister objCreditNoteRegister = new frmCreditNoteRegister();
                    frmCreditNoteRegister open = Application.OpenForms["frmCreditNoteRegister"] as frmCreditNoteRegister;
                    if (open == null)
                    {
                        //objCreditNoteRegister.MdiParent = this;
                        objCreditNoteRegister.Show();
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
                MessageBox.Show("MDI 139: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDebitNoteRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmDebitNoteRegister", "View"))
                //{
                    frmDebitNoteRegister objDebitNoteRegister = new frmDebitNoteRegister();
                    frmDebitNoteRegister open = Application.OpenForms["frmDebitNoteRegister"] as frmDebitNoteRegister;
                    if (open == null)
                    {
                        //objDebitNoteRegister.MdiParent = this;
                        objDebitNoteRegister.Show();
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
                MessageBox.Show("MDI 140: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnJournalRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmJournalRegister", "View"))
                //{
                    frmJournalRegister objJournalRegister = new frmJournalRegister();
                    frmJournalRegister open = Application.OpenForms["frmJournalRegister"] as frmJournalRegister;
                    if (open == null)
                    {
                        //objJournalRegister.MdiParent = this;
                        objJournalRegister.Show();
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
                MessageBox.Show("MDI 124: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPaymentRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmPaymentRegister", "View"))
                //{
                    frmPaymentRegister objPaymentRegister = new frmPaymentRegister();
                    frmPaymentRegister open = Application.OpenForms["frmPaymentRegister"] as frmPaymentRegister;
                    if (open == null)
                    {
                        //objPaymentRegister.MdiParent = this;
                        objPaymentRegister.Show();
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
                MessageBox.Show("MDI 122: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPdcClearanceRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmPdcClearanceRegister", "View"))
                //{
                    frmPdcClearanceRegister frm = new frmPdcClearanceRegister();
                    frmPdcClearanceRegister open = Application.OpenForms["frmPdcClearanceRegister"] as frmPdcClearanceRegister;
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
                MessageBox.Show("MDI 185: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPDCPayableRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmPDCPayableRegister", "View"))
                //{
                    frmPDCPayableRegister objPDCPayableRegister = new frmPDCPayableRegister();
                    frmPDCPayableRegister open = Application.OpenForms["frmPDCPayableRegister"] as frmPDCPayableRegister;
                    if (open == null)
                    {
                        //objPDCPayableRegister.MdiParent = this;
                        objPDCPayableRegister.Show();
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
                MessageBox.Show("MDI 125: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPDCReceivableRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmPDCReceivableRegister", "View"))
                //{
                    frmPDCReceivableRegister objPDCReceivableRegister = new frmPDCReceivableRegister();
                    frmPDCReceivableRegister open = Application.OpenForms["frmPDCReceivableRegister"] as frmPDCReceivableRegister;
                    if (open == null)
                    {
                        //objPDCReceivableRegister.MdiParent = this;
                        objPDCReceivableRegister.Show();
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
                MessageBox.Show("MDI 126: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReceiptRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmReceiptRegister", "View"))
                //{
                    frmReceiptRegister objReceiptRegister = new frmReceiptRegister();
                    frmReceiptRegister open = Application.OpenForms["frmReceiptRegister"] as frmReceiptRegister;
                    if (open == null)
                    {
                        //objReceiptRegister.MdiParent = this;
                        objReceiptRegister.Show();
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
                MessageBox.Show("MDI 123: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnServiceVoucherRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmServiceVoucherRegister", "View"))
                //{
                    frmServiceVoucherRegister objServiceVoucherRegister = new frmServiceVoucherRegister();
                    frmServiceVoucherRegister open = Application.OpenForms["frmServiceVoucherRegister"] as frmServiceVoucherRegister;
                    if (open == null)
                    {
                        //objServiceVoucherRegister.MdiParent = this;
                        objServiceVoucherRegister.Show();
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
                MessageBox.Show("MDI 138: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
