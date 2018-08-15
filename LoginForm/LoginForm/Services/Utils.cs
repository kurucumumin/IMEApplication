using LoginForm.DataSet;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;

namespace LoginForm.Services
{
    class Utils
    {
        private static Worker worker;
        public static decimal _decCurrentCompanyId;
        public static string ConnectionStringLogo = new System.Data.SqlClient.SqlConnectionStringBuilder { DataSource = "195.201.76.156\\MSSQL4", Password = "IME1453", UserID = "Sa", InitialCatalog = "LOGO"/*, IntegratedSecurity = true */}.ConnectionString;
        public static string FrmNo = "001";
        public static string DnmNo = "01";

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static bool HasOnlyNumbers(string numberInputText)
        {
            bool result = true;
            foreach (var c in numberInputText)
            {
                if (!System.Char.IsNumber(c))
                {
                    result = false;
                }
            }
            return result;
        }
        public static bool HasNumbersIn(string numberInputText)
        {
            bool result = false;
            foreach (var c in numberInputText)
            {
                if (System.Char.IsNumber(c))
                {
                    result = true;
                }
            }
            return result;
        }

        public static void setCurrentUser(Worker w)
        {
            worker = w;
        }

        public static Worker getCurrentUser()
        {
            return worker;
        }

        public static Management getManagement()
        {
            IMEEntities IME = new IMEEntities();
            return IME.Managements.ToList().FirstOrDefault();
        }

        public static decimal ConvertPriceToCurrecny(decimal Price, decimal SourceRate, decimal TargetRate)
        {
            return ((Price * SourceRate) / TargetRate);
        }

        public static bool AuthorityCheck(MyClasses.MyAuthority.IMEAuthority auth)
        {
            if (worker.AuthorizationValues.Where(x=>x.AuthorizationID == (int)auth).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ExportDataGridToExcel(List<int> ColumnIndexes, DataGridView Grid, string FileName)
        {
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();

            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = Excel.ActiveSheet;
            
            for (int i = 1;  i < ColumnIndexes.Count+1; i++)
            {
                ws.Cells[1, i].NumberFormat = "@";
                ws.Cells[1, i] = Grid.Columns[ColumnIndexes[i-1]].HeaderText;
            }
            ws.Cells[1, 1].EntireRow.Font.Bold = true;

            for(int i = 2; i < Grid.Rows.Count+2; i++)
            {
                for (int j = 1; j < ColumnIndexes.Count+1; j++)
                {
                    DataGridViewCell cell = Grid.Rows[i - 2].Cells[ColumnIndexes[j - 1]];
                    ws.Cells[i, j].NumberFormat = "@";
                    if (!String.IsNullOrEmpty(cell.Value?.ToString()))
                    {
                        ws.Cells[i, j] = cell.Value.ToString();
                    }
                    else
                    {
                        ws.Cells[i, j] = String.Empty;
                    }

                    if (cell.Style.BackColor != Grid.Columns[j - 1].DefaultCellStyle.BackColor)
                    {
                        if (cell.Style.BackColor == Color.FromName("Window") || (cell.Style.BackColor == Color.White))
                        {
                            ws.Cells[i, j].Interior.ColorIndex = 0;
                        }
                        else
                        {
                            ws.Cells[i, j].Interior.Color = cell.Style.BackColor;
                        }
                    }

                }
            }
            ws.UsedRange.Columns.AutoFit();
            Excel.Visible = true;

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel Files (*.xls)|*.xls|All files (*.xls)|*.xls";
            savefile.FileName = FileName;

            object misValue = System.Reflection.Missing.Value;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string path = savefile.FileName;
                //@"C:\Users\PC\Desktop\test2.xls"
                wb.SaveAs(@path, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
        }
    }
}
