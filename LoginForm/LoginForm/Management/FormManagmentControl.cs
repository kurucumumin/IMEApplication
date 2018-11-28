using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.ManagementModule
{
    public partial class FormManagmentControl : MyForm
    {
        IMEEntities IME = new IMEEntities();

        public FormManagmentControl()
        {
            InitializeComponent();
        }

        private void FormManagmentControl_Load(object sender, EventArgs e)
        {
            checkAuthorities();
            setManagementModule(Utils.getManagement());
        }

        public void checkAuthorities()
        {
            if (Utils.getCurrentUser() != null)
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
            }
        }
        public void setManagementModule(DataSet.Management m)
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
            txtNote.Text = m.Note;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkCustomer.Checked==true)
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
            else
            {
                try
                {
                    IMEEntities IME = new IMEEntities();
                    DataSet.Management management = IME.Managements.First();
                    management.LowMarginLimit = Convert.ToDecimal(txtLowMarginLimit.Text);
                    management.VAT = Convert.ToDecimal(txtVAT.Text);
                    management.Factor = numericFactor.Value;
                    management.DefaultCurrency = Convert.ToDecimal(cbCurrency.SelectedValue);
                    management.DataSeperetor = txtDataSeperator.Text;
                    //management.BranchCode = txtBranchCode.Text;
                    management.CustomsRate = CustomsRateUpDown.Value;
                    management.FreightCharge = FreightChargeUpDown.Value;
                    management.Note = txtNote.Text;

                    IME.SaveChanges();

                    Company c = IME.Companies.Where(x => x.companyId == management.CurrentCompanyId).FirstOrDefault();
                    c.BranchCode = txtBranchCode.Text;

                    IME.SaveChanges();
                    MessageBox.Show("Changes Saved", "Success");
                    Utils.LogKayit("Managment Control", "Managment Control added");
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
            IME.CustomerFactorUpdate(numericFactor.Value);
            //IME.SaveChanges();
        }

    }
}
