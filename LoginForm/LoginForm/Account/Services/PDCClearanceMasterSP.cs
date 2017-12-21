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
    }
}
