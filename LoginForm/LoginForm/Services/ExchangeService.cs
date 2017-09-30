using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LoginForm.DataSet;

namespace LoginForm.Services
{
    class ExchangeService
    {
        public string GetExchangeRateforEuro()
        {

            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);



            string BuyEuro = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            string SellEuro = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;

            return SellEuro;
        }

        public ExchangeRate GetExchangeRateforDolar()
        {
            ExchangeRate RateForDolar = new ExchangeRate();
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            string Name = "USD";
            DateTime TodayDate = new DateTime();
            TodayDate = DateTime.Now.Date;
            string BuyUSDeffective = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            string SellUSDEffective = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string BuyUSD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexSelling").InnerXml;
            string SellUSD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexBuying").InnerXml;

            RateForDolar.Code = Name;
            RateForDolar.RateDate = TodayDate;
            RateForDolar.ExchangeBuy = BuyUSD;
            RateForDolar.ExchangeSell = SellUSD;
            RateForDolar.ExchangeBuyEffective = BuyUSDeffective;
            RateForDolar.ExchangeSellEffective = SellUSDEffective;
            return RateForDolar;
        }

        public string GetExchangeRateforSterlin()
        {

            return "deneme";
        }
    }
}
