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
using System.Globalization;

//using LoginForm.Quotation;

namespace LoginForm
{
    public partial class FormLogin : Form
    {

        //bool closeRequest = false;

        //private FormMain mainForm;

        IMEEntities IME = new IMEEntities();
        public string LoginPerson { get; set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //DateTime time = Convert.ToDateTime(IME.CurrentDate().First());
            DateTime time = (DateTime)IME.CurrentDate().First();
            #region LoginBlock
            string UserName = txtID.Text;
            string PW = Utils.MD5Hash(txtPassWord.Text);
            Worker Logged = new Worker();
            //try
            //{
                Logged = IME.Workers
               .Where(uName => uName.UserName == UserName)
               .Where(pw => pw.UserPass == PW)
               //.Where(status => status.isActive == 1)
               .FirstOrDefault();
            //}
            //catch (Exception ex)
            //{

            //}

            //WorkerApp.ID = Logged.WorkerID;
            if (Logged != null)
            {
                if(Logged.isActive == 1)
                {
                    Utils.setCurrentUser(Logged);
                    FormMain formMain = new FormMain();
                    this.Hide();
                    formMain.ShowDialog();
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
            #endregion
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtID.Focus();
            CultureInfo culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
           
            //
            ////for admin to see everything
            //RoleValue admin = IME.RoleValues.Where(a => a.RoleID == 1009).FirstOrDefault();
            //foreach (AuthorizationValue item in IME.AuthorizationValues)
            //{
            //    if (admin.AuthorizationValues.Where(a => a.AuthorizationID == item.AuthorizationID).FirstOrDefault() == null)
            //    {
            //        admin.AuthorizationValues.Add(item);
            //    }
            //}
            //IME.SaveChanges();

            //txtReader.excelCustomerCategory1();
            //Rate DolarRate1 = new Rate();
            //DolarRate1 = IME.Rates.Where(a => a.rate_date == DateTime.Today.Date).FirstOrDefault();
            //if (DolarRate1 == null)
            //{
            //    ExchangeService DailyDolar = new ExchangeService();
            //    Rate DolarRate = new Rate();
            //    classExchangeRate RateForDolar = new classExchangeRate();
            //    RateForDolar = DailyDolar.GetExchangeRateforDolar();
            //    DolarRate.CurType = RateForDolar.Code;
            //    DolarRate.RateBuy = RateForDolar.ExchangeBuy;
            //    DolarRate.RateSell = RateForDolar.ExchangeSell;
            //    DolarRate.RateSellEffective = RateForDolar.ExchangeSellEffective;
            //    DolarRate.RateBuyEffective = RateForDolar.ExchangeBuyEffective;
            //    DolarRate.rate_date = Convert.ToDateTime(IME.CurrentDate().First()).Date;
            //    IME.Rates.Add(DolarRate);
            //    IME.SaveChanges();
            //    Rate SterlinRate = new Rate();
            //    classExchangeRate RateforSterlin = new classExchangeRate();
            //    RateforSterlin = DailyDolar.GetExchangeRateforSterlin();
            //    SterlinRate.CurType = RateforSterlin.Code;
            //    SterlinRate.RateBuy = RateforSterlin.ExchangeBuy;
            //    SterlinRate.RateSell = RateforSterlin.ExchangeSell;
            //    SterlinRate.RateSellEffective = RateforSterlin.ExchangeSellEffective;
            //    SterlinRate.RateBuyEffective = RateforSterlin.ExchangeBuyEffective;
            //    SterlinRate.rate_date = Convert.ToDateTime(IME.CurrentDate().First()).Date;
            //    IME.Rates.Add(SterlinRate);
            //    IME.SaveChanges();
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }
    }
}
