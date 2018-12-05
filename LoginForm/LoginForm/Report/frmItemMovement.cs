using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;
using LoginForm.DataSet;
using System.Globalization;

namespace LoginForm
{
    public partial class frmItemMovement : Form
    {
        IMEEntities IME = new IMEEntities();
        string txtSelected = "";

        public frmItemMovement()
        {
            InitializeComponent();

            dgItem.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;
            dgMovement.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgItem, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgMovement, new object[] { true });

            var gridAdapterPC = (from a in IME.Items
                                 select new
                                 {
                                     ArticleNo = a.ArticleNo,
                                     ArticleDesc = a.ArticleDesc
                                 }
                        ).Take(100).ToList();

            populateGridItem(gridAdapterPC.ToList());
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ReportQuotvsSale(dgMovement);
            Utils.LogKayit("ItemMovement Report", "Item Movement Report excel");
        }

        private void btnItemFind_Click(object sender, EventArgs e)
        {
            if (txtItem.Text == "")
            {
                MessageBox.Show("Please enter product code");
            }
            else
            {
                itemSelect();
                dgItem.Select();
            }
        }

        private void itemSelect()
        {
            #region itemssearch
            txtSelected = txtItem.Text;
            #region Itemcode Format
            if (txtSelected.ToString().Contains("-")) { txtSelected = txtSelected.ToString().Replace("-", string.Empty).ToString(); }
            if (txtSelected != null && txtSelected.ToString().Length == 6 || (txtSelected.ToString().Contains("P") && txtSelected.ToString().Length == 7)) { txtSelected = 0.ToString() + txtSelected.ToString(); }
            //0100-124 => 0100124
            #endregion

            var gridAdapterPC = (from a in IME.Items.Where(a => a.ArticleNo.Contains(txtSelected))
                                 select new
                                 {
                                     ArticleNo = a.ArticleNo,
                                     ArticleDesc = a.ArticleDesc
                                 }
                        ).ToList();

            #endregion

            populateGridItem(gridAdapterPC.ToList());

        }

        private void populateGridItem<T>(List<T> queryable)
        {   
            dgItem.Rows.Clear();
            dgItem.Refresh();
            foreach (dynamic item in queryable)
            {
                int rowIndex = dgItem.Rows.Add();
                DataGridViewRow row = dgItem.Rows[rowIndex];

                row.Cells[Code.Index].Value = item.ArticleNo;
                row.Cells[ArticleName.Index].Value = item.ArticleDesc;

            }

            if (dgItem.RowCount == 1)
            {
                MessageBox.Show("There is no such a data");
            }
        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtItem.Text == "")
                {
                    MessageBox.Show("Please enter product code");
                }
                else
                {
                    itemSelect();
                    dgItem.Select();
                }
            }
        }

        private void btnItemClear_Click(object sender, EventArgs e)
        {
            txtItem.Text = "";
        }

        private void btnMovementClear_Click(object sender, EventArgs e)
        {
            txtMovement.Text = "";
        }

        private void dgItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Article_No = dgItem.CurrentRow.Cells[Code.Index].Value.ToString();

            var gridAdapterPC = (from a in IME.ItemMovement(Article_No)
                                 select new
                                 {
                                     Date = a.SaleDate,
                                     FicheNo = a.FicheNo,
                                     Customer = a.c_name,
                                     FicheDocumentNo = a.FicheDocumentNo,
                                     Qty = a.Quantity,
                                     InOut = a.InOut,
                                     Type = a.Type,
                                     UOM = a.UnitMeasure,
                                     Price = a.UKPrice,
                                     Total = a.SubTotal,
                                     Currency = a.CurrName
                                 }
                       ).ToList();

            populateGridMovement(gridAdapterPC.ToList());
        }

        private void populateGridMovement<T>(List<T> queryable)
        {
            dgMovement.Rows.Clear();
            dgMovement.Refresh();
            foreach (dynamic item in queryable)
            {
                int rowIndex = dgMovement.Rows.Add();
                DataGridViewRow row = dgMovement.Rows[rowIndex];

                row.Cells[Date.Index].Value = item.Date;
                row.Cells[FicheNo.Index].Value = item.FicheNo;
                row.Cells[CustomerName.Index].Value = item.Customer;
                row.Cells[FicheDocNo.Index].Value = item.FicheDocumentNo;
                row.Cells[Qty.Index].Value = item.Qty;
                row.Cells[InOut.Index].Value = item.InOut;
                if (item.InOut == "IN")
                {
                    row.Cells[Type.Index].Value = "Sales Invoice";
                }
                else
                {
                    row.Cells[Type.Index].Value = "Purchase invoice";
                }
                row.Cells[UnitOfMeasure.Index].Value = item.UOM;
                row.Cells[UKPrice.Index].Value = item.Price;
                row.Cells[Total.Index].Value = item.Total;
                row.Cells[Currency.Index].Value = item.Currency;
            }
        }
    }
}
