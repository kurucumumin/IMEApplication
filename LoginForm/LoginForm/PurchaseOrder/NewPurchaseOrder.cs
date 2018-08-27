using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LoginForm.DataSet;

namespace LoginForm.PurchaseOrder
{
    public partial class NewPurchaseOrder : MyForm
    {
        IMEEntities IME = new IMEEntities();
        List<SaleOrderDetail> saleItemList = new List<SaleOrderDetail>();
        int purchasecode;
        int purchaseno;
        string strPrefix = string.Empty;
        string strSuffix = string.Empty;
        //decimal decPurchaseSuffixPrefixId = 0;
        //decimal decPurchaseOrderTypeId = 0;
        //bool isAutomatic = false;

        public NewPurchaseOrder()
        {
            InitializeComponent();
        }

        public NewPurchaseOrder(decimal item_code)
        {
            InitializeComponent();
            PurchaseOrdersDetailFill(item_code);
        }

        public NewPurchaseOrder(int purchaseId, int sayac)
        {
            InitializeComponent();

            if (sayac == 1)
                PurchaseOrdersDetailFill2(purchaseId);
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

            if (rowList.Count != 0)
            {
                //PurchaseExportFiles form = new PurchaseExportFiles(rowList, purchasecode);
                PurchaseExportFiles form = new PurchaseExportFiles(rowList, purchasecode, Convert.ToInt32(txtOrderNumber.Text));
                form.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Please select an item", "Attention", MessageBoxButtons.OKCancel);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain f = new PurchaseOrderMain();
            if (MessageBox.Show("Are You Sure To Exit Program ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.ShowDialog();
                this.Close();
            }
        }

        private void NewPurchaseOrder_Load(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
           // txtOrderNumber.Enabled = false;
            if (IME.PurchaseOrders.Count() == 0)
            {
                txtOrderNumber.Text = "1";
                txtID.Text = "1";
                purchasecode = 1;
                purchaseno = 1;
            }
            else
            {
                purchasecode = IME.PurchaseOrders.OrderByDescending(q => q.purchaseOrderId).FirstOrDefault().purchaseOrderId;
                //txtOrderNumber.Text = (purchasecode + 1).ToString();
                purchasecode = purchasecode + 1;

                purchaseno = Convert.ToInt32(IME.PurchaseOrders.OrderByDescending(q => q.PurchaseNo).FirstOrDefault().PurchaseNo);
                txtOrderNumber.Text = (purchaseno + 1).ToString();
                purchaseno = purchaseno + 1;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string PurchaseNo = dgPurchase.CurrentRow.Cells[1].Value.ToString();
            ExcelPurchaseOrder.Export(dgPurchase, PurchaseNo);
        }

        private void PurchaseOrdersDetailFill(decimal code)
        {
            IME = new IMEEntities();

            #region Purchase Orders Detail Fill
            var adapter = (from p in IME.SaleOrderDetails.Where(po => po.SaleOrderID == code)
                           select new
                           {
                               p.SaleOrder.Customer.c_name,
                               p.QuotationDetail.QuotationNo,
                               p.SaleOrder.SaleOrderNo,
                               p.ItemCode,
                               p.ItemDescription,
                               p.UPIME,
                               p.Quantity,
                               p.Hazardous,
                               p.Calibration,
                               p.SaleOrder.SaleOrderNature,
                               p.ItemCost,
                               p.SaleOrderID
                           }).ToList();
            readOnly();
            foreach (var item in adapter)
            {
                int rowIndex = dgPurchase.Rows.Add();
                DataGridViewRow row = dgPurchase.Rows[rowIndex];

                row.Cells[c_name.Index].Value = item.c_name;
                row.Cells[QuotationNos.Index].Value = item.QuotationNo;
                row.Cells[SaleOrderNo.Index].Value = item.SaleOrderNo;
                row.Cells[ItemCode.Index].Value = item.ItemCode;
                row.Cells[ItemDescription.Index].Value = item.ItemDescription;
                row.Cells[UnitOfMeasure.Index].Value = item.UPIME;
                row.Cells[Quantity.Index].Value = item.Quantity;
                row.Cells[Hazardous.Index].Value = item.Hazardous;
                row.Cells[Calibration.Index].Value = item.Calibration;
                row.Cells[SaleOrderNature.Index].Value = item.SaleOrderNature;
                row.Cells[AddressType.Index].Value = "IME GENERAL COMPONENTS";
                row.Cells[AdressTitle.Index].Value = "IME GENERAL COMPONENTS";
                row.Cells[UPIME.Index].Value = item.ItemCost;
                row.Cells[SaleID.Index].Value = item.SaleOrderID;
                row.Cells[Total.Index].Value = Decimal.Parse(row.Cells[Quantity.Index].Value.ToString()) * Decimal.Parse(row.Cells[UPIME.Index].Value.ToString());
            }
            #endregion

        }

        private void PurchaseOrdersDetailFill2(int purchaseId)
        {
            IME = new IMEEntities();
            #region Purchase Orders Detail Fill
            var adapter = (from p in IME.PurchaseOrderDetails.Where(p => p.purchaseOrderId == purchaseId)
                           select new
                           {
                               p.PurchaseOrder.Customer.c_name,
                               p.QuotationNo,
                               p.SaleOrderID,
                               p.ItemCode,
                               p.ItemDescription,
                               p.UnitPrice,
                               p.SendQty,
                               p.Hazardous,
                               p.Calibration,
                               p.SaleOrderNature,
                               p.AccountNumber,
                               p.Unit
                           }).ToList();
            readOnlyEnabled();
            foreach (var item in adapter)
            {
                int rowIndex = dgPurchase.Rows.Add();
                DataGridViewRow row = dgPurchase.Rows[rowIndex];

                row.Cells[c_name.Index].Value = item.c_name;
                row.Cells[QuotationNos.Index].Value = item.QuotationNo;
                //SaleOrderID için kontrol et
                //row.Cells[SaleOrderNo.Index].Value = item.SaleOrderID;
                row.Cells[ItemCode.Index].Value = item.ItemCode;
                row.Cells[ItemDescription.Index].Value = item.ItemDescription;
                row.Cells[UnitOfMeasure.Index].Value = item.UnitPrice;
                row.Cells[Quantity.Index].Value = item.SendQty;
                row.Cells[Hazardous.Index].Value = item.Hazardous;
                row.Cells[Calibration.Index].Value = item.Calibration;
                row.Cells[SaleOrderNature.Index].Value = item.SaleOrderNature;
                row.Cells[SaleID.Index].Value = item.SaleOrderID;
                if (item.AccountNumber == 8828170)
                {
                    row.Cells[AddressType.Index].Value = "IME GENERAL COMPONENTS";
                    row.Cells[AdressTitle.Index].Value = "IME GENERAL COMPONENTS";
                }
                if (item.AccountNumber == 8894479)
                {
                    row.Cells[AddressType.Index].Value = "3RD PARTY";
                    row.Cells[AdressTitle.Index].Value = "3RD PARTY";
                }
                row.Cells[UPIME.Index].Value = item.Unit;
                Decimal sonuc = Decimal.Parse(row.Cells[Quantity.Index].Value.ToString()) * Decimal.Parse(row.Cells[UPIME.Index].Value.ToString());
                row.Cells[Total.Index].Value = sonuc.ToString();
                row.Cells[SLC.Index].ReadOnly = true;
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
                pod.QuotationNo = sod.QuotationDetail.QuotationNo;
                pod.SaleOrderID = sod.SaleOrderID;
                pod.ItemDescription = sod.ItemDescription;
                pod.Unit = sod.UnitOfMeasure;
                pod.Hazardous = sod.Hazardous ?? false;
                pod.Calibration = sod.Calibration ?? false;

                purchaseList.Add(pod);
            }
            readOnly();
            dgPurchase.DataSource = purchaseList;
        }

        private void dgPurchase_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBox value is not valid.")
            {
                object value = dgPurchase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgPurchase.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dgPurchase.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void readOnly()
        {
            dgPurchase.Columns[0].ReadOnly = false;
            dgPurchase.Columns[1].ReadOnly = true;
            dgPurchase.Columns[2].ReadOnly = true;
            dgPurchase.Columns[3].ReadOnly = true;
            dgPurchase.Columns[4].ReadOnly = true;
            dgPurchase.Columns[5].ReadOnly = true;
            dgPurchase.Columns[6].ReadOnly = true;
            dgPurchase.Columns[7].ReadOnly = true;
            dgPurchase.Columns[8].ReadOnly = true;
            dgPurchase.Columns[9].ReadOnly = true;
            dgPurchase.Columns[10].ReadOnly = false;
            dgPurchase.Columns[11].ReadOnly = false;
            dgPurchase.Columns[12].ReadOnly = false;
            dgPurchase.Columns[13].ReadOnly = true;
            dgPurchase.Columns[14].ReadOnly = true;
        }

        private void readOnlyEnabled()
        {
            dgPurchase.Columns[0].ReadOnly = false;
            dgPurchase.Columns[1].ReadOnly = true;
            dgPurchase.Columns[2].ReadOnly = true;
            dgPurchase.Columns[3].ReadOnly = true;
            dgPurchase.Columns[4].ReadOnly = true;
            dgPurchase.Columns[5].ReadOnly = true;
            dgPurchase.Columns[6].ReadOnly = true;
            dgPurchase.Columns[7].ReadOnly = true;
            dgPurchase.Columns[8].ReadOnly = true;
            dgPurchase.Columns[9].ReadOnly = true;
            dgPurchase.Columns[10].ReadOnly = true;
            dgPurchase.Columns[11].ReadOnly = true;
            dgPurchase.Columns[12].ReadOnly = true;
            dgPurchase.Columns[13].ReadOnly = true;
            dgPurchase.Columns[14].ReadOnly = true;
            txtOrderNumber.Enabled = false;
            btnCreate.Enabled = false;
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dgPurchase.Rows.Count; i++)
            {
                dgPurchase.Rows[i].Cells[SLC.Index].Value = true;
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dgPurchase.Rows.Count; i++)
            {
                dgPurchase.Rows[i].Cells[SLC.Index].Value = false;
            }
        }
    }
}
