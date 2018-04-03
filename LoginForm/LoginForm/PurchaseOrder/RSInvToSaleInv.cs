using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;
using System.Windows.Forms;

namespace LoginForm.PurchaseOrder
{
    public partial class RSInvToSaleInv : Form
    {
        public RSInvToSaleInv()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RSInvToSaleInv_Load(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            dataGridView1.DataSource = IME.dgPurchaseOrder();
        }

        private void dgPurchaseOrder_SelectionChanged(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();


            IME.dgPurchaseOrderToSaleInvoiceSearchWithPurchaseId("");
        }

       

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgSaleInvoice.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = true;
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgSaleInvoice.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = true;
            }
            
        }

        private void btnSaleInvoice_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            dt.Columns.Add("Quantity");
            dt.Columns.Add("ProductID");
            dt.Columns.Add("Discount");
            dt.Columns.Add("Amount");
            dt.Columns.Add("NetAmount");
            dt.Columns.Add("ProductDesc");
            dt.Columns.Add("BillingDocumentDate");
            dt.Columns.Add("PurchaseOrderNo");
            dt.Columns.Add("Currency");
            for (int i = 0; i < dgSaleInvoice.RowCount; i++)
            {
                DataRow row = dt.NewRow();
                row["Quantity"] = dgSaleInvoice.Rows[i].Cells[dgQuantity.Index].Value.ToString();
                row["ProductID"] = dgSaleInvoice.Rows[i].Cells[dgProductNumber.Index].Value.ToString();
                row["Discount"] = dgSaleInvoice.Rows[i].Cells[dgDiscount.Index].Value.ToString();
                row["Amount"] =
                    (decimal.Parse(dgSaleInvoice.Rows[i].Cells[dgAmount.Index].Value.ToString()) + decimal.Parse(dgSaleInvoice.Rows[i].Cells[dgDiscount.Index].Value.ToString())).ToString();
                row["NetAmount"] = dgSaleInvoice.Rows[i].Cells[dgAmount.Index].Value.ToString();
                row["ProductDesc"] = dgSaleInvoice.Rows[i].Cells[dgArticleDescription.Index].Value.ToString();
                string strPO = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                 row["BillingDocumentDate"] = IME.RS_InvoiceDetails.Where(a => a.PurchaseOrderNumber == strPO).FirstOrDefault().RS_Invoice.BillingDocumentDate; 
                row["Currency"] = IME.RS_InvoiceDetails.Where(a => a.PurchaseOrderNumber == strPO).FirstOrDefault().RS_Invoice.Currency.ToString();
                //string PONo;
                //PONo = dgSaleInvoice.Rows[i].Cells[PODetailNo.Index].Value.ToString();
                
                row["PurchaseOrderNo"] = dgSaleInvoice.Rows[i].Cells[dgPurchaseOrderNumber.Index].Value.ToString();
                dt.Rows.Add(row);
            }
            frmSalesInvoice form = new frmSalesInvoice(dt);
           // form.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            dgSaleInvoice.Rows.Clear();
            string str = "";
            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0] != null) str = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            foreach (var item in IME.dgPurchaseOrderToSaleInvoiceSearchWithPurchaseId(str))
            {
                dgSaleInvoice.AllowUserToAddRows = true;
                DataGridViewRow row = (DataGridViewRow)dgSaleInvoice.Rows[0].Clone();
                row.Cells[dgAmount.Index].Value = item.Amount;
                row.Cells[dgArticleDescription.Index].Value = item.ArticleDescription;
                row.Cells[dgBillingItemNumber.Index].Value = item.BillingItemNumber;
                row.Cells[dgCCCNNO.Index].Value = item.CCCNNO;
                row.Cells[dgCountryofOrigin.Index].Value = item.CountryofOrigin;
                row.Cells[dgDeliveryItemNumber.Index].Value = item.DeliveryItemNumber;
                row.Cells[dgDeliveryNumber.Index].Value = item.DeliveryNumber;
                row.Cells[dgDiscount.Index].Value = item.Discount;
                row.Cells[dgGoodsValue.Index].Value = item.GoodsValue;
                row.Cells[dgProductNumber.Index].Value = item.ProductNumber;
                row.Cells[dgPurchaseOrderItemNumber.Index].Value = item.PurchaseOrderItemNumber;
                row.Cells[dgPurchaseOrderNumber.Index].Value = item.PurchaseOrderNumber;
                row.Cells[dgQuantity.Index].Value = item.Quantity;
                row.Cells[dgSalesUnit.Index].Value = item.SalesUnit;
                row.Cells[dgUnitPrice.Index].Value = item.UnitPrice;
                
                dgSaleInvoice.Rows.Add(row);
                dgSaleInvoice.AllowUserToAddRows = false;
                dgSaleInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }

        }
    }
}
