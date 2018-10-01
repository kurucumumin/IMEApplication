using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Services
{
    class SqlHelper
    {
        public SqlHelper() { }

        public DataTable GetQueryResult(string QueryText)
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable tableResult = new DataTable();

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    Transaction = imeTransaction,
                    CommandText = @QueryText
                };

                SqlDataAdapter daResult = new SqlDataAdapter(cmd);
                daResult.Fill(tableResult);
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
            return tableResult;
        } 

    }
}
