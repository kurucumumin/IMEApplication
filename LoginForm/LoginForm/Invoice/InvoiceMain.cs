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
using LoginForm.Services;

namespace LoginForm.Invoice
{
    public partial class InvoiceMain : Form
    {
        IMEEntities IME = new IMEEntities();

        public InvoiceMain()
        {
            InitializeComponent();
        }

        public InvoiceMain(string item_code)
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void InvoiceMain_Load(object sender, EventArgs e)
        {

        }
    }
}
