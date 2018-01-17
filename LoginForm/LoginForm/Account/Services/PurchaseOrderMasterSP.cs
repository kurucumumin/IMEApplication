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
    class PurchaseOrderMasterSP
    {
        public DataTable PurchaseOrderMasterViewByOrderMasterId(string decOrderMasterId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.PurchaseOrderMasterViewByOrderMasterId(decOrderMasterId).ToList();

                dtbl.Columns.Add("FicheNo");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("userId");
                dtbl.Columns.Add("suffixPrefixId");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("dueDate");
                dtbl.Columns.Add("cancelled");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("exchangeRateId");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("Refer");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["FicheNo"] = item.FicheNo;
                    row["voucherNo"] = item.voucherNo;
                    row["invoiceNo"] = item.invoiceNo;
                    row["userId"] = item.userId;
                    row["suffixPrefixId"] = item.suffixPrefixId;
                    row["date"] = item.date;
                    row["dueDate"] = item.dueDate;
                    row["cancelled"] = item.cancelled;
                    row["ledgerId"] = item.ledgerId;
                    row["narration"] = item.narration;
                    row["exchangeRateId"] = item.exchangeRateId;
                    row["totalAmount"] = item.totalAmount;
                    row["Refer"] = item.Refer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataSet.PurchaseOrder PurchaseOrderMasterView(string purchaseOrderMasterId)
        {
            DataSet.PurchaseOrder p = new DataSet.PurchaseOrder();
            try
            {
                var po = new IMEEntities().PurchaseOrderMasterView(Convert.ToDecimal(purchaseOrderMasterId)).FirstOrDefault();

                p.voucherNo = po.voucherNo;
                p.invoiceNo = po.invoiceNo;
                p.suffixPrefixId = po.suffixPrefixId;
                p.voucherTypeId = po.voucherTypeId;
                p.date = po.date;
                p.ledgerId = po.ledgerId;
                p.dueDate = po.dueDate;
                p.narration = po.narration;
                p.totalAmount = po.totalAmount;
                p.exchangeRateID = po.exchangeRateId;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return p;
        }
    }
}
