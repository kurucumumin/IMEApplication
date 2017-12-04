using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.DataSet
{
    class classExchangeRate
    {
        public string Code { get; set; }
        public DateTime RateDate { get; set; }
        public decimal ExchangeBuy { get; set; }
        public decimal ExchangeSell { get; set; }
        public decimal ExchangeBuyEffective { get; set; }
        public decimal ExchangeSellEffective { get; set; }
    }
}
