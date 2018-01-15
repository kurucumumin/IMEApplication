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

        public DataTable RackViewAll()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.Racks.ToList();
                
                dtbl.Columns.Add("rackId");
                dtbl.Columns.Add("rackName");
                dtbl.Columns.Add("godownId");
                dtbl.Columns.Add("narration");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["rackId"] = item.rackId;
                    row["rackName"] = item.rackName;
                    row["godownId"] = item.godownId;
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
