using LoginForm.DataSet;
using System;
using LoginForm.DataSet;
using LoginForm.Main;
using LoginForm.Services;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class FormLogin : Form
    {
        Timer timer1 = new Timer();
        Timer timer2 = new Timer();
        Label logreg = new Label();
        IMEEntities IME = new IMEEntities();

        public FormLogin()
        {
            InitializeComponent();

            this.Size = new Size(320, 480);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            timer1.Tick += new EventHandler(timer1_go);
            timer2.Tick += new EventHandler(timer2_go);
            timer1.Interval = 10;
            timer2.Interval = 5;
            timer1.Start();
        }

        private void LoginButtonClick()
        {
            DateTime time = Utils.GetCurrentDateTime();

            #region LoginBlock
            string UserName = textBox1.Text;
            string PW = Utils.MD5Hash(textBox2.Text);
            Worker Logged = new Worker();

            Logged = IME.Workers
           .Where(uName => uName.UserName == UserName).Where(pw => pw.UserPass == PW).FirstOrDefault();

            if (Logged != null)
            {
                if (Logged.isActive == 1)
                {
                    Utils.setCurrentUser(Logged);

                    Utils.User(UserName, PW);

                    Utils.LogKayit("Login", "Login form screen has been entered");

                    frmMainMetro formMain = new frmMainMetro();
                    this.Hide();
                    formMain.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User '" + UserName + "' is passive. Please contact with Administration", "Login Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Wrong ID or Password", "Login Error", MessageBoxButtons.OK);
                textBox1.Focus();
            }
            #endregion
        }


        void timer1_go(object sender, EventArgs e)
        {
            //LogoPosition();
        }

        void timer2_go(object sender, EventArgs e)
        {
            if (logreg.Text == "Register")
            {
                reg();
                this.BackColor = Color.FromArgb(0, 173, 239);
                pictureBox1.BackColor = Color.FromArgb(0, 173, 239);
            }
            else if (logreg.Text == "Login")
            {
                log();
                this.BackColor = Color.White;
                pictureBox1.BackColor = Color.White;
            }
        }

        int go = 1;
        void LogoPosition()
        {
            if (panel1.Left == 0)
            {
                pictureBox1.Top += go;
                if (pictureBox1.Top > 50)
                {
                    timer1.Stop();
                }
            }
            if (panel2.Left == 0)
            {
                pictureBox1.Top += go;
                if (pictureBox1.Top < 34)
                {
                    timer1.Stop();
                }
            }
        }

        void line()
        {
            if (panel1.Left == 0)
            {
                separatorControl2.LineThickness = 2;
                separatorControl2.LineColor = Color.FromArgb(0, 173, 239);
                separatorControl1.LineThickness = 1;
                separatorControl1.LineColor = Color.Silver;
            }
            if (panel2.Left == 0)
            {
                separatorControl2.LineThickness = 1;
                separatorControl2.LineColor = Color.Silver;
                separatorControl1.LineThickness = 2;
                separatorControl1.LineColor = Color.FromArgb(0, 173, 239);
            }
        }

        int move_speed = 20;
        void reg()
        {
            if (panel2.Left > 0)
            {
                timer1.Start();
                line();

                panel1.Left -= move_speed;
                panel2.Left -= move_speed;
                if (panel2.Left == 0)
                {
                    timer2.Stop();
                }
            }
        }
        void log()
        {
            if (panel1.Left < 0)
            {
                timer1.Start();
                line();

                panel2.Left += move_speed;
                panel1.Left += move_speed;
                if (panel1.Left == 0)
                {
                    timer2.Stop();
                }
            }
        }

        //image of key
        void unlock()
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        /// <summary>
        /// Event of TextBox
        /// </summary>
        void Enter1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = string.Empty;
            }
        }
        void Leave1(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "Username";
            }
        }
        void Enter2(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.PasswordChar = '*';
                textBox2.Text = string.Empty;
            }
        }
        void Leave2(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.PasswordChar = '\0';
                textBox2.Text = "Password";
            }
        }
        void Enter3(object sender, EventArgs e)
        {
            if (textBox3.Text == "Full Name")
            {
                textBox3.Text = string.Empty;
            }
        }
        void Leave3(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                textBox3.Text = "Full Name";
            }
        }
        void Enter4(object sender, EventArgs e)
        {
            if (textBox4.Text == "Username")
            {
                textBox4.Text = string.Empty;
            }
        }
        void Leave4(object sender, EventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                textBox4.Text = "Username";
            }
        }
        void Enter5(object sender, EventArgs e)
        {
            if (textBox5.Text == "Email")
            {
                textBox5.Text = string.Empty;
            }
        }
        void Leave5(object sender, EventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                textBox5.Text = "Email";
            }
        }
        void Enter6(object sender, EventArgs e)
        {
            if (textBox6.Text == "Password")
            {
                textBox6.PasswordChar = '*';
                textBox6.Text = string.Empty;
            }
        }
        void Leave6(object sender, EventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                textBox6.PasswordChar = '\0';
                textBox6.Text = "Password";
            }
        }

        private void Register(object sender, EventArgs e)
        {
            Label lr = (Label)sender;

            logreg = lr;
            timer2.Start();
        }

        //Event of image
        private void lockun(object sender, EventArgs e)
        {
            unlock();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoginButtonClick();
        }

    }
}
