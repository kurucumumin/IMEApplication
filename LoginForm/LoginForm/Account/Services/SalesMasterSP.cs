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
    }
}
