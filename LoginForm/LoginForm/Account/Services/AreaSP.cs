using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm.Account.Services
{
    class AreaSP
    {
        public DataTable AreaViewAll()
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from a in db.Areas
                               select new
                               {
                                   a.areaId,
                                   a.areaName,
                                   a.narration,
                                   a.extraDate
                               }).ToList();

                dt.Columns.Add("areaId");
                dt.Columns.Add("areaName");
                dt.Columns.Add("narration");
                dt.Columns.Add("extraDate");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["areaId"] = item.areaId;
                    row["areaName"] = item.areaName;
                    row["narration"] = item.narration;
                    row["extraDate"] = item.extraDate;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
    }
}
