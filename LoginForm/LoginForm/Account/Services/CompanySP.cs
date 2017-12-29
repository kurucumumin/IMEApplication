using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using LoginForm.DataSet;

namespace LoginForm.Account.Services
{
    class CompanySP
    {
        public DataTable CompanyViewForDotMatrix()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from c in IME.Companies
                               select new
                               {
                                   c.companyName,
                                   c.mailingName,
                                   c.address,
                                   c.phone,
                                   c.mobile,
                                   c.email,
                                   c.web,
                                   c.country,
                                   c.state,
                                   c.pin,
                                   c.currencyId,
                                   c.financialYearFrom,
                                   c.booksBeginingFrom,
                                   c.tin,
                                   c.cst,
                                   c.pan
                               }).ToList();

                dtbl.Columns.Add("companyName");
                dtbl.Columns.Add("mailingName");
                dtbl.Columns.Add("address");
                dtbl.Columns.Add("phone");
                dtbl.Columns.Add("mobile");
                dtbl.Columns.Add("email");
                dtbl.Columns.Add("web");
                dtbl.Columns.Add("country");
                dtbl.Columns.Add("state");
                dtbl.Columns.Add("pin");
                dtbl.Columns.Add("currencyId");
                dtbl.Columns.Add("financialYearFrom");
                dtbl.Columns.Add("booksBeginingFrom");
                dtbl.Columns.Add("tin");
                dtbl.Columns.Add("cst");
                dtbl.Columns.Add("pan");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["companyName"] = item.companyName;
                    row["mailingName"] = item.mailingName;
                    row["address"] = item.address;
                    row["phone"] = item.phone;
                    row["mobile"] = item.mobile;
                    row["email"] = item.email;
                    row["web"] = item.web;
                    row["country"] = item.country;
                    row["state"] = item.state;
                    row["pin"] = item.pin;
                    row["currencyId"] = item.currencyId;
                    row["financialYearFrom"] = item.financialYearFrom;
                    row["booksBeginingFrom"] = item.booksBeginingFrom;
                    row["tin"] = item.tin;
                    row["cst"] = item.cst;
                    row["pan"] = item.pan;

                    dtbl.Rows.Add(row);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtbl;
        }
    }
}
