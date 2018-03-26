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
    class SalesMasterSP
    {

        //public DataSet salesInvoicePrintAfterSave(decimal decsalesMasterId, decimal decCompanyId, decimal decOrderMasterId, decimal decDeliveryNoteMasterId, decimal decQuotationMasterId)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        if (sqlcon.State == ConnectionState.Closed)
        //        {
        //            sqlcon.Open();
        //        }
        //        SqlDataAdapter sqlda = new SqlDataAdapter("salesInvoicePrintAfterSave", sqlcon);
        //        sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        SqlParameter sprmparam = new SqlParameter();
        //        sprmparam = sqlda.SelectCommand.Parameters.Add("@salesMasterId", SqlDbType.Decimal);
        //        sprmparam.Value = decsalesMasterId;
        //        sprmparam = sqlda.SelectCommand.Parameters.Add("@companyId", SqlDbType.Decimal);
        //        sprmparam.Value = decCompanyId;
        //        sprmparam = sqlda.SelectCommand.Parameters.Add("@orderMasterId", SqlDbType.Decimal);
        //        sprmparam.Value = decOrderMasterId;
        //        sprmparam = sqlda.SelectCommand.Parameters.Add("@deliveryNoteMasterId", SqlDbType.Decimal);
        //        sprmparam.Value = decDeliveryNoteMasterId;
        //        sprmparam = sqlda.SelectCommand.Parameters.Add("@quotationMasterId", SqlDbType.Decimal);
        //        sprmparam.Value = decQuotationMasterId;
        //        sqlda.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sqlcon.Close();
        //    }
        //    return ds;
        //}


        public DataTable SalesInvoiceReportFill(DateTime dtfromDate, DateTime dttoDate, decimal decVoucherTypeId, decimal decLedgerId, decimal decAreaId, string strSalesMode, decimal decEmployeeId, string strProductName, string strVoucherNo, string strstatus, decimal decRouteId, decimal decModelNoId, string strProductCode)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                //var adaptor = IME.SalesInvoiceReportFill(dtfromDate, dttoDate, decVoucherTypeId, decLedgerId, decAreaId, strSalesMode, decEmployeeId, strProductName, strVoucherNo, strstatus, decRouteId, decModelNoId, strProductName);

                //dtbl.Columns.Add("SaleOrderNo");
                //dtbl.Columns.Add("voucherTypeName");
                //dtbl.Columns.Add("invoiceNo");
                //dtbl.Columns.Add("ledgerId");
                //dtbl.Columns.Add("date");
                //dtbl.Columns.Add("grandTotal");
                //dtbl.Columns.Add("ledgerName");
                //dtbl.Columns.Add("currencyName");
                //dtbl.Columns.Add("invoiceRefNo");
                //dtbl.Columns.Add("userName");
                //dtbl.Columns.Add("totalCreditAmt");

                //foreach (var item in adaptor)
                //{
                //    var row = dtbl.NewRow();

                //    row["SaleOrderNo"] = item.SaleOrderNo;
                //    row["voucherTypeName"] = item.voucherTypeName;
                //    row["invoiceNo"] = item.invoiceNo;
                //    row["ledgerId"] = item.ledgerId;
                //    row["date"] = item.date;
                //    row["grandTotal"] = item.grandTotal;
                //    row["ledgerName"] = item.ledgerName;
                //    row["currencyName"] = item.currencyName;
                //    row["invoiceRefNo"] = item.invoiceRefNo;
                //    row["userName"] = item.userName;
                //    row["totalCreditAmt"] = item.totalCreditAmt;

                //    dtbl.Rows.Add(row);
                //}

            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }
            return dtbl;
        }

        public SalesMaster SalesMasterViewBySalesMasterId(decimal salesMasterId)
        {
            IMEEntities IME = new IMEEntities();
            SalesMaster infoSalesMaster = new SalesMaster();
            try
            {
                infoSalesMaster = IME.SalesMasters.Where(x => x.salesMasterId == salesMasterId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }
            return infoSalesMaster;
        }

        public DataTable SalesMasterViewByInvoiceNoForComboSelection(decimal salesMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.SalesMasterViewForComboFillSelection(salesMasterId);

                dtbl.Columns.Add("salesMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("customerName");
                dtbl.Columns.Add("pricingLevelId");
                dtbl.Columns.Add("creditPeriod");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("salesAccount");
                dtbl.Columns.Add("deliveryNoteMasterId");
                dtbl.Columns.Add("orderMasterId");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("WorkerId");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("lrNo");
                dtbl.Columns.Add("transportationCompany");
                dtbl.Columns.Add("quotationNoId");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("billDiscount");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("grandTotal");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["salesMasterId"] = item.salesMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["customerName"] = item.customerName;
                    row["pricingLevelId"] = item.pricingLevelId;
                    row["creditPeriod"] = item.creditPeriod;
                    row["ledgerId"] = item.ledgerId;
                    row["salesAccount"] = item.salesAccount;
                    row["deliveryNoteMasterId"] = item.deliveryNoteMasterId;
                    row["orderMasterId"] = item.orderMasterId;
                    row["narration"] = item.narration;
                    row["WorkerId"] = item.WorkerId;
                    row["suffixPrefixId"] = item.suffixPrefixId;
                    row["lrNo"] = item.lrNo;
                    row["transportationCompany"] = item.transportationCompany;
                    row["quotationNoId"] = item.quotationNoId;
                    row["totalAmount"] = item.totalAmount;
                    row["billDiscount"] = item.billDiscount;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["grandTotal"] = item.grandTotal;

                    dtbl.Rows.Add(row);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Account Suit", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              return dtbl;
            }
            public decimal SalesInvoiceQuantityDetailsAgainstSalesReturn(decimal decvoucherTypeId, string strvoucherNo)
            {
                decimal decQty = 0;
                IMEEntities IME = new IMEEntities();
            decQty= Convert.ToDecimal(IME.SalesInvoiceQuantityDetailsAgainstSalesReturn(decvoucherTypeId, strvoucherNo));
                return decQty;
            }

            public bool SalesReturnCheckReferenceForSIDelete(decimal decSalesMasterId)
            {
                bool isReferenceExist = false;

                IMEEntities IME = new IMEEntities();
                if (IME.SalesReturnCheckReferenceForSIDelete(decSalesMasterId).ToString()=="true")
                {
                    isReferenceExist =  true;
                }
                else
                {
                    isReferenceExist=false;
                }
                return isReferenceExist;
            }

            public void SalesInvoiceDelete(decimal decSalesMasterId, decimal decVoucherTypeId, string strVoucherNo)
            {
                IMEEntities IME = new IMEEntities();
                IME.SalesInvoiceDelete(decSalesMasterId, decVoucherTypeId, strVoucherNo);

            }

            public decimal SalesInvoiceReferenceCheckForEdit(decimal decSalesMasterId)
            {
                IMEEntities IME = new IMEEntities();
                decimal decStatus = 0;
                decStatus = Decimal.Parse(IME.SalesInvoiceReferenceCheckForEdit(decSalesMasterId).ToString());
                return decStatus;
            }

            public void SalesMasterEdit(SalesMaster salesmasterinfo)
            {
                IMEEntities IME = new IMEEntities();
                SalesMaster sm = IME.SalesMasters.Where(a => a.salesMasterId == salesmasterinfo.salesMasterId).FirstOrDefault();
                sm.invoiceNo = salesmasterinfo.invoiceNo; sm.
                voucherTypeId = salesmasterinfo.voucherTypeId; sm.
                suffixPrefixId = salesmasterinfo.suffixPrefixId; sm.
                date = salesmasterinfo.date; sm.
                creditPeriod = salesmasterinfo.creditPeriod; sm.
                ledgerId = salesmasterinfo.ledgerId; sm.
                pricinglevelId = salesmasterinfo.pricinglevelId; sm.
                WorkerId = salesmasterinfo.WorkerId; sm.
                salesAccount = salesmasterinfo.salesAccount; sm.
                deliveryNoteMasterId = salesmasterinfo.deliveryNoteMasterId; sm.
                orderMasterId = salesmasterinfo.orderMasterId; sm.
                narration = salesmasterinfo.narration; sm.
                customerName = salesmasterinfo.customerName; sm.
                exchangeRateId = salesmasterinfo.exchangeRateId; sm.
                taxAmount = salesmasterinfo.taxAmount; sm.
                additionalCost = salesmasterinfo.additionalCost; sm.
                billDiscount = salesmasterinfo.billDiscount; sm.
                grandTotal = salesmasterinfo.grandTotal; sm.
                totalAmount = salesmasterinfo.totalAmount; sm.

                lrNo = salesmasterinfo.lrNo; sm.
                transportationCompany = salesmasterinfo.transportationCompany; sm.
                POS = salesmasterinfo.POS; sm.
                counterId = salesmasterinfo.counterId; sm.
                financialYearId = salesmasterinfo.financialYearId;
                IME.SaveChanges();


            }

            public SalesMaster SalesMasterView(decimal salesMasterId)
            {
                IMEEntities IME = new IMEEntities();
                var SaleMaster = IME.SalesMasterView(salesMasterId).FirstOrDefault();
                SalesMaster sm = new SalesMaster();
                sm.additionalCost = SaleMaster.additionalCost;
                sm.billDiscount = SaleMaster.billDiscount;
                sm.counterId = SaleMaster.counterId;
                sm.creditPeriod = SaleMaster.creditPeriod;
                sm.customerName = SaleMaster.customerName;
                sm.date = SaleMaster.date;
                sm.deliveryNoteMasterId = SaleMaster.deliveryNoteMasterId;
                sm.exchangeRateId = SaleMaster.exchangeRateId;
                sm.financialYearId = SaleMaster.financialYearId;
                sm.grandTotal = SaleMaster.grandTotal;
                sm.invoiceNo = SaleMaster.invoiceNo;
                sm.ledgerId = SaleMaster.ledgerId;
                sm.lrNo = SaleMaster.lrNo;
                sm.narration = SaleMaster.narration;
                sm.orderMasterId = SaleMaster.orderMasterId;
                sm.POS = SaleMaster.POS;
                sm.pricinglevelId = SaleMaster.pricinglevelId;
                sm.quotationNoId = SaleMaster.quotationNoId;
                sm.salesAccount = SaleMaster.salesAccount;
                sm.salesMasterId = SaleMaster.salesMasterId;
                sm.suffixPrefixId = SaleMaster.suffixPrefixId;
                sm.taxAmount = SaleMaster.taxAmount;
                sm.totalAmount = SaleMaster.totalAmount;
                sm.transportationCompany = SaleMaster.transportationCompany;
                sm.voucherNo = SaleMaster.voucherNo;
                sm.voucherTypeId = SaleMaster.voucherTypeId;
                sm.WorkerId = SaleMaster.WorkerId;
                return sm;
            }

            public DataTable SalesInvoiceSalesMasterViewBySalesMasterId(decimal decSalesMasterId)
            {
                DataTable dt = new DataTable();
                IMEEntities IME = new IMEEntities();
                var salesmaster = IME.SalesMasters.Where(a => a.salesMasterId == decSalesMasterId);
                dt.Columns.Add("salesMasterId");
                dt.Columns.Add("voucherNo");
                dt.Columns.Add("invoiceNo");
                dt.Columns.Add("suffixPrefixId");
                dt.Columns.Add("voucherTypeId");
                dt.Columns.Add("date");
                dt.Columns.Add("customerName");
                dt.Columns.Add("pricingLevelId");
                dt.Columns.Add("creditPeriod");
                dt.Columns.Add("ledgerId");
                dt.Columns.Add("employeeId");
                dt.Columns.Add("salesAccount");
                dt.Columns.Add("quotationMasterId");
                dt.Columns.Add("deliveryNoteMasterId");
                dt.Columns.Add("narration");
                dt.Columns.Add("exchangeRateId");
                dt.Columns.Add("additionalCost");
                dt.Columns.Add("taxAmount");
                dt.Columns.Add("billDiscount");
                dt.Columns.Add("totalAmount");
                dt.Columns.Add("grandTotal");
                dt.Columns.Add("userId");
                dt.Columns.Add("suffixPrefixId");
                dt.Columns.Add("lrNo");
                dt.Columns.Add("transportationCompany");
                dt.Columns.Add("currencyId");
                dt.Columns.Add("noOfDecimalPlaces");

                foreach (var item in salesmaster)
                {
                    var row = dt.NewRow();
                    row["salesMasterId"] = item.salesMasterId;

                    row["voucherNo"] = item.voucherNo;

                    row["invoiceNo"] = item.invoiceNo;

                    row["suffixPrefixId"] = item.suffixPrefixId;

                    row["voucherTypeId"] = item.voucherTypeId;

                    row["date"] =(item.date.ToString().Replace(" ","-"));

                    row["customerName"] = item.customerName;

                    row["pricingLevelId"] = item.pricinglevelId;

                    row["creditPeriod"] = item.creditPeriod;

                    row["ledgerId"] = item.ledgerId;

                    row["employeeId"] = item.WorkerId;

                    row["salesAccount"] = item.salesAccount;

                    //row["quotationMasterId"] = item.quo;

                    row["deliveryNoteMasterId"] = item.deliveryNoteMasterId;

                    row["narration"] = item.narration;

                    row["exchangeRateId"] = item.exchangeRateId;

                    row["additionalCost"] = item.additionalCost / item.ExchangeRate.rate;

                    row["taxAmount"] = item.taxAmount / item.ExchangeRate.rate;

                    row["billDiscount"] = item.billDiscount/item.ExchangeRate.rate;

                    row["totalAmount"] = item.totalAmount/item.ExchangeRate.rate;

                    row["grandTotal"] = item.grandTotal/item.ExchangeRate.rate;

                    row["suffixPrefixId"] = item.suffixPrefixId;

                    row["lrNo"] = item.lrNo;

                    row["transportationCompany"] = item.transportationCompany;

                    row["currencyId"] = item.ExchangeRate.currencyId;

                    row["noOfDecimalPlaces"] = 4;
                    dt.Rows.Add(row);
                }
                return dt;
            }

            public DataTable SalesInvoiceAdditionalCostViewByVoucherNoUnderVoucherType(decimal decVoucherTypeId, string strVoucherNo)
            {
                IMEEntities IME = new IMEEntities();
                DataTable dt = new DataTable();


                var adaptor = IME.SalesInvoiceAdditionalCostViewByVoucherNoUnderVoucherType(decVoucherTypeId, strVoucherNo);

                dt.Columns.Add("ledgerName");
                dt.Columns.Add("ledgerId");
                dt.Columns.Add("amount");
                dt.Columns.Add("additionalCostId");
                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();
                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;
                    row["amount"] = item.ledgerId;
                    row["additionalCostId"] = item.ledgerId;
                    dt.Rows.Add(row);
                }
                return dt;
            }

            public DataTable SalesInvoiceSalesAccountModeComboFill()
            {
                IMEEntities IME = new IMEEntities();
                DataTable dt = new DataTable();

                var adaptor = (from al in IME.AccountLedgers
                               from ac in IME.AccountGroups.Where(a => a.accountGroupName == "Sales Account")
                               where (al.accountGroupID == ac.accountGroupId)
                               select new
                               {
                                   al.ledgerName,
                                   al.ledgerId
                               }).ToList();

                dt.Columns.Add("ledgerName");
                dt.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();
                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;
                    dt.Rows.Add(row);
                }
                return dt;
            }

            public ProductInfo ProductViewByProductIdforSalesInvoice(string strproductCode)
            {
                IMEEntities IME = new IMEEntities();
                ProductInfo productinfo = new ProductInfo();
                var product = IME.ArticleSearch(strproductCode).FirstOrDefault();
                productinfo.ProductName = product.Article_Desc;
                productinfo.ProductId = product.Article_No;
                return productinfo;
            }

            public bool SalesInvoiceInvoiceNumberCheckExistence(string strvoucherNo, decimal decsalesMasterId, decimal decVoucherTypeId)
            {
                bool isEdit = false;
                IMEEntities IME = new IMEEntities();
                if(IME.SalesMasters.Where(a=>a.voucherNo==strvoucherNo).Where(a=>a.salesMasterId==decsalesMasterId).Where(a=>a.voucherTypeId==decVoucherTypeId).Count()>0)
                {
                    return isEdit = true;
                }
                return isEdit;
            }

            public int SaleMasterReferenceCheck(decimal decSalesMsterId, decimal decSalesDetailsId)
            {
                int inQty = 0;
                IMEEntities IME = new IMEEntities();
                if(IME.SalesReturnDetails.Where(a=>a.salesDetailsId== decSalesDetailsId).Count()>0)
                {
                    inQty = 1;
                }
                return inQty;
            }

            public decimal SalesReturnDetailsQtyViewBySalesDetailsId(decimal decSalseDetailsId)
            {
                decimal decQty = 0;
                IMEEntities IME = new IMEEntities();
                if (IME.SalesReturnDetails.Where(a=>a.salesDetailsId==decSalseDetailsId)!=null)
                {
                    foreach (var item in IME.SalesReturnDetails.Where(a => a.salesDetailsId == decSalseDetailsId))
                    {
                        decQty = decQty + (decimal)item.qty;
                    }
                }
                return decQty;
            }

            public bool SalesInvoiceInvoicePartyCheckEnableBillByBillOrNot(decimal decPartyId)
            {
                bool isBillByBill = false;
                IMEEntities IME = new IMEEntities();
                if (IME.AccountLedgers.Where(a => a.ledgerId == decPartyId).Where(a => a.billByBill == true).Count() > 0)
                {
                    isBillByBill = true;
                }
                return isBillByBill;
            }

        public decimal SalesMasterAdd(SalesMaster salesmasterinfo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decSalesMasterId = 0;
            try
            {
                object obj = IME.SalesMasterAdd(
                salesmasterinfo.voucherNo,
                salesmasterinfo.invoiceNo,
                salesmasterinfo.voucherTypeId,
                salesmasterinfo.suffixPrefixId,
                salesmasterinfo.date,
                salesmasterinfo.creditPeriod,
                salesmasterinfo.ledgerId,
                salesmasterinfo.salesAccount,
                salesmasterinfo.deliveryNoteMasterId,
                salesmasterinfo.orderMasterId,
                salesmasterinfo.narration,
                salesmasterinfo.customerName,
                salesmasterinfo.exchangeRateId,
                salesmasterinfo.taxAmount,
                salesmasterinfo.additionalCost,
                salesmasterinfo.billDiscount,
                salesmasterinfo.grandTotal,
                salesmasterinfo.totalAmount,
                salesmasterinfo.WorkerId,
                salesmasterinfo.lrNo,
                salesmasterinfo.transportationCompany,
                salesmasterinfo.quotationNoId,
                salesmasterinfo.POS,
                salesmasterinfo.counterId,
                salesmasterinfo.financialYearId).FirstOrDefault();

                if (obj != null)
                {
                    decSalesMasterId = decimal.Parse(obj.ToString());
                }
                else
                {
                    decSalesMasterId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decSalesMasterId;
        }

        public DataTable salesinvoiceAdditionalCostCheckdrOrCrforSiEdit(decimal decVoucherTypeId, string strVoucherNo)
            {
                DataTable dtbl = new DataTable();
                IMEEntities IME = new IMEEntities();
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("debit");
                dtbl.Columns.Add("Credit");
                foreach (var item in IME.AdditionalCosts.Where(a => a.AccountLedger.AccountGroup.accountGroupName == "Bank Account" || a.AccountLedger.AccountGroup.accountGroupName == "Cash-in Hand").Where(b => b.voucherTypeId == decVoucherTypeId).Where(a => a.voucherNo == strVoucherNo))
                {
                    var row = dtbl.NewRow();
                    row["ledgerName"] = item.AccountLedger.ledgerName;
                    row["ledgerId"] = item.ledgerId;
                    row["debit"] = item.debit;
                    row["Credit"] = item.credit;
                    dtbl.Rows.Add(row);
            }
            return dtbl;
        }

        //public DataTable SalesInvoiceSalesAccountModeComboFill()
        //{
        //    DataTable dtbl = new DataTable();
        //    IMEEntities IME = new IMEEntities();

        //    var AccountGroups = IME.AccountGroups.Where(a => a.groupUnder == IME.AccountGroups.Where(b => b.accountGroupName == "Sales Account").FirstOrDefault().accountGroupId).ToList();
        //    var adaptor = (from a in IME.AccountLedgers
        //                   from b in AccountGroups
        //                   where (a.accountGroupID == b.accountGroupId)

        //                   select new
        //                   {
        //                       ledgerName = a.ledgerName,
        //                       ledgerId = a.ledgerId

        //                   }).ToList();

        //    dtbl.Columns.Add("ledgerName");
        //    dtbl.Columns.Add("ledgerId");

        //    foreach (var item in adaptor)
        //    {
        //        var row = dtbl.NewRow();
        //        row["ledgerName"] = item.ledgerName;
        //        row["ledgerId"] = item.ledgerId;
        //        dtbl.Rows.Add(row);
        //    }

        //    return dtbl;
        //}

        public decimal SalesMasterVoucherMax(decimal decVoucherTypeId)
        {
            decimal decVoucherNoMax = 0;
            IMEEntities IME = new IMEEntities();
            decVoucherNoMax = (decimal)IME.SaleOrders.Where(a => a.VoucherTypeId == decVoucherTypeId).OrderByDescending(a => a.VoucherNo).FirstOrDefault().VoucherNo;
            return decVoucherNoMax;
        }

        public bool DayBookSalesInvoiceOrPOS(decimal decSalesMasterId, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            bool isPos = false;
            try
            {
                var adaptor=IME.DayBookSalesInvoiceOrPOS(decSalesMasterId, decVoucherTypeId).ToList();

                if (adaptor!=null)
                {
                    isPos=true;
                }

            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }
            return isPos;
        }

        public decimal SalesMasterIdViewByvoucherNoAndVoucherType(decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decStock = 0;
            try
            {
                decStock = Convert.ToDecimal(IME.SalesMasterIdViewByvoucherNoAndVoucherType(strVoucherNo, decVoucherTypeId).FirstOrDefault());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decStock;
        }

        public string SaleMasterGetPos(decimal saleMasterId, string voucherName)
        {
            IMEEntities IME = new IMEEntities();
            string pos = "";

            try
            {
                pos = IME.SaleMasterGetPos(saleMasterId, voucherName).ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return pos;
        }

    }
}
