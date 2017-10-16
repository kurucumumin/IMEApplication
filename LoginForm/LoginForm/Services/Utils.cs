using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Services
{
    class Utils
    {
        private static Worker worker;
        public static Management management;

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

        public static void setCurrentUser(Worker w)
        {
            worker = w;
        }

        public static Worker getCurrentUser()
        {
            return worker;
        }



        public static void bringManagement()
        {
            IMEEntities IME = new IMEEntities();
            management = IME.Managements.FirstOrDefault();
            
        }

        public static void saveManagement(Management man)
        {
            IMEEntities IME = new IMEEntities();
            Management mn = IME.Managements.Where(m => m.ID == man.ID).FirstOrDefault();
            mn = man;
            IME.SaveChanges();
        }

        public static Management getManagement()
        {
            return management;
        }
    }
}
