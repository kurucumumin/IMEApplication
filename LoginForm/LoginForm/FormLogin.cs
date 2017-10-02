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
//using LoginForm.Quotation;


namespace LoginForm
{
    public partial class FormLogin : Form
    {

        bool closeRequest = false;

        IMEEntities IME = new IMEEntities();
        public Worker Logged;
        public string LoginPerson { get; set; }


        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region LoginBlock
            string UserName = txtID.Text;
            string PW = txtPassWord.Text;
            Worker Logged = new Worker();
            try
            {
                Logged = IME.Workers
               .Where(uName => uName.FirstName == UserName)
               .Where(pw => pw.LastName == PW)
               //.Where(status => status.isActive == 1)
               .FirstOrDefault();
            }
            catch (Exception)
            {
                 
            }
           
            //WorkerApp.ID = Logged.WorkerID;
            if (Logged != null)
            {
                if(Logged.isActive == 1)
                {
                    closeRequest = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your profile is not active", "Login Error", MessageBoxButtons.OK);
                }
                
            }
            else
            {
                MessageBox.Show("Wrong ID or Password","Login Error",MessageBoxButtons.OK);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ExchangeService DailyDolar = new ExchangeService();
            Rate DolarRate = new Rate();
            ExchangeRate RateForDolar = new ExchangeRate();
            RateForDolar = DailyDolar.GetExchangeRateforDolar();
            DolarRate.CurType = RateForDolar.Code;
            DolarRate.RateBuy = RateForDolar.ExchangeBuy;
            DolarRate.RateSell = RateForDolar.ExchangeSell;
            DolarRate.RateSellEffective = RateForDolar.ExchangeSellEffective;
            DolarRate.RateBuyEffective = RateForDolar.ExchangeBuyEffective;
            DolarRate.rate_date = DateTime.Now.Date;
            IME.Rates.Add(DolarRate);
            IME.SaveChanges();

            Rate SterlinRate = new Rate();
            ExchangeRate RateforSterlin = new ExchangeRate();
            RateforSterlin = DailyDolar.GetExchangeRateforSterlin();
            SterlinRate.CurType = RateforSterlin.Code;
            SterlinRate.RateBuy = RateforSterlin.ExchangeBuy;
            SterlinRate.RateSell = RateforSterlin.ExchangeSell;
            SterlinRate.RateSellEffective = RateforSterlin.ExchangeSellEffective;
            SterlinRate.RateBuyEffective = RateforSterlin.ExchangeBuyEffective;
            SterlinRate.rate_date = DateTime.Now.Date;
            label6.Text = SterlinRate.RateBuyEffective.ToString();
            label5.Text = SterlinRate.RateSellEffective.ToString();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!closeRequest)
            {
                base.OnFormClosing(e);
                if (e.CloseReason == CloseReason.WindowsShutDown) return;

                switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        closeRequest = true;
                        Application.Exit();
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    AddIMEWorker workerform = new AddIMEWorker();
        //    AuthorizationManagement manager = new AuthorizationManagement();
        //    manager.Show();
        //    //workerform.Show();
        //}
    }

    
}
