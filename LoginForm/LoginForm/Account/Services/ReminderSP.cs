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
            try
            {
                //DateTime currentDate = DateTime.Now;

                //var adaptor = (from p in IME.PurchaseOrders
                //               join m in IME.ma
                //               select new
                //               {
                //                   v.declaration,
                //                   v.heading1,
                //                   v.heading2,
                //                   v.heading3,
                //                   v.heading4,
                //                   v.masterId
                //               }).ToList();

                //dtbl.Columns.Add("declaration");
                //dtbl.Columns.Add("heading1");
                //dtbl.Columns.Add("heading2");
                //dtbl.Columns.Add("heading3");
                //dtbl.Columns.Add("heading4");
                //dtbl.Columns.Add("masterId");

                //foreach (var item in adaptor)
                //{
                //    var row = dtbl.NewRow();

                //    row["declaration"] = item.declaration;
                //    row["heading1"] = item.heading1;
                //    row["heading2"] = item.heading2;
                //    row["heading3"] = item.heading3;
                //    row["heading4"] = item.heading4;
                //    row["masterId"] = item.masterId;

                //    dtbl.Rows.Add(row);
               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
