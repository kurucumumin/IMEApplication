using LoginForm.DataSet;
using System.Collections.Generic;
using System.Linq;

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
