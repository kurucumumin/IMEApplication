using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;


namespace LoginForm
{
    public partial class FormCustomerMain : Form
    {
        DateTime dateNow;
        Worker currentUser = Utils.getCurrentUser();

        public FormCustomerMain()
        {
            IMEEntities IME = new IMEEntities();
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
           dgCustomer, new object[] { true });

            dateNow = Convert.ToDateTime(new IMEEntities().CurrentDate().First());
        }

        private void FormCustomerMain_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
           dgCustomer, new object[] { true });

            checkAuthorities();

            BringQuotationList();
        }

        public void checkAuthorities()
        {
            List<DataSet.AuthorizationValue> authList = Utils.getCurrentUser().AuthorizationValues.ToList();

            if (!Utils.AuthorityCheck(IMEAuthority.CanAddCustomer) && !Utils.AuthorityCheck(IMEAuthority.CanEditCustomer))
            {
                btnNew.Visible = false;
                btnUpdate.Visible = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormCustomerAdd customerForm = new FormCustomerAdd(this);
            Utils.LogKayit("Customer", "Customer new screen has been entered");
            customerForm.Show();
        }

        private void BringQuotationList()
        {
            dgCustomer.Rows.Clear();
            dgCustomer.Refresh();

            IMEEntities IME = new IMEEntities();
            var list = (from c in IME.Customers
                        select new
                        {
                            Date = c.CreateDate,
                            CustomerNo = c.ID,
                            CustomerName = c.c_name,
                            WebAddress = c.webadress,
                            Telephone = c.telephone,
                            Fax = c.fax,
                            Representative = c.CustomerWorker.cw_name,
                            Factor = c.factor,
                            CreditDays = c.creditDay,
                            CustomerNote = c.Note.Note_name
                        }).OrderByDescending(x=> x.Date).Take(100);

            populateGrid(list.ToList());

        }

        private void populateGrid<T>(List<T> queryable)
        {

            dgCustomer.Rows.Clear();
            dgCustomer.Refresh();

            foreach (dynamic item in queryable)
            {
                int rowIndex = dgCustomer.Rows.Add();
                DataGridViewRow row = dgCustomer.Rows[rowIndex];


                row.Cells[Date.Index].Value = item.Date;
                row.Cells[CustomerNo.Index].Value = item.CustomerNo;
                row.Cells[CustomerName.Index].Value = item.CustomerName;
                row.Cells[WebAddress.Index].Value = item.WebAddress;
                row.Cells[Telephone.Index].Value = item.Telephone;
                row.Cells[Fax.Index].Value = item.Fax;
                row.Cells[Representative.Index].Value = item.Representative;
                row.Cells[Factor.Index].Value = item.Factor;
                row.Cells[CreditDays.Index].Value = item.CreditDays;
                row.Cells[CustomerNote.Index].Value = item.CustomerNote;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Utils.LogKayit("Customer", "Customer excel");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CustomerSearch();
        }

        private void CustomerSearch()
        {
            dgCustomer.Rows.Clear();
            dgCustomer.Refresh();

            IMEEntities IME = new IMEEntities();

            if (!String.IsNullOrEmpty(txtSearchText.Text))
            {
                var list = (from c in IME.Customers
                            where c.c_name.Contains(txtSearchText.Text)
                            select new
                            {
                                Date = c.CreateDate,
                                CustomerNo = c.ID,
                                CustomerName = c.c_name,
                                WebAddress = c.webadress,
                                Telephone = c.telephone,
                                Fax = c.fax,
                                Representative = c.CustomerWorker.cw_name,
                                Factor = c.factor,
                                CreditDays = c.creditDay,
                                CustomerNote = c.Note.Note_name
                            });

                populateGrid(list.ToList());
            }
            else
            {
                MessageBox.Show("You should enter a customer name", "Attention!");
            }
        }

        private void dgCustomer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CustomerOpen("View");
        }

        private void CustomerOpen(string mod)
        {
            if (dgCustomer.CurrentRow != null)
            {
                string CustomerNo = dgCustomer.CurrentRow.Cells["CustomerNo"].Value.ToString();
                Customer c;

                IMEEntities IME = new IMEEntities();
                try
                {
                    c = IME.Customers.Where(q => q.ID == CustomerNo).FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }
                if (c != null)
                {
                    if (mod == "View")
                    {
                        FormCustomerAdd newForm = new FormCustomerAdd(c, mod);
                        newForm.ShowDialog();
                    }
                    else
                    {
                        FormCustomerAdd newForm = new FormCustomerAdd(c, mod);
                        newForm.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("You did not chose any customer.", "Warning!");
            }
        }

        private void qUOTATIONINFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerOpen("View");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CustomerOpen("Modify");
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            BringQuotationList();
        }

        private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CustomerSearch();
            }
        }

        private void uPDATEQUOTATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerOpen("Modify");
        }
    }
}
