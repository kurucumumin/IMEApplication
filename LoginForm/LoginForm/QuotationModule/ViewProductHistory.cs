using LoginForm.Services;
using LoginForm.Services.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class ViewProductHistory : MyForm
    {
        SqlDataAdapter da;
        System.Data.DataSet ds=new System.Data.DataSet();
        string ItemCode;

        public ViewProductHistory()
        {
            InitializeComponent();
            SetDataGridSettings();
        }

        private void SetDataGridSettings()
        {
            //dgProductHistory.AutoResizeColumn(dgcRsCode.Index, DataGridViewAutoSizeColumnMode.AllCells);
            //dgProductHistory.AutoResizeColumn(dgcCustomerCode.Index, DataGridViewAutoSizeColumnMode.ColumnHeader);
            //dgProductHistory.AutoResizeColumn(dgcCustomerName.Index, DataGridViewAutoSizeColumnMode.AllCells);
            //dgProductHistory.AutoResizeColumn(dgcDate.Index, DataGridViewAutoSizeColumnMode.AllCells);
            //dgProductHistory.AutoResizeColumn(dgcQuotationNo.Index, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
            //dgProductHistory.AutoResizeColumn(dgcQuantity.Index, DataGridViewAutoSizeColumnMode.ColumnHeader);
            //dgProductHistory.AutoResizeColumn(dgcUP.Index, DataGridViewAutoSizeColumnMode.AllCells);
            ////dgProductHistory.AutoResizeColumn(dgcCompetitor.Index, DataGridViewAutoSizeColumnMode.AllCells);
            //dgProductHistory.AutoResizeColumn(dgcTargetPrice.Index, DataGridViewAutoSizeColumnMode.ColumnHeader);
            //dgProductHistory.AutoResizeColumn(dgcCurrency.Index, DataGridViewAutoSizeColumnMode.ColumnHeader);
            //dgProductHistory.AutoResizeColumn(dgcStatus.Index, DataGridViewAutoSizeColumnMode.AllCells);
            //dgProductHistory.RowsDefaultCellStyle.SelectionBackColor = DefaultGridSelectedRowColor ;
            dgProductHistory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public ViewProductHistory(string item_code)
        {
            InitializeComponent();
            this.ItemCode = item_code;
            SetDataGridSettings();
        }

        private void ViewProductHistory_Load(object sender, EventArgs e)
        {
            ProductHistory();
        }

        public void ProductHistory()
        {
            if (ItemCode.Substring(ItemCode.Length - 1, 1) == "P")
            {
                FillDataGridWithDataTable(new Sp_Item().GetProductHistoryWithArticleNo_P(ItemCode));
            }
            else
            {
                FillDataGridWithDataTable(new Sp_Item().GetProductHistoryWithArticleNo(ItemCode));
            }   
        }

        private void FillDataGridWithDataTable(DataTable dataTable)
        {
            foreach (DataRow item in dataTable.Rows)
            {
                DataGridViewRow row = dgProductHistory.Rows[dgProductHistory.Rows.Add()];

                row.Cells[dgcRsCode.Index].Value = item["RSCode"];
                row.Cells[dgcCustomerCode.Index].Value = item["CustomerCode"];
                row.Cells[dgcCustomerName.Index].Value = item["CustomerName"];
                row.Cells[dgcDate.Index].Value = item["Date"];
                row.Cells[dgcQuotationNo.Index].Value = item["QuotNo"];
                row.Cells[dgcQuantity.Index].Value = item["QTY"];
                row.Cells[dgcUP.Index].Value = item["UP"];
                row.Cells[dgLandingCost.Index].Value = item["LandingCost"];
                row.Cells[dgMargin.Index].Value = item["Margin"];
                row.Cells[dgcCurrency.Index].Value = item["Curr"];
                row.Cells[dgcStatus.Index].Value = item["Status"];
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgProductHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
