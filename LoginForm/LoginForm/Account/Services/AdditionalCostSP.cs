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
    class AdditionalCostSP
    {
        public DataTable AdditionalCostViewAllByVoucherTypeIdAndVoucherNo(decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.AdditionalCostViewAllByVoucherTypeIdAndVoucherNo(decVoucherTypeId, strVoucherNo);

                dtbl.Columns.Add("additionalCostId");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("amount");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["additionalCostId"] = item.additionalCostId;
                    row["ledgerId"] = item.ledgerId;
                    row["amount"] = item.amount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public void AdditionalCostAdd(AdditionalCost additionalcostinfo)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.AdditionalCostAdd(
                    additionalcostinfo.voucherTypeId,
                    additionalcostinfo.voucherNo,
                    additionalcostinfo.ledgerId,
                    additionalcostinfo.debit,
                    additionalcostinfo.credit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void AdditionalCostEdit(AdditionalCost a)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.AdditionalCostEdit(
                    a.additionalCostId,
                    a.voucherTypeId,
                    a.voucherNo,
                    a.ledgerId,
                    a.debit,
                    a.credit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void AdditionalCostDelete(decimal AdditionalCostId)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.AdditionalCostDelete(AdditionalCostId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
