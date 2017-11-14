using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.SaleOrder
{
    public partial class FormSaleOrderCreate : Form
    {
        IMEEntities IME = new IMEEntities();

        List<Customer> customerList = new List<Customer>();
        List<Customer> tempCustomerList = new List<Customer>();

        public FormSaleOrderCreate()
        {
            InitializeComponent();
        }

        private void FormSaleOrderCustList_Load(object sender, EventArgs e)
        {
            customerList = IME.Customers.ToList();
            PopulateCustomerList(customerList);
        }

        private void PopulateCustomerList(List<Customer> list)
        {
            lbCustomerList.DataSource = list;
            lbCustomerList.ClearSelected();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            tempCustomerList = customerList.Where(c => c.c_name.IndexOf(txtSearchCustomer.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            PopulateCustomerList(tempCustomerList);
        }

        private void lbCustomerList_SelectedValueChanged(object sender, EventArgs e)
        {
            if(lbCustomerList.SelectedValue != null)
            {
                var dgList = IME.Quotations.Where(q => q.CustomerID == lbCustomerList.SelectedValue.ToString()).ToList();
                dgQuotations.DataSource = dgList;
                dgQuotations.ClearSelection();
            }
        }

        private void dgQuotations_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection quotList = dgQuotations.SelectedRows;
            List<QuotationDetail> itemList = new List<QuotationDetail>();

            foreach (DataGridViewRow item in quotList)
            {
                var quotNo = item.Cells["QuotationNo"].Value.ToString();
                Quotation quot = IME.Quotations.Where(q => q.QuotationNo == quotNo).FirstOrDefault();
                itemList.AddRange(quot.QuotationDetails);
            }
            dgItems.DataSource = itemList;
            dgItems.ClearSelection();

        }
    }
}
