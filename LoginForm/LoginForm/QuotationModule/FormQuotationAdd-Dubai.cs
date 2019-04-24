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
using LoginForm.Services.SP;
using System.Data.Entity.Validation;
using System.Xml;

namespace LoginForm.QuotationModule
{
    public partial class FormQuotationAdd_Dubai : Form
    {

        SqlHelper sqlHelper = new SqlHelper();
        string manuelSelection = string.Empty;
        private static string QuoStatusActive = "Not Ordered";
        FormQuaotationCustomerSearch parentCustomer;
        FormQuotationMain parent;
        List<int> enabledColumns = new List<int>(new int[] { 0, 7, 14, 21, 28, 35 });
        #region Definitions
        GetWorkerService GetWorkerService = new GetWorkerService();
        DataTable TotalCostList = new DataTable();
        DataGridViewRow CurrentRow;
        IMEEntities IME = new IMEEntities();
        decimal price;
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
        Quotation mainQuo = new Quotation();
        decimal? totalmargin = 0;
        ToolTip aciklama = new ToolTip();
        System.Data.DataSet ds = new System.Data.DataSet();
        int a = 1;
        int importFromQuotation = 0;
        string mod = "";
        string cName = "";
        string cID = "";
        DataTable table = new DataTable();
        int sayac = 0;
        DataGridViewCellStyle boldStyle = new DataGridViewCellStyle();
        #endregion


        public FormQuotationAdd_Dubai()
        {
            InitializeComponent();
        }

        public FormQuotationAdd_Dubai(string mod, Quotation q, Customer c)
        {

            InitializeComponent();
            dgQuotationAddedItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgQuotationDeleted.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
        dgQuotationAddedItems, new object[] { true });

            CustomerInformation(c);

            if (mod == "New")
            {

            }
            else
            {
                QuotationMainInformation(q);
                QuotationDetailInformation(q);

                if (mod == "View")
                {

                }
                else if (mod == "Update")
                {

                }
            }
        }

        public void QuotationMainInformation(Quotation q)
        {
            txtQuotationNo.Text = q.QuotationNo;
            dtpDate.Value = q.StartDate;
            txtValidation.Text = q.DeliveryDate.ToString();
            txtRFQNo.Text = q.RFQNo;
            cbFactor.Text = String.Format("{0:N}", q.Factor.ToString());
            chkFirstUPIME.Checked = q.FirstColumn.Value;
            txtTotalMargin.Text = String.Format("{0:N}", q.TotalMargin.ToString());
            //txtTotalCost.Text = String.Format("{0:N}", totalCost);
            lblsubtotal.Text = String.Format("{0:N}", q.SubTotal.ToString());
            try { txtNoteForUs.Text = IME.Notes.Where(a => a.ID == q.NoteForUsID).FirstOrDefault().Note_name; } catch { }
            try { txtNoteForCustomer.Text = IME.Notes.Where(a => a.ID == q.NoteForCustomerID).FirstOrDefault().Note_name; } catch { }
            chkbForFinance.Checked = Convert.ToBoolean(q.ForFinancelIsTrue);
            //cbSMethod
            ckItemCost.Checked = Convert.ToBoolean(q.IsItemCost);
            ckWeightCost.Checked = Convert.ToBoolean(q.IsWeightCost);
            ckCustomsDuties.Checked = Convert.ToBoolean(q.IsCustomsDuties);
            cbDeliverDiscount.Checked = q.DistributeDiscount.Value;
            txtTotalDis.Text = String.Format("{0:N}", q.DiscOnSubTotal.ToString());
            txtTotalDis2.Text = String.Format("{0:N}", q.DiscOnSubTotal2.ToString());
            lbltotal.Text = String.Format("{0:N}", q.SubTotal.ToString());
            chkVat.Checked = Convert.ToBoolean(q.IsVatValue);
            //txtExtraChanges.Text = 
            lblTotalExtra.Text = q.ExtraCharges.ToString();
            vat = (decimal)Utils.getManagement().VAT;
            lblVat.Text = vat.ToString();
            //lblVatTotal.Text = 
            lblGrossTotal.Text = String.Format("{0:N}", q.GrossTotal.ToString());
            lblTotalWeight.Text = String.Format("{0:N}", q.TotalWeight.ToString());
            lblTotalNetWeight.Text = String.Format("{0:N}", q.TotalNetWeight.ToString());
        }

