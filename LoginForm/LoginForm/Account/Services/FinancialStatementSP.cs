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
                foreach (var item in adaptor1)
                {
                    DataRow row = dtbl1.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dts.Tables[0].Rows.Add(row);
                }
                dts.Tables.Add(dtbl1);



                DataTable dtbl2 = new DataTable();
                var adaptor2 = (IME.BalanceSheetLiabilities(fromDate, toDate)).ToList();

                foreach (var item in adaptor2)
                {
                    DataRow row = dtbl2.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dts.Tables[1].Rows.Add(row);
                }
                dts.Tables.Add(dtbl2);


                DataTable dtbl3 = new DataTable();
                var adaptor3 = (IME.BalanceSheetProfitAndLossAccount(fromDate, toDate)).ToList();

                foreach (var item in adaptor3)
                {
                    DataRow row = dtbl3.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dts.Tables[2].Rows.Add(row);
                }
                dts.Tables.Add(dtbl3);



                DataTable dtbl4 = new DataTable();
                var adaptor4 = (IME.BalanceSheetProfitAndLoss(fromDate, toDate)).ToList();

                foreach (var item in adaptor4)
                {
                    DataRow row = dtbl4.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dts.Tables[3].Rows.Add(row);
                }
                dts.Tables.Add(dtbl4);


                //DataTable dtbl5 = new DataTable();
                //var adaptor5 = (IME.BalanceSheetDifference(fromDate, toDate)).ToList();

                //foreach (var item in adaptor5)
                //{
                //    DataRow row = dtbl5.NewRow();
                //    row["ID"] = item.ID;
                //    row["Name"] = item.Name;
                //    row["Debit"] = item.Debit;

                //    dts.Tables[4].Rows.Add(row);
                //}
                //dts.Tables.Add(dtbl5);
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
                    
                    dts.Tables[0].Rows.Add(row);
                }
                dts.Tables.Add(dtbl);


                DataTable dtbl2 = new DataTable();
                var adaptor2 = (IME.Trialbalance2(decAccountGroupId, fromDate, toDate)).ToList();

                foreach (var item in adaptor2)
                {
                    DataRow row = dtbl.NewRow();

                    
                    row["Name"] = item.Name;
                    row["credit"] = item.credit;
                    row["debit"] = item.debit;
                    row["OpeningBalance"] = item.OpeningBalance;
                   

                    dts.Tables[0].Rows.Add(row);
                }
                dts.Tables.Add(dtbl2);


                DataTable dtbl3 = new DataTable();
                var adaptor3 = (IME.Trialbalance3(decAccountGroupId, fromDate, toDate)).ToList();

                foreach (var item in adaptor3)
                {
                    DataRow row = dtbl.NewRow();

                    
                    row["Name"] = item.Name;
                    row["credit"] = item.credit;
                    row["debit"] = item.debit;
                    row["OpeningBalance"] = item.OpeningBalance;
                    

                    dts.Tables[0].Rows.Add(row);
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

                var adaptor1 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetPurchaseAcount(fromDate, toDate)).ToList();
                foreach (var item in adaptor1)
                {
                    DataRow row = dtbl1.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = item.Debit;

                    dts.Tables[0].Rows.Add(row);
                }
                dts.Tables.Add(dtbl1);



                DataTable dtbl2 = new DataTable();
                var adaptor2 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetSalesAcount(fromDate, toDate)).ToList();

                foreach (var item in adaptor2)
                {
                    DataRow row = dtbl2.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = item.Credit;

                    dts.Tables[1].Rows.Add(row);
                }
                dts.Tables.Add(dtbl2);


                DataTable dtbl3 = new DataTable();
                var adaptor3 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetDirectExpenses(fromDate, toDate)).ToList();

                foreach (var item in adaptor3)
                {
                    DataRow row = dtbl3.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = item.Debit;

                    dts.Tables[2].Rows.Add(row);
                }
                dts.Tables.Add(dtbl3);



                DataTable dtbl4 = new DataTable();
                var adaptor4 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetDirectincome(fromDate, toDate)).ToList();

                foreach (var item in adaptor4)
                {
                    DataRow row = dtbl4.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = item.Credit;

                    dts.Tables[3].Rows.Add(row);
                }
                dts.Tables.Add(dtbl4);


                DataTable dtbl5 = new DataTable();
                var adaptor5 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetIndirectExpenses(fromDate, toDate)).ToList();

                foreach (var item in adaptor5)
                {
                    DataRow row = dtbl5.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Debit"] = item.Debit;

                    dts.Tables[4].Rows.Add(row);
                }
                dts.Tables.Add(dtbl5);


                DataTable dtbl6 = new DataTable();
                var adaptor6 = (IME.ProfitAndLossAnalysisUpToaDateForBalansheetIndirectincome(fromDate, toDate)).ToList();

                foreach (var item in adaptor6)
                {
                    DataRow row = dtbl6.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Credit"] = item.Credit;

                    dts.Tables[5].Rows.Add(row);
                }
                dts.Tables.Add(dtbl6);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dts;
        }
    }
}
