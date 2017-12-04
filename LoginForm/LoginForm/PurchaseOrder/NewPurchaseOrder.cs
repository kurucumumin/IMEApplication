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

namespace LoginForm.PurchaseOrder
{
    public partial class NewPurchaseOrder : Form
    {
        IMEEntities IME = new IMEEntities();
        List<SaleOrderDetail> saleItemList = new List<SaleOrderDetail>();

        public NewPurchaseOrder()
        {
            InitializeComponent();
        }

        public NewPurchaseOrder(List<SaleOrder> SaleOrderList)
        {
            InitializeComponent();

            foreach (SaleOrder sale in SaleOrderList)
            { 
                saleItemList.AddRange(sale.SaleOrderDetails);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PurchaseExportFiles form = new PurchaseExportFiles();
            form.ShowDialog();
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
            PurchaseOrderFill();
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
                pod.Hazardous = sod.Hazardous;
                pod.Calibration = sod.Calibration;
                pod.UnitPrice = sod.UnitPrice;

                purchaseList.Add(pod);
            }

            dgPurchase.DataSource = purchaseList;
        }
    }
}
