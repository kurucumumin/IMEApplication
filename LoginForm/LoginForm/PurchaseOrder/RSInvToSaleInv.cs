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
    public partial class SaleOrderToDeliveryNote : Form
    {
        frmDeliveryNote parent;

        public SaleOrderToDeliveryNote(frmDeliveryNote parentDeliveryNote)
        {
            InitializeComponent();
            this.parent = parentDeliveryNote;
        }

        public SaleOrderToDeliveryNote()
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
            dgSaleOrder.DataSource = IME.SaleOrderToDeliveryNote(parent.txtCustomer.Text).ToList();
        }


        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgSaleOrderDetails.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = true;
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgSaleOrderDetails.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = true;
            }
        }

        private void btnDeliveryNote_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            dt.Columns.Add("dgCName");
            dt.Columns.Add("dgItemCode");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("dgStockQuantity");
            //dt.Columns.Add("NetAmount");
            dt.Columns.Add("ProductDesc");
            dt.Columns.Add("BillingDocumentDate");
            dt.Columns.Add("dgSaleOrderDetailID");
            dt.Columns.Add("dgUOM");
            dt.Columns.Add("dgUnitPrice");
            dt.Columns.Add("dgUnitContent");
            dt.Columns.Add("dgSaleOrderID");
            //dt.Columns.Add("PurchaseOrderNo");
            dt.Columns.Add("Currency");
            for (int i = 0; i < dgSaleOrderDetails.RowCount; i++)
            {
                DataRow row = dt.NewRow();
                row["dgCName"] = dgSaleOrderDetails.Rows[i].Cells[dgCName.Index].Value.ToString();
                row["dgItemCode"] = dgSaleOrderDetails.Rows[i].Cells[dgItemCode.Index].Value.ToString();
                row["Quantity"] = dgSaleOrderDetails.Rows[i].Cells[dgQuantity.Index].Value.ToString();
                row["dgStockQuantity"] = dgSaleOrderDetails.Rows[i].Cells[dgStockQuantity.Index].Value.ToString();
                row["ProductDesc"] = dgSaleOrderDetails.Rows[i].Cells[dgProductDescription.Index].Value.ToString();
                row["dgSaleOrderDetailID"] = dgSaleOrderDetails.Rows[i].Cells[dgSaleOrderDetailID.Index].Value.ToString();
                row["dgUOM"] = dgSaleOrderDetails.Rows[i].Cells[dgUnitOfMeasure.Index].Value.ToString();
                row["dgUnitPrice"] = dgSaleOrderDetails.Rows[i].Cells[dgUnitPrice.Index].Value.ToString();
                row["dgUnitContent"] = dgSaleOrderDetails.Rows[i].Cells[dgUnitContent.Index].Value.ToString();
                row["dgSaleOrderID"] = dgSaleOrderDetails.Rows[i].Cells[dgSaleOrderID.Index].Value.ToString();
                //string PONo;
                //PONo = dgSaleInvoice.Rows[i].Cells[PODetailNo.Index].Value.ToString();
                dt.Rows.Add(row);
            }
            parent.setSaleOrderItemsFromPopUp(dt);
            this.Close();
            //form.Show();
        }

        private void dgSaleOrder_SelectionChanged(object sender, EventArgs e)
        {
            try {
                dgSaleOrderDetails.Rows.Clear();
                IMEEntities IME = new IMEEntities();
                    foreach (DataGridViewRow item in dgSaleOrder.SelectedRows)
                    {
                        foreach (var item1 in IME.SaleOrderItemsToDeliveryNote(decimal.Parse(item.Cells["SaleOrderID"].Value.ToString())))
                        {
                            dgSaleOrderDetails.AllowUserToAddRows = true;
                            DataGridViewRow row = (DataGridViewRow)dgSaleOrderDetails.Rows[0].Clone();
                            row.Cells[dgCName.Index].Value = item1.c_name;
                            row.Cells[dgItemCode.Index].Value = item1.ItemCode;
                            row.Cells[dgQuantity.Index].Value = item1.NumberToSend;
                            row.Cells[dgStockQuantity.Index].Value = item1.StockQuantityForCustmer;
                            row.Cells[dgSaleOrderID.Index].Value = item1.SaleOrderID;
                            row.Cells[dgProductDescription.Index].Value = item1.ItemDescription;
                            row.Cells[dgSaleOrderDetailID.Index].Value = item1.SaleOrderDetailID;
                            row.Cells[dgUnitContent.Index].Value = item1.UnitContent;
                            row.Cells[dgUnitOfMeasure.Index].Value = item1.UnitOfMeasure;
                            row.Cells[dgUnitPrice.Index].Value = item1.UnitPrice;
                            dgSaleOrderDetails.Rows.Add(row);
                            dgSaleOrderDetails.AllowUserToAddRows = false;
                            dgSaleOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        }
                    }
            }
            catch { }
        }
    }
}
