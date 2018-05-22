using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;

namespace LoginForm.Services
{
    class classAccount
    {
        public static string accountsearchID;
        public static string accountsearchname;
        public static string accountID;
        public static string accountname;
        public static List<DataSet.Account> AccountSearch()
        {
            IMEEntities IME = new IMEEntities();
            List<Supplier> c = new List<Supplier>();
            if (accountsearchname == "")
            {
                c = IME.Accounts.Where(a => a.ID.Contains(suppliersearchID)).ToList().Where(a => a.Name != null).Where(b => b.Name != string.Empty).ToList();
            }
            else
            {
                c = IME.Accounts.Where(a => a.Name.Contains(accountsearchname)).ToList().Where(a => a.Name != null).Where(b => b.Name != string.Empty).ToList();
            }
            return c;
        }

    }
}
