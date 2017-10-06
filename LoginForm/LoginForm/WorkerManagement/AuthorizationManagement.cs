using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{

    public partial class AuthorizationManagement : Form
    {
        AuthorizationService AuthorizationManager = new AuthorizationService();
        WorkerService WorkerService = new WorkerService();
        Worker AutWorker;
        AuthorizationValue AutValue;
        public AuthorizationManagement()
        {
            InitializeComponent();
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Worker AutWorker = cbUser.SelectedItem as Worker;
            //lstAddAuthorization.DataSource = AuthorizationManager.GetAvailAuthorization(AutWorker);
            lstAddAuthorization.DisplayMember = "AuthorizationValue1";
            lstAddAuthorization.ValueMember = "AuthorizationID";
            //dgAuthorizations.DataSource = AuthorizationManager.GetUserAuthorization(AutWorker);


        }

        private void AuthorizationManagement_Load(object sender, EventArgs e)
        {
            cbUser.DataSource = WorkerService.GetWorkers();
            cbUser.DisplayMember = "FirstName";
            cbUser.ValueMember = "WorkerID";
            //lstAddAuthorization.DataSource = AuthorizationManager.Authorizations();




        }

        private void cbUser_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAuthorization_Click(object sender, EventArgs e)
        {
            if (lstAddAuthorization.Items.Count == 0)
            {
                MessageBox.Show("No Authorization Selected to Add");
            }
            else
            {
                AutWorker = cbUser.SelectedItem as Worker;
                AutValue = lstAddAuthorization.SelectedItem as AuthorizationValue;

                //AutValue.Workers.Add(AutWorker);
                int WorkerID = AutWorker.WorkerID;
                int AuthorizationID = AutValue.AuthorizationID;
                AuthorizationManager.Add(AuthorizationID, WorkerID);


                //lstAddAuthorization.DataSource = AuthorizationManager.GetAvailAuthorization(AutWorker);

                //dgAuthorizations.DataSource = AuthorizationManager.GetUserAuthorization(AutWorker);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            try
            {
                int AuthorizationID = Convert.ToInt32(dgAuthorizations.CurrentRow.Cells["AuthorizationID"].Value);

                AutWorker = cbUser.SelectedItem as Worker;
                int WorkerID = AutWorker.WorkerID;
                AuthorizationManager.Delete(AuthorizationID, WorkerID);

                //lstAddAuthorization.DataSource = AuthorizationManager.GetAvailAuthorization(AutWorker);

                //dgAuthorizations.DataSource = AuthorizationManager.GetUserAuthorization(AutWorker);
            }
            catch
            {

                MessageBox.Show("No Authorization Selected");
            }





        }
    }
}
