
using System;
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
using LoginForm.Account;

namespace LoginForm
{
    public partial class frmPaymentVoucher : Form
    {

        #region Public variables

        IMEEntities IME = new IMEEntities();
        frmAccountLedger frmAccountLedgerObj = new frmAccountLedger();//to use in call from account ledger function
        frmPaymentRegister frmPaymentRegisterObj = null;//to use in call from payment register function
        DataTable dtblPartyBalance = new DataTable();//to store party balance entries while clicking btn_Save in payment voucher
        string strVoucherNo = string.Empty;//to save voucher no into tbl_payment master
        string strInvoiceNo = string.Empty;//to save invoice no into tbl_payment master 
        string tableName = "PaymentMaster";//to get the table name in voucher type selection
        string strCashOrBank;//to get the selected value in cmbBankOrCash at teh time of ledger popup
        string strPrefix = string.Empty;//to get the prefix string from frmvouchertypeselection
        string strSuffix = string.Empty;//to get the suffix string from frmvouchertypeselection
        decimal decPaymentVoucherTypeId = 0;//to get the selected voucher type id from frmVoucherTypeSelection
        decimal decDailySuffixPrefixId = 0;//to store the selected voucher type's suffixpreffixid from frmVoucherTypeSelection
        decimal decSelectedCurrencyRate = 0;//to store the selected currency rate
        decimal decAmount = 0;//to find the total amount 
        decimal decConvertRate = 0;//to find the amont after converted into converted rate by multiplying with exchange rate
        decimal decPaymentmasterId = 0;//to get the payment master id from payment register
        public string strVocherNo;
        bool isAutomatic = false;//to check whether the voucher number is automatically generated or not
        bool isUpdated = false;//to check wheteher the using mode is save or update
        bool isValueChanged = false;//to check column missing
        int inArrOfRemoveIndex = 0;//number of rows removed by clicking remove button
        int inNarrationCount = 0;
        ArrayList arrlstOfDeletedPartyBalanceRow;
        ArrayList arrlstOfRemovedLedgerPostingId = new ArrayList();
        ArrayList arrlstOfRemove = new ArrayList();
        frmVoucherSearch _frmVoucherSearch = null;
        int inUpdatingRowIndexForPartyRemove = -1;
        decimal decUpdatingLedgerForPartyremove = 0;
        #endregion

        #region Function

