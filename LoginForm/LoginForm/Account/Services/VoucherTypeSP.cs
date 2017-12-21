using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class VoucherTypeSP
    {
        public bool CheckMethodOfVoucherNumbering(decimal voucherTypeId)
        {
            VoucherType infoVoucherType = new VoucherType();
            bool isAutomatic = false;
            try
            {
                infoVoucherType.methodOfVoucherNumbering = new IMEEntities().VoucherTypes.Where(x => x.voucherTypeId == voucherTypeId).FirstOrDefault().methodOfVoucherNumbering;
                if (infoVoucherType.methodOfVoucherNumbering == "Automatic")
                {
                    isAutomatic = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isAutomatic;
        }
    }
}
