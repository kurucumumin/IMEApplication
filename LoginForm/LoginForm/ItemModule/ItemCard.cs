using LoginForm.DataSet;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;

namespace LoginForm.ItemModule
{
    public partial class ItemCard : Form
    {
        IMEEntities IME = new IMEEntities();
        string txtSelected = "";
        int gridselectedindex = 0;
        public ItemCard()
        {
            InitializeComponent();
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

                var gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.Article_No.Contains(txtSelected))
                                     join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                                     let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         a.MPN,
                                         customerworker.Note.Note_name,
                                     }
                             ).ToList();
                var list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_No.Contains(txtSelected))
                             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 a.MPN,
                                customerworker.Note.Note_name,
                                 //a.CofO,
                                 //a.Pack_Code
                             }
            ).ToList();
                var list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(txtSelected))
                             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,
                                 a.MPN,
                                 customerworker.Note.Note_name
                             }
                            ).ToList();
                gridAdapterPC.AddRange(list2);
                gridAdapterPC.AddRange(list3);
                //
                #endregion
                dgItemList.DataSource = gridAdapterPC;
                for (int i = 0; i < dgItemList.ColumnCount; i++)
                {
                    dgItemList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (gridAdapterPC.Count != 0)
                {
                    ArticleNoSearch = gridAdapterPC[gridselectedindex].ArticleNo;
                }
                else
                {
                    MessageBox.Show("There is no such a data");
                }
                
            }
            else if (rbMPNCode.Checked == true)
            {
                // MPN code ile search
                //List Birleştirme
                #region List Birleştirme
                var gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.MPN.Contains(txtSelected))
                                     join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                                     let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         a.MPN,
                                         customerworker.Note.Note_name,
                                     }
                             ).ToList();
                var list2 = (from a in IME.SuperDiskPs.Where(a => a.MPN.Contains(txtSelected))
                             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 a.MPN,
                                 customerworker.Note.Note_name,
                             }
                            ).ToList();
                var list3 = (from a in IME.ExtendedRanges.Where(a => a.MPN.Contains(txtSelected))
                             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,
                                 a.MPN,
                                 customerworker.Note.Note_name,
                             }
                            ).ToList();
                gridAdapterPC.AddRange(list2);
                gridAdapterPC.AddRange(list3);
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
                var gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.Article_Desc.Contains(txtSelected))
                                     join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                                     let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()

                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         a.MPN,
                                         customerworker.Note.Note_name,
                                     }
                             ).ToList();
                var list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_Desc.Contains(txtSelected))
                             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()

                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 a.MPN,
                                 customerworker.Note.Note_name,
                             }
                            ).ToList();
                var list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleDescription.Contains(txtSelected))
                             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()

                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,
                                 a.MPN,
                                 customerworker.Note.Note_name,

                             }
                            ).ToList();
                gridAdapterPC.AddRange(list2);
                gridAdapterPC.AddRange(list3);
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
            }else if (rbItemNotes.Checked == true)
            {
                #region List Birleştirme
                var gridAdapterPC = (from a in IME.ItemNotes.Where(a => a.Note.Note_name.Contains(txtSelected))
                                     join sp in IME.SuperDisks on a.ArticleNo equals sp.Article_No
                                     select new
                                     {
                                         ArticleNo = a.ArticleNo,
                                         ArticleDesc = sp.Article_Desc,
                                         sp.MPN,
                                         a.Note.Note_name,
                                     }
                             ).ToList();
                var list2 = (from a in IME.ItemNotes.Where(a => a.Note.Note_name.Contains(txtSelected))
                             join sp in IME.SuperDiskPs on a.ArticleNo equals sp.Article_No
                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = sp.Article_Desc,
                                 sp.MPN,
                                 a.Note.Note_name,
                             }
                            ).ToList();
                var list3 = (from a in IME.ItemNotes.Where(a => a.Note.Note_name.Contains(txtSelected))
                             join sp in IME.ExtendedRanges on a.ArticleNo equals sp.ArticleNo
                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = sp.ArticleNo,
                                 sp.MPN,
                                 a.Note.Note_name,
                             }
                            ).ToList();
                gridAdapterPC.AddRange(list2);
                gridAdapterPC.AddRange(list3);
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


            #endregion
            if (dgItemList.RowCount > 0)
            {
                dgItemList.CurrentCell = dgItemList.Rows[gridselectedindex].Cells[0];
                Filler(ArticleNoSearch);
                //
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
                if (sd.Standard_Weight != 0) { txtStandartWeight.Text = Decimal.Parse(String.Format("{0:0.0000}",((decimal)(sd.Standard_Weight) / (decimal)1000).ToString("G29"))).ToString();
                    txtStandartWeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtStandartWeight.Text)).ToString();} else { }
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
                txtHeight.Text = String.Format("{0:0.0000}",((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29"));
                txtHeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtHeight.Text)).ToString();
                txtWidth.Text = String.Format("{0:0.0000}",((decimal)(sd.Width * ((Decimal)100))).ToString("G29"));
                txtWidth.Text = String.Format("{0:0.0000}", Decimal.Parse(txtWidth.Text)).ToString();
                txtLength.Text = String.Format("{0:0.0000}",((decimal)(sd.Length * ((Decimal)100))).ToString("G29"));
                txtLength.Text = String.Format("{0:0.0000}", Decimal.Parse(txtLength.Text)).ToString();
            }

            if (sdP != null)
            {
                txtStockNo.Text = sdP.Article_No;
                txtDesc.Text = sdP.Article_Desc;
                txtUC.Text = sd.Unit_Content.ToString();
                if (sd.Unit_Measure != null && sd.Unit_Measure != "")
                { txtUM.Text = sd.Unit_Measure; }
                else
                {
                    txtUM.Text = "Each";
                    SuppliedIn.Text = "";
                }
                txtSSM.Text = sd.Pack_Quantity.ToString();
                if (sdP.Standard_Weight != 0) { txtStandartWeight.Text = String.Format("{0:0.0000}",((decimal)(sdP.Standard_Weight) / (decimal)1000).ToString("G29")); }
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
                txtHeight.Text = String.Format("{0:0.0000}",((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29"));
                txtHeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtHeight.Text)).ToString();
                txtWidth.Text = String.Format("{0:0.0000}",((decimal)(sdP.Width * ((Decimal)100))).ToString("G29"));
                txtWidth.Text = String.Format("{0:0.0000}", Decimal.Parse(txtWidth.Text)).ToString();
                txtLength.Text = String.Format("{0:0.0000}",((decimal)(sdP.Length * ((Decimal)100))).ToString("G29"));
                txtLength.Text = String.Format("{0:0.0000}", Decimal.Parse(txtLength.Text)).ToString();



            }
            if (er != null)
            {
                txtStockNo.Text = er.ArticleNo;
                txtDesc.Text = er.ArticleDescription;
                txtMPN.Text = er.MPN;
                if (txtLength.Text != "") { txtLength.Text = String.Format("{0:0.0000}", ((decimal)(er.ExtendedRangeLength * ((Decimal)100))).ToString("G29"));
                    txtLength.Text = String.Format("{0:0.0000}", Decimal.Parse(txtLength.Text)).ToString();
                }
                if (txtWidth.Text != "") { txtWidth.Text = String.Format("{0:0.0000}", ((decimal)(er.Width * ((Decimal)100))).ToString("G29"));
                    txtWidth.Text = String.Format("{0:0.0000}", Decimal.Parse(txtWidth.Text)).ToString();
                }
                if (txtHeight.Text != "") { txtHeight.Text = String.Format("{0:0.0000}", ((decimal)(er.Height * ((Decimal)100))).ToString("G29"));
                    txtHeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtHeight.Text)).ToString();
                }
                if (er.ExtendedRangeWeight != null) { txtStandartWeight.Text = String.Format("{0:0.0000}",((decimal)(er.ExtendedRangeWeight) / (decimal)1000).ToString("G29"));
                    txtStandartWeight.Text = String.Format("{0:0.0000}", Decimal.Parse(txtStandartWeight.Text)).ToString();
                }
                txtCCCN.Text = er.CCCN.ToString();
                txtCoO.Text = er.CountryofOrigin;
                txtUM.Text = er.UnitofMeasure;
                
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
                WebandMarginPrices();
            }
            if (sp != null)
            {
                txtStockNo.Text = sp.ArticleNo;
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
            //
            #endregion
            if (txtLithium.Text != "") { label64.BackColor = Color.Red; }
            if (txtShipping.Text != "") { label63.BackColor = Color.Red; }
            if (txtEnvironment.Text != "") { label53.BackColor = Color.Red; }
        }


         private void WebandMarginPrices()
        {
            decimal factor;
            factor = Utils.getManagement().Factor / (decimal)IME.ExchangeRates.Where(a => a.Currency.currencyName == "Pound").OrderByDescending(a => a.date).FirstOrDefault().rate;
            if (txtUK1.Text != "" && txtUK1.Text != null) txtWeb1.Text = (decimal.Parse(txtUK1.Text) * factor).ToString();
            if (txtUK2.Text != "" && txtUK2.Text != null) txtWeb2.Text = (decimal.Parse(txtUK2.Text) * factor).ToString();
            if (txtUK3.Text != "" && txtUK3.Text != null) txtWeb3.Text = (decimal.Parse(txtUK3.Text) * factor).ToString();
            if (txtUK4.Text != "" && txtUK4.Text != null) txtWeb4.Text = (decimal.Parse(txtUK4.Text) * factor).ToString();
            if (txtUK5.Text != "" && txtUK5.Text != null) txtWeb5.Text = (decimal.Parse(txtUK5.Text) * factor).ToString();
            txtMargin1.Text = ""; txtMargin2.Text = ""; txtMargin3.Text = ""; txtMargin4.Text = ""; txtMargin5.Text = "";
            if (txtCost1.Text != "" && txtCost1.Text != null && Int32.Parse(txtUnitCount1.Text) != 0) txtMargin1.Text = ((1 - (decimal.Parse(txtCost1.Text) / decimal.Parse(txtWeb1.Text))) * 100).ToString();
            if (txtCost2.Text != "" && txtCost2.Text != null && Int32.Parse(txtUnitCount2.Text) != 0) txtMargin2.Text = ((1 - (decimal.Parse(txtCost2.Text) / decimal.Parse(txtWeb2.Text))) * 100).ToString();
            if (txtCost3.Text != "" && txtCost3.Text != null && Int32.Parse(txtUnitCount3.Text) != 0) txtMargin3.Text = ((1 - (decimal.Parse(txtCost3.Text) / decimal.Parse(txtWeb3.Text))) * 100).ToString();
            if (txtCost4.Text != "" && txtCost4.Text != null && Int32.Parse(txtUnitCount4.Text) != 0) txtMargin4.Text = ((1 - (decimal.Parse(txtCost4.Text) / decimal.Parse(txtWeb4.Text))) * 100).ToString();
            if (txtCost5.Text != "" && txtCost5.Text != null && Int32.Parse(txtUnitCount5.Text) != 0) txtMargin5.Text = ((1 - (decimal.Parse(txtCost5.Text) / decimal.Parse(txtWeb5.Text))) * 100).ToString();

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
        //private void textsClear()
        //{
        //    txtUnitPrice.Text = "";
        //    txtNote.Text = "";
        //    txtQuantitiy.Text = "";
        //    txtStockNo.Text = "";
        //    txtDesc.Text = "";
        //    txtSSM.Text = "";
        //    txtUC.Text = "";
        //    txtUM.Text = "";
        //    txtStandartWeight.Text = "";
        //    txtHazardousInd.Text = "";
        //    txtCalibrationInd.Text = "";
        //    txtCoO.Text = "";
        //    txtCCCN.Text = "";
        //    txtUKDiscDate.Text = "";
        //    txtDiscCharge.Text = "";
        //    txtExpiringPro.Text = "";
        //    txtManufacturer.Text = "";
        //    txtMPN.Text = "";
        //    txtMHCodeLevel1.Text = "";
        //    txtCCCN.Text = "";
        //    txtWidth.Text = "";
        //    txtLength.Text = "";
        //    txtHeight.Text = "";
        //    txtStockNo.Text = "";
        //    txtUnitCount1.Text = "";
        //    txtUnitCount2.Text = "";
        //    txtUnitCount3.Text = "";
        //    txtUnitCount4.Text = "";
        //    txtUnitCount5.Text = "";
        //    txtUK1.Text = "";
        //    txtUK2.Text = "";
        //    txtUK3.Text = "";
        //    txtUK4.Text = "";
        //    txtUK5.Text = "";
        //    txtCost1.Text = "";
        //    txtCost2.Text = "";
        //    txtCost3.Text = "";
        //    txtCost4.Text = "";
        //    txtCost5.Text = "";
        //    txtSupersectionName.Text = "";
        //    txtDesc.Text = "";
        //    txtStockNo.Text = "";
        //    txtEnvironment.Text = "";
        //    txtLithium.Text = "";
        //    txtShipping.Text = "";
        //    txtStockNo.Text = "";
        //    txtRSStock.Text = "";
        //    txtRSOnOrder.Text = "";
        //    txtStockNo.Text = "";
        //    txtDiscontinuationDate.Text = "";
        //    txtRunOn.Text = "";
        //    txtReferral.Text = "";
        //    txtLicenceType.Text = "";
        //}

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
            int value;
            if (!int.TryParse(txtQuantitiy.Text, out value))
            {
                if(txtQuantitiy.Text!="" && txtQuantitiy.Text != null)
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
                            txtUnitPrice.Text = txtUK1.Text;
                        }
                        else if ((Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount3.Text) && Int32.Parse(txtUnitCount2.Text) != 0) || Int32.Parse(txtUnitCount3.Text) == 0)
                        {
                            txtUnitPrice.Text = txtUK2.Text;
                        }
                        else if ((Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount4.Text) && Int32.Parse(txtUnitCount3.Text) != 0) || Int32.Parse(txtUnitCount4.Text) == 0)
                        {
                            txtUnitPrice.Text = txtUK3.Text;
                        }
                        else if ((Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount5.Text) && Int32.Parse(txtUnitCount4.Text) != 0) || Int32.Parse(txtUnitCount5.Text) == 0)
                        {
                            txtUnitPrice.Text = txtUK4.Text;
                        }
                        else if (Int32.Parse(txtUnitCount5.Text) != 0) { txtUnitPrice.Text = txtUK5.Text; }
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
                getOtherBrnachesStocks(txtStockNo.Text);
            }
        }

        private void getOtherBrnachesStocks(string ArticleCode)
        {
            var OtherBrnachesStocks = IME.OtherBranchStockSearch(ArticleCode);
            if (OtherBrnachesStocks!=null)
            {
                if (OtherBrnachesStocks.Where(a => a.CompanyID == 1).FirstOrDefault() != null)//company ID si değişebilir
                {
                    txtIMEDXB.Text= OtherBrnachesStocks.Where(a => a.CompanyID == 1).FirstOrDefault().Quantity.ToString();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var Updnote = IME.ItemNotes.Where(a => a.ArticleNo == txtStockNo.Text).FirstOrDefault();
            if (Updnote != null)
            {
                var note = IME.Notes.Where(a => a.ID == Updnote.NoteID).FirstOrDefault();
                note.Note_name = txtNote.Text;
                IME.SaveChanges();
                MessageBox.Show("Note updated successfully");
            }
            else
            {
                var note = new Note();
                note.Note_name = txtNote.Text;
                IME.Notes.Add(note);
                IME.SaveChanges();
                var newNoteID = new ItemNote();
                newNoteID.NoteID = note.ID;
                newNoteID.ArticleNo = txtStockNo.Text;
                IME.ItemNotes.Add(newNoteID);
                IME.SaveChanges();
                MessageBox.Show("Note added to item successfully");
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
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1102).FirstOrDefault() == null && Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1103).FirstOrDefault() == null)
            {
                btnUpdateNote.Visible = false;
            }
        }

        private void GetImageFromWeb(string URL)
        {
            try { pictureBox1.Load("https://media.rs-online.com/t_large/Y1373331-01.jpg"); } catch { }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ItemCard_Load(object sender, EventArgs e)
        {
            ControlAutorization();
            GetImageFromWeb(null);
            ReadOnlyAll(true);
            cmbSupplierName.DataSource = IME.Suppliers.ToList();
            cmbSupplierName.DisplayMember = "s_name";
            cmbSupplierName.ValueMember = "ID";
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

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtUnitPrice.Text==""|| txtUnitPrice.Text == null)
            {
                txtTotal.Text = "";
            }
            else
            {
                int qty = Int32.Parse(txtQuantitiy.Text);
                decimal UnitPrice = decimal.Parse(txtUnitPrice.Text);
                txtTotal.Text = String.Format("{0:0.0000}", (qty * UnitPrice).ToString("G29"));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Save")
            {
                if (txtHazardousInd.Text.ToLower() == "Y".ToLower())
                {
                    if (txtShipping.Text.ToLower() != "Y".ToLower() && txtRSStock.Text.ToLower() != "Y".ToLower())
                    {
                        MessageBox.Show("Hazarduse ürün, Environment(HE) yada Shipping(HS) olmalı");
                    }
                }

                Item i = new Item();

                i.StockNo = txtStockNo.Text;

                IME.Item.Add(i);
                IME.SaveChanges();

            }
            else
            {
                AddScreen();
            }
        }

        private void CancelScreen()
        {
            ClearAll(this);
            ReadOnlyAll(true);
            dgItemList.Enabled = true;
            groupBox7.Enabled = true;
            panel1.Enabled = true;
            btnUpdateNote.Enabled = true;
            btnAdd.Text = "Add Item";
            btnClose.Text = "Close";
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
            dgItemList.Enabled = false;
            groupBox7.Enabled = false;
            panel1.Enabled = false;
            btnUpdateNote.Enabled = false;
            btnAdd.Text = "Save";
            btnClose.Text = "Cancel";
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
        }

        private void ReadOnlyAll(bool loop)
        {
            txtStockNo.ReadOnly = loop;
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
            txtStockNo.ReadOnly = loop;
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
            }
            else
            {
                cmbSupplierName.Enabled = true;
                btnSupplierAdd.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text != "Cancel")
            {
                if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                CancelScreen();
            }
        }

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSupplierID.Text= IME.Suppliers.Where(a => a.ID == ((Supplier)(cmbSupplierName).SelectedItem).ID).FirstOrDefault().ID;
        }

        private void btnSupplierAdd_Click(object sender, EventArgs e)
        {
            frmSupplierMain form = new frmSupplierMain();
            form.ShowDialog();
            cmbSupplierName.DataSource = IME.Suppliers.ToList();
            cmbSupplierName.DisplayMember = "s_name";
            cmbSupplierName.ValueMember = "ID";
        }

    }
}
