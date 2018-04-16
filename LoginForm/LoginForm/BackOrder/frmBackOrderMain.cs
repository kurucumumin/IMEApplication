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

namespace LoginForm.BackOrder
{
    public partial class frmBackOrderMain : Form
    {
        public frmBackOrderMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBackOrderLoader form = new frmBackOrderLoader();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateLoaderFunction();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmbackOrderAnalize form = new frmbackOrderAnalize(dtpStartDate.Value, dtpEndDate.Value);
            form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBackOrderMain_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            UpdateLoaderFunction();
        }

        #region Functions
        private void UpdateLoaderFunction()
        {
            IMEEntities IME = new IMEEntities();
            foreach (DataSet.BackOrder item in IME.BackOrders.Where(a=>a.OrderDate<=dtpEndDate.Value ).Where(a=> a.OrderDate >= dtpStartDate.Value))
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
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow item in dg.Rows)
            {
                for (int i = 0; i < item.Cells.Count; i++)
                {
                    DataGridViewCell cell;
                    cell = item.Cells[i];
                    cell.Style.BackColor = Color.White;
                    if (cell.Value!=null && cell.Value.ToString().Contains(txtSearch.Text) )
                    {
                        cell.Style.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dg.Rows)
            {
                for (int i = 0; i < item.Cells.Count; i++)
                {
                    DataGridViewCell cell;
                    cell = item.Cells[i];
                    cell.Style.BackColor = Color.White;
                }
            }
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            int BackOrderDescsID = Int32.Parse(dg.CurrentRow.Cells[ID.Index].Value.ToString());
            //BackOrderDesc bod = IME.BackOrderDescs.Where(a => a.BackOrderID == BackOrderDescsID).FirstOrDefault();
            //txtItemDesc.Text = bod.description;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ExportToItemHistory(dg);
        }

        private void btnAnalize_Click(object sender, EventArgs e)
        {
            frmbackOrderAnalize form = new frmbackOrderAnalize();
            form.Show();
        }
    }
}
