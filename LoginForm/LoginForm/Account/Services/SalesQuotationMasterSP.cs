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
    class SalesQuotationMasterSP
    {
        public DataTable GetSalesQuotationIncludePendingCorrespondingtoLedgerForSI(string decLedgerId, string decSalesMasterId, decimal decVoucherTypeId)
        {
            DataTable dtbLQuotation = new DataTable();
            IMEEntities IME = new IMEEntities();
            var result = IME.GetSalesQuotationIncludePendingCorrespondingtoLedgerForSI(decLedgerId,decSalesMasterId, decVoucherTypeId);
            dtbLQuotation.Columns.Add("QuotationNo");
            dtbLQuotation.Columns.Add("invoiceNo");
            foreach (var item in result)
            {
               var row = dtbLQuotation.NewRow();
                row["QuotationNo"] = item.QuotationNo;
                row["invoiceNo"] = item.invoiceNo;
                dtbLQuotation.Rows.Add(row);
            }
            return dtbLQuotation;
        }
    }
}
