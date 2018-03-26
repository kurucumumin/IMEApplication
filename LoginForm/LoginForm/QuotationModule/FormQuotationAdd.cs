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
    public partial class FormQuotationAdd : Form
    {
        #region Definitions
        GetWorkerService GetWorkerService = new GetWorkerService();
        DataTable TotalCostList = new DataTable();

        IMEEntities IME = new IMEEntities();
        decimal price;
        List<Tuple<int, decimal>> SubTotal = new List<Tuple<int, decimal>>();
        List<Tuple<int, decimal>> SubDeletingTotal = new List<Tuple<int, decimal>>();
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
        decimal round = 0;
        decimal sonuc = 0;
        decimal sayac = 0;
        //ExchangeRate exchangeRate;
        #endregion

        public FormQuotationAdd()
        {
            InitializeComponent();
            dtpDate.Value = Convert.ToDateTime(IME.CurrentDate().First());
            dtpDate.Enabled = false;
        }

        public FormQuotationAdd(string item_code)
        {
            InitializeComponent();

            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                dgQuotationAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgQuotationAddedItems.DefaultCellStyle;

                GetMarginMark(i);
            }
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                QuotataionModifyItemDetailsFiller(item_code, i);

            }
        }

        public FormQuotationAdd(Quotation quotation)
        {
            InitializeComponent();


            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[dgDelivery.Index];

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
            cbPayment.DataSource = IME.PaymentMethods.ToList();
            cbPayment.DisplayMember = "Payment";
            cbPayment.ValueMember = "ID";
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";
            cbWorkers.DataSource = IME.CustomerWorkers.Where(a => a.customerID == q1.CustomerID).ToList();
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
            if (q1.QuotationMainContact != null) cbWorkers.SelectedIndex = (int)q1.QuotationMainContact;
            CustomerCode.Enabled = false;
            txtCustomerName.Enabled = false;
            btnSave.Enabled = false;
            LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
            modifyQuotation(q1);
            //cbCurrency.SelectedValue=

            //fillCustomer();
            cbSMethod.SelectedIndex = (int)q1.ShippingMethodID;
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                dgQuotationAddedItems.Rows[i].Cells["dgQty"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgDelivery"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Style = dgQuotationAddedItems.DefaultCellStyle;

                dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].ReadOnly = false;
                dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Style = dgQuotationAddedItems.DefaultCellStyle;

                GetMarginMark(i);
            }
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                QuotataionModifyItemDetailsFiller(dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString(), i);

            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1125).FirstOrDefault() == null)
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
            ControlAutorization();
            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[dgDelivery.Index];
            if (deliveryColumn.DataSource==null)
            {
                deliveryColumn.DataSource = IME.QuotationDeliveries.ToList();
                deliveryColumn.DisplayMember = "DeliveryName";
                deliveryColumn.ValueMember = "ID";
                
            }

            if (txtCustomerName.Text == null || txtCustomerName.Text == "")
            {
                btnContactAdd.Enabled = false;
                btnContactUpdate.Enabled = false;
            }

            TotalCostList.Columns.Add("dgNo",typeof(int));
            TotalCostList.Columns.Add("cost", typeof(decimal));
            List<string> quotationVisibleFalseNames = QuotationDatagridCustomize.VisibleFalseNames;
            ;
            foreach (var item in quotationVisibleFalseNames)
            {
                dgQuotationAddedItems.Columns[item].Visible = false;
            }
            DeletedQuotationMenu.MenuItems.Add(new MenuItem("Add to Quotation", DeletedQuotationMenu_Click));
            if (!modifyMod)
            {

                DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                dgQuotationAddedItems.Rows.Add(dgRow);
                txtQuotationNo.Text = NewQuotationID();
                //dgQuotationAddedItems.Rows[0].Cells["dgQty"].Value = "0";
                dgQuotationAddedItems.Rows[0].Cells[0].Value = 1.ToString();
                LowMarginLimit = Decimal.Parse(IME.Managements.FirstOrDefault().LowMarginLimit.ToString());
                lblVat.Text = Utils.getManagement().VAT.ToString();
                #region ComboboxFiller.


                dtpDate.Value = Convert.ToDateTime(IME.CurrentDate().First());
                cbPayment.DataSource = IME.PaymentMethods.ToList();
                cbPayment.DisplayMember = "Payment";
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
            if (txtCustomerName.Text != null || txtCustomerName.Text != "")
            {
                btnContactAdd.Enabled = true;
                btnContactUpdate.Enabled = true;
            }

            if (!modifyMod)
            {
                CustomerCode.Text = classQuotationAdd.customerID;
                txtCustomerName.Text = classQuotationAdd.customername;
            }
            var c = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();
            if (c != null)
            {
                txtCustomerName.Text = c.c_name;
                if(c.CurrNameQuo!=null) cbCurrency.SelectedValue = cbCurrency.FindStringExact(c.CurrNameQuo);
                //cbCurrType.SelectedIndex = cbCurrType.FindStringExact(c.CurrTypeQuo);
                //if(c.MainContactID!=null) cbWorkers.SelectedIndex = (int)c.MainContactID;
                if (c.paymentmethodID != null)
                {
                    cbPayment.SelectedIndex = cbPayment.FindStringExact(c.PaymentMethod.Payment);
                }
                try { txtContactNote.Text = c.CustomerWorker.Note.Note_name; } catch { }
                try { txtCustomerNote.Text = c.Note.Note_name; } catch { }
                try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == c.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
                if (c.Worker != null) cbRep.SelectedValue = c.Worker.WorkerID;
                cbCurrency.SelectedItem = cbCurrency.FindStringExact(c.CurrNameQuo);
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
            switch (dgQuotationAddedItems.CurrentCell.ColumnIndex)
            {
                case 0:
                    #region ID Atama
                    if (Int32.Parse(dgQuotationAddedItems.CurrentCell.Value.ToString()) <= Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[0].Value.ToString()))
                    {
                        int currentID = dgQuotationAddedItems.CurrentCell.RowIndex;
                        List<int> Quotation = new List<int>();
                        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                        {
                            Quotation.Add(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()));
                        }
                        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                        {
                            if (dgQuotationAddedItems.CurrentCell.RowIndex < Int32.Parse(dgQuotationAddedItems.CurrentCell.Value.ToString()))
                            {
                                #region RowChange1
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()) <= Int32.Parse(dgQuotationAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgQuotationAddedItems.CurrentCell.RowIndex < i)
                                {
                                    if (i <= Quotation.Count)
                                    {

                                        dgQuotationAddedItems.Rows[i].Cells[0].Value = (i);
                                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                                        decimal stPrice = 0;
                                        if (st != null) { stPrice = st.Item2; }
                                        SubTotal.Remove(st);
                                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()), stPrice));
                                    }
                                }
                                else { dgQuotationAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()); }
                                #endregion
                            }
                            else
                            {
                                #region RowChange2
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()) >= Int32.Parse(dgQuotationAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgQuotationAddedItems.CurrentCell.RowIndex > i)
                                {
                                    if (i <= Quotation.Count)
                                    {
                                        dgQuotationAddedItems.Rows[i].Cells[0].Value = (i + 2);
                                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                                        decimal stPrice = 0;
                                        if (st != null) { stPrice = st.Item2; }
                                        SubTotal.Remove(st);
                                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()), stPrice));
                                    }

                                }
                                else { dgQuotationAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()); }
                                #endregion
                            }

                        }
                    }
                    #endregion
                    // if (dataGridView3.CurrentCell.RowIndex != 0) { dataGridView3.CurrentCell.Value = (dataGridView3.CurrentCell.RowIndex + 1).ToString(); }
                    dgQuotationAddedItems.Sort(dgQuotationAddedItems.Columns["dgNo"], ListSortDirection.Ascending);
                    break;
                case 7://PRODUCT CODE
                    {
                        #region PRODUCT CODE

                        if (dgQuotationAddedItems.CurrentCell.Value != null)
                        {
                            #region Itemcode Format
 if (dgQuotationAddedItems.CurrentCell.Value.ToString().Contains("-")) { dgQuotationAddedItems.CurrentCell.Value = dgQuotationAddedItems.CurrentCell.Value.ToString().Replace("-", string.Empty).ToString(); }
                            if (dgQuotationAddedItems.CurrentCell.Value != null && dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 6 || (dgQuotationAddedItems.CurrentCell.Value.ToString().Contains("P") && dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 7)) { dgQuotationAddedItems.CurrentCell.Value = 0.ToString() + dgQuotationAddedItems.CurrentCell.Value.ToString(); }
                            //0100-124 => 0100124
                            #endregion
                            string itemCode = dgQuotationAddedItems.CurrentCell.Value.ToString();
                            if (IME.ArticleSearchCheckExistence(dgQuotationAddedItems.CurrentCell.Value.ToString()).ToList()[0] >0)
                            {
                                if (IME.ArticleSearchHasMultipleItems(dgQuotationAddedItems.CurrentCell.Value.ToString()).ToList()[0] ==1)
                                {
                                    if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
                                    #region MyRegion

                                    //var MPNList = IME.ArticleSearchWithAll(itemCode);
                                    //burası yeniden yazılacak
                                    //dynamic MPNList;
                                    //if (IME.SuperDisks.Where(a => a.Article_No == itemCode).FirstOrDefault() == null)
                                    //{
                                    //    MPNList = IME.ArticleSearchwithMPN(itemCode);
                                    //}
                                    //else
                                    //{
                                    //    var sdP1 = IME.SuperDiskPs.Where(a => a.Article_No == itemCode).FirstOrDefault();
                                    //    if (sdP1 == null)
                                    //    {
                                    //        MPNList = IME.ArticleSearch(itemCode);
                                    //    }
                                    //    else
                                    //    {
                                    //        var er1 = IME.ExtendedRanges.Where(a => a.ArticleNo == itemCode).FirstOrDefault();
                                    //        if (er1 == null)
                                    //        {
                                    //            MPNList = IME.ArticleSearch(itemCode);
                                    //        }
                                    //    }
                                    //}
                                    #endregion
                                    bool isdiscontunied =Discontinued(dgQuotationAddedItems.CurrentCell.Value.ToString());
                                    if (isdiscontunied==false)
                                    {
                                        ItemDetailsFiller(dgQuotationAddedItems.CurrentCell.Value.ToString());
                                        //LandingCost Calculation
                                        FillProductCodeItem();
                                        dgQuotationAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                                        dgQuotationAddedItems.CurrentRow.Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;

                                    }
                                }
                                else
                                {

                                    this.Enabled = false;
                                    FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(dgQuotationAddedItems.CurrentCell.Value.ToString());
                                    itemsearch.ShowDialog();
                                    //Bu item daha önceden eklimi diye kontrol ediyor
                                    DataGridViewRow row = dgQuotationAddedItems.Rows
           .Cast<DataGridViewRow>()
           .Where(r => r.Cells["dgProductCode"].Value.ToString().Equals(classQuotationAdd.ItemCode))
           .FirstOrDefault();
                                        if (row!=null &&row.Cells["dgUCUPCurr"].Value != null)
                                        {
                                            if (row != null) MessageBox.Show("There is already an item added this qoutation in the " + row.Cells["dgNo"].Value.ToString() + ". Row and the price " + row.Cells["dgUCUPCurr"].Value.ToString());

                                        }
                                        //else
                                        //{
                                        //    if (row != null) MessageBox.Show("There is already an item added this qoutation in the " + row.Cells["dgNo"].Value.ToString() + ". Row");

                                        //}
                                    if(classQuotationAdd.ItemCode!=null)dgQuotationAddedItems.CurrentCell.Value = classQuotationAdd.ItemCode;
                                    if (IME.ArticleSearchCheckExistence(dgQuotationAddedItems.CurrentCell.Value.ToString()).ToList()[0] > 0)
                                    {
                                        if (classQuotationAdd.HasMultipleItems(dgQuotationAddedItems.CurrentCell.Value.ToString()) == 0)
                                        {
                                            if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
                                            Discontinued(dgQuotationAddedItems.CurrentCell.Value.ToString());
                                            bool isdiscontunied = Discontinued(dgQuotationAddedItems.CurrentCell.Value.ToString());
                                            if (isdiscontunied == false)
                                            {
                                                ItemDetailsFiller(dgQuotationAddedItems.CurrentCell.Value.ToString());
                                                //LandingCost Calculation
                                                FillProductCodeItem();
                                                dgQuotationAddedItems.CurrentRow.Cells["dgQty"].ReadOnly = false;
                                                dgQuotationAddedItems.CurrentRow.Cells["dgQty"].Style = dgQuotationAddedItems.DefaultCellStyle;
                                                #region DataGridClear
                                                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value = null;
                                                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgDisc"].Value = null;
                                                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
                                                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUPIME"].Value = null;
                                                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
                                                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value = null;

                                                CalculateSubTotal();
                                                txtSubstitutedBy.Text = null;
                                            }
                                            #endregion
                                        }

                                    }

                                    if (dgQuotationAddedItems.CurrentCell.ColumnIndex == 7)
                                    {
                                        int i=8;
                                        while(dgQuotationAddedItems.CurrentRow.Cells[i].Visible==false)
                                        {
                                            i++;
                                        }
                                        dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentRow.Index].Cells[i];
                                        dgQuotationAddedItems.Select();
                                        ChangeCurrnetCellTabKey(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
                                    }

                                    this.Enabled = true;
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
                    if (dgQuotationAddedItems.CurrentRow.Cells["dgDesc"].Value != null) ChangeCurrnetCell(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
                    break;
                case 14://QAUANTITY
                    #region Quantity
                    {

                            if (LandingCost.Enabled == false) LandingCost.Enabled = true;
                            GetQuotationQuantity(dgQuotationAddedItems.CurrentCell.RowIndex);

                            dgQuotationAddedItems.CurrentRow.Cells["dgUCUPCurr"].ReadOnly = false;
                            dgQuotationAddedItems.CurrentRow.Cells["dgUCUPCurr"].Style = dgQuotationAddedItems.DefaultCellStyle;

                            dgQuotationAddedItems.CurrentRow.Cells["dgTargetUP"].ReadOnly = false;
                            dgQuotationAddedItems.CurrentRow.Cells["dgTargetUP"].Style = dgQuotationAddedItems.DefaultCellStyle;

                            dgQuotationAddedItems.CurrentRow.Cells["dgCompetitor"].ReadOnly = false;
                            dgQuotationAddedItems.CurrentRow.Cells["dgCompetitor"].Style = dgQuotationAddedItems.DefaultCellStyle;

                            dgQuotationAddedItems.CurrentRow.Cells["dgDelivery"].ReadOnly = false;
                            dgQuotationAddedItems.CurrentRow.Cells["dgDelivery"].Style = dgQuotationAddedItems.DefaultCellStyle;

                            dgQuotationAddedItems.CurrentRow.Cells["dgCustStkCode"].ReadOnly = false;
                            dgQuotationAddedItems.CurrentRow.Cells["dgCustStkCode"].Style = dgQuotationAddedItems.DefaultCellStyle;

                            dgQuotationAddedItems.CurrentRow.Cells["dgCustDescription"].ReadOnly = false;
                            dgQuotationAddedItems.CurrentRow.Cells["dgCustDescription"].Style = dgQuotationAddedItems.DefaultCellStyle;

                        }
                    if (dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value != "")
                    {
                        //LOW MARGIN
                        if (dgQuotationAddedItems.CurrentRow.Cells["dgQty"].Value != null && Decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells["dgQty"].Value.ToString()) > 0) { GetMarginMark(); }

                    }

                    break;
                #endregion
                case 21://Total
                    {
                        //TO DO depends on authority
                        //if (dgQuotationAddedItems.CurrentRow.Cells[dgHZ.Index].Style.BackColor == Color.White)
                        if (txtHazardousInd.Text == "N")
                        {
                            #region Total
                            decimal total = decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString());
                            decimal UcupIME = decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString());
                            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgDisc"].Value = String.Format("{0:0.0000}", ((UcupIME - total) * (decimal)100 / UcupIME));
                            GetMargin();
                            GetMarginMark();
                            #region Calculate Total Margin
                            try
                            {
                                Decimal TotalMarginValue = Decimal.Parse(txtTotalMargin.Text) * (Decimal.Parse(lblsubtotal.Text) - Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString()));
                                TotalMarginValue = (TotalMarginValue + (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString()) * Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString()))) / Decimal.Parse(lblsubtotal.Text);
                                txtTotalMargin.Text = String.Format("{0:0.0000}", TotalMarginValue).ToString();
                            }
                            catch
                            {
                                txtTotalMargin.Text = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString())).ToString();
                            }
                            #endregion
                            CalculateSubTotal();
                            #endregion
                        }
                        else if(txtHazardousInd.Text == "Y")
                        {
                            dgQuotationAddedItems.CurrentRow.Cells[dgUCUPCurr.Index].Value = dgQuotationAddedItems.CurrentRow.Cells[dgUPIME.Index].Value.ToString();
                            MessageBox.Show("Hazardous item's price cannot be chanced");
                        }
                    }
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
            if (dd!=null&& Convert.ToDateTime(dd.DiscontinuationDate) < Convert.ToDateTime(IME.CurrentDate().First()).AddDays(90))
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
            if (cbFactor.Text != null && cbFactor.Text != "")
            {
                #region Quantity
                if (dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value != null)
                {
                    if (classQuotationAdd.GetCost(dgQuotationAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()))!=0) {
                        #region Quantity
                        if (txtStandartWeight.Text != null && txtStandartWeight.Text != "")
                        {
                            txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();
                        }
                        //Cost hesaplama
                        dgQuotationAddedItems.Rows[rowindex].Cells["dgCost"].Value = classQuotationAdd.GetCost(dgQuotationAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString("G29");
                        //LandingCost hesaplatma
                        if (dgQuotationAddedItems.Rows[rowindex].Cells["dgCost"].Value.ToString() != "-1") { String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgCost"].Value.ToString())).ToString(); }
                        GetLandingCost(rowindex);
                        //  dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value.ToString())).ToString();
                        //TODO Math.Round
                        //dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value = Math.Round(Convert.ToDecimal(dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value.ToString()), 4);
                        decimal Currrate = 0;
                        if (curr.rate != null) Currrate = Decimal.Parse(curr.rate.ToString());
                        string productCode = dgQuotationAddedItems.Rows[rowindex].Cells[dgProductCode.Index].Value.ToString();
                        if (productCode.Substring(0, 1) == "0") productCode = productCode.Substring(1, productCode.Length - 1);
                        if (IME.Hazardous.Where(a => a.ArticleNo == productCode).FirstOrDefault() != null)
                        {
                            price = Decimal.Parse((classQuotationAdd.GetPrice(dgQuotationAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())) * (Utils.getManagement().Factor) / Currrate * Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString("G29"));
                        }
                        else
                        {
                            price = Decimal.Parse((classQuotationAdd.GetPrice(dgQuotationAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())) * Decimal.Parse(cbFactor.Text) / Currrate * Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString("G29"));
                        }
                        //price /= factor;
                        if (price > 0)
                        {
                            decimal discResult = 0;
                            //Fiyat burada
                            string articleNo = dgQuotationAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString();


                            dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = price / decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString());
                            dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = price;
                            //SuperdiskP değilse
                            if (articleNo.ToUpper().IndexOf('P') == -1 && Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()) > 1)
                            {
                                if ((Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString())) != 0)
                                {
                                    MessageBox.Show("Please enter a number that is a multiple of Unit Content");
                                    dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value = "";
                                    dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = "";
                                    dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = "";
                                }
                                else
                                {
                                    dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString()) / (decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()));
                                    dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = price / (decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()));
                                }

                            }
                            else if ((Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgSSM"].Value.ToString())) != 0)
                            {
                                MessageBox.Show("Please enter a number that is a multiple of SSM");
                                dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value = "";
                                dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = "";
                                dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = "";
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

                            if (dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value!="")
                            {
                                //TOTAL ve UPIME belirleniyor
                                discResult = decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString());
                                dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString())).ToString();
                                dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = String.Format("{0:0.0000}", dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value).ToString();
                                if (dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value != null)
                                {
                                    dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value.ToString())).ToString();
                                    discResult = (discResult - (discResult * decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value.ToString()) / 100));
                                }
                                dgQuotationAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = String.Format("{0:0.0000}", discResult).ToString();

                                //Change lblsubtotal
                                var st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                                if (st != null)
                                {
                                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) - st.Item2).ToString();
                                    SubTotal.Remove(st);

                                    int subtotalcol1 = 0;
                                    if (dgQuotationAddedItems.Rows[rowindex].Cells[0].Value != null) subtotalcol1 = Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString());
                                    SubTotal.Add(new Tuple<int, decimal>(subtotalcol1, Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())));
                                    st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st.Item2).ToString();
                                }
                                else
                                {
                                    int subtotalcol1 = 0;
                                    if (dgQuotationAddedItems.Rows[rowindex].Cells[0].Value != null) subtotalcol1 = Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString());
                                    SubTotal.Add(new Tuple<int, decimal>(subtotalcol1, Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())));
                                    st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st.Item2).ToString();
                                }

                                //ChangeCurr(rowindex);
                                if (dgQuotationAddedItems.CurrentCell == null) dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[rowindex].Cells[0];
                                GetMargin();
                                dgQuotationAddedItems.Rows[rowindex].Cells["dgMargin"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgMargin"].Value.ToString())).ToString();
                                if (dgQuotationAddedItems.CurrentRow.Cells["dgUnitWeigt"].Value != null && dgQuotationAddedItems.CurrentRow.Cells["dgUnitWeigt"].Value != "") dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgTotalWeight"].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();

                                txtTotalMargin.Text = String.Format("{0:0.0000}", calculateTotalMargin()).ToString();
                            }
                            //else { MessageBox.Show("This product does not have price"); }
                        }
                        #endregion

                    }
                    else
                    {
                        MessageBox.Show("This product does not have cost");
                        dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Value = "0";
                    }
                }
                #endregion
            }
            txtTotalMarge.Text = txtTotalMarge.Text = calculateTotalMargin().ToString();

            txtTotalMarge.Text = String.Format("{0:0.0000}", Decimal.Parse(txtTotalMarge.Text)).ToString();
            calculateTotalCost();
        }


        private void calculateTotalCost()
        {
            try {
                decimal totalCost = 0;
                for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                {
                    decimal LandingCost = 0;
                    decimal Quantity = 0;
                    LandingCost = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString());
                    Quantity = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgQty.Index].Value.ToString());
                    totalCost += (LandingCost * Quantity);
                }
                decimal PoundRate = 0;
                decimal CurrentRate = 0;
                 PoundRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a=>a.date).FirstOrDefault().rate;
                CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.currencyId == (decimal)cbCurrency.SelectedValue).OrderByDescending(a => a.date).FirstOrDefault().rate;
                totalCost = totalCost * PoundRate/(CurrentRate) ;
                txtTotalCost.Text = String.Format("{0:0.0000}", totalCost).ToString();
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
                }
                else
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LM"].Style.BackColor = Color.White;
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
                }
                else
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LM"].Style.BackColor = Color.White;
                }
            }
            catch { }
        }

        private void GetMargin()
        {
            #region Get Margin
            DateTime today = DateTime.Today;

            if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null && dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != "")
            {
                if (Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString()) > 1 || Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgSSM"].Value.ToString()) > 1)
                {
                    if(Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString()) > 1 && (!(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString().Contains("P"))))
                    {
                        dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString())*   decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString())  )))) * 100).ToString("G29");
                    }
                    else
                    {
                        dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");

                    }
                    //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
                    if (SubTotal.Where(a => a.Item1 == Int32.Parse(dgQuotationAddedItems.CurrentRow.Cells[0].Value.ToString())).FirstOrDefault() != null)
                    {
                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgQuotationAddedItems.CurrentRow.Cells[0].Value.ToString())).FirstOrDefault();
                        SubTotal.Remove(st);
                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.CurrentRow.Cells[0].Value.ToString()), Decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells["dgTotal"].Value.ToString())));
                    }
                    else
                    {
                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.CurrentRow.Cells[0].Value.ToString()), Decimal.Parse(dgQuotationAddedItems.CurrentRow.Cells["dgTotal"].Value.ToString())));
                    }
                }
                else
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())
                        ) / ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");

                }
            }
            #endregion
        }

        private void GetAllMargin()
         {
            #region Get Margin
            DateTime today = DateTime.Today;
            decimal total=0;
            decimal totalMargin=0;


            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                try
                {
                    if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null)
                    {
                        if (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value.ToString()) > 1 && (!(dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString().Contains("P"))))
                        {
                            dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()) * decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value.ToString()))))) * 100).ToString("G29");
                        }
                        else
                        {
                            decimal margin=0;
                            decimal UCUPCurr = 0;
                            decimal landingCost = 0;
                            UCUPCurr = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                            landingCost = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString());
                            margin = (1 - (landingCost/UCUPCurr))*100;
                            dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = margin;

                            total += Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                            totalMargin += (margin* total);
                            //dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = ((1 - (landingCost / (UCUPCurr))) * 100).ToString("G29");
                            //dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = (((1 - (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())
                            //   ) / ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");

                        }
                    }
                    if (SubTotal.Where(a => a.Item1 == Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault() != null)
                    {
                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                        SubTotal.Remove(st);
                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()), Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())));
                    }
                    else
                    {
                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()), Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())));
                    }
                }
                catch { }

            }
            if (total != 0)
            {
                txtTotalMarge.Text = (totalMargin / total).ToString();
                txtTotalMarge.Text = String.Format("{0:0.0000}", Decimal.Parse(txtTotalMarge.Text)).ToString();
            }
            #endregion
        }

        private void FillProductCodeItem()
        {
            #region FillProductCodeItem
            //dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.CurrentCell.Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked,
            //    Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQtr"].Value.ToString()))).ToString("G29");
            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgCCCNO"].Value = txtCCCN.Text;
            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgCOO"].Value = txtCofO.Text;
            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUnitWeigt"].Value = txtStandartWeight.Text;
            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgTotalWeight"].Value = txtGrossWeight.Text;
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
            decimal currID = (cbCurrency.SelectedItem as Currency).currencyID;
            currWeb = IME.ExchangeRates.Where(a=>a.Currency.currencyID==currID).OrderByDescending(b=>b.date).FirstOrDefault();
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
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgDesc"].Value = sd.Article_Desc;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgSSM"].Value = sd.Pack_Quantity.ToString();
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value = sd.Unit_Content.ToString();
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = sd.Unit_Measure;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMPN"].Value = sd.MPN;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgCL"].Value = sd.Calibration_Ind;
                dgQuotationAddedItems.CurrentRow.Cells["dgDependantTable"].Value = "sd";
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
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgDesc"].Value = sdP.Article_Desc;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgSSM"].Value = sdP.Pack_Quantity.ToString();
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value = sdP.Unit_Content.ToString();
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
                dgQuotationAddedItems.CurrentRow.Cells["dgDependantTable"].Value = "sdp";
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
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMPN"].Value = sdP.MPN;
                txtMHCodeLevel1.Text = sdP.MH_Code_Level_1;
                txtCCCN.Text = sdP.CCCN_No.ToString();
                txtHeight.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            }
            if (er != null)
            {
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgDesc"].Value = er.ArticleDescription;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = er.UnitofMeasure;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMPN"].Value = er.MPN;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgSSM"].Value = er.PackSize;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value = er.SalesUoM;
                dgQuotationAddedItems.CurrentRow.Cells["dgDependantTable"].Value = "ext";


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
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
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
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtSupersectionName.Text = sp.SupersectionName;
            }
            if (h != null)
            {
                if (h.Environment != null) { txtEnvironment.Text = "Y"; } else { txtEnvironment.Text = ""; }
                txtLithium.Text = (h.Lithium != null && h.Lithium != String.Empty) ? "Y" : "";
                txtShipping.Text = (h.Shipping != null && h.Shipping != String.Empty) ? "Y" : "";
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
            if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value == "" && dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUC"].Value != null) { dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUOM"].Value = "Each"; }
            #region ItemMarginFiller
            string articleNo = dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString();
            SlidingPrice sp1 = IME.SlidingPrices.Where(a => a.ArticleNo == articleNo).FirstOrDefault();
            int quantity = 0;
            if (sp1 != null) { quantity = Int32.Parse(sp1.Col1Break.ToString()); } else {if(er!=null) quantity = Int32.Parse(er.Col1Break.ToString()); }
            if (quantity!=0) {
                txtMargin1.Text = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
    , quantity)).ToString("G29");
                txtMargin1.Text = ((1 - ((Decimal.Parse(txtMargin1.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();

                int quantity2 = 0;
                if (sp1 != null) { quantity2 = Int32.Parse(sp1.Col2Break.ToString()); } else { quantity2 = Int32.Parse(er.Col2Break.ToString()); }

                txtMargin2.Text = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
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
                    try { txtMargin3.Text = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked, Int32.Parse(sp1.Col3Break.ToString()))).ToString("G29");
                    if (Decimal.Parse(txtWeb3.Text) != 0) txtMargin3.Text = ((1 - ((Decimal.Parse(txtMargin3.Text)) / (decimal.Parse(txtWeb3.Text)))) * 100).ToString();
                    if (sp1.Col4Break != 0)
                    {
                        txtMargin4.Text = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                    , Int32.Parse(sp1.Col4Break.ToString()))).ToString("G29");
                        txtMargin4.Text = ((1 - ((Decimal.Parse(txtMargin4.Text)) / (decimal.Parse(txtWeb4.Text)))) * 100).ToString();
                        if (sp1.Col5Break != 0)
                        {
                            txtMargin5.Text = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
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
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.Ivory;
                }
                else
                {
                    label64.BackColor = Color.White;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.White;
                }
                if (txtShipping.Text != "")
                {
                    label63.BackColor = Color.Red;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

                }
                else
                {
                    label63.BackColor = Color.White;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.White;
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
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Green;
                }
                else
                {
                    label22.BackColor = Color.White;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.White;
                }

                if (txtLicenceType.Text != "" && txtLicenceType.Text != null)
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
                }
                else
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.White;
                }



                #endregion

            }
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
            txtGrossWeight.Text = "";
            try
            {
                if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
                {
                    txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())).ToString();
                }
            }
            catch { }

        }

        private void dgQuotationAddedItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgQuotationAddedItems.RowCount > 1) dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();
        }

        private void dgQuotationAddedItems_Click(object sender, EventArgs e)

        {
            ItemClear();
            try { ItemDetailsFiller(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString()); } catch { }
        }



        private void GetLandingCost(int Rowindex)
        {
            try
            {
                dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[Rowindex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                    )).ToString("G29");
                dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = String.Format("{0:0.0000}", dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value.ToString()).ToString();
            }
            catch { }

        }

        private void getQuotationValues()
        {
            if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
            {
                for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                {
                    if (dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                    {


                        GetLandingCost(i);
                        if (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString()) < Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgCost"].Value.ToString()))
                        {
                            dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value = dgQuotationAddedItems.Rows[i].Cells["dgCost"].Value.ToString();
                        }
                        GetAllMargin();
                        try
                        {
                            #region Get Margin
                            if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null)
                            {
                                dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
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
            if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value != null)
            {

                #region SubTotal Calculation
                int RowIndex = dgQuotationAddedItems.CurrentCell.RowIndex;
                int rowindexSubTotal = 0;
                if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value != null && dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value != "") Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value.ToString());
                var tuple = SubTotal.Where(a => a.Item1 == rowindexSubTotal).FirstOrDefault();
                if (tuple == null || tuple.Item2 == 0)
                {
                    if (dgQuotationAddedItems.Rows[RowIndex].Cells["dgTotal"].Value != null && dgQuotationAddedItems.Rows[RowIndex].Cells["dgTotal"].Value != "")
                    {
                        var tuple0 = new Tuple<int, decimal>(rowindexSubTotal, Decimal.Parse(dgQuotationAddedItems.Rows[RowIndex].Cells["dgTotal"].Value.ToString()));
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

                    if (dgQuotationAddedItems.Rows[RowIndex].Cells["dgQty"].Value != null && dgQuotationAddedItems.Rows[RowIndex].Cells["dgQty"].Value != "")
                    {
                        SubTotal.Add(new Tuple<int, decimal>(rowindexSubTotal, (Decimal.Parse(dgQuotationAddedItems.Rows[RowIndex].Cells["dgTotal"].Value.ToString()))));
                        dgQuotationAddedItems.Rows[RowIndex].Cells["dgTotal"].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString()) * Decimal.Parse(dgQuotationAddedItems.Rows[RowIndex].Cells["dgUCUPCurr"].Value.ToString())).ToString();
                    }
                    decimal total = 0;
                    try { total = decimal.Parse(dgQuotationAddedItems.Rows[RowIndex].Cells["dgTotal"].Value.ToString()); } catch { }
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
                if (dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value != null && Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value.ToString()) < Utils.getCurrentUser().MinMarge) { MessageBox.Show("Please Check Margin of Products "); return false; }
                if (Utils.getCurrentUser().MinMarge >decimal.Parse(txtTotalMarge.Text))
                {
                    MessageBox.Show("You are not able to give this Total Margin. Please check the Total Margin");
                    return false;
                }
            }
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
              if(((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgDelivery.Index]).Value==null)
                {
                    MessageBox.Show("Delivery part cannot be left blank. Please check Delivery Parts of Items");
                    return false;
                }
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
                QuotationSave();
                QuotationDetailsSave();
            }

            //}
            //catch { MessageBox.Show("Error Occured", "Failure"); }

        }

        private void QuotationSave()
        {
            DataSet.Quotation q = new DataSet.Quotation();
            string qNo = txtQuotationNo.Text;

            if(IME.Quotations.Where(a => a.QuotationNo == qNo).FirstOrDefault() != null)
            {
                NewQuotationID();
            }
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
            try { q.ExtraCharges = decimal.Parse(txtExtraChanges.Text); } catch { }
            if (chkVat.Checked) { q.IsVatValue = 1; } else { q.IsVatValue = 0; }
            try { q.VatValue = Decimal.Parse(lblVat.Text); } catch { }
            try { q.StartDate = dtpDate.Value; } catch { }
            try { q.Factor = Decimal.Parse(cbFactor.Text); } catch { }
            try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
            q.PaymentID = (cbPayment.SelectedItem as PaymentMethod).ID;
            q.CurrName = (cbCurrency.SelectedItem as Currency).currencyName;
            //q.CurrType = cbCurrType.Text;
            q.Curr = CurrValue;
            q.CustomerID = CustomerCode.Text;
            q.ShippingMethodID = cbSMethod.SelectedIndex;
            q.QuotationMainContact = cbWorkers.SelectedIndex;
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
            IME.Quotations.Add(q);
            IME.SaveChanges();
        }

        private void QuotationSave(string QuoNo)
        {
            IMEEntities IME = new IMEEntities();
            Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(QuoNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
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
            q.QuotationNo = txtQuotationNo.Text;
            q.RFQNo = txtRFQNo.Text;
            try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
            if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
            if (ckItemCost.Checked) { q.IsItemCost = 1; } else { q.IsItemCost = 0; }
            if (ckWeightCost.Checked) { q.IsWeightCost = 1; } else { q.IsWeightCost = 0; }
            if (ckCustomsDuties.Checked) { q.IsCustomsDuties = 1; } else { q.IsCustomsDuties = 0; }
            q.ShippingMethodID = cbSMethod.SelectedIndex;
            q.CurrencyID = (decimal)cbCurrency.SelectedValue;
            try { q.DiscOnSubTotal2 = decimal.Parse(txtTotalDis2.Text); } catch { }
            try { q.ExtraCharges = decimal.Parse(txtExtraChanges.Text); } catch { }
            if (chkVat.Checked) { q.IsVatValue = 1; } else { q.IsVatValue = 0; }
            try { q.VatValue = Decimal.Parse(lblVat.Text); } catch { }
            try { q.StartDate = dtpDate.Value; } catch { }
            try { q.Factor = Decimal.Parse(cbFactor.Text); } catch { }
            try { q.ValidationDay = Int32.Parse(txtValidation.Text); } catch { }
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
            IME = new IMEEntities();
            IME.Quotations.Add(q);
            IME.SaveChanges();
        }

        private void QuotationDetailsSave()
        {
            IMEEntities IME = new IMEEntities();
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                if (dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                {
                    QuotationDetail qd = new QuotationDetail();
                    qd.QuotationNo = txtQuotationNo.Text;
                    if (dgQuotationAddedItems.Rows[i].Cells["dgNo"].Value != null) qd.dgNo = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgNo"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgDesc"].Value != null) qd.CustomerDescription = dgQuotationAddedItems.Rows[i].Cells["dgDesc"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value != null) qd.ItemCode = dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null) qd.Qty = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUOM"].Value != null) qd.UnitOfMeasure = dgQuotationAddedItems.Rows[i].Cells["dgUOM"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value != null) qd.UCUPCurr = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value != null) qd.UPIME = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value != null) qd.Disc = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value != null) qd.Total = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value != null) qd.TargetUP = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value != null) qd.Competitor = dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value != null) qd.CustomerDescription = dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value != null) qd.CustomerStockCode = dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value.ToString();
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value != null) qd.UC = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUC"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgSSM"].Value != null) qd.SSM = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgSSM"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value != "") qd.UnitWeight = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUnitWeigt"].Value.ToString());
                    if (dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value != null) qd.Marge = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value.ToString());
                    if(dgQuotationAddedItems.Rows[i].Cells["dgDependantTable"].Value!=null) qd.DependantTable = dgQuotationAddedItems.Rows[i].Cells["dgDependantTable"].Value.ToString();

                    qd.quotationDeliveryID = (int)((DataGridViewComboBoxCell)dgQuotationAddedItems.Rows[i].Cells[dgDelivery.Index]).Value;

                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
                }

            }
            for (int i = 0; i < dgQuotationDeleted.RowCount; i++)
            {
                if (dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value != null)
                {
                    QuotationDetail qd = new QuotationDetail();

                    if (dgQuotationDeleted.Rows[i].Cells["No1"].Value != null) qd.dgNo = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["No1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgDesc1"].Value != null) qd.CustomerDescription = dgQuotationDeleted.Rows[i].Cells["dgDesc1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value != null) qd.ItemCode = dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgQty1"].Value != null) qd.Qty = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["dgQty1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgUCUPCurr1"].Value != null) qd.UCUPCurr = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgUCUPCurr1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgUOM1"].Value != null) qd.UnitOfMeasure = dgQuotationDeleted.Rows[i].Cells["dgUOM1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgDisc1"].Value != null) qd.Disc = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgDisc1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgUPIME1"].Value != null) qd.UCUPCurr = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgUPIME1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgTotal1"].Value != null) qd.Total = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgTotal1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgTargetUP1"].Value != null) qd.TargetUP = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgTargetUP1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgCompetitor1"].Value != null) qd.Competitor = dgQuotationDeleted.Rows[i].Cells["dgCompetitor1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgCustDescription1"].Value != null) qd.CustomerDescription = dgQuotationDeleted.Rows[i].Cells["dgCustDescription1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value != null) qd.CustomerStockCode = dgQuotationDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value.ToString();
                    if (dgQuotationDeleted.Rows[i].Cells["dgSSM1"].Value != null) qd.SSM = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["dgSSM1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgUC1"].Value != null) qd.UC = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["dgUC1"].Value.ToString());
                    if (dgQuotationDeleted.Rows[i].Cells["dgUnitWeigt1"].Value != null) qd.UnitWeight = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgUnitWeigt1"].Value.ToString());
                    qd.IsDeleted = 1;
                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
                }
            }
            MessageBox.Show("Quotation is successfully added", "Success");
            this.Close();
        }

        private void modifyQuotation(Quotation q)
        {
            #region QuotationLoader
            LandingCost.Enabled = true;
            txtQuotationNo.Text = q.QuotationNo;
            txtRFQNo.Text = q.RFQNo;
            CustomerCode.Text = q.Customer.ID;
            cbCurrency.SelectedValue = q.CurrencyID;
            cbFactor.Text = q.Factor.ToString();
            if (q.NoteForCustomerID != null) txtNoteForCustomer.Text = IME.Notes.Where(a => a.ID == q.NoteForCustomerID).FirstOrDefault().Note_name;
            if (q.NoteForCustomerID != null) txtNoteForUs.Text = IME.Notes.Where(a => a.ID == q.NoteForUsID).FirstOrDefault().Note_name;
            if (q.ForFinancelIsTrue == 1) { chkbForFinance.Checked = true; }
            fillCustomer();
            #region QuotationDetails
            //cbCurrType.SelectedItem = q.CurrType;
            cbWorkers.SelectedItem = q.Customer.MainContactID;
            foreach (var item in q.QuotationDetails)
            {
                if (item.IsDeleted == 1)
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationDeleted.Rows[0].Clone();
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
                    dgQuotationDeleted.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                    row.CreateCells(dgQuotationAddedItems);
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
                    dgQuotationAddedItems.Rows.Add(row);

                }
            }
            //ItemDetailsFiller(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString());
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {

                GetLandingCost(i);
                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[i].Cells[0];
                //GetMargin();
                GetQuotationQuantity(i);

            }
            GetAllMargin();
            #endregion
            //buradaki yazılanların sırası önemli sırayı değiştirmeyin
            lblsubtotal.Text = q.SubTotal.ToString();
            txtTotalDis2.Text = q.DiscOnSubTotal2.ToString();
            if (txtTotalDis2.Text == null || txtTotalDis2.Text == "") txtTotalDis2.Text = "0";
            decimal totaldis = (Decimal.Parse(txtTotalDis2.Text) * 100) / decimal.Parse(lblsubtotal.Text);
            txtTotalDis.Text = totaldis.ToString();
            lbltotal.Text = (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString();
            txtExtraChanges.Text = q.ExtraCharges.ToString();
            lblVat.Text = q.VatValue.ToString();
            if (q.IsVatValue == 1) { chkVat.Checked = true; } else { chkVat.Checked = false; }
            //
            if (q.IsItemCost == 1) { ckItemCost.Checked = true; } else { ckItemCost.Checked = false; }
            if (q.IsWeightCost == 1) { ckWeightCost.Checked = true; } else { ckWeightCost.Checked = false; }
            if (q.IsCustomsDuties == 1) { ckCustomsDuties.Checked = true; } else { ckCustomsDuties.Checked = false; }
            //Buraya Curr verileri gelecek
            #endregion
            try {
                if (dgQuotationAddedItems.RowCount > 1)
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();
                }
                else { dgQuotationAddedItems.Rows[0].Cells[0].Value = 1.ToString(); }
            }
            catch { }
            string q1 = q.QuotationNo;
            if (IME.Quotations.Where(a => a.QuotationNo == q1).ToList().Count > 0)
            {
                if (q.QuotationNo.Contains("v"))
                {
                    int quoID = Int32.Parse(q1.Substring(q.QuotationNo.LastIndexOf('v') + 1)) + 1;

                    q1 = (q.QuotationNo.Substring(0, q.QuotationNo.IndexOf('v') + 1)).ToString();

                    q1 = q1 + quoID.ToString();
                }
            }
            txtQuotationNo.Text = q1;
        }

        private void QuotataionModifyItemDetailsFiller(string ArticleNoSearch, int RowIndex)
        {
            bool isLithum = false;
            bool isShipping = false;
            bool isEnvironment = false;
            bool isCalibrationInd = false;
            bool isLicenceType = false;

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
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = sd.Article_Desc;
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgSSM"].Value = sd.Pack_Quantity.ToString();
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUC"].Value = sd.Unit_Content.ToString();
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sd.Unit_Measure;
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = sd.MPN;
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgCL"].Value = sd.Calibration_Ind;
                if (sd.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sd.Standard_Weight) / (decimal)1000).ToString("G29"); } else { }
                txtHazardousInd.Text = sd.Hazardous_Ind;
                txtCalibrationInd.Text = sd.Calibration_Ind;
                if (sd.Calibration_Ind == "Y") isCalibrationInd = true;
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
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = sdP.Article_Desc;
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgSSM"].Value = sdP.Pack_Quantity.ToString();
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUC"].Value = sdP.Unit_Content.ToString();
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
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
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = sdP.MPN;
                txtMHCodeLevel1.Text = sdP.MH_Code_Level_1;
                txtCCCN.Text = sdP.CCCN_No.ToString();
                txtHeight.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            }
            if (er != null)
            {
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgDesc"].Value = er.ArticleDescription;
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgUOM"].Value = er.UnitofMeasure;
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgMPN"].Value = er.MPN;
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
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
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
                txtWeb1.Text = ((Decimal.Parse(txtUK1.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb2.Text = ((Decimal.Parse(txtUK2.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb3.Text = ((Decimal.Parse(txtUK3.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb4.Text = ((Decimal.Parse(txtUK4.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
                txtWeb5.Text = ((Decimal.Parse(txtUK5.Text) * Decimal.Parse(cbFactor.Text)) / CurrValueWeb).ToString();
            }
            if (h != null)
            {
                if (h.Environment != null) { txtEnvironment.Text = "Y"; isEnvironment = true; } else { txtEnvironment.Text = ""; }
                if (h.Lithium != null) { txtLithium.Text = "Y";  isLithum = true; } else { txtLithium.Text = ""; }
                if (h.Shipping != null) { txtShipping.Text = "Y"; isShipping = true; } else { txtShipping.Text = ""; }
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
            if (du != null) { txtLicenceType.Text = du.LicenceType; isLicenceType = true; }
            //
            #endregion
            #region ItemMarginFiller
            string articleNo = ArticleNoSearch;
            SlidingPrice sp1 = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            try
            {
                txtMargin1.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
, Int32.Parse(sp1.Col1Break.ToString()))).ToString("G29");
                txtMargin1.Text = ((1 - ((Decimal.Parse(txtMargin1.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
            }
            catch { }
            try
            {
                txtMargin2.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                             , Int32.Parse(sp1.Col2Break.ToString()))).ToString("G29");
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
                    txtMargin3.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked, Int32.Parse(sp1.Col3Break.ToString()))).ToString("G29");
                    txtMargin3.Text = ((1 - ((Decimal.Parse(txtMargin3.Text)) / (decimal.Parse(txtWeb3.Text)))) * 100).ToString();
                    if (sp1.Col4Break != 0)
                    {
                        txtMargin4.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                    , Int32.Parse(sp1.Col4Break.ToString()))).ToString("G29");
                        txtMargin4.Text = ((1 - ((Decimal.Parse(txtMargin4.Text)) / (decimal.Parse(txtWeb4.Text)))) * 100).ToString();
                        if (sp1.Col5Break != 0)
                        {
                            txtMargin5.Text = (classQuotationAdd.GetLandingCost(ArticleNoSearch, ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
                        , Int32.Parse(sp1.Col5Break.ToString()))).ToString("G29");
                            txtMargin5.Text = ((1 - ((Decimal.Parse(txtMargin5.Text)) / (decimal.Parse(txtWeb5.Text)))) * 100).ToString();
                        }
                    }
                }
                catch { }
            }

            #endregion
            #region Low Margin Mark

            if (isLithum)
            {
                label64.BackColor = Color.Red;
                dgQuotationAddedItems.Rows[RowIndex].Cells["LI"].Style.BackColor = Color.Ivory;


            }
            if (isShipping)
            {
                label63.BackColor = Color.Red;
                dgQuotationAddedItems.Rows[RowIndex].Cells["HS"].Style.BackColor = Color.Red;

            }
            if (isEnvironment)
            {
                label53.BackColor = Color.Red;
            }
            if (isCalibrationInd)
            {
                label22.BackColor = Color.Red;
                dgQuotationAddedItems.Rows[RowIndex].Cells["CL"].Style.BackColor = Color.Green;
            }

            if (isLicenceType)
            {
                dgQuotationAddedItems.Rows[RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
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
            if (cbCurrency.SelectedIndex != null && cbCurrency.DataSource != null)
            {
                GetCurrency(dtpDate.Value);
                ChangeCurr();
                calculateTotalCost();
            }

        }

        private void ChangeCurr(int rowindex)
        {
            if (dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value != null)
            {

                dgQuotationAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value.ToString())) / Currfactor).ToString();
                dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString())) / Currfactor).ToString();
                dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())) / Currfactor).ToString();
                var st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                if (st != null)
                {
                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) - st.Item2).ToString();
                    SubTotal.Remove(st);

                    int subtotalcol1 = 0;
                    if (dgQuotationAddedItems.Rows[rowindex].Cells[0].Value != null) subtotalcol1 = Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString());
                    SubTotal.Add(new Tuple<int, decimal>(subtotalcol1, Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())));
                    st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st.Item2).ToString();
                }
                else
                {
                    int subtotalcol1 = 0;
                    if (dgQuotationAddedItems.Rows[rowindex].Cells[0].Value != null) subtotalcol1 = Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString());
                    SubTotal.Add(new Tuple<int, decimal>(subtotalcol1, Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())));
                    st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
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
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                #region Get Margin
                if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null && dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString() != "0")
                {
                    dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString())) / Currfactor).ToString();
                    dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString())) / Currfactor).ToString();
                    dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())) / Currfactor).ToString();
                    var st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()))).FirstOrDefault();
                    SubTotal.Remove(st);
                    SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()), Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())));
                    st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()))).FirstOrDefault();
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
                DataGridViewRow row = (DataGridViewRow)dgQuotationDeleted.CurrentRow;
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

        private void btnCreateRev_Click(object sender, EventArgs e)
        {
            //try
            //{
                //string newID = NewQuotationID();
                //if (txtQuotationNo.Text != newID) { txtQuotationNo.Text = newID; }
                if (ControlSave())
                {
                    QuotationSave(txtQuotationNo.Text);
                    QuotationDetailsSave();
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Error Occured", "Failure");
            //}
        }

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
                if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[dgQty.Index].Value == null)
                {
                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[dgQty.Index];

                }
                else
                {

                    DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                    dgQuotationAddedItems.Rows.Add(dgRow);
                    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex+1].Cells[dgProductCode.Index];
                    ItemClear();
                }


            }
            catch { }
        }

        private void ChangeCurrnetCellTabKey(int currindex)
        {
            if (IME.ArticleSearch(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()).Count() == 1)
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
                foreach (DataGridViewRow item in dgQuotationAddedItems.SelectedRows)
                {
                    int rownumber = Int32.Parse(dgQuotationAddedItems.Rows[item.Index].Cells["dgNo"].Value.ToString());
                    dgQuotationDeleted.Rows.Add();
                    for (int i = 0; i < dgQuotationDeleted.Columns.Count; i++)
                    {
                        dgQuotationDeleted.Rows[dgQuotationDeleted.Rows.Count - 2].Cells[i].Value = item.Cells[i].Value;
                    }

                    var st = SubTotal.Where(a => a.Item1 == rownumber).FirstOrDefault();
                    if(st!=null)lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) - st.Item2).ToString();
                    if (SubTotal.Count > 0)
                    {
                        SubDeletingTotal.Add(new Tuple<int, decimal>(rownumber, SubTotal.Where(a => a.Item1 == rownumber).FirstOrDefault().Item2));
                        SubTotal.Remove(st);
                        SubTotal.Add(new Tuple<int, decimal>(rownumber, 0));
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
            for (int i = 0; i < dgQuotationAddedItems.ColumnCount; i++)
            {
                QuotationItemList.Add(dgQuotationAddedItems.Columns[i].HeaderText);
            }
            frmQuotationExport form = new frmQuotationExport(QuotationItemList, txtQuotationNo.Text, dgQuotationAddedItems);
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
                for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                {
                    if ((dgQuotationAddedItems.Rows[i].Cells["HS"].Style.BackColor != Color.Red )&& (dgQuotationAddedItems.Rows[i].Cells["LI"].Style.BackColor != Color.Ivory))
                    {
                       if(dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value!=null) subtotal+=  decimal.Parse( dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                    }
                }
                //
                decimal totaldis = (Decimal.Parse(txtTotalDis2.Text) * 100) / subtotal;
                txtTotalDis.Text = String.Format("{0:0.0000}", totaldis).ToString();
                lbltotal.Text = (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text)).ToString();
                getTotalDiscMargin();
                if (txtTotalMarge.Visible == true)
                {
                    txtTotalMarge.Text = calculateTotalMargin().ToString();
                    txtTotalMarge.Text = String.Format("{0:0.0000}", Decimal.Parse(txtTotalMarge.Text)).ToString();
                }
            }
        }

        public void ChangeDataGrid()
        {
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                if (dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value != null)
                {
                    decimal total = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()) * Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                    dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value = ((total) - (((total) * Decimal.Parse(txtTotalDis2.Text)) / Decimal.Parse(lblsubtotal.Text))).ToString();
                    dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString()) / Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString();

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
                        //else if ()//HE için
                        //{

                        //}
                    }
                    //
                    decimal subtotal = Decimal.Parse(lblsubtotal.Text) - hztotal;
                    decimal dis2 = subtotal * Decimal.Parse(txtTotalDis.Text) / 100;
                    txtTotalDis2.Text = String.Format("{0:0.0000}", dis2).ToString();
                    lbltotal.Text = String.Format("{0:0.0000}", (Decimal.Parse(lblsubtotal.Text) - decimal.Parse(txtTotalDis2.Text))).ToString();
                }
                if (cbDeliverDiscount.Checked) getTotalDiscMargin();
                if (txtTotalMarge.Visible == true) {

                        txtTotalMarge.Text = calculateTotalMargin().ToString();
                    txtTotalMarge.Text = String.Format("{0:0.0000}", Decimal.Parse(txtTotalMarge.Text)).ToString();
                }




            }
        }

        private decimal calculateTotalMargin()
        {
            decimal totalMargin = 0;
            decimal subtotal = 0;
            decimal Itemtotal = 0;
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {

                decimal margin = 0;
                if (!cbDeliverDiscount.Checked)
                {
                    if (dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value == "")
                    {
                        Itemtotal = 0;
                    }
                    else
                    {
                        Itemtotal = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                    }

                    decimal disc = 0;
                    if(txtTotalDis.Text!="")disc=decimal.Parse(txtTotalDis.Text);
                    Itemtotal = Itemtotal * (1 - ( disc/100));
                    subtotal += Itemtotal;
                    decimal UCUPCurr = 0;
                    decimal Cost = 0;
                    if(dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value!=null) UCUPCurr= decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgUCUPCurr.Index].Value.ToString());
                    if (UCUPCurr != 0) UCUPCurr = UCUPCurr * ((1 - (disc / 100)));
                    if(dgQuotationAddedItems.Rows[i].Cells[dgCost.Index].Value!=null) Cost = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString());
                    if(UCUPCurr!=0)margin = (1-(Cost/UCUPCurr))*100;
                    totalMargin += (margin* Itemtotal);
                }
                else
                {
                    if (dgQuotationAddedItems.Rows[i].Cells[dgMargin.Index].Value != null) margin = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgMargin.Index].Value.ToString());

                    if (dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value != null) Itemtotal = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                    subtotal += Itemtotal;
                    totalMargin += (margin * Itemtotal);
                }
            }
            if (cbDeliverDiscount.Checked)
            {

                txtTotalMargin.Text = String.Format("{0:0.0000}", totalMargin / subtotal).ToString();
            }
            else
            {
                decimal subtotal1 = 0;
                decimal totalMargin1 = 0;
                for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                {
                    decimal Itemtotal1 = 0;
                    decimal margin1 = 0;
                    if (dgQuotationAddedItems.Rows[i].Cells[dgMargin.Index].Value != null) margin1 = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgMargin.Index].Value.ToString());

                    if (dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value != null) Itemtotal1 = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgTotal.Index].Value.ToString());
                    subtotal1 += Itemtotal1;
                    totalMargin1 += (margin1 * Itemtotal1);
                }

                txtTotalMargin.Text = String.Format("{0:0.0000}", totalMargin1 / subtotal1).ToString();
            }


            return totalMargin / subtotal;
        }

        private void getTotalDiscMargin()
        {
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                if (dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value != null && dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString() != string.Empty)
                {
                    decimal cost = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString());
                    decimal UCUPCur = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString());
                    decimal disc = 0;
                    if (txtTotalDis.Text != string.Empty && txtTotalDis.Text != null) disc = decimal.Parse(txtTotalDis.Text);
                    UCUPCur = UCUPCur * (1 - (disc / 100));
                    //dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = (1 - (cost / UCUPCur)) * 100;
                }
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
            if (txtExtraChanges.Text != null && txtExtraChanges.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtExtraChanges.Text);
                txtExtraChanges.Text = sonuc.ToString();
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

            if (dgQuotationAddedItems.CurrentRow.Cells["dgProductCode"].Value != null)
                item_code = dgQuotationAddedItems.CurrentRow.Cells["dgProductCode"].Value.ToString();
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
                if (dgQuotationAddedItems.CurrentCell.Value != null) ArticleNO = dgQuotationAddedItems.CurrentCell.Value.ToString();
                FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(ArticleNO);
                itemsearch.ShowDialog();
                this.Enabled = true;
                try
                {
                    //Bu item daha önceden eklimi diye kontrol ediyor
                    DataGridViewRow row = dgQuotationAddedItems.Rows
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
                dgQuotationAddedItems.CurrentCell.Value = classQuotationAdd.ItemCode;
                if (dgQuotationAddedItems.CurrentCell.Value != null)
                {
                    try { sdNumber = IME.SuperDisks.Where(a => a.Article_No.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdNumber = 0; }
                    try { sdPNumber = IME.SuperDiskPs.Where(a => a.Article_No.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdPNumber = 0; }
                    try { erNumber = IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { erNumber = 0; }
                    if (sdNumber == 1 || sdPNumber == 1 || erNumber == 1)
                    {
                        if (classQuotationAdd.HasMultipleItems(dgQuotationAddedItems.CurrentCell.Value.ToString()) == 0)
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
                            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
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
                if (item.Cells["dgProductCode1"].Value != null)
                {
                    int rowindex = item.Index;
                    int no = Int32.Parse(dgQuotationDeleted.Rows[rowindex].Cells["No1"].Value.ToString());
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
                    int rowindex1 = dgQuotationAddedItems.RowCount;

                    dgQuotationAddedItems.Rows.Add();
                    int row1 = Int32.Parse(dgQuotationAddedItems.Rows[rowindex1].Cells[0].Value.ToString());

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
                    dgQuotationDeleted.Rows.Remove(dgQuotationDeleted.Rows[rowindex]);

                }
                else { MessageBox.Show("Please choose an item to add Quotation"); }
            }

             //dgQuotationAddedItems.Sort()
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                dgQuotationAddedItems.Rows[i].Cells[0].Value = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString());
            }
            dgQuotationAddedItems.Sort(dgQuotationAddedItems.Columns[0], ListSortDirection.Ascending);
        }

        private void cbDeliverDiscount_CheckedChanged(object sender, EventArgs e)
        {
            decimal subtotal=0;
            if (cbDeliverDiscount.Checked)
            {
                for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                {
                    if (dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value != null)
                    {
                        decimal total = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());

                        decimal disc = 0;
                        if (txtTotalDis.Text != null && txtTotalDis.Text != string.Empty) disc = Decimal.Parse(txtTotalDis.Text);
                        //discValue = total - (total * (1 - (disc / 100)));
                        //total = total - discValue;
                        total = (total * (1 - (disc / 100)));
                        subtotal += total;
                        dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value = total.ToString();
                        dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = (total / Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString();
                        decimal UCIME = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()) * Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString());

                        dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value = (100 - (100 * total / UCIME)).ToString();
                    }
                }

            }
            else
            {
                for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                {
                    if (dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value != null)
                    {
                        decimal total = 0;
                        decimal lasttotal = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString());
                        decimal disc = 0;
                        if (txtTotalDis.Text != null && txtTotalDis.Text != string.Empty) disc = Decimal.Parse(txtTotalDis.Text);
                        total = lasttotal / (1 - (disc / 100));
                        subtotal += total;
                        dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value = total.ToString();
                        dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = (total / Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString())).ToString();
                        decimal UCIME = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()) * Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString());
                        dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value = (100 - (100 * total / UCIME)).ToString();
                    }
                }
            }
            lblsubtotal.Text = subtotal.ToString();
            GetAllMargin();
            txtTotalMarge.Text = calculateTotalMargin().ToString();
            txtTotalMarge.Text = String.Format("{0:0.0000}", Decimal.Parse(txtTotalMarge.Text)).ToString();
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
                dgQuotationAddedItems.CurrentRow.Cells[dgQty.Index].Style = dgQuotationAddedItems.DefaultCellStyle;
                curCell.Value = product.Quantity;
                dgQuotationAddedItems_CellEndEdit(null, null);
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

        private void dgQuotationAddedItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgQuotationAddedItems.Rows.Count == 0)
            {

                dgQuotationAddedItems.Rows.Add();
                dgQuotationAddedItems.Rows[0].Cells[0].Value = "1";
                calculateTotalCost();
            }
        }

        private void btnCustomizeGrid_Click(object sender, EventArgs e)
        {
            frmQuotationGridCustomize form = new frmQuotationGridCustomize(dgQuotationAddedItems);
            form.ShowDialog();
            List<string> quotationVisibleFalseNames = QuotationDatagridCustomize.VisibleFalseNames;
             ;
            foreach (DataGridViewColumn item in dgQuotationAddedItems.Columns)
            {
               if ( item.Name != "dgHZ" && item.Name != "dgCL" && item.Name != "dgCR") item.Visible = true;
            }
            foreach (var item in quotationVisibleFalseNames)
            {
                dgQuotationAddedItems.Columns[item].Visible = false;
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
    }
}
