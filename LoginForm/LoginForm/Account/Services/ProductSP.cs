using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
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

            dt.Columns.Add("productName");
            dt.Columns.Add("productCode");
            dt.Columns.Add("Unit_Measure");
            dt.Columns.Add("Standard_Weight");
            dt.Columns.Add("CofO");
            dt.Columns.Add("MPN");
            dt.Columns.Add("Manufacturer");
            dt.Columns.Add("Heigh");
            dt.Columns.Add("Width");
            dt.Columns.Add("Length");
            string a;
            try
            {
                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();
                    if(item.Article_No== "2550043343")
                    {

                    }
                    row["productName"] = item.Article_Desc;
                     row["productCode"] = item.Article_No;
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
            }
            catch(Exception e) { }
            return dt;
        }

        public string ProductCodeViewByProductName(string productName)
        {
            IMEEntities IME = new IMEEntities();
            string productCode = string.Empty;
            try
            {
                productCode = (from a in IME.ProductViewAll()
                               where a.Article_Desc == productName
                               select new { a.Article_No }).FirstOrDefault().Article_No;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return productCode;
        }

        public DataTable ProductCodeViewByProductName(string productName, decimal vouchertypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                // TODO buradaki prosedure de tax dikkate alınmadı buna sonra tekrar bakılacak
                var adaptor = IME.productviewbyproductNameforSR(productName);

                dtbl.Columns.Add("Article_No");
                dtbl.Columns.Add("Article_Desc");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("discountPercent");
                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("netvalue");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("taxAmount");
                dtbl.Columns.Add("amount");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Article_No"] = item.Article_No;
                    row["Article_Desc"] = item.Article_Desc;
                    row["qty"] = item.qty;
                    row["discountPercent"] = item.discountPercent;
                    row["discount"] = item.discount;
                    row["netvalue"] = item.netvalue;
                    row["taxId"] = item.taxId;
                    row["taxAmount"] = item.taxAmount;
                    row["amount"] = item.amount;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable ProductNameViewByProductCode(string productCode, decimal decProductcode)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();

            try
            {
                // TODO buradaki prosedure de tax dikkate alınmadı buna sonra tekrar bakılacak
                var adaptor = IME.productviewbyproductcodeforSR(productCode);

                dtbl.Columns.Add("Article_No");
                dtbl.Columns.Add("Article_Desc");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("discountPercent");
                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("netvalue");
                dtbl.Columns.Add("taxAmount");
                dtbl.Columns.Add("amount");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Article_No"] = item.Article_No;

                    //row["barcode"] = item.barcode;
                    row["Article_Desc"] = item.Article_Desc;
                    row["qty"] = item.qty;
                    //row["unitConversionId"] = item.unitConversionId;
                    //row["conversionRate"] = item.conversionRate;
                    //row["batchId"] = item.batchId;
                    row["discountPercent"] = item.discountPercent;
                    row["discount"] = item.discount;
                    row["netvalue"] = item.netvalue;
                    //row["taxId"] = item.taxId;
                    row["taxAmount"] = item.taxAmount;
                    row["amount"] = item.amount;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }

        public ProductInfo ProductViewByCode(string strproductCode)
        {
            IMEEntities IME = new IMEEntities();
            ProductInfo productinfo = new ProductInfo();

            try
            {

                var a =IME.ProductViewByCode(strproductCode).FirstOrDefault();
                productinfo.ProductCode = a.Article_No;
                productinfo.ProductName = a.Article_Desc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return productinfo;
        }

        public string BarcodeViewByBatchId(decimal decbatchId)
        {
            IMEEntities IME = new IMEEntities();
            string strBatchId = string.Empty;
            try
            {
                strBatchId = IME.BarcodeViewByBatchId(decbatchId).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strBatchId;
        }

        public ProductInfo ProductViewByName(string strproductName)
        {
            IMEEntities IME = new IMEEntities();
            ProductInfo productinfo = new ProductInfo();

            try
            {
                var a = IME.ProductViewByName(strproductName).FirstOrDefault();
                productinfo.ProductCode = a.Article_No;
                productinfo.ProductName = a.Article_Desc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return productinfo;
        }

        public decimal BatchIdByPartNoOrBarcode(string strpartNo, string strbarcode)
        {
            IMEEntities IME = new IMEEntities();
            decimal decBatchId = 0;
            try
            {
                decBatchId = Convert.ToDecimal(IME.ProductViewByPartNoOrBarcode(strpartNo, strbarcode));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decBatchId;
        }

        public DataTable ProductCodeAndBarcodeByBatchId(decimal decProductBatchId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
               var adaptor= IME.ProductCodeAndBarcodeByBatchId(decProductBatchId);


                dtbl.Columns.Add("Article_No");
                dtbl.Columns.Add("barcode");
                dtbl.Columns.Add("PartNo");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Article_No"] = item.Article_No;
                    row["barcode"] = item.barcode;
                    row["PartNo"] = item.PartNo;


                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

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
                var p = db.ProductView(productId).FirstOrDefault();

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

        public DataTable ProductViewAllForComboBox()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (IME.ProductViewAllForComboBox()).ToList();

                dtbl.Columns.Add("Article_No");
                dtbl.Columns.Add("Article_Desc");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Article_No"] = item.Article_No;
                    row["Article_Desc"] = item.Article_Desc;


                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
    }
}
