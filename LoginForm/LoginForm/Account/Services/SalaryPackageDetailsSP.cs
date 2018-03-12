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

        public DataTable SalaryPackageDetailsViewWithSalaryPackageId(decimal decSalaryPackageId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.SalaryPackageDetailsViewWithSalaryPackageId(decSalaryPackageId).ToList();


                dtbl.Columns.Add("payHeadId");
                dtbl.Columns.Add("Amount");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["payHeadId"] = item.payHeadId;
                    row["Amount"] = item.Amount;


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
