﻿using LoginForm.DataSet;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace LoginForm
{
    class txtReader
    {
        public static string LoaderType;

        public static void PurchaseInvoicetxtReader()
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
                    PurchaseInvoice pi = new PurchaseInvoice();
                    while (lines.Count() > a)
                    {
                        if (lines[a] != "")
                        {
                            if (lines[a].Substring(0, 2) == "FH")
                            {
                                pi.CountryCode = lines[a].Substring(2, 3);
                                if(lines[a].Substring(5, 10)!="") pi.OrderDate = Convert.ToDateTime( lines[a].Substring(5, 10));
                                pi.OrderTime = lines[a].Substring(14, 5);
                            }
                            else if (lines[a].Substring(0, 2) == "IV")
                            {
                                pi.ShipmentReference = lines[a].Substring(2, 10);
                                pi.BillingDocumentReference = lines[a].Substring(12, 10);
                                pi.ShippingCondition = lines[a].Substring(22, 2);
                                pi.BillingDocumentDate = lines[a].Substring(24, 8);
                                pi.SupplyingECCompany = lines[a].Substring(32, 4);
                                pi.CustomerReference = lines[a].Substring(34, 10);
                                pi.InvoiceTaxValue = lines[a].Substring(54, 18);
                                pi.InvoiceGoodsValue = lines[a].Substring(72, 18);
                                pi.InvoiceNettValue = lines[a].Substring(90, 18);
                                pi.Currency = lines[a].Substring(108, 3);
                                pi.AirwayBillNumber = lines[a].Substring(111, 20);

                            }
                            else if (lines[a].Substring(0, 2) == "FT")
                            {
                                pi.LineControl = lines[a].Substring(2, 4);
                            }
                            else if (lines[a].Substring(0, 2) == "IC")
                            {
                                pi.Surchargeordiscountindicator = lines[a].Substring(2, 3);
                                pi.ConditionType = lines[a].Substring(5, 4);
                                pi.ConditionText = lines[a].Substring(9, 80);
                                pi.ConditionValueN = lines[a].Substring(89, 18);
                            }
                            else if (lines[a].Substring(0, 2) == "CT")
                            {
                                pi.LineControl2 = lines[a].Substring(2, 4);
                            }
                        }
                        a++;
                    }
                if (IME.PurchaseInvoices.Where(b => b.BillingDocumentReference == pi.BillingDocumentReference).FirstOrDefault()==null)
                {
                    IME.PurchaseInvoices.Add(pi);
                    IME.SaveChanges();
                    a = 0;

                    while (lines.Count() > a)
                    {
                        if (lines[a].Substring(0, 2) == "OI")
                        {
                            PurchaseInvoiceDetail purchaseInvoiceDetail = new PurchaseInvoiceDetail();
                            purchaseInvoiceDetail.PurchaseInvoiceID = pi.ID;
                            purchaseInvoiceDetail.PurchaseOrderNumber = lines[a].Substring(2, 30);
                            purchaseInvoiceDetail.PurchaseOrderItemNumber = lines[a].Substring(32, 6);
                            purchaseInvoiceDetail.ProductNumber = lines[a].Substring(38, 18);
                            purchaseInvoiceDetail.BillingItemNumber = lines[a].Substring(56, 6);
                            purchaseInvoiceDetail.Quantity = lines[a].Substring(62, 15);
                            purchaseInvoiceDetail.SalesUnit = lines[a].Substring(77, 3);
                            purchaseInvoiceDetail.UnitPrice = lines[a].Substring(80, 11);
                            purchaseInvoiceDetail.Discount = lines[a].Substring(91, 11);
                            purchaseInvoiceDetail.Tax = lines[a].Substring(102, 11);
                            purchaseInvoiceDetail.GoodsValue = lines[a].Substring(113, 11);
                            purchaseInvoiceDetail.Amount = lines[a].Substring(124, 11);
                            purchaseInvoiceDetail.CCCNno = lines[a].Substring(135, 15);
                            purchaseInvoiceDetail.CountryofOrigin = lines[a].Substring(150, 3);
                            purchaseInvoiceDetail.ArticleDescription = lines[a].Substring(153, 40);
                            purchaseInvoiceDetail.DeliveryNumber = lines[a].Substring(193, 10);
                            purchaseInvoiceDetail.DeliveryItemNumber = lines[a].Substring(203, 6);
                            IME.PurchaseInvoiceDetails.Add(purchaseInvoiceDetail);
                            IME.SaveChanges();
                            isItem = true;
                        }
                        a++;
                    }
                    a = 0;
                    MessageBox.Show("Purchase Invoice loaded succesfully");
                }
                else
                {
                    MessageBox.Show("Purchase Invoice already exist");
                }



            }
        }

        public static int SuperDiskRead()
        {
            #region Superdisk
            int a = 1;
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
                            Superdiskitems.Pack_Quantity ,
                            Superdiskitems.Unit_Content,
                            Superdiskitems.Unit_Measure ,
                            Superdiskitems.Uk_Col_1 ,
                            Superdiskitems.Standard_Weight,
                            Superdiskitems.Hazardous_Ind ,
                            Superdiskitems.Calibration_Ind ,
                            Superdiskitems.Obsolete_Flag ,
                            Superdiskitems.MH1,
                            Superdiskitems.Low_Discount_Ind,
                            Superdiskitems.Licensed_Ind ,
                            Superdiskitems.Shelf_Life ,
                            Superdiskitems.CofO ,
                            Superdiskitems.EUR1_Indicator ,
                            Superdiskitems.CCCN_No ,
                            Superdiskitems.Supercede_Date,
                            Superdiskitems.Current_Cat_page ,
                            Superdiskitems.Uk_Intro_Date,
                            Superdiskitems.Filler,
                            Superdiskitems.Uk_Disc_Date ,
                            Superdiskitems.Substitute_By ,
                            Superdiskitems.BHC_Flag,
                            Superdiskitems.Filler1,
                            Superdiskitems.Future_Sell_Price,
                            Superdiskitems.Int_Cat,
                            Superdiskitems.New_Prod_Change_Ind,
                            Superdiskitems.Out_of_Stock_Prohibit_change_ind,
                            Superdiskitems.Disc_Change_Ind,
                            Superdiskitems.Superceded_Change_Ind ,
                            Superdiskitems.Pack_Size_Change_Ind ,
                            Superdiskitems.Rolled_Product_Change_Ind ,
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
                            s.Pack_Quantity ,
                            s.Unit_Content,
                            s.Unit_Measure ,
                            s.Uk_Col_1 ,
                            s.Standard_Weight,
                            s.Hazardous_Ind ,
                            s.Calibration_Ind ,
                            s.Obsolete_Flag ,
                            s.MH1,
                            s.Low_Discount_Ind,
                            s.Licensed_Ind ,
                            s.Shelf_Life ,
                            s.CofO ,
                            s.EUR1_Indicator ,
                            s.CCCN_No ,
                            s.Supercede_Date,
                            s.Current_Cat_page ,
                            s.Uk_Intro_Date,
                            s.Filler,
                            s.Uk_Disc_Date ,
                            s.Substitute_By ,
                            s.BHC_Flag,
                            s.Filler1,
                            s.Future_Sell_Price,
                            s.Int_Cat,
                            s.New_Prod_Change_Ind,
                            s.Out_of_Stock_Prohibit_change_ind,
                            s.Disc_Change_Ind,
                            s.Superceded_Change_Ind ,
                            s.Pack_Size_Change_Ind ,
                            s.Rolled_Product_Change_Ind ,
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

        public static int DiscontinuedListRead()
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
                        if (ws.Cells[ColumnNumber, 4].Text != "") { DailyDiscontinued.Runon = Int32.Parse(ws.Cells[ColumnNumber, 4].Text); }
                        if (ws.Cells[ColumnNumber, 5].Text != "") { DailyDiscontinued.Referral = Int32.Parse(ws.Cells[ColumnNumber, 5].Text); }

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
                catch { MessageBox.Show("This document does not proper to load here"); return 0; }
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
            #region EntendedRangeRead
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
                    bool isextendedRange = true;
                    if (ws.Cells[1, 1].Text != "ArticleNo") isextendedRange = false;
                    if (ws.Cells[1, 2].Text != "Manufacturer Code") isextendedRange = false;
                    if (ws.Cells[1, 3].Text != "Brand") isextendedRange = false;
                    if (ws.Cells[1, 4].Text != "MPN") isextendedRange = false;
                    if (ws.Cells[1, 5].Text != "ArticleDescription (40 Char Description)") isextendedRange = false;
                    if (ws.Cells[1, 6].Text != "Length") isextendedRange = false;
                    if (ws.Cells[1, 7].Text != "Width") isextendedRange = false;
                    if (ws.Cells[1, 8].Text != "Height") isextendedRange = false;
                    if (ws.Cells[1, 9].Text != "Dimension UoM") isextendedRange = false;
                    if (ws.Cells[1, 10].Text != "Weight") isextendedRange = false;
                    if (ws.Cells[1, 11].Text != "Weight UoM") isextendedRange = false;
                    if (ws.Cells[1, 12].Text != "CCCN") isextendedRange = false;
                    if (ws.Cells[1, 13].Text != "Country of Origin") isextendedRange = false;
                    if (ws.Cells[1, 14].Text != "Unit of Measure") isextendedRange = false;
                    if (ws.Cells[1, 15].Text != "Pack Size") isextendedRange = false;
                    if (ws.Cells[1, 16].Text != "(Sales UoM)") isextendedRange = false;
                    if (ws.Cells[1, 17].Text != "Cost price currency") isextendedRange = false;
                    if (ws.Cells[1, 18].Text != "Col1Price") isextendedRange = false;
                    if (ws.Cells[1, 19].Text != "Col1Break") isextendedRange = false;
                    if (ws.Cells[1, 20].Text != "Col2Price") isextendedRange = false;
                    if (ws.Cells[1, 21].Text != "Col2Break") isextendedRange = false;
                    if (ws.Cells[1, 22].Text != "Col3Price") isextendedRange = false;
                    if (ws.Cells[1, 23].Text != "Col3Break") isextendedRange = false;
                    if (ws.Cells[1, 24].Text != "Col4Price") isextendedRange = false;
                    if (ws.Cells[1, 25].Text != "Col4Break") isextendedRange = false;
                    if (ws.Cells[1, 26].Text != "Col5Price") isextendedRange = false;
                    if (ws.Cells[1, 27].Text != "Col5Break") isextendedRange = false;
                    if (ws.Cells[1, 28].Text != "DiscountedPrice1") isextendedRange = false;
                    if (ws.Cells[1, 29].Text != "DiscountedPrice2") isextendedRange = false;
                    if (ws.Cells[1, 30].Text != "DiscountedPrice3") isextendedRange = false;
                    if (ws.Cells[1, 31].Text != "DiscountedPrice4") isextendedRange = false;
                    if (ws.Cells[1, 32].Text != "DiscountedPrice5") isextendedRange = false;


                    while (ws.Cells[ColumnNumber - 1, RowNumber].Text != "" || RowNumber < 33)
                    {
                        Columns.Add(ws.Cells[ColumnNumber - 1, RowNumber].Text);
                        RowNumber++;
                    }
                    //
                    string ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                    


                    if (!isextendedRange)
                    {
                        while (ArticleNumb != "")
                        {
                            ExtendedRange extendedRange = new ExtendedRange();
                            //FILLER
                            //Bu kod extendedranges için bir tane nesenyi dolduruyor
                            int Rownb = 1;


                            while (ws.Cells[ColumnNumber, Rownb].Text != "" || Rownb < (Columns.Count - 1))
                            {
                                switch (Columns[Rownb - 1])
                                {
                                    case "ArticleNo":
                                        extendedRange.ArticleNo = ws.Cells[ColumnNumber, Rownb].Text;
                                        break;
                                    case "Manufacturer Code":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.ManufacturerCode = ws.Cells[ColumnNumber, Rownb].Text; }
                                        break;
                                    case "Brand":
                                        extendedRange.Brand = ws.Cells[ColumnNumber, Rownb].Text;
                                        break;
                                    case "MPN":
                                        extendedRange.MPN = ws.Cells[ColumnNumber, Rownb].Text;
                                        break;
                                    case "ArticleDescription (40 Char Description)":
                                        extendedRange.ArticleDescription = ws.Cells[ColumnNumber, Rownb].Text;
                                        break;
                                    case "Length":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.ExtendedRangeLength = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Width":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Width = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Height":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Height = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Dimension UoM":
                                        extendedRange.DimensionUoM = ws.Cells[ColumnNumber, Rownb].Text;
                                        break;
                                    case "Weight":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.ExtendedRangeWeight = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Weight UoM":
                                        extendedRange.WeightUoM = ws.Cells[ColumnNumber, Rownb].Text;
                                        break;
                                    case "CCCN":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.CCCN = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Country of Origin":
                                        extendedRange.CountryofOrigin = ws.Cells[ColumnNumber, Rownb].Text;
                                        break;
                                    case "Unit of Measure":
                                        extendedRange.UnitofMeasure = ws.Cells[ColumnNumber, Rownb].Text;
                                        break;
                                    case "Pack Size":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.PackSize = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "(Sales UoM)":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.SalesUoM = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Cost price currency":
                                        extendedRange.CostPriceCurrency = ws.Cells[ColumnNumber, Rownb].Text;
                                        break;
                                    case "Col1Price":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col1Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Col2Price":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col2Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Col3Price":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col3Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Col4Price":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col4Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Col5Price":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col5Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Col1Break":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col1Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Col2Break":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col2Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Col3Break":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col3Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Col4Break":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col4Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "Col5Break":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.Col5Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "DiscountedPrice1":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice1 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "DiscountedPrice2":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice2 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "DiscountedPrice3":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice3 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "DiscountedPrice4":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice4 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "DiscountedPrice5":
                                        if (ws.Cells[ColumnNumber, Rownb].Text != "") { extendedRange.DiscountedPrice5 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                        break;
                                    case "":
                                        break;
                                }
                                Rownb++;
                            }
                            //Yeni bir dosya eklemek için

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


                            extendedRange = new ExtendedRange();
                            ColumnNumber++;
                            ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                        }
                    }
                    else
                    {
                        ExtendedRange extendedRange = new ExtendedRange();
                        //FILLER
                        //Bu kod extendedranges için bir tane nesenyi dolduruyor
                        int Rownb = 1;


                        while (ws.Cells[ColumnNumber, 1].Text != "")
                        {
                            
                                
                                    extendedRange.ArticleNo = ws.Cells[ColumnNumber, 1].Text;
                                    if (ws.Cells[ColumnNumber, 2].Text != "") { extendedRange.ManufacturerCode = ws.Cells[ColumnNumber, 2].Text; }
                                    extendedRange.Brand = ws.Cells[ColumnNumber, 3].Text;
                                    extendedRange.MPN = ws.Cells[ColumnNumber, 4].Text;
                                    extendedRange.ArticleDescription = ws.Cells[ColumnNumber, 5].Text;
                            
                                    if (ws.Cells[ColumnNumber, 6].Text != "") { extendedRange.ExtendedRangeLength = Decimal.Parse(ws.Cells[ColumnNumber, 6].Text); }
                           
                                    if (ws.Cells[ColumnNumber, 7].Text != "") { extendedRange.Width = Decimal.Parse(ws.Cells[ColumnNumber, 7].Text); }
                           
                                    if (ws.Cells[ColumnNumber, 8].Text != "") { extendedRange.Height = Decimal.Parse(ws.Cells[ColumnNumber, 8].Text); }
                           
                                    extendedRange.DimensionUoM = ws.Cells[ColumnNumber, 9].Text;
                           
                                    if (ws.Cells[ColumnNumber, 10].Text != "") { extendedRange.ExtendedRangeWeight = Decimal.Parse(ws.Cells[ColumnNumber, 10].Text); }
                            
                                    extendedRange.WeightUoM = ws.Cells[ColumnNumber, 11].Text;

                                    if (ws.Cells[ColumnNumber, 12].Text != "") { extendedRange.CCCN = Int32.Parse(ws.Cells[ColumnNumber, 12].Text); }

                                    extendedRange.CountryofOrigin = ws.Cells[ColumnNumber, 13].Text;
                                    extendedRange.UnitofMeasure = ws.Cells[ColumnNumber, 14].Text;

                                    if (ws.Cells[ColumnNumber, 15].Text != "") { extendedRange.PackSize = Int32.Parse(ws.Cells[ColumnNumber, 15].Text); }

                                    if (ws.Cells[ColumnNumber, 16].Text != "") { extendedRange.SalesUoM = Int32.Parse(ws.Cells[ColumnNumber, 16].Text); }

                                    extendedRange.CostPriceCurrency = ws.Cells[ColumnNumber, 17].Text;

                                    if (ws.Cells[ColumnNumber, 18].Text != "") { extendedRange.Col1Price = Decimal.Parse(ws.Cells[ColumnNumber, 18].Text); }

                                    if (ws.Cells[ColumnNumber, 19].Text != "") { extendedRange.Col2Price = Decimal.Parse(ws.Cells[ColumnNumber, 19].Text); }

                                    if (ws.Cells[ColumnNumber, 20].Text != "") { extendedRange.Col3Price = Decimal.Parse(ws.Cells[ColumnNumber, 20].Text); }

                                    if (ws.Cells[ColumnNumber, 21].Text != "") { extendedRange.Col4Price = Decimal.Parse(ws.Cells[ColumnNumber, 21].Text); }
  
                                    if (ws.Cells[ColumnNumber, 22].Text != "") { extendedRange.Col5Price = Decimal.Parse(ws.Cells[ColumnNumber, 22].Text); }

                                    if (ws.Cells[ColumnNumber, 23].Text != "") { extendedRange.Col1Break = Int32.Parse(ws.Cells[ColumnNumber, 23].Text); }

                                    if (ws.Cells[ColumnNumber, 24].Text != "") { extendedRange.Col2Break = Int32.Parse(ws.Cells[ColumnNumber, 24].Text); }

                                    if (ws.Cells[ColumnNumber, 25].Text != "") { extendedRange.Col3Break = Int32.Parse(ws.Cells[ColumnNumber, 25].Text); }

                                    if (ws.Cells[ColumnNumber, 26].Text != "") { extendedRange.Col4Break = Int32.Parse(ws.Cells[ColumnNumber, 26].Text); }

                                    if (ws.Cells[ColumnNumber, 27].Text != "") { extendedRange.Col5Break = Int32.Parse(ws.Cells[ColumnNumber, 27].Text); }
                                    if (ws.Cells[ColumnNumber, 28].Text != "") { extendedRange.DiscountedPrice1 = Decimal.Parse(ws.Cells[ColumnNumber, 28].Text); }
                                    if (ws.Cells[ColumnNumber, 29].Text != "") { extendedRange.DiscountedPrice2 = Decimal.Parse(ws.Cells[ColumnNumber, 29].Text); }
                                    if (ws.Cells[ColumnNumber, 30].Text != "") { extendedRange.DiscountedPrice3 = Decimal.Parse(ws.Cells[ColumnNumber, 30].Text); }
                                    if (ws.Cells[ColumnNumber, 31].Text != "") { extendedRange.DiscountedPrice4 = Decimal.Parse(ws.Cells[ColumnNumber, 31].Text); }
                                    if (ws.Cells[ColumnNumber, 32].Text != "") { extendedRange.DiscountedPrice5 = Decimal.Parse(ws.Cells[ColumnNumber, 32].Text); }



                            //Yeni bir dosya eklemek için

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


                            extendedRange = new ExtendedRange();
                            ColumnNumber++;
                            ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                        }
                    }
                        
                    MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                    #endregion
                    return 1;
                }
                catch { MessageBox.Show("This document does not proper to load here"); return 0; }
            }
            return 0;
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
                  while ((ws.Cells[ColumnNumber, 1].Text) !="")
                    {
                    ArticleNumb = ws.Cells[ColumnNumber, 25].Text;
                        if (IME.Cities.Where(a => a.City_name == ArticleNumb).FirstOrDefault() == null && ArticleNumb!=null)
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
                    if (IME.Towns.Where(a => a.Town_name == ArticleNumb).ToList().Count==0 && ArticleNumb != null)
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
                        IME.CustomerDepartments .Add(town);
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
                int ColumnNumber =3;
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
                        CustomerSubCategory town = new CustomerSubCategory();
                        town.subcategoryname = ArticleNumb;
                        string Countryname = ws.Cells[ColumnNumber, 1].Text;
                        CustomerCategory c = IME.CustomerCategories.Where(a => a.categoryname == Countryname).FirstOrDefault();
                        if (c != null)town.categoryID = c.ID;
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
                    if (IME.Workers.Where(a=>a.NameLastName==Worker).FirstOrDefault()==null)
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
                    worker= ws.Cells[ColumnNumber, 6].Text;
                    Customer c = IME.Customers.Where(a => a.ID == ArticleNumb).FirstOrDefault();
                    if (c!=null)
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
                    if (IME.Customers.Where(a=>a.ID== CustomerCode).ToList().Count==0)
                    {
                        int noteID=0;
                        if (ws.Cells[ColumnNumber, 11].Text != "")
                        {
                            string notestring = ws.Cells[ColumnNumber, 11].Text;
                            noteID = createNOTE(notestring);
                        }
                        Customer c = new Customer();
                        c.ID= ws.Cells[ColumnNumber, 1].Text;
                        if (noteID != 0) c.customerNoteID = noteID;
                        c.c_name = ws.Cells[ColumnNumber, 2].Text;
                        string categoryname = null;
                        string subcategoryname = null;
                        if(ws.Cells[ColumnNumber, 3].Text==null) categoryname = ws.Cells[ColumnNumber, 3].Text;
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
                        if(ws.Cells[ColumnNumber, 7].Text== "Active") { c.isactive = 1; } else { c.isactive = 0; }

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
    }

    class QuotationExcelExport
    {

        public static void Export(DataGridView dg,string quotationNo, List<bool> ischecked)
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
                if(ischecked[j])xlWorkSheet.Cells[1, j + 1] = dg.Columns[j].HeaderText;
            }
            for (int i = 0; i < dg.RowCount; i++)
            {
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    if (dg.Rows[i].Cells[j].Value != null && ischecked[j]==true) { xlWorkSheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString(); }
                }
            }
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel Files (*.xls)|*.xls|All files (*.xls)|*.xls";
            quotationNo= quotationNo.Replace("/", "-");
            savefile.FileName = quotationNo;
            if (savefile.ShowDialog()==DialogResult.OK)
            {
                string path = savefile.FileName;
                //@"C:\Users\PC\Desktop\test2.xls"
                xlWorkBook.SaveAs(@path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            }


                    //xlWorkBook.Close(true, misValue, misValue);
                    //xlexcel.Quit();

            #endregion

        }
        
    }
}