        public void QuotationDetailInformation(Quotation q)
        {
            foreach (var item in q.QuotationDetails)
            {
                DataGridViewRow row = (DataGridViewRow)dgQuotationAddedItems.RowTemplate.Clone();
                row.CreateCells(dgQuotationAddedItems);
                row.Cells[dgNo.Index].Value = item.dgNo;
                row.Cells[dgProductCode.Index].Value = item.ItemCode;
                row.Cells[dgQty.Index].Value = item.Qty;
                row.Cells[dgSSM.Index].Value = item.SSM;
                row.Cells[dgUC.Index].Value = item.UC;
                row.Cells[dgUPIME.Index].Value = Math.Round((decimal)item.UPIME, 2);
                row.Cells[dgFirstUPIME.Index].Value = (decimal)item.FirstUPIME;
                row.Cells[dgUCUPCurr.Index].Value = item.UCUPCurr;
                row.Cells[dgPacketUP.Index].Value = item.PacketUP;
                row.Cells[dgDisc.Index].Value = item.Disc;
                row.Cells[dgDelivery.Index].Value = item.quotationDeliveryID;
                row.Cells[dgStatus.Index].Value = item.DubaiStatus;
                row.Cells[dgTotal.Index].Value = item.Total;
                row.Cells[dgTargetUP.Index].Value = item.TargetUP;
                row.Cells[dgCompetitor.Index].Value = item.Competitor;
                row.Cells[dgUnitWeigt.Index].Value = item.UnitWeight;
                row.Cells[dgUKPrice.Index].Value = item.UKPrice;
                row.Cells[dgTotalWeight.Index].Value = item.UnitWeight * item.Qty;
                row.Cells[dgUnitNetWeight.Index].Value = item.UnitNetWeight;
                row.Cells[dgUnitTotalNetWeight.Index].Value = item.UnitNetWeight * item.Qty;
                row.Cells[dgCustStkCode.Index].Value = item.CustomerStockCode;
                row.Cells[dgMargin.Index].Value = item.Marge;
                row.Cells[dgBrand.Index].Value = item.Manufacturer;
                row.Cells[dgSupplier.Index].Value = item.SupplierName;
                row.Cells[dgMPN.Index].Value = item.MPN;
                row.Cells[dgDesc.Index].Value = item.ItemDescription;
                row.Cells[dgCost.Index].Value = item.Cost;
                row.Cells[dgLandingCost.Index].Value = item.LandingCost;
                row.Cells[dgUOM.Index].Value = item.UnitOfMeasure;

                #region Low Margin Mark Clear
                if (!String.IsNullOrEmpty(txtHazardousInd.Text) && txtHazardousInd.Text == "Y")
                {
                    label63.BackColor = Color.Red;
                    row.Cells["HS"].Style.BackColor = Color.Red;

                }
                if (!String.IsNullOrEmpty(txtLithium.Text) && txtLithium.Text == "Y")
                {
                    label64.BackColor = Color.Red;
                    row.Cells["LI"].Style.BackColor = Color.Red;
                }
                if (!String.IsNullOrEmpty(txtShipping.Text) && txtShipping.Text == "Y")
                {
                    label63.BackColor = Color.Red;
                    row.Cells["HS"].Style.BackColor = Color.Red;

                }
                if (!String.IsNullOrEmpty(txtEnvironment.Text) && txtEnvironment.Text == "Y")
                {
                    label53.BackColor = Color.Red;
                }
                if (!String.IsNullOrEmpty(txtCalibrationInd.Text) && txtCalibrationInd.Text == "Y")
                {
                    label22.BackColor = Color.Red;
                    row.Cells["CL"].Style.BackColor = Color.Red;
                }
                if (!String.IsNullOrEmpty(txtLicenceType.Text))
                {
                    row.Cells["LC"].Style.BackColor = Color.Red;
                }

                if (Convert.ToDecimal(row.Cells[dgTotalWeight.Index].Value) == 0)
                {
                    row.Cells[WT.Index].Style.BackColor = Color.Red;
                }
                else if (Convert.ToDecimal(row.Cells[dgTotalWeight.Index].Value) > 5)
                {
                    row.Cells[WT.Index].Style.BackColor = Color.Orange;
                }
                else
                {
                    row.Cells[WT.Index].Style.BackColor = Color.Ivory;
                }
                #endregion

                dgQuotationAddedItems.Rows.Add(row);
            }
        }

