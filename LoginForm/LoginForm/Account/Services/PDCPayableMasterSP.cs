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
    class PDCPayableMasterSP
    {
        public DataTable PDCpayableRegisterSearch(DateTime dtFromdate, DateTime dtTodate, string strVoucherNo, string strLedgerName)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from pdc in db.PDCPayableMasters.Where(x=>
                (x.date > dtFromdate && x.date < dtTodate) &&
                ((strVoucherNo == String.Empty) ? x.invoiceNo == x.invoiceNo : x.invoiceNo.StartsWith(strVoucherNo)) &&
                (strLedgerName == "All") ? x.AccountLedger.ledgerName == x.AccountLedger.ledgerName : x.AccountLedger.ledgerName == strLedgerName).
                OrderByDescending(y=>y.pdcPayableMasterId)
                               select new
                               {
                                   pdc.pdcPayableMasterId,
                                   pdc.invoiceNo,
                                   pdc.suffixPrefixId,
                                   date = pdc.date.ToString(),
                                   pdc.amount,
                                   pdc.narration,
                                   pdc.userId,
                                   pdc.voucherTypeId,
                                   pdc.financialYearId,
                                   pdc.AccountLedger.ledgerName,
                                   pdc.VoucherType.voucherTypeName
                               }).ToList();

                dtbl.Columns.Add("pdcPayableMasterId");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("suffixPrefixId");
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

                    row["pdcPayableMasterId"] = item.pdcPayableMasterId;
                    row["invoiceNo"] = item.invoiceNo;
                    row["suffixPrefixId"] = item.suffixPrefixId;
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

        public DataTable AccountLedgerComboFill(bool Isall)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (from al in db.AccountLedgers
                               select new
                               {
                                   al.ledgerId,
                                   al.accountGroupID,
                                   al.ledgerName,
                                   al.openingBalance,
                                   al.crOrDr,
                                   al.narration,
                                   al.mailingName,
                                   al.address,
                                   al.phone,
                                   al.email,
                                   al.creditPeriod,
                                   al.creditLimit,
                                   al.pricinglevelId,
                                   al.billByBill,
                                   al.tin,
                                   al.cst,
                                   al.pan,
                                   al.routeId,
                                   al.bankAccountNumber,
                                   al.branchName,
                                   al.branchCode
                               }).ToList();

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("accountGroupID");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("openingBalance");
                dtbl.Columns.Add("crOrDr");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("mailingName");
                dtbl.Columns.Add("address");
                dtbl.Columns.Add("phone");
                dtbl.Columns.Add("email");
                dtbl.Columns.Add("creditPeriod");
                dtbl.Columns.Add("creditLimit");
                dtbl.Columns.Add("pricinglevelId");
                dtbl.Columns.Add("billByBill");
                dtbl.Columns.Add("tin");
                dtbl.Columns.Add("cst");
                dtbl.Columns.Add("pan");
                dtbl.Columns.Add("routeId");
                dtbl.Columns.Add("bankAccountNumber");
                dtbl.Columns.Add("branchName");
                dtbl.Columns.Add("branchCode");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerId"] = item.ledgerId;
                    row["accountGroupID"] = item.accountGroupID;
                    row["ledgerName"] = item.ledgerName;
                    row["openingBalance"] = item.openingBalance;
                    row["crOrDr"] = item.crOrDr;
                    row["narration"] = item.narration;
                    row["mailingName"] = item.mailingName;
                    row["address"] = item.address;
                    row["phone"] = item.phone;
                    row["email"] = item.email;
                    row["creditPeriod"] = item.creditPeriod;
                    row["creditLimit"] = item.creditLimit;
                    row["pricinglevelId"] = item.pricinglevelId;
                    row["billByBill"] = item.billByBill;
                    row["tin"] = item.tin;
                    row["cst"] = item.cst;
                    row["pan"] = item.pan;
                    row["routeId"] = item.routeId;
                    row["bankAccountNumber"] = item.bankAccountNumber;
                    row["branchName"] = item.branchName;
                    row["branchCode"] = item.branchCode;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        /// <summary>
        /// Function to fill bank combobox
        /// </summary>
        /// <returns></returns>
        public DataTable BankAccountComboFill()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = new IMEEntities().BankAccountComboFill().ToList();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public decimal PDCPayableMaxUnderVoucherTypePlusOne(decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            decimal max = 0;
            try
            {
                List<PDCPayableMaster> list = db.PDCPayableMasters.Where(x => x.voucherTypeId == decVoucherTypeId).ToList();

                foreach (PDCPayableMaster item in list)
                {
                    item.voucherNo = item.voucherNo ?? "0";
                    max = (Convert.ToDecimal(item.voucherNo) > max) ? Convert.ToDecimal(item.voucherNo) : max;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public decimal PDCPayableMasterAdd(PDCPayableMaster pdcpayablemasterinfo)
        {
            IMEEntities db = new IMEEntities();
            PDCPayableMaster pdc = pdcpayablemasterinfo;
            decimal decIdentity = 0;
            try
            {
                db.PDCPayableMasters.Add(pdc);
                db.SaveChanges();
                decIdentity = pdc.pdcPayableMasterId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public void PDCPayableMasterEdit(PDCPayableMaster pdcpayablemasterinfo)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                PDCPayableMaster pdc = db.PDCPayableMasters.Where(x => x.pdcPayableMasterId == pdcpayablemasterinfo.pdcPayableMasterId).FirstOrDefault();

                pdc.voucherNo = pdcpayablemasterinfo.voucherNo;
                pdc.invoiceNo = pdcpayablemasterinfo.invoiceNo;
                pdc.suffixPrefixId = pdcpayablemasterinfo.suffixPrefixId;
                pdc.date = pdcpayablemasterinfo.date;
                pdc.ledgerId = pdcpayablemasterinfo.ledgerId;
                pdc.amount = pdcpayablemasterinfo.amount;
                pdc.chequeNo = pdcpayablemasterinfo.chequeNo;
                pdc.chequeDate = pdcpayablemasterinfo.chequeDate;
                pdc.narration = pdcpayablemasterinfo.narration;
                pdc.userId = pdcpayablemasterinfo.userId;
                pdc.bankId = pdcpayablemasterinfo.bankId;
                pdc.voucherTypeId = pdcpayablemasterinfo.voucherTypeId;
                pdc.financialYearId = pdcpayablemasterinfo.financialYearId;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool PDCpayableCheckExistence(string voucherNo, decimal voucherTypeId, decimal pdcPayableMasterId)
        {
            IMEEntities db = new IMEEntities();
            bool isSave = false;
            int count;
            try
            {
                count = db.PDCPayableMasters.Where(
                    x => x.voucherNo == voucherNo &&
                    x.voucherTypeId == voucherTypeId &&
                    x.pdcPayableMasterId != pdcPayableMasterId).Count();
                isSave = (count > 0) ? false : true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isSave;
        }

        public bool PDCPayableVoucherCheckRreference(decimal decMasterId, decimal voucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            bool isExist = false;
            try
            {
                var list = from lp in db.LedgerPostings
                           from pm in db.PDCPayableMasters.Where(x => x.pdcPayableMasterId == Convert.ToDecimal(lp.voucherNo))
                           from br in db.BankReconciliations.Where(x => x.ledgerPostingId == lp.ledgerPostingId)
                           where lp.voucherTypeId == voucherTypeId && pm.pdcPayableMasterId == decMasterId
                           select new {
                               br.reconcileId
                           };

                isExist = (list.Count() > 0) ? true : false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isExist;
        }

        public DataTable LedgerPostingIdByPDCpayableId(decimal pdcMasterId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtblpdcPayableId = new DataTable();
            try
            {
                string voucherNo = db.PDCPayableMasters.Where(x => x.pdcPayableMasterId == pdcMasterId).FirstOrDefault().voucherNo;
                decimal? voucherTypeID = db.PDCPayableMasters.Where(x => x.pdcPayableMasterId == pdcMasterId).FirstOrDefault().voucherTypeId;

                var adaptor = (from lp in db.LedgerPostings.Where(x=>x.voucherNo == voucherNo && x.voucherTypeId == voucherTypeID)
                               select new
                               {
                                   lp.ledgerPostingId
                               }).ToList();

                dtblpdcPayableId.Columns.Add("ledgerPostingId");

                foreach (var item in adaptor)
                {
                    var row = dtblpdcPayableId.NewRow();

                    row["ledgerPostingId"] = item.ledgerPostingId;

                    dtblpdcPayableId.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblpdcPayableId;
        }

        public void PDCPayableMasterDelete(decimal PdcpayableId, decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                List<PartyBalance> ListPb = db.PartyBalances.Where(x => (x.voucherTypeId == decVoucherTypeId && x.referenceType == "New") || (x.againstVoucherTypeId == decVoucherTypeId && x.againstVoucherNo == strVoucherNo && x.referenceType == "Against") || (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "OnAccount")).ToList();
                db.PartyBalances.RemoveRange(ListPb);
                db.SaveChanges();

                decimal? ledgerPostID = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).FirstOrDefault().ledgerPostingId;
                List<BankReconciliation> listBr = db.BankReconciliations.Where(x => x.ledgerPostingId == ledgerPostID).ToList();
                db.BankReconciliations.RemoveRange(listBr);
                db.SaveChanges();

                List<LedgerPosting> listLp = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();
                db.LedgerPostings.RemoveRange(listLp);
                db.SaveChanges();

                PDCPayableMaster pdc = db.PDCPayableMasters.Where(x => x.pdcPayableMasterId == PdcpayableId).FirstOrDefault();
                db.PDCPayableMasters.Remove(pdc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool PDCPayableReferenceCheck(decimal decMasterId, decimal decvoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            bool isExist = false;
            try
            {
                decimal? against = db.PDCClearanceMasters.Where(x => x.againstId == decMasterId && x.voucherTypeId == decvoucherTypeId).FirstOrDefault().againstId;

                isExist = (against != null) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isExist;
        }

        public PDCPayableMaster PDCPayableMasterView(decimal pdcPayableMasterId)
        {
            PDCPayableMaster pdcpayablemasterinfo = new PDCPayableMaster();
            try
            {
                pdcpayablemasterinfo = new IMEEntities().PDCPayableMasters.Where(x => x.pdcPayableMasterId == pdcPayableMasterId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return pdcpayablemasterinfo;
        }

        public DataTable PdcPayableReportSearch(DateTime dtFromdate, DateTime dtToDate, string strVoucherType, string strLedgerName, DateTime dtcheckfromdate, DateTime dtCheckdateto, string strchequeNo, string strvoucherNo, string strstatus)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.PdcPayableReportSearch(dtFromdate, dtToDate, strVoucherType, strLedgerName, dtcheckfromdate, dtCheckdateto, strstatus, strchequeNo, strvoucherNo );

                dtbl.Columns.Add("pdcPayableMasterId");
                dtbl.Columns.Add("voucherTypeName");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("chequeNo");
                dtbl.Columns.Add("checkDate");
                dtbl.Columns.Add("amount");
                dtbl.Columns.Add("Narration");
                dtbl.Columns.Add("userName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["pdcReceivableMasterId"] = item.pdcPayableMasterId;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["invoiceNo"] = item.invoiceNo;
                    row["date"] = item.date;
                    row["ledgerName"] = item.ledgerName;
                    row["chequeNo"] = item.chequeNo;
                    row["checkDate"] = item.checkDate;
                    row["amount"] = item.amount;
                    row["narration"] = item.Narration;
                    row["UserName"] = item.userName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable ChequeReportGridFill(DateTime dtFromDate, DateTime dtTodate, DateTime dtChequefromDate, DateTime dtChequetoDate, bool isIssued, decimal decParty, string strChequeNo)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            string startext = "";
            try
            {
                var adaptor = IME.ChequeReportGridFill(dtFromDate, dtTodate, dtChequefromDate, dtChequetoDate, isIssued, decParty.ToString(), startext, strChequeNo).ToList();

                dtbl.Columns.Add("MasterId");
                dtbl.Columns.Add("Voucher_Type");
                dtbl.Columns.Add("Voucher_No");
                dtbl.Columns.Add("Issued_Date");
                dtbl.Columns.Add("Party");
                dtbl.Columns.Add("Amount");
                dtbl.Columns.Add("Cheque_No");
                dtbl.Columns.Add("Cheque_Date");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["MasterId"] = item.MasterId;
                    row["Voucher_Type"] = item.Voucher_Type;
                    row["Voucher_No"] = item.Voucher_No;
                    row["Issued_Date"] = item.Issued_Date;
                    row["Party"] = item.Party;
                    row["Amount"] = item.Amount;
                    row["Cheque_No"] = item.Cheque_No;
                    row["Cheque_Date"] = item.Cheque_Date;
                    row["ledgerId"] = item.ledgerId;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable ChequeReportPartyComboFill()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.ChequeReportPartyComboFill().ToList();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public decimal PdcPayableMasterIdView(decimal decVouchertypeid, string strVoucherNo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decid = 0;
            try
            {
                decid = Convert.ToDecimal(IME.PdcPayableMasterIdView(decVouchertypeid, strVoucherNo).FirstOrDefault());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decid;
        }
    }
}
