﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.Account.Services;
using LoginForm.Account;
using LoginForm.DataSet;
using LoginForm.Services;
using LoginForm.PurchaseOrder;
using LoginForm.QuotationModule;
using LoginForm.nmSaleOrder;
using LoginForm.Invoice;


namespace LoginForm
{
    public partial class frmVoucherSearch : Form
    {
        IMEEntities IME = new IMEEntities();

        #region Public Variables
        /// <summary>
        /// Public variable declaration Part
        /// </summary>
        TransactionsGeneralFill transactionGeneralFillObj = new TransactionsGeneralFill();
        string strVoucherTypeText = string.Empty;
        string strInvoiceNo = string.Empty;
        decimal decLedgerId = 0;
        string decEmployeeId;
        decimal decVoucherTypeId = 0;
        int inCurrenRowIndex = 0;
        VoucherTypeSP spVoucherType = new VoucherTypeSP();
        #endregion
        #region Functions
        /// <summary>
        /// Crerate an Instance for frmVoucherSearch
        /// </summary>
        public frmVoucherSearch()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  Function to fill AccountLedger Combobox
        /// </summary>
        public void AccountLedgerComboFill()
        {
            
        }
        /// <summary>
        /// Function to fill voucherType Combobox
        /// </summary>
        public void voucherTypeComboFill()
        {
            try
            {
                spVoucherType.voucherTypeComboFill(cmbVoucherType, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        public void GotoPurchaseOrder()
        {
            decimal item_code = 0;

            try
            {
                if (dgvVoucherSearch.CurrentRow.Cells["Id"].Value != null)
                {
                    item_code = Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString());

                    if (item_code == 0)
                        MessageBox.Show("Please Enter a ID", "Eror !");
                    else
                    {
                        this.Close();
                        NewPurchaseOrder f = new NewPurchaseOrder(item_code);
                        f.ShowDialog();
                    }
                }
                else
                {
                    NewPurchaseOrder f = new NewPurchaseOrder(item_code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS3:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        public void GotoStockJournal()
        {
            string item_code = null;

            try
            {
                if (dgvVoucherSearch.CurrentRow.Cells["Id"].Value != null)
                {
                    item_code = dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString();

                    if (item_code == null)
                        MessageBox.Show("Please Enter a ID", "Eror !");
                    else
                    {
                        this.Close();
                        //frmStock f = new frmStock(item_code);
                        //f.ShowDialog();
                    }
                }
                else
                {
                   // frmStock f = new frmStock(item_code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS4:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        public void GotoSalesQuotation()
        {
            string item_code = null;

            try
            {
                if (dgvVoucherSearch.CurrentRow.Cells["Id"].Value != null)
                {
                    item_code = dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString();

                    if (item_code == null)
                        MessageBox.Show("Please Enter a ID", "Eror !");
                    else
                    {
                        this.Close();
                        FormQuotationAdd f = new FormQuotationAdd(item_code);
                        f.ShowDialog();
                    }
                }
                else
                {
                    FormQuotationAdd f = new FormQuotationAdd(item_code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        public void GotoSalesOrder()
        {
            string item_code = null;

            try
            {
                if (dgvVoucherSearch.CurrentRow.Cells["Id"].Value != null)
                {
                    item_code = dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString();

                    if (item_code == null)
                        MessageBox.Show("Please Enter a ID", "Eror !");
                    else
                    {
                        this.Close();
                        DevFormSaleOrderAdd f = new DevFormSaleOrderAdd(item_code);
                        f.ShowDialog();
                    }
                }
                else
                {
                    DevFormSaleOrderAdd f = new DevFormSaleOrderAdd(item_code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        //public void GotoMaterialReceipt()
        //{
        //    try
        //    {
        //        frmMaterialReceipt objfrmMaterialReceipt = new frmMaterialReceipt();
        //        frmMaterialReceipt open = Application.OpenForms["frmMaterialReceipt"] as frmMaterialReceipt;
        //        if (open == null)
        //        {
        //            objfrmMaterialReceipt.WindowState = FormWindowState.Normal;
        //            objfrmMaterialReceipt.MdiParent = formMDI.MDIObj;
        //            objfrmMaterialReceipt.Show();
        //            objfrmMaterialReceipt.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            open.MdiParent = formMDI.MDIObj;
        //            if (open.WindowState == FormWindowState.Minimized)
        //            {
        //                open.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                open.Activate();
        //            }
        //            open.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            open.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        //public void GotoContraVoucher()
        //{
        //    try
        //    {
        //        frmContraVoucher frmContra = new frmContraVoucher();
        //        frmContraVoucher _isOpen = Application.OpenForms["frmContraVoucher"] as frmContraVoucher;
        //        if (_isOpen == null)
        //        {
        //            frmContra.WindowState = FormWindowState.Normal;
        //            frmContra.MdiParent = formMDI.MDIObj;
        //            frmContra.Show();
        //            frmContra.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            _isOpen.MdiParent = formMDI.MDIObj;
        //            if (_isOpen.WindowState == FormWindowState.Minimized)
        //            {
        //                _isOpen.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                _isOpen.Activate();
        //            }
        //            _isOpen.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            _isOpen.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoJournalVoucher()
        //{
        //    try
        //    {
        //        frmJournalVoucher frmobj = new frmJournalVoucher();
        //        frmJournalVoucher _isOpen = Application.OpenForms["frmJournalVoucher"] as frmJournalVoucher;
        //        if (_isOpen == null)
        //        {
        //            frmobj.WindowState = FormWindowState.Normal;
        //            frmobj.MdiParent = formMDI.MDIObj;
        //            frmobj.Show();
        //            frmobj.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            _isOpen.MdiParent = formMDI.MDIObj;
        //            if (_isOpen.WindowState == FormWindowState.Minimized)
        //            {
        //                _isOpen.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                _isOpen.Activate();
        //            }
        //            _isOpen.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            _isOpen.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS9:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoCrditNote()
        //{
        //    try
        //    {
        //        frmCreditNote frmobj = new frmCreditNote();
        //        frmCreditNote _isOpen = Application.OpenForms["frmCreditNote"] as frmCreditNote;
        //        if (_isOpen == null)
        //        {
        //            frmobj.WindowState = FormWindowState.Normal;
        //            frmobj.MdiParent = formMDI.MDIObj;
        //            frmobj.Show();
        //            frmobj.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            _isOpen.MdiParent = formMDI.MDIObj;
        //            if (_isOpen.WindowState == FormWindowState.Minimized)
        //            {
        //                _isOpen.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                _isOpen.Activate();
        //            }
        //            _isOpen.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            _isOpen.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoDebitNote()
        //{
        //    try
        //    {
        //        frmDebitNote frmobj = new frmDebitNote();
        //        frmDebitNote _isOpen = Application.OpenForms["frmDebitNote"] as frmDebitNote;
        //        if (_isOpen == null)
        //        {
        //            frmobj.WindowState = FormWindowState.Normal;
        //            frmobj.MdiParent = formMDI.MDIObj;
        //            frmobj.Show();
        //            frmobj.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            _isOpen.MdiParent = formMDI.MDIObj;
        //            if (_isOpen.WindowState == FormWindowState.Minimized)
        //            {
        //                _isOpen.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                _isOpen.Activate();
        //            }
        //            _isOpen.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            _isOpen.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        //public void GotoAdvancePayment()
        //{
        //    try
        //    {
        //        frmAdvancePayment frmobj = new frmAdvancePayment();
        //        frmAdvancePayment _isOpen = Application.OpenForms["frmAdvancepayment"] as frmAdvancePayment;
        //        if (_isOpen == null)
        //        {
        //            frmobj.WindowState = FormWindowState.Normal;
        //            frmobj.MdiParent = formMDI.MDIObj;
        //            frmobj.Show();
        //            frmobj.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            _isOpen.MdiParent = formMDI.MDIObj;
        //            if (_isOpen.WindowState == FormWindowState.Minimized)
        //            {
        //                _isOpen.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                _isOpen.Activate();
        //            }
        //            _isOpen.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            _isOpen.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        //public void GotoDailySalaryVoucher()
        //{
        //    try
        //    {
        //        frmDailySalaryVoucher frmobj = new frmDailySalaryVoucher();
        //        frmDailySalaryVoucher _isOpen = Application.OpenForms["frmDebitNote"] as frmDailySalaryVoucher;
        //        if (_isOpen == null)
        //        {
        //            frmobj.WindowState = FormWindowState.Normal;
        //            frmobj.MdiParent = formMDI.MDIObj;
        //            frmobj.Show();
        //            frmobj.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            _isOpen.MdiParent = formMDI.MDIObj;
        //            if (_isOpen.WindowState == FormWindowState.Minimized)
        //            {
        //                _isOpen.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                _isOpen.Activate();
        //            }
        //            _isOpen.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            _isOpen.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS13:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoPaymentVoucher()
        //{
        //    try
        //    {
        //        frmPaymentVoucher frmpayment = new frmPaymentVoucher();
        //        frmPaymentVoucher _isOpen = Application.OpenForms["frmPayment"] as frmPaymentVoucher;
        //        if (_isOpen == null)
        //        {
        //            frmpayment.WindowState = FormWindowState.Normal;
        //            frmpayment.MdiParent = formMDI.MDIObj;
        //            frmpayment.Show();
        //            frmpayment.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            _isOpen.MdiParent = formMDI.MDIObj;
        //            if (_isOpen.WindowState == FormWindowState.Minimized)
        //            {
        //                _isOpen.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                _isOpen.Activate();
        //            }
        //            _isOpen.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            _isOpen.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS14:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoReceiptVoucher()
        //{
        //    try
        //    {
        //        frmReceiptVoucher frmreceipt = new frmReceiptVoucher();
        //        frmReceiptVoucher _isOpen = Application.OpenForms["frmReceipt"] as frmReceiptVoucher;
        //        if (_isOpen == null)
        //        {
        //            frmreceipt.WindowState = FormWindowState.Normal;
        //            frmreceipt.MdiParent = formMDI.MDIObj;
        //            frmreceipt.Show();
        //            frmreceipt.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            _isOpen.MdiParent = formMDI.MDIObj;
        //            if (_isOpen.WindowState == FormWindowState.Minimized)
        //            {
        //                _isOpen.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                _isOpen.Activate();
        //            }
        //            _isOpen.CallThisFormFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            _isOpen.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS15:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        public void GotoPDCPayable()
        {
            string item_code = null;

            try
            {
                if (dgvVoucherSearch.CurrentRow.Cells["Id"].Value != null)
                {
                    item_code = dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString();

                    if (item_code == null)
                        MessageBox.Show("Please Enter a ID", "Eror !");
                    else
                    {
                        this.Close();
                        frmPdcPayable f = new frmPdcPayable(item_code);
                        f.ShowDialog();
                    }
                }
                else
                {
                    frmPdcPayable f = new frmPdcPayable(item_code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS16:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        public void GotoPDCReceivable()
        {
            string item_code = null;

            try
            {
                if (dgvVoucherSearch.CurrentRow.Cells["Id"].Value != null)
                {
                    item_code = dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString();

                    if (item_code == null)
                        MessageBox.Show("Please Enter a ID", "Eror !");
                    else
                    {
                        this.Close();
                        frmPdcReceivable f = new frmPdcReceivable(item_code);
                        f.ShowDialog();
                    }
                }
                else
                {
                    frmPdcReceivable f = new frmPdcReceivable(item_code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoPDCClearance()
        //{
        //    try
        //    {
        //        frmPdcClearance frmobj = new frmPdcClearance();
        //        frmPdcClearance _isOpen = Application.OpenForms["frmPDClearance"] as frmPdcClearance;
        //        if (_isOpen == null)
        //        {
        //            frmobj.WindowState = FormWindowState.Normal;
        //            frmobj.MdiParent = formMDI.MDIObj;
        //            frmobj.Show();
        //            frmobj.CallFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            _isOpen.MdiParent = formMDI.MDIObj;
        //            if (_isOpen.WindowState == FormWindowState.Minimized)
        //            {
        //                _isOpen.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                _isOpen.Activate();
        //            }
        //            _isOpen.ClearFunction();
        //            _isOpen.CallFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            _isOpen.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        //public void GotoPhysicalStock()
        //{
        //    try
        //    {
        //        frmPhysicalStock objForm = new frmPhysicalStock();
        //        frmPhysicalStock open = Application.OpenForms["frmPhysicalStock"] as frmPhysicalStock;
        //        if (open == null)
        //        {
        //            objForm.WindowState = FormWindowState.Normal;
        //            objForm.MdiParent = formMDI.MDIObj;
        //            objForm.Show();
        //            objForm.CallFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            open.MdiParent = formMDI.MDIObj;
        //            if (open.WindowState == FormWindowState.Minimized)
        //            {
        //                open.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                open.Activate();
        //            }
        //            open.CallFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            open.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        //public void GotoDeliveryNote()
        //{
        //    try
        //    {
        //        frmDeliveryNote objfrmDeliveryNote = new frmDeliveryNote();
        //        frmDeliveryNote open = Application.OpenForms["frmDeliveryNote"] as frmDeliveryNote;
        //        if (open == null)
        //        {
        //            objfrmDeliveryNote.WindowState = FormWindowState.Normal;
        //            objfrmDeliveryNote.MdiParent = formMDI.MDIObj;
        //            objfrmDeliveryNote.Show();
        //            objfrmDeliveryNote.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            open.MdiParent = formMDI.MDIObj;
        //            if (open.WindowState == FormWindowState.Minimized)
        //            {
        //                open.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                open.Activate();
        //            }
        //            open.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            open.BringToFront();
        //        }
        //        this.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        //public void GotoRejectionIn()
        //{
        //    try
        //    {
        //        frmRejectionIn objfrmfrmRejectionIn = new frmRejectionIn();
        //        frmRejectionIn open = Application.OpenForms["frmRejectionIn"] as frmRejectionIn;
        //        if (open == null)
        //        {
        //            objfrmfrmRejectionIn.WindowState = FormWindowState.Normal;
        //            objfrmfrmRejectionIn.MdiParent = formMDI.MDIObj;
        //            objfrmfrmRejectionIn.Show();
        //            objfrmfrmRejectionIn.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            open.MdiParent = formMDI.MDIObj;
        //            if (open.WindowState == FormWindowState.Minimized)
        //            {
        //                open.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                open.Activate();
        //            }
        //            open.ClearRejectionIn();
        //            open.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            open.BringToFront();
        //        }
        //        this.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        //public void GotoRejectionOut()
        //{
        //    try
        //    {
        //        frmRejectionOut objfrmfrmRejectionOut = new frmRejectionOut();
        //        frmRejectionOut open = Application.OpenForms["frmRejectionOut"] as frmRejectionOut;
        //        if (open == null)
        //        {
        //            objfrmfrmRejectionOut.WindowState = FormWindowState.Normal;
        //            objfrmfrmRejectionOut.MdiParent = formMDI.MDIObj;
        //            objfrmfrmRejectionOut.Show();
        //            objfrmfrmRejectionOut.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            open.MdiParent = formMDI.MDIObj;
        //            if (open.WindowState == FormWindowState.Minimized)
        //            {
        //                open.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                open.Activate();
        //            }
        //            open.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            open.BringToFront();
        //        }
        //        this.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS22:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        public void GotoPurchaseInvoice()
        {
            string item_code = null;

            try
            {
                if (dgvVoucherSearch.CurrentRow.Cells["Id"].Value != null)
                {
                    item_code = dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString();

                    if (item_code == null)
                        MessageBox.Show("Please Enter a ID", "Eror !");
                    else
                    {
                        this.Close();
                        InvoiceMain f = new InvoiceMain(item_code);
                        f.ShowDialog();
                    }
                }
                else
                {
                    InvoiceMain f = new InvoiceMain(item_code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS23:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoSalesInvoice()
        //{
        //    try
        //    {
        //        SalesMasterSP SpMaster = new SalesMasterSP();
        //        SalesMasterInfo InfoMaster = new SalesMasterInfo();
        //        InfoMaster = SpMaster.SalesMasterView(Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        if (InfoMaster.POS == true)
        //        {
        //            frmPOS objfrm = new frmPOS();

        //            objfrm.WindowState = FormWindowState.Normal;
        //            objfrm.MdiParent = formMDI.MDIObj;
        //            objfrm.Show();
        //            objfrm.CallFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            frmSalesInvoice objfrmSalesInvoice = new frmSalesInvoice();
        //            frmSalesInvoice open = Application.OpenForms["frmSalesInvoice"] as frmSalesInvoice;
        //            if (open == null)
        //            {
        //                objfrmSalesInvoice.WindowState = FormWindowState.Normal;
        //                objfrmSalesInvoice.MdiParent = formMDI.MDIObj;
        //                objfrmSalesInvoice.Show();
        //                objfrmSalesInvoice.CallFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            }
        //            else
        //            {
        //                open.MdiParent = formMDI.MDIObj;
        //                if (open.WindowState == FormWindowState.Minimized)
        //                {
        //                    open.WindowState = FormWindowState.Normal;
        //                }
        //                else
        //                {
        //                    open.Activate();
        //                }
        //                open.CallFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //                open.BringToFront();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS24:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoSalesReturn()
        //{
        //    try
        //    {
        //        frmSalesReturn objfrmSalesReturn = new frmSalesReturn();
        //        frmSalesReturn open = Application.OpenForms["frmSalesReturn"] as frmSalesReturn;
        //        if (open == null)
        //        {
        //            objfrmSalesReturn.WindowState = FormWindowState.Normal;
        //            objfrmSalesReturn.MdiParent = formMDI.MDIObj;
        //            objfrmSalesReturn.Show();
        //            objfrmSalesReturn.CallFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            open.MdiParent = formMDI.MDIObj;
        //            if (open.WindowState == FormWindowState.Minimized)
        //            {
        //                open.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                open.Activate();
        //            }
        //            open.CallFromVoucherSearch(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            open.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS25:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoPurchaseReturn()
        //{
        //    try
        //    {
        //        frmPurchaseReturn objfrmPurchaseReturn = new frmPurchaseReturn();
        //        frmPurchaseReturn open = Application.OpenForms["frmPurchaseReturn"] as frmPurchaseReturn;
        //        if (open == null)
        //        {
        //            objfrmPurchaseReturn.WindowState = FormWindowState.Normal;
        //            objfrmPurchaseReturn.MdiParent = formMDI.MDIObj;
        //            objfrmPurchaseReturn.Show();
        //            objfrmPurchaseReturn.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            open.MdiParent = formMDI.MDIObj;
        //            if (open.WindowState == FormWindowState.Minimized)
        //            {
        //                open.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                open.Activate();
        //            }
        //            open.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            open.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        /// 
        // TO DO: VoucherSearch
        //public void GotoServiceVoucher()
        //{
        //    try
        //    {
        //        frmServiceVoucher objForm = new frmServiceVoucher();
        //        frmServiceVoucher open = Application.OpenForms["frmServiceVoucher"] as frmServiceVoucher;
        //        if (open == null)
        //        {
        //            objForm.WindowState = FormWindowState.Normal;
        //            objForm.MdiParent = formMDI.MDIObj;
        //            objForm.Show();
        //            objForm.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            open.MdiParent = formMDI.MDIObj;
        //            if (open.WindowState == FormWindowState.Minimized)
        //            {
        //                open.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                open.Activate();
        //            }
        //            open.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            open.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS27:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// Call Corresponding Voucher to View details for updation in edit mode
        /// </summary>
        //public void GotoMonthlySalaryVoucher()
        //{
        //    try
        //    {

        //        frmMonthlySalaryVoucher objForm = new frmMonthlySalaryVoucher();
        //        frmMonthlySalaryVoucher open = Application.OpenForms["frmMonthlySalaryVoucher"] as frmMonthlySalaryVoucher;
        //        if (open == null)
        //        {
        //            objForm.WindowState = FormWindowState.Normal;
        //            objForm.MdiParent = formMDI.MDIObj;
        //            objForm.Show();
        //            objForm.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //        }
        //        else
        //        {
        //            open.MdiParent = formMDI.MDIObj;
        //            if (open.WindowState == FormWindowState.Minimized)
        //            {
        //                open.WindowState = FormWindowState.Normal;
        //            }
        //            else
        //            {
        //                open.Activate();
        //            }
        //            open.CallFromVoucherSerach(this, Convert.ToDecimal(dgvVoucherSearch.CurrentRow.Cells["Id"].Value.ToString()));
        //            open.BringToFront();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("VS28:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        /// <summary>
        /// function to fill the Grid based on the search mode
        /// </summary>
        public void GridFill()
        {
            DataTable dtblVoucher = new DataTable();
            try
            {

                if (dtpFromDate.Value <= dtpToDate.Value)
                {

                    if (txtVoucherNo.Text.Trim() == string.Empty)
                    {
                        strInvoiceNo = string.Empty;
                    }
                    else
                    {
                        strInvoiceNo = txtVoucherNo.Text;
                    }
                  
                    if (cmbVoucherType.SelectedIndex == 0 || cmbVoucherType.SelectedIndex == -1)
                    {
                        decVoucherTypeId = -1;
                    }
                    else
                    {
                        decVoucherTypeId = Convert.ToDecimal(cmbVoucherType.SelectedValue.ToString());
                    }
                    if (cmbSalesMan.SelectedIndex == 0 || cmbSalesMan.SelectedIndex == -1)
                    {
                        decEmployeeId = "";
                    }
                    else
                    {
                        decEmployeeId = cmbSalesMan.SelectedValue.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("From date should be less than to date", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DateTime FromDate = this.dtpFromDate.Value;
                DateTime ToDate = this.dtpToDate.Value;
                dtblVoucher = spVoucherType.VoucherSearchFill(FromDate, ToDate, decVoucherTypeId, strInvoiceNo, decLedgerId, decEmployeeId);
                dgvVoucherSearch.DataSource = dtblVoucher;
                dgvVoucherSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS29:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to clear the controls
        /// </summary>
        public void Clear()
        {
            try
            {

                txtFromDate.Focus();
                dtpFromDate.Value = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy"));
                dtpFromDate.MinDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
                dtpFromDate.MaxDate = Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate);
                txtFromDate.Text = Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy");
                dtpToDate.Value = Convert.ToDateTime(Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy"));
                dtpToDate.MinDate = (DateTime)Utils.getManagement().FinancialYear.fromDate;
                dtpToDate.MaxDate = (DateTime)Utils.getManagement().FinancialYear.toDate;
                txtVoucherNo.Text = string.Empty;
                AccountLedgerComboFill();
                ComboSalesManFill();
                voucherTypeComboFill();
                GridFill();

            }
            catch (Exception ex)
            {
                MessageBox.Show("VS30:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill  Salesman combobox
        /// </summary>
        public void ComboSalesManFill()
        {
            try
            {
                DataTable dtbl = transactionGeneralFillObj.SalesmanViewAllForComboFill(cmbSalesMan, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS31:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Events
        /// <summary>
        /// Close button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //if (PublicVariables.isMessageClose)
                //{
                //    Messages.CloseMessage(this);
                //}
                //else
                //{
                this.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS43:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Date validation and set the Fromdate as dtp's value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation obj = new DateValidation();
                obj.DateValidationFunction(txtFromDate);
                if (txtFromDate.Text == string.Empty)
                {
                    txtFromDate.Text = Utils.getManagement().FinancialYear.fromDate.Value.ToString("dd-MMM-yyyy");
                }
                //---for change date in Date time picker----//
                string strdate = txtFromDate.Text;
                dtpFromDate.Value = Convert.ToDateTime(strdate.ToString());
                //------------------//
            }
            catch (Exception ex)
            {
                MessageBox.Show("BU50:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  Date validation and set the Todate as dtp's value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                DateValidation objVal = new DateValidation();
                bool isInvalid = objVal.DateValidationFunction(txtToDate);
                if (!isInvalid)
                {
                    txtToDate.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
                }
                dtpToDate.Value = Convert.ToDateTime(txtToDate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS45:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Set the text box value as to date dtp's value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpFromDate.Value;
                txtFromDate.Text = date.ToString("dd-MMM-yyyy");
                txtFromDate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS46:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///  Set the text box value as From date dtp's value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = this.dtpToDate.Value;
                this.txtToDate.Text = date.ToString("dd-MMM-yyyy");
                txtToDate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS47:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// When form load clear the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmVoucherSearch_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS48:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Call the clear function in reset button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS49:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// txtToDate text changed, set the text box value and validating the date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToDate_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtToDate.Text == string.Empty && !txtToDate.Focused)
            //    {
            //        DateValidation objVal = new DateValidation();
            //        bool isInvalid = objVal.DateValidationFunction(txtToDate);
            //        if (!isInvalid)
            //        {
            //            txtToDate.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
            //        }
            //        dtpToDate.Value = Convert.ToDateTime(txtToDate.Text);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("VS50:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        /// <summary>
        /// Search button click, call the gridfill function
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
                MessageBox.Show("VS51:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Grid Cell double click to view thw purticular details in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVoucherSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    btnViewDetails_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS52:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Butten view details click to view thw purticular details in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ExportToItemHistory(dgvVoucherSearch);
        }
        #endregion Events
        #region Navigation
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtToDate.SelectionStart = txtToDate.Text.Length;
                    txtToDate.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtFromDate.SelectionLength != 11)
                    {
                        if (txtFromDate.Text == string.Empty || txtFromDate.SelectionStart == 0)
                        {
                            cmbVoucherType.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BU44 :" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbVoucherType.Focus();
                }
                else if (e.KeyCode == Keys.Back)
                {
                    if (txtToDate.SelectionStart == 0 || txtToDate.Text == string.Empty)
                    {
                        txtFromDate.Focus();
                        txtFromDate.SelectionStart = 0;
                        txtFromDate.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS55:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbVoucherType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtVoucherNo.Enabled)
                    {
                        txtVoucherNo.Focus();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtToDate.Enabled)
                    {
                        txtToDate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS56:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbVoucherType.Enabled)
                    {
                        if (txtVoucherNo.SelectionStart == 0)
                        {
                            cmbVoucherType.Focus();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("VS57:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCashOrParty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbSalesMan.Enabled)
                    {
                        cmbSalesMan.Focus();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtVoucherNo.Enabled)
                    {
                        txtVoucherNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS58:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSalesMan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (btnSearch.Enabled)
                    {
                        btnSearch.Focus();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS59:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnReset.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbSalesMan.Enabled)
                    {
                        cmbSalesMan.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS60:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvVoucherSearch.Enabled)
                    {
                        dgvVoucherSearch.Focus();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (btnSearch.Enabled)
                    {
                        btnSearch.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS61:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVoucherSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    btnViewDetails_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Back)
                {
                    cmbSalesMan.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS62:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// For enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmVoucherSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VS63:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

      
    }
}