        public void CustomerInformation(Customer c)
        {
            ComboboxInformation();

            cbWorkers.SelectedValue = c.CustomerWorker.ID;
            cbPayment.SelectedValue = c.payment_termID;
            CustomerCode.Text = c.ID;
            txtCustomerName.Text = c.c_name;

            lblCustomerFactorValue.Text = String.Format("{0:N}", c.factor.ToString());
            lblCustomerMarkupValue.Text = String.Format("{0:N}", c.Markup.ToString());
            lblCustomerDiscountValue.Text = String.Format("{0:N}", c.discountrate.ToString());

            try { txtContactNote.Text = c.CustomerWorker.Note.Note_name; } catch { }
            try { txtCustomerNote.Text = c.Note.Note_name; } catch { }
            try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == c.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
        }

        public void ComboboxInformation()
        {
            #region Combobox

            cbWorkers.DataSource = IME.CustomerWorkers.ToList();
            cbWorkers.ValueMember = "ID";
            cbWorkers.DisplayMember = "cw_name";

            cbPayment.DataSource = IME.PaymentTerms.ToList();
            cbPayment.ValueMember = "ID";
            cbPayment.DisplayMember = "term_name";

            cbRep.DataSource = IME.Workers.ToList();
            cbRep.ValueMember = "WorkerID";
            cbRep.DisplayMember = "NameLastName";
            cbRep.SelectedValue = Utils.getCurrentUser().WorkerID;

            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            cbCurrency.SelectedValue = Utils.getManagement().DefaultCurrency;

            #endregion
        }

