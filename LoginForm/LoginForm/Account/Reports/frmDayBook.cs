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
using LoginForm.Account.Services;
using LoginForm.Account;
using LoginForm.Services;
using LoginForm;
using LoginForm.PurchaseOrder;
using LoginForm.nmSaleOrder;
using LoginForm.QuotationModule;

namespace LoginForm
{
    public partial class frmDayBook : Form
    {
        #region Public variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        int inCurrenRowIndex = 0;
        DataTable dtbl = new DataTable();
        #endregion
        #region functions
        /// <summary>
        /// Create an Instance of a frmDayBook class
        /// </summary>
        public frmDayBook()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to fill vouchertype combobox
        /// </summary>
        public void voucherTypeComboFill()
        {
            try
            {
                VoucherTypeSP spVoucherType = new VoucherTypeSP();
                DataTable dtbl = new DataTable();
                dtbl = spVoucherType.VoucherTypeViewAll();
                DataRow dr = dtbl.NewRow();
                dr[0] = 0;
                dr[1] = "All";
                dtbl.Rows.InsertAt(dr, 0);
                cmbVoucherType.DataSource = dtbl;
                cmbVoucherType.DisplayMember = "voucherTypeName";
                cmbVoucherType.ValueMember = "voucherTypeId";
                cmbVoucherType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// combo ledger Fill
        /// </summary>
        public void ledgerComboFill()
        {
            try
            {
                TransactionsGeneralFill obj = new TransactionsGeneralFill();
                DataTable dtbl = new DataTable();
                dtbl = obj.AccountLedgerComboFill();
                DataRow dr = dtbl.NewRow();
                dr[0] = 0;
                dr[2] = "All";
                dtbl.Rows.InsertAt(dr, 0);
                cmbLedger.DataSource = dtbl;
                cmbLedger.DisplayMember = "ledgerName";
                cmbLedger.ValueMember = "ledgerId";
                cmbLedger.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to clear the fields
        /// </summary>
        public void clear()
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                Management m = Utils.getManagement();
                DateTime dt = IME.CurrentDate().FirstOrDefault().Value;
                rbtnCondensed.Checked = true;
                cmbLedger.SelectedIndex = 0;
                cmbVoucherType.SelectedIndex = 0;
                /*-------date setting at the time of loading*/
                dtpFromDate.MinDate = Convert.ToDateTime(m.FinancialYear.fromDate);
                dtpFromDate.MaxDate = Convert.ToDateTime(m.FinancialYear.toDate);
                dtpFromDate.Value = dt;
                dtpToDate.MinDate = Convert.ToDateTime(m.FinancialYear.fromDate);
                dtpToDate.MaxDate = Convert.ToDateTime(m.FinancialYear.toDate);
                dtpToDate.Value = dt;
                //----------------------------------------------*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB3:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function for daybook gridfill
        /// </summary>
        public void dayBookGridFill()
        {
            try
            {
                decimal decDebitTotal = 0;
                decimal decCreditTotal = 0;
                decimal decInwrdTotal = 0;
                decimal decOtwrdTotal = 0;
                decimal decBalance = 0;
                decimal decBalQty = 0;
                FinancialStatementSP spFinance = new FinancialStatementSP();
                dgvDayBook.DataSource = null;
                dtbl = spFinance.DayBook(Convert.ToDateTime(dtpFromDate.Value.ToString("dd/MMM/yyyy")), Convert.ToDateTime(dtpToDate.Value.ToString("dd/MMM/yyyy")), Convert.ToDecimal(cmbVoucherType.SelectedValue), Convert.ToDecimal(cmbLedger.SelectedValue), rbtnCondensed.Checked);
                if (dtbl.Rows.Count > 0)
                {
                    decDebitTotal = Convert.ToDecimal(dtbl.Compute("Sum(Debit)", string.Empty).ToString());
                    decCreditTotal = Convert.ToDecimal(dtbl.Compute("Sum(Credit)", string.Empty).ToString());
                    decInwrdTotal = Convert.ToDecimal(dtbl.Compute("Sum([Inward_Qty])", string.Empty).ToString());
                    decOtwrdTotal = Convert.ToDecimal(dtbl.Compute("Sum([Outward_Qty])", string.Empty).ToString());
                }
                else
                {
                    decDebitTotal = 0;
                    decCreditTotal = 0;
                    decOtwrdTotal = 0;
                    decInwrdTotal = 0;
                }
                if (decDebitTotal > decCreditTotal)
                {
                    decBalance = decDebitTotal - decCreditTotal;
                }
                else
                {
                    decBalance = decCreditTotal - decDebitTotal;
                }
                if (decInwrdTotal > decOtwrdTotal)
                {
                    decBalQty = decInwrdTotal - decOtwrdTotal;
                }
                else
                {
                    decBalQty = decOtwrdTotal - decInwrdTotal;
                }
                dtbl.Rows.Add();
                dtbl.Rows[dtbl.Rows.Count - 1]["Invoice_No"] = string.Empty;
                dtbl.Rows[dtbl.Rows.Count - 1]["Voucher_Type"] = string.Empty;
                dtbl.Rows.Add();
                if (rbtnCondensed.Checked == true)
                {
                    dtbl.Rows[dtbl.Rows.Count - 1]["Invoice_No"] = "Total :";
                }
                else
                {
                    dtbl.Rows[dtbl.Rows.Count - 1]["Ledger"] = "Total :";
                }
                dtbl.Rows[dtbl.Rows.Count - 1]["Debit"] = decDebitTotal.ToString();
                dtbl.Rows[dtbl.Rows.Count - 1]["Credit"] = decCreditTotal.ToString();
                dtbl.Rows[dtbl.Rows.Count - 1]["Inward_Qty"] = decInwrdTotal.ToString();
                dtbl.Rows[dtbl.Rows.Count - 1]["Outward_Qty"] = decOtwrdTotal.ToString();
                dtbl.Rows.Add();
                if (rbtnCondensed.Checked == true)
                {
                    dtbl.Rows[dtbl.Rows.Count - 1]["Voucher_Type"] = "Balance :";
                    dtbl.Rows[dtbl.Rows.Count - 1]["Invoice_No"] = (decDebitTotal > decCreditTotal ? decBalance + "Dr" : decBalance + "Cr");
                }
                else
                {
                    dtbl.Rows[dtbl.Rows.Count - 1]["Invoice_No"] = "Balance :";
                    dtbl.Rows[dtbl.Rows.Count - 1]["Ledger"] = (decDebitTotal > decCreditTotal ? decBalance + "Dr" : decBalance + "Cr");
                }
                dtbl.Rows[dtbl.Rows.Count - 1]["Inward_Qty"] = decBalQty.ToString();
                dgvDayBook.DataSource = dtbl;
                dgvDayBook.Columns["typeOfVoucher"].Visible = false;
                dgvDayBook.Columns["voucherTypeId"].Visible = false;
                dgvDayBook.Columns["voucherNo"].Visible = false;
                dgvDayBook.Columns["MasterId"].Visible = false;
                int index = 0;
                if (dgvDayBook.RowCount > 0)
                {
                    index++;
                    //dgvDayBook.Rows[0].Cells["Sl_No"].Value = index.ToString();
                    int i = 0;
                    string date = dgvDayBook.Rows[i].Cells["Date"].Value.ToString();
                    string voucherType = dgvDayBook.Rows[i].Cells["Voucher_Type"].Value.ToString();
                    string voucherNo = dgvDayBook.Rows[i].Cells["Invoice_No"].Value.ToString();
                    i++;
                    for (; i < dgvDayBook.RowCount; )
                    {
                        if (i >= dgvDayBook.RowCount)
                            break;
                        while ((dgvDayBook.Rows[i].Cells["Date"].Value.ToString() == date || dgvDayBook.Rows[i].Cells["Date"].Value.ToString() == "") && dgvDayBook.Rows[i].Cells["Voucher_Type"].Value.ToString() == voucherType && dgvDayBook.Rows[i].Cells["Invoice_No"].Value.ToString() == voucherNo)
                        {
                            dgvDayBook.Rows[i].Cells["Date"].Value = string.Empty;
                            dgvDayBook.Rows[i].Cells["Voucher_Type"].Value = string.Empty;
                            dgvDayBook.Rows[i].Cells["Invoice_No"].Value = string.Empty;
                            i++;
                            if (i >= dgvDayBook.RowCount)
                                break;
                        }
                        if (i >= dgvDayBook.RowCount)
                            break;
                        index++;
                        //dgvDayBook.Rows[i].Cells["Sl_No"].Value = index.ToString();
                        date = dgvDayBook.Rows[i].Cells["Date"].Value.ToString();
                        voucherType = dgvDayBook.Rows[i].Cells["Voucher_Type"].Value.ToString();
                        voucherNo = dgvDayBook.Rows[i].Cells["Invoice_No"].Value.ToString();
                        i++;
                        //dgvDayBook.Rows[dgvDayBook.Rows.Count - 1].Cells["Sl_No"].Value = string.Empty;
                        //dgvDayBook.Rows[dgvDayBook.Rows.Count - 2].Cells["Sl_No"].Value = string.Empty;
                        //dgvDayBook.Rows[dgvDayBook.Rows.Count - 3].Cells["Sl_No"].Value = string.Empty;
                    }
                    for (int incolIndex = 0; incolIndex < dgvDayBook.Columns.Count; ++incolIndex)//to set columns in the grid not sortable
                        dgvDayBook.Columns[incolIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (inCurrenRowIndex >= 0 && dgvDayBook.Rows.Count > 0 && inCurrenRowIndex < dgvDayBook.Rows.Count)
                {
                    dgvDayBook.CurrentCell = dgvDayBook.Rows[inCurrenRowIndex].Cells["Date"];
                    dgvDayBook.CurrentCell.Selected = true;
                }
                inCurrenRowIndex = 0;
                if (dgvDayBook.Columns.Count > 0)
                {
                    dgvDayBook.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvDayBook.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvDayBook.Columns["Inward_Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvDayBook.Columns["Outward_Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB4:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to create datatable for daybook gridfill
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataTable dtblDayBook = new DataTable();
            try
            {
                if (rbtnCondensed.Checked == true)
                {
                    dtblDayBook.Columns.Add("Sl No");
                    dtblDayBook.Columns.Add("Date");
                    dtblDayBook.Columns.Add("Voucher Type");
                    dtblDayBook.Columns.Add("Invoice No");
                    dtblDayBook.Columns.Add("Debit");
                    dtblDayBook.Columns.Add("Credit");
                    dtblDayBook.Columns.Add("Inward Qty");
                    dtblDayBook.Columns.Add("Outward Qty");
                    DataRow drow = null;
                    foreach (DataGridViewRow dr in dgvDayBook.Rows)
                    {
                        drow = dtblDayBook.NewRow();
                        drow["Sl No"] = dr.Cells["Sl No"].Value;
                        drow["Date"] = dr.Cells["Date"].Value;
                        drow["Voucher Type"] = dr.Cells["Voucher Type"].Value;
                        drow["Invoice No"] = dr.Cells["Invoice No"].Value;
                        drow["Debit"] = dr.Cells["Debit"].Value;
                        drow["Credit"] = dr.Cells["Credit"].Value;
                        drow["Inward Qty"] = dr.Cells["Inward Qty"].Value;
                        drow["Outward Qty"] = dr.Cells["Outward Qty"].Value;
                        dtblDayBook.Rows.Add(drow);
                    }
                }
                else
                {
                    dtblDayBook.Columns.Add("Sl No");
                    dtblDayBook.Columns.Add("Date");
                    dtblDayBook.Columns.Add("Voucher Type");
                    dtblDayBook.Columns.Add("Invoice No");
                    dtblDayBook.Columns.Add("Ledger");
                    dtblDayBook.Columns.Add("Debit");
                    dtblDayBook.Columns.Add("Credit");
                    dtblDayBook.Columns.Add("Inward Qty");
                    dtblDayBook.Columns.Add("Outward Qty");
                    DataRow drow = null;
                    foreach (DataGridViewRow dr in dgvDayBook.Rows)
                    {
                        drow = dtblDayBook.NewRow();
                        drow["Sl No"] = dr.Cells["Sl No"].Value;
                        drow["Date"] = dr.Cells["Date"].Value;
                        drow["Voucher Type"] = dr.Cells["Voucher Type"].Value;
                        drow["Invoice No"] = dr.Cells["Invoice No"].Value;
                        drow["Ledger"] = dr.Cells["Ledger"].Value;
                        drow["Debit"] = dr.Cells["Debit"].Value;
                        drow["Credit"] = dr.Cells["Credit"].Value;
                        drow["Inward Qty"] = dr.Cells["Inward Qty"].Value;
                        drow["Outward Qty"] = dr.Cells["Outward Qty"].Value;
                        dtblDayBook.Rows.Add(drow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtblDayBook;
        }
        /// <summary>
        /// Convert DataTable to DataSet
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet getdataset()
        {
            System.Data.DataSet dsDayBookReport = new System.Data.DataSet();
            try
            {
                FinancialStatementSP spfinancial = new FinancialStatementSP();
                DataTable dtblDayBook = GetDataTable();
                DataTable dtblCompany = new DataTable();
                dtblCompany = spfinancial.DayBookReportPrintCompany();
                dsDayBookReport.Tables.Add(dtblDayBook);
                dsDayBookReport.Tables.Add(dtblCompany);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dsDayBookReport;
        }
        /// <summary>
        /// Convert DataTable to DataSet for condensed
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet getdatasetCondensed()
        {
            System.Data.DataSet dsDayBookReportCondensed = new System.Data.DataSet();
            try
            {
                FinancialStatementSP spfinancial = new FinancialStatementSP();

                DataTable dtblDayBook = GetDataTable();
                DataTable dtblCompany = new DataTable();
                dtblCompany = spfinancial.DayBookReportPrintCompany();
                dsDayBookReportCondensed.Tables.Add(dtblCompany);
                dsDayBookReportCondensed.Tables.Add(dtblDayBook);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dsDayBookReportCondensed;
        }

        public void Print(DateTime fromDate, DateTime toDate, decimal decVoucherTypeId, decimal decLedgerId, bool blCondenced)
        {
            try
            {
                //System.Data.DataSet dsDayBookReport = getdataset();
                //System.Data.DataSet dsDayBookReportCondensed = getdatasetCondensed();
                //frmReport frmReport = new frmReport();
                //frmReport.MdiParent = formMDI.MDIObj;
                //if (rbtnCondensed.Checked == true)
                //{
                //    frmReport.dayBookReportPrintingCondensed(dsDayBookReportCondensed);
                //}
                //else
                //{
                //    frmReport.dayBookReportPrintingDetailed(dsDayBookReport);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region events
       /// <summary>
       /// On load
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void frmDayBook_Load(object sender, EventArgs e)
        {
            try
            {
                voucherTypeComboFill();
                ledgerComboFill();
                txtFromDate.Focus();
                clear();
                dayBookGridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On Value change of dtpFromDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpFromDate.Value;
                this.txtFromDate.Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On leave from txtFromDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFromDate_Leave(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                DateValidation obj = new DateValidation();
                obj.DateValidationFunction(txtFromDate);
                if (txtFromDate.Text == string.Empty)
                {
                    txtFromDate.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                }
                //----for change date in date time picker------//
                dtpFromDate.Value = Convert.ToDateTime(txtFromDate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On Value change of dtpToDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpToDate.Value;
                this.txtToDate.Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On leave from txtToDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToDate_Leave(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                DateValidation obj = new DateValidation();
                obj.DateValidationFunction(txtToDate);
                if (txtToDate.Text == string.Empty)
                {
                    txtToDate.Text = IME.CurrentDate().FirstOrDefault().Value.ToString("dd-MMM-yyyy");
                }
                //----for change date in date time picker------//
                dtpToDate.Value = Convert.ToDateTime(txtToDate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB13:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpToDate.Value >= dtpFromDate.Value)
                {
                    dayBookGridFill();
                }
                else
                {
                    Messages.InformationMessage("To date less than from date");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB14:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On reset button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
                dayBookGridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB15:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// on databinding complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDataBook_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dgvDayBook.RowCount > 2)
                {
                    dgvDayBook.Rows[dgvDayBook.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                    dgvDayBook.Rows[dgvDayBook.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvDayBook.Font, FontStyle.Bold);
                    dgvDayBook.Rows[dgvDayBook.Rows.Count - 2].DefaultCellStyle.ForeColor = Color.Red;
                    dgvDayBook.Rows[dgvDayBook.Rows.Count - 2].DefaultCellStyle.Font = new Font(dgvDayBook.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB16:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On print button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnSearch_Click(sender, e);
                if (dgvDayBook.RowCount > 3)
                {
                    Print(this.dtpFromDate.Value, this.dtpToDate.Value, Convert.ToDecimal(cmbVoucherType.SelectedValue), Convert.ToDecimal(cmbLedger.SelectedValue), rbtnCondensed.Checked);
                }
                else
                {
                    Messages.InformationMessage("No data found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// When doubleclicking on the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDayBook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strVoucherType = string.Empty;
                decimal decMasterId = 0;
                SalesMasterSP spSalesMaster = new SalesMasterSP();
                if (dgvDayBook.CurrentRow.Index == e.RowIndex)
                {
                    int inI = dgvDayBook.CurrentCell.RowIndex;
                    int inCount = dgvDayBook.Rows.Count;
                    if (dgvDayBook.CurrentCell.RowIndex < dgvDayBook.Rows[inCount - 3].Cells["Date"].RowIndex)
                    {
                        foreach (DataGridViewRow dgv in dgvDayBook.Rows)
                        {
                            if (dgv.Cells["Date"].Value.ToString() != string.Empty)
                            {
                                strVoucherType = dgv.Cells["typeOfVoucher"].Value.ToString();
                                decMasterId = Convert.ToDecimal(dgv.Cells["MasterId"].Value.ToString());
                            }
                            if (dgv.Index == inI)
                            {
                                break;
                            }
                        }
                        if (strVoucherType == "Contra Voucher")
                        {
                            //frmContraVoucher frmContraVoucher = new frmContraVoucher();
                            //frmContraVoucher open = Application.OpenForms["frmContraVoucher"] as frmContraVoucher;
                            //if (open == null)
                            //{
                                //frmContraVoucher.WindowState = FormWindowState.Normal;
                                //frmContraVoucher.MdiParent = formMDI.MDIObj;
                                //frmContraVoucher.callFromDayBook(this, decMasterId);
                            //}
                            //else
                            //{
                                //open.callFromDayBook(this, decMasterId);
                                //if (open.WindowState == FormWindowState.Minimized)
                                //{
                                //    open.WindowState = FormWindowState.Normal;
                                //}
                            //}
                        }
                        else if (strVoucherType == "Payment Voucher")
                        {
                            frmPaymentVoucher frmPaymentVoucher = new frmPaymentVoucher();
                            frmPaymentVoucher open = Application.OpenForms["frmPaymentVoucher"] as frmPaymentVoucher;
                            if (open == null)
                            {
                                frmPaymentVoucher.WindowState = FormWindowState.Normal;
                                //frmPaymentVoucher.MdiParent = formMDI.MDIObj;
                                //frmPaymentVoucher.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                //open.callFromDayBook(this, decMasterId);
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                            }
                        }
                        else if (strVoucherType == "Receipt Voucher")
                        {
                            frmReceiptVoucher frmReceiptVoucher = new frmReceiptVoucher();
                            frmReceiptVoucher open = Application.OpenForms["frmReceiptVoucher"] as frmReceiptVoucher;
                            if (open == null)
                            {
                                frmReceiptVoucher.WindowState = FormWindowState.Normal;
                                //frmReceiptVoucher.MdiParent = formMDI.MDIObj;
                                //frmReceiptVoucher.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Journal Voucher")
                        {
                            frmJournalVoucher frmJournalVoucher = new frmJournalVoucher();
                            frmJournalVoucher open = Application.OpenForms["frmJournalVoucher"] as frmJournalVoucher;
                            if (open == null)
                            {
                                frmJournalVoucher.WindowState = FormWindowState.Normal;
                                //frmJournalVoucher.MdiParent = formMDI.MDIObj;
                                //frmJournalVoucher.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                //open.callFromDayBook(this, decMasterId);
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                            }
                        }
                        else if (strVoucherType == "PDC Payable")
                        {
                            frmPdcPayable frmPdcPayable = new frmPdcPayable();
                            frmPdcPayable open = Application.OpenForms["frmPdcPayable"] as frmPdcPayable;
                            if (open == null)
                            {
                                frmPdcPayable.WindowState = FormWindowState.Normal;
                                //frmPdcPayable.MdiParent = formMDI.MDIObj;
                                //frmPdcPayable.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "PDC Receivable")
                        {
                            frmPdcReceivable frmPdcReceivable = new frmPdcReceivable();
                            frmPdcReceivable open = Application.OpenForms["frmPdcReceivable"] as frmPdcReceivable;
                            if (open == null)
                            {
                                frmPdcReceivable.WindowState = FormWindowState.Normal;
                                //frmPdcReceivable.MdiParent = formMDI.MDIObj;
                                //frmPdcReceivable.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Purchase Invoice")
                        {
                            frmPurchaseInvoice frmPurchaseInvoice = new frmPurchaseInvoice();
                            frmPurchaseInvoice open = Application.OpenForms["frmPurchaseInvoice"] as frmPurchaseInvoice;
                            if (open == null)
                            {
                                frmPurchaseInvoice.WindowState = FormWindowState.Normal;
                                //frmPurchaseInvoice.MdiParent = formMDI.MDIObj;
                                //frmPurchaseInvoice.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Purchase Return")
                        {
                            frmPurchaseReturn frmPurchaseReturn = new frmPurchaseReturn();
                            frmPurchaseReturn open = Application.OpenForms["frmPurchaseReturn"] as frmPurchaseReturn;
                            if (open == null)
                            {
                                frmPurchaseReturn.WindowState = FormWindowState.Normal;
                                //frmPurchaseReturn.MdiParent = formMDI.MDIObj;
                                //frmPurchaseReturn.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Sales Invoice")
                        {
                            decimal decSalesId = Convert.ToDecimal(dgvDayBook.CurrentRow.Cells["MasterId"].Value.ToString());
                            decimal decVoucherId = Convert.ToDecimal(dgvDayBook.CurrentRow.Cells["voucherTypeId"].Value.ToString());
                            bool isPOS = spSalesMaster.DayBookSalesInvoiceOrPOS(decSalesId, decVoucherId);
                            if (isPOS == true)
                            {
                                //frmPOS frmPOSObj = new frmPOS();
                                //frmPOS open = Application.OpenForms["frmPOS"] as frmPOS;
                                //if (open == null)
                                //{
                                //    frmPOSObj.WindowState = FormWindowState.Normal;
                                //    frmPOSObj.MdiParent = formMDI.MDIObj;
                                //    frmPOSObj.callFromDayBook(this, decMasterId);
                                //}
                                //else
                                //{
                                //    if (open.WindowState == FormWindowState.Minimized)
                                //    {
                                //        open.WindowState = FormWindowState.Normal;
                                //    }
                                //    open.callFromDayBook(this, decMasterId);
                                //}
                            }
                            else
                            {
                                frmSalesInvoice frmSalesInvoiceObj = new frmSalesInvoice();
                                frmSalesInvoice open = Application.OpenForms["frmSalesInvoice"] as frmSalesInvoice;
                                if (open == null)
                                {
                                    frmSalesInvoiceObj.WindowState = FormWindowState.Normal;
                                    //frmSalesInvoiceObj.MdiParent = formMDI.MDIObj;
                                    //frmSalesInvoiceObj.callFromDayBook(this, decMasterId);
                                }
                                else
                                {
                                    if (open.WindowState == FormWindowState.Minimized)
                                    {
                                        open.WindowState = FormWindowState.Normal;
                                    }
                                    //open.callFromDayBook(this, decMasterId);
                                }
                            }
                        }
                        else if (strVoucherType == "Sales Return")
                        {
                            frmSalesReturn frmSalesReturn = new frmSalesReturn();
                            frmSalesReturn open = Application.OpenForms["frmSalesReturn"] as frmSalesReturn;
                            if (open == null)
                            {
                                frmSalesReturn.WindowState = FormWindowState.Normal;
                                //frmSalesReturn.MdiParent = formMDI.MDIObj;
                                //frmSalesReturn.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                               // open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Service Voucher")
                        {
                            frmServiceVoucher frmServiceVoucher = new frmServiceVoucher();
                            frmServiceVoucher open = Application.OpenForms["frmServiceVoucher"] as frmServiceVoucher;
                            if (open == null)
                            {
                                frmServiceVoucher.WindowState = FormWindowState.Normal;
                                //frmServiceVoucher.MdiParent = formMDI.MDIObj;
                                //frmServiceVoucher.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Credit Note")
                        {
                            frmCreditNote frmCreditNote = new frmCreditNote();
                            frmCreditNote open = Application.OpenForms["frmCreditNote"] as frmCreditNote;
                            if (open == null)
                            {
                                frmCreditNote.WindowState = FormWindowState.Normal;
                                //frmCreditNote.MdiParent = formMDI.MDIObj;
                                //frmCreditNote.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Debit Note")
                        {
                            frmDebitNote frmDebitNote = new frmDebitNote();
                            frmDebitNote open = Application.OpenForms["frmDebitNote"] as frmDebitNote;
                            if (open == null)
                            {
                                frmDebitNote.WindowState = FormWindowState.Normal;
                                //frmDebitNote.MdiParent = formMDI.MDIObj;
                                //frmDebitNote.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        //else if (strVoucherType == "Rejection In")
                        //{
                        //    frmRejectionIn frmRejectionIn = new frmRejectionIn();
                        //    frmRejectionIn open = Application.OpenForms["frmRejectionIn"] as frmRejectionIn;
                        //    if (open == null)
                        //    {
                        //        frmRejectionIn.WindowState = FormWindowState.Normal;
                        //        frmRejectionIn.MdiParent = formMDI.MDIObj;
                        //        frmRejectionIn.callFromDayBook(this, decMasterId);
                        //    }
                        //    else
                        //    {
                        //        if (open.WindowState == FormWindowState.Minimized)
                        //        {
                        //            open.WindowState = FormWindowState.Normal;
                        //        }
                        //        open.callFromDayBook(this, decMasterId);
                        //    }
                        //}
                        //else if (strVoucherType == "Rejection Out")
                        //{
                        //    frmRejectionOut frmRejectionOut = new frmRejectionOut();
                        //    frmRejectionOut open = Application.OpenForms["frmRejectionOut"] as frmRejectionOut;
                        //    if (open == null)
                        //    {
                        //        frmRejectionOut.WindowState = FormWindowState.Normal;
                        //        frmRejectionOut.MdiParent = formMDI.MDIObj;
                        //        frmRejectionOut.callFromDayBook(this, decMasterId);
                        //    }
                        //    else
                        //    {
                        //        if (open.WindowState == FormWindowState.Minimized)
                        //        {
                        //            open.WindowState = FormWindowState.Normal;
                        //        }
                        //        open.callFromDayBook(this, decMasterId);
                        //    }
                        //}
                        //else if (strVoucherType == "Delivery Note")
                        //{
                        //    frmDeliveryNote frmDeliveryNote = new frmDeliveryNote();
                        //    frmDeliveryNote open = Application.OpenForms["frmDeliveryNote"] as frmDeliveryNote;
                        //    if (open == null)
                        //    {
                        //        frmDeliveryNote.WindowState = FormWindowState.Normal;
                        //        frmDeliveryNote.MdiParent = formMDI.MDIObj;
                        //        frmDeliveryNote.callFromDayBook(this, decMasterId);
                        //    }
                        //    else
                        //    {
                        //        if (open.WindowState == FormWindowState.Minimized)
                        //        {
                        //            open.WindowState = FormWindowState.Normal;
                        //        }
                        //        open.callFromDayBook(this, decMasterId);
                        //    }
                        //}
                        //else if (strVoucherType == "Material Receipt")
                        //{
                        //    frmMaterialReceipt frmMaterialReceipt = new frmMaterialReceipt();
                        //    frmMaterialReceipt open = Application.OpenForms["frmMaterialReceipt"] as frmMaterialReceipt;
                        //    if (open == null)
                        //    {
                        //        frmMaterialReceipt.WindowState = FormWindowState.Normal;
                        //        frmMaterialReceipt.MdiParent = formMDI.MDIObj;
                        //        frmMaterialReceipt.callFromDayBook(this, decMasterId);
                        //    }
                        //    else
                        //    {
                        //        if (open.WindowState == FormWindowState.Minimized)
                        //        {
                        //            open.WindowState = FormWindowState.Normal;
                        //        }
                        //        open.callFromDayBook(this, decMasterId);
                        //    }
                        //}
                        else if (strVoucherType == "PDC Clearance")
                        {
                            frmPdcClearance frmPdcClearance = new frmPdcClearance();
                            frmPdcClearance open = Application.OpenForms["frmPdcClearance"] as frmPdcClearance;
                            if (open == null)
                            {
                                frmPdcClearance.WindowState = FormWindowState.Normal;
                                //frmPdcClearance.MdiParent = formMDI.MDIObj;
                                //frmPdcClearance.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Purchase Order")
                        {
                            NewPurchaseOrder frmPurchaseOrder = new NewPurchaseOrder();
                            NewPurchaseOrder open = Application.OpenForms["frmPurchaseOrder"] as NewPurchaseOrder;
                            if (open == null)
                            {
                                frmPurchaseOrder.WindowState = FormWindowState.Normal;
                                //frmPurchaseOrder.MdiParent = formMDI.MDIObj;
                                //frmPurchaseOrder.callFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callFromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Sales Order")
                        {
                            FormSaleOrderAdd frmSalesOrder = new FormSaleOrderAdd();
                            FormSaleOrderAdd open = Application.OpenForms["frmSalesOrder"] as FormSaleOrderAdd;
                            if (open == null)
                            {
                                frmSalesOrder.WindowState = FormWindowState.Normal;
                                //frmSalesOrder.MdiParent = formMDI.MDIObj;
                                //frmSalesOrder.callfromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callfromDayBook(this, decMasterId);
                            }
                        }
                        else if (strVoucherType == "Sales Quotation")
                        {
                            FormQuotationAdd frmSalesQuotation = new FormQuotationAdd();
                            FormQuotationAdd open = Application.OpenForms["frmSalesQuotation"] as FormQuotationAdd;
                            if (open == null)
                            {
                                frmSalesQuotation.WindowState = FormWindowState.Normal;
                                //frmSalesQuotation.MdiParent = formMDI.MDIObj;
                                //frmSalesQuotation.callfromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.callfromDayBook(this, decMasterId);
                            }
                        }
                        //else if (strVoucherType == "Physical Stock")
                        //{
                        //    frmPhysicalStock frmPhysicalStock = new frmPhysicalStock();
                        //    frmPhysicalStock open = Application.OpenForms["frmPhysicalStock"] as frmPhysicalStock;
                        //    if (open == null)
                        //    {
                        //        frmPhysicalStock.WindowState = FormWindowState.Normal;
                        //        frmPhysicalStock.MdiParent = formMDI.MDIObj;
                        //        frmPhysicalStock.callFromDayBook(this, decMasterId);
                        //    }
                        //    else
                        //    {
                        //        if (open.WindowState == FormWindowState.Minimized)
                        //        {
                        //            open.WindowState = FormWindowState.Normal;
                        //        }
                        //        open.callFromDayBook(this, decMasterId);
                        //    }
                        //}
                        //else if (strVoucherType == "Stock Journal")
                        //{
                        //    frmStockJournal frmStockJournal = new frmStockJournal();
                        //    frmStockJournal open = Application.OpenForms["frmStockJournal"] as frmStockJournal;
                        //    if (open == null)
                        //    {
                        //        frmStockJournal.WindowState = FormWindowState.Normal;
                        //        frmStockJournal.MdiParent = formMDI.MDIObj;
                        //        frmStockJournal.CallFromDayBook(this, decMasterId);
                        //    }
                        //    else
                        //    {
                        //        if (open.WindowState == FormWindowState.Minimized)
                        //        {
                        //            open.WindowState = FormWindowState.Normal;
                        //        }
                        //        open.CallFromDayBook(this, decMasterId);
                        //    }
                        //}
                        else if (strVoucherType == "Daily Salary Voucher")
                        {
                            //frmDailySalaryVoucher frmDailySalaryVoucher = new frmDailySalaryVoucher();
                            //frmDailySalaryVoucher open = Application.OpenForms["frmDailySalaryVoucher"] as frmDailySalaryVoucher;
                            //if (open == null)
                            //{
                            //    frmDailySalaryVoucher.WindowState = FormWindowState.Normal;
                            //    //frmDailySalaryVoucher.MdiParent = formMDI.MDIObj;
                            //    //frmDailySalaryVoucher.CallFromDayBook(this, decMasterId);
                            //}
                            //else
                            //{
                            //    if (open.WindowState == FormWindowState.Minimized)
                            //    {
                            //        open.WindowState = FormWindowState.Normal;
                            //    }
                            //    //open.CallFromDayBook(this, decMasterId);
                            //}
                        }
                        else if (strVoucherType == "Monthly Salary Voucher")
                        {
                            //frmMonthlySalaryVoucher frmMonthlySalaryVoucher = new frmMonthlySalaryVoucher();
                            //frmMonthlySalaryVoucher open = Application.OpenForms["frmMonthlySalaryVoucher"] as frmMonthlySalaryVoucher;
                            //if (open == null)
                            //{
                            //    frmMonthlySalaryVoucher.WindowState = FormWindowState.Normal;
                            //    //frmMonthlySalaryVoucher.MdiParent = formMDI.MDIObj;
                            //    //frmMonthlySalaryVoucher.CallFromDayBook(this, decMasterId);
                            //}
                            //else
                            //{
                            //    if (open.WindowState == FormWindowState.Minimized)
                            //    {
                            //        open.WindowState = FormWindowState.Normal;
                            //    }
                            //    //open.CallFromDayBook(this, decMasterId);
                            //}
                        }
                        else if (strVoucherType == "Advance Payment")
                        {
                            frmAdvancePayment frmAdvancePayment = new frmAdvancePayment();
                            frmAdvancePayment open = Application.OpenForms["frmAdvancePayment"] as frmAdvancePayment;
                            if (open == null)
                            {
                                frmAdvancePayment.WindowState = FormWindowState.Normal;
                                //frmAdvancePayment.MdiParent = formMDI.MDIObj;
                                //frmAdvancePayment.CallFromDayBook(this, decMasterId);
                            }
                            else
                            {
                                if (open.WindowState == FormWindowState.Minimized)
                                {
                                    open.WindowState = FormWindowState.Normal;
                                }
                                //open.CallFromDayBook(this, decMasterId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On 'Export' button click to export the report to Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportNew ex = new ExportNew();
                ex.ExportExcel(dgvDayBook, "Day Book", 0, 0, "Excel", null, null, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB29:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Navigations
        /// <summary>
        /// For shortcut keys
        /// Esc for formclosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDayBook_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Messages.CloseMessage(this);
                    this.Close();

                }
                if (e.KeyCode == Keys.P && Control.ModifierKeys == Keys.Control)
                {
                    btnPrint.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enterkey and backspace navigation of txtToDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (txtToDate.Text == string.Empty || txtToDate.SelectionStart == 0)
                    {
                        txtFromDate.Focus();
                        txtFromDate.SelectionLength = 0;
                        txtFromDate.SelectionStart = 0;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbVoucherType.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enterkey and backspace navigation of cmbVoucherType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbVoucherType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtToDate.Focus();
                    txtToDate.SelectionLength = 0;
                    txtToDate.SelectionStart = 0;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbLedger.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enterkey and backspace navigation of cmbLedger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLedger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbtnCondensed.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    cmbVoucherType.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB22:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enterkey navigation of cmbLedger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtToDate.Focus();
                    txtToDate.SelectionLength = 0;
                    txtToDate.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB23:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enterkey and backspace navigation of rbtnCondensed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnCondensed_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbtnDetailed.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    cmbLedger.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB24:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enterkey and backspace navigation of rbtnDetailed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnDetailed_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    rbtnCondensed.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB25:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enterkey and backspace navigation of btnSearch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvDayBook.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    rbtnDetailed.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// backspace navigation of btnReset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    btnSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB27:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enterkey and backspace navigation of dgvDayBook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDayBook_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (dgvDayBook.CurrentCell == dgvDayBook.Rows[0].Cells["Sl No"])
                    {
                        btnReset.Focus();
                        dgvDayBook.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB28:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


    }
}
