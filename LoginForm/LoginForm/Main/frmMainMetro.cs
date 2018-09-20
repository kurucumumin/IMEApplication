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
using LoginForm.f_RSInvoice;
using LoginForm.ItemModule;
using LoginForm.Management;
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
using static LoginForm.Services.MyClasses.MyAuthority;

namespace LoginForm.Main
{
    public partial class frmMainMetro : MyForm
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
            ActivePanel = pnlMain;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(pnlMain.Height == 0)
            {
                ActivePanel.Height = 0;

                int h = 0;
                //maxSubPanelHeight = panel5.Height - 382;
                maxSubPanelHeight = panel5.Height - ExtendingPanelHeight;
                foreach (Control item in pnlMain.Controls)
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
                ActivePanel = pnlMain;
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
            if (pnlImportFiles.Height == 0)
            {
                ActivePanel.Height = 0;

                int h = 0;
                //maxSubPanelHeight = panel5.Height - 382;
                maxSubPanelHeight = panel5.Height - ExtendingPanelHeight;
                foreach (Control item in pnlImportFiles.Controls)
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
                ActivePanel = pnlImportFiles;
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
            checkAuthorities();
            Worker currentUser = Utils.getCurrentUser();
            
            lblName.Text = currentUser.NameLastName?.ToString();
            lblEmail.Text = currentUser.Email?.ToString();
            lblPhone.Text = currentUser.Phone?.ToString();

            //ExchangeRate gbp = db.Currencies.Where(x => x.currencyName == "Pound").
            //    FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault();

            var gbp = db.prc_GetLastExchangeRateWithCurrencyName("Pound").FirstOrDefault();

            lblGBP.Text = ((decimal)gbp.rate).ToString("N4");

            var usd = db.prc_GetLastExchangeRateWithCurrencyName("Dollar").FirstOrDefault();

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

        public void checkAuthorities()
        {
            List<DataSet.AuthorizationValue> authList = Utils.getCurrentUser().AuthorizationValues.ToList();

            #region Ana Kategori
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeManagementModule))
            {
                btnManagement.Visible = false;
                pnlManagement.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeLoaderModule))
            {
                btnFileLoader.Visible = false;
                pnlImportFiles.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeDevelopmentModule))
            {
                btnDevelopment.Visible = false;
            }
            #endregion

            #region Main
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeItemCardModule))
            {
                btnItemCard.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeCustomerModule))
            {
                btnCustomer.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeSupplierModule))
            {
                btnSupplier.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeQuotationModule))
            {
                btnQuotation.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeSaleOrderModule))
            {
                btnSalesOrder.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeePurchaseOrderModule))
            {
                btnPurchaseOrder.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeStockModule))
            {
                btnStock.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeInvoiceModule))
            {
                btnToBeInvoiced.Visible = false;
            }
            #endregion

            #region Import Files
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeRsInvoice))
            {
                btnRsInvoice.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeSuperDýsk))
            {
                btnSuperDisk.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeSuperDýskP))
            {
                btnSuperDiskwithP.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeSlidingPrice))
            {
                btnSlidingPriceList.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeHazardouse))
            {
                btnHazardousFile.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeRsProList))
            {
                btnRSProList.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeTSEList))
            {
                btnTSEList.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeDualUsedArticles))
            {
                btnDualUsedArticles.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeExtendedRangePrice))
            {
                btnExtendedRangePrice.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeDiscountinuedList))
            {
                btnDiscontinuedList.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeOnSale))
            {
                btnOnSale.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeOrderAcknowledgemenet))
            {
                btnOrderAcknowledgement.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeBackOrder))
            {
                btnBackOrder.Visible = false;
            }
            #endregion

            #region Managment
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeExchangeRate))
            {
                btnExchangeRate.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeTermsofPayment))
            {
                btnTermsOfPayment.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeCategoryandSubCategory))
            {
                btnCategorySubCategory.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeRolesandAuthorities))
            {
                btnRoleAuths.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeManagementControl))
            {
                btnManagmentControl.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeCustomerTransfer))
            {
                btnCustomerTransfer.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeUserModule))
            {
                btnUser.Visible = false;
            }
            #endregion
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

        private void btnCustomerTransfer_Click(object sender, EventArgs e)
        {
            FormUserCustomerUpdate form = new FormUserCustomerUpdate();
            form.ShowDialog();
        }

        private void altoSlidingLabel1_DoubleClick(object sender, EventArgs e)
        {
            frm_RSInvoice form = new frm_RSInvoice();
            form.Show();
        }

        private void altoSlidingLabel1_Click(object sender, EventArgs e)
        {
            //frmSupplierMain form = new frmSupplierMain();
            //form.Show();
        }

        private void btnUser_Click_1(object sender, EventArgs e)
        {
            FormUserMain roles = new FormUserMain(this);
            roles.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FormLogKayit logKayit = new FormLogKayit(this);
            logKayit.Show();
        }
    }
}
