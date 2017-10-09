using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Quotation;
using LoginForm.Services;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class QuotationAdd : Form
    {
        GetWorkerService GetWorkerService = new GetWorkerService();
        IMEEntities IME = new IMEEntities();
        decimal price;
        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        public QuotationAdd()
        {
            InitializeComponent();
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

        private void dataGridView3_KeyDown(object sender, KeyEventArgs e)
        {
            

        }



        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView3.CurrentCell.ColumnIndex)
            {
                case 0:
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
                                    }
                                }
                                #endregion
                            }

                        }
                    }

                    // if (dataGridView3.CurrentCell.RowIndex != 0) { dataGridView3.CurrentCell.Value = (dataGridView3.CurrentCell.RowIndex + 1).ToString(); }
                    dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Ascending);
                    break;
                case 2://PRODUCT CODE
                    {
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
                    break;
                case 10://QAUANTITY
                    #region Quantity
                    {

                        if (Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString()) != 0)
                        {
                            #region Quantity


                            if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value != null) { dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgCost"].Value = classQuotationAdd.GetCost(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())).ToString("G29"); }
                            if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value != null) { price = Decimal.Parse((classQuotationAdd.GetPrice(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())) * Decimal.Parse(cbFactor.Text) * Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())).ToString("G29")); }
                            decimal discResult = 0;

                            //Fiyat burada 
                            string articleNo = dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString();
                            int isP = 0;
                            if (articleNo.ToUpper().IndexOf('P') != -1) { isP = 1; }

                            if (isP == 1)
                            {
                                if (IME.SuperDiskPs.Where(a => a.Article_No == articleNo).ToList().Count > 0)
                                {
                                    if (IME.SuperDiskPs.Where(a => a.Article_No == articleNo).FirstOrDefault().Pack_Quantity > 1)
                                    {


                                        if (Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgSSM"].Value.ToString()) > 1 && Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString()) == 1)
                                        {
                                            if ((Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgSSM"].Value.ToString())) != 0)
                                            {
                                                MessageBox.Show("Please enter a number that is a multiple of SSM");
                                            }
                                            else
                                            {
                                                price = price / decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString());
                                            }


                                        }
                                    }

                                }
                            }
                            else
                            {

                                if (Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString()) > 1 && Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgSSM"].Value.ToString()) == 1)
                                {
                                    int resultMod = (Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString()) % Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString()));
                                    if ((resultMod != 0) || (Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())) < Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString()))
                                    {
                                        MessageBox.Show("Please enter a number that is a multiple of Unit Content");
                                        break;
                                    }
                                    else
                                    {
                                        price = price / decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value.ToString());
                                    }

                                }
                            }
                            //

                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value = price.ToString();
                            discResult = decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString());

                            if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDisc"].Value != null) discResult = (discResult - (discResult * decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDisc"].Value.ToString()) / 100));
                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = discResult.ToString("G29");
                            GetMargin();
                        }

                        #endregion
                    }
                    break;
                #endregion
                case 16://Disc
                    {
                        decimal discResult = 0;
                        if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value != null) { discResult = decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString()); }
                        discResult = (discResult - (discResult * decimal.Parse(dataGridView3.CurrentCell.Value.ToString()) / 100));
                        dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = discResult.ToString();
                        GetMargin();
                    }
                    break;
                case 17://total 
                    {

                        decimal total = decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString());
                        decimal UcupIME = decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString());
                        dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDisc"].Value = String.Format("{0:0.000}", ((UcupIME - total) * (decimal)100 / UcupIME));
                        GetMargin();
                    }
                    break;
            }
        }
        private void GetMargin()
        {
            Rate rate = new Rate();
            DateTime today = DateTime.Today;
            rate = IME.Rates.Where(a => a.rate_date == today).Where(b => b.CurType == "GBP").FirstOrDefault();
            decimal GBPBuy = Decimal.Parse(rate.RateBuy.ToString());

            if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
            {
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgLandingCost"].Value.ToString())) / ((Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString())) / GBPBuy))) * 100).ToString("G29");
            }
        }

        private void FillProductCodeItem()
        {
            #region FillProductCodeItem
            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dataGridView3.CurrentCell.Value.ToString())).ToString("G29");
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
                if (txtHeight.Text != "" && txtLength.Text != "" && txtWidth.Text != "") { txtGrossWeight.Text = (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString(); }
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
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["Description"].Value = sdP.Article_Desc;
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
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDescription"].Value = er.ArticleDescription;
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
            if (txtLithium.Text != "") { label64.BackColor = Color.Red; }
            if (txtShipping.Text != "") { label63.BackColor = Color.Red; }
            if (txtEnvironment.Text != "") { label53.BackColor = Color.Red; }
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
            dataGridView3.Rows[dataGridView3.CurrentRow.Index +1].Cells[0].Value = (Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value.ToString()) + 1).ToString();

        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            ItemClear();
            try { ItemDetailsFiller(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[2].Value.ToString()); } catch { }
        }

        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            dataGridView2.Rows.Add();
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                dataGridView2.Rows[dataGridView2.Rows.Count-2].Cells[i].Value= dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[i].Value;
            }
        }

        private void cbFactor_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Cells["dgUPIME"].Value = (Int32.Parse(dataGridView3.Rows[i].Cells["dgLandingCost"].Value.ToString()) * Int32.Parse(cbFactor.Text)).ToString();
            }
        }
    }

}
