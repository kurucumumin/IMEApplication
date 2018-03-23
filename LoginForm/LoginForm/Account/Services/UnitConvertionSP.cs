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
    class UnitConvertionSP
    {

        public DataTable UnitConversionIdAndConRateViewallByProductId(string strProductId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from u in IME.UnitConvertions
                              from un in IME.Units.Where(x => x.unitId == u.unitId)
                              where u.productId == strProductId
                              select new
                              {
                                  un.unitId,
                                  un.unitName,
                                  u.unitconversionId,
                                  u.conversionRate
                              }).ToList();


                dtbl.Columns.Add("unitId");
                dtbl.Columns.Add("unitName");
                dtbl.Columns.Add("unitconversionId");
                dtbl.Columns.Add("conversionRate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["unitId"] = item.unitId;
                    row["unitName"] = item.unitName;
                    row["unitconversionId"] = item.unitconversionId;
                    row["conversionRate"] = item.conversionRate;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable DGVUnitConvertionRateByUnitId(decimal decUnitId, string productName)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                ProductViewAll_Result aa = new ProductViewAll_Result();
                var adaptor = (from b in IME.UnitConvertions.Where(x => x.productId == aa.Article_No)
                               where aa.Article_Desc== productName && b.unitId== decUnitId
                               select new
                               {
                                   b.unitconversionId,
                                   b.conversionRate
                               }).ToList();

                dtbl.Columns.Add("unitconversionId");
                dtbl.Columns.Add("conversionRate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["unitconversionId"] = item.unitconversionId;
                    row["conversionRate"] = item.conversionRate;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtbl;
        }

        public decimal UnitConversionRateByUnitConversionId(decimal decConversionId)
        {
            IMEEntities IME = new IMEEntities();
            decimal decConversionRate = 0;
            try
            {
                decConversionRate = Convert.ToDecimal(IME.UnitConvertions.Where(x => x.unitconversionId == decConversionId).FirstOrDefault().conversionRate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decConversionRate;
        }

        public decimal UnitconversionIdViewByUnitIdAndProductId(decimal unitId, string productId)
        {
            decimal decValue = 0;
            try
            {
                decValue = (decimal)new IMEEntities().UnitconversionIdViewByUnitIdAndProductId(unitId, productId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decValue;
        }
    }
}
