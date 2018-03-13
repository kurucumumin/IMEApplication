using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginForm
{
    class DailySalaryVoucherDetailsSP
    {
        public DataTable DailySalaryVoucherDetailsGridViewAll(string strSalaryDate, bool isEditMode, string strVoucherNumber)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl.No", typeof(decimal));
            dtbl.Columns["Sl.No"].AutoIncrement = true;
            dtbl.Columns["Sl.No"].AutoIncrementSeed = 1;
            dtbl.Columns["Sl.No"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.DailySalaryVoucherDetailsGridViewall(Convert.ToDateTime(strSalaryDate), Convert.ToDecimal(isEditMode), strVoucherNumber).ToList();

                dtbl.Columns.Add("WorkerID");
                dtbl.Columns.Add("NameLastName");
                dtbl.Columns.Add("UserName");
                dtbl.Columns.Add("dailyWage");
                dtbl.Columns.Add("attendance");
                dtbl.Columns.Add("status");
                dtbl.Columns.Add("DetailsId");
                dtbl.Columns.Add("MasterId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["WorkerID"] = item.WorkerID;
                    row["NameLastName"] = item.NameLastName;
                    row["UserName"] = item.UserName;
                    row["dailyWage"] = item.dailyWage;
                    row["attendance"] = item.attendance;
                    row["status"] = item.status;
                    row["DetailsId"] = item.DetailsId;
                    row["MasterId"] = item.MasterId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public string CheckWhetherDailySalaryAlreadyPaid(decimal decEmployeeId, DateTime SalaryDate)
        {
            IMEEntities IME = new IMEEntities();
            string strName = string.Empty;
            try
            {
                strName = IME.CheckWhetherDailySalaryAlreadyPaid(decEmployeeId, SalaryDate).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strName;
        }

        public void DailySalaryVoucherDetailsAdd(DailySalaryVoucherDetail ds)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.DailySalaryVoucherDetailsAdd(ds.dailySalaryVoucherMasterId,
                    ds.employeeId,
                    ds.wage,
                    ds.status);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DailySalaryVoucherDetailsDelete(decimal DailySalaryVoucherDetailsId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.DailySalaryVoucherDetailsDelete(DailySalaryVoucherDetailsId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public int DailySalaryVoucherDetailsCount(decimal decMasterId)
        {
            IMEEntities IME = new IMEEntities();
            int max = 0;
            try
            {
                max = Convert.ToInt32(IME.DailySalaryVoucherDetailsCount(decMasterId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public void DailySalaryVoucherDetailsDeleteUsingMasterId(decimal DailySalaryVoucherDetailsMasterId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.DailySalaryVoucherDetailsDeleteUsingMasterId(DailySalaryVoucherDetailsMasterId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
