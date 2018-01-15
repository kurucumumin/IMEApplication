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
    class PurchaseReturnMasterSP
    {
        public decimal PurchaseReturnMasterGetMaxPlusOne(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal max = 0;
            try
            {
                decimal? adapter = (from pr in IME.PurchaseReturnMasters.Where(p => p.voucherTypeId == decVoucherTypeId)
                                    select new { pr.voucherNo }).Max(x => Convert.ToDecimal(x.voucherNo));

                max = (adapter != null) ? (decimal)adapter : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public string PurchaseReturnMasterGetMax(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            string max = "0";
            try
            {
                int? adapter = (from dn in IME.PurchaseReturnMasters.Where(p => p.voucherTypeId == decVoucherTypeId)
                                select new { dn.voucherNo }).Max(x => Convert.ToInt32(x.voucherNo));

                max = ((adapter != null) ? (int)adapter : 0).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public string TaxRateFromPurchaseDetails(decimal taxId)
        {
            IMEEntities IME = new IMEEntities();
            string taxRate = string.Empty; ;
            try
            {
                taxRate = (from t in IME.Taxes
                           from p in IME.PurchaseDetails.Where(x => x.taxId == t.TaxID)
                           where p.taxId == taxId
                           select new { t.Rate }).FirstOrDefault().Rate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return taxRate; ;
        }

        public bool PurchaseReturnNumberCheckExistence(string strinvoiceNo, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            bool isEdit = false;
            try
            {
                var list = from x in IME.PurchaseReturnMasters
                           where x.invoiceNo == strinvoiceNo && x.voucherTypeId == decVoucherTypeId && x.suffixPrefixId == 0
                           select new { x.voucherNo };
                isEdit = (list.Count() > 0) ? true : false;
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }
            return isEdit;
        }

        public decimal PurchaseReturnMasterAddWithReturnIdentity(PurchaseReturnMaster purchasereturnmasterinfo)
        {
            IMEEntities db = new IMEEntities();
            PurchaseReturnMaster prm = purchasereturnmasterinfo;
            decimal decIdentity = 0;
            try
            {
                db.PurchaseReturnMasters.Add(prm);
                db.SaveChanges();
                decIdentity = prm.purchaseReturnMasterId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public void PurchaseReturnMasterEdit(PurchaseReturnMaster pi)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                PurchaseReturnMaster pdc = IME.PurchaseReturnMasters.Where(pd => pi.purchaseReturnMasterId == pd.purchaseReturnMasterId).FirstOrDefault();

                pdc.purchaseReturnMasterId = pi.purchaseReturnMasterId;
                pdc.voucherNo = pi.voucherNo;
                pdc.invoiceNo = pi.invoiceNo;
                pdc.voucherTypeId = pi.voucherTypeId;
                pdc.suffixPrefixId = pi.suffixPrefixId;
                pdc.purchaseMasterId = pi.purchaseMasterId;
                pdc.date = pi.date;
                pdc.ledgerId = pi.ledgerId;
                pdc.discount = pi.discount;
                pdc.narration = pi.narration;
                pdc.purchaseAccount = pi.purchaseAccount;
                pdc.totalTax = pi.totalTax;
                pdc.totalAmount = pi.totalAmount;
                pdc.grandTotal = pi.grandTotal;
                pdc.userId = pi.userId;
                pdc.lrNo = pi.lrNo;
                pdc.transportationCompany = pi.transportationCompany;
                pdc.financialYearId = pi.financialYearId;
                pdc.exchangeRateId = pi.exchangeRateId;
                

                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public PurchaseReturnMaster PurchaseReturnMasterView(decimal purchaseReturnMasterId)
        {
            IMEEntities IME = new IMEEntities();
            PurchaseReturnMaster purchasereturnmasterinfo = new PurchaseReturnMaster();
            
            try
            {
                purchasereturnmasterinfo = IME.PurchaseReturnMasters.Where(x => x.purchaseReturnMasterId == purchaseReturnMasterId).FirstOrDefault();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return purchasereturnmasterinfo;
        }

        public void PurchaseReturnMasterAndDetailsDelete(decimal decPurchaseReturnMasterId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.PurchaseReturnMasterAndDetailsDelete(decPurchaseReturnMasterId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable PurchaseReturnViewByPurchaseReturnMasterId(decimal decPurchaseReturnMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.PurchaseReturnViewByPurchaseReturnMasterId(decPurchaseReturnMasterId);

                dtbl.Columns.Add("purchaseReturnMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("purchaseMasterId");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("purchaseAccount");
                dtbl.Columns.Add("totalTax");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("lrNo");
                dtbl.Columns.Add("transportationCompany");
                dtbl.Columns.Add("financialYearId");
                dtbl.Columns.Add("exchangeRateId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["purchaseReturnMasterId"] = item.purchaseReturnMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["suffixPrefixId"] = item.suffixPrefixId;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["date"] = item.date;
                    row["purchaseMasterId"] = item.purchaseMasterId;
                    row["ledgerId"] = item.ledgerId;
                    row["discount"] = item.discount;
                    row["narration"] = item.narration;
                    row["purchaseAccount"] = item.purchaseAccount;
                    row["totalTax"] = item.totalTax;
                    row["totalAmount1"] = item.totalAmount;
                    row["invoiceNo"] = item.invoiceNo;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["totalAmount"] = item.totalAmount;
                    row["userId"] = item.userId;
                    row["lrNo"] = item.lrNo;
                    row["transportationCompany"] = item.transportationCompany;
                    row["financialYearId"] = item.financialYearId;
                    row["exchangeRateId"] = item.exchangeRateId;


                    dtbl.Rows.Add(row);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public DataTable PurchaseReturnMasterViewByPurchaseMasterId(decimal decPurchaseMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.PurchaseReturnMasterViewAllByPurchaseMasterId(decPurchaseMasterId);

                dtbl.Columns.Add("purchaseReturnMasterId");
                dtbl.Columns.Add("voucherNo");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();
                    row["purchaseReturnMasterId"] = item.purchaseReturnMasterId;
                    row["totalAmount"] = item.totalAmount;


                    dtbl.Rows.Add(row);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }
    }
}
