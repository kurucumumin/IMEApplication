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
    class PricingLevelSP
    {
        public DataTable PricelistPricingLevelViewAllForComboBox()
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from pl in db.PricingLevels.OrderBy(x => x.pricinglevelName)
                               select new
                               {
                                   pl.pricinglevelId,
                                   pl.pricinglevelName
                               }).ToList();

                dt.Columns.Add("pricinglevelId");
                dt.Columns.Add("pricinglevelName");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["pricinglevelId"] = item.pricinglevelId;
                    row["pricinglevelName"] = item.pricinglevelName;

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
