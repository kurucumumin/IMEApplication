using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LoginForm.DataSet;
using LoginForm.Services;

namespace LoginForm.Account.Services
{
    class ProductSP
    {
        public decimal SalesInvoiceProductRateForSales(int currencyID)
        {
            //TODO check Again
            decimal decRate = 0;
            IMEEntities IME = new IMEEntities();
            decRate = (decimal)IME.ExchangeRates.Where(a=>a.currencyId== currencyID).OrderByDescending(a=>a.date).FirstOrDefault().rate;
            return decRate;
        }

        public DataTable ProductViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();

            var adaptor = IME.ArticleSelectAll();

            dt.Columns.Add("Article_Desc");
            dt.Columns.Add("Article_No");
            dt.Columns.Add("Unit_Measure");
            dt.Columns.Add("Standard_Weight");
            dt.Columns.Add("CofO");
            dt.Columns.Add("MPN");
            dt.Columns.Add("Manufacturer");
            dt.Columns.Add("Heigh");
            dt.Columns.Add("Width");
            dt.Columns.Add("Length");


            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["Article_Desc"] = item.Article_Desc;
                row["Article_No"] = item.Article_No;
                row["Unit_Measure"] = item.Unit_Measure;
                row["Standard_Weight"] = item.Standard_Weight;
                row["CofO"] = item.CofO;
                row["MPN"] = item.MPN;
                row["Manufacturer"] = item.Manufacturer;
                row["Heigh"] = item.Heigh;
                row["Width"] = item.Width;
                row["Length"] = item.Length;

                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
