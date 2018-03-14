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
        private void OpenSubNavigationMenu(Button button, UserControl subControl)
        {
            FormMain parent = this.ParentForm as FormMain;
            if (parent.CurrentNavTabLvl2 != null && parent.CurrentNavTabLvl2.Visible == true)
            {
                parent.CurrentNavTabLvl2.Visible = false;
                parent.CurrentNavTabLvl2 = null;
            }

            ChangeToDefaultDesign();
            pressedButton = button;

            button.BackColor = pressedButtonColor;
            subControl.Visible = true;
            parent.CurrentNavTabLvl2 = subControl;
        }

        private void btnBudgets_Click(object sender, EventArgs e)
        {
            OpenSubNavigationMenu((Button)sender, parent.subControlBudget);
        }

        private void btnFinancialStatements_Click(object sender, EventArgs e)
        {
            OpenSubNavigationMenu((Button)sender, parent.subControlFinancialStatement);
        }
    }
}
