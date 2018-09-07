using LoginForm.ItemModule;
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
using LoginForm.StockManagement;
using LoginForm.IMEAccount;
using LoginForm.Main;

namespace LoginForm.CustomControls
{
    public partial class DevelopmentControl : NavigationControl
    {
        public DevelopmentControl()
        {
            InitializeComponent();
            idleButtonColor = btnCustomer.BackColor;
            pressedButtonColor = btnCustomer.FlatAppearance.MouseOverBackColor;
        }

        private void DevelopmentControl_Load(object sender, EventArgs e)
        {
            checkAuthorities();
        }

        public void checkAuthorities()
        {
            if (Utils.getCurrentUser() != null)
            {
                List<AuthorizationValue> AuthList = Utils.getCurrentUser().AuthorizationValues.ToList();

                if (AuthList.Where(a => a.AuthorizationID == 1089).Count() <= 0)//Can See Customer Module
                {
                    btnCustomer.Visible = false;
                }
                if (AuthList.Where(a => a.AuthorizationID == 1121).Count() <= 0)//Can See Quotation Module
                {
                    btnQuotation.Visible = false;
                }
                if (AuthList.Where(a => a.AuthorizationID == 1094).Count() <= 0)//Can See Supplier Module
                {
                    btnSupplier.Visible = false;
                }
                if (AuthList.Where(a => a.AuthorizationID == 1092).Count() <= 0)//Can See Purchase Order Module
                {
                    btnPurchaseOrders.Visible = false;
                }
                if (AuthList.Where(a => a.AuthorizationID == 1097).Count() <= 0)//Can See User Module
                {
                    btnWorker.Visible = false;
                }
                if (AuthList.Where(a => a.AuthorizationID == 1100).Count() <= 0)//Can See Item Card Module
                {
                    btnItemCard.Visible = false;
                }
                if (AuthList.Where(a => a.AuthorizationID == 1104).Count() <= 0)//Can See Sale Order Module
                {
                    btnSalesOrder.Visible = false;
                }
            }
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
            ____frmSupplierMain supplierMain = new ____frmSupplierMain();
            supplierMain.Show();
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            frmMainMetro formMain = (frmMainMetro) this.ParentForm;
            FormUserMain roles = new FormUserMain(formMain);
            roles.Show();
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard form = new ItemCard();
            form.Show();
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            OpenSubNavigationMenu((Button)sender, parent.subControlSalesOrder);
        }

        private void btnPurchaseOrders_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain form = new PurchaseOrderMain();
            form.Show();
        }

        private void OpenSubNavigationMenu(Button button, UserControl subControl)
        {
            FormMain parent = this.ParentForm as FormMain;
            if (pressedButton == button && parent.CurrentNavTabLvl2 != null)
            {
                parent.CurrentNavTabLvl2.Visible = false;
                parent.CurrentNavTabLvl2 = null;

                ChangeToDefaultDesign();
            }
            else
            {
                if (parent.CurrentNavTabLvl2 != null && parent.CurrentNavTabLvl2.Visible == true)
                {
                    parent.CurrentNavTabLvl2.Visible = false;
                    parent.CurrentNavTabLvl2 = null;
                }

                ChangeToDefaultDesign();
                pressedButton = button;

                button.BackColor = pressedButtonColor;
                subControl.Visible = true;
                parent.CurrentNavTabLvl2 = subControl;
            }

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            StockManagement.frmStock form = new StockManagement.frmStock();
            form.Show();
        }

        private void btnFatura_Click(object sender, EventArgs e)
        {
            Billing.frmFaturalanacaklar frm = new Billing.frmFaturalanacaklar();
            frm.Show();
        }

        private void IMEAccount_Click(object sender, EventArgs e)
        {
            frmAccountMain form = new frmAccountMain();
            form.Show();
        }
    }
}
