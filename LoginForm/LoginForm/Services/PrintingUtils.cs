using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace PrinterHelper
{
    /// <summary>
    /// Contains common functions for accessing printer
    /// </summary>
    public class PrinterHelper
    {
        #region Member Variables & Method Signatures

        // String data to be printed.
        static string prnData = string.Empty;

        //Add the printer connection for specified pName.
        [DllImport("winspool.drv")]
        public static extern bool AddPrinterConnection(string pName);

        //Set the added printer as default printer.
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);

        #endregion Member Variables & Method Signatures

        #region Public Methods
        #region  Print File
        /// <summary>
        /// Sends the file to the printer choosed.
        /// </summary>
        /// <param name="fileName">Name & path of the file to be printed.</param>
        /// <param name="printerPath">The path of printer.</param>
        /// <param name="numCopies">The number of copies send to printer.</param>
        public bool PrintFile(string fileName, string printerPath, int numCopies)
        {
            // Check if the incomming strings are null or empty.
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(printerPath))
            {
                return false;
            }

            //Instantiate the object of ProcessStartInfo.
            Process objProcess = new Process();
            try
            {
                // Set the printer.
                AddPrinterConnection(printerPath);
                SetDefaultPrinter(printerPath);
                //Print the file with number of copies sent.
                for (int intCount = 0; intCount < numCopies; intCount++)
                {
                    objProcess.StartInfo.FileName = fileName;
                    objProcess.StartInfo.Verb = "Print";
                    objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    objProcess.StartInfo.UseShellExecute = true;
                    objProcess.Start();
                }
                // Return true for success.
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception and return false as failure.
                return false;
            }
            finally
            {
                // Close the process.
                objProcess.Close();
            }
        }

        #endregion Print File

        #region SendStringToPrinter

        /// <summary>
        /// Sends a string to the printer.
        /// </summary>
        /// <param name="szString">String to be printed.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public bool SendStringToPrinter(string szString)
        {
            try
            {
                PrintDocument prnDocument;
                string printername;
                //Get the default printer name.
                prnDocument = new PrintDocument();
                printername = Convert.ToString(prnDocument.PrinterSettings.PrinterName);
                if (string.IsNullOrEmpty(printername))
                    throw new Exception("No default printer is set.Printing failed!");
                prnData = szString;
                prnDocument.PrintPage += new PrintPageEventHandler(prnDoc_PrintPage);
                prnDocument.Print();
                return true;
            }
            catch (COMException comException)
            {
                //Log the exception
                return false;
            }
            catch (Exception sysException)
            {
                //Log the exception
                return false;
            }
        }

        /// <summary>
        /// Printes the page.
        /// </summary>
        /// <param name="sender">object : Sender event</param>
        /// <param name="e">PrintPageEventArgs</param>
        static void prnDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Font fnt = new System.Drawing.Font(System.Drawing.FontFamily.GenericSerif, 10);
            e.Graphics.DrawString(prnData, fnt, System.Drawing.Brushes.Black, 0, 0);
        }

        #endregion SendStringToPrinter

        #endregion Public Methods
    }
}