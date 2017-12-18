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
        int purchasecode;

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

            for (int i = 0; i < dgPurchase.RowCount - 1; i++)
            {
                DataGridViewRow row = dgPurchase.Rows[i];
                string ID = row.Cells[SaleOrderNo.Index].Value.ToString();
                if (row.Cells[SaleOrderNo.Index].Value != null)
                {
                    var item = IME.PurchaseOrderDetails.Where(a => a.SaleOrderNo == ID).FirstOrDefault();

                    item.PurchaseOrder.Customer.c_name = row.Cells[c_name.Index].Value.ToString();
                    item.QuotationNo=row.Cells[QuotationNos.Index].Value.ToString();
                    item.SaleOrderNo=row.Cells[SaleOrderNo.Index].Value.ToString();
                    item.ItemCode=row.Cells[ItemCode.Index].Value.ToString();
                    try{item.ItemDescription = row.Cells[ItemDescription.Index].Value.ToString();}catch (Exception){throw;}
                    item.UnitPrice=(decimal)row.Cells[UnitOfMeasure.Index].Value;
                    item.SendQty=(int)row.Cells[Quantity.Index].Value;
                    item.Hazardous=(bool)row.Cells[Hazardous.Index].Value;
                    item.Calibration=(bool)row.Cells[Calibration.Index].Value;
                    item.SaleOrderNature=row.Cells[SaleOrderNature.Index].Value.ToString();
                    if ((row.Cells[AddressType.Index].Value.ToString() == "IME GENERAL COMPONENTS") && (row.Cells[AdressTitle.Index].Value.ToString() == "IME GENERAL COMPONENTS"))
                    {
                        item.AccountNumber = 8828170;
                    }
                    if ((row.Cells[AddressType.Index].Value.ToString() == "3RD PARTY") && (row.Cells[AdressTitle.Index].Value.ToString() == "3RD PARTY"))
                    {
                        item.AccountNumber = 8894479;
                    }
                    item.Unit=row.Cells[UPIME.Index].Value.ToString();
                }
            }
            IME.SaveChanges();
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
                           join s in IME.SaleOrders on p.SaleOrderNo equals s.SaleOrderNo
                           join po in IME.PurchaseOrderDetails on s.SaleOrderNo equals po.SaleOrderNo
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
                               po.AccountNumber,
                               p.ItemCost
                           }).ToList();

            foreach (var item in adapter)
            {
                int rowIndex = dgPurchase.Rows.Add();
                DataGridViewRow row = dgPurchase.Rows[rowIndex];

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
                if (item.AccountNumber== 8828170)
                {
                    row.Cells[AddressType.Index].Value = "IME GENERAL COMPONENTS";
                    row.Cells[AdressTitle.Index].Value = "IME GENERAL COMPONENTS";
                }
                if (item.AccountNumber == 8894479)
                {
                    row.Cells[AddressType.Index].Value = "3RD PARTY";
                    row.Cells[AdressTitle.Index].Value = "3RD PARTY";
                }
                row.Cells[UPIME.Index].Value = item.ItemCost;
                row.Cells[Total.Index].Value = Decimal.Parse(row.Cells[Quantity.Index].Value.ToString()) * Decimal.Parse(row.Cells[UPIME.Index].Value.ToString());
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
                               p.AccountNumber,
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
    }
}