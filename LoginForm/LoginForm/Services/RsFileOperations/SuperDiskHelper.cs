using LoginForm.DataSet;
using LoginForm.MyClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
        private List<string> _ColumnNames;
        private List<string> _Lines;
        private OpenFileDialog _FileDialog;

        public SuperDiskHelper()
        {
            _FileDialog = new OpenFileDialog();
            _FileDialog.Filter = "txt files (*.txt)|*.txt";
        }

        public bool ErrorCheck()
        {
            DialogResult result = _FileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileName = _FileDialog.SafeFileName;
                 _Lines = System.IO.File.ReadAllLines(_FileDialog.FileName).ToList();
                //Arada kalan satır kod seçili olan dosyanın kontroünden sonra yapılmalı
                _ColumnNames = _Lines[0].Split('|').ToList();
                _Lines.RemoveAt(0);
                ReturnMessage ColumnError = SuperDiskColumnCheck(_ColumnNames);


                //Eğer SuperDisk dosyasında sütun isimlerinde hata varsa
                if (ColumnError.MessageList.Count() > 0)
                {
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.Append("Error(s) exist in column names, Check SuperDisk file again").AppendLine().Append("Mis-typed columns are:").AppendLine().AppendLine();

                    foreach (string error in ColumnError.MessageList)
                    {
                        errorMessage.Append(error);
                        if (ColumnError.MessageList.FindIndex(x => x == error) != (ColumnError.MessageList.Count - 1))
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
                    ReturnMessage LineError = CheckLinesForErrors(_Lines);
                    //Satırlarda hata varsa
                    int maxErrorAmount = 20; /*Maksimum 20 hata gösteriliyor MessageBox'ta*/
                    if (LineError.MessageList.Count > 0)
                    {
                        //MessageBox'ta göstermek için sınırlı sayıda hatayı içeren yazıyı oluşturur
                        StringBuilder errorMessage = new StringBuilder();
                        errorMessage.Append("Error(s) exist in item rows, Check SuperDisk file again").AppendLine().AppendLine();

                        for (int i = 0; i< LineError.MessageList.Count; i++)
                        {
                            errorMessage.Append(LineError.MessageList[i]);
                            if (i < LineError.MessageList.Count-1)
                            {
                                errorMessage.AppendLine();
                            }
                            if ((i+1) == maxErrorAmount) /*Bulunan hata sayısı kontrolü*/
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
                            for (int i = 0; i < LineError.MessageList.Count; i++)
                            {
                                errorLog.Append(LineError.MessageList[i]);
                                if (i < LineError.MessageList.Count - 1)
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
                    else if(LineError.MessageList.Count == 0)
                    {
                        return true;
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
            return false;
        }

        private ReturnMessage CheckLinesForErrors(List<string> SuperDiskLines)
        {
            ReturnMessage error = new ReturnMessage();

            string[] wordcontrol = SuperDiskLines[0].Split('|');
            if (!wordcontrol[0].Contains("P"))
            {
                for (int i = 0; i < SuperDiskLines.Count(); i++)
                {
                    string[] lineColumns = SuperDiskLines[i].Split('|');
                    bool ErrorExist = false;
                    List<string> faultyColumns = new List<string>();

                    for (int j = 0; j < lineColumns.Count(); j++)
                    {
                        _ColumnNames[j] = _ColumnNames[j].Replace(" ", "_");

                        switch (_ColumnNames[j])
                        {
                            case "Article_No":
                                if (lineColumns[j].Length != 7)
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
                                }
                                else if (!Int32.TryParse(lineColumns[j], out int tempInt))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
                                };
                                break;
                            case "Pack_Quantity":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty1))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
                                }
                                else if (Int32.Parse(lineColumns[j]) == 0)
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
                                }
                                break;
                            case "Unit_Content":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty2))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
                                }
                                else if (Int32.Parse(lineColumns[j]) == 0)
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
                                }
                                break;
                            case "Standard_Weight":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty3))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
                                }
                                break;
                            case "Height":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty4))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
                                }
                                break;
                            case "Width":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty5))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
                                }
                                break;
                            case "Length":
                                if (!decimal.TryParse(lineColumns[j], out decimal tempQty6))
                                {
                                    ErrorExist = true;
                                    faultyColumns.Add(_ColumnNames[j]);
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
                        error.MessageList.Add("-Line " + (i+2).ToString() + ", " + "ArticleNo: " + lineColumns[0] + ", Columns: " + faultyColumnString);
                    }

                }
            }
            else
            {
                error.MessageList.Add("File Not Correct. File appears to be SuperDiskP file!");
            }
            return error;
        }

        private ReturnMessage SuperDiskColumnCheck(List<string> Columns)
        {
            #region CorrectColumnNames into a List
            List<String> CorrectColumnNames = new List<string>();
            CorrectColumnNames.Add("Article No");
            CorrectColumnNames.Add("Article Desc");
            CorrectColumnNames.Add("Pack Code");
            CorrectColumnNames.Add("Pack Quantity");
            CorrectColumnNames.Add("Unit Content");
            CorrectColumnNames.Add("Unit Measure");
            CorrectColumnNames.Add("Uk Col 1");
            CorrectColumnNames.Add("Standard Weight");
            CorrectColumnNames.Add("Hazardous Ind");
            CorrectColumnNames.Add("Calibration Ind");
            CorrectColumnNames.Add("Obsolete Flag");
            CorrectColumnNames.Add("MH1");
            CorrectColumnNames.Add("Low Discount Ind");
            CorrectColumnNames.Add("Licensed Ind");
            CorrectColumnNames.Add("Shelf Life");
            CorrectColumnNames.Add("CofO");
            CorrectColumnNames.Add("EUR1 Indicator");
            CorrectColumnNames.Add("CCCN No");
            CorrectColumnNames.Add("Supercede Date");
            CorrectColumnNames.Add("Current Cat page");
            CorrectColumnNames.Add("Uk Intro Date");
            CorrectColumnNames.Add("Filler");
            CorrectColumnNames.Add("Uk Disc Date");
            CorrectColumnNames.Add("Substitute By");
            CorrectColumnNames.Add("BHC Flag");
            CorrectColumnNames.Add("Filler1");
            CorrectColumnNames.Add("Future Sell Price");
            CorrectColumnNames.Add("Int Cat");
            CorrectColumnNames.Add("New Prod Change Ind");
            CorrectColumnNames.Add("Out of Stock Prohibit change ind");
            CorrectColumnNames.Add("Disc Change Ind");
            CorrectColumnNames.Add("Superceded Change Ind");
            CorrectColumnNames.Add("Pack Size Change Ind");
            CorrectColumnNames.Add("Rolled Product Change Ind");
            CorrectColumnNames.Add("Expiring Product Change Ind");
            CorrectColumnNames.Add("Manufacturer");
            CorrectColumnNames.Add("MPN");
            CorrectColumnNames.Add("MH Code Level 1");
            CorrectColumnNames.Add("Height");
            CorrectColumnNames.Add("Width");
            CorrectColumnNames.Add("Length");
            #endregion
            
            ReturnMessage error = new ReturnMessage();

            int columnCount = 0;
            for (int i = 0; i < Columns.Count; i++)
            {
                switch (Columns[i])
                {
                    case "Article No":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Article Desc":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Pack Code":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Pack Quantity":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Unit Content":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Unit Measure":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Uk Col 1":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Standard Weight":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Hazardous Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Calibration Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Obsolete Flag":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "MH1":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Low Discount Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Licensed Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Shelf Life":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "CofO":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "EUR1 Indicator":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "CCCN No":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Supercede Date":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Current Cat page":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Uk Intro Date":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Filler":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Uk Disc Date":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Substitute By":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "BHC Flag":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Filler1":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Future Sell Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Int Cat":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "New Prod Change Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Out of Stock Prohibit change ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Disc Change Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Superceded Change Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Pack Size Change Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Rolled Product Change Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Expiring Product Change Ind":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Manufacturer":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "MPN":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "MH Code Level 1":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Height":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Width":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Length":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    default:
                        error.MessageList.Add(Columns[i]);
                        break;
                }
                void DeleteColumnAndIncrementColumCount()
                {
                    columnCount += 1;
                    CorrectColumnNames.Remove(Columns[i]);
                }
            }
            //columnCount += error.ErrorList.Count;

            string MissingColumnsString = String.Empty;
            for (int i = 0; i < CorrectColumnNames.Count; i++)
            {
                MissingColumnsString += CorrectColumnNames[i];
                if (i != CorrectColumnNames.Count - 1)
                {
                    MissingColumnsString += ", ";
                }
            }

            if (columnCount != 41)
            {
                error.MessageList.Add("\n"+ error.MessageList.Count + " mismatched columns, " + columnCount + " matched columns found! " + (CorrectColumnNames.Count - error.MessageList.Count)  + " columns missing");
                error.MessageList.Add("\nMissing columns are:\n\n" + MissingColumnsString);
            }
            return error;
        }
        
        public void LoadSuperDiskItems()
        {
            SqlCommand cmd;
            SqlConnection ImeSqlConn = new Utils().ImeSqlConnection();
            SqlTransaction ImeSqlTransaction = ImeSqlConn.BeginTransaction();
            try
            {
                IMEEntities db = new IMEEntities();
                int updatedItemCount = 0;
                int newItemCount = 0;

                foreach (string itemString in _Lines)
                {
                    List<string> itemData = itemString.Split('|').ToList();
                    bool NewItem = false;
                    string ArticleNo = itemData[_ColumnNames.IndexOf("Article_No")];
                    SuperDisk item = db.SuperDisks.Where(x => x.Article_No == ArticleNo).FirstOrDefault();

                    if (item == null)
                    {
                        item = new SuperDisk();
                        NewItem = true;
                    }

                    foreach (string ColumnName in _ColumnNames)
                    {
                        string _itemData = itemData[_ColumnNames.IndexOf(ColumnName)];
                        switch (ColumnName)
                        {
                            case "Article_Desc":
                                item.Article_Desc = _itemData;
                                break;
                            case "Article_No":
                                item.Article_No = _itemData;
                                break;
                            case "BHC_Flag":
                                item.BHC_Flag = _itemData;
                                break;
                            case "Calibration_Ind":
                                item.Calibration_Ind = _itemData;
                                break;
                            case "CCCN_No":
                                item.CCCN_No = _itemData;
                                break;
                            case "CofO":
                                item.CofO = _itemData;
                                break;
                            case "Current_Cat_page":
                                item.Current_Cat_page = _itemData;
                                break;
                            case "Disc_Change_Ind":
                                item.Disc_Change_Ind = _itemData;
                                break;
                            case "EUR1_Indicator":
                                item.EUR1_Indicator = _itemData;
                                break;
                            case "Expiring_Product_Change_Ind":
                                item.Expiring_Product_Change_Ind = _itemData;
                                break;
                            case "Filler":
                                item.Filler = _itemData;
                                break;
                            case "Filler1":
                                item.Filler1 = _itemData;
                                break;
                            case "Future_Sell_Price":
                                if (_itemData != "")
                                {
                                    item.Future_Sell_Price = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Hazardous_Ind":
                                item.Hazardous_Ind = _itemData;
                                break;
                            case "Height":
                                if (_itemData != "")
                                {
                                    item.Heigh = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Int_Cat":
                                item.Int_Cat = _itemData;
                                break;
                            case "Length":
                                if (_itemData != "")
                                {
                                    item.Length = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Licensed_Ind":
                                item.Licensed_Ind = _itemData;
                                break;
                            case "Low_Discount_Ind":
                                item.Low_Discount_Ind = _itemData;
                                break;
                            case "Manufacturer":
                                item.Manufacturer = _itemData;
                                break;
                            case "MH1":
                                item.MH1 = _itemData;
                                break;
                            case "MH_Code_Level_1":
                                item.MH_Code_Level_1 = _itemData;
                                break;
                            case "MPN":
                                item.MPN = _itemData;
                                break;
                            case "New_Prod_Change_Ind":
                                item.New_Prod_Change_Ind = _itemData;
                                break;
                            case "Obsolete_Flag":
                                item.Obsolete_Flag = _itemData;
                                break;
                            case "Out_of_Stock_Prohibit_change_ind":
                                item.Out_of_Stock_Prohibit_change_ind = _itemData;
                                break;
                            case "Pack_Code":
                                if (_itemData != "")
                                {
                                    item.Pack_Code = Convert.ToInt32(_itemData);
                                }
                                break;
                            case "Pack_Quantity":
                                if (_itemData != "")
                                {
                                    item.Pack_Quantity = Convert.ToInt32(_itemData);
                                }
                                break;
                            case "Pack_Size_Change_Ind":
                                item.Pack_Size_Change_Ind = _itemData;
                                break;
                            case "Rolled_Product_Change_Ind":
                                item.Rolled_Product_Change_Ind = _itemData;
                                break;
                            case "Shelf_Life":
                                item.Shelf_Life = _itemData;
                                break;
                            case "Standard_Weight":
                                if (_itemData != "")
                                {
                                    item.Standard_Weight = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Substitute_By":
                                item.Substitute_By = _itemData;
                                break;
                            case "Superceded_Change_Ind":
                                item.Superceded_Change_Ind = _itemData;
                                break;
                            case "Supercede_Date":
                                item.Supercede_Date = _itemData;
                                break;
                            case "Uk_Col_1":
                                if (_itemData != "")
                                {
                                    item.Uk_Col_1 = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Uk_Disc_Date":
                                item.Uk_Disc_Date = _itemData;
                                break;
                            case "Uk_Intro_Date":
                                item.Uk_Intro_Date = _itemData;
                                break;
                            case "Unit_Content":
                                if (_itemData != "")
                                {
                                    item.Unit_Content = Convert.ToInt32(_itemData);
                                }
                                break;
                            case "Unit_Measure":
                                item.Unit_Measure = _itemData;
                                break;
                            case "Width":
                                if (_itemData != "")
                                {
                                    item.Width = Convert.ToDecimal(_itemData);
                                }
                                break;
                        }
                    }

                    if (NewItem)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = ImeSqlConn;
                        cmd.Transaction = ImeSqlTransaction;
                        cmd.CommandText = @"INSERT INTO [dbo].[SuperDisk]
                        ([Article_No], [Article_Desc] ,[Pack_Code] ,[Pack_Quantity] ,[Unit_Content] ,[Unit_Measure] ,[Uk_Col_1], [Standard_Weight], [Hazardous_Ind], [Calibration_Ind], [Obsolete_Flag], [MH1], [Low_Discount_Ind], [Licensed_Ind], [Shelf_Life], [CofO], [EUR1_Indicator], [CCCN_No], [Supercede_Date], [Current_Cat_page], [Uk_Intro_Date], [Filler], [Uk_Disc_Date], [Substitute_By], [BHC_Flag], [Filler1], [Future_Sell_Price], [Int_Cat], [New_Prod_Change_Ind], [Out_of_Stock_Prohibit_change_ind], [Disc_Change_Ind], [Superceded_Change_Ind], [Pack_Size_Change_Ind], [Rolled_Product_Change_Ind], [Expiring_Product_Change_Ind], [Manufacturer], [MPN], [MH_Code_Level_1], [Heigh], [Width], [Length])
                    VALUES
                        (@Article_No, @Article_Desc, @Pack_Code, @Pack_Quantity, @Unit_Content, @Unit_Measure, @Uk_Col_1, @Standard_Weight, @Hazardous_Ind, @Calibration_Ind, @Obsolete_Flag, @MH1, @Low_Discount_Ind, @Licensed_Ind, @Shelf_Life, @CofO, @EUR1_Indicator, @CCCN_No, @Supercede_Date, @Current_Cat_page, @Uk_Intro_Date, @Filler, @Uk_Disc_Date, @Substitute_By, @BHC_Flag, @Filler1, @Future_Sell_Price, @Int_Cat, @New_Prod_Change_Ind, @Out_of_Stock_Prohibit_change_ind, @Disc_Change_Ind, @Superceded_Change_Ind, @Pack_Size_Change_Ind, @Rolled_Product_Change_Ind, @Expiring_Product_Change_Ind, @Manufacturer, @MPN, @MH_Code_Level_1, @Heigh, @Width, @Length)";
                        cmd.Parameters.AddWithValue("@Article_No", item.Article_No);
                        cmd.Parameters.AddWithValue("@Article_Desc", item.Article_Desc);
                        cmd.Parameters.AddWithValue("@Pack_Code", item.Pack_Code);
                        cmd.Parameters.AddWithValue("@Pack_Quantity", item.Pack_Quantity);
                        cmd.Parameters.AddWithValue("@Unit_Content", item.Unit_Content);
                        cmd.Parameters.AddWithValue("@Unit_Measure", item.Unit_Measure);
                        cmd.Parameters.AddWithValue("@Uk_Col_1", item.Uk_Col_1);
                        cmd.Parameters.AddWithValue("@Standard_Weight", item.Standard_Weight);
                        cmd.Parameters.AddWithValue("@Hazardous_Ind", item.Hazardous_Ind);
                        cmd.Parameters.AddWithValue("@Calibration_Ind", item.Calibration_Ind);
                        cmd.Parameters.AddWithValue("@Obsolete_Flag", item.Obsolete_Flag);
                        cmd.Parameters.AddWithValue("@MH1", item.MH1);
                        cmd.Parameters.AddWithValue("@Low_Discount_Ind", item.Low_Discount_Ind);
                        cmd.Parameters.AddWithValue("@Licensed_Ind", item.Licensed_Ind);
                        cmd.Parameters.AddWithValue("@Shelf_Life", item.Shelf_Life);
                        cmd.Parameters.AddWithValue("@CofO", item.CofO);
                        cmd.Parameters.AddWithValue("@EUR1_Indicator", item.EUR1_Indicator);
                        cmd.Parameters.AddWithValue("@CCCN_No", item.CCCN_No);
                        cmd.Parameters.AddWithValue("@Supercede_Date", item.Supercede_Date);
                        cmd.Parameters.AddWithValue("@Current_Cat_page", item.Current_Cat_page);
                        cmd.Parameters.AddWithValue("@Uk_Intro_Date", item.Uk_Intro_Date);
                        cmd.Parameters.AddWithValue("@Filler", item.Filler);
                        cmd.Parameters.AddWithValue("@Uk_Disc_Date", item.Uk_Disc_Date);
                        cmd.Parameters.AddWithValue("@Substitute_By", item.Substitute_By);
                        cmd.Parameters.AddWithValue("@BHC_Flag", item.BHC_Flag);
                        cmd.Parameters.AddWithValue("@Filler1", item.Filler1);
                        cmd.Parameters.AddWithValue("@Future_Sell_Price", item.Future_Sell_Price);
                        cmd.Parameters.AddWithValue("@Int_Cat", item.Int_Cat);
                        cmd.Parameters.AddWithValue("@New_Prod_Change_Ind", item.New_Prod_Change_Ind);
                        cmd.Parameters.AddWithValue("@Out_of_Stock_Prohibit_change_ind", item.Out_of_Stock_Prohibit_change_ind);
                        cmd.Parameters.AddWithValue("@Disc_Change_Ind", item.Disc_Change_Ind);
                        cmd.Parameters.AddWithValue("@Superceded_Change_Ind", item.Superceded_Change_Ind);
                        cmd.Parameters.AddWithValue("@Pack_Size_Change_Ind", item.Pack_Size_Change_Ind);
                        cmd.Parameters.AddWithValue("@Rolled_Product_Change_Ind", item.Rolled_Product_Change_Ind);
                        cmd.Parameters.AddWithValue("@Expiring_Product_Change_Ind", item.Expiring_Product_Change_Ind);
                        cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
                        cmd.Parameters.AddWithValue("@MPN", item.MPN);
                        cmd.Parameters.AddWithValue("@MH_Code_Level_1", item.MH_Code_Level_1);
                        cmd.Parameters.AddWithValue("@Heigh", item.Heigh);
                        cmd.Parameters.AddWithValue("@Width", item.Width);
                        cmd.Parameters.AddWithValue("@Length", item.Length);

                        cmd.ExecuteNonQuery();
                        newItemCount++;
                    }/* Adds a new item to superDisk */
                    else
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = ImeSqlConn;
                        cmd.Transaction = ImeSqlTransaction;
                        cmd.CommandText = @"UPDATE[dbo].[SuperDisk] 
                                            SET [Article_No] = @Article_No, [Article_Desc] = @Article_Desc, [Pack_Code] = @Pack_Code, [Pack_Quantity] = @Pack_Quantity, [Unit_Content] = @Unit_Content, [Unit_Measure] = @Unit_Measure, [Uk_Col_1] = @Uk_Col_1, [Standard_Weight] = @Standard_Weight, [Hazardous_Ind] = @Hazardous_Ind, [Calibration_Ind] = @Calibration_Ind, [Obsolete_Flag] = @Obsolete_Flag, [MH1] = @MH1, [Low_Discount_Ind] = @Low_Discount_Ind, [Licensed_Ind] = @Licensed_Ind, [Shelf_Life] = @Shelf_Life, [CofO] = @CofO, [EUR1_Indicator] = @EUR1_Indicator, [CCCN_No] = @CCCN_No, [Supercede_Date] = @Supercede_Date, [Current_Cat_page] = @Current_Cat_page, [Uk_Intro_Date] = @Uk_Intro_Date, [Filler] = @Filler, [Uk_Disc_Date] = @Uk_Disc_Date, [Substitute_By] = @Substitute_By, [BHC_Flag] = @BHC_Flag, [Filler1] = @Filler1, [Future_Sell_Price] = @Future_Sell_Price, [Int_Cat] = @Int_Cat, [New_Prod_Change_Ind] = @New_Prod_Change_Ind, [Out_of_Stock_Prohibit_change_ind] =@Out_of_Stock_Prohibit_change_ind, [Disc_Change_Ind] = @Disc_Change_Ind, [Superceded_Change_Ind] =@Superceded_Change_Ind, [Pack_Size_Change_Ind] = @Pack_Size_Change_Ind, [Rolled_Product_Change_Ind] = @Rolled_Product_Change_Ind, [Expiring_Product_Change_Ind] = @Expiring_Product_Change_Ind, [Manufacturer] = @Manufacturer, [MPN] =@MPN, [MH_Code_Level_1] = @MH_Code_Level_1, [Heigh] =@Heigh, [Width] = @Width, [Length] = @Length 
                                        WHERE 
                                            SuperDisk.Article_No = @Article_No";
                        cmd.Parameters.AddWithValue("@Article_No", item.Article_No);
                        cmd.Parameters.AddWithValue("@Article_Desc", item.Article_Desc);
                        cmd.Parameters.AddWithValue("@Pack_Code", item.Pack_Code);
                        cmd.Parameters.AddWithValue("@Pack_Quantity", item.Pack_Quantity);
                        cmd.Parameters.AddWithValue("@Unit_Content", item.Unit_Content);
                        cmd.Parameters.AddWithValue("@Unit_Measure", item.Unit_Measure);
                        cmd.Parameters.AddWithValue("@Uk_Col_1", item.Uk_Col_1);
                        cmd.Parameters.AddWithValue("@Standard_Weight", item.Standard_Weight);
                        cmd.Parameters.AddWithValue("@Hazardous_Ind", item.Hazardous_Ind);
                        cmd.Parameters.AddWithValue("@Calibration_Ind", item.Calibration_Ind);
                        cmd.Parameters.AddWithValue("@Obsolete_Flag", item.Obsolete_Flag);
                        cmd.Parameters.AddWithValue("@MH1", item.MH1);
                        cmd.Parameters.AddWithValue("@Low_Discount_Ind", item.Low_Discount_Ind);
                        cmd.Parameters.AddWithValue("@Licensed_Ind", item.Licensed_Ind);
                        cmd.Parameters.AddWithValue("@Shelf_Life", item.Shelf_Life);
                        cmd.Parameters.AddWithValue("@CofO", item.CofO);
                        cmd.Parameters.AddWithValue("@EUR1_Indicator", item.EUR1_Indicator);
                        cmd.Parameters.AddWithValue("@CCCN_No", item.CCCN_No);
                        cmd.Parameters.AddWithValue("@Supercede_Date", item.Supercede_Date);
                        cmd.Parameters.AddWithValue("@Current_Cat_page", item.Current_Cat_page);
                        cmd.Parameters.AddWithValue("@Uk_Intro_Date", item.Uk_Intro_Date);
                        cmd.Parameters.AddWithValue("@Filler", item.Filler);
                        cmd.Parameters.AddWithValue("@Uk_Disc_Date", item.Uk_Disc_Date);
                        cmd.Parameters.AddWithValue("@Substitute_By", item.Substitute_By);
                        cmd.Parameters.AddWithValue("@BHC_Flag", item.BHC_Flag);
                        cmd.Parameters.AddWithValue("@Filler1", item.Filler1);
                        cmd.Parameters.AddWithValue("@Future_Sell_Price", item.Future_Sell_Price);
                        cmd.Parameters.AddWithValue("@Int_Cat", item.Int_Cat);
                        cmd.Parameters.AddWithValue("@New_Prod_Change_Ind", item.New_Prod_Change_Ind);
                        cmd.Parameters.AddWithValue("@Out_of_Stock_Prohibit_change_ind", item.Out_of_Stock_Prohibit_change_ind);
                        cmd.Parameters.AddWithValue("@Disc_Change_Ind", item.Disc_Change_Ind);
                        cmd.Parameters.AddWithValue("@Superceded_Change_Ind", item.Superceded_Change_Ind);
                        cmd.Parameters.AddWithValue("@Pack_Size_Change_Ind", item.Pack_Size_Change_Ind);
                        cmd.Parameters.AddWithValue("@Rolled_Product_Change_Ind", item.Rolled_Product_Change_Ind);
                        cmd.Parameters.AddWithValue("@Expiring_Product_Change_Ind", item.Expiring_Product_Change_Ind);
                        cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
                        cmd.Parameters.AddWithValue("@MPN", item.MPN);
                        cmd.Parameters.AddWithValue("@MH_Code_Level_1", item.MH_Code_Level_1);
                        cmd.Parameters.AddWithValue("@Heigh", item.Heigh);
                        cmd.Parameters.AddWithValue("@Width", item.Width);
                        cmd.Parameters.AddWithValue("@Length", item.Length);

                        cmd.ExecuteNonQuery();
                        updatedItemCount++;
                    }/* Updates the item */
                }

                ImeSqlTransaction.Commit();
                MessageBox.Show(newItemCount + " item is added! " + updatedItemCount + " item is updated!", "Success");
            }
            catch (Exception)
            {
                ImeSqlTransaction.Rollback();
                MessageBox.Show("An error occured while loading SuperDisk! Try again later","Error");
            }
            finally
            {
                ImeSqlConn.Close();
            }
        }
    }
}
