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
        public string UnitConversionCheck(decimal decUnitId, decimal decProductId)
        {
            IMEEntities IME = new IMEEntities();
            string strQuantities = string.Empty;
            try
            {
                ProductViewAll_Result aa = new ProductViewAll_Result();
                strQuantities = IME.UnitConvertions.Where(x => Convert.ToDecimal(x.productId) == decProductId && x.unitId == decUnitId).FirstOrDefault().quantities;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strQuantities;
        }

        public decimal UnitIdByUnitName(string UnitName)
        {
            IMEEntities IME = new IMEEntities();
            decimal decUnitId = 0;
            try
            {
                decUnitId = IME.Units.Where(x => x.unitName == UnitName).FirstOrDefault().unitId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decUnitId;
        }
    }
}
