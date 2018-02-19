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

        public DataTable BankOrCashComboFill()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
              var adaptor = (from ag in db.AccountGroups.Where(x => x.accountGroupName == "Cash-in Hand" || x.accountGroupName == "Bank Account" || x.accountGroupName == "Bank OD A/C")
                             select new
                             {
                                 AccountGroupId = ag.accountGroupId,
                                 hierarchyLevel = 1
                             }).ToList();
              List<int> IDs = adaptor.Select(x => x.AccountGroupId).ToList();

              var adaptor2 = (from ag in db.AccountGroups.Where(x => x.groupUnder == IDs[0] || x.groupUnder == IDs[1] || x.groupUnder == IDs[2])
                              select new
                              {
                                  AccountGroupId = ag.accountGroupId,
                                  hierarchyLevel = 2
                              }).ToList();

              foreach (var item in adaptor2)
              {
                  if (!adaptor.Exists(x => x.AccountGroupId == item.AccountGroupId))
                  {
                      adaptor.Add(item);
                  }
              }

              dtbl.Columns.Add("AccountGroupId");

                              foreach (var item in adaptor)
                              {
                                  var row = dtbl.NewRow();
                                  row["AccountGroupId"] = item.AccountGroupId;

                                  dtbl.Rows.Add(row);
                              }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            return dtbl;
                        }

        public DataTable VoucherTypesBasedOnTypeOfVouchers(string typeOfVouchers)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            List<VoucherType> VoucherType = new List<DataSet.VoucherType>();
            if(typeOfVouchers!= "")
            {
                VoucherType = IME.VoucherTypes.Where(a => a.typeOfVoucher == typeOfVouchers).ToList();
            }
            else
            {
                VoucherType = IME.VoucherTypes.ToList();
            }
            dtbl.Columns.Add("voucherTypeId");
            dtbl.Columns.Add("voucherTypeName");
            dtbl.Columns.Add("typeOfVoucher");
            foreach (var item in VoucherType)
            {
                var row = dtbl.NewRow();
                row["voucherTypeId"] = item.voucherTypeId;
                row["voucherTypeName"] = item.voucherTypeName;
                row["typeOfVoucher"] = item.typeOfVoucher;
                dtbl.Rows.Add(row);
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

            public DataTable SalesInvoiceDetailsViewByProductNameForSI(decimal decVoucherTypeId, string strProductName)
            {
                
                DataTable dt = new DataTable();
                IMEEntities IME = new IMEEntities();
                var adaptor= IME.SalesInvoiceDetailsViewByProductNameForSI(decVoucherTypeId, strProductName);
                dt.Columns.Add("salesDetailsId");
                dt.Columns.Add("salesOrderDetailsId");
                dt.Columns.Add("salesQuotationDetailsId");
                dt.Columns.Add("deliveryNoteDetailsId");
                dt.Columns.Add("barcode");
                dt.Columns.Add("Article_No");
                dt.Columns.Add("Article_Desc");
                dt.Columns.Add("unitConversionId");
                dt.Columns.Add("batchId");
                dt.Columns.Add("discountPercent");
                dt.Columns.Add("discount");
                dt.Columns.Add("netvalue");
                dt.Columns.Add("discount");
                dt.Columns.Add("taxId");
                dt.Columns.Add("taxAmount");
                dt.Columns.Add("amount");
                dt.Columns.Add("Article_No");
                dt.Columns.Add("Article_Desc");
                dt.Columns.Add("unitConversionId");
                dt.Columns.Add("conversionRate");
                dt.Columns.Add("batchId");
                dt.Columns.Add("taxId");
                
                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();
                    row["salesDetailsId"] = item.salesOrderDetailsId;
                    row["salesOrderDetailsId"] = item.salesOrderDetailsId;
                    row["salesQuotationDetailsId"] = item.salesQuotationDetailsId;
                    row["deliveryNoteDetailsId"] = item.deliveryNoteDetailsId;
                    row["barcode"] = item.barcode;
                    row["Article_No"] = item.Article_No;
                    row["Article_Desc"] = item.Article_Desc;
                    row["unitConversionId"] = item.unitConversionId;
                    row["batchId"] = item.batchId;
                    row["discountPercent"] = item.discountPercent;
                    row["discount"] = item.discount;
                    row["taxId"] = item.taxId;
                    row["taxAmount"] = item.taxAmount;
                    row["amount"] = item.Amount;
                    row["Article_No"] = item.Article_No;
                    row["Article_Desc"] = item.Article_Desc;
                    row["unitConversionId"] = item.unitConversionId;
                    row["conversionRate"] = item.conversionRate;
                    row["batchId"] = item.batchId;
                    row["taxId"] = item.taxId;
                    dt.Rows.Add(row);
                }

                return dt;
            }



            public DataTable SalesInvoiceDetailsViewByBarcodeForSI(decimal decVoucherTypeId, string strBarcode)
            {
                DataTable dtbl = new DataTable();
                IMEEntities IME = new IMEEntities();

                return dtbl;
            }

            public DataTable SalesInvoiceDetailsViewByProductCodeForSI(decimal decVoucherTypeId, string strProductCode)
            {
                DataTable dt = new DataTable();
                IMEEntities IME = new IMEEntities();
                var adaptor=IME.SalesInvoiceDetailsViewByProductCodeForSI(decVoucherTypeId, strProductCode);
                dt.Columns.Add("salseDetailsId");
                dt.Columns.Add("salesOrderDetailsId");
                dt.Columns.Add("salesQuotationDetailsId");
                dt.Columns.Add("deliveryNoteDetailsId");
                dt.Columns.Add("barcode");
                dt.Columns.Add("Article_No");
                dt.Columns.Add("Article_Desc");
                dt.Columns.Add("unitConversionId");
                dt.Columns.Add("conversionRate");
                dt.Columns.Add("discountPercent");
                dt.Columns.Add("netvalue");
                dt.Columns.Add("discount");
                dt.Columns.Add("taxId");
                dt.Columns.Add("taxAmount");
                dt.Columns.Add("amount");
                //
                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["salseDetailsId"] = item.salseDetailsId;
                    row["salesOrderDetailsId"] = item.salesOrderDetailsId;
                    row["salesQuotationDetailsId"] = item.salesQuotationDetailsId;
                    row["deliveryNoteDetailsId"] = item.deliveryNoteDetailsId;
                    row["barcode"] = item.barcode;
                    row["Article_No"] = item.Article_No;
                    row["Article_Desc"] = item.Article_Desc;
                    row["unitConversionId"] =  item.unitConversionId;
                    row["conversionRate"] = item.conversionRate;
                    row["discountPercent"] = item.discountPercent;
                    row["netvalue"] = item.netvalue;
                    row["discount"] = item.discount;
                    row["taxId"] = item.taxId;
                    row["taxAmount"] = item.taxAmount;
                    row["amount"] = item.Amount;
                    dt.Rows.Add(row);
                }

                return dt;
            }

            public void SalesDetailsEdit(SalesDetail salesdetailsinfo)
            {
                IMEEntities IME = new IMEEntities();
                IME.SalesDetailsEdit(salesdetailsinfo.salesDetailsId, salesdetailsinfo.salesMasterId, salesdetailsinfo.deliveryNoteDetailsId, salesdetailsinfo.orderDetailsId, salesdetailsinfo.quotationDetailsId, salesdetailsinfo.productId, salesdetailsinfo.qty, salesdetailsinfo.rate, salesdetailsinfo.unitId, salesdetailsinfo.unitConversionId, salesdetailsinfo.discount, salesdetailsinfo.taxId, salesdetailsinfo.batchId, salesdetailsinfo.godownId, salesdetailsinfo.rackId, salesdetailsinfo.taxAmount, salesdetailsinfo.grossAmount, salesdetailsinfo.netAmount, salesdetailsinfo.amount, salesdetailsinfo.slNo);
                    //SqlCommand sccmd = new SqlCommand("SalesDetailsEdit", sqlcon);

            }

            public void SalesDetailsDelete(decimal SalesDetailsId)
            {
                IMEEntities IME = new IMEEntities();
                IME.SalesDetailsDelete(SalesDetailsId);
            }

            public decimal SalesInvoiceReciptVoucherDetailsAgainstSI(decimal decvoucherTypeId, string strvoucherNo)
            {
                //decimal decBalAmount = 0;
                IMEEntities IME = new IMEEntities();
                var decBalAmount = IME.SalesInvoiceReciptVoucherDetailsAgainstSI(decvoucherTypeId, strvoucherNo);
                return decimal.Parse(decBalAmount.ToString());
            }

            public DataTable SalesInvoiceSalesDetailsViewBySalesMasterId(decimal dcSalesMasterId)
            {
                DataTable dt = new DataTable();
                IMEEntities IME = new IMEEntities();

                return dt;
            }

            public void SalesDetailsAdd(SalesDetail salesdetailsinfo)
            {
                IMEEntities IME = new IMEEntities();
                SalesDetail sd = new SalesDetail();
                sd.amount = salesdetailsinfo.amount;
                sd.batchId = salesdetailsinfo.batchId;
                sd.deliveryNoteDetailsId = salesdetailsinfo.deliveryNoteDetailsId;
                sd.discount = salesdetailsinfo.discount;
                sd.godownId = salesdetailsinfo.godownId;
                sd.grossAmount = salesdetailsinfo.grossAmount;
                sd.netAmount = salesdetailsinfo.netAmount;
                sd.orderDetailsId = salesdetailsinfo.orderDetailsId;
                sd.productId = salesdetailsinfo.productId;
                sd.qty = salesdetailsinfo.qty;
                sd.quotationDetailsId = salesdetailsinfo.quotationDetailsId;
                sd.rackId = salesdetailsinfo.rackId;
                sd.rate = salesdetailsinfo.rate;
                sd.salesDetailsId = salesdetailsinfo.salesDetailsId;
                sd.salesMasterId = salesdetailsinfo.salesMasterId;
                sd.slNo = salesdetailsinfo.slNo;
                sd.taxAmount = salesdetailsinfo.taxAmount;
                sd.taxId = salesdetailsinfo.taxId;
                sd.unitConversionId = salesdetailsinfo.unitConversionId;
                sd.unitId = salesdetailsinfo.unitId;
                IME.SalesDetails.Add(sd);
                IME.SaveChanges();


            }

            //public DataTable VoucherTypesBasedOnTypeOfVouchers(string typeOfVouchers)
            //{
            //    IMEEntities db = new IMEEntities();
            //    DataTable dt = new DataTable();
            //    var adaptor = (from vt in db.VoucherTypes
            //                   where (vt.typeOfVoucher== typeOfVouchers)
            //                   select new
            //                   {
            //                       vt.voucherTypeId,
            //                       vt.voucherTypeName,
            //                       vt.typeOfVoucher
            //                   }).ToList();
            //    dt.Columns.Add("voucherTypeId");
            //    dt.Columns.Add("voucherTypeName");
            //    dt.Columns.Add("typeOfVoucher");
            //    foreach (var item in adaptor)
            //    {
            //        var row = dt.NewRow();

            //        row["voucherTypeId"] = item.voucherTypeId;
            //        row["voucherTypeName"] = item.voucherTypeName;
            //        row["voucherTypeName"] = item.voucherTypeName;
            //        dt.Rows.Add(row);
            //    }
            //    return dt;
            //}
        }

}
