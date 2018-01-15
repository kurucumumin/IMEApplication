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
    class PurchaseReturnDetailsSP
    {
        public decimal PurchaseReturnDetailsAddWithReturnIdentity(PurchaseReturnDetail purchasereturndetailsinfo)
        {
            IMEEntities db = new IMEEntities();
            PurchaseReturnDetail prm = purchasereturndetailsinfo;
            decimal decIdentity = 0;
            try
            {
                db.PurchaseReturnDetails.Add(prm);
                db.SaveChanges();
                decIdentity = prm.purchaseReturnDetailsId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public void PurchaseReturnDetailsEdit(PurchaseReturnDetail pi)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                PurchaseReturnDetail pdc = IME.PurchaseReturnDetails.Where(pd => pi.purchaseDetailsId == pd.purchaseDetailsId).FirstOrDefault();

                pdc.purchaseReturnDetailsId = pi.purchaseReturnDetailsId;
                pdc.purchaseReturnMasterId = pi.purchaseReturnMasterId;
                pdc.productId = pi.productId;
                pdc.qty = pi.qty;
                pdc.rate = pi.rate;
                pdc.unitId = pi.unitId;
                pdc.unitConversionId = pi.unitConversionId;
                pdc.discount = pi.discount;
                pdc.taxId = pi.taxId;
                pdc.batchId = pi.batchId;
                pdc.godownId = pi.godownId;
                pdc.rackId = pi.rackId;
                pdc.taxAmount =pi.taxAmount ;
                pdc.grossAmount=pi.grossAmount;
                pdc.netAmount = pi.netAmount;
                pdc.amount = pi.amount;
                pdc.slNo = pi.slNo;
                

                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal PurchaseReturnDetailsQtyViewByPurchaseDetailsId(decimal decPurchaseDetailsId)
        {
            decimal decQty = 0;
            object objQty = null;
            try
            {
                objQty = new IMEEntities().PurchaseReturnDetailsQtyViewByPurchaseDetailsId(decPurchaseDetailsId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decQty;
        }

        public void PurchaseReturnDetailsDelete(decimal PurchaseReturnDetailsId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.PurchaseReturnDetailsDelete(PurchaseReturnDetailsId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable PurchaseReturnDetailsViewByMasterId(decimal decPurchaseReturnMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor=IME.PurchaseReturnDetailsViewByMasterId(decPurchaseReturnMasterId);

                dtbl.Columns.Add("purchaseReturnDetailsId");
                dtbl.Columns.Add("slno");
                dtbl.Columns.Add("Article_No");
                dtbl.Columns.Add("Article_Desc");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("unitName");
                dtbl.Columns.Add("unitConversionId");
                dtbl.Columns.Add("rate");
                dtbl.Columns.Add("barcode");
                dtbl.Columns.Add("batchId");
                dtbl.Columns.Add("godownId");
                dtbl.Columns.Add("rackId");
                dtbl.Columns.Add("grossAmount");
                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("netAmount");
                dtbl.Columns.Add("taxAmount");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("purchaseReturnMasterId");
                dtbl.Columns.Add("amount");
                dtbl.Columns.Add("purchaseDetailsId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["purchaseReturnDetailsId"] = item.purchaseReturnDetailsId;
                    row["slno"] = item.slno;
                    row["Article_No"] = item.Article_No;
                    row["Article_Desc"] = item.Article_Desc;
                    row["qty"] = item.qty;
                    row["unitName"] = item.unitName;
                    row["unitConversionId"] = item.unitConversionId;
                    row["rate"] = item.rate;
                    row["barcode"] = item.barcode;
                    row["batchId"] = item.batchId;
                    row["godownId"] = item.godownId;
                    row["rackId"] = item.rackId;
                    row["grossAmount"] = item.grossAmount;
                    row["discount"] = item.discount;
                    row["netAmount"] = item.netAmount;
                    row["taxAmount"] = item.taxAmount;
                    row["taxId"] = item.taxId;
                    row["purchaseReturnMasterId"] = item.purchaseReturnMasterId;
                    row["amount"] = item.amount;
                    row["purchaseDetailsId"] = item.purchaseDetailsId;

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
