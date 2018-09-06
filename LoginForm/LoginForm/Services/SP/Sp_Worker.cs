using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm.Services.SP
{
    class Sp_Worker
    {
        public Sp_Worker() { }

        public DataTable GetWorkersAllForComboBox()
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable tblWorker = new DataTable();

            tblWorker.Columns.Add("WorkerID");
            tblWorker.Columns.Add("NameLastName");

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = imeTransaction,
                    CommandText = @"[prc_GetWorkersAllForComboBox]"
                };

                SqlDataAdapter daWorker = new SqlDataAdapter(cmd);
                daWorker.Fill(tblWorker);
                DataRow firstRow = tblWorker.NewRow();
                firstRow["WorkerID"] = "";
                firstRow["NameLastName"] = "Choose";
                tblWorker.Rows.InsertAt(firstRow,0);
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
            return tblWorker;
        }
    }
}
