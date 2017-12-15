using LoginForm.DataSet;
using System;
using System.Linq;
using System.Windows;

namespace LoginForm.Account.Services
{
    static class ExchangeRateSP
    {
        static public decimal ExchangerateViewByCurrencyId(decimal decCurrencyId)
        {
            IMEEntities db = new IMEEntities();

            decimal decExchangerateId = 0;
            try
            {
                decExchangerateId = Convert.ToDecimal(db.ExchangeRates.Where(x => x.currencyId == decCurrencyId).OrderByDescending(x => x.rate).FirstOrDefault());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decExchangerateId;
        }
    }
}
