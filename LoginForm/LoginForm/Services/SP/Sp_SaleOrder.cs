using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Services.SP
{
    class Sp_SaleOrder
    {

        public Sp_SaleOrder() { }

        public DataTable SearchSaleOrdersWithSaleNo(string searchText)
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable tableSaleOrder = new DataTable();

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = imeTransaction,
                    CommandText = @"[SaleOrder_SaleOrderNo]"
                };
                cmd.Parameters.AddWithValue("@SaleOrderNo", searchText);

                SqlDataAdapter daSaleOrder = new SqlDataAdapter(cmd);
                daSaleOrder.Fill(tableSaleOrder);
                imeTransaction.Commit();
            }
            catch (Exception ex)
            {
                imeTransaction.Rollback();
                MessageBox.Show("Database Connection Error. \n\nError Message: " + ex.ToString(), "Error");
                return null;
            }
            finally
            {
                conn.Close();
            }
            return tableSaleOrder;
        }


    }
}
