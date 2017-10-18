using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Services;
using LoginForm.DataSet;
using LoginForm.RolesAndAuths;
using LoginForm.Quotation;

namespace LoginForm
{
    public partial class FormMain : Form
    {
        private Worker User;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnLoader_Click(object sender, EventArgs e)
        {
            controlLoader.BringToFront();
        }

        private void btnDevelopment_Click(object sender, EventArgs e)
        {
            controlDevelopment.BringToFront();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ExchangeService DailyDolar = new ExchangeService();
            ExchangeRate RateForDolar = new ExchangeRate();
            RateForDolar = DailyDolar.GetExchangeRateforDolar();

            //string Euro = DailyEuro.GetExchangeRateforEuro();
            //string Dolar = DailyEuro.GetExchangeRateforDolar();
            //lblDolarSell.Text = Dolar;
            //lblEuroSell.Text = Euro;

            this.Enabled = false;
            FormLogin loginForm = new FormLogin(this);
            loginForm.ShowDialog();
            User = Utils.getCurrentUser();

        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            if (User.AuthorizationValues.Where(a => a.AuthorizationID == 1009).Count() > 0)
            {
                controlManagement.BringToFront();
            }
            else
            {
                MessageBox.Show("You are not authorized for this process");
            }
        }

        public void setManagementControl()
        {
            controlManagement.setManagementModule(Utils.getManagement().LowMarginLimit);
        }
    }
}
