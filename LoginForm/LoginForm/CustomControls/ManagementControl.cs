using System;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;
using LoginForm.DataSet;
using LoginForm.WorkerManagement;

namespace LoginForm.CustomControls
{
    public partial class ManagementControl : UserControl
    {
        public ManagementControl()
        {
            InitializeComponent();
        }
        public void setManagementModule(decimal? value)
        {
            txtLowMarginLimit.Text = Convert.ToString(value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IMEEntities IME = new IMEEntities();
                Management management = IME.Managements.First();
                management.LowMarginLimit = Convert.ToDecimal(txtLowMarginLimit.Text);
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
    }
}
