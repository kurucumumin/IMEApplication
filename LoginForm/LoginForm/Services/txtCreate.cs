using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LoginForm.DataSet;
namespace LoginForm.Services
{
    class txtCreate
    {
        public static string newTxt(string[] txtArray, string AccountNumber)
        {
            IMEEntities IME = new IMEEntities();
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Txt Files (*.txt)|*.txt|All files (*.txt)|*.txt";
            string filename = "ORD_BH01_" + AccountNumber + "_" + Utils.GetCurrentDateTime().ToString("yyyyMMdd") + "_" + Utils.GetCurrentDateTime().ToString("HHmmss");
            savefile.FileName = filename;
            //savefile.FileName = quotationNo;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string path = savefile.FileName;
                File.WriteAllText(path, String.Empty);
                //TextWriter tw = new StreamWriter(@path,true);
                using (var tw = new StreamWriter(path, true))
                {

                    int a = 0;
                    while (txtArray.Count() > a)
                    {

                        tw.WriteLine(txtArray[a]);
                        a++;
                    }
                    tw.Close();
                }

            }

            return filename;
        }
    }
}