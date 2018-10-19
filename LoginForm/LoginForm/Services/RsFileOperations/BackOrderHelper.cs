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
    class BackOrderHelper
    {
        public string FileName;
        private List<string> _ColumnNames;
        private List<string> _Lines;
        private OpenFileDialog _FileDialog;
        private Stopwatch _Timer;

        public BackOrderHelper()
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

                ReturnMessage ColumnError = BackOrderColumnCheck(_ColumnNames);


                //Eğer BackOrder dosyasında sütun isimlerinde hata varsa
                if (ColumnError.MessageList.Count() > 0)
                {
                    _Timer.Stop();
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.Append("Error(s) exist in column names, Check BackOrder file again").AppendLine().Append("Mis-typed columns are:").AppendLine().AppendLine();

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
                        errorMessage.Append("Passed Time: " + _Timer.Elapsed.ToString(@"hh\:mm\:ss") + " sn" + "\n\n" + "Error(s) exist in item rows, Check BackOrder file again").AppendLine().AppendLine();

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

        private ReturnMessage CheckLinesForErrors(List<string> BackOrderLines)
        {
            ReturnMessage error = new ReturnMessage();

            for (int i = 0; i < BackOrderLines.Count(); i++)
            {
                string[] lineColumns = BackOrderLines[i].Split('|');
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

        private ReturnMessage BackOrderColumnCheck(List<string> Columns)
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
    }
}
