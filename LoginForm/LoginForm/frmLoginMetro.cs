using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class frmLoginMetro : Syncfusion.Windows.Forms.MetroForm
    {
        IMEEntities IME = new IMEEntities();
        public string LoginPerson { get; set; }

        public frmLoginMetro()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginButtonClick();
        }

        private void LoginButtonClick()
        {
            DateTime time = (DateTime)IME.CurrentDate().First();

            #region LoginBlock
            string UserName = txtID.Text;
            string PW = Utils.MD5Hash(txtPassWord.Text);
            Worker Logged = new Worker();

            Logged = IME.Workers
           .Where(uName => uName.UserName == UserName).Where(pw => pw.UserPass == PW).FirstOrDefault();

            if (Logged != null)
            {
                if (Logged.isActive == 1)
                {
                    Utils.setCurrentUser(Logged);
                    FormMain formMain = new FormMain();
                    //frmMainMetro formMain = new frmMainMetro();
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
                MessageBox.Show("Wrong ID or Password", "Login Error", MessageBoxButtons.OK);
            }
            #endregion
        }

        private void Metrofrm_Load(object sender, EventArgs e)
        {
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
    }
}
