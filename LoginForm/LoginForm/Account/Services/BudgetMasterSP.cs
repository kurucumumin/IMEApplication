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
    class BudgetMasterSP
    {

        public DataTable BudgetSearchGridFill(string strBudgetName, string strType)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from bm in IME.BudgetMasters.Where(x => x.budgetName.StartsWith(strBudgetName) &&
                               (x.type == "0" && x.type == null) ? x.type == x.type : x.type == strType)
                               select new
                               {
                                   bm.budgetMasterId,
                                   bm.budgetName,
                                   bm.fromDate,
                                   bm.toDate,
                                   bm.narration,
                                   bm.totalDr,
                                   bm.totalCr
                               }).ToList();

                dtbl.Columns.Add("budgetMasterId");
                dtbl.Columns.Add("budgetName");
                dtbl.Columns.Add("fromDate");
                dtbl.Columns.Add("toDate");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("totalDr");
                dtbl.Columns.Add("totalCr");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["budgetMasterId"] = item.budgetMasterId;
                    row["budgetName"] = item.budgetName;
                    row["fromDate"] = item.fromDate;
                    row["toDate"] = item.toDate;
                    row["narration"] = item.narration;
                    row["totalDr"] = item.totalDr;
                    row["totalCr"] = item.totalCr;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }

        public BudgetMaster BudgetMasterView(decimal budgetMasterId)
        {
            IMEEntities IME = new IMEEntities();
            BudgetMaster budgetmasterinfo = new BudgetMaster();
            try
            {
                budgetmasterinfo = IME.BudgetMasters.Where(x => x.budgetMasterId == budgetMasterId).FirstOrDefault();

                return budgetmasterinfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return budgetmasterinfo;
        }

        public decimal BudgetMasterAdd(BudgetMaster budgetmasterinfo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decIdentity = 0;
            try
            {
                IME.BudgetMasters.Add(budgetmasterinfo);
                IME.SaveChanges();
                decIdentity = budgetmasterinfo.budgetMasterId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public void BudgetMasterEdit(BudgetMaster budgetmasterinfo)
        {
            IMEEntities IME = new IMEEntities();

            try
            {
                BudgetMaster budgetmaster = IME.BudgetMasters.Find(budgetmasterinfo);

                budgetmaster.budgetMasterId = budgetmasterinfo.budgetMasterId;
                budgetmaster.budgetName = budgetmasterinfo.budgetName;
                budgetmaster.fromDate = budgetmasterinfo.fromDate;
                budgetmaster.narration = budgetmasterinfo.narration;
                budgetmaster.toDate = budgetmasterinfo.toDate;
                budgetmaster.totalCr = budgetmasterinfo.totalCr;
                budgetmaster.totalDr = budgetmasterinfo.totalDr;
                budgetmaster.type = budgetmasterinfo.type;


                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool BudgetCheckExistanceOfName(string strBudgetName, decimal decBudgetMasterId)
        {
            IMEEntities IME = new IMEEntities();
            bool isEdit = false;
            try
            {
                decimal? adapter = (from bm in IME.BudgetMasters.Where(x => x.budgetName == strBudgetName && x.budgetMasterId == decBudgetMasterId)
                               select new { bm.budgetMasterId }).Count();
                isEdit = (adapter > 0) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isEdit;
        }

        public decimal BudgetMasterDelete(decimal BudgetMasterId)
        {
            IMEEntities IME = new IMEEntities();
            BudgetDetail db = new BudgetDetail();
            BudgetMaster db2 = new BudgetMaster();
            decimal decReturnValue = 0;
            try
            {
                db2 = IME.BudgetMasters.Where(x => x.budgetMasterId == BudgetMasterId).FirstOrDefault();
                IME.BudgetMasters.Remove(db2);

                IME.SaveChanges();

                db = IME.BudgetDetails.Where(x => x.budgetMasterId == BudgetMasterId).FirstOrDefault();
                IME.BudgetDetails.Remove(db);

                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                decReturnValue = -1;
                MessageBox.Show(ex.ToString());
            }
            return decReturnValue;
        }

        public DataTable BudgetVariance(decimal decbudgetId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtblBudget = new DataTable();
            dtblBudget.Columns.Add("SL.NO", typeof(decimal));
            dtblBudget.Columns["SL.NO"].AutoIncrement = true;
            dtblBudget.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtblBudget.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.BudgetVariance(decbudgetId);


                dtblBudget.Columns.Add("particular");
                dtblBudget.Columns.Add("BudgetDr");
                dtblBudget.Columns.Add("ActualDr");
                dtblBudget.Columns.Add("VarianceDr");
                dtblBudget.Columns.Add("BudgetCr");
                dtblBudget.Columns.Add("ActualCr");
                dtblBudget.Columns.Add("VarianceCr");


                foreach (var item in adaptor)
                {
                    var row = dtblBudget.NewRow();

                    row["particular"] = item.particular;
                    row["BudgetDr"] = item.BudgetDr;
                    row["ActualDr"] = item.ActualDr;
                    row["VarianceDr"] = item.VarianceDr;
                    row["BudgetCr"] = item.BudgetCr;
                    row["ActualCr"] = item.ActualCr;
                    row["VarianceCr"] = item.VarianceCr;

                    dtblBudget.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtblBudget;
        }

        public DataTable BudgetViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from bm in IME.BudgetMasters
                               select new
                               {
                                   bm.budgetMasterId,
                                   bm.budgetName,
                                   bm.fromDate,
                                   bm.narration,
                                   bm.toDate,
                                   bm.totalCr,
                                   bm.totalDr,
                                   bm.type
                               }).ToList();

                dtbl.Columns.Add("budgetMasterId");
                dtbl.Columns.Add("budgetName");
                dtbl.Columns.Add("fromDate");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("toDate");
                dtbl.Columns.Add("totalCr");
                dtbl.Columns.Add("totalDr");
                dtbl.Columns.Add("type");
                

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["budgetMasterId"] = item.budgetMasterId;
                    row["budgetName"] = item.budgetName;
                    row["fromDate"] = item.fromDate;
                    row["narration"] = item.narration;
                    row["toDate"] = item.toDate;
                    row["totalCr"] = item.totalCr;
                    row["totalDr"] = item.totalDr;
                    row["type"] = item.type;
                   

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }
    }
}
