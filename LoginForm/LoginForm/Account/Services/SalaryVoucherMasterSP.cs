using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Reflection;

namespace LoginForm.Account.Services
{
    class SalaryVoucherMasterSP
    {
        public DataTable SalaryVoucherMasterViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                dtbl.Columns.Add("salaryVoucherMasterId");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("month");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("financialYearId");
                DataRow row = null;
                foreach (var item in IME.SalaryVoucherMasterViewAll())
                {
                    row = dtbl.NewRow();
                    row["amount"] = item.salaryVoucherMasterId;
                    row["amount"] = item.ledgerId;
                    row["amount"] = item.voucherNo;
                    row["amount"] = item.date;
                    row["amount"] = item.invoiceNo;
                    row["amount"] = item.month;
                    row["amount"] = item.totalAmount;
                    row["amount"] = item.narration;
                    row["amount"] = item.suffixPrefixId;
                    row["amount"] = item.voucherTypeId;
                    row["amount"] = item.financialYearId;
                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return dtbl;
        }

        public DataTable MonthlySalaryRegisterSearch(DateTime dtdateFrom, DateTime dtdateTo, DateTime dtMonth, string strVoucherNo, string strLedgerName, string strVoucherTypeName)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl No", typeof(decimal));
            dtbl.Columns["Sl No"].AutoIncrement = true;
            dtbl.Columns["Sl No"].AutoIncrementSeed = 1;
            dtbl.Columns["Sl No"].AutoIncrementStep = 1;
            try
            {
                dtbl.Columns.Add("amount");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("financialYearId");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("month");
                dtbl.Columns.Add("salaryVoucherMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("voucherTypeName");
                DataRow drow = null;
                foreach (var item in IME.MonthlySalaryRegisterSearch(dtdateFrom,dtdateTo,dtMonth,strVoucherNo,strLedgerName,strVoucherTypeName))
                {
                    drow = dtbl.NewRow();
                    drow["amount"] = item.amount;
                    drow["date"] = item.date;
                    drow["financialYearId"] = item.financialYearId;
                    drow["invoiceNo"] = item.invoiceNo;
                    drow["ledgerId"] = item.ledgerId;
                    drow["ledgerName"] = item.ledgerName;
                    drow["month"] = item.month;
                    drow["salaryVoucherMasterId"] = item.salaryVoucherMasterId;
                    drow["voucherNo"] = item.voucherNo;
                    drow["voucherTypeName"] = item.voucherTypeName;
                    dtbl.Rows.Add(drow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public System.Data.DataSet PaySlipPrinting(decimal decEmployeeId, DateTime dsSalaryMonth, decimal decCompanyId)
        {
            IMEEntities IME = new IMEEntities();
            System.Data.DataSet dSt = new System.Data.DataSet();

            var Result1 = IME.PaySlipPrinting(decEmployeeId, dsSalaryMonth, decCompanyId);
            var Result2 = IME.PaySlipPrinting_2(decEmployeeId, dsSalaryMonth, decCompanyId);
            var Result3 = IME.PaySlipPrinting_3(decEmployeeId, dsSalaryMonth, decCompanyId);
            DataTable dt1 = new DataTable();
            
            //result1
            #region result1
            DataTable dtbl1 = new DataTable();

            dtbl1.Columns.Add("companyId");
            dtbl1.Columns.Add("companyName");
            dtbl1.Columns.Add("mailingName");
            dtbl1.Columns.Add("address");
            dtbl1.Columns.Add("phone");
            dtbl1.Columns.Add("mobile");
            dtbl1.Columns.Add("email");
            dtbl1.Columns.Add("web");
            dtbl1.Columns.Add("country");
            dtbl1.Columns.Add("state");
            dtbl1.Columns.Add("pin");
            dtbl1.Columns.Add("currencyId");
            dtbl1.Columns.Add("tin");
            dtbl1.Columns.Add("cst");
            dtbl1.Columns.Add("pan");
            foreach (var item in Result1)
            { 
                var row = dtbl1.NewRow();
                row["companyId"] = item.address;
                row["companyName"] = item.address;
                row["mailingName"] = item.address;
                row["address"] = item.address;
                row["phone"] = item.address;
                row["mobile"] = item.address;
                row["email"] = item.address;
                row["web"] = item.address;
                row["country"] = item.address;
                row["state"] = item.address;
                row["pin"] = item.address;
                row["currencyId"] = item.address;
                row["tin"] = item.address;
                row["cst"] = item.address;
                row["pan"] = item.address;
                dtbl1.Rows.Add(row);
            }
            dSt.Tables.Add(dtbl1);
            #endregion

            //RESULT 2


            DataTable dtbl2 = new DataTable();

            dtbl2.Columns.Add("WorkerId");
            dtbl2.Columns.Add("NameLastName");
            dtbl2.Columns.Add("designationId");
            dtbl2.Columns.Add("designationName");
            dtbl2.Columns.Add("leaveDays");
            dtbl2.Columns.Add("Month");
            dtbl2.Columns.Add("Date");
            dtbl2.Columns.Add("payHeadId");
            dtbl2.Columns.Add("ADDpayheadName");
            dtbl2.Columns.Add("ADDamount");
            dtbl2.Columns.Add("DEDpayheadName");
            dtbl2.Columns.Add("DEDamount");
            dtbl2.Columns.Add("Advance");
            dtbl2.Columns.Add("Bonus");
            dtbl2.Columns.Add("Deduction");
            dtbl2.Columns.Add("LOP"); 
            dtbl2.Columns.Add("Salary");
            foreach (var item in Result2)
            {
                var row = dtbl2.NewRow();
                row["companyId"] = item.WorkerId;

                row["NameLastName"] =item.NameLastName;
                row["designationId"] = item.designationId;
                row["designationName"] = item.designationName;
                row["leaveDays"] = item.leaveDays;
                row["Month"] = item.Month;
                row["Date"] = item.Date;
                row["payHeadId"] = item.payHeadId;
                row["ADDpayheadName"] = item.ADDpayheadName;
                row["ADDamount"] = item.ADDamount;
                row["DEDpayheadName"] = item.DEDpayheadName;
                row["DEDamount"] = item.DEDamount;
                row["Advance"] = item.Advance;
                row["Bonus"] = item.Bonus;
                row["Deduction"] = item.Deduction;
                row["LOP"] = item.LOP;
                row["Salary"] = item.Salary;
                dtbl2.Rows.Add(row);
            }
            dSt.Tables.Add(dtbl2);



            DataTable dtbl3 = new DataTable();

            dtbl3.Columns.Add("WorkerId");
            dtbl3.Columns.Add("WorkingDay");
            dtbl3.Columns.Add("LeaveDays");
            dtbl3.Columns.Add("PresentDays");
           
            foreach (var item in Result3)
            {
                var row = dtbl3.NewRow();
                row["WorkerId"] = item.WorkerId;
                row["WorkingDay"] = item.WorkingDay;
                row["LeaveDays"] = item.LeaveDays;
                row["PresentDays"] = item.PresentDays;
                
                dtbl3.Rows.Add(row);
            }
            dSt.Tables.Add(dtbl3);


            //



            return dSt;
        }

        public SalaryVoucherMaster SalaryVoucherMasterView(decimal salaryVoucherMasterId)
        {
            SalaryVoucherMaster salaryvouchermasterinfo = new SalaryVoucherMaster();
           
            try
            {
                IMEEntities db = new IMEEntities();

                var svm = db.SalaryVoucherMasterView(salaryVoucherMasterId).FirstOrDefault();

                    salaryvouchermasterinfo.salaryVoucherMasterId = svm.salaryVoucherMasterId;
                    salaryvouchermasterinfo.ledgerId =svm.ledgerId;
                    salaryvouchermasterinfo.voucherNo = svm.voucherNo;
                    salaryvouchermasterinfo.invoiceNo = svm.invoiceNo;
                    salaryvouchermasterinfo.date = svm.date;
                    salaryvouchermasterinfo.month = svm.month;
                    salaryvouchermasterinfo.totalAmount = svm.totalAmount;
                    salaryvouchermasterinfo.narration = svm.narration;
                    salaryvouchermasterinfo.suffixPrefixId = svm.suffixPrefixId;
                    salaryvouchermasterinfo.voucherTypeId = svm.voucherTypeId;
                    salaryvouchermasterinfo.financialYearId = svm.financialYearId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return salaryvouchermasterinfo;
        }

        public DataTable MonthlySalaryVoucherMasterAddWithIdentity(SalaryVoucherMaster salaryvouchermasterinfo, bool IsAutomatic)
        {
            DataTable dtbl = new DataTable();
            try
            {
                IMEEntities db = new IMEEntities();
                db.MonthlySalaryVoucherMasterAddWithIdentity
                    (
                    salaryvouchermasterinfo.ledgerId,
                    salaryvouchermasterinfo.voucherNo,
                    salaryvouchermasterinfo.invoiceNo,
                    salaryvouchermasterinfo.date,
                    salaryvouchermasterinfo.month,
                    salaryvouchermasterinfo.totalAmount,
                    salaryvouchermasterinfo.narration,
                    salaryvouchermasterinfo.suffixPrefixId,
                    salaryvouchermasterinfo.voucherTypeId,
                    salaryvouchermasterinfo.financialYearId,
                    IsAutomatic
                    );
                db.SaveChanges();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }

        public string SalaryVoucherMasterGetMax(decimal decVoucherTypeId)
        {
            string max = "0";
            try
            {
                IMEEntities db = new IMEEntities();
                max= db.SalaryVoucherMasterMax(decVoucherTypeId).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return max;
        }

        public void SalaryVoucherMasterEdit(SalaryVoucherMaster salaryvouchermasterinfo)
        {
            try
            {
                IMEEntities db = new IMEEntities();
                db.SalaryVoucherMasterEdit(
                    salaryvouchermasterinfo.salaryVoucherMasterId,
                    salaryvouchermasterinfo.ledgerId, 
                    salaryvouchermasterinfo.voucherNo,
                    salaryvouchermasterinfo.invoiceNo,
                    salaryvouchermasterinfo.date,
                    salaryvouchermasterinfo.month,
                    salaryvouchermasterinfo.totalAmount,
                    salaryvouchermasterinfo.narration,
                    salaryvouchermasterinfo.suffixPrefixId,
                    salaryvouchermasterinfo.voucherTypeId,
                    salaryvouchermasterinfo.financialYearId
                    );
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }

        public void SalaryVoucherMasterDelete(decimal SalaryVoucherMasterId)
        {
            try
            {
                IMEEntities db = new IMEEntities();
                db.SalaryVoucherMasterDelete(SalaryVoucherMasterId);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        public decimal SalaryVoucherMasterGetMaxPlusOne(decimal decVoucherTypeId)
        {
            decimal max = 0;
            try
            {
                IMEEntities db = new IMEEntities();
              
                max = Convert.ToDecimal(db.SalaryVoucherMasterMax(decVoucherTypeId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max + 1;
        }
    }
}
