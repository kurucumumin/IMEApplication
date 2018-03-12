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
    class DailyAttendanceDetailsSP
    {
        public void DailyAttendanceDetailsAddUsingMasterId(DailyAttendanceDetailsInfo dailyattendancedetailsinfo)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.DailyAttendanceDetailsAddUsingMasterId
                    (
                    dailyattendancedetailsinfo.DailyAttendanceMasterId, dailyattendancedetailsinfo.WorkerID,dailyattendancedetailsinfo.Status, dailyattendancedetailsinfo.Narration
                    );
                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        public DataTable DailyAttendanceDetailsSearchGridFill(string strDate)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtblAttendance = new DataTable();
            dtblAttendance.Columns.Add("Sl NO", typeof(decimal));
            dtblAttendance.Columns["Sl NO"].AutoIncrement = true;
            dtblAttendance.Columns["Sl NO"].AutoIncrementSeed = 1;
            dtblAttendance.Columns["Sl NO"].AutoIncrementStep = 1;


            dtblAttendance.Columns.Add("budgetMasterId");
            dtblAttendance.Columns.Add("budgetName");
            foreach (var item in IME.DailyAttendanceDetailsSearchGridFill(DateTime.Parse(strDate)))
            {
                var row = dtblAttendance.NewRow();

                row["budgetMasterId"] = item.WorkerId;
                row["budgetName"] = item.NameLastName;

                dtblAttendance.Rows.Add(row);
            }

            return dtblAttendance;
        }

        public void DailyAttendanceDetailsEditUsingMasterId(DailyAttendanceDetailsInfo dailyattendancedetailsinfo)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.DailyAttendanceDetailsEditUsingMasterId
                    (dailyattendancedetailsinfo.DailyAttendanceDetailsId, dailyattendancedetailsinfo.DailyAttendanceMasterId, dailyattendancedetailsinfo.WorkerID, dailyattendancedetailsinfo.Status, dailyattendancedetailsinfo.Narration);
                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DailyAttendanceDetailsDeleteAll(decimal decdailyAttendanceMasterId)
        {
            IMEEntities IME = new IMEEntities(); 
            try
            {
                IME.DailyAttendanceDetailsDeleteAll(decdailyAttendanceMasterId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
    }
}
