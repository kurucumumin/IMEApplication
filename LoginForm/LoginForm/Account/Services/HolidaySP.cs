using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class HolidaySP
    {
        public decimal HolliDayChecking(DateTime date)
        {
            IMEEntities IME = new IMEEntities();
            decimal decResult = 0;
            try
            {
                if (IME.HolliDayChecking(date) != null)
                {
                    int? datee = IME.HolliDayChecking(date).FirstOrDefault();
                    decResult = Convert.ToDecimal(datee);
                }
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decResult;
        }

        public DataTable HoildaySettingsViewAllLimited(string strMonth, string strYear)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtblHolidaySettings = new DataTable();

            dtblHolidaySettings.Columns.Add("Date");
            dtblHolidaySettings.Columns.Add("Narration");
            foreach (var item in IME.HoildaySettingsViewAllLimited(strMonth,strYear))
            {
                var row = dtblHolidaySettings.NewRow();

                row["Date"] = item.date;
                row["Narration"] = item.narration;

                dtblHolidaySettings.Rows.Add(row);
            }

            return dtblHolidaySettings;
        }

        public bool HolidayAddWithIdentity(HolidayInfo holidayinfo)
        {
            IMEEntities IME = new IMEEntities();
            bool isSave = true;
            try
            {
                IME.HolidayAddWithIdentity(holidayinfo.Date, holidayinfo.HolidayName, holidayinfo.Narration);
                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                isSave = false;
            }
            
            return isSave;
        }

        public void HolidaySettingsDeleteByMonth(string strMonth, string strYear)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.HolidaySettingsDeleteByMonth(strMonth, strYear);
                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
