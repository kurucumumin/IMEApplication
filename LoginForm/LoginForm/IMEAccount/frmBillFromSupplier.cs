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

namespace LoginForm.IMEAccount
{
    public partial class frmBillFromSupplier : MyForm
    {
        bool IsUpdate = false;
        int PurchaseOperationID;
        public frmBillFromSupplier()
        {
            InitializeComponent();
        }

        public frmBillFromSupplier(int ID)
        {
            IMEEntities IME = new IMEEntities();
            IsUpdate = true;
            PurchaseOperationID = ID;
            InitializeComponent();
            var PurchaseOperations = IME.PurchaseOperations.Where(a => a.ID== PurchaseOperationID).FirstOrDefault();
            txtCustomer.Text = PurchaseOperations.SupplierID;
            txtCustomerName.Text = PurchaseOperations.Supplier.s_name;
            txtAmount.Text = PurchaseOperations.Amount.ToString();
            cbCurrency.SelectedValue = PurchaseOperations.CurrencyID;
            cbBank.SelectedValue = PurchaseOperations.AccountID;
            this.Show();
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            SupplierSearch();
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SupplierSearch();
            }
        }

        #region Functions
        private void SupplierSearch()
        {
            frmSupplierMain form = new frmSupplierMain(txtCustomer.Text);
            form.ShowDialog();
            if (classSupplier.Supplier!=null)
            {
                txtCustomer.Text = classSupplier.supplierID;
                txtCustomerName.Text = classSupplier.suppliername;
            }
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            if (IsUpdate)
            {//Update
                PurchaseOperation po = IME.PurchaseOperations.Where(a => a.ID == PurchaseOperationID).FirstOrDefault();
                DataSet.Account account = IME.Accounts.Where(a => a.ID == (int)cbBank.SelectedValue).FirstOrDefault();
                account.Value = (decimal)account.Value + (decimal)po.Amount;
                po.Amount = decimal.Parse(txtAmount.Text);
                account.Value = (decimal)account.Value + (decimal)po.Amount;
                po.CurrencyID =decimal.Parse( cbCurrency.SelectedValue.ToString());
                po.Description = txtDesc.Text;
                try { po.RepresentativeID = Utils.getCurrentUser().WorkerID; } catch { }
                po.SupplierID = txtCustomer.Text;
                changeAccount();
                po.AccountID = Int32.Parse(cbBank.SelectedValue.ToString());
                IME.SaveChanges();
                MessageBox.Show("Updated Successfully");
            }
            else
            {//new
                PurchaseOperation po = new PurchaseOperation();
                po.Amount = decimal.Parse(txtAmount.Text);

                DataSet.Account account = IME.Accounts.Where(a => a.ID == (int)cbBank.SelectedValue).FirstOrDefault();

                po.AccountID = account.ID;
                account.Value = (decimal)account.Value - (decimal)po.Amount; 
                po.CurrencyID = decimal.Parse(cbCurrency.SelectedValue.ToString());
                po.Description = txtDesc.Text;
                try { po.RepresentativeID = Utils.getCurrentUser().WorkerID; } catch { }
                po.SupplierID = txtCustomer.Text;
                IME.PurchaseOperations.Add(po);
                IME.SaveChanges();
                MessageBox.Show("Saved Successfully");
            }
            this.Close();
        }

        private void changeAccount()
        {
            IMEEntities IME = new IMEEntities();
            decimal UpdatedAmount = 0;
            if (IsUpdate)
            {
                UpdatedAmount = (decimal)IME.PurchaseOperations.Where(a => a.ID == PurchaseOperationID).FirstOrDefault().Amount;
            }
                int BankID = Int32.Parse(cbBank.SelectedValue.ToString());
                var Bank = IME.Accounts.Where(a => a.ID == BankID).FirstOrDefault();
            if (Bank.Value == null) Bank.Value = 0;
                Bank.Value = Bank.Value+ UpdatedAmount - Int32.Parse(txtAmount.Text);
                IME.SaveChanges();
        }

        private void frmBillFromCustomer_Load(object sender, EventArgs e)
        {
            LoadCurriencies();
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
