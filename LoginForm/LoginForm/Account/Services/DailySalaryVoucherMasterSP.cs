using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginForm
{
    class DailySalaryVoucherMasterSP
    {
        public DataTable DailySalaryVoucherCashOrBankLedgersComboFill()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            
            try
            {
                var adaptor = IME.CashOrBankComboFill().ToList();

                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("ledgerName");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["accountGroupId"] = item.ledgerId;
                    row["accountGroupName"] = item.ledgerName;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return dtbl;
        }

        public DailySalaryVoucherMaster DailySalaryVoucherViewFromRegister(decimal decDailySalaryVoucehrMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DailySalaryVoucherMaster ds = new DailySalaryVoucherMaster();
            
            try
            {
                var a = IME.DailySalaryVoucherViewFromRegister(decDailySalaryVoucehrMasterId).FirstOrDefault();

                ds.date = a.date;
                ds.voucherNo = a.voucherNo;
                ds.salaryDate = a.salaryDate;
                ds.ledgerId = a.ledgerId;
                ds.totalAmount = a.totalAmount;
                ds.narration = a.narration;
                ds.invoiceNo = a.invoiceNo;
                ds.voucherTypeId = a.voucherTypeId;
                ds.suffixPrefixId = a.suffixPrefixId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ds;
        }

        public bool DailySalaryVoucherCheckExistence(string voucherNumber, decimal voucherTypeId, decimal masterId)
        {
            IMEEntities IME = new IMEEntities();
            bool trueOrfalse = false;
            try
            {
                object obj = IME.DailySalaryVoucherCheckExistence(voucherNumber, voucherTypeId, masterId).ToString();

                if (obj != null)
                {
                    if (int.Parse(obj.ToString()) == 0)
                    {
                        trueOrfalse = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }

            return trueOrfalse;
        }

        public DataTable DailySalaryVoucherMasterAddWithIdentity(DailySalaryVoucherMaster ds, bool IsAutomatic)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {

                var adaptor = IME.DailySalaryVoucherMasterAddWithIdentity(ds.ledgerId,
                    ds.voucherNo,
                    ds.invoiceNo,
                    ds.date,
                    ds.salaryDate,
                    ds.totalAmount,
                    ds.narration,
                    ds.suffixPrefixId,
                    ds.voucherTypeId,
                    ds.financialYearId,
                    IsAutomatic).ToList();

                dtbl.Columns.Add("Identity");
                dtbl.Columns.Add("UpdatedVoucherNo");
                dtbl.Columns.Add("UpdatedInvoiceNo");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["Identity"] = item.Identity;
                    row["UpdatedVoucherNo"] = item.UpdatedVoucherNo;
                    row["UpdatedInvoiceNo"] = item.UpdatedInvoiceNo;


                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public string DailySalaryVoucherMasterGetMax(decimal voucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            string max = "0";
            try
            {
                max = IME.DailySalaryVoucherMasterMax(voucherTypeId).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return max;
        }

        public void DailySalaryVoucherMasterEdit(DailySalaryVoucherMaster ds)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.DailySalaryVoucherMasterEdit(ds.dailySalaryVoucherMasterId,
                    ds.ledgerId,
                    ds.voucherNo,
                    ds.invoiceNo,
                    ds.date,
                    ds.salaryDate,
                    ds.totalAmount,
                    ds.narration,
                    ds.suffixPrefixId,
                    ds.voucherTypeId,
                    ds.financialYearId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        public void DailySalaryVoucherMasterDelete(decimal DailySalaryVoucehrMasterId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.DailySalaryVoucherMasterDelete(DailySalaryVoucehrMasterId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal SalaryVoucherMasterGetMaxPlusOne(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal max = 0;
            try
            {
                max = Convert.ToDecimal(IME.SalaryVoucherMasterMax(decVoucherTypeId));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return max;
        }

        public DataTable DailySalaryRegisterSearch(DateTime dtVoucherDateFrom, DateTime dtVoucherDateTo, DateTime dtSalaryDateFrom, DateTime dtSalaryDateTo, string strInvoiceNo)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.DailySalaryRegisterSearch(dtVoucherDateFrom, dtVoucherDateTo, dtSalaryDateFrom, dtSalaryDateTo, strInvoiceNo).ToList();

                dtbl.Columns.Add("date");
                dtbl.Columns.Add("salaryDate");
                dtbl.Columns.Add("dailySalaryVoucherMasterId");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["date"] = item.date;
                    row["salaryDate"] = item.salaryDate;
                    row["dailySalaryVoucherMasterId"] = item.dailySalaryVoucherMasterId;
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
    }
}
