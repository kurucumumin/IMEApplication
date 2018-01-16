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
    class SalesQuotationMasterSP
    {
        public DataTable SalesInvoiceGridfillAgainestQuotation(string decQuotationMasterId)
        {
            DataTable dt = new DataTable();
            //Quotation,quotationdetail,exchangerate,currency
            IMEEntities IME = new IMEEntities();
            var q = IME.QuotationDetails.Where(a => a.QuotationNo == decQuotationMasterId);
            dt.Columns.Add("quotationMasterId");
			 dt.Columns.Add("voucherNo");
            dt.Columns.Add("invoiceNo");
            //TODO pricingLevelID ???
            //dt.Columns.Add("pricingLevelId");
            dt.Columns.Add("ledgerId");
            dt.Columns.Add("employeeId");
            dt.Columns.Add("suffixPrefixId");
            dt.Columns.Add("exchangeRateId");
            foreach (var item in q)
            {
                var row = dt.NewRow();
                row["quotationMasterId"] = item.QuotationNo;
                row["voucherNo"] = item.Quotation.voucherNo;
                row["invoiceNo"] = item.Quotation.invoiceNo;
                //row["pricingLevelId"] = item.Quotation.;
                row["ledgerId"] = item.Quotation.ledgerId;
                row["employeeId"] = item.Quotation.RepresentativeID;
                row["suffixPrefixId"] = item.Quotation.suffixPrefixId;
                row["exchangeRateId"] = item.Quotation.ExchangeRateID;

                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable GetSalesQuotationIncludePendingCorrespondingtoLedgerForSI(decimal decLedgerId, decimal decSalesMasterId, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();

            var adaptor = IME.GetSalesQuotationIncludePendingCorrespondingtoLedgerForSI(decLedgerId.ToString(), decSalesMasterId.ToString(), decVoucherTypeId);
            dt.Columns.Add("invoiceNo");
            dt.Columns.Add("QuotationNo");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["invoiceNo"] = item.invoiceNo;
                row["QuotationNo"] = item.QuotationNo;

                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
