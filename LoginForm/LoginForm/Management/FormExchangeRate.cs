using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LoginForm.Services.MyClasses.MyAuthority;

namespace LoginForm.ManagementModule
{
    public partial class FormExchangeRate : MyForm
    {
        public FormExchangeRate()
        {
            InitializeComponent();
            checkAuthorities();
        }
        

        private void FormExchangeRate_Load(object sender, EventArgs e)
        {
            BringExchangeRates();
        }

        private void BringExchangeRates()
        {
            IMEEntities IME = new IMEEntities();

            Rate rateUSD = IME.Rates.Where(r => r.rate_date == DateTime.Today.Date && r.CurType == "USD").FirstOrDefault();
            if(rateUSD != null) { nudUSD.Value = (decimal)rateUSD.RateBuy; }

            Rate rateGBP = IME.Rates.Where(r => r.rate_date == DateTime.Today.Date && r.CurType == "GBP").FirstOrDefault();
            if (rateGBP != null) { nudGBP.Value = (decimal)rateGBP.RateBuy; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IMEEntities IME = new IMEEntities();

                Rate rateUSD = IME.Rates.Where(r => r.rate_date == DateTime.Today.Date && r.CurType == "USD").FirstOrDefault();
                rateUSD.RateBuy = nudUSD.Value;
                rateUSD.RateBuyEffective = nudUSD.Value;
                rateUSD.RateSell = nudUSD.Value;
                rateUSD.RateSellEffective = nudUSD.Value;

                Rate rateGBP = IME.Rates.Where(r => r.rate_date == DateTime.Today.Date && r.CurType == "GBP").FirstOrDefault();
                rateGBP.RateBuy = nudGBP.Value;
                rateGBP.RateBuyEffective = nudGBP.Value;
                rateGBP.RateSell = nudGBP.Value;
                rateGBP.RateSellEffective = nudGBP.Value;

                IME.SaveChanges();

                MessageBox.Show("Data successfully saved!", "Success", MessageBoxButtons.OK);
                Utils.LogKayit("Exchange Rate", "Exchange Rate added");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving changes! Try again later", "Fail", MessageBoxButtons.OK);
                this.Close();
                throw;
            }

        }

        public void checkAuthorities()
        {
            List<DataSet.AuthorizationValue> authList = Utils.getCurrentUser().AuthorizationValues.ToList();

            if (!Utils.AuthorityCheck(IMEAuthority.CanEditDataExchangeRate))
            {
                btnSave.Visible = false;
            }
        }
    }
}