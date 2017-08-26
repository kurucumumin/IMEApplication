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

namespace LoginForm.WorkerManager
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
                    Worker2Add.EMail = txtEmail.Text;
                    #region AddNewWorker
                    try
                    {

                        Worker2Add.FirstName = txtFirstName.Text;
                        Worker2Add.LastName = txtFirstName.Text;

                        Worker2Add.Phone = txtPhone.Text;
                        bool isDuplidateWorker = WorkerService.WarnDuplicateRecord(Worker2Add);
                       
                        if (isDuplidateWorker)
                        {
                            MessageBox.Show("The Worker Already Exist.");
                        }
                        else
                        {
                            WorkerService.AddNewWorker(Worker2Add);
                            #region PrintingResult
                            label5.Visible = true;
                            label5.Text = "Successfull Added New Worker";
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
            List<Worker> Workers = new List<Worker>();
            Workers = WorkerService.GetWorkers();
            lstWorker.DataSource = Workers;
            lstWorker.DisplayMember = "Email";
            lstWorker.ValueMember = "WorkerID";
            #endregion


        }

        private void AddIMEWorker_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            #region PumpWorker->Listbox
            List<Worker> Workers = new List<Worker>();
            Workers = WorkerService.GetWorkers();
            lstWorker.DataSource = Workers;
            lstWorker.DisplayMember = "Email";
            lstWorker.ValueMember = "WorkerID";
            #endregion

        }

        private void lstWorker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstWorker_Click(object sender, EventArgs e)
        {
            #region FillTextBoxDetails
            Worker DetailWorker = new Worker();
            Worker DisplayWorker = new Worker();
            DetailWorker = lstWorker.SelectedItem as Worker;
            DisplayWorker = WorkerService.GetWorkersbyID(DetailWorker.WorkerID);
            txtEmail.Text = DisplayWorker.EMail;
            txtFirstName.Text = DisplayWorker.FirstName;
            txtLastName.Text = DisplayWorker.LastName;
            txtPhone.Text = DisplayWorker.Phone;
            #endregion
        }
    }
}
