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
    class JournalMasterSP
    {

        public DataTable JournalReportSearch(string strFromDate, string strToDate, decimal decVoucherTypeId, decimal decLedgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;

            try
            {

                var adaptor = (from c in IME.JournalMasters
                               from v in IME.VoucherTypes.Where(x => x.voucherTypeId == c.voucherTypeId)
                               from w in IME.Workers.Where(x => x.WorkerID == c.userId)
                               from cd in IME.JournalDetails.Where(x => x.journalMasterId == c.journalMasterId)
                               from al in IME.AccountLedgers.Where(x => x.ledgerId == cd.ledgerId)
                               where
                                      (c.date > Convert.ToDateTime(strFromDate) && c.date < Convert.ToDateTime(strToDate)) &&
                                      (c.voucherTypeId == ((decVoucherTypeId == 0) ? c.voucherTypeId : decVoucherTypeId)) &&
                                      (cd.ledgerId == ((decLedgerId == 0) ? cd.ledgerId : decLedgerId))
                               select new
                               {
                                   c.journalMasterId,
                                   v.voucherTypeName,
                                   c.voucherNo,
                                   date = c.date.ToString(),
                                   totalAmount = Convert.ToDecimal(c.totalAmount),
                                   c.narration,
                                   w.UserName
                               }).OrderByDescending(x => x.journalMasterId).Distinct().ToList();



                dtbl.Columns.Add("creditNoteMasterId");
                dtbl.Columns.Add("voucherTypeName");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("UserName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["creditNoteMasterId"] = item.journalMasterId;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["voucherNo"] = item.voucherNo;
                    row["date"] = item.date;
                    row["totalAmount"] = item.totalAmount;
                    row["narration"] = item.narration;
                    row["UserName"] = item.UserName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable JournalRegisterSearch(string strVoucherNo, string strFromDate, string strToDate)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            //try
            //{
            //    var adaptor = IME.JournalRegisterSearch(strVoucherNo, Convert.ToDateTime(strFromDate), Convert.ToDateTime(strToDate)).ToList();


            //    dtbl.Columns.Add("journalMasterId");
            //    dtbl.Columns.Add("voucherNo");
            //    dtbl.Columns.Add("invoiceNo");
            //    dtbl.Columns.Add("voucherTypeName");
            //    dtbl.Columns.Add("suffixPrefixId");
            //    dtbl.Columns.Add("date");
            //    dtbl.Columns.Add("totalAmount");
            //    dtbl.Columns.Add("narration");
            //    dtbl.Columns.Add("userId");
            //    dtbl.Columns.Add("voucherTypeId");
            //    dtbl.Columns.Add("financialYearId ");

            //    foreach (var item in adaptor)
            //    {
            //        var row = dtbl.NewRow();

            //        row["journalMasterId"] = item.journalMasterId;
            //        row["voucherNo"] = item.voucherNo;
            //        row["invoiceNo"] = item.invoiceNo;
            //        row["voucherTypeName"] = item.voucherTypeName;
            //        row["suffixPrefixId"] = item.suffixPrefixId;
            //        row["date"] = item.date;
            //        row["totalAmount"] = item.totalAmount;
            //        row["narration"] = item.narration;
            //        row["userId"] = item.userId;
            //        row["voucherTypeId"] = item.voucherTypeId;
            //        row["financialYearId"] = item.financialYearId;

            //        dtbl.Rows.Add(row);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            return dtbl;
        }
    }
}
