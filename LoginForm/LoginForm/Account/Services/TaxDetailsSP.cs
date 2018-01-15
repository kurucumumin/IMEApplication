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
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = (from TXD in IME.TaxDetails
                           where (TXD.taxID == decTaxId)
                           select new
                           {
                               TXD.SelectedtaxID,
                           }).ToList();

            dt.Columns.Add("SelectedtaxID");
            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["SelectedtaxID"] = item.SelectedtaxID;
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
