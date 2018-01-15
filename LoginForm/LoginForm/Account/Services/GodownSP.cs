using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LoginForm.DataSet;

namespace LoginForm.Account.Services
{
    class GodownSP
    {
        public DataTable GodownViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = (from gd in IME.Godowns
                           select new
                           {
                               gd.godownId
                               ,
                               gd.godownName
                               ,
                               gd.narration

                           }).ToList();

            dt.Columns.Add("godownId");
            dt.Columns.Add("godownName");
            dt.Columns.Add("narration");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["godownId"] = item.godownId;
                row["godownName"] = item.godownName;
                row["narration"] = item.narration;
                dt.Rows.Add(row);
            }
            return dt;

        }

    }
}
