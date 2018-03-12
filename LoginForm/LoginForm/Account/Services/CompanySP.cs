using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using LoginForm.DataSet;
using LoginForm.Services;

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

        public Company CompanyView(decimal companyId)
        {
            IMEEntities IME = new IMEEntities();
            Company companyinfo = new Company();

            try
            {
                var a = IME.CompanyView(companyId).FirstOrDefault();

                companyinfo.companyId = a.companyId;
                companyinfo.companyName = a.companyName;
                companyinfo.mailingName = a.mailingName;
                companyinfo.address = a.address;
                companyinfo.phone = a.phone;
                companyinfo.mobile = a.mobile;
                companyinfo.web = a.web;
                companyinfo.country = a.country;
                companyinfo.state = a.state;
                companyinfo.pin = a.pin;
                companyinfo.currencyId = a.currencyId;
                companyinfo.financialYearFrom = Convert.ToDateTime(a.financialYearFrom);
                companyinfo.booksBeginingFrom = Convert.ToDateTime(a.booksBeginingFrom);
                companyinfo.tin = a.tin;
                companyinfo.cst = a.cst;
                companyinfo.pan = a.pan;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return companyinfo;
        }

        public DataTable CompanyViewDataTable(decimal companyId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.CompanyView(companyId).ToList();

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
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable CompanyViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.CompanyViewAll().ToList();

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
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        /// <summary>
        /// Function to check existance of company
        /// </summary>
        /// <param name="strCompanyName"></param>
        /// <param name="decCompanyId"></param>
        /// <returns></returns>
        public bool CompanyCheckExistence(String strCompanyName, decimal decCompanyId)
        {
            try
            {
                object obj = new IMEEntities().CompanyCheckExistence(strCompanyName, decCompanyId).FirstOrDefault();
                decimal decCount = 0;
                if (obj != null)
                {
                    decCount = Convert.ToDecimal(obj.ToString());
                }
                if (decCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// Function to insert values to Company Table
        /// </summary>
        /// <param name="companyinfo"></param>
        /// <returns></returns>
        public decimal CompanyAddParticularFeilds(Company companyinfo)
        {
            object decCopmanyId = 0;
            try
            {

                decCopmanyId = new IMEEntities().CompanyAddParticularFeilds(
                    companyinfo.companyName,
                    companyinfo.mailingName,
                    companyinfo.address,
                    companyinfo.phone,
                    companyinfo.mobile,
                    companyinfo.email,
                    companyinfo.web,
                    companyinfo.country,
                    companyinfo.state,
                    companyinfo.pin,
                    companyinfo.currencyId,
                    companyinfo.financialYearFrom,
                    companyinfo.booksBeginingFrom,
                    companyinfo.tin,
                    companyinfo.cst,
                    companyinfo.pan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return Convert.ToDecimal(decCopmanyId);
        }

        /// <summary>
        /// Function to insert values to Company Table
        /// </summary>
        /// <param name="companyinfo"></param>
        public void CompanyAdd(Company companyinfo)
        {
            try
            {
                new IMEEntities().CompanyAdd(
                    companyinfo.companyId,
                    companyinfo.companyName,
                    companyinfo.mailingName,
                    companyinfo.address,
                    companyinfo.phone,
                    companyinfo.mobile,
                    companyinfo.email,
                    companyinfo.web,
                    companyinfo.country,
                    companyinfo.state,
                    companyinfo.pin,
                    companyinfo.currencyId,
                    companyinfo.financialYearFrom,
                    companyinfo.booksBeginingFrom,
                    companyinfo.tin,
                    companyinfo.cst,
                    companyinfo.pan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Function to Update values in Company Table
        /// </summary>
        /// <param name="companyinfo"></param>
        public void CompanyEdit(Company companyinfo)
        {
            try
            {
                new IMEEntities().CompanyEdit(
                    companyinfo.companyId,
                    companyinfo.companyName,
                    companyinfo.mailingName,
                    companyinfo.address,
                    companyinfo.phone,
                    companyinfo.mobile,
                    companyinfo.email,
                    companyinfo.web,
                    companyinfo.country,
                    companyinfo.state,
                    companyinfo.pin,
                    companyinfo.currencyId,
                    companyinfo.financialYearFrom,
                    companyinfo.booksBeginingFrom,
                    companyinfo.tin,
                    companyinfo.cst,
                    companyinfo.pan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
