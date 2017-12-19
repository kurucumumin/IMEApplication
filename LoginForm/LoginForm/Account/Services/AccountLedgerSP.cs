﻿using LoginForm.DataSet;
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

        public void AccountLedgerEdit(AccountLedger accountledgerinfo)
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

        public void LedgerPostingDeleteByVoucherTypeAndVoucherNo(string strVocuherNumber, decimal decvoucherTypeId)
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
        public void PartyBalanceDeleteByVoucherTypeVoucherNoAndReferenceType(string strVocuherNumber, decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            PartyBalance pb = db.PartyBalances.Where(x=>x.voucherNo == strVocuherNumber && x.voucherTypeId == decVoucherTypeId && x.referenceType == "New").FirstOrDefault();
            try
            {
                db.PartyBalances.Remove(pb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable AccountLedgerSearch(String straccountgroupname, String strledgername)
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
                                   openingBalance = Math.Round((decimal)al.openingBalance, 2),
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
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupId == 22 || x.accountGroupId == 26)
                                select new
                                {
                                    AccountGroupId = ag.accountGroupId,
                                    hierarchyLevel = 1
                               }).ToList();
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == 22 || x.groupUnder == 26)
                                select new
                                {
                                    AccountGroupId = ag.accountGroupId,
                                    hierarchyLevel = 2
                                }).ToList();

                foreach (var item in adaptor2)
                {
                    if(!adaptor.Exists(x=>x.AccountGroupId == item.AccountGroupId))
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
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupId == 17 || x.accountGroupId == 28)
                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                   hierarchyLevel = 1
                               }).ToList();
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == 17 || x.groupUnder == 28)
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
                }else if (strNature == "Liabilities" || strNature == "Income")
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
                                   al.branchCode,
                                   al.extraDate
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
                dtbl.Columns.Add("extraDate");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
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
                    row["extraDate"] = item.extraDate;

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