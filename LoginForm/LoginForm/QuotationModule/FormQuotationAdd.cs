﻿using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using static LoginForm.Services.MyClasses.MyAuthority;
using Excel = Microsoft.Office.Interop.Excel;
using LoginForm.Services.SP;
using System.Data.Entity.Validation;
using System.Xml;

namespace LoginForm.QuotationModule
{
    public partial class FormQuotationAdd : DevExpress.XtraEditors.XtraForm
    {
        SqlHelper sqlHelper = new SqlHelper();
        string manuelSelection = string.Empty;
        private static string QuoStatusActive = "Not Ordered";
        FormQuaotationCustomerSearch parentCustomer;
        FormQuotationMain parent;
        List<int> enabledColumns = new List<int>(new int[] { 0, 7, 14, 21, 28, 35 });
        #region Definitions
        GetWorkerService GetWorkerService = new GetWorkerService();
        DataTable TotalCostList = new DataTable();
        DataGridViewRow CurrentRow;
        IMEEntities IME = new IMEEntities();
        decimal price;
        ContextMenu DeletedQuotationMenu = new ContextMenu();
        ExchangeRate curr = new ExchangeRate();
        decimal vat = (decimal)Utils.getManagement().VAT;
        decimal totallbl = 0;
        Decimal CurrValue = 1;
        Decimal CurrValue1 = 1;
        decimal Currfactor = 1;
        private int currentRow;
        private bool resetRow = false;
        decimal CurrentDis;
        decimal LowMarginLimit;
        public static Customer customer;
        bool modifyMod = false;
        Quotation mainQuo = new Quotation();
        decimal? totalmargin = 0;
        ToolTip aciklama = new ToolTip();
        System.Data.DataSet ds = new System.Data.DataSet();
        int a = 1;
        int importFromQuotation = 0;
        string mod = "";
        string cName = "";
        string cID = "";
        DataTable table = new DataTable();
        int sayac = 0;
        DataGridViewCellStyle boldStyle = new DataGridViewCellStyle();
        #endregion

        public FormQuotationAdd(FormQuaotationCustomerSearch parent, string customerName, string customerId)
        {
            InitializeComponent();
            dgQuotationAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgQuotationDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

             typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgQuotationAddedItems, new object[] { true });


            cName = customerName;
            cID = customerId;
            dtpDate.Value = Utils.GetCurrentDateTime();
            dtpDate.Enabled = false;
            //this.parentCustomer = parent;
            txtQuotationNo.PasswordChar = ' ';
            btnCreateRev.Enabled = false;
            label68.Enabled = false;

            if (customerName != null && customerName != "")
            {
                #region customer
                txtCustomerName.Text = cName;
                CustomerCode.Text = cID;

                var customerList = IME.Customers.Where(a => a.c_name.Contains(txtCustomerName.Text)).ToList();

                this.Enabled = true;
                customer = customerList.FirstOrDefault();
                lblCustomerFactorValue.Text = customer.factor.ToString();
                lblCustomerDiscountValue.Text = customer.discountrate.ToString();
                lblCustomerMarkupValue.Text = customer.Markup.ToString();
                cbWorkers.Items.AddRange(customer.CustomerWorkers.ToArray());
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.ValueMember = "ID";
                if (customer.paymentmethodID != null)
                {
                    cbPayment.SelectedIndex = cbPayment.FindStringExact(customer.PaymentTerm.term_name);
                }
                try { txtContactNote.Text = customer.CustomerWorker.Note.Note_name; } catch { }
                try { txtCustomerNote.Text = customer.Note.Note_name; } catch { }
                try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == customer.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
                if (customer.Worker != null) cbRep.SelectedValue = customer.Worker.WorkerID;
                if (this.Text != "Edit Quotation")
                {
                    var CustomerCurr = IME.Currencies.Where(a => a.currencyName == customer.CurrNameQuo).FirstOrDefault();
                    if (CustomerCurr != null) cbCurrency.SelectedValue = CustomerCurr.currencyID;
                }
                if (customer.CustomerWorker != null)
                {
                    cbWorkers.SelectedValue = customer.CustomerWorker.ID;
                    cbWorkers.SelectedItem = cbWorkers.FindStringExact(customer.CustomerWorker.cw_name);
                }
                btnContactAdd.Enabled = true;
                #endregion
            }
        }

        public FormQuotationAdd(string customerId)
        {
            InitializeComponent();
            dgQuotationAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgQuotationDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
        dgQuotationAddedItems, new object[] { true });


            cID = customerId;
            dtpDate.Value = Utils.GetCurrentDateTime();
            dtpDate.Enabled = false;
            //this.parentCustomer = parent;
            txtQuotationNo.PasswordChar = ' ';
            btnCreateRev.Enabled = false;
            label68.Enabled = false;

            groupBox1.Enabled = false;
            chkCustomerDiscount.Enabled = false;
            lblCustomerDiscountValue.Enabled = false;
            chkFirstUPIME.Enabled = false;

            #region customer

            var customerList = IME.Customers.Where(a => a.ID==cID).ToList();

            this.Enabled = true;
            customer = customerList.FirstOrDefault();
            CustomerCode.Text = cID;
            txtCustomerName.Text = customer.c_name;
            lblCustomerFactorValue.Text = customer.factor.ToString();
            lblCustomerDiscountValue.Text = customer.discountrate.ToString();
            lblCustomerMarkupValue.Text = customer.Markup.ToString();
            cbWorkers.Items.AddRange(customer.CustomerWorkers.ToArray());
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
            if (customer.paymentmethodID != null)
            {
                cbPayment.SelectedIndex = cbPayment.FindStringExact(customer.PaymentTerm.term_name);
            }
            try { txtContactNote.Text = customer.CustomerWorker.Note.Note_name; } catch { }
            try { txtCustomerNote.Text = customer.Note.Note_name; } catch { }
            try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == customer.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
            if (customer.Worker != null) cbRep.SelectedValue = customer.Worker.WorkerID;
            if (this.Text != "Edit Quotation")
            {
                var CustomerCurr = IME.Currencies.Where(a => a.currencyName == customer.CurrNameQuo).FirstOrDefault();
                if (CustomerCurr != null) cbCurrency.SelectedValue = CustomerCurr.currencyID;
            }
            if (customer.CustomerWorker != null)
            {
                cbWorkers.SelectedValue = customer.CustomerWorker.ID;
                cbWorkers.SelectedItem = cbWorkers.FindStringExact(customer.CustomerWorker.cw_name);
            }
            btnContactAdd.Enabled = true;
            #endregion

            dtpDate.Value = Utils.GetCurrentDateTime();
            cbPayment.DataSource = IME.PaymentTerms.ToList();
            cbPayment.DisplayMember = "term_name";
            cbPayment.ValueMember = "ID";
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.ValueMember = "WorkerID";
            cbRep.DisplayMember = "NameLastName";
            cbRep.SelectedValue = Utils.getCurrentUser().WorkerID;
            cbFactor.Text = Utils.getManagement().Factor.ToString();
            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            cbCurrency.SelectedValue = Utils.getManagement().DefaultCurrency;

            DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
            dgQuotationAddedItems.Rows.Add(dgRow);
            //txtQuotationNo.Text = NewQuotationID();/*New 1*/
            txtQuotationNo.Text = CreateQuotationID(QuotationIdMod.New,null);
            dgQuotationAddedItems.Rows[0].Cells[dgNo.Index].Value = 1.ToString();
            LowMarginLimit = Decimal.Parse(IME.Managements.FirstOrDefault().LowMarginLimit.ToString());
            vat = (decimal)Utils.getManagement().VAT;
            lblVat.Text = vat.ToString();
        }

        public void FillCustomerFromSearch(string customerName, string customerId)
        {

            cName = customerName;
            cID = customerId;
            txtCustomerName.Text = cName;
            CustomerCode.Text = cID;
            var customerList = IME.Customers.Where(a => a.c_name.Contains(txtCustomerName.Text)).ToList();
            customer = customerList.FirstOrDefault();
            lblCustomerFactorValue.Text = customer.factor.ToString();
            lblCustomerDiscountValue.Text = customer.discountrate.ToString();
            lblCustomerMarkupValue.Text = customer.Markup.ToString();

            if (customer != null && customerName != null && customerName != "")
            {
                #region customer
                this.Enabled = true;
                cbWorkers.Items.AddRange(customer.CustomerWorkers.ToArray());
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.ValueMember = "ID";
                if (customer.paymentmethodID != null)
                {
                    cbPayment.SelectedIndex = cbPayment.FindStringExact(customer.PaymentTerm.term_name);
                }
                try { txtContactNote.Text = customer.CustomerWorker.Note.Note_name; } catch { }
                try { txtCustomerNote.Text = customer.Note.Note_name; } catch { }
                try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == customer.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
                if (customer.Worker != null) cbRep.SelectedValue = customer.Worker.WorkerID;
                if (this.Text != "Edit Quotation")
                {
                    var CustomerCurr = IME.Currencies.Where(a => a.currencyName == customer.CurrNameQuo).FirstOrDefault();
                    if (CustomerCurr != null) cbCurrency.SelectedValue = CustomerCurr.currencyID;
                }
                if (customer.CustomerWorker != null)
                {
                    cbWorkers.SelectedValue = customer.CustomerWorker.ID;
                    cbWorkers.SelectedItem = cbWorkers.FindStringExact(customer.CustomerWorker.cw_name);
                }
                btnContactAdd.Enabled = true;
                #endregion
            }
        }

        public FormQuotationAdd()
        {
            InitializeComponent();
            dgQuotationAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgQuotationDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgQuotationAddedItems, new object[] { true });

            dtpDate.Value = Utils.GetCurrentDateTime();
            dtpDate.Enabled = false;
        }

        public void Disc()
        {
            decimal subtotal = 0;
            if (lblsubtotal.Text != null && lblsubtotal.Text != string.Empty)
            {

                decimal dis2 = 0;
                if (txtTotalDis.Text == null || txtTotalDis.Text == "") txtTotalDis.Text = "0";
                if (lblsubtotal.Text != "" && Decimal.Parse(lblsubtotal.Text) != 0 && lblsubtotal.Text != null)
                {
                    //hz ve lithum disc dan etkilenmeyecek
                    decimal hztotal = 0;

                    for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                    {
                        if (txtHazardousInd.Text == "Y" && txtLithium.Text == "Y")
                        {
                            if (dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString() == null)
                            {
                                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[i].Cells["dgQty"];
                            }
                            else if (dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString() != null)
                            {
                                hztotal += Decimal.Parse(String.Format("{0:N}", decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString())));
                            }


                        }
                    }

                    subtotal = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(lblsubtotal.Text) - hztotal));



                    if (txtTotalDis.Text != "") dis2 = Decimal.Parse(String.Format("{0:N}", subtotal * Decimal.Parse(txtTotalDis.Text) / 100));


                }
                txtTotalDis2.Text = String.Format("{0:N}", dis2.ToString());

                //lbltotal.Text = Math.Round((Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)), 4).ToString();
                lbltotal.Text = String.Format("{0:N}", (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)));
            }
            subtotal = 0;
            decimal DiscounRate = 0;
            if (lblsubtotal.Text != "" && lblsubtotal.Text != null) subtotal = Decimal.Parse(String.Format("{0:N}", decimal.Parse(lblsubtotal.Text)));
            if (txtTotalDis.Text != "" && txtTotalDis.Text != null) DiscounRate = Decimal.Parse(String.Format("{0:N}", decimal.Parse(txtTotalDis.Text)));
            try {
                //lbltotal.Text = (decimal.Parse(lblsubtotal.Text) - ((subtotal * DiscounRate) / 100)).ToString();
                lbltotal.Text = String.Format("{0:N}", (decimal.Parse(lblsubtotal.Text) - ((subtotal * DiscounRate) / 100)).ToString());
            } catch { }

        }

        //public FormQuotationAdd(string item_code)
        //{
        //    InitializeComponent();
        //    dgQuotationAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
        //    dgQuotationDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

        //    typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
        // System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
        // dgQuotationAddedItems, new object[] { true });

        //    for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
        //    {
        //        dgQuotationAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
        //        dgQuotationAddedItems.Rows[i].Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //        dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
        //        dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //        dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
        //        dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //        dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
        //        dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //        dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
        //        dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //        dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
        //        dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //        dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
        //        dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //        GetMarginMark(i);
        //    }
        //    for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
        //    {
        //        QuotataionModifyItemDetailsFiller(item_code, i);

        //    }
        //}

        //public FormQuotationAdd(Quotation quotation, FormQuotationMain parent)
        //{
        //    InitializeComponent();
        //    dgQuotationAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
        //    dgQuotationDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

        //    typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
        // System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
        // dgQuotationAddedItems, new object[] { true });

        //    btnSave.Visible = false;
        //    label67.Visible = false;
        //    this.parent = parent;
        //    dtpDate.Value = Utils.GetCurrentDateTime();
        //    DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[dgDelivery.Index];
        //    deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
        //    deliveryColumn.DisplayMember = "DeliveryName";
        //    deliveryColumn.ValueMember = "ID";
        //    //Son versiyonu açmayı sağlıyor

        //    if (quotation.QuotationNo.Contains("v"))
        //    {
        //        //string q2 = (quotation.QuotationNo.Substring(0, quotation.QuotationNo.LastIndexOf('v') + 1)).ToString();

        //        Quotation q1 = IME.Quotations.Where(a => a.QuotationNo == quotation.QuotationNo).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
        //        mainQuo = q1;
        //        this.Text = "Edit Quotation";
        //        modifyMod = true;
        //        cbCurrency.DataSource = IME.Currencies.ToList();
        //        cbCurrency.DisplayMember = "currencyName";
        //        cbCurrency.ValueMember = "currencyID";

        //        var QuoCurr = IME.Currencies.Where(a => a.currencyName == q1.CurrName).FirstOrDefault();
        //        if (QuoCurr != null) cbCurrency.SelectedValue = QuoCurr.currencyID;

        //        cbPayment.DataSource = IME.PaymentTerms.ToList();
        //        cbPayment.DisplayMember = "term_name";
        //        cbPayment.ValueMember = "ID";

        //        cbRep.DataSource = IME.Workers.ToList();
        //        cbRep.DisplayMember = "NameLastName";
        //        cbRep.ValueMember = "WorkerID";
        //        cbWorkers.Items.AddRange(IME.CustomerWorkers.Where(a => a.customerID == q1.CustomerID).ToArray());
        //        cbWorkers.DisplayMember = "cw_name";
        //        cbWorkers.ValueMember = "ID";
        //        if (q1.QuotationMainContact != null)
        //        {
        //            cbWorkers.SelectedValue = (int)q1.QuotationMainContact;
        //        }
        //        else
        //        {
        //            cbWorkers.Text = q1.MainContactName;

        //        }


        //        CustomerCode.Enabled = false;
        //        txtCustomerName.Enabled = false;

        //        LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
        //        importFromQuotation = 0;
        //        modifyQuotation(q1);

        //        cbSMethod.SelectedIndex = (int)q1.ShippingMethodID;
        //        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
        //        {
        //            dgQuotationAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            GetMarginMark(i);
        //        }
        //        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
        //        {
        //            QuotataionModifyItemDetailsFiller(dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString(), i);

        //        }
        //        if (!Utils.AuthorityCheck(IMEAuthority.EditanyQuotation))
        //        {
        //            dgQuotationAddedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
        //            {
        //                item.ReadOnly = true;
        //            }
        //            foreach (DataGridViewRow item in dgQuotationDeleted.Rows)
        //            {
        //                item.ReadOnly = true;
        //            }
        //            gbCustomer.Enabled = false;
        //            btnCreateRev.Enabled = false;
        //            LandingCost.Enabled = false;
        //            gbShipment.Enabled = false;
        //            groupBox11.Enabled = false;
        //            groupBox7.Enabled = false;
        //            groupBox3.Enabled = false;
        //        }
        //        CalculateTotalMarge();

        //    }
        //    else
        //    {
        //        Quotation q1 = IME.Quotations.Where(a => a.QuotationNo == quotation.QuotationNo).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
        //        mainQuo = q1;
        //        this.Text = "Edit Quotation";
        //        modifyMod = true;
        //        cbCurrency.DataSource = IME.Currencies.ToList();
        //        cbCurrency.DisplayMember = "currencyName";
        //        cbCurrency.ValueMember = "currencyID";
        //        var QuoCurr = IME.Currencies.Where(a => a.currencyName == q1.CurrName).FirstOrDefault();
        //        if (QuoCurr != null) cbCurrency.SelectedValue = QuoCurr.currencyID;

        //        //dtpDate.Value = (DateTime)q1.StartDate;
        //        //dtpDate.Value = DateTime.Today.Date;
        //        //dtpDate.MaxDate = DateTime.Today.Date;
        //        cbPayment.DataSource = IME.PaymentTerms.ToList();
        //        cbPayment.DisplayMember = "term_name";
        //        cbPayment.ValueMember = "ID";
        //        cbRep.DataSource = IME.Workers.ToList();
        //        cbRep.DisplayMember = "NameLastName";
        //        cbRep.ValueMember = "WorkerID";
                
        //        cbWorkers.Items.AddRange(IME.CustomerWorkers.Where(x => x.customerID == q1.CustomerID).ToArray());
        //        cbWorkers.DisplayMember = "cw_name";
        //        cbWorkers.ValueMember = "ID";
        //        if (q1.QuotationMainContact != null)
        //        {
        //            cbWorkers.SelectedValue = (int)q1.QuotationMainContact;
        //        }
        //        else
        //        {
        //            cbWorkers.Text = q1.MainContactName;
        //        }
         
        //        LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
        //        importFromQuotation = 0;
        //        modifyQuotation(q1);
        //        //txtQuotationNo.Text = q1.QuotationNo + "v1";
        //        cbSMethod.SelectedIndex = (int)q1.ShippingMethodID;
        //        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
        //        {
        //            dgQuotationAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
        //            dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgQuotationAddedItems.DefaultCellStyle;

        //            GetMarginMark(i);
        //        }
        //        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
        //        {
        //            QuotataionModifyItemDetailsFiller(dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString(), i);

        //        }
        //        if (!Utils.AuthorityCheck(IMEAuthority.EditanyQuotation))
        //        {
        //            dgQuotationAddedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
        //            {
        //                item.ReadOnly = true;
        //            }
        //            foreach (DataGridViewRow item in dgQuotationDeleted.Rows)
        //            {
        //                item.ReadOnly = true;
        //            }
        //            gbCustomer.Enabled = false;
        //            btnCreateRev.Enabled = false;
        //            LandingCost.Enabled = false;
        //            gbShipment.Enabled = false;
        //            groupBox11.Enabled = false;
        //            groupBox7.Enabled = false;
        //            groupBox3.Enabled = false;
        //        }
        //        CalculateTotalMarge();
        //    }

        //    dgQuotationAddedItems.Focus();
        //    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];

        //}

        public FormQuotationAdd(Quotation quotation, FormQuotationMain parent, string mod2)
        {
            InitializeComponent();
            dgQuotationAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgQuotationDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgQuotationAddedItems, new object[] { true });
            mod = mod2;
            if (mod2 == "Update")
            {
                label67.Text = "Save Modification";
                this.Text = "Modify Quotation";
                btnCreateRev.Visible = false;
                label68.Visible = false;
                importFromQuotation = 0;
            }
            else if (mod2 == "Create New Version")
            {
                label67.Text = "Create Rev.";
                this.Text = "Edit Quotation";
                btnCreateRev.Visible = false;
                label68.Visible = false;
                importFromQuotation = 0;

            }
            modifyMod = true;
            Quotation q1 = IME.Quotations.Where(a => a.QuotationNo == quotation.QuotationNo).FirstOrDefault();
            mainQuo = q1;
            this.parent = parent;
            dtpDate.Value = Utils.GetCurrentDateTime();
            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[dgDelivery.Index];
            deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
            deliveryColumn.DisplayMember = "DeliveryName";
            deliveryColumn.ValueMember = "ID";

            //DataGridViewComboBoxColumn statusColumn = (DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[dgStatus.Index];
            //statusColumn.Items.Add("R");
            //statusColumn.Items.Add("O");
            //statusColumn.Items.Add("D");
            //statusColumn.HeaderText = "Choose";

            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            var QuoCurr = IME.Currencies.Where(a => a.currencyName == q1.CurrName).FirstOrDefault();
            if (QuoCurr != null) cbCurrency.SelectedValue = QuoCurr.currencyID;

            //dtpDate.Value = (DateTime)q1.StartDate;
            //dtpDate.Value = DateTime.Today.Date;
            //dtpDate.MaxDate = DateTime.Today.Date;
            cbPayment.DataSource = IME.PaymentTerms.ToList();
            cbPayment.DisplayMember = "term_name";
            cbPayment.ValueMember = "ID";
            cbPayment.SelectedValue = (int)q1.PaymentID;
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";
            cbRep.SelectedValue = (int)q1.RepresentativeID;
            cbWorkers.Items.AddRange(IME.CustomerWorkers.Where(x=> x.customerID==q1.CustomerID).ToArray());
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
            if (q1.QuotationMainContact != null)
            {
                cbWorkers.SelectedValue = (int)q1.QuotationMainContact;
            }
            else
            {
                cbWorkers.Text = q1.MainContactName;
            }
            if (mainQuo.FirstColumn == true)
            {
                chkFirstUPIME.Checked = true;
                groupBox1.Enabled = false;
                //ActivateTrueFirst();
            }
            else
            {
                chkFirstUPIME.Checked = false;
                groupBox1.Enabled = true;
                //ActivateFalseFirst();
            }
            if (mainQuo.MarkupColumn == true)
            {
                chkCustomerMarkup.Checked = true;
                chkCustomerFactor.Checked = false;
            }
            else
            {
                chkCustomerMarkup.Checked = false;
                chkCustomerFactor.Checked = true;
            }
            if (mod2 == "Update")
            {
                CustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
            }
            else if (mod2 == "Copy")
            {
                CustomerCode.Enabled = true;
                txtCustomerName.Enabled = true;
                this.Text = "Copy Quotation";
                importFromQuotation = 0;
                modifyQuotation(q1);
                txtQuotationNo.PasswordChar = ' ';
            }

            LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
            if (mod2 == "Update")
            {
                modifyQuotation(q1, mod);
            }
            else if(mod2== "Create New Version")
            {
                modifyQuotation(q1);
            }

            if (chkFirstUPIME.Checked)
            {
                chkFirstUPIME.Checked = true;
            }
            else
            {
                chkFirstUPIME.Checked = false;
            }
            if (chkCustomerMarkup.Checked)
            {
                MarkupFactor();
            }
            else
            {
                chkCustomerMarkup.Checked = false;
            }
            cbSMethod.SelectedIndex = (int)q1.ShippingMethodID;
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                dgQuotationAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgQuotationAddedItems.DefaultCellStyle;

                GetMarginMark(i);

            }
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                QuotataionModifyItemDetailsFiller(dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString(), i);

            }
            if (!Utils.AuthorityCheck(IMEAuthority.EditanyQuotation))
            {
                dgQuotationAddedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    item.ReadOnly = true;
                }
                foreach (DataGridViewRow item in dgQuotationDeleted.Rows)
                {
                    item.ReadOnly = true;
                }
                gbCustomer.Enabled = false;
                btnCreateRev.Enabled = false;
                LandingCost.Enabled = false;
                gbShipment.Enabled = false;
                groupBox11.Enabled = false;
                groupBox7.Enabled = false;
                groupBox3.Enabled = false;
            }
           // dgQuotationAddedItems.SelectedRows = true;
            dgQuotationAddedItems.Focus();
            dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
            CalculateTotalMarge();
            
            if (mod2 == "Copy")
            {
                txtQuotationNo.Text = CreateQuotationID(QuotationIdMod.New, null);
            }
            txtTotalDis2.Text = String.Format("{0:N}", (decimal.Parse(txtTotalDis2.Text)));
        }

     
        public FormQuotationAdd(Quotation quotation, string mumin)
        {
            InitializeComponent();
            dgQuotationAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgQuotationDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgQuotationAddedItems, new object[] { true });

            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[dgDelivery.Index];
            deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
            deliveryColumn.DisplayMember = "DeliveryName";
            deliveryColumn.ValueMember = "ID";

            //DataGridViewComboBoxColumn statusColumn = (DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[dgStatus.Index];
            //statusColumn.Items.Add("R");
            //statusColumn.Items.Add("O");
            //statusColumn.Items.Add("D");
            //statusColumn.HeaderText = "Choose";

            //Son versiyonu açmayı sağlıyor
            Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(quotation.QuotationNo)).FirstOrDefault();
            mainQuo = q1;
            this.Text = "View Quotation";
            modifyMod = true;
            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";

            var QuoCurr = IME.Currencies.Where(a => a.currencyName == q1.CurrName).FirstOrDefault();
            if (QuoCurr != null) cbCurrency.SelectedValue = QuoCurr.currencyID;

            dtpDate.Value = (DateTime)q1.StartDate;
            dtpDate.MaxDate = DateTime.Today.Date;
            cbPayment.DataSource = IME.PaymentTerms.ToList();
            cbPayment.DisplayMember = "term_name";
            cbPayment.ValueMember = "ID";
            cbPayment.SelectedValue = (int)q1.PaymentID;
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";
            cbRep.SelectedValue = (int)q1.Worker.WorkerID;
            cbWorkers.Items.AddRange(IME.CustomerWorkers.ToArray());
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
            if (q1.QuotationMainContact != null)
            {
                cbWorkers.SelectedValue = (int)q1.QuotationMainContact;
            }
            else
            {
                cbWorkers.Text = q1.MainContactName;
            }
            CustomerCode.Enabled = false;
            txtCustomerName.Enabled = false;
            if (mainQuo.FirstColumn == true)
            {
                chkFirstUPIME.Checked = true;
                groupBox1.Enabled = false;
                //ActivateTrueFirst();
            }
            else
            {
                chkFirstUPIME.Checked = false;
                groupBox1.Enabled = true;
                //ActivateFalseFirst();
            }
            if (mainQuo.MarkupColumn == true)
            {
                chkCustomerMarkup.Checked = true;
                chkCustomerFactor.Checked = false;
            }
            else
            {
                chkCustomerMarkup.Checked = false;
                chkCustomerFactor.Checked = true;
            }
            LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
            importFromQuotation = 1;
            modifyQuotation(q1);
            if (chkFirstUPIME.Checked)
            {
                chkFirstUPIME.Checked = true;
            }
            else
            {
                chkFirstUPIME.Checked = false;
            }
            if (chkCustomerMarkup.Checked)
            {
                MarkupFactor();
            }
            else
            {
                chkCustomerMarkup.Checked = false;
            }
            cbSMethod.SelectedIndex = (int)q1.ShippingMethodID;
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                dgQuotationAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
                //dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgQuotationAddedItems.DefaultCellStyle;

                GetMarginMark(i);
            }
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                QuotataionModifyItemDetailsFiller(dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString(), i);

            }
            if (!Utils.AuthorityCheck(IMEAuthority.EditanyQuotation))
            {
                dgQuotationAddedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    item.ReadOnly = true;
                }
                foreach (DataGridViewRow item in dgQuotationDeleted.Rows)
                {
                    item.ReadOnly = true;
                }
                gbCustomer.Enabled = false;
                btnCreateRev.Enabled = false;
                LandingCost.Enabled = false;
                gbShipment.Enabled = false;
                groupBox11.Enabled = false;
                groupBox7.Enabled = false;
                groupBox3.Enabled = false;
            }
            CalculateTotalMarge();
            //txtQuotationNo.Text = q1.QuotationNo;/*View 3*/
            EnableForm();
            dgQuotationAddedItems.ReadOnly = true;
        }

        private void EnableForm()
        {
            dgQuotationAddedItems.ReadOnly = true;
            dgQuotationDeleted.ReadOnly = true;
            CustomerCode.ReadOnly = false;
            txtCustomerName.ReadOnly = false;
            btnViewMore.Enabled = false;
            btnContactAdd.Enabled = false;
            btnExQuotation.Enabled = false;
            btnCreateRev.Enabled = false;
            btnSave.Enabled = false;
            groupBox11.Enabled = false;
            gbShipment.Enabled = false;
            groupBox3.Enabled = false;
            groupBox7.Enabled = false;
            gbCustomer.Enabled = false;
            txtAccountingNote.Enabled = false;
            txtCustomerNote.Enabled = false;
            txtContactNote.Enabled = false;
            btnImportFromExcel.Enabled = false;
            btnExcelExport.Enabled = false;
            btnProductHistory.Enabled = false;
            btnCustomizeGrid.Enabled = false;
        }

        public void checkAuthorities()
        {
            List<DataSet.AuthorizationValue> authList = Utils.getCurrentUser().AuthorizationValues.ToList();

            if (!Utils.AuthorityCheck(IMEAuthority.ViewMargine) && !Utils.AuthorityCheck(IMEAuthority.ViewCost) && !Utils.AuthorityCheck(IMEAuthority.ViewUKPrice))
            {
                txtCost1.Visible = false;
                txtCost2.Visible = false;
                txtCost3.Visible = false;
                txtCost4.Visible = false;
                txtCost5.Visible = false;

                txtMargin1.Visible = false;
                txtMargin2.Visible = false;
                txtMargin3.Visible = false;
                txtMargin4.Visible = false;
                txtMargin5.Visible = false;

                txtUK1.Visible = false;
                txtUK2.Visible = false;
                txtUK3.Visible = false;
                txtUK4.Visible = false;
                txtUK5.Visible = false;

                dgQuotationAddedItems.CurrentRow.Cells["dgUKPrice"].ReadOnly = false;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.ViewQuotationCheckBox))
            {
                LandingCost.Visible = false;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.ViewSubTotal))
            {
                lblsubtotal.Visible = false;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.ViewTotalCost))
            {
                txtTotalCost.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewTotalMargine))
            {
                txtTotalMargin.Visible = false;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.ViewDiscount))
            {
                txtTotalDis.Visible = false;
                txtTotalDis2.Visible = false;
                label4.Visible = false;
                dgQuotationAddedItems.CurrentRow.Cells["dgDisc"].ReadOnly = false;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.ViewLandingCost))
            {
                dgQuotationAddedItems.CurrentRow.Cells["dgLandingCost"].ReadOnly = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewCost))
            {
                dgQuotationAddedItems.CurrentRow.Cells["dgCost"].ReadOnly = false;
            }

        }

        private void QuotationForm_Load(object sender, EventArgs e)
        {
            #region Nokta Virgül Olayı
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";

            #endregion

            foreach (DataGridViewRow row in dgQuotationAddedItems.Rows)
            {
                row.Cells[dgUCUPCurr.Index].Style.BackColor = Color.FromArgb(140, 255, 195);
                row.Cells[dgQty.Index].Style.BackColor = Color.FromArgb(140, 255, 195);
            }

            checkAuthorities();
            //ControlAutorization();
            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[dgDelivery.Index];
            if (deliveryColumn.DataSource == null)
            {
                deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
                deliveryColumn.DisplayMember = "DeliveryName";
                deliveryColumn.ValueMember = "ID";
            }

            //DataGridViewComboBoxColumn statusColumn = (DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[dgStatus.Index];
            //if (statusColumn.DataSource == null)
            //{
            //    statusColumn.Items.Add("R");
            //    statusColumn.Items.Add("O");
            //    statusColumn.Items.Add("D");
            //    statusColumn.HeaderText = "Choose";
            //}

            if (txtCustomerName.Text == null || txtCustomerName.Text == "")
            {
                btnContactAdd.Enabled = false;
            }
            else
            {
                btnContactAdd.Enabled = true;
            }

            TotalCostList.Columns.Add("dgNo", typeof(decimal));
            TotalCostList.Columns.Add("cost", typeof(decimal));
            List<int> quotationVisibleFalseNames = QuotationDatagridCustomize.VisibleFalseNames;
            ;
            foreach (var item in quotationVisibleFalseNames)
            {
                dgQuotationAddedItems.Columns[item].Visible = false;
            }
            DeletedQuotationMenu.MenuItems.Add(new MenuItem("Add to Quotation", DeletedQuotationMenu_Click));

            GetCurrency(dtpDate.Value);
            GetAutorities();
            tableLayoutPanel2.Height = 5;


            if (CustomerCode.Text != null && CustomerCode.Text != "")
            {
                dgQuotationAddedItems.Focus();
                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
            }
            else
            {
                CustomerCode.Focus();
            }

            sayac = 1;

            //#region N2 Format
            //try
            //{
            //    string s;
            //    DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.CurrentRow;
            //    s = String.Format("{0:N}");
            //    s = row.Cells[13].Value.ToString();
            //    for (int i = 22; i < 30; i++)
            //    {
            //        s = "";
            //        if (i != 25)
            //        {
            //           s = row.Cells[i].Value.ToString();
            //        }
            //    }
            //}
            //catch { }
            //#endregion

            txtTotalDis2.Text = String.Format("{0:N}", txtTotalDis2.Text);

            //if (cbDeliverDiscount.Checked)
            //{
            //    chkFirstUPIME.Enabled = false;
            //}
            //else
            //{
            //    chkFirstUPIME.Enabled = true;
            //}
        }
        private void GetAutorities()
        {
            if (GetUserAutorities(1020)) { VisibleCostMarginTrue(); }
            if (GetUserAutorities(1021)) { cbDeliverDiscount.Visible = true; }
        }

        private void SearchCustomerWithName()
        {
            QuotationUtils.customersearchID = "";
            QuotationUtils.customersearchname = txtCustomerName.Text;
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
            this.Enabled = false;
            form.ShowDialog();
            fillCustomer();
            if (QuotationUtils.customersearchID != "") { cbRep.DataSource = IME.CustomerWorkers.Where(a => a.customerID == IME.Customers.Where(b => b.ID == QuotationUtils.customersearchID).FirstOrDefault().ID).ToList(); cbRep.DisplayMember = "cw_name"; }
        }

        private void fillCustomer()
        {
            if (txtCustomerName.Text != null || txtCustomerName.Text != "")
            {
                btnContactAdd.Enabled = true;
            }

            //if (!modifyMod)
            //{
            //    CustomerCode.Text = QuotationUtils.customerID;
            //    txtCustomerName.Text = QuotationUtils.customername;
            //}
            //if (customer != null)
            //{
            //    CustomerCode.Text = customer.ID;
            //    txtCustomerName.Text = customer.c_name;

            //    if (customer.paymentmethodID != null)
            //    {
            //        cbPayment.SelectedIndex = cbPayment.FindStringExact(customer.PaymentTerm.term_name);
            //    }
            //    try { txtContactNote.Text = customer.CustomerWorker.Note.Note_name; } catch { }
            //    try { txtCustomerNote.Text = customer.Note.Note_name; } catch { }
            //    try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == customer.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
            //    if (customer.Worker != null) cbRep.SelectedValue = customer.Worker.WorkerID;
            //    if (this.Text != "Edit Quotation")
            //    {
            //        var CustomerCurr = IME.Currencies.Where(a => a.currencyName == customer.CurrNameQuo).FirstOrDefault();
            //        if (CustomerCurr != null) cbCurrency.SelectedValue = CustomerCurr.currencyID;
            //    }
            //    if (customer.CustomerWorker != null)
            //    {
            //        cbWorkers.SelectedItem = cbWorkers.FindStringExact(customer.CustomerWorker.cw_name);
            //    }
            //}
        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(true, CustomerCode.Text);
            f.ShowDialog();
        }

        private void customerDetailsNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(true, txtCustomerName.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Quotation quo = IME.Quotations.Where(q => q.QuotationNo == txtQuotationNo.Text).FirstOrDefault();

            if (quo != null)
            {
                quo.ViewQuotation = true;
                quo.ViewQuotationName = null;
                IME.SaveChanges();
            }

            if (this.Text == "View Quotation")
            {
                if (MessageBox.Show("Do you want to close ?", "Quotation Close", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to close without saving ?", "Quotation Close", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void dgQuotationAddedItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgQuotationAddedItems.CurrentCell.ColumnIndex)
            {
                case 0:
                    #region ID Atama
                    if (Decimal.Parse(dgQuotationAddedItems.CurrentCell.Value.ToString()) <= Decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgNo.Index].Value.ToString()))
                    {
                        decimal currentID = dgQuotationAddedItems.CurrentCell.RowIndex;
                        List<Decimal> Quotation = new List<Decimal>();
                        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                        {
                            Quotation.Add(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()));
                        }
                        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                        {
                            if (dgQuotationAddedItems.CurrentCell.RowIndex < Decimal.Parse(dgQuotationAddedItems.CurrentCell.Value.ToString()))
                            {
                                #region RowChange1
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()) <= Decimal.Parse(dgQuotationAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgQuotationAddedItems.CurrentCell.RowIndex < i)
                                {
                                    if (i <= Quotation.Count)
                                    {
                                        dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value = (i);
                                    }
                                }
                                else { dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()); }
                                #endregion
                            }
                            else
                            {
                                #region RowChange2
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()) >= Decimal.Parse(dgQuotationAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgQuotationAddedItems.CurrentCell.RowIndex > i)
                                {
                                    //if (i <= Quotation.Count)
                                    //{
                                    //    dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value = (i + 2);
                                    //}

                                }
                                else { dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()); }
                                #endregion
                            }

                        }
                    }
                    #endregion
                    try { dgQuotationAddedItems.Sort(dgQuotationAddedItems.Columns[dgNo.Index], ListSortDirection.Ascending); } catch { }
                    break;
                case 8://PRODUCT CODE
                    {
                        #region MyRegion
                        if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value.ToString() != "")
                        {

                        }
                        else
                        {
                            dgQuotationAddedItems.Rows.RemoveAt(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Index);
                            dgQuotationAddedItems.Refresh();
                        }

                        ItemDetailsClear();
                        string articleNo = "";
                        int satir_sayisi = dgQuotationAddedItems.RowCount;
                        if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[satir_sayisi - 1].Cells[dgProductCode.Index].Value.ToString()))
                        {
                            articleNo = dgQuotationAddedItems.CurrentCell.Value.ToString();
                            if (articleNo.Contains("-"))
                            {
                                articleNo = articleNo.Replace("-", "");
                                dgQuotationAddedItems.CurrentCell.Value = articleNo;
                            }
                            if (articleNo.Length == 6)
                            {
                                articleNo = "0" + articleNo;
                                dgQuotationAddedItems.CurrentCell.Value = articleNo;
                            }


                            var articleList = IME.ArticleSearch(articleNo).ToList();
                            if (articleList.Count == 1)
                            {
                                if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString() != "" && dgQuotationAddedItems.CurrentRow.Cells[dgDesc.Index].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgDesc.Index].Value.ToString() != "")
                                {
                                    DataGridViewRow rowsss = (DataGridViewRow)dgQuotationAddedItems.CurrentRow;
                                    for (int i = 11; i < rowsss.Cells.Count; i++)
                                    {
                                        rowsss.Cells[i].Value = "";
                                    }
                                }
                                if (!Discontinued(articleNo))
                                {
                                    List<string> SameItemIndexList = new List<string>();
                                    string _IndexList = string.Empty;
                                    for (int i = 0; i < dgQuotationAddedItems.RowCount - 1; i++)
                                    {
                                        if (dgQuotationAddedItems.Rows[i].Cells[dgProductCode.Index].Value.ToString() == articleNo &&
                                            dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value == null)
                                        {
                                            SameItemIndexList.Add(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString());
                                        }
                                    }
                                    if (SameItemIndexList != null && SameItemIndexList.Count > 0)
                                    {
                                        foreach (string item in SameItemIndexList)
                                        {
                                            _IndexList = _IndexList + item + ", ";
                                        }

                                        MessageBox.Show("This item is already added in row(s): " + _IndexList);
                                    }
                                    tabControl1.SelectedTab = tabItemDetails;
                                    dgQuotationAddedItems.Focus();
                                    ItemDetailsFiller(articleNo);//tekrar bakılacak
                                    FillProductCodeItem();
                                    if (txtWeb1.Text == "0" || txtWeb1.Text == "")
                                    {
                                        DialogResult dialogResult = MessageBox.Show("Item is not available in Price File, please check website and Enter price from ItemCard");
                                        ItemsClear();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("This Item is Discontinued");
                                }

                            }
                            else if (articleList.Count > 1)
                            {
                                if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString() != "" && dgQuotationAddedItems.CurrentRow.Cells[dgDesc.Index].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgDesc.Index].Value.ToString() != "")
                                {
                                    DataGridViewRow rowsss = (DataGridViewRow)dgQuotationAddedItems.CurrentRow;
                                    for (int i = 11; i < rowsss.Cells.Count; i++)
                                    {
                                        rowsss.Cells[i].Value = "";
                                    }
                                }

                                FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(articleNo);
                                itemsearch.ShowDialog();
                                articleNo = QuotationUtils.ItemCode;
                                List<string> SameItemIndexList2 = new List<string>();
                                string _IndexList2 = string.Empty;
                                for (int i = 0; i < dgQuotationAddedItems.RowCount - 1; i++)
                                {
                                    if (dgQuotationAddedItems.Rows[i].Cells[dgProductCode.Index].Value.ToString() == articleNo &&
                                        dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value == null)
                                    {
                                        SameItemIndexList2.Add(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString());
                                    }
                                }
                                if (SameItemIndexList2 != null && SameItemIndexList2.Count > 0)
                                {
                                    foreach (string item in SameItemIndexList2)
                                    {
                                        _IndexList2 = _IndexList2 + item + ", ";
                                    }

                                    MessageBox.Show("This item is already added in row(s): " + _IndexList2);
                                }
                                tabControl1.SelectedTab = tabItemDetails;
                                dgQuotationAddedItems.Focus();
                                dgQuotationAddedItems.CurrentCell.Value = articleNo;
                                ItemDetailsFiller(articleNo);//tekrar bakılacak
                                FillProductCodeItem();
                                if (txtWeb1.Text == "0" || txtWeb1.Text == "")
                                {
                                    DialogResult dialogResult = MessageBox.Show("Item is not available in Price File, please check website and Enter price from ItemCard");
                                    ItemsClear();
                                }
                             
                            }
                            else
                            {
                                MessageBox.Show("Item is not in our range");
                                //dgQuotationAddedItems.Rows.RemoveAt(dgQuotationAddedItems.CurrentRow.Index);
                                ItemsClear();
                                dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value = "";
                                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
                            }
                            //if (!String.IsNullOrEmpty(dgQuotationAddedItems.CurrentRow.Cells[dgDesc.Index].Value.ToString())) ChangeCurrnetCell(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
                               (dgQuotationAddedItems.CurrentRow.Cells[dgDelivery.Index] as DataGridViewComboBoxCell).Value = 3;
                            (dgQuotationAddedItems.CurrentRow.Cells[dgStatus.Index] as DataGridViewComboBoxCell).Value = 1;

                            if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString() != "")
                            {
                                if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString().Substring(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString().Length - 1, 1) == "P")
                                {
                                    if (new Sp_Item().GetProductHistoryWithArticleNo_P(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()) != null && new Sp_Item().GetProductHistoryWithArticleNo_P(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()).Rows.Count > 0)
                                    {
                                        if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null)
                                        {
                                            btnProductHistory.ForeColor = Color.FromArgb(255, 68, 68);
                                            btnProductHistory.Enabled = true;

                                            ViewProductHistory f = new ViewProductHistory(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString(), "Quotation");

                                            try { f.ShowDialog(); } catch { }
                                        }
                                        else
                                        {
                                            btnProductHistory.ForeColor = Color.FromArgb(32, 31, 53);
                                            btnProductHistory.Enabled = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (new Sp_Item().GetProductHistoryWithArticleNo(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()) != null && new Sp_Item().GetProductHistoryWithArticleNo(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()).Rows.Count > 0)
                                    {
                                        if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null)
                                        {
                                            btnProductHistory.ForeColor = Color.FromArgb(255, 68, 68);
                                            btnProductHistory.Enabled = true;

                                            ViewProductHistory f = new ViewProductHistory(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString(), "Quotation");

                                            try { f.ShowDialog(); } catch { }
                                        }
                                        else
                                        {
                                            btnProductHistory.ForeColor = Color.FromArgb(32, 31, 53);
                                            btnProductHistory.Enabled = false;
                                        }
                                    }
                                }
                                if (CurrentRow.Cells[dgUCUPCurr.Index].Value != null && CurrentRow.Cells[dgQty.Index].Value != null)
                                {
                                    CurrentRow.Cells[dgUCUPCurr.Index].Style.BackColor = Color.FromArgb(140, 255, 195);
                                    CurrentRow.Cells[dgQty.Index].Style.BackColor = Color.FromArgb(140, 255, 195);
                                }
                            }
                           
                        }
                        else
                        {
                            //MessageBox.Show("Product Code empty");
                        }
                    }                    
                    #endregion
                    break;
                case 17://MARKUP

                    if (chkCustomerMarkup.Checked == true)
                    {
                        decimal CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;

                        CurrentRow.Cells[dgUPIME.Index].Value = "";
                        CurrentRow.Cells[dgUPIME.Index].Value = decimal.Parse(CurrentRow.Cells[dgLandingCost.Index].Value.ToString()) * (decimal.Parse(CurrentRow.Cells[dgMarkup.Index].Value.ToString())/100+1) * CurrentRate;

                        CurrentRow.Cells[dgTotal.Index].Value = "";
                        CurrentRow.Cells[dgTotal.Index].Value = decimal.Parse(CurrentRow.Cells[dgUPIME.Index].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgQty.Index].Value.ToString()) * CurrentRate;

                        if (chkFirstUPIME.Checked == true)
                        {
                            CalculateSubTotalActivate();
                        }
                        else
                        {
                            CalculateSubTotal();
                        }
                    }

                    break;
                case 18://QAUANTITY
                    
                    if ((Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString())) == 0 && (Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells[dgUC.Index].Value.ToString())) == 0)
                    {
                        DgQuantityFiller();
                        calculateTotalCost();
                        if (CurrentRow.Cells["dgQty"].Value != null && CurrentRow.Cells["dgQty"].Value.ToString() != "")
                        {
                            if (txtStandartWeight.Text != "" && txtGrossWeight.Text != "")
                            {
                                if (Decimal.Parse(txtStandartWeight.Text) < (Decimal.Parse(txtGrossWeight.Text)))
                                {
                                    CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtGrossWeight.Text)).ToString();
                                }
                                else
                                {
                                    CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                                }
                                CurrentRow.Cells["dgTotalWeight"].Value = (Decimal.Parse(CurrentRow.Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();
                                CalculateTotalWeight();
                            }
                        }

                        if (CurrentRow.Cells["dgQty"].Value != null && CurrentRow.Cells["dgQty"].Value.ToString() != "")
                        {
                            CurrentRow.Cells[dgUnitNetWeight.Index].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                            CurrentRow.Cells[dgUnitTotalNetWeight.Index].Value = (Decimal.Parse(CurrentRow.Cells[dgUnitNetWeight.Index].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();
                            CalculateTotalNetWeight();
                        }
                        CurrentRow.Cells[dgFirstUPIME.Index].Value = String.Format("{0:N}", (Decimal.Parse(txtWeb1.Text))).ToString();


                        if (txtGrossWeight.Text == "" && Convert.ToDecimal(txtGrossWeight.Text) == 0)
                        {
                            dgQuotationAddedItems.CurrentRow.Cells[WT.Index].Style.BackColor = Color.Red;
                        }
                        else if (Convert.ToDecimal(txtGrossWeight.Text) * Convert.ToDecimal(dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value.ToString()) > 5)
                        {
                            dgQuotationAddedItems.CurrentRow.Cells[WT.Index].Style.BackColor = Color.Orange;
                        }
                        else
                        {
                            dgQuotationAddedItems.CurrentRow.Cells[WT.Index].Style.BackColor = Color.Ivory;
                        }
                        if (chkFirstUPIME.Checked)
                        {
                            CurrentRow.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString());
                            CurrentRow.Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString());
                            CurrentRow.Cells[dgTotal.Index].Value = (Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString()) * Int32.Parse(CurrentRow.Cells[dgQty.Index].Value.ToString())).ToString();
                            CurrentRow.Cells[dgTotal.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgTotal.Index].Value.ToString());
                            CalculateSubTotalActivate();
                        }
                        else
                        {
                            CurrentRow.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(CurrentRow.Cells[dgUPIME.Index].Value.ToString());
                            CurrentRow.Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString());
                            CurrentRow.Cells[dgTotal.Index].Value = (Decimal.Parse(CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString()) * Int32.Parse(CurrentRow.Cells[dgQty.Index].Value.ToString())).ToString();
                            CurrentRow.Cells[dgTotal.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgTotal.Index].Value.ToString());
                            CalculateSubTotal();
                        }
                        CurrentRow.Cells[dgMarkup.Index].Value = String.Format("{0:N}", decimal.Parse(lblCustomerMarkupValue.Text));
                        if (Decimal.Parse(CurrentRow.Cells[dgUPIME.Index].Value.ToString()) == Decimal.Parse(CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString()))
                        {
                            CurrentRow.Cells[dgDisc.Index].Value = "0.00";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a number that is a multiple of SSM");
                        CurrentRow.Cells["dgQty"].Value = "";
                        CurrentRow.Cells["dgUPIME"].Value = "";
                        CurrentRow.Cells["dgTotal"].Value = "";
                        dgQuotationAddedItems.CurrentCell = CurrentRow.Cells[dgQty.Index];
                        dgQuotationAddedItems.BeginEdit(true);
                    }

                    break;
                     {
                        #region First Curr
                    //    if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value.ToString() != "")
                    //    {

                    //    }
                    //    else
                    //    {
                    //        dgQuotationAddedItems.Rows.RemoveAt(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Index);
                    //        dgQuotationAddedItems.Refresh();
                    //    }
                    //    //TO DO depends on authority
                    //    //if (dgQuotationAddedItems.CurrentRow.Cells[dgHZ.Index].Style.BackColor == Color.White)
                    //    CurrentRow = dgQuotationAddedItems.CurrentRow;
                    //    if (txtHazardousInd.Text == "N")
                    //    {
                    //        #region Total
                    //        decimal ucupcurr = decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString());
                    //        decimal UcupIME = decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString());
                    //        decimal disc = Math.Round(((UcupIME - ucupcurr) * (decimal)100 / UcupIME), 4);
                    //        int workerID = Utils.getCurrentUser().WorkerID;
                    //        decimal Minmarge = (decimal)IME.Workers.Where(x => x.WorkerID == workerID).FirstOrDefault().MinMarge;
                    //        if (disc > Minmarge)
                    //        {
                    //            MessageBox.Show("Low Price ! Ask for authorization");
                    //            dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgFirstUPIME.Index];
                    //            CurrentRow.Cells["dgUCUPCurr"].Value = UcupIME;
                              
                    //            CurrentRow.Cells[dgPacketUP.Index].Value = decimal.Parse(CurrentRow.Cells[dgUKPrice.Index].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgUC.Index].Value.ToString());
                    //            CurrentRow.Cells["dgDisc"].Value = 0;
                    //        }
                    //        else
                    //        {
                    //            CurrentRow.Cells["dgDisc"].Value = disc;
                    //        }


                    //        GetMarginFirst();
                    //        GetMarginMark();
                    //        #region Calculate Total Margin
                    //        try
                    //        {
                    //            txtTotalMargin.Text = Math.Round(calculateTotalMarginFirst(), 4).ToString();
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            txtTotalMargin.Text = Math.Round(calculateTotalMarginFirst(), 4).ToString();
                    //        }

                    //        #endregion
                    //        CalculateSubTotal();
                    //        #endregion
                    //    }
                    //    else if (txtHazardousInd.Text == "Y")
                    //    {
                    //        dgQuotationAddedItems.CurrentRow.Cells[dgFirstUPIME.Index].Value = dgQuotationAddedItems.CurrentRow.Cells[dgUPIME.Index].Value.ToString();

                            
                    //        dgQuotationAddedItems.CurrentRow.Cells[dgPacketUP.Index].Value = decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgUKPrice.Index].Value.ToString()) * decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgUC.Index].Value.ToString());
                    //        MessageBox.Show("Hazardous Item - Discount not allowed");
                    //    }
                    }
                    #endregion
                    break;
                        case 26://UCUP Curr*
                    {
                        #region UCUP Curr
                        if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value.ToString() != "")
                        {

                        }
                        else
                        {
                            dgQuotationAddedItems.Rows.RemoveAt(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Index);
                            dgQuotationAddedItems.Refresh();
                        }
                        //TO DO depends on authority
                        //if (dgQuotationAddedItems.CurrentRow.Cells[dgHZ.Index].Style.BackColor == Color.White)
                        CurrentRow = dgQuotationAddedItems.CurrentRow;
                        if (txtHazardousInd.Text == "")
                        {
                            #region Total
                            decimal UcupIME = 0;
                            decimal ucupcurr = decimal.Parse(String.Format("{0:N}", CurrentRow.Cells["dgUCUPCurr"].Value.ToString()));
                            //decimal UcupIME = Math.Round(decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString()), 2);
                            if (chkFirstUPIME.Checked)
                            {
                                UcupIME = decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString());
                            }
                            else
                            {
                                UcupIME = decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString());
                            }
                            //decimal disc = Math.Round(((UcupIME - ucupcurr) * (decimal)100 / UcupIME), 2);
                            decimal disc = ((UcupIME - ucupcurr) * (decimal)100 / UcupIME);
                            int workerID = Utils.getCurrentUser().WorkerID;
                            decimal Minmarge = (decimal)IME.Workers.Where(x => x.WorkerID == workerID).FirstOrDefault().MinMarge;
                            if (disc > Minmarge)
                            {
                                MessageBox.Show("Low Price ! Ask for authorization");
                                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index];
                                CurrentRow.Cells["dgUCUPCurr"].Value = String.Format("{0:N}", UcupIME);
                                //if (Convert.ToInt32(CurrentRow.Cells[dgSSM.Index].Value.ToString()) > 1 || Convert.ToInt32(CurrentRow.Cells[dgUC.Index].Value.ToString()) > 1)
                                //{
                                //    CurrentRow.Cells[dgPacketUP.Index].Value = decimal.Parse(CurrentRow.Cells[dgUKPrice.Index].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgUC.Index].Value.ToString());
                                //}
                                CurrentRow.Cells[dgPacketUP.Index].Value = decimal.Parse(CurrentRow.Cells[dgUKPrice.Index].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgUC.Index].Value.ToString());
                                CurrentRow.Cells["dgDisc"].Value = 0;
                            }
                            else
                            {
                                CurrentRow.Cells["dgDisc"].Value = disc;
                            }


                            GetMargin();
                            GetMarginMark();
                            #region Calculate Total Margin
                            try
                            {
                                //txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
                                txtTotalMargin.Text = (String.Format("{0:N}", calculateTotalMargin()));
                            }
                            catch (Exception ex)
                            {
                                //txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
                                txtTotalMargin.Text = (String.Format("{0:N}", calculateTotalMargin()));
                            }

                            #endregion
                            CalculateSubTotal();
                            #endregion
                        }
                        else if (txtHazardousInd.Text == "Y")
                        {
                            if (chkFirstUPIME.Checked)
                            {
                                dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString());
                            }
                            else
                            {
                                dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgUPIME.Index].Value.ToString());
                            }
                            

                            //if (Convert.ToInt32(CurrentRow.Cells[dgSSM.Index].Value.ToString()) > 1 || Convert.ToInt32(CurrentRow.Cells[dgUC.Index].Value.ToString()) > 1)
                            //{
                            //    dgQuotationAddedItems.CurrentRow.Cells[dgPacketUP.Index].Value = decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgUKPrice.Index].Value.ToString()) * decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgUC.Index].Value.ToString());
                            //}
                            dgQuotationAddedItems.CurrentRow.Cells[dgPacketUP.Index].Value = decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgUKPrice.Index].Value.ToString()) * decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells[dgUC.Index].Value.ToString());
                            MessageBox.Show("Hazardous Item - Discount not allowed");
                        }
                    }
                    #endregion
                    CurrentRow.Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", CurrentRow.Cells[dgUCUPCurr.Index].Value);
                    break;
                case 39://Cust Stock Kodu

                    #region UCUP Curr
                     string cusStock = dgQuotationAddedItems.CurrentCell.Value.ToString();
                    var stock = IME.QuotationDetails.Where(x => x.CustomerName == txtCustomerName.Text).FirstOrDefault();

                    if (stock != null)
                    {
                        if (CurrentRow.Cells[dgProductCode.Index].Value != null)
                        {

                        }
                        else
                        {
                            if (stock.CustomerStockCode == cusStock)
                            {

                                CurrentRow.Cells[dgProductCode.Index].Value = stock.ItemCode;
                                CurrentRow.Cells["dgDesc"].Value = stock.ItemDescription;
                                CurrentRow.Cells["dgSSM"].Value = stock.SSM.ToString() ?? ""; ;
                                CurrentRow.Cells["dgUC"].Value = stock.UC.ToString() ?? ""; ;
                                CurrentRow.Cells["dgUOM"].Value = stock.UnitOfMeasure;
                                CurrentRow.Cells["dgMPN"].Value = stock.MPN;
                                CurrentRow.Cells[dgCustDescription.Index].Value = stock.CustomerDesc;
                                CurrentRow.Cells[dgCustStkCode.Index].Value = stock.CustomerStockCode;

                                ItemDetailsFiller(CurrentRow.Cells[dgProductCode.Index].Value.ToString());//tekrar bakılacak
                                FillProductCodeItem();
                                if (txtWeb1.Text == "0" || txtWeb1.Text == "")
                                {
                                    DialogResult dialogResult = MessageBox.Show("Item is not available in Price File, please check website and Enter price from ItemCard");
                                    ItemsClear();
                                }

                                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
                            }
                            else
                            {
                                MessageBox.Show("Customer Stock Code entered wrong");
                                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
                            }
                        }
                    }

                    
                    #endregion
                    break;
            }
        }


        private void DgQuantityFiller()
        {
            #region Quantity

            if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value.ToString() != "")
            {

            }
            else
            {
                dgQuotationAddedItems.Rows.RemoveAt(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Index);
                dgQuotationAddedItems.Refresh();
            }

            if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgQty.Index].Value.ToString()) && dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgQty.Index].Value.ToString() != "0")
            {
                if (LandingCost.Enabled == false) LandingCost.Enabled = true;
                GetQuotationQuantity(dgQuotationAddedItems.CurrentCell.RowIndex);
                dgQuotationAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells["dgUCUPCurr"].Style = dgQuotationAddedItems.DefaultCellStyle; 

                dgQuotationAddedItems.CurrentRow.Cells[dgFirstUPIME.Index].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells[dgFirstUPIME.Index].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.CurrentRow.Cells[dgPacketUP.Index].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells[dgPacketUP.Index].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.CurrentRow.Cells["dgTargetUP"].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells["dgTargetUP"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.CurrentRow.Cells["dgCompetitor"].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells["dgCompetitor"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.CurrentRow.Cells["dgDelivery"].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells["dgDelivery"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.CurrentRow.Cells[dgStatus.Index].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells[dgStatus.Index].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.CurrentRow.Cells["dgCustStkCode"].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells["dgCustStkCode"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.CurrentRow.Cells["dgCustDescription"].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells["dgCustDescription"].Style = dgQuotationAddedItems.DefaultCellStyle;

                if (dgQuotationAddedItems.CurrentRow.Cells["dgQty"].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value.ToString() != "")
                {
                    GetMarginMark();
                }
                Disc();
                CalculateTotalMarge();
            }
            else
            {
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgQty.Index].Value = "";
            }
            #endregion
        }

        private bool Discontinued(string ArticleCode)
        {
            var dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleCode).FirstOrDefault();
            if (dd == null)
            {
                if (ArticleCode.Substring(0, 1) == "0") ArticleCode = ArticleCode.Substring(1, ArticleCode.Length - 1);
                dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleCode).FirstOrDefault();
            }
            if (dd != null && Convert.ToDateTime(dd.DiscontinuationDate) < Utils.GetCurrentDateTime().AddDays(90))
            {
                if (Convert.ToDateTime(dd.DiscontinuationDate) > Utils.GetCurrentDateTime())
                {
                    MessageBox.Show("This item will be discontinued " + dd.DiscontinuationDate);
                }
                else
                {
                    MessageBox.Show("This item is discontinued ");
                    return true;
                }
            }
            return false;
        }

        private void GetQuotationQuantity(int rowindex)
        {
            CurrentRow = dgQuotationAddedItems.Rows[rowindex];
            if (cbFactor.Text != null && cbFactor.Text != "")
            {
                #region Quantity
                if (!String.IsNullOrEmpty(CurrentRow.Cells[dgQty.Index].Value.ToString()))
                {
                    if (QuotationUtils.GetCost(CurrentRow.Cells[dgProductCode.Index].Value.ToString(), 1) != 0)
                    {
                        #region Quantity
                        #region Calculate Gross Weight
                        //Calculate Gross Weight
                        if (this.Text != "Modify Quotation" && this.Text != "Edit Quotation" && this.Text != "View Quotation" && this.Text != "Copy Quotation")
                        {
                            if (txtStandartWeight.Text != null && txtStandartWeight.Text != "" && txtGrossWeight.Text != null && txtGrossWeight.Text != "")
                            {
                                if (Decimal.Parse(txtStandartWeight.Text) < (Decimal.Parse(txtGrossWeight.Text)))
                                {
                                    CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtGrossWeight.Text)).ToString();
                                    CalculateTotalWeight();
                                    CurrentRow.Cells[dgUnitNetWeight.Index].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                                    CalculateTotalNetWeight();
                                }
                                else
                                {
                                    CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                                    CalculateTotalWeight();
                                    CurrentRow.Cells[dgUnitNetWeight.Index].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                                    CalculateTotalNetWeight();
                                }
                                txtGrossWeight.Text = String.Format("{0:N}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());
                                if (Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                                {
                                    txtGrossWeight.Text = (decimal.Parse(txtGrossWeight.Text) /
                                        Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString())).ToString();

                                }
                                else if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1)
                                {
                                    txtGrossWeight.Text = (decimal.Parse(txtGrossWeight.Text) /
                                        Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString())).ToString();
                                }
                            }
                        }
                        
                        #endregion
                        //Cost hesaplama
                        CurrentRow.Cells["dgCost"].Value = QuotationUtils.GetCost(CurrentRow.Cells["dgProductCode"].Value.ToString(), Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString("G29");
                        //LandingCost hesaplatma
                        if (CurrentRow.Cells["dgCost"].Value.ToString() != "-1") { String.Format("{0:N}", Decimal.Parse(CurrentRow.Cells["dgCost"].Value.ToString())).ToString(); }
                        GetLandingCost(rowindex);
                        decimal Currrate = 0;
                        if (curr.rate != null) Currrate = Decimal.Parse(curr.rate.ToString());
                        string productCode = CurrentRow.Cells[dgProductCode.Index].Value.ToString();
                        if (productCode.Substring(0, 1) == "0") productCode = productCode.Substring(1, productCode.Length - 1);
                        if (IME.Hazardous.Where(a => a.ArticleNo == productCode).FirstOrDefault() != null)
                        {
                            if (this.Text == "Modify Quotation" || this.Text == "Edit Quotation" || this.Text == "View Quotation" || this.Text == "Copy Quotation")
                            {

                                if (IME.Hazardous.Where(a => a.ArticleNo == productCode).FirstOrDefault().Lithium == "1")
                                {
                                    price = Decimal.Parse((QuotationUtils.GetPrice(CurrentRow.Cells["dgProductCode"].Value.ToString(), Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())) * Decimal.Parse(Utils.getManagement().LIFactor.ToString()) / Currrate * Decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString("G29"));
                                }
                                else if (IME.Hazardous.Where(a => a.ArticleNo == productCode).FirstOrDefault().Shipping == "1")
                                {
                                    price = Decimal.Parse((QuotationUtils.GetPrice(CurrentRow.Cells["dgProductCode"].Value.ToString(), Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())) * Decimal.Parse(Utils.getManagement().HSFactor.ToString()) / Currrate * Decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString("G29"));
                                }
                            }
                            else
                            {
                                price = FiyatKirilmalari2(Convert.ToDecimal(CurrentRow.Cells["dgQty"].Value.ToString()));
                            }

                        }
                        else
                        {
                            if (this.Text == "Modify Quotation" || this.Text == "Edit Quotation" || this.Text == "View Quotation" || this.Text == "Copy Quotation")
                            {
                                price = Decimal.Parse((QuotationUtils.GetPrice(CurrentRow.Cells["dgProductCode"].Value.ToString(), Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())) * Decimal.Parse(cbFactor.Text) / Currrate * Decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString("G29"));
                                
                            }
                            else
                            {
                                price = FiyatKirilmalari2(Convert.ToDecimal(CurrentRow.Cells["dgQty"].Value.ToString()));
                            }
                            
                        }
                        //price /= factor;
                        #region price calculation
                        if (price > 0)
                        {
                            decimal discResult = 0;
                            //Fiyat burada
                            string articleNo = CurrentRow.Cells["dgProductCode"].Value.ToString();
                            string qty = CurrentRow.Cells["dgQty"].Value.ToString();
                            CurrentRow.Cells["dgUPIME"].Value = price / decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString());

                            //CurrentRow.Cells["dgTotal"].Value = Math.Round(price, 2);
                            CurrentRow.Cells["dgTotal"].Value = price;
                            //SuperdiskP değilse
                            if (!(articleNo.ToUpper().Contains('P')) && Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1)
                            {
                                if ((Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString())) != 0 && (Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells[dgUC.Index].Value.ToString())) != 0)
                                {
                                    MessageBox.Show("Please enter a number that is a multiple of Unit Content");
                                    CurrentRow.Cells["dgQty"].Value = "";
                                    CurrentRow.Cells["dgUPIME"].Value = "";
                                    CurrentRow.Cells["dgTotal"].Value = "";
                                }
                                else
                                {
                                    CurrentRow.Cells["dgUPIME"].Value = decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString()) / (decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString()));


                                    //CurrentRow.Cells["dgTotal"].Value = Math.Round(price / (decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())), 2);
                                    CurrentRow.Cells["dgTotal"].Value = price / (decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString()));
                                }

                            }
                            else if ((Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString())) != 0 && (Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells[dgUC.Index].Value.ToString())) != 0)
                            {
                                MessageBox.Show("Please enter a number that is a multiple of SSM");
                                CurrentRow.Cells["dgQty"].Value = "";
                                CurrentRow.Cells["dgUPIME"].Value = "";
                                CurrentRow.Cells["dgTotal"].Value = "";
                                dgQuotationAddedItems.CurrentCell = CurrentRow.Cells[dgQty.Index];
                                dgQuotationAddedItems.BeginEdit(true);
                            }

                            #endregion




                            if (CurrentRow.Cells[dgQty.Index].Value.ToString() != "")
                            {
                                //TOTAL ve UPIME belirleniyor
                                ItemDetailsFiller(CurrentRow.Cells[dgProductCode.Index].Value.ToString());
                                FiyatKirilmalari(Convert.ToDecimal(CurrentRow.Cells["dgQty"].Value.ToString()));
                                //      CurrentRow.Cells[dgFirstUPIME.Index].Value = String.Format("N2", Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString())).ToString();
                                if (chkFirstUPIME.Checked)
                                {
                                    discResult = decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString());
                                }
                                else
                                {
                                    discResult = decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString());
                                }
                                //CurrentRow.Cells["dgTotal"].Value = Math.Round(decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString()), 2);
                                CurrentRow.Cells["dgTotal"].Value = decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString());
                                if (CurrentRow.Cells[dgDisc.Index].Value != null && CurrentRow.Cells[dgDisc.Index].Value.ToString() != "")
                                {
                                    //CurrentRow.Cells[dgDisc.Index].Value = Math.Round(Decimal.Parse(CurrentRow.Cells[dgDisc.Index].Value.ToString()), 2).ToString();
                                    CurrentRow.Cells[dgDisc.Index].Value = Decimal.Parse(CurrentRow.Cells[dgDisc.Index].Value.ToString());
                                    discResult = (discResult - (discResult * decimal.Parse(CurrentRow.Cells[dgDisc.Index].Value.ToString()) / 100));
                                }
                                CurrentRow.Cells["dgUCUPCurr"].Value = String.Format("{0:N}", discResult).ToString();
                                //if (Convert.ToInt32(CurrentRow.Cells[dgSSM.Index].Value.ToString()) > 1 || Convert.ToInt32(CurrentRow.Cells[dgUC.Index].Value.ToString()) > 1)
                                //{
                                //    CurrentRow.Cells[dgPacketUP.Index].Value = String.Format("{0:0.0000}", decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgUC.Index].Value.ToString())).ToString();
                                //}
                                CurrentRow.Cells[dgPacketUP.Index].Value = String.Format("{0:N}", decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(CurrentRow.Cells[dgUC.Index].Value.ToString())).ToString();
                                //Change lblsubtotal

                                CalculateSubTotal();
                                CalculateTotalWeight();
                                CalculateTotalNetWeight();
                                //ChangeCurr(rowindex);
                                GetLandingCost(CurrentRow.Index);
                                if (dgQuotationAddedItems.CurrentCell == null) dgQuotationAddedItems.CurrentCell = CurrentRow.Cells[0];
                                if (this.Text != "View Quotation")
                                {
                                    GetMargin(rowindex);

                                }
                                //CurrentRow.Cells["dgMargin"].Value = Math.Round(Decimal.Parse(CurrentRow.Cells["dgMargin"].Value.ToString()), 4).ToString();
                                CurrentRow.Cells["dgMargin"].Value = Decimal.Parse(CurrentRow.Cells["dgMargin"].Value.ToString().ToString());

                                if (this.Text != "Modify Quotation" && this.Text != "Edit Quotation" && this.Text != "View Quotation" && this.Text != "Copy Quotation")
                                {
                                    if (CurrentRow.Cells["dgUnitWeigt"].Value != null && CurrentRow.Cells["dgUnitWeigt"].Value.ToString() != "")
                                    {
                                        if (txtStandartWeight.Text != null && txtStandartWeight.Text != "" && txtGrossWeight.Text != null && txtGrossWeight.Text != "")
                                        {
                                            if (Decimal.Parse(txtStandartWeight.Text) < (Decimal.Parse(txtGrossWeight.Text)))
                                            {
                                                CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtGrossWeight.Text)).ToString();
                                                CalculateTotalWeight();
                                                CurrentRow.Cells[dgUnitNetWeight.Index].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                                                CalculateTotalNetWeight();
                                            }
                                            else
                                            {
                                                CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                                                CalculateTotalWeight();
                                                CurrentRow.Cells[dgUnitNetWeight.Index].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                                                CalculateTotalNetWeight();
                                            }
                                        }
                                        CurrentRow.Cells["dgTotalWeight"].Value = (Decimal.Parse(CurrentRow.Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();

                                        CurrentRow.Cells[dgUnitTotalNetWeight.Index].Value = (Decimal.Parse(CurrentRow.Cells[dgUnitNetWeight.Index].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();

                                        if (Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                                        {
                                            CurrentRow.Cells["dgTotalWeight"].Value = (decimal.Parse(CurrentRow.Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();

                                            CurrentRow.Cells[dgUnitTotalNetWeight.Index].Value = (decimal.Parse(CurrentRow.Cells[dgUnitNetWeight.Index].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();
                                        }
                                        else if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1)
                                        {
                                            CurrentRow.Cells["dgTotalWeight"].Value = (decimal.Parse(CurrentRow.Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();

                                            CurrentRow.Cells[dgUnitTotalNetWeight.Index].Value = (decimal.Parse(CurrentRow.Cells[dgUnitNetWeight.Index].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();

                                        }
                                    }
                                }

                                //txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
                                txtTotalMargin.Text = (String.Format("{0:N}", calculateTotalMargin()));
                            }
                            //else { MessageBox.Show("This product does not have price"); }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a number that is a multiple of SSM");
                            CurrentRow.Cells["dgQty"].Value = "";
                            CurrentRow.Cells["dgUPIME"].Value = "";
                            CurrentRow.Cells["dgTotal"].Value = "";
                            dgQuotationAddedItems.CurrentCell = CurrentRow.Cells[dgQty.Index];
                            dgQuotationAddedItems.BeginEdit(true);
                        }

                        #endregion
                        CalculateSubTotal();
                        CalculateTotalWeight();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Item is not available in Price File, please check website and Enter price from ItemCard", "Sure", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            if (dgQuotationAddedItems.RowCount != 1)
                            {
                                dgQuotationAddedItems.Rows.RemoveAt(dgQuotationAddedItems.CurrentCell.RowIndex);
                                dgQuotationAddedItems.Refresh();
                                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
                            }
                            else
                            {
                                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
                            }
                            //dgQuotationAddedItems.Rows.Add(rowindex);
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            if (dgQuotationAddedItems.RowCount != 1)
                            {
                                dgQuotationAddedItems.Rows.RemoveAt(dgQuotationAddedItems.CurrentCell.RowIndex);
                                dgQuotationAddedItems.Refresh();
                            }
                            else
                            {
                                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
                            }
                        }                       
                    }
                }
                #endregion
            }

            calculateTotalCost();
        }

        private void FiyatKirilmalari(decimal adet)
        {
            try
            {
                if (Convert.ToDecimal(txtUnitCount1.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount2.Text) || Convert.ToDecimal(txtUnitCount2.Text) == 0))
                {
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:N}", Decimal.Parse(txtWeb1.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:N}", Decimal.Parse(txtUK1.Text)).ToString();
                }
                else if (Convert.ToDecimal(txtUnitCount2.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount3.Text) || Convert.ToDecimal(txtUnitCount3.Text) == 0))
                {
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:N}", Decimal.Parse(txtWeb2.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:N}", Decimal.Parse(txtUK2.Text)).ToString();
                }
                else if (Convert.ToDecimal(txtUnitCount3.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount4.Text) || Convert.ToDecimal(txtUnitCount4.Text) == 0))
                {
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:N}", Decimal.Parse(txtWeb3.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:N}", Decimal.Parse(txtUK3.Text)).ToString();
                }
                else if (Convert.ToDecimal(txtUnitCount4.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount5.Text) || Convert.ToDecimal(txtUnitCount5.Text) == 0))
                {
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:N}", Decimal.Parse(txtWeb4.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:N}", Decimal.Parse(txtUK4.Text)).ToString();
                }
                else if (Convert.ToDecimal(txtUnitCount5.Text) <= adet)
                {
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:N}", Decimal.Parse(txtWeb5.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:N}", Decimal.Parse(txtUK5.Text)).ToString();
                }
                CurrentRow.Cells[dgFirstUPIME.Index].Value = String.Format("{0:N}", Decimal.Parse(txtWeb1.Text)).ToString();
            }
            catch { }

        }

        private decimal FiyatKirilmalari2(decimal adet)
        {
            decimal result=0;
            try
            {
                if (Convert.ToDecimal(txtUnitCount1.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount2.Text) || Convert.ToDecimal(txtUnitCount2.Text) == 0))
                {
                    result = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(txtWeb1.Text)).ToString());

                }
                else if (Convert.ToDecimal(txtUnitCount2.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount3.Text) || Convert.ToDecimal(txtUnitCount3.Text) == 0))
                {
                    result = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(txtWeb2.Text)).ToString());
                }
                else if (Convert.ToDecimal(txtUnitCount3.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount4.Text) || Convert.ToDecimal(txtUnitCount4.Text) == 0))
                {
                    result = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(txtWeb3.Text)).ToString());

                }
                else if (Convert.ToDecimal(txtUnitCount4.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount5.Text) || Convert.ToDecimal(txtUnitCount5.Text) == 0))
                {
                    result = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(txtWeb4.Text)).ToString());
                }
                else if (Convert.ToDecimal(txtUnitCount5.Text) <= adet)
                {
                    result = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(txtWeb5.Text)).ToString());
                }
            }
            catch { }
            return result;
        }

        private void calculateTotalCost()
        {
            try
            {
                if (dgQuotationAddedItems.RowCount != 0)
                {
                    if (dgQuotationAddedItems.RowCount == 1 && (dgQuotationAddedItems.Rows[0].Cells[dgProductCode.Index].Value == null || dgQuotationAddedItems.Rows[0].Cells[dgProductCode.Index].Value.ToString() == ""))
                    {
                        txtTotalCost.Text = 0.ToString();
                    }
                    else
                    {
                        //Satırların landingCost*Qty çarpımı Total Costu Veriyor
                        decimal totalCost = 0;
                        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                        {
                            decimal LandingCost = 0;
                            decimal Quantity = 0;
                            LandingCost = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString());
                            Quantity = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgQty.Index].Value.ToString());

                            totalCost += (LandingCost * Quantity);
                        }

                        //Total Cost'u seçili olan para birimine dönüştürüyor
                        decimal PoundRate = 0;
                        decimal CurrentRate = 0;
                        PoundRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;
                        CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.currencyId == (decimal)cbCurrency.SelectedValue).OrderByDescending(a => a.date).FirstOrDefault().rate;
                        totalCost = totalCost * PoundRate / (CurrentRate);
                        //txtTotalCost.Text = Math.Round(totalCost, 4).ToString();
                        txtTotalCost.Text = String.Format("{0:N}", totalCost);
                    }
                }

            }
            catch { }
        }

        private void GetMarginMark(int rowindex)
        {
            try
            {
                if (Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgMargin"].Value.ToString()) < LowMarginLimit)
                {
                    dgQuotationAddedItems.Rows[rowindex].Cells["LM"].Style.BackColor = Color.Blue;
                    dgQuotationAddedItems.Rows[rowindex].Cells["dgMargin"].Style.BackColor = Color.Red;
                    //MessageBox.Show("Low Margin ! Ask for authorization");
                }
                else
                {
                    //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LM"].Style.BackColor = Color.FromArgb(90, 185, 194);
                    //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Style.BackColor = Color.FromArgb(90, 185, 194);
                }
            }
            catch { }
        }

        private void GetMarginMark()
        {
            try
            {
                if (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString()) < LowMarginLimit)
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LM"].Style.BackColor = Color.Blue;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Style.BackColor = Color.Red;
                    MessageBox.Show("Low Margin ! Ask for authorization");
                }
                else
                {
                    //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LM"].Style.BackColor = Color.FromArgb(90, 185, 194);
                    //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Style.BackColor = Color.FromArgb(90, 185, 194);
                }
            }
            catch { }
        }

        private void GetMargin()
        {
            #region Get Margin
            DateTime today = DateTime.Today;
            CurrentRow = dgQuotationAddedItems.CurrentRow;
            #region Kur Hesaplama
            decimal currentGbpValue = Convert.ToDecimal(IME.Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);
            decimal gbpPrice = 0;
            if (CurrentRow.Cells[dgUCUPCurr.Index].Value != null && CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString() != "")
            {
                gbpPrice = ((Decimal.Parse(CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString())) * CurrValue) / currentGbpValue;
            }
            #endregion
            if (CurrentRow.Cells["dgQty"].Value != null && CurrentRow.Cells["dgQty"].Value.ToString() != "")
            {
                if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1 || Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                {
                    if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1 && (!(CurrentRow.Cells["dgProductCode"].Value.ToString().Contains("P"))))
                    {
                        CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / (gbpPrice/* * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())*/))) * 100).ToString("G29");
                    }
                    else
                    {
                        if (Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                        {
                            if (!String.IsNullOrEmpty(CurrentRow.Cells["dgLandingCost"].Value.ToString()))
                            {
                                CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / (gbpPrice/* * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())*/))) * 100).ToString("G29");
                            }
                        }
                        else
                        {
                            CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / (gbpPrice/* * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())*/))) * 100).ToString("G29");
                        }
                    }
                }
                else
                {
                    CurrentRow.Cells["dgMargin"].Value = ((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString()) / gbpPrice)) * 100).ToString("G29");
                }
            }
            if (CurrentRow.Cells[dgUCUPCurr.Index].Value != null && CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString() != "" && CurrentRow.Cells[dgQty.Index].Value != null && CurrentRow.Cells[dgQty.Index].Value.ToString() != "")
            {
                CurrentRow.Cells[dgTotal.Index].Value = (decimal.Parse(CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString()) *
                decimal.Parse(CurrentRow.Cells[dgQty.Index].Value.ToString())).ToString();
            }
            #endregion

        }

        private void GetMarginFirst()
        {
            #region Get Margin
            DateTime today = DateTime.Today;
            CurrentRow = dgQuotationAddedItems.CurrentRow;
            #region Kur Hesaplama
            decimal currentGbpValue = Convert.ToDecimal(IME.Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);
            decimal gbpPrice = 0;
            if (CurrentRow.Cells[dgFirstUPIME.Index].Value != null && CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString() != "")
            {
                gbpPrice = ((Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString())) * CurrValue) / currentGbpValue;
            }
            #endregion
            if (CurrentRow.Cells["dgQty"].Value != null && CurrentRow.Cells["dgQty"].Value.ToString() != "")
            {
                if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1 || Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                {
                    if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1 && (!(CurrentRow.Cells["dgProductCode"].Value.ToString().Contains("P"))))
                    {
                        CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / (gbpPrice/* * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())*/))) * 100).ToString("G29");
                    }
                    else
                    {
                        if (Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                        {
                            if (!String.IsNullOrEmpty(CurrentRow.Cells["dgLandingCost"].Value.ToString()))
                            {
                                CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / (gbpPrice/* * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())*/))) * 100).ToString("G29");
                            }
                        }
                        else
                        {
                            CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / (gbpPrice/* * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())*/))) * 100).ToString("G29");
                        }
                    }
                }
                else
                {
                    CurrentRow.Cells["dgMargin"].Value = ((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString()) / gbpPrice)) * 100).ToString("G29");
                }
            }
            if (CurrentRow.Cells[dgFirstUPIME.Index].Value != null && CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString() != "" && CurrentRow.Cells[dgQty.Index].Value != null && CurrentRow.Cells[dgQty.Index].Value.ToString() != "")
            {
                CurrentRow.Cells[dgTotal.Index].Value = (decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString()) *
                decimal.Parse(CurrentRow.Cells[dgQty.Index].Value.ToString())).ToString();
            }
            #endregion

        }

        private void GetMargin(int rowindex)
        {
            #region Get Margin
            DateTime today = DateTime.Today;
            CurrentRow = dgQuotationAddedItems.Rows[rowindex];
            #region Kur Hesaplama
            decimal currentGbpValue = Convert.ToDecimal(IME.Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);
            decimal gbpPrice = 0;
            if (CurrentRow.Cells[dgUCUPCurr.Index].Value != null && CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString() != "")
            {
                gbpPrice = ((Decimal.Parse(CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString())) * CurrValue) / currentGbpValue;
            }
            #endregion
            if (CurrentRow.Cells["dgQty"].Value != null && CurrentRow.Cells["dgQty"].Value.ToString() != "")
            {
                if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1 || Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                {
                    if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1 && (!(CurrentRow.Cells["dgProductCode"].Value.ToString().Contains("P"))))
                    {
                        CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / (gbpPrice/* * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())*/))) * 100).ToString("G29");
                    }
                    else
                    {
                        if (Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                        {
                            if (!String.IsNullOrEmpty(CurrentRow.Cells["dgLandingCost"].Value.ToString()))
                            {
                                CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / (gbpPrice/* * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())*/))) * 100).ToString("G29");
                            }
                        }
                        else
                        {
                            CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / (gbpPrice/* * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())*/))) * 100).ToString("G29");
                        }
                    }
                }
                else
                {
                    CurrentRow.Cells["dgMargin"].Value = ((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString()) / gbpPrice)) * 100).ToString("G29");
                }
            }
            if (CurrentRow.Cells[dgUCUPCurr.Index].Value != null && CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString() != "" && CurrentRow.Cells[dgQty.Index].Value != null && CurrentRow.Cells[dgQty.Index].Value.ToString() != "")
            {
                CurrentRow.Cells[dgTotal.Index].Value = (decimal.Parse(CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString()) *
                decimal.Parse(CurrentRow.Cells[dgQty.Index].Value.ToString())).ToString();
            }
            #endregion

        }

        private void GetAllMargin()
        {
            #region Get Margin
            DateTime today = DateTime.Today;
            decimal total = 0;
            decimal totalMargin = 0;


            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                try
                {
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString()))
                    {
                        //if (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value.ToString()) > 1 && (!(dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString().Contains("P"))))
                        //{
                        //    dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()) * decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value.ToString()))))) * 100).ToString("G29");
                        //}
                        //else
                        //{
                        //    decimal margin = 0;
                        //    decimal UCUPCurr = 0;
                        //    decimal landingCost = 0;
                        //    UCUPCurr = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                        //    landingCost = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString());
                        //    margin = (1 - (landingCost / UCUPCurr)) * 100;
                        //    dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = margin;

                        //    total += Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                        //    totalMargin += (margin * total);
                        //    //dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = ((1 - (landingCost / (UCUPCurr))) * 100).ToString("G29");
                        //    //dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())
                        //    //   ) / ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");

                        //}

                        dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = CalculateMargin(
                                        Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString()),
                                        Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()));
                    }
                }
                catch { }

            }
            if (total != 0)
            {
                CalculateTotalMarge();
            }
            #endregion
        }

        private void FillProductCodeItem()
        {
            #region FillProductCodeItem
            CurrentRow = dgQuotationAddedItems.CurrentRow;
            CurrentRow.Cells[dgCCCNO.Index].Value = txtCCCN.Text;
            CurrentRow.Cells[dgCOO.Index].Value = txtCofO.Text;

            if (CurrentRow.Cells[dgSSM.Index].Value != null && CurrentRow.Cells[dgSSM.Index].Value.ToString() != "" && CurrentRow.Cells[dgUC.Index].Value != null && CurrentRow.Cells[dgUC.Index].Value.ToString() != "" && txtStandartWeight.Text != "")
            {
                //dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
                decimal SSM = Convert.ToDecimal(CurrentRow.Cells[dgSSM.Index].Value);
                decimal UC = Convert.ToDecimal(CurrentRow.Cells[dgUC.Index].Value);
                decimal StandardWeight = Convert.ToDecimal(txtStandartWeight.Text);
            }
            #endregion
        }

        private void ItemClear()
        {
            #region ItemPageClear
            label63.BackColor = Color.Transparent;
            label53.BackColor = Color.Transparent;
            label64.BackColor = Color.Transparent;
            label55.BackColor = Color.Transparent;
            label26.BackColor = Color.Transparent;
            label28.BackColor = Color.Transparent;
            txtManufacturer.Text = "";
            textBox17.Text = "";
            txtSupersectionName.Text = "";
            textBox14.Text = "";
            txtMHCodeLevel1.Text = "";
            txtCofO.Text = "";
            txtCCCN.Text = "";
            textBox21.Text = "";
            textBox20.Text = "";
            textBox19.Text = "";
            textBox18.Text = "";
            textBox22.Text = "";
            txtRSStock.Text = "";
            textBox23.Text = "";
            txtRSOnOrder.Text = "";
            textBox24.Text = "";
            txtHazardousInd.Text = "";
            txtEnvironment.Text = "";
            txtShipping.Text = "";
            txtLithium.Text = "";
            txtCalibrationInd.Text = "";
            txtLicenceType.Text = "";
            txtDiscChange.Text = "";
            txtExpiringPro.Text = "";
            txtUKDiscDate.Text = "";
            txtDiscontinuationDate.Text = "";
            txtSubstitutedBy.Text = "";
            txtRunOn.Text = "";
            txtReferral.Text = "";
            txtPP.Text = "";
            txtHeight.Text = "";
            txtWidth.Text = "";
            txtLength.Text = "";
            txtStandartWeight.Text = "";
            txtGrossWeight.Text = "";
            txtUnitCount1.Text = "";
            txtUnitCount2.Text = "";
            txtUnitCount3.Text = "";
            txtUnitCount4.Text = "";
            txtUnitCount5.Text = "";
            txtWeb1.Text = "";
            txtWeb2.Text = "";
            txtWeb3.Text = "";
            txtWeb4.Text = "";
            txtWeb5.Text = "";
            txtUK1.Text = "";
            txtUK2.Text = "";
            txtUK3.Text = "";
            txtUK4.Text = "";
            txtUK5.Text = "";
            txtCost1.Text = "";
            txtCost2.Text = "";
            txtCost3.Text = "";
            txtCost4.Text = "";
            txtCost5.Text = "";
            txtMargin1.Text = "";
            txtMargin2.Text = "";
            txtMargin3.Text = "";
            txtMargin4.Text = "";
            txtMargin5.Text = "";
            #endregion
        }

       // private void ItemDetailsFillerKeyDown(string ArticleNoSearch)
       // {
       //     CurrentRow = dgQuotationAddedItems.CurrentRow;
       //     #region Filler
       //     decimal CurrValueWeb = Decimal.Parse(curr.rate.ToString());
       //     string ArticleNoSearch1 = ArticleNoSearch;
       //     try { ArticleNoSearch1 = (Int32.Parse(ArticleNoSearch)).ToString(); } catch { }
       //     //Seçili olan item ı text lere yazdıran fonksiyon yazılacak
       //     SuperDisk sd;
       //     SuperDiskP sdP;
       //     ExtendedRange er;

       //     var ItemTabDetails = IME.ItemDetailTabFiller(ArticleNoSearch).FirstOrDefault();

       //     if (ItemTabDetails != null)
       //     {
       //         CurrentRow.Cells["dgDesc"].Value = ItemTabDetails.Article_Desc;
       //         CurrentRow.Cells["dgSSM"].Value = ItemTabDetails.Pack_Quantity.ToString() ?? ""; ;
       //         CurrentRow.Cells["dgUC"].Value = ItemTabDetails.Unit_Content.ToString() ?? ""; ;
       //         CurrentRow.Cells["dgUOM"].Value = ItemTabDetails.Unit_Measure;
       //         CurrentRow.Cells["dgMPN"].Value = ItemTabDetails.MPN;
       //         CurrentRow.Cells["dgCL"].Value = ItemTabDetails.Calibration_Ind;
       //         if (ItemTabDetails.Standard_Weight != null && ItemTabDetails.Standard_Weight != 0)
       //         {
       //             decimal sW = (decimal)(ItemTabDetails.Standard_Weight / (decimal)1000);
       //             sW = (ItemTabDetails.Pack_Quantity > ItemTabDetails.Unit_Content) ? (decimal)(sW / ItemTabDetails.Pack_Quantity) : (decimal)(sW / ItemTabDetails.Unit_Content);
       //             txtStandartWeight.Text = sW.ToString();
       //         }
       //         txtHazardousInd.Text = ItemTabDetails.Hazardous_Ind;
       //         txtCalibrationInd.Text = ItemTabDetails.Calibration_Ind;
       //         txtCofO.Text = ItemTabDetails.CofO;
       //         txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
       //         txtUKDiscDate.Text = ItemTabDetails.Uk_Disc_Date;
       //         txtDiscChange.Text = ItemTabDetails.Disc_Change_Ind;
       //         txtExpiringPro.Text = ItemTabDetails.Expiring_Product_Change_Ind;
       //         txtManufacturer.Text = ItemTabDetails.Manufacturer.ToString() ?? "";
       //         txtMHCodeLevel1.Text = ItemTabDetails.MH_Code_Level_1;
       //         txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
       //         txtHeight.Text = ((decimal)(ItemTabDetails.Heigh * ((Decimal)100))).ToString("G29");
       //         txtWidth.Text = ((decimal)(ItemTabDetails.Width * ((Decimal)100))).ToString("G29");
       //         txtLength.Text = ((decimal)(ItemTabDetails.Length * ((Decimal)100))).ToString("G29");
       //         txtGrossWeight.Text = String.Format("{0:0.0000}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());
       //         txtGrossWeight.Text = (ItemTabDetails.Pack_Quantity > ItemTabDetails.Unit_Content) ? (Decimal.Parse(txtGrossWeight.Text) / ItemTabDetails.Pack_Quantity).ToString() : (Decimal.Parse(txtGrossWeight.Text) / ItemTabDetails.Unit_Content).ToString();
       //         txtUK1.Text = (ItemTabDetails.Col1Price / ItemTabDetails.Unit_Content).ToString();
       //         txtUK2.Text = (ItemTabDetails.Col2Price / ItemTabDetails.Unit_Content).ToString();
       //         txtUK3.Text = (ItemTabDetails.Col3Price / ItemTabDetails.Unit_Content).ToString();
       //         txtUK4.Text = (ItemTabDetails.Col4Price / ItemTabDetails.Unit_Content).ToString();
       //         txtUK5.Text = (ItemTabDetails.Col5Price / ItemTabDetails.Unit_Content).ToString();
       //         if (txtUK1.Text == "") { txtUK1.Text = "0"; }
       //         if (txtUK2.Text == "") { txtUK2.Text = "0"; }
       //         if (txtUK3.Text == "") { txtUK3.Text = "0"; }
       //         if (txtUK4.Text == "") { txtUK4.Text = "0"; }
       //         if (txtUK5.Text == "") { txtUK5.Text = "0"; }
       //         txtUnitCount1.Text = (ItemTabDetails.Col1Break * ItemTabDetails.Unit_Content).ToString();
       //         txtUnitCount2.Text = (ItemTabDetails.Col2Break * ItemTabDetails.Unit_Content).ToString();
       //         txtUnitCount3.Text = (ItemTabDetails.Col3Break * ItemTabDetails.Unit_Content).ToString();
       //         txtUnitCount4.Text = (ItemTabDetails.Col4Break * ItemTabDetails.Unit_Content).ToString();
       //         txtUnitCount5.Text = (ItemTabDetails.Col5Break * ItemTabDetails.Unit_Content).ToString();
       //         txtCost1.Text = (ItemTabDetails.DiscountedPrice1 / ItemTabDetails.Unit_Content).ToString();
       //         txtCost2.Text = (ItemTabDetails.DiscountedPrice2 / ItemTabDetails.Unit_Content).ToString();
       //         txtCost3.Text = (ItemTabDetails.DiscountedPrice3 / ItemTabDetails.Unit_Content).ToString();
       //         txtCost4.Text = (ItemTabDetails.DiscountedPrice4 / ItemTabDetails.Unit_Content).ToString();
       //         txtCost5.Text = (ItemTabDetails.DiscountedPrice5 / ItemTabDetails.Unit_Content).ToString();
       //         txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
       //         txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
       //         txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
       //         txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
       //         txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
       //         txtSupersectionName.Text = ItemTabDetails.SupersectionName;
       //         if (ItemTabDetails.Environment != null) { txtEnvironment.Text = "Y"; } else { txtEnvironment.Text = ""; }
       //         txtLithium.Text = (ItemTabDetails.Lithium != null && ItemTabDetails.Lithium != String.Empty) ? "Y" : "";
       //         txtShipping.Text = (ItemTabDetails.Shipping != null && ItemTabDetails.Shipping != String.Empty) ? "Y" : "";
       //         txtRSStock.Text = ItemTabDetails.OnhandStockBalance.ToString();
       //         txtRSOnOrder.Text = ItemTabDetails.QuantityonOrder.ToString();
       //         txtDiscontinuationDate.Text = ItemTabDetails.DiscontinuationDate;
       //         txtRunOn.Text = ItemTabDetails.Runon?.ToString();
       //         txtReferral.Text = ItemTabDetails.Referral?.ToString();
       //         txtLicenceType.Text = ItemTabDetails.LicenceType;

       //         #region ItemMarginFiller
       //         if ((ItemTabDetails.Col1Break * ItemTabDetails.Unit_Content).ToString() == "")
       //         {
       //             ItemTabDetails.Col1Break = 0;
       //         }
       //         int quantity = Int32.Parse((ItemTabDetails.Col1Break * ItemTabDetails.Unit_Content).ToString() ?? "0");
       //         if (quantity != 0)
       //         {
       //             //            decimal margin1 = 0;
       //             //            margin1 = (QuotationUtils.GetLandingCost(CurrentRow.Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
       //             //, quantity));

       //             txtMargin1.Text = ((1 - ((decimal.Parse(txtCost1.Text)) / (decimal.Parse(txtUK1.Text)))) * 100).ToString();
       //             //int quantity2 = 0;
       //             //quantity2 = Int32.Parse(ItemTabDetails.Col2Break.ToString());
       //             //decimal margin2 = 0;
       //             //margin2 = (QuotationUtils.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
       //             //                 , quantity2));
       //             if (decimal.Parse(txtUK2.Text) == 0)
       //             {
       //                 txtMargin2.Text = "";
       //                 txtMargin3.Text = "";
       //                 txtMargin4.Text = "";
       //                 txtMargin5.Text = "";
       //             }
       //             else
       //             {

       //                 txtMargin2.Text = ((1 - ((decimal.Parse(txtCost2.Text)) / (decimal.Parse(txtUK2.Text)))) * 100).ToString();
       //                 try
       //                 {
       //                     //decimal margin3 = 0;
       //                     //margin3 = (QuotationUtils.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked, Int32.Parse(ItemTabDetails.Col3Break.ToString())));
       //                     if (decimal.Parse(txtUK3.Text) != 0)
       //                     {
       //                         txtMargin3.Text = ((1 - ((decimal.Parse(txtCost3.Text)) / (decimal.Parse(txtUK3.Text)))) * 100).ToString();
       //                         if (ItemTabDetails.Col4Break != 0)
       //                         {
       //                             //    decimal margin4 = 0;
       //                             //    margin4 = (QuotationUtils.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
       //                             //, Int32.Parse(ItemTabDetails.Col4Break.ToString())));
       //                             txtMargin4.Text = ((1 - ((decimal.Parse(txtCost4.Text)) / (decimal.Parse(txtUK4.Text)))) * 100).ToString();
       //                             if (ItemTabDetails.Col5Break != 0)
       //                             {
       //                                 //    decimal margin5 = 0;
       //                                 //    margin5 = (QuotationUtils.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
       //                                 //, Int32.Parse(ItemTabDetails.Col5Break.ToString())));
       //                                 txtMargin5.Text = ((1 - ((decimal.Parse(txtCost5.Text)) / (decimal.Parse(txtUK5.Text)))) * 100).ToString();
       //                             }
       //                             else
       //                             {
       //                                 txtMargin5.Text = "";
       //                             }
       //                         }
       //                         else
       //                         {
       //                             txtMargin4.Text = "";
       //                             txtMargin5.Text = "";
       //                         }
       //                     }
       //                     else
       //                     {
       //                         txtMargin3.Text = "";
       //                         txtMargin4.Text = "";
       //                         txtMargin5.Text = "";
       //                     }

       //                 }
       //                 catch { }

       //             }

       //             #endregion



       //         }
       //         if (CurrentRow.Cells["dgUOM"].Value == null && CurrentRow.Cells["dgUC"].Value != null)
       //         { CurrentRow.Cells["dgUOM"].Value = "Each"; }
       //         #endregion

       //         #region Low Margin Mark Clear
       //         if (!String.IsNullOrEmpty(txtLithium.Text) && txtLithium.Text == "Y")
       //         {
       //             label64.BackColor = Color.Red;
       //             //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.Ivory;
       //             dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.Red;
       //         }
       //         //else
       //         //{
       //         //    label64.BackColor = Color.White;
       //         //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.White;
       //         //}
       //         if (!String.IsNullOrEmpty(txtShipping.Text) && txtShipping.Text == "Y")
       //         {
       //             label63.BackColor = Color.Red;
       //             dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

       //         }
       //         //else
       //         //{
       //         //    label63.BackColor = Color.White;
       //         //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.White;
       //         //}

       //         if (!String.IsNullOrEmpty(txtEnvironment.Text) && txtEnvironment.Text == "Y")
       //         {
       //             label53.BackColor = Color.Red;
       //         }
       //         //else
       //         //{
       //         //    label53.BackColor = Color.White;
       //         //}

       //         //if (txtCalibrationInd.Text != "" && txtCalibrationInd.Text != null && txtCalibrationInd.Text != "N")
       //         if (!String.IsNullOrEmpty(txtCalibrationInd.Text) && txtCalibrationInd.Text == "Y")
       //         {
       //             label22.BackColor = Color.Red;
       //             //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Green;
       //             dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Red;
       //         }
       //         //else
       //         //{
       //         //    label22.BackColor = Color.White;
       //         //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.White;
       //         //}

       //         if (!String.IsNullOrEmpty(txtLicenceType.Text))
       //         {
       //             //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
       //             dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.Red;
       //         }
       //         //else
       //         //{
       //         //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.White;
       //         //}
       //         #endregion

       //     }
       //(dgQuotationAddedItems.CurrentRow.Cells[dgDelivery.Index] as DataGridViewComboBoxCell).Value = 3;
       // }

        private void ItemDetailsFiller(string ArticleNoSearch)
        {
            CurrentRow = dgQuotationAddedItems.CurrentRow;
            #region Filler
            decimal CurrValueWeb = Decimal.Parse(curr.rate.ToString());
            string ArticleNoSearch1 = ArticleNoSearch;
            try { ArticleNoSearch1 = (Int32.Parse(ArticleNoSearch)).ToString(); } catch { }
            string supplier = "SC0001";
            //Seçili olan item ı text lere yazdıran fonksiyon yazılacak
            SuperDisk sd;
            SuperDiskP sdP;
            ExtendedRange er;
            string custStockCode = "";
            string custStockDesc = "";
            var ItemTabDetails = IME.ItemDetailTabFiller(ArticleNoSearch).FirstOrDefault();
            if (IME.QuotationDetails.Where(x => x.ItemCode == ArticleNoSearch && x.CustomerDesc == txtCustomerName.Text).FirstOrDefault() != null)
            {
              custStockCode = IME.QuotationDetails.Where(x=> x.ItemCode==ArticleNoSearch && x.CustomerDesc == txtCustomerName.Text).FirstOrDefault().CustomerStockCode;
              custStockDesc = IME.QuotationDetails.Where(x => x.ItemCode == ArticleNoSearch && x.CustomerDesc == txtCustomerName.Text).FirstOrDefault().CustomerDesc;
            }
           
            var rsf = IME.RsFileHistories.Where(a => a.FileType == "OnSale").OrderByDescending(x => x.Date).FirstOrDefault();

            if (ItemTabDetails != null)
            {
                dgQuotationAddedItems.CurrentRow.Cells["dgDesc"].Value = ItemTabDetails.Article_Desc;
                CurrentRow.Cells["dgSSM"].Value = ItemTabDetails.Pack_Quantity.ToString() ?? ""; ;
                CurrentRow.Cells["dgUC"].Value = ItemTabDetails.Unit_Content.ToString() ?? ""; ;
                if (ItemTabDetails.Unit_Measure == "")
                {
                    if (CurrentRow.Cells[dgUC.Index].Value.ToString() == "1" && CurrentRow.Cells[dgSSM.Index].Value.ToString() == "1")
                    {
                        CurrentRow.Cells["dgUOM"].Value = "EACH";
                    }
                    else
                    {
                        CurrentRow.Cells["dgUOM"].Value = "PACKET OF";
                    }
                }
                else
                {
                    CurrentRow.Cells["dgUOM"].Value = ItemTabDetails.Unit_Measure;
                }
                CurrentRow.Cells["dgMPN"].Value = ItemTabDetails.MPN;
                CurrentRow.Cells["dgCL"].Value = ItemTabDetails.Calibration_Ind;
                CurrentRow.Cells[dgCustDescription.Index].Value = custStockDesc;
                CurrentRow.Cells[dgCustStkCode.Index].Value = custStockCode;
                CurrentRow.Cells[dgBrand.Index].Value = ItemTabDetails.Manufacturer;
                CurrentRow.Cells[dgSupplier.Index].Value = IME.Suppliers.Where(x=> x.ID == supplier).FirstOrDefault().s_name;
                if (ItemTabDetails.Standard_Weight != null && ItemTabDetails.Standard_Weight != 0)
                {
                    decimal sW = (decimal)(ItemTabDetails.Standard_Weight / (decimal)1000);
                    sW = (ItemTabDetails.Pack_Quantity > ItemTabDetails.Unit_Content) ? (decimal)(sW / ItemTabDetails.Pack_Quantity) : (decimal)(sW / ItemTabDetails.Unit_Content);
                    txtStandartWeight.Text = String.Format("{0:N}", sW.ToString());
                }
                
                txtHazardousInd.Text = ItemTabDetails.Hazardous_Ind;
                txtHazardousInd.Text = (ItemTabDetails.Hazardous_Ind != null && ItemTabDetails.Hazardous_Ind != String.Empty && ItemTabDetails.Hazardous_Ind != "N") ? "Y" : "";
                txtCalibrationInd.Text = ItemTabDetails.Calibration_Ind;
                txtCalibrationInd.Text = (ItemTabDetails.Calibration_Ind != null && ItemTabDetails.Calibration_Ind != String.Empty && ItemTabDetails.Calibration_Ind != "N") ? "Y" : "";
                txtEnvironment.Text = ItemTabDetails.Environment.ToString();
                txtEnvironment.Text = (ItemTabDetails.Environment != null && ItemTabDetails.Environment != 0) ? "Y" : "";
                txtLicenceType.Text = ItemTabDetails.LicenceType;
                txtLicenceType.Text = (ItemTabDetails.LicenceType != null && ItemTabDetails.LicenceType != String.Empty && ItemTabDetails.LicenceType != "0") ? "Y" : "";
                txtShipping.Text = ItemTabDetails.Shipping;
                txtShipping.Text = (ItemTabDetails.Shipping != null && ItemTabDetails.Shipping != String.Empty && ItemTabDetails.Shipping != "0") ? "Y" : "";
                txtDiscChange.Text = ItemTabDetails.Low_Discount_Ind;
                txtLithium.Text = ItemTabDetails.Lithium;
                txtLithium.Text = (ItemTabDetails.Lithium != null && ItemTabDetails.Lithium != String.Empty && ItemTabDetails.Lithium != "0") ? "Y" : "";
                txtExpiringPro.Text = ItemTabDetails.Expiring_Product_Change_Ind;
                txtExpiringPro.Text = (ItemTabDetails.Expiring_Product_Change_Ind != null && ItemTabDetails.Expiring_Product_Change_Ind != String.Empty && ItemTabDetails.Expiring_Product_Change_Ind != "0") ? "Y" : "";
                txtCofO.Text = ItemTabDetails.CofO;
                txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
                txtUKDiscDate.Text = ItemTabDetails.Uk_Disc_Date;
                txtDiscChange.Text = ItemTabDetails.Disc_Change_Ind;
                txtExpiringPro.Text = ItemTabDetails.Expiring_Product_Change_Ind;
                txtManufacturer.Text = ItemTabDetails.Manufacturer.ToString() ?? "";
                txtMHCodeLevel1.Text = ItemTabDetails.MH_Code_Level_1;
                txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
                txtHeight.Text = ((decimal)(ItemTabDetails.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(ItemTabDetails.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(ItemTabDetails.Length * ((Decimal)100))).ToString("G29");
                txtGrossWeight.Text = String.Format("{0:N}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());
                txtGrossWeight.Text = (ItemTabDetails.Pack_Quantity > ItemTabDetails.Unit_Content) ? (Decimal.Parse(txtGrossWeight.Text) / ItemTabDetails.Pack_Quantity).ToString() : (Decimal.Parse(txtGrossWeight.Text) / ItemTabDetails.Unit_Content).ToString();
                txtUK1.Text = (ItemTabDetails.Col1Price / ItemTabDetails.Unit_Content).ToString();
                txtUK2.Text = (ItemTabDetails.Col2Price / ItemTabDetails.Unit_Content).ToString();
                txtUK3.Text = (ItemTabDetails.Col3Price / ItemTabDetails.Unit_Content).ToString();
                txtUK4.Text = (ItemTabDetails.Col4Price / ItemTabDetails.Unit_Content).ToString();
                txtUK5.Text = (ItemTabDetails.Col5Price / ItemTabDetails.Unit_Content).ToString();
                if (txtUK1.Text == "") { txtUK1.Text = "0"; }
                if (txtUK2.Text == "") { txtUK2.Text = "0"; }
                if (txtUK3.Text == "") { txtUK3.Text = "0"; }
                if (txtUK4.Text == "") { txtUK4.Text = "0"; }
                if (txtUK5.Text == "") { txtUK5.Text = "0"; }
                txtUnitCount1.Text = (ItemTabDetails.Col1Break * ItemTabDetails.Unit_Content).ToString();
                txtUnitCount2.Text = (ItemTabDetails.Col2Break * ItemTabDetails.Unit_Content).ToString();
                txtUnitCount3.Text = (ItemTabDetails.Col3Break * ItemTabDetails.Unit_Content).ToString();
                txtUnitCount4.Text = (ItemTabDetails.Col4Break * ItemTabDetails.Unit_Content).ToString();
                txtUnitCount5.Text = (ItemTabDetails.Col5Break * ItemTabDetails.Unit_Content).ToString();
                txtCost1.Text = (ItemTabDetails.DiscountedPrice1 / ItemTabDetails.Unit_Content).ToString();
                txtCost2.Text = (ItemTabDetails.DiscountedPrice2 / ItemTabDetails.Unit_Content).ToString();
                txtCost3.Text = (ItemTabDetails.DiscountedPrice3 / ItemTabDetails.Unit_Content).ToString();
                txtCost4.Text = (ItemTabDetails.DiscountedPrice4 / ItemTabDetails.Unit_Content).ToString();
                txtCost5.Text = (ItemTabDetails.DiscountedPrice5 / ItemTabDetails.Unit_Content).ToString();
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtSupersectionName.Text = ItemTabDetails.SupersectionName;
                
                txtRSStock.Text = ItemTabDetails.OnhandStockBalance.ToString();
                textBox23.Text = rsf.Date.ToString();
                txtRSOnOrder.Text = ItemTabDetails.QuantityonOrder.ToString();
                txtDiscontinuationDate.Text = ItemTabDetails.DiscontinuationDate;
                txtRunOn.Text = ItemTabDetails.Runon?.ToString();
                txtReferral.Text = ItemTabDetails.Referral?.ToString();

                #region ItemMarginFiller
                if ((ItemTabDetails.Col1Break * ItemTabDetails.Unit_Content).ToString() == "")
                {
                    ItemTabDetails.Col1Break = 0;
                }
                int quantity = Int32.Parse((ItemTabDetails.Col1Break * ItemTabDetails.Unit_Content).ToString() ?? "0");
                if (quantity != 0)
                {
                    //            decimal margin1 = 0;
                    //            margin1 = (QuotationUtils.GetLandingCost(CurrentRow.Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                    //, quantity));

                    txtMargin1.Text = ((1 - ((decimal.Parse(txtCost1.Text)) / (decimal.Parse(txtUK1.Text)))) * 100).ToString();
                    //int quantity2 = 0;
                    //quantity2 = Int32.Parse(ItemTabDetails.Col2Break.ToString());
                    //decimal margin2 = 0;
                    //margin2 = (QuotationUtils.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                    //                 , quantity2));
                    if (decimal.Parse(txtUK2.Text) == 0)
                    {
                        txtMargin2.Text = "";
                        txtMargin3.Text = "";
                        txtMargin4.Text = "";
                        txtMargin5.Text = "";
                    }
                    else
                    {

                        txtMargin2.Text = ((1 - ((decimal.Parse(txtCost2.Text)) / (decimal.Parse(txtUK2.Text)))) * 100).ToString();
                        try
                        {
                            //decimal margin3 = 0;
                            //margin3 = (QuotationUtils.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked, Int32.Parse(ItemTabDetails.Col3Break.ToString())));
                            if (decimal.Parse(txtUK3.Text) != 0)
                            {
                                txtMargin3.Text = ((1 - ((decimal.Parse(txtCost3.Text)) / (decimal.Parse(txtUK3.Text)))) * 100).ToString();
                                if (ItemTabDetails.Col4Break != 0)
                                {
                                    //    decimal margin4 = 0;
                                    //    margin4 = (QuotationUtils.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                                    //, Int32.Parse(ItemTabDetails.Col4Break.ToString())));
                                    txtMargin4.Text = ((1 - ((decimal.Parse(txtCost4.Text)) / (decimal.Parse(txtUK4.Text)))) * 100).ToString();
                                    if (ItemTabDetails.Col5Break != 0)
                                    {
                                        //    decimal margin5 = 0;
                                        //    margin5 = (QuotationUtils.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                                        //, Int32.Parse(ItemTabDetails.Col5Break.ToString())));
                                        txtMargin5.Text = ((1 - ((decimal.Parse(txtCost5.Text)) / (decimal.Parse(txtUK5.Text)))) * 100).ToString();
                                    }
                                    else
                                    {
                                        txtMargin5.Text = "";
                                    }
                                }
                                else
                                {
                                    txtMargin4.Text = "";
                                    txtMargin5.Text = "";
                                }
                            }
                            else
                            {
                                txtMargin3.Text = "";
                                txtMargin4.Text = "";
                                txtMargin5.Text = "";
                            }

                        }
                        catch { }

                    }

                    #endregion



                }
                if (CurrentRow.Cells["dgUOM"].Value == null && CurrentRow.Cells["dgUC"].Value != null)
                { CurrentRow.Cells["dgUOM"].Value = "Each"; }
                #endregion

                #region Low Margin Mark Clear
                if (!String.IsNullOrEmpty(txtHazardousInd.Text) && txtHazardousInd.Text == "Y")
                {
                    label63.BackColor = Color.Red;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

                }
                if (!String.IsNullOrEmpty(txtLithium.Text) && txtLithium.Text == "Y")
                {
                    label64.BackColor = Color.Red;
                    //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.Ivory;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.Red;
                }
                //else
                //{
                //    label64.BackColor = Color.White;
                //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.White;
                //}
                if (!String.IsNullOrEmpty(txtShipping.Text) && txtShipping.Text == "Y")
                {
                    label63.BackColor = Color.Red;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

                }
                //else
                //{
                //    label63.BackColor = Color.White;
                //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.White;
                //}

                if (!String.IsNullOrEmpty(txtEnvironment.Text) && txtEnvironment.Text == "Y")
                {
                    label53.BackColor = Color.Red;
                }
                //else
                //{
                //    label53.BackColor = Color.White;
                //}

                //if (txtCalibrationInd.Text != "" && txtCalibrationInd.Text != null && txtCalibrationInd.Text != "N")
                if (!String.IsNullOrEmpty(txtCalibrationInd.Text) && txtCalibrationInd.Text == "Y")
                {
                    label22.BackColor = Color.Red;
                    //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Green;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Red;
                }
                //else
                //{
                //    label22.BackColor = Color.White;
                //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.White;
                //}

                if (!String.IsNullOrEmpty(txtLicenceType.Text))
                {
                    //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.Red;
                }
                //else
                //{
                //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.White;
                //}
                #endregion

            }
        }

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MakeTextUpperCase((TextBox)sender);
                CustomerSearchInput();
            }
        }

        //private void txtLength_TextChanged(object sender, EventArgs e)
        //{
        //    CurrentRow = dgQuotationAddedItems.CurrentRow;
        //    txtGrossWeight.Text = "";
        //    try
        //    {
        //        if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
        //        {
        //            txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();
        //            if (Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
        //            {
        //                txtGrossWeight.Text = (decimal.Parse(txtGrossWeight.Text) /
        //                    Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString())).ToString();

        //            }
        //            else if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1)
        //            {
        //                txtGrossWeight.Text = (decimal.Parse(txtGrossWeight.Text) /
        //                    Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString())).ToString();
        //            }
        //        }
        //    }
        //    catch { }

        //}

        private void dgQuotationAddedItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (sayac == 1)
            {
                if (dgQuotationAddedItems.RowCount > 1) dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[0].Value = (decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();

            }
        }

        private void dgQuotationAddedItems_Click(object sender, EventArgs e)
        {
            CurrentRow = dgQuotationAddedItems.CurrentRow;
            ItemClear();
            try { ItemDetailsFiller(CurrentRow.Cells["dgProductCode"].Value.ToString()); } catch { }
        }



        private void GetLandingCost(int Rowindex)
        {
            try
            {
                dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = (QuotationUtils.GetLandingCost(dgQuotationAddedItems.Rows[Rowindex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                    , Int32.Parse(dgQuotationAddedItems.Rows[Rowindex].Cells[dgQty.Index].Value.ToString()))).ToString("G29");
                dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = String.Format("{0:N}", dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value.ToString()).ToString();
            }
            catch (Exception e) { }

        }

        private void getQuotationValues()
        {
            if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
            {
                for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                {
                    CurrentRow = dgQuotationAddedItems.Rows[i];
                    if (CurrentRow.Cells["dgProductCode"].Value != null)
                    {
                        GetLandingCost(i);
                        if (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString()) < Decimal.Parse(CurrentRow.Cells["dgCost"].Value.ToString()))
                        {
                            CurrentRow.Cells["dgLandingCost"].Value = CurrentRow.Cells["dgCost"].Value.ToString();
                        }
                        GetAllMargin();
                        try
                        {
                            #region Get Margin
                            if (CurrentRow.Cells["dgQty"].Value != null)
                            {
                                CurrentRow.Cells["dgMargin"].Value = CalculateMargin(
                                    Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString()),
                                    Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString()));
                                //CurrentRow.Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
                            }
                            #endregion
                        }
                        catch { }
                    }
                }
            }
        }

        private decimal CalculateMargin(decimal _LandingCost, decimal _Price)
        {
            decimal currentGbpValue = Convert.ToDecimal(IME.Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);
            decimal gbpPrice = ((_Price) * CurrValue) / currentGbpValue;
            
            return Decimal.Parse(String.Format("{0:N}", ((1 - (_LandingCost / gbpPrice)) * 100)));
        }

        private void ckItemCost_CheckedChanged(object sender, EventArgs e)
        {
            if (ckItemCost.Checked == true)
            {
                getQuotationValues();
            }

        }

        private void CalculateTotalWeight()
        {
            decimal totalweight = 0;
            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
            {
                decimal rowTotal = 0;
                try
                {
                    rowTotal = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgTotalWeight.Index].Value.ToString())));
                }
                catch { }
                totalweight = Decimal.Parse(String.Format("{0:N}", totalweight + rowTotal));
            }
            //lblTotalWeight.Text = Math.Round(totalweight, 4).ToString(); 
            lblTotalWeight.Text = String.Format("{0:N}", totalweight);
        }

        private void CalculateTotalNetWeight()
        {
            decimal totalnetweight = 0;
            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
            {
                decimal rowTotal = 0;
                try
                {
                    rowTotal = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUnitTotalNetWeight.Index].Value.ToString())));
                }
                catch { }
                totalnetweight = Decimal.Parse(String.Format("{0:N}", totalnetweight + rowTotal));
            }
            //lblTotalNetWeight.Text = Math.Round(totalnetweight, 4).ToString();
            lblTotalNetWeight.Text = String.Format("{0:N}", totalnetweight);
        }

        private void CalculateSubTotal()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
            {
                decimal rowTotal = 0;
                try
                {

                    item.Cells[dgTotal.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString()) * decimal.Parse(item.Cells[dgQty.Index].Value.ToString())));
                    rowTotal = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgTotal.Index].Value.ToString())));
                }
                catch { }
                subtotal = Decimal.Parse(String.Format("{0:N}", subtotal + rowTotal));
            }
            //lblsubtotal.Text = Math.Round(subtotal, 4).ToString();
            lblsubtotal.Text = String.Format("{0:N}", subtotal);
            decimal dectotaldisc = 0;

            if (txtTotalDis2.Text != "" && txtTotalDis2.Text != null)
            {
                decimal totaldis = 0;
                totaldis = Decimal.Parse(String.Format("{0:N}", decimal.Parse(txtTotalDis.Text)));
                txtTotalDis2.Text = String.Format("{0:N}", Decimal.Parse((subtotal * totaldis / 100).ToString()));
                dectotaldisc = decimal.Parse(String.Format("{0:N}", Decimal.Parse(txtTotalDis2.Text)));
            }

            lbltotal.Text = String.Format("{0:N}", Decimal.Parse((subtotal - dectotaldisc).ToString()));
        }

        private void CalculateSubTotalActivate()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
            {
                decimal rowTotal = 0;
                try
                {
                    item.Cells[dgTotal.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgFirstUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgQty.Index].Value.ToString())));
                    rowTotal = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgTotal.Index].Value.ToString())));
                }
                catch { }
                subtotal = Decimal.Parse(String.Format("{0:N}", subtotal + rowTotal));
            }
            //lblsubtotal.Text = Math.Round(subtotal, 4).ToString();
            lblsubtotal.Text = String.Format("{0:N}", subtotal);
            decimal dectotaldisc = 0;

            if (txtTotalDis2.Text != "" && txtTotalDis2.Text != null)
            {
                decimal totaldis = 0;
                totaldis = Decimal.Parse(String.Format("{0:N}", decimal.Parse(txtTotalDis.Text)));
                txtTotalDis2.Text = String.Format("{0:N}", (subtotal * totaldis / 100).ToString());
                dectotaldisc = decimal.Parse(String.Format("{0:N}", txtTotalDis2.Text));
            }

            lbltotal.Text = String.Format("{0:N}", (subtotal - dectotaldisc).ToString());
        }

        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            chkVat_Checked();
        }

        private void chkVat_Checked()
        {
            if (chkVat.Checked)
            {
                lblVat.Text = 5.ToString();
                decimal totalextra = 0;
                try { totalextra = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(lblTotalExtra.Text))); } catch { }
                lblVatTotal.Text = String.Format("{0:N}", (totalextra * (vat / 100)).ToString());
                lblGrossTotal.Text = String.Format("{0:N}", ((Decimal.Parse(lblTotalExtra.Text) + ((Decimal.Parse(lblTotalExtra.Text) * ((vat / 100)))))));
            }
            else
            {
                lblVatTotal.Text = 0.ToString();
                lblVat.Text = 0.ToString();
                lblGrossTotal.Text = String.Format("{0:N}", lblTotalExtra.Text);
            }
        }

        private void lblsubtotal_TextChanged(object sender, EventArgs e)
        {
            decimal st = 0;
            try
            {
                st = decimal.Parse(lblsubtotal.Text);
                if (lblsubtotal.Text != Decimal.Parse(String.Format("{0:N}", (decimal.Parse(lblsubtotal.Text)))).ToString("G29")
                )
                { lblsubtotal.Text = String.Format("{0:N}", (decimal.Parse(lblsubtotal.Text))); }
            }
            catch { }
            decimal p = 0;
            ///////////PROBLEM OLABİLİR her seferinde indirim hesaplaması
            try { p = decimal.Parse(lblTotalDis.Text); } catch { }
            try { lbltotal.Text = String.Format("{0:N}", (st - (st * (p / 100))).ToString()); } catch { }
        }

        private void lbltotal_TextChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            try
            {
                total = decimal.Parse(lbltotal.Text);
                if (lbltotal.Text != Decimal.Parse(String.Format("{0:N}", (decimal.Parse(lbltotal.Text)))).ToString("G29")
                )
                {
                    lbltotal.Text = String.Format("{0:N}", (decimal.Parse(lbltotal.Text)));
                }
            }
            catch { }
            decimal extrachange = 0;
            try { extrachange = decimal.Parse(txtExtraChanges.Text); } catch { }
            lblTotalExtra.Text = String.Format("{0:N}", (total + extrachange).ToString());
        }

        private void lblTotalExtra_TextChanged(object sender, EventArgs e)
        {
            if (lblTotalExtra.Text != Decimal.Parse(String.Format("{0:N}", (decimal.Parse(lblTotalExtra.Text)))).ToString("G29")
                )
            {
                lblTotalExtra.Text = String.Format("{0:N}", Decimal.Parse(String.Format("{0:N}", (decimal.Parse(lblTotalExtra.Text)))));
            }
            chkVat_Checked();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DeletedQuotationMenu.Show(dgQuotationDeleted, new Point(e.X, e.Y));
            }
        }

        private void totalDis2Change()
        {
            if (Decimal.Parse(lblsubtotal.Text) != 0 && lblsubtotal.Text != "" && lblsubtotal.Text != null)
            {
                if (txtTotalDis2.Text == "") { txtTotalDis2.Text = 0.ToString(); }
                if (CurrentDis != Decimal.Parse(txtTotalDis2.Text))
                {
                    if (CurrentDis == 0)
                    {
                        CurrentDis = Decimal.Parse(String.Format("{0:N}", txtTotalDis2.Text));
                    }
                    else
                    {
                        lbltotal.Text = String.Format("{0:N}", (Decimal.Parse(lbltotal.Text) + CurrentDis).ToString());
                        CurrentDis = Decimal.Parse(String.Format("{0:N}", txtTotalDis2.Text));
                    }
                    lbltotal.Text = String.Format("{0:N}", (Decimal.Parse(lbltotal.Text) - CurrentDis).ToString());
                    if (txtTotalDis.Text != ((CurrentDis * 100) / Decimal.Parse(lblsubtotal.Text)).ToString())
                    {
                      //txtTotalDis.Text = (Math.Round((CurrentDis * 100) / Decimal.Parse(lblsubtotal.Text), 4)).ToString();
                        txtTotalDis.Text = String.Format("{0:N}", (CurrentDis * 100) / Decimal.Parse(lblsubtotal.Text));
                        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                        {
                            if (dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value == null || dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value.ToString() == 0.ToString())
                            {
                                dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value = txtTotalDis.Text;
                            }
                        }
                    }
                }
            }
            else
            {
                txtTotalDis2.Text = "";
            }
        }

        private bool ControlSave()
        {
            if (txtCustomerName.Text == null || txtCustomerName.Text == String.Empty) { MessageBox.Show("Please Enter a Customer"); return false; }
            for (int i = 0; i < dgQuotationAddedItems.RowCount - 1; i++)
            {
                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value.ToString()) && Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value.ToString()) < Utils.getCurrentUser().MinMarge) { MessageBox.Show("Please Check Margin of Products "); return false; }
                if (txtTotalMargin.Text == null || txtTotalMargin.Text == "") { txtTotalMargin.Text = "0"; }
                if (Utils.getCurrentUser().MinMarge > decimal.Parse(txtTotalMargin.Text))
                {
                    MessageBox.Show("You are not able to give this Total Margin. Please check the Total Margin");
                    return false;
                }
            }
            for (int i = 0; i < dgQuotationAddedItems.RowCount-1; i++)
            {
                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgProductCode.Index].Value.ToString()) && ((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgDelivery.Index]).Value == null && ((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgDelivery.Index]).Value.ToString() == "" && ((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index]).Value == null)
                {
                    MessageBox.Show("Delivery part cannot be left blank. Please check Delivery Parts of Items");
                    return false;
                }

                if (dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index].Value == null)
                {
                    MessageBox.Show("Status cannot be left blank. Please check Status of Items");
                    return false;
                }
            }
            if (dgQuotationAddedItems.Rows.Count == 0)
            {
                MessageBox.Show("Product Code empty");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool SaveOK = false;
            SaveOK = ControlSave();
            IMEEntities IME = new IMEEntities();

            if (SaveOK)
            {
                if (label67.Text == "Save Modification")
                {
                    DialogResult result = MessageBox.Show("Are you sure ?", "Modify Quotation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        #region QuotationUpdate

                        string QuotationNo = txtQuotationNo.Text;

                        Quotation q = IME.Quotations.Where(quo => quo.QuotationNo == QuotationNo).FirstOrDefault();

                        q.status = QuoStatusActive;
                        q.RFQNo = txtRFQNo.Text;
                        try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
                        try { q.GrossTotal = decimal.Parse(lblGrossTotal.Text); } catch { }
                        if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
                        if (ckItemCost.Checked) { q.IsItemCost = 1; } else { q.IsItemCost = 0; }
                        if (ckWeightCost.Checked) { q.IsWeightCost = 1; } else { q.IsWeightCost = 0; }
                        q.CurrencyID = (decimal)cbCurrency.SelectedValue;
                        if (ckCustomsDuties.Checked) { q.IsCustomsDuties = 1; } else { q.IsCustomsDuties = 0; }
                        q.ShippingMethodID = cbSMethod.SelectedIndex;

                        try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
                        try { q.DiscOnSubTotal = decimal.Parse(txtTotalDis.Text); } catch { }
                        try { q.ExtraCharges = decimal.Parse(txtExtraChanges.Text); } catch { }
                        if (chkVat.Checked)
                        {
                            q.IsVatValue = 1;
                            try { q.VatValue = vat; } catch { }

                        }
                        else
                        {
                            q.IsVatValue = 0;
                        }
                        try { q.StartDate = (DateTime)dtpDate.Value; } catch { }
                        try { q.Factor = Decimal.Parse(lblCustomerFactorValue.Text); } catch { }
                        try { q.Markup = Decimal.Parse(lblCustomerMarkupValue.Text); } catch { }
                        try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
                        q.PaymentID = (cbPayment.SelectedItem as PaymentTerm).ID;
                        q.CurrName = (cbCurrency.SelectedItem as Currency).currencyName;
                        //q.CurrType = cbCurrType.Text;
                        q.Curr = CurrValue;
                        try { q.RepresentativeID = (cbRep.SelectedItem as Worker).WorkerID; ; } catch { }
                        //try { q.RepresentativeID2 = (cbWorkers.SelectedItem as Worker).WorkerID; ; } catch { }
                        q.CustomerID = CustomerCode.Text;
                        q.ShippingMethodID = cbSMethod.SelectedIndex;
                        q.MainContactName = cbWorkers.Text;
                        q.TotalMargin = Convert.ToDecimal(txtTotalMargin.Text);
                        if (cbWorkers.SelectedValue != null)
                        {
                            q.QuotationMainContact = (int)cbWorkers.SelectedValue;
                        }
                        else
                        {
                            q.QuotationMainContact = null;
                        }
                        q.ExchangeRateID = curr.exchangeRateID;
                        int Note2 = 0;
                        int Note1 = 0;
                        if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
                        {
                            Note n = new Note();
                            n.Note_name = txtNoteForUs.Text;
                            IME.Notes.Add(n);
                            IME.SaveChanges();
                            Note1 = n.ID;
                        }
                        if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
                        {
                            Note n1 = new Note();
                            n1.Note_name = txtNoteForCustomer.Text;
                            IME.Notes.Add(n1);
                            IME.SaveChanges();
                            Note2 = n1.ID;
                        }
                        if (chkbForFinance.Checked)
                        {
                            q.ForFinancelIsTrue = 1;
                        }
                        q.FirstNote = txtNoteForCustomer.Text;
                        q.DistributeDiscount = cbDeliverDiscount.Checked;
                        q.TotalWeight = Convert.ToDecimal(lblTotalWeight.Text);
                        q.TotalNetWeight = Convert.ToDecimal(lblTotalNetWeight.Text);
                        if (chkFirstUPIME.Checked)
                        {
                            q.FirstColumn = true;
                        }
                        else
                        {
                            q.FirstColumn = false;
                        }
                        if (chkCustomerMarkup.Checked)
                        {
                            q.MarkupColumn = true;
                        }
                        else
                        {
                            q.MarkupColumn = false;
                        }
                        IME.SaveChanges();

                        #endregion

                        #region QuotationDetailUpdate

                        string quotationNo = "";
                        quotationNo = txtQuotationNo.Text;
                        IME.QuotationDetails.RemoveRange(IME.QuotationDetails.Where(a => a.QuotationNo == quotationNo));
                        IME.SaveChanges();

                        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                        {
                            if (dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                            {

                                QuotationDetail qd = new QuotationDetail();
                                qd.QuotationNo = txtQuotationNo.Text;

                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value?.ToString())) qd.dgNo = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString());
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgDesc"].Value?.ToString())) qd.ItemDescription = dgQuotationAddedItems.Rows[i].Cells["dgDesc"].Value.ToString();
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value?.ToString()))
                                    qd.ItemCode = dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString();
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value?.ToString()))
                                    qd.Qty = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value?.ToString()))
                                    qd.UCUPCurr = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()), 2);
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].Value?.ToString()))
                                    qd.PacketUP = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].Value.ToString());
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value?.ToString()))
                                    qd.UPIME = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()), 2);
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Value?.ToString()))
                                    qd.FirstUPIME = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgFirstUPIME"].Value.ToString()), 2);
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value?.ToString()))
                                    qd.Disc = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value.ToString()),2);
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString()))
                                    qd.Total = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString()), 2);
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value?.ToString()))
                                    qd.TargetUP = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value.ToString());
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value?.ToString()))
                                    qd.Competitor = dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value.ToString();
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value?.ToString()))
                                    qd.CustomerDesc = dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value.ToString();
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value?.ToString()))
                                    qd.CustomerStockCode = dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value.ToString();
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value?.ToString()))
                                    qd.CustomerName = txtCustomerName.Text;
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value?.ToString()))
                                    qd.UC = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value.ToString());
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgSSM"].Value?.ToString()))
                                    qd.SSM = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgSSM"].Value.ToString());
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value?.ToString()))
                                    try{ qd.UnitWeight = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value?.ToString()); } catch { }
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgUnitNetWeight.Index].Value?.ToString()))
                                    try { qd.UnitNetWeight = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUnitNetWeight.Index].Value?.ToString()); } catch { }
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value?.ToString()))
                                    qd.Marge = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value.ToString());
                                //if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgDependantTable"].Value?.ToString()))
                                //    qd.DependantTable = dgQuotationAddedItems.Rows[i].Cells["dgDependantTable"].Value?.ToString();
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgCost.Index].Value.ToString()))
                                    qd.Cost = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgCost.Index].Value?.ToString());
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgLandingCost.Index].Value?.ToString()))
                                    qd.LandingCost = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString());
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgMPN.Index].Value.ToString()))
                                    qd.MPN = dgQuotationAddedItems.Rows[i].Cells[dgMPN.Index].Value.ToString();
                                if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgUKPrice.Index].Value.ToString()))
                                    qd.UKPrice = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUKPrice"].Value.ToString()), 2);

                                if (dgQuotationAddedItems.Rows[i].Cells["dgUOM"].Value?.ToString() == "")
                                {
                                    if (qd.UC == 1 && qd.SSM == 1)
                                    {
                                        qd.UnitOfMeasure = "EACH";
                                    }
                                    else
                                    {
                                        qd.UnitOfMeasure = "PACKET OF";
                                    }
                                }
                                else
                                {
                                    qd.UnitOfMeasure = dgQuotationAddedItems.Rows[i].Cells["dgUOM"].Value.ToString();
                                }

                                qd.quotationDeliveryID = (int)((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgDelivery.Index]).Value;
                                qd.DubaiStatus = ((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index]).Value.ToString();
                                qd.Manufacturer = dgQuotationAddedItems.Rows[i].Cells[dgBrand.Index].Value.ToString();
                                qd.SupplierName = dgQuotationAddedItems.Rows[i].Cells[dgSupplier.Index].Value.ToString();
                                if (qd.ItemCode.Contains("P") || qd.ItemCode.Count() == 10)
                                {
                                    qd.Status = "NCNR";
                                }
                                else if (dgQuotationAddedItems.Rows[i].Cells[dgHZ.Index].Value != null && dgQuotationAddedItems.Rows[i].Cells[dgHZ.Index].Value.ToString() != "")
                                {
                                    qd.Status = "HS";
                                }
                                else
                                {
                                    qd.Status = "";
                                }
                                qd.ReportIME = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString()), 2);
                                IME.QuotationDetails.Add(qd);
                                IME.SaveChanges();

                            }
                        }

                        MessageBox.Show("Quotation is successfully modified.", "Success!");
                        #endregion

                        //parent.BringQuotationList();
                        
                        q.ViewQuotation = true;
                        q.ViewQuotationName = null;
                        IME.SaveChanges();
                        this.Close();
                    }
                }
                else if (label67.Text == "Create Rev.")
                {
                    modifyMod = false;
                    QuotationSave();
                    QuotationDetailsSave();

                    Quotation quo = IME.Quotations.Where(q => q.QuotationNo == txtQuotationNo.Text).FirstOrDefault();
                    quo.ViewQuotation = true;
                    quo.ViewQuotationName = null;
                    IME.SaveChanges();

                    this.Close();
                }
                else
                {
                    modifyMod = false;
                    QuotationSave();
                    QuotationDetailsSave();

                    Quotation quo = IME.Quotations.Where(q => q.QuotationNo == txtQuotationNo.Text).FirstOrDefault();
                    quo.ViewQuotation = true;
                    quo.ViewQuotationName = null;
                    IME.SaveChanges();

                    this.Close();
                }
            }

        }

        private void QuotationSave()
        {
            if (modifyMod)
            {
                #region UpdateQuotation
                //Update Quotation

                string quoNo = txtQuotationNo.Text;

                //DataSet.Quotation q = IME.Quotations.Where(a => a.QuotationNo == quoNo).FirstOrDefault();

                IMEEntities IME = new IMEEntities();
                Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(quoNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
                if (txtQuotationNo.Text.Contains("v"))
                {
                    int quoID = Int32.Parse(txtQuotationNo.Text.Substring(txtQuotationNo.Text.LastIndexOf('v') + 1));
                    txtQuotationNo.Text = (txtQuotationNo.Text.Substring(0, txtQuotationNo.Text.IndexOf('v') + 1) + quoID).ToString();
                }
                else
                {
                    txtQuotationNo.Text = q1.QuotationNo + "v1";
                }
                Quotation q = new Quotation();
                q.status = QuoStatusActive;
                q.RFQNo = txtRFQNo.Text;
                try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
                try { q.GrossTotal = decimal.Parse(lblGrossTotal.Text); } catch { }
                if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
                if (ckItemCost.Checked) { q.IsItemCost = 1; } else { q.IsItemCost = 0; }
                if (ckWeightCost.Checked) { q.IsWeightCost = 1; } else { q.IsWeightCost = 0; }
                q.CurrencyID = (decimal)cbCurrency.SelectedValue;
                if (ckCustomsDuties.Checked) { q.IsCustomsDuties = 1; } else { q.IsCustomsDuties = 0; }
                q.ShippingMethodID = cbSMethod.SelectedIndex;

                try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
                try { q.DiscOnSubTotal = decimal.Parse(txtTotalDis.Text); } catch { }
                try { q.ExtraCharges = decimal.Parse(txtExtraChanges.Text); } catch { }
                if (chkVat.Checked)
                {
                    q.IsVatValue = 1;
                    try { q.VatValue = vat; } catch { }

                }
                else
                {
                    q.IsVatValue = 0;
                }
                try { q.StartDate = (DateTime)dtpDate.Value; } catch { }
                try { q.Factor = Decimal.Parse(lblCustomerFactorValue.Text); } catch { }
                try { q.Markup = Decimal.Parse(lblCustomerMarkupValue.Text); } catch { }
                try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
                q.PaymentID = (cbPayment.SelectedItem as PaymentTerm).ID;
                q.CurrName = (cbCurrency.SelectedItem as Currency).currencyName;
                //q.CurrType = cbCurrType.Text;
                q.Curr = CurrValue;
                try { q.RepresentativeID = (cbRep.SelectedItem as Worker).WorkerID; ; } catch { }
                //try { q.RepresentativeID2 = (cbWorkers.SelectedItem as Worker).WorkerID; ; } catch { }
                q.CustomerID = CustomerCode.Text;
                q.ShippingMethodID = cbSMethod.SelectedIndex;
                q.MainContactName = cbWorkers.Text;
                q.TotalMargin = Convert.ToDecimal(txtTotalMargin.Text);
                if (cbWorkers.SelectedValue != null)
                {
                    q.QuotationMainContact = (int)cbWorkers.SelectedValue;
                }
                q.ExchangeRateID = curr.exchangeRateID;
                int Note2 = 0;
                int Note1 = 0;
                if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
                {
                    Note n = new Note();
                    n.Note_name = txtNoteForUs.Text;
                    IME.Notes.Add(n);
                    IME.SaveChanges();
                    Note1 = n.ID;
                }
                if (txtNoteForCustomer.Text != null || txtNoteForCustomer.Text != "")
                {
                    Note n1 = new Note();
                    n1.Note_name = txtNoteForCustomer.Text;
                    IME.Notes.Add(n1);
                    IME.SaveChanges();
                    Note2 = n1.ID;
                }
                if (chkbForFinance.Checked)
                {
                    q.ForFinancelIsTrue = 1;
                }
                q.FirstNote = txtNoteForCustomer.Text;
                q.DistributeDiscount = cbDeliverDiscount.Checked;
                q.TotalWeight = Convert.ToDecimal(lblTotalWeight.Text); 
                q.TotalNetWeight = Convert.ToDecimal(lblTotalNetWeight.Text);
                if (chkFirstUPIME.Checked)
                {
                    q.FirstColumn = true;
                }
                else
                {
                    q.FirstColumn = false;
                }
                if (chkCustomerMarkup.Checked)
                {
                    q.MarkupColumn = true;
                }
                else
                {
                    q.MarkupColumn = false;
                }
                IME.SaveChanges();
                #endregion
            }
            else
            {
                #region  New Quotation
                DataSet.Quotation q = new DataSet.Quotation();
                q.status = QuoStatusActive;

                //if (IME.Quotations.Where(a => a.QuotationNo == txtQuotationNo.Text).FirstOrDefault() != null)
                //{
                //    txtQuotationNo.Text = CreateQuotationID(QuotationIdMod.New, null);
                //}
                q.QuotationNo = txtQuotationNo.Text;
                q.RFQNo = txtRFQNo.Text;
                try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
                try { q.GrossTotal = decimal.Parse(lblGrossTotal.Text); } catch { }
                if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
                if (ckItemCost.Checked) { q.IsItemCost = 1; } else { q.IsItemCost = 0; }
                if (ckWeightCost.Checked) { q.IsWeightCost = 1; } else { q.IsWeightCost = 0; }
                q.CurrencyID = (decimal)cbCurrency.SelectedValue;
                if (ckCustomsDuties.Checked) { q.IsCustomsDuties = 1; } else { q.IsCustomsDuties = 0; }
                q.ShippingMethodID = cbSMethod.SelectedIndex;

                try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
                try { q.DiscOnSubTotal = decimal.Parse(txtTotalDis.Text); } catch { }
                try { q.ExtraCharges = decimal.Parse(txtExtraChanges.Text); } catch { }
                if (chkVat.Checked)
                {
                    q.IsVatValue = 1;
                    try { q.VatValue = vat; } catch { }

                }
                else
                {
                    q.IsVatValue = 0;
                }
                try { q.StartDate = (DateTime)dtpDate.Value; } catch { }
                try { q.Factor = Decimal.Parse(lblCustomerFactorValue.Text); } catch { }
                try { q.Markup = Decimal.Parse(lblCustomerMarkupValue.Text); } catch { }
                try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
                try { q.RepresentativeID = (cbRep.SelectedItem as Worker).WorkerID; ; } catch { }
                //try { q.RepresentativeID2 = (cbWorkers.SelectedItem as Worker).WorkerID; ; } catch { }
                q.PaymentID = (cbPayment.SelectedItem as PaymentTerm).ID;
                q.CurrName = (cbCurrency.SelectedItem as Currency).currencyName;
                //q.CurrType = cbCurrType.Text;
                q.Curr = CurrValue;
                q.CustomerID = CustomerCode.Text;
                q.ShippingMethodID = cbSMethod.SelectedIndex;
                q.MainContactName = cbWorkers.Text;
                q.TotalMargin= Convert.ToDecimal(txtTotalMargin.Text);
                if (cbWorkers.SelectedValue != null)
                {
                    q.QuotationMainContact = (int)cbWorkers.SelectedValue;
                }

                int Note2 = 0;
                int Note1 = 0;
                if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
                {
                    Note n = new Note();
                    n.Note_name = txtNoteForUs.Text;
                    IME.Notes.Add(n);
                    IME.SaveChanges();
                    Note1 = n.ID;
                }
                if (txtNoteForCustomer.Text != null || txtNoteForCustomer.Text != "")
                {
                    Note n1 = new Note();
                    n1.Note_name = txtNoteForCustomer.Text;
                    IME.Notes.Add(n1);
                    IME.SaveChanges();
                    Note2 = n1.ID;
                }
                if (chkbForFinance.Checked)
                {
                    q.ForFinancelIsTrue = 1;
                }
                if (Note1 != 0) q.NoteForUsID = Note1;
                if (Note2 != 0) q.NoteForCustomerID = Note2;
                q.ExchangeRateID = curr.exchangeRateID;
               // q.idNo = Convert.ToInt32(txtQuotationNo.Text.Substring(5));

                string[] idParts = IDShredder(txtQuotationNo.Text);
                q.idYear = Convert.ToInt32(idParts[0]);
                q.idNo = Convert.ToInt32(idParts[2]);

                if (idParts[3] == null)
                {
                    q.idVersion = 0;
                }
                else
                {
                    q.idVersion = Convert.ToInt32(idParts[4]);
                }
                q.FirstNote = txtNoteForCustomer.Text;
                q.DistributeDiscount = cbDeliverDiscount.Checked;
                q.TotalWeight = Convert.ToDecimal(lblTotalWeight.Text);
                q.TotalNetWeight = Convert.ToDecimal(lblTotalNetWeight.Text);
                if (chkFirstUPIME.Checked)
                {
                    q.FirstColumn = true;
                }
                else
                {
                    q.FirstColumn = false;
                }
                if (chkCustomerMarkup.Checked)
                {
                    q.MarkupColumn = true;
                }
                else
                {
                    q.MarkupColumn = false;
                }
                IME.Quotations.Add(q);
                IME.SaveChanges();
                Utils.LogKayit("Quotation", "Quotation added");
                #endregion

            }
        }

        private void QuotationSave(string QuoNo)
        {
            IMEEntities IME = new IMEEntities();
            //Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(QuoNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
            //if (!txtQuotationNo.Text.Contains("v"))
            //{
            //    txtQuotationNo.Text = q1.QuotationNo + "v1";
            //}
            Quotation q = new Quotation();
            q.status = QuoStatusActive;
            q.QuotationNo = txtQuotationNo.Text;
            q.RFQNo = txtRFQNo.Text;
            try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
            try { q.GrossTotal = decimal.Parse(lblGrossTotal.Text); } catch { }
            if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
            if (ckItemCost.Checked) { q.IsItemCost = 1; } else { q.IsItemCost = 0; }
            if (ckWeightCost.Checked) { q.IsWeightCost = 1; } else { q.IsWeightCost = 0; }
            q.CurrencyID = (decimal)cbCurrency.SelectedValue;
            if (ckCustomsDuties.Checked) { q.IsCustomsDuties = 1; } else { q.IsCustomsDuties = 0; }
            q.ShippingMethodID = cbSMethod.SelectedIndex;

            try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
            try { q.DiscOnSubTotal = decimal.Parse(txtTotalDis.Text); } catch { }
            try { q.ExtraCharges = decimal.Parse(txtExtraChanges.Text); } catch { }
            if (chkVat.Checked)
            {
                q.IsVatValue = 1;
                try { q.VatValue = vat; } catch { }

            }
            else
            {
                q.IsVatValue = 0;
            }
            try { q.StartDate = (DateTime)dtpDate.Value; } catch { }
            try { q.Factor = Decimal.Parse(lblCustomerFactorValue.Text); } catch { }
            try { q.Markup = Decimal.Parse(lblCustomerMarkupValue.Text); } catch { }
            try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
            try { q.RepresentativeID = (cbRep.SelectedItem as Worker).WorkerID; ; } catch { }
            //try { q.RepresentativeID2 = (cbWorkers.SelectedItem as Worker).WorkerID; ; } catch { }
            q.PaymentID = (cbPayment.SelectedItem as PaymentTerm).ID;
            q.CurrName = (cbCurrency.SelectedItem as Currency).currencyName;
            q.Curr = CurrValue;
            q.CustomerID = CustomerCode.Text;
            q.ShippingMethodID = cbSMethod.SelectedIndex;
            q.MainContactName = cbWorkers.Text;

            if (cbWorkers.SelectedValue != null)
            {
                q.QuotationMainContact = (int)cbWorkers.SelectedValue;
            }
            int Note2 = 0;
            int Note1 = 0;
            if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
            {
                Note n = new Note();
                n.Note_name = txtNoteForUs.Text;
                IME.Notes.Add(n);
                IME.SaveChanges();
                Note1 = n.ID;
            }
            if (txtNoteForCustomer.Text != null || txtNoteForCustomer.Text != "")
            {
                Note n1 = new Note();
                n1.Note_name = txtNoteForCustomer.Text;
                IME.Notes.Add(n1);
                IME.SaveChanges();
                Note2 = n1.ID;
            }
            if (chkbForFinance.Checked)
            {
                q.ForFinancelIsTrue = 1;
            }
            if (Note1 != 0) q.NoteForUsID = Note1;
            if (Note2 != 0) q.NoteForCustomerID = Note2;
            q.ExchangeRateID = curr.exchangeRateID;

            string[] idParts = IDShredder(txtQuotationNo.Text);
            q.idYear = Convert.ToInt32(idParts[0]);
            q.idNo = Convert.ToInt32(idParts[2]);
            q.idVersion = Convert.ToInt32(idParts[4]);
            q.DistributeDiscount = cbDeliverDiscount.Checked;
            if (chkFirstUPIME.Checked)
            {
                q.FirstColumn = true;
            }
            else
            {
                q.FirstColumn = false;
            }
            if (chkCustomerMarkup.Checked)
            {
                q.MarkupColumn = true;
            }
            else
            {
                q.MarkupColumn = false;
            }
            IME.Quotations.Add(q);
            IME.SaveChanges();
        }

        private void QuotationDetailsSave()
        {
            IMEEntities IME = new IMEEntities();
            string quotationNo = "";
            quotationNo = txtQuotationNo.Text;
            if (modifyMod)
            {

                if (quotationNo.Contains('v'))
                {
                    quotationNo = quotationNo.Substring(0, quotationNo.IndexOf('v')) + 'v' + (Int32.Parse(quotationNo.Substring(quotationNo.IndexOf('v') + 1)) - 1).ToString();
                }
                //quoNo = quoNo + "v1";
                IME.QuotationDetails.RemoveRange(IME.QuotationDetails.Where(a => a.QuotationNo == quotationNo));
                IME.SaveChanges();


            }
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                if (dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                {

                    QuotationDetail qd = new QuotationDetail();
                    qd.QuotationNo = quotationNo;

                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgNo"].Value?.ToString())) qd.dgNo = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgNo"].Value?.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgDesc"].Value?.ToString())) qd.ItemDescription = dgQuotationAddedItems.Rows[i].Cells["dgDesc"].Value.ToString();
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value?.ToString()))
                        qd.ItemCode = dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString();
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value?.ToString()))
                        qd.Qty = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value?.ToString()))
                        qd.UCUPCurr = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].Value?.ToString()))
                        qd.PacketUP = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value?.ToString()))
                        qd.UPIME = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Value?.ToString()))
                        qd.FirstUPIME = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value?.ToString()))
                        qd.Disc = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value.ToString()), 2);
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString()))
                        qd.Total = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value?.ToString()))
                        qd.TargetUP = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value?.ToString()))
                        qd.Competitor = dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value.ToString();
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value?.ToString()))
                        qd.CustomerDesc = dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value.ToString();
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value?.ToString()))
                        qd.CustomerStockCode = dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value.ToString();
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value?.ToString()))
                        qd.CustomerName = txtCustomerName.Text;
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value?.ToString()))
                        qd.UC = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgSSM"].Value?.ToString()))
                        qd.SSM = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgSSM"].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value?.ToString()))
                        qd.UnitWeight = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgUnitNetWeight.Index].Value?.ToString()))
                        try { qd.UnitNetWeight = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUnitNetWeight.Index].Value?.ToString()); } catch { }
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value?.ToString()))
                        qd.Marge = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value.ToString());
                    //if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgDependantTable"].Value?.ToString()))
                    //    qd.DependantTable = dgQuotationAddedItems.Rows[i].Cells["dgDependantTable"].Value?.ToString();
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgCost.Index].Value.ToString()))
                        qd.Cost = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgCost.Index].Value?.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgLandingCost.Index].Value?.ToString()))
                        qd.LandingCost = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString());
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgMPN.Index].Value.ToString()))
                        qd.MPN = dgQuotationAddedItems.Rows[i].Cells[dgMPN.Index].Value.ToString();
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgUKPrice.Index].Value.ToString()))
                        qd.UKPrice = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUKPrice.Index].Value.ToString());


                    if (dgQuotationAddedItems.Rows[i].Cells["dgUOM"].Value?.ToString() == "")
                    {
                        if (qd.UC == 1 && qd.SSM == 1)
                        {
                            qd.UnitOfMeasure = "EACH";
                        }
                        else
                        {
                            qd.UnitOfMeasure = "PACKET OF";
                        }
                    }
                    else
                    {
                        qd.UnitOfMeasure = dgQuotationAddedItems.Rows[i].Cells["dgUOM"].Value.ToString();
                    }

                    qd.quotationDeliveryID = (int)((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgDelivery.Index]).Value;
                    qd.DubaiStatus = ((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index]).Value.ToString();
                    qd.Manufacturer = dgQuotationAddedItems.Rows[i].Cells[dgBrand.Index].Value.ToString();
                    qd.SupplierName = dgQuotationAddedItems.Rows[i].Cells[dgSupplier.Index].Value.ToString();
                    if (qd.ItemCode.Contains("P") || qd.ItemCode.Count() == 10)
                    {
                        qd.Status = "NCNR";
                    }
                    else if (dgQuotationAddedItems.Rows[i].Cells[dgHZ.Index].Value != null && dgQuotationAddedItems.Rows[i].Cells[dgHZ.Index].Value.ToString() != "")
                    {
                        qd.Status = "HS";
                    }
                    else
                    {
                        qd.Status = "";
                    }
                    qd.ReportIME = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString()), 2);
                    try
                    {
                        IME.QuotationDetails.Add(qd);
                        IME.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                }
            }
            if (!modifyMod)
            {
                MessageBox.Show("Quotation is successfully added", "Success");
            }
            else
            {
                MessageBox.Show("Quotation is successfully edited", "Success");
            }
        }
        private void QuotationDetailsSaveRevision()
        {
            IMEEntities IME = new IMEEntities();
            string quotationNo = "";
            quotationNo = txtQuotationNo.Text;


            if (!quotationNo.Contains('v'))
            {
                txtQuotationNo.Text = quotationNo + "v1";

            }
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                if (dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                {

                    QuotationDetail qd = new QuotationDetail();
                    qd.QuotationNo = txtQuotationNo.Text;
                    if (dgQuotationAddedItems.Rows[i].Cells["dgNo"].Value != null) qd.dgNo = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgNo"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgDesc"].Value != null) qd.ItemDescription = dgQuotationAddedItems.Rows[i].Cells["dgDesc"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value != null) qd.ItemCode = dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null) qd.Qty = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUOM"].Value != null) qd.UnitOfMeasure = dgQuotationAddedItems.Rows[i].Cells["dgUOM"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value != null) qd.UCUPCurr = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].Value != null) qd.PacketUP = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgPacketUP.Index].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value != null) qd.UPIME = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Value != null) qd.FirstUPIME = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value != null && dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value.ToString() != "") qd.Disc = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value.ToString()), 2);
                    if (dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value != null) qd.Total = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value != null && dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value.ToString() != "") qd.TargetUP = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value != null) qd.Competitor = dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value != null) qd.CustomerDesc = dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value != null) qd.CustomerStockCode = dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value != null) qd.UC = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgSSM"].Value != null) qd.SSM = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgSSM"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value.ToString() != "") qd.UnitWeight = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells[dgUnitNetWeight.Index].Value.ToString() != "") qd.UnitNetWeight = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUnitNetWeight.Index].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value != null) qd.Marge = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value.ToString());
                    //if (dgQuotationAddedItems.Rows[i].Cells["dgDependantTable"].Value != null) qd.DependantTable = dgQuotationAddedItems.Rows[i].Cells["dgDependantTable"].Value.ToString();
                    if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells[dgUKPrice.Index].Value.ToString()))
                        qd.UKPrice = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUKPrice.Index].Value.ToString());

                    qd.quotationDeliveryID = (int)((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgDelivery.Index]).Value;
                    qd.DubaiStatus = ((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index]).Value.ToString();
                    qd.SupplierName = dgQuotationAddedItems.Rows[i].Cells[dgSupplier.Index].Value.ToString();

                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
                }

            }
            for (int i = 0; i < dgQuotationDeleted.RowCount; i++)
            {
                if (dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value != null)
                {
                    QuotationDetail qd = new QuotationDetail();

                    if (dgQuotationDeleted.Rows[i].Cells["No1"].Value != null) qd.dgNo = decimal.Parse(dgQuotationDeleted.Rows[i].Cells["No1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgDesc1"].Value != null) qd.ItemDescription = dgQuotationDeleted.Rows[i].Cells["dgDesc1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value != null) qd.ItemCode = dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgQty1"].Value != null) qd.Qty = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["dgQty1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgUCUPCurr1"].Value != null) qd.UCUPCurr = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgUCUPCurr1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgUOM1"].Value != null) qd.UnitOfMeasure = dgQuotationDeleted.Rows[i].Cells["dgUOM1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgDisc1"].Value != null) qd.Disc = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgDisc1"].Value.ToString()), 2);
                    if (dgQuotationDeleted.Rows[i].Cells["dgUPIME1"].Value != null) qd.UCUPCurr = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgUPIME1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgTotal1"].Value != null) qd.Total = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgTotal1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgTargetUP1"].Value != null) qd.TargetUP = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgTargetUP1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgCompetitor1"].Value != null) qd.Competitor = dgQuotationDeleted.Rows[i].Cells["dgCompetitor1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgCustDescription1"].Value != null) qd.CustomerDesc = dgQuotationDeleted.Rows[i].Cells["dgCustDescription1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value != null) qd.CustomerStockCode = dgQuotationDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgSSM1"].Value != null) qd.SSM = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["dgSSM1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgUC1"].Value != null) qd.UC = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["dgUC1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgUnitWeigt1"].Value != null) qd.UnitWeight = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgUnitWeigt1"].Value.ToString());

                    qd.IsDeleted = 1;
                    qd.ReportIME = Math.Round(Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString()), 2);
                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
                }
            }
            if (!modifyMod)
            {
                MessageBox.Show("Quotation is successfully added", "Success");
                Utils.LogKayit("Quotation", "Quotation Create Version added");
            }
            else
            {
                MessageBox.Show("Quotation is successfully edited", "Success");
                Utils.LogKayit("Quotation", "Quotation Create Version modify");
            }
            this.Close();
        }

        private void modifyQuotation(Quotation q)
        {
            #region QuotationLoader
            LandingCost.Enabled = true;

            if (importFromQuotation == 0)
            {
                /*txtQuotationNo.Text = q.QuotationNo;*//*CreateRevision 1,View 1*/
                if (this.Text == "Copy Quotation")
                {
                    txtQuotationNo.Text = CreateQuotationID(QuotationIdMod.New, q);
                }
                else if (this.Text == "Edit Quotation")
                {
                    txtQuotationNo.Text = CreateQuotationID(QuotationIdMod.CreateVersion, q);
                }
               
                txtRFQNo.Text = q.RFQNo;
                CustomerCode.Text = q.Customer.ID;
                txtCustomerName.Text = q.Customer.c_name;
                lblCustomerFactorValue.Text = q.Factor.ToString();
                lblCustomerDiscountValue.Text = q.Customer.discountrate.ToString();
                lblCustomerMarkupValue.Text = q.Markup.ToString();
                cbFactor.Text = Utils.getManagement().Factor.ToString();
                if (q.QuotationMainContact != null)
                {
                    cbWorkers.SelectedValue = (int)q.QuotationMainContact;
                }
                else
                {
                    cbWorkers.Text = q.MainContactName;
                }
                if (q.NoteForCustomerID != null) txtNoteForCustomer.Text = IME.Notes.Where(a => a.ID == q.NoteForCustomerID).FirstOrDefault().Note_name;
                if (q.NoteForCustomerID != null) txtNoteForUs.Text = IME.Notes.Where(a => a.ID == q.NoteForUsID).FirstOrDefault().Note_name;
                fillCustomer();
            }
            else if (importFromQuotation == 1)
            {
                txtRFQNo.Text = q.RFQNo;
                CustomerCode.Text = q.Customer.ID;
                txtCustomerName.Text = q.Customer.c_name;
                lblCustomerFactorValue.Text = q.Factor.ToString();
                lblCustomerDiscountValue.Text = q.Customer.discountrate.ToString();
                lblCustomerMarkupValue.Text = q.Markup.ToString();
                txtQuotationNo.Text = q.QuotationNo;
                if (this.Text == "View Quotation")
                {
                    cbFactor.Text = q.Factor.ToString();
                }
                else
                {
                    cbFactor.Text = Utils.getManagement().Factor.ToString();
                }
                fillCustomer();
            }
            if (q.ForFinancelIsTrue == 1) { chkbForFinance.Checked = true; }
            #region QuotationDetails
            var QuoCurr = IME.Currencies.Where(a => a.currencyName == q.CurrName).FirstOrDefault();
            if (QuoCurr != null) cbCurrency.SelectedValue = QuoCurr.currencyID;

            foreach (var item in q.QuotationDetails)
            {
                if (item.IsDeleted == 1)
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationDeleted.Rows[0].Clone();
                    row.Cells[dgNo.Index].Value = item.dgNo;
                    row.Cells[dgProductCode1.Index].Value = item.ItemCode;
                    row.Cells[dgQty1.Index].Value = item.Qty;
                    row.Cells[dgSSM1.Index].Value = item.SSM;
                    row.Cells[dgUC1.Index].Value = item.UC;
                    row.Cells[dgUPIME1.Index].Value = item.UPIME;
                    row.Cells[dgUCUPCurr1.Index].Value = item.UCUPCurr;
                    row.Cells[dgDisc1.Index].Value = item.Disc;
                    row.Cells[dgDelivery1.Index].Value = item.quotationDeliveryID;
                    row.Cells[dgTotal1.Index].Value = item.Total;
                    row.Cells[dgTargetUP1.Index].Value = item.TargetUP;
                    row.Cells[dgCompetitor1.Index].Value = item.Competitor;
                    //row.Cells[dgUKPrice1.Index].Value = item.UKPrice;
                    row.Cells[dgUnitWeigt1.Index].Value = item.UnitWeight;
                    row.Cells[dgTotalWeight.Index].Value = item.UnitWeight * item.Qty;
                    row.Cells[dgUnitTotalNetWeight.Index].Value = item.UnitWeight * item.Qty;
                    row.Cells[dgUnitNetWeight.Index].Value = item.UnitNetWeight;
                    row.Cells[dgUnitTotalNetWeight.Index].Value = item.UnitNetWeight * item.Qty;
                    row.Cells[dgCustomerStokCode1.Index].Value = item.CustomerStockCode;
                    dgQuotationDeleted.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                    row.CreateCells(dgQuotationAddedItems);
                    row.Cells[dgNo.Index].Value = /*Decimal.Parse(item.dgNo.ToString())*/item.dgNo;
                    row.Cells[dgProductCode.Index].Value = item.ItemCode;
                    row.Cells[dgQty.Index].Value = item.Qty;
                    row.Cells[dgSSM.Index].Value = item.SSM;
                    row.Cells[dgUC.Index].Value = item.UC;
                    row.Cells[dgUPIME.Index].Value = Math.Round((decimal)item.UPIME, 2);
                    row.Cells[dgFirstUPIME.Index].Value = Math.Round((decimal)item.FirstUPIME, 2);
                    row.Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                    row.Cells[dgPacketUP.Index].Value = item.PacketUP;
                    row.Cells[dgDisc.Index].Value = item.Disc;
                    row.Cells[dgDelivery.Index].Value = item.quotationDeliveryID;
                    row.Cells[dgStatus.Index].Value = item.DubaiStatus;
                    row.Cells[dgTotal.Index].Value = item.Total;
                    row.Cells[dgTargetUP.Index].Value = item.TargetUP;
                    row.Cells[dgCompetitor.Index].Value = item.Competitor;
                    row.Cells[dgUKPrice.Index].Value = item.UKPrice;
                    row.Cells[dgUnitWeigt.Index].Value = item.UnitWeight;
                    row.Cells[dgTotalWeight.Index].Value = item.UnitWeight * item.Qty;
                    row.Cells[dgUnitNetWeight.Index].Value = item.UnitNetWeight;
                    row.Cells[dgUnitTotalNetWeight.Index].Value = item.UnitNetWeight * item.Qty;
                    row.Cells[dgCustStkCode.Index].Value = item.CustomerStockCode;
                    row.Cells[dgMargin.Index].Value = item.Marge;
                    row.Cells[dgBrand.Index].Value = item.Manufacturer;
                    row.Cells[dgSupplier.Index].Value = item.SupplierName;
                    if (Convert.ToDecimal(row.Cells[dgTotalWeight.Index].Value) == 0)
                    {
                        row.Cells[WT.Index].Style.BackColor = Color.Red;
                    }
                    else if (Convert.ToDecimal(row.Cells[dgTotalWeight.Index].Value) > 5)
                    {
                        row.Cells[WT.Index].Style.BackColor = Color.Orange;
                    }
                    else
                    {
                        row.Cells[WT.Index].Style.BackColor = Color.Ivory;
                    }
                    dgQuotationAddedItems.Rows.Add(row);

                }
            }
            
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {

                GetLandingCost(i);
                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[i].Cells[dgNo.Index];
                GetQuotationQuantity(i);

            }

            if (q.DistributeDiscount == true)
            {
                cbDeliverDiscount.Checked = true;
            }

            #endregion
            //buradaki yazılanların sırası önemli sırayı değiştirmeyin
            lblsubtotal.Text = q.SubTotal.ToString();
            txtTotalDis2.Text = String.Format("{0:N}", q.DiscOnSubTotal2.ToString());
            txtTotalDis.Text = String.Format("{0:N}", q.DiscOnSubTotal.ToString());
            //if (txtTotalDis2.Text == null || txtTotalDis2.Text == "") txtTotalDis2.Text = "0";
            //decimal totaldis = Math.Round((Decimal.Parse(txtTotalDis2.Text) * 100) / decimal.Parse(lblsubtotal.Text), 4);
            //txtTotalDis.Text = totaldis.ToString();
            lbltotal.Text = (q.DistributeDiscount == false) ? (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString() : lblsubtotal.Text;
            txtExtraChanges.Text = q.ExtraCharges.ToString();
            lblVat.Text = vat.ToString();
            if (q.IsVatValue == 1) { chkVat.Checked = true; } else { chkVat.Checked = false; }
            //
            if (q.IsItemCost == 1) { ckItemCost.Checked = true; } else { ckItemCost.Checked = false; }
            if (q.IsWeightCost == 1) { ckWeightCost.Checked = true; } else { ckWeightCost.Checked = false; }
            if (q.IsCustomsDuties == 1) { ckCustomsDuties.Checked = true; } else { ckCustomsDuties.Checked = false; }
            //Buraya Curr verileri gelecek
            #endregion
            try
            {
                //if (dgQuotationAddedItems.RowCount > 1)
                //{
                //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgNo.Index].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[dgNo.Index].Value.ToString()) + 1).ToString();
                //}
                //else { dgQuotationAddedItems.Rows[0].Cells[dgNo.Index].Value = 1.ToString(); }
            }
            catch { }

            string q1 = q.QuotationNo;
            if (IME.Quotations.Where(a => a.QuotationNo == q1).ToList().Count > 0)
            {
                if (q.QuotationNo.Contains("v"))
                {
                    string quoID = q1.Substring(q.QuotationNo.LastIndexOf('/') + 1).ToString();

                    quoID = (quoID.Substring(0, quoID.IndexOf('v') + 1)).ToString();

                    string qNo = IME.Quotations.Where(a => a.QuotationNo.Contains(quoID.ToString())).OrderByDescending(b => b.QuotationNo).FirstOrDefault().QuotationNo;

                    q1 = (q.QuotationNo.Substring(0, q.QuotationNo.IndexOf('v') + 1)).ToString();

                    q1 = q1 + quoID.ToString();
                }
            }
           /* txtQuotationNo.Text = q1;*/ /*CreateRevision 2, View 2*/
            //txtQuotationNo.Text = CreateQuotationID(QuotationIdMod.CreateVersion, q);
        }


        private void modifyQuotation(Quotation q, string aa)
        {
            #region QuotationLoader
            LandingCost.Enabled = true;
            if (importFromQuotation == 0)
            {
                txtQuotationNo.Text = q.QuotationNo;/*Modify 1*/
                txtRFQNo.Text = q.RFQNo;
                CustomerCode.Text = q.Customer.ID;
                txtCustomerName.Text = q.Customer.c_name;
                lblCustomerFactorValue.Text = q.Factor.ToString();
                lblCustomerDiscountValue.Text = q.Customer.discountrate.ToString();
                lblCustomerMarkupValue.Text = q.Markup.ToString();
                cbFactor.Text = Utils.getManagement().Factor.ToString();
                if (q.QuotationMainContact != null)
                {
                    cbWorkers.SelectedValue = (int)q.QuotationMainContact;
                }
                else
                {
                    cbWorkers.Text = q.MainContactName;
                }
                if (q.NoteForCustomerID != null) txtNoteForCustomer.Text = IME.Notes.Where(a => a.ID == q.NoteForCustomerID).FirstOrDefault().Note_name;
                if (q.NoteForCustomerID != null) txtNoteForUs.Text = IME.Notes.Where(a => a.ID == q.NoteForUsID).FirstOrDefault().Note_name;
                fillCustomer();
            }
            else if (importFromQuotation == 1)
            {
                txtQuotationNo.Text = NewQuotationID();
                fillCustomer();
            }
            if (q.ForFinancelIsTrue == 1) { chkbForFinance.Checked = true; }
            #region QuotationDetails
            var QuoCurr = IME.Currencies.Where(a => a.currencyName == q.CurrName).FirstOrDefault();
            if (QuoCurr != null) cbCurrency.SelectedValue = QuoCurr.currencyID;

            foreach (var item in q.QuotationDetails)
            {
                if (item.IsDeleted == 1)
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationDeleted.Rows[0].Clone();
                    row.Cells[dgNo.Index].Value = item.dgNo;
                    row.Cells[dgProductCode1.Index].Value = item.ItemCode;
                    row.Cells[dgQty1.Index].Value = item.Qty;
                    row.Cells[dgSSM1.Index].Value = item.SSM;
                    row.Cells[dgUC1.Index].Value = item.UC;
                    row.Cells[dgUPIME1.Index].Value = item.UPIME;
                    row.Cells[dgUCUPCurr1.Index].Value = item.UCUPCurr;
                    row.Cells[dgDisc1.Index].Value = item.Disc;
                    row.Cells[dgDelivery1.Index].Value = item.quotationDeliveryID;
                    row.Cells[dgTotal1.Index].Value = item.Total;
                    row.Cells[dgTargetUP1.Index].Value = item.TargetUP;
                    row.Cells[dgCompetitor1.Index].Value = item.Competitor;
                    //row.Cells[dgUKPrice1.Index].Value = item.UKPrice;
                    row.Cells[dgUnitWeigt1.Index].Value = item.UnitWeight;
                    row.Cells[dgTotalWeight.Index].Value = item.UnitWeight * item.Qty;
                    row.Cells[dgUnitNetWeight.Index].Value = item.UnitNetWeight;
                    row.Cells[dgUnitTotalNetWeight.Index].Value = item.UnitNetWeight * item.Qty;
                    row.Cells[dgCustomerStokCode1.Index].Value = item.CustomerStockCode;
                    dgQuotationDeleted.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                    row.CreateCells(dgQuotationAddedItems);
                    row.Cells[dgNo.Index].Value = /*Decimal.Parse(item.dgNo.ToString())*/item.dgNo;
                    row.Cells[dgProductCode.Index].Value = item.ItemCode;
                    row.Cells[dgQty.Index].Value = item.Qty;
                    row.Cells[dgSSM.Index].Value = item.SSM;
                    row.Cells[dgUC.Index].Value = item.UC;
                    row.Cells[dgUPIME.Index].Value = Math.Round((decimal)item.UPIME, 2);
                    row.Cells[dgFirstUPIME.Index].Value = (decimal)item.FirstUPIME;
                    row.Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                    row.Cells[dgPacketUP.Index].Value = item.PacketUP;
                    row.Cells[dgDisc.Index].Value = item.Disc;
                    row.Cells[dgDelivery.Index].Value = item.quotationDeliveryID;
                    row.Cells[dgStatus.Index].Value = item.DubaiStatus;
                    row.Cells[dgTotal.Index].Value = item.Total;
                    row.Cells[dgTargetUP.Index].Value = item.TargetUP;
                    row.Cells[dgCompetitor.Index].Value = item.Competitor;
                    row.Cells[dgUnitWeigt.Index].Value = item.UnitWeight;
                    row.Cells[dgUKPrice.Index].Value = item.UKPrice;
                    row.Cells[dgTotalWeight.Index].Value = item.UnitWeight * item.Qty;
                    row.Cells[dgUnitNetWeight.Index].Value = item.UnitNetWeight;
                    row.Cells[dgUnitTotalNetWeight.Index].Value = item.UnitNetWeight * item.Qty;
                    row.Cells[dgCustStkCode.Index].Value = item.CustomerStockCode;
                    row.Cells[dgMargin.Index].Value = item.Marge;
                    row.Cells[dgBrand.Index].Value = item.Manufacturer;
                    row.Cells[dgSupplier.Index].Value = item.SupplierName;
                    if (Convert.ToDecimal(row.Cells[dgTotalWeight.Index].Value) == 0)
                    {
                        row.Cells[WT.Index].Style.BackColor = Color.Red;
                    }
                    else if (Convert.ToDecimal(row.Cells[dgTotalWeight.Index].Value) > 5)
                    {
                        row.Cells[WT.Index].Style.BackColor = Color.Orange;
                    }
                    else
                    {
                        row.Cells[WT.Index].Style.BackColor = Color.Ivory;
                    }
                    dgQuotationAddedItems.Rows.Add(row);

                }
            }
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {

                GetLandingCost(i);
                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[i].Cells[dgNo.Index];
                GetQuotationQuantity(i);

            }

            if (q.DistributeDiscount==true)
            {
                cbDeliverDiscount.Checked = true;
            }

            #endregion
            //buradaki yazılanların sırası önemli sırayı değiştirmeyin
            lblsubtotal.Text = String.Format("{0:N}", q.SubTotal.ToString());
            txtTotalDis2.Text = String.Format("{0:N}", q.DiscOnSubTotal2.ToString());
            if (txtTotalDis2.Text == null || txtTotalDis2.Text == "") txtTotalDis2.Text = "0";
            if(q.DistributeDiscount == true)
            {
                //txtTotalDis.Text = Math.Round((Decimal.Parse(txtTotalDis2.Text) * 100) / (decimal.Parse(lblsubtotal.Text) + Decimal.Parse(txtTotalDis2.Text)), 4).ToString();
                txtTotalDis.Text = String.Format("{0:N}", ((Decimal.Parse(txtTotalDis2.Text) * 100) / (decimal.Parse(lblsubtotal.Text) + Decimal.Parse(txtTotalDis2.Text))));
            }
            else
            {
                //txtTotalDis.Text = Math.Round((Decimal.Parse(txtTotalDis2.Text) * 100) / decimal.Parse(lblsubtotal.Text), 4).ToString();
                txtTotalDis.Text = String.Format("{0:N}", ((Decimal.Parse(txtTotalDis2.Text) * 100) / decimal.Parse(lblsubtotal.Text)));
            }
            lbltotal.Text = (q.DistributeDiscount == false) ? (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString() : lblsubtotal.Text;
            txtExtraChanges.Text = q.ExtraCharges.ToString();
            lblVat.Text = vat.ToString();
            if (q.IsVatValue == 1) { chkVat.Checked = true; } else { chkVat.Checked = false; }
            //
            if (q.IsItemCost == 1) { ckItemCost.Checked = true; } else { ckItemCost.Checked = false; }
            if (q.IsWeightCost == 1) { ckWeightCost.Checked = true; } else { ckWeightCost.Checked = false; }
            if (q.IsCustomsDuties == 1) { ckCustomsDuties.Checked = true; } else { ckCustomsDuties.Checked = false; }
            //Buraya Curr verileri gelecek
            #endregion
            try
            {
                //if (dgQuotationAddedItems.RowCount > 1)
                //{
                //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgNo.Index].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[dgNo.Index].Value.ToString()) + 1).ToString();
                //}
                //else { dgQuotationAddedItems.Rows[0].Cells[dgNo.Index].Value = 1.ToString(); }
            }
            catch { }
        }


        private void QuotataionModifyItemDetailsFiller(string ArticleNoSearch, int RowIndex)
        {
            CurrentRow = dgQuotationAddedItems.Rows[RowIndex];
            bool isLithum = false;
            bool isShipping = false;
            bool isEnvironment = false;
            bool isCalibrationInd = false;
            bool isLicenceType = false;
            #region Filler
            decimal CurrValueWeb = Decimal.Parse(curr.rate.ToString());
            string ArticleNoSearch1 = ArticleNoSearch;
            try { ArticleNoSearch1 = (Int32.Parse(ArticleNoSearch)).ToString(); } catch { }

            var ItemTabDetails = IME.ItemDetailTabFiller(ArticleNoSearch).FirstOrDefault();
            var rsf = IME.RsFileHistories.Where(a => a.FileType == "OnSale").OrderByDescending(x => x.Date).FirstOrDefault();

            if (ItemTabDetails != null)
            {

                CurrentRow.Cells["dgDesc"].Value = ItemTabDetails.Article_Desc;
                CurrentRow.Cells["dgSSM"].Value = ItemTabDetails.Pack_Quantity.ToString() ?? ""; ;
                CurrentRow.Cells["dgUC"].Value = ItemTabDetails.Unit_Content.ToString() ?? ""; ;
                if (ItemTabDetails.Unit_Measure == "")
                {
                    if (CurrentRow.Cells[dgUC.Index].Value.ToString() == "1" && CurrentRow.Cells[dgSSM.Index].Value.ToString() == "1")
                    {
                        CurrentRow.Cells["dgUOM"].Value = "EACH";
                    }
                    else
                    {
                        CurrentRow.Cells["dgUOM"].Value = "PACKET OF";
                    }
                }
                else
                {
                    CurrentRow.Cells["dgUOM"].Value = ItemTabDetails.Unit_Measure;
                }
                CurrentRow.Cells["dgMPN"].Value = ItemTabDetails.MPN;
                CurrentRow.Cells["dgCL"].Value = ItemTabDetails.Calibration_Ind;
                if (ItemTabDetails.Standard_Weight != 0 && ItemTabDetails.Standard_Weight != null)
                {
                    decimal sW = (decimal)(ItemTabDetails.Standard_Weight / (decimal)1000);
                    sW = (ItemTabDetails.Pack_Quantity > ItemTabDetails.Unit_Content) ? (decimal)(sW / ItemTabDetails.Pack_Quantity) : (decimal)(sW / ItemTabDetails.Unit_Content);
                    txtStandartWeight.Text = String.Format("{0:N}", sW.ToString());
                }

                txtHazardousInd.Text = ItemTabDetails.Hazardous_Ind;
                txtHazardousInd.Text = (ItemTabDetails.Hazardous_Ind != null && ItemTabDetails.Hazardous_Ind != String.Empty && ItemTabDetails.Hazardous_Ind != "N") ? "Y" : "";
                txtCalibrationInd.Text = ItemTabDetails.Calibration_Ind;
                txtCalibrationInd.Text = (ItemTabDetails.Calibration_Ind != null && ItemTabDetails.Calibration_Ind != String.Empty && ItemTabDetails.Calibration_Ind != "N") ? "Y" : "";
                txtEnvironment.Text = ItemTabDetails.Environment.ToString();
                txtEnvironment.Text = (ItemTabDetails.Environment != null && ItemTabDetails.Environment != 0) ? "Y" : "";
                txtLicenceType.Text = ItemTabDetails.LicenceType;
                txtLicenceType.Text = (ItemTabDetails.LicenceType != null && ItemTabDetails.LicenceType != String.Empty && ItemTabDetails.LicenceType != "0") ? "Y" : "";
                txtShipping.Text = ItemTabDetails.Shipping;
                txtShipping.Text = (ItemTabDetails.Shipping != null && ItemTabDetails.Shipping != String.Empty && ItemTabDetails.Shipping != "0") ? "Y" : "";
                txtDiscChange.Text = ItemTabDetails.Low_Discount_Ind;
                txtLithium.Text = ItemTabDetails.Lithium;
                txtLithium.Text = (ItemTabDetails.Lithium != null && ItemTabDetails.Lithium != String.Empty && ItemTabDetails.Lithium != "0") ? "Y" : "";
                txtExpiringPro.Text = ItemTabDetails.Expiring_Product_Change_Ind;
                txtExpiringPro.Text = (ItemTabDetails.Expiring_Product_Change_Ind != null && ItemTabDetails.Expiring_Product_Change_Ind != String.Empty && ItemTabDetails.Expiring_Product_Change_Ind != "0") ? "Y" : "";

                txtCofO.Text = ItemTabDetails.CofO;
                txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
                txtUKDiscDate.Text = ItemTabDetails.Uk_Disc_Date;
                txtDiscChange.Text = ItemTabDetails.Disc_Change_Ind;
                txtExpiringPro.Text = ItemTabDetails.Expiring_Product_Change_Ind;
                txtManufacturer.Text = ItemTabDetails.Manufacturer.ToString() ?? ""; ;
                txtMHCodeLevel1.Text = ItemTabDetails.MH_Code_Level_1;
                txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
                txtHeight.Text = ((decimal)(ItemTabDetails.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(ItemTabDetails.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(ItemTabDetails.Length * ((Decimal)100))).ToString("G29");

                txtGrossWeight.Text = String.Format("{0:N}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());

                #region Length
                try
                {
                    if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
                    {
                        txtGrossWeight.Text = String.Format("{0:N}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());
                        if (Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                        {
                            txtGrossWeight.Text = (decimal.Parse(txtGrossWeight.Text) /
                                Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString())).ToString();

                        }
                        else if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1)
                        {
                            txtGrossWeight.Text = (decimal.Parse(txtGrossWeight.Text) /
                                Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString())).ToString();
                        }
                    }
                }
                catch { }
                #endregion

                txtUK1.Text = (ItemTabDetails.Col1Price / ItemTabDetails.Unit_Content).ToString();
                txtUK2.Text = (ItemTabDetails.Col2Price / ItemTabDetails.Unit_Content).ToString();
                txtUK3.Text = (ItemTabDetails.Col3Price / ItemTabDetails.Unit_Content).ToString();
                txtUK4.Text = (ItemTabDetails.Col4Price / ItemTabDetails.Unit_Content).ToString();
                txtUK5.Text = (ItemTabDetails.Col5Price / ItemTabDetails.Unit_Content).ToString();
                txtUnitCount1.Text = (ItemTabDetails.Col1Break * ItemTabDetails.Unit_Content).ToString();
                txtUnitCount2.Text = (ItemTabDetails.Col2Break * ItemTabDetails.Unit_Content).ToString();
                txtUnitCount3.Text = (ItemTabDetails.Col3Break * ItemTabDetails.Unit_Content).ToString();
                txtUnitCount4.Text = (ItemTabDetails.Col4Break * ItemTabDetails.Unit_Content).ToString();
                txtUnitCount5.Text = (ItemTabDetails.Col5Break * ItemTabDetails.Unit_Content).ToString();
                txtCost1.Text = (ItemTabDetails.DiscountedPrice1 / ItemTabDetails.Unit_Content).ToString();
                txtCost2.Text = (ItemTabDetails.DiscountedPrice2 / ItemTabDetails.Unit_Content).ToString();
                txtCost3.Text = (ItemTabDetails.DiscountedPrice3 / ItemTabDetails.Unit_Content).ToString();
                txtCost4.Text = (ItemTabDetails.DiscountedPrice4 / ItemTabDetails.Unit_Content).ToString();
                txtCost5.Text = (ItemTabDetails.DiscountedPrice5 / ItemTabDetails.Unit_Content).ToString();
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtSupersectionName.Text = ItemTabDetails.SupersectionName;

                if (txtLithium.Text == "Y") isLithum = true;
                if (txtShipping.Text == "Y") isShipping = true;
                if (ItemTabDetails.Calibration_Ind != null)
                {
                    txtRSStock.Text = ItemTabDetails.OnhandStockBalance.ToString();
                    textBox23.Text = rsf.Date.ToString();
                }
                txtRSOnOrder.Text = ItemTabDetails.QuantityonOrder.ToString();
                txtDiscontinuationDate.Text = ItemTabDetails.DiscontinuationDate;
                txtRunOn.Text = ItemTabDetails.Runon?.ToString();
                txtReferral.Text = ItemTabDetails.Referral?.ToString();
                if (!String.IsNullOrEmpty(ItemTabDetails.LicenceType)) isLicenceType = true;
                if (ItemTabDetails.Calibration_Ind == "Y") isCalibrationInd = true;
                #region ItemMarginFiller

                int quantity = Int32.Parse((ItemTabDetails.Col1Break * ItemTabDetails.Unit_Content).ToString() ?? "0");
                if (quantity != 0)
                {
                    txtMargin1.Text = ((1 - ((decimal.Parse(txtCost1.Text)) / (decimal.Parse(txtUK1.Text)))) * 100).ToString();
                    if (decimal.Parse(txtUK2.Text) == 0)
                    {
                        txtMargin2.Text = "";
                        txtMargin3.Text = "";
                        txtMargin4.Text = "";
                        txtMargin5.Text = "";
                    }
                    else
                    {

                        txtMargin2.Text = ((1 - ((decimal.Parse(txtCost2.Text)) / (decimal.Parse(txtUK2.Text)))) * 100).ToString();
                        try
                        {
                            if (decimal.Parse(txtUK3.Text) == 0)
                            {
                                txtMargin3.Text = ((1 - ((decimal.Parse(txtCost3.Text)) / (decimal.Parse(txtUK3.Text)))) * 100).ToString();
                                if (ItemTabDetails.Col4Break != 0)
                                {
                                    txtMargin4.Text = ((1 - ((decimal.Parse(txtCost4.Text)) / (decimal.Parse(txtUK4.Text)))) * 100).ToString();
                                    if (ItemTabDetails.Col5Break != 0)
                                    {
                                        txtMargin5.Text = ((1 - ((decimal.Parse(txtCost5.Text)) / (decimal.Parse(txtUK5.Text)))) * 100).ToString();
                                    }
                                    else
                                    {
                                        txtMargin5.Text = "";
                                    }
                                }
                                else
                                {
                                    txtMargin4.Text = "";
                                    txtMargin5.Text = "";
                                }
                            }
                            else
                            {
                                txtMargin3.Text = "";
                                txtMargin4.Text = "";
                                txtMargin5.Text = "";
                            }
                        }
                        catch { }
                    }
                    #endregion
                }
            }
            if (CurrentRow.Cells["dgUOM"].Value == null && CurrentRow.Cells["dgUC"].Value != null)
            { CurrentRow.Cells["dgUOM"].Value = "Each"; }
            #endregion

            #region OldFunction


            #region Filler
            //            decimal CurrValueWeb = Decimal.Parse(curr.rate.ToString());
            //            string ArticleNoSearch1 = ArticleNoSearch;
            //            try { ArticleNoSearch1 = (Int32.Parse(ArticleNoSearch)).ToString(); } catch { }
            //            //Seçili olan item ı text lere yazdıran fonksiyon yazılacak
            //            var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            //            if (sd == null) { sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNoSearch1).FirstOrDefault(); }

            //            var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            //            if (sdP == null) { sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNoSearch1).FirstOrDefault(); }

            //            var er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //            if (er == null) { er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            //            var os = IME.OnSales.Where(a => a.ArticleNumber == ArticleNoSearch).FirstOrDefault();
            //            if (os == null) { os = IME.OnSales.Where(a => a.ArticleNumber == ArticleNoSearch1).FirstOrDefault(); }

            //            var sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //            if (sp == null) { sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            //            var dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //            if (dd == null) { dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            //            var h = IME.Hazardous.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //            if (h == null) { h = IME.Hazardous.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            //            var du = IME.DualUses.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //            if (du == null) { du = IME.DualUses.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            //            if (sd != null)
            //            {
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = sd.Article_Desc;
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgSSM"].Value = sd.Pack_Quantity.ToString();
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUC"].Value = sd.Unit_Content.ToString();
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sd.Unit_Measure;
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = sd.MPN;
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgCL"].Value = sd.Calibration_Ind;
            //                if (sd.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sd.Standard_Weight) / (decimal)1000).ToString("G29"); } else { }
            //                txtHazardousInd.Text = sd.Hazardous_Ind;
            //                txtCalibrationInd.Text = sd.Calibration_Ind;
            //                if (sd.Calibration_Ind == "Y") isCalibrationInd = true;
            //                //ObsoluteFlag.Text = sd.Obsolete_Flag.ToString();
            //                //LowDiscontInd.Text = sd.Low_Discount_Ind;
            //                //LicensedInd.Text = sd.Licensed_Ind.ToString();
            //                //ShelfLife.Text = sd.Shelf_Life;
            //                txtCofO.Text = sd.CofO;
            //                txtCCCN.Text = sd.CCCN_No.ToString();
            //                //UKIntroDate.Text = sd.Uk_Intro_Date;
            //                txtUKDiscDate.Text = sd.Uk_Disc_Date;
            //                //BHCFlag.Text = sd.BHC_Flag.ToString();
            //                txtDiscCharge.Text = sd.Disc_Change_Ind;
            //                txtExpiringPro.Text = sd.Expiring_Product_Change_Ind;
            //                txtManufacturer.Text = sd.Manufacturer.ToString();
            //                txtMHCodeLevel1.Text = sd.MH_Code_Level_1;
            //                txtCCCN.Text = sd.CCCN_No.ToString();
            //                txtHeight.Text = ((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29");
            //                txtWidth.Text = ((decimal)(sd.Width * ((Decimal)100))).ToString("G29");
            //                txtLength.Text = ((decimal)(sd.Length * ((Decimal)100))).ToString("G29");
            //            }
            //            if (sdP != null)
            //            {
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = sdP.Article_Desc;
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgSSM"].Value = sdP.Pack_Quantity.ToString();
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUC"].Value = sdP.Unit_Content.ToString();
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
            //                // dgQuotationAddedItems.Rows[RowIndex].Cells["dgPackType"].Value = sdP.Calibration_Ind;

            //                if (sdP.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sdP.Standard_Weight) / (decimal)1000).ToString("G29"); }
            //                txtHazardousInd.Text = sdP.Hazardous_Ind;
            //                txtCalibrationInd.Text = sdP.Calibration_Ind;
            //                //ObsoluteFlag.Text = sdP.Obsolete_Flag.ToString();
            //                //LowDiscontInd.Text = sdP.Low_Discount_Ind;
            //                //LicensedInd.Text = sdP.Licensed_Ind.ToString();
            //                //ShelfLife.Text = sdP.Shelf_Life;
            //                txtCofO.Text = sdP.CofO;
            //                txtCCCN.Text = sdP.CCCN_No.ToString();
            //                //UKIntroDate.Text = sdP.Uk_Intro_Date;
            //                txtUKDiscDate.Text = sdP.Uk_Disc_Date;
            //                //BHCFlag.Text = sdP.BHC_Flag.ToString();
            //                txtDiscCharge.Text = sdP.Disc_Change_Ind;
            //                txtExpiringPro.Text = sdP.Expiring_Product_Change_Ind;
            //                txtManufacturer.Text = sdP.Manufacturer.ToString();
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = sdP.MPN;
            //                txtMHCodeLevel1.Text = sdP.MH_Code_Level_1;
            //                txtCCCN.Text = sdP.CCCN_No.ToString();
            //                txtHeight.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
            //                txtWidth.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
            //                txtLength.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            //            }
            //            if (er != null)
            //            {
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = er.ArticleDescription;
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = er.UnitofMeasure;
            //                dgQuotationAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = er.MPN;
            //                if (txtLength.Text != "") { txtLength.Text = ((decimal)(er.ExtendedRangeLength * ((Decimal)100))).ToString("G29"); }
            //                if (txtWidth.Text != "") { txtWidth.Text = ((decimal)(er.Width * ((Decimal)100))).ToString("G29"); }
            //                if (txtHeight.Text != "") { txtHeight.Text = ((decimal)(er.Height * ((Decimal)100))).ToString("G29"); }
            //                if (er.ExtendedRangeWeight != null) { txtStandartWeight.Text = ((decimal)(er.ExtendedRangeWeight) / (decimal)1000).ToString("G29"); }
            //                txtCCCN.Text = er.CCCN.ToString();
            //                txtCofO.Text = er.CountryofOrigin;
            //                txtUK1.Text = er.Col1Price.ToString();
            //                txtUK2.Text = er.Col2Price.ToString();
            //                txtUK3.Text = er.Col3Price.ToString();
            //                txtUK4.Text = er.Col4Price.ToString();
            //                txtUK5.Text = er.Col5Price.ToString();
            //                txtUnitCount1.Text = er.Col1Break.ToString();
            //                txtUnitCount2.Text = er.Col2Break.ToString();
            //                txtUnitCount3.Text = er.Col3Break.ToString();
            //                txtUnitCount4.Text = er.Col4Break.ToString();
            //                txtUnitCount5.Text = er.Col5Break.ToString();
            //                txtCost1.Text = er.DiscountedPrice1.ToString();
            //                txtCost2.Text = er.DiscountedPrice2.ToString();
            //                txtCost3.Text = er.DiscountedPrice3.ToString();
            //                txtCost4.Text = er.DiscountedPrice4.ToString();
            //                txtCost5.Text = er.DiscountedPrice5.ToString();
            //                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //            }
            //            if (sp != null)
            //            {
            //                //IntroductionDate.Text = sp.IntroductionDate;
            //                //DiscontinuedDate.Text = sp.DiscontinuedDate;
            //                txtUnitCount1.Text = sp.Col1Break.ToString();
            //                txtUnitCount2.Text = sp.Col2Break.ToString();
            //                txtUnitCount3.Text = sp.Col3Break.ToString();
            //                txtUnitCount4.Text = sp.Col4Break.ToString();
            //                txtUnitCount5.Text = sp.Col5Break.ToString();
            //                txtUK1.Text = sp.Col1Price.ToString();
            //                txtUK2.Text = sp.Col2Price.ToString();
            //                txtUK3.Text = sp.Col3Price.ToString();
            //                txtUK4.Text = sp.Col4Price.ToString();
            //                txtUK5.Text = sp.Col5Price.ToString();
            //                txtCost1.Text = sp.DiscountedPrice1.ToString();
            //                txtCost2.Text = sp.DiscountedPrice2.ToString();
            //                txtCost3.Text = sp.DiscountedPrice3.ToString();
            //                txtCost4.Text = sp.DiscountedPrice4.ToString();
            //                txtCost5.Text = sp.DiscountedPrice5.ToString();
            //                txtSupersectionName.Text = sp.SupersectionName;
            //                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            //            }
            //            if (h != null)
            //            {
            //                if (h.Environment != null) { txtEnvironment.Text = "Y"; isEnvironment = true; } else { txtEnvironment.Text = ""; }
            //                if (h.Lithium != null) { txtLithium.Text = "Y"; isLithum = true; } else { txtLithium.Text = ""; }
            //                if (h.Shipping != null) { txtShipping.Text = "Y"; isShipping = true; } else { txtShipping.Text = ""; }
            //            }
            //            else
            //            {
            //                txtEnvironment.Text = "";
            //                txtLithium.Text = "";
            //                txtShipping.Text = "";
            //            }
            //            if (os != null)
            //            {
            //                //OnSaleDiscontinuedDate.Text = os.DiscontinuedDate;
            //                //OnSaleIntroductionDate.Text = os.IntroductionDate;
            //                txtRSStock.Text = os.OnhandStockBalance.ToString();
            //                txtRSOnOrder.Text = os.QuantityonOrder.ToString();
            //            }
            //            if (dd != null)
            //            {
            //                txtDiscontinuationDate.Text = dd.DiscontinuationDate;
            //                txtRunOn.Text = dd.Runon.ToString();
            //                txtReferral.Text = dd.Referral.ToString();
            //            }
            //            if (du != null) { txtLicenceType.Text = du.LicenceType; isLicenceType = true; }
            //            //
            //            #endregion
            //            #region ItemMarginFiller
            //            string articleNo = ArticleNoSearch;
            //            SlidingPrice sp1 = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //            try
            //            {
            //                txtMargin1.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
            //, Int32.Parse(sp1.Col1Break.ToString()))).ToString("G29");
            //                txtMargin1.Text = ((1 - ((Decimal.Parse(txtMargin1.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
            //            }
            //            catch { }
            //            try
            //            {
            //                txtMargin2.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
            //                             , Int32.Parse(sp1.Col2Break.ToString()))).ToString("G29");
            //            }
            //            catch { }
            //            if (txtWeb2.Text == "0")
            //            {
            //                txtMargin2.Text = "";
            //                txtMargin3.Text = "";
            //                txtMargin4.Text = "";
            //                txtMargin5.Text = "";
            //            }
            //            else
            //            {
            //                try
            //                {
            //                    txtMargin2.Text = ((1 - ((Decimal.Parse(txtMargin2.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
            //                    txtMargin3.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked, Int32.Parse(sp1.Col3Break.ToString()))).ToString("G29");
            //                    txtMargin3.Text = ((1 - ((Decimal.Parse(txtMargin3.Text)) / (decimal.Parse(txtWeb3.Text)))) * 100).ToString();
            //                    if (sp1.Col4Break != 0)
            //                    {
            //                        txtMargin4.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
            //                    , Int32.Parse(sp1.Col4Break.ToString()))).ToString("G29");
            //                        txtMargin4.Text = ((1 - ((Decimal.Parse(txtMargin4.Text)) / (decimal.Parse(txtWeb4.Text)))) * 100).ToString();
            //                        if (sp1.Col5Break != 0)
            //                        {
            //                            txtMargin5.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
            //                        , Int32.Parse(sp1.Col5Break.ToString()))).ToString("G29");
            //                            txtMargin5.Text = ((1 - ((Decimal.Parse(txtMargin5.Text)) / (decimal.Parse(txtWeb5.Text)))) * 100).ToString();
            //                        }
            //                    }
            //                }
            //                catch { }
            //            }

            //#endregion
            #endregion

            #region Low Margin Mark

            //if (isLithum)
            //{
            //    label64.BackColor = Color.Red;
            //    //CurrentRow.Cells["LI"].Style.BackColor = Color.Ivory;
            //    CurrentRow.Cells["LI"].Style.BackColor = Color.Red;
            //}
            ////else
            ////{
            ////    label64.BackColor = Color.Transparent;
            ////    CurrentRow.Cells["LI"].Style.BackColor = Color.White;
            ////}
            //if (isShipping)
            //{
            //    label63.BackColor = Color.Red;
            //    CurrentRow.Cells["HS"].Style.BackColor = Color.Red;
            //}
            ////else
            ////{
            ////    label63.BackColor = Color.Transparent;
            ////    CurrentRow.Cells["HS"].Style.BackColor = Color.White;
            ////}
            //if (isEnvironment)
            //{
            //    label53.BackColor = Color.Red;
            //}
            ////else
            ////{
            ////    label53.BackColor = Color.White;
            ////}
            //if (isCalibrationInd)
            //{
            //    label22.BackColor = Color.Red;
            //    // dgQuotationAddedItems.Rows[RowIndex].Cells["CL"].Style.BackColor = Color.Green;
            //    dgQuotationAddedItems.Rows[RowIndex].Cells["CL"].Style.BackColor = Color.Red;
            //}
            ////else
            ////{
            ////    label22.BackColor = Color.Transparent;
            ////    dgQuotationAddedItems.Rows[RowIndex].Cells["CL"].Style.BackColor = Color.White;
            ////}

            //if (isLicenceType)
            //{
            //    // dgQuotationAddedItems.Rows[RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
            //    dgQuotationAddedItems.Rows[RowIndex].Cells["LC"].Style.BackColor = Color.Red;
            //}
            ////else
            ////{
            ////    dgQuotationAddedItems.Rows[RowIndex].Cells["LC"].Style.BackColor = Color.White;
            ////}
            #endregion
            #endregion

            #region Low Margin Mark Clear
            if (!String.IsNullOrEmpty(txtHazardousInd.Text) && txtHazardousInd.Text == "Y")
            {
                label64.BackColor = Color.Red;
                CurrentRow.Cells[dgHZ.Index].Style.BackColor = Color.Red;
            }
            if (!String.IsNullOrEmpty(txtLithium.Text) && txtLithium.Text == "Y")
            {
                label64.BackColor = Color.Red;
                CurrentRow.Cells["LI"].Style.BackColor = Color.Red;
            }
            if (!String.IsNullOrEmpty(txtShipping.Text) && txtShipping.Text == "Y")
            {
                label63.BackColor = Color.Red;
                CurrentRow.Cells["HS"].Style.BackColor = Color.Red;

            }
            if (!String.IsNullOrEmpty(txtEnvironment.Text) && txtEnvironment.Text == "Y")
            {
                label53.BackColor = Color.Red;
            }
            if (!String.IsNullOrEmpty(txtCalibrationInd.Text) && txtCalibrationInd.Text == "Y")
            {
                label22.BackColor = Color.Red;
                CurrentRow.Cells["CL"].Style.BackColor = Color.Red;
            }
            if (!String.IsNullOrEmpty(txtLicenceType.Text))
            {
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.Red;
            }
            #endregion
        }

        private void cbCurrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    if ((cbCurrType.SelectedIndex != null))
            //    {
            //        GetCurrency(dtpDate.Value);
            //        ChangeCurr();
            //    }
            //    else
            //    {
            //        MessageBox.Show("You Must Choose a Curr Type");
            //        cbCurrType.SelectedIndex = 0;
            //    }
        }

        private void GetCurrency(DateTime date)
        {
            if (cbCurrency.SelectedItem != null)
            {
                decimal cb = (cbCurrency.SelectedItem as Currency).currencyID;
                curr = IME.ExchangeRates.Where(a => a.currencyId == cb).OrderByDescending(b => b.date).FirstOrDefault();

                if (CurrValue1 != CurrValue) CurrValue1 = CurrValue;
                CurrValue = (decimal)curr.rate;
            }
        }

        private void GetCurrencySymbol()
        {
            if (cbCurrency.SelectedItem != null)
            {
                lblPara.Text = (cbCurrency.SelectedItem as Currency).currencySymbol;
            }
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurrency.SelectedIndex != null && cbCurrency.DataSource != null)
            {
                GetCurrency(dtpDate.Value);
                ChangeCurr();
                calculateTotalCost();
                GetCurrencySymbol();
            }
        }

        private void ChangeCurr(int rowindex)
        {
            if (dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value != null)
            {

                dgQuotationAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value.ToString())) / Currfactor).ToString();
                dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = Math.Round(((Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString())) / Currfactor), 2).ToString();
                dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = Math.Round(((Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())) / Currfactor), 2);
                CalculateSubTotal();
            }

        }

        private string GetCurrencySign()
        {
            return curr.Currency?.currencySymbol;
        }

        private void ChangeCurr()
        {
            lblWeb.Text = "Web (" + GetCurrencySign() + ")";
            decimal SubTotalTotal = 0;
            #region ChangeWebValues
            if (CurrValue1 != CurrValue)
            {
                Currfactor = CurrValue / CurrValue1;
            }
            else
            {
                //Else'in çine girme şartını kontrol et
                Currfactor = 1;
                if (txtWeb1.Text != "" && txtWeb1.Text != null)
                {
                    txtWeb1.Text = (Decimal.Parse(txtWeb1.Text) / Currfactor).ToString();
                    txtWeb2.Text = (Decimal.Parse(txtWeb2.Text) / Currfactor).ToString();
                    txtWeb3.Text = (Decimal.Parse(txtWeb3.Text) / Currfactor).ToString();
                    txtWeb4.Text = (Decimal.Parse(txtWeb4.Text) / Currfactor).ToString();
                    txtWeb5.Text = (Decimal.Parse(txtWeb5.Text) / Currfactor).ToString();
                }

            }
            #endregion
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                #region Get Margin
                if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null && dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString() != "0")
                {
                    CurrentRow = dgQuotationAddedItems.Rows[i];
                    //CurrentRow.Cells["dgUCUPCurr"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString())) / Currfactor), 2).ToString();
                    CurrentRow.Cells["dgUCUPCurr"].Value = String.Format("{0:N}", ((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString())) / Currfactor).ToString());
                    if (Convert.ToInt32(CurrentRow.Cells[dgSSM.Index].Value.ToString()) > 1 || Convert.ToInt32(CurrentRow.Cells[dgUC.Index].Value.ToString()) > 1)
                    {
                        //CurrentRow.Cells[dgPacketUP.Index].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells[dgPacketUP.Index].Value.ToString())) / Currfactor), 2).ToString();
                        CurrentRow.Cells[dgPacketUP.Index].Value = ((Decimal.Parse(CurrentRow.Cells[dgPacketUP.Index].Value.ToString())) / Currfactor).ToString();
                    }
                    //CurrentRow.Cells["dgUPIME"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString())) / Currfactor), 2).ToString();
                    //CurrentRow.Cells[dgFirstUPIME.Index].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString())) / Currfactor), 2).ToString();
                    //CurrentRow.Cells["dgTotal"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString())) / Currfactor), 2).ToString();
                    CurrentRow.Cells["dgUPIME"].Value = ((Decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString())) / Currfactor).ToString();
                    CurrentRow.Cells[dgFirstUPIME.Index].Value = ((Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString())) / Currfactor).ToString();
                    CurrentRow.Cells["dgTotal"].Value = ((Decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString())) / Currfactor).ToString();

                }
                #endregion
            }
            CalculateSubTotal();
            //lblCurrValue.Text = Math.Round(CurrValue, 4).ToString();
            lblCurrValue.Text = (String.Format("{0:N}", CurrValue));
        }

        private void lblVatTotal_TextChanged(object sender, EventArgs e)
        {
            if (lblVatTotal.Text != String.Format("{0:N}", (decimal.Parse(lblVatTotal.Text))))
            {
                lblVatTotal.Text = String.Format("{0:N}", (decimal.Parse(lblVatTotal.Text)));
            }
        }

        private void lblGrossTotal_TextChanged(object sender, EventArgs e)
        {
            if (lblGrossTotal.Text != String.Format("{0:N}", (decimal.Parse(lblGrossTotal.Text))))
            {
                lblGrossTotal.Text = String.Format("{0:N}", (decimal.Parse(lblGrossTotal.Text)));
            }
        }

        private void ItemsClear()
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.CurrentRow;
                row.Cells[1].Style.BackColor = Color.Ivory;
                row.Cells[2].Style.BackColor = Color.Ivory;
                row.Cells[3].Style.BackColor = Color.Ivory;
                row.Cells[4].Style.BackColor = Color.Ivory;
                row.Cells[5].Style.BackColor = Color.Ivory;
                row.Cells[6].Style.BackColor = Color.Ivory;
                for (int i = 9; i < row.Cells.Count; i++)
                {
                    row.Cells[i].Value = "";
                }
            }
            catch { }
        }

        private void ItemDetailsClear()
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.CurrentRow;
                row.Cells[1].Style.BackColor = Color.Ivory;
                row.Cells[2].Style.BackColor = Color.Ivory;
                row.Cells[3].Style.BackColor = Color.Ivory;
                row.Cells[4].Style.BackColor = Color.Ivory;
                row.Cells[5].Style.BackColor = Color.Ivory;
                row.Cells[6].Style.BackColor = Color.Ivory;
                for (int i = 9; i < row.Cells.Count; i++)
                {
                    row.Cells[i].Value = "";
                }
            }
            catch { }
        }

        private string NewQuotationID()
        {
            IMEEntities IME = new IMEEntities();
            //List<Quotation> quotList = IME.Quotations.Where(q => q.QuotationNo == Convert.ToDateTime(IME.CurrentDate().First()).Year).toList();
            //int ID;
            int year = Utils.GetCurrentDateTime().Year;
            Quotation quo = IME.Quotations.Where(a => a.StartDate.Year == year).OrderByDescending(q => q.QuotationNo).FirstOrDefault();
            string q1;
            if (quo == null)
            {

                q1 = year.ToString() + "/1";
            }
            else
            {
                q1 = quo.QuotationNo;
                while (IME.Quotations.Where(a => a.QuotationNo == q1).ToList().Count > 0)
                {

                    if (quo.QuotationNo.Contains("v"))
                    {
                        int quoID = Int32.Parse(q1.Substring(quo.QuotationNo.LastIndexOf('/') + 1, (quo.QuotationNo.LastIndexOf('v') + 1) - (quo.QuotationNo.LastIndexOf('/') + 1) - 1)) + 1;

                        q1 = (quo.QuotationNo.Substring(0, quo.QuotationNo.IndexOf('/') + 1)).ToString();

                        q1 = q1 + quoID.ToString();

                    }
                    else
                    {
                        int quoID = Int32.Parse(q1.Substring(quo.QuotationNo.LastIndexOf('/') + 1)) + 1;

                        q1 = year.ToString() + "/" + quoID.ToString();
                    }
                }
            }
            return q1;
        }

        private void btnCreateRev_Click(object sender, EventArgs e)
        {
            modifyMod = false;
            if (MessageBox.Show("Creating a new version! Please Confirm?", "Create Version", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ControlSave())
                {
                    QuotationSave();
                    QuotationDetailsSave();

                    Quotation quo = IME.Quotations.Where(q => q.QuotationNo == txtQuotationNo.Text).FirstOrDefault();
                    quo.ViewQuotation = true;
                    quo.ViewQuotationName = null;
                    IME.SaveChanges();
                }
            }
        }

        private void CustomerCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CustomerSearchInput();
        }

        public void CustomerSearchInput()
        {
            var customerList = IME.Customers.Where(a => a.c_name.Contains(CustomerCode.Text)).ToList();
            if (customerList.Count == 1)
            {
                this.Enabled = true;
                customer = customerList.FirstOrDefault();
                cbWorkers.Items.AddRange(customer.CustomerWorkers.ToArray());
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.ValueMember = "ID";
                txtCustomerName.Text = customer.c_name;
                CustomerCode.Text = customer.ID;
                lblCustomerFactorValue.Text = customer.factor.ToString();
                lblCustomerDiscountValue.Text = customer.discountrate.ToString();
                lblCustomerMarkupValue.Text = customer.Markup.ToString();
                if (customer.paymentmethodID != null)
                {
                    cbPayment.SelectedIndex = cbPayment.FindStringExact(customer.PaymentTerm.term_name);
                }
                try { txtContactNote.Text = customer.CustomerWorker.Note.Note_name; } catch { }
                try { txtCustomerNote.Text = customer.Note.Note_name; } catch { }
                try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == customer.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
                if (customer.Worker != null) cbRep.SelectedValue = customer.Worker.WorkerID;
                if (this.Text != "Edit Quotation")
                {
                    var CustomerCurr = IME.Currencies.Where(a => a.currencyName == customer.CurrNameQuo).FirstOrDefault();
                    if (CustomerCurr != null) cbCurrency.SelectedValue = CustomerCurr.currencyID;
                }
                if (customer.CustomerWorker != null)
                {
                    cbWorkers.SelectedItem = cbWorkers.FindStringExact(customer.CustomerWorker.cw_name);
                }
                btnContactAdd.Enabled = true;
            }
            else if (customerList.Count != 1)
            {
                QuotationUtils.customersearchID = "";
                QuotationUtils.customersearchname = CustomerCode.Text;
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(customer,this);
                this.Enabled = false;
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    customer = form.customer;
                    cbWorkers.Items.AddRange(customer.CustomerWorkers.ToArray());
                    cbWorkers.DisplayMember = "cw_name";
                    cbWorkers.ValueMember = "ID";
                }
                this.Enabled = true;
                fillCustomer();
                btnContactAdd.Enabled = true;
            }
            dgQuotationAddedItems.Focus();
            dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];

        }

        private void ChangeCurrnetCellCellEnd(int currindex)
        {
            try
            {

                if (dgQuotationAddedItems.Columns[dgQuotationAddedItems.CurrentCell.ColumnIndex].HeaderText == "Item Code" && !String.IsNullOrEmpty(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value?.ToString()))
                {
                    dgQuotationAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
                }
                else if (dgQuotationAddedItems.Columns[dgQuotationAddedItems.CurrentCell.ColumnIndex].HeaderText == "Qty" && !String.IsNullOrEmpty(dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value?.ToString()))
                {
                    dgQuotationAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
                }
                else if (dgQuotationAddedItems.Columns[dgQuotationAddedItems.CurrentCell.ColumnIndex].HeaderText == "U/C U/P (Curr.)")
                {
                    if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value == null)
                    {
                        dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index];
                    }
                    else
                    {

                        DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                        int rowIndex = dgQuotationAddedItems.Rows.Add(dgRow);
                        dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index];
                        ItemClear();
                        //dgQuotationAddedItems.Rows[rowIndex].Cells["dgQty"].ReadOnly = true;
                        //dgQuotationAddedItems.Rows[rowIndex].Cells["dgUCUPCurr"].ReadOnly = true;
                    }
                }
            }
            catch { }
        }

        private void ChangeCurrnetCell(int currindex)
        {
            try
            {

                if (dgQuotationAddedItems.Columns[dgQuotationAddedItems.CurrentCell.ColumnIndex].HeaderText == "No" && !String.IsNullOrEmpty(dgQuotationAddedItems.CurrentRow.Cells[dgNo.Index].Value?.ToString()))
                {
                    dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].ReadOnly = false;
                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
                }
                else if (dgQuotationAddedItems.Columns[dgQuotationAddedItems.CurrentCell.ColumnIndex].HeaderText == "Item Code" && !String.IsNullOrEmpty(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value?.ToString()))
                {
                    dgQuotationAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
                }
                else if (dgQuotationAddedItems.Columns[dgQuotationAddedItems.CurrentCell.ColumnIndex].HeaderText == "Qty" && !String.IsNullOrEmpty(dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value?.ToString()))
                {
                    dgQuotationAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index];
                }
                else if (dgQuotationAddedItems.Columns[dgQuotationAddedItems.CurrentCell.ColumnIndex].HeaderText == "U/C U/P (Curr.)")
                {
                    if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value == null)
                    {
                        dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index];
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value.ToString()) && dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value.ToString() != "")
                        {
                            DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                            int rowIndex = dgQuotationAddedItems.Rows.Add(dgRow);
                            dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index];
                            ItemClear();
                            //dgQuotationAddedItems.Rows[rowIndex].Cells["dgQty"].ReadOnly = true;
                            //dgQuotationAddedItems.Rows[rowIndex].Cells["dgUCUPCurr"].ReadOnly = true;
                        }
                    }
                }
                //if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString() != "")
                //{
                //    dgQuotationAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                //    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
                //    if (!String.IsNullOrEmpty(dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value?.ToString()))
                //    {
                //        dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index];
                //        dgQuotationAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
                //        a = a + 1;
                //        if (a == 3)
                //        {
                //            if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value == null && dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString() != "")
                //            {
                //                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
                //            }
                //            else
                //            {
                //                DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                //                int rowIndex = dgQuotationAddedItems.Rows.Add(dgRow);
                //                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index];
                //                ItemClear();
                //                a = 1;
                //                dgQuotationAddedItems.Rows[rowIndex].Cells["dgQty"].ReadOnly = true;
                //                dgQuotationAddedItems.Rows[rowIndex].Cells["dgUCUPCurr"].ReadOnly = true;
                //            }
                //        }
                //        else if (a == 4)
                //        {
                //            a = 2;
                //            dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index];
                //        }
                //    }
                //    else
                //    {
                //        dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
                //        SendKeys.Send("{UP}");
                //        for (int i = 0; i < (dgQuotationAddedItems.RowCount - 1); i++)
                //        {
                //            dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - i].Cells["dgQty"].ReadOnly = true;
                //        }
                //    }

                //}
                //else
                //{
                //    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
                //    for (int i = 0; i < (dgQuotationAddedItems.RowCount - 1); i++)
                //    {
                //        dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - i].Cells["dgQty"].ReadOnly = true;
                //        dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - i].Cells["dgUCUPCurr"].ReadOnly = true;
                //    }
                //}
            }
            catch { }
        }

        private void ChangeCurrnetCellTabKey(int currindex)
        {
            if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && IME.ArticleSearch(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()).Count() == 1)
            {
                int row = dgQuotationAddedItems.CurrentCell.RowIndex;
                while (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[currindex].ReadOnly == true)
                {
                    if (currindex == dgQuotationAddedItems.ColumnCount - 2)
                    {
                        if (dgQuotationAddedItems.RowCount - 1 == row && dgQuotationAddedItems.CurrentRow.Cells["dgDesc"].Value != null)
                        {
                            DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                            dgQuotationAddedItems.Rows.Add(dgRow);
                        }
                        if (dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value == null)
                        {
                            currindex = 13;
                        }
                        else
                        {
                            currindex = 6;
                            row++;
                        }
                    }
                    else
                    {
                        //if (currindex == 14 && dgQuotationAddedItems.Rows[row].Cells[14].Value == null) break;
                        currindex++;
                    }
                }
                try
                {
                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[row].Cells[currindex - 1];
                }
                catch { }
            }
        }

        private void dgQuotationAddedItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                //TabOrEnterKeyOnGrid(e);

                manuelSelection = "Tab";
                ChangeCurrnetCellTabKey(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
                dgQuotationAddedItems.Focus();
            }
            else if ((e.KeyCode == Keys.Escape))
            {
                ChangeCurrnetCell(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
                dgQuotationAddedItems.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ChangeCurrnetCell(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
                if (dgQuotationAddedItems.CurrentRow.Index != dgQuotationAddedItems.RowCount - 1) SendKeys.Send("{UP}");
                dgQuotationAddedItems.Focus();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgQuotationDeleted.Columns[dgDelivery1.Index];

                deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
                deliveryColumn.DisplayMember = "DeliveryName";
                deliveryColumn.ValueMember = "ID";

                foreach (DataGridViewRow item in dgQuotationAddedItems.SelectedRows)
                {
                    decimal rownumber = Decimal.Parse(dgQuotationAddedItems.Rows[item.Index].Cells["dgNo"].Value.ToString());
                    dgQuotationDeleted.Rows.Add();
                    for (int i = 0; i < dgQuotationDeleted.Columns.Count; i++)
                    {
                        dgQuotationDeleted.Rows[dgQuotationDeleted.Rows.Count - 2].Cells[i].Value = item.Cells[i].Value;
                    }
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value.ToString() != "")
                {

                }
                else
                {
                    dgQuotationAddedItems.Rows.RemoveAt(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Index);
                    dgQuotationAddedItems.Refresh();
                }
                if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null)
                {
                    if (dgQuotationAddedItems.CurrentRow.Index > 0)
                    {
                        dgQuotationAddedItems.ClearSelection();
                        dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentRow.Index - 1].Selected = true;
                        QuotataionModifyItemDetailsFiller(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentRow.Index - 1].Cells[dgProductCode.Index].Value.ToString(), dgQuotationAddedItems.CurrentRow.Index - 1);
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value != null)
                {
                    if (dgQuotationAddedItems.CurrentRow.Index < dgQuotationAddedItems.RowCount - 1)
                    {
                        dgQuotationAddedItems.ClearSelection();
                        dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentRow.Index + 1].Selected = true;
                        QuotataionModifyItemDetailsFiller(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentRow.Index + 1].Cells[dgProductCode.Index].Value.ToString(), dgQuotationAddedItems.CurrentRow.Index + 1);
                    }
                }
            }
        }

        private void btnViewMore_Click(object sender, EventArgs e)
        {
            if (CustomerCode.Text == null || CustomerCode.Text == string.Empty)
            {
                MessageBox.Show("Please Enter a Customer", "Eror !");
            }
            else
            {
                Customer c;

                IMEEntities IME = new IMEEntities();
                try
                {
                    c = IME.Customers.Where(q => q.ID == CustomerCode.Text).FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }

                FormCustomerAdd f = new FormCustomerAdd(c, "Quotation");
                f.ShowDialog();
            }
        }

        private void btnContactAdd_Click(object sender, EventArgs e)
        {
            if (CustomerCode.Text == null)
            {
                MessageBox.Show("Customer not selected !", "Eror !");
            }
            else
            {
                Customer c;

                IMEEntities IME = new IMEEntities();
                try
                {
                    c = IME.Customers.Where(q => q.ID == CustomerCode.Text).FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }

                FormCustomerAdd f = new FormCustomerAdd(c, "Contact");
                f.ShowDialog();

                IME = new IMEEntities();

                cbWorkers.Items.AddRange(IME.CustomerWorkers.Where(a => a.customerID == CustomerCode.Text).ToArray());
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.ValueMember = "ID";
            }
        }

        private void btnContactUpdate_Click(object sender, EventArgs e)
        {
            if (CustomerCode.Text == null)
            {
                MessageBox.Show("Customer not selected !", "Error !");
            }
            else
            {
                CustomerMain f = new CustomerMain(1, CustomerCode.Text);
                f.ShowDialog();

                IME = new IMEEntities();

                fillCustomer();
                cbWorkers.Items.AddRange(IME.CustomerWorkers.Where(a => a.customerID == CustomerCode.Text).ToArray());
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.ValueMember = "ID";
            }
        }



        private void txtTotalDis2_Leave(object sender, EventArgs e)
        {

            if (lblsubtotal.Text != null & lblsubtotal.Text != string.Empty)
            {
                if (txtTotalDis2.Text == null || txtTotalDis2.Text == "") txtTotalDis2.Text = "0";
                decimal subtotal = 0;
                //
                for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                {
                    if (txtHazardousInd.Text != "Y" && txtLithium.Text != "Y")
                    {
                        if (dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value == null)
                        {
                            subtotal += Decimal.Parse(String.Format("{0:N}", decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString())));

                        }
                    }
                }
                //
                decimal totaldis = Decimal.Parse(String.Format("{0:N}", (Decimal.Parse(txtTotalDis2.Text) * 100) / decimal.Parse(subtotal.ToString())));
                txtTotalDis.Text = String.Format("{0:N}", totaldis.ToString());
                lbltotal.Text = String.Format("{0:N}", (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString());
            }
            Disc();
            txtTotalDis2.Text = String.Format("{0:N}", Decimal.Parse(txtTotalDis2.Text));
        }



        private void txtTotalDis_Leave(object sender, EventArgs e)
        {
            #region Eski totalDisc
            //if (lblsubtotal.Text != null && lblsubtotal.Text != string.Empty)
            //{
            //    if (txtTotalDis.Text == null || txtTotalDis.Text == "") txtTotalDis.Text = "0";
            //    if (lblsubtotal.Text != "" && Decimal.Parse(lblsubtotal.Text) != 0 && lblsubtotal.Text != null)
            //    {
            //        //hz ve lithum disc dan etkilenmeyecek
            //        decimal hztotal = 0;

            //        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            //        {
            //            if (dgQuotationAddedItems.Rows[i].Cells["HS"].Style.BackColor == Color.Red)
            //            {
            //                hztotal += Decimal.Parse(String.Format("{0:N}", decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString())));
            //            }
            //            else if (dgQuotationAddedItems.Rows[i].Cells["LI"].Style.BackColor == Color.Ivory)
            //            {
            //                hztotal += Decimal.Parse(String.Format("{0:N}", decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString())));
            //            }
            //            //else if ()//HE için
            //            //{

            //            //}
            //        }
            //        //
            //        int workerID = Utils.getCurrentUser().WorkerID;
            //        decimal Minmarge = Decimal.Parse(String.Format("{0:N}", (decimal)IME.Workers.Where(x => x.WorkerID == workerID).FirstOrDefault().MinMarge));
            //        if (Convert.ToDecimal(txtTotalDis.Text) > Minmarge)
            //        {
            //            MessageBox.Show("Low Price ! Ask for authorization");
            //            txtTotalDis.Text = "0";
            //            txtTotalDis2.Text = "0";
            //        }
            //        else
            //        {
            //            decimal subtotal = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(lblsubtotal.Text) - decimal.Parse(hztotal.ToString())));
            //            //decimal dis2 = Math.Round(subtotal * Decimal.Parse(txtTotalDis.Text) / 100,0);
            //            decimal dis2 = Decimal.Parse(String.Format("{0:N}", ((decimal.Parse(subtotal.ToString()) * Decimal.Parse(txtTotalDis.Text)) / 100)));
            //            txtTotalDis2.Text = String.Format("{0:N}", decimal.Parse(dis2.ToString()));
            //            //lbltotal.Text = Math.Round((Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)), 4).ToString();
            //            lbltotal.Text = String.Format("{0:N}", (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)));
            //        }
            //    }

            //}
            //Disc();
            //txtTotalDis2.Text = String.Format("{0:N}", Decimal.Parse(txtTotalDis2.Text));
            #endregion

            #region Yeni Formül
            if (lblsubtotal.Text != null && lblsubtotal.Text != string.Empty)
            {
                if (txtTotalDis.Text == null || txtTotalDis.Text == "") txtTotalDis.Text = "0";
                if (lblsubtotal.Text != "" && Decimal.Parse(lblsubtotal.Text) != 0 && lblsubtotal.Text != null)
                {
                    //hz ve lithum disc dan etkilenmeyecek
                    decimal hztotal = 0;

                    int workerID = Utils.getCurrentUser().WorkerID;
                    decimal Minmarge = Decimal.Parse(String.Format("{0:N}", (decimal)IME.Workers.Where(x => x.WorkerID == workerID).FirstOrDefault().MinMarge));

                    for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                    {
                        //if (dgQuotationAddedItems.Rows[i].Cells["HS"].Style.BackColor != Color.Red && dgQuotationAddedItems.Rows[i].Cells["LI"].Style.BackColor != Color.Ivory)
                        if (txtHazardousInd.Text != "Y" && txtLithium.Text != "Y")
                        {
                            hztotal += Decimal.Parse(String.Format("{0:N}", decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString())));


                        }
                    }

                    if (Convert.ToDecimal(txtTotalDis.Text) > Minmarge)
                    {
                        MessageBox.Show("Low Price ! Ask for authorization");
                        txtTotalDis.Text = "0";
                        txtTotalDis2.Text = "0";
                    }
                    else
                    {
                        if (hztotal != 0)
                        {
                            decimal subtotal = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(lblsubtotal.Text) - decimal.Parse(hztotal.ToString())));
                            //decimal dis2 = Math.Round(subtotal * Decimal.Parse(txtTotalDis.Text) / 100,0);
                            decimal dis2 = Decimal.Parse(String.Format("{0:N}", ((decimal.Parse(subtotal.ToString()) * Decimal.Parse(txtTotalDis.Text)) / 100)));
                            txtTotalDis2.Text = String.Format("{0:N}", decimal.Parse(dis2.ToString()));
                            //lbltotal.Text = Math.Round((Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)), 4).ToString();
                            lbltotal.Text = String.Format("{0:N}", (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)));
                        }
                        else
                        {
                            MessageBox.Show("Item is kind a hazardous");
                            txtTotalDis.Text = "0.00";
                        }
                    }
                }

            }
            Disc();
            txtTotalDis2.Text = String.Format("{0:N}", Decimal.Parse(txtTotalDis2.Text));
            #endregion
        }

        public void ChangeDataGrid()
        {
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                if (dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value != null)
                {
                    decimal total = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()) * Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                    dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value = ((total) - (((total) * Decimal.Parse(txtTotalDis2.Text)) / Decimal.Parse(lblsubtotal.Text))).ToString();
                    dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = Decimal.Parse(String.Format("{0:N}", (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString()) / Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString()));

                }
            }
        }

        /// <summary>
        /// Calculates Total Margin after general discount
        /// </summary>
        private void CalculateTotalMarge()
        {
            if (dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value.ToString() != "")
            {
                decimal AllMargin = 0;
                if (cbDeliverDiscount.Checked)
                {
                    foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                    {
                        decimal Margin = 0;
                        decimal Total = 0;
                        try { Margin = decimal.Parse(item.Cells[dgMargin.Index].Value.ToString()); } catch { }
                        try { Total = decimal.Parse(item.Cells[dgTotal.Index].Value.ToString()); } catch { }
                        try
                        {
                            AllMargin = AllMargin + (Margin * Total);
                        }
                        catch { }
                    }
                }
                else
                {

                    for (int i = 0; i < dgQuotationAddedItems.RowCount - 1; i++)
                    {
                        if (!String.IsNullOrEmpty(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString()))
                        {
                            //(1-(Cost/U/C U/P))*100
                            decimal cost = 0;
                            decimal DiscountRate = 0;
                            decimal UCUP = 0;
                            decimal totalDiscount = 0;
                            decimal margin = 0;
                            //try { ucupcurr = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString()); } catch { }
                            try
                            { DiscountRate = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgDisc.Index].Value.ToString()); }
                            catch { }
                            try { totalDiscount = DiscountRate + decimal.Parse(txtTotalDis.Text); } catch { }
                            try { cost = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString()); } catch { }
                            cost = cost / Currfactor;
                            try { UCUP = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUPIME.Index].Value.ToString()); } catch { }
                            decimal total = 0;
                            try { total = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString()); } catch { }
                            UCUP = (UCUP * (100 - totalDiscount)) / 100;
                            margin = (1 - (cost / UCUP)) * 100;
                            AllMargin = AllMargin + (margin * total);
                        }
                    }
                }
                if (lblsubtotal.Text != null && lblsubtotal.Text != "" && AllMargin != 0) AllMargin = AllMargin / decimal.Parse(lblsubtotal.Text);
                //if (AllMargin != 0)
                //{
                //    txtTotalMargin.Text = Math.Round(AllMargin, 3).ToString();
                //}
                //else
                //{
                //    txtTotalMargin.Text = (0.00).ToString();
                //}
            }
        }
        private decimal calculateTotalMargin()
        {
            DateTime today = DateTime.Today;
            CurrentRow = dgQuotationAddedItems.CurrentRow;
            #region Kur Hesaplama
            decimal currentGbpValue = Convert.ToDecimal(IME.Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);

            #endregion

            decimal totalCost = 0;
            decimal totalPrice = 0;

            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
            {
                decimal gbpPrice = 0;
                if (item.Cells[dgTotal.Index].Value != null && item.Cells[dgTotal.Index].Value.ToString() != "" && item.Cells[dgUCUPCurr.Index].Value != null && item.Cells[dgUCUPCurr.Index].Value.ToString() != "")
                {
                    gbpPrice = Convert.ToDecimal(String.Format("{0:N}", ((Convert.ToDecimal(item.Cells[dgTotal.Index].Value.ToString())) * CurrValue) / currentGbpValue));
                }
                if (item.Cells[dgLandingCost.Index].Value != null && item.Cells[dgLandingCost.Index].Value.ToString() != "" && item.Cells[dgQty.Index].Value != null && item.Cells[dgQty.Index].Value.ToString() != "" && item.Cells[dgQty.Index].Value.ToString() != "0")
                {
                    totalCost += Convert.ToDecimal(String.Format("{0:N}", Convert.ToDecimal(item.Cells[dgLandingCost.Index].Value) * Convert.ToDecimal(item.Cells[dgQty.Index].Value)));

                    totalPrice += Convert.ToDecimal(String.Format("{0:N}", gbpPrice));
                }
            }

            if (cbDeliverDiscount.Checked)
            {
                return Convert.ToDecimal(String.Format("{0:N}", ((1 - (totalCost / totalPrice)) * 100)));
            }
            else
            {
                decimal Disc = 0;
                decimal gbpDisc = 0;
                if (!String.IsNullOrEmpty(txtTotalDis2.Text) && txtTotalDis2.Text!=0.ToString())
                {
                    Disc = Convert.ToDecimal(String.Format("{0:N}", txtTotalDis2.Text));
                    gbpDisc = Convert.ToDecimal(String.Format("{0:N}", (Disc * CurrValue) / currentGbpValue));
                }
                return Convert.ToDecimal(String.Format("{0:N}", ((1 - (totalCost / (totalPrice - gbpDisc))) * 100)));
            }
        }

        private decimal calculateTotalMarginFirst()
        {
            DateTime today = DateTime.Today;
            CurrentRow = dgQuotationAddedItems.CurrentRow;
            #region Kur Hesaplama
            decimal currentGbpValue = Convert.ToDecimal(IME.Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);

            #endregion

            decimal totalCost = 0;
            decimal totalPrice = 0;

            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
            {
                decimal gbpPrice = 0;
                if (item.Cells[dgTotal.Index].Value != null && item.Cells[dgTotal.Index].Value.ToString() != "" && item.Cells[dgFirstUPIME.Index].Value != null && item.Cells[dgFirstUPIME.Index].Value.ToString() != "")
                {
                    gbpPrice = Convert.ToDecimal(String.Format("{0:N}", ((Convert.ToDecimal(item.Cells[dgTotal.Index].Value.ToString())) * CurrValue) / currentGbpValue));
                }
                if (item.Cells[dgLandingCost.Index].Value != null && item.Cells[dgLandingCost.Index].Value.ToString() != "" && item.Cells[dgQty.Index].Value != null && item.Cells[dgQty.Index].Value.ToString() != "" && item.Cells[dgQty.Index].Value.ToString() != "0")
                {
                    totalCost = Convert.ToDecimal(String.Format("{0:N}", totalCost + Convert.ToDecimal(item.Cells[dgLandingCost.Index].Value) * Convert.ToDecimal(item.Cells[dgQty.Index].Value)));
                    totalPrice = Convert.ToDecimal(String.Format("{0:N}", totalPrice + gbpPrice));
                }
            }

            if (cbDeliverDiscount.Checked)
            {
                return ((1 - (totalCost / totalPrice)) * 100);
            }
            else
            {
                decimal Disc = 0;
                decimal gbpDisc = 0;
                if (!String.IsNullOrEmpty(txtTotalDis2.Text) && txtTotalDis2.Text != 0.ToString())
                {
                    Disc = Convert.ToDecimal(String.Format("{0:N}", txtTotalDis2.Text));
                    gbpDisc = Convert.ToDecimal(String.Format("{0:N}", (Disc * CurrValue) / currentGbpValue));
                }
                return Convert.ToDecimal(String.Format("{0:N}", ((1 - (totalCost / (totalPrice - gbpDisc))) * 100)));
            }
        }

        private void txtExtraChanges_TextChanged(object sender, EventArgs e)
        {
            decimal ExtraCharge = 0;

            try { ExtraCharge = Convert.ToDecimal(String.Format("{0:N}", Decimal.Parse(txtExtraChanges.Text))); } catch { }
            lblTotalExtra.Text = String.Format("{0:N}", (ExtraCharge + Decimal.Parse(lbltotal.Text)).ToString());
        }

        private void txtExtraChanges_Leave(object sender, EventArgs e)
        {
            if (txtExtraChanges.Text != null && txtExtraChanges.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtExtraChanges.Text);
                //sonuc = Math.Round(sonuc, 4);
                sonuc = Convert.ToDecimal(String.Format("{0:N}", sonuc));
                txtExtraChanges.Text = String.Format("{0:N}", sonuc.ToString());
            }
        }

        private void txtExtraChanges_Click(object sender, EventArgs e)
        {
            if (txtExtraChanges.Text != null && txtExtraChanges.Text != "")
            {
                decimal sonuc = Convert.ToDecimal(String.Format("{0:N}", Decimal.Parse(txtExtraChanges.Text)));
                txtExtraChanges.Text = String.Format("{0:N}", sonuc.ToString());
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            cbCurrency.DataSource = null;
            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            GetAllMargin();
        }

        private bool GetUserAutorities(int AuthorizationID)
        {
            List<AuthorizationValue> UserAutorityList = Utils.getCurrentUser().AuthorizationValues.ToList();
            if (UserAutorityList.Where(a => a.AuthorizationID == AuthorizationID).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        private void VisibleCostMarginTrue()
        {
            label50.Visible = true;
            txtUK1.Visible = true;
            txtUK2.Visible = true;
            txtUK3.Visible = true;
            txtUK4.Visible = true;
            txtUK5.Visible = true;
            label50.Visible = true;
            txtUK1.Visible = true;
            txtUK2.Visible = true;
            txtUK3.Visible = true;
            txtUK4.Visible = true;
            txtUK5.Visible = true;
            label36.Visible = true;
            txtCost1.Visible = true;
            txtCost2.Visible = true;
            txtCost3.Visible = true;
            txtCost4.Visible = true;
            txtCost5.Visible = true;
            txtMargin1.Visible = true;
            txtMargin2.Visible = true;
            txtMargin3.Visible = true;
            txtMargin4.Visible = true;
            txtMargin5.Visible = true;
        }

        private void btnProductHistory_Click(object sender, EventArgs e)
        {
            #region ProductHistory
            string item_code = null;
            
            btnProductHistory.Text = "Product History";

            if (!String.IsNullOrEmpty(dgQuotationAddedItems.CurrentRow.Cells["dgProductCode"].Value.ToString()))
                item_code = dgQuotationAddedItems.CurrentRow.Cells["dgProductCode"].Value.ToString();
            if (item_code == null)
                MessageBox.Show("Please Enter an Item Code", "Error!");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Item quoted before", "", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    ViewProductHistory f = new ViewProductHistory(item_code, "Quotation");
                    try { f.ShowDialog(); } catch { }
                }
            }
            #endregion
        }

        private void dgQuotationAddedItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                string ArticleNO = null;
                if (dgQuotationAddedItems.CurrentCell.Value != null) ArticleNO = dgQuotationAddedItems.CurrentCell.Value.ToString();
                FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(ArticleNO);
                itemsearch.ShowDialog();
                this.Enabled = true;
                try
                {
                    //Bu item daha önceden eklimi diye kontrol ediyor
                    DataGridViewRow row = dgQuotationAddedItems.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["dgProductCode"].Value.ToString().Equals(QuotationUtils.ItemCode)).FirstOrDefault();
                    if (!String.IsNullOrEmpty(row.Cells["dgUCUPCurr"].Value.ToString()))
                    {
                        if (row != null) MessageBox.Show("There is already an item added this qoutation in the " + row.Cells["dgNo"].Value.ToString() + ". Row and the price " + row.Cells["dgUCUPCurr"].Value.ToString());

                    }
                    else
                    {
                        if (row != null) MessageBox.Show("There is already an item added this qoutation in the " + row.Cells["dgNo"].Value.ToString() + ". Row");

                    }
                }
                catch { }
                int sdNumber = 0, sdPNumber = 0, erNumber = 0;
                dgQuotationAddedItems.CurrentCell.Value = QuotationUtils.ItemCode;
                if (dgQuotationAddedItems.CurrentCell.Value != null)
                {
                    try { sdNumber = IME.SuperDisks.Where(a => a.Article_No.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdNumber = 0; }
                    try { sdPNumber = IME.SuperDiskPs.Where(a => a.Article_No.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdPNumber = 0; }
                    try { erNumber = IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { erNumber = 0; }
                    if (sdNumber == 1 || sdPNumber == 1 || erNumber == 1)
                    {
                        if (QuotationUtils.HasMultipleItems(dgQuotationAddedItems.CurrentCell.Value.ToString()) == 0)
                        {
                            if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
                            ItemDetailsFiller(dgQuotationAddedItems.CurrentCell.Value.ToString());
                            //LandingCost Calculation
                            FillProductCodeItem();

                            dgQuotationAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                            dgQuotationAddedItems.CurrentRow.Cells["dgQty"].Value = null;
                            dgQuotationAddedItems.CurrentRow.Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;
                            #region DataGridClear
                            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value = null;
                            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgDisc"].Value = null;
                            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
                            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUPIME"].Value = null;
                            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[dgFirstUPIME.Index].Value = null;
                            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value = null;

                            CalculateSubTotal();
                            txtSubstitutedBy.Text = null;
                            #endregion
                        }
                    }
                }
            }
        }

        private void DeletedQuotationMenu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgQuotationDeleted.SelectedRows)
            {
                if (!String.IsNullOrEmpty(item.Cells["dgProductCode1"].Value.ToString()))
                {
                    int rowindex = item.Index;
                    int no = Int32.Parse(dgQuotationDeleted.Rows[rowindex].Cells["No1"].Value.ToString());

                    int rowindex1 = dgQuotationAddedItems.RowCount;

                    dgQuotationAddedItems.Rows.Add();
                    decimal row1 = Decimal.Parse(dgQuotationAddedItems.Rows[rowindex1].Cells[dgNo.Index].Value.ToString());

                    //for (int i = 0; i < dgQuotationAddedItems.Rows.Count; i++)
                    //{
                    //    //if(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString())== Int32.Parse(dgQuotationDeleted.Rows[item.Index].Cells[0].Value.ToString())&& (dgQuotationAddedItems.Rows[i].Cells[7].Value=="" || dgQuotationAddedItems.Rows[i].Cells[7].Value==null))
                    //    //{
                    //    //    dgQuotationAddedItems.Rows.Remove(dgQuotationAddedItems.Rows[i]);
                    //    //    rowindex1--;
                    //    //}
                    //}

                    for (int i = 0; i < dgQuotationDeleted.Columns.Count; i++)
                    {
                        dgQuotationAddedItems.Rows[rowindex1].Cells[i].Value = dgQuotationDeleted.Rows[item.Index].Cells[i].Value;
                    }
                    dgQuotationAddedItemsRowChange();
                    dgQuotationDeleted.Rows.Remove(dgQuotationDeleted.Rows[rowindex]);

                }
                else { MessageBox.Show("Please choose an item to add Quotation"); }
            }

            //dgQuotationAddedItems.Sort()
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString());
            }
            dgQuotationAddedItems.Sort(dgQuotationAddedItems.Columns[0], ListSortDirection.Ascending);
            CalculateSubTotal();
        }

        private void DeliverDiscount()
        {
            decimal subtotal = 0;
            if (cbDeliverDiscount.Checked)
            {
                txtTotalDis.Enabled = false;
                txtTotalDis2.Enabled = false;
                chkFirstUPIME.Enabled = false;

                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    if (item.Cells[dgProductCode.Index].Value != null)
                    {
                        if (item.Cells[HS.Index].Style.BackColor != Color.Red && item.Cells[LI.Index].Style.BackColor != Color.Red)
                        {
                            decimal UCUPCurr = 0;
                            decimal DiscountedUCUPCurr = decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString());
                            decimal disc = 0;
                            if (txtTotalDis.Text != null && txtTotalDis.Text != string.Empty)
                            {
                                disc = Decimal.Parse(txtTotalDis.Text);
                            }
                            UCUPCurr = DiscountedUCUPCurr * ((100 - disc) / 100);
                            decimal UPIME  = 0;
                            if (chkFirstUPIME.Checked)
                            {
                                UPIME = decimal.Parse(item.Cells[dgFirstUPIME.Index].Value.ToString());
                            }
                            else
                            {
                                UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                            }
                            //item.Cells[dgDisc.Index].Value = Math.Round((100 - ((UCUPCurr * 100) / UPIME)), 2).ToString();
                            //item.Cells[dgUCUPCurr.Index].Value = (Math.Round(UCUPCurr, 2)).ToString();
                            item.Cells[dgDisc.Index].Value = String.Format("{0:N}", decimal.Parse((100 - ((UCUPCurr * 100) / UPIME)).ToString()));
                            item.Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", decimal.Parse(UCUPCurr.ToString()));
                            //if (Convert.ToInt32(CurrentRow.Cells[dgSSM.Index].Value.ToString()) > 1 || Convert.ToInt32(CurrentRow.Cells[dgUC.Index].Value.ToString()) > 1)
                            //{
                            //    item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                            //}
                            if (chkFirstUPIME.Checked)
                            {
                                item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgFirstUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                            }
                            else
                            {
                                item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                            }
                            decimal quantity = 0;
                            quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                            item.Cells[dgTotal.Index].Value = UCUPCurr * quantity;
                            subtotal += (UCUPCurr * quantity);
                        }
                        else
                        {
                            decimal quantity = 0;
                            quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                            decimal UPIME = decimal.Parse(item.Cells[dgFirstUPIME.Index].Value.ToString());
                            subtotal = subtotal + (UPIME * quantity);
                        }
                    }
                }
                totallbl = subtotal;
                lbltotal.Text = String.Format("{0:N}", subtotal.ToString());
            }
            else
            {
                txtTotalDis.Enabled = true;
                txtTotalDis2.Enabled = false;
                if (this.Text != "Add Quotation") chkFirstUPIME.Enabled = true;

                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    if (item.Cells[dgProductCode.Index].Value != null)
                    {
                        if (item.Cells[HS.Index].Style.BackColor != Color.Red && item.Cells[LI.Index].Style.BackColor != Color.Red)
                        {
                            if (!String.IsNullOrEmpty(item.Cells["dgTotal"].Value.ToString()))
                            {
                                decimal UPIME = 0;
                                decimal total = 0;
                                decimal txtdisc = 0;
                                decimal UCUPCurr = 0;
                                decimal datagriddisc = 0;
                                decimal quantity = 0;
                                quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                                if (txtTotalDis.Text != null && txtTotalDis.Text != "") txtdisc = decimal.Parse(txtTotalDis.Text);
                                total = decimal.Parse(item.Cells[dgTotal.Index].Value.ToString());
                                total = total / quantity;
                                if (chkFirstUPIME.Checked)
                                {
                                    UPIME = decimal.Parse(item.Cells[dgFirstUPIME.Index].Value.ToString());
                                }
                                else
                                {
                                    UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                                }
                                datagriddisc = 100 - (100 * (total * 100 / (100 - txtdisc)) / UPIME);
                                //item.Cells[dgDisc.Index].Value = Math.Round(datagriddisc, 2).ToString();
                                item.Cells[dgDisc.Index].Value = String.Format("{0:N}", decimal.Parse(datagriddisc.ToString()));
                                UCUPCurr = (UPIME * (100 - datagriddisc)) / 100;
                                //item.Cells[dgUCUPCurr.Index].Value = (Math.Round(UCUPCurr, 2)).ToString();
                                item.Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", decimal.Parse(UCUPCurr.ToString()));
                                //if (Convert.ToInt32(CurrentRow.Cells[dgSSM.Index].Value.ToString()) > 1 || Convert.ToInt32(CurrentRow.Cells[dgUC.Index].Value.ToString()) > 1)
                                //{
                                //    item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                                //}
                                if (chkFirstUPIME.Checked)
                                {
                                    item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgFirstUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                                }
                                else
                                {
                                    item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                                }
                                
                                //item.Cells[dgTotal.Index].Value = Math.Round((UCUPCurr * quantity), 2);
                                item.Cells[dgTotal.Index].Value = UCUPCurr * quantity;
                                subtotal = subtotal + (UCUPCurr * quantity);
                            }
                        }
                        else
                        {
                            decimal quantity = 0;
                            quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                            decimal UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                            subtotal = subtotal + (UPIME * quantity);
                        }
                    }

                }
            }

            lblsubtotal.Text = subtotal.ToString();
            lbltotal.Text = String.Format("{0:N}", totallbl.ToString());
            GetAllMargin();

            //txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
            txtTotalMargin.Text = String.Format("{0:N}", calculateTotalMargin());
        }

        private void cbDeliverDiscount_CheckedChanged(object sender, EventArgs e)
        {
            DeliverDiscount();
        }

        private void cbFactor_Leave(object sender, EventArgs e)
        {
            #region Faktör Değişimi
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                bool isHZ = false;
                if (dgQuotationAddedItems.Rows[i].Cells["HS"].Style.BackColor == Color.Red)
                {
                    isHZ = true;
                }
                else if (dgQuotationAddedItems.Rows[i].Cells["LI"].Style.BackColor == Color.Ivory)
                {
                    isHZ = true;
                }

                //else if ()//HE için
                //{
                //isHZ = true;
                //}
                if (!isHZ)
                {
                    GetLandingCost(i);
                    GetQuotationQuantity(i);
                }
            }
            #endregion

            GetAllMargin();
        }

        private void btnImportFromXML_Click(object sender, EventArgs e)
        {
            XmlObject xml;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml files (*.xml)|*.xml";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                xml = new XmlObject(openFileDialog.FileName);

                XmlToCustomer(xml.XmlGetCustomerData());

                XmlToDataGrid(xml.XmlGetProductInfo());

                //int index = 0;
                //List<XmlProduct> productList = xml.XmlGetProductInfo();
                //foreach (XmlProduct product in productList)
                //{
                //    if (index + 1 != productList.Count())
                //    {
                //        dgQuotationAddedItems.Rows.Add();
                //    }
                //    DataGridViewCell cell = dgQuotationAddedItems.Rows[index].Cells[dgProductCode.Index];
                //    cell.Value = product.StockCode;
                //    dgQuotationAddedItems.CurrentCell = cell;
                //    ItemDetailsFiller(product.StockCode);
                //    DataGridViewCell curCell = dgQuotationAddedItems.Rows[cell.RowIndex].Cells[dgQty.Index];
                //    dgQuotationAddedItems.CurrentCell = curCell;
                //    //dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].ReadOnly = false;
                //    //dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Style = dgQuotationAddedItems.DefaultCellStyle;
                //    curCell.Value = product.Quantity;
                //    dgQuotationAddedItems_CellEndEdit(null, null);
                //    SendKeys.Send("{TAB}");
                //    index++;
                //}
            }
        }

        private void XmlToDataGrid(List<XmlProduct> XmlProductList)
        {
            int index = 0;
            foreach (XmlProduct product in XmlProductList)
            {
                if (index + 1 != XmlProductList.Count())
                {
                    dgQuotationAddedItems.Rows.Add();
                }
                DataGridViewCell cell = dgQuotationAddedItems.Rows[index].Cells[dgProductCode.Index];
                cell.Value = product.StockCode;
                dgQuotationAddedItems.CurrentCell = cell;
                ItemDetailsFiller(product.StockCode);
                DataGridViewCell curCell = dgQuotationAddedItems.Rows[cell.RowIndex].Cells[dgQty.Index];
                dgQuotationAddedItems.CurrentCell = curCell;
                dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].ReadOnly = false;
                //dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Style = dgQuotationAddedItems.DefaultCellStyle;
                curCell.Value = product.Quantity;
                dgQuotationAddedItems_CellEndEdit(null, null);
                SendKeys.Send("{TAB}");
                index++;
            }
        }

        private void XmlToCustomer(XmlCustomer xmlCustomer)
        {
            QuotationUtils.customersearchID = CustomerCode.Text;
            QuotationUtils.customersearchname = xmlCustomer.Name;
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(xmlCustomer);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                customer = form.customer;
                cbWorkers.Items.AddRange(customer.CustomerWorkers.ToArray());
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.ValueMember = "ID";
            }
            this.Enabled = true;
            fillCustomer();
        }

        private void dgQuotationAddedItemsRowChange()
        {
            CalculateSubTotal();
            calculateTotalCost();
            try
            {
                //txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
                txtTotalMargin.Text = String.Format("{0:N}", calculateTotalMargin());
            }
            catch { }
            Disc();
        }

        private void dgQuotationAddedItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgQuotationAddedItems.Rows.Count == 0)
            {

                dgQuotationAddedItems.Rows.Add();
                dgQuotationAddedItems.Rows[0].Cells[dgNo.Index].Value = "1";
            }
            dgQuotationAddedItemsRowChange();
        }

        private void btnCustomizeGrid_Click(object sender, EventArgs e)
        {
            frmQuotationGridCustomize form = new frmQuotationGridCustomize(dgQuotationAddedItems);
            form.ShowDialog();
            

            List<int> quotationVisibleFalseNames = QuotationDatagridCustomize.VisibleFalseNames;
            List<int> quotationVisibleTrueNames = QuotationDatagridCustomize.VisibleTrueNames;
            foreach (DataGridViewColumn item in dgQuotationAddedItems.Columns)
            {
                if (item.Name != "dgHZ" && item.Name != "dgCL" && item.Name != "dgCR") item.Visible = true;
            }
            foreach (var item in quotationVisibleFalseNames)
            {
                dgQuotationAddedItems.Columns[item].Visible = false;
            }
            //sayac = dgQuotationAddedItems.ColumnCount - QuotationDatagridCustomize.VisibleFalseNames.Count;
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            List<string> QuotationItemList = new List<string>();
            for (int i = 0; i < dgQuotationAddedItems.ColumnCount; i++)
            {
                QuotationItemList.Add(dgQuotationAddedItems.Columns[i].HeaderText);
            }
            frmQuotationExport form = new frmQuotationExport(QuotationItemList, (txtQuotationNo.Text.Substring(txtQuotationNo.Text.LastIndexOf('/') + 1)).ToString(), dgQuotationAddedItems);
            form.ShowDialog();

        }

        private void txtTotalDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtTotalDis2.Focus();
                lbltotal.Focus();
            }
        }

        private void OnlineProduct()
        {
            //string articleNo = "";
            //articleNo = dgQuotationAddedItems.CurrentCell.Value.ToString();
            //if (articleNo.Contains("-"))
            //{
            //    articleNo = articleNo.Replace("-", "");
            //    dgQuotationAddedItems.CurrentCell.Value = articleNo;
            //}
            //if (articleNo.Length == 6)
            //{
            //    articleNo = "0" + articleNo;
            //    dgQuotationAddedItems.CurrentCell.Value = articleNo;
            //}


            //var articleList = IME.ArticleSearch(articleNo).ToList();
            //if (articleList.Count == 1)
            //{
            //    if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString() != "" && dgQuotationAddedItems.CurrentRow.Cells[dgDesc.Index].Value != null && dgQuotationAddedItems.CurrentRow.Cells[dgDesc.Index].Value.ToString() != "")
            //    {
            //        DataGridViewRow rowsss = (DataGridViewRow)dgQuotationAddedItems.CurrentRow;
            //        for (int i = 11; i < rowsss.Cells.Count; i++)
            //        {
            //            rowsss.Cells[i].Value = "";
            //        }
            //    }
            //    if (!Discontinued(articleNo))
            //    {
            //        List<string> SameItemIndexList = new List<string>();
            //        string _IndexList = string.Empty;
            //        for (int i = 0; i < dgQuotationAddedItems.RowCount - 1; i++)
            //        {
            //            if (dgQuotationAddedItems.Rows[i].Cells[dgProductCode.Index].Value.ToString() == articleNo &&
            //                dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value == null)
            //            {
            //                SameItemIndexList.Add(dgQuotationAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString());
            //            }
            //        }
            //        if (SameItemIndexList != null && SameItemIndexList.Count > 0)
            //        {
            //            foreach (string item in SameItemIndexList)
            //            {
            //                _IndexList = _IndexList + item + ", ";
            //            }

            //            MessageBox.Show("This item is already added in row(s): " + _IndexList);
            //        }
            //        tabControl1.SelectedTab = tabItemDetails;
            //        dgQuotationAddedItems.Focus();
            //        ItemDetailsFiller(articleNo);//tekrar bakılacak
            //        FillProductCodeItem();
            //        if (txtWeb1.Text == "0" || txtWeb1.Text == "")
            //        {
            //            DialogResult dialogResult = MessageBox.Show("Item is not available in Price File, please check website and Enter price from ItemCard");
            //            ItemsClear();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("This Item is Discontinued");
            //    }
            //    (dgQuotationAddedItems.CurrentRow.Cells[dgDelivery.Index] as DataGridViewComboBoxCell).Value = 3;
            //    (dgQuotationAddedItems.CurrentRow.Cells[dgStatus.Index] as DataGridViewComboBoxCell).Value = 1;
            //}
        }

        private void OnlineQty()
        {
            //if ((Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString())) == 0 && (Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells[dgUC.Index].Value.ToString())) == 0)
            //    {
            //        DgQuantityFiller();
            //        calculateTotalCost();
            //        if (CurrentRow.Cells["dgQty"].Value != null && CurrentRow.Cells["dgQty"].Value.ToString() != "")
            //        {
            //            if (txtStandartWeight.Text != "" && txtGrossWeight.Text != "")
            //            {
            //                if (Decimal.Parse(txtStandartWeight.Text) < (Decimal.Parse(txtGrossWeight.Text)))
            //                {
            //                    CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtGrossWeight.Text)).ToString();
            //                }
            //                else
            //                {
            //                    CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
            //                }
            //                CurrentRow.Cells["dgTotalWeight"].Value = (Decimal.Parse(CurrentRow.Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();
            //                CalculateTotalWeight();
            //            }
            //        }

            //        if (CurrentRow.Cells["dgQty"].Value != null && CurrentRow.Cells["dgQty"].Value.ToString() != "")
            //        {
            //            CurrentRow.Cells[dgUnitNetWeight.Index].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
            //            CurrentRow.Cells[dgUnitTotalNetWeight.Index].Value = (Decimal.Parse(CurrentRow.Cells[dgUnitNetWeight.Index].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();
            //            CalculateTotalNetWeight();
            //        }
            //        CurrentRow.Cells[dgFirstUPIME.Index].Value = String.Format("{0:N}", (Decimal.Parse(txtWeb1.Text))).ToString();


            //        if (txtGrossWeight.Text == "" && Convert.ToDecimal(txtGrossWeight.Text) == 0)
            //        {
            //            dgQuotationAddedItems.CurrentRow.Cells[WT.Index].Style.BackColor = Color.Red;
            //        }
            //        else if (Convert.ToDecimal(txtGrossWeight.Text) * Convert.ToDecimal(dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value.ToString()) > 5)
            //        {
            //            dgQuotationAddedItems.CurrentRow.Cells[WT.Index].Style.BackColor = Color.Orange;
            //        }
            //        else
            //        {
            //            dgQuotationAddedItems.CurrentRow.Cells[WT.Index].Style.BackColor = Color.Ivory;
            //        }
            //        if (chkFirstUPIME.Checked)
            //        {
            //            CurrentRow.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString());
            //            CurrentRow.Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString());
            //            CurrentRow.Cells[dgTotal.Index].Value = (Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString()) * Int32.Parse(CurrentRow.Cells[dgQty.Index].Value.ToString())).ToString();
            //            CurrentRow.Cells[dgTotal.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgTotal.Index].Value.ToString());
            //            CalculateSubTotalActivate();
            //        }
            //        else
            //        {
            //            CurrentRow.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(CurrentRow.Cells[dgUPIME.Index].Value.ToString());
            //            CurrentRow.Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString());
            //            CurrentRow.Cells[dgTotal.Index].Value = (Decimal.Parse(CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString()) * Int32.Parse(CurrentRow.Cells[dgQty.Index].Value.ToString())).ToString();
            //            CurrentRow.Cells[dgTotal.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.CurrentRow.Cells[dgTotal.Index].Value.ToString());
            //            CalculateSubTotal();
            //        }
            //    }
        }

        private void btnExQuotation_Click(object sender, EventArgs e)
        {
            #region Daha önce yazılan fonksyon, hiç kullanılmıyodu.
            frmEx_Quotation form = new frmEx_Quotation();
            form.ShowDialog();
            if (form.quo != null)
            {
                Quotation q = form.quo;/*IME.Quotations.Where(a => a.QuotationNo == classQuotationAdd.quotationNo).FirstOrDefault();*/
                dgQuotationAddedItems.Rows.Clear();
                dgQuotationAddedItems.Refresh();

                //int itemCount = -1;
                foreach (QuotationDetail item in q.QuotationDetails)
                {
                    //itemCount++;
                    if (dgQuotationAddedItems.RowCount != 1)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.Rows[0].Clone();
                        row.Cells[dgProductCode.Index].Value = item.ItemCode;
                        ItemDetailsFiller(item.ItemCode);
                        row.Cells[dgQty.Index].Value = item.Qty;
                        DgQuantityFiller();

                        if (QuotationUtils.IsWithItems == true)
                        {
                            row.Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                            row.Cells[dgFirstUPIME.Index].Value = item.FirstUPIME;
                            row.Cells[dgPacketUP.Index].Value = item.PacketUP;
                            row.Cells[dgDisc.Index].Value = item.Disc;
                        }
                        dgQuotationAddedItems.Rows.Add(row);
                        //GetQuotationQuantity(dgQuotationAddedItems.RowCount-1);
                    }
                    else
                    {
                        //int rowIndex = 0;
                        //if (itemCount > 0)
                        //{
                        //    rowIndex = dgQuotationAddedItems.Rows.Add();
                        //}
                        dgQuotationAddedItems.Rows[0].Cells[dgProductCode.Index].Value = item.ItemCode;
                        ItemDetailsFiller(item.ItemCode);
                        dgQuotationAddedItems.Rows[0].Cells[dgQty.Index].Value = item.Qty;
                        //GetQuotationQuantity(0);
                        DgQuantityFiller();
                        if (QuotationUtils.IsWithItems == true)
                        {
                            dgQuotationAddedItems.Rows[0].Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                            dgQuotationAddedItems.Rows[0].Cells[dgFirstUPIME.Index].Value = item.FirstUPIME;
                            dgQuotationAddedItems.Rows[0].Cells[dgPacketUP.Index].Value = item.PacketUP;
                            dgQuotationAddedItems.Rows[0].Cells[dgDisc.Index].Value = item.Disc;
                        }
                    }
                }
            }
            #endregion

        }

        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        DataGridViewCell currentCell = dgQuotationAddedItems.CurrentCell;
        //        dgQuotationAddedItems.EndEdit();
        //        dgQuotationAddedItems.CurrentCell = null;
        //        dgQuotationAddedItems.CurrentCell = currentCell;
        //        return true;
        //    }
        //    return base.ProcessDialogKey(keyData);
        //}

        private void dgQuotationAddedItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            #region Eski
            //if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value == null)
            //{
            //    if (e.ColumnIndex == dgProductCode.Index) // 1 should be your column index
            //    {
            //        int i;

            //        if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
            //        {
            //            e.Cancel = true;
            //            if (dgQuotationAddedItems.CurrentRow.Cells[dgDesc.Index].Value == null && dgQuotationAddedItems.CurrentRow.Cells[dgTotal.Index].Value == null)
            //            {
            //                //MessageBox.Show("");
            //                //dgQuotationAddedItems.Rows.(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].de);
            //            }
            //            else
            //            {
            //                // dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgQty.Index].Value = "";
            //                CurrentRow.Cells[dgQty.Index].Value = "";
            //                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (e.ColumnIndex == dgQty.Index) // 1 should be your column index
            //        {
            //            int i;

            //            if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
            //            {
            //                e.Cancel = true;
            //                if (dgQuotationAddedItems.CurrentRow.Cells[dgLandingCost.Index].Value == null && dgQuotationAddedItems.CurrentRow.Cells[dgMargin.Index].Value == null)
            //                {
            //                    MessageBox.Show("Please enter value !");
            //                }
            //                else
            //                {
            //                    dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value = "";
            //                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            if (e.ColumnIndex == dgQty.Index && dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    if ((dgQuotationAddedItems.CurrentRow.Cells[dgLandingCost.Index].Value == null && dgQuotationAddedItems.CurrentRow.Cells[dgMargin.Index].Value == null))
                    {
                        MessageBox.Show("Please enter value !");
                    }
                    else
                    {
                        dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value = "";
                        dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index];
                    }
                }
            }
        }

        private void dgQuotationDeleted_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgQty1.Index) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter integer");
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[dgQty.Index].Value = "";
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dgQuotationAddedItems.CurrentCell.Value.ToString());
        }

        private void MakeTextUpperCase(TextBox txtBox)
        {
            txtBox.Text = txtBox.Text.ToUpper();
        }

        private void btnImportFromExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xlsx files (*.xlsx,*.xls)| *.xlsx;*.xls";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                try
                {

                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                    Excel.Worksheet ws = wb.Worksheets[1];
                    string Rs_code = "";

                    for (int i = 2; i < ws.Columns.Count; i++)
                    {
                        Rs_code = ws.Cells[i, 3].Text;

                        if (Rs_code != "")
                        {
                            dgQuotationAddedItems.CurrentRow.Cells[dgSupplier.Index].Value = ws.Cells[i, 2].Text;
                            dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value = ws.Cells[i, 3].Text;
                            dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value = ws.Cells[i, 6].Text;
                        }
                        else
                        {
                            break;
                        }
                    }

                    MessageBox.Show("Succesfully");
                }
                catch (Exception)
                {

                    MessageBox.Show("Excel hatalı !");
                    dgQuotationAddedItems.Rows.Clear();
                    dgQuotationAddedItems.Refresh();
                }
            }
        }

        private string CreateQuotationID(QuotationIdMod mod, Quotation _q)
        {
            IMEEntities db = new IMEEntities();
            string NewID = String.Empty;

            switch (mod)
            {
                case QuotationIdMod.New:
                    if (db.Quotations.Count() == 0)
                    {
                        NewID=2019 + "/" + 1;
                        break;
                    }
                    else
                    {
                        Quotation q1 = db.Quotations.OrderByDescending(x => x.idYear).ThenByDescending(y => y.idNo).ThenByDescending(z => z.idVersion).FirstOrDefault();
                        NewID = DateTime.Now.AddYears(0).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture) + "/" + (q1.idNo + 1);
                        break;
                    }

                case QuotationIdMod.CreateVersion:
                    Quotation q2 = db.Quotations.Where(x => x.idYear == _q.idYear && x.idNo == _q.idNo).OrderByDescending(y => y.idVersion).FirstOrDefault();
                    NewID = q2.idYear + "/" + q2.idNo + "v" + (q2.idVersion + 1);
                    break;
                default:
                    break;
            }
            return NewID;
        }

        private string[] IDShredder(string qID)
        {
            string[] IdSections = new string[5];

            IdSections[0] = qID.Substring(0, 4);
            IdSections[1] = qID.Substring(4, 1);


            int vIndex = qID.IndexOf('v');
            if (vIndex == -1)
            {
                IdSections[2] = qID.Substring(5);
            }
            else
            {
                int IdLenght = vIndex - 5;

                IdSections[2] = qID.Substring(5, IdLenght);
                IdSections[3] = qID.Substring(vIndex, 1);
                IdSections[4] = qID.Substring(vIndex + 1);
            }

            return IdSections;
        }

        private void txtTotalDis2_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalMargin.Text != "  .")
            {
                //                txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
                txtTotalMargin.Text = String.Format("{0:N}", calculateTotalMargin());
                
            }
            else
            {
                foreach (var item in mainQuo.QuotationDetails)
                {
                    if (item.Marge != null)
                    {
                        totalmargin = totalmargin + item.Marge;
                    }
                }

                txtTotalMargin.Text = totalmargin.ToString();
            }
            totalmargin = 0;

            txtTotalDis2.Text = String.Format("{0:N}", txtTotalDis2.Text);
        }

        private void dgQuotationAddedItems_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                e.SortResult = decimal.Parse(e.CellValue1.ToString()).CompareTo(decimal.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }
        }
        
        private void FormQuotationAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Quotation quo = IME.Quotations.Where(q => q.QuotationNo == txtQuotationNo.Text).FirstOrDefault();
                if (quo != null)
                {
                    quo.ViewQuotation = true;
                    quo.ViewQuotationName = null;
                    IME.SaveChanges();

                }

                // this.Close();
            }
        }

        private void txtStandartWeight_TextChanged(object sender, EventArgs e)
        {
            //if (txtStandartWeight.Text != null && txtStandartWeight.Text != "" && txtGrossWeight.Text != null && txtGrossWeight.Text != "")
            //{
            //    if (Decimal.Parse(txtStandartWeight.Text) < (Decimal.Parse(txtGrossWeight.Text)))
            //    {
            //        CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtGrossWeight.Text)).ToString();
            //        CalculateTotalWeight();
            //    }
            //    else
            //    {
            //        CurrentRow.Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
            //        CalculateTotalWeight();
            //    }
            //}
        }

        private void CustomerFactor()
        {
            decimal CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;

            chkCustomerMarkup.Checked = false;
            dgQuotationAddedItems.Columns[dgMarkup.Index].Visible = false;

            if (dgQuotationAddedItems.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    if (item.Cells[dgProductCode.Index].Value != null)
                    {
                        if (item.Cells["HS"].Style.BackColor != Color.Red && item.Cells["LI"].Style.BackColor != Color.Ivory)
                        {
                            item.Cells[dgMarkup.Index].Value = "";
                            item.Cells[dgUCUPCurr.Index].Value = "";
                            item.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUKPrice.Index].Value.ToString()) * decimal.Parse(lblCustomerFactorValue.Text)));
                            //item.Cells[dgUCUPCurr.Index].Value = Math.Round(decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString()), 2).ToString();
                            item.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString())));

                            item.Cells[dgTotal.Index].Value = "";
                            item.Cells[dgTotal.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString()) * decimal.Parse(item.Cells[dgQty.Index].Value.ToString())));
                            //item.Cells[dgTotal.Index].Value = Math.Round(decimal.Parse(item.Cells[dgTotal.Index].Value.ToString()), 2).ToString();
                            item.Cells[dgTotal.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgTotal.Index].Value.ToString()).ToString()));

                            if (txtHazardousInd.Text == "")
                            {
                                #region Total
                                decimal ucupcurr = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells["dgUCUPCurr"].Value.ToString())));
                                decimal UcupIME = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells["dgUPIME"].Value.ToString())));
                                //decimal disc = Math.Round(((UcupIME - ucupcurr) * (decimal)100 / UcupIME), 4);
                                decimal disc = Decimal.Parse(String.Format("{0:N}", (UcupIME - ucupcurr) * (decimal)100 / UcupIME));
                                int workerID = Utils.getCurrentUser().WorkerID;
                                decimal Minmarge = Decimal.Parse(String.Format("{0:N}", (decimal)IME.Workers.Where(x => x.WorkerID == workerID).FirstOrDefault().MinMarge));
                                if (disc > Minmarge)
                                {
                                    MessageBox.Show("Low Price ! Ask for authorization");
                                    //dgQuotationAddedItems.CurrentCell = item.Cells[dgUCUPCurr.Index];
                                    item.Cells["dgUCUPCurr"].Value = Decimal.Parse(String.Format("{0:N}", UcupIME));

                                    item.Cells[dgPacketUP.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUKPrice.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString())));
                                    item.Cells["dgDisc"].Value = 0;
                                }
                                else
                                {
                                    item.Cells["dgDisc"].Value = disc;
                                }


                                GetMargin();
                                GetMarginMark();
                                #region Calculate Total Margin
                                try
                                {
                                    //txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
                                    txtTotalMargin.Text = String.Format("{0:N}", calculateTotalMargin());
                                }
                                catch (Exception ex)
                                {
                                    txtTotalMargin.Text = String.Format("{0:N}", calculateTotalMargin());
                                }

                                #endregion
                                CalculateSubTotal();
                                #endregion
                            }
                            else if (txtHazardousInd.Text == "Y")
                            {
                                item.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(String.Format("{0:N}", item.Cells[dgUPIME.Index].Value.ToString()));


                                item.Cells[dgPacketUP.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUKPrice.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString())));
                                MessageBox.Show("Hazardous Item - Discount not allowed");
                            }
                        }
                    }
                }
            }

            if (chkFirstUPIME.Checked == true)
            {
                CalculateSubTotalActivate();
            }
            else
            {
                CalculateSubTotal();
            }
        }

        private void MarkupFactor()
        {
            decimal CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;

            chkCustomerFactor.Checked = false;
            dgQuotationAddedItems.Columns[dgMarkup.Index].Visible = true;

            if (dgQuotationAddedItems.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    if (item.Cells[dgProductCode.Index].Value != null)
                    {
                        if (item.Cells["HS"].Style.BackColor != Color.Red && item.Cells["LI"].Style.BackColor != Color.Ivory)
                        {
                            item.Cells[dgMarkup.Index].Value = String.Format("{0:N}", decimal.Parse(lblCustomerMarkupValue.Text));
                            item.Cells[dgUCUPCurr.Index].Value = "";
                            item.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgLandingCost.Index].Value.ToString()) * decimal.Parse(lblCustomerMarkupValue.Text) * CurrentRate));
                            //item.Cells[dgUCUPCurr.Index].Value = Math.Round(decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString()), 2).ToString();
                            item.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString()).ToString()));
                            item.Cells[dgTotal.Index].Value = "";
                            item.Cells[dgTotal.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString()) * decimal.Parse(item.Cells[dgQty.Index].Value.ToString()) * CurrentRate));
                            //item.Cells[dgTotal.Index].Value = Math.Round(decimal.Parse(item.Cells[dgTotal.Index].Value.ToString()), 2).ToString();
                            item.Cells[dgTotal.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgTotal.Index].Value.ToString()).ToString()));
                        }
                    }
                }
            }

            if (chkFirstUPIME.Checked == true)
            {
                CalculateSubTotalActivate();
            }
            else
            {
                CalculateSubTotal();
            }
        }
        private void chkCustomerFactor_CheckedChanged(object sender, EventArgs e)
        {
            

            if (chkCustomerFactor.Checked == true)
            {
                CustomerFactor();
            }
            else
            {
                MarkupFactor();
                chkCustomerMarkup.Checked = true;
            }
            
        }

        private void chkCustomerMarkup_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkCustomerMarkup.Checked == true)
            {

                MarkupFactor();
            }
            else
            {
                CustomerFactor();
                chkCustomerFactor.Checked = true;
            }
            
        }

        private void chkCustomerDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (dgQuotationAddedItems.RowCount > 0)
            {
                if (chkCustomerDiscount.Checked)
                {
                    txtTotalDis.Enabled = false;
                    txtTotalDis2.Enabled = false;
                    txtTotalDis.Text = lblCustomerDiscountValue.Text;

                    decimal hztotal = 0;

                    for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                    {
                        if (dgQuotationAddedItems.Rows[i].Cells["HS"].Style.BackColor == Color.Red)
                        {
                            hztotal += decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString());
                        }
                        else if (dgQuotationAddedItems.Rows[i].Cells["LI"].Style.BackColor == Color.Ivory)
                        {
                            hztotal += decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString());
                        }
                    }

                    int workerID = Utils.getCurrentUser().WorkerID;
                    decimal Minmarge = (decimal)IME.Workers.Where(x => x.WorkerID == workerID).FirstOrDefault().MinMarge;
                    if (Convert.ToDecimal(txtTotalDis.Text) > Minmarge)
                    {
                        MessageBox.Show("Low Price ! Ask for authorization");
                        txtTotalDis.Text = "0";
                        txtTotalDis2.Text = "0";
                    }
                    else
                    {
                        decimal subtotal = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(lblsubtotal.Text) - hztotal));
                        decimal dis2 = Decimal.Parse(String.Format("{0:N}", ((subtotal * Decimal.Parse(txtTotalDis.Text)) / 100)));
                        txtTotalDis2.Text = String.Format("{0:N}", dis2.ToString());
                        //lbltotal.Text = Math.Round((Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)), 4).ToString();
                        lbltotal.Text = String.Format("{0:N}", (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)));
                    }

                    Disc();
                    cbDeliverDiscount.Enabled = false;
                }
                else
                {
                    txtTotalDis.Enabled = true;
                    txtTotalDis2.Enabled = false;
                    txtTotalDis.Text = "0";

                    decimal hztotal = 0;

                    for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                    {
                        if (dgQuotationAddedItems.Rows[i].Cells["HS"].Style.BackColor == Color.Red)
                        {
                            hztotal += decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString());
                        }
                        else if (dgQuotationAddedItems.Rows[i].Cells["LI"].Style.BackColor == Color.Ivory)
                        {
                            hztotal += decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString());
                        }
                    }

                    int workerID = Utils.getCurrentUser().WorkerID;
                    decimal Minmarge = (decimal)IME.Workers.Where(x => x.WorkerID == workerID).FirstOrDefault().MinMarge;
                    if (Convert.ToDecimal(txtTotalDis.Text) > Minmarge)
                    {
                        MessageBox.Show("Low Price ! Ask for authorization");
                        txtTotalDis.Text = "0";
                        txtTotalDis2.Text = "0";
                    }
                    else
                    {
                        decimal subtotal = Decimal.Parse(String.Format("{0:N}", Decimal.Parse(lblsubtotal.Text) - hztotal));
                        decimal dis2 = Decimal.Parse(String.Format("{0:N}", ((subtotal * Decimal.Parse(txtTotalDis.Text)) / 100)));
                        txtTotalDis2.Text = String.Format("{0:N}", dis2.ToString());
                        //lbltotal.Text = Math.Round((Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)), 4).ToString();
                        lbltotal.Text = String.Format("{0:N}", (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)));
                    }

                    Disc();
                    cbDeliverDiscount.Enabled = true;
                }
            }
            txtTotalDis2.Text = String.Format("{0:N}", (decimal.Parse(txtTotalDis2.Text)));
        }

        private void dgQuotationAddedItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBox value is not valid.")
            {
                object value = dgQuotationAddedItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void ActivateTrueFirst()
        {
            dgQuotationAddedItems.Columns[dgFirstUPIME.Index].Visible = true;
            lblsubtotal.Text = "0";
            CalculateSubTotalActivate();
            ActivateFirstMargin();
        }

        private void ActivateFalseFirst()
        {
            dgQuotationAddedItems.Columns[dgFirstUPIME.Index].Visible = false;
            lblsubtotal.Text = "0";
            CalculateSubTotal();
            PassiveFirstMargin();
            if (chkCustomerFactor.Checked == true)
            {
                CustomerFactor();
            }
            else
            {
                MarkupFactor();
            }
        }

        private void ActivateFirstDisc()
        {
            decimal subtotal = 0;
            if (cbDeliverDiscount.Checked)
            {
                txtTotalDis.Enabled = false;
                txtTotalDis2.Enabled = false;

                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    if (item.Cells[dgProductCode.Index].Value != null)
                    {
                        if (item.Cells[HS.Index].Style.BackColor != Color.Red && item.Cells[LI.Index].Style.BackColor != Color.Red)
                        {
                            decimal First = 0;
                            decimal DiscountedUCUPCurr = decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString());
                            decimal disc = 0;
                            if (txtTotalDis.Text != null && txtTotalDis.Text != string.Empty)
                            {
                                disc = Decimal.Parse(txtTotalDis.Text);
                            }
                            First = DiscountedUCUPCurr * ((100 - disc) / 100);
                            decimal UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                            //item.Cells[dgDisc.Index].Value = Math.Round((100 - ((UCUPCurr * 100) / UPIME)), 2).ToString();
                            //item.Cells[dgUCUPCurr.Index].Value = (Math.Round(UCUPCurr, 2)).ToString();
                            item.Cells[dgDisc.Index].Value = String.Format("{0:N}", decimal.Parse((100 - ((First * 100) / UPIME)).ToString()));
                            item.Cells[dgFirstUPIME.Index].Value = String.Format("{0:N}", decimal.Parse(First.ToString()));
                            //if (Convert.ToInt32(CurrentRow.Cells[dgSSM.Index].Value.ToString()) > 1 || Convert.ToInt32(CurrentRow.Cells[dgUC.Index].Value.ToString()) > 1)
                            //{
                            //    item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                            //}
                            item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                            decimal quantity = 0;
                            quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                            item.Cells[dgTotal.Index].Value = First * quantity;
                            subtotal += (First * quantity);
                        }
                        else
                        {
                            decimal quantity = 0;
                            quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                            decimal UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                            subtotal = subtotal + (UPIME * quantity);
                        }
                    }
                }
                totallbl = subtotal;
                lbltotal.Text = String.Format("{0:N}", subtotal.ToString());
            }
            else
            {
                txtTotalDis.Enabled = true;
                txtTotalDis2.Enabled = false;

                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    if (item.Cells[dgProductCode.Index].Value != null)
                    {
                        if (item.Cells[HS.Index].Style.BackColor != Color.Red && item.Cells[LI.Index].Style.BackColor != Color.Red)
                        {
                            if (!String.IsNullOrEmpty(item.Cells["dgTotal"].Value.ToString()))
                            {
                                decimal UPIME = 0;
                                decimal total = 0;
                                decimal txtdisc = 0;
                                decimal First = 0;
                                decimal datagriddisc = 0;
                                decimal quantity = 0;
                                quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                                if (txtTotalDis.Text != null && txtTotalDis.Text != "") txtdisc = decimal.Parse(txtTotalDis.Text);
                                total = decimal.Parse(item.Cells[dgTotal.Index].Value.ToString());
                                total = total / quantity;
                                UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                                datagriddisc = 100 - (100 * (total * 100 / (100 - txtdisc)) / UPIME);
                                //item.Cells[dgDisc.Index].Value = Math.Round(datagriddisc, 2).ToString();
                                item.Cells[dgDisc.Index].Value = String.Format("{0:N}", decimal.Parse(datagriddisc.ToString()));
                                First = (UPIME * (100 - datagriddisc)) / 100;
                                //item.Cells[dgUCUPCurr.Index].Value = (Math.Round(UCUPCurr, 2)).ToString();
                                item.Cells[dgFirstUPIME.Index].Value = String.Format("{0:N}", decimal.Parse(First.ToString()));
                                //if (Convert.ToInt32(CurrentRow.Cells[dgSSM.Index].Value.ToString()) > 1 || Convert.ToInt32(CurrentRow.Cells[dgUC.Index].Value.ToString()) > 1)
                                //{
                                //    item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                                //}
                                item.Cells[dgPacketUP.Index].Value = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString()) * decimal.Parse(item.Cells[dgSSM.Index].Value.ToString()) * decimal.Parse(item.Cells[dgUC.Index].Value.ToString());
                                //item.Cells[dgTotal.Index].Value = Math.Round((UCUPCurr * quantity), 2);
                                item.Cells[dgTotal.Index].Value = First * quantity;
                                subtotal = subtotal + (First * quantity);
                            }
                        }
                        else
                        {
                            decimal quantity = 0;
                            quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                            decimal UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                            subtotal = subtotal + (UPIME * quantity);
                        }
                    }

                }
            }

            lblsubtotal.Text = subtotal.ToString();
            lbltotal.Text = String.Format("{0:N}", totallbl.ToString());
            GetAllMargin();

            //txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
            txtTotalMargin.Text = String.Format("{0:N}", calculateTotalMargin());
        }

        private void chkFirstUPIME_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFirstUPIME.Checked)
            {
                //ActivateFirstDisc();
                groupBox1.Enabled = false;
                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    try
                    {

                        item.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgFirstUPIME.Index].Value.ToString())));
                    }
                    catch { }
                }
                ActivateTrueFirst();
            }
            else
            {
                //DeliverDiscount();
                groupBox1.Enabled = true;
                foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
                {
                    try
                    {

                        item.Cells[dgUCUPCurr.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString())));
                    }
                    catch { }
                }
                ActivateFalseFirst();
            }
        }

        private void ActivateFirstMargin()
        {
            decimal CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;

            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
            {
                if (item.Cells[dgProductCode.Index].Value != null)
                {
                    item.Cells[dgMargin.Index].Value = (1 - (decimal.Parse(item.Cells[dgLandingCost.Index].Value?.ToString()) / decimal.Parse(item.Cells[dgFirstUPIME.Index].Value?.ToString())) * CurrentRate) * 100;
                }
            }
            
        }

        private void PassiveFirstMargin()
        {
            decimal CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;

            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
            {
                if (item.Cells[dgProductCode.Index].Value != null)
                {
                    item.Cells[dgMargin.Index].Value = (1 - (decimal.Parse(item.Cells[dgLandingCost.Index].Value?.ToString()) / decimal.Parse(item.Cells[dgUCUPCurr.Index].Value?.ToString())) * CurrentRate) * 100;
                }
            }

        }

        private void dgQuotationAddedItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null)
            {

                if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString().Substring(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString().Length - 1, 1) == "P")
                {
                    if (new Sp_Item().GetProductHistoryWithArticleNo_P(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()) != null && new Sp_Item().GetProductHistoryWithArticleNo_P(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()).Rows.Count > 0)
                    {
                        btnProductHistory.ForeColor = Color.FromArgb(255, 68, 68);
                        btnProductHistory.Enabled = true;
                    }
                    else
                    {
                        btnProductHistory.ForeColor = Color.FromArgb(32, 31, 53);
                        btnProductHistory.Enabled = false;
                    }
                }
                else
                {
                    if (new Sp_Item().GetProductHistoryWithArticleNo(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()) != null && new Sp_Item().GetProductHistoryWithArticleNo(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()).Rows.Count > 0)
                    {
                        
                        btnProductHistory.ForeColor = Color.FromArgb(255, 68, 68);
                        btnProductHistory.Enabled = true;
                    }
                    else
                    {
                        btnProductHistory.ForeColor = Color.FromArgb(32, 31, 53);
                        btnProductHistory.Enabled = false;
                    }
                }

            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                if (dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value == null)
                {
                    MessageBox.Show("Please enter value !");
                }
                else
                {
                    dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value = "";
                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index];
                }
            }
        }

        private void dgQuotationAddedItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgQuotationAddedItems.CurrentCell.ColumnIndex == 8) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void lblCustomerFactorValue_Leave(object sender, EventArgs e)
        {
            
            if (chkCustomerFactor.Checked == true)
            {
                CustomerFactor();
            }
            else
            {
                MarkupFactor();
            }
            
        }

        private void lblCustomerMarkupValue_Leave(object sender, EventArgs e)
        {
            
            if (chkCustomerMarkup.Checked == true)
            {
                MarkupFactor();
            }
            else
            {
                CustomerFactor();
            }

        }

        private void lblCustomerFactorValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (chkCustomerFactor.Checked == true)
                {
                    CustomerFactor();
                }
                else
                {
                    MarkupFactor();
                }

            }
        }

        private void lblCustomerMarkupValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 if (chkCustomerMarkup.Checked == true)
                {
                    MarkupFactor();
                }
                else
                {
                    CustomerFactor();
                }
                 
            }
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            
            #region Online Quotatation
            int i = -1;
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "XML File | *.xml",
                Title = "Aktarılacak Online Siparişi Se\x00e7iniz"
            };

            if (DialogResult.OK == dialog.ShowDialog())
            {
                try
                {
                    XmlTextReader reader = new XmlTextReader(dialog.FileName);
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            string name = reader.Name;
                            switch (name)
                            {
                                case "StockCode":
                                    reader.Read();
                                    i = i + 1;
                                    dgQuotationAddedItems.Rows[i].Cells[dgProductCode.Index].Value = reader.Value;
                                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[i].Cells[dgProductCode.Index];
                                    string articleNo = "";
                                    articleNo = dgQuotationAddedItems.CurrentCell.Value.ToString();
                                    if (articleNo.Contains("-"))
                                    {
                                        articleNo = articleNo.Replace("-", "");
                                        dgQuotationAddedItems.CurrentCell.Value = articleNo;
                                    }
                                    if (articleNo.Length == 6)
                                    {
                                        articleNo = "0" + articleNo;
                                        dgQuotationAddedItems.CurrentCell.Value = articleNo;
                                    }


                                    if (dgQuotationAddedItems.Rows[i].Cells[dgProductCode.Index].Value != null && dgQuotationAddedItems.Rows[i].Cells[dgProductCode.Index].Value.ToString() != "" && dgQuotationAddedItems.Rows[i].Cells[dgDesc.Index].Value != null && dgQuotationAddedItems.Rows[i].Cells[dgDesc.Index].Value.ToString() != "")
                                    {
                                        DataGridViewRow rowsss = (DataGridViewRow)dgQuotationAddedItems.Rows[i];
                                        for (int j = 11; j < rowsss.Cells.Count; j++)
                                        {
                                            rowsss.Cells[j].Value = "";
                                        }
                                    }
                                    if (!Discontinued(articleNo))
                                    {
                                        List<string> SameItemIndexList = new List<string>();
                                        string _IndexList = string.Empty;
                                        for (int j = 0; j < dgQuotationAddedItems.RowCount - 1; j++)
                                        {
                                            if (dgQuotationAddedItems.Rows[j].Cells[dgProductCode.Index].Value.ToString() == articleNo &&
                                                dgQuotationAddedItems.Rows[j].Cells[dgQty.Index].Value == null)
                                            {
                                                SameItemIndexList.Add(dgQuotationAddedItems.Rows[j].Cells[dgNo.Index].Value.ToString());
                                            }
                                        }
                                        if (SameItemIndexList != null && SameItemIndexList.Count > 0)
                                        {
                                            foreach (string item in SameItemIndexList)
                                            {
                                                _IndexList = _IndexList + item + ", ";
                                            }

                                            MessageBox.Show("This item is already added in row(s): " + _IndexList);
                                        }
                                        tabControl1.SelectedTab = tabItemDetails;
                                        dgQuotationAddedItems.Focus();
                                        ItemDetailsFiller(articleNo);//tekrar bakılacak
                                        FillProductCodeItem();
                                        if (txtWeb1.Text == "0" || txtWeb1.Text == "")
                                        {
                                            DialogResult dialogResult = MessageBox.Show("Item is not available in Price File, please check website and Enter price from ItemCard");
                                            ItemsClear();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("This Item is Discontinued");
                                    }
                                        (dgQuotationAddedItems.Rows[i].Cells[dgDelivery.Index] as DataGridViewComboBoxCell).Value = 3;
                                    (dgQuotationAddedItems.Rows[i].Cells[dgStatus.Index] as DataGridViewComboBoxCell).Value = 1;
                                    break;
                                case "Quantity":
                                    reader.Read();
                                    dgQuotationAddedItems.Rows[i].Cells[dgQty.Index].Value = reader.Value;
                                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[i].Cells[dgQty.Index];
                                    if ((Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgSSM"].Value.ToString())) == 0 && (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUC.Index].Value.ToString())) == 0)
                                    {
                                        DgQuantityFiller();
                                        calculateTotalCost();
                                        if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null && dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString() != "")
                                        {
                                            if (txtStandartWeight.Text != "" && txtGrossWeight.Text != "")
                                            {
                                                if (Decimal.Parse(txtStandartWeight.Text) < (Decimal.Parse(txtGrossWeight.Text)))
                                                {
                                                    dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtGrossWeight.Text)).ToString();
                                                }
                                                else
                                                {
                                                    dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                                                }
                                                dgQuotationAddedItems.Rows[i].Cells["dgTotalWeight"].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString();
                                                CalculateTotalWeight();
                                            }
                                        }

                                        if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null && dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString() != "")
                                        {
                                            dgQuotationAddedItems.Rows[i].Cells[dgUnitNetWeight.Index].Value = (Decimal.Parse(txtStandartWeight.Text)).ToString();
                                            dgQuotationAddedItems.Rows[i].Cells[dgUnitTotalNetWeight.Index].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUnitNetWeight.Index].Value.ToString()) * Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString();
                                            CalculateTotalNetWeight();
                                        }
                                        dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Value = String.Format("{0:N}", (Decimal.Parse(txtWeb1.Text))).ToString();


                                        if (txtGrossWeight.Text == "" && Convert.ToDecimal(txtGrossWeight.Text) == 0)
                                        {
                                            dgQuotationAddedItems.Rows[i].Cells[WT.Index].Style.BackColor = Color.Red;
                                        }
                                        else if (Convert.ToDecimal(txtGrossWeight.Text) * Convert.ToDecimal(dgQuotationAddedItems.Rows[i].Cells[dgQty.Index].Value.ToString()) > 5)
                                        {
                                            dgQuotationAddedItems.Rows[i].Cells[WT.Index].Style.BackColor = Color.Orange;
                                        }
                                        else
                                        {
                                            dgQuotationAddedItems.Rows[i].Cells[WT.Index].Style.BackColor = Color.Ivory;
                                        }
                                        if (chkFirstUPIME.Checked)
                                        {
                                            dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Value.ToString());
                                            dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString());
                                            dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgFirstUPIME.Index].Value.ToString()) * Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[dgQty.Index].Value.ToString())).ToString();
                                            dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                                            CalculateSubTotalActivate();
                                        }
                                        else
                                        {
                                            dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUPIME.Index].Value.ToString());
                                            dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString());
                                            dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString()) * Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[dgQty.Index].Value.ToString())).ToString();
                                            dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value = String.Format("{0:N}", dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                                            CalculateSubTotal();
                                        }
                                    }
                                    dgQuotationAddedItems.Rows.Add();
                                    break;
                                case "GoogleAnalticsData":
                                    reader.Read();
                                    dgQuotationAddedItems.Rows.RemoveAt(i + 1);
                                    break;
                            }
                        }
                    }
                    reader.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("hatalı !");
                }
            }
            #endregion
        }

        //private void dgQuotationAddedItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    dgQuotationAddedItems.EndEdit();

        //    if (dgQuotationAddedItems.CurrentCell.Value != null)
        //    {
        //        //MessageBox.Show(dgQuotationAddedItems.CurrentCell.Value.ToString());
        //        //textBox2.Text = dgQuotationAddedItems.CurrentCell.FormattedValue.ToString();
        //    }

        //    dgQuotationAddedItems.BeginEdit(false);

        //}

        //private void dgQuotationAddedItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    dgQuotationAddedItems.SelectionChanged += new EventHandler(dgQuotationAddedItems_SelectionChanged);
        //}

        //private void dgQuotationAddedItems_MouseClick(object sender, MouseEventArgs e)
        //{
        //    DataGridView dgv = (DataGridView)sender;
        //    if (dgv.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.RowHeader)
        //    {
        //        dgv.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        //        dgv.EndEdit();
        //    }
        //    else
        //    {
        //        dgv.EditMode = DataGridViewEditMode.EditOnEnter;
        //    }
        //}
    }
    enum QuotationIdMod
    {
        New = 0,
        CreateVersion = 1
    }
}
