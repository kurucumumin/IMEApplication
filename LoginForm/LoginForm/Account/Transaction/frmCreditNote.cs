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
using LoginForm.Account.Services;
using LoginForm.Account;
using LoginForm.Services;
using LoginForm;

namespace LoginForm
{
    public partial class frmCreditNote : Form
    {
        

        #region Public Variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        decimal decCreditNoteVoucherTypeId = 0;
        bool isAutomatic = false;
        decimal decCreditNoteSuffixPrefixId = 0;
        string strPrefix = string.Empty;
        string strSuffix = string.Empty;
        string strVoucherNo = string.Empty;
        string strInvoiceNo = string.Empty;
        string strTableName = "CreditNoteMaster";
        bool isEditMode = false;
        bool isValueChanged = false;
        decimal decAmount = 0;
        decimal decConvertRate = 0;
        decimal decSelectedCurrencyRate = 0;
        DataTable dtblCreditNote = new DataTable();
        //frmCurrencyDetails frmCurrencyObj = null;//to use in call from currency class
        ArrayList arrlstOfRemove = new ArrayList();
        ArrayList arrlstOfRemovedLedgerPostingId = new ArrayList();
        decimal decCreditNoteMasterIdForEdit = 0;
        int inNarrationCount = 0;

        decimal decLedgerIdForPopUp = 0;
        frmCreditNoteReport frmCreditNoteReportObj = null;
        frmCreditNoteRegister CreditNoteRegisterObj = null;//To use in call from JournalRegister 
        //frmPartyBalance frmPartyBalanceObj = null;//To use in call from PartyBalance class
        DataTable dtblPartyBalance = new DataTable();//To store PartyBalance entries while clicking btn_Save in CreditNote
        ArrayList arrlstOfDeletedPartyBalanceRow;
       // frmBillallocation frmBillallocationObj = null;
        frmVoucherSearch objVoucherSearch = null;
        public string strVocherNo;
       // frmDayBook frmDayBookObj = null;//To use in call from frmDayBook
        //frmAgeingReport frmAgeingObj = null;//To use in call from frmAgeing
        int inUpdatingRowIndexForPartyRemove = -1;
        decimal decUpdatingLedgerForPartyremove = 0;
       // frmLedgerDetails frmLedgerDetailsObj;
        #endregion

        #region Functions

        /// <summary>
        /// Create instance of frmCreditNote
        /// </summary>
        public frmCreditNote()
        {
            InitializeComponent();
        }

        /// <summary>
        /// It is a function for vouchertypeselection form to select perticular voucher and open the form under the vouchertype
        /// </summary>
        /// <param name="decVoucherTypeId"></param>
        /// <param name="strVoucherTypeName"></param>
        //public void CallFromVoucherTypeSelection(decimal decVoucherTypeId, string strVoucherTypeName)
        //{
        //    try
        //    {
        //        decCreditNoteVoucherTypeId = decVoucherTypeId;
        //        VoucherTypeSP spVoucherType = new VoucherTypeSP();
        //        isAutomatic = spVoucherType.CheckMethodOfVoucherNumbering(decCreditNoteVoucherTypeId);
        //        SuffixPrefixSP spSuffisprefix = new SuffixPrefixSP();
        //        SuffixPrefixInfo infoSuffixPrefix = new SuffixPrefixInfo();

        //        infoSuffixPrefix = spSuffisprefix.GetSuffixPrefixDetails(decCreditNoteVoucherTypeId, dtpVoucherDate.Value);
        //        decCreditNoteSuffixPrefixId = infoSuffixPrefix.SuffixprefixId;
        //        strPrefix = infoSuffixPrefix.Prefix;
        //        strSuffix = infoSuffixPrefix.Suffix;
        //        this.Text = strVoucherTypeName;
        //        base.Show();
        //        Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("CRNT:01" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //}

