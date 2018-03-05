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

namespace LoginForm.CustomControls
{
    public partial class DevelopmentControl : UserControl
    {
        public DevelopmentControl()
        {
            InitializeComponent();
            checkAuthorities();
        }

        private void checkAuthorities()
        {
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1089).Count() <= 0)//Can See Customer Module
            {
                btnCustomer.Visible = false;
            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1121).Count() <= 0)//Can See Quotation Module
            {
                btnQuotation.Visible = false;
            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1094).Count() <= 0)//Can See Supplier Module
            {
                btnSupplier.Visible = false;
            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1092).Count() <= 0)//Can See Purchase Order Module
            {
                btnPurchaseOrders.Visible = false;
            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1097).Count() <= 0)//Can See User Module
            {
                btnWorker.Visible = false;
            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1100).Count() <= 0)//Can See Item Card Module
            {
                btnItemCard.Visible = false;
            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1104).Count() <= 0)//Can See Sale Order Module
            {
                btnSalesOrder.Visible = false;
            }
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
            CemSupplierMainCem supplierMain = new CemSupplierMainCem();
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

        private void btnPurchaseOrders_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain form = new PurchaseOrderMain();
            form.ShowDialog();
        }
    }
}
