using LoginForm.Services.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.f_RSInvoice
{
    public partial class frm_RsInvoiceDetail : Form
    {
        int InvoiceID;
        DataTable RsInvoiceDetails = new DataTable();
        DataTable RsInvoiceMaster = new DataTable();

        public frm_RsInvoiceDetail(int InvoiceID)
        {
            InitializeComponent();
            this.InvoiceID = InvoiceID;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgRsInvoiceItems, new object[] { true });
        }

        private void frm_RsInvoiceDetail_Load(object sender, EventArgs e)
        {
            bgw_RsInvoiceDetail.RunWorkerAsync();
            bgw_RsInvoiceMaster.RunWorkerAsync();
        }

        private void SetGridColumnWidths()
        {
            dgRsInvoiceItems.Columns["PurchaseOrderID"].Visible = false;

            dgRsInvoiceItems.Columns["PurchaseOrderNumber"].HeaderText = "Purchase Order Number";
            dgRsInvoiceItems.Columns["PurchaseOrderNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["PurchaseOrderItemNumber"].HeaderText = "Purchase Order Item Number";
            dgRsInvoiceItems.Columns["PurchaseOrderItemNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["ProductNumber"].HeaderText = "Product Number";
            dgRsInvoiceItems.Columns["ProductNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["BillingItemNumber"].HeaderText = "Billing Item Number";
            dgRsInvoiceItems.Columns["BillingItemNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["Quantity"].HeaderText = "Quantity";
            dgRsInvoiceItems.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["SalesUnit"].HeaderText = "Sales Unit";
            dgRsInvoiceItems.Columns["SalesUnit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["Discount"].HeaderText = "Discount";
            dgRsInvoiceItems.Columns["Discount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["GoodsValue"].HeaderText = "Goods Value";
            dgRsInvoiceItems.Columns["GoodsValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["Amount"].HeaderText = "Amount";
            dgRsInvoiceItems.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["CCCNNO"].HeaderText = "CCCNNO";
            dgRsInvoiceItems.Columns["CCCNNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["CountryofOrigin"].HeaderText = "CofO";
            dgRsInvoiceItems.Columns["CountryofOrigin"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["ArticleDescription"].HeaderText = "Article Description";
            dgRsInvoiceItems.Columns["ArticleDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["DeliveryNumber"].HeaderText = "Delivery Number";
            dgRsInvoiceItems.Columns["DeliveryNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["DeliveryItemNumber"].HeaderText = "Delivery Item Number";
            dgRsInvoiceItems.Columns["DeliveryItemNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["Tax"].HeaderText = "Tax";
            dgRsInvoiceItems.Columns["Tax"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void bgw_RsInvoiceDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            RsInvoiceDetails = new Sp_RSInvoice().GetRSInvoiceDetailWithInvoiceID(InvoiceID);
        }

        private void bgw_RsInvoiceDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgRsInvoiceItems.DataSource = RsInvoiceDetails;
            SetGridColumnWidths();
            dgRsInvoiceItems.ClearSelection();
            dgRsInvoiceItems.Focus();
        }

        private void bgw_RsInvoiceMaster_DoWork(object sender, DoWorkEventArgs e)
        {
            RsInvoiceMaster = new Sp_RSInvoice().GetRSInvoiceWithInvoiceID(InvoiceID);
        }

        private void bgw_RsInvoiceMaster_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtBillingDocumentDate.Text = RsInvoiceMaster.Rows[0]["BillingDocumentDate"].ToString();
            txtBillingDocumentReference.Text = RsInvoiceMaster.Rows[0]["BillingDocumentReference"].ToString();
            txtCustomerReference.Text = RsInvoiceMaster.Rows[0]["CustomerReference"].ToString();
            txtAirwayBillNumber.Text = RsInvoiceMaster.Rows[0]["AirwayBillNumber"].ToString();
            txtSupplyingECCompany.Text = RsInvoiceMaster.Rows[0]["SupplyingECCompany"].ToString();
            txtSupplyingECCompany.Text = RsInvoiceMaster.Rows[0]["SupplyingECCompany"].ToString();
            txtShipmentReference.Text = RsInvoiceMaster.Rows[0]["ShipmentReference"].ToString();
            txtShippingCondition.Text = RsInvoiceMaster.Rows[0]["ShippingCondition"].ToString();
            txtStatus.Text = RsInvoiceMaster.Rows[0]["Status"].ToString();
            txtDeleted.Text = RsInvoiceMaster.Rows[0]["Deleted"].ToString();
            txtCurrency.Text = RsInvoiceMaster.Rows[0]["Currency"].ToString();
            txtInvoiceTaxValue.Text = RsInvoiceMaster.Rows[0]["InvoiceTaxValue"].ToString();
            txtInvoiceGoodsValue.Text = RsInvoiceMaster.Rows[0]["InvoiceGoodsValue"].ToString();
            txtInvoiceNettValue.Text = RsInvoiceMaster.Rows[0]["InvoiceNettValue"].ToString();
            txtDiscount.Text = RsInvoiceMaster.Rows[0]["Discount"].ToString();
            txtSurcharge.Text = RsInvoiceMaster.Rows[0]["Surcharge"].ToString();
        }
    }
}
