using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class TaxDetailsSP
    {
        public DataTable TaxDetailsViewallByTaxId(decimal decTaxId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.TaxDetailsViewallByTaxId(decTaxId);

                dtbl.Columns.Add("selectedtaxId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();
                    row["selectedtaxId"] = item.selectedtaxId;

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
