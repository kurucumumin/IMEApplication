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
            dataGridView1.DataSource = IME.SaleOrderToDeliveryNote();
        }

        private void dgPurchaseOrder_SelectionChanged(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();


            try { IME.SaleOrderItemsToDeliveryNote(decimal.Parse(dataGridView1.CurrentRow.Cells["SaleOrderID"].ToString())); } catch { }
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
            dt.Columns.Add("dgCName");
            dt.Columns.Add("dgItemCode");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("dgStockQuantity");
            dt.Columns.Add("NetAmount");
            dt.Columns.Add("ProductDesc");
            dt.Columns.Add("BillingDocumentDate");
            dt.Columns.Add("PurchaseOrderNo");
            dt.Columns.Add("Currency");
            for (int i = 0; i < dgSaleInvoice.RowCount; i++)
            {
                DataRow row = dt.NewRow();
                row["dgCName"] = dgSaleInvoice.Rows[i].Cells[dgCName.Index].Value.ToString();
                row["dgItemCode"] = dgSaleInvoice.Rows[i].Cells[dgItemCode.Index].Value.ToString();
                row["Quantity"] = dgSaleInvoice.Rows[i].Cells[dgQuantity.Index].Value.ToString();
                row["dgStockQuantity"] =
                    (dgSaleInvoice.Rows[i].Cells[dgStockQuantity.Index].Value.ToString()).ToString();
                row["dgSaleOrderID"] = dgSaleInvoice.Rows[i].Cells[dgSaleOrderID.Index].Value.ToString();
                //string PONo;
                //PONo = dgSaleInvoice.Rows[i].Cells[PODetailNo.Index].Value.ToString();
            }
            frmSalesInvoice form = new frmSalesInvoice(dt);
           // form.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try {
                dgSaleInvoice.Rows.Clear();
                IMEEntities IME = new IMEEntities();
                    foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                    {

                        foreach (var item1 in IME.SaleOrderItemsToDeliveryNote(decimal.Parse(item.Cells["SaleOrderID"].Value.ToString())))
                        {
                            dgSaleInvoice.AllowUserToAddRows = true;
                            DataGridViewRow row = (DataGridViewRow)dgSaleInvoice.Rows[0].Clone();
                            row.Cells[dgCName.Index].Value = item1.c_name;
                            row.Cells[dgItemCode.Index].Value = item1.ItemCode;
                            row.Cells[dgQuantity.Index].Value = item1.StockQuantityForCustmer;
                            row.Cells[dgStockQuantity.Index].Value = item1.StockQuantityForCustmer;
                            row.Cells[dgSaleOrderID.Index].Value = item1.SaleOrderID;
                            dgSaleInvoice.Rows.Add(row);
                            dgSaleInvoice.AllowUserToAddRows = false;
                            dgSaleInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        }
                    }
                
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgSaleInvoice.Rows.Clear();
        }
    }
}
