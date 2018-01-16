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
    class DeliveryNoteMasterSP
    {

        public DataTable GetDeleveryNoteNoIncludePendingCorrespondingtoLedgerForSI(decimal decLedgerId, decimal decSalesMasterId, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dt = new DataTable();
            var adaptor = IME.GetDeleveryNoteNoIncludePendingCorrespondingtoLedgerForSI(decLedgerId, decSalesMasterId, decVoucherTypeId);

            dt.Columns.Add("deliveryNoteMasterId");
            dt.Columns.Add("invoiceNo");


            foreach (var item in adaptor)
            {
                var row = dt.NewRow();
                row["deliveryNoteMasterId"] = item.deliveryNoteMasterId;
                row["invoiceNo"] = item.invoiceNo;
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}
