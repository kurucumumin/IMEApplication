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
    class MaterialReceiptMasterSP
    {
        public DataTable MaterialReceiptMasterViewByReceiptMasterId(decimal decMaterialReceiptMasterId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.MaterialReceiptMasterViewByReceiptMasterId(decMaterialReceiptMasterId);

                dtbl.Columns.Add("materialReceiptMasterId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("orderMasterId");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("exchangeRateId");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("lrNo");
                dtbl.Columns.Add("transportationCompany");
                dtbl.Columns.Add("currencyId");
                dtbl.Columns.Add("Refer");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["materialReceiptMasterId"] = item.materialReceiptMasterId;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["date"] = item.date;
                    row["ledgerId"] = item.ledgerId;
                    row["orderMasterId"] = item.orderMasterId;
                    row["narration"] = item.narration;
                    row["exchangeRateId"] = item.exchangeRateId;
                    row["totalAmount"] = item.totalAmount;
                    row["userId"] = item.userId;
                    row["suffixPrefixId"] = item.suffixPrefixId;
                    row["lrNo"] = item.lrNo;
                    row["transportationCompany"] = item.transportationCompany;
                    row["currencyId"] = item.currencyId;
                    row["Refer"] = item.Refer;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public MaterialReceiptMaster MaterialReceiptMasterView(decimal materialReceiptMasterId)
        {
            IMEEntities db = new IMEEntities();
            MaterialReceiptMaster mr = new MaterialReceiptMaster();
            try
            {
                var m = db.MaterialReceiptMasterView(materialReceiptMasterId).FirstOrDefault();

                mr.materialReceiptMasterId = m.materialReceiptMasterId;
                mr.voucherNo = m.voucherNo;
                mr.invoiceNo = m.invoiceNo;
                mr.suffixPrefixId = m.suffixPrefixId;
                mr.voucherTypeId = m.voucherTypeId;
                mr.date = m.date;
                mr.ledgerId = m.ledgerId;
                mr.orderMasterId = m.orderMasterId;
                mr.narration = m.narration;
                mr.exchangeRateId = m.exchangeRateId;
                mr.totalAmount = m.totalAmount;
                mr.userId = m.userId;
                mr.lrNo = m.lrNo;
                mr.transportationCompany = m.transportationCompany;
                mr.financialYearId = m.financialYearId;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return mr;
        }
    }
}
