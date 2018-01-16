using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class PurchaseDetailsSP
    {
        public DataTable PurchaseDetailsViewByPurchaseMasterId(decimal decPurchaseMasterId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.PurchaseDetailsViewByPurchaseMasterId(decPurchaseMasterId);

                dtbl.Columns.Add("purchaseDetailsId");
                dtbl.Columns.Add("purchaseOrderDetailsId");
                dtbl.Columns.Add("materialReceiptDetailsId");
                dtbl.Columns.Add("productId");
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
                dtbl.Columns.Add("grossvalue");
                dtbl.Columns.Add("discountPercent");
                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("netValue");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("taxAmount");
                dtbl.Columns.Add("amount");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["purchaseDetailsId"] = item.purchaseDetailsId;
                    row["purchaseOrderDetailsId"] = item.purchaseOrderDetailsId;
                    row["materialReceiptDetailsId"] = item.materialReceiptDetailsId;
                    row["productId"] = item.productId;
                    row["barcode"] = item.barcode;
                    row["productCode"] = item.productCode;
                    row["productName"] = item.productName;
                    row["qty"] = item.qty;
                    row["unitConversionId"] = item.unitConversionId;
                    row["unitId"] = item.unitId;
                    row["godownId"] = item.godownId;
                    row["rackId"] = item.rackId;
                    row["batchId"] = item.batchId;
                    row["rate"] = item.rate;
                    row["grossvalue"] = item.grossvalue;
                    row["discountPercent"] = item.discountPercent;
                    row["discount"] = item.discount;
                    row["netValue"] = item.netValue;
                    row["taxId"] = item.taxId;
                    row["taxAmount"] = item.taxAmount;
                    row["amount"] = item.amount;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable PurchaseDetailsViewByPurchaseMasterIdWithRemaining(decimal decPurchaseMasterId, decimal decPurchaseReturnMasterId, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {

                var adaptor = IME.PurchaseDetailsViewByPurchaseMasterIdWithRemaining(decPurchaseMasterId, decPurchaseReturnMasterId, decVoucherTypeId);

                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("barcode");
                dtbl.Columns.Add("unitConversionId");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("rate");
                dtbl.Columns.Add("unitId");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("grossAmount");
                dtbl.Columns.Add("amount");
                dtbl.Columns.Add("currencyId");
                dtbl.Columns.Add("godownId");
                dtbl.Columns.Add("rackId");
                dtbl.Columns.Add("batchId");
                dtbl.Columns.Add("netAmount");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("Refer");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["discount"] = item.discount;
                    row["barcode"] = item.barcode;
                    row["unitConversionId"] = item.unitConversionId;
                    row["qty"] = item.qty;
                    row["rate"] = item.rate;
                    row["unitId"] = item.unitId;
                    row["taxId"] = item.taxId;
                    row["grossAmount"] = item.grossAmount;
                    row["amount"] = item.amount;
                    row["currencyId"] = item.currencyId;
                    row["godownId"] = item.godownId;
                    row["rackId"] = item.rackId;
                    row["batchId"] = item.batchId;
                    row["netAmount"] = item.netAmount;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["invoiceNo"] = item.invoiceNo;
                    row["voucherNo"] = item.voucherNo;
                    row["Refer"] = item.Refer;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }



        public void PurchaseDetailsDelete(decimal PurchaseDetailsId)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PurchaseDetailsDelete(PurchaseDetailsId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void PurchaseDetailsAdd(PurchaseDetail p)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PurchaseDetailsAdd(
                    p.purchaseMasterId,
                    p.receiptDetailsId,
                    p.orderDetailsId,
                    p.productId,
                    p.qty,
                    p.rate,
                    p.unitId,
                    p.unitConversionId,
                    p.discount,
                    p.taxId,
                    p.batchId,
                    p.godownId,
                    p.rackId,
                    p.taxAmount,
                    p.grossAmount,
                    p.netAmount,
                    p.amount,
                    p.slNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void PurchaseDetailsEdit(PurchaseDetail pd)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PurchaseDetailsEdit(
                    pd.purchaseMasterId,
                    pd.receiptDetailsId,
                    pd.orderDetailsId,
                    pd.productId,
                    pd.qty,
                    pd.rate,
                    pd.unitId,
                    pd.unitConversionId,
                    pd.discount,
                    pd.taxId,
                    pd.batchId,
                    pd.godownId,
                    pd.rackId,
                    pd.taxAmount,
                    pd.grossAmount,
                    pd.netAmount,
                    pd.amount,
                    pd.slNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void PurchaseDetailsDeleteByPurchaseMasterId(decimal decPurchaseMasterId)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PurchaseDetailsDeleteByPurchaseMasterId(decPurchaseMasterId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable PurchaseDetailsViewByProductCodeForPI(decimal decVoucherTypeId, string strProductCode)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.PurchaseDetailsViewByProductCodeForPI(decVoucherTypeId, strProductCode);

                dtbl.Columns.Add("purchaseDetailsId");
                dtbl.Columns.Add("purchaseOrderDetailsId");
                dtbl.Columns.Add("materialReceiptDetailsId");
                dtbl.Columns.Add("barcode");
                dtbl.Columns.Add("productCode");
                dtbl.Columns.Add("productName");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("unitConversionId");
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
                    row["barcode"] = item.barcode;
                    row["productCode"] = item.productCode;
                    row["productName"] = item.productName;
                    row["qty"] = item.qty;
                    row["unitConversionId"] = item.unitConversionId;
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

        public DataTable PurchaseDetailsViewByProductNameForPI(decimal decVoucherTypeId, string strProductName)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.PurchaseDetailsViewByProductNameForPI(decVoucherTypeId, strProductName);

                dtbl.Columns.Add("purchaseDetailsId");
                dtbl.Columns.Add("purchaseOrderDetailsId");
                dtbl.Columns.Add("materialReceiptDetailsId");
                dtbl.Columns.Add("barcode");
                dtbl.Columns.Add("productCode");
                dtbl.Columns.Add("productName");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("unitConversionId");
                dtbl.Columns.Add("batchId");
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
                    row["barcode"] = item.barcode;
                    row["productCode"] = item.productCode;
                    row["productName"] = item.productName;
                    row["qty"] = item.qty;
                    row["unitConversionId"] = item.unitConversionId;
                    row["batchId"] = item.batchId;
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

        public DataTable VoucherTypeComboFillForPurchaseInvoice()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.VoucherTypes.Where(x => x.typeOfVoucher == "Purchase Invoice").ToList();

                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("voucherTypeName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["voucherTypeId"] = item.voucherTypeId;
                    row["voucherTypeName"] = item.voucherTypeName;


                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable PurchaseDetailsViewByBarcodeForPI(decimal decVoucherTypeId, string strBarcode)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.PurchaseDetailsViewByBarcodeForPI(decVoucherTypeId,strBarcode);

                dtbl.Columns.Add("purchaseDetailsId");
                dtbl.Columns.Add("purchaseOrderDetailsId");
                dtbl.Columns.Add("materialReceiptDetailsId");
                dtbl.Columns.Add("barcode");
                dtbl.Columns.Add("productCode");
                dtbl.Columns.Add("productName");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("unitConversionId");
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
                    row["barcode"] = item.barcode;
                    row["productCode"] = item.productCode;
                    row["productName"] = item.productName;
                    row["qty"] = item.qty;
                    row["unitConversionId"] = item.unitConversionId;
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
