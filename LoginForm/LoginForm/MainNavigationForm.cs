using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Quotation;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class MainNavigationForm : Form
    {
        IMEEntities IME = new IMEEntities();
        Worker LoggedPerson = new Worker();
        AuthorizationValue Value = new AuthorizationValue();
        public MainNavigationForm()
        {
            InitializeComponent();
        }

        private void lblQuotation_DoubleClick(object sender, EventArgs e)
        {
           
            //Yetkli Kontrolü
            var canEnterModule = from a in IME.AuthorizationValues
                        where a.Workers == LoggedPerson
                        where a.AuthorizationID == 1
                        select a;
            if (canEnterModule!=null)
            {
                LoginForm.Quotation.Quotation quotation = new Quotation.Quotation();
                quotation.Show();
            }
            else
            {
                MessageBox.Show("siktir git");
            }
        }

        private void MainNavigationForm_Load(object sender, EventArgs e)
        {
            //Login olan kullanıcıyı çekilmeli
            label1.Text = WorkerApp.ID.ToString();
            int PersonID = WorkerApp.ID;
            LoggedPerson = IME.Workers.Where(wID => wID.WorkerID == PersonID).FirstOrDefault();
        }
    }
}
