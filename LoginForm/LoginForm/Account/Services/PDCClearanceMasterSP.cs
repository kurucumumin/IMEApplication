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
    class PDCClearanceMasterSP
    {
        public DataTable VouchertypeComboFill()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (from pl in db.VoucherTypes.OrderBy(x => (x.typeOfVoucher == "Pdc payable" || x.typeOfVoucher == "PDC Receivable") && x.isActive == true)
                               select new
                               {
                                   pl.voucherTypeId,
                                   pl.voucherTypeName
                               }).ToList();

                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("voucherTypeName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["voucherTypeId"] = item.voucherTypeId;
                    row["voucherTypeName"] = item.voucherTypeName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        public DataTable InvoiceNumberCombofillUnderVoucherType(string strVoucherType, decimal MasterId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtblpdcPayableId = new DataTable();
            try
            {
                string typePayable = db.VoucherTypes.Where(x => x.typeOfVoucher == "PDC Payable" && x.voucherTypeName == strVoucherType).FirstOrDefault().voucherTypeName;
                string typeReceivable = db.VoucherTypes.Where(x => x.typeOfVoucher == "PDC Receivable" && x.voucherTypeName == strVoucherType).FirstOrDefault().voucherTypeName;
                dynamic generalList = new object();
                if (typePayable != null && typePayable != String.Empty)
                {
                    List<decimal> idList1 = db.PDCPayableMasters.Select(x => x.pdcPayableMasterId).ToList();
                    List<decimal> idList2 = db.PDCClearanceMasters.Where(x => x.againstId != MasterId && x.type == strVoucherType).Select(y=>(decimal)y.againstId).ToList();
                    var list = idList1.Except(idList2);

                    var adaptor = (from pm in db.PDCPayableMasters
                                   from vt in db.VoucherTypes.Where(x => x.voucherTypeId == pm.voucherTypeId).DefaultIfEmpty()
                                   from pdccm in db.PDCClearanceMasters.Where(x => x.againstId != MasterId && x.type == strVoucherType).DefaultIfEmpty()
                                   where
                                     vt.voucherTypeName == strVoucherType && list.Contains(pm.pdcPayableMasterId)
                                   select new
                                   {
                                       MasterId = pm.pdcPayableMasterId,
                                       pm.invoiceNo,
                                       pm.voucherNo
                                   }).ToList().Distinct();

                    generalList = adaptor;
                }else if (typeReceivable != null && typeReceivable != String.Empty)
                {
                    List<decimal> idList1 = db.PDCReceivableMasters.Select(x => x.pdcReceivableMasterId).ToList();
                    List<decimal> idList2 = db.PDCClearanceMasters.Where(x => x.againstId != MasterId && x.type == strVoucherType).Select(y => (decimal)y.againstId).ToList();
                    var list = idList1.Except(idList2);

                    var adaptor = (from pr in db.PDCReceivableMasters
                                   from al in db.AccountLedgers.Where(x => x.ledgerId == pr.ledgerId).DefaultIfEmpty()
                                   from pdccm in db.PDCClearanceMasters.Where(x => x.againstId == pr.pdcReceivableMasterId).DefaultIfEmpty()
                                   from vt in db.VoucherTypes.Where(x => x.voucherTypeId == pr.voucherTypeId).DefaultIfEmpty()
                                   
                                   where
                                     vt.voucherTypeName == strVoucherType && list.Contains(pr.pdcReceivableMasterId)
                                   select new
                                   {
                                       MasterId = pr.pdcReceivableMasterId,
                                       pr.invoiceNo,
                                       pr.voucherNo
                                   }).ToList().Distinct();
                    generalList = adaptor;
                }

                dtblpdcPayableId.Columns.Add("MasterId");
                dtblpdcPayableId.Columns.Add("invoiceNo");
                dtblpdcPayableId.Columns.Add("voucherNo");

                foreach (var item in generalList)
                {
                    var row = dtblpdcPayableId.NewRow();

                    row["MasterId"] = item.MasterId;
                    row["invoiceNo"] = item.invoiceNo;
                    row["voucherNo"] = item.voucherNo;

                    dtblpdcPayableId.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblpdcPayableId;
        }
        //public DataTable pdcclearancedetailsFill(string strVoucherType, decimal decmasterId)
        //{
        //    IMEEntities db = new IMEEntities();
        //    DataTable dtblpdcPayableId = new DataTable();
        //    try
        //    {
        //        string typePayable = db.VoucherTypes.Where(x => x.typeOfVoucher == "PDC Payable" && x.voucherTypeName == strVoucherType).FirstOrDefault().voucherTypeName;
        //        string typeReceivable = db.VoucherTypes.Where(x => x.typeOfVoucher == "PDC Receivable" && x.voucherTypeName == strVoucherType).FirstOrDefault().voucherTypeName;

        //        if (typePayable != null && typePayable != String.Empty)
        //        {
        //            var adaptor = from pm in db.PDCPayableMasters
        //                          join al in db.AccountLedgers on al



        //        }
        //        else if (typeReceivable != null && typeReceivable != String.Empty)
        //        {

        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return dtblpdcPayableId;
        //}
        public void PDCClearanceDelete(decimal PdcClearanceId, decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();

            try
            {
                List<PartyBalance> pList = db.PartyBalances.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "New").ToList();
                db.PartyBalances.RemoveRange(pList);

                List<LedgerPosting> lpList = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();
                db.LedgerPostings.RemoveRange(lpList);

                PDCClearanceMaster cm = db.PDCClearanceMasters.Where(x=>x.PDCClearanceMasterId == PdcClearanceId).FirstOrDefault();
                db.PDCClearanceMasters.Remove(cm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public PDCClearanceMaster PDCClearanceMasterView(decimal PDCClearanceMasterId)
        {
            PDCClearanceMaster pdcclearancemasterinfo = new PDCClearanceMaster();
            
            try
            {
                pdcclearancemasterinfo = new IMEEntities().PDCClearanceMasters.Where(x => x.PDCClearanceMasterId == PDCClearanceMasterId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
            return pdcclearancemasterinfo;
        }

        public DataTable PDCClearanceMasterViewAll()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (from cm in db.PDCClearanceMasters
                               select new
                               {
                                   cm.PDCClearanceMasterId,
                                   cm.voucherNo,
                                   cm.invoiceNo,
                                   cm.suffixPrefixId,
                                   cm.date,
                                   cm.ledgerId,
                                   cm.type,
                                   cm.againstId,
                                   cm.voucherTypeId,
                                   cm.narration,
                                   cm.status,
                                   cm.userId,
                                   cm.financialYearId,
                               }).ToList();

                dtbl.Columns.Add("PDCClearanceMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("type");
                dtbl.Columns.Add("againstId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("status");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("financialYearId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["PDCClearanceMasterId"] = item.PDCClearanceMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["suffixPrefixId"] = item.suffixPrefixId;
                    row["date"] = item.date;
                    row["ledgerId"] = item.ledgerId;
                    row["type"] = item.type;
                    row["againstId"] = item.againstId;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["narration"] = item.narration;
                    row["status"] = item.status;
                    row["userId"] = item.userId;
                    row["financialYearId"] = item.financialYearId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public void PDCClearanceMasterEdit(PDCClearanceMaster pcm)
        {
            IMEEntities db = new IMEEntities();
            PDCClearanceMaster cm = db.PDCClearanceMasters.Where(x => x.PDCClearanceMasterId == pcm.PDCClearanceMasterId).FirstOrDefault();
            try
            {
                cm.voucherNo = pcm.voucherNo;
                cm.invoiceNo = pcm.invoiceNo;
                cm.suffixPrefixId = pcm.suffixPrefixId;
                cm.date = pcm.date;
                cm.ledgerId = pcm.ledgerId;
                cm.type = pcm.type;
                cm.againstId = pcm.againstId;
                cm.voucherTypeId = pcm.voucherTypeId;
                cm.narration = pcm.narration;
                cm.status = pcm.status;
                cm.userId = pcm.userId;
                cm.financialYearId = pcm.financialYearId;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public decimal PDCClearanceMasterAdd(PDCClearanceMaster pdcclearancemasterinfo)
        {
            decimal decIdentity = 0;
            try
            {
                PDCClearanceMaster pcm = pdcclearancemasterinfo;
                new IMEEntities().PDCClearanceMasters.Add(pcm);
                decIdentity = pcm.PDCClearanceMasterId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }
    }
}
