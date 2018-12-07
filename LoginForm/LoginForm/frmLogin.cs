using Helpers;
using LoginForm.clsClasses;
using LoginForm.DataSet;
using LoginForm.Main;
using LoginForm.Services;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        IMEEntities IME = new IMEEntities();
        public string LoginPerson { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void LoginButtonClick()
        {
            DateTime time = Utils.GetCurrentDateTime();

            #region LoginBlock
            string UserName = txtID.Text;
            string PW = Utils.MD5Hash(txtPassWord.Text);
            string countryLogo = IME.Workers.Where(uName => uName.UserName == UserName).FirstOrDefault().country;
            Worker Logged = new Worker();

            Logged = IME.Workers
           .Where(uName => uName.UserName == UserName).Where(pw => pw.UserPass == PW).FirstOrDefault();

            if (Logged != null)
            {
                if (Logged.isActive == 1)
                {
                    Utils.setCurrentUser(Logged);

                    Utils.User(countryLogo, PW);

                    Utils.LogKayit("Login", "Login form screen has been entered");

                    frmMainMetro formMain = new frmMainMetro();
                    this.Hide();
                    formMain.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User '"+ UserName + "' is passive. Please contact with Administration", "Login Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Wrong ID or Password", "Login Error", MessageBoxButtons.OK);
                txtID.Text = "";
                txtPassWord.Text = "";
                txtID.Focus();
            }
            #endregion
        }

        private void GetSystemSetting()
        {
            DataTable Settings = new Services.SP.Sp_Management().GetManagement();

            //ImeSettings.dbDataSource = Settings.Rows[0]["ServerIP"].ToString();
            //ImeSettings.dbPassword = Settings.Rows[0]["ServerPassword"].ToString();
            //ImeSettings.dbUserID = Settings.Rows[0]["ServerUserID"].ToString();
            //ImeSettings.dbInitialCatalogLOGO = Settings.Rows[0]["ServerLogoDatabaseName"].ToString();
            //ImeSettings.dbInitialCatalogIME = Settings.Rows[0]["ServerIMEDatabaseName"].ToString();
            //ImeSettings.dbFrmNo = Settings.Rows[0]["LogoCompanyNo"].ToString();
            //ImeSettings.dbDnmNo = Settings.Rows[0]["LogoCompanyNo"].ToString();
        }

        private void Metrofrm_Load(object sender, EventArgs e)
        {
            //GetSystemSetting();

            txtID.Focus();

            #region Nokta Virgul Olayi
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            #endregion


        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButtonClick();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginButtonClick();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
