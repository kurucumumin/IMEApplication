using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LoginForm.DataSet;
namespace LoginForm.Account.Services
{
    class TaxSP
    {
        public DataTable TaxViewAllByVoucherTypeId(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = (from TX in IME.Taxes
                           from VTX in IME.VoucherTypeTaxes
                           from al in IME.AccountLedgers
                           where (TX.taxName ==al.ledgerName) && (VTX.voucherTypeId== decVoucherTypeId)
                           &&(TX.isActive==true)
                           select new
                           {
                               TX.TaxID,
                               al.ledgerId,
                               TX.taxName,
                               TX.ApplicationOn,
                               TX.CalculatingMode,
                               TX.Rate
                           }).ToList();

            dt.Columns.Add("TaxID");
            dt.Columns.Add("ledgerId");
            dt.Columns.Add("taxName");
            dt.Columns.Add("ApplicationOn");
            dt.Columns.Add("CalculatingMode");
            dt.Columns.Add("Rate");

            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["TaxID"] = item.TaxID;
                row["ledgerId"] = item.ledgerId;
                row["taxName"] = item.taxName;
                row["ApplicationOn"] = item.ApplicationOn;
                row["CalculatingMode"] = item.CalculatingMode;
                row["Rate"] = item.Rate;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public TaxInfo TaxViewByProductId(string strProductCode)
        {
            TaxInfo taxInfo = new TaxInfo();
            //TODO TaxViewByProductId
            //SqlDataReader sdrreader = null;
            //try
            //{
            //    if (sqlcon.State == ConnectionState.Closed)
            //    {
            //        sqlcon.Open();
            //    }
            //    SqlCommand sccmd = new SqlCommand("TaxViewByProductId", sqlcon);
            //    sccmd.CommandType = CommandType.StoredProcedure;
            //    SqlParameter sprmparam = new SqlParameter();
            //    sprmparam = sccmd.Parameters.Add("@productId", SqlDbType.VarChar);
            //    sprmparam.Value = strProductCode;
            //    sdrreader = sccmd.ExecuteReader();
            //    while (sdrreader.Read())
            //    {
            //        taxInfo.TaxId = Convert.ToDecimal(sdrreader["taxId"].ToString());
            //        taxInfo.TaxName = sdrreader["taxName"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    sdrreader.Close();
            //    sqlcon.Close();
            //}
            return taxInfo;
        }

        public DataTable TaxViewAllByVoucherTypeIdApplicaleForProduct(decimal decVoucherTypeId)
        {

            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = (from TX in IME.Taxes
                           from VTX in IME.VoucherTypeTaxes.Where(a=>a.taxId==TX.TaxID)
                           where (TX.ApplicationOn== "Product") && (VTX.voucherTypeId == decVoucherTypeId)
                           && (TX.isActive == true)
                           select new
                           {
                               TX.TaxID,
                               TX.taxName,
                           }).ToList();

            dt.Columns.Add("TaxID");
            dt.Columns.Add("taxName");
            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["TaxID"] = item.TaxID;
                row["taxName"] = item.taxName;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public TaxInfo TaxView(decimal taxId)
        {
            TaxInfo taxinfo = new TaxInfo();
            IMEEntities IME = new IMEEntities();
            var tax = IME.Taxes.Where(a => a.TaxID == taxId).FirstOrDefault();
            taxinfo.TaxId = tax.TaxID;
            taxinfo.TaxName = tax.taxName;
            taxinfo.ApplicableOn = tax.ApplicationOn;
            taxinfo.Rate = (decimal)tax.Rate;
            taxinfo.CalculatingMode = tax.CalculatingMode;
            taxinfo.Narration = tax.narration;
            taxinfo.IsActive = (bool)tax.isActive;
            return taxinfo;
        }
    }
}
