using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LoginForm.CustomControls;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;

namespace LoginForm
{
    public partial class FormMain : MyForm
    {
        public static FormMain MDIObj;
        public static string strEstimateCompanyPath = string.Empty;
        public static bool isEstimateDB = false;
        public static bool demoProject = false;
        public static string strVouchertype;
        private System.Drawing.Color defaultNavButtonColor;

        private NavigationControl CurrentNavTabLvl1;
        public UserControl CurrentNavTabLvl2;

        private Button currentNavButton;

        private void ChangeCurrentNavButton(Button newNavButton)
        {
            if(currentNavButton != null)
            {
                currentNavButton.BackColor = defaultNavButtonColor;
            }
            currentNavButton = newNavButton;
            currentNavButton.BackColor = currentNavButton.FlatAppearance.MouseDownBackColor;
        }

        public FormMain()
        {
            InitializeComponent();
            defaultNavButtonColor = btnFileLoader.BackColor;
        }

        private void btnLoader_Click(object sender, EventArgs e)
        {
            OpenNavTabLvl1(controlLoader, (Button)sender);
        }

        public void OpenNavTabLvl1(NavigationControl NavControlLvl1, Button clickedNavButton)
        {
            ChangeCurrentNavButton(clickedNavButton);

            if (CurrentNavTabLvl2 != null && CurrentNavTabLvl2.Visible == true)
            {
                CurrentNavTabLvl2.Visible = false;
            }

            if (CurrentNavTabLvl1 != null)
            {
                CurrentNavTabLvl1.Visible = false;
                CurrentNavTabLvl1.ChangeToDefaultDesign();
            }
            CurrentNavTabLvl1 = NavControlLvl1;
            CurrentNavTabLvl1.Visible = true;
        }

        private void btnDevelopment_Click(object sender, EventArgs e)
        {
            OpenNavTabLvl1(controlDevelopment, (Button)sender);
            controlDevelopment.parent = this;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            checkAuthorities();
            //lblUserName.Text = "USER: " + Utils.getCurrentUser().NameLastName;
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            ChangeCurrentNavButton((Button)sender);

            if (CurrentNavTabLvl2 != null && CurrentNavTabLvl2.Visible == true)
            {
                CurrentNavTabLvl2.Visible = false;
                CurrentNavTabLvl2 = null;
            }

            if (CurrentNavTabLvl1 != null && CurrentNavTabLvl1.Visible == true)
            {
                CurrentNavTabLvl1.Visible = false;
                CurrentNavTabLvl1 = null;
            }
            CurrentNavTabLvl1 = controlManagement;
            CurrentNavTabLvl1.Visible = true;
        }

        public void setManagementControl()
        {
            controlManagement.setManagementModule(Utils.getManagement());
        }
        
        public void checkAuthorities()
        {
            List<DataSet.AuthorizationValue> authList = Utils.getCurrentUser().AuthorizationValues.ToList();
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeManagementModule))
            {
                btnManagement.Visible = false;
            }
            else
            {
                btnManagement.Visible = true;
                setManagementControl();
            }

            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeLoaderModule))
            {
                btnFileLoader.Visible = false;
            }
            else
            {
                btnFileLoader.Visible = true;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeDevelopmentModule))
            {
                btnDevelopment.Visible = false;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeUserModule))
            {
                controlDevelopment.btnWorker.Visible = false;
            }

        }
    }
}
