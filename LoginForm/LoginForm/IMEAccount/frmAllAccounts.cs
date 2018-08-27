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
    public partial class frmAllAccounts : MyForm
    {
        public frmAllAccounts()
        {
            InitializeComponent();
        }

        private void frmAllAccounts_Load(object sender, EventArgs e)
        {
            getAllAccounts();
        }
        private void getAllAccounts()
        {
            IMEEntities IME = new IMEEntities();
            foreach (var item in IME.Accounts.ToList())
            {
                DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
                row.Cells[ID.Index].Value = item.ID;
                //row.Cells[Name.Index].Value = item.Name;
                row.Cells[Currency.Index].Value = item.Currency.currencyName;
                row.Cells[Description.Index].Value = item.Description;
                row.Cells[IsActive.Index].Value = item.IsActive;
                row.Cells[Number.Index].Value = item.Number;
                row.Cells[Value.Index].Value = item.Value.ToString();
                dg.Rows.Add(row);
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

        private void AddAccount_Click(object sender, EventArgs e)
        {
            frmAccount form = new frmAccount("New");
            form.Show();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            if (dg.CurrentRow != null)
            {
                frmAccount form = new frmAccount(Int32.Parse(dg.CurrentRow.Cells[ID.Index].Value.ToString()));
                form.Show();
            }
        }
    }
}
