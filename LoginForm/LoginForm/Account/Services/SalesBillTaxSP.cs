using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;


namespace LoginForm.Account.Services
{
    class SalesBillTaxSP
    {
        public void SalesBillTaxEditBySalesMasterIdAndTaxId(SalesBillTax salesbilltaxinfo)
        {
            IMEEntities IME = new IMEEntities();
            IME.SalesBillTaxEditBySalesMasterIdAndTaxId(salesbilltaxinfo.salesMasterId, salesbilltaxinfo.taxId, salesbilltaxinfo.taxAmount,null,null,null);
        }

        public DataTable SalesInvoiceSalesBillTaxViewAllBySalesMasterId(decimal dcSalesmasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = IME.SalesInvoiceSalesBillTaxViewAllBySalesMasterId(dcSalesmasterId);
            dt.Columns.Add("taxId");
            dt.Columns.Add("ledgerId");
            dt.Columns.Add("taxName");
            dt.Columns.Add("ApplicationOn");
            dt.Columns.Add("calculatingMode");
            dt.Columns.Add("rate");
            dt.Columns.Add("taxAmount");
            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["taxId"] = item.taxId;
                row["ledgerId"] = item.ledgerId;
                row["taxName"] = item.taxName;
                row["ApplicationOn"] = item.ApplicationOn;
                row["calculatingMode"] = item.calculatingMode;
                row["rate"] = item.rate;
                row["taxAmount"] = item.taxAmount;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public decimal SalesBillTaxAdd(SalesBillTaxInfo salesbilltaxinfo)
        {
            decimal dcSalesBillTaxId = 0;
            IMEEntities IME = new IMEEntities();
            SalesBillTax sbt = new SalesBillTax();
            sbt.taxId= salesbilltaxinfo.TaxId;
            sbt.taxAmount = salesbilltaxinfo.TaxAmount;
            sbt.salesMasterId = salesbilltaxinfo.SalesMasterId;
            IME.SalesBillTaxes.Add(sbt);
            dcSalesBillTaxId = sbt.salesBillTaxId;
            return dcSalesBillTaxId;
        }
    }
}
