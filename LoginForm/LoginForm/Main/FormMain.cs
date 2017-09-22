using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class FormMain : Form
    {
        ArrayList developmentButtons = new ArrayList();

        public void initialize()
        {
            developmentButtons.Add(btnCustomerMain);
            developmentButtons.Add(btnLogin);
            developmentButtons.Add(btnQuotation);
            developmentButtons.Add(btnSupplier);
            developmentButtons.Add(btnWorker);




        }

        public FormMain()
        {
            InitializeComponent();
            initialize();
        }

        private void trialMain_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomerMain_Click(object sender, EventArgs e)
        {
            CustomerMain customerMain = new CustomerMain();
            customerMain.Show();
        }

        private void btnLoader_Click(object sender, EventArgs e)
        {
            ItemCardMainForm itemCardMainForm = new ItemCardMainForm();
            itemCardMainForm.Show();
        }

        private void btnQuotation_Click(object sender, EventArgs e)
        {
            QuotationForm quotationForm = new QuotationForm();
            quotationForm.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierMain supplierMain = new SupplierMain();
            supplierMain.Show();
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            AddIMEWorker addIMEWorker = new AddIMEWorker();
            addIMEWorker.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
        }

        private void btnDevelopment_Click(object sender, EventArgs e)
        {
            changeButtonVisibility(developmentButtons, true);
        }

        private void changeButtonVisibility(ArrayList list, bool state)
        {
            foreach (Button item in list)
            {
                item.Visible = state;
            }
        }
    }
}
