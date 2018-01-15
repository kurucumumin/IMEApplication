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
    class SalesQuotationDetailsSP
    {

        public DataTable SalesInvoiceGridfillAgainestQuotationUsingQuotationDetails(decimal decQuotationMasterId, decimal salesOrderMasterId, decimal voucherTypeId)
        {
            DataTable dtbl = new DataTable();
            //TODO SalesInvoiceGridfillAgainestQuotationUsingQuotationDetails
            //try
            //{
            //    if (sqlcon.State == ConnectionState.Closed)
            //    {
            //        sqlcon.Open();
            //    }
            //    SqlDataAdapter sqldataadapter = new SqlDataAdapter("SalesInvoiceGridfillAgainestQuotationUsingQuotationDetails", sqlcon);
            //    sqldataadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    SqlParameter sqlparameter = new SqlParameter();
            //    sqlparameter = sqldataadapter.SelectCommand.Parameters.Add("@quotationMasterId", SqlDbType.Decimal);
            //    sqlparameter.Value = decQuotationMasterId;
            //    sqlparameter = sqldataadapter.SelectCommand.Parameters.Add("@salesMasterId", SqlDbType.Decimal);
            //    sqlparameter.Value = salesOrderMasterId;
            //    sqlparameter = sqldataadapter.SelectCommand.Parameters.Add("@voucherTypeId", SqlDbType.Decimal);
            //    sqlparameter.Value = voucherTypeId;
            //    sqldataadapter.Fill(dtbl);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    sqlcon.Close();
            //}
            return dtbl;
        }

    }
}
