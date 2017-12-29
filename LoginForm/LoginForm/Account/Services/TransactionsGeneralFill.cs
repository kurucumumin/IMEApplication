﻿using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class TransactionsGeneralFill
    {
        public string VoucherNumberAutomaicGeneration(decimal VoucherTypeId, decimal txtBox, DateTime date, string tableName)
        {
            IMEEntities db = new IMEEntities();
            string strVoucherNo = string.Empty;
            try
            {
                //TODO Create VoucherNO and Return
                strVoucherNo = "12345";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strVoucherNo;
        }

        public DataTable SalesmanViewAllForComboFill(ComboBox cmbSalesMan, bool isAll)
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from w in db.Workers
                               from d in db.Designations.Where(x=> x.designationId==1 && x.designationId==w.designationId)
                                select new
                               {
                                   w.WorkerID,
                                   UserName = (w.UserName == "NA") ? "1" : w.UserName
                               }).ToList();

                dt.Columns.Add("WorkerID");
                dt.Columns.Add("UserName");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["WorkerID"] = item.WorkerID;
                    row["UserName"] = item.UserName;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return dt;
        }

        public DataTable CurrencyComboByDate(DateTime date)
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from c in db.Currencies
                               from e in db.ExchangeRates.Where(x => x.currencyId == c.currencyID)
                               where e.date==date || e.exchangeRateID==1
                               select new
                               {
                                   c.currencyName,
                                   c.currencySymbol,
                                   e.exchangeRateID
                               }).ToList();

                dt.Columns.Add("currencyName"+ "|" + "currencySymbol");
                dt.Columns.Add("exchangeRateID");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["currencyName" + "|" + "currencySymbol"] = item.currencyName+ "|" +item.currencySymbol;
                    row["exchangeRateID"] = item.exchangeRateID;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }

        public void CashOrBankComboFill(ComboBox cmbCashOrBank, bool isAll)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            List<AccountGroup> AccountGroupList = new List<AccountGroup>();
            AccountGroupList.Add(IME.AccountGroups.Where(a=>a.accountGroupName== "Cash -in Hand").FirstOrDefault());
            AccountGroupList.Add(IME.AccountGroups.Where(a => a.accountGroupName == "Bank Account").FirstOrDefault());
            AccountGroupList.Add(IME.AccountGroups.Where(a => a.accountGroupName == "Bank OD A/ C").FirstOrDefault());
                cmbCashOrBank.DataSource = IME.AccountLedgers.Where(a => a.AccountGroup.groupUnder == AccountGroupList[0].accountGroupId || a.AccountGroup.groupUnder == AccountGroupList[1].accountGroupId || a.AccountGroup.groupUnder == AccountGroupList[2].accountGroupId);
                cmbCashOrBank.ValueMember = "ledgerId";
                cmbCashOrBank.DisplayMember = "ledgerName";
                cmbCashOrBank.SelectedIndex = -1;
        }


        public void CashOrPartyComboFill(ComboBox cmbCashOrParty, bool isAll)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupId == 27 || x.accountGroupId == 22)
                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                   hierarchyLevel = 1
                               }).ToList();
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == 27 || x.groupUnder == 22)
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

                cmbCashOrParty.DataSource = dtbl;
                cmbCashOrParty.ValueMember = "AccountGroupId";
                cmbCashOrParty.DisplayMember = "AccountGroupName";
                cmbCashOrParty.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void CashOrPartyUnderSundryDrComboFill(ComboBox cmbCashOrParty, bool isAll)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupId == 27 || x.accountGroupId == 26)
                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                   hierarchyLevel = 1
                               }).ToList();
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == 27 || x.groupUnder == 26)
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

                cmbCashOrParty.DataSource = dtbl;
                cmbCashOrParty.ValueMember = "AccountGroupId";
                cmbCashOrParty.DisplayMember = "AccountGroupName";
                cmbCashOrParty.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
