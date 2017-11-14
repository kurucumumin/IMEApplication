using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LoginForm.DataSet;
using System.Linq;
using LoginForm.SaleOrder;

namespace LoginForm.SalesOrder
{
    public partial class FormSalesOrderMain : Form
    {
        //List<SalesOrder> list = new List<SalesOrder>

        public FormSalesOrderMain()
        {
            InitializeComponent();
        }

        private void FormSalesOrderMain_Load(object sender, EventArgs e)
        {
            BringSalesList();
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
                       from ca in IME.CustomerAddresses.Where(x => x.ID == so.AddressID)
                       from cw1 in IME.CustomerWorkers.Where(x => x.ID == so.DeliveryContactID).DefaultIfEmpty()
                       from ca1 in IME.CustomerAddresses.Where(x => x.ID == so.DeliveryAddressID).DefaultIfEmpty()
                       where so.SalesOrderDate >= endDate && so.SalesOrderDate <= startDate
                       select new
                       {
                           Date = so.SalesOrderDate,
                           SoNO = so.SoNO,
                           CustomerName = cw.Customer.c_name,
                           Contact = cw.cw_name,
                           DeliveryContact = (cw1.cw_name != null) ? cw1.cw_name : "--None--",
                           Address = ca.AdressDetails,
                           DeliveryAddress = (ca1.AdressDetails != null) ? ca1.AdressDetails : "--None--",

                       };
            populateGrid(list.ToList());

        }

        private void populateGrid<T>(List<T> queryable)
        {
            dgSales.DataSource = null;
            dgSales.DataSource = queryable;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormSaleOrderCreate form = new FormSaleOrderCreate();
            form.ShowDialog();
        }
    }
}
