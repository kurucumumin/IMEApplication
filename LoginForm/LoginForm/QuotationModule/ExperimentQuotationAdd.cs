using LoginForm.DataSet;
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

        private void SetCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        private void ChooseCustomer(string CustomerName)
        {
            //if (frmCustomerMain == DialogResult.OK)
            //{
            //    SetCustomer();
            //}
            throw new NotImplementedException();
        }

        private void CalculateLandingCost(string CustomerName)
        {
            throw new NotImplementedException();
        }

        private decimal CalculateItemMargin(int RowIndex)
        {
            throw new NotImplementedException();
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
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
                this.Enabled = false;

                if(form.ShowDialog() == DialogResult.OK)
                {
                    form.customer = _customer;
                }
                this.Enabled = true;
            }
        }
    }
}
