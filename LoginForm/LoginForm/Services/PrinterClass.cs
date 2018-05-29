using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

public class clsPrintSettings
{
    // Printing commands are depends on the Dotmatrix printer that we are using

    System.IO.StreamWriter rdr;
    private string Bold_On = "";
    private string Bold_Off = "";
    private string Width_On = ""; //Chr(27) + Chr(87) + Chr(49) 'W1
    private string Width_Off = "";
    public string BillType;
    public string BillNo = "013456789";
    public string BillDt = "29/05/2018";
    public string tran_type;
    public string Discount;
    public string bill_amt;
    public string NetAmount;
    public string reciept_amount;
    public decimal MRPTotal = 0, SavedTotal = 0;
    public decimal count;
    public System.Data.DataTable dt_print;

    public clsPrintSettings()
    {
        rdr = new System.IO.StreamWriter("bill.txt");
    }
    public void Close()
    {
        rdr.Close();
    }
    public void PrintHeader()
    {
        rdr.WriteLine(Bold_On + "IME GENERAL, Bahrein" + Bold_Off);
        PrintLine();
        rdr.WriteLine("Bill NO   : " + BillNo);
        rdr.WriteLine("Bill Date : " + BillDt);
        PrintLine();
        rdr.WriteLine(Bold_On + Width_On + BillType + Width_Off + Bold_Off);
        PrintLine();
    }

    public void PrintDetails()
    {
        rdr.WriteLine("   SLNo  |     Item Name |     Quantity  |       Amount  |        Total  |");
        int i;
        PrintLine();
        for (i = 0; i < count - 1; i++)
        {
            rdr.Write("{0,10}", GetFormatedText(dt_print.Rows[i][0].ToString(), 10) + "|");
            rdr.Write("{0,16}", GetFormatedText(dt_print.Rows[i][1].ToString(), 10) + "|");
            rdr.Write("{0,16}", GetFormatedText(dt_print.Rows[i][2].ToString(), 10) + "|");
            rdr.Write("{0,16}", GetFormatedText(dt_print.Rows[i][3].ToString(), 10) + "|");
            rdr.Write("{0,16}", GetFormatedText(dt_print.Rows[i][4].ToString(), 10) + "|");
            rdr.WriteLine("");
        }
    }

    private string GetFormatedText(string Cont, int Length)
    {
        int rLoc = Length - Cont.Length;
        if (rLoc < 0)
        {
            Cont = Cont.Substring(0, Length);
        }
        else
        {
            int nos;
            for (nos = 0; nos < 3; nos++)
                Cont = Cont + " ";
        }
        return (Cont);
    }

    public void PrintFooter()
    {
        PrintLine();
        rdr.WriteLine();
        rdr.WriteLine("                                                 Total          : " + bill_amt);
        rdr.WriteLine("                                                 Discount       : " + Discount);
        rdr.WriteLine("                                                 Net Amount     : " + NetAmount);
        rdr.WriteLine("                                                 Reciept Amount : " + reciept_amount);
        rdr.WriteLine();
        PrintLine();
        rdr.WriteLine("Transaction Type : " + tran_type);
        PrintLine();
        rdr.WriteLine("Thank You");
        PrintLine();
    }

    public void PrintLine()
    {
        int i;
        string Lstr = "";
        for (i = 1; i <= 75; i++)
        {
            Lstr = Lstr + "-";
        }
        rdr.WriteLine(Lstr);
    }

    public void SkipLine(int LineNos)
    {
        int i;
        for (i = 1; i <= 5; i++)
        {
            rdr.WriteLine("");
        }
    }
}

public class Printttt
{
    private Font printFont;
    private StreamReader streamToPrint;
    static string filePath = @"C:\C#Repositories\IMEApplication\LoginForm\LoginForm\bin\Debug\bill.txt";
    public void PrintBill()
    {
        if (MessageBox.Show("Do You want to Print the Bill", "Sales Bill", MessageBoxButtons.OKCancel) == DialogResult.OK)
        {
            clsPrintSettings obj = new clsPrintSettings();
            obj.BillType = "RECIEPT";
            obj.BillNo = "1234";
            obj.BillDt = "29/05/2018";
            //obj.tran_type = comboBox1.Text;
            obj.bill_amt = "45.00";
            obj.Discount = "10.00";
            obj.NetAmount = "55.00";
            obj.reciept_amount = "55.00";
            DataTable dt1_print = new DataTable();
            dt1_print.Columns.Add(new DataColumn("SLNo", typeof(string)));
            dt1_print.Columns.Add(new DataColumn("Item_Name", typeof(string)));
            dt1_print.Columns.Add(new DataColumn("Quantity", typeof(string)));
            dt1_print.Columns.Add(new DataColumn("Amount", typeof(string)));
            dt1_print.Columns.Add(new DataColumn("Total", typeof(string)));
            DataRow newrow = dt1_print.NewRow();
            obj.count = 3;
            for (int i = 0; i < obj.count - 1; i++)
            {
                DataRow dr = dt1_print.NewRow();
                dr["SLNo"] = i.ToString();
                dr["Item_Name"] = i + ".th item";
                dr["Quantity"] = (i * 2).ToString();
                dr["Amount"] = (i * 4).ToString();
                dr["Total"] = (i * i * 8).ToString();
                dt1_print.Rows.Add(dr);
            }
            
            obj.dt_print = dt1_print;
            obj.PrintHeader();
            obj.PrintDetails();
            obj.PrintFooter();
            obj.SkipLine(3);
            obj.Close();
            obj = null;

            Printing();

            //PrintDialog pdlg = new PrintDialog();

            //// Show the PrintDialog
            //if (pdlg.ShowDialog() == DialogResult.OK)
            //{
            //    PrintDocument pd = new PrintDocument();
            //    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            //    // Associate PrintDocument object with the PrintDialog
            //    pdlg.Document = pd;

            //    // Print with the new PrinterSettings
            //    pd.Print();
            //}

        }
    }

    public void Printing()
    {
        try
        {
            streamToPrint = new StreamReader(filePath);
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

    private void pd_PrintPage(object sender, PrintPageEventArgs ev)
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
}

