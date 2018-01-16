using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class SalesReturnBillTaxSP
    {

        public DataTable TaxDetailsViewBySalesReturnMasterId(decimal decSalesReturnMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from sr in IME.SalesReturnBillTaxes
                               from t in IME.Taxes.Where(x => x.TaxID == sr.taxId).DefaultIfEmpty()
                               where sr.salesReturnMasterId == decSalesReturnMasterId
                               select new
                               {
                                   t.taxName,
                                   sr.taxAmount,
                                   sr.taxId,
                                   t.Rate
                               }).ToList();

                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("taxAmount");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("Rate");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["taxName"] = item.taxName;
                    row["taxAmount"] = item.taxAmount;
                    row["taxId"] = item.taxId;
                    row["Rate"] = item.Rate;


                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public void SalesReturnBillTaxDeleteBySalesReturnMasterId(decimal SalesReturnMasterId)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                SalesReturnBillTax lp = db.SalesReturnBillTaxes.Where(x => x.salesReturnMasterId==SalesReturnMasterId).FirstOrDefault();
                db.SalesReturnBillTaxes.Remove(lp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SalesReturnBillTaxAdd(SalesReturnBillTax salesreturnbilltaxinfo)
        {
            IMEEntities db = new IMEEntities();
            SalesReturnBillTax srd = salesreturnbilltaxinfo;
            try
            {
                db.SalesReturnBillTaxes.Add(srd);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
