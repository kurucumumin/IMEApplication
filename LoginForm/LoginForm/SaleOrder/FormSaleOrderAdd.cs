using LoginForm.Account.Services;
using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class FormSaleOrderAdd : Form
    {
        string manuelSelection = string.Empty;
        private static string QuoStatusActive = "Active";
        List<int> enabledColumns = new List<int>(new int[] { 0, 7, 14, 21, 28, 35 });
        List<QuotationDetail> items;

        #region Definitions
        GetWorkerService GetWorkerService = new GetWorkerService();
        DataTable TotalCostList = new DataTable();
        DataGridViewRow CurrentRow;
        IMEEntities IME = new IMEEntities();
        decimal price;
        ContextMenu DeletedQuotationMenu = new ContextMenu();
        ExchangeRate curr = new ExchangeRate();
        decimal decsalesQuotationTypeId = 0;
        decimal decSalesQuotationPreffixSuffixId = 0;
        bool isAutomatic = false;
        Decimal CurrValue = 1;
        Decimal CurrValue1 = 1;
        decimal Currfactor = 1;
        decimal CurrentDis;
        decimal LowMarginLimit;
        public static Customer customer;
        bool modifyMod = false;
        ToolTip aciklama = new ToolTip();
        System.Data.DataSet ds = new System.Data.DataSet();
        int a = 1;
        #endregion

        public FormSaleOrderAdd()
        {
            InitializeComponent();

            dtpDate.Value = Convert.ToDateTime(IME.CurrentDate().First());
            dtpDate.Enabled = false;
        }

        public FormSaleOrderAdd(Customer cus, List<QuotationDetail> list, string QuotationNOs)
        {
            InitializeComponent();

            customer = cus;
            items = list;

            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgSaleAddedItems.Columns[dgDelivery.Index];

            deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
            deliveryColumn.DisplayMember = "DeliveryName";
            deliveryColumn.ValueMember = "ID";
            //Son versiyonu açmayı sağlıyor
            //Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(quotation.QuotationNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
            //this.Text = "Edit Quotation";
            //modifyMod = true;

            Management m = Utils.getManagement();
            cbCurrency.DataSource = IME.Currencies.ToList();
            txtQuotationNo.Text = QuotationNOs;
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            cbCurrency.SelectedIndex = 0;
            dtpDate.Value = m.FinancialYear.fromDate.Value;
            dtpDate.MaxDate = IME.CurrentDate().FirstOrDefault().Value.AddHours(5);
            cbPaymentType.DataSource = IME.PaymentMethods.ToList();
            cbPaymentType.DisplayMember = "Payment";
            cbPaymentType.ValueMember = "ID";
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";
            cbWorkers.DataSource = IME.CustomerWorkers.Where(a => a.customerID == customer.ID).ToList();
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
            if (customer.MainContactID != null) cbWorkers.SelectedValue = (int)customer.MainContactID;
            CustomerCode.Enabled = false;
            txtCustomerName.Enabled = false;
            LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
            modifyQuotation();

            //fillCustomer();
            //cbSMethod.SelectedIndex = (int)q1.ShippingMethodID;
            for (int i = 0; i < dgSaleAddedItems.RowCount-1; i++)
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
            for (int i = 0; i < dgSaleAddedItems.RowCount-1; i++)
            {
                QuotataionModifyItemDetailsFiller(dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString(), i);

            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1125).FirstOrDefault() == null)
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
            //Son Satırın Boş gelmemesi 
            //foreach (DataGridViewRow rows in dgSaleAddedItems.Rows)
            //{
            //    foreach (DataGridViewCell cells in rows.Cells)
            //    {
            //        if ((object)cells.Value == null)
            //        {
            //            dgSaleAddedItems.Rows.Remove(rows);
            //            break;
            //        }
            //    }
            //}
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
                        //else if ()//HE için
                        //{

                        //}
                    }
                    //

                    subtotal = Decimal.Parse(lblsubtotal.Text) - hztotal;



                    if (txtTotalDis.Text != "") dis2 = Math.Round(subtotal * Decimal.Parse(txtTotalDis.Text) / 100, 2);


                }
                if (cbDeliverDiscount.Checked) getTotalDiscMargin();
                if (txtTotalMarge.Visible == true)
                {
                    getTotalDiscMargin();
                }
                txtTotalDis2.Text = dis2.ToString();


                lbltotal.Text = Math.Round((Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)), 2).ToString();
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

        public FormSaleOrderAdd(string item_code)
        {
            InitializeComponent();

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
        }

        public FormSaleOrderAdd(Quotation quotation)
        {
            InitializeComponent();
            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgSaleAddedItems.Columns[dgDelivery.Index];
            deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
            deliveryColumn.DisplayMember = "DeliveryName";
            deliveryColumn.ValueMember = "ID";
            //Son versiyonu açmayı sağlıyor
            Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(quotation.QuotationNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
            this.Text = "Edit Quotation";
            modifyMod = true;
            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            cbCurrency.SelectedIndex = 0;
            dtpDate.Value = (DateTime)q1.StartDate;
            dtpDate.MaxDate = DateTime.Today.Date;
            cbPaymentType.DataSource = IME.PaymentMethods.ToList();
            cbPaymentType.DisplayMember = "Payment";
            cbPaymentType.ValueMember = "ID";
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";
            cbWorkers.DataSource = IME.CustomerWorkers.Where(a => a.customerID == q1.CustomerID).ToList();
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
            if (q1.QuotationMainContact != null) cbWorkers.SelectedIndex = (int)q1.QuotationMainContact;
            CustomerCode.Enabled = false;
            txtCustomerName.Enabled = false;

            LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
            modifyQuotation();
            //cbCurrency.SelectedValue=

            //fillCustomer();
            cbSMethod.SelectedIndex = (int)q1.ShippingMethodID;
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
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1125).FirstOrDefault() == null)
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
                //btnCreateRev.Enabled = false;
                //LandingCost.Enabled = false;
                gbShipment.Enabled = false;
                groupBox11.Enabled = false;
                groupBox7.Enabled = false;
                //groupBox3.Enabled = false;
            }
        }

        private void ControlAutorization()
        {
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1020).FirstOrDefault() == null)
            {
                gbCost.Visible = false;

            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1021).FirstOrDefault() == null)
            {
                txtTotalMarge.Visible = false;
                label42.Visible = false;
            }
        }
        private void QuotationForm_Load(object sender, EventArgs e)
        {
            //Son Satırın Boş gelmemesi !
            //dgSaleAddedItems.AllowUserToAddRows = false;

            ControlAutorization();
            txtSalesOrderNo.Text = "SO" + IME.CreteNewSaleOrderNo().FirstOrDefault().ToString();
            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgSaleAddedItems.Columns[dgDelivery.Index];
            if (deliveryColumn.DataSource == null)
            {
                deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
                deliveryColumn.DisplayMember = "DeliveryName";
                deliveryColumn.ValueMember = "ID";

            }

            //DataGridViewComboBoxColumn deliveryColumn1 = (DataGridViewComboBoxColumn)dgSaleDeleted.Columns[dgDelivery1.Index];
            //if (deliveryColumn1.DataSource != null)
            //{
            //    deliveryColumn1.DataSource = IME.QuotationDeliveries.ToList();
            //    deliveryColumn1.DisplayMember = "DeliveryName";
            //    deliveryColumn1.ValueMember = "ID";

            //}

            if (txtCustomerName.Text == null || txtCustomerName.Text == "")
            {
                btnContactAdd.Enabled = false;
            }

            TotalCostList.Columns.Add("dgNo", typeof(int));
            TotalCostList.Columns.Add("cost", typeof(decimal));
            List<string> quotationVisibleFalseNames = QuotationDatagridCustomize.VisibleFalseNames;
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
                //txtQuotationNo.Text = NewQuotationID();
                //dgSaleAddedItems.Rows[0].Cells["dgQty"].Value = "0";
                dgSaleAddedItems.Rows[0].Cells[0].Value = 1.ToString();
                LowMarginLimit = Decimal.Parse(IME.Managements.FirstOrDefault().LowMarginLimit.ToString());
                lblVat.Text = Utils.getManagement().VAT.ToString();
                #region ComboboxFiller.


                dtpDate.Value = Convert.ToDateTime(IME.CurrentDate().First());
                cbPaymentType.DataSource = IME.PaymentMethods.ToList();
                cbPaymentType.DisplayMember = "Payment";
                cbPaymentType.ValueMember = "ID";
                cbRep.DataSource = IME.Workers.ToList();
                cbRep.ValueMember = "WorkerID";
                cbRep.DisplayMember = "NameLastName";
                cbRep.SelectedValue = Utils.getCurrentUser().WorkerID;
                txtFactor.Text = Utils.getManagement().Factor.ToString();
                cbCurrency.DataSource = IME.Currencies.ToList();
                cbCurrency.DisplayMember = "currencyName";
                cbCurrency.ValueMember = "currencyID";
                cbCurrency.SelectedValue = Utils.getManagement().DefaultCurrency;
                #endregion
            }
            GetCurrency(dtpDate.Value);
            GetAutorities();

            cbPaymentTerm.DataSource = IME.PaymentTerms.ToList();
        }

        private void GetAutorities()
        {
            if (GetUserAutorities(1020)) { VisibleCostMarginTrue(); }
            if (GetUserAutorities(1021)) { txtTotalMarge.Visible = true; cbDeliverDiscount.Visible = true; }
        }

        //private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        classQuotationAdd.customersearchID = "";
        //        classQuotationAdd.customersearchname = txtCustomerName.Text;
        //        FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
        //        this.Enabled = false;
        //        form.ShowDialog();
        //        this.Enabled = true;
        //        fillCustomer();
        //        if (classQuotationAdd.customersearchID != "") { cbRep.DataSource = IME.CustomerWorkers.Where(a => a.customerID == IME.Customers.Where(b => b.ID == classQuotationAdd.customersearchID).FirstOrDefault().ID).ToList(); cbRep.DisplayMember = "cw_name"; }
        //    }
        //}

        private void SearchCustomerWithName()
        {
            classQuotationAdd.customersearchID = "";
            classQuotationAdd.customersearchname = txtCustomerName.Text;
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
            this.Enabled = false;
            form.ShowDialog();
            fillCustomer();
            if (classQuotationAdd.customersearchID != "") { cbRep.DataSource = IME.CustomerWorkers.Where(a => a.customerID == IME.Customers.Where(b => b.ID == classQuotationAdd.customersearchID).FirstOrDefault().ID).ToList(); cbRep.DisplayMember = "cw_name"; }
        }

        private void fillCustomer()
        {
            if (!modifyMod)
            {
                CustomerCode.Text = classQuotationAdd.customerID;
                txtCustomerName.Text = classQuotationAdd.customername;
            }
            var c = customer;
            if (c != null)
            {
                CustomerCode.Text = c.ID;
                txtCustomerName.Text = c.c_name;

                List<CustomerAddress> addressList = customer.CustomerAddresses.ToList();
                if (addressList.Count != 0)
                {
                    cbInvoiceAdress.DataSource = addressList.ToList();
                    cbDeliveryAddress.DataSource = addressList.ToList();

                    CustomerAddress inv = new CustomerAddress();
                    CustomerAddress delv = new CustomerAddress();

                    try
                    {
                        inv = addressList.Where(x => x.AddressType.ToUpper().Contains("invoice".ToUpper())).FirstOrDefault();
                    }
                    catch (Exception) { }

                    try
                    {
                        delv = addressList.Where(x => x.isDeliveryAddress == true).FirstOrDefault();
                    }
                    catch (Exception) { }


                    if (inv != null)
                    {
                        cbInvoiceAdress.SelectedValue = inv.ID;
                    }
                    if (delv != null)
                    {
                        cbDeliveryAddress.SelectedValue = delv.ID;
                    }
                    else
                    {
                        if (inv != null)
                        {
                            cbDeliveryAddress.SelectedValue = inv.ID;
                        }
                    }
                }

                List<CustomerWorker> customerWorkerList = customer.CustomerWorkers.ToList();

                if (customerWorkerList != null)
                {
                    cbWorkers.DataSource = customerWorkerList.ToList();
                    cbWorkers.DisplayMember = "cw_name";
                    cbWorkers.ValueMember = "ID";
                    if (customer.MainContactID != null) cbWorkers.SelectedValue = (int)customer.MainContactID;
                    cbDeliveryContact.DataSource = customerWorkerList.ToList();
                    CustomerWorker cw = new CustomerWorker();
                    try
                    {
                        cw = customerWorkerList.Where(x => x.ID == (int)cbWorkers.SelectedValue).FirstOrDefault();
                    }
                    catch (Exception) { }

                    if (cw != null) { cbDeliveryContact.SelectedValue = cw.ID; }

                }

                var CustomerCurr = IME.Currencies.Where(a => a.currencyName == c.CurrNameQuo).FirstOrDefault();
                if (CustomerCurr != null) cbCurrency.SelectedValue = CustomerCurr.currencyID;
                //cbCurrType.SelectedIndex = cbCurrType.FindStringExact(c.CurrTypeQuo);
                //if(c.MainContactID!=null) cbWorkers.SelectedIndex = (int)c.MainContactID;
                if (c.paymentmethodID != null)
                {
                    cbPaymentType.SelectedIndex = cbPaymentType.FindStringExact(c.PaymentMethod.Payment);
                }
                try { txtContactNote.Text = c.CustomerWorker.Note.Note_name; } catch { }
                try { txtCustomerNote.Text = c.Note.Note_name; } catch { }
                try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == c.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
                if (c.Worker != null) cbRep.SelectedValue = c.Worker.WorkerID;
                cbCurrency.SelectedItem = cbCurrency.FindStringExact(c.CurrNameQuo);
                if (c.CustomerWorker != null)
                {
                    cbWorkers.SelectedValue = c.CustomerWorker.ID;
                    cbWorkers.SelectedItem = cbWorkers.FindStringExact(c.CustomerWorker.cw_name);
                }
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
            if (MessageBox.Show("Are You Sure To Close This Window?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dgSaleAddedItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            cellEndEdit();
            #region OldFunction
            //           switch (dgSaleAddedItems.CurrentCell.ColumnIndex)
            //           {
            //               case 0:
            //                   #region ID Atama
            //                   if (Int32.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) <= Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells[0].Value.ToString()))
            //                   {
            //                       int currentID = dgSaleAddedItems.CurrentCell.RowIndex;
            //                       List<int> Quotation = new List<int>();
            //                       for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            //                       {
            //                           Quotation.Add(Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()));
            //                       }
            //                       for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            //                       {
            //                           if (dgSaleAddedItems.CurrentCell.RowIndex < Int32.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()))
            //                           {
            //                               #region RowChange1
            //                               //Üstteki bir row u aşşağıya getirmek için
            //                               if (Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()) <= Int32.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgSaleAddedItems.CurrentCell.RowIndex < i)
            //                               {
            //                                   if (i <= Quotation.Count)
            //                                   {
            //                                       dgSaleAddedItems.Rows[i].Cells[0].Value = (i);
            //                                   }
            //                               }
            //                               else { dgSaleAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()); }
            //                               #endregion
            //                           }
            //                           else
            //                           {
            //                               #region RowChange2
            //                               //Üstteki bir row u aşşağıya getirmek için
            //                               if (Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()) >= Int32.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgSaleAddedItems.CurrentCell.RowIndex > i)
            //                               {
            //                                   if (i <= Quotation.Count)
            //                                   {
            //                                       dgSaleAddedItems.Rows[i].Cells[0].Value = (i + 2);
            //                                   }

            //                               }
            //                               else { dgSaleAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()); }
            //                               #endregion
            //                           }

            //                       }
            //                   }
            //                   #endregion
            //                   // if (dataGridView3.CurrentCell.RowIndex != 0) { dataGridView3.CurrentCell.Value = (dataGridView3.CurrentCell.RowIndex + 1).ToString(); }
            //                   dgSaleAddedItems.Sort(dgSaleAddedItems.Columns["dgNo"], ListSortDirection.Ascending);
            //                   break;
            //               case 7://PRODUCT CODE
            //                   {
            //                       #region PRODUCT CODE

            //                       if (dgSaleAddedItems.CurrentCell.Value != null)
            //                       {
            //                           #region Itemcode Format
            //if (dgSaleAddedItems.CurrentCell.Value.ToString().Contains("-")) { dgSaleAddedItems.CurrentCell.Value = dgSaleAddedItems.CurrentCell.Value.ToString().Replace("-", string.Empty).ToString(); }
            //                           if (dgSaleAddedItems.CurrentCell.Value != null && dgSaleAddedItems.CurrentCell.Value.ToString().Length == 6 || (dgSaleAddedItems.CurrentCell.Value.ToString().Contains("P") && dgSaleAddedItems.CurrentCell.Value.ToString().Length == 7)) { dgSaleAddedItems.CurrentCell.Value = 0.ToString() + dgSaleAddedItems.CurrentCell.Value.ToString(); }
            //                           //0100-124 => 0100124
            //                           #endregion
            //                           string itemCode = dgSaleAddedItems.CurrentCell.Value.ToString();
            //                           if (IME.ArticleSearchCheckExistence(dgSaleAddedItems.CurrentCell.Value.ToString()).ToList()[0] >0)
            //                           {
            //                               if (IME.ArticleSearchHasMultipleItems(dgSaleAddedItems.CurrentCell.Value.ToString()).ToList()[0] ==1)
            //                               {
            //                                   if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
            //                                   #region MyRegion

            //                                   //var MPNList = IME.ArticleSearchWithAll(itemCode);
            //                                   //burası yeniden yazılacak
            //                                   //dynamic MPNList;
            //                                   //if (IME.SuperDisks.Where(a => a.Article_No == itemCode).FirstOrDefault() == null)
            //                                   //{
            //                                   //    MPNList = IME.ArticleSearchwithMPN(itemCode);
            //                                   //}
            //                                   //else
            //                                   //{
            //                                   //    var sdP1 = IME.SuperDiskPs.Where(a => a.Article_No == itemCode).FirstOrDefault();
            //                                   //    if (sdP1 == null)
            //                                   //    {
            //                                   //        MPNList = IME.ArticleSearch(itemCode);
            //                                   //    }
            //                                   //    else
            //                                   //    {
            //                                   //        var er1 = IME.ExtendedRanges.Where(a => a.ArticleNo == itemCode).FirstOrDefault();
            //                                   //        if (er1 == null)
            //                                   //        {
            //                                   //            MPNList = IME.ArticleSearch(itemCode);
            //                                   //        }
            //                                   //    }
            //                                   //}
            //                                   #endregion
            //                                   bool isdiscontunied =Discontinued(dgSaleAddedItems.CurrentCell.Value.ToString());
            //                                   if (isdiscontunied==false)
            //                                   {
            //                                       ItemDetailsFiller(dgSaleAddedItems.CurrentCell.Value.ToString());
            //                                       //LandingCost Calculation
            //                                       FillProductCodeItem();
            //                                       dgSaleAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
            //                                       dgSaleAddedItems.CurrentRow.Cells["dgQty"].Style = dgSaleAddedItems.DefaultCellStyle;
            //                                   }
            //                               }
            //                               else
            //                               {

            //                                   this.Enabled = false;
            //                                   FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(dgSaleAddedItems.CurrentCell.Value.ToString());
            //                                   itemsearch.ShowDialog();
            //                                   //Bu item daha önceden eklimi diye kontrol ediyor
            //                                   DataGridViewRow row = dgSaleAddedItems.Rows
            //          .Cast<DataGridViewRow>()
            //          .Where(r => r.Cells["dgProductCode"].Value.ToString().Equals(classQuotationAdd.ItemCode))
            //          .FirstOrDefault();
            //                                       if (row!=null &&row.Cells["dgUCUPCurr"].Value != null)
            //                                       {
            //                                           if (row != null) MessageBox.Show("There is already an item added this qoutation in the " + row.Cells["dgNo"].Value.ToString() + ". Row and the price " + row.Cells["dgUCUPCurr"].Value.ToString());

            //                                       }
            //                                       //else
            //                                       //{
            //                                       //    if (row != null) MessageBox.Show("There is already an item added this qoutation in the " + row.Cells["dgNo"].Value.ToString() + ". Row");

            //                                       //}
            //                                   if(classQuotationAdd.ItemCode!=null)dgSaleAddedItems.CurrentCell.Value = classQuotationAdd.ItemCode;
            //                                   if (IME.ArticleSearchCheckExistence(dgSaleAddedItems.CurrentCell.Value.ToString()).ToList()[0] > 0)
            //                                   {
            //                                       if (classQuotationAdd.HasMultipleItems(dgSaleAddedItems.CurrentCell.Value.ToString()) == 0)
            //                                       {
            //                                           if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
            //                                           Discontinued(dgSaleAddedItems.CurrentCell.Value.ToString());
            //                                           bool isdiscontunied = Discontinued(dgSaleAddedItems.CurrentCell.Value.ToString());
            //                                           if (isdiscontunied == false)
            //                                           {
            //                                               ItemDetailsFiller(dgSaleAddedItems.CurrentCell.Value.ToString());
            //                                               //LandingCost Calculation
            //                                               FillProductCodeItem();
            //                                               dgSaleAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
            //                                               dgSaleAddedItems.CurrentRow.Cells["dgQty"].Style = dgSaleAddedItems.DefaultCellStyle;
            //                                               #region DataGridClear
            //                                               dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value = null;
            //                                               dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgDisc"].Value = null;
            //                                               dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
            //                                               dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUPIME"].Value = null;
            //                                               dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
            //                                               dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value = null;

            //                                               CalculateSubTotal();
            //                                               txtSubstitutedBy.Text = null;
            //                                           }
            //                                           #endregion
            //                                       }

            //                                   }

            //                                   if (dgSaleAddedItems.CurrentCell.ColumnIndex == 7)
            //                                   {
            //                                       int i=8;
            //                                       while(dgSaleAddedItems.CurrentRow.Cells[i].Visible==false)
            //                                       {
            //                                           i++;
            //                                       }
            //                                       dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentRow.Index].Cells[i];
            //                                       dgSaleAddedItems.Select();
            //                                       ChangeCurrnetCellTabKey(dgSaleAddedItems.CurrentCell.ColumnIndex + 1);
            //                                   }

            //                                   this.Enabled = true;
            //                               }

            //                           }
            //                           else { MessageBox.Show("There is no such an item"); }

            //                       }
            //                       else
            //                       {
            //                           ItemDetailsClear();
            //                       }
            //                   }
            //                   #endregion
            //                   if (dgSaleAddedItems.CurrentRow.Cells["dgDesc"].Value != null) ChangeCurrnetCell(dgSaleAddedItems.CurrentCell.ColumnIndex + 1);
            //                   break;
            //               case 14://QAUANTITY
            //                   #region Quantity
            //                   {

            //                       if (LandingCost.Enabled == false) LandingCost.Enabled = true;
            //                       GetQuotationQuantity(dgSaleAddedItems.CurrentCell.RowIndex);

            //                       dgSaleAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
            //                       dgSaleAddedItems.CurrentRow.Cells["dgUCUPCurr"].Style = dgSaleAddedItems.DefaultCellStyle;

            //                       dgSaleAddedItems.CurrentRow.Cells["dgTargetUP"].ReadOnly = false;
            //                       dgSaleAddedItems.CurrentRow.Cells["dgTargetUP"].Style = dgSaleAddedItems.DefaultCellStyle;

            //                       dgSaleAddedItems.CurrentRow.Cells["dgCompetitor"].ReadOnly = false;
            //                       dgSaleAddedItems.CurrentRow.Cells["dgCompetitor"].Style = dgSaleAddedItems.DefaultCellStyle;

            //                       dgSaleAddedItems.CurrentRow.Cells["dgDelivery"].ReadOnly = false;
            //                       dgSaleAddedItems.CurrentRow.Cells["dgDelivery"].Style = dgSaleAddedItems.DefaultCellStyle;

            //                       dgSaleAddedItems.CurrentRow.Cells["dgCustStkCode"].ReadOnly = false;
            //                       dgSaleAddedItems.CurrentRow.Cells["dgCustStkCode"].Style = dgSaleAddedItems.DefaultCellStyle;

            //                       dgSaleAddedItems.CurrentRow.Cells["dgCustDescription"].ReadOnly = false;
            //                       dgSaleAddedItems.CurrentRow.Cells["dgCustDescription"].Style = dgSaleAddedItems.DefaultCellStyle;

            //                   }
            //                   if (dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value != "")
            //                   {
            //                       //LOW MARGIN
            //                       if (dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value != null
            //                           //&& Decimal.Parse(dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value.ToString()) > 0
            //                           ) { GetMarginMark(); }

            //                   }
            //                   Disc();
            //                   break;
            //               #endregion
            //               case 21://Total
            //                   {
            //                       //TO DO depends on authority
            //                       //if (dgSaleAddedItems.CurrentRow.Cells[dgHZ.Index].Style.BackColor == Color.White)
            //                       if (txtHazardousInd.Text == "N")
            //                       {
            //                           #region Total
            //                           decimal total = decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString());
            //                           decimal UcupIME = decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString());
            //                           dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgDisc"].Value = String.Format("{0:0.0000}", ((UcupIME - total) * (decimal)100 / UcupIME));
            //                           GetMargin();
            //                           GetMarginMark();
            //                           #region Calculate Total Margin
            //                           try
            //                           {
            //                               Decimal TotalMarginValue = Decimal.Parse(txtTotalMargin.Text) * (Decimal.Parse(lblsubtotal.Text) - Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString()));
            //                               TotalMarginValue = (TotalMarginValue + (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString()) * Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString()))) / Decimal.Parse(lblsubtotal.Text);
            //                               txtTotalMargin.Text = String.Format("{0:0.0000}", TotalMarginValue).ToString();
            //                           }
            //                           catch
            //                           {
            //                               txtTotalMargin.Text = String.Format("{0:0.0000}", Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString())).ToString();
            //                           }
            //                           #endregion
            //                           CalculateSubTotal();
            //                           #endregion
            //                       }
            //                       else if(txtHazardousInd.Text == "Y")
            //                       {
            //                           dgSaleAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value = dgSaleAddedItems.CurrentRow.Cells[dgUPIME.Index].Value.ToString();
            //                           MessageBox.Show("Hazardous item's price cannot be chanced");
            //                       }
            //                   }
            //                   break;
            //           }
            #endregion
        }

        private void DgQuantityFiller()
        {
            #region Quantity
            {

                //if (LandingCost.Enabled == false) LandingCost.Enabled = true;
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

            }
            if (dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value != "")
            {
                //LOW MARGIN
                if (dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value != null
                    //&& Decimal.Parse(dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value.ToString()) > 0
                    )
                { GetMarginMark(); }

            }
            Disc();
            #endregion
        }
        private void cellEndEdit()
        {
            #region MyRegion
            switch (dgSaleAddedItems.CurrentCell.ColumnIndex)
            {
                case 0:
                    #region ID Atama
                    if (Int32.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) <= Int32.Parse(dgSaleAddedItems.CurrentRow.Cells[0].Value.ToString()))
                    {
                        int currentID = dgSaleAddedItems.CurrentCell.RowIndex;
                        List<int> Quotation = new List<int>();
                        for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                        {
                            Quotation.Add(Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()));
                        }
                        for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                        {
                            if (dgSaleAddedItems.CurrentCell.RowIndex < Int32.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()))
                            {
                                #region RowChange1
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()) <= Int32.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgSaleAddedItems.CurrentCell.RowIndex < i)
                                {
                                    if (i <= Quotation.Count)
                                    {
                                        dgSaleAddedItems.Rows[i].Cells[0].Value = (i);
                                    }
                                }
                                else { dgSaleAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()); }
                                #endregion
                            }
                            else
                            {
                                #region RowChange2
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()) >= Int32.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgSaleAddedItems.CurrentCell.RowIndex > i)
                                {
                                    if (i <= Quotation.Count)
                                    {
                                        dgSaleAddedItems.Rows[i].Cells[0].Value = (i + 2);
                                    }

                                }
                                else { dgSaleAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()); }
                                #endregion
                            }

                        }
                    }
                    #endregion

                    dgSaleAddedItems.Sort(dgSaleAddedItems.Columns["dgNo"], ListSortDirection.Ascending);
                    break;
                case 7://PRODUCT CODE
                    {
                        #region MyRegion
                        ItemDetailsClear();
                        string articleNo = "";

                        articleNo = dgSaleAddedItems.CurrentCell.Value.ToString();
                        if (articleNo.Contains("-"))
                        {
                            articleNo = articleNo.Replace("-", "");
                            dgSaleAddedItems.CurrentCell.Value = articleNo;
                        }
                        var articleList = IME.ArticleSearch(articleNo).ToList();
                        if (articleList.Count == 1)
                        {
                            if (!Discontinued(articleNo))
                            {
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
                            FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(articleNo);
                            itemsearch.ShowDialog();
                            articleNo = classQuotationAdd.ItemCode;
                            dgSaleAddedItems.CurrentCell.Value = articleNo;
                            ItemDetailsFiller(articleNo);//tekrar bakılacak
                            FillProductCodeItem();

                        }
                        else
                        {
                            MessageBox.Show("There is no such an Item");
                        }
                    }
                    if (dgSaleAddedItems.CurrentRow.Cells["dgDesc"].Value != null) ChangeCurrnetCell(dgSaleAddedItems.CurrentCell.ColumnIndex + 1);
                    #endregion
                    break;
                case 14://QAUANTITY
                    DgQuantityFiller();
                    #region Quantity
                    //{

                    //    if (LandingCost.Enabled == false) LandingCost.Enabled = true;
                    //    GetQuotationQuantity(dgSaleAddedItems.CurrentCell.RowIndex);

                    //    dgSaleAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
                    //    dgSaleAddedItems.CurrentRow.Cells["dgUCUPCurr"].Style = dgSaleAddedItems.DefaultCellStyle;

                    //    dgSaleAddedItems.CurrentRow.Cells["dgTargetUP"].ReadOnly = false;
                    //    dgSaleAddedItems.CurrentRow.Cells["dgTargetUP"].Style = dgSaleAddedItems.DefaultCellStyle;

                    //    dgSaleAddedItems.CurrentRow.Cells["dgCompetitor"].ReadOnly = false;
                    //    dgSaleAddedItems.CurrentRow.Cells["dgCompetitor"].Style = dgSaleAddedItems.DefaultCellStyle;

                    //    dgSaleAddedItems.CurrentRow.Cells["dgDelivery"].ReadOnly = false;
                    //    dgSaleAddedItems.CurrentRow.Cells["dgDelivery"].Style = dgSaleAddedItems.DefaultCellStyle;

                    //    dgSaleAddedItems.CurrentRow.Cells["dgCustStkCode"].ReadOnly = false;
                    //    dgSaleAddedItems.CurrentRow.Cells["dgCustStkCode"].Style = dgSaleAddedItems.DefaultCellStyle;

                    //    dgSaleAddedItems.CurrentRow.Cells["dgCustDescription"].ReadOnly = false;
                    //    dgSaleAddedItems.CurrentRow.Cells["dgCustDescription"].Style = dgSaleAddedItems.DefaultCellStyle;

                    //}
                    //if (dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value != "")
                    //{
                    //    //LOW MARGIN
                    //    if (dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value != null
                    //        //&& Decimal.Parse(dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value.ToString()) > 0
                    //        )
                    //    { GetMarginMark(); }

                    //}
                    //Disc();
                    #endregion
                    break;

                case 21://Total
                    {
                        #region Total
                        //TO DO depends on authority
                        //if (dgSaleAddedItems.CurrentRow.Cells[dgHZ.Index].Style.BackColor == Color.White)
                        CurrentRow = dgSaleAddedItems.CurrentRow;
                        if (txtHazardousInd.Text == "N")
                        {
                            #region Total
                            decimal total = decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString());
                            decimal UcupIME = decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString());
                            CurrentRow.Cells["dgDisc"].Value = Math.Round(((UcupIME - total) * (decimal)100 / UcupIME), 2);
                            GetMargin();
                            GetMarginMark();
                            #region Calculate Total Margin
                            try
                            {
                                decimal subtotal = 0;
                                decimal total_1 = 0;
                                subtotal = Decimal.Parse(lblsubtotal.Text);
                                total_1 = Decimal.Parse(dgSaleAddedItems.CurrentRow.Cells["dgTotal"].Value.ToString());
                                CurrentRow = dgSaleAddedItems.CurrentRow;
                                decimal totalmargin = 0; totalmargin = Decimal.Parse(txtTotalMargin.Text);
                                Decimal TotalMarginValue = totalmargin * (subtotal - total_1);
                                TotalMarginValue = (TotalMarginValue + (Decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString()) * Decimal.Parse(CurrentRow.Cells["dgMargin"].Value.ToString()))) / Decimal.Parse(lblsubtotal.Text);
                                txtTotalMargin.Text = Math.Round(TotalMarginValue, 2).ToString();
                            }
                            catch (Exception ex)
                            {
                                txtTotalMargin.Text = Math.Round(Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString()), 2).ToString();
                            }

                            #endregion
                            CalculateSubTotal();

                            #endregion
                        }
                        else if (txtHazardousInd.Text == "Y")
                        {
                            dgSaleAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value = dgSaleAddedItems.CurrentRow.Cells[dgUPIME.Index].Value.ToString();
                            MessageBox.Show("Hazardous item's price cannot be chanced");
                        }
                    }
                    #endregion
                    break;
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
            if (dd != null && Convert.ToDateTime(dd.DiscontinuationDate) < Convert.ToDateTime(IME.CurrentDate().First()).AddDays(90))
            {
                if (Convert.ToDateTime(dd.DiscontinuationDate) > Convert.ToDateTime(IME.CurrentDate().First()))
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
            if (txtFactor.Text != null && txtFactor.Text != "")
            {
                #region Quantity
                if (CurrentRow.Cells["dgQty"].Value != null)
                {
                    if (classQuotationAdd.GetCost(CurrentRow.Cells["dgProductCode"].Value.ToString(), 1) != 0)
                    {
                        #region Quantity
                        #region Calculate Gross Weight
                        //Calculate Gross Weight
                        if (txtStandartWeight.Text != null && txtStandartWeight.Text != "")
                        {
                            if (CurrentRow.Cells[dgUnitWeigt.Index].Value == null)
                                CurrentRow.Cells[dgUnitWeigt.Index].Value = txtStandartWeight.Text;
                            txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();
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
                        CurrentRow.Cells["dgCost"].Value = classQuotationAdd.GetCost(CurrentRow.Cells["dgProductCode"].Value.ToString(), Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString("G29");
                        //LandingCost hesaplatma
                        if (CurrentRow.Cells["dgCost"].Value.ToString() != "-1") { String.Format("{0:0.0000}", Decimal.Parse(CurrentRow.Cells["dgCost"].Value.ToString())).ToString(); }
                        GetLandingCost(rowindex);
                        //  CurrentRow.Cells["dgLandingCost"].Value = String.Format("{0:0.0000}", Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())).ToString();
                        //TODO Math.Round
                        //CurrentRow.Cells["dgLandingCost"].Value = Math.Round(Convert.ToDecimal(CurrentRow.Cells["dgLandingCost"].Value.ToString()), 4);
                        decimal Currrate = 0;
                        if (curr.rate != null) Currrate = Decimal.Parse(curr.rate.ToString());
                        string productCode = CurrentRow.Cells[dgProductCode.Index].Value.ToString();
                        if (productCode.Substring(0, 1) == "0") productCode = productCode.Substring(1, productCode.Length - 1);
                        if (IME.Hazardous.Where(a => a.ArticleNo == productCode).FirstOrDefault() != null)
                        {
                            price = Decimal.Parse((classQuotationAdd.GetPrice(CurrentRow.Cells["dgProductCode"].Value.ToString(), Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())) * (Utils.getManagement().Factor) / Currrate * Decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString("G29"));
                        }
                        else
                        {
                            price = Decimal.Parse((classQuotationAdd.GetPrice(CurrentRow.Cells["dgProductCode"].Value.ToString(), Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString())) * Decimal.Parse(txtFactor.Text) / Currrate * Decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString("G29"));
                        }
                        //price /= factor;
                        #region price calculation
                        if (price > 0)
                        {
                            decimal discResult = 0;
                            //Fiyat burada
                            string articleNo = CurrentRow.Cells["dgProductCode"].Value.ToString();
                            CurrentRow.Cells["dgUPIME"].Value = price / decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString());
                            CurrentRow.Cells["dgTotal"].Value = Math.Round(price, 2);
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

                                    CurrentRow.Cells["dgTotal"].Value = Math.Round(price / (decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())), 2);
                                }

                            }
                            else if ((Int32.Parse(CurrentRow.Cells["dgQty"].Value.ToString()) % Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString())) != 0)
                            {
                                MessageBox.Show("Please enter a number that is a multiple of SSM");
                                CurrentRow.Cells["dgQty"].Value = "";
                                CurrentRow.Cells["dgUPIME"].Value = "";
                                CurrentRow.Cells["dgTotal"].Value = "";
                            }

                            #endregion




                            if (CurrentRow.Cells[dgQty.Index].Value != "")
                            {
                                //TOTAL ve UPIME belirleniyor
                                discResult = decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString());
                                CurrentRow.Cells["dgUPIME"].Value = Math.Round(Decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString()), 4).ToString();
                                CurrentRow.Cells["dgTotal"].Value = Math.Round(decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString()), 2);
                                if (CurrentRow.Cells["dgDisc"].Value != null)
                                {
                                    CurrentRow.Cells["dgDisc"].Value = Math.Round(Decimal.Parse(CurrentRow.Cells["dgDisc"].Value.ToString()), 2).ToString();
                                    discResult = (discResult - (discResult * decimal.Parse(CurrentRow.Cells["dgDisc"].Value.ToString()) / 100));
                                }
                                CurrentRow.Cells["dgUCUPCurr"].Value = String.Format("{0:0.0000}", discResult).ToString();

                                //Change lblsubtotal

                                CalculateSubTotal();

                                //ChangeCurr(rowindex);
                                if (dgSaleAddedItems.CurrentCell == null) dgSaleAddedItems.CurrentCell = CurrentRow.Cells[0];
                                GetMargin();
                                CurrentRow.Cells["dgMargin"].Value = Math.Round(Decimal.Parse(CurrentRow.Cells["dgMargin"].Value.ToString()), 2).ToString();
                                if (CurrentRow.Cells["dgUnitWeigt"].Value != null && CurrentRow.Cells["dgUnitWeigt"].Value != "")
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
                                txtTotalMargin.Text = Math.Round(calculateTotalMargin(), 2).ToString();
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
                        MessageBox.Show("This product does not have cost");
                        dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Value = "0";
                    }
                }
                #endregion
            }

            getTotalDiscMargin();

            calculateTotalCost();
        }


        private void calculateTotalCost()
        {
            try
            {
                if (dgSaleAddedItems.RowCount == 1 && (dgSaleAddedItems.Rows[0].Cells[dgProductCode.Index].Value == null || dgSaleAddedItems.Rows[0].Cells[dgProductCode.Index].Value.ToString() == ""))
                {
                    txtTotalCost.Text = 0.ToString();
                }
                else
                {
                    decimal totalCost = 0;
                    for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                    {
                        decimal LandingCost = 0;
                        decimal Quantity = 0;
                        LandingCost = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString());
                        Quantity = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgQty.Index].Value.ToString());
                        //if (Int32.Parse(dgSaleAddedItems.Rows[i].Cells[dgSSM.Index].Value.ToString())>1)
                        //{
                        //    Quantity = Quantity / Int32.Parse(dgSaleAddedItems.Rows[i].Cells[dgSSM.Index].Value.ToString());
                        //} else
                        if (Int32.Parse(dgSaleAddedItems.Rows[i].Cells[dgUC.Index].Value.ToString()) > 1)
                        {
                            Quantity = Quantity / Int32.Parse(dgSaleAddedItems.Rows[i].Cells[dgUC.Index].Value.ToString());
                        }
                        totalCost += (LandingCost * Quantity);
                    }
                    decimal PoundRate = 0;
                    decimal CurrentRate = 0;
                    PoundRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;
                    CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.currencyId == (decimal)cbCurrency.SelectedValue).OrderByDescending(a => a.date).FirstOrDefault().rate;
                    totalCost = totalCost * PoundRate / (CurrentRate);
                    txtTotalCost.Text = Math.Round(totalCost, 2).ToString();
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
            if (CurrentRow.Cells["dgQty"].Value != null && CurrentRow.Cells["dgQty"].Value.ToString() != "")
            {
                if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1 || Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                {
                    if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1 && (!(CurrentRow.Cells["dgProductCode"].Value.ToString().Contains("P"))))
                    {
                        CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())
                            / Currfactor) / ((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString())
                        * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())
                          )))) * 100).ToString("G29");
                    }
                    else
                    {
                        if (Int32.Parse(CurrentRow.Cells["dgUC"].Value.ToString()) > 1 || Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                        {
                            if (Int32.Parse(CurrentRow.Cells["dgSSM"].Value.ToString()) > 1)
                            {
                                CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())
                                    / Currfactor) / ((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString())
                           * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())
                             )))) * 100).ToString("G29");
                            }
                            else
                            {
                                CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())
                                    / Currfactor) / ((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString())
                            * decimal.Parse(CurrentRow.Cells["dgUC"].Value.ToString())
                              )))) * 100).ToString("G29");
                            }
                        }
                        else
                        {
                            CurrentRow.Cells["dgMargin"].Value = (((1 - (Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())
                                / Currfactor) / ((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
                        }
                    }
                    //dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
                }
                else
                {
                    CurrentRow.Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())
                        / Currfactor) / ((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
                }
            }
            CurrentRow.Cells[dgTotal.Index].Value = (decimal.Parse(CurrentRow.Cells[dgUCUPCurr.Index].Value.ToString()) *
                decimal.Parse(CurrentRow.Cells[dgQty.Index].Value.ToString())).ToString();
            #endregion
        }

        private void GetAllMargin()
        {
            #region Get Margin
            DateTime today = DateTime.Today;
            decimal total = 0;
            decimal totalMargin = 0;


            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                try
                {
                    if (dgSaleAddedItems.Rows[i].Cells["dgQty"].Value != null)
                    {
                        if (Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgUC"].Value.ToString()) > 1 && (!(dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString().Contains("P"))))
                        {
                            dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())
                                / Currfactor) / ((Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()) * decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUC"].Value.ToString()))))) * 100).ToString("G29");
                        }
                        else
                        {
                            decimal margin = 0;
                            decimal UCUPCurr = 0;
                            decimal landingCost = 0;
                            UCUPCurr = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                            landingCost = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString());
                            margin = (1 - (landingCost / UCUPCurr)) * 100;
                            dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = margin;

                            total += Decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                            totalMargin += (margin * total);
                            //dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = ((1 - (landingCost / (UCUPCurr))) * 100).ToString("G29");
                            //dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())
                            //   ) / ((Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");

                        }
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
            CurrentRow.Cells[dgUnitWeigt.Index].Value = txtStandartWeight.Text;
            CurrentRow.Cells[dgTotalWeight.Index].Value = txtGrossWeight.Text;
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
            txtDiscCharge.Text = "";
            txtExpiringPro.Text = "";
            txtUKDiscDate.Text = "";
            txtDiscontinuationDate.Text = "";
            txtSubstitutedBy.Text = "";
            txtRunOn.Text = "";
            txtReferral.Text = "";
            textBox35.Text = "";
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
            SuperDisk sd;
            SuperDiskP sdP;
            ExtendedRange er;

            var ItemTabDetails = IME.ItemDetailTabFiller(ArticleNoSearch).FirstOrDefault();

            if (ItemTabDetails != null)
            {

                CurrentRow.Cells["dgDesc"].Value = ItemTabDetails.Article_Desc;
                CurrentRow.Cells["dgSSM"].Value = ItemTabDetails.Pack_Quantity.ToString() ?? ""; ;
                CurrentRow.Cells["dgUC"].Value = ItemTabDetails.Unit_Content.ToString() ?? ""; ;
                CurrentRow.Cells["dgUOM"].Value = ItemTabDetails.Unit_Measure;
                CurrentRow.Cells["dgMPN"].Value = ItemTabDetails.MPN;
                CurrentRow.Cells["dgCL"].Value = ItemTabDetails.Calibration_Ind;
                if (ItemTabDetails.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(ItemTabDetails.Standard_Weight) / (decimal)1000).ToString("G29") ?? ""; }
                txtHazardousInd.Text = ItemTabDetails.Hazardous_Ind;
                txtCalibrationInd.Text = ItemTabDetails.Calibration_Ind;
                txtCofO.Text = ItemTabDetails.CofO;
                txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
                txtUKDiscDate.Text = ItemTabDetails.Uk_Disc_Date;
                txtDiscCharge.Text = ItemTabDetails.Disc_Change_Ind;
                txtExpiringPro.Text = ItemTabDetails.Expiring_Product_Change_Ind;
                txtManufacturer.Text = ItemTabDetails.Manufacturer.ToString() ?? ""; ;
                txtMHCodeLevel1.Text = ItemTabDetails.MH_Code_Level_1;
                txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
                txtHeight.Text = ((decimal)(ItemTabDetails.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(ItemTabDetails.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(ItemTabDetails.Length * ((Decimal)100))).ToString("G29");
                txtUK1.Text = ItemTabDetails.Col1Price.ToString();
                txtUK2.Text = ItemTabDetails.Col2Price.ToString();
                txtUK3.Text = ItemTabDetails.Col3Price.ToString();
                txtUK4.Text = ItemTabDetails.Col4Price.ToString();
                txtUK5.Text = ItemTabDetails.Col5Price.ToString();
                txtUnitCount1.Text = ItemTabDetails.Col1Break.ToString();
                txtUnitCount2.Text = ItemTabDetails.Col2Break.ToString();
                txtUnitCount3.Text = ItemTabDetails.Col3Break.ToString();
                txtUnitCount4.Text = ItemTabDetails.Col4Break.ToString();
                txtUnitCount5.Text = ItemTabDetails.Col5Break.ToString();
                txtCost1.Text = ItemTabDetails.DiscountedPrice1.ToString();
                txtCost2.Text = ItemTabDetails.DiscountedPrice2.ToString();
                txtCost3.Text = ItemTabDetails.DiscountedPrice3.ToString();
                txtCost4.Text = ItemTabDetails.DiscountedPrice4.ToString();
                txtCost5.Text = ItemTabDetails.DiscountedPrice5.ToString();
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtUnitCount1.Text = ItemTabDetails.Col1Break.ToString();
                txtUnitCount2.Text = ItemTabDetails.Col2Break.ToString();
                txtUnitCount3.Text = ItemTabDetails.Col3Break.ToString();
                txtUnitCount4.Text = ItemTabDetails.Col4Break.ToString();
                txtUnitCount5.Text = ItemTabDetails.Col5Break.ToString();
                txtUK1.Text = ItemTabDetails.Col1Price.ToString();
                txtUK2.Text = ItemTabDetails.Col2Price.ToString();
                txtUK3.Text = ItemTabDetails.Col3Price.ToString();
                txtUK4.Text = ItemTabDetails.Col4Price.ToString();
                txtUK5.Text = ItemTabDetails.Col5Price.ToString();
                txtCost1.Text = ItemTabDetails.DiscountedPrice1.ToString();
                txtCost2.Text = ItemTabDetails.DiscountedPrice2.ToString();
                txtCost3.Text = ItemTabDetails.DiscountedPrice3.ToString();
                txtCost4.Text = ItemTabDetails.DiscountedPrice4.ToString();
                txtCost5.Text = ItemTabDetails.DiscountedPrice5.ToString();
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtSupersectionName.Text = ItemTabDetails.SupersectionName;
                if (ItemTabDetails.Environment != null) { txtEnvironment.Text = "Y"; } else { txtEnvironment.Text = ""; }
                txtLithium.Text = (ItemTabDetails.Lithium != null && ItemTabDetails.Lithium != String.Empty) ? "Y" : "";
                txtShipping.Text = (ItemTabDetails.Shipping != null && ItemTabDetails.Shipping != String.Empty) ? "Y" : "";
                txtRSStock.Text = ItemTabDetails.OnhandStockBalance.ToString();
                txtRSOnOrder.Text = ItemTabDetails.QuantityonOrder.ToString();
                txtDiscontinuationDate.Text = ItemTabDetails.DiscontinuationDate;
                txtRunOn.Text = ItemTabDetails.Runon.ToString();
                txtReferral.Text = ItemTabDetails.Referral.ToString();
                txtLicenceType.Text = ItemTabDetails.LicenceType;

                #region ItemMarginFiller

                int quantity = Int32.Parse(ItemTabDetails.Col1Break.ToString() ?? "0");
                if (quantity != 0)
                {
                    decimal margin1 = 0;
                    margin1 = (classQuotationAdd.GetLandingCost(CurrentRow.Cells["dgProductCode"].Value.ToString(), true, true, true, quantity));

                    txtMargin1.Text = ((1 - ((margin1) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
                    int quantity2 = 0;
                    if (ItemTabDetails != null) { quantity2 = Int32.Parse(ItemTabDetails.Col2Break.ToString()); } else { quantity2 = Int32.Parse(ItemTabDetails.Col2Break.ToString()); }
                    txtMargin2.Text = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true
                                     , quantity2)).ToString("G29");
                    if (txtWeb2.Text == "0")
                    {
                        txtMargin2.Text = "";
                        txtMargin3.Text = "";
                        txtMargin4.Text = "";
                        txtMargin5.Text = "";
                    }
                    else
                    {

                        txtMargin2.Text = ((1 - ((Decimal.Parse(txtMargin2.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
                        try
                        {
                            decimal margin3 = 0;
                            margin3 = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true, Int32.Parse(ItemTabDetails.Col3Break.ToString())));
                            if (margin3 != 0)
                            {
                                txtMargin3.Text = ((1 - ((margin3) / (decimal.Parse(txtWeb3.Text)))) * 100).ToString();
                                if (ItemTabDetails.Col4Break != 0)
                                {
                                    decimal margin4 = 0;
                                    margin4 = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true
                                , Int32.Parse(ItemTabDetails.Col4Break.ToString())));
                                    txtMargin4.Text = ((1 - ((margin4) / (decimal.Parse(txtWeb4.Text)))) * 100).ToString();
                                    if (ItemTabDetails.Col5Break != 0)
                                    {
                                        decimal margin5 = 0;
                                        margin5 = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true
                                    , Int32.Parse(ItemTabDetails.Col5Break.ToString())));
                                        txtMargin5.Text = ((1 - ((margin5) / (decimal.Parse(txtWeb5.Text)))) * 100).ToString();
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
                if (txtLithium.Text != "")
                {
                    label64.BackColor = Color.Red;
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.Ivory;
                }
                else
                {
                    label64.BackColor = Color.White;
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.White;
                }
                if (txtShipping.Text != "")
                {
                    label63.BackColor = Color.Red;
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

                }
                else
                {
                    label63.BackColor = Color.White;
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.White;
                }

                if (txtEnvironment.Text != "")
                {
                    label53.BackColor = Color.Red;
                }
                else
                {
                    label53.BackColor = Color.White;
                }

                if (txtCalibrationInd.Text != "" && txtCalibrationInd.Text != null && txtCalibrationInd.Text != "N")
                {
                    label22.BackColor = Color.Red;
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Green;
                }
                else
                {
                    label22.BackColor = Color.White;
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.White;
                }

                if (txtLicenceType.Text != "" && txtLicenceType.Text != null)
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
                }
                else
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.White;
                }
                #endregion

            }
        (dgSaleAddedItems.CurrentRow.Cells[dgDelivery.Index] as DataGridViewComboBoxCell).Value = 3;
        }

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                CustomerSearchInput();
            }
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            CurrentRow = dgSaleAddedItems.CurrentRow;
            txtGrossWeight.Text = "";
            try
            {
                if (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
                {
                    txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(CurrentRow.Cells["dgQty"].Value.ToString())).ToString();
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

        }

        private void dgSaleAddedItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgSaleAddedItems.RowCount > 1) dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();
        }

        private void dgSaleAddedItems_Click(object sender, EventArgs e)
        {
            CurrentRow = dgSaleAddedItems.CurrentRow;
            ItemClear();
            try { ItemDetailsFiller(CurrentRow.Cells["dgProductCode"].Value.ToString()); } catch { }
        }



        private void GetLandingCost(int Rowindex)
        {
            try
            {
                dgSaleAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[Rowindex].Cells["dgProductCode"].Value.ToString(), true, true, true
                    )).ToString("G29");
                dgSaleAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = String.Format("{0:0.0000}", dgSaleAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value.ToString()).ToString();
            }
            catch { }

        }

        private void getQuotationValues()
        {
            if (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
            {
                for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                {
                    CurrentRow = dgSaleAddedItems.Rows[i];
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
                                CurrentRow.Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(CurrentRow.Cells["dgLandingCost"].Value.ToString())
                                    / Currfactor) / ((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
                            }
                            #endregion
                        }
                        catch { }
                    }
                }
            }
        }

        private void ckItemCost_CheckedChanged(object sender, EventArgs e)
        {
            getQuotationValues();
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
            lblsubtotal.Text = Math.Round(subtotal, 2).ToString();
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
                lblVatTotal.Text = (totalextra * (Decimal.Parse((lblVat.Text)) / 100)).ToString();
                lblGrossTotal.Text = ((Decimal.Parse(lblTotalExtra.Text) + ((Decimal.Parse(lblTotalExtra.Text) * ((Decimal.Parse((lblVat.Text)) / 100)))))).ToString();
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
            try { extrachange = decimal.Parse(txtExtraCharges.Text); } catch { }
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

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DeletedQuotationMenu.Show(dgSaleDeleted, new Point(e.X, e.Y));
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
                        CurrentDis = Decimal.Parse(txtTotalDis2.Text);
                    }
                    else
                    {
                        lbltotal.Text = (Decimal.Parse(lbltotal.Text) + CurrentDis).ToString();
                        CurrentDis = Decimal.Parse(txtTotalDis2.Text);
                    }
                    lbltotal.Text = (Decimal.Parse(lbltotal.Text) - CurrentDis).ToString();
                    if (txtTotalDis.Text != ((CurrentDis * 100) / Decimal.Parse(lblsubtotal.Text)).ToString())
                    {
                        txtTotalDis.Text = (Math.Round((CurrentDis * 100) / Decimal.Parse(lblsubtotal.Text), 2)).ToString();
                        for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                        {
                            if (dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value == null || dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value.ToString() == 0.ToString())
                            {
                                dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value = txtTotalDis.Text;
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
            for (int i = 0; i < dgSaleAddedItems.RowCount - 1; i++)
            {
                if (dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value != null && Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value.ToString()) < Utils.getCurrentUser().MinMarge) { MessageBox.Show("Please Check Margin of Products "); return false; }
                if (Utils.getCurrentUser().MinMarge > decimal.Parse(txtTotalMarge.Text))
                {
                    MessageBox.Show("You are not able to give this Total Margin. Please check the Total Margin");
                    return false;
                }
            }
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                if (((DataGridViewComboBoxCell)dgSaleAddedItems.Rows[i].Cells[dgDelivery.Index]).Value == null)
                {
                    MessageBox.Show("Delivery part cannot be left blank. Please check Delivery Parts of Items");
                    return false;
                }
            }
            return true;
        }

        private void SaleOrderDetailsSave(decimal SaleID)
        {
            IMEEntities IME = new IMEEntities();
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                DataGridViewRow row = dgSaleAddedItems.Rows[i];
                if (row.Cells["dgProductCode"].Value != null)
                {
                    SaleOrderDetail sdi = new SaleOrderDetail();
                    sdi.SaleOrderID = SaleID;
                    if (row.Cells[dgNo.Index].Value != null) sdi.No = Int32.Parse(row.Cells[dgNo.Index].Value.ToString());
                    if (row.Cells[QuoDetailNo.Index].Value != null) sdi.quotationDetailsId = Int32.Parse(row.Cells[QuoDetailNo.Index].Value.ToString());
                    if (row.Cells[dgProductCode.Index].Value != null) sdi.ItemCode = row.Cells[dgProductCode.Index].Value.ToString();
                    if (row.Cells[dgQty.Index].Value != null) sdi.Quantity = Int32.Parse(row.Cells[dgQty.Index].Value.ToString());
                    if (row.Cells[dgUCUPCurr.Index].Value != null) sdi.UCUPCurr = Decimal.Parse(row.Cells[dgUCUPCurr.Index].Value.ToString());
                    if (row.Cells[dgDisc.Index].Value != null) sdi.Discount = Decimal.Parse(row.Cells[dgDisc.Index].Value.ToString());
                    if (row.Cells[dgTotal.Index].Value != null) sdi.Total = Decimal.Parse(row.Cells[dgTotal.Index].Value.ToString());
                    if (row.Cells[dgTargetUP.Index].Value != null) sdi.TargetUP = Decimal.Parse(row.Cells[dgTargetUP.Index].Value.ToString());
                    if (row.Cells[dgCompetitor.Index].Value != null) sdi.Competitor = row.Cells[dgCompetitor.Index].Value.ToString();

                    if (row.Cells[dgDesc.Index].Value != null) sdi.ItemDescription = row.Cells[dgDesc.Index].Value.ToString();
                    if (row.Cells[dgCustDescription.Index].Value != null) sdi.CustomerDescription = row.Cells[dgCustDescription.Index].Value.ToString();
                    if (row.Cells[dgCustStkCode.Index].Value != null) sdi.CustomerStockCode = row.Cells[dgCustStkCode.Index].Value.ToString();
                    sdi.IsDeleted = false;
                    if (row.Cells[dgUPIME.Index].Value != null) sdi.UPIME = Decimal.Parse(row.Cells[dgUPIME.Index].Value.ToString());
                    if (row.Cells[dgMargin.Index].Value != null) sdi.Margin = Decimal.Parse(row.Cells[dgMargin.Index].Value.ToString());
                    if (row.Cells[dgUOM.Index].Value != null) sdi.UnitOfMeasure = row.Cells[dgUOM.Index].Value.ToString();
                    if (row.Cells[dgUC.Index].Value != null) sdi.UnitContent = Int32.Parse(row.Cells[dgUC.Index].Value.ToString());
                    if (row.Cells[dgSSM.Index].Value != null) sdi.SSM = Int32.Parse(row.Cells[dgSSM.Index].Value.ToString());
                    if (row.Cells[dgUnitWeigt.Index].Value != null) sdi.UnitWeight = Decimal.Parse(row.Cells[dgUnitWeigt.Index].Value.ToString());
                    if (row.Cells[dgDependantTable.Index].Value != null) sdi.DependantTable = row.Cells[dgDependantTable.Index].Value.ToString();
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
                        sdi.ItemCost = Convert.ToDecimal(row.Cells[dgCost.Index].Value);
                    }

                    //#region StockApplication
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
                    //#endregion
                    IME.SaleOrderDetails.Add(sdi);
                    IME.SaveChanges();
                }
            }
            for (int i = 0; i < dgSaleDeleted.RowCount; i++)
            {
                DataGridViewRow row = dgSaleDeleted.Rows[i];
                if (row.Cells["dgProductCode1"].Value != null)
                {
                    SaleOrderDetail sdi = new SaleOrderDetail();
                    sdi.SaleOrderID = SaleID;
                    if (row.Cells[No1.Index].Value != null) sdi.No = Int32.Parse(row.Cells[No1.Index].Value.ToString());
                    if (row.Cells[dgProductCode1.Index].Value != null) sdi.ItemCode = row.Cells[dgProductCode1.Index].Value.ToString();
                    if (row.Cells[dgDesc1.Index].Value != null) sdi.ItemDescription = row.Cells[dgDesc1.Index].Value.ToString();
                    if (row.Cells[dgQty1.Index].Value != null) sdi.Quantity = Int32.Parse(row.Cells[dgQty1.Index].Value.ToString());
                    if (row.Cells[dgUCUPCurr1.Index].Value != null) sdi.UCUPCurr = Decimal.Parse(row.Cells[dgUCUPCurr1.Index].Value.ToString());
                    if (row.Cells[dgDisc1.Index].Value != null) sdi.Discount = Decimal.Parse(row.Cells[dgDisc1.Index].Value.ToString());
                    if (row.Cells[dgTotal1.Index].Value != null) sdi.Total = Decimal.Parse(row.Cells[dgTotal1.Index].Value.ToString());
                    if (row.Cells[dgTargetUP1.Index].Value != null) sdi.TargetUP = Decimal.Parse(row.Cells[dgTargetUP1.Index].Value.ToString());
                    if (row.Cells[dgCompetitor1.Index].Value != null) sdi.Competitor = row.Cells[dgCompetitor1.Index].Value.ToString();
                    if (row.Cells[dgCustDescription1.Index].Value != null) sdi.CustomerDescription = row.Cells[dgCustDescription1.Index].Value.ToString();
                    if (row.Cells[dgCustomerStokCode1.Index].Value != null) sdi.CustomerStockCode = row.Cells[dgCustomerStokCode1.Index].Value.ToString();
                    sdi.IsDeleted = true;
                    if (row.Cells[dgUPIME1.Index].Value != null) sdi.UPIME = Decimal.Parse(row.Cells[dgUPIME1.Index].Value.ToString());
                    if (row.Cells[dgMargin1.Index].Value != null) sdi.Margin = Decimal.Parse(row.Cells[dgMargin1.Index].Value.ToString());
                    if (row.Cells[dgUOM1.Index].Value != null) sdi.UnitOfMeasure = row.Cells[dgUOM1.Index].Value.ToString();
                    if (row.Cells[dgUC1.Index].Value != null) sdi.UnitContent = Int32.Parse(row.Cells[dgUC1.Index].Value.ToString());
                    if (row.Cells[dgSSM1.Index].Value != null) sdi.SSM = Int32.Parse(row.Cells[dgSSM1.Index].Value.ToString());
                    if (row.Cells[dgUnitWeight1.Index].Value != null) sdi.UnitWeight = Decimal.Parse(row.Cells[dgUnitWeight1.Index].Value.ToString());
                    if (row.Cells[dgDependantTable1.Index].Value != null) sdi.DependantTable = row.Cells[dgDependantTable1.Index].Value.ToString();


                    if (row.Cells[dgHZ1.Index].Value != null)
                    {
                        sdi.Hazardous = (row.Cells[dgHZ1.Index].Value.ToString() == "Y") ? true : false;
                    }
                    else
                    {
                        sdi.Hazardous = false;
                    }

                    if (row.Cells[dgCL1.Index].Value != null)
                    {
                        sdi.Calibration = (row.Cells[dgCL1.Index].Value.ToString() == "Y") ? true : false; ;
                    }
                    else
                    {
                        sdi.Calibration = false;
                    }
                    if (row.Cells[dgCost1.Index].Value != null) sdi.ItemCost = Convert.ToDecimal(row.Cells[dgCost1.Index].Value);

                    IME.SaleOrderDetails.Add(sdi);
                    IME.SaveChanges();
                }
            }
            MessageBox.Show("Sale is successfully added", "Success");
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateTotalMarge();
                if (!HasNullData())
                {
                    if (ControlSave())
                    {
                        decimal saleOrderNo = SaleSave();
                        SaleOrderDetailsSave(saleOrderNo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error Occured\n" + ex.ToString(), "Error");
            }
            
            
            //try
            //{
            //bool SaveOK = false;

            //SaveOK = ControlSave();
            //if (SaveOK)
            //{
            //    QuotationSave();
            //    QuotationDetailsSave();
            //}

            //}
            //catch { MessageBox.Show("Error Occured", "Failure"); }

        }

        private decimal SaleSave()
        {
            try
            {
                getTotalDiscMargin();
                SaleOrder s = new SaleOrder();
                s.SaleOrderNo = Int32.Parse(txtSalesOrderNo.Text.Substring(2));
                s.SaleDate = Convert.ToDateTime(IME.CurrentDate().First());
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
                s.PaymentMethodID = (int)cbPaymentType.SelectedValue;
                s.NoteForUs = txtNoteForUs.Text;
                //s.NoteForCustomer = txtNoteForCustomer.Text;
                s.NoteForFinance = (chkbForFinance.Checked == true) ? 1 : 0;
                s.SaleOrderNature = cbOrderNature.SelectedItem.ToString();
                s.ShippingType = cbSMethod.SelectedItem.ToString();

                s.LPONO = txtLPONO.Text;
                s.TotalMargin = Convert.ToDecimal(txtTotalMargin.Text);
                s.Factor = Convert.ToDecimal(txtFactor.Text);
                s.SubTotal = Convert.ToDecimal(lblsubtotal.Text);
                s.DiscOnSubtotal = (txtTotalDis.Text != null && txtTotalDis.Text != String.Empty) ? Convert.ToDecimal(txtTotalDis.Text) : 0;
                s.ExtraCharges = (txtExtraCharges.Text != null && txtExtraCharges.Text != String.Empty) ? Convert.ToDecimal(txtExtraCharges.Text) : 0;
                s.financialYearId = (decimal)Utils.getManagement().CurrentFinancialYear;
                s.exchangeRateID = curr.exchangeRateID;

                if (!String.IsNullOrEmpty(txtQuotationNo.Text))
                {
                    string[] quotationNos = txtQuotationNo.Text.Split(',');

                    foreach (string no in quotationNos)
                    {
                        IME.Quotations.Where(x => x.QuotationNo == no).FirstOrDefault().status = "Passive";
                    }
                }
                

                IME.SaleOrders.Add(s);
                IME.SaveChanges();

                return s.SaleOrderID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            //int Note2 = 0;
            //int Note1 = 0;
            //if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
            //{
            //    Note n = new Note();
            //    n.Note_name = txtNoteForUs.Text;
            //    IME.Notes.Add(n);
            //    IME.SaveChanges();
            //    Note1 = n.ID;
            //}
            //if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
            //{
            //    Note n1 = new Note();
            //    n1.Note_name = txtNoteForCustomer.Text;
            //    IME.Notes.Add(n1);
            //    IME.SaveChanges();
            //    Note2 = n1.ID;
            //}
            //if (chkbForFinance.Checked)
            //{
            //    q.ForFinancelIsTrue = 1;
            //}
            //if (Note1 != 0) q.NoteForUsID = Note1;
            //if (Note2 != 0) q.NoteForCustomerID = Note2;
            //IME.Quotations.Add(q);
            //IME.SaveChanges();
        }

        //private void QuotationSave()
        //{
        //    if (modifyMod)
        //    {
        //        #region UpdateQuotation
        //        //Update Quotation

        //        string quoNo = txtQuotationNo.Text;

        //        DataSet.Quotation q = IME.Quotations.Where(a => a.QuotationNo == quoNo).FirstOrDefault();
        //        q.status = QuoStatusActive;
        //        q.RFQNo = txtRFQNo.Text;
        //        try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
        //        try { q.GrossTotal = decimal.Parse(lblGrossTotal.Text); } catch { }
        //        if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
        //        if (true) { q.IsItemCost = 1; } else { q.IsItemCost = 0; }
        //        if (true) { q.IsWeightCost = 1; } else { q.IsWeightCost = 0; }
        //        q.CurrencyID = (decimal)cbCurrency.SelectedValue;
        //        if (true) { q.IsCustomsDuties = 1; } else { q.IsCustomsDuties = 0; }
        //        q.ShippingMethodID = cbSMethod.SelectedIndex;

        //        try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
        //        try { q.ExtraCharges = decimal.Parse(txtExtraCharges.Text); } catch { }
        //        if (chkVat.Checked) { q.IsVatValue = 1; } else { q.IsVatValue = 0; }
        //        try { q.VatValue = Decimal.Parse(lblVat.Text); } catch { }
        //        try { q.StartDate = dtpDate.Value; } catch { }
        //        try { q.Factor = Decimal.Parse(txtFactor.Text); } catch { }
        //        try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
        //        q.PaymentID = (cbPaymentType.SelectedItem as PaymentMethod).ID;
        //        q.CurrName = (cbCurrency.SelectedItem as Currency).currencyName;
        //        //q.CurrType = cbCurrType.Text;
        //        q.Curr = CurrValue;
        //        q.CustomerID = CustomerCode.Text;
        //        q.ShippingMethodID = cbSMethod.SelectedIndex;
        //        q.QuotationMainContact = cbWorkers.SelectedIndex;
        //        int Note2 = 0;
        //        int Note1 = 0;
        //        if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
        //        {
        //            Note n = IME.Notes.Where(a => a.ID == q.NoteForUsID).FirstOrDefault();
        //            n.Note_name = txtNoteForUs.Text;

        //            IME.SaveChanges();

        //        }
        //        if (txtNoteForCustomer.Text != null || txtNoteForCustomer.Text != "")
        //        {
        //            Note n1 = IME.Notes.Where(a => a.ID == q.NoteForCustomerID).FirstOrDefault();
        //            n1.Note_name = txtNoteForCustomer.Text;
        //            IME.SaveChanges();

        //        }
        //        if (chkbForFinance.Checked)
        //        {
        //            q.ForFinancelIsTrue = 1;
        //        }
        //        IME.SaveChanges();
        //        #endregion
        //    }
        //    else
        //    {
        //        //New Quotation
        //        #region  New Quotation
        //        DataSet.Quotation q = new DataSet.Quotation();
        //        q.status = QuoStatusActive;
        //        string qNo = txtQuotationNo.Text;

        //        if (IME.Quotations.Where(a => a.QuotationNo == qNo).FirstOrDefault() != null)
        //        {
        //            NewQuotationID();
        //        }
        //        q.QuotationNo = txtQuotationNo.Text;
        //        q.RFQNo = txtRFQNo.Text;
        //        try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
        //        try { q.GrossTotal = decimal.Parse(lblGrossTotal.Text); } catch { }
        //        if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
        //        if (true) { q.IsItemCost = 1; } else { q.IsItemCost = 0; }
        //        if (true) { q.IsWeightCost = 1; } else { q.IsWeightCost = 0; }
        //        q.CurrencyID = (decimal)cbCurrency.SelectedValue;
        //        if (true) { q.IsCustomsDuties = 1; } else { q.IsCustomsDuties = 0; }
        //        q.ShippingMethodID = cbSMethod.SelectedIndex;

        //        try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
        //        try { q.ExtraCharges = decimal.Parse(txtExtraCharges.Text); } catch { }
        //        if (chkVat.Checked) { q.IsVatValue = 1; } else { q.IsVatValue = 0; }
        //        try { q.VatValue = Decimal.Parse(lblVat.Text); } catch { }
        //        try { q.StartDate = dtpDate.Value; } catch { }
        //        try { q.Factor = Decimal.Parse(txtFactor.Text); } catch { }
        //        try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
        //        q.PaymentID = (cbPaymentType.SelectedItem as PaymentMethod).ID;
        //        q.CurrName = (cbCurrency.SelectedItem as Currency).currencyName;
        //        //q.CurrType = cbCurrType.Text;
        //        q.Curr = CurrValue;
        //        q.CustomerID = CustomerCode.Text;
        //        q.ShippingMethodID = cbSMethod.SelectedIndex;
        //        q.QuotationMainContact = cbWorkers.SelectedIndex;
        //        int Note2 = 0;
        //        int Note1 = 0;
        //        if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
        //        {
        //            Note n = new Note();
        //            n.Note_name = txtNoteForUs.Text;
        //            IME.Notes.Add(n);
        //            IME.SaveChanges();
        //            Note1 = n.ID;
        //        }
        //        if (txtNoteForCustomer.Text != null || txtNoteForCustomer.Text != "")
        //        {
        //            Note n1 = new Note();
        //            n1.Note_name = txtNoteForCustomer.Text;
        //            IME.Notes.Add(n1);
        //            IME.SaveChanges();
        //            Note2 = n1.ID;
        //        }
        //        if (chkbForFinance.Checked)
        //        {
        //            q.ForFinancelIsTrue = 1;
        //        }
        //        if (Note1 != 0) q.NoteForUsID = Note1;
        //        if (Note2 != 0) q.NoteForCustomerID = Note2;
        //        IME.Quotations.Add(q);
        //        IME.SaveChanges();
        //        #endregion
        //    }
        //}

        //private void QuotationSave(string QuoNo)
        //{
        //    IMEEntities IME = new IMEEntities();
        //    Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(QuoNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
        //    if (txtQuotationNo.Text.Contains("v"))
        //    {
        //        int quoID = Int32.Parse(txtQuotationNo.Text.Substring(txtQuotationNo.Text.LastIndexOf('v') + 1));
        //        txtQuotationNo.Text = (txtQuotationNo.Text.Substring(0, txtQuotationNo.Text.IndexOf('v') + 1) + quoID).ToString();
        //    }
        //    else
        //    {
        //        txtQuotationNo.Text = q1.QuotationNo + "v1";
        //    }
        //    Quotation q = new Quotation();
        //    q.status = QuoStatusActive;
        //    q.QuotationNo = txtQuotationNo.Text;
        //    q.RFQNo = txtRFQNo.Text;
        //    try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
        //    if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
        //    if (true) { q.IsItemCost = 1; } else { q.IsItemCost = 0; }
        //    if (true) { q.IsWeightCost = 1; } else { q.IsWeightCost = 0; }
        //    if (true) { q.IsCustomsDuties = 1; } else { q.IsCustomsDuties = 0; }
        //    q.ShippingMethodID = cbSMethod.SelectedIndex;
        //    q.CurrencyID = (decimal)cbCurrency.SelectedValue;
        //    try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
        //    try { q.ExtraCharges = decimal.Parse(txtExtraCharges.Text); } catch { }
        //    if (chkVat.Checked) { q.IsVatValue = 1; } else { q.IsVatValue = 0; }
        //    try { q.VatValue = Decimal.Parse(lblVat.Text); } catch { }
        //    try { q.StartDate = dtpDate.Value; } catch { }
        //    try { q.Factor = Decimal.Parse(txtFactor.Text); } catch { }
        //    try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
        //    try { q.PaymentID = (cbPaymentType.SelectedItem as PaymentMethod).ID; } catch { }
        //    try { q.CurrName = (cbCurrency.SelectedItem as Rate).CurType; } catch { }
        //    q.ShippingMethodID = cbSMethod.SelectedIndex;
        //    //try { q.CurrType = cbCurrType.SelectedText; } catch { }
        //    try { q.Curr = CurrValue; } catch { }
        //    try { q.CustomerID = CustomerCode.Text; } catch { }
        //    try { q.QuotationMainContact = cbWorkers.SelectedIndex; } catch { }
        //    int Note2 = 0;
        //    int Note1 = 0;
        //    if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
        //    {
        //        Note n = new Note();
        //        n.Note_name = txtNoteForUs.Text;
        //        IME.Notes.Add(n);
        //        IME.SaveChanges();
        //        Note1 = n.ID;
        //    }
        //    if (txtNoteForUs.Text != null || txtNoteForUs.Text != "")
        //    {
        //        Note n1 = new Note();
        //        n1.Note_name = txtNoteForCustomer.Text;
        //        IME.Notes.Add(n1);
        //        IME.SaveChanges();
        //        Note2 = n1.ID;
        //    }
        //    if (chkbForFinance.Checked)
        //    {
        //        q.ForFinancelIsTrue = 1;
        //    }
        //    if (Note1 != 0) q.NoteForUsID = Note1;
        //    if (Note2 != 0) q.NoteForCustomerID = Note2;
        //    IME = new IMEEntities();
        //    IME.Quotations.Add(q);
        //    IME.SaveChanges();

        //}

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
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                if (dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                {

                    QuotationDetail qd = new QuotationDetail();
                    qd.QuotationNo = quotationNo;
                    if (dgSaleAddedItems.Rows[i].Cells["dgNo"].Value != null) qd.dgNo = Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgNo"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgDesc"].Value != null) qd.CustomerDescription = dgSaleAddedItems.Rows[i].Cells["dgDesc"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value != null) qd.ItemCode = dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgQty"].Value != null) qd.Qty = Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgUOM"].Value != null) qd.UnitOfMeasure = dgSaleAddedItems.Rows[i].Cells["dgUOM"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value != null) qd.UCUPCurr = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value != null) qd.UPIME = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value != null) qd.Disc = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value != null) qd.Total = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].Value != null) qd.TargetUP = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].Value != null) qd.Competitor = dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].Value != null) qd.CustomerDescription = dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].Value != null) qd.CustomerStockCode = dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgUC"].Value != null) qd.UC = Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgUC"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgSSM"].Value != null) qd.SSM = Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgSSM"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgUnitWeigt"].Value != null) qd.UnitWeight = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUnitWeigt"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value != null) qd.Marge = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgDependantTable"].Value != null) qd.DependantTable = dgSaleAddedItems.Rows[i].Cells["dgDependantTable"].Value.ToString();

                    qd.quotationDeliveryID = (int)((DataGridViewComboBoxCell)dgSaleAddedItems.Rows[i].Cells[dgDelivery.Index]).Value;

                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
                }

            }
            for (int i = 0; i < dgSaleDeleted.RowCount; i++)
            {
                if (dgSaleDeleted.Rows[i].Cells["dgProductCode1"].Value != null)
                {
                    QuotationDetail qd = new QuotationDetail();

                    if (dgSaleDeleted.Rows[i].Cells["No1"].Value != null) qd.dgNo = Int32.Parse(dgSaleDeleted.Rows[i].Cells["No1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgDesc1"].Value != null) qd.CustomerDescription = dgSaleDeleted.Rows[i].Cells["dgDesc1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgProductCode1"].Value != null) qd.ItemCode = dgSaleDeleted.Rows[i].Cells["dgProductCode1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgQty1"].Value != null) qd.Qty = Int32.Parse(dgSaleDeleted.Rows[i].Cells["dgQty1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUCUPCurr1"].Value != null) qd.UCUPCurr = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgUCUPCurr1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUOM1"].Value != null) qd.UnitOfMeasure = dgSaleDeleted.Rows[i].Cells["dgUOM1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgDisc1"].Value != null) qd.Disc = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgDisc1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUPIME1"].Value != null) qd.UCUPCurr = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgUPIME1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgTotal1"].Value != null) qd.Total = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgTotal1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgTargetUP1"].Value != null) qd.TargetUP = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgTargetUP1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgCompetitor1"].Value != null) qd.Competitor = dgSaleDeleted.Rows[i].Cells["dgCompetitor1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgCustDescription1"].Value != null) qd.CustomerDescription = dgSaleDeleted.Rows[i].Cells["dgCustDescription1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value != null) qd.CustomerStockCode = dgSaleDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgSSM1"].Value != null) qd.SSM = Int32.Parse(dgSaleDeleted.Rows[i].Cells["dgSSM1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUC1"].Value != null) qd.UC = Int32.Parse(dgSaleDeleted.Rows[i].Cells["dgUC1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUnitWeigt1"].Value != null) qd.UnitWeight = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgUnitWeigt1"].Value.ToString());
                    qd.IsDeleted = 1;
                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
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
            this.Close();
            FormQuotationMain formQuotationMain = new FormQuotationMain();
            formQuotationMain.ShowDialog();
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
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                if (dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                {

                    QuotationDetail qd = new QuotationDetail();
                    qd.QuotationNo = txtQuotationNo.Text;
                    if (dgSaleAddedItems.Rows[i].Cells["dgNo"].Value != null) qd.dgNo = Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgNo"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgDesc"].Value != null) qd.CustomerDescription = dgSaleAddedItems.Rows[i].Cells["dgDesc"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value != null) qd.ItemCode = dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgQty"].Value != null) qd.Qty = Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgUOM"].Value != null) qd.UnitOfMeasure = dgSaleAddedItems.Rows[i].Cells["dgUOM"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value != null) qd.UCUPCurr = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value != null) qd.UPIME = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value != null) qd.Disc = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value != null) qd.Total = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].Value != null) qd.TargetUP = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTargetUP"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].Value != null) qd.Competitor = dgSaleAddedItems.Rows[i].Cells["dgCompetitor"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].Value != null) qd.CustomerDescription = dgSaleAddedItems.Rows[i].Cells["dgCustDescription"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].Value != null) qd.CustomerStockCode = dgSaleAddedItems.Rows[i].Cells["dgCustStkCode"].Value.ToString();
                    if (dgSaleAddedItems.Rows[i].Cells["dgUC"].Value != null) qd.UC = Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgUC"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgSSM"].Value != null) qd.SSM = Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgSSM"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgUnitWeigt"].Value != "") qd.UnitWeight = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUnitWeigt"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value != null) qd.Marge = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value.ToString());
                    if (dgSaleAddedItems.Rows[i].Cells["dgDependantTable"].Value != null) qd.DependantTable = dgSaleAddedItems.Rows[i].Cells["dgDependantTable"].Value.ToString();

                    qd.quotationDeliveryID = (int)((DataGridViewComboBoxCell)dgSaleAddedItems.Rows[i].Cells[dgDelivery.Index]).Value;

                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
                }

            }
            for (int i = 0; i < dgSaleDeleted.RowCount; i++)
            {
                if (dgSaleDeleted.Rows[i].Cells["dgProductCode1"].Value != null)
                {
                    QuotationDetail qd = new QuotationDetail();

                    if (dgSaleDeleted.Rows[i].Cells["No1"].Value != null) qd.dgNo = Int32.Parse(dgSaleDeleted.Rows[i].Cells["No1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgDesc1"].Value != null) qd.CustomerDescription = dgSaleDeleted.Rows[i].Cells["dgDesc1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgProductCode1"].Value != null) qd.ItemCode = dgSaleDeleted.Rows[i].Cells["dgProductCode1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgQty1"].Value != null) qd.Qty = Int32.Parse(dgSaleDeleted.Rows[i].Cells["dgQty1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUCUPCurr1"].Value != null) qd.UCUPCurr = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgUCUPCurr1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUOM1"].Value != null) qd.UnitOfMeasure = dgSaleDeleted.Rows[i].Cells["dgUOM1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgDisc1"].Value != null) qd.Disc = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgDisc1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUPIME1"].Value != null) qd.UCUPCurr = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgUPIME1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgTotal1"].Value != null) qd.Total = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgTotal1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgTargetUP1"].Value != null) qd.TargetUP = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgTargetUP1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgCompetitor1"].Value != null) qd.Competitor = dgSaleDeleted.Rows[i].Cells["dgCompetitor1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgCustDescription1"].Value != null) qd.CustomerDescription = dgSaleDeleted.Rows[i].Cells["dgCustDescription1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value != null) qd.CustomerStockCode = dgSaleDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value.ToString();
                    if (dgSaleDeleted.Rows[i].Cells["dgSSM1"].Value != null) qd.SSM = Int32.Parse(dgSaleDeleted.Rows[i].Cells["dgSSM1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUC1"].Value != null) qd.UC = Int32.Parse(dgSaleDeleted.Rows[i].Cells["dgUC1"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUnitWeigt1"].Value != null) qd.UnitWeight = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgUnitWeigt1"].Value.ToString());
                    qd.IsDeleted = 1;
                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
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
            this.Close();
            FormQuotationMain formQuotationMain = new FormQuotationMain();
            formQuotationMain.ShowDialog();
        }

        private void modifyQuotation()
        {
            #region QuotationLoader
            //LandingCost.Enabled = true;
            //txtQuotationNo.Text = q.QuotationNo;
            //txtRFQNo.Text = q.RFQNo;
            CustomerCode.Text = customer.ID;
            if (customer.CurrNameQuo != null) cbCurrency.SelectedValue = customer.CurrNameQuo;
            txtFactor.Text = customer.factor.ToString();
            //if (q.NoteForCustomerID != null) txtNoteForCustomer.Text = IME.Notes.Where(a => a.ID == q.NoteForCustomerID).FirstOrDefault().Note_name;
            //if (q.NoteForCustomerID != null) txtNoteForUs.Text = IME.Notes.Where(a => a.ID == q.NoteForUsID).FirstOrDefault().Note_name;
            //if (q.ForFinancelIsTrue == 1) { chkbForFinance.Checked = true; }
            fillCustomer();
            #region QuotationDetails
            //cbCurrType.SelectedItem = q.CurrType;
            cbWorkers.SelectedItem = customer.MainContactID;
            foreach (var item in items)
            {
                if (item.IsDeleted == 1)
                {
                    DataGridViewRow row = (DataGridViewRow)dgSaleDeleted.Rows[0].Clone();
                    row.Cells[0].Value = item.dgNo;
                    row.Cells[7].Value = item.ItemCode;
                    row.Cells[14].Value = item.Qty;
                    row.Cells[17].Value = item.SSM;
                    row.Cells[18].Value = item.UC;
                    row.Cells[19].Value = item.UPIME;
                    row.Cells[21].Value = item.UCUPCurr;
                    row.Cells[20].Value = item.Disc;
                    row.Cells[dgDelivery1.Index].Value = item.quotationDeliveryID;
                    row.Cells[22].Value = item.Total;
                    row.Cells[23].Value = item.TargetUP;
                    row.Cells[24].Value = item.Competitor;
                    row.Cells[29].Value = item.UnitWeight;
                    row.Cells[30].Value = item.UnitWeight * item.Qty;
                    row.Cells[31].Value = item.CustomerStockCode;
                    dgSaleDeleted.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                    row.CreateCells(dgSaleAddedItems);
                    row.Cells[0].Value = Int32.Parse(item.dgNo.ToString());
                    row.Cells[7].Value = item.ItemCode;
                    row.Cells[14].Value = item.Qty;
                    row.Cells[17].Value = item.SSM;
                    row.Cells[18].Value = item.UC;
                    row.Cells[19].Value = item.UPIME;
                    row.Cells[21].Value = item.UCUPCurr;
                    row.Cells[dgDelivery.Index].Value = item.quotationDeliveryID;
                    row.Cells[20].Value = item.Disc;
                    row.Cells[22].Value = item.Total;
                    row.Cells[23].Value = item.TargetUP;
                    row.Cells[24].Value = item.Competitor;
                    row.Cells[29].Value = item.UnitWeight;
                    row.Cells[30].Value = item.UnitWeight * item.Qty;
                    row.Cells[31].Value = item.CustomerStockCode;
                    dgSaleAddedItems.Rows.Add(row);

                }
            }
            //ItemDetailsFiller(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString());
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {

                GetLandingCost(i);
                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[i].Cells[0];
                //GetMargin();
                GetQuotationQuantity(i);

            }
            GetAllMargin();
            #endregion
            //buradaki yazılanların sırası önemli sırayı değiştirmeyin
            //lblsubtotal.Text = q.SubTotal.ToString();
            //txtTotalDis2.Text = q.DiscOnSubTotal2.ToString();
            if (txtTotalDis2.Text == null || txtTotalDis2.Text == "") txtTotalDis2.Text = "0";
            decimal totaldis = Math.Round((Decimal.Parse(txtTotalDis2.Text) * 100) / decimal.Parse(lblsubtotal.Text), 2);
            txtTotalDis.Text = totaldis.ToString();
            lbltotal.Text = (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString();
            //txtExtraCharges.Text = q.ExtraCharges.ToString();
            //lblVat.Text = q.VatValue.ToString();
            //if (q.IsVatValue == 1)
            { chkVat.Checked = true; }
            //else { chkVat.Checked = false; }
            
            //if (q.IsItemCost == 1) { true = true; } else { true = false; }
            //if (q.IsWeightCost == 1) { true = true; } else { true = false; }
            //if (q.IsCustomsDuties == 1) { true = true; } else { true = false; }
            //Buraya Curr verileri gelecek
            #endregion
            try
            {
                if (dgSaleAddedItems.RowCount > 1)
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();
                }
                else { dgSaleAddedItems.Rows[0].Cells[0].Value = 1.ToString(); }
            }
            catch { }
            //string q1 = q.QuotationNo;
            //if (IME.Quotations.Where(a => a.QuotationNo == q1).ToList().Count > 0)
            //{
            //    if (q.QuotationNo.Contains("v"))
            //    {
            //        int quoID = Int32.Parse(q1.Substring(q.QuotationNo.LastIndexOf('v') + 1)) + 1;

            //        q1 = (q.QuotationNo.Substring(0, q.QuotationNo.IndexOf('v') + 1)).ToString();

            //        q1 = q1 + quoID.ToString();
            //    }
            //}
            //txtQuotationNo.Text = q1;
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
                if (ItemTabDetails.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(ItemTabDetails.Standard_Weight) / (decimal)1000).ToString("G29") ?? ""; }
                txtHazardousInd.Text = ItemTabDetails.Hazardous_Ind;
                txtCalibrationInd.Text = ItemTabDetails.Calibration_Ind;
                txtCofO.Text = ItemTabDetails.CofO;
                txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
                txtUKDiscDate.Text = ItemTabDetails.Uk_Disc_Date;
                txtDiscCharge.Text = ItemTabDetails.Disc_Change_Ind;
                txtExpiringPro.Text = ItemTabDetails.Expiring_Product_Change_Ind;
                txtManufacturer.Text = ItemTabDetails.Manufacturer.ToString() ?? ""; ;
                txtMHCodeLevel1.Text = ItemTabDetails.MH_Code_Level_1;
                txtCCCN.Text = ItemTabDetails.CCCN_No.ToString() ?? ""; ;
                txtHeight.Text = ((decimal)(ItemTabDetails.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(ItemTabDetails.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(ItemTabDetails.Length * ((Decimal)100))).ToString("G29");
                txtUK1.Text = ItemTabDetails.Col1Price.ToString();
                txtUK2.Text = ItemTabDetails.Col2Price.ToString();
                txtUK3.Text = ItemTabDetails.Col3Price.ToString();
                txtUK4.Text = ItemTabDetails.Col4Price.ToString();
                txtUK5.Text = ItemTabDetails.Col5Price.ToString();
                txtUnitCount1.Text = ItemTabDetails.Col1Break.ToString();
                txtUnitCount2.Text = ItemTabDetails.Col2Break.ToString();
                txtUnitCount3.Text = ItemTabDetails.Col3Break.ToString();
                txtUnitCount4.Text = ItemTabDetails.Col4Break.ToString();
                txtUnitCount5.Text = ItemTabDetails.Col5Break.ToString();
                txtCost1.Text = ItemTabDetails.DiscountedPrice1.ToString();
                txtCost2.Text = ItemTabDetails.DiscountedPrice2.ToString();
                txtCost3.Text = ItemTabDetails.DiscountedPrice3.ToString();
                txtCost4.Text = ItemTabDetails.DiscountedPrice4.ToString();
                txtCost5.Text = ItemTabDetails.DiscountedPrice5.ToString();
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtUnitCount1.Text = ItemTabDetails.Col1Break.ToString();
                txtUnitCount2.Text = ItemTabDetails.Col2Break.ToString();
                txtUnitCount3.Text = ItemTabDetails.Col3Break.ToString();
                txtUnitCount4.Text = ItemTabDetails.Col4Break.ToString();
                txtUnitCount5.Text = ItemTabDetails.Col5Break.ToString();
                txtUK1.Text = ItemTabDetails.Col1Price.ToString();
                txtUK2.Text = ItemTabDetails.Col2Price.ToString();
                txtUK3.Text = ItemTabDetails.Col3Price.ToString();
                txtUK4.Text = ItemTabDetails.Col4Price.ToString();
                txtUK5.Text = ItemTabDetails.Col5Price.ToString();
                txtCost1.Text = ItemTabDetails.DiscountedPrice1.ToString();
                txtCost2.Text = ItemTabDetails.DiscountedPrice2.ToString();
                txtCost3.Text = ItemTabDetails.DiscountedPrice3.ToString();
                txtCost4.Text = ItemTabDetails.DiscountedPrice4.ToString();
                txtCost5.Text = ItemTabDetails.DiscountedPrice5.ToString();
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
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
                txtRunOn.Text = ItemTabDetails.Runon.ToString();
                txtReferral.Text = ItemTabDetails.Referral.ToString();
                txtLicenceType.Text = ItemTabDetails.LicenceType;
                if (ItemTabDetails.LicenceType != "" && ItemTabDetails.LicenceType != null) isLicenceType = true;
                if (ItemTabDetails.Calibration_Ind != "" && ItemTabDetails.Calibration_Ind != null && ItemTabDetails.Calibration_Ind != "N") isCalibrationInd = true;
                #region ItemMarginFiller

                int quantity = Int32.Parse(ItemTabDetails.Col1Break.ToString() ?? "0");
                if (quantity != 0)
                {
                    decimal margin1 = 0;
                    margin1 = (classQuotationAdd.GetLandingCost(CurrentRow.Cells["dgProductCode"].Value.ToString(), true, true, true
        , quantity));

                    txtMargin1.Text = ((1 - ((margin1) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
                    int quantity2 = 0;
                    quantity2 = Int32.Parse(ItemTabDetails.Col2Break.ToString());
                    decimal margin2 = 0;
                    margin2 = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true
                                     , quantity2));
                    if (margin2 == 0)
                    {
                        txtMargin2.Text = "";
                        txtMargin3.Text = "";
                        txtMargin4.Text = "";
                        txtMargin5.Text = "";
                    }
                    else
                    {

                        txtMargin2.Text = ((1 - ((margin2) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
                        try
                        {
                            decimal margin3 = 0;
                            margin3 = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true, Int32.Parse(ItemTabDetails.Col3Break.ToString())));
                            if (margin3 != 0)
                            {
                                txtMargin3.Text = ((1 - ((margin3) / (decimal.Parse(txtWeb3.Text)))) * 100).ToString();
                                if (ItemTabDetails.Col4Break != 0)
                                {
                                    decimal margin4 = 0;
                                    margin4 = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true
                                , Int32.Parse(ItemTabDetails.Col4Break.ToString())));
                                    txtMargin4.Text = ((1 - ((margin4) / (decimal.Parse(txtWeb4.Text)))) * 100).ToString();
                                    if (ItemTabDetails.Col5Break != 0)
                                    {
                                        decimal margin5 = 0;
                                        margin5 = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true
                                    , Int32.Parse(ItemTabDetails.Col5Break.ToString())));
                                        txtMargin5.Text = ((1 - ((margin5) / (decimal.Parse(txtWeb5.Text)))) * 100).ToString();
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


            //            #region Filler
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
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = sd.Article_Desc;
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgSSM"].Value = sd.Pack_Quantity.ToString();
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgUC"].Value = sd.Unit_Content.ToString();
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sd.Unit_Measure;
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = sd.MPN;
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgCL"].Value = sd.Calibration_Ind;
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
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = sdP.Article_Desc;
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgSSM"].Value = sdP.Pack_Quantity.ToString();
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgUC"].Value = sdP.Unit_Content.ToString();
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
            //                // dgSaleAddedItems.Rows[RowIndex].Cells["dgPackType"].Value = sdP.Calibration_Ind;

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
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = sdP.MPN;
            //                txtMHCodeLevel1.Text = sdP.MH_Code_Level_1;
            //                txtCCCN.Text = sdP.CCCN_No.ToString();
            //                txtHeight.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
            //                txtWidth.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
            //                txtLength.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            //            }
            //            if (er != null)
            //            {
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = er.ArticleDescription;
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = er.UnitofMeasure;
            //                dgSaleAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = er.MPN;
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
            //                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
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
            //                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            //                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
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
            //                txtMargin1.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true
            //, Int32.Parse(sp1.Col1Break.ToString()))).ToString("G29");
            //                txtMargin1.Text = ((1 - ((Decimal.Parse(txtMargin1.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
            //            }
            //            catch { }
            //            try
            //            {
            //                txtMargin2.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true
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
            //                    txtMargin3.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true, Int32.Parse(sp1.Col3Break.ToString()))).ToString("G29");
            //                    txtMargin3.Text = ((1 - ((Decimal.Parse(txtMargin3.Text)) / (decimal.Parse(txtWeb3.Text)))) * 100).ToString();
            //                    if (sp1.Col4Break != 0)
            //                    {
            //                        txtMargin4.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true
            //                    , Int32.Parse(sp1.Col4Break.ToString()))).ToString("G29");
            //                        txtMargin4.Text = ((1 - ((Decimal.Parse(txtMargin4.Text)) / (decimal.Parse(txtWeb4.Text)))) * 100).ToString();
            //                        if (sp1.Col5Break != 0)
            //                        {
            //                            txtMargin5.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true
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

            if (isLithum)
            {
                label64.BackColor = Color.Red;
                CurrentRow.Cells["LI"].Style.BackColor = Color.Ivory;
            }
            else
            {
                label64.BackColor = Color.Transparent;
                CurrentRow.Cells["LI"].Style.BackColor = Color.White;
            }
            if (isShipping)
            {
                label63.BackColor = Color.Red;
                CurrentRow.Cells["HS"].Style.BackColor = Color.Red;
            }
            else
            {
                label63.BackColor = Color.Transparent;
                CurrentRow.Cells["HS"].Style.BackColor = Color.White;
            }
            if (isEnvironment)
            {
                label53.BackColor = Color.Red;
            }
            else
            {
                label53.BackColor = Color.White;
            }
            if (isCalibrationInd)
            {
                label22.BackColor = Color.Red;
                dgSaleAddedItems.Rows[RowIndex].Cells["CL"].Style.BackColor = Color.Green;
            }
            else
            {
                label22.BackColor = Color.Transparent;
                dgSaleAddedItems.Rows[RowIndex].Cells["CL"].Style.BackColor = Color.White;
            }

            if (isLicenceType)
            {
                dgSaleAddedItems.Rows[RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
            }
            else
            {
                dgSaleAddedItems.Rows[RowIndex].Cells["LC"].Style.BackColor = Color.White;
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

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurrency.SelectedIndex != -1 && cbCurrency.DataSource != null)
            {
                GetCurrency(dtpDate.Value);
                ChangeCurr();
                calculateTotalCost();
            }

        }

        private void ChangeCurr(int rowindex)
        {
            if (dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value != null)
            {

                dgSaleAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = ((Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value.ToString())) / Currfactor).ToString();
                dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = ((Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString())) / Currfactor).ToString();
                dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value = Math.Round(((Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())) / Currfactor), 2);
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
                    CurrentRow.Cells["dgTotal"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString())) / Currfactor), 2).ToString();

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

        private void ItemDetailsClear()
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgSaleDeleted.CurrentRow;
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

        private string NewQuotationID()
        {
            IMEEntities IME = new IMEEntities();
            //List<Quotation> quotList = IME.Quotations.Where(q => q.QuotationNo == Convert.ToDateTime(IME.CurrentDate().First()).Year).toList();
            //int ID;
            int year = ((DateTime)(IME.CurrentDate().First())).Year;
            Quotation quo = IME.Quotations.Where(a => a.StartDate.Value.Year == year).OrderByDescending(q => q.QuotationNo).FirstOrDefault();
            string q1;
            if (quo == null)
            {

                q1 = Convert.ToDateTime(IME.CurrentDate().First()).Year.ToString() + "/1";
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

                        q1 = Convert.ToDateTime(IME.CurrentDate().First()).Year.ToString() + "/" + quoID.ToString();
                    }
                }
            }
            return q1;
        }

        //private void btnCreateRev_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //string newID = NewQuotationID();
        //    //if (txtQuotationNo.Text != newID) { txtQuotationNo.Text = newID; }
        //    if (ControlSave())
        //    {
        //        QuotationSave(txtQuotationNo.Text);
        //        QuotationDetailsSaveRevision();
        //    }
        //    //}
        //    //catch
        //    //{
        //    //    MessageBox.Show("Error Occured", "Failure");
        //    //}
        //}

        private void CustomerCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CustomerSearchInput();
        }

        public void CustomerSearchInput()
        {
            classQuotationAdd.customersearchID = CustomerCode.Text;
            classQuotationAdd.customersearchname = "";
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(customer);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                customer = form.customer;
                cbWorkers.DataSource = customer.CustomerWorkers.ToList();
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.ValueMember = "ID";
            }
            this.Enabled = true;
            fillCustomer();
        }

        private void ChangeCurrnetCell(int currindex)
        {
            try
            {
                if (dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value != null)
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells["dgQty"].ReadOnly = false;
                    dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgQty.Index];
                    if (dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgQty.Index].Value != null)
                    {
                        dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgUCUPCurr.Index];
                        dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells["dgUCUPCurr"].ReadOnly = false;
                        a = a + 1;
                        if (a == 3)
                        {
                            if (dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index].Value == null)
                            {
                                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index];
                            }
                            else
                            {
                                DataGridViewRow dgRow = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                                dgSaleAddedItems.Rows.Add(dgRow);
                                dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgProductCode.Index];
                                ItemClear();
                                a = 1;
                                dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells["dgQty"].ReadOnly = true;
                                dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells["dgUCUPCurr"].ReadOnly = true;
                            }
                        }
                        else if (a == 4)
                        {
                            a = 2;
                            dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[dgUCUPCurr.Index];
                        }
                    }
                    else
                    {
                        dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgQty.Index];
                        for (int i = 0; i < (dgSaleAddedItems.RowCount - 1); i++)
                        {
                            dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - i].Cells["dgQty"].ReadOnly = true;
                        }
                    }

                }
                else
                {
                    dgSaleAddedItems.CurrentCell = dgSaleAddedItems.CurrentRow.Cells[dgProductCode.Index];
                    for (int i = 0; i < (dgSaleAddedItems.RowCount - 1); i++)
                    {
                        dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - i].Cells["dgQty"].ReadOnly = true;
                        dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - i].Cells["dgUCUPCurr"].ReadOnly = true;
                    }
                }
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
                        //if (currindex == 14 && dgSaleAddedItems.Rows[row].Cells[14].Value == null) break;
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

        private void dgSaleAddedItems_KeyDown(object sender, KeyEventArgs e)
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
                    int rownumber = Int32.Parse(dgSaleAddedItems.Rows[item.Index].Cells["dgNo"].Value.ToString());
                    dgSaleDeleted.Rows.Add();
                    for (int i = 0; i < dgSaleDeleted.Columns.Count; i++)
                    {
                        dgSaleDeleted.Rows[dgSaleDeleted.Rows.Count - 2].Cells[i].Value = item.Cells[i].Value;
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
                CustomerMain f = new CustomerMain(true, CustomerCode.Text);
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
                CustomerMain f = new CustomerMain(1, CustomerCode.Text);
                f.ShowDialog();

                IME = new IMEEntities();

                cbWorkers.DataSource = IME.CustomerWorkers.Where(a => a.customerID == CustomerCode.Text).ToList();
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
                cbWorkers.DataSource = IME.CustomerWorkers.Where(a => a.customerID == CustomerCode.Text).ToList();
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.ValueMember = "ID";
            }

        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            List<string> QuotationItemList = new List<string>();
            for (int i = 0; i < dgSaleAddedItems.ColumnCount; i++)
            {
                QuotationItemList.Add(dgSaleAddedItems.Columns[i].HeaderText);
            }
            frmQuotationExport form = new frmQuotationExport(QuotationItemList, txtQuotationNo.Text, dgSaleAddedItems);
            form.ShowDialog();

        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            //if (textBox10.Text != null && textBox10.Text != "")
            //{
            //    decimal sonuc = Decimal.Parse(textBox10.Text);
            //    textBox10.Text = sonuc.ToString();
            //}
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            //if (textBox10.Text != null && textBox10.Text != "")
            //{
            //    decimal sonuc = Decimal.Parse(textBox10.Text);
            //    sonuc = Math.Round(sonuc, 4);
            //    textBox10.Text = sonuc.ToString();
            //}
        }

        private void txtTotalMargin_Click(object sender, EventArgs e)
        {
            //if (txtTotalMargin.Text != null && txtTotalMargin.Text != "")
            //{
            //    decimal sonuc = Decimal.Parse(txtTotalMargin.Text);
            //    txtTotalMargin.Text = sonuc.ToString();
            //}
        }

        private void txtTotalMargin_Leave(object sender, EventArgs e)
        {
            //if (txtTotalMargin.Text != null && txtTotalMargin.Text != "")
            //{
            //    decimal sonuc = Decimal.Parse(txtTotalMargin.Text);
            //    sonuc = Math.Round(sonuc, 4);
            //    txtTotalMargin.Text = sonuc.ToString();
            //}
        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            //if (textBox11.Text != null && textBox11.Text != "")
            //{
            //    decimal sonuc = Decimal.Parse(textBox11.Text);
            //    textBox11.Text = sonuc.ToString();
            //}
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            //if (textBox11.Text != null && textBox11.Text != "")
            //{
            //    decimal sonuc = Decimal.Parse(textBox11.Text);
            //    sonuc = Math.Round(sonuc, 4);
            //    textBox11.Text = sonuc.ToString();
            //}
        }

        private void lblsubtotal_Click(object sender, EventArgs e)
        {
            //if (lblsubtotal.Text != null && lblsubtotal.Text != "")
            //{
            //    decimal sonuc = Decimal.Parse(lblsubtotal.Text);
            //    lblsubtotal.Text = sonuc.ToString();
            //}
        }

        private void lblsubtotal_Leave(object sender, EventArgs e)
        {
            //if (lblsubtotal.Text != null && lblsubtotal.Text != "")
            //{
            //    decimal sonuc = Decimal.Parse(lblsubtotal.Text);
            //    sonuc = Math.Round(sonuc, 4);
            //    lblsubtotal.Text = sonuc.ToString();
            //}
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
                        if (dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value != null) subtotal += decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                    }
                }
                //
                decimal totaldis = Math.Round((Decimal.Parse(txtTotalDis2.Text) * 100) / subtotal, 2);
                txtTotalDis.Text = totaldis.ToString();
                lbltotal.Text = (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString();
                getTotalDiscMargin();
                if (txtTotalMarge.Visible == true)
                {
                    getTotalDiscMargin();
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
                    decimal subtotal = Decimal.Parse(lblsubtotal.Text) - hztotal;
                    decimal dis2 = subtotal * Decimal.Parse(txtTotalDis.Text) / 100;
                    txtTotalDis2.Text = Math.Round(dis2, 2).ToString();
                    lbltotal.Text = Math.Round((Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)), 2).ToString();
                }
                if (cbDeliverDiscount.Checked) getTotalDiscMargin();
                if (txtTotalMarge.Visible == true)
                {
                    CalculateTotalMarge();
                    //txtTotalMarge.Text = calculateTotalMargin().ToString();
                    // txtTotalMarge.Text = String.Format("{0:0.0000}", Decimal.Parse(txtTotalMarge.Text)).ToString();
                }

            }
            Disc();

        }
        private void CalculateTotalMarge()
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

                for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                {
                    if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value != null)
                    {
                        //(1-(Cost/U/C U/P))*100
                        decimal cost = 0;
                        decimal DiscountRate = 0;
                        decimal UCUP = 0;
                        decimal totalDiscount = 0;
                        decimal margin = 0;
                        //try { ucupcurr = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString()); } catch { }
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
            if (lblsubtotal.Text != null && lblsubtotal.Text != "") AllMargin = AllMargin / decimal.Parse(lblsubtotal.Text);
            if (AllMargin != 0)
            {
                txtTotalMarge.Text = Math.Round(AllMargin, 2).ToString();
            }
            else
            {
                txtTotalMarge.Text = (0.00).ToString();
            }

        }
        private decimal calculateTotalMargin()

        {
            decimal totalMargin = 0;
            decimal subtotal = 0;

            try { subtotal = decimal.Parse(lblsubtotal.Text); } catch { }
            if (subtotal != 0)
            {
                foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
                {

                    decimal total = 0;
                    decimal margin = 0;
                    try { total = decimal.Parse(item.Cells[dgTotal.Index].Value.ToString()); } catch { }
                    try { margin = decimal.Parse(item.Cells[dgMargin.Index].Value.ToString()); } catch { }
                    totalMargin = totalMargin + (total * margin);
                }
                txtTotalMargin.Text = Math.Round((totalMargin / subtotal), 2).ToString();
                return totalMargin / subtotal;
            }
            return 0;



            #region oldfunc
            //decimal totalMargin = 0;
            //decimal subtotal = 0;
            //decimal Itemtotal = 0;
            //for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            //{
            //    if (dgSaleAddedItems.Rows[i].Cells[dgQty.Index].Value!=null && dgSaleAddedItems.Rows[i].Cells[dgDesc.Index].Value != null)
            //    {
            //        decimal margin = 0;
            //        if (!cbDeliverDiscount.Checked)
            //        {
            //            if (dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value == "")
            //            {
            //                Itemtotal = 0;
            //            }
            //            else
            //            {
            //                Itemtotal = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
            //            }

            //            decimal disc = 0;
            //            if (txtTotalDis.Text != "") disc = decimal.Parse(txtTotalDis.Text);
            //            Itemtotal = Itemtotal * (1 - (disc / 100));
            //            subtotal += Itemtotal;
            //            decimal UCUPCurr = 0;
            //            decimal Cost = 0;
            //            if (dgSaleAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value != null) UCUPCurr = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString());
            //            if (UCUPCurr != 0) UCUPCurr = UCUPCurr * ((1 - (disc / 100)));
            //            if (dgSaleAddedItems.Rows[i].Cells[dgCost.Index].Value != null) Cost = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString());
            //            if (UCUPCurr != 0) margin = (1 - (Cost / UCUPCurr)) * 100;
            //            totalMargin += (margin * Itemtotal);
            //        }
            //        else
            //        {
            //            if (dgSaleAddedItems.Rows[i].Cells[dgMargin.Index].Value != null) margin = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgMargin.Index].Value.ToString());

            //            if (dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value != null) Itemtotal = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
            //            subtotal += Itemtotal;
            //            totalMargin += (margin * Itemtotal);
            //        }

            //    }

            //}
            //if (cbDeliverDiscount.Checked)
            //{

            //    txtTotalMargin.Text = String.Format("{0:0.0000}", totalMargin / subtotal).ToString();
            //}
            //else
            //{
            //    decimal subtotal1 = 0;
            //    decimal totalMargin1 = 0;
            //    for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            //    {
            //        decimal Itemtotal1 = 0;
            //        decimal margin1 = 0;
            //        if (dgSaleAddedItems.Rows[i].Cells[dgMargin.Index].Value != null) margin1 = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgMargin.Index].Value.ToString());

            //        if (dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value != null && dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value != "") Itemtotal1 = decimal.Parse(dgSaleAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
            //        subtotal1 += Itemtotal1;
            //        totalMargin1 += (margin1 * Itemtotal1);
            //    }

            //    if(subtotal1!=0)txtTotalMargin.Text = String.Format("{0:0.0000}", totalMargin1 / subtotal1).ToString();
            //}

            //if (subtotal == 0) return 0;
            //return totalMargin / subtotal;
            #endregion
        }

        private void getTotalDiscMargin()
        {
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                DataGridViewRow row = dgSaleAddedItems.Rows[i];
                if (row.Cells["dgUCUPCurr"].Value != null && row.Cells["dgUCUPCurr"].Value.ToString() != string.Empty && row.Cells["dgLandingCost"].Value != null)
                {
                    decimal cost = Decimal.Parse(row.Cells["dgLandingCost"].Value.ToString());
                    decimal UCUPCur = Decimal.Parse(row.Cells["dgUCUPCurr"].Value.ToString());
                    decimal disc = 0;
                    if (txtTotalDis.Text != string.Empty && txtTotalDis.Text != null) disc = decimal.Parse(txtTotalDis.Text);
                    UCUPCur = UCUPCur * (1 - (disc / 100));
                    //dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = (1 - (cost / UCUPCur)) * 100;
                }
            }
        }

        private void txtExtraCharges_TextChanged(object sender, EventArgs e)
        {
            decimal ExtraCharge = 0;

            try { ExtraCharge = Decimal.Parse(txtExtraCharges.Text); } catch { }
            lblTotalExtra.Text = (ExtraCharge + Decimal.Parse(lbltotal.Text)).ToString();
        }

        private void txtExtraCharges_Leave(object sender, EventArgs e)
        {
            if (txtExtraCharges.Text != null && txtExtraCharges.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtExtraCharges.Text);
                sonuc = Math.Round(sonuc, 4);
                txtExtraCharges.Text = sonuc.ToString();
            }
        }

        private void txtExtraCharges_Click(object sender, EventArgs e)
        {
            if (txtExtraCharges.Text != null && txtExtraCharges.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtExtraCharges.Text);
                txtExtraCharges.Text = sonuc.ToString();
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
            btnProductHistory.Font = new Font(btnProductHistory.Font, btnProductHistory.Font.Style ^ FontStyle.Underline);
            btnProductHistory.Text = "Product History";

            if (dgSaleAddedItems.CurrentRow.Cells["dgProductCode"].Value != null)
                item_code = dgSaleAddedItems.CurrentRow.Cells["dgProductCode"].Value.ToString();
            if (item_code == null)
                MessageBox.Show("Please Enter a Item Code", "Eror !");
            else
            {
                ViewProductHistory f = new ViewProductHistory(item_code);
                try { f.ShowDialog(); } catch { }
            }
            #endregion
        }

        private void dgSaleAddedItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    DataGridViewRow row = dgSaleAddedItems.Rows
