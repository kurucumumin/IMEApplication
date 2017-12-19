using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LoginForm.Services
{
    class txtCreate
    {
        public static string newTxt(string[] txtArray, string AccountNumber)
        {

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Txt Files (*.txt)|*.txt|All files (*.txt)|*.txt";
            string filename = "ORD_DB01_" + AccountNumber + "_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
            savefile.FileName = "ORD_DB01_" + AccountNumber + "_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
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