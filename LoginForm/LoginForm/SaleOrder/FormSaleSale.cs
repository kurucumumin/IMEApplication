using LoginForm.DataSet;
using LoginForm.QuotationModule;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.nmSaleOrder
{
    public partial class FormSaleSale : Form
    {
        #region Definitions
        Customer customer;
        List<QuotationDetail> items;


        GetWorkerService GetWorkerService = new GetWorkerService();

        IMEEntities IME = new IMEEntities();
        decimal price;
        List<Tuple<int, decimal>> SubTotal = new List<Tuple<int, decimal>>();
        List<Tuple<int, decimal>> SubDeletingTotal = new List<Tuple<int, decimal>>();
        ContextMenu DeletedQuotationMenu = new ContextMenu();
        ExchangeRate curr = new ExchangeRate();
        Decimal CurrValue = 1;
        Decimal CurrValue1 = 1;
        decimal Currfactor = 1;
        decimal CurrentDis;
        decimal LowMarginLimit;
        bool modifyMod = false;
        ToolTip aciklama = new ToolTip();
        System.Data.DataSet ds = new System.Data.DataSet();
        decimal round = 0;
        decimal sonuc = 0;
        decimal sayac = 0;
        //ExchangeRate exchangeRate;
        #endregion

        public FormSaleSale(Customer cus)
        {
            InitializeComponent();
            customer = cus;
            dtpDate.Value = DateTime.Now;
            dtpDate.Enabled = false;
            fillCustomer();
        }

        public FormSaleSale(Customer cus, List<QuotationDetail> list)
        {
            customer = cus;
            items = list;
            
            this.Text = "Edit Quotation";
            modifyMod = true;
            InitializeComponent();
            dtpDate.Value = DateTime.Today.Date;
            dtpDate.MaxDate = DateTime.Today.Date;
            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            cbCurrency.SelectedIndex = 0;
            cbPayment.DataSource = IME.PaymentMethods.ToList();
            cbPayment.DisplayMember = "Payment";
            cbPayment.ValueMember = "ID";
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";
            CustomerCode.Enabled = false;
            txtCustomerName.Enabled = false;
            //btnSave.Enabled = false;
            LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
            modifyQuotation(items);
            fillCustomer();
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
            QuotataionModifyItemDetailsFiller(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells["dgProductCode"].Value.ToString(), dgSaleAddedItems.RowCount - 1);
        }

        private void QuotationForm_Load(object sender, EventArgs e)
        {
            DeletedQuotationMenu.MenuItems.Add(new MenuItem("Add to Quotation", DeletedQuotationMenu_Click));
            if (!modifyMod)
            {
                DataGridViewRow dgRow = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                dgSaleAddedItems.Rows.Add(dgRow);
                txtSaleOrderNo.Text = NewQuotationID();
                //dgQuotationAddedItems.Rows[0].Cells["dgQty"].Value = "0";
                dgSaleAddedItems.Rows[0].Cells[0].Value = 1.ToString();
                LowMarginLimit = Decimal.Parse(IME.Managements.FirstOrDefault().LowMarginLimit.ToString());
                lblVat.Text = Utils.getManagement().VAT.ToString();
                #region ComboboxFiller.
                dtpDate.Value = DateTime.Now;
                cbCurrency.DataSource = IME.Currencies.ToList();
                cbCurrency.DisplayMember = "currencyName";
                cbCurrency.ValueMember = "currencyID";
                cbCurrency.SelectedIndex = 0;
                cbPayment.DataSource = IME.PaymentMethods.ToList();
                cbPayment.DisplayMember = "Payment";
                cbPayment.ValueMember = "ID";
                cbRep.DataSource = IME.Workers.ToList();
                cbRep.ValueMember = "WorkerID";
                cbRep.DisplayMember = "NameLastName";
                cbRep.SelectedValue = Utils.getCurrentUser().WorkerID;
                txtFactor.Text = Utils.getManagement().Factor.ToString();
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

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                classQuotationAdd.customersearchID = "";
                classQuotationAdd.customersearchname = txtCustomerName.Text;
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
                this.Enabled = false;
                form.ShowDialog();
                this.Enabled = true;
                fillCustomer();
                if (classQuotationAdd.customersearchID != "") { cbRep.DataSource = IME.CustomerWorkers.Where(a => a.customerID == IME.Customers.Where(b => b.ID == classQuotationAdd.customersearchID).FirstOrDefault().ID).ToList(); cbRep.DisplayMember = "cw_name"; }
            }
        }

        private void fillCustomer()
        {
            CustomerCode.Text = customer.ID;
            txtCustomerName.Text = customer.c_name;
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
                catch (Exception){}

                try
                {
                    delv = addressList.Where(x => x.isDeliveryAdress == 1).FirstOrDefault();
                }
                catch (Exception){}
                

                if (inv != null)
                {
                    cbInvoiceAdress.SelectedValue = inv.ID;
                }
                if (delv != null)
                {
                    cbDeliveryAddress.SelectedValue = delv.ID;
                } else
                {
                    if (inv != null)
                    {
                        cbDeliveryAddress.SelectedValue = inv.ID;
                    }
                }
            }

            List<CustomerWorker> customerWorkerList = customer.CustomerWorkers.ToList();

            if(customerWorkerList != null)
            {
                cbWorkers.DataSource = customerWorkerList.ToList();
                if (customer.MainContactID != null) cbWorkers.SelectedValue = (int)customer.MainContactID;
                cbDeliveryContact.DataSource = customerWorkerList.ToList();
                CustomerWorker cw = new CustomerWorker();
                try
                {
                    cw = customerWorkerList.Where(x => x.ID == (int)cbWorkers.SelectedValue).FirstOrDefault();
                }
                catch (Exception){}

                if (cw != null) { cbDeliveryContact.SelectedValue = cw.ID; }

            }
            
            //cbCurrency.SelectedIndex = cbCurrency.FindStringExact(customer.CurrNameQuo);
            //cbCurrType.SelectedIndex = cbCurrType.FindStringExact(c.CurrTypeQuo);
            //if(c.MainContactID!=null) cbWorkers.SelectedIndex = (int)c.MainContactID;
            if (customer.paymentmethodID != null)
            {
                cbPayment.SelectedIndex = cbPayment.FindStringExact(customer.PaymentMethod.Payment);
            }
            try { txtContactNote.Text = customer.CustomerWorker.Note.Note_name; } catch { }
            try { txtCustomerNote.Text = customer.Note.Note_name; } catch { }
            try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == customer.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
            if (customer.Worker != null) cbRep.SelectedValue = customer.Worker.WorkerID;
            cbCurrency.SelectedItem = cbCurrency.FindStringExact(customer.CurrNameQuo);
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
            FormMain f = new FormMain();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.ShowDialog();
                this.Close();
            }
        }

        private void dgQuotationAddedItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region MyRegion
            switch (dgSaleAddedItems.CurrentCell.ColumnIndex)
            {
                case 0:
                    #region ID Atama
                    if (Int32.Parse(dgSaleAddedItems.CurrentCell.Value.ToString()) <= Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells[0].Value.ToString()))
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
                                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                                        decimal stPrice = 0;
                                        if (st != null) { stPrice = st.Item2; }
                                        SubTotal.Remove(st);
                                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()), stPrice));
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
                                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                                        decimal stPrice = 0;
                                        if (st != null) { stPrice = st.Item2; }
                                        SubTotal.Remove(st);
                                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()), stPrice));
                                    }

                                }
                                else { dgSaleAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()); }
                                #endregion
                            }

                        }
                    }
                    #endregion
                    // if (dataGridView3.CurrentCell.RowIndex != 0) { dataGridView3.CurrentCell.Value = (dataGridView3.CurrentCell.RowIndex + 1).ToString(); }
                    dgSaleAddedItems.Sort(dgSaleAddedItems.Columns["dgNo"], ListSortDirection.Ascending);
                    break;
                case 7://PRODUCT CODE
                    {
                        #region PRODUCT CODE


                        if (dgSaleAddedItems.CurrentCell.Value != null)
                        {
                            //0100-124 => 0100124
                            if (dgSaleAddedItems.CurrentCell.Value.ToString().Contains("-")) { dgSaleAddedItems.CurrentCell.Value = dgSaleAddedItems.CurrentCell.Value.ToString().Replace("-", string.Empty).ToString(); }
                            if (dgSaleAddedItems.CurrentCell.Value != null && dgSaleAddedItems.CurrentCell.Value.ToString().Length == 6 || (dgSaleAddedItems.CurrentCell.Value.ToString().Contains("P") && dgSaleAddedItems.CurrentCell.Value.ToString().Length == 7)) { dgSaleAddedItems.CurrentCell.Value = 0.ToString() + dgSaleAddedItems.CurrentCell.Value.ToString(); }
                            var sd = classQuotationAdd.ItemGetSuperDisk(dgSaleAddedItems.CurrentCell.Value.ToString());
                            var sdp = classQuotationAdd.ItemGetSuperDiskP(dgSaleAddedItems.CurrentCell.Value.ToString());
                            var er = classQuotationAdd.ItemGetExtendedRange(dgSaleAddedItems.CurrentCell.Value.ToString());
                            int sdNumber; int sdPNumber; int erNumber;
                            try { sdNumber = IME.SuperDisks.Where(a => a.Article_No.Contains(dgSaleAddedItems.CurrentCell.Value.ToString())).Count(); } catch { sdNumber = 0; }
                            try { sdPNumber = IME.SuperDiskPs.Where(a => a.Article_No.Contains(dgSaleAddedItems.CurrentCell.Value.ToString())).Count(); } catch { sdPNumber = 0; }
                            try { erNumber = IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(dgSaleAddedItems.CurrentCell.Value.ToString())).Count(); } catch { erNumber = 0; }
                            if (sdNumber != 0 || sdPNumber != 0 || erNumber != 0)
                            {
                                if (classQuotationAdd.HasMultipleItems(dgSaleAddedItems.CurrentCell.Value.ToString()) == 0 && ((dgSaleAddedItems.CurrentCell.Value.ToString().Length == 7 || (dgSaleAddedItems.CurrentCell.Value.ToString().Contains("P") && dgSaleAddedItems.CurrentCell.Value.ToString().Length == 8))))
                                {
                                    if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
                                    #region MyRegion
                                    string itemCode = dgSaleAddedItems.CurrentCell.Value.ToString();

                                    dynamic MPNList;
                                    var sd1 = IME.SuperDisks.Where(a => a.Article_No == itemCode).FirstOrDefault();
                                    if (sd1 == null)
                                    {
                                        MPNList = QuotationHelper.BringItems(itemCode, true);
                                    }
                                    else
                                    {
                                        var sdP1 = IME.SuperDiskPs.Where(a => a.Article_No == itemCode).FirstOrDefault();
                                        if (sdP1 == null)
                                        {
                                            MPNList = QuotationHelper.BringItems(itemCode, true);
                                        }
                                        else
                                        {
                                            var er1 = IME.ExtendedRanges.Where(a => a.ArticleNo == itemCode).FirstOrDefault();
                                            if (er1 == null)
                                            {
                                                MPNList = QuotationHelper.BringItems(itemCode, true);
                                            }
                                        }
                                    }
                                    #endregion
                                    ItemDetailsFiller(dgSaleAddedItems.CurrentCell.Value.ToString());
                                    //LandingCost Calculation
                                    FillProductCodeItem();
                                    dgSaleAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                                    dgSaleAddedItems.CurrentRow.Cells["dgQty"].Style = dgSaleAddedItems.DefaultCellStyle;
                                }
                                else
                                {

                                    this.Enabled = false;
                                    FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(dgSaleAddedItems.CurrentCell.Value.ToString());
                                    itemsearch.ShowDialog();
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
                                    dgSaleAddedItems.CurrentCell.Value = classQuotationAdd.ItemCode;
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
                                    this.Enabled = true;
                                    if (dgSaleAddedItems.CurrentCell.ColumnIndex == 7) dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentRow.Index].Cells[dgSaleAddedItems.CurrentCell.ColumnIndex + 1];
                                    dgSaleAddedItems.Select();
                                    ChangeCurrnetCellTabKey(dgSaleAddedItems.CurrentCell.ColumnIndex + 1);
                                }

                            }
                            else { MessageBox.Show("There is no such an item"); }

                        }
                        else
                        {
                            ItemDetailsClear();
                        }
                    }
                    #endregion
                    if (dgSaleAddedItems.CurrentRow.Cells["dgDesc"].Value != null) ChangeCurrnetCell(dgSaleAddedItems.CurrentCell.ColumnIndex + 1);
                    break;
                case 14://QAUANTITY
                    #region Quantity
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

                    }
                    //LOW MARGIN
                    if (dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value != null && Decimal.Parse(dgSaleAddedItems.CurrentRow.Cells["dgQty"].Value.ToString()) > 0) { GetMarginMark(); }
                    break;
                #endregion
                case 21://Total
                    {
                        #region Total
                        decimal total = decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString());
                        decimal UcupIME = decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString());
                        dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgDisc"].Value = String.Format("{0:0.0000}", ((UcupIME - total) * (decimal)100 / UcupIME));
                        GetMargin();
                        GetMarginMark();
                        #region Calculate Total Margin
                        try
                        {
                            Decimal TotalMarginValue = Decimal.Parse(txtTotalMargin.Text) * (Decimal.Parse(lblsubtotal.Text) - Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString()));
                            TotalMarginValue = (TotalMarginValue + (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString()) * Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString()))) / Decimal.Parse(lblsubtotal.Text);
                            txtTotalMargin.Text = String.Format("{0:0.0000}", TotalMarginValue).ToString();
                        }
                        catch
                        {
                            txtTotalMargin.Text = String.Format("{0:0.0000}", Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString())).ToString();
                        }
                        #endregion
                        CalculateSubTotal();
                        #endregion
                    }
                    break;
            }
            #endregion
        }

        private void GetQuotationQuantity(int rowindex)
        {
            if (txtFactor.Text != null && txtFactor.Text != "")
            {
                #region Quantity
                if (dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value != null)
                {
                    #region Quantity
                    if (txtStandartWeight.Text != null && txtStandartWeight.Text != "")
                    {
                        txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();
                    }
                    //TODO @@@Cost hesaplama
                    dgSaleAddedItems.Rows[rowindex].Cells["dgCost"].Value = classQuotationAdd.GetCost(dgSaleAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString("G29");
                    //TODO @@@LandingCost hesaplatma
                    if (dgSaleAddedItems.Rows[rowindex].Cells["dgCost"].Value.ToString() != "-1") { String.Format("{0:0.0000}", Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgCost"].Value.ToString())).ToString(); }
                    GetLandingCost(rowindex);
                    //  dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value.ToString())).ToString();
                    //TODO Math.Round
                    dgSaleAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value = Math.Round(Convert.ToDecimal(dgSaleAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value.ToString()), 4);
                    decimal Currrate = 0;
                    if (curr.rate != null) Currrate = Decimal.Parse(curr.rate.ToString());
                    price = Decimal.Parse((classQuotationAdd.GetPrice(dgSaleAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())) * Decimal.Parse(txtFactor.Text)/ Currrate * Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString("G29"));
                    //price /= factor;
                    if (price > 0)
                    {
                        decimal discResult = 0;
                        //Fiyat burada
                        string articleNo = dgSaleAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString();


                        dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = price / decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString());
                        dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value = price;
                        //SuperdiskP değilse
                        if (articleNo.ToUpper().IndexOf('P')==-1&& Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()) > 1)
                        {
                            if ((Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString())) != 0)
                            {
                                MessageBox.Show("Please enter a number that is a multiple of Unit Content");
                                dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value = "";
                                dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = "";
                                dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value = "";
                            }
                            else
                            {
                                dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString()) / (decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()));
                                dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value = price / (decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()));
                            }

                        }
                        else if ((Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgSSM"].Value.ToString())) != 0)
                        {
                            MessageBox.Show("Please enter a number that is a multiple of SSM");
                            dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value = "";
                            dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = "";
                            dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value = "";
                        }




                        //if (isP == 1)
                        //{
                        //    if (IME.SuperDiskPs.Where(a => a.Article_No == articleNo).ToList().Count > 0)
                        //    {
                        //        if (IME.SuperDiskPs.Where(a => a.Article_No == articleNo).FirstOrDefault().Pack_Quantity > 1)
                        //        {



                        //        }else
                        //        {
                        //            if (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgSSM"].Value.ToString()) > 1 && Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()) == 1)
                        //            {
                        //                if ((Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgSSM"].Value.ToString())) != 0)
                        //                {
                        //                    MessageBox.Show("Please enter a number that is a multiple of SSM");
                        //                    dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value = "";

                        //                }
                        //                else
                        //                {
                        //                    //price = price / decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString());
                        //                    dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = price / decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString());
                        //                    dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = price;
                        //                }
                        //            }

                        //        }

                        //    }
                        //}
                        //else
                        //{

                        //    if (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()) > 1 && Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgSSM"].Value.ToString()) == 1)
                        //    {
                        //        int resultMod = (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()));
                        //        if ((resultMod != 0) || (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())) < Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()))
                        //        {
                        //            MessageBox.Show("Please enter a number that is a multiple of Unit Content");
                        //            dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value = "";
                        //        }
                        //        else
                        //        {
                        //            dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = price;
                        //            price = price / decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString());
                        //            dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = price / decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString());

                        //        }
                        //    }
                        //}

                        //TOTAL ve UPIME belirleniyor
                        discResult = decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString());
                        dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString())).ToString();
                        dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value = String.Format("{0:0.0000}", dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value).ToString();
                        if (dgSaleAddedItems.Rows[rowindex].Cells["dgDisc"].Value != null)
                        {
                            dgSaleAddedItems.Rows[rowindex].Cells["dgDisc"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgDisc"].Value.ToString())).ToString();
                            discResult = (discResult - (discResult * decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgDisc"].Value.ToString()) / 100));
                        }
                        dgSaleAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = String.Format("{0:0.0000}", discResult).ToString();

                        //Change lblsubtotal
                        var st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                        if (st != null)
                        {
                            lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) - st.Item2).ToString();
                            SubTotal.Remove(st);

                            int subtotalcol1 = 0;
                            if (dgSaleAddedItems.Rows[rowindex].Cells[0].Value != null) subtotalcol1 = Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString());
                            SubTotal.Add(new Tuple<int, decimal>(subtotalcol1, Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())));
                            st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                            lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st.Item2).ToString();
                        }
                        else
                        {
                            int subtotalcol1 = 0;
                            if (dgSaleAddedItems.Rows[rowindex].Cells[0].Value != null) subtotalcol1 = Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString());
                            SubTotal.Add(new Tuple<int, decimal>(subtotalcol1, Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())));
                            st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                            lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st.Item2).ToString();
                        }

                        //ChangeCurr(rowindex);
                        if (dgSaleAddedItems.CurrentCell == null) dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[rowindex].Cells[0];
                        GetMargin();
                        dgSaleAddedItems.Rows[rowindex].Cells["dgMargin"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgMargin"].Value.ToString())).ToString();
                        if (dgSaleAddedItems.CurrentRow.Cells["dgUnitWeigt"].Value != null && dgSaleAddedItems.CurrentRow.Cells["dgUnitWeigt"].Value != "") dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgTotalWeight"].Value = (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();
                        txtTotalMargin.Text = calculateTotalMargin().ToString();
                    }
                    else { MessageBox.Show("This product does not have price"); }
                }
                #endregion
                #endregion

            }
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

            if (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null && dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != "")
            {
                if (Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString()) > 1 || Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgSSM"].Value.ToString()) > 1)
                {
                    if(Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString()) > 1 && (!(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString().Contains("P"))))
                    {
                        dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString())*   decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString())  )))) * 100).ToString("G29");
                    }
                    else
                    {
                        dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");

                    }
                    //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
                    if (SubTotal.Where(a => a.Item1 == Int32.Parse(dgSaleAddedItems.CurrentRow.Cells[0].Value.ToString())).FirstOrDefault() != null)
                    {
                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgSaleAddedItems.CurrentRow.Cells[0].Value.ToString())).FirstOrDefault();
                        SubTotal.Remove(st);
                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgSaleAddedItems.CurrentRow.Cells[0].Value.ToString()), Decimal.Parse(dgSaleAddedItems.CurrentRow.Cells["dgTotal"].Value.ToString())));
                    }
                    else
                    {
                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgSaleAddedItems.CurrentRow.Cells[0].Value.ToString()), Decimal.Parse(dgSaleAddedItems.CurrentRow.Cells["dgTotal"].Value.ToString())));
                    }
                }
                else
                {
                    dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");

                }
            }
            #endregion
        }

        private void GetAllMargin()
        {
            #region Get Margin
            DateTime today = DateTime.Today;
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                try
                {
                    if (dgSaleAddedItems.Rows[i].Cells["dgQty"].Value != null)
                    {
                        if (Int32.Parse(dgSaleAddedItems.Rows[i].Cells["dgUC"].Value.ToString()) > 1 && (!(dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString().Contains("P"))))
                        {
                            dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()) * decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUC"].Value.ToString()))))) * 100).ToString("G29");
                        }
                        else
                        {
                            dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");

                        }
                    }
                    if (SubTotal.Where(a => a.Item1 == Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault() != null)
                    {
                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                        SubTotal.Remove(st);
                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()), Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())));
                    }
                    else
                    {
                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()), Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())));
                    }
                }
                catch { }

            }

            #endregion
        }

        private void FillProductCodeItem()
        {
            #region FillProductCodeItem
            //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.CurrentCell.Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked,
            //    Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQtr"].Value.ToString()))).ToString("G29");
            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgCCCNO"].Value = txtCCCN.Text;
            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgCOO"].Value = txtCofO.Text;
            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUnitWeigt"].Value = txtStandartWeight.Text;
            dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgTotalWeight"].Value = txtGrossWeight.Text;
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
            #region Filler
            ExchangeRate currWeb = new ExchangeRate();
            decimal curID = Convert.ToDecimal(cbCurrency.SelectedValue);
            currWeb = IME.ExchangeRates.Where(a => a.currencyId == curID).OrderByDescending(x => x.date).FirstOrDefault();
            decimal CurrValueWeb = Decimal.Parse(curr.rate.ToString());
            string ArticleNoSearch1 = ArticleNoSearch;
            try { ArticleNoSearch1 = (Int32.Parse(ArticleNoSearch)).ToString(); } catch { }
            //Seçili olan item ı text lere yazdıran fonksiyon yazılacak
            var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            if (sd == null) { sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNoSearch1).FirstOrDefault(); }

            var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            if (sdP == null) { sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNoSearch1).FirstOrDefault(); }

            var er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (er == null) { er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            var os = IME.OnSales.Where(a => a.ArticleNumber == ArticleNoSearch).FirstOrDefault();
            if (os == null) { os = IME.OnSales.Where(a => a.ArticleNumber == ArticleNoSearch1).FirstOrDefault(); }

            var sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (sp == null) { sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            var dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (dd == null) { dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            var h = IME.Hazardous.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (h == null) { h = IME.Hazardous.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            var du = IME.DualUses.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (du == null) { du = IME.DualUses.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            if (sd != null)
            {
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgDesc"].Value = sd.Article_Desc;
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgSSM"].Value = sd.Pack_Quantity.ToString();
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value = sd.Unit_Content.ToString();
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = sd.Unit_Measure;
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMPN"].Value = sd.MPN;
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgCL"].Value = sd.Calibration_Ind;
                dgSaleAddedItems.CurrentRow.Cells["dgDependantTable"].Value = "sd";
                if (sd.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sd.Standard_Weight) / (decimal)1000).ToString("G29"); } else { }
                txtHazardousInd.Text = sd.Hazardous_Ind;
                txtCalibrationInd.Text = sd.Calibration_Ind;
                //ObsoluteFlag.Text = sd.Obsolete_Flag.ToString();
                //LowDiscontInd.Text = sd.Low_Discount_Ind;
                //LicensedInd.Text = sd.Licensed_Ind.ToString();
                //ShelfLife.Text = sd.Shelf_Life;
                txtCofO.Text = sd.CofO;
                txtCCCN.Text = sd.CCCN_No.ToString();
                //UKIntroDate.Text = sd.Uk_Intro_Date;
                txtUKDiscDate.Text = sd.Uk_Disc_Date;
                //BHCFlag.Text = sd.BHC_Flag.ToString();
                txtDiscCharge.Text = sd.Disc_Change_Ind;
                txtExpiringPro.Text = sd.Expiring_Product_Change_Ind;
                txtManufacturer.Text = sd.Manufacturer.ToString();
                txtMHCodeLevel1.Text = sd.MH_Code_Level_1;
                txtCCCN.Text = sd.CCCN_No.ToString();
                txtHeight.Text = ((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sd.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sd.Length * ((Decimal)100))).ToString("G29");
            }
            if (sdP != null)
            {
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgDesc"].Value = sdP.Article_Desc;
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgSSM"].Value = sdP.Pack_Quantity.ToString();
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value = sdP.Unit_Content.ToString();
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
                dgSaleAddedItems.CurrentRow.Cells["dgDependantTable"].Value = "sdp";
                //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgPackType"].Value = sdP.Calibration_Ind.ToString();

                if (sdP.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sdP.Standard_Weight) / (decimal)1000).ToString("G29"); }
                txtHazardousInd.Text = sdP.Hazardous_Ind;
                txtCalibrationInd.Text = sdP.Calibration_Ind;
                //ObsoluteFlag.Text = sdP.Obsolete_Flag.ToString();
                //LowDiscontInd.Text = sdP.Low_Discount_Ind;
                //LicensedInd.Text = sdP.Licensed_Ind.ToString();
                //ShelfLife.Text = sdP.Shelf_Life;
                txtCofO.Text = sdP.CofO;
                txtCCCN.Text = sdP.CCCN_No.ToString();
                //UKIntroDate.Text = sdP.Uk_Intro_Date;
                txtUKDiscDate.Text = sdP.Uk_Disc_Date;
                //BHCFlag.Text = sdP.BHC_Flag.ToString();
                txtDiscCharge.Text = sdP.Disc_Change_Ind;
                txtExpiringPro.Text = sdP.Expiring_Product_Change_Ind;
                txtManufacturer.Text = sdP.Manufacturer.ToString();
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMPN"].Value = sdP.MPN;
                txtMHCodeLevel1.Text = sdP.MH_Code_Level_1;
                txtCCCN.Text = sdP.CCCN_No.ToString();
                txtHeight.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            }
            if (er != null)
            {
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgDesc"].Value = er.ArticleDescription;
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = er.UnitofMeasure;
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgMPN"].Value = er.MPN;
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgSSM"].Value = er.PackSize;
                dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value = er.SalesUoM;
                dgSaleAddedItems.CurrentRow.Cells["dgDependantTable"].Value = "ext";


                if (txtLength.Text != "") { txtLength.Text = ((decimal)(er.ExtendedRangeLength * ((Decimal)100))).ToString("G29"); }
                if (txtWidth.Text != "") { txtWidth.Text = ((decimal)(er.Width * ((Decimal)100))).ToString("G29"); }
                if (txtHeight.Text != "") { txtHeight.Text = ((decimal)(er.Height * ((Decimal)100))).ToString("G29"); }
                if (er.ExtendedRangeWeight != null) { txtStandartWeight.Text = ((decimal)(er.ExtendedRangeWeight) / (decimal)1000).ToString("G29"); }
                txtCCCN.Text = er.CCCN.ToString();
                txtCofO.Text = er.CountryofOrigin;





                txtUK1.Text = er.Col1Price.ToString();
                txtUK2.Text = er.Col2Price.ToString();
                txtUK3.Text = er.Col3Price.ToString();
                txtUK4.Text = er.Col4Price.ToString();
                txtUK5.Text = er.Col5Price.ToString();
                txtUnitCount1.Text = er.Col1Break.ToString();
                txtUnitCount2.Text = er.Col2Break.ToString();
                txtUnitCount3.Text = er.Col3Break.ToString();
                txtUnitCount4.Text = er.Col4Break.ToString();
                txtUnitCount5.Text = er.Col5Break.ToString();
                txtCost1.Text = er.DiscountedPrice1.ToString();
                txtCost2.Text = er.DiscountedPrice2.ToString();
                txtCost3.Text = er.DiscountedPrice3.ToString();
                txtCost4.Text = er.DiscountedPrice4.ToString();
                txtCost5.Text = er.DiscountedPrice5.ToString();
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            }
            if (sp != null)
            {
                //IntroductionDate.Text = sp.IntroductionDate;
                //DiscontinuedDate.Text = sp.DiscontinuedDate;
                txtUnitCount1.Text = sp.Col1Break.ToString();
                txtUnitCount2.Text = sp.Col2Break.ToString();
                txtUnitCount3.Text = sp.Col3Break.ToString();
                txtUnitCount4.Text = sp.Col4Break.ToString();
                txtUnitCount5.Text = sp.Col5Break.ToString();
                txtUK1.Text = sp.Col1Price.ToString();
                txtUK2.Text = sp.Col2Price.ToString();
                txtUK3.Text = sp.Col3Price.ToString();
                txtUK4.Text = sp.Col4Price.ToString();
                txtUK5.Text = sp.Col5Price.ToString();
                txtCost1.Text = sp.DiscountedPrice1.ToString();
                txtCost2.Text = sp.DiscountedPrice2.ToString();
                txtCost3.Text = sp.DiscountedPrice3.ToString();
                txtCost4.Text = sp.DiscountedPrice4.ToString();
                txtCost5.Text = sp.DiscountedPrice5.ToString();
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtSupersectionName.Text = sp.SupersectionName;
            }
            if (h != null)
            {
                if (h.Environment != null) { txtEnvironment.Text = "Y"; } else { txtEnvironment.Text = ""; }
                if (h.Lithium != null) { txtLithium.Text = "Y"; } else { txtLithium.Text = ""; }
                if (h.Shipping != null) { txtShipping.Text = "Y"; } else { txtShipping.Text = ""; }
            }
            else
            {
                txtEnvironment.Text = "";
                txtLithium.Text = "";
                txtShipping.Text = "";
            }
            if (os != null)
            {
                //OnSaleDiscontinuedDate.Text = os.DiscontinuedDate;
                //OnSaleIntroductionDate.Text = os.IntroductionDate;
                txtRSStock.Text = os.OnhandStockBalance.ToString();
                txtRSOnOrder.Text = os.QuantityonOrder.ToString();
            }
            if (dd != null)
            {
                txtDiscontinuationDate.Text = dd.DiscontinuationDate;
                txtRunOn.Text = dd.Runon.ToString();
                txtReferral.Text = dd.Referral.ToString();
            }
            if (du != null) { txtLicenceType.Text = du.LicenceType; }
            //
            #endregion
            if (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value == "" && dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value != null) { dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = "Each"; }
            #region ItemMarginFiller
            string articleNo = dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString();
            SlidingPrice sp1 = IME.SlidingPrices.Where(a => a.ArticleNo == articleNo).FirstOrDefault();
            int quantity = 0;
            if (sp1 != null) { quantity = Int32.Parse(sp1.Col1Break.ToString()); } else { quantity = Int32.Parse(er.Col1Break.ToString()); }

            txtMargin1.Text = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true, quantity)).ToString("G29");
            txtMargin1.Text = ((1 - ((Decimal.Parse(txtMargin1.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();

            int quantity2 = 0;
            if (sp1 != null) { quantity2 = Int32.Parse(sp1.Col2Break.ToString()); } else { quantity2 = Int32.Parse(er.Col2Break.ToString()); }

            txtMargin2.Text = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true, quantity2)).ToString("G29");

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
                txtMargin3.Text = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true, Int32.Parse(sp1.Col3Break.ToString()))).ToString("G29");
                if (Decimal.Parse(txtWeb3.Text) != 0) txtMargin3.Text = ((1 - ((Decimal.Parse(txtMargin3.Text)) / (decimal.Parse(txtWeb3.Text)))) * 100).ToString();
                if (sp1.Col4Break != 0)
                {
                    txtMargin4.Text = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true, Int32.Parse(sp1.Col4Break.ToString()))).ToString("G29");
                    txtMargin4.Text = ((1 - ((Decimal.Parse(txtMargin4.Text)) / (decimal.Parse(txtWeb4.Text)))) * 100).ToString();
                    if (sp1.Col5Break != 0)
                    {
                        txtMargin5.Text = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), true, true, true, Int32.Parse(sp1.Col5Break.ToString()))).ToString("G29");
                        txtMargin5.Text = ((1 - ((Decimal.Parse(txtMargin5.Text)) / (decimal.Parse(txtWeb5.Text)))) * 100).ToString();
                    }
                }

            }

            #endregion
            #region Low Margin Mark


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

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                classQuotationAdd.customersearchID = CustomerCode.Text;
                classQuotationAdd.customersearchname = "";
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(customer);
                this.Enabled = false;
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    customer = form.customer;
                    cbWorkers.DataSource = customer.CustomerWorkers.Where(a => a.cw_name != null).ToList();
                    cbWorkers.DisplayMember = "cw_name";
                    cbWorkers.ValueMember = "ID";
                }
                this.Enabled = true;
                fillCustomer();

            }
        }

        private void cbRep_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            txtGrossWeight.Text = "";
            try
            {
                if (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
                {
                    txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())).ToString();
                }
            }
            catch { }

        }

        private void dgQuotationAddedItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgSaleAddedItems.RowCount > 1) dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();
        }

        private void dgQuotationAddedItems_Click(object sender, EventArgs e)

        {
            ItemClear();
            try { ItemDetailsFiller(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString()); } catch { }
        }

        

        private void GetLandingCost(int Rowindex)
        {
            try
            {
                dgSaleAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dgSaleAddedItems.Rows[Rowindex].Cells["dgProductCode"].Value.ToString(), true, true, true)).ToString("G29");
                dgSaleAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = String.Format("{0:0.0000}", dgSaleAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value.ToString()).ToString();
            }
            catch { }

        }

        private void getQuotationValues()
        {
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                if (dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                {


                    GetLandingCost(i);
                    if (Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString()) < Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgCost"].Value.ToString()))
                    {
                        dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value = dgSaleAddedItems.Rows[i].Cells["dgCost"].Value.ToString();
                    }
                    GetAllMargin();
                    try
                    {
                        #region Get Margin
                        if (dgSaleAddedItems.Rows[i].Cells["dgQty"].Value != null)
                        {
                            dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
                        }
                        #endregion
                    }
                    catch { }
                }
            }
        }

        private void ckItemCost_CheckedChanged(object sender, EventArgs e)
        {
            getQuotationValues();
        }

        private void CalculateSubTotal()
        {
            if (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value != null)
            {

                #region SubTotal Calculation
                int RowIndex = dgSaleAddedItems.CurrentCell.RowIndex;
                int rowindexSubTotal = 0;
                if (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value != null && dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value != "") Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value.ToString());
                var tuple = SubTotal.Where(a => a.Item1 == rowindexSubTotal).FirstOrDefault();
                if (tuple == null || tuple.Item2 == 0)
                {
                    if (dgSaleAddedItems.Rows[RowIndex].Cells["dgTotal"].Value != null && dgSaleAddedItems.Rows[RowIndex].Cells["dgTotal"].Value != "")
                    {
                        var tuple0 = new Tuple<int, decimal>(rowindexSubTotal, Decimal.Parse(dgSaleAddedItems.Rows[RowIndex].Cells["dgTotal"].Value.ToString()));
                        SubTotal.Add(tuple0);
                        tuple = SubTotal.Where(a => a.Item1 == rowindexSubTotal).FirstOrDefault();
                        if (lblsubtotal.Text != "" && lblsubtotal.Text != null)
                        {
                            lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + tuple.Item2).ToString();
                        }
                        else
                        {
                            lblsubtotal.Text = (SubTotal[rowindexSubTotal]).ToString();
                        }
                    }

                }
                else
                {


                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) - (tuple.Item2)).ToString();
                    SubTotal.Remove(tuple);

                    if (dgSaleAddedItems.Rows[RowIndex].Cells["dgQty"].Value != null && dgSaleAddedItems.Rows[RowIndex].Cells["dgQty"].Value != "")
                    {
                        SubTotal.Add(new Tuple<int, decimal>(rowindexSubTotal, (Decimal.Parse(dgSaleAddedItems.Rows[RowIndex].Cells["dgTotal"].Value.ToString()))));
                        dgSaleAddedItems.Rows[RowIndex].Cells["dgTotal"].Value = (Decimal.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString()) * Decimal.Parse(dgSaleAddedItems.Rows[RowIndex].Cells["dgUCUPCurr"].Value.ToString())).ToString();
                    }
                    decimal total = 0;
                    try { total = decimal.Parse(dgSaleAddedItems.Rows[RowIndex].Cells["dgTotal"].Value.ToString()); } catch { }
                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + total).ToString();
                }
                #endregion
            }
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
                ) { lblsubtotal.Text = Decimal.Parse(String.Format("{0:0.0000}", (decimal.Parse(lblsubtotal.Text)))).ToString("G29"); }
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
                        txtTotalDis.Text = ((CurrentDis * 100) / Decimal.Parse(lblsubtotal.Text)).ToString();
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
                if (dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value != null && Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value.ToString()) < Utils.getCurrentUser().MinMarge) { MessageBox.Show("Please Check Merge of Products "); return false; }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            bool SaveOK = false;
            SaveOK = ControlSave();
            if (SaveOK)
            {
                SaleSave();
                //QuotationDetailsSave();
            }

            //}
            //catch { MessageBox.Show("Error Occured", "Failure"); }

        }

        private void SaleSave()
        {
            try
            {
                SaleOrder s = new SaleOrder();
                //TODO (SALEORDER) ID Formatını öğren ve ID'yi düzenle
                s.SaleOrderNo = "SO" + (IME.SaleOrders.Count() + 1);
                s.SaleDate = DateTime.Now;
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
                s.NoteForCustomer = txtNoteForCustomer.Text;
                s.NoteForFinance = (chkbForFinance.Checked == true) ? 1 : 0;
                s.SaleOrderNature = cbOrderNature.SelectedItem.ToString();
                s.ShippingType = cbSMethod.SelectedItem.ToString();
                s.currencyID = (decimal)cbCurrency.SelectedValue;
                s.LPONO = txtLPONO.Text;
                s.TotalMargin = Convert.ToDecimal(txtTotalMargin.Text);
                s.Factor = Convert.ToDecimal(txtFactor.Text);
                s.SubTotal = Convert.ToDecimal(lblsubtotal.Text);
                s.DiscOnSubtotal = (txtTotalDis.Text != null && txtTotalDis.Text != String.Empty) ? Convert.ToDecimal(txtTotalDis.Text) : 0;
                s.ExtraCharges = (txtExtraCharges.Text != null && txtExtraCharges.Text != String.Empty) ?Convert.ToDecimal(txtExtraCharges.Text) : 0;
                

                IME.SaleOrders.Add(s);
                IME.SaveChanges();


                MessageBox.Show("Just SaleOrder saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            


            //DataSet.Quotation q = new DataSet.Quotation();
            //q.QuotationNo = txtSaleOrderNo.Text;
            //q.RFQNo = txtLPONO.Text;
            //try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
            //if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
            //q.ShippingMethodID = cbSMethod.SelectedIndex;
            //try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
            //try { q.ExtraCharges = decimal.Parse(txtExtraChanges.Text); } catch { }
            //if (chkVat.Checked) { q.IsVatValue = 1; } else { q.IsVatValue = 0; }
            //try { q.VatValue = Decimal.Parse(lblVat.Text); } catch { }
            //try { q.StartDate = dtpDate.Value; } catch { }
            //try { q.Factor = Decimal.Parse(cbFactor.Text); } catch { }
            ////try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
            //q.PaymentID = (cbPayment.SelectedItem as PaymentMethod).ID;
            //q.CurrType = (cbCurrency.SelectedItem as Rate).CurType;
            ////q.CurrType = cbCurrType.Text;
            //q.Curr = CurrValue;

            //q.CustomerID = CustomerCode.Text;
            //q.ShippingMethodID = cbSMethod.SelectedIndex;
            //q.QuotationMainContact = cbWorkers.SelectedIndex;
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

        private void QuotationSave(string QuoNo)
        {
            IMEEntities IME = new IMEEntities();
            Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(QuoNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
            if (txtSaleOrderNo.Text.Contains("v"))
            {
                int quoID = Int32.Parse(txtSaleOrderNo.Text.Substring(txtSaleOrderNo.Text.LastIndexOf('v') + 1));
                txtSaleOrderNo.Text = (txtSaleOrderNo.Text.Substring(0, txtSaleOrderNo.Text.IndexOf('v') + 1) + quoID).ToString();
            }
            else
            {
                txtSaleOrderNo.Text = q1.QuotationNo + "v1";
            }
            Quotation q = new Quotation();
            q.QuotationNo = txtSaleOrderNo.Text;
            q.RFQNo = txtLPONO.Text;
            try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
            if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
            q.ShippingMethodID = cbSMethod.SelectedIndex;
            try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
            try { q.ExtraCharges = decimal.Parse(txtExtraCharges.Text); } catch { }
            if (chkVat.Checked) { q.IsVatValue = 1; } else { q.IsVatValue = 0; }
            try { q.VatValue = Decimal.Parse(lblVat.Text); } catch { }
            try { q.StartDate = dtpDate.Value; } catch { }
            try { q.Factor = Decimal.Parse(txtFactor.Text); } catch { }
            //try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
            try { q.PaymentID = (cbPayment.SelectedItem as PaymentMethod).ID; } catch { }
            try { q.CurrName = (cbCurrency.SelectedItem as Rate).CurType; } catch { }
            q.ShippingMethodID = cbSMethod.SelectedIndex;
            //try { q.CurrType = cbCurrType.SelectedText; } catch { }
            try { q.Curr = CurrValue; } catch { }
            try { q.CustomerID = CustomerCode.Text; } catch { }
            try { q.QuotationMainContact = cbWorkers.SelectedIndex; } catch { }
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
            if (Note1 != 0) q.NoteForUsID = Note1;
            if (Note2 != 0) q.NoteForCustomerID = Note2;

            IME.Quotations.Add(q);
            IME.SaveChanges();
        }

        private void QuotationDetailsSave()
        {
            IMEEntities IME = new IMEEntities();
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                if (dgSaleAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                {
                    QuotationDetail qd = new QuotationDetail();
                    qd.QuotationNo = txtSaleOrderNo.Text;
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
                    qd.DependantTable = dgSaleAddedItems.Rows[i].Cells["dgDependantTable"].Value.ToString();
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
                    if (dgSaleDeleted.Rows[i].Cells["dgSSM"].Value != null) qd.SSM = Int32.Parse(dgSaleDeleted.Rows[i].Cells["dgSSM"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUC"].Value != null) qd.UC = Int32.Parse(dgSaleDeleted.Rows[i].Cells["dgUC"].Value.ToString());
                    if (dgSaleDeleted.Rows[i].Cells["dgUnitWeigt"].Value != null) qd.UnitWeight = Decimal.Parse(dgSaleDeleted.Rows[i].Cells["dgUnitWeigt"].Value.ToString());
                    qd.IsDeleted = 1;
                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
                }
            }
            MessageBox.Show("Quotation is successfully added", "Success");
            this.Close();
        }

        private void modifyQuotation(List<QuotationDetail> itemList)
        {
            #region QuotationLoader
            //txtQuotationNo.Text = q.QuotationNo;
            //txtRFQNo.Text = q.RFQNo;
            CustomerCode.Text = customer.c_name;
            //if (q.NoteForCustomerID != null) txtNoteForCustomer.Text = IME.Notes.Where(a => a.ID == q.NoteForCustomerID).FirstOrDefault().Note_name;
            //if (q.NoteForCustomerID != null) txtNoteForUs.Text = IME.Notes.Where(a => a.ID == q.NoteForUsID).FirstOrDefault().Note_name;
            //if (q.ForFinancelIsTrue == 1) { chkbForFinance.Checked = true; }
            fillCustomer();
            #region QuotationDetails
            cbCurrency.SelectedIndex = 1;
            //cbCurrType.SelectedItem = q.CurrType;
            cbWorkers.SelectedValue = (customer.MainContactID != null) ? customer.MainContactID : cbWorkers.SelectedValue;
            foreach (var item in itemList)
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
            //ItemDetailsFiller(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString());
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                GetQuotationQuantity(i);
                GetLandingCost(i);
            }
            GetAllMargin();
            #endregion
            //buradaki yazılanların sırası önemli sırayı değiştirmeyin
            //lblsubtotal.Text = q.SubTotal.ToString();
            //txtTotalDis2.Text = q.DiscOnSubTotal2.ToString();
            //txtExtraChanges.Text = q.ExtraCharges.ToString();
            lblVat.Text = Utils.getManagement().VAT.ToString();
            //if (q.IsVatValue == 1) { chkVat.Checked = true; } else { chkVat.Checked = false; }
            //if (q.IsItemCost == 1) { ckItemCost.Checked = true; } else { ckItemCost.Checked = false; }
            //if (q.IsWeightCost == 1) { ckWeightCost.Checked = true; } else { ckWeightCost.Checked = false; }
            //if (q.IsCustomsDuties == 1) { ckCustomsDuties.Checked = true; } else { ckCustomsDuties.Checked = false; }
            //Buraya Curr verileri gelecek
            #endregion
            if (dgSaleAddedItems.RowCount > 1)
            {
                dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgSaleAddedItems.Rows[dgSaleAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();
            }
            else { dgSaleAddedItems.Rows[0].Cells[0].Value = 1.ToString(); }
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
            #region Filler
            decimal CurrValueWeb = Decimal.Parse(curr.rate.ToString());
            string ArticleNoSearch1 = ArticleNoSearch;
            try { ArticleNoSearch1 = (Int32.Parse(ArticleNoSearch)).ToString(); } catch { }
            //Seçili olan item ı text lere yazdıran fonksiyon yazılacak
            var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            if (sd == null) { sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNoSearch1).FirstOrDefault(); }

            var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            if (sdP == null) { sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNoSearch1).FirstOrDefault(); }

            var er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (er == null) { er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            var os = IME.OnSales.Where(a => a.ArticleNumber == ArticleNoSearch).FirstOrDefault();
            if (os == null) { os = IME.OnSales.Where(a => a.ArticleNumber == ArticleNoSearch1).FirstOrDefault(); }

            var sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (sp == null) { sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            var dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (dd == null) { dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            var h = IME.Hazardous.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (h == null) { h = IME.Hazardous.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            var du = IME.DualUses.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (du == null) { du = IME.DualUses.Where(a => a.ArticleNo == ArticleNoSearch1).FirstOrDefault(); }

            if (sd != null)
            {
                dgSaleAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = sd.Article_Desc;
                dgSaleAddedItems.Rows[RowIndex].Cells["dgSSM"].Value = sd.Pack_Quantity.ToString();
                dgSaleAddedItems.Rows[RowIndex].Cells["dgUC"].Value = sd.Unit_Content.ToString();
                dgSaleAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sd.Unit_Measure;
                dgSaleAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = sd.MPN;
                dgSaleAddedItems.Rows[RowIndex].Cells["dgCL"].Value = sd.Calibration_Ind;
                if (sd.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sd.Standard_Weight) / (decimal)1000).ToString("G29"); } else { }
                txtHazardousInd.Text = sd.Hazardous_Ind;
                txtCalibrationInd.Text = sd.Calibration_Ind;
                //ObsoluteFlag.Text = sd.Obsolete_Flag.ToString();
                //LowDiscontInd.Text = sd.Low_Discount_Ind;
                //LicensedInd.Text = sd.Licensed_Ind.ToString();
                //ShelfLife.Text = sd.Shelf_Life;
                txtCofO.Text = sd.CofO;
                txtCCCN.Text = sd.CCCN_No.ToString();
                //UKIntroDate.Text = sd.Uk_Intro_Date;
                txtUKDiscDate.Text = sd.Uk_Disc_Date;
                //BHCFlag.Text = sd.BHC_Flag.ToString();
                txtDiscCharge.Text = sd.Disc_Change_Ind;
                txtExpiringPro.Text = sd.Expiring_Product_Change_Ind;
                txtManufacturer.Text = sd.Manufacturer.ToString();
                txtMHCodeLevel1.Text = sd.MH_Code_Level_1;
                txtCCCN.Text = sd.CCCN_No.ToString();
                txtHeight.Text = ((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sd.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sd.Length * ((Decimal)100))).ToString("G29");
            }
            if (sdP != null)
            {
                dgSaleAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = sdP.Article_Desc;
                dgSaleAddedItems.Rows[RowIndex].Cells["dgSSM"].Value = sdP.Pack_Quantity.ToString();
                dgSaleAddedItems.Rows[RowIndex].Cells["dgUC"].Value = sdP.Unit_Content.ToString();
                dgSaleAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
                dgSaleAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
                // dgQuotationAddedItems.Rows[RowIndex].Cells["dgPackType"].Value = sdP.Calibration_Ind;

                if (sdP.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sdP.Standard_Weight) / (decimal)1000).ToString("G29"); }
                txtHazardousInd.Text = sdP.Hazardous_Ind;
                txtCalibrationInd.Text = sdP.Calibration_Ind;
                //ObsoluteFlag.Text = sdP.Obsolete_Flag.ToString();
                //LowDiscontInd.Text = sdP.Low_Discount_Ind;
                //LicensedInd.Text = sdP.Licensed_Ind.ToString();
                //ShelfLife.Text = sdP.Shelf_Life;
                txtCofO.Text = sdP.CofO;
                txtCCCN.Text = sdP.CCCN_No.ToString();
                //UKIntroDate.Text = sdP.Uk_Intro_Date;
                txtUKDiscDate.Text = sdP.Uk_Disc_Date;
                //BHCFlag.Text = sdP.BHC_Flag.ToString();
                txtDiscCharge.Text = sdP.Disc_Change_Ind;
                txtExpiringPro.Text = sdP.Expiring_Product_Change_Ind;
                txtManufacturer.Text = sdP.Manufacturer.ToString();
                dgSaleAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = sdP.MPN;
                txtMHCodeLevel1.Text = sdP.MH_Code_Level_1;
                txtCCCN.Text = sdP.CCCN_No.ToString();
                txtHeight.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            }
            if (er != null)
            {
                dgSaleAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = er.ArticleDescription;
                dgSaleAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = er.UnitofMeasure;
                dgSaleAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = er.MPN;
                if (txtLength.Text != "") { txtLength.Text = ((decimal)(er.ExtendedRangeLength * ((Decimal)100))).ToString("G29"); }
                if (txtWidth.Text != "") { txtWidth.Text = ((decimal)(er.Width * ((Decimal)100))).ToString("G29"); }
                if (txtHeight.Text != "") { txtHeight.Text = ((decimal)(er.Height * ((Decimal)100))).ToString("G29"); }
                if (er.ExtendedRangeWeight != null) { txtStandartWeight.Text = ((decimal)(er.ExtendedRangeWeight) / (decimal)1000).ToString("G29"); }
                txtCCCN.Text = er.CCCN.ToString();
                txtCofO.Text = er.CountryofOrigin;
                txtUK1.Text = er.Col1Price.ToString();
                txtUK2.Text = er.Col2Price.ToString();
                txtUK3.Text = er.Col3Price.ToString();
                txtUK4.Text = er.Col4Price.ToString();
                txtUK5.Text = er.Col5Price.ToString();
                txtUnitCount1.Text = er.Col1Break.ToString();
                txtUnitCount2.Text = er.Col2Break.ToString();
                txtUnitCount3.Text = er.Col3Break.ToString();
                txtUnitCount4.Text = er.Col4Break.ToString();
                txtUnitCount5.Text = er.Col5Break.ToString();
                txtCost1.Text = er.DiscountedPrice1.ToString();
                txtCost2.Text = er.DiscountedPrice2.ToString();
                txtCost3.Text = er.DiscountedPrice3.ToString();
                txtCost4.Text = er.DiscountedPrice4.ToString();
                txtCost5.Text = er.DiscountedPrice5.ToString();
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            }
            if (sp != null)
            {
                //IntroductionDate.Text = sp.IntroductionDate;
                //DiscontinuedDate.Text = sp.DiscontinuedDate;
                txtUnitCount1.Text = sp.Col1Break.ToString();
                txtUnitCount2.Text = sp.Col2Break.ToString();
                txtUnitCount3.Text = sp.Col3Break.ToString();
                txtUnitCount4.Text = sp.Col4Break.ToString();
                txtUnitCount5.Text = sp.Col5Break.ToString();
                txtUK1.Text = sp.Col1Price.ToString();
                txtUK2.Text = sp.Col2Price.ToString();
                txtUK3.Text = sp.Col3Price.ToString();
                txtUK4.Text = sp.Col4Price.ToString();
                txtUK5.Text = sp.Col5Price.ToString();
                txtCost1.Text = sp.DiscountedPrice1.ToString();
                txtCost2.Text = sp.DiscountedPrice2.ToString();
                txtCost3.Text = sp.DiscountedPrice3.ToString();
                txtCost4.Text = sp.DiscountedPrice4.ToString();
                txtCost5.Text = sp.DiscountedPrice5.ToString();
                txtSupersectionName.Text = sp.SupersectionName;
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(txtFactor.Text)) / CurrValueWeb).ToString();
            }
            if (h != null)
            {
                if (h.Environment != null) { txtEnvironment.Text = "Y"; } else { txtEnvironment.Text = ""; }
                if (h.Lithium != null) { txtLithium.Text = "Y"; } else { txtLithium.Text = ""; }
                if (h.Shipping != null) { txtShipping.Text = "Y"; } else { txtShipping.Text = ""; }
            }
            else
            {
                txtEnvironment.Text = "";
                txtLithium.Text = "";
                txtShipping.Text = "";
            }
            if (os != null)
            {
                //OnSaleDiscontinuedDate.Text = os.DiscontinuedDate;
                //OnSaleIntroductionDate.Text = os.IntroductionDate;
                txtRSStock.Text = os.OnhandStockBalance.ToString();
                txtRSOnOrder.Text = os.QuantityonOrder.ToString();
            }
            if (dd != null)
            {
                txtDiscontinuationDate.Text = dd.DiscontinuationDate;
                txtRunOn.Text = dd.Runon.ToString();
                txtReferral.Text = dd.Referral.ToString();
            }
            if (du != null) { txtLicenceType.Text = du.LicenceType; }
            //
            #endregion
            #region ItemMarginFiller
            string articleNo = ArticleNoSearch;
            SlidingPrice sp1 = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            try
            {
                txtMargin1.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true, Int32.Parse(sp1.Col1Break.ToString()))).ToString("G29");
                txtMargin1.Text = ((1 - ((Decimal.Parse(txtMargin1.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
            }
            catch { }
            try
            {
                txtMargin2.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true, Int32.Parse(sp1.Col2Break.ToString()))).ToString("G29");
            }
            catch { }
            if (txtWeb2.Text == "0")
            {
                txtMargin2.Text = "";
                txtMargin3.Text = "";
                txtMargin4.Text = "";
                txtMargin5.Text = "";
            }
            else
            {
                try
                {
                    txtMargin2.Text = ((1 - ((Decimal.Parse(txtMargin2.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
                    txtMargin3.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true, Int32.Parse(sp1.Col3Break.ToString()))).ToString("G29");
                    txtMargin3.Text = ((1 - ((Decimal.Parse(txtMargin3.Text)) / (decimal.Parse(txtWeb3.Text)))) * 100).ToString();
                    if (sp1.Col4Break != 0)
                    {
                        txtMargin4.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true
                    , Int32.Parse(sp1.Col4Break.ToString()))).ToString("G29");
                        txtMargin4.Text = ((1 - ((Decimal.Parse(txtMargin4.Text)) / (decimal.Parse(txtWeb4.Text)))) * 100).ToString();
                        if (sp1.Col5Break != 0)
                        {
                            txtMargin5.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, true, true, true
                        , Int32.Parse(sp1.Col5Break.ToString()))).ToString("G29");
                            txtMargin5.Text = ((1 - ((Decimal.Parse(txtMargin5.Text)) / (decimal.Parse(txtWeb5.Text)))) * 100).ToString();
                        }
                    }
                }
                catch { }
            }

            #endregion
            #region Low Margin Mark

            if (txtLithium.Text != "")
            {
                label64.BackColor = Color.Red;
                dgSaleAddedItems.Rows[RowIndex].Cells["LI"].Style.BackColor = Color.Ivory;


            }
            if (txtShipping.Text != "")
            {
                label63.BackColor = Color.Red;
                dgSaleAddedItems.Rows[RowIndex].Cells["HS"].Style.BackColor = Color.Red;

            }
            if (txtEnvironment.Text != "")
            {
                label53.BackColor = Color.Red;
            }
            if (txtCalibrationInd.Text != "" && txtCalibrationInd.Text != null && txtCalibrationInd.Text != "N")
            {
                label22.BackColor = Color.Red;
                dgSaleAddedItems.Rows[RowIndex].Cells["CL"].Style.BackColor = Color.Green;
            }

            if (txtLicenceType.Text != "" && txtLicenceType.Text != null)
            {
                dgSaleAddedItems.Rows[RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
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
            //        MessageBox.Show("You Must Choose a Curr Typ9e");
            //        cbCurrType.SelectedIndex = 0;
            //    }
        }

        private void GetCurrency(DateTime date)
        {
            decimal cb = (cbCurrency.SelectedItem as Currency).currencyID;
            curr = IME.ExchangeRates.Where(a => a.currencyId == cb).OrderByDescending(b => b.date).FirstOrDefault();

            if (CurrValue1 != CurrValue) CurrValue1 = CurrValue;
            CurrValue = (decimal)curr.rate;
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurrency.SelectedIndex != null && cbCurrency.DataSource != null)
            {
                GetCurrency(dtpDate.Value);
                ChangeCurr();

            }

        }

        private void ChangeCurr(int rowindex)
        {
            if (dgSaleAddedItems.Rows[rowindex].Cells["dgQty"].Value != null)
            {

                dgSaleAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = ((Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value.ToString())) / Currfactor).ToString();
                dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = ((Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString())) / Currfactor).ToString();
                dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value = ((Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())) / Currfactor).ToString();
                var st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                if (st != null)
                {
                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) - st.Item2).ToString();
                    SubTotal.Remove(st);

                    int subtotalcol1 = 0;
                    if (dgSaleAddedItems.Rows[rowindex].Cells[0].Value != null) subtotalcol1 = Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString());
                    SubTotal.Add(new Tuple<int, decimal>(subtotalcol1, Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())));
                    st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st.Item2).ToString();
                }
                else
                {
                    int subtotalcol1 = 0;
                    if (dgSaleAddedItems.Rows[rowindex].Cells[0].Value != null) subtotalcol1 = Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString());
                    SubTotal.Add(new Tuple<int, decimal>(subtotalcol1, Decimal.Parse(dgSaleAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())));
                    st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgSaleAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st.Item2).ToString();
                }
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
                    dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = ((Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString())) / Currfactor).ToString();
                    dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value = ((Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString())) / Currfactor).ToString();
                    dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value = ((Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())) / Currfactor).ToString();
                    var st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()))).FirstOrDefault();
                    SubTotal.Remove(st);
                    SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()), Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())));
                    st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString()))).FirstOrDefault();
                    SubTotalTotal += st.Item2;
                }
                #endregion
            }
            lblsubtotal.Text = SubTotalTotal.ToString();
            lblCurrValue.Text = String.Format("{0:0.0000}", CurrValue);
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
            //List<Quotation> quotList = IME.Quotations.Where(q => q.QuotationNo == DateTime.Now.Year).toList();
            //int ID;
            Quotation quo = IME.Quotations.OrderByDescending(q => q.QuotationNo).FirstOrDefault();
            string q1;
            if (quo == null)
            {
                q1 = DateTime.Now.Year.ToString() + "/1";
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

                        q1 = DateTime.Now.Year.ToString() + "/" + quoID.ToString();
                    }
                }
            }
            return q1;
        }

        private void btnCreateRev_Click(object sender, EventArgs e)
        {
            try
            {
                //string newID = NewQuotationID();
                //if (txtQuotationNo.Text != newID) { txtQuotationNo.Text = newID; }
                if (ControlSave())
                {
                    QuotationSave(txtSaleOrderNo.Text);
                    QuotationDetailsSave();
                }
            }
            catch
            {
                MessageBox.Show("Error Occured", "Failure");
            }
        }

        private void CustomerCode_MouseDoubleClick(object sender, MouseEventArgs e)
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
            int row = dgSaleAddedItems.CurrentCell.RowIndex;
            while (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells[currindex].ReadOnly == true)
            {
                if (currindex == dgSaleAddedItems.ColumnCount - 2)
                {
                    if (currindex == 14 && dgSaleAddedItems.Rows[row].Cells[14].Value == null) break;
                    if (dgSaleAddedItems.RowCount - 1 == row && dgSaleAddedItems.CurrentRow.Cells["dgDesc"].Value != null)
                    {
                        DataGridViewRow dgRow = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                        dgSaleAddedItems.Rows.Add(dgRow);
                    }
                    currindex = 6;
                    row++;
                }
                else
                {
                    if (currindex == 14 && dgSaleAddedItems.Rows[row].Cells[14].Value == null) break;
                    currindex++;
                }
            }

            dgSaleAddedItems.CurrentCell = dgSaleAddedItems.Rows[row].Cells[currindex];

        }

        private void ChangeCurrnetCellTabKey(int currindex)
        {
            int row = dgSaleAddedItems.CurrentCell.RowIndex;
            while (dgSaleAddedItems.Rows[dgSaleAddedItems.CurrentCell.RowIndex].Cells[currindex].ReadOnly == true)
            {
                if (currindex == dgSaleAddedItems.ColumnCount - 1)
                {

                    if (dgSaleAddedItems.RowCount - 1 == row && dgSaleAddedItems.CurrentRow.Cells["dgDesc"].Value != null)
                    {
                        DataGridViewRow dgRow = (DataGridViewRow)dgSaleAddedItems.RowTemplate.Clone();
                        dgSaleAddedItems.Rows.Add(dgRow);
                    }
                    currindex = 6;
                    row++;
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

        private void dgQuotationAddedItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
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
                foreach (DataGridViewRow item in dgSaleAddedItems.SelectedRows)
                {
                    int rownumber = Int32.Parse(dgSaleAddedItems.Rows[item.Index].Cells["dgNo"].Value.ToString());
                    dgSaleDeleted.Rows.Add();
                    for (int i = 0; i < dgSaleAddedItems.Columns.Count - 1; i++)
                    {
                        dgSaleDeleted.Rows[dgSaleDeleted.Rows.Count - 2].Cells[i].Value = item.Cells[i].Value;
                    }

                    var st = SubTotal.Where(a => a.Item1 == rownumber).FirstOrDefault();
                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) - st.Item2).ToString();
                    SubDeletingTotal.Add(new Tuple<int, decimal>(rownumber, SubTotal.Where(a => a.Item1 == rownumber).FirstOrDefault().Item2));
                    SubTotal.Remove(st);
                    SubTotal.Add(new Tuple<int, decimal>(rownumber, 0));

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
            }
        }

        private void btnContactUpdate_Click(object sender, EventArgs e)
        {
            if (CustomerCode.Text == null)
            {
                MessageBox.Show("Customer not selected !", "Eror !");
            }
            else
            {
                CustomerMain f = new CustomerMain(1, CustomerCode.Text);
                f.ShowDialog();
            }

        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.Export(dgSaleAddedItems, txtSaleOrderNo.Text);
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != null && textBox10.Text != "")
            {
                decimal sonuc = Decimal.Parse(textBox10.Text);
                textBox10.Text = sonuc.ToString();
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text != null && textBox10.Text != "")
            {
                decimal sonuc = Decimal.Parse(textBox10.Text);
                sonuc = Math.Round(sonuc, 4);
                textBox10.Text = sonuc.ToString();
            }
        }

        private void txtTotalMargin_Click(object sender, EventArgs e)
        {
            if (txtTotalMargin.Text != null && txtTotalMargin.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtTotalMargin.Text);
                txtTotalMargin.Text = sonuc.ToString();
            }
        }

        private void txtTotalMargin_Leave(object sender, EventArgs e)
        {
            if (txtTotalMargin.Text != null && txtTotalMargin.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtTotalMargin.Text);
                sonuc = Math.Round(sonuc, 4);
                txtTotalMargin.Text = sonuc.ToString();
            }
        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != null && textBox11.Text != "")
            {
                decimal sonuc = Decimal.Parse(textBox11.Text);
                textBox11.Text = sonuc.ToString();
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text != null && textBox11.Text != "")
            {
                decimal sonuc = Decimal.Parse(textBox11.Text);
                sonuc = Math.Round(sonuc, 4);
                textBox11.Text = sonuc.ToString();
            }
        }

        private void lblsubtotal_Click(object sender, EventArgs e)
        {
            if (lblsubtotal.Text != null && lblsubtotal.Text != "")
            {
                decimal sonuc = Decimal.Parse(lblsubtotal.Text);
                lblsubtotal.Text = sonuc.ToString();
            }
        }

        private void lblsubtotal_Leave(object sender, EventArgs e)
        {
            if (lblsubtotal.Text != null && lblsubtotal.Text != "")
            {
                decimal sonuc = Decimal.Parse(lblsubtotal.Text);
                sonuc = Math.Round(sonuc, 4);
                lblsubtotal.Text = sonuc.ToString();
            }
        }

        private void txtTotalDis2_Leave(object sender, EventArgs e)
        {
            if (lblsubtotal.Text != null & lblsubtotal.Text != string.Empty)
            {
                if (txtTotalDis2.Text == null || txtTotalDis2.Text == "") txtTotalDis2.Text = "0";
                decimal totaldis = (Decimal.Parse(txtTotalDis2.Text) * 100) / decimal.Parse(lblsubtotal.Text);
                txtTotalDis.Text = totaldis.ToString();
                lbltotal.Text = (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString();
                getTotalDiscMargin();
                if (txtTotalMarge.Visible == true) txtTotalMarge.Text = calculateTotalMargin().ToString();
            }
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
                    txtTotalDis2.Text = dis2.ToString();
                    lbltotal.Text = (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString();
                }
                getTotalDiscMargin();
                if (txtTotalMarge.Visible == true) txtTotalMarge.Text = calculateTotalMargin().ToString();
            }
        }

        private decimal calculateTotalMargin()
        {
            decimal total = 0;
            decimal subtotal = 1;
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value != null && dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString() != string.Empty)
                {
                    decimal margin = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value.ToString());
                    decimal price = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());
                    total = total + (margin * price);
                }
            }
            if (decimal.Parse(lblsubtotal.Text) != 0) subtotal = (decimal.Parse(lblsubtotal.Text));
            return total / subtotal;
        }

        private void getTotalDiscMargin()
        {
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                if (dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value != null && dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString() != string.Empty)
                {
                    decimal cost = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString());
                    decimal UCUPCur = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                    decimal disc = 0;
                    if (txtTotalDis.Text != string.Empty && txtTotalDis.Text != null) disc = decimal.Parse(txtTotalDis.Text);
                    UCUPCur = UCUPCur * (1 - (disc / 100));
                    dgSaleAddedItems.Rows[i].Cells["dgMargin"].Value = (1 - (cost / UCUPCur)) * 100;
                }
            }
        }

        private void txtExtraChanges_TextChanged(object sender, EventArgs e)
        {
            decimal ExtraCharge = 0;

            try { ExtraCharge = Decimal.Parse(txtExtraCharges.Text); } catch { }
            lblTotalExtra.Text = (ExtraCharge + Decimal.Parse(lbltotal.Text)).ToString();
        }

        private void txtExtraChanges_Leave(object sender, EventArgs e)
        {
            if (txtExtraCharges.Text != null && txtExtraCharges.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtExtraCharges.Text);
                sonuc = Math.Round(sonuc, 4);
                txtExtraCharges.Text = sonuc.ToString();
            }
        }

        private void txtExtraChanges_Click(object sender, EventArgs e)
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

        private void dgQuotationAddedItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                string ArticleNO = null;
                if (dgSaleAddedItems.CurrentCell.Value != null) ArticleNO = dgSaleAddedItems.CurrentCell.Value.ToString();
                FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(ArticleNO);
                itemsearch.ShowDialog();
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
                    var st = SubTotal.Where(a => a.Item1 == no).FirstOrDefault();
                    var st1 = SubDeletingTotal.Where(a => a.Item1 == no).FirstOrDefault();
                    if (st != null)
                    {
                        SubTotal.Remove(st);
                        if (st1 != null)
                        {
                            SubTotal.Add(new Tuple<int, decimal>(no, st1.Item2));
                            lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st1.Item2).ToString();
                            SubDeletingTotal.Remove(st1);
                        }
                    }
                    int rowindex1 = dgSaleAddedItems.RowCount;
                    dgSaleAddedItems.Rows.Add();
                    for (int i = 0; i < dgSaleDeleted.Columns.Count; i++)
                    {
                        dgSaleAddedItems.Rows[rowindex1].Cells[i].Value = dgSaleDeleted.Rows[item.Index].Cells[i].Value;
                    }
                    dgSaleDeleted.Rows.Remove(dgSaleDeleted.Rows[rowindex]);

                }
                else { MessageBox.Show("Please choose an item to add Quotation"); }
            }
            //dgQuotationAddedItems.Sort()
            for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
            {
                dgSaleAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgSaleAddedItems.Rows[i].Cells[0].Value.ToString());
            }
            dgSaleAddedItems.Sort(dgSaleAddedItems.Columns[0], ListSortDirection.Ascending);
        }

        private void cbDeliverDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeliverDiscount.Checked)
            {
                for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                {
                    if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value != null)
                    {
                        decimal total = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());
                        decimal disc = 0;
                        if (txtTotalDis.Text != null && txtTotalDis.Text != string.Empty) disc = Decimal.Parse(txtTotalDis.Text);
                        //discValue = total - (total * (1 - (disc / 100)));
                        //total = total - discValue;
                        total = (total * (1 - (disc / 100)));
                        dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value = total.ToString();
                        dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = (total / Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString();
                        decimal UCIME = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()) * Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                        dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value = (100 - (100 * total / UCIME)).ToString();
                    }
                }
            }
            else
            {
                for (int i = 0; i < dgSaleAddedItems.RowCount; i++)
                {
                    if (dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value != null)
                    {
                        decimal total = 0;
                        decimal lasttotal = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());
                        decimal disc = 0;
                        if (txtTotalDis.Text != null && txtTotalDis.Text != string.Empty) disc = Decimal.Parse(txtTotalDis.Text);
                        total = lasttotal / (1 - (disc / 100));
                        dgSaleAddedItems.Rows[i].Cells["dgTotal"].Value = total.ToString();
                        dgSaleAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = (total / Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString();
                        decimal UCIME = Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()) * Decimal.Parse(dgSaleAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                        dgSaleAddedItems.Rows[i].Cells["dgDisc"].Value = (100 - (100 * total / UCIME)).ToString();
                    }
                }
            }
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

        private void btnDeliveryContactAdd_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(1, CustomerCode.Text);
            f.ShowDialog();
        }

        private void btnInvoiceAdd_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(2, CustomerCode.Text);
            f.ShowDialog();
        }
    }
}
