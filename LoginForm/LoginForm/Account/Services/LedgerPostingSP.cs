using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class LedgerPostingSP
    {
        public void LedgerPostingEditByVoucherTypeAndVoucherNoAndLedgerId(LedgerPosting infoLedgerPosting)
        {
            IMEEntities IME = new IMEEntities();
            IME.LedgerPostingEditByVoucherTypeAndVoucherNoAndLedgerid(infoLedgerPosting.date, infoLedgerPosting.voucherTypeId, infoLedgerPosting.voucherNo, infoLedgerPosting.ledgerId, infoLedgerPosting.debit.ToString(), infoLedgerPosting.credit.ToString(), infoLedgerPosting.detailsId, infoLedgerPosting.yearId, infoLedgerPosting.invoiceNo, infoLedgerPosting.chequeNo, infoLedgerPosting.chequeDate);
        }


        public void LedgerPostingDeleteByVoucherTypeIdAndLedgerIdAndVoucherNoAndExtra(decimal voucherTypeId, decimal decLedgerId, string strVoucherNo, string strAddCash)
        {
            IMEEntities IME = new IMEEntities();
            IME.LedgerPostingDeleteByVoucherTypeIdAndLedgerIdAndVoucherNoAndExtra(voucherTypeId,
                decLedgerId,strVoucherNo);
        }

        public void LedgerPostDelete(string strVoucherNo, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            IME.LedgerPostDelete(decVoucherTypeId, strVoucherNo);
        }

        public DataTable GetLedgerPostingIds(string v1, decimal v2)
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
            IMEEntities db = new IMEEntities();
            try
            {
                db.LedgerPostings.Add(ledgerpostinginfo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LedgerPostingDeleteByVoucherNoVoucherTypeIdAndLedgerId(string strVoucherNo, decimal decVoucherTypeId, decimal decLedgerId)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                LedgerPosting lp = db.LedgerPostings.Where(x => x.voucherNo == strVoucherNo && x.voucherTypeId == decVoucherTypeId && x.ledgerId == decLedgerId).FirstOrDefault();
                db.LedgerPostings.Remove(lp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LedgerPostDeleteByDetailsId(decimal decDetailsId, string strVoucherNo, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();

            try
            {
                decimal ledgerPostingId = IME.LedgerPostings.Where(x => x.voucherNo == strVoucherNo && x.voucherTypeId == decVoucherTypeId && x.detailsId == decDetailsId).FirstOrDefault().ledgerPostingId;

                List<LedgerPosting> listLp = IME.LedgerPostings.Where(x => x.voucherNo == strVoucherNo && x.voucherTypeId == decVoucherTypeId && x.detailsId==decDetailsId).ToList();
                IME.LedgerPostings.RemoveRange(listLp);
                IME.SaveChanges();

                List<BankReconciliation> listBr = IME.BankReconciliations.Where(x => x.ledgerPostingId == ledgerPostingId).ToList();
                IME.BankReconciliations.RemoveRange(listBr);
                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal LedgerPostingIdFromDetailsId(decimal decDetailsId, string strVoucherNo, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal decLedgerPostingId = 0;

            try
            {
                decLedgerPostingId = IME.LedgerPostings.Where(x => x.detailsId == decDetailsId && x.voucherNo == strVoucherNo && x.voucherTypeId == decVoucherTypeId).FirstOrDefault().ledgerPostingId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LPSP:1" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return decLedgerPostingId;
        }

        public void LedgerPostingEditByVoucherTypeAndVoucherNo(LedgerPosting lpi)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                LedgerPosting lp = db.LedgerPostings.Where(x => x.voucherNo == lpi.voucherNo && x.voucherTypeId == lpi.voucherTypeId).FirstOrDefault();

                lp.date = lpi.date;
                lp.ledgerId = lpi.ledgerId;
                lp.debit = lpi.debit;
                lp.credit = lpi.credit;
                lp.yearId = lpi.yearId;
                lp.invoiceNo = lpi.invoiceNo;
                lp.chequeNo = lpi.chequeNo;
                lp.chequeDate = lpi.chequeDate;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LedgerPostingAndPartyBalanceDeleteByVoucherTypeIdAndLedgerIdAndVoucherNo(decimal voucherTypeId, string voucherNo, string invoiceNo)
        {
          IMEEntities db = new IMEEntities();
          try
            {
              LedgerPosting lp = db.LedgerPostings.Where(x => x.voucherNo == voucherNo && x.voucherTypeId == voucherTypeId && x.invoiceNo == invoiceNo).FirstOrDefault();
              db.LedgerPostings.Remove(lp);
              db.SaveChanges();

              PartyBalance pb = db.PartyBalances.Where(x => x.againstVoucherNo == voucherNo && x.againstVoucherTypeId == voucherTypeId && x.againstInvoiceNo == invoiceNo).FirstOrDefault();
              db.PartyBalances.Remove(pb);
              db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //public void LedgerPostDelete(string strVoucherNo, decimal decVoucherTypeId)
        //{
        //    IMEEntities db = new IMEEntities();
        //    try
        //    {
        //      db.LedgerPostDelete(decVoucherTypeId,strVoucherNo);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //public void LedgerPostDelete(string strVoucherNo, decimal decVoucherTypeId)
        //{
        //    IMEEntities db = new IMEEntities();
        //    try
        //    {
        //        LedgerPosting lp = db.LedgerPostings.Where(x => x.voucherNo == strVoucherNo && x.voucherTypeId == decVoucherTypeId).FirstOrDefault();
        //        db.LedgerPostings.Remove(lp);
        //        db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
    }
}
