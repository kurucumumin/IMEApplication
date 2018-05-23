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
using LoginForm.QuotationModule;
using LoginForm.Services;

namespace LoginForm.IMEAccount
{
    public partial class frmReceiptOperation : Form
    {
        IMEEntities IME = new IMEEntities();

        private Customer customer;
        private Supplier supplier;
        private object currentAccount;

        public frmReceiptOperation()
        {
            InitializeComponent();
        }

        private void frmReceiptOperation_Load(object sender, EventArgs e)
        {
            #region Combobox
            cbReceipt.DataSource = IME.ReceiptTypes.ToList();
            cbReceipt.DisplayMember = "Name";
            cbReceipt.ValueMember = "ReceiptTypeID";

            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";

            cmbAccount.DataSource = IME.Accounts.ToList();
            cmbAccount.DisplayMember = "Name";
            cmbAccount.ValueMember = "ID";
            #endregion
            cbReceipt.SelectedIndex = -1;
            groupBox1.Visible = false;
        }

        private void txtCustomerName_DoubleClick(object sender, EventArgs e)
        {
            if (cbReceipt.SelectedIndex == 0)
            {
                CustomerSearch();
            }
            if (cbReceipt.SelectedIndex == 1)
            {
                SupplierSearch();
            }
        }
        
        public void CustomerSearch()
        {
            classQuotationAdd.customersearchname = txtCustomerName.Text;
            classQuotationAdd.customersearchID = "";
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(currentAccount as Customer);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                currentAccount = form.customer;
            }
            this.Enabled = true;
            fillCustomer();
        }
        private void fillCustomer()
        {
            if (currentAccount != null)
            {
                txtCustomerName.Text = (currentAccount as Customer).c_name;
                txtCustomerID.Text = (currentAccount as Customer).ID;
            }
        }

