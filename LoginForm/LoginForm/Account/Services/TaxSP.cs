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
    class TaxSP
    {
        public DataTable TaxViewAllByVoucherTypeId(decimal decVoucherTypeId)
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();
            var Taxes = (from a in IME.Taxes
                         from b in IME.VoucherTypeTaxes
                         from c in IME.AccountLedgers
                         where (a.TaxID == b.taxId) && (a.taxName == c.ledgerName) && (b.voucherTypeId == decVoucherTypeId) && (a.isActive == true)
                         select new
                         {
                             a.TaxID,
                             c.ledgerId,
                             a.taxName,
                             a.ApplicationOn,
                             a.CalculatingMode,
                             a.Rate
                         }).ToList();

            dtbl.Columns.Add("taxId");
            dtbl.Columns.Add("ledgerId");
            dtbl.Columns.Add("taxName");
            dtbl.Columns.Add("applicableOn");
            dtbl.Columns.Add("calculatingMode");
            dtbl.Columns.Add("rate");
            foreach (var item in Taxes)
            {
                var row = dtbl.NewRow();
                row["taxId"] = item.TaxID;
                row["ledgerId"] = item.ledgerId;
                row["taxName"] = item.taxName;
                row["applicableOn"] = item.ApplicationOn;
                row["calculatingMode"] = item.CalculatingMode;
                row["rate"] = item.Rate;
                dtbl.Rows.Add(row);
            }
            return dtbl;
        }

        public DataTable TaxViewAllByVoucherTypeIdApplicaleForProduct(decimal decVoucherTypeId)
        {
            DataTable dtbl = new DataTable();

            IMEEntities IME = new IMEEntities();

            var adaptor = (from TX in IME.Taxes
                           from VTX in IME.VoucherTypeTaxes
                           where (TX.TaxID==VTX.taxId)&& (VTX.voucherTypeId == decVoucherTypeId) && (TX.ApplicationOn == "Product")
                           && ( TX.isActive == true)
                           select new
                           {
                               TX.TaxID,
                               TX.taxName
                           }).ToList();

            dtbl.Columns.Add("TaxID");
            dtbl.Columns.Add("taxName");
            foreach (var item in adaptor)
            {
                var row = dtbl.NewRow();
                row["TaxID"] = item.TaxID;
                row["taxName"] = item.taxName;
                dtbl.Rows.Add(row);
            }

            return dtbl;
        }

        public DataTable TaxViewAllByVoucherTypeIdForPurchaseInvoice(decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.TaxViewAllByVoucherTypeIdForPurchaseInvoice(decVoucherTypeId);

                dtbl.Columns.Add("purchaseBillTaxId");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("ApplicationOn");
                dtbl.Columns.Add("calculatingMode");
                dtbl.Columns.Add("rate");
                dtbl.Columns.Add("taxAmount");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["purchaseBillTaxId"] = item.purchaseBillTaxId;
                    row["taxId"] = item.taxId;
                    row["ledgerId"] = item.ledgerId;
                    row["taxName"] = item.taxName;
                    row["ApplicationOn"] = item.ApplicationOn;
                    row["calculatingMode"] = item.calculatingMode;
                    row["rate"] = item.rate;
                    row["taxAmount"] = item.taxAmount;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public Tax TaxView(decimal taxId)
        {
            Tax taxinfo = new Tax();
            try
            {
                taxinfo = new IMEEntities().Taxes.Where(x => x.TaxID == taxId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return taxinfo;
        }
    }
}
