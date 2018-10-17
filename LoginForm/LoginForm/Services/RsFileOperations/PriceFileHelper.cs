using LoginForm.DataSet;
using LoginForm.MyClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginForm.Services
{
    class PriceFileHelper
    {
        public string FileName;
        private List<string> _ColumnNames;
        private List<string> _Lines;
        private OpenFileDialog _FileDialog;
        private Stopwatch _Timer;

        public PriceFileHelper()
        {
            _Timer = new Stopwatch();

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

                _Timer.Start();

                ReturnMessage ColumnError = PriceFileColumnCheck(_ColumnNames);


                //Eğer PriceFile dosyasında sütun isimlerinde hata varsa
                if (ColumnError.MessageList.Count() > 0)
                {
                    _Timer.Stop();
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.Append("Error(s) exist in column names, Check PriceFile file again").AppendLine().Append("Mis-typed columns are:").AppendLine().AppendLine();

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
                    _Timer.Stop();
                    //Satırlarda hata varsa
                    int maxShownErrorAmount = 15; /* MessageBox'ta gösterilen maksimum hata sayısını belirler*/
                    if (LineError.MessageList.Count > 0)
                    {
                        //MessageBox'ta göstermek için sınırlı sayıda hatayı içeren yazıyı oluşturur
                        StringBuilder errorMessage = new StringBuilder();
                        errorMessage.Append("Passed Time: " + _Timer.Elapsed.ToString(@"hh\:mm\:ss") + " sn" + "\n\n" + "Error(s) exist in item rows, Check PriceFile file again").AppendLine().AppendLine();

                        for (int i = 0; i < LineError.MessageList.Count; i++)
                        {
                            errorMessage.Append(LineError.MessageList[i]);
                            if (i < LineError.MessageList.Count - 1)
                            {
                                errorMessage.AppendLine();
                            }
                            if ((i + 1) == maxShownErrorAmount)
                            {
                                errorMessage.Append("...");
                                break;
                            } /*Bulunan hata sayısı kontrolü*/
                        }
                        errorMessage.AppendLine().AppendLine();


                        if (MessageBox.Show(errorMessage.ToString() + "Open Details?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                            File.WriteAllText("ErrorLogs/ErrorLog_" + FileName, errorLog.ToString());
                            Process.Start("notepad.exe", "ErrorLogs/ErrorLog_" + FileName);
                        }
                    }
                    //Satırlarda hata yoksa
                    else if (LineError.MessageList.Count == 0)
                    {
                        return true;
                    }
                    else if (LineError == null)
                    {
                        MessageBox.Show("Proccess Cancelled");
                    }
                }
            }
            else
            {
                MessageBox.Show("File Not Choosen", "No File");
            }
            return false;
        }

        private ReturnMessage CheckLinesForErrors(List<string> PriceFileLines)
        {
            ReturnMessage error = new ReturnMessage();

            for (int i = 0; i < PriceFileLines.Count(); i++)
            {
                string[] lineColumns = PriceFileLines[i].Split('|');
                bool ErrorExist = false;
                List<string> faultyColumns = new List<string>();

                for (int j = 0; j < lineColumns.Count(); j++)
                {
                    _ColumnNames[j] = _ColumnNames[j].Replace(" ", "_");

                    switch (_ColumnNames[j])
                    {
                        case "ArticleNo":
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
                        case "Quantity1":
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
                    error.MessageList.Add("-Line " + (i + 2).ToString() + ", " + "ArticleNo: " + lineColumns[0] + ", Columns: " + faultyColumnString);
                }

            }
            return error;
        }

        private ReturnMessage PriceFileColumnCheck(List<string> Columns)
        {
            #region CorrectColumnNames into a List
            List<String> CorrectColumnNames = new List<string>();
            CorrectColumnNames.Add("Article No");
            CorrectColumnNames.Add("Article Desc");
            CorrectColumnNames.Add("Item Type Code");
            CorrectColumnNames.Add("Item Type Desc");
            CorrectColumnNames.Add("Introduction Date");
            CorrectColumnNames.Add("Discontinued Date");
            CorrectColumnNames.Add("Uk Col 1");
            CorrectColumnNames.Add("Quantity 1");
            CorrectColumnNames.Add("Col 1 Price");
            CorrectColumnNames.Add("Col 2 Price");
            CorrectColumnNames.Add("Col 3 Price");
            CorrectColumnNames.Add("Col 4 Price");
            CorrectColumnNames.Add("Col 5 Price");
            CorrectColumnNames.Add("Col 1 Break");
            CorrectColumnNames.Add("Col 2 Break");
            CorrectColumnNames.Add("Col 3 Break");
            CorrectColumnNames.Add("Col 4 Break");
            CorrectColumnNames.Add("Col 5 Break");
            CorrectColumnNames.Add("Discounted Price 1");
            CorrectColumnNames.Add("Discounted Price 2");
            CorrectColumnNames.Add("Discounted Price 3");
            CorrectColumnNames.Add("Discounted Price 4");
            CorrectColumnNames.Add("Discounted Price 5");
            CorrectColumnNames.Add("Super Section No");
            CorrectColumnNames.Add("Super Section Name");
            CorrectColumnNames.Add("Brand ID");
            CorrectColumnNames.Add("Brand Name");
            CorrectColumnNames.Add("Section ID");
            CorrectColumnNames.Add("Section Name");
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
                    case "Item Type Code":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Item Type Desc":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Introduction Date":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Discontinued Date":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Uk Col 1":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Quantity 1":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 1 Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 2 Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 3 Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 4 Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 5 Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 1 Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 2 Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 3 Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 4 Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col 5 Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Discounted Price 1":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Discounted Price 2":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Discounted Price 3":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Discounted Price 4":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Discounted Price 5":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Super Section No":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Super Section Name":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Brand ID":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Brand Name":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Section ID":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Section Name":
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

            string MissingColumnsString = String.Empty;
            for (int i = 0; i < CorrectColumnNames.Count; i++)
            {
                MissingColumnsString += CorrectColumnNames[i];
                if (i != CorrectColumnNames.Count - 1)
                {
                    MissingColumnsString += ", ";
                }
            }

            if (columnCount != 28)
            {
                error.MessageList.Add("\n" + error.MessageList.Count + " mismatched columns, " + columnCount + " matched columns found! " + (CorrectColumnNames.Count - error.MessageList.Count) + " columns missing");
                error.MessageList.Add("\nMissing columns are:\n\n" + MissingColumnsString);
            }
            return error;
        }

        public bool LoadPriceFileItems()
        {
            SqlCommand cmd;
            SqlConnection ImeSqlConn = new Utils().ImeSqlConnection();
            SqlTransaction ImeSqlTransaction = ImeSqlConn.BeginTransaction();
            bool successfull = false;

            int updatedItemCount = 0;
            int newItemCount = 0;
            try
            {
                IMEEntities db = new IMEEntities();

                foreach (string itemString in _Lines)
                {
                    List<string> itemData = itemString.Split('|').ToList();
                    bool NewItem = false;
                    string ArticleNo = itemData[_ColumnNames.IndexOf("ArticleNo")];
                    SlidingPrice item = db.SlidingPrices.Where(x => x.ArticleNo == ArticleNo).FirstOrDefault();

                    if (item == null)
                    {
                        item = new SlidingPrice();
                        NewItem = true;
                    }

                    foreach (string ColumnName in _ColumnNames)
                    {
                        string _itemData = itemData[_ColumnNames.IndexOf(ColumnName)];
                        switch (ColumnName)
                        {
                            case "ArticleDescription":
                                item.ArticleDescription = _itemData;
                                break;
                            case "ArticleNo":
                                item.ArticleNo = _itemData;
                                break;
                            case "ItemTypeCode":
                                if (_itemData != "")
                                {
                                    item.ItemTypeCode = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.ItemTypeCode = 0;
                                }
                                break;
                            case "ItemTypeDesc":
                                item.ItemTypeDesc = _itemData;
                                break;
                            case "IntroductionDate":
                                item.IntroductionDate = _itemData;
                                break;
                            case "DiscontinuedDate":
                                item.DiscontinuedDate = _itemData;
                                break;
                            case "Quantity1":
                                if (_itemData != "")
                                {
                                    item.Quantity1 = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Quantity1 = 0;
                                }
                                break;
                            case "Col1Price":
                                if (_itemData != "")
                                {
                                    item.Col1Price = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col1Price = 0;
                                }
                                break;
                            case "Col2Price":
                                if (_itemData != "")
                                {
                                    item.Col2Price = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col2Price = 0;
                                }
                                break;
                            case "Col3Price":
                                if (_itemData != "")
                                {
                                    item.Col3Price = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col3Price = 0;
                                }
                                break;
                            case "Col4Price":
                                if (_itemData != "")
                                {
                                    item.Col4Price = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col4Price = 0;
                                }
                                break;
                            case "Col5Price":
                                if (_itemData != "")
                                {
                                    item.Col5Price = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col5Price = 0;
                                }
                                break;
                            case "Col1Break":
                                if (_itemData != "")
                                {
                                    item.Col1Break = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col1Break = 0;
                                }
                                break;
                            case "Col2Break":
                                if (_itemData != "")
                                {
                                    item.Col2Break = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col2Break = 0;
                                }
                                break;
                            case "Col3Break":
                                if (_itemData != "")
                                {
                                    item.Col3Break = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col3Break = 0;
                                }
                                break;
                            case "Col4Break":
                                if (_itemData != "")
                                {
                                    item.Col4Break = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col4Break = 0;
                                }
                                break;
                            case "Col5Break":
                                if (_itemData != "")
                                {
                                    item.Col5Break = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.Col5Break = 0;
                                }
                                break;
                            case "DiscountedPrice1":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice1 = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.DiscountedPrice1 = 0;
                                }
                                break;
                            case "DiscountedPrice2":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice2 = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.DiscountedPrice2 = 0;
                                }
                                break;
                            case "DiscountedPrice3":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice3 = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.DiscountedPrice3 = 0;
                                }
                                break;
                            case "DiscountedPrice4":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice4 = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.DiscountedPrice4 = 0;
                                }
                                break;
                            case "DiscountedPrice5":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice5 = Convert.ToInt32(_itemData);
                                }
                                else
                                {
                                    item.DiscountedPrice5 = 0;
                                }
                                break;
                            case "SuperSectionNo":
                                item.SuperSectionNo = _itemData;
                                break;
                            case "SuperSectionName":
                                item.SupersectionName = _itemData;
                                break;
                            case "BrandID":
                                item.BrandID = _itemData;
                                break;
                            case "Brandname":
                                item.Brandname =_itemData;
                                break;
                            case "SectionID":
                                item.SectionID = _itemData;
                                break;
                            case "SectionName":
                                item.SectionName = _itemData;
                                break;
                        }
                    }

                    if (NewItem)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = ImeSqlConn;
                        cmd.Transaction = ImeSqlTransaction;
                        cmd.CommandText = @"INSERT INTO [dbo].[SlidingPrice]
([ArticleNo],[ArticleDescription],[ItemTypeCode],[ItemTypeDesc],[IntroductionDate],[DiscontinuedDate],[Quantity1],[Col1Price],[Col2Price],[Col3Price],[Col4Price],[Col5Price],[Col1Break],[Col2Break],[Col3Break],[Col4Break],[Col5Break],[DiscountedPrice1],[DiscountedPrice2],[DiscountedPrice3],[DiscountedPrice4],[DiscountedPrice5],[SuperSectionNo],[SupersectionName],[BrandID],[Brandname],[SectionID] ,[SectionName])
                    VALUES
                        (@ArticleNo, @ArticleDescription, @ItemTypeCode, @ItemTypeDesc, @IntroductionDate, @DiscontinuedDate, @Quantity1, @Col1Price, @Col2Price, @Col3Price, @Col4Price, @Col5Price, @Col1Break, @Col2Break, @Col3Break, @Col4Break, @Col5Break, @DiscountedPrice1, @DiscountedPrice2, @DiscountedPrice3, @DiscountedPrice4, @DiscountedPrice5, @SuperSectionNo, @SupersectionName, @BrandID, @Brandname, @SectionID, @SectionName)";

                        cmd.Parameters.AddWithValue("@ArticleNo", item.ArticleNo);
                        cmd.Parameters.AddWithValue("@ArticleDescription", item.ArticleDescription);
                        cmd.Parameters.AddWithValue("@ItemTypeCode", item.ItemTypeCode);
                        cmd.Parameters.AddWithValue("@ItemTypeDesc", item.ItemTypeDesc);
                        cmd.Parameters.AddWithValue("@IntroductionDate", item.IntroductionDate);
                        cmd.Parameters.AddWithValue("@DiscontinuedDate", item.DiscontinuedDate);
                        cmd.Parameters.AddWithValue("@Quantity1", item.Quantity1);
                        cmd.Parameters.AddWithValue("@Col1Price", item.Col1Price);
                        cmd.Parameters.AddWithValue("@Col2Price", item.Col2Price);
                        cmd.Parameters.AddWithValue("@Col3Price", item.Col3Price);
                        cmd.Parameters.AddWithValue("@Col4Price", item.Col4Price);
                        cmd.Parameters.AddWithValue("@Col5Price", item.Col5Price);
                        cmd.Parameters.AddWithValue("@Col1Break", item.Col1Break);
                        cmd.Parameters.AddWithValue("@Col2Break", item.Col2Break);
                        cmd.Parameters.AddWithValue("@Col3Break", item.Col3Break);
                        cmd.Parameters.AddWithValue("@Col4Break", item.Col4Break);
                        cmd.Parameters.AddWithValue("@Col5Break", item.Col5Break);
                        cmd.Parameters.AddWithValue("@DiscountedPrice1", item.DiscountedPrice1);
                        cmd.Parameters.AddWithValue("@DiscountedPrice2", item.DiscountedPrice2);
                        cmd.Parameters.AddWithValue("@DiscountedPrice3", item.DiscountedPrice3);
                        cmd.Parameters.AddWithValue("@DiscountedPrice4", item.DiscountedPrice4);
                        cmd.Parameters.AddWithValue("@DiscountedPrice5", item.DiscountedPrice5);
                        cmd.Parameters.AddWithValue("@SuperSectionNo", item.SuperSectionNo);
                        cmd.Parameters.AddWithValue("@SupersectionName", item.SupersectionName);
                        cmd.Parameters.AddWithValue("@BrandID", item.BrandID);
                        cmd.Parameters.AddWithValue("@Brandname", item.Brandname);
                        cmd.Parameters.AddWithValue("@SectionID", item.SectionID);
                        cmd.Parameters.AddWithValue("@SectionName", item.SectionName);

                        cmd.ExecuteNonQuery();
                        newItemCount++;
                    }/* Adds a new item to superDisk */
                    else
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = ImeSqlConn;
                        cmd.Transaction = ImeSqlTransaction;
                        cmd.CommandText = @"UPDATE[dbo].[SlidingPrice] 
                                            SET [ArticleNo] = @ArticleNo, [ArticleDescription] = @ArticleDescription, [ItemTypeCode] = @ItemTypeCode, [ItemTypeDesc] = @ItemTypeDesc, [IntroductionDate] = @IntroductionDate, [DiscontinuedDate] = @DiscontinuedDate, [Quantity1] = @Quantity1, [Col1Price] = @Col1Price, [Col2Price] = @Col2Price, [Col3Price] = @Col3Price, [Col4Price] = @Col4Price, [Col5Price] = @Col5Price, [Low_Discount_Ind] = @Low_Discount_Ind, [Licensed_Ind] = @Licensed_Ind, [Shelf_Life] = @Shelf_Life, [CofO] = @CofO, [EUR1_Indicator] = @EUR1_Indicator, [CCCN_No] = @CCCN_No, [Supercede_Date] = @Supercede_Date, [Current_Cat_page] = @Current_Cat_page, [Uk_Intro_Date] = @Uk_Intro_Date, [Filler] = @Filler, [Uk_Disc_Date] = @Uk_Disc_Date, [Substitute_By] = @Substitute_By, [BHC_Flag] = @BHC_Flag, [Filler1] = @Filler1, [Future_Sell_Price] = @Future_Sell_Price, [Int_Cat] = @Int_Cat, [New_Prod_Change_Ind] = @New_Prod_Change_Ind, [Out_of_Stock_Prohibit_change_ind] =@Out_of_Stock_Prohibit_change_ind, [Disc_Change_Ind] = @Disc_Change_Ind, [Superceded_Change_Ind] =@Superceded_Change_Ind, [Pack_Size_Change_Ind] = @Pack_Size_Change_Ind, [Rolled_Product_Change_Ind] = @Rolled_Product_Change_Ind, [Expiring_Product_Change_Ind] = @Expiring_Product_Change_Ind, [Manufacturer] = @Manufacturer, [MPN] =@MPN, [MH_Code_Level_1] = @MH_Code_Level_1, [Heigh] =@Heigh, [Width] = @Width, [Length] = @Length 
                                        WHERE 
                                            SuperDisk.ArticleNo = @ArticleNo";
                        cmd.Parameters.AddWithValue("@ArticleNo", item.ArticleNo);
                        cmd.Parameters.AddWithValue("@ArticleDescription", item.ArticleDescription);
                        cmd.Parameters.AddWithValue("@ItemTypeCode", item.ItemTypeCode);
                        cmd.Parameters.AddWithValue("@ItemTypeDesc", item.ItemTypeDesc);
                        cmd.Parameters.AddWithValue("@IntroductionDate", item.IntroductionDate);
                        cmd.Parameters.AddWithValue("@DiscontinuedDate", item.DiscontinuedDate);
                        cmd.Parameters.AddWithValue("@Quantity1", item.Quantity1);
                        cmd.Parameters.AddWithValue("@Col1Price", item.Col1Price);
                        cmd.Parameters.AddWithValue("@Col2Price", item.Col2Price);
                        cmd.Parameters.AddWithValue("@Col3Price", item.Col3Price);
                        cmd.Parameters.AddWithValue("@Col4Price", item.Col4Price);
                        cmd.Parameters.AddWithValue("@Col5Price", item.Col5Price);
                        cmd.Parameters.AddWithValue("@Col1Break", item.Col1Break);
                        cmd.Parameters.AddWithValue("@Col2Break", item.Col2Break);
                        cmd.Parameters.AddWithValue("@Col3Break", item.Col3Break);
                        cmd.Parameters.AddWithValue("@Col4Break", item.Col4Break);
                        cmd.Parameters.AddWithValue("@Col5Break", item.Col5Break);
                        cmd.Parameters.AddWithValue("@DiscountedPrice1", item.DiscountedPrice1);
                        cmd.Parameters.AddWithValue("@DiscountedPrice2", item.DiscountedPrice2);
                        cmd.Parameters.AddWithValue("@DiscountedPrice3", item.DiscountedPrice3);
                        cmd.Parameters.AddWithValue("@DiscountedPrice4", item.DiscountedPrice4);
                        cmd.Parameters.AddWithValue("@DiscountedPrice5", item.DiscountedPrice5);
                        cmd.Parameters.AddWithValue("@SuperSectionNo", item.SuperSectionNo);
                        cmd.Parameters.AddWithValue("@SupersectionName", item.SupersectionName);
                        cmd.Parameters.AddWithValue("@BrandID", item.BrandID);
                        cmd.Parameters.AddWithValue("@Brandname", item.Brandname);
                        cmd.Parameters.AddWithValue("@SectionID", item.SectionID);
                        cmd.Parameters.AddWithValue("@SectionName", item.SectionName);

                        cmd.ExecuteNonQuery();
                        updatedItemCount++;
                    }/* Updates the item */
                }

                ImeSqlTransaction.Commit();
                _Timer.Stop();
                MessageBox.Show(newItemCount + " item is added! " + updatedItemCount + " item is updated!" + "\n\n" + "Passed Time: " + _Timer.Elapsed.ToString(@"hh\:mm\:ss") + " sn", "Success");
                successfull = true;
            }
            catch (Exception ex)
            {
                ImeSqlTransaction.Rollback();
                MessageBox.Show("An error occured while loading PriceFile! Try again later\n\n" + ex.ToString(), "Error");
                successfull = false;
            }
            finally
            {
                ImeSqlConn.Close();
            }
            return successfull;
        }

    }
}
