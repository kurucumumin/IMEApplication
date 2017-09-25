using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;

namespace LoginForm.Services
{
    
    class classQuotationAdd
    {
        public static string customersearchID;
        public static string customersearchname;
        public static string customerID;
        public static string customername;

        public static List<Customer> CustomerSearch()
        {
            IMEEntities IME = new IMEEntities();
            List<Customer> c = new List<Customer>();
            if (customersearchname == "")
            {
                c = IME.Customers.Where(a => a.ID.Contains(customersearchID)).ToList();
            }
            else
            {
                c = IME.Customers.Where(a => a.c_name.Contains(customersearchname)).ToList();
            }
            return c;
        }
        
    }
}
