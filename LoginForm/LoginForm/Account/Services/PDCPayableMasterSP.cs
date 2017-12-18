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
    }
}
