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

        public bool PDCReceivableVoucherCheckRreferenceUpdating(decimal decMasterId, decimal voucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            bool isExist = false;
            try
            {
                var adapter = (from l in IME.LedgerPostings.Where(a => a.voucherTypeId == voucherTypeId)
                               from rm in IME.PDCReceivableMasters.Where(r => r.pdcReceivableMasterId == Convert.ToDecimal(l.voucherNo) && l.ledgerId == r.ledgerId)
                               from br in IME.BankReconciliations.Where(b => b.ledgerPostingId == l.ledgerPostingId)
                               where
                                rm.pdcReceivableMasterId == decMasterId
                               select br.reconcileId).ToList();

                isExist = (adapter.Count() > 0) ? true : false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isExist;
        }

        public bool PDCReceivableCheckExistence(string voucherNo, decimal voucherTypeId, decimal decpdcReceivableId)
        {
            IMEEntities IME = new IMEEntities();
            bool isSave = false;
            try
            {
                var obj = (from rm in IME.PDCReceivableMasters.Where(r => r.pdcReceivableMasterId == decpdcReceivableId && r.voucherNo == voucherNo && r.voucherTypeId == voucherTypeId)
                           select rm.voucherNo).ToList();

                if (obj != null)
                {
                    isSave = (obj.Count() > 0) ? true : false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isSave;

        }

        public decimal PDCReceivableMasterAdd(PDCReceivableMaster pdcreceivablemasterinfo)
        {
            decimal decIdentity = 0;
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.PDCReceivableMasters.Add(pdcreceivablemasterinfo);
                IME.SaveChanges();
                decIdentity = pdcreceivablemasterinfo.pdcReceivableMasterId;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public void PDCReceivableMasterEdit(PDCReceivableMaster pi)
        {
            IMEEntities IME = new IMEEntities();

            try
            {

                PDCReceivableMaster pdc = IME.PDCReceivableMasters.Where(pd => pi.pdcReceivableMasterId == pd.pdcReceivableMasterId).FirstOrDefault();

                pdc.voucherNo = pi.voucherNo;
                pdc.invoiceNo = pi.invoiceNo;
                pdc.suffixPrefixId = pi.suffixPrefixId;
                pdc.date = pi.date;
                pdc.ledgerId = pi.ledgerId;
                pdc.amount = pi.amount;
                pdc.chequeNo = pi.chequeNo;
                pdc.chequeDate = pi.chequeDate;
                pdc.narration = pi.narration;
                pdc.userId = pi.userId;
                pdc.bankId = pi.bankId;
                pdc.voucherTypeId = pi.voucherTypeId;
                pdc.financialYearId = pi.financialYearId;

                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public DataTable LedgerPostingIdByPDCReceivableId(decimal pdcMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtblpdcReceivableId = new DataTable();

            decimal voucherNo = Convert.ToDecimal(IME.PDCReceivableMasters.Where(a => a.pdcReceivableMasterId == pdcMasterId).FirstOrDefault().voucherNo);

            int voucherTypeID = Convert.ToInt32(IME.PDCReceivableMasters.Where(a => a.pdcReceivableMasterId == pdcMasterId).FirstOrDefault().voucherTypeId);

            try
            {
                var adaptor = (from lp in IME.LedgerPostings.Where(l => l.voucherNo == Convert.ToString(voucherNo) && l.voucherTypeId == voucherTypeID)
                               select new { lp.ledgerPostingId }).ToList();

                dtblpdcReceivableId.Columns.Add("ledgerPostingId");

                foreach (var item in adaptor)
                {
                    var row = dtblpdcReceivableId.NewRow();

                    row["ledgerPostingId"] = item.ledgerPostingId;

                    dtblpdcReceivableId.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return dtblpdcReceivableId;
        }

        public decimal PDCReceivableMaxUnderVoucherTypePlusOne(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal max = 0;
            try
            {
                decimal? adapter = (from pr in IME.PDCReceivableMasters.Where(p => p.voucherTypeId == decVoucherTypeId)
                               select new { pr.voucherNo }).Max(x => Convert.ToDecimal(x.voucherNo));

                max = (adapter != null) ? (decimal)adapter : 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public string PDCReceivableMaxUnderVoucherType(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            string max ="0";
            try
            {
                var adapter = (from pr in IME.PDCReceivableMasters.Where(p => p.voucherTypeId == decVoucherTypeId)
                                    select new { pr.voucherNo }).Max(x => x.voucherNo);

                max = adapter ?? "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public void PDCReceivableDeleteMaster(decimal PdcReceivableId, decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                List<PartyBalance> ListPb = db.PartyBalances.Where(x => (x.voucherTypeId == decVoucherTypeId && x.referenceType == "New") ||
                 (x.againstVoucherTypeId == decVoucherTypeId && x.againstVoucherNo == strVoucherNo && x.referenceType == "Against")
                  || (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "OnAccount")).ToList();
                db.PartyBalances.RemoveRange(ListPb);

                List<decimal> listLedgerPostID = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).Select(y => y.ledgerPostingId).ToList();
                List<BankReconciliation> listBr = db.BankReconciliations.Where(x => listLedgerPostID.Contains((decimal)x.ledgerPostingId)).ToList();
                db.BankReconciliations.RemoveRange(listBr);

                List<LedgerPosting> listLp = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();
                db.LedgerPostings.RemoveRange(listLp);

                PDCReceivableMaster pdc = db.PDCReceivableMasters.Where(x => x.pdcReceivableMasterId == PdcReceivableId).FirstOrDefault();
                db.PDCReceivableMasters.Remove(pdc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public PDCReceivableMaster PDCReceivableMasterView(decimal pdcReceivableMasterId)
        {
            PDCReceivableMaster pdcreceivablemasterinfo = new PDCReceivableMaster();
            IMEEntities IME = new IMEEntities();

            try
            {
                pdcreceivablemasterinfo = IME.PDCReceivableMasters.Where(rm => rm.pdcReceivableMasterId == pdcReceivableMasterId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return pdcreceivablemasterinfo;
        }

        public bool PDCReceivableReferenceCheck(decimal decPDCReceivableMasterId)
        {
            IMEEntities IME = new IMEEntities();
            bool isExist = false;
            try
            {
                var adapter = (from pr in IME.PDCClearanceMasters.Where(p => p.againstId == decPDCReceivableMasterId)
                               select new { pr.againstId }).ToList();

                isExist = (adapter != null) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isExist;
        }


    }
}
