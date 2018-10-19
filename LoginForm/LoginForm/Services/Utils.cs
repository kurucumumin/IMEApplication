using LoginForm.DataSet;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.Data.SqlClient;
using LoginForm.MyClasses;
using System.Data;
using LoginForm;
namespace LoginForm.Services
{
    class Utils
    {
        private static Worker worker;
        private static int workerID;
        public static decimal _decCurrentCompanyId;


        private readonly string server = @"159.69.213.172";
        private readonly string imedatabase = "IME";
        private readonly string sqluser = "sa";
        private readonly string sqlpassword = "IME1453";

        private static string Name = "";
        private static string Password = "";
        public SqlConnection ImeSqlConnection()
        {
            SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Server=" + server + "; Database=" + imedatabase + "; User Id=" + sqluser + "; Password =" + sqlpassword + "; ";
            conn.ConnectionString = ImeSettings.ConnectionStringIME;
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            return conn;
        }

        public static DateTime GetCurrentDateTime()
        {
            return (DateTime)new IMEEntities().CurrentDate().FirstOrDefault();
        }

        public static void User(string userName, string UserPass)
        {
            Name = userName;
            Password = UserPass;
        } 

        public static string dbFrmNo()
        {
            if (Name == "Dubai")
            {
                return "002";
            }
            if (Name == "Bahreyn")
            {
                return "001";
            }
            if (Name == "Abudhabi")
            {
                return "003";
            }
            if (Name == "Oman")
            {
                return "004";
            }
            if (Name == "Turkey")
            {
                return "005";
            }
            return "";
        }

        public static string dbDnmNo()
        {
            if (Name == "Dubai")
            {
                return "01";
            }
            if (Name == "Bahreyn")
            {
                return "01";
            }
            if (Name == "Abudhabi")
            {
                return "01";
            }
            if (Name == "Oman")
            {
                return "01";
            }
            if (Name == "Turkey")
            {
                return "01";
            }
            return "";
        }

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
            workerID = w.WorkerID;
            //worker = w;
        }

        public static Worker getCurrentUser()
        {
            return new IMEEntities().Workers.Where(x => x.WorkerID == workerID).FirstOrDefault();
            //return worker;
        }

        public static DataSet.Management getManagement()
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
            if (getCurrentUser().AuthorizationValues.Where(x=>x.AuthorizationID == (int)auth).Count() > 0)
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

        public static void LogKayit(string TableName, string DoneOperation)
        {
            KomutArgumanlari_[] arguman = new KomutArgumanlari_[4];
            KomutArgumanlari_ i_1 = new KomutArgumanlari_
            {
                Parametre = TableName,
                ParametreAdi = "@TABLE_NAME"
            };
            arguman[0] = i_1;
            KomutArgumanlari_ i_2 = new KomutArgumanlari_
            {
                Parametre = GetCurrentDateTime(),
                ParametreAdi = "@TIME"
            };
            arguman[1] = i_2;
            KomutArgumanlari_ i_3 = new KomutArgumanlari_
            {
                Parametre = Utils.getCurrentUser().WorkerID,
                ParametreAdi = "@USER_ID"
            };
            arguman[2] = i_3;
            KomutArgumanlari_ i_4 = new KomutArgumanlari_
            {
                Parametre = DoneOperation,
                ParametreAdi = "@DONE_OPERATION"
            };
            arguman[3] = i_4;
            clsClasses.MyConnect.Ornekle.ExecuteNonQuery(ImeSettings.ConnectionStringIME, "INSERT INTO dbo.LogRecords (TABLE_NAME, TIME, USER_ID, DONE_OPERATION) VALUES (@TABLE_NAME, @TIME, @USER_ID, @DONE_OPERATION)", CommandType.Text, 60, arguman);
        }
    }
}
