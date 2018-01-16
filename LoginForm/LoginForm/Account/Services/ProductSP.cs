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

        public ProductInfo ProductView(string productId)
        {
            IMEEntities db = new IMEEntities();
            ProductInfo productinfo = new ProductInfo();
            
            try
            {
                var p = db.ProductView(productId);

                productinfo.ProductCode = p.Article_No;
                productinfo.ProductName = p.Article_Desc;
                //productinfo.Mrp = Convert.ToDecimal(sdrreader[12].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return productinfo;
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
