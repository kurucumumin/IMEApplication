using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;


namespace LoginForm.Services
{
    class ChangeCurrency
    {
        public static decimal ChangeCurrencyToDefault(decimal CurrencyID,decimal Amount)
        {
            IMEEntities IME = new IMEEntities();
            //default currency Dirham
            decimal DefaultCurr = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName== "Dirham").OrderByDescending(a => a.date).FirstOrDefault().rate;
            decimal CurrValue= (decimal)IME.ExchangeRates.Where(a => a.currencyId == CurrencyID).OrderByDescending(a => a.date).FirstOrDefault().rate;
            decimal total = 0;
            total = (Amount / DefaultCurr) * CurrValue;
            return total;
        }
    }
}
