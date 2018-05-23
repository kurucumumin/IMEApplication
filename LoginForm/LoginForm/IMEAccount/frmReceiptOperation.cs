﻿using System;
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
            if (cbReceipt.SelectedIndex == 2)
            {
                AccountSearch();
            }
            if (cbReceipt.SelectedIndex == 3)
            {
                CurrentSearch();
            }
        }

        #region CustomerSearch
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
        #endregion

        #region SupplierSearch
        public void SupplierSearch()
        {

            classSupplier.suppliersearchname = txtCustomerName.Text;
            classSupplier.suppliersearchID = "";
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(currentAccount as Supplier);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                currentAccount = form.supplier;
            }
            this.Enabled = true;
            fillSupplier();
        }

        private void fillSupplier()
        {
            if (currentAccount != null)
            {
                txtCustomerName.Text = (currentAccount as Supplier).s_name;
                txtCustomerID.Text = (currentAccount as Supplier).ID;
            }
        }
        #endregion

        #region AccountSearch
        public void AccountSearch()
        {

            classAccount.accountsearchname = txtCustomerName.Text;
            classAccount.accountsearchID = "";
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(currentAccount as DataSet.Account);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                currentAccount = form.account;
            }
            this.Enabled = true;
            fillAccount();
        }

        private void fillAccount()
        {
            if (currentAccount != null)
            {
                txtCustomerName.Text = (currentAccount as DataSet.Account).Name;
                txtCustomerID.Text = (currentAccount as DataSet.Account).ID.ToString();
            }
        }
        #endregion

        #region CurrentSearch
        public void CurrentSearch()
        {

            classCurrent.currentsearchname= txtCustomerName.Text;
            classCurrent.currentsearchID = "";
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(currentAccount as Current);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                currentAccount = form.current;
            }
            this.Enabled = true;
            fillCurrent();
        }

        private void fillCurrent()
        {
            if (currentAccount != null)
            {
                txtCustomerName.Text = (currentAccount as Current).Name;
                txtCustomerID.Text = (currentAccount as Current).CurrentID.ToString();
            }
        }
        #endregion

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
            if (cbReceipt.SelectedIndex == 2)
            {
                AccountSearch();
            }
            if (cbReceipt.SelectedIndex == 3)
            {
                CurrentSearch();
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
                    Save_ExpenseReceipt();
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
        #region ReceiptOperation
        private void Save_ExpenseReceipt()
        {
            Current c = currentAccount as Current;
            decimal amount = Convert.ToDecimal(txtAmount.Text);

            Save_Receipt(c.CurrentID);
            //UpdateCurrentDebitAmount(c.CurrentID, amount);
            UpdateAccountAmount(Convert.ToInt32(cmbAccount.SelectedValue), amount, false);
        }

        private void Save_Receipt(int CurrentID)
        {
            IMEEntities db = new IMEEntities();
            Receipt r = new Receipt();

            r.ReceiptTypeID = Convert.ToInt32(cbReceipt.SelectedValue);
            r.Amount = Convert.ToDecimal(txtAmount.Text);
            r.CurrencyID = Convert.ToInt32(cbCurrency.SelectedValue);
            r.Date = Convert.ToDateTime(db.CurrentDate().FirstOrDefault());
            r.CurrentID = CurrentID;
            r.Description = txtDescription.Text;
            r.RepresentativeID = Utils.getCurrentUser().WorkerID;

            db.Receipts.Add(r);
            db.SaveChanges();
        }

        //private void UpdateCurrentDebitAmount(int CurrentID, decimal amount)
        //{
        //    IMEEntities db = new IMEEntities();
        //    Current c = db.Currents.Where(x => x.CurrentID == CurrentID).FirstOrDefault();
        //    if (c.Debit == null) c.Debit = 0;
        //    c.Total -= amount;

        //    db.SaveChanges();
        //}
        #endregion

        private enum eReceiptTypes
        {
            SaleReceipt = 0,
            PurchaseReceipt = 1,
            Virement = 2,
            ServiceReceipt = 3
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
                if (cbReceipt.SelectedIndex == 2)
                {
                    AccountSearch();
                }
                if (cbReceipt.SelectedIndex == 3)
                {
                    CurrentSearch();
                }
            }
        }

        private void cbReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbReceipt.SelectedIndex == 0)
            {
                lblCustomer.Text = "Customer Code/Name";
            }
            if (cbReceipt.SelectedIndex == 1)
            {
                lblCustomer.Text = "Supplier Code/Name";
            }
            if (cbReceipt.SelectedIndex == 2)
            {
                lblCustomer.Text = "Account Code/Name";
            }
            if (cbReceipt.SelectedIndex == 3)
            {
                lblCustomer.Text = "Current Code/Name";
            }
            if (cbReceipt.SelectedIndex >= 0)
            {
                groupBox1.Visible = true;
            }
            txtCustomerID.Clear();
            txtCustomerName.Clear();


        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCurrency.SelectedValue = ((DataSet.Account)cmbAccount.SelectedItem).CurrencyID;
        }
    }

}
