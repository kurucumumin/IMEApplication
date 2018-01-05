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
    class ProductSP
    {
        public decimal SalesInvoiceProductRateForSales(decimal decProductId, DateTime dtdate, decimal decBatchId, decimal decPricingLevelId, decimal decNoofDecplaces)
        {
            decimal decRate = 0;
            IMEEntities IME = new IMEEntities();
            //TO DO SalesInvoiceProductRateForSales procedure ü eklenecek
            //var adaptor = 

            return decRate;
        }
    }
}
