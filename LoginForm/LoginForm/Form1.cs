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
using LoginForm.Quotation;


namespace LoginForm
{
    public partial class Form1 : Form
    {
        IMEEntities IME = new IMEEntities();
        public Worker Logged;
        public string LoginPerson { get; set; }
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region LoginBlock
            string UserName = txtID.Text;
            string PW = txtPassWord.Text;
            Worker Logged = IME.Workers
                .Where(uName => uName.FirstName == UserName)
                .Where(pw => pw.LastName == PW)
                .FirstOrDefault();
            WorkerApp.ID = Logged.WorkerID;
            if (Logged != null)
            {
                MainNavigationForm mainNavi = new MainNavigationForm();
                mainNavi.Show();
            }
            else
            {
                MessageBox.Show("Wrong ID or Password");
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
