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

        public static Management getManagement()
        {
            return new IMEEntities().Managements.FirstOrDefault();
        }
    }
}
