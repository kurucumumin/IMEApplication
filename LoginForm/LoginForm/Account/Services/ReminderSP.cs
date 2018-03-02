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
                row["purchaseOrderId"] = item.FicheNo;
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
                dtbl.Columns.Add("OrderNO");
                dtbl.Columns.Add("date");
                dtbl.Columns.Add("dueDate");
                dtbl.Columns.Add("totalAmount");
                dtbl.Columns.Add("QuotationNo");

                foreach (var item in IME.OverdueSalesOrderCorrespondingAccountLedger(decLedgerId.ToString()))
                {
                    var row = dtbl.NewRow();
                    row["OrderNO"] = item.OrderNO;
                    row["date"] = item.date;
                    row["dueDate"] = item.dueDate;
                    row["totalAmount"] = item.totalAmount;
                    row["QuotationNo"] = item.QuotationNo;
                    dtbl.Rows.Add(row);
                }
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

        public bool ReminderAdd(Reminder reminderinfo)
        {
            IMEEntities IME = new IMEEntities();
            Reminder r = reminderinfo;
            try
            {
                object adaptor = IME.ReminderAdd(r.fromDate,r.toDate,r.remindAbout);

                if (adaptor != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool RemainderEdit(Reminder r)
        {
            IMEEntities IME = new IMEEntities();
            
            try
            {
                object adaptor = IME.ReminderEdit(
                    r.reminderId,
                    r.fromDate,
                    r.toDate,
                    r.remindAbout
                    ).ToString();

                if (adaptor!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool RemainderDelete(decimal Remainder)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                object adaptor = IME.ReminderDelete(Remainder);

                if (adaptor != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        public DataTable ReminderSearch(string strfromDate, string strToDate)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(int));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;


            dtbl.Columns.Add("reminderId");
            dtbl.Columns.Add("fromDate");
            dtbl.Columns.Add("toDate");
            dtbl.Columns.Add("remindAbout");

            foreach (var item in IME.ReminderSearch(Convert.ToDateTime(strfromDate), Convert.ToDateTime(strToDate)))
            {
                var row = dtbl.NewRow();
                row["reminderId"] = item.reminderId;
                row["fromDate"] = item.fromDate;
                row["toDate"] = item.toDate;
                row["remindAbout"] = item.remindAbout;
                dtbl.Rows.Add(row);
            }
            return dtbl;
        }

        public DataTable RemainderViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                dtbl.Columns.Add("reminderId");
                dtbl.Columns.Add("fromDate");
                dtbl.Columns.Add("toDate");
                dtbl.Columns.Add("remindAbout");

                foreach (var item in IME.ReminderViewAll())
                {
                    var row = dtbl.NewRow();
                    row["reminderId"] = item.reminderId;
                    row["fromDate"] = item.fromDate;
                    row["toDate"] = item.toDate;
                    row["remindAbout"] = item.remindAbout;
                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        
        public Reminder RemainderView(decimal remainder)
        {
            IMEEntities IME = new IMEEntities();
            Reminder remainderinfo = new Reminder();
            
            try
            {
                var a = IME.ReminderView(remainder).FirstOrDefault();

                remainderinfo.fromDate = a.fromDate;
                remainderinfo.toDate = a.toDate;
                remainderinfo.remindAbout = a.remindAbout;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return remainderinfo;
        }
    }
}
