using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class PurchaseReturnBilltaxSP
    {
        public void PurchaseReturnBilltaxAdd(PurchaseReturnBilltax purchasereturnbilltaxinfo)
        {
            IMEEntities db = new IMEEntities();
            PurchaseReturnBilltax srd = purchasereturnbilltaxinfo;
            try
            {
                db.PurchaseReturnBilltaxes.Add(srd);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
