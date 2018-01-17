using LoginForm.Item;
using System;
using System.Windows.Forms;

namespace LoginForm.CustomControls
{
    public partial class BudgetMasterPayroll : UserControl
    {
        public BudgetMasterPayroll()
        {
            InitializeComponent();
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            frmBudget form = new frmBudget();
            form.ShowDialog();
        }

        private void btnBudgetVariance_Click(object sender, EventArgs e)
        {
            frmBudgetVariance form = new frmBudgetVariance();
            form.ShowDialog();
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

        private void btnArea_Click(object sender, EventArgs e)
        {
            frmArea form = new frmArea();
            form.ShowDialog();
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            frmCurrency form = new frmCurrency();
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

        private void btnAdvancePayment_Click(object sender, EventArgs e)
        {
            frmAdvancePayment form = new frmAdvancePayment();
            form.ShowDialog();
        }

        private void btnBonusDeduction_Click(object sender, EventArgs e)
        {
            frmBonusDeduction form = new frmBonusDeduction();
            form.ShowDialog();
        }

        private void btnPayHead_Click(object sender, EventArgs e)
        {
            frmPayHead form = new frmPayHead();
            form.ShowDialog();
        }
    }
}
