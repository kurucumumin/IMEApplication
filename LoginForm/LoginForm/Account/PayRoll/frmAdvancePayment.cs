using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.Services;
using LoginForm.DataSet;
using LoginForm.Account.Services;

namespace LoginForm
{
    public partial class frmAdvancePayment : Form
    {
        #region Public Variables
        IMEEntities IME = new IMEEntities();

        decimal decAdvancePaymentEditId = 0;
        string strLedgerId;
        string str = string.Empty;
        int decUserId = Utils.getCurrentUser().WorkerID;
        string strFormName = "frmAdvancePayment";
        static string strPaymentVoucherTypeId = string.Empty;
        decimal decPaymentSuffixPrefixId = 0;
        decimal decAdvancePaymentsId;
        decimal decAdvancePaymentId;
        string strUpdatedVoucherNumber = string.Empty;
        decimal decPaymentVoucherTypeId = 0;
        string strSuffix = string.Empty;
        string strPrefix = string.Empty;
        string strUpdatedInvoiceNumber = string.Empty;
        string strVoucherNo = string.Empty;
        string strInvoiceNo = string.Empty;
        bool isLoad = false;
        string strEmployeeId;
        string strAdvancePayment = "AdvancePayment";
        bool isAutomatic = false;
        frmVoucherSearch objVoucherSearch ;
        frmLedgerPopup frmLedgerPopupObj ;
        int inNarrationCount = 0;

        #endregion



        public frmAdvancePayment()
        {
            InitializeComponent();
        }

