using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;
using LoginForm.Services;
using System.Data.SqlClient;


namespace LoginForm.PurchaseOrder
{
    public partial class NewPurchaseOrder : Form
    {
        IMEEntities IME = new IMEEntities();
        List<SaleOrderDetail> saleItemList = new List<SaleOrderDetail>();
        SqlDataAdapter da;
        System.Data.DataSet ds = new System.Data.DataSet();
        int purchasecode;
        int fiche;

        public NewPurchaseOrder()
        {
            InitializeComponent();
        }

        public NewPurchaseOrder(string item_code)
        {
            InitializeComponent();
            PurchaseOrdersDetailFill(item_code);
        }

        public NewPurchaseOrder(int ficheNo, int sayac)
        {
            InitializeComponent();

            if (sayac == 1)
                PurchaseOrdersDetailFill2(ficheNo);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            IME = new IMEEntities();
            List<DataGridViewRow> rowList = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgPurchase.Rows)
            {
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                {
                    rowList.Add(row);
                }      
            }

            #region Save
            #endregion


            PurchaseExportFiles form = new PurchaseExportFiles(rowList, purchasecode);
            form.ShowDialog();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain f = new PurchaseOrderMain();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.ShowDialog();
                this.Close();
            }
        }

        private void NewPurchaseOrder_Load(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            if (IME.PurchaseOrders.Count() == 0)
            {
                txtOrderNumber.Text = "1";
                purchasecode = 1;
            }
            else
            {
                purchasecode = IME.PurchaseOrders.OrderByDescending(q => q.FicheNo).FirstOrDefault().FicheNo;
                txtOrderNumber.Text = (purchasecode + 1).ToString();
                purchasecode = purchasecode + 1;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string PurchaseNo = dgPurchase.CurrentRow.Cells[1].Value.ToString();
            ExcelPurchaseOrder.Export(dgPurchase, PurchaseNo);
        }

        private void PurchaseOrdersDetailFill(string code)
        {
            IME = new IMEEntities();

            #region Purchase Orders Detail Fill
            var adapter = (from p in IME.SaleOrderDetails.Where(p => p.SaleOrderNo == code)
                           select new
                           {
                               p.SaleOrder.Customer.c_name,
                               p.SaleOrder.QuotationNos,
                               p.SaleOrderNo,
                               p.ItemCode,
                               p.ItemDescription,
                               p.UPIME,
                               p.Quantity,
                               p.Hazardous,
                               p.Calibration,
                               p.SaleOrder.SaleOrderNature,
                               p.SaleOrder.DeliveryAddressID,
                               p.SaleOrder.InvoiceAddressID,
                               p.ItemCost
                           }).ToList();

            foreach (var item in adapter)
            {
                int rowIndex = dgPurchase.Rows.Add();
                DataGridViewRow row = dgPurchase.Rows[rowIndex];

                //var addList = IME.PurchaseOrders.Where(p => p.FicheNo == purchasecode - 1).FirstOrDefault().Customer.CustomerAddresses;

                //var cbCellBill = row.Cells[AddressType.Index].Value as DataGridViewComboBoxCell;
                //cbCellBill.DataSource = addList.ToList();

                //var cbCellShip = row.Cells[AdressTitle.Index].Value as DataGridViewComboBoxCell;
                //cbCellShip.DataSource = addList.ToList();

                row.Cells[c_name.Index].Value = item.c_name;
                row.Cells[QuotationNos.Index].Value = item.QuotationNos;
                row.Cells[SaleOrderNo.Index].Value = item.SaleOrderNo;
                row.Cells[ItemCode.Index].Value = item.ItemCode;
                row.Cells[ItemDescription.Index].Value = item.ItemDescription;
                row.Cells[UnitOfMeasure.Index].Value = item.UPIME;
                row.Cells[Quantity.Index].Value = item.Quantity;
                row.Cells[Hazardous.Index].Value = item.Hazardous;
                row.Cells[Calibration.Index].Value = item.Calibration;
                row.Cells[SaleOrderNature.Index].Value = item.SaleOrderNature;
                row.Cells[AddressType.Index].Value = item.DeliveryAddressID;
                row.Cells[AdressTitle.Index].Value = item.InvoiceAddressID;
                row.Cells[UPIME.Index].Value = item.ItemCost;
                //  row.Cells[Total.Index].Value = Decimal.Parse(row.Cells[Quantity.Index].Value.ToString()) * Decimal.Parse(row.Cells[UPIME.Index].Value.ToString());
            }
            #endregion

        }

        private void PurchaseOrdersDetailFill2(int ficheNo)
        {
            IME = new IMEEntities();
            #region Purchase Orders Detail Fill
            var adapter = (from p in IME.PurchaseOrderDetails.Where(p => p.FicheNo == ficheNo)
                           select new
                           {
                               p.PurchaseOrder.Customer.c_name,
                               p.QuotationNo,
                               p.SaleOrderNo,
                               p.ItemCode,
                               p.ItemDescription,
                               p.UnitPrice,
                               p.SendQty,
                               p.Hazardous,
                               p.Calibration,
                               p.SaleOrderNature,
                               p.SaleOrder.Customer.CurrNameQuo,
                               p.SaleOrder.Customer.CurrNameInv,
                               p.Unit
                           }).ToList();

            foreach (var item in adapter)
            {
                int rowIndex = dgPurchase.Rows.Add();
                DataGridViewRow row = dgPurchase.Rows[rowIndex];

                //var addList = IME.PurchaseOrders.Where(p => p.FicheNo == ficheNo).FirstOrDefault().Customer.CurrNameQuo;

                //var cbCellBill = row.Cells[AddressType.Index].Value as DataGridViewComboBoxCell;
                //if (cbCellBill != null)
                //    cbCellBill.DataSource = addList.ToList();
                //else
                //    cbCellBill.DataSource = null;

                //var addList2 = IME.PurchaseOrders.Where(p => p.FicheNo == ficheNo).FirstOrDefault().Customer.CurrNameInv;
                //var cbCellShip = row.Cells[AdressTitle.Index].Value as DataGridViewComboBoxCell;
                //if (cbCellShip != null)
                //    cbCellShip.DataSource = addList2.ToList();
                //else
                //    cbCellShip.DataSource = null;

                row.Cells[c_name.Index].Value = item.c_name;
                row.Cells[QuotationNos.Index].Value = item.QuotationNo;
                row.Cells[SaleOrderNo.Index].Value = item.SaleOrderNo;
                row.Cells[ItemCode.Index].Value = item.ItemCode;
                row.Cells[ItemDescription.Index].Value = item.ItemDescription;
                row.Cells[UnitOfMeasure.Index].Value = item.UnitPrice;
                row.Cells[Quantity.Index].Value = item.SendQty;
                row.Cells[Hazardous.Index].Value = item.Hazardous;
                row.Cells[Calibration.Index].Value = item.Calibration;
                row.Cells[SaleOrderNature.Index].Value = item.SaleOrderNature;
                row.Cells[AddressType.Index].Value = item.CurrNameQuo;
                row.Cells[AdressTitle.Index].Value = item.CurrNameInv;
                row.Cells[UPIME.Index].Value = item.Unit;
                // row.Cells[Total.Index].Value = Decimal.Parse(row.Cells[Quantity.Index].Value.ToString()) * Decimal.Parse(row.Cells[UPIME.Index].Value.ToString());
            }
            #endregion

        }

        private void PurchaseOrderFill()
        {
            List<PurchaseOrderDetail> purchaseList = new List<PurchaseOrderDetail>();

            foreach (SaleOrderDetail sod in saleItemList)
            {
                PurchaseOrderDetail pod = new PurchaseOrderDetail();
                pod.ItemCode = sod.ItemCode;
                pod.SaleOrderNature = sod.SaleOrder.SaleOrderNature;
                pod.QuotationNo = sod.SaleOrder.QuotationNos;
                pod.SaleOrderNo = sod.SaleOrderNo;
                pod.ItemDescription = sod.ItemDescription;
                pod.Unit = sod.UnitOfMeasure;
                pod.Hazardous = sod.Hazardous ?? false;
                pod.Calibration = sod.Calibration ?? false;

                purchaseList.Add(pod);
            }

            dgPurchase.DataSource = purchaseList;
        }
    }
}