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
    class SalesOrderDetailsSP
    {
        public DataTable SalesInvoiceGridfillAgainestSalesOrderUsingSalesDetails(decimal decSalesOrderMasterId, decimal salesMasterId, decimal voucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();

            try
            {

                var adaptor = (IME.SalesInvoiceGridfillAgainestSalesOrderUsingSalesDetails(decSalesOrderMasterId, salesMasterId, voucherTypeId)).ToList();

                dtbl.Columns.Add("ID");
                dtbl.Columns.Add("SaleOrderID");
                dtbl.Columns.Add("ItemCode");
                dtbl.Columns.Add("unitName");
                dtbl.Columns.Add("Article_No");
                dtbl.Columns.Add("Article_Desc");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("currencyId");
                dtbl.Columns.Add("unitConversionId");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("conversionRate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ID"] = item.ID;
                    row["SaleOrderID"] = item.SaleOrderID;
                    row["ItemCode"] = item.ItemCode;
                    row["unitName"] = item.unitName;
                    row["Article_No"] = item.Article_No;
                    row["Article_Desc"] = item.Article_Desc;
                    row["qty"] = item.qty;
                    row["currencyId"] = item.currencyId;
                    row["unitConversionId"] = item.unitConversionId;
                    row["taxId"] = item.taxId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["conversionRate"] = item.conversionRate;


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
