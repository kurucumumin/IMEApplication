using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LoginForm.DataSet;
using System.Linq;
using System.Drawing;
using LoginForm.PurchaseOrder;
using LoginForm.QuotationModule;
using LoginForm.Services;
using System.Data;
using LoginForm.clsClasses;
using static LoginForm.Services.MyClasses.MyAuthority;
using ImeLogoLibrary;
using LoginForm.MyClasses;
using LoginForm.Services.SP;

namespace LoginForm.User
{
    public partial class FormAuthorities : Form
    {
        string name = "";
        List<AuthorizationValue> authList;
        IMEEntities IME = new IMEEntities();

        public FormAuthorities()
        {
            InitializeComponent();
        }

        public FormAuthorities(List<AuthorizationValue> auth)
        {
            InitializeComponent();
            IMEEntities IME = new IMEEntities();
            authList = auth;
            clbUserAuthorityList.DataSource = authList;
            clbUserAuthorityList.DisplayMember = "AuthorizationValue1";
            CheckAllItemsListBox(clbUserAuthorityList, true);
            LoadRoles();
            LoadUserAuthorization();
        }

        private void LoadRoles()
        {
            lbRoles.DataSource = AuthorizationService.getRoles().Where(x=> x.roleName==name).ToList();
            lbRoles.DisplayMember = "roleName";
        }

        private void LoadUserAuthorization()
        {
            clbUserAuthorityList.DataSource = authList;
            clbUserAuthorityList.DisplayMember = "AuthorizationValue1";
            CheckAllItemsListBox(clbUserAuthorityList, true);
        }

