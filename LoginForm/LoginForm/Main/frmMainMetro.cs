#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using LoginForm.BackOrder;
using LoginForm.Billing;
using LoginForm.DataSet;
using LoginForm.ItemModule;
using LoginForm.ManagementModule;
using LoginForm.nsSaleOrder;
using LoginForm.PurchaseOrder;
using LoginForm.QuotationModule;
using LoginForm.Services;
using LoginForm.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.Main
{
    public partial class frmMainMetro : Form
    {
        List<Panel> panels = new List<Panel>();
        Panel ActivePanel;
        int PH;
        string animMode = "Extend";
        int maxSubPanelHeight;
        int ExtendingPanelHeight = 324;
        public frmMainMetro()
        {
            InitializeComponent();
            ActivePanel = pnlDevelopment;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(pnlDevelopment.Height == 0)
            {
                ActivePanel.Height = 0;

                int h = 0;
                //maxSubPanelHeight = panel5.Height - 382;
                maxSubPanelHeight = panel5.Height - ExtendingPanelHeight;
                foreach (Control item in pnlDevelopment.Controls)
                {
                    h += item.Height + 6;
                }
                if(h > maxSubPanelHeight)
                {
                    PH = maxSubPanelHeight;
                }
                else
                {
                    PH = h;
                }
                ActivePanel = pnlDevelopment;
                animMode = "Extend";
                timer2.Start();
            }
            else
            {
                PH = 0;
                animMode = "Shrink";
                timer2.Start();
            }            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (pnlFileLoader.Height == 0)
            {
                ActivePanel.Height = 0;

                int h = 0;
                //maxSubPanelHeight = panel5.Height - 382;
                maxSubPanelHeight = panel5.Height - ExtendingPanelHeight;
                foreach (Control item in pnlFileLoader.Controls)
                {
                    h += item.Height + 6;
                }
                if (h > maxSubPanelHeight)
                {
                    PH = maxSubPanelHeight;
                }
                else
                {
                    PH = h;
                }
                ActivePanel = pnlFileLoader;
                animMode = "Extend";
                timer2.Start();
            }
            else
            {
                PH = 0;
                animMode = "Shrink";
                timer2.Start();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //managementControl1.Visible = !managementControl1.Visible;
            if (pnlManagement.Height == 0)
            {
                ActivePanel.Height = 0;

                int h = 0;
                maxSubPanelHeight = panel5.Height - ExtendingPanelHeight;
                foreach (Control item in pnlManagement.Controls)
                {
                    h += item.Height + 6;
                }
                if (h > maxSubPanelHeight)
                {
                    PH = maxSubPanelHeight;
                }
                else
                {
                    PH = h;
                }
                ActivePanel = pnlManagement;
                animMode = "Extend";
                timer2.Start();
            }
            else
            {
                PH = 0;
                animMode = "Shrink";
                timer2.Start();
            }
        }

        private void frmMainMetro_Load(object sender, EventArgs e)
        {
            IMEEntities db = new IMEEntities();

            Worker currentUser = Utils.getCurrentUser();
            
            lblName.Text = currentUser.NameLastName?.ToString();
            lblEmail.Text = currentUser.Email?.ToString();
            lblPhone.Text = currentUser.Phone?.ToString();

            ExchangeRate gbp = db.Currencies.Where(x => x.currencyName == "Pound").
                FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault();

            lblGBP.Text = ((decimal)gbp.rate).ToString("N4");

            ExchangeRate usd = db.Currencies.Where(x => x.currencyName == "Dollar").
                FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault();

            lblUSD.Text = ((decimal)usd.rate).ToString("N4");
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (animMode == "Extend")
            {
                ActivePanel.Height = ActivePanel.Height + 15;
                if (ActivePanel.Height >= PH)
                {
                    timer2.Stop();
                }
            }
            else
            {
                ActivePanel.Height = ActivePanel.Height - 15;
                if (ActivePanel.Height <= PH)
                {
                    timer2.Stop();
                }
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplierMain supplierMain = new frmSupplierMain();
            supplierMain.Show();
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            FormSalesOrderMain saleOrderMain = new FormSalesOrderMain();
            saleOrderMain.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FormMain formMain = (FormMain)this.ParentForm;
            FormUserMain roles = new FormUserMain(formMain);
            roles.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerMain customerMain = new CustomerMain();
            customerMain.Show();
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain form = new PurchaseOrderMain();
            form.Show();
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard frmItem = new ItemCard();
            frmItem.Show();
        }

        private void btnQuotation_Click(object sender, EventArgs e)
        {
            FormQuotationMain formQuotationMain = new FormQuotationMain();
            formQuotationMain.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmStock frmStock = new frmStock();
            frmStock.Show();
        }

        private void btnToBeInvoiced_Click(object sender, EventArgs e)
        {
            frmFaturalanacaklar frmFatura = new frmFaturalanacaklar();
            frmFatura.Show();
        }

        private void GoToLoaderPage()
        {
            LoaderPage form = new LoaderPage();
            form.ShowDialog();
        }

        private void btnRsInvoice_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "RSInvoice";
            GoToLoaderPage();
        }

        private void btnRSProList_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "RSPro";
            GoToLoaderPage();
        }

        private void btnTSEList_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "TSE";
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

        private void btnDiscontinuedList_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "DiscontinuedList";
            GoToLoaderPage();
        }

        private void btnSlidingPriceList_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "SlidingPrice";
            GoToLoaderPage();
        }

        private void btnSuperDisk_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "SuperDisk";
            GoToLoaderPage();
        }

        private void btnOnSale_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "OnSale";
            GoToLoaderPage();
        }

        private void btnOrderAcknowledgement_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "OrderAcknowledgementtxtReader";
            GoToLoaderPage();
        }

        private void btnBackOrder_Click(object sender, EventArgs e)
        {
            frmBackOrderMain form = new frmBackOrderMain();
            form.Show();
        }

        private void btnExchangeRate_Click(object sender, EventArgs e)
        {
            frmExchangeRate form = new frmExchangeRate();
            form.ShowDialog();
        }

        private void btnTermsOfPayment_Click(object sender, EventArgs e)
        {
            FormTermsOfPayment form = new FormTermsOfPayment();
            form.ShowDialog();
        }

        private void btnCategorySubCategory_Click(object sender, EventArgs e)
        {
            FormCategorySubCategory form = new FormCategorySubCategory();
            form.ShowDialog();
        }

        private void btnRoleAuths_Click(object sender, EventArgs e)
        {
            FormRoleAuths form = new FormRoleAuths();
            form.ShowDialog();
        }

        private void btnManagmentControl_Click(object sender, EventArgs e)
        {
            FormManagmentControl form = new FormManagmentControl();
            form.ShowDialog();
        }
    }
}
