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

namespace LoginForm
{
    public partial class QuotationAdd : Form
    {
        public QuotationAdd()
        {
            InitializeComponent();
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void QuotationForm_Load(object sender, EventArgs e)
        {
            //// TODO: Bu kod satırı 'iMEDataSet3.Worker' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.workerTableAdapter.Fill(this.iMEDataSet3.Worker);
            //// TODO: Bu kod satırı 'iMEDataSet2.Customer' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.customerTableAdapter.Fill(this.iMEDataSet2.Customer);
            //// TODO: Bu kod satırı 'iMEDataSet1.SupplierWorker' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.supplierWorkerTableAdapter.Fill(this.iMEDataSet1.SupplierWorker);
            //// TODO: Bu kod satırı 'iMEDataSet.Supplier' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.supplierTableAdapter.Fill(this.iMEDataSet.Supplier);
        }

        private void CustomerCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerCode_MouseDown(object sender, MouseEventArgs e)
        {
            
       
        }

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                classQuotationAdd.customersearchID = CustomerCode.Text;
                classQuotationAdd.customersearchname = "";
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
                this.Enabled=false;
                form.ShowDialog();
                this.Enabled = true ;
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

        private void button10_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.Show();
                this.Close();
            }
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void DiscCharge_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
