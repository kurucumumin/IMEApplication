using LoginForm.DataSet;
using System.Linq;

namespace LoginForm.Account.Services
{
    class FinancialYearSP
    {
        public FinancialYear FinancialYearViewForAccountLedger(int v)
        {
            return new IMEEntities().FinancialYears.Where(x => x.financialYearId == v).FirstOrDefault();
        }

    }
}
