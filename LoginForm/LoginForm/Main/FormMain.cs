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

        private UserControl CurrentNavTabLvl1;
        public UserControl CurrentNavTabLvl2;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnLoader_Click(object sender, EventArgs e)
        {
            OpenNavTabLvl1(controlLoader);
        }

        public void OpenNavTabLvl1(UserControl NavControlLvl1)
        {
            if(CurrentNavTabLvl2 != null && CurrentNavTabLvl2.Visible == true)
            {
                CurrentNavTabLvl2.Visible = false;
            }

            if (CurrentNavTabLvl1 != null)
            {
                CurrentNavTabLvl1.Visible = false;
            }
            CurrentNavTabLvl1 = NavControlLvl1;
            CurrentNavTabLvl1.Visible = true;
        }

        private void btnDevelopment_Click(object sender, EventArgs e)
        {
            OpenNavTabLvl1(controlDevelopment);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            checkAuthorities();
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            OpenNavTabLvl1(controlManagement);
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
            OpenNavTabLvl1(controlAccounting);
        }

        private void btnBudgetMasterPayroll_Click(object sender, EventArgs e)
        {
            OpenNavTabLvl1(controlBudgetMasterPayroll);
        }

        private void btnRegisterReminderSearchOther_Click(object sender, EventArgs e)
        {
            OpenNavTabLvl1(controlRegisterReminderSearchOther);
        }

        private void brnTransactionsReports_Click(object sender, EventArgs e)
        {
            OpenNavTabLvl1(controlTransactionsReports);
        }
        

        
    }
}
