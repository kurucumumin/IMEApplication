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
    class RackSP
    {
        public DataTable RackNamesCorrespondingToGodownId(decimal decgodownId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = (from r in IME.Racks
                           where r.godownId==decgodownId
                           select new
                           {
                               r.rackName,
                               r.rackId
                           }).ToList();

            dt.Columns.Add("rackName");
            dt.Columns.Add("rackId");
            dt.Columns.Add("narration");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["rackName"] = item.rackName;
                row["rackId"] = item.rackId;
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
