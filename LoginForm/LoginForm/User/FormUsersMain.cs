using System;
using LoginForm.Services;
using LoginForm.DataSet;
using LoginForm.ManagementModule;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace LoginForm.User
{
    public partial class FormUserMain : Form
    {
        FormMain mainForm;
        public FormUserMain(FormMain mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void FormRoles_Load(object sender, EventArgs e)
        {
            LoadWorkerList();
        }

        public void LoadWorkerList()
        {
            dgdg.DataSource = AuthorizationService.getWorkers();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            FormWorkerManagement formWorkerAdd = new FormWorkerManagement(this);
            formWorkerAdd.ShowDialog();
        }

        private void btnEditWorker_Click(object sender, EventArgs e)
        {
            FormWorkerManagement formWorkerAdd = new FormWorkerManagement(mainForm, (Worker)dgdg.CurrentRow.DataBoundItem, this);
            formWorkerAdd.Show();
        }
    }
}
