﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LoginForm.DataSet;
using System.Linq;
using System.Drawing;
using LoginForm.PurchaseOrder;
using LoginForm.QuotationModule;
using LoginForm.Services;
using System.Data;


namespace LoginForm.nsSaleOrder
{
    public partial class FormSalesOrderMain : Form
    {
        //List<SalesOrder> list = new List<SalesOrder>
        ContextMenu PurchaseOrderMenu = new ContextMenu();

        public FormSalesOrderMain()
        {
            InitializeComponent();

            if (Utils.getCurrentUser().AuthorizationValues.Where(x=>x.AuthorizationID == 1022).FirstOrDefault() == null)
            {
                btnDelete.Visible = false;
            }
        }

        private void FormSalesOrderMain_Load(object sender, EventArgs e)
        {
            datetimeEnd.MaxDate = DateTime.Today.Date;
            datetimeEnd.Value = DateTime.Today.Date;
            datetimeStart.Value = DateTime.Today.AddDays(-7);
            BringSalesList(datetimeEnd.Value, datetimeStart.Value);
            PurchaseOrderMenu.MenuItems.Add(new MenuItem("Add to Purchase Order", PurchaseOrderMenu_Click));
        }

        private void BringSalesList()
        {
            BringSalesList(DateTime.Today, DateTime.Today.AddDays(-7));
        }

        private void BringSalesList(DateTime startDate, DateTime endDate)
        {
            IMEEntities IME = new IMEEntities();

            var list = from so in IME.SaleOrders
                       from cw in IME.CustomerWorkers.Where(x => x.ID == so.ContactID)
                       from ca in IME.CustomerAddresses.Where(x => x.ID == so.InvoiceAddressID)
                       from cw1 in IME.CustomerWorkers.Where(x => x.ID == so.DeliveryContactID).DefaultIfEmpty()
                       from ca1 in IME.CustomerAddresses.Where(x => x.ID == so.DeliveryAddressID).DefaultIfEmpty()
                       where so.SaleDate >= endDate && so.SaleDate <= startDate
                       select new
                       {
                           Date = so.SaleDate,
                           SoNO = so.SaleOrderNo,
                           CustomerName = cw.Customer.c_name,
                           Contact = cw.cw_name,
                           DeliveryContact =cw1.cw_name,
                           Address = ca.AdressTitle,
                           DeliveryAddress =ca1.AdressTitle,
                           SaleID = so.SaleOrderID
                       };
            populateGrid(list.ToList());
        }

        private void populateGrid<T>(List<T> queryable)
        {
            dgSales.DataSource = null;
            dgSales.DataSource = queryable;

            foreach (DataGridViewColumn col in dgSales.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormSaleOrderCreate form = new FormSaleOrderCreate();
            form.ShowDialog();
            BringSalesList();
        }
        private void dgSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            { 

                if (dgSales.CurrentRow != null)
                {
                    IMEEntities IME = new IMEEntities();

                    string SaleOrderNo = dgSales.CurrentRow.Cells[1].Value.ToString();

                    SaleOrder so = IME.SaleOrders.Where(x => x.SaleOrderNo == SaleOrderNo).FirstOrDefault();

                   // NewPurchaseOrder form = new NewPurchaseOrder(so);
                   // form.ShowDialog();
                }
            }   
        }

        private void dgSales_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgSales.CurrentRow != null)
            {
                IMEEntities IME = new IMEEntities();

                string SaleOrderNo = dgSales.CurrentRow.Cells[1].Value.ToString();

                SaleOrder so = IME.SaleOrders.Where(x => x.SaleOrderNo == SaleOrderNo).FirstOrDefault();

               // NewPurchaseOrder form = new NewPurchaseOrder(so);
              //  form.ShowDialog();
            }
        }

        private void dgSales_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PurchaseOrderMenu.Show(dgSales, new Point(e.X, e.Y));
            }
        }

        private void PurchaseOrderMenu_Click(object sender, EventArgs e)
        {
            decimal item_code = 0;
           // string purchasecode = "";
            IMEEntities IME = new IMEEntities();

            if (dgSales.CurrentRow.Cells["SoNO"].Value != null)
            {
                item_code = Convert.ToDecimal(dgSales.CurrentRow.Cells["SaleID"].Value.ToString());
                //purchasecode = IME.PurchaseOrders.OrderByDescending(q => q.FicheNo).FirstOrDefault().FicheNo;
                //purchasecode += 1;
            }
            if (item_code == 0)
                MessageBox.Show("Please Enter a Item Code", "Eror !");
            else
            {
                this.Close();
                // NewPurchaseOrder f = new NewPurchaseOrder(item_code,purchasecode);
                NewPurchaseOrder f = new NewPurchaseOrder(item_code);
                f.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            IMEEntities db = new IMEEntities();
            foreach (DataGridViewRow row in dgSales.SelectedRows)
            {
                string SaleID = row.Cells[1].Value.ToString();
                SaleOrder s = db.SaleOrders.Where(x => x.SaleOrderNo == SaleID).FirstOrDefault();
                if(s != null)
                {
                    if (s.SaleOrderDetails != null)
                    {
                        db.SaleOrderDetails.RemoveRange(s.SaleOrderDetails);
                    }
                    db.SaleOrders.Remove(s);
                    db.SaveChanges();
                }
            }
            BringSalesList();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            BringSalesList(datetimeEnd.Value.Date, datetimeStart.Value.Date);
        }
    }
}
