using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace LoginForm.Account.Services
{
    class BonusDedutionSP
    {
        public DataTable BonusDeductionSearch(String strName, DateTime dtMonth)
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            IMEEntities IME = new IMEEntities();
            dtbl.Columns.Add("WorkerID");
            dtbl.Columns.Add("NameLastName");
            dtbl.Columns.Add("month");
            dtbl.Columns.Add("bonusAmount");
            dtbl.Columns.Add("bonusDeductionId");
            foreach (var item in IME.BonusDeductionSearch(strName,dtMonth))
            {
                var row = dtbl.NewRow();
                row["WorkerID"] = item.WorkerID;
                row["NameLastName"] = item.NameLastName;
                row["month"] = item.month;
                row["bonusAmount"] = item.bonusAmount;
                row["bonusDeductionId"] = item.bonusDeductionId;
                dtbl.Rows.Add(row);
            }

                return dtbl;
        }
    }
}
