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
    public partial class PayrollControl : UserControl
    {
        public PayrollControl()
        {
            InitializeComponent();
        }

        private void btnAdvancePayment_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmAdvancePayment))
                    {
                        frm.Activate();
                        IsActivate = true;
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    //TODO Formu ekledikten sonra açılacak
                    //string strVoucherType = "Advance Payment";
                    //frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    //frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    //if (open == null)
                    //{
                    //    //frm.MdiParent = this;
                    //    frm.CallFromVoucherMenu(strVoucherType);
                    //}
                    //else
                    //{
                    //    open.CallFromVoucherMenu(strVoucherType);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 50 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdvanceRegister_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdvanceRegister objAdvanceRegister = new frmAdvanceRegister();
                frmAdvanceRegister open = Application.OpenForms["frmAdvanceRegister"] as frmAdvanceRegister;
                if (open == null)
                {
                    //objAdvanceRegister.MdiParent = this;
                    objAdvanceRegister.Show();
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
                MessageBox.Show("MDI 53: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                frmAttendance objAttendance = new frmAttendance();
                frmAttendance open = Application.OpenForms["frmAttendance"] as frmAttendance;
                if (open == null)
                {
                    //objAttendance.MdiParent = this;
                    objAttendance.Show();
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
                MessageBox.Show("MDI 52: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBonusDeduction_Click(object sender, EventArgs e)
        {
            try
            {
                frmBonusDeduction frm = new frmBonusDeduction();
                frmBonusDeduction open = Application.OpenForms["frmBonusDeduction"] as frmBonusDeduction;
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
                MessageBox.Show("MDI 57: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBonusDeductionRegister_Click(object sender, EventArgs e)
        {
            try
            {
                frmBonusDeductionRegister frm = new frmBonusDeductionRegister();
                frmBonusDeductionRegister open = Application.OpenForms["frmBonusDeductionRegister"] as frmBonusDeductionRegister;
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
                MessageBox.Show("MDI 58 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDailySalaryRegister_Click(object sender, EventArgs e)
        {
            try
            {
                frmDailySalaryRegister frm = new frmDailySalaryRegister();
                frmDailySalaryRegister open = Application.OpenForms["frmDailySalaryRegister"] as frmDailySalaryRegister;
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
                MessageBox.Show("MDI 81 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDailySalaryVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmDailySalaryVoucher))
                    {
                        frm.Activate();
                        IsActivate = true;
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    //TODO Formu ekledikten sonra açılacak
                    //string strVoucherType = "Daily Salary Voucher";
                    //frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    //frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    //if (open == null)
                    //{
                    //    //frm.MdiParent = this;
                    //    frm.CallFromVoucherMenu(strVoucherType);
                    //}
                    //else
                    //{
                    //    open.CallFromVoucherMenu(strVoucherType);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 82 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDesignation_Click(object sender, EventArgs e)
        {
            try
            {
                frmDesignation frm = new frmDesignation();
                frmDesignation open = Application.OpenForms["frmDesignation"] as frmDesignation;
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
                MessageBox.Show("MDI 95 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHolidaySettings_Click(object sender, EventArgs e)
        {
            try
            {
                frmHolydaySettings frm = new frmHolydaySettings();
                frmHolydaySettings open = Application.OpenForms["frmHolydaySettings"] as frmHolydaySettings;
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
                MessageBox.Show("MDI 56: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMontlySalaryRegister_Click(object sender, EventArgs e)
        {
            try
            {
                frmMonthlySalaryRegister frm = new frmMonthlySalaryRegister();
                frmMonthlySalaryRegister open = Application.OpenForms["frmMonthlySalaryRegister"] as frmMonthlySalaryRegister;
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
                MessageBox.Show("MDI 84 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMontlySalarySettings_Click(object sender, EventArgs e)
        {
            try
            {
                frmMonthlySalarySettings objMonthlySalarySettings = new frmMonthlySalarySettings();
                frmMonthlySalarySettings open = Application.OpenForms["frmMonthlySalarySettings"] as frmMonthlySalarySettings;
                if (open == null)
                {
                    //objMonthlySalarySettings.MdiParent = this;
                    objMonthlySalarySettings.Show();
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
                MessageBox.Show("MDI 54: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMontlySalaryVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsActivate = false;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmMonthlySalaryVoucher))
                    {
                        frm.Activate();
                        IsActivate = true;
                        if (frm.WindowState == FormWindowState.Minimized)
                        {
                            frm.WindowState = FormWindowState.Normal;
                        }
                    }
                }
                if (IsActivate == false)
                {
                    //TODO Formu ekledikten sonra açılacak
                    //string strVoucherType = "Monthly Salary Voucher";
                    //frmVoucherTypeSelection frm = new frmVoucherTypeSelection();
                    //frmVoucherTypeSelection open = Application.OpenForms["frmVoucherTypeSelection"] as frmVoucherTypeSelection;
                    //if (open == null)
                    //{
                    //    //frm.MdiParent = this;
                    //    frm.CallFromVoucherMenu(strVoucherType);
                    //}
                    //else
                    //{
                    //    open.CallFromVoucherMenu(strVoucherType);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 55 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPayHead_Click(object sender, EventArgs e)
        {
            try
            {
                frmPayHead frm = new frmPayHead();
                frmPayHead open = Application.OpenForms["frmPayHead"] as frmPayHead;
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
                MessageBox.Show("MDI 96 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPaySlip_Click(object sender, EventArgs e)
        {
            try
            {
                frmPaySlip objPaySlip = new frmPaySlip();
                frmPaySlip open = Application.OpenForms["frmPaySlip"] as frmPaySlip;
                if (open == null)
                {
                    //objPaySlip.MdiParent = this;
                    objPaySlip.Show();
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
                MessageBox.Show("MDI 120: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalaryPackageCreation_Click(object sender, EventArgs e)
        {
            try
            {
                frmSalaryPackageCreation frm = new frmSalaryPackageCreation();
                frmSalaryPackageCreation open = Application.OpenForms["frmSalaryPackageCreation"] as frmSalaryPackageCreation;
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
                MessageBox.Show("MDI 49: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalaryPackageRegister_Click(object sender, EventArgs e)
        {
            try
            {
                frmSalaryPackageRegister frm = new frmSalaryPackageRegister();
                frmSalaryPackageRegister open = Application.OpenForms["frmSalaryPackageRegister"] as frmSalaryPackageRegister;
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
                MessageBox.Show("MDI 83 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
