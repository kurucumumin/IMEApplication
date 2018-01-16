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
    class SalesReturnMasterSP
    {

        public void VoucherTypeComboFillOfSalesReturnReport(ComboBox cmbVoucherType, string strVoucherType, bool isAll)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from vt in IME.VoucherTypes.Where(x => x.voucherTypeName==strVoucherType && isAll==true)
                               select new { vt.voucherTypeId,vt.voucherTypeName }).ToList();

                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("voucherTypeName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["voucherTypeId"] = item.voucherTypeId;
                    row["voucherTypeName"] = item.voucherTypeName;

                    dtbl.Rows.Add(row);
                }
                cmbVoucherType.DataSource = dtbl;
                cmbVoucherType.ValueMember = "voucherTypeId";
                cmbVoucherType.DisplayMember = "voucherTypeName";
                cmbVoucherType.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SalesManComboFillOfSalesReturnReport(ComboBox cmbSalesMan, bool isAll)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from vt in IME.Workers
                               select new { vt.WorkerID, vt.UserName }).ToList();

                dtbl.Columns.Add("WorkerID");
                dtbl.Columns.Add("UserName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["WorkerID"] = item.WorkerID;
                    row["UserName"] = item.UserName;

                    dtbl.Rows.Add(row);
                }
                cmbSalesMan.DataSource = dtbl;
                cmbSalesMan.ValueMember = "WorkerID";
                cmbSalesMan.DisplayMember = "UserName";
                cmbSalesMan.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable SalesReturnReportGrideFill(DateTime fromDate, DateTime toDate, decimal decLedgerId, decimal decVoucherTypeId, decimal decEmployeeId, string strProductCode, string strVoucherNo)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.SalesReturnReportGrideFill(fromDate, toDate, decLedgerId, decVoucherTypeId, strVoucherNo, decEmployeeId, strProductCode);

                dtbl.Columns.Add("salesReturnMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("salesMasterId");
                dtbl.Columns.Add("voucherTypeName");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("UserName");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("grandTotal");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["salesReturnMasterId"] = item.salesReturnMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["salesMasterId"] = item.salesMasterId;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["date"] = item.date;
                    row["UserName"] = item.userName;
                    row["ledgerName"] = item.ledgerName;
                    row["grandTotal"] = item.grandTotal;
                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable SalesReturnMasterViewBySalesReturnMasterId(decimal decSalesReturnMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {

                var adaptor = (from st in IME.SalesReturnMasters
                               from s in IME.SalesMasters.Where(x => x.salesMasterId == st.salesMasterId).DefaultIfEmpty()
                               where st.salesReturnMasterId == decSalesReturnMasterId
                               select new {
                                   st.salesReturnMasterId,
                                   st.voucherNo,
                                   st.invoiceNo,
                                   st.voucherTypeId,
                                   st.salesMasterId,
                                   st.date,
                                   st.ledgerId,
                                   st.salesAccount,
                                   st.pricinglevelId,
                                   st.narration,
                                   st.exchangeRateId,
                                   st.lrNo,
                                   st.transportationCompany,
                                   st.totalAmount,
                                   st.discount,
                                   st.taxAmount,
                                   st.userId,
                                   st.suffixPrefixId,
                                   TotalAmount= s.totalAmount,
                                   SMVoucherTypeId= s.voucherTypeId,
                                   st.grandTotal}).ToList();

                dtbl.Columns.Add("salesReturnMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("salesMasterId");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("salesAccount");
                dtbl.Columns.Add("pricinglevelId");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("exchangeRateId");
                dtbl.Columns.Add("lrNo");
                dtbl.Columns.Add("transportationCompany");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("discount");
                dtbl.Columns.Add("taxAmount");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("TotalAmount");
                dtbl.Columns.Add("SMVoucherTypeId");
                dtbl.Columns.Add("grandTotal");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["salesReturnMasterId"] = item.salesReturnMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["salesMasterId"] = item.salesMasterId;
                    row["date"] = item.date;
                    row["ledgerId"] = item.ledgerId;
                    row["salesAccount"] = item.salesAccount;
                    row["pricinglevelId"] = item.pricinglevelId;
                    row["narration"] = item.narration;
                    row["exchangeRateId"] = item.exchangeRateId;
                    row["lrNo"] = item.lrNo;
                    row["transportationCompany"] = item.transportationCompany;
                    row["totalAmount"] = item.totalAmount;
                    row["discount"] = item.discount;
                    row["taxAmount"] = item.taxAmount;
                    row["userId"] = item.userId;
                    row["suffixPrefixId"] = item.suffixPrefixId;
                    row["TotalAmount"] = item.TotalAmount;
                    row["SMVoucherTypeId"] = item.SMVoucherTypeId;
                    row["grandTotal"] = item.grandTotal;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public DataTable SalesReturnMasterViewBySalesMasterId(decimal decSalesMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {

                var adaptor = (from sr in IME.SalesReturnMasters
                               where sr.salesMasterId == decSalesMasterId
                               select new { sr.salesReturnMasterId }).ToList();

                dtbl.Columns.Add("salesReturnMasterId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();
                    row["salesReturnMasterId"] = item.salesReturnMasterId;
                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public string TaxRateFindForTaxAmmountCalByTaxId(decimal taxId)
        {
            IMEEntities IME = new IMEEntities();
            string taxRate = string.Empty; ;
            try
            {
                taxRate = (from t in IME.Taxes
                           from sd in IME.SalesDetails.Where(x => x.taxId == t.TaxID).DefaultIfEmpty()
                           where sd.taxId == taxId
                           select new { t.Rate }).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return taxRate; ;
        }

        public void SalesReturnDelete(decimal decSalesReturnMasterId, decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                List<PartyBalance> ListPb = db.PartyBalances.Where(x => (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "New") ||
                 (x.againstVoucherTypeId == decVoucherTypeId && x.againstVoucherNo == strVoucherNo && x.referenceType == "Against")).ToList();
                db.PartyBalances.RemoveRange(ListPb);
                db.SaveChanges();


                List<LedgerPosting> listLp = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();
                db.LedgerPostings.RemoveRange(listLp);
                db.SaveChanges();

                List<Stock> listS = db.Stocks.Where(x => (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo) ||
                 (x.againstVoucherTypeId == decVoucherTypeId && x.againstVoucherNo == strVoucherNo)).ToList();
                db.Stocks.RemoveRange(listS);
                db.SaveChanges();

                SalesReturnBillTax srb = db.SalesReturnBillTaxes.Where(x => x.salesReturnMasterId == decSalesReturnMasterId).FirstOrDefault();
                db.SalesReturnBillTaxes.Remove(srb);
                db.SaveChanges();

                SalesReturnDetail srd = db.SalesReturnDetails.Where(x => x.salesReturnMasterId == decSalesReturnMasterId).FirstOrDefault();
                db.SalesReturnDetails.Remove(srd);
                db.SaveChanges();

                SalesReturnMaster srm = db.SalesReturnMasters.Where(x => x.salesReturnMasterId == decSalesReturnMasterId).FirstOrDefault();
                db.SalesReturnMasters.Remove(srm);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool SalesReturnNumberCheckExistence(string strinvoiceNo, decimal decSalesReturnMasterId, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            bool isEdit = false;
            try
            {
                int count = IME.SalesReturnMasters.Where(x => x.invoiceNo == strinvoiceNo && x.suffixPrefixId == 0 && x.salesReturnMasterId != decSalesReturnMasterId && x.voucherTypeId == decVoucherTypeId).Count();

                isEdit = (count > 0) ? true : false;


            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }
            return isEdit;
        }

        public void SalesReturnMasterEdit(SalesReturnMaster pi)
        {
            IMEEntities IME = new IMEEntities();
            try
            {

                SalesReturnMaster pdc = IME.SalesReturnMasters.Where(pd => pi.salesReturnMasterId == pd.salesReturnMasterId).FirstOrDefault();

                pdc.salesReturnMasterId = pi.salesReturnMasterId;
                pdc.voucherNo = pi.voucherNo;
                pdc.invoiceNo = pi.invoiceNo;
                pdc.voucherTypeId = pi.voucherTypeId;
                pdc.suffixPrefixId = pi.suffixPrefixId;
                pdc.ledgerId = pi.ledgerId;
                pdc.salesMasterId = pi.salesMasterId;
                pdc.salesAccount = pi.salesAccount;
                pdc.pricinglevelId = pi.pricinglevelId;
                pdc.userId = pi.userId;
                pdc.narration = pi.narration;
                pdc.exchangeRateId = pi.exchangeRateId;
                pdc.discount = pi.discount;
                pdc.taxAmount = pi.taxAmount;
                pdc.lrNo = pi.lrNo;
                pdc.transportationCompany = pi.transportationCompany;
                pdc.date = pi.date;
                pdc.totalAmount = pi.totalAmount;
                pdc.financialYearId = pi.financialYearId;
                pdc.grandTotal = pi.grandTotal;

                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal SalesReturnMasterAdd(SalesReturnMaster salesreturnmasterinfo)
        {
            IMEEntities db = new IMEEntities();
            SalesReturnMaster srm = salesreturnmasterinfo;
            decimal decIdentity = 0;
            try
            {
                db.SalesReturnMasters.Add(srm);
                db.SaveChanges();
                decIdentity = srm.salesReturnMasterId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public DataTable SalesReturnInvoiceNoComboFill(decimal decVoucherTypeId, decimal salesReturnMasterId, decimal decledgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {


                var adaptor = IME.SalesReturnInvoiceNoComboFill(decledgerId, salesReturnMasterId, decVoucherTypeId);

                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("salesMasterId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["invoiceNo"] = item.invoiceNo;
                    row["salesMasterId"] = item.salesMasterId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable SalesReturnVoucherTypeComboFill(decimal ledgerIdFromCashOrPartyCombo)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.VoucherTypeViewAllByLedgerId(ledgerIdFromCashOrPartyCombo);

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

        public DataTable vouchertypecompofill()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from v in IME.VoucherTypes
                               where v.typeOfVoucher == "Sales Invoice"
                               select new
                               {
                                   v.voucherTypeId,
                                   v.voucherTypeName
                               }).ToList();

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

        public decimal SalesReturnMasterGetMaxPlusOne(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal max = 0;
            try
            {
                max = IME.SalesReturnMasters.Where(x => x.voucherTypeId == decVoucherTypeId).Select(x => Convert.ToDecimal(x.voucherNo)).Max();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public string SalesReturnMasterGetMax(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            string max = "0";
            try
            {
                max = IME.SalesReturnMasters.Where(x => x.voucherTypeId == decVoucherTypeId).Select(x => x.voucherNo).Max();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }
    }
}
