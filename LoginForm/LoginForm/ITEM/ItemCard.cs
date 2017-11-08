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

namespace LoginForm.Item
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
                txtSSM.Text = sd.Pack_Quantity.ToString();
                txtUC.Text = sd.Unit_Content.ToString();
                txtUM.Text = sd.Unit_Measure;
                if (sd.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sd.Standard_Weight) / (decimal)1000).ToString("G29"); } else { }
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
                txtHeight.Text = ((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sd.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sd.Length * ((Decimal)100))).ToString("G29");
            }

            if (sdP != null)
            {
                txtStockNo.Text = sdP.Article_No;
                txtDesc.Text = sdP.Article_Desc;
                txtSSM.Text = sdP.Pack_Quantity.ToString();
                txtUC.Text = sdP.Unit_Content.ToString();
                txtUM.Text = sdP.Unit_Measure;
                if (sdP.Standard_Weight != 0) { txtStandartWeight.Text = ((decimal)(sdP.Standard_Weight) / (decimal)1000).ToString("G29"); }
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
                txtHeight.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
                txtWidth.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
                txtLength.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            }
            if (er != null)
            {
                txtStockNo.Text = er.ArticleNo;
                txtDesc.Text = er.ArticleDescription;
                txtMPN.Text = er.MPN;
                if (txtLength.Text != "") { txtLength.Text = ((decimal)(er.ExtendedRangeLength * ((Decimal)100))).ToString("G29"); }
                if (txtWidth.Text != "") { txtWidth.Text = ((decimal)(er.Width * ((Decimal)100))).ToString("G29"); }
                if (txtHeight.Text != "") { txtHeight.Text = ((decimal)(er.Height * ((Decimal)100))).ToString("G29"); }
                if (er.ExtendedRangeWeight != null) { txtStandartWeight.Text = ((decimal)(er.ExtendedRangeWeight) / (decimal)1000).ToString("G29"); }
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
                txtSupersectionName.Text = sp.SupersectionName;
                txtDesc.Text = sp.ItemTypeDesc;
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dgItemList.DataSource != null)
            {
                textsClear();
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
        private void textsClear()
        {
            txtUnitPrice.Text = "";
            txtNote.Text = "";
            txtQuantitiy.Text = "";
            txtStockNo.Text = "";
            txtDesc.Text = "";
            txtSSM.Text = "";
            txtUC.Text = "";
            txtUM.Text = "";
            txtStandartWeight.Text = "";
            txtHazardousInd.Text = "";
            txtCalibrationInd.Text = "";
            
            txtCoO.Text = "";
            txtCCCN.Text = "";
            
            txtUKDiscDate.Text = "";

            
            txtDiscCharge.Text = "";
            txtExpiringPro.Text = "";
            txtManufacturer.Text = "";
            txtMPN.Text = "";
            txtMHCodeLevel1.Text = "";
            txtCCCN.Text = "";
            txtWidth.Text = "";
            txtLength.Text = "";
            txtHeight.Text = "";
            txtStockNo.Text = "";
           
            txtUnitCount1.Text = "";
            txtUnitCount2.Text = "";
            txtUnitCount3.Text = "";
            txtUnitCount4.Text = "";
            txtUnitCount5.Text = "";
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
            txtSupersectionName.Text = "";
            txtDesc.Text = "";
            txtStockNo.Text = "";
            txtEnvironment.Text = "";
            txtLithium.Text = "";
            txtShipping.Text = "";
            txtStockNo.Text = "";
            txtRSStock.Text = "";
            txtRSOnOrder.Text = "";
            txtStockNo.Text = "";
            txtDiscontinuationDate.Text = "";
            txtRunOn.Text = "";
            txtReferral.Text = "";
            txtLicenceType.Text = "";
        }

        private void rbProductCode_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void rbMPNCode_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void rbFullLicence_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void rbSupplierCode_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void rbImport_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void rbProductName_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void rbEUU_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void rbDiscontinued_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void rbQuickSearch_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void rbItemNotes_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            textsClear();
        }

        private void Number_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount2.Text) && Int32.Parse(txtUnitCount1.Text) != 0)
                {
                    txtUnitPrice.Text = txtUK1.Text;
                }
                else if (Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount3.Text)&& Int32.Parse(txtUnitCount2.Text)!=0)
                {
                    txtUnitPrice.Text = txtUK2.Text;
                }
                else if (Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount4.Text) && Int32.Parse(txtUnitCount3.Text) != 0)
                {
                    txtUnitPrice.Text = txtUK3.Text;
                }
                else if (Int32.Parse(txtQuantitiy.Text) < Int32.Parse(txtUnitCount5.Text) && Int32.Parse(txtUnitCount4.Text) != 0)
                {
                    txtUnitPrice.Text = txtUK4.Text;
                }
                else if(Int32.Parse(txtUnitCount5.Text) != 0) { txtUnitPrice.Text = txtUK5.Text; }
            }
            catch { }

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
            if (txtHeight.Text != "" && txtLength.Text != "" && txtWidth.Text != "") { txtGrossWeight.Text = (Decimal.Parse(txtLength.Text) * Decimal.Parse(txtWidth.Text) * Decimal.Parse(txtHeight.Text) / 6000).ToString(); }
        }

        private void ArticleNo_TextChanged(object sender, EventArgs e)
        {
            if (txtStockNo.Text != "")
            {
                if (IME.ItemNotes.Where(c => c.ArticleNo == txtStockNo.Text).FirstOrDefault() != null) { txtNote.Text = IME.Notes.Where(b => b.ID == IME.ItemNotes.Where(a => a.ArticleNo == txtStockNo.Text).FirstOrDefault().NoteID).FirstOrDefault().Note_name; }
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
            }
        }

        private void ItemCard_Load(object sender, EventArgs e)
        {

        }
    }
}
