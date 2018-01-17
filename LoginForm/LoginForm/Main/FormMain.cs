using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;

namespace LoginForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnLoader_Click(object sender, EventArgs e)
        {
            controlLoader.BringToFront();
        }

        private void btnDevelopment_Click(object sender, EventArgs e)
        {
            controlDevelopment.BringToFront();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            checkAuthorities();
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            controlManagement.BringToFront();
        }

        public void setManagementControl()
        {
            controlManagement.setManagementModule(Utils.getManagement());
        }
        
        public void checkAuthorities()
        {
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1009).Count() <= 0)
            {
                btnManagement.Visible = false;
            }
            else
            {
                btnManagement.Visible = true;
                setManagementControl();
            }

            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1007).Count() <= 0)
            {
                btnLoader.Visible = false;
            }
            else
            {
                btnLoader.Visible = true;
            }
        }

        private void btnAccounting_Click(object sender, EventArgs e)
        {
            controlAccounting.BringToFront();
        }

        private void btnBudgetMasterPayroll_Click(object sender, EventArgs e)
        {
            controlBudgetMasterPayroll.BringToFront();
        }

        private void btnRegisterReminderSearchOther_Click(object sender, EventArgs e)
        {
            controlRegisterReminderSearchOther.BringToFront();
        }

        private void brnTransactionsReports_Click(object sender, EventArgs e)
        {
            controlTransactionsReports.BringToFront();
        }
    }
}
