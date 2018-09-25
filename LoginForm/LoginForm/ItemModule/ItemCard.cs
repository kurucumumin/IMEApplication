using LoginForm.DataSet;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;
using System.Collections.Generic;

namespace LoginForm.ItemModule
{
    public partial class ItemCard : MyForm
    {
        IMEEntities IME = new IMEEntities();
        string txtSelected = "";
        int gridselectedindex = 0;
        decimal defaultCurrencyRate = 0;
        public ItemCard()
        {
            InitializeComponent();
            string currencySymbol = Utils.getManagement().Currency.currencySymbol;
            defaultCurrencyRate = (decimal)Utils.getManagement().Currency.ExchangeRates.OrderByDescending(a => a.date).FirstOrDefault().rate;
            lblCurrency.Text = currencySymbol;
            label65.Text = "WEB (" + currencySymbol + ")";
            dgItemList.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtQuantitiy.Text = "";
            gridselectedindex = 0;
            itemSelect();
            
        }

        private void itemSelect()
        {
            #region itemssearch
            //Seçilen txt grid e yansıyacak

            //Article no ile search
            txtSelected = txtSearchBox.Text;
            string ArticleNoSearch = "";
            label46.Text = "Save Note";
            txtNote.ReadOnly = false;
            txtQuantitiy.ReadOnly = false;
            //
            if (rbProductCode.Checked == true)
            {
                #region Itemcode Format
                if (txtSelected.ToString().Contains("-")) { txtSelected = txtSelected.ToString().Replace("-", string.Empty).ToString(); }
                if (txtSelected != null && txtSelected.ToString().Length == 6 || (txtSelected.ToString().Contains("P") && txtSelected.ToString().Length == 7)) { txtSelected = 0.ToString() + txtSelected.ToString(); }
                //0100-124 => 0100124
                #endregion
               
                //List Birleştirme
                #region List Birleştirme

                var gridAdapterPC = (from a in IME.Items.Where(a => a.ArticleNo.Contains(txtSelected))
                                     //join not in IME.ItemNotes on a.ArticleNo equals not.ArticleNo
                                     select new
                                     {
                                         ArticleNo = a.ArticleNo,
                                         ArticleDesc = a.ArticleDesc,
                                         a.MPN
                                         //not.Note.Note_name
                                     }
                             ).ToList();
            //    var list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_No.Contains(txtSelected))
            //                 join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
            //                 let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
            //                 select new
            //                 {
            //                     ArticleNo = a.Article_No,
            //                     ArticleDesc = a.Article_Desc,
            //                     a.MPN,
            //                    customerworker.Note.Note_name,
            //                     //a.CofO,
            //                     //a.Pack_Code
            //                 }
            //).ToList();
            //    var list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(txtSelected))
            //                 join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
            //                 let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
            //                 select new
            //                 {
            //                     ArticleNo = a.ArticleNo,
            //                     ArticleDesc = a.ArticleDescription,
            //                     a.MPN,
            //                     customerworker.Note.Note_name
            //                 }
            //                ).ToList();
            //    var list4 = (from a in IME.tbl_Item.Where(a=> a.StockNo.Contains(txtSelected))
            //                 select new
            //                 {
            //                     ArticleNo = a.StockNo,
            //                     ArticleDesc = a.ArticleDescription,
            //                     a.MPN,
            //                     Note_name= a.notes
            //                 }
            //                ).ToList();
            //    gridAdapterPC.AddRange(list2);
            //    gridAdapterPC.AddRange(list3);
            //    gridAdapterPC.AddRange(list4);
                //
                #endregion
                dgItemList.DataSource = gridAdapterPC;
                for (int i = 0; i < dgItemList.ColumnCount; i++)
                {
                    dgItemList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (gridAdapterPC.Count != 0)
                {
                    btnUpdate.Enabled = true;
                    ArticleNoSearch = gridAdapterPC[gridselectedindex].ArticleNo;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    MessageBox.Show("There is no such a data");
                    btnUpdate.Enabled = false;
                }
                
            }
            else if (rbMPNCode.Checked == true)
            {
                // MPN code ile search
                //List Birleştirme
                #region List Birleştirme
                var gridAdapterPC = (from a in IME.Items.Where(a => a.MPN.Contains(txtSelected))
                                     //join not in IME.ItemNotes on a.ArticleNo equals not.ArticleNo
                                     //where not.Note.ID == not.ID
                                     select new
                                     {
                                         ArticleNo = a.ArticleNo,
                                         ArticleDesc = a.ArticleDesc,
                                         a.MPN
                                         //not.Note.Note_name
                                     }
                             ).ToList();
                //var list2 = (from a in IME.SuperDiskPs.Where(a => a.MPN.Contains(txtSelected))
                //             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                //             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                //             select new
                //             {
                //                 ArticleNo = a.Article_No,
                //                 ArticleDesc = a.Article_Desc,
                //                 a.MPN,
                //                 customerworker.Note.Note_name,
                //             }
                //            ).ToList();
                //var list3 = (from a in IME.ExtendedRanges.Where(a => a.MPN.Contains(txtSelected))
                //             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                //             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                //             select new
                //             {
                //                 ArticleNo = a.ArticleNo,
                //                 ArticleDesc = a.ArticleDescription,
                //                 a.MPN,
                //                 customerworker.Note.Note_name,
                //             }
                //            ).ToList();
                //gridAdapterPC.AddRange(list2);
                //gridAdapterPC.AddRange(list3);
                //
                #endregion
                dgItemList.DataSource = gridAdapterPC;
                dgItemList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (gridAdapterPC.Count != 0)
                {
                    ArticleNoSearch = gridAdapterPC[gridselectedindex].ArticleNo;
                }
                else
                {
                    MessageBox.Show("There is no such a data");
                }
            }
            else if (rbProductName.Checked == true)
            {
                //List Birleştirme
                #region List Birleştirme
                var gridAdapterPC = (from a in IME.Items.Where(a => a.ArticleDesc.Contains(txtSelected))
                                     //join not in IME.ItemNotes on a.ArticleNo equals not.ArticleNo
                                     //where not.Note.ID == not.ID
                                     select new
                                     {
                                         ArticleNo = a.ArticleNo,
                                         ArticleDesc = a.ArticleDesc,
                                         a.MPN
                                         //not.Note.Note_name
                                     }
                             ).ToList();
                //var list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_Desc.Contains(txtSelected))
                //             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                //             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()

                //             select new
                //             {
                //                 ArticleNo = a.Article_No,
                //                 ArticleDesc = a.Article_Desc,
                //                 a.MPN,
                //                 customerworker.Note.Note_name,
                //             }
                //            ).ToList();
                //var list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleDescription.Contains(txtSelected))
                //             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                //             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()

                //             select new
                //             {
                //                 ArticleNo = a.ArticleNo,
                //                 ArticleDesc = a.ArticleDescription,
                //                 a.MPN,
                //                 customerworker.Note.Note_name,

                //             }
                //            ).ToList();
                //gridAdapterPC.AddRange(list2);
                //gridAdapterPC.AddRange(list3);
                //
                #endregion
                dgItemList.DataSource = gridAdapterPC;
                dgItemList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (gridAdapterPC.Count != 0)
                {
                    ArticleNoSearch = gridAdapterPC[gridselectedindex].ArticleNo;
                }
                else
                {
                    MessageBox.Show("There is no such a data");
                }
            }
            else if (rbItemNotes.Checked == true)
            {
                #region List Birleştirme
                var gridAdapterPC = (from not in IME.ItemNotes.Where(a => a.Note.Note_name.Contains(txtSelected))
                                     join a in IME.Items on not.ArticleNo equals a.ArticleNo
                                     select new
                                     {
                                         ArticleNo = a.ArticleNo,
                                         ArticleDesc = a.ArticleDesc,
                                         a.MPN,
                                         not.Note.Note_name
                                     }
                             ).ToList();
                //var list2 = (from a in IME.ItemNotes.Where(a => a.Note.Note_name.Contains(txtSelected))
                //             join sp in IME.SuperDiskPs on a.ArticleNo equals sp.Article_No
                //             select new
                //             {
                //                 ArticleNo = a.ArticleNo,
                //                 ArticleDesc = sp.Article_Desc,
                //                 sp.MPN,
                //                 a.Note.Note_name,
                //             }
                //            ).ToList();
                //var list3 = (from a in IME.ItemNotes.Where(a => a.Note.Note_name.Contains(txtSelected))
                //             join sp in IME.ExtendedRanges on a.ArticleNo equals sp.ArticleNo
                //             select new
                //             {
                //                 ArticleNo = a.ArticleNo,
                //                 ArticleDesc = sp.ArticleNo,
                //                 sp.MPN,
                //                 a.Note.Note_name,
                //             }
                //            ).ToList();
                //gridAdapterPC.AddRange(list2);
                //gridAdapterPC.AddRange(list3);
                //
                #endregion
                dgItemList.DataSource = gridAdapterPC;
                dgItemList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (gridAdapterPC.Count != 0)
                {
                    ArticleNoSearch = gridAdapterPC[gridselectedindex].ArticleNo;
                }
                else
                {
                    MessageBox.Show("There is no such a data");
                    label46.Text = "Edit Note";
                    txtNote.ReadOnly = true;
                }

            }
            #endregion
            if (dgItemList.RowCount > 0)
            {
                dgItemList.CurrentCell = dgItemList.Rows[gridselectedindex].Cells[0];
                Filler(ArticleNoSearch);
                Utils.LogKayit("Item Card Main", "Item Card Main search");
            }
        }

        private void Filler(string ArticleNoSearch)
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
            var i = IME.tbl_Item.Where(a => a.StockNo == ArticleNoSearch).FirstOrDefault();


            int coefficient = (int)IME.CompleteItems.Where(x => x.Article_No == ArticleNoSearch).FirstOrDefault().Unit_Content;


            if (sd != null)
            {
                txtStockNo.Text = sd.Article_No;
                txtDesc.Text = sd.Article_Desc;

                txtUC.Text = sd.Unit_Content.ToString();
                if (sd.Unit_Measure != null && sd.Unit_Measure != "")
                { txtUM.Text = sd.Unit_Measure; }
                else
                {
                    txtUM.Text = "Each";
                    SuppliedIn.Text = "";
                }
                txtSSM.Text = sd.Pack_Quantity.ToString();
                if (sd.Standard_Weight != 0)
                {
                    txtStandartWeight.Text = Decimal.Parse(String.Format("{0:0.0000}", ((decimal)(sd.Standard_Weight) / (decimal)1000).ToString("G29"))).ToString();
                    txtStandartWeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtStandartWeight.Text)).ToString();
                }
                else { }
                txtHazardousInd.Text = sd.Hazardous_Ind;
                txtCalibrationInd.Text = sd.Calibration_Ind;
                //ObsoluteFlag.Text = sd.Obsolete_Flag.ToString();
                //LowDiscontInd.Text = sd.Low_Discount_Ind;
                //LicensedInd.Text = sd.Licensed_Ind.ToString();
                //ShelfLife.Text = sd.Shelf_Life;
                txtCoO.Text = sd.CofO;
                txtCCCN.Text = sd.CCCN_No.ToString();
                //UKIntroDate.Text = sd.Uk_Intro_Date;
                txtUKDiscDate.Text = sd.Uk_Disc_Date;
                //BHCFlag.Text = sd.BHC_Flag.ToString();
                txtDiscCharge.Text = sd.Disc_Change_Ind;
                txtExpiringPro.Text = sd.Expiring_Product_Change_Ind;
                txtManufacturer.Text = sd.Manufacturer.ToString();
                txtMPN.Text = sd.MPN;
                txtMHCodeLevel1.Text = sd.MH_Code_Level_1;
                txtCCCN.Text = sd.CCCN_No.ToString();
                txtHeight.Text = String.Format("{0:0.0000}", ((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29"));
                txtHeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtHeight.Text)).ToString();
                txtWidth.Text = String.Format("{0:0.0000}", ((decimal)(sd.Width * ((Decimal)100))).ToString("G29"));
                txtWidth.Text = String.Format("{0:0.0000}", Decimal.Parse(txtWidth.Text)).ToString();
                txtLength.Text = String.Format("{0:0.0000}", ((decimal)(sd.Length * ((Decimal)100))).ToString("G29"));
                txtLength.Text = String.Format("{0:0.0000}", Decimal.Parse(txtLength.Text)).ToString();
                cmbSupplierName.SelectedIndex = cmbSupplierName.FindStringExact("RS");
                txtSupplierID.Text = cmbSupplierName.SelectedValue.ToString();

            }

