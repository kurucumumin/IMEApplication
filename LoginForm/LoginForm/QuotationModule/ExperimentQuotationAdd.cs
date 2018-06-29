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
            txtCustomerCode.Text = _customer.ID;
            txtCustomerName.Text = _customer.c_name;

            dtpDate.Value = DateTime.Now;

            if(_customer.CustomerWorkers.Count != 0)
            {
                cbWorkers.ValueMember = "ID";
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.DataSource = _customer.CustomerWorkers.ToList();
            }

            if (!String.IsNullOrEmpty(_customer.CurrNameQuo))
            {
                cbCurrency.SelectedIndex = cbCurrency.FindStringExact(_customer.CurrNameQuo);
            }

            if (!String.IsNullOrEmpty(_customer.representaryID?.ToString()))
            {
                cbRepresentative.SelectedValue = _customer.representaryID;
            }
        }

        private void CalculateLandingCost(string CustomerName)
        {
            throw new NotImplementedException();
        }

        private decimal CalculateItemMargin(bool _Pitem, int _UC, int _SSM, decimal _LandingCost, decimal _Price, decimal currencyValue)
        {
            decimal currentGbpValue = Convert.ToDecimal(new IMEEntities().Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);
            decimal gbpPrice = (_Price * currencyValue) / currentGbpValue;

            if (_UC > 1 || _SSM > 1)
            {
                if (_UC > 1 && !_Pitem)
                {
                    gbpPrice *= _UC;
                }
                else
                {
                    if (_SSM > 1)
                    {
                        gbpPrice *= _SSM;
                    }
                }
            }

            return (1 - (_LandingCost / gbpPrice)) * 100;

            //if(_UC > 1 && _SSM > 1)
            //{

            //}else if (_UC > 1)
            //{

            //}
            //// if(_SSM > 1)
            //else
            //{

            //}
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
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(txtCustomerCode.Text);
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
            cbCurrency.SelectedValue = Utils.getManagement().DefaultCurrency;

            cbPayment.DisplayMember = "term_name";
            cbPayment.ValueMember = "ID";
            cbPayment.DataSource = db.PaymentTerms.ToList();

            cbRepresentative.DisplayMember = "NameLastName";
            cbRepresentative.ValueMember = "WorkerID";
            cbRepresentative.DataSource = db.Workers.ToList();
        }
    }
}
