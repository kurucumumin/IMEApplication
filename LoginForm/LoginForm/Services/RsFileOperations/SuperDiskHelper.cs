using LoginForm.DataSet;
using LoginForm.MyClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Services
{
    class SuperDiskHelper
    {
        public string FileName;
        private string[] ColumnNames;

        public void SuperDiskLoader()
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileName = openFileDialog1.SafeFileName;
                string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                ColumnNames = lines[0].Split('|');
                LoaderError ColumnError = SuperDiskColumnCheck(ColumnNames);


                //Eğer SuperDisk dosyasında sütun isimlerinde hata varsa
                if (ColumnError.ErrorList.Count() > 0)
                {
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.Append("Error(s) exist in column names, Check SuperDisk file again").AppendLine().AppendLine();

                    foreach (string error in ColumnError.ErrorList)
                    {
                        errorMessage.Append("'").Append(error).Append("'");
                        if (ColumnError.ErrorList.FindIndex(x => x == error) != (ColumnError.ErrorList.Count - 1))
                        {
                            errorMessage.AppendLine();
                        }
                    }
                    errorMessage.AppendLine();
                    MessageBox.Show(errorMessage.ToString(), "Warning!");
                }
                //Sütun isimlerinde hata yoksa
                else /*if(r.ErrorList.Count() == 0)*/
                {
                    LoaderError LineError = CheckLinesForErrors(lines);
                    //Satırlarda hata varsa
                    if (LineError.ErrorList.Count > 0)
                    {
                        //MessageBox'ta göstermek için sınırlı sayıda hatayı içeren yazıyı oluşturur
                        StringBuilder errorMessage = new StringBuilder();
                        errorMessage.Append("Error(s) exist in item rows, Check SuperDisk file again").AppendLine().AppendLine();

                        for (int i = 0; i< LineError.ErrorList.Count; i++)
                        {
                            errorMessage.Append(LineError.ErrorList[i]);
                            if (i < LineError.ErrorList.Count-1)
                            {
                                errorMessage.AppendLine();
                            }
                            if ((i+1) == 20)
                            {
                                errorMessage.Append("...");
                                break;
                            }
                        }
                        errorMessage.AppendLine().AppendLine();

                        
                        if(MessageBox.Show(errorMessage.ToString() + "Open Details?", "Warning!",MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //Tüm hatalar görüntülenmek istenirse 
                            StringBuilder errorLog = new StringBuilder();
                            for (int i = 0; i < LineError.ErrorList.Count; i++)
                            {
                                errorLog.Append(LineError.ErrorList[i]);
                                if (i < LineError.ErrorList.Count - 1)
                                {
                                    errorLog.AppendLine();
                                }
                            }
                            Directory.CreateDirectory("ErrorLogs");
                            File.WriteAllText("ErrorLogs/ErrorLog_"+FileName, errorLog.ToString());
                            Process.Start("notepad.exe", "ErrorLogs/ErrorLog_" + FileName);
                        }
                    }
                    //Satırlarda hata yoksa
                    else if(LineError.ErrorList.Count == 0)
                    {
                        /*Save SuperDisk*/
                        MessageBox.Show("No Error");
                    }else if (LineError == null)
                    {
                        MessageBox.Show("Proccess Cancelled");
                    }
                }
            }
            else
            {
                MessageBox.Show("File Not Choosen","No File");
            }
        }

        private LoaderError CheckLinesForErrors(string[] SuperDiskLines)
        {
            LoaderError error = new LoaderError();

            string[] wordcontrol = SuperDiskLines[1].Split('|');
            if (!wordcontrol[0].Contains("P"))
            {
                for (int i = 1; i < SuperDiskLines.Count(); i++)
                {
                    string[] lineColumns = SuperDiskLines[i].Split('|');
                    bool ErrorExist = false;
                    List<string> faultyColumns = new List<string>();

                    for (int j = 0; j < lineColumns.Count(); j++)
                    {
                        ColumnNames[j] = ColumnNames[j].Replace(" ", "_");

                        switch (ColumnNames[j])
                        {
                            case "Article_No":
                                if (lineColumns[j].Length != 7)
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                }
                                else if (!Int32.TryParse(lineColumns[j], out int tempInt))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                };
                                break;
                            case "Pack_Quantity":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty1))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                }
                                else if (Int32.Parse(lineColumns[j]) == 0)
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                }
                                break;
                            case "Unit_Content":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty2))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                }
                                else if (Int32.Parse(lineColumns[j]) == 0)
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                }
                                break;
                            case "Standard_Weight":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty3))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                }
                                break;
                            case "Height":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty4))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                }
                                break;
                            case "Width":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty5))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                }
                                break;
                            case "Length":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty6))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(ColumnNames[j]);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    if (ErrorExist)
                    {
                        string faultyColumnString = String.Empty;
                        for (int k = 0; k < faultyColumns.Count; k++)
                        {
                            faultyColumnString += faultyColumns[k];
                            if (k != faultyColumns.Count - 1)
                            {
                                faultyColumnString += ", ";
                            }
                        }
                        error.ErrorList.Add("-Row " + (i + 1).ToString() + ", " + "ArticleNo: " + lineColumns[0] + ", Columns: " + faultyColumnString);
                    }

                }
            }
            else
            {
                error.ErrorList.Add("File Not Correct. File appears to be SuperDiskP file!");
            }
            return error;
        }

        private LoaderError SuperDiskColumnCheck(string[] Columns)
        {
            LoaderError error = new LoaderError();
            
            if (Columns[0] != "Article No") error.ErrorList.Add(Columns[0]);
            if (Columns[1] != "Article Desc") error.ErrorList.Add(Columns[1]);
            if (Columns[2] != "Pack Code") error.ErrorList.Add(Columns[2]);
            if (Columns[3] != "Pack Quantity") error.ErrorList.Add(Columns[3]);
            if (Columns[4] != "Unit Content") error.ErrorList.Add(Columns[4]);
            if (Columns[5] != "Unit Measure") error.ErrorList.Add(Columns[5]);
            if (Columns[6] != "Uk Col 1") error.ErrorList.Add(Columns[6]);
            if (Columns[7] != "Standard Weight") error.ErrorList.Add(Columns[7]);
            if (Columns[8] != "Hazardous Ind") error.ErrorList.Add(Columns[8]);
            if (Columns[9] != "Calibration Ind") error.ErrorList.Add(Columns[9]);
            if (Columns[10] != "Obsolete Flag") error.ErrorList.Add(Columns[10]);
            if (Columns[11] != "MH1") error.ErrorList.Add(Columns[11]);
            if (Columns[12] != "Low Discount Ind") error.ErrorList.Add(Columns[12]);
            if (Columns[13] != "Licensed Ind") error.ErrorList.Add(Columns[13]);
            if (Columns[14] != "Shelf Life") error.ErrorList.Add(Columns[14]);
            if (Columns[15] != "CofO") error.ErrorList.Add(Columns[15]);
            if (Columns[16] != "EUR1 Indicator") error.ErrorList.Add(Columns[16]);
            if (Columns[17] != "CCCN No") error.ErrorList.Add(Columns[17]);
            if (Columns[18] != "Supercede Date") error.ErrorList.Add(Columns[18]);
            if (Columns[19] != "Current Cat page") error.ErrorList.Add(Columns[19]);
            if (Columns[20] != "Uk Intro Date") error.ErrorList.Add(Columns[20]);
            if (Columns[21] != "Filler") error.ErrorList.Add(Columns[21]);
            if (Columns[22] != "Uk Disc Date") error.ErrorList.Add(Columns[22]);
            if (Columns[23] != "Substitute By") error.ErrorList.Add(Columns[23]);
            if (Columns[24] != "BHC Flag") error.ErrorList.Add(Columns[24]);
            if (Columns[25] != "Filler1") error.ErrorList.Add(Columns[25]);
            if (Columns[26] != "Future Sell Price") error.ErrorList.Add(Columns[26]);
            if (Columns[27] != "Int Cat") error.ErrorList.Add(Columns[27]);
            if (Columns[28] != "New Prod Change Ind") error.ErrorList.Add(Columns[28]);
            if (Columns[29] != "Out of Stock Prohibit change ind") error.ErrorList.Add(Columns[29]);
            if (Columns[30] != "Disc Change Ind") error.ErrorList.Add(Columns[30]);
            if (Columns[31] != "Superceded Change Ind") error.ErrorList.Add(Columns[31]);
            if (Columns[32] != "Pack Size Change Ind") error.ErrorList.Add(Columns[32]);
            if (Columns[33] != "Rolled Product Change Ind") error.ErrorList.Add(Columns[33]);
            if (Columns[34] != "Expiring Product Change Ind") error.ErrorList.Add(Columns[34]);
            if (Columns[35] != "Manufacturer") error.ErrorList.Add(Columns[35]);
            if (Columns[36] != "MPN") error.ErrorList.Add(Columns[36]);
            if (Columns[37] != "MH Code Level 1") error.ErrorList.Add(Columns[37]);
            if (Columns[38] != "Height") error.ErrorList.Add(Columns[38]);
            if (Columns[39] != "Width") error.ErrorList.Add(Columns[39]);
            if (Columns[40] != "Length") error.ErrorList.Add(Columns[40]);

            return error;
        }

        //public static string[] SuperDiskRead()
        //{
        //    #region Superdisk
        //    int a = 1;
        //    string[] returnObject = new string[2];
        //    IMEEntities IME = new IMEEntities();
        //    SuperDisk Superdiskitems = new SuperDisk();
        //    //Show the dialog and get result.
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    openFileDialog1.Filter = "txt files (*.txt)|*.txt";
        //    DialogResult result1 = openFileDialog1.ShowDialog();

        //    int UptCounter = 0;
        //    int AddedCounter = 0;
        //    if (result1 == DialogResult.OK) // Test result.
        //    {
        //        returnObject[(int)LoaderResultColumns.FileName] = openFileDialog1.FileName;
        //        //try
        //        //{
        //        string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
        //        string[] columnnames = lines[0].Split('|');
        //        string[] wordcontrol;
        //        bool isArrayTrue = true;

        //        SuperDisk s = new SuperDisk();
        //        //if(columnnames[0].Replace(" ","_") == nameof(s.Article_No))

        //        if (columnnames[0] != "Article No") isArrayTrue = false;
        //        if (columnnames[1] != "Article Desc") isArrayTrue = false;
        //        if (columnnames[2] != "Pack Code") isArrayTrue = false;
        //        if (columnnames[3] != "Pack Quantity") isArrayTrue = false;
        //        if (columnnames[4] != "Unit Content") isArrayTrue = false;
        //        if (columnnames[5] != "Unit Measure") isArrayTrue = false;
        //        if (columnnames[6] != "Uk Col 1") isArrayTrue = false;
        //        if (columnnames[7] != "Standard Weight") isArrayTrue = false;
        //        if (columnnames[8] != "Hazardous Ind") isArrayTrue = false;
        //        if (columnnames[9] != "Calibration Ind") isArrayTrue = false;
        //        if (columnnames[10] != "Obsolete Flag") isArrayTrue = false;
        //        if (columnnames[11] != "MH1") isArrayTrue = false;
        //        if (columnnames[12] != "Low Discount Ind") isArrayTrue = false;
        //        if (columnnames[13] != "Licensed Ind") isArrayTrue = false;
        //        if (columnnames[14] != "Shelf Life") isArrayTrue = false;
        //        if (columnnames[15] != "CofO") isArrayTrue = false;
        //        if (columnnames[16] != "EUR1 Indicator") isArrayTrue = false;
        //        if (columnnames[17] != "CCCN No") isArrayTrue = false;
        //        if (columnnames[18] != "Supercede Date") isArrayTrue = false;
        //        if (columnnames[19] != "Current Cat page") isArrayTrue = false;
        //        if (columnnames[20] != "Uk Intro Date") isArrayTrue = false;
        //        if (columnnames[21] != "Filler") isArrayTrue = false;
        //        if (columnnames[22] != "Uk Disc Date") isArrayTrue = false;
        //        if (columnnames[23] != "Substitute By") isArrayTrue = false;
        //        if (columnnames[24] != "BHC Flag") isArrayTrue = false;
        //        if (columnnames[25] != "Filler1") isArrayTrue = false;
        //        if (columnnames[26] != "Future Sell Price") isArrayTrue = false;
        //        if (columnnames[27] != "Int Cat") isArrayTrue = false;
        //        if (columnnames[28] != "New Prod Change Ind") isArrayTrue = false;
        //        if (columnnames[29] != "Out of Stock Prohibit change ind") isArrayTrue = false;
        //        if (columnnames[30] != "Disc Change Ind") isArrayTrue = false;
        //        if (columnnames[31] != "Superceded Change Ind") isArrayTrue = false;
        //        if (columnnames[32] != "Pack Size Change Ind") isArrayTrue = false;
        //        if (columnnames[33] != "Rolled Product Change Ind") isArrayTrue = false;
        //        if (columnnames[34] != "Expiring Product Change Ind") isArrayTrue = false;
        //        if (columnnames[35] != "Manufacturer") isArrayTrue = false;
        //        if (columnnames[36] != "MPN") isArrayTrue = false;
        //        if (columnnames[37] != "MH Code Level 1") isArrayTrue = false;
        //        if (columnnames[38] != "Height") isArrayTrue = false;
        //        if (columnnames[39] != "Width") isArrayTrue = false;
        //        if (columnnames[40] != "Length") isArrayTrue = false;

        //        wordcontrol = lines[1].Split('|');
        //        if (!wordcontrol[0].Contains("P"))
        //        {

        //            if (!isArrayTrue)
        //            {
        //                while (lines.Count() > a)
        //                {
        //                    #region isArrayFalse
        //                    string[] word;
        //                    word = lines[a].Split('|');
        //                    for (int i = 0; i < columnnames.Count(); i++)
        //                    {

        //                        columnnames[i] = columnnames[i].Replace(" ", "_");
        //                        //burada Superdiskitems diye bir ITEM nesnesini dolduruyoruz
        //                        switch (columnnames[i])
        //                        {
        //                            case "Article_Desc":
        //                                Superdiskitems.Article_Desc = word[i];
        //                                break;
        //                            case "Article_No":
        //                                Superdiskitems.Article_No = word[i];
        //                                break;
        //                            case "BHC_Flag":
        //                                Superdiskitems.BHC_Flag = word[i];
        //                                break;
        //                            case "Calibration_Ind":
        //                                Superdiskitems.Calibration_Ind = word[i];
        //                                break;
        //                            case "CCCN_No":
        //                                Superdiskitems.CCCN_No = word[i];
        //                                break;
        //                            case "CofO":
        //                                Superdiskitems.CofO = word[i];
        //                                break;
        //                            case "Current_Cat_page":
        //                                Superdiskitems.Current_Cat_page = word[i];
        //                                break;
        //                            case "Disc_Change_Ind":
        //                                Superdiskitems.Disc_Change_Ind = word[i];
        //                                break;
        //                            case "EUR1_Indicator":
        //                                Superdiskitems.EUR1_Indicator = word[i];
        //                                break;
        //                            case "Expiring_Product_Change_Ind":
        //                                Superdiskitems.Expiring_Product_Change_Ind = word[i];
        //                                break;
        //                            case "Filler":
        //                                Superdiskitems.Filler = word[i];
        //                                break;
        //                            case "Filler1":
        //                                Superdiskitems.Filler1 = word[i];
        //                                break;
        //                            case "Future_Sell_Price":
        //                                if (word[i] != "")
        //                                {
        //                                    Superdiskitems.Future_Sell_Price = decimal.Parse(word[i]);
        //                                }
        //                                break;
        //                            case "Hazardous_Ind":
        //                                Superdiskitems.Hazardous_Ind = word[i];
        //                                break;
        //                            case "Height":
        //                                if (word[i] != "")
        //                                {
        //                                    Superdiskitems.Heigh = decimal.Parse(word[i]);
        //                                }
        //                                break;
        //                            case "Int_Cat":
        //                                Superdiskitems.Int_Cat = word[i];
        //                                break;
        //                            case "Length":
        //                                if (word[i] != "")
        //                                {
        //                                    Superdiskitems.Length = decimal.Parse(word[i]);
        //                                }
        //                                break;
        //                            case "Licensed_Ind":
        //                                Superdiskitems.Licensed_Ind = word[i];
        //                                break;
        //                            case "Low_Discount_Ind":
        //                                Superdiskitems.Low_Discount_Ind = word[i];
        //                                break;
        //                            case "Manufacturer":
        //                                Superdiskitems.Manufacturer = word[i];
        //                                break;
        //                            case "MH1":
        //                                Superdiskitems.MH1 = word[i];
        //                                break;
        //                            case "MH_Code_Level_1":
        //                                Superdiskitems.MH_Code_Level_1 = word[i];
        //                                break;
        //                            case "MPN":
        //                                Superdiskitems.MPN = word[i];
        //                                break;
        //                            case "New_Prod_Change_Ind":
        //                                Superdiskitems.New_Prod_Change_Ind = word[i];
        //                                break;
        //                            case "Obsolete_Flag":
        //                                Superdiskitems.Obsolete_Flag = word[i];
        //                                break;
        //                            case "Out_of_Stock_Prohibit_change_ind":
        //                                Superdiskitems.Out_of_Stock_Prohibit_change_ind = word[i];
        //                                break;
        //                            case "Pack_Code":
        //                                if (word[i] != "")
        //                                {
        //                                    Superdiskitems.Pack_Code = Int32.Parse(word[i]);
        //                                }
        //                                break;
        //                            case "Pack_Quantity":
        //                                if (word[i] != "")
        //                                {
        //                                    Superdiskitems.Pack_Quantity = Int32.Parse(word[i]);
        //                                }
        //                                break;
        //                            case "Pack_Size_Change_Ind":
        //                                Superdiskitems.Pack_Size_Change_Ind = word[i];
        //                                break;
        //                            case "Rolled_Product_Change_Ind":
        //                                Superdiskitems.Rolled_Product_Change_Ind = word[i];
        //                                break;
        //                            case "Shelf_Life":
        //                                Superdiskitems.Shelf_Life = word[i];
        //                                break;
        //                            case "Standard_Weight":
        //                                if (word[i] != "")
        //                                {
        //                                    Superdiskitems.Standard_Weight = Int32.Parse(word[i]);
        //                                }
        //                                break;
        //                            case "Substitute_By":
        //                                Superdiskitems.Substitute_By = word[i];
        //                                break;
        //                            case "Superceded_Change_Ind":
        //                                Superdiskitems.Superceded_Change_Ind = word[i];
        //                                break;
        //                            case "Supercede_Date":
        //                                Superdiskitems.Supercede_Date = word[i];
        //                                break;
        //                            case "Uk_Col_1":
        //                                if (word[i] != "")
        //                                {
        //                                    Superdiskitems.Uk_Col_1 = decimal.Parse(word[i]);
        //                                }
        //                                break;
        //                            case "Uk_Disc_Date":
        //                                Superdiskitems.Uk_Disc_Date = word[i];
        //                                break;
        //                            case "Uk_Intro_Date":
        //                                Superdiskitems.Uk_Intro_Date = word[i];
        //                                break;
        //                            case "Unit_Content":
        //                                if (word[i] != "")
        //                                {
        //                                    Superdiskitems.Unit_Content = Int32.Parse(word[i]);
        //                                }
        //                                break;
        //                            case "Unit_Measure":
        //                                Superdiskitems.Unit_Measure = word[i];
        //                                break;
        //                            case "Width":
        //                                if (word[i] != "")
        //                                {
        //                                    Superdiskitems.Width = decimal.Parse(word[i]);
        //                                }
        //                                break;
        //                        }
        //                    }

        //                    IME.SuperDiskAdd(
        //                          Superdiskitems.Article_No,
        //                 Superdiskitems.Article_Desc,
        //                 Superdiskitems.Pack_Code,
        //                 Superdiskitems.Pack_Quantity,
        //                 Superdiskitems.Unit_Content,
        //                 Superdiskitems.Unit_Measure,
        //                 Superdiskitems.Uk_Col_1,
        //                 Superdiskitems.Standard_Weight,
        //                 Superdiskitems.Hazardous_Ind,
        //                 Superdiskitems.Calibration_Ind,
        //                 Superdiskitems.Obsolete_Flag,
        //                 Superdiskitems.MH1,
        //                 Superdiskitems.Low_Discount_Ind,
        //                 Superdiskitems.Licensed_Ind,
        //                 Superdiskitems.Shelf_Life,
        //                 Superdiskitems.CofO,
        //                 Superdiskitems.EUR1_Indicator,
        //                 Superdiskitems.CCCN_No,
        //                 Superdiskitems.Supercede_Date,
        //                 Superdiskitems.Current_Cat_page,
        //                 Superdiskitems.Uk_Intro_Date,
        //                 Superdiskitems.Filler,
        //                 Superdiskitems.Uk_Disc_Date,
        //                 Superdiskitems.Substitute_By,
        //                 Superdiskitems.BHC_Flag,
        //                 Superdiskitems.Filler1,
        //                 Superdiskitems.Future_Sell_Price,
        //                 Superdiskitems.Int_Cat,
        //                 Superdiskitems.New_Prod_Change_Ind,
        //                 Superdiskitems.Out_of_Stock_Prohibit_change_ind,
        //                 Superdiskitems.Disc_Change_Ind,
        //                 Superdiskitems.Superceded_Change_Ind,
        //                 Superdiskitems.Pack_Size_Change_Ind,
        //                 Superdiskitems.Rolled_Product_Change_Ind,
        //                 Superdiskitems.Expiring_Product_Change_Ind,
        //                 Superdiskitems.Manufacturer,
        //                 Superdiskitems.MPN,
        //                 Superdiskitems.MH_Code_Level_1,
        //                 Superdiskitems.Heigh,
        //                 Superdiskitems.Width,
        //                 Superdiskitems.Length);
        //                    a++;
        //                }

        //                #endregion
        //            }
        //            else
        //            {
        //                while (lines.Count() > a)
        //                {
        //                    string[] word;
        //                    word = lines[a].Split('|');
        //                    //superdisk ADD
        //                    SuperDisk s = new SuperDisk();
        //                    s.Article_No = word[0];
        //                    s.Article_Desc = word[1];
        //                    if (word[2] != "") s.Pack_Code = Int32.Parse(word[2]);
        //                    if (word[3] != "") s.Pack_Quantity = Int32.Parse(word[3]);
        //                    if (word[4] != "") s.Unit_Content = Int32.Parse(word[4]);
        //                    s.Unit_Measure = word[5];
        //                    if (word[6] != "") s.Uk_Col_1 = decimal.Parse(word[6]);
        //                    if (word[7] != "") s.Standard_Weight = Int32.Parse(word[7]);
        //                    s.Hazardous_Ind = word[8];
        //                    s.Calibration_Ind = word[9];
        //                    s.Obsolete_Flag = word[10];
        //                    s.MH1 = word[11];
        //                    s.Low_Discount_Ind = word[12];
        //                    s.Licensed_Ind = word[13];
        //                    s.Shelf_Life = word[14];
        //                    s.CofO = word[15];
        //                    s.EUR1_Indicator = word[16];
        //                    s.CCCN_No = word[17];
        //                    s.Supercede_Date = word[18];
        //                    s.Current_Cat_page = word[19];
        //                    s.Uk_Intro_Date = word[20];
        //                    s.Filler = word[21];
        //                    s.Uk_Disc_Date = word[22];
        //                    s.Substitute_By = word[23];
        //                    s.BHC_Flag = word[24];
        //                    s.Filler1 = word[25];
        //                    if (word[26] != "") s.Future_Sell_Price = decimal.Parse(word[26]);
        //                    s.Int_Cat = word[27];
        //                    s.New_Prod_Change_Ind = word[28];
        //                    s.Out_of_Stock_Prohibit_change_ind = word[29];
        //                    s.Disc_Change_Ind = word[30];
        //                    s.Superceded_Change_Ind = word[31];
        //                    s.Pack_Size_Change_Ind = word[32];
        //                    s.Rolled_Product_Change_Ind = word[33];
        //                    s.Expiring_Product_Change_Ind = word[34];
        //                    s.Manufacturer = word[35];
        //                    s.MPN = word[36];
        //                    s.MH_Code_Level_1 = word[37];
        //                    if (word[38] != "") s.Heigh = decimal.Parse(word[38]);
        //                    if (word[39] != "") s.Width = decimal.Parse(word[39]);
        //                    if (word[40] != "") s.Length = decimal.Parse(word[40]);

        //                    IME.SuperDiskAdd(
        //                         s.Article_No,
        //                s.Article_Desc,
        //                s.Pack_Code,
        //                s.Pack_Quantity,
        //                s.Unit_Content,
        //                s.Unit_Measure,
        //                s.Uk_Col_1,
        //                s.Standard_Weight,
        //                s.Hazardous_Ind,
        //                s.Calibration_Ind,
        //                s.Obsolete_Flag,
        //                s.MH1,
        //                s.Low_Discount_Ind,
        //                s.Licensed_Ind,
        //                s.Shelf_Life,
        //                s.CofO,
        //                s.EUR1_Indicator,
        //                s.CCCN_No,
        //                s.Supercede_Date,
        //                s.Current_Cat_page,
        //                s.Uk_Intro_Date,
        //                s.Filler,
        //                s.Uk_Disc_Date,
        //                s.Substitute_By,
        //                s.BHC_Flag,
        //                s.Filler1,
        //                s.Future_Sell_Price,
        //                s.Int_Cat,
        //                s.New_Prod_Change_Ind,
        //                s.Out_of_Stock_Prohibit_change_ind,
        //                s.Disc_Change_Ind,
        //                s.Superceded_Change_Ind,
        //                s.Pack_Size_Change_Ind,
        //                s.Rolled_Product_Change_Ind,
        //                s.Expiring_Product_Change_Ind,
        //                s.Manufacturer,
        //                s.MPN,
        //                s.MH_Code_Level_1,
        //                s.Heigh,
        //                s.Width,
        //                s.Length);
        //                    a++;
        //                }
        //            }
        //            MessageBox.Show("Upload Completed");
        //            returnObject[(int)LoaderResultColumns.Result] = "1";
        //            return returnObject;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please Choose Correct File");
        //            returnObject[(int)LoaderResultColumns.Result] = "0";
        //            return returnObject;
        //        }
        //        //}
        //        //catch (Exception ex) { MessageBox.Show(ex.Message); MessageBox.Show(a.ToString()); return 0; }
        //        #endregion
        //    }
        //    returnObject[(int)LoaderResultColumns.Result] = "0";
        //    return returnObject;
        //}

    }
}
