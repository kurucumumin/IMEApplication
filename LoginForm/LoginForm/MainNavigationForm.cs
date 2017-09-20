using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using LoginForm.Quotation;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class MainNavigationForm : Form
    {
        IMEEntities IME = new IMEEntities();

        Worker LoggedPerson = new Worker();
        AuthorizationValue Value = new AuthorizationValue();
        List<AuthorizationValue> auth = new List<AuthorizationValue>();
        public MainNavigationForm()
        {
            InitializeComponent();
        }

        private void lblQuotation_DoubleClick(object sender, EventArgs e)
        {

            //Yetkli Kontrolü
            bool Login = canLog(LoggedPerson,"Worker Manager2");
           
            //if (Login)
            //{
            //    LoginForm.Quotation.Quotation quotation = new Quotation.Quotation();
            //    quotation.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Insufficient Previleges.");
            //}
        }

        private void MainNavigationForm_Load(object sender, EventArgs e)
        {
            //Login olan kullanıcıyı çekilmeli
            label1.Text = WorkerApp.ID.ToString();
            int PersonID = WorkerApp.ID;
            LoggedPerson = IME.Workers.Where(wID => wID.WorkerID == PersonID).FirstOrDefault();
        }

        public bool canLog(Worker Person,string AuthorizationValue)
        {
            //Sonuç Çeken Sorgu
            var result = (from m in IME.AuthorizationValues
                          from b in m.Workers
                          where b.WorkerID == Person.WorkerID
                          where m.AuthorizationValue1 == AuthorizationValue
                          select new
                          {
                              m.AuthorizationValue1
                          }).Count();
            int a = result;


            if (a >= 1)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            bool Login = canLog(LoggedPerson, "Worker Manager");

            if (Login)
            {
                LoginForm.WorkerManager.AddIMEWorker WorkerPage = new WorkerManager.AddIMEWorker();
                WorkerPage.Show();
            }
            else
            {
                MessageBox.Show("Insufficient Previleges.");
            }
        }
    }
}
