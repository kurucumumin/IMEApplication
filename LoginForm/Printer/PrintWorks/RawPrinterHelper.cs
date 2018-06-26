namespace PrintWorks
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class RawPrinterHelper
    {
        private static StreamReader streamToPrint;
        private static Font printFont;

        public static string Bold(string Headder)
        {
            return (BoldOn() + Headder + BoldOff());
        }

        public static string BoldOff()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('F');
            return builder.ToString();
        }

        public static string BoldOn()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('E');
            return builder.ToString();
        }

        public static string CentreAlign(int length, string field)
        {
            if (field.Trim().Length > length)
            {
                field = field.Remove(length);
            }
            string str = "";
            for (int i = 0; i <= (length - field.Trim().Length); i++)
            {
                str = str + " ";
            }
            str = str.Remove(str.Length / 2);
            return (str + field + str);
        }

        public static void CentreText(StreamWriter sw, string Headder, int Length)
        {
            sw.Write(CentreAlign(Length, Headder));
        }

        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, SetLastError=true, ExactSpelling=true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, SetLastError=true, ExactSpelling=true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, SetLastError=true, ExactSpelling=true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);
        private static string EnlargeOff()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('W');
            builder.Append('0');
            return builder.ToString();
        }

        private static string EnlargeOn()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('W');
            builder.Append('1');
            return builder.ToString();
        }

        public static int GetLength(DataTable dt)
        {
            int num2;
            int num = 0;
            for (num2 = 0; num2 < dt.Columns.Count; num2++)
            {
                num += dt.Columns[num2].ColumnName.Length;
            }
            for (num2 = 0; num2 < (dt.Columns.Count - 1); num2++)
            {
                num += 3;
            }
            return num;
        }

        public static string Headder(string Headder)
        {
            return (EnlargeOn() + BoldOn() + Headder + BoldOff() + EnlargeOff());
        }

        public static void Headder1(StreamWriter sw, string Headder, int Length)
        {
            sw.Write(CentreAlign(Length, BoldOn() + Headder + BoldOff()));
        }

        public static string Italic(string Headder)
        {
            return (ItalicsOn() + Headder + ItalicsOff());
        }

        public static void Italics(StreamWriter sw, string Headder, int Length)
        {
            sw.Write(CentreAlign(Length, ItalicsOn() + Headder + ItalicsOff()));
        }

        private static string ItalicsOff()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('5');
            return builder.ToString();
        }

        private static string ItalicsOn()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('4');
            return builder.ToString();
        }

        public static string LeftAlign(int length, string field)
        {
            if (field.Trim().Length > length)
            {
                field = field.Trim().Remove(length);
            }
            string str = "";
            for (int i = 0; i <= (length - field.Trim().Length); i++)
            {
                str = str + " ";
            }
            return (field.Trim() + str);
        }

        public static void LeftText(StreamWriter sw, string Headder, int Length)
        {
            sw.Write(LeftAlign(Length, Headder));
        }

        [DllImport("winspool.Drv", EntryPoint="OpenPrinterA", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);
        public static void printWithLocation(StreamWriter sw, string text, int column, int width)
        {
            try
            {
                string str = "";
                string str2 = "";
                for (int i = 0; i < column; i++)
                {
                    str = str + " ";
                }
                for (int j = 0; j < (width - text.Length); j++)
                {
                    str2 = str2 + " ";
                }
                sw.Write(str + text + str2);
            }
            catch (Exception)
            {
            }
        }

        public static string RightAlign(int length, string field)
        {
            if (field.Trim().Length > length)
            {
                field = field.Remove(length);
            }
            string str = "";
            int num = field.Trim().Length;
            for (int i = 0; i <= (length - field.Trim().Length); i++)
            {
                str = str + " ";
            }
            return (str + field);
        }

        public static void RightText(StreamWriter sw, string Headder, int Length)
        {
            sw.Write(RightAlign(Length, Headder));
        }

        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount)
        {
            int num = 0;
            int dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool flag = false;
            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        flag = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            if (!flag)
            {
                num = Marshal.GetLastWin32Error();
            }
            return flag;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            //FileStream input = new FileStream(szFileName, FileMode.Open);
            //BinaryReader reader = new BinaryReader(input);
            //byte[] source = new byte[input.Length];
            //bool flag = false;
            //IntPtr destination = new IntPtr(0);
            //int count = Convert.ToInt32(input.Length);
            //source = reader.ReadBytes(count);
            //destination = Marshal.AllocCoTaskMem(count);
            //Marshal.Copy(source, 0, destination, count);
            //flag = SendBytesToPrinter(szPrinterName, destination, count);
            //Marshal.FreeCoTaskMem(destination);
            //return flag;
            bool result = false;
            try
            {
                Printing();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
            
        }

        public static void Printing()
        {
            try
            {
                streamToPrint = new StreamReader(Application.StartupPath + @"\Print.txt");
                try
                {
                    //printFont = new Font("TimesNewRoman", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                    // Print the document.
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Iterate over the file, printing each line.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            int length = szString.Length;
            IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            SendBytesToPrinter(szPrinterName, pBytes, length);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        [DllImport("winspool.Drv", EntryPoint="StartDocPrinterA", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);
        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, SetLastError=true, ExactSpelling=true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);
        public static void WriteColumnHedrDotMatrix(StreamWriter sw, DataTable dt)
        {
            int num = 0;
            for (num = 0; num < dt.Columns.Count; num++)
            {
                sw.Write(dt.Columns[num].ColumnName + "   ");
            }
        }

        public static void WriteLine(StreamWriter sw, string Char, int Length)
        {
            for (int i = 0; i <= Length; i++)
            {
                sw.Write(Char);
            }
        }

        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, SetLastError=true, ExactSpelling=true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);
        public static void WriteTableDataDotMatrix(StreamWriter sw, DataTable dt, string fortrue, string forfalse)
        {
            string str = null;
            int index = 0;
            string field = "";
            foreach (DataRow row in dt.Rows)
            {
                object[] objArray = row.ItemArray;
                int length = 0;
                int num4 = dt.Rows.IndexOf(row);
                if (dt.Rows.IndexOf(row) == (dt.Rows.Count - 1))
                {
                    if (dt.Rows.Count < 3)
                    {
                        sw.WriteLine();
                        sw.WriteLine();
                    }
                    int num5 = GetLength(dt);
                    WriteLine(sw, "-", num5);
                    sw.WriteLine();
                }
                index = 0;
                while (index < (objArray.Length - 1))
                {
                    string str3;
                    str = null;
                    if (((dt.Columns[index].DataType.ToString() == "System.String") || (dt.Columns[index].DataType.ToString() == "System.Decimal")) || (dt.Columns[index].DataType.ToString() == "System.Int32"))
                    {
                        for (int i = 0; i < (dt.Columns[index].ColumnName.Length - objArray[index].ToString().Length); i++)
                        {
                            str = str + " ";
                        }
                    }
                    if ((dt.Columns[index].DataType.ToString() == "System.String") || (dt.Columns[index].DataType.ToString() == "System.Int32"))
                    {
                        str3 = objArray[index].ToString();
                        length = 0;
                        if (index <= 1)
                        {
                            length = dt.Columns[index].ColumnName.Length;
                        }
                        else
                        {
                            length = dt.Columns[index].ColumnName.Length + 2;
                        }
                        if ((((dt.Columns[index].ColumnName.Trim() == "COMMODITY / ITEM") || (dt.Columns[index].ColumnName.Trim() == "COMMODITY/ITEM")) || ((dt.Columns[index].ColumnName.Trim() == "Account Ledger") || (dt.Columns[index].ColumnName.Trim() == "ITEM"))) || (dt.Columns[index].ColumnName == "Commodity Item"))
                        {
                            sw.Write("  " + LeftAlign(length, str3) + " ");
                        }
                        else
                        {
                            sw.Write(RightAlign(length, str3).Substring(1) + " ");
                        }
                    }
                    else if (dt.Columns[index].DataType.ToString() == "System.Decimal")
                    {
                        str3 = objArray[index].ToString();
                        if (objArray[index].ToString().Length > dt.Columns[index].ColumnName.Length)
                        {
                            str3 = objArray[index].ToString().Substring(0, dt.Columns[index].ColumnName.Length);
                        }
                        sw.Write(str + str3 + "   ");
                    }
                    else if (dt.Columns[index].DataType.ToString() == "System.Boolean")
                    {
                        if (bool.Parse(objArray[index].ToString()))
                        {
                            str3 = objArray[index].ToString();
                            if (objArray[index].ToString().Length > fortrue.Length)
                            {
                                str3 = objArray[index].ToString().Substring(0, fortrue.Length);
                            }
                            sw.Write(fortrue + str + "   ");
                        }
                        else
                        {
                            str3 = objArray[index].ToString();
                            if (objArray[index].ToString().Length > forfalse.Length)
                            {
                                str3 = objArray[index].ToString().Substring(0, forfalse.Length);
                            }
                            sw.Write(forfalse + str + "   ");
                        }
                    }
                    index++;
                }
                if (dt.Columns.Count > 0)
                {
                    length = dt.Columns[index].ColumnName.Length;
                    sw.Write(RightAlign(length, objArray[index].ToString()).Substring(1));
                }
                if (field != "")
                {
                    sw.WriteLine();
                    if (dt.Columns.Contains("SL NO"))
                    {
                        sw.Write(RightAlign(6, "") + " ");
                    }
                    sw.Write(RightAlign(4, "") + " ");
                    sw.Write(LeftAlign(field.Length, field) + " ");
                    field = "";
                }
                sw.WriteLine();
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
    }
}

