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

        private void bgw_RsInvoiceDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            RsInvoiceDetails = new Sp_RSInvoice().GetRSInvoiceDetailWithInvoiceID(InvoiceID);
        }

        private void bgw_RsInvoiceDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgRsInvoiceItems.Rows.Clear();
            SetDataGridItemsRsInvoiceDetail(RsInvoiceDetails);
            dgRsInvoiceItems.Refresh();
        }

        private void SetDataGridItemsRsInvoiceDetail(DataTable dataTable)
        {
            foreach (DataRow dRow in dataTable.Rows)
            {
                DataGridViewRow gRow = dgRsInvoiceItems.Rows[dgRsInvoiceItems.Rows.Add()];

                gRow.Cells[dgPurchaseOrderNumber.Index].Value = dRow["PurchaseOrderNumber"].ToString();
                gRow.Cells[dgPurchaseOrderItemNumber.Index].Value = dRow["PurchaseOrderItemNumber"].ToString();
                gRow.Cells[dgProductNumber.Index].Value = dRow["ProductNumber"].ToString();
                gRow.Cells[dgBillingItemNumber.Index].Value = dRow["BillingItemNumber"].ToString();
                gRow.Cells[dgQuantity.Index].Value = dRow["Quantity"].ToString();
                gRow.Cells[dgSalesUnit.Index].Value = dRow["SalesUnit"].ToString();
                gRow.Cells[dgDiscount.Index].Value = dRow["Discount"].ToString();
                gRow.Cells[dgGoodsValue.Index].Value = dRow["GoodsValue"].ToString();
                gRow.Cells[dgAmount.Index].Value = dRow["Amount"].ToString();
                gRow.Cells[dgCCCNNO.Index].Value = dRow["CCCNNO"].ToString();
                gRow.Cells[dgCountryofOrigin.Index].Value = dRow["CountryofOrigin"].ToString();
                gRow.Cells[dgArticleDescription.Index].Value = dRow["ArticleDescription"].ToString();
                gRow.Cells[dgDeliveryNumber.Index].Value = dRow["DeliveryNumber"].ToString();
                gRow.Cells[dgDeliveryItemNumber.Index].Value = dRow["DeliveryItemNumber"].ToString();
                gRow.Cells[dgPurchaseOrderID.Index].Value = dRow["PurchaseOrderID"].ToString();
                gRow.Cells[dgTax.Index].Value = dRow["Tax"].ToString();

            }
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
