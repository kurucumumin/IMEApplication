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
    class PurchaseMasterSP
    {
        public DataTable PurchaseInvoicePurchaseAccountFill()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.PurchaseInvoicePurchaseAccountComboFill();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable GetInvoiceNoCorrespondingtoLedger(decimal decLedgerId, decimal decPurchaseMasterId, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.GetPurchaseReturnInvoiceNoCorrespondingtoLedger(decLedgerId, decPurchaseMasterId, decVoucherTypeId);

                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("purchaseMasterId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["invoiceNo"] = item.invoiceNo;
                    row["purchaseMasterId"] = item.purchaseMasterId;


                    dtbl.Rows.Add(row);
                  }

              }
              catch (Exception ex)
              {
                MessageBox.Show("pmsp" + ex.ToString());
              }
              return dtbl;
          }
        public decimal PurchaseMasterVoucherMax(decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            decimal decVoucherNoMax = 0;
            try
            {

                decVoucherNoMax = Convert.ToDecimal(db.PurchaseMasterVoucherMax(decVoucherTypeId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decVoucherNoMax;
        }

        public DataTable GetOrderNoCorrespondingtoLedgerByNotInCurrPI(decimal decLedgerId, decimal decPurchaseMasterId, decimal decVoucherType)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.GetOrderNoCorrespondingtoLedgerByNotInCurrPI(decLedgerId, decPurchaseMasterId);

                dtbl.Columns.Add("purchaseOrderMasterId");
                dtbl.Columns.Add("invoiceNo");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["purchaseOrderMasterId"] = item.purchaseOrderMasterId;
                    row["invoiceNo"] = item.invoiceNo;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        //public PurchaseMaster PurchaseMasterView(Decimal purchaseMasterId)
        //{
        //    IMEEntities IME = new IMEEntities();
        //    PurchaseMaster purchasemasterinfo = new PurchaseMaster();
        //    try
        //    {
        //        purchasemasterinfo = IME.PurchaseMasters.Where(x => x.purchaseMasterId == purchaseMasterId).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return purchasemasterinfo;
        //}
        public DataTable GetMaterialReceiptNoCorrespondingtoLedgerByNotInCurrPI(string decLedgerId, string decPurchaseMasterId, decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.GetMaterialReceiptNoCorrespondingtoLedgerByNotInCurrPI(decLedgerId, decPurchaseMasterId);

                dtbl.Columns.Add("materialReceiptMasterId");
                dtbl.Columns.Add("invoiceNo");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["materialReceiptMasterId"] = item.materialReceiptMasterId;
                    row["invoiceNo"] = item.invoiceNo;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable GetInvoiceNoCorrespondingtoLedgerInRegister()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.GetInvoiceNoCorrespondingtoLedgerInRegister();

                dtbl.Columns.Add("purchaseMasterId");
                dtbl.Columns.Add("invoiceNo");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["purchaseMasterId"] = item.purchaseMasterId;
                    row["invoiceNo"] = item.invoiceNo;


                    dtbl.Rows.Add(row);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("pmsp" + ex.ToString());
            }
            return dtbl;
        }

        public DataTable AccountLedgerViewForAdditionalCost()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.AccountLedgerViewForAdditionalCost();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public int PurchaseMasterReferenceCheck(decimal decPurchaseMasterId, decimal decPurchaseDetailsId)
        {
            int inQty = 0;
            try
            {
                inQty = new IMEEntities().PurchaseMasterReferenceCheck(decPurchaseMasterId, decPurchaseDetailsId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return inQty;
        }

        public int PurchaseInvoiceVoucherNoCheckExistance(string strInvoiceNo, string strVoucherNo, decimal decVoucherTypeId, decimal decPurchaseMasterId)
        {
            int inRef = 0;
            try
            {
                inRef = Convert.ToInt32(new IMEEntities().PurchaseInvoiceVoucherNoCheckExistance(strInvoiceNo, strVoucherNo, decVoucherTypeId, decPurchaseMasterId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return inRef;
        }

        public decimal PurchaseMasterAdd(PurchaseMaster p)
        {
            decimal decPurchaseMasterId = 0;
            try
            {
                decPurchaseMasterId = Convert.ToDecimal(new IMEEntities().PurchaseMasterAdd(p.voucherNo,
                    p.invoiceNo,
                    p.suffixPrefixId,
                    p.voucherTypeId,
                    p.date,
                    p.ledgerId,
                    p.vendorInvoiceNo,
                    p.vendorInvoiceDate,
                    p.creditPeriod,
                    p.exchangeRateId,
                    p.narration,
                    p.purchaseAccount,
                    p.purchaseOrderMasterId,
                    p.materialReceiptMasterId,
                    p.additionalCost,
                    p.totalTax,
                    p.billDiscount,
                    p.grandTotal,
                    p.totalAmount,
                    p.userId,
                    p.lrNo,
                    p.transportationCompany,
                    p.financialYearId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decPurchaseMasterId;
        }

        public PurchaseMaster PurchaseMasterView(decimal purchaseMasterId)
        {
            IMEEntities db = new IMEEntities();
            PurchaseMaster purchasemasterinfo = new PurchaseMaster();
            try
            {
                var p = db.PurchaseMasterView(purchaseMasterId);

                purchasemasterinfo.purchaseMasterId = p.purchaseMasterId;
                purchasemasterinfo.voucherNo = p.voucherNo;
                purchasemasterinfo.invoiceNo = p.invoiceNo;
                purchasemasterinfo.suffixPrefixId = p.suffixPrefixId;
                purchasemasterinfo.voucherTypeId = p.voucherTypeId;
                purchasemasterinfo.date = p.date;
                purchasemasterinfo.ledgerId = p.ledgerId;
                purchasemasterinfo.vendorInvoiceNo = p.vendorInvoiceNo;
                purchasemasterinfo.vendorInvoiceDate = p.vendorInvoiceDate;
                purchasemasterinfo.creditPeriod = p.creditPeriod;
                purchasemasterinfo.exchangeRateId = p.exchangeRateId;
                purchasemasterinfo.narration = p.narration;
                purchasemasterinfo.purchaseAccount = p.purchaseAccount;
                purchasemasterinfo.purchaseOrderMasterId = p.purchaseOrderMasterId;
                purchasemasterinfo.materialReceiptMasterId = p.materialReceiptMasterId;
                purchasemasterinfo.additionalCost = p.additionalCost;
                purchasemasterinfo.totalTax = p.totalTax;
                purchasemasterinfo.billDiscount = p.billDiscount;
                purchasemasterinfo.grandTotal = p.grandTotal;
                purchasemasterinfo.totalAmount = p.totalAmount;
                purchasemasterinfo.userId = p.userId;
                purchasemasterinfo.lrNo = p.lrNo;
                purchasemasterinfo.transportationCompany = p.transportationCompany;
                purchasemasterinfo.financialYearId = p.financialYearId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return purchasemasterinfo;
        }

        public void PurchaseMasterEdit(PurchaseMaster p)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PurchaseMasterEdit(
                    p.purchaseMasterId,
                    p.voucherNo,
                    p.invoiceNo,
                    p.suffixPrefixId,
                    p.voucherTypeId,
                    p.date,
                    p.ledgerId,
                    p.vendorInvoiceNo,
                    p.vendorInvoiceDate,
                    p.creditPeriod,
                    p.exchangeRateId,
                    p.narration,
                    p.purchaseAccount,
                    p.purchaseOrderMasterId,
                    p.materialReceiptMasterId,
                    p.additionalCost,
                    p.totalTax,
                    p.billDiscount,
                    p.grandTotal,
                    p.totalAmount,
                    p.userId,
                    p.lrNo,
                    p.transportationCompany,
                    p.financialYearId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void PurchaseMasterDelete(decimal PurchaseMasterId)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PurchaseMasterDelete(PurchaseMasterId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
