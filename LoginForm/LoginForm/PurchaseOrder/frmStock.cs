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
        string itemcode;
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
                    Quantitiy=Int32.Parse(txtQuantity.Text)
                };
                IME.Stocks.Add(stock);
                IME.SaveChanges();
            }
            else
            {
                var stock = IME.Stocks.Where(a => a.StockID == stockcode).FirstOrDefault();
                stock.ItemCode = txtProductCode.Text;
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
            if (ProductCodeSearch.Text == itemcode)
            {
                dgStock.DataSource = IME.Stocks.Where(a => a.ItemCode == itemcode).ToList();
            }
            else
            {
                dgStock.DataSource = IME.Stocks.Where(a => a.ItemCode == ProductCodeSearch.Text).ToList();
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductCode.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }


        public frmStock(string voucherSearcheCode)
        {
            InitializeComponent();

            itemcode = voucherSearcheCode;
            ProductCodeSearch.Text = itemcode;
        }
    }
}
