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
    class UnitSP
    {
        public DataTable UnitViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = (from u in IME.Units
                           select new
                           {
                               u.unitId,
                               u.unitName,
                               u.narration,
                               u.noOfDecimalplaces
                           }).ToList();

            dt.Columns.Add("unitId");
            dt.Columns.Add("unitName");
            dt.Columns.Add("narration");
            dt.Columns.Add("noOfDecimalplaces");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["unitId"] = item.unitId;
                row["unitName"] = item.unitName;
                row["narration"] = item.narration;
                row["noOfDecimalplaces"] = item.noOfDecimalplaces;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable UnitViewAllByProductId(string decProductId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var defaultUnit = IME.Units.Where(a => a.unitName == IME.ArticleSearch(decProductId).FirstOrDefault().Unit_Measure).FirstOrDefault().unitId;
            var adaptor = (from uc in IME.UnitConvertions
                           from u in IME.Units.Where(a=>a.unitId==uc.unitId).DefaultIfEmpty()
                           where (uc.productId==decProductId)
                           select new
                           {
                               u.unitId,
                               u.unitName,
                               uc.unitconversionId,
                               uc.conversionRate
                           }).ToList();

            dt.Columns.Add("unitId");
            dt.Columns.Add("unitName");
            dt.Columns.Add("unitconversionId");
            dt.Columns.Add("conversionRate");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["unitId"] = item.unitId;
                row["unitName"] = item.unitName;
                row["unitconversionId"] = item.unitconversionId;
                row["conversionRate"] = item.conversionRate;
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
