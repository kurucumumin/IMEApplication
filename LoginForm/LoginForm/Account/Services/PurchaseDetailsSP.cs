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


    }
}
