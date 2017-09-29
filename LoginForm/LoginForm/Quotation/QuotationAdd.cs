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

            #region ComboboxFiller
            //cmbPayment.DataSource = IME.PaymentMethods.ToList();
            //cmbPayment.DisplayMember = "Payment";
            //cmbPayment.ValueMember = "ID";

            //cmbRep.DataSource = GetWorkerService.GetWorker();
            //cmbRep.DisplayMember = "FirstName";
            //cmbRep.ValueMember = "WorkerID";

            //cmbCur.DataSource = IME.Rates.ToList();
            //cmbCur.DisplayMember = "rate_name";
            //cmbCur.ValueMember = "ID";

            //cmbShipping.DataSource = IME.ShippingMethods.ToList();
            //cmbShipping.DisplayMember = "shipping_name";
            //cmbShipping.ValueMember = "ID";
            #endregion
        }

        private void CustomerCode_KeyDown(object sender, KeyEventArgs e)
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
            }
        }
        private void fillCustomer()
        {
            CustomerCode.Text = classQuotationAdd.customerID;
            txtCustomerName.Text = classQuotationAdd.customername;
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
            
            //#region Filler
            ////Seçili olan item ı text lere yazdıran fonksiyon yazılacak
            //var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            //var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            //var er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //var os = IME.OnSales.Where(a => a.ArticleNumber == ArticleNoSearch).FirstOrDefault();
            //var sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //var dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //var h = IME.Hazardous.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            //var du = IME.DualUses.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();

            //if (sd != null)
            //{
            //    txtStockNo.Text = sd.Article_No;
            //    txtDesc.Text = sd.Article_Desc;
            //    txtSSM.Text = sd.Pack_Quantity.ToString();
            //    txtUC.Text = sd.Unit_Content.ToString();
            //    txtUM.Text = sd.Unit_Measure;
            //    if (sd.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sd.Standard_Weight) / (decimal)100).ToString("G29"); } else { }
            //    txtHazardousInd.Text = sd.Hazardous_Ind;
            //    txtCalibrationInd.Text = sd.Calibration_Ind;
            //    //ObsoluteFlag.Text = sd.Obsolete_Flag.ToString();
            //    //LowDiscontInd.Text = sd.Low_Discount_Ind;
            //    //LicensedInd.Text = sd.Licensed_Ind.ToString();
            //    //ShelfLife.Text = sd.Shelf_Life;
            //    txtCoO.Text = sd.CofO;
            //    txtCCCN.Text = sd.CCCN_No.ToString();
            //    //UKIntroDate.Text = sd.Uk_Intro_Date;
            //    txtUKDiscDate.Text = sd.Uk_Disc_Date;
            //    //BHCFlag.Text = sd.BHC_Flag.ToString();
            //    txtDiscCharge.Text = sd.Disc_Change_Ind;
            //    txtExpiringPro.Text = sd.Expiring_Product_Change_Ind;
            //    txtManufacturer.Text = sd.Manufacturer.ToString();
            //    txtMPN.Text = sd.MPN;
            //    txtMHCodeLevel1.Text = sd.MH_Code_Level_1;
            //    txtCCCN.Text = sd.CCCN_No.ToString();
            //    txtHeight.Text = ((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29");
            //    txtWidth.Text = ((decimal)(sd.Width * ((Decimal)100))).ToString("G29");
            //    txtLength.Text = ((decimal)(sd.Length * ((Decimal)100))).ToString("G29");
            //}

            //if (sdP != null)
            //{
            //    txtStockNo.Text = sdP.Article_No;
            //    txtDesc.Text = sdP.Article_Desc;
            //    txtSSM.Text = sdP.Pack_Quantity.ToString();
            //    txtUC.Text = sdP.Unit_Content.ToString();
            //    txtUM.Text = sdP.Unit_Measure;
            //    if (sdP.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sdP.Standard_Weight) / (decimal)100).ToString("G29"); }
            //    txtHazardousInd.Text = sdP.Hazardous_Ind;
            //    txtCalibrationInd.Text = sdP.Calibration_Ind;
            //    //ObsoluteFlag.Text = sdP.Obsolete_Flag.ToString();
            //    //LowDiscontInd.Text = sdP.Low_Discount_Ind;
            //    //LicensedInd.Text = sdP.Licensed_Ind.ToString();
            //    //ShelfLife.Text = sdP.Shelf_Life;
            //    txtCoO.Text = sdP.CofO;
            //    txtCCCN.Text = sdP.CCCN_No.ToString();
            //    //UKIntroDate.Text = sdP.Uk_Intro_Date;
            //    txtUKDiscDate.Text = sdP.Uk_Disc_Date;
            //    //BHCFlag.Text = sdP.BHC_Flag.ToString();
            //    txtDiscCharge.Text = sdP.Disc_Change_Ind;
            //    txtExpiringPro.Text = sdP.Expiring_Product_Change_Ind;
            //    txtManufacturer.Text = sdP.Manufacturer.ToString();
            //    txtMPN.Text = sdP.MPN;
            //    txtMHCodeLevel1.Text = sdP.MH_Code_Level_1;
            //    txtCCCN.Text = sdP.CCCN_No.ToString();
            //    txtHeight.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
            //    txtWidth.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
            //    txtLength.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            //}
            //if (er != null)
            //{
            //    txtStockNo.Text = er.ArticleNo;
            //    txtDesc.Text = er.ArticleDescription;
            //    txtMPN.Text = er.MPN;
            //    if (txtLength.Text != "") { txtLength.Text = ((decimal)(er.ExtendedRangeLength * ((Decimal)100))).ToString("G29"); }
            //    if (txtWidth.Text != "") { txtWidth.Text = ((decimal)(er.Width * ((Decimal)100))).ToString("G29"); }
            //    if (txtHeight.Text != "") { txtHeight.Text = ((decimal)(er.Height * ((Decimal)100))).ToString("G29"); }
            //    if (er.ExtendedRangeWeight != null) { txtStandartWeight.Text = ((decimal)(er.ExtendedRangeWeight) / (decimal)100).ToString("G29"); }
            //    txtCCCN.Text = er.CCCN.ToString();
            //    txtCoO.Text = er.CountryofOrigin;
            //    txtUM.Text = er.UnitofMeasure;
            //    txtUK1.Text = er.Col1Price.ToString();
            //    txtUK5.Text = er.Col2Price.ToString();
            //    txtUK10.Text = er.Col3Price.ToString();
            //    txtUK25.Text = er.Col4Price.ToString();
            //    txtUK50.Text = er.Col5Price.ToString();
            //    txtUnitCount1.Text = er.Col1Break.ToString();
            //    txtUnitCount5.Text = er.Col2Break.ToString();
            //    txtUnitCount10.Text = er.Col3Break.ToString();
            //    txtUnitCount25.Text = er.Col4Break.ToString();
            //    txtUnitCount50.Text = er.Col5Break.ToString();
            //    txtCost1.Text = er.DiscountedPrice1.ToString();
            //    txtCost5.Text = er.DiscountedPrice2.ToString();
            //    txtCost10.Text = er.DiscountedPrice3.ToString();
            //    txtCost25.Text = er.DiscountedPrice4.ToString();
            //    txtCost50.Text = er.DiscountedPrice5.ToString();
            //}
            //if (sp != null)
            //{
            //    txtStockNo.Text = sp.ArticleNo;
            //    //IntroductionDate.Text = sp.IntroductionDate;
            //    //DiscontinuedDate.Text = sp.DiscontinuedDate;
            //    txtUnitCount1.Text = sp.Col1Break.ToString();
            //    txtUnitCount5.Text = sp.Col2Break.ToString();
            //    txtUnitCount10.Text = sp.Col3Break.ToString();
            //    txtUnitCount25.Text = sp.Col4Break.ToString();
            //    txtUnitCount50.Text = sp.Col5Break.ToString();
            //    txtUK1.Text = sp.Col1Price.ToString();
            //    txtUK5.Text = sp.Col2Price.ToString();
            //    txtUK10.Text = sp.Col3Price.ToString();
            //    txtUK25.Text = sp.Col4Price.ToString();
            //    txtUK50.Text = sp.Col5Price.ToString();
            //    txtCost1.Text = sp.DiscountedPrice1.ToString();
            //    txtCost5.Text = sp.DiscountedPrice2.ToString();
            //    txtCost10.Text = sp.DiscountedPrice3.ToString();
            //    txtCost25.Text = sp.DiscountedPrice4.ToString();
            //    txtCost50.Text = sp.DiscountedPrice5.ToString();
            //    txtSupersectionName.Text = sp.SupersectionName;
            //    txtDesc.Text = sp.ItemTypeDesc;
            //}
            //if (h != null)
            //{
            //    txtStockNo.Text = h.ArticleNo;
            //    txtEnvironment.Text = h.Environment.ToString();
            //    txtLithium.Text = h.Lithium;
            //    txtShipping.Text = h.Shipping;
            //}
            //if (os != null)
            //{
            //    txtStockNo.Text = os.ArticleNumber;
            //    //OnSaleDiscontinuedDate.Text = os.DiscontinuedDate;
            //    //OnSaleIntroductionDate.Text = os.IntroductionDate;
            //    txtRSStock.Text = os.OnhandStockBalance.ToString();
            //    txtRSOnOrder.Text = os.QuantityonOrder.ToString();

            //}
            //if (dd != null)
            //{
            //    txtStockNo.Text = dd.ArticleNo;
            //    txtDiscontinuationDate.Text = dd.DiscontinuationDate;
            //    txtRunOn.Text = dd.Runon.ToString();
            //    txtReferral.Text = dd.Referral.ToString();
            //}

            //if (du != null) { txtLicenceType.Text = du.LicenceType; txtStockNo.Text = du.ArticleNo; }
            ////
            //#endregion
            //if (txtLithium.Text != "") { label64.BackColor = Color.Red; }
            //if (txtShipping.Text != "") { label63.BackColor = Color.Red; }
            //if (txtEnvironment.Text != "") { label53.BackColor = Color.Red; }



        }
    }
    
}
