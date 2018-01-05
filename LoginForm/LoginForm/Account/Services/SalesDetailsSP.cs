using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    class SalesDetailsSP
    {
        public DataTable BankOrCashComboFill()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Cash-in Hand" || x.accountGroupName == "Bank Account" || x.accountGroupName == "Bank OD A/C")
                               select new
                               {
                                   AccountGroupId = ag.accountGroupId,
                                   hierarchyLevel = 1
                               }).ToList();
                List<int> IDs = adaptor.Select(x => x.AccountGroupId).ToList();

                var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == IDs[0] || x.groupUnder == IDs[1] || x.groupUnder == IDs[2])
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

        public DataTable VoucherTypesBasedOnTypeOfVouchers(string typeOfVouchers)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            var VoucherType = IME.VoucherTypes.Where(a => a.typeOfVoucher == typeOfVouchers).ToList();
            dtbl.Columns.Add("voucherTypeId");
            dtbl.Columns.Add("voucherTypeName");
            dtbl.Columns.Add("typeOfVoucher");
            foreach (var item in VoucherType)
            {
                var row = dtbl.NewRow();
                row["voucherTypeId"] = item.voucherTypeId;
                row["voucherTypeName"] = item.voucherTypeName;
                row["typeOfVoucher"] = item.typeOfVoucher;
                dtbl.Rows.Add(row);
            }
            return dtbl;
        }

    }
}
