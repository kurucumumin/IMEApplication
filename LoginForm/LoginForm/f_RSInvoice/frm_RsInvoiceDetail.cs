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
    public partial class frm_RsInvoiceDetail : Form
    {
        int InvoiceID;

        public frm_RsInvoiceDetail(int InvoiceID)
        {
            InitializeComponent();
            this.InvoiceID = InvoiceID;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgRsInvoiceItems, new object[] { true });
        }

        private void frm_RsInvoiceDetail_Load(object sender, EventArgs e)
        {
            dgRsInvoiceItems.DataSource = new Sp_RSInvoice().GetRSInvoiceDetailWithID(InvoiceID);
            dgRsInvoiceItems.ClearSelection();
            dgRsInvoiceItems.Focus();
        }
    }
}
