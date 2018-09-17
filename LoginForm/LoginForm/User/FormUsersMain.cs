using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Drawing;

namespace LoginForm.User
{
    public partial class FormUserMain : MyForm
    {
        Main.frmMainMetro mainForm;
        public FormUserMain(Main.frmMainMetro mainForm)
        {
            InitializeComponent();
            dgdg.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
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
        
        private void btnEditWorker_Click(object sender, EventArgs e)
        {
            FormWorkerManagement formWorkerAdd = new FormWorkerManagement(mainForm, (Worker)dgdg.CurrentRow.DataBoundItem, this);
            formWorkerAdd.ShowDialog();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            FormWorkerManagement formWorkerAdd = new FormWorkerManagement(this);
            formWorkerAdd.ShowDialog();
        }

        private void btnCustomerChange_Click(object sender, EventArgs e)
        {
            FormUserCustomerUpdate form = new FormUserCustomerUpdate();
            form.ShowDialog();
        }
    }
}
