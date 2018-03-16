using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Services;

namespace LoginForm.Account.Services
{
    class FinancialStatementSP
    {
        public DataTable FundFlowReportPrintCompany(decimal decCompanyId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SL.NO", typeof(decimal));
            dtbl.Columns["SL.NO"].AutoIncrement = true;
            dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
            dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from c in IME.Companies.Where(x => x.companyId == decCompanyId)
                               from cur in IME.Currencies.Where(x => x.currencyID == c.currencyId)
                               select new
                               {
                                   c.companyName,
                                   c.address,
                                   c.phone,
                                   c.email,
                                   cur.currencyName
                               }).ToList();

                dtbl.Columns.Add("companyName");
                dtbl.Columns.Add("address");
                dtbl.Columns.Add("phone");
                dtbl.Columns.Add("email");
                dtbl.Columns.Add("currencyName");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["companyName"] = item.companyName;
                    row["address"] = item.address;
                    row["phone"] = item.phone;
                    row["email"] = item.email;
                    row["currencyName"] = item.currencyName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtbl;
        }

        public decimal StockValueGetOnDate(DateTime date, string calculationMethod, bool isOpeningStock, bool isFromBalanceSheet)
        {
            IMEEntities IME = new IMEEntities();
            decimal dcstockValue = 0;
            DateTime fromDate = Utils.getManagement().FinancialYear.fromDate.Value;
            try
            {
                if (calculationMethod == "FIFO")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = IME.StockValueOnDateByFIFOForOpeningStock(date, fromDate);
                        }
                        else
                        {
                            dcstockValue = IME.StockValueOnDateByFIFOForOpeningStockForBalancesheet(date, fromDate);
                        }
                    }
                    else
                    {
                        dcstockValue = IME.StockValueOnDateByFIFO(date);
                    }
                }
                else if (calculationMethod == "Average Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = IME.StockValueOnDateByAVCOForOpeningStock(date, fromDate);
                        }
                        else
                        {
                            dcstockValue = IME.StockValueOnDateByAVCOForOpeningStockForBalanceSheet(date, fromDate);
                        }
                    }
                    else
                    {
                        dcstockValue = IME.StockValueOnDateByAVCO(date);
                    }
                }
                else if (calculationMethod == "High Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByHighCostForOpeningStock(date, fromDate));
                        }
                        else
                        {
                            dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByHighCostForOpeningStockBlncSheet(date, fromDate));
                        }
                    }
                    else
                    {
                        dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByHighCost(date));
                    }
                }
                else if (calculationMethod == "Low Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = IME.StockValueOnDateByLowCostForOpeningStock(date, fromDate);
                        }
                        else
                        {
                            dcstockValue = IME.StockValueOnDateByLowCostForOpeningStockForBlncSheet(date, fromDate);
                        }
                    }
                    else
                    {
                        dcstockValue = IME.StockValueOnDateByLowCost(date);
                    }
                }
                else if (calculationMethod == "Last Purchase Rate")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByLastPurchaseRateForOpeningStock(date, fromDate));
                        }
                        else
                        {
                            dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByLastPurchaseRateForOpeningStockBlncSheet(date, fromDate));
                        }
                    }
                    else
                    {
                        dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByLastPurchaseRate(date));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dcstockValue;
        }

        public System.Data.DataSet BalanceSheet(DateTime fromDate, DateTime toDate)
        {
            IMEEntities IME = new IMEEntities();
            System.Data.DataSet dts = new System.Data.DataSet();
            dts.Tables.Add(new DataTable());
            try
            {
                DataTable dtbl1 = new DataTable();

                var adaptor1 = (IME.BalanceSheetAssets(fromDate, toDate)).ToList();
                dtbl1.Columns.Add("ID");
                dtbl1.Columns.Add("Name");
                dtbl1.Columns.Add("Balance");
                foreach (var item in adaptor1)
                {
                    DataRow row = dtbl1.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dtbl1.Rows.Add(row);
                }
                dts.Tables.Add(dtbl1);



                DataTable dtbl2 = new DataTable();
                var adaptor2 = (IME.BalanceSheetLiabilities(fromDate, toDate)).ToList();
                dtbl2.Columns.Add("ID");
                dtbl2.Columns.Add("Name");
                dtbl2.Columns.Add("Balance");
                foreach (var item in adaptor2)
                {
                    DataRow row = dtbl2.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dtbl2.Rows.Add(row);
                }
                dts.Tables.Add(dtbl2);


                DataTable dtbl3 = new DataTable();
                var adaptor3 = (IME.BalanceSheetProfitAndLossAccount(fromDate, toDate)).ToList();
                dtbl3.Columns.Add("ID");
                dtbl3.Columns.Add("Name");
                dtbl3.Columns.Add("Balance");
                foreach (var item in adaptor3)
                {
                    DataRow row = dtbl3.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dtbl3.Rows.Add(row);
                }
                dts.Tables.Add(dtbl3);



                DataTable dtbl4 = new DataTable();
                var adaptor4 = (IME.BalanceSheetProfitAndLoss(fromDate, toDate)).ToList();
                dtbl4.Columns.Add("ID");
                dtbl4.Columns.Add("Name");
                dtbl4.Columns.Add("Balance");
                foreach (var item in adaptor4)
                {
                    DataRow row = dtbl4.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dtbl4.Rows.Add(row);
                }
                dts.Tables.Add(dtbl4);


                DataTable dtbl5 = new DataTable();
                var adaptor5 = (IME.BalanceSheetDifference(fromDate, toDate)).ToList();
                dtbl5.Columns.Add("ID");
                dtbl5.Columns.Add("Name");
                dtbl5.Columns.Add("Balance");
                foreach (var item in adaptor5)
                {
                    DataRow row = dtbl5.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dtbl5.Rows.Add(row);
                }
                dts.Tables.Add(dtbl5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dts;
        }

        public System.Data.DataSet TrialBalance(DateTime fromDate, DateTime toDate, decimal decAccountGroupId)
        {
            IMEEntities IME = new IMEEntities();
            System.Data.DataSet dts = new System.Data.DataSet();
            dts.Tables.Add(new DataTable());
            try
            {
                DataTable dtbl = new DataTable();
                var adaptor = (IME.Trialbalance1(decAccountGroupId, fromDate, toDate)).ToList();
                dtbl.Columns.Add("Sl_No");
                dtbl.Columns.Add("accountGroupId");
                dtbl.Columns.Add("Name");
                dtbl.Columns.Add("credit");
                dtbl.Columns.Add("debit");
                dtbl.Columns.Add("OpeningBalance");
                dtbl.Columns.Add("OpBalance");
                dtbl.Columns.Add("Balance");
                dtbl.Columns.Add("Balance1");
                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["Sl_No"] = item.Sl_No;
                    row["accountGroupId"] = item.accountGroupId;
                    row["Name"] = item.Name;
                    row["credit"] = item.credit;
                    row["debit"] = item.debit;
                    row["OpeningBalance"] = item.OpeningBalance;
                    row["OpBalance"] = item.OpBalance;
                    row["Balance"] = item.Balance;
                    row["Balance1"] = item.Balance1;

                    dtbl.Rows.Add(row);
                }
                dts.Tables.Add(dtbl);


                DataTable dtbl2 = new DataTable();
                var adaptor2 = (IME.Trialbalance2(decAccountGroupId, fromDate, toDate)).ToList();
                dtbl2.Columns.Add("Name");
                dtbl2.Columns.Add("credit");
                dtbl2.Columns.Add("debit");
                dtbl2.Columns.Add("OpeningBalance");
                foreach (var item in adaptor2)
                {
                    DataRow row = dtbl2.NewRow();


                    row["Name"] = item.Name;
                    row["credit"] = item.credit;
                    row["debit"] = item.debit;
                    row["OpeningBalance"] = item.OpeningBalance;


                    dtbl2.Rows.Add(row);
                }
                dts.Tables.Add(dtbl2);


                DataTable dtbl3 = new DataTable();
                var adaptor3 = (IME.Trialbalance3(decAccountGroupId, fromDate, toDate)).ToList();
                dtbl3.Columns.Add("Name");
                dtbl3.Columns.Add("credit");
                dtbl3.Columns.Add("debit");
                dtbl3.Columns.Add("OpeningBalance");
                foreach (var item in adaptor3)
                {
                    DataRow row = dtbl3.NewRow();


                    row["Name"] = item.Name;
                    row["credit"] = item.credit;
                    row["debit"] = item.debit;
                    row["OpeningBalance"] = item.OpeningBalance;


                    dtbl3.Rows.Add(row);
                }
                dts.Tables.Add(dtbl3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dts;
        }

        public System.Data.DataSet ProfitAndLossAnalysisUpToaDateForBalansheet(DateTime fromDate, DateTime toDate)
        {
            IMEEntities IME = new IMEEntities();
            System.Data.DataSet dts = new System.Data.DataSet();
            dts.Tables.Add(new DataTable());
            try
            {
                DataTable dtbl1 = new DataTable();

                var adaptor1 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetSalesAcount(fromDate, toDate)).ToList();

                dtbl1.Columns.Add("ID");
                dtbl1.Columns.Add("Name");
                dtbl1.Columns.Add("Credit");
                foreach (var item in adaptor1)
                {
                    DataRow row = dtbl1.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = item.Credit;


                    dtbl1.Rows.Add(row);
                }
                dts.Tables.Add(dtbl1);



                DataTable dtbl2 = new DataTable();
                 var adaptor2 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetPurchaseAcount(fromDate, toDate)).ToList();
                dtbl2.Columns.Add("ID");
                dtbl2.Columns.Add("Name");
                dtbl2.Columns.Add("Debit");
                foreach (var item in adaptor2)
                {
                    DataRow row = dtbl2.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = item.Debit;

                    dtbl2.Rows.Add(row);
                }
                dts.Tables.Add(dtbl2);


                DataTable dtbl3 = new DataTable();
                 var adaptor3 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetDirectincome(fromDate, toDate)).ToList();
                dtbl3.Columns.Add("ID");
                dtbl3.Columns.Add("Name");
                dtbl3.Columns.Add("Credit");
                foreach (var item in adaptor3)
                {
                    DataRow row = dtbl3.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = item.Credit;

                    dtbl3.Rows.Add(row);
                }
                dts.Tables.Add(dtbl3);



                DataTable dtbl4 = new DataTable();
                var adaptor4 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetDirectExpenses(fromDate, toDate)).ToList();
                dtbl4.Columns.Add("ID");
                dtbl4.Columns.Add("Name");
                dtbl4.Columns.Add("Debit");
                foreach (var item in adaptor4)
                {
                    DataRow row = dtbl4.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = item.Debit;

                    dtbl4.Rows.Add(row);
                }
                dts.Tables.Add(dtbl4);


                DataTable dtbl5 = new DataTable();
                 var adaptor5 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetIndirectincome(fromDate, toDate)).ToList();
                dtbl5.Columns.Add("ID");
                dtbl5.Columns.Add("Name");
                dtbl5.Columns.Add("Credit");
                foreach (var item in adaptor5)
                {
                    DataRow row = dtbl5.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = item.Credit;

                    dtbl5.Rows.Add(row);
                }
                dts.Tables.Add(dtbl5);


                DataTable dtbl6 = new DataTable();
                var adaptor6 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetIndirectExpenses(fromDate, toDate)).ToList();
                dtbl6.Columns.Add("ID");
                dtbl6.Columns.Add("Name");
                dtbl6.Columns.Add("Debit");
                foreach (var item in adaptor6)
                {
                    DataRow row = dtbl6.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = item.Debit;

                    dtbl6.Rows.Add(row);
                }
                dts.Tables.Add(dtbl6);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dts;
        }

        public System.Data.DataSet ProfitAndLossAnalysis(DateTime fromDate, DateTime toDate)
        {
            IMEEntities IME = new IMEEntities();
            System.Data.DataSet dts = new System.Data.DataSet();
            dts.Tables.Add(new DataTable());
            try
            {
                DataTable dtbl1 = new DataTable();

                var adaptor1 = (IME.ProfitAndLossAnalysisPurchaseAccount(fromDate, toDate)).ToList();
                dtbl1.Columns.Add("ID");
                dtbl1.Columns.Add("Name");
                dtbl1.Columns.Add("Debit");
                foreach (var item in adaptor1)
                {
                    DataRow row = dtbl1.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = Convert.ToDecimal(item.Debit);

                    dtbl1.Rows.Add(row);
                }
                dts.Tables.Add(dtbl1);



                DataTable dtbl2 = new DataTable();
                var adaptor2 = (IME.ProfitAndLossAnalysisSalesAccount(fromDate, toDate)).ToList();
                dtbl2.Columns.Add("ID");
                dtbl2.Columns.Add("Name");
                dtbl2.Columns.Add("Credit");
                foreach (var item in adaptor2)
                {
                    DataRow row = dtbl2.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = Convert.ToDecimal(item.Credit);

                    dtbl2.Rows.Add(row);
                }
                dts.Tables.Add(dtbl2);


                DataTable dtbl3 = new DataTable();
                var adaptor3 = (IME.ProfitAndLossAnalysisDirectExpenses(fromDate, toDate)).ToList();
                dtbl3.Columns.Add("ID");
                dtbl3.Columns.Add("Name");
                dtbl3.Columns.Add("Debit");
                foreach (var item in adaptor3)
                {
                    DataRow row = dtbl3.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = Convert.ToDecimal(item.Debit);

                    dtbl3.Rows.Add(row);
                }
                dts.Tables.Add(dtbl3);



                DataTable dtbl4 = new DataTable();
                var adaptor4 = (IME.ProfitAndLossAnalysisDirectIncome(fromDate, toDate)).ToList();
                dtbl4.Columns.Add("ID");
                dtbl4.Columns.Add("Name");
                dtbl4.Columns.Add("Credit");
                foreach (var item in adaptor4)
                {
                    DataRow row = dtbl4.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = Convert.ToDecimal(item.Credit);

                    dtbl4.Rows.Add(row);
                }
                dts.Tables.Add(dtbl4);


                DataTable dtbl5 = new DataTable();
                var adaptor5 = (IME.ProfitAndLossAnalysisInDirectExpenses(fromDate, toDate)).ToList();
                dtbl5.Columns.Add("ID");
                dtbl5.Columns.Add("Name");
                dtbl5.Columns.Add("Debit");
                foreach (var item in adaptor5)
                {
                    DataRow row = dtbl5.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = Convert.ToDecimal(item.Debit);

                    dtbl5.Rows.Add(row);
                }
                dts.Tables.Add(dtbl5);


                DataTable dtbl6 = new DataTable();
                var adaptor6 = (IME.ProfitAndLossAnalysisInDirectIncome(fromDate, toDate)).ToList();
                dtbl6.Columns.Add("ID");
                dtbl6.Columns.Add("Name");
                dtbl6.Columns.Add("Credit");
                foreach (var item in adaptor6)
                {
                    DataRow row = dtbl6.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = Convert.ToDecimal(item.Credit);

                    dtbl6.Rows.Add(row);
                }
                dts.Tables.Add(dtbl6);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dts;
        }

        public decimal StockValueGetOnDate(DateTime date, DateTime dtToDate, string calculationMethod, bool isOpeningStock, bool isFromBalanceSheet)
        {
            IMEEntities IME = new IMEEntities();
            decimal dcstockValue = 0;
            try
            {
                if (calculationMethod == "FIFO")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = IME.StockValueOnDateByFIFOForOpeningStock(date, dtToDate);
                        }
                        else
                        {
                            dcstockValue = IME.StockValueOnDateByFIFOForOpeningStockForBalancesheet(date, dtToDate);
                        }
                    }
                    else
                    {
                        dcstockValue = IME.StockValueOnDateByFIFO(date);
                    }
                }
                else if (calculationMethod == "Average Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = IME.StockValueOnDateByAVCOForOpeningStock(date, dtToDate);
                        }
                        else
                        {
                            dcstockValue = IME.StockValueOnDateByAVCOForOpeningStockForBalanceSheet(date, dtToDate);
                        }
                    }
                    else
                    {
                        dcstockValue = IME.StockValueOnDateByAVCO(date);
                    }
                }
                else if (calculationMethod == "High Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByHighCostForOpeningStock(date, dtToDate));
                        }
                        else
                        {
                            dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByHighCostForOpeningStockBlncSheet(date, dtToDate));
                        }
                    }
                    else
                    {
                        dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByHighCost(date));
                    }
                }
                else if (calculationMethod == "Low Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = IME.StockValueOnDateByLowCostForOpeningStock(date, dtToDate);
                        }
                        else
                        {
                            dcstockValue = IME.StockValueOnDateByLowCostForOpeningStockForBlncSheet(date, dtToDate);
                        }
                    }
                    else
                    {
                        dcstockValue = IME.StockValueOnDateByLowCost(date);
                    }
                }
                else if (calculationMethod == "Last Purchase Rate")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByLastPurchaseRateForOpeningStock(date, dtToDate));
                        }
                        else
                        {
                            dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByLastPurchaseRateForOpeningStockBlncSheet(date, dtToDate));
                        }
                    }
                    else
                    {
                        dcstockValue = Convert.ToDecimal(IME.StockValueOnDateByLastPurchaseRate(date));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dcstockValue;
        }

        public DataTable ProfitAndLossReportPrintCompany(decimal decCompanyId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.ProfitAndLossReportPrintCompany(decCompanyId).ToList();

                dtbl.Columns.Add("companyName");
                dtbl.Columns.Add("address");
                dtbl.Columns.Add("phone");
                dtbl.Columns.Add("email");
                dtbl.Columns.Add("currencyName");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["companyName"] = item.companyName;
                    row["address"] = item.address;
                    row["phone"] = item.phone;
                    row["email"] = item.email;
                    row["currencyName"] = item.currencyName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtbl;
        }

        public System.Data.DataSet FundFlow(DateTime fromDate, DateTime toDate)
        {
            IMEEntities IME = new IMEEntities();
            System.Data.DataSet dts = new System.Data.DataSet();
            dts.Tables.Add(new DataTable());
            try
            {
                DataTable dtbl1 = new DataTable();

                var adaptor1 = (IME.FundFlow1(fromDate, toDate)).ToList();
                dtbl1.Columns.Add("ID");
                dtbl1.Columns.Add("Name");
                dtbl1.Columns.Add("Balance");
                foreach (var item in adaptor1)
                {
                    DataRow row = dtbl1.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dtbl1.Rows.Add(row);
                }
                dts.Tables.Add(dtbl1);



                DataTable dtbl2 = new DataTable();
                var adaptor2 = (IME.FundFlow2(fromDate, toDate)).ToList();
                dtbl2.Columns.Add("ID");
                dtbl2.Columns.Add("Name");
                dtbl2.Columns.Add("Balance");
                foreach (var item in adaptor2)
                {
                    DataRow row = dtbl2.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dtbl2.Rows.Add(row);
                }
                dts.Tables.Add(dtbl2);


                DataTable dtbl3 = new DataTable();
                var adaptor3 = (IME.FundFlow3(fromDate, toDate)).ToList();
                dtbl3.Columns.Add("ID");
                dtbl3.Columns.Add("Name");
                dtbl3.Columns.Add("OpeningBalance");
                dtbl3.Columns.Add("debit");
                dtbl3.Columns.Add("credit");
                dtbl3.Columns.Add("ClosingBalance");
                foreach (var item in adaptor3)
                {
                    DataRow row = dtbl3.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["OpeningBalance"] = item.OpeningBalance;
                    row["Debit"] = item.debit;
                    row["Credit"] = item.credit;
                    row["ClosingBalance"] = item.ClosingBalance;

                    dtbl3.Rows.Add(row);
                }
                dts.Tables.Add(dtbl3);



                DataTable dtbl4 = new DataTable();
                var adaptor4 = (IME.FundFlow4(fromDate, toDate)).ToList();
                dtbl4.Columns.Add("ID");
                dtbl4.Columns.Add("Name");
                dtbl4.Columns.Add("OpeningBalance");
                dtbl4.Columns.Add("ClosingBalance");
                foreach (var item in adaptor4)
                {
                    DataRow row = dtbl4.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["OpeningBalance"] = item.OpeningBalance;
                    row["ClosingBalance"] = item.ClosingBalance;

                    dtbl4.Rows.Add(row);
                }
                dts.Tables.Add(dtbl4);


                DataTable dtbl5 = new DataTable();
                var adaptor5 = (IME.FundFlow5(fromDate, toDate)).ToList();
                dtbl5.Columns.Add("ID");
                dtbl5.Columns.Add("Name");
                dtbl5.Columns.Add("OpeningBalance");
                dtbl5.Columns.Add("debit");
                dtbl5.Columns.Add("credit");
                dtbl5.Columns.Add("ClosingBalance");
                foreach (var item in adaptor5)
                {
                    DataRow row = dtbl5.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["OpeningBalance"] = item.OpeningBalance;
                    row["debit"] = item.debit;
                    row["credit"] = item.credit;
                    row["ClosingBalance"] = item.ClosingBalance;

                    dtbl5.Rows.Add(row);
                }
                dts.Tables.Add(dtbl5);


                DataTable dtbl6 = new DataTable();
                var adaptor6 = (IME.FundFlow6(fromDate, toDate)).ToList();
                dtbl6.Columns.Add("ID");
                dtbl6.Columns.Add("Name");
                dtbl6.Columns.Add("OpeningBalance");
                dtbl6.Columns.Add("ClosingBalance");
                foreach (var item in adaptor6)
                {
                    DataRow row = dtbl6.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["OpeningBalance"] = item.OpeningBalance;
                    row["ClosingBalance"] = item.ClosingBalance;

                    dtbl6.Rows.Add(row);
                }
                dts.Tables.Add(dtbl6);
            }
            catch (Exception)
            {
                throw;
            }
            return dts;
        }

        public DataTable DayBook(DateTime dtFromDate, DateTime dtToDate, decimal decVoucherTypeId, decimal decLedgerId, bool blCondenced)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl No");
            try
            {
                var adaptor = IME.DayBook(dtFromDate, dtToDate, decVoucherTypeId, decLedgerId, blCondenced).ToList();

                dtbl.Columns.Add("Date");
                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("voucherNo");
                dtbl.Columns.Add("Voucher_Type");
                dtbl.Columns.Add("Invoice_No");
                dtbl.Columns.Add("typeOfVoucher");
                dtbl.Columns.Add("Ledger");
                dtbl.Columns.Add("Debit");
                dtbl.Columns.Add("Credit");
                dtbl.Columns.Add("Inward_Qty");
                dtbl.Columns.Add("Outward_Qty");
                dtbl.Columns.Add("MasterId");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["Date"] = item.Date;
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["voucherNo"] = item.voucherNo;
                    row["Voucher_Type"] = item.Voucher_Type;
                    row["Invoice_No"] = item.Invoice_No;
                    row["typeOfVoucher"] = item.typeOfVoucher;
                    row["Ledger"] = item.Ledger;
                    row["Debit"] = item.Debit;
                    row["Credit"] = item.Credit;
                    row["Inward_Qty"] = item.Inward_Qty;
                    row["Outward_Qty"] = item.Outward_Qty;
                    row["MasterId"] = item.MasterId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtbl;
        }

        public DataTable DayBookReportPrintCompany()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.DayBookReportPrintCompany().ToList();

                dtbl.Columns.Add("companyName");
                dtbl.Columns.Add("address");
                dtbl.Columns.Add("phone");
                dtbl.Columns.Add("email");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["companyName"] = item.companyName;
                    row["address"] = item.address;
                    row["phone"] = item.phone;
                    row["email"] = item.email;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtbl;
        }

        public DataTable CashflowReportPrintCompany(decimal decCompanyId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.CashFlowReportPrintCompany().ToList();


                dtbl.Columns.Add("companyName");
                dtbl.Columns.Add("address");
                dtbl.Columns.Add("phone");
                dtbl.Columns.Add("email");
                dtbl.Columns.Add("currencyName");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["companyName"] = item.companyName;
                    row["address"] = item.address;
                    row["phone"] = item.phone;
                    row["email"] = item.email;
                    row["currencyName"] = item.currencyName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtbl;
        }

        public DataTable CashOrBankBookGridFill(DateTime fromDate, DateTime toDate, bool isShowOpBalance)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.CashOrBankBookGridFill(fromDate, toDate, isShowOpBalance).ToList();


                dtbl.Columns.Add("accountGroupId");
                dtbl.Columns.Add("SlNO");
                dtbl.Columns.Add("accountGroupName");
                dtbl.Columns.Add("Opening");
                dtbl.Columns.Add("op");
                dtbl.Columns.Add("Credit");
                dtbl.Columns.Add("Debit");
                dtbl.Columns.Add("Balance");


                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["SlNO"] = item.SlNO;
                    row["accountGroupName"] = item.accountGroupName;
                    row["Opening"] = item.Opening;
                    row["op"] = item.op;
                    row["Credit"] = item.Credit;
                    row["Debit"] = item.Debit;
                    row["Balance"] = item.Balance;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CB01" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }

        /// <summary>
        /// Function to Profit And Loss Analysis UpTo a Date For Previous Years
        /// </summary>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public System.Data.DataSet ProfitAndLossAnalysisUpToaDateForPreviousYears(DateTime toDate)
        {
            IMEEntities db = new IMEEntities();
            System.Data.DataSet dset = new System.Data.DataSet();
            try
            {
                DataTable dt1 = new DataTable();
                var adaptor1 = db.ProfitAndLossAnalysisUpToaDateForPreviousYearsPurchaseAccount(toDate).ToList();

                dt1.Columns.Add("ID");
                dt1.Columns.Add("Name");
                dt1.Columns.Add("Debit");

                foreach (var item in adaptor1)
                {
                    DataRow row = dt1.NewRow();

                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = item.Debit;

                    dt1.Rows.Add(row);
                }
                dset.Tables.Add(dt1);

                DataTable dt2 = new DataTable();
                var adaptor2 = db.ProfitAndLossAnalysisUpToaDateForPreviousYearsSalesAccount(toDate).ToList();

                dt2.Columns.Add("ID");
                dt2.Columns.Add("Name");
                dt2.Columns.Add("Credit");

                foreach (var item in adaptor2)
                {
                    DataRow row = dt2.NewRow();

                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = item.Credit;

                    dt2.Rows.Add(row);
                }
                dset.Tables.Add(dt2);

                DataTable dt3 = new DataTable();
                var adaptor3 = db.ProfitAndLossAnalysisUpToaDateForPreviousYearsDirectExpenses(toDate).ToList();

                dt3.Columns.Add("ID");
                dt3.Columns.Add("Name");
                dt3.Columns.Add("Debit");

                foreach (var item in adaptor3)
                {
                    DataRow row = dt3.NewRow();

                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = item.Debit;

                    dt3.Rows.Add(row);
                }
                dset.Tables.Add(dt3);

                DataTable dt4 = new DataTable();
                var adaptor4 = db.ProfitAndLossAnalysisUpToaDateForPreviousYearsDirectIncome(toDate).ToList();

                dt4.Columns.Add("ID");
                dt4.Columns.Add("Name");
                dt4.Columns.Add("Credit");

                foreach (var item in adaptor4)
                {
                    DataRow row = dt4.NewRow();

                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = item.Credit;

                    dt4.Rows.Add(row);
                }
                dset.Tables.Add(dt4);

                DataTable dt5 = new DataTable();
                var adaptor5 = db.ProfitAndLossAnalysisUpToaDateForPreviousYearsIndirectExpenses(toDate).ToList();

                dt5.Columns.Add("ID");
                dt5.Columns.Add("Name");
                dt5.Columns.Add("Debit");

                foreach (var item in adaptor5)
                {
                    DataRow row = dt5.NewRow();

                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = item.Debit;

                    dt5.Rows.Add(row);
                }
                dset.Tables.Add(dt5);

                DataTable dt6 = new DataTable();
                var adaptor6 = db.ProfitAndLossAnalysisUpToaDateForPreviousYearsIndirectIncome(toDate).ToList();

                dt6.Columns.Add("ID");
                dt6.Columns.Add("Name");
                dt6.Columns.Add("Credit");

                foreach (var item in adaptor6)
                {
                    DataRow row = dt6.NewRow();

                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = item.Credit;

                    dt6.Rows.Add(row);
                }
                dset.Tables.Add(dt6);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dset;
        }

        public System.Data.DataSet CashFlow(DateTime strfromDate, DateTime strtoDate)
        {
            IMEEntities db = new IMEEntities();
            System.Data.DataSet dset = new System.Data.DataSet();
            try
            {
                DataTable dt1 = new DataTable();
                var adaptor1 = db.CashFlow1(strfromDate, strtoDate).ToList();

                dt1.Columns.Add("accountGroupId");
                dt1.Columns.Add("accountGroupName");
                dt1.Columns.Add("Balance");

                foreach (var item in adaptor1)
                {
                    DataRow row = dt1.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["Balance"] = item.Balance;

                    dt1.Rows.Add(row);
                }
                dset.Tables.Add(dt1);

                DataTable dt2 = new DataTable();
                var adaptor2 = db.CashFlow2(strfromDate, strtoDate).ToList();

                dt2.Columns.Add("accountGroupId");
                dt2.Columns.Add("accountGroupName");
                dt2.Columns.Add("Balance");

                foreach (var item in adaptor2)
                {
                    DataRow row = dt2.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["Balance"] = item.Balance;


                    dt2.Rows.Add(row);
                }
                dset.Tables.Add(dt2);

                DataTable dt3 = new DataTable();
                var adaptor3 = db.CashFlow3(strfromDate, strtoDate).ToList();

                dt3.Columns.Add("accountGroupId");
                dt3.Columns.Add("accountGroupName");
                dt3.Columns.Add("Balance");

                foreach (var item in adaptor3)
                {
                    DataRow row = dt3.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["Balance"] = item.Balance;


                    dt3.Rows.Add(row);
                }
                dset.Tables.Add(dt3);

                DataTable dt4 = new DataTable();
                var adaptor4 = db.CashFlow4(strfromDate, strtoDate).ToList();

                dt4.Columns.Add("accountGroupId");
                dt4.Columns.Add("accountGroupName");
                dt4.Columns.Add("Balance");

                foreach (var item in adaptor4)
                {
                    DataRow row = dt4.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["Balance"] = item.Balance;

                    dt4.Rows.Add(row);
                }
                dset.Tables.Add(dt4);

                DataTable dt5 = new DataTable();
                var adaptor5 = db.CashFlow5(strfromDate, strtoDate).ToList();

                dt5.Columns.Add("accountGroupId");
                dt5.Columns.Add("accountGroupName");
                dt5.Columns.Add("Balance");

                foreach (var item in adaptor5)
                {
                    DataRow row = dt5.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["Balance"] = item.Balance;

                    dt5.Rows.Add(row);
                }
                dset.Tables.Add(dt5);

                DataTable dt6 = new DataTable();
                var adaptor6 = db.CashFlow6(strfromDate, strtoDate).ToList();

                dt6.Columns.Add("accountGroupId");
                dt6.Columns.Add("accountGroupName");
                dt6.Columns.Add("Balance");

                foreach (var item in adaptor6)
                {
                    DataRow row = dt6.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["Balance"] = item.Balance;

                    dt6.Rows.Add(row);
                }
                dset.Tables.Add(dt6);

                DataTable dt7 = new DataTable();
                var adaptor7 = db.CashFlow7(strfromDate, strtoDate).ToList();

                dt7.Columns.Add("accountGroupId");
                dt7.Columns.Add("accountGroupName");
                dt7.Columns.Add("Balance");

                foreach (var item in adaptor7)
                {
                    DataRow row = dt7.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["Balance"] = item.Balance;

                    dt7.Rows.Add(row);
                }
                dset.Tables.Add(dt7);

                DataTable dt8 = new DataTable();
                var adaptor8 = db.CashFlow8(strfromDate, strtoDate).ToList();

                dt8.Columns.Add("accountGroupId");
                dt8.Columns.Add("accountGroupName");
                dt8.Columns.Add("Balance");

                foreach (var item in adaptor8)
                {
                    DataRow row = dt8.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName"] = item.accountGroupName;
                    row["Balance"] = item.Balance;


                    dt8.Rows.Add(row);
                }
                dset.Tables.Add(dt8);

                DataTable dt9 = new DataTable();
                var adaptor9 = db.CashFlow9(strfromDate, strtoDate).ToList();

                dt9.Columns.Add("accountGroupId");
                dt9.Columns.Add("accountGroupName1");
                dt9.Columns.Add("Balance1");

                foreach (var item in adaptor9)
                {
                    DataRow row = dt9.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName1"] = item.accountGroupName1;
                    row["Balance1"] = item.Balance1;


                    dt9.Rows.Add(row);
                }
                dset.Tables.Add(dt9);

                DataTable dt10 = new DataTable();
                var adaptor10 = db.CashFlow10(strfromDate, strtoDate).ToList();

                dt10.Columns.Add("accountGroupId");
                dt10.Columns.Add("accountGroupName1");
                dt10.Columns.Add("Balance1");

                foreach (var item in adaptor10)
                {
                    DataRow row = dt10.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName1"] = item.accountGroupName1;
                    row["Balance1"] = item.Balance1;

                    dt10.Rows.Add(row);
                }
                dset.Tables.Add(dt10);

                DataTable dt11 = new DataTable();
                var adaptor11 = db.CashFlow11(strfromDate, strtoDate).ToList();

                dt11.Columns.Add("accountGroupId");
                dt11.Columns.Add("accountGroupName1");
                dt11.Columns.Add("Balance1");

                foreach (var item in adaptor11)
                {
                    DataRow row = dt11.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName1"] = item.accountGroupName1;
                    row["Balance1"] = item.Balance1;

                    dt11.Rows.Add(row);
                }
                dset.Tables.Add(dt11);

                DataTable dt12 = new DataTable();
                var adaptor12 = db.CashFlow12(strfromDate, strtoDate).ToList();

                dt12.Columns.Add("accountGroupId");
                dt12.Columns.Add("accountGroupName1");
                dt12.Columns.Add("Balance1");

                foreach (var item in adaptor12)
                {
                    DataRow row = dt12.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName1"] = item.accountGroupName1;
                    row["Balance1"] = item.Balance1;

                    dt12.Rows.Add(row);
                }
                dset.Tables.Add(dt12);

                DataTable dt13 = new DataTable();
                var adaptor13 = db.CashFlow13(strfromDate, strtoDate).ToList();

                dt13.Columns.Add("accountGroupId");
                dt13.Columns.Add("accountGroupName1");
                dt13.Columns.Add("Balance1");

                foreach (var item in adaptor13)
                {
                    DataRow row = dt13.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName1"] = item.accountGroupName1;
                    row["Balance1"] = item.Balance1;

                    dt13.Rows.Add(row);
                }
                dset.Tables.Add(dt13);

                DataTable dt14 = new DataTable();
                var adaptor14 = db.CashFlow14(strfromDate, strtoDate).ToList();

                dt14.Columns.Add("accountGroupId");
                dt14.Columns.Add("accountGroupName1");
                dt14.Columns.Add("Balance1");

                foreach (var item in adaptor14)
                {
                    DataRow row = dt14.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName1"] = item.accountGroupName1;
                    row["Balance1"] = item.Balance1;

                    dt14.Rows.Add(row);
                }
                dset.Tables.Add(dt14);

                DataTable dt15 = new DataTable();
                var adaptor15 = db.CashFlow12(strfromDate, strtoDate).ToList();

                dt15.Columns.Add("accountGroupId");
                dt15.Columns.Add("accountGroupName1");
                dt15.Columns.Add("Balance1");

                foreach (var item in adaptor15)
                {
                    DataRow row = dt15.NewRow();

                    row["accountGroupId"] = item.accountGroupId;
                    row["accountGroupName1"] = item.accountGroupName1;
                    row["Balance1"] = item.Balance1;

                    dt15.Rows.Add(row);
                }
                dset.Tables.Add(dt15);
            }
            catch (Exception)
            {
                throw;
            }
            return dset;
        }
    }
}
