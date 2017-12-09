using LoginForm.DataSet;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace LoginForm.PurchaseOrder
{
    class ExcelPurchaseOrder
    {
        public static void Export(DataGridView dg, string ficheNo)
        {
            #region Copy All Items
            dg.SelectAll();
            DataObject dataObj = dg.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            #endregion

            #region ExcelExport
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int j = 0; j <= dg.ColumnCount - 1; j++)
            {
                xlWorkSheet.Cells[1, j + 1] = dg.Columns[j].Name;
            }
            for (int i = 0; i <= dg.RowCount - 2; i++)
            {
                for (int j = 0; j <= dg.ColumnCount - 1; j++)
                {
                    if (dg.Rows[i].Cells[j].Value != null) { xlWorkSheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString(); }
                }
            }
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel Files (*.xls)|*.xls|All files (*.xls)|*.xls";
            ficheNo = ficheNo.Replace("/", "-");
            savefile.FileName = ficheNo;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string path = savefile.FileName;
                //@"C:\Users\PC\Desktop\test2.xls"
                xlWorkBook.SaveAs(@path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            }
            #endregion
        }

    }
}
