using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Services
{
    class ImeSettings
    {
        public static Color DefaultGridSelectedRowColor = Color.FromArgb(90, 185, 194); 
        public static Color GridDeletedRowColor = Color.FromArgb(252, 97, 97); 
        public static Color GridSentToLogoRowColor = Color.FromArgb(159, 255, 154);
        public static Color DefaultGridRowColor = Color.Empty;
        public static Color GridPurchaseOrderCreatedRowColor = Color.FromArgb(114, 155, 185);

        public static string ConnectionStringLogo = new System.Data.SqlClient.SqlConnectionStringBuilder { DataSource = "195.201.76.136", Password = "ime1453..", UserID = "sa", InitialCatalog = "LOGO"/*, IntegratedSecurity = true */}.ConnectionString;
        public static string ConnectionStringIME = new System.Data.SqlClient.SqlConnectionStringBuilder { DataSource = "195.201.76.136", Password = "ime1453..", UserID = "sa", InitialCatalog = "IME"/*, IntegratedSecurity = true */}.ConnectionString;
        public static string FrmNo = "001";
        public static string DnmNo = "01";
    }
}
