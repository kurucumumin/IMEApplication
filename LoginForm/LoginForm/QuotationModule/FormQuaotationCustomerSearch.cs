using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        SqlHelper sqlHelper = new SqlHelper();
        FormQuotationAdd parent;
        decimal sayac = 0;
        public FormQuaotationCustomerSearch()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
           CustomerSearchGrid, new object[] { true });

            CustomerSearchGrid.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
        }

        public FormQuaotationCustomerSearch(string _Name)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
          CustomerSearchGrid, new object[] { true });

            CustomerSearchGrid.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;

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

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
          CustomerSearchGrid, new object[] { true });

            CustomerSearchGrid.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
            fromXmlCustomer = true;
            this.xmlCustomer = customer;
        }

        public FormQuaotationCustomerSearch(Customer customer)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
          CustomerSearchGrid, new object[] { true });

            CustomerSearchGrid.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
            this.customer = customer;
            CustomerSearch();
        }

        public FormQuaotationCustomerSearch(Customer customer, FormQuotationAdd parent)
        {
            this.parent = parent;
            InitializeComponent();
            sayac = 1;
            button2.Visible = false;
            label4.Visible = false;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
          CustomerSearchGrid, new object[] { true });

            CustomerSearchGrid.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;
            this.customer = customer;
            CustomerSearch();
        }

        public FormQuaotationCustomerSearch(Supplier supplier)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
          CustomerSearchGrid, new object[] { true });

            CustomerSearchGrid.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
            this.supplier = supplier;
            SupplierSearch();
        }

        public FormQuaotationCustomerSearch(DataSet.Account account)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
          CustomerSearchGrid, new object[] { true });

            CustomerSearchGrid.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
            this.account = account;
            AccountSearch();
        }

        public FormQuaotationCustomerSearch(Current current, string searchName)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
          CustomerSearchGrid, new object[] { true });

            CustomerSearchGrid.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
            this.current = current;
            CustomerName.Text = searchName;
            CurrentSearch(searchName);
        }

        public void CustomerSearch()
        {
            this.Text = "Customer Search";
            label1.Text = "Customer Code";
            label2.Text = "Customer Name";
            label3.Text = "Add New Customer";
            CustomerCode.Text = QuotationUtils.customersearchname.ToString();
            CustomerName.Text = QuotationUtils.customersearchID;
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
            label3.Text = "Add New Supplier";
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
                CustomerSearchGrid.Focus();

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
                ____frmSupplierMain form = new ____frmSupplierMain(true);
                form.ShowDialog();
            }

        }

        private void FormQuaotationCustomerSearch_Load(object sender, EventArgs e)
        {
            //#region AutoCompleteCustomSource ID
            //CustomerCode.Focus();
            //AutoCompleteStringCollection autoID = new AutoCompleteStringCollection();
            //SqlConnection connID = new Utils().ImeSqlConnection();
            //try
            //{
            //    foreach (DataRow row in sqlHelper.GetQueryResult("Select ID from[Customer]").Rows)
            //    {
            //        autoID.Add(row[0].ToString());
            //    }

            //    CustomerCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    CustomerCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    CustomerCode.AutoCompleteCustomSource = autoID;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Database Connection Error. \n\nError Message: " + ex.ToString(), "Error");
            //}
            //finally
            //{
            //    connID.Close();
            //}


            //#endregion

            //#region AutoCompleteCustomSource Name
            //CustomerName.Focus();
            //AutoCompleteStringCollection autoName = new AutoCompleteStringCollection();
            //SqlConnection connName = new Utils().ImeSqlConnection();
            //try
            //{
            //    foreach (DataRow row in sqlHelper.GetQueryResult("Select c_name from[Customer]").Rows)
            //    {
            //        autoName.Add(row[0].ToString());
            //    }

            //    CustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    CustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    CustomerName.AutoCompleteCustomSource = autoName;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Database Connection Error. \n\nError Message: " + ex.ToString(), "Error");
            //}
            //finally
            //{
            //    connName.Close();
            //}


            //#endregion

            if (this.Text == "Customer Search")
            {
                CustomerSearchGrid.DataSource = IME.CustomerAll().OrderByDescending(x=> x.CreateDate).ToList(); ;
            }
            if (this.Text == "Supplier Search")
            {
                CustomerSearchGrid.DataSource = IME.Suppliers.ToList();
            }
            if (this.Text == "Account Search")
            {
                CustomerSearchGrid.DataSource = IME.Accounts.ToList();
            }
            if (this.Text == "Current Search")
            {
                CustomerSearchGrid.DataSource = IME.Currents.ToList();
            }
        }

        private void CustomerName_TextChanged(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            FormQuotationAdd quotationForm = new FormQuotationAdd(this, "", "");
            Utils.LogKayit("Quotation", "Quotation new screen has been entered");
            quotationForm.Show();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (button2.Visible == false && sayac != 1)
            {

                DialogResult close = new DialogResult();
                close = MessageBox.Show("Are you sure you want to close?", "Closing", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (close == DialogResult.OK)
                {
                    e.Cancel = false;
                }
                else if (close == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }


                //base.OnFormClosing(e);

                //if (e.CloseReason == CloseReason.WindowsShutDown) return;
                //this.Close();
                //Confirm user wants to close
                //switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
                //{
                //    case DialogResult.No:
                //        e.Cancel = true;
                //        break;
                //    case DialogResult.Yes:
                //        //e.Cancel = true;
                //        this.Close();
                //        e.Cancel = false;
                //        break;
                //    default:
                //        break;
                //}
            }
        }

        private void CustomerSearchGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerSearchGrid.ClearSelection();
            string customerName = "";
            string customerID = "";

            #region Customer Search
            if (this.Text == "Customer Search")
            {
                string cID = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();

                if (cID != null && cID != "")
                {
                    if (parent == null)
                    {
                        customer = IME.Customers.Where(a => a.ID == cID).FirstOrDefault();
                        customerName = customer.c_name;
                        customerID = customer.ID;
                        CustomerCode.Text = customerID;
                        CustomerName.Text = customerName;
                        //QuotationUtils.customerID = CustomerCode.Text;
                        //QuotationUtils.customername = CustomerName.Text;

                        this.DialogResult = DialogResult.OK;
                        this.Close();

                        FormQuotationAdd frm = new FormQuotationAdd(customerID);
                        Utils.LogKayit("Quotation", "Quotation new screen has been entered");
                        frm.ShowDialog();
                    }
                    else
                    {
                        customer = IME.Customers.Where(a => a.ID == cID).FirstOrDefault();
                        customerName = customer.c_name;
                        customerID = customer.ID;
                        CustomerCode.Text = customerID;
                        CustomerName.Text = customerName;
                        //QuotationUtils.customerID = CustomerCode.Text;
                        //QuotationUtils.customername = CustomerName.Text;

                        this.DialogResult = DialogResult.OK;
                        this.Close();

                        parent.FillCustomerFromSearch(customerName, customerID);
                        //this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please select customer");
                }


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

                #region Eski
                //#region Customer Search
                //if (this.Text == "Customer Search")
                //{
                //    CustomerSearchGrid.ClearSelection();
                //    string cID = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();
                //    customer = IME.Customers.Where(a => a.ID == cID).FirstOrDefault();
                //    CustomerCode.Text = customer.ID;
                //    CustomerName.Text = customer.c_name;
                //    QuotationUtils.customerID = CustomerCode.Text;
                //    QuotationUtils.customername = CustomerName.Text;

                //    this.DialogResult = DialogResult.OK;
                //    this.Close();
                //}
                //#endregion

                //#region Supplier Search
                //if (this.Text == "Supplier Search")
                //{
                //    CustomerSearchGrid.ClearSelection();
                //    string cID = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();
                //    supplier = IME.Suppliers.Where(a => a.ID == cID).FirstOrDefault();
                //    CustomerCode.Text = supplier.ID;
                //    CustomerName.Text = supplier.s_name;
                //    classSupplier.supplierID = CustomerCode.Text;
                //    classSupplier.suppliername = CustomerName.Text;

                //    this.DialogResult = DialogResult.OK;
                //    this.Close();
                //}
                //#endregion

                //#region Account Search
                //if (this.Text == "Account Search")
                //{
                //    CustomerSearchGrid.ClearSelection();
                //    int cID = Convert.ToInt32(CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString());
                //    account = IME.Accounts.Where(a => a.ID == cID).FirstOrDefault();
                //    CustomerCode.Text = account.ID.ToString();
                //    CustomerName.Text = account.Name;
                //    classAccount.accountID = CustomerCode.Text;
                //    QuotationUtils.customername = CustomerName.Text;

                //    this.DialogResult = DialogResult.OK;
                //    this.Close();
                //}
                //#endregion

                //#region Current Search
                //if (this.Text == "Current Search")
                //{
                //    CustomerSearchGrid.ClearSelection();
                //    int cID = Convert.ToInt32(CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString());
                //    current = IME.Currents.Where(a => a.CurrentID == cID).FirstOrDefault();
                //    CustomerCode.Text = current.CurrentID.ToString();
                //    CustomerName.Text = current.Name;
                //    //classCurrent.currentID = CustomerCode.Text;
                //    //classCurrent.currentname = CustomerName.Text;

                //    this.DialogResult = DialogResult.OK;
                //    this.Close();
                //}
                //#endregion
                #endregion


                CustomerSearchGrid.ClearSelection();
                string customerName = "";
                string customerID = "";

                #region Customer Search
                if (this.Text == "Customer Search")
                {
                    string cID = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();

                    if (cID != null && cID != "")
                    {
                        if (parent == null)
                        {
                            customer = IME.Customers.Where(a => a.ID == cID).FirstOrDefault();
                            customerName = customer.c_name;
                            customerID = customer.ID;
                            //QuotationUtils.customerID = CustomerCode.Text;
                            //QuotationUtils.customername = CustomerName.Text;

                            this.DialogResult = DialogResult.OK;
                            this.Close();

                            FormQuotationAdd quotationForm = new FormQuotationAdd(this, customerName, customerID);
                            Utils.LogKayit("Quotation", "Quotation new screen has been entered");
                            quotationForm.Show();
                        }
                        else
                        {
                            customer = IME.Customers.Where(a => a.ID == cID).FirstOrDefault();
                            customerName = customer.c_name;
                            customerID = customer.ID;
                            //QuotationUtils.customerID = CustomerCode.Text;
                            //QuotationUtils.customername = CustomerName.Text;

                            this.DialogResult = DialogResult.OK;
                            this.Close();

                            parent.FillCustomerFromSearch(customerName, customerID);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select customer");
                    }


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
        }

        private void CustomerSearchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //CustomerCode.Text = CustomerSearchGrid.CurrentRow.Cells["ID"].Value.ToString();
            //CustomerName.Text = CustomerSearchGrid.CurrentRow.Cells["c_name"].Value.ToString();
        }
    }
}
