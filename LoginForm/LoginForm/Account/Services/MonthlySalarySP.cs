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

        public decimal MonthlySalarySettingsMonthlySalaryIdSearchUsingSalaryMonth(DateTime dtSalaryMonth)
        {
            IMEEntities IME = new IMEEntities();
            decimal i = 0;
            try
            {
                i = Convert.ToDecimal(IME.MonthlySalarySettingsMonthlySalaryIdSearchUsingSalaryMonth(dtSalaryMonth));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return i;
        }

        public DataTable MonthlySalarySettingsEmployeeViewAll(DateTime dtSalaryMonth)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.MonthlySalarySettingsEmployeeViewAll(dtSalaryMonth).ToList();
                
                dtbl.Columns.Add("WorkerId");
                dtbl.Columns.Add("NameLastName");
                dtbl.Columns.Add("UserName");
                dtbl.Columns.Add("defaultPackageId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["WorkerId"] = item.WorkerId;
                    row["NameLastName"] = item.NameLastName;
                    row["UserName"] = item.UserName;
                    row["defaultPackageId"] = item.defaultPackageId;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return dtbl;
        }

        public void MonthlySalaryDeleteAll(decimal decMonthlySalaryId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.MonthlySalaryDeleteAll(decMonthlySalaryId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal MonthlySalaryAddWithIdentity(MonthlySalary ms)
        {
            IMEEntities IME = new IMEEntities();
            decimal decIdentity = 0;
            try
            {

                object obj = IME.MonthlySalaryAddWithIdentity(ms.salaryMonth,
                    ms.narration);
                if (obj != null)
                {
                    decIdentity = Convert.ToDecimal(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public void MonthlySalarySettingsEdit(MonthlySalary ms)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.MonthlySalarySettingsEdit(ms.monthlySalaryId,
                    ms.salaryMonth.ToString(),
                    ms.narration);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
