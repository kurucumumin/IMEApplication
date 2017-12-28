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


                List<ReceiptDetail> receiptDList = db.ReceiptDetails.Where(x => x.receiptMasterId == decReceiptMasterId).ToList();
                db.ReceiptDetails.RemoveRange(receiptDList);


                List<ReceiptMaster> receiptMList = db.ReceiptMasters.Where(x => x.receiptMasterId == decReceiptMasterId).ToList();
                db.ReceiptMasters.RemoveRange(receiptMList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("RMSP :5" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
