using LoginForm.DataSet;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace LoginForm
{
    class txtReader
    {
        public static string LoaderType;

        public static List<DataSet.BackOrder> BackOrderRead()
        {
            IMEEntities IME = new IMEEntities();
            List<DataSet.BackOrder> BoList = new List<DataSet.BackOrder>();
            Excel.Application excel = new Excel.Application();
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            openFileDialog1.Filter = "excel files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                try
                {
                    Excel.Workbook theWorkbook = excel.Workbooks.Open(
                  openFileDialog1.FileName, 0, true, 5,
                   "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
                   0, true);
                    Excel.Sheets sheets = theWorkbook.Worksheets;
                    Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
                    //for (int i = 1; i <= 10; i++)
                    //{
                    Excel.Range last = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                    Excel.Range range = worksheet.get_Range("A1", last);
                    Array myvalues = range.Cells.Value;
                    for (int i = 2; i <= myvalues.Length / 10; i++)
                    {
                        DataSet.BackOrder bo = new DataSet.BackOrder();
                        bo.RSUKReference = ((object[,])myvalues)[i, 1].ToString();
                        bo.SoldToNumber = ((object[,])myvalues)[i, 2].ToString();
                        bo.TradingTitle = ((object[,])myvalues)[i, 3].ToString();
                        bo.PurchaseOrderNumber = ((object[,])myvalues)[i, 4].ToString();
                        bo.OrderDate = DateTime.ParseExact(((object[,])myvalues)[i, 5].ToString(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        bo.Article = ((object[,])myvalues)[i, 6].ToString();
                        bo.OutstandingQuantity = ((object[,])myvalues)[i, 7].ToString();
                        bo.LineValue = ((object[,])myvalues)[i, 8].ToString();
                        bo.FirstPromisedDate = DateTime.ParseExact(((object[,])myvalues)[i, 9].ToString(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        bo.LatestPromisedDate = DateTime.ParseExact(((object[,])myvalues)[i, 10].ToString(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        if (bo.PurchaseOrderNumber != null && bo.PurchaseOrderNumber != "") bo.PurchaseOrderID = Int32.Parse(bo.PurchaseOrderNumber.ToString().Substring(0, bo.PurchaseOrderNumber.ToString().IndexOf('R')));
                        BoList.Add(bo);
                    }
                    #region
                    //Excel.Application excel = new Excel.Application();
                    //Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                    //Worksheet ws = wb.Worksheets[1];
                    //int ColumnNumber = 2;
                    ////string ArticleNumb = ws.Cells[2, 1].Text;
                    //#region DiscontinuedList

                    //while(ws.Cells[ColumnNumber, 1].Text!="")
                    //{
                    //    DataSet.BackOrder bo = new DataSet.BackOrder();
                    //    bo.RSUKReference = ws.Cells[ColumnNumber, 1].Text;
                    //    bo.SoldToNumber = ws.Cells[ColumnNumber, 2].Text;
                    //    bo.TradingTitle = ws.Cells[ColumnNumber, 3].Text;
                    //    bo.PurchaseOrderNumber = ws.Cells[ColumnNumber, 4].Text;
                    //    bo.OrderDate = DateTime.ParseExact(ws.Cells[ColumnNumber, 5].Text, "dd.MM.yyyy",System.Globalization.CultureInfo.InvariantCulture);

                    //    bo.Article = ws.Cells[ColumnNumber, 6].Text;
                    //    bo.OutstandingQuantity = ws.Cells[ColumnNumber, 7].Text;
                    //    bo.LineValue = ws.Cells[ColumnNumber, 8].Text;
                    //    bo.FirstPromisedDate = DateTime.ParseExact(ws.Cells[ColumnNumber, 9].Text, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture); 
                    //    bo.LatestPromisedDate = DateTime.ParseExact(ws.Cells[ColumnNumber, 10].Text, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    //    BoList.Add(bo);
                    //    //IME.BackOrders.Add(bo);
                    //    //IME.SaveChanges();
                    //    ColumnNumber++;
                    //}
                    //MessageBox.Show(ColumnNumber + "items's back order date is changed");
                    //return BoList;
                    #endregion
                }
                catch (Exception ex) { MessageBox.Show("This document does not proper to load here"); return null; }
            }
            return BoList;

        }

        public static void OrderAcknowledgementtxtReader()
        {
            IMEEntities IME = new IMEEntities();

            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK) // Test result.
            {

                string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                int a = 0;
                bool isItem = false;
                OrderAcknowledgement oa = new OrderAcknowledgement();
                OrderAcknowledgementDetail oad = new OrderAcknowledgementDetail();
                while (lines.Count() > a)
                {
                    if (lines[a] != "")
                    {
                        if (lines[a].Substring(0, 2) == "FH")
                        {
                            oa.CountryCode = lines[a].Substring(2, 3);
                            oa.OrderDate = lines[a].Substring(5, 10);
                            oa.OrderTime = lines[a].Substring(15, 5);
                            oa.SupplierTelephoneNumber = lines[a].Substring(20, 14);
                        }
                        else if (lines[a].Substring(0, 2) == "OA")
                        {
                            oa.CustomerDistOrderReference = lines[a].Substring(2, 30);
                            oa.ShippingCondition = lines[a].Substring(32, 2);
                            oa.CustomerPONumber = lines[a].Substring(34, 22);
                            oa.SupplyingECCompany = lines[a].Substring(56, 4);
                            oa.CustomerReference = lines[a].Substring(60, 10);
                            oa.HeaderDeliveryBlock = lines[a].Substring(70, 2);
                            oa.RSLSalesOrderNumber = lines[a].Substring(72, 10);
                        }
                        else if (lines[a].Substring(0, 2) == "FT")
                        {
                            oa.ScheduleLineConfirmedQuantity = lines[a].Substring(2, 13);
                            oa.ScheduleLineControl = lines[a].Substring(15, 4);
                        }
                    }
                    a++;
                }

                IME.OrderAcknowledgements.Add(oa);
                IME.SaveChanges();
                int OrderAcknowledgementID = oa.ID;
                a = 0;
                while (lines.Count() > a)
                {
                    if (lines[a] != "")
                    {
                        if (lines[a].Substring(0, 2) == "OI")
                        {
                            oad.PurchaseOrderItemNumber = lines[a].Substring(2, 6);
                            oad.ProductNumber = lines[a].Substring(8, 18);
                            oad.ReasonCode = lines[a].Substring(26, 2);
                            oad.ReasonCodeText = lines[a].Substring(28, 40);
                            oad.OrderQuantity = lines[a].Substring(68, 15);
                            oad.SalesUnit = lines[a].Substring(83, 3);
                        }
                        else if (lines[a].Substring(0, 2) == "SL")
                        {
                            oad.PurchaseOrderItem = lines[a].Substring(2, 6);
                            oad.ScheduleLineNumber = lines[a].Substring(8, 4);
                            oad.ScheduleLineDate = lines[a].Substring(12, 8);
                            oad.ScheduleLineConfirmedQty = lines[a].Substring(20, 13);
                            oad.ScheduleLineDeliveredQty = lines[a].Substring(33, 13);
                            oad.SecheduleLineDeliveryBlock = lines[a].Substring(46, 2);
                        }
                        else if (lines[a].Substring(0, 2) == "SC")
                        {
                            oad.PurchaseOrderItemNumber_SC = lines[a].Substring(2, 6);
                            oad.TotalNumberofScheduleLines = lines[a].Substring(8, 4);
                            oad.OrderAcknowledgementID = OrderAcknowledgementID;
                            IME.OrderAcknowledgementDetails.Add(oad);
                            IME.SaveChanges();
                            oad = new OrderAcknowledgementDetail();
                        }
                    }
                    a++;
                }
            }
        }

        public static int SuperDiskTxtSave()
        {
            //#region Superdisk
            //int a = 1;
            //IMEEntities IME = new IMEEntities();
            //string supplierID = null;
            ////supplierID = IME.Suppliers.Where(x => x.s_name == "RSPro").FirstOrDefault().ID;
            ////Show the dialog and get result.
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            //DialogResult result1 = openFileDialog1.ShowDialog();

            //int UptCounter = 0;
            //int AddedCounter = 0;
            //if (result1 == DialogResult.OK) // Test result.
            //{
            //    //try
            //    //{
            //    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
            //    string[] columnnames = lines[0].Split('|');
            //    string[] wordcontrol;

            //    wordcontrol = lines[1].Split('|');
            //    if (!wordcontrol[0].Contains("P"))
            //    {

            //        while (lines.Count() > a)
            //        {
            //            string[] word;
            //            word = lines[a].Split('|');
            //            //superdisk ADD
            //            Item s = new Item();
            //            s.ArticleNo = word[0];
            //            s.ArticleDesc = word[1];
            //            if (word[3] != "") s.PackQuantity = Int32.Parse(word[3]);
            //            if (word[4] != "") s.UnitContent = Int32.Parse(word[4]);
            //            s.UnitMeasure = (String.IsNullOrEmpty(word[5])) ? "EACH" : word[5];
            //            s.HazardousInd = word[8];
            //            s.CalibrationInd = word[9];
            //            s.MH1 = word[11];
            //            s.LicensedInd = word[13];
            //            s.CofO = word[15];
            //            s.DiscChangeInd = word[30];
            //            s.Manufacturer = word[35];
            //            s.MPN = word[36];
            //            s.MHCodeLevel1 = word[37];
            //            if (word[38] != "") s.Height = decimal.Parse(word[38]);
            //            if (word[39] != "") s.Width = decimal.Parse(word[39]);
            //            if (word[40] != "") s.Length = decimal.Parse(word[40]);
            //            s.DimensionUnit = "M";
            //            s.Currency = "GBP";
            //            s.SupplierID = supplierID;

            //            IME.ItemAdd(
            //                 s.ArticleNo,
            //        s.ArticleDesc,
            //        s.PackQuantity,
            //        s.UnitContent,
            //        s.UnitMeasure,
            //        s.HazardousInd,
            //        s.CalibrationInd,
            //        s.MH1,
            //        s.LicensedInd,
            //        s.CofO,
            //        s.DiscChangeInd,
            //        s.Manufacturer,
            //        s.MPN,
            //        s.MHCodeLevel1,
            //        s.Height,
            //        s.Width,
            //        s.Length,
            //        s.DimensionUnit,
            //        s.Currency,
            //        s.SupplierID);
            //            a++;
            //        }
            //        MessageBox.Show("Upload Completed");
            //        return 1;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please Choose Correct File");
            //        return 0;
            //    }
            //    //}
            //    //catch (Exception ex) { MessageBox.Show(ex.Message); MessageBox.Show(a.ToString()); return 0; }
            //    #endregion
            //}
            //return 0;



            #region Superdisk
            int a = 1;
            IMEEntities IME = new IMEEntities();
            Item item = new Item();
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            DialogResult result1 = openFileDialog1.ShowDialog();

            int UptCounter = 0;
            int AddedCounter = 0;
            if (result1 == DialogResult.OK) // Test result.
            {
                //try
                //{
                string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                string[] columnnames = lines[0].Split('|');
                string[] wordcontrol;
                bool isArrayTrue = true;
                if (columnnames[0] != "Article No") isArrayTrue = false;
                if (columnnames[1] != "Article Desc") isArrayTrue = false;
                if (columnnames[2] != "Pack Code") isArrayTrue = false;
                if (columnnames[3] != "Pack Quantity") isArrayTrue = false;
                if (columnnames[4] != "Unit Content") isArrayTrue = false;
                if (columnnames[5] != "Unit Measure") isArrayTrue = false;
                if (columnnames[6] != "Uk Col 1") isArrayTrue = false;
                if (columnnames[7] != "Standard Weight") isArrayTrue = false;
                if (columnnames[8] != "Hazardous Ind") isArrayTrue = false;
                if (columnnames[9] != "Calibration Ind") isArrayTrue = false;
                if (columnnames[10] != "Obsolete Flag") isArrayTrue = false;
                if (columnnames[11] != "MH1") isArrayTrue = false;
                if (columnnames[12] != "Low Discount Ind") isArrayTrue = false;
                if (columnnames[13] != "Licensed Ind") isArrayTrue = false;
                if (columnnames[14] != "Shelf Life") isArrayTrue = false;
                if (columnnames[15] != "CofO") isArrayTrue = false;
                if (columnnames[16] != "EUR1 Indicator") isArrayTrue = false;
                if (columnnames[17] != "CCCN No") isArrayTrue = false;
                if (columnnames[18] != "Supercede Date") isArrayTrue = false;
                if (columnnames[19] != "Current Cat page") isArrayTrue = false;
                if (columnnames[20] != "Uk Intro Date") isArrayTrue = false;
                if (columnnames[21] != "Filler") isArrayTrue = false;
                if (columnnames[22] != "Uk Disc Date") isArrayTrue = false;
                if (columnnames[23] != "Substitute By") isArrayTrue = false;
                if (columnnames[24] != "BHC Flag") isArrayTrue = false;
                if (columnnames[25] != "Filler1") isArrayTrue = false;
                if (columnnames[26] != "Future Sell Price") isArrayTrue = false;
                if (columnnames[27] != "Int Cat") isArrayTrue = false;
                if (columnnames[28] != "New Prod Change Ind") isArrayTrue = false;
                if (columnnames[29] != "Out of Stock Prohibit change ind") isArrayTrue = false;
                if (columnnames[30] != "Disc Change Ind") isArrayTrue = false;
                if (columnnames[31] != "Superceded Change Ind") isArrayTrue = false;
                if (columnnames[32] != "Pack Size Change Ind") isArrayTrue = false;
                if (columnnames[33] != "Rolled Product Change Ind") isArrayTrue = false;
                if (columnnames[34] != "Expiring Product Change Ind") isArrayTrue = false;
                if (columnnames[35] != "Manufacturer") isArrayTrue = false;
                if (columnnames[36] != "MPN") isArrayTrue = false;
                if (columnnames[37] != "MH Code Level 1") isArrayTrue = false;
                if (columnnames[38] != "Height") isArrayTrue = false;
                if (columnnames[39] != "Width") isArrayTrue = false;
                if (columnnames[40] != "Length") isArrayTrue = false;

                wordcontrol = lines[1].Split('|');
                if (!wordcontrol[0].Contains("P"))
                {

                    //if (!isArrayTrue)
                    //{
                        while (lines.Count() > a)
                        {
                            #region isArrayFalse
                            string[] word;
                            word = lines[a].Split('|');
                            for (int i = 0; i < columnnames.Count(); i++)
                            {
                                columnnames[i] = columnnames[i].Replace(" ", "_");
                                //burada Superdiskitems diye bir ITEM nesnesini dolduruyoruz
                                switch (columnnames[i])
                                {
                                    case "Article_Desc":
                                        item.ArticleDesc = word[i];
                                        break;
                                    case "Article_No":
                                        item.ArticleNo = word[i];
                                        break;
                                    case "BHC_Flag":
                                        item.BHCFlag = word[i];
                                        break;
                                    case "Calibration_Ind":
                                        item.CalibrationInd = word[i];
                                        break;
                                    case "CCCN_No":
                                        item.CCCNNo = word[i];
                                        break;
                                    case "CofO":
                                        item.CofO = word[i];
                                        break;
                                    case "Current_Cat_page":
                                        item.CurrentCatpage = word[i];
                                        break;
                                    case "Disc_Change_Ind":
                                        item.DiscChangeInd = word[i];
                                        break;
                                    case "EUR1_Indicator":
                                        item.EUR1Indicator = word[i];
                                        break;
                                    case "Expiring_Product_Change_Ind":
                                        item.ExpiringProductChangeInd = word[i];
                                        break;
                                    case "Filler":
                                        item.Filler = word[i];
                                        break;
                                    case "Filler1":
                                        item.Filler1 = word[i];
                                        break;
                                    case "Future_Sell_Price":
                                        if (word[i] != "")
                                        {
                                            item.FutureSellPrice = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Hazardous_Ind":
                                        item.HazardousInd = word[i];
                                        break;
                                    case "Height":
                                        if (word[i] != "")
                                        {
                                            item.Height = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Int_Cat":
                                        item.IntCat = word[i];
                                        break;
                                    case "Length":
                                        if (word[i] != "")
                                        {
                                            item.Length = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Licensed_Ind":
                                        item.LicensedInd = word[i];
                                        break;
                                    case "Low_Discount_Ind":
                                        item.LowDiscountInd = word[i];
                                        break;
                                    case "Manufacturer":
                                        item.Manufacturer = word[i];
                                        break;
                                    case "MH1":
                                        item.MH1 = word[i];
                                        break;
                                    case "MH_Code_Level_1":
                                        item.MHCodeLevel1 = word[i];
                                        break;
                                    case "MPN":
                                        item.MPN = word[i];
                                        break;
                                    case "New_Prod_Change_Ind":
                                        item.NewProdChangeInd = word[i];
                                        break;
                                    case "Obsolete_Flag":
                                        item.ObsoleteFlag = word[i];
                                        break;
                                    case "Out_of_Stock_Prohibit_change_ind":
                                        item.OutofStockProhibitchangeind = word[i];
                                        break;
                                    case "Pack_Code":
                                        if (word[i] != "")
                                        {
                                            item.PackCode = word[i];
                                        }
                                        break;
                                    case "Pack_Quantity":
                                        if (word[i] != "")
                                        {
                                            item.PackQuantity = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Pack_Size_Change_Ind":
                                        item.PackSizeChangeInd = word[i];
                                        break;
                                    case "Rolled_Product_Change_Ind":
                                        item.RolledProductChangeInd = word[i];
                                        break;
                                    case "Shelf_Life":
                                        item.ShelfLife = word[i];
                                        break;
                                    case "Standard_Weight":
                                        if (word[i] != "")
                                        {
                                            item.StandardWeight = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Substitute_By":
                                        item.SubstituteBy = word[i];
                                        break;
                                    case "Superceded_Change_Ind":
                                        item.SupercededChangeInd = word[i];
                                        break;
                                    case "Supercede_Date":
                                        item.SupercedeDate = word[i];
                                        break;
                                    case "Uk_Col_1":
                                        if (word[i] != "")
                                        {
                                            item.UkCol1 = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Uk_Disc_Date":
                                        item.UkDiscDate = word[i];
                                        break;
                                    case "Uk_Intro_Date":
                                        item.UkIntroDate = word[i];
                                        break;
                                    case "Unit_Content":
                                        if (word[i] != "")
                                        {
                                            item.UnitContent = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Unit_Measure":
                                        if(word[i] != "")
                                        {
                                            item.UnitMeasure = word[i];
                                            break;
                                        }
                                        else
                                        {
                                            item.UnitMeasure = "EACH";
                                            break;
                                        }
                                    case "Width":
                                        if (word[i] != "")
                                        {
                                            item.Width = decimal.Parse(word[i]);
                                        }
                                        break;
                                }
                            }

                        item.Currency = "GBP";
                        item.DimensionUnit = "M";
                        item.DependantItemFile = "SuperDisk";
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = ImeSqlConnect("159.69.213.172", "IME", "sa", "IME1453");
                        
                        cmd.CommandText = @"[ItemAdd]";

                            cmd.Parameters.AddWithValue("@ArticleNo",item.ArticleNo);
                            cmd.Parameters.AddWithValue("@ArticleDesc",item.ArticleDesc);
                            cmd.Parameters.AddWithValue("@PackCode",item.PackCode);
                            cmd.Parameters.AddWithValue("@PackQuantity",item.PackQuantity);
                            cmd.Parameters.AddWithValue("@UnitContent", item.UnitContent);
                            cmd.Parameters.AddWithValue("@UnitMeasure", item.UnitMeasure);
                            cmd.Parameters.AddWithValue("@UkCol1", item.UkCol1);
                            cmd.Parameters.AddWithValue("@StandardWeight", item.StandardWeight);
                            cmd.Parameters.AddWithValue("@HazardousInd", item.HazardousInd);
                            cmd.Parameters.AddWithValue("@CalibrationInd", item.CalibrationInd);
                            cmd.Parameters.AddWithValue("@ObsoleteFlag", item.ObsoleteFlag);
                            cmd.Parameters.AddWithValue("@MH1", item.MH1);
                            cmd.Parameters.AddWithValue("@LowDiscountInd",item.LowDiscountInd);
                            cmd.Parameters.AddWithValue("@LicensedInd", item.LicensedInd);
                            cmd.Parameters.AddWithValue("@ShelfLife", item.ShelfLife);
                            cmd.Parameters.AddWithValue("@CofO", item.CofO);
                            cmd.Parameters.AddWithValue("@EUR1Indicator", item.EUR1Indicator);
                            cmd.Parameters.AddWithValue("@CCCNNo", item.CCCNNo);
                            cmd.Parameters.AddWithValue("@SupercedeDate", item.SupercedeDate);
                            cmd.Parameters.AddWithValue("@CurrentCatpage", item.CurrentCatpage);
                            cmd.Parameters.AddWithValue("@UkIntroDate", item.UkIntroDate);
                            cmd.Parameters.AddWithValue("@Filler", item.Filler);
                            cmd.Parameters.AddWithValue("@UkDiscDate", item.UkDiscDate);
                            cmd.Parameters.AddWithValue("@SubstituteBy", item.SubstituteBy);
                            cmd.Parameters.AddWithValue("@BHCFlag", item.BHCFlag);
                            cmd.Parameters.AddWithValue("@Filler1", item.Filler1);
                            cmd.Parameters.AddWithValue("@FutureSellPrice", item.FutureSellPrice);
                            cmd.Parameters.AddWithValue("@IntCat", item.IntCat);
                            cmd.Parameters.AddWithValue("@NewProdChangeInd", item.NewProdChangeInd);
                            cmd.Parameters.AddWithValue("@OutofStockProhibitchangeind", item.OutofStockProhibitchangeind);
                            cmd.Parameters.AddWithValue("@DiscChangeInd", item.DiscChangeInd);
                            cmd.Parameters.AddWithValue("@SupercededChangeInd", item.SupercededChangeInd);
                            cmd.Parameters.AddWithValue("@PackSizeChangeInd", item.PackSizeChangeInd);
                            cmd.Parameters.AddWithValue("@RolledProductChangeInd", item.RolledProductChangeInd);
                            cmd.Parameters.AddWithValue("@ExpiringProductChangeInd", item.ExpiringProductChangeInd);
                            cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
                            cmd.Parameters.AddWithValue("@MPN", item.MPN);
                            cmd.Parameters.AddWithValue("@MHCodeLevel1", item.MHCodeLevel1);
                            cmd.Parameters.AddWithValue("@Heigh", item.Height);
                            cmd.Parameters.AddWithValue("@Width", item.Width);
                            cmd.Parameters.AddWithValue("@Length", item.Length);
                            cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                         //   IME.ItemAdd(
                         //         item.ArticleNo,
                         //item.ArticleDesc,
                         //item.PackCode,
                         //item.PackQuantity,
                         //item.UnitContent,
                         //item.UnitMeasure,
                         //item.UkCol1,
                         //item.StandardWeight,
                         //item.HazardousInd,
                         //item.CalibrationInd,
                         //item.ObsoleteFlag,
                         //item.MH1,
                         //item.LowDiscountInd,
                         //item.LicensedInd,
                         //item.ShelfLife,
                         //item.CofO,
                         //item.EUR1Indicator,
                         //item.CCCNNo,
                         //item.SupercedeDate,
                         //item.CurrentCatpage,
                         //item.UkIntroDate,
                         //item.Filler,
                         //item.UkDiscDate,
                         //item.SubstituteBy,
                         //item.BHCFlag,
                         //item.Filler1,
                         //item.FutureSellPrice,
                         //item.IntCat,
                         //item.NewProdChangeInd,
                         //item.OutofStockProhibitchangeind,
                         //item.DiscChangeInd,
                         //item.SupercededChangeInd,
                         //item.PackSizeChangeInd,
                         //item.RolledProductChangeInd,
                         //item.ExpiringProductChangeInd,
                         //item.Manufacturer,
                         //item.MPN,
                         //item.MHCodeLevel1,
                         //item.Height,
                         //item.Width,
                         //item.Length);
                            a++;
                        }

                        #endregion
                    //}
                    //else
                    //{
                    //    while (lines.Count() > a)
                    //    {
                    //        string[] word;
                    //        word = lines[a].Split('|');
                    //        //superdisk ADD
                    //        SuperDisk s = new SuperDisk();
                    //        s.Article_No = word[0];
                    //        s.Article_Desc = word[1];
                    //        if (word[2] != "") s.Pack_Code = Int32.Parse(word[2]);
                    //        if (word[3] != "") s.Pack_Quantity = Int32.Parse(word[3]);
                    //        if (word[4] != "") s.Unit_Content = Int32.Parse(word[4]);
                    //        s.Unit_Measure = word[5];
                    //        if (word[6] != "") s.Uk_Col_1 = decimal.Parse(word[6]);
                    //        if (word[7] != "") s.Standard_Weight = Int32.Parse(word[7]);
                    //        s.Hazardous_Ind = word[8];
                    //        s.Calibration_Ind = word[9];
                    //        s.Obsolete_Flag = word[10];
                    //        s.MH1 = word[11];
                    //        s.Low_Discount_Ind = word[12];
                    //        s.Licensed_Ind = word[13];
                    //        s.Shelf_Life = word[14];
                    //        s.CofO = word[15];
                    //        s.EUR1_Indicator = word[16];
                    //        s.CCCN_No = word[17];
                    //        s.Supercede_Date = word[18];
                    //        s.Current_Cat_page = word[19];
                    //        s.Uk_Intro_Date = word[20];
                    //        s.Filler = word[21];
                    //        s.Uk_Disc_Date = word[22];
                    //        s.Substitute_By = word[23];
                    //        s.BHC_Flag = word[24];
                    //        s.Filler1 = word[25];
                    //        if (word[26] != "") s.Future_Sell_Price = decimal.Parse(word[26]);
                    //        s.Int_Cat = word[27];
                    //        s.New_Prod_Change_Ind = word[28];
                    //        s.Out_of_Stock_Prohibit_change_ind = word[29];
                    //        s.Disc_Change_Ind = word[30];
                    //        s.Superceded_Change_Ind = word[31];
                    //        s.Pack_Size_Change_Ind = word[32];
                    //        s.Rolled_Product_Change_Ind = word[33];
                    //        s.Expiring_Product_Change_Ind = word[34];
                    //        s.Manufacturer = word[35];
                    //        s.MPN = word[36];
                    //        s.MH_Code_Level_1 = word[37];
                    //        if (word[38] != "") s.Heigh = decimal.Parse(word[38]);
                    //        if (word[39] != "") s.Width = decimal.Parse(word[39]);
                    //        if (word[40] != "") s.Length = decimal.Parse(word[40]);

                    //        IME.SuperDiskAdd(
                    //             s.Article_No,
                    //    s.Article_Desc,
                    //    s.Pack_Code,
                    //    s.Pack_Quantity,
                    //    s.Unit_Content,
                    //    s.Unit_Measure,
                    //    s.Uk_Col_1,
                    //    s.Standard_Weight,
                    //    s.Hazardous_Ind,
                    //    s.Calibration_Ind,
                    //    s.Obsolete_Flag,
                    //    s.MH1,
                    //    s.Low_Discount_Ind,
                    //    s.Licensed_Ind,
                    //    s.Shelf_Life,
                    //    s.CofO,
                    //    s.EUR1_Indicator,
                    //    s.CCCN_No,
                    //    s.Supercede_Date,
                    //    s.Current_Cat_page,
                    //    s.Uk_Intro_Date,
                    //    s.Filler,
                    //    s.Uk_Disc_Date,
                    //    s.Substitute_By,
                    //    s.BHC_Flag,
                    //    s.Filler1,
                    //    s.Future_Sell_Price,
                    //    s.Int_Cat,
                    //    s.New_Prod_Change_Ind,
                    //    s.Out_of_Stock_Prohibit_change_ind,
                    //    s.Disc_Change_Ind,
                    //    s.Superceded_Change_Ind,
                    //    s.Pack_Size_Change_Ind,
                    //    s.Rolled_Product_Change_Ind,
                    //    s.Expiring_Product_Change_Ind,
                    //    s.Manufacturer,
                    //    s.MPN,
                    //    s.MH_Code_Level_1,
                    //    s.Heigh,
                    //    s.Width,
                    //    s.Length);
                    //        a++;
                    //    }
                    //}
                    MessageBox.Show("Upload Completed");
                    return 1;
                }
                else
                {
                    MessageBox.Show("Please Choose Correct File");
                    return 0;
                }
                //}
                //catch (Exception ex) { MessageBox.Show(ex.Message); MessageBox.Show(a.ToString()); return 0; }
            }
            #endregion
            return 0;
        }

        public static SqlConnection ImeSqlConnect(string SqlServerName, string SqlDatabaseName, string SqlUser, string SqlPassword)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=" + SqlServerName + "; Database=" + SqlDatabaseName + "; User Id=" + SqlUser + "; Password =" + SqlPassword + "; ";
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            return conn;
        }

        //public static void PurchaseInvoicetxtReader()
        //{
        //    IMEEntities IME = new IMEEntities();

        //    //Show the dialog and get result.
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    openFileDialog1.Filter = "txt files (*.txt)|*.txt";
        //    DialogResult result1 = openFileDialog1.ShowDialog();
        //    if (result1 == DialogResult.OK) // Test result.
        //    {

        //        string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
        //        int a = 0;
        //        bool isItem = false;
        //        PurchaseInvoice pi = new PurchaseInvoice();
        //        while (lines.Count() > a)
        //        {
        //            if (lines[a] != "")
        //            {
        //                if (lines[a].Substring(0, 2) == "FH")
        //                {
        //                    pi.CountryCode = lines[a].Substring(2, 3);
        //                    if (lines[a].Substring(5, 10) != "") pi.OrderDate = Convert.ToDateTime(lines[a].Substring(5, 10));
        //                    pi.OrderTime = lines[a].Substring(14, 5);
        //                }
        //                else if (lines[a].Substring(0, 2) == "IV")
        //                {
        //                    pi.ShipmentReference = lines[a].Substring(2, 10);
        //                    pi.BillingDocumentReference = lines[a].Substring(12, 10);
        //                    pi.ShippingCondition = lines[a].Substring(22, 2);
        //                    pi.BillingDocumentDate = lines[a].Substring(24, 8);
        //                    pi.SupplyingECCompany = lines[a].Substring(32, 4);
        //                    pi.CustomerReference = lines[a].Substring(34, 10);
        //                    pi.InvoiceTaxValue = lines[a].Substring(54, 18);
        //                    pi.InvoiceGoodsValue = lines[a].Substring(72, 18);
        //                    pi.InvoiceNettValue = lines[a].Substring(90, 18);
        //                    pi.Currency = lines[a].Substring(108, 3);
        //                    pi.AirwayBillNumber = lines[a].Substring(111, 20);

        //                }
        //                else if (lines[a].Substring(0, 2) == "FT")
        //                {
        //                    pi.LineControl = lines[a].Substring(2, 4);
        //                }
        //                else if (lines[a].Substring(0, 2) == "IC")
        //                {
        //                    pi.Surchargeordiscountindicator = lines[a].Substring(2, 3);
        //                    pi.ConditionType = lines[a].Substring(5, 4);
        //                    pi.ConditionText = lines[a].Substring(9, 80);
        //                    pi.ConditionValueN = lines[a].Substring(89, 18);
        //                }
        //                else if (lines[a].Substring(0, 2) == "CT")
        //                {
        //                    pi.LineControl2 = lines[a].Substring(2, 4);
        //                }
        //            }
        //            a++;
        //        }
        //        if (IME.PurchaseInvoices.Where(b => b.BillingDocumentReference == pi.BillingDocumentReference).FirstOrDefault() == null)
        //        {
        //            IME.PurchaseInvoices.Add(pi);
        //            IME.SaveChanges();
        //            a = 0;

        //            while (lines.Count() > a)
        //            {
        //                if (lines[a].Substring(0, 2) == "OI")
        //                {
        //                    PurchaseInvoiceDetail purchaseInvoiceDetail = new PurchaseInvoiceDetail();
        //                    purchaseInvoiceDetail.PurchaseInvoiceID = pi.ID;
        //                    purchaseInvoiceDetail.PurchaseOrderNumber = lines[a].Substring(2, 30);
        //                    purchaseInvoiceDetail.PurchaseOrderItemNumber = lines[a].Substring(32, 6);
        //                    purchaseInvoiceDetail.ProductNumber = lines[a].Substring(38, 18);
        //                    purchaseInvoiceDetail.BillingItemNumber = lines[a].Substring(56, 6);
        //                    purchaseInvoiceDetail.Quantity = lines[a].Substring(62, 15);
        //                    purchaseInvoiceDetail.SalesUnit = lines[a].Substring(77, 3);
        //                    purchaseInvoiceDetail.UnitPrice = lines[a].Substring(80, 11);
        //                    purchaseInvoiceDetail.Discount = lines[a].Substring(91, 11);
        //                    purchaseInvoiceDetail.Tax = lines[a].Substring(102, 11);
        //                    purchaseInvoiceDetail.GoodsValue = lines[a].Substring(113, 11);
        //                    purchaseInvoiceDetail.Amount = lines[a].Substring(124, 11);
        //                    purchaseInvoiceDetail.CCCNno = lines[a].Substring(135, 15);
        //                    purchaseInvoiceDetail.CountryofOrigin = lines[a].Substring(150, 3);
        //                    purchaseInvoiceDetail.ArticleDescription = lines[a].Substring(153, 40);
        //                    purchaseInvoiceDetail.DeliveryNumber = lines[a].Substring(193, 10);
        //                    purchaseInvoiceDetail.DeliveryItemNumber = lines[a].Substring(203, 6);
        //                    IME.PurchaseInvoiceDetails.Add(purchaseInvoiceDetail);
        //                    IME.SaveChanges();
        //                    isItem = true;
        //                }
        //                a++;
        //            }
        //            a = 0;
        //            MessageBox.Show("Purchase Invoice loaded succesfully");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Purchase Invoice already exist");
        //        }



        //    }
        //}

        public static string[] SuperDiskRead()
        {
            #region Superdisk
            int a = 1;
            string[] returnObject = new string[2];
            IMEEntities IME = new IMEEntities();
            SuperDisk Superdiskitems = new SuperDisk();
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            DialogResult result1 = openFileDialog1.ShowDialog();

            int UptCounter = 0;
            int AddedCounter = 0;
            if (result1 == DialogResult.OK) // Test result.
            {
                //returnObject[(int)LoaderResultColumns.FileName] = openFileDialog1.FileName;
                //try
                //{
                string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                string[] columnnames = lines[0].Split('|');
                string[] wordcontrol;
                bool isArrayTrue = true;
                if (columnnames[0] != "Article No") isArrayTrue = false;
                if (columnnames[1] != "Article Desc") isArrayTrue = false;
                if (columnnames[2] != "Pack Code") isArrayTrue = false;
                if (columnnames[3] != "Pack Quantity") isArrayTrue = false;
                if (columnnames[4] != "Unit Content") isArrayTrue = false;
                if (columnnames[5] != "Unit Measure") isArrayTrue = false;
                if (columnnames[6] != "Uk Col 1") isArrayTrue = false;
                if (columnnames[7] != "Standard Weight") isArrayTrue = false;
                if (columnnames[8] != "Hazardous Ind") isArrayTrue = false;
                if (columnnames[9] != "Calibration Ind") isArrayTrue = false;
                if (columnnames[10] != "Obsolete Flag") isArrayTrue = false;
                if (columnnames[11] != "MH1") isArrayTrue = false;
                if (columnnames[12] != "Low Discount Ind") isArrayTrue = false;
                if (columnnames[13] != "Licensed Ind") isArrayTrue = false;
                if (columnnames[14] != "Shelf Life") isArrayTrue = false;
                if (columnnames[15] != "CofO") isArrayTrue = false;
                if (columnnames[16] != "EUR1 Indicator") isArrayTrue = false;
                if (columnnames[17] != "CCCN No") isArrayTrue = false;
                if (columnnames[18] != "Supercede Date") isArrayTrue = false;
                if (columnnames[19] != "Current Cat page") isArrayTrue = false;
                if (columnnames[20] != "Uk Intro Date") isArrayTrue = false;
                if (columnnames[21] != "Filler") isArrayTrue = false;
                if (columnnames[22] != "Uk Disc Date") isArrayTrue = false;
                if (columnnames[23] != "Substitute By") isArrayTrue = false;
                if (columnnames[24] != "BHC Flag") isArrayTrue = false;
                if (columnnames[25] != "Filler1") isArrayTrue = false;
                if (columnnames[26] != "Future Sell Price") isArrayTrue = false;
                if (columnnames[27] != "Int Cat") isArrayTrue = false;
                if (columnnames[28] != "New Prod Change Ind") isArrayTrue = false;
                if (columnnames[29] != "Out of Stock Prohibit change ind") isArrayTrue = false;
                if (columnnames[30] != "Disc Change Ind") isArrayTrue = false;
                if (columnnames[31] != "Superceded Change Ind") isArrayTrue = false;
                if (columnnames[32] != "Pack Size Change Ind") isArrayTrue = false;
                if (columnnames[33] != "Rolled Product Change Ind") isArrayTrue = false;
                if (columnnames[34] != "Expiring Product Change Ind") isArrayTrue = false;
                if (columnnames[35] != "Manufacturer") isArrayTrue = false;
                if (columnnames[36] != "MPN") isArrayTrue = false;
                if (columnnames[37] != "MH Code Level 1") isArrayTrue = false;
                if (columnnames[38] != "Height") isArrayTrue = false;
                if (columnnames[39] != "Width") isArrayTrue = false;
                if (columnnames[40] != "Length") isArrayTrue = false;

                wordcontrol = lines[1].Split('|');
                if (!wordcontrol[0].Contains("P"))
                {

                    if (!isArrayTrue)
                    {
                        while (lines.Count() > a)
                        {
                            #region isArrayFalse
                            string[] word;
                            word = lines[a].Split('|');
                            for (int i = 0; i < columnnames.Count(); i++)
                            {

                                columnnames[i] = columnnames[i].Replace(" ", "_");
                                //burada Superdiskitems diye bir ITEM nesnesini dolduruyoruz
                                switch (columnnames[i])
                                {
                                    case "Article_Desc":
                                        Superdiskitems.Article_Desc = word[i];
                                        break;
                                    case "Article_No":
                                        Superdiskitems.Article_No = word[i];
                                        break;
                                    case "BHC_Flag":
                                        Superdiskitems.BHC_Flag = word[i];
                                        break;
                                    case "Calibration_Ind":
                                        Superdiskitems.Calibration_Ind = word[i];
                                        break;
                                    case "CCCN_No":
                                        Superdiskitems.CCCN_No = word[i];
                                        break;
                                    case "CofO":
                                        Superdiskitems.CofO = word[i];
                                        break;
                                    case "Current_Cat_page":
                                        Superdiskitems.Current_Cat_page = word[i];
                                        break;
                                    case "Disc_Change_Ind":
                                        Superdiskitems.Disc_Change_Ind = word[i];
                                        break;
                                    case "EUR1_Indicator":
                                        Superdiskitems.EUR1_Indicator = word[i];
                                        break;
                                    case "Expiring_Product_Change_Ind":
                                        Superdiskitems.Expiring_Product_Change_Ind = word[i];
                                        break;
                                    case "Filler":
                                        Superdiskitems.Filler = word[i];
                                        break;
                                    case "Filler1":
                                        Superdiskitems.Filler1 = word[i];
                                        break;
                                    case "Future_Sell_Price":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Future_Sell_Price = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Hazardous_Ind":
                                        Superdiskitems.Hazardous_Ind = word[i];
                                        break;
                                    case "Height":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Heigh = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Int_Cat":
                                        Superdiskitems.Int_Cat = word[i];
                                        break;
                                    case "Length":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Length = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Licensed_Ind":
                                        Superdiskitems.Licensed_Ind = word[i];
                                        break;
                                    case "Low_Discount_Ind":
                                        Superdiskitems.Low_Discount_Ind = word[i];
                                        break;
                                    case "Manufacturer":
                                        Superdiskitems.Manufacturer = word[i];
                                        break;
                                    case "MH1":
                                        Superdiskitems.MH1 = word[i];
                                        break;
                                    case "MH_Code_Level_1":
                                        Superdiskitems.MH_Code_Level_1 = word[i];
                                        break;
                                    case "MPN":
                                        Superdiskitems.MPN = word[i];
                                        break;
                                    case "New_Prod_Change_Ind":
                                        Superdiskitems.New_Prod_Change_Ind = word[i];
                                        break;
                                    case "Obsolete_Flag":
                                        Superdiskitems.Obsolete_Flag = word[i];
                                        break;
                                    case "Out_of_Stock_Prohibit_change_ind":
                                        Superdiskitems.Out_of_Stock_Prohibit_change_ind = word[i];
                                        break;
                                    case "Pack_Code":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Pack_Code = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Pack_Quantity":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Pack_Quantity = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Pack_Size_Change_Ind":
                                        Superdiskitems.Pack_Size_Change_Ind = word[i];
                                        break;
                                    case "Rolled_Product_Change_Ind":
                                        Superdiskitems.Rolled_Product_Change_Ind = word[i];
                                        break;
                                    case "Shelf_Life":
                                        Superdiskitems.Shelf_Life = word[i];
                                        break;
                                    case "Standard_Weight":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Standard_Weight = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Substitute_By":
                                        Superdiskitems.Substitute_By = word[i];
                                        break;
                                    case "Superceded_Change_Ind":
                                        Superdiskitems.Superceded_Change_Ind = word[i];
                                        break;
                                    case "Supercede_Date":
                                        Superdiskitems.Supercede_Date = word[i];
                                        break;
                                    case "Uk_Col_1":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Uk_Col_1 = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Uk_Disc_Date":
                                        Superdiskitems.Uk_Disc_Date = word[i];
                                        break;
                                    case "Uk_Intro_Date":
                                        Superdiskitems.Uk_Intro_Date = word[i];
                                        break;
                                    case "Unit_Content":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Unit_Content = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Unit_Measure":
                                        Superdiskitems.Unit_Measure = word[i];
                                        break;
                                    case "Width":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Width = decimal.Parse(word[i]);
                                        }
                                        break;
                                }
                            }

                            IME.SuperDiskAdd(
                                  Superdiskitems.Article_No,
                         Superdiskitems.Article_Desc,
                         Superdiskitems.Pack_Code,
                         Superdiskitems.Pack_Quantity,
                         Superdiskitems.Unit_Content,
                         Superdiskitems.Unit_Measure,
                         Superdiskitems.Uk_Col_1,
                         Superdiskitems.Standard_Weight,
                         Superdiskitems.Hazardous_Ind,
                         Superdiskitems.Calibration_Ind,
                         Superdiskitems.Obsolete_Flag,
                         Superdiskitems.MH1,
                         Superdiskitems.Low_Discount_Ind,
                         Superdiskitems.Licensed_Ind,
                         Superdiskitems.Shelf_Life,
                         Superdiskitems.CofO,
                         Superdiskitems.EUR1_Indicator,
                         Superdiskitems.CCCN_No,
                         Superdiskitems.Supercede_Date,
                         Superdiskitems.Current_Cat_page,
                         Superdiskitems.Uk_Intro_Date,
                         Superdiskitems.Filler,
                         Superdiskitems.Uk_Disc_Date,
                         Superdiskitems.Substitute_By,
                         Superdiskitems.BHC_Flag,
                         Superdiskitems.Filler1,
                         Superdiskitems.Future_Sell_Price,
                         Superdiskitems.Int_Cat,
                         Superdiskitems.New_Prod_Change_Ind,
                         Superdiskitems.Out_of_Stock_Prohibit_change_ind,
                         Superdiskitems.Disc_Change_Ind,
                         Superdiskitems.Superceded_Change_Ind,
                         Superdiskitems.Pack_Size_Change_Ind,
                         Superdiskitems.Rolled_Product_Change_Ind,
                         Superdiskitems.Expiring_Product_Change_Ind,
                         Superdiskitems.Manufacturer,
                         Superdiskitems.MPN,
                         Superdiskitems.MH_Code_Level_1,
                         Superdiskitems.Heigh,
                         Superdiskitems.Width,
                         Superdiskitems.Length);
                            a++;
                        }

                        #endregion
                    }
                    else
                    {
                        while (lines.Count() > a)
                        {
                            string[] word;
                            word = lines[a].Split('|');
                            //superdisk ADD
                            SuperDisk s = new SuperDisk();
                            s.Article_No = word[0];
                            s.Article_Desc = word[1];
                            if (word[2] != "") s.Pack_Code = Int32.Parse(word[2]);
                            if (word[3] != "") s.Pack_Quantity = Int32.Parse(word[3]);
                            if (word[4] != "") s.Unit_Content = Int32.Parse(word[4]);
                            s.Unit_Measure = word[5];
                            if (word[6] != "") s.Uk_Col_1 = decimal.Parse(word[6]);
                            if (word[7] != "") s.Standard_Weight = Int32.Parse(word[7]);
                            s.Hazardous_Ind = word[8];
                            s.Calibration_Ind = word[9];
                            s.Obsolete_Flag = word[10];
                            s.MH1 = word[11];
                            s.Low_Discount_Ind = word[12];
                            s.Licensed_Ind = word[13];
                            s.Shelf_Life = word[14];
                            s.CofO = word[15];
                            s.EUR1_Indicator = word[16];
                            s.CCCN_No = word[17];
                            s.Supercede_Date = word[18];
                            s.Current_Cat_page = word[19];
                            s.Uk_Intro_Date = word[20];
                            s.Filler = word[21];
                            s.Uk_Disc_Date = word[22];
                            s.Substitute_By = word[23];
                            s.BHC_Flag = word[24];
                            s.Filler1 = word[25];
                            if (word[26] != "") s.Future_Sell_Price = decimal.Parse(word[26]);
                            s.Int_Cat = word[27];
                            s.New_Prod_Change_Ind = word[28];
                            s.Out_of_Stock_Prohibit_change_ind = word[29];
                            s.Disc_Change_Ind = word[30];
                            s.Superceded_Change_Ind = word[31];
                            s.Pack_Size_Change_Ind = word[32];
                            s.Rolled_Product_Change_Ind = word[33];
                            s.Expiring_Product_Change_Ind = word[34];
                            s.Manufacturer = word[35];
                            s.MPN = word[36];
                            s.MH_Code_Level_1 = word[37];
                            if (word[38] != "") s.Heigh = decimal.Parse(word[38]);
                            if (word[39] != "") s.Width = decimal.Parse(word[39]);
                            if (word[40] != "") s.Length = decimal.Parse(word[40]);

                            IME.SuperDiskAdd(
                                 s.Article_No,
                        s.Article_Desc,
                        s.Pack_Code,
                        s.Pack_Quantity,
                        s.Unit_Content,
                        s.Unit_Measure,
                        s.Uk_Col_1,
                        s.Standard_Weight,
                        s.Hazardous_Ind,
                        s.Calibration_Ind,
                        s.Obsolete_Flag,
                        s.MH1,
                        s.Low_Discount_Ind,
                        s.Licensed_Ind,
                        s.Shelf_Life,
                        s.CofO,
                        s.EUR1_Indicator,
                        s.CCCN_No,
                        s.Supercede_Date,
                        s.Current_Cat_page,
                        s.Uk_Intro_Date,
                        s.Filler,
                        s.Uk_Disc_Date,
                        s.Substitute_By,
                        s.BHC_Flag,
                        s.Filler1,
                        s.Future_Sell_Price,
                        s.Int_Cat,
                        s.New_Prod_Change_Ind,
                        s.Out_of_Stock_Prohibit_change_ind,
                        s.Disc_Change_Ind,
                        s.Superceded_Change_Ind,
                        s.Pack_Size_Change_Ind,
                        s.Rolled_Product_Change_Ind,
                        s.Expiring_Product_Change_Ind,
                        s.Manufacturer,
                        s.MPN,
                        s.MH_Code_Level_1,
                        s.Heigh,
                        s.Width,
                        s.Length);
                            a++;
                        }
                    }
                    MessageBox.Show("Upload Completed");
                    //returnObject[(int)LoaderResultColumns.Result] = "1";
                    return returnObject;
                }
                else
                {
                    MessageBox.Show("Please Choose Correct File");
                    //returnObject[(int)LoaderResultColumns.Result] = "0";
                    return returnObject;
                }
                //}
                //catch (Exception ex) { MessageBox.Show(ex.Message); MessageBox.Show(a.ToString()); return 0; }
                #endregion
            }
            //returnObject[(int)LoaderResultColumns.Result] = "0";
            return returnObject;
        }

        public static int SuperDiskPRead()
        {
            #region Superdisk
            int a = 1;
            IMEEntities IME = new IMEEntities();
            SuperDiskP Superdiskitems = new SuperDiskP();
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            DialogResult result1 = openFileDialog1.ShowDialog();

            int UptCounter = 0;
            int AddedCounter = 0;
            if (result1 == DialogResult.OK) // Test result.
            {
                //try
                //{
                string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                string[] columnnames = lines[0].Split('|');
                string[] wordcontrol;
                bool isArrayTrue = true;
                if (columnnames[0] != "Article No") isArrayTrue = false;
                if (columnnames[1] != "Article Desc") isArrayTrue = false;
                if (columnnames[2] != "Pack Code") isArrayTrue = false;
                if (columnnames[3] != "Pack Quantity") isArrayTrue = false;
                if (columnnames[4] != "Unit Content") isArrayTrue = false;
                if (columnnames[5] != "Unit Measure") isArrayTrue = false;
                if (columnnames[6] != "Uk Col 1") isArrayTrue = false;
                if (columnnames[7] != "Standard Weight") isArrayTrue = false;
                if (columnnames[8] != "Hazardous Ind") isArrayTrue = false;
                if (columnnames[9] != "Calibration Ind") isArrayTrue = false;
                if (columnnames[10] != "Obsolete Flag") isArrayTrue = false;
                if (columnnames[11] != "MH1") isArrayTrue = false;
                if (columnnames[12] != "Low Discount Ind") isArrayTrue = false;
                if (columnnames[13] != "Licensed Ind") isArrayTrue = false;
                if (columnnames[14] != "Shelf Life") isArrayTrue = false;
                if (columnnames[15] != "CofO") isArrayTrue = false;
                if (columnnames[16] != "EUR1 Indicator") isArrayTrue = false;
                if (columnnames[17] != "CCCN No") isArrayTrue = false;
                if (columnnames[18] != "Supercede Date") isArrayTrue = false;
                if (columnnames[19] != "Current Cat page") isArrayTrue = false;
                if (columnnames[20] != "Uk Intro Date") isArrayTrue = false;
                if (columnnames[21] != "Filler") isArrayTrue = false;
                if (columnnames[22] != "Uk Disc Date") isArrayTrue = false;
                if (columnnames[23] != "Substitute By") isArrayTrue = false;
                if (columnnames[24] != "BHC Flag") isArrayTrue = false;
                if (columnnames[25] != "Filler1") isArrayTrue = false;
                if (columnnames[26] != "Future Sell Price") isArrayTrue = false;
                if (columnnames[27] != "Int Cat") isArrayTrue = false;
                if (columnnames[28] != "New Prod Change Ind") isArrayTrue = false;
                if (columnnames[29] != "Out of Stock Prohibit change ind") isArrayTrue = false;
                if (columnnames[30] != "Disc Change Ind") isArrayTrue = false;
                if (columnnames[31] != "Superceded Change Ind") isArrayTrue = false;
                if (columnnames[32] != "Pack Size Change Ind") isArrayTrue = false;
                if (columnnames[33] != "Rolled Product Change Ind") isArrayTrue = false;
                if (columnnames[34] != "Expiring Product Change Ind") isArrayTrue = false;
                if (columnnames[35] != "Manufacturer") isArrayTrue = false;
                if (columnnames[36] != "MPN") isArrayTrue = false;
                if (columnnames[37] != "MH Code Level 1") isArrayTrue = false;
                if (columnnames[38] != "Height") isArrayTrue = false;
                if (columnnames[39] != "Width") isArrayTrue = false;
                if (columnnames[40] != "Length") isArrayTrue = false;

                wordcontrol = lines[1].Split('|');
                if (wordcontrol[0].Contains("P"))
                {

                    if (!isArrayTrue)
                    {
                        while (lines.Count() > a)
                        {
                            #region isArrayFalse
                            string[] word;
                            word = lines[a].Split('|');
                            for (int i = 0; i < columnnames.Count(); i++)
                            {

                                columnnames[i] = columnnames[i].Replace(" ", "_");
                                //burada Superdiskitems diye bir ITEM nesnesini dolduruyoruz
                                switch (columnnames[i])
                                {
                                    case "Article_Desc":
                                        Superdiskitems.Article_Desc = word[i];
                                        break;
                                    case "Article_No":
                                        Superdiskitems.Article_No = word[i];
                                        break;
                                    case "BHC_Flag":
                                        Superdiskitems.BHC_Flag = word[i];
                                        break;
                                    case "Calibration_Ind":
                                        Superdiskitems.Calibration_Ind = word[i];
                                        break;
                                    case "CCCN_No":
                                        Superdiskitems.CCCN_No = word[i];
                                        break;
                                    case "CofO":
                                        Superdiskitems.CofO = word[i];
                                        break;
                                    case "Current_Cat_page":
                                        Superdiskitems.Current_Cat_page = word[i];
                                        break;
                                    case "Disc_Change_Ind":
                                        Superdiskitems.Disc_Change_Ind = word[i];
                                        break;
                                    case "EUR1_Indicator":
                                        Superdiskitems.EUR1_Indicator = word[i];
                                        break;
                                    case "Expiring_Product_Change_Ind":
                                        Superdiskitems.Expiring_Product_Change_Ind = word[i];
                                        break;
                                    case "Filler":
                                        Superdiskitems.Filler = word[i];
                                        break;
                                    case "Filler1":
                                        Superdiskitems.Filler1 = word[i];
                                        break;
                                    case "Future_Sell_Price":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Future_Sell_Price = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Hazardous_Ind":
                                        Superdiskitems.Hazardous_Ind = word[i];
                                        break;
                                    case "Height":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Heigh = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Int_Cat":
                                        Superdiskitems.Int_Cat = word[i];
                                        break;
                                    case "Length":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Length = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Licensed_Ind":
                                        Superdiskitems.Licensed_Ind = word[i];
                                        break;
                                    case "Low_Discount_Ind":
                                        Superdiskitems.Low_Discount_Ind = word[i];
                                        break;
                                    case "Manufacturer":
                                        Superdiskitems.Manufacturer = word[i];
                                        break;
                                    case "MH1":
                                        Superdiskitems.MH1 = word[i];
                                        break;
                                    case "MH_Code_Level_1":
                                        Superdiskitems.MH_Code_Level_1 = word[i];
                                        break;
                                    case "MPN":
                                        Superdiskitems.MPN = word[i];
                                        break;
                                    case "New_Prod_Change_Ind":
                                        Superdiskitems.New_Prod_Change_Ind = word[i];
                                        break;
                                    case "Obsolete_Flag":
                                        Superdiskitems.Obsolete_Flag = word[i];
                                        break;
                                    case "Out_of_Stock_Prohibit_change_ind":
                                        Superdiskitems.Out_of_Stock_Prohibit_change_ind = word[i];
                                        break;
                                    case "Pack_Code":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Pack_Code = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Pack_Quantity":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Pack_Quantity = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Pack_Size_Change_Ind":
                                        Superdiskitems.Pack_Size_Change_Ind = word[i];
                                        break;
                                    case "Rolled_Product_Change_Ind":
                                        Superdiskitems.Rolled_Product_Change_Ind = word[i];
                                        break;
                                    case "Shelf_Life":
                                        Superdiskitems.Shelf_Life = word[i];
                                        break;
                                    case "Standard_Weight":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Standard_Weight = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Substitute_By":
                                        Superdiskitems.Substitute_By = word[i];
                                        break;
                                    case "Superceded_Change_Ind":
                                        Superdiskitems.Superceded_Change_Ind = word[i];
                                        break;
                                    case "Supercede_Date":
                                        Superdiskitems.Supercede_Date = word[i];
                                        break;
                                    case "Uk_Col_1":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Uk_Col_1 = decimal.Parse(word[i]);
                                        }
                                        break;
                                    case "Uk_Disc_Date":
                                        Superdiskitems.Uk_Disc_Date = word[i];
                                        break;
                                    case "Uk_Intro_Date":
                                        Superdiskitems.Uk_Intro_Date = word[i];
                                        break;
                                    case "Unit_Content":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Unit_Content = Int32.Parse(word[i]);
                                        }
                                        break;
                                    case "Unit_Measure":
                                        Superdiskitems.Unit_Measure = word[i];
                                        break;
                                    case "Width":
                                        if (word[i] != "")
                                        {
                                            Superdiskitems.Width = decimal.Parse(word[i]);
                                        }
                                        break;
                                }
                            }
                            IME.SuperDiskPAdd(
                                  Superdiskitems.Article_No,
                         Superdiskitems.Article_Desc,
                         Superdiskitems.Pack_Code,
                         Superdiskitems.Pack_Quantity,
                         Superdiskitems.Unit_Content,
                         Superdiskitems.Unit_Measure,
                         Superdiskitems.Uk_Col_1,
                         Superdiskitems.Standard_Weight,
                         Superdiskitems.Hazardous_Ind,
                         Superdiskitems.Calibration_Ind,
                         Superdiskitems.Obsolete_Flag,
                         Superdiskitems.MH1,
                         Superdiskitems.Low_Discount_Ind,
                         Superdiskitems.Licensed_Ind,
                         Superdiskitems.Shelf_Life,
                         Superdiskitems.CofO,
                         Superdiskitems.EUR1_Indicator,
                         Superdiskitems.CCCN_No,
                         Superdiskitems.Supercede_Date,
                         Superdiskitems.Current_Cat_page,
                         Superdiskitems.Uk_Intro_Date,
                         Superdiskitems.Filler,
                         Superdiskitems.Uk_Disc_Date,
                         Superdiskitems.Substitute_By,
                         Superdiskitems.BHC_Flag,
                         Superdiskitems.Filler1,
                         Superdiskitems.Future_Sell_Price,
                         Superdiskitems.Int_Cat,
                         Superdiskitems.New_Prod_Change_Ind,
                         Superdiskitems.Out_of_Stock_Prohibit_change_ind,
                         Superdiskitems.Disc_Change_Ind,
                         Superdiskitems.Superceded_Change_Ind,
                         Superdiskitems.Pack_Size_Change_Ind,
                         Superdiskitems.Rolled_Product_Change_Ind,
                         Superdiskitems.Expiring_Product_Change_Ind,
                         Superdiskitems.Manufacturer,
                         Superdiskitems.MPN,
                         Superdiskitems.MH_Code_Level_1,
                         Superdiskitems.Heigh,
                         Superdiskitems.Width,
                         Superdiskitems.Length);
                            a++;
                        }

                        #endregion
                    }
                    else
                    {
                        while (lines.Count() > a)
                        {
                            string[] word;
                            word = lines[a].Split('|');
                            //superdisk ADD
                            SuperDisk s = new SuperDisk();
                            s.Article_No = word[0];
                            s.Article_Desc = word[1];
                            if (word[2] != "") s.Pack_Code = Int32.Parse(word[2]);
                            if (word[3] != "") s.Pack_Quantity = Int32.Parse(word[3]);
                            if (word[4] != "") s.Unit_Content = Int32.Parse(word[4]);
                            s.Unit_Measure = word[5];
                            if (word[6] != "") s.Uk_Col_1 = decimal.Parse(word[6]);
                            if (word[7] != "") s.Standard_Weight = Int32.Parse(word[7]);
                            s.Hazardous_Ind = word[8];
                            s.Calibration_Ind = word[9];
                            s.Obsolete_Flag = word[10];
                            s.MH1 = word[11];
                            s.Low_Discount_Ind = word[12];
                            s.Licensed_Ind = word[13];
                            s.Shelf_Life = word[14];
                            s.CofO = word[15];
                            s.EUR1_Indicator = word[16];
                            s.CCCN_No = word[17];
                            s.Supercede_Date = word[18];
                            s.Current_Cat_page = word[19];
                            s.Uk_Intro_Date = word[20];
                            s.Filler = word[21];
                            s.Uk_Disc_Date = word[22];
                            s.Substitute_By = word[23];
                            s.BHC_Flag = word[24];
                            s.Filler1 = word[25];
                            if (word[26] != "") s.Future_Sell_Price = decimal.Parse(word[26]);
                            s.Int_Cat = word[27];
                            s.New_Prod_Change_Ind = word[28];
                            s.Out_of_Stock_Prohibit_change_ind = word[29];
                            s.Disc_Change_Ind = word[30];
                            s.Superceded_Change_Ind = word[31];
                            s.Pack_Size_Change_Ind = word[32];
                            s.Rolled_Product_Change_Ind = word[33];
                            s.Expiring_Product_Change_Ind = word[34];
                            s.Manufacturer = word[35];
                            s.MPN = word[36];
                            s.MH_Code_Level_1 = word[37];
                            if (word[38] != "") s.Heigh = decimal.Parse(word[38]);
                            if (word[39] != "") s.Width = decimal.Parse(word[39]);
                            if (word[40] != "") s.Length = decimal.Parse(word[40]);

                            IME.SuperDiskPAdd(
                                 s.Article_No,
                        s.Article_Desc,
                        s.Pack_Code,
                        s.Pack_Quantity,
                        s.Unit_Content,
                        s.Unit_Measure,
                        s.Uk_Col_1,
                        s.Standard_Weight,
                        s.Hazardous_Ind,
                        s.Calibration_Ind,
                        s.Obsolete_Flag,
                        s.MH1,
                        s.Low_Discount_Ind,
                        s.Licensed_Ind,
                        s.Shelf_Life,
                        s.CofO,
                        s.EUR1_Indicator,
                        s.CCCN_No,
                        s.Supercede_Date,
                        s.Current_Cat_page,
                        s.Uk_Intro_Date,
                        s.Filler,
                        s.Uk_Disc_Date,
                        s.Substitute_By,
                        s.BHC_Flag,
                        s.Filler1,
                        s.Future_Sell_Price,
                        s.Int_Cat,
                        s.New_Prod_Change_Ind,
                        s.Out_of_Stock_Prohibit_change_ind,
                        s.Disc_Change_Ind,
                        s.Superceded_Change_Ind,
                        s.Pack_Size_Change_Ind,
                        s.Rolled_Product_Change_Ind,
                        s.Expiring_Product_Change_Ind,
                        s.Manufacturer,
                        s.MPN,
                        s.MH_Code_Level_1,
                        s.Heigh,
                        s.Width,
                        s.Length);
                            a++;
                        }
                    }
                    MessageBox.Show("Upload Completed");
                    return 1;
                }
                else
                {
                    MessageBox.Show("Please Choose Correct File");
                    return 0;
                }
                //}
                //catch (Exception ex) { MessageBox.Show(ex.Message); MessageBox.Show(a.ToString()); return 0; }
                #endregion
            }
            return 0;
        }

        public static int SlidingPriceRead()
        {
            #region SlidingPrice
            IMEEntities IME = new IMEEntities();
            SlidingPrice Superdiskitems = new SlidingPrice();
            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK) // Test result.
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                    string[] columnnames = lines[0].Split('|');
                    int a = 1;
                    while (lines.Count() > a)
                    {
                        string[] word;
                        word = lines[a].Split('|');
                        for (int i = 0; i < columnnames.Count(); i++)
                        {

                            switch (columnnames[i])
                            {
                                case "ArticleDescription":
                                    Superdiskitems.ArticleDescription = word[i];
                                    break;
                                case "ArticleNo":
                                    Superdiskitems.ArticleNo = word[i].ToString();
                                    break;
                                case "ItemTypeCode":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.ItemTypeCode = Int32.Parse(word[i]);
                                    }
                                    break;
                                case "ItemTypeDesc":
                                    Superdiskitems.ItemTypeDesc = word[i];
                                    break;
                                case "Quantity1":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Quantity1 = Int32.Parse(word[i]);
                                    }
                                    break;
                                case "SupersectionName":
                                    Superdiskitems.SupersectionName = word[i];
                                    break;
                                case "SuperSectionNo":
                                    Superdiskitems.SuperSectionNo = word[i];
                                    break;


                                case "BrandID":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.BrandID = word[i];
                                    }
                                    break;
                                case "Brandname":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Brandname = word[i];
                                    }
                                    break;
                                case "SectionID":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.SectionID = word[i];
                                    }
                                    break;
                                case "SectionName":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.SectionName = word[i];
                                    }
                                    break;
                                case "IntroductionDate":
                                    Superdiskitems.IntroductionDate = word[i];
                                    break;
                                case "Col1Break":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col1Break = Int32.Parse(word[i]);
                                    }
                                    break;
                                case "Col2Break":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col2Break = Int32.Parse(word[i]);
                                    }
                                    break;
                                case "Col3Break":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col3Break = Int32.Parse(word[i]);
                                    }
                                    break;
                                case "Col4Break":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col4Break = Int32.Parse(word[i]);
                                    }
                                    break;
                                case "Col5Break":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col5Break = Int32.Parse(word[i]);
                                    }
                                    break;
                                case "Col1Price":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col1Price = decimal.Parse(word[i]);
                                    }
                                    break;
                                case "Col2Price":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col2Price = decimal.Parse(word[i]);
                                    }
                                    break;
                                case "Col3Price":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col3Price = decimal.Parse(word[i]);
                                    }
                                    break;
                                case "Col4Price":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col4Price = decimal.Parse(word[i]);
                                    }
                                    break;
                                case "Col5Price":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.Col5Price = decimal.Parse(word[i]);
                                    }
                                    break;
                                case "DiscontinuedDate":
                                    Superdiskitems.DiscontinuedDate = word[i];
                                    break;
                                case "DiscountedPrice1":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.DiscountedPrice1 = decimal.Parse(word[i]);
                                    }
                                    break;
                                case "DiscountedPrice2":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.DiscountedPrice2 = decimal.Parse(word[i]);
                                    }
                                    break;
                                case "DiscountedPrice3":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.DiscountedPrice3 = decimal.Parse(word[i]);
                                    }
                                    break;
                                case "DiscountedPrice4":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.DiscountedPrice4 = decimal.Parse(word[i]);
                                    }
                                    break;
                                case "DiscountedPrice5":
                                    if (word[i] != "")
                                    {
                                        Superdiskitems.DiscountedPrice5 = decimal.Parse(word[i]); ;
                                    }
                                    break;
                            }
                        }

                        IME.SlidingPriceAdd(
                            Superdiskitems.ArticleNo
                           , Superdiskitems.ArticleDescription
                           , Superdiskitems.ItemTypeCode
                           , Superdiskitems.ItemTypeDesc
                           , Superdiskitems.IntroductionDate
                           , Superdiskitems.DiscontinuedDate
                           , Superdiskitems.Quantity1
                           , Superdiskitems.Col1Price
                           , Superdiskitems.Col2Price
                           , Superdiskitems.Col3Price
                           , Superdiskitems.Col4Price
                           , Superdiskitems.Col5Price
                           , Superdiskitems.Col1Break
                           , Superdiskitems.Col2Break
                           , Superdiskitems.Col3Break
                           , Superdiskitems.Col4Break
                           , Superdiskitems.Col5Break
                           , Superdiskitems.DiscountedPrice1
                           , Superdiskitems.DiscountedPrice2
                           , Superdiskitems.DiscountedPrice3
                           , Superdiskitems.DiscountedPrice4
                           , Superdiskitems.DiscountedPrice5
                           , Superdiskitems.SuperSectionNo
                           , Superdiskitems.SupersectionName
                           , Superdiskitems.BrandID
                           , Superdiskitems.Brandname
                           , Superdiskitems.SectionID
                           , Superdiskitems.SectionName
                          );


                        a++;
                        Superdiskitems = new SlidingPrice();
                    }

                    MessageBox.Show("Upload Completed");
                    return 1;
                }
                catch { MessageBox.Show("Please Choose Correct File"); return 0; }

                #endregion
            }
            return 0;
        }

        public static int OnSaleRead()
        {

            #region OnSale
            IMEEntities IME = new IMEEntities();

            OnSale item = new OnSale();
            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK) // Test result.
            {
                try
                {
                    IME.OnSaleDeleteAllItems();
                    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                    string[] columnnames = lines[0].Split(',');
                    int a = 1;
                    while (lines.Count() > a)
                    {
                        string[] word;
                        word = lines[a].Split(new string[] { "\"," }, StringSplitOptions.None);
                        word = lines[a].Replace("\"", "").Split(',');
                        for (int i = 0; i < columnnames.Count(); i++)
                        {

                            switch (columnnames[i])
                            {
                                case "\"Article Number\"":
                                    item.ArticleNumber = word[i].Replace("\"", "");
                                    break;
                                case "\"Available to Promise Check\"":
                                    item.AvailabletoPromiseCheck = word[i].Replace("\"", "");
                                    break;
                                case "\"Bulk Pack\"":
                                    if (word[i] != "")
                                    {
                                        item.BulkPack = word[i].Replace("\"", "");
                                    }
                                    break;
                                case "\"Catalogue Status\"":
                                    if (word[i] != "")
                                    {
                                        item.CatalogueStatus = Convert.ToInt32(word[i].Replace("\"", ""));
                                    }
                                    break;
                                case "\"Discontinued Date\"":
                                    item.DiscontinuedDate = word[i].Replace("\"", "");
                                    break;
                                case "\"Introduction Date\"":
                                    item.IntroductionDate = word[i].Replace("\"", "");
                                    break;
                                case "\"Next Scheduled Delivery\"":
                                    item.NextScheduledDelivery = word[i].Replace("\"", "");
                                    break;
                                case "\"Onhand Stock Balance\"":
                                    if (word[i] != "")
                                    {
                                        item.OnhandStockBalance = Convert.ToInt64(word[i].Replace("\"", ""));
                                    }
                                    break;
                                case "\"Pack Size\"":
                                    if (word[i] != "")
                                    {
                                        item.PackSize = Convert.ToInt32(word[i].Replace("\"", ""));
                                    }
                                    break;
                                case "\"Quantity on Order\"":
                                    if (word[i] != "")
                                    {
                                        item.QuantityonOrder = Convert.ToInt32(word[i].Replace("\"", ""));
                                    }
                                    break;
                                case "\"Small Order Protection Level\"":
                                    item.SmallOrderProtectionLevel = word[i].Replace("\"", "");
                                    break;
                                case "\"Substituted By\"":
                                    item.SubstitutedBy = word[i].Replace("\"", "");
                                    break;
                                case "\"Substituted For\"":
                                    item.SubstitutedFor = word[i].Replace("\"", "");
                                    break;
                            }
                        }

                        IME.OnSaleAdd(
                            item.ArticleNumber
                           , item.AvailabletoPromiseCheck
                           , item.BulkPack
                           , item.CatalogueStatus
                           , item.DiscontinuedDate
                           , item.IntroductionDate
                           , item.NextScheduledDelivery
                           , item.OnhandStockBalance
                           , item.PackSize
                           , item.QuantityonOrder
                           , item.SmallOrderProtectionLevel
                           , item.SubstitutedBy
                           , item.SubstitutedFor
                          );


                        a++;
                        item = new OnSale();
                    }

                    MessageBox.Show("Upload Completed");
                    return 1;
                }
                catch (DbEntityValidationException e)
                {

                    foreach (var eve in e.EntityValidationErrors)
                    {
                        MessageBox.Show(string.Format("Entity türü \"{0}\" şu hatalara sahip \"{1}\" Geçerlilik hataları:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show(string.Format("- Özellik: \"{0}\", Hata: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                        }
                    }

                }
            }
            return 0;

            #endregion
        }

        public static int DiscontinuedListRead()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Excel.Application excel = new Excel.Application();
            //openFileDialog1.FileName = "*.xls";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    Excel.Workbook theWorkbook = excel.Workbooks.Open(
            //       openFileDialog1.FileName, 0, true, 5,
            //        "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
            //        0, true);
            //    Excel.Sheets sheets = theWorkbook.Worksheets;
            //    Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
            //    for (int i = 1; i <= 10; i++)
            //    {
            //        Excel.Range range = worksheet.get_Range("A" + i.ToString(), "J" + i.ToString());
            //        System.Array myvalues = (System.Array)range.Cells.Value;

            //    }
            //}



            //


            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                try
                {
                    Excel.Application excel = new Excel.Application();
                    Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                    Worksheet ws = wb.Worksheets[1];
                    int ColumnNumber = 2;
                    string ArticleNumb = ws.Cells[2, 1].Text;
                    #region DiscontinuedList
                    while (ArticleNumb != "")
                    {
                        DailyDiscontinued DailyDiscontinued = new DailyDiscontinued();
                        if (IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() != null)
                        {

                            //UPDATE
                            DailyDiscontinued = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault();
                            UptCounter++;
                        }
                        DailyDiscontinued.ArticleNo = ws.Cells[ColumnNumber, 1].Text;
                        DailyDiscontinued.ReasonDescription = ws.Cells[ColumnNumber, 2].Text;
                        DailyDiscontinued.DiscontinuationDate = ws.Cells[ColumnNumber, 3].Text;
                        DailyDiscontinued.Runon = ws.Cells[ColumnNumber, 4].Text;
                        DailyDiscontinued.Referral = ws.Cells[ColumnNumber, 5].Text;

                        if (IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() == null)
                        {
                            IME.DailyDiscontinueds.Add(DailyDiscontinued);
                            AddedCounter++;
                        }
                        IME.SaveChanges();
                        DailyDiscontinued = new DailyDiscontinued();
                        ColumnNumber++;
                        ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                    }
                    MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                    return 1;
                    #endregion
                }
                catch (Exception e) { MessageBox.Show("This document does not proper to load here"); return 0; }
            }
            return 0;

        }

        public static int DualUsedRead()
        {
            #region DualUsedList
            IMEEntities IME = new IMEEntities();
            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                try
                {
                    Excel.Application excel = new Excel.Application();
                    Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                    Worksheet ws = wb.Worksheets[1];
                    int ColumnNumber = 2;
                    string ArticleNumb = ws.Cells[2, 1].Text;
                    while (ArticleNumb != "")
                    {
                        DualUse DualUse = new DualUse();
                        if (IME.DualUses.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() != null)
                        {
                            //UPDATE
                            DualUse = IME.DualUses.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault();
                            UptCounter++;

                        }
                        DualUse.ArticleNo = ws.Cells[ColumnNumber, 1].Text;
                        DualUse.DualUseSite = ws.Cells[ColumnNumber, 2].Text;
                        DualUse.LicenceType = ws.Cells[ColumnNumber, 3].Text;
                        DualUse.ControlClass = ws.Cells[ColumnNumber, 4].Text;


                        if (IME.DualUses.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() == null)
                        {
                            IME.DualUses.Add(DualUse);
                            AddedCounter++;
                        }
                        IME.SaveChanges();
                        DualUse = new DualUse();
                        ColumnNumber++;
                        ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                    }
                    MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                    return 1;
                    #endregion
                }
                catch { MessageBox.Show("This document does not proper to load here"); return 0; }
            }
            return 0;
        }

        public static int HazardousRead()
        {
            #region HazardousRead
            IMEEntities IME = new IMEEntities();
            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xlsx files (*.xlsx,*.xls)| *.xlsx;*.xls";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                try
                {
                    Excel.Application excel = new Excel.Application();
                    Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                    Worksheet ws = wb.Worksheets[4];
                    int ColumnNumber = 2;
                    string ArticleNumb = ws.Cells[2, 3].Text;
                    while (ArticleNumb != "")
                    {
                        Hazardou Hazardou = new Hazardou();
                        if (IME.Hazardous.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() != null)
                        {
                            //UPDATE

                            Hazardou = IME.Hazardous.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault();
                            UptCounter++;
                        }
                        Hazardou.ArticleNo = ws.Cells[ColumnNumber, 3].Text;

                        if (ws.Cells[ColumnNumber, 4].Text != "") { Hazardou.Occurrences = Int32.Parse(ws.Cells[ColumnNumber, 4].Text); }
                        if (ws.Cells[ColumnNumber, 5].Text != "") { Hazardou.Environment = Int32.Parse(ws.Cells[ColumnNumber, 5].Text); }
                        Hazardou.Shipping = ws.Cells[ColumnNumber, 6].Text;
                        Hazardou.Lithium = ws.Cells[ColumnNumber, 7].Text;


                        if (IME.Hazardous.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() == null)
                        {
                            IME.Hazardous.Add(Hazardou);
                            AddedCounter++;
                        }
                        IME.SaveChanges();
                        Hazardou = new Hazardou();
                        ColumnNumber++;
                        ArticleNumb = ws.Cells[ColumnNumber, 3].Text;
                    }
                    MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                    return 1;
                    #endregion
                }
                catch { MessageBox.Show("This document does not proper to load here"); return 0; }
            }
            return 0;
        }

        public static int EntendedRangeRead()
        {
            //Excel Fast Load
            //try
            //{

            IMEEntities IME = new IMEEntities();
            //Excel Read

            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            Excel.Application excel = new Excel.Application();
            openFileDialog1.FileName = "*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Excel.Workbook theWorkbook = excel.Workbooks.Open(
                   openFileDialog1.FileName, 0, true, 5,
                    "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
                    0, true);
                Excel.Sheets sheets = theWorkbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
                //for (int i = 1; i <= 10; i++)
                //{
                Excel.Range last = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range range = worksheet.get_Range("A1", last);
                Array myvalues = range.Cells.Value;

                #region MyRegion
                //    bool isextendedRange = true;
                //Worksheet ws = theWorkbook.Worksheets[1];
                //if (((object[,])myvalues)[1, 1].ToString() != "ArticleNo") isextendedRange = false;
                //if (((object[,])myvalues)[1, 2].ToString() != "Manufacturer Code") isextendedRange = false;
                //if (((object[,])myvalues)[1, 3].ToString() != "Brand") isextendedRange = false;
                //if (((object[,])myvalues)[1, 4].ToString() != "MPN") isextendedRange = false;
                //if (((object[,])myvalues)[1, 5].ToString() != "ArticleDescription (40 Char Description)") isextendedRange = false;
                //if (((object[,])myvalues)[1, 6].ToString() != "Length") isextendedRange = false;
                //if (((object[,])myvalues)[1, 7].ToString() != "Width") isextendedRange = false;
                //if (((object[,])myvalues)[1, 8].ToString() != "Height") isextendedRange = false;
                //if (((object[,])myvalues)[1, 9].ToString() != "Dimension UoM") isextendedRange = false;
                //if (((object[,])myvalues)[1, 10].ToString() != "Weight") isextendedRange = false;
                //if (((object[,])myvalues)[1, 11].ToString() != "Weight UoM") isextendedRange = false;
                //if (((object[,])myvalues)[1, 12].ToString() != "CCCN") isextendedRange = false;
                //if (((object[,])myvalues)[1, 13].ToString() != "Country of Origin") isextendedRange = false;
                //if (((object[,])myvalues)[1, 14].ToString() != "Unit of Measure") isextendedRange = false;
                //if (((object[,])myvalues)[1, 15].ToString() != "Pack Size") isextendedRange = false;
                //if (((object[,])myvalues)[1, 16].ToString() != "(Sales UoM)") isextendedRange = false;
                //if (((object[,])myvalues)[1, 17].ToString() != "Cost price currency") isextendedRange = false;
                //if (((object[,])myvalues)[1, 18].ToString() != "Col1Price") isextendedRange = false;
                //if (((object[,])myvalues)[1, 19].ToString() != "Col1Break") isextendedRange = false;
                //if (((object[,])myvalues)[1, 20].ToString() != "Col2Price") isextendedRange = false;
                //if (((object[,])myvalues)[1, 21].ToString() != "Col2Break") isextendedRange = false;
                //if (((object[,])myvalues)[1, 22].ToString() != "Col3Price") isextendedRange = false;
                //if (((object[,])myvalues)[1, 23].ToString() != "Col3Break") isextendedRange = false;
                //if (((object[,])myvalues)[1, 24].ToString() != "Col4Price") isextendedRange = false;
                //if (((object[,])myvalues)[1, 25].ToString() != "Col4Break") isextendedRange = false;
                //if (((object[,])myvalues)[1, 26].ToString() != "Col5Price") isextendedRange = false;
                //if (((object[,])myvalues)[1, 27].ToString() != "Col5Break") isextendedRange = false;
                //if (((object[,])myvalues)[1, 28].ToString() != "DiscountedPrice1") isextendedRange = false;
                //if (((object[,])myvalues)[1, 29].ToString() != "DiscountedPrice2") isextendedRange = false;
                //if (((object[,])myvalues)[1, 30].ToString() != "DiscountedPrice3") isextendedRange = false;
                //if (((object[,])myvalues)[1, 31].ToString() != "DiscountedPrice4") isextendedRange = false;
                //if (((object[,])myvalues)[1, 32].ToString() != "DiscountedPrice5") isextendedRange = false;
                #endregion

                //if (isextendedRange)
                //{

                for (int i = 2; i <= (myvalues.Length / 32); i++)
                {

                    ExtendedRange extendedRange = new ExtendedRange();
                    //string[,] myvalues = null;
                    extendedRange.ArticleNo = ((object[,])myvalues)[i, 1].ToString();
                    if (((object[,])myvalues)[i, 2] != null) { extendedRange.ManufacturerCode = ((object[,])myvalues)[i, 2].ToString(); }
                    if (((object[,])myvalues)[i, 3] != null)
                    {
                        extendedRange.Brand = ((object[,])myvalues)[i, 3].ToString();
                    }
                    if (((object[,])myvalues)[i, 4] != null)
                    {
                        extendedRange.MPN = ((object[,])myvalues)[i, 4].ToString();
                    }
                    if (((object[,])myvalues)[i, 5] != null)
                    {
                        extendedRange.ArticleDescription = ((object[,])myvalues)[i, 5].ToString();
                    }

                    if (((object[,])myvalues)[i, 6] != null) { extendedRange.ExtendedRangeLength = Decimal.Parse(((object[,])myvalues)[i, 6].ToString()); }

                    if (((object[,])myvalues)[i, 7] != null) { extendedRange.Width = Decimal.Parse(((object[,])myvalues)[i, 7].ToString()); }

                    if (((object[,])myvalues)[i, 8] != null) { extendedRange.Height = Decimal.Parse(((object[,])myvalues)[i, 8].ToString()); }

                    if (((object[,])myvalues)[i, 9] != null)
                    {
                        extendedRange.DimensionUoM = ((object[,])myvalues)[i, 9].ToString();
                    }

                    if (((object[,])myvalues)[i, 10] != null)

                    {

                        extendedRange.ExtendedRangeWeight = decimal.Parse(((object[,])myvalues)[i, 10].ToString());


                    }

                    if (((object[,])myvalues)[i, 11] != null)
                    {
                        extendedRange.WeightUoM = ((object[,])myvalues)[i, 11].ToString();
                    }

                    if (((object[,])myvalues)[i, 12] != null)
                    {
                        extendedRange.CCCN = Int32.Parse(((object[,])myvalues)[i, 12].ToString());

                    }

                    if (((object[,])myvalues)[i, 13] != null)
                    {
                        extendedRange.CountryofOrigin = ((object[,])myvalues)[i, 13].ToString();
                    }
                    if (((object[,])myvalues)[i, 14] != null)
                    {
                        extendedRange.UnitofMeasure = ((object[,])myvalues)[i, 14].ToString();
                    }

                    if (((object[,])myvalues)[i, 15] != null) { extendedRange.PackSize = Int32.Parse(((object[,])myvalues)[i, 15].ToString()); }

                    if (((object[,])myvalues)[i, 16] != null) { extendedRange.SalesUoM = Int32.Parse(((object[,])myvalues)[i, 16].ToString()); }

                    if (((object[,])myvalues)[i, 17] != null)
                    {
                        extendedRange.CostPriceCurrency = ((object[,])myvalues)[i, 17].ToString();
                    }

                    if (((object[,])myvalues)[i, 18] != null) { extendedRange.Col1Price = Decimal.Parse(((object[,])myvalues)[i, 18].ToString()); }

                    if (((object[,])myvalues)[i, 20] != null) { extendedRange.Col2Price = Decimal.Parse(((object[,])myvalues)[i, 20].ToString()); }

                    if (((object[,])myvalues)[i, 22] != null) { extendedRange.Col3Price = Decimal.Parse(((object[,])myvalues)[i, 22].ToString()); }

                    if (((object[,])myvalues)[i, 24] != null) { extendedRange.Col4Price = Decimal.Parse(((object[,])myvalues)[i, 24].ToString()); }

                    if (((object[,])myvalues)[i, 26] != null) { extendedRange.Col5Price = Decimal.Parse(((object[,])myvalues)[i, 26].ToString()); }

                    if (((object[,])myvalues)[i, 19] != null) { extendedRange.Col1Break = Int32.Parse(((object[,])myvalues)[i, 19].ToString()); }

                    if (((object[,])myvalues)[i, 21] != null) { extendedRange.Col2Break = Int32.Parse(((object[,])myvalues)[i, 21].ToString()); }

                    if (((object[,])myvalues)[i, 23] != null) { extendedRange.Col3Break = Int32.Parse(((object[,])myvalues)[i, 23].ToString()); }

                    if (((object[,])myvalues)[i, 25] != null) { extendedRange.Col4Break = Int32.Parse(((object[,])myvalues)[i, 25].ToString()); }

                    if (((object[,])myvalues)[i, 27] != null) { extendedRange.Col5Break = Int32.Parse(((object[,])myvalues)[i, 27].ToString()); }
                    if (((object[,])myvalues)[i, 28] != null) { extendedRange.DiscountedPrice1 = Decimal.Parse(((object[,])myvalues)[i, 28].ToString()); }
                    if (((object[,])myvalues)[i, 29] != null) { extendedRange.DiscountedPrice2 = Decimal.Parse(((object[,])myvalues)[i, 29].ToString()); }
                    if (((object[,])myvalues)[i, 30] != null) { extendedRange.DiscountedPrice3 = Decimal.Parse(((object[,])myvalues)[i, 30].ToString()); }
                    if (((object[,])myvalues)[i, 31] != null) { extendedRange.DiscountedPrice4 = Decimal.Parse(((object[,])myvalues)[i, 31].ToString()); }
                    if (((object[,])myvalues)[i, 32] != null)
                    {
                        extendedRange.DiscountedPrice5 = Decimal.Parse(((object[,])myvalues)[i, 32].ToString());
                    }



                    IME.ExtendedRangeADD(
                        extendedRange.ArticleNo
       , extendedRange.Brand
       , extendedRange.MPN
       , extendedRange.ArticleDescription
       , extendedRange.ExtendedRangeLength
       , extendedRange.Width
       , extendedRange.Height
       , extendedRange.DimensionUoM
       , extendedRange.WeightUoM
       , extendedRange.CCCN
       , extendedRange.CountryofOrigin
       , extendedRange.UnitofMeasure
       , extendedRange.PackSize
       , extendedRange.SalesUoM
       , extendedRange.CostPriceCurrency
       , extendedRange.Col1Price
       , extendedRange.Col2Price
       , extendedRange.Col3Price
       , extendedRange.Col4Price
       , extendedRange.Col5Price
       , extendedRange.Col1Break
       , extendedRange.Col2Break
       , extendedRange.Col3Break
       , extendedRange.Col4Break
       , extendedRange.Col5Break
       , extendedRange.DiscountedPrice1
       , extendedRange.DiscountedPrice2
       , extendedRange.DiscountedPrice3
       , extendedRange.DiscountedPrice4
       , extendedRange.DiscountedPrice5
       , extendedRange.ManufacturerCode
       , extendedRange.ExtendedRangeWeight


                        );
                }

                //}
                //else
                //{
                //    for (int i = 2; i <= (myvalues.Length / 32); i++)
                //    {
                //        ExtendedRange extendedRange = new ExtendedRange();
                //        for (int j = 1; j < 32; j++)
                //        {

                //            switch (((object[,])myvalues)[1, j].ToString())
                //            {
                //                    case "ArticleNo":
                //                        extendedRange.ArticleNo = ((object[,])myvalues)[i, j].ToString();
                //                        break;
                //                    case "Manufacturer Code":
                //                        if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.ManufacturerCode = ((object[,])myvalues)[i, j].ToString(); }
                //        break;
                //                case "Brand":
                //                        if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") extendedRange.Brand = ((object[,])myvalues)[i, j].ToString();
                //        break;
                //                case "MPN":
                //                        if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") extendedRange.MPN = ((object[,])myvalues)[i, j].ToString();
                //        break;
                //                case "ArticleDescription (40 Char Description)":
                //                        if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "")extendedRange.ArticleDescription = ((object[,])myvalues)[i, j].ToString();
                //        break;
                //                case "Length":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.ExtendedRangeLength = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Width":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Width = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Height":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Height = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Dimension UoM":
                //                        if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "" ) extendedRange.DimensionUoM = ((object[,])myvalues)[i, j].ToString();
                //        break;
                //                case "Weight":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.ExtendedRangeWeight = decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Weight UoM":
                //                        if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") extendedRange.WeightUoM = ((object[,])myvalues)[i, j].ToString();
                //        break;
                //                case "CCCN":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.CCCN = Int32.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Country of Origin":
                //                        if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") extendedRange.CountryofOrigin = ((object[,])myvalues)[i, j].ToString();
                //        break;
                //                case "Unit of Measure":
                //                        if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") extendedRange.UnitofMeasure = ((object[,])myvalues)[i, j].ToString();
                //        break;
                //                case "Pack Size":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.PackSize = Int32.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "(Sales UoM)":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.SalesUoM = Int32.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Cost price currency":
                //                        if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") extendedRange.CostPriceCurrency = ((object[,])myvalues)[i, j].ToString();
                //        break;
                //                case "Col1Price":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col1Price = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Col2Price":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col2Price = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Col3Price":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col3Price = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Col4Price":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col4Price = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Col5Price":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col5Price = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Col1Break":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col1Break = Int32.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Col2Break":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col2Break = Int32.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Col3Break":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col3Break = Int32.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Col4Break":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col4Break = Int32.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "Col5Break":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.Col5Break = Int32.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "DiscountedPrice1":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.DiscountedPrice1 = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "DiscountedPrice2":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.DiscountedPrice2 = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "DiscountedPrice3":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.DiscountedPrice3 = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "DiscountedPrice4":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.DiscountedPrice4 = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "DiscountedPrice5":
                //                    if (((object[,])myvalues)[i, j] != null && ((object[,])myvalues)[i, j] != "") { extendedRange.DiscountedPrice5 = Decimal.Parse(((object[,])myvalues)[i, j].ToString()); }
                //        break;
                //                case "":
                //                    break;

                //    }


                //}
                //            IME.ExtendedRangeADD(
                //                   extendedRange.ArticleNo
                //  , extendedRange.Brand
                //  , extendedRange.MPN
                //  , extendedRange.ArticleDescription
                //  , extendedRange.ExtendedRangeLength
                //  , extendedRange.Width
                //  , extendedRange.Height
                //  , extendedRange.DimensionUoM
                //  , extendedRange.WeightUoM
                //  , extendedRange.CCCN
                //  , extendedRange.CountryofOrigin
                //  , extendedRange.UnitofMeasure
                //  , extendedRange.PackSize
                //  , extendedRange.SalesUoM
                //  , extendedRange.CostPriceCurrency
                //  , extendedRange.Col1Price
                //  , extendedRange.Col2Price
                //  , extendedRange.Col3Price
                //  , extendedRange.Col4Price
                //  , extendedRange.Col5Price
                //  , extendedRange.Col1Break
                //  , extendedRange.Col2Break
                //  , extendedRange.Col3Break
                //  , extendedRange.Col4Break
                //  , extendedRange.Col5Break
                //  , extendedRange.DiscountedPrice1
                //  , extendedRange.DiscountedPrice2
                //  , extendedRange.DiscountedPrice3
                //  , extendedRange.DiscountedPrice4
                //  , extendedRange.DiscountedPrice5
                //  , extendedRange.ManufacturerCode
                //  , extendedRange.ExtendedRangeWeight);
                //        }
                //}

                //}

            }


            //



            #region EntendedRangeReadOLD
            //IMEEntities IME = new IMEEntities();
            //int UptCounter = 0;
            //int AddedCounter = 0;
            ////Show the dialog and get result.
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "xlsx files (*.xlsx,*.xls)| *.xlsx;*.xls";
            //DialogResult result1 = openFileDialog1.ShowDialog();
            //if (result1 == DialogResult.OK)
            //{
            //    try
            //    {
            //        Excel.Application excel = new Excel.Application();
            //        Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
            //        Worksheet ws = wb.Worksheets[1];
            //        int ColumnNumber = 2;
            //
            //        while (ws.Cells[ColumnNumber - 1, 1].Text == "") { ColumnNumber++; }
            //        //
            //        //row sayısını bulan code
            //        int TotalRowNumber = ws.UsedRange.Rows.Count;




            //        List<string> Columns = new List<string>();
            //        int RowNumber = 1;
            //        //column ların isimlerini alıyor
            //        //COLUMNS
            //        bool isextendedRange = true;
            //        if (ws.Cells[1, 1].Text != "ArticleNo") isextendedRange = false;
            //        if (ws.Cells[1, 2].Text != "Manufacturer Code") isextendedRange = false;
            //        if (ws.Cells[1, 3].Text != "Brand") isextendedRange = false;
            //        if (ws.Cells[1, 4].Text != "MPN") isextendedRange = false;
            //        if (ws.Cells[1, 5].Text != "ArticleDescription (40 Char Description)") isextendedRange = false;
            //        if (ws.Cells[1, 6].Text != "Length") isextendedRange = false;
            //        if (ws.Cells[1, 7].Text != "Width") isextendedRange = false;
            //        if (ws.Cells[1, 8].Text != "Height") isextendedRange = false;
            //        if (ws.Cells[1, 9].Text != "Dimension UoM") isextendedRange = false;
            //        if (ws.Cells[1, 10].Text != "Weight") isextendedRange = false;
            //        if (ws.Cells[1, 11].Text != "Weight UoM") isextendedRange = false;
            //        if (ws.Cells[1, 12].Text != "CCCN") isextendedRange = false;
            //        if (ws.Cells[1, 13].Text != "Country of Origin") isextendedRange = false;
            //        if (ws.Cells[1, 14].Text != "Unit of Measure") isextendedRange = false;
            //        if (ws.Cells[1, 15].Text != "Pack Size") isextendedRange = false;
            //        if (ws.Cells[1, 16].Text != "(Sales UoM)") isextendedRange = false;
            //        if (ws.Cells[1, 17].Text != "Cost price currency") isextendedRange = false;
            //        if (ws.Cells[1, 18].Text != "Col1Price") isextendedRange = false;
            //        if (ws.Cells[1, 19].Text != "Col1Break") isextendedRange = false;
            //        if (ws.Cells[1, 20].Text != "Col2Price") isextendedRange = false;
            //        if (ws.Cells[1, 21].Text != "Col2Break") isextendedRange = false;
            //        if (ws.Cells[1, 22].Text != "Col3Price") isextendedRange = false;
            //        if (ws.Cells[1, 23].Text != "Col3Break") isextendedRange = false;
            //        if (ws.Cells[1, 24].Text != "Col4Price") isextendedRange = false;
            //        if (ws.Cells[1, 25].Text != "Col4Break") isextendedRange = false;
            //        if (ws.Cells[1, 26].Text != "Col5Price") isextendedRange = false;
            //        if (ws.Cells[1, 27].Text != "Col5Break") isextendedRange = false;
            //        if (ws.Cells[1, 28].Text != "DiscountedPrice1") isextendedRange = false;
            //        if (ws.Cells[1, 29].Text != "DiscountedPrice2") isextendedRange = false;
            //        if (ws.Cells[1, 30].Text != "DiscountedPrice3") isextendedRange = false;
            //        if (ws.Cells[1, 31].Text != "DiscountedPrice4") isextendedRange = false;
            //        if (ws.Cells[1, 32].Text != "DiscountedPrice5") isextendedRange = false;


            //        while (ws.Cells[ColumnNumber - 1, RowNumber].Text != "" || RowNumber < 33)
            //        {
            //            Columns.Add(ws.Cells[ColumnNumber - 1, RowNumber].Text);
            //            RowNumber++;
            //        }
            //        //
            //        string ArticleNumb = ws.Cells[ColumnNumber, 1].Text;



            //        if (!isextendedRange)
            //        {
            //            while (ArticleNumb != "")
            //            {
            //                ExtendedRange extendedRange = new ExtendedRange();
            //                //FILLER
            //                //Bu kod extendedranges için bir tane nesenyi dolduruyor
            //                int Rownb = 1;


            //                while (ws.Cells[ColumnNumber, Rownb].Text != "" || Rownb < (Columns.Count - 1))
            //                {
            //                    switch (Columns[Rownb - 1])
            //                    {
            //                        case "ArticleNo":
            //                            extendedRange.ArticleNo = ws.Cells[ColumnNumber, Rownb].Text;
            //                            break;
            //                        case "Manufacturer Code":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.ManufacturerCode = ws.Cells[ColumnNumber, Rownb].Text; }
            //                            break;
            //                        case "Brand":
            //                            extendedRange.Brand = ws.Cells[ColumnNumber, Rownb].Text;
            //                            break;
            //                        case "MPN":
            //                            extendedRange.MPN = ws.Cells[ColumnNumber, Rownb].Text;
            //                            break;
            //                        case "ArticleDescription (40 Char Description)":
            //                            extendedRange.ArticleDescription = ws.Cells[ColumnNumber, Rownb].Text;
            //                            break;
            //                        case "Length":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.ExtendedRangeLength = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Width":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Width = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Height":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Height = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Dimension UoM":
            //                            extendedRange.DimensionUoM = ws.Cells[ColumnNumber, Rownb].Text;
            //                            break;
            //                        case "Weight":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.ExtendedRangeWeight = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Weight UoM":
            //                            extendedRange.WeightUoM = ws.Cells[ColumnNumber, Rownb].Text;
            //                            break;
            //                        case "CCCN":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.CCCN = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Country of Origin":
            //                            extendedRange.CountryofOrigin = ws.Cells[ColumnNumber, Rownb].Text;
            //                            break;
            //                        case "Unit of Measure":
            //                            extendedRange.UnitofMeasure = ws.Cells[ColumnNumber, Rownb].Text;
            //                            break;
            //                        case "Pack Size":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.PackSize = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "(Sales UoM)":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.SalesUoM = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Cost price currency":
            //                            extendedRange.CostPriceCurrency = ws.Cells[ColumnNumber, Rownb].Text;
            //                            break;
            //                        case "Col1Price":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col1Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Col2Price":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col2Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Col3Price":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col3Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Col4Price":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col4Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Col5Price":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col5Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Col1Break":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col1Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Col2Break":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col2Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Col3Break":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col3Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Col4Break":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col4Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "Col5Break":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col5Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "DiscountedPrice1":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice1 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "DiscountedPrice2":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice2 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "DiscountedPrice3":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice3 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "DiscountedPrice4":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice4 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "DiscountedPrice5":
            //                            if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice5 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
            //                            break;
            //                        case "":
            //                            break;
            //                    }
            //                    Rownb++;
            //                }
            //                //Yeni bir dosya eklemek için

            //                IME.ExtendedRangeADD(

            //                    extendedRange.ArticleNo
            //   , extendedRange.Brand
            //   , extendedRange.MPN
            //   , extendedRange.ArticleDescription
            //   , extendedRange.ExtendedRangeLength
            //   , extendedRange.Width
            //   , extendedRange.Height
            //   , extendedRange.DimensionUoM
            //   , extendedRange.WeightUoM
            //   , extendedRange.CCCN
            //   , extendedRange.CountryofOrigin
            //   , extendedRange.UnitofMeasure
            //   , extendedRange.PackSize
            //   , extendedRange.SalesUoM
            //   , extendedRange.CostPriceCurrency
            //   , extendedRange.Col1Price
            //   , extendedRange.Col2Price
            //   , extendedRange.Col3Price
            //   , extendedRange.Col4Price
            //   , extendedRange.Col5Price
            //   , extendedRange.Col1Break
            //   , extendedRange.Col2Break
            //   , extendedRange.Col3Break
            //   , extendedRange.Col4Break
            //   , extendedRange.Col5Break
            //   , extendedRange.DiscountedPrice1
            //   , extendedRange.DiscountedPrice2
            //   , extendedRange.DiscountedPrice3
            //   , extendedRange.DiscountedPrice4
            //   , extendedRange.DiscountedPrice5
            //   , extendedRange.ManufacturerCode
            //   , extendedRange.ExtendedRangeWeight


            //                    );


            //                extendedRange = new ExtendedRange();
            //                ColumnNumber++;
            //                ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
            //            }
            //        }
            //        else
            //        {
            //            ExtendedRange extendedRange = new ExtendedRange();
            //            //FILLER
            //            //Bu kod extendedranges için bir tane nesenyi dolduruyor
            //            int Rownb = 1;


            //            while (ws.Cells[ColumnNumber, 1].Text != "")
            //            {


            //                        extendedRange.ArticleNo = ws.Cells[ColumnNumber, 1].Text;
            //                        if (ws.Cells[ColumnNumber, 2].Text != "") { extendedRange.ManufacturerCode = ws.Cells[ColumnNumber, 2].Text; }
            //                        extendedRange.Brand = ws.Cells[ColumnNumber, 3].Text;
            //                        extendedRange.MPN = ws.Cells[ColumnNumber, 4].Text;
            //                        extendedRange.ArticleDescription = ws.Cells[ColumnNumber, 5].Text;

            //                        if (ws.Cells[ColumnNumber, 6].Text != "") { extendedRange.ExtendedRangeLength = Decimal.Parse(ws.Cells[ColumnNumber, 6].Text); }

            //                        if (ws.Cells[ColumnNumber, 7].Text != "") { extendedRange.Width = Decimal.Parse(ws.Cells[ColumnNumber, 7].Text); }

            //                        if (ws.Cells[ColumnNumber, 8].Text != "") { extendedRange.Height = Decimal.Parse(ws.Cells[ColumnNumber, 8].Text); }

            //                        extendedRange.DimensionUoM = ws.Cells[ColumnNumber, 9].Text;

            //                        if (ws.Cells[ColumnNumber, 10].Text != "") { extendedRange.ExtendedRangeWeight = Decimal.Parse(ws.Cells[ColumnNumber, 10].Text); }

            //                        extendedRange.WeightUoM = ws.Cells[ColumnNumber, 11].Text;

            //                        if (ws.Cells[ColumnNumber, 12].Text != "") { extendedRange.CCCN = Int32.Parse(ws.Cells[ColumnNumber, 12].Text); }

            //                        extendedRange.CountryofOrigin = ws.Cells[ColumnNumber, 13].Text;
            //                        extendedRange.UnitofMeasure = ws.Cells[ColumnNumber, 14].Text;

            //                        if (ws.Cells[ColumnNumber, 15].Text != "") { extendedRange.PackSize = Int32.Parse(ws.Cells[ColumnNumber, 15].Text); }

            //                        if (ws.Cells[ColumnNumber, 16].Text != "") { extendedRange.SalesUoM = Int32.Parse(ws.Cells[ColumnNumber, 16].Text); }

            //                        extendedRange.CostPriceCurrency = ws.Cells[ColumnNumber, 17].Text;

            //                        if (ws.Cells[ColumnNumber, 18].Text != "") { extendedRange.Col1Price = Decimal.Parse(ws.Cells[ColumnNumber, 18].Text); }

            //                        if (ws.Cells[ColumnNumber, 19].Text != "") { extendedRange.Col2Price = Decimal.Parse(ws.Cells[ColumnNumber, 19].Text); }

            //                        if (ws.Cells[ColumnNumber, 20].Text != "") { extendedRange.Col3Price = Decimal.Parse(ws.Cells[ColumnNumber, 20].Text); }

            //                        if (ws.Cells[ColumnNumber, 21].Text != "") { extendedRange.Col4Price = Decimal.Parse(ws.Cells[ColumnNumber, 21].Text); }

            //                        if (ws.Cells[ColumnNumber, 22].Text != "") { extendedRange.Col5Price = Decimal.Parse(ws.Cells[ColumnNumber, 22].Text); }

            //                        if (ws.Cells[ColumnNumber, 23].Text != "") { extendedRange.Col1Break = Int32.Parse(ws.Cells[ColumnNumber, 23].Text); }

            //                        if (ws.Cells[ColumnNumber, 24].Text != "") { extendedRange.Col2Break = Int32.Parse(ws.Cells[ColumnNumber, 24].Text); }

            //                        if (ws.Cells[ColumnNumber, 25].Text != "") { extendedRange.Col3Break = Int32.Parse(ws.Cells[ColumnNumber, 25].Text); }

            //                        if (ws.Cells[ColumnNumber, 26].Text != "") { extendedRange.Col4Break = Int32.Parse(ws.Cells[ColumnNumber, 26].Text); }

            //                        if (ws.Cells[ColumnNumber, 27].Text != "") { extendedRange.Col5Break = Int32.Parse(ws.Cells[ColumnNumber, 27].Text); }
            //                        if (ws.Cells[ColumnNumber, 28].Text != "") { extendedRange.DiscountedPrice1 = Decimal.Parse(ws.Cells[ColumnNumber, 28].Text); }
            //                        if (ws.Cells[ColumnNumber, 29].Text != "") { extendedRange.DiscountedPrice2 = Decimal.Parse(ws.Cells[ColumnNumber, 29].Text); }
            //                        if (ws.Cells[ColumnNumber, 30].Text != "") { extendedRange.DiscountedPrice3 = Decimal.Parse(ws.Cells[ColumnNumber, 30].Text); }
            //                        if (ws.Cells[ColumnNumber, 31].Text != "") { extendedRange.DiscountedPrice4 = Decimal.Parse(ws.Cells[ColumnNumber, 31].Text); }
            //                        if (ws.Cells[ColumnNumber, 32].Text != "") { extendedRange.DiscountedPrice5 = Decimal.Parse(ws.Cells[ColumnNumber, 32].Text); }



            //                //Yeni bir dosya eklemek için

            //                IME.ExtendedRangeADD(

            //                    extendedRange.ArticleNo
            //   , extendedRange.Brand
            //   , extendedRange.MPN
            //   , extendedRange.ArticleDescription
            //   , extendedRange.ExtendedRangeLength
            //   , extendedRange.Width
            //   , extendedRange.Height
            //   , extendedRange.DimensionUoM
            //   , extendedRange.WeightUoM
            //   , extendedRange.CCCN
            //   , extendedRange.CountryofOrigin
            //   , extendedRange.UnitofMeasure
            //   , extendedRange.PackSize
            //   , extendedRange.SalesUoM
            //   , extendedRange.CostPriceCurrency
            //   , extendedRange.Col1Price
            //   , extendedRange.Col2Price
            //   , extendedRange.Col3Price
            //   , extendedRange.Col4Price
            //   , extendedRange.Col5Price
            //   , extendedRange.Col1Break
            //   , extendedRange.Col2Break
            //   , extendedRange.Col3Break
            //   , extendedRange.Col4Break
            //   , extendedRange.Col5Break
            //   , extendedRange.DiscountedPrice1
            //   , extendedRange.DiscountedPrice2
            //   , extendedRange.DiscountedPrice3
            //   , extendedRange.DiscountedPrice4
            //   , extendedRange.DiscountedPrice5
            //   , extendedRange.ManufacturerCode
            //   , extendedRange.ExtendedRangeWeight


            //                    );


            //                extendedRange = new ExtendedRange();
            //                ColumnNumber++;
            //                ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
            //            }
            //        }

            //        MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
            #endregion


            return 1;
            //}
            //catch { MessageBox.Show("This document does not proper to load here"); return 0; }
        }

        public static int RSProRead()
        {
            #region RSPro
            IMEEntities IME = new IMEEntities();
            int UptCounter = 0;
            int AddedCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xlsx files (*.xlsx,*.xls)| *.xlsx;*.xls";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                try
                {
                    Excel.Application excel = new Excel.Application();
                    Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                    Worksheet ws = wb.Worksheets[1];
                    int ColumnNumber = 2;
                    //verilerin bşaldığı yeri bulan kısım
                    while (ws.Cells[ColumnNumber - 1, 1].Text == "") { ColumnNumber++; }
                    //
                    //row sayısını bulan code
                    int TotalRowNumber = ws.UsedRange.Rows.Count;
                    List<string> Columns = new List<string>();
                    int RowNumber = 1;
                    //column ların isimlerini alıyor
                    //COLUMNS

                    while (ws.Cells[ColumnNumber - 1, RowNumber].Text != "" || ws.Cells[ColumnNumber, RowNumber].Text != "")
                    {
                        if (RowNumber < 2) { Columns.Add(ws.Cells[ColumnNumber - 1, RowNumber].Text); } else { Columns.Add(ws.Cells[ColumnNumber - 2, RowNumber].Text); }
                        RowNumber++;
                    }
                    //
                    string ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                    while (ArticleNumb != "")
                    {

                        RSPro RSPro = new RSPro();
                        if (IME.RSProes.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() != null)
                        {
                            //UPDATE
                            RSPro = IME.RSProes.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault();

                        }

                        //FILLER
                        //Bu kod extendedranges için bir tane nesenyi dolduruyor
                        int Rownb = 1;
                        while (ws.Cells[ColumnNumber, Rownb].Text != "" || Rownb < Columns.Count - 1)
                        {
                            switch (Columns[Rownb - 1])
                            {
                                case "Article":
                                    RSPro.ArticleNo = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Description":
                                    RSPro.RsProDesc = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Width":
                                    RSPro.Width = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Gross Weight":
                                    RSPro.GrossWeight = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Height":
                                    RSPro.Height = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Length":
                                    RSPro.Lenght = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Volume":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { RSPro.Volume = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "":
                                    if (RSPro.RsProDesc != "") { RSPro.RsProDesc = ws.Cells[ColumnNumber, Rownb].Text; }
                                    break;
                            }
                            Rownb++;

                        }
                        //Yeni bir dosya eklemek için
                        if (IME.RSProes.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() == null)
                        {
                            IME.RSProes.Add(RSPro);
                            AddedCounter++;
                        }
                        else { UptCounter++; }

                        IME.SaveChanges();
                        RSPro = new RSPro();
                        ColumnNumber++;
                        ArticleNumb = ws.Cells[ColumnNumber, 1].Text;

                        MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                        #endregion
                        return 1;
                    }
                }
                catch { MessageBox.Show("This document does not proper to load here"); return 0; }
            }
            return 0;
        }

        public static int excelCustomerCountry()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[7];
                int ColumnNumber = 2;
                string ArticleNumb = ws.Cells[2, 10].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 10].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 10].Text;
                    if (IME.Countries.Where(a => a.Country_name == ArticleNumb).FirstOrDefault() == null)
                    {
                        Country country = new Country();

                        country.Country_name = ArticleNumb.Trim();
                        IME.Countries.Add(country);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerCity()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[1];
                int ColumnNumber = 3;
                string ArticleNumb = ws.Cells[3, 24].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 1].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 25].Text;
                    if (IME.Cities.Where(a => a.City_name == ArticleNumb).FirstOrDefault() == null && ArticleNumb != null)
                    {
                        City city = new City();
                        city.City_name = ArticleNumb;
                        string Countryname = ws.Cells[ColumnNumber, 24].Text;
                        Country c = IME.Countries.Where(a => a.Country_name == Countryname).FirstOrDefault();
                        int countryID = c.ID;
                        city.CountryID = countryID;
                        IME.Cities.Add(city);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerTown1()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[1];
                int ColumnNumber = 3;
                string ArticleNumb = ws.Cells[3, 26].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 1].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 26].Text;
                    if (IME.Towns.Where(a => a.Town_name == ArticleNumb).ToList().Count == 0 && ArticleNumb != null)
                    {
                        Town town = new Town();
                        town.Town_name = ArticleNumb;
                        string Countryname = ws.Cells[ColumnNumber, 25].Text;
                        City c = IME.Cities.Where(a => a.City_name == Countryname).FirstOrDefault();
                        int cityID = c.ID;
                        town.CityID = cityID;
                        IME.Towns.Add(town);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerTown()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[6];
                int ColumnNumber = 2;
                string ArticleNumb = ws.Cells[2, 2].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 2].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 2].Text;
                    if (IME.Towns.Where(a => a.Town_name == ArticleNumb).ToList().Count == 0 && ArticleNumb != null)
                    {
                        Town town = new Town();
                        town.Town_name = ArticleNumb;
                        string Countryname = ws.Cells[ColumnNumber, 1].Text;
                        City c = IME.Cities.Where(a => a.City_name == Countryname).FirstOrDefault();

                        if (c == null)
                        {
                            Countryname = Countryname.ToUpper();
                            c = IME.Cities.Where(a => a.City_name == Countryname).FirstOrDefault();
                        }

                        int cityID = c.ID;
                        town.CityID = cityID;
                        IME.Towns.Add(town);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerTitle()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[2];
                int ColumnNumber = 2;
                string ArticleNumb = ws.Cells[2, 1].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 1].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                    if (IME.CustomerTitles.Where(a => a.titlename == ArticleNumb).FirstOrDefault() == null && ArticleNumb != null)
                    {
                        CustomerTitle town = new CustomerTitle();
                        town.titlename = ArticleNumb;
                        string Countryname = ws.Cells[ColumnNumber, 1].Text;
                        City c = IME.Cities.Where(a => a.City_name == Countryname).FirstOrDefault();
                        IME.CustomerTitles.Add(town);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerDepartment()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[2];
                int ColumnNumber = 2;
                string ArticleNumb = ws.Cells[2, 3].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 3].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                    if (IME.CustomerDepartments.Where(a => a.departmentname == ArticleNumb).FirstOrDefault() == null && ArticleNumb != null)
                    {
                        CustomerDepartment town = new CustomerDepartment();
                        town.departmentname = ArticleNumb;
                        string Countryname = ws.Cells[ColumnNumber, 1].Text;
                        CustomerDepartment c = IME.CustomerDepartments.Where(a => a.departmentname == Countryname).FirstOrDefault();
                        IME.CustomerDepartments.Add(town);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerCategory()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[4];
                int ColumnNumber = 2;
                string ArticleNumb = ws.Cells[1, 1].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 1].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                    if (IME.CustomerDepartments.Where(a => a.departmentname == ArticleNumb).FirstOrDefault() == null && ArticleNumb != null)
                    {
                        CustomerCategory town = new CustomerCategory();
                        town.categoryname = ArticleNumb;
                        string Countryname = ws.Cells[ColumnNumber, 1].Text;
                        CustomerCategory c = IME.CustomerCategories.Where(a => a.categoryname == Countryname).FirstOrDefault();
                        IME.CustomerCategories.Add(town);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerCategory1()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[1];
                int ColumnNumber = 3;
                string ArticleNumb = ws.Cells[3, 3].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 1].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 3].Text;
                    if (IME.CustomerCategories.Where(a => a.categoryname == ArticleNumb).FirstOrDefault() == null && ArticleNumb != null)
                    {
                        CustomerCategory town = new CustomerCategory();
                        town.categoryname = ArticleNumb;
                        string Countryname = ws.Cells[ColumnNumber, 3].Text;
                        IME.CustomerCategories.Add(town);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerSubCategory()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[1];
                int ColumnNumber = 3;
                string ArticleNumb = ws.Cells[3, 1].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 1].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 4].Text;
                    if (IME.CustomerSubCategories.Where(a => a.subcategoryname == ArticleNumb).FirstOrDefault() == null && ArticleNumb != null)
                    {
                        DataSet.CustomerSubCategory town = new DataSet.CustomerSubCategory();
                        town.subcategoryname = ArticleNumb;
                        string Countryname = ws.Cells[ColumnNumber, 1].Text;
                        CustomerCategory c = IME.CustomerCategories.Where(a => a.categoryname == Countryname).FirstOrDefault();
                        if (c != null) town.categoryID = c.ID;
                        IME.CustomerSubCategories.Add(town);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerWorker()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[1];
                int ColumnNumber = 3;
                string Worker = ws.Cells[3, 6].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 1].Text) != "")
                {
                    Worker = ws.Cells[ColumnNumber, 6].Text;
                    if (IME.Workers.Where(a => a.NameLastName == Worker).FirstOrDefault() == null)
                    {
                        Worker w = new Worker();
                        w.NameLastName = Worker;
                        w.UserName = Worker;
                        w.UserPass = Worker;
                        IME.Workers.Add(w);
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int excelCustomerLoader_CategorySubCategotyAndWorker()
        {
            IMEEntities IME = new IMEEntities();

            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[1];
                int ColumnNumber = 3;
                string ArticleNumb = ws.Cells[3, 1].Text;
                #region DiscontinuedList
                while ((ws.Cells[ColumnNumber, 1].Text) != "")
                {
                    ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                    string subcategory;
                    subcategory = ws.Cells[ColumnNumber, 4].Text;
                    string category;
                    category = ws.Cells[ColumnNumber, 3].Text;
                    string worker;
                    worker = ws.Cells[ColumnNumber, 6].Text;
                    Customer c = IME.Customers.Where(a => a.ID == ArticleNumb).FirstOrDefault();
                    if (c != null)
                    {
                        if (category != null) { c.categoryID = IME.CustomerCategories.Where(a => a.categoryname == category).FirstOrDefault().ID; }
                        if (subcategory != null) { c.subcategoryID = IME.CustomerSubCategories.Where(a => a.subcategoryname == subcategory).FirstOrDefault().ID; }
                        if (worker != null && worker != "-") c.representaryID = IME.Workers.Where(a => a.NameLastName == worker).FirstOrDefault().WorkerID;
                        IME.SaveChanges();
                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                return 1;
                #endregion

            }
            return 0;

        }

        public static int createNOTE(string column)
        {
            IMEEntities IME = new IMEEntities();
            int noteID = 0;

            Note n = new Note();
            n.Note_name = column;
            IME.Notes.Add(n);
            IME.SaveChanges();
            return n.ID;
        }

        public static void excelCustomerLoader()
        {
            IMEEntities IME = new IMEEntities();
            int AddedCounter = 0;
            int UptCounter = 0;
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {

                Excel.Application excel = new Excel.Application();
                Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
                Worksheet ws = wb.Worksheets[1];

                //CUSTOMER LOADER
                int ColumnNumber = 3;
                while ((ws.Cells[ColumnNumber, 1].Text) != "")
                {
                    string CustomerCode = ws.Cells[ColumnNumber, 1].Text;
                    if (IME.Customers.Where(a => a.ID == CustomerCode).ToList().Count == 0)
                    {
                        int noteID = 0;
                        if (ws.Cells[ColumnNumber, 11].Text != "")
                        {
                            string notestring = ws.Cells[ColumnNumber, 11].Text;
                            noteID = createNOTE(notestring);
                        }
                        Customer c = new Customer();
                        c.ID = ws.Cells[ColumnNumber, 1].Text;
                        if (noteID != 0) c.customerNoteID = noteID;
                        c.c_name = ws.Cells[ColumnNumber, 2].Text;
                        string categoryname = null;
                        string subcategoryname = null;
                        if (ws.Cells[ColumnNumber, 3].Text == null) categoryname = ws.Cells[ColumnNumber, 3].Text;
                        if (ws.Cells[ColumnNumber, 4].Text == null) subcategoryname = ws.Cells[ColumnNumber, 4].Text;
                        //if (categoryname != null && subcategoryname==null)
                        //{
                        //    CustomerCategorySubCategory c1 = new CustomerCategorySubCategory();
                        //    c1.customerID = c.ID;
                        //    c1.categoryID= IME.CustomerCategories.Where(a => a.categoryname == categoryname).FirstOrDefault().ID;
                        //    IME.CustomerCategorySubCategories.Add(c1);
                        //    IME.SaveChanges();

                        //}
                        //if (categoryname != null && subcategoryname != null)
                        //{
                        //    CustomerCategorySubCategory c1 = new CustomerCategorySubCategory();
                        //    c1.customerID = c.ID;
                        //    c1.subcategoryID = IME.CustomerSubCategories.Where(a => a.subcategoryname == subcategoryname).FirstOrDefault().ID;
                        //    c1.categoryID = IME.CustomerCategories.Where(a => a.categoryname == categoryname).FirstOrDefault().ID;
                        //    IME.CustomerCategorySubCategories.Add(c1);
                        //    IME.SaveChanges();
                        //}
                        if (ws.Cells[ColumnNumber, 7].Text == "Active") { c.isactive = 1; } else { c.isactive = 0; }

                        c.telephone = ws.Cells[ColumnNumber, 8].Text;
                        c.fax = ws.Cells[ColumnNumber, 9].Text;

                        string termName = ws.Cells[ColumnNumber, 15].Text;
                        if (termName != null && IME.PaymentTerms.Where(a => a.term_name.Trim() == termName.Trim()).FirstOrDefault() != null)
                        {
                            c.payment_termID = Int32.Parse(IME.PaymentTerms.Where(a => a.term_name.Trim() == termName.Trim()).FirstOrDefault().ID.ToString());
                        }
                        c.factor = Decimal.Parse(ws.Cells[ColumnNumber, 18].Text);
                        string customercreditstring = ws.Cells[ColumnNumber, 19].Text;
                        customercreditstring = customercreditstring.Replace(",", "");
                        if (customercreditstring.Trim() != "-") c.creditlimit = Int32.Parse(customercreditstring);
                        if (ws.Cells[ColumnNumber, 22].Text != null) c.creditDay = Int32.Parse(ws.Cells[ColumnNumber, 22].Text);
                        c.CreateDate = DateTime.Today;
                        IME.Customers.Add(c);
                        IME.SaveChanges();


                        //CONTACT
                        CustomerWorker cw = new CustomerWorker();
                        cw.cw_name = ws.Cells[ColumnNumber, 32].Text;
                        cw.phone = ws.Cells[ColumnNumber, 34].Text;
                        string languagename;
                        if (ws.Cells[ColumnNumber, 38].Text != "")
                        {
                            cw.languageID = 3;
                        }
                        cw.customerID = c.ID;
                        IME.CustomerWorkers.Add(cw);
                        IME.SaveChanges();
                        //

                        //ADDRESS
                        CustomerAddress ca = new CustomerAddress();
                        string countryname;
                        if (ws.Cells[ColumnNumber, 24].Text != null)
                        {
                            countryname = ws.Cells[ColumnNumber, 24].Text;
                            ca.CountryID = IME.Countries.Where(a => a.Country_name.Trim() == countryname.Trim()).FirstOrDefault().ID;
                        }
                        string Cityname;
                        Cityname = ws.Cells[ColumnNumber, 25].Text;
                        if (Cityname != null)
                        {
                            ca.CityID = IME.Cities.Where(a => a.City_name == Cityname).FirstOrDefault().ID;
                        }
                        string Townname;
                        Townname = ws.Cells[ColumnNumber, 26].Text;
                        if (Townname != null)
                        {
                            ca.TownID = IME.Towns.Where(a => a.Town_name == Townname).FirstOrDefault().ID;
                        }
                        ca.PostCode = ws.Cells[ColumnNumber, 27].Text;
                        if (ws.Cells[ColumnNumber, 28].Text != "0") ca.AdressDetails = ws.Cells[ColumnNumber, 28].Text;
                        ca.CustomerID = c.ID;
                        IME.CustomerAddresses.Add(ca);
                        IME.SaveChanges();
                        //

                        AddedCounter++;
                    }
                    ColumnNumber++;
                }
                //
            }

        }

        public static void QuotationMaster()
        {
            IMEEntities IME = new IMEEntities();
            Excel.Application excel = new Excel.Application();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                Excel.Workbook theWorkbook = excel.Workbooks.Open(
                   openFileDialog1.FileName, 0, true, 5,
                    "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
                    0, true);
                Excel.Sheets sheets = theWorkbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
                //for (int i = 1; i <= 10; i++)
                //{
                Excel.Range last = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range range = worksheet.get_Range("A1", last);
                Array myvalues = range.Cells.Value;


                //Quotation Master
                int ColumnNumber = 2;
                for (int i = 2; i <= (myvalues.Length / 32); i++)
                {

                    Quotation q = new Quotation();
                    //string[,] myvalues = null;
                    if (((object[,])myvalues)[i, 1] != null) { q.QuotationNo = ((object[,])myvalues)[i, 1].ToString(); }
                    if (((object[,])myvalues)[i, 2] != null) { q.StartDate = (DateTime)(Convert.ToDateTime(((object[,])myvalues)[i, 2].ToString())); }
                    //if (((object[,])myvalues)[i, 3] != null)
                    //{
                    //    q.Brand = ((object[,])myvalues)[i, 3].ToString();
                    //}
                    if (((object[,])myvalues)[i, 4] != null)
                    {
                        q.CustomerID = ((object[,])myvalues)[i, 4].ToString();
                    }
                    //if (((object[,])myvalues)[i, 5] != null)
                    //{
                    //    q.ArticleDescription = ((object[,])myvalues)[i, 5].ToString();
                    //}

                    //if (((object[,])myvalues)[i, 6] != null) { q.qLength = Decimal.Parse(((object[,])myvalues)[i, 6].ToString()); }

                    //if (((object[,])myvalues)[i, 7] != null) { q.DelivertDate = Convert.ToDateTime(((object[,])myvalues)[i, 7].ToString()); }

                    //if (((object[,])myvalues)[i, 8] != null) { q.Height = Decimal.Parse(((object[,])myvalues)[i, 8].ToString()); }

                    //if (((object[,])myvalues)[i, 9] != null)
                    //{
                    //    q.DimensionUoM = ((object[,])myvalues)[i, 9].ToString();
                    //}

                    //if (((object[,])myvalues)[i, 10] != null) { q.qWeight = Decimal.Parse(((object[,])myvalues)[i, 10].ToString()); }

                    //if (((object[,])myvalues)[i, 11] != null)
                    //{
                    //    q.WeightUoM = ((object[,])myvalues)[i, 11].ToString();
                    //}

                    //if (((object[,])myvalues)[i, 12] != null) { q.CCCN = Int32.Parse(((object[,])myvalues)[i, 12].ToString()); }

                    //if (((object[,])myvalues)[i, 13] != null)
                    //{
                    //    q.CountryofOrigin = ((object[,])myvalues)[i, 13].ToString();
                    //}
                    //if (((object[,])myvalues)[i, 14] != null)
                    //{
                    //    q.UnitofMeasure = ((object[,])myvalues)[i, 14].ToString();
                    //}q.grosstotal

                    //if (((object[,])myvalues)[i, 15] != null) { q.PackSize = Int32.Parse(((object[,])myvalues)[i, 15].ToString()); }

                    if (((object[,])myvalues)[i, 16] != null) { q.DiscOnSubTotal2 = decimal.Parse(((object[,])myvalues)[i, 16].ToString()); }

                    if (((object[,])myvalues)[i, 17] != null)
                    {
                        q.RepresentativeID = IME.Workers.Where(a => a.UserName == (((object[,])myvalues)[i, 17].ToString())).FirstOrDefault().WorkerID;
                    }

                    //if (((object[,])myvalues)[i, 18] != null) { q.Col1Price = Decimal.Parse(((object[,])myvalues)[i, 18].ToString()); }

                    //if (((object[,])myvalues)[i, 20] != null) { q.Col2Price = Decimal.Parse(((object[,])myvalues)[i, 20].ToString()); }

                    //if (((object[,])myvalues)[i, 22] != null) { q.Col3Price = Decimal.Parse(((object[,])myvalues)[i, 22].ToString()); }

                    //if (((object[,])myvalues)[i, 24] != null) { q.Col4Price = Decimal.Parse(((object[,])myvalues)[i, 24].ToString()); }

                    //if (((object[,])myvalues)[i, 26] != null) { q.Col5Price = Decimal.Parse(((object[,])myvalues)[i, 26].ToString()); }

                    //if (((object[,])myvalues)[i, 19] != null) { q.Col1Break = Int32.Parse(((object[,])myvalues)[i, 19].ToString()); }

                    //if (((object[,])myvalues)[i, 21] != null) { q.Col2Break = Int32.Parse(((object[,])myvalues)[i, 21].ToString()); }

                    //if (((object[,])myvalues)[i, 23] != null) { q.Col3Break = Int32.Parse(((object[,])myvalues)[i, 23].ToString()); }

                    //if (((object[,])myvalues)[i, 25] != null) { q.Col4Break = Int32.Parse(((object[,])myvalues)[i, 25].ToString()); }

                    //if (((object[,])myvalues)[i, 27] != null) { q.Col5Break = Int32.Parse(((object[,])myvalues)[i, 27].ToString()); }
                    //if (((object[,])myvalues)[i, 28] != null) { q.DiscountedPrice1 = Decimal.Parse(((object[,])myvalues)[i, 28].ToString()); }
                    //if (((object[,])myvalues)[i, 29] != null) { q.DiscountedPrice2 = Decimal.Parse(((object[,])myvalues)[i, 29].ToString()); }

                


                    //IME.QuotationADD(
                    //    q.CustomerID,
                    //    q.NoteForUsID,
                    //    q.NoteForCustomerID,
                    //    q.ForFinancelIsTrue,
                    //    q.ShippingMethodID,
                    //    q.IsItemCost,
                    //    q.IsWeightCost,
                    //    q.IsCustomsDuties,
                    //    q.DiscOnSubTotal2,
                    //    q.ExtraCharges,
                    //    q.SubTotal,
                    //    q.StartDate,
                    //    q.ValidationDay,
                    //    q.PaymentID,
                    //    q.Curr,
                    //    q.Factor,
                    //    q.IsVatValue,
                    //    q.VatValue,
                    //    q.CurrName,
                    //    q.QuotationNo,
                    //    q.RFQNo,
                    //    q.CurrType,
                    //    q.QuotationMainContact,
                    //    q.approved,
                    //    q.SaleOrderID,
                    //    q.voucherNo,
                    //    q.RepresentativeID,
                    //    q.RepresentativeID2,
                    //    q.ExchangeRateID,
                    //    q.DeliveryDate,
                    //    q.GrossTotal
                    //    );
                }

            }
        }

        public static void QuotationDetail()
        {
            IMEEntities IME = new IMEEntities();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.xlsx)|*.xlsx";
            Excel.Application excel = new Excel.Application();
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                Excel.Workbook theWorkbook = excel.Workbooks.Open(
                   openFileDialog1.FileName, 0, true, 5,
                    "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
                    0, true);
                Excel.Sheets sheets = theWorkbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
                //for (int i = 1; i <= 10; i++)
                //{
                Excel.Range last = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range range = worksheet.get_Range("A1", last);
                Array myvalues = range.Cells.Value;


                //Quotation Master
                int ColumnNumber = 2;
                for (int i = 2; i <= (myvalues.Length / 32); i++)
                {

                    QuotationDetail q = new QuotationDetail();
                    //string[,] myvalues = null;
                    if (((object[,])myvalues)[i, 1] != null) { q.QuotationNo = ((object[,])myvalues)[i, 1].ToString(); }
                    //if (((object[,])myvalues)[i, 2] != null) { q. = (DateTime)(Convert.ToDateTime(((object[,])myvalues)[i, 2].ToString())); }
                    if (((object[,])myvalues)[i, 3] != null)
                    {
                        q.QuotationNo = ((object[,])myvalues)[i, 3].ToString();
                    }
                    if (((object[,])myvalues)[i, 4] != null)
                    {
                        q.ItemCode = ((object[,])myvalues)[i, 4].ToString();
                    }
                    if (((object[,])myvalues)[i, 5] != null)
                    {
                        q.Qty = Convert.ToInt32(((object[,])myvalues)[i, 5].ToString());
                    }

                    //if (((object[,])myvalues)[i, 6] != null) { q.qLength = Decimal.Parse(((object[,])myvalues)[i, 6].ToString()); }

                    //if (((object[,])myvalues)[i, 7] != null) { q.DelivertDate = Convert.ToDateTime(((object[,])myvalues)[i, 7].ToString()); }

                    //if (((object[,])myvalues)[i, 8] != null) { q.Height = Decimal.Parse(((object[,])myvalues)[i, 8].ToString()); }

                    if (((object[,])myvalues)[i, 9] != null)
                    {
                        q.UC = Convert.ToInt32(((object[,])myvalues)[i, 9].ToString());
                    }

                    /*if (((object[,])myvalues)[i, 10] != null) { q. = Decimal.Parse(((object[,])myvalues)[i, 10].ToString()); }*/

                    //if (((object[,])myvalues)[i, 11] != null)
                    //{
                    //    q.WeightUoM = ((object[,])myvalues)[i, 11].ToString();
                    //}

                    //if (((object[,])myvalues)[i, 12] != null) { q.CCCN = Int32.Parse(((object[,])myvalues)[i, 12].ToString()); }

                    if (((object[,])myvalues)[i, 13] != null)
                    {
                        q.UnitOfMeasure = ((object[,])myvalues)[i, 13].ToString();
                    }
                    if (((object[,])myvalues)[i, 14] != null)
                    {
                        q.SSM = Convert.ToInt32(((object[,])myvalues)[i, 14].ToString());
                    }


                    if (((object[,])myvalues)[i, 15] != null) { q.UnitWeight = decimal.Parse(((object[,])myvalues)[i, 15].ToString()); }

                    //if (((object[,])myvalues)[i, 16] != null) { q. = decimal.Parse(((object[,])myvalues)[i, 16].ToString()); }



                    IME.QuotationDetailsADD(q.dgNo, q.ItemCode, q.Qty, q.UCUPCurr, q.Disc, q.Total, q.TargetUP, q.Competitor, q.ItemDescription, q.CustomerStockCode, q.IsDeleted, q.QuotationNo, q.UPIME, q.Marge, q.UnitOfMeasure, q.UC, q.SSM, q.UnitWeight, q.DependantTable, q.unitConversionId);
                }

            }
        }

    }


    class QuotationExcelExport
    {
        public static void ExportToItemHistory(DataGridView dg)
        {
            #region Copy All Items
            dg.SelectAll();
            DataObject dataObj = dg.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            #endregion

            #region ExcelExport
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            for (int j = 0; j <= dg.ColumnCount - 1; j++)
            {
                xlWorkSheet.Cells[1, j + 1] = dg.Columns[j].HeaderText;
            }
            for (int i = 0; i < dg.RowCount; i++)
            {
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    if (dg.Rows[i].Cells[j].Value != null)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();

                    }
                }
            }
            #endregion

        }

        public static void ReportQuotvsSale(DataGridView dg)
        {
            #region Copy All Items
            dg.SelectAll();
            DataObject dataObj = dg.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            #endregion

            #region ExcelExport
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            for (int j = 0; j <= dg.ColumnCount - 1; j++)
            {
                xlWorkSheet.Cells[1, j + 1] = dg.Columns[j].HeaderText;
            }
            for (int i = 0; i < dg.RowCount; i++)
            {
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    if (dg.Rows[i].Cells[j].Value != null)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();

                    }
                }
            }
            #endregion

        }

        public static void Export(DataGridView dg, string quotationNo, List<bool> ischecked)
        {
            #region Copy All Items
            dg.SelectAll();
            DataObject dataObj = dg.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            #endregion

            #region ExcelExport
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int columnNo = 1;
            for (int j = 0; j <= dg.ColumnCount - 1; j++)
            {
                if (ischecked[j])
                {
                    xlWorkSheet.Cells[1, columnNo] = dg.Columns[j].HeaderText;
                    columnNo++;
                }
            }

            for (int i = 0; i < dg.RowCount; i++)
            {
                columnNo = 1;
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    if (dg.Rows[i].Cells[j].Value != null && ischecked[j] == true)
                    {
                        xlWorkSheet.Cells[i + 2, columnNo] = dg.Rows[i].Cells[j].Value.ToString();
                        columnNo++;
                    }
                }
            }
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel Files (*.xls)|*.xls|All files (*.xls)|*.xls";
            quotationNo = quotationNo.Replace("/", "-");
            savefile.FileName = quotationNo;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string path = savefile.FileName;
                //@"C:\Users\PC\Desktop\test2.xls"
                xlWorkBook.SaveAs(@path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            }


            //xlWorkBook.Close(true, misValue, misValue);
            //xlexcel.Quit();

            #endregion

        }

        public static void QuotationMainExport(DataGridView dg, DateTime start, DateTime End)
        {
            #region Copy All Items
            dg.SelectAll();
            DataObject dataObj = dg.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            #endregion

            #region ExcelExport
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int columnnumber = 0;
            for (int j = 0; j <= dg.ColumnCount - 1; j++)
            {
                xlWorkSheet.Cells[1, j + 1] = dg.Columns[j].HeaderText;
                columnnumber++;
            }
            xlWorkSheet.Cells[1, columnnumber + 1] = start.ToString() + "-" + End.ToString();
            for (int i = 0; i < dg.RowCount; i++)
            {
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    if (dg.Rows[i].Cells[j].Value != null) { xlWorkSheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString(); }
                }
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel Files (*.xls)|*.xls|All files (*.xls)|*.xls";
            savefile.FileName = "Quotations";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string path = savefile.FileName;
                //@"C:\Users\PC\Desktop\test2.xls"
                xlWorkBook.SaveAs(@path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            }

            xlWorkBook.Close(true, misValue, misValue);
            try { xlexcel.Quit(); } catch { }
            #endregion

        }

        public static void TwoGridExport(DataGridView dg, DataGridView dg2, DateTime start, DateTime End)
        {
            #region Copy All Items
            dg.SelectAll();
            DataObject dataObj = dg.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            #endregion

            #region ExcelExport
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int columnnumber = 0;
            int columnnumber2 = 0;
            for (int j = 0; j <= dg.ColumnCount - 1; j++)
            {
                xlWorkSheet.Cells[1, j + 1] = dg.Columns[j].HeaderText;
                columnnumber++;
            }
            xlWorkSheet.Cells[1, columnnumber + 1] = start.ToString() + "-" + End.ToString();
            for (int i = 0; i < dg.RowCount; i++)
            {
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    if (dg.Rows[i].Cells[j].Value != null) { xlWorkSheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString(); }
                }
            }


            for (int j = 0; j <= dg2.ColumnCount - 1; j++)
            {
                xlWorkSheet.Cells[columnnumber, columnnumber+j + 1] = dg2.Columns[j].HeaderText;
                columnnumber2++;
            }
            xlWorkSheet.Cells[columnnumber, columnnumber+columnnumber2 + 1] = start.ToString() + "-" + End.ToString();
            for (int i = 0; i < dg.RowCount; i++)
            {
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    if (dg.Rows[i].Cells[j].Value != null) { xlWorkSheet.Cells[columnnumber, columnnumber + j + 1] = dg.Rows[i].Cells[j].Value.ToString(); }
                }
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel Files (*.xls)|*.xls|All files (*.xls)|*.xls";
            savefile.FileName = "Quotations";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string path = savefile.FileName;
                //@"C:\Users\PC\Desktop\test2.xls"
                xlWorkBook.SaveAs(@path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            }

            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();
            #endregion

        }

        public static void QuotationMainPrintExport(Quotation dg)
        {
            #region ExcelExport
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            string mySheet = @"C:\Program Files (x86)\IME GENERAL COMPONENTS\IME CRM\6944.xlsx";
            IMEEntities IME = new IMEEntities();
            xlexcel = new Excel.Application();
            QuotationDetail qd = new QuotationDetail();
            
            var quoItem = IME.QuotationDetails.Where(x => x.QuotationNo == dg.QuotationNo).ToList();
            Excel.Workbooks books = xlexcel.Workbooks;

            Excel.Workbook sheet = books.Open(mySheet);
            int i = 14;
            xlexcel.Visible = true;
            //sheet = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)sheet.Worksheets.get_Item(1);

            try { xlWorkSheet.Cells[6, 4] = dg.QuotationNo; } catch { }
            try { xlWorkSheet.Cells[6, 23] = dg.Customer.CustomerWorker.cw_email; } catch { }
            try { xlWorkSheet.Cells[6, 35] = dg.StartDate; } catch { }
            try { xlWorkSheet.Cells[7, 4] = dg.Customer.c_name; } catch { }
            try { xlWorkSheet.Cells[7, 23] = dg.Customer.fax; } catch { }
            try { xlWorkSheet.Cells[7, 35] = dg.Worker.NameLastName; } catch { }

            try { xlWorkSheet.Cells[10, 4] = dg.Customer.CustomerWorker.cw_name; } catch { }
            try { xlWorkSheet.Cells[10, 23] = dg.RFQNo; } catch { }
            try { xlWorkSheet.Cells[10, 35] = dg.Worker.Email; } catch { }

            try { xlWorkSheet.Cells[12, 4] = dg.Customer.CustomerWorker.mobilephone; } catch { }
            try { xlWorkSheet.Cells[12, 23] = dg.ValidationDay; } catch { }
            try { xlWorkSheet.Cells[12, 35] = dg.Worker.mobileNumber; } catch { }

            foreach (var item in dg.QuotationDetails)
            {
                try { xlWorkSheet.Cells[i, 1] = item.dgNo; } catch { }
                try { xlWorkSheet.Cells[i, 2] = item.ItemCode; } catch { }
                try { xlWorkSheet.Cells[i, 10] = item.ItemDescription; } catch { }
                try { xlWorkSheet.Cells[i, 15] = item.MPN; } catch { }
                //xlWorkSheet.Cells[i, 21] = item.Brand;
                try { xlWorkSheet.Cells[i, 24] = item.SSM; } catch { }
                try { xlWorkSheet.Cells[i, 27] = item.Qty / item.SSM; } catch { }
                try { xlWorkSheet.Cells[i, 28] = item.Qty; } catch { }
                try { xlWorkSheet.Cells[i, 31] = item.UCUPCurr; } catch { }
                try { xlWorkSheet.Cells[i, 34] = item.Total; } catch { }
                try { xlWorkSheet.Cells[i, 38] = item.Quotation.DeliveryDate; } catch { }

                i = i + 1;
            }

            


            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel Files (*.xls)|*.xls|All files (*.xls)|*.xls";
            savefile.FileName = "Quotations";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string path = savefile.FileName;
                //@"C:\Users\PC\Desktop\test2.xls"
                sheet.SaveAs(@path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            }

            sheet.Close(true, misValue, misValue);
            //xlexcel.Quit();

            #endregion

        }
    }
    //enum LoaderResultColumns
    //{
    //    FileName = 0,
    //    Result = 1
    //}

}