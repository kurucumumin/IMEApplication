using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm.Account.Services
{
    class SettingsSP
    {
        public string SettingsStatusCheck(string strSettingsName)
        {
            IMEEntities db = new IMEEntities();

            string strStatus = string.Empty;
            try
            {
                strStatus = db.Settings.Where(x => x.settingsName == strSettingsName).FirstOrDefault().status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strStatus;
        }
    }
}
