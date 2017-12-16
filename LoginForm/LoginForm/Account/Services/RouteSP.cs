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
    class RouteSP
    {
        public DataTable RouteViewByArea(decimal decAreaId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from r in db.Routes.Where(x=>x.areaId == decAreaId)
                               select new
                               {
                                   r.routeId,
                                   r.routeName
                               }).ToList();

                dt.Columns.Add("routeId");
                dt.Columns.Add("routeName");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["routeId"] = item.routeId;
                    row["routeName"] = item.routeName;

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
