using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm.CustomControls
{
    public partial class AccountingControl : NavigationControl
    {

        public AccountingControl()
        {
            InitializeComponent();
            idleButtonColor = btnBudgets.BackColor;
            pressedButtonColor = btnBudgets.FlatAppearance.MouseOverBackColor;
        }
        private void ButtonClick(Button button, UserControl subControl)
        {
            ChangeToDefaultDesign();
            pressedButton = button;

            button.BackColor = pressedButtonColor;
            subControl.Visible = true;
            parent.CurrentNavTabLvl2 = subControl;
        }

        private void btnBudgets_Click(object sender, EventArgs e)
        {
            ButtonClick((Button)sender, parent.subControlBudget);
        }

        private void btnReminders_Click(object sender, EventArgs e)
        {

        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void btnFinancialStatements_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnOthers_Click(object sender, EventArgs e)
        {

        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {

        }

        private void btnMasters_Click(object sender, EventArgs e)
        {

        }
    }
}
