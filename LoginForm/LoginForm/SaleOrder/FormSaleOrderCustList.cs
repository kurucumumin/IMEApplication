using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.SaleOrder
{
    public partial class FormSaleOrderCustList : Form
    {
        List<Customer> customerList = new List<Customer>();



        public FormSaleOrderCustList()
        {
            InitializeComponent();
        }

        private void FormSaleOrderCustList_Load(object sender, EventArgs e)
        {
            PopulateLists();
        }

        private void PopulateLists()
        {
            IMEEntities IME = new IMEEntities();

            customerList = IME.Customers.ToList();
            lbCustomerList.DataSource = customerList;
        }
    }
}
