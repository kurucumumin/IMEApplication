using LoginForm.DataSet;
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
using LoginForm.QuotationModule;

namespace LoginForm
{
    public partial class XtraFormSaleOrder : DevExpress.XtraEditors.XtraForm
    {
        SqlHelper sqlHelper = new SqlHelper();
        string manuelSelection = string.Empty;
        private static string QuoStatusActive = "Pending";
        FormSalesOrderMain parent;
        List<int> enabledColumns = new List<int>(new int[] { 0, 7, 14, 21, 28, 35 });
        #region Definitions
        GetWorkerService GetWorkerService = new GetWorkerService();
        DataTable TotalCostList = new DataTable();
        DataGridViewRow CurrentRow;
        IMEEntities IME = new IMEEntities();
        decimal price;
        decimal? SaleCurrency = 1;
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
        ToolTip aciklama = new ToolTip();
        System.Data.DataSet ds = new System.Data.DataSet();
        int a = 1;
        int importFromQuotation = 0;
        string mod = "";
        string cName = "";
        string cID = "";
        DataTable table = new DataTable();
        #endregion

        public XtraFormSaleOrder(FormQuaotationCustomerSearch parent, string customerName, string customerId)
        {
            InitializeComponent();
            dgSaleAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgSaleDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgSaleAddedItems, new object[] { true });


            cName = customerName;
            cID = customerId;
            dtpDate.Value = Utils.GetCurrentDateTime();
            dtpDate.Enabled = false;
            //this.parentCustomer = parent;
            txtQuotationNo.PasswordChar = ' ';
            txtTotalMarge.Visible = false;

            if (customerName != null && customerName != "")
            {
                #region customer
                txtCustomerName.Text = cName;
                CustomerCode.Text = cID;

                var customerList = IME.Customers.Where(a => a.c_name.Contains(txtCustomerName.Text)).ToList();

                this.Enabled = true;
                customer = customerList.FirstOrDefault();
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

        public void FillCustomerFromSearch(string customerName, string customerId)
        {

            cName = customerName;
            cID = customerId;
            txtCustomerName.Text = cName;
            CustomerCode.Text = cID;
            var customerList = IME.Customers.Where(a => a.c_name.Contains(txtCustomerName.Text)).ToList();
            customer = customerList.FirstOrDefault();

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

        public XtraFormSaleOrder()
        {
            InitializeComponent();
            dgSaleAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgSaleDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgSaleAddedItems, new object[] { true });

            dtpDate.Value = Utils.GetCurrentDateTime();
            dtpDate.Enabled = false;
            txtTotalMarge.Visible = false;
        }

        public void Disc()
        {
            decimal subtotal = 0;
            if (lblsubtotal.Text != null && lblsubtotal.Text != string.Empty)
            {

                decimal dis2 = 0;
                decimal totaldis = 0;
                if (txtTotalDis.Text == null || txtTotalDis.Text == "") txtTotalDis.Text = "0";
                if (lblsubtotal.Text != "" && Decimal.Parse(lblsubtotal.Text) != 0 && lblsubtotal.Text != null)
                {
                    //hz ve lithum disc dan etkilenmeyecek
                    decimal hztotal = 0;

                    for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                    {
                        if (dgSaleAddedItems.Rows[i].Cells["HS"].Style.BackColor == Color.Red)
                        {
                            if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString() == null)
                            {
                                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[i].Cells["dgQty"];
                            }
                            else if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString() != null)
                            {
                                hztotal += decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString());
                            }


                        }
                        else if (dgSaleAddedItems.Rows[i].Cells["LI"].Style.BackColor == Color.Ivory)
                        {
                            hztotal += decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString());
                        }
                    }

                    subtotal = Decimal.Parse(lblsubtotal.Text) - hztotal;



                    if (txtTotalDis.Text != "") dis2 = Math.Round(subtotal * Decimal.Parse(txtTotalDis.Text) / 100, 3);


                }
                txtTotalDis2.Text = dis2.ToString();

