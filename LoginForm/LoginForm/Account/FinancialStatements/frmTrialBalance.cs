﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using LoginForm.DataSet;
using LoginForm.Services;
using LoginForm.Account.Services;

namespace LoginForm.Account
{
    public partial class frmTrialBalance : Form
    {
        #region Public Variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        bool isFormLoad = false;
        int inCurrenRowIndex = 0;
        int inCurrentColIndex = 0;
        # endregion
        #region Functions
        /// <summary>
        /// Creates an instance of frmTrialBalance class
        /// </summary>
        public frmTrialBalance()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to reset form
        /// </summary>
        public void Clear()
        {
            try
            {
                isFormLoad = true;
                dtpTrialFromDate.MinDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                dtpTrialFromDate.MaxDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate);
                dtpTrialFromDate.Value = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                ddtpTrialToDate.MinDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                ddtpTrialToDate.MaxDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate);
                ddtpTrialToDate.Value = Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate);
                dtpTrialFromDate.Text = dtpTrialFromDate.Value.ToString("dd-MMM-yyyy");
                ddtpTrialToDate.Text = ddtpTrialToDate.Value.ToString("dd-MMM-yyyy");
                txtTodate.Text = ddtpTrialToDate.Value.ToString("dd-MMM-yyyy");
                isFormLoad = false;
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:1" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill Datagridview after calculation
        /// </summary>
        public void GridFill()
        {
            try
            {
                if (!isFormLoad)
                {
                    string calculationMethod = string.Empty;
                    Setting InfoSettings = new Setting();
                    SettingsSP SpSettings = new SettingsSP();
                    //--------------- Selection Of Calculation Method According To Settings ------------------// 
                    if (SpSettings.SettingsStatusCheck("StockValueCalculationMethod") == "FIFO")
                    {
                        calculationMethod = "FIFO";
                    }
                    else if (SpSettings.SettingsStatusCheck("StockValueCalculationMethod") == "Average Cost")
                    {
                        calculationMethod = "Average Cost";
                    }
                    else if (SpSettings.SettingsStatusCheck("StockValueCalculationMethod") == "High Cost")
                    {
                        calculationMethod = "High Cost";
                    }
                    else if (SpSettings.SettingsStatusCheck("StockValueCalculationMethod") == "Low Cost")
                    {
                        calculationMethod = "Low Cost";
                    }
                    else if (SpSettings.SettingsStatusCheck("StockValueCalculationMethod") == "Last Purchase Rate")
                    {
                        calculationMethod = "Last Purchase Rate";
                    }
                    FinancialStatementSP SpFinance1 = new FinancialStatementSP();
                    DataTable dtbl1 = new DataTable();
                    Currency InfoCurrency = new Currency();
                    CurrencySP SpCurrency = new CurrencySP();
                    int inDecimalPlaces = 4;
                    decimal dcClosingStock = SpFinance1.StockValueGetOnDate(Convert.ToDateTime(txtTodate.Text), calculationMethod, false, false);
                    dcClosingStock = Math.Round(dcClosingStock, inDecimalPlaces);
                    //---------------------Opening Stock-----------------------
                    decimal dcOpeninggStock = SpFinance1.StockValueGetOnDate(Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate), calculationMethod, true, true);
                    decimal dcProfit = 0;
                    System.Data.DataSet dsetProfitAndLoss = new System.Data.DataSet();
                    dsetProfitAndLoss = SpFinance1.ProfitAndLossAnalysisUpToaDateForBalansheet(Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate), DateTime.Parse(txtTodate.Text));
                    DataTable dtblProfit = new DataTable();
                    dtblProfit = dsetProfitAndLoss.Tables[0];
                    for (int i = 0; i < dsetProfitAndLoss.Tables.Count; ++i)
                    {
                        dtbl1 = dsetProfitAndLoss.Tables[i];
                        decimal dcSum = 0;
                        if (i == 0 || (i % 2) == 0)
                        {
                            if (dtbl1.Rows.Count > 0)
                            {
                                dcSum = dtbl1.AsEnumerable().Sum(x => Convert.ToDecimal(x["Debit"]));
                            }
                        }
                        else
                        {
                            if (dtbl1.Rows.Count > 0)
                            {
                                dcSum = dtbl1.AsEnumerable().Sum(x => Convert.ToDecimal(x["Credit"]));
                            }
                        }
                    }
                    DateValidation objValidation = new DateValidation();
                    objValidation.DateValidationFunction(txtTodate);
                    if (txtTodate.Text == string.Empty)
                        txtTodate.Text = Utils.getManagement().FinancialYear.toDate.Value.ToString("dd-MMM-yyyy");
                    Font newFont = new Font(dgvTrailBalance.Font, FontStyle.Bold);
                    FinancialStatementSP SpFinance = new FinancialStatementSP();
                    System.Data.DataSet DsetTrailbalance = new System.Data.DataSet();
                    DataTable dtbl = new DataTable();
                    decimal dcTotalCredit = 0;
                    decimal dcTotalDebit = 0;
                    DateValidation objvalidation = new DateValidation();
                    objvalidation.DateValidationFunction(txtFromDate);
                    if (txtFromDate.Text == string.Empty)
                    {
                        txtFromDate.Text = Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy");
                    }
                    objvalidation.DateValidationFunction(txtTodate);
                    if (txtTodate.Text == string.Empty)
                    {
                        txtTodate.Text = Utils.getManagement().FinancialYear.toDate.Value.ToString("dd-MMM-yyyy");
                    }
                    DataTable dtblTrail = new DataTable();
                    DataTable dtblTrail1 = new DataTable();
                    DataTable dtblProfitAndLossAcc = new DataTable();
                    DataTable dtblProfitAndLossAcc1 = new DataTable();
                    System.Data.DataSet dsTrial = new System.Data.DataSet();
                    Font newfont = new Font(dgvTrailBalance.Font, FontStyle.Bold);
                    FinancialStatementSP spfinancial = new FinancialStatementSP();
                    dgvTrailBalance.Rows.Clear();
                    dsTrial = spfinancial.TrialBalance(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtTodate.Text), 0);
                    dtblTrail = dsTrial.Tables[0];
                    dtblProfitAndLossAcc = dsTrial.Tables[1];
                    if (dgvTrailBalance.RowCount > 0)
                    {
                        dcTotalCredit = dtblTrail.AsEnumerable().Sum(x => Convert.ToDecimal(x["Credit"]));
                        dcTotalDebit = dtblTrail.AsEnumerable().Sum(x => Convert.ToDecimal(x["Debit"]));
                    }
                    for (int i = 0; i < dtblTrail.Rows.Count; ++i)
                    {
                        dgvTrailBalance.Rows.Add();
                        if (Convert.ToDecimal(dtblTrail.Rows[i]["accountGroupId"].ToString()) != 6)
                        {
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtAccountGroupId"].Value = dtblTrail.Rows[i]["accountGroupId"];
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["accountGroupName"].Value = dtblTrail.Rows[i]["name"];
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["openingBalance"].Value = dtblTrail.Rows[i]["OpeningBalance"];
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtBalance"].Value = dtblTrail.Rows[i]["Balance"];
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["credit"].Value = dtblTrail.Rows[i]["credit"];
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["debit"].Value = dtblTrail.Rows[i]["debit"];
                            dcTotalCredit += decimal.Parse(dtblTrail.Rows[i]["credit"].ToString());
                            dcTotalDebit += decimal.Parse(dtblTrail.Rows[i]["debit"].ToString());
                        }
                        else
                        {
                            decimal decOpBalance = dcOpeninggStock + Convert.ToDecimal(dtblTrail.Rows[i]["OpBalance"].ToString());
                            decimal decBalance = dcOpeninggStock + Convert.ToDecimal(dtblTrail.Rows[i]["Balance1"].ToString());
                            string strOpBalance = string.Empty;
                            string strBalance = string.Empty;
                            if (decOpBalance < 0)
                            {
                                strOpBalance = Math.Round(decOpBalance, 4).ToString() + "Cr";
                            }
                            else
                            {
                                strOpBalance = Math.Round(decOpBalance, 4).ToString() + "Dr";
                            }
                            if (decBalance < 0)
                            {
                                strBalance = Math.Round(decBalance, 4).ToString() + "Cr";
                            }
                            else
                            {
                                strBalance = Math.Round(decBalance, 4).ToString() + "Dr";
                            }
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtAccountGroupId"].Value = dtblTrail.Rows[i]["accountGroupId"];
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["accountGroupName"].Value = dtblTrail.Rows[i]["name"];
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["openingBalance"].Value = strOpBalance;
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtBalance"].Value = strBalance;
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["credit"].Value = dtblTrail.Rows[i]["credit"];
                            dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["debit"].Value = dtblTrail.Rows[i]["debit"];
                            dcTotalCredit += decimal.Parse(dtblTrail.Rows[i]["credit"].ToString());
                            dcTotalDebit += decimal.Parse(dtblTrail.Rows[i]["debit"].ToString());
                        }
                    }
                    decimal OpeningProfit;
                    dtblProfitAndLossAcc1 = dsTrial.Tables[2];
                    if (dgvTrailBalance.RowCount > 0)
                    {
                        decimal dcTotalCredit1 = dtblTrail.AsEnumerable().Sum(x => Convert.ToDecimal(x["Credit"]));
                        decimal dcTotalDebit1 = dtblTrail.AsEnumerable().Sum(x => Convert.ToDecimal(x["Debit"]));
                        OpeningProfit = dcTotalCredit1 + dcTotalDebit1;
                    }
                    System.Data.DataSet DsetBalanceSheet = new System.Data.DataSet();
                    DsetBalanceSheet = SpFinance.BalanceSheet(Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate), DateTime.Parse(txtTodate.Text));
                    DataTable dtblProf = new DataTable();
                    decimal dcProfitOpening = 0;
                    dtblProf = DsetBalanceSheet.Tables[2];
                    decimal decProfitLedger = 0;
                    if (dtblProf.Rows.Count > 0)
                    {
                        
                        decProfitLedger = dtblProf.AsEnumerable().Sum(x => Convert.ToDecimal(x["Balance"]));
                    }
                    DataTable dtblProfitLedgerOpening = new DataTable();
                    dtblProfitLedgerOpening = DsetBalanceSheet.Tables[3];
                    decimal decProfitLedgerOpening = 0;
                    foreach (DataRow dRow in dtblProfitLedgerOpening.Rows)
                    {
                        decProfitLedgerOpening += decimal.Parse(dRow["Balance"].ToString());
                    }
                    decimal decTotalProfitAndLoss = decProfitLedger;
                    decimal OpeningProfit1;
                    decimal openingBalance;
                    dgvTrailBalance.Rows.Add();
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtSlNo"].Value = "  ";
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["accountGroupName"].Value = "Profit and Loss";
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtAccountGroupId"].Value = "0";
                    if (dtblProfitAndLossAcc.Rows.Count > 0)
                    {
                        openingBalance = Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["OpeningBalance"].ToString());
                        {
                            if (openingBalance > 0)
                            {
                                dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["openingBalance"].Value = openingBalance + "Dr";
                            }
                            else
                                dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["openingBalance"].Value = (-1) * openingBalance + "Cr";
                        }
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtSlNo"].Value = dgvTrailBalance.Rows.Count.ToString();
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Blue;
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvTrailBalance.Font, FontStyle.Regular);
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["credit"].Value = dtblProfitAndLossAcc.Rows[0]["credit"].ToString();
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["debit"].Value = dtblProfitAndLossAcc.Rows[0]["debit"].ToString();
                        OpeningProfit1 = (Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["OpeningBalance"].ToString())) + Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["debit"].ToString()) - Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["credit"].ToString());
                        {
                            if (OpeningProfit1 > 0)
                            {
                                dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtBalance"].Value = decTotalProfitAndLoss + dcProfit + "Dr";
                            }
                            else
                                dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtBalance"].Value = (-1) * decTotalProfitAndLoss - dcProfit + "Cr";
                        };
                        dcTotalCredit = dcTotalCredit + Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["credit"].ToString());
                        dcTotalDebit = dcTotalDebit + Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["debit"].ToString());
                    }
                    //=================================Net profit and NetLoss transation for previousyear==============
                    decimal decprofitLossbal = 0;
                    decimal decbalance = 0;
                    decimal decProfitAndLossOfPrevious = decProfitLedgerOpening;
                    dgvTrailBalance.Rows.Add();
                    if (dcProfitOpening > 0)
                    {
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["openingBalance"].Value = dcProfitOpening + "Dr";
                        decprofitLossbal = dcProfitOpening;
                    }
                    if (dcProfitOpening <= 0)
                    {
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["openingBalance"].Value = (-1) * dcProfitOpening + "Cr";
                        decprofitLossbal = dcProfitOpening;
                    }
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtSlNo"].Value = "  ";
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["accountGroupName"].Value = "Profit and Loss Opening";
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["openingBalance"].Value = "0.00Dr";
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Brown;
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvTrailBalance.Font, FontStyle.Regular);
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtAccountGroupId"].Value = "0";
                    if (decProfitAndLossOfPrevious > 0)
                    {
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["debit"].Value = decProfitAndLossOfPrevious;
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["credit"].Value = "0.00";
                        decbalance = (decProfitAndLossOfPrevious);
                    }
                    if (decProfitAndLossOfPrevious <= 0)
                    {
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["credit"].Value = (-1) * (decProfitAndLossOfPrevious);
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["debit"].Value = "0.00";
                        decbalance = ((decProfitAndLossOfPrevious));
                    }
                    if (decbalance >= 0)
                    {
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtBalance"].Value = decbalance + decprofitLossbal + "Dr";
                    }
                    if (decbalance < 0)
                    {
                        decbalance = -(decbalance);
                        dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtBalance"].Value = decbalance + decprofitLossbal + "Cr";
                    }
                    dgvTrailBalance.Rows.Add();
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtSlNo"].Value = "  ";
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["accountGroupName"].Value = "Total:";
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["dgvtxtSlNo"].Value = string.Empty;
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvTrailBalance.Font, FontStyle.Bold);
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["credit"].Value = dcTotalCredit;
                    dgvTrailBalance.Rows[dgvTrailBalance.Rows.Count - 1].Cells["debit"].Value = dcTotalDebit;
                    if (dgvTrailBalance.Columns.Count > 0)
                    {
                        dgvTrailBalance.Columns["credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvTrailBalance.Columns["debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvTrailBalance.Columns["openingBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvTrailBalance.Columns["dgvtxtBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    dgvTrailBalance.ScrollBars = ScrollBars.Both;
                    dgvTrailBalance.ClearSelection();
                    if (inCurrenRowIndex > 0 && dgvTrailBalance.Rows.Count > 0 && inCurrenRowIndex < dgvTrailBalance.Rows.Count)
                    {
                        if (dgvTrailBalance.Rows[inCurrenRowIndex].Cells[inCurrentColIndex].Visible)
                        {
                            dgvTrailBalance.CurrentCell = dgvTrailBalance.Rows[inCurrenRowIndex].Cells[inCurrentColIndex];
                        }
                        else
                        {
                            dgvTrailBalance.CurrentCell = dgvTrailBalance.Rows[inCurrenRowIndex].Cells["debit"];
                        }
                        dgvTrailBalance.CurrentCell.Selected = true;
                    }
                    inCurrenRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tb:2" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to generate Serial Number in Datagridview
        /// </summary>
        public void SlNo()
        {
            int inRowNo = 1;
            try
            {
                foreach (DataGridViewRow Dr in dgvTrailBalance.Rows)
                {
                    Dr.Cells["dgvtxtSlNo"].Value = inRowNo;
                    inRowNo++;
                    if (Dr.Index == dgvTrailBalance.Rows.Count - 1)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:3" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to add data to Datatable
        /// </summary>
        /// <returns></returns>
        public DataTable Getdatatable()
        {
            DataTable dtblTrail = new DataTable();
            dtblTrail.Columns.Add("dgvtxtSlNo");
            dtblTrail.Columns.Add("dgvtxtAccountGroupId");
            dtblTrail.Columns.Add("accountGroupName");
            dtblTrail.Columns.Add("openingBalance");
            dtblTrail.Columns.Add("Debit");
            dtblTrail.Columns.Add("Credit");
            dtblTrail.Columns.Add("dgvtxtBalance");
            DataRow drow = null;
            foreach (DataGridViewRow dr in dgvTrailBalance.Rows)
            {
                drow = dtblTrail.NewRow();
                drow["dgvtxtSlNo"] = dr.Cells["dgvtxtSlNo"].Value;
                drow["accountGroupName"] = dr.Cells["accountGroupName"].Value;
                drow["openingBalance"] = dr.Cells["openingBalance"].Value;
                drow["Debit"] = dr.Cells["Debit"].Value;
                drow["Credit"] = dr.Cells["Credit"].Value;
                drow["dgvtxtBalance"] = dr.Cells["dgvtxtBalance"].Value;
                dtblTrail.Rows.Add(drow);
            }
            return dtblTrail;
        }
        /// <summary>
        /// Function to convert datatable to System.Data.DataSet
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet getdataset()
        {
            System.Data.DataSet dsTrail = new System.Data.DataSet();
            try
            {
                FinancialStatementSP spfinancial = new FinancialStatementSP();
                DataTable dtblTrail = Getdatatable();
                DataTable dtblCompany = new DataTable();
                dtblCompany = spfinancial.FundFlowReportPrintCompany(1);
                dsTrail.Tables.Add(dtblTrail);
                dsTrail.Tables.Add(dtblCompany);
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:4" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dsTrail;
        }
        /// <summary>
        /// Function for Print
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="todate"></param>
        public void Print(DateTime fromDate, DateTime todate)
        {
            try
            {
                FinancialStatementSP spFinance = new FinancialStatementSP();
                System.Data.DataSet dsTrail = getdataset();
                //frmReport frmReport = new frmReport();
                //frmReport.MdiParent = formMDI.MDIObj;
                //frmReport.TrailBalanceReportPrinting(dsTrail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:5" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Events
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTrialBalance_Load(object sender, EventArgs e)
        {
            try
            {
                isFormLoad = true;
                dtpTrialFromDate.MinDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                dtpTrialFromDate.MaxDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate);
                dtpTrialFromDate.Value = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                ddtpTrialToDate.MinDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                ddtpTrialToDate.MaxDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate);
                ddtpTrialToDate.Value = Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate);
                dtpTrialFromDate.Text = dtpTrialFromDate.Value.ToString("dd-MMM-yyyy");
                ddtpTrialToDate.Text = ddtpTrialToDate.Value.ToString("dd-MMM-yyyy");
                isFormLoad = false;
                GridFill();
                txtFromDate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:6" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Clear' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:7" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fills  txtTodate textbox on dateTimePicker1 Datetimepicker ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.ddtpTrialToDate.Value;
                this.txtTodate.Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:8" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fills  txtFromDate textbox on dtpTrialFromDate Datetimepicker ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpTrialFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpTrialFromDate.Value;
                this.txtFromDate.Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:9" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Generate serial number in Datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTrailBalance_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                SlNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:10" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Calls corresponding Ledgers AccountGroupwiseReport to view details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTrailBalance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvTrailBalance.Rows[e.RowIndex].Cells["dgvtxtAccountGroupId"].Value != null && dgvTrailBalance.Rows[e.RowIndex].Cells["dgvtxtAccountGroupId"].Value.ToString() != string.Empty)
                    {
                        decimal decAccountGroupId = Convert.ToDecimal(dgvTrailBalance.Rows[e.RowIndex].Cells["dgvtxtAccountGroupId"].Value.ToString());
                       // frmAccountGroupwiseReport frmAccountGroupwiseReportObjt = new frmAccountGroupwiseReport();
                       // frmAccountGroupwiseReportObjt.WindowState = FormWindowState.Normal;
                        //frmAccountGroupwiseReportObjt.MdiParent = formMDI.MDIObj;
                        //if (dgvTrailBalance.Rows[e.RowIndex].Cells["dgvtxtBalance"].Value.ToString() != "0.00Dr" && dgvTrailBalance.Rows[e.RowIndex].Cells["dgvtxtBalance"].Value.ToString() != "0.00Cr")
                        //{
                            //frmAccountGroupwiseReportObjt.CallFromTrailBalance(dtpTrialFromDate.Value.ToString(), ddtpTrialToDate.Value.ToString(), decAccountGroupId, this);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show("TB:11" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Print' button click to take print
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTrailBalance.Rows.Count < 0)
                {
                    MessageBox.Show("No Row To Print", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    Print(Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate), Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate));
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:12" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Search' button click fills Datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateValidation ObjValidation = new DateValidation();
                ObjValidation.DateValidationFunction(txtTodate);
                if (Convert.ToDateTime(txtTodate.Text) < Convert.ToDateTime(txtFromDate.Text))
                {
                    MessageBox.Show("todate should be greater than fromdate", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTodate.Text = Utils.getManagement().FinancialYear.toDate.Value.ToString("dd-MMM-yyyy");
                    txtFromDate.Text = Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy");
                    GridFill();
                }
                else
                {
                    GridFill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:13" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// DateValidation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation objValidation = new DateValidation();
                objValidation.DateValidationFunction(txtFromDate);
                if (txtFromDate.Text == string.Empty)
                    txtFromDate.Text = Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy");
                DateTime dt;
                DateTime.TryParse(txtFromDate.Text, out dt);
                dtpTrialFromDate.Value = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:14" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// DateValidation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTodate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation objValidation = new DateValidation();
                objValidation.DateValidationFunction(txtTodate);
                if (txtTodate.Text == string.Empty)
                    txtTodate.Text = Utils.getManagement().FinancialYear.toDate.Value.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:15" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Navigations
        /// <summary>
        /// Escape key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTrialBalance_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Messages.CloseMessage(this);
                    this.Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:16" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTodate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtTodate.SelectionLength != 11)
                    {
                        if (txtTodate.Text == string.Empty && txtTodate.SelectionStart == 0)
                        {
                            txtFromDate.Focus();
                            txtFromDate.SelectionLength = 0;
                            txtFromDate.SelectionStart = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:17" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTodate.Focus();
                    txtTodate.SelectionLength = 0;
                    txtTodate.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TB:18" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
