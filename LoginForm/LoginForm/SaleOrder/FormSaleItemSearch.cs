using LoginForm.DataSet;
using LoginForm.Model;
using LoginForm.QuotationModule;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.nmSaleOrder
{
    public partial class FormSaleItemSearch : Form
    {
        string searchItemCode = null;

        public object selectedItem = new object();
        public string selectedItemCode;
        public string selectedItemTable;

        public FormSaleItemSearch(string ItemCode = "")
        {
            InitializeComponent();
            searchItemCode = ItemCode;
        }

        private void SaleItemSearch_Load(object sender, EventArgs e)
        {
            if (searchItemCode != null && searchItemCode != String.Empty)
            {
                txtItemCode.Text = searchItemCode;
                dgItemSearch.DataSource = SearchItemsForGrid(searchItemCode);
            }
        }

        private dynamic SearchItemsForGrid(string ItemCode, bool isMPN = false)
        {
            IMEEntities IME = new IMEEntities();

            dynamic gridAdapterPC = new object();
            dynamic list2 = new object();
            dynamic list3 = new object();

            switch (isMPN)
            {
                case false:
                    gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.Article_No.Contains(ItemCode))
                                     join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                                     let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         a.MPN,
                                         customerworker.Note.Note_name,
                                         //Supplier = a.Manufacturer,
                                         UniteCode = a.Unit_Content,
                                         StandardWeight = a.Standard_Weight,
                                         dependantTable = "sd"
                                         //HzrInd = a.Hazardous_Ind,
                                         //Calib = a.Calibration_Ind
                                     }
                         ).ToList();
                    list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_No.Contains(ItemCode))
                             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 a.MPN,
                                 customerworker.Note.Note_name,
                                 //Supplier = a.Manufacturer,
                                 UniteCode = a.Unit_Content,
                                 StandardWeight = a.Standard_Weight,
                                 dependantTable = "sdp"
                                 //HzrInd = a.Hazardous_Ind,
                                 //Calib = a.Calibration_Ind
                                 //a.CofO,
                                 //a.Pack_Code
                             }
                ).ToList();
                    list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(ItemCode))
                                 //join sup in IME.Suppliers on a.ManufacturerCode equals sup.ID
                             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()

                             select new
                             {
                                 a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,
                                 a.MPN,
                                 customerworker.Note.Note_name,
                                 //Supplier = sup.s_name,
                                 UniteCode = a.PackSize,
                                 StandardWeight = a.ExtendedRangeWeight,
                                 dependantTable = "ext"
                             }
                                ).ToList();
                    gridAdapterPC.AddRange(list2);
                    gridAdapterPC.AddRange(list3);
                    break;
                case true:
                    gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.MPN == ItemCode)
                                     join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                                     let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         a.MPN,
                                         customerworker.Note.Note_name,
                                         dependantTable = "sd"
                                     }
                         ).ToList();
                    list2 = (from a in IME.SuperDiskPs.Where(a => a.MPN == ItemCode)
                             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 a.MPN,
                                 customerworker.Note.Note_name,
                                 dependantTable = "sdp"
                                 //a.CofO,
                                 //a.Pack_Code
                             }
                ).ToList();
                    list3 = (from a in IME.ExtendedRanges.Where(a => a.MPN == ItemCode)
                             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,
                                 a.MPN,
                                 customerworker.Note.Note_name,
                                 dependantTable = "ext"
                             }
                                ).ToList();
                    gridAdapterPC.AddRange(list2);
                    gridAdapterPC.AddRange(list3);
                    break;
            }

            return gridAdapterPC;
        }

        private void dgItemSearch_DoubleClick(object sender, EventArgs e)
        {
            //selectedItemCode = dgItemSearch.CurrentRow.Cells[0].Value.ToString();
            //selectedItemTable = dgItemSearch.CurrentRow.Cells[6].Value.ToString();

            //this.DialogResult = DialogResult.OK;
            //this.Close();

            if (dgItemSearch.DataSource != null)
            {
                if (dgItemSearch.CurrentRow.Cells[2].Value.ToString() != "")
                {
                    classQuotationAdd.ItemCode = dgItemSearch.Rows[dgItemSearch.CurrentCell.RowIndex].Cells["ArticleNo"].Value.ToString();

                    var MPNItemList = new IMEEntities().ArticleSearchwithMPN(dgItemSearch.CurrentRow.Cells[2].Value.ToString()).ToList();
                    if (MPNItemList.Count > 1)
                    {
                        FormQuotationMPN form = new FormQuotationMPN(MPNItemList);
                        form.ShowDialog();
                    }
                }
            }
            classQuotationAdd.ItemCode = dgItemSearch.Rows[dgItemSearch.CurrentCell.RowIndex].Cells["ArticleNo"].Value.ToString();
            this.Close();

            //SetItemToSend(ItemCode,dependantTable);
        }

        private void SetItemToSend(string ItemCode, string table)
        {
            IMEEntities db = new IMEEntities();
            SaleItem item = new SaleItem();
            item.ItemCode = ItemCode;
            //TODO Landing cost
            //item.LandingCost = classQuotationAdd.GetLandingCost(item.ItemCode, true, true, true);
            //item.LM = (item.Margin < Utils.getCurrentUser().MinMarge) ? true : false;

            switch (table)
            {
                case "sd":
                    SuperDisk itemSD = db.SuperDisks.Where(sd => sd.Article_No == ItemCode).FirstOrDefault();
                    item.UnitWeight = (decimal)itemSD.Standard_Weight / 1000;

                    OnSale itemSDOS = db.OnSales.Where(os => os.ArticleNumber == ItemCode).FirstOrDefault();
                    if (itemSDOS != null)
                    {
                        item.OnHandStockBalance = (int)itemSDOS.OnhandStockBalance;
                        item.QuantityOnOrder = (int)itemSDOS.QuantityonOrder;
                    }

                    SlidingPrice itemSDPrice = db.SlidingPrices.Where(sp => sp.ArticleNo == ItemCode).FirstOrDefault();
                    item.SuperSection = itemSDPrice.SupersectionName;
                    item.Section = itemSDPrice.SectionName;
                    item.MHLevel1 = itemSD.MH_Code_Level_1;
                    //item.UC_UP = itemSDPrice.

                    item.Col1Break = (int)itemSDPrice.Col1Break;
                    item.Col2Break = (int)itemSDPrice.Col2Break;
                    item.Col3Break = (int)itemSDPrice.Col3Break;
                    item.Col4Break = (int)itemSDPrice.Col4Break;
                    item.Col5Break = (int)itemSDPrice.Col5Break;
                    item.UK1Price = (int)itemSDPrice.Col1Price;
                    item.UK2Price = (int)itemSDPrice.Col2Price;
                    item.UK3Price = (int)itemSDPrice.Col3Price;
                    item.UK4Price = (int)itemSDPrice.Col4Price;
                    item.UK5Price = (int)itemSDPrice.Col5Price;
                    item.Cost1 = (decimal)itemSDPrice.DiscountedPrice1;
                    item.Cost2 = (decimal)itemSDPrice.DiscountedPrice2;
                    item.Cost3 = (decimal)itemSDPrice.DiscountedPrice3;
                    item.Cost4 = (decimal)itemSDPrice.DiscountedPrice4;
                    item.Cost5 = (decimal)itemSDPrice.DiscountedPrice5;

                    item.CL = (itemSD.Calibration_Ind == "Y") ? true : false;
                    item.Description = itemSD.Article_Desc;
                    item.LC = (itemSD.Licensed_Ind == "Y") ? true : false;
                    item.Manufacturer = itemSD.Manufacturer;
                    item.MPN = itemSD.MPN;
                    item.COO = itemSD.CofO;
                    item.CCCNO = itemSD.CCCN_No;
                    // TODO Aşağıdaki 2 tarih verisi güncel olan tablodan alınacak.
                    item.UKIntroDate = itemSD.Uk_Intro_Date;
                    item.UKDiscDate = itemSD.Uk_Disc_Date;
                    item.Height = (decimal)itemSD.Heigh;
                    item.Width = (decimal)itemSD.Width;
                    item.Length = (decimal)itemSD.Length;
                    // TODO  TotalWeight hesaplaması - Grossweight farkı
                    item.TotalWeight = (decimal)(item.UnitWeight * itemSD.Unit_Content);
                    item.UC = (int)itemSD.Unit_Content;
                    item.HZ = (itemSD.Hazardous_Ind == "Y") ? true : false;
                    item.CL = (itemSD.Calibration_Ind == "Y") ? true : false;
                    item.LC = (itemSD.Licensed_Ind == "" && itemSD.Licensed_Ind != null) ? true : false;

                    if (itemSD.Hazardous_Ind == "Y")
                    {
                        Hazardou h = db.Hazardous.Where(x => itemSD.Article_No.Contains(x.ArticleNo)).FirstOrDefault();
                        if (h == null) { h = db.Hazardous.Where(x => x.ArticleNo == (Int32.Parse(itemSD.Article_No)).ToString()).FirstOrDefault(); }
                        item.HE = (h.Environment != null) ? true : false;
                        item.HS = (h.Shipping != null && h.Shipping != String.Empty) ? true : false;
                        item.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                    }

                    break;
                case "sdp":
                    SuperDiskP itemSDP = db.SuperDiskPs.Where(sdp => sdp.Article_No == ItemCode).FirstOrDefault();
                    item.UnitWeight = (decimal)itemSDP.Standard_Weight / 1000;

                    OnSale itemSDPOS = db.OnSales.Where(os => os.ArticleNumber == ItemCode).FirstOrDefault();
                    if (itemSDPOS != null)
                    {
                        item.OnHandStockBalance = (int)itemSDPOS.OnhandStockBalance;
                        item.QuantityOnOrder = (int)itemSDPOS.QuantityonOrder;
                    }

                    SlidingPrice itemSDPPrice = db.SlidingPrices.Where(sp => sp.ArticleNo == ItemCode).FirstOrDefault();
                    item.SuperSection = itemSDPPrice.SupersectionName;
                    item.Section = itemSDPPrice.SectionName;
                    item.MHLevel1 = itemSDP.MH_Code_Level_1;

                    item.Col1Break = (int)itemSDPPrice.Col1Break;
                    item.Col2Break = (int)itemSDPPrice.Col2Break;
                    item.Col3Break = (int)itemSDPPrice.Col3Break;
                    item.Col4Break = (int)itemSDPPrice.Col4Break;
                    item.Col5Break = (int)itemSDPPrice.Col5Break;
                    item.UK1Price = (int)itemSDPPrice.Col1Price;
                    item.UK2Price = (int)itemSDPPrice.Col2Price;
                    item.UK3Price = (int)itemSDPPrice.Col3Price;
                    item.UK4Price = (int)itemSDPPrice.Col4Price;
                    item.UK5Price = (int)itemSDPPrice.Col5Price;
                    item.Cost1 = (decimal)itemSDPPrice.DiscountedPrice1;
                    item.Cost2 = (decimal)itemSDPPrice.DiscountedPrice2;
                    item.Cost3 = (decimal)itemSDPPrice.DiscountedPrice3;
                    item.Cost4 = (decimal)itemSDPPrice.DiscountedPrice4;
                    item.Cost5 = (decimal)itemSDPPrice.DiscountedPrice5;

                    item.CL = (itemSDP.Calibration_Ind == "Y") ? true : false;
                    item.LC = (itemSDP.Licensed_Ind == "Y") ? true : false;
                    item.Manufacturer = itemSDP.Manufacturer;
                    item.COO = itemSDP.CofO;
                    item.CCCNO = itemSDP.CCCN_No;
                    // TODO Aşağıdaki 2 tarih verisi güncel olan tablodan alınacak.
                    item.UKIntroDate = itemSDP.Uk_Intro_Date;
                    item.UKDiscDate = itemSDP.Uk_Disc_Date;
                    item.Height = (decimal)itemSDP.Heigh;
                    item.Width = (decimal)itemSDP.Width;
                    item.Length = (decimal)itemSDP.Length;
                    item.TotalWeight = (decimal)(item.UnitWeight * itemSDP.Unit_Content);
                    item.UC = (int)itemSDP.Unit_Content;
                    item.HZ = (itemSDP.Hazardous_Ind == "Y") ? true : false;
                    item.CL = (itemSDP.Calibration_Ind == "Y") ? true : false;
                    item.LC = (itemSDP.Licensed_Ind == "" && itemSDP.Licensed_Ind != null) ? true : false;

                    if (itemSDP.Hazardous_Ind == "Y")
                    {
                        Hazardou h = db.Hazardous.Where(x => x.ArticleNo == itemSDP.Article_No).FirstOrDefault();
                        if (h == null) { h = db.Hazardous.Where(x => x.ArticleNo == (Int32.Parse(itemSDP.Article_No)).ToString()).FirstOrDefault(); }
                        item.HE = (h.Environment != null) ? true : false;
                        item.HS = (h.Shipping != null && h.Shipping != String.Empty) ? true : false;
                        item.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                    }

                    break;
                case "ext":
                    ExtendedRange itemEXT = db.ExtendedRanges.Where(ext => ext.ArticleNo == ItemCode).FirstOrDefault();
                    item.UnitWeight = (decimal)itemEXT.ExtendedRangeWeight / 1000;

                    //s.CL = (itemEXT.Calibration_Ind == "Y") ? true : false;
                    //s.LC = (itemEXT.Licensed_Ind == "Y") ? true : false;
                    item.Manufacturer = (itemEXT.ManufacturerCode != null) ? itemEXT.ManufacturerCode : String.Empty;
                    item.COO = itemEXT.CountryofOrigin;
                    if (itemEXT.CCCN != null) item.CCCNO = itemEXT.CCCN.ToString();
                    // TODO Aşağıdaki 2 tarih verisi güncel olan tablodan alınacak.
                    //s.UKIntroDate = itemEXT.Uk_Intro_Date;
                    //s.UKDiscDate = itemEXT.Uk_Disc_Date;
                    item.Height = (decimal)itemEXT.Height;
                    item.Width = (itemEXT.Width != null) ? (decimal)itemEXT.Width : 0;
                    item.Length = (decimal)itemEXT.ExtendedRangeLength;
                    item.UC = (int)itemEXT.PackSize;
                    item.TotalWeight = (decimal)(item.UnitWeight * itemEXT.PackSize);

                    item.UOM = itemEXT.UnitofMeasure;
                    //s.HZ = (itemEXT.Hazardous_Ind == "Y") ? true : false;
                    //s.CL = (itemEXT.Calibration_Ind == "Y") ? true : false;
                    //s.LC = (itemEXT.Licensed_Ind == "" && itemEXT.Licensed_Ind != null) ? true : false;

                    //if (itemEXT.Hazardous_Ind == "Y")
                    //{
                    //    Hazardou h = IME.Hazardous.Where(x => x.ArticleNo == itemSDP.Article_No).FirstOrDefault();
                    //    s.HE = (h.Environment != null) ? true : false;
                    //    s.HS = (h.Shipping != null && h.Shipping != String.Empty) ? true : false;
                    //    s.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                    //}
                    break;
            }

            selectedItem = item;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private decimal CalculateMargin(decimal landingCost, decimal UCUPCurr)
        {
            return (((1 - landingCost / UCUPCurr)) * 100)/*.ToString("G29")*/;
        }
    }
}
