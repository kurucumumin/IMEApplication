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
    class PurchaseMasterSP
    {
        public DataTable PurchaseInvoicePurchaseAccountFill()
        {
            DataTable dtbl = new DataTable();
            try
            {
                IMEEntities db = new IMEEntities();
                var adaptor = db.PurchaseInvoicePurchaseAccountComboFill();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

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

    }
}
