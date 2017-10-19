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
        decimal CurrentDis = 0;
        #endregion

        public FormQuotationAdd()
        {
            InitializeComponent();
        }

        public FormQuotationAdd(Quotation quotation)
        {
            InitializeComponent();
            modifyQuotation(quotation);
        }

        private void QuotationForm_Load(object sender, EventArgs e)
        {

            dataGridView3.Rows[0].Cells["dgQty"].Value = "0";
            dataGridView3.Rows[0].Cells[0].Value = 1.ToString();
            #region ComboboxFiller
            //cbFactor.DataSource = IME.Rates.ToList();
            //cbFactor.DisplayMember = "currency";
            //cbFactor.ValueMember = "ID";
            cbCurrency.DataSource = IME.Rates.Where(a => a.rate_date == DateTime.Today.Date).ToList();
            cbCurrency.DisplayMember = "CurType";
            cbCurrency.ValueMember = "ID";
            cbPayment.DataSource = IME.PaymentMethods.ToList();
            cbPayment.DisplayMember = "Payment";
            cbPayment.ValueMember = "ID";
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "FirstName";

            dtpDate.Value = DateTime.Now;
            #endregion
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

            CustomerCode.Text = classQuotationAdd.customerID;
            txtCustomerName.Text = classQuotationAdd.customername;
            var c = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();

            if (c.rate_ID != null)
            {
                cbFactor.Text = c.Rate.currency.ToString();
                cbCurrency.SelectedIndex = cbCurrency.FindStringExact(c.Rate.currency.ToString());
            }
            if (c.paymentmethodID != null)
            {
                cbPayment.SelectedIndex = cbPayment.FindStringExact(c.PaymentMethod.Payment);
            }
            try { txtContactNote.Text = c.CustomerWorker.Note.Note_name; } catch { }
            try { txtCustomerNote.Text = c.Note.Note_name; } catch { }
            cbRep.SelectedIndex = cbRep.FindStringExact(c.Worker.NameLastName.ToString());
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
            switch (dataGridView3.CurrentCell.ColumnIndex)
            {
                case 0:
                    #region ID Atama
                    if (Int32.Parse(dataGridView3.CurrentCell.Value.ToString()) <= Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[0].Value.ToString()))
                    {
                        int currentID = dataGridView3.CurrentCell.RowIndex;
                        List<int> Quotation = new List<int>();
                        for (int i = 0; i < dataGridView3.RowCount; i++)
                        {
                            Quotation.Add(Int32.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString()));
                        }
                        for (int i = 0; i < dataGridView3.RowCount; i++)
                        {
                            if (dataGridView3.CurrentCell.RowIndex < Int32.Parse(dataGridView3.CurrentCell.Value.ToString()))
                            {
                                #region RowChange1
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Int32.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString()) <= Int32.Parse(dataGridView3.CurrentCell.Value.ToString()) && currentID != i && dataGridView3.CurrentCell.RowIndex < i)
                                {
                                    if (i <= Quotation.Count - 1)
                                    {

                                        dataGridView3.Rows[i].Cells[0].Value = (i).ToString();
                                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                                        decimal stPrice = st.Item2;
                                        SubTotal.Remove(st);
                                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString()), stPrice));
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region RowChange2
                                //Üstteki bir row u aşşağıya getirmek için
                                if (Int32.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString()) >= Int32.Parse(dataGridView3.CurrentCell.Value.ToString()) && currentID != i && dataGridView3.CurrentCell.RowIndex > i)
                                {
                                    if (i <= Quotation.Count - 1)
                                    {
                                        dataGridView3.Rows[i].Cells[0].Value = (i + 2).ToString();
                                        var st = SubTotal.Where(a => a.Item1 == Int32.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString())).FirstOrDefault();
                                        decimal stPrice = st.Item2;
                                        SubTotal.Remove(st);
                                        SubTotal.Add(new Tuple<int, decimal>(Int32.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString()), stPrice));
                                    }
                                }
                                #endregion
                            }

                        }
                    }
                    #endregion
                    // if (dataGridView3.CurrentCell.RowIndex != 0) { dataGridView3.CurrentCell.Value = (dataGridView3.CurrentCell.RowIndex + 1).ToString(); }
                    dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Ascending);
                    break;
                case 7://PRODUCT CODE
                    {
                        #region PRODUCT CODE
                        if (dataGridView3.CurrentCell.Value.ToString().Contains("-")) { dataGridView3.CurrentCell.Value = dataGridView3.CurrentCell.Value.ToString().Replace("-", string.Empty).ToString(); }
                        if (dataGridView3.CurrentCell.Value != null && dataGridView3.CurrentCell.Value.ToString().Length == 6) { dataGridView3.CurrentCell.Value = 0.ToString() + dataGridView3.CurrentCell.Value.ToString(); }
                        #region Product Code
                        if (dataGridView3.CurrentCell.Value != null)
                        {
                            var sd = classQuotationAdd.ItemGetSuperDisk(dataGridView3.CurrentCell.Value.ToString());
                            var sdp = classQuotationAdd.ItemGetSuperDiskP(dataGridView3.CurrentCell.Value.ToString());
                            var er = classQuotationAdd.ItemGetExtendedRange(dataGridView3.CurrentCell.Value.ToString());
                            int sdNumber; int sdPNumber; int erNumber;
                            try { sdNumber = IME.SuperDisks.Where(a => a.Article_No.Contains(dataGridView3.CurrentCell.Value.ToString())).ToList().Count; } catch { sdNumber = 0; }
                            try { sdPNumber = IME.SuperDiskPs.Where(a => a.Article_No.Contains(dataGridView3.CurrentCell.Value.ToString())).ToList().Count; } catch { sdPNumber = 0; }
                            try { erNumber = IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(dataGridView3.CurrentCell.Value.ToString())).ToList().Count; } catch { erNumber = 0; }
                            if (sdNumber != 0 || sdPNumber != 0 || erNumber != 0)
                            {
                                if (classQuotationAdd.NumberofItem(dataGridView3.CurrentCell.Value.ToString()) == 0)
                                {
                                    //Bu item daha önceden eklimi diye kontrol ediyor  
                                    //                             DataGridViewRow row = dataGridView3.Rows
                                    //.Cast<DataGridViewRow>()
                                    //.Where(r => r.Cells["dgProductCode"].Value.ToString().Equals(dataGridView3.CurrentCell.Value.ToString()))
                                    //.FirstOrDefault();
                                    //                        if (row.Cells["dgUCUPCurr"].Value != null)
                                    //                        {
                                    //                            if (row != null) MessageBox.Show("There is already an item added this qoutation in the " + row.Cells["dgNo"].Value.ToString() + ". Row and the price " + row.Cells["dgUCUPCurr"].Value.ToString());

                                    //                        }
                                    //                        else
                                    //                        {
                                    //                            if (row != null) MessageBox.Show("There is already an item added this qoutation in the " + row.Cells["dgNo"].Value.ToString() + ". Row");

                                    //                        }
                                    if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
                                    //ItemClear();
                                    ItemDetailsFiller(dataGridView3.CurrentCell.Value.ToString());
                                    //LandingCost Calculation
                                    FillProductCodeItem();

                                }
                                else
                                {
                                    this.Enabled = false;
                                    FormQuotationItemSearch itemsearch = new FormQuotationItemSearch(dataGridView3.CurrentCell.Value.ToString());
                                    itemsearch.ShowDialog();
                                    try
                                    {
                                        //Bu item daha önceden eklimi diye kontrol ediyor  
                                        DataGridViewRow row = dataGridView3.Rows
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
                                    dataGridView3.CurrentCell.Value = classQuotationAdd.ItemCode;
                                    try { sdNumber = IME.SuperDisks.Where(a => a.Article_No.Contains(dataGridView3.CurrentCell.Value.ToString())).ToList().Count; } catch { sdNumber = 0; }
                                    try { sdPNumber = IME.SuperDiskPs.Where(a => a.Article_No.Contains(dataGridView3.CurrentCell.Value.ToString())).ToList().Count; } catch { sdPNumber = 0; }
                                    try { erNumber = IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(dataGridView3.CurrentCell.Value.ToString())).ToList().Count; } catch { erNumber = 0; }
                                    if (sdNumber == 1 || sdPNumber == 1 || erNumber == 1)
                                    {
                                        if (classQuotationAdd.NumberofItem(dataGridView3.CurrentCell.Value.ToString()) == 0)
                                        {
                                            //ItemClear();
                                            if (tabControl1.SelectedTab != tabItemDetails) { tabControl1.SelectedTab = tabItemDetails; }
                                            ItemDetailsFiller(dataGridView3.CurrentCell.Value.ToString());
                                            //LandingCost Calculation
                                            FillProductCodeItem();
                                            #region DataGridClear
                                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value = null;
                                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDisc"].Value = null;
                                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
                                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value = null;
                                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = null;
                                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgTotal"].Value = null;
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
                    }
                    #endregion
                    #endregion
                    break;
                case 15://QAUANTITY
                    #region Quantity
                    {
                        GetQuotationQuantity(dataGridView3.CurrentCell.RowIndex);

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
                        decimal total = decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString());
                        decimal UcupIME = decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString());
                        dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDisc"].Value = String.Format("{0:0.000}", ((UcupIME - total) * (decimal)100 / UcupIME));
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
                    if (Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString()) != 0)
                    {
                        #region Quantity
                        if (txtStandartWeight.Text != null && txtStandartWeight.Text != "")
                        {
                            txtGrossWeight.Text = (Decimal.Parse(txtStandartWeight.Text) * Decimal.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();
                            dataGridView3.Rows[rowindex].Cells["dgTotalWeight"].Value = txtGrossWeight.Text;
                        }
                        dataGridView3.Rows[rowindex].Cells["dgCost"].Value = classQuotationAdd.GetCost(dataGridView3.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString("G29");
                        price = Decimal.Parse((classQuotationAdd.GetPrice(dataGridView3.Rows[rowindex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString())) * Decimal.Parse(cbFactor.Text) * Decimal.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString("G29"));
                        decimal discResult = 0;
                        //Fiyat burada 
                        string articleNo = dataGridView3.Rows[rowindex].Cells["dgProductCode"].Value.ToString();
                        int isP = 0;
                        if (articleNo.ToUpper().IndexOf('P') != -1) { isP = 1; }

                        if (isP == 1)
                        {
                            if (IME.SuperDiskPs.Where(a => a.Article_No == articleNo).ToList().Count > 0)
                            {
                                if (IME.SuperDiskPs.Where(a => a.Article_No == articleNo).FirstOrDefault().Pack_Quantity > 1)
                                {


                                    if (Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgSSM"].Value.ToString()) > 1 && Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgUC"].Value.ToString()) == 1)
                                    {
                                        if ((Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgSSM"].Value.ToString())) != 0)
                                        {
                                            MessageBox.Show("Please enter a number that is a multiple of SSM");
                                            dataGridView3.Rows[rowindex].Cells["dgQty"].Value = "";

                                        }
                                        else
                                        {
                                            price = price / decimal.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString());
                                            dataGridView3.Rows[rowindex].Cells["dgUPIME"].Value = price / decimal.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString());
                                            dataGridView3.Rows[rowindex].Cells["dgTotal"].Value = price;
                                            //GetUCMargin();
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {

                            if (Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgUC"].Value.ToString()) > 1 && Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgSSM"].Value.ToString()) == 1)
                            {
                                int resultMod = (Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgUC"].Value.ToString()));
                                if ((resultMod != 0) || (Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString())) < Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgUC"].Value.ToString()))
                                {
                                    MessageBox.Show("Please enter a number that is a multiple of Unit Content");
                                    dataGridView3.Rows[rowindex].Cells["dgQty"].Value = "";
                                }
                                else
                                {
                                    price = price / decimal.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString());
                                    dataGridView3.Rows[rowindex].Cells["dgUPIME"].Value = price / decimal.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString());
                                    dataGridView3.Rows[rowindex].Cells["dgTotal"].Value = price;
                                    //GetUCMargin();
                                }
                            }
                        }
                        //TOTAL ve UPIME belirleniyor
                        //dataGridView3.Rows[rowindex].Cells["dgUPIME"].Value = (price / Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();

                        dataGridView3.Rows[rowindex].Cells["dgUPIME"].Value = (price / Int32.Parse(dataGridView3.Rows[rowindex].Cells["dgQty"].Value.ToString())).ToString();
                        discResult = decimal.Parse(dataGridView3.Rows[rowindex].Cells["dgUPIME"].Value.ToString());

                        dataGridView3.Rows[rowindex].Cells["dgTotal"].Value = (price).ToString();


                        if (dataGridView3.Rows[rowindex].Cells["dgDisc"].Value != null) { discResult = (discResult - (discResult * decimal.Parse(dataGridView3.Rows[rowindex].Cells["dgDisc"].Value.ToString()) / 100)); }
                        dataGridView3.Rows[rowindex].Cells["dgUCUPCurr"].Value = discResult.ToString("G29");
                        GetMargin();
                        CalculateSubTotal();
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
                if (Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgMargin"].Value.ToString()) < Decimal.Parse(15.ToString()))
                {
                    dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["LM"].Style.BackColor = Color.Blue;
                }
            }
            catch { }
        }

        private void GetMargin()
        {
            #region Get Margin
            Rate rate = new Rate();
            DateTime today = DateTime.Today;
            rate = IME.Rates.Where(a => a.rate_date == today).Where(b => b.CurType == "GBP").FirstOrDefault();
            decimal GBPBuy = Decimal.Parse(rate.RateBuy.ToString());

            if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value != null && dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value != "")
            {
                if (Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString()) > 1 || Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgSSM"].Value.ToString()) > 1)
                {
                    dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString())) / GBPBuy))) * 100).ToString("G29");

                }
                else
                {
                    dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgTotal"].Value.ToString()) / Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())) / GBPBuy))) * 100).ToString("G29");

                }
            }
            #endregion
        }

        private void GetAllMargin()
        {
            #region Get Margin
            Rate rate = new Rate();
            DateTime today = DateTime.Today;
            rate = IME.Rates.Where(a => a.rate_date == today).Where(b => b.CurType == "GBP").FirstOrDefault();
            decimal GBPBuy = Decimal.Parse(rate.RateBuy.ToString());
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                try
                {
                    if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
                    {
                        dataGridView3.Rows[i].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dataGridView3.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dataGridView3.Rows[i].Cells["dgUCUPCurr"].Value.ToString())) / GBPBuy))) * 100).ToString("G29");
                    }
                }
                catch { }

            }

            #endregion

        }

        private void FillProductCodeItem()
        {
            #region FillProductCodeItem
            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dataGridView3.CurrentCell.Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked)).ToString("G29");
            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgHZ"].Value = txtHazardousInd.Text;
            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgCCCNO"].Value = txtCCCN.Text;
            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgCOO"].Value = txtCofO.Text;
            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUnitWeigt"].Value = txtStandartWeight.Text;
            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgTotalWeight"].Value = txtGrossWeight.Text;
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
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDesc"].Value = sd.Article_Desc;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgSSM"].Value = sd.Pack_Quantity.ToString();
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value = sd.Unit_Content.ToString();
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUOM"].Value = sd.Unit_Measure;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgMPN"].Value = sd.MPN;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgCL"].Value = sd.Calibration_Ind;
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
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDesc"].Value = sdP.Article_Desc;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgSSM"].Value = sdP.Pack_Quantity.ToString();
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value = sdP.Unit_Content.ToString();
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUOM"].Value = sdP.Unit_Measure;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgPackType"].Value = sdP.Calibration_Ind;

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
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["MPN"].Value = sdP.MPN;
                txtMHCodeLevel1.Text = sdP.MH_Code_Level_1;
                txtCCCN.Text = sdP.CCCN_No.ToString();
                txtHeight.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            }
            if (er != null)
            {
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDesc"].Value = er.ArticleDescription;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUOM"].Value = er.UnitofMeasure;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgMPN"].Value = er.MPN;
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
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.Ivory;


            }
            if (txtShipping.Text != "")
            {
                label63.BackColor = Color.Red;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

            }
            if (txtEnvironment.Text != "")
            {
                label53.BackColor = Color.Red;
            }
            if (txtCalibrationInd.Text != "" && txtCalibrationInd.Text != null && txtCalibrationInd.Text != "N")
            {
                label22.BackColor = Color.Red;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Green;
            }

            if (txtLicenceType.Text != "" && txtLicenceType.Text != null)
            {
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.BurlyWood;
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
            if (txtHeight.Text != "" && txtLength.Text != "" && txtWidth.Text != "") { txtGrossWeight.Text = (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString(); }

        }

        private void dataGridView3_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[0].Value = (Int32.Parse(dataGridView3.Rows[dataGridView3.RowCount - 2].Cells[0].Value.ToString()) + 1).ToString();

            //dataGridView3.Rows[dataGridView3.CurrentRow.Index + 1].Cells[0].Value = (Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value.ToString()) + 1).ToString();

        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            ItemClear();
            try { ItemDetailsFiller(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString()); } catch { }
        }

        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int rownumber = Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgNo"].Value.ToString());
            dataGridView2.Rows.Add();
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                dataGridView2.Rows[dataGridView2.Rows.Count - 2].Cells[i].Value = dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[i].Value;
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
            for (int i = 0; i < dataGridView3.RowCount; i++)
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
                dataGridView3.Rows[Rowindex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dataGridView3.Rows[Rowindex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked)).ToString("G29");
            }
            catch { }

        }

        private void getQuotationValues()
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                GetLandingCost(i);
                GetQuotationQuantity(i);
                try
                {
                    #region Get Margin
                    Rate rate = new Rate();
                    DateTime today = DateTime.Today;
                    rate = IME.Rates.Where(a => a.rate_date == today).Where(b => b.CurType == "GBP").FirstOrDefault();
                    decimal GBPBuy = Decimal.Parse(rate.RateBuy.ToString());

                    if (dataGridView3.Rows[i].Cells["dgQty"].Value != null)
                    {
                        dataGridView3.Rows[i].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dataGridView3.Rows[i].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dataGridView3.Rows[i].Cells["dgUCUPCurr"].Value.ToString())) / GBPBuy))) * 100).ToString("G29");
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
            int RowIndex = dataGridView3.CurrentCell.RowIndex;
            int rowindexSubTotal = Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgNo"].Value.ToString());
            var tuple = SubTotal.Where(a => a.Item1 == rowindexSubTotal).FirstOrDefault();
            if (tuple == null || tuple.Item2 == 0)
            {
                if (dataGridView3.Rows[RowIndex].Cells["dgTotal"].Value != null && dataGridView3.Rows[RowIndex].Cells["dgTotal"].Value != "")
                {
                    var tuple0 = new Tuple<int, decimal>(rowindexSubTotal, Decimal.Parse(dataGridView3.Rows[RowIndex].Cells["dgTotal"].Value.ToString()));
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

                if (dataGridView3.Rows[RowIndex].Cells["dgQty"].Value != null && dataGridView3.Rows[RowIndex].Cells["dgQty"].Value != "")
                {
                    SubTotal.Add(new Tuple<int, decimal>(rowindexSubTotal, (Decimal.Parse(dataGridView3.Rows[RowIndex].Cells["dgTotal"].Value.ToString()))));
                    dataGridView3.Rows[RowIndex].Cells["dgTotal"].Value = (Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString()) * Decimal.Parse(dataGridView3.Rows[RowIndex].Cells["dgUCUPCurr"].Value.ToString())).ToString();
                }
                decimal total = 0;
                try { total = decimal.Parse(dataGridView3.Rows[RowIndex].Cells["dgTotal"].Value.ToString()); } catch { }
                lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + total).ToString();
            }
            #endregion
        }

        private void txtExtraChanges_TextChanged(object sender, EventArgs e)
        {
            decimal ExtraCharge = 0;
            try { ExtraCharge = Decimal.Parse(txtExtraChanges.Text); } catch { }
            lblTotalExtra.Text = (+Decimal.Parse(lbltotal.Text)).ToString();
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
            try { st = decimal.Parse(lblsubtotal.Text); } catch { }
            decimal p = 0;
            ///////////PROBLEM OLABİLİR her seferinde indirim hesaplaması
            try { p = decimal.Parse(lblTotalDis.Text); } catch { }
            try { lbltotal.Text = (st - (st * (p / 100))).ToString(); } catch { }
        }

        private void lbltotal_TextChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            try { total = decimal.Parse(lbltotal.Text); } catch { }
            decimal extrachange = 0;
            try { extrachange = decimal.Parse(txtExtraChanges.Text); } catch { }
            lblTotalExtra.Text = (total + extrachange).ToString();
        }

        private void lblTotalExtra_TextChanged(object sender, EventArgs e)
        {
            chkVat_Checked();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DeletedQuotationMenu.Show(dataGridView2, new Point(e.X, e.Y));
            }
        }

        private void addToQuotationAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView2.CurrentCell.RowIndex;
            int no = Int32.Parse(dataGridView2.Rows[rowindex].Cells["No1"].Value.ToString());
            var st = SubTotal.Where(a => a.Item1 == no).FirstOrDefault();
            var st1 = SubDeletingTotal.Where(a => a.Item1 == no).FirstOrDefault();
            if (st != null)
            {
                SubTotal.Remove(st);
                SubTotal.Add(new Tuple<int, decimal>(no, st1.Item2));
                lblsubtotal.Text = (decimal.Parse(lblsubtotal.Text) + st1.Item2).ToString();
                SubDeletingTotal.Remove(st1);
            }

            if (dataGridView2.Rows[rowindex].Cells["dgProductCode1"].Value != null)
            {
                int rowindex1 = dataGridView3.RowCount - 1;
                dataGridView3.Rows.Add();
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    dataGridView3.Rows[rowindex1].Cells[i].Value = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[i].Value;
                }
                dataGridView2.Rows.Remove(dataGridView2.Rows[rowindex]);
                dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Ascending);
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
                    for (int i = 0; i < dataGridView3.RowCount; i++)
                    {
                        try
                        {
                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDisc"].Value = decimal.Parse(txtTotalDis.Text);
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

        private void button9_Click(object sender, EventArgs e)
        {
            QuotationSave();
            QuotationDetailsSave();

        }

        private void QuotationSave()
        {
            try
            {
                DataSet.Quotation q = new DataSet.Quotation();
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
                q.CurrName = cbCurrency.SelectedValue.ToString();
                q.CurrType = cbCurrType.SelectedIndex;
                IME.Quotations.Add(q);
                IME.SaveChanges();

            }
            catch { }

        }

        private void QuotationDetailsSave()
        {

            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                QuotationDetail qd = new QuotationDetail();
                qd.RFQNo = txtRFQNo.Text;
                try { qd.QuotationNo = Int32.Parse(dataGridView3.Rows[i].Cells["dgNo"].Value.ToString()); } catch { }
                try { qd.ItemCode = dataGridView3.Rows[i].Cells["dgProductCode"].Value.ToString(); } catch { }
                try { qd.Qty = Int32.Parse(dataGridView3.Rows[i].Cells["dgQty"].Value.ToString()); } catch { }
                try { qd.UCUPCurr = Decimal.Parse(dataGridView3.Rows[i].Cells["dgUCUPCurr"].Value.ToString()); } catch { }
                try { qd.Disc = Decimal.Parse(dataGridView3.Rows[i].Cells["dgDisc"].Value.ToString()); } catch { }
                try { qd.Total = Decimal.Parse(dataGridView3.Rows[i].Cells["dgTotal"].Value.ToString()); } catch { }
                try { qd.TargetUP = Decimal.Parse(dataGridView3.Rows[i].Cells["dgTargetUP"].Value.ToString()); } catch { }
                try { qd.Competitor = dataGridView3.Rows[i].Cells["dgCompetitor"].Value.ToString(); } catch { }
                try { qd.CustomerDescription = dataGridView3.Rows[i].Cells["dgCustDescription"].Value.ToString(); } catch { }
                try { qd.CustomerStockCode = dataGridView3.Rows[i].Cells["dgCustStkCode"].Value.ToString(); }
                catch { }
                IME.QuotationDetails.Add(qd);
                IME.SaveChanges();
            }

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                QuotationDetail qd = new QuotationDetail();
                qd.RFQNo = txtRFQNo.Text;
                try { qd.QuotationNo = Int32.Parse(dataGridView2.Rows[i].Cells["No1"].Value.ToString()); } catch { }
                try
                {
                    qd.ItemCode = dataGridView2.Rows[i].Cells["dgProductCode1"].Value.ToString();
                }
                catch { }
                try
                {
                    qd.Qty = Int32.Parse(dataGridView2.Rows[i].Cells["dgQty1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.UCUPCurr = Decimal.Parse(dataGridView2.Rows[i].Cells["dgUCUPCurr1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.Disc = Decimal.Parse(dataGridView2.Rows[i].Cells["dgDisc1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.Total = Decimal.Parse(dataGridView2.Rows[i].Cells["dgTotal1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.TargetUP = Decimal.Parse(dataGridView2.Rows[i].Cells["dgTargetUP1"].Value.ToString());
                }
                catch { }
                try
                {
                    qd.Competitor = dataGridView2.Rows[i].Cells["dgCompetitor1"].Value.ToString();
                }
                catch { }
                try
                {
                    qd.CustomerDescription = dataGridView2.Rows[i].Cells["dgCustDescription1"].Value.ToString();
                }
                catch { }
                try
                {
                    qd.CustomerStockCode = dataGridView2.Rows[i].Cells["dgCustomerStokCode1"].Value.ToString();
                }
                catch { }
                qd.IsDeleted = 1;
                IME.QuotationDetails.Add(qd);
                    IME.SaveChanges();
                }
        }

        private void modifyQuotation(Quotation q)
        {
            CustomerCode.Text = q.Customer.c_name;
            //dataGridView3.DataSource = q.QuotationDetails;
        }
    }
}