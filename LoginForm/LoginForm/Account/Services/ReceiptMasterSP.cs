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
    class ReceiptMasterSP
    {
        public void ReceiptVoucherDelete(decimal decReceiptMasterId, decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                List<PartyBalance> partyList = db.PartyBalances.Where(x =>
                (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "New") ||
                (x.againstVoucherTypeId == decVoucherTypeId && x.againstVoucherNo == strVoucherNo && x.referenceType == "Against") ||
                (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "OnAccount"))
                .ToList();
                
                db.PartyBalances.RemoveRange(partyList);
                db.SaveChanges();


                List<decimal> IDs = db.LedgerPostings.Where(x=>x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).Select(x => x.ledgerPostingId).ToList();
                foreach (decimal id in IDs)
                {
                    List<BankReconciliation> bankList = db.BankReconciliations.Where(x => x.ledgerPostingId == id).ToList();

                    db.BankReconciliations.RemoveRange(bankList);
                    db.SaveChanges();
                }


                List<LedgerPosting> postingList = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();
                db.LedgerPostings.RemoveRange(postingList);
                db.SaveChanges();


                List<ReceiptDetail> receiptDList = db.ReceiptDetails.Where(x => x.receiptMasterId == decReceiptMasterId).ToList();
                db.ReceiptDetails.RemoveRange(receiptDList);
                db.SaveChanges();


                List<ReceiptMaster> receiptMList = db.ReceiptMasters.Where(x => x.receiptMasterId == decReceiptMasterId).ToList();
                db.ReceiptMasters.RemoveRange(receiptMList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("RMSP :5" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public decimal ReceiptMasterGetMax(decimal decVoucherTypeId)
        {
            decimal decMax = 0;
            try
            {
                decMax = new IMEEntities().ReceiptMasters.Where(x => x.voucherTypeId == decVoucherTypeId).Select(x => Convert.ToInt32(x.voucherNo)).Max();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decMax;
        }

        public decimal ReceiptMasterAdd(ReceiptMaster receiptmasterinfo)
        {
            IMEEntities db = new IMEEntities();
            decimal decRecieptMasterId = 0;

            try
            {
                db.ReceiptMasters.Add(receiptmasterinfo);
                decRecieptMasterId = receiptmasterinfo.receiptMasterId;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decRecieptMasterId;
        }

        public decimal ReceiptMasterEdit(ReceiptMaster rmc)
        {
            IMEEntities db = new IMEEntities();
            decimal decRecieptMasterId = 0;
            try
            {
                ReceiptMaster rp = db.ReceiptMasters.Where(x => x.receiptMasterId == rmc.receiptMasterId).FirstOrDefault();

                rp.voucherNo = rmc.voucherNo;
                rp.invoiceNo = rmc.invoiceNo;
                rp.suffixPrefixId = rmc.suffixPrefixId;
                rp.date = rmc.date;
                rp.ledgerId = rmc.ledgerId;
                rp.totalAmount = rmc.totalAmount;
                rp.narration = rmc.narration;
                rp.voucherTypeId = rmc.voucherTypeId;
                rp.userId = rmc.userId;
                rp.financialYearId = rmc.financialYearId;

                db.SaveChanges();

                decRecieptMasterId = rp.receiptMasterId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decRecieptMasterId;
        }

        public bool ReceiptVoucherCheckExistence(string strvoucherNo, decimal decvoucherTypeId, decimal decMasterId)
        {
            IMEEntities db = new IMEEntities();
            bool trueOrfalse = false;
            try
            {
                var adaptor = db.ReceiptMasters.Where(x => x.voucherNo == strvoucherNo && x.voucherTypeId == decvoucherTypeId && x.receiptMasterId != decMasterId).ToList();

                trueOrfalse = (adaptor.Count() > 0) ? false : true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return trueOrfalse;
        }
        public ReceiptMaster ReceiptMasterViewByMasterId(decimal decReceiptMastertId)
        {
            IMEEntities db = new IMEEntities();
            ReceiptMaster InfoReceiptMaster = new ReceiptMaster();
            try
            {
                InfoReceiptMaster = db.ReceiptMasters.Where(x => x.receiptMasterId == decReceiptMastertId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return InfoReceiptMaster;
        }

        public DataTable ReceiptReportSearch(DateTime dtpFromDate, DateTime dtpToDate, decimal decLedgerId, decimal decVoucherTypeId, decimal decCashOrBankId)
        {
            IMEEntities db = new IMEEntities();

            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from R in db.ReceiptMasters
                               from A in db.AccountLedgers.Where(x => x.ledgerId == R.ledgerId)
                               from D in db.ReceiptDetails.Where(x => x.receiptMasterId == R.receiptMasterId)
                               from V in db.VoucherTypes.Where(x => x.voucherTypeId == R.voucherTypeId)
                               from U in db.Workers.Where(x => x.WorkerID == R.userId)
                               where
                                     (R.date > dtpFromDate && R.date < dtpToDate) &&
                                     (R.voucherTypeId == ((decVoucherTypeId == 0) ? R.voucherTypeId : (decimal)decVoucherTypeId)) &&
                                     (D.ledgerId == ((decLedgerId == 0) ? D.ledgerId : decLedgerId)) &&
                                     (R.ledgerId == ((decCashOrBankId == 0) ? R.ledgerId : decCashOrBankId))
                               select new
                               {
                                   R.receiptMasterId,
                                   V.voucherTypeName,
                                   R.voucherNo,
                                   date = R.date,
                                   A.ledgerName,
                                   R.totalAmount,
                                   U.UserName,
                                   R.narration
                               }).OrderByDescending(x => x.receiptMasterId).ToList();

                dtbl.Columns.Add("receiptMasterId");
                dtbl.Columns.Add("voucherTypeName");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("UserName");
                dtbl.Columns.Add("narration");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["receiptMasterId"] = item.receiptMasterId;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["voucherNo"] = item.voucherNo;
                    row["date"] = item.date;
                    row["ledgerName"] = item.ledgerName;
                    row["totalAmount"] = item.totalAmount;
                    row["UserName"] = item.UserName;
                    row["narration"] = item.narration;

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
