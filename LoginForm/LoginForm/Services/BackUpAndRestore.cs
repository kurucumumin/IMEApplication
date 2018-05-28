using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Services
{
    class BackUpAndRestore
    {
        static public void BackUp()
        {
            string ServerName = ".";
            string DBName = "IME";
            Server dbServer = new Server(new ServerConnection(ServerName));
            Backup DBBackUp = new Backup() { Action = BackupActionType.Database, Database = DBName };
            DBBackUp.Devices.AddDevice(@"C:\IMEDBBackUp\IME.bak", DeviceType.File);
            DBBackUp.Initialize = true;
            DBBackUp.SqlBackupAsync(dbServer);
        }

        static public void Restore()
        {
            string ServerName = ".";
            string DBName = "IME";
            Server dbServer = new Server(new ServerConnection(ServerName));
            Restore DBRestore = new Restore() { Database = DBName, Action = RestoreActionType.Database };
            DBRestore.Devices.AddDevice(@"C:\IMEDBBackUp\IME.bak", DeviceType.File);
            DBRestore.SqlRestoreAsync(dbServer);
        }

    }
}
