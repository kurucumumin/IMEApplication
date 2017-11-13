using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LoginForm.DataSet;
using System.Linq;

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
            IMEEntities IME = new IMEEntities();
            BringSalesList(DateTime.Today, DateTime.Today.AddDays(-7));
        }

        private void BringSalesList(DateTime startDate, DateTime endDate)
        {
            IMEEntities IME = new IMEEntities();

            dynamic list = from so in IME.SaleOrders
                       join cw in IME.CustomerWorkers on so.ContactID equals cw.ID
                       join cw1 in IME.CustomerWorkers on so.DeliveryContactID equals cw1.ID
                       join cwa in IME.CustomerAddresses on so.AddressID equals cwa.ID
                       join cwa1 in IME.CustomerAddresses on so.AddressID equals cwa1.ID
                       where so.SalesOrderDate >= endDate && so.SalesOrderDate <= startDate
                       select new
                       {
                           Date = so.SalesOrderDate,
                           SoNO = so.SoNO,
                           CustomerName = cw.Customer.c_name,
                           Contact = cw.cw_name,
                           DeliveryContact = cw1.cw_name,
                           Address = cwa.AdressDetails,
                           DeliveryAddress = cwa1.AdressDetails

                       };

            populateGrid(list.ToList());
        }

        private void populateGrid<T>(List<T> queryable)
        {
            dgSales.DataSource = null;
            dgSales.DataSource = queryable;
        }
    }
}
