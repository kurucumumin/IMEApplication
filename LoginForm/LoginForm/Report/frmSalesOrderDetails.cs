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
    public partial class frmSalesOrderDetails : Form
    {
        IMEEntities IME = new IMEEntities();
        DateTime StartDate;
        DateTime EndDate;
        ExchangeRate curr = new ExchangeRate();
        Decimal CurrValue = 1;
        decimal defaultCurr = 1;
        DataGridViewRow CurrentRow;

        public frmSalesOrderDetails()
        {
            InitializeComponent();

            dgQuotList.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgQuotList, new object[] { true });

            dateFirst.Value = Utils.GetCurrentDateTime().AddMonths(-3);
            dateEnd.Value = Utils.GetCurrentDateTime();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ReportQuotvsSale(dgQuotList);
            Utils.LogKayit("SalesOrderDetails Report", "Sales Order Details Report excel");
        }

        private void populateGrid<T>(List<T> queryable)
        {
            var format = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            format.CurrencySymbol = IME.Currencies.Where(x => x.currencyName == "Dirham").FirstOrDefault().currencySymbol;
            //decimal number = 0;
            //decimal number2 = 0;
            dgQuotList.Rows.Clear();
            dgQuotList.Refresh();
            foreach (dynamic item in queryable)
            {
                int rowIndex = dgQuotList.Rows.Add();
                DataGridViewRow row = dgQuotList.Rows[rowIndex];

                row.Cells[No.Index].Value = rowIndex + 1;
                row.Cells[QuotationNo.Index].Value = item.QuotationNo;
                row.Cells[QuotationDate.Index].Value = item.StartDate;
                row.Cells[CustomerCode.Index].Value = item.CustomerCode;
                row.Cells[CustomerName.Index].Value = item.CustomerName;
                row.Cells[RSCode.Index].Value = item.ItemCard;
                row.Cells[Qty.Index].Value = item.Qty;
                row.Cells[UP.Index].Value = item.UcupCurr;
                row.Cells[TotalQuot.Index].Value = item.TotalQty;
                row.Cells[CurrName.Index].Value = item.CurrName;
                row.Cells[Rate.Index].Value = item.Rate;
                row.Cells[GBPRate.Index].Value = CurrValue;
                row.Cells[GBPTotal.Index].Value = item.GBPTotal;
                row.Cells[GBPTotalCost.Index].Value = item.GBPCost;
                row.Cells[GBPTotalLandingCost.Index].Value = item.GBPLandingCost;
                row.Cells[AEDTotal.Index].Value = item.AEDTotal;
                row.Cells[AEDTotalCost.Index].Value = item.AEDCost;
                row.Cells[AEDTotalLandingCost.Index].Value = item.AEDLandingCost;
                row.Cells[Margin.Index].Value = item.Marge;
                row.Cells[Markup.Index].Value = item.Markup;
                if (item.QuotationStatus == "Deleted")
                {
                    row.Cells[Deleted.Index].Value = "D";
                }
                row.Cells[Online.Index].Value = item.Only;
                row.Cells[SaleOrderNo.Index].Value = item.SaleOrderNo;
                row.Cells[SaleOrderDate.Index].Value = item.SaleOrderDate;
                row.Cells[LPO.Index].Value = item.LPONO;
                row.Cells[PurchaseOrderNo.Index].Value = item.PurchaseOrder;
                row.Cells[RSInvoiceNo.Index].Value = item.RSinvoice;
                row.Cells[RSInvoiceDate.Index].Value = item.RSinvoiceDate;
                row.Cells[IMEInvoiceNo.Index].Value = item.IMEinvoice;
                row.Cells[IMEInvoiceDate.Index].Value = item.IMEinvoiceDate;
                row.Cells[Manufacturer.Index].Value = item.Manufacturer;
                row.Cells[MPN.Index].Value = item.MPN;
                row.Cells[RSCategory.Index].Value = item.MHCodeLevel;
                row.Cells[CCCNNo.Index].Value = item.CCCNNO;
                row.Cells[RepName.Index].Value = item.NameLastName;
                if (item.SaleOrderNature == "XDOC")
                {
                    row.Cells[DeliveryType.Index].Value = item.SaleOrderNature;
                }
                else
                {
                    row.Cells[DeliveryType.Index].Value = "NORMAL";
                }

            }

            for (int i = 0; i < dgQuotList.RowCount; i++)
            {
                CurrentRow = dgQuotList.Rows[i];

                if (CurrentRow.Cells[GBPTotal.Index].Value == null) CurrentRow.Cells[GBPTotal.Index].Value = 0;
                if (CurrentRow.Cells[GBPTotalCost.Index].Value == null) CurrentRow.Cells[GBPTotalCost.Index].Value = 0;
                if (CurrentRow.Cells[GBPTotalLandingCost.Index].Value == null) CurrentRow.Cells[GBPTotalLandingCost.Index].Value = 0;
                if (CurrentRow.Cells[Margin.Index].Value == null) CurrentRow.Cells[Margin.Index].Value = 0;
                if (CurrentRow.Cells[Markup.Index].Value == null) CurrentRow.Cells[Markup.Index].Value = 0;

                lblGbpTotal.Text = Math.Round(Decimal.Parse(lblGbpTotal.Text) + Decimal.Parse(CurrentRow.Cells[GBPTotal.Index].Value.ToString()), 2).ToString();
                lblGbpCost.Text = Math.Round(Decimal.Parse(lblGbpCost.Text) + Decimal.Parse(CurrentRow.Cells[GBPTotalCost.Index].Value.ToString()), 2).ToString();
                lblGbpLandingCost.Text = Math.Round(Decimal.Parse(lblGbpLandingCost.Text) + Decimal.Parse(CurrentRow.Cells[GBPTotalLandingCost.Index].Value.ToString()), 2).ToString();
            }

            lblCostMargin.Text = Math.Round(((1-(Decimal.Parse(lblGbpCost.Text) / Decimal.Parse(lblGbpTotal.Text)))*100), 2).ToString()+" %";
            lblLandingCostMargin.Text = Math.Round(((1 - (Decimal.Parse(lblGbpLandingCost.Text) / Decimal.Parse(lblGbpTotal.Text))) * 100), 2).ToString() + " %";
            lblCostMarkup.Text = Math.Round((((Decimal.Parse(lblGbpTotal.Text) / Decimal.Parse(lblGbpCost.Text))-1) * 100), 2).ToString() + " %";
            lblLandingCostMarkup.Text = Math.Round((((Decimal.Parse(lblGbpTotal.Text) / Decimal.Parse(lblGbpLandingCost.Text)) - 1) * 100), 2).ToString() + " %";
        }

        private void ItemSelect()
        {
            //decimal Ordersqty = 0;
            //decimal Totalqty = 0;
            //decimal sonucvalue = 0;
            //decimal sonucqty = 0;
            AEDCurrencyCalculate("Dirham");
            GBPCurrencyCalculate("Pound");
            StartDate = dateFirst.Value;
            EndDate = dateEnd.Value;

            var gridAdapterPC = (from a in IME.SalesOrdersDetail(StartDate, EndDate)
                                 select new
                                 {
                                     QuotationStatus = a.QuotationStatus,
                                     QuotationNo = a.QuotationNo,
                                     StartDate = a.StartDate,
                                     CustomerCode = a.ID,
                                     CustomerName = a.c_name,
                                     CategoryName = a.categoryname,
                                     SubCategoryName = a.subcategoryname,
                                     ItemCard = a.ItemCode,
                                     Qty = a.Qty,
                                     UcupCurr = a.UCUPCurr,
                                     TotalQty = a.Qty * a.UCUPCurr,
                                     CurrName = a.CurrName,
                                     Rate = a.rate,
                                     GBPTotal = a.TLTotal * a.rate * CurrValue,
                                     GBPCost = a.TLCost * a.Qty,
                                     GBPLandingCost = a.TLLandingCost * a.Qty,
                                     AEDTotal = a.TLTotal * CurrValue,
                                     AEDCost = a.TLCost * CurrValue * a.Qty,
                                     AEDLandingCost = a.TLLandingCost * CurrValue * a.Qty,
                                     Marge = a.Marge,
                                     Markup=(((a.TLTotal * a.rate * CurrValue)/ (a.TLLandingCost * a.Qty))-1)*100,
                                     Status = a.Status,
                                     RFQ = a.RFQNo,
                                     Only = a.Only,
                                     SaleOrderNo = a.SaleOrderNo,
                                     SaleOrderDate = a.SaleDate,
                                     LPONO = a.LPONO,
                                     PurchaseOrder = a.PurchaseNo,
                                     RSinvoice = a.RSinvoice,
                                     RSinvoiceDate = a.RSinvoiceDate,
                                     IMEinvoice = a.IMEinvoice,
                                     IMEinvoiceDate = a.IMEinvoiceDate,
                                     Manufacturer = a.Manufacturer,
                                     MPN = a.MPN,
                                     MHCodeLevel = a.MHCodeLevel1,
                                     CCCNNO = a.CCCNNo,
                                     NameLastName = a.NameLastName,
                                     SaleOrderNature = a.SaleOrderNature
                                 }
                           ).Where(x=> x.SaleOrderNo != null).ToList();

            populateGrid(gridAdapterPC.ToList());

        }

        private void AEDCurrencyCalculate(string name)
        {
            decimal cb = IME.Currencies.Where(x => x.currencyName == name).FirstOrDefault().currencyID;
            curr = IME.ExchangeRates.Where(a => a.currencyId == cb).OrderByDescending(b => b.date).FirstOrDefault();

            defaultCurr = (decimal)curr.rate;
        }

        private void GBPCurrencyCalculate(string name)
        {
            decimal cb = IME.Currencies.Where(x => x.currencyName == name).FirstOrDefault().currencyID;
            curr = IME.ExchangeRates.Where(a => a.currencyId == cb).OrderByDescending(b => b.date).FirstOrDefault();

            CurrValue = (decimal)curr.rate;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ItemSelect();
        }

        private void frmSalesOrderDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
