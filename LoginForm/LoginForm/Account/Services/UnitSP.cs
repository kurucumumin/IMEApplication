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
    class UnitSP
    {
        public DataTable UnitViewAll()
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();
            var adaptor = (from a in IME.Units
                           select new
                           {
                               a.unitId,
                               a.unitName,
                               a.narration,
                               a.noOfDecimalplaces

                           }).ToList();

            dtbl.Columns.Add("unitId");
            dtbl.Columns.Add("unitName");
            dtbl.Columns.Add("narration");
            dtbl.Columns.Add("noOfDecimalplaces");

            foreach (var item in adaptor)
            {
                var row = dtbl.NewRow();
                row["unitId"] = item.unitId;
                row["unitName"] = item.unitName;
                row["narration"] = item.narration;
                row["noOfDecimalplaces"] = item.noOfDecimalplaces;
                dtbl.Rows.Add(row);
            }
            return dtbl;
        }

        public DataTable UnitViewAllByProductId(decimal decProductId)
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();
            var result = (from uc in IME.UnitConvertions
                         join u in IME.Units on uc.unitId equals u.unitId into gj
                         from x in gj.DefaultIfEmpty()
                         where (uc.unitId == x.unitId) && (uc.productId == decProductId)
                         select new
                         {
                             unitId = x.unitId,
                             x.unitName,
                             uc.unitconversionId,
                             uc.conversionRate
            });


        dtbl.Columns.Add("unitId");
            dtbl.Columns.Add("unitName");
            dtbl.Columns.Add("narration");
            dtbl.Columns.Add("noOfDecimalplaces");

            foreach (var item in result)
            {
                var row = dtbl.NewRow();
                row["unitId"] = item.unitId;
                row["unitName"] = item.unitName;
                row["unitconversionId"] = item.unitconversionId;
                row["conversionRate"] = item.conversionRate;
                dtbl.Rows.Add(row);
            }


            return dtbl;
        }
    }
}
