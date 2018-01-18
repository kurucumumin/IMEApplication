using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//TO DO SalesMaster SalesOrderMaster tabloları

namespace LoginForm.Account.Services
{
    class ReminderSP
    {
        public DataTable OverDuePurchaseOrdersCorrespondingAccountLedger(decimal decLedgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            
            dtbl.Columns.Add("PurchaseOrderMasterId");
            dtbl.Columns.Add("InvoicedMasterId");
            dtbl.Columns.Add("MR_OrderMasterId");
            dtbl.Columns.Add("ledgerId");

            foreach (var item in IME.OverduePurchaseOrdersCorrespondingAccountLedger(decLedgerId))
            {
                var row = dtbl.NewRow();
                row["PurchaseOrderMasterId"] = item.FicheNo;
                row["InvoicedMasterId"] = item.InvoicedMasterId;
                row["MR_OrderMasterId"] = item.MR_OrderMasterId;
                row["ledgerId"] = item.ledgerId;
                dtbl.Rows.Add(row);
            }
            return dtbl;


        }

        public DataTable OverdueSalesOrderCorrespondingAccountLedger(decimal decLedgerId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;

            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable ShortExpiryReminderGridFill(decimal groupId, decimal productId, decimal brandId, decimal sizeId, decimal modelNoId, decimal taxId, decimal godownId, decimal rackId)
        {
            //IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            //try
            //{
            //    var adapter = (from a in IME.)
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            return dtbl;
        }

    }
}
