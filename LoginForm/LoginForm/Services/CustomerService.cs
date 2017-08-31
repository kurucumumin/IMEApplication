using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Services
{
    class CustomerService
    {

        public List<Customer> GetCustomers()
        {
            IMEEntities CustomerIME = new IMEEntities();

            return CustomerIME.Customers.ToList();

        }
    }
}
