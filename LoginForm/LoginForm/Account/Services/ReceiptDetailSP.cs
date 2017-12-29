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
    class ReceiptDetailSP
    {
        public decimal ReceiptDetailsAdd(ReceiptDetail receiptdetailsinfo)
        {
            IMEEntities db = new IMEEntities();
            decimal decReceiptDetailsId = 0;
            try
            {
                db.ReceiptDetails.Add(receiptdetailsinfo);
                decReceiptDetailsId = receiptdetailsinfo.receiptDetailsId;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decReceiptDetailsId;
        }

        public void ReceiptDetailsDelete(decimal ReceiptDetailsId)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.ReceiptDetails.Remove(db.ReceiptDetails.Where(x=>x.receiptDetailsId == ReceiptDetailsId).FirstOrDefault());
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public decimal ReceiptDetailsEdit(ReceiptDetail rdi)
        {
            IMEEntities db = new IMEEntities();
            decimal decReceiptDetailsId = 0;
            try
            {
                ReceiptDetail rd = db.ReceiptDetails.Where(x => x.receiptDetailsId == rdi.receiptDetailsId).FirstOrDefault();

                rd.receiptMasterId = rdi.receiptMasterId;
                rd.ledgerId = rdi.ledgerId;
                rd.amount = rdi.amount;
                rd.exchangeRateId = rdi.exchangeRateId;
                rd.chequeNo = rdi.chequeNo;
                rd.chequeDate = rdi.chequeDate;

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decReceiptDetailsId;
        }

        public DataTable ReceiptDetailsViewByMasterId(decimal decreceiptMastertId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                List<ReceiptDetail> details = db.ReceiptDetails.Where(x=>x.receiptMasterId == decreceiptMastertId).ToList();

                dtbl.Columns.Add("receiptMasterId");
                dtbl.Columns.Add("receiptDetailsId");
                dtbl.Columns.Add("amount");
                dtbl.Columns.Add("exchangeRateId");
                dtbl.Columns.Add("chequeNo");
                dtbl.Columns.Add("chequeDate");
                dtbl.Columns.Add("ledgerId");

                foreach (ReceiptDetail item in details)
                {
                    var row = dtbl.NewRow();

                    row["receiptMasterId"] = item.receiptMasterId;
                    row["receiptDetailsId"] = item.receiptDetailsId;
                    row["amount"] = item.amount;
                    row["exchangeRateId"] = item.exchangeRateId;
                    row["chequeNo"] = item.chequeNo;
                    row["chequeDate"] = item.chequeDate;
                    row["ledgerId"] = item.ledgerId;

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
