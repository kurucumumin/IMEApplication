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

namespace ItemCard1
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

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox63_TextChanged(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void textBox62_TextChanged(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Number.Text = "";
            gridselectedindex = 0;
            itemSelect();
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void Substitute_TextChanged(object sender, EventArgs e)
        {

        }

        private void itemSelect()
        {
            #region itemssearch
            //Seçilen txt grid e yansıyacak

            //Article no ile search
            txtSelected = SearchText.Text;
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
                dataGridView1.DataSource = gridAdapterPC;
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
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         //a.MH1,
                                         //a.CofO,
                                         //a.Pack_Code
                                     }
                             ).ToList();
                var list2 = (from a in IME.SuperDiskPs.Where(a => a.MPN.Contains(txtSelected))
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 //a.MH1,
                                 //a.CofO,
                                 //a.Pack_Code
                             }
                            ).ToList();
                var list3 = (from a in IME.ExtendedRanges.Where(a => a.MPN.Contains(txtSelected))
                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,


                             }
                            ).ToList();
                gridAdapterPC.AddRange(list2);
                gridAdapterPC.AddRange(list3);
                //
                #endregion
                dataGridView1.DataSource = gridAdapterPC;
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
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         //a.MH1,
                                         //a.CofO,
                                         //a.Pack_Code
                                     }
                             ).ToList();
                var list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_Desc.Contains(txtSelected))
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 //a.MH1,
                                 //a.CofO,
                                 //a.Pack_Code
                             }
                            ).ToList();
                var list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleDescription.Contains(txtSelected))
                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,


                             }
                            ).ToList();
                gridAdapterPC.AddRange(list2);
                gridAdapterPC.AddRange(list3);
                //
                #endregion
                dataGridView1.DataSource = gridAdapterPC;
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
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[gridselectedindex].Selected = true;// tüm row u seçtirmek için bu formülü kullnınca selectedrow index =0 oluyor
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
                ArticleNo.Text = sd.Article_No;
                ArticleDesc.Text = sd.Article_Desc;
                PackQuan.Text = sd.Pack_Quantity.ToString();
                UnitContent.Text = sd.Unit_Content.ToString();
                UnitMeasure.Text = sd.Unit_Measure;
                if (sd.Standard_Weight != 0) { StandartWeight.Text = ((decimal)(sd.Standard_Weight) / (decimal)100).ToString("G29"); } else { }
                HazardousInd.Text = sd.Hazardous_Ind;
                CalibrationInd.Text = sd.Calibration_Ind;
                ObsoluteFlag.Text = sd.Obsolete_Flag.ToString();
                LowDiscontInd.Text = sd.Low_Discount_Ind;
                LicensedInd.Text = sd.Licensed_Ind.ToString();
                ShelfLife.Text = sd.Shelf_Life;
                CofO.Text = sd.CofO;
                CCCNNo.Text = sd.CCCN_No.ToString();
                UKIntroDate.Text = sd.Uk_Intro_Date;
                UKDiscDate.Text = sd.Uk_Disc_Date;
                BHCFlag.Text = sd.BHC_Flag.ToString();
                DiscCharge.Text = sd.Disc_Change_Ind;
                Expiringpro.Text = sd.Expiring_Product_Change_Ind;
                Manufacturer.Text = sd.Manufacturer.ToString();
                MPN.Text = sd.MPN;
                MHCodeLevel1.Text = sd.MH_Code_Level_1;
                CCCNNo.Text = sd.CCCN_No.ToString();
                Height.Text = ((decimal)(sd.Heigh * ((Decimal)100))).ToString("G29");
                Width.Text = ((decimal)(sd.Width * ((Decimal)100))).ToString("G29");
                Length.Text = ((decimal)(sd.Length * ((Decimal)100))).ToString("G29");
            }

            if (sdP != null)
            {
                ArticleNo.Text = sdP.Article_No;
                ArticleDesc.Text = sdP.Article_Desc;
                PackQuan.Text = sdP.Pack_Quantity.ToString();
                UnitContent.Text = sdP.Unit_Content.ToString();
                UnitMeasure.Text = sdP.Unit_Measure;
                if (sdP.Standard_Weight != 0) { StandartWeight.Text = ((decimal)(sdP.Standard_Weight) / (decimal)100).ToString("G29"); }
                HazardousInd.Text = sdP.Hazardous_Ind;
                CalibrationInd.Text = sdP.Calibration_Ind;
                ObsoluteFlag.Text = sdP.Obsolete_Flag.ToString();
                LowDiscontInd.Text = sdP.Low_Discount_Ind;
                LicensedInd.Text = sdP.Licensed_Ind.ToString();
                ShelfLife.Text = sdP.Shelf_Life;
                CofO.Text = sdP.CofO;
                CCCNNo.Text = sdP.CCCN_No.ToString();
                UKIntroDate.Text = sdP.Uk_Intro_Date;
                UKDiscDate.Text = sdP.Uk_Disc_Date;
                BHCFlag.Text = sdP.BHC_Flag.ToString();
                DiscCharge.Text = sdP.Disc_Change_Ind;
                Expiringpro.Text = sdP.Expiring_Product_Change_Ind;
                Manufacturer.Text = sdP.Manufacturer.ToString();
                MPN.Text = sdP.MPN;
                MHCodeLevel1.Text = sdP.MH_Code_Level_1;
                CCCNNo.Text = sdP.CCCN_No.ToString();
                Height.Text = ((decimal)(sdP.Heigh * ((Decimal)100))).ToString("G29");
                Width.Text = ((decimal)(sdP.Width * ((Decimal)100))).ToString("G29");
                Length.Text = ((decimal)(sdP.Length * ((Decimal)100))).ToString("G29");
            }
            if (er != null)
            {
                ArticleNo.Text = er.ArticleNo;
                ArticleDesc.Text = er.ArticleDescription;
                MPN.Text = er.MPN;
                if (Length.Text != "") { Length.Text = ((decimal)(er.ExtendedRangeLength * ((Decimal)100))).ToString("G29"); }
                if (Width.Text != "") { Width.Text = ((decimal)(er.Width * ((Decimal)100))).ToString("G29"); }
                if (Height.Text != "") { Height.Text = ((decimal)(er.Height * ((Decimal)100))).ToString("G29"); }
                if (er.ExtendedRangeWeight != null) { StandartWeight.Text = ((decimal)(er.ExtendedRangeWeight) / (decimal)100).ToString("G29"); }
                CCCNNo.Text = er.CCCN.ToString();
                CofO.Text = er.CountryofOrigin;
                UnitMeasure.Text = er.UnitofMeasure;
                ColPrice1.Text = er.Col1Price.ToString();
                ColPrice2.Text = er.Col2Price.ToString();
                ColPrice3.Text = er.Col3Price.ToString();
                ColPrice4.Text = er.Col4Price.ToString();
                ColPrice5.Text = er.Col5Price.ToString();
                ColBreak1.Text = er.Col1Break.ToString();
                ColBreak2.Text = er.Col2Break.ToString();
                ColBreak3.Text = er.Col3Break.ToString();
                ColBreak4.Text = er.Col4Break.ToString();
                ColBreak5.Text = er.Col5Break.ToString();
                DiscountedPrice1.Text = er.DiscountedPrice1.ToString();
                DiscountedPrice2.Text = er.DiscountedPrice2.ToString();
                DiscountedPrice3.Text = er.DiscountedPrice3.ToString();
                DiscountedPrice4.Text = er.DiscountedPrice4.ToString();
                DiscountedPrice5.Text = er.DiscountedPrice5.ToString();
            }
            if (sp != null)
            {
                ArticleNo.Text = sp.ArticleNo;
                IntroductionDate.Text = sp.IntroductionDate;
                DiscontinuedDate.Text = sp.DiscontinuedDate;
                ColBreak1.Text = sp.Col1Break.ToString();
                ColBreak2.Text = sp.Col2Break.ToString();
                ColBreak3.Text = sp.Col3Break.ToString();
                ColBreak4.Text = sp.Col4Break.ToString();
                ColBreak5.Text = sp.Col5Break.ToString();
                ColPrice1.Text = sp.Col1Price.ToString();
                ColPrice2.Text = sp.Col2Price.ToString();
                ColPrice3.Text = sp.Col3Price.ToString();
                ColPrice4.Text = sp.Col4Price.ToString();
                ColPrice5.Text = sp.Col5Price.ToString();
                DiscountedPrice1.Text = sp.DiscountedPrice1.ToString();
                DiscountedPrice2.Text = sp.DiscountedPrice2.ToString();
                DiscountedPrice3.Text = sp.DiscountedPrice3.ToString();
                DiscountedPrice4.Text = sp.DiscountedPrice4.ToString();
                DiscountedPrice5.Text = sp.DiscountedPrice5.ToString();
                SupersectionName.Text = sp.SupersectionName;
                ArticleDesc.Text = sp.ItemTypeDesc;
            }
            if (h != null)
            {
                ArticleNo.Text = h.ArticleNo;
                Environment.Text = h.Environment.ToString();
                Lithium.Text = h.Lithium;
                Shipping.Text = h.Shipping;
            }
            if (os != null)
            {
                ArticleNo.Text = os.ArticleNumber;
                OnSaleDiscontinuedDate.Text = os.DiscontinuedDate;
                OnSaleIntroductionDate.Text = os.IntroductionDate;
                OnhandStockBalance.Text = os.OnhandStockBalance.ToString();
                QuantityonOrder.Text = os.QuantityonOrder.ToString();

            }
            if (dd != null)
            {
                ArticleNo.Text = dd.ArticleNo;
                DiscontinuationDate.Text = dd.DiscontinuationDate;
                RunOn.Text = dd.Runon.ToString();
                Referral.Text = dd.Referral.ToString();
            }

            if (du != null) { LicenceType.Text = du.LicenceType; ArticleNo.Text = du.ArticleNo; }
            //
            #endregion
            if (Lithium.Text != "") { label64.BackColor = Color.Red; }
            if (Shipping.Text != "") { label63.BackColor = Color.Red; }
            if (Environment.Text != "") { label53.BackColor = Color.Red; }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            textsClear();
            if (dataGridView1.RowCount > 0)
            {
                gridselectedindex = dataGridView1.CurrentCell.RowIndex;
            }
            Filler(dataGridView1.Rows[gridselectedindex].Cells["ArticleNo"].Value.ToString());
        }
        private void textsClear()
        {
            Price.Text = "";
            Note.Text = "";
            Number.Text = "";
            ArticleNo.Text = "";
            ArticleDesc.Text = "";
            PackQuan.Text = "";
            UnitContent.Text = "";
            UnitMeasure.Text = "";
            StandartWeight.Text = "";
            HazardousInd.Text = "";
            CalibrationInd.Text = "";
            ObsoluteFlag.Text = "";
            LowDiscontInd.Text = "";
            LicensedInd.Text = "";
            ShelfLife.Text = "";
            CofO.Text = "";
            CCCNNo.Text = "";
            UKIntroDate.Text = "";
            UKDiscDate.Text = "";

            BHCFlag.Text = "";
            DiscCharge.Text = "";
            Expiringpro.Text = "";
            Manufacturer.Text = "";
            MPN.Text = "";
            MHCodeLevel1.Text = "";
            CCCNNo.Text = "";
            Width.Text = "";
            Length.Text = "";
            Height.Text = "";
            ArticleNo.Text = "";
            IntroductionDate.Text = "";
            DiscontinuedDate.Text = "";
            ColBreak1.Text = "";
            ColBreak2.Text = "";
            ColBreak3.Text = "";
            ColBreak4.Text = "";
            ColBreak5.Text = "";
            ColPrice1.Text = "";
            ColPrice2.Text = "";
            ColPrice3.Text = "";
            ColPrice4.Text = "";
            ColPrice5.Text = "";
            DiscountedPrice1.Text = "";
            DiscountedPrice2.Text = "";
            DiscountedPrice3.Text = "";
            DiscountedPrice4.Text = "";
            DiscountedPrice5.Text = "";
            SupersectionName.Text = "";
            ArticleDesc.Text = "";
            ArticleNo.Text = "";
            Environment.Text = "";
            Lithium.Text = "";
            Shipping.Text = "";
            ArticleNo.Text = "";
            OnSaleDiscontinuedDate.Text = "";
            OnSaleIntroductionDate.Text = "";
            OnhandStockBalance.Text = "";
            QuantityonOrder.Text = "";
            ArticleNo.Text = "";
            DiscontinuationDate.Text = "";
            RunOn.Text = "";
            Referral.Text = "";
            LicenceType.Text = "";
        }

        private void rbProductCode_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void rbMPNCode_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void rbFullLicence_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void rbSupplierCode_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void rbImport_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void rbProductName_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void rbEUU_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void rbDiscontinued_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void rbQuickSearch_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void rbItemNotes_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textsClear();
        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void OnSaleDiscontinuedDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void Price_TextChanged(object sender, EventArgs e)
        {

        }

        private void Number_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(Number.Text) < Int32.Parse(ColBreak2.Text) && Int32.Parse(ColBreak1.Text) != 0)
                {
                    Price.Text = ColPrice1.Text;
                }
                else if (Int32.Parse(Number.Text) < Int32.Parse(ColBreak3.Text)&& Int32.Parse(ColBreak2.Text)!=0)
                {
                    Price.Text = ColPrice2.Text;
                }
                else if (Int32.Parse(Number.Text) < Int32.Parse(ColBreak4.Text) && Int32.Parse(ColBreak3.Text) != 0)
                {
                    Price.Text = ColPrice3.Text;
                }
                else if (Int32.Parse(Number.Text) < Int32.Parse(ColBreak5.Text) && Int32.Parse(ColBreak4.Text) != 0)
                {
                    Price.Text = ColPrice4.Text;
                }
                else if(Int32.Parse(ColBreak5.Text) != 0) { Price.Text = ColPrice5.Text; }
            }
            catch { }

        }

        private void Environment_TextChanged(object sender, EventArgs e)
        {
            if (Environment.Text != "") { label53.BackColor = Color.Red; } else { label53.BackColor = Color.White; }
        }

        private void Lithium_TextChanged(object sender, EventArgs e)
        {
            if (Lithium.Text != "") { label64.BackColor = Color.Red; } else { label64.BackColor = Color.White; }

        }

        private void Shipping_TextChanged(object sender, EventArgs e)
        {
            if (Shipping.Text != "") { label63.BackColor = Color.Red; } else { label63.BackColor = Color.White; }
        }

        private void Length_TextChanged(object sender, EventArgs e)
        {
            grossWeight.Text = "";
            if (Height.Text != "" && Length.Text != "" && Width.Text != "") { grossWeight.Text = (Decimal.Parse(Length.Text) * Decimal.Parse(Width.Text) * Decimal.Parse(Height.Text) / 6000).ToString(); }
        }

        private void StandartWeight_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UnitContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void CCCNNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void MPN_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void RunOn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void grossWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void Height_TextChanged(object sender, EventArgs e)
        {
            // Height.Text = ((Decimal.Parse(Height.Text)) * 100).ToString();
        }

        private void Width_TextChanged(object sender, EventArgs e)
        {
            //Width.Text = ((Decimal.Parse(Width.Text)) * 100).ToString();
        }

        private void ArticleNo_TextChanged(object sender, EventArgs e)
        {
            if (ArticleNo.Text != "")
            {
                if (IME.ItemNotes.Where(c => c.ArticleNo == ArticleNo.Text).FirstOrDefault() != null) { Note.Text = IME.Notes.Where(b => b.ID == IME.ItemNotes.Where(a => a.ArticleNo == ArticleNo.Text).FirstOrDefault().NoteID).FirstOrDefault().Note_name; }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Updnote = IME.ItemNotes.Where(a => a.ArticleNo == ArticleNo.Text).FirstOrDefault();
            if (Updnote != null)
            {
                var note = IME.Notes.Where(a => a.ID == Updnote.NoteID).FirstOrDefault();
                note.Note_name = Note.Text;
                IME.SaveChanges();
            }
            else
            {
                var note = new Note();
                note.Note_name = Note.Text;
                IME.Notes.Add(note);
                IME.SaveChanges();
                var newNoteID = new ItemNote();
                newNoteID.NoteID = note.ID;
                newNoteID.ArticleNo = ArticleNo.Text;
                IME.ItemNotes.Add(newNoteID);
                IME.SaveChanges();
            }
        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Number.Text = "";
                gridselectedindex = 0;
                itemSelect();
            }
        }
    }
}
