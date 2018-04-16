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
    public partial class frmBackOrderLoader : Form
    {
        public frmBackOrderLoader()
        {
            InitializeComponent();
        }

        private void frmBackOrderLoader_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            List<DataSet.BackOrder>BoList= txtReader.BackOrderRead();
            IMEEntities IME = new IMEEntities();
            foreach (DataSet.BackOrder item in BoList)
            {
                DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();

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

        private void btnsave_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            foreach (DataGridViewRow item in dg.Rows)
            {
                DataGridViewRow row = item;
                if (row.Cells[RSUKReference.Index].Value != null)
                {
                    DataSet.BackOrder bo = new DataSet.BackOrder();
                    bo.RSUKReference = row.Cells[RSUKReference.Index].Value.ToString();
                    bo.SoldToNumber = row.Cells[SoldToNumber.Index].Value.ToString();
                    bo.TradingTitle = row.Cells[TradingTitle.Index].Value.ToString();
                    bo.PurchaseOrderNumber = row.Cells[PurchaseOrderNumber.Index].Value.ToString();
                    bo.OrderDate = DateTime.Parse(row.Cells[OrderDate.Index].Value.ToString());
                    bo.Article = row.Cells[Article.Index].Value.ToString();
                    bo.OutstandingQuantity = row.Cells[OutstandingQuantity.Index].Value.ToString();
                    bo.LineValue = row.Cells[LineValue.Index].Value.ToString();
                    bo.FirstPromisedDate = DateTime.Parse(row.Cells[FirstPromisedDate.Index].Value.ToString());
                    bo.LatestPromisedDate = DateTime.Parse(row.Cells[LatestPromisedDate.Index].Value.ToString());
                    IME.BackOrders.Add(bo);
                    IME.SaveChanges();

                    //BackOrderDesc bod = new BackOrderDesc();
                    //bod.BackOrderID = bo.ID;
                    //bod.description = txtDesc.Text;
                    //IME.BackOrderDescs.Add(bod);
                    //IME.SaveChanges();
                }
            }
            MessageBox.Show("Back Orders are saved successfully");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
