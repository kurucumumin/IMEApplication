using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Quotation;
using LoginForm.Services;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class QuotationAdd : Form
    {
        GetWorkerService GetWorkerService = new GetWorkerService();
        IMEEntities IME = new IMEEntities();

        public QuotationAdd()
        {
            InitializeComponent();
        }

        private void QuotationForm_Load(object sender, EventArgs e)
        {
            #region ComboboxFiller
            cmbPayment.DataSource = IME.PaymentMethods.ToList();
            cmbPayment.DisplayMember = "Payment";
            cmbPayment.ValueMember = "ID";

            cmbRep.DataSource = GetWorkerService.GetWorker();
            cmbRep.DisplayMember = "FirstName";
            cmbRep.ValueMember = "WorkerID";

            cmbCur.DataSource = IME.Rates.ToList();
            cmbCur.DisplayMember = "rate_name";
            cmbCur.ValueMember = "ID";

            cmbShipping.DataSource = IME.ShippingMethods.ToList();
            cmbShipping.DisplayMember = "shipping_name";
            cmbShipping.ValueMember = "ID";
            #endregion
        }

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                classQuotationAdd.customersearchID = CustomerCode.Text;
                classQuotationAdd.customersearchname = "";
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
                this.Enabled = false;
                form.ShowDialog();
                this.Enabled = true;
                fillCustomer();
            }

        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                classQuotationAdd.customersearchID = "";
                classQuotationAdd.customersearchname = txtCustomerName.Text;
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
                this.Enabled = false;
                form.ShowDialog();
                this.Enabled = true;
                fillCustomer();
            }
        }
        private void fillCustomer()
        {
            CustomerCode.Text = classQuotationAdd.customerID;
            txtCustomerName.Text = classQuotationAdd.customername;
        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(true, CustomerCode.Text);
            f.Show();
        }

        private void customerDetailsNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(txtCustomerName.Text, true);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.Show();
                this.Close();
            }
        }
    }
}
