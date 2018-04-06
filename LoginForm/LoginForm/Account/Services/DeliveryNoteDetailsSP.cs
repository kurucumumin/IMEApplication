using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LoginForm.DataSet;

namespace LoginForm.Account.Services
{
    class DeliveryNoteDetailsSP
    {
        /// <summary>
        /// Function to get values of Sales based on DeliveryNote with parameters passed
        /// </summary>
        /// <param name="decDeliveryNoteMasterId"></param>
        /// <param name="SIMasterId"></param>
        /// <param name="voucherTypeId"></param>
        /// <returns></returns>
        public DataTable SalesInvoiceGridfillAgainestDeliveryNoteUsingDeliveryNoteDetails(decimal decDeliveryNoteMasterId, decimal SIMasterId, decimal voucherTypeId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = new IMEEntities().SalesInvoiceGridfillAgainestDeliveryNoteUsingDeliveryNoteDetails(decDeliveryNoteMasterId, SIMasterId, voucherTypeId).ToList();

                dtbl.Columns.Add("deliveryNoteDetailsId");
                dtbl.Columns.Add("deliveryNoteMasterId");
                dtbl.Columns.Add("productId");
                dtbl.Columns.Add("barcode");
                dtbl.Columns.Add("batchId");
                dtbl.Columns.Add("batchNo");
                dtbl.Columns.Add("unitName");
                dtbl.Columns.Add("productCode");
                dtbl.Columns.Add("productName");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("rate");
                dtbl.Columns.Add("currencyId");
                dtbl.Columns.Add("unitConversionId");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("conversionRate");
                dtbl.Columns.Add("amount");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["deliveryNoteDetailsId"] = item.deliveryNoteDetailsId;
                    row["deliveryNoteMasterId"] = item.deliveryNoteMasterId;
                    row["productId"] = item.productId;
                    row["barcode"] = item.barcode;
                    row["batchId"] = item.batchId;
                    row["batchNo"] = item.batchNo;
                    row["unitName"] = item.unitName;
                    row["productCode"] = item.productCode;
                    row["productName"] = item.productName;
                    row["qty"] = item.qty;
                    row["rate"] = item.rate;
                    row["currencyId"] = item.currencyId;
                    row["unitConversionId"] = item.unitConversionId;
                    row["taxId"] = item.taxId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["conversionRate"] = item.conversionRate;
                    row["amount"] = item.amount;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtbl;
        }

        public DataTable SalesInvoiceGridfillAgainestDeliveryNote(decimal DecDeliveryNoteMasterId)
        {
            DataTable dt = new DataTable();
            try
            {
                var q = new IMEEntities().DeliveryNoteDetails.Where(a => a.deliveryNoteMasterId == DecDeliveryNoteMasterId);
                dt.Columns.Add("deliveryNoteMasterId");
                dt.Columns.Add("voucherNo");
                dt.Columns.Add("invoiceNo");
                dt.Columns.Add("ledgerId");
                dt.Columns.Add("orderMasterId");
                dt.Columns.Add("pricingLevelId");
                dt.Columns.Add("employeeId");
                dt.Columns.Add("exchangeRateId");
                dt.Columns.Add("suffixPrefixId");
                dt.Columns.Add("currencyId");
                dt.Columns.Add("quotationMasterId");
                foreach (var item in q)
                {
                    var row = dt.NewRow();
                    row["deliveryNoteMasterId"] = item.deliveryNoteMasterId;
                    row["voucherNo"] = item.DeliveryNoteMaster.voucherNo;
                    row["invoiceNo"] = item.DeliveryNoteMaster.invoiceNo;
                    row["ledgerId"] = item.DeliveryNoteMaster.ledgerId;
                    row["orderMasterId"] = item.DeliveryNoteMaster.orderMasterId;
                    row["employeeId"] = item.DeliveryNoteMaster.Worker.WorkerID;
                    row["exchangeRateId"] = item.DeliveryNoteMaster.exchangeRateId;
                    row["suffixPrefixId"] = item.DeliveryNoteMaster.suffixPrefixId;
                    row["currencyId"] = item.DeliveryNoteMaster.ExchangeRate.currencyId;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Function to insert values to DeliveryNoteDetails Table
        /// </summary>
        /// <param name="deliverynotedetailsinfo"></param>
        public void DeliveryNoteDetailsAdd(DeliveryNoteDetail deliverynotedetailsinfo)
        {
            try
            {
                decimal SaleOrderDetailId = Convert.ToDecimal(deliverynotedetailsinfo.SaleOrderDetailId);


               new IMEEntities().DeliveryNoteDetailsAdd(
                    deliverynotedetailsinfo.deliveryNoteMasterId,
                    SaleOrderDetailId,
                    deliverynotedetailsinfo.productId,
                    deliverynotedetailsinfo.qty,
                    deliverynotedetailsinfo.rate,
                    deliverynotedetailsinfo.unitId,
                    deliverynotedetailsinfo.unitConversionId,
                    deliverynotedetailsinfo.discount,
                    deliverynotedetailsinfo.taxId,
                    deliverynotedetailsinfo.batchId,
                    deliverynotedetailsinfo.godownId,
                    deliverynotedetailsinfo.rackId,
                    deliverynotedetailsinfo.taxAmount,
                    deliverynotedetailsinfo.grossAmount,
                    deliverynotedetailsinfo.netAmount,
                    deliverynotedetailsinfo.amount,
                    deliverynotedetailsinfo.slNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