        public void SaveFunction()
        {
            //AdvancePaymentSP spAdvancepayment = new AdvancePaymentSP();
            //AdvancePaymentInfo infoAdvancepayment = new AdvancePaymentInfo();
            //LedgerPostingSP spLedgerPosting = new LedgerPostingSP();
            //MonthlySalarySP spMonthlySalary = new MonthlySalarySP();
            AdvancePayment AdvancePayment = new AdvancePayment();
            if (CheckAdvanceAmount())
            {

                if (IME.SalaryVoucherDetails.Where(a => a.employeeId == Convert.ToDecimal(cmbEmployee.SelectedValue.ToString())).
                Where(b => b.SalaryVoucherMaster.month == dtpSalaryMonth.Value) == null)
                {
                    if (IME.AdvancePayments.Where(a => a.employeeId == Convert.ToDecimal(cmbEmployee.SelectedValue.ToString()))
                    .Where(b => b.salaryMonth == dtpSalaryMonth.Value) == null)
                    {
                        if (isAutomatic == true)
                        {
                            AdvancePayment.voucherNo = strVoucherNo;
                        }
                        else
                        {
                            AdvancePayment.voucherNo = txtAdvanceVoucherNo.Text.Trim();
                        }
                        AdvancePayment.employeeId = Convert.ToInt32(cmbEmployee.SelectedValue.ToString());
                        AdvancePayment.salaryMonth = Convert.ToDateTime(dtpSalaryMonth.Text.ToString());
                        AdvancePayment.chequenumber = txtCheckNo.Text.ToString();
                        AdvancePayment.date = Convert.ToDateTime(txtDate.Text.ToString());
                        AdvancePayment.amount = Convert.ToDecimal(txtAmount.Text.ToString());
                        if (isAutomatic)
                        {
                            AdvancePayment.invoiceNo = strInvoiceNo;
                        }
                        else
                        {
                            AdvancePayment.invoiceNo = txtAdvanceVoucherNo.Text.Trim();
                        }
                        AdvancePayment.ledgerId = Convert.ToDecimal(cmbCashOrBank.SelectedValue.ToString());
                        AdvancePayment.chequeDate = Convert.ToDateTime(txtChequeDate.Text.ToString());
                        AdvancePayment.narration = txtNarration.Text.Trim();
                        AdvancePayment.voucherTypeId = decPaymentVoucherTypeId;
                        AdvancePayment.suffixPrefixId = decPaymentSuffixPrefixId;

                        AdvancePayment.financialYearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;

                        if (btnAdvancePaymentSave.Text == "Save")
                        {
                            if (decAdvancePaymentsId != -1)
                            {
                                //TO DO CHeck again
                                //                                IF @IsAutomatic != 'false'
                                // BEGIN
                                // SET @UpdatedVoucherNo = (SELECT ISNULL(MAX(CAST(voucherNo AS NUMERIC(18, 0))), 0) + 1
                                // FROM tbl_AdvancePayment
                                // WHERE voucherTypeId = @voucherTypeId)

                                //			IF @UpdatedVoucherNo != CAST(@voucherNo AS DECIMAL(18, 0))

                                //             BEGIN
                                //                SET @UpdatedVoucherNo = dbo.VoucherNumberGeneration(@voucherTypeId, @date, 'AdvancePayment', @UpdatedVoucherNo - 1)

                                //                SET @voucherNo = @UpdatedVoucherNo

                                //                SET @UpdatedInvoiceNo = dbo.InvoiceNumberGeneration(@voucherTypeId, @UpdatedVoucherNo, @date)

                                //                SET @invoiceNo = @UpdatedInvoiceNo

                                //             END
                                //END


                                DataTable dtbl = new DataTable();
                                //TO DO anlamadım???


                                if (isAutomatic)
                                {
                                    IME.AdvancePayments.Add(AdvancePayment);
                                }
                                decAdvancePaymentId = AdvancePayment.advancePaymentId;
                                strUpdatedVoucherNumber = AdvancePayment.voucherNo;
                                strUpdatedInvoiceNumber = AdvancePayment.invoiceNo;
                                if (!isAutomatic)
                                {
                                    strVoucherNo = txtAdvanceVoucherNo.Text.Trim();
                                }
                                if (isAutomatic)
                                {
                                    if (Convert.ToDecimal(strUpdatedVoucherNumber) != Convert.ToDecimal(strVoucherNo))
                                    {
                                        MessageBox.Show("Voucher number changed from  " + strInvoiceNo + "  to  " + strUpdatedInvoiceNumber);
                                        strVoucherNo = strUpdatedVoucherNumber.ToString();
                                        strInvoiceNo = strUpdatedInvoiceNumber;
                                    }
                                }
                                txtAdvanceVoucherNo.Focus();
                            }
                            LedgerPosting(Convert.ToDecimal(cmbCashOrBank.SelectedValue.ToString()), decAdvancePaymentId);
                            MessageBox.Show("Saved successfully");
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Advance already paid for this month");
                        dtpSalaryMonth.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Cant pay advance for this month,Salary already paid");
                    dtpSalaryMonth.Focus();
                }
            }



        }


        public void CallThisFormFromVoucherSearch(frmVoucherSearch frm, decimal decId)
        {
            this.objVoucherSearch = frm;
            decAdvancePaymentEditId = decId;
            fillFunction();

        }

        public void EditFunction()
        {
            try
            {
                //MonthlySalarySP spMonthlySalary = new MonthlySalarySP();
                if (IME.SalaryVoucherDetails.Where(a => a.employeeId == Convert.ToDecimal(cmbEmployee.SelectedValue.ToString()))
               .Where(b => b.status == "paid").Where(c => c.SalaryVoucherMaster.month == dtpSalaryMonth.Value) == null
               )
                {
                    //AdvancePaymentSP spAdvancepayment = new AdvancePaymentSP();
                    //AdvancePaymentInfo infoAdvancepayment = new AdvancePaymentInfo();
                    //LedgerPostingSP spLedgerPosting = new LedgerPostingSP();

                    if (IME.AdvancePayments.Where(a => a.employeeId == Convert.ToDecimal(cmbEmployee.SelectedValue.ToString()))
                    .Where(b => b.salaryMonth == dtpSalaryMonth.Value) == null)
                    {
                        txtAmount.ReadOnly = true;
                    }
                    AdvancePayment AdvancePayment = IME.AdvancePayments.Where(a => a.advancePaymentId == (Convert.ToDecimal(decAdvancePaymentEditId.ToString()))).FirstOrDefault();

                    AdvancePayment.advancePaymentId = (Convert.ToDecimal(decAdvancePaymentEditId.ToString()));
                    AdvancePayment.employeeId = Convert.ToInt32(cmbEmployee.SelectedValue.ToString());
                    AdvancePayment.salaryMonth = Convert.ToDateTime(dtpSalaryMonth.Text.ToString());
                    AdvancePayment.chequenumber = txtCheckNo.Text.ToString();
                    AdvancePayment.date = Convert.ToDateTime(txtDate.Text.ToString());
                    AdvancePayment.amount = Convert.ToDecimal(txtAmount.Text.ToString());
                    if (CheckAdvanceAmount())
                    {
                        if (isAutomatic)
                        {
                            AdvancePayment.voucherNo = strVoucherNo;
                        }
                        else
                        {
                            AdvancePayment.voucherNo = txtAdvanceVoucherNo.Text.Trim();
                        }
                        if (isAutomatic)
                        {
                            AdvancePayment.invoiceNo = strInvoiceNo;
                        }
                        else
                        {
                            AdvancePayment.invoiceNo = txtAdvanceVoucherNo.Text.Trim();
                        }
                        AdvancePayment.ledgerId = Convert.ToDecimal(cmbCashOrBank.SelectedValue.ToString());
                        AdvancePayment.chequeDate = Convert.ToDateTime(txtChequeDate.Text.ToString());
                        AdvancePayment.narration = txtNarration.Text.Trim();
                        AdvancePayment.voucherTypeId = decPaymentVoucherTypeId;
                        AdvancePayment.suffixPrefixId = decPaymentSuffixPrefixId;
                        AdvancePayment.financialYearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
                        IME.SaveChanges();
                        LedgerUpdate();
                        Messages.UpdatedMessage();
                        txtAdvanceVoucherNo.Focus();
                        this.Close();
                    }
                }

                else
                {
                    Messages.ReferenceExistsMessageForUpdate();
                    dtpSalaryMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP3:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call save or edit
        /// </summary>
        public void SaveOrEdit()
        {

            if (txtAdvanceVoucherNo.Text.Trim() == string.Empty)
            {
                Messages.InformationMessage("Enter advance voucher no");
                txtAdvanceVoucherNo.Focus();
            }
            else if (txtDate.Text == string.Empty)
            {
                Messages.InformationMessage("Select date");
            }
            else if (cmbEmployee.Text == string.Empty)
            {
                Messages.InformationMessage("Select employee");
                cmbEmployee.Focus();
            }
            else if (txtAmount.Text.TrimEnd() == string.Empty)
            {
                Messages.InformationMessage("Select amount");
                txtAmount.Focus();
            }
            else if (cmbCashOrBank.Text == string.Empty)
            {
                Messages.InformationMessage("Select Cash/Bank/ac");
                cmbCashOrBank.Focus();
            }
            else
            {
                if (btnAdvancePaymentSave.Text == "Save")
                {


                    if (!isAutomatic)
                    {
                        if
                (IME.AdvancePayments.Where(a => a.voucherNo == txtAdvanceVoucherNo.Text.Trim()).
                    Where(b => b.voucherTypeId == decPaymentVoucherTypeId).Where(b => b.advancePaymentId == 0).FirstOrDefault() == null)
                        {
                            SaveFunction();
                            MessageBox.Show("Saved successfully");
                        }
                        else
                        {
                            MessageBox.Show("Advance voucher number already exist");
                            txtAdvanceVoucherNo.Focus();
                        }
                    }
                    else
                    {
                        SaveFunction();
                        MessageBox.Show("Saved successfully");
                    }


                }

                else
                {
                    if (btnAdvancePaymentSave.Text == "Update")
                    {
                        if (!isAutomatic)
                        {
                            if (IME.AdvancePayments.Where(a => a.voucherNo == txtAdvanceVoucherNo.Text.Trim()).Where(b => b.voucherTypeId == decPaymentVoucherTypeId)
                                .Where(c => c.advancePaymentId == decAdvancePaymentEditId) == null)
                            {
                                EditFunction();
                                MessageBox.Show("Edited succesfully");
                            }
                            else
                            {
                                MessageBox.Show("Advance voucher number already exist");
                                txtAdvanceVoucherNo.Focus();
                            }
                        }
                    }
                }
            }


        }
        /// <summary>
        /// Function to fill Employee combobox while return from Employee creation when creating new ledger
        /// </summary>
        /// <param name="decemployeeId"></param>
        public void ReturnFromEmployeeCreation(decimal decemployeeId)
        {
            try
            {
                EmployeeComboFill();
                cmbEmployee.SelectedValue = decemployeeId;

                if (decemployeeId.ToString() != "0")
                {
                    cmbEmployee.SelectedValue = decemployeeId;
                }
                else if (strEmployeeId != string.Empty)
                {
                    cmbEmployee.SelectedValue = strEmployeeId;
                }
                else
                {
                    cmbEmployee.SelectedIndex = -1;
                }
                cmbEmployee.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function for Ledger Posting
        /// </summary>
        /// <param name="decLedgerPostingId"></param>
        /// <param name="decAdvancePaymentId"></param>
        public void LedgerPosting(decimal decLedgerPostingId, decimal decAdvancePaymentId)
        {
            //AdvancePaymentSP spAdvancePayment = new AdvancePaymentSP();
            //AdvancePaymentInfo infoAdvancePayment = new AdvancePaymentInfo();
            //LedgerPostingSP spLedgerPosting = new LedgerPostingSP();
            //LedgerPostingInfo infoLedgerPosting = new LedgerPostingInfo();
            LedgerPosting LedgerPosting = new LedgerPosting();
            LedgerPosting.voucherTypeId = decPaymentVoucherTypeId;
            if (isAutomatic)
            {
                LedgerPosting.voucherNo = strVoucherNo;
            }
            else
            {
                LedgerPosting.voucherNo = txtAdvanceVoucherNo.Text.Trim();
            }
            LedgerPosting.date = DateTime.Now;
            LedgerPosting.ledgerId = Convert.ToDecimal(cmbCashOrBank.SelectedValue.ToString());
            LedgerPosting.detailsId = decAdvancePaymentId;
            if (isAutomatic)
            {
                LedgerPosting.invoiceNo = strInvoiceNo;
            }
            else
            {
                LedgerPosting.invoiceNo = txtAdvanceVoucherNo.Text.Trim();
            }
            LedgerPosting.yearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
            LedgerPosting.debit = 0;
            LedgerPosting.credit = Convert.ToDecimal(txtAmount.Text.ToString());

            LedgerPosting.chequeNo = string.Empty;
            LedgerPosting.chequeDate = DateTime.Now;
            IME.LedgerPostings.Add(LedgerPosting);

        }
        /// <summary>
        /// Function to update LedgerPosting Table
        /// </summary>
        public void LedgerUpdate()
        {
            try
            {
                decimal decLedgerPostingId = 0;
                //LedgerPostingSP spLedgerPosting = new LedgerPostingSP();
                //LedgerPostingInfo infoLedgerPosting = new LedgerPostingInfo();

                List<LedgerPosting> LedgerPostingList = IME.LedgerPostings.Where(a => a.voucherNo == strVoucherNo).Where(b => b.voucherTypeId == decAdvancePaymentId).ToList();

                int ini = 0;
                foreach (var dr in LedgerPostingList)
                {
                    ini++;
                    if (ini == 2)
                    {
                        LedgerPosting LedgerPosting = IME.LedgerPostings.Where(a => a.ledgerPostingId == Convert.ToDecimal(dr.ledgerPostingId.ToString())).FirstOrDefault();
                        LedgerPosting.ledgerPostingId = decLedgerPostingId;
                        LedgerPosting.date = DateTime.Now;
                        if (isAutomatic)
                        {
                            LedgerPosting.voucherNo = strVoucherNo;
                        }
                        else
                        {
                            LedgerPosting.voucherNo = txtAdvanceVoucherNo.Text.Trim();
                        }
                        LedgerPosting.debit = Convert.ToDecimal(txtAmount.Text.ToString());
                        LedgerPosting.credit = 0;
                        LedgerPosting.voucherTypeId = decPaymentVoucherTypeId;
                        LedgerPosting.ledgerId = 3;
                        LedgerPosting.detailsId = decAdvancePaymentId;
                        if (isAutomatic)
                        {
                            LedgerPosting.invoiceNo = strInvoiceNo;
                        }
                        else
                        {
                            LedgerPosting.invoiceNo = txtAdvanceVoucherNo.Text.Trim();
                        }

                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = DateTime.Now;

                        LedgerPosting.yearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
                        IME.SaveChanges();
                    }
                    if (ini == 1)
                    {
                        LedgerPosting LedgerPosting = IME.LedgerPostings.Where(a => a.ledgerPostingId == Convert.ToDecimal(dr.ledgerPostingId.ToString())).FirstOrDefault();
                        decLedgerPostingId = Convert.ToDecimal(dr.ledgerPostingId.ToString());
                        LedgerPosting.ledgerPostingId = decLedgerPostingId;
                        LedgerPosting.date = DateTime.Now;
                        if (isAutomatic)
                        {
                            LedgerPosting.voucherNo = strVoucherNo;
                        }
                        else
                        {
                            LedgerPosting.voucherNo = txtAdvanceVoucherNo.Text.Trim();
                        }
                        LedgerPosting.debit = 0;
                        LedgerPosting.credit = Convert.ToDecimal(txtAmount.Text.ToString());
                        LedgerPosting.voucherTypeId = decPaymentVoucherTypeId;
                        LedgerPosting.ledgerId = Convert.ToDecimal(cmbCashOrBank.SelectedValue.ToString());
                        LedgerPosting.detailsId = decAdvancePaymentId;
                        if (isAutomatic)
                        {
                            LedgerPosting.invoiceNo = strInvoiceNo;
                        }
                        else
                        {
                            LedgerPosting.invoiceNo = txtAdvanceVoucherNo.Text.Trim();
                        }

                        LedgerPosting.chequeNo = string.Empty;
                        LedgerPosting.chequeDate = DateTime.Now;

                        LedgerPosting.yearId = IME.FinancialYears.Where(a => a.fromDate >= DateTime.Now).Where(b => b.toDate <= DateTime.Now).FirstOrDefault().financialYearId;
                        IME.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill controls for update
        /// </summary>
        public void fillFunction()
        {
            AdvancePayment AdvancePayment = new AdvancePayment();
            AdvancePayment = IME.AdvancePayments.Where(a => a.advancePaymentId == decAdvancePaymentEditId).FirstOrDefault();
            strVoucherNo = AdvancePayment.voucherNo;
            txtAdvanceVoucherNo.Text = AdvancePayment.invoiceNo;
            strInvoiceNo = AdvancePayment.invoiceNo;
            cmbEmployee.SelectedValue = AdvancePayment.employeeId.ToString();
            dtpSalaryMonth.Value = Convert.ToDateTime(AdvancePayment.salaryMonth.ToString());
            txtDate.Text = ((DateTime)AdvancePayment.date).ToString("dd-MMM-yyyy");
            txtChequeDate.Text = ((DateTime)AdvancePayment.date).ToString("dd-MMM-yyyy");
            cmbCashOrBank.SelectedValue = AdvancePayment.ledgerId.ToString();
            txtCheckNo.Text = AdvancePayment.chequenumber;
            txtAmount.Text = AdvancePayment.amount.ToString();
            txtNarration.Text = AdvancePayment.narration;
            btnAdvancePaymentSave.Text = "Update";
            btnAdvancePaymentDelete.Enabled = true;
            decAdvancePaymentsId = decAdvancePaymentId;
            decPaymentVoucherTypeId = (decimal)AdvancePayment.voucherTypeId;
            decPaymentSuffixPrefixId = (decimal)AdvancePayment.suffixPrefixId;
            if (IME.VoucherTypes.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).FirstOrDefault().methodOfVoucherNumbering == "Automatic")
            {
                isAutomatic = true;
            }
            else
            {
                isAutomatic = false;
            }

            if (isAutomatic)
            {
                txtAdvanceVoucherNo.Enabled = false;
            }
            else
            {
                txtAdvanceVoucherNo.Enabled = true;
            }

        }



        //public void CallFromAdvanceRegister(decimal decAdvancePaymentId, frmAdvanceRegister frm)
        //{
        //    try
        //    {
        //        base.Show();
        //        decAdvancePaymentEditId = decAdvancePaymentId;
        //        frmAdvanceRegisterObj = frm;
        //        frm.Enabled = false;
        //        fillFunction();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AP9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}



        //public void CallFromDayBook(frmDayBook frmDayBook, decimal decMasterId)
        //{
        //    try
        //    {
        //        base.Show();
        //        frmDayBook.Enabled = false;
        //        decAdvancePaymentEditId = decMasterId;
        //        frmDayBookObj = frmDayBook;

        //        fillFunction();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("AP10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to call this form from VoucherType Selection form
        /// </summary>
        /// <param name="strVoucherTypeId"></param>
        /// <param name="strVoucherTypeName"></param>
        //public void CallFromVoucherTypeSelection(decimal strVoucherTypeId, string strVoucherTypeName)
        //{
        //    try
        //    {
        //        strPaymentVoucherTypeId = strVoucherTypeId.ToString();
        //        decPaymentVoucherTypeId = strVoucherTypeId;
        //        VoucherTypeSP spvouchertype = new VoucherTypeSP();
        //        isAutomatic = spvouchertype.CheckMethodOfVoucherNumbering(Convert.ToDecimal(strVoucherTypeId.ToString()));
        //        SuffixPrefixSP spSuffisprefix = new SuffixPrefixSP();
        //        SuffixPrefixInfo infoSuffixPrefix = new SuffixPrefixInfo();
        //        infoSuffixPrefix = spSuffisprefix.GetSuffixPrefixDetails(Convert.ToDecimal(strPaymentVoucherTypeId), dtpDate.Value);
        //        decPaymentSuffixPrefixId = infoSuffixPrefix.SuffixprefixId;
        //        this.Text = strVoucherTypeName;
        //        base.Show();
        //        if (isAutomatic)
        //        {
        //            txtDate.Focus();
        //        }
        //        else
        //        {
        //            txtAdvanceVoucherNo.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AP11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Function to fill Employee combobox
        /// </summary>
        public void EmployeeComboFill()
        {
            try
            {
                cmbEmployee.DataSource = IME.Workers.Where(a => a.isActive == 1).ToList();
                cmbEmployee.ValueMember = "WorkerID";
                cmbEmployee.DisplayMember = "UserName";
                cmbEmployee.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public string VoucherNumberGeneration(decimal JournalVoucherTypeId, decimal Box, DateTime VoucherDate, string tableName1)
        {
            if (IME.SuffixPrefixes.Where(a => a.voucherTypeId == (decimal)JournalVoucherTypeId).Where(b => b.fromDate < VoucherDate).Where(c => c.toDate > VoucherDate).ToList().Count == 0)
            {
                if (Box == 0)
                {
                    if (IME.AdvancePayments.Where(a => a.voucherTypeId == JournalVoucherTypeId).FirstOrDefault() != null)
                    {
                        Box = decimal.Parse(IME.AdvancePayments.Where(a => a.voucherTypeId == JournalVoucherTypeId).FirstOrDefault().voucherNo);
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

        public void VoucherNoGeneration()
        {
            //TransactionsGeneralFill obj = new TransactionsGeneralFill();
            //AdvancePaymentSP spAdvancePayment = new AdvancePaymentSP();
            if (strVoucherNo == string.Empty)
            {
                strVoucherNo = "0";
            }
            strVoucherNo = VoucherNumberGeneration(decPaymentVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpSalaryMonth.Value, strAdvancePayment);
            decimal decJournalVoucherTypeIdmax = 0;
            if (IME.AdvancePayments.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).Select(b => b.voucherNo).ToList().Count() != 0) decJournalVoucherTypeIdmax = IME.JournalMasters.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).Select(b => b.voucherNo).ToList().Select(decimal.Parse).ToList().Max();

            if (Convert.ToDecimal(strVoucherNo) != decJournalVoucherTypeIdmax + 1)
            {
                strVoucherNo = decJournalVoucherTypeIdmax.ToString();
                strVoucherNo = VoucherNumberGeneration(decPaymentVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpSalaryMonth.Value, strAdvancePayment);
                if (decJournalVoucherTypeIdmax == 0)
                {
                    strVoucherNo = "0";
                    strVoucherNo = VoucherNumberGeneration(decPaymentVoucherTypeId, Convert.ToDecimal(strVoucherNo), dtpSalaryMonth.Value, strAdvancePayment);
                }
            }
            if (isAutomatic)
            {
                SuffixPrefix SuffixPrefix = IME.SuffixPrefixes.Where(a => a.voucherTypeId == decPaymentVoucherTypeId).Where(b => b.fromDate < dtpDate.Value).Where(c => c.toDate > dtpDate.Value).FirstOrDefault();
                strPrefix = SuffixPrefix.prefix;
                strSuffix = SuffixPrefix.suffix;
                strInvoiceNo = strPrefix + strVoucherNo + strSuffix;
                txtAdvanceVoucherNo.Text = strInvoiceNo;
                txtAdvanceVoucherNo.Enabled = false;
            }
        }
        /// <summary>
        /// Function to clear the fields
        /// </summary>
        public void Clear()
        {
            if (isAutomatic)
            {
                VoucherNoGeneration();
                txtDate.Focus();
            }
            else
            {
                txtAdvanceVoucherNo.Text = string.Empty;
                txtAdvanceVoucherNo.Enabled = true;
                txtAdvanceVoucherNo.Focus();
            }
            cmbEmployee.SelectedIndex = -1;
            txtCheckNo.Clear();
            txtNarration.Clear();
            dtpDate.Value = DateTime.Now;
            dtpSalaryMonth.Value = DateTime.Now;
            txtAmount.Clear();
            cmbCashOrBank.SelectedIndex = -1;
            dtpCheckDate.Value = DateTime.Now;
            btnAdvancePaymentSave.Text = "Save";
            btnAdvancePaymentDelete.Enabled = false;



        }

        public void DeleteFunction()
        {
            MonthlySalary MonthlySalary = new MonthlySalary();
            //MonthlySalarySP spMonthlySalary = new MonthlySalarySP();

            if (IME.SalaryVoucherDetails.Where(a => a.employeeId == Convert.ToDecimal(cmbEmployee.SelectedValue.ToString()))
                .Where(b => b.status == "paid").Where(c => c.SalaryVoucherMaster.month == dtpSalaryMonth.Value) == null
                )
            {
                IME.AdvancePayments.Remove(IME.AdvancePayments.Where(a => a.advancePaymentId == Convert.ToDecimal(decAdvancePaymentEditId.ToString())).FirstOrDefault());
                IME.LedgerPostings.Remove(
                    IME.LedgerPostings.Where(a => a.voucherTypeId == decAdvancePaymentEditId).
                    Where(b => b.voucherNo == txtAdvanceVoucherNo.Text.Trim()).FirstOrDefault()
                    );
                MessageBox.Show("Deleted successfully ");
                txtAdvanceVoucherNo.Focus();
                Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("You can't delete,reference exist");
                dtpSalaryMonth.Focus();
            }


        }

        public void Delete()
        {
            DeleteFunction();
        }


        public bool CheckAdvanceAmount()
        {
            bool Cancel = true;
            decimal decEmployeeId = 0;
            //AdvancePaymentSP spAdvancePayment = new AdvancePaymentSP();

            decimal decEmployeesalary = 0;
            if (cmbEmployee.SelectedValue != null)
            {
                decEmployeeId = Convert.ToDecimal(cmbEmployee.SelectedValue.ToString());
            }
            decEmployeesalary = (decimal)IME.Workers.Where(a => a.WorkerID == decEmployeeId).FirstOrDefault().Designation.advanceAmount;


            decimal txtamountvalue = 0;
            if (txtAmount.Text != string.Empty)
            {
                txtamountvalue = Convert.ToDecimal(txtAmount.Text.ToString());
            }
            if (txtamountvalue > decEmployeesalary)
            {
                MessageBox.Show("Advance of this month exceeds than amount set  for  the employee", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                Cancel = false;
            }
            return Cancel;
        }
        /// <summary>
        /// Function to check wheteher cash or bank is selected
        /// </summary>
        public void CheckWhetherBankOrCash()
        {

            //----- To make readonly txtChequeNo and txtChequeDate if selected ledger group is cash-----//
            if (cmbCashOrBank.SelectedValue != null && cmbCashOrBank.SelectedValue.ToString() != string.Empty)
            {
                decimal decLedger = Convert.ToDecimal(cmbCashOrBank.SelectedValue.ToString());
                bool isBankAcocunt = false;
                //AccountGroupSP SpGroup = new AccountGroupSP();
                List<AccountLedger> AccountLedgerList = new List<AccountLedger>();
                AccountLedgerList.Add(IME.AccountLedgers.Where(a => a.AccountGroup.accountGroupName == "Cash -in Hand").FirstOrDefault());
                AccountLedgerList.AddRange(
                    IME.AccountLedgers.Where(a => a.AccountGroup.groupUnder == IME.AccountLedgers.Where(b => b.AccountGroup.accountGroupName == "Cash -in Hand").FirstOrDefault().accountGroupID)
                    );
                //-------- Checking whether the selected legder is under bank----------//
                foreach (var dr in AccountLedgerList)
                {
                    string str = dr.ledgerId.ToString();
                    if (decLedger == dr.ledgerId)
                    {
                        isBankAcocunt = true;
                    }
                }
                if (isBankAcocunt)
                {
                    txtCheckNo.Enabled = false;
                    txtChequeDate.Enabled = false;
                    dtpCheckDate.Enabled = false;
                    txtCheckNo.Clear();
                }
                else
                {
                    txtCheckNo.Enabled = true;
                    txtChequeDate.Enabled = true;
                    dtpCheckDate.Enabled = true;
                }
            }

        }

        //programdan bak
        public void ReturnFromAccountLedgerForm(decimal decId)
        {
            TransactionsGeneralFill obj = new TransactionsGeneralFill();
            obj.CashOrBankComboFill(cmbCashOrBank, false);
            cmbCashOrBank.SelectedValue = decId.ToString();
            if (decId.ToString() != "0")
            {
                cmbCashOrBank.SelectedValue = decId;
            }
            else if (strLedgerId != string.Empty)
            {
                cmbCashOrBank.SelectedValue = strLedgerId;
            }
            else
            {
                cmbCashOrBank.SelectedIndex = -1;
            }
            this.Enabled = true;
            cmbCashOrBank.Focus();

        }
        /// <summary>
        /// Function to call frmLedgerPopup form to select and view Ledgers
        /// </summary>
        /// <param name="frmLedgerPopup"></param>
        /// <param name="decId"></param>
        public void CallFromLedgerPopup(frmLedgerPopup frmLedgerPopup, decimal decId) //PopUp
        {
            try
            {
                base.Show();
                this.frmLedgerPopupObj = frmLedgerPopup;
                TransactionsGeneralFill obj = new TransactionsGeneralFill();
                obj.CashOrBankComboFill(cmbCashOrBank, false);
                cmbCashOrBank.SelectedValue = decId;
                cmbCashOrBank.Focus();
                frmLedgerPopupObj.Close();
                frmLedgerPopupObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call this form from frmLedgerDetails to view details for updation
        /// </summary>
        /// <param name="frmLedgerDetails"></param>
        /// <param name="decMasterId"></param>
        //public void CallFromLedgerDetails(frmLedgerDetails frmLedgerDetails, decimal decMasterId)
        //{
        //    try
        //    {
        //        base.Show();
        //        decAdvancePaymentEditId = decMasterId;
        //        frmLedgerDetailsObj = frmLedgerDetails;
        //        frmLedgerDetailsObj.Enabled = false;
        //        fillFunction();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AP21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //}
        //#endregion

        #region Events
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAdvancePayment_Load(object sender, EventArgs e)
        {
            dtpSalaryMonth.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            dtpDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            dtpCheckDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            //TransactionsGeneralFill obj = new TransactionsGeneralFill();
            //obj.CashOrBankComboFill(cmbCashOrBank, false);
            EmployeeComboFill();
            btnAdvancePaymentDelete.Enabled = false;
            Clear();
            isLoad = true;
            //dtpDate.MinDate = PublicVariables._dtFromDate;
            //dtpDate.MaxDate = PublicVariables._dtToDate;
        }

        private void btnAdvancePaymetClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        /// <summary>
        /// on 'btnAdvancePaymentEmployee' click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdvancePaymentEmployee_Click(object sender, EventArgs e)
        {

            if (cmbEmployee.SelectedValue != null)
            {
                strEmployeeId = cmbEmployee.SelectedValue.ToString();
            }
            else
            {
                strEmployeeId = string.Empty;
            }

            this.Hide();
            CustomerMain form = new CustomerMain(true);
            form.ShowDialog();
            this.Show();

        }
        /// <summary>
        /// On 'Close' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdvancePaymentClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure to Close" + ContactListItem.contactName + " ?", "Close", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnAdvancePaymentSave_Click(object sender, EventArgs e)
        {
            decimal decAmount = 0;
            if (Convert.ToDateTime(dtpSalaryMonth.Text) >= Convert.ToDateTime(DateTime.Now.ToString("MMM-yyyy")))
            {
                if (txtAmount.Text.Trim() != "")
                {
                    decAmount = Convert.ToDecimal(txtAmount.Text.Trim());
                }

                if (decAmount > 0)
                {
                    SaveOrEdit();
                }
                else
                {
                    MessageBox.Show("Please enter valid amount");
                    txtAmount.Focus();
                }
            }
        }
        /// <summary>
        /// On 'Delete' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdvancePaymentDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        /// <summary>
        /// Fills the Date textbox on dtpDate datetimepicker value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = this.dtpDate.Value;
            this.txtDate.Text = date.ToString("dd-MMM-yyyy");
            txtDate.Focus();
        }
        /// <summary>
        /// Fills the ChequeDate textbox on dtpCheckDate datetimepicker value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpCheckDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = this.dtpCheckDate.Value;
            this.txtChequeDate.Text = date.ToString("dd-MMM-yyyy");
        }
        /// <summary>
        /// Calls the frmAccountLedger form on btnCashOrBank click to create a new ledger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCashOrBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCashOrBank.SelectedValue != null)
                {
                    strLedgerId = cmbCashOrBank.SelectedValue.ToString();
                }
                else
                {
                    strLedgerId = string.Empty;
                }

                frmAccountLedger frmaccountledger = new frmAccountLedger();
                frmaccountledger.ShowDialog();

                this.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("AP31:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Checks whetehr cash or bank is selected on cmbCashOrBank combobox SelectedValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCashOrBank_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isLoad)
                {
                    CheckWhetherBankOrCash();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP32:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion

        # region Navigation
        /// <summary>
        /// Escape key navigation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAdvancePayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    this.Close();
            //}
        }
        /// <summary>
        /// Decimal validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                Common.DecimalValidation(sender, e, false);

            }

            catch (Exception ex)
            {
                MessageBox.Show("AP34:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// Date validation on txtDate Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation objDateValidation = new DateValidation();
                objDateValidation.DateValidationFunction(txtDate);
                if (txtDate.Text == string.Empty)
                {
                    txtDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
                dtpDate.Value = Convert.ToDateTime(txtDate.Text);
                if (btnAdvancePaymentSave.Text != "Update")
                {
                    VoucherNoGeneration();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP35:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date validation on txtChequeDate Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtChequeDate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation obj = new DateValidation();

                bool isInvalid = obj.DateValidationFunction(txtChequeDate);
                if (!isInvalid)
                {
                    txtChequeDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP36:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAdvanceVoucherNo_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show("AP37:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbEmployee.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtDate.Text == string.Empty || txtDate.SelectionStart == 0)
                    {
                        if (!txtAdvanceVoucherNo.ReadOnly)
                        {
                            txtAdvanceVoucherNo.Focus();
                            txtAdvanceVoucherNo.SelectionStart = 0;
                            txtAdvanceVoucherNo.SelectionLength = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP38:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// Enter key and backspace  navigation and calls frmEmployeePopup to create new Employee 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEmployee_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtAmount.Focus();
            }
            if (cmbEmployee.Text == string.Empty || cmbEmployee.SelectionStart == 0)
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtDate.Focus();
                    txtDate.SelectionStart = 0;
                    txtDate.SelectionLength = 0;
                }
            }
            if (e.KeyCode == Keys.C && Control.ModifierKeys == Keys.Alt)
            {
                SendKeys.Send("{F10}");
                btnAdvancePaymentEmployee_Click(sender, e);
            }



        }
        

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dtpSalaryMonth.Enabled != false)
                    {
                        dtpSalaryMonth.Focus();
                    }
                    else
                    {
                        cmbCashOrBank.Focus();
                    }
                }
                if (txtAmount.Text == string.Empty || txtAmount.SelectionStart == 0)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        cmbEmployee.Focus();
                        cmbEmployee.SelectionStart = 0;
                        cmbEmployee.SelectionLength = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP40:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// Enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpSalaryMonth_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCashOrBank.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtAmount.Focus();
                    txtAmount.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP41:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        

        private void cmbCashOrBank_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (txtCheckNo.Enabled == true)
                {
                    txtCheckNo.Focus();
                }
                else
                {
                    txtNarration.Focus();
                }
            }
            if (e.KeyCode == Keys.Back)
            {
                dtpSalaryMonth.Focus();
            }
        }

        private void txtCheckNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtChequeDate.Focus();
                }
                if (txtCheckNo.Text == string.Empty || txtCheckNo.SelectionStart == 0)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        cmbCashOrBank.Focus();
                        cmbCashOrBank.SelectionStart = 0;
                        cmbCashOrBank.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP43:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtChequeDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNarration.Focus();
                }
                if (txtChequeDate.Text == string.Empty || txtChequeDate.SelectionStart == 0)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        txtCheckNo.Focus();
                        txtCheckNo.SelectionStart = 0;
                        txtCheckNo.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP44:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtNarration.Text.Trim() == string.Empty || txtNarration.SelectionStart == 0)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        if (txtChequeDate.Enabled == true)
                        {
                            txtChequeDate.Focus();
                            txtChequeDate.SelectionStart = 0;
                            txtChequeDate.SelectionLength = 0;
                        }
                        else
                        {
                            cmbCashOrBank.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP45:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
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
                        btnAdvancePaymentSave.Focus();
                    }
                }
                else
                {
                    inNarrationCount = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP46:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                inNarrationCount = 0;
                txtNarration.Text = txtNarration.Text.Trim();
                if (txtNarration.Text.Trim() == string.Empty)
                {
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
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
                MessageBox.Show("AP47:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnAdvancePaymentSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtNarration.Focus();
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP48:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmAdvancePayment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {

                    btnAdvancePaymentSave_Click(sender, e);
                }
                if (btnAdvancePaymentDelete.Enabled == true)
                {
                    if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
                    {
                        btnAdvancePaymentDelete_Click(sender, e);
                    }
                }
                if (e.KeyCode == Keys.C && Control.ModifierKeys == Keys.Alt)
                {
                    SendKeys.Send("{ESC}");
                    if (cmbEmployee.Focused)
                    {
                        btnAdvancePaymentEmployee_Click(sender, e);

                    }
                    if (cmbCashOrBank.Focused)
                    {
                        btnCashOrBank_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AP49:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}