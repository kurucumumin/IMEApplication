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
    class Sp_Item
    {
        public Sp_Item() { }

        public DataTable GetProductHistoryWithArticleNo(string ArticleNo)
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable tableProductHistory = new DataTable();

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = imeTransaction,
                    CommandText = @"[prc_GetProductHistoryWithArticleNo]"
                };
                cmd.Parameters.AddWithValue("@ArticleNo", ArticleNo);

                SqlDataAdapter daRsInvoice = new SqlDataAdapter(cmd);
                daRsInvoice.Fill(tableProductHistory);
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
            return tableProductHistory;
        }

        public DataTable GetProductHistoryWithArticleNo_P(string ArticleNo)
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable tableProductHistory = new DataTable();

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = imeTransaction,
                    CommandText = @"[prc_GetProductHistoryWithArticleNo_P]"
                };
                cmd.Parameters.AddWithValue("@ArticleNo", ArticleNo);

                SqlDataAdapter daRsInvoice = new SqlDataAdapter(cmd);
                daRsInvoice.Fill(tableProductHistory);
                imeTransaction.Commit();
            }
            catch (Exception ex)
            {
                imeTransaction.Rollback();
                //MessageBox.Show("Database Connection Error. \n\nError Message: " + ex.ToString(), "Error");
                return null;
            }
            finally
            {
                conn.Close();
            }
            return tableProductHistory;
        }
    }
}
