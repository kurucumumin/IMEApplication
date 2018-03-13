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

        public SalaryPackage SalaryPackageView(decimal salaryPackageId)
        {
            IMEEntities IME = new IMEEntities();
            SalaryPackage sp= new SalaryPackage();
            
            try
            {
                var a = IME.SalaryPackageView(salaryPackageId).FirstOrDefault();

                sp.salaryPackageId = a.salaryPackageId;
                sp.salaryPackageName = a.salaryPackageName;
                sp.isActive= a.isActive;
                sp.narration = a.narration;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return sp;
        }

        public DataTable SalaryPackageregisterSearch(string strSalaryPackageName, string strStatus)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.SalaryPackageregisterSearch(strSalaryPackageName, strStatus).ToList();


                dtbl.Columns.Add("salaryPackageId");
                dtbl.Columns.Add("salaryPackageName");
                dtbl.Columns.Add("isActive");
                dtbl.Columns.Add("totalAmount");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["salaryPackageId"] = item.salaryPackageId;
                    row["salaryPackageName"] = item.salaryPackageName;
                    row["isActive"] = item.isActive;
                    row["totalAmount"] = item.totalAmount;


                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable SalaryPackageViewAllForMonthlySalarySettings()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.SalaryPackageViewAllForMonthlySalarySettings().ToList();


                dtbl.Columns.Add("salaryPackageId");
                dtbl.Columns.Add("salaryPackageName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["salaryPackageId"] = item.salaryPackageId;
                    row["salaryPackageName"] = item.salaryPackageName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
    }
}
