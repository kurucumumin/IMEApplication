using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LoginForm.Services
{
    class classSupplier
    {
        public static string suppliersearchID;
        public static string suppliersearchname;
        public static string supplierID;
        public static string suppliername;
        public static Supplier Supplier; 
        public static List<Supplier> SupplierSearch()
        {
            IMEEntities IME = new IMEEntities();
            List<Supplier> c = new List<Supplier>();
            if (suppliersearchname == "")
            {
                c = IME.Suppliers.Where(a => a.ID.Contains(suppliersearchID)).ToList().Where(a => a.s_name != null).Where(b => b.s_name != string.Empty).ToList();
            }
            else
            {
                c = IME.Suppliers.Where(a => a.s_name.Contains(suppliersearchname)).ToList().Where(a => a.s_name != null).Where(b => b.s_name != string.Empty).ToList();
            }
            return c;
        }
    }

}
