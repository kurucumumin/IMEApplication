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
        public List<AccountGroup> AccountGroupViewAllComboFillForAccountLedger()
        {
            IMEEntities db = new IMEEntities();
            List<AccountGroup> list = new List<AccountGroup>();
            try
            {
                list = db.AccountGroups.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return list;
        }

        //public bool AccountGroupwithLedgerId(decimal decLedgerId)
        //{
        //    IMEEntities IME = new IMEEntities();
        //    int accountgroupID = IME.AccountGroups.Where(a => a.accountGroupName.Contains("Bank Account")).FirstOrDefault().accountGroupId;
        //    if(IME.AccountLedgers.Where(a=>a.ledgerId== decLedgerId).Where(b=>b.accountGroupID==accountgroupID) !=null)
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
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from ac in IME.AccountGroups
                               select new
                               {
                                   ac.accountGroupId,
                                   ac.accountGroupName
                               }).ToList();

                dt.Columns.Add("accountGroupId");
                dt.Columns.Add("accountGroupName");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
    }
}
