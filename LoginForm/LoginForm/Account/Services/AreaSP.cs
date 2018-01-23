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
    class AreaSP
    {
        public DataTable AreaViewAll()
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from a in db.Areas
                               select new
                               {
                                   a.areaId,
                                   a.areaName,
                                   a.narration,
                                   a.extraDate
                               }).ToList();

                dt.Columns.Add("areaId");
                dt.Columns.Add("areaName");
                dt.Columns.Add("narration");
                dt.Columns.Add("extraDate");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["areaId"] = item.areaId;
                    row["areaName"] = item.areaName;
                    row["narration"] = item.narration;
                    row["extraDate"] = item.extraDate;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }

        /// <summary>
        /// Fuinction to get fill area
        /// </summary>
        /// <param name="decAreaId"></param>
        /// <returns></returns>
        public Area AreaFill(decimal decAreaId)
        {
            Area infoArea = new Area();
            try
            {
                var adaptor = new IMEEntities().AreaWithNarrationView(decAreaId).FirstOrDefault();

                infoArea.areaId = adaptor.areaId;
                infoArea.areaName = adaptor.areaName;
                infoArea.narration = adaptor.narration;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return infoArea;
        }

        /// <summary>
        /// Function to get Area Only View All
        /// </summary>
        /// <returns></returns>
        public DataTable AreaOnlyViewAll()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl.No", typeof(decimal));
            dtbl.Columns["Sl.No"].AutoIncrement = true;
            dtbl.Columns["Sl.No"].AutoIncrementSeed = 1;
            dtbl.Columns["Sl.No"].AutoIncrementStep = 1;
            try
            {
                var adaptor = db.AreaOnlyViewAll().ToList();

                dtbl.Columns.Add("areaId");
                dtbl.Columns.Add("areaName");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["areaId"] = item.areaId;
                    row["areaName"] = item.areaName;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        /// <summary>
        /// Function to check references to delete a area
        /// </summary>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        public decimal AreaDeleteReference(decimal AreaId)
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = Convert.ToDecimal(new IMEEntities().AreaDeleteReference(AreaId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decReturnValue;
        }
    }
}
