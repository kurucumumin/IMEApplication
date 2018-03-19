using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using LoginForm.DataSet;
using LoginForm.Services;

namespace LoginForm
{

    public partial class frmJournalVoucher : Form
    {
        #region Public Variables
        IMEEntities IME = new IMEEntities();
        decimal decJournalVoucherTypeId = 0;
        string strVoucherNo = string.Empty;
        string tableName = "JournalMaster";
        string strPrefix = string.Empty;
        string strSuffix = string.Empty;
        string strInvoiceNo = string.Empty;
        int inNarrationCount = 0;
        decimal decJournalSuffixPrefixId = 0;
        bool isAutomatic = false;
        bool isEditMode = false;
        ArrayList arrlstOfRemovedLedgerPostingId = new ArrayList();
        ArrayList arrlstOfRemove = new ArrayList();
        int inArrOfRemove = 0;
        decimal decJournalMasterIdForEdit = 0;
        frmJournalRegister journalRegisterObj = null;//To use in call from JournalRegister class
        DataTable dtblPartyBalance = new DataTable();//To store PartyBalance entries while clicking btn_Save in JournalVoucher
        ArrayList arrlstOfDeletedPartyBalanceRow;
        DataTable dtblTemporaryPartyBalance = new DataTable();//to store PartyBalance entries in update mode while closing the form before updating
        decimal decSelectedCurrencyRate = 0;
        decimal decConvertRate = 0;
        decimal decAmount = 0;
        decimal decLedgerIdForPopUp = 0;
        bool isValueChanged = false;
        public string strVocherNo;
        int inUpdatingRowIndexForPartyRemove = -1;
        decimal decUpdatingLedgerForPartyremove = 0;
        frmJournalReport frmJournalReportObj = null;
        frmBillallocation frmBillallocationObj = null;
        #endregion

        #region Functions
        /// <summary>
        /// Create instance of frmJournalVoucher
        /// </summary>
        public frmJournalVoucher()
        {
            InitializeComponent();
        }

        /// <summary>
        /// It is a function for vouchertypeselection form to select perticular voucher and open the form under the vouchertype
        /// </summary>
        /// <param name="decVoucherTypeId"></param>
        /// <param name="strVoucherTypeName"></param>
        public void CallFromVoucherTypeSelection(decimal decVoucherTypeId, string strVoucherTypeName)
        {
            decJournalVoucherTypeId = decVoucherTypeId;

            if (IME.VoucherTypes.Where(a => a.voucherTypeId == decJournalVoucherTypeId).FirstOrDefault().methodOfVoucherNumbering == "Automatic") isAutomatic = true;

            SuffixPrefix sp = IME.SuffixPrefixes.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.fromDate < dtpVoucherDate.Value).Where(c => c.toDate > dtpVoucherDate.Value).FirstOrDefault();
            if (sp!=null)
            {
                decJournalSuffixPrefixId = sp.suffixprefixId;
                strPrefix = sp.prefix;
                strSuffix = sp.suffix;
            }
            
            this.Text = strVoucherTypeName;
            base.Show();
            clear();
        }

