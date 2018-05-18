using LoginForm.DataSet;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.Services
{
    class CustomerSP
    {

        public List<Customer> GetCustomers()
        {
            IMEEntities CustomerIME = new IMEEntities();

            return CustomerIME.Customers.ToList();

        }

        public bool DebitCustomer(string CustomerID, decimal amount)
        {
            IMEEntities db = new IMEEntities();
            bool result = false;

            try
            {
                Customer c = db.Customers.Where(x=>x.ID == CustomerID).FirstOrDefault();

                c.Debit += amount;

                db.SaveChanges();

                result = true;
            }
            catch (System.Exception e)
            {
                MessageBox.Show("CustServ 1: Debit Error", "Error");
            }

            return result;
        }
    }
}
