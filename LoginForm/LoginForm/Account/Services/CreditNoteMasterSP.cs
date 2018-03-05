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
                //var adaptor = (from cn in db.CreditNoteMasters.Where(x => x.voucherNo.StartsWith(strVoucherNo) && (x.date > DateTime.Parse(strFromDate) && x.date < DateTime.Parse(strToDate))).OrderBy(y=>y.creditNoteMasterId)
                //               select new
                //               {
                //                   cn.creditNoteMasterId,
                //                   cn.invoiceNo,
                //                   //cn.VoucherType.voucherTypeName,
                //                   cn.suffixPrefixId,
                //                   date = cn.date.Value.Date,
                //                   Amount = cn.totalAmount,
                //                   cn.narration,
                //                   cn.userId,
                //                   //cn.voucherTypeId,
                //                   cn.financialYearId
                //               }).ToList();

                //var adaptor = (from cn in db.CreditNoteMasters
                //               from vt in db.VoucherTypes.Where(x =>x.voucherTypeId==cn.voucherTypeId)
                //               where cn.voucherNo.StartsWith(strVoucherNo) && (cn.date > DateTime.Parse(strFromDate) && cn.date < DateTime.Parse(strToDate))
                //               select new
                //               {
                //                   cn.creditNoteMasterId,
                //                   cn.invoiceNo,
                //                   cn.VoucherType.voucherTypeName,
                //                   cn.suffixPrefixId,
                //                   date = cn.date.Value.Date,
                //                   Amount = cn.totalAmount,
                //                   cn.narration,
                //                   cn.userId,
                //                   cn.voucherTypeId,
                //                   cn.financialYearId
                //               }).OrderBy(y=> y.creditNoteMasterId).ToList();

                var adaptor = db.CreditNoteRegisterSearch(strVoucherNo, Convert.ToDateTime(strFromDate), Convert.ToDateTime(strToDate)).ToList();

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

        public DataTable CreditNoteReportSearchWithLedgerId(string strFromDate, string strToDate, decimal  decLedgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            DateTime fromDate = Convert.ToDateTime(strFromDate);
            DateTime ToDate = Convert.ToDateTime(strToDate);

            try
            {

                var adaptor = (from c in IME.CreditNoteMasters
                               from w in IME.Workers.Where(x => x.WorkerID == c.userId)
                               from cd in IME.CreditNoteDetails.Where(x => x.creditNoteMasterId == c.creditNoteMasterId)
                               from al in IME.AccountLedgers.Where(x => x.ledgerId == cd.ledgerId)
                               where
                               (c.date > fromDate && c.date < ToDate) 
                               &&
                               (cd.ledgerId == ((decLedgerId == 0) ? cd.ledgerId : decLedgerId))
                               select new
                               {
                                   c.creditNoteMasterId,
                                   c.VoucherType.voucherTypeName,
                                   c.voucherNo,
                                   date = c.date.ToString(),
                                   totalAmount = c.totalAmount,
                                   c.narration,
                                   w.UserName
                               }).
                               OrderByDescending(x => x.creditNoteMasterId).Distinct().
                               ToList();
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

                    row["creditNoteMasterId"] = item.creditNoteMasterId;
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

        
        public DataTable CreditNoteReportSearch(string strFromDate, string strToDate, decimal decVoucherTypeId, decimal decLedgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            DateTime fromDate = Convert.ToDateTime(strFromDate);
            DateTime ToDate = Convert.ToDateTime(strToDate);

            try
            {

                var adaptor = (from c in IME.CreditNoteMasters
                               from v in IME.VoucherTypes.Where(x => x.voucherTypeId == c.voucherTypeId)
                               from w in IME.Workers.Where(x => x.WorkerID == c.userId)
                               from cd in IME.CreditNoteDetails.Where(x => x.creditNoteMasterId == c.creditNoteMasterId)
                               from al in IME.AccountLedgers.Where(x => x.ledgerId == cd.ledgerId)
                               where
                               (c.date > fromDate && c.date < ToDate) &&
                               (c.voucherTypeId == ((decVoucherTypeId == 0) ? c.voucherTypeId : decVoucherTypeId)) &&
                               (cd.ledgerId == ((decLedgerId == 0) ? cd.ledgerId : decLedgerId))
                               select new
                               {
                                   c.creditNoteMasterId,
                                   v.voucherTypeName,
                                   c.voucherNo,
                                   date = c.date.ToString(),
                                   totalAmount = c.totalAmount,
                                   c.narration,
                                   w.UserName
                               }).
                               OrderByDescending(x => x.creditNoteMasterId).Distinct().
                               ToList();
                                    


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

                    row["creditNoteMasterId"] = item.creditNoteMasterId;
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

        public DataTable CreditNoteReportSearchwithVoucherTypeId(string strFromDate, string strToDate, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            DateTime fromDate = Convert.ToDateTime(strFromDate);
            DateTime ToDate = Convert.ToDateTime(strToDate);

            try
            {

                var adaptor = (from c in IME.CreditNoteMasters
                               from v in IME.VoucherTypes.Where(x => x.voucherTypeId == c.voucherTypeId)
                               from w in IME.Workers.Where(x => x.WorkerID == c.userId)
                               from cd in IME.CreditNoteDetails.Where(x => x.creditNoteMasterId == c.creditNoteMasterId)
                               where
                               (c.date > fromDate && c.date < ToDate) &&
                               (c.voucherTypeId == ((decVoucherTypeId == 0) ? c.voucherTypeId : decVoucherTypeId))
                               select new
                               {
                                   c.creditNoteMasterId,
                                   v.voucherTypeName,
                                   c.voucherNo,
                                   date = c.date.ToString(),
                                   totalAmount = c.totalAmount,
                                   c.narration,
                                   w.UserName
                               }).
                               OrderByDescending(x => x.creditNoteMasterId).Distinct().
                               ToList();



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

                    row["creditNoteMasterId"] = item.creditNoteMasterId;
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

        public decimal CreditNoteMasterGetMaxPlusOne(decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            decimal max = 0;
            try
            {
                List<CreditNoteMaster> list = db.CreditNoteMasters.Where(x => x.voucherTypeId == decVoucherTypeId).ToList();

                foreach (CreditNoteMaster item in list)
                {
                    item.voucherNo = item.voucherNo ?? "0";
                    max = (Convert.ToDecimal(item.voucherNo) > max) ? Convert.ToDecimal(item.voucherNo) : max;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max+1;
        }

        public string CreditNoteMasterGetMax(decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            string max = "0";
            try
            {
                List<CreditNoteMaster> list = db.CreditNoteMasters.Where(x => x.voucherTypeId == decVoucherTypeId).ToList();

                foreach (CreditNoteMaster item in list)
                {
                    item.voucherNo = item.voucherNo ?? "0";
                    max = (Convert.ToDecimal(item.voucherNo) > Convert.ToDecimal(max)) ? item.voucherNo : max;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public bool CreditNoteCheckExistence(string strInvoiceNo, decimal voucherTypeId, decimal decMasterId)
        {
            IMEEntities IME = new IMEEntities();
            bool trueOrfalse = false;
            try
            {
                var list = from x in IME.CreditNoteMasters
                            where x.invoiceNo == strInvoiceNo && x.voucherTypeId == voucherTypeId && x.creditNoteMasterId == decMasterId
                            select new { x.invoiceNo };
                trueOrfalse = (list.Count() > 0) ? true : false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return trueOrfalse;
        }

        public void CreditNoteVoucherDelete(decimal decCreditNoteMasterId, decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();

            try
            {
                List<PartyBalance> pList = db.PartyBalances.Where(x => (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "New") || (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "Against") || (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "OnAccount")).ToList();
                db.PartyBalances.RemoveRange(pList);


                decimal? ledgerPostID = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).FirstOrDefault().ledgerPostingId;
                List<BankReconciliation> listBr = db.BankReconciliations.Where(x => x.ledgerPostingId == ledgerPostID).ToList();
                db.BankReconciliations.RemoveRange(listBr);


                List<LedgerPosting> lpList = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();
                db.LedgerPostings.RemoveRange(lpList);

                List<CreditNoteDetail> cdList = db.CreditNoteDetails.Where(x => x.creditNoteMasterId==decCreditNoteMasterId).ToList();
                db.CreditNoteDetails.RemoveRange(cdList);

                List<CreditNoteMaster> cmList = db.CreditNoteMasters.Where(x => x.creditNoteMasterId==decCreditNoteMasterId).ToList();
                db.CreditNoteMasters.RemoveRange(cmList);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal CreditNoteMasterAdd(CreditNoteMaster creditnotedetailsinfo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decId = 0;
            try
            {
                IME.CreditNoteMasters.Add(creditnotedetailsinfo);
                IME.SaveChanges();
                decId = creditnotedetailsinfo.creditNoteMasterId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decId;
        }

        public decimal CreditNoteMasterEdit(CreditNoteMaster pi)
        {
            IMEEntities IME = new IMEEntities();
            decimal decCreditNoteMaster = 0;

            try
            {
                CreditNoteMaster pdc = IME.CreditNoteMasters.Where(pd => pi.creditNoteMasterId == pd.creditNoteMasterId).FirstOrDefault();

                pdc.creditNoteMasterId = pi.creditNoteMasterId;
                pdc.voucherNo = pi.voucherNo;
                pdc.invoiceNo = pi.invoiceNo;
                pdc.suffixPrefixId = pi.suffixPrefixId;
                pdc.date = pi.date;
                pdc.voucherTypeId= pi.voucherTypeId;
                pdc.userId = pi.userId;
                pdc.totalAmount = pi.totalAmount;
                pdc.narration = pi.narration;
                pdc.financialYearId = pi.financialYearId;

                IME.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decCreditNoteMaster;
        }

        public CreditNoteMaster CreditNoteMasterView(decimal creditNoteMasterId)
        {
            IMEEntities IME = new IMEEntities();
            CreditNoteMaster creditnotemasterinfo = new CreditNoteMaster();
            try
            {

                creditnotemasterinfo = IME.CreditNoteMasters.Where(rm => rm.creditNoteMasterId==creditNoteMasterId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return creditnotemasterinfo;
        }

        public decimal CreditNoteMasterIdView(decimal decVouchertypeid, string strVoucherNo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decid = 0;
            try
            {
                decid = Convert.ToDecimal(IME.CreditNoteMasterIdView(decVouchertypeid, strVoucherNo).FirstOrDefault());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decid;
        }
    }
}
