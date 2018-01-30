using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginForm.Account.Services
{
    class MonthlySalarySP
    {
        public bool CheckSalaryAlreadyPaidOrNotForAdvancePayment(decimal decEmployeeId, DateTime date)
        {
            IMEEntities IME = new IMEEntities();
            bool isPaid = false;
            try
            {
                var adaptor = IME.CheckSalaryAlreadyPaidOrNotForAdvancePayment(decEmployeeId, date).ToList();

                isPaid = (adaptor.Count() >0) ? false : true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isPaid;
        }

    }
}
