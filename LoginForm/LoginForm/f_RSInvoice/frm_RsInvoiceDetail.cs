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
            dgRsInvoiceItems.DataSource = new Sp_RSInvoice().GetRSInvoiceDetailWithID(InvoiceID);
            dgRsInvoiceItems.ClearSelection();
            dgRsInvoiceItems.Focus();
        }

        private void FixGridColumns()
        {
            dgRsInvoiceItems.Columns["ID"].Visible = false;

            dgRsInvoiceItems.Columns["ShipmentReference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["ShipmentReference"].HeaderText = "Shipment Reference";
            dgRsInvoiceItems.Columns["BillingDocumentReference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["BillingDocumentReference"].HeaderText = "Billing Document Reference";
            dgRsInvoiceItems.Columns["ShippingCondition"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["ShippingCondition"].HeaderText = "Shipping Condition";
            dgRsInvoiceItems.Columns["BillingDocumentDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["BillingDocumentDate"].HeaderText = "Billing DocumentDate";
            dgRsInvoiceItems.Columns["SupplyingECCompany"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["SupplyingECCompany"].HeaderText = "Supplying EC Company";
            dgRsInvoiceItems.Columns["CustomerReference"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["CustomerReference"].HeaderText = "Customer Reference";
            dgRsInvoiceItems.Columns["InvoiceTaxValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["InvoiceTaxValue"].HeaderText = "Invoice Tax Value";
            dgRsInvoiceItems.Columns["InvoiceGoodsValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["InvoiceGoodsValue"].HeaderText = "Invoice Goods Value";
            dgRsInvoiceItems.Columns["InvoiceNettValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["InvoiceNettValue"].HeaderText = "Invoice Nett Value";
            dgRsInvoiceItems.Columns["Currency"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["AirwayBillNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgRsInvoiceItems.Columns["AirwayBillNumber"].HeaderText = "Airway Bill Number";
            dgRsInvoiceItems.Columns["Discount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["Surcharge"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["Deleted"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRsInvoiceItems.Columns["Supplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }
    }
}
