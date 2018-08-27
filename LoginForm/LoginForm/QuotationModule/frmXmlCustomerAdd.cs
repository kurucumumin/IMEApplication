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
    public partial class frmXmlCustomerAdd : MyForm
    {
        public XmlCustomer customer;
        public frmXmlCustomerAdd(XmlCustomer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void SaveCustomer()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while saving the customer");

                throw;
            }
        }
        
    }
}
