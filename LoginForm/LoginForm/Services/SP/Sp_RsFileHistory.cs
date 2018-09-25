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
    class Sp_RsFileHistory
    {
        public Sp_RsFileHistory() { }

        public DataTable GetRsFileHistoryWithFileType(string FileType)
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable tableRSFileHistory = new DataTable();

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = imeTransaction,
                    CommandText = @"[prc_GetRsFileHistoryWithFileType]"
                };
                cmd.Parameters.AddWithValue("@FileType", FileType);

                SqlDataAdapter daRsFileHistory = new SqlDataAdapter(cmd);
                daRsFileHistory.Fill(tableRSFileHistory);
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
            return tableRSFileHistory;
        }

    }
}
