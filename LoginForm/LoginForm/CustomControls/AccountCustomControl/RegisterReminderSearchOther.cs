using LoginForm.Account;
using System;
using System.Windows.Forms;

namespace LoginForm.CustomControls
{
    public partial class RegisterReminderSearchOther : UserControl
    {
        public RegisterReminderSearchOther()
        {
            InitializeComponent();
        }

        private void btnDebitNoteRegister_Click(object sender, EventArgs e)
        {
            frmDebitNoteRegister form = new frmDebitNoteRegister();
            form.ShowDialog();
        }

        private void btnJournalRegister_Click(object sender, EventArgs e)
        {
            frmJournalRegister form = new frmJournalRegister();
            form.ShowDialog();
        }

        private void btnPaymentRegister_Click(object sender, EventArgs e)
        {
            frmPaymentRegister form = new frmPaymentRegister();
            form.ShowDialog();
        }

        private void btnPdcClearanceRegister_Click(object sender, EventArgs e)
        {
            frmPdcClearanceRegister form = new frmPdcClearanceRegister();
            form.ShowDialog();
        }

        private void btnPDCPayableRegister_Click(object sender, EventArgs e)
        {
            frmPDCPayableRegister form = new frmPDCPayableRegister();
            form.ShowDialog();
        }

        private void btnPDCReceivableRegister_Click(object sender, EventArgs e)
        {
            frmPDCReceivableRegister form = new frmPDCReceivableRegister();
            form.ShowDialog();
        }

        private void btnReceiptRegister_Click(object sender, EventArgs e)
        {
            frmReceiptRegister form = new frmReceiptRegister();
            form.ShowDialog();
        }

        private void btnOverduePurchaseOrder_Click(object sender, EventArgs e)
        {
            frmOverduePurchaseOrder form = new frmOverduePurchaseOrder();
            form.ShowDialog();
        }

        private void btnOverdueSalesOrder_Click(object sender, EventArgs e)
        {
            frmOverdueSalesOrder form = new frmOverdueSalesOrder();
            form.ShowDialog();
        }

        private void btnReminderPopUp_Click(object sender, EventArgs e)
        {
            frmReminderPopUp form = new frmReminderPopUp();
            form.ShowDialog();
        }

        private void btnShortExpiry_Click(object sender, EventArgs e)
        {
            frmShortExpiry form = new frmShortExpiry();
            form.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmStock form = new frmStock();
            form.ShowDialog();
        }

        private void btnVoucherSearch_Click(object sender, EventArgs e)
        {
            frmVoucherSearch form = new frmVoucherSearch();
            form.ShowDialog();
        }

        private void btnLedgerPopup_Click(object sender, EventArgs e)
        {
            frmLedgerPopup form = new frmLedgerPopup();
            form.ShowDialog();
        }

        private void btnCreditNoteRegister_Click(object sender, EventArgs e)
        {
            frmCreditNoteRegister form = new frmCreditNoteRegister();
            form.ShowDialog();
        }
    }
}
