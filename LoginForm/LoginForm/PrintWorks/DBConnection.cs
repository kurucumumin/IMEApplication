namespace PrintWorks
{
    using System;
    using System.Data.SqlClient;

    internal class DBConnection
    {
        protected SqlConnection sqlcon = new SqlConnection();

        public DBConnection()
        {
            this.sqlcon = new SqlConnection(frmDBConnection.connectionString);
        }
    }
}