.Cast<DataGridViewRow>()
.Where(r => r.Cells["dgProductCode"].Value.ToString().Equals(classQuotationAdd.ItemCode))
.FirstOrDefault();
                    if (row.Cells["dgUCUPCurr"].Value != null)
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
                dgSaleAddedItems.CurrentCell.Value = classQuotationAdd.ItemCode;
                if (dgSaleAddedItems.CurrentCell.Value != null)
                {
                    try { sdNumber = IME.SuperDisks.Where(a => a.Article_No.Contains(dgSaleAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdNumber = 0; }
                    try { sdPNumber = IME.SuperDiskPs.Where(a => a.Article_No.Contains(dgSaleAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdPNumber = 0; }
                    try { erNumber = IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(dgSaleAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { erNumber = 0; }
                    if (sdNumber == 1 || sdPNumber == 1 || erNumber == 1)
                    {
                        if (classQuotationAdd.HasMultipleItems(dgSaleAddedItems.CurrentCell.Value.ToString()) == 0)
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
                if (item.Cells["dgProductCode1"].Value != null)
                {
                    int rowindex = item.Index;
                    int no = Int32.Parse(dgSaleDeleted.Rows[rowindex].Cells["No1"].Value.ToString());

                    int rowindex1 = dgSaleAddedItems.RowCount;

                    dgSaleAddedItems.Rows.Add();
                    int row1 = Int32.Parse(dgSaleAddedItems.Rows[rowindex1].Cells[0].Value.ToString());

                    //for (int i = 0; i < dgSaleAddedItems.Rows.Count; i++)
                    //{
                    //    //if(Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString())== Int32.Parse(dgSaleDeleted.Rows[item.Index].Cells[0].Value.ToString())&& (dgSaleAddedItems.Rows[i].Cells[7].Value=="" || dgSaleAddedItems.Rows[i].Cells[7].Value==null))
                    //    //{
                    //    //    dgSaleAddedItems.Rows.Remove(dgSaleAddedItems.Rows[i]);
                    //    //    rowindex1--;
                    //    //}
                    //}

                    for (int i = 0; i < dgSaleDeleted.Columns.Count; i++)
                    {
                        dgSaleAddedItems.Rows[rowindex1].Cells[i].Value = dgSaleDeleted.Rows[item.Index].Cells[i].Value;
                    }
                    dgSaleAddedItemsRowChange();
                    dgSaleDeleted.Rows.Remove(dgSaleDeleted.Rows[rowindex]);

                }
                else { MessageBox.Show("Please choose an item to add Quotation"); }
            }

            //dgSaleAddedItems.Sort()
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                dgSaleAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString());
            }
            dgSaleAddedItems.Sort(dgSaleAddedItems.Columns[0], ListSortDirection.Ascending);
            CalculateSubTotal();
        }

        private void cbDeliverDiscount_CheckedChanged(object sender, EventArgs e)
        {
            decimal subtotal = 0;
            if (cbDeliverDiscount.Checked)
            {
                foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
                {
                    if (item.Cells["HS"].Style.BackColor != Color.Red && item.Cells["LI"].Style.BackColor != Color.Ivory)
                    {
                        decimal UCUPCurr = 0;
                        decimal DiscountedUCUPCurr = decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString());
                        decimal disc = 0;
                        if (txtTotalDis.Text != null && txtTotalDis.Text != string.Empty) disc = Decimal.Parse(txtTotalDis.Text);
                        UCUPCurr = DiscountedUCUPCurr * ((100 - disc) / 100);
                        decimal UPIME = decimal.Parse(item.Cells[dgUPIME.Index].Value.ToString());
                        item.Cells[dgDisc.Index].Value = (100 - ((UCUPCurr * 100) / UPIME)).ToString();
                        item.Cells[dgUCUPCurr.Index].Value = UCUPCurr.ToString();
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
                lbltotal.Text = subtotal.ToString();
                #region Old Function
                //for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                //{
                //    if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value != null)
                //    {
                //        decimal total = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());

                //        decimal disc = 0;
                //        if (txtTotalDis.Text != null && txtTotalDis.Text != string.Empty) disc = Decimal.Parse(txtTotalDis.Text);
                //        //discValue = total - (total * (1 - (disc / 100)));
                //        //total = total - discValue;
                //        total = (total * (1 - (disc / 100)));
                //        subtotal += total;
                //        dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value = total.ToString();
                //        dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = (total / Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString();
                //        decimal UCIME = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()) * Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString());

                //        dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value = (Math.Round(100 - (100 * total / UCIME), 2)).ToString();
                //    }
                //}
                #endregion
            }
            else
            {
                foreach (DataGridViewRow item in dgSaleAddedItems.Rows)
                {
                    if (item.Cells["HS"].Style.BackColor != Color.Red && item.Cells["LI"].Style.BackColor != Color.Ivory)
                    {
                        if (item.Cells["dgTotal"].Value != null)
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
                            item.Cells[dgDisc.Index].Value = Math.Round(datagriddisc, 2).ToString();
                            UCUPCurr = (UPIME * (100 - datagriddisc)) / 100;
                            item.Cells[dgUCUPCurr.Index].Value = (Math.Round(UCUPCurr, 2)).ToString();
                            item.Cells[dgTotal.Index].Value = Math.Round((UCUPCurr * quantity), 2);
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
            GetAllMargin();

        }

        private void txtFactor_Leave(object sender, EventArgs e)
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
                //        dgSaleAddedItems.Rows.Add();
                //    }
                //    DataGridViewCell cell = dgSaleAddedItems.Rows[index].Cells[dgProductCode.Index];
                //    cell.Value = product.StockCode;
                //    dgSaleAddedItems.CurrentCell = cell;
                //    ItemDetailsFiller(product.StockCode);
                //    DataGridViewCell curCell = dgSaleAddedItems.Rows[cell.RowIndex].Cells[dgQty.Index];
                //    dgSaleAddedItems.CurrentCell = curCell;
                //    //dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].ReadOnly = false;
                //    //dgSaleAddedItems.CurrentRow.Cells[dgQty.Index].Style = dgSaleAddedItems.DefaultCellStyle;
                //    curCell.Value = product.Quantity;
                //    dgSaleAddedItems_CellEndEdit(null, null);
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
                dgSaleAddedItems_CellEndEdit(null, null);
                SendKeys.Send("{TAB}");
                index++;
            }
        }

        private void XmlToCustomer(XmlCustomer xmlCustomer)
        {
            classQuotationAdd.customersearchID = CustomerCode.Text;
            classQuotationAdd.customersearchname = xmlCustomer.Name;
            FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(xmlCustomer);
            this.Enabled = false;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                customer = form.customer;
                cbWorkers.DataSource = customer.CustomerWorkers.ToList();
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.ValueMember = "ID";
            }
            this.Enabled = true;
            fillCustomer();
        }

        private void dgSaleAddedItemsRowChange()
        {
            CalculateSubTotal();
            calculateTotalCost();
            calculateTotalMargin();
            Disc();
        }

        private void dgSaleAddedItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgSaleAddedItems.Rows.Count == 0)
            {

                dgSaleAddedItems.Rows.Add();
                dgSaleAddedItems.Rows[0].Cells[0].Value = "1";
            }
            dgSaleAddedItemsRowChange();
        }

        private void btnCustomizeGrid_Click(object sender, EventArgs e)
        {
            frmQuotationGridCustomize form = new frmQuotationGridCustomize(dgSaleAddedItems);
            form.ShowDialog();
            List<string> quotationVisibleFalseNames = QuotationDatagridCustomize.VisibleFalseNames;
            ;
            foreach (DataGridViewColumn item in dgSaleAddedItems.Columns)
            {
                if (item.Name != "dgHZ" && item.Name != "dgCL" && item.Name != "dgCR") item.Visible = true;
            }
            foreach (var item in quotationVisibleFalseNames)
            {
                dgSaleAddedItems.Columns[item].Visible = false;
            }
        }

        public void CallFromVoucherTypeSelection(decimal decVoucherTypeId, string strVoucherTypeName)
        {
            try
            {
                decsalesQuotationTypeId = decVoucherTypeId;
                VoucherTypeSP SPVoucherType = new VoucherTypeSP();
                isAutomatic = SPVoucherType.CheckMethodOfVoucherNumbering(decsalesQuotationTypeId);
                SuffixPrefixSP SPSuffixPrefix = new SuffixPrefixSP();
                SuffixPrefix InfoSuffixPrefix = new SuffixPrefix();
                InfoSuffixPrefix = SPSuffixPrefix.GetSuffixPrefixDetails(decsalesQuotationTypeId, dtpDate.Value);
                decSalesQuotationPreffixSuffixId = InfoSuffixPrefix.suffixprefixId;
                this.Text = strVoucherTypeName;
                base.Show();
                if (isAutomatic)
                {
                    dtpDate.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQ:14" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTotalDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalDis2.Focus();
            }
        }

        //private void TabOrEnterKeyOnGrid()
        //{
        //    DataGridViewRow row = dgSaleAddedItems.CurrentRow;

        //    if (row.Cells[dgProductCode.Index].Value == null || row.Cells[dgProductCode.Index].Value.ToString() == String.Empty)
        //    {
        //        dgSaleAddedItems.CurrentCell = row.Cells[dgProductCode.Index];
        //        MessageBox.Show("Please Enter Item Code First!", "Warning");
        //    }
        //    else
        //    {
        //        int index = FindNextEditableColumnIndex();
        //        dgSaleAddedItems.CurrentCell = row.Cells[index];
        //    }
        //}

        //private int FindNextEditableColumnIndex()
        //{
        //    int selectedCellIndex = dgSaleAddedItems.CurrentCell.ColumnIndex;
        //    int nextAvailableColumn = 0;
        //    for (int i = 0; i < enabledColumns.Count; i++)
        //    {
        //        if (selectedCellIndex < enabledColumns[i])
        //        {
        //            nextAvailableColumn = enabledColumns[i];
        //            break;
        //        }
        //    }
        //    return nextAvailableColumn;
        //}

        private void btnExQuotation_Click(object sender, EventArgs e)
        {

            frmEx_Quotation form = new frmEx_Quotation();
            form.ShowDialog();
            if (classQuotationAdd.quotationNo != null)
            {
                Quotation q = IME.Quotations.Where(a => a.QuotationNo == classQuotationAdd.quotationNo).FirstOrDefault();
                dgSaleAddedItems.Rows.Clear();
                dgSaleAddedItems.Refresh();
                foreach (QuotationDetail item in IME.QuotationDetails.Where(a => a.QuotationNo == classQuotationAdd.quotationNo))
                {
                    if (dgSaleAddedItems.RowCount != 1)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgSaleAddedItems.Rows[0].Clone();
                        row.Cells[dgProductCode.Index].Value = item.ItemCode;
                        ItemDetailsFiller(item.ItemCode);
                        row.Cells[dgQty.Index].Value = item.Qty;
                        DgQuantityFiller();

                        if (classQuotationAdd.IsWithItems == true)
                        {
                            row.Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                            row.Cells[dgDisc.Index].Value = item.Disc;
                        }
                        dgSaleAddedItems.Rows.Add(row);
                        //GetQuotationQuantity(dgSaleAddedItems.RowCount-1);
                    }
                    else
                    {
                        dgSaleAddedItems.Rows[0].Cells[dgProductCode.Index].Value = item.ItemCode;
                        ItemDetailsFiller(item.ItemCode);
                        dgSaleAddedItems.Rows[0].Cells[dgQty.Index].Value = item.Qty;
                        //GetQuotationQuantity(0);
                        DgQuantityFiller();
                        if (classQuotationAdd.IsWithItems == true)
                        {
                            dgSaleAddedItems.Rows[0].Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                            dgSaleAddedItems.Rows[0].Cells[dgDisc.Index].Value = item.Disc;
                        }
                    }

                }
            }
        }

        private void btnInvoiceAdd_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(2, CustomerCode.Text);
            f.ShowDialog();
            customer = IME.Customers.Where(x => x.ID == CustomerCode.Text).FirstOrDefault();
            fillCustomer();
        }

        private void btnDeliveryContactAdd_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(1, CustomerCode.Text);
            f.ShowDialog();
            customer = IME.Customers.Where(x => x.ID == CustomerCode.Text).FirstOrDefault();
            fillCustomer();
        }

        private void btnDeliveryAdd_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(2, CustomerCode.Text);
            f.ShowDialog();
            customer = IME.Customers.Where(x => x.ID == CustomerCode.Text).FirstOrDefault();
            fillCustomer();
        }

        private bool HasNullData()
        {
            List<string> nullAreaList = new List<string>();

            if (txtSalesOrderNo.Text == null || txtSalesOrderNo.Text == String.Empty)
            {
                nullAreaList.Add("SaleOrderNo is Empty!");
            }
            if (cbPaymentType.SelectedValue == null)
            {
                nullAreaList.Add("Payment Type is Empty!");
            }
            if (cbCurrency.SelectedValue == null)
            {
                nullAreaList.Add("Currency is Empty!");
            }
            if (cbInvoiceAdress.SelectedValue == null)
            {
                nullAreaList.Add("Invoice Address is Empty!");
            }
            if (cbDeliveryAddress.SelectedValue == null)
            {
                nullAreaList.Add("Delivery Address is Empty!");
            }
            if (cbWorkers.SelectedValue == null)
            {
                nullAreaList.Add("Contact is Empty!");
            }
            if (cbDeliveryContact.SelectedValue == null)
            {
                nullAreaList.Add("Delivery Contact is Empty!");
            }
            if (txtFactor.Text == null || txtFactor.Text == String.Empty)
            {
                nullAreaList.Add("Factor is Empty!");
            }
            if (cbSMethod.SelectedItem == null)
            {
                nullAreaList.Add("Shipping Method is Empty!");
            }
            if (cbOrderNature.SelectedItem == null)
            {
                nullAreaList.Add("Order Nature is Empty!");
            }
            if (cbPaymentTerm.SelectedValue == null)
            {
                nullAreaList.Add("Payment Term is Empty!");
            }
            if (txtTotalDis.Text == null || txtTotalDis.Text == String.Empty)
            {
                nullAreaList.Add("Disc On Subtotal is Empty!");
            }
            if (txtExtraCharges.Text == null || txtExtraCharges.Text == String.Empty)
            {
                nullAreaList.Add("Extra Charges is Empty!");
            }
            if (dgSaleAddedItems.RowCount != 0)
            {
                foreach (DataGridViewRow row in dgSaleAddedItems.Rows)
                {
                    if ((row.Cells[dgProductCode.Index].Value != null && row.Cells[dgProductCode.Index].Value.ToString() != String.Empty) && (row.Cells[dgQty.Index].Value == null || row.Cells[dgQty.Index].Value.ToString() == String.Empty))
                    {
                        nullAreaList.Add("Check for Items' Quantities and Margins!");
                    }
                }
            }
            else
            {
                nullAreaList.Add("Items can not be Empty!");
            }

            System.Text.StringBuilder errorString = new System.Text.StringBuilder();
            for (int i = 0; i < nullAreaList.Count; i++)
            {
                errorString.Append(nullAreaList[i]);
                if (i != nullAreaList.Count - 1)
                {
                    errorString.Append("\n");
                }
            }

            string errorMessage = errorString.ToString();

            if (nullAreaList.Count != 0)
            {
                MessageBox.Show(errorMessage, "Null Data");
            }

            return (nullAreaList.Count != 0) ? true : false;
        }

        private void dgSaleAddedItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgQty.Index) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter integer");
                }
                else
                {
                    // the input is numeric 
                }
            }
        }

        private void dgSaleDeleted_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgQty1.Index) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter integer");
                }
                else
                {
                    // the input is numeric 
                }
            }
        }
    }
}
