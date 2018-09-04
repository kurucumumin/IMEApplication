using LoginForm.Services.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.f_RSInvoice
{
    public partial class frm_RSInvoice : Form
    {
        public frm_RSInvoice()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgRSInvoice, new object[] { true });
        }

        private void frm_RSInvoice_Load(object sender, EventArgs e)
        {
            dtpToDate.Value = DateTime.Now.Date;
            dtpFromDate.Value = DateTime.Now.AddMonths(-1).Date;

            dgRSInvoice.DataSource = new Sp_RSInvoice().GetRSInvoiceBetweenDates(dtpFromDate.Value.Date,dtpToDate.Value.AddDays(1).Date);
            dgRSInvoice.ClearSelection();
            dgRSInvoice.Focus();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            dgRSInvoice.DataSource = null;
            dgRSInvoice.DataSource = new Sp_RSInvoice().GetRSInvoiceBetweenDates(dtpFromDate.Value.Date, dtpToDate.Value.AddDays(1).Date);
        }

        private void btnModifyQuotation_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgRSInvoice.Rows)
            {
                if (!row.Visible)
                {
                    row.Visible = true;
                }
            }
        }

        private void btnDeleteQuotation_Click(object sender, EventArgs e)
        {
            if (dgRSInvoice.SelectedRows.Count != 0)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgRSInvoice.DataSource];
                currencyManager1.SuspendBinding();
                foreach (DataGridViewRow row in dgRSInvoice.SelectedRows)
                {
                    row.Visible = false;
                }
                currencyManager1.ResumeBinding();
            }
        }
    }
}
