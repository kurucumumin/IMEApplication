using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.QuotationModule;
using LoginForm.Item;
using LoginForm.User;

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
            customerMain.Show();
        }

        private void btnQuotation_Click(object sender, EventArgs e)
        {
            FormQuotationMain formQuotationMain = new FormQuotationMain();
            formQuotationMain.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierMain supplierMain = new SupplierMain();
            supplierMain.Show();
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            FormMain formMain = (FormMain) this.Parent.Parent.Parent;
            FormUserMain roles = new FormUserMain(formMain);
            roles.Show();
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard form = new ItemCard();
            form.Show();
        }
    }
}
