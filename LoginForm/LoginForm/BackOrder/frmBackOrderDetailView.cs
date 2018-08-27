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

namespace LoginForm.BackOrder
{
    public partial class frmBackOrderDetailView : MyForm
    {
        int BackOrderMainID;
        public frmBackOrderDetailView()
        {
            InitializeComponent();
        }

        public frmBackOrderDetailView(int ID)
        {
            InitializeComponent();
            BackOrderMainID = ID;
            UpdateLoaderFunction();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Close", "Are you sure to close this page", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void frmBackOrderDetailView_Load(object sender, EventArgs e)
        {

        }

        private void UpdateLoaderFunction()
        {
            IMEEntities IME = new IMEEntities();
            foreach (DataSet.BackOrder item in IME.BackOrders.Where(a=>a.BackOrderMainID==BackOrderMainID))
            {
                DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
                row.Cells[ID.Index].Value = item.ID;
                row.Cells[LatestPromisedDate.Index].Value = item.LatestPromisedDate;
                row.Cells[Article.Index].Value = item.Article;
                row.Cells[FirstPromisedDate.Index].Value = item.FirstPromisedDate;
                row.Cells[LineValue.Index].Value = item.LineValue;
                row.Cells[OrderDate.Index].Value = item.OrderDate;
                row.Cells[OutstandingQuantity.Index].Value = item.OutstandingQuantity;
                row.Cells[PurchaseOrderNumber.Index].Value = item.PurchaseOrderNumber;
                row.Cells[RSUKReference.Index].Value = item.RSUKReference;
                row.Cells[SoldToNumber.Index].Value = item.SoldToNumber;
                row.Cells[TradingTitle.Index].Value = item.TradingTitle;
                dg.Rows.Add(row);
            }
        }
}
}
