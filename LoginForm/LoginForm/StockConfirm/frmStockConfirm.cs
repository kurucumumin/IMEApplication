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

namespace LoginForm.StockConfirm
{
    public partial class frmStockConfirm : MyForm
    {
        public frmStockConfirm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Close", "Are you sure to close this page", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dg.Rows)
            {
                if(item.Cells[ProductID.Index].Value!=null && (bool)item.Cells[chkBox.Index].Value== true)
                {
                    int intStockReserveID = Int32.Parse(item.Cells[StockReserveID.Index].Value.ToString());
                    IMEEntities IME = new IMEEntities();
                    var sr = IME.StockReserves.Where(a => a.ReserveID == intStockReserveID).FirstOrDefault();
                    
                    sr.NotConfirmedQ = 0;
                    sr.Qty = Int32.Parse(item.Cells[Qty.Index].Value.ToString());
                    int srQty = sr.Qty;
                    //IME.StockReserves.Remove(sr);
                    IME.SaveChanges();
                    int stockID= Int32.Parse(item.Cells[StockID.Index].Value.ToString());
                    var Stock = IME.Stocks.Where(a => a.StockID ==stockID).FirstOrDefault();
                    Stock.NotConfirmedQTY = 0;
                    Stock.Qty = Stock.Qty + srQty;
                    Stock.ReserveQty=Stock.ReserveQty+ srQty;
                    IME.SaveChanges();
                }
            }
        }

        private void frmStockConfirm_Load(object sender, EventArgs e)
        {
            dgLoad();
        }
        #region Functions
        public void dgLoad()
        {
            IMEEntities IME = new IMEEntities();
            foreach (var item in IME.StockSearchforConfirm())
            {
                DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
                row.Cells[CustomerID.Index].Value = item.CustomerID;
                row.Cells[ReserveID.Index].Value = item.ReserveID;
                row.Cells[ProductID.Index].Value = item.ProductID;
                row.Cells[StockReserveID.Index].Value = item.ReserveID;
                row.Cells[Qty.Index].Value = item.Qty;
                row.Cells[CustomerName.Index].Value = item.c_name;
                row.Cells[SaleOrderID.Index].Value = item.SaleOrderID;
                dg.Rows.Add(row);
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dg.Rows)
            {
                if (item.Cells[ProductID.Index].Value != null)
                {
                    if ((!item.Cells[ProductID.Index].Value.ToString().Contains(txtSearch.Text)))
                    {
                        item.Visible = false;
                    }
                    else
                    {
                        item.Visible = true;
                    }
                }
            }
        }
    }
}
