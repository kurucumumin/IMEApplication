using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Services;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class frmPurchaseInvoiceLoader : Form
    {
        IMEEntities IME = new IMEEntities();
        public frmPurchaseInvoiceLoader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtReader.PurchaseInvoicetxtReader();
        }

        private void frmPurchaseInvoiceLoader_Load(object sender, EventArgs e)
        {
            PurchaseInvoiceItemList.DataSource = IME.PurchaseInvoices.ToList();
        }
    }
}
