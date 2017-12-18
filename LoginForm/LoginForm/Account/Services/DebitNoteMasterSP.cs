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
                                   dn.invoiceNo,
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
                    row["invoiceNo"] = item.invoiceNo;
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
            try
            {
                var adaptor = (from dn in db.DeliveryNoteMasters.Where(x=>x.voucherNo.StartsWith(strVoucherNo) && (x.date > DateTime.Parse(strFromDate) && x.date < DateTime.Parse(strToDate))).OrderByDescending(y=>y.deliveryNoteMasterId)
                               select new
                               {
                                   dn.deliveryNoteMasterId,
                                   dn.voucherNo,
                                   dn.invoiceNo,
                                   dn.VoucherType.voucherTypeName,
                                   dn.suffixPrefixId,
                                   dn.date,
                                   dn.totalAmount,
                                   dn.narration,
                                   dn.userId,
                                   dn.voucherTypeId,
                                   dn.financialYearId
                               }).ToList();

                dtbl.Columns.Add("deliveryNoteMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("voucherTypeName");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("financialYearId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["deliveryNoteMasterId"] = item.deliveryNoteMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["suffixPrefixId"] = item.suffixPrefixId;
                    row["date"] = item.date;
                    row["totalAmount"] = item.totalAmount;
                    row["narration"] = item.narration;
                    row["userId"] = item.userId;
                    row["voucherTypeId"] = item.voucherTypeId;
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
    }
}
