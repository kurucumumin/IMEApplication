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
using LoginForm.Services;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class FormMain : Form
    {
        ArrayList developmentButtons = new ArrayList();
        ArrayList loaderButtons = new ArrayList();

        public void initialize()
        {
            developmentButtons.Add(btnCustomerMain);
            developmentButtons.Add(btnLogin);
            developmentButtons.Add(btnQuotation);
            developmentButtons.Add(btnSupplier);
            developmentButtons.Add(btnWorker);
            developmentButtons.Add(btnItemCard);

            loaderButtons.Add(btnOnSale);
            loaderButtons.Add(btnSuperDisk);
            loaderButtons.Add(btnSlidingPriceList);
            loaderButtons.Add(btnDiscontinuedList);
            loaderButtons.Add(btnSuperDiskwithP);
            loaderButtons.Add(btnDualUsedArticles);
            loaderButtons.Add(btnHazardousFile);
            loaderButtons.Add(btnExtendedRangePrice);
            loaderButtons.Add(btnTSEList);
            loaderButtons.Add(btnRSProList);
            
        }

        public FormMain()
        {
            InitializeComponent();
            initialize();
        }

        private void btnCustomerMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMain customerMain = new CustomerMain();
            customerMain.ShowDialog();
            this.Show();
        }

        private void btnLoader_Click(object sender, EventArgs e)
        {

            changeButtonVisibility(loaderButtons, true);
            changeButtonVisibility(developmentButtons, false);


        }

        private void btnQuotation_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuotationAdd quotationForm = new QuotationAdd();
            quotationForm.ShowDialog();
            this.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            this.Hide();
            SupplierMain supplierMain = new SupplierMain();
            supplierMain.ShowDialog();
            this.Show();

        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddIMEWorker addIMEWorker = new AddIMEWorker();
            addIMEWorker.ShowDialog();
            this.Show();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
            this.Show();
        }

        private void btnDevelopment_Click(object sender, EventArgs e)
        {
            changeButtonVisibility(developmentButtons, true);
            changeButtonVisibility(loaderButtons, false);
        }










        private void changeButtonVisibility(ArrayList list, bool state)
        {
            foreach (Button item in list)
            {
                item.Visible = state;
            }
        }

        private void GoToLoaderPage()
        {
            LoaderPage form = new LoaderPage();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnOnSale_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "OnSale";
            GoToLoaderPage();
        }

        private void btnSuperDisk_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "SuperDisk";
            GoToLoaderPage();
        }

        private void btnSlidingPriceList_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "SlidingPrice";
            GoToLoaderPage();
        }

        private void btnDiscontinuedList_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "DiscontinuedList";
            GoToLoaderPage();
        }

        private void btnSuperDiskwithP_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "SuperDiskP";
            GoToLoaderPage();
        }

        private void btnDualUsedArticles_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "DualUse";
            GoToLoaderPage();
        }

        private void btnHazardousFile_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "Hazardous";
            GoToLoaderPage();
        }

        private void btnExtendedRangePrice_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "ExtendedRange";
            GoToLoaderPage();
        }

        private void btnTSEList_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "TSE";
            GoToLoaderPage();
        }

        private void btnRSProList_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "RSPro";
            GoToLoaderPage();
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard form = new ItemCard();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ExchangeService DailyDolar = new ExchangeService();
            ExchangeRate RateForDolar = new ExchangeRate();
            RateForDolar = DailyDolar.GetExchangeRateforDolar();
            
            //string Euro = DailyEuro.GetExchangeRateforEuro();
            //string Dolar = DailyEuro.GetExchangeRateforDolar();
            //lblDolarSell.Text = Dolar;
            //lblEuroSell.Text = Euro;

            this.Show();
            this.Enabled = false;
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
            this.Enabled = true;
        }
    }
}
