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
    class FinancialStatementSP
    {
        public DataTable FundFlowReportPrintCompany(decimal decCompanyId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from c in IME.Companies.Where(x => x.companyId == decCompanyId)
                               from cur in IME.Currencies.Where(x => x.currencyID == c.currencyId)
                               select new
                               {
                                   c.companyName,
                                   c.address,
                                   c.phone,
                                   c.email,
                                   cur.currencyName
                               }).ToList();

                dtbl.Columns.Add("companyName");
                dtbl.Columns.Add("address");
                dtbl.Columns.Add("phone");
                dtbl.Columns.Add("email");
                dtbl.Columns.Add("currencyName");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["companyName"] = item.companyName;
                    row["address"] = item.address;
                    row["phone"] = item.phone;
                    row["email"] = item.email;
                    row["currencyName"] = item.currencyName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtbl;
        }

    }
}
