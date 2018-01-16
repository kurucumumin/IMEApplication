using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class PurchaseReturnDetailsSP
    {
        public decimal PurchaseReturnDetailsQtyViewByPurchaseDetailsId(decimal decPurchaseDetailsId)
        {
            decimal decQty = 0;
            object objQty = null;
            try
            {
                objQty = new IMEEntities().PurchaseReturnDetailsQtyViewByPurchaseDetailsId(decPurchaseDetailsId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decQty;
        }
    }
}
