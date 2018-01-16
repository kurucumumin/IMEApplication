using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginForm.Account.Services
{
    class SalesOrderMasterSP
    {
        public DataTable GetSalesOrderNoIncludePendingCorrespondingtoLedgerforSI(decimal decLedgerId, decimal decSalesMasterId, decimal decVoucherTypeId)
        {

            //GetSalesOrderNoIncludePendingCorrespondingtoLedgerforSI
                IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();

            var adaptor = IME.GetSalesOrderNoIncludePendingCorrespondingtoLedgerforSI(decLedgerId, decSalesMasterId, decVoucherTypeId);
            dt.Columns.Add("invoiceNo");
            dt.Columns.Add("SaleOrderNo");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["invoiceNo"] = item.invoiceNo;
                row["SaleOrderNo"] = item.SaleOrderNo;

                                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable SalesInvoiceGridfillAgainestSalesOrder(string strOrderMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();

            var adaptor = IME.SaleOrders.Where(a => a.SaleOrderNo == strOrderMasterId);
            dt.Columns.Add("invoiceNo");
            dt.Columns.Add("SaleOrderNo");
            dt.Columns.Add("ledgerId");
            dt.Columns.Add("exchangeRateID");
            dt.Columns.Add("currencyId");
            dt.Columns.Add("WorkerID");
            dt.Columns.Add("pricingLevelId");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["invoiceNo"] = item.invoiceNo;
                row["SaleOrderNo"] = item.SaleOrderNo;
                row["ledgerId"] = item.ledgerId;
                row["exchangeRateID"] = item.exchangeRateID;
                row["currencyId"] = item.ExchangeRate.currencyId;
                row["WorkerID"] = item.Worker.WorkerID;
                row["pricingLevelId"] = item.pricingLevelId;

                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
