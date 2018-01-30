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
    class AdvancePaymentSP
    {
        public bool CheckSalaryAlreadyPaidOrNot(decimal decEmployeeId, DateTime date)
        {
            IMEEntities IME = new IMEEntities();
            bool isPaid = false;
            try
            {
                var adaptor = IME.CheckSalaryAlreadyPaidOrNot(decEmployeeId,date).ToList();

                isPaid = (adaptor.Count() > 0) ? false : true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isPaid;
        }

        public DataTable AdvancePaymentAddWithIdentity(AdvancePayment advancepaymentinfo, bool IsAutomatic)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            AdvancePayment ad= advancepaymentinfo;
            try
            {

              var adaptor=(IME.AdvancePaymentAddWithIdentity(ad.employeeId,ad.ledgerId,ad.voucherNo,ad.invoiceNo,Convert.ToDateTime(ad.date),ad.amount,ad.salaryMonth,ad.chequenumber, Convert.ToDateTime(ad.chequeDate),ad.narration,ad.suffixPrefixId,ad.voucherTypeId,ad.financialYearId,IsAutomatic)).ToList();


                dtbl.Columns.Add("Identity");
                dtbl.Columns.Add("UpdatedVoucherNo");
                dtbl.Columns.Add("UpdatedInvoiceNo");
                

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Identity"] = item.Identity;
                    row["UpdatedVoucherNo"] = item.UpdatedVoucherNo;
                    row["UpdatedInvoiceNo"] = item.UpdatedInvoiceNo;
                    

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;

        }

        public decimal AdvancePaymentGetMaxPlusOne(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal Max = 0;
            try
            {
               Max= Convert.ToDecimal(IME.AdvancePayments.Where(a => a.voucherTypeId == decVoucherTypeId).Select(b => b.voucherNo).ToList().Max());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return Max + 1;
        }

        public string AdvancePaymentGetMax(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            string Max = "0";
            try
            {
                Max = IME.AdvancePayments.Where(a => a.voucherTypeId == decVoucherTypeId).Select(b => b.voucherNo).ToList().Max();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return Max;
        }
    }
}
