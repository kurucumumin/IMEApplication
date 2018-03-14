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
    public partial class MastersControl : UserControl
    {
        public MastersControl()
        {
            InitializeComponent();
        }

        private void btnAccountGroup_Click(object sender, EventArgs e)
        {
            try
            {
                frmAccountGroup frm = new frmAccountGroup();
                frmAccountGroup open = Application.OpenForms["frmAccountGroup"] as frmAccountGroup;
                if (open == null)
                {
                    //frm.MdiParent = this;
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
                MessageBox.Show("MDI 59: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAccountLedger_Click(object sender, EventArgs e)
        {
            try
            {
                frmAccountLedger frm = new frmAccountLedger();
                frmAccountLedger open = Application.OpenForms["frmAccountLedger"] as frmAccountLedger;
                if (open == null)
                {
                    //frm.MdiParent = this;
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
                MessageBox.Show("MDI 80 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            try
            {
                frmArea frm = new frmArea();
                frmArea open = Application.OpenForms["frmArea"] as frmArea;
                if (open == null)
                {
                    //frm.MdiParent = this;
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
                MessageBox.Show("MDI 85 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            try
            {
                frmCurrency frm = new frmCurrency();
                frmCurrency open = Application.OpenForms["frmCurrency"] as frmCurrency;
                if (open == null)
                {
                    //frm.MdiParent = this;
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
                MessageBox.Show("MDI 67 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExchangeRate_Click(object sender, EventArgs e)
        {
            try
            {
                frmExchangeRate frm = new frmExchangeRate();
                frmExchangeRate open = Application.OpenForms["frmExchangeRate"] as frmExchangeRate;
                if (open == null)
                {
                    //frm.MdiParent = this;
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
                MessageBox.Show("MDI 68 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMultipleAccountLedger_Click(object sender, EventArgs e)
        {
            try
            {
                frmMultipleAccountLedger frm = new frmMultipleAccountLedger();
                frmMultipleAccountLedger open = Application.OpenForms["frmmultipleAccountLedger"] as frmMultipleAccountLedger;
                if (open == null)
                {
                    //frm.MdiParent = this;
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
                MessageBox.Show("MDI 61: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalesman_Click(object sender, EventArgs e)
        {
            try
            {
                frmSalesman frm = new frmSalesman();
                frmSalesman open = Application.OpenForms["frmSalesman"] as frmSalesman;
                if (open == null)
                {
                    //frm.MdiParent = this;
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
                MessageBox.Show("MDI 92 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTax_Click(object sender, EventArgs e)
        {
            try
            {
                frmTax frm = new frmTax();
                frmTax open = Application.OpenForms["frmTax"] as frmTax;
                if (open == null)
                {
                    //frm.MdiParent = this;
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
                MessageBox.Show("MDI 78 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVoucherType_Click(object sender, EventArgs e)
        {
            try
            {
                frmVoucherType frm = new frmVoucherType();
                frmVoucherType open = Application.OpenForms["frmVoucherType"] as frmVoucherType;
                if (open == null)
                {
                    //frm.MdiParent = this;
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
                MessageBox.Show("MDI 79 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
