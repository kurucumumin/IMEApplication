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

        public decimal ExchangeRateViewByExchangeRateId(decimal decExchangeRateId)
        {
            IMEEntities db = new IMEEntities();
            decimal? exchangeRate = 0;
            try
            {
                decimal? excID = decExchangeRateId;
                if (db.ExchangeRateViewByExchangeRateId(decExchangeRateId)==null)
                {
                    exchangeRate = 0;
                }
                else
                {
                    exchangeRate = db.ExchangeRateViewByExchangeRateId(excID).FirstOrDefault();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return (decimal)exchangeRate;
        }

        /// <summary>
        /// Function to insert values to ExchangeRate Table
        /// </summary>
        /// <param name="exchangerateinfo"></param>
        public void ExchangeRateAdd(ExchangeRate exchangerateinfo)
        {
            try
            {
                new IMEEntities().ExchangeRateAdd(
                exchangerateinfo.currencyId,
                exchangerateinfo.date,
                exchangerateinfo.rate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Function to Update values in ExchangeRate Table
        /// </summary>
        /// <param name="exchangerateinfo"></param>
        public void ExchangeRateEdit(ExchangeRate exchangerateinfo)
        {
            try
            {
                new IMEEntities().ExchangeRateEdit(
                    exchangerateinfo.exchangeRateID,
                    exchangerateinfo.currencyId,
                    exchangerateinfo.date,
                    exchangerateinfo.rate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
