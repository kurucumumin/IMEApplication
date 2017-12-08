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
        string ficheNumber;

        public PurchaseOrderMain()
        {
            InitializeComponent();
        }

        public PurchaseOrderMain(string ficheNo)
        {
            InitializeComponent();
            ficheNumber = ficheNo;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewPurchaseOrder form = new NewPurchaseOrder();
            form.ShowDialog();
            this.Show();
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
            PurchaseOrderFill();
        }

        private void PurchaseOrderFill()
        {
            IME = new IMEEntities();
            #region PurchaseOrderFill
            var adapter = (from p in IME.PurchaseOrders
                           select new
                           {
                               p.FicheNo,
                               p.PurchaseOrderDate,
                               p.CustomerID,
                               p.Customer.c_name,
                               p.CameDate,
                               p.Reason
                           }).ToList();
            #endregion
            dgPurchase.DataSource = adapter;
            dgPurchase.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgPurchase.Columns[0].HeaderText = "Fiche No";
            dgPurchase.Columns[1].HeaderText = "Date";
            dgPurchase.Columns[2].HeaderText = "Customer Code";
            dgPurchase.Columns[3].HeaderText = "Customer Title";
            dgPurchase.Columns[4].HeaderText = "Came Date";
            dgPurchase.Columns[5].HeaderText = "Reason";
        }
    }
}
