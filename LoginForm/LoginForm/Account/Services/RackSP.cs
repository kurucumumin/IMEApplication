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
    class RackSP
    {

        public DataTable RackNamesCorrespondingToGodownId(decimal decgodownId)
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();
            var Racks = IME.Racks.Where(a => a.godownId == decgodownId).ToList();

            dtbl.Columns.Add("rackName");
            dtbl.Columns.Add("rackId");
            foreach (var item in Racks)
            {
                var row = dtbl.NewRow();
                row["rackName"] = item.rackName;
                row["rackId"] = item.rackId;
                dtbl.Rows.Add(row);
            }
            return dtbl;
        }
    }
}
