using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm.Account.Services
{
    class CreditNoteDetailsSP
    {

        public decimal CreditNoteDetailsAdd(CreditNoteDetail creditnotedetailsinfo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decId = 0;
            try
            {
                IME.CreditNoteDetails.Add(creditnotedetailsinfo);
                IME.SaveChanges();
                decId = creditnotedetailsinfo.creditNoteDetailsId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decId;
        }

        public void CreditNoteDetailsDelete(decimal CreditNoteMasterId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                List<CreditNoteDetail> cmList = IME.CreditNoteDetails.Where(x => x.creditNoteDetailsId == CreditNoteMasterId).ToList();
                IME.CreditNoteDetails.RemoveRange(cmList);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal CreditNoteDetailsEdit(CreditNoteDetail pi)
        {
            IMEEntities IME = new IMEEntities();
            decimal decCreditNoteMaster = 0;

            try
            {
                CreditNoteDetail pdc = IME.CreditNoteDetails.Where(pd => pi.creditNoteDetailsId == pd.creditNoteDetailsId).FirstOrDefault();

                pdc.creditNoteDetailsId = pi.creditNoteDetailsId;
                pdc.creditNoteMasterId = pi.creditNoteMasterId;
                pdc.ledgerId = pi.ledgerId;
                pdc.credit = pi.credit;
                pdc.debit = pi.debit;
                pdc.chequeNo= pi.chequeNo;
                pdc.chequeDate = pi.chequeDate;

                IME.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decCreditNoteMaster;
        }

        public DataTable CreditNoteDetailsViewByMasterId(decimal decMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;

            try
            {

                var adaptor = (from pdc in IME.CreditNoteDetails
                               where pdc.creditNoteMasterId == decMasterId
                               select new
                               {
                                   pdc.creditNoteDetailsId,
                                   pdc.creditNoteMasterId,
                                   pdc.ledgerId,
                                   pdc.credit,
                                   pdc.debit,
                                   pdc.exchangeRateId,
                                   pdc.chequeNo,
                                   pdc.chequeDate
                               }).ToList();

                dtbl.Columns.Add("creditNoteDetailsId");
                dtbl.Columns.Add("creditNoteMasterId");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("credit");
                dtbl.Columns.Add("debit");
                dtbl.Columns.Add("exchangeRateId");
                dtbl.Columns.Add("chequeNo");
                dtbl.Columns.Add("chequeDate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["creditNoteDetailsId"] = item.creditNoteDetailsId;
                    row["creditNoteMasterId"] = item.creditNoteMasterId;
                    row["ledgerId"] = item.ledgerId;
                    row["credit"] = item.credit;
                    row["debit"] = item.debit;
                    row["exchangeRateId"] = item.exchangeRateId;
                    row["chequeNo"] = item.chequeNo;
                    row["chequeDate"] = item.chequeDate;

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