        private void calculateTotalCost()
        {
            try
            {
                if (dgQuotationAddedItems.RowCount != 0)
                {
                    if (dgQuotationAddedItems.RowCount == 1 && (dgQuotationAddedItems.Rows[0].Cells[dgProductCode.Index].Value == null || dgQuotationAddedItems.Rows[0].Cells[dgProductCode.Index].Value.ToString() == ""))
                    {
                        txtTotalCost.Text = 0.ToString();
                    }
                    else
                    {
                        //Satırların landingCost*Qty çarpımı Total Costu Veriyor
                        decimal totalCost = 0;
                        for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
                        {
                            decimal LandingCost = 0;
                            decimal Quantity = 0;
                            LandingCost = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgLandingCost.Index].Value.ToString());
                            Quantity = decimal.Parse(dgQuotationAddedItems.Rows[i].Cells[dgQty.Index].Value.ToString());

                            totalCost += (LandingCost * Quantity);
                        }

                        //Total Cost'u seçili olan para birimine dönüştürüyor
                        decimal PoundRate = 0;
                        decimal CurrentRate = 0;
                        PoundRate = (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;
                        CurrentRate = (decimal)IME.ExchangeRates.Where(a => a.currencyId == (decimal)cbCurrency.SelectedValue).OrderByDescending(a => a.date).FirstOrDefault().rate;
                        totalCost = totalCost * PoundRate / (CurrentRate);
                        //txtTotalCost.Text = Math.Round(totalCost, 4).ToString();
                        txtTotalCost.Text = String.Format("{0:N}", totalCost);
                    }
                }

            }
            catch { }
        }

        private void ItemDetailsFiller(string ArticleNoSearch)
        {
            CurrentRow = dgQuotationAddedItems.CurrentRow;
            #region Filler
            decimal CurrValueWeb = Decimal.Parse(curr.rate.ToString());
            string ArticleNoSearch1 = ArticleNoSearch;
            try { ArticleNoSearch1 = (Int32.Parse(ArticleNoSearch)).ToString(); } catch { }
            string supplier = "SC0001";
            //Seçili olan item ı text lere yazdıran fonksiyon yazılacak
            SuperDisk sd;
            SuperDiskP sdP;
            ExtendedRange er;
            string custStockCode = "";
            string custStockDesc = "";
            var ItemTabDetails = IME.ItemDetailTabFiller(ArticleNoSearch).FirstOrDefault();
            if (IME.QuotationDetails.Where(x => x.ItemCode == ArticleNoSearch && x.CustomerDesc == txtCustomerName.Text).FirstOrDefault() != null)
            {
                custStockCode = IME.QuotationDetails.Where(x => x.ItemCode == ArticleNoSearch && x.CustomerDesc == txtCustomerName.Text).FirstOrDefault().CustomerStockCode;
                custStockDesc = IME.QuotationDetails.Where(x => x.ItemCode == ArticleNoSearch && x.CustomerDesc == txtCustomerName.Text).FirstOrDefault().CustomerDesc;
            }

            var rsf = IME.RsFileHistories.Where(a => a.FileType == "OnSale").OrderByDescending(x => x.Date).FirstOrDefault();

            if (ItemTabDetails != null)
            {
                dgQuotationAddedItems.CurrentRow.Cells["dgDesc"].Value = ItemTabDetails.Article_Desc;
                CurrentRow.Cells["dgSSM"].Value = ItemTabDetails.Pack_Quantity.ToString() ?? ""; ;
                CurrentRow.Cells["dgUC"].Value = ItemTabDetails.Unit_Content.ToString() ?? ""; ;
                if (ItemTabDetails.Unit_Measure == "")
                {
                    if (CurrentRow.Cells[dgUC.Index].Value.ToString() == "1" && CurrentRow.Cells[dgSSM.Index].Value.ToString() == "1")
                    {
                        CurrentRow.Cells["dgUOM"].Value = "EACH";
                    }
                    else
                    {
                        CurrentRow.Cells["dgUOM"].Value = "PACKET OF";
                    }
                }
                else
                {
                    CurrentRow.Cells["dgUOM"].Value = ItemTabDetails.Unit_Measure;
                }
                CurrentRow.Cells["dgMPN"].Value = ItemTabDetails.MPN;
                CurrentRow.Cells["dgCL"].Value = ItemTabDetails.Calibration_Ind;
                CurrentRow.Cells[dgCustDescription.Index].Value = custStockDesc;
                CurrentRow.Cells[dgCustStkCode.Index].Value = custStockCode;
                CurrentRow.Cells[dgBrand.Index].Value = ItemTabDetails.Manufacturer;
                CurrentRow.Cells[dgSupplier.Index].Value = IME.Suppliers.Where(x => x.ID == supplier).FirstOrDefault().s_name;
                if (ItemTabDetails.Standard_Weight != null && ItemTabDetails.Standard_Weight != 0)
                {
                    decimal sW = (decimal)(ItemTabDetails.Standard_Weight / (decimal)1000);
                    sW = (ItemTabDetails.Pack_Quantity > ItemTabDetails.Unit_Content) ? (decimal)(sW / ItemTabDetails.Pack_Quantity) : (decimal)(sW / ItemTabDetails.Unit_Content);
                    txtStandartWeight.Text = String.Format("{0:N}", sW.ToString());
                }

                txtHazardousInd.Text = ItemTabDetails.Hazardous_Ind;
                txtHazardousInd.Text = (ItemTabDetails.Hazardous_Ind != null && ItemTabDetails.Hazardous_Ind != String.Empty && ItemTabDetails.Hazardous_Ind != "N") ? "Y" : "";
                txtCalibrationInd.Text = ItemTabDetails.Calibration_Ind;
                txtCalibrationInd.Text = (ItemTabDetails.Calibration_Ind != null && ItemTabDetails.Calibration_Ind != String.Empty && ItemTabDetails.Calibration_Ind != "N") ? "Y" : "";
                txtEnvironment.Text = ItemTabDetails.Environment.ToString();
                txtEnvironment.Text = (ItemTabDetails.Environment != null && ItemTabDetails.Environment != 0) ? "Y" : "";
                txtLicenceType.Text = ItemTabDetails.LicenceType;
                txtLicenceType.Text = (ItemTabDetails.LicenceType != null && ItemTabDetails.LicenceType != String.Empty && ItemTabDetails.LicenceType != "0") ? "Y" : "";
                txtShipping.Text = ItemTabDetails.Shipping;
                txtShipping.Text = (ItemTabDetails.Shipping != null && ItemTabDetails.Shipping != String.Empty && ItemTabDetails.Shipping != "0") ? "Y" : "";
                txtDiscChange.Text = ItemTabDetails.Low_Discount_Ind;
                txtLithium.Text = ItemTabDetails.Lithium;
                txtLithium.Text = (ItemTabDetails.Lithium != null && ItemTabDetails.Lithium != String.Empty && ItemTabDetails.Lithium != "0") ? "Y" : "";
                txtExpiringPro.Text = ItemTabDetails.Expiring_Product_Change_Ind;
                txtExpiringPro.Text = (ItemTabDetails.Expiring_Product_Change_Ind != null && ItemTabDetails.Expiring_Product_Change_Ind != String.Empty && ItemTabDetails.Expiring_Product_Change_Ind != "0") ? "Y" : "";
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
                txtGrossWeight.Text = String.Format("{0:N}", (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());
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

                txtRSStock.Text = ItemTabDetails.OnhandStockBalance.ToString();
                textBox23.Text = rsf.Date.ToString();
                txtRSOnOrder.Text = ItemTabDetails.QuantityonOrder.ToString();
                txtDiscontinuationDate.Text = ItemTabDetails.DiscontinuationDate;
                txtRunOn.Text = ItemTabDetails.Runon?.ToString();
                txtReferral.Text = ItemTabDetails.Referral?.ToString();

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
                }
                if (CurrentRow.Cells["dgUOM"].Value == null && CurrentRow.Cells["dgUC"].Value != null)
                { CurrentRow.Cells["dgUOM"].Value = "Each"; }
                #endregion

                #region Low Margin Mark Clear
                if (!String.IsNullOrEmpty(txtHazardousInd.Text) && txtHazardousInd.Text == "Y")
                {
                    label63.BackColor = Color.Red;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

                }
                if (!String.IsNullOrEmpty(txtLithium.Text) && txtLithium.Text == "Y")
                {
                    label64.BackColor = Color.Red;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LI"].Style.BackColor = Color.Red;
                }
                if (!String.IsNullOrEmpty(txtShipping.Text) && txtShipping.Text == "Y")
                {
                    label63.BackColor = Color.Red;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["HS"].Style.BackColor = Color.Red;

                }
                if (!String.IsNullOrEmpty(txtEnvironment.Text) && txtEnvironment.Text == "Y")
                {
                    label53.BackColor = Color.Red;
                }
                if (!String.IsNullOrEmpty(txtCalibrationInd.Text) && txtCalibrationInd.Text == "Y")
                {
                    label22.BackColor = Color.Red;
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["CL"].Style.BackColor = Color.Red;
                }
                if (!String.IsNullOrEmpty(txtLicenceType.Text))
                {
                    dgQuotationAddedItems.Rows[dgQuotationAddedItems.CurrentCell.RowIndex].Cells["LC"].Style.BackColor = Color.Red;
                }
                #endregion
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

        #region DATAGRİD CELL

        private void dgQuotationAddedItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgQuotationAddedItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value != null)
            {

                CurrentRow = dgQuotationAddedItems.CurrentRow;
                ItemClear();
                try { ItemDetailsFiller(CurrentRow.Cells["dgProductCode"].Value.ToString()); } catch { }

                if (dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString().Substring(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString().Length - 1, 1) == "P")
                {
                    if (new Sp_Item().GetProductHistoryWithArticleNo_P(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()) != null && new Sp_Item().GetProductHistoryWithArticleNo_P(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()).Rows.Count > 0)
                    {
                        btnProductHistory.ForeColor = Color.FromArgb(255, 68, 68);
                        btnProductHistory.Enabled = true;
                    }
                    else
                    {
                        btnProductHistory.ForeColor = Color.FromArgb(32, 31, 53);
                        btnProductHistory.Enabled = false;
                    }
                }
                else
                {
                    if (new Sp_Item().GetProductHistoryWithArticleNo(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()) != null && new Sp_Item().GetProductHistoryWithArticleNo(dgQuotationAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString()).Rows.Count > 0)
                    {

                        btnProductHistory.ForeColor = Color.FromArgb(255, 68, 68);
                        btnProductHistory.Enabled = true;
                    }
                    else
                    {
                        btnProductHistory.ForeColor = Color.FromArgb(32, 31, 53);
                        btnProductHistory.Enabled = false;
                    }
                }

            }
        }

        private void dgQuotationAddedItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgQuotationAddedItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBox value is not valid.")
            {
                object value = dgQuotationAddedItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dgQuotationAddedItems.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void dgQuotationAddedItems_Click(object sender, EventArgs e)
        {

        }

        private void dgQuotationAddedItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dgQuotationAddedItems_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgQuotationAddedItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dgQuotationAddedItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void dgQuotationAddedItems_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

        }

        #endregion

        private void cbDeliverDiscount_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CalculateSubTotal()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow item in dgQuotationAddedItems.Rows)
            {
                decimal rowTotal = 0;
                try
                {

                    item.Cells[dgTotal.Index].Value = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgUCUPCurr.Index].Value.ToString()) * decimal.Parse(item.Cells[dgQty.Index].Value.ToString())));
                    rowTotal = Decimal.Parse(String.Format("{0:N}", decimal.Parse(item.Cells[dgTotal.Index].Value.ToString())));
                }
                catch { }
                subtotal = Decimal.Parse(String.Format("{0:N}", subtotal + rowTotal));
            }
            //lblsubtotal.Text = Math.Round(subtotal, 4).ToString();
            lblsubtotal.Text = String.Format("{0:N}", subtotal);
            decimal dectotaldisc = 0;

            if (txtTotalDis2.Text != "" && txtTotalDis2.Text != null)
            {
                decimal totaldis = 0;
                totaldis = Decimal.Parse(String.Format("{0:N}", decimal.Parse(txtTotalDis.Text)));
                txtTotalDis2.Text = String.Format("{0:N}", Decimal.Parse((subtotal * totaldis / 100).ToString()));
                dectotaldisc = decimal.Parse(String.Format("{0:N}", Decimal.Parse(txtTotalDis2.Text)));
            }

            lbltotal.Text = String.Format("{0:N}", Decimal.Parse((subtotal - dectotaldisc).ToString()));
        }

        #region KUR

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurrency.DataSource != null)
            {
                GetCurrency(dtpDate.Value);
                ChangeCurr();
                calculateTotalCost();
                GetCurrencySymbol();
            }
        }

        private string GetCurrencySign()
        {
            return curr.Currency?.currencySymbol;
        }

        private void ChangeCurr()
        {
            lblWeb.Text = "Web (" + GetCurrencySign() + ")";
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
            for (int i = 0; i < dgQuotationAddedItems.RowCount; i++)
            {
                #region Get Margin
                if (dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value != null && dgQuotationAddedItems.Rows[i].Cells["dgQty"].Value.ToString() != "0")
                {
                    CurrentRow = dgQuotationAddedItems.Rows[i];
                    //CurrentRow.Cells["dgUCUPCurr"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString())) / Currfactor), 2).ToString();
                    CurrentRow.Cells["dgUCUPCurr"].Value = String.Format("{0:N}", ((Decimal.Parse(CurrentRow.Cells["dgUCUPCurr"].Value.ToString())) / Currfactor).ToString());
                    if (Convert.ToInt32(CurrentRow.Cells[dgSSM.Index].Value.ToString()) > 1 || Convert.ToInt32(CurrentRow.Cells[dgUC.Index].Value.ToString()) > 1)
                    {
                        //CurrentRow.Cells[dgPacketUP.Index].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells[dgPacketUP.Index].Value.ToString())) / Currfactor), 2).ToString();
                        CurrentRow.Cells[dgPacketUP.Index].Value = ((Decimal.Parse(CurrentRow.Cells[dgPacketUP.Index].Value.ToString())) / Currfactor).ToString();
                    }
                    //CurrentRow.Cells["dgUPIME"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString())) / Currfactor), 2).ToString();
                    //CurrentRow.Cells[dgFirstUPIME.Index].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString())) / Currfactor), 2).ToString();
                    //CurrentRow.Cells["dgTotal"].Value = Math.Round(((Decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString())) / Currfactor), 2).ToString();
                    CurrentRow.Cells["dgUPIME"].Value = ((Decimal.Parse(CurrentRow.Cells["dgUPIME"].Value.ToString())) / Currfactor).ToString();
                    CurrentRow.Cells[dgFirstUPIME.Index].Value = ((Decimal.Parse(CurrentRow.Cells[dgFirstUPIME.Index].Value.ToString())) / Currfactor).ToString();
                    CurrentRow.Cells["dgTotal"].Value = ((Decimal.Parse(CurrentRow.Cells["dgTotal"].Value.ToString())) / Currfactor).ToString();

                }
                #endregion
            }
            CalculateSubTotal();
            //lblCurrValue.Text = Math.Round(CurrValue, 4).ToString();
            lblCurrValue.Text = (String.Format("{0:N}", CurrValue));
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

        #endregion

        #region virgülden sonraki basamak işlemleri

        private void lblsubtotal_TextChanged(object sender, EventArgs e)
        {
            if (lblsubtotal.Text != "")
            {
                decimal top = Convert.ToDecimal(lblsubtotal.Text);
                lblsubtotal.Text = String.Format("{0:N}", top);
            }
        }

        private void txtTotalDis_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalDis.Text != "")
            {
                decimal top = Convert.ToDecimal(lblsubtotal.Text);
                lblsubtotal.Text = String.Format("{0:N}", top);
            }
        }

        private void txtTotalDis2_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalDis2.Text != "")
            {
                decimal top = Convert.ToDecimal(txtTotalDis.Text);
                txtTotalDis.Text = String.Format("{0:N}", top);
            }
        }

        private void lbltotal_TextChanged(object sender, EventArgs e)
        {
            if (lbltotal.Text != "")
            {
                decimal top = Convert.ToDecimal(lbltotal.Text);
                lbltotal.Text = String.Format("{0:N}", top);
            }
        }

        private void lblTotalExtra_TextChanged(object sender, EventArgs e)
        {
            if (lblTotalExtra.Text != "")
            {
                decimal top = Convert.ToDecimal(lblTotalExtra.Text);
                lblTotalExtra.Text = String.Format("{0:N}", top);
            }
        }

        private void lblVatTotal_TextChanged(object sender, EventArgs e)
        {
            if (lblVatTotal.Text != "")
            {
                decimal top = Convert.ToDecimal(lblVatTotal.Text);
                lblVatTotal.Text = String.Format("{0:N}", top);
            }
        }

        private void lblGrossTotal_TextChanged(object sender, EventArgs e)
        {
            if (lblGrossTotal.Text != "")
            {
                decimal top = Convert.ToDecimal(lblGrossTotal.Text);
                lblGrossTotal.Text = String.Format("{0:N}", top);
            }
        }

        private void txtTotalCost_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalCost.Text != "")
            {
                decimal top = Convert.ToDecimal(txtTotalCost.Text);
                txtTotalCost.Text = String.Format("{0:N}", top);
            }
        }

        private void lblTotalWeight_TextChanged(object sender, EventArgs e)
        {
            if (lblTotalWeight.Text != "")
            {
                decimal top = Convert.ToDecimal(lblTotalWeight.Text);
                lblTotalWeight.Text = String.Format("{0:N}", top);
            }
        }

        private void lblTotalNetWeight_TextChanged(object sender, EventArgs e)
        {
            if (lblTotalNetWeight.Text != "")
            {
                decimal top = Convert.ToDecimal(lblTotalNetWeight.Text);
                lblTotalNetWeight.Text = String.Format("{0:N}", top);
            }
        }

        #endregion

    }
}
