using System;
using System.Linq;
using System.Windows.Forms;
using LoginForm.DataSet;
using LoginForm.ManagementModule;
using LoginForm.Services;
using System.Data;

namespace LoginForm.CustomControls
{
    public partial class ManagementControl : NavigationControl
    {
        public ManagementControl()
        {
            InitializeComponent();
        }
        private void ManagementControl_Load(object sender, EventArgs e)
        {
            checkAuthorities();
        }
        public void checkAuthorities()
        {
            if(Utils.getCurrentUser() != null)
            {
                System.Collections.Generic.List<AuthorizationValue> authList = Utils.getCurrentUser().AuthorizationValues.ToList();
                if (authList.Where(a => a.AuthorizationID == 1107).Count() <= 0)//Can Edit Low Margin Limit
                {
                    lblLowMarginLimit.Visible = false;
                    txtLowMarginLimit.Visible = false;
                }
                if (authList.Where(a => a.AuthorizationID == 1108).Count() <= 0)//Can Edit VAT
                {
                    lblVAT.Visible = false;
                    txtVAT.Visible = false;
                }
                if (authList.Where(a => a.AuthorizationID == 1109).Count() <= 0)//Can Edit Default Currency
                {
                    lblDefaultCurrency.Visible = false;
                    cbCurrency.Visible = false;
                }
                if (authList.Where(a => a.AuthorizationID == 1110).Count() <= 0)//Can Edit Factor
                {
                    lblFactor.Visible = false;
                    numericFactor.Visible = false;
                }
                if (authList.Where(a => a.AuthorizationID == 1111).Count() <= 0)//Can Edit Data Seperator
                {
                    label1.Visible = false;
                    txtDataSeperator.Visible = false;
                }
                if (authList.Where(a => a.AuthorizationID == 1112).Count() <= 0)//Can Edit Data Branch Code
                {
                    label2.Visible = false;
                    txtBranchCode.Visible = false;
                }
                if (authList.Where(a => a.AuthorizationID == 1113).Count() <= 0)//Can Edit Data Exchange Rate
                {
                    exchangeRateToolStripMenuItem.Visible = false;
                }
                if (authList.Where(a => a.AuthorizationID == 1122).Count() <= 0)//Can Edit Terms of Payment
                {
                    termsOfPaymentToolStripMenuItem.Visible = false;
                }
                if (authList.Where(a => a.AuthorizationID == 1123).Count() <= 0)//Can Edit Roles and Authorities
                {
                    rolesAndAuthoritiesToolStripMenuItem.Visible = false;
                }
                if (authList.Where(a => a.AuthorizationID == 1124).Count() <= 0)//Can Edit Category and SubCategory
                {
                    mainCategorySubCategoryToolStripMenuItem1.Visible = false;
                }
            }
        }
        public void setManagementModule(Management m)
        {
            IMEEntities db = new IMEEntities();
            txtLowMarginLimit.Text = Convert.ToString(m.LowMarginLimit);
            txtVAT.Text = Convert.ToString(m.VAT);
            numericFactor.Value = m.Factor;
            CustomsRateUpDown.Value = Convert.ToDecimal(m.CustomsRate);
            FreightChargeUpDown.Value = Convert.ToDecimal(m.FreightCharge);
            cbCurrency.DataSource = db.Currencies.ToList();
            cbCurrency.SelectedValue = m.DefaultCurrency;

            txtDataSeperator.Text = m.DataSeperetor;
            txtBranchCode.Text = m.Company.BranchCode;
        }


        private void exchangeRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExchangeRate form = new FormExchangeRate();
            form.ShowDialog();
        }

        private void termsOfPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTermsOfPayment form = new FormTermsOfPayment();
            form.ShowDialog();
        }

        private void mainCategorySubCategoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCategorySubCategory form = new FormCategorySubCategory();
            form.ShowDialog();
        }

        private void rolesAndAuthoritiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRoleAuths form = new FormRoleAuths();
            form.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IMEEntities IME = new IMEEntities();
                Management management = IME.Managements.First();
                management.LowMarginLimit = Convert.ToDecimal(txtLowMarginLimit.Text);
                management.VAT = Convert.ToDecimal(txtVAT.Text);
                management.Factor = numericFactor.Value;
                management.DefaultCurrency = Convert.ToDecimal(cbCurrency.SelectedValue);
                management.DataSeperetor = txtDataSeperator.Text;
                //management.BranchCode = txtBranchCode.Text;
                management.CustomsRate = CustomsRateUpDown.Value;
                management.FreightCharge = FreightChargeUpDown.Value;
                IME.SaveChanges();

                Company c = IME.Companies.Where(x => x.companyId == management.CurrentCompanyId).FirstOrDefault();
                c.BranchCode = txtBranchCode.Text;

                IME.SaveChanges();



                MessageBox.Show("Changes Saved", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("MC1: An error occured while saving changes. Try again.");
                throw;
            }
        }
        
    }
}
