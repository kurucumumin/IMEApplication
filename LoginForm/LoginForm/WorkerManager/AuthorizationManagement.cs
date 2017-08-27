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

namespace LoginForm.WorkerManager
{
    
    public partial class AuthorizationManagement : Form
    {
        AuthorizationService AuthorizationManager = new AuthorizationService();
        WorkerService WorkerService = new WorkerService();
        
        public AuthorizationManagement()
        {
            InitializeComponent();
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Worker AutWorker = cbUser.SelectedItem as Worker;
            lstAddAuthorization.DataSource = AuthorizationManager.GetAvailAuthorization(AutWorker);
            lstAddAuthorization.DisplayMember = "AuthorizationValue1";
            lstAddAuthorization.ValueMember = "AuthorizationID";
            dgAuthorizations.DataSource= AuthorizationManager.GetUserAuthorization(AutWorker);
           

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
            //Aktif Değil Burası Çalıştırmayın Beyler.

            AuthorizationValue AutValue = lstAddAuthorization.SelectedItem as AuthorizationValue;
            Worker AutWorker = cbUser.SelectedItem as Worker;
            AutValue.Workers.Add(AutWorker);
            AuthorizationManager.AddNewAuthorization(AutValue);
            lstAddAuthorization.DataSource = AuthorizationManager.GetAvailAuthorization(AutWorker);
            
            dgAuthorizations.DataSource = AuthorizationManager.GetUserAuthorization(AutWorker);
        }
    }
}
