using LoginForm.DataSet;
using System.Linq;

namespace LoginForm.Account.Services
{
    static class FinancialYearSP
    {
        static public FinancialYear FinancialYearViewForAccountLedger(int v)
        {
            return new IMEEntities().FinancialYears.Where(x => x.financialYearId == v).FirstOrDefault();
        }

    }
}
