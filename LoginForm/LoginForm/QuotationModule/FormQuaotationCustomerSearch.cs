using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class FormQuaotationCustomerSearch : Form
    {
        IMEEntities IME = new IMEEntities();
        public Customer customer;
        public Supplier supplier;
        public DataSet.Account account;
        public Current current;
        public XmlCustomer xmlCustomer;
        bool fromXmlCustomer = false;
        object choosenObject;

        public FormQuaotationCustomerSearch()
        {
            InitializeComponent();
        }

        public FormQuaotationCustomerSearch(string _Name)
        {
            InitializeComponent();

            CustomerName.Text = _Name;
            CustomerSearchGrid.DataSource = CustomerSearch(_Name);
        }

        private List<Customer> CustomerSearch(string _Name = "")
        {
            List<Customer> cList = new IMEEntities().Customers.
                Where(x => x.c_name.Contains(_Name)).
                //Where(x => x.ID.IndexOf(_ID, StringComparison.OrdinalIgnoreCase) >= 0).
                ToList();

            return cList;
        }

        public FormQuaotationCustomerSearch(XmlCustomer customer)
        {
            InitializeComponent();
            fromXmlCustomer = true;
            this.xmlCustomer = customer;
        }

        public FormQuaotationCustomerSearch(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            CustomerSearch();
        }

        public FormQuaotationCustomerSearch(Supplier supplier)
        {
            InitializeComponent();
            this.supplier = supplier;
            SupplierSearch();
        }

        public FormQuaotationCustomerSearch(DataSet.Account account)
        {
            InitializeComponent();
            this.account = account;
            AccountSearch();
        }

        public FormQuaotationCustomerSearch(Current current, string searchName)
        {
            InitializeComponent();
            this.current = current;
            CustomerName.Text = searchName;
            CurrentSearch(searchName);
        }

        public void CustomerSearch()
        {
            this.Text = "Customer Search";
            label1.Text = "Customer Code";
            label2.Text = "Customer Name";
            button1.Text = "Add New Customer";
            CustomerCode.Text = QuotationUtils.customersearchID.ToString();
            CustomerName.Text = QuotationUtils.customersearchname;
            List<Customer> c = QuotationUtils.CustomerSearch();
            CustomerSearchGrid.DataSource = c;
            if (fromXmlCustomer && c.Count <= 0)
            {
                MessageBox.Show("Customer Not Found!");
                frmXmlCustomerAdd frm = new frmXmlCustomerAdd(xmlCustomer);
                frm.ShowDialog();
            }
            else
            {
                CustomerSearchGrid.DataSource = c;
            }
        }

        public void SupplierSearch()
        {
            this.Text = "Supplier Search";
            label1.Text = "Supplier Code";
            label2.Text = "Supplier Name";
            button1.Text = "Add New Supplier";
            CustomerCode.Text = classSupplier.suppliersearchID.ToString();
            CustomerName.Text = classSupplier.suppliersearchname;
            List<Supplier> c = classSupplier.SupplierSearch();
            CustomerSearchGrid.DataSource = c;
        }

        public void AccountSearch()
        {
            this.Text = "Account Search";
            label1.Text = "Account Code";
            label2.Text = "Account Name";
            button1.Visible = false;
            CustomerCode.Text = classAccount.accountsearchID.ToString();
            CustomerName.Text = classAccount.accountsearchname;
            List<DataSet.Account> c = classAccount.AccountSearch();
            CustomerSearchGrid.DataSource = c;
        }

        public void CurrentSearch(string name)
        {
            this.Text = "Current Search";
            label1.Text = "Current Code";
            label2.Text = "Current Name";
            button1.Visible = false;
            //CustomerCode.Text = classCurrent.CurrentSearchID;
            //CustomerName.Text = classCurrent.CurrentSearchName;
            List<Current> c = classCurrent.CurrentSearch(name, CustomerCode.Text);
            CustomerSearchGrid.DataSource = c;
        }

        private void CustomerSearchGrid_DoubleClick(object sender, EventArgs e)
        {

            CustomerSearchGrid.ClearSelection();
            #region Customer Search
            if (this.Text == "Customer Search")
            {
                string cID = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();
                customer = IME.Customers.Where(a => a.ID == cID).FirstOrDefault();
                CustomerCode.Text = customer.ID;
                CustomerName.Text = customer.c_name;
                QuotationUtils.customerID = CustomerCode.Text;
                QuotationUtils.customername = CustomerName.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            #endregion

            #region Supplier Search
            if (this.Text == "Supplier Search")
            {
                string cID = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();
                supplier = IME.Suppliers.Where(a => a.ID == cID).FirstOrDefault();
                CustomerCode.Text = supplier.ID;
                CustomerName.Text = supplier.s_name;
                classSupplier.supplierID = CustomerCode.Text;
                classSupplier.suppliername = CustomerName.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            #endregion

            #region Account Search
            if (this.Text == "Account Search")
            {
                int cID = Convert.ToInt32(CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString());
                account = IME.Accounts.Where(a => a.ID == cID).FirstOrDefault();
                CustomerCode.Text = account.ID.ToString();
                CustomerName.Text = account.Name;
                classAccount.accountID = CustomerCode.Text;
                QuotationUtils.customername = CustomerName.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            #endregion

            #region Current Search
            if (this.Text == "Current Search")
            {
                CustomerSearchGrid.ClearSelection();
                int cID = Convert.ToInt32(CustomerSearchGrid.CurrentRow.Cells["CurrentID"].Value.ToString());
                current = IME.Currents.Where(a => a.CurrentID == cID).FirstOrDefault();
                CustomerCode.Text = current.CurrentID.ToString();
                CustomerName.Text = current.Name;
                //classCurrent.currentID = CustomerCode.Text;
                //classCurrent.currentname = CustomerName.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            #endregion
        }

        private void CustomerSearchGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region Customer Search
                if (this.Text == "Customer Search")
                {
                    CustomerSearchGrid.ClearSelection();
                    string cID = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();
                    customer = IME.Customers.Where(a => a.ID == cID).FirstOrDefault();
                    CustomerCode.Text = customer.ID;
                    CustomerName.Text = customer.c_name;
                    QuotationUtils.customerID = CustomerCode.Text;
                    QuotationUtils.customername = CustomerName.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                #endregion

                #region Supplier Search
                if (this.Text == "Supplier Search")
                {
                    CustomerSearchGrid.ClearSelection();
                    string cID = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();
                    supplier = IME.Suppliers.Where(a => a.ID == cID).FirstOrDefault();
                    CustomerCode.Text = supplier.ID;
                    CustomerName.Text = supplier.s_name;
                    classSupplier.supplierID = CustomerCode.Text;
                    classSupplier.suppliername = CustomerName.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                #endregion

                #region Account Search
                if (this.Text == "Account Search")
                {
                    CustomerSearchGrid.ClearSelection();
                    int cID = Convert.ToInt32(CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString());
                    account = IME.Accounts.Where(a => a.ID == cID).FirstOrDefault();
                    CustomerCode.Text = account.ID.ToString();
                    CustomerName.Text = account.Name;
                    classAccount.accountID = CustomerCode.Text;
                    QuotationUtils.customername = CustomerName.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                #endregion

                #region Current Search
                if (this.Text == "Current Search")
                {
                    CustomerSearchGrid.ClearSelection();
                    int cID = Convert.ToInt32(CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString());
                    current = IME.Currents.Where(a => a.CurrentID == cID).FirstOrDefault();
                    CustomerCode.Text = current.CurrentID.ToString();
                    CustomerName.Text = current.Name;
                    //classCurrent.currentID = CustomerCode.Text;
                    //classCurrent.currentname = CustomerName.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                #endregion
            }
        }

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.Text == "Customer Search")
                {
                    QuotationUtils.customersearchID = CustomerCode.Text;
                    QuotationUtils.customersearchname = "";
                    List<Customer> c = QuotationUtils.CustomerSearch();
                    CustomerSearchGrid.DataSource = c;
                }
                if (this.Text == "Supplier Search")
                {
                    classSupplier.suppliersearchID = CustomerCode.Text;
                    classSupplier.suppliersearchname = "";
                    List<Supplier> c = classSupplier.SupplierSearch();
                    CustomerSearchGrid.DataSource = c;
                }
                if (this.Text == "Account Search")
                {
                    classAccount.accountsearchID = CustomerCode.Text;
                    classAccount.accountsearchname = "";
                    List<DataSet.Account> c = classAccount.AccountSearch();
                    CustomerSearchGrid.DataSource = c;
                }
                if (this.Text == "Current Search")
                {
                    List<Current> c = classCurrent.CurrentSearch("", CustomerCode.Text);
                    CustomerSearchGrid.DataSource = c;
                }
            }
        }

        private void CustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.Text == "Customer Search")
                {
                    QuotationUtils.customersearchID = "";
                    QuotationUtils.customersearchname = CustomerName.Text;
                    List<Customer> c = QuotationUtils.CustomerSearch();
                    CustomerSearchGrid.DataSource = c;
                }
                if (this.Text == "Supplier Search")
                {
                    classSupplier.suppliersearchID = "";
                    classSupplier.suppliersearchname = CustomerName.Text;
                    List<Supplier> c = classSupplier.SupplierSearch();
                    CustomerSearchGrid.DataSource = c;
                }
                if (this.Text == "Account Search")
                {
                    classAccount.accountsearchID = "";
                    classAccount.accountsearchname = CustomerName.Text;
                    List<DataSet.Account> c = classAccount.AccountSearch();
                    CustomerSearchGrid.DataSource = c;
                }
                if (this.Text == "Current Search")
                {
                    List<Current> c = classCurrent.CurrentSearch(CustomerName.Text, CustomerCode.Text);
                    CustomerSearchGrid.DataSource = c;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Text== "Customer Search")
            {
                CustomerMain form = new CustomerMain(true);
                form.ShowDialog();
            }
            if (this.Text == "Supplier Search")
            {
                frmSupplierMain form = new frmSupplierMain(true);
                form.ShowDialog();
            }

        }
    }
}
