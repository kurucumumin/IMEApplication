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
using LoginForm.Account;

namespace LoginForm.CustomControls
{
    public partial class ReminderControl : UserControl
    {
        public ReminderControl()
        {
            InitializeComponent();
        }

        private void btnOverduePurchaseOrder_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmOverduePurchaseOrder", "View"))
                //{
                    frmOverduePurchaseOrder objOverduePurchaseOrder = new frmOverduePurchaseOrder();
                    frmOverduePurchaseOrder open = Application.OpenForms["frmOverduePurchaseOrder"] as frmOverduePurchaseOrder;
                    if (open == null)
                    {
                        //objOverduePurchaseOrder.MdiParent = this;
                        objOverduePurchaseOrder.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 154: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOverdueSalesOrder_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmOverdueSalesOrder", "View"))
                //{
                    frmOverdueSalesOrder objOverdueSalesOrder = new frmOverdueSalesOrder();
                    frmOverdueSalesOrder open = Application.OpenForms["frmOverdueSalesOrder"] as frmOverdueSalesOrder;
                    if (open == null)
                    {
                        //objOverdueSalesOrder.MdiParent = this;
                        objOverdueSalesOrder.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 155: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPersonalReminder_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmPersonalReminder", "Save"))
                //{
                    frmPersonalReminder objPersonalReminder = new frmPersonalReminder();
                    frmPersonalReminder open = Application.OpenForms["frmPersonalReminder"] as frmPersonalReminder;
                    if (open == null)
                    {
                        //objPersonalReminder.MdiParent = this;
                        objPersonalReminder.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 156: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnShortExpiry_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmShortExpiry", "View"))
                //{
                    frmShortExpiry objShortExpiry = new frmShortExpiry();
                    frmShortExpiry open = Application.OpenForms["frmShortExpiry"] as frmShortExpiry;
                    if (open == null)
                    {
                        //objShortExpiry.MdiParent = this;
                        objShortExpiry.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 157: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmStock", "View"))
                //{
                Account.frmStock objStock = new Account.frmStock();
                Account.frmStock open = Application.OpenForms["frmStock"] as Account.frmStock;
                    if (open == null)
                    {
                        //objStock.MdiParent = this;
                        objStock.Show();
                    }
                    else
                    {
                        open.Activate();
                        if (open.WindowState == FormWindowState.Minimized)
                        {
                            open.WindowState = FormWindowState.Normal;
                        }
                    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 158: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
