using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class FormQuaotationCustomerSearch : Form
    {
        IMEEntities IME = new IMEEntities();
        public Customer customer;
        public XmlCustomer xmlCustomer;
        bool fromXmlCustomer = false;
        public FormQuaotationCustomerSearch()
        {
            InitializeComponent();
        }

        public FormQuaotationCustomerSearch(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        public FormQuaotationCustomerSearch(XmlCustomer customer)
        {
            InitializeComponent();
            fromXmlCustomer = true;
            this.xmlCustomer = customer;
        }

        private void FormQuaotationCustomerSearch_Load(object sender, EventArgs e)
        {
            CustomerCode.Text = classQuotationAdd.customersearchID.ToString();
            CustomerName.Text = classQuotationAdd.customersearchname;
            List<Customer> c = classQuotationAdd.CustomerSearch();
            CustomerSearchGrid.DataSource = c;
            if (fromXmlCustomer && c.Count <= 0)
            {
                MessageBox.Show("Customer Not Found!");
                frmXmlCustomerAdd frm = new frmXmlCustomerAdd(xmlCustomer);
                frm.ShowDialog();
            }
            else
            {
                CustomerSearchGrid.DataSource = c;
            }

        }

        private void CustomerSearchGrid_DoubleClick(object sender, EventArgs e)
        {
            CustomerSearchGrid.ClearSelection();
            //CustomerSearchGrid.CurrentCell = CustomerSearchGrid.Rows[CustomerSearchGrid.CurrentCell.RowIndex].Cells[0];
            string cID = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();
            customer = IME.Customers.Where(a => a.ID == cID).FirstOrDefault();
            CustomerCode.Text = customer.ID;
            CustomerName.Text = customer.c_name;
            classQuotationAdd.customerID = CustomerCode.Text;
            classQuotationAdd.customername = CustomerName.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CustomerSearchGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CustomerSearchGrid.ClearSelection();
                CustomerSearchGrid.CurrentCell = CustomerSearchGrid.Rows[CustomerSearchGrid.CurrentCell.RowIndex].Cells[0];
                string cname = CustomerSearchGrid.Rows[CustomerSearchGrid.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
                Customer c = new Customer();
                c = IME.Customers.Where(a => a.ID == cname).FirstOrDefault();
                CustomerCode.Text = c.ID;
                CustomerName.Text = c.c_name;
                classQuotationAdd.customerID = CustomerCode.Text;
                classQuotationAdd.customername = CustomerName.Text;
                customer = c;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                classQuotationAdd.customersearchID = CustomerCode.Text;
                classQuotationAdd.customersearchname = "";
                List<Customer> c = classQuotationAdd.CustomerSearch();
                CustomerSearchGrid.DataSource = c;
            }
        }

        private void CustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                classQuotationAdd.customersearchID = "";
                classQuotationAdd.customersearchname = CustomerName.Text;
                List<Customer> c = classQuotationAdd.CustomerSearch();
                CustomerSearchGrid.DataSource = c;
            }
        }

        private void CustomerCode_TextChanged(object sender, EventArgs e)
        {
            //if (CustomerName.Text != "") {  CustomerName.Text = "";}
        }

        private void CustomerName_TextChanged(object sender, EventArgs e)
        {
            //if (CustomerCode.Text != "") { CustomerCode.Text = ""; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerMain form = new CustomerMain(true);
            form.ShowDialog();
            //this.Show();
            //List<Customer> c = classQuotationAdd.CustomerSearch();
            //CustomerSearchGrid.DataSource = c;
        }
    }
}