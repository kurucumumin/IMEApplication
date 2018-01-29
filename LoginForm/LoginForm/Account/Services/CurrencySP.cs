using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class CurrencySP
    {
        public Currency CurrencyView(decimal currencyId)
        {
            Currency currencyinfo = new Currency();
            try
            {
                currencyinfo = new IMEEntities().Currencies.Where(x => x.currencyID == currencyId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return currencyinfo;
        }

        /// <summary>
        /// Function to view all values for search based on parameters
        /// </summary>
        /// <param name="strname"></param>
        /// <param name="strsymbol"></param>
        /// <returns></returns>
        public DataTable CurrencySearch(String strname, String strsymbol)
        {
            IMEEntities db = new IMEEntities();

            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;

            dtbl.Columns.Add("currencyId");
            dtbl.Columns.Add("currencySymbol");
            dtbl.Columns.Add("currencyName");
            dtbl.Columns.Add("noOfDecimalPlaces");

            try
            {
                var adaptor = db.CurrencySearch(strname, strsymbol).ToList();

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["currencyId"] = item.currencyId;
                    row["currencySymbol"] = item.currencySymbol;
                    row["currencyName"] = item.currencyName;
                    row["noOfDecimalPlaces"] = "";

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
        /// Function to Update values in Currency Table
        /// </summary>
        /// <param name="currencyinfo"></param>
        public void CurrencyEdit(Currency currencyinfo)
        {
            try
            {
                new IMEEntities().CurrencyEdit(
                    currencyinfo.currencyID,
                    currencyinfo.currencySymbol,
                    currencyinfo.currencyName,
                    currencyinfo.subunitName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Function to check existence of currency based on parameter and return status
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="decCurrencyId"></param>
        /// <returns></returns>
        public bool CurrencyNameCheckExistence(String strName, string strCurrencySymb, decimal decCurrencyId)
        {
            try
            {
                var adaptor = new IMEEntities().CurrencyNameCheckExistence(
                    strName,
                    decCurrencyId,
                    strCurrencySymb).FirstOrDefault();
                decimal decCount = 0;
                if (adaptor != null)
                {
                    decCount = Convert.ToDecimal(adaptor.ToString());
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
    }
}
