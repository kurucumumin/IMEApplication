using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LoginForm.DataSet;
using System.Windows;

namespace LoginForm.Account.Services
{
    class SalaryVoucherDetailsSP
    {
        //public SalaryVoucherMaster SalaryVoucherMasterView(decimal salaryVoucherMasterId)
        //{
        //    SalaryVoucherMaster salaryvouchermasterinfo = new SalaryVoucherMaster();

        //    try
        //    {
        //        if (sqlcon.State == ConnectionState.Closed)
        //        {
        //            sqlcon.Open();
        //        }
        //        SqlCommand sccmd = new SqlCommand("SalaryVoucherMasterView", sqlcon);
        //        sccmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter sprmparam = new SqlParameter();
        //        sprmparam = sccmd.Parameters.Add("@salaryVoucherMasterId", SqlDbType.Decimal);
        //        sprmparam.Value = salaryVoucherMasterId;
        //        sdrreader = sccmd.ExecuteReader();
        //        while (sdrreader.Read())
        //        {
        //            salaryvouchermasterinfo.SalaryVoucherMasterId = decimal.Parse(sdrreader[0].ToString());
        //            salaryvouchermasterinfo.LedgerId = decimal.Parse(sdrreader[1].ToString());
        //            salaryvouchermasterinfo.VoucherNo = sdrreader[2].ToString();
        //            salaryvouchermasterinfo.InvoiceNo = sdrreader[3].ToString();
        //            salaryvouchermasterinfo.Date = DateTime.Parse(sdrreader[4].ToString());
        //            salaryvouchermasterinfo.Month = DateTime.Parse(sdrreader[5].ToString());
        //            salaryvouchermasterinfo.TotalAmount = decimal.Parse(sdrreader[6].ToString());
        //            salaryvouchermasterinfo.Narration = sdrreader[7].ToString();
        //            salaryvouchermasterinfo.ExtraDate = DateTime.Parse(sdrreader[8].ToString());
        //            salaryvouchermasterinfo.Extra1 = sdrreader[9].ToString();
        //            salaryvouchermasterinfo.Extra2 = sdrreader[10].ToString();
        //            salaryvouchermasterinfo.SuffixPrefixId = decimal.Parse(sdrreader[11].ToString());
        //            salaryvouchermasterinfo.VoucherTypeId = decimal.Parse(sdrreader[12].ToString());
        //            salaryvouchermasterinfo.FinancialYearId = decimal.Parse(sdrreader[13].ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sdrreader.Close();
        //        sqlcon.Close();
        //    }
        //    return salaryvouchermasterinfo;
        //}
        public DataTable MonthlySalaryVoucherDetailsViewAll(string strMonth, string Month, string monthYear, bool isEditMode, string strVoucherNoforEdit)
        {
            IMEEntities IME = new IMEEntities();
            decimal decEditMode = 0;
            DataTable dtbl = new DataTable();

            try
            {
                if (isEditMode == true)
                {
                    decEditMode = 1;
                }
                else
                {
                    decEditMode = 0;
                    strVoucherNoforEdit = "0";
                }


                dtbl.Columns.Add("SlNo", typeof(decimal));
                dtbl.Columns["SlNo"].AutoIncrement = true;
                dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
                dtbl.Columns["SlNo"].AutoIncrementStep = 1;
                if (isEditMode == true)
                {
                    DataRow row = null;
                    ////TODO MonthlySalaryVoucherDetailViewAll tekrar bakılacak
                    foreach (var item in IME.MonthlySalaryVoucherDetailsViewAll(strMonth, Month, monthYear, decEditMode, strVoucherNoforEdit))
                    {

                        row = dtbl.NewRow();
                        row["voucherTypeId"] = item;
                        dtbl.Rows.Add(row);
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }

        public string CheckWhetherSalaryAlreadyPaid(decimal decEmployeeId, DateTime Month)
        {
            string strName = string.Empty;
            try
            {
                IMEEntities IME = new IMEEntities();
                strName = IME.CheckWhetherDailySalaryAlreadyPaid(decEmployeeId, Month).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strName;
        }

        public DataTable SalaryVoucherMasterViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();


            try
            {
                foreach (var item in IME.SalaryVoucherMasterViewAll())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return dtbl;
        }

        public void MonthlySalaryVoucherDetailsAdd(SalaryVoucherDetail salaryvoucherdetailsinfo)
        {
            try
            {
                IMEEntities db = new IMEEntities();
                db.SalaryVoucherDetailsAdd(
                    salaryvoucherdetailsinfo.salaryVoucherMasterId,
                    salaryvoucherdetailsinfo.employeeId
                    , salaryvoucherdetailsinfo.bonus
                    , salaryvoucherdetailsinfo.deduction,
                    salaryvoucherdetailsinfo.advance,
                    salaryvoucherdetailsinfo.lop,
                    salaryvoucherdetailsinfo.salary,
                    salaryvoucherdetailsinfo.status
                    );
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public void SalaryVoucherDetailsDelete(decimal SalaryVoucherDetailsId)
        {
            try
            {
                IMEEntities db = new IMEEntities();
                db.SalaryVoucherDetailsDelete(SalaryVoucherDetailsId);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }

        public int SalaryVoucherDetailsCount(decimal decMasterId)
        {
            int max = 0;
            try
            {
                IMEEntities db = new IMEEntities();
                max = Convert.ToInt32(db.SalaryVoucherDetailsCount(decMasterId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return max;
        }

        public void SalaryVoucherDetailsDeleteUsingMasterId(decimal SalaryVoucherDetailsMasterId)
        {
            try
            {
                IMEEntities db = new IMEEntities();
                db.SalaryVoucherDetailsDeleteUsingMasterId(SalaryVoucherDetailsMasterId);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
