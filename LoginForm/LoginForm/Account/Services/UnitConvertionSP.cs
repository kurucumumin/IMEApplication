using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;


namespace LoginForm.Account.Services
{
    class UnitConvertionSP
    {
        public DataTable UnitConversionIdAndConRateViewallByProductId(string strProductId)
        {
            DataTable dtblConversionIdViewAll = new DataTable();
            IMEEntities IME = new IMEEntities();
            var c = IME.UnitConversionIdAndConRateViewallByProductId(strProductId);
            dtblConversionIdViewAll.Columns.Add("lrNo");
            dtblConversionIdViewAll.Columns.Add("transportationCompany");
            dtblConversionIdViewAll.Columns.Add("currencyId");
            dtblConversionIdViewAll.Columns.Add("noOfDecimalPlaces");

            foreach (var item in c)
            {
                var row = dtblConversionIdViewAll.NewRow();
                row["salesMasterId"] = item.conversionRate;
                row["salesMasterId"] = item.defaulunitId;
                row["salesMasterId"] = item.unitconversionId;
                row["salesMasterId"] = item.unitId;
                row["salesMasterId"] = item.unitName;
            }
            return dtblConversionIdViewAll;
        }

        public decimal UnitConversionRateByUnitConversionId(decimal decConversionId)
        {
            IMEEntities IME = new IMEEntities();
            decimal decConversionRate = 0;
            if(IME.UnitConvertions.Where(a => a.unitconversionId == decConversionId)!=null) decConversionRate = (decimal)IME.UnitConvertions.Where(a => a.unitconversionId == decConversionId).FirstOrDefault().conversionRate;
            return decConversionRate;
        }


    }
}
