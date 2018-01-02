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
        public DataTable pdcclearancedetailsFill(string strVoucherType, decimal decmasterId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtblpdcPayableId = new DataTable();
            try
            {
                var a = db.PDCClearanceFillDetails(strVoucherType, decmasterId);

                dtblpdcPayableId.Columns.Add("voucherTypeName");
                dtblpdcPayableId.Columns.Add("voucherNo");
                dtblpdcPayableId.Columns.Add("date");
                dtblpdcPayableId.Columns.Add("ledgerId");
                dtblpdcPayableId.Columns.Add("amount");
                dtblpdcPayableId.Columns.Add("Narration");
                dtblpdcPayableId.Columns.Add("ledgerName");
                dtblpdcPayableId.Columns.Add("checkDate");
                dtblpdcPayableId.Columns.Add("chequeNo");
                dtblpdcPayableId.Columns.Add("BankId");
                dtblpdcPayableId.Columns.Add("Bank");

                foreach (var item in a)
                {
                    var row = dtblpdcPayableId.NewRow();

                    row["voucherTypeName"] = item.voucherTypeName;
                    row["voucherNo"] = item.voucherNo;
                    row["date"] = item.date;
                    row["ledgerId"] = item.ledgerId;
                    row["amount"] = item.amount;
                    row["Narration"] = item.Narration;
                    row["ledgerName"] = item.ledgerName;
                    row["checkDate"] = item.checkDate;
                    row["chequeNo"] = item.chequeNo;
                    row["BankId"] = item.BankId;
                    row["Bank"] = item.Bank;




                    dtblpdcPayableId.Rows.Add(row);
                }
                //string typePayable = db.VoucherTypes.Where(x => x.typeOfVoucher == "PDC Payable" && x.voucherTypeName == strVoucherType).FirstOrDefault().voucherTypeName;
                //string typeReceivable = db.VoucherTypes.Where(x => x.typeOfVoucher == "PDC Receivable" && x.voucherTypeName == strVoucherType).FirstOrDefault().voucherTypeName;

                //dynamic generalList = new object();

                //if (typePayable != null && typePayable != String.Empty)
                //{
                //    List<decimal> List1 = db.PDCPayableMasters.Select(x=>x.pdcPayableMasterId).ToList();
                //    List<decimal> List2 = db.PDCClearanceMasters.Where(y => y.againstId != decmasterId).Select(x => Convert.ToDecimal(x.againstId)).ToList();

                //    var list = List1.Except(List2);

                //    var adaptor = (from pm in db.PDCPayableMasters
                //                   from al in db.AccountLedgers.Where(x => x.ledgerId == pm.ledgerId)
                //                   from vt in db.VoucherTypes.Where(x => x.voucherTypeId == pm.voucherTypeId).DefaultIfEmpty()
                //                   from cm in db.PDCClearanceMasters.Where(x => x.againstId == pm.pdcPayableMasterId)
                //                   where
                //                     vt.voucherTypeName == strVoucherType &&
                //                     pm.pdcPayableMasterId == decmasterId &&
                //                     list.Contains(pm.pdcPayableMasterId)
                //                   select new
                //                   {
                //                       vt.voucherTypeName,
                //                       pm.voucherNo,
                //                       date = (pm.date).Value.ToShortDateString(),
                //                       pm.ledgerId,
                //                       pm.amount,
                //                       Narration = pm.narration,
                //                       al.ledgerName,
                //                       chequeDate = (pm.chequeDate).Value.ToShortDateString(),
                //                       pm.chequeNo,
                //                       BankId = pm.bankId,
                //                       Bank = db.AccountLedgers.Where(x=>x.ledgerId == pm.bankId).Select(x=>x.ledgerName).FirstOrDefault()
                //                   }).ToList().Distinct();
                //    generalList = adaptor;
                //}
                //else if (typeReceivable != null && typeReceivable != String.Empty)
                //{
                //    List<decimal> List1 = db.PDCReceivableMasters.Select(x => x.pdcReceivableMasterId).ToList();
                //    List<decimal> List2 = db.PDCClearanceMasters.Where(y => y.againstId != decmasterId).Select(x => Convert.ToDecimal(x.againstId)).ToList();

                //    var list = List1.Except(List2);

                //    var left = (from pr in db.PDCReceivableMasters
                //                join al in db.AccountLedgers on pr.ledgerId equals al.ledgerId into temp
                //                from pral in temp.DefaultIfEmpty()
                //                select new { pral }
                //                ).ToList().DefaultIfEmpty();
                //    var right = (from al in db.AccountLedgers
                //                 join pr in db.PDCReceivableMasters on al.ledgerId equals pr.ledgerId into temp
                //                 from pral in temp.DefaultIfEmpty()
                //                 select new { pral }
                //                ).ToList().DefaultIfEmpty();

                //    var fullJoin = left.Union(right);



                //    var adaptor = (from pr in db.PDCReceivableMasters
                //                   join al in db.AccountLedgers on pr.ledgerId equals al.ledgerId into temp
                //                   from pral in temp.DefaultIfEmpty()

                //                   from vt in db.VoucherTypes.Where(x => x.voucherTypeId == pm.voucherTypeId)
                //                   from cm in db.PDCClearanceMasters.Where(x => x.againstId == pm.pdcPayableMasterId)
                //                   where
                //                     vt.voucherTypeName == strVoucherType &&
                //                     pm.pdcPayableMasterId == decmasterId &&
                //                     list.Contains(pm.pdcPayableMasterId)
                //                   select new
                //                   {
                //                       vt.voucherTypeName,
                //                       pm.voucherNo,
                //                       date = (pm.date).Value.ToShortDateString(),
                //                       pm.ledgerId,
                //                       pm.amount,
                //                       Narration = pm.narration,
                //                       al.ledgerName,
                //                       chequeDate = (pm.chequeDate).Value.ToShortDateString(),
                //                       pm.chequeNo,
                //                       BankId = pm.bankId,
                //                       Bank = db.AccountLedgers.Where(x => x.ledgerId == pm.bankId).Select(x => x.ledgerName).FirstOrDefault()
                //                   }).ToList().Distinct();


                //    //var adaptor = (from pr in db.PDCReceivableMasters
                //    //               from al in db.AccountLedgers.Where(x => x.ledgerId == pr.ledgerId)
                //    //               from vt in db.VoucherTypes.Where(x => x.voucherTypeId == pm.voucherTypeId)
                //    //               from cm in db.PDCClearanceMasters.Where(x => x.againstId == pm.pdcPayableMasterId)
                //    //               where
                //    //                 vt.voucherTypeName == strVoucherType &&
                //    //                 pm.pdcPayableMasterId == decmasterId &&
                //    //                 list.Contains(pm.pdcPayableMasterId)
                //    //               select new
                //    //               {
                //    //                   vt.voucherTypeName,
                //    //                   pm.voucherNo,
                //    //                   date = (pm.date).Value.ToShortDateString(),
                //    //                   pm.ledgerId,
                //    //                   pm.amount,
                //    //                   Narration = pm.narration,
                //    //                   al.ledgerName,
                //    //                   chequeDate = (pm.chequeDate).Value.ToShortDateString(),
                //    //                   pm.chequeNo,
                //    //                   BankId = pm.bankId,
                //    //                   Bank = db.AccountLedgers.Where(x => x.ledgerId == pm.bankId).Select(x => x.ledgerName).FirstOrDefault()
                //    //               }).ToList().Distinct();
                //    generalList = adaptor;
                //}



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblpdcPayableId;
        }
        public void PDCClearanceDelete(decimal PdcClearanceId, decimal decVoucherTypeId, string strVoucherNo)
        {
            IMEEntities db = new IMEEntities();

            try
            {
                List<PartyBalance> pList = db.PartyBalances.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo && x.referenceType == "New").ToList();
                db.PartyBalances.RemoveRange(pList);
                db.SaveChanges();

                List<LedgerPosting> lpList = db.LedgerPostings.Where(x => x.voucherTypeId == decVoucherTypeId && x.voucherNo == strVoucherNo).ToList();
                db.LedgerPostings.RemoveRange(lpList);
                db.SaveChanges();

                PDCClearanceMaster cm = db.PDCClearanceMasters.Where(x=>x.PDCClearanceMasterId == PdcClearanceId).FirstOrDefault();
                db.PDCClearanceMasters.Remove(cm);
                db.SaveChanges();
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
            IMEEntities db = new IMEEntities();
            decimal decIdentity = 0;
            try
            {
                PDCClearanceMaster pcm = pdcclearancemasterinfo;
                db.PDCClearanceMasters.Add(pcm);
                db.SaveChanges();
                decIdentity = pcm.PDCClearanceMasterId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public bool PDCclearanceCheckExistence(string voucherNo, decimal voucherTypeId, decimal PDCClearanceMasterId)
        {
            IMEEntities db = new IMEEntities();
            bool isSave = false;
            int count = 0;
            try
            {

                var obj = db.PDCClearanceMasters.Where(x => x.voucherNo == voucherNo && x.voucherTypeId == voucherTypeId && x.PDCClearanceMasterId == PDCClearanceMasterId).ToList();
                if (obj != null)
                {
                    count = obj.Count();
                    if (count > 0)
                    {
                        isSave = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isSave;
        }
        public string PDCClearanceMaxUnderVoucherType(decimal decVoucherTypeId)
        {
            string max = "0";
            try
            {
                max = new IMEEntities().PDCClearanceMasters.Where(p => p.voucherTypeId == decVoucherTypeId).Select(y => Convert.ToDecimal(y.voucherNo)).Max().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public decimal PDCClearanceMaxUnderVoucherTypePlusOne(decimal decVoucherTypeId)
        {
            decimal max = 0;
            try
            {
                max = new IMEEntities().PDCClearanceMasters.Where(p => p.voucherTypeId == decVoucherTypeId).Select(y => Convert.ToDecimal(y.voucherNo)).Max();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public DataTable PDCClearanceRegisterSearch(DateTime dtFromdate, DateTime dtTodate, string strLedgerName, string voucherTypeName, string strchequeNo, decimal decBankId, string strstatus)
        {
            IMEEntities db = new IMEEntities();

            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            
            try
            {
                if (voucherTypeName == "All")
                {
                    var adaptor = (from pdcm in db.PDCClearanceMasters
                                   from pdpm in db.PDCPayableMasters.Where(x => x.pdcPayableMasterId == pdcm.againstId).DefaultIfEmpty()
                                   from pdrm in db.PDCReceivableMasters.Where(x => x.pdcReceivableMasterId == pdcm.againstId).DefaultIfEmpty()
                                   from al in db.AccountLedgers.Where(x => x.ledgerId == pdcm.ledgerId)
                                   from vt in db.VoucherTypes.Where(x => x.voucherTypeName == pdcm.type)
                                   where
                                         (pdcm.date > dtFromdate && pdcm.date < dtTodate) &&
                                         (al.ledgerName == ((strLedgerName == "All") ? al.ledgerName : strLedgerName)) &&
                                         (vt.voucherTypeName == ((voucherTypeName == "All") ? vt.voucherTypeName : voucherTypeName)) &&
                                         ((strchequeNo == "") ? (pdpm.chequeNo == pdpm.chequeNo) : (pdpm.chequeNo.StartsWith(strchequeNo))) &&
                                         (pdpm.bankId == ((decBankId == 0) ? pdpm.bankId : decBankId)) &&
                                         (pdcm.status == ((strstatus == "All") ? pdcm.status : strstatus))
                                   select new
                                   {
                                       pdcm.PDCClearanceMasterId,
                                       voucherNo = pdcm.invoiceNo,
                                       vt.voucherTypeName,
                                       pdcm.suffixPrefixId,
                                       pdcm.againstId,
                                       date = pdcm.date.Value.ToShortDateString(),
                                       pdcm.narration,
                                       pdcm.userId,
                                       pdcm.voucherTypeId,
                                       pdcm.financialYearId,
                                       pdcm.status,
                                       al.ledgerName,
                                       pdcm.type,
                                       amount = (vt.typeOfVoucher == "PDC Payable") ? pdpm.amount : pdrm.amount
                                   }).ToList();

                    dtbl.Columns.Add("PDCClearanceMasterId");
                    dtbl.Columns.Add("voucherNo");
                    dtbl.Columns.Add("voucherTypeName");
                    dtbl.Columns.Add("suffixPrefixId");
                    dtbl.Columns.Add("againstId");
                    dtbl.Columns.Add("date");
                    dtbl.Columns.Add("narration");
                    dtbl.Columns.Add("userId");
                    dtbl.Columns.Add("voucherTypeId");
                    dtbl.Columns.Add("financialYearId");
                    dtbl.Columns.Add("status");
                    dtbl.Columns.Add("ledgerName");
                    dtbl.Columns.Add("type");
                    dtbl.Columns.Add("amount");


                    foreach (var item in adaptor)
                    {
                        var row = dtbl.NewRow();

                        row["PDCClearanceMasterId"] = item.PDCClearanceMasterId;
                        row["voucherNo"] = item.voucherNo;
                        row["voucherTypeName"] = item.voucherTypeName;
                        row["suffixPrefixId"] = item.suffixPrefixId;
                        row["againstId"] = item.againstId;
                        row["date"] = item.date;
                        row["narration"] = item.narration;
                        row["userId"] = item.userId;
                        row["voucherTypeId"] = item.voucherTypeId;
                        row["financialYearId"] = item.financialYearId;
                        row["status"] = item.status;
                        row["ledgerName"] = item.ledgerName;
                        row["type"] = item.type;
                        row["amount"] = item.amount;
                        
                        dtbl.Rows.Add(row);
                    }
                    
                } else if (db.VoucherTypes.Where(x => x.typeOfVoucher == "PDC Payable" && x.voucherTypeName == voucherTypeName).Select(x=>x.voucherTypeName).FirstOrDefault() != null)
                {
                    var adaptor = (from pdc in db.PDCPayableMasters
                                   from pdcl in db.PDCClearanceMasters.Where(x => x.againstId == pdc.pdcPayableMasterId)
                                   from al in db.AccountLedgers.Where(x => x.ledgerId == pdc.ledgerId)
                                   from vt in db.VoucherTypes.Where(x => x.voucherTypeName == pdcl.type)

                                   where (pdcl.date > dtFromdate && pdcl.date < dtTodate) &&
                                         (al.ledgerName == ((strLedgerName == "All") ? al.ledgerName : strLedgerName)) &&
                                         (vt.voucherTypeName == ((voucherTypeName == "All") ? vt.voucherTypeName : voucherTypeName)) &&
                                         ((strchequeNo == "") ? (pdc.chequeNo == pdc.chequeNo) : (pdc.chequeNo.StartsWith(strchequeNo))) &&
                                         (pdc.bankId == ((decBankId == 0) ? pdc.bankId : decBankId)) &&
                                         (pdcl.status == ((strstatus == "All") ? pdcl.status : strstatus))
                                   select new
                                   {
                                       pdc.pdcPayableMasterId,
                                       pdc.amount,
                                       pdcl.PDCClearanceMasterId,
                                       voucherNo = pdcl.invoiceNo,
                                       pdcl.againstId,
                                       pdcl.suffixPrefixId,
                                       date = pdcl.date.ToString(),
                                       pdcl.narration,
                                       pdcl.userId,
                                       pdcl.voucherTypeId,
                                       pdcl.financialYearId,
                                       pdcl.status,
                                       al.ledgerName,
                                       pdcl.type
                                   }).ToList();

                    dtbl.Columns.Add("pdcPayableMasterId");
                    dtbl.Columns.Add("amount");
                    dtbl.Columns.Add("PDCClearanceMasterId");
                    dtbl.Columns.Add("voucherNo");
                    dtbl.Columns.Add("againstId");
                    dtbl.Columns.Add("suffixPrefixId");
                    dtbl.Columns.Add("date");
                    dtbl.Columns.Add("narration");
                    dtbl.Columns.Add("userId");
                    dtbl.Columns.Add("voucherTypeId");
                    dtbl.Columns.Add("financialYearId");
                    dtbl.Columns.Add("status");
                    dtbl.Columns.Add("ledgerName");
                    dtbl.Columns.Add("type");


                    foreach (var item in adaptor)
                    {
                        var row = dtbl.NewRow();

                        row["pdcPayableMasterId"] = item.pdcPayableMasterId;
                        row["amount"] = item.amount;
                        row["PDCClearanceMasterId"] = item.PDCClearanceMasterId;
                        row["voucherNo"] = item.voucherNo;
                        row["againstId"] = item.againstId;
                        row["suffixPrefixId"] = item.suffixPrefixId;
                        row["date"] = item.date;
                        row["narration"] = item.narration;
                        row["userId"] = item.userId;
                        row["voucherTypeId"] = item.voucherTypeId;
                        row["financialYearId"] = item.financialYearId;
                        row["status"] = item.status;
                        row["ledgerName"] = item.ledgerName;
                        row["type"] = item.type;

                        dtbl.Rows.Add(row);
                    }


                } else if (db.VoucherTypes.Where(x=>x.typeOfVoucher== "PDC Receivable" && x.voucherTypeName == voucherTypeName).Select(x=>x.voucherTypeName).FirstOrDefault() != null)
                {
                    var adaptor = (from pdcr in db.PDCReceivableMasters
                                   from pdcl in db.PDCClearanceMasters.Where(x => x.againstId == pdcr.pdcReceivableMasterId)
                                   from al in db.AccountLedgers.Where(x => x.ledgerId == pdcr.pdcReceivableMasterId)
                                   from vt in db.VoucherTypes.Where(x => x.voucherTypeName == pdcl.type)

                                   where (pdcl.date > dtFromdate && pdcl.date < dtTodate) &&
                                         (al.ledgerName == ((strLedgerName == "All ") ? al.ledgerName : strLedgerName)) &&
                                         (vt.voucherTypeName == ((voucherTypeName == "All") ? vt.voucherTypeName : voucherTypeName)) &&
                                         ((strchequeNo == "") ? (pdcr.chequeNo == pdcr.chequeNo) : (pdcr.chequeNo.StartsWith(strchequeNo))) &&
                                         (pdcr.bankId == ((decBankId == 0) ? pdcr.bankId : decBankId)) &&
                                         (pdcl.status == ((strstatus == "All") ? pdcl.status : strstatus))

                                   select new
                                   {
                                       pdcr.pdcReceivableMasterId,
                                       pdcr.amount,
                                       pdcl.PDCClearanceMasterId,
                                       pdcl.againstId,
                                       voucherNo = pdcl.invoiceNo,
                                       pdcl.suffixPrefixId,
                                       date = pdcl.date.ToString(),
                                       pdcl.narration,
                                       pdcl.userId,
                                       pdcl.voucherTypeId,
                                       pdcl.financialYearId,
                                       pdcl.status,
                                       al.ledgerName,
                                       pdcl.type
                                   }).ToList();

                    dtbl.Columns.Add("pdcReceivableMasterId");
                    dtbl.Columns.Add("amount");
                    dtbl.Columns.Add("PDCClearanceMasterId");
                    dtbl.Columns.Add("againstId");
                    dtbl.Columns.Add("voucherNo");
                    dtbl.Columns.Add("suffixPrefixId");
                    dtbl.Columns.Add("date");
                    dtbl.Columns.Add("narration");
                    dtbl.Columns.Add("userId");
                    dtbl.Columns.Add("voucherTypeId");
                    dtbl.Columns.Add("financialYearId");
                    dtbl.Columns.Add("status");
                    dtbl.Columns.Add("ledgerName");
                    dtbl.Columns.Add("type");


                    foreach (var item in adaptor)
                    {
                        var row = dtbl.NewRow();

                        row["pdcReceivableMasterId"] = item.pdcReceivableMasterId;
                        row["amount"] = item.amount;
                        row["PDCClearanceMasterId"] = item.PDCClearanceMasterId;
                        row["againstId"] = item.againstId;
                        row["voucherNo"] = item.voucherNo;
                        row["suffixPrefixId"] = item.suffixPrefixId;
                        row["date"] = item.date;
                        row["narration"] = item.narration;
                        row["userId"] = item.userId;
                        row["voucherTypeId"] = item.voucherTypeId;
                        row["financialYearId"] = item.financialYearId;
                        row["status"] = item.status;
                        row["ledgerName"] = item.ledgerName;
                        row["type"] = item.type;

                        dtbl.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public string TypeOfVoucherReturnUnderVoucherName(string strVoucherType)
        {
            string VoucherType = string.Empty;
            try
            {
                VoucherType = new IMEEntities().VoucherTypes.Where(x => x.voucherTypeName == strVoucherType).Select(x => x.typeOfVoucher).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return VoucherType;
        }
        public decimal PDCClearanceAgainstIdUnderClearanceId(decimal decclearanceId)
        {
            decimal decAgainstId = 0;
            try
            {
                var id = new IMEEntities().PDCClearanceMasters.Where(x => x.PDCClearanceMasterId == decclearanceId).Select(x => x.againstId).FirstOrDefault();
                decAgainstId = Convert.ToDecimal(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decAgainstId;
        }

        public DataTable PDCClearanceReportSearch(DateTime dtFromdate, DateTime dtTodate, string strLedgerName, string voucherTypeName, string voucherNo)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from c in IME.PDCClearanceMasters
                               from pm in IME.PDCPayableMasters.Where(x => x.pdcPayableMasterId == c.againstId).DefaultIfEmpty()
                               from cd in IME.PDCReceivableMasters.Where(x => x.pdcReceivableMasterId == c.againstId).DefaultIfEmpty()
                               from v in IME.VoucherTypes.Where(x => x.voucherTypeName == c.type)
                               from w in IME.AccountLedgers.Where(x => x.ledgerId == c.ledgerId)
                               where
                                      (c.date > Convert.ToDateTime(dtFromdate) && c.date < Convert.ToDateTime(dtTodate)) &&
                                      ((voucherNo == "") ? c.invoiceNo == c.invoiceNo : c.invoiceNo.StartsWith(voucherNo)) &&
                                      (w.ledgerName == ((strLedgerName == "All") ? w.ledgerName : strLedgerName)) &&
                                      (c.type == ((voucherTypeName == "All") ? c.type : voucherTypeName))
                               select new
                               {
                                   c.PDCClearanceMasterId,
                                   voucherNo= c.invoiceNo,
                                   c.againstId,
                                   date = c.date.ToString(),
                                   c.narration,
                                   c.userId,
                                   c.voucherTypeId,
                                   c.type,
                                   amount = (v.typeOfVoucher== ((v.typeOfVoucher== "PDC Payable") ? Convert.ToString(pm.amount) : Convert.ToString(pm.amount)) || (v.typeOfVoucher == "PDC Receivable") ? Convert.ToString(cd.amount) : Convert.ToString(cd.amount)),
                                   c.status,
                                   w.ledgerName
                               }).ToList();



                dtbl.Columns.Add("PDCClearanceMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("againstId");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("type");
                dtbl.Columns.Add("amount");
                dtbl.Columns.Add("status");
                dtbl.Columns.Add("ledgerName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["PDCClearanceMasterId"] = item.PDCClearanceMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["againstId"] = item.againstId;
                    row["date"] = item.date;
                    row["narration"] = item.narration;
                    row["userId"] = item.userId;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["type"] = item.type;
                    row["amount"] = item.amount;
                    row["status"] = item.status;
                    row["ledgerName"] = item.ledgerName;

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
