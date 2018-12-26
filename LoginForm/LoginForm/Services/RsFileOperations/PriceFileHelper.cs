using LoginForm.DataSet;
using LoginForm.MyClasses;
using System;
using System.Collections.Generic;
using System.Data;
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
                    //_Timer.Stop();
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
                            if (lineColumns[j].Length != 7 && lineColumns[j].Length != 8 && lineColumns[j].Length != 10)
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            else if (lineColumns[j].Length == 8 && !lineColumns[j].EndsWith("P"))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            else if (lineColumns[j].Length == 10 && !lineColumns[j].StartsWith("250") && !lineColumns[j].StartsWith("255") && !lineColumns[j].StartsWith("300"))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            };
                            break;
                        case "Col1Price":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty1))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "Col2Price":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty2))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "Col3Price":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty3))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "Col4Price":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty4))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "Col5Price":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty5))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "Col1Break":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty6))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "Col2Break":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty7))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "Col3Break":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty8))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "Col4Break":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty9))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "Col5Break":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty10))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "DiscountedPrice1":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty11))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "DiscountedPrice2":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty12))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "DiscountedPrice3":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty13))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "DiscountedPrice4":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty14))
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                            break;
                        case "DiscountedPrice5":
                            if (!decimal.TryParse(lineColumns[j], out decimal tempQty15))
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
            CorrectColumnNames.Add("ArticleNo");
            CorrectColumnNames.Add("ArticleDescription");
            CorrectColumnNames.Add("ItemTypeCode");
            CorrectColumnNames.Add("ItemTypeDesc");
            CorrectColumnNames.Add("IntroductionDate");
            CorrectColumnNames.Add("DiscontinuedDate");
            CorrectColumnNames.Add("Quantity1");
            CorrectColumnNames.Add("Col1Price");
            CorrectColumnNames.Add("Col2Price");
            CorrectColumnNames.Add("Col3Price");
            CorrectColumnNames.Add("Col4Price");
            CorrectColumnNames.Add("Col5Price");
            CorrectColumnNames.Add("Col1Break");
            CorrectColumnNames.Add("Col2Break");
            CorrectColumnNames.Add("Col3Break");
            CorrectColumnNames.Add("Col4Break");
            CorrectColumnNames.Add("Col5Break");
            CorrectColumnNames.Add("DiscountedPrice1");
            CorrectColumnNames.Add("DiscountedPrice2");
            CorrectColumnNames.Add("DiscountedPrice3");
            CorrectColumnNames.Add("DiscountedPrice4");
            CorrectColumnNames.Add("DiscountedPrice5");
            CorrectColumnNames.Add("SuperSectionNo");
            CorrectColumnNames.Add("SupersectionName");
            CorrectColumnNames.Add("BrandID");
            CorrectColumnNames.Add("Brandname");
            CorrectColumnNames.Add("SectionID");
            CorrectColumnNames.Add("SectionName");
            #endregion

            ReturnMessage error = new ReturnMessage();

            int columnCount = 0;
            for (int i = 0; i < Columns.Count; i++)
            {
                switch (Columns[i])
                {
                    case "ArticleNo":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "ArticleDescription":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "ItemTypeCode":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "ItemTypeDesc":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "IntroductionDate":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "DiscontinuedDate":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Quantity1":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col1Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col2Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col3Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col4Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col5Price":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col1Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col2Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col3Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col4Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Col5Break":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "DiscountedPrice1":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "DiscountedPrice2":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "DiscountedPrice3":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "DiscountedPrice4":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "DiscountedPrice5":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "SuperSectionNo":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "SupersectionName":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "BrandID":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Brandname":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "SectionID":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "SectionName":
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
            int ItemCount = 0;
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
                                break;
                            case "Col1Price":
                                if (_itemData != "")
                                {
                                    item.Col1Price = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Col2Price":
                                if (_itemData != "")
                                {
                                    item.Col2Price = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Col3Price":
                                if (_itemData != "")
                                {
                                    item.Col3Price = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Col4Price":
                                if (_itemData != "")
                                {
                                    item.Col4Price = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Col5Price":
                                if (_itemData != "")
                                {
                                    item.Col5Price = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "Col1Break":
                                if (_itemData != "")
                                {
                                    item.Col1Break = Convert.ToInt32(_itemData);
                                }
                                break;
                            case "Col2Break":
                                if (_itemData != "")
                                {
                                    item.Col2Break = Convert.ToInt32(_itemData);
                                }
                                break;
                            case "Col3Break":
                                if (_itemData != "")
                                {
                                    item.Col3Break = Convert.ToInt32(_itemData);
                                }
                                break;
                            case "Col4Break":
                                if (_itemData != "")
                                {
                                    item.Col4Break = Convert.ToInt32(_itemData);
                                }
                                break;
                            case "Col5Break":
                                if (_itemData != "")
                                {
                                    item.Col5Break = Convert.ToInt32(_itemData);
                                }
                                break;
                            case "DiscountedPrice1":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice1 = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "DiscountedPrice2":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice2 = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "DiscountedPrice3":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice3 = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "DiscountedPrice4":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice4 = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "DiscountedPrice5":
                                if (_itemData != "")
                                {
                                    item.DiscountedPrice5 = Convert.ToDecimal(_itemData);
                                }
                                break;
                            case "SuperSectionNo":
                                item.SuperSectionNo = _itemData;
                                break;
                            case "SupersectionName":
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

                    //                    if (NewItem)
                    //                    {
                    //                        cmd = new SqlCommand();
                    //                        cmd.Connection = ImeSqlConn;
                    //                        cmd.Transaction = ImeSqlTransaction;
                    //                        cmd.CommandText = @"INSERT INTO [dbo].[SlidingPrice]
                    //([ArticleNo],[ArticleDescription],[ItemTypeCode],[ItemTypeDesc],[IntroductionDate],[DiscontinuedDate],[Quantity1],[Col1Price],[Col2Price],[Col3Price],[Col4Price],[Col5Price],[Col1Break],[Col2Break],[Col3Break],[Col4Break],[Col5Break],[DiscountedPrice1],[DiscountedPrice2],[DiscountedPrice3],[DiscountedPrice4],[DiscountedPrice5],[SuperSectionNo],[SupersectionName],[BrandID],[Brandname],[SectionID] ,[SectionName])
                    //                    VALUES
                    //                        (@ArticleNo, @ArticleDescription, @ItemTypeCode, @ItemTypeDesc, @IntroductionDate, @DiscontinuedDate, @Quantity1, @Col1Price, @Col2Price, @Col3Price, @Col4Price, @Col5Price, @Col1Break, @Col2Break, @Col3Break, @Col4Break, @Col5Break, @DiscountedPrice1, @DiscountedPrice2, @DiscountedPrice3, @DiscountedPrice4, @DiscountedPrice5, @SuperSectionNo, @SupersectionName, @BrandID, @Brandname, @SectionID, @SectionName)";

                    //                        cmd.Parameters.AddWithValue("@ArticleNo", item.ArticleNo);
                    //                        cmd.Parameters.AddWithValue("@ArticleDescription", item.ArticleDescription);
                    //                        cmd.Parameters.AddWithValue("@ItemTypeCode", item.ItemTypeCode);
                    //                        cmd.Parameters.AddWithValue("@ItemTypeDesc", item.ItemTypeDesc);
                    //                        cmd.Parameters.AddWithValue("@IntroductionDate", item.IntroductionDate);
                    //                        cmd.Parameters.AddWithValue("@DiscontinuedDate", item.DiscontinuedDate);
                    //                        cmd.Parameters.AddWithValue("@Quantity1", item.Quantity1);
                    //                        cmd.Parameters.AddWithValue("@Col1Price", item.Col1Price);
                    //                        cmd.Parameters.AddWithValue("@Col2Price", item.Col2Price);
                    //                        cmd.Parameters.AddWithValue("@Col3Price", item.Col3Price);
                    //                        cmd.Parameters.AddWithValue("@Col4Price", item.Col4Price);
                    //                        cmd.Parameters.AddWithValue("@Col5Price", item.Col5Price);
                    //                        cmd.Parameters.AddWithValue("@Col1Break", item.Col1Break);
                    //                        cmd.Parameters.AddWithValue("@Col2Break", item.Col2Break);
                    //                        cmd.Parameters.AddWithValue("@Col3Break", item.Col3Break);
                    //                        cmd.Parameters.AddWithValue("@Col4Break", item.Col4Break);
                    //                        cmd.Parameters.AddWithValue("@Col5Break", item.Col5Break);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice1", item.DiscountedPrice1);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice2", item.DiscountedPrice2);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice3", item.DiscountedPrice3);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice4", item.DiscountedPrice4);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice5", item.DiscountedPrice5);
                    //                        cmd.Parameters.AddWithValue("@SuperSectionNo", item.SuperSectionNo);
                    //                        cmd.Parameters.AddWithValue("@SupersectionName", item.SupersectionName);
                    //                        cmd.Parameters.AddWithValue("@BrandID", item.BrandID);
                    //                        cmd.Parameters.AddWithValue("@Brandname", item.Brandname);
                    //                        cmd.Parameters.AddWithValue("@SectionID", item.SectionID);
                    //                        cmd.Parameters.AddWithValue("@SectionName", item.SectionName);

                    //                        cmd.ExecuteNonQuery();
                    //                        newItemCount++;
                    //                    }/* Adds a new item to SlidingPrice */
                    //                    else
                    //                    {
                    //                        cmd = new SqlCommand();
                    //                        cmd.Connection = ImeSqlConn;
                    //                        cmd.Transaction = ImeSqlTransaction;
                    //                        cmd.CommandText = @"UPDATE[dbo].[SlidingPrice] 
                    //                                            SET [ArticleNo] = @ArticleNo, [ArticleDescription] = @ArticleDescription, [ItemTypeCode] = @ItemTypeCode, [ItemTypeDesc] = @ItemTypeDesc, [IntroductionDate] = @IntroductionDate, [DiscontinuedDate] = @DiscontinuedDate, [Quantity1] = @Quantity1, [Col1Price] = @Col1Price, [Col2Price] = @Col2Price, [Col3Price] = @Col3Price, [Col4Price] = @Col4Price, [Col5Price] = @Col5Price, [Col1Break] = @Col1Break, [Col2Break] = @Col2Break, [Col3Break] = @Col3Break, [Col4Break] = @Col4Break, [Col5Break] = @Col5Break, [DiscountedPrice1] = @DiscountedPrice1, [DiscountedPrice2] = @DiscountedPrice2, [DiscountedPrice3] = @DiscountedPrice3, [DiscountedPrice4] = @DiscountedPrice4, [DiscountedPrice5] = @DiscountedPrice5, [SuperSectionNo] = @SuperSectionNo, [SupersectionName] = @SupersectionName, [BrandID] = @BrandID, [Brandname] = @Brandname, [SectionID] = @SectionID, [SectionName] = @SectionName
                    //                                        WHERE 
                    //                                            SlidingPrice.ArticleNo = @ArticleNo";

                    //                        cmd.Parameters.AddWithValue("@ArticleNo", item.ArticleNo);
                    //                        cmd.Parameters.AddWithValue("@ArticleDescription", item.ArticleDescription);
                    //                        cmd.Parameters.AddWithValue("@ItemTypeCode", item.ItemTypeCode);
                    //                        cmd.Parameters.AddWithValue("@ItemTypeDesc", item.ItemTypeDesc);
                    //                        cmd.Parameters.AddWithValue("@IntroductionDate", item.IntroductionDate);
                    //                        cmd.Parameters.AddWithValue("@DiscontinuedDate", item.DiscontinuedDate);
                    //                        cmd.Parameters.AddWithValue("@Quantity1", item.Quantity1);
                    //                        cmd.Parameters.AddWithValue("@Col1Price", item.Col1Price);
                    //                        cmd.Parameters.AddWithValue("@Col2Price", item.Col2Price);
                    //                        cmd.Parameters.AddWithValue("@Col3Price", item.Col3Price);
                    //                        cmd.Parameters.AddWithValue("@Col4Price", item.Col4Price);
                    //                        cmd.Parameters.AddWithValue("@Col5Price", item.Col5Price);
                    //                        cmd.Parameters.AddWithValue("@Col1Break", item.Col1Break);
                    //                        cmd.Parameters.AddWithValue("@Col2Break", item.Col2Break);
                    //                        cmd.Parameters.AddWithValue("@Col3Break", item.Col3Break);
                    //                        cmd.Parameters.AddWithValue("@Col4Break", item.Col4Break);
                    //                        cmd.Parameters.AddWithValue("@Col5Break", item.Col5Break);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice1", item.DiscountedPrice1);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice2", item.DiscountedPrice2);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice3", item.DiscountedPrice3);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice4", item.DiscountedPrice4);
                    //                        cmd.Parameters.AddWithValue("@DiscountedPrice5", item.DiscountedPrice5);
                    //                        cmd.Parameters.AddWithValue("@SuperSectionNo", item.SuperSectionNo);
                    //                        cmd.Parameters.AddWithValue("@SupersectionName", item.SupersectionName);
                    //                        cmd.Parameters.AddWithValue("@BrandID", item.BrandID);
                    //                        cmd.Parameters.AddWithValue("@Brandname", item.Brandname);
                    //                        cmd.Parameters.AddWithValue("@SectionID", item.SectionID);
                    //                        cmd.Parameters.AddWithValue("@SectionName", item.SectionName);

                    //                        cmd.ExecuteNonQuery();
                    //                        updatedItemCount++;
                    //                    }/* Updates the item */

                    cmd = new SqlCommand
                    {
                        Connection = ImeSqlConn,
                        CommandTimeout = 50,
                        CommandType = CommandType.StoredProcedure,
                        Transaction = ImeSqlTransaction,
                        CommandText = @"[SlidingPriceAdd]"
                    };
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
                    ItemCount++;
                }

                //ImeSqlTransaction.Commit();
                _Timer.Stop();
                MessageBox.Show(ItemCount + " item is added! " + "\n\n" + "Passed Time: " + _Timer.Elapsed.ToString(@"hh\:mm\:ss") + " sn", "Success");
                successfull = true;
            }
            catch (Exception ex)
            {
                //ImeSqlTransaction.Rollback();
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
