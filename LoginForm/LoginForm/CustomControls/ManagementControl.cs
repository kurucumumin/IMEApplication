using System;
using System.Linq;
using System.Windows.Forms;
using LoginForm.DataSet;
using LoginForm.ManagementModule;

namespace LoginForm.CustomControls
{
    public partial class ManagementControl : UserControl
    {
        public ManagementControl()
        {
            InitializeComponent();
        }

        public void setManagementModule(Management m)
        {
            IMEEntities db = new IMEEntities();
            txtLowMarginLimit.Text = Convert.ToString(m.LowMarginLimit);
            txtVAT.Text = Convert.ToString(m.VAT);
            numericFactor.Value = m.Factor;

            cbCurrency.DataSource = db.Currencies.ToList();
            cbCurrency.SelectedValue = m.DefaultCurrency;

            txtDataSeperator.Text = m.DataSeperator;
            txtBranchCode.Text = m.Company.BranchCode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try          {
                IMEEntities IME = new IMEEntities();
                Management management = IME.Managements.First();
                management.LowMarginLimit = Convert.ToDecimal(txtLowMarginLimit.Text);
                management.VAT = Convert.ToDecimal(txtVAT.Text);
                management.DefaultCurrency = Convert.ToDecimal(cbCurrency.SelectedValue);
                management.Factor = numericFactor.Value;
                management.DataSeperator = txtDataSeperator.Text;
                IME.SaveChanges();

                Company c = IME.Companies.Where(x => x.companyId == management.CurrentCompanyId).FirstOrDefault();
                c.BranchCode = txtBranchCode.Text;

                IME.SaveChanges();

                MessageBox.Show("Changes Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("MC1: An error occured while saving changes. Try again.");
                throw;
            }
        }

        private void btnRolesAuthorities_Click(object sender, EventArgs e)
        {
            FormRoleAuths form = new FormRoleAuths();
            form.ShowDialog();
        }

        private void btnTermsOfPayment_Click(object sender, EventArgs e)
        {
            FormTermsOfPayment form = new FormTermsOfPayment();
            form.ShowDialog();
        }

        private void btnExchangeRate_Click(object sender, EventArgs e)
        {
            FormExchangeRate form = new FormExchangeRate();
            form.ShowDialog();
        }

        private void btnCategorySubCategory_Click(object sender, EventArgs e)
        {
            FormCategorySubCategory form = new FormCategorySubCategory();
            form.ShowDialog();
        }
    }
}
