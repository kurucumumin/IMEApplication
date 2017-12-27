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
    class TransactionsGeneralFill
    {
        public string VoucherNumberAutomaicGeneration(decimal VoucherTypeId, decimal txtBox, DateTime date, string tableName)
        {
            IMEEntities db = new IMEEntities();
            string strVoucherNo = string.Empty;
            try
            {
                //TODO Create VoucherNO and Return
                strVoucherNo = "12345";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strVoucherNo;
        }

        public DataTable SalesmanViewAllForComboFill(ComboBox cmbSalesMan, bool isAll)
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from w in db.Workers
                               from d in db.Designations.Where(x=> x.designationId==1 && x.designationId==w.designationId)
                                select new
                               {
                                   w.WorkerID,
                                   UserName = (w.UserName == "NA") ? "1" : w.UserName
                               }).ToList();

                dt.Columns.Add("WorkerID");
                dt.Columns.Add("UserName");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["WorkerID"] = item.WorkerID;
                    row["UserName"] = item.UserName;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return dt;
        }

        public DataTable CurrencyComboByDate(DateTime date)
        {
            IMEEntities db = new IMEEntities();
            DataTable dt = new DataTable();
            try
            {
                var adaptor = (from c in db.Currencies
                               from e in db.ExchangeRates.Where(x => x.currencyId == c.currencyID)
                               where e.date==date || e.exchangeRateID==1
                               select new
                               {
                                   c.currencyName,
                                   c.currencySymbol,
                                   e.exchangeRateID
                               }).ToList();

                dt.Columns.Add("currencyName"+ "|" + "currencySymbol");
                dt.Columns.Add("exchangeRateID");

                foreach (var item in adaptor)
                {
                    var row = dt.NewRow();

                    row["currencyName" + "|" + "currencySymbol"] = item.currencyName+ "|" +item.currencySymbol;
                    row["exchangeRateID"] = item.exchangeRateID;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
    }
}
