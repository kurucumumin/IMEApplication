using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;

namespace LoginForm
{
    public partial class FormMain : Form
    {
        public static FormMain MDIObj;
        public static string strEstimateCompanyPath = string.Empty;
        public static bool isEstimateDB = false;
        public static bool demoProject = false;

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
            //controlDevelopment.checkAuthorities();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            checkAuthorities();
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            controlManagement.BringToFront();
            //controlManagement.checkAuthorities();
        }

        public void setManagementControl()
        {
            controlManagement.setManagementModule(Utils.getManagement());
        }
        
        public void checkAuthorities()
        {
            List<DataSet.AuthorizationValue> authList = Utils.getCurrentUser().AuthorizationValues.ToList();
            if (authList.Where(a => a.AuthorizationID == 1024).Count() <= 0)
            {
                btnManagement.Visible = false;
            }
            else
            {
                btnManagement.Visible = true;
                setManagementControl();
            }

            if (authList.Where(a => a.AuthorizationID == 1022).Count() <= 0)
            {
                btnLoader.Visible = false;
            }
            else
            {
                btnLoader.Visible = true;
            }

            if (authList.Where(a => a.AuthorizationID == 1023).Count() <= 0)
            {
                btnDevelopment.Visible = false;
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
