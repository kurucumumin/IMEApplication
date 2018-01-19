using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows;

namespace LoginForm.Account.Services
{
    class PaymentMasterSP
    {
        public DataTable PaymentReportSearch(DateTime dtpFromDate, DateTime dtpToDate, decimal decLedgerId, decimal decVoucherTypeId, decimal decCashOrBankId)
        {
            IMEEntities IME = new IMEEntities();

            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from c in IME.PaymentMasters
                               from v in IME.VoucherTypes.Where(x => x.voucherTypeId == c.voucherTypeId)
                               from w in IME.Workers.Where(x => x.WorkerID == c.userId)
                               from cd in IME.PaymentDetails.Where(x => x.paymentMasterId == c.paymentMasterId)
                               where
                                      (c.date > Convert.ToDateTime(dtpFromDate) && c.date < Convert.ToDateTime(dtpToDate)) &&
                                      (c.voucherTypeId == ((decVoucherTypeId == 0) ? c.voucherTypeId : decVoucherTypeId)) &&
                                      (cd.ledgerId == ((decLedgerId == 0) ? cd.ledgerId : decLedgerId))
                               select new
                               {
                                   c.paymentMasterId,
                                   v.voucherTypeName,
                                   c.voucherNo,
                                   date = c.date.ToString(),
                                   totalAmount = Convert.ToDecimal(c.totalAmount),
                                   c.narration,
                                   w.UserName,
                                   c.AccountLedger.ledgerName
                               }).OrderByDescending(x => x.paymentMasterId).Distinct().ToList();



                dtbl.Columns.Add("paymentMasterId");
                dtbl.Columns.Add("voucherTypeName");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("UserName");
                dtbl.Columns.Add("ledgerName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["paymentMasterId"] = item.paymentMasterId;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["voucherNo"] = item.voucherNo;
                    row["date"] = item.date;
                    row["totalAmount"] = item.totalAmount;
                    row["narration"] = item.narration;
                    row["UserName"] = item.UserName;
                    row["ledgerName"] = item.ledgerName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable PaymentMasterSearch(DateTime dtpFromDate, DateTime dtpToDate, decimal decledgerId, string strvoucherNo)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            //try
            //{
            //    var adaptor = IME.PaymentMasterSearch(dtpFromDate, dtpToDate, decledgerId, strvoucherNo).ToList();

            //    dtbl.Columns.Add("paymentMasterId");
            //    dtbl.Columns.Add("invoiceNo");
            //    dtbl.Columns.Add("voucherTypeName");
            //    dtbl.Columns.Add("date");
            //    dtbl.Columns.Add("totalAmount");
            //    dtbl.Columns.Add("ledgerName");
            //    dtbl.Columns.Add("narration");
            //    dtbl.Columns.Add("voucherTypeId");
                

            //    foreach (var item in adaptor)
            //    {
            //        var row = dtbl.NewRow();

            //        row["paymentMasterId"] = item.paymentMasterId;
            //        row["invoiceNo"] = item.invoiceNo;
            //        row["voucherTypeName"] = item.voucherTypeName;
            //        row["date"] = item.date;
            //        row["totalAmount"] = item.totalAmount;
            //        row["ledgerName"] = item.ledgerName;
            //        row["narration"] = item.narration;
            //        row["voucherTypeId"] = item.voucherTypeId;
                    

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
