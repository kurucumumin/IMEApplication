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
    public partial class PurchaseOrderMain : Form
    {
        public PurchaseOrderMain()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            NewPurchaseOrder form = new NewPurchaseOrder();
            form.Show();
            this.Hide();
        }

        private void btnPurchaseOrders_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
