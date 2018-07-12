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
    public partial class BudgetControl : UserControl
    {
        public BudgetControl()
        {
            InitializeComponent();
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            frmBudget frm = new frmBudget();
            frmBudget open = Application.OpenForms["frmBudget"] as frmBudget;
            if (open == null)
            {
                //frm.MdiParent = this.ParentForm;
                frm.Show();
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

        private void btnBudgetVariance_Click(object sender, EventArgs e)
        {
            try
            {
                frmBudgetVariance frm = new frmBudgetVariance();
                frmBudgetVariance open = Application.OpenForms["frmBudgetVariance"] as frmBudgetVariance;
                if (open == null)
                {
                    //frm.MdiParent = this.ParentForm;
                    frm.Show();
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
                MessageBox.Show("MDI 163: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
