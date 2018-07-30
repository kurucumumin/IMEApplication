namespace MyLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Security;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    public static class MyExtension
    {
        public static string _HTMLKodTemizleyici(this string gelenMetin)
        {
            Regex regex = new Regex("<.*?>", RegexOptions.Compiled);
            return regex.Replace(gelenMetin, string.Empty);
        }

        public static string _SqlBugTemizle(this string str)
        {
            str = str.Replace("'", "");
            str = str.Replace(";", "");
            str = str.Replace("(", "");
            str = str.Replace(")", "");
            str = str.Replace("[", "");
            str = str.Replace("]", "");
            str = str.Replace("{", "");
            str = str.Replace("}", "");
            str = str.Replace("=", "");
            str = str.Replace("`", "");
            str = str.Replace("&", "");
            str = str.Replace("%", "");
            str = str.Replace("!", "");
            str = str.Replace("#", "");
            str = str.Replace("<", "");
            str = str.Replace(">", "");
            str = str.Replace("*", "");
            str = str.Replace("-", "");
            str = str.Replace("--", "");
            str = str.Replace(" and ", "");
            str = str.Replace("delay", "");
            str = str.Replace("DELAY", "");
            str = str.Replace("WAITFOR", "");
            str = str.Replace("waitfor", "");
            return str;
        }

        public static bool _TC_VD_IBAN_MAIL_Kontrol(this string gelenVeri, KontrolTipleri kontrolu)
        {
            if (kontrolu == KontrolTipleri.TC_Kimlik_No)
            {
                string str = gelenVeri;
                try
                {
                    int num = 0;
                    int num2 = 0;
                    foreach (char ch in str)
                    {
                        if (num < 10)
                        {
                            num2 += Convert.ToInt32(char.ToString(ch));
                        }
                        num++;
                    }
                    char ch2 = str[10];
                    return ((num2 % 10) == Convert.ToInt32(ch2.ToString()));
                }
                catch
                {
                    return false;
                }
            }
            if (kontrolu == KontrolTipleri.VergiKimlik_No)
            {
                string str3 = gelenVeri;
                try
                {
                    int num4 = (Convert.ToInt32(gelenVeri.Substring(0, 1)) + 9) % 10;
                    int num5 = (Convert.ToInt32(gelenVeri.Substring(1, 1)) + 8) % 10;
                    int num6 = (Convert.ToInt32(gelenVeri.Substring(2, 1)) + 7) % 10;
                    int num7 = (Convert.ToInt32(gelenVeri.Substring(3, 1)) + 6) % 10;
                    int num8 = (Convert.ToInt32(gelenVeri.Substring(4, 1)) + 5) % 10;
                    int num9 = (Convert.ToInt32(gelenVeri.Substring(5, 1)) + 4) % 10;
                    int num10 = (Convert.ToInt32(gelenVeri.Substring(6, 1)) + 3) % 10;
                    int num11 = (Convert.ToInt32(gelenVeri.Substring(7, 1)) + 2) % 10;
                    int num12 = (Convert.ToInt32(gelenVeri.Substring(8, 1)) + 1) % 10;
                    int num13 = Convert.ToInt32(gelenVeri.Substring(9, 1)) % 10;
                    int num14 = (num4 * 0x200) % 9;
                    int num15 = (num5 * 0x100) % 9;
                    int num16 = (num6 * 0x80) % 9;
                    int num17 = (num7 * 0x40) % 9;
                    int num18 = (num8 * 0x20) % 9;
                    int num19 = (num9 * 0x10) % 9;
                    int num20 = (num10 * 8) % 9;
                    int num21 = (num11 * 4) % 9;
                    int num22 = (num12 * 2) % 9;
                    if ((num4 != 0) && (num14 == 0))
                    {
                        num14 = 9;
                    }
                    if ((num5 != 0) && (num15 == 0))
                    {
                        num15 = 9;
                    }
                    if ((num6 != 0) && (num16 == 0))
                    {
                        num16 = 9;
                    }
                    if ((num7 != 0) && (num17 == 0))
                    {
                        num17 = 9;
                    }
                    if ((num8 != 0) && (num18 == 0))
                    {
                        num18 = 9;
                    }
                    if ((num9 != 0) && (num19 == 0))
                    {
                        num19 = 9;
                    }
                    if ((num10 != 0) && (num20 == 0))
                    {
                        num20 = 9;
                    }
                    if ((num11 != 0) && (num21 == 0))
                    {
                        num21 = 9;
                    }
                    if ((num12 != 0) && (num22 == 0))
                    {
                        num22 = 9;
                    }
                    int num23 = (((((((num14 + num15) + num16) + num17) + num18) + num19) + num20) + num21) + num22;
                    if ((num23 % 10) == 0)
                    {
                        num23 = 0;
                    }
                    else
                    {
                        num23 = 10 - (num23 % 10);
                    }
                    return (num23 == num13);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            if (kontrolu == KontrolTipleri.IBAN_No)
            {
                string str4 = gelenVeri.ToUpper();
                if (!string.IsNullOrEmpty(str4) && Regex.IsMatch(str4, "^[A-Z0-9]"))
                {
                    str4 = str4.Replace(" ", string.Empty);
                    string str5 = str4.Substring(4, str4.Length - 4) + str4.Substring(0, 4);
                    int num24 = 0x37;
                    StringBuilder builder = new StringBuilder();
                    foreach (char ch3 in str5)
                    {
                        int num27;
                        if (char.IsLetter(ch3))
                        {
                            num27 = ch3 - num24;
                        }
                        else
                        {
                            num27 = int.Parse(ch3.ToString());
                        }
                        builder.Append(num27);
                    }
                    string str6 = builder.ToString();
                    int num25 = int.Parse(str6.Substring(0, 1));
                    for (int i = 1; i < str6.Length; i++)
                    {
                        int num29 = int.Parse(str6.Substring(i, 1));
                        num25 *= 10;
                        num25 += num29;
                        num25 = num25 % 0x61;
                    }
                    return (num25 == 1);
                }
                return false;
            }
            return ((kontrolu == KontrolTipleri.Email) && Regex.IsMatch(gelenVeri, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"));
        }

        public static bool? _ToBoolean(this object gelen)
        {
            bool? nullable;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                nullable = new bool?(Convert.ToBoolean(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    nullable = new bool?(Convert.ToBoolean(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static bool _ToBooleanR(this object gelen)
        {
            bool flag3;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                flag3 = Convert.ToBoolean(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    flag3 = Convert.ToBoolean(gelen);
                }
                catch (Exception)
                {
                    flag3 = false;
                }
            }
            return flag3;
        }

        public static DateTime? _ToDateTime(this object gelen)
        {
            DateTime? nullable;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                nullable = new DateTime?(Convert.ToDateTime(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    nullable = new DateTime?(Convert.ToDateTime(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static DateTime _ToDateTimeR(this object gelen)
        {
            DateTime minValue;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                minValue = Convert.ToDateTime(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    minValue = Convert.ToDateTime(gelen);
                }
                catch (Exception)
                {
                    minValue = DateTime.MinValue;
                }
            }
            return minValue;
        }

        public static decimal? _ToDecimal(this object gelen)
        {
            decimal? nullable;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                nullable = new decimal?(Convert.ToDecimal(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    nullable = new decimal?(Convert.ToDecimal(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static decimal _ToDecimalR(this object gelen)
        {
            decimal zero;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                zero = Convert.ToDecimal(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    zero = Convert.ToDecimal(gelen);
                }
                catch (Exception)
                {
                    zero = decimal.Zero;
                }
            }
            return zero;
        }

        public static double? _ToDouble(this object gelen)
        {
            double? nullable;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                nullable = new double?(Convert.ToDouble(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    nullable = new double?(Convert.ToDouble(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static double _ToDoubleR(this object gelen)
        {
            double num2;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                num2 = Convert.ToDouble(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    num2 = Convert.ToDouble(gelen);
                }
                catch (Exception)
                {
                    num2 = 0.0;
                }
            }
            return num2;
        }

        public static float? _ToFloat(this string gelen)
        {
            float? nullable;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                nullable = new float?(float.Parse(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (string.IsNullOrEmpty(gelen) || string.IsNullOrWhiteSpace(gelen))
                    {
                        throw new Exception();
                    }
                    nullable = new float?(float.Parse(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static float _ToFloatR(this string gelen)
        {
            float num2;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                num2 = float.Parse(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (string.IsNullOrEmpty(gelen) || string.IsNullOrWhiteSpace(gelen))
                    {
                        throw new Exception();
                    }
                    num2 = float.Parse(gelen);
                }
                catch (Exception)
                {
                    num2 = 0f;
                }
            }
            return num2;
        }

        public static int? _ToInteger(this object gelen)
        {
            int? nullable;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                nullable = new int?(Convert.ToInt32(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    nullable = new int?(Convert.ToInt32(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static int _ToIntegerR(this object gelen)
        {
            int num2;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                num2 = Convert.ToInt32(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    num2 = Convert.ToInt32(gelen);
                }
                catch (Exception)
                {
                    num2 = 0;
                }
            }
            return num2;
        }

        public static string _ToString(this object gelen)
        {
            string str;
            try
            {
                if (gelen == null)
                {
                    throw new Exception();
                }
                str = gelen.ToString();
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value)
                    {
                        throw new Exception();
                    }
                    str = gelen.ToString();
                }
                catch (Exception)
                {
                    str = "";
                }
            }
            return str;
        }

        //public static void CreateDirectory(this DirectoryInfo dirInfo)
        //{
        //    if (dirInfo.Parent > null)
        //    {
        //        dirInfo.Parent.CreateDirectory();
        //    }
        //    if (!dirInfo.Exists)
        //    {
        //        dirInfo.Create();
        //    }
        //}

        public static string Decrypt(this string stringToDecrypt, string key)
        {
            if (string.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentException("Boş metnin şifresi \x00e7\x00f6z\x00fclemez");
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Şifre \x00e7\x00f6zme i\x00e7in anahtar vermelisiniz");
            }
            string str = null;
            try
            {
                CspParameters parameters = new CspParameters {
                    KeyContainerName = key
                };
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider(parameters) {
                    PersistKeyInCsp = true
                };
                char[] separator = new char[] { '-' };
                byte[] rgb = Array.ConvertAll<string, byte>(stringToDecrypt.Split(separator), s => Convert.ToByte(byte.Parse(s, NumberStyles.HexNumber)));
                byte[] bytes = provider.Decrypt(rgb, true);
                str = Encoding.UTF8.GetString(bytes);
            }
            catch (Exception)
            {
            }
            return str;
        }

        public static string Encrypt(this string stringToEncrypt, string key)
        {
            if (string.IsNullOrEmpty(stringToEncrypt))
            {
                throw new ArgumentException("Boş metin şifrelenemez");
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Şifreleme i\x00e7in anahtar vermelisiniz");
            }
            CspParameters parameters = new CspParameters {
                KeyContainerName = key
            };
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(parameters) {
                PersistKeyInCsp = true
            };
            return BitConverter.ToString(provider.Encrypt(Encoding.UTF8.GetBytes(stringToEncrypt), true));
        }

        public static int[] FabionacciDizisi(int adimSayisi, ref double altinOran)
        {
            int[] numArray = new int[adimSayisi];
            numArray[0] = 0;
            numArray[1] = 1;
            for (int i = 2; i < adimSayisi; i++)
            {
                numArray[i] = numArray[i - 1] + numArray[i - 2];
            }
            altinOran = ((double) numArray[adimSayisi - 1]) / ((double) numArray[adimSayisi - 2]);
            return numArray;
        }

        public static void FileIsRunAsAdmin(string filePath, ref string msg)
        {
            FileInfo info = new FileInfo(filePath);
            ProcessStartInfo startInfo = new ProcessStartInfo {
                UseShellExecute = true,
                WorkingDirectory = info.DirectoryName,
                FileName = info.FullName,
                Verb = "runas"
            };
            try
            {
                Process.Start(startInfo);
            }
            catch (Exception exception)
            {
                msg = exception.Message;
            }
        }

        public static List<FizikselDosya_> FizikselDosyalariGetir(string dizin)
        {
            List<FizikselDosya_> list = new List<FizikselDosya_>();
            foreach (string str in Directory.GetFiles(dizin))
            {
                FizikselDosya_ item = new FizikselDosya_ {
                    DosyaAdi = str.Substring(str.LastIndexOf(@"\")),
                    DosyaYolu = str
                };
                list.Add(item);
            }
            return list;
        }

        public static string GetMD5(this string filename, ref string hata)
        {
            string str = string.Empty;
            try
            {
                MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                FileStream inputStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                byte[] buffer = provider.ComputeHash(inputStream);
                inputStream.Close();
                str = BitConverter.ToString(buffer).Replace("-", "");
            }
            catch (Exception exception)
            {
                hata = exception.Message;
            }
            return str.ToLower();
        }

        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor descriptor in properties)
            {
                table.Columns.Add(descriptor.Name, Nullable.GetUnderlyingType(descriptor.PropertyType) ?? descriptor.PropertyType);
            }
            foreach (T local in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor descriptor2 in properties)
                {
                    row[descriptor2.Name] = descriptor2.GetValue(local) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public static bool listToTxtFile(string filePath, List<string> liste, ref string HataMesaji)
        {
            bool flag3;
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        for (int i = 0; i < liste.Count; i++)
                        {
                            writer.WriteLine(liste[i]);
                        }
                        writer.Close();
                        return true;
                    }
                }
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                using (StreamWriter writer2 = new StreamWriter(filePath))
                {
                    for (int j = 0; j < liste.Count; j++)
                    {
                        writer2.WriteLine(liste[j]);
                    }
                    writer2.Close();
                    flag3 = true;
                }
            }
            catch (Exception exception)
            {
                HataMesaji = exception.Message;
                flag3 = false;
            }
            return flag3;
        }

        //public static bool MailSend(MailParametreleri_ param, ref string msg)
        //{
        //    MailAddress address = new MailAddress(param.GonderenMail, param.GonderenIsim);
        //    MailMessage message = new MailMessage {
        //        From = address,
        //        IsBodyHtml = true
        //    };
        //    if (param.ToGonderiListesi == null)
        //    {
        //        param.ToGonderiListesi = new List<mailiAlacaklar>();
        //    }
        //    foreach (mailiAlacaklar alacaklar in param.ToGonderiListesi)
        //    {
        //        message.To.Add(new MailAddress(alacaklar.MailAdresi, alacaklar.KisiAdi));
        //    }
        //    if (param.BccGonderiListesi == null)
        //    {
        //        param.BccGonderiListesi = new List<mailiAlacaklar>();
        //    }
        //    foreach (mailiAlacaklar alacaklar2 in param.BccGonderiListesi)
        //    {
        //        message.Bcc.Add(new MailAddress(alacaklar2.MailAdresi, alacaklar2.KisiAdi));
        //    }
        //    if (param.CcGonderiListesi == null)
        //    {
        //        param.CcGonderiListesi = new List<mailiAlacaklar>();
        //    }
        //    foreach (mailiAlacaklar alacaklar3 in param.CcGonderiListesi)
        //    {
        //        message.CC.Add(new MailAddress(alacaklar3.MailAdresi, alacaklar3.KisiAdi));
        //    }
        //    message.Subject = param.MailKonusu;
        //    message.Body = param.MailMesaji;
        //    message.Priority = param.Onceligi;
        //    NetworkCredential credential = new NetworkCredential(param.MailiGonderecekMailinAdi, param.MailiGonderecekMailinSifresi);
        //    SmtpClient client = new SmtpClient {
        //        Host = param.mailHostu,
        //        Port = param.Port,
        //        UseDefaultCredentials = false,
        //        Credentials = credential,
        //        EnableSsl = param.SSL_ID,
        //        DeliveryMethod = SmtpDeliveryMethod.Network
        //    };
        //    foreach (string str in param.GonderilecekDosyalar)
        //    {
        //        message.Attachments.Add(new Attachment(str));
        //    }
        //    try
        //    {
        //        if (param.GuvenlikIptal)
        //        {
        //            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
        //        }
        //        client.Send(message);
        //        msg = "OK";
        //        try
        //        {
        //            message.Attachments.Clear();
        //            message.Dispose();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        return true;
        //    }
        //    catch (Exception exception)
        //    {
        //        msg = exception.Message;
        //        return false;
        //    }
        //}

        public static string OndalikSayiYuvarla(decimal deger, int virgulSonrasi)
        {
            string format = "{0:0.";
            for (int i = 0; i < virgulSonrasi; i++)
            {
                format = format + "0";
            }
            format = (virgulSonrasi == 0) ? (format.Replace(".", "") + "}") : (format + "}");
            return string.Format(format, deger);
        }

        public static string SayiyiYaziyaCevir(decimal tutar)
        {
            string str = tutar.ToString("F2").Replace('.', ',');
            string str2 = str.Substring(0, str.IndexOf(','));
            string str3 = str.Substring(str.IndexOf(',') + 1, 2);
            string str4 = "";
            string[] strArray = new string[] { "", "BİR", "İKİ", "\x00dc\x00e7", "D\x00d6RT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] strArray2 = new string[] { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] strArray3 = new string[] { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" };
            int num = 6;
            str2 = str2.PadLeft(num * 3, '0');
            for (int i = 0; i < (num * 3); i += 3)
            {
                string str5 = "";
                if (str2.Substring(i, 1) != "0")
                {
                    str5 = str5 + strArray[Convert.ToInt32(str2.Substring(i, 1))] + "Y\x00dcZ";
                }
                if (str5 == "BİRY\x00dcZ")
                {
                    str5 = "Y\x00dcZ";
                }
                str5 = str5 + strArray2[Convert.ToInt32(str2.Substring(i + 1, 1))] + strArray[Convert.ToInt32(str2.Substring(i + 2, 1))];
                if (str5 != "")
                {
                    str5 = str5 + strArray3[i / 3];
                }
                if (str5 == "BİRBİN")
                {
                    str5 = "BİN";
                }
                str4 = str4 + str5;
            }
            if (str4 != "")
            {
                str4 = str4 + " TL ";
            }
            int length = str4.Length;
            if (str3.Substring(0, 1) != "0")
            {
                str4 = str4 + strArray2[Convert.ToInt32(str3.Substring(0, 1))];
            }
            if (str3.Substring(1, 1) != "0")
            {
                str4 = str4 + strArray[Convert.ToInt32(str3.Substring(1, 1))];
            }
            if (str4.Length > length)
            {
                return (str4 + " Krş.");
            }
            return (str4 + "SIFIR Krş.");
        }

        //public static void WS_Restart(string ServiceName, ref string HataMesaji)
        //{
        //    try
        //    {
        //        ServiceController[] services = ServiceController.GetServices();
        //        foreach (ServiceController controller in services)
        //        {
        //            if (controller.ServiceName == ServiceName)
        //            {
        //                ServiceController controller2 = new ServiceController(controller.ServiceName);
        //                if (controller2.Status != ServiceControllerStatus.Running)
        //                {
        //                    controller2.Start();
        //                    controller2.WaitForStatus(ServiceControllerStatus.Running);
        //                    controller2.Refresh();
        //                }
        //                else
        //                {
        //                    controller.Stop();
        //                    controller.WaitForStatus(ServiceControllerStatus.Stopped);
        //                    Thread.Sleep(0x1388);
        //                    controller.Start();
        //                    controller.WaitForStatus(ServiceControllerStatus.Running);
        //                    controller2.Refresh();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        HataMesaji = exception.Message;
        //    }
        //}

        //public static void WS_Start(string ServiceName, ref string HataMesaji)
        //{
        //    try
        //    {
        //        ServiceController[] services = ServiceController.GetServices();
        //        foreach (ServiceController controller in services)
        //        {
        //            if (controller.ServiceName == ServiceName)
        //            {
        //                ServiceController controller2 = new ServiceController(controller.ServiceName);
        //                if (controller2.Status != ServiceControllerStatus.Running)
        //                {
        //                    controller2.Start();
        //                    controller2.WaitForStatus(ServiceControllerStatus.Running);
        //                    controller2.Refresh();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        HataMesaji = exception.Message;
        //    }
        //}

        //public static void WS_Stop(string ServiceName, ref string HataMesaji)
        //{
        //    try
        //    {
        //        ServiceController[] services = ServiceController.GetServices();
        //        foreach (ServiceController controller in services)
        //        {
        //            if (controller.ServiceName == ServiceName)
        //            {
        //                ServiceController controller2 = new ServiceController(controller.ServiceName);
        //                if (controller2.Status != ServiceControllerStatus.Stopped)
        //                {
        //                    controller.Stop();
        //                    controller.WaitForStatus(ServiceControllerStatus.Stopped);
        //                    controller2.Refresh();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        HataMesaji = exception.Message;
        //    }
        //}

        public static DateTime FirstWeekDay
        {
            get
            {
                int dayOfWeek = (int) DateTime.Now.DayOfWeek;
                if (dayOfWeek == 0)
                {
                    return DateTime.Now.AddDays(-6.0);
                }
                return DateTime.Now.AddDays((double) (1 - dayOfWeek));
            }
        }

        public static DateTime LastWeekDay
        {
            get
            {
                return FirstWeekDay.AddDays(6.0);
            }
        }

        //[Serializable, CompilerGenerated]
        //private sealed class <>c
        //{
        //    public static readonly MyExtension.<>c <>9 = new MyExtension.<>c();
        //    public static Converter<string, byte> <>9__13_0;
        //    public static RemoteCertificateValidationCallback <>9__7_0;

        //    internal byte <Decrypt>b__13_0(string s)
        //    {
        //        return Convert.ToByte(byte.Parse(s, NumberStyles.HexNumber));
        //    }

        //    internal bool <MailSend>b__7_0(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //    {
        //        return true;
        //    }
        //}

        public enum KontrolTipleri
        {
            TC_Kimlik_No,
            VergiKimlik_No,
            IBAN_No,
            Email
        }
    }
}

