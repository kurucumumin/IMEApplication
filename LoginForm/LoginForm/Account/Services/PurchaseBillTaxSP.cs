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
    class PurchaseBillTaxSP
    {
        public DataTable PurchaseBillTaxViewAllByPurchaseMasterId(decimal decPurchaseMasterId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.PurchaseBillTaxViewAllByPurchaseMasterId(decPurchaseMasterId);

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

        public void PurchaseBillTaxAdd(PurchaseBillTax p)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PurchaseBillTaxAdd(
                    p.purchaseMasterId,
                    p.taxId,
                    p.taxAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void PurchaseBillTaxEdit(PurchaseBillTax p)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PurchaseBillTaxEdit(
                    p.purchaseBillTaxId,
                    p.purchaseMasterId,
                    p.taxId,
                    p.taxAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void PurchaseBillTaxDelete(decimal PurchaseBillTaxId)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PurchaseBillTaxDelete(PurchaseBillTaxId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
