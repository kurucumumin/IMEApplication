using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class PurchaseOrderDetailsSP
    {
        public DataTable PurchaseOrderDetailsViewByOrderMasterIdWithRemainingByNotInCurrPI(string decPurchaseOrderMasterId, decimal decPurchaseMasterId, decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.PurchaseOrderDetailsViewByOrderMasterIdWithRemainingByNotInCurrPI(decPurchaseOrderMasterId, decPurchaseMasterId, decVoucherTypeId);

                dtbl.Columns.Add("purchaseDetailsId");
                dtbl.Columns.Add("purchaseOrderDetailsId");
                dtbl.Columns.Add("materialReceiptDetailsId");
                dtbl.Columns.Add("ItemCode");
                dtbl.Columns.Add("barcode");
                dtbl.Columns.Add("productCode");
                dtbl.Columns.Add("productName");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("unitConversionId");
                dtbl.Columns.Add("unitId");
                dtbl.Columns.Add("godownId");
                dtbl.Columns.Add("rackId");
                dtbl.Columns.Add("batchId");
                dtbl.Columns.Add("rate");
                dtbl.Columns.Add("grossValue");
                dtbl.Columns.Add("discountPercent");
                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("netvalue");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("taxAmount");
                dtbl.Columns.Add("Amount");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["purchaseDetailsId"] = item.purchaseDetailsId;
                    row["purchaseOrderDetailsId"] = item.purchaseOrderDetailsId;
                    row["materialReceiptDetailsId"] = item.materialReceiptDetailsId;
                    row["ItemCode"] = item.ItemCode;
                    row["barcode"] = item.barcode;
                    row["productCode"] = item.Article_No;
                    row["productName"] = item.productName;
                    row["qty"] = item.qty;
                    row["unitConversionId"] = item.unitConversionId;
                    row["unitId"] = item.unitId;
                    row["godownId"] = item.godownId;
                    row["rackId"] = item.rackId;
                    row["batchId"] = item.batchId;
                    row["rate"] = item.rate;
                    row["grossValue"] = item.grossValue;
                    row["discountPercent"] = item.discountPercent;
                    row["discount"] = item.discount;
                    row["netvalue"] = item.netvalue;
                    row["taxId"] = item.taxId;
                    row["taxAmount"] = item.taxAmount;
                    row["Amount"] = item.Amount;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
    }
}
