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
    class GodownSP
    {
        public DataTable GodownViewAll()
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();
            var adaptor = IME.Godowns.ToList();

            dtbl.Columns.Add("godownId");
            dtbl.Columns.Add("godownName");
            dtbl.Columns.Add("narration");

            foreach (var item in adaptor)
            {
                var row = dtbl.NewRow();
                row["godownId"] = item.godownId;
                row["godownName"] = item.godownName;
                row["narration"] = item.narration;
                dtbl.Rows.Add(row);
            }
            return dtbl;
        }


    }
}
