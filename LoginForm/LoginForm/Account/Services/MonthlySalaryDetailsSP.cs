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
    class MonthlySalaryDetailsSP
    {
        public void MonthlySalaryDetailsAddWithMonthlySalaryId(MonthlySalaryDetail ms)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.MonthlySalaryDetailsAddWithMonthlySalaryId(ms.employeeId,
                    ms.salaryPackageId,
                    ms.monthlySalaryId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void MonthlySalaryDetailsEditUsingMasterIdAndDetailsId(MonthlySalaryDetail ms)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.MonthlySalaryDetailsEditUsingMasterIdAndDetailsId(ms.monthlySalaryDetailsId,
                    ms.monthlySalaryId,
                    ms.employeeId,
                    ms.salaryPackageId);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void MonthlySalarySettingsDetailsIdDelete(decimal MonthlySalaryDetailsId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.MonthlySalarySettingsDetailsIdDelete(MonthlySalaryDetailsId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
