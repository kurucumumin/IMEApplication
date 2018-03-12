using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class SalaryPackageDetailsSP
    {
        public bool SalaryPackageDetailsAdd(SalaryPackageDetail sp)
        {
            IMEEntities IME = new IMEEntities();
            bool isSave = false;
            try
            {
               string sayi= IME.SalaryPackageDetailsAdd(sp.salaryPackageId,
                    sp.payHeadId,
                    sp.amount,
                    sp.narration).ToString();

                if (sayi != "" && sayi != null)
                {
                    isSave = true;
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isSave;
        }

        public void SalaryPackageDetailsDeleteWithSalaryPackageId(decimal SalaryPackageId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.SalaryPackageDetailsDeleteWithSalaryPackageId(SalaryPackageId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string PayHeadTypeView(decimal payHeadId)
        {
            IMEEntities IME = new IMEEntities();
            string price = null;
            try
            {
                price = IME.PayHeadTypeView(payHeadId).ToString();
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.ToString());
            }
            return price;
        }
    }
}
