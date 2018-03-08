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

        public DataTable SettinsCheckReference()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.SettinsCheckReference().ToList();

                dtbl.Columns.Add("CurrencyExist");
                dtbl.Columns.Add("Godown");
                dtbl.Columns.Add("Rack");
                dtbl.Columns.Add("BillByBillExist");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["CurrencyExist"] = item.CurrencyExist;
                    row["Godown"] = item.Godown;
                    row["Rack"] = item.Rack;
                    row["BillByBillExist"] = item.BillByBillExist;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public decimal SettingsGetId(string strsettingsName)
        {
            IMEEntities IME = new IMEEntities();
            decimal decSettingsId = 0;
            try
            {
                decSettingsId = Convert.ToDecimal(IME.SettingsGetId(strsettingsName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decSettingsId;
        }

        public void SettingsEdit(Setting si)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.SettingsEdit(si.status, si.settingsId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable SettingsViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.SettingsViewAll();


                dtbl.Columns.Add("settingsId");
                dtbl.Columns.Add("settingsName");
                dtbl.Columns.Add("status");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["settingsId"] = item.settingsId;
                    row["settingsName"] = item.settingsName;
                    row["status"] = item.status;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable SettingsToCopyViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.SettingsToCopyViewAll();


                dtbl.Columns.Add("settingsId");
                dtbl.Columns.Add("settingsName");
                dtbl.Columns.Add("status");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["settingsId"] = item.settingsId;
                    row["settingsName"] = item.settingsName;
                    row["status"] = item.status;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public Setting SettingsToCopyView(string strsettingsName)
        {
            IMEEntities db = new IMEEntities();
            Setting settingsinfo = new Setting();
            
            try
            {
                var a = db.SettingsToCopyView(strsettingsName).FirstOrDefault();

                settingsinfo.settingsId = a.settingsId;
                settingsinfo.settingsName = a.settingsName;
                settingsinfo.status = a.status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return settingsinfo;
        }

        public Setting SettingsView(string strsettingsName)
        {
            IMEEntities db = new IMEEntities();
            Setting settingsinfo = new Setting();
            
            try
            {
                var a = db.SettingsView(strsettingsName).FirstOrDefault();

                settingsinfo.settingsId = a.settingsId;
                settingsinfo.settingsName = a.settingsName;
                settingsinfo.status = a.status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return settingsinfo;
        }
    }
}
