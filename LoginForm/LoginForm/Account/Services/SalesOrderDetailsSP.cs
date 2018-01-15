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
    class SalesOrderDetailsSP
    {
        public DataTable SalesInvoiceGridfillAgainestSalesOrderUsingSalesDetails(decimal decSalesOrderMasterId, decimal salesMasterId, decimal voucherTypeId)
        {
            DataTable dtbl = new DataTable();
            //TODO SalesInvoiceGridfillAgainestSalesOrderUsingSalesDetails
            //try
            //{
            //    if (sqlcon.State == ConnectionState.Closed)
            //    {
            //        sqlcon.Open();
            //    }
            //    SqlDataAdapter sqlda = new SqlDataAdapter("SalesInvoiceGridfillAgainestSalesOrderUsingSalesDetails", sqlcon);
            //    sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    SqlParameter sqlparameter = new SqlParameter();
            //    sqlparameter = sqlda.SelectCommand.Parameters.Add("@salesOrderMasterId", SqlDbType.Decimal);
            //    sqlparameter.Value = decSalesOrderMasterId;
            //    sqlparameter = sqlda.SelectCommand.Parameters.Add("@salesMasterId", SqlDbType.Decimal);
            //    sqlparameter.Value = salesMasterId;
            //    sqlparameter = sqlda.SelectCommand.Parameters.Add("@voucherTypeId", SqlDbType.Decimal);
            //    sqlparameter.Value = voucherTypeId;
            //    sqlda.Fill(dtbl);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    sqlcon.Close();
            //}
            return dtbl;
        }
    }
}
