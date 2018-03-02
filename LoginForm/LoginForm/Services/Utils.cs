using LoginForm.DataSet;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
            worker = w;
        }

        public static Worker getCurrentUser()
        {
            return worker;
        }

        public static Management getManagement()
        {
            IMEEntities IME = new IMEEntities();
            return IME.Managements.ToList().FirstOrDefault();
        }
    }
}
