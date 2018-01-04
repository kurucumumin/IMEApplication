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
    class BudgetDetailsSP
    {

        public DataTable BudgetDetailsViewByMasterId(decimal decBudgetMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from bd in IME.BudgetDetails.Where(x => x.budgetMasterId == decBudgetMasterId)
                               from al in IME.AccountLedgers.Where(x => x.ledgerName == bd.particular).DefaultIfEmpty()
                               select new
                               {
                                   bd.budgetDetailsId,
                                   bd.budgetMasterId,
                                   bd.particular,
                                   al.ledgerId,
                                   bd.credit,
                                   bd.debit
                               }).ToList();


                dtbl.Columns.Add("budgetDetailsId");
                dtbl.Columns.Add("budgetMasterId");
                dtbl.Columns.Add("particular");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("credit");
                dtbl.Columns.Add("debit");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["budgetDetailsId"] = item.budgetDetailsId;
                    row["budgetMasterId"] = item.budgetMasterId;
                    row["particular"] = item.particular;
                    row["ledgerId"] = item.ledgerId;
                    row["credit"] = item.credit;
                    row["debit"] = item.debit;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public void BudgetDetailsAdd(BudgetDetail budgetdetailsinfo)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.BudgetDetails.Add(budgetdetailsinfo);
                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void BudgetDetailsEdit(BudgetDetail budgetdetailsinfo)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                BudgetDetail budgetdetail = IME.BudgetDetails.Find(budgetdetailsinfo);

                budgetdetail.budgetDetailsId = budgetdetailsinfo.budgetDetailsId;
                budgetdetail.budgetMasterId = budgetdetailsinfo.budgetMasterId;
                budgetdetail.credit = budgetdetailsinfo.credit;
                budgetdetail.debit = budgetdetailsinfo.debit;
                budgetdetail.particular = budgetdetailsinfo.particular;

                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void BudgetDetailsDelete(decimal BudgetDetailsId)
        {
            IMEEntities IME = new IMEEntities();
            BudgetDetail db = new BudgetDetail();
            try
            {
                db = IME.BudgetDetails.Where(x => x.budgetDetailsId == BudgetDetailsId).FirstOrDefault();
                IME.BudgetDetails.Remove(db);

                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
