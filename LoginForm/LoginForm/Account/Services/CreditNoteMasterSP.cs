using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm.Account.Services
{
    class CreditNoteMasterSP
    {
        public DataTable CreditNoteRegisterSearch(string strVoucherNo, string strFromDate, string strToDate)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from cn in db.CreditNoteMasters.Where(x => x.voucherNo.StartsWith(strVoucherNo) && (x.date > DateTime.Parse(strFromDate) && x.date < DateTime.Parse(strToDate))).OrderBy(y=>y.creditNoteMasterId)
                               select new
                               {
                                   cn.creditNoteMasterId,
                                   cn.invoiceNo,
                                   cn.VoucherType.voucherTypeName,
                                   cn.suffixPrefixId,
                                   date = cn.date.Value.Date,
                                   Amount = cn.totalAmount,
                                   cn.narration,
                                   cn.userId,
                                   cn.voucherTypeId,
                                   cn.financialYearId
                               }).ToList();

                dtbl.Columns.Add("creditNoteMasterId");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("voucherTypeName");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("Amount");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("financialYearId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["creditNoteMasterId"] = item.creditNoteMasterId;
                    row["invoiceNo"] = item.invoiceNo;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["suffixPrefixId"] = item.suffixPrefixId;
                    row["date"] = item.date;
                    row["Amount"] = item.Amount;
                    row["narration"] = item.narration;
                    row["userId"] = item.userId;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["financialYearId"] = item.financialYearId;

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
