using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Account.Services
{
    static class spFinancialYear
    {
        static public FinancialYear FinancialYearViewForAccountLedger(int v)
        {
            return new IMEEntities().FinancialYears.Where(x => x.financialYearId == v).FirstOrDefault();
        }

    }
}
