using LoginForm.DataSet;
using LoginForm.Model;
using LoginForm.QuotationModule;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LoginForm.BackOrder
{
    public partial class frmBackOrderLoader : MyForm
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
            if (dg.Rows[0].Cells[RSUKReference.Index].Value != null)
            {
                BackOrderMain bom = new BackOrderMain();
                bom.Date = DateTime.Now;
                bom.description = txtDesc.Text;
                if (Utils.getCurrentUser() != null)
                { bom.userID = Utils.getCurrentUser().WorkerID; }
                IME.BackOrderMains.Add(bom);
                int BackOrderMainsID = bom.ID;
                IME.SaveChanges();
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
                        bo.BackOrderMainID = bom.ID;
                        IME.BackOrders.Add(bo);
                        IME.SaveChanges();


                    }
                }
                MessageBox.Show("Back Orders are saved successfully");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
