using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;
using LoginForm.QuotationModule;

namespace LoginForm.IMEAccount
{
    public partial class frmReceiptOperation : Form
    {
        IMEEntities IME = new IMEEntities();
        private Customer customer;
        private object currentOperation;
        private object previousOperation;

        public frmReceiptOperation()
        {
            InitializeComponent();
        }

        private void frmReceiptOperation_Load(object sender, EventArgs e)
        {
            #region Combobox
            cbReceipt.DataSource = IME.ReceiptTypes.ToList();
            cbReceipt.DisplayMember = "Name";
            cbReceipt.ValueMember = "ReceiptTypeID";

            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            #endregion
            //groupBox1.Visible = false;
        }

        private void txtCustomerName_DoubleClick(object sender, EventArgs e)
        {
            CustomerSearch();
        }

        public void CustomerSearch()
        {

            classQuotationAdd.customersearchname = txtCustomerName.Text;
            classQuotationAdd.customersearchID = "";
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(customer);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                customer = form.customer;
            }
            this.Enabled = true;
            fillCustomer();
        }
        private void fillCustomer()
        {
            txtCustomerName.Text = classQuotationAdd.customerID;
            txtCustomerID.Text = classQuotationAdd.customername;

            var c = IME.Customers.Where(a => a.c_name == txtCustomerName.Text).FirstOrDefault();
            if (c != null)
            {
                txtCustomerName.Text = c.c_name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerSearch();
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CustomerSearch();
            }
        }


    }
}
