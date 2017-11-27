using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.PurchaseOrder
{
    public partial class NewPurchaseOrder : Form
    {
        public NewPurchaseOrder()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PurchaseExportFiles form = new PurchaseExportFiles();
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain f = new PurchaseOrderMain();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.ShowDialog();
                this.Close();
            }
        }
    }
}
