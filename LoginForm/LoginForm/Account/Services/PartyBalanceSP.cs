using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class PartyBalanceSP
    {
        public void PartyBalanceEditByVoucherNoVoucherTypeIdAndReferenceType(PartyBalanceInfo infoPartyBalance)
        {
            IMEEntities IME = new IMEEntities();
            IME.PartyBalanceEditByVoucherNoVoucherTypeIdAndReferenceType(infoPartyBalance.Date, infoPartyBalance.LedgerId, infoPartyBalance.VoucherTypeId, infoPartyBalance.VoucherNo, infoPartyBalance.AgainstVoucherTypeId, infoPartyBalance.AgainstVoucherNo, infoPartyBalance.InvoiceNo, infoPartyBalance.AgainstInvoiceNo, infoPartyBalance.ReferenceType, infoPartyBalance.Debit, infoPartyBalance.Credit, infoPartyBalance.CreditPeriod, infoPartyBalance.ExchangeRateId, infoPartyBalance.FinancialYearId, infoPartyBalance.ExtraDate, infoPartyBalance.Extra1, infoPartyBalance.Extra2);
        }

        public void PartyBalanceAdd(PartyBalance partybalanceinfo)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PartyBalances.Add(partybalanceinfo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public int PartyBalanceDeleteByVoucherTypeAndVoucherNo(decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();
            List<PartyBalance> list = new List<PartyBalance>();
            int inEffect = 0;
            try
            {
                list = db.PartyBalances.Where(x => x.againstVoucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();

                foreach (PartyBalance item in list)
                {
                    db.PartyBalances.Remove(item);
                }
                inEffect = db.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).Count();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return inEffect;
        }

        public void PartyBalanceEdit(PartyBalance pb)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                PartyBalance p = db.PartyBalances.Where(x => x.partyBalanceId == pb.partyBalanceId).FirstOrDefault();
                p.date = pb.date;
                p.ledgerId = pb.ledgerId;
                p.voucherTypeId = pb.voucherTypeId;
                p.voucherNo = pb.voucherNo;
                p.againstVoucherTypeId = pb.againstVoucherTypeId;
                p.againstVoucherNo = pb.againstVoucherNo;
                p.invoiceNo = pb.invoiceNo;
                p.againstInvoiceNo = pb.againstInvoiceNo;
                p.referenceType = pb.referenceType;
                p.debit = pb.debit;
                p.credit = pb.credit;
                p.creditPeriod = pb.creditPeriod;
                p.exchangeRateId = pb.exchangeRateId;
                p.financialYearId = pb.financialYearId;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool PartyBalanceCheckReference(decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();
            bool isReferenceExist = false;
            try
            {
                int count = db.PartyBalances.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.againstVoucherTypeId != 0 && x.againstVoucherNo != "0").Count();

                isReferenceExist = (count > 0) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PBSP:2" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isReferenceExist;
        }

        public DataTable PartyBalanceViewByVoucherNoAndVoucherType(decimal decVoucherTypeId, string strVoucherNo, DateTime dtDate)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (from pb in db.PartyBalances.Where(x =>
                (x.againstVoucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "Against") ||
                (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && (x.referenceType == "New" || x.referenceType == "OnAccount")))
                               from er in db.ExchangeRates.Where(x => x.exchangeRateID == pb.exchangeRateId)
                               select new
                               {
                                   LedgerId = pb.ledgerId,
                                   AgainstVoucherTypeId = pb.voucherTypeId,
                                   AgainstVoucherNo = pb.voucherNo,
                                   Amount = (pb.debit == 0) ? pb.credit : pb.debit,
                                   AgainstInvoiceNo = pb.invoiceNo,
                                   CurrencyId = (db.ExchangeRates.Where(x => x.date == dtDate && x.currencyId == (
                                      db.ExchangeRates.Where(e => e.exchangeRateID == pb.exchangeRateId).FirstOrDefault().exchangeRateID)).FirstOrDefault().exchangeRateID),
                                   DebitOrCredit = (pb.debit == 0) ? "Cr" : "Dr",
                                   PendingAmount = (pb.debit - pb.credit),
                                   PartyPalanceId = pb.partyBalanceId,
                                   VoucherTypeId = pb.againstVoucherTypeId,
                                   VoucherNo = pb.againstVoucherNo,
                                   InvoiceNo = pb.againstInvoiceNo,
                                   OldExchangeRate = "--Not Implemented Exception--"
                               }).ToList();

                dtbl.Columns.Add("LedgerId");
                dtbl.Columns.Add("AgainstVoucherTypeId");
                dtbl.Columns.Add("AgainstVoucherNo");
                dtbl.Columns.Add("Amount");
                dtbl.Columns.Add("AgainstInvoiceNo");
                dtbl.Columns.Add("CurrencyId");
                dtbl.Columns.Add("DebitOrCredit");
                dtbl.Columns.Add("PendingAmount");
                dtbl.Columns.Add("PartyPalanceId");
                dtbl.Columns.Add("VoucherTypeId");
                dtbl.Columns.Add("VoucherNo");
                dtbl.Columns.Add("InvoiceNo");
                dtbl.Columns.Add("OldExchangeRate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["LedgerId"] = item.LedgerId;
                    row["AgainstVoucherTypeId"] = item.AgainstVoucherTypeId;
                    row["AgainstVoucherNo"] = item.AgainstVoucherNo;
                    row["Amount"] = item.Amount;
                    row["AgainstInvoiceNo"] = item.AgainstInvoiceNo;
                    row["CurrencyId"] = item.CurrencyId;
                    row["DebitOrCredit"] = item.DebitOrCredit;
                    row["PendingAmount"] = item.PendingAmount;
                    row["PartyPalanceId"] = item.PartyPalanceId;
                    row["VoucherTypeId"] = item.VoucherTypeId;
                    row["VoucherNo"] = item.VoucherNo;
                    row["InvoiceNo"] = item.InvoiceNo;
                    row["OldExchangeRate"] = item.OldExchangeRate;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public void PartyBalanceDelete(decimal PartyBalanceId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                List<PartyBalance> listLp = IME.PartyBalances.Where(x => x.partyBalanceId == PartyBalanceId).ToList();
                IME.PartyBalances.RemoveRange(listLp);
                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public decimal PartyBalanceAmountViewByVoucherNoVoucherTypeIdAndReferenceType(string strVoucherNo, decimal decVoucherTypeId, string strReferenceType)
        {
            decimal decAmount = 0;
            try
            {
                decAmount = Convert.ToDecimal(new IMEEntities().PartyBalanceAmountViewByVoucherNoVoucherTypeIdAndReferenceType(strVoucherNo, decVoucherTypeId, strReferenceType));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decAmount;
        }

        public decimal PartyBalanceAmountViewForSalesInvoice(string strVoucherNo, decimal decVoucherTypeId, string strReferenceType)
        {
            decimal decAmount = 0;

            IMEEntities IME = new IMEEntities();
            if(IME.PartyBalances.Where(a=>a.voucherNo==strVoucherNo).Where(a=>a.voucherTypeId==decVoucherTypeId).Where(c=>c.referenceType==strReferenceType)!=null)
            {
                foreach (var item in IME.PartyBalances.Where(a => a.voucherNo == strVoucherNo).Where(a => a.voucherTypeId == decVoucherTypeId).Where(c => c.referenceType == strReferenceType))
                {
                    decAmount = decAmount + (decimal)item.credit;
                }
            }
            return decAmount;
        }

    }
}
