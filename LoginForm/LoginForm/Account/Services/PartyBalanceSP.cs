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
        public void PartyBalanceEditByVoucherNoVoucherTypeIdAndReferenceType(PartyBalance infoPartyBalance)
        {
            IMEEntities IME = new IMEEntities();
            IME.PartyBalanceEditByVoucherNoVoucherTypeIdAndReferenceType(infoPartyBalance.date, infoPartyBalance.ledgerId, infoPartyBalance.voucherTypeId, infoPartyBalance.voucherNo, infoPartyBalance.againstVoucherTypeId, infoPartyBalance.againstVoucherNo, infoPartyBalance.invoiceNo, infoPartyBalance.againstInvoiceNo, infoPartyBalance.referenceType, infoPartyBalance.debit, infoPartyBalance.credit, infoPartyBalance.creditPeriod, infoPartyBalance.exchangeRateId, infoPartyBalance.financialYearId);
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

        public PartyBalance PartyBalanceViewByVoucherNoAndVoucherTypeId(decimal decVoucherTypeId, string strVoucherNo, DateTime dtDate)
        {
            IMEEntities IME = new IMEEntities();
            PartyBalance partybalanceinfo = new PartyBalance();

            try
            {
                var a = IME.PartyBalanceViewByVoucherNoAndVoucherType(decVoucherTypeId, strVoucherNo, dtDate).FirstOrDefault();

                partybalanceinfo.ledgerId = a.LedgerId;
                partybalanceinfo.voucherTypeId = a.AgainstVoucherTypeId;
                partybalanceinfo.voucherNo = a.AgainstVoucherNo;
                partybalanceinfo.referenceType = a.ReferenceType;
                //partybalanceinfo.a = a.Amount;
                partybalanceinfo.againstInvoiceNo = a.AgainstInvoiceNo;
                partybalanceinfo.debit = Convert.ToDecimal(a.DebitOrCredit);
                //partybalanceinfo.p = a.PendingAmount;
                partybalanceinfo.partyBalanceId = a.PartyBalanceId;
                partybalanceinfo.againstVoucherTypeId = a.VoucherTypeId;
                partybalanceinfo.againstVoucherNo = a.VoucherNo;
                partybalanceinfo.againstInvoiceNo = a.InvoiceNo;
                partybalanceinfo.exchangeRateId = Convert.ToInt32(a.OldExchangeRate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return partybalanceinfo;
        }

        public DataTable AccountLedgerGetByDebtorAndCreditorWithBalance()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.AccountLedgerGetByDebtorAndCreditorWithBalance().ToList();

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("balance");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerId"] = item.ledgerId;
                    row["ledgerName"] = item.ledgerName;
                    row["balance"] = item.balance;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public DataTable AgeingReportLedgerReceivable(DateTime ageingDate, decimal decledgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.AgeingReportLedgerReceivable(ageingDate, decledgerId).ToList();

                dtbl.Columns.Add("Sl_NO");
                dtbl.Columns.Add("Account_Ledger");
                dtbl.Columns.Add("VoucherType");
                dtbl.Columns.Add("VoucherNo");
                dtbl.Columns.Add("Date");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("masterId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("1 to 30");
                dtbl.Columns.Add("31 to 60");
                dtbl.Columns.Add("61 to 90");
                dtbl.Columns.Add("90 above");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Sl_NO"] = item.Sl_NO;
                    row["Account_Ledger"] = item.Account_Ledger;
                    row["VoucherType"] = item.VoucherType;
                    row["VoucherNo"] = item.VoucherNo;
                    row["Date"] = item.Date;
                    row["ledgerId"] = item.ledgerId;
                    row["masterId"] = item.masterId;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["1 to 30"] = item.C1_to_30;
                    row["31 to 60"] = item.C31_to_60;
                    row["61 to 90"] = item.C61_to_90;
                    row["90 above"] = item.C90_above;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("MRSP1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public DataTable AgeingReportLedgerPayable(DateTime ageingDate, decimal decledgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.AgeingReportLedgerPayable(ageingDate, decledgerId).ToList();

                dtbl.Columns.Add("Sl_NO");
                dtbl.Columns.Add("Account_Ledger");
                dtbl.Columns.Add("VoucherType");
                dtbl.Columns.Add("VoucherNo");
                dtbl.Columns.Add("Date");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("masterId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("1 to 30");
                dtbl.Columns.Add("31 to 60");
                dtbl.Columns.Add("61 to 90");
                dtbl.Columns.Add("90 above");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Sl_NO"] = item.Sl_NO;
                    row["Account_Ledger"] = item.Account_Ledger;
                    row["VoucherType"] = item.VoucherType;
                    row["VoucherNo"] = item.VoucherNo;
                    row["Date"] = item.Date;
                    row["ledgerId"] = item.ledgerId;
                    row["masterId"] = item.masterId;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["1 to 30"] = item.C1_to_30;
                    row["31 to 60"] = item.C31_to_60;
                    row["61 to 90"] = item.C61_to_90;
                    row["90 above"] = item.C90_above;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MRSP1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public DataTable AgeingReportVoucherPayable(DateTime ageingDate, decimal decledgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.AgeingReportVoucherPayable(ageingDate, decledgerId).ToList();

                dtbl.Columns.Add("Sl_NO");
                dtbl.Columns.Add("Account_Ledger");
                dtbl.Columns.Add("VoucherType");
                dtbl.Columns.Add("VoucherNo");
                dtbl.Columns.Add("Date");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("masterId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("1 to 30");
                dtbl.Columns.Add("31 to 60");
                dtbl.Columns.Add("61 to 90");
                dtbl.Columns.Add("90 above");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Sl_NO"] = item.Sl_NO;
                    row["Account_Ledger"] = item.Account_Ledger;
                    row["VoucherType"] = item.VoucherType;
                    row["VoucherNo"] = item.VoucherNo;
                    row["Date"] = item.Date;
                    row["ledgerId"] = item.ledgerId;
                    row["masterId"] = item.masterId;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["1 to 30"] = item.C1_to_30;
                    row["31 to 60"] = item.C31_to_60;
                    row["61 to 90"] = item.C61_to_90;
                    row["90 above"] = item.C90_above;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MRSP1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public DataTable AgeingReportVoucherReceivable(DateTime ageingDate, decimal decledgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.AgeingReportVoucherReceivable(ageingDate, decledgerId).ToList();

                dtbl.Columns.Add("Sl_NO");
                dtbl.Columns.Add("Account_Ledger");
                dtbl.Columns.Add("VoucherType");
                dtbl.Columns.Add("VoucherNo");
                dtbl.Columns.Add("Date");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("masterId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("1 to 30");
                dtbl.Columns.Add("31 to 60");
                dtbl.Columns.Add("61 to 90");
                dtbl.Columns.Add("90 above");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Sl_NO"] = item.Sl_NO;
                    row["Account_Ledger"] = item.Account_Ledger;
                    row["VoucherType"] = item.VoucherType;
                    row["VoucherNo"] = item.VoucherNo;
                    row["Date"] = item.Date;
                    row["ledgerId"] = item.ledgerId;
                    row["masterId"] = item.masterId;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["1 to 30"] = item.C1_to_30;
                    row["31 to 60"] = item.C31_to_60;
                    row["61 to 90"] = item.C61_to_90;
                    row["90 above"] = item.C90_above;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MRSP1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public DataTable OutstandingPartyView()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.OutstandingPartyFillView().ToList();

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("ledgerName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerId"] = item.ledgerId;
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

        public System.Data.DataSet OutstandingViewAll(decimal decledgerId, string strAccountGroup, DateTime dtfromdate, DateTime dttodate)
        {
            IMEEntities IME = new IMEEntities();
            System.Data.DataSet dts = new System.Data.DataSet();
            dts.Tables.Add(new DataTable());
            try
            {
                DataTable dtbl1 = new DataTable();

                //var adaptor1 = (IME.OutstandingViewAll1(decledgerId, strAccountGroup, dtfromdate, dttodate)).FirstOrDefault();
                //foreach (var item in adaptor1)
                //{
                //    DataRow row = dtbl1.NewRow();
                //    row["companyName"] = item.;
                //    row["address"] = item.address;
                //    row["phone"] = item.phone;
                //    row["email"] = item.email;

                //    dts.Tables[0].Rows.Add(row);
                //}
                //dts.Tables.Add(dtbl1);


                //DataTable dtbl2 = new DataTable();

                //var adaptor2 = (IME.OutstandingViewAll2(decledgerId, strAccountGroup, dtfromdate, dttodate)).ToList();
                //foreach (var item in adaptor2)
                //{
                //    DataRow row = dtbl1.NewRow();
                //    row["companyName"] = item.companyName;
                //    row["address"] = item.address;
                //    row["phone"] = item.phone;
                //    row["email"] = item.email;

                //    dts.Tables[0].Rows.Add(row);
                //}
                //dts.Tables.Add(dtbl2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dts;
        }

        /// <summary>
        /// Function for billallocation search from partybalance table
        /// </summary>
        /// <param name="dtfromdate"></param>
        /// <param name="dttodate"></param>
        /// <param name="straccountgroup"></param>
        /// <param name="strledgername"></param>
        /// <returns></returns>
        public DataTable BillAllocationSearch(DateTime dtfromdate, DateTime dttodate, string straccountgroup, string strledgername)
        {
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = new IMEEntities().BillAllocationSearch(dtfromdate, dttodate,straccountgroup, strledgername).ToList();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("debit");
                dtbl.Columns.Add("credit");
                dtbl.Columns.Add("voucherTypeName");
                dtbl.Columns.Add("typeOfVoucher");
                dtbl.Columns.Add("accountGroupName");
                dtbl.Columns.Add("voucherTypeId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
                    row["date"] = item.date;
                    row["voucherNo"] = item.voucherNo;
                    row["debit"] = item.debit;
                    row["credit"] = item.credit;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["typeOfVoucher"] = item.typeOfVoucher;
                    row["accountGroupName"] = item.accountGroupName;
                    row["voucherTypeId"] = item.voucherTypeId;

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
