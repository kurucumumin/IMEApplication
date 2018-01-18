using LoginForm.Invoice;
using LoginForm.nsSaleOrder;
using LoginForm.PurchaseOrder;
using LoginForm.QuotationModule;
using System;
using System.Windows.Forms;
using LoginForm.Account;

namespace LoginForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLedgerPopup());
        }
    }
}
