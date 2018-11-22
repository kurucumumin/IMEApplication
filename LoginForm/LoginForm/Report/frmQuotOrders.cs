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
    public partial class frmQuotOrders : Form
    {
        IMEEntities IME = new IMEEntities();
        decimal total = 0;
        decimal total2 = 0;
        DateTime time;
        int year = 0;
        int StartMonth = 0;
        int EndMonth = 0;
        int customer = 0;
        int city = 0;
        DataGridViewRow CurrentRow;

        public frmQuotOrders()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
           dgQuotList, new object[] { true });

            #region Combobox

            cmbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbCustomer.DataSource = IME.Customers.ToList();
            cmbCustomer.DisplayMember = "c_name";
            cmbCustomer.ValueMember = "ID";
            cmbCustomer.SelectedIndex = -1;

            cmbCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCity.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbCity.DataSource = IME.Cities.ToList();
            cmbCity.DisplayMember = "City_name";
            cmbCity.ValueMember = "ID";
            cmbCity.SelectedIndex = -1;

            #endregion

            cmbStartMonth.SelectedIndex = 0;
            cmbEndMonth.SelectedIndex = 11;
            time = Utils.GetCurrentDateTime();
            lblCurrency.Text = IME.Currencies.Where(x => x.currencyName == "Dirham").FirstOrDefault().currencySymbol;
            lblCurrency2.Text = IME.Currencies.Where(x => x.currencyName == "Dirham").FirstOrDefault().currencySymbol;
        }

        private void populateGrid<T>(List<T> queryable)
        {
            var format = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            format.CurrencySymbol = IME.Currencies.Where(x=> x.currencyName == "Dirham").FirstOrDefault().currencySymbol;
            decimal number = 0;
            decimal number2 = 0;
            dgQuotList.Rows.Clear();
            dgQuotList.Refresh();

            foreach (dynamic item in queryable)
            {
                int rowIndex = dgQuotList.Rows.Add();
                DataGridViewRow row = dgQuotList.Rows[rowIndex];

                row.Cells[Years.Index].Value = item.Year;
                row.Cells[Months.Index].Value = item.Month;
                row.Cells[QuotationTotal.Index].Value = item.QuotationTotal;
                row.Cells[QuotationQty.Index].Value = item.QuotationQty;
                row.Cells[SaleOrderTotal.Index].Value = item.SaleOrderTotal;
                row.Cells[SaleOrderQty.Index].Value = item.SaleOrderQty;
            }

            for (int i = 0; i < dgQuotList.RowCount; i++)
            {
                CurrentRow = dgQuotList.Rows[i];
                dgQuotList.Columns[QuotationTotal.Index].DefaultCellStyle.FormatProvider = format;
                dgQuotList.Columns[QuotationTotal.Index].DefaultCellStyle.Format = "c";
                dgQuotList.Columns[SaleOrderTotal.Index].DefaultCellStyle.FormatProvider = format;
                dgQuotList.Columns[SaleOrderTotal.Index].DefaultCellStyle.Format = "c";

                number = number + Decimal.Parse(CurrentRow.Cells[QuotationQty.Index].Value.ToString());
                number2 = number2 + Decimal.Parse(CurrentRow.Cells[SaleOrderQty.Index].Value.ToString());

                total = total + (Decimal.Parse(CurrentRow.Cells[QuotationTotal.Index].Value.ToString()));
                total2 = total2 + (Decimal.Parse(CurrentRow.Cells[SaleOrderTotal.Index].Value.ToString()));
            }
            txtTotalQty.Text = number.ToString();
            txtOrdersQty.Text = number2.ToString();
        }

        private void ItemSelect()
        {
            decimal Ordersqty = 0;
            decimal Totalqty = 0;
            decimal sonucvalue = 0;
            decimal sonucqty = 0;
            total = 0;
            total2 = 0;
            year = Convert.ToInt32(cmbYear.GetItemText((cmbYear.SelectedItem)));
            customer = cmbCustomer.SelectedIndex + 1;
            city = cmbCity.SelectedIndex + 1;
            StartMonth = cmbStartMonth.SelectedIndex + 1;
            EndMonth = cmbEndMonth.SelectedIndex + 1;
            #region List Birleştirme

            if (chkMonthGroup.Checked == true)
            {
                if (customer != 0)
                {
                    var gridAdapterPC = (from a in IME.Orders_LikeCustomer_Month(StartMonth, EndMonth, year, cmbCustomer.GetItemText((cmbCustomer.SelectedItem)))
                                         select new
                                         {
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = a.Months,
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderQty =a.SaleOrderQty
                                         }
                           ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
                else if (city != 0)
                {
                    var gridAdapterPC = (from a in IME.Orders_LikeCity_Month(StartMonth, EndMonth, year, cmbCity.GetItemText((cmbCity.SelectedItem)))
                                         select new
                                         {
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = a.Months,
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                           ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
                else
                {
                    var gridAdapterPC = (from a in IME.OrdersDate_Month(StartMonth, EndMonth, year)
                                         select new
                                         {
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = a.Months,
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                        ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }

            }
            else
            {
                if (customer != 0)
                {
                    var gridAdapterPC = (from a in IME.Orders_LikeCustomer(StartMonth, EndMonth, year, cmbCustomer.GetItemText((cmbCustomer.SelectedItem)))
                                         select new
                                         {
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = cmbStartMonth.GetItemText((cmbStartMonth.SelectedItem)) + "-" + cmbEndMonth.GetItemText((cmbEndMonth.SelectedItem)),
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                           ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
                else if (city != 0)
                {
                    var gridAdapterPC = (from a in IME.Orders_LikeCity(StartMonth, EndMonth, year, cmbCity.GetItemText((cmbCity.SelectedItem)))
                                         select new
                                         {
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = cmbStartMonth.GetItemText((cmbStartMonth.SelectedItem)) + "-" + cmbEndMonth.GetItemText((cmbEndMonth.SelectedItem)),
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                           ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
                else
                {
                    var gridAdapterPC = (from a in IME.OrdersDate(StartMonth, EndMonth, year)
                                         select new
                                         {
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = cmbStartMonth.GetItemText((cmbStartMonth.SelectedItem)) + "-" + cmbEndMonth.GetItemText((cmbEndMonth.SelectedItem)),
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                        ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
            }

            #endregion
            for (int i = 0; i < dgQuotList.ColumnCount; i++)
            {
                dgQuotList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            txtTotal.Text = (Math.Round(total, 2)).ToString();
            txtOrdersTotal.Text = (Math.Round(total2, 2)).ToString();
            Ordersqty = Convert.ToDecimal(txtOrdersQty.Text);
            Totalqty = Convert.ToDecimal(txtTotalQty.Text);
            sonucqty = (Ordersqty / Totalqty)*100;
            sonucvalue = (total2 / total)*100;
            if (Ordersqty != 0 && Totalqty != 0) txtValue.Text = (Math.Round(sonucqty, 2)).ToString() + " %"; else txtValue.Text = "0 %";
            if (total != 0 && total2 != 0) txtNumbers.Text = (Math.Round(sonucvalue, 2)).ToString() + " %"; else txtNumbers.Text = "0 %";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbYear.GetItemText((cmbYear.SelectedItem)) != "")
            {
                ItemSelect();
            }
            else
            {
                MessageBox.Show("Please selected year");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            customer = - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbCity.SelectedIndex = -1;
            city = -1;
        }

        private void chkYearsGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYearsGroup.Checked==true)
            {
                chkMonthGroup.Checked = false;
            }
        }

        private void chkMonthGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMonthGroup.Checked == true)
            {
                chkYearsGroup.Checked = false;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ReportQuotvsSale(dgQuotList);
            Utils.LogKayit("QuotvsOrders Report", "Quot vs Orders Report excel");
        }
    }
}
