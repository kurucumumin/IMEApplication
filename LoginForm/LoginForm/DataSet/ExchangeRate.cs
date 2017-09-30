using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.DataSet
{
    class ExchangeRate
    {
        public string Code { get; set; }
        public DateTime RateDate { get; set; }
        public string ExchangeBuy { get; set; }
        public string ExchangeSell { get; set; }
        public string ExchangeBuyEffective { get; set; }
        public string ExchangeSellEffective { get; set; }
    }
}
