using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LoginForm.DataSet;
namespace LoginForm
{
    class ServiceMasterSP
    {
        public DataTable SalesInvoiceSalesAccountModeComboFill()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            var AccountGroups = IME.AccountGroups.Where(a => a.groupUnder == IME.AccountGroups.Where(b => b.accountGroupName == "Sales Account").FirstOrDefault().accountGroupId).ToList();
            var adaptor = (from a in IME.AccountLedgers
                           from b in AccountGroups
                           where (a.accountGroupID== b.accountGroupId)

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

        public int ServiceMasterGetMax(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            int max = 0;
            try
            {
                max = Convert.ToInt32(IME.ServiceVoucherMasterMax(decVoucherTypeId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public bool ServiceVoucherCheckExistence(string strInvoiceNo, decimal voucherTypeId, decimal masterId)
        {
            IMEEntities IME = new IMEEntities();
            bool trueOrfalse = false;
            try
            {
                trueOrfalse= Convert.ToBoolean(IME.ServiceVoucherCheckExistence(strInvoiceNo, masterId, voucherTypeId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return trueOrfalse;
        }
    }
}
