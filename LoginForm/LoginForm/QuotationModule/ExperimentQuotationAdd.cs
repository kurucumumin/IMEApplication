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

namespace LoginForm.QuotationModule
{
    
    public partial class ExperimentQuotationAdd : Form
    {
        Customer _customer;
        ExchangeRate _rate;
        decimal _factor;

        public ExperimentQuotationAdd()
        {
            InitializeComponent();
        }

        private void SetCustomer()
        {
            CustomerCode.Text = _customer.ID;
            txtCustomerName.Text = _customer.c_name;

            dtpDate.Value = DateTime.Now;
        }

        private void CalculateLandingCost(string CustomerName)
        {
            throw new NotImplementedException();
        }

        private decimal CalculateItemMargin(decimal _GBPcost, decimal _Currentprice)
        {
            IMEEntities db = new IMEEntities();

            decimal? GBPrate = db.Currencies.Where(x=>x.currencyName == "Pound").FirstOrDefault().
                ExchangeRates.OrderByDescending(x=>x.date).FirstOrDefault().rate;

            decimal _GBPprice = (_Currentprice * Decimal.Parse(lblCurrValue.Text)) / Convert.ToDecimal(GBPrate);

            return (1 - (_GBPcost/ Convert.ToDecimal(_GBPprice))) * 100;
        }

        private decimal CalculateTotalMargin()
        {
            throw new NotImplementedException();
        }

        private void CalculateSubTotal()
        {
            throw new NotImplementedException();
        }

        private void ChangeDate()
        {
            throw new NotImplementedException();
        }

        private void ChangeFactor()
        {
            throw new NotImplementedException();
        }

        private void SetCurrency()
        {
            throw new NotImplementedException();
        }

        private string CreateNewQuotationNumber()
        {
            throw new NotImplementedException();
        }

        private void ApplyDiscountOnSubtotal()
        {
            throw new NotImplementedException();
        }

        private void AddExtraCharges()
        {
            throw new NotImplementedException();
        }

        private void ApplyVAT()
        {
            throw new NotImplementedException();
        }

        private void SaveFunction()
        {
            throw new NotImplementedException();
        }

        private void SaveQuotation()
        {
            throw new NotImplementedException();
        }

        private void SaveQuotationDeTails()
        {
            throw new NotImplementedException();
        }

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(CustomerCode.Text);
                this.Enabled = false;

                if(form.ShowDialog() == DialogResult.OK)
                {
                    _customer = form.customer;
                    SetCustomer();
                }
                this.Enabled = true;
            }
        }

        private void ExperimentQuotationAdd_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
            lblVat.Text = Utils.getManagement().VAT.ToString();
        }

        private void FillComboBoxes()
        {
            IMEEntities db = new IMEEntities();

            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            cbCurrency.DataSource = db.Currencies.ToList();


        }
    }
}
