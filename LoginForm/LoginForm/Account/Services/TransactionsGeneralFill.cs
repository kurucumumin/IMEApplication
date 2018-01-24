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
    class TransactionsGeneralFill
    {
        public DataTable PricingLevelViewAll(ComboBox cmbPricingLevel, bool isAll)
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = (from w in db.PricingLevels
                           select new
                           {
                               w.pricinglevelId,
                               UserName = (w.pricinglevelName == "NA") ? "1" : w.pricinglevelName
                           }).ToList();
            dt.Columns.Add("WorkerID");
            dt.Columns.Add("UserName");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();

                row["WorkerID"] = item.pricinglevelId;
                row["UserName"] = item.UserName;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public string VoucherNumberAutomaicGeneration(decimal VoucherTypeId, decimal txtBox, DateTime date, string tableName)
        {
            IMEEntities db = new IMEEntities();
            string strVoucherNo = string.Empty;
            try
            {
                strVoucherNo = db.VoucherNumberAutomaicGeneration(VoucherTypeId, date, tableName, txtBox).ToString();
                if (strVoucherNo == "System.Data.Entity.Core.Objects.ObjectResult`1[System.Nullable`1[System.Decimal]]")
                {
                    strVoucherNo = "0";
                }
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
                               from d in db.Designations.Where(x=> x.designationName== "Sale" && x.designationId==w.designationId)
                                select new
                               {
                                   w.WorkerID,
                                    NameLastName = (w.NameLastName == "NA") ? "1" : w.NameLastName
                                }).ToList();

                dt.Columns.Add("WorkerID");
                dt.Columns.Add("NameLastName");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["WorkerID"] = item.WorkerID;
                    row["NameLastName"] = item.NameLastName;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmbSalesMan.DataSource = dt;
            cmbSalesMan.ValueMember = "WorkerID";
            cmbSalesMan.DisplayMember = "NameLastName";
            return dt;


        }

        public DataTable CurrencyComboByDate(DateTime date)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.CurrencyComboByDate(date).ToList();

                dtbl.Columns.Add("currencyName");
                dtbl.Columns.Add("exchangeRateId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["currencyName"] = item.currencyName;
                    row["exchangeRateId"] = item.exchangeRateId;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        //public DataTable PricingLevelViewAll(ComboBox cmbPricingLevel, bool isAll)
        //{
        //    IMEEntities IME = new IMEEntities();
        //    DataTable dtbl = new DataTable();
        //    try
        //    {
        //        var adaptor = (from a in IME.PricingLevels
        //                       select new
        //                       {
        //                           a.pricinglevelId,a.pricinglevelName
        //                       }).ToList();

        //        dtbl.Columns.Add("pricinglevelId");
        //        dtbl.Columns.Add("pricinglevelName");
        //        cmbPricingLevel.DataSource = dtbl;
        //        cmbPricingLevel.DisplayMember = "pricinglevelName";
        //        cmbPricingLevel.ValueMember = "pricinglevelId";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return dtbl;
        //}

        public void CashOrBankComboFill(ComboBox cmbCashOrBank, bool isAll)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            List<AccountGroup> AccountGroupList = new List<AccountGroup>();

            var adaptor = (from ag in IME.AccountGroups
                           where ((ag.accountGroupName == "Cash-in Hand") || (ag.accountGroupName == "Bank Account") || (ag.accountGroupName == "Bank OD A/C")) || (ag.groupUnder == ag.accountGroupId)
                           select new
                           {
                               ag.accountGroupId,
                               //LedgerName = ag.ledgerName,
                               //LedgerId=ag.ledgerId
                           }).ToList();

            List<AccountLedger> alList = new List<AccountLedger>();

            foreach (var item in adaptor)
            {
                alList.AddRange(IME.AccountLedgers.Where(a => a.accountGroupID == item.accountGroupId));
            }
            dtbl.Columns.Add("LedgerName");
            dtbl.Columns.Add("LedgerId");
            foreach (var item in alList)
            {
                var row = dtbl.NewRow();
                row["LedgerName"] = item.ledgerName;
                row["LedgerId"] = item.ledgerId;
                dtbl.Rows.Add(row);
            }


            cmbCashOrBank.DataSource = dtbl;
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
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Cash-in Hand" || x.accountGroupName == "Sundry Creditors")
                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                    ag.accountGroupName,
                                   hierarchyLevel = 1
                               }).ToList();
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Cash-in Hand" || x.accountGroupName == "Sundry Creditors")
                                select new
                                {
                                    AccountGroupId = ag.accountGroupId,
                                    ag.accountGroupName,
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
                dtbl.Columns.Add("accountGroupName");
                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["AccountGroupId"] = item.AccountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    dtbl.Rows.Add(row);
                }

                cmbCashOrParty.DataSource = dtbl;
                cmbCashOrParty.ValueMember = "AccountGroupId";
                cmbCashOrParty.DisplayMember = "accountGroupName";
                cmbCashOrParty.SelectedIndex = 0;
           
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
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Cash -in Hand" || x.accountGroupName == "Sundry Debtors")
                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                   AccountGroupName = ag.accountGroupName,
                                   hierarchyLevel = 1
                               }).ToList();
                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Cash -in Hand" || x.accountGroupName == "Sundry Debtors")
                                select new
                                {
                                    AccountGroupId = ag.accountGroupId,
                                    AccountGroupName = ag.accountGroupName,
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
                dtbl.Columns.Add("AccountGroupName");
                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["AccountGroupId"] = item.AccountGroupId;
                    row["AccountGroupName"] = item.AccountGroupName;
                    dtbl.Rows.Add(row);
                }

                cmbCashOrParty.DataSource = dtbl;
                cmbCashOrParty.ValueMember = "AccountGroupId";
                cmbCashOrParty.DisplayMember = "AccountGroupName";
                cmbCashOrParty.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Function to fill All cash/Bank ledgers for Combobox
        /// </summary>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public DataTable BankOrCashComboFill(bool isAll)
        {
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = new IMEEntities().CashOrBankComboFill().ToList();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

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

        public bool StatusOfPrintAfterSave()
        {
            IMEEntities IME = new IMEEntities();
            string strStatus = "";
            bool isTrue = false;
            try
            {

                strStatus = IME.Settings.Where(x => x.settingsName == "TickPrintAfterSave").FirstOrDefault().settingsName;

                isTrue = (strStatus==null) ? false : true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isTrue;
        }

        public void SalesAccountComboFill(ComboBox cmbSalesAccount, bool isAll)
        {
            IMEEntities IME = new IMEEntities();

            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.SalesAccountComboFill();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;

                    dtbl.Rows.Add(row);
                }
                cmbSalesAccount.DataSource = dtbl;
                cmbSalesAccount.ValueMember = "ledgerId";
                cmbSalesAccount.DisplayMember = "ledgerName";
                cmbSalesAccount.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                //return isTrue;
            }

        public DataTable AccountLedgerComboFill()
        {
            DataTable dtbl = new DataTable();
            try
            {
                AccountLedgerSP spaccountledger = new AccountLedgerSP();
                dtbl = spaccountledger.AccountLedgerViewAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TGF:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        //public bool StatusOfPrintAfterSave()
        //{
        //    IMEEntities db = new IMEEntities();
        //    string strStatus = "";
        //    bool isTrue = false;
        //    try
        //    {
        //        strStatus = db.PrintAfterSave();
        //        if (strStatus == "Yes")
        //        {
        //            isTrue = true;
        //        }
        //        else
        //        {
        //            isTrue = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return isTrue;
        //}
    }

}
