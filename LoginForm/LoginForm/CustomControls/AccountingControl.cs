using System;
using System.Windows.Forms;

namespace LoginForm.CustomControls
{
    public partial class AccountingControl : UserControl
    {
        FormMain parent;
        public AccountingControl()
        {
            InitializeComponent();
        }

        private void btnAccountGroup_Click(object sender, EventArgs e)
        {
            frmAccountGroup form = new frmAccountGroup();
            form.ShowDialog();
        }

        private void btnAccountLedger_Click(object sender, EventArgs e)
        {
            frmAccountLedger form = new frmAccountLedger();
            form.ShowDialog();
        }

        private void btnExchangeRate_Click(object sender, EventArgs e)
        {
            frmExchangeRate form = new frmExchangeRate();
            form.ShowDialog();
        }

        private void btnTax_Click(object sender, EventArgs e)
        {
            frmTax form = new frmTax();
            form.ShowDialog();
        }

        private void btnVoucherType_Click(object sender, EventArgs e)
        {
            frmVoucherType form = new frmVoucherType();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCurrency form = new frmCurrency();
            form.ShowDialog();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            frmArea form = new frmArea();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmJournalVoucher form = new frmJournalVoucher();
            form.ShowDialog();
        }

        private void btnSalesInvoice_Click(object sender, EventArgs e)
        {
            frmSalesInvoice form = new frmSalesInvoice();
            form.ShowDialog();
        }

        private void btnBudgets_Click(object sender, EventArgs e)
        {
            parent.subControlBudget.Visible = true;
            parent.CurrentNavTabLvl2 = parent.subControlBudget;
        }

        private void AccountingControl_Load(object sender, EventArgs e)
        {
            this.parent = (FormMain)ParentForm;
        }
    }
}
