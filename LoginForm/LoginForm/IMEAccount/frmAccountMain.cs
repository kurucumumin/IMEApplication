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

namespace LoginForm.IMEAccount
{
    public partial class frmAccountMain : MyForm
    {
        public frmAccountMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBillToCustomer form = new frmBillToCustomer("");
            form.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                if (dg.CurrentRow.Cells[ID.Index].Value!=null)
                {
                    frmBillToCustomer form = new frmBillToCustomer(Int32.Parse(dg.CurrentRow.Cells[ID.Index].Value.ToString()));
                }
                //form.Show();
            }
            catch
            {
                MessageBox.Show("Please Select a Bill");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Close", "Are you sure to close this page", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmAccountMain_Load(object sender, EventArgs e)
        {
            dgLoad();
        }
        #region Function
        private void dgLoad()
        {
            IMEEntities IME = new IMEEntities();
            //foreach (var item in IME.AccountMainDataGridFiller())
            //{
            //    DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
            //    row.Cells[Amount.Index].Value = item.Amount;
            //    row.Cells[Currency.Index].Value = item.Currency;
            //    row.Cells[CustomerName.Index].Value = item.Customer;
            //    row.Cells[Desc.Index].Value = item.Description;
            //    row.Cells[ID.Index].Value = item.ID;
            //    row.Cells[Representative.Index].Value = item.Representative;
            //    row.Cells[Supplier.Index].Value = item.Supplier;
            //    row.Cells[IsSaleoperation.Index].Value = item.IsSalesOperations;
            //    dg.Rows.Add(row);
            //}

            dgCurrenetAccountMovements.DataSource = IME.CariHarekets.ToList();

        }
        #endregion

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            if (dg.CurrentRow!=null)
            {
                frmAccount form = new frmAccount(Int32.Parse(dg.CurrentRow.Cells[ID.Index].Value.ToString()));
                form.Show();
            }
        }

        private void AddAccount_Click(object sender, EventArgs e)
        {
            frmAccount form = new frmAccount("New");
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBillFromSupplier form = new frmBillFromSupplier();
            form.Show();
        }

        private void btnAllAccounts_Click(object sender, EventArgs e)
        {
            frmAllAccounts form = new frmAllAccounts();
            form.Show();
        }

        private void btnCustomersDebits_Click(object sender, EventArgs e)
        {
            frmCustomersDebits form = new frmCustomersDebits();
            form.Show();
        }

        private void btnUpdateFromCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg.CurrentRow.Cells[ID.Index].Value == null)
                {
                    frmBillFromSupplier form = new frmBillFromSupplier(Int32.Parse(dg.CurrentRow.Cells[ID.Index].Value.ToString()));
                }
                //form.Show();
            }
            catch
            {
                MessageBox.Show("Please Select a Bill");
            }
        }

        private void btnAddVoucher_Click(object sender, EventArgs e)
        {
            frmVoucherOperation form = new frmVoucherOperation();
            form.Show();
            this.Close();
        }
    }
}
