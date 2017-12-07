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

namespace LoginForm.PurchaseOrder
{
    public partial class frmStock : Form
    {
        #region Definitions
        IMEEntities IME = new IMEEntities();
        int stockcode;
        #endregion


        public frmStock()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text=="Save")
            {
                Stock stock = new Stock
                {
                    ItemCode = txtProductCode.Text,
                    date = dtpDate.Value,
                    Quantitiy=Int32.Parse(txtQuantity.Text)
                };
                IME.Stocks.Add(stock);
                IME.SaveChanges();
            }
            else
            {
                var stock = IME.Stocks.Where(a => a.StockID == stockcode).FirstOrDefault();
                stock.ItemCode = txtProductCode.Text;
                stock.date = dtpDate.Value;
                stock.Quantitiy = Int32.Parse(txtQuantity.Text);
                IME.SaveChanges();
            }
        }

        private void frmStock_DoubleClick(object sender, EventArgs e)
        {
            stockcode = Int32.Parse(dgStock.CurrentRow.Cells["StockID"].Value.ToString());
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            dgStock.DataSource = IME.Stocks.ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgStock.DataSource = IME.Stocks.Where(a => a.ItemCode == ProductCodeSearch.Text).Where(b => b.date == DateSearch.Value).ToList();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductCode.Text = string.Empty;
            dtpDate.Value = DateTime.Today;
            txtQuantity.Text = string.Empty;
        }

        private void dgStock_DoubleClick(object sender, EventArgs e)
        {
            
        }
    }
}