        public string VoucherNumberGeneration(decimal JournalVoucherTypeId, decimal Box, DateTime VoucherDate, string tableName1)
        {
            if(IME.SuffixPrefixes.Where(a=>a.voucherTypeId == (decimal)JournalVoucherTypeId).Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).ToList().Count == 0)
            {
                if (Box == 0)
                {
                    if (IME.JournalMasters.Where(a => a.voucherTypeId == JournalVoucherTypeId).FirstOrDefault() != null)
                    {
                        Box = decimal.Parse(IME.JournalMasters.Where(a => a.voucherTypeId == JournalVoucherTypeId).FirstOrDefault().voucherNo);
                    }
                    else
                    {
                        Box = 1;
                    }
                }
                else
                {
                    Box=Box + 1;
                }
                return Box.ToString();
            }else
            {
                if (IME.SuffixPrefixes.Where(a=>a.voucherTypeId== JournalVoucherTypeId).Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).FirstOrDefault().prefillWithZero==true)
                {
                    int length = IME.SuffixPrefixes.Where(a => a.voucherTypeId == JournalVoucherTypeId).
                        Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).Count();
                    string startindex = IME.SuffixPrefixes.Where(a => a.voucherTypeId == JournalVoucherTypeId).
                        Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).FirstOrDefault().startIndex.ToString();
                    int widthOfNumericalPart = (int)IME.SuffixPrefixes.Where(a => a.voucherTypeId == JournalVoucherTypeId).
                        Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).FirstOrDefault().widthOfNumericalPart;

                    while (length<widthOfNumericalPart)
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
                        while (length<widthOfNumericalPart)
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


        /// <summary>
        /// Function to clear the fields
        /// </summary>
        public void clear()
        {

            //TransactionsGeneralFill obj = new TransactionsGeneralFill();
            //JournalMasterSP spMaster = new JournalMasterSP();


            //-----------------------------------VoucherNo automatic generation-------------------------------------------//

            if (strVoucherNo == string.Empty)
                {

                    strVoucherNo = "0"; //strMax;
                }
            if( VoucherNumberGeneration(decJournalVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpVoucherDate.Value, tableName)!="") strVoucherNo = VoucherNumberGeneration(decJournalVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpVoucherDate.Value, tableName).ToString() ;
            //strVoucherNo = obj.VoucherNumberAutomaicGeneration(decJournalVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpVoucherDate.Value, tableName);


            decimal decJournalVoucherTypeIdmax = 0;
            if(IME.JournalMasters.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Select(b => b.voucherNo).ToList().Count()!=0) decJournalVoucherTypeIdmax= IME.JournalMasters.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Select(b => b.voucherNo).ToList().Select(decimal.Parse).ToList().Max();
            if (Convert.ToDecimal(strVoucherNo) != decJournalVoucherTypeIdmax+1)
                {
                    strVoucherNo = decJournalVoucherTypeIdmax.ToString();
                    strVoucherNo = VoucherNumberGeneration(decJournalVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpVoucherDate.Value, tableName);
                    if (decJournalVoucherTypeIdmax.ToString() == "0")
                    {
                        strVoucherNo = "0";
                        strVoucherNo = VoucherNumberGeneration(decJournalVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpVoucherDate.Value, tableName);
                    }
                }

                //===================================================================================================================//
                if (isAutomatic)
                {

                    SuffixPrefix sp = IME.SuffixPrefixes.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.fromDate < dtpVoucherDate.Value).Where(c => c.toDate > dtpVoucherDate.Value).FirstOrDefault();
                if (sp!=null)
                {
                    strPrefix = sp.prefix;
                    strSuffix = sp.suffix;
                    strInvoiceNo = strPrefix + strVoucherNo + strSuffix;
                    txtVoucherNo.Text = strInvoiceNo;
                    txtVoucherNo.ReadOnly = true;
                }
                    
                }
                else
                {
                    txtVoucherNo.ReadOnly = false;
                    txtVoucherNo.Text = string.Empty;
                    strInvoiceNo = txtVoucherNo.Text.Trim();
                }


                dgvJournalVoucher.Rows.Clear();
                VoucherDate();
                dtpVoucherDate.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
                txtDebitTotal.Text = string.Empty;
                txtCreditTotal.Text = string.Empty;
                txtNarration.Text = string.Empty;
                btnSave.Text = "Save";
                btnDelete.Enabled = false;
                isEditMode = false;
                dtblPartyBalance.Clear();//to clear party balance entries to clear the dgvpatybalance
                PrintCheck();
                if (!txtVoucherNo.ReadOnly)
                {
                    txtVoucherNo.Focus();
                }
                else
                {
                    txtDate.Select();
                }

        }


        //public void CallFromCurrenCyDetails(frmCurrencyDetails frmCurrencyDetails, decimal decId) //PopUp
        //{
        //        frmCurrencyObj.Close();
        //        CurrencyComboFill();
        //        decId = (decimal)IME.ExchangeRates.Where(a => a.currencyId == decId).OrderByDescending(b => b.date).FirstOrDefault().currencyId;
        //    dgvJournalVoucher.CurrentRow.Cells["dgvcmbCurrency"].Value = decId;
        //        dgvJournalVoucher.Focus();
        //}


        public void CallFromLedgerPopup(decimal decId, frmLedgerPopup frmLedgerPopUpObj) //PopUp
        {
            try
            {
                frmLedgerPopUpObj.Close();
                dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value = decId;
                dgvJournalVoucher.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("JV4:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void CallThisFormFromVoucherSearch(frmVoucherSearch frm, decimal decId)
        {
            // Function to call form voucher Search

            decJournalMasterIdForEdit = decId;
            isEditMode = true;
            btnDelete.Enabled = true;
            FillFunction();
        }

        /// <summary>
        /// Function to fill the currency combo box
        /// </summary>
        public void CurrencyComboFill()
        {
            List<Currency> CurrencyList = new List<Currency>();
            Currency c = new Currency();
            c.currencyName = "";
            CurrencyList.Add(c);
            CurrencyList.AddRange(IME.Currencies.ToList());
            dgvcmbCurrency.DataSource = CurrencyList;
            dgvcmbCurrency.DisplayMember = "currencyName";
            dgvcmbCurrency.ValueMember = "currencyID";

            if (IME.Settings.Where(a => a.settingsName == "MultiCurrency").FirstOrDefault().status == "Yes")
            {
                dgvcmbCurrency.ReadOnly = false;
            }
            else
            {
                dgvcmbCurrency.ReadOnly = true;

            }
        }

        /// <summary>
        /// Function to fill the account ledger
        /// </summary>
        public void AccountLedgerComboFill()
        {

                List<AccountLedger> AccountLedgerList = new List<AccountLedger>();
                AccountLedger AccountLedger = new AccountLedger();
                AccountLedger.ledgerName = "";
                AccountLedgerList.Add(AccountLedger);
                AccountLedgerList.AddRange(IME.AccountLedgers.ToList());
                dgvcmbAccountLedger.DataSource = AccountLedgerList;
                dgvcmbAccountLedger.ValueMember = "ledgerId";
                dgvcmbAccountLedger.DisplayMember = "ledgerName";

            
        }


        public void DrOrCrComboFill()
        {

                dgvcmbDrOrCr.Items.AddRange("Dr", "Cr");
            
        }


        //public void CallFromPartyBalance(frmPartyBalance frmPartyBalance, decimal decAmount, DataTable dtbl, ArrayList arrlstOfRemovedRow)
        //{
        //    try
        //    {
        //        dgvJournalVoucher.CurrentRow.Cells["dgvtxtAmount"].Value = decAmount.ToString();
        //        dgvJournalVoucher.CurrentRow.Cells["dgvcmbCurrency"].Value = Convert.ToDecimal(1);
        //        dgvJournalVoucher.CurrentRow.Cells["dgvcmbCurrency"].ReadOnly = true;
        //        this.frmPartyBalanceObj = frmPartyBalance;
        //        frmPartyBalance.Close();
        //        frmPartyBalanceObj = null;
        //        dtblPartyBalance = dtbl;
        //        arrlstOfDeletedPartyBalanceRow = arrlstOfRemovedRow;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("JV9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}


        public void CallFromJournalRegister(frmJournalRegister frmJournalObj, decimal decMasterId)
        {
                base.Show();
                journalRegisterObj = frmJournalObj;
                journalRegisterObj.Enabled = false;
                isEditMode = true;
                btnDelete.Enabled = true;
                decJournalMasterIdForEdit = decMasterId;
                FillFunction();
   
        }

        /// <summary>
        /// Function to generate serial number
        /// </summary>
        public void SlNo()
        {
            int inRowNo = 1;

                foreach (DataGridViewRow dr in dgvJournalVoucher.Rows)
                {
                    dr.Cells["dgvtxtSlNo"].Value = inRowNo;
                    inRowNo++;
                    if (dr.Index == dgvJournalVoucher.Rows.Count - 1)
                    {
                        break;
                    }
                }

        }

        /// <summary>
        /// Function to calculate total debit and credit
        /// </summary>
        public void DebitAndCreditTotal()
        {

            ExchangeRate spExchangeRate = new ExchangeRate();
            int inRowCount = dgvJournalVoucher.RowCount;
            decimal decTxtTotalDebit = 0;
            decimal decTxtTotalCredit = 0;
            for (int inI = 0; inI < inRowCount; inI++)
            {
                if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() != string.Empty)
                {
                    if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString() != string.Empty)
                    {
                        if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString() != string.Empty)
                        {
                            if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString() != ".")
                            {
                                if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
                                {

                                    //--------Currency conversion--------------//
                                    decimal currencyRateID = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                                    decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.currencyId == currencyRateID).OrderByDescending(b => b.date).FirstOrDefault().rate;
                                    decAmount = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                    decConvertRate = decAmount * decSelectedCurrencyRate;
                                    //===========================================//
                                    decTxtTotalDebit = decTxtTotalDebit + decConvertRate;


                                }
                                else
                                {
                                    //--------Currency conversion--------------//
                                    decimal currencyRateID = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                                    decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.currencyId == currencyRateID).OrderByDescending(b => b.date).FirstOrDefault().rate;
                                    decAmount = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                    decConvertRate = decAmount * decSelectedCurrencyRate;
                                    //===========================================//
                                    decTxtTotalCredit = decTxtTotalCredit + decConvertRate;
                                }
                            }
                        }
                    }
                }

                txtDebitTotal.Text = Math.Round(decTxtTotalDebit, 4).ToString();
                txtCreditTotal.Text = Math.Round(decTxtTotalCredit, 4).ToString();

            }



        }

        /// <summary>
        /// Function to call the save after checking invalid entries
        /// </summary>
        public void SaveFunction()
        {
            ArrayList arrlstOfRowToRemove = new ArrayList();
            int inReadyForSave = 0;
            int inIsRowToRemove = 0;
            int inIfGridColumnMissing = 0;


            if (txtVoucherNo.Text.Trim() != string.Empty)
            {
                if (!isEditMode)
                {
                    decimal decTotalDebit = 0;
                    decimal decTotalCredit = 0;

                    int inRowCount = dgvJournalVoucher.RowCount;
                    for (int inI = 0; inI < inRowCount - 1; inI++)
                    {
                        if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value == null || dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString().Trim() == string.Empty)
                        {
                            arrlstOfRowToRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                            inIfGridColumnMissing = 1;
                            continue;
                        }
                        else if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value == null || dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString().Trim() == string.Empty)
                        {
                            arrlstOfRowToRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                            inIfGridColumnMissing = 1;
                            continue;
                        }

                        else if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value == null || dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString().Trim() == string.Empty)
                        {
                            arrlstOfRowToRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                            inIfGridColumnMissing = 1;
                            continue;
                        }
                        else if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value == null || dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].FormattedValue.ToString() == string.Empty)
                        {
                            arrlstOfRowToRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                            inIfGridColumnMissing = 1;
                            continue;
                        }

                    }

                    //----------------------------------------------------------------------//
                    if (inIfGridColumnMissing == 0)
                    {
                        inReadyForSave = 1;
                        inIsRowToRemove = 0;

                    }
                    else
                    {
                        string strMsg = string.Empty;
                        int inK = 0;
                        foreach (object obj in arrlstOfRowToRemove)
                        {
                            if (inK != 0)
                            {
                                strMsg = strMsg + ", ";
                            }
                            string str = Convert.ToString(obj);
                            strMsg = strMsg + str;
                            inK++;
                        }
                        if (MessageBox.Show("Row " + strMsg + " Contains invalid entries.\n Do you want to continue ? ", "Open Miracle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            inReadyForSave = 1;
                            inIsRowToRemove = 1;
                        }
                        else
                            return;
                    }
                    //=====================================================================//

                    //-------------------------------------------------------------------//
                    if (inReadyForSave == 1)
                    {

                        int inTableRowCount = dtblPartyBalance.Rows.Count;
                        //-----------------If there are rows to remove---------------//
                        if (inIsRowToRemove == 1)
                        {
                            int inDgvJournalRowCount = dgvJournalVoucher.RowCount;
                            int inK = 0;
                            for (int inI = 0; inI < inDgvJournalRowCount; inI++)
                            {
                                if (inK == arrlstOfRowToRemove.Count)
                                {
                                    break;
                                }
                                if (inDgvJournalRowCount > 0)
                                {

                                    if (Convert.ToInt32(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString()) == Convert.ToInt32(arrlstOfRowToRemove[inK]))
                                    {
                                        inK++;
                                        if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString() != string.Empty)
                                        {
                                            arrlstOfRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString());
                                            arrlstOfRemovedLedgerPostingId.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value.ToString());
                                        }

                                        inTableRowCount = dtblPartyBalance.Rows.Count;
                                        for (int inJ = 0; inJ < inTableRowCount; inJ++)
                                        {
                                            if (dtblPartyBalance.Rows.Count == inJ)
                                            {
                                                break;
                                            }
                                            if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                                            {
                                                if (Convert.ToInt32(dtblPartyBalance.Rows[inJ]["LedgerId"].ToString()) == Convert.ToInt32(dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString()))
                                                {
                                                    if (dtblPartyBalance.Rows[inJ]["PartyBalanceId"].ToString() != "0")
                                                    {
                                                        arrlstOfDeletedPartyBalanceRow.Add(dtblPartyBalance.Rows[inI]["PartyBalanceId"]);
                                                    }
                                                    dtblPartyBalance.Rows.RemoveAt(inJ);
                                                    inJ--;
                                                }
                                            }
                                        }
                                        if (inUpdatingRowIndexForPartyRemove == inI)
                                        {
                                            inUpdatingRowIndexForPartyRemove = -1;
                                            decUpdatingLedgerForPartyremove = 0;
                                        }
                                        dgvJournalVoucher.Rows.Remove(dgvJournalVoucher.Rows[inI]);
                                        inDgvJournalRowCount = dgvJournalVoucher.RowCount;
                                        inI--;

                                    }
                                }
                            }
                            SlNo();

                        }

                        //============================================================//
                        int RowCount = dgvJournalVoucher.RowCount;
                        if (RowCount > 1)
                        {
                            decTotalDebit = Convert.ToDecimal(txtDebitTotal.Text.Trim());
                            decTotalCredit = Convert.ToDecimal(txtCreditTotal.Text.Trim());
                            if (decTotalCredit != 0 || decTotalDebit != 0)
                            {
                                if (decTotalDebit == decTotalCredit)
                                {

                                    Save();
                                    clear();


                                }
                                else
                                {
                                    MessageBox.Show("Total debit and total credit should be equal");
                                    dgvJournalVoucher.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cannot save total debit and credit as 0");

                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no row to save");
                        }

                    }

                }

            }
            else
            {
                MessageBox.Show("Enter voucherno.");
                txtVoucherNo.Focus();
            }

        }

        /// <summary>
        /// Function to Save the voucher
        /// </summary>
        public void Save()
        {

                decimal decTotalDebit = 0;
                decimal decTotalCredit = 0;

                decTotalDebit = Convert.ToDecimal(txtDebitTotal.Text.Trim());
                decTotalCredit = Convert.ToDecimal(txtCreditTotal.Text.Trim());


                JournalMaster JournalMaster = new JournalMaster();
                //JournalMasterSP spJournalMaster = new JournalMasterSP();
                //JournalDetailsSP spJournalDetails = new JournalDetailsSP();
                //JournalMasterInfo infoJournalMaster = new JournalMasterInfo();
                //JournalDetailsInfo infoJournalDetails = new JournalDetailsInfo();
                //PartyBalanceSP SpPartyBalance = new PartyBalanceSP();
                //PartyBalanceInfo InfopartyBalance = new PartyBalanceInfo();
                //ExchangeRateSP spExchangeRate = new ExchangeRateSP();

                JournalMaster.voucherNo = strVoucherNo;
                JournalMaster.invoiceNo = txtVoucherNo.Text;
                JournalMaster.suffixPrefixId = decJournalSuffixPrefixId;
                JournalMaster.date = Convert.ToDateTime(txtDate.Text);
                JournalMaster.narration = txtNarration.Text.Trim();
                JournalMaster.userId = Utils.getCurrentUser().WorkerID;
                JournalMaster.voucherTypeId = decJournalVoucherTypeId;
                JournalMaster.financialYearId = Convert.ToDecimal(Utils.getManagement().FinancialYear.financialYearId);
                JournalMaster.totalAmount = decTotalDebit;
                IME.JournalMasters.Add(JournalMaster);

                decimal decJournalMasterId = JournalMaster.journalMasterId;
                JournalDetail JournalDetail = new JournalDetail();
                /*******************JournalDetailsAdd and LedgerPosting*************************/
                JournalDetail.journalMasterId = decJournalMasterId;



                decimal decLedgerId = 0;
                decimal decDebit = 0;
                decimal decCredit = 0;
                int inRowCount = dgvJournalVoucher.RowCount;
                for (int inI = 0; inI < inRowCount - 1; inI++)
                {
                    if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {
                        JournalDetail.ledgerId = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString());
                        decLedgerId = (decimal)JournalDetail.ledgerId;
                    }
                    if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() != string.Empty)
                    {
                        if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString() != string.Empty)
                        {
                            //--------Currency conversion--------------//
                            decimal exchangeRateID = decimal.Parse(dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                            decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == exchangeRateID).FirstOrDefault().rate;
                            decAmount = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                            decConvertRate = decAmount * decSelectedCurrencyRate;
                            //===========================================//
                            if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
                            {
                                JournalDetail.debit = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                JournalDetail.credit = 0;
                                decDebit = decConvertRate;
                                decCredit = (decimal)JournalDetail.credit;
                            }
                            else
                            {
                                JournalDetail.credit = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                JournalDetail.debit = 0;
                                decDebit = (decimal)JournalDetail.debit;
                                decCredit = decConvertRate;
                            }
                        }
                        JournalDetail.exchangeRateId = Convert.ToInt32(dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                        if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                        {
                            JournalDetail.chequeNo = dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString();
                        }
                        else
                        {
                            JournalDetail.chequeNo = string.Empty;
                        }
                        if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            JournalDetail.chequeDate = Convert.ToDateTime(dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                        {
                            JournalDetail.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());
                        }
                        IME.JournalDetails.Add(JournalDetail);
                        decimal decJournalDetailsId = JournalDetail.journalDetailsId;
                        if (decJournalDetailsId != 0)
                        {
                            PartyBalanceAddOrEdit(inI);
                            LedgerPosting(decLedgerId, decCredit, decDebit, decJournalDetailsId, inI);
                        }
                    }

                }

                MessageBox.Show("Saved successfully");

                //----------------If print after save is enable-----------------------//
                //if (cbxPrintAfterSave.Checked)
                //{
                //    if (spSettings.SettingsStatusCheck("Printer") == "Dot Matrix")
                //    {
                //        PrintForDotMatrix(decJournalMasterId);
                //    }
                //    else
                //    {
                //        Print(decJournalMasterId);
                //    }
                //}

                //===================================================================//
   
        }

        /// <summary>
        /// Function to call the Edit after checking invalid entries
        /// </summary>
        /// <param name="decJournalMasterId"></param>
        public void EditFunction(decimal decJournalMasterId)
        {
                ArrayList arrlstOfRowToRemove = new ArrayList();
                int inReadyForSave = 0;
                int inIsRowToRemove = 0;
                int inIfGridColumnMissing = 0;

                decimal decTotalDebit = 0;
                decimal decTotalCredit = 0;

                int inRowCount = dgvJournalVoucher.RowCount;
                for (int inI = 0; inI < inRowCount - 1; inI++)
                {
                    if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value == null || dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString().Trim() == string.Empty)
                    {
                        arrlstOfRowToRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                        inIfGridColumnMissing = 1;
                        continue;
                    }
                    else if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value == null || dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString().Trim() == string.Empty)
                    {
                        arrlstOfRowToRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                        inIfGridColumnMissing = 1;
                        continue;
                    }

                    else if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value == null || dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString().Trim() == string.Empty)
                    {
                        arrlstOfRowToRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                        inIfGridColumnMissing = 1;
                        continue;
                    }
                    else if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value == null || dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString().Trim() == string.Empty)
                    {
                        arrlstOfRowToRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                        inIfGridColumnMissing = 1;
                        continue;
                    }

                }
                //----------------------------------------------------------------------//
                if (inIfGridColumnMissing == 0)
                {
                    inReadyForSave = 1;
                    inIsRowToRemove = 0;

                }
                else
                {
                    string strMsg = string.Empty;
                    int inK = 0;

                    foreach (object obj in arrlstOfRowToRemove)
                    {
                        if (inK != 0)
                        {
                            strMsg = strMsg + ", ";
                        }
                        string str = Convert.ToString(obj);
                        strMsg = strMsg + str;
                        inK++;
                    }
                    if (MessageBox.Show("Row " + strMsg + " Contains invalid entries.\n Do you want to continue ? ", "Open Miracle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        inReadyForSave = 1;
                        inIsRowToRemove = 1;
                    }
                    else
                        inReadyForSave = 0;
                }
                //=====================================================================//

                if (inReadyForSave == 1)
                {
                    int inTableRowCount = dtblPartyBalance.Rows.Count;
                    //-----------------If there are rows to remove---------------//
                    if (inIsRowToRemove == 1)
                    {
                        int inDgvJournalRowCount = dgvJournalVoucher.RowCount;
                        int inK = 0;
                        for (int inI = 0; inI < inDgvJournalRowCount; inI++)
                        {
                            if (inK == arrlstOfRowToRemove.Count)
                            {
                                break;
                            }
                            if (inDgvJournalRowCount > 0)
                            {

                                if (Convert.ToInt32(dgvJournalVoucher.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString()) == Convert.ToInt32(arrlstOfRowToRemove[inK]))
                                {
                                    inK++;
                                    if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString() != string.Empty)
                                    {
                                        arrlstOfRemove.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString());
                                        arrlstOfRemovedLedgerPostingId.Add(dgvJournalVoucher.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value.ToString());
                                    }

                                    inTableRowCount = dtblPartyBalance.Rows.Count;
                                    for (int inJ = 0; inJ < inTableRowCount; inJ++)
                                    {
                                        if (dtblPartyBalance.Rows.Count == inJ)
                                        {
                                            break;
                                        }
                                        if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                                        {
                                            if (dtblPartyBalance.Rows[inJ]["LedgerId"].ToString() == dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString())
                                            {
                                                if (dtblPartyBalance.Rows[inI]["PartyBalanceId"].ToString() != "0")
                                                {
                                                    arrlstOfDeletedPartyBalanceRow.Add(dtblPartyBalance.Rows[inI]["PartyBalanceId"]);
                                                }
                                                dtblPartyBalance.Rows.RemoveAt(inJ);
                                                inJ--;
                                            }
                                        }
                                    }
                                    if (inUpdatingRowIndexForPartyRemove == inI)
                                    {
                                        inUpdatingRowIndexForPartyRemove = -1;
                                        decUpdatingLedgerForPartyremove = 0;
                                    }
                                    dgvJournalVoucher.Rows.RemoveAt(dgvJournalVoucher.Rows[inI].Index);
                                    inDgvJournalRowCount = dgvJournalVoucher.RowCount;
                                    inI--;
                                }
                            }
                        }
                        SlNo();
                    }
                    //============================================================//
                    inRowCount = dgvJournalVoucher.RowCount;
                    if (inRowCount > 1)
                    {
                        decTotalDebit = Convert.ToDecimal(txtDebitTotal.Text.Trim());
                        decTotalCredit = Convert.ToDecimal(txtCreditTotal.Text.Trim());
                        if (decTotalDebit != 0 && decTotalCredit != 0)
                        {
                            if (decTotalDebit == decTotalCredit)
                            {

                                DeletePartyBalanceOfRemovedRow();
                                Edit(decJournalMasterId);


                            }
                            else
                            {
                                MessageBox.Show("Total debit and total credit should be equal");
                                dgvJournalVoucher.Focus();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot save total debit and credit as 0");
                            dgvJournalVoucher.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no row to save");
                    }
                }


        }

        /// <summary>
        /// Function to edit the debitnote voucher
        /// </summary>
        /// <param name="decJournalMasterId"></param>
        public void Edit(decimal decJournalMasterId)
        {


                JournalMaster JournalMaster = IME.JournalMasters.Where(a => a.journalMasterId == decJournalMasterId).FirstOrDefault();

                /*****************Update in JournalMaster table *************/

                decimal decTotalDebit = 0;
                decimal decTotalCredit = 0;

                JournalMaster.voucherNo = strVoucherNo;
                JournalMaster.invoiceNo = txtVoucherNo.Text.Trim();
                JournalMaster.suffixPrefixId = decJournalSuffixPrefixId;
                JournalMaster.date = Convert.ToDateTime(txtDate.Text);
                JournalMaster.narration = txtNarration.Text.Trim();
                JournalMaster.userId = Utils.getCurrentUser().WorkerID;
                JournalMaster.voucherTypeId = decJournalVoucherTypeId;
                JournalMaster.financialYearId = Convert.ToDecimal(Utils.getManagement().FinancialYear.financialYearId);



                decTotalDebit = Convert.ToDecimal(txtDebitTotal.Text.Trim());
                decTotalCredit = Convert.ToDecimal(txtCreditTotal.Text.Trim());

                JournalMaster.totalAmount = decTotalDebit;
                IME.SaveChanges();


                /**********************JournalDetails Edit********************/



                //-----------to delete details, LedgerPosting and bankReconciliation of removed rows--------------// 

                foreach (object obj in arrlstOfRemove)
                {
                    string str = Convert.ToString(obj);
                    IME.JournalDetails.RemoveRange(IME.JournalDetails.Where(a=>a.journalDetailsId== Convert.ToDecimal(str)));
                    decimal ledgerPostingId=-1;
                    if(IME.LedgerPostings.Where(a => a.voucherNo == strVoucherNo).Where(b=>b.voucherTypeId== decJournalVoucherTypeId).FirstOrDefault()!=null)
                    {
                        ledgerPostingId=IME.LedgerPostings.Where(a => a.voucherNo == strVoucherNo).Where(b => b.voucherTypeId == decJournalVoucherTypeId).FirstOrDefault().ledgerPostingId;
                    }
                    IME.LedgerPostings.RemoveRange(IME.LedgerPostings.Where(a => a.voucherNo == strVoucherNo).Where(b => b.voucherTypeId == decJournalVoucherTypeId).Where(c => c.detailsId == Convert.ToDecimal(str)).ToList());
                    if(ledgerPostingId!=-1) IME.BankReconciliations.RemoveRange(IME.BankReconciliations
                        .Where(a=>a.ledgerPostingId==(decimal)ledgerPostingId).ToList());
                    //spLedgerPosting.LedgerPostDeleteByDetailsId(Convert.ToDecimal(str), strVoucherNo, decJournalVoucherTypeId);
                }
                if(IME.LedgerPostings.Where(a=>a.voucherNo== strVoucherNo).Where(b=>b.voucherTypeId== decJournalVoucherTypeId).Where(c=>c.AccountLedger.ledgerName== "Forex Gain/Loss").FirstOrDefault() != null)
                {
                    IME.LedgerPostings.Remove(IME.LedgerPostings.Where(a => a.voucherNo == strVoucherNo).Where(b => b.voucherTypeId == decJournalVoucherTypeId).Where(c => c.AccountLedger.ledgerName == "Forex Gain/Loss").FirstOrDefault());
                }
                //=============================================================================================//

                decimal decLedgerId = 0;
                decimal decDebit = 0;
                decimal decCredit = 0;
                decimal decJournalDetailsId = 0;
                int inRowCount = dgvJournalVoucher.RowCount;
                for (int inI = 0; inI < inRowCount; inI++)
                {
                    //JournalDetail JournalDetail = new JournalDetail();
                    
                    decimal journaldetailID = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString());
                    JournalDetail JournalDetail = IME.JournalDetails.Where(a => a.journalDetailsId == journaldetailID).FirstOrDefault();
                    JournalDetail.journalMasterId = decJournalMasterId;
                    if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {
                        decLedgerId = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString());
                        JournalDetail.ledgerId = decLedgerId;
                    }
                    if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() != string.Empty)
                    {
                        //------------------Currency conversion------------------//
                        decimal SelectedCurrencyRate = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value);
                        decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == SelectedCurrencyRate).FirstOrDefault().rate;
                        decAmount = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                        decConvertRate = decAmount * decSelectedCurrencyRate;
                        //======================================================//

                        if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
                        {
                            JournalDetail.debit= Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                            JournalDetail.credit = 0;

                            decDebit = decConvertRate;
                            decCredit = (decimal)JournalDetail.credit;
                        }
                        else
                        {
                            JournalDetail.credit = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                            JournalDetail.debit = 0;
                            decDebit = (decimal)JournalDetail.debit;
                            decCredit = decConvertRate;
                        }
                        JournalDetail.exchangeRateId = Convert.ToInt32(dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                        if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                        {
                            JournalDetail.chequeNo = dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString();
                        }
                        else
                        {
                            JournalDetail.chequeNo = string.Empty;
                        }
                        if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            JournalDetail.chequeDate = Convert.ToDateTime(dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                        {
                            JournalDetail.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());
                        }
                        if (dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString() != string.Empty)
                        {


                            IME.SaveChanges();
                            PartyBalanceAddOrEdit(inI);
                            decJournalDetailsId = JournalDetail.journalDetailsId;
                            decimal decLedgerPostId = Convert.ToDecimal(dgvJournalVoucher.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value.ToString());
                            LedgerPostingEdit(decLedgerPostId, decLedgerId, decCredit, decDebit, decJournalDetailsId, inI);

                        }
                        else
                        {
                            IME.JournalDetails.Add(JournalDetail);
                            IME.SaveChanges();
                            PartyBalanceAddOrEdit(inI);
                            LedgerPosting(decLedgerId, decCredit, decDebit, decJournalDetailsId, inI);
                        }

                    }

                }
                DeletePartyBalanceOfRemovedRow();
                MessageBox.Show("Updated successfully");
            //if (cbxPrintAfterSave.Checked)
            //{
            //    if (spSettings.SettingsStatusCheck("Printer") == "Dot Matrix")
            //    {
            //        PrintForDotMatrix(infoJournalMaster.JournalMasterId);
            //    }
            //    else
            //    {
            //        Print(infoJournalMaster.JournalMasterId);
            //    }
            //}
            if (journalRegisterObj != null)
            {
                this.Close();
                journalRegisterObj.Enabled = true;
            }
            else if (frmJournalReportObj != null)
            {
                this.Close();
                frmJournalReportObj.Enabled = true;
            }
            //else if (frmDayBookObj != null)
            //{
            //    this.Close();

            //}
            else if (frmBillallocationObj != null)
            {
                this.Close();

            }

        }

        /// <summary>
        /// Function to determine whether to call SaveFunction or EditFunction function 
        /// </summary>
        public void SaveOrEditFunction()
        {

                if (!isEditMode)
                {

                    if (txtVoucherNo.Text != string.Empty)
                    {

                        if (!isAutomatic)
                        {
                            strInvoiceNo = txtVoucherNo.Text.Trim();

                            if (IME.JournalMasters.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.invoiceNo == strInvoiceNo).FirstOrDefault() == null)
                            {
                                SaveFunction();
                            }
                            else
                            {
                                MessageBox.Show("Voucher number already exist");
                            }
                        }
                        else
                        {
                            SaveFunction();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter voucherNo");
                        txtVoucherNo.Focus();
                    }
                }
                else
                {
                    if (txtVoucherNo.Text != string.Empty)
                    {
                        if (!isAutomatic)
                        {
                            strInvoiceNo = txtVoucherNo.Text.Trim();
                            if(IME.JournalMasters.Where(a=>a.voucherTypeId== decJournalVoucherTypeId).Where(b=>b.invoiceNo== strInvoiceNo).Where(c=>c.journalMasterId== decJournalMasterIdForEdit).Select(e => e.invoiceNo).Distinct().Count() <= 0)
                            {

                                EditFunction(decJournalMasterIdForEdit);
                            }
                            else
                            {
                                MessageBox.Show("Voucher number already exist");
                            }
                        }
                        else
                        {
                            EditFunction(decJournalMasterIdForEdit);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter voucherNo");
                    }
                }

            
        }


        public void SaveOrEdit()
        {

            //=====================================================
            string strStatus = IME.Settings.Where(a => a.settingsName == "NegativeCashTransaction").FirstOrDefault().status;
            decimal decBalance = 0;
            decimal decCalcAmount = 0;
            List<LedgerPosting> LedgerPostingList = new List<DataSet.LedgerPosting>();
            bool isNegativeLedger = false;
            int inRowCount = dgvJournalVoucher.RowCount;
            for (int i = 0; i < inRowCount - 1; i++)
            {
                decimal decledgerId = 0;
                if (dgvJournalVoucher.Rows[i].Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.Rows[i].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                {
                    decledgerId = Convert.ToDecimal(dgvJournalVoucher.Rows[i].Cells["dgvcmbAccountLedger"].Value.ToString());
                    LedgerPostingList = IME.LedgerPostings.Where(a => a.ledgerId == decledgerId).ToList();
                    foreach (var item in LedgerPostingList)
                    {
                        decBalance = decBalance + ((decimal)item.debit - (decimal)item.credit);
                    }

                    if (dgvJournalVoucher.Rows[i].Cells["dgvtxtAmount"].Value != null && dgvJournalVoucher.Rows[i].Cells["dgvtxtAmount"].Value.ToString() != string.Empty)
                    {
                        decCalcAmount = decBalance - Convert.ToDecimal(dgvJournalVoucher.Rows[i].Cells["dgvtxtAmount"].Value.ToString());
                    }
                    if (decCalcAmount < 0)
                    {
                        isNegativeLedger = true;
                        break;
                    }
                }
            }
            //=========================================
            if (isNegativeLedger)
            {

                if (strStatus == "Warn")
                {
                    if (MessageBox.Show("Negative balance exists,Do you want to Continue", "Open miracle", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SaveOrEditFunction();
                    }
                }
                else if (strStatus == "Block")
                {
                    MessageBox.Show("Cannot continue ,due to negative balance", "Open miracle", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    SaveOrEditFunction();
                }
            }
            else
            {
                SaveOrEditFunction();
            }


        }


        public void DeleteFunction(decimal decJournalMasterId)
        {


                if (IME.PartyBalances.Where(a => a.voucherNo == strVoucherNo).Where(b => b.voucherTypeId == decJournalVoucherTypeId).Where(c => c.againstVoucherTypeId != 0).Where(d => d.againstVoucherNo != "0").Select(e => e.partyBalanceId).Distinct().Count() <= 0)
                {
                    var PartyBalances1 = IME.PartyBalances.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.voucherNo == strVoucherNo).Where(c => c.referenceType == "new").FirstOrDefault();
                    var PartyBalances2 = IME.PartyBalances.Where(a => a.againstVoucherTypeId == decJournalVoucherTypeId).Where(b => b.againstVoucherNo == strVoucherNo).Where(c => c.referenceType == "Against").FirstOrDefault();
                    var PartyBalances3 = IME.PartyBalances.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.voucherNo == strVoucherNo).Where(c => c.referenceType == "OnAccount").FirstOrDefault();

                    if (PartyBalances1 != null)
                    {
                        IME.PartyBalances.Remove(PartyBalances1);
                    }else if(PartyBalances2!=null)
                    {
                        IME.PartyBalances.Remove(PartyBalances2);

                    }else if (PartyBalances3 != null)
                    {
                        IME.PartyBalances.Remove(PartyBalances3);
                    }
                    if(PartyBalances1!=null || PartyBalances2!=null || PartyBalances3 != null)
                    {

                        //delete from tbl_BankReconciliation where ledgerPostingId IN (select ledgerPostingId from tbl_LedgerPosting 
                        //															where voucherTypeId=@voucherTypeId and voucherNo=@voucherNo)
                        var ledgerPostingIdList = IME.LedgerPostings.Where(a => a.voucherTypeId == decJournalVoucherTypeId).ToList();
                        foreach (var item in ledgerPostingIdList)
                        {
                            IME.BankReconciliations.RemoveRange(IME.BankReconciliations.Where(a => a.ledgerPostingId == item.ledgerPostingId));
                        }
                        IME.LedgerPostings.RemoveRange(IME.LedgerPostings.Where(a => a.voucherTypeId == decJournalVoucherTypeId).ToList());
                        IME.JournalDetails.RemoveRange(IME.JournalDetails.Where(a => a.journalMasterId == decJournalMasterId).ToList());
                        IME.JournalMasters.RemoveRange(IME.JournalMasters.Where(a => a.journalMasterId == decJournalMasterId).ToList());
                    }
                    MessageBox.Show("Deleted successfully ");


                }
                else
                {
                    MessageBox.Show("Reference exist. Cannot delete");
                    txtDate.Focus();
                }


        }


        public void LedgerPosting(decimal decId, decimal decCredit, decimal decDebit, decimal decDetailsId, int inA)
        {

            LedgerPosting LedgerPosting = new LedgerPosting();
            decimal decOldExchange = 0;
            decimal decNewExchangeRate = 0;
            decimal decNewExchangeRateId = 0;
            decimal decOldExchangeId = 0;

                if (!dgvJournalVoucher.Rows[inA].Cells["dgvtxtAmount"].ReadOnly)
                {

                    LedgerPosting.date = Convert.ToDateTime(IME.CurrentDate().First());
                    LedgerPosting.voucherTypeId = decJournalVoucherTypeId;
                    LedgerPosting.voucherNo = strVoucherNo;
                    LedgerPosting.detailsId = decDetailsId;
                    LedgerPosting.yearId = Utils.getManagement().CurrentFinancialYear;
                    LedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();

                    if (dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        LedgerPosting.chequeNo = dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            LedgerPosting.chequeDate = Convert.ToDateTime(dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            LedgerPosting.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());

                    }
                    else
                    {
                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());
                    }


                    LedgerPosting.ledgerId = decId;
                    LedgerPosting.credit = decCredit;
                    LedgerPosting.debit = decDebit;
                    IME.LedgerPostings.Add(LedgerPosting);
                }
                else
                {
                    LedgerPosting.date = Convert.ToDateTime(IME.CurrentDate().First());
                    LedgerPosting.voucherTypeId = decJournalVoucherTypeId;
                    LedgerPosting.voucherNo = strVoucherNo;
                    LedgerPosting.detailsId = decDetailsId;
                    LedgerPosting.yearId = Utils.getManagement().CurrentFinancialYear;
                    LedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();

                    if (dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        LedgerPosting.chequeNo = dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            LedgerPosting.chequeDate = Convert.ToDateTime(dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            LedgerPosting.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());

                    }
                    else
                    {
                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());
                    }



                    LedgerPosting.ledgerId = decId;

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

                    if (decCredit == 0)
                    {
                        LedgerPosting.credit = 0;
                        LedgerPosting.debit = decConvertRate;
                    }
                    else
                    {
                        LedgerPosting.debit = 0;
                        LedgerPosting.credit = decConvertRate;
                    }
                    IME.LedgerPostings.Add(LedgerPosting);
                     LedgerPosting.ledgerId = 12;
                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (Convert.ToDecimal(dgvJournalVoucher.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString()) == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            if (dr["ReferenceType"].ToString() == "Against")
                            {
                                decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());

                                decNewExchangeRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decNewExchangeRateId).FirstOrDefault().rate;
                                decOldExchangeId = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                                decOldExchange = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decOldExchangeId).FirstOrDefault().rate;
                                decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                                decimal decForexAmount = (decAmount * decNewExchangeRate) - (decAmount * decOldExchange);
                                if (dr["DebitOrCredit"].ToString() == "Dr")
                                {
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
                                }
                                else
                                {
                                    if (decForexAmount >= 0)
                                    {

                                        LedgerPosting.credit = decForexAmount;
                                        LedgerPosting.debit = 0;
                                    }
                                    else
                                    {
                                        LedgerPosting.debit = -1 * decForexAmount;
                                        LedgerPosting.credit = 0;
                                    }
                                }
                                IME.LedgerPostings.Add(LedgerPosting);
                                IME.SaveChanges();
                            }
                        }

                    }
                }
            }

        /// <summary>
        /// Function For ledger posting edit
        /// </summary>
        /// <param name="decLedgerPostingId"></param>
        /// <param name="decLedgerId"></param>
        /// <param name="decCredit"></param>
        /// <param name="decDebit"></param>
        /// <param name="decDetailsId"></param>
        /// <param name="inA"></param>
        public void LedgerPostingEdit(decimal decLedgerPostingId, decimal decLedgerId, decimal decCredit, decimal decDebit, decimal decDetailsId, int inA)
        {
            

            //LedgerPostingSP spLedgerPosting = new LedgerPostingSP();
            // infoLedgerPosting = new LedgerPostingInfo();
            //ExchangeRateSP SpExchangRate = new ExchangeRateSP();
            decimal decOldExchange = 0;
            decimal decNewExchangeRate = 0;
            decimal decNewExchangeRateId = 0;
            decimal decOldExchangeId = 0;
                if (!dgvJournalVoucher.Rows[inA].Cells["dgvtxtAmount"].ReadOnly)
                {
                    LedgerPosting LedgerPosting = IME.LedgerPostings.Where(a => a.ledgerPostingId == decLedgerPostingId).FirstOrDefault();
                    LedgerPosting.date = Convert.ToDateTime(IME.CurrentDate().First());
                    LedgerPosting.voucherTypeId = decJournalVoucherTypeId;
                    LedgerPosting.voucherNo = strVoucherNo;
                    LedgerPosting.detailsId = decDetailsId;
                    LedgerPosting.yearId = Utils.getManagement().CurrentFinancialYear;
                    LedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();

                    if (dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        LedgerPosting.chequeNo = dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            LedgerPosting.chequeDate = Convert.ToDateTime(dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            LedgerPosting.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());

                    }
                    else
                    {
                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());
                    }


                    LedgerPosting.ledgerId = decLedgerId;
                    LedgerPosting.credit = decCredit;
                    LedgerPosting.debit = decDebit;


                    IME.SaveChanges();
                }
                else
                {
                    LedgerPosting LedgerPosting = new LedgerPosting();
                    LedgerPosting.ledgerPostingId = decLedgerPostingId;
                    LedgerPosting.date = Convert.ToDateTime(IME.CurrentDate().First());
                    LedgerPosting.voucherTypeId = decJournalVoucherTypeId;
                    LedgerPosting.voucherNo = strVoucherNo;
                    LedgerPosting.detailsId = decDetailsId;
                    LedgerPosting.yearId = Utils.getManagement().CurrentFinancialYear;
                    LedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();

                    if (dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        LedgerPosting.chequeNo = dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            LedgerPosting.chequeDate = Convert.ToDateTime(dgvJournalVoucher.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            LedgerPosting.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());

                    }
                    else
                    {
                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = Convert.ToDateTime(IME.CurrentDate().First());
                    }

                    LedgerPosting.ledgerId = decLedgerId;


                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (LedgerPosting.ledgerId == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            decOldExchange = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                            decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                            decSelectedCurrencyRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decNewExchangeRateId).FirstOrDefault().rate;
                            decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                            decConvertRate = decConvertRate + (decAmount * decSelectedCurrencyRate);

                        }
                    }

                    if (decCredit == 0)
                    {
                        LedgerPosting.credit = 0;
                        LedgerPosting.debit = decConvertRate;
                    }
                    else
                    {
                        LedgerPosting.debit = 0;
                        LedgerPosting.credit = decConvertRate;
                    }

                    IME.SaveChanges();

                    LedgerPosting.ledgerId = 12;
                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (Convert.ToDecimal(dgvJournalVoucher.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString()) == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            if (dr["ReferenceType"].ToString() == "Against")
                            {
                                LedgerPosting = new LedgerPosting();
                                   decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                                decNewExchangeRate = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decNewExchangeRateId).FirstOrDefault().rate;
                                decOldExchangeId = Convert.ToDecimal(dr["OldExchangeRate"].ToString()); 
                                 decOldExchange = (decimal)IME.ExchangeRates.Where(a => a.exchangeRateID == decOldExchangeId).FirstOrDefault().rate;
                                decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                                decimal decForexAmount = (decAmount * decNewExchangeRate) - (decAmount * decOldExchange);
                                if (dr["DebitOrCredit"].ToString() == "Dr")
                                {
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
                                }
                                else
                                {
                                    if (decForexAmount >= 0)
                                    {

                                        LedgerPosting.credit = decForexAmount;
                                        LedgerPosting.debit = 0;
                                    }
                                    else
                                    {
                                        LedgerPosting.debit = -1 * decForexAmount;
                                        LedgerPosting.credit = 0;
                                    }
                                }
                                IME.LedgerPostings.Add(LedgerPosting);
                            }
                        }

                    }

                }


        }

        /// <summary>
        /// Function to save partybalance
        /// </summary>
        /// <param name="inRowIndex"></param>
        /// <param name="inJ"></param>
        public void PartyBalanceAdd(int inRowIndex, int inJ)
        {
            int inTableRowCount = dtblPartyBalance.Rows.Count;
            PartyBalance PartyBalance = new PartyBalance();

            PartyBalance.creditPeriod = 0;//
            PartyBalance.date = dtpVoucherDate.Value;
            PartyBalance.ledgerId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["LedgerId"].ToString());
            PartyBalance.referenceType = dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString();
            if (dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "New" || dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "OnAccount")
            {
                PartyBalance.againstInvoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
                PartyBalance.againstVoucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                PartyBalance.againstVoucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());//decPaymentVoucherTypeId;
                PartyBalance.voucherTypeId = decJournalVoucherTypeId;
                PartyBalance.invoiceNo = strInvoiceNo;
                PartyBalance.voucherNo = strVoucherNo;
            }
            else
            {
                PartyBalance.exchangeRateId = Convert.ToInt32(dtblPartyBalance.Rows[inJ]["OldExchangeRate"].ToString());
                PartyBalance.againstInvoiceNo = strInvoiceNo;
                PartyBalance.againstVoucherNo = strVoucherNo;
                PartyBalance.againstVoucherTypeId = decJournalVoucherTypeId;
                PartyBalance.voucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());
                PartyBalance.voucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                PartyBalance.invoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
            }
            if (dgvJournalVoucher.Rows[inRowIndex].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
            {
                PartyBalance.debit = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["Amount"].ToString());
                PartyBalance.credit = 0;
            }
            else
            {
                PartyBalance.credit = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["Amount"].ToString());
                PartyBalance.debit = 0;
            }
            PartyBalance.exchangeRateId = Convert.ToInt32(dtblPartyBalance.Rows[inJ]["CurrencyId"].ToString());
            PartyBalance.financialYearId = Utils.getManagement().CurrentFinancialYear;
            IME.PartyBalances.Add(PartyBalance);
            IME.SaveChanges();



        }

        /// <summary>
        /// Function to edit the partybalance
        /// </summary>
        /// <param name="decPartyBalanceId"></param>
        /// <param name="inRowIndex"></param>
        /// <param name="inJ"></param>
        public void PartyBalanceEdit(decimal decPartyBalanceId, int inRowIndex, int inJ)
        {

            //PartyBalanceSP spPartyBalance = new PartyBalanceSP();
            //PartyBalanceInfo InfopartyBalance = new PartyBalanceInfo();
            PartyBalance PartyBalance = IME.PartyBalances.Where(a => a.partyBalanceId == decPartyBalanceId).FirstOrDefault();

            PartyBalance.partyBalanceId = decPartyBalanceId;
            PartyBalance.creditPeriod = 0;//
            PartyBalance.date = dtpVoucherDate.Value;
            PartyBalance.ledgerId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["LedgerId"].ToString());
            PartyBalance.referenceType = dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString();
            if (dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "New" || dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "OnAccount")
            {
                PartyBalance.againstInvoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
                PartyBalance.againstVoucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                PartyBalance.againstVoucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());//decPaymentVoucherTypeId;
                PartyBalance.voucherTypeId = decJournalVoucherTypeId;
                PartyBalance.invoiceNo = strInvoiceNo;
                PartyBalance.voucherNo = strVoucherNo;
            }
            else
            {
                PartyBalance.exchangeRateId = Convert.ToInt32(dtblPartyBalance.Rows[inJ]["OldExchangeRate"].ToString());
                PartyBalance.againstInvoiceNo = strInvoiceNo;
                PartyBalance.againstVoucherNo = strVoucherNo;
                PartyBalance.againstVoucherTypeId = decJournalVoucherTypeId;
                PartyBalance.voucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());
                PartyBalance.voucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                PartyBalance.invoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
            }
            if (dgvJournalVoucher.Rows[inRowIndex].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
            {
                PartyBalance.debit = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["Amount"].ToString());
                PartyBalance.credit = 0;
            }
            else
            {
                PartyBalance.credit = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["Amount"].ToString());
                PartyBalance.debit = 0;
            }
            PartyBalance.exchangeRateId = Convert.ToInt32(dtblPartyBalance.Rows[inJ]["CurrencyId"].ToString());
            PartyBalance.financialYearId = Utils.getManagement().CurrentFinancialYear;
            IME.SaveChanges();

        }

        /// <summary>
        /// Function to call partybalance add or edit
        /// </summary>
        /// <param name="inRowIndex"></param>
        public void PartyBalanceAddOrEdit(int inRowIndex)
        {
            int inTableRowCount = dtblPartyBalance.Rows.Count;


                for (int inJ = 0; inJ < inTableRowCount; inJ++)
                {
                    if (dgvJournalVoucher.Rows[inRowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() == dtblPartyBalance.Rows[inJ]["LedgerId"].ToString())
                    {
                        if (dtblPartyBalance.Rows[inJ]["PartyBalanceId"].ToString() == "0")
                        {
                            PartyBalanceAdd(inRowIndex, inJ);
                        }
                        else
                        {
                            decimal decPartyBalanceId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["partyBalanceId"]);
                            PartyBalanceEdit(decPartyBalanceId, inRowIndex, inJ);
                        }
                    }
                }


        }

        /// <summary>
        /// Function to check invalid entries
        /// </summary>
        /// <param name="e"></param>
        public void CheckColumnMissing(DataGridViewCellEventArgs e)
        {
                if (dgvJournalVoucher.CurrentRow != null)
                {
                    if (!isValueChanged)
                    {
                        if (dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value == null || dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvJournalVoucher.CurrentRow.HeaderCell.Value = "X";
                            dgvJournalVoucher.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;
                        }
                        else if (dgvJournalVoucher.CurrentRow.Cells["dgvcmbDrOrCr"].Value == null || dgvJournalVoucher.CurrentRow.Cells["dgvcmbDrOrCr"].Value.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvJournalVoucher.CurrentRow.HeaderCell.Value = "X";
                            dgvJournalVoucher.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;
                        }
                        else if (dgvJournalVoucher.CurrentRow.Cells["dgvtxtAmount"].Value == null || dgvJournalVoucher.CurrentRow.Cells["dgvtxtAmount"].Value.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvJournalVoucher.CurrentRow.HeaderCell.Value = "X";
                            dgvJournalVoucher.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;

                        }
                        else if (dgvJournalVoucher.CurrentRow.Cells["dgvcmbCurrency"].Value == null || dgvJournalVoucher.CurrentRow.Cells["dgvcmbCurrency"].FormattedValue.ToString() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvJournalVoucher.CurrentRow.HeaderCell.Value = "X";
                            dgvJournalVoucher.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;

                        }

                        else
                        {
                            isValueChanged = true;
                            dgvJournalVoucher.CurrentRow.HeaderCell.Value = string.Empty;
                        }

                    }
                    isValueChanged = false;
                }

        }

        /// <summary>
        /// Function to remove row
        /// </summary>
        public void RemoveRow()
        {
                int inRowCount = dgvJournalVoucher.RowCount;
                if (inRowCount > 1)
                {
                    if (int.Parse(dgvJournalVoucher.CurrentRow.Cells["dgvtxtSlNo"].Value.ToString()) < inRowCount)
                    {
                        if (dgvJournalVoucher.CurrentRow.Cells["dgvtxtDetailsId"].Value != null && dgvJournalVoucher.CurrentRow.Cells["dgvtxtDetailsId"].Value.ToString() != string.Empty)
                        {
                            arrlstOfRemove.Add(dgvJournalVoucher.CurrentRow.Cells["dgvtxtDetailsId"].Value.ToString());
                            arrlstOfRemovedLedgerPostingId.Add(dgvJournalVoucher.CurrentRow.Cells["dgvtxtLedgerPostingId"].Value.ToString());
                            inArrOfRemove++;
                        }


                        int inTableRowCount = dtblPartyBalance.Rows.Count;
                        for (int inI = 0; inI < inTableRowCount; inI++)
                        {
                            if (dtblPartyBalance.Rows.Count == inI)
                            {
                                break;
                            }
                            if (dtblPartyBalance.Rows[inI]["LedgerId"].ToString() == dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString())
                            {
                                if (dtblPartyBalance.Rows[inI]["PartyBalanceId"].ToString() != "0")
                                {
                                    arrlstOfDeletedPartyBalanceRow.Add(dtblPartyBalance.Rows[inI]["PartyBalanceId"]);
                                }
                                dtblPartyBalance.Rows.RemoveAt(inI);
                                inI--;
                            }
                        }
                        if (inUpdatingRowIndexForPartyRemove == dgvJournalVoucher.CurrentRow.Index)
                        {
                            inUpdatingRowIndexForPartyRemove = -1;
                            decUpdatingLedgerForPartyremove = 0;
                        }
                        dgvJournalVoucher.Rows.RemoveAt(dgvJournalVoucher.CurrentRow.Index);
                        SlNo();
                    }
                }

        }

        
        //public void Print(decimal decMasterId)
        //{
        //    try
        //    {
        //        JournalMasterSP SpJournalMaster = new JournalMasterSP();
        //        DataSet dsJournalVoucher = SpJournalMaster.JournalVoucherPrinting(decMasterId, 1);
        //        frmReport frmReport = new frmReport();
        //        frmReport.MdiParent = formMDI.MDIObj;
        //        frmReport.JournalVoucherPrinting(dsJournalVoucher);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("JV27:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }


        //}

        
        public void PrintForDotMatrix(decimal decMasterId)
        {
            // TO DO PrintForDotMatrix
            //try
            //{

            //    DataTable dtblOtherDetails = new DataTable();
            //    CompanySP spComapany = new CompanySP();
            //    dtblOtherDetails = spComapany.CompanyViewForDotMatrix();
            //    //-------------Grid Details-------------------\\
            //    DataTable dtblGridDetails = new DataTable();
            //    dtblGridDetails.Columns.Add("SlNo");
            //    dtblGridDetails.Columns.Add("Account Ledger");
            //    dtblGridDetails.Columns.Add("CrOrDr");
            //    dtblGridDetails.Columns.Add("Amount");
            //    dtblGridDetails.Columns.Add("Currency");
            //    dtblGridDetails.Columns.Add("Cheque No");
            //    dtblGridDetails.Columns.Add("Cheque Date");
            //    int inRowCount = 0;
            //    foreach (DataGridViewRow dRow in dgvJournalVoucher.Rows)
            //    {
            //        if (dRow.HeaderCell.Value != null && dRow.HeaderCell.Value.ToString() != "X")
            //        {
            //            if (!dRow.IsNewRow)
            //            {
            //                DataRow dr = dtblGridDetails.NewRow();
            //                dr["SlNo"] = ++inRowCount;
            //                dr["Account Ledger"] = dRow.Cells["dgvcmbAccountLedger"].FormattedValue.ToString();
            //                dr["CrOrDr"] = dRow.Cells["dgvcmbDrOrCr"].Value.ToString();
            //                dr["Amount"] = dRow.Cells["dgvtxtAmount"].Value.ToString();
            //                dr["Currency"] = dRow.Cells["dgvcmbCurrency"].FormattedValue.ToString();
            //                dr["Cheque No"] = (dRow.Cells["dgvtxtChequeNo"].Value == null ? "" : dRow.Cells["dgvtxtChequeNo"].Value.ToString());
            //                dr["Cheque Date"] = (dRow.Cells["dgvtxtChequeDate"].Value == null ? "" : dRow.Cells["dgvtxtChequeDate"].Value.ToString());
            //                dtblGridDetails.Rows.Add(dr);
            //            }
            //        }
            //    }


            //    //-------------Other Details-------------------\\

            //    dtblOtherDetails.Columns.Add("voucherNo");
            //    dtblOtherDetails.Columns.Add("date");
            //    dtblOtherDetails.Columns.Add("DebitTotal");
            //    dtblOtherDetails.Columns.Add("CreditTotal");
            //    dtblOtherDetails.Columns.Add("Narration");
            //    dtblOtherDetails.Columns.Add("DebitAmountInWords");
            //    dtblOtherDetails.Columns.Add("CreditAmountInWords");
            //    dtblOtherDetails.Columns.Add("Declaration");
            //    dtblOtherDetails.Columns.Add("Heading1");
            //    dtblOtherDetails.Columns.Add("Heading2");
            //    dtblOtherDetails.Columns.Add("Heading3");
            //    dtblOtherDetails.Columns.Add("Heading4");
            //    DataRow dRowOther = dtblOtherDetails.Rows[0];
            //    dRowOther["voucherNo"] = txtVoucherNo.Text;
            //    dRowOther["date"] = txtDate.Text;
            //    dRowOther["DebitTotal"] = txtDebitTotal.Text;
            //    dRowOther["CreditTotal"] = txtCreditTotal.Text;
            //    dRowOther["Narration"] = txtNarration.Text;
            //    dRowOther["DebitAmountInWords"] = new NumToText().AmountWords(Convert.ToDecimal(txtDebitTotal.Text), PublicVariables._decCurrencyId);
            //    dRowOther["CreditAmountInWords"] = new NumToText().AmountWords(Convert.ToDecimal(txtCreditTotal.Text), PublicVariables._decCurrencyId);
            //    dRowOther["address"] = (dtblOtherDetails.Rows[0]["address"].ToString().Replace("\n", ", ")).Replace("\r", "");


            //    VoucherTypeSP spVoucherType = new VoucherTypeSP();
            //    DataTable dtblDeclaration = spVoucherType.DeclarationAndHeadingGetByVoucherTypeId(decJournalVoucherTypeId);
            //    dRowOther["Declaration"] = dtblDeclaration.Rows[0]["Declaration"].ToString();
            //    dRowOther["Heading1"] = dtblDeclaration.Rows[0]["Heading1"].ToString();
            //    dRowOther["Heading2"] = dtblDeclaration.Rows[0]["Heading2"].ToString();
            //    dRowOther["Heading3"] = dtblDeclaration.Rows[0]["Heading3"].ToString();
            //    dRowOther["Heading4"] = dtblDeclaration.Rows[0]["Heading4"].ToString();
            //    int inFormId = spVoucherType.FormIdGetForPrinterSettings(Convert.ToInt32(dtblDeclaration.Rows[0]["masterId"].ToString()));
            //    PrintWorks.DotMatrixPrint.PrintDesign(inFormId, dtblOtherDetails, dtblGridDetails, dtblOtherDetails);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("JV28:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }


        public void CallFromAccountLedger(decimal decLedgerId)
        {
                if (decLedgerId != 0)
                {
                    //AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                    DataTable dtbl = new DataTable();
                    DataGridViewComboBoxCell dgvccAccountLedger = (DataGridViewComboBoxCell)dgvJournalVoucher[dgvJournalVoucher.Columns["dgvcmbAccountLedger"].Index, dgvJournalVoucher.CurrentRow.Index];
                    dgvccAccountLedger.DataSource = IME.AccountLedgers.ToList();
                    dgvccAccountLedger.ValueMember = "ledgerId";
                    dgvccAccountLedger.DisplayMember = "ledgerName";
                    dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value = decLedgerId;
                }
                dgvJournalVoucher.Focus();
                this.Enabled = true;
                this.BringToFront();
            
        }

        /// <summary>
        /// Function to set the date
        /// </summary>
        public void VoucherDate()
        {
                dtpVoucherDate.MinDate = (DateTime)Utils.getManagement().FinancialYear.fromDate;
                dtpVoucherDate.MaxDate = (DateTime)Utils.getManagement().FinancialYear.toDate;

                //CompanyInfo infoComapany = new CompanyInfo();
                //CompanySP spCompany = new CompanySP();

                //infoComapany = spCompany.CompanyView(1);
                DateTime dtVoucherDate = Convert.ToDateTime(IME.CurrentDate().First());
                dtpVoucherDate.Value = dtVoucherDate;
                txtDate.Text = dtVoucherDate.ToString("dd-MMM-yyyy");
                dtpVoucherDate.Value = Convert.ToDateTime(txtDate.Text);
                txtDate.Focus();
                txtDate.SelectAll();
            
        }

        /// <summary>
        /// Function to check the settings for printaftersave
        /// </summary>
        public void PrintCheck()
        {
                if (IME.Settings.Where(a=>a.settingsName=="TickPrintAfterSave").FirstOrDefault() != null)
                {
                    cbxPrintAfterSave.Checked = true;
                }
                else
                {
                    cbxPrintAfterSave.Checked = false;
                }
        }


        public void CallFromJournalReport(frmJournalReport frmJournalReport, decimal decJournalMasterId)
        {
            try
            {
                frmJournalReport.Enabled = false;
                base.Show();
                isEditMode = true;
                btnDelete.Enabled = true;
                frmJournalReportObj = frmJournalReport;
                decJournalMasterIdForEdit = decJournalMasterId;
                FillFunction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("JV33:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void keypresseventEnable(object sender, KeyPressEventArgs e)
        {
            
                e.Handled = false;

            
        }

        /// <summary>
        /// Function to delete partybalance of removed row
        /// </summary>
        public void DeletePartyBalanceOfRemovedRow()
        {
                foreach (object obj in arrlstOfDeletedPartyBalanceRow)
                {
                    string str = Convert.ToString(obj);
                    IME.PartyBalances.Where(a => a.partyBalanceId == Convert.ToDecimal(str));
                }


        }

        /// <summary>
        /// Function to load the form while calling from BillAllocation form
        /// </summary>
        /// <param name="frmBillallocation"></param>
        /// <param name="decJournalMasterId"></param>
        public void CallFromBillAllocation(frmBillallocation frmBillallocation, decimal decJournalMasterId)
        {
            try
            {
                frmBillallocation.Enabled = false;
                base.Show();
                isEditMode = true;
                btnDelete.Enabled = true;
                frmBillallocationObj = frmBillallocation;
                decJournalMasterIdForEdit = decJournalMasterId;
                FillFunction();
            }
            catch (Exception ex)
            {

                MessageBox.Show("JV36:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to fill the fields for edit or delete
        /// </summary>
        public void FillFunction()
        {

                
                JournalMaster JournalMaster = IME.JournalMasters.Where(a => a.journalMasterId == decJournalMasterIdForEdit).FirstOrDefault();
                VoucherType VoucherType = IME.VoucherTypes.Where(a => a.voucherTypeId == decJournalMasterIdForEdit).FirstOrDefault();

               this.Text = VoucherType.voucherTypeName;
                txtVoucherNo.ReadOnly = false;
                strVoucherNo = JournalMaster.voucherNo;
                strInvoiceNo = JournalMaster.invoiceNo;
                txtVoucherNo.Text = strInvoiceNo;
                decJournalSuffixPrefixId = (decimal)JournalMaster.suffixPrefixId;
                decJournalVoucherTypeId = (decimal)JournalMaster.voucherTypeId;
                dtpVoucherDate.Value = (DateTime)JournalMaster.date;
                txtNarration.Text = JournalMaster.narration;
                if (IME.VoucherTypes.Where(a=>a.voucherTypeId== decJournalVoucherTypeId).FirstOrDefault().methodOfVoucherNumbering== "Automatic")
                {
                    txtVoucherNo.ReadOnly = true;
                }
                else
                {
                    txtVoucherNo.ReadOnly = false;
                }

                //GridFill
                //DataTable dtbl = new DataTable();
                //JournalDetail JournalDetail = IME.JournalDetails.Where(a => a.journalMasterId == decJournalMasterIdForEdit).FirstOrDefault();

                //JournalDetailsSP spJournalDetailsSp = new JournalDetailsSP();
                //dtbl = IME.JournalDetails.Where(a => a.journalMasterId == decJournalMasterIdForEdit).ToList();

                //AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                //LedgerPostingSP spLedgerPosting = new LedgerPostingSP();
                var JournalDetailsList = IME.JournalDetails.Where(a => a.journalMasterId == decJournalMasterIdForEdit).ToList() ;

                for (int inI = 0; inI < JournalDetailsList.Count; inI++)
                {
                    dgvJournalVoucher.Rows.Add();
                    dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value = Convert.ToDecimal(JournalDetailsList[inI].ledgerId.ToString());
                    
                    if (Convert.ToDecimal(JournalDetailsList[inI].debit.ToString()) == 0)
                    {
                        dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value = "Cr";
                        dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value = Convert.ToDecimal(JournalDetailsList[inI].credit.ToString());
                    }
                    else
                    {
                        dgvJournalVoucher.Rows[inI].Cells["dgvcmbDrOrCr"].Value = "Dr";
                        dgvJournalVoucher.Rows[inI].Cells["dgvtxtAmount"].Value = Convert.ToDecimal(JournalDetailsList[inI].debit.ToString());
                    }
                    dgvJournalVoucher.Rows[inI].Cells["dgvcmbCurrency"].Value = Convert.ToDecimal(JournalDetailsList[inI].exchangeRateId.ToString());
                    if (JournalDetailsList[inI].chequeNo.ToString() != string.Empty)
                    {
                        dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeNo"].Value = JournalDetailsList[inI].chequeNo.ToString();
                        dgvJournalVoucher.Rows[inI].Cells["dgvtxtChequeDate"].Value = (Convert.ToDateTime(JournalDetailsList[inI].chequeDate.ToString())).ToString("dd-MMM-yyyy");
                    }
                    dgvJournalVoucher.Rows[inI].Cells["dgvtxtDetailsId"].Value = JournalDetailsList[inI].journalDetailsId.ToString();

                    decimal decDetailsId1 = Convert.ToDecimal(JournalDetailsList[inI].journalDetailsId.ToString());
                    decimal decLedgerPostingId = IME.LedgerPostings.Where(a => a.detailsId == decDetailsId1).Where(b => b.voucherNo == strVoucherNo).Where
                        (c => c.voucherTypeId == decJournalVoucherTypeId).FirstOrDefault().ledgerPostingId;
                    
                    dgvJournalVoucher.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value = decLedgerPostingId.ToString();
                    btnSave.Text = "Update";

                }

                //PartyBalanceSP SpPartyBalance = new PartyBalanceSP();
                DataTable dtbl1 = new DataTable();
                DateTime Date = Convert.ToDateTime(txtDate.Text);
                //dtbl1 = SpPartyBalance.PartyBalanceViewByVoucherNoAndVoucherType(decJournalVoucherTypeId, strVoucherNo, infoJournalMaster.Date);


            dtbl1 = GetpartyBalanceView(decJournalVoucherTypeId, strVoucherNo, Date);
            
            dtblPartyBalance = dtbl1;
                dgvJournalVoucher.ClearSelection();
                txtDate.Focus();
            
           
        }


        public DataTable GetpartyBalanceView(decimal decJournalVoucherTypeId, string strVoucherNo, DateTime Date)
        {
            PartyBalance PartyBalance = new PartyBalance();
            if (IME.PartyBalances.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.referenceType == "Against") != null)
            {

                var adaptor = (from ac in IME.PartyBalances.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.referenceType == "Against")
                               select new
                               {

                                   LedgerId = ac.ledgerId,
                                   AgainstVoucherTypeId = ac.againstVoucherTypeId,
                                   voucherNo = ac.voucherNo,
                                   referenceType = ac.referenceType,
                                   Amount = (ac.debit == 0) ? ac.credit : ac.debit,
                                   AgainstInvoiceNo = ac.againstInvoiceNo,
                                   CurrencyId = (IME.ExchangeRates.Where(a => a.date == Date).Where(b => b.currencyId == Decimal.Parse(IME.ExchangeRates.Where(d => d.exchangeRateID == ac.exchangeRateId).Select(e => e.currencyId).ToString())) == null) ? 1 : 0,
                                   DebitOrCredit = (ac.debit == 0) ? "Cr" : "Dr",
                                   PendingAmount = ac.debit - ac.credit,
                                   PartyBalanceId = ac.partyBalanceId,
                                   VoucherTypeId = ac.voucherTypeId,
                                   VoucherNo = ac.voucherNo,
                                   InvoiceNo = ac.invoiceNo,
                                   OldExchangeRate = (IsNullGetOldExchangeRateId((string)ac.voucherNo, (decimal)ac.voucherTypeId, (decimal)ac.ledgerId )== true) ? 1 : 0,
                               });
                return adaptor as DataTable;
            }
            else if (IME.PartyBalances.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.referenceType == "New") != null)
            {
                var adaptor = (from ac in IME.PartyBalances.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.referenceType == "New")
                               select new
                               {

                                   LedgerId = ac.ledgerId,
                                   AgainstVoucherTypeId = ac.againstVoucherTypeId,
                                   voucherNo = ac.voucherNo,
                                   referenceType = ac.referenceType,
                                   Amount = (ac.debit == 0) ? ac.credit : ac.debit,
                                   AgainstInvoiceNo = ac.againstInvoiceNo,
                                   CurrencyId = (IME.ExchangeRates.Where(a => a.date == Date).Where(b => b.currencyId == Decimal.Parse(IME.ExchangeRates.Where(d => d.exchangeRateID == ac.exchangeRateId).Select(e => e.currencyId).ToString())) == null) ? 1 : 0,
                                   DebitOrCredit = (ac.debit == 0) ? "Cr" : "Dr",
                                   PendingAmount = ac.debit - ac.credit,
                                   PartyBalanceId = ac.partyBalanceId,
                                   VoucherTypeId = ac.voucherTypeId,
                                   VoucherNo = ac.voucherNo,
                                   InvoiceNo = ac.invoiceNo,
                                   OldExchangeRate = (IsNullGetOldExchangeRateId((string)ac.voucherNo, (decimal)ac.voucherTypeId, (decimal)ac.ledgerId) == true) ? 1 : 0,
                               });
                return adaptor as DataTable;
            }
            else if (IME.PartyBalances.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.referenceType == "OnAccount") != null)
            {
                var adaptor = (from ac in IME.PartyBalances.Where(a => a.voucherTypeId == decJournalVoucherTypeId).Where(b => b.referenceType == "OnAccount")
                               select new
                               {

                                   LedgerId = ac.ledgerId,
                                   AgainstVoucherTypeId = ac.againstVoucherTypeId,
                                   voucherNo = ac.voucherNo,
                                   referenceType = ac.referenceType,
                                   Amount = (ac.debit == 0) ? ac.credit : ac.debit,
                                   AgainstInvoiceNo = ac.againstInvoiceNo,
                                   CurrencyId = (IME.ExchangeRates.Where(a => a.date == Date).Where(b => b.currencyId == Decimal.Parse(IME.ExchangeRates.Where(d => d.exchangeRateID == ac.exchangeRateId).Select(e => e.currencyId).ToString())) == null) ? 1 : 0,
                                   DebitOrCredit = (ac.debit == 0) ? "Cr" : "Dr",
                                   PendingAmount = ac.debit - ac.credit,
                                   PartyBalanceId = ac.partyBalanceId,
                                   VoucherTypeId = ac.voucherTypeId,
                                   VoucherNo = ac.voucherNo,
                                   InvoiceNo = ac.invoiceNo,
                                   OldExchangeRate = (IsNullGetOldExchangeRateId((string)ac.voucherNo, (decimal)ac.voucherTypeId, (decimal)ac.ledgerId) == true) ? 1 : 0,
                               });
                return adaptor as DataTable;
            }

            return null;
            
        }

        public bool IsNullGetOldExchangeRateId(string voucherNo, decimal voucherTypeId, decimal ledgerId)
        {
            string typeOfVoucher = IME.VoucherTypes.Where(a => a.voucherTypeId == voucherTypeId).FirstOrDefault().typeOfVoucher;
            bool isnull = false;
            switch (typeOfVoucher)
            {
                case "Sales Invoice":
                    {

                        if (IME.SaleOrders.Where(a => a.VoucherId == Decimal.Parse(voucherNo)).Where(b => b.VoucherTypeId == voucherTypeId) == null) isnull = true;
                    }
                    break;
                case "Purchase Invoice":
                    {
                        //To Do What are they Purchase Invoice
                    }
                    break;
                case "Payment Voucher":
                    {
                        
                    }
                    break;
                case "Receipt Voucher":
                    {

                    }
                    break;
                case "Journal Voucher":
                    {
                        if (IME.JournalDetails.Where(a => a.JournalMaster.voucherNo == voucherNo).
                            Where(b => b.JournalMaster.voucherTypeId == voucherTypeId).Where(c => c.ledgerId == ledgerId) == null) isnull= true;
                        
                    }
                    break;
                case "Debit Note":
                    {

                        var a1 = (from a in IME.DebitNoteDetails
                                  join b in IME.DebitNoteMasters on a.debitNoteMasterId equals b.debitNoteMasterId
                                  where b.voucherNo==voucherNo
                                  where b.voucherTypeId==voucherTypeId
                                  where a.ledgerId == ledgerId
                                  select a.exchangeRateId
                            ).ToList();
                        if (a1 == null) isnull = true;
                    }
                    break;
                case "Credit Note":
                    {
                        var a1 = (from a in IME.CreditNoteDetails
                                  join b in IME.CreditNoteMasters on a.creditNoteMasterId equals b.creditNoteMasterId
                                  where b.voucherNo == voucherNo
                                  where b.voucherTypeId == voucherTypeId
                                  where a.ledgerId == ledgerId
                                  select a.exchangeRateId
                           ).ToList();
                        if (a1 == null) isnull = true;
                    }
                    break;
                case "PDC Payable":
                    {
                        var a1 = (from a in IME.PartyBalances
                                  join b in IME.PDCPayableMasters on a.againstVoucherTypeId equals b.voucherTypeId
                                  where a.againstVoucherNo == b.voucherNo
                                  select a.exchangeRateId
                            ).ToList();
                        if (a1 == null) isnull = true;
                    }
                    break;
                case "PDC Receivable":
                    {
                        var a1 = (from a in IME.PartyBalances
                                  join b in IME.PDCReceivableMasters on a.againstVoucherTypeId equals b.voucherTypeId
                                  where a.againstVoucherNo == b.voucherNo
                                  select a.exchangeRateId
                            ).ToList();
                        if (a1 == null) isnull = true;
                    }
                    break;
            }

            return isnull;
        }

        //public void CallFromLedgerDetails(frmLedgerDetails frmLedgerDetails, decimal decMasterId)
        //{
        //    try
        //    {
        //        base.Show();
        //        frmLedgerDetailsObj = frmLedgerDetails;
        //        frmLedgerDetailsObj.Enabled = false;
        //        isEditMode = true;
        //        btnDelete.Enabled = true;
        //        decJournalMasterIdForEdit = decMasterId;
        //        FillFunction();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("JV38:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //}


        //public void callFromDayBook(frmDayBook frmDayBook, decimal decMasterId)
        //{
        //    try
        //    {
        //        frmDayBook.Enabled = false;
        //        base.Show();
        //        isEditMode = true;
        //        btnDelete.Enabled = true;
        //        frmDayBookObj = frmDayBook;
        //        decJournalMasterIdForEdit = decMasterId;
        //        FillFunction();
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("JV39:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        /// <summary>
        /// Function to load the form while calling from Ageingreport form
        /// </summary>
        /// <param name="frmAgeing"></param>
        /// <param name="decMasterId"></param>
        //public void callFromAgeing(frmAgeingReport frmAgeing, decimal decMasterId)
        //{
        //try
        //{
        //    frmAgeing.Enabled = false;
        //    base.Show();

        //    btnDelete.Enabled = true;
        //    frmAgeingObj = frmAgeing;
        //    decJournalMasterIdForEdit = decMasterId;
        //    FillFunction();

        //}

        //catch (Exception ex)
        //{
        //    MessageBox.Show("JV40:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        //}
        #endregion

        #region Events

        /// <summary>
        /// On changing the date from dtpVoucherDate, sets the txtDate with the new date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpVoucherDate_ValueChanged(object sender, EventArgs e)
        {

                DateTime date = this.dtpVoucherDate.Value;
                this.txtDate.Text = date.ToString("dd-MMM-yyyy");
                CurrencyComboFill();
            
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

                SaveOrEdit();
            
        }

        /// <summary>
        /// On CellEnter of dgvCreditNote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJournalVoucher_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

                if (dgvJournalVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
                {
                    dgvJournalVoucher.EditMode = DataGridViewEditMode.EditOnEnter;
                }
                else
                {
                    dgvJournalVoucher.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
            
        }

        /// <summary>
        /// On Close button click
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
        /// On load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJournalVoucher_Load(object sender, EventArgs e)
        {
                AccountLedgerComboFill();
                DrOrCrComboFill();
                clear();
                CurrencyComboFill();
                DebitAndCreditTotal();

                /************For PartyBalance***********************/
                // dtblPartyBalance.Columns.Add("RowIndex", typeof(int));
                dtblPartyBalance.Columns.Add("LedgerId", typeof(decimal));
                dtblPartyBalance.Columns.Add("AgainstVoucherTypeId", typeof(decimal));
                dtblPartyBalance.Columns.Add("AgainstVoucherNo", typeof(string));
                dtblPartyBalance.Columns.Add("ReferenceType", typeof(string));
                dtblPartyBalance.Columns.Add("Amount", typeof(decimal));
                dtblPartyBalance.Columns.Add("AgainstInvoiceNo", typeof(string));
                dtblPartyBalance.Columns.Add("CurrencyId", typeof(decimal));
                dtblPartyBalance.Columns.Add("DebitOrCredit", typeof(string));
                dtblPartyBalance.Columns.Add("PendingAmount", typeof(decimal));
                dtblPartyBalance.Columns.Add("PartyBalanceId", typeof(decimal));
                dtblPartyBalance.Columns.Add("VoucherTypeId", typeof(decimal));
                dtblPartyBalance.Columns.Add("VoucherNo", typeof(string));
                dtblPartyBalance.Columns.Add("InvoiceNo", typeof(string));
                dtblPartyBalance.Columns.Add("OldExchangeRate", typeof(decimal));
                //ArrayList of deleted partybalance row in update mode
                arrlstOfDeletedPartyBalanceRow = new ArrayList();

                /***********************************************************/

        }

        /// <summary>
        /// On Clear button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
                clear();
        }


        /// <summary>
        /// On remove linkbutton click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

                if (dgvJournalVoucher.RowCount > 1)
                {
                    if (MessageBox.Show("Do you want to remove current row ?", "OpenMiracle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        RemoveRow();
                    }
                }
            
        }


        private void dgvJournalVoucher_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    DebitAndCreditTotal();

                    if (dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {

                        if (dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value == null || dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value.ToString() == string.Empty)
                        {
                            dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value = Convert.ToDecimal(1); //decExchangeRateId;
                        }

                    }

                    if (dgvJournalVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbAccountLedger")
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

                            dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvtxtAmount"].Value = string.Empty;

                            //reset
                            decUpdatingLedgerForPartyremove = 0;
                            inUpdatingRowIndexForPartyRemove = -1;
                        }
                        /*************************************************************************/

                        //-----------To make amount readonly when party is selected as ledger------------------------------//
                        string ledgerName = dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].FormattedValue.ToString();
                        
                        if (IME.AccountLedgers.Where(c => c.ledgerName == ledgerName).Where(b=>b.billByBill==true).Select(a => a.ledgerId).Distinct().Count() <= 0)
                        {
                            dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvtxtAmount"].Value = string.Empty;
                            dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvtxtAmount"].ReadOnly = true;

                        }
                        else
                        {
                            dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvtxtAmount"].Value = string.Empty;
                            dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvtxtAmount"].ReadOnly = false;
                           
                            if (IME.Settings.Where(a => a.settingsName == "MultiCurrency").FirstOrDefault().status == "Yes")
                            {
                                dgvcmbCurrency.ReadOnly = false;
                            }
                            else
                            {
                                dgvcmbCurrency.ReadOnly = true;

                            }
                        }

                        //========================================================================================//
                    }

                    if (dgvJournalVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbDrOrCr")
                    {
                        /*************Remove partybalance while changing the Dr/Cr ************/
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
                            dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvtxtAmount"].Value = string.Empty;

                            //reset
                            decUpdatingLedgerForPartyremove = 0;
                            inUpdatingRowIndexForPartyRemove = -1;
                        }
                        /*************************************************************************/
                    }

                    //-----------------------------------Chequedate validation----------------------------------//
                    
                            dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
                        
                    //=========================================================================================//
                    //---------------------check column missing---------------------------------//

                    CheckColumnMissing(e);

                    //==========================================================================//

                }
            
        }

        /// <summary>
        /// For the shortcut keys
        /// Esc for form closing
        /// ctrl+s for save
        /// ctrl+d for delete
        /// alt+c for ledger creation
        /// ctrl+f for ledger popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void frmJournalVoucher_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {

        //        if (dgvJournalVoucher.RowCount > 0)
        //        {
        //            //-----------------------for ledger creation----------------------------------//
        //            if (e.KeyCode == Keys.C && Control.ModifierKeys == Keys.Alt)//Ledger creation
        //            {
        //                if (dgvJournalVoucher.CurrentCell == dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"])
        //                {
        //                   // SendKeys.Send("{F10}");
        //                    frmAccountLedger accounLedgerObj = new frmAccountLedger();
        //                    accounLedgerObj.MdiParent = formMDI.MDIObj;
        //                    if (dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
        //                    {
        //                        string strLedgerName = dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].FormattedValue.ToString();
        //                        accounLedgerObj.CallFromJournalVoucher(this, strLedgerName);
        //                    }
        //                    else
        //                    {
        //                        string strLedgerName = string.Empty;
        //                        accounLedgerObj.CallFromJournalVoucher(this, strLedgerName);
        //                    }
        //                }

        //            }
        //            //========================================================================//

        //            //--------------------For ledger Popup------------------------------------//

        //            if (e.KeyCode == Keys.F && Control.ModifierKeys == Keys.Control)//Ledger popup
        //            {
        //                if (dgvJournalVoucher.CurrentCell == dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"])
        //                {
        //                    frmLedgerPopup frmLedgerPopupObj = new frmLedgerPopup();
        //                    frmLedgerPopupObj.MdiParent = formMDI.MDIObj;

        //                    if (dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
        //                    {
        //                        decLedgerIdForPopUp = Convert.ToDecimal(dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString());
        //                        frmLedgerPopupObj.CallFromJournalVoucher(this, decLedgerIdForPopUp, string.Empty);

        //                    }
        //                }

        //            }
        //            //========================================================================// 


        //            if (e.KeyCode == Keys.F && Control.ModifierKeys == Keys.Control) //Pop Up
        //            {
        //                if (dgvJournalVoucher.CurrentCell == dgvJournalVoucher.CurrentRow.Cells["dgvcmbCurrency"])
        //                {
        //                    frmCurrencyObj = new frmCurrencyDetails();
        //                    frmCurrencyObj.MdiParent = formMDI.MDIObj;
        //                    if (dgvJournalVoucher.CurrentRow.Cells["dgvcmbCurrency"].Value != null && dgvJournalVoucher.CurrentRow.Cells["dgvcmbCurrency"].Value.ToString() != string.Empty)
        //                    {
        //                        frmCurrencyObj.CallFromJournalVoucher(this, Convert.ToDecimal(dgvJournalVoucher.CurrentRow.Cells["dgvcmbCurrency"].Value.ToString()));
        //                    }
        //                }
        //            }

        //        }


        //        //-----------------------CTRL+S Save-----------------------------//
        //        if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
        //        {
        //            btnSave_Click(sender, e);
        //        }
        //        //===============================================================//

        //        //-----------------------CTRL+D Delete-----------------------------//
        //        if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control) //Delete
        //        {
        //            if (btnDelete.Enabled)
        //            {
        //                btnDelete_Click(sender, e);
        //            }
        //        }
        //        //=====================================================================//
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("JV51:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //}

        /// <summary>

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction(decJournalMasterIdForEdit);
            }

        }

        /// <summary>
        /// While adding new row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJournalVoucher_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

                SlNo();
            
        }

        /// <summary>
        /// For committing edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJournalVoucher_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

                if (dgvJournalVoucher.IsCurrentCellDirty)
                {
                    dgvJournalVoucher.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            
        }


        /// <summary>
        /// For against button click in the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJournalVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
                {
                    if (dgvJournalVoucher.CurrentCell.ColumnIndex == dgvJournalVoucher.Columns["dgvbtnAgainst"].Index)
                    {
                        if (dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                        {
                            if (dgvJournalVoucher.CurrentRow.Cells["dgvcmbDrOrCr"].Value != null && dgvJournalVoucher.CurrentRow.Cells["dgvcmbDrOrCr"].Value.ToString() != string.Empty)
                            {
                                decimal ledgerId = decimal.Parse(dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].FormattedValue.ToString());
                                if (IME.AccountLedgers.Where(c => c.ledgerId == ledgerId).Select(a => a.ledgerId).Distinct().Count() <= 0)
                                {
                                    
                                    //frmPartyBalanceObj = new frmPartyBalance();
                                    //frmPartyBalanceObj.MdiParent = formMDI.MDIObj;
                                    decimal decLedgerId = Convert.ToDecimal(dgvJournalVoucher.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString());

                                    string strDebitOrCredit = dgvJournalVoucher.CurrentRow.Cells["dgvcmbDrOrCr"].Value.ToString();
                                    // TO DO Party balance call eklenecek
                                    //if (!isAutomatic)
                                    //{
                                        
                                    //    frmPartyBalanceObj.CallFromJournalVoucher(this, decLedgerId, dtblPartyBalance, strDebitOrCredit, decJournalVoucherTypeId, txtVoucherNo.Text, Convert.ToDateTime(txtDate.Text), arrlstOfDeletedPartyBalanceRow);
                                    //}
                                    //else
                                    //{
                                    //    frmPartyBalanceObj.CallFromJournalVoucher(this, decLedgerId, dtblPartyBalance, strDebitOrCredit, decJournalVoucherTypeId, strVoucherNo, Convert.ToDateTime(txtDate.Text), arrlstOfDeletedPartyBalanceRow);
                                    //}

                                }

                            }
                            else
                            {
                                MessageBox.Show("Select debit or credit");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select any ledger");
                        }
                    }
                }
            
        }


        //private void dgvJournalVoucher_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    try
        //    {
        //        inUpdatingRowIndexForPartyRemove = -1;
        //        decUpdatingLedgerForPartyremove = 0;
        //        DataTable dtbl = new DataTable();
        //        AccountLedgerSP SpAccountLedger = new AccountLedgerSP();

        //        if (dgvJournalVoucher.CurrentCell.ColumnIndex == dgvJournalVoucher.Columns["dgvcmbAccountLedger"].Index)
        //        {
        //            dtbl = SpAccountLedger.AccountLedgerViewAll();
        //            DataRow dr = dtbl.NewRow();
        //            dr[0] = 0;
        //            dr[2] = string.Empty;
        //            dtbl.Rows.InsertAt(dr, 0);

        //            if (dtbl.Rows.Count > 0)
        //            {
        //                if (dgvJournalVoucher.RowCount > 1)
        //                {
        //                    int inGridRowCount = dgvJournalVoucher.RowCount;
        //                    for (int inI = 0; inI < inGridRowCount - 1; inI++)
        //                    {
        //                        if (inI != e.RowIndex)
        //                        {
        //                            int inTableRowcount = dtbl.Rows.Count;
        //                            for (int inJ = 0; inJ < inTableRowcount; inJ++)
        //                            {
        //                                if (dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
        //                                {
        //                                    if (dtbl.Rows[inJ]["ledgerId"].ToString() == dgvJournalVoucher.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString())
        //                                    {
        //                                        dtbl.Rows.RemoveAt(inJ);
        //                                        break;
        //                                    }
        //                                }
        //                            }

        //                        }
        //                    }
        //                }
        //                DataGridViewComboBoxCell dgvccVoucherType = (DataGridViewComboBoxCell)dgvJournalVoucher[dgvJournalVoucher.Columns["dgvcmbAccountLedger"].Index, e.RowIndex];
        //                dgvccVoucherType.DataSource = dtbl;
        //                dgvccVoucherType.ValueMember = "ledgerId";
        //                dgvccVoucherType.DisplayMember = "ledgerName";
        //            }
        //        }

        //        if (dgvJournalVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbAccountLedger")
        //        {
        //            if (dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
        //            {
        //                AccountLedgerSP spAccountLedger = new AccountLedgerSP();
        //                if (spAccountLedger.AccountGroupIdCheck(dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].FormattedValue.ToString()))
        //                {
        //                    inUpdatingRowIndexForPartyRemove = e.RowIndex;
        //                    decUpdatingLedgerForPartyremove = Convert.ToDecimal(dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString());
        //                }
        //            }
        //        }
        //        if (dgvJournalVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbDrOrCr")
        //        {
        //            if (dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
        //            {
        //                AccountLedgerSP spAccountLedger = new AccountLedgerSP();
        //                if (spAccountLedger.AccountGroupIdCheck(dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].FormattedValue.ToString()))
        //                {
        //                    inUpdatingRowIndexForPartyRemove = e.RowIndex;
        //                    decUpdatingLedgerForPartyremove = Convert.ToDecimal(dgvJournalVoucher.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString());
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("JV57:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        /// <summary>
        /// For handling dataerror
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJournalVoucher_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
                if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                {
                    object value = dgvJournalVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dgvJournalVoucher.Columns[e.ColumnIndex]).Items.Contains(value))
                    {
                        e.ThrowException = false;
                    }
                }
        }

        #endregion

        #region Navigation

        /// <summary>
        /// For enter key navigation txtVoucherNo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDate.Focus();
                }
        }

        /// <summary>
        /// For enter key and backspace navigation of txtDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvJournalVoucher.Focus();

                }
                if (txtDate.Text == string.Empty || txtDate.SelectionStart == 0)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        if (!txtVoucherNo.ReadOnly)
                        {
                            txtVoucherNo.Focus();
                        }

                    }
                }
           
        }

        /// <summary>
        /// For backspace navigation of txtNarration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text.Trim() == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        if (dgvJournalVoucher.RowCount > 0)
                        {
                            dgvJournalVoucher.Focus();
                        }
                        else
                        {
                            txtDate.Focus();
                            txtDate.SelectionStart = txtDate.TextLength;
                        }
                    }
                }
        }

        /// <summary>
        /// Enter key navigation of txtNarration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// For backspace navigation of btnSave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Back)
                {
                    txtNarration.Focus();
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
                }

        }

        /// <summary>
        /// For backspace navigation of btnClear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_KeyUp(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Back)
                {
                    btnSave.Focus();
                }

        }

        /// <summary>
        /// For backspace navigation of btnDelete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_KeyUp(object sender, KeyEventArgs e)
        {

                if (e.KeyCode == Keys.Back)
                {
                    if (btnDelete.Enabled)
                    {
                        btnDelete.Focus();
                    }
                    else
                    {
                        btnClear.Focus();
                    }
                }
           
        }

        /// <summary>
        /// For enter key and backspace navigation of dgvJournalVoucher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJournalVoucher_KeyDown(object sender, KeyEventArgs e)
        {
                int inDgvJournalRowCount = dgvJournalVoucher.Rows.Count;
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvJournalVoucher.CurrentCell == dgvJournalVoucher.Rows[inDgvJournalRowCount - 1].Cells["dgvtxtChequeDate"])
                    {
                        txtNarration.Focus();
                        txtNarration.SelectionStart = txtNarration.TextLength;
                        dgvJournalVoucher.ClearSelection();
                    }

                }
                if (e.KeyCode == Keys.Back)
                {
                    if (dgvJournalVoucher.CurrentCell == dgvJournalVoucher.Rows[0].Cells["dgvtxtSlNo"])
                    {
                        txtDate.Focus();
                        txtDate.SelectionStart = txtDate.TextLength;
                        dgvJournalVoucher.ClearSelection();
                    }
                }


        }

        #endregion



    }
}
