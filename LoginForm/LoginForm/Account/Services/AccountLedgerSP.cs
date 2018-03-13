using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace LoginForm.Account.Services
{
    class AccountLedgerSP
    {
        public bool AccountLedgerCheckExistence(string LedgerName, decimal ledgerID)
        {
            IMEEntities db = new IMEEntities();
            return (db.AccountLedgers.Where(x => x.ledgerName == LedgerName && x.ledgerId != ledgerID).FirstOrDefault() != null) ? true : false;
        }

        public DataTable AccountLedgerViewForAdditionalCost()
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();

            var accountGroup = IME.AccountGroups.Where(a => a.accountGroupName == "Indirect Expenses").ToList();
            var adaptor = (from al in IME.AccountLedgers
                           from ac in accountGroup
                           where (al.accountGroupID == ac.accountGroupId)
                           select new
                           {
                               al.ledgerName,
                               al.ledgerId
                           }).ToList();

            dtbl.Columns.Add("ledgerName");
            dtbl.Columns.Add("ledgerId");

            foreach (var item in adaptor)
            {
                var row = dtbl.NewRow();
                row["ledgerName"] = item.ledgerName;
                row["ledgerId"] = item.ledgerId;
                dtbl.Rows.Add(row);
            }

            return dtbl;
        }

        public void AccountLedgerEdit(AccountLedger ac)
        {
            if (ac == null)
            {
                throw new ArgumentNullException(nameof(ac));
            }

            try
            {
                new IMEEntities().AccountLedgerEdit(
                    ac.ledgerId,
                    ac.accountGroupID,
                    ac.ledgerName,
                    ac.openingBalance,
                    ac.crOrDr,
                    ac.narration,
                    ac.mailingName,
                    ac.address,
                    ac.isDefault,
                    ac.phone,
                    ac.mobile,
                    ac.email,
                    ac.creditPeriod,
                    ac.creditLimit,
                    ac.pricinglevelId,
                    ac.billByBill,
                    ac.tin,
                    ac.cst,
                    ac.pan,
                    ac.routeId,
                    ac.bankAccountNumber,
                    ac.branchName,
                    ac.branchCode,
                    ac.areaId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LedgerPostingDeleteByVoucherTypeAndVoucherNo(string strVocuherNumber, decimal decvoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            LedgerPosting lp = new LedgerPosting();
            try
            {
                new IMEEntities().LedgerPostingDeleteByVoucherTypeAndVoucherNo(strVocuherNumber, decvoucherTypeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void PartyBalanceDeleteByVoucherTypeVoucherNoAndReferenceType(string strVocuherNumber, decimal decVoucherTypeId)
        {

            try
            {
                new IMEEntities().PartyBalanceDeleteByVoucherTypeVoucherNoAndReferenceType(strVocuherNumber, decVoucherTypeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable AccountLedgerSearch(string straccountgroupname, string strledgername)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;


            try
            {
                var adaptor = (from al in db.AccountLedgers.Where(x => x.ledgerName.StartsWith(strledgername) && x.AccountGroup.accountGroupName ==
                               ((straccountgroupname == "All") ?
                               x.AccountGroup.accountGroupName : straccountgroupname))
                               select new
                               {
                                   al.ledgerName,
                                   al.AccountGroup.accountGroupName,
                                   al.openingBalance,
                                   al.crOrDr,
                                   al.ledgerId
                               }).ToList();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("accountGroupName");
                dtbl.Columns.Add("openingBalance");
                dtbl.Columns.Add("crOrDr");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
                    row["accountGroupName"] = item.accountGroupName;
                    row["openingBalance"] = item.openingBalance;
                    row["crOrDr"] = item.crOrDr;
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

        public decimal AccountLedgerCheckReferences(decimal decledgerId)
        {

            // Referance tablo kontrolleri eklenecek
            IMEEntities db = new IMEEntities();
            decimal decReturnValue = -1;
            try
            {
                AccountLedger ac = db.AccountLedgers.Where(x => x.ledgerId == decledgerId).FirstOrDefault();
                db.AccountLedgers.Remove(ac);

                db.SaveChanges();
                decReturnValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decReturnValue;
        }

        public AccountLedger AccountLedgerViewForEdit(decimal ledgerId)
        {
            IMEEntities db = new IMEEntities();
            AccountLedger accountLedger = new AccountLedger();

            accountLedger = db.AccountLedgers.Where(x => x.ledgerId == ledgerId).FirstOrDefault();

            return accountLedger;
        }

        public bool PartyBalanceAgainstReferenceCheck(string strVoucherNo, decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            List<PartyBalance> list = new List<PartyBalance>();
            try
            {
                list = db.PartyBalances.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "Against").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return (list.Count > 0) ? true : false;
        }

        public DataTable AccountLedgerForSecondaryDetails()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Sundry Creditors" || x.accountGroupName == "Sundry Debtors")
                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                   hierarchyLevel = 1
                               }).ToList();

                List<int> IDs = adaptor.Select(x => x.AccountGroupId).ToList();
                int ID1 = IDs[0];
                int ID2 = IDs[1];
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == ID1 || x.groupUnder == ID2)
                                select new
                                {
                                    AccountGroupId = ag.accountGroupId,
                                    hierarchyLevel = 2
                                }).ToList();

                foreach (var item in adaptor2)
                {
                    if (!adaptor.Exists(x => x.AccountGroupId == item.AccountGroupId))
                    {
                        adaptor.Add(item);
                    }
                }

                dtbl.Columns.Add("AccountGroupId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["AccountGroupId"] = item.AccountGroupId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable AccountLedgerForBankDetails()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Bank OD A/C" || x.accountGroupName == "Bank Account")
                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                   hierarchyLevel = 1
                               }).ToList();
                List<int> IDs = adaptor.Select(x => x.AccountGroupId).ToList();
                int ID1 = IDs[0];
                int ID2 = IDs[1];
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == ID1 || x.groupUnder == ID2)
                                select new
                                {
                                    AccountGroupId = ag.accountGroupId,
                                    hierarchyLevel = 2
                                }).ToList();

                foreach (var item in adaptor2)
                {
                    if (!adaptor.Exists(x => x.AccountGroupId == item.AccountGroupId))
                    {
                        adaptor.Add(item);
                    }
                }

                dtbl.Columns.Add("AccountGroupId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["AccountGroupId"] = item.AccountGroupId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public String CreditOrDebitChecking(decimal decLedgerId)
        {
            IMEEntities db = new IMEEntities();

            string strNature = string.Empty;
            try
            {
                strNature = db.AccountGroups.Where(x => x.accountGroupId == decLedgerId).FirstOrDefault().nature;
                if (strNature == "Assets" || strNature == "Expenses")
                {
                    strNature = "Dr";
                }
                else if (strNature == "Liabilities" || strNature == "Income")
                {
                    strNature = "Cr";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strNature;
        }

        public DataTable AccountLedgerViewAll()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.AccountLedgerViewAll().ToList();

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

                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;
                    row["accountGroupID"] = item.accountGroupId;
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
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public bool AccountGroupIdCheckSundryCreditorOnly(string strLedgerName)
        {
            IMEEntities db = new IMEEntities();
            bool isSundrycredit = false;
            try
            {
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Sundry Creditors" || x.accountGroupName == "Sundry Debtors")
                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                   hierarchyLevel = 1
                               }).ToList();

                List<int> IDs = adaptor.Select(x => x.AccountGroupId).ToList();
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == IDs[0] || x.groupUnder == IDs[1])
                                select new
                                {
                                    AccountGroupId = ag.accountGroupId,
                                    hierarchyLevel = 2
                                }).ToList();

                foreach (var item in adaptor2)
                {
                    if (!adaptor.Exists(x => x.AccountGroupId == item.AccountGroupId))
                    {
                        adaptor.Add(item);
                    }
                }

                List<int> idList = new List<int>();
                foreach (var item in adaptor)
                {
                    if (!idList.Contains(item.AccountGroupId)) { idList.Add(item.AccountGroupId); }
                }

                List<AccountLedger> ledgerList = new List<AccountLedger>();
                foreach (var aGroupID in idList)
                {
                    var list = db.AccountLedgers.Where(x => x.ledgerName == strLedgerName && x.accountGroupID == aGroupID && x.billByBill == true).ToList();
                    ledgerList.AddRange(list);
                }

                isSundrycredit = (ledgerList.Count() > 0) ? true : false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isSundrycredit;
        }

        public bool AccountGroupIdCheck(string strLedgerName)
        {
            IMEEntities db = new IMEEntities();
            bool isSundryCreditOrDebit = false;
            try
            {
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Sundry Creditors" || x.accountGroupName == "Sundry Debtors")

                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                   hierarchyLevel = 1
                               }).ToList();
                List<int> IDs = adaptor.Select(x => x.AccountGroupId).ToList();
                int AccountGroupsID1 = IDs[0];
                int AccountGroupsID2 = IDs[1];
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == AccountGroupsID1 || x.groupUnder == AccountGroupsID2)
                                select new
                                {
                                    AccountGroupId = ag.accountGroupId,
                                    hierarchyLevel = 2
                                }).ToList();

                foreach (var item in adaptor2)
                {
                    if (!adaptor.Exists(x => x.AccountGroupId == item.AccountGroupId))
                    {
                        adaptor.Add(item);
                    }
                }

                List<int> idList = new List<int>();
                foreach (var item in adaptor)
                {
                    if (!idList.Contains(item.AccountGroupId)) { idList.Add(item.AccountGroupId); }
                }

                List<AccountLedger> ledgerList = new List<AccountLedger>();
                foreach (var aGroupID in idList)
                {
                    var list = db.AccountLedgers.Where(x => x.ledgerName == strLedgerName && x.accountGroupID == aGroupID && x.billByBill == true).ToList();
                    ledgerList.AddRange(list);
                }
                isSundryCreditOrDebit = (ledgerList.Count() > 0) ? true : false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isSundryCreditOrDebit;
        }

        public bool PDCReceivableReferenceCheck(decimal decPDCReceivableMasterId)
        {
            IMEEntities IME = new IMEEntities();
            bool isExist = false;
            try
            {
                var obj = (from rm in IME.PDCClearanceMasters.Where(r => r.againstId == decPDCReceivableMasterId)
                           select rm.againstId).ToList();

                if (obj != null)
                {
                    isExist = (obj.Count() > 0) ? true : false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return isExist;
        }

        public bool AccountGroupIdCheckSundryDeptor(string strLedgerName)
        {
            IMEEntities IME = new IMEEntities();
            bool isSundryDebit = false;
            try
            {
                var obj = (from rm in IME.AccountLedgers.Where(r => r.ledgerName == strLedgerName && r.AccountGroup.accountGroupName == "Sundry Debtors" && r.billByBill == true)
                           select rm.ledgerId).ToList();

                isSundryDebit = (obj.Count() > 0) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isSundryDebit;
        }

        public decimal CheckLedgerBalance(decimal decledgerId)
        {
            IMEEntities IME = new IMEEntities();
            decimal inBalance = 0;
            decimal inBalance1 = 0;
            decimal inBalance2 = 0;
            try
            {
                decimal? adapter = (from dn in IME.LedgerPostings.Where(p => p.ledgerId == decledgerId)
                                    select new { dn.debit }).Sum(x => x.debit);

                decimal? adapter2 = (from dn in IME.LedgerPostings.Where(p => p.ledgerId == decledgerId)
                                     select new { dn.credit }).Sum(x => x.credit);



                inBalance1 = (adapter != null) ? (decimal)adapter : 0;
                inBalance2 = (adapter2 != null) ? (decimal)adapter2 : 0;
                inBalance = inBalance1 - inBalance2;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return inBalance;
        }

        public DataTable AccountLedgerViewAllForComboBox()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.AccountLedgerViewAllForComboBox();

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("ledgerName");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
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

        public DataTable LedgerPopupSearch(String strledgername, String straccountgroupname, decimal decId1, decimal decId2)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl No", typeof(decimal));
            dtbl.Columns["Sl No"].AutoIncrement = true;
            dtbl.Columns["Sl No"].AutoIncrementSeed = 1;
            dtbl.Columns["Sl No"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.LedgerPopupSearch(strledgername, straccountgroupname, decId1, decId2);

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("Balance");
                dtbl.Columns.Add("accountGroupId");



                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerId"] = item.ledgerId;
                    row["ledgerName"] = item.ledgerName;
                    row["Balance"] = item.Balance;
                    row["accountGroupId"] = item.accountGroupId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable LedgerPopupSearchForServiceAccountsUnderIncome()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl No", typeof(decimal));
            dtbl.Columns["Sl No"].AutoIncrement = true;
            dtbl.Columns["Sl No"].AutoIncrementSeed = 1;
            dtbl.Columns["Sl No"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.AccountLedgerSearchForServiceAccountUnderIncome();

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("accountGroupId");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("Balance");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerId"] = item.ledgerId;
                    row["accountGroupId"] = item.accountGroupId;
                    row["ledgerName"] = item.ledgerName;
                    row["Balance"] = item.Balance;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public AccountLedger AccountLedgerView(decimal ledgerId)
        {
            IMEEntities db = new IMEEntities();
            AccountLedger accountledgerinfo = new AccountLedger();
            try
            {
                var a = db.AccountLedgerView(ledgerId).FirstOrDefault();

                accountledgerinfo.ledgerId = a.ledgerId;
                accountledgerinfo.accountGroupID = a.accountGroupId;
                accountledgerinfo.ledgerName = a.ledgerName;
                accountledgerinfo.openingBalance = a.openingBalance;
                accountledgerinfo.crOrDr = a.crOrDr;
                accountledgerinfo.narration = a.narration;
                accountledgerinfo.mailingName = a.mailingName;
                accountledgerinfo.address = a.address;
                accountledgerinfo.phone = a.phone;
                accountledgerinfo.mobile = a.mobile;
                accountledgerinfo.email = a.email;
                accountledgerinfo.creditPeriod = a.creditPeriod;
                accountledgerinfo.creditLimit = a.creditLimit;
                accountledgerinfo.pricinglevelId = a.pricinglevelId;
                accountledgerinfo.billByBill = a.billByBill;
                accountledgerinfo.tin = a.tin;
                accountledgerinfo.cst = a.cst;
                accountledgerinfo.pan = a.pan;
                accountledgerinfo.routeId = a.routeId;
                accountledgerinfo.bankAccountNumber = a.bankAccountNumber;
                accountledgerinfo.branchName = a.branchName;
                accountledgerinfo.branchCode = a.branchCode;
                accountledgerinfo.extraDate = a.extraDate;
                accountledgerinfo.areaId = a.areaId;
                accountledgerinfo.isDefault = a.isDefault;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return accountledgerinfo;
        }

        public decimal AccountLedgerIdGetByName(string strLedgerName)
        {
            decimal decLedgerId = 0;
            try
            {
                decLedgerId = Convert.ToDecimal(new IMEEntities().AccountLedgerIdGetByName(strLedgerName).FirstOrDefault());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decLedgerId;
        }

        public DataTable MultipleAccountLedgerComboFill()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.MultipleAccountLedgerComboFill();

                dtbl.Columns.Add("accountGroupId");
                dtbl.Columns.Add("accountGroupName");
                dtbl.Columns.Add("nature");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["nature"] = item.nature;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public decimal AccountLedgerAddWithIdentity(AccountLedger ac)
        {
            IMEEntities IME = new IMEEntities();
            decimal decLedgerId = 0;
            try
            {
                object obj = IME.AccountLedgerAddWithIdentity(
                    ac.accountGroupID,
                    ac.ledgerName,
                    ac.openingBalance,
                    ac.crOrDr,
                    ac.narration,
                    ac.mailingName,
                    ac.address,
                    ac.isDefault,
                    ac.phone,
                    ac.mobile,
                    ac.email,
                    ac.creditPeriod,
                    ac.creditLimit,
                    ac.pricinglevelId,
                    ac.billByBill,
                    ac.tin,
                    ac.cst,
                    ac.pan,
                    ac.routeId,
                    ac.bankAccountNumber,
                    ac.branchName,
                    ac.branchCode,
                    ac.areaId);

                if (obj != null)
                {
                    decLedgerId = decimal.Parse(obj.ToString());
                }
                else
                {
                    decLedgerId = 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decLedgerId;
        }

        public AccountLedger accountLedgerviewbyId(decimal ledgerId)
        {
            IMEEntities IME = new IMEEntities();
            AccountLedger accountledgerinfo = new AccountLedger();
            try
            {
                var a = IME.AccountLedgerView(ledgerId).FirstOrDefault();

                accountledgerinfo.ledgerId = a.ledgerId;
                accountledgerinfo.ledgerName = a.ledgerName;
                accountledgerinfo.creditPeriod = a.creditPeriod;
                accountledgerinfo.pricinglevelId = a.pricinglevelId;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return accountledgerinfo;
        }

        public DataTable AccountLedgerSearchForServiceAccountUnderIncome()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.AccountLedgerSearchForServiceAccountUnderIncome();

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("accountGroupId");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("Balance");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["ledgerId"] = item.ledgerId;
                    row["accountGroupId"] = item.accountGroupId;
                    row["ledgerName"] = item.ledgerName;
                    row["Balance"] = item.Balance;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable AccountLedgerViewAllByLedgerName(decimal decaccountGroupId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.AccountLedgerViewAllByLedgerName(decaccountGroupId);

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("accountGroupId");
                dtbl.Columns.Add("ledgerName");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["ledgerId"] = item.ledgerId;
                    row["accountGroupId"] = item.accountGroupId;
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

        public DataTable PartyAddressBookSearch(string strType, string strmobile, string strphone, string stremail, string strledgerName)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl No", typeof(int));
            dtbl.Columns["Sl No"].AutoIncrement = true;
            dtbl.Columns["Sl No"].AutoIncrementSeed = 1;
            dtbl.Columns["Sl No"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.PartyAddressBookSearch(strType, strmobile, strphone, stremail, strledgerName);

                dtbl.Columns.Add("accountGroupName");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("phone");
                dtbl.Columns.Add("mobile");
                dtbl.Columns.Add("email");
                dtbl.Columns.Add("address");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["accountGroupName"] = item.accountGroupName;
                    row["ledgerName"] = item.ledgerName;
                    row["phone"] = item.phone;
                    row["mobile"] = item.mobile;
                    row["email"] = item.email;
                    row["address"] = item.address;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        internal DataTable PartyAddressBookPrint(string strType, string strmobile, string strphone, string stremail, string strledgerName)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.PartyAddressBookPrint(strType, strmobile, strphone, stremail, strledgerName);

                dtbl.Columns.Add("accountGroupName");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("phone");
                dtbl.Columns.Add("mobile");
                dtbl.Columns.Add("email");
                dtbl.Columns.Add("address");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["accountGroupName"] = item.accountGroupName;
                    row["ledgerName"] = item.ledgerName;
                    row["phone"] = item.phone;
                    row["mobile"] = item.mobile;
                    row["email"] = item.email;
                    row["address"] = item.address;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable AccountLedgerViewByAccountGroup(decimal decAccounGroupId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.AccountLedgerViewByAccountGroup(decAccounGroupId);

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("ledgerName");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
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

        public DataTable AccountLedgerReportFill(DateTime dtFromDate, DateTime dtToDate, decimal decAccountGroupId, decimal decLedgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.AccountLedgerReportFill(dtFromDate, dtToDate, decAccountGroupId, decLedgerId);

                dtbl.Columns.Add("slNO");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("Opening");
                dtbl.Columns.Add("op");
                dtbl.Columns.Add("Debit");
                dtbl.Columns.Add("Credit");
                dtbl.Columns.Add("Closing");
                dtbl.Columns.Add("Closing1");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["slNO"] = item.slNO;
                    row["ledgerId"] = item.ledgerId;
                    row["ledgerName"] = item.ledgerName;
                    row["Opening"] = item.Opening;
                    row["op"] = item.op;
                    row["Debit"] = item.Debit;
                    row["Credit"] = item.Credit;
                    row["Closing"] = item.Closing;
                    row["Closing1"] = item.Closing1;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        /// <summary>
        /// Bill allocation ledger fill
        /// </summary>
        /// <param name="cmbAccountLedger"></param>
        /// <param name="strAccountGroup"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public DataTable BillAllocationLedgerFill(System.Windows.Forms.ComboBox cmbAccountLedger, string strAccountGroup, bool isAll)
        {
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = new IMEEntities().BillAllocationLedgerFill(strAccountGroup).ToList();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;

                    dtbl.Rows.Add(row);
                }

                if (isAll)
                {
                    DataRow dr = dtbl.NewRow();
                    dr["ledgerName"] = "All";
                    dr["ledgerId"] = 0;
                    dtbl.Rows.InsertAt(dr, 0);
                }
                cmbAccountLedger.DataSource = dtbl;
                cmbAccountLedger.DisplayMember = "ledgerName";
                cmbAccountLedger.ValueMember = "ledgerId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
    }
}
