using LoginForm.DataSet;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class FinancialYearSP
    {
        public FinancialYear FinancialYearViewForAccountLedger(int v)
        {
            return new IMEEntities().FinancialYears.Where(x => x.financialYearId == v).FirstOrDefault();
        }

        /// <summary>
        /// Function to check existence based on parameter and return status
        /// </summary>
        /// <param name="dtFromDate"></param>
        /// <param name="dtToDate"></param>
        /// <returns></returns>
        public bool FinancialYearExistenceCheck(DateTime dtFromDate, DateTime dtToDate)
        {
            bool trueOrfalse = true;
            try
            {
                int inD = Convert.ToInt32(new IMEEntities().FinancialYearExistenceCheck(dtFromDate, dtToDate));
                if (inD == 0)
                {
                    trueOrfalse = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return trueOrfalse;
        }

        /// <summary>
        /// Function to insert values and return id 
        /// </summary>
        /// <param name="financialyearinfo"></param>
        /// <returns></returns>
        public decimal FinancialYearAddWithReturnIdentity(FinancialYear financialyearinfo)
        {
            object decIdentity = 0;
            try
            {
                decIdentity = new IMEEntities().FinancialYearAddWithReturnIdentity(
                    financialyearinfo.fromDate,
                    financialyearinfo.toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return Convert.ToDecimal(decIdentity);
        }
    }
}
