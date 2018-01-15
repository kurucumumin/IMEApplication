using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LoginForm.DataSet;

namespace LoginForm.Account.Services
{
    class StockPostingSP
    {
        public int StockCheckForProductSale(string decProductId)
        {
            int decStock = 0;
            IMEEntities IME = new IMEEntities();
            if (IME.Stocks.Where(a => a.ItemCode == decProductId).FirstOrDefault() != null) decStock = (int)IME.Stocks.Where(a => a.ItemCode == decProductId).FirstOrDefault().Quantitiy;
            return decStock;
        }

        public int StockCheckForProductSale(string decProductId, decimal decBatchId)
        {
            int decStock = 0;
            IMEEntities IME = new IMEEntities();
            decStock = (int)IME.Stocks.Where(a => a.ItemCode == decProductId).FirstOrDefault().Quantitiy;
            return decStock;
        }

    }
}
