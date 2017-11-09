using LoginForm.DataSet;
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



                try
                {

                    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                    string[] columnnames = lines[0].Split('|');
                    string[] wordcontrol;
                    wordcontrol = lines[1].Split('|');
                    if (!wordcontrol[0].Contains("P"))
                    {


                        while (lines.Count() > a)
                        {
                            if (a == 67)
                            {

                            }


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


                            var result = (from m in IME.SuperDisks
                                          where m.Article_No == Superdiskitems.Article_No
                                          select new
                                          {

                                          }).Count();
                            //burada update veya insert yapıyoruz
                            if (result > 0)
                            {
                                //UPDATE
                                var updateresult = IME.SuperDisks.Where(b => b.Article_No == Superdiskitems.Article_No).FirstOrDefault();
                                updateresult.Article_Desc = Superdiskitems.Article_Desc;
                                updateresult.Article_No = Superdiskitems.Article_No;
                                updateresult.BHC_Flag = Superdiskitems.BHC_Flag;
                                updateresult.Calibration_Ind = Superdiskitems.Calibration_Ind;
                                updateresult.CCCN_No = Superdiskitems.CCCN_No;
                                updateresult.CofO = Superdiskitems.CofO;
                                updateresult.Current_Cat_page = Superdiskitems.Current_Cat_page;
                                updateresult.Disc_Change_Ind = Superdiskitems.Disc_Change_Ind;
                                updateresult.EUR1_Indicator = Superdiskitems.EUR1_Indicator;
                                updateresult.Expiring_Product_Change_Ind = Superdiskitems.Expiring_Product_Change_Ind;
                                updateresult.Filler = Superdiskitems.Filler;
                                updateresult.Filler1 = Superdiskitems.Filler1;
                                updateresult.Future_Sell_Price = Superdiskitems.Future_Sell_Price;
                                updateresult.Hazardous_Ind = Superdiskitems.Hazardous_Ind;
                                updateresult.Heigh = Superdiskitems.Heigh;
                                updateresult.Int_Cat = Superdiskitems.Int_Cat;
                                updateresult.Length = Superdiskitems.Length;
                                updateresult.Licensed_Ind = Superdiskitems.Licensed_Ind;
                                updateresult.Low_Discount_Ind = Superdiskitems.Low_Discount_Ind;
                                updateresult.Manufacturer = Superdiskitems.Manufacturer;
                                updateresult.MH1 = Superdiskitems.MH1;
                                updateresult.MH_Code_Level_1 = Superdiskitems.MH_Code_Level_1;
                                updateresult.MPN = Superdiskitems.MPN;
                                updateresult.New_Prod_Change_Ind = Superdiskitems.New_Prod_Change_Ind;
                                updateresult.Obsolete_Flag = Superdiskitems.Obsolete_Flag;
                                updateresult.Out_of_Stock_Prohibit_change_ind = Superdiskitems.Out_of_Stock_Prohibit_change_ind;
                                updateresult.Pack_Code = Superdiskitems.Pack_Code;
                                updateresult.Pack_Quantity = Superdiskitems.Pack_Quantity;
                                updateresult.Pack_Size_Change_Ind = Superdiskitems.Pack_Size_Change_Ind;
                                updateresult.Rolled_Product_Change_Ind = Superdiskitems.Rolled_Product_Change_Ind;
                                updateresult.Shelf_Life = Superdiskitems.Shelf_Life;
                                updateresult.Standard_Weight = Superdiskitems.Standard_Weight;
                                updateresult.Substitute_By = Superdiskitems.Substitute_By;
                                updateresult.Superceded_Change_Ind = Superdiskitems.Superceded_Change_Ind;
                                updateresult.Supercede_Date = Superdiskitems.Supercede_Date;
                                updateresult.Uk_Col_1 = Superdiskitems.Uk_Col_1;
                                updateresult.Uk_Disc_Date = Superdiskitems.Uk_Disc_Date;
                                updateresult.Uk_Intro_Date = Superdiskitems.Uk_Intro_Date;
                                updateresult.Unit_Content = Superdiskitems.Unit_Content;
                                updateresult.Unit_Measure = Superdiskitems.Unit_Measure;
                                updateresult.Width = Superdiskitems.Width;
                                IME.SaveChanges();
                                UptCounter++;
                            }
                            else
                            {
                                //ADD
                                IME.SuperDisks.Add(Superdiskitems);
                                IME.SaveChanges();
                                //item ın içindeki verileri boşaltmak için
                                SuperDisk item1 = new SuperDisk();
                                Superdiskitems = item1;
                                AddedCounter++;
                            }
                            a++;
                            Superdiskitems = new SuperDisk();
                        }
                        MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("Please Choose Correct File");
                        return 0;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); MessageBox.Show(a.ToString()); return 0; }
                #endregion
            }
            return 0;
        }
        public static int SuperDiskPRead()
        {
            #region SuperdiskP
            IMEEntities IME = new IMEEntities();
            SuperDiskP Superdiskitems = new SuperDiskP();
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            DialogResult result1 = openFileDialog1.ShowDialog();
            int AddedCounter = 0;
            int UptCounter = 0;
            if (result1 == DialogResult.OK) // Test result.
            {


                try
                {
                    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                    string[] columnnames = lines[0].Split('|');

                    string[] wordcontrol;
                    wordcontrol = lines[1].Split('|');
                    if (wordcontrol[0].Contains("P"))
                    {
                        int a = 1;
                        while (lines.Count() > a)
                        {
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
                                        try
                                        {
                                            Superdiskitems.Future_Sell_Price = decimal.Parse(word[i]);
                                        }
                                        catch { }
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


                            var result = (from m in IME.SuperDiskPs
                                          where m.Article_No == Superdiskitems.Article_No
                                          select new
                                          {

                                          }).Count();
                            //burada update veya insert yapıyoruz
                            if (result > 0)
                            {
                                //UPDATE
                                var updateresult = IME.SuperDiskPs.Where(b => b.Article_No == Superdiskitems.Article_No).FirstOrDefault();
                                updateresult.Article_Desc = Superdiskitems.Article_Desc;
                                updateresult.Article_No = Superdiskitems.Article_No;
                                updateresult.BHC_Flag = Superdiskitems.BHC_Flag;
                                updateresult.Calibration_Ind = Superdiskitems.Calibration_Ind;
                                updateresult.CCCN_No = Superdiskitems.CCCN_No;
                                updateresult.CofO = Superdiskitems.CofO;
                                updateresult.Current_Cat_page = Superdiskitems.Current_Cat_page;
                                updateresult.Disc_Change_Ind = Superdiskitems.Disc_Change_Ind;
                                updateresult.EUR1_Indicator = Superdiskitems.EUR1_Indicator;
                                updateresult.Expiring_Product_Change_Ind = Superdiskitems.Expiring_Product_Change_Ind;
                                updateresult.Filler = Superdiskitems.Filler;
                                updateresult.Filler1 = Superdiskitems.Filler1;
                                updateresult.Future_Sell_Price = Superdiskitems.Future_Sell_Price;
                                updateresult.Hazardous_Ind = Superdiskitems.Hazardous_Ind;
                                updateresult.Heigh = Superdiskitems.Heigh;
                                updateresult.Int_Cat = Superdiskitems.Int_Cat;
                                updateresult.Length = Superdiskitems.Length;
                                updateresult.Licensed_Ind = Superdiskitems.Licensed_Ind;
                                updateresult.Low_Discount_Ind = Superdiskitems.Low_Discount_Ind;
                                updateresult.Manufacturer = Superdiskitems.Manufacturer;
                                updateresult.MH1 = Superdiskitems.MH1;
                                updateresult.MH_Code_Level_1 = Superdiskitems.MH_Code_Level_1;
                                updateresult.MPN = Superdiskitems.MPN;
                                updateresult.New_Prod_Change_Ind = Superdiskitems.New_Prod_Change_Ind;
                                updateresult.Obsolete_Flag = Superdiskitems.Obsolete_Flag;
                                updateresult.Out_of_Stock_Prohibit_change_ind = Superdiskitems.Out_of_Stock_Prohibit_change_ind;
                                updateresult.Pack_Code = Superdiskitems.Pack_Code;
                                updateresult.Pack_Quantity = Superdiskitems.Pack_Quantity;
                                updateresult.Pack_Size_Change_Ind = Superdiskitems.Pack_Size_Change_Ind;
                                updateresult.Rolled_Product_Change_Ind = Superdiskitems.Rolled_Product_Change_Ind;
                                updateresult.Shelf_Life = Superdiskitems.Shelf_Life;
                                updateresult.Standard_Weight = Superdiskitems.Standard_Weight;
                                updateresult.Substitute_By = Superdiskitems.Substitute_By;
                                updateresult.Superceded_Change_Ind = Superdiskitems.Superceded_Change_Ind;
                                updateresult.Supercede_Date = Superdiskitems.Supercede_Date;
                                updateresult.Uk_Col_1 = Superdiskitems.Uk_Col_1;
                                updateresult.Uk_Disc_Date = Superdiskitems.Uk_Disc_Date;
                                updateresult.Uk_Intro_Date = Superdiskitems.Uk_Intro_Date;
                                updateresult.Unit_Content = Superdiskitems.Unit_Content;
                                updateresult.Unit_Measure = Superdiskitems.Unit_Measure;
                                updateresult.Width = Superdiskitems.Width;
                                IME.SaveChanges();
                                UptCounter++;
                            }
                            else
                            {
                                //ADD
                                IME.SuperDiskPs.Add(Superdiskitems);
                                IME.SaveChanges();
                                //item ın içindeki verileri boşaltmak için
                                SuperDiskP item1 = new SuperDiskP();
                                Superdiskitems = item1;
                                AddedCounter++;
                            }
                            a++;
                            Superdiskitems = new SuperDiskP();

                        }
                        MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
                        return 1;
                    }
                    else
                    { MessageBox.Show("Please Choose Correct File1"); return 0; }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return 0; }

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


                        var result = (from m in IME.SlidingPrices
                                      where m.ArticleNo == Superdiskitems.ArticleNo
                                      select new
                                      {

                                      }).Count();
                        //burada update veya insert yapıyoruz
                        if (result > 0)
                        {
                            //UPDATE
                            var updateresult = IME.SlidingPrices.Where(b => b.ArticleNo == Superdiskitems.ArticleNo).FirstOrDefault();
                            updateresult.ArticleDescription = Superdiskitems.ArticleDescription;
                            updateresult.ArticleNo = Superdiskitems.ArticleNo;
                            updateresult.Col1Break = Superdiskitems.Col1Break;
                            updateresult.Col1Price = Superdiskitems.Col1Price;
                            updateresult.Col2Break = Superdiskitems.Col2Break;
                            updateresult.Col2Price = Superdiskitems.Col2Price;
                            updateresult.Col3Break = Superdiskitems.Col3Break;
                            updateresult.Col3Price = Superdiskitems.Col3Price;
                            updateresult.Col4Break = Superdiskitems.Col4Break;
                            updateresult.Col4Price = Superdiskitems.Col4Price;
                            updateresult.Col5Break = Superdiskitems.Col5Break;
                            updateresult.Col5Price = Superdiskitems.Col5Price;
                            updateresult.DiscontinuedDate = Superdiskitems.DiscontinuedDate;
                            updateresult.DiscountedPrice1 = Superdiskitems.DiscountedPrice1;
                            updateresult.DiscountedPrice2 = Superdiskitems.DiscountedPrice2;
                            updateresult.DiscountedPrice3 = Superdiskitems.DiscountedPrice3;
                            updateresult.DiscountedPrice4 = Superdiskitems.DiscountedPrice4;
                            updateresult.DiscountedPrice5 = Superdiskitems.DiscountedPrice5;
                            updateresult.IntroductionDate = Superdiskitems.IntroductionDate;
                            updateresult.ItemTypeCode = Superdiskitems.ItemTypeCode;
                            updateresult.ItemTypeDesc = Superdiskitems.ItemTypeDesc;
                            updateresult.Quantity1 = Superdiskitems.Quantity1;
                            updateresult.SupersectionName = Superdiskitems.SupersectionName;
                            updateresult.SuperSectionNo = Superdiskitems.SuperSectionNo;
                            IME.SaveChanges();
                            UptCounter++;
                        }
                        else
                        {
                            //ADD
                            IME.SlidingPrices.Add(Superdiskitems);
                            IME.SaveChanges();
                            //item ın içindeki verileri boşaltmak için
                            SlidingPrice item1 = new SlidingPrice();
                            Superdiskitems = item1;
                            AddedCounter++;
                        }
                        a++;
                        Superdiskitems = new SlidingPrice();
                    }

                    MessageBox.Show(AddedCounter + " items are Added, " + UptCounter + " items are Updated");
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
                        DailyDiscontinued ddc = new DailyDiscontinued();
                        if (IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() != null)
                        {

                            //UPDATE
                            ddc = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault();
                            UptCounter++;
                        }
                        ddc.ArticleNo = ws.Cells[ColumnNumber, 1].Text;
                        ddc.ReasonDescription = ws.Cells[ColumnNumber, 2].Text;
                        ddc.DiscontinuationDate = ws.Cells[ColumnNumber, 3].Text;
                        if (ws.Cells[ColumnNumber, 4].Text != "") { ddc.Runon = Int32.Parse(ws.Cells[ColumnNumber, 4].Text); }
                        if (ws.Cells[ColumnNumber, 5].Text != "") { ddc.Referral = Int32.Parse(ws.Cells[ColumnNumber, 5].Text); }

                        if (IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() == null)
                        {
                            IME.DailyDiscontinueds.Add(ddc);
                            AddedCounter++;
                        }
                        IME.SaveChanges();
                        ddc = new DailyDiscontinued();
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
                        DualUse ddc = new DualUse();
                        if (IME.DualUses.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() != null)
                        {
                            //UPDATE
                            ddc = IME.DualUses.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault();
                            UptCounter++;

                        }
                        ddc.ArticleNo = ws.Cells[ColumnNumber, 1].Text;
                        ddc.DualUseSite = ws.Cells[ColumnNumber, 2].Text;
                        ddc.LicenceType = ws.Cells[ColumnNumber, 3].Text;
                        ddc.ControlClass = ws.Cells[ColumnNumber, 4].Text;


                        if (IME.DualUses.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() == null)
                        {
                            IME.DualUses.Add(ddc);
                            AddedCounter++;
                        }
                        IME.SaveChanges();
                        ddc = new DualUse();
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
                        Hazardou ddc = new Hazardou();
                        if (IME.Hazardous.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() != null)
                        {
                            //UPDATE

                            ddc = IME.Hazardous.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault();
                            UptCounter++;
                        }
                        ddc.ArticleNo = ws.Cells[ColumnNumber, 3].Text;

                        if (ws.Cells[ColumnNumber, 4].Text != "") { ddc.Occurrences = Int32.Parse(ws.Cells[ColumnNumber, 4].Text); }
                        if (ws.Cells[ColumnNumber, 5].Text != "") { ddc.Environment = Int32.Parse(ws.Cells[ColumnNumber, 5].Text); }
                        ddc.Shipping = ws.Cells[ColumnNumber, 6].Text;
                        ddc.Lithium = ws.Cells[ColumnNumber, 7].Text;


                        if (IME.Hazardous.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() == null)
                        {
                            IME.Hazardous.Add(ddc);
                            AddedCounter++;
                        }
                        IME.SaveChanges();
                        ddc = new Hazardou();
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
                    while (ws.Cells[ColumnNumber - 1, RowNumber].Text != "" || RowNumber < 33)
                    {
                        Columns.Add(ws.Cells[ColumnNumber - 1, RowNumber].Text);
                        RowNumber++;
                    }
                    //
                    string ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
                    while (ArticleNumb != "")
                    {
                        ExtendedRange ddc = new ExtendedRange();
                        if (IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() != null)
                        {
                            //UPDATE
                            ddc = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault();

                        }

                        //FILLER
                        //Bu kod extendedranges için bir tane nesenyi dolduruyor
                        int Rownb = 1;
                        while (ws.Cells[ColumnNumber, Rownb].Text != "" || Rownb < (Columns.Count - 1))
                        {
                            switch (Columns[Rownb - 1])
                            {
                                case "ArticleNo":
                                    ddc.ArticleNo = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Manufacturer Code":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.ManufacturerCode = ws.Cells[ColumnNumber, Rownb].Text; }
                                    break;
                                case "Brand":
                                    ddc.Brand = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "MPN":
                                    ddc.MPN = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "ArticleDescription (40 Char Description)":
                                    ddc.ArticleDescription = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Length":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.ExtendedRangeLength = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Width":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Width = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Height":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Height = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Dimension UoM":
                                    ddc.DimensionUoM = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Weight":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.ExtendedRangeWeight = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Weight UoM":
                                    ddc.WeightUoM = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "CCCN":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.CCCN = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Country of Origin":
                                    ddc.CountryofOrigin = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Unit of Measure":
                                    ddc.UnitofMeasure = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Pack Size":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.PackSize = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "(Sales UoM)":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.SalesUoM = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Cost price currency":
                                    ddc.CostPriceCurrency = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Col1Price":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col1Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Col2Price":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col2Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Col3Price":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col3Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Col4Price":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col4Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Col5Price":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col5Price = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Col1Break":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col1Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Col2Break":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col2Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Col3Break":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col3Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Col4Break":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col4Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "Col5Break":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Col5Break = Int32.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "DiscountedPrice1":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.DiscountedPrice1 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "DiscountedPrice2":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.DiscountedPrice2 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "DiscountedPrice3":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.DiscountedPrice3 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "DiscountedPrice4":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.DiscountedPrice4 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "DiscountedPrice5":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.DiscountedPrice5 = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "":
                                    break;
                            }
                            Rownb++;
                        }
                        //Yeni bir dosya eklemek için
                        if (IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() == null)
                        {
                            IME.ExtendedRanges.Add(ddc);
                            AddedCounter++;
                        }
                        else { UptCounter++; }

                        IME.SaveChanges();
                        ddc = new ExtendedRange();
                        ColumnNumber++;
                        ArticleNumb = ws.Cells[ColumnNumber, 1].Text;
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

                        RSPro ddc = new RSPro();
                        if (IME.RSProes.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() != null)
                        {
                            //UPDATE
                            ddc = IME.RSProes.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault();

                        }

                        //FILLER
                        //Bu kod extendedranges için bir tane nesenyi dolduruyor
                        int Rownb = 1;
                        while (ws.Cells[ColumnNumber, Rownb].Text != "" || Rownb < Columns.Count - 1)
                        {
                            switch (Columns[Rownb - 1])
                            {
                                case "Article":
                                    ddc.ArticleNo = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Description":
                                    ddc.RsProDesc = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Width":
                                    ddc.Width = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Gross Weight":
                                    ddc.GrossWeight = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Height":
                                    ddc.Height = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Length":
                                    ddc.Lenght = ws.Cells[ColumnNumber, Rownb].Text;
                                    break;
                                case "Volume":
                                    if (ws.Cells[ColumnNumber, Rownb].Text != "") { ddc.Volume = Decimal.Parse(ws.Cells[ColumnNumber, Rownb].Text); }
                                    break;
                                case "":
                                    if (ddc.RsProDesc != "") { ddc.RsProDesc = ws.Cells[ColumnNumber, Rownb].Text; }
                                    break;
                            }
                            Rownb++;

                        }
                        //Yeni bir dosya eklemek için
                        if (IME.RSProes.Where(a => a.ArticleNo == ArticleNumb).FirstOrDefault() == null)
                        {
                            IME.RSProes.Add(ddc);
                            AddedCounter++;
                        }
                        else { UptCounter++; }

                        IME.SaveChanges();
                        ddc = new RSPro();
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
    }
    class QuotationExcelExport
    {
        public static void Export(DataGridView dg,string quotationNo)
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
                xlWorkSheet.Cells[1, j + 1] = dg.Columns[j].Name;
            }
            for (int i = 0; i <= dg.RowCount - 2; i++)
            {
                for (int j = 0; j <= dg.ColumnCount - 1; j++)
                {
                    if (dg.Rows[i].Cells[j].Value != null) { xlWorkSheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString(); }
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
