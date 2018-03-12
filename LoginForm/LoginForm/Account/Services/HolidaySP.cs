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
    class HolidaySP
    {
        public decimal HolliDayChecking(DateTime date)
        {
            IMEEntities IME = new IMEEntities();
            decimal decResult = 0;
            try
            {
               if(IME.HolliDayChecking(date)!=null) decResult = Decimal.Parse( IME.HolliDayChecking(date).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decResult;
        }
    }
}
