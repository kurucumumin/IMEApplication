using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;
using System.Data;
using System.Windows.Forms;

namespace LoginForm.Services
{
    class PDCReceivableMasterSP
    {
        public DataTable PDCReceivableRegisterSearch(DateTime dtFromdate, DateTime dtTodate, string strVoucherNo, string strLedgerName)
        {
            IMEEntities IME = new IMEEntities();

            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from pdc in IME.PDCReceivableMasters.Where(x =>
                (x.date > dtFromdate && x.date < dtTodate) &&
                ((strVoucherNo == String.Empty) ? x.invoiceNo == x.invoiceNo : x.invoiceNo.StartsWith(strVoucherNo)) &&
                (strLedgerName == "All") ? x.AccountLedger.ledgerName == x.AccountLedger.ledgerName : x.AccountLedger.ledgerName == strLedgerName).
                OrderByDescending(y => y.pdcReceivableMasterId)
                               select new
                               {
                                   pdc.pdcReceivableMasterId,
                                   pdc.voucherNo,
                                   pdc.invoiceNo,
                                   date = pdc.date.ToString(),
                                   pdc.amount,
                                   pdc.narration,
                                   pdc.userId,
                                   pdc.voucherTypeId,
                                   pdc.financialYearId,
                                   pdc.AccountLedger.ledgerName,
                                   pdc.VoucherType.voucherTypeName
                               }).ToList();

                dtbl.Columns.Add("pdcReceivableMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("amount");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("financialYearId");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("voucherTypeName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["pdcReceivableMasterId"] = item.pdcReceivableMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["date"] = item.date;
                    row["amount"] = item.amount;
                    row["narration"] = item.narration;
                    row["userId"] = item.userId;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["financialYearId"] = item.financialYearId;
                    row["ledgerName"] = item.ledgerName;
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
