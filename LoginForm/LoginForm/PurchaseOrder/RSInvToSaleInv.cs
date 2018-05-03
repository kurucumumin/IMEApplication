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
        Form parent;
        string ItemsFrom = String.Empty;

        public SaleOrderToDeliveryNote(Form parentDeliveryNote, string ItemsFrom)
        {
            InitializeComponent();
            this.parent = parentDeliveryNote;
            this.ItemsFrom = ItemsFrom;
        }

        public SaleOrderToDeliveryNote()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Close();
        }

        private void RSInvToSaleInv_Load(object sender, EventArgs e)
        {
            //parent.Enabled = false;

            IMEEntities IME = new IMEEntities();
            if(parent.GetType() == typeof(frmDeliveryNote))
            {
                dgSaleOrder.DataSource = IME.SaleOrderToDeliveryNote(((frmDeliveryNote)parent).txtCustomer.Text).ToList();
            }
            else
            {
                if (ItemsFrom == "SaleOrder")
                {
                    dgSaleOrder.DataSource = IME.SaleOrderToDeliveryNote(((frmSalesInvoice)parent).txtCustomer.Text).ToList();
                }
                else if(ItemsFrom == "DeliveryNote")
                {
                    dgSaleOrder.DataSource = IME.DeliveryNoteToSaleInvoice(((frmSalesInvoice)parent).txtCustomer.Text).ToList();
                }
            }
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
            dt.Columns.Add("dgDetailID");
            dt.Columns.Add("dgUOM");
            dt.Columns.Add("dgUnitPrice");
            dt.Columns.Add("dgUnitContent");
            dt.Columns.Add("dgMasterNo");
            //dt.Columns.Add("PurchaseOrderNo");
            dt.Columns.Add("Currency");
            dt.Columns.Add("dgUPIME");
            for (int i = 0; i < dgSaleOrderDetails.RowCount; i++)
            {
                DataRow row = dt.NewRow();
                DataGridViewRow currentRow = dgSaleOrderDetails.Rows[i];
                //row["dgCName"] = dgSaleOrderDetails.Rows[i].Cells[dgCName.Index].Value.ToString();
                row["dgItemCode"] = currentRow.Cells[dgItemCode.Index].Value.ToString();
                row["Quantity"] = currentRow.Cells[dgQuantity.Index].Value.ToString();
                row["dgStockQuantity"] = currentRow.Cells[dgStockQuantity.Index].Value?.ToString();
                row["ProductDesc"] = currentRow.Cells[dgProductDescription.Index].Value.ToString();
                row["dgDetailID"] = currentRow.Cells[dgDetailID.Index].Value.ToString();
                row["dgUOM"] = currentRow.Cells[dgUnitOfMeasure.Index].Value?.ToString();
                row["dgUnitPrice"] = currentRow.Cells[dgUnitPrice.Index].Value.ToString();
                row["dgUnitContent"] = currentRow.Cells[dgUnitContent.Index].Value.ToString();
                row["dgMasterNo"] = currentRow.Cells[dgMasterNo.Index].Value.ToString();
                row["dgUPIME"] = currentRow.Cells[dgUPIME.Index].Value.ToString();
                //string PONo;
                //PONo = dgSaleInvoice.Rows[i].Cells[PODetailNo.Index].Value.ToString();
                dt.Rows.Add(row);
            }
            //parent.Enabled = true;

            if(parent.GetType() == typeof(frmDeliveryNote))
            {
                ((frmDeliveryNote)parent).setDeliveryNoteItemsFromPopUp(dt);
            }
            else
            {
                ((frmSalesInvoice)parent).setSaleOrderItemsFromPopUp(dt);
            }
            
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
                    if (ItemsFrom == "SaleOrder")
                    {
                        var list = IME.SaleOrderItemsToDeliveryNote(decimal.Parse(item.Cells["SaleOrderID"].Value.ToString()));

                        foreach (var item1 in list)
                        {
                            dgSaleOrderDetails.AllowUserToAddRows = true;
                            DataGridViewRow row = (DataGridViewRow)dgSaleOrderDetails.Rows[0].Clone();
                            //row.Cells[dgCName.Index].Value = item1.;
                            row.Cells[dgItemCode.Index].Value = item1.ItemCode;
                            row.Cells[dgQuantity.Index].Value = item1.NumberToSend;
                            row.Cells[dgStockQuantity.Index].Value = item1.StockQuantityForCustmer;
                            row.Cells[dgMasterNo.Index].Value = item1.SaleOrderID;
                            row.Cells[dgProductDescription.Index].Value = item1.ItemDescription;
                            row.Cells[dgDetailID.Index].Value = item1.SaleOrderDetailID;
                            row.Cells[dgUnitContent.Index].Value = item1.UnitContent;
                            row.Cells[dgUnitOfMeasure.Index].Value = item1.UnitOfMeasure;
                            row.Cells[dgUnitPrice.Index].Value = item1.UnitPrice;
                            row.Cells[dgUPIME.Index].Value = item1.UPIME;
                            dgSaleOrderDetails.Rows.Add(row);
                            dgSaleOrderDetails.AllowUserToAddRows = false;
                            dgSaleOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        }
                    }else if (ItemsFrom == "DeliveryNote")
                    {
                        var list = IME.DeliveryNoteItemsToSaleInvoice(item.Cells["Delivery_Note_No"].Value.ToString()).ToList();
                        foreach (var item1 in list)
                        {
                            dgSaleOrderDetails.AllowUserToAddRows = true;
                            DataGridViewRow row = (DataGridViewRow)dgSaleOrderDetails.Rows[0].Clone();
                            dgSaleOrderDetails.Columns[dgMasterNo.Index].HeaderText = "Delivery Note No";
                            dgSaleOrderDetails.Columns[dgDetailID.Index].HeaderText = "Delivery Note Detail ID";
                            row.Cells[dgItemCode.Index].Value = item1.Product_ID;
                            row.Cells[dgQuantity.Index].Value = item1.Sent_Quantity;
                            row.Cells[dgMasterNo.Index].Value = item1.Delivery_Note_NO;
                            row.Cells[dgProductDescription.Index].Value = item1.Product_Description;
                            row.Cells[dgDetailID.Index].Value = item1.Delivery_Note_ID;
                            row.Cells[dgUnitContent.Index].Value = item1.Unit_Content;
                            row.Cells[dgUnitOfMeasure.Index].Value = item1.Unit_Of_Measure;
                            row.Cells[dgUnitPrice.Index].Value = item1.UnitPrice;
                            row.Cells[dgUPIME.Index].Value = item1.UPIME;
                            dgSaleOrderDetails.Rows.Add(row);
                            dgSaleOrderDetails.AllowUserToAddRows = false;
                            dgSaleOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        }
                    }
                }
            }
            catch { }
        }
    }
}
