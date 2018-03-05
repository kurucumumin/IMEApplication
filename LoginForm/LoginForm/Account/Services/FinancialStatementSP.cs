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


                DataTable dtbl5 = new DataTable();
                var adaptor5 = (IME.BalanceSheetDifference(fromDate, toDate)).ToList();

                foreach (var item in adaptor5)
                {
                    DataRow row = dtbl5.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["Balance"] = item.Balance;

                    dts.Tables[4].Rows.Add(row);
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

        public System.Data.DataSet ProfitAndLossAnalysis(DateTime fromDate, DateTime toDate)
        {
            IMEEntities IME = new IMEEntities();
            System.Data.DataSet dts = new System.Data.DataSet();
            dts.Tables.Add(new DataTable());
            try
            {
                DataTable dtbl1 = new DataTable();

                var adaptor1 = (IME.ProfitAndLossAnalysisPurchaseAccount(fromDate, toDate)).ToList();
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
                var adaptor2 = (IME.ProfitAndLossAnalysisSalesAccount(fromDate, toDate)).ToList();

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
                var adaptor3 = (IME.ProfitAndLossAnalysisDirectExpenses(fromDate, toDate)).ToList();

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
                var adaptor4 = (IME.ProfitAndLossAnalysisDirectIncome(fromDate, toDate)).ToList();

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
                var adaptor5 = (IME.ProfitAndLossAnalysisInDirectExpenses(fromDate, toDate)).ToList();

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
                var adaptor6 = (IME.ProfitAndLossAnalysisInDirectIncome(fromDate, toDate)).ToList();

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
                var adaptor2 = (IME.FundFlow2(fromDate, toDate)).ToList();

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
                var adaptor3 = (IME.FundFlow3(fromDate, toDate)).ToList();

                foreach (var item in adaptor3)
                {
                    DataRow row = dtbl3.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["OpeningBalance"] = item.OpeningBalance;
                    row["Debit"] = item.debit;
                    row["Credit"] = item.credit;
                    row["ClosingBalance"] = item.ClosingBalance;

                    dts.Tables[2].Rows.Add(row);
                }
                dts.Tables.Add(dtbl3);



                DataTable dtbl4 = new DataTable();
                var adaptor4 = (IME.FundFlow4(fromDate, toDate)).ToList();

                foreach (var item in adaptor4)
                {
                    DataRow row = dtbl4.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["OpeningBalance"] = item.OpeningBalance;
                    row["ClosingBalance"] = item.ClosingBalance;

                    dts.Tables[3].Rows.Add(row);
                }
                dts.Tables.Add(dtbl4);


                DataTable dtbl5 = new DataTable();
                var adaptor5 = (IME.FundFlow5(fromDate, toDate)).ToList();

                foreach (var item in adaptor5)
                {
                    DataRow row = dtbl5.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["OpeningBalance"] = item.OpeningBalance;
                    row["Debit"] = item.debit;
                    row["Credit"] = item.credit;
                    row["ClosingBalance"] = item.ClosingBalance;

                    dts.Tables[4].Rows.Add(row);
                }
                dts.Tables.Add(dtbl5);


                DataTable dtbl6 = new DataTable();
                var adaptor6 = (IME.FundFlow6(fromDate, toDate)).ToList();

                foreach (var item in adaptor6)
                {
                    DataRow row = dtbl6.NewRow();
                    row["ID"] = item.ID;
                    row["Name"] = item.Name;
                    row["OpeningBalance"] = item.OpeningBalance;
                    row["ClosingBalance"] = item.ClosingBalance;

                    dts.Tables[5].Rows.Add(row);
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
                var adaptor = IME.CashflowReportPrintCompany(decCompanyId).ToList();

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
    }
}
