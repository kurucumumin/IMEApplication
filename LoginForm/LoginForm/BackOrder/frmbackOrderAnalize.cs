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
using LoginForm.Services;

namespace LoginForm.BackOrder
{
    public partial class frmbackOrderAnalize : Form
    {
        DateTime dtpEndDate;
        DateTime dtpStartDate;
        public frmbackOrderAnalize()
        {
            InitializeComponent();
        }
        public frmbackOrderAnalize(DateTime startDate,DateTime EndDate)
        {
            dtpStartDate = startDate;
            dtpEndDate = EndDate;
            InitializeComponent();
            dgLoader();
        }

        private void frmbackOrderAnalize_Load(object sender, EventArgs e)
        {

        }

        #region Functions
        private void dgLoader()
        {
            IMEEntities IME = new IMEEntities();
            foreach (var item in IME.BackOrderAnalize(dtpStartDate, dtpEndDate))
            {
                DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
                row.Cells[Adder.Index].Value= item.Adder;
                row.Cells[CustomerName.Index].Value = item.customerName;
                row.Cells[FirstPromisedDate.Index].Value = item.FirstDate;
                row.Cells[PendingAmount.Index].Value = item.PendingAmount;
                row.Cells[PendingAmount1.Index].Value = item.PendingQuantity;
                row.Cells[Productno.Index].Value = item.ProductNo;
                row.Cells[PromisedDate2.Index].Value = item.PromisedDate2;
                row.Cells[PurchaseOrderNumber.Index].Value = item.PurchaseOrderNo;
                row.Cells[Quantity.Index].Value = item.Quantity;
                row.Cells[QuotationNo.Index].Value = item.QuotationNo;
                row.Cells[Representative.Index].Value = item.RepresentativeID;
                row.Cells[OrderDate.Index].Value = item.SaleDate;
                row.Cells[SaleOrder.Index].Value = item.SaleOrderID;
                dg.Rows.Add(row);

            }
        }
        #endregion
        private void copyAlltoClipboard()
        {
            dg.SelectAll();
            DataObject dataObj = dg.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            

            // QuotationExcelExport.ExportToItemHistory(dg);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
