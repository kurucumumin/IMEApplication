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
    public partial class frmbackOrderAnalize : MyForm
    {
        DateTime backOrderanalizeDate;
        public frmbackOrderAnalize()
        {
            InitializeComponent();
        }
        public frmbackOrderAnalize(DateTime Date)
        {
            backOrderanalizeDate = Date;
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
            var BackOrderAnalizeList = IME.BackOrderAnalize(backOrderanalizeDate.Date).ToList();
            foreach (var item in BackOrderAnalizeList)
            {
                if (BackOrderAnalizeList.Where(a=>a.PurchaseOrderNo==item.PurchaseOrderNo).Where(a => a.ProductNo == item.ProductNo).OrderByDescending(a => a.FirstDate).FirstOrDefault().FirstDate == item.FirstDate)
                {
                    DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
                    row.Cells[Adder.Index].Value = item.Adder;
                    row.Cells[CustomerName.Index].Value = item.customerName;
                    row.Cells[FirstPromisedDate.Index].Value = item.FirstDate;
                    row.Cells[CurrentPromisedDate1.Index].Value = item.PromisedDate2;
                    row.Cells[PendingAmount.Index].Value = item.PendingAmount;                    
                    row.Cells[Productno.Index].Value = item.ProductNo;
                    row.Cells[PurchaseOrderNumber.Index].Value = item.PurchaseOrderNo;
                    row.Cells[Quantity.Index].Value = item.Quantity;
                    row.Cells[QuotationNo.Index].Value = item.QuotationNo;
                    row.Cells[Representative.Index].Value = item.RepresentativeID;
                    row.Cells[OrderDate.Index].Value = item.SaleDate;
                    row.Cells[SaleOrder.Index].Value = item.SaleOrderID;
                    //
                    row.Cells[PendingAmount1.Index].Value = item.PendingQuantity;
                    row.Cells[CurrentPromisedDate2.Index].Value = item.PromisedDate2;
                    row.Cells[PromisedDate2.Index].Value = item.FirstDate;
                    if (BackOrderAnalizeList.Where(a => a.PurchaseOrderNo == item.PurchaseOrderNo).Where(a => a.ProductNo == item.ProductNo).ToList().Count==1)
                    {
                        row.Cells[PendingAmount.Index].Value = item.PendingQuantity;
                        row.Cells[CurrentPromisedDate1.Index].Value = item.PromisedDate2;
                        row.Cells[FirstPromisedDate.Index].Value = item.FirstDate;
                    }
                    else
                    {
                        var item2 = BackOrderAnalizeList.Where(a => a.PurchaseOrderNo == item.PurchaseOrderNo).Where(a => a.ProductNo == item.ProductNo).OrderByDescending(a => a.FirstDate).ToList().ElementAt(1);
                        row.Cells[PendingAmount.Index].Value = item2.PendingQuantity;
                        row.Cells[FirstPromisedDate.Index].Value = item2.FirstDate;
                        row.Cells[CurrentPromisedDate1.Index].Value = item2.PromisedDate2;
                    }

                    #region DataGrid Info 
                    if (row.Cells[CurrentPromisedDate2.Index].Value!=null &&  DateTime.Parse(row.Cells[CurrentPromisedDate2.Index].Value.ToString()) < DateTime.Now)
                    {
                        row.DefaultCellStyle.BackColor = Color.IndianRed;
                        row.Cells[Information.Index].Value = "Delivery date is past";
                    }
                    else if (row.Cells[PendingAmount1.Index].Value == null || row.Cells[PendingAmount1.Index].Value.ToString() == "")
                    {
                        row.Cells[Information.Index].Style.BackColor = Color.LightSeaGreen;
                        row.Cells[Information.Index].Value = "Billed by RS";
                    }
                    else if (row.Cells[PendingAmount.Index].Value == null || row.Cells[PendingAmount.Index].Value.ToString() == "")
                    {
                        row.Cells[Information.Index].Style.BackColor = Color.LightYellow;
                        row.Cells[Information.Index].Value = "New order sent by RS";
                    }
                    else if (DateTime.Parse(row.Cells[CurrentPromisedDate2.Index].Value.ToString()) > DateTime.Parse(row.Cells[CurrentPromisedDate1.Index].Value.ToString()))
                    {
                        row.Cells[Information.Index].Style.BackColor = Color.BlueViolet;
                        row.Cells[Information.Index].Value = " RS has postponed the sending date";
                    }
                    else if (DateTime.Parse(row.Cells[CurrentPromisedDate2.Index].Value.ToString()) < DateTime.Parse(row.Cells[CurrentPromisedDate1.Index].Value.ToString()))
                    {
                        row.Cells[Information.Index].Style.BackColor = Color.BlueViolet;
                        row.Cells[Information.Index].Value = " RS has preponed the sending date";
                    }                    
                    #endregion
                    dg.Rows.Add(row);
                }
            }
        }
        #endregion
        
        private void button1_Click(object sender, EventArgs e)
        {
             QuotationExcelExport.ExportToItemHistory(dg);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Close", "Are you sure to close this page", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
