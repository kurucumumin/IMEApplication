using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace LoginForm.Account.Services
{
    class PartyBalanceSP
    {
        public void PartyBalanceAdd(PartyBalance partybalanceinfo)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PartyBalances.Add(partybalanceinfo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public int PartyBalanceDeleteByVoucherTypeAndVoucherNo(decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();
            List<PartyBalance> list = new List<PartyBalance>();
            int inEffect = 0;
            try
            {
                list = db.PartyBalances.Where(x => x.againstVoucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();

                foreach (PartyBalance item in list)
                {
                    db.PartyBalances.Remove(item);
                }
                inEffect = db.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).Count();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return inEffect;
        }
    }
}
