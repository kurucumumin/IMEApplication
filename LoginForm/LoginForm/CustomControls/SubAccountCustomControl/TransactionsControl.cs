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
    public partial class TransactionsControl : UserControl
    {
        public TransactionsControl()
        {
            InitializeComponent();
        }

        private void btnBankReconciliation_Click(object sender, EventArgs e)
        {
            try
            {
                frmBankReconciliation frm = new frmBankReconciliation();
                frmBankReconciliation open = Application.OpenForms["frmBankReconciliation"] as frmBankReconciliation;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 103: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBillAllocation_Click(object sender, EventArgs e)
        {
            try
            {
                frmBillallocation objBillallocation = new frmBillallocation();
                frmBillallocation open = Application.OpenForms["frmBillallocation"] as frmBillallocation;
                if (open == null)
                {
                    //objBillallocation.MdiParent = this;
                    objBillallocation.Show();
                }
                else
                {
                    open.Activate();
                    if (open.WindowState == FormWindowState.Minimized)
                    {
                        open.WindowState = FormWindowState.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 213 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreditNote_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmCreditNote))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strCreditNote = "Credit Note";
                    frm.CallFromVoucherMenu(strCreditNote);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 116: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDebitNote_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmDebitNote))
                    {
                        frm.Activate();
                        IsActivate = true;
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strDebitVoucherType = "Debit Note";
                    frm.CallFromVoucherMenu(strDebitVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 117: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnJournalVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmJournalVoucher))
                    {
                        frm.Activate();
                        IsActivate = true;
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strJournalVoucherType = "Journal Voucher";
                    frm.CallFromVoucherMenu(strJournalVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 101: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPaymentVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmPaymentVoucher))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strDailyVoucherType = "Payment Voucher";
                    frm.CallFromVoucherMenu(strDailyVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 98 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPdcClearance_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmPdcClearance))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strDailyVoucherType = "PDC Clearance";
                    frm.CallFromVoucherMenu(strDailyVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 210: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPdcPayable_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmPdcPayable))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strDailyVoucherType = "PDC Payable";
                    frm.CallFromVoucherMenu(strDailyVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 99 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPdcReceivable_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmPdcReceivable))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strDailyVoucherType = "PDC Receivable";
                    frm.CallFromVoucherMenu(strDailyVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 102 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmPurchaseInvoice))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strVoucherType = "Purchase Invoice";
                    frm.CallFromVoucherMenu(strVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 107 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPurchaseReturn_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmPurchaseReturn))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strDailyVoucherType = "Purchase Return";
                    frm.CallFromVoucherMenu(strDailyVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 108: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReceiptVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmReceiptVoucher))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strVoucherType = "Receipt Voucher";
                    frm.CallFromVoucherMenu(strVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 100: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeliveryNote_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmDeliveryNote))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strVoucherType = "Sales Invoice";
                    frm.CallFromVoucherMenu(strVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 112: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalesReturn_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmSalesReturn))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strDailyVoucherType = "Sales Return";
                    frm.CallFromVoucherMenu(strDailyVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 113: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnServiceVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmServiceVoucher))
                    {
                        frm.Activate();
                        IsActivate = true;
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (!IsActivate)
                {
                    frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strServiceVoucherType = "Service Voucher";
                    frm.CallFromVoucherMenu(strServiceVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 115: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(frmReceiptVoucher))
                    {
                        form.Activate();
                        IsActivate = true;
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    SaleOrderToDeliveryNote frm = new SaleOrderToDeliveryNote();
                    SaleOrderToDeliveryNote open = Application.OpenForms["frmVoucherTypeSelection"] as SaleOrderToDeliveryNote;
                    if (open == null)
                    {
                        //frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm = open;
                        frm.Activate();
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                    string strVoucherType = "RSInvToSaleInv";
                    //frm.CallFromVoucherMenu(strVoucherType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 100: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
