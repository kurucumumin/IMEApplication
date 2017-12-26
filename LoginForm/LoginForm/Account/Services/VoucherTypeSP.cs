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
    class VoucherTypeSP
    {
        public bool CheckMethodOfVoucherNumbering(decimal voucherTypeId)
        {
            VoucherType infoVoucherType = new VoucherType();
            bool isAutomatic = false;
            try
            {
                infoVoucherType.methodOfVoucherNumbering = new IMEEntities().VoucherTypes.Where(x => x.voucherTypeId == voucherTypeId).FirstOrDefault().methodOfVoucherNumbering;
                if (infoVoucherType.methodOfVoucherNumbering == "Automatic")
                {
                    isAutomatic = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isAutomatic;
        }

        public void voucherTypeComboFill(ComboBox cmbVoucherType, bool isAll)
        {
            IMEEntities IME = new IMEEntities();

            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from vt in IME.VoucherTypes.Where(x => x.voucherTypeId != 1 && x.voucherTypeId != 2)
                               select new { vt.voucherTypeName }).ToList();

                dtbl.Columns.Add("voucherTypeName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["voucherTypeName"] = item.voucherTypeName;
                    
                    dtbl.Rows.Add(row);
                }
                cmbVoucherType.DataSource = dtbl;
                cmbVoucherType.ValueMember = "voucherTypeId";
                cmbVoucherType.DisplayMember = "voucherTypeName";
                cmbVoucherType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string TypeOfVoucherView(string strvoucherTypeName)
        {
            IMEEntities IME = new IMEEntities();
            string StrTypeOfVoucher = string.Empty;
            try
            {
                StrTypeOfVoucher= IME.VoucherTypes.Where(x => x.voucherTypeName == strvoucherTypeName).FirstOrDefault().typeOfVoucher;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return StrTypeOfVoucher;
        }

        public DataTable VoucherSearchFill(DateTime fromDate, DateTime toDate, decimal decVoucherTypeId, string strVoucherNo, decimal decLedgerId, decimal decEmployeeId)
        {
            IMEEntities IME = new IMEEntities();

            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl No");
            dtbl.Columns["Sl No"].AutoIncrement = true;
            dtbl.Columns["Sl No"].AutoIncrementSeed = 1;
            dtbl.Columns["Sl No"].AutoIncrementStep = 1;
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return dtbl;
        }

    }
}
