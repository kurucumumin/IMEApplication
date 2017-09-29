using System;
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

namespace LoginForm.Quotation
{
    public partial class FormQuaotationCustomerSearch : Form
    {
        IMEEntities IME = new IMEEntities();
        public FormQuaotationCustomerSearch()
        {
            InitializeComponent();
        }

        private void FormQuaotationCustomerSearch_Load(object sender, EventArgs e)
        {
            CustomerCode.Text = classQuotationAdd.customersearchID.ToString();
            CustomerName.Text = classQuotationAdd.customersearchname;
            List<Customer> c = classQuotationAdd.CustomerSearch();
            CustomerSearchGrid.DataSource = c;
        }

        private void CustomerSearchGrid_Click(object sender, EventArgs e)
        {
            if (CustomerSearchGrid.RowCount > 0)
            {
                CustomerSearchGrid.ClearSelection();
                CustomerSearchGrid.CurrentCell = CustomerSearchGrid.Rows[CustomerSearchGrid.CurrentCell.RowIndex].Cells[0];
                string cname = CustomerSearchGrid.Rows[CustomerSearchGrid.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
                Customer c = new Customer();
                c = IME.Customers.Where(a => a.ID == cname).FirstOrDefault();
                CustomerCode.Text = c.ID;
                CustomerName.Text = c.c_name;
            }
        }

        private void CustomerSearchGrid_DoubleClick(object sender, EventArgs e)
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
            this.Hide();
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
                this.Hide();
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
            CustomerMain form = new CustomerMain(true, "newCustomerDevelopers");
            form.ShowDialog();
            this.Show();
            List<Customer> c = classQuotationAdd.CustomerSearch();
            CustomerSearchGrid.DataSource = c;
        }
    }
}
