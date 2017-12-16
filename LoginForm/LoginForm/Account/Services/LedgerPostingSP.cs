using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace LoginForm.Account.Services
{
    class LedgerPostingSP
    {
        public DataTable GetLedgerPostingIds(string v1, int v2)
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();

            var adaptor = (from lp in db.LedgerPostings.Where(x => x.voucherNo == v1 && x.voucherTypeId == v2)
                           select new
                           {
                               lp.voucherNo,
                               lp.voucherTypeId
                           }).ToList();
            dt.Columns.Add("voucherNo");
            dt.Columns.Add("voucherTypeId");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();

                row["voucherNo"] = item.voucherNo;
                row["voucherTypeId"] = item.voucherTypeId;

                dt.Rows.Add(row);
            }

            return dt;
        }

        public void LedgerPostingEdit(LedgerPosting ledgerpostinginfo)
        {
            IMEEntities db = new IMEEntities();
            LedgerPosting lp;
            lp = db.LedgerPostings.Where(x => x.ledgerPostingId == ledgerpostinginfo.ledgerPostingId).FirstOrDefault();

            try
            {
                lp.date = ledgerpostinginfo.date;
                lp.voucherTypeId = ledgerpostinginfo.voucherTypeId;
                lp.voucherNo = ledgerpostinginfo.voucherNo;
                lp.ledgerId = ledgerpostinginfo.ledgerId;
                lp.debit = ledgerpostinginfo.debit;
                lp.credit = ledgerpostinginfo.credit;
                lp.detailsId = ledgerpostinginfo.detailsId;
                lp.yearId = ledgerpostinginfo.yearId;
                lp.invoiceNo = ledgerpostinginfo.invoiceNo;
                lp.chequeNo = ledgerpostinginfo.chequeNo;
                lp.chequeDate = ledgerpostinginfo.chequeDate;

                db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LedgerPostingAdd(LedgerPosting ledgerpostinginfo)
        {
            try
            {
                new IMEEntities().LedgerPostings.Add(ledgerpostinginfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



    }
}