        /// <summary>
        /// Load the form while calling from the voucherSearch in editmode
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="decId"></param>
        public void CallThisFormFromVoucherSearch(frmVoucherSearch frm, decimal decId)
        {
            // Function to call form voucher Search
            try
            {
                this.objVoucherSearch = frm;
                decCreditNoteMasterIdForEdit = decId;
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
                isEditMode = true;
                FillFunction();

            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:02" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to clear the fields
        /// </summary>
        public void Clear()
        {
            try
            {
                TransactionsGeneralFill obj = new TransactionsGeneralFill();
                CreditNoteMasterSP spMaster = new CreditNoteMasterSP();
                //MessageBox.Show(DateTime.Now.ToString());
                //dtpVoucherDate.Value = DateTime.Now;
                //-----------------------------------VoucherNo automatic generation-------------------------------------------//


                if (strVoucherNo == string.Empty)
                {
                    strVoucherNo = "0"; //strMax;
                }
                if (dtpVoucherDate != null)
                {
                    strVoucherNo = obj.VoucherNumberAutomaicGeneration(decCreditNoteVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpVoucherDate.Value, strTableName);
                }
                else
                {
                    strVoucherNo = obj.VoucherNumberAutomaicGeneration(decCreditNoteVoucherTypeId, Convert.ToDecimal(strVoucherNo), DateTime.Now, strTableName);
                }
                

                if (Convert.ToDecimal(strVoucherNo) != spMaster.CreditNoteMasterGetMaxPlusOne(decCreditNoteVoucherTypeId))
                {
                    strVoucherNo = spMaster.CreditNoteMasterGetMax(decCreditNoteVoucherTypeId).ToString();
                    strVoucherNo = obj.VoucherNumberAutomaicGeneration(decCreditNoteVoucherTypeId, Convert.ToDecimal(strVoucherNo), DateTime.Now, strTableName);
                    if (spMaster.CreditNoteMasterGetMax(decCreditNoteVoucherTypeId).ToString() == "0")
                    {
                        strVoucherNo = "0";
                        strVoucherNo = obj.VoucherNumberAutomaicGeneration(decCreditNoteVoucherTypeId, Convert.ToDecimal(strVoucherNo), DateTime.Now, strTableName);
                    }
                }

                //===================================================================================================================//
                if (isAutomatic)
                {
                    SuffixPrefixSP spSuffisprefix = new SuffixPrefixSP();
                    SuffixPrefix infoSuffixPrefix = new SuffixPrefix();

                    infoSuffixPrefix = spSuffisprefix.GetSuffixPrefixDetails(decCreditNoteVoucherTypeId, dtpVoucherDate.Value);
                    strPrefix = infoSuffixPrefix.prefix;
                    strSuffix = infoSuffixPrefix.suffix;
                    strInvoiceNo = strPrefix + strVoucherNo + strSuffix;
                    txtVoucherNo.Text = strInvoiceNo;
                    txtVoucherNo.ReadOnly = true;
                }
                else
                {
                    txtVoucherNo.ReadOnly = false;
                    txtVoucherNo.Text = string.Empty;
                    strInvoiceNo = txtVoucherNo.Text.Trim();
                }


                dgvCreditNote.Rows.Clear();
                VoucherDate();
                dtpVoucherDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                txtDebitTotal.Text = string.Empty;
                txtCreditTotal.Text = string.Empty;
                txtNarration.Text = string.Empty;
                btnSave.Text = "Save";
                btnDelete.Enabled = false;
                isEditMode = false;
                dtblPartyBalance.Clear();//to clear party balance entries to clear the dgvpatybalance
                PrintCheck();
                if (txtVoucherNo.ReadOnly != true)
                {
                    txtVoucherNo.Focus();
                }
                else
                {
                    txtDate.Select();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:03" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to check the settings for printaftersave
        /// </summary>
        public void PrintCheck()
        {
            try
            {
                SettingsSP spSettings = new SettingsSP();

                if (spSettings.SettingsStatusCheck("TickPrintAfterSave") == "Yes")
                {
                    cbxPrintAfterSave.Checked = true;
                }
                else
                {
                    cbxPrintAfterSave.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:04" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to keep the datatable containing party balance details while calling from the partybalance form
        /// </summary>
        /// <param name="frmPartyBalance"></param>
        /// <param name="decAmount"></param>
        /// <param name="dtbl"></param>
        /// <param name="arrlstOfRemovedRow"></param>
        //public void CallFromPartyBalance(frmPartyBalance frmPartyBalance, decimal decAmount, DataTable dtbl, ArrayList arrlstOfRemovedRow)
        //{
        //    try
        //    {
        //        dgvCreditNote.CurrentRow.Cells["dgvtxtAmount"].Value = decAmount.ToString();
        //        dgvCreditNote.CurrentRow.Cells["dgvcmbCurrency"].Value = Convert.ToDecimal(1);
        //        dgvCreditNote.CurrentRow.Cells["dgvcmbCurrency"].ReadOnly = true;
        //        this.frmPartyBalanceObj = frmPartyBalance;
        //        frmPartyBalance.Close();
        //        frmPartyBalanceObj = null;
        //        dtblPartyBalance = dtbl;
        //        arrlstOfDeletedPartyBalanceRow = arrlstOfRemovedRow;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("CRNT:05" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        /// <summary>
        /// Function to fill the currency combobox
        /// </summary>
        public void CurrencyComboFill()
        {
            try
            {
                IMEEntities IME = new IMEEntities();
                //DataTable dtbl = new DataTable();
                //TransactionsGeneralFill TransactionGeneralFillObj = new TransactionsGeneralFill();
                //dtbl = TransactionGeneralFillObj.CurrencyComboByDate(Convert.ToDateTime(txtDate.Text));
                //DataRow dr = dtbl.NewRow();
                //dr[0] = string.Empty;
                //dr[1] = 0;
                //dtbl.Rows.InsertAt(dr, 0);
                dgvcmbCurrency.DataSource = IME.Currencies.ToList();
                dgvcmbCurrency.ValueMember = "currencyId";
                dgvcmbCurrency.DisplayMember = "currencyName";

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
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:06" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to fill the accountledger combobox
        /// </summary>
        public void AccountLedgerComboFill()
        {
            try
            {
                DataTable dtbl = new DataTable();
                AccountLedgerSP spaccountledger = new AccountLedgerSP();
                dtbl = spaccountledger.AccountLedgerViewAll();
                DataRow dr = dtbl.NewRow();
                dr[0] = 0;
                dr[2] = string.Empty;
                dtbl.Rows.InsertAt(dr, 0);
                dgvcmbAccountLedger.DataSource = dtbl;
                dgvcmbAccountLedger.ValueMember = "ledgerId";
                dgvcmbAccountLedger.DisplayMember = "ledgerName";

            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:07" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to fill the debit/credit combobox in grid
        /// </summary>
        public void DrOrCrComboFill()
        {
            try
            {
                dgvcmbDrOrCr.Items.AddRange("Dr", "Cr");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:08" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// To change the currency from currency popup
        /// </summary>
        /// <param name="frmCurrencyDetails"></param>
        /// <param name="decId"></param>
        //public void CallFromCurrenCyDetails(frmCurrencyDetails frmCurrencyDetails, decimal decId) //PopUp
        //{
        //    ExchangeRateSP spExchangeRate = new ExchangeRateSP();
        //    try
        //    {
        //        frmCurrencyObj.Close();
        //        CurrencyComboFill();
        //        decId = spExchangeRate.GetExchangeRateId(decId, Convert.ToDateTime(txtDate.Text));
        //        dgvCreditNote.CurrentRow.Cells["dgvcmbCurrency"].Value = decId;
        //        dgvCreditNote.Focus();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("CRNT:09" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}


        /// <summary>
        /// To select the ledger from ledger popup
        /// </summary>
        /// <param name="decId"></param>
        /// <param name="frmLedgerPopUp"></param>
        public void CallFromLedgerPopup(decimal decId, frmLedgerPopup frmLedgerPopUp) //PopUp
        {
            try
            {
                frmLedgerPopUp.Close();
                dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value = decId;
                dgvCreditNote.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:10" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to load the voucher to edit or delete while calling from the creditnote register 
        /// </summary>
        /// <param name="frmCreditNoteObj"></param>
        /// <param name="decMasterId"></param>
        public void CallFromCreditNoteRegister(frmCreditNoteRegister frmCreditNoteObj, decimal decMasterId)
        {
            try
            {
                base.Show();
                isEditMode = true;
                btnDelete.Enabled = true;
                CreditNoteRegisterObj = frmCreditNoteObj;
                CreditNoteRegisterObj.Enabled = false;
                decCreditNoteMasterIdForEdit = decMasterId;

                FillFunction();

            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:11" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Function to generate serial number
        /// </summary>
        public void SlNo()
        {
            try
            {
                int inRowNo = 1;
                foreach (DataGridViewRow dr in dgvCreditNote.Rows)
                {
                    dr.Cells["dgvtxtSlNo"].Value = inRowNo;
                    inRowNo++;
                    if (dr.Index == dgvCreditNote.Rows.Count - 1)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:12" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        /// Function to calculate total debit and credit
        /// </summary>
        public void DebitAndCreditTotal()
        {
            ExchangeRateSP spExchangeRate = new ExchangeRateSP();
            int inRowCount = dgvCreditNote.RowCount;
            decimal decTxtTotalDebit = 0;
            decimal decTxtTotalCredit = 0;
            try
            {
                for (int inI = 0; inI < inRowCount; inI++)
                {
                    if (dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() != string.Empty)
                    {
                        if (dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString() != string.Empty)
                        {
                            if (dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString() != string.Empty)
                            {
                                if (dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
                                {
                                    //--------Currency conversion--------------//
                                    decSelectedCurrencyRate = spExchangeRate.GetExchangeRateByExchangeRateId(Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString()));
                                    decAmount = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                    decConvertRate = decAmount * decSelectedCurrencyRate;
                                    //===========================================//
                                    decTxtTotalDebit = decTxtTotalDebit + decConvertRate;

                                }
                                else
                                {
                                    //--------Currency conversion--------------//
                                    decSelectedCurrencyRate = spExchangeRate.GetExchangeRateByExchangeRateId(Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString()));
                                    decAmount = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                    decConvertRate = decAmount * decSelectedCurrencyRate;
                                    //===========================================//
                                    decTxtTotalCredit = decTxtTotalCredit + decConvertRate;
                                }
                            }
                        }
                    }
                    //txtDebitTotal.Text = Math.Round(decTxtTotalDebit, PublicVariables._inNoOfDecimalPlaces).ToString();
                    //txtCreditTotal.Text = Math.Round(decTxtTotalCredit, PublicVariables._inNoOfDecimalPlaces).ToString();
                    txtDebitTotal.Text = Math.Round(decTxtTotalDebit).ToString();
                    txtCreditTotal.Text = Math.Round(decTxtTotalCredit).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:13" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Function to call the SaveOrEditFunction by checking the negative balance
        /// </summary>
        public void SaveOrEdit()
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, this.Name, btnSave.Text))
                //{
                    //===================================
                    SettingsSP spSettings = new SettingsSP();
                    string strStatus = spSettings.SettingsStatusCheck("NegativeCashTransaction");
                    decimal decBalance = 0;
                    decimal decCalcAmount = 0;
                    AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                    bool isNegativeLedger = false;
                    int inRowCount = dgvCreditNote.RowCount;
                    for (int i = 0; i < inRowCount - 1; i++)
                    {
                        decimal decledgerId = 0;
                        if (dgvCreditNote.Rows[i].Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.Rows[i].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                        {
                            decledgerId = Convert.ToDecimal(dgvCreditNote.Rows[i].Cells["dgvcmbAccountLedger"].Value.ToString());
                        }
                        decBalance = spAccountLedger.CheckLedgerBalance(decledgerId);
                        if (dgvCreditNote.Rows[i].Cells["dgvtxtAmount"].Value != null && dgvCreditNote.Rows[i].Cells["dgvtxtAmount"].Value.ToString() != string.Empty)
                        {
                            decCalcAmount = decBalance - Convert.ToDecimal(dgvCreditNote.Rows[i].Cells["dgvtxtAmount"].Value.ToString());
                        }
                        if (decCalcAmount < 0)
                        {
                            isNegativeLedger = true;
                            break;
                        }
                    }
                    //===================================
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

                //}
                //else
                //{
                    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:14" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to determine whether to call savefunction or edit function
        /// </summary>
        public void SaveOrEditFunction()
        {
            try
            {
                CreditNoteMasterSP spCreditNoteMaster = new CreditNoteMasterSP();
               
                    if (!isEditMode)
                    {
                        if (txtVoucherNo.Text.Trim() != string.Empty)
                        {

                            if (!isAutomatic)
                            {
                                strInvoiceNo = txtVoucherNo.Text.Trim();
                                if (spCreditNoteMaster.CreditNoteCheckExistence(strInvoiceNo, decCreditNoteVoucherTypeId, 0) == false)
                                {
                                    SaveFunction();
                                }
                                else
                                {
                                    Messages.InformationMessage("Voucher number already exist");
                                }
                            }
                            else
                            {
                                SaveFunction();
                            }
                        }
                        else
                        {
                            Messages.InformationMessage("Enter voucherNo");
                            txtVoucherNo.Focus();
                        }
                    }
                    else
                    {
                        if (txtVoucherNo.Text.Trim() != string.Empty)
                        {
                            if (!isAutomatic)
                            {
                                strInvoiceNo = txtVoucherNo.Text.Trim();

                                if (spCreditNoteMaster.CreditNoteCheckExistence(strInvoiceNo, decCreditNoteVoucherTypeId, decCreditNoteMasterIdForEdit) == false)
                                {
                                    EditFunction(decCreditNoteMasterIdForEdit);
                                }
                                else
                                {
                                    Messages.InformationMessage("Voucher number already exist");
                                }
                            }
                            else
                            {
                                EditFunction(decCreditNoteMasterIdForEdit);
                            }
                        }
                        else
                        {
                            Messages.InformationMessage("Enter voucherNo");
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:15" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to call the Save by checking invalid entries
        /// </summary>
        public void SaveFunction()
        {

            ArrayList arrlstOfRowToRemove = new ArrayList();

            int inReadyForSave = 0;
            int inIsRowToRemove = 0;
            int inIfGridColumnMissing = 0;

            try
            {
                if (txtVoucherNo.Text.Trim() != string.Empty)
                {
                    if (!isEditMode)
                    {
                        decimal decTotalDebit = 0;
                        decimal decTotalCredit = 0;

                        int inRowCount = dgvCreditNote.RowCount;
                        for (int inI = 0; inI < inRowCount - 1; inI++)
                        {
                            if (dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value == null || dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString().Trim() == string.Empty)
                            {
                                arrlstOfRowToRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                                inIfGridColumnMissing = 1;
                                continue;
                            }
                            else if (dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value == null || dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString().Trim() == string.Empty)
                            {
                                arrlstOfRowToRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                                inIfGridColumnMissing = 1;
                                continue;
                            }

                            else if (dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value == null || dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString().Trim() == string.Empty)
                            {
                                arrlstOfRowToRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                                inIfGridColumnMissing = 1;
                                continue;
                            }
                            else if (dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value == null || dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].FormattedValue.ToString().Trim() == string.Empty)
                            {
                                arrlstOfRowToRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
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
                                int inDgvJournalRowCount = dgvCreditNote.RowCount;
                                int inK = 0;
                                for (int inI = 0; inI < inDgvJournalRowCount; inI++)
                                {
                                    if (inK == arrlstOfRowToRemove.Count)
                                    {
                                        break;
                                    }
                                    if (inDgvJournalRowCount > 0)
                                    {

                                        if (Convert.ToInt32(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString()) == Convert.ToInt32(arrlstOfRowToRemove[inK]))
                                        {
                                            inK++;
                                            if (dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString() != string.Empty)
                                            {
                                                arrlstOfRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString());
                                                arrlstOfRemovedLedgerPostingId.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value.ToString());
                                            }

                                            inTableRowCount = dtblPartyBalance.Rows.Count;
                                            for (int inJ = 0; inJ < inTableRowCount; inJ++)
                                            {
                                                if (dtblPartyBalance.Rows.Count == inJ)
                                                {
                                                    break;
                                                }
                                                if (dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                                                {
                                                    if (Convert.ToInt32(dtblPartyBalance.Rows[inJ]["LedgerId"].ToString()) == Convert.ToInt32(dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString()))
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
                                            dgvCreditNote.Rows.Remove(dgvCreditNote.Rows[inI]);
                                            inDgvJournalRowCount = dgvCreditNote.RowCount;
                                            inI--;

                                        }
                                    }
                                }
                                SlNo();

                            }
                            //============================================================//
                            int RowCount = dgvCreditNote.RowCount;
                            if (RowCount > 1)
                            {
                                decTotalDebit = Convert.ToDecimal(txtDebitTotal.Text.Trim());
                                decTotalCredit = Convert.ToDecimal(txtCreditTotal.Text.Trim());
                                if (decTotalCredit != 0 || decTotalDebit != 0)
                                {
                                    if (decTotalDebit == decTotalCredit)
                                    {
                                        //if (PublicVariables.isMessageAdd)
                                        //{
                                            if (Messages.SaveMessage())
                                            {
                                                Save();
                                                Clear();
                                            }
                                            else
                                            {
                                                dgvCreditNote.Focus();
                                            }
                                        //}
                                        //else
                                        //{

                                            Save();
                                            Clear();

                                        //}
                                    }

                                    else
                                    {
                                        Messages.InformationMessage("Total debit and total credit should be equal");
                                        dgvCreditNote.Focus();
                                    }
                                }
                                else
                                {
                                    Messages.InformationMessage("Cannot save total debit and credit as 0");

                                }
                            }
                            else
                            {
                                Messages.InformationMessage("Can't save credit not without atleast one row with complete details");
                            }
                            

                        }
                        

                    }

                }
                else
                {
                    Messages.InformationMessage("Enter voucherno.");
                    txtVoucherNo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:16" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Function to call the Edit by checking invalid entries
        /// </summary>
        /// <param name="decCreditNoteMasterId"></param>
        public void EditFunction(decimal decCreditNoteMasterId)
        {
            try
            {
                ArrayList arrlstOfRowToRemove = new ArrayList();
                int inReadyForSave = 0;
                int inIsRowToRemove = 0;
                int inIfGridColumnMissing = 0;

                decimal decTotalDebit = 0;
                decimal decTotalCredit = 0;



                int inRowCount = dgvCreditNote.RowCount;
                for (int inI = 0; inI < inRowCount - 1; inI++)
                {
                    if (dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value == null || dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString().Trim() == string.Empty)
                    {
                        arrlstOfRowToRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                        inIfGridColumnMissing = 1;
                        continue;
                    }
                    else if (dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value == null || dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString().Trim() == string.Empty)
                    {
                        arrlstOfRowToRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                        inIfGridColumnMissing = 1;
                        continue;
                    }

                    else if (dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value == null || dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString().Trim() == string.Empty)
                    {
                        arrlstOfRowToRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
                        inIfGridColumnMissing = 1;
                        continue;
                    }
                    else if (dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value == null || dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].FormattedValue.ToString().Trim() == string.Empty)
                    {
                        arrlstOfRowToRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString());
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
                        int inDgvJournalRowCount = dgvCreditNote.RowCount;
                        int inK = 0;
                        for (int inI = 0; inI < inDgvJournalRowCount; inI++)
                        {
                            if (inK == arrlstOfRowToRemove.Count)
                            {
                                break;
                            }
                            if (inDgvJournalRowCount > 0)
                            {

                                if (Convert.ToInt32(dgvCreditNote.Rows[inI].Cells["dgvtxtSlNo"].Value.ToString()) == Convert.ToInt32(arrlstOfRowToRemove[inK]))
                                {
                                    inK++;
                                    if (dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString() != string.Empty)
                                    {
                                        arrlstOfRemove.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString());
                                        arrlstOfRemovedLedgerPostingId.Add(dgvCreditNote.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value.ToString());
                                    }

                                    inTableRowCount = dtblPartyBalance.Rows.Count;
                                    for (int inJ = 0; inJ < inTableRowCount; inJ++)
                                    {
                                        if (dtblPartyBalance.Rows.Count == inJ)
                                        {
                                            break;
                                        }
                                        if (dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                                        {
                                            if (dtblPartyBalance.Rows[inJ]["LedgerId"].ToString() == dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString())
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
                                    dgvCreditNote.Rows.RemoveAt(dgvCreditNote.Rows[inI].Index);
                                    inDgvJournalRowCount = dgvCreditNote.RowCount;
                                    inI--;
                                }
                            }
                        }
                        SlNo();
                    }
                    //============================================================//
                    inRowCount = dgvCreditNote.RowCount;
                    if (inRowCount > 1)
                    {
                        decTotalDebit = Convert.ToDecimal(txtDebitTotal.Text.Trim());
                        decTotalCredit = Convert.ToDecimal(txtCreditTotal.Text.Trim());
                        if (decTotalDebit == decTotalCredit)
                        {
                            //if (PublicVariables.isMessageEdit)
                            //{
                                if (Messages.UpdateMessage())
                                {
                                    DeletePartyBalanceOfRemovedRow();
                                    Edit(decCreditNoteMasterIdForEdit);
                                }
                                else
                                {
                                    dgvCreditNote.Focus();
                                }
                            //}
                            //else
                            //{
                                DeletePartyBalanceOfRemovedRow();
                                Edit(decCreditNoteMasterIdForEdit);
                            //}
                        }
                        else
                        {
                            Messages.InformationMessage("Total debit and total credit should be equal");
                            dgvCreditNote.Focus();
                            return;
                        }
                    }
                    else
                    {
                        Messages.InformationMessage("Can't save credit not without atleast one row with complete details");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:17" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Function for ledger posting
        /// </summary>
        /// <param name="decId"></param>
        /// <param name="decCredit"></param>
        /// <param name="decDebit"></param>
        /// <param name="decDetailsId"></param>
        /// <param name="inA"></param>
        public void LedgerPosting(decimal decId, decimal decCredit, decimal decDebit, decimal decDetailsId, int inA)
        {
            LedgerPostingSP spLedgerPosting = new LedgerPostingSP();
            LedgerPosting infoLedgerPosting = new LedgerPosting();
            ExchangeRateSP SpExchangRate = new ExchangeRateSP();
            decimal decOldExchange = 0;
            decimal decNewExchangeRate = 0;
            decimal decNewExchangeRateId = 0;
            decimal decOldExchangeId = 0;
            try
            {


                if (!dgvCreditNote.Rows[inA].Cells["dgvtxtAmount"].ReadOnly)
                {
                    infoLedgerPosting.date = DateTime.Now;
                    infoLedgerPosting.voucherTypeId = decCreditNoteVoucherTypeId;
                    infoLedgerPosting.voucherNo = strVoucherNo;
                    infoLedgerPosting.detailsId = decDetailsId;
                    infoLedgerPosting.yearId = Utils.getManagement().FinancialYear.financialYearId;
                    infoLedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();

                    if (dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        infoLedgerPosting.chequeNo = dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            infoLedgerPosting.chequeDate = Convert.ToDateTime(dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            infoLedgerPosting.chequeDate = DateTime.Now;

                    }
                    else
                    {
                        infoLedgerPosting.chequeNo = string.Empty;
                        infoLedgerPosting.chequeDate = DateTime.Now;
                    }

                    infoLedgerPosting.ledgerId = decId;
                    infoLedgerPosting.credit = decCredit;
                    infoLedgerPosting.debit = decDebit;

                    spLedgerPosting.LedgerPostingAdd(infoLedgerPosting);
                }
                else
                {
                    infoLedgerPosting.date = DateTime.Now;
                    infoLedgerPosting.voucherTypeId = decCreditNoteVoucherTypeId;
                    infoLedgerPosting.voucherNo = strVoucherNo;
                    infoLedgerPosting.detailsId = decDetailsId;
                    infoLedgerPosting.yearId = Utils.getManagement().FinancialYear.financialYearId;
                    infoLedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();

                    if (dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        infoLedgerPosting.chequeNo = dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            infoLedgerPosting.chequeDate = Convert.ToDateTime(dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            infoLedgerPosting.chequeDate = DateTime.Now;

                    }
                    else
                    {
                        infoLedgerPosting.chequeNo = string.Empty;
                        infoLedgerPosting.chequeDate = DateTime.Now;
                    }
                    
                    infoLedgerPosting.ledgerId = decId;

                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (infoLedgerPosting.ledgerId == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            decOldExchange = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                            decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                            decSelectedCurrencyRate = SpExchangRate.GetExchangeRateByExchangeRateId(decOldExchange);
                            decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                            decConvertRate = decConvertRate + (decAmount * decSelectedCurrencyRate);

                        }
                    }

                    if (decCredit == 0)
                    {
                        infoLedgerPosting.credit = 0;
                        infoLedgerPosting.debit = decConvertRate;
                    }
                    else
                    {
                        infoLedgerPosting.debit = 0;
                        infoLedgerPosting.credit = decConvertRate;
                    }


                    spLedgerPosting.LedgerPostingAdd(infoLedgerPosting);

                    infoLedgerPosting.ledgerId = 12;
                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (Convert.ToDecimal(dgvCreditNote.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString()) == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            if (dr["ReferenceType"].ToString() == "Against")
                            {
                                decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                                decNewExchangeRate = SpExchangRate.GetExchangeRateByExchangeRateId(decNewExchangeRateId);
                                decOldExchangeId = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                                decOldExchange = SpExchangRate.GetExchangeRateByExchangeRateId(decOldExchangeId);
                                decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                                decimal decForexAmount = (decAmount * decNewExchangeRate) - (decAmount * decOldExchange);
                                if (dr["DebitOrCredit"].ToString() == "Dr")
                                {
                                    if (decForexAmount >= 0)
                                    {

                                        infoLedgerPosting.debit = decForexAmount;
                                        infoLedgerPosting.credit = 0;
                                    }
                                    else
                                    {
                                        infoLedgerPosting.credit = -1 * decForexAmount;
                                        infoLedgerPosting.debit = 0;
                                    }
                                }
                                else
                                {
                                    if (decForexAmount >= 0)
                                    {

                                        infoLedgerPosting.credit = decForexAmount;
                                        infoLedgerPosting.debit = 0;
                                    }
                                    else
                                    {
                                        infoLedgerPosting.debit = -1 * decForexAmount;
                                        infoLedgerPosting.credit = 0;
                                    }
                                }
                                spLedgerPosting.LedgerPostingAdd(infoLedgerPosting);
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:18" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Function for ledgerposting edit
        /// </summary>
        /// <param name="decLedgerPostingId"></param>
        /// <param name="decLedgerId"></param>
        /// <param name="decCredit"></param>
        /// <param name="decDebit"></param>
        /// <param name="decDetailsId"></param>
        /// <param name="inA"></param>
        public void LedgerPostingEdit(decimal decLedgerPostingId, decimal decLedgerId, decimal decCredit, decimal decDebit, decimal decDetailsId, int inA)
        {
            LedgerPostingSP spLedgerPosting = new LedgerPostingSP();
            LedgerPosting infoLedgerPosting = new LedgerPosting();
            ExchangeRateSP SpExchangRate = new ExchangeRateSP();
            decimal decOldExchange = 0;
            decimal decNewExchangeRate = 0;
            decimal decNewExchangeRateId = 0;
            decimal decOldExchangeId = 0;
            try
            {


                if (!dgvCreditNote.Rows[inA].Cells["dgvtxtAmount"].ReadOnly)
                {
                    infoLedgerPosting.ledgerPostingId = decLedgerPostingId;
                    infoLedgerPosting.date = DateTime.Now;
                    infoLedgerPosting.voucherTypeId = decCreditNoteVoucherTypeId;
                    infoLedgerPosting.voucherNo = strVoucherNo;
                    infoLedgerPosting.detailsId = decDetailsId;
                    infoLedgerPosting.yearId = Utils.getManagement().FinancialYear.financialYearId;
                    infoLedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();

                    if (dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        infoLedgerPosting.chequeNo = dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            infoLedgerPosting.chequeDate = Convert.ToDateTime(dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            infoLedgerPosting.chequeDate = DateTime.Now;

                    }
                    else
                    {
                        infoLedgerPosting.chequeNo = string.Empty;
                        infoLedgerPosting.chequeDate = DateTime.Now;
                    }
                    
                    infoLedgerPosting.ledgerId = decLedgerId;
                    infoLedgerPosting.credit = decCredit;
                    infoLedgerPosting.debit = decDebit;

                    spLedgerPosting.LedgerPostingEdit(infoLedgerPosting);
                }
                else
                {
                    infoLedgerPosting.ledgerPostingId = decLedgerPostingId;
                    infoLedgerPosting.date = DateTime.Now;
                    infoLedgerPosting.voucherTypeId = decCreditNoteVoucherTypeId;
                    infoLedgerPosting.voucherNo = strVoucherNo;
                    infoLedgerPosting.detailsId = decDetailsId;
                    infoLedgerPosting.yearId = Utils.getManagement().FinancialYear.financialYearId;
                    infoLedgerPosting.invoiceNo = txtVoucherNo.Text.Trim();

                    if (dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value != null && dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                    {
                        infoLedgerPosting.chequeNo = dgvCreditNote.Rows[inA].Cells["dgvtxtChequeNo"].Value.ToString();
                        if (dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value != null && dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                        {
                            infoLedgerPosting.chequeDate = Convert.ToDateTime(dgvCreditNote.Rows[inA].Cells["dgvtxtChequeDate"].Value.ToString());
                        }
                        else
                            infoLedgerPosting.chequeDate = DateTime.Now;

                    }
                    else
                    {
                        infoLedgerPosting.chequeNo = string.Empty;
                        infoLedgerPosting.chequeDate = DateTime.Now;
                    }
                    
                    infoLedgerPosting.ledgerId = decLedgerId;

                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (infoLedgerPosting.ledgerId == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            decOldExchange = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                            decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                            decSelectedCurrencyRate = SpExchangRate.GetExchangeRateByExchangeRateId(decOldExchange);
                            decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                            decConvertRate = decConvertRate + (decAmount * decSelectedCurrencyRate);

                        }
                    }

                    if (decCredit == 0)
                    {
                        infoLedgerPosting.credit = 0;
                        infoLedgerPosting.debit = decConvertRate;
                    }
                    else
                    {
                        infoLedgerPosting.debit = 0;
                        infoLedgerPosting.credit = decConvertRate;
                    }


                    spLedgerPosting.LedgerPostingEdit(infoLedgerPosting);

                    infoLedgerPosting.ledgerId = 12;
                    foreach (DataRow dr in dtblPartyBalance.Rows)
                    {
                        if (Convert.ToDecimal(dgvCreditNote.Rows[inA].Cells["dgvcmbAccountLedger"].Value.ToString()) == Convert.ToDecimal(dr["LedgerId"].ToString()))
                        {
                            if (dr["ReferenceType"].ToString() == "Against")
                            {
                                decNewExchangeRateId = Convert.ToDecimal(dr["CurrencyId"].ToString());
                                decNewExchangeRate = SpExchangRate.GetExchangeRateByExchangeRateId(decNewExchangeRateId);
                                decOldExchangeId = Convert.ToDecimal(dr["OldExchangeRate"].ToString());
                                decOldExchange = SpExchangRate.GetExchangeRateByExchangeRateId(decOldExchangeId);
                                decAmount = Convert.ToDecimal(dr["Amount"].ToString());
                                decimal decForexAmount = (decAmount * decNewExchangeRate) - (decAmount * decOldExchange);
                                if (dr["DebitOrCredit"].ToString() == "Dr")
                                {
                                    if (decForexAmount >= 0)
                                    {

                                        infoLedgerPosting.debit = decForexAmount;
                                        infoLedgerPosting.credit = 0;
                                    }
                                    else
                                    {
                                        infoLedgerPosting.credit = -1 * decForexAmount;
                                        infoLedgerPosting.debit = 0;
                                    }
                                }
                                else
                                {
                                    if (decForexAmount >= 0)
                                    {

                                        infoLedgerPosting.credit = decForexAmount;
                                        infoLedgerPosting.debit = 0;
                                    }
                                    else
                                    {
                                        infoLedgerPosting.debit = -1 * decForexAmount;
                                        infoLedgerPosting.credit = 0;
                                    }
                                }
                                spLedgerPosting.LedgerPostingAdd(infoLedgerPosting);
                            }
                        }

                    }

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:19" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Function to save party balance details
        /// </summary>
        /// <param name="inRowIndex"></param>
        /// <param name="inJ"></param>
        public void PartyBalanceAdd(int inRowIndex, int inJ)
        {
            int inTableRowCount = dtblPartyBalance.Rows.Count;
            PartyBalanceSP spPartyBalance = new PartyBalanceSP();
            PartyBalance InfopartyBalance = new PartyBalance();
            try
            {
                InfopartyBalance.creditPeriod = 0;//
                InfopartyBalance.date = dtpVoucherDate.Value;
                InfopartyBalance.ledgerId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["LedgerId"].ToString());
                InfopartyBalance.referenceType = dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString();
                if (dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "New" || dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "OnAccount")
                {
                    InfopartyBalance.againstInvoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
                    InfopartyBalance.againstVoucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                    InfopartyBalance.againstVoucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());//decPaymentVoucherTypeId;
                    InfopartyBalance.voucherTypeId = decCreditNoteVoucherTypeId;
                    InfopartyBalance.invoiceNo = strInvoiceNo;
                    InfopartyBalance.voucherNo = strVoucherNo;
                }
                else
                {
                    InfopartyBalance.exchangeRateId = Convert.ToInt32(dtblPartyBalance.Rows[inJ]["OldExchangeRate"].ToString());
                    InfopartyBalance.againstInvoiceNo = strInvoiceNo;
                    InfopartyBalance.againstVoucherNo = strVoucherNo;
                    InfopartyBalance.againstVoucherTypeId = decCreditNoteVoucherTypeId;
                    InfopartyBalance.voucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());
                    InfopartyBalance.voucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                    InfopartyBalance.invoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
                }
                if (dgvCreditNote.Rows[inRowIndex].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
                {
                    InfopartyBalance.debit = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["Amount"].ToString());
                    InfopartyBalance.credit = 0;
                }
                else
                {
                    InfopartyBalance.credit = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["Amount"].ToString());
                    InfopartyBalance.debit = 0;
                }
                InfopartyBalance.financialYearId = Utils.getManagement().FinancialYear.financialYearId;
                spPartyBalance.PartyBalanceAdd(InfopartyBalance);


            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:20" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to print the voucher
        /// </summary>
        /// <param name="decMasterId"></param>
        public void Print(decimal decMasterId)
        {
            try
            {
                //CreditNoteMasterSP spCreditNoteMaster = new CreditNoteMasterSP();
                //DataSet dsCreditNote = spCreditNoteMaster.CreditNotePrinting(decMasterId, 1);
                //frmReport frmReport = new frmReport();
                //frmReport.MdiParent = formMDI.MDIObj;
                //frmReport.CreditNotePrinting(dsCreditNote);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:21" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to print the voucher in dotmatrix printer
        /// </summary>
        /// <param name="decMasterId"></param>
        public void PrintForDotMatrix(decimal decMasterId)
        {
            try
            {

                DataTable dtblOtherDetails = new DataTable();
                CompanySP spComapany = new CompanySP();
                dtblOtherDetails = spComapany.CompanyViewForDotMatrix();
                //-------------Grid Details-------------------\\
                DataTable dtblGridDetails = new DataTable();
                dtblGridDetails.Columns.Add("SlNo");
                dtblGridDetails.Columns.Add("Account Ledger");
                dtblGridDetails.Columns.Add("CrOrDr");
                dtblGridDetails.Columns.Add("Amount");
                dtblGridDetails.Columns.Add("Currency");
                dtblGridDetails.Columns.Add("Cheque No");
                dtblGridDetails.Columns.Add("Cheque Date");
                int inRowCount = 0;
                foreach (DataGridViewRow dRow in dgvCreditNote.Rows)
                {
                    if (dRow.HeaderCell.Value != null && dRow.HeaderCell.Value.ToString() != "X")
                    {
                        if (!dRow.IsNewRow)
                        {
                            DataRow dr = dtblGridDetails.NewRow();
                            dr["SlNo"] = ++inRowCount;
                            dr["Account Ledger"] = dRow.Cells["dgvcmbAccountLedger"].FormattedValue as string;
                            dr["CrOrDr"] = dRow.Cells["dgvcmbDrOrCr"].Value as string;
                            dr["Amount"] = dRow.Cells["dgvtxtAmount"].Value as string;
                            dr["Currency"] = dRow.Cells["dgvcmbCurrency"].FormattedValue as string;
                            dr["Cheque No"] = (dRow.Cells["dgvtxtChequeNo"].Value == null ? "" : dRow.Cells["dgvtxtChequeNo"].Value as string );
                            dr["Cheque Date"] = (dRow.Cells["dgvtxtChequeDate"].Value == null ? "" : dRow.Cells["dgvtxtChequeDate"].Value as string);
                            dtblGridDetails.Rows.Add(dr);
                        }
                    }
                }


                //-------------Other Details-------------------\\

                dtblOtherDetails.Columns.Add("voucherNo");
                dtblOtherDetails.Columns.Add("date");
                dtblOtherDetails.Columns.Add("DebitTotal");
                dtblOtherDetails.Columns.Add("CreditTotal");
                dtblOtherDetails.Columns.Add("Narration");
                dtblOtherDetails.Columns.Add("DebitAmountInWords");
                dtblOtherDetails.Columns.Add("CreditAmountInWords");
                dtblOtherDetails.Columns.Add("Declaration");
                dtblOtherDetails.Columns.Add("Heading1");
                dtblOtherDetails.Columns.Add("Heading2");
                dtblOtherDetails.Columns.Add("Heading3");
                dtblOtherDetails.Columns.Add("Heading4");
                DataRow dRowOther = dtblOtherDetails.Rows[0];
                dRowOther["voucherNo"] = txtVoucherNo.Text;
                dRowOther["date"] = txtDate.Text;
                dRowOther["DebitTotal"] = txtDebitTotal.Text;
                dRowOther["CreditTotal"] = txtCreditTotal.Text;
                dRowOther["Narration"] = txtNarration.Text;
                dRowOther["DebitAmountInWords"] = new NumToText().AmountWords(Convert.ToDecimal(txtDebitTotal.Text), Utils.getCurrentUser().WorkerID);
                dRowOther["CreditAmountInWords"] = new NumToText().AmountWords(Convert.ToDecimal(txtCreditTotal.Text), Utils.getCurrentUser().WorkerID);
                dRowOther["address"] = (dtblOtherDetails.Rows[0]["address"].ToString().Replace("\n", ", ")).Replace("\r", "");


                VoucherTypeSP spVoucherType = new VoucherTypeSP();
                DataTable dtblDeclaration = spVoucherType.DeclarationAndHeadingGetByVoucherTypeId(decCreditNoteVoucherTypeId);
                dRowOther["Declaration"] = dtblDeclaration.Rows[0]["Declaration"].ToString();
                dRowOther["Heading1"] = dtblDeclaration.Rows[0]["Heading1"].ToString();
                dRowOther["Heading2"] = dtblDeclaration.Rows[0]["Heading2"].ToString();
                dRowOther["Heading3"] = dtblDeclaration.Rows[0]["Heading3"].ToString();
                dRowOther["Heading4"] = dtblDeclaration.Rows[0]["Heading4"].ToString();
                int inFormId = spVoucherType.FormIdGetForPrinterSettings(Convert.ToInt32(dtblDeclaration.Rows[0]["masterId"].ToString()));
              //  PrintWorks.DotMatrixPrint.PrintDesign(inFormId, dtblOtherDetails, dtblGridDetails, dtblOtherDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:22" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to check invalid entries
        /// </summary>
        /// <param name="e"></param>
        public void CheckColumnMissing(DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCreditNote.CurrentRow != null)
                {
                    if (!isValueChanged)
                    {
                        if (dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value == null || dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvCreditNote.CurrentRow.HeaderCell.Value = "X";
                            dgvCreditNote.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;
                        }
                        else if (dgvCreditNote.CurrentRow.Cells["dgvcmbDrOrCr"].Value == null || dgvCreditNote.CurrentRow.Cells["dgvcmbDrOrCr"].Value.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvCreditNote.CurrentRow.HeaderCell.Value = "X";
                            dgvCreditNote.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;
                        }
                        else if (dgvCreditNote.CurrentRow.Cells["dgvtxtAmount"].Value == null || dgvCreditNote.CurrentRow.Cells["dgvtxtAmount"].Value.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvCreditNote.CurrentRow.HeaderCell.Value = "X";
                            dgvCreditNote.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;

                        }
                        else if (dgvCreditNote.CurrentRow.Cells["dgvcmbCurrency"].Value == null || dgvCreditNote.CurrentRow.Cells["dgvcmbCurrency"].FormattedValue.ToString().Trim() == string.Empty)
                        {
                            isValueChanged = true;
                            dgvCreditNote.CurrentRow.HeaderCell.Value = "X";
                            dgvCreditNote.CurrentRow.HeaderCell.Style.ForeColor = Color.Red;

                        }

                        else
                        {
                            isValueChanged = true;
                            dgvCreditNote.CurrentRow.HeaderCell.Value = string.Empty;
                        }

                    }
                    isValueChanged = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:23" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to delete a voucher
        /// </summary>
        /// <param name="decCreditNoteMasterId"></param>
        public void DeleteFunction(decimal decCreditNoteMasterId)
        {
            try
            {
                CreditNoteMasterSP spCreditNoteMaster = new CreditNoteMasterSP();
                PartyBalanceSP spPartyBalance = new PartyBalanceSP();
                if (!spPartyBalance.PartyBalanceCheckReference(decCreditNoteVoucherTypeId, strVoucherNo))
                {
                    spCreditNoteMaster.CreditNoteVoucherDelete(decCreditNoteMasterId, decCreditNoteVoucherTypeId, strVoucherNo);
                    Messages.DeletedMessage();
                    if (CreditNoteRegisterObj != null)
                    {
                        this.Close();
                        CreditNoteRegisterObj.Enabled = true;
                    }
                    else if (frmCreditNoteReportObj != null)
                    {
                        this.Close();
                        frmCreditNoteReportObj.Enabled = true;
                    }
                    else  if (objVoucherSearch != null)
                    {
                        this.Close();
                        objVoucherSearch.GridFill();
                    }
                    //else if (frmDayBookObj != null)
                    //{
                    //    this.Close();
                    //}
                    //else if (frmBillallocationObj != null)
                    //{
                    //    this.Close();
                    //}
                    //else if (frmLedgerDetailsObj != null)
                    //{
                    //    this.Close();
                    //}
                    else
                    {
                        Clear();
                    }
                }
                else
                {
                    Messages.InformationMessage("Reference exist. Cannot delete");
                    txtDate.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:24" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function for decimal validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keypressevent(object sender, KeyPressEventArgs e)
        {
            try
            {
                Common.DecimalValidation(sender, e, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:25" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to add the new accountledger from accountLedger form
        /// </summary>
        /// <param name="decLedgerId"></param>
        public void CallFromAccountLedger(decimal decLedgerId)
        {
            try
            {
                if (decLedgerId != 0)
                {
                    AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                    DataTable dtbl = new DataTable();
                    dtbl = spAccountLedger.AccountLedgerViewAll();
                    DataGridViewComboBoxCell dgvccAccountLedger = (DataGridViewComboBoxCell)dgvCreditNote[dgvCreditNote.Columns["dgvcmbAccountLedger"].Index, dgvCreditNote.CurrentRow.Index];
                    dgvccAccountLedger.DataSource = dtbl;
                    dgvccAccountLedger.ValueMember = "ledgerId";
                    dgvccAccountLedger.DisplayMember = "ledgerName";
                    dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value = decLedgerId;
                }
                this.Enabled = true;
                dgvCreditNote.Focus();
                this.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:26" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to set the voucher date
        /// </summary>
        public void VoucherDate()
        {
            //try
            //{
                dtpVoucherDate.Value = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy"));
                dtpVoucherDate.MinDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                dtpVoucherDate.MaxDate = (DateTime)Utils.getManagement().FinancialYear.toDate;
                //Company infoComapany = new CompanyInfo();
                //CompanySP spCompany = new CompanySP();
                //infoComapany = spCompany.CompanyView(1);
                //DateTime dtVoucherDate = infoComapany.CurrentDate;
                //dtpVoucherDate.Value = dtVoucherDate;
                txtDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                txtDate.Focus();
                txtDate.SelectAll();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("CRNT:27" + ex.Message, "Open Miracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        /// <summary>
        /// Function to load the voucher to edit or delete while calling from the creditnote report
        /// </summary>
        /// <param name="frmCreditNoteReport"></param>
        /// <param name="decCreditNoteMasterId"></param>
        public void CallFromCreditNoteReport(frmCreditNoteReport frmCreditNoteReport, decimal decCreditNoteMasterId)
        {
            try
            {
                base.Show();

                isEditMode = true;
                btnDelete.Enabled = true;
                frmCreditNoteReportObj = frmCreditNoteReport;
                frmCreditNoteReportObj.Enabled = false;
                decCreditNoteMasterIdForEdit = decCreditNoteMasterId;
                FillFunction();


            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:28" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to remove a row
        /// </summary>
        public void RemoveRow()
        {
            try
            {
                int inRowCount = dgvCreditNote.RowCount;
                if (inRowCount > 1)
                {
                    if (int.Parse(dgvCreditNote.CurrentRow.Cells["dgvtxtSlNo"].Value.ToString()) < inRowCount)
                    {
                        if (dgvCreditNote.CurrentRow.Cells["dgvtxtDetailsId"].Value != null && dgvCreditNote.CurrentRow.Cells["dgvtxtDetailsId"].Value.ToString() != string.Empty)
                        {
                            arrlstOfRemove.Add(dgvCreditNote.CurrentRow.Cells["dgvtxtDetailsId"].Value.ToString());
                            arrlstOfRemovedLedgerPostingId.Add(dgvCreditNote.CurrentRow.Cells["dgvtxtLedgerPostingId"].Value.ToString());
                        }


                        int inTableRowCount = dtblPartyBalance.Rows.Count;
                        for (int inI = 0; inI < inTableRowCount; inI++)
                        {
                            if (dtblPartyBalance.Rows.Count == inI)
                            {
                                break;
                            }
                            if (dtblPartyBalance.Rows[inI]["LedgerId"].ToString() == dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString())
                            {
                                if (dtblPartyBalance.Rows[inI]["PartyBalanceId"].ToString() != "0")
                                {
                                    arrlstOfDeletedPartyBalanceRow.Add(dtblPartyBalance.Rows[inI]["PartyBalanceId"]);
                                }
                                dtblPartyBalance.Rows.RemoveAt(inI);
                                inI--;
                            }
                        }
                        if (inUpdatingRowIndexForPartyRemove == dgvCreditNote.CurrentRow.Index)
                        {
                            inUpdatingRowIndexForPartyRemove = -1;
                            decUpdatingLedgerForPartyremove = 0;
                        }
                        dgvCreditNote.Rows.RemoveAt(dgvCreditNote.CurrentRow.Index);
                        SlNo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:29" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to to enable keypress in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keypresseventEnable(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:30" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to save the voucher
        /// </summary>
        public void Save()
        {
            try
            {
                decimal decTotalDebit = 0;
                decimal decTotalCredit = 0;

                decTotalDebit = Convert.ToDecimal(txtDebitTotal.Text.Trim());
                decTotalCredit = Convert.ToDecimal(txtCreditTotal.Text.Trim());

                CreditNoteMasterSP spCreditNoteMaster = new CreditNoteMasterSP();
                CreditNoteDetailsSP spCreditNoteDetails = new CreditNoteDetailsSP();
                CreditNoteMaster infoCreditNoteMaster = new CreditNoteMaster();
                CreditNoteDetail infoCreditNoteDetails = new CreditNoteDetail();
                PartyBalanceSP SpPartyBalance = new PartyBalanceSP();
                PartyBalance InfopartyBalance = new PartyBalance();
                ExchangeRateSP spExchangeRate = new ExchangeRateSP();

                infoCreditNoteMaster.voucherNo = strVoucherNo;
                infoCreditNoteMaster.invoiceNo = txtVoucherNo.Text.Trim();
                infoCreditNoteMaster.suffixPrefixId = decCreditNoteSuffixPrefixId;
                infoCreditNoteMaster.date = Convert.ToDateTime(txtDate.Text);
                infoCreditNoteMaster.narration = txtNarration.Text.Trim();
                infoCreditNoteMaster.userId = Utils.getCurrentUser().WorkerID;
                infoCreditNoteMaster.voucherTypeId = decCreditNoteVoucherTypeId;
                infoCreditNoteMaster.financialYearId = Convert.ToDecimal(Utils.getManagement().FinancialYear.financialYearId);
                


                infoCreditNoteMaster.totalAmount = decTotalDebit;
                decimal decCreditNoteMasterId = spCreditNoteMaster.CreditNoteMasterAdd(infoCreditNoteMaster);

                /*******************CreditNote Details Add and LedgerPosting*************************/
                infoCreditNoteDetails.creditNoteMasterId = decCreditNoteMasterId;
               

                decimal decLedgerId = 0;
                decimal decDebit = 0;
                decimal decCredit = 0;
                int inRowCount = dgvCreditNote.RowCount;
                for (int inI = 0; inI < inRowCount - 1; inI++)
                {
                    if (dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {
                        infoCreditNoteDetails.ledgerId = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString());
                        decLedgerId = Convert.ToDecimal(infoCreditNoteDetails.ledgerId);
                    }
                    if (dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() != string.Empty)
                    {
                        if (dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString() != string.Empty)
                        {
                            //--------Currency conversion--------------//
                            decSelectedCurrencyRate = spExchangeRate.GetExchangeRateByExchangeRateId(Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString()));
                            decAmount = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                            decConvertRate = decAmount * decSelectedCurrencyRate;
                            //===========================================//
                            if (dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
                            {
                                infoCreditNoteDetails.debit = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                infoCreditNoteDetails.credit = 0;
                                decDebit = decConvertRate;
                                decCredit = Convert.ToDecimal(infoCreditNoteDetails.credit);
                            }
                            else
                            {
                                infoCreditNoteDetails.credit = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                infoCreditNoteDetails.debit = 0;
                                decDebit = Convert.ToDecimal(infoCreditNoteDetails.debit);
                                decCredit = decConvertRate;
                            }
                        }
                        infoCreditNoteDetails.exchangeRateId = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                        if (dgvCreditNote.Rows[inI].Cells["dgvtxtChequeNo"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                        {
                            infoCreditNoteDetails.chequeNo = dgvCreditNote.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString();
                            if (dgvCreditNote.Rows[inI].Cells["dgvtxtChequeDate"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                            {
                                infoCreditNoteDetails.chequeDate = Convert.ToDateTime(dgvCreditNote.Rows[inI].Cells["dgvtxtChequeDate"].Value);
                            }
                            else
                            {
                                infoCreditNoteDetails.chequeDate = DateTime.Now;
                            }
                        }
                        else
                        {
                            infoCreditNoteDetails.chequeNo = string.Empty;
                            infoCreditNoteDetails.chequeDate = DateTime.Now;
                        }
                        decimal decDetailsId = spCreditNoteDetails.CreditNoteDetailsAdd(infoCreditNoteDetails);

                        if (decDetailsId != 0)
                        {
                            PartyBalanceAddOrEdit(inI);
                            LedgerPosting(decLedgerId, decCredit, decDebit, decDetailsId, inI);
                        }
                    }

                }

                Messages.SavedMessage();


                //----------------If print after save is enable-----------------------//
                SettingsSP spSettings = new SettingsSP();
                if (cbxPrintAfterSave.Checked)
                {
                    if (spSettings.SettingsStatusCheck("Printer") == "Dot Matrix")
                    {
                        PrintForDotMatrix(decCreditNoteMasterId);
                    }
                    else
                    {
                        Print(decCreditNoteMasterId);
                    }
                }

                //===================================================================//
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:31" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Function to call the partybalance add or edit
        /// </summary>
        /// <param name="inRowIndex"></param>
        public void PartyBalanceAddOrEdit(int inRowIndex)
        {
            int inTableRowCount = dtblPartyBalance.Rows.Count;

            try
            {
                for (int inJ = 0; inJ < inTableRowCount; inJ++)
                {
                    if (dgvCreditNote.Rows[inRowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() == dtblPartyBalance.Rows[inJ]["LedgerId"].ToString())
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
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:32" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Function to edit partybalance entries
        /// </summary>
        /// <param name="decPartyBalanceId"></param>
        /// <param name="inRowIndex"></param>
        /// <param name="inJ"></param>
        public void PartyBalanceEdit(decimal decPartyBalanceId, int inRowIndex, int inJ)
        {

            PartyBalanceSP spPartyBalance = new PartyBalanceSP();
            PartyBalance InfopartyBalance = new PartyBalance();
            try
            {
                InfopartyBalance.partyBalanceId = decPartyBalanceId;
                InfopartyBalance.creditPeriod = 0;//
                InfopartyBalance.date = dtpVoucherDate.Value;
                InfopartyBalance.ledgerId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["LedgerId"].ToString());
                InfopartyBalance.referenceType = dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString();
                if (dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "New" || dtblPartyBalance.Rows[inJ]["ReferenceType"].ToString() == "OnAccount")
                {
                    InfopartyBalance.againstInvoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
                    InfopartyBalance.againstVoucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                    InfopartyBalance.againstVoucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());//decPaymentVoucherTypeId;
                    InfopartyBalance.voucherTypeId = decCreditNoteVoucherTypeId;
                    InfopartyBalance.invoiceNo = strInvoiceNo;
                    InfopartyBalance.voucherNo = strVoucherNo;
                }
                else
                {
                    InfopartyBalance.exchangeRateId = Convert.ToInt32(dtblPartyBalance.Rows[inJ]["OldExchangeRate"].ToString());
                    InfopartyBalance.againstInvoiceNo = strInvoiceNo;
                    InfopartyBalance.againstVoucherNo = strVoucherNo;
                    InfopartyBalance.againstVoucherTypeId = decCreditNoteVoucherTypeId;
                    InfopartyBalance.voucherTypeId = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["AgainstVoucherTypeId"].ToString());
                    InfopartyBalance.voucherNo = dtblPartyBalance.Rows[inJ]["AgainstVoucherNo"].ToString();
                    InfopartyBalance.invoiceNo = dtblPartyBalance.Rows[inJ]["AgainstInvoiceNo"].ToString();
                }
                if (dgvCreditNote.Rows[inRowIndex].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
                {
                    InfopartyBalance.debit = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["Amount"].ToString());
                    InfopartyBalance.credit = 0;
                }
                else
                {
                    InfopartyBalance.credit = Convert.ToDecimal(dtblPartyBalance.Rows[inJ]["Amount"].ToString());
                    InfopartyBalance.debit = 0;
                }
                InfopartyBalance.financialYearId = Convert.ToDecimal(Utils.getManagement().FinancialYear.fromDate);
                spPartyBalance.PartyBalanceEdit(InfopartyBalance);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:33" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to delete partybalance of removed row
        /// </summary>
        public void DeletePartyBalanceOfRemovedRow()
        {
            PartyBalanceSP spPartyBalance = new PartyBalanceSP();
            try
            {
                foreach (object obj in arrlstOfDeletedPartyBalanceRow)
                {
                    string str = Convert.ToString(obj);
                    spPartyBalance.PartyBalanceDelete(Convert.ToDecimal(str));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:34" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Function to edit the voucher
        /// </summary>
        /// <param name="decCreditNoteMasterId"></param>
        public void Edit(decimal decCreditNoteMasterId)
        {
            try
            {
                CreditNoteMasterSP spCreditnoteMaster = new CreditNoteMasterSP();
                CreditNoteMaster infoCreditNoteMaster = new CreditNoteMaster();
                CreditNoteDetailsSP spCreditNoteDetails = new CreditNoteDetailsSP();
                CreditNoteDetail infoCreditNoteDetails = new CreditNoteDetail();
                ExchangeRateSP spExchangeRate = new ExchangeRateSP();

                /*****************Update in CreditNoteMaster table *************/
                decimal decTotalDebit = 0;
                decimal decTotalCredit = 0;

                infoCreditNoteMaster.creditNoteMasterId = decCreditNoteMasterId;
                infoCreditNoteMaster.voucherNo = strVoucherNo;
                infoCreditNoteMaster.invoiceNo = txtVoucherNo.Text.Trim();
                infoCreditNoteMaster.suffixPrefixId = decCreditNoteSuffixPrefixId;
                infoCreditNoteMaster.date = Convert.ToDateTime(txtDate.Text);
                infoCreditNoteMaster.narration = txtNarration.Text.Trim();
                infoCreditNoteMaster.userId = Utils.getCurrentUser().WorkerID;
                infoCreditNoteMaster.voucherTypeId = decCreditNoteVoucherTypeId;
                infoCreditNoteMaster.financialYearId = Convert.ToDecimal(Utils.getManagement().FinancialYear.financialYearId);
                decTotalDebit = Convert.ToDecimal(txtDebitTotal.Text.Trim());
                decTotalCredit = Convert.ToDecimal(txtCreditTotal.Text.Trim());

                infoCreditNoteMaster.totalAmount = decTotalDebit;
                decimal decEffectRow = spCreditnoteMaster.CreditNoteMasterEdit(infoCreditNoteMaster);

                /**********************CreditNote Details Edit********************/
                if (decEffectRow > 0)
                {
                    infoCreditNoteDetails.creditNoteMasterId = decCreditNoteMasterId;

                    //-----------to delete details, LedgerPosting and bankReconciliation of removed rows--------------// 
                    LedgerPostingSP spLedgerPosting = new LedgerPostingSP();

                    foreach (object obj in arrlstOfRemove)
                    {
                        string str = Convert.ToString(obj);
                        spCreditNoteDetails.CreditNoteDetailsDelete(Convert.ToDecimal(str));
                        spLedgerPosting.LedgerPostDeleteByDetailsId(Convert.ToDecimal(str), strVoucherNo, decCreditNoteVoucherTypeId);
                    }
                    spLedgerPosting.LedgerPostingDeleteByVoucherNoVoucherTypeIdAndLedgerId(strVoucherNo, decCreditNoteVoucherTypeId, 12);
                    //=============================================================================================//

                    decimal decLedgerId = 0;
                    decimal decDebit = 0;
                    decimal decCredit = 0;
                    decimal decCreditNoteDetailsId = 0;
                    int inRowCount = dgvCreditNote.RowCount;
                    for (int inI = 0; inI < inRowCount; inI++)
                    {
                        if (dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                        {
                            infoCreditNoteDetails.ledgerId = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString());
                            decLedgerId = (decimal)infoCreditNoteDetails.ledgerId;
                        }
                        if (dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() != string.Empty)
                        {
                            //------------------Currency conversion------------------//
                            decSelectedCurrencyRate = spExchangeRate.GetExchangeRateByExchangeRateId(Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value));
                            decAmount = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                            decConvertRate = decAmount * decSelectedCurrencyRate;
                            //======================================================//

                            if (dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value.ToString() == "Dr")
                            {
                                infoCreditNoteDetails.debit = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                infoCreditNoteDetails.credit = 0;

                                decDebit = decConvertRate;
                                decCredit = (decimal)infoCreditNoteDetails.credit;
                            }
                            else
                            {
                                infoCreditNoteDetails.credit = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value.ToString());
                                infoCreditNoteDetails.debit = 0;
                                decDebit = (decimal)infoCreditNoteDetails.debit;
                                decCredit = decConvertRate;
                            }
                            infoCreditNoteDetails.exchangeRateId = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value.ToString());
                            if (dgvCreditNote.Rows[inI].Cells["dgvtxtChequeNo"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString() != string.Empty)
                            {
                                infoCreditNoteDetails.chequeNo = dgvCreditNote.Rows[inI].Cells["dgvtxtChequeNo"].Value.ToString();
                            }
                            else
                            {
                                infoCreditNoteDetails.chequeNo = string.Empty;
                            }
                            if (dgvCreditNote.Rows[inI].Cells["dgvtxtChequeDate"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                            {
                                infoCreditNoteDetails.chequeDate = Convert.ToDateTime(dgvCreditNote.Rows[inI].Cells["dgvtxtChequeDate"].Value);
                            }
                            else
                            {
                                infoCreditNoteDetails.chequeDate = DateTime.Now;
                            }
                            if (dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString() != string.Empty)
                            {
                                infoCreditNoteDetails.creditNoteDetailsId = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value.ToString());
                                spCreditNoteDetails.CreditNoteDetailsEdit(infoCreditNoteDetails);
                                PartyBalanceAddOrEdit(inI);
                                decCreditNoteDetailsId = infoCreditNoteDetails.creditNoteDetailsId;
                                decimal decLedgerPostId = Convert.ToDecimal(dgvCreditNote.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value.ToString());
                                LedgerPostingEdit(decLedgerPostId, decLedgerId, decCredit, decDebit, decCreditNoteDetailsId, inI);

                            }
                            else
                            {
                                decCreditNoteDetailsId = spCreditNoteDetails.CreditNoteDetailsAdd(infoCreditNoteDetails);
                                PartyBalanceAddOrEdit(inI);
                                LedgerPosting(decLedgerId, decCredit, decDebit, decCreditNoteDetailsId, inI);
                            }

                        }

                    }
                    DeletePartyBalanceOfRemovedRow();
                    Messages.UpdatedMessage();
                    

                }
                //----------------If print after save is enable-----------------------//
                SettingsSP spSettings = new SettingsSP();
                if (cbxPrintAfterSave.Checked)
                {
                    if (spSettings.SettingsStatusCheck("Printer") == "Dot Matrix")
                    {
                        PrintForDotMatrix(infoCreditNoteMaster.creditNoteMasterId);
                    }
                    else
                    {
                        Print(infoCreditNoteMaster.creditNoteMasterId);
                    }
                }

                //===================================================================//
                if (CreditNoteRegisterObj != null)
                {
                    this.Close();
                    CreditNoteRegisterObj.Enabled = true;

                }
                else if (frmCreditNoteReportObj != null)
                {
                    this.Close();
                    frmCreditNoteReportObj.Enabled = true;

                }
                else
                {
                    Clear();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:35" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
        /// <summary>
        /// Function to load the form while calling from BillAllocation form
        /// </summary>
        /// <param name="frmBillallocation"></param>
        /// <param name="deccreditMasterId"></param>
        //public void CallFromBillAllocation(frmBillallocation frmBillallocation, decimal deccreditMasterId)
        //{
        //    try
        //    {
        //        frmBillallocation.Enabled = false;
        //        base.Show();
        //        isEditMode = true;
        //        btnDelete.Enabled = true;
        //        frmBillallocationObj = frmBillallocation;
        //        decCreditNoteMasterIdForEdit = deccreditMasterId;
        //        FillFunction();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("CRNT:36" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        /// <summary>
        /// Function to fill the controlls
        /// </summary>
        public void FillFunction()
        {
            try
            {
                CreditNoteMaster infoCreditNoteMaster = new CreditNoteMaster();
                CreditNoteMasterSP spCreditNoteMaster = new CreditNoteMasterSP();
                infoCreditNoteMaster = spCreditNoteMaster.CreditNoteMasterView(decCreditNoteMasterIdForEdit);

                txtVoucherNo.ReadOnly = false;
                strVoucherNo = infoCreditNoteMaster.voucherNo;
                strInvoiceNo = infoCreditNoteMaster.invoiceNo;
                txtVoucherNo.Text = strInvoiceNo;
                decCreditNoteSuffixPrefixId = (decimal)infoCreditNoteMaster.suffixPrefixId;
                decCreditNoteVoucherTypeId = (decimal)infoCreditNoteMaster.voucherTypeId;
                dtpVoucherDate.Value = Convert.ToDateTime(infoCreditNoteMaster.date.Value.ToString("dd-MMM-yyyy"));
                txtDate.Text= infoCreditNoteMaster.date.Value.ToString("dd-MMM-yyyy");


                VoucherTypeSP spVoucherType = new VoucherTypeSP();
                isAutomatic = spVoucherType.CheckMethodOfVoucherNumbering(decCreditNoteVoucherTypeId);
                if (isAutomatic)
                {
                    txtVoucherNo.ReadOnly = true;
                }
                else
                {
                    txtVoucherNo.ReadOnly = false;
                }

                txtNarration.Text = infoCreditNoteMaster.narration;
                //GridFill
                DataTable dtbl = new DataTable();
                CreditNoteDetailsSP spCreditNoteDetailsSp = new CreditNoteDetailsSP();
                dtbl = spCreditNoteDetailsSp.CreditNoteDetailsViewByMasterId(decCreditNoteMasterIdForEdit);

                AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                LedgerPostingSP spLedgerPosting = new LedgerPostingSP();
                for (int inI = 0; inI < dtbl.Rows.Count; inI++)
                {
                    dgvCreditNote.Rows.Add();
                    dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value = Convert.ToDecimal(dtbl.Rows[inI]["ledgerId"].ToString());

                    if (Convert.ToDecimal(dtbl.Rows[inI]["debit"].ToString()) == 0)
                    {
                        dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value = "Cr";
                        dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value = Convert.ToDecimal(dtbl.Rows[inI]["credit"].ToString());
                    }
                    else
                    {
                        dgvCreditNote.Rows[inI].Cells["dgvcmbDrOrCr"].Value = "Dr";
                        dgvCreditNote.Rows[inI].Cells["dgvtxtAmount"].Value = Convert.ToDecimal(dtbl.Rows[inI]["debit"].ToString());
                    }
                    dgvCreditNote.Rows[inI].Cells["dgvcmbCurrency"].Value = Convert.ToDecimal(dtbl.Rows[inI]["exchangeRateId"].ToString());
                    if (dtbl.Rows[inI]["chequeNo"].ToString() != string.Empty)
                    {
                        dgvCreditNote.Rows[inI].Cells["dgvtxtChequeNo"].Value = dtbl.Rows[inI]["chequeNo"].ToString();
                        dgvCreditNote.Rows[inI].Cells["dgvtxtChequeDate"].Value = (Convert.ToDateTime(dtbl.Rows[inI]["chequeDate"].ToString())).ToString();
                    }
                    dgvCreditNote.Rows[inI].Cells["dgvtxtDetailsId"].Value = dtbl.Rows[inI]["CreditNoteDetailsId"].ToString();

                    decimal decDetailsId1 = Convert.ToDecimal(dtbl.Rows[inI]["CreditNoteDetailsId"].ToString());
                    decimal decLedgerPostingId = spLedgerPosting.LedgerPostingIdFromDetailsId(decDetailsId1, strVoucherNo, decCreditNoteVoucherTypeId);
                    dgvCreditNote.Rows[inI].Cells["dgvtxtLedgerPostingId"].Value = decLedgerPostingId.ToString();
                    btnSave.Text = "Update";

                }

                PartyBalanceSP SpPartyBalance = new PartyBalanceSP();
                DataTable dtbl1 = new DataTable();
                dtbl1 = SpPartyBalance.PartyBalanceViewByVoucherNoAndVoucherType(decCreditNoteVoucherTypeId, strVoucherNo, Convert.ToDateTime(infoCreditNoteMaster.date));

                dtblPartyBalance = dtbl1;
                dgvCreditNote.ClearSelection();
                txtDate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:37" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to load the form while calling from DayBook form
        /// </summary>
        /// <param name="frmDayBook"></param>
        /// <param name="decMasterId"></param>
        //public void callFromDayBook(frmDayBook frmDayBook, decimal decMasterId)
        //{
        //    try
        //    {
        //        base.Show();
        //        this.frmDayBookObj = frmDayBook;
        //        frmDayBook.Enabled = false;
        //        isEditMode = true;
        //        btnDelete.Enabled = true;
        //        decCreditNoteMasterIdForEdit = decMasterId;
        //        FillFunction();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("CRNT:38" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        /// <summary>
        /// Function to load the form while calling from Ageing report form
        /// </summary>
        /// <param name="frmAgeing"></param>
        /// <param name="decMasterId"></param>
        //public void callFromAgeing(frmAgeingReport frmAgeing, decimal decMasterId)
        //{
        //    try
        //    {
        //        base.Show();
        //        this.frmAgeingObj = frmAgeing;
        //        frmAgeing.Enabled = false;
        //        isEditMode = true;
        //        btnDelete.Enabled = true;
        //        decCreditNoteMasterIdForEdit = decMasterId;
        //        FillFunction();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("CRNT:39" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        /// <summary>
        /// Function to select the ledger while from ledgerpopup
        /// </summary>
        /// <param name="frmLedgerDetails"></param>
        /// <param name="decMasterId"></param>
        //public void CallFromLedgerDetails(frmLedgerDetails frmLedgerDetails, decimal decMasterId)
        //{
        //    try
        //    {
        //        base.Show();
        //        isEditMode = true;
        //        btnDelete.Enabled = true;
        //        frmLedgerDetailsObj = frmLedgerDetails;
        //        frmLedgerDetailsObj.Enabled = false;
        //        decCreditNoteMasterIdForEdit = decMasterId;
        //        FillFunction();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("CRNT:40:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //}
        #endregion

        #region Navigation

        /// <summary>
        /// Enter key navigation of txtVoucherNo
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
                    txtDate.SelectionStart = txtDate.TextLength;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:41" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Enter key and backspace navigation of txtDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvCreditNote.Focus();
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
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:42" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Enter key and backspace navigation of dgvCreditNote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCreditNote_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int inDgvCreditNoteRowCount = dgvCreditNote.Rows.Count;
                if (e.KeyCode == Keys.Enter)
                {

                    if (dgvCreditNote.CurrentCell == dgvCreditNote.Rows[inDgvCreditNoteRowCount - 1].Cells["dgvtxtChequeDate"])
                    {
                        txtNarration.Focus();
                        txtNarration.SelectionStart = txtNarration.TextLength;
                        dgvCreditNote.ClearSelection();
                    }

                }
                if (e.KeyCode == Keys.Back)
                {
                    if (dgvCreditNote.CurrentCell == dgvCreditNote.Rows[0].Cells["dgvtxtSlNo"])
                    {
                        dgvCreditNote.ClearSelection();
                        txtDate.Focus();
                        txtDate.SelectionStart = txtDate.TextLength;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:43" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Backspace navigation of txtNarration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text.Trim() == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        if (dgvCreditNote.RowCount > 0)
                        {
                            dgvCreditNote.Focus();
                        }
                        else
                        {
                            txtDate.Focus();
                            txtDate.SelectionStart = txtDate.TextLength;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:44" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Enter key navigation of txtNarration
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
                        cbxPrintAfterSave.Focus();
                    }
                }
                else
                {
                    inNarrationCount = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:45" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Backspace navigation of btnSave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    cbxPrintAfterSave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:46" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Backspace navigation of btnClear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:47" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Backspace navigation of btnDelete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (btnDelete.Enabled == true)
                    {
                        btnDelete.Focus();
                    }
                    else
                    {
                        btnClear.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:48" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Enter key and backspace navigation of cbxPrintafterSave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxPrintAfterSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
                else if (e.KeyCode == Keys.Back)
                {
                    txtNarration.Focus();
                    txtNarration.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:49" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// On load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCreditNote_Load(object sender, EventArgs e)
        {
            try
            {
                //InitializeComponent();
                AccountLedgerComboFill();
                DrOrCrComboFill();
                Clear();
                CurrencyComboFill();
                DebitAndCreditTotal();

                /************For PartyBalance***********************/
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
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:50" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On Clear button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                //if (frmAgeingObj != null)
                //{
                //    frmAgeingObj.Close();
                //    frmAgeingObj = null;
                //}
                //if (frmBillallocationObj != null)
                //{
                //    frmBillallocationObj.Close();
                //    frmBillallocationObj = null;
                //}
                //if (frmCurrencyObj != null)
                //{
                //    frmCurrencyObj.Close();
                //    frmCurrencyObj = null;
                //}
                if (frmCreditNoteReportObj != null)
                {
                    frmCreditNoteReportObj.Close();
                    frmCreditNoteReportObj = null;
                }
                if (CreditNoteRegisterObj != null)
                {
                    CreditNoteRegisterObj.Close();
                    CreditNoteRegisterObj = null;
                }

                //if (frmLedgerDetailsObj != null)
                //{
                //    frmLedgerDetailsObj.Close();
                //    frmLedgerDetailsObj = null;
                //}

                //if (frmPartyBalanceObj != null)
                //{
                //    frmPartyBalanceObj.Close();
                //    frmPartyBalanceObj = null;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:51" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On close button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (Messages.CloseConfirmation())
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:52" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On CellEnter of dgvCreditNote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCreditNote_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCreditNote.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
                {
                    dgvCreditNote.EditMode = DataGridViewEditMode.EditOnEnter;
                }
                else
                {
                    dgvCreditNote.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:53" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On changing the date from dtpVoucherDate, sets the txtDate with the new date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpVoucherDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpVoucherDate.Value;
                this.txtDate.Text = date.ToString("dd-MMM-yyyy");
                CurrencyComboFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:54" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Date validation while leaving txtDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation obj = new DateValidation();
                bool isInvalid = obj.DateValidationFunction(txtDate);
                if (!isInvalid)
                {
                    txtDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
                string date = txtDate.Text;
                dtpVoucherDate.Value = Convert.ToDateTime(date);
                CurrencyComboFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:55" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On cellvalueChanged of dgvCreditNote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCreditNote_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    DebitAndCreditTotal();

                    if (dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {
                        if (dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value == null || dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value.ToString() == string.Empty)
                        {
                            dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbCurrency"].Value = Convert.ToDecimal(1);//decExchangeRateId;
                        }
                    }


                    
                    //==========================================================================================//

                    //-----------To make amount readonly when party is selected as ledger------------------------------//
                    if (dgvCreditNote.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbAccountLedger")
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

                            dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtAmount"].Value = string.Empty;

                            //reset
                            decUpdatingLedgerForPartyremove = 0;
                            inUpdatingRowIndexForPartyRemove = -1;
                        }
                        /*************************************************************************/

                        //-----------To make amount readonly when party is selected as ledger------------------------------//
                        AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                        if (spAccountLedger.AccountGroupIdCheck(dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].FormattedValue.ToString()))
                        {
                            dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtAmount"].Value = string.Empty;
                            dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtAmount"].ReadOnly = true;

                        }
                        else
                        {
                            dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtAmount"].Value = string.Empty;
                            dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtAmount"].ReadOnly = false;
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

                    //========================================================================================//

                    if (dgvCreditNote.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbDrOrCr")
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
                            dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtAmount"].Value = string.Empty;

                            //reset
                            decUpdatingLedgerForPartyremove = 0;
                            inUpdatingRowIndexForPartyRemove = -1;
                        }
                        /*************************************************************************/
                    }

                    //-----------------------------------Chequedate validation----------------------------------//
                    if (dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value != null && dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value.ToString() != string.Empty)
                    {
                        DateValidation obj = new DateValidation();
                        TextBox txtDate1 = new TextBox();

                        txtDate1.Text = dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value.ToString();
                        bool isInvalid = obj.DateValidationFunction(txtDate1);
                        if (!isInvalid)
                        {
                            dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value = DateTime.Now.ToString("dd-MMM-yyyy");
                        }
                        else
                        {
                            dgvCreditNote.Rows[e.RowIndex].Cells["dgvtxtChequeDate"].Value = txtDate1.Text;
                        }
                    }
                    //=========================================================================================//
                    //---------------------check column missing---------------------------------//

                    CheckColumnMissing(e);

                    //==========================================================================//

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:56" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On cellBeginEdit of dgvCreditNote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCreditNote_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                inUpdatingRowIndexForPartyRemove = -1;
                decUpdatingLedgerForPartyremove = 0;

                DataTable dtbl = new DataTable();
                AccountLedgerSP SpAccountLedger = new AccountLedgerSP();

                if (dgvCreditNote.CurrentCell.ColumnIndex == dgvCreditNote.Columns["dgvcmbAccountLedger"].Index)
                {
                    dtbl = SpAccountLedger.AccountLedgerViewAll();
                    DataRow dr = dtbl.NewRow();
                    dr[0] = 0;
                    dr[2] = string.Empty;
                    dtbl.Rows.InsertAt(dr, 0);

                    if (dtbl.Rows.Count > 0)
                    {
                        if (dgvCreditNote.RowCount > 1)
                        {
                            int inGridRowCount = dgvCreditNote.RowCount;
                            for (int inI = 0; inI < inGridRowCount - 1; inI++)
                            {
                                if (inI != e.RowIndex)
                                {
                                    int inTableRowcount = dtbl.Rows.Count;
                                    for (int inJ = 0; inJ < inTableRowcount; inJ++)
                                    {
                                        if (dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                                        {
                                            if (dtbl.Rows[inJ]["ledgerId"].ToString() == dgvCreditNote.Rows[inI].Cells["dgvcmbAccountLedger"].Value.ToString())
                                            {
                                                dtbl.Rows.RemoveAt(inJ);
                                                break;
                                            }
                                        }
                                    }

                                }
                            }
                        }
                        DataGridViewComboBoxCell dgvccVoucherType = (DataGridViewComboBoxCell)dgvCreditNote[dgvCreditNote.Columns["dgvcmbAccountLedger"].Index, e.RowIndex];
                        dgvccVoucherType.DataSource = dtbl;
                        dgvccVoucherType.ValueMember = "ledgerId";
                        dgvccVoucherType.DisplayMember = "ledgerName";
                    }
                }

                if (dgvCreditNote.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbAccountLedger")
                {
                    if (dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {
                        AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                        if (spAccountLedger.AccountGroupIdCheck(dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].FormattedValue.ToString()))
                        {
                            inUpdatingRowIndexForPartyRemove = e.RowIndex;
                            decUpdatingLedgerForPartyremove = Convert.ToDecimal(dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString());
                        }
                    }
                }
                if (dgvCreditNote.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "dgvcmbDrOrCr")
                {
                    if (dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                    {
                        AccountLedgerSP spAccountLedger = new AccountLedgerSP();
                        if (spAccountLedger.AccountGroupIdCheck(dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].FormattedValue.ToString()))
                        {
                            inUpdatingRowIndexForPartyRemove = e.RowIndex;
                            decUpdatingLedgerForPartyremove = Convert.ToDecimal(dgvCreditNote.Rows[e.RowIndex].Cells["dgvcmbAccountLedger"].Value.ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:57" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// For committing the edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCreditNote_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCreditNote.IsCurrentCellDirty)
                {
                    dgvCreditNote.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:58" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handling dataerror
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCreditNote_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                {
                    object value = dgvCreditNote.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dgvCreditNote.Columns[e.ColumnIndex]).Items.Contains(value))
                    {
                        e.ThrowException = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:59" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Calling the keypress event for validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCreditNote_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridViewTextBoxEditingControl txt = e.Control as DataGridViewTextBoxEditingControl;
                if (dgvCreditNote.CurrentCell.ColumnIndex == dgvCreditNote.Columns["dgvtxtAmount"].Index)
                {
                    txt.KeyPress += keypressevent;
                }
                else if (dgvCreditNote.CurrentCell.ColumnIndex == dgvCreditNote.Columns["dgvtxtChequeNo"].Index)
                {
                    txt.KeyPress += keypresseventEnable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:60" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// While adding new row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCreditNote_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                SlNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:61" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// For against button click in the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCreditNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex>=0)
                {
                    if (dgvCreditNote.CurrentCell.ColumnIndex == dgvCreditNote.Columns["dgvbtnAgainst"].Index)
                    {
                        AccountLedgerSP SpAccountLedger = new AccountLedgerSP();
                        if (dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                        {
                            if (dgvCreditNote.CurrentRow.Cells["dgvcmbDrOrCr"].Value != null && dgvCreditNote.CurrentRow.Cells["dgvcmbDrOrCr"].Value.ToString() != string.Empty)
                            {

                                if (SpAccountLedger.AccountGroupIdCheck(dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].FormattedValue.ToString()))
                                {
                                    //frmPartyBalanceObj = new frmPartyBalance();
                                    //frmPartyBalanceObj.MdiParent = formMDI.MDIObj;
                                    decimal decLedgerId = Convert.ToDecimal(dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString());

                                    string strDebitOrCredit = dgvCreditNote.CurrentRow.Cells["dgvcmbDrOrCr"].Value.ToString();
                                    if (!isAutomatic)
                                    {
                                        //frmPartyBalanceObj.CallFromCreditNote(this, decLedgerId, dtblPartyBalance, strDebitOrCredit, decCreditNoteVoucherTypeId, txtVoucherNo.Text, Convert.ToDateTime(txtDate.Text), arrlstOfDeletedPartyBalanceRow);
                                    }
                                    else
                                    {
                                        //frmPartyBalanceObj.CallFromCreditNote(this, decLedgerId, dtblPartyBalance, strDebitOrCredit, decCreditNoteVoucherTypeId, strVoucherNo, Convert.ToDateTime(txtDate.Text), arrlstOfDeletedPartyBalanceRow);
                                    }

                                }

                            }
                            else
                            {
                                Messages.InformationMessage("Select debit or credit");
                            }
                        }
                        else
                        {
                            Messages.InformationMessage("Select any ledger");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:62" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On remove linkbutton click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dgvCreditNote.RowCount > 1)
                {
                    if (MessageBox.Show("Do you want to remove current row ?", "OpenMiracle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        RemoveRow();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:63" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On Save button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveOrEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:64" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On Delete button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, this.Name, btnDelete.Text))
                //{
                    //if (PublicVariables.isMessageDelete)
                    //{
                        if (Messages.DeleteMessage())
                        {
                            DeleteFunction(decCreditNoteMasterIdForEdit);
                        }
                        dgvCreditNote.Focus();
                    //}
                    //else
                    //{
                        DeleteFunction(decCreditNoteMasterIdForEdit);
                    //}
                //}
                //else
                //{
                    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:65" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// On form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCreditNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (CreditNoteRegisterObj != null)
                {
                    CreditNoteRegisterObj.Enabled = true;
                    CreditNoteRegisterObj.SearchRegister();
                }
                else if (frmCreditNoteReportObj != null)
                {
                    frmCreditNoteReportObj.Enabled = true;
                    frmCreditNoteReportObj.Search();
                }
                //if (frmBillallocationObj != null)
                //{
                //    frmBillallocationObj.Enabled = true;
                //    frmBillallocationObj.BillAllocationGridFill();
                //    frmBillallocationObj.Activate();
                //}
                //if (frmDayBookObj != null)
                //{
                //    frmDayBookObj.Enabled = true;
                //    frmDayBookObj.dayBookGridFill();
                //    frmDayBookObj = null;
                //}
                //if (frmAgeingObj != null)
                //{
                //    frmAgeingObj.Enabled = true;
                //    frmAgeingObj.FillGrid();
                //    frmAgeingObj = null;
                //}
                if (objVoucherSearch != null)
                {
                    objVoucherSearch.Enabled = true;
                    objVoucherSearch.GridFill();
                }
                //if (frmLedgerDetailsObj != null)
                //{
                //    frmLedgerDetailsObj.Enabled = true;
                //    frmLedgerDetailsObj.LedgerDetailsView();
                //    frmLedgerDetailsObj = null;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:66" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void frmCreditNote_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    //if (PublicVariables.isMessageClose)
                    //{
                        Messages.CloseMessage(this);

                    //}
                    //else
                    //{
                        this.Close();
                   // }
                }
                if (dgvCreditNote.RowCount > 0)
                {
                    if (dgvCreditNote.CurrentCell == dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"])
                    {
                        //-----------------------for ledger creation----------------------------------//
                        if (e.KeyCode == Keys.C && Control.ModifierKeys == Keys.Alt)//Ledger creation
                        {
                            frmAccountLedger accounLedgerObj = new frmAccountLedger();
                           // accounLedgerObj.MdiParent = formMDI.MDIObj;
                            if (dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                            {
                                string strLedgerName = dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].FormattedValue.ToString();
                                accounLedgerObj.CallFromCreditNote(this, strLedgerName);
                            }
                            else
                            {
                                string strLedgerName = string.Empty;
                                accounLedgerObj.CallFromCreditNote(this, strLedgerName);
                            }

                        }
                        //========================================================================//

                        //--------------------For ledger Popup------------------------------------//

                        if (e.KeyCode == Keys.F && Control.ModifierKeys == Keys.Control)//Ledger popup
                        {
                            frmLedgerPopup frmLedgerPopupObj = new frmLedgerPopup();
                            //frmLedgerPopupObj.MdiParent = formMDI.MDIObj;
                            btnSave.Focus();
                            dgvCreditNote.Focus();
                            if (dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value != null && dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString() != string.Empty)
                            {
                                btnSave.Focus();
                                dgvCreditNote.Focus();
                                decLedgerIdForPopUp = Convert.ToDecimal(dgvCreditNote.CurrentRow.Cells["dgvcmbAccountLedger"].Value.ToString());
                                frmLedgerPopupObj.CallFromCreditNote(this, decLedgerIdForPopUp, string.Empty);

                            }

                        }
                        //========================================================================// 
                    }
                    if (dgvCreditNote.CurrentCell == dgvCreditNote.CurrentRow.Cells["dgvcmbCurrency"])
                    {
                        if (e.KeyCode == Keys.F && Control.ModifierKeys == Keys.Control) //Pop Up
                        {
                            //frmCurrencyObj = new frmCurrencyDetails();
                            //frmCurrencyObj.MdiParent = formMDI.MDIObj;
                            if (dgvCreditNote.CurrentRow.Cells["dgvcmbCurrency"].Value != null && dgvCreditNote.CurrentRow.Cells["dgvcmbCurrency"].Value.ToString() != string.Empty)
                            {
                               // frmCurrencyObj.CallFromCreditNote(this, Convert.ToDecimal(dgvCreditNote.CurrentRow.Cells["dgvcmbCurrency"].Value.ToString()));
                            }
                        }
                    }
                }


                //-----------------------CTRL+S Save-----------------------------//
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
                {
                    btnSave_Click(sender, e);
                }
                //===============================================================//

                //-----------------------CTRL+D Delete-----------------------------//
                if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control) //Delete
                {
                    if (btnDelete.Enabled)
                    {
                        btnDelete_Click(sender, e);
                    }
                }
                //=====================================================================//
            }
            catch (Exception ex)
            {
                MessageBox.Show("CRNT:67" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

   
    }
}
