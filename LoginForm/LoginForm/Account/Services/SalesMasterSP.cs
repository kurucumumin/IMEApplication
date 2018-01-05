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
    class SalesMasterSP
    {

        public DataTable SalesInvoiceSalesAccountModeComboFill()
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();

            var AccountGroups = IME.AccountGroups.Where(a => a.groupUnder == IME.AccountGroups.Where(b => b.accountGroupName == "Sales Account").FirstOrDefault().accountGroupId).ToList();
            var adaptor = (from a in IME.AccountLedgers
                           from b in AccountGroups
                           where (a.accountGroupID == b.accountGroupId)

                           select new
                           {
                               ledgerName = a.ledgerName,
                               ledgerId = a.ledgerId

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

        public decimal SalesMasterVoucherMax(decimal decVoucherTypeId)
        {
            decimal decVoucherNoMax = 0;
            IMEEntities IME = new IMEEntities();
            decVoucherNoMax = (decimal)IME.SaleOrders.Where(a => a.VoucherTypeId == decVoucherTypeId).OrderByDescending(a => a.VoucherNo).FirstOrDefault().VoucherNo;
            return decVoucherNoMax;
        }
    }
}
