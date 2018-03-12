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
    class DailyAttendanceMasterSP
    {

        public bool DailyAttendanceMasterMasterIdSearch(string strDate)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                if (IME.DailyAttendanceMasterMasterIdSearch(strDate) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          return false;
        }

        public decimal DailyAttendanceAddToMaster(DailyAttendanceMasterInfo dailyattendancemasterinfo)
        {
            IMEEntities IME = new IMEEntities();
            decimal incount = 0;
            try
            {
                incount=Decimal.Parse(IME.DailyAttendanceAddToMaster(dailyattendancemasterinfo.Date, dailyattendancemasterinfo.Narration).ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
            return incount;
        }

        public void DailyAttendanceEditMaster(DailyAttendanceMasterInfo dailyattendancemasterinfo)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.DailyAttendanceEditMaster(dailyattendancemasterinfo.DailyAttendanceMasterId, dailyattendancemasterinfo.Date, dailyattendancemasterinfo.Narration);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
