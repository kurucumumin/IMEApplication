using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Services;
using LoginForm.DataSet;
using LoginForm.RolesAndAuths;
using LoginForm.QuotationModule;

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
    }
}
