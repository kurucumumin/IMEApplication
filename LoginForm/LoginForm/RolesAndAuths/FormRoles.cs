using System;
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
using LoginForm.WorkerManagement;

namespace LoginForm.RolesAndAuths
{
    public partial class FormRoles : Form
    {
        public FormRoles()
        {
            InitializeComponent();
        }

        private void FormRoles_Load(object sender, EventArgs e)
        {
            LoadCBRoleList();
            LoadWorkerList();
        }

        private void LoadCBRoleList()
        {
            cbRoleList.DataSource = AuthorizationService.getRoles();
            cbRoleList.DisplayMember = "roleName";
        }

        private void LoadWorkerList()
        {
            lbWorkerList.DataSource = AuthorizationService.getWorkers();
            lbWorkerList.DisplayMember = "NameLastName";
        }



        private void btnAddAuth_Click(object sender, EventArgs e)
        {
            AuthorizationValue auth = new AuthorizationValue();
            //auth.AuthRole = (AuthRole) cbRoleList.SelectedItem;
            auth.AuthorizationValue1 = txtAuthName.Text;
            AuthorizationService.AddAuthToRole(auth);
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            Role role = new Role();
            role.roleName = txtRoleName.Text;
            AuthorizationService.AddRole(role);
            LoadCBRoleList();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            FormWorkerManagement formWorkerAdd = new FormWorkerManagement();
            formWorkerAdd.ShowDialog();
        }
    }
}
