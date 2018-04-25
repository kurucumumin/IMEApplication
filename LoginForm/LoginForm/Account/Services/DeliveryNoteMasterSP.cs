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
                row["invoiceNo"] = item.DeliveryNoteNo;
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// Function to insert values to DeliveryNoteMaster Table
        /// </summary>
        /// <param name="deliverynotemasterinfo"></param>
        /// <returns></returns>
        public decimal DeliveryNoteMasterAdd(DeliveryNoteMaster deliverynotemasterinfo)
        {
            decimal decDeliveryNoteMasterId = 0;
            try
            {
                object obj = new IMEEntities().DeliveryNoteMasterAdd(
                deliverynotemasterinfo.voucherNo,
                deliverynotemasterinfo.DeliveryNoteNo,
                deliverynotemasterinfo.voucherTypeId,
                deliverynotemasterinfo.suffixPrefixId,
                deliverynotemasterinfo.date,
                deliverynotemasterinfo.creditPeriod,
                deliverynotemasterinfo.ledgerId,
                deliverynotemasterinfo.salesAccount,
                deliverynotemasterinfo.orderMasterId,
                deliverynotemasterinfo.narration,
                deliverynotemasterinfo.exchangeRateId,
                deliverynotemasterinfo.taxAmount,
                deliverynotemasterinfo.additionalCost,
                deliverynotemasterinfo.billDiscount,
                deliverynotemasterinfo.grandTotal,
                deliverynotemasterinfo.totalAmount,
                deliverynotemasterinfo.userId,
                deliverynotemasterinfo.lrNo,
                deliverynotemasterinfo.transportationCompany,
                deliverynotemasterinfo.POS,
                deliverynotemasterinfo.financialYearId,
                deliverynotemasterinfo.CustomerID).FirstOrDefault();

                if (obj != null)
                {
                    decDeliveryNoteMasterId = decimal.Parse(obj.ToString());
                }
                else
                {
                    decDeliveryNoteMasterId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decDeliveryNoteMasterId;
        }

    }
}
