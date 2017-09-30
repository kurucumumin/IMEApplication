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

        public QuotationAdd()
        {
            InitializeComponent();
        }

        private void QuotationForm_Load(object sender, EventArgs e)
        {
            dataGridView3.Rows[0].Cells["dgQty"].Value ="0";
            dataGridView3.Rows[0].Cells[0].Value = 1.ToString();
            #region ComboboxFiller
            cbFactor.DataSource = IME.Rates.ToList();
            cbFactor.DisplayMember = "currency";
            //cbFactor.ValueMember = "ID";
            cbCurrency.DataSource = IME.Rates.ToList();
            cbCurrency.DisplayMember = "rate_name";
            //cbCurrency.ValueMember = "ID";
            cbPayment.DataSource = IME.PaymentMethods.ToList();
            cbPayment.DisplayMember = "Payment";
            //cbPayment.ValueMember = "ID";
            

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
                if (classQuotationAdd.customersearchID!="") { cbRep.DataSource = IME.CustomerWorkers.Where(a => a.customerID == IME.Customers.Where(b => b.ID == classQuotationAdd.customersearchID).FirstOrDefault().ID).ToList(); cbRep.DisplayMember = "cw_name";  }
            }
        }
        private void fillCustomer()
        {
            
            CustomerCode.Text = classQuotationAdd.customerID;
            txtCustomerName.Text = classQuotationAdd.customername;
            var c = IME.Customers.Where(a => a.ID == CustomerCode.Text).FirstOrDefault();
            cbRep.DataSource = IME.Workers.ToList();
            if (c.rate_ID != null)
            {
                cbFactor.SelectedIndex = cbFactor.FindStringExact(c.Rate.rate_name); 
                cbCurrency.SelectedIndex = cbCurrency.FindStringExact(c.Rate.currency.ToString());
            }
            if (c.paymentmethodID != null)
            {
                cbPayment.SelectedIndex = cbPayment.FindStringExact(c.paymentmethodID.ToString());
            }
            try { txtContactNote.Text = c.CustomerWorker.Note.Note_name; } catch { }
            try { txtCustomerNote.Text = c.Note.Note_name; } catch { }
            cbRep.SelectedIndex = cbRep.FindStringExact(c.Worker.FirstName);
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
                    if (dataGridView3.CurrentCell.RowIndex != 0) { dataGridView3.CurrentCell.Value = (dataGridView3.CurrentCell.RowIndex + 1).ToString(); }
                    break;
                case 2://PRODUCT CODE
                    {
                        var sd = classQuotationAdd.ItemGetSuperDisk(dataGridView3.CurrentCell.Value.ToString());
                        var sdp = classQuotationAdd.ItemGetSuperDiskP(dataGridView3.CurrentCell.Value.ToString());
                        var er = classQuotationAdd.ItemGetExtendedRange(dataGridView3.CurrentCell.Value.ToString());
                        if (sd != null || sdp != null || er != null)
                        {
                            ItemDetailsFiller(dataGridView3.CurrentCell.Value.ToString());
                            //LandingCost Calculation
                            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[8].Value = (classQuotationAdd.GetLandingCost(dataGridView3.CurrentCell.Value.ToString())).ToString("G29");
                        }
                        else { MessageBox.Show("There is no such an item"); }
                    }break;
                case 10://QAUANTITY
                    {
                        if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value != null) { dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgCost"].Value = classQuotationAdd.GetCost(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())).ToString("G29"); }
                        if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value != null) { dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value = (classQuotationAdd.GetPrice(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgProductCode"].Value.ToString(), Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString()))* Decimal.Parse(cbFactor.Text)* Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value.ToString())).ToString("G29") ; }
                        decimal discResult = 0;
                        if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value != null) { discResult = decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString()); }
                        discResult = (discResult - (discResult * decimal.Parse(dataGridView3.CurrentCell.Value.ToString()) / 100));
                        dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = discResult.ToString("G29");
                        //if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgQty"].Value != null)
                        //{
                        //    dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgMargin"].Value = ((1 - ((Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString())) / (Decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value.ToString())))) * 100).ToString("G29");
                        //}
                    }
                    break;
                case 17://Disc
                    {
                        decimal discResult=0;
                        if (dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value != null) { discResult = decimal.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUPIME"].Value.ToString()); }
                        discResult = (discResult - (discResult * decimal.Parse(dataGridView3.CurrentCell.Value.ToString()) / 100));
                        dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUCUPCurr"].Value = discResult.ToString("G29");
                    }
                    break;
                case 18://
                    {

                    }break;
            }
        }

        private void ItemDetailsFiller(string ArticleNoSearch)
        {
            #region Filler
            //Seçili olan item ı text lere yazdıran fonksiyon yazılacak
            var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            var er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            var os = IME.OnSales.Where(a => a.ArticleNumber == ArticleNoSearch).FirstOrDefault();
            var sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            var dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            var h = IME.Hazardous.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            var du = IME.DualUses.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            if (sd != null)
            {
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgDesc"].Value = sd.Article_Desc;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgSSM"].Value = sd.Pack_Quantity.ToString();
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUC"].Value = sd.Unit_Content.ToString();
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgUOM"].Value = sd.Unit_Measure;
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
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["dgMPN"].Value = sd.MPN;
                txtMHCodeLevel1.Text = sd.MH_Code_Level_1;
                txtCCCN.Text = sd.CCCN_No.ToString();
                txtHeight.Text = ((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sd.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sd.Length * ((Decimal)100))).ToString("G29");
            }
            if (sdP != null)
            {
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["Description"].Value = sdP.Article_Desc;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["SSM"].Value = sdP.Pack_Quantity.ToString();
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["U/C"].Value = sdP.Unit_Content.ToString();
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["UOM"].Value = sdP.Unit_Measure;
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
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["Description"].Value = er.ArticleDescription;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["UOM"].Value = er.UnitofMeasure;
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["MPN"].Value = er.MPN;
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
                txtEnvironment.Text = h.Environment.ToString();
                txtLithium.Text = h.Lithium;
                txtShipping.Text = h.Shipping;
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
            if (du != null) { txtLicenceType.Text = du.LicenceType;}
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
        

    }
    
}