            if (sdP != null)
            {
                txtStockNo.Text = sdP.Article_No;
                txtDesc.Text = sdP.Article_Desc;
                txtUC.Text = sdP.Unit_Content.ToString();
                if (sdP.Unit_Measure != null && sdP.Unit_Measure != "")
                { txtUM.Text = sdP.Unit_Measure; }
                else
                {
                    txtUM.Text = "Each";
                    SuppliedIn.Text = "";
                }
                txtSSM.Text = sdP.Pack_Quantity.ToString();
                if (sdP.Standard_Weight != 0) { txtStandartWeight.Text = String.Format("{0:0.0000}", ((decimal)(sdP.Standard_Weight) / (decimal)1000).ToString("G29")); }
                txtHazardousInd.Text = sdP.Hazardous_Ind;
                txtCalibrationInd.Text = sdP.Calibration_Ind;
                //ObsoluteFlag.Text = sdP.Obsolete_Flag.ToString();
                //LowDiscontInd.Text = sdP.Low_Discount_Ind;
                //LicensedInd.Text = sdP.Licensed_Ind.ToString();
                //ShelfLife.Text = sdP.Shelf_Life;
                txtCoO.Text = sdP.CofO;
                txtCCCN.Text = sdP.CCCN_No.ToString();
                //UKIntroDate.Text = sdP.Uk_Intro_Date;
                txtUKDiscDate.Text = sdP.Uk_Disc_Date;
                //BHCFlag.Text = sdP.BHC_Flag.ToString();
                txtDiscCharge.Text = sdP.Disc_Change_Ind;
                txtExpiringPro.Text = sdP.Expiring_Product_Change_Ind;
                txtManufacturer.Text = sdP.Manufacturer.ToString();
                txtMPN.Text = sdP.MPN;
                txtMHCodeLevel1.Text = sdP.MH_Code_Level_1;
                txtCCCN.Text = sdP.CCCN_No.ToString();
                txtHeight.Text = String.Format("{0:0.0000}", ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29"));
                txtHeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtHeight.Text)).ToString();
                txtWidth.Text = String.Format("{0:0.0000}", ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29"));
                txtWidth.Text = String.Format("{0:0.0000}", Decimal.Parse(txtWidth.Text)).ToString();
                txtLength.Text = String.Format("{0:0.0000}", ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29"));
                txtLength.Text = String.Format("{0:0.0000}", Decimal.Parse(txtLength.Text)).ToString();
                cmbSupplierName.SelectedIndex = cmbSupplierName.FindStringExact("RS");
                txtSupplierID.Text = cmbSupplierName.SelectedValue.ToString();


            }
            if (er != null)
            {
                txtStockNo.Text = er.ArticleNo;
                txtDesc.Text = er.ArticleDescription;
                txtMPN.Text = er.MPN;
                if (txtLength.Text != "")
                {
                    txtLength.Text = String.Format("{0:0.0000}", ((decimal)(er.ExtendedRangeLength * ((Decimal)100))).ToString("G29"));
                    txtLength.Text = String.Format("{0:0.0000}", Decimal.Parse(txtLength.Text)).ToString();
                }
                if (txtWidth.Text != "")
                {
                    txtWidth.Text = String.Format("{0:0.0000}", ((decimal)(er.Width * ((Decimal)100))).ToString("G29"));
                    txtWidth.Text = String.Format("{0:0.0000}", Decimal.Parse(txtWidth.Text)).ToString();
                }
                if (txtHeight.Text != "")
                {
                    txtHeight.Text = String.Format("{0:0.0000}", ((decimal)(er.Height * ((Decimal)100))).ToString("G29"));
                    txtHeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtHeight.Text)).ToString();
                }
                if (er.ExtendedRangeWeight != null)
                {
                    txtStandartWeight.Text = String.Format("{0:0.0000}", ((decimal)(er.ExtendedRangeWeight) / (decimal)1000).ToString("G29"));
                    txtStandartWeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtStandartWeight.Text)).ToString();
                }
                txtCCCN.Text = er.CCCN.ToString();
                txtCoO.Text = er.CountryofOrigin;
                txtUM.Text = er.UnitofMeasure;
                cmbSupplierName.SelectedIndex = cmbSupplierName.FindStringExact("RS");
                txtSupplierID.Text = cmbSupplierName.SelectedValue.ToString();

                txtUK1.Text = (er.Col1Price / coefficient).ToString();
                txtUK2.Text = (er.Col2Price / coefficient).ToString();
                txtUK3.Text = (er.Col3Price / coefficient).ToString();
                txtUK4.Text = (er.Col4Price / coefficient).ToString();
                txtUK5.Text = (er.Col5Price / coefficient).ToString();
                txtUnitCount1.Text = (er.Col1Break * coefficient).ToString();
                txtUnitCount2.Text = (er.Col2Break * coefficient).ToString();
                txtUnitCount3.Text = (er.Col3Break * coefficient).ToString();
                txtUnitCount4.Text = (er.Col4Break * coefficient).ToString();
                txtUnitCount5.Text = (er.Col5Break * coefficient).ToString();
                txtCost1.Text = (er.DiscountedPrice1 / coefficient).ToString();
                txtCost2.Text = (er.DiscountedPrice2 / coefficient).ToString();
                txtCost3.Text = (er.DiscountedPrice3 / coefficient).ToString();
                txtCost4.Text = (er.DiscountedPrice4 / coefficient).ToString();
                txtCost5.Text = (er.DiscountedPrice5 / coefficient).ToString();
                WebandMarginPrices();
            }
            if (sp != null)
            {
                txtStockNo.Text = sp.ArticleNo;
                //IntroductionDate.Text = sp.IntroductionDate;
                //DiscontinuedDate.Text = sp.DiscontinuedDate;
                txtUnitCount1.Text = (sp.Col1Break * coefficient).ToString();
                txtUnitCount2.Text = (sp.Col2Break * coefficient).ToString();
                txtUnitCount3.Text = (sp.Col3Break * coefficient).ToString();
                txtUnitCount4.Text = (sp.Col4Break * coefficient).ToString();
                txtUnitCount5.Text = (sp.Col5Break * coefficient).ToString();
                txtUK1.Text = (sp.Col1Price / coefficient).ToString();
                txtUK2.Text = (sp.Col2Price / coefficient).ToString();
                txtUK3.Text = (sp.Col3Price / coefficient).ToString();
                txtUK4.Text = (sp.Col4Price / coefficient).ToString();
                txtUK5.Text = (sp.Col5Price / coefficient).ToString();

                txtCost1.Text = (sp.DiscountedPrice1 / coefficient).ToString();
                txtCost2.Text = (sp.DiscountedPrice2 / coefficient).ToString();
                txtCost3.Text = (sp.DiscountedPrice3 / coefficient).ToString();
                txtCost4.Text = (sp.DiscountedPrice4 / coefficient).ToString();
                txtCost5.Text = (sp.DiscountedPrice5 / coefficient).ToString();
                WebandMarginPrices();
                txtSupersectionName.Text = sp.SupersectionName;
                txtDesc.Text = sp.ArticleDescription;
            }
            if (h != null)
            {
                txtStockNo.Text = h.ArticleNo;
                txtEnvironment.Text = h.Environment.ToString();
                txtLithium.Text = h.Lithium;
                txtShipping.Text = h.Shipping;
            }
            if (os != null)
            {
                txtStockNo.Text = os.ArticleNumber;
                //OnSaleDiscontinuedDate.Text = os.DiscontinuedDate;
                //OnSaleIntroductionDate.Text = os.IntroductionDate;
                txtRSStock.Text = os.OnhandStockBalance.ToString();
                txtRSOnOrder.Text = os.QuantityonOrder.ToString();

            }
            if (dd != null)
            {
                txtStockNo.Text = dd.ArticleNo;
                txtDiscontinuationDate.Text = dd.DiscontinuationDate;
                txtRunOn.Text = dd.Runon.ToString();
                txtReferral.Text = dd.Referral.ToString();
            }

            if (du != null) { txtLicenceType.Text = du.LicenceType; txtStockNo.Text = du.ArticleNo; }

            if (i != null)
            {
                txtStockNo.Text = i.StockNo;
                txtSupplierID.Text = i.SupplierID;
                cmbSupplierName.SelectedValue = cmbSupplierName.FindStringExact(i.SupplierName);
                cmbSupplierName.Text = i.SupplierName;
                txtDesc.Text = i.ArticleDescription;
                txtMPN.Text = i.MPN;
                txtManufacturer.Text = i.MFR;
                txtBrand.Text = i.Brandname;
                txtSupersectionName.Text = i.SupersectionName;
                txtSection.Text = i.SectionName;
                txtMHCodeLevel1.Text = i.MH;
                txtCoO.Text = i.CoO;
                txtCCCN.Text = i.CCCN;
                txtSSM.Text = i.SSM;
                txtUC.Text = i.UC;
                txtUM.Text = i.UM;
                if (i.DXB != null && i.DXB.ToString() != "") { txtIMEDXB.Text = i.DXB.ToString(); }
                if (i.ADH != null && i.ADH.ToString() != "") { txtIMEADH.Text = i.ADH.ToString(); }
                if (i.MCT != null && i.MCT.ToString() != "") { txtIMEMCT.Text = i.MCT.ToString(); }
                if (i.BHH != null && i.BHH.ToString() != "") { txtIMEBHH.Text = i.BHH.ToString(); }
                if (i.TUR != null && i.TUR.ToString() != "") { txtIMETUR.Text = i.TUR.ToString(); }
                if (i.Reserved != null && i.Reserved.ToString() != "") { txtIMEReserved.Text = i.Reserved.ToString(); }
                if (i.HZ != null && i.HZ.ToString() != "") { txtHazardousInd.Text = i.HZ.ToString(); }
                if (i.HE != null && i.HE.ToString() != "") { txtEnvironment.Text = i.HE.ToString(); }
                if (i.HS != null && i.HS.ToString() != "") { txtShipping.Text = i.HS.ToString(); }
                if (i.Li != null && i.Li.ToString() != "") { txtLithium.Text = i.Li.ToString(); }
                if (i.CL != null && i.CL.ToString() != "") { txtCalibrationInd.Text = i.CL.ToString(); }
                if (i.LC != null && i.LC.ToString() != "") { txtLicenceType.Text = i.LC.ToString(); }
                if (i.DC != null && i.DC.ToString() != "") { txtDiscCharge.Text = i.DC.ToString(); }
                if (i.EC != null && i.EC.ToString() != "") { txtExpiringPro.Text = i.EC.ToString(); }
                txtUKDiscDate.Text = i.Uk_Disc_Date;
                txtDiscontinuationDate.Text = i.DiscontinuationDate;
                if (i.Runon != null && i.Runon.ToString() != "") { txtRunOn.Text = i.Runon.ToString(); }
                if (i.Referral != null && i.Referral.ToString() != "") { txtReferral.Text = i.Referral.ToString(); }
                if (i.Heigh != null && i.Heigh.ToString() != "") { txtHeight.Text = i.Heigh.ToString(); }
                if (i.Width != null && i.Width.ToString() != "") { txtWidth.Text = i.Width.ToString(); }
                if (i.Length != null && i.Length.ToString() != "") { txtLength.Text = i.Length.ToString(); }
                if (i.Standard_Weight != null && i.Standard_Weight.ToString() != "") { txtStandartWeight.Text = i.Standard_Weight.ToString(); }
                if (i.Gross_Weight != null && i.Gross_Weight.ToString() != "") { txtGrossWeight.Text = i.Gross_Weight.ToString(); }
                if (i.Col1Break != null && i.Col1Break.ToString() != "") { txtUnitCount1.Text = i.Col1Break.ToString(); }
                if (i.Col2Break != null && i.Col2Break.ToString() != "") { txtUnitCount2.Text = i.Col2Break.ToString(); }
                if (i.Col3Break != null && i.Col3Break.ToString() != "") { txtUnitCount3.Text = i.Col3Break.ToString(); }
                if (i.Col4Break != null && i.Col4Break.ToString() != "") { txtUnitCount4.Text = i.Col4Break.ToString(); }
                if (i.Col5Break != null && i.Col5Break.ToString() != "") { txtUnitCount5.Text = i.Col5Break.ToString(); }
                if (i.DiscountedPrice1 != null && i.DiscountedPrice1.ToString() != "")
                {
                    txtCost1.Text = String.Format("{0:0}", Decimal.Parse(i.DiscountedPrice1.ToString())).ToString();
                    if (i.DiscountedPrice2 != null && i.DiscountedPrice2.ToString() != "") { txtCost2.Text = i.DiscountedPrice2.ToString(); }
                    if (i.DiscountedPrice3 != null && i.DiscountedPrice3.ToString() != "") { txtCost3.Text = i.DiscountedPrice3.ToString(); }
                    if (i.DiscountedPrice4 != null && i.DiscountedPrice4.ToString() != "") { txtCost4.Text = i.DiscountedPrice4.ToString(); }
                    if (i.DiscountedPrice5 != null && i.DiscountedPrice5.ToString() != "") { txtCost5.Text = i.DiscountedPrice5.ToString(); }
                    txtNote.Text = i.notes;
                }

                //
                #endregion
                if (txtLithium.Text != "") { label64.BackColor = Color.Red; }
                if (txtShipping.Text != "") { label63.BackColor = Color.Red; }
                if (txtEnvironment.Text != "") { label53.BackColor = Color.Red; }
            }
        }

         private void WebandMarginPrices()
        {
            decimal factor;
            factor = Utils.getManagement().Factor / defaultCurrencyRate;
            if (txtUK1.Text != "" && txtUK1.Text != null) txtWeb1.Text = (decimal.Parse(txtUK1.Text) * factor).ToString();
            if (txtUK2.Text != "" && txtUK2.Text != null) txtWeb2.Text = (decimal.Parse(txtUK2.Text) * factor).ToString();
            if (txtUK3.Text != "" && txtUK3.Text != null) txtWeb3.Text = (decimal.Parse(txtUK3.Text) * factor).ToString();
            if (txtUK4.Text != "" && txtUK4.Text != null) txtWeb4.Text = (decimal.Parse(txtUK4.Text) * factor).ToString();
            if (txtUK5.Text != "" && txtUK5.Text != null) txtWeb5.Text = (decimal.Parse(txtUK5.Text) * factor).ToString();
            txtMargin1.Text = ""; txtMargin2.Text = ""; txtMargin3.Text = ""; txtMargin4.Text = ""; txtMargin5.Text = "";
            if (txtCost1.Text != "" && txtCost1.Text != null && Int32.Parse(txtUnitCount1.Text) != 0) txtMargin1.Text = ((1 - (decimal.Parse(txtCost1.Text) / decimal.Parse(txtUK1.Text))) * 100).ToString();
            if (txtCost2.Text != "" && txtCost2.Text != null && Int32.Parse(txtUnitCount2.Text) != 0) txtMargin2.Text = ((1 - (decimal.Parse(txtCost2.Text) / decimal.Parse(txtUK2.Text))) * 100).ToString();
            if (txtCost3.Text != "" && txtCost3.Text != null && Int32.Parse(txtUnitCount3.Text) != 0) txtMargin3.Text = ((1 - (decimal.Parse(txtCost3.Text) / decimal.Parse(txtUK3.Text))) * 100).ToString();
            if (txtCost4.Text != "" && txtCost4.Text != null && Int32.Parse(txtUnitCount4.Text) != 0) txtMargin4.Text = ((1 - (decimal.Parse(txtCost4.Text) / decimal.Parse(txtUK4.Text))) * 100).ToString();
            if (txtCost5.Text != "" && txtCost5.Text != null && Int32.Parse(txtUnitCount5.Text) != 0) txtMargin5.Text = ((1 - (decimal.Parse(txtCost5.Text) / decimal.Parse(txtUK5.Text))) * 100).ToString();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dgItemList.DataSource != null)
            {
                ClearAll(this);
                if (dgItemList.RowCount > 0)
                {
                    gridselectedindex = dgItemList.CurrentCell.RowIndex;
                }
                Filler(dgItemList.Rows[gridselectedindex].Cells["ArticleNo"].Value.ToString());
                if (dgItemList.RowCount > 0)
                {
                    dgItemList.ClearSelection();
                    dgItemList.CurrentCell = dgItemList.Rows[gridselectedindex].Cells[0];
                }
            }

        }

        private void rbProductCode_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbMPNCode_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbFullLicence_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbSupplierCode_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbImport_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbProductName_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbEUU_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbDiscontinued_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbQuickSearch_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbItemNotes_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void Number_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantitiy.Text, out int value))
            {
                if (txtQuantitiy.Text != "" && txtQuantitiy.Text != null)
                {
                    txtUnitPrice.Text = string.Empty;
                    MessageBox.Show("Please enter a valid number");
                }
            }
            else
            {

                try
                {
                    if ((txtStockNo.Text != "" && txtStockNo.Text != null) && (!(txtQuantitiy.Text == string.Empty || Int32.Parse(txtQuantitiy.Text) == 0)))
                    {
                        if ((Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount2.Text) && Int32.Parse(txtUnitCount1.Text) != 0) || Int32.Parse(txtUnitCount2.Text) == 0)
                        {
                            txtUnitPrice.Text = txtWeb1.Text;
                        }
                        else if ((Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount3.Text) && Int32.Parse(txtUnitCount2.Text) != 0) || Int32.Parse(txtUnitCount3.Text) == 0)
                        {
                            txtUnitPrice.Text = txtWeb2.Text;
                        }
                        else if ((Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount4.Text) && Int32.Parse(txtUnitCount3.Text) != 0) || Int32.Parse(txtUnitCount4.Text) == 0)
                        {
                            txtUnitPrice.Text = txtWeb3.Text;
                        }
                        else if ((Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount5.Text) && Int32.Parse(txtUnitCount4.Text) != 0) || Int32.Parse(txtUnitCount5.Text) == 0)
                        {
                            txtUnitPrice.Text = txtWeb4.Text;
                        }
                        else if (Int32.Parse(txtUnitCount5.Text) != 0) { txtUnitPrice.Text = txtWeb5.Text; }
                        
                        decimal UnitPrice = decimal.Parse(txtUnitPrice.Text);
                        txtTotal.Text = String.Format("{0:0.0000}", (value * UnitPrice).ToString("G29"));

                    }
                    else { txtUnitPrice.Text = string.Empty; }
                }
                catch
                {

                }
            }
        }

        private void Environment_TextChanged(object sender, EventArgs e)
        {
            if (txtEnvironment.Text != "") { label53.BackColor = Color.Red; } else { label53.BackColor = Color.White; }
        }

        private void Lithium_TextChanged(object sender, EventArgs e)
        {
            if (txtLithium.Text != "") { label64.BackColor = Color.Red; } else { label64.BackColor = Color.White; }

        }

        private void Shipping_TextChanged(object sender, EventArgs e)
        {
            if (txtShipping.Text != "") { label63.BackColor = Color.Red; } else { label63.BackColor = Color.White; }
        }

        private void Length_TextChanged(object sender, EventArgs e)
        {
            txtGrossWeight.Text = "";
            if (txtHeight.Text != "" && txtLength.Text != "" && txtWidth.Text != "") { txtGrossWeight.Text = String.Format("{0:0.0000}",(Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString());
                txtGrossWeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtGrossWeight.Text)).ToString();}

            
        }

        private void ArticleNo_TextChanged(object sender, EventArgs e)
        {
            if (txtStockNo.Text != "")
            {
                if (IME.ItemNotes.Where(c => c.ArticleNo == txtStockNo.Text).FirstOrDefault() != null) { txtNote.Text = IME.Notes.Where(b => b.ID == IME.ItemNotes.Where(a => a.ArticleNo == txtStockNo.Text).FirstOrDefault().NoteID).FirstOrDefault().Note_name; }
                //getOtherBrnachesStocks(txtStockNo.Text);
            }
        }

        //private void getOtherBrnachesStocks(string ArticleCode)
        //{
        //    var OtherBrnachesStocks = IME.OtherBranchStockSearch(ArticleCode);
        //    if (OtherBrnachesStocks!=null)
        //    {
        //        if (OtherBrnachesStocks.Where(a => a.CompanyID == 1).FirstOrDefault() != null)//company ID si değişebilir
        //        {
        //            txtIMEDXB.Text= OtherBrnachesStocks.Where(a => a.CompanyID == 1).FirstOrDefault().Quantity.ToString();
        //        }
        //    }
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (label43.Text == "Save")
            {
                    #region Item tablosu
                    var i = IME.tbl_Item.Where(a => a.StockNo == txtStockNo.Text).FirstOrDefault();

                    if (i != null)
                    {
                        i.StockNo = txtStockNo.Text;
                        i.SupplierID = txtSupplierID.Text;
                        if (cmbSupplierName.SelectedItem != null)
                        {
                            i.SupplierName = ((Supplier)cmbSupplierName.SelectedItem).s_name;
                        }
                        i.ArticleDescription = txtDesc.Text;
                        i.MPN = txtMPN.Text;
                        i.MFR = txtManufacturer.Text;
                        i.Brandname = txtBrand.Text;
                        i.SupersectionName = txtSupersectionName.Text;
                        i.SectionName = txtSection.Text;
                        i.MH = txtMHCodeLevel1.Text;
                        i.CoO = txtCoO.Text;
                        i.CCCN = txtCCCN.Text;
                        i.SSM = txtSSM.Text;
                        i.UC = txtUC.Text;
                        i.UM = txtUM.Text;
                        if (txtIMEDXB.Text != null && txtIMEDXB.Text != "") { i.DXB = Convert.ToInt32(txtIMEDXB.Text); }
                        if (txtIMEADH.Text != null && txtIMEADH.Text != "") { i.ADH = Convert.ToInt32(txtIMEADH.Text); }
                        if (txtIMEMCT.Text != null && txtIMEMCT.Text != "") { i.MCT = Convert.ToInt32(txtIMEMCT.Text); }
                        if (txtIMEBHH.Text != null && txtIMEBHH.Text != "") { i.BHH = Convert.ToInt32(txtIMEBHH.Text); }
                        if (txtIMETUR.Text != null && txtIMETUR.Text != "") { i.TUR = Convert.ToInt32(txtIMETUR.Text); }
                        if (txtIMEReserved.Text != null && txtIMEReserved.Text != "") { i.Reserved = Convert.ToInt32(txtIMEReserved.Text); }
                        if (txtHazardousInd.Text != null && txtHazardousInd.Text != "") { i.HZ = Convert.ToBoolean(txtHazardousInd.Text); }
                        if (txtEnvironment.Text != null && txtEnvironment.Text != "") { i.HE = Convert.ToBoolean(txtEnvironment.Text); }
                        if (txtShipping.Text != null && txtShipping.Text != "") { i.HS = Convert.ToBoolean(txtShipping.Text); }
                        if (txtLithium.Text != null && txtLithium.Text != "") { i.Li = Convert.ToBoolean(txtLithium.Text); }
                        if (txtCalibrationInd.Text != null && txtCalibrationInd.Text != "") { i.CL = Convert.ToBoolean(txtCalibrationInd.Text); }
                        if (txtLicenceType.Text != null && txtLicenceType.Text != "") { i.LC = Convert.ToBoolean(txtLicenceType.Text); }
                        if (txtDiscCharge.Text != null && txtDiscCharge.Text != "") { i.DC = Convert.ToBoolean(txtDiscCharge.Text); }
                        if (txtExpiringPro.Text != null && txtExpiringPro.Text != "") { i.EC = Convert.ToBoolean(txtExpiringPro.Text); }
                        i.Uk_Disc_Date = txtUKDiscDate.Text;
                        i.DiscontinuationDate = txtDiscontinuationDate.Text;
                        if (txtRunOn.Text != null && txtRunOn.Text != "") { i.Runon = txtRunOn.Text; }
                        if (txtReferral.Text != null && txtReferral.Text != "") { i.Referral = txtReferral.Text; }
                        if (txtHeight.Text != null && txtHeight.Text != "") { i.Heigh = Convert.ToDecimal(txtHeight.Text); }
                        if (txtWidth.Text != null && txtWidth.Text != "") { i.Width = Convert.ToDecimal(txtWidth.Text); }
                        if (txtLength.Text != null && txtLength.Text != "") { i.Length = Convert.ToDecimal(txtLength.Text); }
                        if (txtStandartWeight.Text != null && txtStandartWeight.Text != "") { i.Standard_Weight = Convert.ToDecimal(txtStandartWeight.Text); }
                        if (txtGrossWeight.Text != null && txtGrossWeight.Text != "") { i.Gross_Weight = Convert.ToDecimal(txtGrossWeight.Text); }
                        if (txtUnitCount1.Text != null && txtUnitCount1.Text != "") { i.Col1Break = Convert.ToInt32(txtUnitCount1.Text); }
                        if (txtUnitCount2.Text != null && txtUnitCount2.Text != "") { i.Col2Break = Convert.ToInt32(txtUnitCount2.Text); }
                        if (txtUnitCount3.Text != null && txtUnitCount3.Text != "") { i.Col3Break = Convert.ToInt32(txtUnitCount3.Text); }
                        if (txtUnitCount4.Text != null && txtUnitCount4.Text != "") { i.Col4Break = Convert.ToInt32(txtUnitCount4.Text); }
                        if (txtUnitCount5.Text != null && txtUnitCount5.Text != "") { i.Col5Break = Convert.ToInt32(txtUnitCount5.Text); }
                        if (txtCost1.Text != null && txtCost1.Text != "") { i.DiscountedPrice1 = Convert.ToInt32(txtCost1.Text); }
                        if (txtCost2.Text != null && txtCost2.Text != "") { i.DiscountedPrice2 = Convert.ToInt32(txtCost2.Text); }
                        if (txtCost3.Text != null && txtCost3.Text != "") { i.DiscountedPrice3 = Convert.ToInt32(txtCost3.Text); }
                        if (txtCost4.Text != null && txtCost4.Text != "") { i.DiscountedPrice4 = Convert.ToInt32(txtCost4.Text); }
                        if (txtCost5.Text != null && txtCost5.Text != "") { i.DiscountedPrice5 = Convert.ToInt32(txtCost5.Text); }
                        i.notes = txtNote.Text;

                    IME.SaveChanges();
                    MessageBox.Show("Item updated successfully");
                    Utils.LogKayit("Item Card Main", "Item Card update");
                    label43.Text = "Update Item";
                }      
                    #endregion

                    #region Superdisk
                    var sd = IME.SuperDisks.Where(a => a.Article_No == txtStockNo.Text).FirstOrDefault();

                    if (sd != null)
                    {
                        txtStockNo.Text = sd.Article_No;
                        txtDesc.Text = sd.Article_Desc;

                        txtUC.Text = sd.Unit_Content.ToString();
                        if (sd.Unit_Measure != null && sd.Unit_Measure != "")
                        { txtUM.Text = sd.Unit_Measure; }
                        else
                        {
                            txtUM.Text = "Each";
                            SuppliedIn.Text = "";
                        }
                        txtSSM.Text = sd.Pack_Quantity.ToString();
                        if (sd.Standard_Weight != 0)
                        {
                            txtStandartWeight.Text = Decimal.Parse(String.Format("{0:0.0000}", ((decimal)(sd.Standard_Weight) / (decimal)1000).ToString("G29"))).ToString();
                            txtStandartWeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtStandartWeight.Text)).ToString();
                        }
                        else { }
                        txtHazardousInd.Text = sd.Hazardous_Ind;
                        txtCalibrationInd.Text = sd.Calibration_Ind;
                        //ObsoluteFlag.Text = sd.Obsolete_Flag.ToString();
                        //LowDiscontInd.Text = sd.Low_Discount_Ind;
                        //LicensedInd.Text = sd.Licensed_Ind.ToString();
                        //ShelfLife.Text = sd.Shelf_Life;
                        txtCoO.Text = sd.CofO;
                        txtCCCN.Text = sd.CCCN_No.ToString();
                        //UKIntroDate.Text = sd.Uk_Intro_Date;
                        txtUKDiscDate.Text = sd.Uk_Disc_Date;
                        //BHCFlag.Text = sd.BHC_Flag.ToString();
                        txtDiscCharge.Text = sd.Disc_Change_Ind;
                        txtExpiringPro.Text = sd.Expiring_Product_Change_Ind;
                        txtManufacturer.Text = sd.Manufacturer.ToString();
                        txtMPN.Text = sd.MPN;
                        txtMHCodeLevel1.Text = sd.MH_Code_Level_1;
                        txtCCCN.Text = sd.CCCN_No.ToString();
                        txtHeight.Text = String.Format("{0:0.0000}", ((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29"));
                        txtHeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtHeight.Text)).ToString();
                        txtWidth.Text = String.Format("{0:0.0000}", ((decimal)(sd.Width * ((Decimal)100))).ToString("G29"));
                        txtWidth.Text = String.Format("{0:0.0000}", Decimal.Parse(txtWidth.Text)).ToString();
                        txtLength.Text = String.Format("{0:0.0000}", ((decimal)(sd.Length * ((Decimal)100))).ToString("G29"));
                        txtLength.Text = String.Format("{0:0.0000}", Decimal.Parse(txtLength.Text)).ToString();

                    IME.SaveChanges();
                    MessageBox.Show("Item updated successfully");
                    Utils.LogKayit("Item Card Main", "Item Card update");
                    label43.Text = "Update Item";
                }
                    #endregion

                    
            }
            else
            {
                ReadOnlyAll(false);
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                label43.Text = "Save";
                label42.Text = "Cancel";
            }
            
        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantitiy.Text = "";
                gridselectedindex = 0;
                itemSelect();
                dgItemList.Select();
            }
        }

        private void dgItemList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgItemList.CurrentCell != null)
            {
                if (dgItemList.DataSource != null)
                {
                    ClearAll(this);
                    if (dgItemList.RowCount > 0)
                    {
                        gridselectedindex = dgItemList.CurrentCell.RowIndex;
                    }
                    Filler(dgItemList.Rows[gridselectedindex].Cells["ArticleNo"].Value.ToString());
                    if (dgItemList.RowCount > 0)
                    {
                        dgItemList.ClearSelection();
                        dgItemList.CurrentCell = dgItemList.Rows[gridselectedindex].Cells[0];
                    }
                }
            }
        }

        private void ControlAutorization()
        {
            if (!Utils.AuthorityCheck(IMEAuthority.CanAddNoteinItemCard) && !Utils.AuthorityCheck(IMEAuthority.CanEditNoteinItemCard))
            {
                btnUpdate.Visible = false;
            }
        }

        private void GetImageFromWeb(string URL)
        {
            //try { pictureBox1.Load("https://media.rs-online.com/t_large/Y1373331-01.jpg"); } catch { }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ItemCard_Load(object sender, EventArgs e)
        {
            cmbSupplierName.DisplayMember = "s_name";
            cmbSupplierName.ValueMember = "ID";
            cmbSupplierName.DataSource = IME.Suppliers.ToList();
            cmbSupplierName.SelectedIndex = -1;

            checkAuthorities();
            //ControlAutorization();
            GetImageFromWeb(null);
            ReadOnlyAll(true);
        }

        private void txtSSM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtSSM.Text)>1)
                {
                    SuppliedIn.Text = "Package of " + txtSSM.Text;
                }else if (Int32.Parse(txtUC.Text) > 1)
                {
                    SuppliedIn.Text = txtUM.Text+ " of " + txtUC.Text;
                }
            }
            catch
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (label45.Text == "Save")
            {
                if (NullControl())
                {
                    if (txtHazardousInd.Text.ToLower() == "y")
                    {
                        if (txtShipping.Text.ToLower() != "y" && txtEnvironment.Text.ToLower() != "y")
                        {
                            MessageBox.Show("Hazarduse ürün, Environment(HE) yada Shipping(HS) olmalı");
                            
                        }
                        else
                        {
                            Save();
                        }
                    }
                    else
                    {
                        Save();
                    }

                }    
            }
            else
            {
                AddScreen();
            }
        }

        private void Save()
        {
            tbl_Item i = new tbl_Item();

            i.StockNo = txtStockNo.Text;
            i.SupplierID = txtSupplierID.Text;
            if (cmbSupplierName.SelectedItem != null)
            {
                i.SupplierName = ((Supplier)cmbSupplierName.SelectedItem).s_name;
            }
            i.ArticleDescription = txtDesc.Text;
            i.MPN = txtMPN.Text;
            i.MFR = txtManufacturer.Text;
            i.Brandname = txtBrand.Text;
            i.SupersectionName = txtSupersectionName.Text;
            i.SectionName = txtSection.Text;
            i.MH = txtMHCodeLevel1.Text;
            i.CoO = txtCoO.Text;
            i.CCCN = txtCCCN.Text;
            i.SSM = txtSSM.Text;
            i.UC = txtUC.Text;
            i.UM = txtUM.Text;
            if (txtIMEDXB.Text != null && txtIMEDXB.Text != "") { i.DXB = Convert.ToInt32(txtIMEDXB.Text); }
            if (txtIMEADH.Text != null && txtIMEADH.Text != "") { i.ADH = Convert.ToInt32(txtIMEADH.Text); }
            if (txtIMEMCT.Text != null && txtIMEMCT.Text != "") { i.MCT = Convert.ToInt32(txtIMEMCT.Text); }
            if (txtIMEBHH.Text != null && txtIMEBHH.Text != "") { i.BHH = Convert.ToInt32(txtIMEBHH.Text); }
            if (txtIMETUR.Text != null && txtIMETUR.Text != "") { i.TUR = Convert.ToInt32(txtIMETUR.Text); }
            if (txtIMEReserved.Text != null && txtIMEReserved.Text != "") { i.Reserved = Convert.ToInt32(txtIMEReserved.Text); }
            if (txtHazardousInd.Text != null && txtHazardousInd.Text != "" && txtHazardousInd.Text.ToLower() != "y") { i.HZ = false; } else { i.HZ =true; }
            if (txtEnvironment.Text != null && txtEnvironment.Text != "" && txtEnvironment.Text.ToLower() != "y") { i.HE = false; } else { i.HE = true; }
            if (txtShipping.Text != null && txtShipping.Text != "" && txtShipping.Text.ToLower() != "y") { i.HS = false; } else { i.HS = true; }
            if (txtLithium.Text != null && txtLithium.Text != "" && txtLithium.Text.ToLower() != "y") { i.Li = false; } else { i.Li = true; }
            if (txtCalibrationInd.Text != null && txtCalibrationInd.Text != "" && txtCalibrationInd.Text.ToLower() != "y") { i.CL = false; } else { i.CL = true; }
            if (txtLicenceType.Text != null && txtLicenceType.Text != "" && txtLicenceType.Text.ToLower() != "y") { i.LC = false; } else { i.LC = true; }
            if (txtDiscCharge.Text != null && txtDiscCharge.Text != "" && txtDiscCharge.Text.ToLower() != "y") { i.DC = false; } else { i.DC = true; }
            if (txtExpiringPro.Text != null && txtExpiringPro.Text != "" && txtExpiringPro.Text.ToLower() != "y") { i.EC = false; } else { i.EC = true; }
            i.Uk_Disc_Date = txtUKDiscDate.Text;
            i.DiscontinuationDate = txtDiscontinuationDate.Text;
            if (txtRunOn.Text != null && txtRunOn.Text != "") { i.Runon = txtRunOn.Text; }
            if (txtReferral.Text != null && txtReferral.Text != "") { i.Referral = txtReferral.Text; }
            if (txtHeight.Text != null && txtHeight.Text != "") { i.Heigh = Convert.ToDecimal(txtHeight.Text); }
            if (txtWidth.Text != null && txtWidth.Text != "") { i.Width = Convert.ToDecimal(txtWidth.Text); }
            if (txtLength.Text != null && txtLength.Text != "") { i.Length = Convert.ToDecimal(txtLength.Text); }
            if (txtStandartWeight.Text != null && txtStandartWeight.Text != "") { i.Standard_Weight = Convert.ToDecimal(txtStandartWeight.Text); }
            if (txtGrossWeight.Text != null && txtGrossWeight.Text != "") { i.Gross_Weight = Convert.ToDecimal(txtGrossWeight.Text); }
            if (txtUnitCount1.Text != null && txtUnitCount1.Text != "") { i.Col1Break = Convert.ToInt32(txtUnitCount1.Text); }
            if (txtUnitCount2.Text != null && txtUnitCount2.Text != "") { i.Col2Break = Convert.ToInt32(txtUnitCount2.Text); }
            if (txtUnitCount3.Text != null && txtUnitCount3.Text != "") { i.Col3Break = Convert.ToInt32(txtUnitCount3.Text); }
            if (txtUnitCount4.Text != null && txtUnitCount4.Text != "") { i.Col4Break = Convert.ToInt32(txtUnitCount4.Text); }
            if (txtUnitCount5.Text != null && txtUnitCount5.Text != "") { i.Col5Break = Convert.ToInt32(txtUnitCount5.Text); }
            if (txtCost1.Text != null && txtCost1.Text != "") { i.DiscountedPrice1 = Convert.ToInt32(txtCost1.Text); }
            if (txtCost2.Text != null && txtCost2.Text != "") { i.DiscountedPrice2 = Convert.ToInt32(txtCost2.Text); }
            if (txtCost3.Text != null && txtCost3.Text != "") { i.DiscountedPrice3 = Convert.ToInt32(txtCost3.Text); }
            if (txtCost4.Text != null && txtCost4.Text != "") { i.DiscountedPrice4 = Convert.ToInt32(txtCost4.Text); }
            if (txtCost5.Text != null && txtCost5.Text != "") { i.DiscountedPrice5 = Convert.ToInt32(txtCost5.Text); }
            i.notes = txtNote.Text;

            IME.tbl_Item.Add(i);
            IME.SaveChanges();
            MessageBox.Show("Item added!", "Success");
            Utils.LogKayit("Item Card Main", "Item Card added");
            ClearAll(this);
            CancelScreen();
        }

        private bool NullControl()
        {
            bool isSave = true;
            string ErrorMessage = string.Empty;
            if (txtStockNo.Text == null || txtStockNo.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Stock No\n"; isSave = false; }
            if (txtMPN.Text == null || txtMPN.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter MPN\n"; isSave = false; }
            if (txtBrand.Text == null || txtBrand.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter Brand\n"; isSave = false; }
            if (txtSSM.Text == null || txtSSM.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter SSM\n"; isSave = false; }
            if (txtUC.Text == null || txtUC.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter UC\n"; isSave = false; }
            if (txtUM.Text == null || txtUM.Text == string.Empty) { ErrorMessage = ErrorMessage + "Please Enter UM\n"; isSave = false; }
            if (isSave == true) { return true; } else { MessageBox.Show(ErrorMessage); return false; }
        }

        private void CancelScreen()
        {
            ClearAll(this);
            ReadOnlyAll(true);
            dgItemList.Enabled = true;
            groupBox7.Enabled = true;
            panel1.Enabled = true;
            btnAdd.Enabled = true;
            label45.Text = "Add Item";
            label43.Text = "Update Item";
            label42.Text = "Close";
            label1.Font = new Font(label1.Font, FontStyle.Regular);
            label1.ForeColor = Color.Black;
            label39.Font = new Font(label39.Font, FontStyle.Regular);
            label39.ForeColor = Color.Black;
            label27.Font = new Font(label27.Font, FontStyle.Regular);
            label27.ForeColor = Color.Black;
            label37.Font = new Font(label37.Font, FontStyle.Regular);
            label37.ForeColor = Color.Black;
            label2.Font = new Font(label2.Font, FontStyle.Regular);
            label2.ForeColor = Color.Black;
            label4.Font = new Font(label4.Font, FontStyle.Regular);
            label4.ForeColor = Color.Black;
            label52.Font = new Font(label52.Font, FontStyle.Regular);
            label52.ForeColor = Color.Black;
        }

        private void AddScreen()
        {
            ClearAll(this);
            ReadOnlyAll(false);
            cmbSupplierName.DisplayMember = "s_name";
            cmbSupplierName.ValueMember = "ID";
            cmbSupplierName.DataSource = IME.Suppliers.ToList();
            txtStockNo.Text = NewItemID();
            dgItemList.Enabled = false;
            groupBox7.Enabled = false;
            panel1.Enabled = false;
            label45.Text = "Save";
            label42.Text = "Cancel";
            label1.Font = new Font(label1.Font, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label39.Font = new Font(label39.Font, FontStyle.Bold);
            label39.ForeColor = Color.Red;
            label27.Font = new Font(label27.Font, FontStyle.Bold);
            label27.ForeColor = Color.Red;
            label37.Font = new Font(label37.Font, FontStyle.Bold);
            label37.ForeColor = Color.Red;
            label2.Font = new Font(label2.Font, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label4.Font = new Font(label4.Font, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label52.Font = new Font(label52.Font, FontStyle.Bold);
            label52.ForeColor = Color.Red;

        }

        private void ClearAll(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    ClearAll(c);
                }
            }
            cmbSupplierName.Text = "";
            SuppliedIn.Text = "";
        }

        private void ReadOnlyAll(bool loop)
        {
            txtBrand.ReadOnly = loop;
            txtCalibrationInd.ReadOnly = loop;
            txtCCCN.ReadOnly = loop;
            txtCoO.ReadOnly = loop;
            txtCost1.ReadOnly = loop;
            txtCost2.ReadOnly = loop;
            txtCost3.ReadOnly = loop;
            txtCost4.ReadOnly = loop;
            txtCost5.ReadOnly = loop;
            txtDesc.ReadOnly = loop;
            txtDiscCharge.ReadOnly = loop;
            txtDiscontinuationDate.ReadOnly = loop;
            txtEnvironment.ReadOnly = loop;
            txtExpiringPro.ReadOnly = loop;
            txtGrossWeight.ReadOnly = loop;
            txtHazardousInd.ReadOnly = loop;
            txtHeight.ReadOnly = loop;
            txtIMEADH.ReadOnly = loop;
            txtIMEBHH.ReadOnly = loop;
            txtIMEDXB.ReadOnly = loop;
            txtIMEMCT.ReadOnly = loop;
            txtIMEReserved.ReadOnly = loop;
            txtIMETUR.ReadOnly = loop;
            txtLength.ReadOnly = loop;
            txtLicenceType.ReadOnly = loop;
            txtLithium.ReadOnly = loop;
            txtManufacturer.ReadOnly = loop;
            txtMargin1.ReadOnly = loop;
            txtMargin2.ReadOnly = loop;
            txtMargin3.ReadOnly = loop;
            txtMargin4.ReadOnly = loop;
            txtMargin5.ReadOnly = loop;
            txtMHCodeLevel1.ReadOnly = loop;
            txtMPN.ReadOnly = loop;
            txtNote.ReadOnly = loop;
            txtQuantitiy.ReadOnly = loop;
            txtReferral.ReadOnly = loop;
            txtRSOnOrder.ReadOnly = loop;
            txtRSStock.ReadOnly = loop;
            txtRunOn.ReadOnly = loop;
            txtSection.ReadOnly = loop;
            txtShipping.ReadOnly = loop;
            txtSSM.ReadOnly = loop;
            txtStandartWeight.ReadOnly = loop;
            txtStockNo.ReadOnly = true;
            txtSubstitutedBy.ReadOnly = loop;
            txtSupersectionName.ReadOnly = loop;
            //txtSupplierID.ReadOnly = loop;
            txtTotal.ReadOnly = loop;
            txtUC.ReadOnly = loop;
            txtUK1.ReadOnly = loop;
            txtUK2.ReadOnly = loop;
            txtUK3.ReadOnly = loop;
            txtUK4.ReadOnly = loop;
            txtUK5.ReadOnly = loop;
            txtUKDiscDate.ReadOnly = loop;
            txtUM.ReadOnly = loop;
            txtUnitCount1.ReadOnly = loop;
            txtUnitCount2.ReadOnly = loop;
            txtUnitCount3.ReadOnly = loop;
            txtUnitCount4.ReadOnly = loop;
            txtUnitCount5.ReadOnly = loop;
            txtUnitPrice.ReadOnly = loop;
            txtWeb1.ReadOnly = loop;
            txtWeb2.ReadOnly = loop;
            txtWeb3.ReadOnly = loop;
            txtWeb4.ReadOnly = loop;
            txtWeb5.ReadOnly = loop;
            txtWidth.ReadOnly = loop;
            textBox13.ReadOnly = loop;
            textBox14.ReadOnly = loop;
            SuppliedIn.ReadOnly = loop;

            if (loop==true)
            {
                cmbSupplierName.Enabled = false;
                btnSupplierAdd.Visible = false;
                groupBox9.Enabled = false;
                groupBox5.Enabled = false;
            }
            else
            {
                cmbSupplierName.Enabled = true;
                btnSupplierAdd.Visible = true;
            }
            btnUpdate.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (label42.Text != "Cancel")
            {
                this.Close();
            }
            else
            {
                CancelScreen();
            }
        }

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplierName.SelectedIndex == -1)
            {
                txtSupplierID.Text = String.Empty;
            }
            else
            {
                //txtSupplierID.Text = IME.Suppliers.Where(a => a.ID == ((Supplier)(cmbSupplierName).SelectedItem).ID).FirstOrDefault().ID;
                txtSupplierID.Text = cmbSupplierName.SelectedValue.ToString();
            }
        }

        private void btnSupplierAdd_Click(object sender, EventArgs e)
        {
            ____frmSupplierMain form = new ____frmSupplierMain();
            form.ShowDialog();
            cmbSupplierName.DataSource = IME.Suppliers.ToList();
            cmbSupplierName.DisplayMember = "s_name";
            cmbSupplierName.ValueMember = "ID";
        }

        private string NewItemID()
        {
            IMEEntities IME = new IMEEntities();
            string no = "";
            int ID = 0;
            try { no = IME.tbl_Item.FirstOrDefault().StockNo;}   catch { }
            if (no != null && no != "")
            {
                ID = Int32.Parse(no) + 1;
                return ID.ToString();
            }
            else
            {
                no = "1000000";
                return no;
            }
            
        }

        private void btnEditNote_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            //label46.Text = "Save Note";

            if (txtStockNo.Text != null && txtStockNo.Text != "" && label46.Text == "Save Note")
            {
                ItemNote note = IME.ItemNotes.Where(a => a.ArticleNo == txtStockNo.Text).FirstOrDefault();
                

                if (note == null)
                {
                    ItemNote inot = new ItemNote();

                    inot.ArticleNo = txtStockNo.Text;

                    Note n = new Note();

                    n.Note_name = txtNote.Text;

                    IME.Notes.Add(n);
                    IME.SaveChanges();

                    inot.NoteID = n.ID;

                    IME.ItemNotes.Add(inot);
                    IME.SaveChanges();
                    MessageBox.Show("Item note edit successfully");
                    Utils.LogKayit("Item Card Main", "Item Card added note");
                    label46.Text = "Edit Note";
                }
                else
                {
                    

                    note.ArticleNo = txtStockNo.Text;

                    Note n = IME.Notes.Where(a => a.ID == note.NoteID).FirstOrDefault();

                    n.Note_name = txtNote.Text;
                    note.NoteID = n.ID;

                    IME.SaveChanges();
                    MessageBox.Show("Item note modify successfully");
                    Utils.LogKayit("Item Card Main", "Item Card modify note");
                    label46.Text = "Edit Note";
                }
                IME.SaveChanges();
            }
            else
            {
                MessageBox.Show("Please selected item");
                label46.Text = "Edit Note";
            }
        }

        public void checkAuthorities()
        {
            List<DataSet.AuthorizationValue> authList = Utils.getCurrentUser().AuthorizationValues.ToList();

            if (!Utils.AuthorityCheck(IMEAuthority.CanAddNoteinItemCard))
            {
                btnEditNote.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanSeeMargine) && !Utils.AuthorityCheck(IMEAuthority.CanSeeCost))
            {
                txtCost1.Visible = false;
                txtCost2.Visible = false;
                txtCost3.Visible = false;
                txtCost4.Visible = false;
                txtCost5.Visible = false;

                txtMargin1.Visible = false;
                txtMargin2.Visible = false;
                txtMargin3.Visible = false;
                txtMargin4.Visible = false;
                txtMargin5.Visible = false;
            }

            if (!Utils.AuthorityCheck(IMEAuthority.CanAddItemCard) && !Utils.AuthorityCheck(IMEAuthority.CanEditItemCard))
            {
                btnAdd.Visible = false;
                btnUpdate.Visible = false;
            }
        }
    }
}
