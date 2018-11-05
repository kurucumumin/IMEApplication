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
    class OnSaleHelper
    {
        public string FileName;
        private List<string> _ColumnNames;
        private List<string> _Lines;
        private OpenFileDialog _FileDialog;
        private Stopwatch _Timer;

        public OnSaleHelper()
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
                _ColumnNames = _Lines[0].Split('"',',','"').ToList();
                _Lines.RemoveAt(0);

                _Timer.Start();

                ReturnMessage ColumnError = OnSaleColumnCheck(_ColumnNames);


                //Eğer OnSale dosyasında sütun isimlerinde hata varsa
                if (ColumnError.MessageList.Count() > 0)
                {
                    _Timer.Stop();
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.Append("Error(s) exist in column names, Check OnSale file again").AppendLine().Append("Mis-typed columns are:").AppendLine().AppendLine();

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
                        errorMessage.Append("Passed Time: " + _Timer.Elapsed.ToString(@"hh\:mm\:ss") + " sn" + "\n\n" + "Error(s) exist in item rows, Check OnSale file again").AppendLine().AppendLine();

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

        private ReturnMessage CheckLinesForErrors(List<string> OnSaleLines)
        {
            ReturnMessage error = new ReturnMessage();

            string[] wordcontrol = OnSaleLines[0].Split('"', ',', '"');

            for (int i = 0; i < OnSaleLines.Count(); i++)
            {
                string[] lineColumns = OnSaleLines[i].Split('"', ',', '"');
                bool ErrorExist = false;
                List<string> faultyColumns = new List<string>();

                for (int j = 0; j < lineColumns.Count(); j++)
                {
                    _ColumnNames[j] = _ColumnNames[j].Replace(" ", "_");

                    switch (_ColumnNames[j])
                    {
                        case "ArticleNumber":
                            if (lineColumns[j].Length != 8)
                            {
                                ErrorExist = true;
                                faultyColumns.Add(_ColumnNames[j]);
                            }
                        //    else if (lineColumns[j].Length == 8 && !lineColumns[j].EndsWith("P"))
                        //    {
                        //        ErrorExist = true;
                        //        faultyColumns.Add(_ColumnNames[j]);
                        //    };
                        //    break;
                        //case "Pack_Quantity":
                        //    if (!decimal.TryParse(lineColumns[j], out decimal tempQty1))
                        //    {
                        //        ErrorExist = true;
                        //        faultyColumns.Add(_ColumnNames[j]);
                        //    }
                        //    else if (Int32.Parse(lineColumns[j]) == 0)
                        //    {
                        //        ErrorExist = true;
                        //        faultyColumns.Add(_ColumnNames[j]);
                        //    }
                        //    break;
                        //case "Unit_Content":
                        //    if (!decimal.TryParse(lineColumns[j], out decimal tempQty2))
                        //    {
                        //        ErrorExist = true;
                        //        faultyColumns.Add(_ColumnNames[j]);
                        //    }
                        //    else if (Int32.Parse(lineColumns[j]) == 0)
                        //    {
                        //        ErrorExist = true;
                        //        faultyColumns.Add(_ColumnNames[j]);
                        //    }
                        //    break;
                        //case "Standard_Weight":
                        //    if (!decimal.TryParse(lineColumns[j], out decimal tempQty3))
                        //    {
                        //        ErrorExist = true;
                        //        faultyColumns.Add(_ColumnNames[j]);
                        //    }
                        //    break;
                        //case "Height":
                        //    if (!decimal.TryParse(lineColumns[j], out decimal tempQty4))
                        //    {
                        //        ErrorExist = true;
                        //        faultyColumns.Add(_ColumnNames[j]);
                        //    }
                        //    break;
                        //case "Width":
                        //    if (!decimal.TryParse(lineColumns[j], out decimal tempQty5))
                        //    {
                        //        ErrorExist = true;
                        //        faultyColumns.Add(_ColumnNames[j]);
                        //    }
                        //    break;
                        //case "Length":
                        //    if (!decimal.TryParse(lineColumns[j], out decimal tempQty6))
                        //    {
                        //        ErrorExist = true;
                        //        faultyColumns.Add(_ColumnNames[j]);
                        //    }
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
                    error.MessageList.Add("-Line " + (i + 2).ToString() + ", " + "ArticleNumber: " + lineColumns[0] + ", Columns: " + faultyColumnString);
                }

            }
            return error;
        }

        private ReturnMessage OnSaleColumnCheck(List<string> Columns)
        {
            #region CorrectColumnNames into a List
            List<String> CorrectColumnNames = new List<string>();
            CorrectColumnNames.Add("Article Number");
            CorrectColumnNames.Add("Available to Promise Check");
            CorrectColumnNames.Add("Bulk Pack");
            CorrectColumnNames.Add("Catalogue Status");
            CorrectColumnNames.Add("Discontinued Date");
            CorrectColumnNames.Add("Introduction Date");
            CorrectColumnNames.Add("Next Scheduled Delivery");
            CorrectColumnNames.Add("Onhand Stock Balance");
            CorrectColumnNames.Add("Pack Size");
            CorrectColumnNames.Add("Quantity on Order");
            CorrectColumnNames.Add("Small Order Protection Level");
            CorrectColumnNames.Add("Substituted By");
            CorrectColumnNames.Add("Substituted For");
            #endregion

            ReturnMessage error = new ReturnMessage();

            int columnCount = 0;
            for (int i = 0; i < Columns.Count; i++)
            {
                switch (Columns[i])
                {
                    case "Article Number":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Available to Promise Check":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Bulk Pack":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Catalogue Status":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Discontinued Date":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Introduction Date":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Next Scheduled Delivery":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Onhand Stock Balance":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Pack Size":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Quantity on Order":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Small Order Protection Level":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Substituted By":
                        DeleteColumnAndIncrementColumCount();
                        break;
                    case "Substituted For":
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

            if (columnCount != 14)
            {
                error.MessageList.Add("\n" + error.MessageList.Count + " mismatched columns, " + columnCount + " matched columns found! " + (CorrectColumnNames.Count - error.MessageList.Count) + " columns missing");
                error.MessageList.Add("\nMissing columns are:\n\n" + MissingColumnsString);
            }
            return error;
        }

        public bool LoadOnSaleItems()
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
                    string ArticleNo = itemData[_ColumnNames.IndexOf("ArticleNumber")];
                    OnSale item = db.OnSales.Where(x => x.ArticleNumber == ArticleNo).FirstOrDefault();

                    if (item == null)
                    {
                        item = new OnSale();
                        NewItem = true;
                    }

                    foreach (string ColumnName in _ColumnNames)
                    {
                        string _itemData = itemData[_ColumnNames.IndexOf(ColumnName)];
                        switch (ColumnName)
                        {
                            case "ArticleNumber":
                                item.ArticleNumber = _itemData;
                                break;
                            case "AvailabletoPromiseCheck":
                                item.AvailabletoPromiseCheck = _itemData;
                                break;
                            case "BulkPack":
                                item.BulkPack = _itemData;
                                break;
                            case "CatalogueStatus":
                                item.CatalogueStatus = Convert.ToInt32(_itemData.ToString());
                                break;
                            case "DiscontinuedDate":
                                item.DiscontinuedDate = _itemData;
                                break;
                            case "IntroductionDate":
                                item.IntroductionDate = _itemData;
                                break;
                            case "NextScheduledDelivery":
                                item.NextScheduledDelivery = _itemData;
                                break;
                            case "OnhandStockBalance":
                                item.OnhandStockBalance = Convert.ToInt32(_itemData.ToString());
                                break;
                            case "PackSize":
                                item.PackSize = Convert.ToInt32(_itemData.ToString());
                                break;
                            case "QuantityonOrder":
                                item.QuantityonOrder = Convert.ToInt32(_itemData.ToString());
                                break;
                            case "SmallOrderProtectionLevel":
                                item.SmallOrderProtectionLevel = _itemData;
                                break;
                            case "SubstitutedBy":
                                item.SubstitutedBy = _itemData;
                                break;
                            case "SubstitutedFor":
                                item.SubstitutedFor = _itemData;
                                break;
                        }
                    }

                    if (NewItem)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = ImeSqlConn;
                        cmd.Transaction = ImeSqlTransaction;
                        cmd.CommandText = @"INSERT INTO [dbo].[OnSale]
                        ([ArticleNumber], [AvailabletoPromiseCheck], [BulkPack], [CatalogueStatus], [DiscontinuedDate], [IntroductionDate], [NextScheduledDelivery], [OnhandStockBalance], [PackSize], [QuantityonOrder], [SmallOrderProtectionLevel], [SubstitutedBy], [SubstitutedFor])
                    VALUES
                        (@ArticleNumber, @AvailabletoPromiseCheck, @BulkPack, @CatalogueStatus, @DiscontinuedDate, @IntroductionDate, @NextScheduledDelivery, @OnhandStockBalance, @PackSize, @QuantityonOrder, @SmallOrderProtectionLevel, @SubstitutedBy, @SubstitutedFor)";
                        cmd.Parameters.AddWithValue("@ArticleNumber", item.ArticleNumber);
                        cmd.Parameters.AddWithValue("@AvailabletoPromiseCheck", item.AvailabletoPromiseCheck);
                        cmd.Parameters.AddWithValue("@BulkPack", item.BulkPack);
                        cmd.Parameters.AddWithValue("@CatalogueStatus", item.CatalogueStatus);
                        cmd.Parameters.AddWithValue("@DiscontinuedDate", item.DiscontinuedDate);
                        cmd.Parameters.AddWithValue("@IntroductionDate", item.IntroductionDate);
                        cmd.Parameters.AddWithValue("@NextScheduledDelivery", item.NextScheduledDelivery);
                        cmd.Parameters.AddWithValue("@OnhandStockBalance", item.OnhandStockBalance);
                        cmd.Parameters.AddWithValue("@PackSize", item.PackSize);
                        cmd.Parameters.AddWithValue("@QuantityonOrder", item.QuantityonOrder);
                        cmd.Parameters.AddWithValue("@SmallOrderProtectionLevel", item.SmallOrderProtectionLevel);
                        cmd.Parameters.AddWithValue("@SubstitutedBy", item.SubstitutedBy);
                        cmd.Parameters.AddWithValue("@SubstitutedFor", item.SubstitutedFor);

                        cmd.ExecuteNonQuery();
                        newItemCount++;
                    }/* Adds a new item to OnSale */
                    else
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = ImeSqlConn;
                        cmd.Transaction = ImeSqlTransaction;
                        cmd.CommandText = @"UPDATE[dbo].[OnSale] 
                                            SET [ArticleNumber] = @ArticleNumber, [AvailabletoPromiseCheck] = @AvailabletoPromiseCheck, [BulkPack] = @BulkPack, [CatalogueStatus] = @CatalogueStatus, [DiscontinuedDate] = @DiscontinuedDate, [IntroductionDate] = @IntroductionDate, [NextScheduledDelivery] = @NextScheduledDelivery, [OnhandStockBalance] = @OnhandStockBalance, [PackSize] = @PackSize, [QuantityonOrder] = @QuantityonOrder, [SmallOrderProtectionLevel] = @SmallOrderProtectionLevel, [SubstitutedBy] = @SubstitutedBy, [SubstitutedByFor] = @SubstitutedFor
                                        WHERE 
                                            OnSale.ArticleNumber = @ArticleNumber";
                        cmd.Parameters.AddWithValue("@ArticleNumber", item.ArticleNumber);
                        cmd.Parameters.AddWithValue("@AvailabletoPromiseCheck", item.AvailabletoPromiseCheck);
                        cmd.Parameters.AddWithValue("@BulkPack", item.BulkPack);
                        cmd.Parameters.AddWithValue("@CatalogueStatus", item.CatalogueStatus);
                        cmd.Parameters.AddWithValue("@DiscontinuedDate", item.DiscontinuedDate);
                        cmd.Parameters.AddWithValue("@IntroductionDate", item.IntroductionDate);
                        cmd.Parameters.AddWithValue("@NextScheduledDelivery", item.NextScheduledDelivery);
                        cmd.Parameters.AddWithValue("@OnhandStockBalance", item.OnhandStockBalance);
                        cmd.Parameters.AddWithValue("@PackSize", item.PackSize);
                        cmd.Parameters.AddWithValue("@QuantityonOrder", item.QuantityonOrder);
                        cmd.Parameters.AddWithValue("@SmallOrderProtectionLevel", item.SmallOrderProtectionLevel);
                        cmd.Parameters.AddWithValue("@SubstitutedBy", item.SubstitutedBy);
                        cmd.Parameters.AddWithValue("@SubstitutedFor", item.SubstitutedFor);

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
                MessageBox.Show("An error occured while loading OnSale! Try again later\n\n" + ex.ToString(), "Error");
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
