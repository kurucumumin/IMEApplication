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
            if (!Utils.AuthorityCheck(IMEAuthority.ViewManagementModule))
            {
                btnManagement.Enabled = false;
                pnlManagement.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewLoaderModule))
            {
                btnFileLoader.Enabled = false;
                pnlImportFiles.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewWorkToBeModule))
            {
                btnDevelopment.Enabled = false;
            }
            #endregion

            #region Main
            if (!Utils.AuthorityCheck(IMEAuthority.UpdateItemCardModule))
            {
                btnItemCard.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewCustomerModule))
            {
                btnCustomer.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewSupplierModule))
            {
                btnSupplier.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewQuotationModule))
            {
                btnQuotation.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewSaleOrderModule))
            {
                btnSalesOrder.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewPurchaseOrderModule))
            {
                btnPurchaseOrder.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewStockModule))
            {
                btnStock.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewInvoiceModule))
            {
                btnToBeInvoiced.Enabled = false;
            }
            #endregion

            #region Import Files
            if (!Utils.AuthorityCheck(IMEAuthority.ViewRsInvoice))
            {
                btnRsInvoice.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewSuperDisk))
            {
                btnSuperDisk.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewSuperDiskP))
            {
                btnSuperDiskwithP.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewSlidingPrice))
            {
                btnSlidingPriceList.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewHazardouse))
            {
                btnHazardousFile.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewRsProList))
            {
                btnRSProList.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewTSEList))
            {
                btnTSEList.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewDualUsedArticles))
            {
                btnDualUsedArticles.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewExtendedRangePrice))
            {
                btnExtendedRangePrice.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewDiscountinuedList))
            {
                btnDiscontinuedList.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewOnSale))
            {
                btnOnSale.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewOrderAcknowledgemenet))
            {
                btnOrderAcknowledgement.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewBackOrder))
            {
                btnBackOrder.Enabled = false;
            }
            #endregion

            #region Managment
            if (!Utils.AuthorityCheck(IMEAuthority.ViewExchangeRate))
            {
                btnExchangeRate.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewTermsofPayment))
            {
                btnTermsOfPayment.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewCategoryAndSubCategory))
            {
                btnCategorySubCategory.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewRolesandAuthorities))
            {
                btnRoleAuths.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewManagementControl))
            {
                btnManagmentControl.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewCustomerTransfer))
            {
                btnCustomerTransfer.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewUserModule))
            {
                btnUser.Enabled = false;
            }
            #endregion
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FormSupplierMain supplierMain = new FormSupplierMain();
            //frmSupplierMain supplierMain = new frmSupplierMain();
            supplierMain.Show();
            Utils.LogKayit("Supplier", "Supplier main screen has been entered");
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            FormSalesOrderMain saleOrderMain = new FormSalesOrderMain();
            saleOrderMain.Show();
            Utils.LogKayit("SaleOrder Main", "SaleOrder main screen has been entered");
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FormCustomerMain customerMain = new FormCustomerMain();
            customerMain.Show();
            Utils.LogKayit("Customer Main", "Customer main screen has been entered");
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain form = new PurchaseOrderMain();
            form.Show();
            Utils.LogKayit("PurchaseOrder Main", "PurchaseOrder main screen has been entered");
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard frmItem = new ItemCard();
            frmItem.Show();
            Utils.LogKayit("ItemCard Main", "ItemCard main screen has been entered");
        }

        private void btnQuotation_Click(object sender, EventArgs e)
        {
            FormQuotationMain formQuotationMain = new FormQuotationMain();
            formQuotationMain.Show();
            Utils.LogKayit("Quotation Main", "Quotation main screen has been entered");
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmStock frmStock = new frmStock();
            frmStock.Show();
            Utils.LogKayit("Stock Main", "Stock main screen has been entered");
        }

        private void btnToBeInvoiced_Click(object sender, EventArgs e)
        {
            frmFaturalanacaklar frmFatura = new frmFaturalanacaklar();
            frmFatura.Show();
            Utils.LogKayit("ToBeInvoiced Main", "ToBeInvoiced main screen has been entered");
        }

        private void GoToLoaderPage()
        {
            LoaderPage form = new LoaderPage();
            form.ShowDialog();
            Utils.LogKayit(txtReader.LoaderType, txtReader.LoaderType +"main screen has been entered");

        }

        private void btnRsInvoice_Click(object sender, EventArgs e)
        {
            frm_RSInvoice form = new frm_RSInvoice();
            form.Show();
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
            Utils.LogKayit("BackOrder Main", "BackOrder main screen has been entered");
        }

        private void btnExchangeRate_Click(object sender, EventArgs e)
        {
            frmExchangeRate form = new frmExchangeRate();
            form.ShowDialog();
            Utils.LogKayit("ExchangeRate Main", "ExchangeRate main screen has been entered");
        }

        private void btnTermsOfPayment_Click(object sender, EventArgs e)
        {
            FormTermsOfPayment form = new FormTermsOfPayment();
            form.ShowDialog();
            Utils.LogKayit("TermsOfPayment Main", "TermsOfPayment main screen has been entered");
        }

        private void btnCategorySubCategory_Click(object sender, EventArgs e)
        {
            FormCategorySubCategory form = new FormCategorySubCategory();
            form.ShowDialog();
            Utils.LogKayit("CategorySubCategory Main", "CategorySubCategory main screen has been entered");
        }

        private void btnRoleAuths_Click(object sender, EventArgs e)
        {
            FormRoleAuths form = new FormRoleAuths();
            form.ShowDialog();
            Utils.LogKayit("RoleAuths Main", "RoleAuths main screen has been entered");
        }

        private void btnManagmentControl_Click(object sender, EventArgs e)
        {
            FormManagmentControl form = new FormManagmentControl();
            form.ShowDialog();
            Utils.LogKayit("ManagmentControl Main", "ManagmentControl main screen has been entered");
        }

        private void btnCustomerTransfer_Click(object sender, EventArgs e)
        {
            FormUserCustomerUpdate form = new FormUserCustomerUpdate();
            form.ShowDialog();
            Utils.LogKayit("CustomerTransfer Main", "CustomerTransfer main screen has been entered");
        }

        private void btnUser_Click_1(object sender, EventArgs e)
        {
            FormUserMain roles = new FormUserMain(this);
            roles.Show();
            Utils.LogKayit("User Main", "User main screen has been entered");
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FormLogKayit logKayit = new FormLogKayit(this);
            logKayit.Show();
            Utils.LogKayit("LogRecords Main", "LogRecords main screen has been entered");
        }

        private void altoSlidingLabel1_Click(object sender, EventArgs e)
        {
            frmSupplierMain frm = new frmSupplierMain();
            frm.Show();
        }
    }
}
