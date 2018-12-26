using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class FormFactor : Form
    {
        IMEEntities IME = new IMEEntities();

        public FormFactor()
        {
            InitializeComponent();
        }

        public void setManagementModule(DataSet.Management m)
        {
            IMEEntities db = new IMEEntities();

            txtFactor.Text = m.Factor.ToString();
            txtHSFactor.Text = m.HSFactor.ToString();
            txtLIFactor.Text = m.LIFactor.ToString();

        }

        private void FormFactor_Load(object sender, EventArgs e)
        {
            setManagementModule(Utils.getManagement());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IMEEntities IME = new IMEEntities();
                DataSet.Management management = IME.Managements.First();

                management.Factor = Convert.ToDecimal(txtFactor.Text);
                management.HSFactor = Convert.ToDecimal(txtHSFactor.Text);
                management.LIFactor = Convert.ToDecimal(txtLIFactor.Text);

                IME.SaveChanges();


                MessageBox.Show("Changes Saved", "Success");
                Utils.LogKayit("Factor Control", "Factor Control added");
            }
            catch (Exception)
            {
                MessageBox.Show("MC1: An error occured while saving changes. Try again.");
                throw;
            }

            if (chkCustomer.Checked == true)
            {
                try
                {

                    FactorUpdate();
                    MessageBox.Show("Factor added to customers", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("MC1: An error occured while saving changes. Try again.");
                    throw;
                }
            }
        }

        private void FactorUpdate()
        {
            IME.CustomerFactorUpdate(Convert.ToDecimal(txtFactor.Text));
        }
    }
}
