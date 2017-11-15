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

        List<QuotationDetail> itemList = new List<QuotationDetail>();

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
            List<QuotationDetail> tempItemList = new List<QuotationDetail>();

            foreach (DataGridViewRow item in quotList)
            {
                var quotNo = item.Cells["QuotationNo"].Value.ToString();
                Quotation quot = IME.Quotations.Where(q => q.QuotationNo == quotNo).FirstOrDefault();
                tempItemList.AddRange(quot.QuotationDetails);
            }
            dgItems.DataSource = tempItemList;
            itemList = tempItemList.ToList();
            dgItems.ClearSelection();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<QuotationDetail> list = new List<QuotationDetail>();

            foreach (DataGridViewRow item in dgItems.Rows)
            {
                if(item.Cells[0].Value != null && (bool)item.Cells[0].Value == true)
                {
                    QuotationDetail qd = itemList.Where(x => x.ID == Convert.ToInt32(item.Cells["ID"].Value)).First();
                    list.Add(qd);
                }
            }

            FormSaleOrderAdd form = new FormSaleOrderAdd((Customer)lbCustomerList.SelectedItem,list);
            form.Show();
            form.BringToFront();
            this.Close();

        }
    }
}
