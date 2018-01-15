using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;


namespace LoginForm.Account.Services
{
    class AdditionalCostSP
    {
        public void AdditionalCostEditByVoucherTypeIdAndVoucherNo(AdditionalCostInfo additionalcostinfo)
        {
            IMEEntities IME = new IMEEntities();
            IME.AdditionalCostEditByVoucherTypeIdAndVoucherNo(additionalcostinfo.VoucherTypeId, additionalcostinfo.VoucherNo, additionalcostinfo.LedgerId, additionalcostinfo.Debit, additionalcostinfo.Credit, additionalcostinfo.ExtraDate, additionalcostinfo.Extra1, additionalcostinfo.Extra2);
        }

        public void AdditionalCostDelete(decimal AdditionalCostId)
        {
            IMEEntities IME = new IMEEntities();
            IME.AdditionalCostDelete(AdditionalCostId);
        }

        public void AdditionalCostAdd(AdditionalCostInfo additionalcostinfo)
        {
            IMEEntities IME = new IMEEntities();
            IME.AdditionalCostAdd(additionalcostinfo.VoucherTypeId, additionalcostinfo.VoucherNo, additionalcostinfo.LedgerId,additionalcostinfo.Debit, additionalcostinfo.Credit);

            
        }
    }
}
