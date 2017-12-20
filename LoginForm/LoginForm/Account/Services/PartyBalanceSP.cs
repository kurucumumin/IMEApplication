using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

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
        public void PartyBalanceEdit(PartyBalance pb)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                PartyBalance p = db.PartyBalances.Where(x => x.partyBalanceId == pb.partyBalanceId).FirstOrDefault();
                p.date = pb.date;
                p.ledgerId = pb.ledgerId;
                p.voucherTypeId = pb.voucherTypeId;
                p.voucherNo = pb.voucherNo;
                p.againstVoucherTypeId = pb.againstVoucherTypeId;
                p.againstVoucherNo = pb.againstVoucherNo;
                p.invoiceNo = pb.invoiceNo;
                p.againstInvoiceNo = pb.againstInvoiceNo;
                p.referenceType = pb.referenceType;
                p.debit = pb.debit;
                p.credit = pb.credit;
                p.creditPeriod = pb.creditPeriod;
                p.exchangeRateId = pb.exchangeRateId;
                p.financialYearId = pb.financialYearId;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool PartyBalanceCheckReference(decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();
            bool isReferenceExist = false;
            try
            {
                int count = db.PartyBalances.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.againstVoucherTypeId != 0 && x.againstVoucherNo != "0").Count();

                isReferenceExist = (count > 0) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PBSP:2" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isReferenceExist;
        }

    }
}
