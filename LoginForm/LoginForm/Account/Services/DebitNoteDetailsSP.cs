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
    class DebitNoteDetailsSP
    {
       
        public decimal DebitNoteDetailsAdd(DebitNoteDetail debitnotedetailsinfo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decDebitNoteDetails = 0;
            try
            {
                IME.DebitNoteDetails.Add(debitnotedetailsinfo);
                IME.SaveChanges();
                decDebitNoteDetails = debitnotedetailsinfo.debitNoteDetailsId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decDebitNoteDetails;
        }
        
        public void DebitNoteDetailsEdit(DebitNoteDetail di)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                DebitNoteDetail pdc = IME.DebitNoteDetails.Where(pd => pd.debitNoteDetailsId == di.debitNoteDetailsId).FirstOrDefault();

                pdc.debitNoteMasterId = di.debitNoteMasterId;
                pdc.ledgerId = di.ledgerId;
                pdc.credit = di.credit;
                pdc.debit = di.debit;
                pdc.exchangeRateId= di.exchangeRateId;
                pdc.chequeNo =di.chequeNo;
                pdc.chequeDate =di.chequeDate;
                pdc.chequeDate = di.chequeDate;

                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        public DataTable DebitNoteDetailsViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from pdc in IME.DebitNoteDetails
                               select new
                               {
                                   pdc.debitNoteDetailsId,
                                   pdc.debitNoteMasterId,
                                   pdc.ledgerId,
                                   pdc.credit,
                                   pdc.debit,
                                   pdc.exchangeRateId,
                                   pdc.chequeNo,
                                   pdc.chequeDate
                               }).ToList();

                dtbl.Columns.Add("debitNoteDetailsId");
                dtbl.Columns.Add("debitNoteMasterId");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("credit");
                dtbl.Columns.Add("debit");
                dtbl.Columns.Add("exchangeRateId");
                dtbl.Columns.Add("chequeNo");
                dtbl.Columns.Add("chequeDate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["debitNoteDetailsId"] = item.debitNoteDetailsId;
                    row["debitNoteMasterId"] = item.debitNoteMasterId;
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
       
        public DebitNoteDetail DebitNoteDetailsView(decimal debitNoteDetailsId)
        {
            IMEEntities IME = new IMEEntities();
            DebitNoteDetail debitnotedetailsinfo = new DebitNoteDetail();
            try
            {
                debitnotedetailsinfo = IME.DebitNoteDetails.Where(rm => rm.debitNoteDetailsId == debitNoteDetailsId).FirstOrDefault();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return debitnotedetailsinfo;
        }
        
        public void DebitNoteDetailsDelete(decimal DebitNoteDetailsId)
        {
            IMEEntities IME = new IMEEntities();
            DebitNoteDetail db = new DebitNoteDetail();
            try
            {
                db = IME.DebitNoteDetails.Where(x => x.debitNoteDetailsId==DebitNoteDetailsId).FirstOrDefault();
                IME.DebitNoteDetails.Remove(db);

                IME.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       
        //public int DebitNoteDetailsGetMax()
        //{
        //    IMEEntities IME = new IMEEntities();
        //    int max = 0;
        //    try
        //    {
        //        int? adapter = (from dn in IME.DebitNoteDetails
        //                        select new { dn. }).Max(x => Convert.ToInt32(x.voucherNo));

        //        max = (adapter != null) ? (int)adapter : 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return max;
        //}

        public DataTable DebitNoteDetailsViewByMasterId(decimal decMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from pdc in IME.DebitNoteDetails
                               where pdc.debitNoteMasterId==decMasterId
                               select new
                               {
                                   pdc.debitNoteDetailsId,
                                   pdc.debitNoteMasterId,
                                   pdc.ledgerId,
                                   pdc.credit,
                                   pdc.debit,
                                   pdc.exchangeRateId,
                                   pdc.chequeNo,
                                   pdc.chequeDate
                               }).ToList();

                dtbl.Columns.Add("debitNoteDetailsId");
                dtbl.Columns.Add("debitNoteMasterId");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("credit");
                dtbl.Columns.Add("debit");
                dtbl.Columns.Add("exchangeRateId");
                dtbl.Columns.Add("chequeNo");
                dtbl.Columns.Add("chequeDate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["debitNoteDetailsId"] = item.debitNoteDetailsId;
                    row["debitNoteMasterId"] = item.debitNoteMasterId;
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
