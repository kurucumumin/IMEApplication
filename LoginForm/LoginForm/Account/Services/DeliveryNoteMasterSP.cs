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
            DataTable dtbl = new DataTable();

            IMEEntities IME = new IMEEntities();
            var result = IME.GetDeleveryNoteNoIncludePendingCorrespondingtoLedgerForSI(decLedgerId, decSalesMasterId, decVoucherTypeId);
            dtbl.Columns.Add("deliveryNoteMasterId");
            dtbl.Columns.Add("invoiceNo");
            foreach (var item in result)
            {
                var row = dtbl.NewRow();
                row["deliveryNoteMasterId"] = item.deliveryNoteMasterId;
                row["invoiceNo"] = item.invoiceNo;
                dtbl.Rows.Add(row);
            }

            return dtbl;
        }
    }
}
