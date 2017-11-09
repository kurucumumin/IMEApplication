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

        IMEEntities IME = new IMEEntities();
        decimal price;
        List<Tuple<int, decimal>> SubTotal = new List<Tuple<int, decimal>>();
        List<Tuple<int, decimal>> SubDeletingTotal = new List<Tuple<int, decimal>>();
        ContextMenu DeletedQuotationMenu = new ContextMenu();
        Rate curr = new Rate();
        Decimal CurrValue = 1;
        Decimal CurrValue1 = 1;
        decimal Currfactor = 1;
        decimal CurrentDis;
        decimal LowMarginLimit;
        public static Customer customer;
        bool modifyMod = false;
        ToolTip aciklama = new ToolTip();
        SqlDataAdapter da;
        System.Data.DataSet ds = new System.Data.DataSet();
        #endregion

        public FormQuotationAdd()
        {
            InitializeComponent();
            dtpDate.Value = DateTime.Now;
            dtpDate.Enabled = false;
        }

        public FormQuotationAdd(Quotation quotation)
        {
            //Son versiyonu açmayı sağlıyor
            Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(quotation.QuotationNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();
            this.Text = "Edit Quotation";
            modifyMod = true;
            InitializeComponent();
            dtpDate.Value = (DateTime)q1.StartDate;
            dtpDate.MaxDate = DateTime.Today.Date;
            cbCurrency.DataSource = IME.Rates.Where(a => a.rate_date == dtpDate.Value).ToList();
            cbCurrency.DisplayMember = "CurType";
            cbCurrency.ValueMember = "ID";
            cbCurrency.SelectedIndex = 0;
            cbPayment.DataSource = IME.PaymentMethods.ToList();
            cbPayment.DisplayMember = "Payment";
            cbPayment.ValueMember = "ID";
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbWorkers.DataSource = IME.CustomerWorkers.Where(a=>a.customerID==q1.CustomerID).ToList();
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
            if(q1.QuotationMainContact!=null) cbWorkers.SelectedIndex = (int)q1.QuotationMainContact;
            CustomerCode.Enabled = false;
            txtCustomerName.Enabled = false;
            btnSave.Enabled = false;
            LowMarginLimit = (Decimal)Utils.getManagement().LowMarginLimit;
            modifyQuotation(q1);
            //fillCustomer();
            cbSMethod.SelectedIndex = (int)q1.ShippingMethodID;
            for (int i = 0; i < dgQuotationAddedItems.RowCount-1; i++)
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
            QuotataionModifyItemDetailsFiller(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells["dgProductCode"].Value.ToString(), dgQuotationAddedItems.RowCount - 1);
        }

        private void QuotationForm_Load(object sender, EventArgs e)
        {

            if (!modifyMod)
            {
                DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                dgQuotationAddedItems.Rows.Add(dgRow);
                txtQuotationNo.Text = NewQuotationID();
                dgQuotationAddedItems.Rows[0].Cells["dgQty"].Value = "0";
                dgQuotationAddedItems.Rows[0].Cells[0].Value = 1.ToString();
                LowMarginLimit = Decimal.Parse(IME.Managements.FirstOrDefault().LowMarginLimit.ToString());
                lblVat.Text = Utils.getManagement().VAT.ToString();
                #region ComboboxFiller.
                dtpDate.Value = DateTime.Now;
                cbCurrency.DataSource = IME.Rates.Where(a => a.rate_date == dtpDate.Value.Date).ToList();
                cbCurrency.DisplayMember = "CurType";
                cbCurrency.ValueMember = "ID";
                cbCurrency.SelectedIndex = 0;
                cbCurrType.SelectedIndex = 0;
                cbPayment.DataSource = IME.PaymentMethods.ToList();
                cbPayment.DisplayMember = "Payment";
                cbPayment.ValueMember = "ID";
                cbRep.DataSource = IME.Workers.ToList();
                cbRep.ValueMember = "WorkerID";
                cbRep.DisplayMember = "NameLastName";
                cbRep.SelectedValue = Utils.getCurrentUser().WorkerID;
                cbCurrType.SelectedIndex = 0;
                #endregion
            }
            GetCurrency(dtpDate.Value);
            if (GetUserAutorities(1020)) { VisibleCostMarginTrue(); }
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
            if (!modifyMod)
            {
                CustomerCode.Text = classQuotationAdd.customerID;
                txtCustomerName.Text = classQuotationAdd.customername;
            }

            var c = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();
            if (c != null)
            {
                txtCustomerName.Text = c.c_name;
                cbCurrency.SelectedIndex = cbCurrency.FindStringExact(c.CurrNameQuo);
                cbCurrType.SelectedIndex = cbCurrType.FindStringExact(c.CurrTypeQuo);
                //if(c.MainContactID!=null) cbWorkers.SelectedIndex = (int)c.MainContactID;
                if (c.paymentmethodID != null)
                {
                    cbPayment.SelectedIndex = cbPayment.FindStringExact(c.PaymentMethod.Payment);
                }
                try { txtContactNote.Text = c.CustomerWorker.Note.Note_name; } catch { }
                try { txtCustomerNote.Text = c.Note.Note_name; } catch { }
                try { txtAccountingNote.Text = IME.Notes.Where(a=>a.ID==c.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
                cbRep.SelectedIndex = c.Worker.WorkerID;
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
                                        if (st != null) {  stPrice = st.Item2; }
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
                            //0100-124 => 0100124
                            if (dgQuotationAddedItems.CurrentCell.Value.ToString().Contains("-")) { dgQuotationAddedItems.CurrentCell.Value = dgQuotationAddedItems.CurrentCell.Value.ToString().Replace("-", string.Empty).ToString(); }
                            if (dgQuotationAddedItems.CurrentCell.Value != null && dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 6 || (dgQuotationAddedItems.CurrentCell.Value.ToString().Contains("P") && dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 7)) { dgQuotationAddedItems.CurrentCell.Value = 0.ToString() + dgQuotationAddedItems.CurrentCell.Value.ToString(); }
                            var sd = classQuotationAdd.ItemGetSuperDisk(dgQuotationAddedItems.CurrentCell.Value.ToString());
                            var sdp = classQuotationAdd.ItemGetSuperDiskP(dgQuotationAddedItems.CurrentCell.Value.ToString());
                            var er = classQuotationAdd.ItemGetExtendedRange(dgQuotationAddedItems.CurrentCell.Value.ToString());
                            int sdNumber; int sdPNumber; int erNumber;
                            try { sdNumber = IME.SuperDisks.Where(a => a.Article_No.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).Count(); } catch { sdNumber = 0; }
                            try { sdPNumber = IME.SuperDiskPs.Where(a => a.Article_No.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).Count(); } catch { sdPNumber = 0; }
                            try { erNumber = IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).Count(); } catch { erNumber = 0; }
                            if (sdNumber != 0 || sdPNumber != 0 || erNumber != 0)
                            {
                                if (classQuotationAdd.HasMultipleItems(dgQuotationAddedItems.CurrentCell.Value.ToString()) == 0 && ((dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 7 || (dgQuotationAddedItems.CurrentCell.Value.ToString().Contains("P") && dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 8))))
                                {
                                    if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
                                    #region MyRegion
                                    string itemCode = dgQuotationAddedItems.CurrentCell.Value.ToString();

                                    dynamic MPNList;
                                    var sd1 = IME.SuperDisks.Where(a => a.Article_No == itemCode).FirstOrDefault();
                                    if (sd1 == null)
                                    {
                                        MPNList = QuotationHelper.BringItems(itemCode,true);
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

                                    //ItemClear();

                                    ItemDetailsFiller(dgQuotationAddedItems.CurrentCell.Value.ToString());
                                    //LandingCost Calculation
                                    FillProductCodeItem();
                                }
                                else
                                {
                                    this.Enabled = false;
                                    FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(dgQuotationAddedItems.CurrentCell.Value.ToString());
                                    itemsearch.ShowDialog();
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
                                    dgQuotationAddedItems.CurrentCell.Value = classQuotationAdd.ItemCode;
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
                                    this.Enabled = true;
                                    if(dgQuotationAddedItems.CurrentCell.ColumnIndex==7) dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentRow.Index].Cells[dgQuotationAddedItems.CurrentCell.ColumnIndex+1];
                                }

                            }
                            else { MessageBox.Show("There is no such an item"); }

                        }
                        else
                        {
                            ItemDetailsClear();
                            //dgQuotationAddedItems.Rows[dgQuotationAddedItems.].Cells["dgProductCode"].Selected

                        }
                    }
                    #endregion
                    //ChangeCurrnetCell(dgQuotationAddedItems.CurrentCell.RowIndex +1);
                    break;
                case 15://QAUANTITY
                    #region Quantity
                    {
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
                    //LOW MARGIN
                    GetMarginMark();

                    //
                    //TotalDis();
                    break;
                #endregion
                case 22://Total
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
                    break;

            }
            #endregion
            try
            {
                ChangeCurrnetCell(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
            }
            catch { }

        }

        private void GetQuotationQuantity(int rowindex)
        {
            if (cbFactor.Text != null && cbFactor.Text != "")
            {
                #region Quantity
                try
                {
                    if (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()) != 0)
                    {
                        #region Quantity
                        if (txtStandartWeight.Text != null && txtStandartWeight.Text != "")
                        {
                            txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();
                        }
                        dgQuotationAddedItems.Rows[rowindex].Cells["dgCost"].Value = classQuotationAdd.GetCost(dgQuotationAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString("G29");
                        if (dgQuotationAddedItems.Rows[rowindex].Cells["dgCost"].Value.ToString() != "-1") { String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgCost"].Value.ToString())).ToString(); }
                        GetLandingCost(rowindex);
                        //  dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value.ToString())).ToString();
                        dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value = Math.Round(Convert.ToDecimal(dgQuotationAddedItems.Rows[rowindex].Cells["dgLandingCost"].Value.ToString()), 4);
                        price = Decimal.Parse((classQuotationAdd.GetPrice(dgQuotationAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())) * Decimal.Parse(cbFactor.Text) * Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString("G29"));
                        //price /= factor;
                        decimal discResult = 0;
                        //Fiyat burada
                        string articleNo = dgQuotationAddedItems.Rows[rowindex].Cells["dgProductCode"].Value.ToString();
                        int isP = 0;
                        if (articleNo.ToUpper().IndexOf('P') != -1) { isP = 1; }

                        if (isP == 1)
                        {
                            if (IME.SuperDiskPs.Where(a => a.Article_No == articleNo).ToList().Count > 0)
                            {
                                if (IME.SuperDiskPs.Where(a => a.Article_No == articleNo).FirstOrDefault().Pack_Quantity > 1)
                                {


                                    if (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgSSM"].Value.ToString()) > 1 && Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()) == 1)
                                    {
                                        if ((Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgSSM"].Value.ToString())) != 0)
                                        {
                                            MessageBox.Show("Please enter a number that is a multiple of SSM");
                                            dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value = "";

                                        }
                                        else
                                        {
                                            price = price / decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString());
                                            dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = price / decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString());
                                            dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = price;

                                            //GetUCMargin();
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {

                            if (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()) > 1 && Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgSSM"].Value.ToString()) == 1)
                            {
                                int resultMod = (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()));
                                if ((resultMod != 0) || (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())) < Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUC"].Value.ToString()))
                                {
                                    MessageBox.Show("Please enter a number that is a multiple of Unit Content");
                                    dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value = "";
                                }
                                else
                                {
                                    price = price / decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString());
                                    dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = price / decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString());
                                    dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = price;

                                    //GetUCMargin();
                                }
                            }
                        }
                        //TOTAL ve UPIME belirleniyor
                        //dataGridView3.Rows[rowindex].Cells["dgUPIME"].Value = (price / Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();
                        dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = (price / Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();
                        discResult = decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString());
                        dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString())).ToString();
                        dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = String.Format("{0:0.0000}", price).ToString();
                        if (dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value != null)
                        {
                            dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value.ToString())).ToString();
                            discResult = (discResult - (discResult * decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value.ToString()) / 100));
                        }
                        dgQuotationAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = String.Format("{0:0.0000}", discResult).ToString();
                        ChangeCurr(rowindex);
                        GetMargin();
                        dgQuotationAddedItems.Rows[rowindex].Cells["dgMargin"].Value = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgMargin"].Value.ToString())).ToString();
                        dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgTotalWeight"].Value = (Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUnitWeigt"].Value.ToString()) * Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();
                        //CalculateSubTotal();
                        #region Calculate Total Margin
                        try
                        {
                            Decimal TotalMarginValue = Decimal.Parse(txtTotalMargin.Text) * (Decimal.Parse(lblsubtotal.Text) - Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString()));
                            TotalMarginValue = (TotalMarginValue + (Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString()) * Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString()))) / Decimal.Parse(lblsubtotal.Text);
                            txtTotalMargin.Text = String.Format("{0:0.0000}", TotalMarginValue).ToString();
                        }
                        catch
                        {
                            txtTotalMargin.Text = String.Format("{0:0.0000}", Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString())).ToString();
                        }
                        #endregion
                    }

                    #endregion
                }
                catch { }
                #endregion

            }
        }

        private void GetMarginMark(int rowindex)
        {
            try
            {
                if (Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgMargin"].Value.ToString()) < LowMarginLimit)
                {
                    dgQuotationAddedItems.Rows[rowindex].Cells["LM"].Style.BackColor = Color.Blue;
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
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = (((1 - ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString())))))) * 100).ToString("G29");

                }
                else
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");

                }
            }
            #endregion
        }

        private void GetAllMargin()
        {
            #region Get Margin
            DateTime today = DateTime.Today;
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                try
                {
                    if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null)
                    {
                        dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()))))) * 100).ToString("G29");
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
            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgHZ"].Value = txtHazardousInd.Text;
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
            Rate currWeb = new Rate();
            currWeb = IME.Rates.Where(a => a.rate_date == DateTime.Today.Date).ToList().Where(b => b.CurType == "GBP").FirstOrDefault();
            decimal CurrValueWeb = Decimal.Parse(curr.RateBuy.ToString());
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
                if (h.Environment != null) { txtEnvironment.Text = "Y"; }
                if (h.Lithium != null) { txtLithium.Text = "Y"; }
                if (h.Shipping != null) { txtShipping.Text = "Y"; }
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
            try
            {
                txtMargin1.Text = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
, Int32.Parse(sp1.Col1Break.ToString()))).ToString("G29");
                txtMargin1.Text = ((1 - ((Decimal.Parse(txtMargin1.Text)) / (decimal.Parse(txtWeb1.Text)))) * 100).ToString();
            }
            catch { }
            try
            {
                txtMargin2.Text = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
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
                    txtMargin3.Text = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked, Int32.Parse(sp1.Col3Break.ToString()))).ToString("G29");
                    txtMargin3.Text = ((1 - ((Decimal.Parse(txtMargin3.Text)) / (decimal.Parse(txtWeb3.Text)))) * 100).ToString();
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
            if (txtShipping.Text != "")
            {
                label63.BackColor = Color.Red;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

            }
            if (txtEnvironment.Text != "")
            {
                label53.BackColor = Color.Red;
            }
            if (txtCalibrationInd.Text != "" && txtCalibrationInd.Text != null && txtCalibrationInd.Text != "N")
            {
                label22.BackColor = Color.Red;
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Green;
            }

            if (txtLicenceType.Text != "" && txtLicenceType.Text != null)
            {
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
            }



            #endregion


        }

        private void CustomerCode_KeyDown_1(object sender, KeyEventArgs e)
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
                    cbWorkers.DataSource = customer.CustomerWorkers.ToList();
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
                if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
                {
                    txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())).ToString();
                }
            }
            catch { }

        }

        private void dgQuotationAddedItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();
            }
            catch { }
        }

        private void dgQuotationAddedItems_Click(object sender, EventArgs e)

                {
            ItemClear();
            try { ItemDetailsFiller(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString()); } catch { }
        }

        private void dgQuotationAddedItems_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int rownumber = Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value.ToString());
            dgQuotationDeleted.Rows.Add();
            for (int i = 0; i < dgQuotationAddedItems.Columns.Count; i++)
            {
                dgQuotationDeleted.Rows[dgQuotationDeleted.Rows.Count - 2].Cells[i].Value = dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[i].Value;
            }
            try { lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) - SubTotal.Where(a => a.Item1 == rownumber).FirstOrDefault().Item2).ToString(); } catch { }
            var st = SubTotal.Where(a => a.Item1 == rownumber).FirstOrDefault();
            try
            {
                SubDeletingTotal.Add(new Tuple<int, decimal>(rownumber, st.Item2));
                SubTotal.Remove(st);
                SubTotal.Add(new Tuple<int, decimal>(rownumber, 0));
            }
            catch { }
        }

        private void cbFactor_TextChanged(object sender, EventArgs e)
        {
            #region Faktör Değişimi
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                GetQuotationQuantity(i);
                GetLandingCost(i);
            }
            #endregion

            GetAllMargin();
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
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                if (dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                {


                    GetLandingCost(i);
                    if (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString()) < Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgCost"].Value.ToString()))
                    {
                        dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value = dgQuotationAddedItems.Rows[i].Cells["dgCost"].Value.ToString();
                    }
                    //GetQuotationQuantity(i);
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

        private void ckItemCost_CheckedChanged(object sender, EventArgs e)
        {
            getQuotationValues();
        }

        private void CalculateSubTotal()
        {
            #region SubTotal Calculation
            int RowIndex = dgQuotationAddedItems.CurrentCell.RowIndex;
            int rowindexSubTotal = Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgNo"].Value.ToString());
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
                lblVatTotal.Text = (totalextra * Decimal.Parse((0.4).ToString())).ToString();
                lblGrossTotal.Text = ((Decimal.Parse(lblTotalExtra.Text) + ((Decimal.Parse(lblTotalExtra.Text) * (Decimal.Parse((0.4).ToString())))))).ToString();
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

        private void addToQuotationAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgQuotationDeleted.CurrentRow.Cells["dgProductCode1"].Value != null)
            {
                int rowindex = dgQuotationDeleted.CurrentCell.RowIndex;
                int no = Int32.Parse(dgQuotationDeleted.Rows[rowindex].Cells["No1"].Value.ToString());
                var st = SubTotal.Where(a => a.Item1 == no).FirstOrDefault();
                var st1 = SubDeletingTotal.Where(a => a.Item1 == no).FirstOrDefault();
                if (st != null)
                {
                    SubTotal.Remove(st);
                    SubTotal.Add(new Tuple<int, decimal>(no, st1.Item2));
                    lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st1.Item2).ToString();
                    SubDeletingTotal.Remove(st1);
                }


                    int rowindex1 = dgQuotationAddedItems.RowCount - 1;
                    dgQuotationAddedItems.Rows.Add();
                    for (int i = 0; i < dgQuotationDeleted.Columns.Count; i++)
                    {
                        dgQuotationAddedItems.Rows[rowindex1].Cells[i].Value = dgQuotationDeleted.Rows[dgQuotationDeleted.CurrentCell.RowIndex].Cells[i].Value;
                    }
                    dgQuotationDeleted.Rows.Remove(dgQuotationDeleted.Rows[rowindex]);
                    dgQuotationAddedItems.Sort(dgQuotationAddedItems.Columns[0], ListSortDirection.Ascending);
                }
                else { MessageBox.Show("Please choose an item to add Quotation"); }



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
                    if(txtTotalDis.Text != ((CurrentDis * 100) / Decimal.Parse(lblsubtotal.Text)).ToString())
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
            if(txtCustomerName.Text==null || txtCustomerName.Text ==String.Empty) { MessageBox.Show("Please Enter a Customer");return false; }
            for (int i = 0; i < dgQuotationAddedItems.RowCount-1 ; i++)
            {
                if (Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value.ToString()) < Utils.getCurrentUser().MinMarge) { MessageBox.Show("Please Check Merge of Products "); return false;  }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool SaveOK = false;
                SaveOK = ControlSave();
                if (SaveOK)
                {
                    QuotationSave();
                    QuotationDetailsSave();
                }
                
            }
            catch { MessageBox.Show("Error Occured", "Failure"); }

        }

        private void QuotationSave()
        {
            DataSet.Quotation q = new DataSet.Quotation();
            q.QuotationNo = txtQuotationNo.Text;
            q.RFQNo = txtRFQNo.Text;
            try { q.SubTotal = decimal.Parse(lblsubtotal.Text); } catch { }
            if (chkbForFinance.Checked) { q.ForFinancelIsTrue = 1; } else { q.ForFinancelIsTrue = 0; }
            if (ckItemCost.Checked) { q.IsItemCost = 1; } else { q.IsItemCost = 0; }
            if (ckWeightCost.Checked) { q.IsWeightCost = 1; } else { q.IsWeightCost = 0; }
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
            q.CurrName = (cbCurrency.SelectedItem as Rate).CurType;
            q.CurrType = cbCurrType.SelectedText;
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
            try { q.CurrType = cbCurrType.SelectedText; } catch { }
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
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                if (dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value != null)
                {
                    QuotationDetail qd = new QuotationDetail();
                    qd.QuotationNo = txtQuotationNo.Text;
                    try { qd.RFQNo = txtRFQNo.Text; } catch { }
                    try { qd.dgNo = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgNo"].Value.ToString()); } catch { }
                    try { qd.ItemCode = dgQuotationAddedItems.Rows[i].Cells["dgProductCode"].Value.ToString(); } catch { }
                    try { qd.Qty = Int32.Parse(dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString()); } catch { }
                    try { qd.UCUPCurr = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString()); } catch { }
                    try { qd.UCUPCurr = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString()); } catch { }
                    try { qd.Disc = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value.ToString()); } catch { }
                    try { qd.Total = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString()); } catch { }
                    try { qd.TargetUP = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value.ToString()); } catch { }
                    try { qd.Competitor = dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value.ToString(); } catch { }
                    try { qd.CustomerDescription = dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value.ToString(); } catch { }
                    try { qd.CustomerStockCode = dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value.ToString(); } catch { }
                    IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();

                }

            }
            for (int i = 0; i < dgQuotationDeleted.RowCount; i++)
            {
                if (dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value != null)
                {
                    QuotationDetail qd = new QuotationDetail();
                    qd.RFQNo = txtRFQNo.Text;
                    try{qd.dgNo = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["No1"].Value.ToString()); } catch { }
                    try{qd.ItemCode = dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value.ToString();}catch { }
                    try{qd.Qty = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["dgQty1"].Value.ToString());}catch { }
                    try{qd.UCUPCurr = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgUCUPCurr1"].Value.ToString());}catch { }
                    try{qd.Disc = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgDisc1"].Value.ToString());}catch { }
                    try { qd.UCUPCurr = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgUPIME"].Value.ToString()); } catch { }
                    try {qd.Total = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgTotal1"].Value.ToString());}catch { }
                    try{qd.TargetUP = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgTargetUP1"].Value.ToString());}catch { }
                    try{qd.Competitor = dgQuotationDeleted.Rows[i].Cells["dgCompetitor1"].Value.ToString();  } catch { }
                    try{qd.CustomerDescription = dgQuotationDeleted.Rows[i].Cells["dgCustDescription1"].Value.ToString();}catch { }
                    try {qd.CustomerStockCode = dgQuotationDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value.ToString();}catch { }
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
            txtQuotationNo.Text = q.QuotationNo;
            txtRFQNo.Text = q.RFQNo;
            CustomerCode.Text = q.Customer.ID;
            if(q.NoteForCustomerID!=null)txtNoteForCustomer.Text = IME.Notes.Where(a => a.ID == q.NoteForCustomerID).FirstOrDefault().Note_name;
            if (q.NoteForCustomerID != null) txtNoteForUs.Text = IME.Notes.Where(a => a.ID == q.NoteForUsID).FirstOrDefault().Note_name;
            if (q.ForFinancelIsTrue == 1) { chkbForFinance.Checked = true; }
            fillCustomer();
            #region QuotationDetails
            cbCurrency.SelectedItem = q.CurrName;
            cbCurrType.SelectedItem = q.CurrType;
            cbWorkers.SelectedItem = q.Customer.MainContactID;
            foreach (var item in q.QuotationDetails)
            {
                if (item.IsDeleted == 1)
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationDeleted.Rows[0].Clone();
                    row.Cells[0].Value = item.dgNo;
                    row.Cells[7].Value = item.ItemCode;
                    row.Cells[15].Value = item.Qty;
                    row.Cells[20].Value = item.dgUPIME;
                    row.Cells[22].Value = item.UCUPCurr;
                    row.Cells[21].Value = item.Disc;
                    row.Cells[23].Value = item.Total;
                    row.Cells[24].Value = item.TargetUP;
                    row.Cells[25].Value = item.Competitor;
                    row.Cells[29].Value = item.Qty;
                    row.Cells[30].Value = item.CustomerStockCode;
                    dgQuotationDeleted.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                    row.CreateCells(dgQuotationAddedItems);
                    row.Cells[0].Value = item.dgNo;
                    row.Cells[7].Value = item.ItemCode;
                    row.Cells[15].Value = item.Qty;
                    row.Cells[22].Value = item.UCUPCurr;
                    row.Cells[20].Value = item.dgUPIME;
                    row.Cells[21].Value = item.Disc;
                    row.Cells[23].Value = item.Total;
                    row.Cells[24].Value = item.TargetUP;
                    row.Cells[25].Value = item.Competitor;
                    row.Cells[30].Value = item.Qty;
                    row.Cells[29].Value = item.CustomerStockCode;
                    dgQuotationAddedItems.Rows.Add(row);
                    
                }
            }
            //ItemDetailsFiller(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString()); 
             for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                GetQuotationQuantity(i);
                GetLandingCost(i);
            }
            GetAllMargin();
            #endregion
            //buradaki yazılanların sırası önemli sırayı değiştirmeyin
            lblsubtotal.Text = q.SubTotal.ToString();
            txtTotalDis2.Text = q.DiscOnSubTotal2.ToString();
            txtExtraChanges.Text = q.ExtraCharges.ToString();
            lblVat.Text = q.VatValue.ToString();
            if (q.IsVatValue == 1) { chkVat.Checked = true; } else { chkVat.Checked = false; }
            //
            if (q.IsItemCost == 1) { ckItemCost.Checked = true; } else { ckItemCost.Checked = false; }
            if (q.IsWeightCost == 1) { ckWeightCost.Checked = true; } else { ckWeightCost.Checked = false; }
            if (q.IsCustomsDuties == 1) { ckCustomsDuties.Checked = true; } else { ckCustomsDuties.Checked = false; }
            //Buraya Curr verileri gelecek
            #endregion
            if (dgQuotationAddedItems.RowCount > 1)
            {
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();
            }
            else { dgQuotationAddedItems.Rows[0].Cells[0].Value = 1.ToString(); }
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
            #region Filler
            decimal CurrValueWeb = Decimal.Parse(curr.RateBuy.ToString());
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
                if (h.Environment != null) { txtEnvironment.Text = "Y"; }
                if (h.Lithium != null) { txtLithium.Text = "Y"; }
                if (h.Shipping != null) { txtShipping.Text = "Y"; }
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

            if (txtLithium.Text != "")
            {
                label64.BackColor = Color.Red;
                dgQuotationAddedItems.Rows[RowIndex].Cells["LI"].Style.BackColor = Color.Ivory;


            }
            if (txtShipping.Text != "")
            {
                label63.BackColor = Color.Red;
                dgQuotationAddedItems.Rows[RowIndex].Cells["HS"].Style.BackColor = Color.Red;

            }
            if (txtEnvironment.Text != "")
            {
                label53.BackColor = Color.Red;
            }
            if (txtCalibrationInd.Text != "" && txtCalibrationInd.Text != null && txtCalibrationInd.Text != "N")
            {
                label22.BackColor = Color.Red;
                dgQuotationAddedItems.Rows[RowIndex].Cells["CL"].Style.BackColor = Color.Green;
            }

            if (txtLicenceType.Text != "" && txtLicenceType.Text != null)
            {
                dgQuotationAddedItems.Rows[RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
            }
            #endregion
        }

        private void cbCurrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbCurrType.SelectedIndex != null))
            {
                GetCurrency(dtpDate.Value);
                ChangeCurr();
            }
            else
            {
                MessageBox.Show("You Must Choose a Curr Type");
                cbCurrType.SelectedIndex = 0;
            }
        }

        private void GetCurrency(DateTime date)
        {
            if (cbCurrency.SelectedIndex >= 0)
            {
                curr = IME.Rates.Where(a => a.rate_date == date.Date).ToList().Where(b => b.CurType == (cbCurrency.SelectedItem as Rate).CurType).FirstOrDefault();
                if (cbCurrType.SelectedText == "Buy" || cbCurrType.SelectedIndex == 0)
                {
                    if (CurrValue1 != CurrValue) CurrValue1 = CurrValue;
                    CurrValue = Decimal.Parse(curr.RateBuy.ToString());
                }
                else if (cbCurrType.SelectedIndex == 1)
                {
                    if (CurrValue1 != CurrValue) CurrValue1 = CurrValue;
                    CurrValue = Decimal.Parse(curr.RateBuyEffective.ToString());
                }
                else if (cbCurrType.SelectedIndex == 2)
                {
                    if (CurrValue1 != CurrValue) CurrValue1 = CurrValue;
                    CurrValue = Decimal.Parse(curr.RateSell.ToString());
                }
                else if (cbCurrType.SelectedIndex == 3)
                {
                    if (CurrValue1 != CurrValue) CurrValue1 = CurrValue;
                    CurrValue = Decimal.Parse(curr.RateSellEffective.ToString());
                }
            }
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurrency.SelectedIndex != null && cbCurrency.DataSource!=null)
            {
                GetCurrency(dtpDate.Value);
                ChangeCurr();
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
                }
                SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString()), Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())));
                st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[rowindex].Cells[0].Value.ToString()))).FirstOrDefault();
                lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st.Item2).ToString();
            }

        }

        private string GetCurrencySign()
        {
            string cur = "";
            switch (cbCurrency.Text)
            {
                case "USD":
                    cur = "$";
                    break;
                case "GBP":
                    cur = "£";
                    break;
                case "EUR":
                    cur = "€";
                    break;
            }
            return cur;
        }

        private void ChangeCurr()
        {
            lblWeb.Text = "Web (" + GetCurrencySign() + ")";
            decimal SubTotalTotal = 0;
            if (CurrValue1 !=CurrValue) { Currfactor = CurrValue / CurrValue1; } else { Currfactor = 1; }
            #region ChangeWebValues
            if (txtWeb1.Text!="" && txtWeb1.Text != null) {
                txtWeb1.Text = (Decimal.Parse(txtWeb1.Text) / Currfactor).ToString();
                txtWeb2.Text = (Decimal.Parse(txtWeb2.Text) / Currfactor).ToString();
                txtWeb3.Text = (Decimal.Parse(txtWeb3.Text) / Currfactor).ToString();
                txtWeb4.Text = (Decimal.Parse(txtWeb4.Text) / Currfactor).ToString();
                txtWeb5.Text = (Decimal.Parse(txtWeb5.Text) / Currfactor).ToString(); }
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

                        q1 = DateTime.Now.Year.ToString()+"/"+quoID.ToString();
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
                    QuotationSave(txtQuotationNo.Text);
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
            int row= dgQuotationAddedItems.CurrentCell.RowIndex;
            while (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[currindex].ReadOnly == true)
            {
                if (currindex == 35)
                {
                    if (currindex == 15 && dgQuotationAddedItems.Rows[row].Cells[15].Value == null) break;
                    if (dgQuotationAddedItems.RowCount - 1 == row)
                    {
                        DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                        dgQuotationAddedItems.Rows.Add(dgRow);
                    }
                    currindex = 6;
                    row++;
                }
                else
                {
                    if (currindex == 16 && dgQuotationAddedItems.Rows[row].Cells[15].Value == null) break;
                    currindex++;
                }
            }
            try
            {
                dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[row].Cells[currindex];
            }
            catch { }
        }

        private void ChangeCurrnetCellTabKey(int currindex)
        {
            int row = dgQuotationAddedItems.CurrentCell.RowIndex;
            while (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[currindex].ReadOnly == true)
            {
                if (currindex == 35)
                {
                    
                    if (dgQuotationAddedItems.RowCount - 1 == row)
                    {
                        DataGridViewRow dgRow = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                        dgQuotationAddedItems.Rows.Add(dgRow);
                    }
                    currindex = 6;
                    row++;
                }
                else {
                    if (currindex == 16 && dgQuotationAddedItems.Rows[row].Cells[15].Value == null) break;
                    currindex++;
                }
            }
            try
            {
                 dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[row].Cells[currindex-1]; 
            }
            catch { }
            //while (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[currindex].ReadOnly == true)
            //{
            //    currindex++;
            //}
            //try
            //{
            //    dgQuotationAddedItems.CurrentCell = dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells[currindex - 1];
            //}
            //catch { }
        }

        private void dgQuotationAddedItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                ChangeCurrnetCellTabKey(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
            }
            else if ((e.KeyCode == Keys.Escape))
            {
                ChangeCurrnetCell(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ChangeCurrnetCell(dgQuotationAddedItems.CurrentCell.ColumnIndex + 1);
                SendKeys.Send("{UP}");
            }
        }

        private void btnViewMore_Click(object sender, EventArgs e)
        {
            if (CustomerCode.Text == null|| CustomerCode.Text == string.Empty)
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
            QuotationExcelExport.Export(dgQuotationAddedItems,txtQuotationNo.Text);
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
            totalDis2Change();

            if (txtTotalDis2.Text != null && txtTotalDis2.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtTotalDis2.Text);
                sonuc = Math.Round(sonuc, 4);
                txtTotalDis2.Text = sonuc.ToString();
            }
        }

        private void txtTotalDis2_Click(object sender, EventArgs e)
        {
            if (txtTotalDis2.Text != null && txtTotalDis2.Text != "")
            {
                decimal sonuc = Decimal.Parse(txtTotalDis2.Text);
                txtTotalDis2.Text = sonuc.ToString();
            }
        }

        private void txtTotalDis_Leave(object sender, EventArgs e)
        {
            if (lblsubtotal.Text != "" && Decimal.Parse(lblsubtotal.Text) != 0 && lblsubtotal.Text != null
                && txtTotalDis.Text != "" && Decimal.Parse(txtTotalDis.Text) != 0)
            {
                decimal dis2 = Decimal.Parse(lblsubtotal.Text) * Decimal.Parse(txtTotalDis.Text) / 100;

                txtTotalDis2.Text = dis2.ToString();
                for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                {
                    if (dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value == null || dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value.ToString() == 0.ToString())
                    {
                        dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value = txtTotalDis.Text;
                    }
                }
                totalDis2Change();

                if (txtTotalDis.Text != null && txtTotalDis.Text != "")
                {
                    decimal sonuc = Decimal.Parse(txtTotalDis.Text);
                    sonuc = Math.Round(sonuc, 4);
                    txtTotalDis.Text = sonuc.ToString();
                }
            }
        }

        private void txtTotalDis_Click(object sender, EventArgs e)
        {
            if (txtTotalDis.Text != null && txtTotalDis.Text!="")
            {
            decimal sonuc = Decimal.Parse(txtTotalDis.Text);
            txtTotalDis.Text = sonuc.ToString();
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
            cbCurrency.DataSource = IME.Rates.Where(a => a.rate_date == dtpDate.Value).ToList();
            cbCurrency.DisplayMember = "CurType";
            cbCurrency.ValueMember = "ID";

            GetAllMargin();
        }

        private bool GetUserAutorities(int AuthorizationID)
        {
            List<AuthorizationValue> UserAutorityList = Utils.getCurrentUser().AuthorizationValues.ToList();
            if (UserAutorityList.Where(a=>a.AuthorizationID== AuthorizationID).FirstOrDefault()!=null)
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

        private void dgQuotationAddedItems_DoubleClick(object sender, EventArgs e)
        {
            string item_code;

            item_code= dgQuotationAddedItems.CurrentRow.Cells["dgProductCode"].Value.ToString();

            if (item_code == null || item_code == string.Empty)
            {
                MessageBox.Show("Please Enter a Item Code", "Eror !");
            }
            else
            {
                ViewProductHistory f = new ViewProductHistory(item_code);
                f.ShowDialog();
            }
        }
    }
}
    