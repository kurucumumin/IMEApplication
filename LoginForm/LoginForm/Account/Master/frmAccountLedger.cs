//This is a source code or part of OpenMiracle project
//Copyright (C) 2013  Cybrosys Technologies Pvt.Ltd
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.
using LoginForm.Account.Services;
using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace LoginForm
{
    public partial class frmAccountLedger : Form
    {
        # region Public Variables
        /// <summary>
        ///  public variable declaration part
        /// </summary>
        string strGroup;
        string strBankAccount;
        string strGroupName;
        bool isSundryDebtorOrCreditor = false; // To indicate whether the selected accontgroup is under sundrydebtor or creditor
        bool isBankAccount = false; // To indicate whether the selected accontgroup is under BankAccount or BankODAccount
        decimal decLedgerId;
        decimal decLedger;
        decimal decAccountLedgerId;
        int inNarrationCount = 0;
        bool isGrid = false;
        bool isDefault;
        decimal decIdForOtherForms = 0;
        string strComboTypes = string.Empty;
        //frmAdvancePayment frmAdvancePaymentobj;
        //frmDailySalaryVoucher frmDailysalaryvoucherobj;
        //frmMonthlySalaryVoucher frmMonthlySalaryVoucherObj;
        //frmContraVoucher frmContraVoucherObj;
        frmPaymentVoucher frmPaymentVoucherObj;
        frmReceiptVoucher frmReceiptVoucherObj;
        frmJournalVoucher frmJournalVoucherObj;
        //frmPurchaseOrder frmPurchaseOrderObj;
        //frmServiceVoucher frmServiceVoucherObj;
        //frmMaterialReceipt frmMaterialReceptObj = null;
        frmDebitNote frmDebitNoteObj = null;
        frmCreditNote frmCreditNoteObj = null;
        //frmRejectionOut frmRejectionOutObj;
        //frmDeliveryNote frmDeliveryNoteObj;
        frmSalesInvoice frmSalesInvoiceObj;
        //frmPurchaseInvoice frmPurchaseInvoiceObj = null;
        frmPurchaseReturn frmPurchaseReturnObj;
        //frmSalesQuotation frmSalesQuotationObj;
        frmPdcPayable frmPdcpayableObj;
        frmPdcPayable frmPdcpayableObj2;
        //frmSalesOrder frmSalesOrderObj;
        frmSalesReturn frmSalesReturnObj;
        //frmRejectionIn frmRejectionInObj;
        frmPdcReceivable frmpdcreceivableObj;
        frmPdcReceivable frmpdcreceivableObj2;
        //frmPOS frmPOSObj;
        bool isFromSalesReturnCashOrPartyCombo = false;
        bool isFromSalesReturnSalesAccountCombo = false;
        bool isFromPurchaseReturnCashOrPartyCombo = false;
        bool isFromPurchaseReturnPurchaseAccountCombo = false;
        decimal decOpeningBalance = 0;
        #endregion
        # region Functions
        /// <summary>
        /// Creates an instance of a frmLogin class.
        /// </summary>
        public frmAccountLedger()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to save account ledger
        /// </summary>
        public void SaveFunction()
        {
            IMEEntities db = new IMEEntities();

            try
            {
                AccountLedger accountLedger = new AccountLedger();
                accountLedger.ledgerName = txtLedgerName.Text.Trim();
                accountLedger.accountGroupID = Convert.ToInt32(cmbGroup.SelectedValue.ToString());
                decOpeningBalance = Convert.ToDecimal(((txtOpeningBalance.Text == "") ? "0" : txtOpeningBalance.Text.Trim()));
                accountLedger.openingBalance = decOpeningBalance;
                accountLedger.crOrDr = cmbOpeningBalanceCrOrDr.Text.Trim();
                accountLedger.narration = txtNarration.Text.Trim();
                accountLedger.isDefault = false;
                if (isBankAccount)
                {
                    accountLedger.bankAccountNumber = txtAcNo.Text.Trim();
                    accountLedger.branchName = txtBranchName.Text.Trim();
                    accountLedger.branchCode = txtBranchCode.Text.Trim();
                }
                else
                {
                    if (isSundryDebtorOrCreditor)
                    {
                        accountLedger.bankAccountNumber = txtAccountNo.Text;
                        accountLedger.branchName = string.Empty;
                        accountLedger.branchCode = string.Empty;
                    }
                    else
                    {
                        accountLedger.bankAccountNumber = string.Empty;
                        accountLedger.branchName = string.Empty;
                        accountLedger.branchCode = string.Empty;
                    }
                }
                if (isSundryDebtorOrCreditor)
                {
                    accountLedger.mailingName = txtMailingName.Text.Trim();
                    accountLedger.bankAccountNumber = txtAccountNo.Text.Trim();
                    accountLedger.address = txtAddress.Text.Trim();
                    accountLedger.phone = txtPhone.Text.Trim();
                    accountLedger.mobile = txtMobile.Text.Trim();
                    accountLedger.email = txtEmail.Text.Trim();
                    accountLedger.creditPeriod = Convert.ToInt32(txtCreditPeriod.Text.Trim());
                    accountLedger.creditLimit = Convert.ToDecimal(txtCreditLimit.Text.Trim());
                    if (cmbPricingLevel.SelectedIndex <= 0)
                    {
                        accountLedger.pricinglevelId = 1;
                    }
                    else
                    {
                        accountLedger.pricinglevelId = Convert.ToDecimal(cmbPricingLevel.SelectedValue.ToString());
                    }
                    if (cmbBillByBill.Text == "Yes")
                    {
                        accountLedger.billByBill = true;
                    }
                    else
                    {
                        accountLedger.billByBill = false;
                    }
                    accountLedger.tin = txtTin.Text.Trim();
                    accountLedger.cst = txtCst.Text.Trim();
                    accountLedger.pan = txtPan.Text.Trim();
                    if (cmbArea.SelectedIndex <= 0)
                    {
                        accountLedger.areaId = 2;
                    }
                    else
                    {
                        accountLedger.areaId = Convert.ToDecimal(cmbArea.SelectedValue.ToString());
                    }
                    if (cmbRoute.SelectedIndex < 0)
                    {
                        accountLedger.routeId = 1;
                    }
                    else
                    {
                        accountLedger.routeId = Convert.ToDecimal(cmbRoute.SelectedValue.ToString());
                    }
                    //accountLedger.extra1 = string.Empty;
                    //accountLedger.extra2 = string.Empty;
                }
                else
                {
                    accountLedger.mailingName = string.Empty;
                    accountLedger.bankAccountNumber = string.Empty;
                    accountLedger.address = string.Empty;
                    //accountLedger.state = string.Empty;
                    accountLedger.phone = string.Empty;
                    accountLedger.mobile = string.Empty;
                    accountLedger.email = string.Empty;
                    accountLedger.creditPeriod = 0;
                    accountLedger.creditLimit = 0;
                    accountLedger.pricinglevelId = 0;
                    accountLedger.billByBill = false;
                    accountLedger.tin = string.Empty;
                    accountLedger.cst = string.Empty;
                    accountLedger.pan = string.Empty;
                    accountLedger.routeId = 2;
                    accountLedger.areaId = 2;
                    //accountLedger.extra1 = string.Empty;
                    //accountLedger.extra2 = string.Empty;
                }
                if(new AccountLedgerSP().AccountLedgerCheckExistence(txtLedgerName.Text.Trim().ToString(), 0) == false)
                {
                    db.AccountLedgers.Add(accountLedger);
                    db.SaveChanges();
                    decLedgerId = accountLedger.ledgerId;
                    if (decOpeningBalance > 0)
                    {
                        LedgerPostingAdd();
                        if (cmbBillByBill.Text == "Yes" && isSundryDebtorOrCreditor)
                        {
                            PartyBalanceAdd();
                        }
                    }
                    Messages.SavedMessage();
                    Clear();
                }
                else
                {
                    Messages.InformationMessage("Ledger name already exist");
                    txtLedgerName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to edit account ledger
        /// </summary>
        public void EditFunction()
        {
            try
            {
                //        AccountLedgerInfo infoAccountLedger = new AccountLedgerInfo();
                //        AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                AccountLedger infoAccountLedger = new AccountLedger();
                infoAccountLedger.ledgerName = txtLedgerName.Text.Trim();
                infoAccountLedger.accountGroupID = Convert.ToInt32(cmbGroup.SelectedValue.ToString());
                infoAccountLedger.openingBalance = Convert.ToDecimal(((txtOpeningBalance.Text == "") ? "0" : txtOpeningBalance.Text.Trim()));
                infoAccountLedger.crOrDr = cmbOpeningBalanceCrOrDr.Text.Trim();
                infoAccountLedger.narration = txtNarration.Text.Trim();
                if (isBankAccount)
                {
                    infoAccountLedger.bankAccountNumber = txtAcNo.Text.Trim();
                    infoAccountLedger.branchName = txtBranchName.Text.Trim();
                    infoAccountLedger.branchCode = txtBranchCode.Text.Trim();
                }
                else
                {
                    if (isSundryDebtorOrCreditor)
                    {
                        infoAccountLedger.bankAccountNumber = txtAccountNo.Text;
                        infoAccountLedger.branchName = string.Empty;
                        infoAccountLedger.branchCode = string.Empty;
                    }
                    else
                    {
                        infoAccountLedger.bankAccountNumber = string.Empty;
                        infoAccountLedger.branchName = string.Empty;
                        infoAccountLedger.branchCode = string.Empty;
                    }
                }
                if (!isDefault)
                {
                    infoAccountLedger.isDefault = false;
                }
                else
                {
                    infoAccountLedger.isDefault = true;
                }
                if (isSundryDebtorOrCreditor)
                {
                    infoAccountLedger.mailingName = txtMailingName.Text.Trim();
                    infoAccountLedger.address = txtAddress.Text.Trim();
                    infoAccountLedger.phone = txtPhone.Text.Trim();
                    infoAccountLedger.mobile = txtMobile.Text.Trim();
                    infoAccountLedger.email = txtEmail.Text.Trim();
                    infoAccountLedger.creditPeriod = Convert.ToInt32(txtCreditPeriod.Text.Trim());
                    infoAccountLedger.creditLimit = Convert.ToDecimal(txtCreditLimit.Text.Trim());
                    if (cmbPricingLevel.SelectedIndex <= 0)
                    {
                        infoAccountLedger.pricinglevelId = 1;
                    }
                    else
                    {
                        infoAccountLedger.pricinglevelId = Convert.ToDecimal(cmbPricingLevel.SelectedValue.ToString());
                    }
                    if (cmbBillByBill.Text == "Yes")
                    {
                        infoAccountLedger.billByBill = true;
                    }
                    else
                    {
                        infoAccountLedger.billByBill = false;
                    }
                    infoAccountLedger.tin = txtTin.Text.Trim();
                    infoAccountLedger.cst = txtCst.Text.Trim();
                    infoAccountLedger.pan = txtPan.Text.Trim();
                    if (cmbArea.SelectedIndex <= 0)
                    {
                        infoAccountLedger.areaId = 1;
                    }
                    else
                    {
                        infoAccountLedger.areaId = Convert.ToDecimal(cmbArea.SelectedValue.ToString());
                    }
                    if (cmbRoute.SelectedIndex < 0)
                    {
                        infoAccountLedger.routeId = 1;
                    }
                    else
                    {
                        infoAccountLedger.routeId = Convert.ToDecimal(cmbRoute.SelectedValue.ToString());
                    }
                    //infoAccountLedger.Extra1 = string.Empty;
                    //infoAccountLedger.Extra2 = string.Empty;
                }
                else
                {
                    infoAccountLedger.mailingName = string.Empty;
                    infoAccountLedger.address = string.Empty;
                    //infoAccountLedger.State = string.Empty;
                    infoAccountLedger.phone = string.Empty;
                    infoAccountLedger.mobile = string.Empty;
                    infoAccountLedger.email = string.Empty;
                    infoAccountLedger.creditPeriod = 0;
                    infoAccountLedger.creditLimit = 0;
                    infoAccountLedger.pricinglevelId = 1;
                    infoAccountLedger.billByBill = false;
                    infoAccountLedger.tin = string.Empty;
                    infoAccountLedger.cst = string.Empty;
                    infoAccountLedger.pan = string.Empty;
                    infoAccountLedger.routeId = 1;
                    infoAccountLedger.areaId = 1;
                    //infoAccountLedger.Extra1 = string.Empty;
                    //infoAccountLedger.Extra2 = string.Empty;
                }
                infoAccountLedger.ledgerId = decAccountLedgerId;

                AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                if (spAccountLedger.AccountLedgerCheckExistence(txtLedgerName.Text.Trim(), decLedger) == false)
                {
                    spAccountLedger.AccountLedgerEdit(infoAccountLedger);
                    LedgerPostingEdit();
                    if (cmbBillByBill.Text == "Yes" && isSundryDebtorOrCreditor)
                    {
                        PartyBalanceEdit();
                    }
                    else
                    {
                        //spAccountLedger.PartyBalanceDeleteByVoucherTypeVoucherNoAndReferenceType(decAccountLedgerId.ToString(), 1);
                    }
                    Messages.UpdatedMessage();
                    Clear();
                }
                else
                {
                    Messages.InformationMessage("Ledgername already exist");
                    txtLedgerName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Funtion to call save and edit function
        /// </summary>
        public void SaveOrEdit()
        {
            try
            {
                if (txtMailingName.Text.Trim() == string.Empty)
                {
                    txtMailingName.Text = txtLedgerName.Text.Trim();
                }
                if (txtLedgerName.Text.Trim() == string.Empty)
                {
                    Messages.InformationMessage("Enter ledger name");
                    txtLedgerName.Focus();
                    tbctrlLedger.SelectedTab = tbMainDetails;
                }
                else if (cmbGroup.SelectedIndex == -1)
                {
                    Messages.InformationMessage("Select group name");
                    cmbGroup.Focus();
                    tbctrlLedger.SelectedTab = tbMainDetails;
                }
                else
                {
                    if (btnSave.Text == "Save")
                    {
                        //Jamshi
                        //if (PublicVariables.isMessageAdd)
                        //{
                        //    if (Messages.SaveMessage())
                        //    {
                        //        SaveFunction();
                        //    }
                        //}
                        //else
                        //{
                        //    SaveFunction();
                        //}
                        if (Messages.SaveConfirmation())
                        {
                            SaveFunction();
                        }
                        decIdForOtherForms = decLedgerId;
                    }
                    else
                    {
                        //Jamshi
                        //if (PublicVariables.isMessageEdit)
                        //{
                        //    if (Messages.UpdateMessage())
                        //    {
                        //        EditFunction();
                        //    }
                        //}
                        //else
                        //{
                        //    EditFunction();
                        //}
                        if (Messages.UpdateConfirmation())
                        {
                            EditFunction();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL3:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to save ledgerposting incase of opening balance
        /// </summary>
        public void LedgerPostingAdd()
        {
            IMEEntities db = new IMEEntities();
            try
            {
                string strfinancialId;
                decOpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text);
                LedgerPosting infoLedgerPosting = new LedgerPosting();
                FinancialYear infoFinancialYear = new FinancialYear();
                infoFinancialYear = new FinancialYearSP().FinancialYearViewForAccountLedger(1);
                strfinancialId = infoFinancialYear.fromDate.Value.ToString("dd-MMM-yyyy");
                infoLedgerPosting.voucherTypeId = 1;
                infoLedgerPosting.date = Convert.ToDateTime(strfinancialId.ToString());
                infoLedgerPosting.ledgerId = decLedgerId;
                infoLedgerPosting.voucherNo = decLedgerId.ToString();
                if (cmbOpeningBalanceCrOrDr.Text == "Dr")
                {
                    infoLedgerPosting.debit = decOpeningBalance;
                }
                else
                {
                    infoLedgerPosting.credit = decOpeningBalance;
                }
                infoLedgerPosting.detailsId = 0;
                infoLedgerPosting.yearId = Utils.getManagement().CurrentFinancialYear;
                infoLedgerPosting.invoiceNo = decLedgerId.ToString();
                infoLedgerPosting.chequeNo = string.Empty;
                infoLedgerPosting.chequeDate = DateTime.Now;

                db.LedgerPostings.Add(infoLedgerPosting);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL4:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///Function to edit ledgerposting incase of opening balance
        /// </summary> 
        public void LedgerPostingEdit()
        {
            LedgerPostingSP spledgerPosting = new LedgerPostingSP();
            try
            {
                string strfinancialId;
                decOpeningBalance = Convert.ToDecimal(((txtOpeningBalance.Text == "") ? "0" : txtOpeningBalance.Text.Trim()));
                LedgerPosting infoLedgerPosting = new LedgerPosting();
                FinancialYear infoFinancialYear = new FinancialYear();
                infoFinancialYear =new FinancialYearSP().FinancialYearViewForAccountLedger(1);
                strfinancialId = infoFinancialYear.fromDate.Value.ToString("dd-MMM-yyyy");
                infoLedgerPosting.voucherTypeId = 1;
                infoLedgerPosting.date = Convert.ToDateTime(strfinancialId.ToString());
                if (cmbOpeningBalanceCrOrDr.Text == "Dr")
                {
                    infoLedgerPosting.debit = decOpeningBalance;
                }
                else
                {
                    infoLedgerPosting.credit = decOpeningBalance;
                }
                infoLedgerPosting.detailsId = 0;
                infoLedgerPosting.yearId = Utils.getManagement().CurrentFinancialYear;
                infoLedgerPosting.invoiceNo = decAccountLedgerId.ToString();
                infoLedgerPosting.ledgerId = decAccountLedgerId;
                infoLedgerPosting.voucherNo = decAccountLedgerId.ToString();
                infoLedgerPosting.chequeNo = string.Empty;
                infoLedgerPosting.chequeDate = DateTime.Now;
                DataTable dtbl = spledgerPosting.GetLedgerPostingIds(decAccountLedgerId.ToString(), 1);
                if (dtbl.Rows.Count > 0)
                {
                    if (decOpeningBalance > 0)
                    {
                        //Edit
                        infoLedgerPosting.ledgerPostingId = Convert.ToDecimal(dtbl.Rows[0][0].ToString());
                        spledgerPosting.LedgerPostingEdit(infoLedgerPosting);
                    }
                    else
                    {
                        //Delete
                        new AccountLedgerSP().LedgerPostingDeleteByVoucherTypeAndVoucherNo(decAccountLedgerId.ToString(), 1);
                    }
                }
                else
                {
                    //Add new row
                    spledgerPosting.LedgerPostingAdd(infoLedgerPosting);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        /// <summary>
        ///Function to save opening balance to party balance
        /// </summary> 
        public void PartyBalanceAdd()
        {
            try
            {
                PartyBalance infoPatryBalance = new PartyBalance();
                AccountLedger spLedger = new AccountLedger();
                if (decOpeningBalance > 0)
                {
                    if (cmbBillByBill.Text == "Yes")
                    {
                        infoPatryBalance.date = DateTime.Now;
                        infoPatryBalance.ledgerId = decLedgerId;
                        infoPatryBalance.voucherTypeId = 1;
                        infoPatryBalance.voucherNo = decLedgerId.ToString();
                        infoPatryBalance.againstVoucherTypeId = 0;
                        infoPatryBalance.againstVoucherNo = "0";
                        infoPatryBalance.referenceType = "New";
                        if (cmbOpeningBalanceCrOrDr.Text == "Dr")
                        {
                            infoPatryBalance.debit = decOpeningBalance;
                            infoPatryBalance.credit = 0;
                        }
                        else
                        {
                            infoPatryBalance.debit = 0;
                            infoPatryBalance.credit = decOpeningBalance;
                        }
                        infoPatryBalance.invoiceNo = "0";
                        infoPatryBalance.againstInvoiceNo = "0";
                        infoPatryBalance.creditPeriod = 0;
                        infoPatryBalance.exchangeRateId = Convert.ToInt32(new ExchangeRateSP().ExchangerateViewByCurrencyId(Convert.ToDecimal(Utils.getManagement().DefaultCurrency)));
                        infoPatryBalance.financialYearId = Utils.getManagement().CurrentFinancialYear;
                    }
                    new PartyBalanceSP().PartyBalanceAdd(infoPatryBalance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to edit opening balance incase of opening balance
        /// </summary>        
        public void PartyBalanceEdit()
        {
            Management m = Utils.getManagement();
            try
            {
                PartyBalance infoPatryBalance = new PartyBalance();
                new AccountLedgerSP().PartyBalanceDeleteByVoucherTypeVoucherNoAndReferenceType(decAccountLedgerId.ToString(), 1);
                if (decOpeningBalance > 0)
                {
                    if (cmbBillByBill.Text == "Yes")
                    {
                        infoPatryBalance.date = DateTime.Now.Date;
                        infoPatryBalance.ledgerId = decAccountLedgerId;
                        infoPatryBalance.voucherTypeId = 1;
                        infoPatryBalance.voucherNo = decAccountLedgerId.ToString();
                        infoPatryBalance.againstVoucherTypeId = 0;
                        infoPatryBalance.againstVoucherNo = "0";
                        infoPatryBalance.referenceType = "New";
                        if (cmbOpeningBalanceCrOrDr.Text == "Dr")
                        {
                            infoPatryBalance.debit = decOpeningBalance;
                            infoPatryBalance.credit = 0;
                        }
                        else
                        {
                            infoPatryBalance.debit = 0;
                            infoPatryBalance.credit = decOpeningBalance;
                        }
                        infoPatryBalance.invoiceNo = "0";
                        infoPatryBalance.againstInvoiceNo = "0";
                        infoPatryBalance.creditPeriod = 0;
                        infoPatryBalance.exchangeRateId = Convert.ToInt32(new ExchangeRateSP().ExchangerateViewByCurrencyId(Convert.ToDecimal(m.DefaultCurrency)));
                        infoPatryBalance.financialYearId = m.CurrentFinancialYear;
                    }
                    new PartyBalanceSP().PartyBalanceAdd(infoPatryBalance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to fill acoountgroup combobox
        /// </summary>  
        public void AccountGroupComboFill()
        {
            try
            {
                cmbGroup.DataSource = new AccountGroupSP().AccountGroupViewAllComboFillForAccountLedger();
                cmbGroup.ValueMember = "accountGroupId";
                cmbGroup.DisplayMember = "accountGroupName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill acoountgroup combobox
        /// </summary>
        public void AccountGroupComboFillSearch()
        {
            try
            {
                DataTable dtblAccountGroupSearch = new DataTable();
                dtblAccountGroupSearch = new AccountGroupSP().AccountGroupViewAllComboFill();
                DataRow dr = dtblAccountGroupSearch.NewRow();
                dr[1] = "All";
                dtblAccountGroupSearch.Rows.InsertAt(dr, 0);
                cmbGroupSearch.DataSource = dtblAccountGroupSearch;
                cmbGroupSearch.ValueMember = "accountGroupId";
                cmbGroupSearch.DisplayMember = "accountGroupName";
                cmbGroupSearch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to fill pricing level combobox
        /// </summary> 
        public void PrlicingLevelComboFill()
        {
            try
            {
                DataTable dtblPrlicingLevel = new DataTable();
                dtblPrlicingLevel = new PricingLevelSP().PricelistPricingLevelViewAllForComboBox();
                cmbPricingLevel.DataSource = dtblPrlicingLevel;
                DataRow dr = dtblPrlicingLevel.NewRow();

                cmbPricingLevel.ValueMember = "pricinglevelId";
                cmbPricingLevel.DisplayMember = "pricinglevelName";

            }
            catch (Exception ex)
            {
                MessageBox.Show("AL10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to fill area combobox
        /// </summary> 
        public void AreaComboFill()
        {
            try
            {
                DataTable dtblArea = new DataTable();
                dtblArea = new AreaSP().AreaViewAll();
                DataRow dr = dtblArea.NewRow();
                cmbArea.DataSource = dtblArea;
                cmbArea.ValueMember = "areaId";
                cmbArea.DisplayMember = "areaName";
                cmbArea.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to fill route combobox
        /// </summary> 
        public void RouteComboFill()
        {
            try
            {
                if (cmbArea.Items.Count > 0)
                {
                    if (cmbArea.SelectedIndex != -1)
                    {
                        if (cmbArea.SelectedValue.ToString() != "System.Data.DataRowView" && cmbArea.Text != "System.Data.DataRowView")
                        {
                            DataTable dtblRoute = new DataTable();
                            dtblRoute = new RouteSP().RouteViewByArea(Convert.ToDecimal(cmbArea.SelectedValue.ToString()));
                            cmbRoute.DataSource = dtblRoute;
                            cmbRoute.ValueMember = "routeId";
                            cmbRoute.DisplayMember = "routeName";
                            cmbRoute.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to clear fields
        /// </summary>         
        public void Clear()
        {
            try
            {
                txtAccountNo.Clear();
                txtAcNo.Clear();
                txtAddress.Clear();
                txtBranchName.Clear();
                txtBranchCode.Clear();
                txtCst.Clear();
                txtEmail.Clear();
                txtLedgerName.Clear();
                txtLedgerNameSearch.Clear();
                txtMailingName.Clear();
                txtMobile.Clear();
                txtNarration.Clear();
                txtPan.Clear();
                txtPhone.Clear();
                txtTin.Clear();
                AreaComboFill();
                cmbArea.SelectedIndex = 0;
                if (new SettingsSP().SettingsStatusCheck("BillByBill") == "Yes")
                {
                    cmbBillByBill.Enabled = true;
                    cmbBillByBill.Text = "No";
                }
                else
                {
                    cmbBillByBill.Enabled = false;
                }
                cmbGroup.SelectedIndex = -1;
                cmbPricingLevel.SelectedIndex = 0;
                txtOpeningBalance.Text = "0.00";
                txtCreditLimit.Text = "0.00";
                txtCreditPeriod.Text = "0";
                cmbOpeningBalanceCrOrDr.Text = "Dr";
                btnSave.Text = "Save";
                txtLedgerName.ReadOnly = false;
                btnDelete.Enabled = false;
                tbctrlLedger.SelectedTab = tbMainDetails;
                isSundryDebtorOrCreditor = false;
                isBankAccount = false;
                cmbGroupSearch.SelectedIndex = 0;
                cmbGroup.Enabled = true;
                GridFill();
                txtLedgerName.Select();
                gbxDetails.Visible = false;
                txtOpeningBalance.Enabled = true;
                cmbOpeningBalanceCrOrDr.Enabled = true;
                btnAccountGroupAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL13:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to fill datagridview
        /// </summary>        
        public void GridFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = new AccountLedgerSP().AccountLedgerSearch(cmbGroupSearch.Text, txtLedgerNameSearch.Text.Trim());
                dgvAccountLedger.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL14:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmDailySalaryVoucher for creating new account ledger
        /// </summary>
        /// <param name="frmdailysalaryvoucher"></param>
        /// 
        //TODO OpenMiracle Function
        //public void CallFromDailySalaryVoucher(frmDailySalaryVoucher frmdailysalaryvoucher)
        //{
        //try
        //{
        //    dgvAccountLedger.Enabled = false;
        //    txtLedgerNameSearch.Enabled = false;
        //    btnSearch.Enabled = false;
        //    cmbGroupSearch.Enabled = false;
        //    dgvAccountLedger.Enabled = false;
        //    lblLedgerNameSearch.Enabled = false;
        //    lblGroupSearch.Enabled = false;
        //    this.frmDailysalaryvoucherobj = frmdailysalaryvoucher;
        //    base.Show();
        //    frmdailysalaryvoucher.Enabled = false;
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show("AL15:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        //}
        /// <summary>
        /// Function to call this form from frmMonthlySalaryVoucher for creating new account ledger
        /// </summary>
        /// <param name="frmMonthlySalaryVoucher"></param>
        /// //TODO OpenMiracle Function
        //public void CallFromMonthlySalaryVoucher(frmMonthlySalaryVoucher frmMonthlySalaryVoucher)
        //{
        //try
        //{
        //    dgvAccountLedger.Enabled = false;
        //    txtLedgerNameSearch.Enabled = false;
        //    btnSearch.Enabled = false;
        //    cmbGroupSearch.Enabled = false;
        //    dgvAccountLedger.Enabled = false;
        //    lblLedgerNameSearch.Enabled = false;
        //    lblGroupSearch.Enabled = false;
        //    this.frmMonthlySalaryVoucherObj = frmMonthlySalaryVoucher;
        //    base.Show();
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show("AL16:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        //}
        /// <summary>
        /// Function to call this form from frmReceiptVoucher for creating new account ledger
        /// </summary>
        /// <param name="frmReceiptVoucher"></param>
        /// <param name="strComboType"></param>
        /// //TODO OpenMiracle Function
        public void CallFromReceiptVoucher(frmReceiptVoucher frmReceiptVoucher, string strComboType)
        {
            try
            {
                base.Show();
                strComboTypes = strComboType;
                this.frmReceiptVoucherObj = frmReceiptVoucher;
                frmReceiptVoucherObj.Enabled = false;
                groupBox2.Enabled = false;
                dgvAccountLedger.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmAdvancePayment for creating new account ledger
        /// </summary>
        /// <param name="frmadvancepayment"></param>
        /// //TODO OpenMiracle Function
        public void CallFromAdvancePayment(frmAdvancePayment frmadvancepayment)
        {
            try
            {
                dgvAccountLedger.Enabled = false;
                txtLedgerNameSearch.Enabled = false;
                btnSearch.Enabled = false;
                cmbGroupSearch.Enabled = false;
                dgvAccountLedger.Enabled = false;
                lblLedgerNameSearch.Enabled = false;
                lblGroupSearch.Enabled = false;
                //this.frmAdvancePaymentobj = frmadvancepayment;
                base.Show();
                txtLedgerName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmContraVoucher for creating new account ledger
        /// </summary>
        /// <param name="frmContravoucher"></param>
        /// <param name="isGrids"></param>
        /// //TODO OpenMiracle Function
        //public void CallFromContraVoucher(frmContraVoucher frmContravoucher, bool isGrids)
        //{
        //    try
        //    {
        //        this.frmContraVoucherObj = frmContravoucher;
        //        base.Show();
        //        isGrid = isGrids;
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //        cmbGroup.SelectedValue = 27;    // 27 is account group id for cash in hand
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmSalesReturn for creating new account ledger
        /// </summary>
        /// <param name="frmSalesReturn"></param>
        /// <param name="isFromCorParty"></param>
        /// <param name="isFromSA"></param>
        /// //TODO OpenMiracle Function
        public void CallFromSalesReturn(frmSalesReturn frmSalesReturn, bool isFromCorParty, bool isFromSA)
        {
            try
            {
                isFromSalesReturnCashOrPartyCombo = isFromCorParty;
                isFromSalesReturnSalesAccountCombo = isFromSA;
                dgvAccountLedger.Enabled = false;
                txtLedgerNameSearch.Enabled = false;
                cmbGroupSearch.Enabled = false;
                btnSearch.Enabled = false;
                lblLedgerNameSearch.Enabled = false;
                lblGroupSearch.Enabled = false;
                this.frmSalesReturnObj = frmSalesReturn;
                base.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmSalesInvoice for creating new account ledger
        /// </summary>
        /// <param name="frmSalesInvoice"></param>
        /// <param name="isFromCorParty"></param>
        /// <param name="isFromSA"></param>
        /// //TODO OpenMiracle Function
        public void callFromSalesInvoice(frmSalesInvoice frmSalesInvoice, bool isFromCorParty, bool isFromSA)
        {
            try
            {
                isFromSalesReturnCashOrPartyCombo = isFromCorParty;
                isFromSalesReturnSalesAccountCombo = isFromSA;
                txtLedgerNameSearch.Enabled = false;
                btnSearch.Enabled = false;
                cmbGroupSearch.Enabled = false;
                dgvAccountLedger.Enabled = false;
                lblLedgerNameSearch.Enabled = false;
                lblGroupSearch.Enabled = false;
                this.frmSalesInvoiceObj = frmSalesInvoice;
                base.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmJournalVoucher for creating new account ledger
        /// </summary>
        /// <param name="journalVoucherObj"></param>
        /// <param name="strLedgerName"></param>
        //TODO OpenMiracle Function
        public void CallFromJournalVoucher(frmJournalVoucher journalVoucherObj, string strLedgerName)
        {
            try
            {
                base.Show();
                this.frmJournalVoucherObj = journalVoucherObj;
                frmJournalVoucherObj.Enabled = false;
                dgvAccountLedger.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL22:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmPurchaseOrder for creating new account ledger
        /// </summary>
        /// <param name="frmPurchaseOrder"></param
        //TODO OpenMiracle Function
        //public void CallFromPurchaseOrder(frmPurchaseOrder frmPurchaseOrder)
        //{
        //    try
        //    {
        //        groupBox2.Enabled = false;
        //        this.frmPurchaseOrderObj = frmPurchaseOrder;
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //        base.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL23:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmRejectionIn for creating new account ledger
        /// </summary>
        /// <param name="frmRejectionIn"></param>
        /// //TODO OpenMiracle Function
        //public void CallFromRejectionIn(frmRejectionIn frmRejectionIn)
        //{
        //    try
        //    {
        //        this.frmRejectionInObj = frmRejectionIn;
        //        frmRejectionInObj.Enabled = false;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL24:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to delete account ledger
        /// </summary>
        public void Delete()
        {
            IMEEntities db = new IMEEntities();
            try
            {
                if (!isDefault)
                {
                    if (Messages.DeleteConfirmation())
                    {
                        AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                        spAccountLedger.PartyBalanceDeleteByVoucherTypeVoucherNoAndReferenceType(decAccountLedgerId.ToString(), 1);
                        spAccountLedger.LedgerPostingDeleteByVoucherTypeAndVoucherNo(decAccountLedgerId.ToString(), 1);
                        if (spAccountLedger.AccountLedgerCheckReferences(decAccountLedgerId) == -1)
                        {
                            Messages.ReferenceExistsMessage();
                        }
                        else
                        {
                            Messages.DeletedMessage();
                            Clear();
                        }
                    }
                }
                else
                {
                    Messages.InformationMessage("Can't delete build in account ledger");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL25:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Function to fill data in to controls when click on datagridview
        /// </summary>        
        public void FillControls()
        {
            try
            {
                AccountLedger infoAccountLedger = new AccountLedger();
                AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                infoAccountLedger = spAccountLedger.AccountLedgerViewForEdit(decAccountLedgerId);
                txtAccountNo.Text = infoAccountLedger.bankAccountNumber;
                txtAcNo.Text = infoAccountLedger.bankAccountNumber;
                txtAddress.Text = infoAccountLedger.address;
                txtBranchName.Text = infoAccountLedger.branchName;
                txtBranchCode.Text = infoAccountLedger.branchCode;
                txtCst.Text = infoAccountLedger.cst;
                txtEmail.Text = infoAccountLedger.email;
                txtLedgerName.Text = infoAccountLedger.ledgerName;
                txtMailingName.Text = infoAccountLedger.mailingName;
                txtMobile.Text = infoAccountLedger.mobile;
                txtNarration.Text = infoAccountLedger.narration;
                txtPan.Text = infoAccountLedger.pan;
                txtPhone.Text = infoAccountLedger.phone;
                txtTin.Text = infoAccountLedger.tin;
                txtCreditLimit.Text = infoAccountLedger.creditLimit.ToString();
                txtCreditPeriod.Text = infoAccountLedger.creditPeriod.ToString();
                cmbArea.SelectedValue = infoAccountLedger.areaId.ToString();
                if ((bool)infoAccountLedger.billByBill)
                {
                    cmbBillByBill.Text = "Yes";
                }
                else
                {
                    cmbBillByBill.Text = "No";
                }
                cmbGroup.SelectedValue = infoAccountLedger.accountGroupID.ToString();
                PrlicingLevelComboFill();
                cmbPricingLevel.SelectedValue = infoAccountLedger.pricinglevelId;
                cmbRoute.SelectedValue = infoAccountLedger.routeId.ToString();
                decimal decBalance = Convert.ToDecimal(infoAccountLedger.openingBalance);
                txtOpeningBalance.Text = decBalance.ToString();
                cmbOpeningBalanceCrOrDr.Text = infoAccountLedger.crOrDr.ToString();
                if (infoAccountLedger.isDefault == true)
                {
                    cmbGroup.Enabled = false;
                    txtLedgerName.ReadOnly = true;
                    btnAccountGroupAdd.Enabled = false;
                    txtLedgerName.BackColor = Color.WhiteSmoke;
                }
                else if (infoAccountLedger.isDefault == false && decBalance > 0)
                {
                    cmbGroup.Enabled = false;
                    btnAccountGroupAdd.Enabled = false;
                    txtLedgerName.ReadOnly = false;
                    txtLedgerName.BackColor = Color.White;
                }
                else
                {
                    cmbGroup.Enabled = true;
                    txtLedgerName.ReadOnly = false;
                    txtLedgerName.BackColor = Color.White;
                    btnAccountGroupAdd.Enabled = true;
                }
                if (spAccountLedger.PartyBalanceAgainstReferenceCheck(decAccountLedgerId.ToString(), 1))
                {
                    cmbGroup.Enabled = false;
                    txtLedgerName.ReadOnly = false;
                    txtOpeningBalance.Enabled = false;
                    cmbOpeningBalanceCrOrDr.Enabled = false;
                    cmbBillByBill.Enabled = false;
                    txtLedgerName.BackColor = Color.White;
                }
                decLedger = infoAccountLedger.ledgerId;
                isDefault = Convert.ToBoolean(infoAccountLedger.isDefault);
                tbctrlLedger.SelectedTab = tbMainDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to refill acountgroup combobox when returns from accountgroup form
        /// </summary>
        /// <param name="decId"></param>
        public void ReturnFromAccountGroupForm(decimal decId)
        {
            try
            {
                AccountGroupComboFill();
                AccountGroupComboFillSearch();
                if (!isBankAccount)
                {
                    gbxDetails.Visible = false;
                }
                else
                {
                    gbxDetails.Visible = true;
                }
                if (decId.ToString() != "0")
                {
                    cmbGroup.SelectedValue = decId;
                }
                else if (strGroupName != string.Empty)
                {
                    cmbGroup.SelectedValue = strGroupName;
                }
                else
                {
                    cmbGroup.SelectedIndex = -1;
                }
                this.Enabled = true;
                this.Activate();
                cmbGroup.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL27:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //TODO OpenMiracle Function
        public void CallFromPaymentVoucher(frmPaymentVoucher frmPaymentVoucherObj, string strComboType)
        {
            try
            {
                strComboTypes = strComboType;
                dgvAccountLedger.Enabled = false;
                txtLedgerNameSearch.Enabled = false;
                btnSearch.Enabled = false;
                cmbGroupSearch.Enabled = false;
                dgvAccountLedger.Enabled = false;
                lblLedgerNameSearch.Enabled = false;
                lblGroupSearch.Enabled = false;
                base.Show();
                this.frmPaymentVoucherObj = frmPaymentVoucherObj;
                frmPaymentVoucherObj.Enabled = false;
                txtLedgerName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL28:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmServiceVoucher for creating new account ledger
        /// </summary>
        /// <param name="frmServiceVoucherObj"></param> 
        /// //TODO OpenMiracle Function
        //public void CallFromServiceVoucher(frmServiceVoucher frmServiceVoucherObj)
        //{
        //    try
        //    {
        //        this.frmServiceVoucherObj = frmServiceVoucherObj;
        //        frmServiceVoucherObj.Enabled = false;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //        cmbGroup.SelectedValue = 27;    // 27 is account group id for cash in hand
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL29:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmDebitNote for creating new account ledger
        /// </summary>
        /// <param name="frmDebitNoteObj"></param>
        /// <param name="strLedgerName"></param>  
        //TODO OpenMiracle Function
        //public void CallFromDebitNoteVoucher(frmDebitNote frmDebitNoteObj, string strLedgerName)
        //{
        //    try
        //    {
        //        base.Show();
        //        this.frmDebitNoteObj = frmDebitNoteObj;
        //        frmDebitNoteObj.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL30:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmCreditNote for creating new account ledger
        /// </summary>
        /// <param name="frmCreditNoteObj"></param>
        /// <param name="strLedgerName"></param>     
        //TODO OpenMiracle Function
        public void CallFromCreditNote(frmCreditNote frmCreditNoteObj, string strLedgerName)
        {
            try
            {
                base.Show();
                this.frmCreditNoteObj = frmCreditNoteObj;
                frmCreditNoteObj.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL31:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmMaterialReceipt for creating new account ledger
        /// </summary>
        /// <param name="frmMaterialReceipt"></param>
        /// //TODO OpenMiracle Function
        //public void callFromMaterialReceipt(frmMaterialReceipt frmMaterialReceipt)
        //{
        //    try
        //    {
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //        this.frmMaterialReceptObj = frmMaterialReceipt;
        //        frmMaterialReceptObj.Enabled = false;
        //        base.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL32:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmRejectionOut for creating new account ledger
        /// </summary>
        /// <param name="frmRejectionOut"></param>   
        //TODO OpenMiracle Function
        //public void callFromRejectionOut(frmRejectionOut frmRejectionOut)
        //{
        //    try
        //    {
        //        this.frmRejectionOutObj = frmRejectionOut;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL33:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmDeliveryNote for creating new account ledger
        /// </summary>
        /// <param name="frmDeliveryNoteObj"></param>       
        //TODO OpenMiracle Function
        //public void CallFromDeliveryNote(frmDeliveryNote frmDeliveryNoteObj)
        //{
        //    try
        //    {
        //        dgvAccountLedger.Enabled = false;
        //        this.frmDeliveryNoteObj = frmDeliveryNoteObj;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL34:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmPurchaseInvoice for creating new account ledger
        /// </summary>
        /// <param name="frmPurchaseInvoiceObj"></param>    
        //TODO OpenMiracle Function
        //public void CallFromPurchaseInvoice(frmPurchaseInvoice frmPurchaseInvoiceObj)
        //{
        //    try
        //    {
        //        dgvAccountLedger.Enabled = false;
        //        this.frmPurchaseInvoiceObj = frmPurchaseInvoiceObj;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL35:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmPurchaseReturn for creating new account ledger
        /// </summary>
        /// <param name="frmPurchaseReturnObj"></param>     
        ///TODO OpenMiracle Function
        public void CallFromPurchaseReturn(frmPurchaseReturn frmPurchaseReturnObj, bool isFromCashOrParty, bool isFromPurchaseAccount)
        {
            try
            {
                isFromPurchaseReturnCashOrPartyCombo = isFromCashOrParty;
                isFromPurchaseReturnPurchaseAccountCombo = isFromPurchaseAccount;
                dgvAccountLedger.Enabled = false;
                this.frmPurchaseReturnObj = frmPurchaseReturnObj;
                base.Show();
                dgvAccountLedger.Enabled = false;
                txtLedgerNameSearch.Enabled = false;
                cmbGroupSearch.Enabled = false;
                btnSearch.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show("AL36:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmSalesQuotation for creating new account ledger
        /// </summary>
        /// <param name="frmsalesquotation"></param>  
        //TODO OpenMiracle Function
        //public void CallFromSalesQuotation(frmSalesQuotation frmsalesquotation)
        //{
        //    try
        //    {
        //        dgvAccountLedger.Enabled = false;
        //        this.frmSalesQuotationObj = frmsalesquotation;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL37:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmPdcPayable for creating new account ledger
        /// </summary>
        /// <param name="frmPDC"></param>  
        //TODO OpenMiracle Function
        //public void CallThisFormFromPDCPayable(frmPdcPayable frmPDC)
        //{
        //    try
        //    {
        //        dgvAccountLedger.Enabled = false;
        //        this.frmPdcpayableObj = frmPDC;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL38:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmSalesOrder for creating new account ledger
        /// </summary>
        /// <param name="frmSalesOrderObj"></param>      
        //TODO OpenMiracle Function
        //public void CallFromSalesOrder(frmSalesOrder frmSalesOrderObj)
        //{
        //    try
        //    {
        //        this.frmSalesOrderObj = frmSalesOrderObj;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL39:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        ///  Function to call this form from frmPdcPayable for creating new account ledger(Bank Account)
        /// </summary>
        /// <param name="frmPDC1"></param>
        //TODO OpenMiracle Function
        //public void CallThisFormFromPDCPayable2(frmPdcPayable frmPDC1)
        //{
        //    try
        //    {
        //        dgvAccountLedger.Enabled = false;
        //        this.frmPdcpayableObj2 = frmPDC1;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL40:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmPOS for creating new account ledger
        /// </summary>
        /// <param name="frmPOS"></param>
        /// <param name="isFromCorParty"></param>
        /// <param name="isFromSA"></param>
        /// //TODO OpenMiracle Function
        //public void callFromPOS(frmPOS frmPOS, bool isFromCorParty, bool isFromSA)
        //{
        //    try
        //    {
        //        isFromSalesReturnCashOrPartyCombo = isFromCorParty;
        //        isFromSalesReturnSalesAccountCombo = isFromSA;
        //        groupBox2.Enabled = false;
        //        dgvAccountLedger.Enabled = false;
        //        this.frmPOSObj = frmPOS;
        //        base.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL41:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call from PdcReceivableVoucher for creating new account ledger
        /// </summary>
        /// <param name="frmPDCRec"></param>
        //TODO OpenMiracle Function
        //public void CallThisFormFromPDCreceivable(frmPdcReceivable frmPDCRec)
        //{
        //    try
        //    {
        //        dgvAccountLedger.Enabled = false;
        //        this.frmpdcreceivableObj = frmPDCRec;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL42:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call from PdcReceivableVoucher for creating new account ledger(Bank Account)
        /// </summary>
        /// <param name="frmPDCRece"></param>
        /// //TODO OpenMiracle Function
        //public void CallThisFormFromPDCreceivable2(frmPdcReceivable frmPDCRece)
        //{
        //    try
        //    {
        //        dgvAccountLedger.Enabled = false;
        //        this.frmpdcreceivableObj2 = frmPDCRece;
        //        base.Show();
        //        dgvAccountLedger.Enabled = false;
        //        txtLedgerNameSearch.Enabled = false;
        //        cmbGroupSearch.Enabled = false;
        //        btnSearch.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AL43:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        #endregion
        #region Events
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAccountLedger_Load(object sender, EventArgs e)
        {
            try
            {
                AccountGroupComboFill();
                PrlicingLevelComboFill();
                AccountGroupComboFillSearch();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL44:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        /// <summary>
        /// Close this form On 'Close' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //Jamshi
                //if (PublicVariables.isMessageClose)
                //{
                //    Messages.CloseMessage(this);
                //}
                //else
                //{
                //    this.Close();
                //}
                if (Messages.CloseConfirmation())
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL45:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  On 'Save' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO AuthorityCheck
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, this.Name, "Save"))
                //{
                    SaveOrEdit();
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL46:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Search' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL47:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// checking 'Account Group' for secondary details or bank details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbGroup.SelectedValue != null)
                {
                    DataTable dtbl = new DataTable();
                    AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                    isSundryDebtorOrCreditor = false;
                    isBankAccount = false;
                    dtbl = spAccountLedger.AccountLedgerForSecondaryDetails();
                    for (int ini = 0; ini < dtbl.Rows.Count; ini++)
                    {
                        strGroup = dtbl.Rows[ini].ItemArray[0].ToString();
                        if (strGroup == ((AccountGroup)(cmbGroup.SelectedValue)).accountGroupId.ToString())
                        {
                            isSundryDebtorOrCreditor = true;
                        }
                    }
                    dtbl = spAccountLedger.AccountLedgerForBankDetails();
                    for (int ini = 0; ini < dtbl.Rows.Count; ini++)
                    {
                        strBankAccount = dtbl.Rows[ini].ItemArray[0].ToString();
                        if (strBankAccount == cmbGroup.SelectedValue.ToString())
                        {
                            isBankAccount = true;
                        }
                    }
                    if (!isBankAccount)
                    {
                        gbxDetails.Visible = false;
                    }
                    else
                    {
                        gbxDetails.Visible = true;
                    }
                    if (cmbGroup.SelectedIndex > 0)
                    {
                        string strNature = spAccountLedger.CreditOrDebitChecking(Convert.ToDecimal(cmbGroup.SelectedValue.ToString()));
                        cmbOpeningBalanceCrOrDr.Text = strNature.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL48:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On double click in Datagridview to fill the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAccountLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    decAccountLedgerId = Convert.ToDecimal(dgvAccountLedger.Rows[e.RowIndex].Cells["dgvtxtLedgerId"].Value.ToString());
                    Clear();
                    FillControls();
                    btnDelete.Enabled = true;
                    btnSave.Text = "Update";
                    txtLedgerName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL49:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// on 'Clear' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL50:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Delete' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO AuthorityCheck
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, this.Name, "Delete"))
                //{
                    Delete();
                //}
                //else
                //{
                    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL51:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// To open 'Account Group form' on New Account Group button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccountGroupAdd_Click(object sender, EventArgs e)
        {
            frmAccountGroup accountGroupForm = new frmAccountGroup();
            accountGroupForm.ShowDialog();
            cmbGroup.DataSource = new AccountGroupSP().AccountGroupViewAllComboFillForAccountLedger();
            cmbGroup.ValueMember = "accountGroupId";
            cmbGroup.DisplayMember = "accountGroupName";
            
                if (cmbGroup.SelectedValue != null)
                {
                    strGroupName = cmbGroup.SelectedValue.ToString();
                }
                else
                {
                    strGroupName = string.Empty;
                }
                //frmAccountGroup frmAccountGroup = new frmAccountGroup();
                //frmAccountGroup.MdiParent = f.MdiParent; 
                //frmAccountGroup open = Application.OpenForms["frmAccountGroup"] as frmAccountGroup;
                //if (open == null)
                //{
                //    frmAccountGroup.WindowState = FormWindowState.Normal;
                //frmAccountGroup.MdiParent = f.MdiParent;
                //    frmAccountGroup.CallFromAccountLedger(this);
                //}
                //else
                //{
                //open.MdiParent =  f.MdiParent;
                //    open.CallFromAccountLedger(this);
                //    open.BringToFront();
                //    if (open.WindowState == FormWindowState.Minimized)
                //    {
                //        open.WindowState = FormWindowState.Normal;
                //    }
                //}
                this.Enabled = false;
            }


        private void frmAccountLedger_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    if (frmMonthlySalaryVoucherObj != null)
            //    {
            //        frmMonthlySalaryVoucherObj.ReturnFromAccountLedgerForm(decIdForOtherForms);
            //    }
            //    if (frmAdvancePaymentobj != null)
            //    {
            //        frmAdvancePaymentobj.Enabled = true;
            //        frmAdvancePaymentobj.ReturnFromAccountLedgerForm(decIdForOtherForms);
            //    }
            //    if (frmDailysalaryvoucherobj != null)
            //    {
            //        frmDailysalaryvoucherobj.ReturnFromAccountLedgerForm(decLedgerId);
            //    }
            //    if (frmMaterialReceptObj != null)
            //    {
            //        frmMaterialReceptObj.ReturnFromAccountLedger(decLedgerId);
            //    }
            //    if (frmRejectionOutObj != null)
            //    {
            //        frmRejectionOutObj.Enabled = true;
            //        frmRejectionOutObj.ReturnFromAccountLedgerForm(decLedgerId);
            //        frmRejectionOutObj.Activate();
            //    }
            //    if (frmRejectionInObj != null)
            //    {
            //        frmRejectionInObj.Enabled = true;
            //        frmRejectionInObj.ReturnFromAccountLedger(decLedgerId);
            //        frmRejectionInObj.Activate();
            //    }
            //    if (frmSalesReturnObj != null)
            //    {
            //        if (isFromSalesReturnCashOrPartyCombo)
            //        {
            //            frmSalesReturnObj.ReturnFromAccountLedger(decIdForOtherForms);
            //        }
            //        if (isFromSalesReturnSalesAccountCombo)
            //        {
            //            frmSalesReturnObj.ReturnFromAccountLedgerOfSalesAccount(decIdForOtherForms);
            //        }
            //    }
            //    if (frmSalesInvoiceObj != null)
            //    {
            //        if (isFromSalesReturnCashOrPartyCombo)
            //        {
            //            frmSalesInvoiceObj.ReturnFromAccountLedger(decIdForOtherForms);
            //        }
            //        if (isFromSalesReturnSalesAccountCombo)
            //        {
            //            frmSalesInvoiceObj.ReturnFromSalesAccount(decIdForOtherForms);
            //        }
            //    }
            //    if (frmPurchaseOrderObj != null)
            //    {
            //        frmPurchaseOrderObj.ReturnFromAccountLedgerForm(decIdForOtherForms);
            //    }
            //    if (frmServiceVoucherObj != null)
            //    {
            //        frmServiceVoucherObj.ReturnFromAccountLedgerForm(decIdForOtherForms);
            //    }
            //    if (frmContraVoucherObj != null)
            //    {
            //        if (isGrid)
            //        {
            //            frmContraVoucherObj.ReturnFromAccountLedgerFormForGridCombo(decIdForOtherForms);
            //        }
            //        else
            //        {
            //            frmContraVoucherObj.ReturnFromAccountLedgerForm(decIdForOtherForms);
            //        }
            //    }
            //    if (frmDeliveryNoteObj != null)
            //    {
            //        frmDeliveryNoteObj.ReturnFromAccountLedger(decIdForOtherForms);
            //    }
            if (frmPurchaseReturnObj != null)
            {
                if (isFromPurchaseReturnCashOrPartyCombo)
                {
                    frmPurchaseReturnObj.ReturnFromAccountLedger(decIdForOtherForms);
                }
                if (isFromPurchaseReturnPurchaseAccountCombo)
                {
                    frmPurchaseReturnObj.ReturnFromAccountLedgerOfPurchaseAccount(decIdForOtherForms);
                }
            }
            //    if (frmSalesOrderObj != null)
            //    {
            //        frmSalesOrderObj.ReturnFromAccountLedgerForm(decIdForOtherForms);
            //    }
            //    if (frmPurchaseInvoiceObj != null)
            //    {
            //        frmPurchaseInvoiceObj.ReturnFromAccountLedgerForm(decIdForOtherForms);
            //    }
            //    if (frmSalesQuotationObj != null)
            //    {
            //        frmSalesQuotationObj.ReturnFromAccountLedger(decIdForOtherForms);
            //    }
            //    /*----------- for PDCpayable voucher---------------------*/
            //    if (frmPdcpayableObj != null)
            //    {
            //        frmPdcpayableObj.ReturnFromAccountLedger(decIdForOtherForms);
            //        frmPdcpayableObj.Enabled = true;
            //    }
            //    if (frmPdcpayableObj2 != null)
            //    {
            //        frmPdcpayableObj2.ReturnFromAccountLedger2(decIdForOtherForms);
            //        frmPdcpayableObj2.Enabled = true;
            //    }
            //    /*----------- for PDCReceivable voucher---------------------*/
            //    if (frmpdcreceivableObj != null)
            //    {
            //        frmpdcreceivableObj.ReturnFromAccountLedger(decIdForOtherForms);
            //        frmpdcreceivableObj.Enabled = true;
            //    }
            //    if (frmpdcreceivableObj2 != null)
            //    {
            //        frmpdcreceivableObj2.ReturnFromAccountLedger2(decIdForOtherForms);
            //        frmpdcreceivableObj2.Enabled = true;
            //    }
            //    if (frmPaymentVoucherObj != null)
            //    {
            //        frmPaymentVoucherObj.ReturnFromAccountLedgerForm(decIdForOtherForms, strComboTypes);
            //    }
            //    if (frmPOSObj != null)
            //    {
            //        if (isFromSalesReturnCashOrPartyCombo)
            //        {
            //            frmPOSObj.ReturnFromAccountLedgerForm(decIdForOtherForms);
            //        }
            //        if (isFromSalesReturnSalesAccountCombo)
            //        {
            //            frmPOSObj.ReturnFromSalesAccount(decIdForOtherForms);
            //        }
            //    }
            //    if (frmReceiptVoucherObj != null)
            //    {
            //        frmReceiptVoucherObj.ReturnFromAccountLedgerForm(decIdForOtherForms, strComboTypes);
            //    }
            //    if (frmJournalVoucherObj != null)
            //    {
            //        frmJournalVoucherObj.CallFromAccountLedger(decLedgerId);
            //    }
            //    if (frmDebitNoteObj != null)
            //    {
            //        frmDebitNoteObj.CallFromAccountLedger(decLedgerId);
            //    }
            //    if (frmCreditNoteObj != null)
            //    {
            //        frmCreditNoteObj.CallFromAccountLedger(decLedgerId);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("AL53:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }


        private void txtCreditPeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Convert.ToInt32(txtCreditPeriod.Text);
                }
                catch
                {
                    txtCreditPeriod.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL54:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtCreditLimit_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Convert.ToDecimal(txtCreditLimit.Text);
                }
                catch
                {
                    txtCreditLimit.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL55:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void tbctrlLedger_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (tbctrlLedger.SelectedTab == tbSecondaryDetails)
                {
                    if (!isSundryDebtorOrCreditor)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        txtMailingName.Focus();
                        txtMailingName.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL56:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Decimal validation for 'Credit Period' textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreditPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Common.DecimalValidation(sender, e, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL57:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 'CreditLimit' textbox key enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreditLimit_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtCreditLimit.Text) == 0)
                {
                    txtCreditLimit.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL58:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  'CreditPeriod' textbox key enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreditPeriod_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtCreditPeriod.Text) == 0)
                {
                    txtCreditPeriod.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL59:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// account ledger datagridview clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAccountLedger_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvAccountLedger.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL60:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 'OpeningBalance' textbox key enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOpeningBalance_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtOpeningBalance.Text != String.Empty && Convert.ToDecimal(txtOpeningBalance.Text) == 0)
                {
                    txtOpeningBalance.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL61:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 'OpeningBalance' textbox key leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOpeningBalance_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Convert.ToDecimal(txtOpeningBalance.Text);
                }
                catch
                {
                    txtOpeningBalance.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL62:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Checking decimal validation on key press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Common.DecimalValidation(sender, e, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL63:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 'LedgerName' textbox key leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLedgerName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMailingName.Text == string.Empty)
                    txtMailingName.Text = txtLedgerName.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL64:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Narration textbox key enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                inNarrationCount = 0;
                txtNarration.Text = txtNarration.Text.Trim();
                if (txtNarration.Text == string.Empty)
                {
                    txtNarration.SelectionStart = 0;
                    txtNarration.Focus();
                }
                else
                {
                    txtNarration.SelectionStart = txtNarration.Text.Length;
                    txtNarration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL65:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Address textbox key enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddress_Enter(object sender, EventArgs e)
        {
            try
            {
                inNarrationCount = 0;
                txtNarration.Text = txtNarration.Text.Trim();
                if (txtAddress.Text == string.Empty)
                {
                    txtAddress.SelectionStart = 0;
                    txtAddress.Focus();
                }
                else
                {
                    txtAddress.SelectionStart = txtNarration.Text.Length;
                    txtAddress.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL66:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// decimal validation in CreditLimit textbox keypress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Common.DecimalValidation(sender, e, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL67:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Mobile textbox key press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 43)
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL68:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Phone textbox key press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 43)
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL69:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// filling Route combo while selecting from area combo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RouteComboFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL70:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Navigation
        /// <summary>
        /// form keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAccountLedger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
                {
                    btnSave.Focus();
                    btnSave_Click(sender, e);
                }
                if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control) //Delete
                {
                    if (btnDelete.Enabled)
                    {
                        btnDelete_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL71:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key  navigation in'ledgername' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGroup.Focus();
                    cmbGroup.SelectionLength = 0;
                    cmbGroup.SelectionStart = 0;
                    if (cmbGroup.Enabled == false)
                    {
                        txtOpeningBalance.Focus();
                        txtOpeningBalance.SelectionLength = 0;
                        txtOpeningBalance.SelectionStart = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL72:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation in'Group' combo keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOpeningBalance.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbGroup.Text == string.Empty || cmbGroup.SelectionStart == 0)
                    {
                        txtLedgerName.Focus();
                        txtLedgerName.SelectionStart = 0;
                        txtLedgerName.SelectionLength = 0;
                    }
                }
                if (e.KeyCode == Keys.C && Control.ModifierKeys == Keys.Alt)
                {
                    SendKeys.Send("{F10}");
                    btnAccountGroupAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL73:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation in'OpeningBalance' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOpeningBalance_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOpeningBalanceCrOrDr.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtOpeningBalance.Text == string.Empty || txtOpeningBalance.SelectionStart == 0)
                    {
                        cmbGroup.Focus();
                        cmbGroup.SelectionStart = 0;
                        cmbGroup.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL74:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'narration' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                    inNarrationCount++;
                    if (inNarrationCount == 2)
                    {
                        inNarrationCount = 0;
                        if (isBankAccount)
                        {
                            txtAcNo.Focus();
                        }
                        else if (isSundryDebtorOrCreditor)
                        {
                            tbctrlLedger.SelectedTab = tbSecondaryDetails;
                            txtMailingName.Focus();
                        }
                        else
                        {
                            btnSave.Focus();
                        }
                    }
                }
                else
                {
                    inNarrationCount = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        cmbOpeningBalanceCrOrDr.Focus();
                        cmbOpeningBalanceCrOrDr.SelectionLength = 0;
                        cmbOpeningBalanceCrOrDr.SelectionStart = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL75:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'A/c No' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAcNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBranchName.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtAcNo.Text == string.Empty || txtAcNo.SelectionStart == 0)
                    {
                        txtNarration.Focus();
                        txtNarration.SelectionStart = 0;
                        txtNarration.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL76:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'BranchName' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBranchCode.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtBranchName.Text == string.Empty || txtBranchName.SelectionStart == 0)
                    {
                        txtAcNo.Focus();
                        txtAcNo.SelectionStart = 0;
                        txtAcNo.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL77:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'BranchCode ' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBranchCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (isSundryDebtorOrCreditor)
                    {
                        txtMailingName.Focus();
                        tbctrlLedger.SelectedTab = tbSecondaryDetails;
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtBranchCode.Text == string.Empty || txtBranchCode.SelectionStart == 0)
                    {
                        txtBranchName.Focus();
                        txtBranchName.SelectionStart = 0;
                        txtBranchName.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL78:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation in 'mailing' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMailingName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAccountNo.Focus();
                    txtAccountNo.SelectionStart = 0;
                    txtAccountNo.SelectionLength = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtMailingName.Text == string.Empty || txtMailingName.SelectionStart == 0)
                    {
                        if (isSundryDebtorOrCreditor)
                        {
                            tbctrlLedger.SelectedTab = tbMainDetails;
                            btnSave.Focus();
                            txtBranchCode.SelectionStart = 0;
                            txtBranchCode.SelectionLength = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL79:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation in'address ' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    inNarrationCount++;
                    if (inNarrationCount == 2)
                    {
                        inNarrationCount = 0;
                        txtPhone.Focus();
                        txtPhone.SelectionStart = 0;
                        txtPhone.SelectionLength = 0;
                    }
                }
                else
                {
                    inNarrationCount = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtAddress.Text == string.Empty || txtAddress.SelectionStart == 0)
                    {
                        txtAccountNo.Focus();
                        txtAccountNo.SelectionStart = 0;
                        txtAccountNo.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL80:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'Mobile' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBillByBill.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtMobile.Text == string.Empty || txtMobile.SelectionStart == 0)
                    {
                        txtEmail.Focus();
                        txtEmail.SelectionStart = 0;
                        txtEmail.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL81:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation in'PricingLevel' combo keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPricingLevel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCreditPeriod.Focus();
                    txtCreditPeriod.SelectionLength = 0;
                    txtCreditPeriod.SelectionStart = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbPricingLevel.Text == string.Empty || cmbPricingLevel.SelectionStart == 0)
                    {
                        cmbBillByBill.Focus();
                        cmbBillByBill.SelectionStart = 0;
                        cmbBillByBill.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL82:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'CreditLimit' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreditLimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCst.Focus();
                    txtCst.SelectionLength = 0;
                    txtCst.SelectionStart = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtCreditLimit.Text == string.Empty || txtCreditLimit.SelectionStart == 0)
                    {
                        txtCreditPeriod.Focus();
                        txtCreditPeriod.SelectionStart = 0;
                        txtCreditPeriod.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL83:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation in'tin' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbArea.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtTin.Text == string.Empty || txtTin.SelectionStart == 0)
                    {
                        txtCst.Focus();
                        txtCst.SelectionStart = 0;
                        txtCst.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL84:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'Pan' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRoute.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtPan.Text == string.Empty || txtPan.SelectionStart == 0)
                    {
                        cmbArea.Focus();
                        cmbArea.SelectionStart = 0;
                        cmbArea.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL85:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'Account No' textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddress.Focus();
                    txtAddress.SelectionLength = 0;
                    txtAddress.SelectionStart = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtAccountNo.Text == string.Empty || txtAccountNo.SelectionStart == 0)
                    {
                        txtMailingName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL86:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'Dr/Cr' combo keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOpeningBalanceCrOrDr_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNarration.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbOpeningBalanceCrOrDr.Text == string.Empty || cmbOpeningBalanceCrOrDr.SelectionStart == 0)
                    {
                        txtOpeningBalance.Focus();
                        txtOpeningBalance.SelectionStart = 0;
                        txtOpeningBalance.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL87:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in Phone textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEmail.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtPhone.Text == string.Empty || txtPhone.SelectionStart == 0)
                    {
                        txtAddress.Focus();
                        txtAddress.SelectionStart = 0;
                        txtAddress.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL88:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in Email textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    inNarrationCount = 0;
                    txtMobile.Focus();
                    txtMobile.SelectionLength = 0;
                    txtMobile.SelectionStart = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtEmail.Text == string.Empty || txtEmail.SelectionStart == 0)
                    {
                        txtPhone.Focus();
                        txtPhone.SelectionStart = 0;
                        txtPhone.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL89:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in Bill by Bill combo keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBillByBill_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPricingLevel.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbBillByBill.Text == string.Empty || cmbBillByBill.SelectionStart == 0)
                    {
                        txtMobile.Focus();
                        txtMobile.SelectionStart = 0;
                        txtMobile.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL90:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in CreditPeriod textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreditPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCreditLimit.Focus();
                    txtCreditLimit.SelectionLength = 0;
                    txtCreditLimit.SelectionStart = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtCreditPeriod.Text == string.Empty || txtCreditPeriod.SelectionStart == 0)
                    {
                        cmbPricingLevel.Focus();
                        cmbPricingLevel.SelectionStart = 0;
                        cmbPricingLevel.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL91:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in Cst textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCst_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTin.Focus();
                    txtTin.SelectionStart = 0;
                    txtTin.SelectionLength = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtCst.Text == string.Empty || txtCst.SelectionStart == 0)
                    {
                        txtCreditLimit.Focus();
                        txtCreditLimit.SelectionStart = 0;
                        txtCreditLimit.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL92:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in Area combo keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPan.Focus();
                    txtPan.SelectionLength = 0;
                    txtPan.SelectionStart = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtTin.Focus();
                    txtTin.SelectionLength = 0;
                    txtTin.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL93:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in Route combo keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRoute_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbRoute.Text == string.Empty || cmbRoute.SelectionStart == 0)
                    {
                        txtPan.Focus();
                        txtPan.SelectionStart = 0;
                        txtPan.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL94:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key  navigation in LedgerName textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLedgerNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGroupSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL95:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in 'Group' combo keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGroupSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbGroupSearch.Text == string.Empty || cmbGroupSearch.SelectionStart == 0)
                    {
                        txtLedgerNameSearch.Focus();
                        txtLedgerNameSearch.SelectionStart = 0;
                        txtLedgerNameSearch.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL96:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Enter key and backspace navigation in Account ledger datagridview key up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAccountLedger_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter /*|| e.KeyCode == Keys.Tab*/)
                {
                    if (dgvAccountLedger.CurrentRow != null)
                    {
                        DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(dgvAccountLedger.CurrentCell.ColumnIndex, dgvAccountLedger.CurrentCell.RowIndex);
                        dgvAccountLedger_CellDoubleClick(sender, ex);
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    cmbGroupSearch.Focus();
                    cmbGroupSearch.SelectionLength = 0;
                    cmbGroupSearch.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL97:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///backspace navigation in 'Save' button keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (isBankAccount)
                    {
                        txtBranchCode.Focus();
                        txtBranchCode.SelectionLength = 0;
                        txtBranchCode.SelectionStart = 0;
                    }
                    else
                    {
                        txtNarration.Focus();
                        txtNarration.SelectionLength = 0;
                        txtNarration.SelectionStart = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL98:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// backspace navigation in 'Search' button keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    cmbGroupSearch.Focus();
                    cmbGroupSearch.SelectionLength = 0;
                    cmbGroupSearch.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AL99:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        
    }
}
