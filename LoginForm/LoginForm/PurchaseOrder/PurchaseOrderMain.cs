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

namespace LoginForm.PurchaseOrder
{
    public partial class PurchaseOrderMain : Form
    {
        IMEEntities IME = new IMEEntities();

        public PurchaseOrderMain()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewPurchaseOrder form = new NewPurchaseOrder();
            form.ShowDialog();
            this.Show();
        }

        private void btnPurchaseOrders_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
            }
        }

        private void PurchaseOrderMain_Load(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            dgPurchase.DataSource = IME.PurchaseOrders.ToList();
        }

        private void PurchaseOrderFill()
        {
            IME = new IMEEntities();
            #region PurchaseOrderFill
            //var adapter = (from p in IME.PurchaseOrderDetails
            //               select new
            //               {
            //                   p.PurchaseOrderID,
            //                   p.PurchaseOrderDate,
            //                   p.
            //               }.ToString();
            #endregion

        }
    }
}