        public void SupplierSearch()
        {

            classSupplier.suppliersearchname = txtCustomerName.Text;
            classSupplier.suppliersearchID = "";
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(supplier);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                supplier = form.supplier;
            }
            this.Enabled = true;
            fillSupplier();
        }
        private void fillSupplier()
        {
            txtCustomerName.Text = classSupplier.supplierID;
            txtCustomerID.Text = classSupplier.suppliername;

            var c = IME.Suppliers.Where(a => a.s_name == txtCustomerName.Text).FirstOrDefault();
            if (c != null)
            {
                txtCustomerName.Text = c.s_name;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbReceipt.SelectedIndex == 0)
            {
                CustomerSearch();
            }
            if (cbReceipt.SelectedIndex == 1)
            {
                SupplierSearch();
            }
        }

        private void SaveFunction()
        {
            switch (cbReceipt.SelectedIndex)
            {
                case (int)eReceiptTypes.SaleReceipt:
                    Save_SaleReceipt();
                    break;
                case (int)eReceiptTypes.PurchaseReceipt:
                    Save_PurchaseReceipt();
                    break;
                case (int)eReceiptTypes.Virement:
                    Save_Virement();
                    break;
                case (int)eReceiptTypes.ServiceReceipt:
                    Save_ServiceReceipt();
                    break;
                case (int)eReceiptTypes.Others:
                    Save_Others();
                    break;
            }
        }
        
        private void UpdateAccountAmount(int AccountID, decimal amount, bool increaseValue)
        {
            IMEEntities db = new IMEEntities();
            DataSet.Account a = db.Accounts.Where(x => x.ID == AccountID).FirstOrDefault();
            if (!increaseValue) amount *= -1; 
            a.Value += amount;
            db.SaveChanges();
        }
        
        #region SaleInvoice
        private void Save_SaleReceipt()
        {
            Customer c = currentAccount as Customer;
            decimal amount = Convert.ToDecimal(txtAmount.Text);

            Save_SaleOperation(c.ID);
            UpdateCustomerDebitAmount(c.ID, amount);
            UpdateAccountAmount(Convert.ToInt32(cmbAccount.SelectedValue), amount, true);
        }

        private void Save_SaleOperation(string CustomerID)
        {
            IMEEntities db = new IMEEntities();
            SalesOperation so = new SalesOperation();

            so.CustomerID = CustomerID;
            so.Amount = Convert.ToDecimal(txtAmount.Text);
            so.RepresentativeID = Services.Utils.getCurrentUser().WorkerID;
            so.CurrencyID = Convert.ToDecimal(cbCurrency.SelectedValue);
            so.AccountID = Convert.ToInt32(cmbAccount.SelectedValue);

            db.SalesOperations.Add(so);
            db.SaveChanges();
        }

        private void UpdateCustomerDebitAmount(string CustomerID, decimal amount)
        {
            IMEEntities db = new IMEEntities();
            Customer c = db.Customers.Where(x => x.ID == CustomerID).FirstOrDefault();
            if (c.Debit == null) c.Debit = 0;
            c.Debit -= amount;

            db.SaveChanges();
        }
        #endregion
        #region PurchaseInvoice
        private void Save_PurchaseReceipt()
        {
            Supplier s = currentAccount as Supplier;
            decimal amount = Convert.ToDecimal(txtAmount.Text);

            Save_PurchaseOperation(s.ID);
            UpdateSupplierDebitAmount(s.ID, amount);
            UpdateAccountAmount(Convert.ToInt32(cmbAccount.SelectedValue), amount, false);
        }

        private void Save_PurchaseOperation(string SupplierID)
        {
            IMEEntities db = new IMEEntities();
            PurchaseOperation po = new PurchaseOperation();

            po.AccountID = Convert.ToInt32(cmbAccount.SelectedValue);
            po.Amount = Convert.ToDecimal(txtAmount.Text);
            po.Description = txtDescription.Text;
            po.SupplierID = SupplierID;
            po.RepresentativeID = Services.Utils.getCurrentUser().WorkerID;
            po.CurrencyID = Convert.ToDecimal(cbCurrency.SelectedValue);
            

            db.PurchaseOperations.Add(po);
            db.SaveChanges();
        }

        private void UpdateSupplierDebitAmount(string SupplierID, decimal amount)
        {
            IMEEntities db = new IMEEntities();

            Supplier s = db.Suppliers.Where(x => x.ID == SupplierID).FirstOrDefault();
            if (s.Debit == null) s.Debit = 0;
            s.Debit -= amount;

            db.SaveChanges();
        }
        #endregion
        #region AccountTransaction
        private void Save_Virement()
        {
            DataSet.Account a = currentAccount as DataSet.Account;
            decimal amount = Convert.ToDecimal(txtAmount.Text);

            Save_AccountOperation(a.ID);
            UpdateAccountAmount(a.ID, amount, false);
            UpdateAccountAmount(Convert.ToInt32(cmbAccount.SelectedValue), amount, true);
        }

        private void Save_AccountOperation(int AccountID)
        {
            IMEEntities db = new IMEEntities();
            AccountOperation ao = new AccountOperation();

            ao.FromAccountID = AccountID;
            ao.Amount = Convert.ToDecimal(txtAmount.Text);
            ao.Date = Convert.ToDateTime(db.CurrentDate().FirstOrDefault());
            ao.Description = txtDescription.Text;
            ao.ToAccountID = Convert.ToInt32(cmbAccount.SelectedValue);
            ao.RepresentativeID = Utils.getCurrentUser().WorkerID;

            db.AccountOperations.Add(ao);
            db.SaveChanges();
        }

        #endregion

        private void Save_ServiceReceipt()
        {

        }
        private void Save_Others()
        {

        }

        private enum eReceiptTypes
        {
            SaleReceipt = 0,
            PurchaseReceipt = 1,
            Virement = 2,
            ServiceReceipt = 3,
            Others = 4
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFunction();
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbReceipt.SelectedIndex == 0)
                {
                    CustomerSearch();
                }
                if (cbReceipt.SelectedIndex == 1)
                {
                    SupplierSearch();
                }
            }
        }
        private void cbReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbReceipt.SelectedIndex == 0)
            {
                groupBox1.Visible = true;
                lblCustomer.Text = "Customer Code/Name";
            }
            if (cbReceipt.SelectedIndex == 1)
            {
                groupBox1.Visible = true;
                lblCustomer.Text = "Supplier Code/Name";
            }
        }
    }

}
