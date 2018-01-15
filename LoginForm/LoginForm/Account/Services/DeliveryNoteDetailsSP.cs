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

        public DataTable SalesInvoiceGridfillAgainestDeliveryNoteUsingDeliveryNoteDetails(decimal decDeliveryNoteMasterId, decimal SIMasterId, decimal voucherTypeId)
        {
            //TODO SalesInvoiceGridfillAgainestDeliveryNoteUsingDeliveryNoteDetails
            DataTable dtbl = new DataTable();
            
            return dtbl;
        }

        public DataTable SalesInvoiceGridfillAgainestDeliveryNote(decimal DecDeliveryNoteMasterId)
        {
            DataTable dt = new DataTable();
            IMEEntities IME = new IMEEntities();
            var q = IME.DeliveryNoteDetails.Where(a => a.deliveryNoteMasterId == DecDeliveryNoteMasterId);
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
                row["quotationMasterId"] = item.Quotation.QuotationNo;

                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}
