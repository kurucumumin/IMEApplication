using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm.Account.Services
{
    static class spAccountLedger
    {

        static public bool AccountLedgerCheckExistence(string LedgerName, decimal ledgerID)
        {
            IMEEntities db = new IMEEntities();
            return (db.AccountLedgers.Where(x => x.ledgerName == LedgerName && x.ledgerId != ledgerID).FirstOrDefault() != null) ? true : false;
        }

        static public void AccountLedgerEdit(AccountLedger accountledgerinfo)
        {
            try
            {
                IMEEntities db = new IMEEntities();
                AccountLedger accountledger = db.AccountLedgers.Find(accountledgerinfo);

                accountledger.ledgerId = accountledgerinfo.ledgerId;
                accountledger.accountGroupID = accountledgerinfo.accountGroupID;
                accountledger.ledgerName = accountledgerinfo.ledgerName;
                accountledger.openingBalance = accountledgerinfo.openingBalance;
                accountledger.crOrDr = accountledgerinfo.crOrDr;
                accountledger.narration = accountledgerinfo.narration;
                accountledger.mailingName = accountledgerinfo.mailingName;
                accountledger.phone = accountledgerinfo.phone;
                accountledger.mobile = accountledgerinfo.mobile;
                accountledger.email = accountledgerinfo.email;
                accountledger.creditPeriod = accountledgerinfo.creditPeriod;
                accountledger.creditLimit = accountledgerinfo.creditLimit;
                accountledger.pricinglevelId = accountledgerinfo.pricinglevelId;
                accountledger.billByBill = accountledgerinfo.billByBill;
                accountledger.tin = accountledgerinfo.tin;
                accountledger.cst = accountledgerinfo.cst;
                accountledger.pan = accountledgerinfo.pan;
                accountledger.routeId = accountledgerinfo.routeId;
                accountledger.bankAccountNumber = accountledgerinfo.bankAccountNumber;
                accountledger.branchName = accountledgerinfo.branchName;
                accountledger.branchCode = accountledgerinfo.branchCode;
                accountledger.areaId = accountledgerinfo.areaId;
                accountledger.isDefault = accountledgerinfo.isDefault;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        static public void LedgerPostingDeleteByVoucherTypeAndVoucherNo(string strVocuherNumber, decimal decvoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            LedgerPosting lp = new LedgerPosting();
            try
            {
                lp = db.LedgerPostings.Where(x => x.voucherNo == strVocuherNumber && x.voucherTypeId == (decimal)decvoucherTypeId).FirstOrDefault();
                db.LedgerPostings.Remove(lp);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }







    }
}
