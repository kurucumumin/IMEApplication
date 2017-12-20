using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class TransactionsGeneralFill
    {
        public string VoucherNumberAutomaicGeneration(decimal VoucherTypeId, decimal txtBox, DateTime date, string tableName)
        {
            IMEEntities db = new IMEEntities();
            string strVoucherNo = string.Empty;
            try
            {
                //TODO Create VoucherNO and Return
                strVoucherNo = "12345";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strVoucherNo;
        }
    }
}
