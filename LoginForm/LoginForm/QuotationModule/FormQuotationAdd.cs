using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;
using LoginForm.Services;


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
        decimal factor = 1;
        decimal CurrentDis;
        decimal LowMarginLimit;
        decimal CurrentExraChange;
        #endregion

        bool modifyMod = false;

        public FormQuotationAdd()
        {
            InitializeComponent();
        }

        public FormQuotationAdd(Quotation quotation)
        {
            //Son versiyonu açmayı sağlıyor
            Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(quotation.QuotationNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();

            this.Text = "Edit Quotation";
            modifyMod = true;
            InitializeComponent();
            cbCurrency.DataSource = IME.Rates.Where(a => a.rate_date == DateTime.Today.Date).ToList();
            cbCurrency.DisplayMember = "CurType";
            cbCurrency.ValueMember = "ID";
            cbCurrency.SelectedIndex = 0;
            CustomerCode.Enabled = false;
            modifyQuotation(q1);
        }

        private void QuotationForm_Load(object sender, EventArgs e)
        {
            if (!modifyMod)
            {
                txtQuotationNo.Text = NewQuotationID();
                dgQuotationAddedItems.Rows[0].Cells["dgQty"].Value = "0";
                dgQuotationAddedItems.Rows[0].Cells[0].Value = 1.ToString();
                LowMarginLimit = Decimal.Parse(IME.Managements.FirstOrDefault().LowMarginLimit.ToString());
                chkVat.Text = IME.Managements.FirstOrDefault().VAT.ToString();
                #region ComboboxFiller
                cbCurrency.DataSource = IME.Rates.Where(a => a.rate_date == DateTime.Today.Date).ToList();
                cbCurrency.DisplayMember = "CurType";
                cbCurrency.ValueMember = "ID";
                cbCurrency.SelectedIndex = 0;
                cbCurrType.SelectedIndex = 0;
                cbPayment.DataSource = IME.PaymentMethods.ToList();
                cbPayment.DisplayMember = "Payment";
                cbPayment.ValueMember = "ID";
                cbRep.DataSource = IME.Workers.ToList();
                cbRep.DisplayMember = "NameLastName";
                cbCurrType.SelectedIndex = 0;
                dtpDate.Value = DateTime.Now;
                GetCurrency();
                #endregion
            }
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

                cbCurrency.SelectedIndex = cbCurrency.FindStringExact(c.CurrNameQuo);
                cbCurrType.SelectedIndex = cbCurrType.FindStringExact(c.CurrTypeQuo);
                if (c.paymentmethodID != null)
                {
                    cbPayment.SelectedIndex = cbPayment.FindStringExact(c.PaymentMethod.Payment);
                }
                try { txtContactNote.Text = c.CustomerWorker.Note.Note_name; } catch { }
                try { txtCustomerNote.Text = c.Note.Note_name; } catch { }
                cbRep.SelectedIndex = cbRep.FindStringExact(c.Worker.NameLastName.ToString());
            }
        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMain f = new CustomerMain(true, CustomerCode.Text);
            f.Show();
        }

        private void customerDetailsNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CustomerMain f = new CustomerMain(true, txtCustomerName.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.Show();
                this.Close();
            }
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
                                    if (i <= Quotation.Count - 1)
                                    {

                                        dgQuotationAddedItems.Rows[i].Cells[0].Value = (i).ToString();
                                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                                        decimal stPrice = st.Item2;
                                        SubTotal.Remove(st);
                                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()), stPrice));
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region RowChange2
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()) >= Int32.Parse(dgQuotationAddedItems.CurrentCell.Value.ToString()) && currentID != i && dgQuotationAddedItems.CurrentCell.RowIndex > i)
                                {
                                    if (i <= Quotation.Count - 1)
                                    {
                                        dgQuotationAddedItems.Rows[i].Cells[0].Value = (i + 2).ToString();
                                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                                        decimal stPrice = st.Item2;
                                        SubTotal.Remove(st);
                                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()), stPrice));
                                    }
                                }
                                #endregion
                            }

                        }
                    }
                    #endregion
                    // if (dataGridView3.CurrentCell.RowIndex != 0) { dataGridView3.CurrentCell.Value = (dataGridView3.CurrentCell.RowIndex + 1).ToString(); }
                    dgQuotationAddedItems.Sort(dgQuotationAddedItems.Columns[0], ListSortDirection.Ascending);
                    break;
                case 7://PRODUCT CODE
                    {
                        #region PRODUCT CODE

                        if (dgQuotationAddedItems.CurrentCell.Value != null)
                        {
                            if (dgQuotationAddedItems.CurrentCell.Value.ToString().Contains("-")) { dgQuotationAddedItems.CurrentCell.Value = dgQuotationAddedItems.CurrentCell.Value.ToString().Replace("-", string.Empty).ToString(); }
                            if (dgQuotationAddedItems.CurrentCell.Value != null && dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 6 || (dgQuotationAddedItems.CurrentCell.Value.ToString().Contains("P") && dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 7)) { dgQuotationAddedItems.CurrentCell.Value = 0.ToString() + dgQuotationAddedItems.CurrentCell.Value.ToString(); }
                            var sd = classQuotationAdd.ItemGetSuperDisk(dgQuotationAddedItems.CurrentCell.Value.ToString());
                            var sdp = classQuotationAdd.ItemGetSuperDiskP(dgQuotationAddedItems.CurrentCell.Value.ToString());
                            var er = classQuotationAdd.ItemGetExtendedRange(dgQuotationAddedItems.CurrentCell.Value.ToString());
                            int sdNumber; int sdPNumber; int erNumber;
                            try { sdNumber = IME.SuperDisks.Where(a => a.Article_No.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdNumber = 0; }
                            try { sdPNumber = IME.SuperDiskPs.Where(a => a.Article_No.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { sdPNumber = 0; }
                            try { erNumber = IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(dgQuotationAddedItems.CurrentCell.Value.ToString())).ToList().Count; } catch { erNumber = 0; }
                            if (sdNumber != 0 || sdPNumber != 0 || erNumber != 0)
                            {
                                if (classQuotationAdd.NumberofItem(dgQuotationAddedItems.CurrentCell.Value.ToString()) == 0 && ((dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 6 || (dgQuotationAddedItems.CurrentCell.Value.ToString().Contains("P") && dgQuotationAddedItems.CurrentCell.Value.ToString().Length == 7))))
                                {
                                    
                                    if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
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
                                        if (classQuotationAdd.NumberofItem(dgQuotationAddedItems.CurrentCell.Value.ToString()) == 0)
                                        {
                                            //ItemClear();
                                            if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
                                            ItemDetailsFiller(dgQuotationAddedItems.CurrentCell.Value.ToString());
                                            //LandingCost Calculation
                                            FillProductCodeItem();
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
                    break;
                case 15://QAUANTITY
                    #region Quantity
                    {
                        GetQuotationQuantity(dgQuotationAddedItems.CurrentCell.RowIndex);

                    }
                    //LOW MARGIN
                    GetMarginMark();
                    //
                    //TotalDis();
                    break;
                #endregion
                case 22://total 
                    {
                        #region Total
                        decimal total = decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString());
                        decimal UcupIME = decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString());
                        dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgDisc"].Value = String.Format("{0:0.0000}", ((UcupIME - total) * (decimal)100 / UcupIME));
                        GetMargin();
                        GetMarginMark();
                        CalculateSubTotal();
                        #endregion
                    }
                    break;
            }
            #endregion
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
                        GetLandingCost(rowindex);
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

                        dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = price;




                        if (dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value != null) { discResult = (discResult - (discResult * decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgDisc"].Value.ToString()) / 100)); }
                        dgQuotationAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = discResult.ToString("G29");
                        GetMargin();
                        ChangeCurr(rowindex);
                        //CalculateSubTotal();
                    }

                    #endregion
                }
                catch { }
                #endregion

            }
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
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString())) / CurrValue))) * 100).ToString("G29");

                }
                else
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString()) / Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())) / CurrValue))) * 100).ToString("G29");

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
                        dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString())) / CurrValue))) * 100).ToString("G29");
                    }
                }
                catch { }

            }

            #endregion

        }

        private void FillProductCodeItem()
        {
            #region FillProductCodeItem
            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.CurrentCell.Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked)).ToString("G29");
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
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgPackType"].Value = sdP.Calibration_Ind;

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
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["MPN"].Value = sdP.MPN;
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

        private void CustomerCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerCode_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                classQuotationAdd.customersearchID = CustomerCode.Text;
                classQuotationAdd.customersearchname = "";
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch();
                this.Enabled = false;
                form.ShowDialog();
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
            try { 
            if (dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value != null) {
                txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())).ToString();
            }
            }
            catch { }

        }

        private void dataGridView3_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {  
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();

        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            ItemClear();
            try { ItemDetailsFiller(dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString()); } catch { }
        }

        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
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
                dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[Rowindex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked)).ToString("G29");
            }
            catch { }

        }

        private void getQuotationValues()
        {
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                GetLandingCost(i);
                GetQuotationQuantity(i);
                try
                {
                    #region Get Margin
                    if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null)
                    {
                        dgQuotationAddedItems.Rows[i].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString())) / CurrValue))) * 100).ToString("G29");
                    }
                    #endregion
                }
                catch { }
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

        private void txtExtraChanges_TextChanged(object sender, EventArgs e)
        {
            decimal ExtraCharge = 0;
            try { ExtraCharge = Decimal.Parse(txtExtraChanges.Text); } catch { }
            lblTotalExtra.Text = (ExtraCharge + Decimal.Parse(lbltotal.Text) - CurrentExraChange).ToString();
            CurrentExraChange = ExtraCharge;
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

            if (dgQuotationDeleted.Rows[rowindex].Cells["dgProductCode1"].Value != null)
            {
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

        private void txtTotalDis2_Leave(object sender, EventArgs e)
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
                    txtTotalDis.Text = ((CurrentDis * 100) / Decimal.Parse(lblsubtotal.Text)).ToString();
                }
            }
            else
            {
                txtTotalDis2.Text = "";
            }
        }

        private void txtTotalDis_Leave(object sender, EventArgs e)
        {
            if (Decimal.Parse(lblsubtotal.Text) != 0 && lblsubtotal.Text != "" && lblsubtotal.Text != null)
            {
                decimal dis2 = Decimal.Parse(lblsubtotal.Text) * Decimal.Parse(txtTotalDis.Text) / 100;
                if (dis2 != CurrentDis)
                {
                    txtTotalDis2.Text = dis2.ToString();
                    for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                    {
                        try
                        {
                            dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["dgDisc"].Value = decimal.Parse(txtTotalDis.Text);
                            GetQuotationQuantity(i);
                        }
                        catch { }
                    }
                }
            }
            else
            {
                txtTotalDis.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            QuotationSave();
            QuotationDetailsSave();


        }

        private void QuotationSave()
        {
            try
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
               
                IME.Quotations.Add(q);
                IME.SaveChanges();
            }
            catch
            {

                MessageBox.Show("Error Occured", "Failure");
            }

        }
        private void QuotationSave(string QuoNo)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                Quotation q1 = IME.Quotations.Where(a => a.QuotationNo.Contains(QuoNo)).OrderByDescending(b => b.QuotationNo).FirstOrDefault();



                if (q1.QuotationNo.Contains("v"))
                {
                    int quoID = Int32.Parse(q1.QuotationNo.Substring(q1.QuotationNo.LastIndexOf('v') + 1))+1;
                txtQuotationNo.Text = (q1.QuotationNo.Substring(q1.QuotationNo.IndexOf('v') + 1) + quoID).ToString();
                    int charLocation = q1.QuotationNo.IndexOf("v", StringComparison.Ordinal);

                    if (charLocation > 0)
                    {
                    txtQuotationNo.Text = txtQuotationNo.Text.Substring(0, charLocation) + quoID.ToString();
                    }
                    
                  
                }
                else
                {
                txtQuotationNo.Text = q1.QuotationNo + "v1";
                }
               
               
                Quotation q = new Quotation();
                 q.QuotationNo= txtQuotationNo.Text;
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
                try
                {
                    q.CurrType = cbCurrType.SelectedText;
            }
            catch { }
                try
                {
                    q.Curr = CurrValue;
        } catch { }
                try { q.CustomerID = CustomerCode.Text;} catch { }

                IME.Quotations.Add(q);
                IME.SaveChanges();
            }
            catch
            {

                MessageBox.Show("Error Occured", "Failure");
            }

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
                try { qd.Disc = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgDisc"].Value.ToString()); } catch { }
                try { qd.Total = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString()); } catch { }
                try { qd.TargetUP = Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTargetUP"].Value.ToString()); } catch { }
                try { qd.Competitor = dgQuotationAddedItems.Rows[i].Cells["dgCompetitor"].Value.ToString(); } catch { }
                try { qd.CustomerDescription = dgQuotationAddedItems.Rows[i].Cells["dgCustDescription"].Value.ToString(); } catch { }
                try { qd.CustomerStockCode = dgQuotationAddedItems.Rows[i].Cells["dgCustStkCode"].Value.ToString(); }
                catch { }
                    try
                    {
                        IME.QuotationDetails.Add(qd);
                        IME.SaveChanges();
                        
                    }
                    catch
                    {
                        MessageBox.Show("Error Occured", "Failure");
                        this.Close();
                    }
                    
                }
                
            }

            for (int i = 0; i < dgQuotationDeleted.RowCount; i++)
            {
                if (dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value != null)
                {
                    QuotationDetail qd = new QuotationDetail();
                qd.RFQNo = txtRFQNo.Text;
                try { qd.dgNo = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["No1"].Value.ToString()); } catch { }
                try
                {
                    qd.ItemCode = dgQuotationDeleted.Rows[i].Cells["dgProductCode1"].Value.ToString();
                }
                catch { }
                try
                {
                    qd.Qty = Int32.Parse(dgQuotationDeleted.Rows[i].Cells["dgQty1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.UCUPCurr = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgUCUPCurr1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.Disc = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgDisc1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.Total = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgTotal1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.TargetUP = Decimal.Parse(dgQuotationDeleted.Rows[i].Cells["dgTargetUP1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.Competitor = dgQuotationDeleted.Rows[i].Cells["dgCompetitor1"].Value.ToString();
                }
                catch { }
                try
                {
                    qd.CustomerDescription = dgQuotationDeleted.Rows[i].Cells["dgCustDescription1"].Value.ToString();
                }
                catch { }
                try
                {
                    qd.CustomerStockCode = dgQuotationDeleted.Rows[i].Cells["dgCustomerStokCode1"].Value.ToString();
                }
                catch { }
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
            fillCustomer();
            #region QuotationDetails
            cbCurrency.SelectedItem = q.CurrName;
            cbCurrType.SelectedItem = q.CurrType;
            foreach (var item in q.QuotationDetails)
            {
                if (item.IsDeleted == 1)
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationDeleted.Rows[0].Clone();
                    row.Cells[0].Value = item.dgNo;
                    row.Cells[7].Value = item.ItemCode;
                    row.Cells[15].Value = item.Qty;
                    row.Cells[22].Value = item.UCUPCurr;
                    row.Cells[21].Value = item.Disc;
                    row.Cells[23].Value = item.Total;
                    row.Cells[24].Value = item.TargetUP;
                    row.Cells[25].Value = item.Competitor;
                    row.Cells[29].Value = item.Qty;
                    row.Cells[30].Value = item.CustomerStockCode;
                    dgQuotationDeleted.Rows.Add(row);
                    QuotataionModifyItemDetailsFiller(item.ItemCode, dgQuotationAddedItems.RowCount - 2);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                    row.CreateCells(dgQuotationAddedItems);
                    row.Cells[0].Value = item.dgNo;
                    row.Cells[7].Value = item.ItemCode;
                    row.Cells[15].Value = item.Qty;
                    row.Cells[22].Value = item.UCUPCurr;
                    row.Cells[21].Value = item.Disc;
                    row.Cells[23].Value = item.Total;
                    row.Cells[24].Value = item.TargetUP;
                    row.Cells[25].Value = item.Competitor;
                    row.Cells[30].Value = item.Qty;
                    row.Cells[29].Value = item.CustomerStockCode;
                    dgQuotationAddedItems.Rows.Add(row);
                    QuotataionModifyItemDetailsFiller(item.ItemCode, dgQuotationAddedItems.RowCount - 2);
                }
            }
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
            //if(Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[0].Value.ToString())> Int32.Parse(dgQuotationDeleted.Rows[dgQuotationDeleted.RowCount - 2].Cells[0].Value.ToString()))
            //{
            //dgQuotationAddedItems.Rows.Add(new DataGridViewRow());
                dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount-1].Cells[0].Value = (Int32.Parse(dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();

            //}
            //else
            //{
            //    dgQuotationAddedItems.Rows[dgQuotationAddedItems.RowCount - 1].Cells[0].Value = (Int32.Parse(dgQuotationDeleted.Rows[dgQuotationDeleted.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();

            //}

        }

        private void QuotataionModifyItemDetailsFiller(string ArticleNoSearch, int RowIndex)
        {

            #region Filler
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
                dgQuotationAddedItems.Rows[RowIndex].Cells["dgPackType"].Value = sdP.Calibration_Ind;

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
                dgQuotationAddedItems.Rows[RowIndex].Cells["MPN"].Value = sdP.MPN;
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
                GetCurrency();
                ChangeCurr();
            }
            else
            {
                MessageBox.Show("You Must Choose a Curr Type");
                cbCurrType.SelectedIndex = 0;
            }
        }

        private void GetCurrency()
        {
            curr = IME.Rates.Where(a => a.rate_date == DateTime.Today.Date).ToList().Where(b => b.CurType == (cbCurrency.SelectedItem as Rate).CurType).FirstOrDefault();
            if (cbCurrType.SelectedText == "Buy" || cbCurrType.SelectedIndex == 0)
            {
                if (CurrValue1 != CurrValue) CurrValue1 = CurrValue;
                CurrValue = Decimal.Parse(curr.RateBuy.ToString());
            }
            else if (cbCurrType.SelectedText == "Eff. Buy" || cbCurrType.SelectedIndex == 1)
            {
                if (CurrValue1 != Decimal.Parse(curr.RateBuy.ToString())) CurrValue1 = CurrValue;
                CurrValue = Decimal.Parse(curr.RateBuyEffective.ToString());
            }
            else if (cbCurrType.SelectedText == "Sale" || cbCurrType.SelectedIndex == 2)
            {
                if (CurrValue1 != Decimal.Parse(curr.RateBuy.ToString())) CurrValue1 = CurrValue;
                CurrValue = Decimal.Parse(curr.RateSell.ToString());
            }
            else if (cbCurrType.SelectedText == "Eff. Sale" || cbCurrType.SelectedIndex == 3)
            {
                if (CurrValue1 != Decimal.Parse(curr.RateBuy.ToString())) CurrValue1 = CurrValue;
                CurrValue = Decimal.Parse(curr.RateSellEffective.ToString());
            }
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurrency.SelectedIndex != null)
            {
                GetCurrency();
                ChangeCurr();
            }
            else
            {
                MessageBox.Show("You Must Choose a Curr Name");
                cbCurrency.SelectedIndex = 0;
            }
        }
        private void ChangeCurr(int rowindex)
        { 
            if (dgQuotationAddedItems.Rows[rowindex].Cells["dgQty"].Value != null)
            {
                
                dgQuotationAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUCUPCurr"].Value.ToString())) / factor).ToString();
                dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgUPIME"].Value.ToString())) / factor).ToString();
                dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[rowindex].Cells["dgTotal"].Value.ToString())) / factor).ToString();
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
        private void ChangeCurr()
        {
            decimal SubTotalTotal = 0;
            if (CurrValue1 != Decimal.Parse(curr.RateBuy.ToString())) factor = CurrValue / CurrValue1;
            for (int i = 0; i < dgQuotationAddedItems.RowCount - 1; i++)
            {
                try
                {
                    #region Get Margin
                    if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null)
                    {
                        dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUCUPCurr"].Value.ToString())) / factor).ToString();
                        dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgUPIME"].Value.ToString())) / factor).ToString();
                        dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value = ((Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())) / factor).ToString();
                        var st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()))).FirstOrDefault();
                        SubTotal.Remove(st);
                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()), Decimal.Parse(dgQuotationAddedItems.Rows[i].Cells["dgTotal"].Value.ToString())));
                        st = SubTotal.Where(a => a.Item1 == (Int32.Parse(dgQuotationAddedItems.Rows[i].Cells[0].Value.ToString()))).FirstOrDefault();
                        SubTotalTotal += st.Item2;
                    }
                    #endregion
                }
                catch { }
            }
            lblsubtotal.Text = SubTotalTotal.ToString();
            //lblsubtotal.Text = SubTotalTotal.ToString("G29");

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

        //private void FormQuotationAdd_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F2)
        //    {
        //        QuotationSave();
        //        QuotationDetailsSave();
        //    }
        //    else if (e.KeyCode == Keys.F3)
        //    {
        //        FormMain f = new FormMain();
        //        if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //        {
        //            f.Show();
        //            this.Close();
        //        }
        //    }
        //}
        private string NewQuotationID()
        {
            IMEEntities IME = new IMEEntities();
            //List<Quotation> quotList = IME.Quotations.Where(q => q.QuotationNo == DateTime.Now.Year).toList();
            int ID;
            Quotation quo = IME.Quotations.OrderByDescending(q => q.QuotationNo).FirstOrDefault();
            string q1="";
               q1 = quo.QuotationNo;
                if (quo.QuotationNo.Contains("v"))
                {
                int quoID= Int32.Parse(q1.Substring(quo.QuotationNo.LastIndexOf('/') + 1, (quo.QuotationNo.LastIndexOf('v') + 1)-(quo.QuotationNo.LastIndexOf('/') + 1)-1))+1;

                    q1 = (quo.QuotationNo.Substring(0,quo.QuotationNo.IndexOf('/')+1)).ToString();

                q1 = q1 + quoID.ToString();
                    
                }
            //if (q1 != null&& q1!="")
            //{
            //    ID = Convert.ToInt32(q1.Substring(quo.QuotationNo.LastIndexOf('/')));
            //    ID++;
            //}
            //else { ID = 1; }


            //string qNo = DateTime.Now.Year.ToString() + "/" + ID.ToString();

            return q1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuotationSave(txtQuotationNo.Text);
            QuotationDetailsSave();
        }
    }
}