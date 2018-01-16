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
            if(db.Settings.Where(x => x.settingsName == strSettingsName).FirstOrDefault()!=null)
            { 
                strStatus = db.Settings.Where(x => x.settingsName == strSettingsName).FirstOrDefault().status;
            }
            
            return strStatus;
        }
    }
}
