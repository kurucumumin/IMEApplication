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
    class Sp_Customer
    {
        public Sp_Customer() { }

        public DataTable SearchCustomersWithName(string searchText)
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable tableRsInvoice = new DataTable();

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = imeTransaction,
                    CommandText = @"[Customer_CustomerName]"
                };
                cmd.Parameters.AddWithValue("@c_name", searchText);

                SqlDataAdapter daRsInvoice = new SqlDataAdapter(cmd);
                daRsInvoice.Fill(tableRsInvoice);
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
            return tableRsInvoice;
        }
    }
}