        public frmPaymentVoucher()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void PrintCheck()
        {
            try
            {
                if (IME.Settings.Where(a => a.settingsName == "TickPrintAfterSave").FirstOrDefault().status == "Yes")
                {
                    cbxPrintafterSave.Checked = true;
                }
                else
                {
                    cbxPrintafterSave.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void SerialNumberGeneration()
        {
            try
            {
                int inRowSlNo = 1;
                foreach (DataGridViewRow dr in dgvPaymentVoucher.Rows)
                {
                    dr.Cells["dgvtxtSlNo"].Value = inRowSlNo;
                    inRowSlNo++;
                    if (dr.Index == dgvPaymentVoucher.Rows.Count - 2)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV3:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //public void CallFromCurrenCyDetails(frmCurrencyDetails frmCurrencyDetails, decimal decId) //PopUp
        //{
        //    try
        //    {
        //        base.Show();
        //        this.frmCurrencyObj = frmCurrencyDetails;
        //        GridCurrencyComboFill();
        //        dgvPaymentVoucher.CurrentRow.Cells["dgvcmbCurrency"].Value = decId;
        //        frmCurrencyObj.Close();
        //        frmCurrencyObj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PV4:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}


        public void GridCurrencyComboFill()
        {
            try
            {
                DateTime dt = Convert.ToDateTime(txtDate.Text);
                var adapter = (from a in IME.Currencies
                               from b in IME.ExchangeRates.Where(x=>x.currencyId == a.currencyID)
                               where b.date == dt
                               where b.exchangeRateID==1
                               select new
                               {
                                   currencyName=a.currencyName + "|" +a.currencySymbol,
                                   b.exchangeRateID
                               }).ToList();
                dgvcmbCurrency.DataSource = adapter;
                dgvcmbCurrency.DisplayMember = "currencyName";
                dgvcmbCurrency.ValueMember = "exchangeRateId";             
                if (IME.Settings.Where(a => a.settingsName == "MultiCurrency").FirstOrDefault().status == "Yes")
                {
                    dgvcmbCurrency.ReadOnly = false;
                }
                else
                {
                    dgvcmbCurrency.ReadOnly = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //public void CallFromLedgerPopup(frmLedgerPopup frmLedgerPopup, decimal decId, string str)
        //{
        //    try
        //    {
        //        this.Enabled = true;
        //        if (str == "CashOrBank")
        //        {
        //            TransactionsGeneralFill obj = new TransactionsGeneralFill();
        //            obj.CashOrBankComboFill(cmbBankorCash, false);
        //            cmbBankorCash.SelectedValue = decId;
        //            cmbBankorCash.Focus();
        //        }
        //        else
        //        {
        //            dgvPaymentVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value = decId;
        //            dgvPaymentVoucher.Focus();
        //        }
        //        frmLedgerPopupObj.Close();
        //        frmLedgerPopupObj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PV6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //public void CallThisFormFromVoucherSearch(frmVoucherSearch frm, decimal decId)
        //{
        //    try
        //    {
        //        this._frmVoucherSearch = frm;
        //        decPaymentmasterId = decId;
        //        btnClear.Text = "New";
        //        btnSave.Text = "Update";
        //        btnDelete.Enabled = true;
        //        FillFunction();
        //        this.Activate();
        //        this.BringToFront();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PV7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
       
        //public void CallFromPartyBalance(frmPartyBalance frmPartyBalance, decimal decId, DataTable dtbl, ArrayList arrlstOfRemovedRow)
        //{
        //    try
        //    {
        //        this.frmPartyBalanceObj = frmPartyBalance;
        //        dgvPaymentVoucher.CurrentRow.Cells["dgvtxtAmount"].Value = decId.ToString();
        //        frmPartyBalanceObj.Close();
        //        frmPartyBalanceObj = null;
        //        dtblPartyBalance = dtbl;
        //        arrlstOfDeletedPartyBalanceRow = arrlstOfRemovedRow;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PV8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
       
        public void Clear()
        {
            try
            {
                //TransactionsGeneralFill obj = new TransactionsGeneralFill();
                if (btnSave.Text == "Update")
                {
                    if (frmPaymentRegisterObj != null)
                    {
                        frmPaymentRegisterObj.Close();
                    }
                }
                if (isAutomatic)
                {

                    //SalaryVoucherMasterSP spMaster = new SalaryVoucherMasterSP();
                    //PaymentMasterSP SpPaymentMaster = new PaymentMasterSP();
                    if (strVoucherNo == string.Empty)
                    {
                        strVoucherNo = "0";
                    }
                    strVoucherNo = VoucherNumberGeneration(decPaymentVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpDate.Value, tableName);
                    decimal decJournalVoucherTypeIdmax = 0;
                    if (IME.PaymentMasters.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).Select(b => b.voucherNo).ToList().Count() != 0) decJournalVoucherTypeIdmax = IME.JournalMasters.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).Select(b => b.voucherNo).ToList().Select(decimal.Parse).ToList().Max();

                    if (Convert.ToDecimal(strVoucherNo) != decJournalVoucherTypeIdmax + 1)
                    {
                        strVoucherNo = decJournalVoucherTypeIdmax.ToString();
                        strVoucherNo = VoucherNumberGeneration(decPaymentVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpDate.Value, tableName);
                        if (decJournalVoucherTypeIdmax == 0)
                        {
                            strVoucherNo = "0";
                            strVoucherNo = VoucherNumberGeneration(decPaymentVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpDate.Value, tableName);
                        }
                    }
                    //SuffixPrefixSP spSuffisprefix = new SuffixPrefixSP();
                    //SuffixPrefixInfo infoSuffixPrefix = new SuffixPrefixInfo();
                    SuffixPrefix SuffixPrefix = IME.SuffixPrefixes.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).
                        Where(b => b.fromDate < dtpDate.Value).Where(c => c.toDate > dtpDate.Value).FirstOrDefault();
                    strPrefix = SuffixPrefix.prefix;
                    strSuffix = SuffixPrefix.suffix;
                    strInvoiceNo = strPrefix + strVoucherNo + strSuffix;
                    txtVoucherNo.Text = strInvoiceNo;
                    txtVoucherNo.ReadOnly = true;
                }
                else
                {
                    txtVoucherNo.Text = string.Empty;
                    txtVoucherNo.ReadOnly = false;
                }
                dtpDate.MinDate = DateTime.Now.AddMonths(-8);
                dtpDate.MaxDate = DateTime.Now.AddMonths(3);
                dtpDate.Value = DateTime.Now;
                cmbBankorCash.SelectedIndex = -1;
                txtNarration.Text = string.Empty;
                txtTotal.Text = string.Empty;
                dgvPaymentVoucher.ClearSelection();
                dgvPaymentVoucher.Rows.Clear();
                btnSave.Text = "Save";
                btnDelete.Enabled = false;
                cbxPrintafterSave.Checked = false;
                dtblPartyBalance.Clear();
                if (isAutomatic)
                {
                    txtDate.Select();
                }
                else
                {
                    txtVoucherNo.Select();
                }
                PrintCheck();

            }
            catch (Exception ex)
            {
                MessageBox.Show("PV9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //public void Print(decimal decPaymentMasterId)
        //{
        //    try
        //    {
        //        PaymentMasterSP SpPaymentMaster = new PaymentMasterSP();
        //        DataSet dsPaymentVoucher = SpPaymentMaster.PaymentVoucherPrinting(decPaymentMasterId, 1);
        //        frmReport frmReport = new frmReport();
        //        frmReport.MdiParent = formMDI.MDIObj;
        //        frmReport.PaymentVoucherPrinting(dsPaymentVoucher);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PV10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        // TO DO PrintForDotMatrix
        //public void PrintForDotMatrix(decimal decPaymentMasterId)
        //{
        //    try
        //    {

        //        DataTable dtblOtherDetails = new DataTable();
        //        CompanySP spComapany = new CompanySP();
        //        dtblOtherDetails = spComapany.CompanyViewForDotMatrix();
        //        DataTable dtblGridDetails = new DataTable();
        //        dtblGridDetails.Columns.Add("SlNo");
        //        dtblGridDetails.Columns.Add("Account Ledger");
        //        dtblGridDetails.Columns.Add("Amount");
        //        dtblGridDetails.Columns.Add("Currency");
        //        dtblGridDetails.Columns.Add("Cheque No");
        //        dtblGridDetails.Columns.Add("Cheque Date");
        //        int inRowCount = 0;
        //        foreach (DataGridViewRow dRow in dgvPaymentVoucher.Rows)
        //        {
        //            if (dRow.HeaderCell.Value != null && dRow.HeaderCell.Value.ToString() != "X")
        //            {
        //                if (!dRow.IsNewRow)
        //                {
        //                    DataRow dr = dtblGridDetails.NewRow();
        //                    dr["SlNo"] = ++inRowCount;
        //                    dr["Account Ledger"] = dRow.Cells["dgvcmbAccountLedger"].FormattedValue.ToString();
        //                    dr["Amount"] = dRow.Cells["dgvtxtAmount"].Value.ToString();
        //                    dr["Currency"] = dRow.Cells["dgvcmbCurrency"].FormattedValue.ToString();
        //                    dr["Cheque No"] = (dRow.Cells["dgvtxtChequeNo"].Value == null ? "" : dRow.Cells["dgvtxtChequeNo"].Value.ToString());
        //                    dr["Cheque Date"] = (dRow.Cells["dgvtxtChequeDate"].Value == null ? "" : dRow.Cells["dgvtxtChequeDate"].Value.ToString());
        //                    dtblGridDetails.Rows.Add(dr);
        //                }
        //            }
        //        }
        //        dtblOtherDetails.Columns.Add("voucherNo");
        //        dtblOtherDetails.Columns.Add("date");
        //        dtblOtherDetails.Columns.Add("totalAmount");
        //        dtblOtherDetails.Columns.Add("ledgerName");
        //        dtblOtherDetails.Columns.Add("Narration");
        //        dtblOtherDetails.Columns.Add("AmountInWords");
        //        dtblOtherDetails.Columns.Add("Declaration");
        //        dtblOtherDetails.Columns.Add("Heading1");
        //        dtblOtherDetails.Columns.Add("Heading2");
        //        dtblOtherDetails.Columns.Add("Heading3");
        //        dtblOtherDetails.Columns.Add("Heading4");
        //        DataRow dRowOther = dtblOtherDetails.Rows[0];
        //        dRowOther["voucherNo"] = txtVoucherNo.Text;
        //        dRowOther["date"] = txtDate.Text;
        //        dRowOther["totalAmount"] = txtTotal.Text;
        //        dRowOther["ledgerName"] = cmbBankorCash.Text;
        //        dRowOther["Narration"] = txtNarration.Text;
        //        dRowOther["AmountInWords"] = new NumToText().AmountWords(Convert.ToDecimal(txtTotal.Text), PublicVariables._decCurrencyId);
        //        dRowOther["address"] = (dtblOtherDetails.Rows[0]["address"].ToString().Replace("\n", ", ")).Replace("\r", "");
        //        VoucherTypeSP spVoucherType = new VoucherTypeSP();
        //        DataTable dtblDeclaration = spVoucherType.DeclarationAndHeadingGetByVoucherTypeId(decPaymentVoucherTypeId);
        //        dRowOther["Declaration"] = dtblDeclaration.Rows[0]["Declaration"].ToString();
        //        dRowOther["Heading1"] = dtblDeclaration.Rows[0]["Heading1"].ToString();
        //        dRowOther["Heading2"] = dtblDeclaration.Rows[0]["Heading2"].ToString();
        //        dRowOther["Heading3"] = dtblDeclaration.Rows[0]["Heading3"].ToString();
        //        dRowOther["Heading4"] = dtblDeclaration.Rows[0]["Heading4"].ToString();
        //        int inFormId = spVoucherType.FormIdGetForPrinterSettings(Convert.ToInt32(dtblDeclaration.Rows[0]["masterId"].ToString()));
        //        PrintWorks.DotMatrixPrint.PrintDesign(inFormId, dtblOtherDetails, dtblGridDetails, dtblOtherDetails);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PV:11" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}


        public void DeletePartyBalanceOfRemovedRow()
        {

                foreach (object obj in arrlstOfDeletedPartyBalanceRow)
                {
                    decimal str = Convert.ToDecimal(obj);
                    IME.PartyBalances.Remove(IME.PartyBalances.Where(a => a.partyBalanceId == str).FirstOrDefault());
                }
        }


        public string VoucherNumberGeneration(decimal JournalVoucherTypeId, decimal Box, DateTime VoucherDate, string tableName1)
        {
            if (IME.SuffixPrefixes.Where(a => a.voucherTypeId == (decimal)JournalVoucherTypeId).Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).ToList().Count == 0)
            {
                if (Box == 0)
                {
                    if (IME.PaymentMasters.Where(a => a.voucherTypeId == JournalVoucherTypeId).FirstOrDefault() != null)
                    {
                        Box = decimal.Parse(IME.PaymentMasters.Where(a => a.voucherTypeId == JournalVoucherTypeId).FirstOrDefault().voucherNo);
                    }
                    else
                    {
                        Box = 1;
                    }
                }
                else
                {
                    Box = Box + 1;
                }
                return Box.ToString();
            }
            else
            {
                if (IME.SuffixPrefixes.Where(a => a.voucherTypeId == JournalVoucherTypeId).Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).FirstOrDefault().prefillWithZero == true)
                {
                    int length = IME.SuffixPrefixes.Where(a => a.voucherTypeId == JournalVoucherTypeId).
                        Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).Count();
                    string startindex = IME.SuffixPrefixes.Where(a => a.voucherTypeId == JournalVoucherTypeId).
                        Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).FirstOrDefault().startIndex.ToString();
                    int widthOfNumericalPart = (int)IME.SuffixPrefixes.Where(a => a.voucherTypeId == JournalVoucherTypeId).
                        Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).FirstOrDefault().widthOfNumericalPart;

                    while (length < widthOfNumericalPart)
                    {
                        startindex = "0" + startindex;
                        length++;
                    }
                    if (Box == 0)
                    {
                        return startindex;
                    }
                    else
                    {
                        startindex = (Box + 1).ToString();
                        length = 1;
                        while (length < widthOfNumericalPart)
                        {
                            startindex = "0" + startindex;
                            length++;
                        }
                        return startindex;
                    }
                }
                else
                {
                    if (Box == 0)
                    {
                        if (IME.SuffixPrefixes.Where(a => a.voucherTypeId == JournalVoucherTypeId)
                            .Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).FirstOrDefault() != null)
                        {
                            Box = (decimal)IME.SuffixPrefixes.Where(a => a.voucherTypeId == JournalVoucherTypeId)
                            .Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).FirstOrDefault().startIndex;
                        }
                        else
                        {
                            Box = 0;
                        }
                    }
                    else
                    {
                        Box = Box + 1;
                    }
                }
            }
            return "";
        }


        public void CallFromVoucherTypeSelection(decimal decPaymentVoucherTypeId1, string strVoucherTypeNames1)
        {
                decPaymentVoucherTypeId = decPaymentVoucherTypeId1;
                isAutomatic = IME.VoucherTypes.Where(a=>a.voucherTypeId== decPaymentVoucherTypeId).FirstOrDefault().methodOfVoucherNumbering == "Automatic" ?true:false;
            SuffixPrefix SuffixPrefix = IME.SuffixPrefixes.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).
                    Where(b => b.fromDate < dtpDate.Value).Where(c => c.toDate > dtpDate.Value).FirstOrDefault();
            strPrefix = SuffixPrefix.prefix;
            strSuffix = SuffixPrefix.suffix;
            decDailySuffixPrefixId = SuffixPrefix.suffixprefixId;
                base.Show();
                Clear();
           
        }


        public void SaveOrEdit()
        {
                int inIfGridColumnMissing = 0;
                int inRowCount = dgvPaymentVoucher.RowCount;
                ArrayList arrLst = new ArrayList();
                string output = string.Empty;
                if (txtVoucherNo.Text == string.Empty)
                {
                    Messages.InformationMessage("Enter voucher number.");
                    txtVoucherNo.Focus();
                    inIfGridColumnMissing = 1;
                }
                else if (cmbBankorCash.SelectedIndex == -1)
                {
                    Messages.InformationMessage("Select any bank or cash");
                    cmbBankorCash.Focus();
                    inIfGridColumnMissing = 1;
                }
                else if (inRowCount == 1)
                {
                    Messages.InformationMessage("Can't save without atleast one complete details");
                    dgvPaymentVoucher.Focus();
                    inIfGridColumnMissing = 1;
                }
                else if (Convert.ToDecimal(txtTotal.Text) == 0)
                {
                    Messages.InformationMessage("Can't save the total amount as Zero");
                    dgvPaymentVoucher.Focus();
                }
                else
                {
                    int inJ = 0;
                    for (int inI = 0; inI < inRowCount - 1; inI++)
                    {

                        if (dgvPaymentVoucher.Rows[inI].HeaderCell.Value.ToString() == "X")
                        {
                            arrLst.Add(Convert.ToString(inI + 1));
                            inIfGridColumnMissing = 1;
                            inJ++;
                        }
                    }
                    if (inJ != 0)
                    {
                        if (inJ == inRowCount - 1)
                        {
                            Messages.InformationMessage("Can't save without atleat one complete details");
                            inIfGridColumnMissing = 1;
                        }
                        else
                        {
                            foreach (object obj in arrLst)
                            {
                                string str = Convert.ToString(obj);
                                if (str != null)
                                {
                                    output += str + ",";
                                }
                                else
                                {
                                    break;
                                }
                            }
                            bool isOk = Messages.UpdateMessageCustom("Row No " + output + " not completed.Do you want to continue?");
                            if (isOk)
                            {
                                inIfGridColumnMissing = 0;
                            }
                            else
                            {
                                inIfGridColumnMissing = 1;
                            }
                        }
                    }

                    if (inIfGridColumnMissing == 0)
                    {
                        if (btnSave.Text == "Save")
                        {
                            if (!isAutomatic)
                            {
                                //if (SpPaymentMaster.PaymentVoucherCheckExistence(txtVoucherNo.Text.Trim(), 
                                //    decPaymentVoucherTypeId, 0))
                                if(IME.PaymentMasters.Where(a=>a.voucherNo== txtVoucherNo.Text.Trim()).Where(b=>b.voucherTypeId== decPaymentVoucherTypeId)
                                !=null)
                                {
                                    Messages.InformationMessage("Voucher number already exist");
                                }
                                else
                                {
                                        Save();
                                }
                            }
                            else
                            {
                                    Save();
                            }
                        }
                        else if (btnSave.Text == "Update")
                        {
                            if (!isAutomatic)
                            {
                            if (IME.PaymentMasters.Where(a => a.voucherNo == txtVoucherNo.Text.Trim()).Where(b => b.voucherTypeId == decPaymentVoucherTypeId)
                            != null)
                            {
                                Messages.InformationMessage("Voucher number already exist");
                                }
                                else
                                {
                                            Edit(decPaymentmasterId);
                                }
                            }
                            else
                            {

                                        Edit(decPaymentmasterId);
                            }

                        }
                    }

                }
        }


        public void PartyBalanceAddOrEdit(int inJ)
        {
            PartyBalance PartyBalance = new PartyBalance();
            if (dtblPartyBalance.Rows[inJ]["PartyBalanceId"].ToString() != "0")
            {
                decimal PartyBalanceId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["partyBalanceId"]);
                PartyBalance = IME.PartyBalances.Where(a => a.partyBalanceId == PartyBalanceId).FirstOrDefault();
            }

            int inTableRowCount = dtblPartyBalance.Rows.Count;
            //PartyBalanceInfo InfopartyBalance = new PartyBalanceInfo();
            //PartyBalanceSP spPartyBalance = new PartyBalanceSP();
            PartyBalance.credit = 0;
            PartyBalance.creditPeriod = 0;
            PartyBalance.date = dtpDate.Value;
            PartyBalance.debit = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["Amount"].ToString());
            PartyBalance.exchangeRateId = Convert.ToInt32(dtblPartyBalance.Rows[inJ]["CurrencyId"].ToString());
            PartyBalance.financialYearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
            PartyBalance.ledgerId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["LedgerId"].ToString());
            PartyBalance.referenceType = dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString();
            if (dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "New" || dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "OnAccount")
            {
                PartyBalance.againstInvoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
                PartyBalance.againstVoucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                PartyBalance.againstVoucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());//decPaymentVoucherTypeId;
                PartyBalance.voucherTypeId = decPaymentVoucherTypeId;
                PartyBalance.invoiceNo = strInvoiceNo;
                if (!isAutomatic)
                {
                    PartyBalance.voucherNo = txtVoucherNo.Text.Trim();
                }
                else
                {
                    PartyBalance.voucherNo = strVoucherNo;
                }
            }
            else
            {
                PartyBalance.againstInvoiceNo = strInvoiceNo;
                if (!isAutomatic)
                {
                    PartyBalance.againstVoucherNo = txtVoucherNo.Text.Trim();
                }
                else
                {
                    PartyBalance.againstVoucherNo = strVoucherNo;
                }
                PartyBalance.againstVoucherTypeId = decPaymentVoucherTypeId;
                PartyBalance.voucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());
                PartyBalance.voucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                PartyBalance.invoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
            }

            if (dtblPartyBalance.Rows[inJ]["PartyBalanceId"].ToString() != "0")
            {
                IME.SaveChanges();
            }
            else
            {
                IME.PartyBalances.Add(PartyBalance);
                IME.SaveChanges();
            }

            }


        public decimal TotalAmountCalculation()
        {
            decimal decTotal = 0;
            decimal decSelectedCurrencyRate = 0;
            //ExchangeRateSP SpExchangRate = new ExchangeRateSP();

                for (int inI = 0; inI < dgvPaymentVoucher.RowCount - 1; inI++)
                {
                    if (dgvPaymentVoucher.Rows[inI].HeaderCell.Value.ToString() != "X")
                    {
                    decimal exchangeRateID = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                    
                        decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == exchangeRateID).FirstOrDefault().rate;//Exchange rate of grid's row
                        decTotal = decTotal + (Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString()) * decSelectedCurrencyRate);
                    }
                }
            
            return decTotal;
        }


        public void Save()
        {
                int inGridRowCount = dgvPaymentVoucher.RowCount;
                int inTableRowCount = dtblPartyBalance.Rows.Count;
                int inB = 0;
                PaymentMaster PaymentMaster = new PaymentMaster();
                DateValidation objVal = new DateValidation();
                TextBox txtDate1 = new TextBox();
                PaymentMaster.date = dtpDate.Value;
                PaymentMaster.financialYearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
                PaymentMaster.invoiceNo = txtVoucherNo.Text.Trim(); ;
                PaymentMaster.ledgerId = Convert.ToDecimal(cmbBankorCash.SelectedValue.ToString());
                PaymentMaster.narration = txtNarration.Text.Trim();
                PaymentMaster.suffixPrefixId = decDailySuffixPrefixId;
                decimal decTotalAmount = TotalAmountCalculation();
                PaymentMaster.totalAmount = decTotalAmount;
                PaymentMaster.userId = Utils.getCurrentUser().WorkerID;
                PaymentMaster.voucherNo = strVoucherNo;
                PaymentMaster.voucherTypeId = decPaymentVoucherTypeId;
                IME.PaymentMasters.Add(PaymentMaster);
                IME.SaveChanges();
                decimal decPaymentMasterId = PaymentMaster.paymentMasterId;
                if (decPaymentMasterId != 0)
                {
                    MasterLedgerPosting();
                }
                for (int inI = 0; inI < inGridRowCount - 1; inI++)
                {
                    if (dgvPaymentVoucher.Rows[inI].HeaderCell.Value.ToString() != "X")
                    {
                        //PaymentMaster PaymentMaster = new PaymentMaster();
                        PaymentDetail PaymentDetail = new PaymentDetail();
                        PaymentDetail.amount = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                        PaymentDetail.exchangeRateId = Convert.ToInt32(dgvPaymentVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                        PaymentDetail.ledgerId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString());
                        PaymentDetail.paymentMasterId = decPaymentMasterId;
                        if (dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                        {
                            PaymentDetail.ledgerId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString());
                        }
                        if (dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                        {
                            PaymentDetail.chequeNo = dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString();

                            if (dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                            {
                                PaymentDetail.chequeDate = Convert.ToDateTime(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value);
                            }
                            else
                            {
                                PaymentDetail.chequeDate = DateTime.Now;
                            }
                        }
                        else
                        {
                            PaymentDetail.chequeNo = string.Empty;
                            PaymentDetail.chequeDate = DateTime.Now;
                        }
                        IME.PaymentDetails.Add(PaymentDetail);
                        IME.SaveChanges();
                        decimal decPaymentDetailsId = PaymentDetail.paymentDetailsId;
                        if (decPaymentDetailsId != 0)
                        {
                            for (int inJ = 0; inJ < inTableRowCount; inJ++)
                            {
                                if (dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() == dtblPartyBalance.Rows[inJ]["LedgerId"].ToString())
                                {
                                    PartyBalanceAddOrEdit(inJ);
                                }
                            }
                            inB++;
                            DetailsLedgerPosting(inI, decPaymentDetailsId);
                        }
                    }
                }
                MessageBox.Show("Saved successfully");
                //if (cbxPrintafterSave.Checked)
                //{
                //    if (spSettings.SettingsStatusCheck("Printer") == "Dot Matrix")
                //    {
                //        PrintForDotMatrix(decPaymentmasterId);
                //    }
                //    else
                //    {
                //        Print(decPaymentMasterId);
                //    }
                //}
                Clear();

        }

        public void Edit(decimal decMasterId)
        {
            try
            {
                int inRowCount = dgvPaymentVoucher.RowCount;
                int inTableRowCount = dtblPartyBalance.Rows.Count;
                int inB = 0;
                //PaymentMasterInfo InfoPaymentMaster = new PaymentMasterInfo();
                //PaymentMasterSP SpPaymentMaster = new PaymentMasterSP();
                //PaymentDetailsInfo InfoPaymentDetails = new PaymentDetailsInfo();
                //PaymentDetailsSP SpPaymentDetails = new PaymentDetailsSP();
                //LedgerPostingSP SpLedgerPosting = new LedgerPostingSP();
                //LedgerPostingInfo InfoLegerPosting = new LedgerPostingInfo();
                //PartyBalanceInfo InfopartyBalance = new PartyBalanceInfo();
                //PartyBalanceSP SpPartyBalance = new PartyBalanceSP();
                //BankReconciliationSP SpBankReconcilation = new BankReconciliationSP();
                PaymentMaster PaymentMaster = IME.PaymentMasters.Where(a => a.paymentMasterId == decMasterId).FirstOrDefault();
                PaymentMaster.date = dtpDate.Value;
                PaymentMaster.financialYearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
                PaymentMaster.invoiceNo = txtVoucherNo.Text.Trim();
                PaymentMaster.ledgerId = Convert.ToDecimal(cmbBankorCash.SelectedValue.ToString());
                PaymentMaster.narration = txtNarration.Text.Trim();
                PaymentMaster.suffixPrefixId = decDailySuffixPrefixId;
                decimal decTotalAmount = TotalAmountCalculation();
                PaymentMaster.totalAmount = decTotalAmount;
                PaymentMaster.userId = Utils.getCurrentUser().WorkerID;

                PaymentMaster.voucherNo = strVoucherNo;

                PaymentMaster.voucherTypeId = decPaymentVoucherTypeId;
                IME.SaveChanges();
                decimal decPaymentMasterId = PaymentMaster.paymentMasterId;
                //if (decPaymentmasterId != 0)
                //{
                //    MasterLedgerPostingEdit();
                //}
                foreach (object obj in arrlstOfRemove)
                {
                    decimal str = Convert.ToDecimal(obj);
                    IME.PaymentDetails.RemoveRange(IME.PaymentDetails.Where(a => a.paymentDetailsId == str));
                    IME.LedgerPostings.RemoveRange(IME.LedgerPostings.Where(a => a.detailsId == str).Where(b => b.voucherNo == strVoucherNo)
                        .Where(c => c.voucherTypeId == decPaymentVoucherTypeId));
                    decimal ledgerPostingId =
                        IME.LedgerPostings.Where(a => a.detailsId == str).Where(b => b.voucherNo == strVoucherNo)
                        .Where(c => c.voucherTypeId == decPaymentVoucherTypeId).FirstOrDefault().ledgerPostingId;
                    IME.BankReconciliations.RemoveRange(IME.BankReconciliations.Where(a => a.ledgerPostingId ==
                    ledgerPostingId));

                }
                IME.LedgerPostings.RemoveRange(IME.LedgerPostings.Where(a => a.AccountLedger.ledgerName== "Forex Gain/Loss").Where(b => b.voucherNo == strVoucherNo)
                        .Where(c => c.voucherTypeId == decPaymentVoucherTypeId));
                //SpLedgerPosting.LedgerPostingDeleteByVoucherNoVoucherTypeIdAndLedgerId(strVoucherNo, decPaymentVoucherTypeId, 12);
                decimal decPaymentDetailsId1 = 0;
                for (int inI = 0; inI < inRowCount - 1; inI++)
                {
                    if (dgvPaymentVoucher.Rows[inI].Cells["dgvtxtpaymentDetailsId"].FormattedValue.ToString() == "0")//if new rows are added
                    {
                        if (dgvPaymentVoucher.Rows[inI].HeaderCell.Value.ToString() != "X")//add new rows added which are completed
                        {

                            //ADD - PAyment detail add
                            PaymentDetail PaymentDetail = new PaymentDetail();
                            PaymentDetail.amount = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                            PaymentDetail.exchangeRateId = Convert.ToInt32(dgvPaymentVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                            
                            if (dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                            {
                                PaymentDetail.ledgerId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString());
                            }
                            if (dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                            {
                                PaymentDetail.chequeNo = dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString();
                                if (dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                                {
                                    PaymentDetail.chequeDate = Convert.ToDateTime(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value);
                                }
                                else
                                {
                                    PaymentDetail.chequeDate = DateTime.Now;
                                }
                            }
                            else
                            {
                                PaymentDetail.chequeNo = string.Empty;
                                PaymentDetail.chequeDate = DateTime.Now;
                            }
                            PaymentDetail.paymentMasterId = decPaymentMasterId;

                            //
                            IME.PaymentDetails.Add(PaymentDetail);
                            IME.SaveChanges();
                            decimal decPaymentDetailsId = PaymentDetail.paymentDetailsId;
                            if (decPaymentDetailsId != 0)
                            {
                                for (int inJ = 0; inJ < inTableRowCount; inJ++)
                                {
                                    if (dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() == dtblPartyBalance.Rows[inJ]["LedgerId"].ToString())
                                    {
                                        PartyBalanceAddOrEdit(inJ);
                                    }
                                }
                                inB++;
                                DetailsLedgerPosting(inI, decPaymentDetailsId);//to add new ledger posting
                            }
                        }
                    }
                    else
                    {

                        if (dgvPaymentVoucher.Rows[inI].HeaderCell.Value.ToString() != "X")//add new rows updated which are completed
                        {
                            var PaymentDetailsId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtpaymentDetailsId"].Value.ToString());
                            //edit - PAyment detail edit
                            PaymentDetail PaymentDetail = IME.PaymentDetails.Where(a => a.paymentDetailsId == PaymentDetailsId).FirstOrDefault();
                            PaymentDetail.amount = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                            PaymentDetail.exchangeRateId = Convert.ToInt32(dgvPaymentVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());

                            if (dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                            {
                                PaymentDetail.ledgerId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString());
                            }
                            if (dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                            {
                                PaymentDetail.chequeNo = dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString();
                                if (dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                                {
                                    PaymentDetail.chequeDate = Convert.ToDateTime(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value);
                                }
                                else
                                {
                                    PaymentDetail.chequeDate = DateTime.Now;
                                }
                            }
                            else
                            {
                                PaymentDetail.chequeNo = string.Empty;
                                PaymentDetail.chequeDate = DateTime.Now;
                            }
                            PaymentDetail.paymentMasterId = decPaymentMasterId;

                            //
                            IME.SaveChanges();


                            decimal decPaymentDetailsId = PaymentDetail.paymentDetailsId;//to edit rows
                            if (decPaymentDetailsId != 0)
                            {
                                for (int inJ = 0; inJ < inTableRowCount; inJ++)
                                {
                                    if (dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() == dtblPartyBalance.Rows[inJ]["LedgerId"].ToString())
                                    {
                                        PartyBalanceAddOrEdit(inJ);
                                    }
                                }
                                inB++;
                                decPaymentDetailsId1 = PaymentDetail.paymentDetailsId;
                                decimal decLedgerPostId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value.ToString());
                                DetailsLedgerPostingEdit(inI, decLedgerPostId, decPaymentDetailsId1);
                            }
                        }
                        else
                        {
                            decimal decDetailsId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inI].Cells["dgvtxtpaymentDetailsId"].Value.ToString());
                            IME.PaymentDetails.Remove(IME.PaymentDetails.Where(a => a.paymentDetailsId == decDetailsId).FirstOrDefault());


                            IME.LedgerPostings.RemoveRange(IME.LedgerPostings.Where(a => a.detailsId == decDetailsId).Where(b => b.voucherNo == strVoucherNo)
                        .Where(c => c.voucherTypeId == decPaymentVoucherTypeId));
                            decimal ledgerPostingId =
                                IME.LedgerPostings.Where(a => a.detailsId == decDetailsId).Where(b => b.voucherNo == strVoucherNo)
                                .Where(c => c.voucherTypeId == decPaymentVoucherTypeId).FirstOrDefault().ledgerPostingId;
                            IME.BankReconciliations.RemoveRange(IME.BankReconciliations.Where(a => a.ledgerPostingId ==
                            ledgerPostingId));
                            
                            for (int inJ = 0; inJ < dtblPartyBalance.Rows.Count; inJ++)
                            {
                                if (dtblPartyBalance.Rows.Count == inJ)
                                {
                                    break;
                                }
                                if (dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                                {
                                    if (dtblPartyBalance.Rows[inJ]["LedgerId"].ToString() == dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString())
                                    {
                                        if (dtblPartyBalance.Rows[inJ]["PartyBalanceId"].ToString() != "0")
                                        {
                                            arrlstOfDeletedPartyBalanceRow.Add(dtblPartyBalance.Rows[inJ]["PartyBalanceId"]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                DeletePartyBalanceOfRemovedRow();
                isUpdated = true;
                Messages.UpdatedMessage();
                //if (cbxPrintafterSave.Checked)
                //{
                //    if (spSettings.SettingsStatusCheck("Printer") == "Dot Matrix")
                //    {
                //        PrintForDotMatrix(decPaymentmasterId);
                //    }
                //    else
                //    {
                //        Print(decPaymentMasterId);
                //    }
                //}
                //if (frmPaymentRegisterObj != null)
                //{
                //    this.Close();
                //    frmPaymentRegisterObj.CallFromPaymentVoucher(this);
                //}
                //if (frmPaymentReportObj != null)
                //{
                //    this.Close();
                //    frmPaymentReportObj.CallFromPaymentVoucher(this);
                //}
                //if (frmDayBookObj != null)
                //{
                //    this.Close();
                //}
                //if (frmBillallocationObj != null)
                //{
                //    this.Close();
                //}
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Delete(decimal decMasterId)
        {
                //PaymentMasterSP SpPaymentMaster = new PaymentMasterSP();
                //PartyBalanceSP SpPartyBalance = new PartyBalanceSP();

                //if (!SpPartyBalance.PartyBalanceCheckReference(decPaymentVoucherTypeId, strVoucherNo))
                //{
                    if (IME.PartyBalances.Where(a=>a.againstVoucherTypeId== decPaymentVoucherTypeId)
                    .Where(b=>b.voucherNo== strVoucherNo) ==null)
                    {
                var PartyBalance = IME.PartyBalances.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).Where(b => b.voucherNo == strVoucherNo)
                     .Where(c => c.referenceType == "New");
                if (PartyBalance != null)
                {
                    IME.PartyBalances.RemoveRange(PartyBalance);
                }
                else
                {
                    PartyBalance = IME.PartyBalances.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).Where(b => b.voucherNo == strVoucherNo)
                     .Where(c => c.referenceType == "Against");
                    if (PartyBalance != null)
                    {
                        IME.PartyBalances.RemoveRange(PartyBalance);
                    }
                    else
                    {
                        PartyBalance = IME.PartyBalances.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).Where(b => b.voucherNo == strVoucherNo)
                    .Where(c => c.referenceType == "OnAccount");
                        if (PartyBalance != null)
                        {
                            IME.PartyBalances.RemoveRange(PartyBalance);
                        }
                    }
                }
                decimal ledgerPostingId = IME.LedgerPostings.Where(b => b.voucherTypeId == decPaymentVoucherTypeId).Where(c => c.voucherNo == strVoucherNo).FirstOrDefault().ledgerPostingId;
               IME.BankReconciliations.RemoveRange(IME.BankReconciliations.Where(a=>a.ledgerPostingId== ledgerPostingId));
                IME.LedgerPostings.RemoveRange(IME.LedgerPostings.Where(a=>a.voucherTypeId== decPaymentVoucherTypeId));
                IME.PaymentDetails.RemoveRange(IME.PaymentDetails.Where(a=>a.paymentMasterId== decPaymentmasterId));
                IME.PaymentMasters.RemoveRange(IME.PaymentMasters.Where(a => a.paymentMasterId == decPaymentmasterId));

                    MessageBox.Show("Deleted successfully ");
                    //if (frmPaymentRegisterObj != null)
                    //{
                    //    this.Close();
                    //    frmPaymentRegisterObj.CallFromPaymentVoucher(this);
                    //}
                    //else if (frmPaymentReportObj != null)
                    //{
                    //    this.Close();
                    //    frmPaymentReportObj.CallFromPaymentVoucher(this);
                    //}
                    //else if (frmLedgerDetailsObj != null)
                    //{
                    //    this.Close();
                    //}
                    //if (_frmVoucherSearch != null)
                    //{
                    //    this.Close();
                    //    _frmVoucherSearch.GridFill();
                    //}
                    //if (frmDayBookObj != null)
                    //{
                    //    this.Close();
                    //}
                    //if (frmBillallocationObj != null)
                    //{
                    //    this.Close();
                    //}

                }
                else
                {
                    Messages.InformationMessage("Reference exist. Cannot delete");
                    txtDate.Focus();
                }
           
        }


        public void TotalAmount()
        {
                decimal decTotalAmount = 0;
                decimal decSelectedCurrencyRate = 0;
                foreach (DataGridViewRow dr in dgvPaymentVoucher.Rows)
                {
                    if (dr.Cells["dgvtxtAmount"].Value != null && dr.Cells["dgvtxtAmount"].Value.ToString() != string.Empty)
                    {
                        if (dr.Cells["dgvcmbCurrency"].Value != null)
                        {
                        decimal exchangerateID = Convert.ToDecimal(dr.Cells["dgvcmbCurrency"].Value.ToString());
                        decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == exchangerateID).FirstOrDefault().rate;
                        decTotalAmount = decTotalAmount + (Convert.ToDecimal(dr.Cells["dgvtxtAmount"].Value.ToString()) * decSelectedCurrencyRate);
                        }
                        else
                        {
                            decTotalAmount = decTotalAmount + Convert.ToDecimal(dr.Cells["dgvtxtAmount"].Value.ToString());
                        }
                    }
                }
                txtTotal.Text = decTotalAmount.ToString();
        }


        public void MasterLedgerPosting()
        {
            LedgerPosting LedgerPosting = new LedgerPosting();
            LedgerPosting.credit = Convert.ToDecimal(txtTotal.Text);
            LedgerPosting.date = dtpDate.Value;
            LedgerPosting.debit = 0;
            LedgerPosting.detailsId = 0;
            LedgerPosting.invoiceNo = strInvoiceNo;
            LedgerPosting.chequeNo = string.Empty;
            LedgerPosting.chequeDate = DateTime.Now;
            LedgerPosting.ledgerId = Convert.ToDecimal(cmbBankorCash.SelectedValue.ToString());
                if (!isAutomatic)
                {
                LedgerPosting.voucherNo = txtVoucherNo.Text.Trim();
                }
                else
                {
                LedgerPosting.voucherNo = strVoucherNo;
                }
            LedgerPosting.voucherTypeId = decPaymentVoucherTypeId;
            LedgerPosting.yearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
            IME.LedgerPostings.Add(LedgerPosting);
        }

        public void MasterLedgerPostingEdit()
        {
            //LedgerPostingInfo InfoLedgerPosting = new LedgerPostingInfo();
            //LedgerPostingSP SpLedgerPosting = new LedgerPostingSP();
            //ExchangeRateSP SpExchangRate = new ExchangeRateSP();
            string voucherNo = "";
            if (!isAutomatic)
            {
                voucherNo = txtVoucherNo.Text.Trim();
            }
            else
            {
                voucherNo = strVoucherNo;
            }
            LedgerPosting LedgerPosting = IME.LedgerPostings.Where(a => a.voucherNo == voucherNo).Where(b => b.voucherTypeId == decPaymentVoucherTypeId).FirstOrDefault();
            LedgerPosting.credit = Convert.ToDecimal(txtTotal.Text);
            LedgerPosting.date = dtpDate.Value;
            LedgerPosting.debit = 0;
            LedgerPosting.detailsId = 0;
            LedgerPosting.invoiceNo = strInvoiceNo;
            LedgerPosting.chequeNo = string.Empty;
            LedgerPosting.chequeDate = DateTime.Now;
            LedgerPosting.ledgerId = Convert.ToDecimal(cmbBankorCash.SelectedValue.ToString());
            if (!isAutomatic)
            {
                LedgerPosting.voucherNo = txtVoucherNo.Text.Trim();
            }
            else
            {
                LedgerPosting.voucherNo = strVoucherNo;
            }
            LedgerPosting.voucherTypeId = decPaymentVoucherTypeId;
            LedgerPosting.yearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
            IME.SaveChanges();
        }


        public void DetailsLedgerPosting(int inA, decimal decPaymentDetailsId)
        {
            LedgerPosting LedgerPosting = new LedgerPosting();
            decimal decOldExchange = 0;
            decimal decNewExchangeRate = 0;
            decimal decNewExchangeRateId = 0;
            decimal decOldExchangeId = 0;
              
                
                if (!dgvPaymentVoucher.Rows[inA].Cells["dgvtxtAmount"].ReadOnly)
                {
                    int exchangeRateID = Convert.ToInt32(dgvPaymentVoucher.Rows[inA].Cells["dgvcmbCurrency"].Value.ToString());
                    decimal d = Convert.ToDecimal(dgvPaymentVoucher.Rows[inA].Cells["dgvcmbCurrency"].Value.ToString());
                    decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == exchangeRateID).FirstOrDefault().rate;
                    decAmount = Convert.ToDecimal(dgvPaymentVoucher.Rows[inA].Cells["dgvtxtAmount"].Value.ToString());
                    decConvertRate = decAmount * decSelectedCurrencyRate;
                    
                    LedgerPosting.credit = 0;
                    LedgerPosting.date = dtpDate.Value;
                    LedgerPosting.debit = decConvertRate;
                    LedgerPosting.detailsId = decPaymentDetailsId;
                    LedgerPosting.invoiceNo = strInvoiceNo;

                    if (dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        LedgerPosting.chequeNo = dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            LedgerPosting.chequeDate = Convert.ToDateTime(dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            LedgerPosting.chequeDate = DateTime.Now;

                    }
                    else
                    {
                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = DateTime.Now;
                    }
                    LedgerPosting.ledgerId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString());
                    if (!isAutomatic)
                    {
                        LedgerPosting.voucherNo = txtVoucherNo.Text.Trim();
                    }
                    else
                    {
                        LedgerPosting.voucherNo = strVoucherNo;
                    }
                    LedgerPosting.voucherTypeId = decPaymentVoucherTypeId;
                    LedgerPosting.yearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
                    IME.LedgerPostings.Add(LedgerPosting);
                    IME.SaveChanges();
                }
                else
                {
                    LedgerPosting.date = dtpDate.Value;
                    LedgerPosting.invoiceNo = strInvoiceNo;
                    LedgerPosting.voucherTypeId = decPaymentVoucherTypeId;
                    LedgerPosting.yearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
                    LedgerPosting.credit = 0;
                    LedgerPosting.ledgerId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString());
                    LedgerPosting.voucherNo = strVoucherNo;
                    LedgerPosting.detailsId = decPaymentDetailsId;
                    LedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();
                    if (dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        LedgerPosting.chequeNo = dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            LedgerPosting.chequeDate = Convert.ToDateTime(dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            LedgerPosting.chequeDate = DateTime.Now;
                    }
                    else
                    {
                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = DateTime.Now;
                    }

                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (LedgerPosting.ledgerId == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            decOldExchange = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                            decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                            decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decOldExchange).FirstOrDefault().rate;
                            decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                            decConvertRate = decConvertRate + (decAmount * decSelectedCurrencyRate);

                        }
                    }
                    LedgerPosting.debit = decConvertRate;
                    IME.LedgerPostings.Add(LedgerPosting);
                    IME.SaveChanges();

                    LedgerPosting.ledgerId = 12;
                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (Convert.ToDecimal(dgvPaymentVoucher.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString()) == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            if (dr["ReferenceType"].ToString() == "Against")
                            {
                                decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                                
                                decNewExchangeRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decNewExchangeRateId).FirstOrDefault().rate;
                                decOldExchangeId = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                                decOldExchange = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decOldExchangeId).FirstOrDefault().rate;
                                decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                                decimal decForexAmount = (decAmount * decNewExchangeRate) - (decAmount * decOldExchange);
                                if (decForexAmount >= 0)
                                {

                                    LedgerPosting.debit = decForexAmount;
                                    LedgerPosting.credit = 0;
                                }
                                else
                                {
                                    LedgerPosting.credit = -1 * decForexAmount;
                                    LedgerPosting.debit = 0;
                                }
                                IME.LedgerPostings.Add(LedgerPosting);
                                IME.SaveChanges();
                            }
                        }

                    }
                }
           }



        public void DetailsLedgerPostingEdit(int inA, decimal decLedgerPostingId, decimal decPaymentDetailsId)
        {
            LedgerPosting LedgerPosting = new LedgerPosting();
            decimal decOldExchange = 0;
            decimal decNewExchangeRate = 0;
            decimal decNewExchangeRateId = 0;
            decimal decOldExchangeId = 0;
                if (!dgvPaymentVoucher.Rows[inA].Cells["dgvtxtAmount"].ReadOnly)
                {
                    int exchangeRateID = Convert.ToInt32(dgvPaymentVoucher.Rows[inA].Cells["dgvcmbCurrency"].Value.ToString());
                    decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == exchangeRateID).FirstOrDefault().rate;
                    decAmount = Convert.ToDecimal(dgvPaymentVoucher.Rows[inA].Cells["dgvtxtAmount"].Value.ToString());
                    decConvertRate = decAmount * decSelectedCurrencyRate;
                    LedgerPosting.credit = 0;
                    LedgerPosting.date = dtpDate.Value;
                    LedgerPosting.debit = decConvertRate;
                    LedgerPosting.detailsId = decPaymentDetailsId;
                    LedgerPosting.invoiceNo = strInvoiceNo;
                    LedgerPosting.ledgerId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString());
                    if (!isAutomatic)
                    {
                        LedgerPosting.voucherNo = txtVoucherNo.Text.Trim();
                    }
                    else
                    {
                        LedgerPosting.voucherNo = strVoucherNo;
                    }
                    if (dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        LedgerPosting.chequeNo = dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            LedgerPosting.chequeDate = Convert.ToDateTime(dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            LedgerPosting.chequeDate = DateTime.Now;
                    }
                    else
                    {
                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = DateTime.Now;
                    }

                    LedgerPosting.voucherTypeId = decPaymentVoucherTypeId;
                    LedgerPosting.yearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
                    LedgerPosting.ledgerPostingId = decLedgerPostingId;
                    ledgerPostingEdit(LedgerPosting);
                }
                else
                {
                    LedgerPosting.date = dtpDate.Value;

                    LedgerPosting.invoiceNo = strInvoiceNo;
                    LedgerPosting.voucherTypeId = decPaymentVoucherTypeId;
                    LedgerPosting.yearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId; ;
                    LedgerPosting.credit = 0;
                    LedgerPosting.ledgerId = Convert.ToDecimal(dgvPaymentVoucher.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString());
                    LedgerPosting.voucherNo = strVoucherNo;
                    LedgerPosting.detailsId = decPaymentDetailsId;
                    LedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();
                    if (dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        LedgerPosting.chequeNo = dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            LedgerPosting.chequeDate = Convert.ToDateTime(dgvPaymentVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            LedgerPosting.chequeDate = DateTime.Now;
                    }
                    else
                    {
                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = DateTime.Now;
                    }

                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (LedgerPosting.ledgerId == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            decOldExchange = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                            decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                            decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decOldExchange).FirstOrDefault().rate;
                            decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                            decConvertRate = decConvertRate + (decAmount * decSelectedCurrencyRate);

                        }
                    }
                    LedgerPosting.debit = decConvertRate;
                    LedgerPosting.ledgerPostingId = decLedgerPostingId;
                    ledgerPostingEdit(LedgerPosting);
                    LedgerPosting.ledgerId = 12;
                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (Convert.ToDecimal(dgvPaymentVoucher.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString()) == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            if (dr["ReferenceType"].ToString() == "Against")
                            {
                                decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                                decNewExchangeRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decNewExchangeRateId).FirstOrDefault().rate;
                                decOldExchangeId = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                                decOldExchange = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decOldExchangeId).FirstOrDefault().rate;
                                decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                                decimal decForexAmount = (decAmount * decNewExchangeRate) - (decAmount * decOldExchange);
                                if (decForexAmount >= 0)
                                {

                                    LedgerPosting.debit = decForexAmount;
                                    LedgerPosting.credit = 0;
                                }
                                else
                                {
                                    LedgerPosting.credit = -1 * decForexAmount;
                                    LedgerPosting.debit = 0;
                                }
                            ledgerPostingAdd(LedgerPosting);
                            }
                        }


                    }
                }
           }

        public void ledgerPostingAdd(LedgerPosting LedgerPosting)
        {
            LedgerPosting Ledgerpostingnew = IME.LedgerPostings.Where(a => a.ledgerPostingId == LedgerPosting.ledgerPostingId).FirstOrDefault();
            Ledgerpostingnew.voucherTypeId = LedgerPosting.voucherTypeId;
            Ledgerpostingnew.voucherNo = LedgerPosting.voucherNo;
            Ledgerpostingnew.ledgerId = LedgerPosting.ledgerId;
            Ledgerpostingnew.debit = LedgerPosting.debit;
            Ledgerpostingnew.credit = LedgerPosting.credit;
            Ledgerpostingnew.yearId = LedgerPosting.yearId;
            Ledgerpostingnew.invoiceNo = LedgerPosting.invoiceNo;
            Ledgerpostingnew.chequeNo = LedgerPosting.chequeNo;
            Ledgerpostingnew.chequeDate = LedgerPosting.chequeDate;
            IME.LedgerPostings.Add(Ledgerpostingnew);
            IME.SaveChanges();
        }
        public void ledgerPostingEdit(LedgerPosting LedgerPosting)
        {
            LedgerPosting Ledgerpostingnew = IME.LedgerPostings.Where(a => a.ledgerPostingId == LedgerPosting.ledgerPostingId).FirstOrDefault();
            Ledgerpostingnew.voucherTypeId = LedgerPosting.voucherTypeId;
            Ledgerpostingnew.voucherNo = LedgerPosting.voucherNo;
            Ledgerpostingnew.ledgerId = LedgerPosting.ledgerId;
            Ledgerpostingnew.debit = LedgerPosting.debit;
            Ledgerpostingnew.credit = LedgerPosting.credit;
            Ledgerpostingnew.yearId = LedgerPosting.yearId;
            Ledgerpostingnew.invoiceNo = LedgerPosting.invoiceNo;
            Ledgerpostingnew.chequeNo = LedgerPosting.chequeNo;
            Ledgerpostingnew.chequeDate = LedgerPosting.chequeDate;
            IME.SaveChanges();
        }
        /// <summary>
        /// Function to call this form from frmPaymentRegister to view details and for updation 
        /// </summary>
        /// <param name="frmPaymentRegister"></param>
        /// <param name="decmasterId"></param>
        public void CallFromPaymentRegister(frmPaymentRegister frmPaymentRegister, decimal decmasterId)
        {
            try
            {
                base.Show();
                this.frmPaymentRegisterObj = frmPaymentRegister;
                frmPaymentRegisterObj.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Text = "Update";
                decPaymentmasterId = decmasterId;
                FillFunction();

            }
            catch (Exception ex)
            {
                MessageBox.Show("PV25:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmPaymentReport to view details and for updation 
        /// </summary>
        /// <param name="frmPaymentReport"></param>
        /// <param name="decmasterId"></param>
        public void CallFromPaymentReport(frmPaymentReport frmPaymentReport, decimal decmasterId)
        {
            try
            {
                base.Show();
                btnDelete.Enabled = true;
                btnSave.Text = "Update";
                decPaymentmasterId = decmasterId;

                FillFunction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Remove function when click Link button
        /// </summary>
        public void Remove()
        {
            try
            {
                if (dgvPaymentVoucher.CurrentRow != null)
                {
                    if (dgvPaymentVoucher.CurrentRow.Index != dgvPaymentVoucher.NewRowIndex)
                    {
                        if (Convert.ToInt32(dgvPaymentVoucher.CurrentRow.Cells["dgvtxtSlNo"].Value.ToString()) < dgvPaymentVoucher.RowCount)
                        {
                            if (btnSave.Text == "Update")
                            {
                                if (dgvPaymentVoucher.CurrentRow.Cells["dgvtxtpaymentDetailsId"].Value != null && dgvPaymentVoucher.CurrentRow.Cells["dgvtxtpaymentDetailsId"].Value.ToString() != string.Empty)
                                {
                                    arrlstOfRemove.Add(dgvPaymentVoucher.CurrentRow.Cells["dgvtxtpaymentDetailsId"].Value.ToString());
                                    arrlstOfRemovedLedgerPostingId.Add(dgvPaymentVoucher.CurrentRow.Cells["dgvtxtLedgerPostingId"].Value.ToString());
                                    inArrOfRemoveIndex++;
                                }
                            }
                            int inTableRowCount = dtblPartyBalance.Rows.Count;
                            for (int inI = 0; inI < inTableRowCount; inI++)
                            {
                                if (dtblPartyBalance.Rows.Count == inI)
                                {
                                    break;
                                }
                                if (dtblPartyBalance.Rows[inI]["LedgerId"].ToString() == dgvPaymentVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString())
                                {
                                    if (dtblPartyBalance.Rows[inI]["PartyBalanceId"].ToString() != "0")
                                    {
                                        arrlstOfDeletedPartyBalanceRow.Add(dtblPartyBalance.Rows[inI]["PartyBalanceId"]);
                                    }
                                    dtblPartyBalance.Rows.RemoveAt(inI);
                                    inI--;
                                }
                            }
                            if (inUpdatingRowIndexForPartyRemove == dgvPaymentVoucher.CurrentRow.Index)
                            {
                                inUpdatingRowIndexForPartyRemove = -1;
                                decUpdatingLedgerForPartyremove = 0;
                            }
                            dgvPaymentVoucher.Rows.RemoveAt(this.dgvPaymentVoucher.CurrentRow.Index);
                            SerialNumberGeneration();
                            TotalAmount();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV27:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Checking Invalid entries
        /// </summary>
        public void CheckColumnMissing()
        {
            try
            {
                if (dgvPaymentVoucher.CurrentRow != null)
                {
                    if (!isValueChanged)
                    {
                        if (dgvPaymentVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].FormattedValue == null || dgvPaymentVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].FormattedValue.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvPaymentVoucher.CurrentRow.HeaderCell.Value = "X";
                            dgvPaymentVoucher.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;
                        }
                        else if (dgvPaymentVoucher.CurrentRow.Cells["dgvtxtAmount"].Value == null || dgvPaymentVoucher.CurrentRow.Cells["dgvtxtAmount"].Value.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvPaymentVoucher.CurrentRow.HeaderCell.Value = "X";
                            dgvPaymentVoucher.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;
                        }
                        else if (dgvPaymentVoucher.CurrentRow.Cells["dgvcmbCurrency"].FormattedValue == null || dgvPaymentVoucher.CurrentRow.Cells["dgvcmbCurrency"].FormattedValue.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvPaymentVoucher.CurrentRow.HeaderCell.Value = "X";
                            dgvPaymentVoucher.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            isValueChanged = true;
                            dgvPaymentVoucher.CurrentRow.HeaderCell.Value = string.Empty;
                        }
                    }
                    isValueChanged = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV28:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill BankorCash combobox while return from Ledger creation when creating new ledger 
        /// </summary>
        /// <param name="decId"></param>
        /// <param name="str"></param>
        public void ReturnFromAccountLedgerForm(decimal decId, string str)
        {
            try
            {
                if (str == "CashOrBank")
                {
                    if (decId != 0)
                    {
                        TransactionsGeneralFill Obj = new TransactionsGeneralFill();
                        Obj.CashOrBankComboFill(cmbBankorCash, false);
                        cmbBankorCash.SelectedValue = decId.ToString();
                    }
                    cmbBankorCash.Focus();
                }
                else
                {
                    if (decId != 0)
                    {
                        int inCurrentRowIndex = dgvPaymentVoucher.CurrentRow.Index;
                        if (inCurrentRowIndex == dgvPaymentVoucher.Rows.Count - 1)
                        {
                            dgvPaymentVoucher.Rows.Add();
                        }
                        dgvPaymentVoucher.CurrentRow.HeaderCell.Value = "X";
                        dgvPaymentVoucher.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;
                        DataTable dtbl = new DataTable();
                        AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                        dtbl = spAccountLedger.AccountLedgerViewAll();
                        DataGridViewComboBoxCell dgvccCashOrBank = (DataGridViewComboBoxCell)dgvPaymentVoucher[dgvPaymentVoucher.Columns["dgvcmbAccountLedger"].Index, dgvPaymentVoucher.Rows[inCurrentRowIndex].Index];
                        DataRow dr = dtbl.NewRow();
                        dr["ledgerId"] = "0";
                        dr["ledgerName"] = string.Empty;
                        dtbl.Rows.InsertAt(dr, 0);
                        dgvccCashOrBank.DataSource = dtbl;
                        dgvccCashOrBank.ValueMember = "ledgerId";
                        dgvccCashOrBank.DisplayMember = "ledgerName";
                        dgvPaymentVoucher.Rows[inCurrentRowIndex].Cells["dgvcmbAccountLedger"].Value = decId;
                        dgvPaymentVoucher.Rows[inCurrentRowIndex].Cells["dgvcmbAccountLedger"].Selected = true;
                    }
                }
                
                this.Enabled = true;
                this.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV29:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Cash or bank combofill
        /// </summary>
        public void CashOrBankComboFill()
        {
            try
            {
                TransactionsGeneralFill Obj = new TransactionsGeneralFill();
                Obj.CashOrBankComboFill(cmbBankorCash, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV30:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Account ledger combofill
        /// </summary>
        public void AccountLedgerComboFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                TransactionsGeneralFill obj = new TransactionsGeneralFill();
                dtbl.Rows.Add(IME.AccountLedgers);
                DataRow dr = dtbl.NewRow();
                dr["ledgerId"] = "0";
                dr["ledgerName"] = string.Empty;
                dtbl.Rows.InsertAt(dr, 0);
                dgvcmbAccountLedger.DataSource = dtbl;
                dgvcmbAccountLedger.ValueMember = "ledgerId";
                dgvcmbAccountLedger.DisplayMember = "ledgerName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV31:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmBillallocation to view details and for updation 
        /// </summary>
        /// <param name="frmBillallocation"></param>
        /// <param name="decPayementId"></param>
        //public void CallFromBillAllocation(frmBillallocation frmBillallocation, decimal decPayementId)
        //{
        //    try
        //    {
        //        frmBillallocation.Enabled = false;
        //        base.Show();
        //        isUpdated = true;
        //        btnSave.Text = "Update";
        //        btnDelete.Enabled = true;
        //        frmBillallocationObj = frmBillallocation;
        //        decPaymentmasterId = decPayementId;
        //        FillFunction();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("PV32:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //}
        /// <summary>
        /// Function to call this form from frmDayBook to view details and for updation 
        /// </summary>
        /// <param name="frmDayBook"></param>
        /// <param name="decMasterId"></param>
        //public void callFromDayBook(frmDayBook frmDayBook, decimal decMasterId)
        //{
        //    try
        //    {
        //        base.Show();
        //        frmDayBook.Enabled = false;
        //        this.frmDayBookObj = frmDayBook;
        //        decPaymentmasterId = decMasterId;
        //        btnDelete.Enabled = true;
        //        btnSave.Text = "Update";
        //        FillFunction();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PV33:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmChequeReport to view details and for updation 
        /// </summary>
        /// <param name="frmChequeReport"></param>
        /// <param name="decMasterId"></param>
        //public void CallFromChequeReport(frmChequeReport frmChequeReport, decimal decMasterId)
        //{
        //    try
        //    {
        //        base.Show();
        //        frmChequeReport.Enabled = false;
        //        this.frmChequeReportObj = frmChequeReport;
        //        decPaymentmasterId = decMasterId;
        //        btnDelete.Enabled = true;
        //        btnSave.Text = "Update";
        //        FillFunction();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PV34:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from frmAgeingReport to view details and for updation 
        /// </summary>
        /// <param name="frmAgeing"></param>
        /// <param name="decMasterId"></param>
        //public void callFromAgeing(frmAgeingReport frmAgeing, decimal decMasterId)
        //{
        //    try
        //    {
        //        base.Show();
        //        frmAgeing.Enabled = false;
        //        this.frmAgeingObj = frmAgeing;
        //        decPaymentmasterId = decMasterId;
        //        btnDelete.Enabled = true;
        //        btnSave.Text = "Update";
        //        FillFunction();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PV35:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Grid Fill function while coming from other form to update or delete
        /// </summary>
        public void FillFunction()
        {
            
            PartyBalanceSP SpPartyBalance = new PartyBalanceSP();
            LedgerPostingSP SpLedgerPosting = new LedgerPostingSP();
            VoucherTypeSP SpVoucherType = new VoucherTypeSP();
            AccountGroupSP spAccountGroup = new AccountGroupSP();
            AccountLedgerSP SpAccountLedger = new AccountLedgerSP();

            PaymentMaster PaymentMaster = IME.PaymentMasters.Where(a => a.paymentMasterId == decPaymentmasterId).FirstOrDefault();//view master details                    
            isAutomatic = PaymentMaster.VoucherType.methodOfVoucherNumbering == "Automatic" ? true : false;
            if (isAutomatic)
            {
                txtVoucherNo.ReadOnly = true;
                txtVoucherNo.Text = PaymentMaster.invoiceNo;
                txtDate.Focus();
            }
            else
            {
                txtVoucherNo.ReadOnly = false;
                txtVoucherNo.Text = PaymentMaster.invoiceNo;
                txtVoucherNo.Focus();
            }
            dtpDate.Text = PaymentMaster.date.ToString();
            cmbBankorCash.SelectedValue = PaymentMaster.ledgerId;
            txtNarration.Text = PaymentMaster.narration;
            txtTotal.Text = PaymentMaster.totalAmount.ToString();
            decDailySuffixPrefixId = (decimal)PaymentMaster.suffixPrefixId;
            decPaymentVoucherTypeId = (decimal)PaymentMaster.voucherTypeId;
            strVoucherNo = PaymentMaster.voucherNo;
            strInvoiceNo = PaymentMaster.invoiceNo;
            List<PaymentDetail> PaymentDetailList = IME.PaymentDetails.Where(a => a.paymentMasterId == decPaymentmasterId).ToList();
            for (int inI = 0; inI < PaymentDetailList.Count; inI++)
            {
                dgvPaymentVoucher.Rows.Add();
                dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value = PaymentDetailList[inI].ledgerId;
                dgvPaymentVoucher.Rows[inI].Cells["dgvtxtpaymentMasterId"].Value = PaymentDetailList[inI].paymentMasterId;
                dgvPaymentVoucher.Rows[inI].Cells["dgvtxtpaymentDetailsId"].Value = PaymentDetailList[inI].paymentDetailsId;
                dgvPaymentVoucher.Rows[inI].Cells["dgvtxtAmount"].Value = PaymentDetailList[inI].amount;
                dgvPaymentVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value = PaymentDetailList[inI].exchangeRateId;
                decimal decDetailsId1 = PaymentDetailList[inI].paymentDetailsId;
                decimal decLedgerPostingId = SpLedgerPosting.LedgerPostingIdFromDetailsId(decDetailsId1, strVoucherNo, decPaymentVoucherTypeId);
                dgvPaymentVoucher.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value = decLedgerPostingId.ToString();
                decimal decLedgerId = (decimal)PaymentDetailList[inI].ledgerId;
                bool IsBankAccount = spAccountGroup.AccountGroupwithLedgerId(decLedgerId);
                decimal decI = Convert.ToDecimal(SpAccountLedger.AccountGroupIdCheck(dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].FormattedValue.ToString()));
                if (decI > 0)//to make amount and currency read only when party is choosen as ledger
                {
                    dgvPaymentVoucher.Rows[inI].Cells["dgvtxtAmount"].ReadOnly = true;
                    dgvPaymentVoucher.Rows[inI].Cells["dgvcmbCurrency"].ReadOnly = true;
                }
                else
                {
                    dgvPaymentVoucher.Rows[inI].Cells["dgvtxtAmount"].ReadOnly = false;
                    dgvPaymentVoucher.Rows[inI].Cells["dgvcmbCurrency"].ReadOnly = false;
                }
                dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value = PaymentDetailList[inI].chequeNo;
                if (dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                {
                    dgvPaymentVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value = PaymentDetailList[inI].chequeDate;
                }
            }
            DataTable dtbl1 = new DataTable();
            dtbl1 = SpPartyBalance.PartyBalanceViewByVoucherNoAndVoucherType(decPaymentVoucherTypeId, strVoucherNo, (DateTime)PaymentMaster.date);

            dtblPartyBalance = dtbl1;
        }
        

            //public void CallFromLedgerDetails(frmLedgerDetails frmLedgerDetails, decimal decMasterId)
            //{
            //    try
            //    {
            //        base.Show();
            //        this.frmLedgerDetailsObj = frmLedgerDetails;
            //        frmLedgerDetailsObj.Enabled = false;
            //        btnDelete.Enabled = true;
            //        btnSave.Text = "Update";
            //        decPaymentmasterId = decMasterId;
            //        FillFunction();

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("PV37:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            #endregion

            #region Events
            /// <summary>
            ///  Close button click 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        /// <summary>
        /// Clear button click
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
                MessageBox.Show("PV39:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// When form load call the clear function to reset the form controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPaymentVoucher_Load(object sender, EventArgs e)
        {
            try
            {

                dtpDate.Value = DateTime.Now;
                dtpDate.MinDate = DateTime.Now.AddMonths(-8);
                dtpDate.MaxDate = DateTime.Now.AddMonths(3);
                dtpDate.CustomFormat = "dd-MMMM-yyyy";
                Clear();
                CashOrBankComboFill();
                AccountLedgerComboFill();
                txtTotal.Text = "0";
                dtblPartyBalance.Columns.Add("LedgerId", typeof(decimal));
                dtblPartyBalance.Columns.Add("AgainstVoucherTypeId", typeof(decimal));
                dtblPartyBalance.Columns.Add("AgainstVoucherNo", typeof(string));
                dtblPartyBalance.Columns.Add("ReferenceType", typeof(string));
                dtblPartyBalance.Columns.Add("Amount", typeof(decimal));
                dtblPartyBalance.Columns.Add("AgainstInvoiceNo", typeof(string));
                dtblPartyBalance.Columns.Add("DebitOrCredit", typeof(string));
                dtblPartyBalance.Columns.Add("CurrencyId", typeof(decimal));
                dtblPartyBalance.Columns.Add("PendingAmount", typeof(decimal));
                dtblPartyBalance.Columns.Add("PartyBalanceId", typeof(decimal));
                dtblPartyBalance.Columns.Add("VoucherTypeId", typeof(decimal));
                dtblPartyBalance.Columns.Add("VoucherNo", typeof(string));
                dtblPartyBalance.Columns.Add("InvoiceNo", typeof(string));
                dtblPartyBalance.Columns.Add("OldExchangeRate", typeof(decimal));
                arrlstOfDeletedPartyBalanceRow = new ArrayList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("PV40:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Button LedgerAdd click to create a new ledger from this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLedgerAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBankorCash.SelectedValue != null)
                {
                    strCashOrBank = cmbBankorCash.SelectedValue.ToString();
                }
                else
                {
                    strCashOrBank = string.Empty;
                }
                frmAccountLedger frmAccountLedger = new frmAccountLedger();
                frmAccountLedger.ShowDialog();
                //frmAccountLedgerObj.MdiParent = formMDI.MDIObj;
                //frmAccountLedger open = Application.OpenForms["frmAccountLedger"] as frmAccountLedger;
                //if (open == null)
                //{
                //    frmAccountLedgerObj.WindowState = FormWindowState.Normal;
                //    frmAccountLedgerObj.MdiParent = formMDI.MDIObj;
                //    frmAccountLedgerObj.CallFromPaymentVoucher(this, "CashOrBank");
                //}
                //else
                //{
                //    open.MdiParent = formMDI.MDIObj;
                //    open.BringToFront();
                //    open.CallFromPaymentVoucher(this, "CashOrBank");
                //    if (open.WindowState == FormWindowState.Minimized)
                //    {
                //        open.WindowState = FormWindowState.Normal;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV41:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// xhange the text box value when change the datetimepicker value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpDate.Value;
                this.txtDate.Text = date.ToString("dd-MMM-yyyy");
                GridCurrencyComboFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV42:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Set the current date in text box when leave the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation obj = new DateValidation();
                obj.DateValidationFunction(txtDate);
                if (txtDate.Text == string.Empty)
                {
                    txtDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
                dtpDate.Value = Convert.ToDateTime(txtDate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV43:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Remove link button click. call the remove function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dgvPaymentVoucher.SelectedCells.Count > 0 && dgvPaymentVoucher.CurrentRow != null)
                {
                    if (!dgvPaymentVoucher.Rows[dgvPaymentVoucher.CurrentRow.Index].IsNewRow)
                    {
                        if (MessageBox.Show("Do you want to remove current row ?", "OpenMiracle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Remove();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV44:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call the serial no function to generate serial no automatically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentVoucher_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (dgvPaymentVoucher.Rows.Count != 1)
                    SerialNumberGeneration();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV45:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Save button click, check the privillage and call the save or edit function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
                    SaveOrEdit();
        }
        /// <summary>
        /// Delete button click, call the Delete function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Update")
            {
                DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Delete(decPaymentmasterId);
                    MessageBox.Show("Deleted successfully ");
                }
            }
        }
        /// <summary>
        /// Gridview cell value changed , doing basic calculations and checking invalid entries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentVoucher_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    TotalAmount();

                    if (dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {

                        if (dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value == null || dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value.ToString() == string.Empty)
                        {
                            dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value = Convert.ToDecimal(1);
                        }

                    }
                    AccountGroupSP spAccountGroup = new AccountGroupSP();
                    AccountLedgerSP SpAccountLedger = new AccountLedgerSP();
                    if (dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString().Trim() != string.Empty)
                    {
                        if (dgvPaymentVoucher.CurrentCell.ColumnIndex == dgvPaymentVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].ColumnIndex)
                        {

                            /*************Remove partybalance while changing the ledger ************/
                            if (inUpdatingRowIndexForPartyRemove != -1)
                            {
                                int inTableRowCount = dtblPartyBalance.Rows.Count;
                                for (int inJ = 0; inJ < inTableRowCount; inJ++)
                                {
                                    if (dtblPartyBalance.Rows.Count == inJ)
                                    {
                                        break;
                                    }
                                    if (Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["ledgerId"].ToString()) == decUpdatingLedgerForPartyremove)
                                    {
                                        if (dtblPartyBalance.Rows[inJ]["PartyBalanceId"].ToString() != "0")
                                        {
                                            arrlstOfDeletedPartyBalanceRow.Add(dtblPartyBalance.Rows[inJ]["PartyBalanceId"]);
                                        }
                                        dtblPartyBalance.Rows.RemoveAt(inJ);
                                        inJ--;
                                    }
                                }
                                dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvtxtAmount"].Value = string.Empty;
                                decUpdatingLedgerForPartyremove = 0;
                                inUpdatingRowIndexForPartyRemove = -1;
                            }
                            /*************************************************************************/
                            decimal decLedgerId = Convert.ToDecimal(dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString());
                            bool IsBankAccount = spAccountGroup.AccountGroupwithLedgerId(decLedgerId);
                            decimal decI = Convert.ToDecimal(SpAccountLedger.AccountGroupIdCheck(dgvPaymentVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].FormattedValue.ToString()));
                            if (decI > 0)//to make amount and currency read only when party is choosen as ledger
                            {
                                dgvPaymentVoucher.CurrentRow.Cells["dgvtxtAmount"].ReadOnly = true;
                                dgvPaymentVoucher.CurrentRow.Cells["dgvtxtAmount"].Value = string.Empty;
                                dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value = Convert.ToDecimal(1);
                                dgvPaymentVoucher.CurrentRow.Cells["dgvcmbCurrency"].ReadOnly = true;
                            }
                            else
                            {
                                dgvPaymentVoucher.CurrentRow.Cells["dgvtxtAmount"].ReadOnly = false;
                                SettingsSP spSettings = new SettingsSP();
                                if (spSettings.SettingsStatusCheck("MultiCurrency") == "Yes")
                                {
                                    dgvcmbCurrency.ReadOnly = false;
                                }
                                else
                                {
                                    dgvcmbCurrency.ReadOnly = true;

                                }
                            }
                        }
                    }
                    CheckColumnMissing();
                    DateValidation objVal = new DateValidation();
                    TextBox txtDate1 = new TextBox();
                    if (dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value != null)
                    {

                        txtDate1.Text = dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value.ToString();
                        bool isDate = objVal.DateValidationFunction(txtDate1);
                        if (isDate)
                        {
                            dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value = txtDate1.Text;
                        }
                        else
                        {
                            dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value = DateTime.Now.ToString("dd-MMM-yyyy");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV48:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Checking and blocking in invalid entries in Decimal fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentVoucher_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridViewTextBoxEditingControl txt = e.Control as DataGridViewTextBoxEditingControl;
                if (dgvPaymentVoucher.CurrentCell.ColumnIndex == dgvPaymentVoucher.Columns["dgvtxtAmount"].Index)
                {
                    if (txt != null)
                    {
                        txt.KeyPress += dgvtxtAmount_KeyPress;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV49:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// It handle the unexpected DataErrors and throw it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentVoucher_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                {
                    object value = dgvPaymentVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dgvPaymentVoucher.Columns[e.ColumnIndex]).Items.Contains(value))
                    {
                        e.ThrowException = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV50:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Commit the each and every changes of grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentVoucher_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPaymentVoucher.IsCurrentCellDirty)
                {
                    dgvPaymentVoucher.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV51:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void dgvPaymentVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    AccountLedgerSP SpAccountLedger = new AccountLedgerSP();
                    if (dgvPaymentVoucher.CurrentCell.ColumnIndex == dgvPaymentVoucher.Columns["dgvbtnAgainst"].Index)
                    {
                        decimal decI = Convert.ToDecimal(SpAccountLedger.AccountGroupIdCheck(dgvPaymentVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].FormattedValue.ToString()));
                        if (decI > 0)
                        {
                             //TO DO frmPArtyBalance
                            //frmPartyBalance frmPartyBalance = new frmPartyBalance();
                            //frmPartyBalanceObj.MdiParent = formMDI.MDIObj;
                            //decimal decLedgerId = Convert.ToDecimal(dgvPaymentVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString());
                            //if (!isAutomatic)
                            //{
                            //    frmPartyBalanceObj.CallFromPaymentVoucher(this, decLedgerId, dtblPartyBalance, decPaymentVoucherTypeId, txtVoucherNo.Text, Convert.ToDateTime(txtDate.Text), arrlstOfDeletedPartyBalanceRow);
                            //}
                            //else
                            //{
                            //    frmPartyBalanceObj.CallFromPaymentVoucher(this, decLedgerId, dtblPartyBalance, decPaymentVoucherTypeId, strVoucherNo, Convert.ToDateTime(txtDate.Text), arrlstOfDeletedPartyBalanceRow);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV52:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPaymentVoucher_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                inUpdatingRowIndexForPartyRemove = -1;
                decUpdatingLedgerForPartyremove = 0;
                DataTable dtbl = new DataTable();
                AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                if (dgvPaymentVoucher.CurrentCell.ColumnIndex == dgvPaymentVoucher.Columns["dgvcmbAccountLedger"].Index)
                {
                    dtbl = spAccountLedger.AccountLedgerViewAll();
                    if (dtbl.Rows.Count < 2)
                    {
                        DataRow dr = dtbl.NewRow();
                        dr[0] = string.Empty;
                        dr[1] = string.Empty;
                        dtbl.Rows.InsertAt(dr, 0);
                    }
                    if (dgvPaymentVoucher.RowCount > 1)
                    {
                        int inGridRowCount = dgvPaymentVoucher.RowCount;
                        for (int inI = 0; inI < inGridRowCount - 1; inI++)
                        {
                            if (inI != e.RowIndex)
                            {
                                int inTableRowcount = dtbl.Rows.Count;
                                for (int inJ = 0; inJ < inTableRowcount; inJ++)
                                {
                                    if (dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                                    {
                                        if (dtbl.Rows[inJ]["ledgerId"].ToString() == dgvPaymentVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString())
                                        {
                                            dtbl.Rows.RemoveAt(inJ);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    DataGridViewComboBoxCell dgvccCashOrBank = (DataGridViewComboBoxCell)dgvPaymentVoucher[dgvPaymentVoucher.Columns["dgvcmbAccountLedger"].Index, e.RowIndex];
                    DataRow drow = dtbl.NewRow();
                    drow["ledgerId"] = "0";
                    drow["ledgerName"] = string.Empty;
                    dtbl.Rows.InsertAt(drow, 0);
                    dgvccCashOrBank.DataSource = dtbl;
                    dgvccCashOrBank.ValueMember = "ledgerId";
                    dgvccCashOrBank.DisplayMember = "ledgerName";
                }
                if (dgvPaymentVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbAccountLedger")
                {
                    if (dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {
                        if (spAccountLedger.AccountGroupIdCheck(dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].FormattedValue.ToString()))
                        {
                            inUpdatingRowIndexForPartyRemove = e.RowIndex;
                            decUpdatingLedgerForPartyremove = Convert.ToDecimal(dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString());
                        }
                    }
                }
                if (dgvPaymentVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbDrOrCr")
                {
                    if (dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {
                        if (spAccountLedger.AccountGroupIdCheck(dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].FormattedValue.ToString()))
                        {
                            inUpdatingRowIndexForPartyRemove = e.RowIndex;
                            decUpdatingLedgerForPartyremove = Convert.ToDecimal(dgvPaymentVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV54:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Cell enter event of grid,here makes the grid column to edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentVoucher_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPaymentVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
                {
                    dgvPaymentVoucher.EditMode = DataGridViewEditMode.EditOnEnter;
                }
                else
                {
                    dgvPaymentVoucher.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("PV55:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        #endregion

        #region Navigation
        /// <summary>
        /// For Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDate.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV56:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBankorCash.Focus();
                }
                if (txtVoucherNo.ReadOnly == false)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        txtVoucherNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV57:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBankorCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvPaymentVoucher.Focus();
                    dgvPaymentVoucher.ClearSelection();
                    if (dgvPaymentVoucher.Rows.Count > 0)
                    {
                        dgvPaymentVoucher.CurrentCell = dgvPaymentVoucher.Rows[0].Cells[0];
                        dgvPaymentVoucher.Rows[0].Cells[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbBankorCash.SelectionStart == 0 || cmbBankorCash.Text == string.Empty)
                    {
                        txtDate.Focus();
                        txtDate.SelectionStart = 0;
                        txtDate.SelectionLength = 0;
                    }
                }
                if (e.KeyCode == Keys.C && Control.ModifierKeys == Keys.Alt)
                {
                    SendKeys.Send("{F10}");
                    btnLedgerAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV58:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// get narration count For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    inNarrationCount++;
                    if (inNarrationCount == 2)
                    {
                        inNarrationCount = 0;
                        btnSave.Focus();
                    }
                }
                else
                {
                    inNarrationCount = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV59:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                inNarrationCount = 0;
                txtNarration.Text = txtNarration.Text.Trim();
                if (txtNarration.Text == String.Empty)
                {
                    txtNarration.Focus();
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;

                }
                else
                {
                    txtNarration.Text = txtNarration.Text.Trim();
                    txtNarration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV60:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvPaymentVoucher.CurrentCell == dgvPaymentVoucher.Rows[dgvPaymentVoucher.Rows.Count - 1].Cells["dgvtxtChequeDate"])
                    {
                        txtNarration.Focus();
                        dgvPaymentVoucher.ClearSelection();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (dgvPaymentVoucher.CurrentCell == dgvPaymentVoucher.Rows[0].Cells["dgvtxtSlNo"])
                    {
                        cmbBankorCash.Focus();
                     
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV61:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {

                    if (txtNarration.SelectionStart == 0 || txtNarration.Text == String.Empty)
                    {
                        dgvPaymentVoucher.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV62:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For  backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtNarration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV63:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       

        private void dgvtxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvPaymentVoucher.CurrentCell != null)
                {
                    if (dgvPaymentVoucher.Columns[dgvPaymentVoucher.CurrentCell.ColumnIndex].Name == "dgvtxtAmount")
                    {
                        Common.DecimalValidation(sender, e, false);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PV65:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
