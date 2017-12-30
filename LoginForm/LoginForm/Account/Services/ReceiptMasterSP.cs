using LoginForm.DataSet;
using System;
using System.Collections.Generic;
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
    }
}
