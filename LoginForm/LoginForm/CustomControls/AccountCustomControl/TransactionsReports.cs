using LoginForm.Item;
using Open_Miracle;
using System;
using System.Windows.Forms;

namespace LoginForm.CustomControls
{
    public partial class TransactionsReports : UserControl
    {
        public TransactionsReports()
        {
            InitializeComponent();
        }

        private void btnBankReconciliation_Click(object sender, EventArgs e)
        {
            frmBankReconciliation form = new frmBankReconciliation();
            form.ShowDialog();
        }

        private void btnCreditNote_Click(object sender, EventArgs e)
        {
            frmCreditNote form = new frmCreditNote();
            form.ShowDialog();
        }

        private void btnDebitNote_Click(object sender, EventArgs e)
        {
            frmDebitNote form = new frmDebitNote();
            form.ShowDialog();
        }

        private void btnJournalVoucher_Click(object sender, EventArgs e)
        {
            frmJournalVoucher form = new frmJournalVoucher();
            form.ShowDialog();
        }

        private void btnPaymentVoucher_Click(object sender, EventArgs e)
        {
            frmPaymentVoucher form = new frmPaymentVoucher();
            form.ShowDialog();
        }

        private void btnPdcClearance_Click(object sender, EventArgs e)
        {
            frmPdcClearance form = new frmPdcClearance();
            form.ShowDialog();
        }

        private void btnPdcPayable_Click(object sender, EventArgs e)
        {
            frmPdcPayable form = new frmPdcPayable();
            form.ShowDialog();
        }

        private void btnPdcReceivable_Click(object sender, EventArgs e)
        {
            frmPdcReceivable form = new frmPdcReceivable();
            form.ShowDialog();
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            frmPurchaseInvoice form = new frmPurchaseInvoice();
            form.ShowDialog();
        }

        private void btnPurchaseReturn_Click(object sender, EventArgs e)
        {
            frmPurchaseReturn form = new frmPurchaseReturn();
            form.ShowDialog();
        }

        private void btnReceiptVoucher_Click(object sender, EventArgs e)
        {
            frmReceiptVoucher form = new frmReceiptVoucher();
            form.ShowDialog();
        }

        private void btnSalesInvoice_Click(object sender, EventArgs e)
        {
            frmSalesInvoice form = new frmSalesInvoice();
            form.ShowDialog();
        }

        private void btnSalesReturn_Click(object sender, EventArgs e)
        {
            frmSalesReturn form = new frmSalesReturn();
            form.ShowDialog();
        }

        private void btnCreditNoteReport_Click(object sender, EventArgs e)
        {
            frmCreditNoteReport form = new frmCreditNoteReport();
            form.ShowDialog();
        }

        private void btnJournalReport_Click(object sender, EventArgs e)
        {
            frmJournalReport form = new frmJournalReport();
            form.ShowDialog();
        }

        private void btnPaymentReport_Click(object sender, EventArgs e)
        {
            frmPaymentReport form = new frmPaymentReport();
            form.ShowDialog();
        }

        private void btnPDCClearanceReport_Click(object sender, EventArgs e)
        {
            frmPDCClearanceReport form = new frmPDCClearanceReport();
            form.ShowDialog();
        }

        private void btnPDCPayableReport_Click(object sender, EventArgs e)
        {
            frmPDCPayableReport form = new frmPDCPayableReport();
            form.ShowDialog();
        }

        private void btnPDCRecievableReport_Click(object sender, EventArgs e)
        {
            frmPDCRecievableReport form = new frmPDCRecievableReport();
            form.ShowDialog();
        }

        private void btnReceiptReport_Click(object sender, EventArgs e)
        {
            frmReceiptReport form = new frmReceiptReport();
            form.ShowDialog();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            frmSalesReport form = new frmSalesReport();
            form.ShowDialog();
        }

        private void btnSalesReturnReport_Click(object sender, EventArgs e)
        {
            frmSalesReturnReport form = new frmSalesReturnReport();
            form.ShowDialog();
        }

        //private void btn_Click(object sender, EventArgs e)
        //{
        //     form = new ();
        //    form.ShowDialog();
        //}
    }
}
