using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class CurrencySP
    {
        public Currency CurrencyView(decimal currencyId)
        {
            Currency currencyinfo = new Currency();
            try
            {
                currencyinfo = new IMEEntities().Currencies.Where(x => x.currencyID == currencyId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return currencyinfo;
        }
    }
}
