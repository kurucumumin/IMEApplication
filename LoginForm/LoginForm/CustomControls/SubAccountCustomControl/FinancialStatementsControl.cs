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
using LoginForm.Account;
using Open_Miracle;

namespace LoginForm.CustomControls
{
    public partial class FinancialStatementsControl : UserControl
    {
        public FinancialStatementsControl()
        {
            InitializeComponent();
        }

        private void btnCashFlow_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmCashFlow", "View"))
                //{
                    frmCashFlow objCashFlow = new frmCashFlow();
                    frmCashFlow open = Application.OpenForms["frmCashFlow"] as frmCashFlow;
                    if (open == null)
                    {
                        //objCashFlow.MdiParent = this;
                        objCashFlow.Show();
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
                MessageBox.Show("MDI 219: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChartOfAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmChartOfAccount", "View"))
                //{
                    frmChartOfAccount objChartOfAccount = new frmChartOfAccount();
                    frmChartOfAccount open = Application.OpenForms["frmChartOfAccount"] as frmChartOfAccount;
                    if (open == null)
                    {
                        //objChartOfAccount.MdiParent = this;
                        objChartOfAccount.Show();
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
                MessageBox.Show("MDI 221 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFundFlow_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmFundFlow", "View"))
                //{
                frmFundFlow objFundFlow = new frmFundFlow();
                frmFundFlow open = Application.OpenForms["frmFundFlow"] as frmFundFlow;
                if (open == null)
                {
                    //objFundFlow.MdiParent = this;
                    objFundFlow.Show();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 220: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnProfitAndLoss_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmProfitAndLoss", "View"))
                //{
                    frmProfitAndLoss objProfitAndLoss = new frmProfitAndLoss();
                    frmProfitAndLoss open = Application.OpenForms["frmProfitAndLoss"] as frmProfitAndLoss;
                    if (open == null)
                    {
                        //objProfitAndLoss.MdiParent = this;
                        objProfitAndLoss.Show();
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
                MessageBox.Show("MDI 218: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTrialBalance_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmTrialBalance", "View"))
                //{
                    frmTrialBalance objTrialBalance = new frmTrialBalance();
                    frmTrialBalance open = Application.OpenForms["frmTrialBalance"] as frmTrialBalance;
                    if (open == null)
                    {
                        //objTrialBalance.MdiParent = this;
                        objTrialBalance.Show();
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
                MessageBox.Show("MDI 216 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, "frmBalanceSheet", "View"))
                //{
                    frmBalanceSheet objBalanceSheet = new frmBalanceSheet();
                    frmBalanceSheet open = Application.OpenForms["frmBalanceSheet"] as frmBalanceSheet;
                    if (open == null)
                    {
                        //objBalanceSheet.MdiParent = this;
                        objBalanceSheet.Show();
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
                MessageBox.Show("MDI 217: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
