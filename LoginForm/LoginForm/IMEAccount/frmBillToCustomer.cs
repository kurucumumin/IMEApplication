using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;
using LoginForm.Services;
using LoginForm.QuotationModule;

namespace LoginForm.IMEAccount
{
    public partial class frmBillToCustomer : MyForm
    {
        IMEEntities IME = new IMEEntities();
        bool IsUpdate = false;
        int SalesOperationID;
        public static Customer customer;
        public frmBillToCustomer()
        {
            InitializeComponent();
        }

        public frmBillToCustomer(int ID)
        {
            InitializeComponent();
            SalesOperationID = ID;
            IsUpdate = true;
            var salesOperation = IME.SalesOperations.Where(a => a.ID == SalesOperationID).FirstOrDefault();
            txtCustomerName.Text = salesOperation.Customer.c_name;
            txtCustomerID.Text = salesOperation.CustomerID;
            txtAmount.Text = salesOperation.Amount.ToString();
            cbCurrency.SelectedValue = salesOperation.CurrencyID;
            cbBank.SelectedValue = salesOperation.AccountID;
            this.Show();
        }

        public frmBillToCustomer(string Name)
        {
            InitializeComponent();
            SalesOperationID = -1;
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            CustomerSearchInput();
        }

        #region Functions
        public void CustomerSearchInput()
        {
            QuotationUtils.customersearchID = txtCustomerName.Text;
            QuotationUtils.customersearchname = "";
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(customer);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                customer = form.customer;
            }
            this.Enabled = true;
            fillCustomer();
        }
        private void fillCustomer()
        {

            txtCustomerName.Text = QuotationUtils.customerID;
            txtCustomerID.Text = QuotationUtils.customername;

            var c = IME.Customers.Where(a => a.ID == txtCustomerName.Text).FirstOrDefault();
            if (c != null)
            {
                txtCustomerID.Text = c.c_name;
            }
        }

        private void LoadCurriencies()
        {
            IMEEntities IME = new IMEEntities();
            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            cbBank.DataSource = IME.Accounts.ToList();
            cbBank.DisplayMember = "Name";
            cbBank.ValueMember = "ID";
            changeCurrencySelection();
        }

        private void changeAccount()
        {
            IMEEntities IME = new IMEEntities();
            decimal UpdatedAmount = 0;
            if (IsUpdate)
            {
                UpdatedAmount = (decimal)IME.PurchaseOperations.Where(a => a.ID == SalesOperationID).FirstOrDefault().Amount;
            }
            int BankID = Int32.Parse(cbBank.SelectedValue.ToString());
            var Bank = IME.Accounts.Where(a => a.ID == BankID).FirstOrDefault();
            if (Bank.Value == null) Bank.Value = 0;
            Bank.Value = Bank.Value - UpdatedAmount + Decimal.Parse(txtAmount.Text);
            IME.SaveChanges();
        }
        private void changeCurrencySelection()
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                Int32 cbBankID = Int32.Parse(cbBank.SelectedValue.ToString());
                cbCurrency.SelectedValue = IME.Accounts.Where(a => a.ID == cbBankID).FirstOrDefault().CurrencyID;
            }
            catch { }
        }
        #endregion

        private void BillToCustomer_Load(object sender, EventArgs e)
        {
            LoadCurriencies();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SalesOperationID==-1)
            {
                //New
                SalesOperation so = new SalesOperation();

                so.Amount = decimal.Parse(txtAmount.Text);
                so.CurrencyID = decimal.Parse(cbCurrency.SelectedValue.ToString());
                so.CustomerID = txtCustomerName.Text;
               
                try { so.RepresentativeID = Utils.getCurrentUser().WorkerID; } catch { }
                so.AccountID=Int32.Parse(cbBank.SelectedValue.ToString());
                changeAccount();
                string strcustomer = txtCustomerName.Text;
               Customer c = IME.Customers.Where(a => a.ID == strcustomer).FirstOrDefault();
                if (c.Debit == null) c.Debit = 0;
                decimal dcmAmount = (decimal)so.Amount;
                dcmAmount = ChangeCurrency.ChangeCurrencyToDefault((decimal)so.CurrencyID, dcmAmount);
                c.Debit = c.Debit - dcmAmount;
                IME.SalesOperations.Add(so);
                IME.SaveChanges();
                MessageBox.Show("Saved Successfully");
            }
            else
            {
                //Update
                SalesOperation so = IME.SalesOperations.Where(a => a.ID == SalesOperationID).FirstOrDefault();
                string strcustomerID = txtCustomerID.Text;
                Customer c = IME.Customers.Where(a => a.ID == strcustomerID).FirstOrDefault();
                if (c.Debit == null) c.Debit = 0;
                decimal dcmAmount= (decimal)so.Amount;
                dcmAmount = ChangeCurrency.ChangeCurrencyToDefault((decimal)so.CurrencyID, dcmAmount);
                c.Debit = c.Debit + so.Amount;
                so.Amount = decimal.Parse(txtAmount.Text);
                dcmAmount = (decimal)so.Amount;
                dcmAmount = ChangeCurrency.ChangeCurrencyToDefault((decimal)so.CurrencyID, dcmAmount);
                c.Debit = c.Debit - dcmAmount;
                so.CurrencyID = decimal.Parse(cbCurrency.SelectedValue.ToString());
                so.CustomerID = txtCustomerName.Text;
                try { so.RepresentativeID = Utils.getCurrentUser().WorkerID; } catch { }
                changeAccount();
                so.AccountID = Int32.Parse(cbBank.SelectedValue.ToString());
                IME.SaveChanges();
                MessageBox.Show("Updated Successfully");
            }
            frmAccountMain form = new frmAccountMain();
            form.Show();
            this.Close();
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    CustomerSearchInput();
                }
        }

        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            frmAccount form = new frmAccount();
            form.Show();
            LoadCurriencies();
        }

        private void cbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCurrencySelection();
        }
    }
}