        private void CheckAllItemsListBox(CheckedListBox listBox, bool state)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, state);
            }
        }

        private void chcAllAuth_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            if (chcAllAuth.Checked == true)
            {
                //tüm otoriteleri işaretle
                clbAuthorities.DataSource = IME.AuthorizationValues.ToList();
                clbAuthorities.DisplayMember = "AuthorizationValue1";
                SelectAllChangeState(clbAuthorities, true);
            }
            else
            {
                //tüm otoriteleri kaldır
                clbAuthorities.DataSource = IME.AuthorizationValues.Where(x=> x.AuthorizationValue1.Contains(ıtemCardToolStripMenuItem.Text)).ToList();
                clbAuthorities.DisplayMember = "AuthorizationValue1";
                SelectAllChangeState(clbAuthorities, false);
            }
        }

        void SelectAllChangeState(CheckedListBox listBox, bool state)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, state);
                X(listBox, i);
            }
        }

        void X(CheckedListBox listBox, int index)
        {
            bool state = clbAuthorities.GetItemChecked(index);

            if (state)
            {
                if (!authList.Exists(x => x.AuthorizationID == ((AuthorizationValue)(clbAuthorities.Items[index])).AuthorizationID))
                {
                    authList.Add((AuthorizationValue)clbAuthorities.Items[index]);
                    RefreshUserAuthList();
                }
            }
            else if (!state)
            {
                for (int i = 0; i < clbUserAuthorityList.Items.Count; i++)
                {
                    if (((AuthorizationValue)clbAuthorities.Items[index]).AuthorizationID == ((AuthorizationValue)clbUserAuthorityList.Items[i]).AuthorizationID)
                    {
                        authList.Remove((AuthorizationValue)clbUserAuthorityList.Items[i]);
                        RefreshUserAuthList();
                    }
                }
            }
        }

        #region Menüler
        private void MenuItem(string select)
        {
            clbAuthorities.DataSource = IME.AuthorizationValues.Where(x => x.AuthorizationValue1.Contains(select)).ToList();
            clbAuthorities.DisplayMember = "AuthorizationValue1";
            chcAllAuth.Checked = false;
           // SelectAllChangeState(clbAuthorities, true);
        }

        private void ıtemCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(ıtemCardToolStripMenuItem.Text);
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(customerToolStripMenuItem.Text);
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(supplierToolStripMenuItem.Text);
        }

        private void quotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(quotationToolStripMenuItem.Text);
        }

        private void salesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(salesOrderToolStripMenuItem.Text);
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(purchaseOrderToolStripMenuItem.Text);
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(stockToolStripMenuItem.Text);
        }

        private void toBeInvoicedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(toBeInvoicedToolStripMenuItem.Text);
        }

        private void rsInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(rsInvoiceToolStripMenuItem.Text);
        }

        private void superDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(superDiskToolStripMenuItem.Text);
        }

        private void superDiskPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(superDiskPToolStripMenuItem.Text);
        }

        private void slidingPriceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(slidingPriceFileToolStripMenuItem.Text);
        }

        private void hazardouseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(hazardouseFileToolStripMenuItem.Text);
        }

        private void rsProListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(rsProListToolStripMenuItem.Text);
        }

        private void tSEListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(tSEListToolStripMenuItem.Text);
        }

        private void dualUsedArticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(dualUsedArticlesToolStripMenuItem.Text);
        }

        private void extendedRangePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(extendedRangePriceToolStripMenuItem.Text);
        }

        private void discontinuedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(discontinuedListToolStripMenuItem.Text);
        }

        private void onSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(onSaleToolStripMenuItem.Text);
        }

        private void orderAcknowledgementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(orderAcknowledgementToolStripMenuItem.Text);
        }

        private void backOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(backOrderToolStripMenuItem.Text);
        }

        private void exchangeRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(exchangeRateToolStripMenuItem.Text);
        }

        private void termsOfPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(termsOfPaymentToolStripMenuItem.Text);
        }

        private void categorySubCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(categorySubCategoryToolStripMenuItem.Text);
        }

        private void roleAuthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(roleAuthsToolStripMenuItem.Text);
        }

        private void managmentControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(managmentControlToolStripMenuItem.Text);
        }

        private void customerTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(customerTransferToolStripMenuItem.Text);
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem(userToolStripMenuItem.Text);
        }
        #endregion

        private void RefreshUserAuthList()
        {
            clbUserAuthorityList.DataSource = null;
            clbUserAuthorityList.DataSource = authList;
            clbUserAuthorityList.DisplayMember = "AuthorizationValue1";

            CheckAllItemsListBox(clbUserAuthorityList, true);
        }

        private void matchAuthorities()
        {
            for (int i = 0; i < clbAuthorities.Items.Count; i++)
            {
                for (int j = 0; j <= clbUserAuthorityList.Items.Count; j++)
                {
                    if (j == clbUserAuthorityList.Items.Count)
                    {
                        clbAuthorities.SetItemChecked(i, false);
                    }
                    else if (((AuthorizationValue)clbUserAuthorityList.Items[j]).AuthorizationID == ((AuthorizationValue)clbAuthorities.Items[i]).AuthorizationID)
                    {
                        clbAuthorities.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        private void clbUserAuthorityList_MouseClick(object sender, MouseEventArgs e)
        {
            int index = clbUserAuthorityList.SelectedIndex;
            if (index >= 0)
            {
                authList.Remove((AuthorizationValue)clbUserAuthorityList.Items[index]);

                RefreshUserAuthList();
                matchAuthorities();
                clbUserAuthorityList.ClearSelected();
            }
        }

        private void clbAuthorities_MouseClick(object sender, MouseEventArgs e)
        {
            int index = clbAuthorities.SelectedIndex;
            bool state = clbAuthorities.GetItemChecked(index);


            if (!state)
            {
                authList.Add((AuthorizationValue)clbAuthorities.Items[index]);
                RefreshUserAuthList();
            }
            else if (state)
            {
                for (int i = 0; i < clbUserAuthorityList.Items.Count; i++)
                {
                    if (((AuthorizationValue)clbAuthorities.Items[index]).AuthorizationID == ((AuthorizationValue)clbUserAuthorityList.Items[i]).AuthorizationID)
                    {
                        authList.Remove((AuthorizationValue)clbUserAuthorityList.Items[i]);
                        RefreshUserAuthList();
                    }
                }
            }
        }
    }
}
