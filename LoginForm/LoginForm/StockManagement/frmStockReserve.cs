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
using LoginForm.ItemModule;
using LoginForm.QuotationModule;

namespace LoginForm.StockManagement
{
    public partial class frmStockReserve : Form
    {
        //Cem GEnar
        #region Parameters

        frmStock parent;

        public Stock _Stock;
        public string _ProductName;
        private Customer _customer;

        #endregion

        #region Methods

        private void UpdateStockReserveGrid()
        {
            IMEEntities db = new IMEEntities();
            List<StockReserve> reserveList = null;
            if(_Stock != null)
            {
                reserveList = db.StockReserves.Where(x => x.StockID == _Stock.StockID).ToList();
            }
            else
            {
                reserveList = db.StockReserves.ToList();
            }

            ItemToStockReserveGrid(reserveList);

            if (reserveList.Count != 0)
            {
                if(_Stock.StockReserves.Where(x=>x.CustomerID == null).Count() <= 0)
                {
                    rbIncrease.Enabled = false;
                    rbDecrease.Enabled = false;
                }
                else
                {
                    rbIncrease.Enabled = true;
                    rbDecrease.Enabled = true;
                }
                btnDelete.Enabled = true;
            }
            else
            {
                rbIncrease.Enabled = false;
                rbDecrease.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void ClearInputs()
        {
            dgStockReserveList.ClearSelection();

            txtProductID.Clear();
            txtProductID.Enabled = true;

            txtProductName.Clear();
            numQuantity.Value = 0;
            rbIncrease.Checked = false;
            rbIncrease.Enabled = false;
            rbDecrease.Checked = false;
            rbDecrease.Enabled = false;
        }

        private bool CheckForEmptyInput()
        {
            List<string> emptyAreaList = new List<string>();






            //if (txtProductID.Text == String.Empty)
            //{
            //    emptyAreaList.Add("Product ID is Empty!");
            //}
            //if (numQuantity.Value == 0)
            //{
            //    emptyAreaList.Add("Quantity must be greater than 0!");
            //}

            //if (rbIncrease.Enabled && rbDecrease.Enabled)
            //{
            //    if (!rbIncrease.Checked && !rbDecrease.Checked)
            //    {
            //        emptyAreaList.Add("Quantity method is Empty!");
            //    }
            //}









            //else if (rbIncrease.Enabled && !rbDecrease.Enabled)
            //{
            //    if (!rbIncrease.Checked)
            //    {
            //        nullAreaList.Add("Quantity method is Empty!");
            //    }
            //}

            System.Text.StringBuilder errorString = new System.Text.StringBuilder();
            for (int i = 0; i < emptyAreaList.Count; i++)
            {
                errorString.Append(emptyAreaList[i]);
                if (i != emptyAreaList.Count - 1)
                {
                    errorString.Append("\n");
                }
            }

            string errorMessage = errorString.ToString();

            if (emptyAreaList.Count != 0)
            {
                MessageBox.Show(errorMessage, "Null Data");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void UpdateExistingStock()
        {
            //IMEEntities db = new IMEEntities();

            //decimal sID = Convert.ToDecimal(dgStockReserveList.CurrentRow.Cells[dgStockID.Index].Value);
            //int quantity = Convert.ToInt32(numQuantity.Text);

            //Stock s = db.Stocks.Where(x => x.StockID == sID).FirstOrDefault();

            //if (rbIncrease.Checked)
            //{
            //    s.Qty += quantity;
            //    db.SaveChanges();
            //    UpdateStockGrid();
            //    MessageBox.Show("Stock increased!", "Success");
            //}
            //else
            //{
            //    if (s.Qty < quantity)
            //    {
            //        MessageBox.Show("Decrease quantity cannot be lower than stock quantity", "Error");
            //    }
            //    else
            //    {
            //        s.Qty -= quantity;
            //        db.SaveChanges();
            //        UpdateStockGrid();
            //    }
            //}
        }

        //private object CheckExistingStockForItem(IMEEntities db)
        //{
        //    return db.StockReserves.Where(x => x.ProductID == txtProductID.Text).FirstOrDefault();
        //}

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
                if (_Stock != null)
                {
                    IMEEntities db = new IMEEntities();

                    _Stock = db.Stocks.Where(x => x.StockID == _Stock.StockID).FirstOrDefault();

                    if (_Stock.ReserveQty + Convert.ToInt32(numQuantity.Value) <= _Stock.Qty)
                    {
                        StockReserve existingReserve = _Stock.StockReserves.Where(x => x.CustomerID == null).FirstOrDefault();

                        if (existingReserve == null)
                        {
                            existingReserve = new StockReserve();
                            existingReserve.StockID = _Stock.StockID;
                            existingReserve.ProductID = _Stock.ProductID;
                            existingReserve.Qty = Convert.ToInt32(numQuantity.Value);

                            db.StockReserves.Add(existingReserve);
                        }
                        else
                        {
                            existingReserve.Qty += Convert.ToInt32(numQuantity.Value);
                        }

                        _Stock.ReserveQty += Convert.ToInt32(numQuantity.Value);
                        db.SaveChanges();
                    }
                    parent.UpdateStockGrid();
                    dgStockReserveList.Rows.Clear();
                    dgStockReserveList.Refresh();
                    ItemToStockReserveGrid(db.StockReserves.Where(x => x.StockID == _Stock.StockID).ToList());
                }
                else
                {

                }
                
                
                //if (dgStockReserveList.SelectedRows.Count > 0)
                //{
                //    UpdateExistingStock();
                //}
                //else
                //{
                //    IMEEntities db = new IMEEntities();
                //    Stock s;
                //    var productOnStock = CheckExistingStockForItem(db);

                //    if (productOnStock != null)
                //    {
                //        s = productOnStock as Stock;
                //        System.Text.StringBuilder warningString = new System.Text.StringBuilder();

                //        warningString.Append("Item with " + s.ProductID + " Article No is already on stock.\n");
                //        warningString.Append("It's quantity will increase by " + Convert.ToInt32(numQuantity.Text) + "\n");
                //        warningString.Append("Do you confirm?");

                //        if (MessageBox.Show(warningString.ToString(), "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //        {
                //            s.Qty += Convert.ToInt32(numQuantity.Text);
                //            db.SaveChanges();
                //            UpdateStockGrid();
                //            MessageBox.Show("Stock increased!", "Success");
                //        }
                //        else
                //        {
                //            MessageBox.Show("Operation Cancelled!");
                //        }
                //    }
                //    else
                //    {
                //        s = new Stock();
                //        s.ProductID = txtProductID.Text;
                //        var product = db.V_Product.Where(x => x.productId == s.ProductID).FirstOrDefault();
                //        if (product != null)
                //        {
                //            s.Qty = Convert.ToInt32(numQuantity.Text);
                //            s.ProductName = product.productCode;
                //            s.ReserveQty = 0;

                //            db.Stocks.Add(s);
                //            db.SaveChanges();
                //            UpdateStockGrid();
                //            MessageBox.Show("New stock created!", "Success");
                //        }
                //        else
                //        {
                //            MessageBox.Show("Product not found", "Error");
                //            txtProductID.Focus();
                //        }
                //    }
                //}

            }
        }

        private void StockDevelopment_Load(object sender, EventArgs e)
        {
            txtProductID.Text = _Stock.ProductID;
            txtProductName.Text = _Stock.ProductName;

            UpdateStockReserveGrid();
            dgStockReserveList.ClearSelection();
        }

        private void dgStockList_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        #endregion
        
        public frmStockReserve()
        {
            InitializeComponent();
        }       

        public frmStockReserve(frmStock parent, decimal StockID)
        {
            InitializeComponent();
            this.parent = parent;
            _Stock = new IMEEntities().Stocks.Where(x => x.StockID == StockID).FirstOrDefault(); ;
        }

        private void ItemToStockReserveGrid(List<StockReserve> stockList)
        {
            IMEEntities db = new IMEEntities();
            foreach (StockReserve item in stockList)
            {
                int rowI = dgStockReserveList.Rows.Add();

                DataGridViewRow row = dgStockReserveList.Rows[rowI];

                row.Cells[dgStockID.Index].Value = item.StockID;
                row.Cells[dgSaleOrderID.Index].Value = item.SaleOrderID;
                row.Cells[dgCustomerName.Index].Value = item.SaleOrder.Customer.c_name;
                row.Cells[dgValidationDate.Index].Value = item.ValidationDate;
                row.Cells[dgProductID.Index].Value = item.ProductID;
                row.Cells[dgProductName.Index].Value = db.V_Product.Where(x => x.productId == item.ProductID).FirstOrDefault().productCode;
                row.Cells[dgQty.Index].Value = item.Qty;
            }
        }
        
        public void CustomerSearchInput()
        {
            QuotationUtils.customersearchID = txtCustomerID.Text;
            QuotationUtils.customersearchname = "";
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                _customer = form.customer;
            }
            this.Enabled = true;
            fillCustomer();
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CustomerSearchInput();
            }
        }
        private void fillCustomer()
        {
            txtCustomerID.Text = _customer.ID;
            txtCustomerName.Text = _customer.c_name;
        }

        private void txtCustomerID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CustomerSearchInput();
        }
    }
}
