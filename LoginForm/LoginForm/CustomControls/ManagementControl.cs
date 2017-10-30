using System;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;
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
            txtLowMarginLimit.Text = Convert.ToString(m.LowMarginLimit);
            txtVAT.Text = Convert.ToString(m.VAT);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IMEEntities IME = new IMEEntities();
                Management management = IME.Managements.First();
                management.LowMarginLimit = Convert.ToDecimal(txtLowMarginLimit.Text);
                management.VAT = Convert.ToDecimal(txtVAT.Text);
                IME.SaveChanges();

                MessageBox.Show("Changes Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while saving changes. Try again.");
                throw;
            }
        }

        private void btnRolesAuthorities_Click(object sender, EventArgs e)
        {
            FormRoleAuths form = new FormRoleAuths();
            form.Show();
        }

        private void btnTermsOfPayment_Click(object sender, EventArgs e)
        {
            FormTermsOfPayment form = new FormTermsOfPayment();
            form.Show();
        }
    }
}
