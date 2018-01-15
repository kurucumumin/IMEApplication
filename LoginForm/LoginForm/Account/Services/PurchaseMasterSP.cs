using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class PurchaseMasterSP
    {
        public DataTable PurchaseInvoicePurchaseAccountFill()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.PurchaseInvoicePurchaseAccountComboFill();

                dtbl.Columns.Add("ledgerName");
                dtbl.Columns.Add("ledgerId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerName"] = item.ledgerName;
                    row["ledgerId"] = item.ledgerId;


                    dtbl.Rows.Add(row);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable GetInvoiceNoCorrespondingtoLedger(decimal decLedgerId, decimal decPurchaseMasterId, decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.GetPurchaseReturnInvoiceNoCorrespondingtoLedger(decLedgerId, decPurchaseMasterId, decVoucherTypeId);

                dtbl.Columns.Add("invoiceNo");
                dtbl.Columns.Add("purchaseMasterId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["invoiceNo"] = item.invoiceNo;
                    row["purchaseMasterId"] = item.purchaseMasterId;


                    dtbl.Rows.Add(row);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("pmsp" + ex.ToString());
            }
            return dtbl;
        }

        public PurchaseMaster PurchaseMasterView(Decimal purchaseMasterId)
        {
            IMEEntities IME = new IMEEntities();
            PurchaseMaster purchasemasterinfo = new PurchaseMaster();
            try
            {
                purchasemasterinfo = IME.PurchaseMasters.Where(x => x.purchaseMasterId == purchaseMasterId).FirstOrDefault();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return purchasemasterinfo;
        }

        public DataTable GetInvoiceNoCorrespondingtoLedgerInRegister()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.GetInvoiceNoCorrespondingtoLedgerInRegister();

                dtbl.Columns.Add("purchaseMasterId");
                dtbl.Columns.Add("invoiceNo");
                
                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["purchaseMasterId"] = item.purchaseMasterId;
                    row["invoiceNo"] = item.invoiceNo;
                    

                    dtbl.Rows.Add(row);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("pmsp" + ex.ToString());
            }
            return dtbl;
        }
    }
}