                lbltotal.Text = Math.Round((Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)), 4).ToString();
            }
            subtotal = 0;
            decimal DiscounRate = 0;
            if (lblsubtotal.Text != "" && lblsubtotal.Text != null) subtotal = decimal.Parse(lblsubtotal.Text);
            if (txtTotalDis.Text != "" && txtTotalDis.Text != null) DiscounRate = decimal.Parse(txtTotalDis.Text);
            try
            {
                lbltotal.Text = (decimal.Parse(lblsubtotal.Text) - ((subtotal * DiscounRate) / 100)).ToString();
            }
            catch { }

        }

        public XtraFormSaleOrder(string item_code)
        {
            InitializeComponent();
            dgSaleAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgSaleDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgSaleAddedItems, new object[] { true });

            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                dgSaleAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgQty"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgDelivery"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgSaleAddedItems.DefaultCellStyle;

                GetMarginMark(i);
            }
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                QuotataionModifyItemDetailsFiller(item_code, i);

            }
            txtTotalMarge.Visible = false;
        }

        private void cbCurrencySelected(string name, SaleOrder s)
        {
            
            if (name == "New")
            {
                cbCurrency.DataSource = IME.Currencies.ToList();
                cbCurrency.DisplayMember = "currencyName";
                cbCurrency.ValueMember = "currencyID";

                var c = customer;
                var CustomerCurr = IME.Currencies.Where(a => a.currencyName == c.CurrNameQuo).FirstOrDefault();
                if (CustomerCurr != null) cbCurrency.SelectedValue = CustomerCurr.currencyID;
                cbCurrency.SelectedItem = cbCurrency.FindStringExact(c.CurrNameQuo);

            }
            //else if (name == "Quotation")
            //{
            //   var quo = s.Quotations.Where(x => x.SaleOrderID == s.SaleOrderID).ToList();

            //    cbCurrency.DataSource = IME.Currencies.ToList();
            //    cbCurrency.DisplayMember = "currencyName";
            //    cbCurrency.ValueMember = "currencyID";

            //    cbCurrency.SelectedIndex = cbCurrency.FindStringExact(quotation.ExchangeRate.Currency.currencyName);
            //}
            else if (name == "Sale")
            {
                cbCurrency.DataSource = IME.Currencies.ToList();
                cbCurrency.DisplayMember = "currencyName";
                cbCurrency.ValueMember = "currencyID";

                cbCurrency.SelectedIndex = cbCurrency.FindStringExact(s.ExchangeRate.Currency.currencyName);
            }
            ChangeCurr();
        }

        public XtraFormSaleOrder(SaleOrder sale2, FormSalesOrderMain parent, string mod2)
        {
            InitializeComponent();
            dgSaleAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgSaleDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgSaleAddedItems, new object[] { true });
            mod = mod2;
            if (mod == "Update")
            {
                label67.Text = "Save Modification";
                this.Text = "Modify SaleOrder";
                CustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                cbCurrencySelected("Sale", sale2);
                txtSalesOrderNo.Text = "SO" + sale2.SaleOrderNo.ToString();
            }
            else if (mod == "View")
            {
                //label67.Text = "Save Modification";
                this.Text = "View SaleOrder";
                CustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                cbCurrencySelected("Sale", sale2);
                txtSalesOrderNo.Text = "SO" + sale2.SaleOrderNo.ToString();
                dgSaleAddedItems.ReadOnly = true;
            }
            modifyMod = true;
            this.parent = parent;
            dtpDate.Value = Utils.GetCurrentDateTime();
            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgSaleAddedItems.Columns[dgDelivery.Index];
            deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
            deliveryColumn.DisplayMember = "DeliveryName";
            deliveryColumn.ValueMember = "ID";
            SaleOrder q1 = IME.SaleOrders.Where(a => a.SaleOrderNo == sale2.SaleOrderNo).FirstOrDefault();
            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            cbPayment.DataSource = IME.PaymentTerms.ToList();
            cbPayment.DisplayMember = "term_name";
            cbPayment.ValueMember = "ID";
            cbPayment.SelectedValue = (int)q1.PaymentTermID;
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";
            cbRep.SelectedValue = (int)q1.RepresentativeID;
            cbWorkers.Items.AddRange(IME.CustomerWorkers.Where(x => x.customerID == q1.CustomerID).ToArray());
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
            if (q1.Customer != null && q1.Customer.MainContactID != null)
            {
                cbWorkers.SelectedValue = (int)q1.Customer.MainContactID;
            }
            else
            {
                cbWorkers.Text = q1.Customer.MainContactID.ToString();
            }
            LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
            importFromQuotation = 0;
            modifyQuotation(q1, mod);

            cbSMethod.SelectedText = q1.ShippingType;
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                dgSaleAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgQty"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgDelivery"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
                dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgSaleAddedItems.DefaultCellStyle;

                GetMarginMark(i);

            }
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                QuotataionModifyItemDetailsFiller(dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString(), i);

            }
            if (!Utils.AuthorityCheck(IMEAuthority.EditanyQuotation))
            {
                dgSaleAddedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
                {
                    item.ReadOnly = true;
                }
                foreach (DataGridViewRow item in dgSaleDeleted.Rows)
                {
                    item.ReadOnly = true;
                }
                gbCustomer.Enabled = false;
                gbShipment.Enabled = false;
                groupBox11.Enabled = false;
                groupBox7.Enabled = false;
            }
            CalculateTotalMarge();

            dgSaleAddedItems.Focus();
            dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index];

            txtTotalMarge.Visible = false;
        }


        public XtraFormSaleOrder(SaleOrder quotation, string mumin)
        {
         //   InitializeComponent();
         //   dgSaleAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
         //   dgSaleDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

         //   typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         //System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         //dgSaleAddedItems, new object[] { true });

         //   DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgSaleAddedItems.Columns[dgDelivery.Index];
         //   deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
         //   deliveryColumn.DisplayMember = "DeliveryName";
         //   deliveryColumn.ValueMember = "ID";
         //   //Son versiyonu açmayı sağlıyor
         //   SaleOrder q1 = IME.SaleOrders.Where(a => a.SaleOrderNo.Contains(quotation.QuotationNo)).FirstOrDefault();
         //   this.Text = "View Quotation";
         //   modifyMod = true;
         //   cbCurrency.DataSource = IME.Currencies.ToList();
         //   cbCurrency.DisplayMember = "currencyName";
         //   cbCurrency.ValueMember = "currencyID";

         //   var QuoCurr = IME.Currencies.Where(a => a.currencyName == q1.).FirstOrDefault();
         //   if (QuoCurr != null) cbCurrency.SelectedValue = QuoCurr.currencyID;

         //   dtpDate.Value = (DateTime)q1.StartDate;
         //   dtpDate.MaxDate = DateTime.Today.Date;
         //   cbPayment.DataSource = IME.PaymentTerms.ToList();
         //   cbPayment.DisplayMember = "term_name";
         //   cbPayment.ValueMember = "ID";
         //   cbPayment.SelectedValue = (int)q1.PaymentTermID;
         //   cbRep.DataSource = IME.Workers.ToList();
         //   cbRep.DisplayMember = "NameLastName";
         //   cbRep.ValueMember = "WorkerID";
         //   cbRep.SelectedValue = (int)q1.Worker.WorkerID;
         //   cbWorkers.Items.AddRange(IME.CustomerWorkers.ToArray());
         //   cbWorkers.DisplayMember = "cw_name";
         //   cbWorkers.ValueMember = "ID";
         //   if (q1.QuotationMainContact != null)
         //   {
         //       cbWorkers.SelectedValue = (int)q1.QuotationMainContact;
         //   }
         //   else
         //   {
         //       cbWorkers.Text = q1.MainContactName;
         //   }
         //   CustomerCode.Enabled = false;
         //   txtCustomerName.Enabled = false;

         //   LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
         //   importFromQuotation = 1;
         //   modifyQuotation(q1);
         //   cbSMethod.SelectedText = q1.ShippingType;
         //   for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
         //   {
         //       dgSaleAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
         //       dgSaleAddedItems.Rows[i].Cells["dgQty"].Style = dgSaleAddedItems.DefaultCellStyle;

         //       dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
         //       dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgSaleAddedItems.DefaultCellStyle;

         //       dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
         //       dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgSaleAddedItems.DefaultCellStyle;

         //       dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
         //       dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgSaleAddedItems.DefaultCellStyle;

         //       dgSaleAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
         //       dgSaleAddedItems.Rows[i].Cells["dgDelivery"].Style = dgSaleAddedItems.DefaultCellStyle;

         //       dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
         //       dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgSaleAddedItems.DefaultCellStyle;

         //       dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
         //       dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgSaleAddedItems.DefaultCellStyle;

         //       GetMarginMark(i);
         //   }
         //   for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
         //   {
         //       QuotataionModifyItemDetailsFiller(dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString(), i);

         //   }
         //   if (!Utils.AuthorityCheck(IMEAuthority.EditanyQuotation))
         //   {
         //       dgSaleAddedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         //       foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
         //       {
         //           item.ReadOnly = true;
         //       }
         //       foreach (DataGridViewRow item in dgSaleDeleted.Rows)
         //       {
         //           item.ReadOnly = true;
         //       }
         //       gbCustomer.Enabled = false;
         //       gbShipment.Enabled = false;
         //       groupBox11.Enabled = false;
         //       groupBox7.Enabled = false;
         //   }
         //   CalculateTotalMarge();
         //   //txtQuotationNo.Text = q1.QuotationNo;/*View 3*/
         //   EnableForm();
         //   txtTotalMarge.Visible = false;
         //   dgSaleAddedItems.ReadOnly = true;
        }

        private void EnableForm()
        {
            dgSaleAddedItems.ReadOnly = true;
            dgSaleDeleted.ReadOnly = true;
            CustomerCode.ReadOnly = false;
            txtCustomerName.ReadOnly = false;
            btnViewMore.Enabled = false;
            btnContactAdd.Enabled = false;
            btnSave.Enabled = false;
            groupBox11.Enabled = false;
            gbShipment.Enabled = false;
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

                dgSaleAddedItems.CurrentRow.Cells["dgUKPrice"].ReadOnly = false;
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
                txtTotalMarge.Visible = false;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.ViewDiscount))
            {
                txtTotalDis.Visible = false;
                txtTotalDis2.Visible = false;
                label4.Visible = false;
                dgSaleAddedItems.CurrentRow.Cells["dgDisc"].ReadOnly = false;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.ViewLandingCost))
            {
                dgSaleAddedItems.CurrentRow.Cells["dgLandingCost"].ReadOnly = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.ViewCost))
            {
                dgSaleAddedItems.CurrentRow.Cells["dgCost"].ReadOnly = false;
            }

        }

        private void XtraFormSaleOrder_Load(object sender, EventArgs e)
        {
            #region Nokta Virgül Olayı
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";

            #endregion

            checkAuthorities();
            //ControlAutorization();
            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgSaleAddedItems.Columns[dgDelivery.Index];
            if (deliveryColumn.DataSource == null)
            {
                deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
                deliveryColumn.DisplayMember = "DeliveryName";
                deliveryColumn.ValueMember = "ID";
            }

            if (txtCustomerName.Text == null || txtCustomerName.Text == "")
            {
                btnContactAdd.Enabled = false;
            }
            else
            {
                btnContactAdd.Enabled = true;
            }

            TotalCostList.Columns.Add("dgNo", typeof(int));
            TotalCostList.Columns.Add("cost", typeof(decimal));
            List<int> quotationVisibleFalseNames = QuotationDatagridCustomize.VisibleFalseNames;
            ;
            foreach (var item in quotationVisibleFalseNames)
            {
                dgSaleAddedItems.Columns[item].Visible = false;
            }
            DeletedQuotationMenu.MenuItems.Add(new MenuItem("Add to Quotation", DeletedQuotationMenu_Click));
            if (!modifyMod)
            {

                DataGridViewRow dgRow = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                dgSaleAddedItems.Rows.Add(dgRow);
                //txtQuotationNo.Text = NewQuotationID();/*New 1*/
                txtQuotationNo.Text = CreateQuotationID(QuotationIdMod.New, null);
                dgSaleAddedItems.Rows[0].Cells[dgNo.Index].Value = 1.ToString();
                LowMarginLimit = Decimal.Parse(IME.Managements.FirstOrDefault().LowMarginLimit.ToString());
                vat = (decimal)Utils.getManagement().VAT;
                lblVat.Text = vat.ToString();
                #region ComboboxFiller.
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
                #endregion
            }
            GetCurrency(dtpDate.Value);
            GetAutorities();

            if (CustomerCode.Text != null && CustomerCode.Text != "")
            {
                dgSaleAddedItems.Focus();
                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index];
            }
            else
            {
                CustomerCode.Focus();
            }

        }

        private void GetAutorities()
        {
            if (GetUserAutorities(1020)) { VisibleCostMarginTrue(); }
            if (GetUserAutorities(1021)) { txtTotalMarge.Visible = true; cbDeliverDiscount.Visible = true; }
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
            switch (dgSaleAddedItems.CurrentCell.ColumnIndex)
            {
                case 0:
                    #region ID Atama
                    if (Decimal.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) <= Decimal.Parse(dgSaleAddedItems.CurrentRow.Cells[dgNo.Index].Value.ToString()))
                    {
                        int currentID = dgSaleAddedItems.CurrentCell.RowIndex;
                        List<Decimal> Quotation = new List<Decimal>();
                        for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                        {
                            Quotation.Add(Decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()));
                        }
                        for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                        {
                            if (dgSaleAddedItems.CurrentCell.RowIndex < Decimal.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()))
                            {
                                #region RowChange1
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()) <= Decimal.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgSaleAddedItems.CurrentCell.RowIndex < i)
                                {
                                    if (i <= Quotation.Count)
                                    {
                                        dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value = (i);
                                    }
                                }
                                else { dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()); }
                                #endregion
                            }
                            else
                            {
                                #region RowChange2
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()) >= Decimal.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgSaleAddedItems.CurrentCell.RowIndex > i)
                                {
                                    if (i <= Quotation.Count)
                                    {
                                        dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value = (i + 2);
                                    }

                                }
                                else { dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString()); }
                                #endregion
                            }

                        }
                    }
                    #endregion
                    dgSaleAddedItems.Sort(dgSaleAddedItems.Columns[dgNo.Index], ListSortDirection.Ascending);
                    break;
                case 7://PRODUCT CODE
                    {
                        #region MyRegion
                        ItemDetailsClear();
                        string articleNo = "";
                        int satir_sayisi = dgSaleAddedItems.RowCount;
                        if (!String.IsNullOrEmpty(dgSaleAddedItems.Rows[satir_sayisi - 1].Cells[dgProductCode.Index].Value.ToString()))
                        {
                            articleNo = dgSaleAddedItems.CurrentCell.Value.ToString();
                            if (articleNo.Contains("-"))
                            {
                                articleNo = articleNo.Replace("-", "");
                                dgSaleAddedItems.CurrentCell.Value = articleNo;
                            }
                            if (articleNo.Length == 6)
                            {
                                articleNo = "0" + articleNo;
                                dgSaleAddedItems.CurrentCell.Value = articleNo;
                            }


                            var articleList = IME.ArticleSearch(articleNo).ToList();
                            if (articleList.Count == 1)
                            {
                                if (dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString() != "" && dgSaleAddedItems.CurrentRow.Cells[dgDesc.Index].Value != null && dgSaleAddedItems.CurrentRow.Cells[dgDesc.Index].Value.ToString() != "")
                                {
                                    DataGridViewRow rowsss = (DataGridViewRow)dgSaleAddedItems.CurrentRow;
                                    for (int i = 11; i < rowsss.Cells.Count; i++)
                                    {
                                        rowsss.Cells[i].Value = "";
                                    }
                                }
                                if (!Discontinued(articleNo))
                                {
                                    List<string> SameItemIndexList = new List<string>();
                                    string _IndexList = string.Empty;
                                    for (int i = 0; i < dgSaleAddedItems.RowCount - 1; i++)
                                    {
                                        if (dgSaleAddedItems.Rows[i].Cells[dgProductCode.Index].Value.ToString() == articleNo &&
                                            dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value == null)
                                        {
                                            SameItemIndexList.Add(dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString());
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
                                    dgSaleAddedItems.Focus();
                                    ItemDetailsFiller(articleNo);//tekrar bakılacak
                                    FillProductCodeItem();
                                }
                                else
                                {
                                    MessageBox.Show("This Item is Discontinued");
                                }

                            }
                            else if (articleList.Count > 1)
                            {
                                if (dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString() != "" && dgSaleAddedItems.CurrentRow.Cells[dgDesc.Index].Value != null && dgSaleAddedItems.CurrentRow.Cells[dgDesc.Index].Value.ToString() != "")
                                {
                                    DataGridViewRow rowsss = (DataGridViewRow)dgSaleAddedItems.CurrentRow;
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
                                for (int i = 0; i < dgSaleAddedItems.RowCount - 1; i++)
                                {
                                    if (dgSaleAddedItems.Rows[i].Cells[dgProductCode.Index].Value.ToString() == articleNo &&
                                        dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value == null)
                                    {
                                        SameItemIndexList2.Add(dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString());
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
                                dgSaleAddedItems.Focus();
                                dgSaleAddedItems.CurrentCell.Value = articleNo;
                                ItemDetailsFiller(articleNo);//tekrar bakılacak
                                FillProductCodeItem();
                            }
                            else
                            {
                                MessageBox.Show("Item is not in our range");
                                //dgQuotationAddedItems.Rows.RemoveAt(dgQuotationAddedItems.CurrentRow.Index);
                                ItemsClear();
                                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index];
                            }
                            //if (!String.IsNullOrEmpty(dgQuotationAddedItems.CurrentRow.Cells[dgDesc.Index].Value.ToString())) ChangeCurrnetCell(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
                        }
                        else
                        {
                            //MessageBox.Show("Product Code empty");
                        }
                    }
                    #endregion
                    break;
                case 15://QAUANTITY
                    DgQuantityFiller();
                    calculateTotalCost();
                    break;
                case 22://UCUP Curr
                    {
                        #region UCUP Curr
                        //TO DO depends on authority
                        //if (dgQuotationAddedItems.CurrentRow.Cells[dgHZ.Index].Style.BackColor == Color.White)
                        CurrentRow = dgSaleAddedItems.CurrentRow;
                        if (txtHazardousInd.Text == "N")
                        {
                            #region Total
                            decimal ucupcurr = decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString());
                            decimal UcupIME = decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString());
                            decimal disc = Math.Round(((UcupIME - ucupcurr) * (decimal)100 / UcupIME), 4);
                            int workerID = Utils.getCurrentUser().WorkerID;
                            decimal Minmarge = (decimal)IME.Workers.Where(x => x.WorkerID == workerID).FirstOrDefault().MinMarge;
                            if (disc > Minmarge)
                            {
                                MessageBox.Show("Low Price ! Ask for authorization");
                                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgUCUPCurr.Index];
                                CurrentRow.Cells["dgUCUPCurr"].Value = UcupIME;
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
                                txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
                            }
                            catch (Exception ex)
                            {
                                txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
                            }

                            #endregion
                            CalculateSubTotal();

                            #endregion
                        }
                        else if (txtHazardousInd.Text == "Y")
                        {
                            dgSaleAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value = dgSaleAddedItems.CurrentRow.Cells[dgUPIME.Index].Value.ToString();
                            MessageBox.Show("Hazardous Item - Discount not allowed");
                        }
                    }
                    #endregion
                    break;
            }
        }


        private void DgQuantityFiller()
        {
            #region Quantity

            if (dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value != null)
            {

            }
            else
            {
                dgSaleAddedItems.Rows.RemoveAt(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Index);
                dgSaleAddedItems.Refresh();
            }

            if (!String.IsNullOrEmpty(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgQty.Index].Value.ToString()) && dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgQty.Index].Value.ToString() != "0")
            {
                GetQuotationQuantity(dgSaleAddedItems.CurrentCell.RowIndex);
                dgSaleAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
                dgSaleAddedItems.CurrentRow.Cells["dgUCUPCurr"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.CurrentRow.Cells["dgTargetUP"].ReadOnly = false;
                dgSaleAddedItems.CurrentRow.Cells["dgTargetUP"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.CurrentRow.Cells["dgCompetitor"].ReadOnly = false;
                dgSaleAddedItems.CurrentRow.Cells["dgCompetitor"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.CurrentRow.Cells["dgDelivery"].ReadOnly = false;
                dgSaleAddedItems.CurrentRow.Cells["dgDelivery"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.CurrentRow.Cells["dgCustStkCode"].ReadOnly = false;
                dgSaleAddedItems.CurrentRow.Cells["dgCustStkCode"].Style = dgSaleAddedItems.DefaultCellStyle;

                dgSaleAddedItems.CurrentRow.Cells["dgCustDescription"].ReadOnly = false;
                dgSaleAddedItems.CurrentRow.Cells["dgCustDescription"].Style = dgSaleAddedItems.DefaultCellStyle;

                if (dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value != null && dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value.ToString() != "")
                {
                    GetMarginMark();
                }
                Disc();
                CalculateTotalMarge();
            }
            else
            {
                dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgQty.Index].Value = "";
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
            CurrentRow = dgSaleAddedItems.Rows[rowindex];
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
                        if (txtStandartWeight.Text != null && txtStandartWeight.Text != "")
                        {
                            if (CurrentRow.Cells[dgUnitWeigt.Index].Value == null)
                                CurrentRow.Cells[dgUnitWeigt.Index].Value = txtStandartWeight.Text;
                            txtGrossWeight.Text = String.Format("{0:0.0000}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());
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
                        #endregion
                        //Cost hesaplama
                        CurrentRow.Cells["dgCost"].Value = QuotationUtils.GetCost(CurrentRow.Cells["dgProductCode"].Value.ToString(), Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString("G29");
                        //LandingCost hesaplatma
                        if (CurrentRow.Cells["dgCost"].Value.ToString() != "-1") { String.Format("{0:0.0000}", Decimal.Parse(CurrentRow.Cells["dgCost"].Value.ToString())).ToString(); }
                        GetLandingCost(rowindex);
                        decimal Currrate = 0;
                        if (curr.rate != null) Currrate = Decimal.Parse(curr.rate.ToString());
                        string productCode = CurrentRow.Cells[dgProductCode.Index].Value.ToString();
                        if (productCode.Substring(0, 1) == "0") productCode = productCode.Substring(1, productCode.Length - 1);
                        if (IME.Hazardous.Where(a => a.ArticleNo == productCode).FirstOrDefault() != null)
                        {
                            if (this.Text == "Modify SaleOrder" || this.Text == "Edit Quotation" || this.Text == "View Quotation" || this.Text == "Copy Quotation")
                            {

                                price = Decimal.Parse((QuotationUtils.GetPrice(CurrentRow.Cells["dgProductCode"].Value.ToString(), Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())) * (Utils.getManagement().Factor) / Currrate * Decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString("G29"));
                            }
                            else
                            {
                                price = FiyatKirilmalari2(Convert.ToDecimal(CurrentRow.Cells["dgQty"].Value.ToString()));
                            }

                        }
                        else
                        {
                            if (this.Text == "Modify SaleOrder" || this.Text == "Edit Quotation" || this.Text == "View Quotation" || this.Text == "Copy Quotation")
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
                            CurrentRow.Cells["dgTotal"].Value = Math.Round(price, 4);
                            //SuperdiskP değilse
                            if (!(articleNo.ToUpper().Contains('P')) && Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1)
                            {
                                if ((Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString())) != 0)
                                {
                                    MessageBox.Show("Please enter a number that is a multiple of Unit Content");
                                    CurrentRow.Cells["dgQty"].Value = "";
                                    CurrentRow.Cells["dgUPIME"].Value = "";
                                    CurrentRow.Cells["dgTotal"].Value = "";
                                }
                                else
                                {
                                    CurrentRow.Cells["dgUPIME"].Value = decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString()) / (decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString()));

                                    CurrentRow.Cells["dgTotal"].Value = Math.Round(price / (decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())), 4);
                                }

                            }
                            else if ((Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString())) != 0)
                            {
                                MessageBox.Show("Please enter a number that is a multiple of SSM");
                                CurrentRow.Cells["dgQty"].Value = "";
                                CurrentRow.Cells["dgUPIME"].Value = "";
                                CurrentRow.Cells["dgTotal"].Value = "";
                                dgSaleAddedItems.CurrentCell = CurrentRow.Cells[dgQty.Index];
                                dgSaleAddedItems.BeginEdit(true);
                            }

                            #endregion




                            if (CurrentRow.Cells[dgQty.Index].Value.ToString() != "")
                            {
                                //TOTAL ve UPIME belirleniyor
                                FiyatKirilmalari(Convert.ToDecimal(CurrentRow.Cells["dgQty"].Value.ToString()));
                                discResult = decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString());

                                CurrentRow.Cells["dgTotal"].Value = Math.Round(decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString()), 4);
                                if (CurrentRow.Cells[dgDisc.Index].Value != null && CurrentRow.Cells[dgDisc.Index].Value.ToString() != "")
                                {
                                    CurrentRow.Cells[dgDisc.Index].Value = Math.Round(Decimal.Parse(CurrentRow.Cells[dgDisc.Index].Value.ToString()), 4).ToString();
                                    discResult = (discResult - (discResult * decimal.Parse(CurrentRow.Cells[dgDisc.Index].Value.ToString()) / 100));
                                }
                                CurrentRow.Cells["dgUCUPCurr"].Value = String.Format("{0:0.0000}", discResult).ToString();

                                //Change lblsubtotal

                                CalculateSubTotal();

                                //ChangeCurr(rowindex);
                                GetLandingCost(CurrentRow.Index);
                                if (dgSaleAddedItems.CurrentCell == null) dgSaleAddedItems.CurrentCell = CurrentRow.Cells[0];
                                if (this.Text != "View Quotation")
                                {
                                    GetMargin(rowindex);

                                }
                                CurrentRow.Cells["dgMargin"].Value = Math.Round(Decimal.Parse(CurrentRow.Cells["dgMargin"].Value.ToString()), 4).ToString();
                                if (CurrentRow.Cells["dgUnitWeigt"].Value != null && CurrentRow.Cells["dgUnitWeigt"].Value.ToString() != "")
                                {
                                    CurrentRow.Cells["dgTotalWeight"].Value = (Decimal.Parse(CurrentRow.Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();
                                    if (Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                                    {
                                        CurrentRow.Cells["dgTotalWeight"].Value = (decimal.Parse(CurrentRow.Cells["dgTotalWeight"].Value.ToString()) / Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString())).ToString();
                                    }
                                    else if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1)
                                    {
                                        CurrentRow.Cells["dgTotalWeight"].Value = (decimal.Parse(CurrentRow.Cells["dgTotalWeight"].Value.ToString()) / Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString())).ToString();

                                    }
                                }
                                txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
                            }
                            //else { MessageBox.Show("This product does not have price"); }
                        }
                        else
                        {
                            CurrentRow.Cells[dgTotal.Index].Value = 0.ToString();
                        }

                        #endregion
                        CalculateSubTotal();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Item is not available in Price File, please check website and Enter price from ItemCard", "Sure", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            if (dgSaleAddedItems.RowCount != 1)
                            {
                                dgSaleAddedItems.Rows.RemoveAt(dgSaleAddedItems.CurrentCell.RowIndex);
                                dgSaleAddedItems.Refresh();
                                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index];
                            }
                            else
                            {
                                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgQty.Index];
                            }
                            //dgQuotationAddedItems.Rows.Add(rowindex);
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            if (dgSaleAddedItems.RowCount != 1)
                            {
                                dgSaleAddedItems.Rows.RemoveAt(dgSaleAddedItems.CurrentCell.RowIndex);
                                dgSaleAddedItems.Refresh();
                            }
                            else
                            {
                                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgQty.Index];
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
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:0.0000}", Decimal.Parse(txtWeb1.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:0.0000}", Decimal.Parse(txtUK1.Text)).ToString();
                }
                else if (Convert.ToDecimal(txtUnitCount2.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount3.Text) || Convert.ToDecimal(txtUnitCount3.Text) == 0))
                {
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:0.0000}", Decimal.Parse(txtWeb2.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:0.0000}", Decimal.Parse(txtUK2.Text)).ToString();
                }
                else if (Convert.ToDecimal(txtUnitCount3.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount4.Text) || Convert.ToDecimal(txtUnitCount4.Text) == 0))
                {
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:0.0000}", Decimal.Parse(txtWeb3.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:0.0000}", Decimal.Parse(txtUK3.Text)).ToString();
                }
                else if (Convert.ToDecimal(txtUnitCount4.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount5.Text) || Convert.ToDecimal(txtUnitCount5.Text) == 0))
                {
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:0.0000}", Decimal.Parse(txtWeb4.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:0.0000}", Decimal.Parse(txtUK4.Text)).ToString();
                }
                else if (Convert.ToDecimal(txtUnitCount5.Text) <= adet)
                {
                    CurrentRow.Cells["dgUPIME"].Value = String.Format("{0:0.0000}", Decimal.Parse(txtWeb5.Text)).ToString();
                    CurrentRow.Cells[dgUKPrice.Index].Value = String.Format("{0:0.0000}", Decimal.Parse(txtUK5.Text)).ToString();
                }
            }
            catch { }

        }

        private decimal FiyatKirilmalari2(decimal adet)
        {
            decimal result = 0;
            try
            {
                if (Convert.ToDecimal(txtUnitCount1.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount2.Text) || Convert.ToDecimal(txtUnitCount2.Text) == 0))
                {
                    result = Decimal.Parse(String.Format("{0:0.0000}", Decimal.Parse(txtWeb1.Text)).ToString());

                }
                else if (Convert.ToDecimal(txtUnitCount2.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount3.Text) || Convert.ToDecimal(txtUnitCount3.Text) == 0))
                {
                    result = Decimal.Parse(String.Format("{0:0.0000}", Decimal.Parse(txtWeb2.Text)).ToString());
                }
                else if (Convert.ToDecimal(txtUnitCount3.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount4.Text) || Convert.ToDecimal(txtUnitCount4.Text) == 0))
                {
                    result = Decimal.Parse(String.Format("{0:0.0000}", Decimal.Parse(txtWeb3.Text)).ToString());

                }
                else if (Convert.ToDecimal(txtUnitCount4.Text) <= adet && (adet < Convert.ToDecimal(txtUnitCount5.Text) || Convert.ToDecimal(txtUnitCount5.Text) == 0))
                {
                    result = Decimal.Parse(String.Format("{0:0.0000}", Decimal.Parse(txtWeb4.Text)).ToString());
                }
                else if (Convert.ToDecimal(txtUnitCount5.Text) <= adet)
                {
                    result = Decimal.Parse(String.Format("{0:0.0000}", Decimal.Parse(txtWeb5.Text)).ToString());
                }
            }
            catch { }
            return result;
        }

        private void calculateTotalCost()
        {
            try
            {
                if (dgSaleAddedItems.RowCount != 0)
                {
                    if (dgSaleAddedItems.RowCount == 1 && (dgSaleAddedItems.Rows[0].Cells[dgProductCode.Index].Value == null || dgSaleAddedItems.Rows[0].Cells[dgProductCode.Index].Value.ToString() == ""))
                    {
                        txtTotalCost.Text = 0.ToString();
                    }
                    else
                    {
                        //Satırların landingCost*Qty çarpımı Total Costu Veriyor
                        decimal totalCost = 0;
                        for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                        {
                            decimal LandingCost = 0;
                            decimal Quantity = 0;
                            LandingCost = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString());
                            Quantity = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgQty.Index].Value.ToString());

                            totalCost += (LandingCost * Quantity);
                        }

                        //Total Cost'u seçili olan para birimine dönüştürüyor
                        decimal PoundRate = 0;
                        decimal CurrentRate = 0;
                        PoundRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;
                        CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.currencyId == (decimal)cbCurrency.SelectedValue).OrderByDescending(a => a.date).FirstOrDefault().rate;
                        totalCost = totalCost * PoundRate / (CurrentRate);
                        txtTotalCost.Text = Math.Round(totalCost, 4).ToString();
                    }
                }

            }
            catch { }
        }

        private void GetMarginMark(int rowindex)
        {
            try
            {
                if (Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgMargin"].Value.ToString()) < LowMarginLimit)
                {
                    dgSaleAddedItems.Rows[rowindex].Cells["LM"].Style.BackColor = Color.Blue;
                }
                else
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LM"].Style.BackColor = Color.White;
                }
            }
            catch { }
        }

        private void GetMarginMark()
        {
            try
            {
                if (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString()) < LowMarginLimit)
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LM"].Style.BackColor = Color.Blue;
                }
                else
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LM"].Style.BackColor = Color.White;
                }
            }
            catch { }
        }

        private void GetMargin()
        {
            #region Get Margin
            DateTime today = DateTime.Today;
            CurrentRow = dgSaleAddedItems.CurrentRow;
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

        private void GetMargin(int rowindex)
        {
            #region Get Margin
            DateTime today = DateTime.Today;
            CurrentRow = dgSaleAddedItems.Rows[rowindex];
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


            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                try
                {
                    if (!String.IsNullOrEmpty(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString()))
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

                        dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = CalculateMargin(
                                        Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString()),
                                        Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()));
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
            CurrentRow = dgSaleAddedItems.CurrentRow;
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

        private void ItemDetailsFiller(string ArticleNoSearch)
        {
            CurrentRow = dgSaleAddedItems.CurrentRow;
            #region Filler
            decimal CurrValueWeb = Decimal.Parse(curr.rate.ToString());
            string ArticleNoSearch1 = ArticleNoSearch;
            try { ArticleNoSearch1 = (Int32.Parse(ArticleNoSearch)).ToString(); } catch { }
            //Seçili olan item ı text lere yazdıran fonksiyon yazılacak

            var ItemTabDetails = IME.ItemDetailTabFiller(ArticleNoSearch).FirstOrDefault();

            if (ItemTabDetails != null)
            {
                CurrentRow.Cells["dgDesc"].Value = ItemTabDetails.Article_Desc;
                CurrentRow.Cells["dgSSM"].Value = ItemTabDetails.Pack_Quantity.ToString() ?? ""; ;
                CurrentRow.Cells["dgUC"].Value = ItemTabDetails.Unit_Content.ToString() ?? ""; ;
                CurrentRow.Cells["dgUOM"].Value = ItemTabDetails.Unit_Measure;
                CurrentRow.Cells["dgMPN"].Value = ItemTabDetails.MPN;
                CurrentRow.Cells["dgCL"].Value = ItemTabDetails.Calibration_Ind;
                if (ItemTabDetails.Standard_Weight != null && ItemTabDetails.Standard_Weight != 0)
                {
                    decimal sW = (decimal)(ItemTabDetails.Standard_Weight / (decimal)1000);
                    sW = (ItemTabDetails.Pack_Quantity > ItemTabDetails.Unit_Content) ? (decimal)(sW / ItemTabDetails.Pack_Quantity) : (decimal)(sW / ItemTabDetails.Unit_Content);
                    txtStandartWeight.Text = sW.ToString();
                }
                txtHazardousInd.Text = ItemTabDetails.Hazardous_Ind;
                txtCalibrationInd.Text = ItemTabDetails.Calibration_Ind;
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
                txtGrossWeight.Text = String.Format("{0:0.0000}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());
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
                if (ItemTabDetails.Environment != null) { txtEnvironment.Text = "Y"; } else { txtEnvironment.Text = ""; }
                txtLithium.Text = (ItemTabDetails.Lithium != null && ItemTabDetails.Lithium != String.Empty) ? "Y" : "";
                txtShipping.Text = (ItemTabDetails.Shipping != null && ItemTabDetails.Shipping != String.Empty) ? "Y" : "";
                txtRSStock.Text = ItemTabDetails.OnhandStockBalance.ToString();
                txtRSOnOrder.Text = ItemTabDetails.QuantityonOrder.ToString();
                txtDiscontinuationDate.Text = ItemTabDetails.DiscontinuationDate;
                txtRunOn.Text = ItemTabDetails.Runon?.ToString();
                txtReferral.Text = ItemTabDetails.Referral?.ToString();
                txtLicenceType.Text = ItemTabDetails.LicenceType;

                #region ItemMarginFiller
                if ((ItemTabDetails.Col1Break * ItemTabDetails.Unit_Content).ToString() == "")
                {
                    ItemTabDetails.Col1Break = 0;
                }
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
                            if (decimal.Parse(txtUK3.Text) != 0)
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
                if (CurrentRow.Cells["dgUOM"].Value == null && CurrentRow.Cells["dgUC"].Value != null)
                { CurrentRow.Cells["dgUOM"].Value = "Each"; }
                #endregion

                #region Low Margin Mark Clear
                if (!String.IsNullOrEmpty(txtLithium.Text) && txtLithium.Text == "Y")
                {
                    label64.BackColor = Color.Red;
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.Red;
                }
               
                if (!String.IsNullOrEmpty(txtShipping.Text) && txtShipping.Text == "Y")
                {
                    label63.BackColor = Color.Red;
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

                }

                if (!String.IsNullOrEmpty(txtEnvironment.Text) && txtEnvironment.Text == "Y")
                {
                    label53.BackColor = Color.Red;
                }

                if (!String.IsNullOrEmpty(txtCalibrationInd.Text) && txtCalibrationInd.Text == "Y")
                {
                    label22.BackColor = Color.Red;
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Red;
                }

                if (!String.IsNullOrEmpty(txtLicenceType.Text))
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.Red;
                }
                #endregion

            }
        (dgSaleAddedItems.CurrentRow.Cells[dgDelivery.Index] as DataGridViewComboBoxCell).Value = 3;
        }

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MakeTextUpperCase((TextBox)sender);
                CustomerSearchInput();
            }
        }
        
        private void dgQuotationAddedItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgSaleAddedItems.RowCount > 1) dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgNo.Index].Value = (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 2].Cells[dgNo.Index].Value.ToString()) + 1).ToString();
        }

        private void dgQuotationAddedItems_Click(object sender, EventArgs e)
        {
            CurrentRow = dgSaleAddedItems.CurrentRow;
            ItemClear();
            try { ItemDetailsFiller(CurrentRow.Cells["dgProductCode"].Value.ToString()); } catch { }
        }



        private void GetLandingCost(int Rowindex)
        {
            try
            {
                dgSaleAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = (QuotationUtils.GetLandingCost(dgSaleAddedItems.Rows[Rowindex].Cells["dgProductCode"].Value.ToString(), true, true, true, Int32.Parse(dgSaleAddedItems.Rows[Rowindex].Cells[dgQty.Index].Value.ToString()))).ToString("G29");
                dgSaleAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = String.Format("{0:0.0000}", dgSaleAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value.ToString()).ToString();
            }
            catch (Exception e) { }

        }


        private decimal CalculateMargin(decimal _LandingCost, decimal _Price)
        {
            decimal currentGbpValue = Convert.ToDecimal(IME.Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);
            decimal gbpPrice = ((_Price) * CurrValue) / currentGbpValue;

            return Math.Round((1 - (_LandingCost / gbpPrice)) * 100, 4);
        }

        private void CalculateSubTotal()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
            {
                decimal rowTotal = 0;
                try { rowTotal = decimal.Parse(item.Cells[dgTotal.Index].Value.ToString()); } catch { }
                subtotal += rowTotal;
            }
            lblsubtotal.Text = Math.Round(subtotal, 4).ToString();
            decimal dectotaldisc = 0;

            if (txtTotalDis2.Text != "" && txtTotalDis2.Text != null)
            {
                decimal totaldis = 0;
                totaldis = decimal.Parse(txtTotalDis.Text);
                txtTotalDis2.Text = (subtotal * totaldis / 100).ToString();
                dectotaldisc = decimal.Parse(txtTotalDis2.Text);
            }

            lbltotal.Text = (subtotal - dectotaldisc).ToString();
        }

        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            chkVat_Checked();
        }

        private void chkVat_Checked()
        {
            if (chkVat.Checked)
            {
                decimal totalextra = 0;
                try { totalextra = Decimal.Parse(lblTotalExtra.Text); } catch { }
                lblVatTotal.Text = (totalextra * (vat / 100)).ToString();
                lblGrossTotal.Text = ((Decimal.Parse(lblTotalExtra.Text) + ((Decimal.Parse(lblTotalExtra.Text) * ((vat / 100)))))).ToString();
            }
            else
            {
                lblVatTotal.Text = 0.ToString();
                lblGrossTotal.Text = lblTotalExtra.Text;
            }
        }

        private void lblsubtotal_TextChanged(object sender, EventArgs e)
        {
            decimal st = 0;
            try
            {
                st = decimal.Parse(lblsubtotal.Text);
                if (lblsubtotal.Text != Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lblsubtotal.Text)))).ToString("G29")
                )
                { lblsubtotal.Text = Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lblsubtotal.Text)))).ToString("G29"); }
            }
            catch { }
            decimal p = 0;
            ///////////PROBLEM OLABİLİR her seferinde indirim hesaplaması
            try { p = decimal.Parse(lblTotalDis.Text); } catch { }
            try { lbltotal.Text = (st - (st * (p / 100))).ToString(); } catch { }
        }

        private void lbltotal_TextChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            try
            {
                total = decimal.Parse(lbltotal.Text);
                if (lbltotal.Text != Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lbltotal.Text)))).ToString("G29")
                )
                {
                    lbltotal.Text = Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lbltotal.Text)))).ToString("G29");
                }
            }
            catch { }
            decimal extrachange = 0;
            try { extrachange = decimal.Parse(txtExtraChanges.Text); } catch { }
            lblTotalExtra.Text = (total + extrachange).ToString();
        }

        private void lblTotalExtra_TextChanged(object sender, EventArgs e)
        {
            if (lblTotalExtra.Text != Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lblTotalExtra.Text)))).ToString("G29")
                )
            {
                lblTotalExtra.Text = Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lblTotalExtra.Text)))).ToString("G29");
            }
            chkVat_Checked();
        }

       
        private bool ControlSave()
        {
            if (txtCustomerName.Text == null || txtCustomerName.Text == String.Empty) { MessageBox.Show("Please Enter a Customer"); return false; }
            for (int i = 0; i < dgSaleAddedItems.RowCount - 1; i++)
            {
                if (!String.IsNullOrEmpty(dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value.ToString()) && Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value.ToString()) < Utils.getCurrentUser().MinMarge) { MessageBox.Show("Please Check Margin of Products "); return false; }
                if (txtTotalMargin.Text == null || txtTotalMargin.Text == "") { txtTotalMargin.Text = "0"; }
                if (Utils.getCurrentUser().MinMarge > decimal.Parse(txtTotalMargin.Text))
                {
                    MessageBox.Show("You are not able to give this Total Margin. Please check the Total Margin");
                    return false;
                }
            }
            for (int i = 0; i < dgSaleAddedItems.RowCount - 1; i++)
            {
                if (!String.IsNullOrEmpty(dgSaleAddedItems.Rows[i].Cells[dgProductCode.Index].Value.ToString()) && ((DataGridViewComboBoxCell)dgSaleAddedItems.Rows[i].Cells[dgDelivery.Index]).Value == null && ((DataGridViewComboBoxCell)dgSaleAddedItems.Rows[i].Cells[dgDelivery.Index]).Value.ToString() == "")
                {
                    MessageBox.Show("Delivery part cannot be left blank. Please check Delivery Parts of Items");
                    return false;
                }
            }
            if (dgSaleAddedItems.Rows.Count == 0)
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

            if (SaveOK)
            {
                if (label67.Text == "Save Modification")
                {
                    #region Update SaleOrder
                    IMEEntities IME = new IMEEntities();
                    try
                    {
                        // getTotalDiscMargin();
                        decimal SaleOrderNo = Decimal.Parse(txtSalesOrderNo.Text.Substring(2));
                        SaleOrder s = IME.SaleOrders.Where(quo => quo.SaleOrderNo == SaleOrderNo).FirstOrDefault();
                        s.SaleDate = Utils.GetCurrentDateTime();
                        s.OnlineConfirmationNo = txtOnlineConfirmationNo.Text;
                        s.QuotationNos = txtQuotationNo.Text;
                        s.PaymentTermID = (int)cbPaymentTerm.SelectedValue;
                        s.RequestedDeliveryDate = dtpRequestedDelvDate.Value.Date;
                        s.Vat = Convert.ToDecimal(lblVat.Text);
                        s.TotalPrice = Convert.ToDecimal(lbltotal.Text);
                        s.CustomerID = CustomerCode.Text;
                        s.ContactID = (int)cbWorkers.SelectedValue;
                        s.DeliveryContactID = (int)cbDeliveryContact.SelectedValue;
                        s.InvoiceAddressID = (int)cbInvoiceAdress.SelectedValue;
                        s.DeliveryAddressID = (int)cbDeliveryAddress.SelectedValue;
                        s.RepresentativeID = (int)cbRep.SelectedValue;
                        s.PaymentMethodID = (int)cbPayment.SelectedValue;
                        s.NoteForUs = txtNoteForUs.Text;
                        //s.NoteForCustomer = txtNoteForCustomer.Text;
                        s.NoteForFinance = (chkbForFinance.Checked == true) ? 1 : 0;
                        s.SaleOrderNature = cbOrderNature.SelectedItem.ToString();
                        s.ShippingType = cbSMethod.SelectedItem.ToString();
                        s.Status = "Active";

                        s.LPONO = txtLPONO.Text;
                        s.TotalMargin = Convert.ToDecimal(txtTotalMargin.Text);
                        s.Factor = Convert.ToDecimal(cbFactor.Text);
                        s.SubTotal = Convert.ToDecimal(lblsubtotal.Text);
                        s.DiscOnSubtotal = (txtTotalDis.Text != null && txtTotalDis.Text != String.Empty) ? Convert.ToDecimal(txtTotalDis.Text) : 0;
                        s.ExtraCharges = (txtExtraChanges.Text != null && txtExtraChanges.Text != String.Empty) ? Convert.ToDecimal(txtExtraChanges.Text) : 0;
                        s.financialYearId = (decimal)Utils.getManagement().CurrentFinancialYear;
                        s.exchangeRateID = curr.exchangeRateID;

                        if (!String.IsNullOrEmpty(txtQuotationNo.Text))
                        {
                            string[] quotationNos = txtQuotationNo.Text.Split(',');

                            foreach (string no in quotationNos)
                            {
                                IME.Quotations.Where(x => x.QuotationNo == no).FirstOrDefault().status = "Passive";
                                IME.Quotations.Where(x => x.QuotationNo == no).FirstOrDefault().SaleOrderID = s.SaleOrderID;
                            }
                        }

                        s.DistributeDiscount = cbDeliverDiscount.Checked;
                        IME.SaveChanges();



                        DebitCustomer();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        throw;
                    }
                    #endregion

                    #region UpdateSaleOrderDetail
                    decimal discountAmount = 0;
                    decimal SaleID = Convert.ToDecimal(txtSalesOrderNo.Text.Substring(2));
                    for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                    {
                        DataGridViewRow row = dgSaleAddedItems.Rows[i];
                        if (row.Cells["dgProductCode"].Value != null)
                        {
                            SaleOrderDetail sdi = new SaleOrderDetail();
                            sdi.SaleOrderID = SaleID;
                            if (row.Cells[dgNo.Index].Value != null) sdi.No = Int32.Parse(row.Cells[dgNo.Index].Value.ToString());
                            //if (row.Cells[QuoDetailNo.Index].Value != null) sdi.quotationDetailsId = Int32.Parse(row.Cells[QuoDetailNo.Index].Value.ToString());
                            if (row.Cells[dgProductCode.Index].Value != null) sdi.ItemCode = row.Cells[dgProductCode.Index].Value?.ToString();
                            if (row.Cells[dgQty.Index].Value != null) sdi.Quantity = Int32.Parse(row.Cells[dgQty.Index].Value?.ToString());
                            if (row.Cells[dgUCUPCurr.Index].Value != null) sdi.UCUPCurr = Decimal.Parse(row.Cells[dgUCUPCurr.Index].Value?.ToString());
                            if (row.Cells[dgDisc.Index].Value != null)
                            {
                                sdi.Discount = Decimal.Parse(row.Cells[dgDisc.Index].Value.ToString());
                            }
                            else
                            {
                                sdi.Discount = 0;
                            }

                            if (row.Cells[dgTotal.Index].Value != null) sdi.Total = Decimal.Parse(row.Cells[dgTotal.Index].Value?.ToString());
                            if (row.Cells[dgTargetUP.Index].Value != null) sdi.TargetUP = Decimal.Parse(row.Cells[dgTargetUP.Index].Value?.ToString());
                            if (row.Cells[dgCompetitor.Index].Value != null) sdi.Competitor = row.Cells[dgCompetitor.Index].Value?.ToString();

                            if (row.Cells[dgLandingCost.Index].Value != null) sdi.LandingCost = Convert.ToDecimal(row.Cells[dgLandingCost.Index].Value?.ToString());
                            sdi.DeliveryID = Convert.ToInt32(row.Cells[dgDelivery.Index].Value?.ToString());
                            if (row.Cells[dgMPN.Index].Value != null) sdi.MPN = row.Cells[dgMPN.Index].Value?.ToString();
                            if (row.Cells[dgDesc.Index].Value != null) sdi.ItemDescription = row.Cells[dgDesc.Index].Value?.ToString();
                            if (row.Cells[dgCustDescription.Index].Value != null) sdi.CustomerDescription = row.Cells[dgCustDescription.Index].Value?.ToString();
                            if (row.Cells[dgCustStkCode.Index].Value != null) sdi.CustomerStockCode = row.Cells[dgCustStkCode.Index].Value?.ToString();
                            sdi.IsDeleted = false;
                            if (row.Cells[dgUPIME.Index].Value != null) sdi.UPIME = Decimal.Parse(row.Cells[dgUPIME.Index].Value?.ToString());
                            if (row.Cells[dgMargin.Index].Value != null) sdi.Margin = Decimal.Parse(row.Cells[dgMargin.Index].Value?.ToString());
                            if (!String.IsNullOrEmpty(dgSaleAddedItems.Rows[i].Cells[dgUOM.Index].Value?.ToString()))
                            {
                                sdi.UnitOfMeasure = "EACH";
                            }
                            else
                            {
                                sdi.UnitOfMeasure = row.Cells[dgUOM.Index].Value?.ToString();
                            }
                            if (row.Cells[dgUC.Index].Value != null) sdi.UnitContent = Int32.Parse(row.Cells[dgUC.Index].Value?.ToString());
                            if (row.Cells[dgSSM.Index].Value != null) sdi.SSM = Int32.Parse(row.Cells[dgSSM.Index].Value?.ToString());
                            if (row.Cells[dgUnitWeigt.Index].Value != null) sdi.UnitWeight = Decimal.Parse(row.Cells[dgUnitWeigt.Index].Value?.ToString());
                           // if (row.Cells[dgDependantTable.Index].Value != null) sdi.DependantTable = row.Cells[dgDependantTable.Index].Value?.ToString();
                            if (row.Cells[dgHZ.Index].Value != null)
                            {
                                sdi.Hazardous = (row.Cells[dgHZ.Index].Value.ToString() == "Y") ? true : false;
                            }
                            else
                            { sdi.Hazardous = false; }
                            if (row.Cells[dgCL.Index].Value != null)
                            {
                                sdi.Calibration = (row.Cells[dgCL.Index].Value.ToString() == "Y") ? true : false;
                            }
                            else
                            {
                                sdi.Calibration = false;
                            }
                            if (row.Cells[dgCost.Index].Value != null)
                            {
                                sdi.ItemCost = Convert.ToDecimal(row.Cells[dgCost.Index].Value?.ToString());
                            }
                            discountAmount += ((decimal)sdi.UPIME - (decimal)sdi.UCUPCurr) * sdi.Quantity;

                            IME.SaveChanges();
                            Utils.LogKayit("Sale Order", "Sale Order update");
                        }

                        SaleOrder so = IME.SaleOrders.Where(x => x.SaleOrderNo == SaleID).FirstOrDefault();
                        so.TotalDiscount = ((so.DiscOnSubtotal * so.SubTotal) / 100) + discountAmount;

                        IME.SaveChanges();
                    }
                    MessageBox.Show("Sale is successfully update", "Success");
                    #endregion

                    this.Close();
                }
                else
                {
                    decimal saleOrderNo = SaleSave();
                    SaleOrderDetailsSave(saleOrderNo);

                    this.Close();
                }
            }

        }

        private void SaleOrderDetailsSave(decimal SaleID)
        {
            decimal discountAmount = 0;

            IMEEntities IME = new IMEEntities();
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                DataGridViewRow row = dgSaleAddedItems.Rows[i];
                if (row.Cells["dgProductCode"].Value != null)
                {
                    SaleOrderDetail sdi = new SaleOrderDetail();
                    sdi.SaleOrderID = SaleID;
                    if (row.Cells[dgNo.Index].Value != null) sdi.No = Int32.Parse(row.Cells[dgNo.Index].Value.ToString());
                    if (row.Cells[dgProductCode.Index].Value != null) sdi.ItemCode = row.Cells[dgProductCode.Index].Value?.ToString();
                    if (row.Cells[dgQty.Index].Value != null) sdi.Quantity = Int32.Parse(row.Cells[dgQty.Index].Value?.ToString());
                    if (row.Cells[dgUCUPCurr.Index].Value != null) sdi.UCUPCurr = Decimal.Parse(row.Cells[dgUCUPCurr.Index].Value?.ToString());
                    if (row.Cells[dgDisc.Index].Value != null)
                    {
                        sdi.Discount = Decimal.Parse(row.Cells[dgDisc.Index].Value.ToString());
                    }
                    else
                    {
                        sdi.Discount = 0;
                    }

                    if (row.Cells[dgTotal.Index].Value != null) sdi.Total = Decimal.Parse(row.Cells[dgTotal.Index].Value?.ToString());
                    if (!String.IsNullOrEmpty(row.Cells[dgTargetUP.Index].Value?.ToString())) sdi.TargetUP = Decimal.Parse(row.Cells[dgTargetUP.Index].Value?.ToString());
                    if (!String.IsNullOrEmpty(row.Cells[dgCompetitor.Index].Value?.ToString())) sdi.Competitor = row.Cells[dgCompetitor.Index].Value?.ToString();
                    if (row.Cells[dgMPN.Index].Value != null) sdi.MPN = row.Cells[dgMPN.Index].Value?.ToString();
                    if (row.Cells[dgLandingCost.Index].Value != null) sdi.LandingCost = Convert.ToDecimal(row.Cells[dgLandingCost.Index].Value?.ToString());
                    sdi.DeliveryID = Convert.ToInt32(row.Cells[dgDelivery.Index].Value?.ToString());

                    if (row.Cells[dgDesc.Index].Value != null) sdi.ItemDescription = row.Cells[dgDesc.Index].Value?.ToString();
                    if (row.Cells[dgCustDescription.Index].Value != null) sdi.CustomerDescription = row.Cells[dgCustDescription.Index].Value?.ToString();
                    if (row.Cells[dgCustStkCode.Index].Value != null) sdi.CustomerStockCode = row.Cells[dgCustStkCode.Index].Value?.ToString();
                    sdi.IsDeleted = false;
                    if (row.Cells[dgUPIME.Index].Value != null) sdi.UPIME = Decimal.Parse(row.Cells[dgUPIME.Index].Value?.ToString());
                    if (row.Cells[dgMargin.Index].Value != null) sdi.Margin = Decimal.Parse(row.Cells[dgMargin.Index].Value?.ToString());
                    if (!String.IsNullOrEmpty(dgSaleAddedItems.Rows[i].Cells[dgUOM.Index].Value?.ToString()))
                    {
                        sdi.UnitOfMeasure = "EACH";
                    }
                    else
                    {
                        sdi.UnitOfMeasure = row.Cells[dgUOM.Index].Value?.ToString();
                    }
                    if (row.Cells[dgUC.Index].Value != null) sdi.UnitContent = Int32.Parse(row.Cells[dgUC.Index].Value?.ToString());
                    if (row.Cells[dgSSM.Index].Value != null) sdi.SSM = Int32.Parse(row.Cells[dgSSM.Index].Value?.ToString());
                    if (row.Cells[dgUnitWeigt.Index].Value != null) sdi.UnitWeight = Decimal.Parse(row.Cells[dgUnitWeigt.Index].Value?.ToString());
                   // if (row.Cells[dgDependantTable.Index].Value != null) sdi.DependantTable = row.Cells[dgDependantTable.Index].Value?.ToString();
                    if (row.Cells[dgHZ.Index].Value != null)
                    {
                        sdi.Hazardous = (row.Cells[dgHZ.Index].Value.ToString() == "Y") ? true : false;
                    }
                    else
                    { sdi.Hazardous = false; }
                    if (row.Cells[dgCL.Index].Value != null)
                    {
                        sdi.Calibration = (row.Cells[dgCL.Index].Value?.ToString() == "Y") ? true : false;
                    }
                    else
                    {
                        sdi.Calibration = false;
                    }
                    if (row.Cells[dgCost.Index].Value != null)
                    {
                        sdi.ItemCost = Convert.ToDecimal(row.Cells[dgCost.Index].Value);
                    }

                    #region StockApplication
                    //decimal sdID = (decimal)sdi.SaleOrderID;
                    //string product = sdi.ItemCode;
                    //int Qty = sdi.Quantity;
                    //if (IME.Stocks.Where(a => a.ProductID == product).FirstOrDefault() != null && IME.Stocks.Where(a => a.ProductID == product).FirstOrDefault().Qty != 0)
                    //{

                    //}

                    //if (IME.PurchaseOrders.Where(x => x.purchaseOrderId == sdID).FirstOrDefault() != null && IME.PurchaseOrders.Where(x => x.purchaseOrderId == sdID).FirstOrDefault().Customer != null)
                    //{

                    //    Stock StockInfo = IME.Stocks.Where(x => x.ProductID == product).FirstOrDefault();
                    //    if (StockInfo == null)
                    //    {
                    //        StockInfo = new Stock();
                    //        StockInfo.ProductID = product;
                    //        StockInfo.Qty = Qty;
                    //        StockInfo.ReserveQty = Qty;
                    //        IME.Stocks.Add(StockInfo);
                    //        IME.SaveChanges();
                    //        StockReserve sr = new StockReserve();
                    //        sr.Qty = Qty;
                    //        sr.StockID = StockInfo.StockID;
                    //        sr.IsFromRSInvoice = true;
                    //        IME.StockReserves.Add(sr);
                    //        IME.SaveChanges();
                    //    }
                    //    else
                    //    {
                    //        StockInfo.Qty = StockInfo.Qty + Qty;
                    //        StockInfo.ReserveQty = StockInfo.ReserveQty + Qty;
                    //        IME.SaveChanges();
                    //        StockReserve sr = new StockReserve();
                    //        sr.Qty = Qty;
                    //        sr.StockID = StockInfo.StockID;
                    //        sr.IsFromRSInvoice = true;
                    //        IME.StockReserves.Add(sr);
                    //        IME.SaveChanges();
                    //    }
                    //}
                    //else
                    //{//Bizim stockumuz için demek
                    //    Stock stockInfo = new Stock();
                    //    stockInfo.ProductID = product;
                    //    stockInfo.Qty = Qty;
                    //    stockInfo.ReserveQty = 0;
                    //}
                    #endregion

                    discountAmount += ((decimal)sdi.UPIME - (decimal)sdi.UCUPCurr) * sdi.Quantity;

                    IME.SaleOrderDetails.Add(sdi);
                    IME.SaveChanges();
                    Utils.LogKayit("Sale Order", "Sale Order added");
                }

                SaleOrder so = IME.SaleOrders.Where(x => x.SaleOrderID == SaleID).FirstOrDefault();
                so.TotalDiscount = ((so.DiscOnSubtotal * so.SubTotal) / 100) + discountAmount;

                IME.SaveChanges();
            }
            MessageBox.Show("Sale is successfully added", "Success");
            this.Close();
        }

        private decimal SaleSave()
        {
            try
            {
                //getTotalDiscMargin();
                SaleOrder s = new SaleOrder();
                s.SaleOrderNo = Int32.Parse(txtSalesOrderNo.Text.Substring(2));
                s.SaleDate = Utils.GetCurrentDateTime();
                s.OnlineConfirmationNo = txtOnlineConfirmationNo.Text;
                s.QuotationNos = txtQuotationNo.Text;
                s.PaymentTermID = (int)cbPaymentTerm.SelectedValue;
                s.RequestedDeliveryDate = dtpRequestedDelvDate.Value.Date;
                s.Vat = Convert.ToDecimal(lblVat.Text);
                s.TotalPrice = Convert.ToDecimal(lbltotal.Text);
                s.CustomerID = CustomerCode.Text;
                s.ContactID = (int)cbWorkers.SelectedValue;
                s.DeliveryContactID = (int)cbDeliveryContact.SelectedValue;
                s.InvoiceAddressID = (int)cbInvoiceAdress.SelectedValue;
                s.DeliveryAddressID = (int)cbDeliveryAddress.SelectedValue;
                s.RepresentativeID = (int)cbRep.SelectedValue;
                s.PaymentMethodID = (int)cbPayment.SelectedValue;
                s.NoteForUs = txtNoteForUs.Text;
                //s.NoteForCustomer = txtNoteForCustomer.Text;
                s.NoteForFinance = (chkbForFinance.Checked == true) ? 1 : 0;
                s.SaleOrderNature = cbOrderNature.SelectedItem.ToString();
                s.ShippingType = cbSMethod.SelectedItem.ToString();
                s.Status = "Active";

                s.LPONO = txtLPONO.Text;
                s.TotalMargin = Convert.ToDecimal(txtTotalMargin.Text);
                s.Factor = Convert.ToDecimal(cbFactor.Text);
                s.SubTotal = Convert.ToDecimal(lblsubtotal.Text);
                s.DiscOnSubtotal = (txtTotalDis.Text != null && txtTotalDis.Text != String.Empty) ? Convert.ToDecimal(txtTotalDis.Text) : 0;
                s.ExtraCharges = (txtExtraChanges.Text != null && txtExtraChanges.Text != String.Empty) ? Convert.ToDecimal(txtExtraChanges.Text) : 0;
                s.financialYearId = (decimal)Utils.getManagement().CurrentFinancialYear;
                s.exchangeRateID = curr.exchangeRateID;

                if (!String.IsNullOrEmpty(txtQuotationNo.Text))
                {
                    string[] quotationNos = txtQuotationNo.Text.Split(',');

                    foreach (string no in quotationNos)
                    {
                        IME.Quotations.Where(x => x.QuotationNo == no).FirstOrDefault().status = "Passive";
                        IME.Quotations.Where(x => x.QuotationNo == no).FirstOrDefault().SaleOrderID = s.SaleOrderID;
                    }
                }

                s.DistributeDiscount = cbDeliverDiscount.Checked;
                IME.SaleOrders.Add(s);
                IME.SaveChanges();



                DebitCustomer();

                return s.SaleOrderID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void DebitCustomer()
        {
            IMEEntities db = new IMEEntities();

            Customer c = db.Customers.Where(x => x.ID == customer.ID).FirstOrDefault();
            decimal debitPrice = ConvertToDefaultCurrency(Convert.ToDecimal(SaleCurrency), Convert.ToDecimal(lblGrossTotal.Text));
            c.Debit = (c.Debit != null) ? c.Debit + debitPrice : debitPrice;
            db.SaveChanges();
        }

        private decimal ConvertToDefaultCurrency(decimal _CurrencyRate, decimal _Amount)
        {
            return (_Amount * _CurrencyRate);
        }

        private void modifyQuotation(SaleOrder q)
        {
            //#region QuotationLoader
            //LandingCost.Enabled = true;

            //if (importFromQuotation == 0)
            //{
            //    txtQuotationNo.Text = CreateQuotationID(QuotationIdMod.CreateVersion, q);
            //    txtLPONO.Text = q.LPONO;
            //    CustomerCode.Text = q.Customer.ID;
            //    txtCustomerName.Text = q.Customer.c_name;
            //    cbFactor.Text = Utils.getManagement().Factor.ToString();
            //    if (q.QuotationMainContact != null)
            //    {
            //        cbWorkers.SelectedValue = (int)q.QuotationMainContact;
            //    }
            //    else
            //    {
            //        cbWorkers.Text = q.MainContactName;
            //    }
            //    if (q.NoteForCustomerID != null) txtNoteForCustomer.Text = IME.Notes.Where(a => a.ID == q.NoteForCustomerID).FirstOrDefault().Note_name;
            //    if (q.NoteForCustomerID != null) txtNoteForUs.Text = IME.Notes.Where(a => a.ID == q.NoteForUsID).FirstOrDefault().Note_name;
            //    fillCustomer();
            //}
            //else if (importFromQuotation == 1)
            //{
            //    txtLPONO.Text = q.LPONO;
            //    CustomerCode.Text = q.Customer.ID;
            //    txtCustomerName.Text = q.Customer.c_name;
            //    txtQuotationNo.Text = q.QuotationNo;
            //    if (this.Text == "View Quotation")
            //    {
            //        cbFactor.Text = q.Factor.ToString();
            //    }
            //    else
            //    {
            //        cbFactor.Text = Utils.getManagement().Factor.ToString();
            //    }
            //    fillCustomer();
            //}
            //if (q.ForFinancelIsTrue == 1) { chkbForFinance.Checked = true; }
            //#region QuotationDetails
            //var QuoCurr = IME.Currencies.Where(a => a.currencyName == q.CurrName).FirstOrDefault();
            //if (QuoCurr != null) cbCurrency.SelectedValue = QuoCurr.currencyID;

            //foreach (var item in q.SaleOrderDetails)
            //{
            //    if (item.IsDeleted == true)
            //    {
            //        DataGridViewRow row = (DataGridViewRow)dgSaleDeleted.Rows[0].Clone();
            //        row.Cells[dgNo.Index].Value = item.No;
            //        row.Cells[dgProductCode1.Index].Value = item.ItemCode;
            //        row.Cells[dgQty1.Index].Value = item.Quantity;
            //        row.Cells[dgSSM1.Index].Value = item.SSM;
            //        row.Cells[dgUC1.Index].Value = item.UC;
            //        row.Cells[dgUPIME1.Index].Value = item.UPIME;
            //        row.Cells[dgUCUPCurr1.Index].Value = item.UCUPCurr;
            //        row.Cells[dgDisc1.Index].Value = item.Disc;
            //        row.Cells[dgDelivery1.Index].Value = item.DeliveryID;
            //        row.Cells[dgTotal1.Index].Value = item.Total;
            //        row.Cells[dgTargetUP1.Index].Value = item.TargetUP;
            //        row.Cells[dgCompetitor1.Index].Value = item.Competitor;
            //        //row.Cells[dgUKPrice1.Index].Value = item.UKPrice;
            //        row.Cells[dgUnitWeigt1.Index].Value = item.UnitWeight;
            //        row.Cells[dgTotalWeight.Index].Value = item.UnitWeight * item.Qty;
            //        row.Cells[dgCustomerStokCode1.Index].Value = item.CustomerStockCode;
            //        dgSaleDeleted.Rows.Add(row);
            //    }
            //    else
            //    {
            //        DataGridViewRow row = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
            //        row.CreateCells(dgSaleAddedItems);
            //        row.Cells[dgNo.Index].Value = /*Decimal.Parse(item.dgNo.ToString())*/item.No;
            //        row.Cells[dgProductCode.Index].Value = item.ItemCode;
            //        row.Cells[dgQty.Index].Value = item.Quantity;
            //        row.Cells[dgSSM.Index].Value = item.SSM;
            //        row.Cells[dgUC.Index].Value = item.UC;
            //        row.Cells[dgUPIME.Index].Value = Math.Round((decimal)item.UPIME, 4);
            //        row.Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
            //        row.Cells[dgDisc.Index].Value = item.Disc;
            //        row.Cells[dgDelivery.Index].Value = item.DeliveryID;
            //        row.Cells[dgTotal.Index].Value = item.Total;
            //        row.Cells[dgTargetUP.Index].Value = item.TargetUP;
            //        row.Cells[dgCompetitor.Index].Value = item.Competitor;
            //        row.Cells[dgUnitWeigt.Index].Value = item.UnitWeight;
            //        row.Cells[dgUKPrice.Index].Value = item.UKPrice;
            //        row.Cells[dgTotalWeight.Index].Value = item.UnitWeight * item.Qty;
            //        row.Cells[dgCustStkCode.Index].Value = item.CustomerStockCode;
            //        row.Cells[dgMargin.Index].Value = item.Marge;
            //        dgSaleAddedItems.Rows.Add(row);

            //    }
            //}

            //for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            //{

            //    GetLandingCost(i);
            //    dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[i].Cells[dgNo.Index];
            //    GetQuotationQuantity(i);

            //}

            //if (q.DistributeDiscount == true)
            //{
            //    cbDeliverDiscount.Checked = true;
            //}

            //#endregion
            ////buradaki yazılanların sırası önemli sırayı değiştirmeyin
            //lblsubtotal.Text = q.SubTotal.ToString();
            //txtTotalDis2.Text = q.DiscOnSubTotal2.ToString();
            //if (txtTotalDis2.Text == null || txtTotalDis2.Text == "") txtTotalDis2.Text = "0";
            //decimal totaldis = Math.Round((Decimal.Parse(txtTotalDis2.Text) * 100) / decimal.Parse(lblsubtotal.Text), 4);
            //txtTotalDis.Text = totaldis.ToString();
            //lbltotal.Text = (q.DistributeDiscount == false) ? (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString() : lblsubtotal.Text;
            //txtExtraChanges.Text = q.ExtraCharges.ToString();
            //lblVat.Text = vat.ToString();
            //if (q.IsVatValue == 1) { chkVat.Checked = true; } else { chkVat.Checked = false; }
            ////
            //if (q.IsWeightCost == 1) { ckWeightCost.Checked = true; } else { ckWeightCost.Checked = false; }
            //if (q.IsCustomsDuties == 1) { ckCustomsDuties.Checked = true; } else { ckCustomsDuties.Checked = false; }
            ////Buraya Curr verileri gelecek
            //#endregion
            //try
            //{
            //    if (dgSaleAddedItems.RowCount > 1)
            //    {
            //        dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgNo.Index].Value = (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 2].Cells[dgNo.Index].Value.ToString()) + 1).ToString();
            //    }
            //    else { dgSaleAddedItems.Rows[0].Cells[dgNo.Index].Value = 1.ToString(); }
            //}
            //catch { }

            //string q1 = q.QuotationNo;
            //if (IME.Quotations.Where(a => a.QuotationNo == q1).ToList().Count > 0)
            //{
            //    if (q.QuotationNo.Contains("v"))
            //    {
            //        string quoID = q1.Substring(q.QuotationNo.LastIndexOf('/') + 1).ToString();

            //        quoID = (quoID.Substring(0, quoID.IndexOf('v') + 1)).ToString();

            //        string qNo = IME.Quotations.Where(a => a.QuotationNo.Contains(quoID.ToString())).OrderByDescending(b => b.QuotationNo).FirstOrDefault().QuotationNo;

            //        q1 = (q.QuotationNo.Substring(0, q.QuotationNo.IndexOf('v') + 1)).ToString();

            //        q1 = q1 + quoID.ToString();
            //    }
            //}
           
        }


        private void modifyQuotation(SaleOrder q, string aa)
        {
            #region QuotationLoader
            if (importFromQuotation == 0)
            {
                txtQuotationNo.Text = q.QuotationNos;/*Modify 1*/
                txtLPONO.Text = q.LPONO;
                CustomerCode.Text = q.Customer.ID;
                txtCustomerName.Text = q.Customer.c_name;
                cbFactor.Text = Utils.getManagement().Factor.ToString();
                if (q.Customer != null && q.Customer.MainContactID != null)
                {
                    cbWorkers.SelectedValue = (int)q.Customer.MainContactID;
                }
                else
                {
                    cbWorkers.Text = "";
                }
                if (q.NoteForCustomer != null) txtNoteForUs.Text = IME.Notes.Where(a => a.ID == q.Customer.customerNoteID).FirstOrDefault().Note_name;
                fillCustomer();
            }
            else if (importFromQuotation == 1)
            {
                txtQuotationNo.Text = NewQuotationID();
                fillCustomer();
            }
            #region QuotationDetails
            
            foreach (var item in q.SaleOrderDetails)
            {
                if (item.IsDeleted == true)
                {
                    DataGridViewRow row = (DataGridViewRow)dgSaleDeleted.Rows[0].Clone();
                    row.Cells[dgNo.Index].Value = item.No;
                    row.Cells[dgProductCode1.Index].Value = item.ItemCode;
                    row.Cells[dgQty1.Index].Value = item.Quantity;
                    row.Cells[dgSSM1.Index].Value = item.SSM;
                    row.Cells[dgUC1.Index].Value = item.UnitContent;
                    row.Cells[dgUPIME1.Index].Value = item.UPIME;
                    row.Cells[dgUCUPCurr1.Index].Value = item.UCUPCurr;
                    row.Cells[dgDisc1.Index].Value = item.Discount;
                    row.Cells[dgDelivery1.Index].Value = item.DeliveryID;
                    row.Cells[dgTotal1.Index].Value = item.Total;
                    row.Cells[dgTargetUP1.Index].Value = item.TargetUP;
                    row.Cells[dgCompetitor1.Index].Value = item.Competitor;
                    //row.Cells[dgUKPrice1.Index].Value = item.UKPrice;
                    row.Cells[dgUnitWeigt1.Index].Value = item.UnitWeight;
                    row.Cells[dgTotalWeight.Index].Value = item.UnitWeight * item.Quantity;
                    row.Cells[dgCustomerStokCode1.Index].Value = item.CustomerStockCode;
                    dgSaleDeleted.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                    row.CreateCells(dgSaleAddedItems);
                    row.Cells[dgNo.Index].Value = /*Decimal.Parse(item.dgNo.ToString())*/item.No;
                    row.Cells[dgProductCode.Index].Value = item.ItemCode;
                    row.Cells[dgQty.Index].Value = item.Quantity;
                    row.Cells[dgSSM.Index].Value = item.SSM;
                    row.Cells[dgUC.Index].Value = item.UnitContent;
                    row.Cells[dgUPIME.Index].Value = Math.Round((decimal)item.UPIME, 4);
                    row.Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                    row.Cells[dgDisc.Index].Value = item.Discount;
                    row.Cells[dgDelivery.Index].Value = item.DeliveryID;
                    row.Cells[dgTotal.Index].Value = item.Total;
                    row.Cells[dgTargetUP.Index].Value = item.TargetUP;
                    row.Cells[dgCompetitor.Index].Value = item.Competitor;
                    row.Cells[dgUnitWeigt.Index].Value = item.UnitWeight;
                    row.Cells[dgUKPrice.Index].Value = item.UKPrice;
                    row.Cells[dgTotalWeight.Index].Value = item.UnitWeight * item.Quantity;
                    row.Cells[dgCustStkCode.Index].Value = item.CustomerStockCode;
                    row.Cells[dgMargin.Index].Value = item.Margin;
                    dgSaleAddedItems.Rows.Add(row);

                }
            }
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {

                GetLandingCost(i);
                // dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[i].Cells[dgNo.Index];
                GetQuotationQuantity(i);

            }

            if (q.DistributeDiscount == true)
            {
                cbDeliverDiscount.Checked = true;
            }

            #endregion
            //buradaki yazılanların sırası önemli sırayı değiştirmeyin
            lblsubtotal.Text = q.SubTotal.ToString();
            txtTotalDis2.Text = q.DiscOnSubTotal2.ToString();
            if (txtTotalDis2.Text == null || txtTotalDis2.Text == "") txtTotalDis2.Text = "0";
            if (q.DistributeDiscount == true)
            {
                txtTotalDis.Text = Math.Round((Decimal.Parse(txtTotalDis2.Text) * 100) / (decimal.Parse(lblsubtotal.Text) + Decimal.Parse(txtTotalDis2.Text)), 4).ToString();
            }
            else
            {
                txtTotalDis.Text = Math.Round((Decimal.Parse(txtTotalDis2.Text) * 100) / decimal.Parse(lblsubtotal.Text), 4).ToString();
            }
            lbltotal.Text = (q.DistributeDiscount == false) ? (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString() : lblsubtotal.Text;
            txtExtraChanges.Text = q.ExtraCharges.ToString();
            lblVat.Text = q.Vat.ToString();
            //Buraya Curr verileri gelecek
            #endregion
            try
            {
                if (dgSaleAddedItems.RowCount > 1)
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgNo.Index].Value = (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 2].Cells[dgNo.Index].Value.ToString()) + 1).ToString();
                }
                else { dgSaleAddedItems.Rows[0].Cells[dgNo.Index].Value = 1.ToString(); }
            }
            catch { }
        }


        private void QuotataionModifyItemDetailsFiller(string ArticleNoSearch, int RowIndex)
        {
            CurrentRow = dgSaleAddedItems.Rows[RowIndex];
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

            if (ItemTabDetails != null)
            {

                CurrentRow.Cells["dgDesc"].Value = ItemTabDetails.Article_Desc;
                CurrentRow.Cells["dgSSM"].Value = ItemTabDetails.Pack_Quantity.ToString() ?? ""; ;
                CurrentRow.Cells["dgUC"].Value = ItemTabDetails.Unit_Content.ToString() ?? ""; ;
                CurrentRow.Cells["dgUOM"].Value = ItemTabDetails.Unit_Measure;
                CurrentRow.Cells["dgMPN"].Value = ItemTabDetails.MPN;
                CurrentRow.Cells["dgCL"].Value = ItemTabDetails.Calibration_Ind;
                if (ItemTabDetails.Standard_Weight != 0 && ItemTabDetails.Standard_Weight != null)
                {
                    decimal sW = (decimal)(ItemTabDetails.Standard_Weight / (decimal)1000);
                    sW = (ItemTabDetails.Pack_Quantity > ItemTabDetails.Unit_Content) ? (decimal)(sW / ItemTabDetails.Pack_Quantity) : (decimal)(sW / ItemTabDetails.Unit_Content);
                    txtStandartWeight.Text = sW.ToString("G29");
                }
                txtHazardousInd.Text = ItemTabDetails.Hazardous_Ind;
                txtCalibrationInd.Text = ItemTabDetails.Calibration_Ind;
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

                txtGrossWeight.Text = String.Format("{0:0.0000}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());

                #region Length
                try
                {
                    if (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
                    {
                        txtGrossWeight.Text = String.Format("{0:0.0000}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());
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
                if (ItemTabDetails.Environment != null) { txtEnvironment.Text = "Y"; isEnvironment = true; } else { txtEnvironment.Text = ""; }
                txtLithium.Text = (ItemTabDetails.Lithium != null && ItemTabDetails.Lithium != String.Empty) ? "Y" : "";
                txtShipping.Text = (ItemTabDetails.Shipping != null && ItemTabDetails.Shipping != String.Empty) ? "Y" : "";

                if (txtLithium.Text == "Y") isLithum = true;
                if (txtShipping.Text == "Y") isShipping = true;
                if (ItemTabDetails.Calibration_Ind != null)
                    txtRSStock.Text = ItemTabDetails.OnhandStockBalance.ToString();
                txtRSOnOrder.Text = ItemTabDetails.QuantityonOrder.ToString();
                txtDiscontinuationDate.Text = ItemTabDetails.DiscontinuationDate;
                txtRunOn.Text = ItemTabDetails.Runon?.ToString();
                txtReferral.Text = ItemTabDetails.Referral?.ToString();
                txtLicenceType.Text = ItemTabDetails.LicenceType;
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
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.Red;
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
            if (dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value != null)
            {

                dgSaleAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = ((Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value.ToString())) / Currfactor).ToString();
                dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = Math.Round(((Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString())) / Currfactor), 4).ToString();
                dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value = Math.Round(((Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())) / Currfactor), 4);
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
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                #region Get Margin
                if (dgSaleAddedItems.Rows[i].Cells["dgQty"].Value != null && dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString() != "0")
                {
                    CurrentRow = dgSaleAddedItems.Rows[i];
                    CurrentRow.Cells["dgUCUPCurr"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString())) / Currfactor), 4).ToString();
                    CurrentRow.Cells["dgUPIME"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString())) / Currfactor), 4).ToString();
                    CurrentRow.Cells["dgTotal"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString())) / Currfactor), 4).ToString();

                }
                #endregion
            }
            CalculateSubTotal();
            lblCurrValue.Text = Math.Round(CurrValue, 4).ToString();
        }

        private void lblVatTotal_TextChanged(object sender, EventArgs e)
        {
            if (lblVatTotal.Text != Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lblVatTotal.Text)))).ToString("G29")
                )
            {
                lblVatTotal.Text = Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lblVatTotal.Text)))).ToString("G29");
            }
        }

        private void lblGrossTotal_TextChanged(object sender, EventArgs e)
        {
            if (lblGrossTotal.Text != Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lblGrossTotal.Text)))).ToString("G29")
                           )
            {
                lblGrossTotal.Text = Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lblGrossTotal.Text)))).ToString("G29");
            }
        }

        private void ItemsClear()
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgSaleAddedItems.CurrentRow;
                row.Cells[1].Style.BackColor = Color.White;
                row.Cells[2].Style.BackColor = Color.White;
                row.Cells[3].Style.BackColor = Color.White;
                row.Cells[4].Style.BackColor = Color.White;
                row.Cells[5].Style.BackColor = Color.White;
                row.Cells[6].Style.BackColor = Color.White;
                for (int i = 7; i < row.Cells.Count; i++)
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
                DataGridViewRow row = (DataGridViewRow)dgSaleAddedItems.CurrentRow;
                row.Cells[1].Style.BackColor = Color.White;
                row.Cells[2].Style.BackColor = Color.White;
                row.Cells[3].Style.BackColor = Color.White;
                row.Cells[4].Style.BackColor = Color.White;
                row.Cells[5].Style.BackColor = Color.White;
                row.Cells[6].Style.BackColor = Color.White;
                for (int i = 8; i < row.Cells.Count; i++)
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
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(customer);
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
            dgSaleAddedItems.Focus();
            dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index];

        }

        private void ChangeCurrnetCellCellEnd(int currindex)
        {
            try
            {

                if (dgSaleAddedItems.Columns[dgSaleAddedItems.CurrentCell.ColumnIndex].HeaderText == "Item Code" && !String.IsNullOrEmpty(dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value?.ToString()))
                {
                    dgSaleAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                    dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index];
                }
                else if (dgSaleAddedItems.Columns[dgSaleAddedItems.CurrentCell.ColumnIndex].HeaderText == "Qty" && !String.IsNullOrEmpty(dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value?.ToString()))
                {
                    dgSaleAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
                    dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgQty.Index];
                }
                else if (dgSaleAddedItems.Columns[dgSaleAddedItems.CurrentCell.ColumnIndex].HeaderText == "U/C U/P (Curr.)")
                {
                    if (dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value == null)
                    {
                        dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index];
                    }
                    else
                    {

                        DataGridViewRow dgRow = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                        int rowIndex = dgSaleAddedItems.Rows.Add(dgRow);
                        dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index];
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

                if (dgSaleAddedItems.Columns[dgSaleAddedItems.CurrentCell.ColumnIndex].HeaderText == "Item Code" && !String.IsNullOrEmpty(dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value?.ToString()))
                {
                    dgSaleAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                    dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgQty.Index];
                }
                else if (dgSaleAddedItems.Columns[dgSaleAddedItems.CurrentCell.ColumnIndex].HeaderText == "Qty" && !String.IsNullOrEmpty(dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value?.ToString()))
                {
                    dgSaleAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
                    dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgUCUPCurr.Index];
                }
                else if (dgSaleAddedItems.Columns[dgSaleAddedItems.CurrentCell.ColumnIndex].HeaderText == "U/C U/P (Curr.)")
                {
                    if (dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value == null)
                    {
                        dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index];
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value.ToString()) && dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value.ToString() != "")
                        {
                            DataGridViewRow dgRow = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                            int rowIndex = dgSaleAddedItems.Rows.Add(dgRow);
                            dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index];
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
            if (dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && IME.ArticleSearch(dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()).Count() == 1)
            {
                int row = dgSaleAddedItems.CurrentCell.RowIndex;
                while (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells[currindex].ReadOnly == true)
                {
                    if (currindex == dgSaleAddedItems.ColumnCount - 2)
                    {
                        if (dgSaleAddedItems.RowCount - 1 == row && dgSaleAddedItems.CurrentRow.Cells["dgDesc"].Value != null)
                        {
                            DataGridViewRow dgRow = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                            dgSaleAddedItems.Rows.Add(dgRow);
                        }
                        if (dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value == null)
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
                    dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[row].Cells[currindex - 1];
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
                ChangeCurrnetCellTabKey(dgSaleAddedItems.CurrentCell.ColumnIndex + 1);
                dgSaleAddedItems.Focus();
            }
            else if ((e.KeyCode == Keys.Escape))
            {
                ChangeCurrnetCell(dgSaleAddedItems.CurrentCell.ColumnIndex + 1);
                dgSaleAddedItems.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ChangeCurrnetCell(dgSaleAddedItems.CurrentCell.ColumnIndex + 1);
                if (dgSaleAddedItems.CurrentRow.Index != dgSaleAddedItems.RowCount - 1) SendKeys.Send("{UP}");
                dgSaleAddedItems.Focus();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgSaleDeleted.Columns[dgDelivery1.Index];

                deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
                deliveryColumn.DisplayMember = "DeliveryName";
                deliveryColumn.ValueMember = "ID";
                foreach (DataGridViewRow item in dgSaleAddedItems.SelectedRows)
                {
                    decimal rownumber = Decimal.Parse(dgSaleAddedItems.Rows[item.Index].Cells["dgNo"].Value.ToString());
                    dgSaleDeleted.Rows.Add();
                    for (int i = 0; i < dgSaleDeleted.Columns.Count; i++)
                    {
                        dgSaleDeleted.Rows[dgSaleDeleted.Rows.Count - 2].Cells[i].Value = item.Cells[i].Value;
                    }
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null)
                {
                    if (dgSaleAddedItems.CurrentRow.Index > 0)
                    {
                        dgSaleAddedItems.ClearSelection();
                        dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentRow.Index - 1].Selected = true;
                        QuotataionModifyItemDetailsFiller(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentRow.Index - 1].Cells[dgProductCode.Index].Value.ToString(), dgSaleAddedItems.CurrentRow.Index - 1);
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null && dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value != null)
                {
                    if (dgSaleAddedItems.CurrentRow.Index < dgSaleAddedItems.RowCount - 1)
                    {
                        dgSaleAddedItems.ClearSelection();
                        dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentRow.Index + 1].Selected = true;
                        QuotataionModifyItemDetailsFiller(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentRow.Index + 1].Cells[dgProductCode.Index].Value.ToString(), dgSaleAddedItems.CurrentRow.Index + 1);
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
                for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                {
                    if ((dgSaleAddedItems.Rows[i].Cells["HS"].Style.BackColor != Color.Red) && (dgSaleAddedItems.Rows[i].Cells["LI"].Style.BackColor != Color.Ivory))
                    {
                        if (dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value != null)
                        {
                            subtotal += decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                        }
                    }
                }
                //
                decimal totaldis = Math.Round((Decimal.Parse(txtTotalDis2.Text) * 100) / subtotal, 1);
                txtTotalDis.Text = totaldis.ToString();
                lbltotal.Text = (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString();
            }
            Disc();
        }



        private void txtTotalDis_Leave(object sender, EventArgs e)
        {
            if (lblsubtotal.Text != null && lblsubtotal.Text != string.Empty)
            {
                if (txtTotalDis.Text == null || txtTotalDis.Text == "") txtTotalDis.Text = "0";
                if (lblsubtotal.Text != "" && Decimal.Parse(lblsubtotal.Text) != 0 && lblsubtotal.Text != null)
                {
                    //hz ve lithum disc dan etkilenmeyecek
                    decimal hztotal = 0;

                    for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                    {
                        if (dgSaleAddedItems.Rows[i].Cells["HS"].Style.BackColor == Color.Red)
                        {
                            hztotal += decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString());
                        }
                        else if (dgSaleAddedItems.Rows[i].Cells["LI"].Style.BackColor == Color.Ivory)
                        {
                            hztotal += decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value?.ToString());
                        }
                        //else if ()//HE için
                        //{

                        //}
                    }
                    //
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
                        decimal subtotal = Math.Round(Decimal.Parse(lblsubtotal.Text) - hztotal, 4);
                        //decimal dis2 = Math.Round(subtotal * Decimal.Parse(txtTotalDis.Text) / 100,0);
                        decimal dis2 = Math.Round(((subtotal * Decimal.Parse(txtTotalDis.Text)) / 100), 3);
                        txtTotalDis2.Text = dis2.ToString();
                        lbltotal.Text = Math.Round((Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)), 4).ToString();
                    }
                }
                if (txtTotalMarge.Visible == true)
                {
                    CalculateTotalMarge();
                }

            }
            Disc();
        }

        public void ChangeDataGrid()
        {
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value != null)
                {
                    decimal total = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()) * Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                    dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value = ((total) - (((total) * Decimal.Parse(txtTotalDis2.Text)) / Decimal.Parse(lblsubtotal.Text))).ToString();
                    dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = (Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString()) / Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString();

                }
            }
        }

        /// <summary>
        /// Calculates Total Margin after general discount
        /// </summary>
        private void CalculateTotalMarge()
        {
            if (dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value != null && dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value.ToString() != "")
            {
                decimal AllMargin = 0;
                if (cbDeliverDiscount.Checked)
                {
                    foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
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

                    for (int i = 0; i < dgSaleAddedItems.RowCount - 1; i++)
                    {
                        if (!String.IsNullOrEmpty(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString()))
                        {
                            //(1-(Cost/U/C U/P))*100
                            decimal cost = 0;
                            decimal DiscountRate = 0;
                            decimal UCUP = 0;
                            decimal totalDiscount = 0;
                            decimal margin = 0;
                            //try { ucupcurr = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString()); } catch { }
                            try
                            { DiscountRate = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgDisc.Index].Value.ToString()); }
                            catch { }
                            try { totalDiscount = DiscountRate + decimal.Parse(txtTotalDis.Text); } catch { }
                            try { cost = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString()); } catch { }
                            cost = cost / Currfactor;
                            try { UCUP = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgUPIME.Index].Value.ToString()); } catch { }
                            decimal total = 0;
                            try { total = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString()); } catch { }
                            UCUP = (UCUP * (100 - totalDiscount)) / 100;
                            margin = (1 - (cost / UCUP)) * 100;
                            AllMargin = AllMargin + (margin * total);
                        }
                    }
                }
                if (lblsubtotal.Text != null && lblsubtotal.Text != "" && AllMargin != 0) AllMargin = AllMargin / decimal.Parse(lblsubtotal.Text);
                if (AllMargin != 0)
                {
                    txtTotalMarge.Text = Math.Round(AllMargin, 3).ToString();
                }
                else
                {
                    txtTotalMarge.Text = (0.00).ToString();
                }
            }
        }
        private decimal calculateTotalMargin()
        {
            DateTime today = DateTime.Today;
            CurrentRow = dgSaleAddedItems.CurrentRow;
            #region Kur Hesaplama
            decimal currentGbpValue = Convert.ToDecimal(IME.Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);

            #endregion

            decimal totalCost = 0;
            decimal totalPrice = 0;

            foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
            {
                decimal gbpPrice = 0;
                if (item.Cells[dgTotal.Index].Value != null && item.Cells[dgTotal.Index].Value.ToString() != "" && item.Cells[dgUCUPCurr.Index].Value != null && item.Cells[dgUCUPCurr.Index].Value.ToString() != "")
                {
                    gbpPrice = ((Convert.ToDecimal(item.Cells[dgTotal.Index].Value.ToString())) * CurrValue) / currentGbpValue;
                }
                if (item.Cells[dgLandingCost.Index].Value != null && item.Cells[dgLandingCost.Index].Value.ToString() != "" && item.Cells[dgQty.Index].Value != null && item.Cells[dgQty.Index].Value.ToString() != "" && item.Cells[dgQty.Index].Value.ToString() != "0")
                {
                    totalCost += Convert.ToDecimal(item.Cells[dgLandingCost.Index].Value) * Convert.ToDecimal(item.Cells[dgQty.Index].Value);
                    totalPrice += gbpPrice;
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
                    Disc = Convert.ToDecimal(txtTotalDis2.Text);
                    gbpDisc = (Disc * CurrValue) / currentGbpValue;
                }
                return ((1 - (totalCost / (totalPrice - gbpDisc))) * 100);
            }
        }

        private void txtExtraChanges_TextChanged(object sender, EventArgs e)
        {
            decimal ExtraCharge = 0;

            try { ExtraCharge = Decimal.Parse(txtExtraChanges.Text); } catch { }
            lblTotalExtra.Text = (ExtraCharge + Decimal.Parse(lbltotal.Text)).ToString();
        }

        private void txtExtraChanges_Leave(object sender, EventArgs e)
        {
            if (txtExtraChanges.Text != null && txtExtraChanges.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtExtraChanges.Text);
                sonuc = Math.Round(sonuc, 4);
                txtExtraChanges.Text = sonuc.ToString();
            }
        }

        private void txtExtraChanges_Click(object sender, EventArgs e)
        {

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
            btnProductHistory.Font = new Font(btnProductHistory.Font, btnProductHistory.Font.Style ^ FontStyle.Underline);
            btnProductHistory.Text = "Product History";

            if (!String.IsNullOrEmpty(dgSaleAddedItems.CurrentRow.Cells["dgProductCode"].Value.ToString()))
                item_code = dgSaleAddedItems.CurrentRow.Cells["dgProductCode"].Value.ToString();
            if (item_code == null)
                MessageBox.Show("Please Enter an Item Code", "Error!");
            else
            {
                ViewProductHistory f = new ViewProductHistory(item_code, "SaleOrder");
                try { f.ShowDialog(); } catch { }
            }
            #endregion
        }

        private void dgQuotationAddedItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                string ArticleNO = null;
                if (dgSaleAddedItems.CurrentCell.Value != null) ArticleNO = dgSaleAddedItems.CurrentCell.Value.ToString();
                FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(ArticleNO);
                itemsearch.ShowDialog();
                this.Enabled = true;
                try
                {
                    //Bu item daha önceden eklimi diye kontrol ediyor
                    DataGridViewRow row = dgSaleAddedItems.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["dgProductCode"].Value.ToString().Equals(QuotationUtils.ItemCode)).FirstOrDefault();
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
                dgSaleAddedItems.CurrentCell.Value = QuotationUtils.ItemCode;
                if (dgSaleAddedItems.CurrentCell.Value != null)
                {
                    try { sdNumber = IME.SuperDisks.Where(a => a.Article_No.Contains(dgSaleAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdNumber = 0; }
                    try { sdPNumber = IME.SuperDiskPs.Where(a => a.Article_No.Contains(dgSaleAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdPNumber = 0; }
                    try { erNumber = IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(dgSaleAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { erNumber = 0; }
                    if (sdNumber == 1 || sdPNumber == 1 || erNumber == 1)
                    {
                        if (QuotationUtils.HasMultipleItems(dgSaleAddedItems.CurrentCell.Value.ToString()) == 0)
                        {
                            if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
                            ItemDetailsFiller(dgSaleAddedItems.CurrentCell.Value.ToString());
                            //LandingCost Calculation
                            FillProductCodeItem();

                            dgSaleAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                            dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value = null;
                            dgSaleAddedItems.CurrentRow.Cells["dgQty"].Style = dgSaleAddedItems.DefaultCellStyle;
                            #region DataGridClear
                            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value = null;
                            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgDisc"].Value = null;
                            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
                            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUPIME"].Value = null;
                            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
                            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value = null;

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
            foreach (DataGridViewRow item in dgSaleDeleted.SelectedRows)
            {
                if (!String.IsNullOrEmpty(item.Cells["dgProductCode1"].Value.ToString()))
                {
                    int rowindex = item.Index;
                    int no = Int32.Parse(dgSaleDeleted.Rows[rowindex].Cells["No1"].Value.ToString());

                    int rowindex1 = dgSaleAddedItems.RowCount;

                    dgSaleAddedItems.Rows.Add();
                    decimal row1 = Decimal.Parse(dgSaleAddedItems.Rows[rowindex1].Cells[dgNo.Index].Value.ToString());

                    //for (int i = 0; i < dgQuotationAddedItems.Rows.Count; i++)
                    //{
                    //    //if(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString())== Int32.Parse(dgQuotationDeleted.Rows[item.Index].Cells[0].Value.ToString())&& (dgQuotationAddedItems.Rows[i].Cells[7].Value=="" || dgQuotationAddedItems.Rows[i].Cells[7].Value==null))
                    //    //{
                    //    //    dgQuotationAddedItems.Rows.Remove(dgQuotationAddedItems.Rows[i]);
                    //    //    rowindex1--;
                    //    //}
                    //}

                    for (int i = 0; i < dgSaleDeleted.Columns.Count; i++)
                    {
                        dgSaleAddedItems.Rows[rowindex1].Cells[i].Value = dgSaleDeleted.Rows[item.Index].Cells[i].Value;
                    }
                    dgQuotationAddedItemsRowChange();
                    dgSaleDeleted.Rows.Remove(dgSaleDeleted.Rows[rowindex]);

                }
                else { MessageBox.Show("Please choose an item to add Quotation"); }
            }

            //dgQuotationAddedItems.Sort()
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgNo.Index].Value.ToString());
            }
            dgSaleAddedItems.Sort(dgSaleAddedItems.Columns[0], ListSortDirection.Ascending);
            CalculateSubTotal();
        }

        private void cbDeliverDiscount_CheckedChanged(object sender, EventArgs e)
        {
            decimal subtotal = 0;
            if (cbDeliverDiscount.Checked)
            {
                txtTotalDis.Enabled = false;
                txtTotalDis2.Enabled = false;

                foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
                {
                    if (item.Cells["HS"].Style.BackColor != Color.Red && item.Cells["LI"].Style.BackColor != Color.Ivory)
                    {
                        decimal UCUPCurr = 0;
                        decimal DiscountedUCUPCurr = decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString());
                        decimal disc = 0;
                        if (txtTotalDis.Text != null && txtTotalDis.Text != string.Empty)
                        {
                            disc = Decimal.Parse(txtTotalDis.Text);
                        }
                        UCUPCurr = DiscountedUCUPCurr * ((100 - disc) / 100);
                        decimal UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                        item.Cells[dgDisc.Index].Value = Math.Round((100 - ((UCUPCurr * 100) / UPIME)), 4).ToString();
                        item.Cells[dgUCUPCurr.Index].Value = (Math.Round(UCUPCurr, 4)).ToString();

                        decimal quantity = 0;
                        quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                        item.Cells[dgTotal.Index].Value = UCUPCurr * quantity;
                        subtotal += (UCUPCurr * quantity);
                    }
                    else
                    {
                        decimal quantity = 0;
                        quantity = decimal.Parse(item.Cells[dgQty.Index].Value.ToString());
                        decimal UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                        subtotal = subtotal + (UPIME * quantity);
                    }
                }
                totallbl = subtotal;
                lbltotal.Text = subtotal.ToString();
            }
            else
            {
                txtTotalDis.Enabled = true;
                txtTotalDis2.Enabled = true;

                foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
                {
                    if (item.Cells["HS"].Style.BackColor != Color.Red && item.Cells["LI"].Style.BackColor != Color.Ivory)
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
                            UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                            datagriddisc = 100 - (100 * (total * 100 / (100 - txtdisc)) / UPIME);
                            item.Cells[dgDisc.Index].Value = Math.Round(datagriddisc, 4).ToString();
                            UCUPCurr = (UPIME * (100 - datagriddisc)) / 100;
                            item.Cells[dgUCUPCurr.Index].Value = (Math.Round(UCUPCurr, 4)).ToString();
                            item.Cells[dgTotal.Index].Value = Math.Round((UCUPCurr * quantity), 4);
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

            lblsubtotal.Text = subtotal.ToString();
            lbltotal.Text = totallbl.ToString();
            GetAllMargin();

            txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();

        }

        private void cbFactor_Leave(object sender, EventArgs e)
        {
            #region Faktör Değişimi
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                bool isHZ = false;
                if (dgSaleAddedItems.Rows[i].Cells["HS"].Style.BackColor == Color.Red)
                {
                    isHZ = true;
                }
                else if (dgSaleAddedItems.Rows[i].Cells["LI"].Style.BackColor == Color.Ivory)
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
                    dgSaleAddedItems.Rows.Add();
                }
                DataGridViewCell cell = dgSaleAddedItems.Rows[index].Cells[dgProductCode.Index];
                cell.Value = product.StockCode;
                dgSaleAddedItems.CurrentCell = cell;
                ItemDetailsFiller(product.StockCode);
                DataGridViewCell curCell = dgSaleAddedItems.Rows[cell.RowIndex].Cells[dgQty.Index];
                dgSaleAddedItems.CurrentCell = curCell;
                dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].ReadOnly = false;
                dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Style = dgSaleAddedItems.DefaultCellStyle;
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
            txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
            Disc();
        }

        private void dgQuotationAddedItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgSaleAddedItems.Rows.Count == 0)
            {

                dgSaleAddedItems.Rows.Add();
                dgSaleAddedItems.Rows[0].Cells[dgNo.Index].Value = "1";
            }
            dgQuotationAddedItemsRowChange();
        }

        private void btnCustomizeGrid_Click(object sender, EventArgs e)
        {
            frmQuotationGridCustomize form = new frmQuotationGridCustomize(dgSaleAddedItems);
            form.ShowDialog();


            List<int> quotationVisibleFalseNames = QuotationDatagridCustomize.VisibleFalseNames;
            List<int> quotationVisibleTrueNames = QuotationDatagridCustomize.VisibleTrueNames;
            foreach (DataGridViewColumn item in dgSaleAddedItems.Columns)
            {
                if (item.Name != "dgHZ" && item.Name != "dgCL" && item.Name != "dgCR") item.Visible = true;
            }
            foreach (var item in quotationVisibleFalseNames)
            {
                dgSaleAddedItems.Columns[item].Visible = false;
            }
            //sayac = dgQuotationAddedItems.ColumnCount - QuotationDatagridCustomize.VisibleFalseNames.Count;
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            List<string> QuotationItemList = new List<string>();
            for (int i = 0; i < dgSaleAddedItems.ColumnCount; i++)
            {
                QuotationItemList.Add(dgSaleAddedItems.Columns[i].HeaderText);
            }
            frmQuotationExport form = new frmQuotationExport(QuotationItemList, (txtQuotationNo.Text.Substring(txtQuotationNo.Text.LastIndexOf('/') + 1)).ToString(), dgSaleAddedItems);
            form.ShowDialog();

        }

        private void txtTotalDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalDis2.Focus();
            }
        }

        private void btnExQuotation_Click(object sender, EventArgs e)
        {
            frmEx_Quotation form = new frmEx_Quotation();
            form.ShowDialog();
            if (form.quo != null)
            {
                Quotation q = form.quo;/*IME.Quotations.Where(a => a.QuotationNo == classQuotationAdd.quotationNo).FirstOrDefault();*/
                dgSaleAddedItems.Rows.Clear();
                dgSaleAddedItems.Refresh();

                //int itemCount = -1;
                foreach (QuotationDetail item in q.QuotationDetails)
                {
                    //itemCount++;
                    if (dgSaleAddedItems.RowCount != 1)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgSaleAddedItems.Rows[0].Clone();
                        row.Cells[dgProductCode.Index].Value = item.ItemCode;
                        ItemDetailsFiller(item.ItemCode);
                        row.Cells[dgQty.Index].Value = item.Qty;
                        DgQuantityFiller();

                        if (QuotationUtils.IsWithItems == true)
                        {
                            row.Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                            row.Cells[dgDisc.Index].Value = item.Disc;
                        }
                        dgSaleAddedItems.Rows.Add(row);
                        //GetQuotationQuantity(dgQuotationAddedItems.RowCount-1);
                    }
                    else
                    {
                        //int rowIndex = 0;
                        //if (itemCount > 0)
                        //{
                        //    rowIndex = dgQuotationAddedItems.Rows.Add();
                        //}
                        dgSaleAddedItems.Rows[0].Cells[dgProductCode.Index].Value = item.ItemCode;
                        ItemDetailsFiller(item.ItemCode);
                        dgSaleAddedItems.Rows[0].Cells[dgQty.Index].Value = item.Qty;
                        //GetQuotationQuantity(0);
                        DgQuantityFiller();
                        if (QuotationUtils.IsWithItems == true)
                        {
                            dgSaleAddedItems.Rows[0].Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                            dgSaleAddedItems.Rows[0].Cells[dgDisc.Index].Value = item.Disc;
                        }
                    }
                }
            }
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

            if (e.ColumnIndex == dgQty.Index && dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    if ((dgSaleAddedItems.CurrentRow.Cells[dgLandingCost.Index].Value == null && dgSaleAddedItems.CurrentRow.Cells[dgMargin.Index].Value == null))
                    {
                        MessageBox.Show("Please enter value !");
                    }
                    else
                    {
                        dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value = "";
                        dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgQty.Index];
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
                    dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgQty.Index].Value = "";
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dgSaleAddedItems.CurrentCell.Value.ToString());
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
                            dgSaleAddedItems.CurrentRow.Cells[dgSupplier.Index].Value = ws.Cells[i, 2].Text;
                            dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index].Value = ws.Cells[i, 3].Text;
                            dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value = ws.Cells[i, 6].Text;
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
                    dgSaleAddedItems.Rows.Clear();
                    dgSaleAddedItems.Refresh();
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
                    Quotation q1 = db.Quotations.OrderByDescending(x => x.idYear).ThenByDescending(y => y.idNo).ThenByDescending(z => z.idVersion).FirstOrDefault();
                    NewID = q1.idYear + "/" + (q1.idNo + 1);
                    break;

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

        private void dgQuotationAddedItems_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                e.SortResult = decimal.Parse(e.CellValue1.ToString()).CompareTo(decimal.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }
        }

        private void txtTotalDis2_TextChanged(object sender, EventArgs e)
        {
            txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 4).ToString();
        }

        private void btnInvoiceAdd_Click(object sender, EventArgs e)
        {
            AddresMainPage("Addresses");

            cbInvoiceAdress.DataSource = IME.CustomerAddresses.Where(a => a.CustomerID == CustomerCode.Text && a.isInvoiceAddress == true).ToList();
            cbInvoiceAdress.DisplayMember = "AdressTitle";
            cbInvoiceAdress.ValueMember = "ID";
        }

        private void btnDeliveryAdd_Click(object sender, EventArgs e)
        {
            AddresMainPage("Addresses");

            cbDeliveryAddress.DataSource = IME.CustomerAddresses.Where(a => a.CustomerID == CustomerCode.Text && a.isDeliveryAddress == true).ToList(); ;
            cbDeliveryAddress.DisplayMember = "AdressTitle";
            cbDeliveryAddress.ValueMember = "ID";
        }

        private void btnDeliveryContactAdd_Click(object sender, EventArgs e)
        {
            AddresMainPage("Contact");

            cbWorkers.Items.AddRange(IME.CustomerWorkers.Where(a => a.customerID == CustomerCode.Text).ToArray());
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
        }

        private void AddresMainPage(string menu)
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

                FormCustomerAdd f = new FormCustomerAdd(c, menu);
                f.ShowDialog();

                IME = new IMEEntities();
            }
        }
    }
    enum QuotationIdMod
    {
        New = 0,
        CreateVersion = 1
    }
}