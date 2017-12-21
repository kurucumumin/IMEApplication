using LoginForm.DataSet;
using System;
using System.Linq;
using System.Windows;

namespace LoginForm.Account.Services
{
    class ExchangeRateSP
    {
        public decimal ExchangerateViewByCurrencyId(decimal decCurrencyId)
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
        public decimal GetExchangeRateByExchangeRateId(decimal decExchangeRateId)
        {
            IMEEntities db = new IMEEntities();
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (decimal)db.ExchangeRates.Where(x => x.exchangeRateID == decExchangeRateId).FirstOrDefault().rate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decReturnValue;
        }
    }
}
