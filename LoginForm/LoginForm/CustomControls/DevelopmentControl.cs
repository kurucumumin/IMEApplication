using LoginForm.Item;
using LoginForm.PurchaseOrder;
using LoginForm.QuotationModule;
using LoginForm.SalesOrder;
using LoginForm.ShipingDetails;
using LoginForm.User;
using System;
using System.Windows.Forms;

namespace LoginForm.CustomControls
{
    public partial class DevelopmentControl : UserControl
    {
        public DevelopmentControl()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerMain customerMain = new CustomerMain();
           customerMain.ShowDialog();
        }

        private void btnQuotation_Click(object sender, EventArgs e)
        {
            FormQuotationMain formQuotationMain = new FormQuotationMain();
            formQuotationMain.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierMain supplierMain = new SupplierMain();
            supplierMain.ShowDialog();
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            FormMain formMain = (FormMain) this.Parent.Parent.Parent;
            FormUserMain roles = new FormUserMain(formMain);
            roles.ShowDialog();
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard form = new ItemCard();
            form.ShowDialog();
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            FormSalesOrderMain form = new FormSalesOrderMain();
            form.ShowDialog();
        }

        private void btnShippingDetail_Click(object sender, EventArgs e)
        {
            ShipingDetailMain form = new ShipingDetailMain();
            form.ShowDialog();
        }

        private void btnPurchaseOrders_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain form = new PurchaseOrderMain();
            form.ShowDialog();
        }
    }
}
