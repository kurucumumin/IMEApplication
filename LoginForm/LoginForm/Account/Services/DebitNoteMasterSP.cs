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
    class DebitNoteMasterSP
    {
        public DataTable DebitNoteMasterViewAllWithSlNo()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from dn in db.DeliveryNoteMasters
                               select new
                               {
                                   dn.deliveryNoteMasterId,
                                   dn.voucherNo,
                                   dn.DeliveryNoteNo,
                                   dn.suffixPrefixId,
                                   dn.date,
                                   dn.userId,
                                   dn.totalAmount,
                                   dn.narration,
                                   dn.financialYearId,
                                   dn.voucherTypeId
                               }).ToList();

                dtbl.Columns.Add("deliveryNoteMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("financialYearId");
                dtbl.Columns.Add("voucherTypeId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["deliveryNoteMasterId"] = item.deliveryNoteMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.DeliveryNoteNo;
                    row["suffixPrefixId"] = item.suffixPrefixId;
                    row["date"] = item.date;
                    row["userId"] = item.userId;
                    row["totalAmount"] = item.totalAmount;
                    row["narration"] = item.narration;
                    row["financialYearId"] = item.financialYearId;
                    row["voucherTypeId"] = item.voucherTypeId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable DebitNoteRegisterSearch(string strVoucherNo, string strFromDate, string strToDate)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            //try
            //{
            //    //var adaptor = (from dn in db.DeliveryNoteMasters.Where(x=>x.voucherNo.StartsWith(strVoucherNo) && (x.date > DateTime.Parse(strFromDate) && x.date < DateTime.Parse(strToDate))).OrderByDescending(y=>y.deliveryNoteMasterId)
            //    //               select new
            //    //               {
            //    //                   dn.deliveryNoteMasterId,
            //    //                   dn.voucherNo,
            //    //                   dn.invoiceNo,
            //    //                   dn.VoucherType.voucherTypeName,
            //    //                   dn.suffixPrefixId,
            //    //                   dn.date,
            //    //                   dn.totalAmount,
            //    //                   dn.narration,
            //    //                   dn.userId,
            //    //                   dn.voucherTypeId,
            //    //                   dn.financialYearId
            //    //               }).ToList();

            //    var adaptor = db.DebitNoteRegisterSearch(strVoucherNo, strFromDate, strToDate).ToList();

            //    dtbl.Columns.Add("voucherNo");
            //    dtbl.Columns.Add("voucherTypeName");
            //    dtbl.Columns.Add("date");
            //    dtbl.Columns.Add("totalAmount");
            //    dtbl.Columns.Add("narration");
            //    dtbl.Columns.Add("userName");

            //    foreach (var item in adaptor)
            //    {
            //        var row = dtbl.NewRow();

            //        row["voucherNo"] = item.voucherNo;
            //        row["voucherTypeName"] = item.voucherTypeName;
            //        row["date"] = item.date;
            //        row["totalAmount"] = item.totalAmount;
            //        row["narration"] = item.narration;
            //        row["userName"] = item.userName;

            //        dtbl.Rows.Add(row);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            return dtbl;
        }

        public decimal DebitNoteMasterGetMaxPlusOne(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal max = 0;
            try
            {
                max = (decimal)IME.DebitNoteMasterMax(decVoucherTypeId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max + 1;
        }

        public decimal DebitNoteMasterGetMax(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            decimal max = 0;
            try
            {
                 max = (decimal)IME.DebitNoteMasterMax(decVoucherTypeId).FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public bool DebitNoteVoucherCheckExistance(string strInvoiceNo, decimal VoucherTypeId, decimal decMasterId)
        {
            IMEEntities IME = new IMEEntities();
            bool trueOrfalse = false;
            try
            {
                decimal? adapter = (from dn in IME.DebitNoteMasters.Where(p => p.invoiceNo == strInvoiceNo && p.voucherTypeId==VoucherTypeId && p.debitNoteMasterId !=decMasterId)
                                select new { dn.invoiceNo }).Count();
                trueOrfalse = (adapter >0) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return trueOrfalse;
        }

        public void DebitNoteVoucherDelete(decimal decDebitNoteMasterId, decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();

            try
            {
                List<PartyBalance> ListPb = db.PartyBalances.Where(x => (x.voucherTypeId == decVoucherTypeId && x.referenceType == "New") || (x.againstVoucherTypeId == decVoucherTypeId && x.againstVoucherNo == strVoucherNo && x.referenceType == "Against") || (x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "OnAccount")).ToList();
                db.PartyBalances.RemoveRange(ListPb);
                db.SaveChanges();

                decimal? ledgerPostID = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).FirstOrDefault().ledgerPostingId;

                List<BankReconciliation> listBr = db.BankReconciliations.Where(x => x.ledgerPostingId == ledgerPostID).ToList();
                db.BankReconciliations.RemoveRange(listBr);
                db.SaveChanges();

                List<LedgerPosting> listLp = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();
                db.LedgerPostings.RemoveRange(listLp);
                db.SaveChanges();

                DebitNoteDetail dn = db.DebitNoteDetails.Where(x => x.debitNoteMasterId == decDebitNoteMasterId).FirstOrDefault();
                db.DebitNoteDetails.Remove(dn);
                db.SaveChanges();

                DebitNoteMaster dm = db.DebitNoteMasters.Where(x => x.debitNoteMasterId == decDebitNoteMasterId).FirstOrDefault();
                db.DebitNoteMasters.Remove(dm);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DNM:2" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public decimal DebitNoteMasterAdd(DebitNoteMaster debitnotemasterinfo)
        {
            IMEEntities db = new IMEEntities();
            DebitNoteMaster pdc = debitnotemasterinfo;
            decimal decDebitNoteMasterId = 0;
            try
            {
                db.DebitNoteMasters.Add(pdc);
                db.SaveChanges();
                decDebitNoteMasterId = pdc.debitNoteMasterId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decDebitNoteMasterId;


            
        }

        public decimal DebitNoteMasterEdit(DebitNoteMaster debitnotemasterinfo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decEffectRow = 0;
            try
            {
                DebitNoteMaster debitnotemaster = IME.DebitNoteMasters.Where(a => debitnotemasterinfo.debitNoteMasterId == a.debitNoteMasterId).FirstOrDefault();


                debitnotemaster.voucherNo = debitnotemasterinfo.voucherNo;
                debitnotemaster.invoiceNo = debitnotemasterinfo.invoiceNo;
                debitnotemaster.suffixPrefixId = debitnotemasterinfo.suffixPrefixId;
                debitnotemaster.date = debitnotemasterinfo.date;
                debitnotemaster.userId = debitnotemasterinfo.userId;
                debitnotemaster.totalAmount = debitnotemasterinfo.totalAmount;
                debitnotemaster.narration = debitnotemasterinfo.narration;
                debitnotemaster.financialYearId = debitnotemasterinfo.financialYearId;
                debitnotemaster.voucherTypeId = debitnotemasterinfo.voucherTypeId;

                IME.SaveChanges();

                decEffectRow = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decEffectRow;
        }

        public DebitNoteMaster DebitNoteMasterView(decimal debitNoteMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DebitNoteMaster debitnotemasterinfo = new DebitNoteMaster();
            
            try
            {
                debitnotemasterinfo = IME.DebitNoteMasters.Where(rm => rm.debitNoteMasterId == debitNoteMasterId).FirstOrDefault();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return debitnotemasterinfo;
        }

        public decimal DebitNoteMasterIdView(decimal decVouchertypeid, string strVoucherNo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decid = 0;
            try
            {
                decid = Convert.ToDecimal(IME.DebitNoteMasterIdView(decVouchertypeid, strVoucherNo).FirstOrDefault());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decid;
        }
    }
}
