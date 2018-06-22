namespace PrintWorks
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public class DotMatrixPrint
    {
        public static DataTable dtbl2 = new DataTable();

        private static StreamReader streamToPrint;
        private static Font printFont;

        public static void CondensedOff(StreamWriter sw)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x0012');
            builder.ToString();
            sw.Write(builder.ToString());
        }

        public static void CondensedOn(StreamWriter sw)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('\x000f');
            builder.Append('\x000f');
            builder.ToString();
            sw.Write(builder.ToString());
        }

        public static void Pitch10(StreamWriter sw)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('P');
            builder.ToString();
            sw.Write(builder.ToString());
        }

        public static void Pitch12(StreamWriter sw)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('M');
            builder.ToString();
            sw.Write(builder.ToString());
        }

        public static void PrintDesign(int inFormId, DataTable dtblHedder, DataTable dtblDetails, DataTable dtblFooter)
        {
            int num;
            int num2;
            int num6;
            int num7;
            int num9;
            string str;
            string str2;
            string str3;
            int num10;
            int num11;
            DataTable table = new DataTable();
            MasterSP rsp = new MasterSP();
            MasterInfo info = new MasterInfo();
            DetailsSP ssp = new DetailsSP();
            info = rsp.MasterViewByFormName(inFormId);
            if (info.MasterId != 0)
            {
                table = ssp.DetailsViewAll(info.MasterId);
            }
            frmPrintDesigner.isDoubleLineRepeat = info.IsTwoLineForDetails;
            frmPrintDesigner.isDoubleLineNonRepeat = info.IsTwoLineForHedder;
            frmPrintDesigner.inLineCountBetweenTwoPages = info.LineCountBetweenTwo;
            frmPrintDesigner.inPageSizeInFirst = info.PageSize1;
            frmPrintDesigner.inPageSizeInOther = info.PageSizeOther;
            frmPrintDesigner.strPitch = (info.Pitch == "10") ? "10" : "12";
            frmPrintDesigner.strCondensed = (info.Condensed == "On") ? "On" : "Off";
            frmPrintDesigner.inBlankLineForFooter = info.BlankLneForFooter;
            frmPrintDesigner.strFooterLocation = info.FooterLocation;
            frmPrintDesigner.inLineCountAfterPrint = info.LineCountAfterPrint;
            bool flag = true;
            bool flag2 = true;
            DataTable table2 = table.Copy();
            table2.Rows.Clear();
            DataTable table3 = table2.Copy();
            DataTable table4 = table2.Copy();
            DataRow[] rowArray = table.Select("repeat='false'");
            foreach (DataRow row in rowArray)
            {
                table2.Rows.Add(new object[0]);
                num = table2.Rows.Count - 1;
                num2 = 0;
                while (num2 < table2.Columns.Count)
                {
                    table2.Rows[num][num2] = row[num2];
                    num2++;
                }
            }
            rowArray = table.Select("repeat='true'");
            foreach (DataRow row in rowArray)
            {
                table3.Rows.Add(new object[0]);
                num = table3.Rows.Count - 1;
                num2 = 0;
                while (num2 < table3.Columns.Count)
                {
                    table3.Rows[num][num2] = row[num2];
                    num2++;
                }
            }
            rowArray = table.Select("repeat='footer'");
            foreach (DataRow row in rowArray)
            {
                table4.Rows.Add(new object[0]);
                num = table4.Rows.Count - 1;
                for (num2 = 0; num2 < table4.Columns.Count; num2++)
                {
                    table4.Rows[num][num2] = row[num2];
                }
            }
            int count = table2.Rows.Count;
            int num4 = table3.Rows.Count;
            int num5 = table4.Rows.Count;
            DataTable table5 = new DataTable();
            DataTable table6 = new DataTable();
            DataTable table7 = new DataTable();
            table5.Columns.Add("id");
            table5.Columns.Add("extraFieldName");
            table5.Columns.Add("fieldsForExtra");
            table5.Columns.Add("width");
            table6.Columns.Add("id");
            table6.Columns.Add("extraFieldName");
            table6.Columns.Add("fieldsForExtra");
            table6.Columns.Add("width");
            table7.Columns.Add("id");
            table7.Columns.Add("extraFieldName");
            table7.Columns.Add("fieldsForExtra");
            table7.Columns.Add("width");
            for (num6 = 0; num6 < count; num6++)
            {
                if (table2.Rows[num6]["extraFieldName"].ToString() != "")
                {
                    table5.Rows.Add(new object[0]);
                    num7 = table5.Rows.Count - 1;
                    table5.Rows[num7]["id"] = table2.Rows[num6]["name"].ToString();
                    table5.Rows[num7]["extraFieldName"] = table2.Rows[num6]["extraFieldName"].ToString();
                    table5.Rows[num7]["fieldsForExtra"] = table2.Rows[num6]["fieldsForExtra"].ToString();
                    table5.Rows[num7]["width"] = table2.Rows[num6]["width"].ToString();
                }
            }
            for (num6 = 0; num6 < num4; num6++)
            {
                if (table3.Rows[num6]["extraFieldName"].ToString() != "")
                {
                    table6.Rows.Add(new object[0]);
                    num7 = table6.Rows.Count - 1;
                    table6.Rows[num7]["id"] = table3.Rows[num6]["name"].ToString();
                    table6.Rows[num7]["extraFieldName"] = table3.Rows[num6]["extraFieldName"].ToString();
                    table6.Rows[num7]["fieldsForExtra"] = table3.Rows[num6]["fieldsForExtra"].ToString();
                    table6.Rows[num7]["width"] = table3.Rows[num6]["width"].ToString();
                }
            }
            for (num6 = 0; num6 < num5; num6++)
            {
                if (table4.Rows[num6]["extraFieldName"].ToString() != "")
                {
                    table7.Rows.Add(new object[0]);
                    num7 = table7.Rows.Count - 1;
                    table7.Rows[num7]["id"] = table4.Rows[num6]["name"].ToString();
                    table7.Rows[num7]["extraFieldName"] = table4.Rows[num6]["extraFieldName"].ToString();
                    table7.Rows[num7]["fieldsForExtra"] = table4.Rows[num6]["fieldsForExtra"].ToString();
                    table7.Rows[num7]["width"] = table4.Rows[num6]["width"].ToString();
                }
            }
            int num8 = table5.Rows.Count;
            for (num6 = 0; num6 < num8; num6++)
            {
                num9 = int.Parse(table5.Rows[num6]["width"].ToString());
                str = table5.Rows[num6]["fieldsForExtra"].ToString();
                str2 = table5.Rows[num6]["extraFieldName"].ToString();
                if (dtblHedder.Rows[0][str].ToString().Length >= ((num9 * (num6 + 1)) + num9))
                {
                    str3 = dtblHedder.Rows[0][str].ToString().Substring(num9 * (num6 + 1), num9);
                }
                else
                {
                    num10 = ((dtblHedder.Rows[0][str].ToString().Length - (num9 * (num6 + 1))) < 0) ? 0 : (dtblHedder.Rows[0][str].ToString().Length - (num9 * (num6 + 1)));
                    num11 = ((num9 * (num6 + 1)) <= dtblHedder.Rows[0][str].ToString().Length) ? (num9 * (num6 + 1)) : 0;
                    str3 = dtblHedder.Rows[0][str].ToString().Substring(num11, num10);
                }
                dtblHedder.Columns.Add(str2);
                dtblHedder.Rows[0][str2] = str3;
            }
            num8 = table6.Rows.Count;
            for (num6 = 0; num6 < num8; num6++)
            {
                num9 = int.Parse(table6.Rows[num6]["width"].ToString());
                str = table6.Rows[num6]["fieldsForExtra"].ToString();
                str2 = table6.Rows[num6]["extraFieldName"].ToString();
                if (dtblDetails.Rows[0][str].ToString().Length >= ((num9 * (num6 + 1)) + num9))
                {
                    str3 = dtblDetails.Rows[0][str].ToString().Substring(num9 * (num6 + 1), num9);
                }
                else
                {
                    num10 = ((dtblDetails.Rows[0][str].ToString().Length - (num9 * (num6 + 1))) < 0) ? 0 : (dtblDetails.Rows[0][str].ToString().Length - (num9 * (num6 + 1)));
                    num11 = ((num9 * (num6 + 1)) <= dtblDetails.Rows[0][str].ToString().Length) ? (num9 * (num6 + 1)) : 0;
                    str3 = dtblDetails.Rows[0][str].ToString().Substring(num11, num10);
                }
                dtblDetails.Columns.Add(str2);
                int num12 = dtblDetails.Rows.Count;
                for (int i = 0; i < num12; i++)
                {
                    dtblDetails.Rows[i][str2] = str3;
                }
            }
            num8 = table7.Rows.Count;
            for (num6 = 0; num6 < num8; num6++)
            {
                num9 = int.Parse(table7.Rows[num6]["width"].ToString());
                str = table7.Rows[num6]["fieldsForExtra"].ToString();
                str2 = table7.Rows[num6]["extraFieldName"].ToString();
                if (dtblFooter.Rows[0][str].ToString().Length >= ((num9 * (num6 + 1)) + num9))
                {
                    str3 = dtblFooter.Rows[0][str].ToString().Substring(num9 * (num6 + 1), num9);
                }
                else
                {
                    num10 = ((dtblFooter.Rows[0][str].ToString().Length - (num9 * (num6 + 1))) < 0) ? 0 : (dtblFooter.Rows[0][str].ToString().Length - (num9 * (num6 + 1)));
                    num11 = ((num9 * (num6 + 1)) <= dtblFooter.Rows[0][str].ToString().Length) ? (num9 * (num6 + 1)) : 0;
                    str3 = dtblFooter.Rows[0][str].ToString().Substring(num11, num10);
                }
                dtblFooter.Columns.Add(str2);
                dtblFooter.Rows[0][str2] = str3;
            }
            PrintDialog dialog = new PrintDialog();
            StreamWriter sw = null;
            int num14 = 0;
            int num15 = 0;
            int num16 = 0;
            int num17 = 0;
            int num18 = dtblDetails.Rows.Count;
            bool flag3 = false;
            string str4 = "false";
            try
            {
                int num24;
                string str10;
                int num25;
                DataRow[] rowArray3;
                int num26;
                int num27;
                DataRow row2;
                int num28;
                int num29;
                int num30;
                string str11;
                string str12;
                string str13;
                int num31;
                string str14;
                int num32;
                int num33;
                string str15;
                string str16;
                string str17;
                string str18;
                string str19;
                string str20;
                string str21;
                string str22;
                string str23;
                string str24;
                int num34;
                int num35;
                DataRow[] rowArray4;
                bool flag4;
                int num36;
                DataRow row3;
                int num37;
                int num38;
                DataRow row4;
                string str5 = "";
                string str6 = "";
                DataRow[] rowArray2 = new DataRow[10];
                string path = Application.StartupPath + @"\print.txt";
                sw = new StreamWriter(path, false);
                ResetPrinter(sw);
                if (frmPrintDesigner.strPitch == "10")
                {
                    Pitch10(sw);
                }
                else
                {
                    Pitch12(sw);
                }
                if (frmPrintDesigner.strCondensed == "On")
                {
                    CondensedOn(sw);
                }
                else
                {
                    CondensedOff(sw);
                }
                FileInfo info2 = new FileInfo(path);
                num14 = 0x87;
                int num19 = num14;
                int num20 = int.Parse(table.Compute("MAX(row)", "").ToString());
                int num21 = int.Parse(table.Compute("MIN(row)", "").ToString());
                string str8 = table.Compute("MAX(row)", "Repeat='Footer'").ToString();
                string str9 = table.Compute("MIN(row)", "Repeat='Footer'").ToString();
                int num22 = int.Parse((str8 == "") ? "-2" : str8);
                int num23 = int.Parse((str9 == "") ? "-1" : str9);
                for (num24 = 0; num24 <= num20; num24++)
                {
                    str10 = "";
                    num25 = int.Parse(table.Compute("Count(row)", "row='" + num24.ToString() + "'").ToString());
                    rowArray3 = table.Select("row='" + num24.ToString() + "'", "columns");
                    num26 = 0;
                    while (num26 < rowArray3.Length)
                    {
                        if (rowArray3[num26]["Repeat"].ToString() == "true")
                        {
                            str4 = "true";
                            break;
                        }
                        if (rowArray3[num26]["Repeat"].ToString() == "false")
                        {
                            str4 = "false";
                        }
                        else
                        {
                            str4 = "Footer";
                        }
                        num26++;
                    }
                    if (str4 == "false")
                    {
                        str5 = str6 = "";
                        num27 = 0;
                        while (num27 < num25)
                        {
                            row2 = rowArray3[num27];
                            num28 = int.Parse(row2["row"].ToString());
                            num29 = int.Parse(row2["columns"].ToString());
                            num30 = int.Parse(row2["width"].ToString());
                            if (row2["DBF"].ToString() != "")
                            {
                                str11 = dtblHedder.Rows[0][row2["DBF"].ToString()].ToString();
                            }
                            else if (row2["extraFieldName"].ToString() != "")
                            {
                                str11 = dtblHedder.Rows[0][row2["extraFieldName"].ToString()].ToString();
                            }
                            else
                            {
                                str11 = row2["text"].ToString();
                            }
                            str12 = "";
                            str13 = "";
                            num31 = 0;
                            while (num31 < (num29 - str10.Length))
                            {
                                str12 = str12 + " ";
                                num31++;
                            }
                            if (num30 >= str11.Length)
                            {
                                str14 = "";
                                num32 = 0;
                                while (num32 < (num30 - str11.Length))
                                {
                                    str13 = str13 + " ";
                                    num32++;
                                }
                                num33 = 0;
                                while (num33 < str11.Length)
                                {
                                    str14 = str14 + " ";
                                    num33++;
                                }
                                str5 = str5 + str12 + str14 + str13;
                            }
                            else
                            {
                                str15 = "";
                                str16 = "";
                                str17 = "";
                                str18 = "";
                                if (row2["textWrap"].ToString().ToLower() == "true")
                                {
                                    str19 = str11.Substring(num30);
                                    str17 = str11.Substring(num30, num30);
                                    num32 = 0;
                                    while (num32 < (num30 - str17.Length))
                                    {
                                        str15 = str15 + " ";
                                        num32++;
                                    }
                                    if ((num30 < str19.Length) && (int.Parse(row2["wrapLineCount"].ToString()) > 1))
                                    {
                                        str18 = str19.Substring(num30, str19.Length - num30);
                                        num32 = 0;
                                        while (num32 < (num30 - str18.Length))
                                        {
                                            str16 = str16 + " ";
                                            num32++;
                                        }
                                    }
                                    if (row2["dOrH"].ToString() == "Hedding")
                                    {
                                        str17 = RawPrinterHelper.Headder(str17);
                                        str18 = RawPrinterHelper.Headder(str18);
                                    }
                                    else if (row2["dOrH"].ToString() == "Bold")
                                    {
                                        str17 = RawPrinterHelper.Bold(str17);
                                        str18 = RawPrinterHelper.Bold(str18);
                                    }
                                    else if (row2["dOrH"].ToString() == "Italic")
                                    {
                                        str17 = RawPrinterHelper.Italic(str17);
                                        str18 = RawPrinterHelper.Italic(str18);
                                    }
                                    if (row2["Align"].ToString() == "Left")
                                    {
                                        str5 = str5 + str12 + str17 + str15;
                                        str6 = str6 + str12 + str18 + str16;
                                    }
                                    else if (row2["Align"].ToString() == "Right")
                                    {
                                        str5 = str5 + str12 + str15 + str17;
                                        str6 = str6 + str12 + str16 + str18;
                                    }
                                    else
                                    {
                                        str20 = str15.Substring(0, str15.Length / 2);
                                        str21 = str16.Substring(0, str16.Length / 2);
                                        if ((str15.Length % 2) == 0)
                                        {
                                            str22 = str20;
                                        }
                                        else
                                        {
                                            str22 = str20.Insert(0, " ");
                                        }
                                        if ((str16.Length % 2) == 0)
                                        {
                                            str23 = str21;
                                        }
                                        else
                                        {
                                            str23 = str21.Insert(0, " ");
                                        }
                                        str5 = str5 + str12 + str20 + str17 + str22;
                                        str6 = str6 + str12 + str21 + str18 + str23;
                                    }
                                }
                                else
                                {
                                    str14 = "";
                                    str24 = str11.Substring(0, num30);
                                    num33 = 0;
                                    while (num33 < str24.Length)
                                    {
                                        str14 = str14 + " ";
                                        num33++;
                                    }
                                    str5 = str5 + str12 + str14 + str13;
                                    str6 = str6 + str12 + str14 + str13;
                                }
                                str11 = str11.Substring(0, num30);
                            }
                            if (row2["dOrH"].ToString() == "Hedding")
                            {
                                str11 = RawPrinterHelper.Headder(str11);
                            }
                            else if (row2["dOrH"].ToString() == "Bold")
                            {
                                str11 = RawPrinterHelper.Bold(str11);
                            }
                            else if (row2["dOrH"].ToString() == "Italic")
                            {
                                str11 = RawPrinterHelper.Italic(str11);
                            }
                            if (row2["Align"].ToString() == "Left")
                            {
                                str10 = str10 + str12 + str11 + str13;
                            }
                            else if (row2["Align"].ToString() == "Right")
                            {
                                str10 = str10 + str12 + str13 + str11;
                            }
                            else
                            {
                                str20 = str13.Substring(0, str13.Length / 2);
                                if ((str13.Length % 2) == 0)
                                {
                                    str22 = str20;
                                }
                                else
                                {
                                    str22 = str20.Insert(0, " ");
                                }
                                str10 = str10 + str12 + str20 + str11 + str22;
                            }
                            num27++;
                        }
                        sw.Write(str10);
                        sw.WriteLine();
                        num15++;
                        num16++;
                        flag3 = false;
                        if (str5.Trim() != "")
                        {
                            sw.Write(str5);
                            sw.WriteLine();
                            num15++;
                            num16++;
                            str5 = "";
                            flag3 = false;
                        }
                        if (str6.Trim() != "")
                        {
                            sw.Write(str6);
                            sw.WriteLine();
                            num15++;
                            num16++;
                            str6 = "";
                            flag3 = false;
                        }
                    }
                    else if (str4 == "true")
                    {
                        str5 = "";
                        str6 = "";
                        while (num17 < num18)
                        {
                            str10 = "";
                            num27 = 0;
                            while (num27 < num25)
                            {
                                row2 = rowArray3[num27];
                                num28 = int.Parse(row2["row"].ToString());
                                num29 = int.Parse(row2["columns"].ToString());
                                num30 = int.Parse(row2["width"].ToString());
                                if (row2["DBF"].ToString() != "")
                                {
                                    str11 = dtblDetails.Rows[num17][row2["DBF"].ToString()].ToString();
                                }
                                else if (row2["extraFieldName"].ToString() != "")
                                {
                                    str11 = dtblDetails.Rows[num17][row2["extraFieldName"].ToString()].ToString();
                                }
                                else
                                {
                                    str11 = row2["text"].ToString();
                                }
                                str12 = "";
                                str13 = "";
                                num31 = 0;
                                while (num31 < (num29 - str10.Length))
                                {
                                    str12 = str12 + " ";
                                    num31++;
                                }
                                if (num30 >= str11.Length)
                                {
                                    str14 = "";
                                    num32 = 0;
                                    while (num32 < (num30 - str11.Length))
                                    {
                                        str13 = str13 + " ";
                                        num32++;
                                    }
                                    num33 = 0;
                                    while (num33 < str11.Length)
                                    {
                                        str14 = str14 + " ";
                                        num33++;
                                    }
                                    str5 = str5 + str12 + str14 + str13;
                                }
                                else
                                {
                                    str15 = "";
                                    str16 = "";
                                    str17 = "";
                                    str18 = "";
                                    if (row2["textWrap"].ToString().ToLower() == "true")
                                    {
                                        str19 = str11.Substring(num30);
                                        str17 = str11.Substring(num30, num30);
                                        num32 = 0;
                                        while (num32 < (num30 - str17.Length))
                                        {
                                            str15 = str15 + " ";
                                            num32++;
                                        }
                                        if ((num30 < str19.Length) && (int.Parse(row2["wrapLineCount"].ToString()) > 1))
                                        {
                                            str18 = str19.Substring(num30, str19.Length - num30);
                                            num32 = 0;
                                            while (num32 < (num30 - str18.Length))
                                            {
                                                str16 = str16 + " ";
                                                num32++;
                                            }
                                        }
                                        if (row2["dOrH"].ToString() == "Hedding")
                                        {
                                            str17 = RawPrinterHelper.Headder(str17);
                                            str18 = RawPrinterHelper.Headder(str18);
                                        }
                                        else if (row2["dOrH"].ToString() == "Bold")
                                        {
                                            str17 = RawPrinterHelper.Bold(str17);
                                            str18 = RawPrinterHelper.Bold(str18);
                                        }
                                        else if (row2["dOrH"].ToString() == "Italic")
                                        {
                                            str17 = RawPrinterHelper.Italic(str17);
                                            str18 = RawPrinterHelper.Italic(str18);
                                        }
                                        if (row2["Align"].ToString() == "Left")
                                        {
                                            str5 = str5 + str12 + str17 + str15;
                                            str6 = str6 + str12 + str18 + str16;
                                        }
                                        else if (row2["Align"].ToString() == "Right")
                                        {
                                            str5 = str5 + str12 + str15 + str17;
                                            str6 = str6 + str12 + str16 + str18;
                                        }
                                        else
                                        {
                                            str20 = str15.Substring(0, str15.Length / 2);
                                            str21 = str16.Substring(0, str16.Length / 2);
                                            if ((str15.Length % 2) == 0)
                                            {
                                                str22 = str20;
                                            }
                                            else
                                            {
                                                str22 = str20.Insert(0, " ");
                                            }
                                            if ((str16.Length % 2) == 0)
                                            {
                                                str23 = str21;
                                            }
                                            else
                                            {
                                                str23 = str21.Insert(0, " ");
                                            }
                                            str5 = str5 + str12 + str20 + str17 + str22;
                                            str6 = str6 + str12 + str21 + str18 + str23;
                                        }
                                    }
                                    else
                                    {
                                        str14 = "";
                                        str24 = str11.Substring(0, num30);
                                        num33 = 0;
                                        while (num33 < str24.Length)
                                        {
                                            str14 = str14 + " ";
                                            num33++;
                                        }
                                        str5 = str5 + str12 + str14 + str13;
                                        str6 = str6 + str12 + str14 + str13;
                                    }
                                    str11 = str11.Substring(0, num30);
                                }
                                if (row2["dOrH"].ToString() == "Hedding")
                                {
                                    str11 = RawPrinterHelper.Headder(str11);
                                }
                                else if (row2["dOrH"].ToString() == "Bold")
                                {
                                    str11 = RawPrinterHelper.Bold(str11);
                                }
                                else if (row2["dOrH"].ToString() == "Italic")
                                {
                                    str11 = RawPrinterHelper.Italic(str11);
                                }
                                if (row2["Align"].ToString() == "Left")
                                {
                                    str10 = str10 + str12 + str11 + str13;
                                }
                                else if (row2["Align"].ToString() == "Right")
                                {
                                    str10 = str10 + str12 + str13 + str11;
                                }
                                else
                                {
                                    str20 = str13.Substring(0, str13.Length / 2);
                                    if ((str13.Length % 2) == 0)
                                    {
                                        str22 = str20;
                                    }
                                    else
                                    {
                                        str22 = str20.Insert(0, " ");
                                    }
                                    str10 = str10 + str12 + str20 + str11 + str22;
                                }
                                num27++;
                            }
                            sw.Write(str10);
                            sw.WriteLine();
                            num15++;
                            flag3 = false;
                            if ((num15 - num16) >= frmPrintDesigner.inPageSizeInFirst)
                            {
                                flag3 = true;
                                break;
                            }
                            if (str5.Trim() != "")
                            {
                                sw.Write(str5);
                                sw.WriteLine();
                                num15++;
                                str5 = "";
                                flag3 = false;
                                if ((num15 - num16) >= frmPrintDesigner.inPageSizeInFirst)
                                {
                                    flag3 = true;
                                    break;
                                }
                            }
                            if (str6.Trim() != "")
                            {
                                sw.Write(str6);
                                sw.WriteLine();
                                num15++;
                                str6 = "";
                                flag3 = false;
                                if ((num15 - num16) >= frmPrintDesigner.inPageSizeInFirst)
                                {
                                    flag3 = true;
                                    break;
                                }
                            }
                            num17++;
                        }
                        num34 = num23;
                        while (num34 <= num22)
                        {
                            str10 = "";
                            num35 = int.Parse(table.Compute("Count(row)", "row='" + num34.ToString() + "'").ToString());
                            rowArray4 = table.Select("row='" + num34.ToString() + "'", "columns");
                            str5 = "";
                            str6 = "";
                            flag4 = false;
                            num36 = 0;
                            while (num36 < num35)
                            {
                                row3 = rowArray4[num36];
                                flag4 = bool.Parse(row3["FooterRepeatAll"].ToString());
                                if (flag4)
                                {
                                    break;
                                }
                                if (flag3)
                                {
                                    sw.WriteLine();
                                }
                                num36++;
                            }
                            if (flag4)
                            {
                                if (frmPrintDesigner.strFooterLocation == "PageEnd")
                                {
                                    if (flag2)
                                    {
                                        num37 = num15 - num16;
                                        while (num37 < frmPrintDesigner.inPageSizeInFirst)
                                        {
                                            sw.WriteLine();
                                            num37++;
                                        }
                                        flag2 = false;
                                    }
                                }
                                else if (flag)
                                {
                                    num37 = 0;
                                    while (num37 < frmPrintDesigner.inBlankLineForFooter)
                                    {
                                        sw.WriteLine();
                                        num37++;
                                    }
                                    flag = false;
                                }
                            }
                            num38 = 0;
                            while (num38 < num35)
                            {
                                row4 = rowArray4[num38];
                                if (bool.Parse(row4["FooterRepeatAll"].ToString()))
                                {
                                    num28 = int.Parse(row4["row"].ToString());
                                    num29 = int.Parse(row4["columns"].ToString());
                                    num30 = int.Parse(row4["width"].ToString());
                                    if (row4["DBF"].ToString() != "")
                                    {
                                        str11 = dtblFooter.Rows[0][row4["DBF"].ToString()].ToString();
                                    }
                                    else if (row4["extraFieldName"].ToString() != "")
                                    {
                                        str11 = dtblFooter.Rows[0][row4["extraFieldName"].ToString()].ToString();
                                    }
                                    else
                                    {
                                        str11 = row4["text"].ToString();
                                    }
                                    str12 = "";
                                    str13 = "";
                                    num31 = 0;
                                    while (num31 < (num29 - str10.Length))
                                    {
                                        str12 = str12 + " ";
                                        num31++;
                                    }
                                    if (num30 >= str11.Length)
                                    {
                                        str14 = "";
                                        num32 = 0;
                                        while (num32 < (num30 - str11.Length))
                                        {
                                            str13 = str13 + " ";
                                            num32++;
                                        }
                                        num33 = 0;
                                        while (num33 < str11.Length)
                                        {
                                            str14 = str14 + " ";
                                            num33++;
                                        }
                                        str5 = str5 + str12 + str14 + str13;
                                    }
                                    else
                                    {
                                        str15 = "";
                                        str16 = "";
                                        str17 = "";
                                        str18 = "";
                                        if (row4["textWrap"].ToString().ToLower() == "true")
                                        {
                                            str19 = str11.Substring(num30);
                                            str17 = str11.Substring(num30, num30);
                                            num32 = 0;
                                            while (num32 < (num30 - str17.Length))
                                            {
                                                str15 = str15 + " ";
                                                num32++;
                                            }
                                            if ((num30 < str19.Length) && (int.Parse(row4["wrapLineCount"].ToString()) > 1))
                                            {
                                                str18 = str19.Substring(num30, str19.Length - num30);
                                                num32 = 0;
                                                while (num32 < (num30 - str18.Length))
                                                {
                                                    str16 = str16 + " ";
                                                    num32++;
                                                }
                                            }
                                            if (row4["dOrH"].ToString() == "Hedding")
                                            {
                                                str17 = RawPrinterHelper.Headder(str17);
                                                str18 = RawPrinterHelper.Headder(str18);
                                            }
                                            else if (row4["dOrH"].ToString() == "Bold")
                                            {
                                                str17 = RawPrinterHelper.Bold(str17);
                                                str18 = RawPrinterHelper.Bold(str18);
                                            }
                                            else if (row4["dOrH"].ToString() == "Italic")
                                            {
                                                str17 = RawPrinterHelper.Italic(str17);
                                                str18 = RawPrinterHelper.Italic(str18);
                                            }
                                            if (row4["Align"].ToString() == "Left")
                                            {
                                                str5 = str5 + str12 + str17 + str15;
                                                str6 = str6 + str12 + str18 + str16;
                                            }
                                            else if (row4["Align"].ToString() == "Right")
                                            {
                                                str5 = str5 + str12 + str15 + str17;
                                                str6 = str6 + str12 + str16 + str18;
                                            }
                                            else
                                            {
                                                str20 = str15.Substring(0, str15.Length / 2);
                                                str21 = str16.Substring(0, str16.Length / 2);
                                                if ((str15.Length % 2) == 0)
                                                {
                                                    str22 = str20;
                                                }
                                                else
                                                {
                                                    str22 = str20.Insert(0, " ");
                                                }
                                                if ((str16.Length % 2) == 0)
                                                {
                                                    str23 = str21;
                                                }
                                                else
                                                {
                                                    str23 = str21.Insert(0, " ");
                                                }
                                                str5 = str5 + str12 + str20 + str17 + str22;
                                                str6 = str6 + str12 + str21 + str18 + str23;
                                            }
                                        }
                                        else
                                        {
                                            str14 = "";
                                            str24 = str11.Substring(0, num30);
                                            num33 = 0;
                                            while (num33 < str24.Length)
                                            {
                                                str14 = str14 + " ";
                                                num33++;
                                            }
                                            str5 = str5 + str12 + str14 + str13;
                                            str6 = str6 + str12 + str14 + str13;
                                        }
                                        str11 = str11.Substring(0, num30);
                                    }
                                    if (row4["dOrH"].ToString() == "Hedding")
                                    {
                                        str11 = RawPrinterHelper.Headder(str11);
                                    }
                                    else if (row4["dOrH"].ToString() == "Bold")
                                    {
                                        str11 = RawPrinterHelper.Bold(str11);
                                    }
                                    else if (row4["dOrH"].ToString() == "Italic")
                                    {
                                        str11 = RawPrinterHelper.Italic(str11);
                                    }
                                    if (row4["Align"].ToString() == "Left")
                                    {
                                        str10 = str10 + str12 + str11 + str13;
                                    }
                                    else if (row4["Align"].ToString() == "Right")
                                    {
                                        str10 = str10 + str12 + str13 + str11;
                                    }
                                    else
                                    {
                                        str10 = str10 + str12 + str13 + str11;
                                    }
                                }
                                num38++;
                            }
                            if (str10 != "")
                            {
                                sw.Write(str10);
                                sw.WriteLine();
                                num15++;
                                num16++;
                            }
                            if (str5.Trim() != "")
                            {
                                sw.Write(str5);
                                sw.WriteLine();
                                num15++;
                                num16++;
                                str5 = "";
                            }
                            if (str6.Trim() != "")
                            {
                                sw.Write(str6);
                                sw.WriteLine();
                                num15++;
                                num16++;
                                str6 = "";
                            }
                            num34++;
                        }
                    }
                    flag3 = false;
                    if (((num15 - num16) >= frmPrintDesigner.inPageSizeInFirst) && (num17 < (num18 - 1)))
                    {
                        flag3 = true;
                        num37 = 0;
                        while (frmPrintDesigner.inLineCountBetweenTwoPages > num37)
                        {
                            sw.WriteLine();
                            num37++;
                        }
                        num17++;
                        break;
                    }
                }
                if (flag3)
                {
                    flag2 = true;
                    flag = true;
                    num15 = 0;
                    num16 = 0;
                    for (num24 = 0; num24 <= num20; num24++)
                    {
                        str4 = "";
                        if (num24 == 0)
                        {
                            flag2 = true;
                            flag = true;
                            num15 = 0;
                            num16 = 0;
                        }
                        if (str5.Trim() != "")
                        {
                            sw.Write(str5);
                            sw.WriteLine();
                            num15++;
                            str5 = "";
                            str6 = "";
                            flag3 = false;
                            if (num15 >= frmPrintDesigner.inPageSizeInOther)
                            {
                                flag3 = true;
                                num37 = 0;
                                while (frmPrintDesigner.inLineCountBetweenTwoPages > num37)
                                {
                                    sw.WriteLine();
                                    num37++;
                                }
                                num15 = 0;
                                num24 = -1;
                                num17++;
                            }
                        }
                        else
                        {
                            str5 = "";
                        }
                        if (str6.Trim() != "")
                        {
                            sw.Write(str6);
                            sw.WriteLine();
                            num15++;
                            str6 = "";
                            flag3 = false;
                            if (num15 >= frmPrintDesigner.inPageSizeInOther)
                            {
                                flag3 = true;
                                num37 = 0;
                                while (frmPrintDesigner.inLineCountBetweenTwoPages > num37)
                                {
                                    sw.WriteLine();
                                    num37++;
                                }
                                num15 = 0;
                                num24 = -1;
                                num17++;
                            }
                        }
                        else
                        {
                            str6 = "";
                        }
                        str10 = "";
                        num25 = int.Parse(table.Compute("Count(row)", "row='" + num24.ToString() + "'").ToString());
                        rowArray3 = table.Select("row='" + num24.ToString() + "'", "columns");
                        for (num26 = 0; num26 < rowArray3.Length; num26++)
                        {
                            if (rowArray3[num26]["Repeat"].ToString() == "true")
                            {
                                str4 = "true";
                                break;
                            }
                            if (rowArray3[num26]["Repeat"].ToString() == "false")
                            {
                                str4 = "false";
                            }
                            else
                            {
                                str4 = "Footer";
                            }
                        }
                        switch (str4)
                        {
                            case "false":
                                str5 = "";
                                str6 = "";
                                num27 = 0;
                                while (num27 < num25)
                                {
                                    row2 = rowArray3[num27];
                                    if (!bool.Parse(row2["RepeatAllPage"].ToString()))
                                    {
                                        break;
                                    }
                                    num28 = int.Parse(row2["row"].ToString());
                                    num29 = int.Parse(row2["columns"].ToString());
                                    num30 = int.Parse(row2["width"].ToString());
                                    if (row2["DBF"].ToString() != "")
                                    {
                                        str11 = dtblHedder.Rows[0][row2["DBF"].ToString()].ToString();
                                    }
                                    else if (row2["extraFieldName"].ToString() != "")
                                    {
                                        str11 = dtblHedder.Rows[0][row2["extraFieldName"].ToString()].ToString();
                                    }
                                    else
                                    {
                                        str11 = row2["text"].ToString();
                                    }
                                    str12 = "";
                                    str13 = "";
                                    num31 = 0;
                                    while (num31 < (num29 - str10.Length))
                                    {
                                        str12 = str12 + " ";
                                        num31++;
                                    }
                                    if (num30 >= str11.Length)
                                    {
                                        str14 = "";
                                        num32 = 0;
                                        while (num32 < (num30 - str11.Length))
                                        {
                                            str13 = str13 + " ";
                                            num32++;
                                        }
                                        num33 = 0;
                                        while (num33 < str11.Length)
                                        {
                                            str14 = str14 + " ";
                                            num33++;
                                        }
                                        str5 = str5 + str12 + str14 + str13;
                                    }
                                    else
                                    {
                                        str15 = "";
                                        str16 = "";
                                        str17 = "";
                                        str18 = "";
                                        if (row2["textWrap"].ToString().ToLower() == "true")
                                        {
                                            str19 = str11.Substring(num30);
                                            str17 = str11.Substring(num30, num30);
                                            num32 = 0;
                                            while (num32 < (num30 - str11.Substring(num30).Length))
                                            {
                                                str15 = str15 + " ";
                                                num32++;
                                            }
                                            if ((num30 < str19.Length) && (int.Parse(row2["wrapLineCount"].ToString()) > 1))
                                            {
                                                str18 = str19.Substring(num30, str19.Length - num30);
                                                num32 = 0;
                                                while (num32 < (num30 - str18.Length))
                                                {
                                                    str16 = str16 + " ";
                                                    num32++;
                                                }
                                            }
                                            if (row2["dOrH"].ToString() == "Hedding")
                                            {
                                                str17 = RawPrinterHelper.Headder(str17);
                                                str18 = RawPrinterHelper.Headder(str18);
                                            }
                                            else if (row2["dOrH"].ToString() == "Bold")
                                            {
                                                str17 = RawPrinterHelper.Bold(str17);
                                                str18 = RawPrinterHelper.Bold(str18);
                                            }
                                            else if (row2["dOrH"].ToString() == "Italic")
                                            {
                                                str17 = RawPrinterHelper.Italic(str17);
                                                str18 = RawPrinterHelper.Italic(str18);
                                            }
                                            if (row2["Align"].ToString() == "Left")
                                            {
                                                str5 = str5 + str12 + str17 + str15;
                                                str6 = str6 + str12 + str18 + str16;
                                            }
                                            else if (row2["Align"].ToString() == "Right")
                                            {
                                                str5 = str5 + str12 + str15 + str17;
                                                str6 = str6 + str12 + str16 + str18;
                                            }
                                            else
                                            {
                                                str20 = str15.Substring(0, str15.Length / 2);
                                                str21 = str16.Substring(0, str16.Length / 2);
                                                if ((str15.Length % 2) == 0)
                                                {
                                                    str22 = str20;
                                                }
                                                else
                                                {
                                                    str22 = str20.Insert(0, " ");
                                                }
                                                if ((str16.Length % 2) == 0)
                                                {
                                                    str23 = str21;
                                                }
                                                else
                                                {
                                                    str23 = str21.Insert(0, " ");
                                                }
                                                str5 = str5 + str12 + str20 + str17 + str22;
                                                str6 = str6 + str12 + str21 + str18 + str23;
                                            }
                                        }
                                        else
                                        {
                                            str14 = "";
                                            str24 = str11.Substring(0, num30);
                                            num33 = 0;
                                            while (num33 < str24.Length)
                                            {
                                                str14 = str14 + " ";
                                                num33++;
                                            }
                                            str5 = str5 + str12 + str14 + str13;
                                            str6 = str6 + str12 + str14 + str13;
                                        }
                                        str11 = str11.Substring(0, num30);
                                    }
                                    if (row2["dOrH"].ToString() == "Hedding")
                                    {
                                        str11 = RawPrinterHelper.Headder(str11);
                                    }
                                    else if (row2["dOrH"].ToString() == "Bold")
                                    {
                                        str11 = RawPrinterHelper.Bold(str11);
                                    }
                                    else if (row2["dOrH"].ToString() == "Italic")
                                    {
                                        str11 = RawPrinterHelper.Italic(str11);
                                    }
                                    if (row2["Align"].ToString() == "Left")
                                    {
                                        str10 = str10 + str12 + str11 + str13;
                                    }
                                    else if (row2["Align"].ToString() == "Right")
                                    {
                                        str10 = str10 + str12 + str13 + str11;
                                    }
                                    else
                                    {
                                        str20 = str13.Substring(0, str13.Length / 2);
                                        if ((str13.Length % 2) == 0)
                                        {
                                            str22 = str20;
                                        }
                                        else
                                        {
                                            str22 = str20.Insert(0, " ");
                                        }
                                        str10 = str10 + str12 + str13 + str11 + str22;
                                    }
                                    num27++;
                                }
                                if (str10 != "")
                                {
                                    sw.Write(str10);
                                    sw.WriteLine();
                                    num15++;
                                    num16++;
                                    flag3 = false;
                                    str10 = "";
                                }
                                if (str5.Trim() != "")
                                {
                                    sw.Write(str5);
                                    sw.WriteLine();
                                    num15++;
                                    num16++;
                                    str5 = "";
                                }
                                if (str6.Trim() != "")
                                {
                                    sw.Write(str6);
                                    sw.WriteLine();
                                    num15++;
                                    num16++;
                                    str6 = "";
                                }
                                break;

                            case "true":
                                str5 = "";
                                str6 = "";
                                while (num17 < num18)
                                {
                                    str10 = "";
                                    for (num27 = 0; num27 < num25; num27++)
                                    {
                                        row2 = rowArray3[num27];
                                        num28 = int.Parse(row2["row"].ToString());
                                        num29 = int.Parse(row2["columns"].ToString());
                                        num30 = int.Parse(row2["width"].ToString());
                                        if (row2["DBF"].ToString() != "")
                                        {
                                            str11 = dtblDetails.Rows[num17][row2["DBF"].ToString()].ToString();
                                        }
                                        else if (row2["extraFieldName"].ToString() != "")
                                        {
                                            str11 = dtblDetails.Rows[num17][row2["extraFieldName"].ToString()].ToString();
                                        }
                                        else
                                        {
                                            str11 = row2["text"].ToString();
                                        }
                                        str12 = "";
                                        str13 = "";
                                        num31 = 0;
                                        while (num31 < (num29 - str10.Length))
                                        {
                                            str12 = str12 + " ";
                                            num31++;
                                        }
                                        if (num30 >= str11.Length)
                                        {
                                            str14 = "";
                                            num32 = 0;
                                            while (num32 < (num30 - str11.Length))
                                            {
                                                str13 = str13 + " ";
                                                num32++;
                                            }
                                            num33 = 0;
                                            while (num33 < str11.Length)
                                            {
                                                str14 = str14 + " ";
                                                num33++;
                                            }
                                            str5 = str5 + str12 + str14 + str13;
                                        }
                                        else
                                        {
                                            str15 = "";
                                            str16 = "";
                                            str17 = "";
                                            str18 = "";
                                            if (row2["textWrap"].ToString().ToLower() == "true")
                                            {
                                                str19 = str11.Substring(num30);
                                                str17 = str11.Substring(num30, num30);
                                                num32 = 0;
                                                while (num32 < (num30 - str17.Length))
                                                {
                                                    str15 = str15 + " ";
                                                    num32++;
                                                }
                                                if ((num30 < str19.Length) && (int.Parse(row2["wrapLineCount"].ToString()) > 1))
                                                {
                                                    str18 = str19.Substring(num30, str19.Length - num30);
                                                    num32 = 0;
                                                    while (num32 < (num30 - str18.Length))
                                                    {
                                                        str16 = str16 + " ";
                                                        num32++;
                                                    }
                                                }
                                                if (row2["dOrH"].ToString() == "Hedding")
                                                {
                                                    str17 = RawPrinterHelper.Headder(str17);
                                                    str18 = RawPrinterHelper.Headder(str18);
                                                }
                                                else if (row2["dOrH"].ToString() == "Bold")
                                                {
                                                    str17 = RawPrinterHelper.Bold(str17);
                                                    str18 = RawPrinterHelper.Bold(str18);
                                                }
                                                else if (row2["dOrH"].ToString() == "Italic")
                                                {
                                                    str17 = RawPrinterHelper.Italic(str17);
                                                    str18 = RawPrinterHelper.Italic(str18);
                                                }
                                                if (row2["Align"].ToString() == "Left")
                                                {
                                                    str5 = str5 + str12 + str17 + str15;
                                                    str6 = str6 + str12 + str18 + str16;
                                                }
                                                else if (row2["Align"].ToString() == "Right")
                                                {
                                                    str5 = str5 + str12 + str15 + str17;
                                                    str6 = str6 + str12 + str16 + str18;
                                                }
                                                else
                                                {
                                                    str20 = str15.Substring(0, str15.Length / 2);
                                                    str21 = str16.Substring(0, str16.Length / 2);
                                                    if ((str15.Length % 2) == 0)
                                                    {
                                                        str22 = str20;
                                                    }
                                                    else
                                                    {
                                                        str22 = str20.Insert(0, " ");
                                                    }
                                                    if ((str16.Length % 2) == 0)
                                                    {
                                                        str23 = str21;
                                                    }
                                                    else
                                                    {
                                                        str23 = str21.Insert(0, " ");
                                                    }
                                                    str5 = str5 + str12 + str20 + str17 + str22;
                                                    str6 = str6 + str12 + str21 + str18 + str23;
                                                }
                                            }
                                            else
                                            {
                                                str14 = "";
                                                str24 = str11.Substring(0, num30);
                                                num33 = 0;
                                                while (num33 < str24.Length)
                                                {
                                                    str14 = str14 + " ";
                                                    num33++;
                                                }
                                                str5 = str5 + str12 + str14 + str13;
                                                str6 = str6 + str12 + str14 + str13;
                                            }
                                            str11 = str11.Substring(0, num30);
                                        }
                                        if (row2["dOrH"].ToString() == "Hedding")
                                        {
                                            str11 = RawPrinterHelper.Headder(str11);
                                        }
                                        else if (row2["dOrH"].ToString() == "Bold")
                                        {
                                            str11 = RawPrinterHelper.Bold(str11);
                                        }
                                        else if (row2["dOrH"].ToString() == "Italic")
                                        {
                                            str11 = RawPrinterHelper.Italic(str11);
                                        }
                                        if (row2["Align"].ToString() == "Left")
                                        {
                                            str10 = str10 + str12 + str11 + str13;
                                        }
                                        else if (row2["Align"].ToString() == "Right")
                                        {
                                            str10 = str10 + str12 + str13 + str11;
                                        }
                                        else
                                        {
                                            str20 = str13.Substring(0, str13.Length / 2);
                                            if ((str13.Length % 2) == 0)
                                            {
                                                str22 = str20;
                                            }
                                            else
                                            {
                                                str22 = str20.Insert(0, " ");
                                            }
                                            str10 = str10 + str12 + str20 + str11 + str22;
                                        }
                                    }
                                    sw.Write(str10);
                                    sw.WriteLine();
                                    num15++;
                                    flag3 = false;
                                    if ((num15 - num16) >= frmPrintDesigner.inPageSizeInOther)
                                    {
                                        flag3 = true;
                                        break;
                                    }
                                    if (str5.Trim() != "")
                                    {
                                        sw.Write(str5);
                                        sw.WriteLine();
                                        num15++;
                                        str5 = "";
                                        flag3 = false;
                                        if ((num15 - num16) >= frmPrintDesigner.inPageSizeInOther)
                                        {
                                            flag3 = true;
                                            break;
                                        }
                                    }
                                    if (str6.Trim() != "")
                                    {
                                        sw.Write(str6);
                                        sw.WriteLine();
                                        num15++;
                                        str6 = "";
                                        flag3 = false;
                                        if ((num15 - num16) >= frmPrintDesigner.inPageSizeInOther)
                                        {
                                            flag3 = true;
                                            break;
                                        }
                                    }
                                    num17++;
                                }
                                num34 = num23;
                                while (num34 <= num22)
                                {
                                    str10 = "";
                                    num35 = int.Parse(table.Compute("Count(row)", "row='" + num34.ToString() + "'").ToString());
                                    rowArray4 = table.Select("row='" + num34.ToString() + "'", "columns");
                                    str5 = "";
                                    str6 = "";
                                    flag4 = false;
                                    num36 = 0;
                                    while (num36 < num35)
                                    {
                                        row3 = rowArray4[num36];
                                        flag4 = bool.Parse(row3["FooterRepeatAll"].ToString());
                                        if (flag4)
                                        {
                                            break;
                                        }
                                        if ((num17 + 1) < num18)
                                        {
                                            sw.WriteLine();
                                        }
                                        num36++;
                                    }
                                    if (flag4)
                                    {
                                        if (frmPrintDesigner.strFooterLocation == "PageEnd")
                                        {
                                            if (flag2)
                                            {
                                                num37 = num15 - num16;
                                                while (num37 < frmPrintDesigner.inPageSizeInFirst)
                                                {
                                                    sw.WriteLine();
                                                    num37++;
                                                }
                                                flag2 = false;
                                            }
                                        }
                                        else if (flag)
                                        {
                                            num37 = 0;
                                            while (num37 < frmPrintDesigner.inBlankLineForFooter)
                                            {
                                                sw.WriteLine();
                                                num37++;
                                            }
                                            flag = false;
                                        }
                                    }
                                    num38 = 0;
                                    while (num38 < num35)
                                    {
                                        row4 = rowArray4[num38];
                                        if (bool.Parse(row4["FooterRepeatAll"].ToString()))
                                        {
                                            num28 = int.Parse(row4["row"].ToString());
                                            num29 = int.Parse(row4["columns"].ToString());
                                            num30 = int.Parse(row4["width"].ToString());
                                            if (row4["DBF"].ToString() != "")
                                            {
                                                str11 = dtblFooter.Rows[0][row4["DBF"].ToString()].ToString();
                                            }
                                            else if (row4["extraFieldName"].ToString() != "")
                                            {
                                                str11 = dtblFooter.Rows[0][row4["extraFieldName"].ToString()].ToString();
                                            }
                                            else
                                            {
                                                str11 = row4["text"].ToString();
                                            }
                                            str12 = "";
                                            str13 = "";
                                            num31 = 0;
                                            while (num31 < (num29 - str10.Length))
                                            {
                                                str12 = str12 + " ";
                                                num31++;
                                            }
                                            if (num30 >= str11.Length)
                                            {
                                                str14 = "";
                                                num32 = 0;
                                                while (num32 < (num30 - str11.Length))
                                                {
                                                    str13 = str13 + " ";
                                                    num32++;
                                                }
                                                num33 = 0;
                                                while (num33 < str11.Length)
                                                {
                                                    str14 = str14 + " ";
                                                    num33++;
                                                }
                                                str5 = str5 + str12 + str14 + str13;
                                            }
                                            else
                                            {
                                                str15 = "";
                                                str16 = "";
                                                str17 = "";
                                                str18 = "";
                                                if (row4["textWrap"].ToString().ToLower() == "true")
                                                {
                                                    str19 = str11.Substring(num30, num30);
                                                    str17 = str11.Substring(num30, num30);
                                                    num32 = 0;
                                                    while (num32 < (num30 - str17.Length))
                                                    {
                                                        str15 = str15 + " ";
                                                        num32++;
                                                    }
                                                    if ((num30 < str19.Length) && (int.Parse(row4["wrapLineCount"].ToString()) > 1))
                                                    {
                                                        str18 = str19.Substring(num30, str19.Length - num30);
                                                        num32 = 0;
                                                        while (num32 < (num30 - str18.Length))
                                                        {
                                                            str16 = str16 + " ";
                                                            num32++;
                                                        }
                                                    }
                                                    if (row4["dOrH"].ToString() == "Hedding")
                                                    {
                                                        str17 = RawPrinterHelper.Headder(str17);
                                                        str18 = RawPrinterHelper.Headder(str18);
                                                    }
                                                    else if (row4["dOrH"].ToString() == "Bold")
                                                    {
                                                        str17 = RawPrinterHelper.Bold(str17);
                                                        str18 = RawPrinterHelper.Bold(str18);
                                                    }
                                                    else if (row4["dOrH"].ToString() == "Italic")
                                                    {
                                                        str17 = RawPrinterHelper.Italic(str17);
                                                        str18 = RawPrinterHelper.Italic(str18);
                                                    }
                                                    if (row4["Align"].ToString() == "Left")
                                                    {
                                                        str5 = str5 + str12 + str17 + str15;
                                                        str6 = str6 + str12 + str18 + str16;
                                                    }
                                                    else if (row4["Align"].ToString() == "Right")
                                                    {
                                                        str5 = str5 + str12 + str15 + str17;
                                                        str6 = str6 + str12 + str16 + str18;
                                                    }
                                                    else
                                                    {
                                                        str20 = str15.Substring(0, str15.Length / 2);
                                                        str21 = str16.Substring(0, str16.Length / 2);
                                                        if ((str15.Length % 2) == 0)
                                                        {
                                                            str22 = str20;
                                                        }
                                                        else
                                                        {
                                                            str22 = str20.Insert(0, " ");
                                                        }
                                                        if ((str16.Length % 2) == 0)
                                                        {
                                                            str23 = str21;
                                                        }
                                                        else
                                                        {
                                                            str23 = str21.Insert(0, " ");
                                                        }
                                                        str5 = str5 + str12 + str20 + str17 + str22;
                                                        str6 = str6 + str12 + str21 + str18 + str23;
                                                    }
                                                }
                                                else
                                                {
                                                    str14 = "";
                                                    str24 = str11.Substring(0, num30);
                                                    num33 = 0;
                                                    while (num33 < str24.Length)
                                                    {
                                                        str14 = str14 + " ";
                                                        num33++;
                                                    }
                                                    str5 = str5 + str12 + str14 + str13;
                                                    str6 = str6 + str12 + str14 + str13;
                                                }
                                                str11 = str11.Substring(0, num30);
                                            }
                                            if (row4["dOrH"].ToString() == "Hedding")
                                            {
                                                str11 = RawPrinterHelper.Headder(str11);
                                            }
                                            else if (row4["dOrH"].ToString() == "Bold")
                                            {
                                                str11 = RawPrinterHelper.Bold(str11);
                                            }
                                            else if (row4["dOrH"].ToString() == "Italic")
                                            {
                                                str11 = RawPrinterHelper.Italic(str11);
                                            }
                                            if (row4["Align"].ToString() == "Left")
                                            {
                                                str10 = str10 + str12 + str11 + str13;
                                            }
                                            else if (row4["Align"].ToString() == "Right")
                                            {
                                                str10 = str10 + str12 + str13 + str11;
                                            }
                                            else
                                            {
                                                str10 = str10 + str12 + str13 + str11;
                                            }
                                        }
                                        num38++;
                                    }
                                    if (str10 != "")
                                    {
                                        sw.Write(str10);
                                        sw.WriteLine();
                                        num15++;
                                        num16++;
                                    }
                                    if (str5.Trim() != "")
                                    {
                                        sw.Write(str5);
                                        sw.WriteLine();
                                        num15++;
                                        num16++;
                                        str5 = "";
                                    }
                                    if (str6.Trim() != "")
                                    {
                                        sw.Write(str6);
                                        sw.WriteLine();
                                        num15++;
                                        num16++;
                                        str6 = "";
                                    }
                                    num34++;
                                }
                                break;
                        }
                        flag3 = false;
                        if (((num15 - num16) >= frmPrintDesigner.inPageSizeInOther) && (num17 < (num18 - 1)))
                        {
                            flag3 = true;
                            num37 = 0;
                            if ((num17 + 1) < num18)
                            {
                                num24 = -1;
                                while (frmPrintDesigner.inLineCountBetweenTwoPages > num37)
                                {
                                    sw.WriteLine();
                                    num37++;
                                }
                                num15 = 0;
                                num16 = 0;
                            }
                            num17++;
                        }
                    }
                }
                for (num34 = num23; num34 <= num22; num34++)
                {
                    str10 = "";
                    num35 = int.Parse(table.Compute("Count(row)", "row='" + num34.ToString() + "'").ToString());
                    rowArray4 = table.Select("row='" + num34.ToString() + "'", "columns");
                    str5 = "";
                    str6 = "";
                    flag4 = false;
                    for (num36 = 0; num36 < num35; num36++)
                    {
                        row3 = rowArray4[num36];
                        flag4 = !bool.Parse(row3["FooterRepeatAll"].ToString());
                        if (flag4)
                        {
                            break;
                        }
                    }
                    if (flag4)
                    {
                        if (frmPrintDesigner.strFooterLocation == "PageEnd")
                        {
                            if (((num15 - num16) < frmPrintDesigner.inPageSizeInOther) && flag2)
                            {
                                num37 = num15 - num16;
                                while (num37 < frmPrintDesigner.inPageSizeInOther)
                                {
                                    sw.WriteLine();
                                    num37++;
                                }
                                flag2 = false;
                            }
                        }
                        else if (flag)
                        {
                            for (num37 = 0; num37 < frmPrintDesigner.inBlankLineForFooter; num37++)
                            {
                                sw.WriteLine();
                            }
                            flag = false;
                        }
                    }
                    for (num38 = 0; num38 < num35; num38++)
                    {
                        row4 = rowArray4[num38];
                        if (!bool.Parse(row4["FooterRepeatAll"].ToString()))
                        {
                            num28 = int.Parse(row4["row"].ToString());
                            num29 = int.Parse(row4["columns"].ToString());
                            num30 = int.Parse(row4["width"].ToString());
                            if (row4["DBF"].ToString() != "")
                            {
                                str11 = dtblFooter.Rows[0][row4["DBF"].ToString()].ToString();
                            }
                            else if (row4["extraFieldName"].ToString() != "")
                            {
                                str11 = dtblFooter.Rows[0][row4["extraFieldName"].ToString()].ToString();
                            }
                            else
                            {
                                str11 = row4["text"].ToString();
                            }
                            str12 = "";
                            str13 = "";
                            for (num31 = 0; num31 < (num29 - str10.Length); num31++)
                            {
                                str12 = str12 + " ";
                            }
                            if (num30 >= str11.Length)
                            {
                                str14 = "";
                                num32 = 0;
                                while (num32 < (num30 - str11.Length))
                                {
                                    str13 = str13 + " ";
                                    num32++;
                                }
                                num33 = 0;
                                while (num33 < str11.Length)
                                {
                                    str14 = str14 + " ";
                                    num33++;
                                }
                                str5 = str5 + str12 + str14 + str13;
                            }
                            else
                            {
                                str15 = "";
                                str16 = "";
                                str17 = "";
                                str18 = "";
                                if (row4["textWrap"].ToString().ToLower() == "true")
                                {
                                    str19 = str11.Substring(num30);
                                    str17 = str11.Substring(num30, num30);
                                    num32 = 0;
                                    while (num32 < (num30 - str17.Length))
                                    {
                                        str15 = str15 + " ";
                                        num32++;
                                    }
                                    if ((num30 < str19.Length) && (int.Parse(row4["wrapLineCount"].ToString()) > 1))
                                    {
                                        str18 = str19.Substring(num30, str19.Length - num30);
                                        for (num32 = 0; num32 < (num30 - str18.Length); num32++)
                                        {
                                            str16 = str16 + " ";
                                        }
                                    }
                                    if (row4["dOrH"].ToString() == "Hedding")
                                    {
                                        str17 = RawPrinterHelper.Headder(str17);
                                        str18 = RawPrinterHelper.Headder(str18);
                                    }
                                    else if (row4["dOrH"].ToString() == "Bold")
                                    {
                                        str17 = RawPrinterHelper.Bold(str17);
                                        str18 = RawPrinterHelper.Bold(str18);
                                    }
                                    else if (row4["dOrH"].ToString() == "Italic")
                                    {
                                        str17 = RawPrinterHelper.Italic(str17);
                                        str18 = RawPrinterHelper.Italic(str18);
                                    }
                                    if (row4["Align"].ToString() == "Left")
                                    {
                                        str5 = str5 + str12 + str17 + str15;
                                        str6 = str6 + str12 + str18 + str16;
                                    }
                                    else if (row4["Align"].ToString() == "Right")
                                    {
                                        str5 = str5 + str12 + str15 + str17;
                                        str6 = str6 + str12 + str16 + str18;
                                    }
                                    else
                                    {
                                        str20 = str15.Substring(0, str15.Length / 2);
                                        str21 = str16.Substring(0, str16.Length / 2);
                                        if ((str15.Length % 2) == 0)
                                        {
                                            str22 = str20;
                                        }
                                        else
                                        {
                                            str22 = str20.Insert(0, " ");
                                        }
                                        if ((str16.Length % 2) == 0)
                                        {
                                            str23 = str21;
                                        }
                                        else
                                        {
                                            str23 = str21.Insert(0, " ");
                                        }
                                        str5 = str5 + str12 + str20 + str17 + str22;
                                        str6 = str6 + str12 + str21 + str18 + str23;
                                    }
                                }
                                else
                                {
                                    str14 = "";
                                    str24 = str11.Substring(0, num30);
                                    for (num33 = 0; num33 < str24.Length; num33++)
                                    {
                                        str14 = str14 + " ";
                                    }
                                    str5 = str5 + str12 + str14 + str13;
                                    str6 = str6 + str12 + str14 + str13;
                                }
                                str11 = str11.Substring(0, num30);
                            }
                            if (row4["dOrH"].ToString() == "Hedding")
                            {
                                str11 = RawPrinterHelper.Headder(str11);
                            }
                            else if (row4["dOrH"].ToString() == "Bold")
                            {
                                str11 = RawPrinterHelper.Bold(str11);
                            }
                            else if (row4["dOrH"].ToString() == "Italic")
                            {
                                str11 = RawPrinterHelper.Italic(str11);
                            }
                            if (row4["Align"].ToString() == "Left")
                            {
                                str10 = str10 + str12 + str11 + str13;
                            }
                            else if (row4["Align"].ToString() == "Right")
                            {
                                str10 = str10 + str12 + str13 + str11;
                            }
                            else
                            {
                                str10 = str10 + str12 + str13 + str11;
                            }
                        }
                    }
                    if (str10 != "")
                    {
                        sw.Write(str10);
                        sw.WriteLine();
                        num15++;
                        num16++;
                    }
                    if (str5.Trim() != "")
                    {
                        sw.Write(str5);
                        sw.WriteLine();
                        num15++;
                        num16++;
                        str5 = "";
                    }
                    if (str6.Trim() != "")
                    {
                        sw.Write(str6);
                        sw.WriteLine();
                        num15++;
                        num16++;
                        str6 = "";
                    }
                }
                for (int j = 0; j < frmPrintDesigner.inLineCountAfterPrint; j++)
                {
                    sw.WriteLine();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                sw.Close();
            }
            RawPrinterHelper.SendFileToPrinter(dialog.PrinterSettings.PrinterName, Application.StartupPath + @"\Print.txt");
            //Printing();
        }

        public static void Printing()
        {
            try
            {
                streamToPrint = new StreamReader(Application.StartupPath + @"\Print.txt");
                try
                {
                    printFont = new Font("Arial", 15);
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

        public static void ResetPrinter(StreamWriter sw)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('@');
            builder.ToString();
            sw.Write(builder.ToString());
        }

        public void TearOff(StreamWriter sw)
        {
            StringBuilder builder = new StringBuilder();
            builder.ToString();
            sw.Write(builder.ToString());
        }

        public void TearOn(StreamWriter sw)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('\x001b');
            builder.Append('\x0019');
            builder.Append('4');
            builder.ToString();
            sw.Write(builder.ToString());
        }
    }
}

