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
    class AccountGroupSP
    {

        public DataTable AccountGroupViewAllComboFillForAccountLedger()
        {
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = new IMEEntities().AccountGroupViewAllComboFillForAccountLedger().ToList();

                dtbl.Columns.Add("accountGroupId");
                dtbl.Columns.Add("accountGroupName");
                dtbl.Columns.Add("groupUnder");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("isDefault");
                dtbl.Columns.Add("nature");
                dtbl.Columns.Add("affectGrossProfit");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["groupUnder"] = item.groupUnder;
                    row["narration"] = item.narration;
                    row["isDefault"] = item.isDefault;
                    row["nature"] = item.nature;
                    row["affectGrossProfit"] = item.affectGrossProfit;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public decimal AccountGroupAddWithIdentity(AccountGroup a)
        {
            decimal decAccountGroupId = 0;
            try
            {
                object obj = new IMEEntities().AccountGroupAddWithIdentity
                    (a.accountGroupName,
                    a.groupUnder.ToString(),
                    a.narration,
                    a.isDefault,
                    a.nature,
                    a.affectGrossProfit);
                if (obj != null)
                {
                    decAccountGroupId = decimal.Parse(obj.ToString());
                }
                else
                {
                    decAccountGroupId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decAccountGroupId;
        }

        public bool AccountGroupUpdate(AccountGroup a)
        {
            bool isEdit = false;
            try
            {

                int inAffectedRows = new IMEEntities().AccountGroupEdit(a.accountGroupId,
                    a.accountGroupName,
                    a.groupUnder.ToString(),
                    a.narration,
                    a.isDefault,
                    a.nature,
                    a.affectGrossProfit);
                if (inAffectedRows > 0)
                {
                    isEdit = true;
                }
                else
                {
                    isEdit = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isEdit;
        }

        //public bool AccountGroupwithLedgerId(decimal decLedgerId)
        //{
        //    IMEEntities IME = new IMEEntities();
        //    int accountgroupID = IME.AccountGroups.Where(a => a.accountGroupName.Contains("Bank Account")).FirstOrDefault().accountGroupId;
        //    if (IME.AccountLedgers.Where(a => a.ledgerId == decLedgerId).Where(b => b.accountGroupID == accountgroupID) != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        public DataTable AccountGroupViewAllComboFill()
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from ac in db.AccountGroups.OrderBy(x => x.accountGroupName)
                               select new
                               {
                                   ac.accountGroupId,
                                   ac.accountGroupName,
                                   ac.groupUnder,
                                   ac.narration,
                                   ac.isDefault,
                                   ac.nature,
                                   ac.affectGrossProfit
                               }).ToList();

                dt.Columns.Add("accountGroupId");
                dt.Columns.Add("accountGroupName");
                dt.Columns.Add("groupUnder");
                dt.Columns.Add("narration");
                dt.Columns.Add("isDefault");
                dt.Columns.Add("nature");
                dt.Columns.Add("affectGrossProfit");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["groupUnder"] = item.groupUnder;
                    row["narration"] = item.narration;
                    row["isDefault"] = item.isDefault;
                    row["nature"] = item.nature;
                    row["affectGrossProfit"] = item.affectGrossProfit;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }

        public bool AccountGroupwithLedgerId(decimal decLedgerId)
        {
            IMEEntities db = new IMEEntities();
            bool isExist = false;
            try
            {
                decimal groupId = db.AccountGroups.Where(x => x.accountGroupName.Contains("Bank Account")).Select(x=>x.accountGroupId).FirstOrDefault();

                var adaptor = db.AccountLedgers.Where(x => x.ledgerId == decLedgerId && x.accountGroupID == groupId).ToList();

                isExist = (adaptor.Count() > 0) ? true : false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("AGSP :2" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isExist;
        }

        public DataTable GroupNameViewForComboFill()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.GroupNameViewForComboFill();

                dtbl.Columns.Add("accountGroupId");
                dtbl.Columns.Add("accountGroupName");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public AccountGroup AccountGroupViewForUpdate(decimal decAccountGroupId)
        {
            AccountGroup accountgroupinfo = new AccountGroup();
            try
            {
                var a = new IMEEntities().AccountGroupViewForUpdate(decAccountGroupId).FirstOrDefault();

                accountgroupinfo.accountGroupId = a.accountGroupId;
                accountgroupinfo.accountGroupName = a.accountGroupName;
                accountgroupinfo.groupUnder = a.groupUnder;
                accountgroupinfo.narration = a.narration;
                accountgroupinfo.isDefault = a.isDefault;
                accountgroupinfo.nature = a.nature;
                accountgroupinfo.affectGrossProfit = a.affectGrossProfit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return accountgroupinfo;
        }

        public bool AccountGroupCheckExistenceOfUnderGroup(decimal decAccountGroupId)
        {
            bool isDelete = false;
            try
            {
                var obj = new IMEEntities().AccountGroupCheckExistenceOfUnderGroup(decAccountGroupId).FirstOrDefault();
                if (obj != null)
                {
                    if (int.Parse(obj.ToString()) == 1)
                    {
                        isDelete = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isDelete;
        }

        public string AccountGroupNatureUnderGroup(decimal decAccountGroupId)
        {
            string strNature = string.Empty;
            try
            {
                strNature = new IMEEntities().AccountGroupNatureUnderGroup(decAccountGroupId).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strNature;
        }

        public decimal AccountGroupReferenceDelete(decimal AccountGroupId)
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = Convert.ToDecimal(new IMEEntities().AccountGroupReferenceDelete(AccountGroupId).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decReturnValue;
        }

        public AccountGroup AccountGroupView(decimal accountGroupId)
        {
            AccountGroup accountgroupinfo = new AccountGroup();
            try
            {
                var adaptor = new IMEEntities().AccountGroupView(accountGroupId).FirstOrDefault();

                accountgroupinfo.accountGroupId = adaptor.accountGroupId;
                accountgroupinfo.accountGroupName = adaptor.accountGroupName;
                accountgroupinfo.groupUnder = adaptor.groupUnder;
                accountgroupinfo.narration = adaptor.narration;
                accountgroupinfo.isDefault = adaptor.isDefault;
                accountgroupinfo.nature = adaptor.nature;
                accountgroupinfo.affectGrossProfit = adaptor.affectGrossProfit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return accountgroupinfo;
        }

        public DataTable AccountGroupSearch(string strAccountGroupName, string strGroupUnder)
        {
            DataTable dtblAccountGroup = new DataTable();
            dtblAccountGroup.Columns.Add("Sl No", typeof(int));
            dtblAccountGroup.Columns["Sl No"].AutoIncrement = true;
            dtblAccountGroup.Columns["Sl No"].AutoIncrementSeed = 1;
            dtblAccountGroup.Columns["Sl No"].AutoIncrementStep = 1;

            dtblAccountGroup.Columns.Add("AccountGroupId");
            dtblAccountGroup.Columns.Add("AccountGroupName");
            dtblAccountGroup.Columns.Add("Under");

            try
            {
                var adaptor = new IMEEntities().AccountGroupSearch(strAccountGroupName, strGroupUnder).ToList();

                foreach (var item in adaptor)
                {
                    DataRow row = dtblAccountGroup.NewRow();

                    row["AccountGroupId"] = item.AccountGroupId;
                    row["AccountGroupName"] = item.AccountGroupName;
                    row["Under"] = item.Under;

                    dtblAccountGroup.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblAccountGroup;
        }

        public string MultipleAccountLedgerCrOrDr(string strAccountGroup)
        {
            IMEEntities IME = new IMEEntities();
            string strNature = string.Empty;
            try
            {
                strNature = IME.MultipleAccountLedgerCrOrDr(strAccountGroup).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strNature;
        }

        public DataTable AccountGroupViewAllByGroupUnder(decimal decaccountGroupId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.AccountGroupViewAllByGroupUnder(decaccountGroupId).ToList();

                dtbl.Columns.Add("accountGroupId");
                dtbl.Columns.Add("accountGroupName");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable AccountGroupReportFill(DateTime dtmFromDate, DateTime dtmToDate)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = IME.AccountGroupReportViewAll(dtmFromDate,dtmToDate).ToList();

                dt.Columns.Add("accountGroupId");
                dt.Columns.Add("accountGroupName");
                dt.Columns.Add("debit");
                dt.Columns.Add("credit");
                dt.Columns.Add("nature");
                dt.Columns.Add("affectGrossProfit");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["debit"] = item.debit;
                    row["credit"] = item.credit;

                    dt.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("AGSP :3" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dt;
        }
    }
}
