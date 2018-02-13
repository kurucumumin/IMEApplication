using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace LoginForm.Account.Services
{
    class ServiceSP
    {
        public DataTable ServiceViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SLNO", typeof(decimal));
            dtbl.Columns["SLNO"].AutoIncrement = true;
            dtbl.Columns["SLNO"].AutoIncrementSeed = 1;
            dtbl.Columns["SLNO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.ServiceViewAll();

                dtbl.Columns.Add("serviceId");
                dtbl.Columns.Add("serviceName");
                dtbl.Columns.Add("serviceCategoryId");
                dtbl.Columns.Add("rate");
                dtbl.Columns.Add("narration");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["serviceId"] = item.serviceId;
                    row["serviceName"] = item.serviceName;
                    row["serviceCategoryId"] = item.serviceCategoryId;
                    row["rate"] = item.rate;
                    row["narration"] = item.narration;

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
