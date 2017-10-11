using System;
using LoginForm.Services;
using LoginForm.DataSet;
using LoginForm.WorkerManagement;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace LoginForm.RolesAndAuths
{
    //public partial class FormRoles : MaterialForm
    public partial class FormRoles : Form
    {
        public FormRoles()
        {
            InitializeComponent();

            //var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

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

        public void LoadWorkerList()
        {
            //dgWorkerList.DataSource = AuthorizationService.getWorkers();
            dgdg.DataSource = AuthorizationService.getWorkers();
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
            RoleValue role = new RoleValue();
            role.roleName = txtRoleName.Text;
            AuthorizationService.AddRole(role);
            LoadCBRoleList();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            FormWorkerManagement formWorkerAdd = new FormWorkerManagement();
            formWorkerAdd.ShowDialog();
        }

        private void btnEditWorker_Click(object sender, EventArgs e)
        {
            FormWorkerManagement formWorkerAdd = new FormWorkerManagement((Worker)dgdg.CurrentRow.DataBoundItem, this);
            formWorkerAdd.Show();
        }
    }
}
