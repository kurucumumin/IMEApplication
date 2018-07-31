using LoginForm.MyClasses;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace LoginForm.clsClasses
{
    public sealed class MyConnect
    {
        private static object __kilit = new object();
        private static MyConnect __ornek;

        public void BackupDatabase(string databaseName, string userName, string password, string serverName, string destinationPath, ref Exception hataMsj)
        {
            try
            {
                ServerConnection serverConnection = new ServerConnection(serverName, userName, password);
                Server srv = new Server(serverConnection);
                BackupDeviceItem item = new BackupDeviceItem(destinationPath, DeviceType.File);
                Backup backup = new Backup();
                backup.Devices.Add(item);
                backup.Action = BackupActionType.Database;
                backup.BackupSetDescription = "ArsivDataBase:" + DateTime.Now.ToShortDateString();
                backup.BackupSetName = "Arsiv";
                backup.Database = databaseName;
                backup.Initialize = true;
                backup.Checksum = true;
                backup.ContinueAfterError = true;
                backup.Incremental = false;
                backup.ExpirationDate = DateTime.Now.AddDays(3.0);
                backup.LogTruncation = BackupTruncateLogType.Truncate;
                backup.FormatMedia = false;
                backup.SqlBackup(srv);
            }
            catch (Exception exception)
            {
                hataMsj = exception;
            }
        }

        public bool ConnectionControl(string ConnectionStrings, ref string hataMesaji)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionStrings);
                SqlCommand command = new SqlCommand("", connection) {
                    CommandTimeout = 5
                };
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                SqlException exception2 = (SqlException) exception;
                hataMesaji = exception2.Message;
                return false;
            }
        }

        public SqlConnection ConnectionString(string str)
        {
            return new SqlConnection(str);
        }

        public string ConnectionString(string server, string user, string pass, string db)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
                DataSource = server,
                Password = pass,
                UserID = user,
                InitialCatalog = db,
                IntegratedSecurity = true
            };
            return builder.ConnectionString;
        }

        public SqlConnection ConnectionStringX(string server, string user, string pass, string db)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
                DataSource = server,
                Password = pass,
                UserID = user,
                InitialCatalog = db,
                IntegratedSecurity = true
            };
            return new SqlConnection(builder.ConnectionString);
        }

        public bool ExecuteNonQuery(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, params KomutArgumanlari_[] arguman)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection(ConnectionStrings);
            SqlCommand command = new SqlCommand(komut, connection) {
                CommandType = komutTipi,
                CommandTimeout = timeOut
            };
            if (arguman.ToList<KomutArgumanlari_>().Count > 0)
            {
                foreach (KomutArgumanlari_ i_ in arguman.ToList<KomutArgumanlari_>())
                {
                    command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                }
            }
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                flag = command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public bool ExecuteNonQuery_WithTransaction(string ConnectionStrings, TransacsionArgumanlari_[] transactionArgs)
        {
            bool flag = true;
            SqlConnection connection = new SqlConnection(ConnectionStrings);
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                transaction = connection.BeginTransaction();
                foreach (TransacsionArgumanlari_ i_ in transactionArgs)
                {
                    SqlCommand command = new SqlCommand(i_.Komut, connection, transaction);
                    foreach (KomutArgumanlari_ i_2 in i_.KomutArgumanDizisi)
                    {
                        command.Parameters.AddWithValue(i_2.ParametreAdi, i_2.Parametre);
                    }
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                flag = false;
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public DataTable ExecuteReader(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, params KomutArgumanlari_[] arguman)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionStrings);
            SqlCommand command = new SqlCommand(komut, connection) {
                CommandType = komutTipi,
                CommandTimeout = timeOut
            };
            if (arguman.ToList<KomutArgumanlari_>().Count > 0)
            {
                foreach (KomutArgumanlari_ i_ in arguman.ToList<KomutArgumanlari_>())
                {
                    command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                }
            }
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return table;
        }

        public object ExecuteScalar(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, params KomutArgumanlari_[] arguman)
        {
            object obj2 = 0;
            SqlConnection connection = new SqlConnection(ConnectionStrings);
            SqlCommand command = new SqlCommand(komut, connection) {
                CommandType = komutTipi,
                CommandTimeout = timeOut
            };
            if (arguman.ToList<KomutArgumanlari_>().Count > 0)
            {
                foreach (KomutArgumanlari_ i_ in arguman.ToList<KomutArgumanlari_>())
                {
                    command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                }
            }
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                obj2 = command.ExecuteScalar();
            }
            catch (Exception)
            {
                obj2 = 0;
            }
            finally
            {
                connection.Close();
            }
            return obj2;
        }

        public decimal ExecuteScalar_Decimal(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, params KomutArgumanlari_[] arguman)
        {
            decimal num = new decimal();
            SqlConnection connection = new SqlConnection(ConnectionStrings);
            SqlCommand command = new SqlCommand(komut, connection) {
                CommandType = komutTipi,
                CommandTimeout = timeOut
            };
            if (arguman.ToList<KomutArgumanlari_>().Count > 0)
            {
                foreach (KomutArgumanlari_ i_ in arguman.ToList<KomutArgumanlari_>())
                {
                    command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                }
            }
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                num = Convert.ToDecimal(command.ExecuteScalar());
            }
            catch (Exception)
            {
                num = new decimal();
            }
            finally
            {
                connection.Close();
            }
            return num;
        }

        public int ExecuteScalar_Int(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, params KomutArgumanlari_[] arguman)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(ConnectionStrings);
            SqlCommand command = new SqlCommand(komut, connection) {
                CommandType = komutTipi,
                CommandTimeout = timeOut
            };
            if (arguman.ToList<KomutArgumanlari_>().Count > 0)
            {
                foreach (KomutArgumanlari_ i_ in arguman.ToList<KomutArgumanlari_>())
                {
                    command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                }
            }
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                num = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                num = 0;
            }
            finally
            {
                connection.Close();
            }
            return num;
        }

        public void RestoreDatabase(string databaseName, string filePath, string serverName, string userName, string password, string dataFilePath, ref Exception hataMsj)
        {
            try
            {
                string physicalFileName = dataFilePath + databaseName + ".mdf";
                string str2 = dataFilePath + databaseName + "_Log.ldf";
                BackupDeviceItem item = new BackupDeviceItem(filePath, DeviceType.File);
                ServerConnection serverConnection = new ServerConnection(serverName, userName, password);
                Server server = new Server(serverConnection);
                if (!server.Databases.Contains(databaseName))
                {
                    server.Databases.Add(new Database(server, databaseName));
                    server.Refresh();
                }
                Restore restore = new Restore();
                restore.Devices.Add(item);
                restore.Database = databaseName;
                restore.RelocateFiles.Add(new RelocateFile(databaseName, physicalFileName));
                restore.RelocateFiles.Add(new RelocateFile(databaseName + "_log", str2));
                restore.ReplaceDatabase = true;
                restore.Action = RestoreActionType.Database;
                restore.SqlRestore(server);
            }
            catch (Exception exception)
            {
                hataMsj = exception;
            }
        }

        public bool TabloKolonVarmi(string ConnectionStrings, string tabloAdi, string kolonAdi)
        {
            return (this.ExecuteScalar_Int(ConnectionStrings, string.Format("select COUNT(*) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", tabloAdi, kolonAdi), CommandType.Text, 30, new KomutArgumanlari_[0]) > 0);
        }

        public bool TabloVarMi(string ConnectionStrings, string tabloAdi)
        {
            return (Ornekle.ExecuteScalar_Int(ConnectionStrings, string.Format("SELECT COUNT(*) FROM SYS.tables WHERE NAME = '{0}'", tabloAdi), CommandType.Text, 30, new KomutArgumanlari_[0]) <= 0);
        }

        public static MyConnect Ornekle
        {
            get
            {
                object obj2 = __kilit;
                lock (obj2)
                {
                    if (__ornek == null)
                    {
                        __ornek = new MyConnect();
                    }
                    return __ornek;
                }
            }
        }
    }
}

