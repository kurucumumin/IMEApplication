using LoginForm.Item;
using LoginForm.nsSaleOrder;
using LoginForm.PurchaseOrder;
using LoginForm.QuotationModule;
using LoginForm.User;
using System;
using System.Windows.Forms;
using LoginForm.Services;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using LoginForm.DataSet;

namespace LoginForm.CustomControls
{
    public partial class SalesOrderControl : UserControl
    {
        public SalesOrderControl()
        {
            InitializeComponent();
        }

        private void btnFromQuotation_Click(object sender, EventArgs e)
        {
            //FormSalesOrderMain form = new FormSalesOrderMain();
            FormSalesOrderMain form = new FormSalesOrderMain();
            form.Show();
        }

        private void btnEmptySalesOrder_Click(object sender, EventArgs e)
        {
            DevFormSaleOrderAdd form = new DevFormSaleOrderAdd();
            form.Show();
        }
    }
}
