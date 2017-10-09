using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;
using LoginForm.Services;

namespace LoginForm
{
    public partial class AddIMEWorker : Form
    {
        WorkerService WorkerService = new WorkerService();
        public AddIMEWorker()
        {
            InitializeComponent();
        }

        private void btnSaveWorker_Click(object sender, EventArgs e)
        {
            Worker Worker2Add = new Worker();

            #region NewWorkerBlock
            if (txtEmail.Text.Contains("@"))
            {
                if (txtEmail.Text.Contains(".com"))
                {
                    Worker2Add.Email = txtEmail.Text;
                    #region AddNewWorker
                    try
                    {

                        Worker2Add.NameLastName = txtFirstName.Text;
                        Worker2Add.UserPass = txtLastName.Text;

                        Worker2Add.Phone = txtPhone.Text;
                        bool isDuplidateWorker = WorkerService.WarnDuplicateRecord(Worker2Add);
                       
                        if (isDuplidateWorker)
                        {
                            MessageBox.Show("The Worker Already Exist.");
                        }
                        else
                        {
                            Worker2Add.isActive = 1;
                            //Worker2Add.isActive = "A";
                            WorkerService.AddNewWorker(Worker2Add);
                            #region PrintingResult
                            lblResult.Visible = true;
                            lblResult.Text = "Successfull Added New Worker";
                            #endregion(Worker2Add);
                        }

                    }
                    catch (Exception WorkerException)
                    {

                        MessageBox.Show(WorkerException.InnerException.Message);
                    }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Please provide a valid e-mail adress");
            }
            #endregion
            #region RefreshListBox
      
          lbWorkerList.DataSource= WorkerService.GetWorkers();
           
            lbWorkerList.DisplayMember = "Email";
            lbWorkerList.ValueMember = "WorkerID";
            #endregion
        }

        private void AddIMEWorker_Load(object sender, EventArgs e)
        {
            lblResult.Visible = false;
            #region PumpWorker->Listbox
            List<Worker> Workers = new List<Worker>();
            Workers = WorkerService.GetWorkers();
            lbWorkerList.DataSource = Workers;
            lbWorkerList.DisplayMember = "Email";
            lbWorkerList.ValueMember = "WorkerID";
            #endregion
            formIsEditMode(false);

        }

        private void lbWorkerList_Click(object sender, EventArgs e)
        {
            if (lbWorkerList.Items.Count >0)
            {
                #region FillTextBoxDetails
                Worker DetailWorker = new Worker();
                Worker DisplayWorker = new Worker();
                DetailWorker = lbWorkerList.SelectedItem as Worker;
                DisplayWorker = WorkerService.GetWorkersbyID(DetailWorker.WorkerID);
                txtEmail.Text = DisplayWorker.Email;
                txtFirstName.Text = DisplayWorker.NameLastName;
                txtLastName.Text = DisplayWorker.UserPass;
                txtPhone.Text = DisplayWorker.Phone;
                #endregion
            }
            else
            {
                //MessageBox.Show("There is no Worker Defined in the List");
            }

        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
            Worker Deleted = new Worker();
            Deleted = lbWorkerList.SelectedItem as Worker;
            Deleted.isActive = 0;
            //Deleted.isActive = "I";

            try
            {
                WorkerService.UpdateWorker(Deleted);
                MessageBox.Show("The Worker Deleted.");

            }
            catch (Exception)
            {

                MessageBox.Show("The Operation Could Not Completed.Please Contact Your Consultant.");
            }
            #region RefreshListBox
            List<Worker> Workers = new List<Worker>();
            Workers = WorkerService.GetWorkers();
            lbWorkerList.DataSource = Workers;
            lbWorkerList.DisplayMember = "Email";
            lbWorkerList.ValueMember = "WorkerID";
            #endregion
        }

        private void btnUpdateWorker_Click(object sender, EventArgs e)
        {
            Worker Updated = new Worker();
            Updated = lbWorkerList.SelectedItem as Worker;
            Updated.NameLastName = txtFirstName.Text;
            Updated.UserPass = txtLastName.Text;
            Updated.Email = txtEmail.Text;
            Updated.Phone = txtPhone.Text;
            //Updated.isActive = "A";
            try
            {
                WorkerService.UpdateWorker(Updated);

                MessageBox.Show("The Worker Updadated.");

            }
            catch (Exception)
            {

                MessageBox.Show("The Operation Could Not Completed.Please Contact Your Consultant.");
            }
            finally
            {
                #region RefreshListBox
                List<Worker> Workers = new List<Worker>();
                Workers = WorkerService.GetWorkers();
                lbWorkerList.DataSource = Workers;
                lbWorkerList.DisplayMember = "Email";
                lbWorkerList.ValueMember = "WorkerID";
                #endregion
            }


        }

        private void btnAuthorizationPanel_Click(object sender, EventArgs e)
        {
            AuthorizationManagement management = new AuthorizationManagement();
            management.Show();
        }

        private void formIsEditMode(bool state)
        {
            txtEmail.Enabled = state;
            txtFirstName.Enabled = state;
            txtLastName.Enabled = state;
            txtPhone.Enabled = state;
            btnSaveWorker.Visible = state;
        }

        private void btnNewWorker_Click(object sender, EventArgs e)
        {
            lbWorkerList.ClearSelected();
            lbWorkerList.Enabled = false;
            btnUpdateWorker.Visible = false;
            btnDeleteWorker.Visible = false;
            btnAuthorizationPanel.Visible = false;
            btnNewWorker.Visible = false;

            formIsEditMode(true);
            clearTextBoxes();
            
        }
        private void clearTextBoxes()
        {
            txtEmail.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
        }
    }    
}
