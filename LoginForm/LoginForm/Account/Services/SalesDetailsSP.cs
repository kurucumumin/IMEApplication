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
    class SalesDetailsSP
    {
        public DataTable VoucherTypeNameComboFillForSalesInvoiceRegister()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from v in IME.VoucherTypes.Where(x => x.typeOfVoucher.StartsWith("Sales Invoice"))
                               select new { v.voucherTypeId, v.voucherTypeName }).ToList();

                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("voucherTypeName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["voucherTypeId"] = item.voucherTypeId;
                    row["voucherTypeName"] = item.voucherTypeName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable SalesDetailsViewForSalesReturnGrideFill(decimal salesMasterId, decimal salesReturnMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor=IME.SalesReturnGrideFillNew(salesMasterId,salesReturnMasterId);

                dtbl.Columns.Add("salesDetailsId");
                dtbl.Columns.Add("salesMasterId");
                dtbl.Columns.Add("deliveryNoteDetailsId");
                dtbl.Columns.Add("orderDetailsId");
                dtbl.Columns.Add("productId");
                dtbl.Columns.Add("qty");
                dtbl.Columns.Add("unitId");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("godownId");
                dtbl.Columns.Add("rackId");
                dtbl.Columns.Add("batchId");
                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("netAmount");
                dtbl.Columns.Add("taxAmount");
                dtbl.Columns.Add("grossAmount");
                dtbl.Columns.Add("amount");
                dtbl.Columns.Add("unitConversionId");
                dtbl.Columns.Add("conversionRate");
                dtbl.Columns.Add("Refer");
                dtbl.Columns.Add("batch");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["salesDetailsId"] = item.salesDetailsId;
                    row["salesMasterId"] = item.salesMasterId;
                    row["deliveryNoteDetailsId"] = item.deliveryNoteDetailsId;
                    row["orderDetailsId"] = item.orderDetailsId;
                    row["productId"] = item.productId;
                    row["qty"] = item.qty;
                    row["unitId"] = item.unitId;
                    row["taxId"] = item.taxId;
                    row["godownId"] = item.godownId;
                    row["rackId"] = item.rackId;
                    row["batchId"] = item.batchId;
                    row["discount"] = item.discount;
                    row["netAmount"] = item.netAmount;
                    row["taxAmount"] = item.taxAmount;
                    row["grossAmount"] = item.grossAmount;
                    row["amount"] = item.amount;
                    row["unitConversionId"] = item.unitConversionId;
                    row["conversionRate"] = item.conversionRate;
                    row["Refer"] = item.Refer;
                    row["batch"] = item.batch;


                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable SalesReturnGrideFillNewByProductId(decimal decProductId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                ProductViewAll_Result aa = new ProductViewAll_Result();
                var adaptor = (from b in IME.Batches.Where(x => x.productId == aa.Article_No).DefaultIfEmpty()
                               where aa.Article_No == Convert.ToString(decProductId)
                               select new
                               {
                                   aa.Article_Desc,
                                   aa.Article_No,
                                   b.barcode
                               }).ToList();

                dtbl.Columns.Add("Article_Desc");
                dtbl.Columns.Add("Article_No");
                dtbl.Columns.Add("barcode");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Article_Desc"] = item.Article_Desc;
                    row["Article_No"] = item.Article_No;
                    row["barcode"] = item.barcode;

                    dtbl.Rows.Add(row);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable SalesDetailsViewForSalesReturnGrideFill1(decimal decProductId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                ProductViewAll_Result aa = new ProductViewAll_Result();
                var adaptor = (from b in IME.Batches.Where(x => x.productId == aa.Article_No).DefaultIfEmpty()
                               where aa.Article_No == Convert.ToString(decProductId)
                               select new
                               {
                                   aa.Article_Desc,
                                   aa.Article_No,
                                   b.barcode
                               }).ToList();

                dtbl.Columns.Add("Article_Desc");
                dtbl.Columns.Add("Article_No");
                dtbl.Columns.Add("barcode");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Article_Desc"] = item.Article_Desc;
                    row["Article_No"] = item.Article_No;
                    row["barcode"] = item.barcode;

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
