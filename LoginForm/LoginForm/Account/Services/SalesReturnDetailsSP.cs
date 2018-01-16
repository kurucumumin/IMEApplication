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
    class SalesReturnDetailsSP
    {

        public DataTable SalesReturnDetailsViewBySalesReturnMasterId(decimal decSalesReturnMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from sd in IME.SalesReturnDetails
                               from uc in IME.UnitConvertions.Where(x => x.unitconversionId == sd.unitConversionId).DefaultIfEmpty()
                               where sd.salesReturnMasterId == decSalesReturnMasterId
                               select new
                               {
                                   sd.salesReturnDetailsId,
                                   sd.salesReturnMasterId,
                                   sd.productId,
                                   sd.qty,
                                   sd.rate,
                                   sd.unitId,
                                   sd.unitConversionId,
                                   sd.discount,
                                   sd.taxId,
                                   sd.batchId,
                                   sd.godownId,
                                   sd.amount,
                                   sd.salesDetailsId
                               }).ToList();

                dtbl.Columns.Add("salesReturnDetailsId");
                dtbl.Columns.Add("salesReturnMasterId");
                dtbl.Columns.Add("productId");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("rate");
                dtbl.Columns.Add("unitId");
                dtbl.Columns.Add("unitConversionId");
                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("batchId");
                dtbl.Columns.Add("godownId");
                dtbl.Columns.Add("amount");
                dtbl.Columns.Add("salesDetailsId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["salesReturnDetailsId"] = item.salesReturnDetailsId;
                    row["salesReturnMasterId"] = item.salesReturnMasterId;
                    row["productId"] = item.productId;
                    row["qty"] = item.qty;
                    row["rate"] = item.rate;
                    row["unitId"] = item.unitId;
                    row["unitConversionId"] = item.unitConversionId;
                    row["discount"] = item.discount;
                    row["taxId"] = item.taxId;
                    row["batchId"] = item.batchId;
                    row["godownId"] = item.godownId;
                    row["amount"] = item.amount;
                    row["salesDetailsId"] = item.salesDetailsId;

                    dtbl.Rows.Add(row);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OPen Tally", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public void SalesReturnDetailsDelete(decimal SalesReturnDetailsId)
        {
            IMEEntities db= new IMEEntities();
            try
            {
                SalesReturnDetail pdc = db.SalesReturnDetails.Where(x => x.salesReturnDetailsId == SalesReturnDetailsId).FirstOrDefault();
                db.SalesReturnDetails.Remove(pdc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SalesReturnDetailsEdit(SalesReturnDetail si)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                SalesReturnDetail pdc = db.SalesReturnDetails.Where(x => x.salesReturnDetailsId == si.salesReturnDetailsId).FirstOrDefault();

                pdc.salesReturnMasterId = si.salesReturnMasterId;
                pdc.productId = si.productId;
                pdc.qty = si.qty;
                pdc.rate = si.rate;
                pdc.unitId = si.unitId;
                pdc.unitConversionId = si.unitConversionId;
                pdc.discount = si.discount;
                pdc.taxId = si.taxId;
                pdc.batchId = si.batchId;
                pdc.godownId = si.godownId;
                pdc.rackId = si.rackId;
                pdc.taxAmount = si.taxAmount;
                pdc.grossAmount = si.grossAmount;
                pdc.netAmount = si.netAmount;
                pdc.amount = si.amount;
                pdc.slNo = si.slNo;
                pdc.salesDetailsId = si.salesDetailsId;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal SalesReturnDetailsAdd(SalesReturnDetail salesreturndetailsinfo)
        {
            IMEEntities db = new IMEEntities();
            SalesReturnDetail sd= salesreturndetailsinfo;
            decimal decIdentity = 0;
            try
            {
                db.SalesReturnDetails.Add(sd);
                db.SaveChanges();
                decIdentity = sd.salesReturnDetailsId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public DataTable productviewbybarcodeforSR(string strProductCode, decimal vouchertypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.productviewbybarcodeforSR(vouchertypeId,strProductCode);


                dtbl.Columns.Add("Article_No");
                dtbl.Columns.Add("barcode");
                dtbl.Columns.Add("Article_Desc");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("unitConversionId");
                dtbl.Columns.Add("conversionRate");
                dtbl.Columns.Add("batchId");
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
                    row["barcode"] = item.barcode;
                    row["Article_Desc"] = item.Article_Desc;
                    row["qty"] = item.qty;
                    row["unitConversionId"] = item.unitConversionId;
                    row["conversionRate"] = item.conversionRate;
                    row["batchId"] = item.batchId;
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
    }
}
