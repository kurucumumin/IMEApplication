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

namespace LoginForm.CustomControls
{
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
        }

        private void btnVoucherSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmVoucherSearch objVoucherSearch = new frmVoucherSearch();
                frmVoucherSearch open = Application.OpenForms["frmVoucherSearch"] as frmVoucherSearch;
                if (open == null)
                {
                    //objVoucherSearch.MdiParent = this;
                    objVoucherSearch.Show();
                }
                else
                {
                    open.Activate();
                    if (open.WindowState == FormWindowState.Minimized)
                    {
                        open.WindowState = FormWindowState.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 152: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
