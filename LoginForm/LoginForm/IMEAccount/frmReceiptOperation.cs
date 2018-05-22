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

        private void Save_SaleReceipt()
        {
            Customer c = currentAccount as Customer;
            decimal amount = Convert.ToDecimal(txtAmount.Text);

            Save_SaleOperation(c.ID);
            UpdateCustomerDebitAmount(c.ID, amount);
            UpdateBankAmount(Convert.ToInt32(cmbAccount.SelectedValue), amount);
        }

        private void Save_SaleOperation(string CustomerID)
        {
            IMEEntities db = new IMEEntities();
            SalesOperation so = new SalesOperation();

            so.CustomerID = CustomerID;
            so.Amount = Convert.ToDecimal(txtAmount.Text);
            so.RepreresentetiveID = Services.Utils.getCurrentUser().WorkerID;
            so.CurrencyID = Convert.ToDecimal(cbCurrency.SelectedValue);
            so.AccountID = Convert.ToInt32(cmbAccount.SelectedValue);

            db.SalesOperations.Add(so);
            db.SaveChanges();
        }

        private void UpdateCustomerDebitAmount(string CustomerID, decimal amount)
        {
            IMEEntities db = new IMEEntities();
            Customer c = db.Customers.Where(x => x.ID == CustomerID).FirstOrDefault();

            c.Debit -= amount;

            db.SaveChanges();
        }

        private void UpdateBankAmount(int AccountID, decimal amount)
        {
            IMEEntities db = new IMEEntities();
            DataSet.Account a = db.Accounts.Where(x => x.ID == AccountID).FirstOrDefault();

            a.Value += amount;
            db.SaveChanges();
        }

        private void Save_PurchaseReceipt()
        {

        }
        private void Save_Virement()
        {

        }
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
