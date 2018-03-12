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
    class SalaryPackageSP
    {
        public void SalaryPackageDeleteAll(decimal SalaryPackageId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.SalaryPackageDeleteAll(SalaryPackageId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SalaryPackageDelete(decimal SalaryPackageId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.SalaryPackageDelete(SalaryPackageId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal SalaryPackageAdd(SalaryPackage sp)
        {
            IMEEntities IME = new IMEEntities();
            decimal decIdentity = -1;
            try
            {

                string obj = IME.SalaryPackageAdd(sp.salaryPackageName,
                    sp.isActive,
                    sp.narration,
                    sp.totalAmount).ToString();


                if (obj != null && obj != "")
                {
                    decIdentity = Convert.ToDecimal(obj.ToString());
                }
                else
                {
                    decIdentity = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public bool SalaryPackageNameCheckExistance(string strSalaryPackageName)
        {
            IMEEntities IME = new IMEEntities();
            bool isExists = false;
            try
            {
                object obj = IME.SalaryPackageNameCheckExistance(strSalaryPackageName).ToList();

                if (obj != null)
                {
                    isExists = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isExists;
        }

        public void SalaryPackageEdit(SalaryPackage sp)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.SalaryPackageEdit(sp.salaryPackageId,
                    sp.salaryPackageName,
                    sp.isActive,
                    sp.narration,
                    sp.totalAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
