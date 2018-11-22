using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;
using LoginForm.DataSet;
using System.Globalization;

namespace LoginForm
{
    public partial class frmQuotOrdersCurrency : DevExpress.XtraEditors.XtraForm
    {
        IMEEntities IME = new IMEEntities();
        decimal total = 0;
        decimal total2 = 0;
        DateTime time;
        ExchangeRate curr = new ExchangeRate();
        Decimal CurrValue = 1;
        decimal Currfactor = 1;
        decimal defaultCurr = 1;
        int year = 0;
        int StartMonth = 0;
        int EndMonth = 0;
        int customer = 0;
        int city = 0;
        DataGridViewRow CurrentRow;
        public frmQuotOrdersCurrency()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
           dgItemList, new object[] { true });

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

            cmbCurrency.DataSource = IME.Currencies.ToList();
            cmbCurrency.DisplayMember = "currencyName";
            cmbCurrency.ValueMember = "currencyID";
            cmbCurrency.SelectedValue = Utils.getManagement().DefaultCurrency;
            #endregion

            time = Utils.GetCurrentDateTime();
            cmbStartMonth.SelectedIndex = 0;
            cmbEndMonth.SelectedIndex = 11;
        }

        private void ItemSelect()
        {
            decimal QuotationTotal = 0;
            decimal SaleOrderTotal = 0;
            decimal Ordersqty = 0;
            decimal Totalqty = 0;
            decimal sonucvalue = 0;
            decimal sonucqty =0;
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
                if (cmbCustomer.GetItemText((cmbCustomer.SelectedItem)) != "")
                {
                    var gridAdapterPC = (from a in IME.Orders_LikeCustomer_CurrencyMonth(StartMonth, EndMonth, year, cmbCustomer.GetItemText((cmbCustomer.SelectedItem)))
                                         select new
                                         {
                                             CurrencyName = a.Cur,
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = a.Months,
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationCurrency = "",
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderCurrency = "",
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                           ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
                else if (cmbCity.GetItemText((cmbCity.SelectedItem)) != "")
                {
                    var gridAdapterPC = (from a in IME.Orders_LikeCity_CurrencyMonth(StartMonth, EndMonth, year, cmbCity.GetItemText((cmbCity.SelectedItem)))
                                         select new
                                         {
                                             CurrencyName = a.Cur,
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = a.Months,
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationCurrency = "",
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderCurrency = "",
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                           ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
                else
                {
                    var gridAdapterPC = (from a in IME.OrdersDate_CurrencyMonth(StartMonth, EndMonth, year)
                                         select new
                                         {
                                             CurrencyName = a.Cur,
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = a.Months,
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationCurrency = "",
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderCurrency = "",
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                        ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }

            }
            else
            {
                if (cmbCustomer.GetItemText((cmbCustomer.SelectedItem)) != "")
                {
                    var gridAdapterPC = (from a in IME.Orders_CurrencyLikeCustomer(StartMonth, EndMonth, year, cmbCustomer.GetItemText((cmbCustomer.SelectedItem)))
                                         select new
                                         {
                                             CurrencyName = a.Cur,
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = cmbStartMonth.GetItemText((cmbStartMonth.SelectedItem)) + "-" + cmbEndMonth.GetItemText((cmbEndMonth.SelectedItem)),
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationCurrency = "",
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderCurrency = "",
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                           ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
                else if (cmbCity.GetItemText((cmbCity.SelectedItem)) != "")
                {
                    var gridAdapterPC = (from a in IME.Orders_CurrencyLikeCity(StartMonth, EndMonth, year, cmbCity.GetItemText((cmbCity.SelectedItem)))
                                         select new
                                         {
                                             CurrencyName = a.Cur,
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = cmbStartMonth.GetItemText((cmbStartMonth.SelectedItem)) + "-" + cmbEndMonth.GetItemText((cmbEndMonth.SelectedItem)),
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationCurrency = "",
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderCurrency = "",
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                           ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
                else
                {
                    var gridAdapterPC = (from a in IME.OrdersDate_Currency(StartMonth, EndMonth, year)
                                         select new
                                         {
                                             CurrencyName = a.Cur,
                                             Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                             Month = cmbStartMonth.GetItemText((cmbStartMonth.SelectedItem)) + "-" + cmbEndMonth.GetItemText((cmbEndMonth.SelectedItem)),
                                             QuotationTotal = a.QuotationTotal,
                                             QuotationCurrency = "",
                                             QuotationQty = a.QuotationQty,
                                             SaleOrderTotal = a.SaleOrderTotal,
                                             SaleOrderCurrency = "",
                                             SaleOrderQty = a.SaleOrderQty
                                         }
                        ).ToList();

                    populateGrid(gridAdapterPC.ToList());
                }
            }

            #endregion
            for (int i = 0; i < dgItemList.ColumnCount; i++)
            {
                dgItemList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            for (int i = 0; i < dgItemList.RowCount; i++)
            {
                QuotationTotal = QuotationTotal + Decimal.Parse(dgItemList.Rows[i].Cells[QuotationCurrency.Index].Value.ToString());
                SaleOrderTotal = SaleOrderTotal + Decimal.Parse(dgItemList.Rows[i].Cells[SaleOrderCurrency.Index].Value.ToString());
            }

            txtTotal.Text = (Math.Round(QuotationTotal, 2)).ToString();
            txtOrdersTotal.Text = (Math.Round(SaleOrderTotal, 2)).ToString();
            Ordersqty = Convert.ToDecimal(txtOrdersQty.Text);
            Totalqty = Convert.ToDecimal(txtTotalQty.Text);
            sonucqty = (Ordersqty / Totalqty) * 100;
            sonucvalue = (SaleOrderTotal / QuotationTotal) * 100;
            if (Ordersqty != 0 && Totalqty != 0) txtValue.Text = (Math.Round(sonucqty, 2)).ToString() + " %"; else txtValue.Text = "0 %";
            if (QuotationTotal != 0 && SaleOrderTotal != 0) txtNumbers.Text = (Math.Round(sonucvalue, 2)).ToString() + " %"; else txtNumbers.Text = "0 %";
        }

        private void populateGrid<T>(List<T> queryable)
        {
            var format = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            format.CurrencySymbol = (cmbCurrency.SelectedItem as Currency).currencySymbol;
            decimal sayac = 0;
            decimal sayac2 = 0;
            decimal number = 0;
            decimal number2 = 0;
            dgItemList.Rows.Clear();
            dgItemList.Refresh();

            foreach (dynamic item in queryable)
            {
                int rowIndex = dgItemList.Rows.Add();
                DataGridViewRow row = dgItemList.Rows[rowIndex];

                row.Cells[CurrName.Index].Value = item?.CurrencyName;
                row.Cells[Years.Index].Value = item.Year;
                row.Cells[Months.Index].Value = item.Month;
                row.Cells[QuotationTotal.Index].Value = item.QuotationTotal;
                row.Cells[QuotationQty.Index].Value = item.QuotationQty;
                row.Cells[QuotationCurrency.Index].Value = item.QuotationCurrency;
                row.Cells[SaleOrderTotal.Index].Value = item.SaleOrderTotal;
                row.Cells[SaleOrderQty.Index].Value = item.SaleOrderQty;
                row.Cells[SaleOrderCurrency.Index].Value = item.SaleOrderCurrency;
            }

            for (int i = 0; i < dgItemList.RowCount; i++)
            {
                sayac = 0;
                sayac2 = 0;

                if (dgItemList.Rows[i].Cells[CurrName.Index].Value != null && (dgItemList.Rows[i].Cells[CurrName.Index].Value.ToString() != cmbCurrency.GetItemText((cmbCurrency.SelectedItem))))
                {
                    CurrencyCalculate(cmbCurrency.GetItemText((cmbCurrency.SelectedItem)));
                    CurrentRow = dgItemList.Rows[i];

                    if (CurrentRow.Cells[QuotationTotal.Index].Value != null)
                    {
                        sayac = Decimal.Parse(CurrentRow.Cells[QuotationTotal.Index].Value.ToString()) / CurrValue;
                        total = total + (Decimal.Parse(CurrentRow.Cells[QuotationTotal.Index].Value.ToString()) / CurrValue);
                    }
                    else { sayac = 0; total = 0; CurrentRow.Cells[QuotationTotal.Index].Value = 0; }
                    CurrentRow.Cells[QuotationCurrency.Index].Value = (Math.Round(sayac, 2));

                    if (CurrentRow.Cells[SaleOrderTotal.Index].Value != null)
                    {
                        sayac2 = Decimal.Parse(CurrentRow.Cells[SaleOrderTotal.Index].Value.ToString()) / CurrValue;
                        total2 = total2 + (Decimal.Parse(CurrentRow.Cells[SaleOrderTotal.Index].Value.ToString()) / CurrValue);
                    }
                    else { sayac2 = 0; total2 = 0; CurrentRow.Cells[SaleOrderTotal.Index].Value = 0; }
                    CurrentRow.Cells[SaleOrderCurrency.Index].Value = (Math.Round(sayac2, 2));
                }
                else
                {
                    CurrentRow = dgItemList.Rows[i];

                    if (CurrentRow.Cells[QuotationTotal.Index].Value != null)
                    {
                        sayac = Decimal.Parse(CurrentRow.Cells[QuotationTotal.Index].Value.ToString()) / defaultCurr;
                        total = total + (Decimal.Parse(CurrentRow.Cells[QuotationTotal.Index].Value.ToString()) / defaultCurr);
                    }
                    else { sayac = 0; total = 0; CurrentRow.Cells[QuotationTotal.Index].Value = 0; }
                    CurrentRow.Cells[QuotationCurrency.Index].Value = (Math.Round(sayac, 2));

                    if (CurrentRow.Cells[SaleOrderTotal.Index].Value != null)
                    {
                        sayac2 = Decimal.Parse(CurrentRow.Cells[SaleOrderTotal.Index].Value.ToString()) / defaultCurr;
                        total2 = total2 + (Decimal.Parse(CurrentRow.Cells[SaleOrderTotal.Index].Value.ToString()) / defaultCurr);
                    }
                    else { sayac2 = 0; total2 = 0; CurrentRow.Cells[SaleOrderTotal.Index].Value = 0; }
                    CurrentRow.Cells[SaleOrderCurrency.Index].Value = (Math.Round(sayac2, 2));
                }
                dgItemList.Columns[QuotationCurrency.Index].DefaultCellStyle.FormatProvider = format;
                dgItemList.Columns[QuotationCurrency.Index].DefaultCellStyle.Format = "c";
                number = number + Decimal.Parse(CurrentRow.Cells[QuotationQty.Index].Value.ToString());

                dgItemList.Columns[SaleOrderCurrency.Index].DefaultCellStyle.FormatProvider = format;
                dgItemList.Columns[SaleOrderCurrency.Index].DefaultCellStyle.Format = "c";
                number2 = number2 + Decimal.Parse(CurrentRow.Cells[SaleOrderQty.Index].Value.ToString());
            }
            txtTotalQty.Text = number.ToString();
            txtOrdersQty.Text = number2.ToString();
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

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurrency.GetItemText((cmbCurrency.SelectedItem)) != "" && cmbCurrency.DataSource != null)
            {
                GetCurrencySymbol();
                CurrencyCalculateTotal(cmbCurrency.GetItemText((cmbCurrency.SelectedItem)));
                txtTotal.Text = (Math.Round(total / Currfactor, 2)).ToString();
                txtOrdersTotal.Text = (Math.Round(total2 / Currfactor, 2)).ToString();
            }
        }

        private void CurrencyCalculate(string name)
        {
            if (cmbCurrency.SelectedItem != null)
            {

                decimal cb = IME.Currencies.Where(x => x.currencyName == name).FirstOrDefault().currencyID;
                curr = IME.ExchangeRates.Where(a => a.currencyId == cb).OrderByDescending(b => b.date).FirstOrDefault();

                CurrValue = (decimal)curr.rate;
            }
        }

        private void CurrencyCalculateTotal(string name)
        {
            if (cmbCurrency.GetItemText((cmbCurrency.SelectedItem)).ToString() != "System.Data.Entity.DynamicProxies.Currency_9335EDE4734B1A611248253EC13CD7E02BCB9B350417564E93A1316131A3D90F")
            {
                Currfactor = 1;
                decimal cb = IME.Currencies.Where(x => x.currencyName == name).FirstOrDefault().currencyID;
                curr = IME.ExchangeRates.Where(a => a.currencyId == cb).OrderByDescending(b => b.date).FirstOrDefault();

                Currfactor = (decimal)curr.rate;
            }
        }

        private void GetCurrencySymbol()
        {
            if (cmbCurrency.SelectedItem != null)
            {
                lblCurrency.Text = (cmbCurrency.SelectedItem as Currency).currencySymbol;
                lblCurrency2.Text = (cmbCurrency.SelectedItem as Currency).currencySymbol;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbCity.SelectedIndex = -1;
            city = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            customer = -1;
        }

        private void chkMonthGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMonthGroup.Checked == true)
            {
                chkYearsGroup.Checked = false;
            }
        }

        private void chkYearsGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYearsGroup.Checked == true)
            {
                chkMonthGroup.Checked = false;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ReportQuotvsSale(dgItemList);
            Utils.LogKayit("QuotationvsOrdersCurrency Report", "Quot vs Orders Currency Report excel");
        }
    }
}