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
using LoginForm.Item;
using LoginForm.QuotationModule;

namespace LoginForm.StockManagement
{
    public partial class frmStock : Form
    {
        #region Parameters
        public string _ProductID;
        public string _ProductName;

        #endregion

        #region Methods

        public void UpdateStockGrid()
        {
            dgStockList.DataSource = new IMEEntities().Stocks.ToList();
        }

        private void ClearInputs()
        {
            dgStockList.ClearSelection();

            txtProductID.Clear();
            txtProductID.Enabled = true;

            txtProductName.Clear();
            numQuantity.Value = 0;
            rbIncrease.Checked = false;
            rbIncrease.Enabled = false;
            rbDecrease.Checked = false;
            rbDecrease.Enabled = false;
            btnViewStockReserves.Enabled = false;
        }

        private bool CheckForEmptyInput()
        {
            List<string> nullAreaList = new List<string>();

            if (txtProductID.Text == String.Empty)
            {
                nullAreaList.Add("Product ID is Empty!");
            }
            if (numQuantity.Value == 0)
            {
                nullAreaList.Add("Quantity must be greater than 0!");
            }

            if (rbIncrease.Enabled && rbDecrease.Enabled)
            {
                if (!rbIncrease.Checked && !rbDecrease.Checked)
                {
                    nullAreaList.Add("Quantity method is Empty!");
                }
            }
            else if (rbIncrease.Enabled && !rbDecrease.Enabled)
            {
                if (!rbIncrease.Checked)
                {
                    nullAreaList.Add("Quantity method is Empty!");
                }
            }

            System.Text.StringBuilder errorString = new System.Text.StringBuilder();
            for (int i = 0; i < nullAreaList.Count; i++)
            {
                errorString.Append(nullAreaList[i]);
                if (i != nullAreaList.Count - 1)
                {
                    errorString.Append("\n");
                }
            }

            string errorMessage = errorString.ToString();

            if (nullAreaList.Count != 0)
            {
                MessageBox.Show(errorMessage, "Null Data");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void UpdateExistingStock(decimal StockID, int quantity, string countMethod)
        {
            IMEEntities db = new IMEEntities();

            Stock s = db.Stocks.Where(x => x.StockID == StockID).FirstOrDefault();

            if (countMethod.Equals("increase"))
            {
                s.Qty += quantity;
                db.SaveChanges();
                UpdateStockGrid();
                MessageBox.Show("Stock increased!", "Success");
            }
            else
            {
                if (s.Qty < quantity)
                {
                    MessageBox.Show("Decrease quantity cannot be lower than stock quantity", "Error");
                }
                else
                {
                    s.Qty -= quantity;
                    db.SaveChanges();
                    UpdateStockGrid();
                }
            }
        }

        private object CheckExistingStockForItem(IMEEntities db)
        {
            return db.Stocks.Where(x => x.ProductID == txtProductID.Text).FirstOrDefault();
        }

        #endregion

        #region Events

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckForEmptyInput())
            {
                if (dgStockList.SelectedRows.Count > 0)
                {
                    decimal sID = Convert.ToDecimal(dgStockList.CurrentRow.Cells[dgStockID.Index].Value);
                    int quantity = Convert.ToInt32(numQuantity.Text);
                    string countMethod = (rbIncrease.Checked) ? "increase" : "decrease";
                    UpdateExistingStock(sID, quantity, countMethod);
                }
                else
                {
                    IMEEntities db = new IMEEntities();
                    Stock s;
                    var productOnStock = CheckExistingStockForItem(db);

                    if (productOnStock != null)
                    {
                        s = productOnStock as Stock;
                        System.Text.StringBuilder warningString = new System.Text.StringBuilder();

                        warningString.Append("Item with " + s.ProductID + " Article No is already on stock.\n");
                        warningString.Append("It's quantity will increase by " + Convert.ToInt32(numQuantity.Text) + "\n");
                        warningString.Append("Do you confirm?");

                        if (MessageBox.Show(warningString.ToString(), "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            s.Qty += Convert.ToInt32(numQuantity.Text);
                            db.SaveChanges();
                            UpdateStockGrid();
                            MessageBox.Show("Stock increased!", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Operation Cancelled!");
                        }
                    }
                    else
                    {
                        s = new Stock();
                        s.ProductID = txtProductID.Text;
                        var product = db.V_Product.Where(x => x.productId == s.ProductID).FirstOrDefault();
                        if (product != null)
                        {
                            s.Qty = Convert.ToInt32(numQuantity.Text);
                            s.ProductName = product.productCode;
                            s.MPN = product.MPN;
                            s.Cost = product.Cost;
                            s.ReserveQty = 0;

                            db.Stocks.Add(s);
                            db.SaveChanges();
                            UpdateStockGrid();
                            MessageBox.Show("New stock created!", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Product not found", "Error");
                            txtProductID.Focus();
                        }
                    }
                }

            }
        }

        private void StockDevelopment_Load(object sender, EventArgs e)
        {
            UpdateStockGrid();
            dgStockList.ClearSelection();
        }

        private void dgStockList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgStockList.SelectedRows.Count > 0)
            {
                btnViewStockReserves.Enabled = true;
                txtProductID.Text = dgStockList.CurrentRow.Cells[dgProductID.Index].Value.ToString();
                txtProductID.Enabled = false;
                if (dgStockList.CurrentRow.Cells[dgProductName.Index].Value != null) txtProductName.Text = dgStockList.CurrentRow.Cells[dgProductName.Index].Value.ToString();
                txtProductName.Enabled = false;

                numQuantity.Value = 0;

                if (Convert.ToDecimal(dgStockList.CurrentRow.Cells[dgQty.Index].Value) == 0)
                {
                    rbDecrease.Enabled = false;
                }
                else
                {
                    rbDecrease.Enabled = true;
                }
                rbIncrease.Enabled = true;
            }
            else
            {
                ClearInputs();
            }
        }

        private void btnViewStockReserves_Click(object sender, EventArgs e)
        {
            frmStockReserve form = new frmStockReserve(this, Convert.ToDecimal(dgStockList.CurrentRow.Cells[dgStockID.Index].Value));
            form.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IQueryable<Stock> query = new IMEEntities().Stocks;

            if (!String.IsNullOrEmpty(txt_productID.Text))
            {
                query = query.Where(x => x.ProductID.Contains(txt_productID.Text));
            }
            if (!String.IsNullOrEmpty(txt_ProductDesc.Text))
            {
                query = query.Where(y => y.ProductName.Contains(txt_ProductDesc.Text));
            }

            dgStockList.DataSource = query.ToList();
        }

        private void txt_productID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void txt_ProductDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        #endregion

        public frmStock()
        {
            InitializeComponent();
        }

        private void txtProductID_DoubleClick(object sender, EventArgs e)
        {
            SearchItem();
        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchItem();
            }
        }

        private void SearchItem()
        {
            FormQuotationItemSearch form = new FormQuotationItemSearch(txtProductID.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtProductID.Text = form.itemProps[0];
                txtProductName.Text = form.itemProps[1];
            }
        }

        private void numQuantity_Click(object sender, EventArgs e)
        {
            if (numQuantity.Value == 0)
            {
                numQuantity.Text = "";
            }
            else
            {
                numQuantity.Value = numQuantity.Value;
            }
        }
    }
}
